using System;
using System.Collections;
using Common.AITools.Tvbboy;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 均值归一化函数
    /// </summary>
    public partial class ExampleNormalization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] FlightDistance = { 400, 134000, 20000, 32000 };
            double[] AimFlightDistance = { 0, 0, 0, 0, 0 };
            ArrayList list = new ArrayList(FlightDistance);
            list.Sort();
            double min = Convert.ToDouble(list[0]);
            double max = Convert.ToDouble(list[list.Count - 1]);
            double mean = TvbboyMath.Mean(FlightDistance);
            Response.Write(string.Format("待处理数据的最大值:{0},最小值{1},平均值{2}</br>",max,min,mean));
            Response.Write("数据归一化结果:</br>");
            for (int i = 0; i < FlightDistance.Length; i++)
            {
                
                AimFlightDistance[i] = Math.Abs(FlightDistance[i] - mean) / (max-min);
                Response.Write(string.Format("{0}----归一化-----{1}</br>", FlightDistance[i], AimFlightDistance[i]));
            }

        }
        
    }
}