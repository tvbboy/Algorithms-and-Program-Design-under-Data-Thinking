<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleMonteCarloIntegration.aspx.cs" Inherits="ProjectAlgorithm.ExampleMonteCarloIntegration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>测试样本的数量
            <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="求y=x^2在[0-1]之间积分" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
