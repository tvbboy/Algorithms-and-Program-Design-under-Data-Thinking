<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleChineseAnalyzer.aspx.cs" Inherits="ProjectWordSegmenter.ExampleChineseAnalyzer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInput" runat="server" Height="352px" TextMode="MultiLine" Width="1006px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnWordSeg" runat="server" Text="分词" />
        </div>
        <a href="http://ictclas.nlpir.org/nlpir/" target="_blank">北京理工大学大数据搜索与挖掘实验室</a>
    </form>
</body>
</html>
