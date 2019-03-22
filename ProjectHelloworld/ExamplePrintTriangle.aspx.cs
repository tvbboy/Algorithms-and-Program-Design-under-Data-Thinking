using System;

namespace ProjectHelloworld
{
    public partial class ExamplePrintTriangle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int maxLineno = 5;
            int lineno, i = 0;
            for (lineno = 1; lineno <= maxLineno; lineno++)
            {
                for (i = 0; i < maxLineno - lineno; i++)
                {
                    Response.Write("&nbsp;&nbsp;");
                }
                for (i = 0; i < 2 * lineno - 1; i++)
                {
                    Response.Write("*");
                }
                Response.Write("</br>");
            }

        }
    }
}