Public Class Result
    Inherits System.Web.UI.Page

#Region " Web 窗体设计器生成的代码 "

    '该调用是 Web 窗体设计器所必需的。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHint As System.Web.UI.WebControls.Label
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents HyperLink2 As System.Web.UI.WebControls.HyperLink

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

        Me.Session("FirstTime") = 1
        Me.lblHint.Text = Me.Session("userID") + "，您好！您的考试成绩为：" + Me.Session("myScore").ToString() + "分，总分为" + Me.Session("totalScore").ToString() + "分<br>"
    End Sub
End Class
