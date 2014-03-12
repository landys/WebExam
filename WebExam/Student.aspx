<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Student.aspx.vb" Inherits="WebExam.Student"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Student</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:label id="lblWelcome" style="Z-INDEX: 101; LEFT: 168px; POSITION: absolute; TOP: 24px"
					runat="server" Width="488px" Height="31px" Font-Names="华文楷体" Font-Bold="True">lable</asp:label><asp:datagrid id="myDatagrid2" style="Z-INDEX: 107; LEFT: 144px; POSITION: absolute; TOP: 360px"
					runat="server" Width="568px" PageSize="5" HorizontalAlign="Center" AlternatingItemStyle-BackColor="#eeeeee" HeaderStyle-BackColor="#aaaadd" Font-Size="11pt" Font-Name="宋体" CellSpacing="0" CellPadding="3"
					GridLines="Both" BorderWidth="1" BorderColor="black" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" AllowPaging="True">
					<SelectedItemStyle Wrap="False" BorderStyle="Double" BorderColor="#8080FF" BackColor="#C0C0FF"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
					<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="选择"></asp:EditCommandColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:datagrid><asp:datagrid id="myDatagrid" style="Z-INDEX: 106; LEFT: 160px; POSITION: absolute; TOP: 168px"
					runat="server" Width="568px" PageSize="5" HorizontalAlign="Center" AlternatingItemStyle-BackColor="#eeeeee"
					HeaderStyle-BackColor="#aaaadd" Font-Size="11pt" Font-Name="宋体" CellSpacing="0" CellPadding="3" GridLines="Both"
					BorderWidth="1" BorderColor="black" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" AllowPaging="True">
					<SelectedItemStyle Wrap="False" BorderStyle="Double" BorderColor="#8080FF" BackColor="#C0C0FF"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
					<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
					<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:datagrid><asp:label id="lblRule" style="Z-INDEX: 102; LEFT: 168px; POSITION: absolute; TOP: 64px" runat="server"
					Width="656px" Height="72px">Label</asp:label><asp:label id="lable2" style="Z-INDEX: 103; LEFT: 160px; POSITION: absolute; TOP: 144px" runat="server"
					Width="320px">Label</asp:label><asp:label id="Label3" style="Z-INDEX: 104; LEFT: 256px; POSITION: absolute; TOP: 328px" runat="server"
					Width="328px" Height="26px">Label</asp:label><asp:button id="btnBack" style="Z-INDEX: 105; LEFT: 456px; POSITION: absolute; TOP: 536px" runat="server"
					Width="81" Height="24" Text="返回"></asp:button><asp:button id="btnYes" style="Z-INDEX: 108; LEFT: 368px; POSITION: absolute; TOP: 536px" runat="server"
					Width="81px" Height="24px" Text="进入考试"></asp:button></FONT></form>
	</body>
</HTML>
