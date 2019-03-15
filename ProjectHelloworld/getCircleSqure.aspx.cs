using System;

namespace ProjectHelloworld
{
    public partial class getCircleSqure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double pi = 3.14;
            double r = 12;
            //假设发生了下面误改
            pi = 4.14;
            double s = pi * r * r;
            Response.Write(string.Format("半径是{0}的圆的面积是{1}",r, s));

        }
    }
}