using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OnlineTicketingSystem.forms.academic.reports
{
    public partial class amtfctranrpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xtfccode = Request.QueryString["xtfccode"].ToString();
                string xstdid = Request.QueryString["xstdid"].ToString();
                DateTime xfdate = Convert.ToDateTime(Request.QueryString["xfdate"].ToString());
                DateTime xtdate = Convert.ToDateTime(Request.QueryString["xtdate"].ToString());
                string xsession = Request.QueryString["xsession"].ToString();
                string xtype = Request.QueryString["xtype"].ToString();

                string xsrow = zglobal.fnGetValue("xrow", "amadmis",
                "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                xstdid + "'");

                if (xtype == "Collection")
                {
                    xtype = "Received";
                }
                else
                {
                    xtype = "Due";
                }

               // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/amtfctran.rpt")); // path of report 
                //crystalReport.Load(zglobal.reportPath + "amtfctran.rpt");
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                crystalReport.SetParameterValue("xtfccode", xtfccode);
                crystalReport.SetParameterValue("xfdate", xfdate);
                crystalReport.SetParameterValue("xtdate", xtdate);
                crystalReport.SetParameterValue("xtype1", xtype);
                crystalReport.SetParameterValue("xsession", xsession);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;
                PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;
                crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                crystalReport.PrintOptions.ApplyPageMargins(customPageMargin);

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