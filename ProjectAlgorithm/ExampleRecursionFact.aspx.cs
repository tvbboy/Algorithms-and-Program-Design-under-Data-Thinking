using System;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 递归阶乘的思路
    ///  </summary>
    public partial class ExampleRecursionFact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
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
       protected void btnFact_Click(object sender, EventArgs e)
       {
            try
            {
                int num = int.Parse(txtNum.Text);
                Response.Write(string.Format("{0}的阶乘是{1}", num, Fact(num)));
            }
            catch
            {
                Response.Write("输入的内容有误，请重新输入");
            }
       }
    }
}