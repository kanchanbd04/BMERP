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
    public partial class rptstdasgradeanalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xsession = Request.QueryString["xsession"].ToString();
                string xterm = Request.QueryString["xterm"].ToString();
                string xclass = Request.QueryString["xclass"].ToString();
                string xgroup = Request.QueryString["xgroup"].ToString();
                string xsection = Request.QueryString["xsection"].ToString();





                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                if (xterm.ToLower() == "avg")
                {
                    crystalReport.Load(Server.MapPath("~/reports/asstdgradeanalysisavg.rpt"));
                }
                else
                {
                    crystalReport.Load(Server.MapPath("~/reports/asstdgradeanalysis.rpt")); // path of report 
                    crystalReport.SetParameterValue("xterm", xterm);
                }
            
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xsession", xsession);
                
                crystalReport.SetParameterValue("xclass", xclass);
                crystalReport.SetParameterValue("xgroup", xgroup);
                crystalReport.SetParameterValue("xsection", xsection);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;

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