using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OnlineTicketingSystem.forms.academic.reports
{
    public partial class stappform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        Int64 xrow1 = Convert.ToInt64(Request.QueryString["xrow"]);
                        string query = "select coalesce(xnumexam,'') from amadmis where zid=@zid and xrow=@xrow";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
                        da.Fill(dts, "tempztcode");
                        DataTable dtexam = new DataTable();
                        dtexam = dts.Tables[0];
                        if (dtexam.Rows.Count > 0)
                        {
                            if (dtexam.Rows[0][0].ToString() == "")
                            {
                                Response.Write("<h1><font color='#FF0000'>Please update 'No. of Exam' before print admit card. </font></h1>");
                                return;
                            }
                        }
                    }
                }

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                Int64 xrow = Convert.ToInt64(Request.QueryString["xrow"]);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/stappform.rpt")); // path of report 
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xrow", xrow);
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