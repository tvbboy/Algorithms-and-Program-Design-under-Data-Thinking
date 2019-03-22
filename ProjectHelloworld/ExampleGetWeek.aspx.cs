using System;

namespace ProjectHelloworld
{
    public partial class ExampleGetWeek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int week = 2;
            switch (week)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    //当变量week的值为1,2,3,4,5中任意一个值时,处理方法相同,都是打印"今天是工作日".
                    Response.Write("今天是工作日");
                    break;
                case 6:
                case 7:
                    Response.Write("今天是休息日");//同理
                    break;
            }

        }
    }
}