<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleSegmentationThreeCountryCut.aspx.cs" Inherits="ProjectWordSegmenter.ExampleSegmentationThreeCountryCut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAll" runat="server" Text="全模式" OnClick="btnAll_Click" />
&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="搜索引擎模式" OnClick="btnSearch_Click" />
        &nbsp;
            <asp:Button ID="btn" runat="server" Text="精确模式" OnClick="btn_Click" />
        </div>
    </form>
</body>
</html>
