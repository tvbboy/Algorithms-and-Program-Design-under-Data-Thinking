using JiebaNet.Segmenter;
using System;
using System.IO;

namespace ProjectWordSegmenter
{
    public partial class ExampleSegmentationThreeCountryCut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            string aimFile = @"./Resources/三国演义.txt";
            string content = ReadData(aimFile);
            var wordsforSearch = segmenter.Cut(content, cutAll: true);
            Response.Write("</br>【全模式】：{0}" + string.Join("/ ", wordsforSearch));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            string aimFile = @"./Resources/三国演义.txt";
            string content = ReadData(aimFile);
            var wordsforSearch = segmenter.CutForSearch(content);
            Response.Write("</br>【搜索引擎模式】：{0}" + string.Join("/ ", wordsforSearch));

        }

        /// <summary>
        /// 将路径filepath所代表的文件读取到某个字符串中
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public string ReadData(string filepath)
        {
            //C#读取TXT文件之建立  FileStream 的对象,说白了告诉程序,     
            //文件在那里,对文件如何 处理,对文件内容采取的处理方式     
            System.Text.Encoding code = System.Text.Encoding.GetEncoding("gb2312");
            FileStream fs = new FileStream(Server.MapPath(filepath), FileMode.Open, FileAccess.Read);
            //仅 对文本 执行  读写操作     
            StreamReader sr = new StreamReader(fs, code);
            //定位操作点,begin 是一个参考点     
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            //读一下，看看文件内有没有内容，为下一步循环 提供判断依据     
            //sr.ReadLine() 这里是 StreamReader的要领  可不是 console 中的~      
            string str = sr.ReadToEnd();//假如  文件有内容     
            //C#读取TXT文件之关上文件，留心顺序，先对文件内部执行 关上，然后才是文件~     
            sr.Close();
            fs.Close();
            return str;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            string aimFile = @"./Resources/三国演义.txt";
            string content = ReadData(aimFile);
            var wordsforSearch = segmenter.Cut(content);
            Response.Write("</br>【搜索引擎模式】：{0}" + string.Join("/ ", wordsforSearch));
        }
    }
}