using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;
using SQL;
namespace MyProject
{
    public partial class HomeworkDijkstra : System.Web.UI.Page
    {
        private ArrayList nodeList;
        protected void Page_Load(object sender, EventArgs e)
        {
                SQLHelper sh = new SQLHelper();
                DataSet ds = new DataSet();
                string sql = "select  location1 from tblLocation group by location1";                             
                sh.RunSQL(sql, ref ds);
                DataTable dtstart = new DataTable();
                dtstart = ds.Tables[0];

                sql = "select  location2 from tblLocation group by location2";
                ds = null;//清空，重新用一次
                sh.RunSQL(sql, ref ds);
                DataTable dtend = new DataTable();
                dtend = ds.Tables[0];

                if (!this.IsPostBack)
                {
                    ddlStart.DataSource = dtstart;
                    ddlStart.DataTextField = "location1";
                    ddlStart.DataValueField = "location1";
                    ddlStart.DataBind();

                    ddlEnd.DataSource = dtend;
                    ddlEnd.DataTextField = "location2";
                    ddlEnd.DataValueField = "location2";
                    ddlEnd.DataBind();
                }
                nodeList = new ArrayList();//结点的序列
                //***************** A Node 北京 *******************
                foreach (DataRow dr in dtstart.Rows)//遍历所有的起点
                {
                    Node aNode = new Node(dr[0].ToString());//制作顶点
                    nodeList.Add(aNode);
                    DataTable dtedge = new DataTable();
                    sql = "select location2,distance from tblLocation where location1='" + dr[0].ToString() + "'";
                    ds = null;
                    sh.RunSQL(sql, ref ds);
                    dtedge = ds.Tables[0];
                    foreach (DataRow dr2 in dtedge.Rows)//遍历所有的边，执行添加
                    {
                        aNode.EdgeList.Add(new Edge(dr[0].ToString(), dr2[0].ToString(), double.Parse(dr2[1].ToString())));
                        //aNode.EdgeList.Add(new Edge(dr[0].ToString(), "武汉", 40));
                    }
                }
                //为了使最短的路径接受到的数据是完备的，还必须添加，只有入度没有出度的顶点(Node)
                //对于只有入度没有出度的顶点，只添加顶点即可，可以不添加任何边（Edge）
                foreach (DataRow dr in dtend.Rows)
                {                    
                    Node aNode = new Node(dr[0].ToString());
                    if (dtstart.Select("location1='"+dr[0].ToString()+"'").Length <= 0)             //确保该顶点不曾在dtstart中出现过
                    {                         
                            nodeList.Add(aNode);
                    }
             
                }
                sh.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = null;
            result = planner.Paln(nodeList, ddlStart.SelectedValue, ddlEnd.SelectedValue);
            //当路径的权值返回是double的最大值，就认为，两点间的距离是正无穷，也就是不通的
            double aim = Math.Abs(result.getWeight() - double.MaxValue);
            string finalpath = string.Format("{0}到{1}的路径是:", ddlStart.SelectedValue, ddlEnd.SelectedValue);
            Response.Write(finalpath);
            if (aim <= 0)
            {                
                Response.Write("距离为正无穷");
            }
            else
            { 
                Response.Write("距离为" + result.getWeight());
                //输出路径
                printRouteResult(result);
            }                              
            planner = null;
        }
        private void printRouteResult(RoutePlanResult _result)
        {

            string[] tmp = _result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
                Response.Write(tmp[i] + "-->");
            Response.Write(ddlEnd.SelectedValue);
            Response.Write("<br>");

        }
    }
}