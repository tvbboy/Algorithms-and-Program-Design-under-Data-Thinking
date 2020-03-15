using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectHelloWorld
{
    public partial class homeworkTriangularArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "三角形面积求解工具";
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //初始化
            double m = 0;
            double a = double.Parse(TextBox1.Text);
            double b = double.Parse(TextBox2.Text);
            double c = double.Parse(TextBox3.Text);
            string error_msg = "你输入的三条边不能构成1个三角形";
            string right_msg_1 = "你输入的三条边组成了一个";
            string tri_type = "";
            string right_msg_2 = "三角形，它的面积是";
            //排序
            if (a > b) { m = b; b = a; a = m; }
            if (a > c) { m = c; c = a; a = m; }
            if (b > c) { m = c; c = b; b = m; }
            //计算正、余弦
            double cosC = (a * a + b * b - c * c) / (2 * a * b);
            double sinC = Math.Sqrt(1 - cosC * cosC);
            //判断非三角形
            if (cosC <= -1 || a <= 0 || b <= 0 || c <= 0) { Response.Write(error_msg); }
            //计算面积
            double S = 0.5 * a * b * sinC;
            string area = S.ToString();
            //判断三角形类型
            if (a > 0 && b > 0 && c > 0)
            {
                if (a == b)
                {
                    if (-1 < cosC && cosC < 0)
                    {
                        tri_type = "等腰钝角";
                    }
                    else if (cosC == 0)
                    {
                        tri_type = "等腰直角";
                    }
                    else if (0 < cosC && cosC < 0.5)
                    {
                        tri_type = "等腰锐角";
                    }
                    else if (cosC == 0.5)
                    {
                        tri_type = "等边锐角";
                    }
                }
                else
                {
                    if (b == c)
                    {
                        tri_type = "等腰锐角";
                    }
                    else
                    {
                        if (-1 < cosC && cosC < 0)
                        {
                            tri_type = "一般钝角";
                        }
                        else if (cosC == 0)
                        {
                            tri_type = "一般直角";
                        }
                        else if (0 < cosC && cosC < 0.5)
                        {
                            tri_type = "一般锐角";
                        }
                    }
                }
            }
            Response.Write(right_msg_1 + tri_type + right_msg_2 + area);
        }
    }
}