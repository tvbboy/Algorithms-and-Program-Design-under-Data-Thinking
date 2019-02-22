using System;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 该示例程序主要递进的讲述.NET 随机数的产生
    /// </summary>
    public partial class ExampleRandom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*方法一
            for (int i = 0; i < 10; i++)
            {
                Random rd = new Random();
                Response.Write(rd.Next(1, 100).ToString()+"<br>");
            }
            */
            /*方法二
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
               Response.Write(random.Next(1,100)+"<br>");
            }
            */
            for (int i = 0; i < 10; i++)
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                Response.Write(random.Next(1, 100) +"</br>");
            }


        }
    }
}