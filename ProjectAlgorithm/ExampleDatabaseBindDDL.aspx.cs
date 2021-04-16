using SQL;
using System;
using System.Data;

namespace ProjectAlgorithm
{
    //作业输出朝代
    public partial class ExampleDatabaseBindDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            string sql = "select c_dy,c_dynasty_chn from DYNASTIES WHERE c_start<1911 order by c_sort";
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
                        //下面4行代码可以使得下拉列表增加一个默认选项
                        DataRow dr = dt.NewRow();
                        dr["c_dynasty_chn"] = "请选择";
                        dr["c_dy"] = "-1";
                        dt.Rows.Add(dr);
                        ddlDynasties.DataTextField = "c_dynasty_chn";
                        ddlDynasties.DataValueField = "c_dy";
                        ddlDynasties.DataSource = dt;
                        ddlDynasties.DataBind();
                        //下面1行代码可以设置下来列表默认选中的项目
                        ddlDynasties.SelectedIndex = dt.Rows.Count - 1;
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