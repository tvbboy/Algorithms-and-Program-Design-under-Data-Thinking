<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleSegmentation.aspx.cs" Inherits="ProjectWordSegmenter.ExampleSegmentation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            请输入待匹配的字符串：<asp:TextBox ID="txtInput" runat="server" Width="944px"></asp:TextBox>
            <br />
            <br />
            最大匹配长度：<asp:TextBox ID="txtMaxLength" runat="server" Width="80px"></asp:TextBox>
            <br />
            <br />
            词典：研究、研究生、生命、命、的、起源<br />
            <br />
            <asp:Button ID="btnButtonLeftToRight" runat="server" OnClick="btnButtonLeftToRight_Click" Text="正向匹配" />
&nbsp;<asp:Button ID="btnButtonRightToLeft" runat="server" OnClick="btnButtonRightToLeft_Click" Text="逆向匹配" />
        &nbsp; <asp:Button ID="btnButtonDouble" runat="server"  Text="双向匹配" OnClick="btnButtonDouble_Click" />
        </div>
    </form>
</body>
</html>
