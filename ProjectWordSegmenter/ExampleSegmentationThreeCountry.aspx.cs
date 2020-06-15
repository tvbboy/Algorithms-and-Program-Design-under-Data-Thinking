using JiebaNet.Segmenter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProjectWordSegmenter
{
    public partial class ExampleSegmentationThreeCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();

            segmenter.DeleteWord("将军");
            segmenter.DeleteWord("却说");
            segmenter.DeleteWord("二人");
            segmenter.DeleteWord("玄德曰");
            segmenter.DeleteWord("孔明曰");
            segmenter.DeleteWord("司马");
            segmenter.DeleteWord("不可");
            segmenter.DeleteWord("不能");
            segmenter.DeleteWord("夏侯");
            segmenter.DeleteWord("如此");
            segmenter.DeleteWord("诸葛");
            segmenter.DeleteWord("商议");
            segmenter.DeleteWord("如何");
            segmenter.DeleteWord("大喜");
            segmenter.DeleteWord("军士");
            segmenter.DeleteWord("左右");
            segmenter.DeleteWord("引兵");
            segmenter.DeleteWord("夫人");

            string aimFile = @"./Resources/三国演义.txt";
            string content = ReadData(aimFile);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //搜索引擎模式分词
            //var wordsforSearch = segmenter.CutForSearch(content);
            //精确模式
            var wordsforSearch = segmenter.Cut(content);
            List<KV> list = new List<KV>();
            //定义数据结构persons ，放置人名和词频
            Dictionary<string, int> persons = new Dictionary<string, int>();
           
            foreach (string item in wordsforSearch.Distinct<string>())
            {
                //对长度大于等于2并且小于等于4的词进行统计
                if (item.Length >= 2 && item.Length <= 4)
                {
                    if (!persons.ContainsKey(item))
                    {
                        int f = GetFrequence(wordsforSearch, item);//统计词频
                        persons.Add(item.Trim(), f);
                        if (f >= 100 && f != 2406)//出于测试需要只对频率100以上的关键词，制作词云
                        {
                            KV kv = new KV(item.Trim(),f);
                            list.Add(kv);
                        }
                    }
                }

            }               
            string output = JsonConvert.SerializeObject(list);
            //将要以JSON格式输出的字符串，将其写到JSON文件中，就可以实现，词云图
            WriteData("test.json", output);
            persons = (from entry in persons
                       orderby entry.Value descending
                       select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            string result = "";
            foreach (var person in persons)
            {
                if(person.Value>=100)
                result += ("<br>" + person.Key + "-" + person.Value.ToString());
            }
            Response.Write(result);
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Response.Write("</br>Stopwatch总共花费{0}ms." + ts2.TotalMilliseconds.ToString());
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
        /// <summary>
        /// 统计某个特殊单词，再文章中出现的次数
        /// </summary>
        /// <param name="content"></param>
        /// <param name="specficword"></param>
        /// <returns></returns>
        public int GetFrequence(IEnumerable<string> content, string specficword)
        {
            int ret = 0;
            foreach (string item in content)
            {
                if (item == specficword)
                    ret++;
            }
            return ret;
        }
        /// <summary>
        /// C#数组去掉重复的元素
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        string[] DelRepeatData(string[] a)
        {
            return a.GroupBy(p => p).Select(p => p.Key).ToArray();
        }
        /// <summary>
        /// 将某个内容写入到JSON文件中
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileContent"></param>
        public void WriteData(string filePath, string fileContent)
        {
            string aimfilepath = MapPath(filePath);//将虚拟路径转为实际路径
            if (File.Exists(aimfilepath))//如果原文件存在，先删除以免数据堆叠导致JSON语法错误
                File.Delete(aimfilepath);
            using (FileStream fs = new FileStream(aimfilepath, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(fileContent);
                sw.Close();
            }
        }

    }
    public class KV
    {
        public KV(string s, double d)
        {
            name = s;
            value = d;
        }
       public string name { get; set; }
       public  double value { get; set; }
    }
}