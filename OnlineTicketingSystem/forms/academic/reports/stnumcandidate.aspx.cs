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
    public partial class stnumcandidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //string xfroms = Request.QueryString["xfrom"].ToString();
                //string xtos = Request.QueryString["xto"].ToString();
                string xsession = Request.QueryString["xsession"].ToString();
                //DateTime xfrom = xfroms != string.Empty ? DateTime.ParseExact(xfroms, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime xto = xtos != string.Empty ? DateTime.ParseExact(xtos, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/stnumcandidate.rpt")); // path of report 
                crystalReport.SetParameterValue("zid", zid);
                //crystalReport.SetParameterValue("xfrom", xfrom);
                //crystalReport.SetParameterValue("xto", xto);
                crystalReport.SetParameterValue("xsession", xsession);
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