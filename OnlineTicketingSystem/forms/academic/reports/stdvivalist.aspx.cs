using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OnlineTicketingSystem.forms.academic.reports
{
    public partial class stdvivalist : System.Web.UI.Page
    {
        private int zid = 0;
        private string xtype = "";
        private string xsession = "";
        private string xclass = "";
        private string xgroup = "";
        private string xnumexam = "";
        private string xschofor1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Session", xsession_res);
                    zglobal.fnGetComboDataCD("Class", xclass_res);
                    zglobal.fnGetComboDataCD("Education Group", xgroup_res);

                    xnumexam_res.Items.Clear();
                    xnumexam_res.Items.Add("");
                    xnumexam_res.Items.Add("1st");
                    xnumexam_res.Items.Add("2nd");
                    xnumexam_res.Items.Add("3rd");
                    xnumexam_res.Items.Add("4th");
                    xnumexam_res.Items.Add("5th");
                    xnumexam_res.Items.Add("6th");
                    xnumexam_res.Items.Add("7th");
                    xnumexam_res.Items.Add("8th");
                    xnumexam_res.Items.Add("9th");
                    xnumexam_res.Items.Add("10th");
                    xnumexam_res.Text = "";

                    xprintlistfor.Items.Clear();
                    xprintlistfor.Items.Add("");
                    xprintlistfor.Items.Add("Qualified");
                    xprintlistfor.Items.Add("Waiting");
                    xprintlistfor.Text = "";

                    zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    xtype = Request.QueryString["xtype"].ToString();
                    xsession = Request.QueryString["xsession"].ToString();
                    xclass = Request.QueryString["xclass"].ToString();
                    xgroup = Request.QueryString["xgroup"].ToString();
                    xnumexam = Request.QueryString["xnumexam"].ToString();
                    xschofor1 = Request.QueryString["xschfor"].ToString();

                    xsession_res.Text = xsession;
                    xclass_res.Text = xclass;
                    xgroup_res.Text = xgroup;
                    xnumexam_res.Text = xnumexam;
                    xprintlistfor.Text = xschofor1;



                }


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }


        protected void fnPrintList(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xsession1 = xsession_res.Text.Trim().ToString();
                string xclass1 = xclass_res.Text.Trim().ToString();
                string xgroup1 = xgroup_res.Text.Trim().ToString();
                string xnumexam1 = xnumexam_res.Text.Trim().ToString();
                string xstatus2 = xprintlistfor.Text.Trim().ToString();
                xtype = Request.QueryString["xtype"].ToString();
                DateTime xvivadate1 = xvivadate.Text.Trim() != string.Empty ? DateTime.ParseExact(xvivadate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (xstatus2 == "Qualified")
                {
                    xstatus2 = "Approved";
                }
                else if (xstatus2 == "Waiting")
                {
                    xstatus2 = "Waiting";
                }
                else
                {
                    xstatus2 = "";
                }
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();

                crystalReport.Load(Server.MapPath("~/reports/stdvivalist.rpt")); // path of report 
                crystalReport.Refresh();
                crystalReport.SetParameterValue("zid", _zid);
                crystalReport.SetParameterValue("xsession", xsession1);
                crystalReport.SetParameterValue("xclass", xclass1);
                crystalReport.SetParameterValue("xgroup", xgroup1);
                crystalReport.SetParameterValue("xnumexam", xnumexam1);
                crystalReport.SetParameterValue("xstatus", xstatus2);
                crystalReport.SetParameterValue("xvivadate", xvivadate1);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;
                string fileName = "Result_" + xsession1 + "_" + xclass1 + "_" + xgroup1 + "_" + xnumexam1 + "_" + DateTime.Now;
                if (xtype == "excel")
                {
                    crystalReport.ExportToHttpResponse(ExportFormatType.Excel, Response, true, fileName);
                }
                else if (xtype == "word")
                {
                    crystalReport.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, fileName);
                }
                else
                {
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, fileName);
                }

                crystalReport.Close();
                crystalReport.Dispose();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }
    }
}