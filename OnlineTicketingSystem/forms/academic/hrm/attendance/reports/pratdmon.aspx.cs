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
    public partial class pratdmon : System.Web.UI.Page
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
                    //fdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //tdate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                    //xtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Warehouse", fware);
                    //zglobal.fnGetComboDataCD("Item Group", fgitem);
                    //zglobal.fnGetComboDataCD("Book Category", xlbcatgry);

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

                    fdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    tdate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                    //zglobal.fnGetComboDataCD("Job Department", fdep);
                    //zglobal.fnGetComboDataCD("Job Department", tdep);
                    //zglobal.fnGetComboDataCD("Location", floc);
                    //zglobal.fnGetComboDataCD("Location", tloc);

                }

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       xstdid.Text.ToString().Trim() + "'");

                //xnamemem.Text = zglobal.fnGetValue("xname", "lbmemlistvw",
                //        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xlbmemcode='" + xlbmemcode.Text.ToString().Trim() + "' and xtype='" + hxlbmemtype.Value.Trim().ToString() + "'");

                fname.Text = zglobal.fnGetValue("xname", "hrmst",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xemp='" +
                       femp.Text.ToString().Trim() + "'");

                tname.Text = zglobal.fnGetValue("xname", "hrmst",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xemp='" +
                       temp.Text.ToString().Trim() + "'");
                
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