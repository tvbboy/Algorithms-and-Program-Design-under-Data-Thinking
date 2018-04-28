using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 递归阶乘的思路
    ///  </summary>
    public partial class ExampleRecursionFact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("10的阶乘是" + Fact(10)+"</br>");
            Response.Write("10个斐波那契序列：");
            for (int i = 1; i <= 10; i++)
            {
                Response.Write(Fabi(i)+ "&nbsp;&nbsp;");
            }
        }
        /// <summary>
        /// 求a这个数的阶乘
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private int Fact(int a)
        {
            if (a == 1)
                return 1;
            else
                return a * Fact(a - 1);
        }
        /// <summary>
        /// 返回第n个位置的数
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private int Fabi(int n)
        {
            if (n == 2)
                return 1;
            else if (n == 1)
                return 1;
            else
                return Fabi(n-1)+Fabi(n-2);
        }
    }
}