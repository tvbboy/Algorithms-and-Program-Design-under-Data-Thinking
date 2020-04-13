using System;

namespace ProjectAlgorithm
{
    //以上证数据（2018年10月）作基本的统计介绍
    public partial class ExampleBasicStatisticsPpcc : System.Web.UI.Page
    {
       
        //2018年10月份每天的涨跌
        private double[] Month201810RangeData = { 1.3526,1.0206,-2.1834,-0.1902,0.0194,0.3264,-2.2619,4.0938,2.5759,-2.9355,0.6003,-0.8477,-1.4889,0.9079,-5.2233,0.1773,0.1657,-3.7159 };      
        //2018年10月份山东黄金股票的涨跌
        private double[] Month201810GoldenData = { -0.5671,-1.5264,0.2239,-0.8142,0.9716,-0.5574,3.341,2.1978,3.8305,-3.953,-0.4287,-3.0967,1.6117,1.0469,-1.1877,4.6931,4.7479,0.5492};
       //private double[] MonthRangeData = { 0.16, -0.67, -0.21, 0.54, 0.22, -0.15, -0.63, 0.03, 0.88, -0.04, 0.20, 0.52, -1.03, 0.11, 0.49, -0.47, 0.35, 0.80, -0.33, -0.24, -0.13, -0.82, 0.56 };
        protected void Page_Load(object sender, EventArgs e)
        {
                
            double Variance201810= calcVariance(Month201810RangeData);
            double Mean201810 = calcMean(Month201810RangeData);
            double cov = calcCov(Month201810RangeData, Month201810GoldenData);
            //相关系数
            double ppcc = 0.0;
            ppcc = cov / (Math.Sqrt(Variance201810)* Math.Sqrt(calcVariance(Month201810GoldenData)));
            string result = string.Format("<br>2018年10月份的大盘指数和山东黄金指数的协方差：{0}，相关系数为{1}<br>", cov, ppcc);
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
        /// <summary>
        /// 输出两个数组的协方差,两个数组的长度必须一致
        /// </summary>
        /// <param name="aimtmp1"></param>
        /// <param name="aimtmp2"></param>
        private double calcCov(double[] aimtmp1,double[] aimtmp2)
        {
            if (aimtmp1.Length != aimtmp2.Length)
            {
                Response.Write("<br>计算协方差的两个数组必须长度一致</br>");
                return -1;
            }
            printData(aimtmp1);
            printData(aimtmp2);                
            //均值
            double MonthRangeDataMean1 = calcMean(aimtmp1) ;
            double MonthRangeDataMean2 = calcMean(aimtmp2);            
            double tmp = 0.0;
            for (int i = 0; i < aimtmp1.Length; i++)
            {
                tmp += (aimtmp1[i] - MonthRangeDataMean1) * (aimtmp2[i] - MonthRangeDataMean2);

            }
            //协方差
            double Cov = tmp / aimtmp1.Length;
            return Cov;
         
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