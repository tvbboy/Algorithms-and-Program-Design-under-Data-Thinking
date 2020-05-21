using System;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 作业：使用蒙特卡洛方法模拟产品的瑕疵率
    /// http://mdsa.51cto.com/art/201509/490338.htm
    /// </summary>
    public partial class ExampleMonteCarloProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            double Y = 0.0; //转换方程的预期值
            int SpecimenNum = 1000000; //需要用来测试的样本数量
            int DefectiveNum = 0;
            double[] X1=new double[SpecimenNum];
            double X2 = 0.5;
            double[] X3 = new double[SpecimenNum];
            double[] X4 = new double[SpecimenNum];
            double[] X5 = new double[SpecimenNum];
            double[] X6 = new double[SpecimenNum];
            double X7 = 0.5;
            double[] X8 = new double[SpecimenNum];
            for (int i = 0; i < SpecimenNum; i++)
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                X1[i] = random.NextDouble() * (2.091 - 1.909) + 1.909;
                X3[i] = random.NextDouble() * (4.682- 4.468) + 4.468;
                X4[i] = random.NextDouble() * (3.091 - 2.909) + 2.909;
                X5[i] = random.NextDouble() * (1.102 - 0.898) + 1.102;
                X6[i] = random.NextDouble() * (13.1 -12.9) +12.9;
                X8[i] = random.NextDouble() * (2.091 - 1.909) + 1.909; 
            }
            for (int i = 0; i < SpecimenNum; i++)
            {
                Y = X1[i] + X2 + X3[i] + X4[i] + X5[i] + X6[i] + X7 + X8[i];
                if (Y > 27.0)
                    DefectiveNum++;
            }
            Response.Write("</br>样本总数：" + SpecimenNum);
            Response.Write("</br>疵品总数：" + DefectiveNum);
            Response.Write("</br>：概率" + (double)DefectiveNum / (double)SpecimenNum);
        }
    }
}