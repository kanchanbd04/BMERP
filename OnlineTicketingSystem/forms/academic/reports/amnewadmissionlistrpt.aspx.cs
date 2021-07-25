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
    public partial class amnewadmissionlistrpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                int zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xclass = Request.QueryString["xclass"].ToString();
                //string xstdid = Request.QueryString["xstdid"].ToString();
                DateTime xfdate = Convert.ToDateTime(Request.QueryString["xfdate"].ToString());
                DateTime xtdate = Convert.ToDateTime(Request.QueryString["xtdate"].ToString());
                //string xbank = Request.QueryString["xbank"].ToString();
                //string xsize = Request.QueryString["xsize"].ToString();
                //string xorientation = Request.QueryString["xorientation"].ToString();
                string xtype = Request.QueryString["xtype"].ToString();
                string xsession = Request.QueryString["xsession"].ToString();
                string xwithdate = Request.QueryString["xwithdate"].ToString();

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

                if(xtype == "New Admission")
                {
                    xtype = "New";
                }
                else if (xtype == "All")
                {
                    xtype = "All";
                }
                else
                {
                    xtype = "Seat Conf";
                }



                //CrystalReportViewer1.ReportSource = null;
                //CrystalReportViewer1.ParameterFieldInfo = null;

                // Response.Write(xfdate + "  " + xtdate);
                ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                //crystalReport.DataSourceConnections.Clear();
                crystalReport.Load(Server.MapPath("~/reports/amnewadmissionlist.rpt")); // path of report 
                //crystalReport.Load(zglobal.reportPath + "amtfcactivity.rpt");
                crystalReport.SetParameterValue("zid", zid);
                //crystalReport.SetParameterValue("xsrow", Convert.ToInt64(xsrow));
                crystalReport.SetParameterValue("xclass", xclass);
                crystalReport.SetParameterValue("xfdate", xfdate);
                crystalReport.SetParameterValue("xtdate", xtdate);
                //crystalReport.SetParameterValue("xbank", xbank);
                crystalReport.SetParameterValue("xtype", xtype);
                crystalReport.SetParameterValue("xsession", xsession);
                crystalReport.SetParameterValue("xwithdate", xwithdate);
                //crystalReport.SetParameterValue("zemail", zemail);
                //crystalReport.SetDataSource(datatable); // binding datatable
                //CrystalReportViewer1.ReportSource = crystalReport;



                //ParameterFields myParams = new ParameterFields();

                //ParameterField myParam = new ParameterField();
                //ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();

                //myParam.ParameterFieldName = "zid";
                //myDiscreteValue.Value = zid;
                //myParam.CurrentValues.Add(myDiscreteValue);
                //myParams.Add(myParam);

                //ParameterField myParam1 = new ParameterField();
                //ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();

                //myParam1.ParameterFieldName = "xclass";
                //myDiscreteValue1.Value = xclass;
                //myParam1.CurrentValues.Add(myDiscreteValue1);
                //myParams.Add(myParam1);

                //ParameterField myParam11 = new ParameterField();
                //ParameterDiscreteValue myDiscreteValue11 = new ParameterDiscreteValue();

                //myParam11.ParameterFieldName = "xfdate";
                //myDiscreteValue11.Value = xfdate;
                //myParam11.CurrentValues.Add(myDiscreteValue11);
                //myParams.Add(myParam11);

                //ParameterField myParam111 = new ParameterField();
                //ParameterDiscreteValue myDiscreteValue111 = new ParameterDiscreteValue();

                //myParam111.ParameterFieldName = "xtdate";
                //myDiscreteValue111.Value = xtdate;
                //myParam111.CurrentValues.Add(myDiscreteValue111);
                //myParams.Add(myParam111);

                //ParameterField myParamSection = new ParameterField();
                //ParameterDiscreteValue myDiscreteValueSection = new ParameterDiscreteValue();

                //myParamSection.ParameterFieldName = "xtype";
                //myDiscreteValueSection.Value = xtype;
                //myParamSection.CurrentValues.Add(myDiscreteValueSection);
                //myParams.Add(myParamSection);

                //CrystalReportViewer1.ParameterFieldInfo = myParams;


                //CrystalReportViewer1.ReportSource = crystalReport;



                PageMargins customPageMargin = crystalReport.PrintOptions.PageMargins;
                crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                crystalReport.PrintOptions.PaperSize = PaperSize.PaperA4;
                crystalReport.PrintOptions.ApplyPageMargins(customPageMargin);

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