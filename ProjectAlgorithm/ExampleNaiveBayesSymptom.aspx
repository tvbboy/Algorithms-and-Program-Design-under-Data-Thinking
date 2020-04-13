<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleNaiveBayesSymptom.aspx.cs" Inherits="ProjectAlgorithm.ExampleNaiveBayesSymptom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddlSymptom" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlJob" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnOut" runat="server" OnClick="btnOut_Click" Text="预测疾病" />
    
    </div>
    </form>
</body>
</html>
