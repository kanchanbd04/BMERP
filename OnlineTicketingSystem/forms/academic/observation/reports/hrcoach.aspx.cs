using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CrystalDecisions.ReportAppServer;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class hrcoach : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

            //        //xfdate.Text = zgetvalue.xfdate;
            //        //string xdate = zglobal.fnDefaults("xstdageday", "Student");
            //        //string xmonth = zglobal.fnDefaults("xstdagemonth", "Student");



            //        //string xyear1 = zglobal.fnDefaults("xsession", "Student");
            //        //string xyear = xyear1.Substring(0, 4);
            //        //string xfdate1 = xdate + "/" + xmonth + "/" + xyear;

            //        xfdate.Text = zgetvalue.fnFdate();
            //        xtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            //        zglobal.fnGetComboDataCD("Class", xclass);
            //        zglobal.fnGetComboDataCD("Location", xlocation);

            //        //xsize.Items.Add("");
            //        xsize.Items.Add("Legal");
            //        xsize.Items.Add("Letter");
            //        xsize.Items.Add("A4");
            //        xsize.Text = "Legal";

            //        xorientation.Items.Add("Landscape");
            //        xorientation.Items.Add("Portrait");
            //        xorientation.Text = "Landscape";
                    fnGridValue();
                }

            //    //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
            //    //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
            //    //       xstdid.Text.ToString().Trim() + "'");
            //    xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
            //           "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and xcode='" + xtfccode.Text.Trim().ToString() + "'");

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }




        protected void FillControl(object sender, EventArgs e)
        {
            try
            {

                LinkButton lb = (LinkButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                string xrow12 = GridView2.Rows[rowID].Cells[GridView2.Columns.Count - 1].Text;
                //message.InnerHtml = xrow12;
                //fnFillControl(xrow12);

                message.InnerHtml = "";

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = Convert.ToInt32(xrow12);

                string str = "SELECT  xcoach FROM hrcoachconfighvw where zid=@zid  and xrow=@xrow ";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.Fill(dts, "tempztcode");
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                ViewState["xrow"] = xrow.ToString();
                hiddenxrow.Value = ViewState["xrow"].ToString();

                _coach.Value = dttemp.Rows[0]["xcoach"].ToString();

                fnGridValue();



            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        private void fnGridValue()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT   xrow,xclass,xsubject,xcoach,xname " +

                         "FROM hrcoachconfighvw WHERE zid=@zid  AND zactive=1 " +
                         "order by xrow desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        GridView2.DataSource = tempTable;
                        GridView2.DataBind();
                        if (ViewState["xrow"] != null)
                        {
                            teacher.Visible = true;


                            //GridView1.DataSource = null;
                            //GridView1.DataBind();

                            fnGridValue1();

                            teacherheader.InnerText = "List(s) of Teacher(s) for coach - " +
                                                      tempTable.Select("xcoach='" + _coach.Value.ToString() + "'")[
                                                          0]["xname"].ToString();
                        }
                        else
                        {
                            teacher.Visible = false;
                        }

                        int i = 1;
                        foreach (GridViewRow row in GridView2.Rows)
                        {
                            Label lbl = (Label)row.FindControl("xsl");
                            lbl.Text = i.ToString();
                            i++;
                        }
                    }
                    else
                    {
                        teacher.Visible = false;
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                        ViewState["xrow"] = null;
                    }


                }
            }
        }

        private void fnGridValue1()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT   xrow,xclass,xsubject,xteacher,xname,xline " +
                         "FROM hrcoachconfigdvw WHERE zid=@zid  AND zactive=1 AND xrow=@xrow " +
                         "order by xrow desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));



                    DataTable tempTable1 = new DataTable();
                    da1.Fill(dts1, "tempTable1");
                    tempTable1 = dts1.Tables["tempTable1"];

                    if (tempTable1.Rows.Count > 0)
                    {
                        GridView1.DataSource = tempTable1;
                        GridView1.DataBind();


                        int i = 1;
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            Label lbl = (Label)row.FindControl("xsl");
                            lbl.Text = i.ToString();
                            i++;
                        }
                    }
                    else
                    {
                        //teacher.Visible = false;
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        //ViewState["xrow"] = null;
                    }


                }
            }
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                message.InnerText = "";




            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        protected void btnRefresh_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {

                message.InnerText = "";

                teacher.Visible = false;
                GridView2.DataSource = null;
                GridView2.DataBind();
                ViewState["xrow"] = null;

                fnGridValue();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}