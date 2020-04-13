using System;
using System.Collections.Generic;
using Common.AITools.Tvbboy;

namespace ProjectAlgorithm
{
    public partial class ExampleKnnMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             var data = new List<double[]>() {
                new double[] {3,104},
                new double[] {2,100},
                new double[] {1,81},
                new double[] {101,10},
                new double[] {99,5},
                new double[] {98,2},
            };
            //其中类别0代表爱情片，类别1代表动作片。            
            var labels = new List<int>()
            {
                0,0,0,1,1,1
            };
            var knn = new ClassKNN(k: 3, labels: labels, features: data);
            
            //开始分类，并获取最后的分类结果
            int classfyResult1=knn.Classify(new double[][] { new double[] { 18, 90 } });
            int classfyResult2 = knn.Classify(new double[][] { new double[] { 50, 25 } });
            Response.Write("电影7分类：" + classfyResult1+"</br>");
            Response.Write("电影8分类：" + classfyResult2 + "</br>");
            Response.Write("</br>----------------------------------------</br>");
            //输出所有数据
            Response.Write(knn.getResult());
        }


    }
}
