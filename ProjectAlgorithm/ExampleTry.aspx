<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleTry.aspx.cs" Inherits="ProjectAlgorithm.ExampleTry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="判断负数" />
        </div>
    </form>
</body>
</html>
