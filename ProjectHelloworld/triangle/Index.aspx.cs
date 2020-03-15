using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class Index : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                this.Title = "HelloWorld";
                Response.Write("<script type='text/javascript'>alert(\"xx\");</script>");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e) {
            double a = double.Parse(TextBox1.Text);
            double b = double.Parse(TextBox2.Text);
            double c = double.Parse(TextBox3.Text);
            if (!IsTriangle(a,b,c)) {
                Response.Write("<script>alert(\"三条边无法构成一个三角形\");</script>");
            } else {
                Response.Write(String.Format("<script>alert(\"三条边构成一个{0}三角形，面积是{1}\");</script>", getType(a,b,c), getArea(a,b,c)));
            }
        }
        private bool IsTriangle(double a, double b, double c) {
            return (a + b > c && a + c > b && b + c > a);
        }
        private double getArea(double a, double b, double c) {
            double p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private String getType(double a, double b, double c) {
            String result = "";
            if (a == b && b == c) {
                result += "等边";
            } else if(a == b || b == c || a == c){
                result += "等腰";
            } else {
                result += "一般";
            }
            double cosA = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
            double cosB = (Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c);
            double cosC = (Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * b * a);
            if (cosA == 0 || cosB == 0 || cosC == 0){
                result += "直角";
            } else if (cosA < 0 || cosB < 0 || cosC < 0){
                result += "钝角";
            } else {
                result += "锐角";
            }
            return result;
        }
    }
}