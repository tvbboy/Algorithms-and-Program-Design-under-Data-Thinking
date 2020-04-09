using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
namespace FirstProject
{
    public partial class testDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnTest_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            SQLHelper sh = new SQLHelper();
            try
            {
               string sql="select count(*) from tblstudents";
               string num=sh.RunSelectSQLToScalar(sql);
               msg = string.Format("我们班共有{0}个同学!",num);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally {
                sh.Close();
            }
            Response.Write(msg);
        }
    }
}