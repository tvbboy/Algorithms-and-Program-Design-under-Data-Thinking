using System;

namespace ProjectHelloworld
{
    public partial class homeworkGetTriangularArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetS_Click(object sender, EventArgs e)
        {
            double a = double.Parse(txtA.Text);
            double b = double.Parse(txtB.Text);
            double c = double.Parse(txtC.Text);
            //判断是否构造三角形
            if (a >= b + c || b >= a + c || c >= a + b)
            {
                Response.Write("你输入的三条边不能组成三角形");                
            }
            else
            {
                double s = (a + b + c) / 2;
                double area= Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                string ret = "";
                if (a == b && b == c )
                    ret = "等边";
                else if (a == b || b == c ||a==c)
                    ret = "等腰";
                else
                    ret = "一般";
                if (a * a > b * b + c * c || b * b > a * a + c * c || c * c > a * a + b * b) 
                {
                    ret += "钝角三角形";                  
                }
                else if (a * a == b * b + c * c || b * b == a * a + c * c || c * c == a * a + b * b)
                {
                    ret += "直角三角形";                    
                }
                else if (a * a < (b * b + c * c) || b * b < a * a + c * c || c * c < a * a + b * b)
                {
                    ret += "锐角三角形";                    
                }
                Response.Write("你输入的三条边组成了一个" + ret + ",它的面积是" + area);
            }

            
        }
    }
}