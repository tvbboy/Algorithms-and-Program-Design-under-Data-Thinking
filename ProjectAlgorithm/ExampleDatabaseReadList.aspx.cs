using SQL;
using System;
using System.Data.SqlClient;


namespace ProjectAlgorithm
{
    public partial class ExampleDatabaseReadList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //entry_code=113意味着弑君当上帝王的人
            string sql = string.Format("select B.c_personid AS c_personid,B.c_name_chn from ENTRY_DATA A ,BIOG_MAIN B where A.c_personid = B.c_personid AND c_entry_code = 113");
            SQLHelper sh = new SQLHelper();
            SqlDataReader sdr;            
            try
            {
                sh.RunSQL(sql, out sdr);
                while (sdr.Read())
                {
                    Response.Write(string.Format("ID：{0},姓名：{1}</br>", sdr["c_personid"].ToString(), sdr["c_name_chn"].ToString()));
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                
            }
            finally
            {                
                //使用完毕，必须主动关闭数据读取器
                sh.Close();
            }

        }
    }
}