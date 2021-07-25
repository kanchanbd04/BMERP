using System;
using System.Collections.Generic;
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
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class amexamhh : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamhh",
            //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            ////if (ViewState["xrow"] == null)
            ////{
            ////    btnSubmit.Enabled = false;
            ////    btnSubmit1.Enabled = false;
            ////    btnSave.Enabled = true;
            ////    btnSave1.Enabled = true;
            ////    btnDelete.Enabled = true;
            ////    btnDelete1.Enabled = true;
            ////    //dxstatus.Visible = false;
            ////    dxstatus.Text = "-";
            ////}
            ////else
            ////{
            ////    //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ////    //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh",
            ////    //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            ////    //dxstatus.Visible = true;
            ////    if (xstatus1 == "New" || xstatus1 == "Undo")
            ////    {
            ////        btnSubmit.Enabled = true;
            ////        btnSubmit1.Enabled = true;
            ////        btnSave.Enabled = true;
            ////        btnSave1.Enabled = true;
            ////        btnDelete.Enabled = true;
            ////        btnDelete1.Enabled = true;
            ////        dxstatus.Text = xstatus1;
            ////        hxstatus.Value = xstatus1;
            ////        dxstatus.Style.Value = zglobal.am_new;

            ////    }
            ////    else
            ////    {
            ////        btnSubmit.Enabled = false;
            ////        btnSubmit1.Enabled = false;
            ////        btnSave.Enabled = false;
            ////        btnSave1.Enabled = false;
            ////        btnDelete.Enabled = false;
            ////        btnDelete1.Enabled = false;
            ////        dxstatus.Text = xstatus1;
            ////        hxstatus.Value = xstatus1;
            ////        dxstatus.Style.Value = zglobal.am_submited;


            ////    }

            ////    //if (xstatus1 == "New" || xstatus1 == "Undo")
            ////    //{
            ////    //    dxstatus.Style.Value = zglobal.am_new;
            ////    //}
            ////    //else
            ////    //{
            ////    //    dxstatus.Style.Value = zglobal.am_submited;
            ////    //}

            ////}

            //if (xstatus1 == "New" || xstatus1 == "Undo")
            //{
                
            //    btnUndo.Enabled = false;
            //    btnUndo1.Enabled = false;
            //    btnSave.Enabled = false;
            //    btnSave1.Enabled = false;
            //    btnApprove.Enabled = false;
            //    btnApprove1.Enabled = false;
            //    //dxstatus.Text = xstatus1;
            //    hxstatus.Value = xstatus1;
            //    //dxstatus.Style.Value = zglobal.am_new;

            //}
            //else if (xstatus1 == "Submited")
            //{
               
            //    btnUndo.Enabled = true;
            //    btnUndo1.Enabled = true;
            //    btnApprove.Enabled = true;
            //    btnApprove1.Enabled = true;
            //    //dxstatus.Text = xstatus1;
            //    hxstatus.Value = xstatus1;
            //    //dxstatus.Style.Value = zglobal.am_submited;
            //}
            //else if (xstatus1 == "Approved1" || xstatus1 == "Approved2")
            //{
            //    btnUndo.Enabled = true;
            //    btnUndo1.Enabled = true;
            //    btnApprove.Enabled = true;
            //    btnApprove1.Enabled = true;
            //    //dxstatus.Text = xstatus1;
            //    hxstatus.Value = xstatus1;
            //    //dxstatus.Style.Value = zglobal.am_submited;
            //}
            ////else if (xstatus1 == "Approved2" || xstatus1 == "Approved3")
            ////{
            ////    btnUndo.Enabled = false;
            ////    btnUndo1.Enabled = false;
            ////    btnApprove.Enabled = false;
            ////    btnApprove1.Enabled = false;
            ////    dxstatus.Text = xstatus1;
            ////    hxstatus.Value = xstatus1;
            ////    dxstatus.Style.Value = zglobal.am_submited;
            ////}
            //else if (xstatus1 == "Approved3")
            //{
            //    btnUndo.Enabled = false;
            //    btnUndo1.Enabled = false;
            //    btnApprove.Enabled = false;
            //    btnApprove1.Enabled = false;
            //    //dxstatus.Text = xstatus1;
            //    hxstatus.Value = xstatus1;
            //    //dxstatus.Style.Value = zglobal.am_submited;
            //}
            //else if (xstatus1 == "Undo1")
            //{
            //    btnUndo.Enabled = true;
            //    btnUndo1.Enabled = true;
            //    btnApprove.Enabled = true;
            //    btnApprove1.Enabled = true;
            //    //dxstatus.Text = xstatus1;
            //    hxstatus.Value = xstatus1;
            //    //dxstatus.Style.Value = zglobal.am_submited;
            //}
            ////else
            ////{
            ////    btnSubmit.Enabled = false;
            ////    btnSubmit1.Enabled = false;
            ////    btnSave.Enabled = false;
            ////    btnSave1.Enabled = false;
            ////    btnDelete.Enabled = false;
            ////    btnDelete1.Enabled = false;
            ////    dxstatus.Text = xstatus1;
            ////    hxstatus.Value = xstatus1;
            ////    dxstatus.Style.Value = zglobal.am_submited;


            ////}



            btnSubmit.Enabled = false;
            btnSubmit1.Enabled = false;
            //btnSave.Enabled = false;
            //btnSave1.Enabled = false;
            btnDelete.Enabled = false;
            btnDelete1.Enabled = false;
            btnApprove.Enabled = false;
            btnApprove1.Enabled = false;
            btnUndo.Enabled = false;
            btnUndo1.Enabled = false;

            //btnSave.Visible = false;
            //btnSave1.Visible = false;
            btnDelete.Visible = false;
            btnDelete1.Visible = false;
            btnSubmit.Visible = false;
            btnSubmit1.Visible = false;
            btnApprove.Visible = false;
            btnApprove1.Visible = false;
            btnUndo.Visible = false;
            btnUndo1.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    zglobal.fnGetComboDataCD("Subject Extension", xext);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    //xperc.Items.Add("");
                    //for (int i = 10; i <= 100; i = i + 5)
                    //{
                    //    xperc.Items.Add(i.ToString());
                    //}
                    //xperc.Text = "";
                    xperc.Visible = false;
                    //zglobal.fnGetComboDataCD("Test Type", xcttype);

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    //xpermission.Items.Add("");
                    //xpermission.Items.Add("Wrong Entry");
                    //xpermission.Items.Add("Missing Test");
                    //xpermission.Text = "";
                    ////zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    ViewState["xrow"] = null;
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";

                    fnButtonState();

                    result.Visible = false;
                    barchart.Visible = false;

                    //btnShowList.Visible = false;
                    //pnllistct.Visible = false;
                    //retestfor.Visible = false;
                    //xreason_d.Visible = false;
                    //xschdate.Enabled = false;
                    //schedule_d.Visible = false;


                    //xcttype.Enabled = false;
                    //xctno.Enabled = false;
                    //xreference.Enabled = false;
                    //xdate.Enabled = false;
                    //xmarks.Enabled = false;
                    //xreason.Enabled = false;

                    //string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                    //string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                    //string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                    //string xgroup1 = Request.QueryString["xgroup"] != null ? Request.QueryString["xgroup"].ToString() : "";
                    //string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                    //string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
                    //string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
                    //string xcttype1 = Request.QueryString["xcttype"] != null ? Request.QueryString["xcttype"].ToString() : "";
                    //string xctno1 = Request.QueryString["xctno"] != null ? Request.QueryString["xctno"].ToString() : "";

                    //if (xsession1 != "" && xterm1 != "" && xclass1 != "" && xsection1 != "" && xsubject1 != "" && xcttype1 != "" && xctno1 != "")
                    //{
                    //    xsession.Text = xsession1;
                    //    xterm.Text = xterm1;
                    //    xclass.Text = xclass1;
                    //    xgroup.Text = xgroup1;
                    //    xsection.Text = xsection1;
                    //    xsubject.Text = xsubject1;
                    //    xpaper.Text = xpaper1;

                    //    combo_OnTextChanged(null, null);

                    //    xcttype.Text = xcttype1;
                    //    xcttype_Click(null, null);

                    //    xctno.Text = xctno1;
                    //    xctno_Click(null, null);
                    //}

                    //btnSave1.Enabled = false;
                    //btnSave.Enabled = false;
                    //btnApprove.Enabled = false;
                    //btnApprove1.Enabled = false;

                    //xtbest.Enabled = false;
                    //xperc.Enabled = false;
                    hiscom.Value = "0";

                    _xext.Visible = false;
                    _xpaper.Visible = false;

                }

                //if (xtbest.Text != "" && xperc.Text != "" && ViewState["xgvshow"].ToString() == "yes")
                if (xtbest.Text != ""  && ViewState["xgvshow"].ToString() == "yes")
                {
                    BindGrid();

                }


              

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
        List<string> listtest = new List<string>();
        List<int> listretest = new List<int>();
        List<string> listtrow = new List<string>();
        List<string> listmaxrtcount = new List<string>();
        List<string> listretestrow = new List<string>();
        List<int> listmissedtest = new List<int>();
        private void BindGrid()
        {

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ViewState["xrow"] = null;

            //string xrow = zglobal.fnGetValue("xrow", "amexamh",
            //     "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
            //     "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xsubject='" + xsubject.Text.Trim().ToString() + "' and xpaper='" + xpaper.Text.Trim().ToString() + "'" + " and xstatus in('Approved2','Approved3')");
            ////if (ViewState["xrow"] == null)
            //if (xrow == "")
            //{
            //    message.InnerHtml = "No data found.";
            //    message.Style.Value = zglobal.am_warningmsg;
            //    //dxstatus.Visible = false;
            //    //dxstatus.Text = "Status : ";
            //    //dxstatus.Style.Value = zglobal.am_submited;
            //    return;
            //}


            fnResult();

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
            string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";

            //string str = "SELECT ROW_NUMBER() OVER (ORDER BY xcttype desc, xctno asc) AS xid,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //    "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper order by xstdid";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {

                GridView1.Columns.Clear();

                //TemplateField tfield119 = new TemplateField();
                //tfield119.HeaderText = "No.";
                //tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield119.ItemStyle.Width = 35;
                //GridView1.Columns.Add(tfield119);

                bfield = new BoundField();
                bfield.HeaderText = "No.";
                //bfield.ShowHeader = false;
                bfield.DataField = "xid";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.ItemStyle.Width = 35;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "ID";
                //bfield.ShowHeader = false;
                bfield.DataField = "xstdid";
                bfield.ItemStyle.Width = 50;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Student's Name";
                //bfield.ShowHeader = false;
                bfield.DataField = "xname";
                bfield.ItemStyle.Width = 200;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);


                //Generating coloum for all test
                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') and coalesce(xext,'')=@xext ORDER BY xdate";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int rowCount = 0;
                    listtest.Clear();
                    listtrow.Clear();
                    listretest.Clear();
                    listmaxrtcount.Clear();
                    listretestrow.Clear();
                    listmissedtest.Clear();

                    while (rdr.Read())
                    {
                        //if (rowCount == 0)
                        //{
                        //    dxstatus.Visible = true;
                        //    dxstatus.Text = "Status : " + rdr["xstatus"].ToString();
                        //    dxstatus.Style.Value = zglobal.am_submited;
                        //}

                        tfield = new TemplateField();
                        tfield.HeaderText = Convert.ToDateTime(rdr["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(rdr["xmarks"].ToString()).ToString("###");
                        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        tfield.ItemStyle.Width = 80;
                        GridView1.Columns.Add(tfield);


                        listtest.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                        listtrow.Add(rdr["xrow"].ToString());
                        rowCount = rowCount + 1;

                        //Generate column for retest
                        string maxretest = zglobal.fnGetValue("max(xid)", "amexamretestvw",
                           "zid='" + _zid + "' AND xsession='" + xsession.Text.ToString().Trim() + "' AND xclass='" + xclass.Text.ToString().Trim() +
                           "' AND xterm='" + xterm.Text.ToString().Trim() + "' AND xgroup='" + xgroup.Text.ToString().Trim() +
                           "' AND xtype='Class Test'  AND xsection='" + xsection.Text.ToString().Trim() +
                           "' AND xsubject='" + xsubject.Text.ToString().Trim() + "' AND xpaper='" + xpaper.Text.ToString().Trim() +
                           "' AND xcttype in('Retest') AND xrefcttype='" + rdr["xcttype"].ToString() + "' AND xrefctno='" + rdr["xctno"].ToString() + "' AND xstatus in('Approved2','Approved3') AND coalesce(xext,'')='"+xext.Text.Trim().ToString()+"'");
                        //message.InnerHtml = message.InnerHtml + maxretest;
                        int retest_count = 0;
                        int maxrtcount = 0;
                        if (maxretest != null && maxretest != "")
                        {

                            for (int i = 1; i <= Convert.ToInt32(maxretest); i++)
                            {
                                tfield = new TemplateField();
                                //tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                                tfield.HeaderText = "Retest";
                                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                tfield.ItemStyle.Width = 40;
                                tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                                tfield.HeaderStyle.ForeColor = Color.DimGray;
                                tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                                GridView1.Columns.Add(tfield);
                                retest_count = retest_count + 1;
                                rowCount = rowCount + 1;

                                listtrow.Add("-1");
                            }

                            //using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                            //{
                            //    using (DataSet dts1 = new DataSet())
                            //    {
                            //        // query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Retest') AND xrefcttype=@xrefcttype AND xrefctno=@xrefctno AND xstatus in('Approved2','Approved3') ORDER BY xdate";
                            //        query = "SELECT xrow FROM amexamretestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Retest') AND xrefcttype=@xrefcttype AND xrefctno=@xrefctno AND xstatus in('Approved2','Approved3') AND xid<=@xid ";

                            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xrefcttype", rdr["xcttype"].ToString());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xrefctno", rdr["xctno"].ToString());
                            //        da1.SelectCommand.Parameters.AddWithValue("@xid", maxretest);

                            //        da1.Fill(dts1, "tempztcode");
                            //        DataTable dtamexam = new DataTable();
                            //        dtamexam = dts1.Tables[0];

                            //        // int retest_count = 0;
                            //        if (dtamexam.Rows.Count > 0)
                            //        {

                            //            foreach (DataRow row in dtamexam.Rows)
                            //            {

                            //                //tfield = new TemplateField();
                            //                ////tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                            //                //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            //                //tfield.ItemStyle.Width = 60;
                            //                //tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                            //                //tfield.HeaderStyle.ForeColor = Color.DimGray;
                            //                //tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                            //                //GridView1.Columns.Add(tfield);

                            //                //listtest.Add(row["xcttype"].ToString() + "-" + row["xctno"].ToString());
                            //                listretestrow.Add(row["xrow"].ToString());
                            //                // rowCount = rowCount + 1;
                            //                // retest_count = retest_count + 1;
                            //            }

                            //        }
                            //        //listretest.Add(retest_count);
                            //    }
                            //}

                        }
                        //else
                        //{

                        //}
                        listretest.Add(retest_count);


                        //Generate column for missed-test
                        string maxmissedtest = zglobal.fnGetValue("max(xid)", "amexammissedtestvw",
                           "zid='" + _zid + "' AND xsession='" + xsession.Text.ToString().Trim() + "' AND xclass='" + xclass.Text.ToString().Trim() +
                           "' AND xterm='" + xterm.Text.ToString().Trim() + "' AND xgroup='" + xgroup.Text.ToString().Trim() +
                           "' AND xtype='Class Test'  AND xsection='" + xsection.Text.ToString().Trim() +
                           "' AND xsubject='" + xsubject.Text.ToString().Trim() + "' AND xpaper='" + xpaper.Text.ToString().Trim() +
                           "' AND coalesce(xext,'')='" + xext.Text.Trim().ToString() + "' AND xcttype in('Missed Test') AND xrefcttype='" + rdr["xcttype"].ToString() + "' AND xrefctno='" + rdr["xctno"].ToString() + "' AND xstatus in('Approved2','Approved3')");
                        //message.InnerHtml = message.InnerHtml + maxretest;
                        int missedtest_count = 0;
                        int maxmtcount = 0;
                        if (maxmissedtest != null && maxmissedtest != "")
                        {

                            for (int i = 1; i <= Convert.ToInt32(maxmissedtest); i++)
                            {
                                tfield = new TemplateField();
                                //tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                                tfield.HeaderText = "Missed Test";
                                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                tfield.ItemStyle.Width = 40;
                                tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#8ED8F8");
                                tfield.HeaderStyle.ForeColor = Color.DimGray;
                                tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#8ED8F8");
                                GridView1.Columns.Add(tfield);
                                missedtest_count = missedtest_count + 1;
                                rowCount = rowCount + 1;

                                listtrow.Add("-2");
                            }
                        }

                        listmissedtest.Add(missedtest_count);

                        //using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                        //{
                        //    using (DataSet dts1 = new DataSet())
                        //    {
                        //        // query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Retest') AND xrefcttype=@xrefcttype AND xrefctno=@xrefctno AND xstatus in('Approved2','Approved3') ORDER BY xdate";
                        //        query = "SELECT * FROM amexamretestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Retest') AND xrefcttype=@xrefcttype AND xrefctno=@xrefctno AND xstatus in('Approved2','Approved3') AND xid<=@xid order by xstdid,xdate,xid";

                        //        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                        //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xrefcttype", rdr["xcttype"].ToString());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xrefctno", rdr["xctno"].ToString());
                        //        da1.SelectCommand.Parameters.AddWithValue("@xid", maxretest);

                        //        da1.Fill(dts1, "tempztcode");
                        //        DataTable dtamexam = new DataTable();
                        //        dtamexam = dts1.Tables[0];

                        //       // int retest_count = 0;
                        //        if (dtamexam.Rows.Count > 0)
                        //        {

                        //            foreach (DataRow row in dtamexam.Rows)
                        //            {

                        //                //tfield = new TemplateField();
                        //                ////tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                        //                //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //                //tfield.ItemStyle.Width = 60;
                        //                //tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                        //                //tfield.HeaderStyle.ForeColor = Color.DimGray;
                        //                //tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                        //                //GridView1.Columns.Add(tfield);

                        //                //listtest.Add(row["xcttype"].ToString() + "-" + row["xctno"].ToString());
                        //                listtrow.Add(row["xrow"].ToString());
                        //                rowCount = rowCount + 1;
                        //               // retest_count = retest_count + 1;
                        //            }

                        //        }
                        //        //listretest.Add(retest_count);
                        //    }
                        //}

                    }

                    //if (rowCount == 0)
                    //{
                    //    dxstatus.Visible = false;
                    //    dxstatus.Text = "Status : ";
                    //    dxstatus.Style.Value = zglobal.am_submited;
                    //}

                    ViewState["listretest"] = listretest;
                    ViewState["listmissedtest"] = listmissedtest;
                    ViewState["listtest"] = listtest;
                    ViewState["listtrow"] = listtrow;
                    ViewState["rowCount"] = rowCount;
                    xgcol.Value = rowCount.ToString();
                }

                string xrow2 = "";

                for (int i = 0; i < listtrow.Count; i++)
                {
                    if (i == listtrow.Count - 1)
                    {
                        xrow2 = xrow2 + listtrow[i].ToString();
                    }
                    else
                    {
                        xrow2 = xrow2 + listtrow[i].ToString() + ",";
                    }
                }


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xcttype,amexamh.xctno,amexamh.xrow as xrow,amexamd.xremarks1 as xremarks1,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        // da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow2);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamd"] = dtamexamd;

                    }
                }





                //string xrow3 = "";

                //for (int i = 0; i < listretestrow.Count; i++)
                //{
                //    if (i == listretestrow.Count - 1)
                //    {
                //        xrow3 = xrow3 + listretestrow[i].ToString();
                //    }
                //    else
                //    {
                //        xrow3 = xrow3 + listretestrow[i].ToString() + ",";
                //    }
                //}

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xgetmark,xtopic,xdetails,* FROM amexamretestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xcttype in('Retest') AND xstatus in('Approved2','Approved3')";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamretestvw"] = dtamexamd;

                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xgetmark,xtopic,xdetails,* FROM amexammissedtestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xcttype in('Missed Test') AND xstatus in('Approved2','Approved3')";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexammissedtestvw"] = dtamexamd;

                    }
                }




                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT * FROM amexammaxmarkvw2 WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper  AND  coalesce(xext,'')=@xext";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexammaxmarkvw2"] = dtamexamd;

                    }
                }

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts1 = new DataSet())
                //    {
                //        string query = "SELECT * FROM amexamvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper  AND  coalesce(xext,'')=@xext and xstatus in ('Approved2','Approved3')";

                //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                //        da1.Fill(dts1, "tempztcode");
                //        DataTable dtamexamd = new DataTable();
                //        dtamexamd = dts1.Tables[0];

                //        ViewState["amexamvw123"] = dtamexamd;

                //    }
                //}



                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts1 = new DataSet())
                //    {
                //        string query = "SELECT xremarks,* FROM amexamhh inner join amexamhhd on amexamhh.zid=amexamhhd.zid and amexamhh.xrow=amexamhhd.xrow WHERE amexamhh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' and coalesce(xext,'')=@xext";

                //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                //        da1.Fill(dts1, "tempztcode");
                //        DataTable dtamexamd = new DataTable();
                //        dtamexamd = dts1.Tables[0];
                //        if (dtamexamd.Rows.Count > 0)
                //        {
                //            ViewState["amexamhhd"] = dtamexamd;
                //        }
                //        else
                //        {
                //            ViewState["amexamhhd"] = null;
                //        }

                //    }
                //}

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT xremarks,* FROM amexamhhdtemp WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper ";
                        string query = "SELECT xremarks,* FROM amexamhhd1 WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper and coalesce(xext,'')=@xext";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["amexamhhdtemp"] = dtamexamd;
                        }
                        else
                        {
                            ViewState["amexamhhdtemp"] = null;
                        }

                    }
                }

                ////foreach (DataRow row in ((DataTable)ViewState["amexamd"]).Rows)
                ////{
                ////    Response.Write(row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " <br>");
                ////}

                //TemplateField tfield3 = new TemplateField();
                //tfield3.HeaderText = "C. Test";//+ "<br />" + xperc.Text.Trim().ToString();
                //tfield3.ItemStyle.Width = 50;
                //tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield3.ItemStyle.BackColor = ColorTranslator.FromHtml("#B6D993");
                //GridView1.Columns.Add(tfield3);

                TemplateField tfield1 = new TemplateField();
                tfield1.HeaderText = "Comments";
                tfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield1.ItemStyle.Width = Unit.Pixel(250);
                GridView1.Columns.Add(tfield1);

                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield2.ItemStyle.Width = Unit.Pixel(30);
                GridView1.Columns.Add(tfield2);

                //TemplateField tfield2 = new TemplateField();
                //tfield2.HeaderText = "";
                //tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //GridView1.Columns.Add(tfield2);

                BoundField bfield1 = new BoundField();
                bfield1.DataField = "xrow";
                GridView1.Columns.Add(bfield1);

                

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                //int i = 1;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Label lbl = (Label)row.FindControl("lblno");
                //    lbl.Text = i.ToString();
                //    i++;
                //}

                bfield1.Visible = false;




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
                ////    if (data != 0)
                ////    {
                ////        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = data;
                ////        for (int m = 2; m <= data; m++)
                ////        {
                ////            GridView1.HeaderRow.Cells[k + m].Visible = false;
                ////        }
                ////        k = k + data + 1;
                ////    }
                ////    else
                ////    {
                ////        k = k + 1;
                ////    }

                ////}

                List<int> listrt = (List<int>)ViewState["listretest"];
                List<int> listmt = (List<int>)ViewState["listmissedtest"];

                //for (int j = 0; j < listrt.Count; j++)
                //{
                //    if (listrt[j] != 0)
                //    {
                //        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = listrt[j];
                //        for (int m = 2; m <= listrt[j]; m++)
                //        {
                //            GridView1.HeaderRow.Cells[k + m].Visible = false;
                //        }
                //        k = k + listrt[j] + 1;
                //    }
                //    else
                //    {
                //        k = k + 1;
                //    }

                //    l = k;

                //    if (listmt[j] != 0)
                //    {
                //        GridView1.HeaderRow.Cells[l].ColumnSpan = listmt[j];
                //        for (int m = 1; m <= listmt[j]; m++)
                //        {
                //            GridView1.HeaderRow.Cells[l + m].Visible = false;
                //        }
                //        //l = l + listrt[j] + 1;
                //    }
                //    //else
                //    //{
                //    //    l = l + 1;
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
                            GridView1.HeaderRow.Cells[k-l-1].ColumnSpan = l+1;
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

                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();

                GridView1.HeaderRow.Cells[0].Visible = false;
                GridView1.HeaderRow.Cells[1].Visible = false;
                GridView1.HeaderRow.Cells[2].Visible = false;


                cell = new TableHeaderCell();
                cell.Text = "No.";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "ID";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Student's Name";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                //GridView1.Rows[0].Cells[0].RowSpan = 2;
                //GridView1.Rows[0].Cells[1].RowSpan = 2;
                //GridView1.Rows[0].Cells[2].RowSpan = 2;
                //int i = 0;
                //foreach (string date in (List<string>)ViewState["listtest"])
                //{
                //    cell = new TableHeaderCell();
                //    cell.ColumnSpan = ((List<int>)ViewState["listretest"])[i] + 1;
                //    cell.Text = date;
                //    cell.BorderStyle = BorderStyle.Solid;
                //    cell.BorderWidth = 2;
                //    cell.BorderColor = Color.White;
                //    row.Controls.Add(cell);

                //    i = i + 1;
                //}

                int i = 0;
                foreach (string date in (List<string>)ViewState["listtest"])
                {
                    cell = new TableHeaderCell();
                    cell.ColumnSpan = ((List<int>)ViewState["listretest"])[i] + listmt[i] + 1;
                    //cell.ColumnSpan = ((List<int>)ViewState["listretest"])[i]  + 1;
                    cell.Text = date;
                    cell.BorderStyle = BorderStyle.Solid;
                    cell.BorderWidth = 2;
                    cell.BorderColor = Color.White;
                    row.Controls.Add(cell);

                    i = i + 1;
                }

                GridView1.HeaderRow.Cells[(int)ViewState["rowCount"] + 3].Visible = false;
                GridView1.HeaderRow.Cells[(int)ViewState["rowCount"] + 4].Visible = false;
                //GridView1.HeaderRow.Cells[(int)ViewState["rowCount"] + 5].Visible = false;

                //cell = new TableHeaderCell();
                //cell.Text = "C. Test" + "<br />" + xperc.Text.Trim().ToString() + "%";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Comments";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "";
                cell.RowSpan = 2;
                row.Controls.Add(cell);
                // row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
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
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    List<string> list_t_row = (List<string>)ViewState["listtrow"];
                    int retestcount = 0;
                    int mtcount = 0;
                    string xrefcttype1 = "";
                    string xrefctno1 = "";


                    TextBox txtComments = new TextBox();
                    txtComments.ID = "txtComments";
                    txtComments.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    txtComments.TextMode = TextBoxMode.MultiLine;
                    txtComments.Attributes.Add("onkeyup", "enter(this,event)");
                    //e.Row.Cells[4 + (int)ViewState["rowCount"]].Controls.Add(txtComments);
                    e.Row.Cells[3 + (int)ViewState["rowCount"]].Controls.Add(txtComments);

                    HtmlGenericControl image = new HtmlGenericControl("img");
                    image.ID = "image2";
                    image.Attributes.Add("src", "/images/list-am32x32.png");
                    image.Attributes.Add("class", "bm_academic_list bm_list");
                    image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
                    //e.Row.Cells[5 + (int)ViewState["rowCount"]].Controls.Add(image);
                    e.Row.Cells[4 + (int)ViewState["rowCount"]].Controls.Add(image);

                    //Int64 xsrow = Convert.ToInt64(e.Row.Cells[6 + (int)ViewState["rowCount"]].Text);
                    Int64 xsrow = Convert.ToInt64(e.Row.Cells[5 + (int)ViewState["rowCount"]].Text);

                    //if (ViewState["amexamhhd"] != null)
                    //{
                    //    //DataRow[] result80 =
                    //    //    ((DataTable)ViewState["amexamhhd"]).Select("zid=" + _zid + "  and xsrow=" + xsrow);
                    //    //if (result80.Length > 0)
                    //    //{
                    //    //    txtComments.Text = result80[0][0].ToString();
                    //    //    txtComments.Enabled = false;
                    //    //}

                    //    txtComments.Enabled = false;
                    //}
                    //else if (ViewState["amexamhhdtemp"] != null)
                    //{
                    //    DataRow[] result80 =
                    //        ((DataTable)ViewState["amexamhhdtemp"]).Select("zid=" + _zid + "  and xsrow=" + xsrow);
                    //    if (result80.Length > 0)
                    //    {
                    //        txtComments.Text = result80[0][0].ToString();
                    //    }
                    //}


                    if (ViewState["amexamhhdtemp"] != null)
                    {
                        DataRow[] result80 =
                            ((DataTable)ViewState["amexamhhdtemp"]).Select("zid=" + _zid + "  and xsrow=" + xsrow);
                        if (result80.Length > 0)
                        {
                            txtComments.Text = result80[0][0].ToString();
                        }
                    }

                    decimal best = 0;
                    List<int> xrowList = new List<int>();

                    for (int i = 3; i < 3 + (int)ViewState["rowCount"]; i = i + 1)
                    {

                        Label lblmarks = new Label();
                        lblmarks.Text = "";
                        lblmarks.ID = "lblmarks" + i.ToString();
                        lblmarks.ForeColor = Color.Black;
                        lblmarks.Attributes.Add("runat", "server");
                        //lblmarks.Text = "1.00";
                        //lnkbtn.Click += OnLinkClick;
                        e.Row.Cells[i].Controls.Add(lblmarks);

                        

                        //e.Row.Cells[i].ToolTip = "Hi";

                        //message.InnerHtml = message.InnerHtml + " " +e.Row.Cells[4 + (int) ViewState["rowCount"]].Text;
                        //Int64 xsrow = Convert.ToInt64(e.Row.Cells[6 + (int)ViewState["rowCount"]].Text);

                        ////var xmarks = from amexamd in ((DataTable)ViewState["amexamd"]).AsEnumerable()
                        ////             where amexamd.Field<int>("zid") == _zid && amexamd.Field<int>("xrow") == Convert.ToInt32(list_t_row[i]) && amexamd.Field<Int64>("xsrow") == xsrow
                        ////             select amexamd;

                        DataRow[] result =
                            ((DataTable)ViewState["amexamd"]).Select("zid=" + _zid + " and xrow=" +
                                                                      Convert.ToInt32(((List<string>)ViewState["listtrow"])[i - 3]) + " and xsrow=" +
                                                                      xsrow);


                        //foreach (DataRow row in result)
                        //{
                        //    lblmarks.Text = row[7].ToString();
                        //}
                        if (result.Length > 0)
                        {
                            if (result[0][0].ToString() != "-1.00")
                            {
                                lblmarks.Text = result[0][0].ToString();
                                e.Row.Cells[i].ToolTip = "Topic : " + result[0][1].ToString() + "\n" + "Details : " +
                                                         "\n" + result[0][2].ToString();


                            //    if (xtbest.Text != "")
                            //    {
                            //        DataRow[] result10 =
                            //((DataTable)ViewState["amexammaxmarkvw3"]).Select("zid=" + _zid + " and xrow=" +
                            //                                          Convert.ToInt32(result[0][5].ToString()) + " and xsrow=" +
                            //                                          xsrow);
                            //        if (result10.Length > 0)
                            //        {
                            //            if (Convert.ToInt32(result10[0][2].ToString()) <= Convert.ToInt32(xtbest.Text) &&
                            //                result10[0][3].ToString() == "1")
                            //            {
                            //                //best = Convert.ToDecimal(result[0][0].ToString());
                            //                ((Label)e.Row.FindControl("lblmarks" + i.ToString())).ForeColor = ColorTranslator.FromHtml("#64B446");
                            //                ((Label)e.Row.FindControl("lblmarks" + i.ToString())).Font.Bold = true;
                            //                ((Label)e.Row.FindControl("lblmarks" + i.ToString())).Font.Size = 12;
                            //                xrowList.Add(Convert.ToInt32(result[0][5].ToString()));
                            //            }

                            //        }
                            //    }
                            }
                            else
                            {
                                lblmarks.Text = "";
                            }

                            if (xtbest.Text != "")
                            {
                                DataRow[] result10 =
                        ((DataTable)ViewState["amexammaxmarkvw2"]).Select("zid=" + _zid + " and xrow=" +
                                                                  Convert.ToInt32(result[0]["xrow"].ToString()) + " and xsrow=" +
                                                                  xsrow);
                                if (result10.Length > 0)
                                {
                                    if (Convert.ToInt32(result10[0]["xid"].ToString()) <= Convert.ToInt32(xtbest.Text))
                                    {
                                        //best = Convert.ToDecimal(result[0][0].ToString());
                                        ((Label)e.Row.FindControl("lblmarks" + i.ToString())).ForeColor = ColorTranslator.FromHtml("#64B446");
                                        ((Label)e.Row.FindControl("lblmarks" + i.ToString())).Font.Bold = true;
                                        ((Label)e.Row.FindControl("lblmarks" + i.ToString())).Font.Size = 12;
                                        xrowList.Add(Convert.ToInt32(result[0]["xrow"].ToString()));
                                    }

                                }
                            }

                            retestcount = 0;
                            mtcount = 0;
                            xrefcttype1 = result[0][3].ToString();
                            xrefctno1 = result[0][4].ToString();
                            //message.InnerHtml = message.InnerHtml + xrefcttype1 + "-" + xrefctno1 + "<br>";

                        }
                        else
                        {
                            //lblmarks.Text = "";

                            if (Convert.ToInt32(((List<string>)ViewState["listtrow"])[i - 3]) == -1)
                            {
                                retestcount = retestcount + 1;
                                int xid = retestcount;

                                DataRow[] result1 = ((DataTable)ViewState["amexamretestvw"]).Select("zid=" + _zid + " and xid=" +
                                                                      xid + " and xsrow=" +
                                                                      xsrow + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'");


                                if (result1.Length > 0)
                                {
                                    lblmarks.Text = result1[0][0].ToString();
                                    e.Row.Cells[i].ToolTip = "Topic : " + result1[0][1].ToString() + "\n" + "Details : " +
                                                             "\n" + result1[0][2].ToString();
                                    if (xtbest.Text != "")
                                    {
                                        DataRow[] result11 =
                             ((DataTable)ViewState["amexammaxmarkvw2"]).Select("zid=" + _zid + " and xrow=" +
                                                                       Convert.ToInt32(result1[0]["xrow"].ToString()) + " and xsrow=" +
                                                                       xsrow);
                                        if (result11.Length > 0)
                                        {
                                            //message.InnerHtml = result11[0][0].ToString() + "-";
                                            if (Convert.ToInt32(result11[0]["xid"].ToString()) <= Convert.ToInt32(xtbest.Text) )
                                            {
                                                //best = Convert.ToDecimal(result[0][0].ToString());
                                                ((Label) e.Row.FindControl("lblmarks" + i.ToString())).ForeColor =
                                                    ColorTranslator.FromHtml("#64B446");
                                                ((Label) e.Row.FindControl("lblmarks" + i.ToString())).Font.Bold = true;
                                                ((Label) e.Row.FindControl("lblmarks" + i.ToString())).Font.Size = 12;
                                                xrowList.Add(Convert.ToInt32(result1[0]["xrow"].ToString()));
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    lblmarks.Text = "";
                                }

                                //message.InnerHtml = message.InnerHtml + xid + " " + xrefcttype1 + " " + xrefctno1 + " " +
                                //                    xsrow + "<br>";
                            }
                            else if (Convert.ToInt32(((List<string>)ViewState["listtrow"])[i - 3]) == -2)
                            {
                                mtcount = mtcount + 1;
                                int xid1 = mtcount;

                                DataRow[] result11 = ((DataTable)ViewState["amexammissedtestvw"]).Select("zid=" + _zid + " and xid=" +
                                                                      xid1 + " and xsrow=" +
                                                                      xsrow + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'");


                                if (result11.Length > 0)
                                {
                                    lblmarks.Text = result11[0][0].ToString();
                                    e.Row.Cells[i].ToolTip = "Topic : " + result11[0][1].ToString() + "\n" + "Details : " +
                                                             "\n" + result11[0][2].ToString();

                                    if (xtbest.Text != "")
                                    {
                                        DataRow[] result110 =
                             ((DataTable)ViewState["amexammaxmarkvw2"]).Select("zid=" + _zid + " and xrow=" +
                                                                       Convert.ToInt32(result11[0]["xrow"].ToString()) + " and xsrow=" +
                                                                       xsrow);
                                        if (result110.Length > 0)
                                        {
                                            if (Convert.ToInt32(result110[0]["xid"].ToString()) <= Convert.ToInt32(xtbest.Text) )
                                            {
                                                //best = Convert.ToDecimal(result[0][0].ToString());
                                                ((Label)e.Row.FindControl("lblmarks" + i.ToString())).ForeColor =
                                                    ColorTranslator.FromHtml("#64B446");
                                                ((Label)e.Row.FindControl("lblmarks" + i.ToString())).Font.Bold = true;
                                                ((Label)e.Row.FindControl("lblmarks" + i.ToString())).Font.Size = 12;
                                                xrowList.Add(Convert.ToInt32(result11[0]["xrow"].ToString()));
                                            }

                                        }
                                    }

                                }
                                else
                                {
                                    lblmarks.Text = "";
                                }

                                //message.InnerHtml = message.InnerHtml + xid + " " + xrefcttype1 + " " + xrefctno1 + " " +
                                //                    xsrow + "<br>";
                            }
                            else
                            {
                                lblmarks.Text = "U";
                            }

                        }

                    }

                    //Calculate Parcentage of Marks
                    //if (xtbest.Text != "" && xperc.Text != "")
                    //if (xtbest.Text != "")
                    //{
                    //    xperc.Text = "100";
                    //    if (xrowList.Count > 0)
                    //    {
                    //        string xrow2 = "";
                    //        for (int i = 0; i < xrowList.Count; i++)
                    //        {
                    //            if (i == xrowList.Count - 1)
                    //            {
                    //                xrow2 = xrow2 + xrowList[i].ToString();
                    //            }
                    //            else
                    //            {
                    //                xrow2 = xrow2 + xrowList[i].ToString() + ",";
                    //            }
                    //        }


                    //        DataRow[] result20 =
                    //        ((DataTable)ViewState["amexammaxmarkvw2"]).Select("zid=" + _zid + " and xrow in(" +
                    //                                                               xrow2 + ") and xsrow=" +
                    //                                                               xsrow + " and xid<= " + xtbest.Text.Trim().ToString());

                    //       // DataRow[] result20 =
                    //       //((DataTable)ViewState["amexamvw123"]).Select("zid=" + _zid + " and xrow in(" +
                    //       //                                                       xrow2 + ") and xsrow=" +
                    //       //                                                       xsrow);

                    //        //foreach (DataRow row in result20)
                    //        //{
                    //        //    message.InnerHtml = message.InnerHtml + result20[0]["xmarks"].ToString() + " " +
                    //        //                        result20[0]["xgetmark"].ToString() + " ";
                    //        //}
                    //        //message.InnerHtml = message.InnerHtml + "<br />";

                    //        if (result20.Length > 0)
                    //        {
                    //            decimal marks = 0;
                    //            decimal getmark = 0;
                    //            int n = 0;
                    //            foreach (DataRow row in result20)
                    //            {
                    //                //DataRow[] result201 =
                    //                //((DataTable)ViewState["amexamvw123"]).Select("zid=" + _zid + " and xrow=" + row["xrow"] + " and xsrow=" +
                    //                //                                              xsrow);
                    //                marks = marks + Convert.ToDecimal(result20[0]["xmarks"].ToString());
                    //                if (Convert.ToDecimal(result20[0]["xgetmark"].ToString()) != -1)
                    //                {
                    //                    getmark = getmark + Convert.ToDecimal(result20[0]["xgetmark"].ToString());
                    //                }
                    //                else
                    //                {
                    //                    getmark = getmark + 0;
                    //                }

                    //                n = n + 1;
                    //            }

                    //            decimal parcent = (getmark * Convert.ToInt32(xperc.Text)) / marks;

                    //            e.Row.Cells[3 + (int)ViewState["rowCount"]].Text = parcent.ToString("F");

                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void OnLinkClick(object sender, EventArgs e)
        {
            try
            {
                //LinkButton lb = (LinkButton) sender;
                //GridViewRow row = (GridViewRow) lb.NamingContainer;
                //if (row != null)
                //{
                //    //message.InnerHtml = lb.ID.ToString();
                //    int xcellno = int.Parse(lb.ID.ToString().Substring(9));
                //    //message.InnerHtml = lb.ID.ToString().Substring(9);
                //    lbldate.Text = Convert.ToDateTime(row.Cells[2 + (int) ViewState["rowCount"]].Text).ToString("dddd, MMMM dd, yyyy");
                //    lblperiod.Text = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //    lblsection.Text = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //    _xdate.Value = row.Cells[2 + (int) ViewState["rowCount"]].Text.ToString();
                //    _xperiod.Value = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //    _xsection.Value = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {
                //        using (DataSet dts = new DataSet())
                //        {
                //            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //            int xrow = Convert.ToInt32(ViewState["xrow"]);
                //            DateTime xdate2 = Convert.ToDateTime(row.Cells[2 + (int)ViewState["rowCount"]].Text);
                //            string xperiod2 = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //            string xsection2 = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //            string query = "SELECT xsubject,xpaper,xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, " +
                //                " (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1,xcteacher,xsteacher FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                //            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                //            da.Fill(dts, "tempTable");
                //            DataTable tempTable = new DataTable();
                //            tempTable = dts.Tables["tempTable"];

                //            if (tempTable.Rows.Count > 0)
                //            {
                //                xsubject.Text = tempTable.Rows[0]["xsubject"].ToString();
                //                xpaper.Text = tempTable.Rows[0]["xpaper"].ToString();
                //                xtopic.Value = tempTable.Rows[0]["xtopic"].ToString();
                //                xdetails.Value = tempTable.Rows[0]["xdetails"].ToString();
                //                xcteacher.Text = tempTable.Rows[0]["xcteacher1"].ToString();
                //                xsteacher.Text = tempTable.Rows[0]["xsteacher1"].ToString();
                //                _classteacher.Value = tempTable.Rows[0]["xcteacher"].ToString();
                //                _subteacher.Value = tempTable.Rows[0]["xsteacher"].ToString();
                //            }
                //            else
                //            {
                //                xsubject.Text = "";
                //                xpaper.Text = "";
                //                xtopic.Value = "";
                //                xdetails.Value = "";
                //                xcteacher.Text = "";
                //                xsteacher.Text = "";
                //                _classteacher.Value = "";
                //                _subteacher.Value = "";
                //            }


                //            da.Dispose();
                //        }
                //    }

                //    this.ModalPopupExtender1.Show();
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    TextBox tb = (TextBox)sender;
            //    GridViewRow row = (GridViewRow)tb.NamingContainer;
            //    if (row != null)
            //    {
            //    //    //message.InnerHtml = lb.ID.ToString();
            //    //    int xcellno = int.Parse(lb.ID.ToString().Substring(9));
            //    //    //message.InnerHtml = lb.ID.ToString().Substring(9);
            //    //    lbldate.Text = Convert.ToDateTime(row.Cells[2 + (int) ViewState["rowCount"]].Text).ToString("dddd, MMMM dd, yyyy");
            //    //    lblperiod.Text = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
            //    //    lblsection.Text = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

            //    //    _xdate.Value = row.Cells[2 + (int) ViewState["rowCount"]].Text.ToString();
            //    //    _xperiod.Value = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
            //    //    _xsection.Value = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();
            //        int val = 4;
            //        //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //        //{
            //        //    val = 4;
            //        //}
            //        //else
            //        //{
            //        //    val = 3;
            //        //}

            //        //if (Convert.ToDecimal(row.Cells[val].Text.ToString()) > Convert.ToDecimal(xmarks.Text.Trim()))
            //        //{
            //        //    row.Cells[val].BackColor = Color.Bisque;
            //        //}

            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        private void fnCheckRow()
        {
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts = new DataSet())
            //    {
            //        con.Open();
            //        string query;

            //        //if (xctno.Text != "")
            //        //{
            //        //    query =
            //        //    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno AND xdate=@xdate";
            //        //}
            //        //else
            //        // {
            //        query =
            //        "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";
            //        // }

            //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xcttype", xcttype.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xctno", xctno.Text.ToString().Trim());
            //        DateTime xdate1 = xdate.Text.Trim() != string.Empty
            //                    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //        da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


            //        DataTable tempTable = new DataTable();
            //        da.Fill(dts, "tempTable");
            //        tempTable = dts.Tables["tempTable"];

            //        if (tempTable.Rows.Count > 0)
            //        {
            //            ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
            //        }
            //        else
            //        {
            //            ViewState["xrow"] = null;
            //        }


            //    }
            //}
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xstatus not in ('Approved2','Approved3') and coalesce(xext,'')=@xext ";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());


                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        string msg = "Cann't save data. " + tempTable.Rows.Count.ToString() +
                                     " exam not yet approved by coordinator. <br />";
                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            msg = msg + (i + 1).ToString() + ". " + tempTable.Rows[i]["xcttype"].ToString() +
                            "-" + tempTable.Rows[i]["xctno"] + ", Status - " + tempTable.Rows[i]["xstatus"].ToString() + "<br />";
                        }

                        message.InnerHtml = msg;
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }


                }
            }


                using (TransactionScope tran = new TransactionScope())
                {
                    if (GridView1.Rows.Count > 0)
                    {
                       
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;


                            //string query = "DELETE FROM amexamhhdtemp WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper ";
                            string query = "DELETE FROM amexamhhd1 WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper and coalesce(xext,'')=@xext ";
                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());
                            cmd.ExecuteNonQuery();

           


                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                TextBox txtTextBox1 = row.FindControl("txtComments") as TextBox;

                                Int64 xsrow = Convert.ToInt64(row.Cells[5 + (int)ViewState["rowCount"]].Text);

                                //query = "INSERT INTO amexamhhdtemp (zid,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xsrow,xtype,xremarks) " +
                                //        "VALUES(@zid,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xsrow,'Class Test',@xremarks) ";

                                query = "INSERT INTO amexamhhd1 (ztime,zid,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xsrow,xtype,xremarks,zemail,xext) " +
                                       "VALUES(@ztime,@zid,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xsrow,'Class Test',@xremarks,@zemail,@xext) ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xremarks", txtTextBox1.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xsrow", xsrow);
                                cmd.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
                                cmd.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        message.InnerHtml = "No student found.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }

                    tran.Complete();

                }

            //    //btnSave.Enabled = false;
            //    //btnSave1.Enabled = false;
            //    // btnRefresh_Click(null, null);
                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;
            //    //ViewState["xrow"] = xrow;
            //    //ViewState["xstatus"] = "New";
            //    //hiddenxstatus.Value = "New";

                ////BindGrid();

            //    fnButtonState();
            //    fnFillGrid2();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //int xrow = int.Parse(ViewState["xrow"].ToString());
                //int xline1 = 0;
                //message.InnerHtml = "";

                //using (TransactionScope tran = new TransactionScope())
                //{
                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {

                //        using (DataSet dts = new DataSet())
                //        {

                //            DateTime xdate2 = Convert.ToDateTime(_xdate.Value);
                //            string xperiod2 = _xperiod.Value;
                //            string xsection2 = _xsection.Value;

                //            string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                //            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                //            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                //            da.Fill(dts, "tempTable");
                //            DataTable tempTable = new DataTable();
                //            tempTable = dts.Tables["tempTable"];

                //            if (tempTable.Rows.Count > 0)
                //            {
                //                xline1 = Convert.ToInt32(tempTable.Rows[0][0].ToString());
                //            }


                //            da.Dispose();
                //        }


                //        conn.Open();
                //        SqlCommand cmd = new SqlCommand();
                //        cmd.Connection = conn;


                //        //if (xline1 != 0)
                //        //{
                //        //    string query2 = "DELETE FROM amexamschd WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                //        //    cmd.Parameters.Clear();
                //        //    cmd.CommandText = query2;
                //        //    cmd.Parameters.AddWithValue("@zid", _zid);
                //        //    cmd.Parameters.AddWithValue("@xrow", xrow);
                //        //    cmd.Parameters.AddWithValue("@xline", xline1);
                //        //    cmd.ExecuteNonQuery();
                //        //}


                //        DateTime ztime = DateTime.Now;
                //        DateTime zutime = DateTime.Now;
                //        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //        int xline = zglobal.GetMaximumIdInt("xline", "amexamschd", " zid=" + _zid + " and xrow=" + xrow, "line");
                //        string xsubject1 = "";
                //        string xpaper1 = "";
                //        DateTime xdate1 = DateTime.Now;
                //        string xsection1 = "";
                //        string xcperiod1 = "";
                //        string xcteacher1 = "";
                //        string xsteacher1 = "";
                //        string xtopic1 = "";
                //        string xdetails1 = "";
                //        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

                //        string query;
                //        if (xline1 != 0)
                //        {
                //            query = "UPDATE amexamschd SET zutime=@zutime, xsubject=@xsubject, xpaper=@xpaper, xtopic=@xtopic, xdetails=@xdetails, xcteacher=@xcteacher, xsteacher=@xsteacher, xemail=@xemail WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                //            xline = xline1;
                //        }
                //        else
                //        {
                //            query = "INSERT INTO amexamschd (ztime,zid,xrow,xline,xsubject,xpaper,xdate,xsection,xcperiod,xcteacher,xsteacher,xtopic,xdetails,zemail) " +
                //                   "VALUES(@ztime,@zid,@xrow,@xline,@xsubject,@xpaper,@xdate,@xsection,@xcperiod,@xcteacher,@xsteacher,@xtopic,@xdetails,@zemail) ";
                //        }


                //        xsubject1 = xsubject.Text.ToString().Trim();
                //        xpaper1 = xpaper.Text.Trim().ToString();
                //        xdate1 = Convert.ToDateTime(_xdate.Value.ToString());
                //        xsection1 = _xsection.Value.ToString();
                //        xcperiod1 = _xperiod.Value.ToString();
                //        xcteacher1 = _classteacher.Value.ToString();
                //        xsteacher1 = _subteacher.Value.ToString();
                //        xtopic1 = xtopic.Value.Trim().ToString();
                //        xdetails1 = xdetails.Value.Trim().ToString();

                //        cmd.CommandText = query;
                //        cmd.Parameters.Clear();
                //        cmd.Parameters.AddWithValue("@ztime", ztime);
                //        cmd.Parameters.AddWithValue("@zutime", ztime);
                //        cmd.Parameters.AddWithValue("@zid", _zid);
                //        cmd.Parameters.AddWithValue("@xrow", xrow);
                //        cmd.Parameters.AddWithValue("@xline", xline);
                //        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                //        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                //        cmd.Parameters.AddWithValue("@xdate", xdate1);
                //        cmd.Parameters.AddWithValue("@xsection", xsection1);
                //        cmd.Parameters.AddWithValue("@xcperiod", xcperiod1);
                //        cmd.Parameters.AddWithValue("@xcteacher", xcteacher1);
                //        cmd.Parameters.AddWithValue("@xsteacher", xsteacher1);
                //        cmd.Parameters.AddWithValue("@xtopic", xtopic1);
                //        cmd.Parameters.AddWithValue("@xdetails", xdetails1);
                //        cmd.Parameters.AddWithValue("@zemail", zemail);
                //        cmd.Parameters.AddWithValue("@xemail", xemail);
                //        //if (xsubject.Text != "" && xpaper.Text != "")
                //        //{
                //            cmd.ExecuteNonQuery();
                //        //}


                //    }

                //    tran.Complete();

                //}




                //if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                //{
                //    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                //    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                //    BindGrid(year, month);
                //}
                //else
                //{
                //    BindGrid(1999, 1);
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnFillDataGrid(object sender, EventArgs e)
        {
            try
            {
                ////System.Threading.Thread.Sleep(1000);
                //message.InnerHtml = "";


                //if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                //{
                //    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                //    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                //    BindGrid(year, month);
                //}
                //else
                //{
                //    BindGrid(1999, 1);
                //    //GridView1.DataSource = null;
                //    //GridView1.DataBind();
                //}



            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        private void fnGetScheduleDate(string xflag)
        {
            //using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts = new DataSet())
            //    {
            //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //        string xsession1 = xsession.Text.Trim().ToString();
            //        string xterm1 = xterm.Text.Trim().ToString();
            //        string xclass1 = xclass.Text.Trim().ToString();
            //        string xgroup1 = xgroup.Text.Trim().ToString();
            //        string xsection1 = xsection.Text.Trim().ToString();
            //        string xsubject1 = xsubject.Text.Trim().ToString();
            //        string xpaper1 = xpaper.Text.Trim().ToString();

            //        //string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //        //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited'";
            //        string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //                       "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test'";

            //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
            //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //        da.Fill(dts, "tempztcode");
            //        DataTable dtexam = new DataTable();
            //        dtexam = dts.Tables[0];
            //        //xdate.Items.Clear();
            //        //xdate.Items.Add("");
            //        if (dtexam.Rows.Count > 0)
            //        {
            //            ViewState["xnumsch"] = dtexam.Rows.Count;
            //            //foreach (DataRow row in dtexam.Rows)
            //            //{
            //            //    if (row["xdate"].Equals(DBNull.Value) == false)
            //            //    {
            //            //        // xdate.Items.Add(Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy"));
            //            //        //xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
            //            //    }
            //            //}
            //            //if (xflag == "comval")
            //            //{
            //            //    xcttype.Text = "Test";
            //            //    fnEventValue("xcttype", null, null);
            //            //}
            //        }
            //        else
            //        {
            //            ViewState["xnumsch"] = null;
            //            //if (xflag == "comval")
            //            //{
            //            //    xcttype.Text = "Test (WS)";
            //            //    fnEventValue("xcttype", null, null);
            //            //}
            //        }
            //        //xdate.Text = "";
            //    }
            //}
        }

        private void fnFillGrid2()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    //string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xdate";

                    string query =
                      "select xsubject,xpaper,coalesce(xext,'') as xext,MAX(tbl.best) as best1 from " +
                      " (select zid,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,coalesce(xext,'') as xext,count(*) as best " +
                      " from amexamh where xcttype in ('Test','Test (WS)') AND xtype='Class Test' " +
                      " group by zid,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext) as tbl " +
                      "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xsubject=@xsubject AND xpaper=@xpaper and xext=@xext " +
                      " group by xsubject,xpaper,xext ";
                    
                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());


                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        //// btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        //GridView2.DataSource = tempTable;
                        //GridView2.DataBind();
                        zsetvalue.SetDWNumItem(xtbest, 1, Convert.ToInt32(tempTable.Rows[0]["best1"]));
                        ViewState["xbest1"] = tempTable.Rows[0]["best1"].ToString();
                    }
                    else
                    {
                    //    // btnShowList.Visible = false;
                    //    pnllistct.Visible = false;
                    //    GridView2.DataSource = null;
                    //    GridView2.DataBind();
                        zsetvalue.SetDWNumItem(xtbest, 2, 1);
                    }


                }
            }
        }

        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                ////System.Threading.Thread.Sleep(1000);
                message.InnerHtml = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                ViewState["xrow"] = null;

                result.Visible = false;
                barchart.Visible = false;
                //fnGetScheduleDate();

                //xctno.Items.Clear();
                //xctno.Items.Add("");
                //xcttype.Text = "";
                //xctno.Text = "";
                //xmarks.Text = "";
                //xtopic.Value = "";
                //xdetails.Value = "";
                ////xcteacher.Text = "-";
                //xcteacher.Text = "";
                ////xsteacher.Text = "-";
                //xsteacher.Text = "";
                //dxstatus.Text = "-";
                fnButtonState();
                _classteacher.Value = "";
                _subteacher.Value = "";

                fnFillGrid2();
                xperc.Text = "";
                //xperc.Text = "100";


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT * FROM amexamhh inner join amexamhhd on amexamhh.zid=amexamhhd.zid and amexamhh.xrow=amexamhhd.xrow WHERE amexamhh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' ";

                        string query = "SELECT * FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup " +
                            " AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' and xext=@xext and xtype1='Subject Extension' and xstatus='Approved3'";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            xtbest.Text = dtamexamd.Rows[0]["xtbest"].ToString();
                            xperc.Text = dtamexamd.Rows[0]["xperc"].ToString();

                            btnRefresh_Click(sender,e);

                            xtbest.Enabled = false;
                            xperc.Enabled = false;
                            //btnSave.Enabled = false;
                            //btnSave1.Enabled = false;
                            hiscom.Value = "1";
                        }
                        else
                        {
                            xtbest.Enabled = true;
                            xperc.Enabled = true;
                            //btnSave.Enabled = true;
                            //btnSave1.Enabled = true;
                            hiscom.Value = "0";
                        }

                    }
                }

                //xtbest.Enabled = false;
                //xperc.Enabled = false;
                //zglobal.fnComboBoxValueWithItem(xreference, "(xcttype + '-' + xctno) as xtext,(xcttype + '|' + xctno) as xvalue", "amexamh", "zid=" + _zid + " and xsession='" + xsession.Text + "' and xterm='" + xterm.Text +
                //     "' and xclass='" + xclass.Text + "' and xgroup='" + xgroup.Text + "' and xsection='" + xsection.Text + "' and xsubject='" + xsubject.Text + "' and xpaper='" + xpaper.Text + "' and xtype='Class Test' and xcttype in ('Test','Test (WS)') order by xctno");


                //fnGetScheduleDate("comval");

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //try 
        //    //{
        //        if (e.CommandName == "xno")
        //        {
        //            int rowIndex = Convert.ToInt32(e.CommandArgument);
        //            GridViewRow row = GridView1.Rows[rowIndex];
        //            //xdate.Text = row.Cells[1].Text;
        //            //xcttype.Text = row.Cells[2].Text;
        //            //xctno.Text = row.Cells[3].Text;
        //           // btnRefresh_Click(null,null);
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Date: " + row.Cells[1].Text + "\\Type: " + row.Cells[2].Text + "');", true);
        //        }
        //    //}
        //    //catch (Exception exp)
        //    //{
        //    //    message.InnerHtml = exp.Message;
        //    //    message.Style.Value = zglobal.errormsg;
        //    //}
        //}

        protected void FillControl(object sender, EventArgs e)
        {
            //try
            //{
            //    LinkButton lb = (LinkButton)sender;
            //    GridViewRow row = (GridViewRow)lb.NamingContainer;
            //    if (row != null)
            //    {
            //        int index = row.RowIndex; //gets the row index selected


            //        //xcttype.Text = GridView2.Rows[index].Cells[1].Text;
            //        //fnEventValue("xcttype", sender, e);

            //        //xctno.Text = GridView2.Rows[index].Cells[2].Text;
            //        //fnEventValue("xctno", sender, e);

            //        //xdate.Text = GridView2.Rows[index].Cells[3].Text;
            //        //fnEventValue("xdate", sender, e);




            //        // xdate.Enabled = true;

            //        btnRefresh_Click(sender, e);

            //        //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //        //{
            //        //    xreference_Click(sender, e);
            //        //}
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //message.InnerText = "";
                //if (ViewState["xrow"] != null)
                //{
                //    if (txtconformmessageValue.Value == "Yes")
                //    {
                //        string xstatus;

                //        using (TransactionScope tran = new TransactionScope())
                //        {
                //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //            {
                //                conn.Open();
                //                SqlCommand cmd = new SqlCommand();
                //                cmd.Connection = conn;
                //                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //                string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //                DateTime xsubmitdt = DateTime.Now;
                //                xstatus = "Submited";




                //                string query =
                //                    "UPDATE amexamh SET xstatus=@xstatus,xsubmitedby=@xsubmitedby,xsubmitdt=@xsubmitdt " +
                //                    "WHERE zid=@zid AND xrow=@xrow ";
                //                cmd.Parameters.Clear();

                //                cmd.CommandText = query;
                //                cmd.Parameters.AddWithValue("@zid", _zid);
                //                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                //                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                //                cmd.Parameters.AddWithValue("@xsubmitedby", xsubmitedby);
                //                cmd.Parameters.AddWithValue("@xsubmitdt", xsubmitdt);
                //                cmd.ExecuteNonQuery();
                //            }

                //            tran.Complete();
                //        }

                //        message.InnerHtml = zglobal.subsuccmsg;
                //        message.Style.Value = zglobal.successmsg;
                //        btnSubmit.Enabled = false;
                //        btnSubmit1.Enabled = false;
                //        btnSave.Enabled = false;
                //        btnSave1.Enabled = false;
                //        btnDelete.Enabled = false;
                //        btnDelete1.Enabled = false;
                //        ViewState["xstatus"] = "Submited";
                //        hxstatus.Value = "Submited";
                //        //dxstatus.Visible = true;
                //        //btnPrint.Visible = true;
                //        //dxstatus.Text = "Status : Submited";
                //        hiddenxstatus.Value = "Submited";
                //        fnButtonState();
                //        BindGrid();
                //        fnFillGrid2();
                //    }
                //}
                //else
                //{
                //    message.InnerHtml = "Cann't submit information.";
                //    message.Style.Value = zglobal.warningmsg;
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //message.InnerText = "";
                //fnCheckRow();

                //if (ViewState["xrow"] != null)
                //{
                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh",
                //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    if (xstatus1 != "New" && xstatus1 != "Undo")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}
                //if (ViewState["xrow"] != null)
                //{
                //    if (txtconformmessageValue1.Value == "Yes")
                //    {
                //        string xstatus;


                //        using (TransactionScope tran = new TransactionScope())
                //        {
                //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //            {
                //                conn.Open();
                //                SqlCommand cmd = new SqlCommand();
                //                cmd.Connection = conn;


                //                string query = "DELETE FROM amexamd WHERE zid=@zid AND xrow=@xrow";
                //                cmd.Parameters.Clear();

                //                cmd.CommandText = query;
                //                cmd.Parameters.AddWithValue("@zid", _zid);
                //                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                //                cmd.ExecuteNonQuery();

                //                query = "DELETE FROM amexamh WHERE zid=@zid AND xrow=@xrow";
                //                cmd.CommandText = query;
                //                cmd.ExecuteNonQuery();
                //            }

                //            tran.Complete();
                //        }

                //        message.InnerHtml = zglobal.delsuccmsg;
                //        message.Style.Value = zglobal.successmsg;
                //        //btnSubmit.Enabled = false;
                //        //btnSubmit1.Enabled = false;
                //        //btnSave.Enabled = false;
                //        //btnSave1.Enabled = false;
                //        //btnDelete.Enabled = false;
                //        //btnDelete1.Enabled = false;
                //        //ViewState["xstatus"] = "Submited";
                //        //hxstatus.Value = "Submited";
                //        //dxstatus.Visible = true;
                //        //btnPrint.Visible = true;
                //        //dxstatus.Text = "Status : Submited";
                //        //hiddenxstatus.Value = "Submited";
                //        fnButtonState();
                //        BindGrid();
                //        fnFillGrid2();
                //    }
                //}
                //else
                //{
                //    message.InnerHtml = "No data found for delete.";
                //    message.Style.Value = zglobal.warningmsg;
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                //message.InnerText = "";


                //bool isValid = true;
                //string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                //if (xpermission.Text == "" || xpermission.Text == string.Empty || xpermission.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Permission Type</li>";
                //    isValid = false;
                //}
                //rtnMessage = rtnMessage + "</ol></div>";
                //if (!isValid)
                //{
                //    message.InnerHtml = rtnMessage;
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}

                //if (ViewState["xrow"] != null)
                //{
                //    if (txtconformmessageValue2.Value == "Yes")
                //    {
                //        string xstatus;

                //        using (TransactionScope tran = new TransactionScope())
                //        {
                //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //            {
                //                conn.Open();
                //                SqlCommand cmd = new SqlCommand();
                //                cmd.Connection = conn;
                //                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //                string xundoby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //                DateTime xundodt = DateTime.Now;
                //                xstatus = "Undo1";





                //                string query =
                //                    "UPDATE amexamh SET xstatus=@xstatus,xundoby=@xundoby,xundodt=@xundodt " +
                //                    "WHERE zid=@zid AND xrow=@xrow ";
                //                cmd.Parameters.Clear();

                //                cmd.CommandText = query;
                //                cmd.Parameters.AddWithValue("@zid", _zid);
                //                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                //                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                //                cmd.Parameters.AddWithValue("@xundoby", xundoby);
                //                cmd.Parameters.AddWithValue("@xundodt", xundodt);
                //                cmd.ExecuteNonQuery();

                //                foreach (GridViewRow row in GridView1.Rows)
                //                {
                //                    CheckBox chkxflag = row.FindControl("xflag") as CheckBox;
                //                    Label lblxline = row.FindControl("xline") as Label;
                //                    Label lxflag1 = row.FindControl("xflag1") as Label;
                //                    Label lxflag2 = row.FindControl("xflag2") as Label;
                //                    //string xflag1 = "";
                //                    //string xflag2 = "";

                //                    string xflag1 = lxflag1.Text;
                //                    string xflag2 = lxflag2.Text;

                //                    if (chkxflag.Checked)
                //                    {
                //                        if (xpermission.Text == "Wrong Entry")
                //                        {
                //                            xflag1 = "Wrong";
                //                        }

                //                        if (xpermission.Text == "Missing Test")
                //                        {
                //                            xflag2 = "Missing";
                //                        }
                //                    }

                //                    query =
                //                        "UPDATE amexamd SET xflag1=@xflag1,xflag2=@xflag2,xundoby=@xundoby,xundodt=@xundodt " +
                //                        "WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                //                        cmd.Parameters.Clear();

                //                        cmd.CommandText = query;
                //                        cmd.Parameters.AddWithValue("@zid", _zid);
                //                        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                //                        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lblxline.Text));
                //                        cmd.Parameters.AddWithValue("@xflag1", xflag1);
                //                        cmd.Parameters.AddWithValue("@xflag2", xflag2);
                //                        cmd.Parameters.AddWithValue("@xundoby", xundoby);
                //                        cmd.Parameters.AddWithValue("@xundodt", xundodt);
                //                        cmd.ExecuteNonQuery();
                                    
                //                }
                //            }

                //            tran.Complete();
                //        }

                //        message.InnerHtml = zglobal.undosuccmsg;
                //        message.Style.Value = zglobal.successmsg;
                //        btnSubmit.Enabled = false;
                //        btnSubmit1.Enabled = false;
                //        btnSave.Enabled = false;
                //        btnSave1.Enabled = false;
                //        btnDelete.Enabled = false;
                //        btnDelete1.Enabled = false;
                //        btnApprove.Enabled = false;
                //        btnApprove1.Enabled = false;
                //        //btnUndo.Enabled = false;
                //        //btnUndo1.Enabled = false;
                //        ViewState["xstatus"] = "Undo1";
                //        hxstatus.Value = "Undo1";
                //        hiddenxstatus.Value = "Undo1";
                //        fnButtonState();
                //        BindGrid();
                //        fnFillGrid2();
                //    }
                //}
                //else
                //{
                //    message.InnerHtml = "No data found for undo.";
                //    message.Style.Value = zglobal.warningmsg;
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerText = "";

            //    if (ViewState["xrow"] != null)
            //    {
            //        if (txtconformmessageValue3.Value == "Yes")
            //        {
            //            string xstatus;

            //            using (TransactionScope tran = new TransactionScope())
            //            {
            //                using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //                {
            //                    conn.Open();
            //                    SqlCommand cmd = new SqlCommand();
            //                    cmd.Connection = conn;
            //                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //                    string xapproved2by = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    DateTime xapproved2dt = DateTime.Now;
            //                    xstatus = "Approved2";




            //                    string query =
            //                        "UPDATE amexamh SET xstatus=@xstatus,xapproved2by=@xapproved2by,xapproved2dt=@xapproved2dt " +
            //                        "WHERE zid=@zid AND xrow=@xrow ";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
            //                    cmd.Parameters.AddWithValue("@xapproved2by", xapproved2by);
            //                    cmd.Parameters.AddWithValue("@xapproved2dt", xapproved2dt);
            //                    cmd.ExecuteNonQuery();
            //                }

            //                tran.Complete();
            //            }

            //            message.InnerHtml = zglobal.appsuccmsg;
            //            message.Style.Value = zglobal.successmsg;
            //            btnSubmit.Enabled = false;
            //            btnSubmit1.Enabled = false;
            //            btnSave.Enabled = false;
            //            btnSave1.Enabled = false;
            //            btnDelete.Enabled = false;
            //            btnDelete1.Enabled = false;
            //            btnApprove.Enabled = false;
            //            btnApprove1.Enabled = false;
            //            btnUndo.Enabled = false;
            //            btnUndo1.Enabled = false;
            //            ViewState["xstatus"] = "Approved2";
            //            hxstatus.Value = "Approved2";
            //            hiddenxstatus.Value = "Approved2";
            //            fnButtonState();
            //            BindGrid();
            //            fnFillGrid2();
            //        }
            //    }
            //    else
            //    {
            //        message.InnerHtml = "No data found for approved.";
            //        message.Style.Value = zglobal.warningmsg;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void fnEventValue(string evnt, object sender, EventArgs e)
        {
            //xpermission.Text = "";
            //if (xcttype.Text == "Test")
            //{
            //    xschdate.Enabled = false;
            //    schedule_d.Visible = true;
            //}
            //else
            //{
            //    schedule_d.Visible = false;
            //}

            //if ((xcttype.Text == "Extra Test" || xcttype.Text == "Retest") && xreference.Text == "")
            //{
            //    ViewState["dtprectmarks"] = null;
            //}

            //if (evnt == "xcttype")
            //{
            //    if (xcttype.Text == "Test")
            //    {
            //        ViewState["xnumsch"] = null;
            //        xdate.Text = "";
            //        xnsdate.Value = "";
            //        //xdate.Enabled = false;
            //        xschdate.Text = "";
            //        //xschdate.Enabled = false;
            //        //schedule_d.Visible = true;
            //        fnGetScheduleDate("evnval");
            //        //if (ViewState["xnumsch"] != null)
            //        //{
            //        //    zsetvalue.SetDWNumItem(xctno, 1, Convert.ToInt32(ViewState["xnumsch"]));
            //        //}
            //        //else
            //        //{
            //        //    zsetvalue.SetDWNumItem(xctno, 2, 1);
            //        //}
            //    }
            //    else
            //    {
            //        //if (xcttype.Text != "")
            //        //{
            //        //    zsetvalue.SetDWNumItem(xctno, 1, 15);
            //        //}
            //        //else
            //        //{
            //        //    zsetvalue.SetDWNumItem(xctno, 2, 1);
            //        //}
            //        xdate.Text = "";
            //        xnsdate.Value = "";
            //        // xdate.Enabled = true;
            //        // schedule_d.Visible = false;

            //    }

            //    if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test")
            //    {
            //        retestfor.Visible = true;
            //    }
            //    else
            //    {
            //        retestfor.Visible = false;
            //    }

            //    //xreason_d.Visible = false;
            //    ViewState["xdate1"] = null;
            //    xnsdate.Value = "";
            //    xreference.Text = "";
            //    xreason.Text = "";


            //    if (xcttype.Text != "")
            //    {
            //        //zsetvalue.SetDWNumItem(xctno, 1, 15);
            //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //        using (SqlConnection con = new SqlConnection(zglobal.constring))
            //        {
            //            using (DataSet dts = new DataSet())
            //            {
            //                con.Open();
            //                string query;

            //                //if (xctno.Text != "")
            //                //{
            //                //    query =
            //                //    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno AND xdate=@xdate";
            //                //}
            //                //else
            //                // {
            //                query =
            //                //"SELECT count(*) FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xstatus IN ('Approved1','Approved2')";
            //                "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xstatus IN ('Approved1','Approved2')";
            //                // }

            //                SqlDataAdapter da = new SqlDataAdapter(query, con);

            //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xcttype", xcttype.Text.ToString().Trim());
            //                //da.SelectCommand.Parameters.AddWithValue("@xctno", xctno.Text.ToString().Trim());
            //                //DateTime xdate1 = xdate.Text.Trim() != string.Empty
            //                //            ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                //                CultureInfo.InvariantCulture)
            //                //            : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //                //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


            //                DataTable tempTable = new DataTable();
            //                da.Fill(dts, "tempTable");
            //                tempTable = dts.Tables["tempTable"];

            //                if (tempTable.Rows.Count > 0)
            //                {
            //                    //zsetvalue.SetDWNumItem(xctno, 1, int.Parse(tempTable.Rows[0][0].ToString()));

            //                    xctno.Items.Clear();
            //                    xctno.Items.Add("");
            //                    foreach (DataRow row in tempTable.Rows)
            //                    {
            //                        xctno.Items.Add(row["xctno"].ToString());
            //                    }
            //                    xctno.Text = "";
            //                }
            //                else
            //                {
            //                    zsetvalue.SetDWNumItem(xctno, 2, 1);
            //                }


            //            }
            //        }
            //    }
            //    else
            //    {
            //        zsetvalue.SetDWNumItem(xctno, 2, 1);
            //    }
            //}
            //else if (evnt == "xctno")
            //{
            //    if (xcttype.Text == "Test")
            //    {
            //        if (xctno.Text != "")
            //        {
            //            fnGetDate(sender, e);
            //            //xdate.Enabled = true;

            //            if (xdate.Text == "")
            //            {
            //                ViewState["xdate1"] = null;
            //            }
            //            else
            //            {
            //                ViewState["xdate1"] = xdate.Text.ToString().Trim();
            //            }

            //        }
            //        else
            //        {
            //            xdate.Text = "";
            //            xnsdate.Value = "";
            //            xschdate.Text = "";
            //            //xdate.Enabled = false;
            //            ViewState["xdate1"] = null;
            //        }
            //    }
            //    else
            //    {
            //        xdate.Text = "";
            //        xnsdate.Value = "";
            //        ViewState["xdate1"] = null;
            //        xschdate.Text = "";
            //        //schedule_d.Visible = false;

            //    }

            //    //xreason_d.Visible = false;
            //    xreason.Text = "";
            //}
            //else if (evnt == "xdate")
            //{
            //    xreason.Text = "";
            //    if (xcttype.Text == "Test")
            //    {
            //        if (xctno.Text != "")
            //        {

            //            if (ViewState["xdate1"] != null)
            //            {
            //                DateTime xnsdate1 = xnsdate.Value != ""
            //                    ? DateTime.ParseExact(xnsdate.Value.ToString(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //                DateTime xdate1 = xdate.Text.Trim() != string.Empty
            //                    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


            //                DateTime xpsdate = ViewState["xdate1"] != null
            //                    ? DateTime.ParseExact(Convert.ToString(ViewState["xdate1"]), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


            //                if (xdate1.Date >= xnsdate1.Date || xdate1.Date < xpsdate.Date)
            //                {
            //                    xdate.Text = Convert.ToString(ViewState["xdate1"]);
            //                    message.InnerHtml = "Cann't exceed next schedule date. Select a date between '" + xpsdate.ToString("dd/MM/yyyy") + "' and '" + xnsdate1.ToString("dd/MM/yyyy") + "'";
            //                    //return;
            //                    message.Style.Value = zglobal.warningmsg;
            //                    ViewState["xreturn"] = 1;
            //                }

            //                //if (Convert.ToString(ViewState["xdate1"]) != xdate.Text.ToString().Trim())
            //                //{
            //                //    xreason_d.Visible = true;
            //                //}
            //                //else
            //                //{
            //                //    xreason_d.Visible = false;
            //                //    xreason.Text = "";
            //                //}
            //            }
            //        }
            //        else
            //        {
            //            //xreason_d.Visible = false;
            //            xreason.Text = "";
            //            ViewState["xdate1"] = null;
            //            xnsdate.Value = "";
            //        }
            //    }
            //    else
            //    {
            //        //xreason_d.Visible = false;
            //        xreason.Text = "";
            //        ViewState["xdate1"] = null;
            //        xnsdate.Value = "";
            //    }

            //}
        }

        protected void xcttype_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    fnEventValue("xcttype", sender, e);

            //    btnRefresh_Click(sender, e);
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void xctno_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    fnEventValue("xctno", sender, e);

            //    btnRefresh_Click(sender, e);

            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //    {
            //        xreference_Click(sender, e);
            //    }
               
               
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void xdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";
            //    fnEventValue("xdate", sender, e);

            //    if (Convert.ToInt32(ViewState["xreturn"]) == 1)
            //    {
            //        ViewState["xreturn"] = null;
            //        return;
            //    }

            //    string xdate10 = xdate.Text;

            //    btnRefresh_Click(sender, e);

            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //    {
            //        xreference_Click(sender, e);
            //    }

            //    xdate.Text = xdate10;
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void xpermission_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";
               

            //    btnRefresh_Click(sender, e);
                
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        private void fnResult()
        {
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //string xpaper1 = xpaper.Text.ToString();
            //string xsubject1 = xsubject.Text.ToString();
            //string xbest1 = xtbest.Text.ToString();
            //string xperc1 = xperc.Text.ToString();




            ////using (SqlConnection con = new SqlConnection(zglobal.constring))
            ////{
            ////    using (DataSet dts1 = new DataSet())
            ////    {
            ////        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            ////        //string query =
            ////        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            ////        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            ////        string query =
            ////               "select xsection,xcttype,xctno from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
            ////               "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper " +
            ////               "group by xsection,xcttype,xctno  order by min(cast(xcodealt as int))";

            ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            ////        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            ////        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            ////        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            ////        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            ////        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            ////        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            ////        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

            ////        da1.Fill(dts1, "tempztcode");
            ////        DataTable dtamexamh = new DataTable();
            ////        dtamexamh = dts1.Tables[0];

            ////        if (dtamexamh.Rows.Count > 0)
            ////        {
            ////            message.InnerHtml = "Please check for approval.";

            ////            DataTable dtamexamh1 = dtamexamh.DefaultView.ToTable(true, "xsection");

            ////            foreach (DataRow row1 in dtamexamh1.Rows)
            ////            {

            ////                DataRow[] result20 = dtamexamh.Select("xsection='" + row1["xsection"].ToString() + "'");

            ////                if (result20.Length > 0)
            ////                {
            ////                    message.InnerHtml = message.InnerHtml + "<br/><br/>Section : " + " " + row1["xsection"].ToString();

            ////                    int h = 0;
            ////                    foreach (DataRow val in result20)
            ////                    {
            ////                        if (h == result20.Length - 1)
            ////                        {
            ////                            message.InnerHtml = message.InnerHtml + result20[h]["xcttype"].ToString() + "-" + result20[h]["xctno"].ToString() + ". <br/>";
            ////                        }
            ////                        else
            ////                        {
            ////                            message.InnerHtml = message.InnerHtml + result20[h]["xcttype"].ToString() + "-" + result20[h]["xctno"].ToString() + ", ";
            ////                        }

            ////                        h = h + 1;

            ////                    }
            ////                }


            ////            }




            ////            message.Style.Value = zglobal.am_warningmsg;
            ////            result.Visible = false;
            ////            barchart.Visible = false;
            ////            return;
            ////        }

            ////    }
            ////}


            ////result.Visible = true;
            ////barchart.Visible = true;




            //if (xpaper1 == "")
            //{
            //    xsubject11.Text = xsubject1;
            //}
            //else
            //{
            //    xsubject11.Text = xsubject1 + "-" + xpaper1;
            //}

            //if (xbest1 != "")
            //{
            //    xbest.Text = xbest1;

            //    if (xperc1 != "")
            //    {
            //        xbest.Text = xbest1 + " out of " + ViewState["xbest1"].ToString() + " (" + xperc1 + "%)";
            //    }
            //}
            //else
            //{
            //    xbest.Text = "";
            //}

            //int ts = 0;
            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            //        //string query =
            //        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            //        string query =
            //       "select count(xstdid) from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession  ";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];

            //        xnostd.Text = dtamexamd.Rows[0][0].ToString();
            //        ts = Convert.ToInt32(dtamexamd.Rows[0][0].ToString());

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
            //       "select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
            //       " except " +
            //       "select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
            //       " and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and  xgetmark<>-1 and  coalesce(xna,0) <> 1";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);

            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];

            //        if (dtamexamd.Rows.Count > 0)
            //        {
            //            xabsent.Text = dtamexamd.Rows.Count.ToString();
            //            xtaken.Text = (ts - dtamexamd.Rows.Count).ToString();
            //        }
            //        else
            //        {
            //            xabsent.Text = "0";
            //            xtaken.Text = ts.ToString();
            //        }

            //    }
            //}

            //if (xbest1 != "" && xperc1 != "")
            //{
            //    using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    {
            //        using (DataSet dts1 = new DataSet())
            //        {
            //            //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            //            //string query =
            //            //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //            //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            //            // string query =
            //            //"select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
            //            //" except " +
            //            //"select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
            //            //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and  xgetmark<>-1";

            //            string query = "select grade,count(*) as nostd from " +
            //                "(select xsrow,SUM(case when xbest=-1 then 0 else xbest end) as xgetmark,SUM(xmarks) as xmark, " +
            //                "(SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks)) as xperc, " +
            //                "((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) as xperc1, " +
            //                " (select xgrade from amgradeconf where round(((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc),0) >=xmin and " +
            //                " round(((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc),0) <=xmax and " +
            //                "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
            //                "(select max(xdate) from amexamh where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
            //                "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper )  )) as grade " +
            //                "from amexammaxmarkvw3 " +
            //                " where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
            //                "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and xid <=@xid and xbestflag=1 " +
            //                "group by xsrow) tbl " +
            //            "group by grade";

            //            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //            //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //            da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //            da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //            da1.SelectCommand.Parameters.AddWithValue("@xid", Convert.ToInt32(xbest1));
            //            da1.SelectCommand.Parameters.AddWithValue("@perc", Convert.ToInt32(xperc1));

            //            da1.Fill(dts1, "tempztcode");
            //            DataTable dtamexamd = new DataTable();
            //            dtamexamd = dts1.Tables[0];

            //            if (dtamexamd.Rows.Count > 0)
            //            {
            //                ViewState["amresult"] = dtamexamd;
            //            }
            //            else
            //            {
            //                ViewState["amresult"] = null;
            //            }

            //        }
            //    }
            //}


            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        string query =
            //       "select * from amgradeconf where zid=@zid and xeffdate=(select MAX(xeffdate) from amgradeconf as a " +
            //       " where zid=amgradeconf.zid and xeffdate<= " +
            //       " (select max(xdate) from amexamh where xcttype in ('Test','Test (WS)') AND xtype='Class Test' and zid=@zid and " +
            //       " xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper) " +
            //       " )";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);

            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];

            //        if (dtamexamd.Rows.Count > 0)
            //        {
            //            grade.Controls.Clear();
            //            colorcode.Controls.Clear();

            //            HtmlGenericControl table = new HtmlGenericControl("table");
            //            table.Attributes.Add("style", "width: 100%; border-collapse: collapse; border: none;color: #000000");

            //            grade.Controls.Add(table);

            //            HtmlGenericControl table1 = new HtmlGenericControl("table");
            //            table1.Attributes.Add("style", "width: 100%;  border: 1px solid #eaf7ff; border-spacing: 5px;color: #000000");

            //            colorcode.Controls.Add(table1);

            //            Chart1.Series["Series1"].Points.Clear();

                        

            //            Series series = Chart1.Series["Series1"];

            //            int count = 1;
            //            foreach (DataRow _row in dtamexamd.Rows)
            //            {
            //                HtmlGenericControl tr = new HtmlGenericControl("tr");
            //                if (count % 2 != 0)
            //                {
            //                    tr.Attributes.Add("style", "background-color: #CEE5B7");
            //                }
            //                table.Controls.Add(tr);

            //                HtmlGenericControl td1 = new HtmlGenericControl("td");
            //                td1.Attributes.Add("style", "width: 50%; text-align: right; padding-right: 30px;");
            //                td1.InnerHtml = dtamexamd.Rows[count - 1]["xcaption"].ToString();
            //                tr.Controls.Add(td1);

            //                HtmlGenericControl td2 = new HtmlGenericControl("td");
            //                td2.Attributes.Add("style", "width: 20%;");
            //                td2.InnerHtml = dtamexamd.Rows[count - 1]["xgrade"].ToString();
            //                tr.Controls.Add(td2);

            //                HtmlGenericControl td3 = new HtmlGenericControl("td");
            //                td3.Attributes.Add("style", "width: 30%; padding-left: 10px;");
            //                if (xbest1 != "" && xperc1 != "")
            //                {
            //                    if (ViewState["amresult"] != null)
            //                    {
            //                        DataRow[] result20 =
            //                            ((DataTable)ViewState["amresult"]).Select("grade='" + dtamexamd.Rows[count - 1]["xgrade"].ToString() + "'");
            //                        if (result20.Length > 0)
            //                        {
            //                            td3.InnerHtml = result20[0][1].ToString();

            //                            series.Points.AddXY(result20[0][0].ToString(), result20[0][1].ToString());
            //                            series.Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
            //                            series.Points[count - 1].Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
            //                        }
            //                        else
            //                        {
            //                            td3.InnerHtml = "0";
            //                            series.Points.AddXY(dtamexamd.Rows[count - 1]["xgrade"].ToString(), 0);
            //                            series.Points[count - 1].Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
            //                        }
            //                    }
            //                    else
            //                    {
            //                        td3.InnerHtml = "-";
            //                    }
            //                }
            //                else
            //                {
            //                    td3.InnerHtml = "";
            //                }

            //                tr.Controls.Add(td3);




            //                //Add color code


            //                HtmlGenericControl tr2 = new HtmlGenericControl("tr");
            //                table1.Controls.Add(tr2);

            //                HtmlGenericControl td4 = new HtmlGenericControl("td");
            //                string _color = dtamexamd.Rows[count - 1]["xcolor"].ToString();
            //                td4.Attributes.Add("style", "width:20px;height:10px;background-color:" + _color + ";color:" + _color);
            //                td4.InnerHtml = "---";
            //                tr2.Controls.Add(td4);

            //                HtmlGenericControl td5 = new HtmlGenericControl("td");
            //                td5.InnerHtml = dtamexamd.Rows[count - 1]["xgrade"].ToString();
            //                tr2.Controls.Add(td5);

            //                ///////////
            //                /// 
            //                /// 
            //                /// 
            //                count = count + 1;
            //            }
            //        }
            //    }
            //}
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //ViewState["xrow"] = null;



                


                //string xrow = zglobal.fnGetValue("xrow", "amexamh",
                //     "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
                //     "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xsubject='" + xsubject.Text.Trim().ToString() + "' and xpaper='" + xpaper.Text.Trim().ToString() + "'" + " and xstatus in('Approved2','Approved3')");
                ////if (ViewState["xrow"] == null)
                //if (xrow == "")
                //{
                //    message.InnerHtml = "No data found.";
                //    message.Style.Value = zglobal.am_warningmsg;
                //    //dxstatus.Visible = false;
                //    //dxstatus.Text = "Status : ";
                //    //dxstatus.Style.Value = zglobal.am_submited;
                //    return;
                //}


                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xtbest.Text == "" || xtbest.Text == string.Empty || xtbest.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Take Best</li>";
                    isValid = false;
                }
                //if (xperc.Text == "" || xperc.Text == string.Empty || xperc.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>%</li>";
                //    isValid = false;
                //}


                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }


                string xpaper1 = xpaper.Text.ToString();
                string xsubject1 = xsubject.Text.ToString();
                string xext1 = xext.Text.Trim().ToString();
                string xbest1 = xtbest.Text.ToString();
                string xperc1 = xperc.Text.ToString();




                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                               "select xsection,xcttype,xctno from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                               "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper and coalesce(xext,'')=@xext " +
                               "group by xsection,xcttype,xctno  order by min(cast(xcodealt as int))";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                        da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamh = new DataTable();
                        dtamexamh = dts1.Tables[0];

                        if (dtamexamh.Rows.Count > 0)
                        {
                            message.InnerHtml = "Please check for approval.";

                            DataTable dtamexamh1 = dtamexamh.DefaultView.ToTable(true, "xsection");

                            foreach (DataRow row1 in dtamexamh1.Rows)
                            {

                                DataRow[] result20 = dtamexamh.Select("xsection='" + row1["xsection"].ToString() + "'");

                                if (result20.Length > 0)
                                {
                                    message.InnerHtml = message.InnerHtml + "<br/><br/>Section : " + " " + row1["xsection"].ToString() + "<br/>";

                                    int h = 0;
                                    foreach (DataRow val in result20)
                                    {
                                        if (h == result20.Length - 1)
                                        {
                                            message.InnerHtml = message.InnerHtml + result20[h]["xcttype"].ToString() + "-" + result20[h]["xctno"].ToString() + ".";
                                        }
                                        else
                                        {
                                            message.InnerHtml = message.InnerHtml + result20[h]["xcttype"].ToString() + "-" + result20[h]["xctno"].ToString() + ", ";
                                        }

                                        h = h + 1;

                                    }
                                }


                            }




                            message.Style.Value = zglobal.am_warningmsg;
                            result.Visible = false;
                            barchart.Visible = false;
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                            ViewState["xgvshow"] = "no";
                            return;
                        }
                        else
                        {
                            ViewState["xgvshow"] = "yes";
                        }

                    }
                }


                //result.Visible = true;
                //barchart.Visible = true;
               

                


                BindGrid();
                //fnFillGrid2();

                fnButtonState();


                //xtbest.Enabled = true;
                //xperc.Enabled = true;

                if (hiscom.Value == "1")
                {
                    xtbest.Enabled = false;
                    xperc.Enabled = false;
                }
                else
                {
                    xtbest.Enabled = true;
                    xperc.Enabled = true;
                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnGetDate(object sender, EventArgs e)
        {
            //try
            //{
            //    if (xctno.Text != "" && xctno.Text != string.Empty && xctno.Text != "[Select]")
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            using (DataSet dts = new DataSet())
            //            {
            //                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //                string xsession1 = xsession.Text.Trim().ToString();
            //                string xterm1 = xterm.Text.Trim().ToString();
            //                string xclass1 = xclass.Text.Trim().ToString();
            //                string xgroup1 = xgroup.Text.Trim().ToString();
            //                string xsection1 = xsection.Text.Trim().ToString();
            //                string xsubject1 = xsubject.Text.Trim().ToString();
            //                string xpaper1 = xpaper.Text.Trim().ToString();

            //                //string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //                //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' ";

            //                string query =
            //                    "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //                    "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' ORDER BY xdate ";

            //                SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
            //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //                da.Fill(dts, "tempztcode");
            //                DataTable dtexam = new DataTable();
            //                dtexam = dts.Tables[0];

            //                if (dtexam.Rows.Count > 0)
            //                {
            //                    int count = 1;
            //                    foreach (DataRow row in dtexam.Rows)
            //                    {
            //                        if (row["xdate"].Equals(DBNull.Value) == false)
            //                        {
            //                            if (count == Int32.Parse(xctno.Text.Trim().ToString()))
            //                            {
            //                                xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
            //                                xschdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
            //                                if (count < dtexam.Rows.Count)
            //                                {
            //                                    xnsdate.Value =
            //                                        Convert.ToDateTime(dtexam.Rows[count]["xdate"])
            //                                            .ToString("dd/MM/yyyy");
            //                                }
            //                                else
            //                                {
            //                                    xnsdate.Value = "";
            //                                }
            //                                break;
            //                            }
            //                            else
            //                            {
            //                                xdate.Text = "";
            //                                xnsdate.Value = "";
            //                                xschdate.Text = "";
            //                            }

            //                            count = count + 1;
            //                        }
            //                    }

            //                    //for (int i = 1; i <= dtexam.Rows.Count; i++)
            //                    //{
            //                    //    if (dtexam.Rows[i-1]["xdate"].Equals(DBNull.Value) == false)
            //                    //    {
            //                    //        if (i == Int32.Parse(xctno.Text.Trim().ToString()))
            //                    //        {
            //                    //            xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
            //                    //            if (count < dtexam.Rows.Count)
            //                    //            {
            //                    //                xnsdate.Value =
            //                    //                    Convert.ToDateTime(dtexam.Rows[count + 1]["xdate"])
            //                    //                        .ToString("dd/MM/yyyy");
            //                    //            }
            //                    //            else
            //                    //            {
            //                    //                xnsdate.Value = "";
            //                    //            }
            //                    //            break;
            //                    //        }
            //                    //        else
            //                    //        {
            //                    //            xdate.Text = "";
            //                    //            xnsdate.Value = "";
            //                    //        }
            //                    //    }
            //                    //}
            //                }


            //            }
            //        }
            //    }
            //    else
            //    {
            //        xdate.Text = "";
            //        xschdate.Text = "";
            //    }

            //    //btnRefresh_Click(null, null);
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void xreference_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    string xrefcttype1 = "";
            //    string xrefctno1 = "";
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test")
            //    {
            //        if (xreference.Text != "")
            //        {
            //            string[] sch = xreference.SelectedValue.Split('|');
            //            xrefcttype1 = sch[0];
            //            xrefctno1 = sch[1];

            //            if (xcttype.Text == xrefcttype1 && xctno.Text == xrefctno1)
            //            {
            //                message.InnerText = "Cann't reference same exam.";
            //                message.Style.Value = zglobal.warningmsg;
            //                xreference.Text = "";
            //                return;
            //            }
            //        }
            //    }

            //    string xref = xreference.SelectedValue;



            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //    {
            //        if (xreference.Text != "")
            //        {
            //            string[] sch = xreference.SelectedValue.Split('|');
            //            xrefcttype1 = sch[0];
            //            xrefctno1 = sch[1];

            //            //message.InnerText = xrefcttype1 + "-" + xrefctno1;
            //            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //            using (SqlConnection con = new SqlConnection(zglobal.constring))
            //            {
            //                using (DataSet dts = new DataSet())
            //                {
            //                    con.Open();
            //                    string query;


            //                    query =
            //                        "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";


            //                    SqlDataAdapter da = new SqlDataAdapter(query, con);

            //                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                    da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xcttype", xrefcttype1);
            //                    da.SelectCommand.Parameters.AddWithValue("@xctno", xrefctno1);
            //                    //DateTime xdate1 = xdate.Text.Trim() != string.Empty
            //                    //    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                    //        CultureInfo.InvariantCulture)
            //                    //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //                    //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


            //                    DataTable tempTable10 = new DataTable();
            //                    da.Fill(dts, "tempTable");
            //                    tempTable10 = dts.Tables["tempTable"];

            //                    if (tempTable10.Rows.Count > 0)
            //                    {
            //                        query = "SELECT * FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamh.zid=@zid AND amexamh.xrow=@xrow";


            //                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                        da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable10.Rows[0]["xrow"]));

            //                        dts.Reset();
            //                        da1.Fill(dts, "tempztcode");
            //                        DataTable dtexam1 = new DataTable();
            //                        dtexam1 = dts.Tables[0];
            //                        ViewState["dtprectmarks"] = dtexam1;
            //                        dtprectmarks = dtexam1;


            //                        xmarks.Text = dtexam1.Rows[0]["xmarks"].ToString();
            //                        xtopic.Value = dtexam1.Rows[0]["xtopic"].ToString();

            //                        //foreach (DataRow row in dtprectmarks.Rows)
            //                        //{
            //                        //    message.InnerText = message.InnerText + " " + row["xgetmark"].ToString();
            //                        //}
            //                    }
            //                    else
            //                    {
            //                        ViewState["dtprectmarks"] = null;
            //                        dtprectmarks = null;
            //                    }



            //                }
            //            }
            //        }
            //        else
            //        {
            //            ViewState["dtprectmarks"] = null;
            //            dtprectmarks = null;
            //        }
            //    }
            //    else
            //    {
            //        ViewState["dtprectmarks"] = null;
            //        dtprectmarks = null;
            //    }

            //    //BindGrid();

            //    btnRefresh_Click(sender, e);

            //    xreference.SelectedValue = xref;

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void combo_OnTextChanged_class(object sender, EventArgs e)
        {
            try
            {
                combo_OnTextChanged(sender, e);
                zglobal.fnGetComboDataCDSubject(xclass.Text.ToString().Trim(), xsubject);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void combo_OnTextChanged_subject(object sender, EventArgs e)
        {
            try
            {
                combo_OnTextChanged(sender, e);
                zglobal.fnGetComboDataCDPaper(xclass.Text.ToString().Trim(), xsubject.Text.ToString().Trim(), xpaper);
                zglobal.fnGetComboDataCDExtension(xclass.Text.ToString().Trim(), xsubject.Text.ToString().Trim(), xext);

                if (xext.Items.Count <= 1)
                {
                    _xext.Visible = false;
                }
                else
                {
                    _xext.Visible = true;
                }

                if (xpaper.Items.Count <= 1)
                {
                    _xpaper.Visible = false;
                }
                else
                {
                    _xpaper.Visible = true;
                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


    }
}