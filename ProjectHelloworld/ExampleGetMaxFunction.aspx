<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleGetMaxFunction.aspx.cs" Inherits="ProjectHelloworld.ExampleGetMaxFunction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtNum1" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtNum3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGetMax" runat="server"  Text="求最大值" OnClick="btnGetMax_Click" />
        </div>
    </form>
</body>
</html>
