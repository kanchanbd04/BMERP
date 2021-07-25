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
    public partial class amstdindivirpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xsession = Request.QueryString["xsession"].ToString();
                string xclass = Request.QueryString["xclass"].ToString();
                string xgroup = Request.QueryString["xgroup"].ToString();
                string xsection = Request.QueryString["xsection"].ToString();
                string xstdid = Request.QueryString["xstdid"].ToString();
                string xrtype = Request.QueryString["xrtype"].ToString();


                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/amstdindivi.rpt")); // path of report 
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xsession", xsession);
                crystalReport.SetParameterValue("xclass", xclass);
                //crystalReport.SetParameterValue("xgroup", xgroup);
                crystalReport.SetParameterValue("xsection", xsection);
                crystalReport.SetParameterValue("xstdid", xstdid);

                PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;
                crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                //crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                crystalReport.PrintOptions.PaperSize = PaperSize.PaperLegal;
                crystalReport.PrintOptions.ApplyPageMargins(customPageMargin);

                string fileName = "StudentList_" + xsession + "_" + xclass + "_" + DateTime.Today.Date;

                if (xrtype == "MS-Word")
                {
                    crystalReport.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, fileName);
                }
                else if (xrtype == "MS-Excel")
                {
                    crystalReport.ExportToHttpResponse(ExportFormatType.Excel, Response, true, fileName);
                }
                else
                {
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
                }



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