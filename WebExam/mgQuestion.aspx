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
				BorderColor="black" BorderWidth="1" GridLines="Both" CellPadding="3" CellSpacing="0" Font-Name="����"
				Font-Size="11pt" HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee"
				Width="850px" HorizontalAlign="Center" PageSize="5">
				<SelectedItemStyle Wrap="False" BorderStyle="Double" BorderColor="#8080FF" BackColor="#C0C0FF"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#EEEEEE"></AlternatingItemStyle>
				<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="�༭"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="ɾ��" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:button id="btnCancel" style="Z-INDEX: 124; LEFT: 432px; POSITION: absolute; TOP: 736px"
				runat="server" Width="56px" Text="����"></asp:button><asp:label id="Label1" style="Z-INDEX: 101; LEFT: 160px; POSITION: absolute; TOP: 480px" runat="server"><font color="red">
					*</font>���⣺</asp:label><asp:label id="Label2" style="Z-INDEX: 102; LEFT: 160px; POSITION: absolute; TOP: 448px" runat="server">��Ŀ��</asp:label><asp:label id="lblHint" style="Z-INDEX: 103; LEFT: 440px; POSITION: absolute; TOP: 376px" runat="server">
				<font size="3">�� �� �� ��</font></asp:label><asp:label id="lblWarning" style="Z-INDEX: 104; LEFT: 408px; POSITION: absolute; TOP: 408px"
				runat="server">
				<font color="red" size="+0">��*�����������ȫ��д</font></asp:label><asp:label id="Label5" style="Z-INDEX: 105; LEFT: 160px; POSITION: absolute; TOP: 512px" runat="server">ѡ��A��</asp:label><asp:label id="Label6" style="Z-INDEX: 106; LEFT: 160px; POSITION: absolute; TOP: 544px" runat="server">ѡ��B��</asp:label><asp:label id="Label7" style="Z-INDEX: 107; LEFT: 160px; POSITION: absolute; TOP: 688px" runat="server"><font color="red">
					*</font>���ͣ���ѡ�⣬��ѡ�⻹���ж��⣩��</asp:label><asp:label id="Label8" style="Z-INDEX: 108; LEFT: 160px; POSITION: absolute; TOP: 584px" runat="server">ѡ��C��</asp:label><asp:label id="Label9" style="Z-INDEX: 109; LEFT: 160px; POSITION: absolute; TOP: 616px" runat="server">ѡ��D��</asp:label><asp:label id="Label10" style="Z-INDEX: 110; LEFT: 160px; POSITION: absolute; TOP: 648px" runat="server">
<font color="red">*</font>�𰸣�����дѡ�����ĸ����</asp:label><asp:button id="btnBack" style="Z-INDEX: 111; LEFT: 520px; POSITION: absolute; TOP: 736px" runat="server"
				Width="56px" Text="����"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 113; LEFT: 344px; POSITION: absolute; TOP: 736px" runat="server"
				Width="56px" Text="���"></asp:button><asp:textbox id="txtQustion" style="Z-INDEX: 114; LEFT: 232px; POSITION: absolute; TOP: 480px"
				runat="server" Width="584px"></asp:textbox><asp:textbox id="txtSubName" style="Z-INDEX: 115; LEFT: 232px; POSITION: absolute; TOP: 448px"
				runat="server" Width="280px"></asp:textbox><asp:textbox id="txtA" style="Z-INDEX: 116; LEFT: 232px; POSITION: absolute; TOP: 512px" runat="server"
				Width="585" Height="24"></asp:textbox><asp:textbox id="txtC" style="Z-INDEX: 117; LEFT: 232px; POSITION: absolute; TOP: 576px" runat="server"
				Width="585px" Height="24px"></asp:textbox><asp:textbox id="txtD" style="Z-INDEX: 118; LEFT: 232px; POSITION: absolute; TOP: 608px" runat="server"
				Width="585px" Height="24px"></asp:textbox><asp:textbox id="txtAnswer" style="Z-INDEX: 119; LEFT: 472px; POSITION: absolute; TOP: 648px"
				runat="server"></asp:textbox><asp:textbox id="txtB" style="Z-INDEX: 120; LEFT: 232px; POSITION: absolute; TOP: 544px" runat="server"
				Width="585px" Height="24px"></asp:textbox><asp:radiobutton id="rbtnSingle" style="Z-INDEX: 121; LEFT: 464px; POSITION: absolute; TOP: 688px"
				runat="server" Text="��ѡ��" GroupName="rbtnType"></asp:radiobutton><asp:radiobutton id="rbtnMulti" style="Z-INDEX: 122; LEFT: 560px; POSITION: absolute; TOP: 688px"
				runat="server" Text="��ѡ��" GroupName="rbtnType"></asp:radiobutton><asp:radiobutton id="rbtnJudge" style="Z-INDEX: 123; LEFT: 656px; POSITION: absolute; TOP: 688px"
				runat="server" Text="�ж���" GroupName="rbtnType"></asp:radiobutton></form>
	</body>
</HTML>
