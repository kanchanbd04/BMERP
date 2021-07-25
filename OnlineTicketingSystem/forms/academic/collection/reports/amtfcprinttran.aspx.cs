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
    public partial class amtfcprinttran : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ////xfdate.Text = zgetvalue.xfdate;
                    ////string xdate = zglobal.fnDefaults("xstdageday", "Student");
                    ////string xmonth = zglobal.fnDefaults("xstdagemonth", "Student");
                    ////xfdate.Text = zgetvalue.fnFdate();

                    ////xtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    ////zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    ////zglobal.fnGetComboDataCD("Term", xterm);
                    //xsession.Text = zglobal.fnDefaults("xsessionacc", "Student");
                    ////xterm.Text = zglobal.fnDefaults("xterm", "Student");

                }

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       xstdid.Text.ToString().Trim() + "'");


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