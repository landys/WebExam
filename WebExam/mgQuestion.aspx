<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mgQuestion.aspx.vb" Inherits="WebExam.mgQuestion"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mgQuestion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="image\bg2.jpg">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="myDataGrid" style="Z-INDEX: 100; LEFT: 48px; POSITION: absolute; TOP: 16px"
				runat="server" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"
				BorderColor="black" BorderWidth="1" GridLines="Both" CellPadding="3" CellSpacing="0" Font-Name="宋体"
				Font-Size="11pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee"
				Width="850px" HorizontalAlign="Center" PageSize="5">
				<SelectedItemStyle Wrap="False" BorderStyle="Double" BorderColor="#8080FF" BackColor="#C0C0FF"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
				<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="编辑"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:button id="btnCancel" style="Z-INDEX: 124; LEFT: 432px; POSITION: absolute; TOP: 736px"
				runat="server" Width="56px" Text="重置"></asp:button><asp:label id="Label1" style="Z-INDEX: 101; LEFT: 160px; POSITION: absolute; TOP: 480px" runat="server"><font color="red">
					*</font>问题：</asp:label><asp:label id="Label2" style="Z-INDEX: 102; LEFT: 160px; POSITION: absolute; TOP: 448px" runat="server">科目：</asp:label><asp:label id="lblHint" style="Z-INDEX: 103; LEFT: 440px; POSITION: absolute; TOP: 376px" runat="server">
				<font size="3">添 加 试 题</font></asp:label><asp:label id="lblWarning" style="Z-INDEX: 104; LEFT: 408px; POSITION: absolute; TOP: 408px"
				runat="server">
				<font color="red" size="+0">带*各项均必须完全填写</font></asp:label><asp:label id="Label5" style="Z-INDEX: 105; LEFT: 160px; POSITION: absolute; TOP: 512px" runat="server">选项A：</asp:label><asp:label id="Label6" style="Z-INDEX: 106; LEFT: 160px; POSITION: absolute; TOP: 544px" runat="server">选项B：</asp:label><asp:label id="Label7" style="Z-INDEX: 107; LEFT: 160px; POSITION: absolute; TOP: 688px" runat="server"><font color="red">
					*</font>类型（单选题，多选题还是判断题）：</asp:label><asp:label id="Label8" style="Z-INDEX: 108; LEFT: 160px; POSITION: absolute; TOP: 584px" runat="server">选项C：</asp:label><asp:label id="Label9" style="Z-INDEX: 109; LEFT: 160px; POSITION: absolute; TOP: 616px" runat="server">选项D：</asp:label><asp:label id="Label10" style="Z-INDEX: 110; LEFT: 160px; POSITION: absolute; TOP: 648px" runat="server">
<font color="red">*</font>答案（请填写选项的字母）：</asp:label><asp:button id="btnBack" style="Z-INDEX: 111; LEFT: 520px; POSITION: absolute; TOP: 736px" runat="server"
				Width="56px" Text="返回"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 113; LEFT: 344px; POSITION: absolute; TOP: 736px" runat="server"
				Width="56px" Text="添加"></asp:button><asp:textbox id="txtQustion" style="Z-INDEX: 114; LEFT: 232px; POSITION: absolute; TOP: 480px"
				runat="server" Width="584px"></asp:textbox><asp:textbox id="txtSubName" style="Z-INDEX: 115; LEFT: 232px; POSITION: absolute; TOP: 448px"
				runat="server" Width="280px"></asp:textbox><asp:textbox id="txtA" style="Z-INDEX: 116; LEFT: 232px; POSITION: absolute; TOP: 512px" runat="server"
				Width="585" Height="24"></asp:textbox><asp:textbox id="txtC" style="Z-INDEX: 117; LEFT: 232px; POSITION: absolute; TOP: 576px" runat="server"
				Width="585px" Height="24px"></asp:textbox><asp:textbox id="txtD" style="Z-INDEX: 118; LEFT: 232px; POSITION: absolute; TOP: 608px" runat="server"
				Width="585px" Height="24px"></asp:textbox><asp:textbox id="txtAnswer" style="Z-INDEX: 119; LEFT: 472px; POSITION: absolute; TOP: 648px"
				runat="server"></asp:textbox><asp:textbox id="txtB" style="Z-INDEX: 120; LEFT: 232px; POSITION: absolute; TOP: 544px" runat="server"
				Width="585px" Height="24px"></asp:textbox><asp:radiobutton id="rbtnSingle" style="Z-INDEX: 121; LEFT: 464px; POSITION: absolute; TOP: 688px"
				runat="server" Text="单选题" GroupName="rbtnType"></asp:radiobutton><asp:radiobutton id="rbtnMulti" style="Z-INDEX: 122; LEFT: 560px; POSITION: absolute; TOP: 688px"
				runat="server" Text="多选题" GroupName="rbtnType"></asp:radiobutton><asp:radiobutton id="rbtnJudge" style="Z-INDEX: 123; LEFT: 656px; POSITION: absolute; TOP: 688px"
				runat="server" Text="判断题" GroupName="rbtnType"></asp:radiobutton></form>
	</body>
</HTML>
