using Common.AITools.Tvbboy;
using System;
using System.Data;
using System.Web.UI.WebControls;
namespace ProjectAlgorithm
{
    public partial class ExampleNaiveBayesSymptom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)//如果第一次打开网页
            {
                ListItem li1 = new ListItem("打喷嚏", "1");
                ListItem li2 = new ListItem("头痛", "2");
                ListItem li3 = new ListItem("护士", "1");
                ListItem li4 = new ListItem("农夫", "2");
                ListItem li5 = new ListItem("建筑工人", "3");
                ListItem li6 = new ListItem("教师", "4");
                ddlSymptom.Items.Add(li1);
                ddlSymptom.Items.Add(li2);
                ddlJob.Items.Add(li3);
                ddlJob.Items.Add(li4);
                ddlJob.Items.Add(li5);
                ddlJob.Items.Add(li6);
            }
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            double Symptom = double.Parse(ddlSymptom.SelectedValue);
            double Job = double.Parse(ddlJob.SelectedValue);            
            /*
             打喷嚏--1
             * 头痛--2
             * 
             * 护士--1
             * 农夫--2
             * 建筑工人--3
             * 教师--4
             */
            //training data
            DataTable table = new DataTable();
            table.Columns.Add("disease");
            table.Columns.Add("symptom", typeof(double));
            table.Columns.Add("job", typeof(double));
                       
            table.Rows.Add("感冒", 1, 1);
            table.Rows.Add("过敏", 1, 2);
            table.Rows.Add("脑震荡", 2, 3);
            table.Rows.Add("感冒", 2, 3);
            table.Rows.Add("感冒", 1, 4);
            table.Rows.Add("脑震荡", 2, 4);
            ClassNaiveBayes classifier = new ClassNaiveBayes();
            classifier.TrainClassifier(table);
            Response.Write(classifier.Classify(new double[] { Symptom, Job }));//新来了打喷嚏的建筑工人，问可能得什么病
        }
    }
}