Imports System.Data
Imports System.Data.OleDb

Public Class mgSubject
    Inherits System.Web.UI.Page

#Region " Web 窗体设计器生成的代码 "

    '该调用是 Web 窗体设计器所必需的。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnCannel As System.Web.UI.WebControls.Button
    Protected WithEvents txtTestTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSubName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWarning As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSingleper As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMultiNum As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJudgeNum As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJudgeper As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSingleNum As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMultiper As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnEdit As System.Web.UI.WebControls.Button

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

    Private Sub Initialize()
        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql = "select * from subject"
        Try
            myDbConn.Open()
            Dim myDbAdapt = New OleDbDataAdapter(strSql, myDbConn)

            ds = New DataSet
            myDbAdapt.Fill(ds, "subject")
            myDataGrid.PagerStyle.Mode = PagerMode.NumericPages
            myDataGrid.DataSource = ds.Tables("subject")
            myDataGrid.DataKeyField = "subName"
            myDataGrid.DataBind()
            myDbConn.Close()
        Catch ex As OleDbException
            myDbConn.Close()
            Throw ex
        Finally
        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化参数
        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If
        Me.btnEdit.Enabled = False
        Me.Initialize()
    End Sub

    Private Sub myDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles myDataGrid.PageIndexChanged
        myDataGrid.CurrentPageIndex = e.NewPageIndex
        myDataGrid.DataBind()
    End Sub

    Private Sub myDataGrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.EditCommand

        Dim ii = e.Item.ItemIndex + myDataGrid.PageSize * myDataGrid.CurrentPageIndex
        Me.txtSubName.Text = ds.Tables("subject").Rows(ii).Item("subName")
        Me.txtSubName.ReadOnly = True
        Me.txtTestTime.Text = ds.Tables("subject").Rows(ii).Item("testTime")
        Me.txtSingleNum.Text = ds.Tables("subject").Rows(ii).Item("singleNum")
        Me.txtSingleper.Text = ds.Tables("subject").Rows(ii).Item("singleper")
        Me.txtMultiNum.Text = ds.Tables("subject").Rows(ii).Item("multiNum")
        Me.txtMultiper.Text = ds.Tables("subject").Rows(ii).Item("multiper")
        Me.txtJudgeNum.Text = ds.Tables("subject").Rows(ii).Item("judgeNum")
        Me.txtJudgeper.Text = ds.Tables("subject").Rows(ii).Item("judgeper")
        Me.btnAdd.Text = "修改"
        Me.lblWarning.Text = "修改课程信息"
        Me.btnEdit.Enabled = True
        Me.Session("subName") = ds.Tables("subject").Rows(ii).Item("subName")
        myDataGrid.DataBind()
    End Sub

    Private Sub myDataGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.ItemCommand
        myDataGrid.SelectedIndex = e.Item.ItemIndex
        myDataGrid.DataBind()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.txtSubName.Text.Trim() = "" Then
            lblWarning.Text = "请先输入课程名"
            Exit Sub
        ElseIf Me.txtTestTime.Text = "" Then
            lblWarning.Text = "请先输入考试时间"
            Exit Sub
        End If

        Dim sn As String
        Dim sp As String
        Dim mn As String
        Dim mp As String
        Dim jn As String
        Dim jp As String

        If (Me.txtSingleNum.Text = "") Then
            sn = "0"
        Else
            sn = Me.txtSingleNum.Text.Trim()
        End If
        If (Me.txtSingleper.Text = "") Then
            sp = "0"
        Else
            sp = Me.txtSingleper.Text.Trim()
        End If
        If (Me.txtMultiNum.Text = "") Then
            mn = "0"
        Else
            mn = Me.txtMultiNum.Text.Trim()
        End If
        If (Me.txtMultiper.Text = "") Then
            mp = "0"
        Else
            mp = Me.txtMultiper.Text.Trim()
        End If
        If (Me.txtJudgeNum.Text = "") Then
            jn = "0"
        Else
            jn = Me.txtJudgeNum.Text.Trim()
        End If
        If (Me.txtJudgeper.Text = "") Then
            jp = "0"
        Else
            jp = Me.txtJudgeper.Text.Trim()
        End If

        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql As New String("")
        Dim myReader As OleDbDataReader = Nothing
        strSql = [String].Format("select subName from subject where subName='{0}'", Me.txtSubName.Text.Trim())
        myDbComm = New OleDbCommand(strSql, myDbConn)
        Try
            myDbConn.Open()
            myReader = myDbComm.ExecuteReader()

            If (Me.txtSubName.ReadOnly = True) Then
                strSql = [String].Format("update subject set singleper='{0}',multiper='{1}',judgeper='{2}',singleNum='{3}',multiNum='{4}',judgeNum='{5}',testTime='{6}' where subName='{7}'", _
                    sp, mp, jp, sn, mn, jn, Me.txtTestTime.Text, Me.txtSubName.Text)
            Else
                If (myReader.Read()) Then
                    lblWarning.Text = "该课程已存在，请重新输入"
                    Me.txtSubName.Text = ""
                    myDbConn.Close()
                    Exit Sub
                Else
                    strSql = [String].Format("insert into subject values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", _
                        Me.txtSubName.Text, sp, mp, jp, sn, mn, jn, Me.txtTestTime.Text)
                End If
            End If
            myDbConn.Close()
            myDbComm.CommandText = strSql

            myDbConn.Open()
            myDbComm.ExecuteNonQuery()
            myDbConn.Close()
            Me.txtSubName.Text = ""
            Me.txtTestTime.Text = ""
            Me.txtSubName.ReadOnly = False
            Me.txtSingleNum.Text = ""
            Me.txtSingleper.Text = ""
            Me.txtMultiNum.Text = ""
            Me.txtMultiper.Text = ""
            Me.txtJudgeNum.Text = ""
            Me.txtJudgeper.Text = ""

            Me.btnAdd.Text = "添加"
            Me.lblWarning.Text = "添加新课程"
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
        Me.txtSubName.Text = ""
        Me.txtTestTime.Text = ""
        Me.txtSubName.ReadOnly = False
        Me.txtSingleNum.Text = ""
        Me.txtSingleper.Text = ""
        Me.txtMultiNum.Text = ""
        Me.txtMultiper.Text = ""
        Me.txtJudgeNum.Text = ""
        Me.txtJudgeper.Text = ""
        Me.btnAdd.Text = "添加"
        Me.lblWarning.Text = "添加新课程"
        myDataGrid.SelectedIndex = -1
        myDataGrid.DataBind()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Response.Redirect("admin.aspx")
    End Sub

    Private Sub myDataGrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.DeleteCommand
        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql As New String("")
        strSql = [String].Format("delete from subject where subName='{0}'", ds.Tables("subject").Rows(e.Item.ItemIndex + myDataGrid.PageSize * myDataGrid.CurrentPageIndex).Item("subName"))
        myDbComm = New OleDbCommand(strSql, myDbConn)
        Try
            myDbConn.Open()
            myDbComm.ExecuteNonQuery()
            myDbConn.Close()
            Me.txtSubName.Text = ""
            Me.txtTestTime.Text = ""
            Me.txtSubName.ReadOnly = False
            Me.txtSingleNum.Text = ""
            Me.txtSingleper.Text = ""
            Me.txtMultiNum.Text = ""
            Me.txtMultiper.Text = ""
            Me.txtJudgeNum.Text = ""
            Me.txtJudgeper.Text = ""
            Me.btnAdd.Text = "添加"
            Me.lblWarning.Text = "添加新课程"
            myDataGrid.SelectedIndex = -1
            Me.Initialize()
        Catch ex As OleDbException
            myDbConn.Close()
            Throw ex
        Finally
            myDbConn.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Me.Response.Redirect("mgQuestion.aspx")
    End Sub
End Class

