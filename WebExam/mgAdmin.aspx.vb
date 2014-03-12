Imports System.Data
Imports System.Data.OleDb
Public Class mgAdmin1
    Inherits System.Web.UI.Page

#Region " Web ������������ɵĴ��� "

    '�õ����� Web ���������������ġ�
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnCannel As System.Web.UI.WebControls.Button
    Protected WithEvents txtPwd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUserID As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents lblWarning As System.Web.UI.WebControls.Label

    'ע��: ����ռλ�������� Web ���������������ġ�
    '��Ҫɾ�����ƶ�����
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: �˷��������� Web ����������������
        '��Ҫʹ�ô���༭���޸�����
        InitializeComponent()
    End Sub

#End Region

    Dim myDbConn As OleDbConnection
    Dim myDbComm As OleDbCommand
    Dim ds As DataSet
    Dim myDbAdapt As OleDbDataAdapter

    Private Sub Initialize()
        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql = "SELECT userID, pwd FROM userTable WHERE (role='1') ORDER BY userID"
        Try
            myDbConn.Open()
            Dim myDbAdapt = New OleDbDataAdapter(strSql, myDbConn)

            ds = New DataSet
            myDbAdapt.Fill(ds, "userTable")
            myDataGrid.PagerStyle.Mode = PagerMode.NumericPages
            myDataGrid.DataSource = ds.Tables("userTable")
            myDataGrid.DataKeyField = "userID"
            myDataGrid.DataBind()
            myDbConn.Close()
        Catch ex As OleDbException
            myDbConn.Close()
            'Throw ex
        Finally
        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '��ʼ������
        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        Me.Initialize()
    End Sub

    Private Sub myDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles myDataGrid.PageIndexChanged
        myDataGrid.CurrentPageIndex = e.NewPageIndex
        myDataGrid.DataBind()
    End Sub

    Private Sub myDataGrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.EditCommand
        Dim ii = e.Item.ItemIndex + myDataGrid.PageSize * myDataGrid.CurrentPageIndex
        Me.txtUserID.Text = ds.Tables("userTable").Rows(ii).Item("userID")
        Me.txtUserID.ReadOnly = True
        Me.txtPwd.Text = ds.Tables("userTable").Rows(ii).Item("pwd")
        Me.btnAdd.Text = "�޸�"
        Me.lblWarning.Text = "�޸Ĺ���Ա��Ϣ"
    End Sub

    Private Sub myDataGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.ItemCommand
        myDataGrid.SelectedIndex = e.Item.ItemIndex
        myDataGrid.DataBind()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.txtUserID.Text.Trim() = "" Then
            lblWarning.Text = "���������û���"
            Exit Sub
        ElseIf Me.txtPwd.Text = "" Then
            lblWarning.Text = "������������"
            Exit Sub
        End If

        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql As New String("")
        Dim myReader As OleDbDataReader = Nothing
        strSql = [String].Format("select * from userTable where userID='{0}'", Me.txtUserID.Text.Trim())
        myDbComm = New OleDbCommand(strSql, myDbConn)
        Try
            myDbConn.Open()
            myReader = myDbComm.ExecuteReader()

            If (Me.txtUserID.ReadOnly = True) Then
                strSql = [String].Format("update userTable set pwd='{0}' where userId='{1}'", Me.txtPwd.Text, Me.txtUserID.Text.Trim())
            Else
                If (myReader.Read()) Then
                    lblWarning.Text = "���û����Ѵ��ڣ�����������"
                    Me.txtUserID.Text = ""
                    myDbConn.Close()
                    Exit Sub
                Else
                    strSql = [String].Format("insert into userTable values('{0}','{1}','1')", Me.txtUserID.Text.Trim(), Me.txtPwd.Text)
                End If
            End If

            myDbConn.Close()
            myDbComm.CommandText = strSql

            myDbConn.Open()
            myDbComm.ExecuteNonQuery()
            myDbConn.Close()
            Me.txtPwd.Text = ""
            Me.txtUserID.Text = ""
            Me.txtUserID.ReadOnly = False
            Me.btnAdd.Text = "���"
            Me.lblWarning.Text = "��ӹ���Ա��Ϣ"
            myDataGrid.SelectedIndex = -1
            Me.Initialize()
        Catch ex As OleDbException
            myDbConn.Close()
            Throw ex
        Finally
            myDbConn.Close()
        End Try
    End Sub

    Private Sub btnCannel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCannel.Click
        Me.txtPwd.Text = ""
        Me.txtUserID.Text = ""
        Me.txtUserID.ReadOnly = False
        Me.btnAdd.Text = "���"
        Me.lblWarning.Text = "��ӹ���Ա��Ϣ"
        myDataGrid.SelectedIndex = -1
        myDataGrid.DataBind()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Response.Redirect("admin.aspx")
    End Sub

    Private Sub myDataGrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.DeleteCommand
        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql As New String("")
        strSql = [String].Format("delete from userTable where userID='{0}'", ds.Tables("userTable").Rows(e.Item.ItemIndex + myDataGrid.PageSize * myDataGrid.CurrentPageIndex).Item("userID"))
        myDbComm = New OleDbCommand(strSql, myDbConn)
        Try
            myDbConn.Open()
            myDbComm.ExecuteNonQuery()
            myDbConn.Close()
            Me.txtPwd.Text = ""
            Me.txtUserID.Text = ""
            Me.txtUserID.ReadOnly = False
            Me.btnAdd.Text = "���"
            Me.lblWarning.Text = "���ѧ����Ϣ"
            myDataGrid.SelectedIndex = -1
            Me.Initialize()
        Catch ex As OleDbException
            myDbConn.Close()
            Throw ex
        Finally
            myDbConn.Close()
        End Try
    End Sub
End Class
