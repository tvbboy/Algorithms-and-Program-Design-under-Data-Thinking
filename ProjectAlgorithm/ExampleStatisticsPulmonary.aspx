<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleStatisticsPulmonary.aspx.cs" Inherits="ProjectAlgorithm.ExampleStatisticsPulmonary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入平均值<asp:TextBox ID="txtMean" runat="server"></asp:TextBox>
            <br />
            请输输入方差差<asp:TextBox ID="txtS" runat="server"></asp:TextBox>
            <br />
            请输入概率区间<br />
            <br />
            <asp:TextBox ID="txtX1" runat="server"></asp:TextBox>
            ~<asp:TextBox ID="txtX2" runat="server"></asp:TextBox>
&nbsp;A代表无穷，比如大于2000的概率可输入 2000~A，小于2000的概率可输入A~3000<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="计算概率" />
        </div>
    </form>
</body>
</html>
