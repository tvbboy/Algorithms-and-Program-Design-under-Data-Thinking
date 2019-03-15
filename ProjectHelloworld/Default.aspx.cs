using System;

namespace ProjectHelloworld
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "这是我的第一个动态网页";
            Response.Write("Hello World");
        }
    }
}