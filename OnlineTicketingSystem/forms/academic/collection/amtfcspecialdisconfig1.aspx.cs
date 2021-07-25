using System;
using System.Collections;
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
    public partial class amtfcspecialdisconfig1 : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            if (ViewState["xrow"] == null)
            {
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
                btnConfirm.Enabled = false;
                btnConfirm1.Enabled = false;
                btnPaid.Enabled = false;
                btnPaid1.Enabled = false;
                btnPrint.Enabled = false;
                btnPrint1.Enabled = false;
                //dxstatus.Visible = false;
                //dxstatus.Text = "-";
                //xsessionpro.Text = "";
                //xclasspro.Text = "";
                //xgrouppro.Text = "";
                xsession.Enabled = true;
                xstdid.Enabled = true;
                hxstatus.Value = "";
                //xstatus.InnerHtml = "";
                //zemail.InnerHtml = "";
                //xapprovedby.InnerHtml = "";
                hiddenxrow.Value = "";
            }
            else
            {
                xrow1.Text = ViewState["xrow"].ToString();
                //xsession.Enabled = false;
                //xstdid.Enabled = false;

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xstatus1 = zglobal.fnGetValue("xstatus", "amtfcspecialdisconf",
                               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                hxstatus.Value = xstatus1;
                //xstatus.InnerHtml = xstatus1;
                //zemail.InnerHtml = zglobal.fnGetValue("coalesce(zemail,'') as zemail", "amdropout",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //xapprovedby.InnerHtml = zglobal.fnGetValue("coalesce(xapprovedby,'') as xapprovedby", "amdropout",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                //xsessionpro.Text = zglobal.fnGetValue("xsessionpro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                //xclasspro.Text = zglobal.fnGetValue("xclasspro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                //xgrouppro.Text = zglobal.fnGetValue("xgrouppro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //dxstatus.Visible = true;

                if (xstatus1 == "New" || xstatus1 == "Undo")
                {
                    btnSubmit.Enabled = true;
                    btnSubmit1.Enabled = true;
                    btnConfirm.Enabled = true;
                    btnConfirm1.Enabled = true;
                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDelete1.Enabled = true;
                    btnPaid.Enabled = true;
                    btnPaid1.Enabled = true;
                    btnPrint.Enabled = true;
                    btnPrint1.Enabled = true;
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
                    btnPaid.Enabled = false;
                    btnPaid1.Enabled = false;
                    btnPrint.Enabled = true;
                    btnPrint1.Enabled = true;
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

                    btnPrint.Visible = false;
                    btnPrint1.Visible = false;

                    //xsessionpro.Enabled = true;
                    //xclasspro.Enabled = true;
                    //xgrouppro.Enabled = true;
                }

            }

            btnDelete.Enabled = true;
            btnDelete1.Enabled = true;
            btnSave.Enabled = true;
            btnSave1.Enabled = true;
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
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //        zglobal.fnGetComboDataCD("Education Group", xgrouppro);
                    //        // zglobal.fnGetComboDataCD("Test Type", xcttype);

                    zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Bank", xbank);
                    //        zglobal.fnGetComboDataCD("Class", xclasspro);
                    //        //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //        //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    //        zglobal.fnGetComboDataCD("Section", xsection);
                    //        //zglobal.fnGetComboDataCD("Class Subject", xsubject);
                    //zglobal.fnGetComboDataCD("Dropout Type", xtype);
                    //zglobal.fnGetComboDataCD("Dropout Reason", xreason);

                    xsession.Text = zglobal.fnDefaults("xsessionacc", "Student");
                   // xbank.Text = zglobal.fnDefaults("xbank", "Student");

                    //        //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //        //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //        //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    ViewState["xrow"] = null;
                    ViewState["xrowconf"] = null;
                    hiddenxrow.Value = "";
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
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
                    ViewState["xtype"] = "Seat Conf";
                    btnPaid.Visible = false;
                    btnPaid1.Visible = false;
                    btnPrint.Visible = false;
                    btnPrint1.Visible = false;

                    btnDelete.Enabled = true;
                    btnDelete1.Enabled = true;

                    divrunninginfo.Visible = false;
                    //xsessioncur.Text = zglobal.fnDefaults("xsession", "Student");

                    int offset;
                    int year = DateTime.Now.Year;

                    int tempyear;

                    offset = zglobal.fnGetValueInt("xinteger", "msstatus",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtypestatus='GL Period Offset'");

                    int per = 12 + DateTime.Now.Month - offset;

                    if (per <= 12)
                    {
                        tempyear = year - 1;
                    }
                    else
                    {
                        tempyear = year;
                    }
                    //int year = DateTime.Now.Year;
                    int month = 7;
                    int day = 1;
                    DateTime xeffdate1 = new DateTime(tempyear, month, day);
                    xeffdate.Text = xeffdate1.ToString("dd/MM/yyyy");
                }

                divrunninginfo.Visible = false;

                xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
         "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
         xstdid.Text.ToString().Trim() + "' ");

                //xclass.Text = zglobal.fnGetValue("xclass", "amstudentvwextacc",
                //   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //   xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");

                //xstdname.Text = zglobal.fnGetValue("xname + ' - ' + xclass + ' ('+xsection+')'", "amstudentvw",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
             //   xclasscur.Text = zglobal.fnGetValue("xclass", "amstudentvwextacc",
             //      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
             //      xstdid.Text.ToString().Trim() + "' and xsession='" + xsessioncur.Text.ToString().Trim() + "'");

             //   xgroupcur.Text = zglobal.fnGetValue("xgroup", "amstudentvwextacc",
             //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
             //xstdid.Text.ToString().Trim() + "' and xsession='" + xsessioncur.Text.ToString().Trim() + "' ");

             //   xsectioncur.Text = zglobal.fnGetValue("xsection", "amstudentvwextacc",
             //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
             //xstdid.Text.ToString().Trim() + "' and xsession='" + xsessioncur.Text.ToString().Trim() + "'  ");

                //       xname.Text = zglobal.fnGetValue("xname", "amadmis",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' ");
                //       xfname.Text = zglobal.fnGetValue("xfname", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xmname.Text = zglobal.fnGetValue("xmname", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");

                BindGrid();
                fnRegisterPostBack();
                //fnCalculateTotal();
                xstdid.Focus();
                xstdid.Attributes.Add("onfocus", "javascript:this.select();");

//                using (SqlConnection conn = new SqlConnection(zglobal.constring))
//                {
//                    using (DataSet dts1 = new DataSet())
//                    {
//                        string query = @"select zid,xsession,xstdid,xname,xclass,xcodealt, codealt1,
//(select xcode from mscodesam where zid=tbl.zid and xtype='Class' and cast(xcodealt as int)=codealt1)   as xclassconf
//from 
//(
//select zid,xsession,xstdid,xname,xclass, (select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as xcodealt,
//case when cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int) =
//(select max(cast(xcodealt as int)) from mscodesam where zid=a.zid and xtype='Class'  ) 
//then   cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int) else
// cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int)+1 end as codealt1
// from amstudentvw as a 
// )tbl
// where zid=@zid and xsession=@xsession and xstdid=@xstdid";

//                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
//                        da1.SelectCommand.Parameters.AddWithValue("zid", Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
//                        da1.SelectCommand.Parameters.AddWithValue("xsession", xsessioncur.Text.ToString().Trim());
//                        da1.SelectCommand.Parameters.AddWithValue("xstdid", xstdid.Text.ToString().Trim());
//                        da1.Fill(dts1, "tblamadmisd");
//                        amexamd = dts1.Tables[0];
//                        if (amexamd.Rows.Count > 0)
//                        {
//                            xclass.Text = amexamd.Rows[0]["xclassconf"].ToString();
//                        }
//                        else
//                        {
//                            xclass.Text = "";
//                        }
//                    }

//                }



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
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            foreach (GridViewRow row in dgvcollectionpaid.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }
        }

        //private decimal xdeftotal1 = 0;
        private decimal xnettotal1 = 0;
        private decimal xnettotal2 = 0;
        private decimal xreceived = 0;
        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        List<string> listsubject = new List<string>();
        private void BindGrid()
        {
            if (xsession.Text.Trim().ToString() == "" || xstdid.Text.Trim().ToString() == "" || xclass.Text.Trim().ToString() == "" )
            {
                return;
            }

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //xdeftotal1 = 0;
            xnettotal1 = 0;
            xnettotal2 = 0;
            xreceived = 0;

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();


            //string xclass1 = xclass.Text.Trim().ToString();
            string xclass1 = xclass.Text.Trim().ToString();
            string xgroup1 = xgroupcur.Text.Trim().ToString();

            string str = "";

            string[] date = new string[3];
            if (xeffdate.Text.ToString().Trim() == "")
            {
                date[0] = "1";
                date[1] = "7";
                date[2] = DateTime.Now.Year.ToString();
            }
            else
            {
                date = xeffdate.Text.Split('/');
            }

            int year = Int32.Parse(date[2]);
            int month = Int32.Parse(date[1]);
            int day = Int32.Parse(date[0]);
            DateTime xeffdate1 = new DateTime(year, month, day);

            //message.InnerHtml = xeffdate1.ToString("dd/MM/yyyy");
            

            int xrow1;

            ViewState["xstatus"] = "";
            ViewState["amtfcd"] = null;

            Int64 xsrow1 = zglobal.fnGetValue("xrow", "amadmis",
                "zid=" + _zid + " and xstdid='" +
                xstdid.Text.ToString().Trim() + "' ") != ""
                ? Convert.ToInt64(zglobal.fnGetValue("xrow", "amadmis",
                    "zid=" + _zid + " and xstdid='" +
                    xstdid.Text.ToString().Trim() + "' "))
                : 0;

            //if (ViewState["xrow"] != null)
            //{



                string xstatus1 = zglobal.fnGetValue("xstatus", "amtfcspecialdisconf",
                       "zid=" + _zid + " AND xsrow=" + xsrow1 + " and xsession='"+xsession.Text+"' and xeffdate='"+xeffdate1+"'");
                ViewState["xstatus"] = xstatus1;

                //if (xstatus1 != "Paid")
                //{
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts1 = new DataSet())
                        {
                            string query = "SELECT * FROM amtfcspecialdisconf WHERE zid=@zid AND xsrow=@xsrow and xsession=@xsession and xeffdate=@xeffdate";
                            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow1);
                            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text);
                            da1.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
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
                //}
           // }


            //if (ViewState["xrow"] != null)
            //{
            //    str =
            //        "SELECT  xtfccode,xdescdet,xtype,xamount as xnettotal1,xreceived,xremarks1,xspecialdis,xspecialdistype, " +
            //        "cast(case when xspecialdistype='%' then xamount - (xamount*xspecialdis/100) else xamount-xspecialdis end as decimal(18,2)) as xnetamount " +
            //        "FROM amtfcvw " +
            //        "WHERE zid=@zid AND xrow=@xrow ";// +
            //   //"ORDER BY xsequence";
            //    xrow1 = Convert.ToInt32(ViewState["xrow"].ToString());
            //}
            //else
            //{
                //str = zglobal.fnxtfcdefault(ViewState["xtype"].ToString());
              str = zglobal.fntfcSpecialDiscount();
              xrow1 = 0;
            //}

            

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            da.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow1);
            da.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {

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

                //bfield = new BoundField();
                //bfield.HeaderText = "Default Amount";
                //bfield.DataField = "xnettotal1";
                //bfield.ItemStyle.Width = 120;
                //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                //GridView1.Columns.Add(bfield);

                //tfield = new TemplateField();
                //tfield.HeaderText = "Default Amount";
                //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                //tfield.ItemStyle.Width = 120;
                //GridView1.Columns.Add(tfield);



                tfield = new TemplateField();
                tfield.HeaderText = "Discount";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 120;
                GridView1.Columns.Add(tfield);

                tfield = new TemplateField();
                tfield.HeaderText = "";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 50;
                GridView1.Columns.Add(tfield);

                //tfield = new TemplateField();
                //tfield.HeaderText = "Net Amount";
                //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                //tfield.ItemStyle.Width = 120;
                //GridView1.Columns.Add(tfield);

                bfield = new BoundField();
                bfield.HeaderText = "Net Amount";
                bfield.DataField = "xnetamount";
                bfield.ItemStyle.Width = 120;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                bfield.Visible = false;
                GridView1.Columns.Add(bfield);

                tfield = new TemplateField();
                tfield.HeaderText = "Received Amount";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 120;
                tfield.Visible = false;
                GridView1.Columns.Add(tfield);



                tfield = new TemplateField();
                tfield.HeaderText = "Remarks";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                tfield.ItemStyle.Width = 300;
                GridView1.Columns.Add(tfield);

                tfield = new TemplateField();
                tfield.HeaderText = "Type";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield.ItemStyle.Width = 80;
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

        TextBox txTextBox;
        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.DataSource == null)
                {
                    return;
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
                    //xnettotal1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xnettotal1"));
                    //xnettotal2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "xnetamount"));

                    //TextBox txtDefAmount = new TextBox();
                    //txtDefAmount.ID = "xamount";
                    //txtDefAmount.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xdiscount";
                    //txtDefAmount.Attributes.Add("onkeyup", "enter(this,event)");
                    ////txtDefAmount.Enabled = false;
                    ////txtDefAmount.BackColor = Color.Transparent;
                    //txtDefAmount.ForeColor = Color.Black;
                    ////txtDefAmount.Text = DataBinder.Eval(e.Row.DataItem, "xnettotal1").ToString();
                    //e.Row.Cells[2].Controls.Add(txtDefAmount);


                    TextBox txtDiscount = new TextBox();
                    txtDiscount.ID = "xdiscount";
                    txtDiscount.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xdiscount";
                    txtDiscount.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[2].Controls.Add(txtDiscount);


                    //TextBox txtNetAmount = new TextBox();
                    //txtNetAmount.ID = "xnetamount";
                    //txtNetAmount.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xreceive";
                    //txtNetAmount.Attributes.Add("onkeyup", "enter(this,event)");
                    //txtNetAmount.Enabled = false;
                    //e.Row.Cells[4].Controls.Add(txtNetAmount);

                    DropDownList dpDisType = new DropDownList();
                    dpDisType.ID = "xdistype";
                    dpDisType.Items.Add("Fixed");
                    dpDisType.Items.Add("%");
                    
                    //dpDisType.AutoPostBack = true;
                    //dpDisType.SelectedIndexChanged += dpDisType_SelectedIndexChanged;
                    e.Row.Cells[3].Controls.Add(dpDisType);

                    //Label txtNetAmount = new Label();
                    //txtNetAmount.ID = "xnetamount";
                    //txtNetAmount.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xnetamount";
                    ////txtNetAmount.Attributes.Add("onkeyup", "enter(this,event)");
                    //e.Row.Cells[5].Controls.Add(txtNetAmount);

                    TextBox txtReceive = new TextBox();
                    txtReceive.ID = "xreceived";
                    txtReceive.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox right xreceive";
                    txtReceive.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[5].Controls.Add(txtReceive);

                    TextBox txtRemarks = new TextBox();
                    txtRemarks.ID = "xremarks";
                    txtRemarks.CssClass = "xremarks";
                    txtRemarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    txtRemarks.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[6].Controls.Add(txtRemarks);

                    DropDownList dpType = new DropDownList();
                    dpType.ID = "xtype1";
                    dpType.Items.Add("");
                    dpType.Items.Add("Single");
                    dpType.Items.Add("Monthly");
                    dpType.Items.Add("Yearly");
                    dpType.Items.Add("N/A");
                    dpType.Enabled = false;
                    dpType.BackColor = Color.Transparent;
                    dpType.BorderStyle=BorderStyle.None;
                    dpType.Style.Add("-webkit-appearance","none;");

                    //dpDisType.AutoPostBack = true;
                    //dpDisType.SelectedIndexChanged += dpDisType_SelectedIndexChanged;
                    e.Row.Cells[7].Controls.Add(dpType);

                    if (ViewState["amtfcd"] != null)
                    {
                        DataTable dt = new DataTable();
                        dt = ViewState["amtfcd"] as DataTable;
                        int f = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["xtfccode"].ToString() == e.Row.Cells[0].Text.ToString())
                            {

                                //txtReceive.Text = row["xreceived"].ToString();
                                txtRemarks.Text = row["xremarks"].ToString();
                                //txtDefAmount.Text = row["xamount"].ToString();

                                //if ((row["xdisperc"].ToString() != "0" && row["xdisperc"].ToString() != "0.00") || (row["xdisfixed"].ToString() == "0" || row["xdisfixed"].ToString() == "0.00"))
                                //{
                                //    txtDiscount.Text = row["xdisperc"].ToString();
                                //    dpDisType.Text = "%";
                                //}
                                //else
                                //{
                                //    txtDiscount.Text = row["xdisfixed"].ToString();
                                //    dpDisType.Text = "Fixed";
                                //}

                                if ((row["xdisperc"].ToString() == "0" || row["xdisperc"].ToString() == "0.00") || (row["xdisfixed"].ToString() != "0" && row["xdisfixed"].ToString() != "0.00"))
                                {
                                    
                                    txtDiscount.Text = row["xdisfixed"].ToString();
                                    dpDisType.Text = "Fixed";
                                }
                                else
                                {
                                    txtDiscount.Text = row["xdisperc"].ToString();
                                    dpDisType.Text = "%";
                                }

                                dpType.Text = row["xtype1"].ToString();
                                //xreceived += Convert.ToDecimal(row["xreceived"].ToString().Trim());
                                f = 1;
                                break;
                            }
                        }

                        if (f == 0)
                        {
                            txtRemarks.Text = (e.Row.DataItem as DataRowView).Row["xremarks"].ToString();
                            //txtDefAmount.Text = (e.Row.DataItem as DataRowView).Row["xamount"].ToString();

                            //if ((e.Row.DataItem as DataRowView).Row["xdisperc"].ToString() != "0")
                            //{
                            //    txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisperc"].ToString();
                            //    dpDisType.Text = "%";
                            //}
                            //else
                            //{
                            //    txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisfixed"].ToString();
                            //    dpDisType.Text = "Fixed";
                            //}

                            if ((e.Row.DataItem as DataRowView).Row["xdisfixed"].ToString() != "0")
                            {
                                txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisfixed"].ToString();
                                dpDisType.Text = "Fixed";
                            }
                            else
                            {

                                txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisperc"].ToString();
                                dpDisType.Text = "%";
                            }

                            dpType.Text = (e.Row.DataItem as DataRowView).Row["xtype1"].ToString();
                        }
                    }
                    else
                    {
                        //txtNetAmount.Text = "0.00";
                        //decimal xdefaultamt = Convert.ToDecimal((e.Row.DataItem as DataRowView).Row["xnettotal1"].ToString());
                        ////decimal xspecialdis = Convert.ToDecimal((e.Row.DataItem as DataRowView).Row["xspecialdis"].ToString());
                        //string xspecialdistype = (e.Row.DataItem as DataRowView).Row["xspecialdistype"].ToString();

                        ////if (xspecialdistype == "%")
                        ////{
                        ////    txtNetAmount.Text = (xdefaultamt - (xdefaultamt * xspecialdis / 100)).ToString("0.00");
                        ////}
                        ////else
                        ////{
                        ////    txtNetAmount.Text = (xdefaultamt - xspecialdis).ToString("0.00");
                        ////}

                        //dpDisType.Text = xspecialdistype;
                        //txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xspecialdis"].ToString();

                        //xnettotal2 += Convert.ToDecimal(e.Row.Cells[5].Text);

                        txtRemarks.Text = (e.Row.DataItem as DataRowView).Row["xremarks"].ToString();
                        //txtDefAmount.Text = (e.Row.DataItem as DataRowView).Row["xamount"].ToString();

                        //if ((e.Row.DataItem as DataRowView).Row["xdisperc"].ToString() != "0")
                        //{
                        //    txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisperc"].ToString();
                        //    dpDisType.Text = "%";
                        //}
                        //else
                        //{
                        //    txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisfixed"].ToString();
                        //    dpDisType.Text = "Fixed";
                        //}

                        if ((e.Row.DataItem as DataRowView).Row["xdisfixed"].ToString() != "0")
                        {
                            txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisfixed"].ToString();
                            dpDisType.Text = "Fixed";
                        }
                        else
                        {

                            txtDiscount.Text = (e.Row.DataItem as DataRowView).Row["xdisperc"].ToString();
                            dpDisType.Text = "%";
                        }

                        dpType.Text = (e.Row.DataItem as DataRowView).Row["xtype1"].ToString();

                    }

                    //txtDefAmount.Text = (e.Row.DataItem as DataRowView).Row["xamount"].ToString();

                    //if (ViewState["xstatus"] != null)
                    //{
                    //    if (ViewState["xstatus"].ToString() == "Submited")
                    //    {
                    //        txtReceive.Enabled = false;
                    //        txtRemarks.Enabled = false;
                    //        txtDiscount.Enabled = false;
                    //        dpDisType.Enabled = false;
                    //        dpType.Enabled = false;
                    //        txtDefAmount.Enabled = false;

                    //        //txtReceive.Text = (e.Row.DataItem as DataRowView).Row["xreceived"].ToString();
                    //        //txtRemarks.Text = (e.Row.DataItem as DataRowView).Row["xremarks1"].ToString();

                    //        //xreceived += Convert.ToDecimal((e.Row.DataItem as DataRowView).Row["xreceived"].ToString().Trim());
                    //    }
                    //}

                    

                }



                //if (e.Row.RowType == DataControlRowType.Footer)
                //{
                //    e.Row.Cells[1].Text = "Total :";
                //    e.Row.Cells[1].Font.Bold = true;
                //    e.Row.Cells[1].ForeColor = Color.White;
                //    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                //    e.Row.Cells[2].Text = xnettotal1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    e.Row.Cells[2].Font.Bold = true;
                //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //    e.Row.Cells[2].ForeColor = Color.White;

                //    e.Row.Cells[5].Text = xnettotal2.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    e.Row.Cells[5].Font.Bold = true;
                //    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                //    e.Row.Cells[5].ForeColor = Color.White;

                //    e.Row.Cells[6].Font.Bold = true;
                //    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                //    e.Row.Cells[6].ForeColor = Color.White;

                //    if (ViewState["xrow"] != null)
                //    {
                //        e.Row.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    }
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        void dpDisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.NamingContainer;

                TextBox xdiscount1 = (TextBox)row.FindControl("xdiscount");
                decimal defaultamt = Convert.ToDecimal(row.Cells[2].Text);

                decimal disamount;
                if (xdiscount1.Text.Trim().ToString() == String.Empty)
                {
                    disamount = 0;
                    xdiscount1.Text = "0";
                }
                else
                {
                    disamount = Convert.ToDecimal(xdiscount1.Text.Trim().ToString());
                }

                decimal discount;
                decimal netamount;

                if (ddl.Text == "%")
                {
                    discount = defaultamt * disamount / 100;
                    netamount = defaultamt - discount;
                }
                else
                {
                    netamount = defaultamt - disamount;
                }

                row.Cells[5].Text = Convert.ToString(netamount);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
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
            fnCalculateTotal();

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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xtfccode");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xdescdet");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xamount");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceivable");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceived");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xremarks");

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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xtfccode");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xdescdet");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xamount");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceivable");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceived");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xremarks");

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
                fnCalculateTotal();
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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("xtfccode");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xdescdet");
                        TextBox box3 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xamount");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceivable");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xreceived");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("xremarks");

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
                fnCalculateTotal();
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
                //btnRefresh_Click(sender,e);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = 0;
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xstdid.Text == "" || xstdid.Text == string.Empty || xstdid.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Student ID</li>";
                    isValid = false;
                }
                if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Class</li>";
                    isValid = false;
                }
                if (xeffdate.Text == "" || xeffdate.Text == string.Empty || xeffdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Effected Date</li>";
                    isValid = false;
                }
                //if (xbank.Text == "" || xbank.Text == string.Empty || xbank.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Bank</li>";
                //    isValid = false;
                //}
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


              

               

                //string[] date = new string[2];
                //date = xcdate.Text.Split('-');

                //int year = Int32.Parse(date[1]);
                //int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                //DateTime xdate1 = new DateTime(year, month, 1);

                //string xtype1 = ViewState["xtype"].ToString();
                //Int64 xsrow1 = Convert.ToInt64(ViewState["xrow1"]);
                //string xsession1 = xsession.Text.Trim().ToString();
                //DateTime xcdate1 = xdate1;
                //DateTime xtdate1 = DateTime.Now;
                //string xbank1 = "";
                //DateTime xchqdate1 = new DateTime(2999, 12, 31);
                //string xchqno1 = "";
                //string xstatus1 = "New";
                //string xremarks1 = "";
                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xpaidby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                DateTime xpaiddt = DateTime.Now;
                string xstdid1 = "";

                Int64 xsrow1 = zglobal.fnGetValue("xrow", "amadmis",
               "zid=" + _zid + " and xstdid='" +
               xstdid.Text.ToString().Trim() + "' ") != ""
               ? Convert.ToInt64(zglobal.fnGetValue("xrow", "amadmis",
                   "zid=" + _zid + " and xstdid='" +
                   xstdid.Text.ToString().Trim() + "' "))
               : 0;

                if (xsrow1 == 0)
                {
                    message.InnerHtml = "Invalid student ID.";
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                string[] date1 = new string[3];
                if (xeffdate.Text.ToString().Trim() == "")
                {
                    date1[0] = "1";
                    date1[1] = "7";
                    date1[2] = DateTime.Now.Year.ToString();
                }
                else
                {
                    date1 = xeffdate.Text.Split('/');
                }

                int year1 = Int32.Parse(date1[2]);
                int month1 = Int32.Parse(date1[1]);
                int day1 = Int32.Parse(date1[0]);
                DateTime xeffdate1 = new DateTime(year1, month1, day1);

                using (TransactionScope tran = new TransactionScope())
                {
                   
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        string query = "";

                        //ArrayList type1 = new ArrayList();
                        //type1.Add("Admission");
                        //type1.Add("Readmission");
                        //type1.Add("Tuition Fee");

                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            //query = "DELETE FROM amtfcspecialdisconft WHERE zid=@zid AND " +
                            //        "xrow=(select xrow from amtfcspecialdisconf WHERE zid=@zid AND xsrow=@xsrow and xsession=@xsession and xeffdate=@xeffdate and xtfccode=@xtfccode)";
                            //cmd.Parameters.Clear();

                            //cmd.CommandText = query;
                            //cmd.Parameters.AddWithValue("@zid", _zid);
                            //cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                            //cmd.Parameters.AddWithValue("@xsession", xsession.Text);
                            //cmd.Parameters.AddWithValue("@xeffdate", xeffdate1);
                            //cmd.Parameters.AddWithValue("@xtfccode", row.Cells[0].Text.ToString());

                            //cmd.ExecuteNonQuery();

                            query = "DELETE FROM amtfcspecialdisconf WHERE zid=@zid AND xsrow=@xsrow and xsession=@xsession and xeffdate=@xeffdate and xtfccode=@xtfccode";
                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                            cmd.Parameters.AddWithValue("@xsession", xsession.Text);
                            cmd.Parameters.AddWithValue("@xeffdate", xeffdate1);
                            cmd.Parameters.AddWithValue("@xtfccode", row.Cells[0].Text.ToString());

                            cmd.ExecuteNonQuery();
                        }

                        foreach (GridViewRow row in GridView1.Rows)
                        {

                            


                            //int xline = zglobal.GetMaximumIdInt("xline", "amtfcd", " zid=" + _zid + " and xrow=" + Convert.ToInt32(ViewState["xrow"]), "line");
                            //TextBox xamount1 = row.FindControl("xamount") as TextBox;
                            TextBox xreceived1 = row.FindControl("xreceived") as TextBox;
                            TextBox xremarks12 = row.FindControl("xremarks") as TextBox;
                            TextBox xdiscount12 = row.FindControl("xdiscount") as TextBox;
                            DropDownList xdistype12 = row.FindControl("xdistype") as DropDownList;
                            DropDownList xtype11 = row.FindControl("xtype1") as DropDownList;

                            decimal xspecialdisfixed1 = 0;
                            decimal xspecialdisperc1 = 0;

                            if (xdiscount12.Text.Trim() == "" || xdiscount12.Text.Trim() == String.Empty)
                            {
                                xdiscount12.Text = "0";
                            }

                            if (xdistype12.Text == "%")
                            {
                                xspecialdisperc1 = decimal.Parse(xdiscount12.Text.Trim());
                            }
                            else
                            {
                                xspecialdisfixed1 = decimal.Parse(xdiscount12.Text.Trim());
                            }
                            //TextBox xamount1 = row.FindControl("xamount") as TextBox;
                            //TextBox xtfccode1 = row.FindControl("xtfccode") as TextBox;

                            decimal xreceived12;
                            decimal xamount12;

                            //if (xreceived1.Text.Trim().ToString() == "" || xreceived1.Text.Trim().ToString() == String.Empty)
                            //{
                            //    //getmarks = 0;
                            //    xreceived12 = 0;
                            //}
                            //else
                            //{
                            //    xreceived12 = decimal.Parse(xreceived1.Text.Trim().ToString());
                            //}

                            //if (xamount1.Text.Trim().ToString() == "" || xamount1.Text.Trim().ToString() == String.Empty)
                            //{
                            //    //getmarks = 0;
                            //    xamount12 = 0;
                            //}
                            //else
                            //{
                            //    xamount12 = decimal.Parse(xamount1.Text.Trim().ToString());
                            //}


                            //xamount12 = decimal.Parse(row.Cells[2].Text.ToString());

                            int row111 = zglobal.GetMaximumIdInt("xrow", "amtfcspecialdisconf", " zid=" + _zid, 1, 1);
                            ViewState["xrow"] = row111;

                            query =
                                     "INSERT INTO amtfcspecialdisconf (ztime,zid,xrow,xtfccode,xclass,xgroup,xsection,xstdid,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xsign,xeffdate,zactive,xstatus,xremarks,zemail,xsrow,xtype1,xsession) " +
                                     "VALUES(@ztime,@zid,@xrow,@xtfccode,@xclass,'','',@xstdid,@xamount,@xdisfixed,@xdisperc,0,0,1,@xeffdate,1,'Submited',@xremarks,@zemail,@xsrow,@xtype1,@xsession) ";

                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", row111);
                            cmd.Parameters.AddWithValue("@xtfccode", row.Cells[0].Text.ToString());
                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString());
                            cmd.Parameters.AddWithValue("@xstdid", xstdid.Text.Trim().ToString());
                            //cmd.Parameters.AddWithValue("@xamount", xamount1.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@xamount", 0);
                            cmd.Parameters.AddWithValue("@xdisfixed", xspecialdisfixed1);
                            cmd.Parameters.AddWithValue("@xdisperc", xspecialdisperc1);
                            cmd.Parameters.AddWithValue("@xeffdate", xeffdate1);
                            cmd.Parameters.AddWithValue("@xremarks", xremarks12.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.Parameters.AddWithValue("@xtype1", xtype11.Text);
                            cmd.Parameters.AddWithValue("@xsession", xsession.Text);
                            cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                            //if (xdiscount12.Text.ToString().Trim() != "0" && xdiscount12.Text.ToString().Trim() != "0.00")
                            //{
                                cmd.ExecuteNonQuery();

                                //xamount12 = 0;

                                //int xline = 1;
                                //foreach (string type2 in type1)
                                //{
                                //    //int xline = zglobal.GetMaximumIdInt("xline", "amtfcspecialdisconft", " zid=" + _zid + " and xrow=" + xrow111, "line");

                                //    query = "INSERT INTO amtfcspecialdisconft (zid,xrow,xline,xtype,xamount) " +
                                //            "VALUES(@zid,@xrow,@xline,@xtype,@xamount) ";

                                //    cmd.CommandText = query;
                                //    cmd.Parameters.Clear();
                                //    cmd.Parameters.AddWithValue("@zid", _zid);
                                //    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //    cmd.Parameters.AddWithValue("@xline", xline);
                                //    cmd.Parameters.AddWithValue("@xtype", type2);
                                //    cmd.Parameters.AddWithValue("@xamount", xamount12);
                                //    cmd.ExecuteNonQuery();

                                //    xline = xline + 1;
                                //}
                            //}


                            

                           



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
                //ViewState["xrow"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";

                //BindGrid();
               // xrow1.Text = ViewState["xrow"].ToString();
                fnButtonState();
                fnFillGrid2();


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
                    //string query =
                    //     "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession,xcdate, " +
                    //      "(select xclass from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xclass, " +
                    //        "(select xgroup from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xgroup, " +
                    //     "(select xstdid from amadmis where zid=amtfch.zid and xrow=amtfch.xsrow) as xstdid, " +
                    //     "(select xname from amadmis where zid=amtfch.zid and xrow=amtfch.xsrow) as xname " +
                    //     "FROM amtfch WHERE zid=@zid AND xtype in ('Seat Conf','Due Rcv','Hold') AND xstatus='New' " +
                    //     "order by xrow desc";

                    string query =
                         "SELECT distinct Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xsession, xclass,  xstdid, xeffdate, " +
                         "(select xname from amadmis where zid=amtfcspecialdisconf.zid and xrow=amtfcspecialdisconf.xsrow) as xname " +
                         "FROM amtfcspecialdisconf WHERE zid=@zid AND xstdid=@xstdid AND coalesce(xsession,'')<>''" +
                         "order by xsession,xeffdate desc";


                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid.Text.Trim().ToString());


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

                    //string query =
                    //   "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xrow,xsession,xcdate, " +
                    //       "(select xclass from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xclass, " +
                    //        "(select xgroup from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xgroup, " +
                    //     "(select xstdid from amadmis where zid=amtfch.zid and xrow=amtfch.xsrow) as xstdid, " +
                    //     "(select xname from amadmis where zid=amtfch.zid and xrow=amtfch.xsrow) as xname " +
                    //     "FROM amtfch WHERE zid=@zid AND xtype in ('Seat Conf','Due Rcv','Hold') AND xstatus='Paid' " +
                    //     "order by xrow desc";

                    string query =
                        "SELECT distinct Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xsession, xclass,  xstdid, xeffdate, " +
                        "(select xname from amadmis where zid=amtfcspecialdisconf.zid and xrow=amtfcspecialdisconf.xsrow) as xname " +
                        "FROM amtfcspecialdisconf WHERE zid=@zid AND coalesce(xstdid,'')<>'' AND coalesce(xsession,'')<>''" +
                        "order by xsession,xstdid,xeffdate desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid.Text.Trim().ToString());



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvcollectionpaid.DataSource = tempTable;
                        dgvcollectionpaid.DataBind();
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
            try
            {
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

        protected void FillControl(object sender, EventArgs e)
        {
            try
            {

                //fnFillControl(((LinkButton)sender).Text);
                message.InnerHtml = "";

                hxclass.Value = xclass.Text.Trim().ToString();
                //message.InnerHtml = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                ViewState["xrow"] = null;
                xrow1.Text = "";

                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                //int i = Convert.ToInt32(row.RowIndex);

                xsession.Text = ((LinkButton)sender).Text;
                xstdid.Text = row.Cells[2].Text;
                xclass.Text = row.Cells[4].Text;
                xeffdate.Text = row.Cells[5].Text;

                xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                                "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                                xstdid.Text.ToString().Trim() + "' ");

                BindGrid();
                fnFillGrid2();

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
                   // fnFillControl(xrow1.Text.Trim().ToString());
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
            //message.InnerHtml = "";

            //divrunninginfo.Visible = true;

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();


            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //int xrow = Convert.ToInt32(xrow123);

            //string str = "SELECT  xrow,xsession, " +
            //             "(select xstdid from amadmis where zid=amtfch.zid and xrow=amtfch.xsrow) as xstdid, " +
            //             "(select xname from amadmis where zid=amtfch.zid and xrow=amtfch.xsrow) as xname, " +
            //             "(select xclass from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xclass, " +
            //             "(select xgroup from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xgroup, " +
            //             "(select xsection from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xsection, " +
            //             "(select xsessionconf from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xsessionconf, " +
            //             "(select xclassconf from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xclassconf, " +
            //             "(select xgroupconf from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xgroupconf, " +
            //             "(select xsectionconf from amtfcseatconf where zid=amtfch.zid and xrow=amtfch.xrow) as xsectionconf, " +
            //             "xcdate,xtdate,xremarks,xstatus,xbank,xchqdate,xchqno,xtype " +
            //             "FROM amtfch where zid=@zid  and xrow=@xrow ";




            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
            //da.Fill(dts, "tempztcode");
            //DataTable dttemp = new DataTable();
            //dttemp = dts.Tables[0];

            //if (dttemp.Rows.Count <= 0)
            //{
            //    message.InnerHtml = "Wrong transaction code.";
            //    message.Style.Value = zglobal.am_warningmsg;
            //    return;
            //}

            //ViewState["xrow"] = xrow.ToString();
            //hiddenxrow.Value = ViewState["xrow"].ToString();

            //xrow1.Text = dttemp.Rows[0]["xrow"].ToString();
            //xsession.Text = dttemp.Rows[0]["xsession"].ToString();
            //xstdid.Text = dttemp.Rows[0]["xstdid"].ToString();
            //xstdname.Text = dttemp.Rows[0]["xname"].ToString();
            //xclass.Text = dttemp.Rows[0]["xclass"].ToString() != "" ? dttemp.Rows[0]["xclass"].ToString() : hxclass.Value.ToString();
            //xgroup.Text = dttemp.Rows[0]["xgroup"].ToString();
            //xremarks.Text = dttemp.Rows[0]["xremarks"].ToString();
            //xsessioncur.Text = dttemp.Rows[0]["xsessionconf"].ToString();
            //xclasscur.Text = dttemp.Rows[0]["xclassconf"].ToString();
            //xgroupcur.Text = dttemp.Rows[0]["xgroupconf"].ToString();
            //xsectioncur.Text = dttemp.Rows[0]["xsectionconf"].ToString();

            //DateTime xcdate1 = Convert.ToDateTime(dttemp.Rows[0]["xcdate"]);
            //string month1 = zgetvalue.GetMonthName(xcdate1.Month);
            //string year1 = xcdate1.Year.ToString();

            //xcdate.Text = month1 + "-" + year1;
            //xtdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
            //xbank.Text = dttemp.Rows[0]["xbank"].ToString();
            //xchqdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xchqdate"]).ToString("dd/MM/yyyy");
            //xchqno.Text = dttemp.Rows[0]["xchqno"].ToString();

            //if (dttemp.Rows[0]["xtype"].ToString() == "Seat Conf")
            //{
            //    RadioButtonList1.ClearSelection();
            //    RadioButtonList1.Items.FindByValue("Seat Confirmation").Selected = true;
            //}
            //else if (dttemp.Rows[0]["xtype"].ToString() == "Hold")
            //{
            //    RadioButtonList1.ClearSelection();
            //    RadioButtonList1.Items.FindByValue("Hold").Selected = true;
            //}
            //else
            //{
            //    RadioButtonList1.ClearSelection();
            //    RadioButtonList1.Items.FindByValue("Due Receive").Selected = true;
            //}



            //if (dttemp.Rows[0]["xstatus"].ToString() == "Paid")
            //{
            //    xsession.Enabled = false;
            //    xstdid.Enabled = false;
            //    xclass.Enabled = false;
            //    xgroup.Enabled = false;
            //    xcdate.Enabled = false;
            //    xtdate.Enabled = false;
            //    xbank.Enabled = false;
            //    xchqdate.Enabled = false;
            //    xchqno.Enabled = false;
            //    xremarks.Enabled = false;
            //    RadioButtonList1.Enabled = false;


            //}
            //else
            //{
            //    xsession.Enabled = true;
            //    xstdid.Enabled = true;
            //    xclass.Enabled = true;
            //    xgroup.Enabled = false;
            //    xcdate.Enabled = true;
            //    xtdate.Enabled = true;
            //    xbank.Enabled = true;
            //    xchqdate.Enabled = true;
            //    xchqno.Enabled = true;
            //    xremarks.Enabled = true;
            //    RadioButtonList1.Enabled = true;
                
            //}

            //fnButtonState();
            //BindGrid();
            //fnCalculateTotal();
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
                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfch",
                //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                //if (ViewState["xrow"] != null)
                //{
                    if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xstatus;
                        Int64 xsrow1 = zglobal.fnGetValue("xrow", "amadmis",
               "zid=" + _zid + " and xstdid='" +
               xstdid.Text.ToString().Trim() + "' ") != ""
               ? Convert.ToInt64(zglobal.fnGetValue("xrow", "amadmis",
                   "zid=" + _zid + " and xstdid='" +
                   xstdid.Text.ToString().Trim() + "' "))
               : 0;

                        if (xsrow1 == 0)
                        {
                            message.InnerHtml = "Invalid student ID.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }

                        string[] date1 = new string[3];
                        if (xeffdate.Text.ToString().Trim() == "")
                        {
                            date1[0] = "1";
                            date1[1] = "7";
                            date1[2] = DateTime.Now.Year.ToString();
                        }
                        else
                        {
                            date1 = xeffdate.Text.Split('/');
                        }

                        int year1 = Int32.Parse(date1[2]);
                        int month1 = Int32.Parse(date1[1]);
                        int day1 = Int32.Parse(date1[0]);
                        DateTime xeffdate1 = new DateTime(year1, month1, day1);

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;

                                string query = "";

                                foreach (GridViewRow row in GridView1.Rows)
                                {
                                    //query = "DELETE FROM amtfcspecialdisconft WHERE zid=@zid AND " +
                                    //        "xrow=(select xrow from amtfcspecialdisconf WHERE zid=@zid AND xsrow=@xsrow and xsession=@xsession and xeffdate=@xeffdate and xtfccode=@xtfccode)";
                                    //cmd.Parameters.Clear();

                                    //cmd.CommandText = query;
                                    //cmd.Parameters.AddWithValue("@zid", _zid);
                                    //cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                                    //cmd.Parameters.AddWithValue("@xsession", xsession.Text);
                                    //cmd.Parameters.AddWithValue("@xeffdate", xeffdate1);
                                    //cmd.Parameters.AddWithValue("@xtfccode", row.Cells[0].Text.ToString());

                                    //cmd.ExecuteNonQuery();

                                    query = "DELETE FROM amtfcspecialdisconf WHERE zid=@zid AND xsrow=@xsrow and xsession=@xsession and xeffdate=@xeffdate and xtfccode=@xtfccode";
                                    cmd.Parameters.Clear();

                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                                    cmd.Parameters.AddWithValue("@xsession", xsession.Text);
                                    cmd.Parameters.AddWithValue("@xeffdate", xeffdate1);
                                    cmd.Parameters.AddWithValue("@xtfccode", row.Cells[0].Text.ToString());

                                    cmd.ExecuteNonQuery();
                                }

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
            //                    string xconfirmedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    DateTime xconfirmeddt = DateTime.Now;
            //                    xstatus = "Confirmed";
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
            //                        "UPDATE amtfcdueh SET xstatus=@xstatus,xconfirmedby=@xconfirmedby,xconfirmeddt=@xconfirmeddt " +
            //                        "WHERE zid=@zid AND xrow=@xrow ";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
            //                    cmd.Parameters.AddWithValue("@xconfirmedby", xconfirmedby);
            //                    cmd.Parameters.AddWithValue("@xconfirmeddt", xconfirmeddt);
            //                    cmd.ExecuteNonQuery();
            //                }

            //                tran.Complete();
            //            }

            //            message.InnerHtml = zglobal.confsuccmsg;
            //            message.Style.Value = zglobal.successmsg;
            //            btnSubmit.Enabled = false;
            //            btnSubmit1.Enabled = false;
            //            btnSave.Enabled = false;
            //            btnSave1.Enabled = false;
            //            btnDelete.Enabled = false;
            //            btnDelete1.Enabled = false;
            //            ViewState["xstatus"] = "Confirmed";
            //            hxstatus.Value = "Confirmed";
            //            //dxstatus.Visible = true;
            //            //btnPrint.Visible = true;
            //            //dxstatus.Text = "Status : Submited";
            //            hiddenxstatus.Value = "Confirmed";
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
            try
            {

                //message.InnerText = "";
                //if (ViewState["xrow"] != null)
                //{
                //    if (txtconformmessageValue.Value == "Yes")
                //    {
                //        btnSave_Click(sender, e);

                //        string xstatus;

                //        using (TransactionScope tran = new TransactionScope())
                //        {
                //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //            {
                //                conn.Open();
                //                SqlCommand cmd = new SqlCommand();
                //                cmd.Connection = conn;
                //                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //                string xpaidby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //                DateTime xpaiddt = DateTime.Now;
                //                xstatus = "Paid";
                //                string xflag10 = "";

                //                string query = "";
                //                //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                //                //if (xstatus1 == "Undo1")
                //                //{
                //                //    xflag10 = "Undo1";
                //                //    foreach (GridViewRow row in GridView1.Rows)
                //                //    {
                //                //        Label lblxline = row.FindControl("xline") as Label;
                //                //        Label lxflag1 = row.FindControl("xflag1") as Label;
                //                //        Label lxflag2 = row.FindControl("xflag2") as Label;
                //                //        //string xflag1 = "";
                //                //        //string xflag2 = "";

                //                //        string xflag1 = lxflag1.Text;
                //                //        string xflag2 = lxflag2.Text;

                //                //        if (lxflag1.Text.ToString() == "Wrong")
                //                //        {
                //                //            xflag1 = "Corrected";
                //                //        }

                //                //        if (lxflag2.Text.ToString() == "Missing")
                //                //        {
                //                //            xflag2 = "Taken";
                //                //        }

                //                //        query =
                //                //            "UPDATE amexamd SET xflag1=@xflag1,xflag2=@xflag2,xundoby=@xundoby,xundodt=@xundodt " +
                //                //            "WHERE zid=@zid AND xrow=@xrow AND xline=@xline";

                //                //        cmd.Parameters.Clear();

                //                //        cmd.CommandText = query;
                //                //        cmd.Parameters.AddWithValue("@zid", _zid);
                //                //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                //                //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lblxline.Text));
                //                //        cmd.Parameters.AddWithValue("@xflag1", xflag1);
                //                //        cmd.Parameters.AddWithValue("@xflag2", xflag2);
                //                //        cmd.Parameters.AddWithValue("@xundoby", Convert.ToString(HttpContext.Current.Session["curuser"]));
                //                //        cmd.Parameters.AddWithValue("@xundodt", DateTime.Now);
                //                //        cmd.ExecuteNonQuery();
                //                //    }
                //                //}


                //                query =
                //                    "UPDATE amtfch SET xstatus=@xstatus,xpaidby=@xpaidby,xpaiddt=@xpaiddt " +
                //                    "WHERE zid=@zid AND xrow=@xrow ";
                //                cmd.Parameters.Clear();

                //                cmd.CommandText = query;
                //                cmd.Parameters.AddWithValue("@zid", _zid);
                //                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                //                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                //                cmd.Parameters.AddWithValue("@xpaidby", xpaidby);
                //                cmd.Parameters.AddWithValue("@xpaiddt", xpaiddt);
                //                cmd.ExecuteNonQuery();
                //            }

                //            tran.Complete();
                //        }

                    
                //        btnSubmit.Enabled = false;
                //        btnSubmit1.Enabled = false;
                //        btnSave.Enabled = false;
                //        btnSave1.Enabled = false;
                //        btnDelete.Enabled = false;
                //        btnDelete1.Enabled = false;
                //        btnPaid.Enabled = false;
                //        btnPaid1.Enabled = false;
                //        btnPrint.Enabled = true;
                //        btnPrint1.Enabled = true;
                //        ViewState["xstatus"] = "Paid";
                //        hxstatus.Value = "Paid";
                //        //dxstatus.Visible = true;
                //        //btnPrint.Visible = true;
                //        //dxstatus.Text = "Status : Submited";
                //        hiddenxstatus.Value = "Paid";
                //        fnButtonState();
                //        //BindGrid();
                //        fnFillGrid2();

                //        fnFillControl(ViewState["xrow"].ToString());

                //        message.InnerHtml = zglobal.paidsuccmsg;
                //        message.Style.Value = zglobal.successmsg;
                //    }
                //}
                //else
                //{
                //    message.InnerHtml = "No record found for approved.";
                //    message.Style.Value = zglobal.warningmsg;
                //}


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void xcdate_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                //if (xclass.Text.Trim().ToString() == "")
                //{
                //    message.InnerHtml = "Student not found.";
                //    message.Style.Value = zglobal.am_warningmsg;
                //    GridView1.DataSource = null;
                //    GridView1.DataBind();
                //    return;
                //}

          //      string isStudentFound = zglobal.fnGetValue("xname", "amstudentvwextacc",
          //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
          //xstdid.Text.ToString().Trim() + "' and xsession='" + xsessioncur.Text.ToString().Trim() + "'  and zactiveacc=1");

          //      if (isStudentFound == "")
          //      {
          //          message.InnerHtml = "Student not found.";
          //          message.Style.Value = zglobal.warningmsg;
          //          xstdname.Text = "";
          //          xclasscur.Text = "";
          //          xsectioncur.Text = "";
          //          xgroupcur.Text = "";
          //          GridView1.DataSource = null;
          //          GridView1.DataBind();
          //          return;
          //      }

                //if (xcdate.Text.Trim().ToString() == "")
                //{
                //    message.InnerHtml = "Charge Period not given.";
                //    message.Style.Value = zglobal.am_warningmsg;
                //    GridView1.DataSource = null;
                //    GridView1.DataBind();
                //    return;
                //}

                BindGrid();

                //if (GridView1.DataSource != null)
                //{
                //    xnettotal2 = 0;
                //    xreceived = 0;

                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //        TextBox xrec = (TextBox)row.FindControl("xreceived");
                //        //Label xnetamt = (Label)row.FindControl("xnetamount");

                //        if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
                //        {
                //            //xrec.Text = Convert.ToDecimal("0").ToString("F"); 
                //        }
                //        else
                //        {
                //            xreceived += decimal.Parse(xrec.Text.Trim().ToString());
                //        }
                        
                //        //if (xnetamt.Text.Trim().ToString() == "" || xnetamt.Text.Trim().ToString() == String.Empty)
                //        //{
                //        //    xnetamt.Text = "0";
                //        //}
                //        //else
                //        //{
                //        //    xnettotal2 += decimal.Parse(xnetamt.Text.ToString());
                //        //}

                //        if (row.Cells[5].Text.ToString() == "" || row.Cells[5].Text.ToString() == String.Empty)
                //        {
                //            row.Cells[5].Text = "0";
                //        }
                //        else
                //        {
                //            xnettotal2 += decimal.Parse(row.Cells[5].Text.ToString());
                //        }


                //    }

                //    //GridView1.FooterRow.Cells[3].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    //GridView1.FooterRow.Cells[3].Font.Bold = true;
                //    //GridView1.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                //    //GridView1.FooterRow.Cells[3].ForeColor = Color.White;

                //    GridView1.FooterRow.Cells[5].Text = xnettotal2.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    GridView1.FooterRow.Cells[5].Font.Bold = true;
                //    GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                //    GridView1.FooterRow.Cells[5].ForeColor = Color.White;

                //    GridView1.FooterRow.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    GridView1.FooterRow.Cells[6].Font.Bold = true;
                //    GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                //    GridView1.FooterRow.Cells[6].ForeColor = Color.White;


                //}

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnCalculateTotal()
        {
            
            //xnettotal1 = 0;
            //xnettotal2 = 0;
            //xreceived = 0;
           

            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    TextBox xrec = (TextBox)row.FindControl("xreceived");
            //   // Label xnetamt = (Label) row.FindControl("xnetamount");
                

            //    if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
            //    {
            //        xrec.Text = "0.00";
            //    }

            //    //if (xnetamt.Text.Trim().ToString() == "" || xnetamt.Text.Trim().ToString() == String.Empty)
            //    //{
            //    //    xnetamt.Text = "0.00";
            //    //}

            //    if (row.Cells[5].Text.ToString() == "" || row.Cells[5].Text.ToString() == String.Empty)
            //    {
            //        row.Cells[5].Text = "0";
            //    }
                

                
            //    xreceived += decimal.Parse(xrec.Text.Trim().ToString());
            //    xnettotal1 += decimal.Parse(row.Cells[2].Text.ToString());
            //    xnettotal2 += decimal.Parse(row.Cells[5].Text.ToString());
                
            //}

            //GridView1.FooterRow.Cells[2].Text = xnettotal1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[2].Font.Bold = true;
            //GridView1.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[2].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[5].Text = xnettotal2.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[5].Font.Bold = true;
            //GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[5].ForeColor = Color.White;

            //GridView1.FooterRow.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            //GridView1.FooterRow.Cells[6].Font.Bold = true;
            //GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[6].ForeColor = Color.White;
        }

        protected void xstdid_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                divrunninginfo.Visible = false;
                //xcdate.Text = "";
                //SetInitialRow();
                hxclass.Value = xclass.Text.Trim().ToString();
                //message.InnerHtml = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                ViewState["xrow"] = null;
                xrow1.Text = "";

                xclass.Text = zglobal.fnGetValue("xclass", "amstudentvwextacc",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                  xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");

                //xsession.Text = zglobal.fnDefaults("xsessiononline", "Student");
                //RadioButtonList1.ClearSelection();
                //RadioButtonList1.Items.FindByValue("Seat Confirmation").Selected = true;
                //RadioButtonList1.Items.FindByText("Seat Confirmation").Selected = true;
                //xbank.Text = zglobal.fnDefaults("xbank", "Student");
                //xcdate.Text = DateTime.Now.ToString("MMM-yyyy");
                //xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //xchqdate.Text = "";
                //xchqno.Text = "";
                //xremarks.Text = "";

//                using (SqlConnection conn = new SqlConnection(zglobal.constring))
//                {
//                    using (DataSet dts1 = new DataSet())
//                    {
//                        string query = @"select zid,xsession,xstdid,xname,xclass,xcodealt, codealt1,
//(select xcode from mscodesam where zid=tbl.zid and xtype='Class' and cast(xcodealt as int)=codealt1)   as xclassconf
//from 
//(
//select zid,xsession,xstdid,xname,xclass, (select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as xcodealt,
//case when cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int) =
//(select max(cast(xcodealt as int)) from mscodesam where zid=a.zid and xtype='Class'  ) 
//then   cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int) else
// cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int)+1 end as codealt1
//from amstudentvwextacc as a where zactiveacc=1
// )tbl
// where zid=@zid and xsession=@xsession and xstdid=@xstdid";

//                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
//                        da1.SelectCommand.Parameters.AddWithValue("zid", Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
//                        da1.SelectCommand.Parameters.AddWithValue("xsession", xsessioncur.Text.ToString().Trim());
//                        da1.SelectCommand.Parameters.AddWithValue("xstdid", xstdid.Text.ToString().Trim());
//                        da1.Fill(dts1, "tblamadmisd");
//                        amexamd = dts1.Tables[0];
//                        if (amexamd.Rows.Count > 0)
//                        {
//                            xclass.Text = amexamd.Rows[0]["xclassconf"].ToString();
//                        }
//                        else
//                        {
//                            xclass.Text = "";
//                        }
//                    }

//                }


                BindGrid();

                if (xstdid.Text.Trim().ToString() != "")
                {
                    fnFillGrid2();
                }

                //if (GridView1.DataSource != null)
                //{
                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //        TextBox xrec = (TextBox)row.FindControl("xreceived");

                //        if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
                //        {
                //            //xrec.Text = Convert.ToDecimal("0").ToString("F"); 
                //        }
                //        else
                //        {
                //            xreceived += decimal.Parse(xrec.Text.Trim().ToString());
                //        }
                //    }

                //    GridView1.FooterRow.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    GridView1.FooterRow.Cells[6].Font.Bold = true;
                //    GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                //    GridView1.FooterRow.Cells[6].ForeColor = Color.White;


                //}

                //if (GridView1.DataSource != null)
                //{
                //    xnettotal2 = 0;
                //    xreceived = 0;

                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //        TextBox xrec = (TextBox)row.FindControl("xreceived");
                //        //Label xnetamt = (Label)row.FindControl("xnetamount");

                //        if (xrec.Text.Trim().ToString() == "" || xrec.Text.Trim().ToString() == String.Empty)
                //        {
                //            //xrec.Text = Convert.ToDecimal("0").ToString("F"); 
                //        }
                //        else
                //        {
                //            xreceived += decimal.Parse(xrec.Text.Trim().ToString());
                //        }

                //        if (row.Cells[5].ToString() == "" || row.Cells[5].ToString() == String.Empty)
                //        {
                //            row.Cells[5].Text = "0";
                //        }
                //        else
                //        {
                //            xnettotal2 += decimal.Parse(row.Cells[5].Text.ToString());
                //        }


                //    }

                //    //GridView1.FooterRow.Cells[3].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    //GridView1.FooterRow.Cells[3].Font.Bold = true;
                //    //GridView1.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                //    //GridView1.FooterRow.Cells[3].ForeColor = Color.White;

                //    GridView1.FooterRow.Cells[5].Text = xnettotal2.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    GridView1.FooterRow.Cells[5].Font.Bold = true;
                //    GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                //    GridView1.FooterRow.Cells[5].ForeColor = Color.White;

                //    GridView1.FooterRow.Cells[6].Text = xreceived.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
                //    GridView1.FooterRow.Cells[6].Font.Bold = true;
                //    GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                //    GridView1.FooterRow.Cells[6].ForeColor = Color.White;


                //}

          //      string isStudentFound = zglobal.fnGetValue("xname", "amstudentvwextacc",
          //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
          //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'  and zactiveacc=1");

          //      if (isStudentFound == "")
          //      {
          //          message.InnerHtml = "Student not found.";
          //          message.Style.Value = zglobal.warningmsg;
          //          xstdname.Text = "";
          //          xclasscur.Text = "";
          //          xsectioncur.Text = "";
          //          xgroupcur.Text = "";
          //          GridView1.DataSource = null;
          //          GridView1.DataBind();
          //          return;
          //      }

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts = new DataSet())
                //    {
                //        con.Open();
                //        string query =
                //            "SELECT top 1 * FROM amstudentvwextacc WHERE zid=@zid AND xsession=@xsession AND xstdid=@xstdid";

                //        SqlDataAdapter da = new SqlDataAdapter(query, con);

                //        da.SelectCommand.Parameters.AddWithValue("@zid", Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
                //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid.Text.ToString().Trim());



                //        DataTable tempTable = new DataTable();
                //        da.Fill(dts, "tempTable");
                //        tempTable = dts.Tables["tempTable"];

                //        if (tempTable.Rows.Count > 0)
                //        {
                //            if (tempTable.Rows[0]["xtype"].ToString() == "New" )
                //            {
                //                message.InnerHtml = "This is a new student, please collect fees from 'Tuition Fees & Other Collection' menu. ";
                //            }
                //            else
                //            {
                //                message.InnerHtml = "This student already confirm seat in this session, please collect fees from 'Tuition Fees & Other Collection' menu. ";
                //            }

                //            message.Style.Value = zglobal.am_warningmsg;
                //            return;
                //        }


                //    }
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