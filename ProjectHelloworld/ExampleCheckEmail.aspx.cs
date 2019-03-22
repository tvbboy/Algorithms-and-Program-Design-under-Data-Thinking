using System;

namespace ProjectHelloworld
{
    public partial class ExampleCheckEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // string email = "puxiaoming@163.com";
            string email = "pp@.cn";
            string[] dns_list = { "edu", "com", "cn", "org", "net" };
            string[] temp = email.Split('@');
            if (temp.Length != 2)
            {
                Response.Write("@分割错误");
                Response.End();
            }
            else//分割成功
            {
                string name = temp[0]; //获取主机名
                string dns = temp[1];//获取域名
                if (name.Length < 6)
                {
                    Response.Write("主机名长度不正确");
                    Response.End();
                }
                string[] temp_dns = dns.Split('.'); //对域名再次分割
                if (temp_dns.Length < 2)
                {
                    Response.Write("域名格式不正确");
                    Response.End();
                }
                else
                {
                    string top_dns;
                    top_dns = temp_dns[temp_dns.Length - 1].ToLower();
                    //获取顶级域名，顶级域名位于最右边
                    bool found_top_dns = false;
                    //默认列表中找不到顶级域名
                    foreach (string t in dns_list)
                    {
                        if (t == top_dns)
                        {
                            found_top_dns = true;
                        }
                    }
                    if (found_top_dns)
                    {
                        Response.Write("Email:"+ email + "格式正确,顶级域名是:"+ top_dns);
                        Response.End();
                    }
                    else
                    {
                        Response.Write("顶级域名"+ top_dns + "不在规定的列表中");
                        Response.End();
                    }
                }
            }

        }
    }
}