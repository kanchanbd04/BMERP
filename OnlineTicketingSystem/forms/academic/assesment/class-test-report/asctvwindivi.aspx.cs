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


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class asctvwindivi : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string rowid;
        object row;
        private string q_val;
        private string filter;
        

        public void fnFillDataGrid(object sender,EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                if (_student.Value != "" && flag==0)
                {
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    xclass.Text = zglobal.fnGetValue("xclass", "amstudentvw",
                        "zid=" + _zid + " and xsession='" + xsession.Text + "' and xrow=" +
                        Convert.ToInt64(_student.Value));
                    xgroup.Text = zglobal.fnGetValue("xgroup", "amstudentvw",
                       "zid=" + _zid + " and xsession='" + xsession.Text + "' and xrow=" +
                       Convert.ToInt64(_student.Value));
                    xsection.Text = zglobal.fnGetValue("xsection", "amstudentvw",
                     "zid=" + _zid + " and xsession='" + xsession.Text + "' and xrow=" +
                     Convert.ToInt64(_student.Value));

                }

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
        List<int> listmissedtest = new List<int>();
        List<string> listtrow = new List<string>();
        List<string> listmaxrtcount = new List<string>();
        List<string> listretestrow = new List<string>();
        private void BindGrid()
        {

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //ViewState["xrow"] = null;

            //string xrow = zglobal.fnGetValue("xrow", "amexamh",
            //     "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
            //     "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xstatus in('Approved2','Approved3')");
            ////if (ViewState["xrow"] == null)
            //if (xrow == "")
            //{
            //    message.InnerHtml = "No data found.";
            //    message.Style.Value = zglobal.am_warningmsg;
            //    return;
            //}

            SqlConnection conn11;
            conn11 = new SqlConnection(zglobal.constring);
            DataSet dts11 = new DataSet();

            dts11.Reset();
            
            string str1 = "SELECT ROW_NUMBER() OVER (ORDER BY xcttype desc, xctno asc) AS xid,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow AND amexamh.xstatus in('Approved2','Approved3') order by xstdid";


            SqlDataAdapter da11 = new SqlDataAdapter(str1, conn11);
            da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            da11.Fill(dts11, "tempztcode");
            DataTable dtmarks1 = new DataTable();
            dtmarks1 = dts11.Tables[0];

            if (dtmarks1.Rows.Count <= 0)
            {
                message.InnerHtml = "No data found.";
                message.Style.Value = zglobal.am_warningmsg;
                return;
            }








            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string xsession1 = xsession.Text.Trim().ToString();
            string xclass1 = xclass.Text.Trim().ToString();
            string xgroup1 = xgroup.Text.Trim().ToString();
            string xsection1 = xsection.Text.Trim().ToString();
            //message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            //return;
            //string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";

            string str = "SELECT distinct xsubject,xpaper,coalesce(xext,'') as xext FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow AND amexamh.xstatus in('Approved2','Approved3')";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
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
                tfield119.ItemStyle.Width = 35;
                GridView1.Columns.Add(tfield119);

                //bfield = new BoundField();
                //bfield.HeaderText = "No.";
                //bfield.ShowHeader = false;
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

                //bfield = new BoundField();
                //bfield.HeaderText = "Student's Name";
                ////bfield.ShowHeader = false;
                //bfield.DataField = "xname";
                //bfield.ItemStyle.Width = 200;
                //bfield.HtmlEncode = false;
                //GridView1.Columns.Add(bfield);

                TemplateField tfield120 = new TemplateField();
                tfield120.HeaderText = "Subject's Name";
                tfield120.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield120.ItemStyle.Width = 200;
                GridView1.Columns.Add(tfield120);


                //Generating coloum for all test
                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    //string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xcttype asc, xctno asc";
                    string query = "SELECT distinct xcttype,cast(xctno as int) as xctno FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                                   "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  " +
                                   "AND xsection=@xsection AND xsrow=@xsrow AND xcttype in('Test','Test (WS)') AND amexamh.xstatus in('Approved2','Approved3') " +
                                   "ORDER BY  xcttype asc, xctno asc";
                                   

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                    //cmd.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                    //cmd.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int rowCount = 0;
                    listtest.Clear();
                    listtrow.Clear();
                    listretest.Clear();
                    listmissedtest.Clear();

                    int test_count = 0;

                    //int cnt = 0;
                    while (rdr.Read())
                    {
                        tfield = new TemplateField();
                        tfield.HeaderText = rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString();
                        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        tfield.ItemStyle.Width = 50;
                        //tfield.ItemStyle.CssClass = "bm-marks";
                        GridView1.Columns.Add(tfield);

                        //cnt = cnt + 1;
                        //if (cnt%2 == 0)
                        //{
                            tfield = new TemplateField();
                            tfield.HeaderText = rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString();
                            tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            tfield.ItemStyle.Width = 45;
                            tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#D6E3B5");
                            //tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#CCD9AF");
                            GridView1.Columns.Add(tfield);
                        //}
                        //else
                        //{
                        //    tfield = new TemplateField();
                        //    tfield.HeaderText = rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString();
                        //    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //    tfield.ItemStyle.Width = 40;
                        //    tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#CCD9AF");
                        //    GridView1.Columns.Add(tfield);
                        //}

                        test_count = test_count + 1;
                        listtest.Add(test_count);
                        //listtrow.Add(rdr["xrow"].ToString());
                        listtrow.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                        listtrow.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                        rowCount = rowCount + 2;

                        //Generate column for retest
                        string maxretest = zglobal.fnGetValue("max(xid)", "amexamretestvw",
                           "zid='" + _zid + "' AND xsession='" + xsession.Text.ToString().Trim() + "' AND xclass='" + xclass.Text.ToString().Trim() +
                           "' AND xterm='" + xterm.Text.ToString().Trim() + "' AND xgroup='" + xgroup.Text.ToString().Trim() +
                           "' AND xtype='Class Test'  AND xsection='" + xsection.Text.ToString().Trim() +
                           "' AND xsrow=" + _student.Value.ToString().Trim() +
                           " AND xcttype in('Retest') AND xrefcttype='" + rdr["xcttype"].ToString() + "' AND xrefctno='" + rdr["xctno"].ToString() + "' AND xstatus in('Approved2','Approved3')");
                        //message.InnerHtml = message.InnerHtml + maxretest;
                        int retest_count = 0;
                        int maxrtcount = 0;
                        if (maxretest != null && maxretest != "")
                        {

                            for (int p = 1; p <= Convert.ToInt32(maxretest); p++)
                            {
                                tfield = new TemplateField();
                                //tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                                tfield.HeaderText = "Retest";
                                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                tfield.ItemStyle.Width = 45;
                                tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                                tfield.HeaderStyle.ForeColor = Color.DimGray;
                                tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                                GridView1.Columns.Add(tfield);
                                retest_count = retest_count + 1;
                                rowCount = rowCount + 1;

                                listtrow.Add("-1");
                            }


                        }
                        listretest.Add(retest_count);


                        ////Generate column for missed-test
                        //string maxmissedtest = zglobal.fnGetValue("max(xid)", "amexammissedtestvw",
                        //   "zid='" + _zid + "' AND xsession='" + xsession.Text.ToString().Trim() + "' AND xclass='" + xclass.Text.ToString().Trim() +
                        //   "' AND xterm='" + xterm.Text.ToString().Trim() + "' AND xgroup='" + xgroup.Text.ToString().Trim() +
                        //   "' AND xtype='Class Test'  AND xsection='" + xsection.Text.ToString().Trim() +
                        //   "' AND xsrow=" + _student.Value.ToString().Trim() +
                        //   " AND xcttype in('Missed Test') AND xrefcttype='" + rdr["xcttype"].ToString() + "' AND xrefctno='" + rdr["xctno"].ToString() + "' AND xstatus in('Approved2','Approved3')");
                        ////message.InnerHtml = message.InnerHtml + maxretest;
                        //int missedtest_count = 0;
                        //int maxmtcount = 0;
                        //if (maxmissedtest != null && maxmissedtest != "")
                        //{

                        //    for (int p = 1; p <= Convert.ToInt32(maxmissedtest); p++)
                        //    {
                        //        tfield = new TemplateField();
                        //        //tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                        //        tfield.HeaderText = "Missed Test";
                        //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //        tfield.ItemStyle.Width = 45;
                        //        tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#8ED8F8");
                        //        tfield.HeaderStyle.ForeColor = Color.DimGray;
                        //        tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#8ED8F8");
                        //        GridView1.Columns.Add(tfield);
                        //        missedtest_count = missedtest_count + 1;
                        //        rowCount = rowCount + 1;

                        //        listtrow.Add("-2");
                        //    }


                        //}

                        //listmissedtest.Add(missedtest_count);


                        //using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                        //{
                        //    using (DataSet dts1 = new DataSet())
                        //    {
                        //        //query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Retest') AND xrefcttype=@xrefcttype AND xrefctno=@xrefctno AND xstatus in('Approved2','Approved3') ORDER BY xdate";
                        //        //query = "SELECT * FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //        //    "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow AND xcttype in('Retest') AND xrefcttype=@xrefcttype AND xrefctno=@xrefctno AND xstatus in('Approved2','Approved3') ORDER BY xcttype asc, xctno asc";

                        //        query = "SELECT * FROM amexamretestvw WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow AND xcttype in('Retest') AND xrefcttype=@xrefcttype AND xrefctno=@xrefctno AND xstatus in('Approved2','Approved3') AND xid<=@xid ";

                        //        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                        //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        //        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xrefcttype", rdr["xcttype"].ToString());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xrefctno", rdr["xctno"].ToString());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xid", maxretest);
                        //        da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        //        da1.Fill(dts1, "tempztcode");
                        //        DataTable dtamexam = new DataTable();
                        //        dtamexam = dts1.Tables[0];

                        //        //int retest_count = 0;
                        //        if (dtamexam.Rows.Count > 0)
                        //        {

                        //            foreach (DataRow row in dtamexam.Rows)
                        //            {
                                        
                        //                //listtest.Add(row["xcttype"].ToString() + "-" + row["xctno"].ToString());
                        //                //listtrow.Add(row["xrow"].ToString());
                        //                //rowCount = rowCount + 1;
                        //                //retest_count = retest_count + 1;
                        //            }

                        //        }
                        //        //listretest.Add(retest_count);
                        //    }
                        //}

                    }

                    if (test_count == 0)
                    {
                        listtest.Add(test_count);
                    }

                    ViewState["listretest"] = listretest;
                    ViewState["listmissedtest"] = listmissedtest;
                    ViewState["listtest"] = listtest;
                    ViewState["listtrow"] = listtrow;
                    ViewState["rowCount"] = rowCount;
                }

                //List<string> listxrow = new List<string>();
                //listxrow.Clear();
                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    //string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xcttype asc, xctno asc";
                //    string query =
                //        "SELECT * FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                //        "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY  xcttype asc, xctno asc";

                //    SqlCommand cmd = new SqlCommand(query, con);
                //    cmd.Parameters.AddWithValue("@zid", _zid);
                //    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                //    //cmd.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                //    //cmd.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                //    cmd.CommandType = CommandType.Text;
                //    con.Open();
                //    SqlDataReader rdr = cmd.ExecuteReader();
                //    while (rdr.Read())
                //    {
                //        listxrow.Add(rdr["xrow"].ToString());
                //    }
                //}

                //string xrow2 = "";

                //for (int l = 0; l < listtrow.Count; l++)
                //{
                //    if (l == listxrow.Count - 1)
                //    {
                //        xrow2 = xrow2 + listxrow[l].ToString();
                //    }
                //    else
                //    {
                //        xrow2 = xrow2 + listxrow[l].ToString() + ",";
                //    }
                //}


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,amexamh.zid,amexamh.xsubject,amexamh.xpaper,amexamh.xcttype,amexamh.xctno,coalesce(amexamh.xext,'') as xext FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow AND xcttype in('Test','Test (WS)') AND amexamh.xstatus in('Approved2','Approved3') ";
                        string query =
                        "SELECT xgetmark,xtopic,xdetails,xdate,xmarks,zid,xsubject,xpaper,xcttype,xctno,xext,xismissedtest FROM amexamvw_getmark1 " +
                        "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  " +
                        "AND xsection=@xsection AND xsrow=@xsrow AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                       da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                       da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                       da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                       da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                       da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                       da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                       da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamd"] = dtamexamd;

                    }
                }

                ////foreach (DataRow row in ((DataTable)ViewState["amexamd"]).Rows)
                ////{
                ////    Response.Write(row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " <br>");
                ////}
                /// 
                /// 
                /// 




                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xgetmark,xtopic,xdetails,zid,xsubject,xpaper,coalesce(xext,'') as xext, xrefcttype,xrefctno,xid FROM amexamretestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow  AND xcttype in('Retest') AND xstatus in('Approved2','Approved3')";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamretestvw"] = dtamexamd;

                    }
                }

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts1 = new DataSet())
                //    {
                //        string query = "SELECT xgetmark,xtopic,xdetails,zid,xsubject,xpaper,coalesce(xext,'') as xext, xrefcttype,xrefctno,xid FROM amexammissedtestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsrow=@xsrow  AND xcttype in('Missed Test') AND xstatus in('Approved2','Approved3')";

                //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                //        da1.Fill(dts1, "tempztcode");
                //        DataTable dtamexamd = new DataTable();
                //        dtamexamd = dts1.Tables[0];

                //        ViewState["amexammissedtestvw"] = dtamexamd;

                //    }
                //}




                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield2);

                BoundField bfield1 = new BoundField();
                bfield1.DataField = "xsubject";
                GridView1.Columns.Add(bfield1);

                BoundField bfield2 = new BoundField();
                bfield2.DataField = "xpaper";
                GridView1.Columns.Add(bfield2);

                BoundField bfield3 = new BoundField();
                bfield3.DataField = "xext";
                GridView1.Columns.Add(bfield3);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                int i = 1;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lbl = (Label)row.FindControl("lblno");
                    lbl.Text = i.ToString();
                    i++;
                }

                bfield1.Visible = false;
                bfield2.Visible = false;
                bfield3.Visible = false;

                


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

                ////for merging retest column
                //int k = 3;
                //int l = k;
                ////foreach (int data in (List<int>)ViewState["listretest"])
                ////{
                ////    GridView1.HeaderRow.Cells[k - 1].ColumnSpan = 2;
                ////    GridView1.HeaderRow.Cells[k].Visible = false;

                ////    if (data != 0)
                ////    {
                ////        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = data;
                ////        for (int m = 2; m <= data; m++)
                ////        {
                ////            GridView1.HeaderRow.Cells[k + m].Visible = false;
                ////        }
                ////        k = k + data + 2;
                ////    }
                ////    else
                ////    {
                ////        k = k + 2;
                ////    }

                ////}

                //List<int> listrt = (List<int>)ViewState["listretest"];
                //List<int> listmt = (List<int>)ViewState["listmissedtest"];

                //for (int j = 0; j < listrt.Count; j++)
                //{
                //    GridView1.HeaderRow.Cells[l - 1].ColumnSpan = 2;
                //    GridView1.HeaderRow.Cells[l].Visible = false;

                //    if (listrt[j] != 0)
                //    {
                //        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = listrt[j];
                //        for (int m = 2; m <= listrt[j]; m++)
                //        {
                //            GridView1.HeaderRow.Cells[k + m].Visible = false;
                //        }
                //        k = k + listrt[j] + 2;
                //    }
                //    else
                //    {
                //        k = k + 2;
                //    }

                //    l = k;

                //    if (listmt[j] != 0)
                //    {
                //        GridView1.HeaderRow.Cells[l].ColumnSpan = listmt[j];
                //        for (int m = 1; m <= listmt[j]; m++)
                //        {
                //            GridView1.HeaderRow.Cells[l + m].Visible = false;
                //        }
                //        //l = l + listrt[j] + 2;
                //    }
                //    //else
                //    //{
                //    //    l = l + 2;
                //    //}
                //}

                int l = 0;
                for (int k = 1; k <= (int)ViewState["rowCount"]; k++)
                {
                    if (GridView1.HeaderRow.Cells[k].Text == GridView1.HeaderRow.Cells[k - 1].Text)
                    {
                        l = l + 1;
                    }
                    else
                    {
                        if (l != 0)
                        {
                            GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
                            for (int p = 0; p < l; p++)
                            {
                                GridView1.HeaderRow.Cells[k - l + p].Visible = false;
                            }
                        }
                        //else
                        //{
                        l = 0;
                        //}
                    }
                }
                

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
                    lblno.ForeColor = Color.Black;
                    e.Row.Cells[0].Controls.Add(lblno);

                    Label lblsubject = new Label();
                    lblsubject.Text = "";
                    lblsubject.ID = "lblsubject";
                    lblsubject.ForeColor = Color.Black;
                    e.Row.Cells[1].Controls.Add(lblsubject);

                    //if ((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "")
                    //{
                    //    lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
                    //                      (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    //}
                    //else
                    //{
                    //    lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    //}

                    if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != String.Empty) &&
                        ((e.Row.DataItem as DataRowView).Row["xext"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() != String.Empty))
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "(" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + ")" + "-" +
                                          (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    }
                    else if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != String.Empty) &&
                   ((e.Row.DataItem as DataRowView).Row["xext"].ToString() == "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() == String.Empty))
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
                                          (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    }
                    else if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == String.Empty) &&
                   ((e.Row.DataItem as DataRowView).Row["xext"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() != String.Empty))
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "(" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + ")" ;
                    }
                    else
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    }


                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    List<string> list_t_row = (List<string>)ViewState["listtrow"];
                    int retestcount = 0;
                    int mtcount = 0;
                    string xrefcttype1 = "";
                    string xrefctno1 = "";
                    for (int i = 2; i < 2 + (int)ViewState["rowCount"]; )
                    {

                        //Label lblmarks = new Label();
                        //lblmarks.Text = "";
                        //lblmarks.ID = "lblmarks" + i.ToString();
                        //lblmarks.ForeColor = Color.Black;
                        //lblmarks.Attributes.Add("runat", "server");
                        ////lblmarks.Text = "1.00";
                        ////lnkbtn.Click += OnLinkClick;
                        //e.Row.Cells[i].Controls.Add(lblmarks);

                        //e.Row.Cells[i].ToolTip = "Hi";

                        //message.InnerHtml = message.InnerHtml + " " +e.Row.Cells[4 + (int) ViewState["rowCount"]].Text;
                       // Int64 xsrow = Convert.ToInt64(e.Row.Cells[3 + (int)ViewState["rowCount"]].Text);


                        ////var xmarks = from amexamd in ((DataTable)ViewState["amexamd"]).AsEnumerable()
                        ////             where amexamd.Field<int>("zid") == _zid && amexamd.Field<int>("xrow") == Convert.ToInt32(list_t_row[i]) && amexamd.Field<Int64>("xsrow") == xsrow
                        ////             select amexamd;
                        /// 

                        //message.InnerHtml = message.InnerHtml + ((List<string>) ViewState["listtrow"])[i - 2].ToString() + "<br>";
                        Label lblmarks1 = new Label();
                        Label lblmarks2 = new Label();
                        Label lblmarks3 = new Label();
                        Label lblmarks4 = new Label();

                        if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-2")
                        {
                            lblmarks4 = new Label();
                            lblmarks4.Text = "";
                            lblmarks4.ID = "lblmarks" + i.ToString();
                            lblmarks4.ForeColor = Color.Black;
                            lblmarks4.Attributes.Add("runat", "server");
                            //lblmarks.Text = "1.00";
                            //lnkbtn.Click += OnLinkClick;
                            e.Row.Cells[i].Controls.Add(lblmarks4);

                        }
                        else if (((List<string>) ViewState["listtrow"])[i - 2].ToString() == "-1")
                        {
                            lblmarks1 = new Label();
                            lblmarks1.Text = "";
                            lblmarks1.ID = "lblmarks" + i.ToString();
                            lblmarks1.ForeColor = Color.Black;
                            lblmarks1.Attributes.Add("runat", "server");
                            //lblmarks.Text = "1.00";
                            //lnkbtn.Click += OnLinkClick;
                            e.Row.Cells[i].Controls.Add(lblmarks1);

                        }
                        else
                        {
                            lblmarks2 = new Label();
                            lblmarks2.Text = "";
                            lblmarks2.ID = "lblmarks" + i.ToString();
                            lblmarks2.ForeColor = Color.Black;
                            lblmarks2.Attributes.Add("runat", "server");
                            //lblmarks.Text = "1.00";
                            //lnkbtn.Click += OnLinkClick;
                            e.Row.Cells[i].Controls.Add(lblmarks2);

                            lblmarks3 = new Label();
                            lblmarks3.Text = "";
                            lblmarks3.ID = "lblmarks" + (i+1).ToString();
                            lblmarks3.ForeColor = Color.Black;
                            lblmarks3.Attributes.Add("runat", "server");
                            //lblmarks.Text = "1.00";
                            //lnkbtn.Click += OnLinkClick;
                            e.Row.Cells[i+1].Controls.Add(lblmarks3);

                            string[] type = ((List<string>) ViewState["listtrow"])[i - 2].Split('-');
                            xrefcttype1 = type[0];
                            xrefctno1 = type[1];
                            retestcount = 0;
                            mtcount = 0;

                        }

                        //message.InnerHtml = message.InnerHtml + xrefcttype1 + "-" + xrefctno1 + "<br>";
                        DataRow[] result =
                            ((DataTable)ViewState["amexamd"]).Select("zid=" + _zid + " and xsubject='" +
                                                                     (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
                                                                     (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "'" + " and xext='" +
                                                                     (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'" + " and xcttype='" + xrefcttype1 + "' and xctno='" + xrefctno1 + "'");
                        
                        if (result.Length > 0)
                        {
                            //if (result[0][0].ToString() != "-1.00")
                            //{
                                //if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-2")
                                //{
                                //    //lblmarks1.Text = result[0][0].ToString();
                                //    //e.Row.Cells[i].ToolTip = "Topic : " + result[0][1].ToString() + "\n" + "Details : " +
                                //    //"\n" + result[0][2].ToString();

                                //    mtcount = mtcount + 1;
                                //    int xid = mtcount;

                                //    DataRow[] result1 = ((DataTable)ViewState["amexammissedtestvw"]).Select("zid=" + _zid + " and xsubject='" +
                                //                                     (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
                                //                                     (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xext='" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'" + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'" + " and xid=" +
                                //                                      xid);


                                //    if (result1.Length > 0)
                                //    {
                                //        lblmarks4.Text = result1[0][0].ToString();
                                //        e.Row.Cells[i].ToolTip = "Topic : " + result1[0][1].ToString() + "\n" + "Details : " +
                                //                                 "\n" + result1[0][2].ToString();
                                //    }
                                //    else
                                //    {
                                //        lblmarks4.Text = "";
                                //    }

                                //}
                               if (((List<string>) ViewState["listtrow"])[i - 2].ToString() == "-1")
                                {
                                    //lblmarks1.Text = result[0][0].ToString();
                                    //e.Row.Cells[i].ToolTip = "Topic : " + result[0][1].ToString() + "\n" + "Details : " +
                                                             //"\n" + result[0][2].ToString();

                                    retestcount = retestcount + 1;
                                    int xid = retestcount;

                                    DataRow[] result1 = ((DataTable)ViewState["amexamretestvw"]).Select("zid=" + _zid + " and xsubject='" +
                                                                     (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
                                                                     (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xext='" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'" + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'" + " and xid=" +
                                                                      xid);


                                    if (result1.Length > 0)
                                    {
                                        lblmarks1.Text = result1[0][0].ToString();
                                        e.Row.Cells[i].ToolTip = "Topic : " + result1[0][1].ToString() + "\n" + "Details : " +
                                                                 "\n" + result1[0][2].ToString();
                                    }
                                    else
                                    {
                                        lblmarks1.Text = "";
                                    }

                                }
                                else
                                {
                                    if (result[0][0].ToString() != "-1.00")
                                    {
                                        lblmarks2.Text =
                                            Convert.ToDateTime(result[0][3].ToString()).ToString("dd/MM/yy") + "<br/>" +
                                            "Marks:" + Convert.ToDecimal(result[0][4].ToString()).ToString("###");
                                        lblmarks2.Font.Size = 9;
                                        lblmarks3.Text = result[0][0].ToString();
                                        e.Row.Cells[i + 1].ToolTip = "Topic : " + result[0][1].ToString() + "\n" +
                                                                     "Details : " +
                                                                     "\n" + result[0][2].ToString();
                                        if (Convert.ToInt32(result[0]["xismissedtest"].ToString()) == 1)
                                        {
                                            e.Row.Cells[i+1].BackColor = ColorTranslator.FromHtml("#8ED8F8");
                                        }
                                    }
                                    else
                                    {
                                        lblmarks2.Text = "";
                                        lblmarks3.Text = "";
                                    }
                                }
                            //}
                            //else
                            //{
                            //    lblmarks1.Text = "";
                            //    lblmarks2.Text = "";
                            //    lblmarks3.Text = "";
                            //    lblmarks4.Text = "";
                            //}
                        }
                        else
                        {
                            lblmarks1.Text = "";
                            lblmarks2.Text = "";
                            lblmarks3.Text = "";
                        }

                        if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-2")
                        {
                            i = i + 1;
                        }
                        else if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-1")
                        {
                            i = i + 1;
                        }
                        else
                        {
                            i = i + 2;
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


        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
               
                message.InnerHtml = "";

                xname.Text = "";
                _student.Value = "";

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
                
                fnFillDataGrid(null,null);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        private int flag;
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
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    _student.Value = "";
                    //BindGrid();
                    flag = 0;
                    
                    string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                    string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                    string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                    string xgroup1 = Request.QueryString["xgroup"] != null ? Request.QueryString["xgroup"].ToString() : "";
                    string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                    string xsrow1 = Request.QueryString["xsrow"] != null ? Request.QueryString["xsrow"].ToString() : "";
                    string xname1 = Request.QueryString["xname"] != null ? Request.QueryString["xname"].ToString() : "";

                    if (xsession1 != "" && xterm1 != "" && xclass1 != "" && xsection1 != "" && xsrow1 != "")
                    {
                        xsession.Text = xsession1;
                        xterm.Text = xterm1;
                        xclass.Text = xclass1;
                        xgroup.Text = xgroup1;
                        xsection.Text = xsection1;
                        _student.Value = xsrow1;
                        xname.Text = xname1;

                        
                        MasterPage m = this.Page.Master;
                        zglobal.fnDisableMasterPageContent(m);

                        fnFillDataGrid(null, null);

                        xsession.Enabled = false;
                        xterm.Enabled = false;
                        xclass.Enabled = false;
                        xgroup.Enabled = false;
                        xsection.Enabled = false;
                        xname.Enabled = false;
                        flag = 1;
                    }
                    

                    

                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }

     

       


        
    }
}