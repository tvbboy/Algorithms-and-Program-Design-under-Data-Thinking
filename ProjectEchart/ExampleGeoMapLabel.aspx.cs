using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
namespace ProjectEchart
{
    public partial class ExampleGeoMapLabel : System.Web.UI.Page
    {
        
        public DataTable dt;
        public string jsstirng = "";
        public string jsli = "";
       protected void Page_Load(object sender, EventArgs e)
        {
            
            SQLHelper sh = new SQLHelper();
            string sql = "select b.c_name_chn as c_name_chn, c.c_addr_id,c.x_coord as x_coord ,c.y_coord as y_coord from biog_addr_data A,biog_main B,ADDR_CODES c";
            sql+=" where A.c_personid = B.c_personid AND c.c_addr_id = a.c_addr_id and ";
            sql+=" ((b.c_deathyear<=907 and  b.c_birthyear>=618) or (b.c_deathyear>=618 and b.c_birthyear<=618)) and c.x_coord is not null and c.y_coord is not null";
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                dt = ds.Tables[0];
               // personnumber = dt.Rows.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    //  jsstirng += string.Format(@"{name:{0}'', geoCoord:[{1}, {2}]},", dr["c_name_chn"].ToString(), dr["x_coord"].ToString(), dr["y_coord"].ToString());
                   jsstirng += string.Format(@"{{name:'{0}',geoCoord:[{1}, {2}]}},", dr["c_name_chn"].ToString(), dr["x_coord"].ToString(), dr["y_coord"].ToString());
                   if (dr["c_name_chn"].ToString() == "李世民" || dr["c_name_chn"].ToString() == "李淵" || dr["c_name_chn"].ToString() == "李渊")
                    {
                        jsli += string.Format(@"{{name:'{0}',geoCoord:[{1}, {2}]}},", dr["c_name_chn"].ToString(), dr["x_coord"].ToString(), dr["y_coord"].ToString());
                      
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("数据库出错"+ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }
    }
}