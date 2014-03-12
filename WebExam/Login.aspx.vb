Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO

Public Class Login
    Inherits System.Web.UI.Page

#Region " Web 窗体设计器生成的代码 "

    '该调用是 Web 窗体设计器所必需的。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents lblPwd As System.Web.UI.WebControls.Label
    Protected WithEvents lblAffCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblRole As System.Web.UI.WebControls.Label
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPwd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAffCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlstRole As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblWarning As System.Web.UI.WebControls.Label
    Protected WithEvents txtShowCode As System.Web.UI.WebControls.TextBox

    '注意: 以下占位符声明是 Web 窗体设计器所必需的。
    '不要删除或移动它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此方法调用是 Web 窗体设计器所必需的
        '不要使用代码编辑器修改它。
        InitializeComponent()
    End Sub

#End Region
    Private Sub GetRandCode()
        Dim rr As New Random
        Dim ii As Integer
        Dim i As Integer
        Me.Session("AffCode") = ""
        For i = 1 To 4
            ii = rr.Next(10)
            Me.Session("AffCode") = Me.Session("AffCode") + ii.ToString()
        Next
        Me.txtShowCode.Text = Me.Session("AffCode")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在此处放置初始化页的用户代码
        If Not IsPostBack Then
            GetRandCode()
        End If
        Me.lblWarning.Visible = False   '影响警言标签
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Me.txtName.Text.Trim() = "" Or Me.txtPwd.Text.Trim() = "" Or Me.txtAffCode.Text.Trim() = "" Then
            Me.lblWarning.Text = "提醒：请先输入登录信息"
            Me.lblWarning.Visible = True
            Exit Sub
        End If

        If Me.txtAffCode.Text.Trim() <> Me.Session("AffCode") Then
            Me.lblWarning.Text = "提醒：验证码输入有错, 请重新输入"
            Me.lblWarning.Visible = True
            Exit Sub
        End If

        Dim myDbConn As OleDbConnection
        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql As String
        strSql = "Select * from userTable Where userId='" + Me.txtName.Text.Trim() + "' and " + _
            "pwd='" + Me.txtPwd.Text.Trim() + "' and " + "role='" + Me.ddlstRole.SelectedValue + "'"
        Dim myDbReader As OleDbDataReader = Nothing
        Dim myDbComm As OleDbCommand
        myDbComm = New OleDbCommand(strSql, myDbConn)
        Try
            myDbConn.Open()
            myDbReader = myDbComm.ExecuteReader()

            If (myDbReader.Read()) Then
                Me.Session("UserId") = Me.txtName.Text.Trim()
                Me.Session("Role") = Me.ddlstRole.SelectedValue
                If Me.Session("Role") = "1" Then
                    Me.Response.Redirect("Admin.aspx")
                ElseIf Me.Session("Role") = "0" Then
                    Me.Response.Redirect("Student.aspx")
                Else
                    Me.Response.Redirect("error.htm") '错误提示
                End If
            Else
                lblWarning.Text = "提醒：错误的用户名或密码，请重新输入"
                lblWarning.Visible = True
            End If
            myDbReader.Close()
            myDbConn.Close()
        Catch ex As OleDbException
            If myDbReader.IsClosed() = False Then
                myDbReader.Close()
                myDbConn.Close()
            End If
            Me.Response.Redirect("error.htm") '错误提示
            'Throw ex
        Finally
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtAffCode.Text = ""
        Me.txtName.Text = ""
        Me.txtPwd.Text = ""
    End Sub
End Class
