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
    public partial class lbbooktyperpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string booktype = Request.QueryString["booktype"].ToString();
                string xdesc02 = Request.QueryString["xdesc02"].ToString();
                //string xterm = Request.QueryString["xterm"].ToString();
              
                //string xsession = Request.QueryString["xsession"].ToString();

                //string xsrow;

               

               // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/lbbooktype.rpt")); // path of report 
                //crystalReport.Load(zglobal.reportPath + "amtfcadmitcard.rpt");
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("booktype", booktype);
                crystalReport.SetParameterValue("xdesc02", xdesc02);
                //crystalReport.SetParameterValue("xterm", xterm);
                //crystalReport.SetParameterValue("xclass", xclass);
                //crystalReport.SetParameterValue("xsession", xsession);
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