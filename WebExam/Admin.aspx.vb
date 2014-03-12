Public Class Admin
    Inherits System.Web.UI.Page

#Region " Web 窗体设计器生成的代码 "

    '该调用是 Web 窗体设计器所必需的。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hlnkStu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlnkAdmin As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlnkSubject As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlnkScore As System.Web.UI.WebControls.HyperLink
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents HyperLink2 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents HyperLink3 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents HyperLink5 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlnkCancle As System.Web.UI.WebControls.HyperLink
    Protected WithEvents ibtnStu As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnAdmin As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnSubject As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnScore As System.Web.UI.WebControls.ImageButton

    '注意: 以下占位符声明是 Web 窗体设计器所必需的。
    '不要删除或移动它。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: 此方法调用是 Web 窗体设计器所必需的
        '不要使用代码编辑器修改它。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '在此处放置初始化页的用户代码

        If Me.Session("UserId") = "" Then
            Me.Response.Redirect("Login.aspx")
            Exit Sub
        End If

        Me.hlnkStu.NavigateUrl = "mgStudent.aspx"
        Me.hlnkAdmin.NavigateUrl = "mgAdmin.aspx"
        Me.hlnkScore.NavigateUrl = "mgScore.aspx"
        Me.hlnkSubject.NavigateUrl = "mgSubject.aspx"

        Me.hlnkCancle.NavigateUrl = "Login.aspx"
    End Sub

    Private Sub ibtnStu_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnStu.Click
        Me.Response.Redirect("mgStudent.aspx")
    End Sub

    Private Sub ibtnAdmin_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnAdmin.Click
        Me.Response.Redirect("mgAdmin.aspx")
    End Sub

    Private Sub ibtnSubject_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSubject.Click
        Me.Response.Redirect("mgSubject.aspx")
    End Sub

    Private Sub ibtnScore_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnScore.Click
        Me.Response.Redirect("mgScore.aspx")
    End Sub
End Class
