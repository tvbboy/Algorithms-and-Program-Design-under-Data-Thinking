using System;

namespace ProjectAlgorithm
{
    /// <summary>
    /// https://www.cnblogs.com/leoo2sk/archive/2009/05/29/1491526.html
    /// sin(x)/x^2在1~2之间的积分
    /// </summary>
    public partial class ExampleMonteCarloIntegratorSinx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(MonteCarloIntegrate(1, 2, 10000));
        }
        /// <summary>
        /// 用Monte-Carlo法求解积分值
        /// </summary>
        /// <param name="a">积分下限</param>
        /// <param name="b">积分上限</param>
        /// <param name="N">模拟次数</param>
        /// <returns>积分值</returns>
        public static double MonteCarloIntegrate(int a, int b, int N)
        {
            Random random = new Random();
            int positivePointCount = 0;//y >=0 区间内落入函数曲线内的点数目
            int negativePointCount = 0;//y < 0区间内落入函数曲线内的点数目

            //统计y >= 0区间点分布
            for (int i = 0; i < N; i++)
            {
                double xCoordinate = random.NextDouble();//随机产生的x坐标
                double yCoordinate = random.NextDouble();//随机产生的y坐标
                xCoordinate = a + (b - a) * xCoordinate;//将x规格化到相应积分区间
                //yCoordinate = 1 * yCoordinate;//将y规格化到相应区间
                if (Math.Sin(xCoordinate) / (xCoordinate* xCoordinate) >= yCoordinate)
                {
                    positivePointCount++;
                }
            }

            //统计y < 0区间点分布
            for (int i = 0; i < N; i++)
            {
                double xCoordinate = random.NextDouble();//随机产生的x坐标
                double yCoordinate = random.NextDouble();//随机产生的y坐标
                xCoordinate = a + (b - a) * xCoordinate;//将x规格化到相应积分区间
                yCoordinate = -1 * yCoordinate;//将y规格化到相应区间
                if (Math.Sin(xCoordinate) / (xCoordinate * xCoordinate) <= yCoordinate)
                {
                    negativePointCount++;
                }
            }

            double positiveFrequency = (double)positivePointCount / (double)N;//y >= 0区间内函数内点频率
            double negativeFrequency = (double)negativePointCount / (double)N;//y < 0区间内函数内点频率

            return (positiveFrequency - negativeFrequency) * (double)(b - a);
        }
    }
}