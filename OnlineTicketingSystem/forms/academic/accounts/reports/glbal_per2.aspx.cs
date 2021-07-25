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
    public partial class glbal_per2 : System.Web.UI.Page
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
                    //nara.Text = "";

                    //ob.Items.Add("");
                    ob.Items.Add("No");
                    ob.Items.Add("Yes");
                    ob.Text = "No";

                    //drcr.Items.Add("");
                    //drcr.Items.Add("Both");
                    //drcr.Items.Add("Credit");
                    //drcr.Items.Add("Debit");
                    //drcr.Text = "";

                    //led_break_up.Items.Add("");
                    //led_break_up.Items.Add("No");
                    //led_break_up.Items.Add("Yes");
                    //led_break_up.Text = "";

                    type.Items.Add("Summary");
                    type.Items.Add("Detail");
                    type.Text = "Summery";

                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    int offset;
                    int per;
                    int year = DateTime.Now.Year;
                    int tempyear;

                    offset = zglobal.fnGetValueInt("xinteger", "msstatus",
                    "zid=" + _zid + " and xtypestatus='GL Period Offset'");

                    per = 12 + DateTime.Now.Month - offset;

                    if (per <= 12)
                    {
                        tempyear = year - 1;
                    }
                    else
                    {
                        tempyear = year;
                    }

                    xyear.Text = tempyear.ToString();
                }

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       xstdid.Text.ToString().Trim() + "'");

                //xdesc.Text = zglobal.fnGetValue("xdesc", "glmst",
                //   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacc.Text.ToString() +  "'");

                //xdescsub.Text = zglobal.fnGetValue("xdescsub", "glmstvw",
                //  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacc.Text.ToString() + "' " +
                //  "and xsub='"+ xsub.Text.Trim().ToString() +"'");
                
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