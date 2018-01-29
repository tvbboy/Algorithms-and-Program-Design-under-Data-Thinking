using Common.AITools.Tvbboy;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectCrawler
{
    /// <summary>
     /// 该程序是抓取网页图片的范例程序
    
     /// </summary>
    public partial class ExampleCrawlerImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1.抓取图片
            IMGCrawler();
            
        }
        /// <summary>
        /// 抓取超链接
        /// </summary>
        public void IMGCrawler()
        {
            List<string> imglist=new List<string>();
            string initurl = "http://tieba.baidu.com/f?kw=%E5%8D%8E%E4%B8%9C%E5%B8%88%E8%8C%83%E5%A4%A7%E5%AD%A6&ie=utf-8";
            string result = string.Empty;
            var imgCrawler = new SimpleCrawler();//调用爬虫程序
            imgCrawler.url = new Uri(initurl);//定义爬虫入口URL      
                Response.Write("爬虫开始抓取地址：" + imgCrawler.url.ToString()+"</br>");
            imgCrawler.OnError += (s, e) =>
                {
                    Response.Write("爬虫抓取出现错误，异常消息：" + e.Exception.Message);
                };
            imgCrawler.OnCompleted += (s, e) =>
                {
                    //使用正则表达式清洗网页源代码中的数据
                    string pattern= @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";
                    var imgs = Regex.Matches(e.PageSource, pattern, RegexOptions.IgnoreCase);
                    foreach (Match match in imgs)
                    {
                        if (!imglist.Contains(match.Groups["imgUrl"].Value))
                        {
                            imglist.Add(match.Groups["imgUrl"].Value);//将数据加入到泛型列表
                            result += match.Groups["imgUrl"].Value + "|<img width='50',height='50' src='"+ match.Groups["imgUrl"].Value + "'></br>";//将名称及URL显示到网页
                        }
                    }
                    Response.Write("===============================================</br>");
                    Response.Write("爬虫抓取任务完成！合计 " + imgs.Count + " 个图片。</br>");
                    Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");
                    Response.Write("线程：" + e.ThreadId+"</br>");
                    Response.Write(result);
                    Response.Write("===============================================</br>");

                };

            imgCrawler.start();
            
            
           


        }

    }
    
}