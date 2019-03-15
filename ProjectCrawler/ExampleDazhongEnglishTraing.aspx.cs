using Common.AITools.Tvbboy;
using System;
using System.Text;

namespace ProjectCrawler
{
    public partial class ExampleDazhongEnglishTraing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string heads = @"Accept:text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
                            Accept-Encoding:gzip, deflate
                            Accept-Language:zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                            Cache-Control:max-age=0
                            Connection:keep-alive
                            Cookie:showNav=#nav-tab|0|0; navCtgScroll=0; cy=1; cye=shanghai; _lxsdk_cuid=1693813fdecc8-062bf66f365a768-11666e4a-384000-1693813fdecc8; _lxsdk_s=1693813fded-ea2-2e7-d89%7C%7C51; _lxsdk=1693813fdecc8-062bf66f365a768-11666e4a-384000-1693813fdecc8; _hc.v=7216e9e3-be12-eff4-1836-49d9b0c4b0ce.1551424029; s_ViewType=10
                            Host:www.dianping.com
                            Upgrade-Insecure-Requests:1                           
                            User-Agent:Mozilla/5.0 (Windows NT 10.0; WOW64; rv:65.0) Gecko/20100101 Firefox/65.0";
            string url = "http://www.dianping.com/search/keyword/1/0_%E8%8B%B1%E8%AF%AD%E5%9F%B9%E8%AE%AD/r842";
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
                sb.Append(string.Format("{0}---{1}---{2}</br>", aname.InnerText, anum.InnerText, aprice.InnerText));

            }
            Response.Write(sb);
        }
    }
}