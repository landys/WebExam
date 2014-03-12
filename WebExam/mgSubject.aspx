<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mgSubject.aspx.vb" Inherits="WebExam.mgSubject"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mgSubject</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="image\bg2.jpg">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="myDataGrid" style="Z-INDEX: 100; LEFT: 224px; POSITION: absolute; TOP: 24px"
				runat="server" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"
				BorderColor="black" BorderWidth="1" GridLines="Both" CellPadding="3" CellSpacing="0" Font-Name="宋体"
				Font-Size="11pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee"
				Width="593px" HorizontalAlign="Center" PageSize="5">
				<SelectedItemStyle Wrap="False" BorderStyle="Double" BorderColor="#8080FF" BackColor="#C0C0FF"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
				<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="编辑"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<asp:Button id="btnEdit" style="Z-INDEX: 122; LEFT: 456px; POSITION: absolute; TOP: 464px" runat="server"
				Width="65px" Text="编辑题目" Height="24px"></asp:Button>
			<asp:TextBox id="txtSingleNum" style="Z-INDEX: 121; LEFT: 352px; POSITION: absolute; TOP: 384px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtJudgeper" style="Z-INDEX: 120; LEFT: 632px; POSITION: absolute; TOP: 416px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtJudgeNum" style="Z-INDEX: 119; LEFT: 632px; POSITION: absolute; TOP: 384px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtMultiper" style="Z-INDEX: 118; LEFT: 632px; POSITION: absolute; TOP: 352px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtMultiNum" style="Z-INDEX: 117; LEFT: 632px; POSITION: absolute; TOP: 320px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtSingleper" style="Z-INDEX: 116; LEFT: 352px; POSITION: absolute; TOP: 416px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label8" style="Z-INDEX: 115; LEFT: 536px; POSITION: absolute; TOP: 384px" runat="server"
				Width="82px" Height="18px">是非题量</asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 114; LEFT: 536px; POSITION: absolute; TOP: 416px" runat="server"
				Width="82px" Height="18px">是非分值</asp:Label>
			<asp:Label id="Label6" style="Z-INDEX: 113; LEFT: 536px; POSITION: absolute; TOP: 352px" runat="server"
				Width="82px" Height="18px">多选分值</asp:Label>
			<asp:Button id="btnAdd" style="Z-INDEX: 108; LEFT: 376px; POSITION: absolute; TOP: 464px" runat="server"
				Width="65px" Text="添加" Height="24px"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 256px; POSITION: absolute; TOP: 320px" runat="server"
				Width="82px" Height="18">科目名称</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 256px; POSITION: absolute; TOP: 352px" runat="server"
				Width="82px" Height="18">考试时间</asp:Label>
			<asp:Label id="lblWarning" style="Z-INDEX: 103; LEFT: 472px; POSITION: absolute; TOP: 288px"
				runat="server">添加课程信息</asp:Label>
			<asp:TextBox id="txtSubName" style="Z-INDEX: 104; LEFT: 352px; POSITION: absolute; TOP: 320px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtTestTime" style="Z-INDEX: 105; LEFT: 352px; POSITION: absolute; TOP: 352px"
				runat="server"></asp:TextBox>
			<asp:Button id="btnCannel" style="Z-INDEX: 106; LEFT: 544px; POSITION: absolute; TOP: 464px"
				runat="server" Width="65px" Text="重置" Height="24px"></asp:Button>
			<asp:Button id="btnBack" style="Z-INDEX: 107; LEFT: 624px; POSITION: absolute; TOP: 464px" runat="server"
				Width="65" Text="返回" Height="24"></asp:Button>
			<asp:Label id="Label3" style="Z-INDEX: 110; LEFT: 256px; POSITION: absolute; TOP: 384px" runat="server"
				Width="82px" Height="18px">单选题量</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 111; LEFT: 256px; POSITION: absolute; TOP: 416px" runat="server"
				Width="82px" Height="18px">单选分值</asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 112; LEFT: 536px; POSITION: absolute; TOP: 320px" runat="server"
				Width="82px" Height="18px">多选题量</asp:Label></form>
	</body>
</HTML>
