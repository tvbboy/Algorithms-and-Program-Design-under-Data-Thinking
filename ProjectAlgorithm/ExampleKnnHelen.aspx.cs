using Common.AITools.Tvbboy;
using SQL;
using System;
using System.Collections.Generic;
using System.Data;
namespace ProjectAlgorithm
{
    public partial class ExampleKnnHelen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string sql = string.Format("select FlightDistance,GameTime,Icecream,Label from tblHelenDate where id >=1 and id<=900 order by id");          
            DataSet ds=new DataSet();
            SQLHelper sh = new SQLHelper();            
            try
            {
                //通过数据库读取数据建立数据模型
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                int len = dt.Rows.Count;
                int[] Label = new int[len];
                double[] FlightDistance = new double[len];
                double[] GameTime = new double[len];
                double[] Icecream = new double[len];
                int i= 0;
                foreach (DataRow dr in dt.Rows)
                {
                    FlightDistance[i] = Convert.ToDouble(dr[0].ToString());
                    GameTime[i] = Convert.ToDouble(dr[1].ToString());
                    Icecream[i] = Convert.ToDouble(dr[2].ToString());
                    Label[i] = Convert.ToInt32(dr[3].ToString());
                    i++;
                }
                //归一化处理
                FlightDistance = TvbboyMath.Normlize(FlightDistance);
                GameTime = TvbboyMath.Normlize(GameTime);
                Icecream = TvbboyMath.Normlize(Icecream);

                //建立模型需要的数据类型data
                var data = new List<double[]>();
                for(int j=0;j< len;j++)
                {
                    data.Add(new double[] { FlightDistance[j], GameTime[j] , Icecream[j] });
                };
                var labelslist = new List<int>(Label);
                //正式建立knn数据模型
                var knn = new ClassKNN(k: 30, labels: labelslist, features: data);
                //从数据库检索待测的10%数据
                sql = string.Format("select FlightDistance,GameTime,Icecream,Label from tblHelenDate where id >=901 order by id");
                //在执行新的查询前，确认原来datatable数据不再有效的时候，应该将其清空，方可复用，否则数据会累加
                ds.Tables.Clear();
                sh.RunSQL(sql, ref ds);
                
                dt = ds.Tables[0];
                len = dt.Rows.Count;
                int[] aimLabel = new int[len];
                double[] aimFlightDistance = new double[len];
                double[] aimGameTime = new double[len];
                double[] aimIcecream = new double[len];
                i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    aimFlightDistance[i] = Convert.ToDouble(dr[0].ToString());
                    aimGameTime[i] = Convert.ToDouble(dr[1].ToString());
                    aimIcecream[i] = Convert.ToDouble(dr[2].ToString());
                    aimLabel[i] = Convert.ToInt32(dr[3].ToString());
                    i++;
                }
                //归一化处理
                aimFlightDistance = TvbboyMath.Normlize(aimFlightDistance);
                aimGameTime = TvbboyMath.Normlize(aimGameTime);
                aimIcecream = TvbboyMath.Normlize(aimIcecream);
                int predictionTrueNum = 0;
                for (int j=0;j<len;j++)
                { 
                    int classfyResult = knn.Classify(new double[][] { new double[] { aimFlightDistance[j], aimGameTime[j], aimIcecream[j] } });
                    Response.Write("第"+(j+1)+"组数据：预测值" + classfyResult + "-----真实值："+ aimLabel[j]+ "&nbsp;&nbsp;");
                    if (j % 4 == 0)
                        Response.Write("</br>");
                    if (classfyResult == aimLabel[j])
                        predictionTrueNum++;
                }
                //成功率是小数，所以不允许两个整数相除
                Response.Write("预测成功率：" + double.Parse(predictionTrueNum.ToString())/len + "</br>");
                Response.Write("</br>----------------------------------------</br>");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message+ex.Message);

            }
            finally
            {
                //使用完毕，必须主动关闭数据读取器
                sh.Close();
            }
        }
    }
}