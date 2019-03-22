<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamplePrime.aspx.cs" Inherits="ProjectHelloworld.ExamplePrime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlStart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStart_SelectedIndexChanged">
            </asp:DropDownList>
&nbsp;--------&nbsp;&nbsp;
            <asp:DropDownList ID="ddlEnd" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnPrime" runat="server" OnClick="btnPrime_Click" Text="求素数" />
        </div>
    </form>
</body>
</html>
