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
    public partial class gladvemp6_salary : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //xfdate.Text = zgetvalue.xfdate;
                    //string xdate = zglobal.fnDefaults("xstdageday", "Student");
                    //string xmonth = zglobal.fnDefaults("xstdagemonth", "Student");
                    fdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    tdate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                    //xtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCDTRN("GL Voucher", ftype);
                    //zglobal.fnGetComboDataCDTRN("GL Voucher", ttype);

                    //xsize.Items.Add("");
                    //xsize.Items.Add("Legal");
                    //xsize.Items.Add("Letter");
                    //xsize.Items.Add("A4");
                    //xsize.Text = "Legal";

                    //xorientation.Items.Add("Landscape");
                    //xorientation.Items.Add("Portrait");
                    //xorientation.Text = "Landscape";

                    //nara.Items.Add("");
                    //nara.Items.Add("No");
                    //nara.Items.Add("Yes");
                    //nara.Text = "Yes";

                    //ob.Items.Add("");
                    //ob.Items.Add("No");
                    //ob.Items.Add("Yes");
                    //ob.Text = "";

                    //drcr.Items.Add("");
                    //drcr.Items.Add("Both");
                    //drcr.Items.Add("Credit");
                    //drcr.Items.Add("Debit");
                    //drcr.Text = "";

                    //led_break_up.Items.Add("");
                    //led_break_up.Items.Add("No");
                    //led_break_up.Items.Add("Yes");
                    //led_break_up.Text = "";

                   // xacc.Text = zglobal.fnGetValue("coalesce(xaccbb,'') as xaccbb", "msdef",
                   //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) );
                }

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       xstdid.Text.ToString().Trim() + "'");

                //xdesc.Text = zglobal.fnGetValue("xdesc", "glmst",
                //   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacc.Text.ToString() +  "'");

                //xdescsub.Text = zglobal.fnGetValue("xdescsub", "glmstvw",
                //  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacc.Text.ToString() + "' " +
                //  "and xsub='"+ xsub.Text.Trim().ToString() +"'");

                xdescfsup.Text = zglobal.fnGetValue("xorg", "mssup",
                      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xsup='" + fsup.Text.ToString().Trim() + "'");

                xdesctsup.Text = zglobal.fnGetValue("xorg", "mssup",
                    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xsup='" + tsup.Text.ToString().Trim() + "'");
                
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