<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkDijkstra.aspx.cs" Inherits="MyProject.HomeworkDijkstra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddlStart" runat="server" >
        </asp:DropDownList>
        <asp:DropDownList ID="ddlEnd" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Path" />
    
    </div>
    </form>
</body>
</html>
