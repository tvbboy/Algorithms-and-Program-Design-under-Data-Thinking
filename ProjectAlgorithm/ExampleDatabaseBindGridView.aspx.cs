using SQL;
using System;
using System.Data;

namespace FirstProject
{
    public partial class ExampleDatabaseBindGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           SQLHelper sh = new SQLHelper();
           try
           {
               string sql = "select * from tblStudentsForExercise";
               DataSet ds = new DataSet();
               sh.RunSQL(sql, ref ds);
               DataTable dt = ds.Tables[0];
               GridView1.DataSource = dt;
               GridView1.DataBind();
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