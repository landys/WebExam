Imports System.Data
Imports System.Data.OleDb

Public Class mgScore
    Inherits System.Web.UI.Page

#Region " Web 窗体设计器生成的代码 "

    '该调用是 Web 窗体设计器所必需的。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents myDatagrid As System.Web.UI.WebControls.DataGrid

    '注意: 以下占位符声明是 Web 窗体设计器所必需的。
    '不要删除或移动它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此方法调用是 Web 窗体设计器所必需的
        '不要使用代码编辑器修改它。
        InitializeComponent()
    End Sub

#End Region
    Dim myDbConn As OleDbConnection
    Dim myDbComm As OleDbCommand
    Dim ds As DataSet
    Dim myDbAdapt As OleDbDataAdapter

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在此处放置初始化页的用户代码
        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql = [String].Format("select * from score order by userID")

        Try
            myDbConn.Open()
            myDbAdapt = New OleDbDataAdapter(strSql, myDbConn)

            ds = New DataSet
            myDbAdapt.Fill(ds, "score")
            myDatagrid.PagerStyle.Mode = PagerMode.NumericPages
            myDatagrid.DataSource = ds.Tables("score")
            myDatagrid.DataBind()
            myDbConn.Close()
        Catch ex As OleDbException
            myDbConn.Close()
            'Throw ex
        Finally
            myDbConn.Close()
        End Try
    End Sub

    Private Sub myDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles myDatagrid.PageIndexChanged
        myDatagrid.CurrentPageIndex = e.NewPageIndex
        myDatagrid.DataBind()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Response.Redirect("Admin.aspx")
    End Sub
End Class
