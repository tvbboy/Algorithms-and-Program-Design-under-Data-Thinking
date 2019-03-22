using System;
using System.Web.UI.WebControls;

namespace ProjectHelloworld
{
    public partial class ExamplePrime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//如果网页是第一次打开
            {
                for (int i = 0; i <=20; i++)
                {
                    ListItem a = new ListItem(i.ToString(), i.ToString());
                    ddlStart.Items.Add(a);
                    ddlEnd.Items.Add(a);
                }
            }
        }

        protected void btnPrime_Click(object sender, EventArgs e)
        {

            int start = int.Parse(ddlStart.SelectedItem.Value);
            int end = int.Parse(ddlEnd.SelectedItem.Value);
            if (end < start)
            {
                Response.Write("数值区间不正确");
                return;
            }
            bool isPrime = false;
            Response.Write("找到的素数如下：<br>");
            for (int i = start; i <= end; i++)
            {
                int j = 2;//整除因子从2开始
                isPrime = true;
                while (j <= Math.Sqrt(i))
                {
                    if (i % j == 0)
                        isPrime = false;
                    j++;
                }
                if (isPrime)
                    Response.Write(i + "&nbsp;&nbsp;");
            }

        }

        protected void ddlStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int start = int.Parse(ddlStart.SelectedItem.Value);
            ddlEnd.Items.Clear();
            for (int i = start; i <= 20; i++)
            {
                ListItem a = new ListItem(i.ToString(), i.ToString());               
                ddlEnd.Items.Add(a);
            }
            
        }
    }
}