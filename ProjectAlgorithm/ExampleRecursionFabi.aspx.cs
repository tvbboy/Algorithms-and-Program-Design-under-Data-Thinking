using System;

namespace ProjectAlgorithm
{
    public partial class ExampleRecursionFabi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("10个斐波那契序列：");
            for (int i = 1; i <= 10; i++)
            {
                Response.Write(Fabi(i) + "&nbsp;&nbsp;");
            }
        }
        /// <summary>
        /// 返回第n个位置的数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int Fabi(int n)
        {
            if (n == 2)
                return 1;
            else if (n == 1)
                return 1;
            else
                return Fabi(n - 1) + Fabi(n - 2);
        }
    }
}