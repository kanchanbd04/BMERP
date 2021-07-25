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
    public partial class pratdmon_emp_late_date1rpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                DateTime fdate = Convert.ToDateTime(Request.QueryString["fdate"].ToString());
                string femp = Request.QueryString["femp"].ToString();
                string temp = Request.QueryString["temp"].ToString();
                string fdep = Request.QueryString["fdep"].ToString();
                string tdep = Request.QueryString["tdep"].ToString();
                string floc = Request.QueryString["floc"].ToString();
                string tloc = Request.QueryString["tloc"].ToString();
                

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
                crystalReport.Load(Server.MapPath("~/reports/pratdmon_emp_late_date1.rpt")); // path of report 
                //crystalReport.Load(zglobal.reportPath + "amtfcactivity.rpt");
                crystalReport.SetParameterValue("zid", zid);
                //crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                crystalReport.SetParameterValue("fdate", fdate);
                crystalReport.SetParameterValue("femp", femp);
                crystalReport.SetParameterValue("temp", temp);
                //crystalReport.SetParameterValue("fdep", fdep);
                //crystalReport.SetParameterValue("tdep", tdep);
                crystalReport.SetParameterValue("floc", floc);
                crystalReport.SetParameterValue("tloc", tloc);
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
                 //   crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
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