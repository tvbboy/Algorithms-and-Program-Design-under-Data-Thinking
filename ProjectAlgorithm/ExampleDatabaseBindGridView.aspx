<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleDatabaseBindGridView.aspx.cs" Inherits="FirstProject.ExampleDatabaseBindGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
