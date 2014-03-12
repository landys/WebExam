<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mgScore.aspx.vb" Inherits="WebExam.mgScore"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mgScore</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="image\bg2.jpg">
		<form id="Form1" method="post" runat="server">
			<FONT face="ËÎÌå">
				<asp:Button id="btnBack" style="Z-INDEX: 102; LEFT: 456px; POSITION: absolute; TOP: 456px" runat="server"
					Width="72px" Text="·µ»Ø"></asp:Button>
				<asp:datagrid id="myDatagrid" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 32px"
					runat="server" Width="568px" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"
					BorderColor="black" BorderWidth="1" GridLines="Both" CellPadding="3" CellSpacing="0" Font-Name="ËÎÌå"
					Font-Size="11pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee"
					HorizontalAlign="Center" PageSize="15">
					<SelectedItemStyle Wrap="False" BorderStyle="Double" BorderColor="#8080FF" BackColor="#C0C0FF"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
					<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
					<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></FONT>
		</form>
	</body>
</HTML>
