Imports System.Timers
Imports System.Data
Imports System.Data.OleDb

Public Class Examine
    Inherits System.Web.UI.Page

    Private hour As Integer
    Protected WithEvents myPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Private mi As Integer
    Private si() As Integer
    Private ju() As Integer
    Protected WithEvents lblTestTime As System.Web.UI.WebControls.Label
    Private mu() As Integer

#Region " Web ������������ɵĴ��� "

    '�õ����� Web ���������������ġ�
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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

    Private Sub PrintPaper()
        Dim strSql As String
        Dim myReader As OleDbDataReader = Nothing

        Dim ii As Integer
        ii = 1
        Dim sii As String
        Dim i As Integer
        i = 1

        ' ����Ƿ���
        ReDim ju(Me.Session("judgeNum"))
        If (Me.Session("judgeNum") > 0) Then
            ii = ii + 1
            Me.myPanel.Controls.Add(New LiteralControl("<h2>һ���Ƿ���</h2><br>"))
            myDbConn = New OleDbConnection(Me.Application("DataBase"))
            strSql = New String("")

            strSql = [String].Format("select * from question where subName='{0}' and type='{1}' order by rnd(qId)", Me.Session("subName"), "�Ƿ���")

            myDbComm = New OleDbCommand(strSql, myDbConn)

            Try
                myDbConn.Open()
                myReader = myDbComm.ExecuteReader()

                While (myReader.Read() And i <= Me.Session("judgeNum"))
                    Me.myPanel.Controls.Add(New LiteralControl(i.ToString() + "��" + myReader.GetValue(1) + "<br>"))
                    Dim rb As New RadioButtonList
                    rb.ID = "judge" + i.ToString()
                    rb.Items.Add(New ListItem(myReader.GetValue(2), "1"))
                    rb.Items.Add(New ListItem(myReader.GetValue(3), "2"))
                    Me.myPanel.Controls.Add(rb)
                    Me.myPanel.Controls.Add(New LiteralControl("<hr>"))
                    ju(i - 1) = myReader.GetValue(0)
                    i = i + 1
                End While
                Me.Session("ju") = ju
                myDbConn.Close()
            Catch ex As OleDbException
                myDbConn.Close()
                Throw ex
            Finally
                myDbConn.Close()
            End Try
        End If
        Me.Session("iJudge") = i - 1

        ' �����ѡ��
        If (ii = 1) Then
            sii = "һ"
        Else
            sii = "��"
        End If
        i = 1
        ReDim si(Me.Session("SingleNum"))
        If (Me.Session("singleNum") > 0) Then
            ii = ii + 1
            Me.myPanel.Controls.Add(New LiteralControl("<h2>" + sii + "����ѡ��</h2><br>"))
            myDbConn = New OleDbConnection(Me.Application("DataBase"))
            strSql = New String("")

            strSql = [String].Format("select * from question where subName='{0}' and type='{1}' order by rnd(qId)", Me.Session("subName"), "��ѡ��")
            myDbComm = New OleDbCommand(strSql, myDbConn)


            Try
                myDbConn.Open()
                myReader = myDbComm.ExecuteReader()

                While (myReader.Read() And i <= Me.Session("singleNum"))
                    Me.myPanel.Controls.Add(New LiteralControl(i.ToString() + "��" + myReader.GetValue(1) + "<br>"))
                    Dim rb As New RadioButtonList
                    rb.ID = "single" + i.ToString()
                    rb.Items.Add(New ListItem("A. " + myReader.GetValue(2), "1"))
                    rb.Items.Add(New ListItem("B. " + myReader.GetValue(3), "2"))
                    rb.Items.Add(New ListItem("C. " + myReader.GetValue(4), "3"))
                    rb.Items.Add(New ListItem("D. " + myReader.GetValue(5), "4"))
                    Me.myPanel.Controls.Add(rb)
                    Me.myPanel.Controls.Add(New LiteralControl("<hr>"))
                    si(i - 1) = myReader.GetValue(0)
                    i = i + 1
                End While
                Me.Session("si") = si
                myDbConn.Close()
            Catch ex As OleDbException
                myDbConn.Close()
                Throw ex
            Finally
                myDbConn.Close()
            End Try
        End If
        Me.Session("iSingle") = i - 1

        ' �����ѡ��
        If (ii = 1) Then
            sii = "һ"
        ElseIf (ii = 2) Then
            sii = "��"
        Else
            sii = "��"
        End If
        i = 1
        ReDim mu(Me.Session("multiNum"))
        If (Me.Session("multiNum") > 0) Then
            Me.myPanel.Controls.Add(New LiteralControl("<h2>" + sii + "����ѡ��</h2><br>"))
            myDbConn = New OleDbConnection(Me.Application("DataBase"))
            strSql = New String("")

            strSql = [String].Format("select * from question where subName='{0}' and type='{1}' order by rnd(qId)", Me.Session("subName"), "��ѡ��")
            myDbComm = New OleDbCommand(strSql, myDbConn)

            Try
                myDbConn.Open()
                myReader = myDbComm.ExecuteReader()

                While (myReader.Read() And i <= Me.Session("multiNum"))
                    Me.myPanel.Controls.Add(New LiteralControl(i.ToString() + "��" + myReader.GetValue(1) + "<br>"))
                    Dim rb As New CheckBoxList
                    rb.ID = "multi" + i.ToString()
                    rb.Items.Add(New ListItem("A. " + myReader.GetValue(2), "1"))
                    rb.Items.Add(New ListItem("B. " + myReader.GetValue(3), "2"))
                    rb.Items.Add(New ListItem("C. " + myReader.GetValue(4), "3"))
                    rb.Items.Add(New ListItem("D. " + myReader.GetValue(5), "4"))
                    Me.myPanel.Controls.Add(rb)
                    Me.myPanel.Controls.Add(New LiteralControl("<hr>"))
                    mu(i - 1) = myReader.GetValue(0)
                    i = i + 1
                End While
                Me.Session("mu") = mu
                myDbConn.Close()
            Catch ex As OleDbException
                myDbConn.Close()
                Throw ex
            Finally
                myDbConn.Close()
            End Try
        End If
        Me.Session("iMulti") = i - 1
    End Sub

    Private Sub GetResult()
        Dim strSql As String
        Dim myReader As OleDbDataReader = Nothing

        Dim i As Integer
        Dim j As Integer
        Me.Session("myScore") = 0
        Dim myAnswer As New String("")

        myDbConn = New OleDbConnection(Me.Application("DataBase"))
        myDbConn.Open()
        strSql = New String("")

        For i = 1 To Me.Session("iJudge")
            strSql = [String].Format("select answer from question where qId={0}", Session("ju")(i - 1))
            myDbComm = New OleDbCommand(strSql, myDbConn)
            myReader = myDbComm.ExecuteReader()
            myReader.Read()

            Dim iii As String
            iii = Request.Form("judge" + i.ToString())
            If (iii = 1) Then
                myAnswer = "A"
            ElseIf (iii = 2) Then
                myAnswer = "B"
            Else
                myAnswer = "Z"
            End If

            If (myAnswer = myReader("answer")) Then
                Me.Session("myScore") = Me.Session("myScore") + Me.Session("judgeper")
            End If
            myReader.Close()
        Next

        myAnswer = ""
        For i = 1 To Me.Session("iSingle")
            strSql = [String].Format("select answer from question where qId={0}", Session("si")(i - 1))
            myDbComm = New OleDbCommand(strSql, myDbConn)
            myReader = myDbComm.ExecuteReader()
            myReader.Read()

            Dim iii As String
            iii = Request.Form("single" + i.ToString())
            If (iii = 1) Then
                myAnswer = "A"
            ElseIf (iii = 2) Then
                myAnswer = "B"
            ElseIf (iii = 3) Then
                myAnswer = "C"
            ElseIf (iii = 4) Then
                myAnswer = "D"
            Else
                myAnswer = "Z"
            End If

            If (myAnswer = myReader("answer")) Then
                Me.Session("myScore") = Me.Session("myScore") + Me.Session("judgeper")
            End If
            myReader.Close()
        Next

        For i = 1 To Me.Session("iMulti")
            strSql = [String].Format("select answer from question where qId={0}", Session("mu")(i - 1))
            myDbComm = New OleDbCommand(strSql, myDbConn)
            myReader = myDbComm.ExecuteReader()
            myReader.Read()

            myAnswer = ""
            If (Request.Form("multi" + i.ToString() + ":0") = "on") Then
                myAnswer = "A"
            End If
            If (Request.Form("multi" + i.ToString() + ":1") = "on") Then
                myAnswer = myAnswer + "B"
            End If
            If (Request.Form("multi" + i.ToString() + ":2") = "on") Then
                myAnswer = myAnswer + "C"
            End If
            If (Request.Form("multi" + i.ToString() + ":3") = "on") Then
                myAnswer = myAnswer + "D"
            End If

            If (myAnswer = myReader("answer")) Then
                Me.Session("myScore") = Me.Session("myScore") + Me.Session("judgeper")
            End If

            myReader.Close()
        Next
        myDbConn.Close()

        Me.Session("totalScore") = Me.Session("judgeper") * Me.Session("iJudge") + Me.Session("singleper") * Me.Session("iSingle") + Me.Session("multiper") * Me.Session("iMulti")
        Me.Session("iJudge") = 0
        Me.Session("iSingle") = 0
        Me.Session("iMulti") = 0
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '�ڴ˴����ó�ʼ��ҳ���û�����

        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        If (Me.Session("FirstTime") <> 0 Or IsPostBack) Then
            GetResult() ' �õ����Գɼ�
            myDbConn = New OleDbConnection(Me.Application("DataBase"))
            Dim strSql As New String("")
            strSql = [String].Format("insert into score values('{0}', '{1}', {2}, '{3}')", _
                Me.Session("userID"), Me.Session("subName"), Me.Session("myScore"), Now.ToString())
            myDbComm = New OleDbCommand(strSql, myDbConn)
            Try
                myDbConn.Open()
                myDbComm.ExecuteNonQuery()
                myDbConn.Close()
            Catch ex As OleDbException
                myDbConn.Close()
                Throw ex
            Finally
                myDbConn.Close()
            End Try

            Me.Response.Redirect("result.aspx")
            Exit Sub
        End If
        hour = Me.Session("testTime") \ 60
        mi = Me.Session("testTime") Mod 60

        Me.lblTestTime.Text = "<font color=blue>" + hour.ToString() + "Сʱ" + mi.ToString() + "��</font>"

        Me.Session("FirstTime") = 1

        PrintPaper()
        Me.myPanel.Controls(0).Visible = False
    End Sub
End Class
