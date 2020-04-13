using Common.AITools.Tvbboy;
using System;

namespace ProjectAlgorithm
{
    public partial class ExampleMultiLineRegression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Point[] array = new Point[6];
            array[0] = new Point(2010, 35000);
            array[1] = new Point(2012, 36000);
            array[2] = new Point(2013, 38000);
            array[3] = new Point(2014, 39000);
            array[4] = new Point(2015, 40000);
            array[5] = new Point(2016, 40500);           
            MultiLineRegression(array);
        }       
        /// <summary>
        ///通过最小二乘法进行二次方程的拟合 
        /// </summary>
        /// <param name="parray"></param>
        public void MultiLineRegression(Point[] parray)
        {
            //点数不能小于2
            if (parray.Length < 2)
            {
                Response.Write("点的数量小于2，无法进行线性回归");
                return;
            }
            //MultiLine的第一个参数，是已经存在的点的集合，第二个参数是拟合的方程的最高次幂
            //返回的是double[]类型的数组，这个数组放的就是方程的系数
            double[] xishu=ClassLeastSquares.MultiLine(parray, 2);
            string expr = "";
            for (int i = 0; i < xishu.Length; i++)
                expr += xishu[i].ToString() + "*x^" + i+"+";
            expr = expr.Substring(0, expr.Length - 1);
            Response.Write("线性回归二次方程为： y = "+expr);
        }
    }
}