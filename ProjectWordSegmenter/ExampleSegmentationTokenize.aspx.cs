using JiebaNet.Segmenter;
using System;

namespace ProjectWordSegmenter
{
    public partial class ExampleSegmentationTokenize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       /// <summary>
       /// 默认模式
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void btnDefault_Click(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            var s = txtInput.Text;
            var tokens = segmenter.Tokenize(s);
            foreach (var token in tokens)
            {
                Response.Write(string.Format("word {0,-12} start: {1,-3} end: {2,-3}<br>", token.Word, token.StartIndex, token.EndIndex));
            }

        }
        /// <summary>
        /// 搜索模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            var s = txtInput.Text;
            var tokens = segmenter.Tokenize(s, TokenizerMode.Search);
            foreach (var token in tokens)
            {
                Response.Write(string.Format("word {0,-12} start: {1,-3} end: {2,-3}<br>", token.Word, token.StartIndex, token.EndIndex));
            }

        }
    }
}