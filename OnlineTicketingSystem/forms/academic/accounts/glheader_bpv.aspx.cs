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
using System.Web.Services.Discovery;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class glheader_bpv : System.Web.UI.Page
    {

        private int globalerr;
        private void fnButtonState()
        {
            if (ViewState["xvoucher"] == null)
            {
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                //btnPrint.Enabled = false;
                //btnPrint1.Enabled = false;
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
                hiddenxvoucher.Value = "";
                xstatusjv.InnerHtml = "";
                zemail.InnerHtml = "";
                xemail.InnerHtml = "";
                xemailc.InnerHtml = "";
            }
            else
            {
                //xsession.Enabled = false;
                //xstdid.Enabled = false;
                hiddenxvoucher.Value = Convert.ToString(ViewState["xvoucher"]);

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xstatus1 = zglobal.fnGetValue("xpostflag", "glheader",
                               "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");

                hxstatus.Value = xstatus1;

                string xstatus2 = zglobal.fnGetValue("xstatusjv", "glheader",
                              "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");

                xstatusjv.InnerHtml = xstatus2 + " <sub>" + xstatus1 + "</sub>";
                //xstatus.InnerHtml = xstatus1;
                zemail.InnerHtml = zglobal.fnGetValue("coalesce(zemail,'') as zemail", "glheader",
                               "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");

                xemail.InnerHtml = zglobal.fnGetValue("coalesce(xemail,'') as xemail", "glheader",
                               "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");

                xemailc.InnerHtml = zglobal.fnGetValue("coalesce(xemailc,'') as xemailc", "glheader",
                               "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");

                //xapprovedby.InnerHtml = zglobal.fnGetValue("coalesce(xapprovedby,'') as xapprovedby", "amdropout",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xvoucher"]));

                //xsessionpro.Text = zglobal.fnGetValue("xsessionpro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xvoucher"]));

                //xclasspro.Text = zglobal.fnGetValue("xclasspro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xvoucher"]));

                //xgrouppro.Text = zglobal.fnGetValue("xgrouppro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xvoucher"]));
                //dxstatus.Visible = true;

                if (xstatus1 == "New" || xstatus1 == "Undo" || xstatus1 == "Open" || xstatus1=="")
                {
                    btnSubmit.Enabled = true;
                    btnSubmit1.Enabled = true;
                    btnConfirm.Enabled = true;
                    btnConfirm1.Enabled = true;
                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDelete1.Enabled = true;
                    btnUndo.Enabled = false;
                    btnUndo1.Enabled = false;
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
                    btnUndo.Enabled = true;
                    btnUndo1.Enabled = true;
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

            //LoopButton(Page.Controls);
        }

        //private void LoopButton(ControlCollection controlCollection)
        //{
        //    foreach (Control control in controlCollection)
        //    {
        //        if (control is Button)
        //        {
        //            if (((Button)control).Text == "Post")
        //                ((Button)control).Visible = false;
        //        }

        //        if (control.Controls != null)
        //        {
        //            LoopButton(control.Controls);
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    ViewState["xvoucher"] = null;
                    hiddenxvoucher.Value = "";
                    ViewState["xstatus"] = null;
                   
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    hxstatus.Value = "";
                   

                   

                    ViewState["xtrngl"] = "BPV-";
                    xtrngl.Text = ViewState["xtrngl"].ToString();

                    ViewState["xtypetrn"] = "GL Voucher";

                    ViewState["xaction"] = zglobal.fnGetValue("xaction", "mstrn",
                    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtypetrn='" + ViewState["xtypetrn"].ToString() + "' " +
                    "and xtrn='" + ViewState["xtrngl"].ToString() + "'");

                    fnButtonState();

                    //ViewState["xrel"] = zglobal.fnGetValue("xrel", "mstrnp",
                    //  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xtypetrn='" + ViewState["xtypetrn"].ToString() + "' " +
                    //  "and xtrn='" + ViewState["xtrngl"].ToString() + "' and xtyperel='" + ViewState["xtyperel"].ToString() + "'");

                    _gridrow.Text = zglobal._grid_row_value;
                    _gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();
                    SetInitialRow();
                    ViewState["xtype"] = "Headwise";

                    xstatusjv.InnerHtml = "";
                    zemail.InnerHtml = "";
                    xemail.InnerHtml = "";
                    xemailc.InnerHtml = "";
                 
                    xdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    zglobal.fnGLYearCombo(xyear);
                    zglobal.fnGLPerCombo(xper);

                    xpaytypecr.Items.Clear();
                    xpaytypecr.Items.Add("Cheque");
                    xpaytypecr.Items.Add("DD");
                    xpaytypecr.Items.Add("TT");
                    xpaytypecr.Items.Add("Online");
                    xpaytypecr.Items.Add("Pay Order");
                    xpaytypecr.Items.Add("Transfer");
                    xpaytypecr.Text = "Cheque";

                    string xvoucher1 = Request.QueryString["xvoucher"] != null ? Request.QueryString["xvoucher"].ToString() : "";

                    if (xvoucher1 != "")
                    {
                        MasterPage m = this.Page.Master;
                        zglobal.fnDisableMasterPageContent(m);
                        fnFillControl(xvoucher1);
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

                        xacccr.Text = zglobal.fnGetValue("xsubbpv", "msdef",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));

                        hxacc.Value = zglobal.fnGetValue("xaccbpv", "msdef",
                            "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));

                        hxsub.Value = zglobal.fnGetValue("xsubbpv", "msdef",
                            "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
                    }

                    

                }


             

                xdesccr.Text = zglobal.fnGetValue("xdesc1", "glmstvw1",
                     "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + hxacc.Value.ToString() + "' " +
                     "and xsub='" + hxsub.Value.ToString() + "'");

                fnRegisterPostBack();
                fnCalculateTotal();

                

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnRegisterPostBack()
        {
            foreach (GridViewRow row in dgvunposted.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xvoucher") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            foreach (GridViewRow row in dgvposted.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xvoucher") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }
        }

        private decimal xamountdr1 = 0;
        private decimal xamountcr1 = 0;

        private void fnCalculateTotal()
        {

            xamountdr1 = 0;
            xamountcr1 = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox xamountdr = (TextBox)row.FindControl("xamountdr");
                TextBox xamountcr = (TextBox)row.FindControl("xamountcr");

                string xamountdr12;
                string xamountcr12;

                if (xamountdr.Text.Trim().ToString() == "" || xamountdr.Text.Trim().ToString() == String.Empty)
                {
                    //xamountdr.Text = "0.00";
                    xamountdr12 = "0";
                }
                else
                {
                    xamountdr12 = xamountdr.Text.Trim().ToString();
                }

                if (xamountcr.Text.Trim().ToString() == "" || xamountcr.Text.Trim().ToString() == String.Empty)
                {
                    //xamountcr.Text = "0.00";
                    xamountcr12 = "0";
                }
                else
                {
                    xamountcr12 = xamountcr.Text.Trim().ToString();
                }

                //if (row.Cells[6].Text.ToString() == "" || row.Cells[6].Text.ToString() == String.Empty)
                //{
                //    row.Cells[6].Text = "0";
                //}


                //xamountdr1 += decimal.Parse(xamountdr.Text.Trim().ToString());
                //xamountcr1 += decimal.Parse(xamountcr.Text.Trim().ToString());

                xamountdr1 += decimal.Parse(xamountdr12);
                xamountcr1 += decimal.Parse(xamountcr12);

            }

            decimal xprimecr1 = xamountdr1 - xamountcr1;
            xprimecr.Text = Convert.ToString(xprimecr1);

            GridView1.FooterRow.Cells[6].Text = xamountdr1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            GridView1.FooterRow.Cells[6].Font.Bold = true;
            GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[6].ForeColor = Color.White;

            GridView1.FooterRow.Cells[7].Text = (xamountcr1 + xprimecr1).ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
            GridView1.FooterRow.Cells[7].Font.Bold = true;
            GridView1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[7].ForeColor = Color.White;

        }

        //private void fnCalculateTotal()
        //{

        //    xamountdr1 = 0;
        //    xamountcr1 = 0;


        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        TextBox xamountdr = (TextBox)row.FindControl("xamountdr");
        //        TextBox xamountcr = (TextBox)row.FindControl("xamountcr");

        //        string xamountdr12;
        //        string xamountcr12;

        //        if (xamountdr.Text.Trim().ToString() == "" || xamountdr.Text.Trim().ToString() == String.Empty)
        //        {
        //            //xamountdr.Text = "0.00";
        //            xamountdr12 = "0";
        //        }
        //        else
        //        {
        //            xamountdr12 = xamountdr.Text.Trim().ToString();
        //        }

        //        if (xamountcr.Text.Trim().ToString() == "" || xamountcr.Text.Trim().ToString() == String.Empty)
        //        {
        //            //xamountcr.Text = "0.00";
        //            xamountcr12 = "0";
        //        }
        //        else
        //        {
        //            xamountcr12 = xamountcr.Text.Trim().ToString();
        //        }

        //        //if (row.Cells[6].Text.ToString() == "" || row.Cells[6].Text.ToString() == String.Empty)
        //        //{
        //        //    row.Cells[6].Text = "0";
        //        //}


        //        //xamountdr1 += decimal.Parse(xamountdr.Text.Trim().ToString());
        //        //xamountcr1 += decimal.Parse(xamountcr.Text.Trim().ToString());

        //        xamountdr1 += decimal.Parse(xamountdr12);
        //        xamountcr1 += decimal.Parse(xamountcr12);

        //    }

        //    GridView1.FooterRow.Cells[6].Text = xamountdr1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
        //    GridView1.FooterRow.Cells[6].Font.Bold = true;
        //    GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        //    GridView1.FooterRow.Cells[6].ForeColor = Color.White;

        //    GridView1.FooterRow.Cells[7].Text = xamountcr1.ToString(zglobal.CurrecnyFormatSpecifier, zglobal.GetCultureInfo());
        //    GridView1.FooterRow.Cells[7].Font.Bold = true;
        //    GridView1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
        //    GridView1.FooterRow.Cells[7].ForeColor = Color.White;
        //}


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




            //         if (ViewState["xvoucher"] != null)
            //         {
            //             using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //             {
            //                 using (DataSet dts1 = new DataSet())
            //                 {
            //                     string query = "SELECT xsrow,coalesce(xpromoted,0) as xpromoted FROM ampromotiond WHERE zid=@zid AND xrow=@xrow";
            //                     SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
            //                     da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
            //                     da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xvoucher"]));
            //                     da1.Fill(dts1, "tblamadmisd");
            //                     //tblamadmisd = new DataTable();
            //                     amexamd = dts1.Tables[0];
            //                 }
            //             }

            //             ViewState["ampromotiond"] = amexamd;
            //             string xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
            //                    "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xvoucher"]));
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

            //            //if (ViewState["xvoucher"] != null)
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

        private void fnFillPayType(DropDownList dpl)
        {
            dpl.Items.Clear();
            dpl.Items.Add("None");
            dpl.Items.Add("Cheque");
            dpl.Items.Add("Cash");
            dpl.Items.Add("DD");
            dpl.Items.Add("TT");
            dpl.Items.Add("Online");
            dpl.Items.Add("Pay Order");
            dpl.Items.Add("Transfer");
            dpl.Text = "None";
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
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = string.Empty;
                dr["Column5"] = string.Empty;
                dr["Column6"] = "0.00";
                dr["Column7"] = "0.00";
                dr["Column8"] = string.Empty;
                dr["Column9"] = string.Empty;
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
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                DropDownList ddl1 = (DropDownList)GridView1.Rows[i].Cells[3].FindControl("xpaytype");
                fnFillPayType(ddl1);
            }
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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xsub");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xdesc");
                        DropDownList box3 = (DropDownList)GridView1.Rows[i].Cells[3].FindControl("xpaytype");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xcheque");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xdateclr");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("xamountdr");
                        TextBox box7 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("xamountcr");
                        TextBox box8 = (TextBox)GridView1.Rows[i].Cells[8].FindControl("xrem");
                        TextBox box9 = (TextBox)GridView1.Rows[i].Cells[9].FindControl("xacc");

                        dtCurrentTable.Rows[i]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i]["Column3"] = box3.Text;
                        dtCurrentTable.Rows[i]["Column4"] = box4.Text;
                        dtCurrentTable.Rows[i]["Column5"] = box5.Text;
                        dtCurrentTable.Rows[i]["Column6"] = box6.Text;
                        dtCurrentTable.Rows[i]["Column7"] = box7.Text;
                        dtCurrentTable.Rows[i]["Column8"] = box8.Text;
                        dtCurrentTable.Rows[i]["Column9"] = box9.Text;

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
            fnCalculateTotal();
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
                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xsub");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xdesc");
                        DropDownList box3 = (DropDownList)GridView1.Rows[i].Cells[3].FindControl("xpaytype");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xcheque");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xdateclr");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("xamountdr");
                        TextBox box7 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("xamountcr");
                        TextBox box8 = (TextBox)GridView1.Rows[i].Cells[8].FindControl("xrem");
                        TextBox box9 = (TextBox)GridView1.Rows[i].Cells[9].FindControl("xacc");


                        //DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                        //DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("DropDownList2");

                        ////Fill the DropDownList with Data   
                        //FillDropDownList(ddl1);
                        //FillDropDownList(ddl2);


                        fnFillPayType(box3);

                        //if (i < dt.Rows.Count - 1)
                        //{

                        //Assign the value from DataTable to the TextBox   
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        box5.Text = dt.Rows[i]["Column5"].ToString();
                        box6.Text = dt.Rows[i]["Column6"].ToString();
                        box7.Text = dt.Rows[i]["Column7"].ToString();
                        box8.Text = dt.Rows[i]["Column8"].ToString();
                        box9.Text = dt.Rows[i]["Column9"].ToString();

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

                        TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("xsub");
                        TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("xdesc");
                        DropDownList box3 = (DropDownList)GridView1.Rows[i].Cells[3].FindControl("xpaytype");
                        TextBox box4 = (TextBox)GridView1.Rows[i].Cells[4].FindControl("xcheque");
                        TextBox box5 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("xdateclr");
                        TextBox box6 = (TextBox)GridView1.Rows[i].Cells[6].FindControl("xamountdr");
                        TextBox box7 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("xamountcr");
                        TextBox box8 = (TextBox)GridView1.Rows[i].Cells[8].FindControl("xrem");
                        TextBox box9 = (TextBox)GridView1.Rows[i].Cells[9].FindControl("xacc");

                        dt.Rows[i]["Column1"] = box1.Text;
                        dt.Rows[i]["Column2"] = box2.Text;
                        dt.Rows[i]["Column3"] = box3.Text;
                        dt.Rows[i]["Column4"] = box4.Text;
                        dt.Rows[i]["Column5"] = box5.Text;
                        dt.Rows[i]["Column6"] = box6.Text;
                        dt.Rows[i]["Column7"] = box7.Text;
                        dt.Rows[i]["Column8"] = box8.Text;
                        dt.Rows[i]["Column9"] = box9.Text;

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //btnRefresh_Click(sender,e);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xvoucher_1 = "";
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                if (xdate.Text == "" || xdate.Text == string.Empty || xdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Date</li>";
                    isValid = false;
                }
                if (xacccr.Text == "" || xacccr.Text == string.Empty || xacccr.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Bank Account</li>";
                    isValid = false;
                }
                //if (xprimecr.Text == "" || xprimecr.Text == string.Empty || xprimecr.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Amount</li>";
                //    isValid = false;
                //}
                if (xchequecr.Text == "" || xchequecr.Text == string.Empty || xchequecr.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Cheque/Ref No</li>";
                    isValid = false;
                }
                if (xdateclrcr.Text == "" || xdateclrcr.Text == string.Empty || xdateclrcr.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Cheque Date</li>";
                    isValid = false;
                }
                if (xnote.Text == "" || xnote.Text == string.Empty || xnote.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Narration</li>";
                    isValid = false;
                }

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }


                //fnCheckRow();
                string xstatus2 = "";
                if (ViewState["xvoucher"] != null)
                {
                    xstatus2 = zglobal.fnGetValue("coalesce(xpostflag,'') as xpostflag", "glheader",
                          "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");
                    if (xstatus2 != "New" && xstatus2 != "Undo" && xstatus2 != "Undo1" && xstatus2 != "" && xstatus2 != "Open" && xstatus2 != "1-Open" && xstatus2 != "" && xstatus2 != String.Empty)
                    {
                        message.InnerHtml = "Status : " + xstatus2 + ". Cann't Change Record.";
                        message.Style.Value = zglobal.warningmsg;
                        globalerr = 1;
                        return;
                    }
                }

                int flag = 0;
                
                //No Accounts selected
                flag = 0;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtTextBox1 = row.FindControl("xsub") as TextBox;
                    TextBox txtTextBoxAcc = row.FindControl("xacc") as TextBox;
                    if (txtTextBox1.Text != String.Empty)
                    {
                        if (txtTextBoxAcc.Text == String.Empty)
                        {
                            row.BackColor = zglobal.rowerr;
                            flag = 1;
                        }
                    }

                }

                if (flag == 1)
                {
                    message.InnerText = "No Account Selected";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                //Duplicate accounts check
                flag = 0;
                List<String> val = new List<String>();
                val.Add("");
                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtTextBox1 = row.FindControl("xsub") as TextBox;
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
                    message.InnerText = "Duplicate Accounts Selected.";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                //Sub Accounts Check
                flag = 0;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtTextBox1 = row.FindControl("xsub") as TextBox;
                    TextBox txtTextBoxAcc = row.FindControl("xacc") as TextBox;

                    if (txtTextBox1.Text != String.Empty)
                    {
                        if (zglobal.fnGetValue("xsub", "glmstvw",
                      "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + "  and xsub='" + txtTextBox1.Text.ToString().Trim() + "' and xacc='" + txtTextBoxAcc.Text.ToString().Trim() + "'") == "")
                        {
                            //txtTextBox1.Text = "";
                            row.BackColor = zglobal.rowerr;
                            flag = 1;
                        }
                    }

                }

                if (flag == 1)
                {
                    message.InnerText = "Account Not Found";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                if (xacccr.Text.Trim().ToString() != hxsub.Value.ToString().Trim())
                {
                    message.InnerText = "Record Pointer Mismatch";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                if (xacccr.Text.Trim().ToString() != String.Empty)
                {
                    if (zglobal.fnGetValue("xsub", "glmstvw",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + "  and xsub='" + hxsub.Value.ToString().Trim() + "' and xacc='" + hxacc.Value.ToString().Trim() + "'") == "")
                    {
                        message.InnerText = "Invalid Cash Account";
                        message.Style.Value = zglobal.warningmsg;
                        globalerr = 1;
                        return;
                    }
                }

                //Dr. Cr. Both field fill Check
                flag = 0;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtTextBox1 = row.FindControl("xsub") as TextBox;
                    TextBox txtTextBoxDr = row.FindControl("xamountdr") as TextBox;
                    TextBox txtTextBoxCr = row.FindControl("xamountcr") as TextBox;

                    if (txtTextBox1.Text != String.Empty)
                    {
                        if (txtTextBoxDr.Text.ToString().Trim() != "" && txtTextBoxCr.Text.ToString().Trim() != "")
                        {
                            //if (txtTextBoxDr.Text.ToString().Trim() != 0 )
                            //txtTextBox1.Text = "";
                            row.BackColor = zglobal.rowerr;
                            flag = 1;
                        }
                    }

                }

                if (flag == 1)
                {
                    message.InnerText = "Not Allowed Entry Both Debit and Credit Amount in the Same Row";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                //Dr. Cr. Balance Check
                flag = 0;

                decimal dramt = 0;
                decimal cramt = 0;

                if (xprimecr.Text.Trim().ToString() != String.Empty)
                {
                    cramt = Convert.ToDecimal(xprimecr.Text.Trim().ToString());
                }

                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox txtTextBox1 = row.FindControl("xsub") as TextBox;
                    TextBox txtTextBoxDr = row.FindControl("xamountdr") as TextBox;
                    TextBox txtTextBoxCr = row.FindControl("xamountcr") as TextBox;

                    decimal dr;
                    decimal cr;

                    if (txtTextBox1.Text != String.Empty)
                    {
                        if (txtTextBoxDr.Text.ToString().Trim() == "")
                        {
                            dr = 0;
                        }
                        else
                        {
                            dr = Convert.ToDecimal(txtTextBoxDr.Text.ToString().Trim());
                        }

                        dramt += dr;

                        if (txtTextBoxCr.Text.ToString().Trim() == "")
                        {
                            cr = 0;
                        }
                        else
                        {
                            cr = Convert.ToDecimal(txtTextBoxCr.Text.ToString().Trim());
                        }

                        cramt += cr;

                    }

                }

                if (dramt != cramt)
                {
                    //if (txtTextBoxDr.Text.ToString().Trim() != 0 )
                    //txtTextBox1.Text = "";
                    //row.BackColor = zglobal.rowerr;
                    flag = 1;
                }

                if (flag == 1)
                {
                    message.InnerText = "The Debit Amount and Credit Amount is Not Equal";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                if (dramt - cramt != 0)
                {
                    message.InnerHtml = "Detail Has No Record. Can't Save.";
                    message.Style.Value = zglobal.warningmsg;
                    globalerr = 1;
                    return;
                }

                //Check and set Year/Period

                DateTime xdate111 = xdate.Text.ToString().Trim() != string.Empty
                               ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture)
                               : DateTime.Now;

                int offset;
                int per;
                int year = xdate111.Year;

                int tempper;
                int tempyear;

                offset = zglobal.fnGetValueInt("xinteger", "msstatus",
                    "zid=" + _zid + " and xtypestatus='GL Period Offset'");

                per = 12 + xdate111.Month - offset;

                if (per <= 12)
                {
                    tempper = per;
                    tempyear = year - 1;
                }
                else
                {
                    tempper = per - 12;
                    tempyear = year;
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

               
                
                string xlong1 = "";
                string xpostflag1 = "";
                DateTime xtdate1 = DateTime.Now;
                string xstatusjv1 = "Balanced";
                string xdesc031 = "";
                int xyear1 = tempyear;
                int xper1 = tempper;
                int xnumofper1 = offset;
                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xtrngl1 = "";

                string xnote1 = "";
                string xaction1 = "";
                string xref1 = "";
                DateTime xdate1 = DateTime.Now;
                string xsup1 = "";
                string xtwh1 = "";
                int xsign1 = 1;
                string xremarks1 = "";


                using (TransactionScope tran = new TransactionScope())
                {

                    if (ViewState["xvoucher"] == null)
                    {

                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;

                            DateTime ztime = DateTime.Now;
                            DateTime zutime = DateTime.Now;
                            _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                            xvoucher_1 = "";
                            xdate1 = xdate.Text.ToString().Trim() != string.Empty
                                ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                    : DateTime.Now;

                            string query =
                              "INSERT INTO glheader (ztime,zid,xvoucher,xref,xdate,xlong,xpostflag,xyear,xper,xstatusjv,xdesc03,zemail,xnumofper,xtrngl,xnote,xaction,xflag,xstatus) " +
                                    "VALUES(@ztime,@zid,@xvoucher,@xref,@xdate,@xlong,@xpostflag,@xyear,@xper,@xstatusjv,@xdesc03,@zemail,@xnumofper,@xtrngl,@xnote,@xaction,'','0000' )";

                            xvoucher_1 = zglobal.GetMaximumIDWithTRNAcc(ViewState["xtrngl"].ToString(),"xvoucher","glheader",xdate1,"xdate");
                            ViewState["xvoucher"] = xvoucher_1;
                            hiddenxvoucher.Value = xvoucher_1;
                            xtrngl1 = ViewState["xtrngl"].ToString();
                            xref1 = xref.Text.Trim().ToString();
                            xdesc031 = xdesc03.Text.Trim().ToString();
                            xnote1 = xnote.Text.Trim().ToString();
                            
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xvoucher", xvoucher_1);
                            cmd.Parameters.AddWithValue("@xref", xref1);
                            cmd.Parameters.AddWithValue("@xdate", xdate1);
                            cmd.Parameters.AddWithValue("@xlong", xlong1);
                            cmd.Parameters.AddWithValue("@xpostflag", xpostflag1);
                            cmd.Parameters.AddWithValue("@xyear", xyear1);
                            cmd.Parameters.AddWithValue("@xper", xper1);
                            cmd.Parameters.AddWithValue("@xstatusjv", xstatusjv1);
                            cmd.Parameters.AddWithValue("@xdesc03", xdesc031);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.Parameters.AddWithValue("@xnumofper", xnumofper1);
                            cmd.Parameters.AddWithValue("@xtrngl", ViewState["xtrngl"].ToString());
                            cmd.Parameters.AddWithValue("@xnote", xnote1);
                            cmd.Parameters.AddWithValue("@xaction", ViewState["xaction"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }



                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        string query = "";
                      

                        if (xvoucher_1 == "")
                        {
                            if (Convert.ToString(ViewState["xvoucher"]) != xvoucher.Text.Trim().ToString())
                            {
                                message.InnerHtml = "<font color=red>Record Pointer Mismatch; Cannot <font color=blue>Save <br> New Record Retrieved</font>";
                                message.Style.Value = zglobal.warningmsg;
                                globalerr = 1;
                                return;
                            }

                            int chkyear = zglobal.fnGetValueInt("xyear", "glheader",
                     " zid=" + _zid + " and xvoucher='" + Convert.ToString(ViewState["xvoucher"] + "'"));

                            int chkper = zglobal.fnGetValueInt("xper", "glheader",
                     " zid=" + _zid + " and xvoucher='" + Convert.ToString(ViewState["xvoucher"] + "'"));

                            if (tempyear != chkyear || tempper != chkper)
                            {
                                message.InnerHtml = "Can't Change Year & Period.";
                                message.Style.Value = zglobal.warningmsg;
                                globalerr = 1;
                                return;
                            }

                            //xdate1 = xdate.Text.ToString().Trim() != string.Empty
                            //    ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
                            //        CultureInfo.InvariantCulture)
                            //    : DateTime.Now;
                            xref1 = xref.Text.Trim().ToString();
                            xdesc031 = xdesc03.Text.Trim().ToString();
                            xnote1 = xnote.Text.Trim().ToString();

                            query = "UPDATE glheader SET zutime=@zutime,xemail=@xemail, " +
                                   "xdesc03=@xdesc03, xref=@xref, xnote=@xnote " +
                                   "WHERE zid=@zid AND xvoucher=@xvoucher ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xvoucher", Convert.ToString(ViewState["xvoucher"]));
                            cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@xemail",
                                Convert.ToString(HttpContext.Current.Session["curuser"]));
                            cmd.Parameters.AddWithValue("@xdesc03", xdesc031);
                            cmd.Parameters.AddWithValue("@xref", xref1);
                            cmd.Parameters.AddWithValue("@xnote", xnote1);
                            cmd.ExecuteNonQuery();

                        }

                        query = "DELETE FROM gldetail WHERE zid=@zid AND xvoucher=@xvoucher";
                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xvoucher", ViewState["xvoucher"].ToString());
                        cmd.ExecuteNonQuery();

                        int count = 1;
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            TextBox xsub123 = row.FindControl("xsub") as TextBox;

                            int xrow1 = zglobal.GetMaximumIdInt("xrow", "gldetail",
                                   " zid=" + _zid + " and xvoucher='" + Convert.ToString(ViewState["xvoucher"] + "'"), "row");

                            TextBox xamountdr123 = row.FindControl("xamountdr") as TextBox;
                            TextBox xamountcr123 = row.FindControl("xamountcr") as TextBox;
                            TextBox xacc123 = row.FindControl("xacc") as TextBox;
                            DropDownList xpaytype123 = row.FindControl("xpaytype") as DropDownList;
                            TextBox xcheque123 = row.FindControl("xcheque") as TextBox;
                            TextBox xdateclr123 = row.FindControl("xdateclr") as TextBox;

                            string ximtrnnum1 = "";


                            decimal xamountdr12;
                            if (xamountdr123.Text.Trim().ToString() == "" ||
                                xamountdr123.Text.Trim().ToString() == String.Empty)
                            {
                                xamountdr12 = 0;
                            }
                            else
                            {
                                xamountdr12 = decimal.Parse(xamountdr123.Text.Trim().ToString());
                            }

                            decimal xamountcr12;
                            if (xamountcr123.Text.Trim().ToString() == "" ||
                                xamountcr123.Text.Trim().ToString() == String.Empty)
                            {
                                xamountcr12 = 0;
                            }
                            else
                            {
                                xamountcr12 = decimal.Parse(xamountcr123.Text.Trim().ToString());
                            }

                            decimal xprime1;

                            if (xamountdr12 != 0)
                            {
                                xprime1 = xamountdr12;
                            }
                            else
                            {
                                xprime1 = -xamountcr12;
                            }

                            decimal xexch1 = 1;

                            string xaccusage1 = "";
                            string xaccsource1 = "";
                            string xacctype1 = "";

                            

                            string xcheque1 = xcheque123.Text.Trim().ToString();
                            string xpaytype1 = xpaytype123.Text.Trim().ToString();
                            string xstatus1 = "0000";
                            DateTime xdateclr1 = xdateclr123.Text.ToString().Trim() != string.Empty
                            ? DateTime.ParseExact(xdateclr123.Text.ToString().Trim(), "dd/MM/yyyy",
                                CultureInfo.InvariantCulture)
                            : new DateTime(2999, 12, 31);
                            
                            if (xsub123.Text.Trim().ToString() != string.Empty)
                            {
                                using (DataSet dtsChkStatusDataSet = new DataSet())
                                {
                                    string query1 = "SELECT xaccusage,xaccsource,xacctype FROM glmst WHERE zid=@zid and xacc=@xacc";

                                    SqlDataAdapter daChkStatuSqlDataAdapter = new SqlDataAdapter(query1, conn);
                                    daChkStatuSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                    daChkStatuSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@xacc", xacc123.Text.Trim().ToString());
                                    daChkStatuSqlDataAdapter.Fill(dtsChkStatusDataSet, "tempTable");
                                    DataTable tempTableChkStatusDataTable = new DataTable();
                                    tempTableChkStatusDataTable = dtsChkStatusDataSet.Tables["tempTable"];
                                    if (tempTableChkStatusDataTable.Rows.Count > 0)
                                    {
                                        xaccusage1 = tempTableChkStatusDataTable.Rows[0]["xaccusage"].ToString();
                                        xaccsource1 = tempTableChkStatusDataTable.Rows[0]["xaccsource"].ToString();
                                        xacctype1 = tempTableChkStatusDataTable.Rows[0]["xacctype"].ToString();
                                    }

                                    daChkStatuSqlDataAdapter.Dispose();
                                    dtsChkStatusDataSet.Clear();
                                    tempTableChkStatusDataTable.Dispose();
                                }

                                query =
                                    "INSERT INTO gldetail (zid,xvoucher,xrow,xacc,xaccusage,xaccsource,xsub,xdiv,xsec,xcur,xexch,xprime,xbase,xacctype,xcheque,xpaytype,xstatus,xdateclr) " +
                                    "VALUES(@zid,@xvoucher,@xrow,@xacc,@xaccusage,@xaccsource,@xsub,@xdiv,@xsec,@xcur,@xexch,@xprime,@xbase,@xacctype,@xcheque,@xpaytype,@xstatus,@xdateclr) ";


                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xvoucher", Convert.ToString(ViewState["xvoucher"]));
                                cmd.Parameters.AddWithValue("@xrow", xrow1);
                                cmd.Parameters.AddWithValue("@xacc", xacc123.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xaccusage", xaccusage1);
                                cmd.Parameters.AddWithValue("@xaccsource", xaccsource1);
                                cmd.Parameters.AddWithValue("@xsub", xsub123.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xdiv", "");
                                cmd.Parameters.AddWithValue("@xsec", "");
                                cmd.Parameters.AddWithValue("@xcur", "BDT");
                                cmd.Parameters.AddWithValue("@xexch", xexch1);
                                cmd.Parameters.AddWithValue("@xprime", xprime1);
                                cmd.Parameters.AddWithValue("@xbase", xexch1*xprime1);
                                cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                                cmd.Parameters.AddWithValue("@xcheque", xcheque1);
                                cmd.Parameters.AddWithValue("@xpaytype", xpaytype1);
                                cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                                cmd.Parameters.AddWithValue("@xdateclr", xdateclr1);
                                cmd.ExecuteNonQuery();

                            }

                            count += 1;
                            if (count == GridView1.Rows.Count)
                            {
                                if (xprimecr.Text.Trim().ToString() != String.Empty)
                                {
                                    using (DataSet dtsChkStatusDataSet = new DataSet())
                                    {
                                        string query1 = "SELECT xaccusage,xaccsource,xacctype FROM glmst WHERE zid=@zid and xacc=@xacc";

                                        SqlDataAdapter daChkStatuSqlDataAdapter = new SqlDataAdapter(query1, conn);
                                        daChkStatuSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daChkStatuSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@xacc", hxacc.Value.Trim().ToString());
                                        daChkStatuSqlDataAdapter.Fill(dtsChkStatusDataSet, "tempTable");
                                        DataTable tempTableChkStatusDataTable = new DataTable();
                                        tempTableChkStatusDataTable = dtsChkStatusDataSet.Tables["tempTable"];

                                        if (tempTableChkStatusDataTable.Rows.Count > 0)
                                        {
                                            xaccusage1 = tempTableChkStatusDataTable.Rows[0]["xaccusage"].ToString();
                                            xaccsource1 = tempTableChkStatusDataTable.Rows[0]["xaccsource"].ToString();
                                            xacctype1 = tempTableChkStatusDataTable.Rows[0]["xacctype"].ToString();
                                        }

                                        daChkStatuSqlDataAdapter.Dispose();
                                        dtsChkStatusDataSet.Clear();
                                        tempTableChkStatusDataTable.Dispose();
                                    }

                                    xprime1 = -Convert.ToDecimal(xprimecr.Text.Trim().ToString());
                                    xcheque1 = xchequecr.Text.Trim().ToString();
                                    xpaytype1 = xpaytypecr.Text.Trim().ToString();
                                    xdateclr1 = xdateclrcr.Text.ToString().Trim() != string.Empty
                                    ? DateTime.ParseExact(xdateclrcr.Text.ToString().Trim(), "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture)
                                    : new DateTime(2999, 12, 31);

                                    query =
                                        "INSERT INTO gldetail (zid,xvoucher,xrow,xacc,xaccusage,xaccsource,xsub,xdiv,xsec,xcur,xexch,xprime,xbase,xacctype,xcheque,xpaytype,xstatus,xdateclr) " +
                                        "VALUES(@zid,@xvoucher,@xrow,@xacc,@xaccusage,@xaccsource,@xsub,@xdiv,@xsec,@xcur,@xexch,@xprime,@xbase,@xacctype,@xcheque,@xpaytype,@xstatus,@xdateclr) ";


                                    cmd.CommandText = query;
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xvoucher", Convert.ToString(ViewState["xvoucher"]));
                                    cmd.Parameters.AddWithValue("@xrow", xrow1);
                                    cmd.Parameters.AddWithValue("@xacc", hxacc.Value.Trim().ToString());
                                    cmd.Parameters.AddWithValue("@xaccusage", xaccusage1);
                                    cmd.Parameters.AddWithValue("@xaccsource", xaccsource1);
                                    cmd.Parameters.AddWithValue("@xsub", hxsub.Value.Trim().ToString());
                                    cmd.Parameters.AddWithValue("@xdiv", "");
                                    cmd.Parameters.AddWithValue("@xsec", "");
                                    cmd.Parameters.AddWithValue("@xcur", "BDT");
                                    cmd.Parameters.AddWithValue("@xexch", xexch1);
                                    cmd.Parameters.AddWithValue("@xprime", xprime1);
                                    cmd.Parameters.AddWithValue("@xbase", xexch1 * xprime1);
                                    cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                                    cmd.Parameters.AddWithValue("@xcheque", xcheque1);
                                    cmd.Parameters.AddWithValue("@xpaytype", xpaytype1);
                                    cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                                    cmd.Parameters.AddWithValue("@xdateclr", xdateclr1);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                        }



                    }

                    tran.Complete();

                }



                //message.InnerHtml = zglobal.savesuccmsg;
                //message.Style.Value = zglobal.successmsg;
               
                xvoucher.Text = ViewState["xvoucher"].ToString();
                //fnButtonState();
                fnFillGrid2();

                //xstatusjv.InnerHtml = "Balanced";
                //zemail.InnerHtml = zemail1;
                
                //fnCalculateTotal();
                fnFillControl(ViewState["xvoucher"].ToString());

                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;

                xyear.Text = tempyear.ToString();
                xper.Text = tempper.ToString();

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
                         "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xvoucher,xdate,xref,xyear,xper,xstatusjv,xpostflag " +
                         "FROM glheader WHERE zid=@zid AND xtrngl=@xtrngl AND xpostflag='' " +
                         "order by xvoucher desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xtrngl", ViewState["xtrngl"].ToString());



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        dgvunposted.DataSource = tempTable;
                        dgvunposted.DataBind();
                    }


                }
            }


            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    
                    string query =
                       "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xvoucher,xdate,xref,xyear,xper,xstatusjv,xpostflag " +
                       "FROM glheader WHERE zid=@zid AND xtrngl=@xtrngl AND xpostflag='Posted' " +
                        "order by xvoucher desc";


                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xtrngl", ViewState["xtrngl"].ToString());



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        dgvposted.DataSource = tempTable;
                        dgvposted.DataBind();
                    }
                   


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
            //    ViewState["xvoucher"] = null;
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
                if (xvoucher.Text.Trim().ToString() != String.Empty)
                {
                    fnFillControl(xvoucher.Text.Trim().ToString());
                }
                else
                {
                    message.InnerHtml = "Enter transaction code.";
                    message.Style.Value = zglobal.am_warningmsg;
                    xvoucher.Focus();
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
            string xvoucher123 = xrow123;


            string str = "SELECT  xtrngl,xvoucher,xdesc03,xref,xdate,xnote,xyear,xper,xstatusjv as xstatus, xpostflag,zemail,xemail,xemailc " +
                         "FROM glheader where zid=@zid  and xvoucher=@xvoucher ";




            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xvoucher", xvoucher123);
            da.Fill(dts, "tempztcode");
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];

            if (dttemp.Rows.Count <= 0)
            {
                message.InnerHtml = "Wrong Voucher No.";
                message.Style.Value = zglobal.am_warningmsg;

                ViewState["xvoucher"] = null;
                //xtrngl.Text = "";
                xdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                xdesc03.Text = "";
                xref.Text = "";
                xnote.Text = "";
                xstatusjv.InnerHtml = "";
                zemail.InnerHtml = "";
                xemail.InnerHtml = "";
                xemailc.InnerHtml = "";
                xacccr.Text = "";
                xprimecr.Text = "";
                hxacc.Value = "";
                hxsub.Value = "";
                xpaytypecr.Text = "Cheque";
                xchequecr.Text = "";
                xdateclrcr.Text = "";

                GridView1.DataSource = null;
                GridView1.DataBind();

                SetInitialRow();

                return;
            }

            ViewState["xvoucher"] = xvoucher123;
            hiddenxvoucher.Value = ViewState["xvoucher"].ToString();

            xtrngl.Text = dttemp.Rows[0]["xtrngl"].ToString();
            xvoucher.Text = dttemp.Rows[0]["xvoucher"].ToString();
            xdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
            xdesc03.Text = dttemp.Rows[0]["xdesc03"].ToString();
            xref.Text = dttemp.Rows[0]["xref"].ToString();
            xnote.Text = dttemp.Rows[0]["xnote"].ToString();

            try
            {
                xyear.Text = dttemp.Rows[0]["xyear"].ToString();
                xper.Text = dttemp.Rows[0]["xper"].ToString();
            }
            catch (Exception)
            {
               
            }
          


            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         @"select xrow,xsub,(select xdesc1 from glmstvw1 
                            where zid=gldetail.zid and xacc=gldetail.xacc and xsub=gldetail.xsub) as xdesc, 
                            case when xprime>=0 then cast(xprime as varchar(50)) else '' end as xamountdr, 
                            case when xprime<0 then cast(abs(xprime) as varchar(50)) else '' end as xamountcr,xrem,xacc,xcheque,xpaytype,xdateclr
                            from gldetail  WHERE zid=@zid AND xvoucher=@xvoucher order by xrow";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xvoucher", xvoucher123);

                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        DataRow dr = null;

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
                            //if (tempTable.Rows[i]["xamountdr"].ToString() != "")
                            if (i < tempTable.Rows.Count - 1)
                            {
                                dr = dt.NewRow();
                                //dr["RowNumber"] = 1;
                                dr["Column1"] = tempTable.Rows[i]["xsub"].ToString();
                                dr["Column2"] = tempTable.Rows[i]["xdesc"].ToString();
                                dr["Column3"] = tempTable.Rows[i]["xpaytype"].ToString();
                                dr["Column4"] = tempTable.Rows[i]["xcheque"].ToString();
                                dr["Column5"] = tempTable.Rows[i]["xdateclr"].ToString();
                                dr["Column6"] = tempTable.Rows[i]["xamountdr"].ToString();
                                dr["Column7"] = tempTable.Rows[i]["xamountcr"].ToString();
                                dr["Column8"] = tempTable.Rows[i]["xrem"].ToString();
                                dr["Column9"] = tempTable.Rows[i]["xacc"].ToString();
                                dt.Rows.Add(dr);

                                //i = i + 1;
                            }
                            else
                            {
                                xacccr.Text = tempTable.Rows[i]["xsub"].ToString();
                                xprimecr.Text = tempTable.Rows[i]["xamountcr"].ToString();
                                xdesccr.Text = tempTable.Rows[i]["xdesc"].ToString();
                                hxacc.Value = tempTable.Rows[i]["xacc"].ToString();
                                hxsub.Value = tempTable.Rows[i]["xsub"].ToString();
                                xpaytypecr.Text = tempTable.Rows[i]["xpaytype"].ToString();
                                xchequecr.Text = tempTable.Rows[i]["xcheque"].ToString();
                                xdateclrcr.Text = Convert.ToDateTime(tempTable.Rows[i]["xdateclr"].ToString()).ToString("dd/MM/yyyy");
                                if (xdateclrcr.Text == "31/12/2999")
                                {
                                    xdateclrcr.Text = "";
                                }
                            }

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
                                dr["Column9"] = "";
                                dt.Rows.Add(dr);

                                i = i + 1;
                            }
                        }


                        ViewState["CurrentTable"] = dt;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        for (int k = 0; k < GridView1.Rows.Count; k++)
                        {
                            DropDownList ddl1 = (DropDownList)GridView1.Rows[k].Cells[3].FindControl("xpaytype");
                            fnFillPayType(ddl1);
                        }

                        i = 0;
                        foreach (GridViewRow row in GridView1.Rows)
                        {

                            TextBox xsub1 = row.FindControl("xsub") as TextBox;
                            TextBox xdesc1 = row.FindControl("xdesc") as TextBox;
                            TextBox xamountdr1 = row.FindControl("xamountdr") as TextBox;
                            TextBox xamountcr1 = row.FindControl("xamountcr") as TextBox;
                            TextBox xrem1 = row.FindControl("xrem") as TextBox;
                            TextBox xacc1 = row.FindControl("xacc") as TextBox;
                            DropDownList xpaytype1 = row.FindControl("xpaytype") as DropDownList;
                            TextBox xcheque1 = row.FindControl("xcheque") as TextBox;
                            TextBox xdateclr1 = row.FindControl("xdateclr") as TextBox;
                            LinkButton btnRemove = row.FindControl("btnRemove") as LinkButton;

                            if (i < tempTable.Rows.Count)
                            {
                                //if (tempTable.Rows[i]["xamountdr"].ToString() != "")
                                if (i < tempTable.Rows.Count - 1)
                                {
                                    xsub1.Text = tempTable.Rows[i]["xsub"].ToString();
                                    xdesc1.Text = tempTable.Rows[i]["xdesc"].ToString();
                                    xamountdr1.Text = tempTable.Rows[i]["xamountdr"].ToString();
                                    xamountcr1.Text = tempTable.Rows[i]["xamountcr"].ToString();
                                    xrem1.Text = tempTable.Rows[i]["xrem"].ToString();
                                    xacc1.Text = tempTable.Rows[i]["xacc"].ToString();
                                    xpaytype1.Text = tempTable.Rows[i]["xpaytype"].ToString();
                                    xcheque1.Text = tempTable.Rows[i]["xcheque"].ToString();
                                    xdateclr1.Text =
                                        Convert.ToDateTime(tempTable.Rows[i]["xdateclr"].ToString())
                                            .ToString("dd/MM/yyyy");
                                    if (xdateclr1.Text == "31/12/2999")
                                    {
                                        xdateclr1.Text = "";
                                    }
                                }
                            }

                            if (dttemp.Rows[0]["xpostflag"].ToString() == "Posted")
                            {
                                xsub1.Enabled = false;
                                xdesc1.Enabled = false;
                                xamountdr1.Enabled = false;
                                xamountcr1.Enabled = false;
                                xrem1.Enabled = false;
                                xacc1.Enabled = false;
                                xpaytype1.Enabled = false;
                                xcheque1.Enabled = false;
                                xdateclr1.Enabled = false;
                                btnRemove.Visible = false;
                            }
                            else
                            {
                                //xitem1.Enabled = true;
                                //xdesc1.Enabled = true;
                                xsub1.Enabled = true;
                                //xunit1.Enabled = true;
                                xamountdr1.Enabled = true;
                                xamountcr1.Enabled = true;
                                xrem1.Enabled = true;
                                xacc1.Enabled = true;
                                xpaytype1.Enabled = true;
                                xcheque1.Enabled = true;
                                xdateclr1.Enabled = true;
                                btnRemove.Visible = true;
                            }

                            i = i + 1;
                        }
                    }
                    else
                    {
                        SetInitialRow();
                    }

                    tempTable.Dispose();


                }
            }

            Button btnaddrow = GridView1.FooterRow.Cells[0].FindControl("btnAddRow") as Button;

            if (dttemp.Rows[0]["xpostflag"].ToString() == "Posted")
            {
                xvoucher.Enabled = false;
                xdate.Enabled = false;
                xdesc03.Enabled = false;
                xref.Enabled = false;
                xnote.Enabled = false;
                xyear.Enabled = false;
                xper.Enabled = false;
                btnaddrow.Enabled = false;
                xacccr.Enabled = false;
                xprimecr.Enabled = false;
                xpaytypecr.Enabled = false;
                xchequecr.Enabled = false;
                xdateclrcr.Enabled = false;

            }
            else
            {
                xvoucher.Enabled = true;
                xdate.Enabled = true;
                xdesc03.Enabled = true;
                xref.Enabled = true;
                xnote.Enabled = true;
                xyear.Enabled = true;
                xper.Enabled = true;
                btnaddrow.Enabled = true;
                xpaytypecr.Enabled = true;
                xchequecr.Enabled = true;
                xdateclrcr.Enabled = true;
            }

            fnButtonState();
            fnCalculateTotal();
            //BindGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerText = "";
            //    if (ViewState["xvoucher"] != null)
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
            //                    //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xvoucher"]));

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
            //                    //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xvoucher"]));
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
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xvoucher"]));
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

                if (ViewState["xvoucher"] != null)
                {
                    string xstatus1 = zglobal.fnGetValue("xpostflag", "glheader",
                         "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");
                    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1" && xstatus1!="")
                    {
                        message.InnerHtml = "Status : " + xstatus1 + ". Cann't Delete Record.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                if (ViewState["xvoucher"] != null)
                {
                    if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xstatusjv1;


                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM gldetail WHERE zid=@zid AND xvoucher=@xvoucher";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xvoucher", Convert.ToString(ViewState["xvoucher"]));
                                cmd.ExecuteNonQuery();

                                query = "DELETE FROM glheader WHERE zid=@zid AND xvoucher=@xvoucher";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        fnButtonState();

                        fnFillGrid2();

                        message.InnerHtml = zglobal.delsuccmsg;
                        message.Style.Value = zglobal.successmsg;

                    }
                }
                else
                {
                    message.InnerHtml = "No voucher found for delete.";
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
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                globalerr = 0;
                message.InnerText = "";

                if (ViewState["xvoucher"] != null)
                {
                    string xstatus1 = zglobal.fnGetValue("xpostflag", "glheader",
                         "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");
                    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1" && xstatus1 != "")
                    {
                        message.InnerHtml = "Status : " + xstatus1 + ". Already Posted.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                if (ViewState["xvoucher"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {
                        btnSave_Click(sender, e);

                        if (globalerr == 1)
                        {
                            return;
                        }

                        string drtot = zglobal.fnGetValue("sum(xbase)", "gldetail",
                            "zid=" + _zid + " and xvoucher='" + ViewState["xvoucher"].ToString() + "'");

                        if (drtot == "")
                        {
                            message.InnerHtml = "Detail Has No Record. Can't Post.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }
                        else if (Convert.ToDecimal(drtot) != 0)
                        {
                            message.InnerHtml = "Out of Balance Voucher. Can't Post.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }
                        else
                        {
                            
                        }

                        string xpostflag1;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                
                                string xconfirmedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xconfirmeddt = DateTime.Now;
                                xpostflag1 = "Posted";
                                string xflag10 = "";

                                string query = "";
                               
                                query =
                                    "UPDATE glheader SET xpostflag=@xpostflag,xemailc=@xemailc,xdatepost=@xdatepost " +
                                    "WHERE zid=@zid AND xvoucher=@xvoucher ";

                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xvoucher", Convert.ToString(ViewState["xvoucher"]));
                                cmd.Parameters.AddWithValue("@xpostflag", xpostflag1);
                                cmd.Parameters.AddWithValue("@xemailc", xconfirmedby);
                                cmd.Parameters.AddWithValue("@xdatepost", xconfirmeddt);
                                cmd.ExecuteNonQuery();


                            }

                            tran.Complete();
                        }

                        fnFillControl(Convert.ToString(ViewState["xvoucher"]));
                        message.InnerHtml = zglobal.postsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "Posted";
                        hxstatus.Value = "Posted";
                        hiddenxstatus.Value = "Posted";
                        //fnButtonState();
                        //BindGrid();
                        fnFillGrid2();
                    }
                }
                else
                {
                    message.InnerHtml = "No voucher found for post.";
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
            //    ViewState["xvoucher"] = null;
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

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                globalerr = 0;
                message.InnerText = "";

                //if (ViewState["xvoucher"] != null)
                //{
                //    string xstatus1 = zglobal.fnGetValue("xpostflag", "glheader",
                //         "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");
                //    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1" && xstatus1 != "")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Already Posted.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                if (ViewState["xvoucher"] != null)
                {
                    string xstatus1 = zglobal.fnGetValue("xref", "glheader",
                         "zid=" + _zid + " AND xvoucher='" + Convert.ToString(ViewState["xvoucher"]) + "'");
                    if (xstatus1 == "Transfered From TFC.")
                    {
                        message.InnerHtml = "This is a system generated voucher. Please contact with system administrator for undo this voucher.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

                if (ViewState["xvoucher"] != null)
                {
                    if (txtconformmessageValue3.Value == "Yes")
                    {
                        //btnSave_Click(sender, e);

                        //if (globalerr == 1)
                        //{
                        //    return;
                        //}

                        //string drtot = zglobal.fnGetValue("sum(xbase)", "gldetail",
                        //    "zid=" + _zid + " and xvoucher='" + ViewState["xvoucher"].ToString() + "'");

                        //if (drtot == "")
                        //{
                        //    message.InnerHtml = "Detail Has No Record. Can't Post.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}
                        //else if (Convert.ToDecimal(drtot) != 0)
                        //{
                        //    message.InnerHtml = "Out of Balance Voucher. Can't Post.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}
                        //else
                        //{

                        //}

                        string xpostflag1;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;

                                string xconfirmedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xconfirmeddt = DateTime.Now;
                                xpostflag1 = "";
                                string xflag10 = "";

                                string query = "";

                                query =
                                    "UPDATE glheader SET xpostflag=@xpostflag,xundoby=@xundoby,xdateundo=@xdateundo,xundost='Undo' " +
                                    "WHERE zid=@zid AND xvoucher=@xvoucher ";

                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xvoucher", Convert.ToString(ViewState["xvoucher"]));
                                cmd.Parameters.AddWithValue("@xpostflag", xpostflag1);
                                cmd.Parameters.AddWithValue("@xundoby", xconfirmedby);
                                cmd.Parameters.AddWithValue("@xdateundo", xconfirmeddt);
                                cmd.ExecuteNonQuery();


                            }

                            tran.Complete();
                        }

                        fnFillControl(Convert.ToString(ViewState["xvoucher"]));
                        message.InnerHtml = zglobal.undosuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "";
                        hxstatus.Value = "";
                        hiddenxstatus.Value = "";
                        fnButtonState();
                        //BindGrid();
                        fnFillGrid2();
                    }
                }
                else
                {
                    message.InnerHtml = "No voucher found for post.";
                    message.Style.Value = zglobal.warningmsg;
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