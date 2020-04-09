<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkGetTriangularArea.aspx.cs" Inherits="ProjectHelloworld.homeworkGetTriangularArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <p>请输入第一条边长：</p><asp:TextBox id='TextBox1' OnTextChanged="TextBox1_TextChanged" runat="server" />
        <br />
        <p>请输入第二条边长：</p><asp:TextBox id='TextBox2' OnTextChanged="TextBox1_TextChanged" runat="server" />
        <br />
        <p>请输入第三条边长：</p><asp:TextBox id='TextBox3' OnTextChanged="TextBox1_TextChanged" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button1" Text="求三角形面积" OnClick="Button1_Click" runat="server" />
        </div>
    </form>
</body>
</html>
