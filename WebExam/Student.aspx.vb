Imports System.Data
Imports System.Data.OleDb

Public Class Student
    Inherits System.Web.UI.Page

#Region " Web 窗体设计器生成的代码 "

    '该调用是 Web 窗体设计器所必需的。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblWelcome As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents lblRule As System.Web.UI.WebControls.Label
    Protected WithEvents lable2 As System.Web.UI.WebControls.Label
    Protected WithEvents myDatagrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents myDatagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnYes As System.Web.UI.WebControls.Button

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
    Dim myDbAdapt2 As OleDbDataAdapter
    Dim ds2 As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在此处放置初始化页的用户代码

        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        Me.btnYes.Enabled = False

        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        Me.lblWelcome.Text = "您好, " + Me.Session("UserID") + ", 欢迎使用网上考试系统, 好运!"
        Me.lblRule.Text = "考试规则：<br>" + "请不要按<b><font color=#FF0000>F5</font></b>按钮进行刷新或按<b><font color=#FF0000>后退</font></b>按钮后退，否则你的成绩将被记为0分。"
        Me.lable2.Text = "您已参加考试的科目及分数如下："
        Me.Label3.Text = "<H2>请您选择考试科目：</H2>"

        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql = [String].Format("select * from score where userID='{0}'", Me.Session("UserId"))

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
        Try
            Dim strSql2 = [String].Format("select * from subject where subName not in (select subName from score where userID='cc')")
            myDbConn.Open()
            myDbAdapt2 = New OleDbDataAdapter(strSql2, myDbConn)

            ds2 = New DataSet
            myDbAdapt2.Fill(ds2, "subject")
            myDatagrid2.PagerStyle.Mode = PagerMode.NumericPages
            myDatagrid2.DataSource = ds2.Tables("subject")
            myDatagrid2.DataBind()
            myDbConn.Close()
        Catch ex As OleDbException
            myDbConn.Close()
            'Throw ex
        Finally
        End Try
    End Sub

    Private Sub myDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles myDatagrid.PageIndexChanged
        myDatagrid.CurrentPageIndex = e.NewPageIndex
        myDatagrid.DataBind()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Response.Redirect("Login.aspx")
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Me.myDatagrid2.SelectedIndex = -1
        Me.btnYes.Enabled = False
        Me.Session("FirstTime") = 0
        Me.Response.Redirect("Examine.aspx")
    End Sub

    Private Sub myDatagrid2_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDatagrid2.EditCommand
        Dim ii = e.Item.ItemIndex + myDatagrid2.PageSize * myDatagrid2.CurrentPageIndex
        Me.Session("subName") = ds2.Tables("subject").Rows(ii).Item("subName")
        Me.Session("singleper") = ds2.Tables("subject").Rows(ii).Item("singleper")
        Me.Session("multiper") = ds2.Tables("subject").Rows(ii).Item("multiper")
        Me.Session("judgeper") = ds2.Tables("subject").Rows(ii).Item("judgeper")
        Me.Session("singleNum") = ds2.Tables("subject").Rows(ii).Item("singleNum")
        Me.Session("multiNum") = ds2.Tables("subject").Rows(ii).Item("multiNum")
        Me.Session("judgeNum") = ds2.Tables("subject").Rows(ii).Item("judgeNum")
        Me.Session("testTime") = ds2.Tables("subject").Rows(ii).Item("testTime")
        Me.myDatagrid2.SelectedIndex = e.Item.ItemIndex
        Me.myDatagrid2.DataBind()
        Me.btnYes.Enabled = True
    End Sub
End Class
