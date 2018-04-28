using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data.SqlClient;
using System.Data;

namespace ProjectAlgorithm
{
    //作业输出朝代
    public partial class ExersizeDatabaseReadList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            string sql = "select c_dy,c_dynasty_chn from DYNASTIES order by c_sort";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                if (ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ddlDynasties.DataTextField = "c_dynasty_chn";
                        ddlDynasties.DataValueField = "c_dy";
                        ddlDynasties.DataSource = dt;
                        ddlDynasties.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }
    }
}