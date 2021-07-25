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
    public partial class rptreportcard : System.Web.UI.Page
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



                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        // string query =
                        //"SELECT * FROM amexammaxmarkph3_sum3_gs1 " +
                        //"WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup ";

                        string query =
                      "SELECT * FROM amexamph_sumext_exam " +
                      "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup and xtype in ('Term Exam','Class Test')";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                        //da1.SelectCommand.CommandTimeout = 0;
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];


                        if (dtamexamd.Rows.Count > 0)
                        {
                            //ViewState["amexammaxmarkvw3_sum3_gs1"] = dtamexamd;
                            ViewState["amexamph_sumext_exam"] = dtamexamd;
                        }
                        else
                        {
                            Response.Write("Please generate tabulation sheet.");
                          
                            return;
                            //GridView1.DataSource = null;
                            //GridView1.DataBind();
                        }

                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                       "SELECT * FROM amexamph_sumext_exam2_sub " +
                       "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                        //da1.SelectCommand.CommandTimeout = 0;
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["amexamph_sumext_exam2_sub"] = dtamexamd;
                        }
                        else
                        {
                           Response.Write("Please generate tabulation sheet.");
                            
                            return;
                            //GridView1.DataSource = null;
                            //GridView1.DataBind();
                        }

                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                       "SELECT * FROM amexamph_sumext_exam2_wt1 " +
                       "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                        //da1.SelectCommand.CommandTimeout = 0;
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["amexamph_sumext_exam2_wt1"] = dtamexamd;
                        }
                        else
                        {
                            Response.Write("Please generate tabulation sheet.");
                            
                            return;
                            //GridView1.DataSource = null;
                            //GridView1.DataBind();
                        }

                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                            "select * from amexamhh where zid=@zid and xsession=@xsession and xclass=@xclass  and xgroup=@xgroup and xtype=@xtype and xstatus='Approved'";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup);
                        da1.SelectCommand.Parameters.AddWithValue("@xtype", "Combined");
                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamh = new DataTable();
                        dtamexamh = dts1.Tables[0];

                        if (dtamexamh.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            Response.Write("Tabulation Sheet not yet approved.");
                           
                            return;
                        }

                    }
                }


               
               
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/asreportcard.rpt")); // path of report 
                crystalReport.SetParameterValue("zid", zid);
                crystalReport.SetParameterValue("xsession", xsession);
                crystalReport.SetParameterValue("xterm", xterm);
                crystalReport.SetParameterValue("xclass", xclass);
                crystalReport.SetParameterValue("xgroup", xgroup);
                crystalReport.SetParameterValue("xsection", xsection);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;
                //crystalReport.Refresh();
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ExportedReport");
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}