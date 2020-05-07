using System;

namespace ProjectAlgorithm
{
    //以上证数据（2018年10月）作基本的统计介绍
    public partial class ExampleBasicStatistics : System.Web.UI.Page
    {
       
        //2018年10月份每天的涨跌
        private double[] Month201810RangeData = { 1.3526,1.0206,-2.1834,-0.1902,0.0194,0.3264,-2.2619,4.0938,2.5759,-2.9355,0.6003,-0.8477,-1.4889,0.9079,-5.2233,0.1773,0.1657,-3.7159 };
        //2018年10月份每天的涨跌
        private double[] Month201710RangeData = { 0.0886,-0.7749,0.2713,0.3141,0.2553,0.2233,0.0607,0.2515,-0.3437,0.2892,-0.1903,-0.3555,0.1306,-0.0645,0.1565,0.2552,0.7595};
        

        //private double[] MonthRangeData = { 0.16, -0.67, -0.21, 0.54, 0.22, -0.15, -0.63, 0.03, 0.88, -0.04, 0.20, 0.52, -1.03, 0.11, 0.49, -0.47, 0.35, 0.80, -0.33, -0.24, -0.13, -0.82, 0.56 };
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<br>2018年10月份的情况<br>");           
            double Variance201810= calcVariance(Month201810RangeData);
            printData(Month201810RangeData);
            double Mean201810 = calcMean(Month201810RangeData);
            string result = string.Format("其中方差是:{0}，标准差是{1},均值是{2}", Variance201810, Math.Sqrt(Variance201810), Mean201810);
            Response.Write(result);
            
            Response.Write("<br>2017年10月份的情况<br>");
            double Variance201710 = calcVariance(Month201710RangeData);
            printData(Month201710RangeData);
            double Mean201710 = calcMean(Month201710RangeData);
            result = string.Format("其中方差是:{0}，标准差是{1},均值是{2}", Variance201710, Math.Sqrt(Variance201710), Mean201710);
            Response.Write(result);           
        }
        //计算并输出某个数组的方差
        private double calcVariance(double[] aimtmp)
        {
             //均值
            double MonthRangeDataMean = calcMean(aimtmp);
            //方差
            double MonthRangeDataVariance = 0.0;
            double tmp = 0.0;
            for (int i = 0; i < aimtmp.Length; i++)
            {
                tmp += (aimtmp[i] - MonthRangeDataMean) * (aimtmp[i] - MonthRangeDataMean);

            }
            MonthRangeDataVariance = tmp / aimtmp.Length;
            return MonthRangeDataVariance;
        }
        //计算并输出某个数组的方差
        private double calcMean(double[] aimtmp)
        {
           
            double MonthRangeDataTotal = 0;
            for (int i = 0; i < aimtmp.Length; i++)
            {
                MonthRangeDataTotal += aimtmp[i];
            }
            //均值
           double MonthRangeDataMean = MonthRangeDataTotal / aimtmp.Length;
           return MonthRangeDataMean;
        }        
        private void printData(double[] aimtmp)
        {
            string str = "";
            for (int i = 0; i < aimtmp.Length; i++)
            {
                str += string.Format("{0},{1}</br>",i,aimtmp[i]);
            }
            Response.Write("<br>" + str + "<br>");
        }
    }
}