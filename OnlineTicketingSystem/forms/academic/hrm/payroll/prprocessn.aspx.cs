﻿using System;
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
    public partial class prprocessn : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            //if (ViewState["xsup"] == null)
            //{
            //    btnSubmit.Enabled = false;
            //    btnSubmit1.Enabled = false;
            //    btnSave.Enabled = true;
            //    btnSave1.Enabled = true;
            //    btnDelete.Enabled = false;
            //    btnDelete1.Enabled = false;
            //    btnConfirm.Enabled = false;
            //    btnConfirm1.Enabled = false;
            //    btnPaid.Enabled = false;
            //    btnPaid1.Enabled = false;
            //    btnPrint.Enabled = false;
            //    btnPrint1.Enabled = false;
            //    //dxstatus.Visible = false;
            //    //dxstatus.Text = "-";
            //    //xsessionpro.Text = "";
            //    //xclasspro.Text = "";
            //    //xgrouppro.Text = "";
            //    xsession.Enabled = true;
            //    xstdid.Enabled = true;
            //    hxstatus.Value = "";
            //    //xstatus.InnerHtml = "";
            //    //zemail.InnerHtml = "";
            //    //xapprovedby.InnerHtml = "";
            //    hiddenxrow.Value = "";
            //}
            //else
            //{
            //    xsup.Text = ViewState["xsup"].ToString();
            //    ////xsession.Enabled = false;
            //    ////xstdid.Enabled = false;

            //    //string xstatus1 = "";
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    string xstatus1 = zglobal.fnGetValue("xstatus", "prholiday",
            //        "zid=" + _zid + " AND xshift='" + xshift.Text.ToString().Trim() + "' AND xdate='" +
            //        DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
            //            CultureInfo.InvariantCulture) + "'");
            //    ////hxstatus.Value = xstatus1;
            //    ////xstatus.InnerHtml = xstatus1;
            //    ////zemail.InnerHtml = zglobal.fnGetValue("coalesce(zemail,'') as zemail", "amdropout",
            //    ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    ////xapprovedby.InnerHtml = zglobal.fnGetValue("coalesce(xapprovedby,'') as xapprovedby", "amdropout",
            //    ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            //    ////xsessionpro.Text = zglobal.fnGetValue("xsessionpro", "ampromotionh",
            //    ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            //    ////xclasspro.Text = zglobal.fnGetValue("xclasspro", "ampromotionh",
            //    ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

            //    ////xgrouppro.Text = zglobal.fnGetValue("xgrouppro", "ampromotionh",
            //    ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    ////dxstatus.Visible = true;

            //    //if (xstatus1 == "New" || xstatus1 == "Undo")
            //    //{
            //    //    btnSubmit.Enabled = true;
            //    //    btnSubmit1.Enabled = true;
            //    //    btnConfirm.Enabled = true;
            //    //    btnConfirm1.Enabled = true;
            //    //    btnSave.Enabled = true;
            //    //    btnSave1.Enabled = true;
            //    //    btnDelete.Enabled = true;
            //    //    btnDelete1.Enabled = true;
            //    //    btnPaid.Enabled = true;
            //    //    btnPaid1.Enabled = true;
            //    //    btnPrint.Enabled = true;
            //    //    btnPrint1.Enabled = true;
            //    //    //dxstatus.Text = xstatus1;
            //    //    hxstatus.Value = xstatus1;
            //    //    //dxstatus.Style.Value = zglobal.am_new;

            //    //    //xsessionpro.Enabled = true;
            //    //    //xclasspro.Enabled = true;
            //    //    //xgrouppro.Enabled = true;

            //    //    //xsession.Enabled = false;
            //    //    //xstdid.Enabled = false;

            //    //}
            //    //else
            //    //{
            //    //    btnSubmit.Enabled = false;
            //    //    btnSubmit1.Enabled = false;
            //    //    btnConfirm.Enabled = false;
            //    //    btnConfirm1.Enabled = false;
            //    //    btnSave.Enabled = false;
            //    //    btnSave1.Enabled = false;
            //    //    btnDelete.Enabled = false;
            //    //    btnDelete1.Enabled = false;
            //    //    btnPaid.Enabled = false;
            //    //    btnPaid1.Enabled = false;
            //    //    btnPrint.Enabled = true;
            //    //    btnPrint1.Enabled = true;
            //    //    //dxstatus.Text = xstatus1;
            //    //    hxstatus.Value = xstatus1;
            //    //    //dxstatus.Style.Value = zglobal.am_submited;

            //    //    //xsessionpro.Enabled = false;
            //    //    //xclasspro.Enabled = false;
            //    //    //xgrouppro.Enabled = false;
            //    //}

            //    ////if (xstatus1 == "New" || xstatus1 == "Undo")
            //    ////{
            //    ////    dxstatus.Style.Value = zglobal.am_new;
            //    ////}
            //    ////else
            //    ////{
            //    ////    dxstatus.Style.Value = zglobal.am_submited;
            //    ////}
            //    //if (xstatus1 == "Undo1")
            //    //{
            //    //    //int t = 0;
            //    //    //foreach (GridViewRow row in GridView1.Rows)
            //    //    //{
            //    //    //    Label lblxflag1 = row.FindControl("xflag1") as Label;
            //    //    //    Label lblxflag2 = row.FindControl("xflag2") as Label;

            //    //    //    if (lblxflag1.Text == "Wrong" || lblxflag2.Text == "Missing")
            //    //    //    {
            //    //    //        t = 1;
            //    //    //        break;
            //    //    //    }
            //    //    //}

            //    //    //if (t == 1)
            //    //    //{
            //    //    //    btnSave.Enabled = true;
            //    //    //    btnSave1.Enabled = true;
            //    //    //    btnDelete.Enabled = false;
            //    //    //    btnDelete1.Enabled = false;
            //    //    //    btnSubmit.Enabled = true;
            //    //    //    btnSubmit1.Enabled = true;
            //    //    //}
            //    //    //else
            //    //    //{
            //    //    //    btnSave.Enabled = false;
            //    //    //    btnSave1.Enabled = false;
            //    //    //    btnDelete.Enabled = false;
            //    //    //    btnDelete1.Enabled = false;
            //    //    //    btnSubmit.Enabled = false;
            //    //    //    btnSubmit1.Enabled = false;
            //    //    //}

            //    //    btnSave.Enabled = true;
            //    //    btnSave1.Enabled = true;
            //    //    //btnDelete.Enabled = false;
            //    //    //btnDelete1.Enabled = false;
            //    //    btnDelete.Enabled = true;
            //    //    btnDelete1.Enabled = true;
            //    //    btnSubmit.Enabled = true;
            //    //    btnSubmit1.Enabled = true;

            //    //    //xsessionpro.Enabled = true;
            //    //    //xclasspro.Enabled = true;
            //    //    //xgrouppro.Enabled = true;
            //    //}

            //    if (xstatus1 == "")
            //    {
            //        btnConfirm.Enabled = true;
            //        btnConfirm1.Enabled = true;
            //        btnSave.Enabled = true;
            //        btnSave1.Enabled = true;
            //        btnDelete.Enabled = true;
            //        btnDelete1.Enabled = true;
            //    }
            //    else
            //    {
            //        btnConfirm.Enabled = false;
            //        btnConfirm1.Enabled = false;
            //        btnSave.Enabled = false;
            //        btnSave1.Enabled = false;
            //        btnDelete.Enabled = false;
            //        btnDelete1.Enabled = false;
            //    }

            //    btnSubmit.Enabled = false;
            //    btnSubmit1.Enabled = false;
            //    //btnSave.Enabled = true;
            //    //btnSave1.Enabled = true;
            //    //btnDelete.Enabled = false;
            //    //btnDelete1.Enabled = false;
            //    //btnConfirm.Enabled = false;
            //    //btnConfirm1.Enabled = false;
            //    btnPaid.Enabled = false;
            //    btnPaid1.Enabled = false;
            //    btnPrint.Enabled = false;
            //    btnPrint1.Enabled = false;

            //    //btnSave.Enabled = true;
            //    //btnSave1.Enabled = true;
            //    //btnDelete.Enabled = false;
            //    //btnDelete1.Enabled = false;
            //    //btnDelete.Enabled = true;
            //    //btnDelete1.Enabled = true;

            //}

            btnPaid.Visible = false;
            btnPaid1.Visible = false;
            btnConfirm.Visible = false;
            btnConfirm1.Visible = false;
            btnDelete.Visible = false;
            btnDelete1.Visible = false;
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
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //        zglobal.fnGetComboDataCD("Education Group", xgrouppro);
                    //        // zglobal.fnGetComboDataCD("Test Type", xcttype);

                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Bank", xbank);
                    //        zglobal.fnGetComboDataCD("Class", xclasspro);
                    //        //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //        //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    //        zglobal.fnGetComboDataCD("Section", xsection);
                    //        //zglobal.fnGetComboDataCD("Class Subject", xsubject);
                    //zglobal.fnGetComboDataCD("Dropout Type", xtype);
                    //zglobal.fnGetComboDataCD("Dropout Reason", xreason);
                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //xbank.Text = zglobal.fnDefaults("xbank", "Student");

                    //        //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //        //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //        //zsetvalue.SetDWNumItem(xctno, 2, 1);

                    //zglobal.fnGetComboDataCD("Country", xcountry);
                    //zglobal.fnGetComboDataCD("Supplier Group", xgsup);
                    //zglobal.fnGetComboDataCD("Tax Scope", xtaxscope);
                    //zglobal.fnGetComboDataCDTRN("'Supplier Number'", xtrnsup);

                    //zglobal.fnGetComboDataCD("Shift Code", xshift);
                    //zglobal.fnComboWeekDay(xstr01);
                    //zglobal.fnComboWeekDay(xremark);

                    //xatdstat.Items.Clear();
                    //xatdstat.Items.Add("");
                    //xatdstat.Items.Add("Yes");
                    //xatdstat.Items.Add("No");
                    //xatdstat.Text = "No";

                    //xstr01.Items.Add("");
                    //xstr01.Items.Add("Check");

                    ViewState["xrow"] = null;
                    hiddenxrow.Value = "";
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    ViewState["xsup"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";
                    hxclass.Value = "";

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
                    //xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    _gridrow.Text = zglobal._grid_row_value;
                    _gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();
                    //SetInitialRow();
                    ViewState["xtype"] = "Tuition Fee";

                    btnPaid.Visible = false;
                    btnPaid1.Visible = false;

                }

                //       xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' ");

                //       //xstdname.Text = zglobal.fnGetValue("xname + ' - ' + xclass + ' ('+xsection+')'", "amstudentvw",
                //       //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       //       xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xclass.Text = zglobal.fnGetValue("xclass", "amstudentvw",
                //          "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //          xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xgroup.Text = zglobal.fnGetValue("xgroup", "amstudentvw",
                //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //    xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       //       xsection.Text = zglobal.fnGetValue("xsection", "amstudentvw",
                //       //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       //    xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       //       xname.Text = zglobal.fnGetValue("xname", "amadmis",
                //       //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       //xstdid.Text.ToString().Trim() + "' ");
                //       //       xfname.Text = zglobal.fnGetValue("xfname", "amstudentvw",
                //       //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       //       xmname.Text = zglobal.fnGetValue("xmname", "amstudentvw",
                //       //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");

                //       BindGrid();
                fnRegisterPostBack();
                //fnCalculateTotal();
                //xstdid.Focus();
                //xstdid.Attributes.Add("onfocus","javascript:this.select();");
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnRegisterPostBack()
        {
            foreach (GridViewRow row in dgvcollectionew.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xdate") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            foreach (GridViewRow row in dgvcollectionpaid.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xshift") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }
        }

        private decimal xnettotal1 = 0;
        private decimal xreceived = 0;
        private decimal xdue = 0;
        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        List<string> listsubject = new List<string>();
        private void BindGrid()
        {
            //if (xsession.Text.Trim().ToString() == "" || xstdid.Text.Trim().ToString() == "" ||
            //    xcdate.Text.Trim().ToString() == "")
            //{
            //    return;

            //}

            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //xnettotal1 = 0;
            //xreceived = 0;
            //xdue = 0;

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();


            //string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();

            //string str = "";

            //string[] date = new string[2];
            //if (xcdate.Text.ToString().Trim() == "")
            //{
            //    date[0] = "Jan";
            //    date[1] = "1800";
            //}
            //else
            //{
            //    date = xcdate.Text.Split('-');
            //}

            //int year = Int32.Parse(date[1]);
            //int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
            //DateTime xeffdate1 = new DateTime(year, month, 1);
            //int xrow1;

            //ViewState["xstatus"] = "";
            //ViewState["amtfcd"] = null;

            //if (ViewState["xrow"] != null)
            //{



            //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfch",
            //           "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    ViewState["xstatus"] = xstatus1;

            //    if (xstatus1 != "Paid")
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            using (DataSet dts1 = new DataSet())
            //            {
            //                string query = "SELECT * FROM amtfcd WHERE zid=@zid AND xrow=@xrow";
            //                SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
            //                da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
            //                da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
            //                da1.Fill(dts1, "tblamadmisd");
            //                amexamd = dts1.Tables[0];
            //                if (amexamd.Rows.Count > 0)
            //                {
            //                    ViewState["amtfcd"] = amexamd;
            //                }
            //                else
            //                {
            //                    ViewState["amtfcd"] = null;
            //                }
            //            }
            //        }
            //    }
            //}


            //if (ViewState["xrow"] != null)
            //{
            //    str =
            //        "SELECT  xtfccode,xdescdet,xtype,xamount as xnettotal1,xreceived,xremarks1," +
            //        "coalesce((select xdue from amtfcduecalvw1 where zid=amtfcvw.zid and xsession=amtfcvw.xsession and xsrow=amtfcvw.xsrow and xtfccode=amtfcvw.xtfccode),0) as xdue " +
            //        "FROM amtfcvw " +
            //        "WHERE zid=@zid AND xrow=@xrow ";// +
            //   //"ORDER BY xsequence";
            //    xrow1 = Convert.ToInt32(ViewState["xrow"].ToString());
            //}
            //else
            //{
            //    str = zglobal.fnxtfcdefault3(ViewState["xtype"].ToString());
            //    xrow1 = 0;
            //}

            //Int64 xsrow1 = zglobal.fnGetValue("xrow", "amadmis",
            //    "zid=" + _zid + " and xstdid='" +
            //    xstdid.Text.ToString().Trim() + "' ") != ""
            //    ? Convert.ToInt64(zglobal.fnGetValue("xrow", "amadmis",
            //        "zid=" + _zid + " and xstdid='" +
            //        xstdid.Text.ToString().Trim() + "' "))
            //    : 0;

            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
            //da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //da.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow1);
            //da.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
            //da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
            //da.Fill(dts, "tempztcode");
            //DataTable dtmarks = new DataTable();
            //dtmarks = dts.Tables[0];

            //if (dtmarks.Rows.Count > 0)
            //{

            //    GridView1.Columns.Clear();

            //    bfield = new BoundField();
            //    bfield.HeaderText = "TFC Code";
            //    bfield.DataField = "xtfccode";
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    bfield.ItemStyle.Width = 100;
            //    GridView1.Columns.Add(bfield);

            //    bfield = new BoundField();
            //    bfield.HeaderText = "Description";
            //    bfield.DataField = "xdescdet";
            //    bfield.ItemStyle.Width = 250;
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            //    GridView1.Columns.Add(bfield);

            //    bfield = new BoundField();
            //    bfield.HeaderText = "Default Amount";
            //    bfield.DataField = "xnettotal1";
            //    bfield.ItemStyle.Width = 150;
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            //    GridView1.Columns.Add(bfield);

            //    bfield = new BoundField();
            //    bfield.HeaderText = "Receivable Amount";
            //    bfield.DataField = "xdue";
            //    bfield.ItemStyle.Width = 150;
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            //    GridView1.Columns.Add(bfield);

            //    tfield = new TemplateField();
            //    tfield.HeaderText = "Received Amount";
            //    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            //    tfield.ItemStyle.Width = 150;
            //    GridView1.Columns.Add(tfield);

            //    tfield = new TemplateField();
            //    tfield.HeaderText = "Remarks";
            //    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            //    tfield.ItemStyle.Width = 300;
            //    GridView1.Columns.Add(tfield);

            //    TemplateField tfield3 = new TemplateField();
            //    tfield3.HeaderText = "";
            //    tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    GridView1.Columns.Add(tfield3);






            //    GridView1.DataSource = dtmarks;
            //    GridView1.DataBind();



            //}
            //else
            //{
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //}

        }

        TextBox txTextBox;
        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (GridView1.DataSource == null)
            //    {
            //        return;
            //    }




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
            //        xnettotal1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xnettotal1"));
            //        xdue += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xdue"));

            //        TextBox txtReceive = new TextBox();
            //        txtReceive.ID = "xreceived";
            //        txtReceive.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xreceive";
            //        txtReceive.Attributes.Add("onkeyup", "enter(this,event)");
            //        e.Row.Cells[4].Controls.Add(txtReceive);

            //        TextBox txtRemarks = new TextBox();
            //        txtRemarks.ID = "xremarks";
            //        txtRemarks.CssClass = "xremarks";
            //        txtRemarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //        txtRemarks.Attributes.Add("onkeyup", "enter(this,event)");
            //        e.Row.Cells[5].Controls.Add(txtRemarks);

            //        if (ViewState["amtfcd"] != null)
            //        {
            //            DataTable dt = new DataTable();
            //            dt = ViewState["amtfcd"] as DataTable;
            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (row["xtfccode"].ToString() == e.Row.Cells[0].Text.ToString())
            //                {

            //                    txtReceive.Text = row["xreceived"].ToString();
            //                    txtRemarks.Text = row["xremarks"].ToString();

            //                    xreceived += Convert.ToDecimal(row["xreceived"]);
            //                    break;
            //                }
            //            }
            //        }

            //        if (ViewState["xstatus"] != null)
            //        {
            //            if (ViewState["xstatus"].ToString() == "Paid")
            //            {
            //                txtReceive.Enabled = false;
            //                txtRemarks.Enabled = false;

            //                txtReceive.Text = (e.Row.DataItem as DataRowView).Row["xreceived"].ToString();
            //                txtRemarks.Text = (e.Row.DataItem as DataRowView).Row["xremarks1"].ToString();

            //                xreceived += Convert.ToDecimal((e.Row.DataItem as DataRowView).Row["xreceived"].ToString());
            //            }
            //        }
            //    }

            //    if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        e.Row.Cells[1].Text = "Total :";
            //        e.Row.Cells[1].Font.Bold = true;
            //        e.Row.Cells[1].ForeColor = Color.White;
            //        e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

            //        e.Row.Cells[2].Text = xnettotal1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //        e.Row.Cells[2].Font.Bold = true;
            //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //        e.Row.Cells[2].ForeColor = Color.White;

            //        e.Row.Cells[3].Text = xdue.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //        e.Row.Cells[3].Font.Bold = true;
            //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            //        e.Row.Cells[3].ForeColor = Color.White;

            //        e.Row.Cells[4].Font.Bold = true;
            //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //        e.Row.Cells[4].ForeColor = Color.White;

            //        if (ViewState["xrow"] != null)
            //        {
            //            e.Row.Cells[4].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
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

            dr = dt.NewRow();
            //dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dt.Rows.Add(dr);

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
            //TextBox xreceivabletot1 = GridView1.FooterRow.FindControl("xreceivabletot") as TextBox;
            //TextBox xreceivedtot1 = GridView1.FooterRow.FindControl("xreceivedtot") as TextBox;

            //xreceivedtot1.Text = "";
            //xreceivabletot1.Text = "";
            //fnCalculateTotal();

        }

        private void AddNewRowToGrid()
        {

            //if (ViewState["CurrentTable"] != null)
            //{

            //    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            //    DataRow drCurrentRow = null;

            //    if (dtCurrentTable.Rows.Count > 0)
            //    {
            //        drCurrentRow = dtCurrentTable.NewRow();
            //        //drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

            //        //add new row to DataTable   
            //        dtCurrentTable.Rows.Add(drCurrentRow);
            //        ////Store the current data to ViewState for future reference   

            //        //ViewState["CurrentTable"] = dtCurrentTable;


            //        //for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
            //        for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
            //        {

            //            //extract the TextBox values   

            //            TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xtfccode");
            //            TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xdescdet");
            //            TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xamount");
            //            TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceivable");
            //            TextBox box5 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceived");
            //            TextBox box6 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xremarks");

            //            dtCurrentTable.Rows[i]["Column1"] = box1.Text;
            //            dtCurrentTable.Rows[i]["Column2"] = box2.Text;
            //            dtCurrentTable.Rows[i]["Column3"] = box3.Text;
            //            dtCurrentTable.Rows[i]["Column4"] = box4.Text;
            //            dtCurrentTable.Rows[i]["Column5"] = box5.Text;
            //            dtCurrentTable.Rows[i]["Column6"] = box6.Text;

            //            ////extract the DropDownList Selected Items   

            //            //DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[3].FindControl("DropDownList1");
            //            //DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[4].FindControl("DropDownList2");

            //            // Update the DataRow with the DDL Selected Items   

            //            //dtCurrentTable.Rows[i]["Column3"] = ddl1.SelectedItem.Text;
            //            //dtCurrentTable.Rows[i]["Column4"] = ddl2.SelectedItem.Text;

            //        }

            //        //Store the current data to ViewState for future reference   

            //        ViewState["CurrentTable"] = dtCurrentTable;

            //        //Rebind the Grid with the current data to reflect changes   
            //        GridView1.DataSource = dtCurrentTable;
            //        GridView1.DataBind();
            //    }
            //}
            ////else
            ////{
            ////    Response.Write("ViewState is null");

            ////}
            ////Set Previous Data on Postbacks   
            //SetPreviousData();
        }

        private void SetPreviousData()
        {

            //int rowIndex = 0;
            //if (ViewState["CurrentTable"] != null)
            //{

            //    DataTable dt = (DataTable)ViewState["CurrentTable"];
            //    if (dt.Rows.Count > 0)
            //    {

            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {

            //            TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xtfccode");
            //            TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xdescdet");
            //            TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xamount");
            //            TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceivable");
            //            TextBox box5 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceived");
            //            TextBox box6 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xremarks");

            //            //DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
            //            //DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("DropDownList2");

            //            ////Fill the DropDownList with Data   
            //            //FillDropDownList(ddl1);
            //            //FillDropDownList(ddl2);

            //            //if (i < dt.Rows.Count - 1)
            //            //{

            //            //Assign the value from DataTable to the TextBox   
            //            box1.Text = dt.Rows[i]["Column1"].ToString();
            //            box2.Text = dt.Rows[i]["Column2"].ToString();
            //            box3.Text = dt.Rows[i]["Column3"].ToString();
            //            box4.Text = dt.Rows[i]["Column4"].ToString();
            //            box5.Text = dt.Rows[i]["Column5"].ToString();
            //            box6.Text = dt.Rows[i]["Column6"].ToString();

            //            ////Set the Previous Selected Items on Each DropDownList  on Postbacks   
            //            //ddl1.ClearSelection();
            //            //ddl1.Items.FindByText(dt.Rows[i]["Column3"].ToString()).Selected = true;

            //            //ddl2.ClearSelection();
            //            //ddl2.Items.FindByText(dt.Rows[i]["Column4"].ToString()).Selected = true;

            //            //}

            //            rowIndex++;
            //        }
            //    }
            //}
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    AddNewRowToGrid();
            //    fnCalculateTotal();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    LinkButton lb = (LinkButton)sender;
            //    GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            //    int rowID = gvRow.RowIndex;
            //    if (ViewState["CurrentTable"] != null)
            //    {

            //        DataTable dt = (DataTable)ViewState["CurrentTable"];

            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {

            //            //extract the TextBox values   

            //            TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xtfccode");
            //            TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xdescdet");
            //            TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xamount");
            //            TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceivable");
            //            TextBox box5 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceived");
            //            TextBox box6 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xremarks");

            //            dt.Rows[i]["Column1"] = box1.Text;
            //            dt.Rows[i]["Column2"] = box2.Text;
            //            dt.Rows[i]["Column3"] = box3.Text;
            //            dt.Rows[i]["Column4"] = box4.Text;
            //            dt.Rows[i]["Column5"] = box5.Text;
            //            dt.Rows[i]["Column6"] = box6.Text;

            //        }


            //        if (dt.Rows.Count > 1)
            //        {
            //            //if (gvRow.RowIndex < dt.Rows.Count - 1)
            //            //{
            //            //Remove the Selected Row data and reset row number  
            //            dt.Rows.Remove(dt.Rows[rowID]);
            //            //ResetRowID(dt);
            //            //}
            //        }




            //        //Store the current data in ViewState for future reference  
            //        ViewState["CurrentTable"] = dt;

            //        //Re bind the GridView for the updated data  
            //        GridView1.DataSource = dt;
            //        GridView1.DataBind();
            //    }

            //    //Set Previous Data on Postbacks  
            //    SetPreviousData();
            //    fnCalculateTotal();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        private void ResetRowID(DataTable dt)
        {
            //int rowNumber = 1;
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        row[0] = rowNumber;
            //        rowNumber++;
            //    }
            //}
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

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                if (xpaydate.Text == "" || xpaydate.Text == string.Empty || xpaydate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Payment Date</li>";
                    isValid = false;
                }



                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                DateTime xpaydate1 = xpaydate.Text.Trim() != string.Empty ? DateTime.ParseExact(xpaydate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);


                int xyear = xpaydate1.Year;
                int xper = xpaydate1.Month;

                int payyrpr = xyear + xper;

                int xday = 1;

                if (xper == 1 || xper == 3 || xper == 5 || xper == 7 || xper == 8 || xper == 10 || xper == 12)
                {
                    xday = 31;
                }
                else if (xper == 01 || xper == 03 || xper == 05 || xper == 07 || xper == 08 || xper == 10 || xper == 12)
                {
                    xday = 31;
                }

                if (xper == 4 || xper == 6 || xper == 9 || xper == 11)
                {
                    xday = 30;
                }
                else if (xper == 04 || xper == 06 || xper == 09 || xper == 11)
                {
                    xday = 30;
                }

                if (xyear % 4 == 0)
                {
                    if (xper == 2)
                    {
                        xday = 29;
                    }
                    else if (xper == 02)
                    {
                        xday = 29;
                    }
                }
                else
                {
                    if (xper == 2)
                    {
                        xday = 28;
                    }
                    else if (xper == 02)
                    {
                        xday = 28;
                    }
                }

                DateTime lastday = new DateTime(xyear, xper, xday);

                if (lastday != xpaydate1)
                {
                    message.InnerHtml =
                        "<font color=red size=+1>Not a valid pay date ; Please Select Last Date of Month</font>";
                    //message.Style.Value = zglobal.warningmsg;
                    return;
                }

                string xempf = "0";
                string xempt = "zzz";

                if (xpaydate1.ToString("yyyy-MM-dd") == "2999-12-31")
                {
                    message.InnerHtml =
                        "<font color=red size=+1>Please check Date Carefully</font>";
                    //message.Style.Value = zglobal.warningmsg;
                    return;
                }

                string chk_fpay = zglobal.fnGetValue("xflags", "prpay",
                     "zid=" + _zid + " AND xpaydate='" + xpaydate1 + "' and xflags='1'");

                if (chk_fpay != "")
                {
                    message.InnerHtml = "<font color=red size=+1>Can't Process <br/>Final Payroll already Processed.</font>";
                    //message.Style.Value = zglobal.warningmsg;
                    return;
                }

                string absent_code = zglobal.fnGetValue("xprabsent", "prdef",
                     "zid=" + _zid + " AND xprabsentapp='Yes'");

                if (absent_code != "")
                {
                    string chkcode = zglobal.fnGetValue("xpaycode", "prpayhead",
                     "zid=" + _zid + " AND xpaycode='" + absent_code + "'");

                    if (chkcode == "")
                    {
                        message.InnerHtml = "<font color=red>Absent Deduction Code (" + absent_code + ") not found in Payment Head Table</font>";
                        //message.Style.Value = zglobal.warningmsg;
                        return;
                    }

                }

                string pf_code = zglobal.fnGetValue("xprpf", "prdef",
                    "zid=" + _zid + " AND xprpfapp='Yes'");

                if (pf_code != "")
                {
                    string chkcode = zglobal.fnGetValue("xpaycode", "prpayhead",
                     "zid=" + _zid + " AND xpaycode='" + pf_code + "'");

                    if (chkcode == "")
                    {
                        message.InnerHtml = "<font color=red>Absent Deduction Code (" + pf_code + ") not found in Payment Head Table</font>";
                        //message.Style.Value = zglobal.warningmsg;
                        return;
                    }

                }



                using (TransactionScope tran = new TransactionScope())
                {

                    string xptype = xptype_test.Checked == true ? xptype_test.Text : xptype_final.Text;

                    if (xptype == "Test Run")
                    {
                        string chk = zglobal.fnGetValue("xpaydate", "prpay",
                    "zid=" + _zid + " AND xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "'");

                        if (chk == "")
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                cmd.CommandTimeout = 0;

                                string query =
                                    "insert into prpay (ztime,zid,xpaydate,xremarks,zemail,xemail,xyear,xper,xyearq,xperend,xflags ) " +
                                    "values(@ztime,@zid,@xpaydate,@xremarks,@zemail,@xemail,@xyear,@xper,@xyearq,@xperend,@xflags)";

                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                                cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);
                                cmd.Parameters.AddWithValue("@xremarks", "");
                                cmd.Parameters.AddWithValue("@zemail",
                                    Convert.ToString(HttpContext.Current.Session["curuser"]));
                                cmd.Parameters.AddWithValue("@xemail", "");
                                cmd.Parameters.AddWithValue("@xyear", xyear);
                                cmd.Parameters.AddWithValue("@xper", xper);
                                cmd.Parameters.AddWithValue("@xyearq", xyear);
                                cmd.Parameters.AddWithValue("@xperend", xper);
                                cmd.Parameters.AddWithValue("@xflags", 0);

                                cmd.ExecuteNonQuery();

                            }

                        }

                        

                    }


                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "insert into prmsg (ztime,zid,xpaydate,xemp,xdayab,xdaylv,xratev,xgvothour,xnoothour,xadvflag,zemail,xemail,xdayspay,xpostflag,xdesig,xdept,xlocation) " +
                                "select '" + DateTime.Now + "'," + _zid + ",'" + xpaydate1.ToString("yyyy-MM-dd") + "',xemp,0,0,0,0,0,'Yes','" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "','',0,'',xdesig,xdept,xlocation " +
                                "from hrmst where zid=" + _zid + " and xstatusemp='A-Active' and xpaytyp='Monthly Rated' and " +
                                "xemp not in (select xemp from prmsg where zid=" + _zid + " and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "')";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);

                        cmd.ExecuteNonQuery();

                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "update prmsg set xdayspay=(case when (select month(xjoindate) from prmst where zid=prmsg.zid and xemp=prmsg.xemp)='" + xper + "' " +
                                "and (select year(xjoindate) from prmst where zid=prmsg.zid and xemp=prmsg.xemp)='" + xyear + "' then  " +
                                "(select day(xjoindate) from prmst where zid=prmsg.zid and xemp=prmsg.xemp)-1 " +
                                "else (select count(xdate) from cadate where zid=prmsg.zid and xyear='" + xyear + "' and xper='" + xper + "') end) " +
                                "where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "'";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }

                    int cnt_days = xpaydate1.Day;

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "update prmsg set xdayab=coalesce((select count(xdate) from pratd " +
                                "where zid=prmsg.zid and xyear=year(prmsg.xpaydate) " +
                                "and xper=month(prmsg.xpaydate) and xemp=prmsg.xemp and xatdstat='Absent'),0) " +
                                "+ ( " + cnt_days + "- coalesce((select count(xdate) from pratd " +
                                "where zid=prmsg.zid and xyear=year(prmsg.xpaydate) " +
                                "and xper=month(prmsg.xpaydate) and xemp=prmsg.xemp ),0)) " +
                                "where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "'";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }


                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            con.Open();
                            string query =

                            "SELECT xcode,xprops FROM mscodesam WHERE zid=@zid and xtype='In Out Penalty'";

                            SqlDataAdapter da = new SqlDataAdapter(query, con);
                            da.SelectCommand.CommandTimeout = 0;

                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);

                            DataTable tempTable = new DataTable();
                            da.Fill(dts, "tempTable");
                            tempTable = dts.Tables["tempTable"];

                            int i = 0;

                            while (i < tempTable.Rows.Count && tempTable.Rows.Count > 0)
                            {
                                string days_reduc = zglobal.fnProperty("In Out Penalty",
                                    tempTable.Rows[i]["xcode"].ToString(), "days_Penalty");

                                if (Convert.ToInt32(days_reduc) > 0)
                                {
                                    if (tempTable.Rows[i]["xcode"].ToString() == "Early Departure")
                                    {
                                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand();
                                            cmd.Connection = conn;
                                            cmd.CommandTimeout = 0;

                                            query =
                                                    "update prmsg set xdayab=xdayab+(select 0+count(xdate)/" + Convert.ToInt32(days_reduc) + " from pratd where zid=prmsg.zid " +
                                                    "and xyear=year(prmsg.xpaydate) and xper=month(prmsg.xpaydate) " +
                                                    "and xemp=prmsg.xemp and coalesce(xatdstato,'')='" + tempTable.Rows[i]["xcode"].ToString() + "' and coalesce(xatdstat,'')<>'Late') " +
                                                    "where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' ";

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                            cmd.ExecuteNonQuery();

                                        }
                                    }
                                    else
                                    {

                                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand();
                                            cmd.Connection = conn;
                                            cmd.CommandTimeout = 0;

                                            query =
                                                    "update prmsg set xdayab=xdayab+(select 0+count(xdate)/" + Convert.ToInt32(days_reduc) + " from pratd where zid=prmsg.zid " +
                                                    "and xyear=year(prmsg.xpaydate) and xper=month(prmsg.xpaydate) " +
                                                    "and xemp=prmsg.xemp and xatdstat='" + tempTable.Rows[i]["xcode"].ToString() + "') " +
                                                    "where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "'";

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                            cmd.ExecuteNonQuery();

                                        }

                                    }
                                }

                                i = i + 1;
                            }

                        }
                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "update prmsg set xnoothour=(select sum(xdayab) from provtime where zid=prmsg.zid and xyear=year(prmsg.xpaydate) and " +
                                "xper=month(prmsg.xpaydate) and xemp=prmsg.xemp) where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "'";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "update prmsg set xratev=(select max(xratev) from provtime where zid=prmsg.zid and xyear=year(prmsg.xpaydate) and xper=month(prmsg.xpaydate) " +
                                "and xemp=prmsg.xemp) where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "'";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "delete from practrndt where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "'";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "delete from prmsg where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' " +
                                "and xemp not in (select xemp from hrmst where zid='" + _zid + "' and xstatusemp='A-Active')";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "insert into practrndt (ztime,zid,xpaydate,xemp,xpaycode,xrow,xamount,zemail,xemail) " +
                                "select '" + DateTime.Now + "','" + _zid + "','" + xpaydate1.ToString("yyyy-MM-dd") + "',prmsg.xemp,prpayhead.xpaycode,10,0,'" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "','' " +
                                "from prmsg inner join prpayhead on prmsg.zid=prpayhead.zid where prmsg.zid='" + _zid + "' and prmsg.xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and prpayhead.xoption<>'Advance'";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }

                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            con.Open();
                            string query =

                                "SELECT xprsign,xoption,xpaycode FROM prpayhead WHERE zid=@zid order by xpaycode";

                            SqlDataAdapter da = new SqlDataAdapter(query, con);

                            da.SelectCommand.CommandTimeout = 0;

                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);

                            DataTable tempTable = new DataTable();
                            da.Fill(dts, "tempTable");
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {
                                foreach (DataRow row in tempTable.Rows)
                                {
                                    decimal actamt = 0;
                                    decimal payamt = 0;
                                    string xprsign = row["xprsign"].ToString();
                                    string xoption = row["xoption"].ToString();

                                    if (xprsign.StartsWith("3"))
                                    {
                                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand();
                                            cmd.Connection = conn;
                                            cmd.CommandTimeout = 0;

                                            query =
                                                    "update practrndt set xamount=(case when (select xamount from prtrndt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode and xpaydate=practrndt.xpaydate)>0 then " +
                                                    "coalesce((select xamount from prtrndt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode and xpaydate=practrndt.xpaydate),0) " +
                                                    "when (select xamount from prpaymentdt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode)>0 then " +
                                                    "coalesce((select xamount from prpaymentdt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode),0) " +
                                                    "when (select xpcode from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode)<>'' " +
                                                    "then coalesce(((select xamount from practrndt a where a.zid=practrndt.zid and a.xpaydate=practrndt.xpaydate " +
                                                    "and a.xemp=practrndt.xemp and a.xpaycode=(select xpcode from prpayheaddt where zid=a.zid and xpsclcode = " +
                                                    "(select xpsclcode from prmst where zid=a.zid and xemp=a.xemp) and xpaycode=practrndt.xpaycode)) * " +
                                                    "(select xpercent from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode)/100),0) " +
                                                    "when (select xamount from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode)>0 then " +
                                                    "coalesce((select xamount from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode),0) " +
                                                    "else coalesce((select sum(a.xamount) from practrndt a where a.zid=practrndt.zid and a.xemp=practrndt.xemp and a.xpaydate=practrndt.xpaydate and a.xpaycode<practrndt.xpaycode and (select xprsign from prpayhead where zid=a.zid and xpaycode=a.xpaycode)='1-Pay'),0) " +
                                                    "end) where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xpaycode='" + row["xpaycode"].ToString() + "'";

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                            cmd.ExecuteNonQuery();

                                        }
                                    }
                                    else if (xprsign.StartsWith("4"))
                                    {
                                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand();
                                            cmd.Connection = conn;
                                            cmd.CommandTimeout = 0;

                                            query =
                                                    "update practrndt set xamount=coalesce((select sum(a.xamount) from practrndt a where a.zid=practrndt.zid and a.xemp=practrndt.xemp and " +
                                                    "a.xpaydate=practrndt.xpaydate and a.xpaycode<practrndt.xpaycode and (select xprsign from prpayhead where zid=a.zid and xpaycode=a.xpaycode)='2-Deduct'),0) " +
                                                    "where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xpaycode='" + row["xpaycode"].ToString() + "'";

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                            cmd.ExecuteNonQuery();

                                        }

                                    }
                                    else if (xprsign.StartsWith("5"))
                                    {
                                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand();
                                            cmd.Connection = conn;
                                            cmd.CommandTimeout = 0;

                                            query =
                                                    "update practrndt set xamount=(coalesce((select sum(a.xamount) from practrndt a where a.zid=practrndt.zid and a.xemp=practrndt.xemp and a.xpaydate=practrndt.xpaydate and " +
                                                    "a.xpaycode<practrndt.xpaycode and (select xprsign from prpayhead where zid=a.zid and xpaycode=a.xpaycode)='1-Pay'),0) - " +
                                                    "coalesce((select sum(a.xamount) from practrndt a where a.zid=practrndt.zid and a.xemp=practrndt.xemp and a.xpaydate=practrndt.xpaydate and a.xpaycode<practrndt.xpaycode and (select xprsign from prpayhead where zid=a.zid and xpaycode=a.xpaycode)='2-Deduct'),0)) " +
                                                    "where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xpaycode='" + row["xpaycode"].ToString() + "'";

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                            cmd.ExecuteNonQuery();

                                        }

                                    }
                                    else
                                    {
                                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                        {
                                            conn.Open();
                                            SqlCommand cmd = new SqlCommand();
                                            cmd.Connection = conn;
                                            cmd.CommandTimeout = 0;

                                            query =
                                                    "update practrndt set xamount=(case when (select xamount from prtrndt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode and xpaydate=practrndt.xpaydate)>0 then " +
                                                    "coalesce((select xamount from prtrndt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode and xpaydate=practrndt.xpaydate),0) " +
                                                    "when (select xamount from prpaymentdt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode)>0 then " +
                                                    "coalesce((select xamount from prpaymentdt where zid=practrndt.zid and xemp=practrndt.xemp and xpaycode=practrndt.xpaycode),0) " +
                                                    "when (select xpcode from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode)<>'' " +
                                                    "then coalesce(((select xamount from practrndt a where a.zid=practrndt.zid and a.xpaydate=practrndt.xpaydate " +
                                                    "and a.xemp=practrndt.xemp and a.xpaycode=(select xpcode from prpayheaddt where zid=a.zid and xpsclcode = " +
                                                    "(select xpsclcode from prmst where zid=a.zid and xemp=a.xemp) and xpaycode=practrndt.xpaycode)) * " +
                                                    "(select xpercent from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode)/100),0) " +
                                                    "when (select xamount from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode)>0 then " +
                                                    "coalesce((select xamount from prpayheaddt where zid=practrndt.zid and xpsclcode=(select xpsclcode from prmst where zid=practrndt.zid and xemp=practrndt.xemp) and xpaycode=practrndt.xpaycode),0) " +
                                                    "else 0 end) where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xpaycode='" + row["xpaycode"].ToString() + "'";

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                            cmd.ExecuteNonQuery();

                                        }

                                        if (xoption == "Advance")
                                        {
                                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                            {
                                                conn.Open();
                                                SqlCommand cmd = new SqlCommand();
                                                cmd.Connection = conn;
                                                cmd.CommandTimeout = 0;

                                                query =
                                                        "insert into practrndt (ztime,zid,xpaydate,xemp,xpaycode,xrow,xamount,zemail,xemail) " +
                                                        "select '" + DateTime.Now + "','" + _zid + "','" + xpaydate1.ToString("yyyy-MM-dd") + "',prloanview.xemp,prloanview.xpaycode,prloanview.xrow,case when xprrate < (xadvance-xreturn-xpayamt) then xprrate else  (xadvance-xreturn-xpayamt) end,'" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "','' " +
                                                        "from prloanview where prloanview.zid='" + _zid + "' and prloanview.xpaycode='" + row["xpaycode"] + "' and (xadvance-xreturn-xpayamt)>0 and prloanview.xpaydate<='" + xpaydate1.ToString("yyyy-MM-dd") + "' and " +
                                                        "prloanview.xemp in (select xemp from prmsg where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xadvflag='Yes')";

                                                cmd.Parameters.Clear();

                                                cmd.CommandText = query;
                                                cmd.Parameters.AddWithValue("@zid", _zid);
                                                cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                                cmd.ExecuteNonQuery();

                                            }
                                        }

                                        if (row["xpaycode"].ToString() == absent_code)
                                        {
                                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                            {
                                                conn.Open();
                                                SqlCommand cmd = new SqlCommand();
                                                cmd.Connection = conn;
                                                cmd.CommandTimeout = 0;

                                                query =
                                                        "update practrndt set xamount=xamount*(select sum(xdayspay+xdayab) from prmsg where zid=practrndt.zid and xemp=practrndt.xemp and xpaydate=practrndt.xpaydate)/" +
                                                        "(select count(xdate) from cadate where zid=practrndt.zid and xyear='" + xyear + "' and xper='" + xper + "') " +
                                                        "where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xpaycode='" + row["xpaycode"] + "'";

                                                cmd.Parameters.Clear();

                                                cmd.CommandText = query;
                                                cmd.Parameters.AddWithValue("@zid", _zid);
                                                cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                                cmd.ExecuteNonQuery();

                                            }
                                        }

                                        if (row["xpaycode"].ToString() == pf_code)
                                        {
                                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                            {
                                                conn.Open();
                                                SqlCommand cmd = new SqlCommand();
                                                cmd.Connection = conn;
                                                cmd.CommandTimeout = 0;

                                                query =
                                                        "update practrndt set xamount=0 where zid='" + _zid + "' and xpaycode='" + row["xpaycode"] + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' " +
                                                        "and (select xpfflag from hrmst where zid=practrndt.zid and xemp=practrndt.xemp)<>'Yes'";

                                                cmd.Parameters.Clear();

                                                cmd.CommandText = query;
                                                cmd.Parameters.AddWithValue("@zid", _zid);
                                                cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                                cmd.ExecuteNonQuery();

                                            }
                                        }


                                    }


                                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                    {
                                        conn.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.Connection = conn;
                                        cmd.CommandTimeout = 0;

                                        query =
                                                "update practrndt set xamount=ROUND(xamount,0) where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xpaycode='" + row["xpaycode"] + "' ";

                                        cmd.Parameters.Clear();

                                        cmd.CommandText = query;
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                                        cmd.ExecuteNonQuery();

                                    }


                                }


                            }


                        }
                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;

                        string query =
                                "delete from practrndt where zid='" + _zid + "' and xpaydate='" + xpaydate1.ToString("yyyy-MM-dd") + "' and xamount=0";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                        cmd.ExecuteNonQuery();

                    }





                    if (xptype == "Final Run")
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;

                            string query =
                                    "UPDATE prpay " +
                                    "SET xflags='1' " +
                                    "WHERE zid=@zid AND xpaydate=@xpaydate ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);

                            cmd.ExecuteNonQuery();

                        }
                    }



                    tran.Complete();

                }

                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                // btnRefresh_Click(null, null);
                //message.InnerHtml = zglobal.savesuccmsg;
                //message.Style.Value = zglobal.successmsg;
                //ViewState["xrow"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";

                //BindGrid();
                //xrow1.Text = ViewState["xrow"].ToString();
                //xsup.Text = ViewState["xsup"].ToString();
                //fnButtonState();
                //fnFillGrid2();

                if (xptype_test.Checked)
                {
                    message.InnerHtml = "<font color=blue size=4>Trial Run Payroll Processing Completed</font>";
                }
                else
                {
                    message.InnerHtml = "<font color=blue size=4>Final Run Payroll Processing Completed</font>";
                }



            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        //private void ot_calc2()
        //{
        //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
        //    DateTime xdate1 = xdate.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //    using (SqlConnection con = new SqlConnection(zglobal.constring))
        //    {
        //        using (DataSet dts = new DataSet())
        //        {
        //            con.Open();
        //            string query =
        //                "SELECT xemp,xshift,xstddttimin,xdttimin,xatdstat,xdttimout,dtfrom " +
        //                "FROM pratdvw " +
        //                "WHERE zid=@zid AND xdate=@xdate and (xatdstat='Holiday' or xatdstat='Late' or xatdstat='Present') and xhoursest>57600 and xflags='P' " +
        //                "ORDER BY xemp";

        //            SqlDataAdapter da = new SqlDataAdapter(query, con);

        //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
        //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

        //            DataTable tempTable = new DataTable();
        //            da.Fill(dts, "tempTable");
        //            tempTable = dts.Tables["tempTable"];

        //            string empid = "";
        //            string minus_in = "";
        //            string minus_out = "";
        //            int minus_tot = 0;
        //            int i = 0;

        //            if (tempTable.Rows.Count > 0)
        //            {
        //                //START 1ST WHILE LOOP
        //                #region f_w_loop
        //                while (i < tempTable.Rows.Count && tempTable.Rows.Count > 0)
        //                {
        //                    string in_flag = "";
        //                    string out_flag = "";
        //                    string in_t = "";
        //                    string out_t = "";
        //                    int totsec = 0;
        //                    int cursec = 0;
        //                    int tot_intime = 0;
        //                    int tot_outtime = 0;
        //                    string inout_flag = "";

        //                    int mysql = zglobal.fnGetValueInt("count(*)", "pratdummy_t",
        //              "zid=" + _zid + "xdatetime>='" + tempTable.Rows[i]["xdttimin"] + "' and xdatetime<='" + tempTable.Rows[i]["xdttimout"] + "' and xemp='" + tempTable.Rows[i]["xemp"] + "' and xstatusjv='1'");
        //                    tot_intime = mysql;

        //                    mysql = zglobal.fnGetValueInt("count(*)", "pratdummy_t",
        //              "zid=" + _zid + "xdatetime>='" + tempTable.Rows[i]["xdttimin"] + "' and xdatetime<='" + tempTable.Rows[i]["xdttimout"] + "' and xemp='" + tempTable.Rows[i]["xemp"] + "' and xstatusjv='0'");
        //                    tot_outtime = mysql;

        //                    if (tot_intime != tot_outtime)
        //                    {
        //                        inout_flag = "1";
        //                    }

        //                    query =
        //                "SELECT xdatetime,xstatusjv " +
        //                "FROM pratdummy_t " +
        //                "WHERE zid=" + _zid + "xdatetime>='" + tempTable.Rows[i]["xdttimin"] + "' and xdatetime<='" + tempTable.Rows[i]["xdttimout"] + "' and xemp='" + tempTable.Rows[i]["xemp"] + "' " +
        //                "ORDER BY xdatetime,xstatusjv desc ";

        //                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

        //                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
        //                    da1.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


        //                    DataTable tempTable1 = new DataTable();
        //                    da1.Fill(dts, "tempTable1");
        //                    tempTable1 = dts.Tables["tempTable1"];

        //                    int kk = 0;
        //                    string kk_flag = "";

        //                    //START 2ND WHILE LOOP
        //                    #region s_w_loop
        //                    while (kk < tempTable1.Rows.Count && tempTable1.Rows.Count > 0 && kk_flag == "")
        //                    {
        //                        if (kk == 0)
        //                        {
        //                            if (tempTable1.Rows[kk]["xstatusjv"].ToString() != "1")
        //                            {
        //                                kk_flag = "1";
        //                            }
        //                        }

        //                        if (kk == tempTable1.Rows.Count-1)
        //                        {
        //                            if (tempTable1.Rows[kk]["xstatusjv"].ToString() != "0")
        //                            {
        //                                kk_flag = "1";
        //                            }
        //                        }

        //                        if (kk == 0 || kk == tempTable1.Rows.Count - 1)
        //                        {

        //                        }
        //                        else
        //                        {
        //                            int in_out_mod = 0 + kk%2;
        //                            if (in_out_mod == 1)
        //                            {
        //                                if (tempTable1.Rows[kk]["xstatusjv"].ToString() != "0")
        //                                {
        //                                    kk_flag = "1";
        //                                }
        //                            }

        //                            if (in_out_mod == 0)
        //                            {
        //                                if (tempTable1.Rows[kk]["xstatusjv"].ToString() != "1")
        //                                {
        //                                    kk_flag = "1";
        //                                }
        //                            }

        //                        }

        //                        kk = 0 + kk + 1;
        //                    }
        //                    #endregion s_w_loop
        //                    //END 2ND WHILE LOOP

        //                    if (kk_flag != "1")
        //                    {
        //                        inout_flag = "1";
        //                    }
        //                    int j = 0;
        //                    int k = 0;


        //                    //START 3RD WHILE LOOP
        //                    #region t_w_loop
        //                    while (j < tempTable1.Rows.Count && tempTable1.Rows.Count > 0 && inout_flag == "")
        //                    {
        //                        k = 0;
        //                        if (in_flag == "" && tempTable1.Rows[j]["xstatusjv"].ToString() == "1")
        //                        {
        //                            in_flag = "1";
        //                            in_t = tempTable1.Rows[j]["xdatetime"].ToString();
        //                            k = 0 + j + 1;

        //                            if (tempTable1.Rows[k]["xstatusjv"].ToString() == "1")
        //                            {
        //                                in_flag = "1";
        //                                in_t = tempTable1.Rows[k]["xdatetime"].ToString();
        //                            }
        //                        }

        //                        k = 0;

        //                        if (out_flag == "" && tempTable1.Rows[j]["xstatusjv"].ToString() == "0")
        //                        {
        //                            out_flag = "1";
        //                            out_t = tempTable1.Rows[j]["xdatetime"].ToString();
        //                            k = 0 + j + 1;

        //                            if (k != tempTable1.Rows.Count)
        //                            {
        //                                if (tempTable1.Rows[k]["xstatusjv"].ToString() == "0")
        //                                {
        //                                    out_flag = "";
        //                                    out_t = "";
        //                                }
        //                            }

        //                        }

        //                        cursec = 0;

        //                        if (in_flag == "1" && out_flag == "1")
        //                        {
        //                            //cursec = zglobal.fnGetValueInt("DATEDIFF(SECOND, '" + in_t + "','" + out_t + "')", "mscus", "zid=" + _zid );
        //                            cursec = zglobal.ReturnIntValue("SELECT DATEDIFF(SECOND, '" + in_t + "','" + out_t + "')");
        //                            totsec = 0 + totsec + cursec;
        //                            in_flag = "";
        //                            out_flag = "";
        //                            in_t = "";
        //                            out_t = "";
        //                        }

        //                        j = 0 + j + 1;
        //                    }
        //                    #endregion t_w_loop
        //                    //END 3RD WHILE LOOP

        //                    string paytyp = zglobal.fnGetValue("xpaytyp", "prmst", "zid=" + _zid + " and xemp='" + tempTable.Rows[i]["xemp"].ToString() + "'");

        //                    if (tempTable.Rows[i]["xatdstat"].ToString() == "Holiday" ||
        //                        tempTable.Rows[i]["xshift"].ToString().StartsWith("Casual") ||
        //                        tempTable.Rows[i]["paytyp"].ToString().StartsWith("Hourly Rated"))
        //                    {
        //                        totsec = 0 + totsec + 900; //***900secound add for consideration
        //                    }
        //                    else
        //                    {
        //                        minus_in = tempTable.Rows[i]["xdttimin"].ToString();
        //                        minus_out = zglobal.fnGetValue("dtfrom", "pratdvw",
        //                                    "zid=" + _zid + "xemp='" + tempTable.Rows[i]["xemp"] + "' and xdate='" + xdate1 + "'");

        //                        //mysql = zglobal.fnGetValueInt("DATEDIFF(SECOND, '" + minus_in + "','" + minus_out + "')", "mscus", "zid=" + _zid);
        //                        mysql = zglobal.ReturnIntValue("DATEDIFF(SECOND, '" + minus_in + "','" + minus_out + "')");
        //                        minus_tot = 0 + mysql;

        //                        totsec = 0 + totsec + 900 - minus_tot;

        //                        if (tempTable.Rows[i]["xshift"].ToString() == "Casual Shift(General)")
        //                        {
        //                            totsec = 0 + totsec - 3600;
        //                        }

        //                    }

        //                    if (inout_flag == "1")
        //                    {
        //                        totsec = 0;
        //                    }

        //                    if (totsec > 0)
        //                    {
        //                        totsec = 0 + totsec/3600;
        //                        if (totsec > 24)
        //                        {
        //                            totsec = 0 + 24;
        //                        }

        //                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                        {
        //                            conn.Open();
        //                            SqlCommand cmd = new SqlCommand();
        //                            cmd.Connection = conn;
        //                            cmd.CommandTimeout = 0;

        //                            query =
        //                                    "UPDATE pratd " +
        //                                    "SET xhoursact='" + totsec + "' " +
        //                                    "WHERE zid=@zid AND xemp=@xemp and xdate=@xdate ";

        //                            cmd.Parameters.Clear();

        //                            cmd.CommandText = query;
        //                            cmd.Parameters.AddWithValue("@zid", _zid);
        //                            cmd.Parameters.AddWithValue("@xemp", tempTable.Rows[i]["xemp"].ToString());
        //                            cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                            cmd.ExecuteNonQuery();

        //                        }

        //                    }
        //                    else
        //                    {
        //                        string ot_hour = "-01";

        //                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                        {
        //                            conn.Open();
        //                            SqlCommand cmd = new SqlCommand();
        //                            cmd.Connection = conn;
        //                            cmd.CommandTimeout = 0;

        //                            query =
        //                                    "UPDATE pratd " +
        //                                    "SET xhoursact='" + ot_hour + "' " +
        //                                    "WHERE zid=@zid AND xemp=@xemp and xdate=@xdate ";

        //                            cmd.Parameters.Clear();

        //                            cmd.CommandText = query;
        //                            cmd.Parameters.AddWithValue("@zid", _zid);
        //                            cmd.Parameters.AddWithValue("@xemp", tempTable.Rows[i]["xemp"].ToString());
        //                            cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                            cmd.ExecuteNonQuery();

        //                        }
        //                    }

        //                    i = 0 + i + 1;
        //                }
        //                #endregion f_w_loop
        //                //END 1ST WHILE LOOP
        //            }
        //        }
        //    }
        //}

        //private void out_calc()
        //{
        //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
        //    DateTime xdate1 = xdate.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //    string out_sta = zglobal.fnGetValue("xleasestat", "prdef", "zid=" + _zid );

        //    using (SqlConnection con = new SqlConnection(zglobal.constring))
        //    {
        //        using (DataSet dts = new DataSet())
        //        {
        //            con.Open();
        //            string query =
        //                "SELECT xshift FROM pratdt WHERE zid=@zid AND xstatus='Approved' and xdate<=@xdate group by xshift";

        //            SqlDataAdapter da = new SqlDataAdapter(query, con);

        //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
        //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

        //            DataTable tempTable = new DataTable();
        //            da.Fill(dts, "tempTable");
        //            tempTable = dts.Tables["tempTable"];

        //            int i = 0;
        //            if (tempTable.Rows.Count > 0)
        //            {
        //                while (i < tempTable.Rows.Count && tempTable.Rows.Count > 0)
        //                {
        //                    string mysql = zglobal.fnGetValue("max(xdate)", "pratdt", "zid=" + _zid + " and xstatus='Approved' and xshift='" + tempTable.Rows[i]["xshift"].ToString() + "' and xdate<='" + xdate1 + "'");
        //                    DateTime dt = Convert.ToDateTime(mysql);

        //                    string lotime = zglobal.fnGetValue("xlotime", "pratdt", "zid=" + _zid + " and xstatus='Approved' and xshift='" + tempTable.Rows[i]["xshift"].ToString() + "' and xdate='" + dt + "'");
        //                    int xrowauth = 0 + zglobal.fnGetValueInt("xrowauth", "pratdt", "zid=" + _zid + " and xstatus='Approved' and xshift='" + tempTable.Rows[i]["xshift"].ToString() + "' and xdate='" + dt + "'");
        //                    int out_del_tim = 0 + zglobal.fnGetValueInt("xrowprob", "pratdt", "zid=" + _zid + " and xstatus='Approved' and xshift='" + tempTable.Rows[i]["xshift"].ToString() + "' and xdate='" + dt + "'");
        //                    out_del_tim = 0 - out_del_tim;
        //                    string str01 = zglobal.fnGetValue("xstr01", "pratdt", "zid=" + _zid + " and xstatus='Approved' and xshift='" + tempTable.Rows[i]["xshift"].ToString() + "' and xdate='" + dt + "'");
        //                    string cdateNam = zglobal.fnGetValue("xname", "cadatevw", "zid=" + _zid + " and xdate='" + xdate1 + "'");
        //                    string std_in_dttm = xdate1.ToString("yyyy-MM-dd") + " " + lotime;

        //                    if (str01 == "" || cdateNam != str01)
        //                    {
        //                        xrowauth = 0 +
        //                                   60*
        //                                   zglobal.fnGetValueInt("xnum", "pratdt",
        //                                       "zid=" + _zid + " and xstatus='Approved' and xshift='" +
        //                                       tempTable.Rows[i]["xshift"].ToString() + "' and xdate='" + dt + "'");
        //                    }

        //                    //int mysql1 = zglobal.fnGetValueInt("dateadd(minute, '" + xrowauth + "','" + std_in_dttm + "')", "mscus", "zid=" + _zid);
        //                    string mysql1 = zglobal.ReturnStringValue("select dateadd(minute, " + xrowauth + ",'" + std_in_dttm + "')");
        //                    string std_out_tim = mysql1;

        //                    if (str01 != "" && cdateNam == str01)
        //                    {
        //                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                        {
        //                            conn.Open();
        //                            SqlCommand cmd = new SqlCommand();
        //                            cmd.Connection = conn;
        //                            cmd.CommandTimeout = 0;

        //                            query =
        //                                    "UPDATE pratd " +
        //                                    "SET xdatefrom='"+std_out_tim+"' "+
        //                                    "WHERE zid=@zid AND xshift=@xshift and xdate=@xdate and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0";

        //                            cmd.Parameters.Clear();

        //                            cmd.CommandText = query;
        //                            cmd.Parameters.AddWithValue("@zid", _zid);
        //                            cmd.Parameters.AddWithValue("@xshift", tempTable.Rows[i]["xshift"].ToString());
        //                            cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                            cmd.ExecuteNonQuery();

        //                        }
        //                    }

        //                    if (out_sta.ToString().StartsWith("1-Y"))
        //                    {
        //                        if (DateTime.Now.Date == xdate1.Date)
        //                        {
        //                            if (DateTime.Now.Minute < Convert.ToDateTime(std_out_tim).Minute)
        //                            {

        //                            }
        //                            else
        //                            {
        //                                using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                                {
        //                                    conn.Open();
        //                                    SqlCommand cmd = new SqlCommand();
        //                                    cmd.Connection = conn;
        //                                    cmd.CommandTimeout = 0;

        //                                    query =
        //                                            "UPDATE pratd " +
        //                                            "SET xatdstat='Absent' " +
        //                                            "WHERE zid=@zid AND xshift=@xshift and xdate=@xdate " +
        //                                            "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                            "and dateadd(minute," + out_del_tim + ",xdatefrom)>xouttime";

        //                                    cmd.Parameters.Clear();

        //                                    cmd.CommandText = query;
        //                                    cmd.Parameters.AddWithValue("@zid", _zid);
        //                                    cmd.Parameters.AddWithValue("@xshift", tempTable.Rows[i]["xshift"].ToString());
        //                                    cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                    cmd.ExecuteNonQuery();

        //                                }

        //                                using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                                {
        //                                    conn.Open();
        //                                    SqlCommand cmd = new SqlCommand();
        //                                    cmd.Connection = conn;
        //                                    cmd.CommandTimeout = 0;

        //                                    query =
        //                                            "UPDATE pratd " +
        //                                            "SET xatdstato='Early Departure' " +
        //                                            "WHERE zid=@zid AND xshift=@xshift and xdate=@xdate " +
        //                                            "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                            "and dateadd(minute," + out_del_tim + ",xdatefrom)<=xouttime and xdatefrom>xouttime";

        //                                    cmd.Parameters.Clear();

        //                                    cmd.CommandText = query;
        //                                    cmd.Parameters.AddWithValue("@zid", _zid);
        //                                    cmd.Parameters.AddWithValue("@xshift", tempTable.Rows[i]["xshift"].ToString());
        //                                    cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                    cmd.ExecuteNonQuery();

        //                                } 
        //                            }
        //                        }
        //                        else
        //                        {
        //                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                            {
        //                                conn.Open();
        //                                SqlCommand cmd = new SqlCommand();
        //                                cmd.Connection = conn;
        //                                cmd.CommandTimeout = 0;

        //                                query =
        //                                        "UPDATE pratd " +
        //                                        "SET xatdstat='Absent' " +
        //                                        "WHERE zid=@zid AND xshift=@xshift and xdate=@xdate " +
        //                                        "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                        "and dateadd(minute," + out_del_tim + ",xdatefrom)>xouttime";

        //                                cmd.Parameters.Clear();

        //                                cmd.CommandText = query;
        //                                cmd.Parameters.AddWithValue("@zid", _zid);
        //                                cmd.Parameters.AddWithValue("@xshift", tempTable.Rows[i]["xshift"].ToString());
        //                                cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                cmd.ExecuteNonQuery();

        //                            }

        //                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                            {
        //                                conn.Open();
        //                                SqlCommand cmd = new SqlCommand();
        //                                cmd.Connection = conn;
        //                                cmd.CommandTimeout = 0;

        //                                query =
        //                                        "UPDATE pratd " +
        //                                        "SET xatdstato='Early Departure' " +
        //                                        "WHERE zid=@zid AND xshift=@xshift and xdate=@xdate " +
        //                                        "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                        "and dateadd(minute," + out_del_tim + ",xdatefrom)<=xouttime and xdatefrom>xouttime";

        //                                cmd.Parameters.Clear();

        //                                cmd.CommandText = query;
        //                                cmd.Parameters.AddWithValue("@zid", _zid);
        //                                cmd.Parameters.AddWithValue("@xshift", tempTable.Rows[i]["xshift"].ToString());
        //                                cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                cmd.ExecuteNonQuery();

        //                            } 
        //                        }
        //                    }

        //                    i = 0 + i + 1;
        //                }




        //            }
        //        }
        //    }


        //    using (SqlConnection con = new SqlConnection(zglobal.constring))
        //    {
        //        using (DataSet dts = new DataSet())
        //        {
        //            con.Open();
        //            string query =
        //                "SELECT xemp FROM pratdtemp WHERE zid=@zid AND xstatus='Approved' and xdate<=@xdate group by xemp order by xemp";

        //            SqlDataAdapter da = new SqlDataAdapter(query, con);

        //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
        //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

        //            DataTable tempTable = new DataTable();
        //            da.Fill(dts, "tempTable");
        //            tempTable = dts.Tables["tempTable"];

        //            int i = 0;
        //            if (tempTable.Rows.Count > 0)
        //            {
        //                while (i < tempTable.Rows.Count && tempTable.Rows.Count > 0)
        //                {
        //                    string mysql = zglobal.fnGetValue("max(xdate)", "pratdtemp", "zid=" + _zid + " and xstatus='Approved' and xemp='" + tempTable.Rows[i]["xemp"].ToString() + "' and xdate<='" + xdate1 + "'");
        //                    DateTime dt = Convert.ToDateTime(mysql);

        //                    string lotime = zglobal.fnGetValue("xlotime", "pratdtemp", "zid=" + _zid + " and xstatus='Approved' and xemp='" + tempTable.Rows[i]["xemp"].ToString() + "' and xdate='" + dt + "'");
        //                    int xrowauth = 0 + zglobal.fnGetValueInt("xrowauth", "pratdtemp", "zid=" + _zid + " and xstatus='Approved' and xemp='" + tempTable.Rows[i]["xemp"].ToString() + "' and xdate='" + dt + "'");
        //                    int out_del_tim = 0 + zglobal.fnGetValueInt("xrowprob", "pratdtemp", "zid=" + _zid + " and xstatus='Approved' and xemp='" + tempTable.Rows[i]["xemp"].ToString() + "' and xdate='" + dt + "'");
        //                    out_del_tim = 0 - out_del_tim;
        //                    string str01 = zglobal.fnGetValue("xstr01", "pratdtemp", "zid=" + _zid + " and xstatus='Approved' and xemp='" + tempTable.Rows[i]["xemp"].ToString() + "' and xdate='" + dt + "'");
        //                    string cdateNam = zglobal.fnGetValue("xname", "cadatevw", "zid=" + _zid + " and xdate='" + xdate1 + "'");
        //                    string std_in_dttm = xdate1.ToString("yyyy-MM-dd") + " " + lotime;

        //                    if (str01 == "" || cdateNam != str01)
        //                    {
        //                        xrowauth = 0 +
        //                                   60 *
        //                                   zglobal.fnGetValueInt("xnum", "pratdtemp",
        //                                       "zid=" + _zid + " and xstatus='Approved' and xemp='" +
        //                                       tempTable.Rows[i]["xemp"].ToString() + "' and xdate='" + dt + "'");
        //                    }

        //                    //int mysql1 = zglobal.fnGetValueInt("dateadd(minute, '" + xrowauth + "','" + std_in_dttm + "')", "mscus", "zid=" + _zid);
        //                    string mysql1 = zglobal.ReturnStringValue("select dateadd(minute, " + xrowauth + ",'" + std_in_dttm + "')");
        //                    string std_out_tim = mysql1;

        //                    if (str01 != "" && cdateNam == str01)
        //                    {
        //                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                        {
        //                            conn.Open();
        //                            SqlCommand cmd = new SqlCommand();
        //                            cmd.Connection = conn;
        //                            cmd.CommandTimeout = 0;

        //                            query =
        //                                    "UPDATE pratd " +
        //                                    "SET xdatefrom='" + std_out_tim + "' " +
        //                                    "WHERE zid=@zid AND xemp=@xemp and xdate=@xdate and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0";

        //                            cmd.Parameters.Clear();

        //                            cmd.CommandText = query;
        //                            cmd.Parameters.AddWithValue("@zid", _zid);
        //                            cmd.Parameters.AddWithValue("@xemp", tempTable.Rows[i]["xemp"].ToString());
        //                            cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                            cmd.ExecuteNonQuery();

        //                        }
        //                    }

        //                    if (out_sta.ToString().StartsWith("1-Y"))
        //                    {
        //                        if (DateTime.Now.Date == xdate1.Date)
        //                        {
        //                            if (DateTime.Now.Minute < Convert.ToDateTime(std_out_tim).Minute)
        //                            {

        //                            }
        //                            else
        //                            {
        //                                using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                                {
        //                                    conn.Open();
        //                                    SqlCommand cmd = new SqlCommand();
        //                                    cmd.Connection = conn;
        //                                    cmd.CommandTimeout = 0;

        //                                    query =
        //                                            "UPDATE pratd " +
        //                                            "SET xatdstat='Absent' " +
        //                                            "WHERE zid=@zid AND xemp=@xemp and xdate=@xdate " +
        //                                            "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                            "and dateadd(minute," + out_del_tim + ",xdatefrom)>xouttime";

        //                                    cmd.Parameters.Clear();

        //                                    cmd.CommandText = query;
        //                                    cmd.Parameters.AddWithValue("@zid", _zid);
        //                                    cmd.Parameters.AddWithValue("@xemp", tempTable.Rows[i]["xemp"].ToString());
        //                                    cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                    cmd.ExecuteNonQuery();

        //                                }

        //                                using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                                {
        //                                    conn.Open();
        //                                    SqlCommand cmd = new SqlCommand();
        //                                    cmd.Connection = conn;
        //                                    cmd.CommandTimeout = 0;

        //                                    query =
        //                                            "UPDATE pratd " +
        //                                            "SET xatdstato='Early Departure' " +
        //                                            "WHERE zid=@zid AND xemp=@xemp and xdate=@xdate " +
        //                                            "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                            "and dateadd(minute," + out_del_tim + ",xdatefrom)<=xouttime and xdatefrom>xouttime";

        //                                    cmd.Parameters.Clear();

        //                                    cmd.CommandText = query;
        //                                    cmd.Parameters.AddWithValue("@zid", _zid);
        //                                    cmd.Parameters.AddWithValue("@xemp", tempTable.Rows[i]["xemp"].ToString());
        //                                    cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                    cmd.ExecuteNonQuery();

        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                            {
        //                                conn.Open();
        //                                SqlCommand cmd = new SqlCommand();
        //                                cmd.Connection = conn;
        //                                cmd.CommandTimeout = 0;

        //                                query =
        //                                        "UPDATE pratd " +
        //                                        "SET xatdstat='Absent' " +
        //                                        "WHERE zid=@zid AND xemp=@xemp and xdate=@xdate " +
        //                                        "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                        "and dateadd(minute," + out_del_tim + ",xdatefrom)>xouttime";

        //                                cmd.Parameters.Clear();

        //                                cmd.CommandText = query;
        //                                cmd.Parameters.AddWithValue("@zid", _zid);
        //                                cmd.Parameters.AddWithValue("@xemp", tempTable.Rows[i]["xemp"].ToString());
        //                                cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                cmd.ExecuteNonQuery();

        //                            }

        //                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //                            {
        //                                conn.Open();
        //                                SqlCommand cmd = new SqlCommand();
        //                                cmd.Connection = conn;
        //                                cmd.CommandTimeout = 0;

        //                                query =
        //                                        "UPDATE pratd " +
        //                                        "SET xatdstato='Early Departure' " +
        //                                        "WHERE zid=@zid AND xemp=@xemp and xdate=@xdate " +
        //                                        "and (select count(*) from pratdtemp where zid=pratd.zid and xemp=pratd.xemp)=0 and (xatdstat='Late' or xatdstat='Present') " +
        //                                        "and dateadd(minute," + out_del_tim + ",xdatefrom)<=xouttime and xdatefrom>xouttime";

        //                                cmd.Parameters.Clear();

        //                                cmd.CommandText = query;
        //                                cmd.Parameters.AddWithValue("@zid", _zid);
        //                                cmd.Parameters.AddWithValue("@xemp", tempTable.Rows[i]["xemp"].ToString());
        //                                cmd.Parameters.AddWithValue("@xdate", xdate1);

        //                                cmd.ExecuteNonQuery();

        //                            }
        //                        }
        //                    }

        //                    i = 0 + i + 1;
        //                }




        //            }


        //        }
        //    }


        //}

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
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        con.Open();
            //        string query =
            //             "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xdate,xshift,xremark,xstatus " +
            //           "FROM prholiday WHERE zid=@zid " +
            //           "order by xdate,xshift ";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



            //        DataTable tempTable = new DataTable();
            //        da1.Fill(dts1, "tempTable");
            //        tempTable = dts1.Tables["tempTable"];

            //        if (tempTable.Rows.Count > 0)
            //        {
            //            // btnShowList.Visible = true;
            //            //pnllistct.Visible = true;
            //            dgvcollectionew.DataSource = tempTable;
            //            dgvcollectionew.DataBind();
            //        }
            //        //else
            //        //{
            //        //    // btnShowList.Visible = false;
            //        //    pnllistct.Visible = false;
            //        //    GridView2.DataSource = null;
            //        //    GridView2.DataBind();
            //        //}


            //    }
            //}


            ////using (SqlConnection con = new SqlConnection(zglobal.constring))
            ////{
            ////    using (DataSet dts1 = new DataSet())
            ////    {
            ////        con.Open();
            ////        //string query =
            ////        //     "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession, " +
            ////        //      "(select xname from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xname, " +
            ////        //     "(select xstdid from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xstdid, " +
            ////        //     "(select xclass from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xclass, " +
            ////        //     "(select xgroup from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xgroup, " +
            ////        //     "(select xsection from amstudentvw where zid=amdropout.zid and xsession=amdropout.xsession and xrow=amdropout.xsrow) as xsection, " +
            ////        //     "xtype, xreason, xstatus, xdate " +
            ////        //     "FROM amdropout WHERE zid=@zid AND xstatus='Approved' order by xrow desc";

            ////        string query =
            ////           "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xshift," +
            ////           "xdate,xdayab,xlotime,xintime,xpnlttime,xinc,xouttime,xnum,xstr01,xrowauth,xrowappt,xrowprob,xmrgntime," +
            ////           "xqtycount,xremark,xstatus,xatdstat,xscore " +
            ////           "FROM pratdt WHERE zid=@zid  " +
            ////           "order by xshift,xdate desc";

            ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



            ////        DataTable tempTable = new DataTable();
            ////        da1.Fill(dts1, "tempTable");
            ////        tempTable = dts1.Tables["tempTable"];

            ////        if (tempTable.Rows.Count > 0)
            ////        {
            ////            // btnShowList.Visible = true;
            ////            //pnllistct.Visible = true;
            ////            dgvcollectionpaid.DataSource = tempTable;
            ////            dgvcollectionpaid.DataBind();
            ////        }
            ////        //else
            ////        //{
            ////        //    // btnShowList.Visible = false;
            ////        //    pnllistct.Visible = false;
            ////        //    GridView2.DataSource = null;
            ////        //    GridView2.DataBind();
            ////        //}


            ////    }
            ////}

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
            try
            {
                xcdate.Text = "";
                //SetInitialRow();
                hxclass.Value = xclass.Text.Trim().ToString();
                message.InnerHtml = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                ViewState["xrow"] = null;
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
            //    LinkButton btn = (LinkButton)sender;
            //    GridViewRow row = (GridViewRow)btn.NamingContainer;
            //    DateTime xdate1 = DateTime.ParseExact(btn.Text, "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture);
            //    string xshift1 = row.Cells[1].Text.ToString().Trim();

            //    fnFillControl(xshift1,xdate1);

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void FillControl2(object sender, EventArgs e)
        {
            //try
            //{
            //    //message.InnerHtml = "Hi";
            //    if (xsup.Text.Trim().ToString() != String.Empty)
            //    {
            //        fnFillControl(xsup.Text.Trim().ToString());
            //    }
            //    else
            //    {
            //        message.InnerHtml = "Enter supplier code.";
            //        message.Style.Value = zglobal.am_warningmsg;
            //        xrow1.Focus();
            //    }

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        private void fnFillControl(string xsup1, DateTime xdate1)
        {
            //message.InnerHtml = "";

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();


            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //string str = "SELECT  * " +
            //             "FROM prholiday where zid=@zid  and xshift=@xshift and xdate=@xdate ";




            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@xshift", xsup1);
            //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            //da.Fill(dts, "tempztcode");
            //DataTable dttemp = new DataTable();
            //dttemp = dts.Tables[0];

            //if (dttemp.Rows.Count <= 0)
            //{
            //    message.InnerHtml = "Wrong shift code.";
            //    message.Style.Value = zglobal.am_warningmsg;
            //    return;
            //}

            //ViewState["xsup"] = xsup1.ToString();
            ////hiddenxrow.Value = ViewState["xrow"].ToString();

            //xshift.Text = dttemp.Rows[0]["xshift"].ToString();
            //xdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
            ////xlotime.Text = dttemp.Rows[0]["xlotime"].ToString();
            ////xintime.Text = dttemp.Rows[0]["xintime"].ToString();
            ////xpnlttime.Text = dttemp.Rows[0]["xpnlttime"].ToString();
            ////xouttime.Text = dttemp.Rows[0]["xouttime"].ToString();
            ////xmrgntime.Text = dttemp.Rows[0]["xmrgntime"].ToString();

            ////DateTime xcdate1 = Convert.ToDateTime(dttemp.Rows[0]["xcdate"]);
            ////string month1 = zgetvalue.GetMonthName(xcdate1.Month);
            ////string year1 = xcdate1.Year.ToString();

            ////xcdate.Text = month1 + "-" + year1;
            ////xtdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");

            //xremark.Text = dttemp.Rows[0]["xremark"].ToString();
            ////xchqdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xchqdate"]).ToString("dd/MM/yyyy");
            ////xchqno.Text = dttemp.Rows[0]["xchqno"].ToString();
            //xstatus.Text = dttemp.Rows[0]["xstatus"].ToString();
            //xnote.Text = dttemp.Rows[0]["xnote"].ToString();
            ////xdayab.Text = dttemp.Rows[0]["xdayab"].ToString();
            ////xatdstat.Text = dttemp.Rows[0]["xatdstat"].ToString();
            ////xinc.Text = dttemp.Rows[0]["xinc"].ToString();
            ////xnum.Text = dttemp.Rows[0]["xnum"].ToString();
            ////xscore.Text = dttemp.Rows[0]["xscore"].ToString();
            ////xqtycount.Text = dttemp.Rows[0]["xqtycount"].ToString();
            ////xstr01.Text = dttemp.Rows[0]["xstr01"].ToString();
            ////xrowauth.Text = dttemp.Rows[0]["xrowauth"].ToString();
            ////xrowappt.Text = dttemp.Rows[0]["xrowappt"].ToString();
            ////xrowprob.Text = dttemp.Rows[0]["xrowprob"].ToString();
            ////xint01.Text = dttemp.Rows[0]["xint01"].ToString();
            ////xint02.Text = dttemp.Rows[0]["xint02"].ToString();
            ////zemail.Text = dttemp.Rows[0]["zemail"].ToString();
            ////xemail.Text = dttemp.Rows[0]["xemail"].ToString();




            //fnButtonState();
            ////BindGrid();
            ////fnCalculateTotal();
            //fnFillGrid2();
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
            //try
            //{
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    message.InnerText = "";
            //    //fnCheckRow();

            //    //if (ViewState["xrow"] != null)
            //    //{
            //    //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfch",
            //    //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    //    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
            //    //    {
            //    //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
            //    //        message.Style.Value = zglobal.warningmsg;
            //    //        return;
            //    //    }
            //    //}

            //    if (ViewState["xsup"] != null)
            //    {
            //        if (txtconformmessageValue1.Value == "Yes")
            //        {

            //            string xstatus1 = zglobal.fnGetValue("xshift", "prholiday",
            //             "zid=" + _zid + " AND xshift='" + xshift.Text.ToString().Trim() + "' AND xdate='" + DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture) + "'");
            //            if (xstatus1 != "")
            //            {
            //                message.InnerHtml = "Status : " + xstatus1 + ". Cann't delete data.";
            //                message.Style.Value = zglobal.warningmsg;
            //                return;
            //            }

            //            string xstatus;


            //            using (TransactionScope tran = new TransactionScope())
            //            {
            //                using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //                {
            //                    conn.Open();
            //                    SqlCommand cmd = new SqlCommand();
            //                    cmd.Connection = conn;


            //                    string query = "DELETE FROM prholiday WHERE zid=" + _zid + " AND xshift='" + xshift.Text.ToString().Trim() + "' AND xdate='" + DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture) + "'";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    //cmd.Parameters.AddWithValue("@xsup", ViewState["xsup"].ToString());
            //                    cmd.ExecuteNonQuery();

            //                }

            //                tran.Complete();
            //            }

            //            message.InnerHtml = zglobal.delsuccmsg;
            //            message.Style.Value = zglobal.successmsg;
            //            //btnSubmit.Enabled = false;
            //            //btnSubmit1.Enabled = false;
            //            //btnSave.Enabled = false;
            //            //btnSave1.Enabled = false;
            //            //btnDelete.Enabled = false;
            //            //btnDelete1.Enabled = false;
            //            //ViewState["xstatus"] = "Submited";
            //            //hxstatus.Value = "Submited";
            //            //dxstatus.Visible = true;
            //            //btnPrint.Visible = true;
            //            //dxstatus.Text = "Status : Submited";
            //            //hiddenxstatus.Value = "Submited";
            //            fnButtonState();
            //            //BindGrid();
            //            fnFillGrid2();
            //        }
            //    }
            //    else
            //    {
            //        message.InnerHtml = "No data found for delete.";
            //        message.Style.Value = zglobal.warningmsg;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
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
            //try
            //{

            //    message.InnerText = "";
            //    if (ViewState["xsup"] != null)
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
            //                    string xconfirmedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    DateTime xconfirmeddt = DateTime.Now;
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
            //                        "UPDATE prholiday SET xstatus=@xstatus " +
            //                        "WHERE zid=" + _zid + " AND xshift='" + xshift.Text.ToString().Trim() + "' AND xdate='" + DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture) + "'";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
            //                    //cmd.Parameters.AddWithValue("@xconfirmedby", xconfirmedby);
            //                    //cmd.Parameters.AddWithValue("@xconfirmeddt", xconfirmeddt);
            //                    cmd.ExecuteNonQuery();
            //                }

            //                tran.Complete();
            //            }

            //            message.InnerHtml = "<font color=blue size=+1><strong>Approved</p></strong></font>";
            //            //message.Style.Value = zglobal.successmsg;
            //            btnConfirm.Enabled = false;
            //            btnConfirm1.Enabled = false;
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

        protected void btnPaid_Click(object sender, EventArgs e)
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
            //                    string xpaidby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    DateTime xpaiddt = DateTime.Now;
            //                    xstatus = "Paid";
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
            //                        "UPDATE amtfch SET xstatus=@xstatus,xpaidby=@xpaidby,xpaiddt=@xpaiddt " +
            //                        "WHERE zid=@zid AND xrow=@xrow ";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
            //                    cmd.Parameters.AddWithValue("@xpaidby", xpaidby);
            //                    cmd.Parameters.AddWithValue("@xpaiddt", xpaiddt);
            //                    cmd.ExecuteNonQuery();
            //                }

            //                tran.Complete();
            //            }


            //            btnSubmit.Enabled = false;
            //            btnSubmit1.Enabled = false;
            //            btnSave.Enabled = false;
            //            btnSave1.Enabled = false;
            //            btnDelete.Enabled = false;
            //            btnDelete1.Enabled = false;
            //            btnPaid.Enabled = false;
            //            btnPaid1.Enabled = false;
            //            btnPrint.Enabled = true;
            //            btnPrint1.Enabled = true;
            //            ViewState["xstatus"] = "Paid";
            //            hxstatus.Value = "Paid";
            //            //dxstatus.Visible = true;
            //            //btnPrint.Visible = true;
            //            //dxstatus.Text = "Status : Submited";
            //            hiddenxstatus.Value = "Paid";
            //            fnButtonState();
            //            //BindGrid();
            //            fnFillGrid2();

            //            fnFillControl(ViewState["xrow"].ToString());

            //            message.InnerHtml = zglobal.paidsuccmsg;
            //            message.Style.Value = zglobal.successmsg;
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

        protected void xcdate_OnTextChanged(object sender, EventArgs e)
        {
            //    try
            //    {
            //        message.InnerHtml = "";
            //        if (xclass.Text.Trim().ToString() == "")
            //        {
            //            message.InnerHtml = "Student not found.";
            //            message.Style.Value = zglobal.am_warningmsg;
            //            GridView1.DataSource = null;
            //            GridView1.DataBind();
            //            return;
            //        }
            //        BindGrid();
            //        if (GridView1.DataSource != null)
            //        {
            //            xreceived = 0;
            //            xdue = 0;
            //            foreach (GridViewRow row in GridView1.Rows)
            //            {
            //                TextBox xrec = (TextBox)row.FindControl("xreceived");


            //                if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
            //                {
            //                    //xrec.Text = Convert.ToDecimal("0").ToString("F"); 
            //                }
            //                else
            //                {
            //                    xreceived += decimal.Parse(xrec.Text.Trim().ToString());
            //                }


            //                xdue += decimal.Parse(row.Cells[3].Text.ToString());

            //            }

            //            GridView1.FooterRow.Cells[3].Text = xdue.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //            GridView1.FooterRow.Cells[3].Font.Bold = true;
            //            GridView1.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            //            GridView1.FooterRow.Cells[3].ForeColor = Color.White;

            //            GridView1.FooterRow.Cells[4].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //            GridView1.FooterRow.Cells[4].Font.Bold = true;
            //            GridView1.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //            GridView1.FooterRow.Cells[4].ForeColor = Color.White;


            //        }

            //    }
            //    catch (Exception exp)
            //    {
            //        message.InnerHtml = exp.Message;
            //        message.Style.Value = zglobal.errormsg;
            //    }
            //}

            //private void fnCalculateTotal()
            //{

            //    xnettotal1 = 0;
            //    xreceived = 0;
            //    xdue = 0;


            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        TextBox xrec = (TextBox)row.FindControl("xreceived");


            //        if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
            //        {
            //            xrec.Text = "0.00";
            //        }



            //        xreceived += decimal.Parse(xrec.Text.Trim().ToString());
            //        xnettotal1 += decimal.Parse(row.Cells[2].Text.ToString());
            //        xdue += decimal.Parse(row.Cells[3].Text.ToString());

            //    }

            //    GridView1.FooterRow.Cells[2].Text = xnettotal1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //    GridView1.FooterRow.Cells[2].Font.Bold = true;
            //    GridView1.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //    GridView1.FooterRow.Cells[2].ForeColor = Color.White;

            //    GridView1.FooterRow.Cells[3].Text = xdue.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //    GridView1.FooterRow.Cells[3].Font.Bold = true;
            //    GridView1.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            //    GridView1.FooterRow.Cells[3].ForeColor = Color.White;

            //    GridView1.FooterRow.Cells[4].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //    GridView1.FooterRow.Cells[4].Font.Bold = true;
            //    GridView1.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //    GridView1.FooterRow.Cells[4].ForeColor = Color.White;
        }

        protected void xstdid_OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    //xcdate.Text = "";
            //    //SetInitialRow();
            //    hxclass.Value = xclass.Text.Trim().ToString();
            //    //message.InnerHtml = "";
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    ViewState["xrow"] = null;
            //    xrow1.Text = "";
            //    xsession.Text = zglobal.fnDefaults("xsession", "Student");
            //    //xbank.Text = zglobal.fnDefaults("xbank", "Student");
            //    //xcdate.Text = DateTime.Now.ToString("MMM-yyyy");
            //    //xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //    //xchqdate.Text = "";
            //    //xchqno.Text = "";
            //    //xremarks.Text = "";

            //    BindGrid();

            //    if (GridView1.DataSource != null)
            //    {
            //        xreceived = 0;
            //        xdue = 0;
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            TextBox xrec = (TextBox)row.FindControl("xreceived");

            //            if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
            //            {
            //                //xrec.Text = Convert.ToDecimal("0").ToString("F"); 
            //            }
            //            else
            //            {
            //                xreceived += decimal.Parse(xrec.Text.Trim().ToString());
            //            }

            //            xdue += decimal.Parse(row.Cells[3].Text.ToString());
            //        }

            //        GridView1.FooterRow.Cells[3].Text = xdue.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //        GridView1.FooterRow.Cells[3].Font.Bold = true;
            //        GridView1.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            //        GridView1.FooterRow.Cells[3].ForeColor = Color.White;

            //        GridView1.FooterRow.Cells[4].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //        GridView1.FooterRow.Cells[4].Font.Bold = true;
            //        GridView1.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //        GridView1.FooterRow.Cells[4].ForeColor = Color.White;


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