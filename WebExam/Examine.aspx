<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Examine.aspx.vb" Inherits="WebExam.Examine"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Examine</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form name="bb">
			<SCRIPT language="JavaScript">
				<!--
					var second=0;
					var minute=0;
					var hour=0;
					window.setInterval("timestay();",1000);
					function timestay()
					{ 
						second++;
						if(second == 60)
						{
							second = 0;
							minute += 1;
						}
						if(minute == 60)
						{
							minute = 0;
							hour += 1;
							if (hour == 1)
							{
								window.location.reload();
							}
						}
						window.status="您已经考了"+hour+"小时"+minute+"分"+second+"秒";
						document.bb.aa.value=hour+"小时"+minute+"分"+second+"秒";
					}
				//-->
			</SCRIPT>
			&nbsp;&nbsp;<input style="Z-INDEX: 103; LEFT: 520px; WIDTH: 96px; POSITION: absolute; TOP: 37px; HEIGHT: 24px"
				readOnly type="text" size="10" name="aa" id="ccdd">
		</form>
		<form name="bbbb" id="Form1" method="post" runat="server">
			<asp:label id="Label2" style="Z-INDEX: 101; LEFT: 168px; POSITION: absolute; TOP: 40px" runat="server">考试时间为</asp:label><asp:label id="Label1" style="Z-INDEX: 102; LEFT: 408px; POSITION: absolute; TOP: 40px" runat="server"
				Width="96px">您已经考了</asp:label>
			<asp:Label id="lblTestTime" style="Z-INDEX: 105; LEFT: 288px; POSITION: absolute; TOP: 40px"
				runat="server" Width="96px" Height="24px">Label</asp:Label><br>
			<br>
			<asp:panel id="myPanel" runat="server" Wrap="True">
				<FONT face="宋体"></FONT>
			</asp:panel><FONT face="宋体">
				<asp:Button id="Button1" style="Z-INDEX: 104; LEFT: 664px; POSITION: absolute; TOP: 37px" runat="server"
					Text="提交" Width="72px"></asp:Button></FONT></form>
	</body>
</HTML>
