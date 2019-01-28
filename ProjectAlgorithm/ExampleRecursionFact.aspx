<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleRecursionFact.aspx.cs" Inherits="ProjectAlgorithm.ExampleRecursionFact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnFact" runat="server" OnClick="btnFact_Click" Text="计算阶乘" />
        </div>
    </form>
</body>
</html>
