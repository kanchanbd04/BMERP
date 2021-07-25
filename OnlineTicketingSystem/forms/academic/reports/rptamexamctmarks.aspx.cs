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
    public partial class rptamexamctmarks : System.Web.UI.Page
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
                string xsubject = Request.QueryString["xsubject"].ToString();
                string xpaper = Request.QueryString["xpaper"].ToString();

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT * FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper and xstatus in('Approved3')";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass);
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm);
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup);
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection);
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject);
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        if (dtamexamd.Rows.Count > 0)
                        {
                            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                            //crystalReport.DataSourceConnections.Clear();
                            crystalReport.Load(Server.MapPath("~/reports/amexamctmarks.rpt")); // path of report 
                            crystalReport.SetParameterValue("zid", zid);
                            crystalReport.SetParameterValue("xsession", xsession);
                            crystalReport.SetParameterValue("xterm", xterm);
                            crystalReport.SetParameterValue("xclass", xclass);
                            crystalReport.SetParameterValue("xgroup", xgroup);
                            crystalReport.SetParameterValue("xsection", xsection);
                            crystalReport.SetParameterValue("xsubject", xsubject);
                            crystalReport.SetParameterValue("xpaper", xpaper);
                            //crystalReport.SetDataSource(datatable); // binding datatable
                            //CrystalReportViewer1.ReportSource = crystalReport;

                            crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");

                            crystalReport.Close();
                            crystalReport.Dispose();
                        }
                        else
                        {
                            Response.Write("Please approve all class test before print.");
                        }

                    }
                }

               
                
               
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}