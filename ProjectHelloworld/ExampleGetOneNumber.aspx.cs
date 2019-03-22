using System;

namespace ProjectHelloworld
{
    public partial class ExampleGetOneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cusum = 0;
            int n = 0;
            while (cusum <= 100)
            {
                n++;
                cusum += n;
            }
            Response.Write(n);

        }
    }
}