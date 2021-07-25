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
using System.IO;
using System.Transactions;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class amexamhh3 : System.Web.UI.Page
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
                message.InnerHtml = "";
                BindGrid();


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

            if (ViewState["ispostback"].ToString() == "yes")
            {
                ViewState["ispostback"] = "no";
                return;
            }


            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ViewState["xrow"] = null;

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    // string query =
                    //"SELECT * FROM amexammaxmarkph3_sum3_gs1 " +
                    //"WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup ";

                    string query =
                  "SELECT * FROM amexamph_sumext_exam " +
                  "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup and xtype in ('Term Exam','Class Test') ";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
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
                        message.InnerHtml = "Please generate tabulation sheet.";
                        message.Style.Value = zglobal.warningmsg;
                        if (GridView1.DataSource != null)
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
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
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
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
                        message.InnerHtml = "Please generate tabulation sheet.";
                        message.Style.Value = zglobal.warningmsg;
                        if (GridView1.DataSource != null)
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
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
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
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
                        message.InnerHtml = "Please generate tabulation sheet.";
                        message.Style.Value = zglobal.warningmsg;
                        if (GridView1.DataSource != null)
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                        return;
                        //GridView1.DataSource = null;
                        //GridView1.DataBind();
                    }

                }
            }



            //string xrow = zglobal.fnGetValue("xrow", "amexamh",
            //     "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
            //     "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xsubject='" + xsubject.Text.Trim().ToString() + "' and xpaper='" + xpaper.Text.Trim().ToString() + "'" + " and xstatus in('Approved2','Approved3')");
            ////if (ViewState["xrow"] == null)
            //if (xrow == "")
            //{
            //    message.InnerHtml = "No data found.";
            //    message.Style.Value = zglobal.am_warningmsg;
            //    dxstatus.Visible = false;
            //    dxstatus.Text = "Status : ";
            //    dxstatus.Style.Value = zglobal.am_submited;
            //    return;
            //}




            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string xsession1 = xsession.Text.Trim().ToString();
            string xclass1 = xclass.Text.Trim().ToString();
            string xgroup1 = xgroup.Text.Trim().ToString();
            //string xsection1 = xsection.Text.Trim().ToString();
            //message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            //return;
            string str = "";

            //if (xsection.Text == "All")
            //{
            //    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup  ORDER BY xstdid";
            //}
            //else
            //{
            //    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";
            //}

            if (xsection.Text == "All")
            {
                str = "select zid, xsession,xterm,xclass,xgroup,xsection,xrow,xname,xstdid,xcodealt,xexam,(xname + '<br/>' + xstdid) as xnmid from amstdgs1,amexamname  " +
                      "WHERE amstdgs1.zid=@zid AND amstdgs1.xsession=@xsession  AND amstdgs1.xclass=@xclass AND amstdgs1.xgroup=@xgroup and xtype in ('Term Exam','Class Test') " +
                      "and xterm in (select xcode from mscodesam where zid=amstdgs1.zid and xtype='Term' and xcodealt<=(select xcodealt from mscodesam where zid=amstdgs1.zid and xtype='Term' and xcode=@xterm)) " +
                      "order by xname,xcodealt,xserial ";

            }
            else
            {
                str = "select zid, xsession,xterm,xclass,xgroup,xsection,xrow,xname,xstdid,xcodealt,xexam,(xname + '<br/>' + xstdid) as xnmid from amstdgs1,amexamname  " +
                      "WHERE amstdgs1.zid=@zid AND amstdgs1.xsession=@xsession  AND amstdgs1.xclass=@xclass AND amstdgs1.xgroup=@xgroup AND amstdgs1.xsection=@xsection and xtype in ('Term Exam','Class Test') " +
                      "and xterm in (select xcode from mscodesam where zid=amstdgs1.zid and xtype='Term' and xcodealt<=(select xcodealt from mscodesam where zid=amstdgs1.zid and xtype='Term' and xcode=@xterm)) " +
                      "order by xname,xcodealt,xserial ";
            }


            //if (xsection.Text == "All")
            //{
            //    str = "select zid, xsession,xterm,xclass,xgroup,xsection,xrow,xname,xstdid,xcodealt,xexam,(xname + '<br/>' + xstdid) as xnmid from amtabu  " +
            //          "WHERE amtabu.zid=@zid AND amtabu.xsession=@xsession  AND amtabu.xclass=@xclass AND amtabu.xgroup=@xgroup  " +
            //          "order by xname,xcodealt,xserial ";

            //}
            //else
            //{
            //    str = "select zid, xsession,xterm,xclass,xgroup,xsection,xrow,xname,xstdid,xcodealt,xexam,(xname + '<br/>' + xstdid) as xnmid from amtabu  " +
            //        "WHERE amtabu.zid=@zid AND amtabu.xsession=@xsession  AND amtabu.xclass=@xclass AND amtabu.xgroup=@xgroup and amtabu.xsection=@xsection " +
            //        "order by xname,xcodealt,xserial ";
            //}

            //string str = "SELECT ROW_NUMBER() OVER (ORDER BY xcttype desc, xctno asc) AS xid,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //    "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper order by xstdid";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {

                GridView1.Columns.Clear();

                TemplateField tfield119 = new TemplateField();
                tfield119.HeaderText = "No.";
                tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield119.ItemStyle.Width = 30;
                GridView1.Columns.Add(tfield119);

                //bfield = new BoundField();
                //bfield.HeaderText = "No.";
                ////bfield.ShowHeader = false;
                //bfield.DataField = "xid";
                //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //bfield.ItemStyle.Width = 35;
                //bfield.HtmlEncode = false;
                //GridView1.Columns.Add(bfield);

                //bfield = new BoundField();
                //bfield.HeaderText = "ID";
                ////bfield.ShowHeader = false;
                //bfield.DataField = "xstdid";
                //bfield.ItemStyle.Width = 50;
                //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //bfield.HtmlEncode = false;
                //GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Student's Name";
                //bfield.ShowHeader = false;
                bfield.DataField = "xnmid";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.ItemStyle.Width = 150;
                bfield.HeaderStyle.Width = 150;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Term";
                bfield.DataField = "xterm";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.ItemStyle.Width = 20;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "";
                bfield.DataField = "xexam";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                bfield.ItemStyle.Width = 50;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);


                List<int> listcolspan = new List<int>();
                listcolspan.Clear();
                int colspan = 0;
                //Generating coloum for all subject
                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    //string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xcttype asc, xctno asc";
                    string query = "SELECT distinct xsubject,xpaper FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                                   "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup ORDER BY xsubject,xpaper";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int rowCount = 0;
                    listtest.Clear();
                    listtrow.Clear();
                    listretest.Clear();
                    listsubject.Clear();
                    listpaper.Clear();

                    int test_count = 0;

                    int cnt = 0;
                    string xsub = "";
                    string xsubtemp = "";

                    while (rdr.Read())
                    {
                        xsubtemp = rdr["xsubject"].ToString();
                        if (cnt == 0)
                        {
                            xsub = rdr["xsubject"].ToString();
                        }

                        if (xsub != xsubtemp)
                        {

                            tfield = new TemplateField();
                            tfield.HeaderText = "G";
                            tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            tfield.ItemStyle.Width = 20;
                            tfield.HeaderStyle.Width = 20;
                            tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#D6E3B5");
                            GridView1.Columns.Add(tfield);

                            xsub = rdr["xsubject"].ToString();
                            test_count = test_count + 3;
                            rowCount = rowCount + 3;
                            listsubject.Add("");
                            listsubject.Add(rdr["xsubject"].ToString());
                            listsubject.Add(rdr["xsubject"].ToString());

                            listcolspan.Add(colspan + 1);
                            // listcolspan.Add(1);
                            colspan = 2;
                        }
                        else
                        {
                            test_count = test_count + 2;
                            rowCount = rowCount + 2;
                            listsubject.Add(rdr["xsubject"].ToString());
                            listsubject.Add(rdr["xsubject"].ToString());
                            colspan = colspan + 2;
                        }


                        tfield = new TemplateField();
                        tfield.HeaderText = rdr["xpaper"].ToString();
                        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        tfield.ItemStyle.Width = 40;
                        tfield.HeaderStyle.Width = 40;
                        GridView1.Columns.Add(tfield);

                        tfield = new TemplateField();
                        tfield.HeaderText = "";
                        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        tfield.ItemStyle.Width = 35;
                        tfield.HeaderStyle.Width = 35;
                        tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                        GridView1.Columns.Add(tfield);

                        //tfield = new TemplateField();
                        //tfield.HeaderText = "";
                        //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //tfield.ItemStyle.Width = 20;
                        //tfield.HeaderStyle.Width = 20;
                        //tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                        //GridView1.Columns.Add(tfield);



                        //test_count = test_count + 2;
                        listtest.Add(test_count);
                        //listtrow.Add(rdr["xrow"].ToString());
                        //listsubject.Add(rdr["xsubject"].ToString());
                        listpaper.Add(rdr["xpaper"].ToString());
                        //listtrow.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                        //rowCount = rowCount + 2;
                        cnt = cnt + 1;
                    }

                    tfield = new TemplateField();
                    tfield.HeaderText = "G";
                    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield.ItemStyle.Width = 20;
                    tfield.HeaderStyle.Width = 20;
                    tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#D6E3B5");
                    GridView1.Columns.Add(tfield);

                    listcolspan.Add(colspan);
                    //listcolspan.Add(1);

                    if (test_count == 0)
                    {
                        listtest.Add(test_count);
                    }

                    ViewState["listretest"] = listretest;
                    ViewState["listtest"] = listtest;
                    ViewState["listtrow"] = listtrow;
                    ViewState["rowCount"] = rowCount;
                    ViewState["xsubject"] = listsubject;
                    ViewState["xpaper"] = listpaper;
                    ViewState["colspan"] = listcolspan;
                }






                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT * FROM amexamhhd1 WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass  AND xgroup=@xgroup AND xtype='Combined'   ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.Trim().ToString());
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.Trim().ToString());


                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["amexamhhd1"] = dtamexamd;
                        }
                        else
                        {
                            ViewState["amexamhhd1"] = null;
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
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
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
                            ViewState["amexamhh4"] = dtamexamh;
                        }
                        else
                        {
                            ViewState["amexamhh4"] = null;
                        }

                    }
                }


                TemplateField tfield13 = new TemplateField();
                tfield13.HeaderText = "C";
                tfield13.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield13.ItemStyle.Width = 20;
                tfield13.HeaderStyle.Width = 20;
                GridView1.Columns.Add(tfield13);

                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield2);

                //BoundField bfield1 = new BoundField();
                //bfield1.DataField = "xsubject";
                //GridView1.Columns.Add(bfield1);

                //BoundField bfield2 = new BoundField();
                //bfield2.DataField = "xpaper";
                //GridView1.Columns.Add(bfield2);

                BoundField bfield1 = new BoundField();
                bfield1.DataField = "xrow";
                GridView1.Columns.Add(bfield1);

                BoundField bfield2 = new BoundField();
                bfield2.DataField = "xsection";
                GridView1.Columns.Add(bfield2);

                BoundField bfield3 = new BoundField();
                bfield3.DataField = "xname";
                GridView1.Columns.Add(bfield3);

                BoundField bfield4 = new BoundField();
                bfield4.DataField = "xstdid";
                GridView1.Columns.Add(bfield4);

                BoundField bfield5 = new BoundField();
                bfield5.DataField = "xterm";
                GridView1.Columns.Add(bfield5);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                //bfield1.Visible = false;
                //bfield2.Visible = false;
                bfield1.ItemStyle.CssClass = "hiddencol";
                bfield1.HeaderStyle.CssClass = "hiddencol";
                bfield2.ItemStyle.CssClass = "hiddencol";
                bfield2.HeaderStyle.CssClass = "hiddencol";
                bfield3.ItemStyle.CssClass = "hiddencol";
                bfield3.HeaderStyle.CssClass = "hiddencol";
                bfield4.ItemStyle.CssClass = "hiddencol";
                bfield4.HeaderStyle.CssClass = "hiddencol";
                bfield5.ItemStyle.CssClass = "hiddencol";
                bfield5.HeaderStyle.CssClass = "hiddencol";

                //int i = 1;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Label lbl = (Label)row.FindControl("lblno");
                //    lbl.Text = i.ToString();
                //    i++;
                //}


                //if (GridView1.Rows.Count > 0)
                //{
                //    //Adds THEAD and TBODY Section.
                //    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                //    //Adds TH element in Header Row.  
                //    GridView1.UseAccessibleHeader = true;

                //    ////Adds TFOOT section. 
                //    //GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
                //}

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 600, 1229.4 , 60 ,false); </script>", false);
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.DataSource == null)
                {
                    return;
                }

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                int m = 0;
                for (int i = 4; i < 4 + (int)ViewState["rowCount"]; )
                {
                    GridView1.HeaderRow.Cells[i].ColumnSpan = 2;
                    GridView1.HeaderRow.Cells[i + 1].Visible = false;
                    //GridView1.HeaderRow.Cells[i + 2].Visible = false;

                    if (m + 2 < (int)ViewState["rowCount"])
                    {
                        if (((List<string>)ViewState["xsubject"])[m + 2] == "")
                        {
                            i = i + 3;
                            m = m + 3;
                        }
                        else
                        {

                            i = i + 2;
                            m = m + 2;
                        }
                    }
                    else
                    {
                        i = i + 2;
                        m = m + 2;
                    }
                }

                //message.InnerHtml = ViewState["rowCount"].ToString() + " " +
                //                    ((List<string>) ViewState["xsubject"]).Count.ToString();


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query;
                        //if (xsection.Text == "All")
                        //{
                        //    query = "select distinct xterm from amexamh  " +
                        //          "WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xtype IN ('Term Exam','Class Test') and xstatus='Approved3'";

                        //}
                        //else
                        //{
                        //    query = "select distinct xterm from amexamh  " +
                        //          "WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xtype IN ('Term Exam','Class Test') and xstatus='Approved3'";
                        //}

                        //SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        //da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());

                        //da1.Fill(dts1, "tempztcode");
                        //DataTable dtxtermcount = new DataTable();
                        //dtxtermcount = dts1.Tables[0];

                        //if (dtxtermcount.Rows.Count > 0)
                        {
                            query = "select * from amexamname  ";

                            SqlDataAdapter da2 = new SqlDataAdapter(query, con);


                            da2.Fill(dts1, "tempztcode1");
                            DataTable dtamexamname = new DataTable();
                            dtamexamname = dts1.Tables["tempztcode1"];

                            int rowIndex = 0;
                            int rowno = 1;
                            //while (rowIndex < GridView1.Rows.Count)
                            //{
                            //    GridViewRow gvRow = GridView1.Rows[rowIndex];
                            //    //gvRow.BorderStyle=BorderStyle.Solid;
                            //    //gvRow.BorderColor=Color.Black;
                            //    //gvRow.BorderWidth = Unit.Pixel(3);
                            //    if (rowIndex != 0)
                            //    {
                            //        gvRow.CssClass = "BorderRow";
                            //    }

                            //    gvRow.Cells[1].RowSpan = dtxtermcount.Rows.Count * dtamexamname.Rows.Count;
                            //    gvRow.Cells[0].RowSpan = dtxtermcount.Rows.Count * dtamexamname.Rows.Count;

                            //    for (int i = 1; i < dtxtermcount.Rows.Count * dtamexamname.Rows.Count; i++)
                            //    {
                            //        GridView1.Rows[rowIndex + i].Cells[1].Visible = false;
                            //        GridView1.Rows[rowIndex + i].Cells[0].Visible = false;
                            //    }

                            //    Label lbl = (Label)gvRow.FindControl("lblno");
                            //    lbl.Text = rowno.ToString();

                            //    rowno = rowno + 1;
                            //    rowIndex = rowIndex + dtxtermcount.Rows.Count * dtamexamname.Rows.Count;
                            //}

                            int l = 0;
                            int k = 1;
                            for (k = 1; k < GridView1.Rows.Count; k++)
                            {
                                //GridViewRow gvRow = GridView1.Rows[k];

                                //if (l != 0)
                                //{
                                //    gvRow.CssClass = "BorderRow";
                                //}

                                if (GridView1.Rows[k].Cells[1].Text == GridView1.Rows[k - 1].Cells[1].Text)
                                {
                                    l = l + 1;
                                }
                                else
                                {
                                    if (l != 0)
                                    {
                                        //GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
                                        GridView1.Rows[k - l - 1].Cells[1].RowSpan = l + 1;
                                        GridView1.Rows[k - l - 1].Cells[0].RowSpan = l + 1;
                                        for (int p = 0; p < l; p++)
                                        {
                                            //GridView1.HeaderRow.Cells[k - l + p].Visible = false;
                                            GridView1.Rows[k - l + p].Cells[1].Visible = false;
                                            GridView1.Rows[k - l + p].Cells[0].Visible = false;
                                        }

                                        if (rowno != 1)
                                        {
                                            GridView1.Rows[k - l - 1].CssClass = "BorderRow";
                                        }

                                        Label lbl = (Label)GridView1.Rows[k - l - 1].FindControl("lblno");
                                        lbl.Text = rowno.ToString();

                                        rowno = rowno + 1;
                                    }
                                    //else
                                    //{
                                    l = 0;
                                    //}
                                }
                            }

                            if (l != 0)
                            {
                                //GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
                                GridView1.Rows[k - l - 1].Cells[1].RowSpan = l + 1;
                                GridView1.Rows[k - l - 1].Cells[0].RowSpan = l + 1;
                                for (int p = 0; p < l; p++)
                                {
                                    //GridView1.HeaderRow.Cells[k - l + p].Visible = false;
                                    GridView1.Rows[k - l + p].Cells[1].Visible = false;
                                    GridView1.Rows[k - l + p].Cells[0].Visible = false;
                                }
                                GridView1.Rows[k - l - 1].CssClass = "BorderRow";
                                Label lbl = (Label)GridView1.Rows[k - l - 1].FindControl("lblno");
                                lbl.Text = rowno.ToString();

                                rowno = rowno + 1;
                            }

                            int rowIndex1 = 0;
                            while (rowIndex1 < GridView1.Rows.Count)
                            {
                                GridViewRow gvRow = GridView1.Rows[rowIndex1];

                                gvRow.Cells[2].RowSpan = dtamexamname.Rows.Count;
                                gvRow.Cells[4 + (int)ViewState["rowCount"]].RowSpan = dtamexamname.Rows.Count;
                                gvRow.Cells[4 + (int)ViewState["rowCount"] + 1].RowSpan = dtamexamname.Rows.Count;
                                gvRow.Cells[4 + (int)ViewState["rowCount"] + 2].RowSpan = dtamexamname.Rows.Count;

                                for (int i = 1; i < dtamexamname.Rows.Count; i++)
                                {
                                    GridView1.Rows[rowIndex1 + i].Cells[2].Visible = false;
                                    GridView1.Rows[rowIndex1 + i].Cells[4 + (int)ViewState["rowCount"]].Visible = false;
                                    GridView1.Rows[rowIndex1 + i].Cells[4 + (int)ViewState["rowCount"] + 1].Visible = false;
                                    GridView1.Rows[rowIndex1 + i].Cells[4 + (int)ViewState["rowCount"] + 2].Visible = false;
                                }

                                rowIndex1 = rowIndex1 + dtamexamname.Rows.Count;
                            }



                            rowIndex1 = 0;
                            while (rowIndex1 < GridView1.Rows.Count)
                            {
                                GridViewRow gvRow = GridView1.Rows[rowIndex1];

                                m = 0;

                                for (int i = 4; i < 4 + (int)ViewState["rowCount"]; )
                                {


                                    if (m + 2 < (int)ViewState["rowCount"])
                                    {
                                        if (((List<string>)ViewState["xsubject"])[m + 2] == "")
                                        {
                                            gvRow.Cells[i + 2].RowSpan = dtamexamname.Rows.Count;


                                            for (int h = 1; h < dtamexamname.Rows.Count; h++)
                                            {
                                                GridView1.Rows[rowIndex1 + h].Cells[i + 2].Visible = false;

                                            }

                                            i = i + 3;
                                            m = m + 3;
                                        }
                                        else
                                        {

                                            i = i + 2;
                                            m = m + 2;
                                        }
                                    }
                                    else
                                    {
                                        i = i + 2;
                                        m = m + 2;
                                    }
                                    //gvRow.Cells[i + 2].RowSpan = dtamexamname.Rows.Count;


                                    //for (int h = 1; h < dtamexamname.Rows.Count; h++)
                                    //{
                                    //    GridView1.Rows[rowIndex1 + h].Cells[i + 2].Visible = false;

                                    //}
                                }

                                rowIndex1 = rowIndex1 + dtamexamname.Rows.Count;
                            }

                        }



                    }
                }


                ///////////////////////////////////////////////////////


                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();

                GridView1.HeaderRow.Cells[0].Visible = false;
                GridView1.HeaderRow.Cells[1].Visible = false;
                GridView1.HeaderRow.Cells[2].Visible = false;
                GridView1.HeaderRow.Cells[3].Visible = false;


                cell = new TableHeaderCell();
                cell.Text = "No.";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Student's Name";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Term";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "";
                cell.RowSpan = 2;
                row.Controls.Add(cell);


                int j = 0;
                for (int i = 0; i < (int)ViewState["rowCount"]; ) //i=i+1
                {
                    cell = new TableHeaderCell();



                    cell.Text = ((List<string>)ViewState["xsubject"])[i];
                    cell.BorderStyle = BorderStyle.Solid;
                    cell.BorderWidth = 1;
                    cell.BorderColor = ColorTranslator.FromHtml("#778899");

                    i = i + ((List<int>)ViewState["colspan"])[j];


                    if (i == (int)ViewState["rowCount"])
                    {
                        cell.ColumnSpan = ((List<int>)ViewState["colspan"])[j] + 1;
                        //message.InnerHtml = message.InnerHtml + "last" + " ";
                    }
                    else
                    {
                        cell.ColumnSpan = ((List<int>)ViewState["colspan"])[j];
                        //message.InnerHtml = message.InnerHtml + "cell" + " ";
                    }


                    row.Controls.Add(cell);
                    // message.InnerHtml = message.InnerHtml + (((List<int>)ViewState["colspan"])[j]).ToString() + " ";

                    j = j + 1;


                }





                GridView1.HeaderRow.Cells[4 + (int)ViewState["rowCount"] + 0].Visible = false;
                GridView1.HeaderRow.Cells[4 + (int)ViewState["rowCount"] + 1].Visible = false;
                //GridView1.HeaderRow.Cells[4 + (int)ViewState["rowCount"] + 2].Visible = false;

                //cell = new TableHeaderCell();
                //cell.Text = "";
                ////cell.RowSpan = 2;
                //row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "C";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                //row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
                GridView1.HeaderRow.Parent.Controls.AddAt(0, row);




            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblno = new Label();
                    lblno.Text = "";
                    lblno.ID = "lblno";
                    lblno.Attributes.Add("runat", "server");
                    e.Row.Cells[0].Controls.Add(lblno);
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    //    List<string> list_t_row = (List<string>)ViewState["listtrow"];
                    //    int retestcount = 0;
                    //    string xrefcttype1 = "";
                    //    string xrefctno1 = "";
                    int k = 0;
                    int m = 0;
                    for (int i = 4; i < 4 + (int)ViewState["rowCount"]; ) //i = i + 2
                    {
                        if (m + 2 < (int)ViewState["rowCount"])
                        {
                            if (((List<string>)ViewState["xsubject"])[m + 2] == "")
                            {
                                ///////////////////////////////////////////////////////


                                Label lblperc = new Label();
                                lblperc.Text = "";
                                lblperc.ID = "lblperc" + i.ToString();
                                lblperc.ForeColor = Color.Black;
                                lblperc.Attributes.Add("runat", "server");
                                e.Row.Cells[i].Controls.Add(lblperc);

                                Label lblmarks = new Label();
                                lblmarks.Text = "";
                                lblmarks.ID = "lblmarks" + i.ToString();
                                lblmarks.ForeColor = Color.Black;
                                lblmarks.Attributes.Add("runat", "server");
                                e.Row.Cells[i + 1].Controls.Add(lblmarks);

                                Label lblgrade = new Label();
                                lblgrade.Text = "";
                                lblgrade.ID = "lblgrade" + i.ToString();
                                lblgrade.ForeColor = Color.Black;
                                lblgrade.Attributes.Add("runat", "server");
                                e.Row.Cells[i + 2].Controls.Add(lblgrade);

                                //***********************************************


                                Int64 xsrow = Convert.ToInt64((e.Row.DataItem as DataRowView).Row["xrow"].ToString());
                                DataRow[] result;
                                DataRow[] result1;
                                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() != "Total")
                                {
                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                                    {
                                        result =
                                            ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                           ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                    }
                                    else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                                    {
                                        result =
                                            ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                           ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                    }
                                    else
                                    {
                                        result =
                                           ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                           (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                          ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Class Test' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                    }
                                }
                                else
                                {
                                    //result =
                                    //   ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
                                    //                                             (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                                    //                                             xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");
                                    result =
                                          ((DataTable)ViewState["amexamph_sumext_exam2_sub"]).Select("zid=" + _zid + " and xterm='" +
                                          (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                         ((List<string>)ViewState["xsubject"])[m].ToString() + "'  and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                }

                                result1 =
                                      ((DataTable)ViewState["amexamph_sumext_exam2_wt1"]).Select("zid=" + _zid + " and xterm='" +
                                                                                (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                                                                                xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[m].ToString() + "'");

                                if (result.Length > 0)
                                {
                                    //message.InnerHtml = message.InnerHtml + result[0]["xnetmark"].ToString() + "<br/>";
                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                                    {
                                        lblmarks.Text = Convert.ToDecimal(result[0]["xgetmark"].ToString()).ToString("####");
                                        lblperc.Text = Convert.ToDecimal(result[0]["xmarks"].ToString()).ToString("####");
                                    }
                                    else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
                                    {
                                        lblmarks.Text =
                                            Convert.ToDecimal(result[0]["xgetmarksubwt"].ToString()).ToString("####");
                                    }
                                    else
                                    {
                                        lblmarks.Text =
                                            Convert.ToDecimal(result[0]["xgetmarkexam"].ToString()).ToString("####");
                                    }

                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "CT" ||
                                        (e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                                    {
                                        lblperc.Text = Convert.ToDecimal(result[0]["xpercexam"].ToString()).ToString("####") + "%";
                                    }


                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
                                    {
                                        //lblgrade.Text = result[0]["xgrade"].ToString();
                                        lblperc.Text = Convert.ToDecimal(result[0]["xpercsubwt"].ToString()).ToString("####") + "%";
                                    }




                                }

                                if (result1.Length > 0)
                                {
                                    lblgrade.Text = result1[0]["xgrade"].ToString() + "<br/>" + "(" + Convert.ToDecimal(result1[0]["xpercsubwt100"].ToString()).ToString("####") + ")";
                                    //lblperc.Text = "%";
                                }

                                //***********************************************

                                //fnGradeSheetMarks(e.Row, k, lblmarks, lblperc, lblgrade);
                                ///////////////////////////////////////////////////////

                                i = i + 3;
                                m = m + 3;
                            }
                            else
                            {
                                ///////////////////////////////////////////////////////


                                Label lblperc = new Label();
                                lblperc.Text = "";
                                lblperc.ID = "lblperc" + i.ToString();
                                lblperc.ForeColor = Color.Black;
                                lblperc.Attributes.Add("runat", "server");
                                e.Row.Cells[i].Controls.Add(lblperc);

                                Label lblmarks = new Label();
                                lblmarks.Text = "";
                                lblmarks.ID = "lblmarks" + i.ToString();
                                lblmarks.ForeColor = Color.Black;
                                lblmarks.Attributes.Add("runat", "server");
                                e.Row.Cells[i + 1].Controls.Add(lblmarks);

                                ////////////////////////////////////////////


                                //***********************************************


                                Int64 xsrow = Convert.ToInt64((e.Row.DataItem as DataRowView).Row["xrow"].ToString());
                                DataRow[] result;
                                DataRow[] result1;
                                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() != "Total")
                                {
                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                                    {
                                        result =
                                            ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                           ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                    }
                                    else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                                    {
                                        result =
                                            ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                           ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                    }
                                    else
                                    {
                                        result =
                                           ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                           (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                          ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Class Test' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                    }
                                }
                                else
                                {
                                    //result =
                                    //   ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
                                    //                                             (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                                    //                                             xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");
                                    result =
                                          ((DataTable)ViewState["amexamph_sumext_exam2_sub"]).Select("zid=" + _zid + " and xterm='" +
                                          (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                         ((List<string>)ViewState["xsubject"])[m].ToString() + "'  and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                }

                                //result1 =
                                //      ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
                                //                                                (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                                //                                                xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");

                                if (result.Length > 0)
                                {
                                    //message.InnerHtml = message.InnerHtml + result[0]["xnetmark"].ToString() + "<br/>";
                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                                    {
                                        lblmarks.Text = Convert.ToDecimal(result[0]["xgetmark"].ToString()).ToString("####");
                                        lblperc.Text = Convert.ToDecimal(result[0]["xmarks"].ToString()).ToString("####");
                                    }
                                    else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
                                    {
                                        lblmarks.Text =
                                            Convert.ToDecimal(result[0]["xgetmarksubwt"].ToString()).ToString("####");
                                    }
                                    else
                                    {
                                        lblmarks.Text = Convert.ToDecimal(result[0]["xgetmarkexam"].ToString()).ToString("####");
                                    }

                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "CT" ||
                                        (e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                                    {
                                        lblperc.Text = Convert.ToDecimal(result[0]["xpercexam"].ToString()).ToString("####") + "%";
                                    }


                                    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
                                    {
                                        //lblgrade.Text = result[0]["xgrade"].ToString();
                                        lblperc.Text = Convert.ToDecimal(result[0]["xpercsubwt"].ToString()).ToString("####") + "%";
                                    }




                                }

                                //***********************************************


                                ///////////////////////////////////////////////////
                                i = i + 2;
                                m = m + 2;
                            }
                        }
                        else
                        {
                            Label lblperc = new Label();
                            lblperc.Text = "";
                            lblperc.ID = "lblperc" + i.ToString();
                            lblperc.ForeColor = Color.Black;
                            lblperc.Attributes.Add("runat", "server");
                            e.Row.Cells[i].Controls.Add(lblperc);

                            Label lblmarks = new Label();
                            lblmarks.Text = "";
                            lblmarks.ID = "lblmarks" + i.ToString();
                            lblmarks.ForeColor = Color.Black;
                            lblmarks.Attributes.Add("runat", "server");
                            e.Row.Cells[i + 1].Controls.Add(lblmarks);

                            Label lblgrade = new Label();
                            lblgrade.Text = "";
                            lblgrade.ID = "lblgrade" + i.ToString();
                            lblgrade.ForeColor = Color.Black;
                            lblgrade.Attributes.Add("runat", "server");
                            e.Row.Cells[i + 2].Controls.Add(lblgrade);

                            //***********************************************


                            Int64 xsrow = Convert.ToInt64((e.Row.DataItem as DataRowView).Row["xrow"].ToString());
                            DataRow[] result;
                            DataRow[] result1;
                            if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() != "Total")
                            {
                                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                                {
                                    result =
                                        ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                        (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                       ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                }
                                else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                                {
                                    result =
                                        ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                        (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                       ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                }
                                else
                                {
                                    result =
                                       ((DataTable)ViewState["amexamph_sumext_exam"]).Select("zid=" + _zid + " and xterm='" +
                                       (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                      ((List<string>)ViewState["xsubject"])[m].ToString() + "' and xtype='Class Test' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                                }
                            }
                            else
                            {
                                //result =
                                //   ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
                                //                                             (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                                //                                             xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");
                                result =
                                      ((DataTable)ViewState["amexamph_sumext_exam2_sub"]).Select("zid=" + _zid + " and xterm='" +
                                      (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                                     ((List<string>)ViewState["xsubject"])[m].ToString() + "'  and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                            }

                            result1 =
                                  ((DataTable)ViewState["amexamph_sumext_exam2_wt1"]).Select("zid=" + _zid + " and xterm='" +
                                                                            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                                                                            xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[m].ToString() + "'");

                            if (result.Length > 0)
                            {
                                //message.InnerHtml = message.InnerHtml + result[0]["xnetmark"].ToString() + "<br/>";
                                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                                {
                                    lblmarks.Text = Convert.ToDecimal(result[0]["xgetmark"].ToString()).ToString("####");
                                    lblperc.Text = Convert.ToDecimal(result[0]["xmarks"].ToString()).ToString("####");
                                }
                                else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
                                {
                                    lblmarks.Text =
                                        Convert.ToDecimal(result[0]["xgetmarksubwt"].ToString()).ToString("####");
                                }
                                else
                                {
                                    lblmarks.Text = Convert.ToDecimal(result[0]["xgetmarkexam"].ToString()).ToString("####");
                                }

                                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "CT" ||
                                    (e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                                {
                                    lblperc.Text = Convert.ToDecimal(result[0]["xpercexam"].ToString()).ToString("####") + "%";
                                }


                                if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
                                {
                                    //lblgrade.Text = result[0]["xgrade"].ToString();
                                    lblperc.Text = Convert.ToDecimal(result[0]["xpercsubwt"].ToString()).ToString("####") + "%";
                                }




                            }

                            if (result1.Length > 0)
                            {
                                lblgrade.Text = result1[0]["xgrade"].ToString() + "<br/>" + "(" + Convert.ToDecimal(result1[0]["xpercsubwt100"].ToString()).ToString("####") + ")";
                                //lblperc.Text = "%";
                            }

                            //***********************************************

                            i = i + 2;
                            m = m + 2;
                        }


                        ////////////////////////////////////////////////////////
                        //Label lblperc = new Label();
                        //lblperc.Text = "";
                        //lblperc.ID = "lblperc" + i.ToString();
                        //lblperc.ForeColor = Color.Black;
                        //lblperc.Attributes.Add("runat", "server");
                        //e.Row.Cells[i].Controls.Add(lblperc);

                        //Label lblmarks = new Label();
                        //lblmarks.Text = "";
                        //lblmarks.ID = "lblmarks" + i.ToString();
                        //lblmarks.ForeColor = Color.Black;
                        //lblmarks.Attributes.Add("runat", "server");
                        //e.Row.Cells[i + 1].Controls.Add(lblmarks);

                        ////Label lblgrade = new Label();
                        ////lblgrade.Text = "";
                        ////lblgrade.ID = "lblgrade" + i.ToString();
                        ////lblgrade.ForeColor = Color.Black;
                        ////lblgrade.Attributes.Add("runat", "server");
                        ////e.Row.Cells[i + 2].Controls.Add(lblgrade);

                        //message.InnerHtml = (e.Row.DataItem as DataRowView).Row["xrow"].ToString();
                        // message.InnerHtml = ((List<string>)ViewState["xsubject"])[k].ToString();
                        //Int64 xsrow = Convert.ToInt64((e.Row.DataItem as DataRowView).Row["xrow"].ToString());
                        //DataRow[] result;
                        //DataRow[] result1;
                        //if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() != "Total")
                        //{
                        //    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                        //    {
                        //        result =
                        //            ((DataTable)ViewState["amexammaxmarkph3_sum3"]).Select("zid=" + _zid + " and xterm='" +
                        //            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                        //           ((List<string>)ViewState["xsubject"])[k].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                        //    }
                        //    else if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                        //    {
                        //        result =
                        //            ((DataTable)ViewState["amexammaxmarkph3_sum3"]).Select("zid=" + _zid + " and xterm='" +
                        //            (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                        //           ((List<string>)ViewState["xsubject"])[k].ToString() + "' and xtype='Term Exam' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                        //    }
                        //    else
                        //    {
                        //        result =
                        //           ((DataTable)ViewState["amexammaxmarkph3_sum3"]).Select("zid=" + _zid + " and xterm='" +
                        //           (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                        //          ((List<string>)ViewState["xsubject"])[k].ToString() + "' and xtype='Class Test' and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                        //    }
                        //}
                        //else
                        //{
                        //    //result =
                        //    //   ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
                        //    //                                             (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                        //    //                                             xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");
                        //    result =
                        //          ((DataTable)ViewState["amexammaxmarkph3_sum4_sub"]).Select("zid=" + _zid + " and xterm='" +
                        //          (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" + xsrow + " and xsubject='" +
                        //         ((List<string>)ViewState["xsubject"])[k].ToString() + "'  and xpaper='" + ((List<string>)ViewState["xpaper"])[k].ToString() + "'");
                        //}

                        ////result1 =
                        ////      ((DataTable)ViewState["amexammaxmarkvw3_sum6"]).Select("zid=" + _zid + " and xterm='" +
                        ////                                                (e.Row.DataItem as DataRowView).Row["xterm"].ToString() + "' and xsrow=" +
                        ////                                                xsrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[k].ToString() + "'");

                        //if (result.Length > 0)
                        //{
                        //    //message.InnerHtml = message.InnerHtml + result[0]["xnetmark"].ToString() + "<br/>";
                        //    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Marks")
                        //    {
                        //        lblmarks.Text = Convert.ToDecimal(result[0]["xgetmark"].ToString()).ToString("####");
                        //        lblperc.Text = Convert.ToDecimal(result[0]["xmarks"].ToString()).ToString("####");
                        //    }
                        //    else
                        //    {
                        //        lblmarks.Text = Convert.ToDecimal(result[0]["xnetmark"].ToString()).ToString("####");
                        //    }

                        //    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "CT" ||
                        //        (e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "%")
                        //    {
                        //        lblperc.Text = Convert.ToDecimal(result[0]["xperc"].ToString()).ToString("####") + "%";
                        //    }


                        //    if ((e.Row.DataItem as DataRowView).Row["xexam"].ToString() == "Total")
                        //    {
                        //        //lblgrade.Text = result[0]["xgrade"].ToString();
                        //        lblperc.Text = "%";
                        //    }




                        //}

                        ////if (result1.Length > 0)
                        ////{
                        ////    lblgrade.Text = result1[0]["xgrade"].ToString();
                        ////    //lblperc.Text = "%";
                        ////}


                        k = k + 1;

                    }



                    HtmlGenericControl btnComments = new HtmlGenericControl("input");
                    btnComments.ID = "btnComments";
                    btnComments.Attributes.Add("type", "button");
                    btnComments.Attributes.Add("class", "btnComments");
                    //btnComments.Attributes.Add("runat", "server");
                    btnComments.Attributes.Add("style", "background-color: #f44336;cursor: pointer; border: none;text-decoration: none;display: block;height:18px;width:18px;");
                    e.Row.Cells[5 + (int)ViewState["rowCount"]].Controls.Add(btnComments);
                    //btnComments.Attributes.Add("title", "i am button");

                    if (ViewState["amexamhhd1"] != null)
                    {
                        Int64 xsrow1 = Convert.ToInt64((e.Row.DataItem as DataRowView).Row["xrow"].ToString());
                        string xsection1 = (e.Row.DataItem as DataRowView).Row["xsection"].ToString();
                        string xterm1 = (e.Row.DataItem as DataRowView).Row["xterm"].ToString();
                        DataRow[] result13 =
                              ((DataTable)ViewState["amexamhhd1"]).Select("zid=" + _zid + " and  xsrow=" +
                                                                        xsrow1 + " and xsection='" + xsection1 + "' and xterm='" + xterm1 + "'");
                        if (result13.Length > 0)
                        {
                            btnComments.Attributes.Add("title", result13[0]["xremarks"].ToString());
                            btnComments.Style.Add("background-color", "#64B446");
                        }
                    }

                    if (ViewState["amexamhh4"] != null)
                    {

                        string xterm1 = (e.Row.DataItem as DataRowView).Row["xterm"].ToString();
                        DataRow[] result13 =
                              ((DataTable)ViewState["amexamhh4"]).Select("zid=" + _zid + " and xterm='" + xterm1 + "'");
                        if (result13.Length > 0)
                        {
                            btnComments.Disabled = true;
                        }
                        else
                        {
                            btnComments.Disabled = false;
                        }
                    }


                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        //protected void gvTheGrid_PreRender(object sender, EventArgs e)
        //{


        //    if (GridView1.Rows.Count > 0)
        //    {
        //        //This replaces <td> with <th> and adds the scope attribute
        //        GridView1.UseAccessibleHeader = true;

        //        //This will add the <thead> and <tbody> elements
        //        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

        //        //This adds the <tfoot> element. 
        //        //Remove if you don't have a footer row
        //        GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }
        //}

        public void btnGenerate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";


            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //    using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    {
            //        using (DataSet dts1 = new DataSet())
            //        {
            //            //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            //            //string query =
            //            //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //            //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            //            string query =
            //                "select * from amexamh where zid=@zid and xsession=@xsession and xclass=@xclass and xterm=@xterm and xgroup=@xgroup";

            //            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //            //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

            //            da1.Fill(dts1, "tempztcode");
            //            DataTable dtamexamh = new DataTable();
            //            dtamexamh = dts1.Tables[0];

            //            if (dtamexamh.Rows.Count > 0)
            //            {
                            
            //            }
            //            else
            //            {
            //                message.InnerHtml = "Wrong parameter selected.";
            //                message.Style.Value = zglobal.am_warningmsg;
            //                return;
            //            }
            //        }
            //    }

            //    using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    {
            //        using (DataSet dts1 = new DataSet())
            //        {
            //            //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            //            //string query =
            //            //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //            //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            //            string query =
            //                "select xsubject,xpaper,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
            //                "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm   " +
            //                "group by xsubject,xpaper,xsection  order by min(cast(xcodealt as int))";

            //            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //            //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

            //            da1.Fill(dts1, "tempztcode");
            //            DataTable dtamexamh = new DataTable();
            //            dtamexamh = dts1.Tables[0];

            //            if (dtamexamh.Rows.Count > 0)
            //            {
            //                message.InnerHtml = "Please check for all class test & term exam approval.";
            //                message.Style.Value = zglobal.am_warningmsg;
            //                return;
            //            }
            //        }
            //    }

            //    //using (TransactionScope tran = new TransactionScope())
            //    //{
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            using (DataSet dts = new DataSet())
            //            {
            //                conn.Open();
            //                SqlTransaction tran = conn.BeginTransaction();
            //                try
            //                {
                               
                                
            //                    SqlCommand cmd = new SqlCommand();
            //                    cmd.Connection = conn;
            //                    cmd.Transaction = tran;
            //                    cmd.CommandTimeout = 0;

            //                    string query2 =
            //                        "DELETE FROM amexammaxmarkph3_sum6 WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup";
            //                    cmd.Parameters.Clear();
            //                    cmd.CommandText = query2;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                    cmd.ExecuteNonQuery();

            //                    query2 =
            //                        "DELETE FROM amexammaxmarkph3_sum3_gs1 WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup";
            //                    cmd.Parameters.Clear();
            //                    cmd.CommandText = query2;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                    cmd.ExecuteNonQuery();

            //                    query2 = "insert into amexammaxmarkph3_sum6 " +
            //                             "select * from amexammaxmarkvw3_sum6 " +
            //                             "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup";
            //                    cmd.Parameters.Clear();
            //                    cmd.CommandText = query2;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                    cmd.ExecuteNonQuery();

            //                    query2 = "insert into amexammaxmarkph3_sum3_gs1 " +
            //                             "select * from amexammaxmarkvw3_sum3_gs1 " +
            //                             "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup";
            //                    cmd.Parameters.Clear();
            //                    cmd.CommandText = query2;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                    cmd.ExecuteNonQuery();

            //                    tran.Commit();
            //                }
            //                catch (Exception exp)
            //                {
            //                    message.InnerHtml = exp.Message;
            //                    message.Style.Value = zglobal.errormsg;
            //                    tran.Rollback();
            //                    return;
            //                }
            //            }
            //        }

            //    //    tran.Complete();
            //    //}


            //    message.InnerHtml = "Generate tabulation sheet completed.";
            //    message.Style.Value = zglobal.successmsg;


            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
                
            //}

        }


        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {

                message.InnerHtml = "";

                //dxstatus.Visible = false;
                //dxstatus.Text = "Status : ";
                
                GridView1.DataSource = null;
                GridView1.DataBind();

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
                // message.InnerHtml = "";

                //// BindGrid(1999, 1);

                // if (ViewState["xrow"] == null)
                // {
                //     message.InnerHtml = "No data found.";
                //     message.Style.Value = zglobal.am_warningmsg;
                //     return;
                // }


                //// hiddenxdate.Value = xdate.SelectedValue.ToString();


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

                fnFillDataGrid(null, null);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        //private int _isPostBack = 0;
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
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCalendar(xdate);

                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnPermission(xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);

                    zglobal.fnGetComboDataCD("Section", xsection);
                    //xsection.Items.Add("All");
                    //xsection.Text = "All";
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;

                    //dxstatus.Visible = false;
                    //dxstatus.Text = "Status : ";
                    //dxstatus.Style.Value = zglobal.am_submited;

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    //BindGrid();

                    ViewState["ispostback"] = "yes";
                }

               
                    BindGrid();
                
                

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }

        }



        [WebMethod(EnableSession = true)]
        public static string fnInsetComments(string xsession1, string xterm1, string xclass1, string xgroup1, string xsection1, string xsrow1, string xremarks1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        conn.Open();
                        SqlTransaction tran = conn.BeginTransaction();
                        try
                        {
                            if (xremarks1 == "")
                            {
                                return "Please enter comments.";
                            }

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.Transaction = tran;
                            cmd.CommandTimeout = 0;

                            string query = "DELETE FROM amexamhhd1 WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Combined'  AND xsection=@xsection AND xsrow=@xsrow  ";
                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xsession", xsession1);
                            cmd.Parameters.AddWithValue("@xclass", xclass1);
                            cmd.Parameters.AddWithValue("@xterm", xterm1);
                            cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                            cmd.Parameters.AddWithValue("@xsection", xsection1);
                            cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                            cmd.ExecuteNonQuery();

                            query = "INSERT INTO amexamhhd1 (ztime,zid,xsession,xterm,xclass,xgroup,xsection,xsrow,xtype,xremarks,zemail) " +
                                       "VALUES(@ztime,@zid,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsrow,'Combined',@xremarks,@zemail) ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xsession", xsession1);
                            cmd.Parameters.AddWithValue("@xclass", xclass1);
                            cmd.Parameters.AddWithValue("@xterm", xterm1);
                            cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                            cmd.Parameters.AddWithValue("@xsection", xsection1);
                            cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                            cmd.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
                            cmd.ExecuteNonQuery();

                            tran.Commit();
                        }
                        catch (Exception exp)
                        {
                            tran.Rollback();
                            return exp.Message;
                            
                        }
                    }
                }


                return "success";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }


        [WebMethod(EnableSession = true)]
        public static string fnFetchComments(string xsession1, string xterm1, string xclass1, string xgroup1, string xsection1, string xsrow1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT * FROM amexamhhd1 WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Combined'  AND xsection=@xsection AND xsrow=@xsrow ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow1);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            return "success" + "|" + dtamexamd.Rows[0]["xremarks"].ToString();
                        }
                        else
                        {
                            return "nodata";
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