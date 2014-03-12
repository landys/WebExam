Imports System.Data
Imports System.Data.OleDb

Public Class mgQuestion
    Inherits System.Web.UI.Page

#Region " Web 窗体设计器生成的代码 "

    '该调用是 Web 窗体设计器所必需的。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents txtQustion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSubName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtA As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAnswer As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtB As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbtnSingle As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbtnMulti As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbtnJudge As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblHint As System.Web.UI.WebControls.Label
    Protected WithEvents lblWarning As System.Web.UI.WebControls.Label
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button

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
        Me.rbtnSingle.Checked = True
        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql = [String].Format("select * from question where subName='{0}'", Me.Session("subName"))
        Try
            myDbConn.Open()
            Dim myDbAdapt = New OleDbDataAdapter(strSql, myDbConn)

            ds = New DataSet
            myDbAdapt.Fill(ds, "question")
            myDataGrid.PagerStyle.Mode = PagerMode.NumericPages
            myDataGrid.DataSource = ds.Tables("question")
            myDataGrid.DataKeyField = "qId"
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

        Me.txtSubName.Text = Me.Session("subName")
        Me.txtSubName.ReadOnly = True
        Me.Initialize()
    End Sub

    Private Sub myDataGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles myDataGrid.PageIndexChanged
        myDataGrid.CurrentPageIndex = e.NewPageIndex
        myDataGrid.DataBind()
    End Sub

    Private Sub myDataGrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.EditCommand
        'myDataGrid.EditItemIndex = e.Item.ItemIndex

        Dim ii = e.Item.ItemIndex + myDataGrid.PageSize * myDataGrid.CurrentPageIndex
        Me.txtSubName.Text = ds.Tables("question").Rows(e.Item.ItemIndex).Item("subName")
        Me.txtSubName.ReadOnly = True
        Me.Session("qId") = ds.Tables("question").Rows(e.Item.ItemIndex).Item("qId")
        Me.txtQustion.Text = ds.Tables("question").Rows(ii).Item("ques")
        Me.txtSubName.Text = ds.Tables("question").Rows(ii).Item("subName")
        Me.txtA.Text = ds.Tables("question").Rows(ii).Item("A")
        Me.txtB.Text = ds.Tables("question").Rows(ii).Item("B")
        Me.txtC.Text = ds.Tables("question").Rows(ii).Item("C")
        Me.txtD.Text = ds.Tables("question").Rows(ii).Item("D")
        Me.txtAnswer.Text = ds.Tables("question").Rows(ii).Item("answer")

        rbtnJudge.Checked = False
        rbtnMulti.Checked = False
        rbtnSingle.Checked = False
        Dim ss As String = ds.Tables("question").Rows(ii).Item("type")
        If ss = "单选题" Then
            rbtnSingle.Checked = True
        ElseIf ss = "多选题" Then
            rbtnMulti.Checked = True
        Else
            rbtnJudge.Checked = True
        End If

        Me.Session("flag") = 1
        Me.btnAdd.Text = "修改"
        Me.lblHint.Text = "修改问题信息"
        Me.lblWarning.Text = "<font color=red>带*各项均必须完全填写</font>"
        myDataGrid.DataBind()
    End Sub

    Private Sub myDataGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.ItemCommand
        myDataGrid.SelectedIndex = e.Item.ItemIndex
        myDataGrid.DataBind()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.txtQustion.Text.Trim() = "" Then
            lblWarning.Text = "请先输入问题"
            Exit Sub
        ElseIf Me.txtSubName.Text = "" Then
            lblWarning.Text = "请先输入课程名"
            Exit Sub
        ElseIf Me.txtAnswer.Text.Trim() = "" Then
            lblWarning.Text = "请先输入答案"
            Exit Sub
        End If

        Dim aa As String
        Dim bb As String
        Dim cc As String
        Dim dd As String
        Dim ans As String

        If (Me.txtA.Text = "") Then
            aa = "0"
        Else
            aa = Me.txtA.Text.Trim()
        End If
        If (Me.txtB.Text = "") Then
            bb = "0"
        Else
            bb = Me.txtB.Text.Trim()
        End If
        If (Me.txtC.Text = "") Then
            cc = "0"
        Else
            cc = Me.txtC.Text.Trim()
        End If
        If (Me.txtD.Text = "") Then
            dd = "0"
        Else
            dd = Me.txtD.Text.Trim()
        End If
        If (Me.rbtnJudge.Checked = True) Then
            ans = "判断题"
        ElseIf Me.rbtnMulti.Checked = True Then
            ans = "多选题"
        Else
            ans = "单选题"
        End If

        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql As New String("")
        Dim myReader As OleDbDataReader = Nothing
        strSql = [String].Format("select * from question where ques='{0}'", Me.txtQustion.Text.Trim())
        myDbComm = New OleDbCommand(strSql, myDbConn)
        'Try
            myDbConn.Open()
            myReader = myDbComm.ExecuteReader()

        If (Me.Session("flag") = 1) Then
            strSql = [String].Format("update question set ques='{0}',A='{1}',B='{2}',C='{3}',D='{4}',answer='{5}',type='{6}' where qId={7}", _
                Me.txtQustion.Text.Trim(), aa, bb, cc, dd, Me.txtAnswer.Text(), ans, Me.Session("qId"))
        Else
            If (myReader.Read()) Then
                lblWarning.Text = "该问题已存在，请重新输入"
                Me.txtSubName.Text = ""
                myDbConn.Close()
                Exit Sub
            Else
                strSql = [String].Format("insert into question (ques,A,B,C,D,answer,type,subName) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", _
                    Me.txtQustion.Text.Trim(), aa, bb, cc, dd, Me.txtAnswer.Text(), ans, Me.txtSubName.Text.Trim())
            End If
        End If
        myReader.Close()
        myDbConn.Close()
        myDbComm.CommandText = strSql

        myDbConn.Open()
        myDbComm.ExecuteNonQuery()
        myDbConn.Close()

        Me.txtQustion.Text = ""
        Me.txtQustion.ReadOnly = False
        Me.txtA.Text = ""
        Me.txtB.Text = ""
        Me.txtC.Text = ""
        Me.txtD.Text = ""
        Me.txtAnswer.Text = ""
        rbtnJudge.Checked = False
        rbtnMulti.Checked = False
        rbtnSingle.Checked = True
        Me.Session("flag") = 0
        Me.btnAdd.Text = "添加"
        Me.lblHint.Text = "添加新问题"
        myDataGrid.SelectedIndex = -1
        Me.Initialize()
        ' Catch ex As OleDbException
        '   myDbConn.Close()
        '  Throw ex
        'Finally
        '    myDbConn.Close()
        ' End Try
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Response.Redirect("admin.aspx")
    End Sub

    Private Sub myDataGrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles myDataGrid.DeleteCommand
        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        Dim strSql As New String("")
        strSql = [String].Format("delete from question where qId={0}", ds.Tables("question").Rows(e.Item.ItemIndex + myDataGrid.PageSize * myDataGrid.CurrentPageIndex).Item("qId"))
        myDbComm = New OleDbCommand(strSql, myDbConn)
        ' Try
        myDbConn.Open()
        myDbComm.ExecuteNonQuery()
        myDbConn.Close()

        Me.txtQustion.Text = ""
        Me.txtQustion.ReadOnly = False
        Me.txtA.Text = ""
        Me.txtB.Text = ""
        Me.txtC.Text = ""
        Me.txtD.Text = ""
        Me.txtAnswer.Text = ""
        rbtnJudge.Checked = False
        rbtnMulti.Checked = False
        rbtnSingle.Checked = True

        Me.Session("flag") = 0
        Me.btnAdd.Text = "添加"
        Me.lblHint.Text = "添加新问题"
        myDataGrid.SelectedIndex = -1
        Me.Initialize()
        ' Catch ex As OleDbException
        '    myDbConn.Close()
        '    Throw ex
        ' Finally
        '   myDbConn.Close()
        ' End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtSubName.Text = ""
        Me.txtQustion.Text = ""
        Me.txtQustion.ReadOnly = False
        Me.txtA.Text = ""
        Me.txtB.Text = ""
        Me.txtC.Text = ""
        Me.txtD.Text = ""
        Me.txtAnswer.Text = ""
        rbtnJudge.Checked = False
        rbtnMulti.Checked = False
        rbtnSingle.Checked = True

        Me.Session("flag") = 0
        Me.btnAdd.Text = "添加"
        Me.lblWarning.Text = "添加新问题"
        myDataGrid.SelectedIndex = -1
        myDataGrid.DataBind()
    End Sub
End Class

