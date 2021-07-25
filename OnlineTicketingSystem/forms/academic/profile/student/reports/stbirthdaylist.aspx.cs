using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CrystalDecisions.ReportAppServer;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class stbirthdaylist : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    zglobal.fnGetComboDataCD("Session", xsession);
                  


                    zglobal.fnGetComboDataCD("Class", xclass);
                    xclass.Items.Add("All");
                    xclass.Text = "All";


                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    xsection.Items.Add("All");
                    xsection.Text = "All";

                    xsession.Text = zglobal.fnDefaults("xsessionacc", "Student");

                    //xtype.Items.Add("All");
                    //xtype.Items.Add("New Admission");
                    //xtype.Items.Add("Readmission");
                    //xtype.Items.Add("Promoted");
                    //xtype.Items.Add("Not Promoted");
                    //xtype.Text = "All";

                    //xtype.Items.Add("All");
                    //xtype.Items.Add("New Admission");
                    //xtype.Items.Add("Readmission");
                    //xtype.Items.Add("Not Readmitted");
                    //xtype.Items.Add("Promoted");
                    //xtype.Items.Add("Not Promoted");
                    //xtype.Items.Add("Qualified for Admission");
                    //xtype.Items.Add("Not Admitted");
                    ////xtype.Items.Add("Promoted");
                    ////xtype.Items.Add("Not Promoted");
                    ////xtype.Items.Add("All With Promoted");
                    ////xtype.Items.Add("All Without Promoted");
                    //xtype.Text = "All";

                    //zglobal.fnReportType(xrtype);
                    xfdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }

                
                
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }





        
        

       

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                message.InnerText = "";

                


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

       
        

       
    }
}