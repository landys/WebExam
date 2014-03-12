<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Admin.aspx.vb" Inherits="WebExam.Admin"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Admin</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:HyperLink id="hlnkSubject" runat="server" Width="120px" style="Z-INDEX: 103; LEFT: 216px; POSITION: absolute; TOP: 384px">考试科目管理</asp:HyperLink></P>
			<P>&nbsp;</P>
			<asp:HyperLink id="hlnkStu" runat="server" Width="128px" style="Z-INDEX: 104; LEFT: 208px; POSITION: absolute; TOP: 192px">学生信息管理</asp:HyperLink>
			<P>
				<asp:HyperLink id="hlnkAdmin" runat="server" Width="160px" style="Z-INDEX: 105; LEFT: 536px; POSITION: absolute; TOP: 192px">管理员信息管理</asp:HyperLink></P>
			<asp:HyperLink id="hlnkScore" runat="server" Width="114px" style="Z-INDEX: 102; LEFT: 544px; POSITION: absolute; TOP: 384px">学生成绩管理</asp:HyperLink>
			<asp:HyperLink id="hlnkCancle" style="Z-INDEX: 101; LEFT: 400px; POSITION: absolute; TOP: 432px"
				runat="server">退出管理</asp:HyperLink>
			<asp:ImageButton id="ibtnStu" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 56px" runat="server"
				Width="150px" Height="113px" ImageUrl="image\\mouseout.gif"
				onmouseover="this.src='image\\mousein.gif';" onmouseout="this.src='image\\mouseout.gif';"></asp:ImageButton>
			<asp:ImageButton id="ibtnAdmin" style="Z-INDEX: 107; LEFT: 520px; POSITION: absolute; TOP: 56px"
				runat="server" Width="150px" Height="113px" ImageUrl="image\\mouseout.gif"
				onmouseover="this.src='image\\mousein.gif';" onmouseout="this.src='image\\mouseout.gif';"></asp:ImageButton>
			<asp:ImageButton id="ibtnSubject" style="Z-INDEX: 108; LEFT: 192px; POSITION: absolute; TOP: 248px"
				runat="server" Width="150px" Height="113px" ImageUrl="image\\mouseout.gif"
				onmouseover="this.src='image\\mousein.gif';" onmouseout="this.src='image\\mouseout.gif';"></asp:ImageButton>
			<asp:ImageButton id="ibtnScore" style="Z-INDEX: 109; LEFT: 520px; POSITION: absolute; TOP: 248px"
				runat="server" Width="150px" Height="113px" ImageUrl="image\\mouseout.gif"
				onmouseover="this.src='image\\mousein.gif';" onmouseout="this.src='image\\mouseout.gif';"></asp:ImageButton>
		</form>
	</body>
</HTML>
