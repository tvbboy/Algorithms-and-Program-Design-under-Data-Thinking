using Lucene.Net.Analysis;
using System;
using System.IO;
using System.Text;

namespace ProjectWordSegmenter
{
    /// <summary>
    /// 首先需要引用 2个dll库文件 Lucene.Net.dll + Lucene.China.dll
    ///还有一个data文件夹需要放在C:\Program Files(x86)\Common Files\microsoft shared\DevServer\10.0目录下
    ///里面有三个文件（1）.sDict.txt（2）.sDict.txt.bak（3）.sNoise.txt
    ///
    ///分词解释参考 http://blog.csdn.net/mingzai624/article/details/51698643
    /// </summary>
    public partial class ExampleChineseAnalyzer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
            string t1 = "";
            int i = 0;
            Analyzer analyzer = new Lucene.China.ChineseAnalyzer();
            StringReader sr = new StringReader(txtInput.Text);
            TokenStream stream = analyzer.TokenStream(null, sr);

            long begin = System.DateTime.Now.Ticks;
            Token t = stream.Next();
            while (t != null)
            {
                t1 = t.ToString();   //显示格式： (关键词,0,2) ，需要处理
                t1 = t1.Replace("(", "");
                char[] separator = { ',' };
                t1 = t1.Split(separator)[0];

                sb.Append(i + ":" + t1 + "\r\n");
                t = stream.Next();
                i++;
            }
            Response.Write(sb.ToString());
            long end = System.DateTime.Now.Ticks; //100毫微秒
            int time = (int)((end - begin) / 10000); //ms
            Response.Write("耗时" + (time) + "ms \r\n=====\r\n");
            
        }
    }
}