<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mgTeacher.aspx.vb" Inherits="WebExam.mgAdmin"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mgAdmin</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:datagrid id="myDataGrid" style="Z-INDEX: 110; LEFT: 56px; POSITION: absolute; TOP: 16px"
					runat="server" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"
					BorderColor="black" BorderWidth="1" GridLines="Both" CellPadding="3" CellSpacing="0" Font-Name="����"
					Font-Size="11pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee"
					Width="593px" HorizontalAlign="Justify" DataKeyField="userID">
					<SelectedItemStyle Wrap="False" BorderStyle="Double" BorderColor="#8080FF" BackColor="#C0C0FF"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
					<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="����" CancelText="ȡ��" EditText="�༭"></asp:EditCommandColumn>
						<asp:ButtonColumn Text="ɾ��" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<asp:Button id="btnAdd" style="Z-INDEX: 102; LEFT: 352px; POSITION: absolute; TOP: 440px" runat="server"
					Width="56px" Text="���"></asp:Button>
				<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 304px; POSITION: absolute; TOP: 360px" runat="server">�û�����</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 304px; POSITION: absolute; TOP: 392px" runat="server">�û�����</asp:Label>
				<asp:Label id="Label3" style="Z-INDEX: 105; LEFT: 352px; POSITION: absolute; TOP: 312px" runat="server">��ӽ�ʦ��Ϣ</asp:Label>
				<asp:TextBox id="txtUserID" style="Z-INDEX: 106; LEFT: 392px; POSITION: absolute; TOP: 360px"
					runat="server"></asp:TextBox>
				<asp:TextBox id="txtPwd" style="Z-INDEX: 107; LEFT: 392px; POSITION: absolute; TOP: 392px" runat="server"></asp:TextBox>
				<asp:Button id="btnCannel" style="Z-INDEX: 108; LEFT: 432px; POSITION: absolute; TOP: 440px"
					runat="server" Width="56px" Text="����"></asp:Button>
				<asp:Button id="btnBack" style="Z-INDEX: 109; LEFT: 512px; POSITION: absolute; TOP: 440px" runat="server"
					Width="64px" Text="����"></asp:Button></P>
		</form>
	</body>
</HTML>
