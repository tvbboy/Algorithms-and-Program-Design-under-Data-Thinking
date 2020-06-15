using JiebaNet.Segmenter.PosSeg;
using System;
using System.Linq;

namespace ProjectWordSegmenter
{
    //具体词性的显示可以参考：https://blog.csdn.net/smilejiasmile/article/details/80958010
    public partial class ExampleSegmentationPosSeg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var posSeg = new PosSegmenter();
            var s = "就算你留恋开放在水中娇艳的水仙,别忘了寂寞的山谷里角落里野百合也有春天";
            var tokens = posSeg.Cut(s);
            Response.Write(string.Join(" ", tokens.Select(token => string.Format("{0}/{1}</br>", token.Word, token.Flag))));

        }
    }
}