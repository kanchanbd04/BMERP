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
    public partial class amtfcdueremain : System.Web.UI.Page
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



                    //string xyear1 = zglobal.fnDefaults("xsession", "Student");
                    //string xyear = xyear1.Substring(0, 4);
                    //string xfdate1 = xdate + "/" + xmonth + "/" + xyear;

                    xfdate.Text = zgetvalue.fnFdate();
                    xtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Location", xlocation);
                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    xsession.Text = zglobal.fnDefaults("xsessionacc", "Student");

                    //xsize.Items.Add("");
                    xsize.Items.Add("Legal");
                    xsize.Items.Add("Letter");
                    xsize.Items.Add("A4");
                    xsize.Text = "A4";

                    xorientation.Items.Add("Landscape");
                    xorientation.Items.Add("Portrait");
                    xorientation.Text = "Landscape";

                    RadioButtonList2.Items.FindByValue("Session Wise").Selected = true;
                    _date.Visible = false;
                    _session.Visible = true;

                    xpaytype.Items.Add("All");
                    xpaytype.Items.Add("Admission Fee");
                    xpaytype.Items.Add("Monthly Fee");
                    xpaytype.Items.Add("Yearly Fee");
                    xpaytype.Items.Add("Others Fee");
                    xpaytype.Text = "All";

                    zglobal.fnReportType(xrtype);

                    
                    for (int i = 1; i <= 12; i++)
                    {
                        xper.Items.Add(i.ToString());
                    }
                    xper.Text = "1";
                }

                xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                       xstdid.Text.ToString().Trim() + "'");
                xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and xcode='" + xtfccode.Text.Trim().ToString() + "'");

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


        protected void RadioButtonList2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                message.InnerText = "";

                if (RadioButtonList2.Items.FindByValue("Session Wise").Selected)
                {
                    _session.Visible = true;
                    _date.Visible = false;
                }
                else
                {
                    _session.Visible = false;
                    _date.Visible = true;
                }


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


    }
}