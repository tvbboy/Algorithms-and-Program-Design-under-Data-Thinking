<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HelloWorld.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请输入三条边长:<br/>
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox><br/>
        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox><br/>
        <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="计算三角形面积" OnClick="Button1_Click" /><br/>
    </div>
    </form>
</body>
</html>
