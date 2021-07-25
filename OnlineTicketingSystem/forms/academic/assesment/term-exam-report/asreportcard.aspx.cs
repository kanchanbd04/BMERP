using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Transactions;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;
using System.Web.Services;
using System.Web.UI.HtmlControls;

namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class asreportcard : System.Web.UI.Page
    {


        string zid;
        string zorg;
        string ctlid;
        string rowid;
        object row;
        private string q_val;
        private string filter;


        public void fnFillDataGrid(object sender, EventArgs e)
        {
            try
            {
                //message.InnerHtml = "";
                //BindGrid();

                message.InnerHtml = "";
                int zid1 = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                string xsession1 = xsession.Text.Trim().ToString();
                string xterm1 = xterm.Text.Trim().ToString();
                string xclass1 = xclass.Text.Trim().ToString();
                string xgroup1 = xgroup.Text.Trim().ToString();
                string xsection1 = xsection.Text.Trim().ToString();

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
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
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
                            message.InnerHtml = ("Please generate tabulation sheet.");

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
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
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
                            message.InnerHtml = ("Please generate tabulation sheet.");

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
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
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
                            message.InnerHtml = ("Please generate tabulation sheet.");

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
                        da1.SelectCommand.Parameters.AddWithValue("@zid", zid1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
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
                           message.InnerHtml = ("Tabulation Sheet not yet approved.");

                            return;
                        }

                    }
                }

            


                report.Attributes.Add("src", "/forms/academic/reports/rptreportcardoffline.aspx?zid=" + zid1 + "&xsession=" + xsession1 + "&xterm=" + xterm1 + "&xclass=" + xclass1 + "&xgroup=" + xgroup1 + "&xsection=" + xsection1);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable dtsec;
        //private int check = 0;
        List<string> listsec = new List<string>();
        List<string> listperiod = new List<string>();
        List<int> listmaxnum = new List<int>();
        List<int> listtest = new List<int>();
        List<int> listretest = new List<int>();
        List<string> listtrow = new List<string>();
        List<string> listmaxrtcount = new List<string>();
        List<string> listretestrow = new List<string>();
        List<string> listsubject = new List<string>();
        List<string> listpaper = new List<string>();
        private void BindGrid()
        {

            ////if (ViewState["ispostback"].ToString() == "yes")
            ////{
            ////    ViewState["ispostback"] = "no";
            ////    return;
            ////}


            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //ViewState["xrow"] = null;

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        string query =
            //       "SELECT * FROM amexammaxmarkph3_sum3_gs1 " +
            //       "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup ";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //        //da1.SelectCommand.CommandTimeout = 0;
            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];


            //        if (dtamexamd.Rows.Count > 0)
            //        {
            //            ViewState["amexammaxmarkvw3_sum3_gs1"] = dtamexamd;
            //        }
            //        else
            //        {
            //            message.InnerHtml = "Please generate tabulation sheet.";
            //            message.Style.Value = zglobal.warningmsg;
            //            if (GridView1.DataSource != null)
            //            {
            //                GridView1.DataSource = null;
            //                GridView1.DataBind();
            //            }
            //            return;
            //            //GridView1.DataSource = null;
            //            //GridView1.DataBind();
            //        }

            //    }
            //}

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        string query =
            //       "SELECT * FROM amexammaxmarkph3_sum6 " +
            //       "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup ";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //        //da1.SelectCommand.CommandTimeout = 0;
            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];
            //        if (dtamexamd.Rows.Count > 0)
            //        {
            //            ViewState["amexammaxmarkvw3_sum6"] = dtamexamd;
            //        }
            //        else
            //        {
            //            message.InnerHtml = "Please generate tabulation sheet.";
            //            message.Style.Value = zglobal.warningmsg;
            //            if (GridView1.DataSource != null)
            //            {
            //                GridView1.DataSource = null;
            //                GridView1.DataBind();
            //            }
            //            return;
                       
            //        }

            //    }
            //}

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            //        //string query =
            //        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            //        string query =
            //            "select * from amexamhh where zid=@zid and xsession=@xsession and xclass=@xclass  and xgroup=@xgroup and xtype=@xtype and xstatus='Approved'";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xtype", "Combined");
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamh = new DataTable();
            //        dtamexamh = dts1.Tables[0];

            //        if (dtamexamh.Rows.Count > 0)
            //        {
                        
            //        }
            //        else
            //        {
            //            message.InnerHtml = "Tabulation Sheet not yet approved.";
            //            message.Style.Value = zglobal.warningmsg;
            //            if (GridView1.DataSource != null)
            //            {
            //                GridView1.DataSource = null;
            //                GridView1.DataBind();
            //            }
            //            return;
            //        }

            //    }
            //}



            ////string xrow = zglobal.fnGetValue("xrow", "amexamh",
            ////     "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
            ////     "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xsubject='" + xsubject.Text.Trim().ToString() + "' and xpaper='" + xpaper.Text.Trim().ToString() + "'" + " and xstatus in('Approved2','Approved3')");
            //////if (ViewState["xrow"] == null)
            ////if (xrow == "")
            ////{
            ////    message.InnerHtml = "No data found.";
            ////    message.Style.Value = zglobal.am_warningmsg;
            ////    dxstatus.Visible = false;
            ////    dxstatus.Text = "Status : ";
            ////    dxstatus.Style.Value = zglobal.am_submited;
            ////    return;
            ////}




            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();
            //string xsession1 = xsession.Text.Trim().ToString();
            //string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            ////string xsection1 = xsection.Text.Trim().ToString();
            ////message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            ////return;
            //string str = "";

            ////if (xsection.Text == "All")
            ////{
            ////    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup  ORDER BY xstdid";
            ////}
            ////else
            ////{
            ////    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";
            ////}

            //if (xsection.Text == "All")
            //{
            //    str = "select zid, xsession,xterm,xclass,xgroup,xsection,xrow,xname,xstdid,xcodealt,xexam,(xname + '<br/>' + xstdid) as xnmid from amstdgs,amexamname  " +
            //          "WHERE amstdgs.zid=@zid AND amstdgs.xsession=@xsession  AND amstdgs.xclass=@xclass AND amstdgs.xgroup=@xgroup " +
            //          "order by xname,xcodealt ";

            //}
            //else
            //{
            //    str = "select zid, xsession,xterm,xclass,xgroup,xsection,xrow,xname,xstdid,xcodealt,xexam,(xname + '<br/>' + xstdid) as xnmid from amstdgs,amexamname  " +
            //          "WHERE amstdgs.zid=@zid AND amstdgs.xsession=@xsession  AND amstdgs.xclass=@xclass AND amstdgs.xgroup=@xgroup AND amstdgs.xsection=@xsection " +
            //          "order by xname,xcodealt ";
            //}

            ////string str = "SELECT ROW_NUMBER() OVER (ORDER BY xcttype desc, xctno asc) AS xid,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            ////    "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper order by xstdid";


            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            ////da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            ////da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //da.Fill(dts, "tempztcode");
            //DataTable dtmarks = new DataTable();
            //dtmarks = dts.Tables[0];

            //if (dtmarks.Rows.Count > 0)
            //{

            //    GridView1.Columns.Clear();

            //    TemplateField tfield119 = new TemplateField();
            //    tfield119.HeaderText = "No.";
            //    tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield119.ItemStyle.Width = 30;
            //    GridView1.Columns.Add(tfield119);

            //    //bfield = new BoundField();
            //    //bfield.HeaderText = "No.";
            //    ////bfield.ShowHeader = false;
            //    //bfield.DataField = "xid";
            //    //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //bfield.ItemStyle.Width = 35;
            //    //bfield.HtmlEncode = false;
            //    //GridView1.Columns.Add(bfield);

            //    //bfield = new BoundField();
            //    //bfield.HeaderText = "ID";
            //    ////bfield.ShowHeader = false;
            //    //bfield.DataField = "xstdid";
            //    //bfield.ItemStyle.Width = 50;
            //    //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //bfield.HtmlEncode = false;
            //    //GridView1.Columns.Add(bfield);

            //    bfield = new BoundField();
            //    bfield.HeaderText = "Student's Name";
            //    //bfield.ShowHeader = false;
            //    bfield.DataField = "xnmid";
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    bfield.ItemStyle.Width = 150;
            //    bfield.HeaderStyle.Width = 150;
            //    bfield.HtmlEncode = false;
            //    GridView1.Columns.Add(bfield);

            //    bfield = new BoundField();
            //    bfield.HeaderText = "Term";
            //    bfield.DataField = "xterm";
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    bfield.ItemStyle.Width = 20;
            //    bfield.HtmlEncode = false;
            //    GridView1.Columns.Add(bfield);

            //    bfield = new BoundField();
            //    bfield.HeaderText = "";
            //    bfield.DataField = "xexam";
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    bfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
            //    bfield.ItemStyle.Width = 50;
            //    bfield.HtmlEncode = false;
            //    GridView1.Columns.Add(bfield);


            //    //Generating coloum for all subject
            //    using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    {
            //        //string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xcttype asc, xctno asc";
            //        string query = "SELECT distinct xsubject FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //                       "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup ORDER BY xsubject";


            //        SqlCommand cmd = new SqlCommand(query, con);
            //        cmd.Parameters.AddWithValue("@zid", _zid);
            //        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        cmd.CommandType = CommandType.Text;
            //        con.Open();
            //        SqlDataReader rdr = cmd.ExecuteReader();
            //        int rowCount = 0;
            //        listtest.Clear();
            //        listtrow.Clear();
            //        listretest.Clear();
            //        listsubject.Clear();
            //        listpaper.Clear();

            //        int test_count = 0;

            //        //int cnt = 0;
            //        while (rdr.Read())
            //        {
            //            tfield = new TemplateField();
            //            tfield.HeaderText = rdr["xsubject"].ToString();
            //            tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //            tfield.ItemStyle.Width = 40;
            //            tfield.HeaderStyle.Width = 40;
            //            GridView1.Columns.Add(tfield);

            //            tfield = new TemplateField();
            //            tfield.HeaderText = "";
            //            tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //            tfield.ItemStyle.Width = 35;
            //            tfield.HeaderStyle.Width = 35;
            //            tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
            //            GridView1.Columns.Add(tfield);

            //            tfield = new TemplateField();
            //            tfield.HeaderText = "";
            //            tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //            tfield.ItemStyle.Width = 20;
            //            tfield.HeaderStyle.Width = 20;
            //            tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
            //            GridView1.Columns.Add(tfield);

            //            test_count = test_count + 3;
            //            listtest.Add(test_count);
            //            //listtrow.Add(rdr["xrow"].ToString());
            //            listsubject.Add(rdr["xsubject"].ToString());
            //            //listpaper.Add(rdr["xpaper"].ToString());
            //            //listtrow.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
            //            rowCount = rowCount + 3;
            //        }

            //        if (test_count == 0)
            //        {
            //            listtest.Add(test_count);
            //        }

            //        ViewState["listretest"] = listretest;
            //        ViewState["listtest"] = listtest;
            //        ViewState["listtrow"] = listtrow;
            //        ViewState["rowCount"] = rowCount;
            //        ViewState["xsubject"] = listsubject;
            //        //ViewState["xpaper"] = listpaper;
            //    }






            //    using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    {
            //        using (DataSet dts1 = new DataSet())
            //        {
            //            string query = "SELECT * FROM amexamhhd1 WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Combined'   ";

            //            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
            //            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.Trim().ToString());
            //            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
            //            da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.Trim().ToString());


            //            da1.Fill(dts1, "tempztcode");
            //            DataTable dtamexamd = new DataTable();
            //            dtamexamd = dts1.Tables[0];
            //            if (dtamexamd.Rows.Count > 0)
            //            {
            //                ViewState["amexamhhd1"] = dtamexamd;
            //            }
            //            else
            //            {
            //                ViewState["amexamhhd1"] = null;
            //            }
            //        }
            //    }

               


            //    //TemplateField tfield13 = new TemplateField();
            //    //tfield13.HeaderText = "C";
            //    //tfield13.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield13.ItemStyle.Width = 20;
            //    //tfield13.HeaderStyle.Width = 20;
            //    //GridView1.Columns.Add(tfield13);

            //    TemplateField tfield2 = new TemplateField();
            //    tfield2.HeaderText = "";
            //    tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    GridView1.Columns.Add(tfield2);

            //    //BoundField bfield1 = new BoundField();
            //    //bfield1.DataField = "xsubject";
            //    //GridView1.Columns.Add(bfield1);

            //    //BoundField bfield2 = new BoundField();
            //    //bfield2.DataField = "xpaper";
            //    //GridView1.Columns.Add(bfield2);

            //    BoundField bfield1 = new BoundField();
            //    bfield1.DataField = "xrow";
            //    GridView1.Columns.Add(bfield1);

            //    BoundField bfield2 = new BoundField();
            //    bfield2.DataField = "xsection";
            //    GridView1.Columns.Add(bfield2);

            //    GridView1.DataSource = dtmarks;
            //    GridView1.DataBind();

            //    //bfield1.Visible = false;
            //    //bfield2.Visible = false;
            //    bfield1.ItemStyle.CssClass = "hiddencol";
            //    bfield1.HeaderStyle.CssClass = "hiddencol";
            //    bfield2.ItemStyle.CssClass = "hiddencol";
            //    bfield2.HeaderStyle.CssClass = "hiddencol";

            //    //int i = 1;
            //    //foreach (GridViewRow row in GridView1.Rows)
            //    //{
            //    //    Label lbl = (Label)row.FindControl("lblno");
            //    //    lbl.Text = i.ToString();
            //    //    i++;
            //    //}


            //}
            //else
            //{
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //}
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (GridView1.DataSource == null)
            //    {
            //        return;
            //    }

            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //    for (int i = 4; i < 4 + (int)ViewState["rowCount"]; i = i + 3)
            //    {
            //        GridView1.HeaderRow.Cells[i].ColumnSpan = 3;
            //        GridView1.HeaderRow.Cells[i + 1].Visible = false;
            //        GridView1.HeaderRow.Cells[i + 2].Visible = false;
            //    }




            //    using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    {
            //        using (DataSet dts1 = new DataSet())
            //        {
            //            string query;
            //            if (xsection.Text == "All")
            //            {
            //                query = "select distinct xterm from amexamh  " +
            //                      "WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup ";

            //            }
            //            else
            //            {
            //                query = "select distinct xterm from amexamh  " +
            //                      "WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ";
            //            }

            //            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());

            //            da1.Fill(dts1, "tempztcode");
            //            DataTable dtxtermcount = new DataTable();
            //            dtxtermcount = dts1.Tables[0];

            //            if (dtxtermcount.Rows.Count > 0)
            //            {
            //                query = "select * from amexamname  ";

            //                SqlDataAdapter da2 = new SqlDataAdapter(query, con);


            //                da2.Fill(dts1, "tempztcode1");
            //                DataTable dtamexamname = new DataTable();
            //                dtamexamname = dts1.Tables["tempztcode1"];

            //                int rowIndex = 0;
            //                int rowno = 1;
            //                while (rowIndex < GridView1.Rows.Count)
            //                {
            //                    GridViewRow gvRow = GridView1.Rows[rowIndex];
            //                    //gvRow.BorderStyle=BorderStyle.Solid;
            //                    //gvRow.BorderColor=Color.Black;
            //                    //gvRow.BorderWidth = Unit.Pixel(3);
            //                    if (rowIndex != 0)
            //                    {
            //                        gvRow.CssClass = "BorderRow";
            //                    }

            //                    gvRow.Cells[1].RowSpan = dtxtermcount.Rows.Count * dtamexamname.Rows.Count;
            //                    gvRow.Cells[0].RowSpan = dtxtermcount.Rows.Count * dtamexamname.Rows.Count;


            //                    for (int i = 1; i < dtxtermcount.Rows.Count * dtamexamname.Rows.Count; i++)
            //                    {
            //                        GridView1.Rows[rowIndex + i].Cells[1].Visible = false;
            //                        GridView1.Rows[rowIndex + i].Cells[0].Visible = false;
            //                    }

            //                    Label lbl = (Label)gvRow.FindControl("lblno");
            //                    lbl.Text = rowno.ToString();

            //                    rowno = rowno + 1;
            //                    rowIndex = rowIndex + dtxtermcount.Rows.Count * dtamexamname.Rows.Count;
            //                }

            //                int rowIndex1 = 0;
            //                while (rowIndex1 < GridView1.Rows.Count)
            //                {
            //                    GridViewRow gvRow = GridView1.Rows[rowIndex1];

            //                    gvRow.Cells[2].RowSpan = dtamexamname.Rows.Count;
            //                    gvRow.Cells[4 + (int)ViewState["rowCount"]].RowSpan = dtamexamname.Rows.Count;

            //                    for (int i = 1; i < dtamexamname.Rows.Count; i++)
            //                    {
            //                        GridView1.Rows[rowIndex1 + i].Cells[2].Visible = false;
            //                        GridView1.Rows[rowIndex1 + i].Cells[4 + (int)ViewState["rowCount"]].Visible = false;
            //                    }

            //                    rowIndex1 = rowIndex1 + dtamexamname.Rows.Count;
            //                }

            //                rowIndex1 = 0;
            //                while (rowIndex1 < GridView1.Rows.Count)
            //                {
            //                    GridViewRow gvRow = GridView1.Rows[rowIndex1];

            //                    for (int i = 4; i < 4 + (int)ViewState["rowCount"]; i = i + 3)
            //                    {
            //                        gvRow.Cells[i + 2].RowSpan = dtamexamname.Rows.Count;


            //                        for (int j = 1; j < dtamexamname.Rows.Count; j++)
            //                        {
            //                            GridView1.Rows[rowIndex1 + j].Cells[i + 2].Visible = false;

            //                        }
            //                    }

            //                    rowIndex1 = rowIndex1 + dtamexamname.Rows.Count;
            //                }

            //            }



            //        }
            //    }


            //    ////for merging retest column
            //    //int k = 3;
            //    //foreach (int data in (List<int>)ViewState["listretest"])
            //    //{
            //    //    if (data != 0)
            //    //    {
            //    //        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = data;
            //    //        for (int m = 2; m <= data; m++)
            //    //        {
            //    //            GridView1.HeaderRow.Cells[k + m].Visible = false;
            //    //        }
            //    //        k = k + data + 1;
            //    //    }
            //    //    else
            //    //    {
            //    //        k = k + 1;
            //    //    }

            //    //}


            //    //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            //    //TableHeaderCell cell = new TableHeaderCell();

            //    //GridView1.HeaderRow.Cells[0].Visible = false;
            //    //GridView1.HeaderRow.Cells[1].Visible = false;
            //    //GridView1.HeaderRow.Cells[2].Visible = false;


            //    //cell = new TableHeaderCell();
            //    //cell.Text = "No.";
            //    //cell.RowSpan = 2;
            //    //row.Controls.Add(cell);

            //    //cell = new TableHeaderCell();
            //    //cell.Text = "ID";
            //    //cell.RowSpan = 2;
            //    //row.Controls.Add(cell);

            //    //cell = new TableHeaderCell();
            //    //cell.Text = "Student's Name";
            //    //cell.RowSpan = 2;
            //    //row.Controls.Add(cell);

            //    ////GridView1.Rows[0].Cells[0].RowSpan = 2;
            //    ////GridView1.Rows[0].Cells[1].RowSpan = 2;
            //    ////GridView1.Rows[0].Cells[2].RowSpan = 2;
            //    //int i = 0;
            //    //foreach (string date in (List<string>)ViewState["listtest"])
            //    //{
            //    //    cell = new TableHeaderCell();
            //    //    cell.ColumnSpan = ((List<int>)ViewState["listretest"])[i] + 1;
            //    //    cell.Text = date;
            //    //    cell.BorderStyle = BorderStyle.Solid;
            //    //    cell.BorderWidth = 2;
            //    //    cell.BorderColor = Color.White;
            //    //    row.Controls.Add(cell);

            //    //    i = i + 1;
            //    //}


            //    //cell = new TableHeaderCell();
            //    //row.Controls.Add(cell);
            //    //// row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            //    //GridView1.HeaderRow.Parent.Controls.AddAt(0, row);




            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}

        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{

            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {

            //        Label lblno = new Label();
            //        lblno.Text = "";
            //        lblno.ID = "lblno";
            //        lblno.Attributes.Add("runat", "server");
            //        e.Row.Cells[0].Controls.Add(lblno);
            //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //        //    List<string> list_t_row = (List<string>)ViewState["listtrow"];
            //        //    int retestcount = 0;
            //        //    string xrefcttype1 = "";
            //        //    string xrefctno1 = "";
            //        int k = 0;
            //        for (int i = 4; i < 4 + (int)ViewState["rowCount"]; i = i + 3)
            //        {

            //            Label lblperc = new Label();
            //            lblperc.Text = "";
            //            lblperc.ID = "lblperc" + i.ToString();
            //            lblperc.ForeColor = Color.Black;
            //            lblperc.Attributes.Add("runat", "server");
            //            e.Row.Cells[i].Controls.Add(lblperc);

            //            Label lblmarks = new Label();
            //            lblmarks.Text = "";
            //            lblmarks.ID = "lblmarks" + i.ToString();
            //            lblmarks.ForeColor = Color.Black;
            //            lblmarks.Attributes.Add("runat", "server");
            //            e.Row.Cells[i + 1].Controls.Add(lblmarks);

            //            Label lblgrade = new Label();
            //            lblgrade.Text = "";
            //            lblgrade.ID = "lblgrade" + i.ToString();
            //            lblgrade.ForeColor = Color.Black;
            //            lblgrade.Attributes.Add("runat", "server");
            //            e.Row.Cells[i + 2].Controls.Add(lblgrade);

            //            //message.InnerHtml = (e.Row.DataItem as DataRowView).Row["xrow"].ToString();
            //            // message.InnerHtml = ((List<string>)ViewState["xsubject"])[k].ToString();
            //            Int64 xsrow = Convert.ToInt64((e.Row.DataItem as DataRowView).Row["xrow"].ToString());
            //            DataRow[] result;
            //            DataRow[] result1;
            //            if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() != "Total")
            //            {
            //                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
            //                {
            //                    result =
            //                        ((DataTable)ViewState["amexammaxmarkvw3_sum3_gs1"]).Select("zid=" + _zid + " and xterm='" +
            //                        (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
            //                       ((List<string>)ViewState["xsubject"])[k].ToString() + "' and xtype='Term Exam'");
            //                }
            //                else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
            //                {
            //                    result =
            //                        ((DataTable)ViewState["amexammaxmarkvw3_sum3_gs1"]).Select("zid=" + _zid + " and xterm='" +
            //                        (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
            //                       ((List<string>)ViewState["xsubject"])[k].ToString() + "' and xtype='Term Exam'");
            //                }
            //                else
            //                {
            //                    result =
            //                       ((DataTable)ViewState["amexammaxmarkvw3_sum3_gs1"]).Select("zid=" + _zid + " and xterm='" +
            //                       (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
            //                      ((List<string>)ViewState["xsubject"])[k].ToString() + "' and xtype='Class Test'");
            //                }
            //            }
            //            else
            //            {
            //                result =
            //                   ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
            //                                                             (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
            //                                                             xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");
            //            }

            //            result1 =
            //                  ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
            //                                                            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
            //                                                            xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");

            //            if (result.Length > 0)
            //            {
            //                //message.InnerHtml = message.InnerHtml + result[0]["xnetmark"].ToString() + "<br/>";
            //                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
            //                {
            //                    lblmarks.Text = Convert.ToDecimal(result[0]["xgetmark"].ToString()).ToString("####");
            //                }
            //                else
            //                {
            //                    lblmarks.Text = Convert.ToDecimal(result[0]["xnetmark"].ToString()).ToString("####");
            //                }

            //                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "CT" ||
            //                    (e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
            //                {
            //                    lblperc.Text = Convert.ToDecimal(result[0]["xperc"].ToString()).ToString("####") + "%";
            //                }


            //                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
            //                {
            //                    //lblgrade.Text = result[0]["xgrade"].ToString();
            //                    lblperc.Text = "%";
            //                }




            //            }

            //            if (result1.Length > 0)
            //            {
            //                lblgrade.Text = result1[0]["xgrade"].ToString();
            //                //lblperc.Text = "%";
            //            }


            //            k = k + 1;

            //        }



                    


            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void gvTheGrid_PreRender(object sender, EventArgs e)
        {


            //if (GridView1.Rows.Count > 0)
            //{
            //    //This replaces <td> with <th> and adds the scope attribute
            //    GridView1.UseAccessibleHeader = true;

            //    //This will add the <thead> and <tbody> elements
            //    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //    //This adds the <tfoot> element. 
            //    //Remove if you don't have a footer row
            //    GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
            //}
        }


        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                //System.Threading.Thread.Sleep(1000);
                message.InnerHtml = "";

               // //using (SqlConnection connRowConnection = new SqlConnection(zglobal.constring))
               // //{
               // //    using (DataSet dtsRowDataSet = new DataSet())
               // //    {
               // //        string query = "SELECT xrow FROM amexamschh WHERE xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND zid=@zid";

               // //        // return query;
               // //        SqlDataAdapter daRowValueAdapter = new SqlDataAdapter(query, connRowConnection);
               // //        daRowValueAdapter.SelectCommand.Parameters.AddWithValue("@xrow", row);
               // //        daRowValueAdapter.Fill(dtsRowDataSet, "tempTable");
               // //        DataTable tempTableRowDataTable = new DataTable();
               // //        tempTableRowDataTable = dtsRowDataSet.Tables["tempTable"];

               // //        value = tempTableRowDataTable.Rows[0][0].ToString();

               // //        daRowValueAdapter.Dispose();
               // //        dtsRowDataSet.Clear();
               // //        tempTableRowDataTable.Dispose();
               // //    }
               // //}
               // int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
               // string xsession1 = xsession.Text.Trim().ToString();
               // string xterm1 = xterm.Text.Trim().ToString();
               // string xclass1 = xclass.Text.Trim().ToString();
               // string xgroup1 = xgroup.Text.Trim().ToString();
               // int xyear = 1999;
               // int xmonth = 1;
               // if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
               // {
               //     xyear = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
               //     xmonth = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());
               // }
               // string xrow = zglobal.fnGetValue("xrow", "amexamschh",
               //     "zid=" + _zid + " and xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xclass='" + xclass1 +
               //     "' and xgroup='" + xgroup1 + "' and xyear=" + xyear + " and xmonth=" + xmonth);
               // string xstatus = zglobal.fnGetValue("xstatus", "amexamschh",
               //     "zid=" + _zid + " and xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xclass='" + xclass1 +
               //     "' and xgroup='" + xgroup1 + "'and xyear=" + xyear + " and xmonth=" + xmonth); 

               // if (xrow == "")
               // {
               //     ViewState["xrow"] = null;
               //     hiddenxrow.Value = null;
               //     hiddenxstatus.Value = null;
               // }
               // else
               // {
               //     ViewState["xrow"] = xrow;
               //     hiddenxrow.Value = xrow;
               //     hiddenxstatus.Value = xstatus;
               // }


               // if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
               // {
               //     //int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
               //     //int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

               //     //BindGrid(year, month);
               //     hiddenxdate.Value = xdate.SelectedValue.ToString();
               // }
               // else
               // {
               //     //BindGrid(1999, 1);
               //     //GridView1.DataSource = null;
               //     //GridView1.DataBind();
               //     hiddenxdate.Value = new DateTime(1999, 1, 1).ToString();
               // }

               // //GridView1.DataSource = null;
               // //GridView1.DataBind();
               // //xdate.Text = "";
               //// BindGrid(1999, 1);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        protected void combo1_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

               // BindGrid(1999, 1);

                if (ViewState["xrow"] == null)
                {
                    message.InnerHtml = "No data found.";
                    message.Style.Value = zglobal.am_warningmsg;
                    return;
                }


                //hiddenxdate.Value = xdate.SelectedValue.ToString();


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                
                fnFillDataGrid(null,null);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            //    //////Check Permission
            //    ////SiteMaster sm = new SiteMaster();
            //    ////string s = sm.fnChkPagePermis("ztpermis");
            //    ////if (s == "n" || s == "e")
            //    ////{
            //    ////    HttpContext.Current.Session["curuser"] = null;
            //    ////    Session.Abandon();
            //    ////    Response.Redirect("~/forms/zlogin.aspx");
            //    ////}


            //    //pagew = Request.QueryString["page"];
            //    //if (pagew == "user")
            //    //{
            //    //    curuser = Request.QueryString["xuser"];
            //    //    xuser.InnerHtml = "User : " + curuser;
            //    //}
            //    //else
            //    //{
            //    //    curuser = Request.QueryString["xrole"];
            //    //    xuser.InnerHtml = "Role : " + curuser;
            //    //}

                //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                if (!IsPostBack)
                {
                   // //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                   // ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                   // //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                   // ctlid_v.Value = ctlid;
                   //// Response.Write(ctlid_v.Value);
                    _gridrow.Text = zglobal._grid_row_value;

                    //xfrom.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //xto.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //fnFillDataGrid(null,null);
                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                   
                    //ViewState["ispostback"] = "yes";
                    
                }

                //BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }


        [WebMethod(EnableSession = true)]
        public static string fnGetStatus(string xsession1, string xterm1, string xclass1, string xgroup1, string xsection1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {

                        string query =
                            "select * from amstdatdh where zid=@zid and xsession=@xsession and xterm=@xterm and xclass=@xclass  and xgroup=@xgroup " +
                            "and xsection=@xsection and xstatus='Submited'";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamh = new DataTable();
                        dtamexamh = dts1.Tables[0];

                        if (dtamexamh.Rows.Count > 0)
                        {
                            return "success";
                        }
                        else
                        {
                            return "fail";
                        }

                    }
                }



            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }
 


     

       


        
    }
}