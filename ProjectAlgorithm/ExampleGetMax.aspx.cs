using System;

namespace ProjectAlgorithm
{
    public partial class ExampleGetMax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        private double getMax(double x,double y)
        {
            return x > y ? x : y;
        }
        protected void btnGetMax_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(txtNum1.Text);
                double num2 = double.Parse(txtNum2.Text);
                double num3 = double.Parse(txtNum3.Text);
                double maxnum = getMax(num1, getMax(num2, num3));
                Response.Write(string.Format("此三个数的最大值是{0}", maxnum));
            }
            catch
            {
                Response.Write("可能输入有误，数据类型转发发生异常");
            }
        }
    }
}