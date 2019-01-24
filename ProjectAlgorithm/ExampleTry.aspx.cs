using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    public partial class ExampleTry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = txtContent.Text;
            if (s.Length < 1)
            {
                Response.Write("必须输入内容");
                return;
            }
            try
            {
                if (double.Parse(s) < 0)
                {
                    Response.Write(string.Format("输入内容{0}是负数",s));
                }
                else
                {
                    Response.Write(string.Format("输入内容{0}不是负数",s));
                }
            }
            //发生异常，证明语句double.parse(s)出错，也就证明s根本不是数学意义上数据，那肯定无从谈起是否是负数
            catch
            {
                Response.Write(string.Format("输入内容{0}不是负数", s));
            }

        }
    }
}