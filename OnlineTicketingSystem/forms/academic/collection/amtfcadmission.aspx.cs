using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
using CrystalDecisions.Shared;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class amtfcadmission : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            if (ViewState["xstdid"] == null)
            {
                //btnSubmit.Enabled = false;
                //btnSubmit1.Enabled = false;
                btnPaid.Enabled = false;
                btnPaid1.Enabled = false;
                btnSave.Enabled = false;
                btnSave1.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
                btnPrint.Enabled = false;
                btnPrint1.Enabled = false;
                btnRefresh.Enabled = false;
                btnRefresh1.Enabled = false;
                btnGenerateID.Enabled = true;
                //dxstatus.Visible = false;
                //dxstatus.Text = "-";
                hxstatus.Value = "";
                //xtfccode.Enabled = true;
                //xeffdate.Enabled = true;
                //xclass.Enabled = true;
                //xgroup.Enabled = true;
                //xsection.Enabled = true;
                //xstdid.Enabled = true;
                //btnActive.Visible = false;
                //btnActive1.Visible = false;
                //btnInactive.Visible = false;
                //btnInactive1.Visible = false;
            }
            else
            {
                btnGenerateID.Enabled = false;

                if (ViewState["xrow"] == null)
                {
                    btnPaid.Enabled = false;
                    btnPaid1.Enabled = false;
                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    btnDelete.Enabled = false;
                    btnDelete1.Enabled = false;
                    btnPrint.Enabled = false;
                    btnPrint1.Enabled = false;
                    btnRefresh.Enabled = true;
                    btnRefresh1.Enabled = true;
                    btnGenerateID.Enabled = false;
                }
                else
                {
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfch",
                                   "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                    if (xstatus1 == "New" || xstatus1 == "Undo")
                    {
                        btnPaid.Enabled = true;
                        btnPaid1.Enabled = true;
                        btnSave.Enabled = true;
                        btnSave1.Enabled = true;
                        btnDelete.Enabled = true;
                        btnDelete1.Enabled = true;
                        btnPrint.Enabled = true;
                        btnPrint1.Enabled = true;
                        btnRefresh.Enabled = true;
                        btnRefresh1.Enabled = true;
                    }
                    else if (xstatus1 == "Paid")
                    {
                        btnPaid.Enabled = false;
                        btnPaid1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        btnPrint.Enabled = true;
                        btnPrint1.Enabled = true;
                        btnRefresh.Enabled = true;
                        btnRefresh1.Enabled = true;

                        xtdate.Enabled = false;
                        xbank.Enabled = false;
                        xchqdate.Enabled = false;
                        xchqno.Enabled = false;
                        xremarks.Enabled = false;
                        xadvreceive.Enabled = false;
                    }

                }

                //    xtfccode.Enabled = false;
                //    xeffdate.Enabled = false;
                //    xclass.Enabled = false;
                //    xgroup.Enabled = false;
                //    xsection.Enabled = false;
                //    xstdid.Enabled = false;
                //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfcconfig",
                //                   "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    xstatus.InnerHtml = xstatus1;
                //    zemail.InnerHtml = zglobal.fnGetValue("zemail", "amtfcconfig",
                //                   "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    xemail.InnerHtml = zglobal.fnGetValue("xemail", "amtfcconfig",
                //                   "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    //    //dxstatus.Visible = true;
                //    if (xstatus1 == "New" || xstatus1 == "Undo")
                //    {
                //        btnSubmit.Enabled = true;
                //        btnSubmit1.Enabled = true;
                //        btnSave.Enabled = true;
                //        btnSave1.Enabled = true;
                //        btnDelete.Enabled = true;
                //        btnDelete1.Enabled = true;
                //        //dxstatus.Text = xstatus1;
                //        hxstatus.Value = xstatus1;
                //        //dxstatus.Style.Value = zglobal.am_new;
                //        btnActive.Visible = false;
                //        btnActive1.Visible = false;
                //        btnInactive.Visible = false;
                //        btnInactive1.Visible = false;

                //    }
                //    else
                //    {
                //        btnSubmit.Enabled = false;
                //        btnSubmit1.Enabled = false;
                //        btnSave.Enabled = false;
                //        btnSave1.Enabled = false;
                //        btnDelete.Enabled = false;
                //        btnDelete1.Enabled = false;
                //        //dxstatus.Text = xstatus1;
                //        hxstatus.Value = xstatus1;
                //        //dxstatus.Style.Value = zglobal.am_submited;
                //        if (xstatus1 == "Submited")
                //        {
                //            btnActive.Visible = true;
                //            btnActive1.Visible = true;
                //            btnInactive.Visible = true;
                //            btnInactive1.Visible = true;

                //            if (zglobal.fnGetValue("zactive", "amtfcconfig",
                //                "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"])) == "1")
                //            {
                //                btnActive.Enabled = false;
                //                btnActive1.Enabled = false;
                //                btnInactive.Enabled = true;
                //                btnInactive1.Enabled = true;
                //            }
                //            else
                //            {
                //                btnActive.Enabled = true;
                //                btnActive1.Enabled = true;
                //                btnInactive.Enabled = false;
                //                btnInactive1.Enabled = false;
                //            }
                //        }

                //    }

                //    //    //if (xstatus1 == "New" || xstatus1 == "Undo")
                //    //    //{
                //    //    //    dxstatus.Style.Value = zglobal.am_new;
                //    //    //}
                //    //    //else
                //    //    //{
                //    //    //    dxstatus.Style.Value = zglobal.am_submited;
                //    //    //}
                //    //    if (xstatus1 == "Undo1")
                //    //    {
                //    //        //int t = 0;
                //    //        //foreach (GridViewRow row in GridView1.Rows)
                //    //        //{
                //    //        //    Label lblxflag1 = row.FindControl("xflag1") as Label;
                //    //        //    Label lblxflag2 = row.FindControl("xflag2") as Label;

                //    //        //    if (lblxflag1.Text == "Wrong" || lblxflag2.Text == "Missing")
                //    //        //    {
                //    //        //        t = 1;
                //    //        //        break;
                //    //        //    }
                //    //        //}

                //    //        //if (t == 1)
                //    //        //{
                //    //        //    btnSave.Enabled = true;
                //    //        //    btnSave1.Enabled = true;
                //    //        //    btnDelete.Enabled = false;
                //    //        //    btnDelete1.Enabled = false;
                //    //        //    btnSubmit.Enabled = true;
                //    //        //    btnSubmit1.Enabled = true;
                //    //        //}
                //    //        //else
                //    //        //{
                //    //        //    btnSave.Enabled = false;
                //    //        //    btnSave1.Enabled = false;
                //    //        //    btnDelete.Enabled = false;
                //    //        //    btnDelete1.Enabled = false;
                //    //        //    btnSubmit.Enabled = false;
                //    //        //    btnSubmit1.Enabled = false;
                //    //        //}

                //    //        btnSave.Enabled = true;
                //    //        btnSave1.Enabled = true;
                //    //        //btnDelete.Enabled = false;
                //    //        //btnDelete1.Enabled = false;
                //    //        btnDelete.Enabled = true;
                //    //        btnDelete1.Enabled = true;
                //    //        btnSubmit.Enabled = true;
                //    //        btnSubmit1.Enabled = true;
                //    //    }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(zglobal.CurrencyType);
                    MasterPage m = this.Page.Master;
                    zglobal.fnDisableMasterPageContent(m);

                    //zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Bank", xbank);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Test Type", xcttype);

                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xbank.Text = zglobal.fnDefaults("xbank", "Student");

                    xadvreceive.Items.Clear();
                    xadvreceive.Items.Add("");
                    xadvreceive.Items.Add("Yes");
                    xadvreceive.Items.Add("No");
                    xadvreceive.Text = "";

                    xadvreceive.Text = zglobal.fnDefaults("xadvyesno", "Student");

                    //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    ////zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    //ViewState["xrow"] = null;
                    //ViewState["xstatus"] = null;
                    //ViewState["dtprectmarks"] = null;
                    //ViewState["colid"] = null;
                    //ViewState["sortdr"] = null;
                    //hxstatus.Value = "";
                    //_classteacher.Value = "";
                    //_subteacher.Value = "";

                    //fnButtonState();
                    ////btnShowList.Visible = false;
                    //pnllistct.Visible = false;
                    //retestfor.Visible = false;
                    //xreason_d.Visible = false;
                    //xschdate.Enabled = false;
                    //schedule_d.Visible = false;

                    //string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                    //string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                    //string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                    //string xgroup1 = Request.QueryString["xgroup"] != null ? Request.QueryString["xgroup"].ToString() : "";
                    //string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                    //string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
                    //string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
                    //string xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";
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
                    //    xext.Text = xext1;

                    //    combo_OnTextChanged(null, null);

                    //    xcttype.Text = xcttype1;
                    //    xcttype_Click(null, null);

                    //    xctno.Text = xctno1;
                    //    xctno_Click(null, null);
                    //}

                    //xstatus.InnerHtml = "";
                    //zemail.InnerHtml = "";
                    //xemail.InnerHtml = "";
                    //zactive.Checked = true;

                    //_gridrow.Text = zglobal._grid_row_value;
                    //_gridrow1.Text = zglobal._grid_row_value;
                    //fnFillGrid2();

                    //btnActive.Visible = false;
                    //btnActive1.Visible = false;
                    //btnInactive.Visible = false;
                    //btnInactive1.Visible = false;

                    xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    xstdid.Enabled = false;
                    xclass.Enabled = false;
                    xgroup.Enabled = false;
                    xsession.Enabled = false;
                    xname.Enabled = false;

                    Int64 xrow1 = Request.QueryString["xrow"] != null
                        ? Int64.Parse(Request.QueryString["xrow"].ToString())
                        : 0;
                    if (xrow1 == 0)
                    {
                        ViewState["xrow1"] = null;
                    }
                    else
                    {
                        ViewState["xrow1"] = xrow1;
                    }

                    string xstdid1 = zglobal.fnGetValue("xstdid", "amadmis",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xrow=" + xrow1);
                    string xclass1 = zglobal.fnGetValue("xclass", "amadmis",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xrow=" + xrow1);
                    string xgroup1 = zglobal.fnGetValue("xgroup", "amadmis",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xrow=" + xrow1);
                    string xsession1 = zglobal.fnGetValue("xsession", "amadmis",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xrow=" + xrow1);
                    string xname1 = zglobal.fnGetValue("xname", "amadmis",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xrow=" + xrow1);

                    if (xstdid1 != "")
                    {
                        xstdid.Text = xstdid1;
                        xclass.Text = xclass1;
                        xgroup.Text = xgroup1;
                        xsession.Text = xsession1;
                        xname.Text = xname1;
                        btnGenerateID.Enabled = false;
                        ViewState["xstdid"] = xrow1;
                    }
                    else
                    {
                        xstdid.Text = xstdid1;
                        xclass.Text = xclass1;
                        xgroup.Text = xgroup1;
                        xsession.Text = xsession1;
                        xname.Text = xname1;
                        btnGenerateID.Enabled = true;
                        ViewState["xstdid"] = null;
                        message.Style.Value = zglobal.warningmsg;
                        message.InnerHtml =
                            "<font style='font-size:16'>Please generate 'Student ID' before create receipt.</font>";

                    }

                    ViewState["xtype"] = "Admission";

                    //string xfperiod = zglobal.fnGetValue("xfperiod", "amdefaults",
                    //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    //    " and xtype='Student'");
                    //string xtperiod = zglobal.fnGetValue("xtperiod", "amdefaults",
                    //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    //    " and xtype='Student'");

                    //zglobal.fnGetComboDataCalendar(xcdate, Convert.ToDateTime(xfperiod), Convert.ToDateTime(xtperiod));

                    //xcdate.Text = DateTime.Now.ToString("MMM-yyyy");

                    zglobal.fnGetComboDataCalendar(xcdate, Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
                    xcdate.Text = DateTime.Now.ToString("MMM-yyyy");

                    string xrow = zglobal.fnGetValue("xrow", "amtfch",
                                   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                                   " AND xsrow=" + Convert.ToInt64(ViewState["xrow1"]) + " AND xtype='Admission' AND xsession='" + xsession.Text.Trim().ToString() + "'");
                    if (xrow != "")
                    {
                        ViewState["xrow"] = xrow;
                        hiddenxrow.Value = xrow.ToString();

                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        DataSet dts = new DataSet();

                        dts.Reset();

                        if (ViewState["xrow"] != null)
                        {
                            string str1 =
                           "SELECT  * FROM amtfch where zid=@zid and xrow=@xrow";

                            SqlDataAdapter da1 = new SqlDataAdapter(str1, conn1);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            da1.Fill(dts, "tempztcode");
                            DataTable dtmarks1 = new DataTable();
                            dtmarks1 = dts.Tables[0];
                            if (dtmarks1.Rows.Count > 0)
                            {
                                xcdate.Enabled = false;
                                DateTime xcdate1 = Convert.ToDateTime(dtmarks1.Rows[0]["xcdate"]);
                                string month1 = zgetvalue.GetMonthName(xcdate1.Month);
                                string year1 = xcdate1.Year.ToString();

                                xcdate.Text = month1 + "-" + year1;

                                xtdate.Text = Convert.ToDateTime(dtmarks1.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
                                xbank.Text = dtmarks1.Rows[0]["xbank"].ToString();
                                xchqdate.Text = Convert.ToDateTime(dtmarks1.Rows[0]["xchqdate"]).ToString("dd/MM/yyyy");
                                xchqno.Text = dtmarks1.Rows[0]["xchqno"].ToString();
                                xremarks.Text = dtmarks1.Rows[0]["xremarks"].ToString();
                                xadvreceive.Text = dtmarks1.Rows[0]["xadvreceive"]==DBNull.Value?"":dtmarks1.Rows[0]["xadvreceive"].ToString();
                            }
                        }
                    }
                    else
                    {
                        ViewState["xrow"] = null;
                        hiddenxrow.Value = "";
                    }

                    btnRefresh.Visible = false;
                    btnRefresh1.Visible = false;
                    btnPaid.Visible = false;
                    btnPaid1.Visible = false;


                }




                //xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
                //   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xcode='" +
                //   xtfccode.Text.ToString().Trim() + "'" + "and xtype='TFC Code' and zactive=1");

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //    xstdid.Text.ToString().Trim() +"'");

                BindGrid();
                //fnRegisterPostBack();
                fnButtonState();

                //TextBox txtbox = GridView1.Rows[0].Cells[0].FindControl("xreceived") as TextBox;
                //txtbox.Focus();
                //txtbox.Attributes.Add("onfocus", "javascript:this.select();");
                xcdate.Focus();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnRegisterPostBack()
        {
            //foreach (GridViewRow row in dgvTFCListNew.Rows)
            //{
            //    LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            //}

            //foreach (GridViewRow row in dgvTFCListSubmitted.Rows)
            //{
            //    LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            //}
        }

        private BoundField bfield;
        private TemplateField tfield;
        private DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        private decimal xnettotal2 = 0;
        private decimal xnettotal1 = 0;
        private decimal xreceived = 0;

        private void BindGrid()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            
            xnettotal1 = 0;
            xnettotal2 = 0;
            xreceived = 0;

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();


            string xclass1 = xclass.Text.Trim().ToString();
            string xgroup1 = xgroup.Text.Trim().ToString();
          
            string str = "";

            string[] date = new string[2];
            if (xcdate.Text.ToString().Trim() == "")
            {
                date[0] = "Jan";
                date[1] = "1800";
            }
            else
            {
                date = xcdate.Text.Split('-');
            }

            int year = Int32.Parse(date[1]);
            int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
            DateTime xeffdate1 = new DateTime(year, month, 1);
            int xrow1;
          
            ViewState["xstatus"] = "";
            ViewState["amtfcd"] = null;

            if (ViewState["xrow"] != null)
            {

                

                string xstatus1 = zglobal.fnGetValue("xstatus", "amtfch",
                       "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                ViewState["xstatus"] = xstatus1;

                //if (xstatus1 != "Paid")
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts1 = new DataSet())
                        {
                            string query = "SELECT * FROM amtfcd WHERE zid=@zid AND xrow=@xrow";
                            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                            da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
                            da1.Fill(dts1, "tblamadmisd");
                            amexamd = dts1.Tables[0];
                            if (amexamd.Rows.Count > 0)
                            {
                                ViewState["amtfcd"] = amexamd;
                            }
                            else
                            {
                                ViewState["amtfcd"] = null;
                            }
                        }
                    }
                }
            }

            
            if (ViewState["xrow"] != null)
            {
               // str =
               //     "SELECT  xtfccode,xdescdet,xtype,xamount as xnettotal1,xreceived,xremarks1,xspecialdis,xspecialdistype, " +
               //     "cast(case when xspecialdistype='%' then xamount - (xamount*xspecialdis/100) else xamount-xspecialdis end as decimal(18,2)) as xnetamount " +
               //     "FROM amtfcvw " +
               //     "WHERE zid=@zid AND xrow=@xrow ";// +
               ////"ORDER BY xsequence";
               /// 

                str = zglobal.xtfcdefault;

                xrow1 = Convert.ToInt32(ViewState["xrow"].ToString());
            }
            else
            {
                str = zglobal.xtfcdefault;
                xrow1 = 0;
            }



            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            da.SelectCommand.Parameters.AddWithValue("@xsrow", ViewState["xrow1"]);
            da.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = zglobal.fntfcSpecialDiscount();
                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsrow", ViewState["xrow1"]);
                        da1.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                        da1.Fill(dts1, "tblamadmisd");
                        DataTable amexamd11 = dts1.Tables[0];
                        if (amexamd11.Rows.Count > 0)
                        {
                            ViewState["amtfcspecialdis"] = amexamd11;
                        }
                        else
                        {
                            ViewState["amtfcspecialdis"] = null;
                        }
                    }
                }


                GridView1.Columns.Clear();


                bfield = new BoundField();
                bfield.HeaderText = "TFC Code";
                bfield.DataField = "xtfccode";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.ItemStyle.Width = 80;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Description";
                bfield.DataField = "xdescdet";
                bfield.ItemStyle.Width = 250;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Default Amount";
                bfield.DataField = "xnettotal1";
                bfield.ItemStyle.Width = 120;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                GridView1.Columns.Add(bfield);

                tfield = new TemplateField();
                tfield.HeaderText = "Special Discount";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 120;
                GridView1.Columns.Add(tfield);

                tfield = new TemplateField();
                tfield.HeaderText = "";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 50;
                GridView1.Columns.Add(tfield);

                //bfield = new BoundField();
                //bfield.HeaderText = "Net Amount";
                //bfield.DataField = "xnetamount";
                //bfield.ItemStyle.Width = 120;
                //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                //GridView1.Columns.Add(bfield);

                tfield = new TemplateField();
                tfield.HeaderText = "Net Amount";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 120;
                GridView1.Columns.Add(tfield);

                

                tfield = new TemplateField();
                tfield.HeaderText = "Received Amount";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 120;
                GridView1.Columns.Add(tfield);

               

                tfield = new TemplateField();
                tfield.HeaderText = "Remarks";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 300;
                GridView1.Columns.Add(tfield);

                TemplateField tfield3 = new TemplateField();
                tfield3.HeaderText = "";
                tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield3);




                

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

               

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

        }

        private TextBox txTextBox;

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.DataSource == null)
                {
                    return;
                }

                //CheckBox chkCheckBox = new CheckBox();
                //chkCheckBox.ID = "chkall";
                //GridView1.HeaderRow.Cells[0].Controls.Add(chkCheckBox);


                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    TextBox xrec = (TextBox)row.FindControl("xreceived");
                //    //message.InnerHtml = xrec.Text.ToString() + "<br>";
                //    //xreceived += Convert.ToDecimal(xrec.Text.ToString().Trim() != "" ? xrec.Text.ToString().Trim() : "0");
                //    //decimal sum;
                //    //if (decimal.TryParse(xrec.Text.Trim(), out sum))
                //    //{
                //    //    xreceived += sum;
                //    //}

                //    //if (xrec.Text == "")
                //    //{
                //    //    xrec.Text = row.Cells[6].Text;
                //    //}

                //    if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
                //    {
                //        ////getmarks = 0;
                //        //getmarks = -1;
                //        xrec.Text = row.Cells[6].Text.ToString();
                //    }
                //    //else
                //    //{
                //    xreceived += decimal.Parse(xrec.Text.Trim().ToString());
                //    //}
                //}

                //GridView1.FooterRow.Cells[7].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //GridView1.FooterRow.Cells[7].Font.Bold = true;
                //GridView1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                //GridView1.FooterRow.Cells[7].ForeColor = Color.White;


                //if (ViewState["xrow"] != null)
                //{
                //    fnCalTotal();
                //}

                //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                //TableHeaderCell cell = new TableHeaderCell();

                //GridView1.HeaderRow.Cells[0].Visible = false;
                //GridView1.HeaderRow.Cells[1].Visible = false;
                //GridView1.HeaderRow.Cells[2].Visible = false;
                //GridView1.HeaderRow.Cells[6].Visible = false;
                //GridView1.HeaderRow.Cells[10].Visible = false;
                //GridView1.HeaderRow.Cells[11].Visible = false;
                //GridView1.HeaderRow.Cells[12].Visible = false;
                //GridView1.HeaderRow.Cells[13].Visible = false;
                //GridView1.HeaderRow.Cells[14].Visible = false;

                //cell = new TableHeaderCell();
                //cell.Text = "TFC Code";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Description";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Default Amount";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Discount";
                //cell.BorderStyle = BorderStyle.Solid;
                //cell.BorderWidth = 2;
                //cell.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
                //cell.ColumnSpan = 3;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Net Total <br> (After Discount)";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "VAT";
                //cell.BorderStyle = BorderStyle.Solid;
                //cell.BorderWidth = 2;
                //cell.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
                //cell.ColumnSpan = 3;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Net Total <br> (Including VAT)";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Received <br> Amount";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Due <br> Amount";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Remarks";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //GridView1.HeaderRow.Parent.Controls.AddAt(0, row);


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
                    xnettotal1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xnettotal1"));

                    TextBox txtDiscount = new TextBox();
                    txtDiscount.ID = "xdiscount";
                    txtDiscount.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xdiscount";
                    txtDiscount.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[3].Controls.Add(txtDiscount);

                    DropDownList dpDisType = new DropDownList();
                    dpDisType.ID = "xdistype";
                    dpDisType.Items.Add("%");
                    dpDisType.Items.Add("Fixed");
                    //dpDisType.AutoPostBack = true;
                    //dpDisType.SelectedIndexChanged += dpDisType_SelectedIndexChanged;
                    e.Row.Cells[4].Controls.Add(dpDisType);

                    TextBox txtReceive = new TextBox();
                    txtReceive.ID = "xreceived";
                    txtReceive.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xreceive";
                    txtReceive.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[6].Controls.Add(txtReceive);

                    TextBox txtRemarks = new TextBox();
                    txtRemarks.ID = "xremarks";
                    txtRemarks.CssClass = "xremarks";
                    txtRemarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    txtRemarks.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[7].Controls.Add(txtRemarks);

                    if (ViewState["amtfcd"] != null)
                    {
                        //DataTable dt = new DataTable();
                        //dt = ViewState["amtfcd"] as DataTable;
                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    if (row["xtfccode"].ToString() == e.Row.Cells[0].Text.ToString())
                        //    {

                        //        txtReceive.Text = row["xreceived"].ToString();
                        //        txtRemarks.Text = row["xremarks"].ToString();

                        //        xreceived += Convert.ToDecimal(row["xreceived"]);
                        //        break;
                        //    }
                        //}

                        DataRow[] result800 =
                        ((DataTable)ViewState["amtfcd"]).Select("xtfccode=" + e.Row.Cells[0].Text);
                        if (result800.Length > 0)
                        {
                            txtReceive.Text = result800[0]["xreceived"].ToString();
                            txtRemarks.Text = result800[0]["xremarks"].ToString();

                            xreceived += Convert.ToDecimal(result800[0]["xreceived"].ToString().Trim());
                        }

                    }

                    //string xspecialdistype = (e.Row.DataItem as DataRowView).Row["xspecialdistype"].ToString();
                    //dpDisType.Text = xspecialdistype;
                    //txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xspecialdis"].ToString();

                    ////if ((e.Row.DataItem as DataRowView).Row["xspecialdis"].ToString() == "0.00" ||
                    ////    (e.Row.DataItem as DataRowView).Row["xspecialdis"].ToString() == "0")
                    ////{
                    ////    txtDiscount.Enabled = false;
                    ////    txtDiscount.BackColor = Color.Transparent;

                    ////    dpDisType.Enabled = false;
                    ////}

                    ////string xtype1 = zglobal.fnProperty("TFC Code",(e.Row.DataItem as DataRowView).Row["xtfccode"].ToString(), "xtype");
                    ////if (xtype1 == "" || xtype1 == "N/A")
                    ////{
                    //    txtDiscount.Enabled = false;
                    //    txtDiscount.BackColor = Color.Transparent;

                    //    dpDisType.Enabled = false;
                    ////}

                    //xnettotal2 += Convert.ToDecimal(e.Row.Cells[5].Text);

                    if (ViewState["amtfcspecialdis"] != null)
                    {


                        DataRow[] result80 =
                            ((DataTable)ViewState["amtfcspecialdis"]).Select("xtfccode=" + e.Row.Cells[0].Text);
                        if (result80.Length > 0)
                        {
                            if (result80[0]["xdisperc"].ToString() == "0.00" ||
                                result80[0]["xdisperc"].ToString() == "0")
                            {
                                dpDisType.Text = "Fixed";
                                txtDiscount.Text = result80[0]["xdisfixed"].ToString();
                                e.Row.Cells[5].Text = ((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xnettotal1")) - Convert.ToDecimal(result80[0]["xdisfixed"].ToString()))).ToString("F");
                            }
                            else
                            {
                                dpDisType.Text = "%";
                                txtDiscount.Text = result80[0]["xdisperc"].ToString();
                                e.Row.Cells[5].Text = ((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xnettotal1")) - (Convert.ToDecimal(result80[0]["xdisperc"].ToString()) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xnettotal1")) / 100))).ToString("F");
                            }
                        }
                        else
                        {

                            dpDisType.Text = "%";
                            txtDiscount.Text = "0.00";
                            e.Row.Cells[5].Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "xnettotal1"));
                        }

                    }
                    else
                    {
                      
                        dpDisType.Text = "%";
                        txtDiscount.Text = "0.00";
                        e.Row.Cells[5].Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "xnettotal1"));
                     

                    }


                    txtDiscount.Enabled = false;
                    txtDiscount.BackColor = Color.Transparent;
                    txtDiscount.ForeColor = Color.Black;

                    dpDisType.Enabled = false;
                    dpDisType.ForeColor = Color.Black;
                    dpDisType.BackColor = Color.Transparent;
                    dpDisType.BorderStyle = BorderStyle.None;
                    dpDisType.Style.Add("-webkit-appearance", "none;");

                    xnettotal2 += Convert.ToDecimal(e.Row.Cells[5].Text);

                    if (ViewState["xstatus"] != null)
                    {
                        if (ViewState["xstatus"].ToString() == "Paid")
                        {
                            txtReceive.Enabled = false;
                            txtRemarks.Enabled = false;

                            //txtReceive.Text = (e.Row.DataItem as DataRowView).Row["xreceived"].ToString();
                            //txtRemarks.Text = (e.Row.DataItem as DataRowView).Row["xremarks1"].ToString();

                            //xreceived += Convert.ToDecimal((e.Row.DataItem as DataRowView).Row["xreceived"].ToString());
                        }

                    }
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[1].Text = "Total :";
                    e.Row.Cells[1].Font.Bold = true;
                    e.Row.Cells[1].ForeColor = Color.White;
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[2].Text = xnettotal1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                    e.Row.Cells[2].Font.Bold = true;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[2].ForeColor = Color.White;

                    e.Row.Cells[5].Text = xnettotal2.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                    e.Row.Cells[5].Font.Bold = true;
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[5].ForeColor = Color.White;

                    e.Row.Cells[6].Font.Bold = true;
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[6].ForeColor = Color.White;

                    if (ViewState["xrow"] != null)
                    {
                        e.Row.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
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

                //    _xtdate.Value = row.Cells[2 + (int) ViewState["rowCount"]].Text.ToString();
                //    _xperiod.Value = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //    _xsection.Value = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {
                //        using (DataSet dts = new DataSet())
                //        {
                //            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //            int xrow = Convert.ToInt32(ViewState["xrow"]);
                //            DateTime xtdate2 = Convert.ToDateTime(row.Cells[2 + (int)ViewState["rowCount"]].Text);
                //            string xperiod2 = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //            string xsection2 = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //            string query = "SELECT xsubject,xpaper,xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, " +
                //                " (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1,xcteacher,xsteacher FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcdate=@xcdate and xtdate=@xtdate";
                //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                //            da.SelectCommand.Parameters.AddWithValue("@xcdate", xperiod2);
                //            da.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate2);
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

            //        //    _xtdate.Value = row.Cells[2 + (int) ViewState["rowCount"]].Text.ToString();
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
            //        string query;

            //        //if (xctno.Text != "")
            //        //{
            //        //    query =
            //        //    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno AND xtdate=@xtdate";
            //        //}
            //        //else
            //        // {
            //        query =
            //        "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xcttype=@xcttype AND xctno=@xctno";
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
            //        da.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xcttype", xcttype.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xctno", xctno.Text.ToString().Trim());
            //        DateTime xtdate1 = xtdate.Text.Trim() != string.Empty
            //                    ? DateTime.ParseExact(xtdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //        da.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate1);


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

        protected void btnGenerateID_Click(object sender, EventArgs e)
        {
            try
            {
                if (zglobal.fnGetValue("xstdid", "amadmis",
                    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    " and xrow=" + Convert.ToInt32(ViewState["xrow1"])) != "")
                {
                    message.InnerHtml = "Already have ID. Can not generate ID.";
                    message.Style.Value = zglobal.warningmsg;
                }

                string xiddigit;
                string xidstart;
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                xiddigit = zglobal.fnGetValue("xiddigit", "amdefaults",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xtype='Student'");

                xidstart = zglobal.fnGetValue("xidstart", "amdefaults",
                       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                       " and xtype='Student'");

                //Duplicate entry check
                using (SqlConnection conn1 = new SqlConnection(zglobal.constring))
                {
                    string qur = "SELECT COUNT(*) FROM amadmis WHERE zid=@zid AND xstdid=(SELECT COALESCE( " +
                            "CAST(REPLICATE(0,@xiddigit- " +
                            "LEN(CAST(RIGHT(MAX(xstdid),@xiddigit) as int)+1)) as varchar(10)) + " +
                            "CAST(CAST(RIGHT(MAX(xstdid),@xiddigit) as int)+1 as varchar(10)), " +
                            "@xidstart) as maxid FROM amadmis) ";

                    SqlParameter objParameter = null;

                    SqlCommand cmd1 = new SqlCommand(qur, conn1);
                    objParameter = cmd1.Parameters.Add("zid", SqlDbType.Int);
                    objParameter = cmd1.Parameters.Add("xstdid", SqlDbType.VarChar);
                    objParameter = cmd1.Parameters.Add("xiddigit", SqlDbType.Int);
                    objParameter = cmd1.Parameters.Add("xidstart", SqlDbType.Int);

                    cmd1.Parameters["zid"].Value = _zid;
                    cmd1.Parameters["xstdid"].Value = xstdid.Text.ToString().Trim();
                    cmd1.Parameters["xiddigit"].Value  = Convert.ToInt32(xiddigit);
                    cmd1.Parameters["xidstart"].Value = Convert.ToInt32(xidstart);
                    conn1.Open();
                    int temp = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                    conn1.Close();
                    if (temp > 1)
                    {
                        message.InnerHtml = "Duplicate Student ID. Generate ID Faild. Please contact with system administrator.";
                        message.Style.Value = zglobal.am_warningmsg;
                        return;
                    }
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



                        string query =
                            "UPDATE amadmis SET xstdid=(SELECT COALESCE( " +
                            "CAST(REPLICATE(0,@xiddigit- " +
                            "LEN(CAST(RIGHT(MAX(xstdid),@xiddigit) as int)+1)) as varchar(10)) + " +
                            "CAST(CAST(RIGHT(MAX(xstdid),@xiddigit) as int)+1 as varchar(10)), " +
                            "@xidstart) as maxid FROM amadmis) " +
                            "WHERE zid=@zid AND xrow=@xrow ";
                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt64(ViewState["xrow1"]));
                        cmd.Parameters.AddWithValue("@xiddigit", xiddigit);
                        cmd.Parameters.AddWithValue("@xidstart", xidstart);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Complete();
                }

                //ViewState["xrow"] = ViewState["xrow1"];
                xstdid.Text = zglobal.fnGetValue("xstdid", "amadmis",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xrow=" + Convert.ToInt64(ViewState["xrow1"]));
                ViewState["xstdid"] = xstdid.Text.Trim().ToString();
                fnButtonState();
                message.InnerHtml = "";


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //btnRefresh_Click(sender,e);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = 0;
                message.InnerHtml = "";

                fnCalTotal();
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

                if (xstdid.Text == "" || xstdid.Text == string.Empty || xstdid.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Student ID</li>";
                    isValid = false;
                }
                if (xcdate.Text == "" || xcdate.Text == string.Empty || xcdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Charge Period</li>";
                    isValid = false;
                }
                if (xtdate.Text == "" || xtdate.Text == string.Empty || xtdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Transaction Date</li>";
                    isValid = false;
                }
                if (xbank.Text == "" || xbank.Text == string.Empty || xbank.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Bank Name</li>";
                    isValid = false;
                }
                if (xadvreceive.Text == "" || xadvreceive.Text == string.Empty || xadvreceive.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Advance Received</li>";
                    isValid = false;
                }
                

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                //string xrow1 = zglobal.fnGetValue("xrow", "amtfch",
                //                   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                //                   " AND xsrow=" + Convert.ToInt64(ViewState["xrow1"]) + " AND xtype='Admission' AND xsession='" + xsession.Text.Trim().ToString() + "'");
                //if (xrow1 != "")
                //{
                //    ViewState["xrow"] = xrow;
                //}
                //else
                //{
                //    ViewState["xrow"] = null;
                //}
                //fnCheckRow();
                string xstatus2 = "";
                if (ViewState["xrow"] != null)
                {
                    xstatus2 = zglobal.fnGetValue("xstatus", "amtfch",
                          "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                    if (xstatus2 != "New" && xstatus2 != "Undo" && xstatus2 != "Undo1")
                    {
                        message.InnerHtml = "Status : " + xstatus2 + "Cann't change data.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }


                DateTime xdate111 = xtdate.Text.ToString().Trim() != string.Empty
                               ? DateTime.ParseExact(xtdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture)
                               : DateTime.Now;

                int offset;
                int per1;
                int year1 = xdate111.Year;

                int tempper;
                int tempyear;

                offset = zglobal.fnGetValueInt("xinteger", "msstatus",
                    "zid=" + _zid + " and xtypestatus='GL Period Offset'");

                per1 = 12 + xdate111.Month - offset;

                if (per1 <= 12)
                {
                    tempper = per1;
                    tempyear = year1 - 1;
                }
                else
                {
                    tempper = per1 - 12;
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
                        //globalerr = 1;
                        return;
                    }
                }
                else
                {
                    message.InnerText = "Post/Previous Month's Data Entry Not Allowed";
                    message.Style.Value = zglobal.warningmsg;
                    //globalerr = 1;
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
                Int64 xsrow1 = Convert.ToInt64(ViewState["xrow1"]);
                string xsession1 = xsession.Text.Trim().ToString();
                DateTime xcdate1 = xdate1;
                DateTime xtdate1 = DateTime.Now;
                string xbank1 = "";
                DateTime xchqdate1 = new DateTime(2999, 12, 31);
                string xchqno1 = "";
                string xstatus1 = "New";
                string xremarks1 = "";
                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xpaidby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                DateTime xpaiddt = DateTime.Now;
                string xadvreceive1 = "";



                using (TransactionScope tran = new TransactionScope())
                {
                    //if (GridView1.Rows.Count > 0)
                    //{
                    if (ViewState["xrow"] == null)
                    {


                        //Duplicate entry check
                        using (SqlConnection con = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts = new DataSet())
                            {
                                con.Open();
                                string query =
                                    "SELECT * FROM amtfch WHERE zid=@zid AND xsrow=@xsrow AND xtype=@xtype AND xcdate=@xcdate AND xsession=@xsession ";

                                SqlDataAdapter da = new SqlDataAdapter(query, con);

                                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow1);
                                da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
                                da.SelectCommand.Parameters.AddWithValue("@xcdate", xcdate1);
                                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);


                                DataTable tempTable = new DataTable();
                                da.Fill(dts, "tempTable");
                                tempTable = dts.Tables["tempTable"];

                                if (tempTable.Rows.Count > 0)
                                {
                                    message.InnerHtml = "Cann't insert duplicate record.";
                                    message.Style.Value = zglobal.warningmsg;
                                    return;
                                }
                            }
                        }


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


                            string query =
                                "INSERT INTO amtfch (ztime,zid,xrow,xtype,xsrow,xcdate,xtdate,xbank,xchqdate,xchqno,xstatus,zemail,xsession,xremarks,xclass,xadvreceive) " +
                                "VALUES(@ztime,@zid,@xrow,@xtype,@xsrow,@xcdate,@xtdate,@xbank,@xchqdate,@xchqno,@xstatus,@zemail,@xsession,@xremarks," +
                                "@xclass,@xadvreceive ) ";

                            xrow = zglobal.GetMaximumInvoiceResetMonthlyBusiness("xcdate", "xrow", "amtfch", xcdate1); //zglobal.GetMaximumIdInt("xrow", "amtfch", " zid=" + _zid, 1, 1);
                            ViewState["xrow"] = xrow;
                            hiddenxrow.Value = xrow.ToString();
                            xtdate1 = xtdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xtdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.Now;

                            xbank1 = xbank.Text.Trim().ToString();
                            xchqdate1 = xchqdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xchqdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : new DateTime(2999, 12, 31);

                            xchqno1 = xchqno.Text.Trim().ToString();
                            xsession1 = xsession.Text.ToString().Trim();
                            xremarks1 = xremarks.Text.Trim().ToString();
                            xadvreceive1 = xadvreceive.Text.Trim().ToString();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", xrow);
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                            cmd.Parameters.AddWithValue("@xcdate", xcdate1);
                            cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                            cmd.Parameters.AddWithValue("@xbank", xbank1);
                            cmd.Parameters.AddWithValue("@xchqdate", xchqdate1);
                            cmd.Parameters.AddWithValue("@xchqno", xchqno1);
                            cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.Parameters.AddWithValue("@xsession", xsession1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                            cmd.Parameters.AddWithValue("@xstdid", xstdid.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xadvreceive", xadvreceive1);
                            cmd.ExecuteNonQuery();
                        }
                    }



                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        string query = "DELETE FROM amtfcd WHERE zid=@zid AND xrow=@xrow";
                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                        //if (xstatus1 != "Undo1" && xstatus1 != "Undo")
                        //if (xstatus1 != "Undo1")
                        //{
                        cmd.ExecuteNonQuery();
                        //}

                        xtdate1 = xtdate.Text.ToString().Trim() != string.Empty
                               ? DateTime.ParseExact(xtdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture)
                               : DateTime.Now;

                        query = "UPDATE amadmis SET xadmitdate=@xadmitdate WHERE zid=@zid AND xrow=@xsrow";
                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                        cmd.Parameters.AddWithValue("@xadmitdate", xtdate1);
                        cmd.ExecuteNonQuery();


                        if (xrow == 0)
                        {

                            xtdate1 = xtdate.Text.ToString().Trim() != string.Empty
                                 ? DateTime.ParseExact(xtdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                     CultureInfo.InvariantCulture)
                                 : DateTime.Now;
                            xbank1 = xbank.Text.Trim().ToString();
                            xchqdate1 = xchqdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xchqdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : new DateTime(2999, 12, 31);

                            xchqno1 = xchqno.Text.Trim().ToString();
                            xremarks1 = xremarks.Text.Trim().ToString();
                            xadvreceive1 = xadvreceive.Text.Trim().ToString();

                            query = "UPDATE amtfch SET zutime=@zutime,xemail=@xemail, " +
                                   "xtdate=@xtdate,xbank=@xbank,xchqdate=@xchqdate, xchqno=@xchqno, xremarks=@xremarks, " +
                                    "xclass=@xclass, xadvreceive=@xadvreceive " +
                                   "WHERE zid=@zid AND xrow=@xrow ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@xemail",
                                Convert.ToString(HttpContext.Current.Session["curuser"]));
                            cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                            cmd.Parameters.AddWithValue("@xbank", xbank1);
                            cmd.Parameters.AddWithValue("@xchqdate", xchqdate1);
                            cmd.Parameters.AddWithValue("@xchqno", xchqno1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                            cmd.Parameters.AddWithValue("@xstdid", xstdid.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xadvreceive", xadvreceive1);
                            cmd.ExecuteNonQuery();


                        }



                        //int flag = 0;
                        //foreach (GridViewRow row in GridView1.Rows)
                        //{


                        //    TextBox txtTextBox1 = row.FindControl("txtMarks") as TextBox;
                        //    decimal getmarks;
                        //    if (txtTextBox1.Text.Trim().ToString() == "" || txtTextBox1.Text.Trim().ToString() == String.Empty)
                        //    {
                        //        getmarks = 0;
                        //    }
                        //    else
                        //    {
                        //        getmarks = decimal.Parse(txtTextBox1.Text.Trim().ToString());
                        //    }

                        //    if (getmarks > decimal.Parse(xmarks.Text.Trim().ToString()))
                        //    {
                        //        row.BackColor = zglobal.rowerr;
                        //        flag = 1;
                        //    }
                        //}

                        //if (flag == 1)
                        //{
                        //    message.InnerText = "Student marks can not greater than exam marks.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}


                        foreach (GridViewRow row in GridView1.Rows)
                        {

                            int xline = zglobal.GetMaximumIdInt("xline", "amtfcd", " zid=" + _zid + " and xrow=" + Convert.ToInt32(ViewState["xrow"]), "line");
                            TextBox txtTextBox1 = row.FindControl("xreceived") as TextBox;
                            TextBox txtxremarks = row.FindControl("xremarks") as TextBox;
                            //TextBox txtxdisfixed = row.FindControl("xdisfixed") as TextBox;
                            //TextBox txtxdisperc = row.FindControl("xdisperc") as TextBox;
                            //TextBox txtxvatfixed = row.FindControl("xvatfixed") as TextBox;
                            //TextBox txtxvatperc = row.FindControl("xvatperc") as TextBox;
                            TextBox xdiscount12 = row.FindControl("xdiscount") as TextBox;
                            DropDownList xdistype12 = row.FindControl("xdistype") as DropDownList;

                            if (xdiscount12.Text.Trim() == "" || xdiscount12.Text.Trim() == String.Empty)
                            {
                                xdiscount12.Text = "0";
                            }

                            decimal xspecialdisfixed1 = 0;
                            decimal xspecialdisperc1 = 0;

                            if (xdistype12.Text == "%")
                            {
                                xspecialdisperc1 = decimal.Parse(xdiscount12.Text.Trim());
                            }
                            else
                            {
                                xspecialdisfixed1 = decimal.Parse(xdiscount12.Text.Trim());
                            }

                            decimal xreceived12;
                            //decimal xdisfixed12;
                            //decimal xdisperc12;
                            //decimal xvatfixed12;
                            //decimal xvatperc12;

                            if (txtTextBox1.Text.Trim().ToString() == "" || txtTextBox1.Text.Trim().ToString() == String.Empty)
                            {
                                //getmarks = 0;
                                xreceived12 = 0;
                            }
                            else
                            {
                                xreceived12 = decimal.Parse(txtTextBox1.Text.Trim().ToString());
                            }

                            //if (txtxdisfixed.Text.Trim().ToString() == "" || txtxdisfixed.Text.Trim().ToString() == String.Empty)
                            //{
                            //    //getmarks = 0;
                            //    xdisfixed12 = 0;
                            //}
                            //else
                            //{
                            //    xdisfixed12 = decimal.Parse(txtxdisfixed.Text.Trim().ToString());
                            //}

                            //if (txtxdisperc.Text.Trim().ToString() == "" || txtxdisperc.Text.Trim().ToString() == String.Empty)
                            //{
                            //    //getmarks = 0;
                            //    xdisperc12 = 0;
                            //}
                            //else
                            //{
                            //    xdisperc12 = decimal.Parse(txtxdisperc.Text.Trim().ToString());
                            //}

                            //if (txtxvatfixed.Text.Trim().ToString() == "" || txtxvatfixed.Text.Trim().ToString() == String.Empty)
                            //{
                            //    //getmarks = 0;
                            //    xvatfixed12 = 0;
                            //}
                            //else
                            //{
                            //    xvatfixed12 = decimal.Parse(txtxvatfixed.Text.Trim().ToString());
                            //}

                            //if (txtxvatperc.Text.Trim().ToString() == "" || txtxvatperc.Text.Trim().ToString() == String.Empty)
                            //{
                            //    //getmarks = 0;
                            //    xvatperc12 = 0;
                            //}
                            //else
                            //{
                            //    xvatperc12 = decimal.Parse(txtxvatperc.Text.Trim().ToString());
                            //}


                            decimal xamount12 = decimal.Parse(row.Cells[2].Text.ToString());
                            //decimal xdiscount12 = decimal.Parse(row.Cells[5].Text.ToString());
                            //decimal xvat12 = decimal.Parse(row.Cells[9].Text.ToString());

                            query = "INSERT INTO amtfcd (zid,xrow,xline,xtfccode,xamount,xdisfixed,xdisperc,xdiscount,xvatfixed,xvatperc,xvat,xreceived,xremarks,xspecialdisfixed,xspecialdisperc) " +
                                    "VALUES(@zid,@xrow,@xline,@xtfccode,@xamount,@xdisfixed,@xdisperc,@xdiscount,@xvatfixed,@xvatperc,@xvat,@xreceived,@xremarks,@xspecialdisfixed,@xspecialdisperc) ";

                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            cmd.Parameters.AddWithValue("@xline", xline);
                            cmd.Parameters.AddWithValue("@xtfccode", row.Cells[0].Text.ToString());
                            cmd.Parameters.AddWithValue("@xamount", xamount12);
                            cmd.Parameters.AddWithValue("@xdisfixed", decimal.Parse("0"));
                            cmd.Parameters.AddWithValue("@xdisperc", decimal.Parse("0"));
                            cmd.Parameters.AddWithValue("@xdiscount", decimal.Parse("0"));
                            cmd.Parameters.AddWithValue("@xvatfixed", decimal.Parse("0"));
                            cmd.Parameters.AddWithValue("@xvatperc", decimal.Parse("0"));
                            cmd.Parameters.AddWithValue("@xvat", decimal.Parse("0"));
                            cmd.Parameters.AddWithValue("@xspecialdisfixed", xspecialdisfixed1);
                            cmd.Parameters.AddWithValue("@xspecialdisperc", xspecialdisperc1);
                            cmd.Parameters.AddWithValue("@xreceived", xreceived12);
                            cmd.Parameters.AddWithValue("@xremarks", txtxremarks.Text.Trim().ToString());
                            cmd.ExecuteNonQuery();


                        }
                    }


                    tran.Complete();

                }




                //BindGrid();



                fnButtonState();

                //fnCalTotal();
                //fnFillGrid2();

                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                // btnRefresh_Click(null, null);
                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;
                //ViewState["xrow"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";
                xcdate.Enabled = false;

              
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnCalTotal()
        {
            //xdefault = 0;
            //xdiscount = 0;
            //xnettotal = 0;
            //xvat = 0;
            xnettotal1 = 0;
            xreceived = 0;
            xnettotal2 = 0;
            //xdisfixed = 0;
            //xdisperc = 0;
            //xvatfixed = 0;
            //xvatperc = 0;
            //xdue = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox xrec = (TextBox)row.FindControl("xreceived");
                //TextBox xdisfixed1 = (TextBox)row.FindControl("xdisfixed");
                //TextBox xdisperc1 = (TextBox)row.FindControl("xdisperc");
                //TextBox xvatfixed1 = (TextBox)row.FindControl("xvatfixed");
                //TextBox xvatperc1 = (TextBox)row.FindControl("xvatperc");
                //message.InnerHtml = xrec.Text.ToString() + "<br>";
                //xreceived += Convert.ToDecimal(xrec.Text.ToString().Trim() != "" ? xrec.Text.ToString().Trim() : "0");
                //decimal sum;
                //if (decimal.TryParse(xrec.Text.Trim(), out sum))
                //{
                //    xreceived += sum;
                //}

                //if (xrec.Text == "")
                //{
                //    xrec.Text = row.Cells[6].Text;
                //}

                if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
                {
                    xrec.Text = "0.00";
                }

                if (row.Cells[5].Text.ToString() == "" || row.Cells[5].Text.ToString() == String.Empty)
                {
                    row.Cells[5].Text = "0";
                }

                //if (xdisfixed1.Text.Trim().ToString() == "" || xdisfixed1.Text.Trim().ToString() == String.Empty)
                //{
                //    xdisfixed1.Text = "0.00";
                //}
                //if (xdisperc1.Text.Trim().ToString() == "" || xdisperc1.Text.Trim().ToString() == String.Empty)
                //{
                //    xdisperc1.Text = "0.00";
                //}
                //if (xvatfixed1.Text.Trim().ToString() == "" || xvatfixed1.Text.Trim().ToString() == String.Empty)
                //{
                //    xvatfixed1.Text = "0.00";
                //}
                //if (xvatperc1.Text.Trim().ToString() == "" || xvatperc1.Text.Trim().ToString() == String.Empty)
                //{
                //    xvatperc1.Text = "0.00";
                //}
                //else
                //{
                xreceived += decimal.Parse(xrec.Text.Trim().ToString());
                xnettotal1 += decimal.Parse(row.Cells[2].Text.ToString());
                xnettotal2 += decimal.Parse(row.Cells[5].Text.ToString());
                //xdisfixed += decimal.Parse(xdisfixed1.Text.Trim().ToString());
                //xdisperc += decimal.Parse(xdisperc1.Text.Trim().ToString());
                //xvatfixed += decimal.Parse(xvatfixed1.Text.Trim().ToString());
                //xvatperc += decimal.Parse(xvatperc1.Text.Trim().ToString());

                //xdefault += decimal.Parse(row.Cells[2].Text.ToString());

                //xdiscount += decimal.Parse(xdisfixed1.Text.Trim().ToString()) +
                //             (decimal.Parse(row.Cells[2].Text.ToString()) *
                //              decimal.Parse(xdisperc1.Text.Trim().ToString()) / 100);
                //xnettotal += decimal.Parse(row.Cells[2].Text.ToString()) -
                //             (decimal.Parse(xdisfixed1.Text.Trim().ToString()) +
                //              (decimal.Parse(row.Cells[2].Text.ToString()) *
                //               decimal.Parse(xdisperc1.Text.Trim().ToString()) / 100));

                //row.Cells[5].Text = Convert.ToDecimal(decimal.Parse(xdisfixed1.Text.Trim().ToString()) +
                //                    (decimal.Parse(row.Cells[2].Text.ToString()) *
                //                     decimal.Parse(xdisperc1.Text.Trim().ToString()) / 100)).ToString("F");

                //row.Cells[6].Text = Convert.ToDecimal(decimal.Parse(row.Cells[2].Text.ToString()) -
                //                 (decimal.Parse(xdisfixed1.Text.Trim().ToString()) +
                //                  (decimal.Parse(row.Cells[2].Text.ToString()) *
                //                   decimal.Parse(xdisperc1.Text.Trim().ToString()) / 100))).ToString("F");

                //xvat += decimal.Parse(xvatfixed1.Text.Trim().ToString()) +
                //           (decimal.Parse(row.Cells[6].Text.ToString()) *
                //            decimal.Parse(xvatperc1.Text.Trim().ToString()) / 100);

                //xnettotal1 += decimal.Parse(row.Cells[6].Text.ToString()) +
                //              (decimal.Parse(xvatfixed1.Text.Trim().ToString()) +
                //               (decimal.Parse(row.Cells[6].Text.ToString()) *
                //                decimal.Parse(xvatperc1.Text.Trim().ToString()) / 100));

                //row.Cells[9].Text = Convert.ToDecimal(decimal.Parse(xvatfixed1.Text.Trim().ToString()) +
                //           (decimal.Parse(row.Cells[6].Text.ToString()) *
                //            decimal.Parse(xvatperc1.Text.Trim().ToString()) / 100)).ToString("F");

                //row.Cells[10].Text = Convert.ToDecimal(decimal.Parse(row.Cells[6].Text.ToString()) +
                //              (decimal.Parse(xvatfixed1.Text.Trim().ToString()) +
                //               (decimal.Parse(row.Cells[6].Text.ToString()) *
                //                decimal.Parse(xvatperc1.Text.Trim().ToString()) / 100))).ToString("F");

                //row.Cells[12].Text = Convert.ToDecimal((decimal.Parse(row.Cells[6].Text.ToString()) +
                //              (decimal.Parse(xvatfixed1.Text.Trim().ToString()) +
                //               (decimal.Parse(row.Cells[6].Text.ToString()) *
                //                decimal.Parse(xvatperc1.Text.Trim().ToString()) / 100))) - decimal.Parse(xrec.Text.Trim().ToString())).ToString("F");

                //xdue += decimal.Parse(row.Cells[12].Text.Trim().ToString());
                //}
            }

            GridView1.FooterRow.Cells[2].Text = xnettotal1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            GridView1.FooterRow.Cells[2].Font.Bold = true;
            GridView1.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[2].ForeColor = Color.White;

            GridView1.FooterRow.Cells[5].Text = xnettotal2.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            GridView1.FooterRow.Cells[5].Font.Bold = true;
            GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[5].ForeColor = Color.White;

            GridView1.FooterRow.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            GridView1.FooterRow.Cells[6].Font.Bold = true;
            GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[6].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[4].Text = xdisperc.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[4].Font.Bold = true;
            //GridView1.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[4].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[5].Text = xdiscount.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[5].Font.Bold = true;
            //GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[5].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[6].Text = xnettotal.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[6].Font.Bold = true;
            //GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[6].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[7].Text = xvatfixed.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[7].Font.Bold = true;
            //GridView1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[7].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[8].Text = xvatperc.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[8].Font.Bold = true;
            //GridView1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[8].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[9].Text = xvat.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[9].Font.Bold = true;
            //GridView1.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[9].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[10].Text = xnettotal1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[10].Font.Bold = true;
            //GridView1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[10].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[11].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[11].Font.Bold = true;
            //GridView1.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[11].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[12].Text = xdue.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[12].Font.Bold = true;
            //GridView1.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[12].ForeColor = Color.White;

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

                //            DateTime xtdate2 = Convert.ToDateTime(_xtdate.Value);
                //            string xperiod2 = _xperiod.Value;
                //            string xsection2 = _xsection.Value;

                //            string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcdate=@xcdate and xtdate=@xtdate";
                //            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                //            da.SelectCommand.Parameters.AddWithValue("@xcdate", xperiod2);
                //            da.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate2);
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
                //        DateTime xtdate1 = DateTime.Now;
                //        string xsection1 = "";
                //        string xcdate1 = "";
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
                //            query = "INSERT INTO amexamschd (ztime,zid,xrow,xline,xsubject,xpaper,xtdate,xsection,xcdate,xcteacher,xsteacher,xtopic,xdetails,zemail) " +
                //                   "VALUES(@ztime,@zid,@xrow,@xline,@xsubject,@xpaper,@xtdate,@xsection,@xcdate,@xcteacher,@xsteacher,@xtopic,@xdetails,@zemail) ";
                //        }


                //        xsubject1 = xsubject.Text.ToString().Trim();
                //        xpaper1 = xpaper.Text.Trim().ToString();
                //        xtdate1 = Convert.ToDateTime(_xtdate.Value.ToString());
                //        xsection1 = _xsection.Value.ToString();
                //        xcdate1 = _xperiod.Value.ToString();
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
                //        cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                //        cmd.Parameters.AddWithValue("@xsection", xsection1);
                //        cmd.Parameters.AddWithValue("@xcdate", xcdate1);
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




                //if (xtdate.Text != "" && xtdate.Text != string.Empty && xtdate.Text != "[Select]")
                //{
                //    int year = int.Parse(Convert.ToDateTime(xtdate.SelectedValue).Year.ToString());
                //    int month = int.Parse(Convert.ToDateTime(xtdate.SelectedValue).Month.ToString());

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


                //if (xtdate.Text != "" && xtdate.Text != string.Empty && xtdate.Text != "[Select]")
                //{
                //    int year = int.Parse(Convert.ToDateTime(xtdate.SelectedValue).Year.ToString());
                //    int month = int.Parse(Convert.ToDateTime(xtdate.SelectedValue).Month.ToString());

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
            //        string xext1 = xext.Text.Trim().ToString();

            //        //string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //        //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited'";
            //        string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //                       "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xtype='Class Test'";

            //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
            //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //        da.SelectCommand.Parameters.AddWithValue("@xext", xext1);
            //        da.Fill(dts, "tempztcode");
            //        DataTable dtexam = new DataTable();
            //        dtexam = dts.Tables[0];
            //        //xtdate.Items.Clear();
            //        //xtdate.Items.Add("");
            //        if (dtexam.Rows.Count > 0)
            //        {
            //            ViewState["xnumsch"] = dtexam.Rows.Count;
            //            //foreach (DataRow row in dtexam.Rows)
            //            //{
            //            //    if (row["xtdate"].Equals(DBNull.Value) == false)
            //            //    {
            //            //        // xtdate.Items.Add(Convert.ToDateTime(row["xtdate"]).ToString("dd/MM/yyyy"));
            //            //        //xtdate.Text = Convert.ToDateTime(row["xtdate"]).ToString("dd/MM/yyyy");
            //            //    }
            //            //}
            //            if (xflag == "comval")
            //            {
            //                xcttype.Text = "Test";
            //                fnEventValue("xcttype", null, null);
            //            }
            //        }
            //        else
            //        {
            //            ViewState["xnumsch"] = null;
            //            if (xflag == "comval")
            //            {
            //                xcttype.Text = "Test (WS)";
            //                fnEventValue("xcttype", null, null);
            //            }
            //        }
            //        //xtdate.Text = "";
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
            //             "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xtfccode,xclass,xgroup,xsection,xeffdate,xstdid, " +
            //             " (select xdescdet from mscodesam where zid=amtfcconfig.zid and xcode=amtfcconfig.xtfccode and xtype='TFC Code') as xtfccodetitle, " +
            //             "(select xname from amadmis where zid=amtfcconfig.zid and xstdid=amtfcconfig.xstdid) as xname, xamount,zactive " +
            //             "FROM amtfcconfig WHERE zid=@zid  AND xstatus='New' order by xtfccode,xeffdate desc";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



            //        DataTable tempTable = new DataTable();
            //        da1.Fill(dts1, "tempTable");
            //        tempTable = dts1.Tables["tempTable"];

            //        if (tempTable.Rows.Count > 0)
            //        {
            //            // btnShowList.Visible = true;
            //            //pnllistct.Visible = true;
            //            dgvTFCListNew.DataSource = tempTable;
            //            dgvTFCListNew.DataBind();
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


            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        con.Open();
            //        string query =
            //             "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xrow,xtfccode,xclass,xgroup,xsection,xeffdate,xstdid, " +
            //             " (select xdescdet from mscodesam where zid=amtfcconfig.zid and xcode=amtfcconfig.xtfccode and xtype='TFC Code') as xtfccodetitle, " +
            //             "(select xname from amadmis where zid=amtfcconfig.zid and xstdid=amtfcconfig.xstdid) as xname, xamount,zactive " +
            //             "FROM amtfcconfig WHERE zid=@zid  AND xstatus='Submited' order by xtfccode,xeffdate desc";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



            //        DataTable tempTable = new DataTable();
            //        da1.Fill(dts1, "tempTable");
            //        tempTable = dts1.Tables["tempTable"];

            //        if (tempTable.Rows.Count > 0)
            //        {
            //            // btnShowList.Visible = true;
            //            //pnllistct.Visible = true;
            //            dgvTFCListSubmitted.DataSource = tempTable;
            //            dgvTFCListSubmitted.DataBind();
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
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    ////System.Threading.Thread.Sleep(1000);
            //    message.InnerHtml = "";
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    ViewState["xrow"] = null;
            //    //fnGetScheduleDate();

            //    xctno.Items.Clear();
            //    xctno.Items.Add("");
            //    xcttype.Text = "";
            //    xctno.Text = "";
            //    xmarks.Text = "";
            //    xtopic.Value = "";
            //    xdetails.Value = "";
            //    //xcteacher.Text = "-";
            //    xcteacher.Text = "";
            //    //xsteacher.Text = "-";
            //    xsteacher.Text = "";
            //    dxstatus.Text = "-";
            //    fnButtonState();
            //    _classteacher.Value = "";
            //    _subteacher.Value = "";

            //    fnFillGrid2();
            //    zglobal.fnComboBoxValueWithItem(xreference, "(xcttype + '-' + xctno) as xtext,(xcttype + '|' + xctno) as xvalue", "amexamh", "zid=" + _zid + " and xsession='" + xsession.Text + "' and xterm='" + xterm.Text +
            //         "' and xclass='" + xclass.Text + "' and xgroup='" + xgroup.Text + "' and xsection='" + xsection.Text + "' and xsubject='" + xsubject.Text + "' and xpaper='" + xpaper.Text + "' and coalesce(xext,'')='"+ xext.Text +"' and xtype='Class Test' and xcttype in ('Test','Test (WS)') order by cast(xctno as int)");


            //    fnGetScheduleDate("comval");

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
        //            //xtdate.Text = row.Cells[1].Text;
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


            //    message.InnerHtml = "";

            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    DataSet dts = new DataSet();

            //    dts.Reset();


            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    int xrow = Convert.ToInt32(((LinkButton)sender).Text);

            //    string str = "SELECT  * FROM amtfcconfig where zid=@zid  and xrow=@xrow ";





            //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
            //    da.Fill(dts, "tempztcode");
            //    DataTable dttemp = new DataTable();
            //    dttemp = dts.Tables[0];

            //    ViewState["xrow"] = xrow.ToString();
            //    hiddenxrow.Value = ViewState["xrow"].ToString();

            //    xtfccode.Text = dttemp.Rows[0]["xtfccode"].ToString();
            //    if (dttemp.Rows[0]["xeffdate"].Equals(DBNull.Value) == false)
            //    {
            //        if (Convert.ToDateTime(dttemp.Rows[0]["xeffdate"]).ToString("dd/MM/yyyy") != "01/01/1999" &&
            //            Convert.ToDateTime(dttemp.Rows[0]["xeffdate"]).ToString("dd/MM/yyyy") != "31/12/2999")
            //        {
            //            xeffdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xeffdate"]).ToString("dd/MM/yyyy");
            //        }
            //    }
            //    xclass.Text = dttemp.Rows[0]["xclass"].ToString();
            //    xgroup.Text = dttemp.Rows[0]["xgroup"].ToString();
            //    xsection.Text = dttemp.Rows[0]["xsection"].ToString();
            //    xstdid.Text = dttemp.Rows[0]["xstdid"].ToString();
            //    xamount.Text = dttemp.Rows[0]["xamount"].ToString();
            //    xsign.Text = dttemp.Rows[0]["xsign"].ToString();
            //    xdisfixed.Text = dttemp.Rows[0]["xdisfixed"].ToString();
            //    xdisperc.Text = dttemp.Rows[0]["xdisperc"].ToString();
            //    xvatfixed.Text = dttemp.Rows[0]["xvatfixed"].ToString();
            //    xvatperc.Text = dttemp.Rows[0]["xvatperc"].ToString();
            //    xremarks.Value = dttemp.Rows[0]["xremarks"].ToString();
            //    if (dttemp.Rows[0]["zactive"].ToString() == "1")
            //    {
            //        zactive.Checked = true;
            //    }
            //    else
            //    {
            //        zactive.Checked = false;
            //    }



            //    fnButtonState();
            //    //BindGrid();

            //    xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
            //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xcode='" +
            //       xtfccode.Text.ToString().Trim() + "'" + "and xtype='TFC Code' and zactive=1");

            //    xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
            //        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
            //        xstdid.Text.ToString().Trim() + "'");



            //    str = "SELECT  * FROM amtfcconfigt where zid=@zid  and xrow=@xrow ";




            //    dts.Reset();
            //    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
            //    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
            //    da1.Fill(dts, "tempztcode");
            //    DataTable dttemp1 = new DataTable();
            //    dttemp1 = dts.Tables[0];

            //    if (dttemp1.Rows.Count > 0)
            //    {
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            TextBox txtTextBox1 = row.FindControl("xamount") as TextBox;
            //            CheckBox chkCheckBox = row.FindControl("selbiz") as CheckBox;
            //            chkCheckBox.Checked = false;
            //            txtTextBox1.Text ="";
            //        }

            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            foreach (DataRow row1 in dttemp1.Rows)
            //            {

            //                if (row.Cells[1].Text.ToString() == row1["xtype"].ToString())
            //                {
            //                    TextBox txtTextBox1 = row.FindControl("xamount") as TextBox;
            //                    CheckBox chkCheckBox = row.FindControl("selbiz") as CheckBox;
            //                    chkCheckBox.Checked = true;
            //                    txtTextBox1.Text = row1["xamount"].ToString();
            //                }

            //            }
            //        }
            //    }

            //    da.Dispose();
            //    da1.Dispose();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerText = "";
            //    if (txtconformmessageValue.Value == "Yes")
            //    //if (ViewState["xrow"] != null)
            //    {
            //        if (ViewState["xrow"] != null)
            //        //if (txtconformmessageValue.Value == "Yes")
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
            //                    string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    DateTime xsubmitdt = DateTime.Now;
            //                    xstatus = "Submited";


            //                    string query = "";



            //                    query =
            //                        "UPDATE amtfcconfig SET xstatus=@xstatus,xsubmitedby=@xsubmitedby,xsubmitdt=@xsubmitdt " +
            //                        "WHERE zid=@zid AND xrow=@xrow ";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
            //                    cmd.Parameters.AddWithValue("@xsubmitedby", xsubmitedby);
            //                    cmd.Parameters.AddWithValue("@xsubmitdt", xsubmitdt);
            //                    cmd.ExecuteNonQuery();
            //                }

            //                tran.Complete();
            //            }

            //            message.InnerHtml = zglobal.subsuccmsg;
            //            message.Style.Value = zglobal.successmsg;
            //            btnSubmit.Enabled = false;
            //            btnSubmit1.Enabled = false;
            //            btnSave.Enabled = false;
            //            btnSave1.Enabled = false;
            //            btnDelete.Enabled = false;
            //            btnDelete1.Enabled = false;
            //            ViewState["xstatus"] = "Submited";
            //            hxstatus.Value = "Submited";
            //            //dxstatus.Visible = true;
            //            //btnPrint.Visible = true;
            //            //dxstatus.Text = "Status : Submited";
            //            hiddenxstatus.Value = "Submited";
            //            fnButtonState();
            //            BindGrid();
            //            fnFillGrid2();
            //        }
            //        else
            //        {
            //            message.InnerHtml = "No record found for submited.";
            //            message.Style.Value = zglobal.warningmsg;
            //        }
            //    }
            //    //else
            //    //{
            //    //    message.InnerHtml = "No record found for submited.";
            //    //    message.Style.Value = zglobal.warningmsg;
            //    //}
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerText = "";
            //    if (ViewState["xrow"] != null)
            //    {
            //        //if (txtconformmessageValue.Value == "Yes")
            //        //{
            //            //string xstatus;

            //            using (TransactionScope tran = new TransactionScope())
            //            {
            //                using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //                {
            //                    conn.Open();
            //                    SqlCommand cmd = new SqlCommand();
            //                    cmd.Connection = conn;
            //                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



            //                    string query = "";



            //                    query =
            //                        "UPDATE amtfcconfig SET zactive=1 WHERE zid=@zid AND xrow=@xrow ";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.ExecuteNonQuery();
            //                }

            //                tran.Complete();
            //            }

            //            //message.InnerHtml = zglobal.subsuccmsg;
            //            //message.Style.Value = zglobal.successmsg;
            //            //btnSubmit.Enabled = false;
            //            //btnSubmit1.Enabled = false;
            //            //btnSave.Enabled = false;
            //            //btnSave1.Enabled = false;
            //            //btnDelete.Enabled = false;
            //            //btnDelete1.Enabled = false;
            //            //ViewState["xstatus"] = "Submited";
            //            //hxstatus.Value = "Submited";
            //            ////dxstatus.Visible = true;
            //            ////btnPrint.Visible = true;
            //            ////dxstatus.Text = "Status : Submited";
            //            //hiddenxstatus.Value = "Submited";
            //            fnButtonState();
            //            //BindGrid();
            //            fnFillGrid2();
            //        zactive.Checked = true;
            //        //}
            //    }
            //    else
            //    {
            //        message.InnerHtml = "No record found for submited.";
            //        message.Style.Value = zglobal.warningmsg;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }
        protected void btnInactive_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerText = "";
            //    if (ViewState["xrow"] != null)
            //    {
            //        //if (txtconformmessageValue.Value == "Yes")
            //        //{
            //        //string xstatus;

            //        using (TransactionScope tran = new TransactionScope())
            //        {
            //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //            {
            //                conn.Open();
            //                SqlCommand cmd = new SqlCommand();
            //                cmd.Connection = conn;
            //                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



            //                string query = "";



            //                query =
            //                    "UPDATE amtfcconfig SET zactive=0 WHERE zid=@zid AND xrow=@xrow ";
            //                cmd.Parameters.Clear();

            //                cmd.CommandText = query;
            //                cmd.Parameters.AddWithValue("@zid", _zid);
            //                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                cmd.ExecuteNonQuery();
            //            }

            //            tran.Complete();
            //        }

            //        //message.InnerHtml = zglobal.subsuccmsg;
            //        //message.Style.Value = zglobal.successmsg;
            //        //btnSubmit.Enabled = false;
            //        //btnSubmit1.Enabled = false;
            //        //btnSave.Enabled = false;
            //        //btnSave1.Enabled = false;
            //        //btnDelete.Enabled = false;
            //        //btnDelete1.Enabled = false;
            //        //ViewState["xstatus"] = "Submited";
            //        //hxstatus.Value = "Submited";
            //        ////dxstatus.Visible = true;
            //        ////btnPrint.Visible = true;
            //        ////dxstatus.Text = "Status : Submited";
            //        //hiddenxstatus.Value = "Submited";
            //        fnButtonState();
            //        //BindGrid();
            //        fnFillGrid2();
            //        zactive.Checked = false;
            //        //}
            //    }
            //    else
            //    {
            //        message.InnerHtml = "No record found for submited.";
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
                //    if (xstatus1 != "New" && xstatus1 != "Undo")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}
                if (txtconformmessageValue1.Value == "Yes")
                //if (ViewState["xrow"] != null)
                {
                    if (ViewState["xrow"] != null)
                    //if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xstatus;


                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM amtfcd WHERE zid=@zid AND xrow=@xrow";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.ExecuteNonQuery();

                                query = "DELETE FROM amtfch WHERE zid=@zid AND xrow=@xrow";
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
                        //fnFillGrid2();
                    }
                    else
                    {
                        message.InnerHtml = "No data found for delete.";
                        message.Style.Value = zglobal.warningmsg;
                    }
                }
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

        protected void fnEventValue(string evnt, object sender, EventArgs e)
        {
            //if (xcttype.Text == "Test")
            //{
            //    xschdate.Enabled = false;
            //    schedule_d.Visible = true;
            //}
            //else
            //{
            //    schedule_d.Visible = false;
            //}

            //if ((xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test") && xreference.Text == "")
            //{
            //    ViewState["dtprectmarks"] = null;
            //}

            //if (evnt == "xcttype")
            //{
            //    if (xcttype.Text == "Test")
            //    {
            //        ViewState["xnumsch"] = null;
            //        xtdate.Text = "";
            //        xnsdate.Value = "";
            //        //xtdate.Enabled = false;
            //        xschdate.Text = "";
            //        //xschdate.Enabled = false;
            //        //schedule_d.Visible = true;
            //        fnGetScheduleDate("evnval");
            //        if (ViewState["xnumsch"] != null)
            //        {
            //            zsetvalue.SetDWNumItem(xctno, 1, Convert.ToInt32(ViewState["xnumsch"]));
            //        }
            //        else
            //        {
            //            zsetvalue.SetDWNumItem(xctno, 2, 1);
            //        }
            //    }
            //    else
            //    {
            //        if (xcttype.Text != "")
            //        {
            //            zsetvalue.SetDWNumItem(xctno, 1, 15);
            //        }
            //        else
            //        {
            //            zsetvalue.SetDWNumItem(xctno, 2, 1);
            //        }
            //        xtdate.Text = "";
            //        xnsdate.Value = "";
            //        // xtdate.Enabled = true;
            //        // schedule_d.Visible = false;

            //    }

            //    if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test" || xcttype.Text == "Missed Test")
            //    {
            //        retestfor.Visible = true;
            //    }
            //    else
            //    {
            //        retestfor.Visible = false;
            //    }

            //    //xreason_d.Visible = false;
            //    ViewState["xtdate1"] = null;
            //    xnsdate.Value = "";
            //    xreference.Text = "";
            //    xreason.Text = "";
            //}
            //else if (evnt == "xctno")
            //{
            //    if (xcttype.Text == "Test")
            //    {
            //        if (xctno.Text != "")
            //        {
            //            fnGetDate(sender, e);
            //            //xtdate.Enabled = true;

            //            if (xtdate.Text == "")
            //            {
            //                ViewState["xtdate1"] = null;
            //            }
            //            else
            //            {
            //                ViewState["xtdate1"] = xtdate.Text.ToString().Trim();
            //            }

            //        }
            //        else
            //        {
            //            xtdate.Text = "";
            //            xnsdate.Value = "";
            //            xschdate.Text = "";
            //            //xtdate.Enabled = false;
            //            ViewState["xtdate1"] = null;
            //        }
            //    }
            //    else
            //    {
            //        xtdate.Text = "";
            //        xnsdate.Value = "";
            //        ViewState["xtdate1"] = null;
            //        xschdate.Text = "";
            //        //schedule_d.Visible = false;

            //    }

            //    //xreason_d.Visible = false;
            //    xreason.Text = "";
            //}
            //else if (evnt == "xtdate")
            //{
            //    xreason.Text = "";
            //    if (xcttype.Text == "Test")
            //    {
            //        if (xctno.Text != "")
            //        {

            //            if (ViewState["xtdate1"] != null)
            //            {
            //                DateTime xnsdate1 = xnsdate.Value != ""
            //                    ? DateTime.ParseExact(xnsdate.Value.ToString(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //                DateTime xtdate1 = xtdate.Text.Trim() != string.Empty
            //                    ? DateTime.ParseExact(xtdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


            //                DateTime xpsdate = ViewState["xtdate1"] != null
            //                    ? DateTime.ParseExact(Convert.ToString(ViewState["xtdate1"]), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


            //                if (xtdate1.Date >= xnsdate1.Date || xtdate1.Date < xpsdate.Date)
            //                {
            //                    xtdate.Text = Convert.ToString(ViewState["xtdate1"]);
            //                    message.InnerHtml = "Cann't exceed next schedule date. Select a date between '" + xpsdate.ToString("dd/MM/yyyy") + "' and '" + xnsdate1.ToString("dd/MM/yyyy") + "'";
            //                    //return;
            //                    message.Style.Value = zglobal.warningmsg;
            //                    ViewState["xreturn"] = 1;
            //                }

            //                //if (Convert.ToString(ViewState["xtdate1"]) != xtdate.Text.ToString().Trim())
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
            //            ViewState["xtdate1"] = null;
            //            xnsdate.Value = "";
            //        }
            //    }
            //    else
            //    {
            //        //xreason_d.Visible = false;
            //        xreason.Text = "";
            //        ViewState["xtdate1"] = null;
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

            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
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

        protected void xtdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";
            //    fnEventValue("xtdate", sender, e);

            //    if (Convert.ToInt32(ViewState["xreturn"]) == 1)
            //    {
            //        ViewState["xreturn"] = null;
            //        return;
            //    }

            //    string xtdate10 = xtdate.Text;

            //    btnRefresh_Click(sender, e);

            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
            //    {
            //        xreference_Click(sender, e);
            //    }

            //    xtdate.Text = xtdate10;
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
                message.InnerHtml = "";
                //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //    //ViewState["dtprectmarks"] = null;



                //    fnCheckRow();


                //    if (ViewState["xrow"] != null)
                //    {
                //        string xmarks1 = zglobal.fnGetValue("xmarks", "amexamh",
                //            "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //        xmarks.Text = xmarks1;
                //    }
                //    else
                //    {


                //        if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test" && xcttype.Text != "Missed Test")
                //        {
                //            xmarks.Text = "";
                //        }
                //    }

                //    if (ViewState["xrow"] == null && xcttype.Text == "Test")
                //    {
                //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //        {
                //            using (DataSet dts = new DataSet())
                //            {

                //                string xsession1 = xsession.Text.Trim().ToString();
                //                string xterm1 = xterm.Text.Trim().ToString();
                //                string xclass1 = xclass.Text.Trim().ToString();
                //                string xgroup1 = xgroup.Text.Trim().ToString();
                //                string xsection1 = xsection.Text.Trim().ToString();
                //                string xsubject1 = xsubject.Text.Trim().ToString();
                //                string xpaper1 = xpaper.Text.Trim().ToString();
                //                string xext1 = xext.Text.Trim().ToString();
                //                DateTime xtdate1 = xtdate.Text.Trim() != string.Empty
                //                    ? DateTime.ParseExact(xtdate.Text.Trim().ToString(), "dd/MM/yyyy",
                //                        CultureInfo.InvariantCulture)
                //                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //                //string query = "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher,xretestfor " +
                //                //               "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                //                //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' AND xtdate=@xtdate";
                //                string query =
                //                    "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher " +
                //                    "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                //                    "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xtype='Class Test'  AND xtdate=@xtdate";

                //                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
                //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                //                da.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                //                da.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate1);
                //                da.Fill(dts, "tempztcode");
                //                DataTable dtexam = new DataTable();
                //                dtexam = dts.Tables[0];


                //                if (dtexam.Rows.Count > 0)
                //                {
                //                    xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
                //                    xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
                //                    xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
                //                    xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
                //                    _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
                //                    _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();


                //                }
                //                else
                //                {
                //                    if (ViewState["xtdate1"] == null)
                //                    {
                //                        xtopic.Value = "";
                //                        xdetails.Value = "";
                //                        //xsteacher.Text = "-";
                //                        //xcteacher.Text = "-";
                //                        xsteacher.Text = "";
                //                        xcteacher.Text = "";
                //                        dxstatus.Text = "-";
                //                        _classteacher.Value = "";
                //                        _subteacher.Value = "";
                //                    }

                //                }



                //            }
                //        }
                //    }
                //    else
                //    {
                //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //        {
                //            using (DataSet dts = new DataSet())
                //            {

                //                string query =
                //                    "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xsteacher) as xsteacher1, xcteacher,xsteacher,xrefcttype,xrefctno,xreason,xtdate,xschdate " +
                //                    "FROM amexamh " +
                //                    "WHERE zid=@zid AND xrow=@xrow";

                //                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //                da.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                //                da.Fill(dts, "tempztcode");
                //                DataTable dtexam = new DataTable();
                //                dtexam = dts.Tables[0];


                //                if (dtexam.Rows.Count > 0)
                //                {
                //                    xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
                //                    xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
                //                    xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
                //                    xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
                //                    _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
                //                    _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();
                //                    xtdate.Text = Convert.ToDateTime(dtexam.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");


                //                    //if (xreference.Items.Contains(new ListItem(dtexam.Rows[0]["xretestfor"].ToString())))
                //                    //{
                //                    //    xreference.Text = dtexam.Rows[0]["xretestfor"].ToString();
                //                    //}

                //                    string xref = dtexam.Rows[0]["xrefcttype"].ToString() + "|" +
                //                                  dtexam.Rows[0]["xrefctno"].ToString();

                //                    if (dtexam.Rows[0]["xrefcttype"].ToString() != "" &&
                //                        dtexam.Rows[0]["xrefcttype"].ToString() != "")
                //                    {
                //                        xreference.SelectedValue = xref;
                //                    }
                //                    // xreason.Text = dtexam.Rows[0]["xreason"].ToString();

                //                    //if (dtexam.Rows[0]["xtdate"].ToString() != dtexam.Rows[0]["xschdate"].ToString() && xcttype.Text=="Test")
                //                    //{
                //                    //    xreason_d.Visible = true;
                //                    //   // ViewState["xtdate1"] = dtexam.Rows[0]["xtdate"];
                //                    //}
                //                    //else
                //                    //{
                //                    //    xreason_d.Visible = false;
                //                    //   // ViewState["xtdate1"] = null;
                //                    //}
                //                }
                //                else
                //                {
                //                    if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test" && xcttype.Text != "Missed Test")
                //                    {
                //                        xtopic.Value = "";
                //                        xdetails.Value = "";
                //                        //xsteacher.Text = "-";
                //                        //xcteacher.Text = "-";
                //                        xsteacher.Text = "";
                //                        xcteacher.Text = "";
                //                        dxstatus.Text = "-";
                //                        _classteacher.Value = "";
                //                        _subteacher.Value = "";
                //                    }

                //                    //xdetails.Value = "";
                //                    ////xsteacher.Text = "-";
                //                    ////xcteacher.Text = "-";
                //                    //xsteacher.Text = "";
                //                    //xcteacher.Text = "";
                //                    //dxstatus.Text = "-";
                //                    //_classteacher.Value = "";
                //                    //_subteacher.Value = "";
                //                }



                //            }
                //        }



                //    }


                //    //if (xcttype.Text == "Extra Test")
                //    //{
                //    //    if (xreference.SelectedItem.Text != "")
                //    //    {
                //    //        string[] sch = xreference.SelectedValue.Split('|');
                //    //        string xrefcttype1 = sch[0];
                //    //        string xrefctno1 = sch[1];

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
                //    //                //DateTime xtdate1 = xtdate.Text.Trim() != string.Empty
                //    //                //    ? DateTime.ParseExact(xtdate.Text.Trim().ToString(), "dd/MM/yyyy",
                //    //                //        CultureInfo.InvariantCulture)
                //    //                //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //    //                //da.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate1);


                //    //                DataTable tempTable10 = new DataTable();
                //    //                da.Fill(dts, "tempTable");
                //    //                tempTable10 = dts.Tables["tempTable"];

                //    //                if (tempTable10.Rows.Count > 0)
                //    //                {
                //    //                    query = "SELECT * FROM amexamd WHERE zid=@zid AND xrow=@xrow";


                //    //                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                //    //                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //    //                    da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable10.Rows[0]["xrow"]));

                //    //                    dts.Reset();
                //    //                    da1.Fill(dts, "tempztcode");
                //    //                    DataTable dtexam1 = new DataTable();
                //    //                    dtexam1 = dts.Tables[0];
                //    //                    ViewState["dtprectmarks"] = dtexam1;
                //    //                    dtprectmarks = dtexam1;
                //    //                }
                //    //                else
                //    //                {
                //    //                    ViewState["dtprectmarks"] = null;
                //    //                    dtprectmarks = null;
                //    //                }



                //    //            }
                //    //        }
                //    //    }
                //    //}

                //    ViewState["xrow"] = null;
                //    hiddenxrow.Value = "";

                //    xtfccode.Text = "";
                //    xtfccodetitle.Text = "";
                //    xeffdate.Text = "";
                //    xclass.Text = "";
                //    xgroup.Text = "";
                //    xsection.Text = "";
                //    xstdid.Text = "";
                //    xamount.Text = "";
                //    xsign.Text = "";
                //    xdisfixed.Text = "";
                //    xdisperc.Text = "";
                //    xvatfixed.Text = "";
                //    xvatperc.Text = "";
                //    xremarks.Value = "";
                //    zactive.Checked = true;
                //    xstatus.InnerHtml = "";
                //    zemail.InnerHtml = "";
                //    xemail.InnerHtml = "";

                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //        TextBox txtTextBox1 = row.FindControl("xamount") as TextBox;
                //        CheckBox chkCheckBox = row.FindControl("selbiz") as CheckBox;
                //        chkCheckBox.Checked = false;
                //        txtTextBox1.Text = "";
                //    }




                ////    BindGrid();
                //    fnFillGrid2();

                //    fnButtonState();


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
            //                string xext1 = xext.Text.Trim().ToString();

            //                //string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //                //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' ";

            //                string query =
            //                    "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //                    "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xtype='Class Test' ORDER BY xtdate ";

            //                SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
            //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //                da.SelectCommand.Parameters.AddWithValue("@xext", xext1);
            //                da.Fill(dts, "tempztcode");
            //                DataTable dtexam = new DataTable();
            //                dtexam = dts.Tables[0];

            //                if (dtexam.Rows.Count > 0)
            //                {
            //                    int count = 1;
            //                    foreach (DataRow row in dtexam.Rows)
            //                    {
            //                        if (row["xtdate"].Equals(DBNull.Value) == false)
            //                        {
            //                            if (count == Int32.Parse(xctno.Text.Trim().ToString()))
            //                            {
            //                                xtdate.Text = Convert.ToDateTime(row["xtdate"]).ToString("dd/MM/yyyy");
            //                                xschdate.Text = Convert.ToDateTime(row["xtdate"]).ToString("dd/MM/yyyy");
            //                                if (count < dtexam.Rows.Count)
            //                                {
            //                                    xnsdate.Value =
            //                                        Convert.ToDateTime(dtexam.Rows[count]["xtdate"])
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
            //                                xtdate.Text = "";
            //                                xnsdate.Value = "";
            //                                xschdate.Text = "";
            //                            }

            //                            count = count + 1;
            //                        }
            //                    }

            //                    //for (int i = 1; i <= dtexam.Rows.Count; i++)
            //                    //{
            //                    //    if (dtexam.Rows[i-1]["xtdate"].Equals(DBNull.Value) == false)
            //                    //    {
            //                    //        if (i == Int32.Parse(xctno.Text.Trim().ToString()))
            //                    //        {
            //                    //            xtdate.Text = Convert.ToDateTime(row["xtdate"]).ToString("dd/MM/yyyy");
            //                    //            if (count < dtexam.Rows.Count)
            //                    //            {
            //                    //                xnsdate.Value =
            //                    //                    Convert.ToDateTime(dtexam.Rows[count + 1]["xtdate"])
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
            //                    //            xtdate.Text = "";
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
            //        xtdate.Text = "";
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
            //    if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test" || xcttype.Text == "Missed Test")
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



            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
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
            //                        "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xcttype=@xcttype AND xctno=@xctno";


            //                    SqlDataAdapter da = new SqlDataAdapter(query, con);

            //                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                    da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xcttype", xrefcttype1);
            //                    da.SelectCommand.Parameters.AddWithValue("@xctno", xrefctno1);
            //                    //DateTime xtdate1 = xtdate.Text.Trim() != string.Empty
            //                    //    ? DateTime.ParseExact(xtdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                    //        CultureInfo.InvariantCulture)
            //                    //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //                    //da.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate1);


            //                    DataTable tempTable10 = new DataTable();
            //                    da.Fill(dts, "tempTable");
            //                    tempTable10 = dts.Tables["tempTable"];

            //                    if (tempTable10.Rows.Count > 0)
            //                    {
            //                        query = "SELECT *,(select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xcteacher) as xcteacher1, " +
            //                                "(select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xsteacher) as xsteacher1 " +
            //                                "FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //                                "WHERE amexamh.zid=@zid AND amexamh.xrow=@xrow";


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
            //                        xdetails.Value = dtexam1.Rows[0]["xdetails"].ToString();
            //                        xcteacher.Text = dtexam1.Rows[0]["xcteacher1"].ToString();
            //                        xsteacher.Text = dtexam1.Rows[0]["xsteacher1"].ToString();
            //                        _classteacher.Value = dtexam1.Rows[0]["xcteacher"].ToString();
            //                        _subteacher.Value = dtexam1.Rows[0]["xsteacher"].ToString();
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


        protected void xcdate_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                BindGrid();
                if (GridView1.DataSource != null)
                {
                    xnettotal2 = 0;
                    xreceived = 0;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        TextBox xrec = (TextBox)row.FindControl("xreceived");
                        

                        if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
                        {
                            xrec.Text = Convert.ToDecimal("0").ToString("F");
                        }
                        else
                        {
                            xreceived += decimal.Parse(xrec.Text.Trim().ToString());
                        }

                        if (row.Cells[5].Text.ToString() == "" || row.Cells[5].Text.ToString() == String.Empty)
                        {
                            row.Cells[5].Text = "0";
                        }
                        else
                        {
                            xnettotal2 += decimal.Parse(row.Cells[5].Text.ToString());
                        }
                        

                    }


                    GridView1.FooterRow.Cells[5].Text = xnettotal2.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                    GridView1.FooterRow.Cells[5].Font.Bold = true;
                    GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                    GridView1.FooterRow.Cells[5].ForeColor = Color.White;

                    GridView1.FooterRow.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                    GridView1.FooterRow.Cells[6].Font.Bold = true;
                    GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                    GridView1.FooterRow.Cells[6].ForeColor = Color.White;

                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        protected void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerText = "";
                if (txtconformmessageValue.Value == "Yes")
                //if (ViewState["xrow"] != null)
                {
                    if (ViewState["xrow"] != null)
                    //if (txtconformmessageValue.Value == "Yes")
                    {
                        btnSave_Click(sender,e);

                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                string xpaidby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xpaiddt = DateTime.Now;
                                xstatus = "Paid";


                                string query = "";



                                query =
                                    "UPDATE amtfch SET xstatus=@xstatus,xpaidby=@xpaidby,xpaiddt=@xpaiddt " +
                                    "WHERE zid=@zid AND xrow=@xrow ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.Parameters.AddWithValue("@xpaidby", xpaidby);
                                cmd.Parameters.AddWithValue("@xpaiddt", xpaiddt);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.paidsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnPaid.Enabled = false;
                        btnPaid1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "Paid";
                        //hxstatus.Value = "Submited";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        //hiddenxstatus.Value = "Submited";
                        fnButtonState();
                        BindGrid();
                        //fnFillGrid2();
                    }
                    else
                    {
                        message.InnerHtml = "No record found for paid.";
                        message.Style.Value = zglobal.warningmsg;
                    }
                }
                //else
                //{
                //    message.InnerHtml = "No record found for submited.";
                //    message.Style.Value = zglobal.warningmsg;
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}