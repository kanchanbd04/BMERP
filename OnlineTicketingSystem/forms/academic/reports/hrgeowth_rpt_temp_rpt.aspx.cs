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
    public partial class hrgeowth_rpt_temp_rpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xrow = Request.QueryString["xrow"].ToString();
                string xtype = Request.QueryString["xtype"].ToString();


                if (xtype == "hod")
                {
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    //crystalReport.DataSourceConnections.Clear();
                    crystalReport.Load(Server.MapPath("~/reports/hrgrowth_report_template_hod.rpt")); // path of report 
                    crystalReport.SetParameterValue("zid", zid);
                    crystalReport.SetParameterValue("xrow", xrow);
                    //crystalReport.SetDataSource(datatable); // binding datatable
                    //CrystalReportViewer1.ReportSource = crystalReport;

                    //PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;
                    crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                    //crystalReport.PrintOptions.ApplyPageMargins(customPageMargin);

                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false,
                        "ExportedReport");

                    crystalReport.Close();
                    crystalReport.Dispose();

                }
                else
                {
                    ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                    //crystalReport.DataSourceConnections.Clear();
                    crystalReport.Load(Server.MapPath("~/reports/hrgrowth_report_template.rpt")); // path of report 
                    crystalReport.SetParameterValue("zid", zid);
                    crystalReport.SetParameterValue("xrow", xrow);
                    //crystalReport.SetDataSource(datatable); // binding datatable
                    //CrystalReportViewer1.ReportSource = crystalReport;

                    //PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;
                    crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                    //crystalReport.PrintOptions.ApplyPageMargins(customPageMargin);

                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false,
                        "ExportedReport");


                    crystalReport.Close();
                    crystalReport.Dispose();

                }

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}