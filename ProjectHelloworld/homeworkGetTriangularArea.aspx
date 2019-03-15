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
            请输入三角形的三条边：<br />
            a<asp:TextBox ID="txtA" runat="server"></asp:TextBox>
            <br />
            b<asp:TextBox ID="txtB" runat="server"></asp:TextBox>
            <br />
            c<asp:TextBox ID="txtC" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGetS" runat="server" OnClick="btnGetS_Click" Text="求三角形面积" />
        </div>
    </form>
</body>
</html>
