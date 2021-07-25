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
    public partial class imledwqtygrp_std : System.Web.UI.Page
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

                    fitem.Text = "0";
                    titem.Text = "z";
                    //xtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Warehouse", fware);
                    zglobal.fnGetComboDataCD("Item Group", fgitem);
                    zglobal.fnGetComboDataCD("Item Group", tgitem);

                    //xsize.Items.Add("");
                    //xsize.Items.Add("Legal");
                    //xsize.Items.Add("Letter");
                    //xsize.Items.Add("A4");
                    //xsize.Text = "Legal";

                    //xorientation.Items.Add("Landscape");
                    //xorientation.Items.Add("Portrait");
                    //xorientation.Text = "Landscape";

                    //narr.Items.Add("");
                    //narr.Items.Add("No");
                    //narr.Items.Add("Yes");
                    //narr.Text = "";

                }

                fitemname.Text = zglobal.fnGetValue("xdesc", "msitem",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xitem='" +
                       fitem.Text.ToString().Trim() + "'");

                titemname.Text = zglobal.fnGetValue("xdesc", "msitem",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xitem='" +
                       titem.Text.ToString().Trim() + "'");

                xnamestd.Text = zglobal.fnGetValue("xname", "amadmis",
                     "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                     xstdid.Text.ToString().Trim() + "'");
                
                
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