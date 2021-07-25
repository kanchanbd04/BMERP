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
    public partial class lbissudailym2rpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //string fware = Request.QueryString["fware"].ToString();
                //string fgitem = Request.QueryString["fgitem"].ToString();
                DateTime fdate = Convert.ToDateTime(Request.QueryString["fdate"].ToString());
                DateTime tdate = Convert.ToDateTime(Request.QueryString["tdate"].ToString());
                string xdesc02 = Request.QueryString["xdesc02"].ToString();
                //DateTime xtdate = Convert.ToDateTime(Request.QueryString["xtdate"].ToString());
                //string xlbcatgry1 = Request.QueryString["xlbcatgry"].ToString();
                //string xsize = Request.QueryString["xsize"].ToString();
                //string xorientation = Request.QueryString["xorientation"].ToString();
                //string xtype = Request.QueryString["xtype"].ToString();

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

                //if (xtype == "All Collection")
                //{
                //    xtype = "All";
                //}
                //else
                //{
                //    xtype = "My";
                //}

                // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/lbissudailym2.rpt")); // path of report 
                //crystalReport.Load(zglobal.reportPath + "amtfcactivity.rpt");
                crystalReport.SetParameterValue("zid", zid);
                //crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                crystalReport.SetParameterValue("fdate", fdate);
                crystalReport.SetParameterValue("tdate", tdate);
                crystalReport.SetParameterValue("xdesc02", xdesc02);
                //crystalReport.SetParameterValue("fware", fware);
                //crystalReport.SetParameterValue("fgitem", fgitem);
                //crystalReport.SetParameterValue("bookcate", xlbcatgry1);
                //crystalReport.SetParameterValue("xtype", xtype);
                //crystalReport.SetParameterValue("zemail", zemail);
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