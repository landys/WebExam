<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Result.aspx.vb" Inherits="WebExam.Result"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Result</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="image\110.jpg">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblHint" style="Z-INDEX: 101; LEFT: 264px; POSITION: absolute; TOP: 152px" runat="server"
				Width="536px">Label</asp:Label>
			<asp:HyperLink id="HyperLink1" style="Z-INDEX: 104; LEFT: 360px; POSITION: absolute; TOP: 208px"
				runat="server" NavigateUrl="Login.aspx">
				<font color="red" size="+0" face="楷体">返回登录界面</font></asp:HyperLink>
			<asp:HyperLink id="HyperLink2" style="Z-INDEX: 105; LEFT: 328px; POSITION: absolute; TOP: 256px"
				runat="server" NavigateUrl="Student.aspx">
				<font color="red" size="+0" face="楷体">返回考试界面继续考试</font></asp:HyperLink>
		</form>
	</body>
</HTML>
