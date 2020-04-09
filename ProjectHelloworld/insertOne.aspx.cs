using SQL;
using System;
using System.Text;
using Common.Framework.Tvbboy;
namespace FirstProject
{
    public partial class insertOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = string.Empty;
            SQLHelper sh = new SQLHelper();
            //string colList = "id,birthday,logintimes,username,pwd,gender,deptID,lastLoginTime,dtedate";
            string colList = "birthday,logintimes,username,pwd,gender,lastLoginTime";  //需要插入的字段
            DateTime birthday = DateTime.Parse("2000-6-1");
            int logintimes = 0;
            string username = "tvbgirl";
            string pwd =ClassMd5.Md5Hash32("123456");
            bool gender = true;
            DateTime lastLoginTime = DateTime.Now;
            try
            {
                
                StringBuilder insertSql = new StringBuilder(string.Format("insert into tblStudentsForExercise ({0})",colList));
                insertSql.Append("values(");
                insertSql.Append(string.Format("'{0}'", birthday));//日期值必须使用单引号括起来
                insertSql.Append(",");        //逗号分隔     
                insertSql.Append(string.Format("{0}", logintimes));//数字不需要单引号
                insertSql.Append(",");        //逗号分隔
                insertSql.Append(string.Format("'{0}'", username));
                insertSql.Append(",");       //逗号分隔
                insertSql.Append(string.Format("'{0}'", pwd));
                insertSql.Append(",");       //逗号分隔
                insertSql.Append(string.Format("{0}", gender==true?1:0));
                insertSql.Append(",");       //逗号分隔
                insertSql.Append(string.Format("'{0}'", lastLoginTime));
                insertSql.Append(")");      //逗号分隔
                Response.Write(insertSql);
                int rows = sh.RunSQL(insertSql.ToString());
                if(rows>0)
                    msg = string.Format("插入了{0}个同学信息!", rows);
                else
                    msg = "没有插入";
            }
            catch (Exception ex)
            {
                msg =  "数据库插入发生异常，原因： "+ex.Message;
            }
            finally
            {
                sh.Close();
            }
            Response.Write(msg);
        }
    }
}