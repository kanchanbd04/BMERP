﻿using System;
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
    public partial class stdclasswisenum : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    xsession.Text = zglobal.fnDefaults("xsession", "Student");

                    xtype.Items.Add("All");
                    xtype.Items.Add("New Admission");
                    //xtype.Items.Add("Readmission");
                    //xtype.Items.Add("Promoted");
                    //xtype.Items.Add("Not Promoted");
                    xtype.Text = "All";

                    zglobal.fnReportType(xrtype);
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