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
    public partial class amdropoutrpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xclass = Request.QueryString["xclass"].ToString();
                string xsession = Request.QueryString["xsession"].ToString();
                //string xstdid = Request.QueryString["xstdid"].ToString();
                DateTime xfdate = Convert.ToDateTime(Request.QueryString["xfdate"].ToString());
                DateTime xtdate = Convert.ToDateTime(Request.QueryString["xtdate"].ToString());
                //string xbank = Request.QueryString["xbank"].ToString();
                //string xsize = Request.QueryString["xsize"].ToString();
                //string xorientation = Request.QueryString["xorientation"].ToString();

                //string xsrow;

                //if (xstdid == "")
                //{
                //    xsrow = "0";
                //}
                //else
                //{
                //    xsrow = zglobal.fnGetValue("xrow", "amadmis",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid + "'");
                //}

               // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/amdropout.rpt")); // path of report 
                crystalReport.SetParameterValue("zid", zid);
                //crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                crystalReport.SetParameterValue("xclass", xclass);
                crystalReport.SetParameterValue("xsession", xsession);
                crystalReport.SetParameterValue("xfdate", xfdate);
                crystalReport.SetParameterValue("xtdate", xtdate);
                //crystalReport.SetParameterValue("xbank", xbank);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;

                //PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;

                //if (xorientation == "Landscape")
                //{
                //    crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                //}
                //else
                //{
                //    crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                //}

                //if (xsize == "Legal")
                //{
                //    crystalReport.PrintOptions.PaperSize = PaperSize.PaperLegal;
                //}
                //else if (xsize == "Letter")
                //{
                //    crystalReport.PrintOptions.PaperSize = PaperSize.PaperLetter;
                //}
                //else
                //{
                //    crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                //}


                //crystalReport.PrintOptions.ApplyPageMargins(customPageMargin);

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