using Common.AITools.Tvbboy;
using System;

namespace ProjectAlgorithm
{
    public partial class ExampleStatisticsPulmonary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double z1, z2;
            double x1, x2;
            double m, s, sigma;//均值\方差\标准差
            try
            {
                m = double.Parse(txtMean.Text);
                s = double.Parse(txtS.Text);//输入的是方差
                sigma = Math.Sqrt(s);
                //处理统计区间，如果是第二个文本框内容是A，表示正无穷
                //如果是第一个文本框内容是A，表示负无穷
                if (txtX1.Text.ToUpper() != "A")
                {
                    x1 = double.Parse(txtX1.Text);
                    z1 = (x1 - m) / s;//标准正态变换
                }
                else
                    z1 = -4;//只要小于-3.8就可以视为负无穷
                if (txtX2.Text.ToUpper() != "A")
                {
                    x2 = double.Parse(txtX2.Text);
                    z2 = (x2 - m) / s;//标准正态变换
                }
                else
                    z2 = 4;//只要大于3.8就可以视为正无穷
                Response.Write(string.Format("转换为标准正态分布之后，所求的区间是{0}-{1}，所求概率是{2}", 
                                    z1, z2, ClassStatistics.selfCaculate(z2) - ClassStatistics.selfCaculate(z1)
                                    )
                );
            }
            catch
            {
                Response.Write("输入内容有误！");
            }

        }
    }
}