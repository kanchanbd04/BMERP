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
    public partial class amtfcadvancedrcvrpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xschool = Request.QueryString["xschool"].ToString();
                string xclass = Request.QueryString["xclass"].ToString();
                string xsection = Request.QueryString["xsection"].ToString();
                string xtfccode = Request.QueryString["xtfccode"].ToString();
                //string xstdid = Request.QueryString["xstdid"].ToString();
                DateTime xfdate = Convert.ToDateTime(Request.QueryString["xfdate"].ToString());
                DateTime xtdate = Convert.ToDateTime(Request.QueryString["xtdate"].ToString());
                //string xtype = Request.QueryString["xtype"].ToString();
                string xsize = Request.QueryString["xsize"].ToString();
                string xorientation = Request.QueryString["xorientation"].ToString();
                string xtype1 = Request.QueryString["xtype2"].ToString();
                string xsession1 = Request.QueryString["xsession"].ToString();
                string xstdid1 = Request.QueryString["xstdid"].ToString();
                string xpaytype1 = Request.QueryString["xpaytype"].ToString();

                 xstdid1 = zglobal.fnGetValue("xrow", "amadmis",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xstdid='" +
                        xstdid1 + "'");

                if (xstdid1 == "")
                {
                    xstdid1 = "0";
                }

                Int64 xsrow = Convert.ToInt64(xstdid1);

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

                //if (xtype == "Received")
                //{
                //    xtype = "Received";
                //}
                //else if (xtype == "Receivable")
                //{
                //    xtype = "Receivable";
                //}
                //else
                //{
                //    xtype = "Dues";
                //}

                //if (xtype == "Dues")
                //{
                //    xfdate = new DateTime(2999, 12, 31);
                //    xtdate = new DateTime(2999, 12, 31);
                //}

                //if (xtype == "Special Discount")
                //{
                //    xtype = "Special";
                //}

                //if (xtype == "Net Receivable")
                //{
                //    xtype = "NetRcvbl";
                //}

                // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                //crystalReport.Load(Server.MapPath("~/reports/amtfcduercv.rpt")); // path of report 

                if (xtype1 == "Details")
                {
                    crystalReport.Load(Server.MapPath("~/reports/amtfcadvancedrcv.rpt"));
                    //crystalReport.Load(zglobal.reportPath + "amtfcduercv_details.rpt");
                    crystalReport.SetParameterValue("zid", zid);
                    //crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                    crystalReport.SetParameterValue("xschool", xschool);
                    crystalReport.SetParameterValue("xclass", xclass);
                    crystalReport.SetParameterValue("xtfccode", xtfccode);
                    crystalReport.SetParameterValue("xfdate", xfdate);
                    crystalReport.SetParameterValue("xtdate", xtdate);
                    //crystalReport.SetParameterValue("xtype1", xtype);
                    crystalReport.SetParameterValue("xsession", xsession1);
                    crystalReport.SetParameterValue("xsrow", xsrow);
                    crystalReport.SetParameterValue("xpaytype", xpaytype1);
                }
                //else if (xtype1 == "Details (Studentwise)")
                //{
                //    crystalReport.Load(Server.MapPath("~/reports/ambalancest_details_studentwise.rpt"));
                //    crystalReport.SetParameterValue("xsection", xsection);
                //    //crystalReport.Load(zglobal.reportPath + "amtfcduercv_details.rpt");
                //}
                else
                {
                    crystalReport.Load(Server.MapPath("~/reports/amtfcadvancedrcvsummery.rpt"));
                    xorientation = "Landscape";
                    xsize = "Legal";
                    //crystalReport.Load(zglobal.reportPath + "amtfcduercv_summery.rpt");
                    crystalReport.SetParameterValue("zid", zid);
                    //crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                    //crystalReport.SetParameterValue("xschool", xschool);
                    crystalReport.SetParameterValue("xclass", xclass);
                    //crystalReport.SetParameterValue("xtfccode", xtfccode);
                    //crystalReport.SetParameterValue("xfdate", xfdate);
                    crystalReport.SetParameterValue("xtdate", xtdate);
                    //crystalReport.SetParameterValue("xtype1", xtype);
                    crystalReport.SetParameterValue("xsession", xsession1);
                    //crystalReport.SetParameterValue("xsrow", xsrow);
                    crystalReport.SetParameterValue("xpaytype", xpaytype1);
                }

                //crystalReport.Load(Server.MapPath("~/reports/amtfcadvancedrcv.rpt")); 

                //crystalReport.SetParameterValue("zid", zid);
                ////crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                //crystalReport.SetParameterValue("xschool", xschool);
                //crystalReport.SetParameterValue("xclass", xclass);
                //crystalReport.SetParameterValue("xtfccode", xtfccode);
                //crystalReport.SetParameterValue("xfdate", xfdate);
                //crystalReport.SetParameterValue("xtdate", xtdate);
                ////crystalReport.SetParameterValue("xtype1", xtype);
                //crystalReport.SetParameterValue("xsession", xsession1);
                //crystalReport.SetParameterValue("xsrow", xsrow);
                //crystalReport.SetParameterValue("xpaytype", xpaytype1);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;
                //PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;

                if (xorientation == "Landscape")
                {
                    crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                }
                else
                {
                    crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                }

                if (xsize == "Legal")
                {
                    crystalReport.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
                else if (xsize == "Letter")
                {
                    crystalReport.PrintOptions.PaperSize = PaperSize.PaperLetter;
                }
                else
                {
                    crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                }


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