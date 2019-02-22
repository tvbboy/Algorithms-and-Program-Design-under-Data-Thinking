using Common.AITools.Tvbboy;
using System;
using System.Collections;

namespace ProjectAlgorithm
{
    public partial class ExampleDijkstraCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList nodeList = new ArrayList();//结点的序列
            //***************** A Node 北京 *******************
            Node aNode = new Node("北京");
            nodeList.Add(aNode);
            aNode.EdgeList.Add(new Edge("北京", "上海", 20));
            aNode.EdgeList.Add(new Edge("北京", "武汉", 40));
            //***************** B Node  上海*******************
            Node bNode = new Node("上海");
            nodeList.Add(bNode);
            bNode.EdgeList.Add(new Edge("上海", "武汉", 70));
            bNode.EdgeList.Add(new Edge("上海", "北京", 20));
            //***************** D Node *******************
            Node dNode = new Node("武汉");
            nodeList.Add(dNode);
            dNode.EdgeList.Add(new Edge("武汉", "上海", 70));
            dNode.EdgeList.Add(new Edge("武汉", "北京", 40));
            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = null;
            //Paln函数是核心函数，首先将所有节点喂给模型，然后输入起点和终点，返回最优路径
            result = planner.Paln(nodeList, "武汉", "上海");
            Response.Write("距离为" + result.getWeight());
            printRouteResult(result);
            Response.Write("上海");
            Response.Write("<br>");
            planner = null;
        }
        private void printRouteResult(RoutePlanResult _result)
        {
            Response.Write("</br>路径:");
            //获取最短路径结果中，所有的节点
            string[] tmp = _result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
                Response.Write(tmp[i] + "-->");
        }

    }
}