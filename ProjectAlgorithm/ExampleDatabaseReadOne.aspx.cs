using SQL;
using System;
using System.Data.SqlClient;
namespace ProjectAlgorithm
{
    /// <summary>
    /// 数据库如何读取单个记录的内容
    /// </summary>
    public partial class ExampleDatabaseReadOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                      
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string pname = txtName.Text;
            string result = string.Empty;
            if (pname.Length < 1)
            {
                Response.Write("请输入一个人名！");
                return;
            }
            string sql = string.Format("select c_personid,c_name,c_name_chn,c_birthyear,c_deathyear from biog_main where C_NAME_CHN = '{0}'", pname);
            //string sql = "select c_personid,c_name,c_name_chn,c_birthyear,c_deathyear from biog_main where C_NAME_CHN = '李世民'";
            SQLHelper sh = new SQLHelper();
            SqlDataReader sdr;
            try
            {
                sh.RunSQL(sql, out sdr);
                if (sdr.Read())
                {
                    result = string.Format("姓名：{0},生于{1}年", sdr["c_name_chn"].ToString(), sdr["c_birthyear"].ToString());
                }
                else
                {
                    result = "没有找到该记录";
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                Response.Write(result);
                sh.Close();
            }
        }
    }
}