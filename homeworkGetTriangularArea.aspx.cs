using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hello
{
    public partial class homeworkGetTriangularArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("HELLOWORLD");
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
            double a, b, c, p, s, m, k1, k2, kk1, kk2, mm;
            string bky, ky, sjx, xz, lx;
            bky = "你输入的三条边不能构成1个三角形";
            ky = "你输入的三条边组成了一个";
            sjx = "三角形,它的面积是";
            a = double.Parse(TextBox1.Text);
            b = double.Parse(TextBox2.Text);
            c = double.Parse(TextBox3.Text);

            if (a >= b && a >= c)
            {
                m = a;
                k1 = b;
                k2 = c;
            }
            else if (b >= c)
            {
                m = b;
                k1 = a;
                k2 = c;
            }
            else
            {
                m = c;
                k1 = a;
                k2 = b;
            }
            kk1 = Math.Pow(k1, 2);
            kk2 = Math.Pow(k2, 2);
            mm = Math.Pow(m, 2);
            if (a > 0 && b > 0 && c > 0 && k1 + k2 > m)
            {
                {
                    if (kk1 + kk2 > mm)
                        xz = "锐角";
                    else if (kk1 + kk2 == mm)
                        xz = "直角";
                    else
                        xz = "钝角";
                }
                {
                    if (k1 == k2 && k2 == m)
                        lx = "等边";
                    else if (k1 == k2 || kk1 == m || kk2 == m)
                        lx = "等腰";
                    else
                        lx = "一般";
                }
                p = (a + b + c) / 2;
                s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Response.Write(ky + lx + xz + sjx + s);
            }
            else
                Response.Write(bky);
        }
    }
}