using System;

namespace ProjectHelloworld
{
    public partial class getDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dayName ="";
            int day = 1;
            switch (day)
            {
                case 0:
                    dayName = "Sunday";
                    break;
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                default:
                    dayName = "休息日";
                    break;
            }
            Response.Write(dayName);

        }
    }
}