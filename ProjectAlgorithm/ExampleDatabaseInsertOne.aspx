<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleDatabaseInsertOne.aspx.cs" Inherits="ProjectAlgorithm.ExampleDatabaseInsertOne" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            学号：<asp:TextBox ID="txtStudentNo" runat="server"></asp:TextBox>
            <br />
            <br />
            姓名：<asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
            <br />
            <br />
            专业:<asp:DropDownList ID="ddlMajor" runat="server">
                <asp:ListItem>计算机</asp:ListItem>
                <asp:ListItem>数学</asp:ListItem>
                <asp:ListItem>其它</asp:ListItem>
            </asp:DropDownList>
            <br />
            性别：<asp:RadioButton ID="ridMale" runat="server" GroupName="Gender" Text="男" />
            <asp:RadioButton ID="ridFemale" runat="server" GroupName="Gender" Text="女" />
            <br />
            出生日期：<br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="btnInsert" runat="server" Text="插入" OnClick="btnInsert_Click" style="height: 21px" />
        </div>
    </form>
</body>
</html>
