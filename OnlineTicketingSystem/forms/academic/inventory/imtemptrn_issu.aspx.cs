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
    public partial class imtemptrn_issu : System.Web.UI.Page
    {
        private int globalerr;

        private void fnButtonState()
        {
            if (ViewState["ximtmptrn"] == null)
            {
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete1.Enabled = true;
                btnConfirm.Enabled = false;
                btnConfirm1.Enabled = false;
                btnUndo.Enabled = false;
                btnUndo1.Enabled = false;
                //dxstatus.Visible = false;
                //dxstatus.Text = "-";
                //xsessionpro.Text = "";
                //xclasspro.Text = "";
                //xgrouppro.Text = "";
                //xsession.Enabled = true;
                //xstdid.Enabled = true;
                hxstatus.Value = "";
                //xstatus.InnerHtml = "";
                //zemail.InnerHtml = "";
                //xapprovedby.InnerHtml = "";
                hiddenxrow.Value = "";
            }
            else
            {
                //xsession.Enabled = false;
                //xstdid.Enabled = false;

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xstatus1 = zglobal.fnGetValue("xstatustrn", "imtemptrn",
                               "zid=" + _zid + " AND ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"]) + "'");
                hxstatus.Value = xstatus1;
                xstatustrn.InnerHtml = xstatus1;
                //xstatus.InnerHtml = xstatus1;
                zemail.InnerHtml = zglobal.fnGetValue("coalesce(zemail,'') as zemail", "imtemptrn",
                               "zid=" + _zid + " AND ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"]) + "'");

                xemail.InnerHtml = zglobal.fnGetValue("coalesce(xemail,'') as xemail", "imtemptrn",
                               "zid=" + _zid + " AND ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"]) + "'");

                xconfirmby.InnerHtml = zglobal.fnGetValue("coalesce(xconfirmby,'') as xconfirmby", "imtemptrn",
                               "zid=" + _zid + " AND ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"]) + "'");

                //xapprovedby.InnerHtml = zglobal.fnGetValue("coalesce(xapprovedby,'') as xapprovedby", "amdropout",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));

                //xsessionpro.Text = zglobal.fnGetValue("xsessionpro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));

                //xclasspro.Text = zglobal.fnGetValue("xclasspro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));

                //xgrouppro.Text = zglobal.fnGetValue("xgrouppro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));
                //dxstatus.Visible = true;

                btnUndo.Enabled = true;
                btnUndo1.Enabled = true;

                if (xstatus1 == "New" || xstatus1 == "Undo" || xstatus1 == "Open")
                {
                    btnSubmit.Enabled = true;
                    btnSubmit1.Enabled = true;
                    btnConfirm.Enabled = true;
                    btnConfirm1.Enabled = true;
                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDelete1.Enabled = true;
                    //dxstatus.Text = xstatus1;
                    hxstatus.Value = xstatus1;
                    //dxstatus.Style.Value = zglobal.am_new;

                    //xsessionpro.Enabled = true;
                    //xclasspro.Enabled = true;
                    //xgrouppro.Enabled = true;

                    //xsession.Enabled = false;
                    //xstdid.Enabled = false;

                }
                else
                {
                    btnSubmit.Enabled = false;
                    btnSubmit1.Enabled = false;
                    btnConfirm.Enabled = false;
                    btnConfirm1.Enabled = false;
                    btnSave.Enabled = false;
                    btnSave1.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDelete1.Enabled = false;
                    //dxstatus.Text = xstatus1;
                    hxstatus.Value = xstatus1;
                    //dxstatus.Style.Value = zglobal.am_submited;

                    //xsessionpro.Enabled = false;
                    //xclasspro.Enabled = false;
                    //xgrouppro.Enabled = false;
                }

                //if (xstatus1 == "New" || xstatus1 == "Undo")
                //{
                //    dxstatus.Style.Value = zglobal.am_new;
                //}
                //else
                //{
                //    dxstatus.Style.Value = zglobal.am_submited;
                //}
                if (xstatus1 == "Undo1")
                {
                    //int t = 0;
                    //foreach (GridViewRow row in GridView1.Rows)
                    //{
                    //    Label lblxflag1 = row.FindControl("xflag1") as Label;
                    //    Label lblxflag2 = row.FindControl("xflag2") as Label;

                    //    if (lblxflag1.Text == "Wrong" || lblxflag2.Text == "Missing")
                    //    {
                    //        t = 1;
                    //        break;
                    //    }
                    //}

                    //if (t == 1)
                    //{
                    //    btnSave.Enabled = true;
                    //    btnSave1.Enabled = true;
                    //    btnDelete.Enabled = false;
                    //    btnDelete1.Enabled = false;
                    //    btnSubmit.Enabled = true;
                    //    btnSubmit1.Enabled = true;
                    //}
                    //else
                    //{
                    //    btnSave.Enabled = false;
                    //    btnSave1.Enabled = false;
                    //    btnDelete.Enabled = false;
                    //    btnDelete1.Enabled = false;
                    //    btnSubmit.Enabled = false;
                    //    btnSubmit1.Enabled = false;
                    //}

                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    //btnDelete.Enabled = false;
                    //btnDelete1.Enabled = false;
                    btnDelete.Enabled = true;
                    btnDelete1.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnSubmit1.Enabled = true;

                    //xsessionpro.Enabled = true;
                    //xclasspro.Enabled = true;
                    //xgrouppro.Enabled = true;
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //zglobal.fnGetComboDataCD("Session", xsession);
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
                   // xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //        //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //        //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //        //zsetvalue.SetDWNumItem(xctno, 2, 1);

                    ViewState["ximtmptrn"] = null;
                    hiddenxrow.Value = "";
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";

                    ViewState["ximtmptrn"] = null;

                    ViewState["xtrnim"] = "IS--";
                    xtrnim.Text = ViewState["xtrnim"].ToString();

                    ViewState["xmode"] = "General Issue";
                    ViewState["xtypetrn"] = "Im Transaction";
                    ViewState["xtyperel"] = "Inventory Transaction:-";

                    ViewState["xaction"] = zglobal.fnGetValue("xaction", "mstrn",
                    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtypetrn='" + ViewState["xtypetrn"].ToString() + "' " +
                    "and xtrn='" + ViewState["xtrnim"].ToString() + "'");

                    fnButtonState();

                    ViewState["xrel"] = zglobal.fnGetValue("xrel", "mstrnp",
                      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtypetrn='" + ViewState["xtypetrn"].ToString() + "' " +
                      "and xtrn='" + ViewState["xtrnim"].ToString() + "' and xtyperel='" + ViewState["xtyperel"].ToString() + "'");

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
                    //xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    _gridrow.Text = zglobal._grid_row_value;
                    _gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();
                    SetInitialRow();
                    ViewState["xtype"] = "Headwise";

                    xstatustrn.InnerHtml = "";
                    zemail.InnerHtml = "";
                    xemail.InnerHtml = "";
                    xconfirmby.InnerHtml = "";
                    //btnConfirm.Visible = false;
                    //btnConfirm1.Visible = false;

                    //xtyperec.Items.Add("");
                    //xtyperec.Items.Add("0-Opening Balance");
                    //xtyperec.Items.Add("1-Cash Purchase");
                    //xtyperec.Items.Add("2-Credit Purchase");
                    //xtyperec.Items.Add("3-Receive");
                    //xtyperec.Text = "";

                    xdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    zglobal.fnGetComboDataCD("Warehouse", xfwh);
                    //zglobal.fnGetComboDataCD("Item Class", xglevel2);
                    zglobal.fnGetComboDataCD("Class", xglevel2);

                    includeset.Visible = false;

                    string ximtmptrn1 = Request.QueryString["ximtmptrn"] != null ? Request.QueryString["ximtmptrn"].ToString() : "";

                    if (ximtmptrn1 != "")
                    {
                        MasterPage m = this.Page.Master;
                        zglobal.fnDisableMasterPageContent(m);
                        fnFillControl(ximtmptrn1);
                        UpdatePanel5.Visible = false;
                        UpdatePanel2.Visible = false;
                        btnRefresh.Visible = false;
                        btnRefresh1.Visible = false;
                    }
                    else
                    {
                        UpdatePanel5.Visible = true;
                        UpdatePanel2.Visible = true;
                        btnRefresh.Visible = true;
                        btnRefresh1.Visible = true;
                    }

                }

                //xorg.Text = zglobal.fnGetValue("xorg", "mssup",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xsup='" + xsup.Text.ToString().Trim() + "'");

                xnameemp.Text = zglobal.fnGetValue("xname", "hrmst",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xemp='" + xemp.Text.ToString().Trim() + "'");

                //xnamestd.Text = zglobal.fnGetValue("xname", "amadmis",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" + xstdid.Text.ToString().Trim() + "'");

                xnamestd.Text = zglobal.fnGetValue("xname + ' - '  + xclass + '(' + left(xsection,1) +')'", "amstudentvwextacc",
             "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
             xstdid.Text.ToString().Trim() + "' and xsession='" + zglobal.fnDefaults("xsessionacc", "Student") + "'  ");

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

         //        xdescdet.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
         //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and " +
         //"xcode='" + xtfccode.Text.ToString().Trim() + "'");
         //        xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
         //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtype='TFC Code' and " +
         //"xcode='" + xtfccode.Text.ToString().Trim() + "'");

                //BindGrid();
                fnRegisterPostBack();

                xglevel2_OnTextChanged(null, null);
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




            //         if (ViewState["ximtmptrn"] != null)
            //         {
            //             using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //             {
            //                 using (DataSet dts1 = new DataSet())
            //                 {
            //                     string query = "SELECT xsrow,coalesce(xpromoted,0) as xpromoted FROM ampromotiond WHERE zid=@zid AND xrow=@xrow";
            //                     SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
            //                     da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
            //                     da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["ximtmptrn"]));
            //                     da1.Fill(dts1, "tblamadmisd");
            //                     //tblamadmisd = new DataTable();
            //                     amexamd = dts1.Tables[0];
            //                 }
            //             }

            //             ViewState["ampromotiond"] = amexamd;
            //             string xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
            //                    "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));
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

            //            //if (ViewState["ximtmptrn"] != null)
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
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));
            dt.Columns.Add(new DataColumn("Column8", typeof(string)));
            dt.Columns.Add(new DataColumn("Column9", typeof(string)));

            for (int i = 0; i < 10; i++)
            {
                dr = dt.NewRow();
                //dr["RowNumber"] = 1;
                //dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = "0.00";
                dr["Column5"] = "0.00";
                dr["Column6"] = "Pcs";
                dr["Column7"] = "0.00";
                dr["Column8"] = string.Empty;
                dr["Column9"] = "0.00";
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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xitem");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xdesc");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xstock");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xqty");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xunit");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("xrate");
                        TextBox box7 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("xremarks");
                        TextBox box8 = (TextBox)GridView1.Rows[i].Cells[9].FindControl("xcf");
                    
                        dtCurrentTable.Rows[i]["Column2"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column3"] = box2.Text;
                        dtCurrentTable.Rows[i]["Column4"] = box3.Text;
                        dtCurrentTable.Rows[i]["Column5"] = box4.Text;
                        dtCurrentTable.Rows[i]["Column6"] = box5.Text;
                        dtCurrentTable.Rows[i]["Column7"] = box6.Text;
                        dtCurrentTable.Rows[i]["Column8"] = box7.Text;
                        dtCurrentTable.Rows[i]["Column9"] = box8.Text;

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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xitem");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xdesc");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xstock");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xqty");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xunit");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("xrate");
                        TextBox box7 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("xremarks");
                        TextBox box8 = (TextBox)GridView1.Rows[i].Cells[8].FindControl("xcf");


                        //DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                        //DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("DropDownList2");

                        ////Fill the DropDownList with Data   
                        //FillDropDownList(ddl1);
                        //FillDropDownList(ddl2);

                        //if (i < dt.Rows.Count - 1)
                        //{

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Column2"].ToString();
                            box2.Text = dt.Rows[i]["Column3"].ToString();
                            box3.Text = dt.Rows[i]["Column4"].ToString();
                            box4.Text = dt.Rows[i]["Column5"].ToString();
                            box5.Text = dt.Rows[i]["Column6"].ToString();
                            box6.Text = dt.Rows[i]["Column7"].ToString();
                            box7.Text = dt.Rows[i]["Column8"].ToString();
                            box8.Text = dt.Rows[i]["Column9"].ToString();

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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xitem");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xdesc");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xstock");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xqty");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xunit");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("xrate");
                        TextBox box7 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("xremarks");
                        TextBox box8 = (TextBox)GridView1.Rows[i].Cells[8].FindControl("xcf");

                        dt.Rows[i]["Column2"] = box1.Text;
                        dt.Rows[i]["Column3"] = box2.Text;
                        dt.Rows[i]["Column4"] = box3.Text;
                        dt.Rows[i]["Column5"] = box4.Text;
                        dt.Rows[i]["Column6"] = box5.Text;
                        dt.Rows[i]["Column7"] = box6.Text;
                        dt.Rows[i]["Column8"] = box7.Text;
                        dt.Rows[i]["Column9"] = box8.Text;

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //btnRefresh_Click(sender,e);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string ximtmptrn_1 = "";
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

                if (xdate.Text == "" || xdate.Text == string.Empty || xdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Date</li>";
                    isValid = false;
                }
                if ((xemp.Text == "" || xemp.Text == string.Empty || xemp.Text == "[Select]") && (xstdid.Text == "" || xstdid.Text == string.Empty || xstdid.Text == "[Select]"))
                {
                    rtnMessage = rtnMessage + "<li>'Teacher/Employee' or 'Student'</li>";
                    isValid = false;
                }
                if (xfwh.Text == "" || xfwh.Text == string.Empty || xfwh.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Warehouse</li>";
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
                    globalerr = 1;
                    return;
                }

                DateTime xdate111 = xdate.Text.ToString().Trim() != string.Empty
                              ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                  CultureInfo.InvariantCulture)
                              : DateTime.Now;
                if (xdate111 > DateTime.Now)
                {
                    message.InnerHtml = "Date Cannot be gatter than System Date.";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                if (xemp.Text != ""  && xstdid.Text != "" )
                {
                    message.InnerHtml = "Cann't issue item both 'Teacher/Employee' and 'Student'.";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                if (xemp.Text != "")
                {
                    string isempfound = zglobal.fnGetValue("xemp", "hrmst",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        "  and xemp='" + xemp.Text.ToString().Trim() + "'");

                    if (isempfound == "")
                    {
                        message.InnerHtml = "Wrong Employee Selected.";
                        message.Style.Value = zglobal.warningmsg;
                        globalerr = 1;
                        return;
                    }
                }

                if (xstdid.Text != "")
                {
                    //string isempfound = zglobal.fnGetValue("xstdid", "amadmis",
                    //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    //    "  and xstdid='" + xstdid.Text.ToString().Trim() + "'");
                    string isempfound = zglobal.fnGetValue("xstdid", "amstudentvwextacc",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xstdid='" +
                        xstdid.Text.ToString().Trim() + "' and xsession='" + zglobal.fnDefaults("xsessionacc", "Student") +
                        "'  "); //and zactiveacc=1

                    if (isempfound == "")
                    {
                        message.InnerHtml = "Wrong Student Selected.";
                        message.Style.Value = zglobal.warningmsg;
                        globalerr = 1;
                        return;
                    }
                }

                //Check and set Year/Period

                //DateTime xdate111 = xdate.Text.ToString().Trim() != string.Empty
                //               ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                //                   CultureInfo.InvariantCulture)
                //               : DateTime.Now;

                int offset;
                int per;
                int year1 = xdate111.Year;

                int tempper;
                int tempyear;

                offset = zglobal.fnGetValueInt("xinteger", "msstatus",
                    "zid=" + _zid + " and xtypestatus='GL Period Offset'");

                per = 12 + xdate111.Month - offset;

                if (per <= 12)
                {
                    tempper = per;
                    tempyear = year1 - 1;
                }
                else
                {
                    tempper = per - 12;
                    tempyear = year1;
                }

                string yrper = zglobal.fnGetValue("xnote", "msstatus",
                    "zid=" + _zid + " and xtypestatus='GL Year/Period'");
                if (yrper != "")
                {
                    string s = tempyear + "/" + tempper;
                    if (!yrper.Contains(s))
                    {
                        message.InnerHtml = "<span>Year and Period Must Match the Following Period:</span><br><span>" + yrper + "</span>";
                        message.Style.Value = zglobal.warningmsg;
                        globalerr = 1;
                        return;
                    }
                }
                else
                {
                    message.InnerText = "Post/Previous Month's Data Entry Not Allowed";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                //fnCheckRow();

                string xstatus2 = "";
                if (ViewState["ximtmptrn"] != null)
                {
                    xstatus2 = zglobal.fnGetValue("xstatustrn", "imtemptrn",
                          "zid=" + _zid + " AND ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"]) + "'");
                    if (xstatus2 != "New" && xstatus2 != "Undo" && xstatus2 != "Undo1" && xstatus2 != "" && xstatus2 != "Open" && xstatus2 != "1-Open")
                    {
                        message.InnerHtml = "Status : " + xstatus2 + ". Cann't change data.";
                        message.Style.Value = zglobal.warningmsg;
                        globalerr = 1;
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
                    TextBox txtTextBox1 = row.FindControl("xitem") as TextBox;
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
                    message.InnerText = "Duplicate item selected.";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                flag = 0;
                
                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtTextBox1 = row.FindControl("xitem") as TextBox;
                    if (txtTextBox1.Text != String.Empty)
                    {
                        if (zglobal.fnGetValue("xitem", "msitem",
                      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + "  and xitem='" + txtTextBox1.Text.ToString().Trim() + "'") == "")
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
                    message.InnerText = "Item not found.";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                //Stock Check ondate and overall

                flag = 0;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtTextBox1 = row.FindControl("xitem") as TextBox;
                    TextBox xqty321 = row.FindControl("xqty") as TextBox;
                    TextBox xdesc321 = row.FindControl("xdesc") as TextBox;
                    if (txtTextBox1.Text != String.Empty)
                    {
                        int year = int.Parse(DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Year.ToString());
                        int month = int.Parse(DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Month.ToString());
                        int day = int.Parse(DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Day.ToString());

                        DateTime date = new DateTime(year, month, day);

                        string xstkondate;
                        string xstk;

                        xstkondate = zglobal.fnGetValue("sum(xqty*xsign)", "imtrn",
                            "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                            "  and xitem='" + txtTextBox1.Text.ToString().Trim() + "' and xwh='"+ xfwh.Text.Trim().ToString() +"' and xdate<='"+ date +"'");

                        xstk = zglobal.fnGetValue("sum(xqty*xsign)", "imtrn",
                           "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                           "  and xitem='" + txtTextBox1.Text.ToString().Trim() + "' and xwh='" + xfwh.Text.Trim().ToString() + "'");

                        xstkondate = xstkondate == "" ? "0" : xstkondate;
                        xstk = xstk == "" ? "0" : xstk;


                        if (Convert.ToDecimal(xqty321.Text.Trim().ToString()) <= Convert.ToDecimal(xstkondate) && Convert.ToDecimal(xqty321.Text.Trim().ToString()) <= Convert.ToDecimal(xstk))
                        {
                            //txtTextBox1.Text = "";
                           
                            //val.Add(txtTextBox1.Text.Trim().ToString());
                        }
                        else
                        {
                            row.BackColor = zglobal.rowerr;
                            flag = 1;

                            if (Convert.ToDecimal(xstkondate) <= Convert.ToDecimal(xqty321.Text.Trim().ToString()))
                            {
                                message.InnerHtml = message.InnerHtml + "Item : " + xdesc321.Text.Trim().ToString() + ", Stock On Date '" + xdate.Text.Trim().ToString()
                                    + "' : " + Convert.ToDecimal(xstkondate).ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo()) + "<br/> ";
                            }
                        }
                    }

                }

                if (flag == 1)
                {
                    message.InnerHtml = message.InnerHtml + "<br/>Stock Not Available.";
                    //message.InnerText = Server.HtmlEncode(message.InnerText);
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
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
                //            ViewState["ximtmptrn"] = tempTable.Rows[0]["ximtmptrn"].ToString();
                //        }
                //        else
                //        {
                //            ViewState["ximtmptrn"] = null;
                //        }


                //    }
                //}

                ////Duplicate entry check
                //if (ViewState["ximtmptrn"] != null)
                //{
                //    message.InnerHtml = "Cann't insert duplicate record.";
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}



                //string[] date = new string[2];
                //date = xcdate.Text.Split('-');

                //int year = Int32.Parse(date[1]);
                //int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                //DateTime xdate1 = new DateTime(year, month, 1);

                string xtype1 = ViewState["xtype"].ToString();
                //string xsession1 = xsession.Text.Trim().ToString();
                string xclass1 = "";
                string xgroup1 = "";
               // DateTime xcdate1 = xdate1;
                DateTime xtdate1 = DateTime.Now;
                string xstatus1 = "New";
                //string xremarks1 = "";

                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xstdid1 = "";
                string xtfccode1 = "";

                string ximtmptrn1 = "";
                string xtrnim1 = "";
                string xref1 = "";
                DateTime xdate1 = DateTime.Now;
                string xsup1 = "";
                string xstatustrn1 = "";
                string xfwh1 = "";
                int xsign1 = -1;
                string xremarks1 = "";
                string xemp1 = "";
                int xyear1 = tempyear;
                int xper1 = tempper;


                using (TransactionScope tran = new TransactionScope())
                {
                    //if (GridView1.Rows.Count > 0)
                    //{
                    if (ViewState["ximtmptrn"] == null)
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
                            ximtmptrn_1 = "";

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
                              "INSERT INTO imtemptrn (ztime,zid,ximtmptrn,xtrnim,xref,xdate,xemp,xstdid,xstatustrn,xfwh,xsign,xremarks,zemail,xaction,xmode,xyear,xper) " +
                                    "VALUES(@ztime,@zid,@ximtmptrn,@xtrnim,@xref,@xdate,@xemp,@xstdid,@xstatustrn,@xfwh,@xsign,@xremarks,@zemail,@xaction,@xmode,@xyear,@xper )";

                            ximtmptrn_1 = zglobal.GetMaximumIDWithTRN(ViewState["xtrnim"].ToString(), "ximtmptrn", "imtemptrn");
                            ViewState["ximtmptrn"] = ximtmptrn_1;
                            hiddenxrow.Value = ximtmptrn_1;
                            xtrnim1 = ViewState["xtrnim"].ToString();
                            xref1 = xref.Text.Trim().ToString();
                            xdate1 = xdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.Now;
                            //xsup1 = xsup.Text.Trim().ToString();
                            xstatustrn1 = "Open";
                            xfwh1 = xfwh.Text.Trim().ToString();
                            xsign1 = -1;
                            xremarks1 = xremarks.Text.Trim().ToString();
                            xemp1 = xemp.Text.Trim().ToString();
                            xstdid1 = xstdid.Text.Trim().ToString();



                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@ximtmptrn", ximtmptrn_1);
                            cmd.Parameters.AddWithValue("@xtrnim", xtrnim1);
                            cmd.Parameters.AddWithValue("@xref", xref1);
                            cmd.Parameters.AddWithValue("@xdate", xdate1);
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.Parameters.AddWithValue("@xstdid", xstdid1);
                            cmd.Parameters.AddWithValue("@xstatustrn", xstatustrn1);
                            cmd.Parameters.AddWithValue("@xfwh", xfwh1);
                            cmd.Parameters.AddWithValue("@xsign", xsign1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                            cmd.Parameters.AddWithValue("@xaction", ViewState["xaction"].ToString());
                            cmd.Parameters.AddWithValue("@xmode", ViewState["xmode"].ToString());
                            cmd.Parameters.AddWithValue("@xyear", xyear1);
                            cmd.Parameters.AddWithValue("@xper", xper1);
                            cmd.ExecuteNonQuery();
                        }
                    }



                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        string query = "";
                        query = "DELETE FROM imtemptdt WHERE zid=@zid AND ximtmptrn=@ximtmptrn";
                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@ximtmptrn", ViewState["ximtmptrn"].ToString());
                        //if (xstatus1 != "Undo1" && xstatus1 != "Undo")
                        //if (xstatus1 != "Undo1")
                        //{
                        cmd.ExecuteNonQuery();
                        //}


                        if (ximtmptrn_1 == "")
                        {
                            xdate1 = xdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.Now;
                            //xsup1 = xsup.Text.Trim().ToString();
                            xfwh1 = xfwh.Text.Trim().ToString();
                            xref1 = xref.Text.Trim().ToString();
                            xremarks1 = xremarks.Text.Trim().ToString();
                            xemp1 = xemp.Text.Trim().ToString();
                            xstdid1 = xstdid.Text.Trim().ToString();

                            query = "UPDATE imtemptrn SET zutime=@zutime,xemail=@xemail, " +
                                   "xdate=@xdate, xemp=@xemp, xstdid=@xstdid, xfwh=@xfwh, xref=@xref, xremarks=@xremarks,xyear=@xyear,xper=@xper " +
                                   "WHERE zid=@zid AND ximtmptrn=@ximtmptrn ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@ximtmptrn", Convert.ToString(ViewState["ximtmptrn"]));
                            cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@xemail",
                                Convert.ToString(HttpContext.Current.Session["curuser"]));
                            cmd.Parameters.AddWithValue("@xdate", xdate1);
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.Parameters.AddWithValue("@xstdid", xstdid1);
                            cmd.Parameters.AddWithValue("@xfwh", xfwh1);
                            cmd.Parameters.AddWithValue("@xref", xref1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                            cmd.Parameters.AddWithValue("@xyear", xyear1);
                            cmd.Parameters.AddWithValue("@xper", xper1);
                            cmd.ExecuteNonQuery();


                        }






                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            TextBox xitem1234 = row.FindControl("xitem") as TextBox;

                            if (xitem1234.Text != string.Empty)
                            {
                                int xline = zglobal.GetMaximumIdInt("xline", "imtemptdt",
                                    " zid=" + _zid + " and ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"] + "'"), "line");
                                TextBox xitem12 = row.FindControl("xitem") as TextBox;
                                TextBox xqty12 = row.FindControl("xqty") as TextBox;
                                TextBox xunit12 = row.FindControl("xunit") as TextBox;
                                TextBox xcf12 = row.FindControl("xcf") as TextBox;
                                TextBox xrate12 = row.FindControl("xrate") as TextBox;
                                TextBox xremarks12 = row.FindControl("xremarks") as TextBox;

                                //string ximtrnnum1 = zglobal.GetMaximumIDWithTRN(ViewState["xrel"].ToString(), "ximtrnnum", "imtemptdt");
                                string ximtrnnum1 = "";


                                decimal xqty123;
                                if (xqty12.Text.Trim().ToString() == "" ||
                                    xqty12.Text.Trim().ToString() == String.Empty)
                                {
                                    xqty123 = 0;
                                }
                                else
                                {
                                    xqty123 = decimal.Parse(xqty12.Text.Trim().ToString());
                                }

                                decimal xrate123;
                                if (xrate12.Text.Trim().ToString() == "" ||
                                    xrate12.Text.Trim().ToString() == String.Empty)
                                {
                                    xrate123 = 0;
                                }
                                else
                                {
                                    xrate123 = decimal.Parse(xrate12.Text.Trim().ToString());
                                }

                                decimal xcf123;
                                if (xcf12.Text.Trim().ToString() == "" ||
                                    xcf12.Text.Trim().ToString() == String.Empty)
                                {
                                    xcf123 = 0;
                                }
                                else
                                {
                                    xcf123 = decimal.Parse(xcf12.Text.Trim().ToString());
                                }

                                query =
                                    "INSERT INTO imtemptdt (zid,ximtmptrn,xline,xitem,xqty,xunit,xrate,xcf,xremarks,ximtrnnum) " +
                                    "VALUES(@zid,@ximtmptrn,@xline,@xitem,@xqty,@xunit,@xrate,@xcf,@xremarks,@ximtrnnum) ";


                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@ximtmptrn", Convert.ToString(ViewState["ximtmptrn"]));
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.Parameters.AddWithValue("@xitem", xitem12.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xqty", xqty123);
                                cmd.Parameters.AddWithValue("@xunit", xunit12.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xrate", xrate123);
                                cmd.Parameters.AddWithValue("@xcf", xcf123);
                                cmd.Parameters.AddWithValue("@xremarks", xremarks12.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@ximtrnnum", ximtrnnum1);
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
                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;
                //ViewState["ximtmptrn"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";

                //BindGrid();

                ximtmptrn.Text = ViewState["ximtmptrn"].ToString();
                fnButtonState();
                fnFillGrid2();

                xstatustrn.InnerHtml = "Open";
                zemail.InnerHtml = zemail1;


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
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
                         "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " ximtmptrn,xdate,xfwh,xaction,xstatustrn " +
                         "FROM imtemptrn WHERE zid=@zid AND xmode=@xmode AND xstatustrn='Open' " +
                         "order by ximtmptrn desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xmode", ViewState["xmode"].ToString());



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
                       "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " ximtmptrn,xdate,xfwh,xaction,xstatustrn " +
                       "FROM imtemptrn WHERE zid=@zid AND xmode=@xmode AND xstatustrn='Confirmed' " +
                        "order by ximtmptrn desc";
                  

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xmode", ViewState["xmode"].ToString());



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
            //    ViewState["ximtmptrn"] = null;
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
                if (ximtmptrn.Text.Trim().ToString() != String.Empty)
                {
                    fnFillControl(ximtmptrn.Text.Trim().ToString());
                }
                else
                {
                    message.InnerHtml = "Enter transaction code.";
                    message.Style.Value = zglobal.am_warningmsg;
                    ximtmptrn.Focus();
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
            string ximtmptrn123 = xrow123;


            string str = "SELECT  xtrnim,ximtmptrn,xdate,xsup,xfwh,xremarks,xstatustrn as xstatus,xemp,xstdid " +
                         "FROM imtemptrn where zid=@zid  and ximtmptrn=@ximtmptrn ";




            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@ximtmptrn", ximtmptrn123);
            da.Fill(dts, "tempztcode");
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];

            if (dttemp.Rows.Count <= 0)
            {
                message.InnerHtml = "Wrong transaction code.";
                message.Style.Value = zglobal.am_warningmsg;

                ViewState["ximtmptrn"] = null;
                //xtrnim.Text = "";
                xdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //xsup.Text = "";
                //xorg.Text = "";
                xfwh.Text = "";
                xremarks.Text = "";
                xstatustrn.InnerHtml = "";
                zemail.InnerHtml = "";
                xemail.InnerHtml = "";
                xconfirmby.InnerHtml = "";
                xstdid.Text = "";
                xnamestd.Text = "";
                xemp.Text = "";
                xnameemp.Text = "";

                GridView1.DataSource = null;
                GridView1.DataBind();

                SetInitialRow();

                return;
            }

            ViewState["ximtmptrn"] = ximtmptrn123;
            hiddenxrow.Value = ViewState["ximtmptrn"].ToString();

            xtrnim.Text = dttemp.Rows[0]["xtrnim"].ToString();
            ximtmptrn.Text = dttemp.Rows[0]["ximtmptrn"].ToString();
            xdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
            //xsup.Text = dttemp.Rows[0]["xsup"].ToString();

            //xorg.Text = zglobal.fnGetValue("xorg", "mssup",
            //          "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xsup='" + xsup.Text.ToString().Trim() + "'");

            xfwh.Text = dttemp.Rows[0]["xfwh"].ToString();
            xremarks.Text = dttemp.Rows[0]["xremarks"].ToString();

            xemp.Text = dttemp.Rows[0]["xemp"].ToString();

            xnameemp.Text = zglobal.fnGetValue("xname", "hrmst",
                      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xemp='" + xemp.Text.ToString().Trim() + "'");

            xstdid.Text = dttemp.Rows[0]["xstdid"].ToString();

            //xnamestd.Text = zglobal.fnGetValue("xname", "amadmis",
            //          "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" + xstdid.Text.ToString().Trim() + "'");

            xnamestd.Text = zglobal.fnGetValue("xname + ' - '  + xclass + '(' + left(xsection,1) +')'", "amstudentvwextacc",
       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
       xstdid.Text.ToString().Trim() + "' and xsession='" + zglobal.fnDefaults("xsessionacc", "Student") + "'  ");

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT xitem,(select xdesc from msitem where zid=imtemptdt.zid and xitem=imtemptdt.xitem) as xdesc,xqty,xunit,xrate,xremarks,xcf, " +
                         "coalesce((select sum(xqty*xsign) from imtrn where zid=@zid and xwh=@xwh and xitem=imtemptdt.xitem ),0) as xstock " +
                         "FROM imtemptdt WHERE zid=@zid AND ximtmptrn=@ximtmptrn  " +
                         "order by xline";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@ximtmptrn", ximtmptrn123);
                    da1.SelectCommand.Parameters.AddWithValue("@xwh", dttemp.Rows[0]["xfwh"].ToString());



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
                        dt.Columns.Add(new DataColumn("Column7", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column8", typeof(string)));
                        dt.Columns.Add(new DataColumn("Column9", typeof(string)));

                        int i = 0;
                        foreach (DataRow row in tempTable.Rows)
                        {
                            dr = dt.NewRow();
                            //dr["RowNumber"] = 1;
                            dr["Column1"] = tempTable.Rows[i]["xitem"].ToString();
                            dr["Column2"] = tempTable.Rows[i]["xdesc"].ToString();
                            dr["Column3"] = tempTable.Rows[i]["xstock"].ToString();
                            dr["Column4"] = tempTable.Rows[i]["xqty"].ToString();
                            dr["Column5"] = tempTable.Rows[i]["xunit"].ToString();
                            dr["Column6"] = tempTable.Rows[i]["xrate"].ToString();
                            dr["Column7"] = tempTable.Rows[i]["xremarks"].ToString();
                            dr["Column8"] = tempTable.Rows[i]["xcf"].ToString();
                            dt.Rows.Add(dr);

                            i = i + 1;
                        }

                      

                        if (tempTable.Rows.Count < 10)
                        {
                            for(int j=i;j<10;j++)
                            {
                                dr = dt.NewRow();
                                //dr["RowNumber"] = 1;
                                dr["Column1"] = "";
                                dr["Column2"] = "";
                                dr["Column3"] = "";
                                dr["Column4"] = "";
                                dr["Column5"] = "";
                                dr["Column6"] = "";
                                dr["Column7"] = "";
                                dr["Column8"] = "";
                                dt.Rows.Add(dr);

                                i = i + 1;
                            }
                        }


                        ViewState["CurrentTable"] = dt;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        i = 0;
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            
                            
                            TextBox xitem1 = row.FindControl("xitem") as TextBox;
                            TextBox xdesc1 = row.FindControl("xdesc") as TextBox;
                            TextBox xstock1 = row.FindControl("xstock") as TextBox;
                            TextBox xqty1 = row.FindControl("xqty") as TextBox;
                            TextBox xunit1 = row.FindControl("xunit") as TextBox;
                            TextBox xrate1 = row.FindControl("xrate") as TextBox;
                            TextBox xremarks1 = row.FindControl("xremarks") as TextBox;
                            TextBox xcf1 = row.FindControl("xcf") as TextBox;
                            LinkButton btnRemove = row.FindControl("btnRemove") as LinkButton;

                            if (i < tempTable.Rows.Count)
                            {
                                xitem1.Text = tempTable.Rows[i]["xitem"].ToString();
                                xdesc1.Text = tempTable.Rows[i]["xdesc"].ToString();
                                xstock1.Text = Convert.ToDecimal(tempTable.Rows[i]["xstock"].ToString())
                                    .ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo()); ;

                                xqty1.Text =
                                    Convert.ToDecimal(tempTable.Rows[i]["xqty"])
                                        .ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                                xunit1.Text = tempTable.Rows[i]["xunit"].ToString();
                                xrate1.Text =
                                    Convert.ToDecimal(tempTable.Rows[i]["xrate"])
                                        .ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                                xremarks1.Text = tempTable.Rows[i]["xremarks"].ToString();
                                xcf1.Text = tempTable.Rows[i]["xcf"].ToString();
                            }

                            if (dttemp.Rows[0]["xstatus"].ToString() == "Confirmed")
                            {
                                xitem1.Enabled = false;
                                xdesc1.Enabled = false;
                                xqty1.Enabled = false;
                                xunit1.Enabled = false;
                                xrate1.Enabled = false;
                                xremarks1.Enabled = false;
                                xcf1.Enabled = false;
                                btnRemove.Visible = false;
                            }
                            else
                            {
                                //xitem1.Enabled = true;
                                //xdesc1.Enabled = true;
                                xqty1.Enabled = true;
                                //xunit1.Enabled = true;
                                xrate1.Enabled = true;
                                xremarks1.Enabled = true;
                                xcf1.Enabled = true;
                                btnRemove.Visible = true;
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
                ximtmptrn.Enabled = false;
                xdate.Enabled = false;
                //xsup.Enabled = false;
                xfwh.Enabled = false;
                xremarks.Enabled = false;
                btnaddrow.Enabled = false;

            }
            else
            {
                ximtmptrn.Enabled = true;
                xdate.Enabled = true;
                //xsup.Enabled = true;
                xfwh.Enabled = true;
                xremarks.Enabled = true;
                btnaddrow.Enabled = true;
            }

            fnButtonState();
            //BindGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerText = "";
            //    if (ViewState["ximtmptrn"] != null)
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
            //                    //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));

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
            //                    //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["ximtmptrn"]));
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
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["ximtmptrn"]));
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

                //if (ViewState["ximtmptrn"] != null)
                //{
                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh",
                //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));
                //    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                if (ViewState["ximtmptrn"] != null)
                {
                    if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xstatustrn1;


                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM imtemptdt WHERE zid=@zid AND ximtmptrn=@ximtmptrn";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@ximtmptrn", Convert.ToString(ViewState["ximtmptrn"]));
                                cmd.ExecuteNonQuery();

                                query = "DELETE FROM imtemptrn WHERE zid=@zid AND ximtmptrn=@ximtmptrn";
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

        protected void btnRefresh_Click(object sender, EventArgs e)
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
                globalerr = 0;

                if (ViewState["ximtmptrn"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {
                        btnSave_Click(sender, e);

                        if (globalerr == 1)
                        {
                            return;
                        }

                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                        decimal xqtyord1 = zglobal.fnGetValueDecimal("sum(xqty)", "imtemptdt",
                    "zid=" + _zid + " and ximtmptrn='" + ViewState["ximtmptrn"].ToString() + "'");

                        if (xqtyord1 <= 0)
                        {
                            message.InnerText = "No Item Qty found. Cann't Confirm.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }

                        int flag = 0;

                        //foreach (GridViewRow row in GridView1.Rows)
                        //{
                        //    TextBox txtTextBox1 = row.FindControl("xitem") as TextBox;
                        //    if (txtTextBox1.Text != String.Empty)
                        //    {
                        //        TextBox txtTextBox11 = row.FindControl("xrate") as TextBox;
                        //        if (txtTextBox11.Text == String.Empty)
                        //        {
                        //            //txtTextBox1.Text = "";
                        //            row.BackColor = zglobal.rowerr;
                        //            flag = 1;
                        //        }
                        //    }

                        //}

                        //if (flag == 1)
                        //{
                        //    message.InnerText = "Rate not given. Cann't Save.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}

                        flag = 0;

                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            TextBox txtTextBox1 = row.FindControl("xitem") as TextBox;
                            if (txtTextBox1.Text != String.Empty)
                            {
                                TextBox txtTextBox11 = row.FindControl("xqty") as TextBox;
                                if (txtTextBox11.Text == String.Empty)
                                {
                                    //txtTextBox1.Text = "";
                                    row.BackColor = zglobal.rowerr;
                                    flag = 1;
                                }
                            }

                        }

                        if (flag == 1)
                        {
                            message.InnerText = "Quantity not given. Cann't Save.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }

                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                
                                string xconfirmedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xconfirmeddt = DateTime.Now;
                                xstatus = "Confirmed";
                                string xflag10 = "";

                                string query = "";
                                //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));

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
                                //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["ximtmptrn"]));
                                //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lblxline.Text));
                                //        cmd.Parameters.AddWithValue("@xflag1", xflag1);
                                //        cmd.Parameters.AddWithValue("@xflag2", xflag2);
                                //        cmd.Parameters.AddWithValue("@xundoby", Convert.ToString(HttpContext.Current.Session["curuser"]));
                                //        cmd.Parameters.AddWithValue("@xundodt", DateTime.Now);
                                //        cmd.ExecuteNonQuery();
                                //    }
                                //}

                                foreach (GridViewRow row in GridView1.Rows)
                                {
                                    TextBox xitem1234 = row.FindControl("xitem") as TextBox;

                                    if (xitem1234.Text != string.Empty)
                                    {

                                        TextBox xitem12 = row.FindControl("xitem") as TextBox;
                                        TextBox xqty12 = row.FindControl("xqty") as TextBox;




                                        decimal xqty123;
                                        if (xqty12.Text.Trim().ToString() == "" ||
                                            xqty12.Text.Trim().ToString() == String.Empty)
                                        {
                                            xqty123 = 0;
                                        }
                                        else
                                        {
                                            xqty123 = decimal.Parse(xqty12.Text.Trim().ToString());
                                        }

                                        string xcostmeth1 = zglobal.fnGetValue("xcostmeth", "msitem",
                                            "zid=" + _zid + " and xitem='" + xitem12.Text.Trim().ToString() + "'");

                                        string xmode1 = zglobal.fnGetValue("xmode", "imtemptrn",
                                           "zid=" + _zid + " and ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"]) + "'");

                                        string xwh1 = zglobal.fnGetValue("xfwh", "imtemptrn",
                                           "zid=" + _zid + " and ximtmptrn='" + Convert.ToString(ViewState["ximtmptrn"]) + "'");

                                        decimal xval1 = 0;

                                        if (xcostmeth1 == "Weighted Average" && xmode1 != "Purchase Return")
                                        {
                                            string xval123 = zglobal.fnGetValue("isnull(sum(xval*xsign)/nullif(sum(xqty*xsign),0),0)", "imtrn",
                                            "zid=" + _zid + " and xwh='" + xwh1 + "' and xitem='" + xitem12.Text.Trim().ToString() + "'");

                                            xval1 = Convert.ToDecimal(xval123);
                                        }
                                        else
                                        {
                                            xval1 = 0;
                                        }

                                        query =
                                   "UPDATE imtemptdt SET xval=@xval*@xqty,xrate=@xrate " +
                                   "WHERE zid=@zid AND ximtmptrn=@ximtmptrn AND xitem=@xitem";

                                        cmd.CommandText = query;
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@ximtmptrn", Convert.ToString(ViewState["ximtmptrn"]));
                                        cmd.Parameters.AddWithValue("@xitem", xitem12.Text.Trim().ToString());
                                        cmd.Parameters.AddWithValue("@xqty", xqty123);
                                        cmd.Parameters.AddWithValue("@xval", xval1);
                                        cmd.Parameters.AddWithValue("@xrate", xval1);
                                        cmd.ExecuteNonQuery();

                                    }
                                }


                                query =
                                    "UPDATE imtemptrn SET xstatustrn=@xstatustrn,xconfirmby=@xconfirmby,xconfirmdate=@xconfirmdate " +
                                    "WHERE zid=@zid AND ximtmptrn=@ximtmptrn ";

                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@ximtmptrn", Convert.ToString(ViewState["ximtmptrn"]));
                                cmd.Parameters.AddWithValue("@xstatustrn", xstatus);
                                cmd.Parameters.AddWithValue("@xconfirmby", xconfirmedby);
                                cmd.Parameters.AddWithValue("@xconfirmdate", xconfirmeddt);
                                cmd.ExecuteNonQuery();


                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.confsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
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

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {

                message.InnerText = "";
                if (ViewState["ximtmptrn"] != null)
                {
                    if (txtconformmessageValue2.Value == "Yes")
                    {
                        //btnSave_Click(sender, e);

                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));


                        string xvoucher1 = zglobal.fnGetValue("coalesce(xvoucher,'')", "imtemptrn",
                    "zid=" + _zid + " and ximtmptrn='" + ViewState["ximtmptrn"].ToString() + "'");

                        if (xvoucher1 != "")
                        {
                            message.InnerText = "Transaction Posted to GL. Cann't Undo.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }

                        //    int xqtyord1 = zglobal.fnGetValueInt("sum(xqty)", "imtemptdt",
                        //"zid=" + _zid + " and ximtmptrn='" + ViewState["ximtmptrn"].ToString() + "'");

                        //    if (xqtyord1 <= 0)
                        //    {
                        //        message.InnerText = "No Item Qty found. Cann't Confirm.";
                        //        message.Style.Value = zglobal.warningmsg;
                        //        return;
                        //    }

                        //int flag = 0;

                        //foreach (GridViewRow row in GridView1.Rows)
                        //{
                        //    TextBox txtTextBox1 = row.FindControl("xitem") as TextBox;
                        //    if (txtTextBox1.Text != String.Empty)
                        //    {
                        //        TextBox txtTextBox11 = row.FindControl("xrate") as TextBox;
                        //        if (txtTextBox11.Text == String.Empty)
                        //        {
                        //            //txtTextBox1.Text = "";
                        //            row.BackColor = zglobal.rowerr;
                        //            flag = 1;
                        //        }
                        //    }

                        //}

                        //if (flag == 1)
                        //{
                        //    message.InnerText = "Rate not given. Cann't Save.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}

                        //flag = 0;

                        //foreach (GridViewRow row in GridView1.Rows)
                        //{
                        //    TextBox txtTextBox1 = row.FindControl("xitem") as TextBox;
                        //    if (txtTextBox1.Text != String.Empty)
                        //    {
                        //        TextBox txtTextBox11 = row.FindControl("xqty") as TextBox;
                        //        if (txtTextBox11.Text == String.Empty)
                        //        {
                        //            //txtTextBox1.Text = "";
                        //            row.BackColor = zglobal.rowerr;
                        //            flag = 1;
                        //        }
                        //    }

                        //}

                        //if (flag == 1)
                        //{
                        //    message.InnerText = "Quantity not given. Cann't Save.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}


                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;

                                string xconfirmedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xconfirmeddt = DateTime.Now;
                                xstatus = "Open";
                                string xflag10 = "";

                                string query = "";
                                //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["ximtmptrn"]));

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
                                //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["ximtmptrn"]));
                                //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lblxline.Text));
                                //        cmd.Parameters.AddWithValue("@xflag1", xflag1);
                                //        cmd.Parameters.AddWithValue("@xflag2", xflag2);
                                //        cmd.Parameters.AddWithValue("@xundoby", Convert.ToString(HttpContext.Current.Session["curuser"]));
                                //        cmd.Parameters.AddWithValue("@xundodt", DateTime.Now);
                                //        cmd.ExecuteNonQuery();
                                //    }
                                //}


                                query =
                                    "UPDATE imtemptrn SET xstatustrn=@xstatustrn,xundoby=@xundoby,xundodate=@xundodate " +
                                    "WHERE zid=@zid AND ximtmptrn=@ximtmptrn ";

                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@ximtmptrn", Convert.ToString(ViewState["ximtmptrn"]));
                                cmd.Parameters.AddWithValue("@xstatustrn", xstatus);
                                cmd.Parameters.AddWithValue("@xundoby", xconfirmedby);
                                cmd.Parameters.AddWithValue("@xundodate", xconfirmeddt);
                                cmd.ExecuteNonQuery();


                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.undosuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "Open";
                        hxstatus.Value = "Open";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        hiddenxstatus.Value = "Open";
                        fnButtonState();
                        //BindGrid();
                        fnFillGrid2();
                        fnFillControl(Convert.ToString(ViewState["ximtmptrn"]));
                    }
                }
                else
                {
                    message.InnerHtml = "No record found for undo.";
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
            //    ViewState["ximtmptrn"] = null;
            //    xrow1.Text = "";
            //    xsession.Text = zglobal.fnDefaults("xsession", "Student");
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

        protected void xglevel2_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        con.Open();
                        string query =
                            //"SELECT xitemset FROM msitem WHERE zid=@zid AND xglevel2=@xglevel2 and coalesce(xitemset,'')<>'' group by xitemset";

                            "SELECT xsetname as xitemset FROM imitemsetvw where zid=@zid and xclass=@xclass group by xsetname";

                        SqlDataAdapter da = new SqlDataAdapter(query, con);

                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xclass", xglevel2.Text.ToString().Trim());

                        DataTable tempTable = new DataTable();
                        da.Fill(dts, "tempTable");
                        tempTable = dts.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            includeset.Visible = true;

                            setlist.Controls.Clear();
                            foreach (DataRow row in tempTable.Rows)
                            {
                                LinkButton setlink = new LinkButton();
                                setlink.Text = row["xitemset"].ToString();
                                setlink.Attributes.Add("style","padding-left:15px;");
                                setlink.Click += SetlinkOnClick;
                                setlist.Controls.Add(setlink);
                               
                            }
                        }
                        else
                        {
                            includeset.Visible = false;
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

        private void SetlinkOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                message.InnerHtml = "";
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                LinkButton lnk = (LinkButton)sender;
                //message.InnerHtml = lnk.Text;

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        con.Open();

                        string query =
                            "SELECT msitem.xitem,msitem.xdesc,xunitiss as xunit,xcfiss as xcf, " +
                            "coalesce((select sum(xqty*xsign) from imtrn where zid=@zid and xwh=@xwh and xitem=msitem.xitem ),0) as xstock,imitemsetvw.xqty " +
                            "FROM msitem inner join imitemsetvw on msitem.zid=imitemsetvw.zid and msitem.xitem=imitemsetvw.xitem " +
                            "WHERE imitemsetvw.zid=@zid AND imitemsetvw.xclass=@xclass and imitemsetvw.xsetname=@xsetname ";

                        SqlDataAdapter da = new SqlDataAdapter(query, con);

                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xclass", xglevel2.Text.ToString().Trim());
                        da.SelectCommand.Parameters.AddWithValue("@xsetname", lnk.Text.ToString().Trim());
                        da.SelectCommand.Parameters.AddWithValue("@xwh", xfwh.Text.ToString().Trim());

                        DataTable tempTable = new DataTable();
                        da.Fill(dts, "tempTable");
                        tempTable = dts.Tables["tempTable"];

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
                            dt.Columns.Add(new DataColumn("Column7", typeof(string)));
                            dt.Columns.Add(new DataColumn("Column8", typeof(string)));
                            dt.Columns.Add(new DataColumn("Column9", typeof(string)));

                            int i = 0;
                            foreach (DataRow row in tempTable.Rows)
                            {
                                dr = dt.NewRow();
                                //dr["RowNumber"] = 1;
                                dr["Column1"] = tempTable.Rows[i]["xitem"].ToString();
                                dr["Column2"] = tempTable.Rows[i]["xdesc"].ToString();
                                dr["Column3"] = tempTable.Rows[i]["xstock"].ToString();
                                dr["Column4"] = tempTable.Rows[i]["xqty"].ToString();
                                dr["Column5"] = tempTable.Rows[i]["xunit"].ToString();
                                dr["Column6"] = "";
                                dr["Column7"] = "";
                                dr["Column8"] = tempTable.Rows[i]["xcf"].ToString();
                                dt.Rows.Add(dr);

                                i = i + 1;
                            }



                            if (tempTable.Rows.Count < 10)
                            {
                                for (int j = i; j < 10; j++)
                                {
                                    dr = dt.NewRow();
                                    //dr["RowNumber"] = 1;
                                    dr["Column1"] = "";
                                    dr["Column2"] = "";
                                    dr["Column3"] = "";
                                    dr["Column4"] = "";
                                    dr["Column5"] = "";
                                    dr["Column6"] = "";
                                    dr["Column7"] = "";
                                    dr["Column8"] = "";
                                    dt.Rows.Add(dr);

                                    i = i + 1;
                                }
                            }


                            ViewState["CurrentTable"] = dt;
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            i = 0;
                            foreach (GridViewRow row in GridView1.Rows)
                            {


                                TextBox xitem1 = row.FindControl("xitem") as TextBox;
                                TextBox xdesc1 = row.FindControl("xdesc") as TextBox;
                                TextBox xstock1 = row.FindControl("xstock") as TextBox;
                                TextBox xqty1 = row.FindControl("xqty") as TextBox;
                                TextBox xunit1 = row.FindControl("xunit") as TextBox;
                                TextBox xrate1 = row.FindControl("xrate") as TextBox;
                                TextBox xremarks1 = row.FindControl("xremarks") as TextBox;
                                TextBox xcf1 = row.FindControl("xcf") as TextBox;
                                LinkButton btnRemove = row.FindControl("btnRemove") as LinkButton;

                                if (i < tempTable.Rows.Count)
                                {
                                    xitem1.Text = tempTable.Rows[i]["xitem"].ToString();
                                    xdesc1.Text = tempTable.Rows[i]["xdesc"].ToString();
                                    xstock1.Text = Convert.ToDecimal(tempTable.Rows[i]["xstock"].ToString())
                                        .ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo()); ;

                                    xqty1.Text = tempTable.Rows[i]["xqty"].ToString();
                                    xunit1.Text = tempTable.Rows[i]["xunit"].ToString();
                                    xrate1.Text = "";
                                    xremarks1.Text = "";
                                    xcf1.Text = tempTable.Rows[i]["xcf"].ToString();
                                }


                                i = i + 1;
                            }
                        }
                        else
                        {

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

        //private void SetlinkOnClick(object sender, EventArgs eventArgs)
        //{
        //    try
        //    {
        //        message.InnerHtml = "";
        //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

        //        LinkButton lnk = (LinkButton) sender;
        //        //message.InnerHtml = lnk.Text;

        //        using (SqlConnection con = new SqlConnection(zglobal.constring))
        //        {
        //            using (DataSet dts = new DataSet())
        //            {
        //                con.Open();

        //                string query =
        //                    "SELECT xitem,xdesc,xunitiss as xunit,xcfiss as xcf, " +
        //                    "coalesce((select sum(xqty*xsign) from imtrn where zid=@zid and xwh=@xwh and xitem=msitem.xitem ),0) as xstock " +
        //                    "FROM msitem WHERE zid=@zid AND xglevel2=@xglevel2 and coalesce(xitemset,'')=@xitemset";

        //                SqlDataAdapter da = new SqlDataAdapter(query, con);

        //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
        //                da.SelectCommand.Parameters.AddWithValue("@xglevel2", xglevel2.Text.ToString().Trim());
        //                da.SelectCommand.Parameters.AddWithValue("@xitemset", lnk.Text.ToString().Trim());
        //                da.SelectCommand.Parameters.AddWithValue("@xwh", xfwh.Text.ToString().Trim());

        //                DataTable tempTable = new DataTable();
        //                da.Fill(dts, "tempTable");
        //                tempTable = dts.Tables["tempTable"];

        //                if (tempTable.Rows.Count > 0)
        //                {
        //                    DataTable dt = new DataTable();
        //                    DataRow dr = null;

        //                    //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column7", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column8", typeof(string)));
        //                    dt.Columns.Add(new DataColumn("Column9", typeof(string)));

        //                    int i = 0;
        //                    foreach (DataRow row in tempTable.Rows)
        //                    {
        //                        dr = dt.NewRow();
        //                        //dr["RowNumber"] = 1;
        //                        dr["Column1"] = tempTable.Rows[i]["xitem"].ToString();
        //                        dr["Column2"] = tempTable.Rows[i]["xdesc"].ToString();
        //                        dr["Column3"] = tempTable.Rows[i]["xstock"].ToString();
        //                        dr["Column4"] = "";
        //                        dr["Column5"] = tempTable.Rows[i]["xunit"].ToString();
        //                        dr["Column6"] = "";
        //                        dr["Column7"] = "";
        //                        dr["Column8"] = tempTable.Rows[i]["xcf"].ToString();
        //                        dt.Rows.Add(dr);

        //                        i = i + 1;
        //                    }



        //                    if (tempTable.Rows.Count < 10)
        //                    {
        //                        for (int j = i; j < 10; j++)
        //                        {
        //                            dr = dt.NewRow();
        //                            //dr["RowNumber"] = 1;
        //                            dr["Column1"] = "";
        //                            dr["Column2"] = "";
        //                            dr["Column3"] = "";
        //                            dr["Column4"] = "";
        //                            dr["Column5"] = "";
        //                            dr["Column6"] = "";
        //                            dr["Column7"] = "";
        //                            dr["Column8"] = "";
        //                            dt.Rows.Add(dr);

        //                            i = i + 1;
        //                        }
        //                    }


        //                    ViewState["CurrentTable"] = dt;
        //                    GridView1.DataSource = dt;
        //                    GridView1.DataBind();

        //                    i = 0;
        //                    foreach (GridViewRow row in GridView1.Rows)
        //                    {


        //                        TextBox xitem1 = row.FindControl("xitem") as TextBox;
        //                        TextBox xdesc1 = row.FindControl("xdesc") as TextBox;
        //                        TextBox xstock1 = row.FindControl("xstock") as TextBox;
        //                        TextBox xqty1 = row.FindControl("xqty") as TextBox;
        //                        TextBox xunit1 = row.FindControl("xunit") as TextBox;
        //                        TextBox xrate1 = row.FindControl("xrate") as TextBox;
        //                        TextBox xremarks1 = row.FindControl("xremarks") as TextBox;
        //                        TextBox xcf1 = row.FindControl("xcf") as TextBox;
        //                        LinkButton btnRemove = row.FindControl("btnRemove") as LinkButton;

        //                        if (i < tempTable.Rows.Count)
        //                        {
        //                            xitem1.Text = tempTable.Rows[i]["xitem"].ToString();
        //                            xdesc1.Text = tempTable.Rows[i]["xdesc"].ToString();
        //                            xstock1.Text = Convert.ToDecimal(tempTable.Rows[i]["xstock"].ToString())
        //                                .ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo()); ;

        //                            xqty1.Text = "";
        //                            xunit1.Text = tempTable.Rows[i]["xunit"].ToString();
        //                            xrate1.Text = "";
        //                            xremarks1.Text = "";
        //                            xcf1.Text = tempTable.Rows[i]["xcf"].ToString();
        //                        }


        //                        i = i + 1;
        //                    }
        //                }
        //                else
        //                {
                            
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        message.InnerHtml = exp.Message;
        //        message.Style.Value = zglobal.errormsg;
        //    }
        //}


    }
}