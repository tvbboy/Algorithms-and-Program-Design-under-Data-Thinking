using Common.AITools.Tvbboy;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectCrawler
{
    /// <summary>
    ///  这是爬取华东师范大学贴吧的范例，把贴吧地址赋值给它，它会爬取相应网页的超级链接地址和标题
    /// </summary>
    public partial class ExampleCrawLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1.抓取超链接
            HrefCrawler();

        }
        /// <summary>
        /// 抓取超链接
        /// </summary>
        public void HrefCrawler()
        {
            var hrefList = new List<examplemyhref>();//定义泛型列表存放URL   
            string initurl = "http://tieba.baidu.com/f?kw=%E5%8D%8E%E4%B8%9C%E5%B8%88%E8%8C%83%E5%A4%A7%E5%AD%A6&ie=utf-8";
            string result = string.Empty;
            var hrefCrawler = new SimpleCrawler();//调用爬虫程序
            hrefCrawler.url = new Uri(initurl);//定义爬虫入口URL      
            Response.Write("爬虫开始抓取地址：" + hrefCrawler.url.ToString() + "</br>");
            hrefCrawler.OnError += (s, e) =>
            {
               Response.Write("爬虫抓取出现错误，异常消息：" + e.Exception.Message);
            };
            hrefCrawler.OnCompleted += (s, e) =>
            {
                //使用正则表达式清洗网页源代码中的数据
                var links = Regex.Matches(e.PageSource, @"<a[^>]+href=""*(?<href>[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>", RegexOptions.IgnoreCase);
                foreach (Match match in links)
                    {
                        var h = new examplemyhref
                        {
                            hreftitle = match.Groups["text"].Value,
                            hrefsrc = match.Groups["href"].Value
                        };
                        if (!hrefList.Contains(h))
                        {
                                hrefList.Add(h);//将数据加入到泛型列表
                        result += h.hreftitle + "|" + h.hrefsrc + "</br>";//将名称及URL显示到网页
                            
                        }
                    }
                    Response.Write("===============================================</br>");
                    Response.Write("爬虫抓取任务完成！合计 " + links.Count + " 个超级链接。</br>");
                    Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");
                    Response.Write("线程：" + e.ThreadId + "</br>");
                    Response.Write(result);
                    Response.Write("===============================================</br>");

                };
                hrefCrawler.start();
             }
    }
    public class examplemyhref
    {
      public string hreftitle { get; set; }
      public string hrefsrc { get; set; }
    }
}