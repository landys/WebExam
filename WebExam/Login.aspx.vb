Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO

Public Class Login
    Inherits System.Web.UI.Page

#Region " Web ������������ɵĴ��� "

    '�õ����� Web ���������������ġ�
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

    'ע��: ����ռλ�������� Web ���������������ġ�
    '��Ҫɾ�����ƶ�����
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: �˷��������� Web ����������������
        '��Ҫʹ�ô���༭���޸�����
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
        '�ڴ˴����ó�ʼ��ҳ���û�����
        If Not IsPostBack Then
            GetRandCode()
        End If
        Me.lblWarning.Visible = False   'Ӱ�쾯�Ա�ǩ
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Me.txtName.Text.Trim() = "" Or Me.txtPwd.Text.Trim() = "" Or Me.txtAffCode.Text.Trim() = "" Then
            Me.lblWarning.Text = "���ѣ����������¼��Ϣ"
            Me.lblWarning.Visible = True
            Exit Sub
        End If

        If Me.txtAffCode.Text.Trim() <> Me.Session("AffCode") Then
            Me.lblWarning.Text = "���ѣ���֤�������д�, ����������"
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
                    Me.Response.Redirect("error.htm") '������ʾ
                End If
            Else
                lblWarning.Text = "���ѣ�������û��������룬����������"
                lblWarning.Visible = True
            End If
            myDbReader.Close()
            myDbConn.Close()
        Catch ex As OleDbException
            If myDbReader.IsClosed() = False Then
                myDbReader.Close()
                myDbConn.Close()
            End If
            Me.Response.Redirect("error.htm") '������ʾ
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
