using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OnlineTicketingSystem.forms.academic.reports
{
    public partial class stdvivalistfinal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xsession1 = Request.QueryString["xsession"].ToString();
                string xclass1 = Request.QueryString["xclass"].ToString();
                string xgroup1 = Request.QueryString["xgroup"].ToString();
                string xnumexam1 = Request.QueryString["xnumexam"].ToString();
                DateTime xvivadate1  = Request.QueryString["xvivadate"].ToString() != string.Empty ? DateTime.ParseExact(Request.QueryString["xvivadate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string xstatus1 = Request.QueryString["xstatus"].ToString();
                if (xstatus1 == "Qualified")
                {
                    xstatus1 = "Approved";
                }
                else if (xstatus1 == "Waiting")
                {
                    xstatus1 = "Waiting";
                }
                else
                {
                    xstatus1 = "undefined";
                }
                //int xrow = Convert.ToInt32(Request.QueryString["xrow"]);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/stdvivalistfinal.rpt")); // path of report 
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xsession", xsession1);
                crystalReport.SetParameterValue("xclass", xclass1);
                crystalReport.SetParameterValue("xgroup", xgroup1);
                crystalReport.SetParameterValue("xnumexam", xnumexam1);
                crystalReport.SetParameterValue("xvivadate", xvivadate1);
                crystalReport.SetParameterValue("xstatus", xstatus1);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;

                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");

                crystalReport.Close();
                crystalReport.Dispose();
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}