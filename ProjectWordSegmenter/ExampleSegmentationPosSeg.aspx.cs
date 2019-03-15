using JiebaNet.Segmenter.PosSeg;
using System;
using System.Linq;

namespace ProjectWordSegmenter
{
    public partial class ExampleSegmentationPosSeg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var posSeg = new PosSegmenter();
            var s = "就算你留恋开放在水中娇艳的水仙,别忘了寂寞的山谷里角落里野百合也有春天";
            var tokens = posSeg.Cut(s);
            Response.Write(string.Join(" ", tokens.Select(token => string.Format("{0}/{1}", token.Word, token.Flag))));

        }
    }
}