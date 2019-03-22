<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleDatabaseReadOne.aspx.cs" Inherits="ProjectAlgorithm.ExampleDatabaseReadOne" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入一个唐朝人物 
         
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />
        </div>
    </form>
</body>
</html>
