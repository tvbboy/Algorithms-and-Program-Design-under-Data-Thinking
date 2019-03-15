using System;

namespace ProjectHelloworld
{
    public partial class homeworkOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<script>alert('欢迎学习《数据思维下的算法与程序设计》课程')</script>");
        }
    }
}