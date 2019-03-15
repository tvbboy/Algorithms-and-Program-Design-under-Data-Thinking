using Common.AITools.Tvbboy;
using System;
using System.Text;

namespace ProjectCrawler
{
    //https://jingyan.baidu.com/article/7e44095334bb162fc0e2efad.html

    //https://www.cnblogs.com/soundcode/p/3785152.html
    public partial class ExampleDazhong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string heads = @"Accept:text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8
Accept-Encoding:gzip, deflate
Accept-Language:zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
Cache-Control:max-age=0
Connection:keep-alive
Cookie:cy=1; _lxsdk_cuid=15ffc822338c…3fb990e3e-b37-f9f-cd5%7C%7C20
Host:www.dianping.com
Upgrade-Insecure-Requests:1
Accept:text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8
Accept-Encoding:gzip, deflate
Accept-Language:zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
Cache-Control:max-age=0
Connection:keep-alive
Cookie:cy=1; _lxsdk_cuid=15ffc822338c…3fb990e3e-b37-f9f-cd5%7C%7C20
Host:www.dianping.com
Upgrade-Insecure-Requests:1
User-Agent:Mozilla/5.0 (Windows NT 10.0; …) Gecko/20100101 Firefox/60.0";

            string url = "http://www.dianping.com/shanghai/ch75/g3032";
            ClassHttpRequestClient s = new ClassHttpRequestClient(true);
            string content = "";
            string response = s.httpPost(url, heads, content, Encoding.UTF8);
           // Response.Write(response);
            // 第一步声明HtmlAgilityPack.HtmlDocument实例
           HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();           
            //第二步加载html文档
            doc.LoadHtml(response);
            HtmlAgilityPack.HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class=\"txt\"]");
            StringBuilder sb = new StringBuilder();
            foreach (HtmlAgilityPack.HtmlNode item in collection)
            {
                HtmlAgilityPack.HtmlNode divtit = item.SelectNodes("div[@class=\"tit\"]")[0];
                HtmlAgilityPack.HtmlNode aname = divtit.SelectNodes("a[1]")[0]; //divtit下面的第一个超级链接

                HtmlAgilityPack.HtmlNode divcomment = item.SelectNodes("div[@class=\"comment\"]")[0];
                    HtmlAgilityPack.HtmlNode anum = divcomment.SelectNodes("a[1]")[0]; //divcomment下面的第一个超级链接
                    HtmlAgilityPack.HtmlNode aprice = divcomment.SelectNodes("a[2]")[0];//divcomment下面的第二个超级链接
                sb.Append(string.Format("{0}---{1}---{2}</br>", aname.InnerText, anum.InnerText,aprice.InnerText));
                
            }
            Response.Write(sb);

        }
      
    }
}