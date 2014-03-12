<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Login.aspx.vb" Inherits="WebExam.Login"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body vLink="#008000" aLink="#008000" link="#008000" background="image/bg.jpg" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblName" style="Z-INDEX: 101; LEFT: 304px; POSITION: absolute; TOP: 208px" runat="server">用户名</asp:label>
			<asp:label id="lblPwd" style="Z-INDEX: 102; LEFT: 304px; POSITION: absolute; TOP: 240px" runat="server">密码</asp:label>
			<asp:label id="lblAffCode" style="Z-INDEX: 103; LEFT: 304px; POSITION: absolute; TOP: 304px"
				runat="server">验证码</asp:label><asp:label id="lblRole" style="Z-INDEX: 104; LEFT: 304px; POSITION: absolute; TOP: 272px" runat="server">身份</asp:label>
			<asp:textbox id="txtName" style="Z-INDEX: 105; LEFT: 376px; POSITION: absolute; TOP: 208px" runat="server"
				Width="156" Height="24"></asp:textbox><asp:textbox id="txtPwd" style="Z-INDEX: 106; LEFT: 376px; POSITION: absolute; TOP: 240px" runat="server"
				Width="156" Height="24" TextMode="Password"></asp:textbox><asp:textbox id="txtAffCode" style="Z-INDEX: 107; LEFT: 376px; POSITION: absolute; TOP: 304px"
				runat="server" Width="67" Height="26"></asp:textbox><asp:dropdownlist id="ddlstRole" style="Z-INDEX: 108; LEFT: 376px; POSITION: absolute; TOP: 272px"
				runat="server" Width="156px" Height="24px">
				<asp:ListItem Value="0" Selected="True">学生</asp:ListItem>
				<asp:ListItem Value="1">管理员</asp:ListItem>
			</asp:dropdownlist><asp:button id="btnLogin" style="Z-INDEX: 109; LEFT: 344px; POSITION: absolute; TOP: 368px"
				runat="server" Width="57" Height="24" Text="进入"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 110; LEFT: 440px; POSITION: absolute; TOP: 368px"
				runat="server" Width="57px" Height="24px" Text="取消"></asp:button><asp:label id="lblTitle" style="Z-INDEX: 111; LEFT: 214px; POSITION: absolute; TOP: 56px" runat="server"
				Width="476px" Font-Names="Harlow Solid Italic" Font-Size="XX-Large" ForeColor="#4E8EC0">Web&nbsp;&nbsp;Exam&nbsp;&nbsp;System</asp:label><asp:label id="lblWarning" style="Z-INDEX: 112; LEFT: 288px; POSITION: absolute; TOP: 432px"
				runat="server" Width="408px">Label</asp:label>
			<asp:TextBox id="txtShowCode" style="Z-INDEX: 113; LEFT: 456px; POSITION: absolute; TOP: 304px"
				runat="server" Height="26px" Width="67px" ReadOnly="True" ForeColor="Black" BackColor="Transparent"
				BorderColor="Transparent"></asp:TextBox></form>
	</body>
</HTML>
