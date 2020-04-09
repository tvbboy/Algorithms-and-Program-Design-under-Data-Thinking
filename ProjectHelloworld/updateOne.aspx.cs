using SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProject
{
    public partial class updateOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = string.Empty;
            SQLHelper sh = new SQLHelper();
            DateTime birthday = DateTime.Parse("2010-6-1");
            string username = "tvbgirl";
            bool gender = false;
            DateTime lastLoginTime = DateTime.Now;
            try
            {
                StringBuilder updateSql = new StringBuilder("update tblStudentsForExercise set ");
                updateSql.Append("lastLoginTime=getdate()");
                updateSql.Append(",");
                updateSql.Append("logintimes=logintimes+1");
                updateSql.Append(",");
                updateSql.Append(string.Format("gender={0}",gender==true?1:0));
                updateSql.Append(",");
                updateSql.Append(string.Format("birthday='{0}'",birthday));

                updateSql.Append(string.Format(" where username='{0}'",username)); //condition,where前要有空格
                Response.Write(updateSql);
                int rows = sh.RunSQL(updateSql.ToString());
                if(rows>0)
                    msg = string.Format("更新了{0}个同学!", rows);
                else
                    msg = "没有更新";
            }
            catch (Exception ex)
            {
                msg =  "更新发生异常，原因： "+ex.Message;
            }
            finally
            {
                sh.Close();
            }
            Response.Write(msg);
        }
    }
}