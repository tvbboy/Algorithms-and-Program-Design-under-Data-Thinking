using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 作业：使用蒙特卡洛方法求 y = x^2 在 [0, 1] 区间的积分
    /// 这个函数在 (1,1) 点的取值为1，所以整个红色区域在一个面积为 1 的正方形里面。
    /// 在该正方形内部，产生大量随机点，可以计算出有多少点落在红色区域,判断条件 y<x^2
    /// 这个比重就是所要求的积分值。
    /// http://mdsa.51cto.com/art/201509/490338.htm
    /// </summary>
    public partial class MonteCarloIntegral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double x, y;//随机点
            double p;//随机点落入圆中的概率
            double m;//随机点落入圆的数量
          
            int nums = 10000;
            Random rand = new Random();
            m = 0;
            for (int i = 0; i <= nums; i++)
            {
                //产生（0,1）之间的随机点（x,y）
                x = rand.NextDouble();
                y = rand.NextDouble();
                //如果这个点坐落在圆內
                if (x * x>= y)
                {
                    m++;
                }
                Response.Write(string.Format("</br>x={0},y={1}", x, y));
            }
            p = m / nums;
            
            Response.Write("</br>落在积分区域的次数：" + m);
            Response.Write("</br>随机点落在积分区域的概率：" + p);
            Response.Write("</br>：积分的值是" + p);
        }
    }
}