﻿using System;
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
    public partial class rptamtf3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xrow = Request.QueryString["xrow"].ToString();
                //string xtype = Request.QueryString["xtype"].ToString();
                //string xsession = Request.QueryString["xsession"].ToString();
                //string xstdid = Request.QueryString["xstdid"].ToString();
                //string xclass = Request.QueryString["xclass"].ToString();

                //string xsection = zglobal.fnGetValue("xsection", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid + "' and xsession='" + xsession + "'");

                //string xgroup = zglobal.fnGetValue("xgroup", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid + "' and xsession='" + xsession + "'");

                string xtype = zglobal.fnGetValue("xtype", "amtfch",
                "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xrow=" + xrow );

                if (xtype == "")
                {
                    return;
                }

                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                if (xtype == "Tuition Fee")
                {
                    crystalReport.Load(Server.MapPath("~/reports/amtfc1.rpt"));
                }
                else if (xtype == "Seat Conf")
                {
                    crystalReport.Load(Server.MapPath("~/reports/amtfc2.rpt"));
                }
                else if (xtype == "Admission")
                {
                    crystalReport.Load(Server.MapPath("~/reports/amtfc.rpt"));
                }
                 // path of report 
                //crystalReport.Load(zglobal.reportPath + "amtfc1.rpt");
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xrow", xrow);
                crystalReport.SetParameterValue("xtype", xtype);
                //crystalReport.SetParameterValue("xsession", xsession);
                //crystalReport.SetParameterValue("xclass", xclass);
                //crystalReport.SetParameterValue("xsection", xsection);
                //crystalReport.SetParameterValue("xgroup", xgroup);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;

                PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;
                crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                crystalReport.PrintOptions.ApplyPageMargins(customPageMargin);
                
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");


                crystalReport.Close();
                crystalReport.Dispose();
                GC.Collect();
               
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}