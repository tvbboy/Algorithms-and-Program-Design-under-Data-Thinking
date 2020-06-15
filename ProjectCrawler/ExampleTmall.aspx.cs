using Common.AITools.Tvbboy;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCrawler
{
    public partial class ExampleTmall : System.Web.UI.Page
    {// private string initurl = "https://search.jd.com/Search?keyword=thinkpad&enc=utf-8&wq=thinkpad&pvid=c438dcf5021241e19cdc869a488f1290";
        private string initurl = "https://list.tmall.com/search_product.htm?q=thinkpad&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
        private string result = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HrefCrawler();
            // AdvCrawler();
            ScrapingCrawler();
        }
        /// <summary>
        /// 抓取超链接
        /// </summary>
        public void HrefCrawler()
        {

            var hrefCrawler = new SimpleCrawler();//调用爬虫程序
            hrefCrawler.url = new Uri(initurl);//定义爬虫入口URL      
            Response.Write("爬虫开始抓取地址：" + hrefCrawler.url.ToString() + "</br>");
            hrefCrawler.OnError += (s, e) =>
            {
                Response.Write("爬虫抓取出现错误，异常消息：" + e.Exception.Message);
            };
            hrefCrawler.OnCompleted += (s, e) =>
            {
                result = e.PageSource;
                Response.Write("===============================================</br>");
                Response.Write("爬虫抓取任务完成！</br>");
                Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");
                Response.Write("线程：" + e.ThreadId + "</br>");
                Response.Write(result);
                Response.Write("===============================================</br>");
                if (result != "")
                    doHtml();
                else
                    Response.Write("爬取失败！");
            };
            hrefCrawler.start();
        }
        private void doHtml()
        {
            // 第一步声明HtmlAgilityPack.HtmlDocument实例
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //第二步加载html文档
            doc.LoadHtml(result);

            string xpathDiv = "//*[@id=\"J_ItemList\"]";//找到class=zg_itemImmersion的div节点
            HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode(xpathDiv);
            HtmlAgilityPack.HtmlNodeCollection collection = node.ChildNodes;
            StringBuilder sb = new StringBuilder();
            foreach (HtmlAgilityPack.HtmlNode item in collection)
            {
                string price_path = "div[2]/strong/i";

                HtmlAgilityPack.HtmlNode divtit1 = item.SelectSingleNode(price_path);
                string name_path = "div[3]/a/em";
                HtmlAgilityPack.HtmlNode divtit2 = item.SelectSingleNode(name_path);

                sb.Append(string.Format("{0}---{1}</br>", divtit1.InnerText, divtit2.InnerText));

            }
            Response.Write(sb);

        }
        /// <summary>
        /// 高级爬取
        /// </summary>
        public void AdvCrawler()
        {



            string heads = @"at_bucketid: sbucket_7
at_cat: 2
at_mall_pro_re: 1635
at_rn: 0397de31c2ae1cbafdf3f6ded7be1fe0
at_type: search
at_vmarket: 0
content-encoding: gzip
content-language: zh-CN
content-type: text/html;charset=GBK
date: Wed, 10 Jun 2020 01:28:36 GMT
eagleeye-traceid: 0b5218bb15917525159411294e7f2d
s_group: tao-session
s_ip: 4547514b653151352b3059752f6a633155746b3d
s_read_unit: [CN:CENTER]
s_status: STATUS_NOT_EXISTED
s_tag: 283674001342464|4294967296^1|^^
s_tid: 0b5218bb15917525159411294e7f2d
s_ucode: CN:CENTER
s_v: 4.0.2.6
server: Tengine/Aserver
status: 200
strict-transport-security: max-age=31536000
timing-allow-origin: *
ufe-result: A6
vary: Accept-Encoding";


            ClassHttpRequestClient s = new ClassHttpRequestClient(true);
            string content = "";
            string response = s.httpPost(initurl, heads, content, Encoding.UTF8);
            Response.Write(response);

        }

        public void ScrapingCrawler()
        {
            Uri uri = new Uri(initurl);
            var browser1 = new ScrapingBrowser();
           result = browser1.DownloadString(uri);
            doHtml();
        }
    }
}