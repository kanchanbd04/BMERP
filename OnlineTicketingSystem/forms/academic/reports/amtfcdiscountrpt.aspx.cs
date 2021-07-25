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
    public partial class amtfcdiscountrpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xclass = Request.QueryString["xclass"].ToString();
                string xstdid = Request.QueryString["xstdid"].ToString();
                string xdistype = Request.QueryString["xdistype"].ToString();
                string xpaytype1 = Request.QueryString["xpaytype"].ToString();
                string xsession = Request.QueryString["xsession"].ToString();

                string xsrow;

                if (xstdid == "")
                {
                    xsrow = "0";
                }
                else
                {
                    xsrow = zglobal.fnGetValue("xrow", "amadmis",
                "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                xstdid + "'");
                }

                if (xdistype == "")
                {
                    xdistype = "All";
                }

                if (xpaytype1 == "Admission Fee")
                {
                    xpaytype1 = "Single";
                }
                else if (xpaytype1 == "Monthly Fee")
                {
                    xpaytype1 = "Monthly";
                }
                else if (xpaytype1 == "Yearly Fee")
                {
                    xpaytype1 = "Yearly";
                }
                else if (xpaytype1 == "Others Fee")
                {
                    xpaytype1 = "N/A";
                }
                else
                {
                    xpaytype1 = "All";
                }


                // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/amtfcdiscount.rpt")); // path of report 
                //crystalReport.Load(zglobal.reportPath + "amtfcdiscount.rpt");
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                crystalReport.SetParameterValue("xclass", xclass);
                crystalReport.SetParameterValue("xsession", xsession);
                crystalReport.SetParameterValue("xdistype", xdistype);
                crystalReport.SetParameterValue("xpaytype", xpaytype1);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;

                PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;
                crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
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