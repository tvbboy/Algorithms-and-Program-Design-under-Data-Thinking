using System;

namespace ProjectHelloworld
{
    public partial class ExampleGetMax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int a, b, c, max;
            a = 100;
            b = 234;
            c = 66;
            string s = "三个数:" + a + "," + b + "," + c + ".其中最大值是:";
            if (a >= b && a >= c)
                max = a;
            else if (b >= c)
                max = b;
            else
                max = c;
            Response.Write(s + max);

        }
    }
}