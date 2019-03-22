using System;
using System.Text;

namespace ProjectHelloworld
{
    public partial class ExamplePrintNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pattern ="哈哈asdfsdf23sdafdsf33455结尾";
            StringBuilder sb = new StringBuilder("");
            foreach (char c in pattern)
            {
                if (Convert.ToInt32(c) >= 48 && Convert.ToInt32(c) <= 57)
                {
                    sb.Append(c);
                }
            }
            Response.Write("原字符串:"+ pattern+"<br>");
            Response.Write("使用ASCII码提取<br>");
            Response.Write(sb.ToString());

        }
    }
}