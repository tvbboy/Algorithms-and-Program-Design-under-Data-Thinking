<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleSegmentationTokenize.aspx.cs" Inherits="ProjectWordSegmenter.ExampleSegmentationTokenize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        请输入字符串<asp:TextBox ID="txtInput" runat="server" Width="320px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnDefault" runat="server" Text="默认模式" OnClick="btnDefault_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="搜索模式" OnClick="btnSearch_Click" />
    </form>
</body>
</html>
