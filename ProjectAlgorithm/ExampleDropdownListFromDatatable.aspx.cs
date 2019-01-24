using System;
using System.Data;

namespace ProjectAlgorithm
{
    public partial class ExampleDropdownListFromDatatable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //创建数据表格
            DataTable dt = new DataTable("Dynasty");
            //创建列结构
            dt.Columns.Add(new DataColumn("DynastyValue", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("DynastyName", Type.GetType("System.String")));
            //创建数据    
            DataRow dr = dt.NewRow();
            dr["DynastyName"] = "秦";
            dr["DynastyValue"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["DynastyName"] = "汉";
            dr["DynastyValue"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["DynastyName"] = "唐";
            dr["DynastyValue"] = 3;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["DynastyName"] = "宋";
            dr["DynastyValue"] = 4;
            dt.Rows.Add(dr);
            DropDownList1.DataSource = dt;//设置数据源
            DropDownList1.DataTextField = "DynastyName";//设置所要读取的数据表里的列名
            DropDownList1.DataValueField = "DynastyValue";
            DropDownList1.DataBind();//数据绑定

        }
    }
}