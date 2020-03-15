using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle
{
    public partial class Triangle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "三角形形状与面积计算器";
            //命名网页。
            double a, b, c, s, k;
            string msg_1, msg_2, shape_1, shape_2, yb, db, dy, zj, dj, rj;
            a = 24;
            b = 24;
            c = 19;
            msg_1 = "你输入的三条边组成了一个";
            msg_2 = "三角形，它的面积是";
            yb = "一般";
            db = "等边";
            dy = "等腰";
            zj = "直角";
            dj = "钝角";
            rj = "锐角";
            k = (a + b + c) / 2;
            s = Math.Sqrt(k * (k - a) * (k - b) * (k - c));
            //计算三角形面积。
            if (a == b && b == c)
            { shape_1 = db; }
            else if (a != b && b != c && a != c)
            { shape_1 = yb; }
            else { shape_1 = dy; }
            //判断形状1：边长。
            if (a * a + b * b == c * c || c * c + b * b == a * a || a * a + c * c == b * b)
            { shape_2 = zj; }
            else if (a * a + b * b > c * c || c * c + b * b > a * a || a * a + c * c > b * b)
            { shape_2 = rj; }
            else
            { shape_2 = dj; }
                //判断形状2：角度。
            if (a * b * c < 0 || a >= b + c || b >= a + c || c >= b + a)
                { Response.Write("你输入的三条边不能构成1个三角形。"); }
                //判定不能构成三角形的情况。
            else
                { Response.Write(msg_1 + shape_1 + shape_2+ msg_2 + s); }
            }
        }
    }