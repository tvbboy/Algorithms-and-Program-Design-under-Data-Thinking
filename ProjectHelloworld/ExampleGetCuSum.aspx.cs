using System;

namespace ProjectHelloworld
{
    public partial class ExampleGetCuSum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cusum = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)//如果是偶数
                    cusum += i;
            }
            string result = string.Format("偶数和是{0}", cusum.ToString());
            Response.Write(result);

        }
    }
}