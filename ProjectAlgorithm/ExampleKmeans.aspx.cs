using Common.AITools.Tvbboy;
using System;
namespace ProjectAlgorithm
{
    /// <summary>
    /// https://www.cnblogs.com/gaochundong/p/kmeans_clustering.html
    /// 认识k-means的聚类
    /// </summary>
    public partial class ExampleKmeans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("\n开始 k-means 聚类（clustering）\n");
            // real data likely to come from a text file or SQL
            // 需要聚类的数据是两个维度，具体指某个人的身高体重
            //集合中每项描述了一个人的身高（Height: inches）和体重（Weight: kilograms）
            double[][] rawData = new double[20][];
            rawData[0] = new double[] { 65.0, 220.0 };
            rawData[1] = new double[] { 73.0, 160.0 };
            rawData[2] = new double[] { 59.0, 110.0 };
            rawData[3] = new double[] { 61.0, 120.0 };
            rawData[4] = new double[] { 75.0, 150.0 };
            rawData[5] = new double[] { 67.0, 240.0 };
            rawData[6] = new double[] { 68.0, 230.0 };
            rawData[7] = new double[] { 70.0, 220.0 };
            rawData[8] = new double[] { 62.0, 130.0 };
            rawData[9] = new double[] { 66.0, 210.0 };
            rawData[10] = new double[] { 77.0, 190.0 };
            rawData[11] = new double[] { 75.0, 180.0 };
            rawData[12] = new double[] { 74.0, 170.0 };
            rawData[13] = new double[] { 70.0, 210.0 };
            rawData[14] = new double[] { 61.0, 110.0 };
            rawData[15] = new double[] { 58.0, 100.0 };
            rawData[16] = new double[] { 66.0, 230.0 };
            rawData[17] = new double[] { 59.0, 120.0 };
            rawData[18] = new double[] { 68.0, 210.0 };
            rawData[19] = new double[] { 61.0, 130.0 };

            Response.Write("需要聚类的数据如下:</br>");
            Response.Write("&nbsp;&nbsp&nbsp&nbsp身高&nbsp;&nbsp&nbsp&nbsp体重</br>");
            Response.Write("-------------------</br>");
            ShowData(rawData, 2, true);
            //首先需要确定划分的簇的数量
            int numClusters = 3;
            Response.Write("需要聚类的目标簇数: " + numClusters+"<br>");

            int[] clustering =ClassKmeans.Cluster(rawData, numClusters); // this is it

            Response.Write("K-means 聚类结束e<br>");

            //Response.Write("最终划分的结果："+"<br>");
            ///ShowVector(clustering, true);

            Response.Write("原始数据被聚类之后的结果:<br>");
            ShowClustered(rawData, clustering, numClusters, 1);
        }
        /// <summary>
        ///  用来显示二维的数据
        /// </summary>
        /// <param name="data">被显示的数据</param>
        /// <param name="decimals">如果是数字的话显示的有效数字位数</param>
        /// <param name="indices">是否显示编号一列</param>
       
        public void ShowData(double[][] data, int decimals, bool indices)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                if (indices)
                    Response.Write(i.ToString().PadLeft(3) + "&nbsp;&nbsp&nbsp&nbsp");
                for (int j = 0; j < data[i].Length; ++j)
                {
                    if (data[i][j] >= 0.0)
                        Response.Write("&nbsp;&nbsp&nbsp&nbsp");
                    Response.Write(data[i][j].ToString("F" + decimals) + "&nbsp;&nbsp&nbsp&nbsp ");
                }
                Response.Write("</br>");
            }
           
        } // ShowData
        public  void ShowVector(int[] vector, bool newLine)
      {
        for (int i = 0; i<vector.Length; ++i)
                Response.Write(vector[i] + "&nbsp;&nbsp;&nbsp;&nbsp; ");
  
        if (newLine == true)
                Response.Write("</br>");
      }
        public void ShowClustered(double[][] data, int[] clustering,int numClusters, int decimals)
        {
            for (int k = 0; k<numClusters; ++k)
            {
                Response.Write("===================</br>");
                for (int i = 0; i<data.Length; ++i)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k) continue;
                    Response.Write("第"+i.ToString() + "项&nbsp;&nbsp; ");
                    for (int j = 0; j<data[i].Length; ++j)
                    {
                      double v = data[i][j];
                      Response.Write(v.ToString("F" + decimals) + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                    Response.Write("</br>");
                }
                Response.Write("===================</br>");
            }
        }
   
    }
}