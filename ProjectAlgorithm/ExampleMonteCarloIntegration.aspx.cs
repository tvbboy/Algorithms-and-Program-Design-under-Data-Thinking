using System;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 使用蒙卡算法求积分
    /// </summary>
    public partial class ExampleMonteCarloIntegration : System.Web.UI.Page
    {
        private int nums = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double x, y;//随机点
            double p;//随机点落入函数中的概率
            double m;//随机点落入函数中的数量
            double s=0;//所求面积
            nums = int.Parse(txtNum.Text);
            Random rand = new Random();
            m = 0;
            for (int i = 0; i <= nums; i++)
            {
                //产生（0，1）之间的随机点（x,y）
                x = rand.NextDouble() * (-1) +1;
                y = rand.NextDouble() * (-1) + 1;
                //如果这个点坐落在函数內
                if (  y <= x * x)
                {
                    m++;
                }
            }
            p = m / nums;
            s = 1 * p;
            Response.Write("</br>落在函数区域的次数：" + m);
            Response.Write("</br>随机点落在函数区域的概率：" + p);
            Response.Write("</br>积分值为：" + s);
        }
    }
}