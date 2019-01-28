using SQL;
using System;
using System.Data;
namespace ProjectAlgorithm
{
    public partial class ExampleRecursionDB : System.Web.UI.Page
    {
        DataTable dt;
        int count;//用来记录谱系中第几代
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from  DynastyHanEmperor ";
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();            
            sh.RunSQL(sql,ref ds);
            if (ds.Tables.Count > 0)
            { 
                dt = ds.Tables[0];
                PrintFather("018");//输出汉献帝刘协的谱系
                Response.Write(string.Format("总共{0}代</br>", count));
                count = 0;
                PrintFather("035");//输出刘备的谱系
                Response.Write(string.Format("总共{0}代</br>", count));
                count = 0;
                PrintFather("011");//输出刘秀的谱系
                Response.Write(string.Format("总共{0}代</br>", count));
            }
        }
        private void PrintFather(string EID)
        {
            //边界条件避免死循环
            if (EID == "0")
                return;
            string condition = string.Format("EID ='{0}'", EID);
            DataRow[] rows = dt.Select(condition);
            if (rows.Length > 0)
            {
                PrintFather(rows[0]["EPARENTID"].ToString());
                Response.Write(rows[0]["ENAME"].ToString() + "</br>");
                count++;
            }
        }
    }
}