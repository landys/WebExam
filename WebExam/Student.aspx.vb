Imports System.Data
Imports System.Data.OleDb

Public Class Student
    Inherits System.Web.UI.Page

#Region " Web ������������ɵĴ��� "

    '�õ����� Web ���������������ġ�
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
    Dim myDbAdapt2 As OleDbDataAdapter
    Dim ds2 As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�ڴ˴����ó�ʼ��ҳ���û�����

        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        Me.btnYes.Enabled = False

        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        Me.lblWelcome.Text = "����, " + Me.Session("UserID") + ", ��ӭʹ�����Ͽ���ϵͳ, ����!"
        Me.lblRule.Text = "���Թ���<br>" + "�벻Ҫ��<b><font color=#FF0000>F5</font></b>��ť����ˢ�»�<b><font color=#FF0000>����</font></b>��ť���ˣ�������ĳɼ�������Ϊ0�֡�"
        Me.lable2.Text = "���Ѳμӿ��ԵĿ�Ŀ���������£�"
        Me.Label3.Text = "<H2>����ѡ���Կ�Ŀ��</H2>"

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
