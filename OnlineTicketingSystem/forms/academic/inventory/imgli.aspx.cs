using System;
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

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class imgli : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            if (ViewState["xrow"] == null)
            {
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete1.Enabled = true;
                //dxstatus.Visible = false;
                //dxstatus.Text = "-";
                hxstatus.Value = "";
               // xtfccode.Enabled = true;
                //xeffdate.Enabled = true;
                //xclass.Enabled = true;
                xgroup.Enabled = true;
                xsection.Enabled = true;
                xstdid.Enabled = true;
                btnActive.Visible = false;
                btnActive1.Visible = false;
                btnInactive.Visible = false;
                btnInactive1.Visible = false;
            }
            else
            {
                //xtfccode.Enabled = false;
                //xeffdate.Enabled = false;
                //xclass.Enabled = false;
                xgroup.Enabled = false;
                xsection.Enabled = false;
                xstdid.Enabled = false;
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //string xstatus1 = zglobal.fnGetValue("xstatus", "amtfcspecialdisconf",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //xstatus.InnerHtml = xstatus1;
                //zemail.InnerHtml = zglobal.fnGetValue("zemail", "amtfcspecialdisconf",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //xemail.InnerHtml = zglobal.fnGetValue("xemail", "amtfcspecialdisconf",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    //dxstatus.Visible = true;
                //if (xstatus1 == "New" || xstatus1 == "Undo")
                //{
                //    btnSubmit.Enabled = true;
                //    btnSubmit1.Enabled = true;
                //    btnSave.Enabled = true;
                //    btnSave1.Enabled = true;
                //    btnDelete.Enabled = true;
                //    btnDelete1.Enabled = true;
                //    //dxstatus.Text = xstatus1;
                //    hxstatus.Value = xstatus1;
                //    //dxstatus.Style.Value = zglobal.am_new;
                //    btnActive.Visible = false;
                //    btnActive1.Visible = false;
                //    btnInactive.Visible = false;
                //    btnInactive1.Visible = false;

                //}
                //else
                //{
                //    btnSubmit.Enabled = false;
                //    btnSubmit1.Enabled = false;
                //    btnSave.Enabled = false;
                //    btnSave1.Enabled = false;
                //    btnDelete.Enabled = false;
                //    btnDelete1.Enabled = false;
                //    //dxstatus.Text = xstatus1;
                //    hxstatus.Value = xstatus1;
                //    //dxstatus.Style.Value = zglobal.am_submited;
                //    if (xstatus1 == "Submited")
                //    {
                //        btnActive.Visible = true;
                //        btnActive1.Visible = true;
                //        btnInactive.Visible = true;
                //        btnInactive1.Visible = true;

                //        if (zglobal.fnGetValue("zactive", "amtfcspecialdisconf",
                //            "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"])) == "1")
                //        {
                //            btnActive.Enabled = false;
                //            btnActive1.Enabled = false;
                //            btnInactive.Enabled = true;
                //            btnInactive1.Enabled = true;
                //        }
                //        else
                //        {
                //            btnActive.Enabled = true;
                //            btnActive1.Enabled = true;
                //            btnInactive.Enabled = false;
                //            btnInactive1.Enabled = false;
                //        }
                //    }
                    
                //}

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
                //    }

            }

            btnSubmit.Visible = false;
            btnSubmit1.Visible = false;
            btnActive.Visible = false;
            btnActive1.Visible = false;
            btnInactive.Visible = false;
            btnInactive1.Visible = false;
            btnSave.Enabled = true;
            btnSave1.Enabled = true;
            btnDelete.Enabled = true;
            btnDelete1.Enabled = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Test Type", xcttype);

                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    //zglobal.fnGetComboDataCD("Bank", xbank);
                    //zglobal.fnGetComboDataCD("GL Interface Type", xtype);
                    zglobal.fnGetComboDataCDTRN("'GL Voucher'", xprefix);
                    zglobal.fnGetComboDataCDTRN("'Im Transaction','Transfer Transaction'", xtrnim);

                    xaction.Items.Clear();
                    xaction.Items.Add("");
                    xaction.Items.Add("Issue");
                    xaction.Items.Add("Receipt");
                    xaction.Text = "";

                    zglobal.fnGetComboDataCD("Item Group", xglevel1);
                    zglobal.fnGetComboDataCD("Warehouse", xwh);

                    //xtype.Items.Add("");
                    //xtype.Items.Add("Revenue");
                    //xtype.Items.Add("Discount");
                    //xtype.Items.Add("Special Discount");
                    //xtype.Items.Add("Received");
                    //xtype.Text = "";

                    //xtype1.Items.Add("");
                    //xtype1.Items.Add("Single");
                    //xtype1.Items.Add("Monthly");
                    //xtype1.Items.Add("Yearly");
                    //xtype1.Items.Add("N/A");
                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    ////zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    ViewState["xrow"] = null;
                    //ViewState["xstatus"] = null;
                    //ViewState["dtprectmarks"] = null;
                    //ViewState["colid"] = null;
                    //ViewState["sortdr"] = null;
                    //hxstatus.Value = "";
                    //_classteacher.Value = "";
                    //_subteacher.Value = "";

                    fnButtonState();
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

                    xstatus.InnerHtml = "";
                    zemail.InnerHtml = "";
                    xemail.InnerHtml = "";
                    zactive.Checked = true;

                    _gridrow.Text = zglobal._grid_row_value100;
                    _gridrow1.Text = zglobal._grid_row_value;
                  

                    btnActive.Visible = false;
                    btnActive1.Visible = false;
                    btnInactive.Visible = false;
                    btnInactive1.Visible = false;

                    ViewState["xmodule"] = "Inventory";

                    fnFillGrid2();

                }




                //xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
                //   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xcode='" +
                //   xkey.Text.ToString().Trim() + "'" + "and xtype='TFC Code' and zactive=1");

                xdescdr.Text = zglobal.fnGetValue("xdesc", "glmst",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xaccdr.Text.ToString() + "'");

                xdescsubdr.Text = zglobal.fnGetValue("xdescsub", "glmstvw",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xaccdr.Text.ToString() + "' " +
                  "and xsub='" + xsubdr.Text.Trim().ToString() + "'");

                xdesccr.Text = zglobal.fnGetValue("xdesc", "glmst",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacccr.Text.ToString() + "'");

                xdescsubcr.Text = zglobal.fnGetValue("xdescsub", "glmstvw",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacccr.Text.ToString() + "' " +
                  "and xsub='" + xsubcr.Text.Trim().ToString() + "'");

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //    xstdid.Text.ToString().Trim() +"'");

                //BindGrid();
                fnRegisterPostBack();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnRegisterPostBack()
        {
            foreach (GridViewRow row in dgvTFCListNew.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            //foreach (GridViewRow row in dgvTFCListSubmitted.Rows)
            //{
            //    LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            //}
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        private void BindGrid()
        {

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();

            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ////string xsession1 = xsession.Text.Trim().ToString();
            ////string xclass1 = xclass.Text.Trim().ToString();
            ////string xgroup1 = xgroup.Text.Trim().ToString();
            ////string xsection1 = xsection.Text.Trim().ToString();
            ////message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            ////return;
            //string str = "";

            ////if (ViewState["sortdr"] != null)
            ////{
            ////    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY " + Convert.ToString(ViewState["colid"]) + " " + Convert.ToString(ViewState["sortdr"]);
            ////}
            ////else
            ////{
            ////    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";
            ////}

            //str = "SELECT   ROW_NUMBER() OVER (ORDER BY xcodealt) AS xid, xcode FROM mscodesam WHERE zid=@zid AND xtype='Fees Type' AND zactive=1 ORDER BY xcodealt";

            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            ////da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            ////da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            ////da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //da.Fill(dts, "tempztcode");
            //DataTable dtmarks = new DataTable();
            //dtmarks = dts.Tables[0];

            //if (dtmarks.Rows.Count > 0)
            //{




            //    //DataSet dts2 = new DataSet();

            //    //dts2.Reset();

            //    //DateTime xexamdate1 = fnGetExamDate();
            //    //string str2 = "SELECT xsubject,xmark, xpassmark FROM  ammarks " +
            //    //              "WHERE zid=@zid AND xclass=@xclass  AND xtype='admistest' AND " +
            //    //              "xeffdate=(SELECT MAX(xeffdate)FROM ammarks WHERE zid=@zid and xclass=@xclass and xgroup=@xgroup " +
            //    //              "and xeffdate<=@xexamdate and xtype='admistest' AND zactive=1 AND xstatus='Approved' ) AND zactive=1 AND xstatus='Approved' AND xgroup=@xgroup";

            //    //SqlDataAdapter da2 = new SqlDataAdapter(str2, conn1);
            //    //da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //da2.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //    //da2.SelectCommand.Parameters.AddWithValue("@xexamdate", xexamdate1);
            //    //da2.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //    //da2.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //    //da2.Fill(dts2, "tempztcode");
            //    //DataTable dtmarks2 = new DataTable();
            //    //dtmarks2 = dts2.Tables[0];
            //    //if (dtmarks2.Rows.Count > 0)
            //    //{

            //    GridView1.Columns.Clear();
            //    //Change Index
            //    //ViewState["numrow"] = dtmarks2.Rows.Count;

            //    TemplateField tfield119 = new TemplateField();
            //    //tfield119.HeaderText = "No.";
            //    tfield119.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield119.ItemStyle.Width = 35;
            //    GridView1.Columns.Add(tfield119);

                

            //    //bfield = new BoundField();
            //    //bfield.HeaderText = "No.";
            //    //bfield.DataField = "xid";
            //    //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //bfield.ItemStyle.Width = 35;
            //    //GridView1.Columns.Add(bfield);

            //    bfield = new BoundField();
            //    bfield.HeaderText = "Fees Type";
            //    //bfield.SortExpression = "xcode";
            //    bfield.DataField = "xcode";
            //    bfield.ItemStyle.Width = 50;
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            //    GridView1.Columns.Add(bfield);

            //    //bfield = new BoundField();
            //    //bfield.HeaderText = "Student's Name";
            //    //bfield.SortExpression = "xname";
            //    //bfield.DataField = "xname";
            //    //bfield.ItemStyle.Width = 200;
            //    //GridView1.Columns.Add(bfield);



            //    ////int tmarks = 0;
            //    ////int passm = 0;
            //    ////dt = new DataTable();
            //    ////dt.Columns.AddRange(new DataColumn[3] { 
            //    ////    new DataColumn("xsubject", typeof(string)),
            //    ////    new DataColumn("xmark", typeof(string)),
            //    ////    new DataColumn("xpassmark",typeof(string)) });
            //    ////foreach (DataRow row in dtmarks2.Rows)
            //    ////{
            //    ////    tfield = new TemplateField();
            //    ////    tfield.HeaderText = row["xsubject"].ToString() + " (" + row["xmark"].ToString() + ")";
            //    ////    //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    ////    tfield.ItemStyle.Width = 50;
            //    ////    GridView1.Columns.Add(tfield);

            //    ////    tmarks = tmarks + Convert.ToInt32(row["xmark"].ToString());
            //    ////    passm = passm + Convert.ToInt32(row["xpassmark"].ToString());
            //    ////    dt.Rows.Add(row["xsubject"].ToString(), row["xmark"].ToString(), row["xpassmark"].ToString());
            //    ////}

            //    ////xtotalmaks.Text = tmarks.ToString();
            //    ////int pass = (100 * passm) / tmarks;
            //    ////xpassmarks.Text = pass.ToString() + "%";

            //    //TemplateField tfield9 = new TemplateField();
            //    //tfield9.HeaderText = "Pre. Marks";
            //    //tfield9.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield9.ItemStyle.Width = 70;
            //    //GridView1.Columns.Add(tfield9);

            //    ////if (xcttype.Text == "Extra Test" && xreference.SelectedItem.Text!="")
            //    //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
            //    //{
            //    //    tfield9.Visible = true;
            //    //}
            //    //else
            //    //{
            //    //    tfield9.Visible = false;
            //    //}

            //    tfield = new TemplateField();
            //    tfield.HeaderText = "Amount";
            //    //tfield.HeaderText = "";
            //    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield.ItemStyle.Width = 150;
            //    GridView1.Columns.Add(tfield);
            //    tfield.ItemStyle.CssClass = "hiddencol";
            //    tfield.HeaderStyle.CssClass = "hiddencol";
            //    tfield.FooterStyle.CssClass = "hiddencol";

            //    ////tfield = new TemplateField();
            //    ////tfield.HeaderText = "%";
            //    ////tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    ////tfield.ItemStyle.Width = 70;
            //    ////GridView1.Columns.Add(tfield);





            //    //TemplateField tfield1 = new TemplateField();
            //    //tfield1.HeaderText = "Comments";
            //    //tfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    ////tfield1.ItemStyle.Width = Unit.Pixel(250);
            //    //GridView1.Columns.Add(tfield1);

            //    //BoundField bfield1 = new BoundField();
            //    //bfield1.DataField = "xrow";
            //    //GridView1.Columns.Add(bfield1);


            //    TemplateField tfield2 = new TemplateField();
            //    tfield2.HeaderText = "";
            //    tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield2.Visible = false;
            //    //tfield2.ItemStyle.Width = Unit.Pixel(30);
            //    GridView1.Columns.Add(tfield2);

            //    TemplateField tfield3 = new TemplateField();
            //    tfield3.HeaderText = "";
            //    tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield1.ItemStyle.Width = 50;
            //    GridView1.Columns.Add(tfield3);




            //    //if (ViewState["xrow"] != null)
            //    //{
            //    //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //    //    {
            //    //        using (DataSet dts1 = new DataSet())
            //    //        {
            //    //            string query = "SELECT *, coalesce(xflag1,'') as xflag11, coalesce(xflag2,'') as xflag22 FROM amexamd WHERE zid=@zid AND xrow=@xrow";
            //    //            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
            //    //            da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
            //    //            da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
            //    //            da1.Fill(dts1, "tblamadmisd");
            //    //            //tblamadmisd = new DataTable();
            //    //            amexamd = dts1.Tables[0];
            //    //        }
            //    //    }


            //    //    string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh",
            //    //           "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    //    ViewState["xstatus"] = xstatus1;
            //    //    hxstatus.Value = xstatus1;
            //    //}
            //    //else
            //    //{
            //    //    hxstatus.Value = "";
            //    //}

            //    //if (ViewState["xrow"] != null)
            //    //{

            //    //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfcconfigvw",
            //    //           "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    //    if (xstatus1 != "")
            //    //    {
            //    //        ViewState["xstatus"] = xstatus1;
            //    //        hxstatus.Value = xstatus1;
            //    //    }
            //    //    else
            //    //    {
            //    //        hxstatus.Value = "";
            //    //        ViewState["xstatus"] = "";
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    hxstatus.Value = "";
            //    //    ViewState["xstatus"] = "";
            //    //}

            //    //TemplateField tfield4 = new TemplateField();
            //    //tfield4.HeaderText = "";
            //    //tfield4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield4.Visible = false;
            //    //GridView1.Columns.Add(tfield4);

            //    //TemplateField tfield5 = new TemplateField();
            //    //tfield5.HeaderText = "";
            //    //tfield5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield5.Visible = false;
            //    //GridView1.Columns.Add(tfield5);

            //    //TemplateField tfield6 = new TemplateField();
            //    //tfield6.HeaderText = "";
            //    //tfield6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield6.Visible = false;
            //    //GridView1.Columns.Add(tfield6);

            //    //TemplateField tfield7 = new TemplateField();
            //    //tfield7.HeaderText = "N/A";
            //    //tfield7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield7.ItemStyle.Width = Unit.Pixel(30);
            //    //// tfield7.Visible = false;
            //    //GridView1.Columns.Add(tfield7);

            //    GridView1.DataSource = dtmarks;
            //    GridView1.DataBind();

            //    //int i = 1;
            //    //foreach (GridViewRow row in GridView1.Rows)
            //    //{
            //    //    Label lbl = (Label)row.FindControl("lblno");
            //    //    lbl.Text = i.ToString();
            //    //    i++;
            //    //}

            //    //ViewState["dirState"] = dtmarks;
            //    //// ViewState["sortdr"] = "Asc";

            //    //bfield1.Visible = false;

            //    ////}
            //    ////else
            //    ////{
            //    ////    GridView1.DataSource = null;
            //    ////    GridView1.DataBind();
            //    ////    xtotalmaks.Text = "";
            //    ////    xpassmarks.Text = "";
            //    ////    ViewState["numrow"] = null;
            //    ////}


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

            //    CheckBox chkCheckBox = new CheckBox();
            //    chkCheckBox.ID = "chkall";
            //    GridView1.HeaderRow.Cells[0].Controls.Add(chkCheckBox);

            //    //if (ViewState["xrow"] != null)
            //    //{
            //    //    if (Convert.ToString(ViewState["xstatus"]) != "New" &&
            //    //         Convert.ToString(ViewState["xstatus"]) != "Undo" &&
            //    //         Convert.ToString(ViewState["xstatus"]) != "Undo1")
            //    //    {
            //    //        chkCheckBox.Enabled = false;
            //    //    }
            //    //    else
            //    //    {
            //    //        chkCheckBox.Enabled = true;
            //    //    }
            //    //}

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


            //        CheckBox chkCheckBox = new CheckBox();
            //        chkCheckBox.ID = "selbiz";
            //        chkCheckBox.CssClass = "selbiz";
            //        e.Row.Cells[0].Controls.Add(chkCheckBox);

            //        TextBox txtAmount = new TextBox();
            //        txtAmount.ID = "xamount";
            //        txtAmount.CssClass = "xamount";
            //        txtAmount.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //        e.Row.Cells[2].Controls.Add(txtAmount);

                    

            //        //if (ViewState["xrow"] != null)
            //        //{
            //        //    if (Convert.ToString(ViewState["xstatus"]) != "New" &&
            //        //     Convert.ToString(ViewState["xstatus"]) != "Undo" &&
            //        //     Convert.ToString(ViewState["xstatus"]) != "Undo1")
            //        //    {
            //        //        txtAmount.Enabled = false;
            //        //        chkCheckBox.Enabled = false;
            //        //    }
            //        //    else
            //        //    {
            //        //        txtAmount.Enabled = true;
            //        //        chkCheckBox.Enabled = true;
            //        //    }
            //        //}

            //        //Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

            //        //Label lblno = new Label();
            //        //lblno.ID = "lblno";
            //        //e.Row.Cells[0].Controls.Add(lblno);

            //        //TextBox txtPreMarks = new TextBox();
            //        //txtPreMarks.ID = "txtPreMarks";
            //        //txtPreMarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //        //e.Row.Cells[3].Controls.Add(txtPreMarks);
            //        //txtPreMarks.Enabled = false;

            //        //TextBox txtMarks = new TextBox();
            //        //txtMarks.ID = "txtMarks";
            //        //txtMarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox bm_marks";
            //        ////txtMarks.AutoPostBack = true;
            //        ////txtMarks.TextChanged += OnTextChanged;
            //        //txtMarks.Attributes.Add("onkeyup", "enter(this,event)");
            //        //e.Row.Cells[4].Controls.Add(txtMarks);

            //        //TextBox txtComments = new TextBox();
            //        //txtComments.ID = "txtComments";
            //        //txtComments.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //        //txtComments.TextMode = TextBoxMode.MultiLine;
            //        //txtComments.Attributes.Add("onkeyup", "enter(this,event)");
            //        //e.Row.Cells[5].Controls.Add(txtComments);

            //        //HtmlGenericControl image = new HtmlGenericControl("img");
            //        //image.ID = "image2";
            //        //image.Attributes.Add("src", "/images/list-am32x32.png");
            //        //image.Attributes.Add("class", "bm_academic_list bm_list");
            //        //image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
            //        //e.Row.Cells[7].Controls.Add(image);

            //        //Label lblxline = new Label();
            //        //lblxline.ID = "xline";
            //        //e.Row.Cells[8].Controls.Add(lblxline);

            //        //Label lblxflag1 = new Label();
            //        //lblxflag1.ID = "xflag1";
            //        //e.Row.Cells[9].Controls.Add(lblxflag1);

            //        //Label lblxflag2 = new Label();
            //        //lblxflag2.ID = "xflag2";
            //        //e.Row.Cells[10].Controls.Add(lblxflag2);

            //        //CheckBox chkCheckBox = new CheckBox();
            //        //chkCheckBox.ID = "xna";
            //        //e.Row.Cells[11].Controls.Add(chkCheckBox);

            //        ////ImageButton image = new ImageButton();
            //        ////image.ID = "image2";
            //        ////image.Attributes.Add("src", "/images/list-am32x32.png");
            //        ////image.Attributes.Add("class", "bm_academic_list bm_list");
            //        ////image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
            //        ////e.Row.Cells[6].Controls.Add(image);

            //        //if (ViewState["xrow"] != null)
            //        //{
            //        //    if (Convert.ToString(ViewState["xstatus"]) != "New" && Convert.ToString(ViewState["xstatus"]) != "Undo" && Convert.ToString(ViewState["xstatus"]) != "Undo1")
            //        //    {
            //        //        txtComments.Enabled = false;
            //        //        txtMarks.Enabled = false;
            //        //        chkCheckBox.Enabled = false;
            //        //        //image.Enabled = false;
            //        //        //Page.ClientScript.RegisterHiddenField("hxstatus", ViewState["xstatus"].ToString());
            //        //    }



            //        //    if (amexamd.Rows.Count > 0)
            //        //    {
            //        //        foreach (DataRow row in amexamd.Rows)
            //        //        {
            //        //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
            //        //            {
            //        //                if (row["xgetmark"].ToString() == "-1.00")
            //        //                {
            //        //                    txtMarks.Text = "";
            //        //                }
            //        //                else
            //        //                {
            //        //                    txtMarks.Text = row["xgetmark"].ToString();
            //        //                }

            //        //                int chk = DBNull.Value.Equals(row["xna"]) == true
            //        //                    ? 0
            //        //                    : Convert.ToInt32(row["xna"].ToString());

            //        //                if (chk == 1)
            //        //                {
            //        //                    chkCheckBox.Checked = true;
            //        //                }
            //        //                else
            //        //                {
            //        //                    chkCheckBox.Checked = false;
            //        //                }

            //        //                txtComments.Text = row["xremarks"].ToString();
            //        //                lblxline.Text = row["xline"].ToString();
            //        //                lblxflag1.Text = row["xflag11"].ToString();
            //        //                lblxflag2.Text = row["xflag22"].ToString();

            //        //                //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
            //        //                //{
            //        //                //    //if (row["xflag11"].ToString() == "Wrong" ||
            //        //                //    //    row["xflag22"].ToString() == "Missing" || row["xflag11"].ToString() == "Corrected" ||
            //        //                //    //    row["xflag22"].ToString() == "Taken")
            //        //                //    //if (row["xflag11"].ToString() == "" ||
            //        //                //    //    row["xflag22"].ToString() == "")
            //        //                //    if (row["xflag11"].ToString() == "Wrong" || row["xflag22"].ToString() == "Missing")
            //        //                //    {
            //        //                //        txtComments.Enabled = true;
            //        //                //        txtMarks.Enabled = true;
            //        //                //        chkCheckBox.Enabled = true;
            //        //                //    }

            //        //                //    //if (lblxline.Text == "" || lblxline.Text == String.Empty)
            //        //                //    //{
            //        //                //    //    txtComments.Enabled = true;
            //        //                //    //    txtMarks.Enabled = true;
            //        //                //    //}

            //        //                //}
            //        //                break;
            //        //            }
            //        //        }

            //        //        //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
            //        //        //{
            //        //        //    if (lblxline.Text == "" || lblxline.Text == String.Empty)
            //        //        //    {
            //        //        //        txtComments.Enabled = true;
            //        //        //        txtMarks.Enabled = true;
            //        //        //        chkCheckBox.Enabled = true;
            //        //        //    }
            //        //        //}
            //        //    }


            //        //}


            //        //if (ViewState["dtprectmarks"] != null)
            //        //{
            //        //    DataTable dtprectmarks = (DataTable)ViewState["dtprectmarks"];
            //        //    if (dtprectmarks.Rows.Count > 0)
            //        //    {
            //        //        foreach (DataRow row in dtprectmarks.Rows)
            //        //        {
            //        //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
            //        //            {
            //        //                if (row["xgetmark"].ToString() == "-1.00")
            //        //                {
            //        //                    txtPreMarks.Text = "";
            //        //                }
            //        //                else
            //        //                {
            //        //                    txtPreMarks.Text = row["xgetmark"].ToString();
            //        //                }

            //        //                int chk = DBNull.Value.Equals(row["xna"]) == true
            //        //                  ? 0
            //        //                  : Convert.ToInt32(row["xna"].ToString());

            //        //                if (chk == 1)
            //        //                {
            //        //                    chkCheckBox.Checked = true;
            //        //                }
            //        //                else
            //        //                {
            //        //                    chkCheckBox.Checked = false;
            //        //                }

            //        //                break;
            //        //            }
            //        //        }
            //        //    }
            //        //}
            //        //else
            //        //{
            //        //    txtPreMarks.Text = "";
            //        //}



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
            //        string query;

            //        //if (xctno.Text != "")
            //        //{
            //        //    query =
            //        //    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno AND xdate=@xdate";
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
                //btnRefresh_Click(sender,e);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = 0;
                message.InnerHtml = "";

                
                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                if (xtrnim.Text == "" || xtrnim.Text == string.Empty || xtrnim.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>IM Transaction</li>";
                    isValid = false;
                }

                if (xaction.Text == "" || xaction.Text == string.Empty || xaction.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Action</li>";
                    isValid = false;
                }

                if (xglevel1.Text == "" || xglevel1.Text == string.Empty || xglevel1.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Item Group</li>";
                    isValid = false;
                }

                if (xwh.Text == "" || xwh.Text == string.Empty || xwh.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Warehouse</li>";
                    isValid = false;
                }

                if (xprefix.Text == "" || xprefix.Text == string.Empty || xprefix.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Voucher Prefix</li>";
                    isValid = false;
                }

                if (xaccdr.Text == "" || xaccdr.Text == string.Empty || xaccdr.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Debit Account</li>";
                    isValid = false;
                }

                string xsubdr123 = zglobal.fnGetValue("xsub", "glmstvw",
                   "zid=" + _zid + " and zactive=1 and xaccsource<>'None' and xacc='" + xaccdr.Text.Trim().ToString() +
                   "'");
                if (xsubdr123 != "")
                {
                    if (xsubdr.Text == "" || xsubdr.Text == string.Empty || xsubdr.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Debit Sub Acc.</li>";
                        isValid = false;
                    }
                }
                else
                {
                    xsubdr.Text = "";
                }

                if (xacccr.Text == "" || xacccr.Text == string.Empty || xacccr.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Credit Account</li>";
                    isValid = false;
                }

                string xsubcr123 = zglobal.fnGetValue("xsub", "glmstvw",
                   "zid=" + _zid + " and zactive=1 and xaccsource<>'None' and xacc='" + xacccr.Text.Trim().ToString() +
                   "'");
                if (xsubcr123 != "")
                {
                    if (xsubcr.Text == "" || xsubcr.Text == string.Empty || xsubcr.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Credit Sub Acc.</li>";
                        isValid = false;
                    }
                }
                else
                {
                    xsubcr.Text = "";
                }

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                if (xaccdr.Text.Trim().ToString() != String.Empty)
                {
                    if (zglobal.fnGetValue("xacc", "glmst",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + "  and xacc='" + xaccdr.Text.ToString().Trim() + "'") == "")
                    {
                        message.InnerText = "Invalid Debit Account";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                if (xacccr.Text.Trim().ToString() != String.Empty)
                {
                    if (zglobal.fnGetValue("xacc", "glmst",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + "  and xacc='" + xacccr.Text.ToString().Trim() + "'") == "")
                    {
                        message.InnerText = "Invalid Credit Account";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                if (xsubdr123 != "")
                {
                    string xsubdr1234 = zglobal.fnGetValue("xsub", "glmstvw",
                        "zid=" + _zid + " and zactive=1 and xaccsource<>'None' and xacc='" +
                        xaccdr.Text.Trim().ToString() +
                        "' and ( xsub like '%" + xaccdr.Text.Trim().ToString() + "%' or xdescsub like '%" +
                        xaccdr.Text.Trim().ToString() + "%') ");

                    if (xsubdr1234 == "")
                    {
                        message.InnerHtml = "Record Pointer Mismatch.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }


                if (xsubcr123 != "")
                {
                    string xsubcr1234 = zglobal.fnGetValue("xsub", "glmstvw",
                        "zid=" + _zid + " and zactive=1 and xaccsource<>'None' and xacc='" +
                        xacccr.Text.Trim().ToString() +
                        "' and ( xsub like '%" + xacccr.Text.Trim().ToString() + "%' or xdescsub like '%" +
                        xacccr.Text.Trim().ToString() + "%') ");

                    if (xsubcr1234 == "")
                    {
                        message.InnerHtml = "Record Pointer Mismatch.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                
                string xtfccode1 = "";
                string xclass1 = "";
                string xgroup1 = "";
                string xsection1 = "";
                string xstdid1 = "";
                decimal xamount1 = 0;
                decimal xdisfixed1 = 0;
                decimal xdisperc1 = 0;
                decimal xvatfixed1 = 0;
                decimal xvatperc1 = 0;
                int xsign1 = 1;
                DateTime xeffdate1 = DateTime.Now;
                int zactive1 = 1;
                string xstatus1 = "New";
                string xremarks1 = "";
                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                DateTime xsubmitdt = DateTime.Now;


                string xmodule1 = "";
                string xkey1 = "";
                string xtype12 = "";
                string xaccdr1 = "";
                string xsubdr1 = "";
                string xacccr1 = "";
                string xsubcr1 = "";
                string xbank1 = "";
                string xprefix1 = "";
                string xtrnim1 = "";
                string xaction1 = "";
                string xglevel11 = "";
                string xwh1 = "";


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
                                //string query =
                                //    "SELECT * FROM glinterface WHERE zid=@zid AND xtype=@xtype AND xprefix=@xprefix AND xaccdr=@xaccdr AND xsubdr=@xsubdr AND xacccr=@xacccr AND xsubcr=@xsubcr and xmodule=@xmodule ";

                                string query =
                                   "SELECT * FROM glinterface WHERE zid=@zid AND xtrnim=@xtrnim AND xaction=@xaction AND xglevel1=@xglevel1 AND xwh=@xwh and xmodule=@xmodule "; //AND xbank=@xbank AND xprefix=@xprefix 


                                SqlDataAdapter da = new SqlDataAdapter(query, con);

                                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da.SelectCommand.Parameters.AddWithValue("@xtrnim", xtrnim.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xprefix", xprefix.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xaccdr", xaccdr.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xsubdr", xsubdr.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xacccr", xacccr.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xsubcr", xsubcr.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xaction", xaction.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xglevel1", xglevel1.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xwh", xwh.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xmodule", ViewState["xmodule"].ToString());


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
                                "INSERT INTO glinterface (ztime,zid,xrow,xmodule,xtrnim,xaction,xglevel1,xaccdr,xsubdr,xacccr,xsubcr,xwh,xprefix,zemail) " +
                                "VALUES(@ztime,@zid,@xrow,@xmodule,@xtrnim,@xaction,@xglevel1,@xaccdr,@xsubdr,@xacccr,@xsubcr,@xwh,@xprefix,@zemail) ";

                            xrow = zglobal.GetMaximumIdInt("xrow", "glinterface", " zid=" + _zid, 1, 1);
                            ViewState["xrow"] = xrow;
                            //xtfccode1 = xtfccode.Text.Trim().ToString();
                            //xclass1 = xclass.Text.Trim().ToString();
                            //xgroup1 = xgroup.Text.Trim().ToString();
                            //xsection1 = xsection.Text.Trim().ToString();
                            //xstdid1 = xstdid.Text.Trim().ToString();
                            //xamount1 = xamount.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xamount.Text.Trim().ToString())
                            //    : 0;
                            //xdisfixed1 = xdisfixed.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xdisfixed.Text.Trim().ToString())
                            //    : 0;
                            //xdisperc1 = xdisperc.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xdisperc.Text.Trim().ToString())
                            //    : 0;
                            //xvatfixed1 = xvatfixed.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xvatfixed.Text.Trim().ToString())
                            //    : 0;
                            //xvatperc1 = xvatperc.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xvatperc.Text.Trim().ToString())
                            //    : 0;
                            //xsign1 = xsign.Text.Trim().ToString() != string.Empty
                            //    ? int.Parse(xsign.Text.ToString().Trim())
                            //    : 1;

                            //xeffdate1 = xeffdate.Text.ToString().Trim() != string.Empty
                            //    ? DateTime.ParseExact(xeffdate.Text.ToString().Trim(), "dd/MM/yyyy",
                            //        CultureInfo.InvariantCulture)
                            //    : DateTime.Now;

                            //zactive1 = zactive.Checked ? 1 : 0;

                            //xremarks1 = xremarks.Value.Trim().ToString();
                            ////xtype12 = xtype1.Text.Trim().ToString();
                            //xtype12 = zglobal.fnProperty("TFC Code", xtfccode1, "xtype");

                            xmodule1 = ViewState["xmodule"].ToString();
                            xtrnim1 = xtrnim.Text.Trim().ToString();
                            xaction1 = xaction.Text.Trim().ToString();
                            xglevel11 = xglevel1.Text.Trim().ToString();
                            xaccdr1 = xaccdr.Text.Trim().ToString();
                            xsubdr1 = xsubdr.Text.Trim().ToString();
                            xacccr1 = xacccr.Text.Trim().ToString();
                            xsubcr1 = xsubcr.Text.Trim().ToString();
                            xwh1 = xwh.Text.Trim().ToString();
                            xprefix1 = xprefix.Text.Trim().ToString();


                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", xrow);
                            cmd.Parameters.AddWithValue("@xmodule", xmodule1);
                            cmd.Parameters.AddWithValue("@xtrnim", xtrnim1);
                            cmd.Parameters.AddWithValue("@xaction", xaction1);
                            cmd.Parameters.AddWithValue("@xglevel1", xglevel11);
                            cmd.Parameters.AddWithValue("@xaccdr", xaccdr1);
                            cmd.Parameters.AddWithValue("@xsubdr", xsubdr1);
                            cmd.Parameters.AddWithValue("@xacccr", xacccr1);
                            cmd.Parameters.AddWithValue("@xsubcr", xsubcr1);
                            cmd.Parameters.AddWithValue("@xwh", xwh1);
                            cmd.Parameters.AddWithValue("@xprefix", xprefix1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.ExecuteNonQuery();
                        }
                    }



                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        string query = "";

                        //query = "DELETE FROM amtfcconfigt WHERE zid=@zid AND xrow=@xrow";
                        //cmd.Parameters.Clear();

                        //cmd.CommandText = query;
                        //cmd.Parameters.AddWithValue("@zid", _zid);
                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                        ////if (xstatus1 != "Undo1" && xstatus1 != "Undo")
                        ////if (xstatus1 != "Undo1")
                        ////{
                        //cmd.ExecuteNonQuery();
                        ////}


                        if (xrow == 0)
                        {


                            //xtfccode1 = xtfccode.Text.Trim().ToString();
                            //xclass1 = xclass.Text.Trim().ToString();
                            //xgroup1 = xgroup.Text.Trim().ToString();
                            //xsection1 = xsection.Text.Trim().ToString();
                            //xstdid1 = xstdid.Text.Trim().ToString();
                            //xamount1 = xamount.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xamount.Text.Trim().ToString())
                            //    : 0;
                            //xdisfixed1 = xdisfixed.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xdisfixed.Text.Trim().ToString())
                            //    : 0;
                            //xdisperc1 = xdisperc.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xdisperc.Text.Trim().ToString())
                            //    : 0;
                            //xvatfixed1 = xvatfixed.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xvatfixed.Text.Trim().ToString())
                            //    : 0;
                            //xvatperc1 = xvatperc.Text.Trim().ToString() != string.Empty
                            //    ? decimal.Parse(xvatperc.Text.Trim().ToString())
                            //    : 0;
                            //xsign1 = xsign.Text.Trim().ToString() != string.Empty
                            //    ? int.Parse(xsign.Text.ToString().Trim())
                            //    : 1;

                            //xeffdate1 = xeffdate.Text.ToString().Trim() != string.Empty
                            //    ? DateTime.ParseExact(xeffdate.Text.ToString().Trim(), "dd/MM/yyyy",
                            //        CultureInfo.InvariantCulture)
                            //    : DateTime.Now;

                            //zactive1 = zactive.Checked ? 1 : 0;

                            //xremarks1 = xremarks.Value.Trim().ToString();
                            ////xtype12 = xtype1.Text.Trim().ToString();
                            //xtype12 = zglobal.fnProperty("TFC Code", xtfccode1, "xtype");

                            //query = "UPDATE amtfcconfig SET zutime=@zutime,xemail=@xemail,xtfccode=@xtfccode,xclass=@xclass,xgroup=@xgroup,xsection=@xsection, " +
                            //        "xstdid=@xstdid,xamount=@xamount,xdisfixed=@xdisfixed,xdisperc=@xdisperc, xvatfixed=@xvatfixed, xvatperc=@xvatperc,xsign=@xsign " +
                            //        "xeffdate=@xeffdate, zactive=@zactive, xremarks=@xremarks " +
                            //        "WHERE zid=@zid AND xrow=@xrow ";

                            xmodule1 = ViewState["xmodule"].ToString();
                            xtrnim1 = xtrnim.Text.Trim().ToString();
                            xaction1 = xaction.Text.Trim().ToString();
                            xglevel11 = xglevel1.Text.Trim().ToString();
                            xaccdr1 = xaccdr.Text.Trim().ToString();
                            xsubdr1 = xsubdr.Text.Trim().ToString();
                            xacccr1 = xacccr.Text.Trim().ToString();
                            xsubcr1 = xsubcr.Text.Trim().ToString();
                            xwh1 = xwh.Text.Trim().ToString();
                            xprefix1 = xprefix.Text.Trim().ToString();

                            query = "UPDATE glinterface SET zutime=@zutime,xemail=@xemail, " +
                                   "xmodule=@xmodule,xtrnim=@xtrnim,xaction=@xaction,xglevel1=@xglevel1, xaccdr=@xaccdr, xsubdr=@xsubdr,xacccr=@xacccr, " +
                                   "xsubcr=@xsubcr, xwh=@xwh, xprefix=@xprefix " +
                                   "WHERE zid=@zid AND xrow=@xrow ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@xemail",
                                Convert.ToString(HttpContext.Current.Session["curuser"]));
                            cmd.Parameters.AddWithValue("@xmodule", xmodule1);
                            cmd.Parameters.AddWithValue("@xtrnim", xtrnim1);
                            cmd.Parameters.AddWithValue("@xaction", xaction1);
                            cmd.Parameters.AddWithValue("@xglevel1", xglevel11);
                            cmd.Parameters.AddWithValue("@xaccdr", xaccdr1);
                            cmd.Parameters.AddWithValue("@xsubdr", xsubdr1);
                            cmd.Parameters.AddWithValue("@xacccr", xacccr1);
                            cmd.Parameters.AddWithValue("@xsubcr", xsubcr1);
                            cmd.Parameters.AddWithValue("@xwh", xwh1);
                            cmd.Parameters.AddWithValue("@xprefix", xprefix1);
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

                fnButtonState();
                fnFillGrid2();
                xrow1.Text = ViewState["xrow"].ToString();

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
                    //string query =
                    //     "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow," +
                    //     "coalesce((select xcode + '-' + xdescdet from mscodesam where mscodesam.zid=glinterface.zid and mscodesam.xcode=glinterface.xkey and mscodesam.xtype='TFC Code'),'') as xkey," +
                    //     "xtype,xbank,xprefix," +
                    //     "(select xacc + '-' + xdesc from glmst where zid=glinterface.zid and xacc=xaccdr) as xaccdr, " +
                    //     "coalesce((select xsub + '-' + xdescsub from glmstvw where zid=glinterface.zid and xacc=glinterface.xaccdr and xsub=glinterface.xsubdr and xaccsource<>'None'),'') as xsubdr," +
                    //     "(select xacc + '-' + xdesc from glmst where zid=glinterface.zid and xacc=xacccr) as xacccr, " +
                    //     "coalesce((select xsub + '-' + xdescsub from glmstvw where zid=glinterface.zid and xacc=glinterface.xacccr and xsub=glinterface.xsubcr and xaccsource<>'None'),'') as xsubcr  " +
                    //     "FROM glinterface WHERE zid=@zid  AND xmodule=@xmodule  order by xkey ";

                  
                    string query =
                      "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow," +
                      "xtrnim,xaction,xglevel1," +
                      "xtype,xbank,xprefix,xwh," +
                      "(select xacc + '-' + xdesc from glmst where zid=glinterface.zid and xacc=xaccdr) as xaccdr, " +
                      "coalesce((select xsub + '-' + xdescsub from glmstvw where zid=glinterface.zid and xacc=glinterface.xaccdr and xsub=glinterface.xsubdr and xaccsource<>'None'),'') as xsubdr," +
                      "(select xacc + '-' + xdesc from glmst where zid=glinterface.zid and xacc=xacccr) as xacccr, " +
                      "coalesce((select xsub + '-' + xdescsub from glmstvw where zid=glinterface.zid and xacc=glinterface.xacccr and xsub=glinterface.xsubcr and xaccsource<>'None'),'') as xsubcr  " +
                      "FROM glinterface WHERE zid=@zid  AND xmodule=@xmodule  order by xkey ";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xmodule", ViewState["xmodule"].ToString());



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvTFCListNew.DataSource = tempTable;
                        dgvTFCListNew.DataBind();
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


            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        con.Open();
            //        string query =
            //              "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xrow,xtfccode,xclass,xgroup,xsection,xeffdate,xstdid, " +
            //             " (select xdescdet from mscodesam where zid=amtfcspecialdisconf.zid and xcode=amtfcspecialdisconf.xtfccode and xtype='TFC Code') as xtfccodetitle, " +
            //             "(select xname from amadmis where zid=amtfcspecialdisconf.zid and xstdid=amtfcspecialdisconf.xstdid) as xname, xamount,zactive, " +
            //             "xdisperc,xdisfixed " +
            //             "FROM amtfcspecialdisconf WHERE zid=@zid  AND xstatus='Submited' and coalesce(xstdid,'')=''  order by xtfccode,xeffdate desc";

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


                message.InnerHtml = "";

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = Convert.ToInt32(((LinkButton)sender).Text);

                xrow1.Text = xrow.ToString();

                string str = "SELECT  * FROM glinterface where zid=@zid  and xrow=@xrow ";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.Fill(dts, "tempztcode");
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                ViewState["xrow"] = xrow.ToString();
                hiddenxrow.Value = ViewState["xrow"].ToString();

                //xtfccode.Text = dttemp.Rows[0]["xtfccode"].ToString();
                //if (dttemp.Rows[0]["xeffdate"].Equals(DBNull.Value) == false)
                //{
                //    if (Convert.ToDateTime(dttemp.Rows[0]["xeffdate"]).ToString("dd/MM/yyyy") != "01/01/1999" &&
                //        Convert.ToDateTime(dttemp.Rows[0]["xeffdate"]).ToString("dd/MM/yyyy") != "31/12/2999")
                //    {
                //        xeffdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xeffdate"]).ToString("dd/MM/yyyy");
                //    }
                //}
                //xclass.Text = dttemp.Rows[0]["xclass"].ToString();
                //xgroup.Text = dttemp.Rows[0]["xgroup"].ToString();
                //xsection.Text = dttemp.Rows[0]["xsection"].ToString();
                //xstdid.Text = dttemp.Rows[0]["xstdid"].ToString();
                //xamount.Text = dttemp.Rows[0]["xamount"].ToString();
                //xsign.Text = dttemp.Rows[0]["xsign"].ToString();
                //xdisfixed.Text = dttemp.Rows[0]["xdisfixed"].ToString();
                //xdisperc.Text = dttemp.Rows[0]["xdisperc"].ToString();
                //xvatfixed.Text = dttemp.Rows[0]["xvatfixed"].ToString();
                //xvatperc.Text = dttemp.Rows[0]["xvatperc"].ToString();
                //xremarks.Value = dttemp.Rows[0]["xremarks"].ToString();
                //xtype1.Text = dttemp.Rows[0]["xtype1"].ToString();
                //if (dttemp.Rows[0]["zactive"].ToString() == "1")
                //{
                //    zactive.Checked = true;
                //}
                //else
                //{
                //    zactive.Checked = false;
                //}

                xtrnim.Text = dttemp.Rows[0]["xtrnim"].ToString();
                xaction.Text = dttemp.Rows[0]["xaction"].ToString();
                xglevel1.Text = dttemp.Rows[0]["xglevel1"].ToString();
                xwh.Text = dttemp.Rows[0]["xwh"].ToString();
                xprefix.Text = dttemp.Rows[0]["xprefix"].ToString();
                xaccdr.Text = dttemp.Rows[0]["xaccdr"].ToString();
                xsubdr.Text = dttemp.Rows[0]["xsubdr"].ToString();
                xacccr.Text = dttemp.Rows[0]["xacccr"].ToString();
                xsubcr.Text = dttemp.Rows[0]["xsubcr"].ToString();




                fnButtonState();
                //BindGrid();

                //xtfccodetitle.Text = zglobal.fnGetValue("xdescdet", "mscodesam",
                //   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xcode='" +
                //   xkey.Text.ToString().Trim() + "'" + "and xtype='TFC Code' and zactive=1");

                xdescdr.Text = zglobal.fnGetValue("xdesc", "glmst",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xaccdr.Text.ToString() + "'");

                xdescsubdr.Text = zglobal.fnGetValue("xdescsub", "glmstvw",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xaccdr.Text.ToString() + "' " +
                  "and xsub='" + xsubdr.Text.Trim().ToString() + "'");

                xdesccr.Text = zglobal.fnGetValue("xdesc", "glmst",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacccr.Text.ToString() + "'");

                xdescsubcr.Text = zglobal.fnGetValue("xdescsub", "glmstvw",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xacccr.Text.ToString() + "' " +
                  "and xsub='" + xsubcr.Text.Trim().ToString() + "'");

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //    xstdid.Text.ToString().Trim() + "'");



                //str = "SELECT  * FROM amtfcconfigt where zid=@zid  and xrow=@xrow ";


                //if (ViewState["xrow"] != null)
                //{

                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amtfcconfigvw",
                //           "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    if (xstatus1 != "")
                //    {
                //        ViewState["xstatus"] = xstatus1;
                //        hxstatus.Value = xstatus1;
                //    }
                //    else
                //    {
                //        hxstatus.Value = "";
                //        ViewState["xstatus"] = "";
                //    }
                //}
                //else
                //{
                //    hxstatus.Value = "";
                //    ViewState["xstatus"] = "";
                //}



                //dts.Reset();
                //SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                //da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //da1.Fill(dts, "tempztcode");
                //DataTable dttemp1 = new DataTable();
                //dttemp1 = dts.Tables[0];

                //if (dttemp1.Rows.Count > 0)
                //{

                //    //CheckBox chkCheckBox1 = GridView1.HeaderRow.FindControl("chkall") as CheckBox;

                //    //if (ViewState["xrow"] != null)
                //    //{
                //    //    if (Convert.ToString(ViewState["xstatus"]) != "New" &&
                //    //         Convert.ToString(ViewState["xstatus"]) != "Undo" &&
                //    //         Convert.ToString(ViewState["xstatus"]) != "Undo1")
                //    //    {
                //    //        chkCheckBox1.Enabled = false;
                //    //    }
                //    //    else
                //    //    {
                //    //        chkCheckBox1.Enabled = true;
                //    //    }
                //    //}

                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //        TextBox txtTextBox1 = row.FindControl("xamount") as TextBox;
                //        CheckBox chkCheckBox = row.FindControl("selbiz") as CheckBox;
                //        chkCheckBox.Checked = false;
                //        txtTextBox1.Text ="";

                //        //if (ViewState["xrow"] != null)
                //        //{
                //        //    if (Convert.ToString(ViewState["xstatus"]) != "New" &&
                //        //         Convert.ToString(ViewState["xstatus"]) != "Undo" &&
                //        //         Convert.ToString(ViewState["xstatus"]) != "Undo1")
                //        //    {
                //        //        txtTextBox1.Enabled = false;
                //        //        chkCheckBox.Enabled = false;
                //        //    }
                //        //    else
                //        //    {
                //        //        txtTextBox1.Enabled = true;
                //        //        chkCheckBox.Enabled = true;
                //        //    }
                //        //}
                //    }

                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //        foreach (DataRow row1 in dttemp1.Rows)
                //        {

                //            if (row.Cells[1].Text.ToString() == row1["xtype"].ToString())
                //            {
                //                TextBox txtTextBox1 = row.FindControl("xamount") as TextBox;
                //                CheckBox chkCheckBox = row.FindControl("selbiz") as CheckBox;
                //                chkCheckBox.Checked = true;
                //                txtTextBox1.Text = row1["xamount"].ToString();
                //            }

                //        }
                //    }
                //}

                da.Dispose();
                //da1.Dispose();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
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
            //            btnSave_Click(sender,e);
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
            //                        "UPDATE amtfcspecialdisconf SET xstatus=@xstatus,xsubmitedby=@xsubmitedby,xsubmitdt=@xsubmitdt " +
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
            //                        "UPDATE amtfcspecialdisconf SET zactive=1 WHERE zid=@zid AND xrow=@xrow ";
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
            //                    "UPDATE amtfcspecialdisconf SET zactive=0 WHERE zid=@zid AND xrow=@xrow ";
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


                                string query = "DELETE FROM glinterface WHERE zid=@zid AND xrow=@xrow";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.ExecuteNonQuery();

                                //query = "DELETE FROM amtfcconfig WHERE zid=@zid AND xrow=@xrow";
                                //cmd.CommandText = query;
                                //cmd.ExecuteNonQuery();
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
            //        xdate.Text = "";
            //        xnsdate.Value = "";
            //        //xdate.Enabled = false;
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
            //        xdate.Text = "";
            //        xnsdate.Value = "";
            //        // xdate.Enabled = true;
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
            //    ViewState["xdate1"] = null;
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

            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
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
            //    message.InnerHtml = "";
            ////    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ////    //ViewState["dtprectmarks"] = null;



            ////    fnCheckRow();


            ////    if (ViewState["xrow"] != null)
            ////    {
            ////        string xmarks1 = zglobal.fnGetValue("xmarks", "amexamh",
            ////            "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            ////        xmarks.Text = xmarks1;
            ////    }
            ////    else
            ////    {


            ////        if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test" && xcttype.Text != "Missed Test")
            ////        {
            ////            xmarks.Text = "";
            ////        }
            ////    }

            ////    if (ViewState["xrow"] == null && xcttype.Text == "Test")
            ////    {
            ////        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            ////        {
            ////            using (DataSet dts = new DataSet())
            ////            {

            ////                string xsession1 = xsession.Text.Trim().ToString();
            ////                string xterm1 = xterm.Text.Trim().ToString();
            ////                string xclass1 = xclass.Text.Trim().ToString();
            ////                string xgroup1 = xgroup.Text.Trim().ToString();
            ////                string xsection1 = xsection.Text.Trim().ToString();
            ////                string xsubject1 = xsubject.Text.Trim().ToString();
            ////                string xpaper1 = xpaper.Text.Trim().ToString();
            ////                string xext1 = xext.Text.Trim().ToString();
            ////                DateTime xdate1 = xdate.Text.Trim() != string.Empty
            ////                    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            ////                        CultureInfo.InvariantCulture)
            ////                    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            ////                //string query = "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher,xretestfor " +
            ////                //               "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            ////                //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' AND xdate=@xdate";
            ////                string query =
            ////                    "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher " +
            ////                    "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            ////                    "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xtype='Class Test'  AND xdate=@xdate";

            ////                SqlDataAdapter da = new SqlDataAdapter(query, conn);
            ////                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xext", xext1);
            ////                da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            ////                da.Fill(dts, "tempztcode");
            ////                DataTable dtexam = new DataTable();
            ////                dtexam = dts.Tables[0];


            ////                if (dtexam.Rows.Count > 0)
            ////                {
            ////                    xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
            ////                    xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
            ////                    xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
            ////                    xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
            ////                    _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
            ////                    _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();


            ////                }
            ////                else
            ////                {
            ////                    if (ViewState["xdate1"] == null)
            ////                    {
            ////                        xtopic.Value = "";
            ////                        xdetails.Value = "";
            ////                        //xsteacher.Text = "-";
            ////                        //xcteacher.Text = "-";
            ////                        xsteacher.Text = "";
            ////                        xcteacher.Text = "";
            ////                        dxstatus.Text = "-";
            ////                        _classteacher.Value = "";
            ////                        _subteacher.Value = "";
            ////                    }

            ////                }



            ////            }
            ////        }
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
            ////                    xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
            ////                    xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
            ////                    xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
            ////                    xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
            ////                    _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
            ////                    _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();
            ////                    xdate.Text = Convert.ToDateTime(dtexam.Rows[0]["xdate"]).ToString("dd/MM/yyyy");


            ////                    //if (xreference.Items.Contains(new ListItem(dtexam.Rows[0]["xretestfor"].ToString())))
            ////                    //{
            ////                    //    xreference.Text = dtexam.Rows[0]["xretestfor"].ToString();
            ////                    //}

            ////                    string xref = dtexam.Rows[0]["xrefcttype"].ToString() + "|" +
            ////                                  dtexam.Rows[0]["xrefctno"].ToString();

            ////                    if (dtexam.Rows[0]["xrefcttype"].ToString() != "" &&
            ////                        dtexam.Rows[0]["xrefcttype"].ToString() != "")
            ////                    {
            ////                        xreference.SelectedValue = xref;
            ////                    }
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
            ////                    if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test" && xcttype.Text != "Missed Test")
            ////                    {
            ////                        xtopic.Value = "";
            ////                        xdetails.Value = "";
            ////                        //xsteacher.Text = "-";
            ////                        //xcteacher.Text = "-";
            ////                        xsteacher.Text = "";
            ////                        xcteacher.Text = "";
            ////                        dxstatus.Text = "-";
            ////                        _classteacher.Value = "";
            ////                        _subteacher.Value = "";
            ////                    }
                                
            ////                    //xdetails.Value = "";
            ////                    ////xsteacher.Text = "-";
            ////                    ////xcteacher.Text = "-";
            ////                    //xsteacher.Text = "";
            ////                    //xcteacher.Text = "";
            ////                    //dxstatus.Text = "-";
            ////                    //_classteacher.Value = "";
            ////                    //_subteacher.Value = "";
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
            //    xtype1.Text = "";

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
            //                    "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xtype='Class Test' ORDER BY xdate ";

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


    }
}