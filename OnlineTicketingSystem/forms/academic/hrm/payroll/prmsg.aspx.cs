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
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CrystalDecisions.ReportAppServer;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class prmsg : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            if (ViewState["xpaydate"] == null)
            {
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
                //btnConfirm.Enabled = false;
                //btnConfirm1.Enabled = false;
                //btnPaid.Enabled = false;
                //btnPaid1.Enabled = false;
                btnPrint.Enabled = false;
                btnPrint1.Enabled = false;
                btnDetails.Enabled = false;
                btnDetails1.Enabled = false;
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
                //xsup.Text = ViewState["xpaydate"].ToString();
                ////xsession.Enabled = false;
                ////xstdid.Enabled = false;

                //string xstatus1 = "";
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //string xstatus1 = zglobal.fnGetValue("xstatus", "prholiday",
                //    "zid=" + _zid + " AND xshift='" + xshift.Text.ToString().Trim() + "' AND xdate='" +
                //    DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                //        CultureInfo.InvariantCulture) + "'");
                ////hxstatus.Value = xstatus1;
                ////xstatus.InnerHtml = xstatus1;
                ////zemail.InnerHtml = zglobal.fnGetValue("coalesce(zemail,'') as zemail", "amdropout",
                ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                ////xapprovedby.InnerHtml = zglobal.fnGetValue("coalesce(xapprovedby,'') as xapprovedby", "amdropout",
                ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                ////xsessionpro.Text = zglobal.fnGetValue("xsessionpro", "ampromotionh",
                ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                ////xclasspro.Text = zglobal.fnGetValue("xclasspro", "ampromotionh",
                ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                ////xgrouppro.Text = zglobal.fnGetValue("xgrouppro", "ampromotionh",
                ////               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                ////dxstatus.Visible = true;

                //if (xstatus1 == "New" || xstatus1 == "Undo")
                //{
                //    btnSubmit.Enabled = true;
                //    btnSubmit1.Enabled = true;
                //    btnConfirm.Enabled = true;
                //    btnConfirm1.Enabled = true;
                //    btnSave.Enabled = true;
                //    btnSave1.Enabled = true;
                //    btnDelete.Enabled = true;
                //    btnDelete1.Enabled = true;
                //    btnPaid.Enabled = true;
                //    btnPaid1.Enabled = true;
                //    btnPrint.Enabled = true;
                //    btnPrint1.Enabled = true;
                //    //dxstatus.Text = xstatus1;
                //    hxstatus.Value = xstatus1;
                //    //dxstatus.Style.Value = zglobal.am_new;

                //    //xsessionpro.Enabled = true;
                //    //xclasspro.Enabled = true;
                //    //xgrouppro.Enabled = true;

                //    //xsession.Enabled = false;
                //    //xstdid.Enabled = false;

                //}
                //else
                //{
                //    btnSubmit.Enabled = false;
                //    btnSubmit1.Enabled = false;
                //    btnConfirm.Enabled = false;
                //    btnConfirm1.Enabled = false;
                //    btnSave.Enabled = false;
                //    btnSave1.Enabled = false;
                //    btnDelete.Enabled = false;
                //    btnDelete1.Enabled = false;
                //    btnPaid.Enabled = false;
                //    btnPaid1.Enabled = false;
                //    btnPrint.Enabled = true;
                //    btnPrint1.Enabled = true;
                //    //dxstatus.Text = xstatus1;
                //    hxstatus.Value = xstatus1;
                //    //dxstatus.Style.Value = zglobal.am_submited;

                //    //xsessionpro.Enabled = false;
                //    //xclasspro.Enabled = false;
                //    //xgrouppro.Enabled = false;
                //}

                ////if (xstatus1 == "New" || xstatus1 == "Undo")
                ////{
                ////    dxstatus.Style.Value = zglobal.am_new;
                ////}
                ////else
                ////{
                ////    dxstatus.Style.Value = zglobal.am_submited;
                ////}
                //if (xstatus1 == "Undo1")
                //{
                //    //int t = 0;
                //    //foreach (GridViewRow row in GridView1.Rows)
                //    //{
                //    //    Label lblxflag1 = row.FindControl("xflag1") as Label;
                //    //    Label lblxflag2 = row.FindControl("xflag2") as Label;

                //    //    if (lblxflag1.Text == "Wrong" || lblxflag2.Text == "Missing")
                //    //    {
                //    //        t = 1;
                //    //        break;
                //    //    }
                //    //}

                //    //if (t == 1)
                //    //{
                //    //    btnSave.Enabled = true;
                //    //    btnSave1.Enabled = true;
                //    //    btnDelete.Enabled = false;
                //    //    btnDelete1.Enabled = false;
                //    //    btnSubmit.Enabled = true;
                //    //    btnSubmit1.Enabled = true;
                //    //}
                //    //else
                //    //{
                //    //    btnSave.Enabled = false;
                //    //    btnSave1.Enabled = false;
                //    //    btnDelete.Enabled = false;
                //    //    btnDelete1.Enabled = false;
                //    //    btnSubmit.Enabled = false;
                //    //    btnSubmit1.Enabled = false;
                //    //}

                //    btnSave.Enabled = true;
                //    btnSave1.Enabled = true;
                //    //btnDelete.Enabled = false;
                //    //btnDelete1.Enabled = false;
                //    btnDelete.Enabled = true;
                //    btnDelete1.Enabled = true;
                //    btnSubmit.Enabled = true;
                //    btnSubmit1.Enabled = true;

                //    //xsessionpro.Enabled = true;
                //    //xclasspro.Enabled = true;
                //    //xgrouppro.Enabled = true;
                //}

                //if (xstatus1 == "")
                //{
                //    btnConfirm.Enabled = true;
                //    btnConfirm1.Enabled = true;
                //    btnSave.Enabled = true;
                //    btnSave1.Enabled = true;
                //    btnDelete.Enabled = true;
                //    btnDelete1.Enabled = true;
                //}
                //else
                //{
                //    btnConfirm.Enabled = false;
                //    btnConfirm1.Enabled = false;
                //    btnSave.Enabled = false;
                //    btnSave1.Enabled = false;
                //    btnDelete.Enabled = false;
                //    btnDelete1.Enabled = false;
                //}

                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                //btnSave.Enabled = true;
                //btnSave1.Enabled = true;
                //btnDelete.Enabled = false;
                //btnDelete1.Enabled = false;
                //btnConfirm.Enabled = true;
                //btnConfirm1.Enabled = true;
                //btnPaid.Enabled = false;
                //btnPaid1.Enabled = false;
                btnPrint.Enabled = false;
                btnPrint1.Enabled = false;

                //btnConfirm.Visible = false;
                //btnConfirm1.Visible = false;
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete1.Enabled = true;
                btnDetails.Enabled = true;
                btnDetails1.Enabled = true;

                //btnSave.Enabled = true;
                //btnSave1.Enabled = true;
                //btnDelete.Enabled = false;
                //btnDelete1.Enabled = false;
                //btnDelete.Enabled = true;
                //btnDelete1.Enabled = true;

            }

            //btnPaid.Visible = false;
            //btnPaid1.Visible = false;
            //btnConfirm.Visible = false;
            //btnConfirm1.Visible = false;
        }

        private string xempcat1 = "";
        private string xyear1 = "";
        private string xdateeff1 = "";
        private string xdateexp1 = "";
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

                    //zglobal.fnGetComboDataCD("Employee Category", xempcat);
                    //zglobal.fnGetComboDataCD("Leave Type", xleave);
                    //zglobal.fnComboWeekDay(xstr01);
                    //zglobal.fnComboWeekDay(xremark);

                    //xatdstat.Items.Clear();
                    //xatdstat.Items.Add("");
                    //xatdstat.Items.Add("Yes");
                    //xatdstat.Items.Add("No");
                    //xatdstat.Text = "No";

                    ViewState["xrow"] = null;
                    hiddenxrow.Value = "";
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    ViewState["xpaydate"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";
                    hxclass.Value = "";

                    string xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
                    string xemp1 = Request.QueryString["xemp"] != null ? Request.QueryString["xemp"].ToString().Trim() : "";

                    spanxpaydate.InnerHtml = xpaydate1;

                    if (xpaydate1 != "" && xemp1!= "")
                    {
                        //xpaydate.Text = xpaydate1;


                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        DataSet dts = new DataSet();

                        dts.Reset();


                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                        string str = "SELECT  * " +
                                     "FROM prmsg where zid=@zid  and xpaydate=@xpaydate and xemp=@xemp ";


                        DateTime xpaydt = DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xpaydate", xpaydt);
                        da.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                        da.Fill(dts, "tempztcode");
                        DataTable dttemp = new DataTable();
                        dttemp = dts.Tables[0];



                        ViewState["xpaydate"] = xpaydate1;

                        xemp.Text = dttemp.Rows[0]["xemp"].ToString();
                        xdayab.Text = dttemp.Rows[0]["xdayab"].ToString();
                        xdaylv.Text = dttemp.Rows[0]["xdaylv"].ToString();
                        if (dttemp.Rows[0]["xadvflag"].ToString() == "Yes")
                        {
                            rdoyes.Checked = true;
                        }
                        else
                        {
                            rdono.Checked = true;
                        }
                        xemail.Text = dttemp.Rows[0]["xemail"].ToString();
                        zemail.Text = dttemp.Rows[0]["zemail"].ToString();
                        xdept.Text = dttemp.Rows[0]["xdept"].ToString();
                        xstatusemp.Text = dttemp.Rows[0]["xstatusemp"].ToString();
                    }

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
                    //_gridrow2.Text = zglobal._grid_row_value;
                    fnFillGrid2();
                    //SetInitialRow();
                    ViewState["xtype"] = "Tuition Fee";

                    //btnPaid.Visible = false;
                    //btnPaid1.Visible = false;

                    

                }

               // tmpdesc.Text = zglobal.fnGetValue("xdesc", "prpayhead",
               //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xpaydate='" + xpaydate.Text.ToString().Trim() + "' ");

               // tmpdesc1.Text = zglobal.fnGetValue("xdesc", "prpayhead",
               //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xpaydate='" + xpcode.Text.ToString().Trim() + "' ");

                xnameemp.Text = zglobal.fnGetValue("xname", "hrmst",
         "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xemp='" +
         xemp.Text.ToString().Trim() + "' ");

                //xempcat1 = Request.QueryString["xempcat"] != null ? Request.QueryString["xempcat"].ToString().Trim() : "";
                //xyear1 = Request.QueryString["xempcat"] != null ? Request.QueryString["xempcat"].ToString().Trim() : "";
                //xdateeff1 = Request.QueryString["xempcat"] != null ? Request.QueryString["xempcat"].ToString().Trim() : "";
                //xdateexp1 = Request.QueryString["xempcat"] != null ? Request.QueryString["xempcat"].ToString().Trim() : "";

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
                LinkButton lnkFull1 = row.FindControl("xemp") as LinkButton;
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

        private string dept = "";
        private string desig = "";
        private string location = "";
        //private string div = "";
        private string sec = "";
        //private string proj = "";
        private string empnature = "";
        private string statusemp = "";
        //private string zone = "";
        //private string subsec = "";
        private string empcat = "";

        private void emp_info()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            dept = zglobal.fnGetValue("xdept", "hrmst",
                        "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");

            desig = zglobal.fnGetValue("xdesig", "hrmst",
                        "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");

            location = zglobal.fnGetValue("xlocation", "hrmst",
                        "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");

            sec = zglobal.fnGetValue("xsec", "hrmst",
                        "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");

            empnature = zglobal.fnGetValue("xempnature", "hrmst",
                        "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");

            statusemp = zglobal.fnGetValue("xstatusemp", "hrmst",
                        "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");

            empcat = zglobal.fnGetValue("xcat", "hrmst",
                       "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = 0;
                string xsupp = "";
                message.InnerHtml = "";



                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                if (xemp.Text == "" || xemp.Text == string.Empty || xemp.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Employee Code</li>";
                    isValid = false;
                }

                




                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                //DateTime xdateeff1 = xdateeff.Text.Trim() != string.Empty ? DateTime.ParseExact(xdateeff.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now;
                //DateTime xdateexp1 = xdateexp.Text.Trim() != string.Empty ? DateTime.ParseExact(xdateexp.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now;

                //string chk_fpay = zglobal.fnGetValue("xflags", "prpay",
                //      "zid=" + _zid + " AND xpaydate>='" + xdate1 + "' and xflags='1'");

                //if (chk_fpay != "")
                //{
                //    message.InnerHtml = "Can't Save <br/>Final Payroll already Processed.";
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}

                if (xemp.Text.Trim().ToString() != "")
                {
                    string tmpchk = zglobal.fnGetValue("xemp", "hrmst",
                        "zid=" + _zid + "  and xemp='" + xemp.Text.ToString().Trim() + "'");

                    if (tmpchk == "")
                    {
                        message.InnerHtml = "Not a valid Employee Code.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                //if (xpcode.Text.Trim().ToString() != "")
                //{
                //    string tmpchk = zglobal.fnGetValue("xpaydate", "prpayhead",
                //        "zid=" + _zid + "  and xpaydate='" + xpcode.Text.ToString().Trim() + "'");

                //    if (tmpchk == "")
                //    {
                //        message.InnerHtml = "Not a valid Paycode.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}


                ////fnCheckRow();
                //string xstatus2 = "";
                //if (ViewState["xpaydate"] != null)
                //{
                //    xstatus2 = zglobal.fnGetValue("xstatus", "prholiday",
                //          "zid=" + _zid + " AND xdate='" + xdate1 + "' AND xshift='" + xshift.Text.ToString().Trim() + "'");
                //    if (xstatus2 != "")
                //    {
                //        message.InnerHtml = "Status : " + xstatus2 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                //emp_info();


                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail12 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                string xleave1 = "";
                int xefffrom1 = 0;
                var xcalcday1 = 0;
                int xleavecfd1 = 0;
                int xleavecfy1 = 0;
                int xmaxleave1 = 0;
                int xminleave1 = 0;
                decimal xmaxencash1 = 0;
                decimal xminencash1 = 0;
                int xmaxoffers1 = 0;
                int xfstslabday1 = 0;
                int xsndslabday1 = 0;
                int xtrdslabday1 = 0;
                string xfstslabpay1 = "";
                string xsndslabpay1 = "";
                string xtrdslabpay1 = "";
                string xstatus1 = "";
                int xcfleave1 = 0;
                int xleavealc1 = 0;

                string xpaydate1 = "";
                string xpcode1 = "";
                decimal xpercent1 = 0;
                decimal xamount1 = 0;
                decimal xminpay1 = 0;
                decimal xmaxpay1 = 0;

                string xpflag = "";

                xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
                //xyear1 = Request.QueryString["xyear"] != null ? Request.QueryString["xyear"].ToString().Trim() : "";

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        con.Open();
                        string query =
                            "SELECT * FROM prmsg WHERE zid=@zid AND xpaydate=@xpaydate ";

                        SqlDataAdapter da = new SqlDataAdapter(query, con);

                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xpaydate", DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture));

                        DataTable tempTable = new DataTable();
                        da.Fill(dts, "tempTable");
                        tempTable = dts.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            ViewState["xpaydate"] = xpaydate1;
                        }
                        else
                        {
                            ViewState["xpaydate"] = null;
                        }
                    }
                }


                using (TransactionScope tran = new TransactionScope())
                {
                    //if (GridView1.Rows.Count > 0)
                    //{
                    //if (ViewState["xpaydate"] == null)
                    //{


                    //    ////Duplicate entry check
                    //    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //    //{
                    //    //    using (DataSet dts = new DataSet())
                    //    //    {
                    //    //        con.Open();
                    //    //        string query =
                    //    //   "SELECT * FROM prlvpolicy WHERE zid=@zid AND xempcat=@xempcat and xyear=@xyear and xleave=@xleave ";

                    //    //        SqlDataAdapter da = new SqlDataAdapter(query, con);

                    //    //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //    //        da.SelectCommand.Parameters.AddWithValue("@xempcat", xempcat1);
                    //    //        da.SelectCommand.Parameters.AddWithValue("@xyear", xyear1);
                    //    //        da.SelectCommand.Parameters.AddWithValue("@xleave", xleave.Text.ToString());

                    //    //        DataTable tempTable = new DataTable();
                    //    //        da.Fill(dts, "tempTable");
                    //    //        tempTable = dts.Tables["tempTable"];

                    //    //        if (tempTable.Rows.Count > 0)
                    //    //        {
                    //    //            message.InnerHtml = "Cann't insert duplicate record.";
                    //    //            message.Style.Value = zglobal.warningmsg;
                    //    //            return;
                    //    //        }
                    //    //    }
                    //    //}


                    //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    //    {
                    //        conn.Open();
                    //        SqlCommand cmd = new SqlCommand();
                    //        cmd.Connection = conn;

                    //        DateTime ztime = DateTime.Now;
                    //        DateTime zutime = DateTime.Now;
                    //        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    //        //xrow = 0;
                    //        xsupp = "";


                    //        string query =
                    //           "INSERT INTO prmsg (zid,ztime,xpaydate,xemp,xremarks,xdayab,zemail) " +
                    //           "VALUES(@zid,@ztime,@xpsclcode,@xpaydate,@xpcode,@xpercent,@xamount,@xminpay,@xmaxpay,@zemail) ";


                    //        //xrow = zglobal.GetMaximumIDWithTRN("xcdate", "xrow", "amtfch", xcdate1);
                    //        //ViewState["xrow"] = xrow;
                    //        //hiddenxrow.Value = xrow.ToString();
                    //        //xtrnsup1 = xtrnsup.Text.Trim().ToString();
                    //        //xsup1 = zglobal.GetMaximumIDWithTRN(xtrnsup1, "xsup", "mssup");
                    //        //ViewState["xpaydate"] = xsup1;
                    //        //xsupp = xsup1;

                    //        ViewState["xpaydate"] = xpaydate.Text.Trim().ToString();
                    //        xsupp = xpaydate.Text.Trim().ToString();


                    //        //xcrlimit1 = Convert.ToDecimal(xcrlimit.Text.Trim().ToString() == ""? "0" : xcrlimit.Text.Trim().ToString());
                    //        //xcrterms1 = Convert.ToInt32(xcrterms.Text.ToString().Trim() == "" ? "0" : xcrterms.Text.ToString().Trim());

                    //        //xempcat1 = xempcat.Text.ToString().Trim();
                    //        //xyear1 = xyear.Text.ToString().Trim();

                    //        xpaydate1 = xpaydate.Text.ToString();
                    //        xpcode1 = xpcode.Text.ToString();
                    //        xpercent1 = Convert.ToDecimal(xpercent.Text.ToString().Trim());
                    //        xamount1 = Convert.ToDecimal(xamount.Text.ToString().Trim());
                    //        xminpay1 = Convert.ToDecimal(xminpay.Text.ToString().Trim());
                    //        xmaxpay1 = Convert.ToDecimal(xmaxpay.Text.ToString().Trim());



                    //        cmd.CommandText = query;
                    //        cmd.Parameters.AddWithValue("@ztime", ztime);
                    //        cmd.Parameters.AddWithValue("@zid", _zid);
                    //        cmd.Parameters.AddWithValue("@zemail", zemail1);
                    //        cmd.Parameters.AddWithValue("@xpsclcode", xpsclcode1);
                    //        cmd.Parameters.AddWithValue("@xpaydate", xpaydate1);
                    //        cmd.Parameters.AddWithValue("@xpcode", xpcode1);
                    //        cmd.Parameters.AddWithValue("@xpercent", xpercent1);
                    //        cmd.Parameters.AddWithValue("@xamount", xamount1);
                    //        cmd.Parameters.AddWithValue("@xminpay", xminpay1);
                    //        cmd.Parameters.AddWithValue("@xmaxpay", xmaxpay1);
                    //        cmd.ExecuteNonQuery();
                    //    }
                    //}



                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        string query = "";



                        if (xsupp == "")
                        {

                            //xempcat1 = xempcat.Text.ToString().Trim();
                            //xyear1 = xyear.Text.ToString().Trim();

                            //xpaydate1 = xpaydate.Text.ToString();
                            //xpcode1 = xpcode.Text.ToString();
                            //xpercent1 = Convert.ToDecimal(xpercent.Text.ToString().Trim());
                            //xamount1 = Convert.ToDecimal(xamount.Text.ToString().Trim());
                            //xminpay1 = Convert.ToDecimal(xminpay.Text.ToString().Trim());
                            //xmaxpay1 = Convert.ToDecimal(xmaxpay.Text.ToString().Trim());

                            query = "UPDATE prmsg SET zutime=@zutime,xadvflag=@xadvflag, xdayab=@xdayab, xemail=@xemail, xremarks=@xremarks " +
                                    "WHERE zid=@zid AND xemp=@xemp AND xpaydate=@xpaydate ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xemail", zemail1);
                            cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@xadvflag", rdono.Checked?"No":"Yes");
                            cmd.Parameters.AddWithValue("@xpaydate", DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                            cmd.Parameters.AddWithValue("@xdayab", Convert.ToInt32(xdayab.Text.Trim()));
                            cmd.Parameters.AddWithValue("@xemp", xemp.Text.Trim());
                            cmd.Parameters.AddWithValue("@xremarks", xremarks.Text.Trim());
                            cmd.ExecuteNonQuery();


                        }




                    }

                    tran.Complete();

                }

                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                // btnRefresh_Click(null, null);
                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;
                //ViewState["xrow"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";

                //BindGrid();
                //xrow1.Text = ViewState["xrow"].ToString();
                //xsup.Text = ViewState["xpaydate"].ToString();
                fnButtonState();
                fnFillGrid2();


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




        private void fnFillGrid2()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            string xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
            //xyear1 = Request.QueryString["xyear"] != null ? Request.QueryString["xyear"].ToString().Trim() : "";

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " *,(select xname from hrmst where zid=prmsg.zid and xemp=prmsg.xemp) as xname " +
                       "FROM prmsg WHERE zid=@zid and xpaydate=@xpaydate " +
                       "order by xemp ";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xpaydate", DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    //da1.SelectCommand.Parameters.AddWithValue("@xyear", xyear1);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvcollectionew.DataSource = tempTable;
                        dgvcollectionew.DataBind();
                    }
                    else
                    {
                        dgvcollectionew.DataSource = null;
                        dgvcollectionew.DataBind();
                    }


                }
            }


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

       

        protected void FillControl(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                string xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
                //xyear1 = Request.QueryString["xyear"] != null ? Request.QueryString["xyear"].ToString().Trim() : "";
                string xemp1 = ((LinkButton)sender).Text;

                fnFillControl( xpaydate1,xemp1);

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
                if (xemp.Text.Trim().ToString() != String.Empty )
                {
                    string xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
                    string xemp1 = xemp.Text.Trim().ToString();

                    fnFillControl(xpaydate1, xemp1);
                }
                else
                {
                    message.InnerHtml = "Invaliv Parameter.";
                    message.Style.Value = zglobal.am_warningmsg;
                    xemp.Focus();
                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnFillControl(string xpaydate1, string xemp1)
        {
            message.InnerHtml = "";

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();


            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            string str = "SELECT  * " +
                         "FROM prmsg where zid=@zid  and xemp=@xemp and xpaydate=@xpaydate ";




            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
            da.SelectCommand.Parameters.AddWithValue("@xpaydate", DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            da.Fill(dts, "tempztcode");
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];

            if (dttemp.Rows.Count <= 0)
            {
                message.InnerHtml = "Invalid Peremeter.";
                message.Style.Value = zglobal.am_warningmsg;
                return;
            }

            ViewState["xpaydate"] = xpaydate1;
            //hiddenxrow.Value = ViewState["xrow"].ToString();

            xemp.Text = dttemp.Rows[0]["xemp"].ToString();
            xdayab.Text = dttemp.Rows[0]["xdayab"].ToString();
            xdaylv.Text = dttemp.Rows[0]["xdaylv"].ToString();
            if (dttemp.Rows[0]["xadvflag"].ToString() == "Yes")
            {
                rdoyes.Checked = true;
            }
            else
            {
                rdono.Checked = true;
            }
            xemail.Text = dttemp.Rows[0]["xemail"].ToString();
            zemail.Text = dttemp.Rows[0]["zemail"].ToString();
            xdept.Text = dttemp.Rows[0]["xdept"].ToString();
            xstatusemp.Text = dttemp.Rows[0]["xstatusemp"].ToString();
            xremarks.Text = dttemp.Rows[0]["xremarks"].ToString();

            xnameemp.Text = zglobal.fnGetValue("xname", "hrmst",
           "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xemp='" + xemp.Text.ToString().Trim() + "' ");

            fnButtonState();
            //BindGrid();
            //fnCalculateTotal();
            fnFillGrid2();
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
                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfch",
                //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                if (ViewState["xpaydate"] != null)
                {
                    if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
                        //string xstatus1 = zglobal.fnGetValue("xshift", "prholiday",
                        // "zid=" + _zid + " AND xshift='" + xshift.Text.ToString().Trim() + "' AND xdate='" + DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                        //            CultureInfo.InvariantCulture) + "'");
                        //if (xstatus1 != "")
                        //{
                        //    message.InnerHtml = "Status : " + xstatus1 + ". Cann't delete data.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}

                        string chk_fpay = zglobal.fnGetValue("xflags", "prpay",
                      "zid=" + _zid + " AND xpaydate>='" + DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture) + "' and xflags='1'");

                        if (chk_fpay != "")
                        {
                            message.InnerHtml = "Can't Save <br/>Final Payroll already Processed.";
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


                                string query = "DELETE FROM prtrndt WHERE zid=" + _zid + " AND xemp='" + xemp.Text.Trim().ToString()
                                    + "' and xpaydate='" + DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture) + "'";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //cmd.Parameters.AddWithValue("@xsup", ViewState["xpaydate"].ToString());
                                cmd.ExecuteNonQuery();

                                query = "DELETE FROM prmsg WHERE zid=" + _zid + " AND xemp='" + xemp.Text.Trim().ToString()
                                    + "' and xpaydate='" + DateTime.ParseExact(xpaydate1, "dd/MM/yyyy", CultureInfo.InvariantCulture) + "'";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //cmd.Parameters.AddWithValue("@xsup", ViewState["xpaydate"].ToString());
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

        

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                string xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
                //xyear1 = Request.QueryString["xyear"] != null ? Request.QueryString["xyear"].ToString().Trim() : "";
                //xdateeff1 = Request.QueryString["xdateeff"] != null ? Request.QueryString["xdateeff"].ToString().Trim() : "";
                //xdateexp1 = Request.QueryString["xdateexp"] != null ? Request.QueryString["xdateexp"].ToString().Trim() : "";

                string url =
                         string.Format(
                             "~/forms/academic/hrm/payroll/prpay.aspx?subnav=myDropdown21&link=LinkButton21&xid=205005001&xpaydate={0}",
                             xpaydate1);

                Response.Redirect(url);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                if (ViewState["xpaydate"] != null)
                {
                    string xpaydate1 = Request.QueryString["xpaydate"] != null ? Request.QueryString["xpaydate"].ToString().Trim() : "";
                    string xemp1 = xemp.Text.Trim().ToString();

                    string url =
                         string.Format(
                             "~/forms/academic/hrm/payroll/prtrndt.aspx?subnav=myDropdown21&link=LinkButton21&xid=205005001&xpaydate={0}&xemp={1}",
                             xpaydate1,xemp1);

                    Response.Redirect(url);
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