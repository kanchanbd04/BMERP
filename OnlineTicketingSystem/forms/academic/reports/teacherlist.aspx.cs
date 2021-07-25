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
    public partial class teacherlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xclass = Request.QueryString["xclass"].ToString();

                
               // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/teacherlist.rpt")); // path of report 
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xclass", xclass);
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