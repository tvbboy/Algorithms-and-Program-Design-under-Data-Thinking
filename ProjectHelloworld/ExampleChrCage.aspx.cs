using System;

namespace ProjectHelloworld
{
    public partial class ExampleChrCage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int chickenNum, rabbitNum;
            int count = 0;
            for (chickenNum = 1; chickenNum <= 35; chickenNum++)
            {
                for (rabbitNum = 0; rabbitNum < 35; rabbitNum++)
                {
                    count++;
                    if (chickenNum * 2 + rabbitNum * 4 == 94 && chickenNum + rabbitNum == 35)
                        Response.Write(string.Format("鸡和兔子的数量分别是{0},{1}", chickenNum, rabbitNum));
                }
            }
            Response.Write(string.Format("<br>总共循环了{0}次", count));

}
    }
}