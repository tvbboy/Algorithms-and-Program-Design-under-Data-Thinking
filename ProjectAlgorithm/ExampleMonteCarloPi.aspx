<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleMonteCarloPi.aspx.cs" Inherits="ProjectAlgorithm.ExampleMonteCarloPi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入随机样本的数量<asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
             <br />
            <br />
            <asp:CheckBox ID="chkPrintPoint" runat="server" Text="显示随机样本" />
            <br />
            <br />
           
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="求PI" />
        </div>
    </form>
</body>
</html>
