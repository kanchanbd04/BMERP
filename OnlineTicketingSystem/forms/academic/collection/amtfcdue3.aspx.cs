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

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class amtfcdue3 : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            //if (ViewState["xrow"] == null)
            //{
            //    btnSubmit.Enabled = false;
            //    btnSubmit1.Enabled = false;
            //    btnSave.Enabled = true;
            //    btnSave1.Enabled = true;
            //    btnDelete.Enabled = true;
            //    btnDelete1.Enabled = true;
            //    btnConfirm.Enabled = false;
            //    btnConfirm1.Enabled = false;
            //    //dxstatus.Visible = false;
            //    //dxstatus.Text = "-";
            //    //xsessionpro.Text = "";
            //    //xclasspro.Text = "";
            //    //xgrouppro.Text = "";
            //    //xsession.Enabled = true;
            //    //xstdid.Enabled = true;
            //    hxstatus.Value = "";
            //    //xstatus.InnerHtml = "";
            //    //zemail.InnerHtml = "";
            //    //xapprovedby.InnerHtml = "";
            //    hiddenxrow.Value = "";
            //}
            //else
            //{
            //    //xsession.Enabled = false;
            //    //xstdid.Enabled = false;

            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfcdueh",
            //                   "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    hxstatus.Value = xstatus1;
            //    //xstatus.InnerHtml = xstatus1;
            //    //zemail.InnerHtml = zglobal.fnGetValue("coalesce(zemail,'') as zemail", "amdropout",
            //    //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    //xapprovedby.InnerHtml = zglobal.fnGetValue("coalesce(xapprovedby,'') as xapprovedby", "amdropout",
            //    //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            //    //xsessionpro.Text = zglobal.fnGetValue("xsessionpro", "ampromotionh",
            //    //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            //    //xclasspro.Text = zglobal.fnGetValue("xclasspro", "ampromotionh",
            //    //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            //    //xgrouppro.Text = zglobal.fnGetValue("xgrouppro", "ampromotionh",
            //    //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    //dxstatus.Visible = true;

            //    if (xstatus1 == "New" || xstatus1 == "Undo")
            //    {
            //        btnSubmit.Enabled = true;
            //        btnSubmit1.Enabled = true;
            //        btnConfirm.Enabled = true;
            //        btnConfirm1.Enabled = true;
            //        btnSave.Enabled = true;
            //        btnSave1.Enabled = true;
            //        btnDelete.Enabled = true;
            //        btnDelete1.Enabled = true;
            //        //dxstatus.Text = xstatus1;
            //        hxstatus.Value = xstatus1;
            //        //dxstatus.Style.Value = zglobal.am_new;

            //        //xsessionpro.Enabled = true;
            //        //xclasspro.Enabled = true;
            //        //xgrouppro.Enabled = true;

            //        //xsession.Enabled = false;
            //        //xstdid.Enabled = false;

            //    }
            //    else
            //    {
            //        btnSubmit.Enabled = false;
            //        btnSubmit1.Enabled = false;
            //        btnConfirm.Enabled = false;
            //        btnConfirm1.Enabled = false;
            //        btnSave.Enabled = false;
            //        btnSave1.Enabled = false;
            //        btnDelete.Enabled = false;
            //        btnDelete1.Enabled = false;
            //        //dxstatus.Text = xstatus1;
            //        hxstatus.Value = xstatus1;
            //        //dxstatus.Style.Value = zglobal.am_submited;

            //        //xsessionpro.Enabled = false;
            //        //xclasspro.Enabled = false;
            //        //xgrouppro.Enabled = false;
            //    }

            //    //if (xstatus1 == "New" || xstatus1 == "Undo")
            //    //{
            //    //    dxstatus.Style.Value = zglobal.am_new;
            //    //}
            //    //else
            //    //{
            //    //    dxstatus.Style.Value = zglobal.am_submited;
            //    //}
            //    if (xstatus1 == "Undo1")
            //    {
            //        //int t = 0;
            //        //foreach (GridViewRow row in GridView1.Rows)
            //        //{
            //        //    Label lblxflag1 = row.FindControl("xflag1") as Label;
            //        //    Label lblxflag2 = row.FindControl("xflag2") as Label;

            //        //    if (lblxflag1.Text == "Wrong" || lblxflag2.Text == "Missing")
            //        //    {
            //        //        t = 1;
            //        //        break;
            //        //    }
            //        //}

            //        //if (t == 1)
            //        //{
            //        //    btnSave.Enabled = true;
            //        //    btnSave1.Enabled = true;
            //        //    btnDelete.Enabled = false;
            //        //    btnDelete1.Enabled = false;
            //        //    btnSubmit.Enabled = true;
            //        //    btnSubmit1.Enabled = true;
            //        //}
            //        //else
            //        //{
            //        //    btnSave.Enabled = false;
            //        //    btnSave1.Enabled = false;
            //        //    btnDelete.Enabled = false;
            //        //    btnDelete1.Enabled = false;
            //        //    btnSubmit.Enabled = false;
            //        //    btnSubmit1.Enabled = false;
            //        //}

            //        btnSave.Enabled = true;
            //        btnSave1.Enabled = true;
            //        //btnDelete.Enabled = false;
            //        //btnDelete1.Enabled = false;
            //        btnDelete.Enabled = true;
            //        btnDelete1.Enabled = true;
            //        btnSubmit.Enabled = true;
            //        btnSubmit1.Enabled = true;

            //        //xsessionpro.Enabled = true;
            //        //xclasspro.Enabled = true;
            //        //xgrouppro.Enabled = true;
            //    }

            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Session", xsession);
                    //        zglobal.fnGetComboDataCD("Session", xsessionpro);
                    //        //zglobal.fnGetComboDataCD("Term", xterm);
                    //        zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //        zglobal.fnGetComboDataCD("Education Group", xgrouppro);
                    //        // zglobal.fnGetComboDataCD("Test Type", xcttype);

                    //        zglobal.fnGetComboDataCD("Class", xclass);
                    //        zglobal.fnGetComboDataCD("Class", xclasspro);
                    //        //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //        //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    //        zglobal.fnGetComboDataCD("Section", xsection);
                    //        //zglobal.fnGetComboDataCD("Class Subject", xsubject);
                    //zglobal.fnGetComboDataCD("Dropout Type", xtype);
                    //zglobal.fnGetComboDataCD("Dropout Reason", xreason);
                    xsession.Text = zglobal.fnDefaults("xsessionacc", "Student");
                    //        //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //        //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //        //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    ViewState["xrow"] = null;
                    hiddenxrow.Value = "";
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";

                            fnButtonState();
                    //        //btnShowList.Visible = false;
                    //        // pnllistct.Visible = false;
                    //        //retestfor.Visible = false;
                    //        //xreason_d.Visible = false;
                    //        //xschdate.Enabled = false;
                    //        //schedule_d.Visible = false;

                    //        //string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                    //        //string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                    //        //string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                    //        //string xgroup1 = Request.QueryString["xgroup"] != null ? Request.QueryString["xgroup"].ToString() : "";
                    //        //string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                    //        //string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
                    //        //string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
                    //        //string xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";
                    //        ////string xcttype1 = Request.QueryString["xcttype"] != null ? Request.QueryString["xcttype"].ToString() : "";
                    //        ////string xctno1 = Request.QueryString["xctno"] != null ? Request.QueryString["xctno"].ToString() : "";

                    //        //if (xsession1 != "" && xterm1 != "" && xclass1 != "" && xsection1 != "" && xsubject1 != "")
                    //        //{
                    //        //    xsession.Text = xsession1;
                    //        //    xterm.Text = xterm1;
                    //        //    xclass.Text = xclass1;
                    //        //    xgroup.Text = xgroup1;
                    //        //    xsection.Text = xsection1;
                    //        //    xsubject.Text = xsubject1;
                    //        //    xpaper.Text = xpaper1;
                    //        //    xext.Text = xext1;

                    //        //    combo_OnTextChanged(null, null);

                    //        //    //xcttype.Text = xcttype1;
                    //        //    //xcttype_Click(null, null);

                    //        //    //xctno.Text = xctno1;
                    //        //    //xctno_Click(null, null);
                    //        //}

                    //        divliststd.Visible = false;

                    //xstatus.InnerHtml = "";
                    //zemail.InnerHtml = "";
                    //xapprovedby.InnerHtml = "";

                    //string xfperiod = zglobal.fnGetValue("xfperiod", "amdefaults",
                    // "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    // " and xtype='Student'");
                    //string xtperiod = zglobal.fnGetValue("xtperiod", "amdefaults",
                    //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    //    " and xtype='Student'");
                    //zglobal.fnGetComboDataCalendar(xcdate, Convert.ToDateTime(xfperiod), Convert.ToDateTime(xtperiod));
                    //xcdate.Text = DateTime.Now.ToString("MMM-yyyy");

                            zglobal.fnGetComboDataCalendar(xcdate, Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
                            xcdate.Text = DateTime.Now.ToString("MMM-yyyy");

                    xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    _gridrow.Text = zglobal._grid_row_value;
                    _gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();
                    SetInitialRow();
                    ViewState["xtype"] = "Studentwise";

                    //btnConfirm.Visible = false;
                    //btnConfirm1.Visible = false;

                }

                //xstdname.Text = zglobal.fnGetValue("xname + ' - ' + xclass + ' ('+xsection+')'", "amstudentvw",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       xstdid.Text.ToString().Trim() + "' and xsession='"+xsession.Text.ToString().Trim()+"'");
         //       xclass.Text = zglobal.fnGetValue("xclass", "amstudentvw",
         //          "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
         //          xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
         //       xgroup.Text = zglobal.fnGetValue("xgroup", "amstudentvw",
         //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
         //    xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
         //       xsection.Text = zglobal.fnGetValue("xsection", "amstudentvw",
         //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
         //    xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
         //       xname.Text = zglobal.fnGetValue("xname", "amstudentvw",
         //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
         //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xfname.Text = zglobal.fnGetValue("xfname", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xmname.Text = zglobal.fnGetValue("xmname", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");

                 xdescdet.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
         "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and " +
         "xcode='" + xtfccode.Text.ToString().Trim() + "'");
                 xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
         "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and " +
         "xcode='" + xtfccode.Text.ToString().Trim() + "'");

                BindGrid();
                fnRegisterPostBack();

                //xtfccode.Focus();
                //xtfccode.Attributes.Add("onfocus", "javascript:this.select();");

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnRegisterPostBack()
        {
            foreach (GridViewRow row in dgvgenerateduesnew.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            foreach (GridViewRow row in dgvgenerateduesconfirmed.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        List<string> listsubject = new List<string>();
        private void BindGrid()
        {
            if (GridView1.Rows.Count > 0)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox xstdid1 = (TextBox) row.FindControl("xstdid");
                    TextBox xname1 = (TextBox) row.FindControl("xname");
                    TextBox xclass1 = (TextBox) row.FindControl("xclass");

                    if (xstdid1.Text.Trim() != string.Empty)
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts11 = new DataSet())
                            {
                                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                                string query11 =
                                    @"SELECT xname,xclass FROM amstudentvwextacc WHERE zid=@zid AND xstdid=@xstdid AND xsession=@xsession AND zactiveacc=1";

                                SqlDataAdapter da11 = new SqlDataAdapter(query11, conn);
                                da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da11.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid1.Text.Trim().ToString());
                                da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                                da11.Fill(dts11, "tblamadmisd");

                                DataTable amexamd = dts11.Tables[0];

                                if (amexamd.Rows.Count > 0)
                                {
                                    xname1.Text = amexamd.Rows[0]["xname"].ToString();
                                    xclass1.Text = amexamd.Rows[0]["xclass"].ToString();
                                }
                            }
                        }
                    }

                }
            }

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();

            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //string xsession1 = xsession.Text.Trim().ToString();
            //string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            //string xsection1 = xsection.Text.Trim().ToString();
            ////message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            ////return;
            //string str = "";

            ////if (ViewState["sortdr"] != null)
            ////{
            ////    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY " + Convert.ToString(ViewState["colid"]) + " " + Convert.ToString(ViewState["sortdr"]);
            ////}
            ////else
            ////{
            //    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xname";
            ////}


            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //da.Fill(dts, "tempztcode");
            //DataTable dtmarks = new DataTable();
            //dtmarks = dts.Tables[0];

            //if (dtmarks.Rows.Count > 0)
            //{




            //    DataSet dts2 = new DataSet();

            //    dts2.Reset();

            //    //DateTime xexamdate1 = fnGetExamDate();
            //    string str2 = "SELECT xsubject FROM  amexamph_result_avg1 " +
            //                  "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass " +
            //                  "AND xgroup=@xgroup AND xsection=@xsection " +
            //                  "GROUP BY xsubject";

            //    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn1);
            //    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    da2.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //    da2.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //    da2.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //    da2.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //    da2.Fill(dts2, "tempztcode");
            //    DataTable dtmarks2 = new DataTable();
            //    dtmarks2 = dts2.Tables[0];
            //    //ViewState["amexamph_result_avg1"] = dtmarks2;
            //    if (dtmarks2.Rows.Count > 0)
            //    {
            //        ViewState["amexamph_result_avg1"] = dtmarks2;

            //        GridView1.Columns.Clear();


            //        DataSet dts3 = new DataSet();

            //        dts3.Reset();

            //        //DateTime xexamdate1 = fnGetExamDate();
            //        str2 = "SELECT * FROM  amexamph_result_avg1 " +
            //                      "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass " +
            //                      "AND xgroup=@xgroup AND xsection=@xsection ";

            //        SqlDataAdapter da3 = new SqlDataAdapter(str2, conn1);
            //        da3.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da3.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //        da3.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //        da3.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //        da3.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //        da3.Fill(dts3, "tempztcode");
            //        DataTable dtmarks3 = new DataTable();
            //        dtmarks3 = dts3.Tables[0];

            //        ViewState["amexamph_result_avg12"] = dtmarks3;

            //        //Change Index
            //        //ViewState["numrow"] = dtmarks2.Rows.Count;

            //        TemplateField tfield119 = new TemplateField();
            //        tfield119.HeaderText = "No.";
            //        tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        tfield119.ItemStyle.Width = 35;
            //        GridView1.Columns.Add(tfield119);

            //        //bfield = new BoundField();
            //        //bfield.HeaderText = "No.";
            //        //bfield.DataField = "xid";
            //        //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //bfield.ItemStyle.Width = 35;
            //        //GridView1.Columns.Add(bfield);

            //        bfield = new BoundField();
            //        bfield.HeaderText = "ID";
            //        //bfield.SortExpression = "xstdid";
            //        bfield.DataField = "xstdid";
            //        bfield.ItemStyle.Width = 50;
            //        bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        GridView1.Columns.Add(bfield);

            //        bfield = new BoundField();
            //        bfield.HeaderText = "Student's Name";
            //        //bfield.SortExpression = "xname";
            //        bfield.DataField = "xname";
            //        bfield.ItemStyle.Width = 200;
            //        GridView1.Columns.Add(bfield);



            //        //int tmarks = 0;
            //        //int passm = 0;
            //        //dt = new DataTable();
            //        //dt.Columns.AddRange(new DataColumn[3] { 
            //        //    new DataColumn("xsubject", typeof(string)),
            //        //    new DataColumn("xmark", typeof(string)),
            //        //    new DataColumn("xpassmark",typeof(string)) });
            //        listsubject.Clear();

            //        foreach (DataRow row in dtmarks2.Rows)
            //        {
            //            tfield = new TemplateField();
            //            tfield.HeaderText = row["xsubject"].ToString() ;
            //            tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //            tfield.ItemStyle.Width = 50;
            //            GridView1.Columns.Add(tfield);

            //            listsubject.Add(row["xsubject"].ToString());
            //            //tmarks = tmarks + Convert.ToInt32(row["xmark"].ToString());
            //            //passm = passm + Convert.ToInt32(row["xpassmark"].ToString());
            //            //dt.Rows.Add(row["xsubject"].ToString(), row["xmark"].ToString(), row["xpassmark"].ToString());
            //        }

            //         ViewState["xsubject"] = listsubject;

            //        //xtotalmaks.Text = tmarks.ToString();
            //        //int pass = (100 * passm) / tmarks;
            //        //xpassmarks.Text = pass.ToString() + "%";

            //        //TemplateField tfield9 = new TemplateField();
            //        //tfield9.HeaderText = "Pre. Marks";
            //        //tfield9.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield9.ItemStyle.Width = 70;
            //        //GridView1.Columns.Add(tfield9);

            //        ////if (xcttype.Text == "Extra Test" && xreference.SelectedItem.Text!="")
            //        //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
            //        //{
            //        //    tfield9.Visible = true;
            //        //}
            //        //else
            //        //{
            //        //    tfield9.Visible = false;
            //        //}

            //        //tfield = new TemplateField();
            //        //tfield.HeaderText = "Marks";
            //        //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield.ItemStyle.Width = 70;
            //        //GridView1.Columns.Add(tfield);

            //        //tfield = new TemplateField();
            //        //tfield.HeaderText = "%";
            //        //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield.ItemStyle.Width = 70;
            //        //GridView1.Columns.Add(tfield);





            //        //TemplateField tfield1 = new TemplateField();
            //        //tfield1.HeaderText = "Comments";
            //        //tfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        ////tfield1.ItemStyle.Width = Unit.Pixel(250);
            //        //GridView1.Columns.Add(tfield1);




            //        //TemplateField tfield2 = new TemplateField();
            //        //tfield2.HeaderText = "";
            //        //tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield2.ItemStyle.Width = Unit.Pixel(30);
            //        //GridView1.Columns.Add(tfield2);

            //        //TemplateField tfield3 = new TemplateField();
            //        //tfield3.HeaderText = "";
            //        //tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        ////tfield1.ItemStyle.Width = 50;
            //        //GridView1.Columns.Add(tfield3);




            //         if (ViewState["xrow"] != null)
            //         {
            //             using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //             {
            //                 using (DataSet dts1 = new DataSet())
            //                 {
            //                     string query = "SELECT xsrow,coalesce(xpromoted,0) as xpromoted FROM ampromotiond WHERE zid=@zid AND xrow=@xrow";
            //                     SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
            //                     da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
            //                     da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
            //                     da1.Fill(dts1, "tblamadmisd");
            //                     //tblamadmisd = new DataTable();
            //                     amexamd = dts1.Tables[0];
            //                 }
            //             }

            //             ViewState["ampromotiond"] = amexamd;
            //             string xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
            //                    "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //             ViewState["xstatus"] = xstatus1;
            //             hxstatus.Value = xstatus1;
            //         }
            //         else
            //         {
            //             hxstatus.Value = "";
            //             ViewState["ampromotiond"] = null;
            //         }


            //        //TemplateField tfield4 = new TemplateField();
            //        //tfield4.HeaderText = "";
            //        //tfield4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield4.Visible = false;
            //        //GridView1.Columns.Add(tfield4);

            //        //TemplateField tfield5 = new TemplateField();
            //        //tfield5.HeaderText = "";
            //        //tfield5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield5.Visible = false;
            //        //GridView1.Columns.Add(tfield5);

            //        //TemplateField tfield6 = new TemplateField();
            //        //tfield6.HeaderText = "";
            //        //tfield6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield6.Visible = false;
            //        //GridView1.Columns.Add(tfield6);

            //        TemplateField tfield7 = new TemplateField();
            //        tfield7.HeaderText = "Promoted";
            //        tfield7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        tfield7.ItemStyle.Width = Unit.Pixel(30);
            //        // tfield7.Visible = false;
            //        GridView1.Columns.Add(tfield7);

            //        TemplateField tfield3 = new TemplateField();
            //        tfield3.HeaderText = "";
            //        tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield1.ItemStyle.Width = 50;
            //        GridView1.Columns.Add(tfield3);

            //        BoundField bfield1 = new BoundField();
            //        bfield1.DataField = "xrow";
            //        GridView1.Columns.Add(bfield1);

            //        GridView1.DataSource = dtmarks;
            //        GridView1.DataBind();

            //        divliststd.Visible = true;

            //        int i = 1;
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            Label lbl = (Label) row.FindControl("lblno");
            //            lbl.Text = i.ToString();
            //            i++;
            //        }

            //        ViewState["dirState"] = dtmarks;
            //        // ViewState["sortdr"] = "Asc";


            //        bfield1.Visible = false;

            //        //}
            //        //else
            //        //{
            //        //    GridView1.DataSource = null;
            //        //    GridView1.DataBind();
            //        //    xtotalmaks.Text = "";
            //        //    xpassmarks.Text = "";
            //        //    ViewState["numrow"] = null;
            //        //}
            //        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 50, 78% , 60 ,false); </script>", false);

            //    }
            //    else
            //    {
            //        ViewState["amexamph_result_avg1"] = null;
            //        ViewState["amexamph_result_avg12"] = null;
            //        ViewState["xsubject"] = null;
            //        ViewState["ampromotiond"] = null;
            //        GridView1.DataSource = null;
            //        GridView1.DataBind();
            //        message.InnerHtml = "Generate final result before promotion.";
            //        message.Style.Value = zglobal.warningmsg;
            //        divliststd.Visible = false;
            //    }
            //}
            //else
            //{
            //    ViewState["amexamph_result_avg1"] = null;
            //    ViewState["amexamph_result_avg12"] = null;
            //    ViewState["xsubject"] = null;
            //    ViewState["ampromotiond"] = null;
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    //message.InnerHtml = "Student not found.";
            //    //message.Style.Value = zglobal.warningmsg;
            //    divliststd.Visible = false;
            //}

        }

        TextBox txTextBox;

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        if (ViewState["amexamph_result_avg1"] != null)
            //        {
            //            DataTable amexamph_result_avg1 = (DataTable) ViewState["amexamph_result_avg1"];

            //            Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

            //            Label lblno = new Label();
            //            lblno.ID = "lblno";
            //            e.Row.Cells[0].Controls.Add(lblno);

            //            //TextBox txtPreMarks = new TextBox();
            //            //txtPreMarks.ID = "txtPreMarks";
            //            //txtPreMarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //            //e.Row.Cells[3].Controls.Add(txtPreMarks);
            //            //txtPreMarks.Enabled = false;

            //            //TextBox txtMarks = new TextBox();
            //            //txtMarks.ID = "txtMarks";
            //            //txtMarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox bm_marks";
            //            ////txtMarks.AutoPostBack = true;
            //            ////txtMarks.TextChanged += OnTextChanged;
            //            //txtMarks.Attributes.Add("onkeyup", "enter(this,event)");
            //            //e.Row.Cells[4].Controls.Add(txtMarks);

            //            //TextBox txtComments = new TextBox();
            //            //txtComments.ID = "txtComments";
            //            //txtComments.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //            //txtComments.TextMode = TextBoxMode.MultiLine;
            //            //txtComments.Attributes.Add("onkeyup", "enter(this,event)");
            //            //e.Row.Cells[5].Controls.Add(txtComments);

            //            //HtmlGenericControl image = new HtmlGenericControl("img");
            //            //image.ID = "image2";
            //            //image.Attributes.Add("src", "/images/list-am32x32.png");
            //            //image.Attributes.Add("class", "bm_academic_list bm_list");
            //            //image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
            //            //e.Row.Cells[7].Controls.Add(image);

            //            //Label lblxline = new Label();
            //            //lblxline.ID = "xline";
            //            //e.Row.Cells[8].Controls.Add(lblxline);

            //            //Label lblxflag1 = new Label();
            //            //lblxflag1.ID = "xflag1";
            //            //e.Row.Cells[9].Controls.Add(lblxflag1);

            //            //Label lblxflag2 = new Label();
            //            //lblxflag2.ID = "xflag2";
            //            //e.Row.Cells[10].Controls.Add(lblxflag2);

            //            HtmlGenericControl lbl = new HtmlGenericControl("label");
            //            lbl.Attributes.Add("class", "switch");
            //            e.Row.Cells[amexamph_result_avg1.Rows.Count + 3].Controls.Add(lbl);

            //            CheckBox chkCheckBox = new CheckBox();
            //            chkCheckBox.ID = "xpromotion";
            //            //chkCheckBox.CssClass = "toggle-checkbox";
            //            //e.Row.Cells[amexamph_result_avg1.Rows.Count+3].Controls.Add(chkCheckBox);
            //            lbl.Controls.Add(chkCheckBox);

            //            HtmlGenericControl spn = new HtmlGenericControl("span");
            //            spn.Attributes.Add("class", "slider round");
            //            lbl.Controls.Add(spn);

            //            //ImageButton image = new ImageButton();
            //            //image.ID = "image2";
            //            //image.Attributes.Add("src", "/images/list-am32x32.png");
            //            //image.Attributes.Add("class", "bm_academic_list bm_list");
            //            //image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
            //            //e.Row.Cells[6].Controls.Add(image);

            //            //if (ViewState["xrow"] != null)
            //            //{
            //            //    if (Convert.ToString(ViewState["xstatus"]) != "New" && Convert.ToString(ViewState["xstatus"]) != "Undo" && Convert.ToString(ViewState["xstatus"]) != "Undo1")
            //            //    {
            //            //        txtComments.Enabled = false;
            //            //        txtMarks.Enabled = false;
            //            //        chkCheckBox.Enabled = false;
            //            //        //image.Enabled = false;
            //            //        //Page.ClientScript.RegisterHiddenField("hxstatus", ViewState["xstatus"].ToString());
            //            //    }



            //            //    if (amexamd.Rows.Count > 0)
            //            //    {
            //            //        foreach (DataRow row in amexamd.Rows)
            //            //        {
            //            //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
            //            //            {
            //            //                if (row["xgetmark"].ToString() == "-1.00")
            //            //                {
            //            //                    txtMarks.Text = "";
            //            //                }
            //            //                else
            //            //                {
            //            //                    txtMarks.Text = row["xgetmark"].ToString();
            //            //                }

            //            //                int chk = DBNull.Value.Equals(row["xna"]) == true
            //            //                    ? 0
            //            //                    : Convert.ToInt32(row["xna"].ToString());

            //            //                if (chk == 1)
            //            //                {
            //            //                    chkCheckBox.Checked = true;
            //            //                }
            //            //                else
            //            //                {
            //            //                    chkCheckBox.Checked = false;
            //            //                }

            //            //                txtComments.Text = row["xremarks"].ToString();
            //            //                lblxline.Text = row["xline"].ToString();
            //            //                lblxflag1.Text = row["xflag11"].ToString();
            //            //                lblxflag2.Text = row["xflag22"].ToString();

            //            //                //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
            //            //                //{
            //            //                //    //if (row["xflag11"].ToString() == "Wrong" ||
            //            //                //    //    row["xflag22"].ToString() == "Missing" || row["xflag11"].ToString() == "Corrected" ||
            //            //                //    //    row["xflag22"].ToString() == "Taken")
            //            //                //    //if (row["xflag11"].ToString() == "" ||
            //            //                //    //    row["xflag22"].ToString() == "")
            //            //                //    if (row["xflag11"].ToString() == "Wrong" || row["xflag22"].ToString() == "Missing")
            //            //                //    {
            //            //                //        txtComments.Enabled = true;
            //            //                //        txtMarks.Enabled = true;
            //            //                //        chkCheckBox.Enabled = true;
            //            //                //    }

            //            //                //    //if (lblxline.Text == "" || lblxline.Text == String.Empty)
            //            //                //    //{
            //            //                //    //    txtComments.Enabled = true;
            //            //                //    //    txtMarks.Enabled = true;
            //            //                //    //}

            //            //                //}
            //            //                break;
            //            //            }
            //            //        }

            //            //        //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
            //            //        //{
            //            //        //    if (lblxline.Text == "" || lblxline.Text == String.Empty)
            //            //        //    {
            //            //        //        txtComments.Enabled = true;
            //            //        //        txtMarks.Enabled = true;
            //            //        //        chkCheckBox.Enabled = true;
            //            //        //    }
            //            //        //}
            //            //    }


            //            //}

            //            if (ViewState["ampromotiond"] != null)
            //            {
            //                if (ViewState["xstatus"].ToString() == "Approved")
            //                {
            //                    chkCheckBox.InputAttributes.Add("disabled", "disabled");
            //                }
            //                else
            //                {
            //                    chkCheckBox.InputAttributes.Remove("disabled");
            //                }

            //                DataTable ampromotiond = (DataTable) ViewState["ampromotiond"];
            //                DataRow[] result =
            //                   ampromotiond.Select("xsrow=" +
            //                                                xrow );
            //                if (result.Length > 0)
            //                {
            //                    if (result[0]["xpromoted"].ToString() == "1")
            //                    {
            //                        chkCheckBox.Checked = true;
            //                    }
            //                    else
            //                    {
            //                        chkCheckBox.Checked = false;
            //                    }
            //                }



            //            }

            //            //if (ViewState["dtprectmarks"] != null)
            //            //{
            //            //    DataTable dtprectmarks = (DataTable)ViewState["dtprectmarks"];
            //            //    if (dtprectmarks.Rows.Count > 0)
            //            //    {
            //            //        foreach (DataRow row in dtprectmarks.Rows)
            //            //        {
            //            //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
            //            //            {
            //            //                if (row["xgetmark"].ToString() == "-1.00")
            //            //                {
            //            //                    txtPreMarks.Text = "";
            //            //                }
            //            //                else
            //            //                {
            //            //                    txtPreMarks.Text = row["xgetmark"].ToString();
            //            //                }

            //            //                int chk = DBNull.Value.Equals(row["xna"]) == true
            //            //                  ? 0
            //            //                  : Convert.ToInt32(row["xna"].ToString());

            //            //                if (chk == 1)
            //            //                {
            //            //                    chkCheckBox.Checked = true;
            //            //                }
            //            //                else
            //            //                {
            //            //                    chkCheckBox.Checked = false;
            //            //                }

            //            //                break;
            //            //            }
            //            //        }
            //            //    }
            //            //}
            //            //else
            //            //{
            //            //    txtPreMarks.Text = "";
            //            //}

            //            DataTable amexamph_result_avg12 = (DataTable)ViewState["amexamph_result_avg12"];
            //            if (amexamph_result_avg12.Rows.Count > 0)
            //            {
            //                //DataRow[] result;

            //                for (int i = 3; i < amexamph_result_avg1.Rows.Count + 3; i++)
            //                {
            //                    DataRow[] result =
            //                    amexamph_result_avg12.Select("xsrow=" +
            //                                                 xrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[i - 3] + "'");
            //                    if (result.Length > 0)
            //                    {
            //                        e.Row.Cells[i].Text = result[0]["xgrade"].ToString();
            //                        e.Row.Cells[i].ToolTip = result[0]["xsubject"].ToString() + "\n Marks: " +
            //                                                 result[0]["xaveragemarks"].ToString();
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int i = 3; i < amexamph_result_avg1.Rows.Count + 3; i++)
            //                {
            //                    e.Row.Cells[i].Text = "";
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));

            for (int i = 0; i < 50; i++)
            {
                dr = dt.NewRow();
                //dr["RowNumber"] = 1;
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = "0.00";
                dr["Column5"] = "0.00";
                dr["Column6"] = string.Empty;
                dt.Rows.Add(dr);
            }

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Create Columns in GridView

            //tfield = new TemplateField();
            //tfield.HeaderText = "TFC Code";
            //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            //tfield.ItemStyle.Width = 120;
            //GridView1.Columns.Add(tfield);

            //Bind the Gridview   
            GridView1.DataSource = dt;
            GridView1.DataBind();

            ////After binding the gridview, we can then extract and fill the DropDownList with Data   
            //DropDownList ddl1 = (DropDownList)Gridview1.Rows[0].Cells[3].FindControl("DropDownList1");
            //DropDownList ddl2 = (DropDownList)Gridview1.Rows[0].Cells[4].FindControl("DropDownList2");
            //FillDropDownList(ddl1);
            //FillDropDownList(ddl2); 
        }

        private void AddNewRowToGrid()
        {

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ////Store the current data to ViewState for future reference   

                    //ViewState["CurrentTable"] = dtCurrentTable;


                    //for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xstdid");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xname");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xclass");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xamtdue");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xdisfixed");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xremarks");

                        dtCurrentTable.Rows[i]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i]["Column3"] = box3.Text;
                        dtCurrentTable.Rows[i]["Column4"] = box4.Text;
                        dtCurrentTable.Rows[i]["Column5"] = box5.Text;
                        dtCurrentTable.Rows[i]["Column6"] = box6.Text;

                        ////extract the DropDownList Selected Items   

                        //DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[3].FindControl("DropDownList1");
                        //DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[4].FindControl("DropDownList2");

                        // Update the DataRow with the DDL Selected Items   

                        //dtCurrentTable.Rows[i]["Column3"] = ddl1.SelectedItem.Text;
                        //dtCurrentTable.Rows[i]["Column4"] = ddl2.SelectedItem.Text;

                    }

                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;

                    //Rebind the Grid with the current data to reflect changes   
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            //else
            //{
            //    Response.Write("ViewState is null");

            //}
            //Set Previous Data on Postbacks   
            SetPreviousData();
        }

        private void SetPreviousData()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xstdid");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xname");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xclass");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xamtdue");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xdisfixed");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xremarks");


                        //DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                        //DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("DropDownList2");

                        ////Fill the DropDownList with Data   
                        //FillDropDownList(ddl1);
                        //FillDropDownList(ddl2);

                        //if (i < dt.Rows.Count - 1)
                        //{

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Column1"].ToString();
                            box2.Text = dt.Rows[i]["Column2"].ToString();
                            box3.Text = dt.Rows[i]["Column3"].ToString();
                            box4.Text = dt.Rows[i]["Column4"].ToString();
                            box5.Text = dt.Rows[i]["Column5"].ToString();
                            box6.Text = dt.Rows[i]["Column6"].ToString();

                            ////Set the Previous Selected Items on Each DropDownList  on Postbacks   
                            //ddl1.ClearSelection();
                            //ddl1.Items.FindByText(dt.Rows[i]["Column3"].ToString()).Selected = true;

                            //ddl2.ClearSelection();
                            //ddl2.Items.FindByText(dt.Rows[i]["Column4"].ToString()).Selected = true;

                        //}

                        rowIndex++;
                    }
                }
            }
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewRowToGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                if (ViewState["CurrentTable"] != null)
                {

                    DataTable dt = (DataTable)ViewState["CurrentTable"];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xstdid");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xname");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xclass");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xamtdue");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xdisfixed");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("xremarks");

                        dt.Rows[i]["Column1"] = box1.Text;
                        dt.Rows[i]["Column2"] = box2.Text;
                        dt.Rows[i]["Column3"] = box3.Text;
                        dt.Rows[i]["Column4"] = box4.Text;
                        dt.Rows[i]["Column5"] = box5.Text;
                        dt.Rows[i]["Column6"] = box6.Text;

                    }


                    if (dt.Rows.Count > 1)
                    {
                        //if (gvRow.RowIndex < dt.Rows.Count - 1)
                        //{
                            //Remove the Selected Row data and reset row number  
                            dt.Rows.Remove(dt.Rows[rowID]);
                            //ResetRowID(dt);
                        //}
                    }


                    

                    //Store the current data in ViewState for future reference  
                    ViewState["CurrentTable"] = dt;

                    //Re bind the GridView for the updated data  
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                //Set Previous Data on Postbacks  
                SetPreviousData(); 
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //DataTable dtrslt = (DataTable)ViewState["dirState"];
            ////message.InnerHtml = e.SortExpression;
            //if (dtrslt.Rows.Count > 0)
            //{
            //    ViewState["colid"] = e.SortExpression;
            //    if (ViewState["sortdr"] != null)
            //    {
            //        if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            //        {
            //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
            //            ViewState["sortdr"] = "Desc";
            //        }
            //        else
            //        {
            //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
            //            ViewState["sortdr"] = "Asc";
            //        }
            //    }
            //    else
            //    {
            //        dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
            //        ViewState["sortdr"] = "Desc";
            //    }
            //    GridView1.DataSource = dtrslt;
            //    GridView1.DataBind();

            //    int i = 1;
            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        Label lbl = (Label)row.FindControl("lblno");
            //        lbl.Text = i.ToString();
            //        i++;
            //    }
            //    //UpdatePanel1.Update();
            //}
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
            //        //    //message.InnerHtml = lb.ID.ToString();
            //        //    int xcellno = int.Parse(lb.ID.ToString().Substring(9));
            //        //    //message.InnerHtml = lb.ID.ToString().Substring(9);
            //        //    lbldate.Text = Convert.ToDateTime(row.Cells[2 + (int) ViewState["rowCount"]].Text).ToString("dddd, MMMM dd, yyyy");
            //        //    lblperiod.Text = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
            //        //    lblsection.Text = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

            //        //    _xdate.Value = row.Cells[2 + (int) ViewState["rowCount"]].Text.ToString();
            //        //    _xperiod.Value = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
            //        //    _xsection.Value = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();
            //        int val = 4;
            //        //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //        //{
            //        //    val = 4;
            //        //}
            //        //else
            //        //{
            //        //    val = 3;
            //        //}

            //        if (Convert.ToDecimal(row.Cells[val].Text.ToString()) > Convert.ToDecimal(xmarks.Text.Trim()))
            //        {
            //            row.Cells[val].BackColor = Color.Bisque;
            //        }

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
            //        string query =

            //        "SELECT * FROM ampromotionh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection";


            //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());

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
                //foreach (GridViewRow row in GridView1.Rows)
                //{


                //    TextBox txtTextBox1 = row.FindControl("xstdid") as TextBox;
                //    message.InnerHtml = message.InnerHtml + " " + txtTextBox1.Text;
                //}
                //return;

                //btnRefresh_Click(sender,e);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = 0;
                message.InnerHtml = "";

                ////Check for final approval
                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts = new DataSet())
                //    {
                //        con.Open();
                //        string query =
                //            //"SELECT count(*) FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xstatus='Approved3' ";
                //            "SELECT count(*) FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test' AND xstatus='Approved3' ";

                //        SqlDataAdapter da = new SqlDataAdapter(query, con);

                //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da.SelectCommand.Parameters.AddWithValue("@xsession",
                //            xsession.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        //da.SelectCommand.Parameters.AddWithValue("@xsection",
                //        //    xsection.Text.ToString().Trim());
                //        //da.SelectCommand.Parameters.AddWithValue("@xsubject",
                //        //    xsubject.Text.ToString().Trim());
                //        //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                //        //da.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());



                //        DataTable tempTable = new DataTable();
                //        da.Fill(dts, "tempTable");
                //        tempTable = dts.Tables["tempTable"];

                //        if (Convert.ToInt32(tempTable.Rows[0][0]) > 0)
                //        {
                //            message.InnerHtml = "Best test selection already approved. Cann't insert new record for this term.";
                //            message.Style.Value = zglobal.warningmsg;
                //            return;
                //        }
                //    }
                //}


                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xtfccode.Text == "" || xtfccode.Text == string.Empty || xtfccode.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>TFC Code</li>";
                    isValid = false;
                }
                if (xcdate.Text == "" || xcdate.Text == string.Empty || xcdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Charge Period </li>";
                    isValid = false;
                }
                //if (xamount.Text == "" || xamount.Text == string.Empty || xamount.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Default Amount</li>";
                //    isValid = false;
                //}
                //if (xsign.Text == "" || xsign.Text == string.Empty || xsign.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Sign</li>";
                //    isValid = false;
                //}


                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                string istfccodefound = zglobal.fnGetValue("xcode", "mscodesam",
                      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and xcode='" + xtfccode.Text.ToString().Trim() + "'");

                if (istfccodefound == "")
                {
                    message.InnerHtml = "Wrong TFC Code Selected.";
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }
                //fnCheckRow();
                string xstatus2 = "";
                if (ViewState["xrow"] != null)
                {
                    xstatus2 = zglobal.fnGetValue("xstatus", "amtfcdueh",
                          "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                    if (xstatus2 != "New" && xstatus2 != "Undo" && xstatus2 != "Undo1" && xstatus2 != "")
                    {
                        message.InnerHtml = "Status : " + xstatus2 + ". Cann't change data.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                int flag = 0;
                //foreach (GridViewRow row in GridView1.Rows)
                //{


                //    TextBox txtTextBox1 = row.FindControl("xstdid") as TextBox;

                //    if (txtTextBox1.Text == "" || txtTextBox1.Text == String.Empty)
                //    {
                //        row.BackColor = zglobal.rowerr;
                //        flag = 1;
                //    }
                //}

                //if (flag == 1)
                //{
                //    message.InnerText = "Please enter Student ID.";
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}


                flag = 0;
                List<String> val = new List<String>();
                val.Add("");
                foreach (GridViewRow row in GridView1.Rows)
                {


                    TextBox txtTextBox1 = row.FindControl("xstdid") as TextBox;
                    if (txtTextBox1.Text != String.Empty)
                    {
                        if (val.Contains(txtTextBox1.Text.Trim().ToString()))
                        {
                            //txtTextBox1.Text = "";
                            row.BackColor = zglobal.rowerr;
                            flag = 1;
                        }
                        else
                        {
                            val.Add(txtTextBox1.Text.Trim().ToString());
                        }
                    }

                }

                if (flag == 1)
                {
                    message.InnerText = "Duplicate student selected.";
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                int flag1 = 0;
                List<String> val1 = new List<String>();
                val1.Add("");
                foreach (GridViewRow row in GridView1.Rows)
                {


                    TextBox txtTextBox1 = row.FindControl("xstdid") as TextBox;

                    if (txtTextBox1.Text.Trim().ToString() == string.Empty)
                        continue;

                    string isStudentFound = zglobal.fnGetValue("xname", "amstudentvwext1",
       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
       txtTextBox1.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'  and zactiveacc=1");

                    if (isStudentFound == "")
                    {
                       
                        if (val1.Contains(txtTextBox1.Text.Trim().ToString()))
                        {
                            //txtTextBox1.Text = "";
                            row.BackColor = zglobal.rowerr;
                            flag1 = 1;
                        }
                        else
                        {
                            val1.Add(txtTextBox1.Text.Trim().ToString());
                        }
                        
                    }

                    

                }

                if (flag1 == 1)
                {
                    message.InnerHtml = "Student not found.";
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts = new DataSet())
                //    {
                //        con.Open();
                //        string query =
                //            "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";

                //        SqlDataAdapter da = new SqlDataAdapter(query, con);

                //        da.SelectCommand.Parameters.AddWithValue("@zid",_zid);
                //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xcttype", xcttype.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xctno", xctno.Text.ToString().Trim());



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

                ////Duplicate entry check
                //if (ViewState["xrow"] != null)
                //{
                //    message.InnerHtml = "Cann't insert duplicate record.";
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}



                string[] date = new string[2];
                date = xcdate.Text.Split('-');

                int year = Int32.Parse(date[1]);
                int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                DateTime xdate1 = new DateTime(year, month, 1);

                string xtype1 = ViewState["xtype"].ToString();
                string xsession1 = xsession.Text.Trim().ToString();
                string xclass1 = "";
                string xgroup1 = "";
                DateTime xcdate1 = xdate1;
                DateTime xtdate1 = DateTime.Now;
                string xstatus1 = "New";
                string xremarks1 = "";

                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xstdid1 = "";
                string xtfccode1 = "";


                using (TransactionScope tran = new TransactionScope())
                {
                    //if (GridView1.Rows.Count > 0)
                    //{
                    if (ViewState["xrow"] == null)
                    {


                        ////Duplicate entry check
                        //using (SqlConnection con = new SqlConnection(zglobal.constring))
                        //{
                        //    using (DataSet dts = new DataSet())
                        //    {
                        //        con.Open();
                        //        string query =
                        //            "SELECT * FROM amdropout WHERE zid=@zid AND xsession=@xsession AND xsrow=(select xrow from amadmis where xstdid=@xstdid) ";

                        //        SqlDataAdapter da = new SqlDataAdapter(query, con);

                        //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        //        da.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid.Text.ToString().Trim());

                        //        DataTable tempTable = new DataTable();
                        //        da.Fill(dts, "tempTable");
                        //        tempTable = dts.Tables["tempTable"];

                        //        if (tempTable.Rows.Count > 0)
                        //        {
                        //            message.InnerHtml = "Cann't insert duplicate record.";
                        //            message.Style.Value = zglobal.warningmsg;
                        //            return;
                        //        }
                        //    }
                        //}


                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;

                            DateTime ztime = DateTime.Now;
                            DateTime zutime = DateTime.Now;
                            _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                            xrow = 0;

                            //string xtfccode1 = "";
                            //string xclass1 = "";
                            //string xgroup1 = "";
                            //string xsection1 = "";
                            //string xstdid1 = "";
                            //decimal xamount1 = 0;
                            //decimal xdisfixed1 = 0;
                            //decimal xdisperc1 = 0;
                            //decimal xvatfixed1 = 0;
                            //decimal xvatperc1 = 0;
                            //int xsign1 = 1;
                            //DateTime xeffdate1 = DateTime.Now;
                            //int zactive1 = 1;
                            //string xstatus1 = "New";
                            //string xremarks1 = "";
                            //string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            //string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            //string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            //DateTime xsubmitdt = DateTime.Now;


                            //string query =
                            //    "INSERT INTO amdropout (ztime,zid,xrow,xsession,xsrow,xtype,xreason,xtccertificate,xmarksheet,xcharcertificate,xreference,xdate,xstatus,xremarks,zemail,xstdid,xname,xclass,xgroup,xsection) " +
                            //    "VALUES(@ztime,@zid,@xrow,@xsession,(select xrow from amadmis where zid=@zid and xstdid=@xstdid),@xtype,@xreason,@xtccertificate,@xmarksheet,@xcharcertificate,@xreference,@xdate,@xstatus,@xremarks,@zemail,@xstdid," +
                            //    "(select xname from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession), " +
                            //    "(select xclass from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession), " +
                            //    "(select xgroup from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession), " +
                            //    "(select xsection from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession)) ";

                            string query =
                              "INSERT INTO amtfcdueh (ztime,zid,xrow,xtype,xsession,xclass,xgroup,xcdate,xtdate,xstatus,zemail,xremarks,xtfccode) " +
                                    "VALUES(@ztime,@zid,@xrow,@xtype,@xsession,@xclass,@xgroup,@xcdate,@xtdate,@xstatus,@zemail,@xremarks,@xtfccode)";

                            xrow = zglobal.GetMaximumInvoiceResetMonthlyBusiness("xcdate", "xrow", "amtfcdueh", xcdate1);
                            ViewState["xrow"] = xrow;
                            hiddenxrow.Value = xrow.ToString();
                            xtdate1 = xtdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xtdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.Now;
                            //xstdid1 = xstdid.Text.Trim().ToString();
                            xremarks1 = xremarks.Text.Trim().ToString();
                            xtfccode1 = xtfccode.Text.Trim().ToString();



                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", xrow);
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xsession", xsession1);
                            cmd.Parameters.AddWithValue("@xclass", xclass1);
                            cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                            cmd.Parameters.AddWithValue("@xcdate", xcdate1);
                            cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                            cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                            cmd.Parameters.AddWithValue("@xtfccode", xtfccode1);
                            cmd.ExecuteNonQuery();

                        }
                    }



                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        string query = "";
                        query = "DELETE FROM amtfcdued WHERE zid=@zid AND xrow=@xrow";
                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                        //if (xstatus1 != "Undo1" && xstatus1 != "Undo")
                        //if (xstatus1 != "Undo1")
                        //{
                        cmd.ExecuteNonQuery();
                        //}

                        string xcdate123 = zglobal.fnGetValue("xcdate", "amtfcdueh",
                      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xrow=" + ViewState["xrow"].ToString());

                        int xrownew=0;
                        if (Convert.ToDateTime(xcdate123) != xdate1)
                        {

                            xrownew = zglobal.GetMaximumInvoiceResetMonthlyBusiness("xcdate", "xrow", "amtfcdueh", xcdate1);
                        }
                        else
                        {
                            xrownew = Convert.ToInt32(ViewState["xrow"]);
                        }

                        if (xrow == 0)
                        {
                            xsession1 = xsession.Text.Trim().ToString();
                            xtdate1 = xtdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xtdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.Now;
                            xtfccode1 = xtfccode.Text.Trim().ToString();
                            xremarks1 = xremarks.Text.Trim().ToString();

                            query = "UPDATE amtfcdueh SET zutime=@zutime,xemail=@xemail,xrow=@xrownew, " +
                                   "xsession=@xsession, xtfccode=@xtfccode, xclass=@xclass, xgroup=@xgroup, " +
                                    "xcdate = @xcdate, xtdate=@xtdate, xremarks=@xremarks " +
                                   "WHERE zid=@zid AND xrow=@xrow ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            cmd.Parameters.AddWithValue("@xrownew", xrownew);
                            cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@xemail",
                                Convert.ToString(HttpContext.Current.Session["curuser"]));
                            cmd.Parameters.AddWithValue("@xsession", xsession1);
                            cmd.Parameters.AddWithValue("@xstdid", xstdid1);
                            cmd.Parameters.AddWithValue("@xclass", xclass1);
                            cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                            cmd.Parameters.AddWithValue("@xcdate", xcdate1);
                            cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                            cmd.Parameters.AddWithValue("@xtfccode", xtfccode1);
                            cmd.ExecuteNonQuery();

                            ViewState["xrow"] = xrownew;
                        }






                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            TextBox xstdid1234 = row.FindControl("xstdid") as TextBox;
                            TextBox xname1234 = row.FindControl("xname") as TextBox;

                            //if (xstdid1234.Text != string.Empty && xname1234.Text != string.Empty)
                            if (xstdid1234.Text != string.Empty)
                            {
                                int xline = zglobal.GetMaximumIdInt("xline", "amtfcdued",
                                    " zid=" + _zid + " and xrow=" + Convert.ToInt32(ViewState["xrow"]), "line");
                                TextBox xstdid12 = row.FindControl("xstdid") as TextBox;
                                TextBox xamtdue12 = row.FindControl("xamtdue") as TextBox;
                                TextBox xdisfixed12 = row.FindControl("xdisfixed") as TextBox;
                                string xstdid123 = Convert.ToString(xstdid12.Text.Trim());
                                decimal xamtdue123;
                                if (xamtdue12.Text.Trim().ToString() == "" ||
                                    xamtdue12.Text.Trim().ToString() == String.Empty)
                                {
                                    xamtdue123 = 0;
                                }
                                else
                                {
                                    xamtdue123 = decimal.Parse(xamtdue12.Text.Trim().ToString());
                                }

                                decimal xdisfixed123;
                                if (xdisfixed12.Text.Trim().ToString() == "" ||
                                xdisfixed12.Text.Trim().ToString() == String.Empty)
                                {
                                    xdisfixed123 = 0;
                                }
                                else
                                {
                                    xdisfixed123 = decimal.Parse(xdisfixed12.Text.Trim().ToString());
                                }

                               

                                TextBox xremarsk12 = row.FindControl("xremarks") as TextBox;


                                query =
                                    "INSERT INTO amtfcdued (zid,xrow,xline,xtfccode,xamount,xdisfixed,xdisperc,xdiscount,xvatfixed,xvatperc,xvat,xamtdue,xremarks,xsrow,xclassd) " +
                                    "VALUES(@zid,@xrow,@xline,@xtfccode,@xamount,@xdisfixed,@xdisperc,@xdiscount,@xvatfixed,@xvatperc,@xvat,@xamtdue,@xremarks," +
                                    "(select xrow from amadmis where zid=@zid and xstdid=@xstdid),(select xclass from amstudentvwext1 where zid=@zid and xstdid=@xstdid and xsession=@xsession)) ";


                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.Parameters.AddWithValue("@xtfccode", xtfccode1);
                                cmd.Parameters.AddWithValue("@xamount", xamtdue123);
                                cmd.Parameters.AddWithValue("@xdisfixed", xdisfixed123);
                                cmd.Parameters.AddWithValue("@xdisperc", Convert.ToDecimal("0"));
                                cmd.Parameters.AddWithValue("@xdiscount", xdisfixed123);
                                cmd.Parameters.AddWithValue("@xvatfixed", Convert.ToDecimal("0"));
                                cmd.Parameters.AddWithValue("@xvatperc", Convert.ToDecimal("0"));
                                cmd.Parameters.AddWithValue("@xvat", Convert.ToDecimal("0"));
                                cmd.Parameters.AddWithValue("@xamtdue", (xamtdue123 - xdisfixed123));
                                cmd.Parameters.AddWithValue("@xremarks", xremarsk12.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xstdid", xstdid12.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                                cmd.ExecuteNonQuery();

                            }
                        }



                    }
                    //}
                    //else
                    //{
                    //    message.InnerHtml = "No student found.";
                    //    message.Style.Value = zglobal.warningmsg;
                    //    return;
                    //}

                    tran.Complete();

                }

                

                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                // btnRefresh_Click(null, null);
                //message.InnerHtml = zglobal.savesuccmsg;
                message.InnerHtml = "Successfully Generated.";
                message.Style.Value = zglobal.successmsg;
                //ViewState["xrow"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";

                //BindGrid();

                xrow1.Text = ViewState["xrow"].ToString();
                fnButtonState();
                fnFillGrid2();


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
                // message.InnerHtml = "";


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

                //BindGrid();

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
            //            //    //xcttype.Text = "Test";
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
                    string query =
                         "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession,xcdate,xtfccode,xtdate, " +
                         "(select xdescdet from mscodesam where zid=amtfcdueh.zid and xtype='TFC Code' and xcode=amtfcdueh.xtfccode) as xdescdet, " +
                         "(select xusername from ztuser where zid=amtfcdueh.zid and xuser=amtfcdueh.zemail) as xusername " +
                         "FROM amtfcdueh WHERE zid=@zid AND xtype='Studentwise' AND xstatus='New' " +
                         "order by xrow desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvgenerateduesnew.DataSource = tempTable;
                        dgvgenerateduesnew.DataBind();
                    }
                    //else
                    //{
                    //    // btnShowList.Visible = false;
                    //    pnllistct.Visible = false;
                    //    GridView2.DataSource = null;
                    //    GridView2.DataBind();
                    //}


                }
            }


            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    //string query =
                    //     "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession, " +
                    //      "(select xname from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xname, " +
                    //     "(select xstdid from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xstdid, " +
                    //     "(select xclass from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xclass, " +
                    //     "(select xgroup from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xgroup, " +
                    //     "(select xsection from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xsection, " +
                    //     "xtype, xreason, xstatus, xdate " +
                    //     "FROM amdropout WHERE zid=@zid AND xstatus='Approved' order by xrow desc";

                    string query =
                       "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession,xcdate,xtfccode,xtdate, " +
                         "(select xdescdet from mscodesam where zid=amtfcdueh.zid and xtype='TFC Code' and xcode=amtfcdueh.xtfccode) as xdescdet, " +
                         "(select xusername from ztuser where zid=amtfcdueh.zid and xuser=amtfcdueh.zemail) as xusername " +
                         "FROM amtfcdueh WHERE zid=@zid AND xtype='Studentwise' AND xstatus='Confirmed' " +
                         "order by xrow desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvgenerateduesconfirmed.DataSource = tempTable;
                        dgvgenerateduesconfirmed.DataBind();
                    }
                    //else
                    //{
                    //    // btnShowList.Visible = false;
                    //    pnllistct.Visible = false;
                    //    GridView2.DataSource = null;
                    //    GridView2.DataBind();
                    //}


                }
            }
        }

        protected void fnFillGrid6(object sender, EventArgs e)
        {
            try
            {
                fnFillGrid2();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            ////    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ////    ////System.Threading.Thread.Sleep(1000);
            //    message.InnerHtml = "";
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    ViewState["xrow"] = null;
            //    divliststd.Visible = false;
            //    //    //fnGetScheduleDate();
            //    //    xdate.Text = "";
            //    //    //xctno.Items.Clear();
            //    //    //xctno.Items.Add("");
            //    //    //xcttype.Text = "";
            //    //    //xctno.Text = "";
            //    //    xmarks.Text = "";
            //    //    //xtopic.Value = "";
            //    //    xdetails.Value = "";
            //    //    //xcteacher.Text = "-";
            //    //    xcteacher.Text = "";
            //    //    //xsteacher.Text = "-";
            //    //    xsteacher.Text = "";
            //    //    dxstatus.Text = "-";
            //    //    fnButtonState();
            //    //    _classteacher.Value = "";
            //    //    _subteacher.Value = "";

            //    //    //fnFillGrid2();

            //    //    btnRefresh_Click(sender,e);
            //    //    //zglobal.fnComboBoxValueWithItem(xreference, "(xcttype + '-' + xctno) as xtext,(xcttype + '|' + xctno) as xvalue", "amexamh", "zid=" + _zid + " and xsession='" + xsession.Text + "' and xterm='" + xterm.Text +
            //    //    //     "' and xclass='" + xclass.Text + "' and xgroup='" + xgroup.Text + "' and xsection='" + xsection.Text + "' and xsubject='" + xsubject.Text + "' and xpaper='" + xpaper.Text + "' and xtype='Class Test' and xcttype in ('Test','Test (WS)') order by xctno");


            //    //    //fnGetScheduleDate("comval");

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
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
            try
            {

                fnFillControl(((LinkButton)sender).Text);
               
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void FillControl2(object sender, EventArgs e)
        {
            try
            {
                //message.InnerHtml = "Hi";
                if (xrow1.Text.Trim().ToString() != String.Empty)
                {
                    fnFillControl(xrow1.Text.Trim().ToString());
                }
                else
                {
                    message.InnerHtml = "Enter transaction code.";
                    message.Style.Value = zglobal.am_warningmsg;
                    xrow1.Focus();
                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnFillControl(string xrow123)
        {
            message.InnerHtml = "";

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();


            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            int xrow = Convert.ToInt32(xrow123);


            string str = "SELECT  xrow,xsession,xtfccode, " +
                         "(select xdescdet from mscodesam where zid=amtfcdueh.zid and xtype='TFC Code' and xcode=amtfcdueh.xtfccode) as xdescdet, " +
                         "xcdate,xtdate,xremarks,xstatus " +
                         "FROM amtfcdueh where zid=@zid  and xrow=@xrow ";




            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
            da.Fill(dts, "tempztcode");
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];

            if (dttemp.Rows.Count <= 0)
            {
                message.InnerHtml = "Wrong transaction code.";
                message.Style.Value = zglobal.am_warningmsg;
                return;
            }

            ViewState["xrow"] = xrow.ToString();
            hiddenxrow.Value = ViewState["xrow"].ToString();

            xsession.Text = dttemp.Rows[0]["xsession"].ToString();
            xtfccode.Text = dttemp.Rows[0]["xtfccode"].ToString();
            xdescdet.Text = dttemp.Rows[0]["xdescdet"].ToString();
            xtfccodetitle.Text = dttemp.Rows[0]["xdescdet"].ToString();
            xrow1.Text = dttemp.Rows[0]["xrow"].ToString();

            DateTime xcdate1 = Convert.ToDateTime(dttemp.Rows[0]["xcdate"]);
            string month1 = zgetvalue.GetMonthName(xcdate1.Month);
            string year1 = xcdate1.Year.ToString();

            xcdate.Text = month1 + "-" + year1;
            xtdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
            xremarks.Text = dttemp.Rows[0]["xremarks"].ToString();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT (select xstdid from amadmis where zid=amtfcdued.zid and xrow=amtfcdued.xsrow) as xstdid, " +
                         "(select xname from amadmis where zid=amtfcdued.zid and xrow=amtfcdued.xsrow) as xname," +
                         "(select xclass from amstudentvwext1 where zid=amtfcdued.zid and xrow=amtfcdued.xsrow and xsession=" +
                         "(select xsession from amtfcdueh where zid=amtfcdued.zid and xrow=amtfcdued.xrow)) as xclass," +
                         "xamtdue, xremarks,xamount,xdisfixed " +
                         "FROM amtfcdued WHERE zid=@zid AND xrow=@xrow  " +
                         "order by xline";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        DataRow dr = null;

                        //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column6", typeof(string)));

                        int i = 0;
                        foreach (DataRow row in tempTable.Rows)
                        {
                            dr = dt.NewRow();
                            //dr["RowNumber"] = 1;
                            dr["Column1"] = tempTable.Rows[i]["xstdid"].ToString();
                            dr["Column2"] = tempTable.Rows[i]["xname"].ToString();
                            dr["Column3"] = tempTable.Rows[i]["xclass"].ToString();
                            dr["Column4"] = tempTable.Rows[i]["xamount"].ToString();
                            dr["Column5"] = tempTable.Rows[i]["xdisfixed"].ToString();
                            dr["Column6"] = tempTable.Rows[i]["xremarks"].ToString();
                            dt.Rows.Add(dr);

                            i = i + 1;
                        }

                        if (tempTable.Rows.Count < 50)
                        {
                            for (int j = tempTable.Rows.Count-1; j < 50; j++)
                            {
                                dr = dt.NewRow();
                                //dr["RowNumber"] = 1;
                                dr["Column1"] = string.Empty;
                                dr["Column2"] = string.Empty;
                                dr["Column3"] = string.Empty;
                                dr["Column4"] = "0.00";
                                dr["Column5"] = "0.00";
                                dr["Column6"] = string.Empty;
                                dt.Rows.Add(dr);
                            }
                        }
                        



                        ViewState["CurrentTable"] = dt;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        i = 0;
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            TextBox xstdid1 = row.FindControl("xstdid") as TextBox;
                            TextBox xname1 = row.FindControl("xname") as TextBox;
                            TextBox xclass1 = row.FindControl("xclass") as TextBox;
                            TextBox xamtdue1 = row.FindControl("xamtdue") as TextBox;
                            TextBox xdisfixed1 = row.FindControl("xdisfixed") as TextBox;
                            TextBox xremarks1 = row.FindControl("xremarks") as TextBox;
                            // LinkButton btnRemove = row.FindControl("btnRemove") as LinkButton;

                            if (dttemp.Rows[0]["xstatus"].ToString() == "Confirmed")
                            {
                                xstdid1.Enabled = false;
                                xname1.Enabled = false;
                                xclass1.Enabled = false;
                                xamtdue1.Enabled = false;
                                xdisfixed1.Enabled = false;
                                xremarks1.Enabled = false;
                                // btnRemove.Visible = false;
                            }
                            else
                            {
                                xstdid1.Enabled = true;
                                //xname1.Enabled = true;
                                //xclass1.Enabled = true;
                                xamtdue1.Enabled = true;
                                xdisfixed1.Enabled = true;
                                xremarks1.Enabled = true;
                                // btnRemove.Visible = true;
                            }

                            if (i < tempTable.Rows.Count)
                            {
                                //xstdid1.Enabled = false;
                                xstdid1.Text = tempTable.Rows[i]["xstdid"].ToString();
                                xname1.Text = tempTable.Rows[i]["xname"].ToString();
                                xclass1.Text = tempTable.Rows[i]["xclass"].ToString();
                                xamtdue1.Text = tempTable.Rows[i]["xamount"].ToString();
                                xdisfixed1.Text = tempTable.Rows[i]["xdisfixed"].ToString();
                                xremarks1.Text = tempTable.Rows[i]["xremarks"].ToString();
                            }

                         

                            i = i + 1;
                        }
                    }

                    tempTable.Dispose();


                }
            }

            Button btnaddrow = GridView1.FooterRow.Cells[0].FindControl("btnAddRow") as Button;

            if (dttemp.Rows[0]["xstatus"].ToString() == "Confirmed")
            {
                xtfccode.Enabled = false;
                xsession.Enabled = false;
                xcdate.Enabled = false;
                xtdate.Enabled = false;
                xremarks.Enabled = false;
                btnaddrow.Enabled = false;

            }
            else
            {
                xtfccode.Enabled = true;
                xsession.Enabled = true;
                xcdate.Enabled = true;
                xtdate.Enabled = true;
                xremarks.Enabled = true;
                btnaddrow.Enabled = true;
            }

            fnButtonState();
            BindGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerText = "";
            //    if (ViewState["xrow"] != null)
            //    {
            //        if (txtconformmessageValue.Value == "Yes")
            //        {
            //            btnSave_Click(sender, e);

            //            string xstatus;

            //            using (TransactionScope tran = new TransactionScope())
            //            {
            //                using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //                {
            //                    conn.Open();
            //                    SqlCommand cmd = new SqlCommand();
            //                    cmd.Connection = conn;
            //                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //                    string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    DateTime xsubmitdt = DateTime.Now;
            //                    xstatus = "Approved";
            //                    string xflag10 = "";

            //                    string query = "";
            //                    //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            //                    //if (xstatus1 == "Undo1")
            //                    //{
            //                    //    xflag10 = "Undo1";
            //                    //    foreach (GridViewRow row in GridView1.Rows)
            //                    //    {
            //                    //        Label lblxline = row.FindControl("xline") as Label;
            //                    //        Label lxflag1 = row.FindControl("xflag1") as Label;
            //                    //        Label lxflag2 = row.FindControl("xflag2") as Label;
            //                    //        //string xflag1 = "";
            //                    //        //string xflag2 = "";

            //                    //        string xflag1 = lxflag1.Text;
            //                    //        string xflag2 = lxflag2.Text;

            //                    //        if (lxflag1.Text.ToString() == "Wrong")
            //                    //        {
            //                    //            xflag1 = "Corrected";
            //                    //        }

            //                    //        if (lxflag2.Text.ToString() == "Missing")
            //                    //        {
            //                    //            xflag2 = "Taken";
            //                    //        }

            //                    //        query =
            //                    //            "UPDATE amexamd SET xflag1=@xflag1,xflag2=@xflag2,xundoby=@xundoby,xundodt=@xundodt " +
            //                    //            "WHERE zid=@zid AND xrow=@xrow AND xline=@xline";

            //                    //        cmd.Parameters.Clear();

            //                    //        cmd.CommandText = query;
            //                    //        cmd.Parameters.AddWithValue("@zid", _zid);
            //                    //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lblxline.Text));
            //                    //        cmd.Parameters.AddWithValue("@xflag1", xflag1);
            //                    //        cmd.Parameters.AddWithValue("@xflag2", xflag2);
            //                    //        cmd.Parameters.AddWithValue("@xundoby", Convert.ToString(HttpContext.Current.Session["curuser"]));
            //                    //        cmd.Parameters.AddWithValue("@xundodt", DateTime.Now);
            //                    //        cmd.ExecuteNonQuery();
            //                    //    }
            //                    //}


            //                    query =
            //                        "UPDATE amdropout SET xstatus=@xstatus,xapprovedby=@xapprovedby,xapproveddt=@xapproveddt " +
            //                        "WHERE zid=@zid AND xrow=@xrow ";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
            //                    cmd.Parameters.AddWithValue("@xapprovedby", xsubmitedby);
            //                    cmd.Parameters.AddWithValue("@xapproveddt", xsubmitdt);
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
            //            ViewState["xstatus"] = "Approved";
            //            hxstatus.Value = "Approved";
            //            //dxstatus.Visible = true;
            //            //btnPrint.Visible = true;
            //            //dxstatus.Text = "Status : Submited";
            //            hiddenxstatus.Value = "Approved";
            //            fnButtonState();
            //            //BindGrid();
            //            fnFillGrid2();
            //        }
            //    }
            //    else
            //    {
            //        message.InnerHtml = "No record found for approved.";
            //        message.Style.Value = zglobal.warningmsg;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                message.InnerText = "";
                //fnCheckRow();

                //if (ViewState["xrow"] != null)
                //{
                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh",
                //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xstatus;


                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM amtfcdued WHERE zid=@zid AND xrow=@xrow";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.ExecuteNonQuery();

                                query = "DELETE FROM amtfcdueh WHERE zid=@zid AND xrow=@xrow";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.delsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        //btnSubmit.Enabled = false;
                        //btnSubmit1.Enabled = false;
                        //btnSave.Enabled = false;
                        //btnSave1.Enabled = false;
                        //btnDelete.Enabled = false;
                        //btnDelete1.Enabled = false;
                        //ViewState["xstatus"] = "Submited";
                        //hxstatus.Value = "Submited";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        //hiddenxstatus.Value = "Submited";
                        fnButtonState();
                        //BindGrid();
                        fnFillGrid2();
                    }
                }
                else
                {
                    message.InnerHtml = "No data found for delete.";
                    message.Style.Value = zglobal.warningmsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        //protected void fnEventValue(string evnt, object sender, EventArgs e)
        //{
        //    //if (xcttype.Text == "Test")
        //    //{
        //    //    xschdate.Enabled = false;
        //    //    schedule_d.Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    schedule_d.Visible = false;
        //    //}

        //    //if ((xcttype.Text == "Extra Test" || xcttype.Text == "Retest") && xreference.Text == "")
        //    //{
        //    //    ViewState["dtprectmarks"] = null;
        //    //}

        //    //if (evnt == "xcttype")
        //    //{
        //    //    if (xcttype.Text == "Test")
        //    //    {
        //    //        ViewState["xnumsch"] = null;
        //    //        xdate.Text = "";
        //    //        xnsdate.Value = "";
        //    //        //xdate.Enabled = false;
        //    //        xschdate.Text = "";
        //    //        //xschdate.Enabled = false;
        //    //        //schedule_d.Visible = true;
        //    //        fnGetScheduleDate("evnval");
        //    //        if (ViewState["xnumsch"] != null)
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 1, Convert.ToInt32(ViewState["xnumsch"]));
        //    //        }
        //    //        else
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 2, 1);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        if (xcttype.Text != "")
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 1, 15);
        //    //        }
        //    //        else
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 2, 1);
        //    //        }
        //    //        xdate.Text = "";
        //    //        xnsdate.Value = "";
        //    //        // xdate.Enabled = true;
        //    //        // schedule_d.Visible = false;

        //    //    }

        //    //    if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test")
        //    //    {
        //    //        retestfor.Visible = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        retestfor.Visible = false;
        //    //    }

        //        ////xreason_d.Visible = false;
        //        //ViewState["xdate1"] = null;
        //        //xnsdate.Value = "";
        //        //xreference.Text = "";
        //        //xreason.Text = "";
        //    }
        //    else if (evnt == "xctno")
        //    {
        //        if (xcttype.Text == "Test")
        //        {
        //            if (xctno.Text != "")
        //            {
        //                fnGetDate(sender, e);
        //                //xdate.Enabled = true;

        //                if (xdate.Text == "")
        //                {
        //                    ViewState["xdate1"] = null;
        //                }
        //                else
        //                {
        //                    ViewState["xdate1"] = xdate.Text.ToString().Trim();
        //                }

        //            }
        //            else
        //            {
        //                xdate.Text = "";
        //                xnsdate.Value = "";
        //                xschdate.Text = "";
        //                //xdate.Enabled = false;
        //                ViewState["xdate1"] = null;
        //            }
        //        }
        //        else
        //        {
        //            xdate.Text = "";
        //            xnsdate.Value = "";
        //            ViewState["xdate1"] = null;
        //            xschdate.Text = "";
        //            //schedule_d.Visible = false;

        //        }

        //        //xreason_d.Visible = false;
        //        xreason.Text = "";
        //    }
        //    else if (evnt == "xdate")
        //    {
        //        xreason.Text = "";
        //        if (xcttype.Text == "Test")
        //        {
        //            if (xctno.Text != "")
        //            {

        //                if (ViewState["xdate1"] != null)
        //                {
        //                    DateTime xnsdate1 = xnsdate.Value != ""
        //                        ? DateTime.ParseExact(xnsdate.Value.ToString(), "dd/MM/yyyy",
        //                            CultureInfo.InvariantCulture)
        //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //                    DateTime xdate1 = xdate.Text.Trim() != string.Empty
        //                        ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
        //                            CultureInfo.InvariantCulture)
        //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


        //                    DateTime xpsdate = ViewState["xdate1"] != null
        //                        ? DateTime.ParseExact(Convert.ToString(ViewState["xdate1"]), "dd/MM/yyyy",
        //                            CultureInfo.InvariantCulture)
        //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


        //                    if (xdate1.Date >= xnsdate1.Date || xdate1.Date < xpsdate.Date)
        //                    {
        //                        xdate.Text = Convert.ToString(ViewState["xdate1"]);
        //                        message.InnerHtml = "Cann't exceed next schedule date. Select a date between '" + xpsdate.ToString("dd/MM/yyyy") + "' and '" + xnsdate1.ToString("dd/MM/yyyy") + "'";
        //                        //return;
        //                        message.Style.Value = zglobal.warningmsg;
        //                        ViewState["xreturn"] = 1;
        //                    }

        //                    //if (Convert.ToString(ViewState["xdate1"]) != xdate.Text.ToString().Trim())
        //                    //{
        //                    //    xreason_d.Visible = true;
        //                    //}
        //                    //else
        //                    //{
        //                    //    xreason_d.Visible = false;
        //                    //    xreason.Text = "";
        //                    //}
        //                }
        //            }
        //            else
        //            {
        //                //xreason_d.Visible = false;
        //                xreason.Text = "";
        //                ViewState["xdate1"] = null;
        //                xnsdate.Value = "";
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
        //}

        protected void xcttype_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    //fnEventValue("xcttype", sender, e);

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

            //    //fnEventValue("xctno", sender, e);

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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // message.InnerHtml = "";
                ////    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                ////    //ViewState["dtprectmarks"] = null;



                //    fnCheckRow();


                ////    if (ViewState["xrow"] != null)
                ////    {
                ////        string xmarks1 = zglobal.fnGetValue("xmarks", "amexamh",
                ////            "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                ////        xmarks.Text = xmarks1;

                ////        string xdate1 = zglobal.fnGetValue("xdate", "amexamh",
                ////            "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                ////        xdate.Text = Convert.ToDateTime(xdate1).ToString("dd/MM/yyyy");
                ////    }
                ////    else
                ////    {


                ////        //if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test")
                ////        //{
                ////        //    xmarks.Text = "";
                ////        //}
                ////    }

                ////    if (ViewState["xrow"] == null )
                ////    {
                ////        //using (SqlConnection conn = new SqlConnection(zglobal.constring))
                ////        //{
                ////        //    using (DataSet dts = new DataSet())
                ////        //    {

                ////        //        string xsession1 = xsession.Text.Trim().ToString();
                ////        //        string xterm1 = xterm.Text.Trim().ToString();
                ////        //        string xclass1 = xclass.Text.Trim().ToString();
                ////        //        string xgroup1 = xgroup.Text.Trim().ToString();
                ////        //        string xsection1 = xsection.Text.Trim().ToString();
                ////        //        string xsubject1 = xsubject.Text.Trim().ToString();
                ////        //        string xpaper1 = xpaper.Text.Trim().ToString();
                ////        //        //DateTime xdate1 = xdate.Text.Trim() != string.Empty
                ////        //        //    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                ////        //        //        CultureInfo.InvariantCulture)
                ////        //        //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ////        //        //string query = "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher,xretestfor " +
                ////        //        //               "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                ////        //        //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' AND xdate=@xdate";
                ////        //        string query =
                ////        //            "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher " +
                ////        //            "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                ////        //            "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test'  AND xdate=@xdate";

                ////        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                ////        //        //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                ////        //        da.Fill(dts, "tempztcode");
                ////        //        DataTable dtexam = new DataTable();
                ////        //        dtexam = dts.Tables[0];


                ////        //        if (dtexam.Rows.Count > 0)
                ////        //        {
                ////        //            //xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
                ////        //            xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
                ////        //            xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
                ////        //            xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
                ////        //            _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
                ////        //            _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();


                ////        //        }
                ////        //        else
                ////        //        {
                ////        //            if (ViewState["xdate1"] == null)
                ////        //            {
                ////        //                //xtopic.Value = "";
                ////        //                xdetails.Value = "";
                ////        //                //xsteacher.Text = "-";
                ////        //                //xcteacher.Text = "-";
                ////        //                xsteacher.Text = "";
                ////        //                xcteacher.Text = "";
                ////        //                dxstatus.Text = "-";
                ////        //                _classteacher.Value = "";
                ////        //                _subteacher.Value = "";
                ////        //            }

                ////        //        }



                ////        //    }
                ////        //}
                ////    }
                ////    else
                ////    {
                ////        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                ////        {
                ////            using (DataSet dts = new DataSet())
                ////            {

                ////                string query =
                ////                    "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xsteacher) as xsteacher1, xcteacher,xsteacher,xrefcttype,xrefctno,xreason,xdate,xschdate " +
                ////                    "FROM amexamh " +
                ////                    "WHERE zid=@zid AND xrow=@xrow";

                ////                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                ////                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////                da.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                ////                da.Fill(dts, "tempztcode");
                ////                DataTable dtexam = new DataTable();
                ////                dtexam = dts.Tables[0];


                ////                if (dtexam.Rows.Count > 0)
                ////                {
                ////                    //xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
                ////                    xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
                ////                    xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
                ////                    xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
                ////                    _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
                ////                    _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();
                ////                    //xdate.Text = Convert.ToDateTime(dtexam.Rows[0]["xdate"]).ToString("dd/MM/yyyy");


                ////                    //if (xreference.Items.Contains(new ListItem(dtexam.Rows[0]["xretestfor"].ToString())))
                ////                    //{
                ////                    //    xreference.Text = dtexam.Rows[0]["xretestfor"].ToString();
                ////                    //}

                ////                    //string xref = dtexam.Rows[0]["xrefcttype"].ToString() + "|" +
                ////                    //              dtexam.Rows[0]["xrefctno"].ToString();

                ////                    //if (dtexam.Rows[0]["xrefcttype"].ToString() != "" &&
                ////                    //    dtexam.Rows[0]["xrefcttype"].ToString() != "")
                ////                    //{
                ////                    //    //xreference.SelectedValue = xref;
                ////                    //}
                ////                    // xreason.Text = dtexam.Rows[0]["xreason"].ToString();

                ////                    //if (dtexam.Rows[0]["xdate"].ToString() != dtexam.Rows[0]["xschdate"].ToString() && xcttype.Text=="Test")
                ////                    //{
                ////                    //    xreason_d.Visible = true;
                ////                    //   // ViewState["xdate1"] = dtexam.Rows[0]["xdate"];
                ////                    //}
                ////                    //else
                ////                    //{
                ////                    //    xreason_d.Visible = false;
                ////                    //   // ViewState["xdate1"] = null;
                ////                    //}
                ////                }
                ////                else
                ////                {
                ////                    //if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test")
                ////                    //{
                ////                    //    xtopic.Value = "";
                ////                    //}

                ////                    xdetails.Value = "";
                ////                    //xsteacher.Text = "-";
                ////                    //xcteacher.Text = "-";
                ////                    xsteacher.Text = "";
                ////                    xcteacher.Text = "";
                ////                    dxstatus.Text = "-";
                ////                    _classteacher.Value = "";
                ////                    _subteacher.Value = "";
                ////                }



                ////            }
                ////        }



                ////    }


                ////    //if (xcttype.Text == "Extra Test")
                ////    //{
                ////    //    if (xreference.SelectedItem.Text != "")
                ////    //    {
                ////    //        string[] sch = xreference.SelectedValue.Split('|');
                ////    //        string xrefcttype1 = sch[0];
                ////    //        string xrefctno1 = sch[1];

                ////    //        //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                ////    //        using (SqlConnection con = new SqlConnection(zglobal.constring))
                ////    //        {
                ////    //            using (DataSet dts = new DataSet())
                ////    //            {
                ////    //                con.Open();
                ////    //                string query;


                ////    //                query =
                ////    //                    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";


                ////    //                SqlDataAdapter da = new SqlDataAdapter(query, con);

                ////    //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xcttype", xrefcttype1);
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xctno", xrefctno1);
                ////    //                //DateTime xdate1 = xdate.Text.Trim() != string.Empty
                ////    //                //    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                ////    //                //        CultureInfo.InvariantCulture)
                ////    //                //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ////    //                //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


                ////    //                DataTable tempTable10 = new DataTable();
                ////    //                da.Fill(dts, "tempTable");
                ////    //                tempTable10 = dts.Tables["tempTable"];

                ////    //                if (tempTable10.Rows.Count > 0)
                ////    //                {
                ////    //                    query = "SELECT * FROM amexamd WHERE zid=@zid AND xrow=@xrow";


                ////    //                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                ////    //                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////    //                    da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable10.Rows[0]["xrow"]));

                ////    //                    dts.Reset();
                ////    //                    da1.Fill(dts, "tempztcode");
                ////    //                    DataTable dtexam1 = new DataTable();
                ////    //                    dtexam1 = dts.Tables[0];
                ////    //                    ViewState["dtprectmarks"] = dtexam1;
                ////    //                    dtprectmarks = dtexam1;
                ////    //                }
                ////    //                else
                ////    //                {
                ////    //                    ViewState["dtprectmarks"] = null;
                ////    //                    dtprectmarks = null;
                ////    //                }



                ////    //            }
                ////    //        }
                ////    //    }
                ////    //}


                //    BindGrid();
                ////    fnFillGrid2();
                /// 
                /// 

                //xsession.Text = "";
                //xstdid.Text = "";

                //ViewState["xrow"] = null;

                //fnButtonState();

                Response.Redirect(Request.RawUrl);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnGetDate(object sender, EventArgs e)
        {
            try
            {
                //if (xctno.Text != "" && xctno.Text != string.Empty && xctno.Text != "[Select]")
                //{
                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {
                //        using (DataSet dts = new DataSet())
                //        {
                //            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //            string xsession1 = xsession.Text.Trim().ToString();
                //            string xterm1 = xterm.Text.Trim().ToString();
                //            string xclass1 = xclass.Text.Trim().ToString();
                //            string xgroup1 = xgroup.Text.Trim().ToString();
                //            string xsection1 = xsection.Text.Trim().ToString();
                //            string xsubject1 = xsubject.Text.Trim().ToString();
                //            string xpaper1 = xpaper.Text.Trim().ToString();

                //            //string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                //            //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' ";

                //            string query =
                //                "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                //                "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' ORDER BY xdate ";

                //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                //            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
                //            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                //            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                //            da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                //            da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                //            da.Fill(dts, "tempztcode");
                //            DataTable dtexam = new DataTable();
                //            dtexam = dts.Tables[0];

                //            if (dtexam.Rows.Count > 0)
                //            {
                //                int count = 1;
                //                foreach (DataRow row in dtexam.Rows)
                //                {
                //                    if (row["xdate"].Equals(DBNull.Value) == false)
                //                    {
                //                        if (count == Int32.Parse(xctno.Text.Trim().ToString()))
                //                        {
                //                            xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
                //                            xschdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
                //                            if (count < dtexam.Rows.Count)
                //                            {
                //                                xnsdate.Value =
                //                                    Convert.ToDateTime(dtexam.Rows[count]["xdate"])
                //                                        .ToString("dd/MM/yyyy");
                //                            }
                //                            else
                //                            {
                //                                xnsdate.Value = "";
                //                            }
                //                            break;
                //                        }
                //                        else
                //                        {
                //                            xdate.Text = "";
                //                            xnsdate.Value = "";
                //                            xschdate.Text = "";
                //                        }

                //                        count = count + 1;
                //                    }
                //                }

                //                //for (int i = 1; i <= dtexam.Rows.Count; i++)
                //                //{
                //                //    if (dtexam.Rows[i-1]["xdate"].Equals(DBNull.Value) == false)
                //                //    {
                //                //        if (i == Int32.Parse(xctno.Text.Trim().ToString()))
                //                //        {
                //                //            xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
                //                //            if (count < dtexam.Rows.Count)
                //                //            {
                //                //                xnsdate.Value =
                //                //                    Convert.ToDateTime(dtexam.Rows[count + 1]["xdate"])
                //                //                        .ToString("dd/MM/yyyy");
                //                //            }
                //                //            else
                //                //            {
                //                //                xnsdate.Value = "";
                //                //            }
                //                //            break;
                //                //        }
                //                //        else
                //                //        {
                //                //            xdate.Text = "";
                //                //            xnsdate.Value = "";
                //                //        }
                //                //    }
                //                //}
                //            }


                //        }
                //    }
                //}
                //else
                //{
                //    xdate.Text = "";
                //    xschdate.Text = "";
                //}

                //btnRefresh_Click(null, null);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void xreference_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    //string xrefcttype1 = "";
            //    //string xrefctno1 = "";
            //    //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    //if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test")
            //    //{
            //    //    if (xreference.Text != "")
            //    //    {
            //    //        string[] sch = xreference.SelectedValue.Split('|');
            //    //        xrefcttype1 = sch[0];
            //    //        xrefctno1 = sch[1];

            //    //        if (xcttype.Text == xrefcttype1 && xctno.Text == xrefctno1)
            //    //        {
            //    //            message.InnerText = "Cann't reference same exam.";
            //    //            message.Style.Value = zglobal.warningmsg;
            //    //            xreference.Text = "";
            //    //            return;
            //    //        }
            //    //    }
            //    //}

            //    //string xref = xreference.SelectedValue;



            //    //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //    //{
            //    //    if (xreference.Text != "")
            //    //    {
            //    //        string[] sch = xreference.SelectedValue.Split('|');
            //    //        xrefcttype1 = sch[0];
            //    //        xrefctno1 = sch[1];

            //    //        //message.InnerText = xrefcttype1 + "-" + xrefctno1;
            //    //        //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    //        using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    //        {
            //    //            using (DataSet dts = new DataSet())
            //    //            {
            //    //                con.Open();
            //    //                string query;


            //    //                query =
            //    //                    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";


            //    //                SqlDataAdapter da = new SqlDataAdapter(query, con);

            //    //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xcttype", xrefcttype1);
            //    //                da.SelectCommand.Parameters.AddWithValue("@xctno", xrefctno1);
            //    //                //DateTime xdate1 = xdate.Text.Trim() != string.Empty
            //    //                //    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //    //                //        CultureInfo.InvariantCulture)
            //    //                //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    //                //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


            //    //                DataTable tempTable10 = new DataTable();
            //    //                da.Fill(dts, "tempTable");
            //    //                tempTable10 = dts.Tables["tempTable"];

            //    //                if (tempTable10.Rows.Count > 0)
            //    //                {
            //    //                    query = "SELECT * FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamh.zid=@zid AND amexamh.xrow=@xrow";


            //    //                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //    //                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //                    da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable10.Rows[0]["xrow"]));

            //    //                    dts.Reset();
            //    //                    da1.Fill(dts, "tempztcode");
            //    //                    DataTable dtexam1 = new DataTable();
            //    //                    dtexam1 = dts.Tables[0];
            //    //                    ViewState["dtprectmarks"] = dtexam1;
            //    //                    dtprectmarks = dtexam1;

            //    //                    xmarks.Text = dtexam1.Rows[0]["xmarks"].ToString();
            //    //                    xtopic.Value = dtexam1.Rows[0]["xtopic"].ToString();
            //    //                    //foreach (DataRow row in dtprectmarks.Rows)
            //    //                    //{
            //    //                    //    message.InnerText = message.InnerText + " " + row["xgetmark"].ToString();
            //    //                    //}
            //    //                }
            //    //                else
            //    //                {
            //    //                    ViewState["dtprectmarks"] = null;
            //    //                    dtprectmarks = null;
            //    //                }



            //    //            }
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        ViewState["dtprectmarks"] = null;
            //    //        dtprectmarks = null;
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    ViewState["dtprectmarks"] = null;
            //    //    dtprectmarks = null;
            //    //}

            //    ////BindGrid();

            //    //btnRefresh_Click(sender, e);

            //    //xreference.SelectedValue = xref;

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect(Request.RawUrl);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                message.InnerText = "";
                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {
                        btnSave_Click(sender, e);

                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                string xconfirmedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xconfirmeddt = DateTime.Now;
                                xstatus = "Confirmed";
                                string xflag10 = "";

                                string query = "";
                                //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                                //if (xstatus1 == "Undo1")
                                //{
                                //    xflag10 = "Undo1";
                                //    foreach (GridViewRow row in GridView1.Rows)
                                //    {
                                //        Label lblxline = row.FindControl("xline") as Label;
                                //        Label lxflag1 = row.FindControl("xflag1") as Label;
                                //        Label lxflag2 = row.FindControl("xflag2") as Label;
                                //        //string xflag1 = "";
                                //        //string xflag2 = "";

                                //        string xflag1 = lxflag1.Text;
                                //        string xflag2 = lxflag2.Text;

                                //        if (lxflag1.Text.ToString() == "Wrong")
                                //        {
                                //            xflag1 = "Corrected";
                                //        }

                                //        if (lxflag2.Text.ToString() == "Missing")
                                //        {
                                //            xflag2 = "Taken";
                                //        }

                                //        query =
                                //            "UPDATE amexamd SET xflag1=@xflag1,xflag2=@xflag2,xundoby=@xundoby,xundodt=@xundodt " +
                                //            "WHERE zid=@zid AND xrow=@xrow AND xline=@xline";

                                //        cmd.Parameters.Clear();

                                //        cmd.CommandText = query;
                                //        cmd.Parameters.AddWithValue("@zid", _zid);
                                //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lblxline.Text));
                                //        cmd.Parameters.AddWithValue("@xflag1", xflag1);
                                //        cmd.Parameters.AddWithValue("@xflag2", xflag2);
                                //        cmd.Parameters.AddWithValue("@xundoby", Convert.ToString(HttpContext.Current.Session["curuser"]));
                                //        cmd.Parameters.AddWithValue("@xundodt", DateTime.Now);
                                //        cmd.ExecuteNonQuery();
                                //    }
                                //}


                                query =
                                    "UPDATE amtfcdueh SET xstatus=@xstatus,xconfirmedby=@xconfirmedby,xconfirmeddt=@xconfirmeddt " +
                                    "WHERE zid=@zid AND xrow=@xrow ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.Parameters.AddWithValue("@xconfirmedby", xconfirmedby);
                                cmd.Parameters.AddWithValue("@xconfirmeddt", xconfirmeddt);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.confsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        //btnSubmit.Enabled = false;
                        //btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        //btnDelete.Enabled = false;
                        //btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "Confirmed";
                        hxstatus.Value = "Confirmed";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        hiddenxstatus.Value = "Confirmed";
                        fnButtonState();
                        //BindGrid();
                        fnFillGrid2();
                    }
                }
                else
                {
                    message.InnerHtml = "No record found for approved.";
                    message.Style.Value = zglobal.warningmsg;
                }


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void xtfccode_OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

                
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    ViewState["xrow"] = null;
            //    xrow1.Text = "";
            //    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
            //    //xcdate.Text = DateTime.Now.ToString("MMM-yyyy");
            //    //xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //    //xremarks.Text = "";

            //    //BindGrid();

            //    SetInitialRow();

            //    string istfccodefound = zglobal.fnGetValue("xcode", "mscodesam",
            //          "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and xcode='" + xtfccode.Text.ToString().Trim() + "'");

            //    if (istfccodefound == "")
            //    {
            //        message.InnerHtml = "Wrong TFC Code Selected.";
            //        message.Style.Value = zglobal.warningmsg;
                    
            //    }

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }
    }
}