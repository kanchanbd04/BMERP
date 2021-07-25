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
    public partial class pratdummym : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            if (ViewState["xrow"] == null)
            {
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                btnConfirmOut.Enabled = false;
                btnConfirmOut1.Enabled = false;
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
                //dxstatus.Visible = false;
                //dxstatus.Text = "-";
                //xsessionpro.Text = "";
                //xclasspro.Text = "";
                //xsessionpro.Enabled = true;
                //xclasspro.Enabled = true;
                //xgrouppro.Text = "";
            }
            else
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                DateTime xdate1 = xdate.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string xstatus1 = zglobal.fnGetValue("xstatus", "pratdummym",
                               "zid=" + _zid + " AND xdate='" + xdate1 + "' and xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.ToString().Trim() + "'");

                string xstatus11 = zglobal.fnGetValue("xstatusin", "pratdummym",
                               "zid=" + _zid + " AND xdate='" + xdate1 + "' and xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.ToString().Trim() + "'");

                string xstatus22 = zglobal.fnGetValue("xstatusout", "pratdummym",
                               "zid=" + _zid + " AND xdate='" + xdate1 + "' and xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.ToString().Trim() + "'");

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
                    btnConfirmOut.Enabled = true;
                    btnConfirmOut1.Enabled = true;
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

                }
                else
                {
                    btnSubmit.Enabled = false;
                    btnSubmit1.Enabled = false;
                    btnSave.Enabled = false;
                    btnSave1.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDelete1.Enabled = false;
                    btnConfirmOut.Enabled = false;
                    btnConfirmOut1.Enabled = false;
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

                if (xstatus11 != "New")
                {
                    btnSubmit.Enabled = false;
                    btnSubmit1.Enabled = false;
                }

                if (xstatus22 != "New")
                {
                    btnConfirmOut.Enabled = false;
                    btnConfirmOut1.Enabled = false;
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
                    //zglobal.fnGetComboDataCD("Session", xsessionpro);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Education Group", xgrouppro);
                    // zglobal.fnGetComboDataCD("Test Type", xcttype);

                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Class", xclasspro);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);
                    zglobal.fnGetComboDataCD("Location", xlocation);
                    //zglobal.fnGetComboDataCD("Job Department", xdept);

                    xtype.Items.Clear();
                    xtype.Items.Add(new ListItem("", ""));
                    xtype.Items.Add(new ListItem("Teacher", "Teacher"));
                    xtype.Items.Add(new ListItem("Officer & Staff", "Staff"));
                    xtype.Text = "";

                    xdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //xsessionpro.Text = zglobal.fnDefaults("xsessiononline", "Student");
                    //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //zsetvalue.SetDWNumItem(xctno, 1, 15);
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
                    //btnShowList.Visible = false;
                    // pnllistct.Visible = false;
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
                    ////string xcttype1 = Request.QueryString["xcttype"] != null ? Request.QueryString["xcttype"].ToString() : "";
                    ////string xctno1 = Request.QueryString["xctno"] != null ? Request.QueryString["xctno"].ToString() : "";

                    //if (xsession1 != "" && xterm1 != "" && xclass1 != "" && xsection1 != "" && xsubject1 != "")
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

                    //    //xcttype.Text = xcttype1;
                    //    //xcttype_Click(null, null);

                    //    //xctno.Text = xctno1;
                    //    //xctno_Click(null, null);
                    //}

                    //divliststd.Visible = false;

                    _gridrow.Text = zglobal._grid_row_value;
                    _gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();



                }



                BindGrid();
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
            foreach (GridViewRow row in dgvPromotedistNew.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xdate") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            foreach (GridViewRow row in dgvPromotedistSubmitted.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xdate") as LinkButton;
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

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            DateTime xdate1 = xdate.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string xlocation1 = xlocation.Text.Trim().ToString();
            string xtype1 = xtype.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            //string xsection1 = xsection.Text.Trim().ToString();
            //message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            //return;
            string str = "";

            //if (ViewState["sortdr"] != null)
            //{
            //    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY " + Convert.ToString(ViewState["colid"]) + " " + Convert.ToString(ViewState["sortdr"]);
            //}
            //else
            //{
            str = "SELECT   @xdate as xdate,xemp,xname,xdesig,xdept FROM hrmst WHERE zid=@zid AND xlocation=@xlocation  AND xtype=@xtype and xstatusemp='A-Active'  " +
                  "ORDER BY (select cast(xcodealt as int) from mscodesam where zid=@zid and xtype='Designation' and xcode=hrmst.xdesig) ";
            //}

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xlocation", xlocation1);
            da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
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

                bfield = new BoundField();
                bfield.HeaderText = "Date";
                //bfield.SortExpression = "xstdid";
                bfield.DataField = "xdate";
                bfield.ItemStyle.Width = 100;
                bfield.DataFormatString = "{0:dd/MM/yyyy}";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(bfield);
                

                bfield = new BoundField();
                bfield.HeaderText = "Emp. Code";
                //bfield.SortExpression = "xstdid";
                bfield.DataField = "xemp";
                bfield.ItemStyle.Width = 100;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Employee Name";
                //bfield.SortExpression = "xname";
                bfield.DataField = "xname";
                bfield.ItemStyle.Width = 200;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Designation";
                //bfield.SortExpression = "xname";
                bfield.DataField = "xdesig";
                bfield.ItemStyle.Width = 200;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Department";
                //bfield.SortExpression = "xname";
                bfield.DataField = "xdept";
                bfield.ItemStyle.Width = 200;
                GridView1.Columns.Add(bfield);




                TemplateField tfield5 = new TemplateField();
                tfield5.HeaderText = "In Time";
                tfield5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield5.ItemStyle.Width = Unit.Pixel(100);
                // tfield7.Visible = false;
                GridView1.Columns.Add(tfield5);



                TemplateField tfield6 = new TemplateField();
                tfield6.HeaderText = "Out Time";
                tfield6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield6.ItemStyle.Width = Unit.Pixel(100);
                GridView1.Columns.Add(tfield6);

                TemplateField tfield7 = new TemplateField();
                tfield7.HeaderText = "N/A";
                tfield7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield7.ItemStyle.Width = Unit.Pixel(30);
                GridView1.Columns.Add(tfield7);

                TemplateField tfield8 = new TemplateField();
                tfield8.HeaderText = "Remarks";
                tfield8.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield8.ItemStyle.Width = Unit.Pixel(250);
                GridView1.Columns.Add(tfield8);

                TemplateField tfield9 = new TemplateField();
                tfield9.HeaderText = "";
                tfield9.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield9.ItemStyle.Width = Unit.Pixel(250);
                GridView1.Columns.Add(tfield9);

                //BoundField bfield1 = new BoundField();
                //bfield1.DataField = "xrow";
                //GridView1.Columns.Add(bfield1);


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        con.Open();
                        string query =

                        "SELECT * FROM pratdummym WHERE zid=@zid AND xlocation=@xlocation AND xcategory=@xcategory AND xdate=@xdate";


                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xlocation", xlocation.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xcategory", xtype.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

                        DataTable tempTable1 = new DataTable();
                        da1.Fill(dts1, "tempTable1");
                        tempTable1 = dts1.Tables["tempTable1"];

                        if (tempTable1.Rows.Count > 0)
                        {
                            ViewState["manual"] = tempTable1;
                        }
                        else
                        {
                            ViewState["manual"] = null;
                        }


                    }
                }


                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                //divliststd.Visible = true;

                int i = 1;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lbl = (Label)row.FindControl("lblno");
                    lbl.Text = i.ToString();
                    i++;
                }


            }
            else
            {
                ViewState["amexamph_result_avg1"] = null;
                ViewState["amexamph_result_avg12"] = null;
                ViewState["xsubject"] = null;
                ViewState["ampromotiond"] = null;
                ViewState["manual"] = null;
                GridView1.DataSource = null;
                GridView1.DataBind();
                //message.InnerHtml = "Student not found.";
                //message.Style.Value = zglobal.warningmsg;
                //divliststd.Visible = false;
            }

        }

        TextBox txTextBox;

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //if (ViewState["amexamph_result_avg1"] != null)
                    {
                        //DataTable amexamph_result_avg1 = (DataTable)ViewState["amexamph_result_avg1"];

                        //Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

                        Label lblno = new Label();
                        lblno.ID = "lblno";
                        e.Row.Cells[0].Controls.Add(lblno);

                        TextBox txtInTime = new TextBox();
                        txtInTime.ID = "txtInTime";
                        txtInTime.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                        e.Row.Cells[6].Controls.Add(txtInTime);
                        txtInTime.Text = "08:00:00";
                        //txtPreMarks.Enabled = false;

                        TextBox txtOutTime = new TextBox();
                        txtOutTime.ID = "txtOutTime";
                        txtOutTime.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                        e.Row.Cells[7].Controls.Add(txtOutTime);
                        txtOutTime.Text = "17:00:00";
                        //txtPreMarks.Enabled = false;

                        //DropDownList ddlIsAbsent = new DropDownList();
                        //ddlIsAbsent.ID = "ddlIsAbsent";
                        //e.Row.Cells[7].Controls.Add(ddlIsAbsent);
                        //ddlIsAbsent.Items.Clear();
                        //ddlIsAbsent.Items.Add("No");
                        //ddlIsAbsent.Items.Add("Yes");
                        //ddlIsAbsent.Text = "No";

                        //HtmlGenericControl lbl = new HtmlGenericControl("label");
                        //lbl.Attributes.Add("class", "switch");
                        //e.Row.Cells[7].Controls.Add(lbl);

                        CheckBox chkIsAbsent = new CheckBox();
                        chkIsAbsent.ID = "chkIsAbsent";
                        //chkCheckBox.CssClass = "toggle-checkbox";
                        //e.Row.Cells[amexamph_result_avg1.Rows.Count+3].Controls.Add(chkCheckBox);
                        e.Row.Cells[8].Controls.Add(chkIsAbsent);
                        chkIsAbsent.Enabled = true;

                        //HtmlGenericControl spn = new HtmlGenericControl("span");
                        //spn.Attributes.Add("class", "slider round");
                        //lbl.Controls.Add(spn);

                        TextBox txtRemarks = new TextBox();
                        txtRemarks.ID = "txtRemarks";
                        txtRemarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                        e.Row.Cells[9].Controls.Add(txtRemarks);


                        if (ViewState["xrow"] != null)
                        {
                            DataTable manual = (DataTable) ViewState["manual"];

                            if (manual.Rows.Count > 0)
                            {
                                if (Convert.ToString(manual.Rows[0]["xstatusin"]) != "New" &&
                                    Convert.ToString(manual.Rows[0]["xstatusin"]) != "Undo" &&
                                    Convert.ToString(manual.Rows[0]["xstatusin"]) != "Undo1")
                                {
                                    txtInTime.Enabled = false;
                                    chkIsAbsent.Enabled = false;
                                }
                                else
                                {
                                    txtInTime.Enabled = true;
                                   
                                }

                                if (Convert.ToString(manual.Rows[0]["xstatusout"]) != "New" &&
                                    Convert.ToString(manual.Rows[0]["xstatusout"]) != "Undo" &&
                                    Convert.ToString(manual.Rows[0]["xstatusout"]) != "Undo1")
                                {
                                    txtOutTime.Enabled = false;
                                    chkIsAbsent.Enabled = false;
                                    
                                }
                                else
                                {
                                    txtOutTime.Enabled = true;
                                }

                                if (Convert.ToString(manual.Rows[0]["xstatus"]) != "New" &&
                                    Convert.ToString(manual.Rows[0]["xstatus"]) != "Undo" &&
                                    Convert.ToString(manual.Rows[0]["xstatus"]) != "Undo1")
                                {
                                    chkIsAbsent.Enabled = false;
                                    txtRemarks.Enabled = false;
                                }
                                else
                                {
                                   
                                    txtRemarks.Enabled = true;
                                }

                                //DataRow[] dtrows = manual.Select("xemp='" + (e.Row.DataItem as DataRowView).Row["xemp"].ToString() + "'");

                                //bool isabsent = dtrows[0]["xisabsent"] == "1" ? true : false;

                                //if (isabsent)
                                //{
                                //    chkIsAbsent.Checked = true;
                                //}
                                //else
                                //{
                                //    chkIsAbsent.Checked = false;
                                //}

                                foreach (DataRow row in manual.Rows)
                                {
                                    if (row["xemp"].ToString() ==
                                        (e.Row.DataItem as DataRowView).Row["xemp"].ToString())
                                    {
                                        if (row["xisabsent"].ToString() == "1")
                                        {
                                            chkIsAbsent.Checked = true;
                                        }
                                        else
                                        {
                                            chkIsAbsent.Checked = false;
                                        }

                                        txtInTime.Text = row["xstr01"].ToString();
                                        txtOutTime.Text = row["xstr02"].ToString();
                                        txtRemarks.Text = row["xremarks"].ToString();

                                        break;
                                    }
                                    else
                                    {
                                        chkIsAbsent.Checked = false;
                                    }

                                   
                                }


                            }

                        }



                        //    if (amexamd.Rows.Count > 0)
                        //    {
                        //        foreach (DataRow row in amexamd.Rows)
                        //        {
                        //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
                        //            {
                        //                if (row["xgetmark"].ToString() == "-1.00")
                        //                {
                        //                    txtMarks.Text = "";
                        //                }
                        //                else
                        //                {
                        //                    txtMarks.Text = row["xgetmark"].ToString();
                        //                }

                        //                int chk = DBNull.Value.Equals(row["xna"]) == true
                        //                    ? 0
                        //                    : Convert.ToInt32(row["xna"].ToString());

                        //                if (chk == 1)
                        //                {
                        //                    chkCheckBox.Checked = true;
                        //                }
                        //                else
                        //                {
                        //                    chkCheckBox.Checked = false;
                        //                }

                        //                txtComments.Text = row["xremarks"].ToString();
                        //                lblxline.Text = row["xline"].ToString();
                        //                lblxflag1.Text = row["xflag11"].ToString();
                        //                lblxflag2.Text = row["xflag22"].ToString();

                        //                //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
                        //                //{
                        //                //    //if (row["xflag11"].ToString() == "Wrong" ||
                        //                //    //    row["xflag22"].ToString() == "Missing" || row["xflag11"].ToString() == "Corrected" ||
                        //                //    //    row["xflag22"].ToString() == "Taken")
                        //                //    //if (row["xflag11"].ToString() == "" ||
                        //                //    //    row["xflag22"].ToString() == "")
                        //                //    if (row["xflag11"].ToString() == "Wrong" || row["xflag22"].ToString() == "Missing")
                        //                //    {
                        //                //        txtComments.Enabled = true;
                        //                //        txtMarks.Enabled = true;
                        //                //        chkCheckBox.Enabled = true;
                        //                //    }

                        //                //    //if (lblxline.Text == "" || lblxline.Text == String.Empty)
                        //                //    //{
                        //                //    //    txtComments.Enabled = true;
                        //                //    //    txtMarks.Enabled = true;
                        //                //    //}

                        //                //}
                        //                break;
                        //            }
                        //        }

                        //        //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
                        //        //{
                        //        //    if (lblxline.Text == "" || lblxline.Text == String.Empty)
                        //        //    {
                        //        //        txtComments.Enabled = true;
                        //        //        txtMarks.Enabled = true;
                        //        //        chkCheckBox.Enabled = true;
                        //        //    }
                        //        //}
                        //    }


                        //}

                        //if (ViewState["ampromotiond"] != null)
                        //{
                        //    if (ViewState["xstatus"].ToString() == "Approved")
                        //    {
                        //        chkCheckBox.InputAttributes.Add("disabled", "disabled");
                        //    }
                        //    else
                        //    {
                        //        chkCheckBox.InputAttributes.Remove("disabled");
                        //    }

                        //    DataTable ampromotiond = (DataTable)ViewState["ampromotiond"];
                        //    DataRow[] result =
                        //       ampromotiond.Select("xsrow=" +
                        //                                    xrow);
                        //    if (result.Length > 0)
                        //    {
                        //        if (result[0]["xpromoted"].ToString() == "1")
                        //        {
                        //            chkCheckBox.Checked = true;
                        //        }
                        //        else
                        //        {
                        //            chkCheckBox.Checked = false;
                        //        }
                        //    }



                        //}

                        //if (ViewState["dtprectmarks"] != null)
                        //{
                        //    DataTable dtprectmarks = (DataTable)ViewState["dtprectmarks"];
                        //    if (dtprectmarks.Rows.Count > 0)
                        //    {
                        //        foreach (DataRow row in dtprectmarks.Rows)
                        //        {
                        //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
                        //            {
                        //                if (row["xgetmark"].ToString() == "-1.00")
                        //                {
                        //                    txtPreMarks.Text = "";
                        //                }
                        //                else
                        //                {
                        //                    txtPreMarks.Text = row["xgetmark"].ToString();
                        //                }

                        //                int chk = DBNull.Value.Equals(row["xna"]) == true
                        //                  ? 0
                        //                  : Convert.ToInt32(row["xna"].ToString());

                        //                if (chk == 1)
                        //                {
                        //                    chkCheckBox.Checked = true;
                        //                }
                        //                else
                        //                {
                        //                    chkCheckBox.Checked = false;
                        //                }

                        //                break;
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    txtPreMarks.Text = "";
                        //}

                        //DataTable amexamph_result_avg12 = (DataTable)ViewState["amexamph_result_avg12"];
                        //if (amexamph_result_avg12.Rows.Count > 0)
                        //{
                        //    //DataRow[] result;

                        //    for (int i = 3; i < amexamph_result_avg1.Rows.Count + 3; i++)
                        //    {
                        //        DataRow[] result =
                        //        amexamph_result_avg12.Select("xsrow=" +
                        //                                     xrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[i - 3] + "'");
                        //        if (result.Length > 0)
                        //        {
                        //            e.Row.Cells[i].Text = result[0]["xgrade"].ToString();
                        //            e.Row.Cells[i].ToolTip = result[0]["xsubject"].ToString() + "\n Marks: " +
                        //                                     result[0]["xaveragemarks"].ToString();
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    for (int i = 3; i < amexamph_result_avg1.Rows.Count + 3; i++)
                        //    {
                        //        e.Row.Cells[i].Text = "";
                        //    }
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
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            DateTime xdate1 = xdate.Text.Trim() != string.Empty
                                ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {
                    con.Open();
                    string query =

                    "SELECT * FROM pratdummym WHERE zid=@zid AND xlocation=@xlocation AND xcategory=@xcategory AND xdate=@xdate";


                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xlocation", xlocation.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xcategory", xtype.Text.Trim().ToString());
                    da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

                    DataTable tempTable = new DataTable();
                    da.Fill(dts, "tempTable");
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        ViewState["xrow"] = tempTable.Rows[0]["xemp"].ToString();
                    }
                    else
                    {
                        ViewState["xrow"] = null;
                    }


                }
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //btnRefresh_Click(sender,e);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                DateTime xdate1 = xdate.Text.Trim() != string.Empty
                                ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                int xrow = 0;
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xlocation.Text == "" || xlocation.Text == string.Empty || xlocation.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Location</li>";
                    isValid = false;
                }
                if (xtype.Text == "" || xtype.Text == string.Empty || xtype.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Type</li>";
                    isValid = false;
                }
                if (xdate.Text == "" || xdate.Text == string.Empty || xdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Date</li>";
                    isValid = false;
                }
                


                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                fnCheckRow();
                string xstatus1 = "";
                if (ViewState["xrow"] != null)
                {
                    xstatus1 = zglobal.fnGetValue("xstatus", "pratdummym",
                          "zid=" + _zid + " AND xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='"+ xtype.Text.Trim().ToString() +"' and xdate='"+xdate1+"'");
                    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                    {
                        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }


                string chk_fpay = zglobal.fnGetValue("xflags", "prpay",
                     "zid=" + _zid + " AND xpaydate>='" + xdate1 + "' and xflags='1'");

                if (chk_fpay != "")
                {
                    message.InnerHtml = "Can't Save <br/>Final Payroll already Processed.";
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }


                using (TransactionScope tran = new TransactionScope())
                {
                    if (GridView1.Rows.Count > 0)
                    {
                        //if (ViewState["xrow"] == null)
                        //{
                            ////Duplicate entry check & check sequential entry Test-1,2,3.....
                            //using (SqlConnection con = new SqlConnection(zglobal.constring))
                            //{
                            //    using (DataSet dts = new DataSet())
                            //    {
                            //        con.Open();
                            //        string query =
                            //            //"SELECT * FROM hrgrowthh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass  AND xgroup=@xgroup   AND xsection=@xsection AND xsubject=@xsubject AND xobserno=@xobserno AND xteacher=@xteacher";
                            //            "SELECT * FROM ampromotionh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection";


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
                            //            message.InnerHtml = "Cann't insert duplicate record.";
                            //            message.Style.Value = zglobal.warningmsg;
                            //            return;
                            //        }

                            //    }
                            //}


                            //using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            //{
                                //conn.Open();
                                //SqlCommand cmd = new SqlCommand();
                                //cmd.Connection = conn;

                                //DateTime ztime = DateTime.Now;
                                //DateTime zutime = DateTime.Now;
                                //_zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                //xrow = 0;

                                //string xsession1 = "";
                                //string xclass1 = "";
                                //string xgroup1 = "";
                                //string xsection1 = "";
                                //string xsessionpro1 = "";
                                //string xclasspro1 = "";
                                //string xgrouppro1 = "";
                                //string xstatus = "New";
                                //string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);


                                //string query = 
                                    //"INSERT INTO pratdummym (ztime,zid,xemp,xdate,xstr01,xstr02,xstatus,xremarks,xlocation,xcategory,xstatusin,xstatusout,xisabsent,zemail) " +
                                    //"VALUES(@ztime,@zid,@xemp,@xdate,@xstr01,@xstr02,@xstatus,@xremarks,@xlocation,@xcategory,@xstatusin,@xstatusout,@xisabsent,@zemail) ";

                                //xrow = zglobal.GetMaximumIdInt("xrow", "ampromotionh", " zid=" + _zid, 1, 1);
                                //ViewState["xrow"] = xrow;
                                //hiddenxrow.Value = ViewState["xrow"].ToString();
                                //xsession1 = xsession.Text.Trim().ToString();
                                //xclass1 = xclass.Text.Trim().ToString();
                                //xgroup1 = xgroup.Text.Trim().ToString();
                                //xsection1 = xsection.Text.ToString().Trim();
                                //xsessionpro1 = xsessionpro.Text.Trim().ToString();
                                //xclasspro1 = xclasspro.Text.ToString().Trim();
                                //// xgrouppro1 = xgrouppro.Text.Trim().ToString();

                                //cmd.CommandText = query;
                                //cmd.Parameters.AddWithValue("@ztime", ztime);
                                //cmd.Parameters.AddWithValue("@zutime", ztime);
                                //cmd.Parameters.AddWithValue("@zid", _zid);
                                //cmd.Parameters.AddWithValue("@xrow", xrow);
                                //cmd.Parameters.AddWithValue("@xsession", xsession1);
                                //cmd.Parameters.AddWithValue("@xclass", xclass1);
                                //cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                                //cmd.Parameters.AddWithValue("@xsection", xsection1);
                                //cmd.Parameters.AddWithValue("@xsessionpro", xsessionpro1);
                                //cmd.Parameters.AddWithValue("@xclasspro", xclasspro1);
                                //cmd.Parameters.AddWithValue("@xgrouppro", xgrouppro1);
                                //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //cmd.Parameters.AddWithValue("@zemail", zemail);
                                //cmd.ExecuteNonQuery();
                            //}
                        //}



                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;


                            string query = "DELETE FROM pratdummym WHERE zid=@zid AND xlocation=@xlocation and xcategory=@xcategory and xdate=@xdate ";
                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xlocation", xlocation.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@xcategory", xtype.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@xdate", xdate1);
                            //if (xstatus1 != "Undo1" && xstatus1 != "Undo")
                            //if (xstatus1 != "Undo1")
                            //{
                            cmd.ExecuteNonQuery();
                            //}


                            //if (xrow == 0)
                            //{


                            //    string xsessionpro1 = xsessionpro.Text.Trim().ToString();
                            //    string xclasspro1 = xclasspro.Text.ToString().Trim();
                            //    string xgrouppro1 = "";//xgrouppro.Text.Trim().ToString();

                            //    query = "UPDATE ampromotionh SET zutime=@zutime,xemail=@xemail,xsessionpro=@xsessionpro,xclasspro=@xclasspro,xgrouppro=@xgrouppro " +
                            //            "WHERE zid=@zid AND xrow=@xrow ";
                            //    cmd.Parameters.Clear();

                            //    cmd.CommandText = query;
                            //    cmd.Parameters.AddWithValue("@zid", _zid);
                            //    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            //    cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                            //    cmd.Parameters.AddWithValue("@xemail",
                            //        Convert.ToString(HttpContext.Current.Session["curuser"]));
                            //    cmd.Parameters.AddWithValue("@xsessionpro", xsessionpro1);
                            //    cmd.Parameters.AddWithValue("@xclasspro", xclasspro1);
                            //    cmd.Parameters.AddWithValue("@xgrouppro", xgrouppro1);
                            //    cmd.ExecuteNonQuery();


                            //}

                            DateTime ztime = DateTime.Now;
                            string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            xstatus1 = "New";
                            string xstatusin1 = "New";

                            string chk_in = zglobal.fnGetValue("xstatusin", "pratdummym",
                          "zid=" + _zid + " and xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                          "xcategory='" + xtype.Text.Trim().ToString()  + "' and xdate='" + xdate1 + "'");
                            if (chk_in != "New" && chk_in != "Undo" && chk_in != "Undo1" && chk_in != "")
                            {
                                xstatusin1 = chk_in;
                            }

                            string xstatusout1 = "New";

                            string chk_out = zglobal.fnGetValue("xstatusout", "pratdummym",
                          "zid=" + _zid + " AND xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                          "xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "'");
                            if (chk_out != "New" && chk_out != "Undo" && chk_out != "Undo1" && chk_out !="")
                            {
                                xstatusout1 = chk_out;
                            }



                            foreach (GridViewRow row in GridView1.Rows)
                            {

                                //int xline = zglobal.GetMaximumIdInt("xline", "ampromotiond", " zid=" + _zid + " and xrow=" + Convert.ToInt32(ViewState["xrow"]), "line");

                                CheckBox xisabsent = row.FindControl("chkIsAbsent") as CheckBox;
                                TextBox xstr01 = row.FindControl("txtInTime") as TextBox;
                                TextBox xstr02 = row.FindControl("txtOutTime") as TextBox;
                                TextBox xremarks = row.FindControl("txtRemarks") as TextBox;

                                string xisabsent1;
                                string xstatus11 = "";
                                if (xisabsent.Checked == true)
                                {
                                    xisabsent1 = "1";
                                }
                                else
                                {
                                    xisabsent1 = "0";
                                }

                                query = 
                                    "INSERT INTO pratdummym (ztime,zid,xemp,xdate,xstr01,xstr02,xstatus,xremarks,xlocation,xcategory,xstatusin,xstatusout,xisabsent,zemail) " +
                                    "VALUES(@ztime,@zid,@xemp,@xdate,@xstr01,@xstr02,@xstatus,@xremarks,@xlocation,@xcategory,@xstatusin,@xstatusout,@xisabsent,@zemail) ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ztime", _zid);
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", row.Cells[2].Text.ToString());
                                cmd.Parameters.AddWithValue("@xdate", xdate1);
                                cmd.Parameters.AddWithValue("@xstr01", xstr01.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xstr02", xstr02.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                                cmd.Parameters.AddWithValue("@xremarks", xremarks.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xlocation", xlocation.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xcategory", xtype.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xstatusin", xstatusin1);
                                cmd.Parameters.AddWithValue("@xstatusout", xstatusout1);
                                cmd.Parameters.AddWithValue("@xisabsent", xisabsent1);
                                cmd.Parameters.AddWithValue("@zemail", zemail);
                                cmd.ExecuteNonQuery();



                            }
                        }
                    }
                    else
                    {
                        message.InnerHtml = "No employee found.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
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
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " zid,xdate,xlocation,xcategory,max(xstatusin) as xstatusin,max(xstatusout) as xstatusout, max(xstatus) as xstatus " +
                         "FROM pratdummym WHERE zid=@zid AND xstatus='New' " +
                         "group by zid,xdate,xlocation,xcategory ";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvPromotedistNew.DataSource = tempTable;
                        dgvPromotedistNew.DataBind();
                    }
                    else
                    {
                        // btnShowList.Visible = false;
                        //pnllistct.Visible = false;
                        //GridView2.DataSource = null;
                        //GridView2.DataBind();
                        dgvPromotedistNew.DataSource = null;
                        dgvPromotedistNew.DataBind();
                    }


                }
            }


            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    string query =
                         "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " zid,xdate,xlocation,xcategory,max(xstatusin) as xstatusin,max(xstatusout) as xstatusout, max(xstatus) as xstatus " +
                         "FROM pratdummym WHERE zid=@zid AND xstatus='Confirmed' " +
                         "group by zid,xdate,xlocation,xcategory";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvPromotedistSubmitted.DataSource = tempTable;
                        dgvPromotedistSubmitted.DataBind();
                    }
                    else
                    {
                        // btnShowList.Visible = false;
                        //pnllistct.Visible = false;
                        //GridView2.DataSource = null;
                        //GridView2.DataBind();
                        dgvPromotedistSubmitted.DataSource = null;
                        dgvPromotedistSubmitted.DataBind();
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




        protected void FillControl(object sender, EventArgs e)
        {
            try
            {
                //LinkButton lb = (LinkButton)sender;
                //GridViewRow row = (GridViewRow)lb.NamingContainer;
                //if (row != null)
                //{
                //    int index = row.RowIndex; //gets the row index selected


                //    //xcttype.Text = GridView2.Rows[index].Cells[1].Text;
                //    //fnEventValue("xcttype", sender, e);

                //    //xctno.Text = GridView2.Rows[index].Cells[2].Text;
                //    //fnEventValue("xctno", sender, e);

                //    //xdate.Text = GridView2.Rows[index].Cells[3].Text;
                //    //fnEventValue("xdate", sender, e);




                //    //// xdate.Enabled = true;

                //    //btnRefresh_Click(sender, e);

                //    //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
                //    //{
                //    //    xreference_Click(sender, e);
                //    //}
                //}

                LinkButton lb = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lb.NamingContainer;
                int index = row.RowIndex;

                message.InnerHtml = "";

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                DateTime xdate1 = DateTime.ParseExact(((LinkButton) sender).Text.Trim().ToString(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);


                xdate.Text = xdate1.ToString("dd/MM/yyyy");
                xlocation.Text = dgvPromotedistNew.Rows[index].Cells[1].Text;
                xtype.Text = dgvPromotedistNew.Rows[index].Cells[2].Text;

                //string str = "SELECT  * FROM ampromotionh where zid=@zid  and xrow=@xrow ";





                //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //da.Fill(dts, "tempztcode");
                //DataTable dttemp = new DataTable();
                //dttemp = dts.Tables[0];

                //ViewState["xrow"] = xrow.ToString();
                //hiddenxrow.Value = ViewState["xrow"].ToString();

                //xsession.Text = dttemp.Rows[0]["xsession"].ToString();
                //xclass.Text = dttemp.Rows[0]["xclass"].ToString();
                //xgroup.Text = dttemp.Rows[0]["xgroup"].ToString();
                //xsection.Text = dttemp.Rows[0]["xsection"].ToString();
                //xsessionpro.Text = dttemp.Rows[0]["xsessionpro"].ToString();
                //xclasspro.Text = dttemp.Rows[0]["xclasspro"].ToString();
                //xgrouppro.Text = dttemp.Rows[0]["xgrouppro"].ToString();

                fnCheckRow();
                fnButtonState();
                BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void FillControl1(object sender, EventArgs e)
        {
            try
            {
                
                LinkButton lb = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lb.NamingContainer;
                int index = row.RowIndex;

                message.InnerHtml = "";

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                DateTime xdate1 = DateTime.ParseExact(((LinkButton)sender).Text.Trim().ToString(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);


                xdate.Text = xdate1.ToString("dd/MM/yyyy");
                xlocation.Text = dgvPromotedistSubmitted.Rows[index].Cells[1].Text;
                xtype.Text = dgvPromotedistSubmitted.Rows[index].Cells[2].Text ;

               
                fnCheckRow();
                fnButtonState();
                BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                DateTime xdate1 = xdate.Text.Trim() != string.Empty
                               ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                               : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                message.InnerText = "";
                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {

                        string xstatus1 = "";
                        if (ViewState["xrow"] != null)
                        {
                            xstatus1 = zglobal.fnGetValue("xstatus", "pratdummym",
                                  "zid=" + _zid + " AND xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "'");
                            if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                            {
                                message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                                message.Style.Value = zglobal.warningmsg;
                                return;
                            }
                        }

                        xstatus1 = zglobal.fnGetValue("xstatusin", "pratdummym",
                                  "zid=" + _zid + " AND xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString()  + "' and xdate='" + xdate1 + "'");
                        if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                        {
                            message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }


                        string chk_fpay = zglobal.fnGetValue("xflags", "prpay",
                             "zid=" + _zid + " AND xpaydate>='" + xdate1 + "' and xflags='1'");

                        if (chk_fpay != "")
                        {
                            message.InnerHtml = "Can't Save <br/>Final Payroll already Processed.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }

                        //btnSave_Click(sender, e);

                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xsubmitdt = DateTime.Now;
                                xstatus = "Confirmed";
                                string xflag10 = "";

                                string query = "";
                                //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                               


                                query =
                                    "UPDATE pratdummym SET xstatusin=@xstatus " +
                                    "WHERE zid=@zid AND  xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                                    "xcategory='" + xtype.Text.Trim().ToString()  + "' and xdate='" + xdate1 + "'";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.ExecuteNonQuery();

                                query =
                                     "insert into pratdummy(ztime,zid,xemp,xdate,xdesc,xref,xstatusjv,xpflag,xlocation,xcategory) " +
                                     "select '" + DateTime.Now + "','" + _zid + "',pratdummymvw.xemp,'" + xdate1 + "',pratdummymvw.xdesc01,'','1','Manually Attd.','" + xlocation.Text.ToString().Trim() + "', '" + xtype.Text.Trim().ToString()  + "' " +
						             "from pratdummymvw " +
                                     "WHERE zid=@zid AND  xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                                     "xcategory='" + xtype.Text.Trim().ToString()  + "' and xdate='" + xdate1 + "' and xisabsent=0";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.ExecuteNonQuery();

                                string xstatus11 = zglobal.fnGetValue("xstatusin", "pratdummym",
                              "zid=" + _zid + " AND xdate='" + xdate1 + "' and xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString()  + "'");

                                string xstatus22 = zglobal.fnGetValue("xstatusout", "pratdummym",
                                               "zid=" + _zid + " AND xdate='" + xdate1 + "' and xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString()  + "'");


                                if (xstatus11 == "Confirmed" && xstatus22 == "Confirmed")
                                {
                                    query =
                                    "UPDATE pratdummym SET xstatus=@xstatus " +
                                    "WHERE zid=@zid AND  xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                                    "xcategory='" + xtype.Text.Trim().ToString()  + "' and xdate='" + xdate1 + "'";
                                    cmd.Parameters.Clear();

                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                    cmd.ExecuteNonQuery();
                                }

                            }

                            tran.Complete();
                        }

                        message.InnerHtml = "<font color=blue>Confirmed Successfully</font>";
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "Approved";
                        hxstatus.Value = "Approved";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        hiddenxstatus.Value = "Approved";
                        fnButtonState();
                        BindGrid();
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

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                DateTime xdate1 = xdate.Text.Trim() != string.Empty
                               ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                               : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                message.InnerText = "";
                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue2.Value == "Yes")
                    {

                        string xstatus1 = "";
                        if (ViewState["xrow"] != null)
                        {
                            xstatus1 = zglobal.fnGetValue("xstatus", "pratdummym",
                                  "zid=" + _zid + " AND xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "'");
                            if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                            {
                                message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                                message.Style.Value = zglobal.warningmsg;
                                return;
                            }
                        }

                        xstatus1 = zglobal.fnGetValue("xstatusout", "pratdummym",
                                  "zid=" + _zid + " AND xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "'");
                        if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                        {
                            message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }


                        string chk_fpay = zglobal.fnGetValue("xflags", "prpay",
                             "zid=" + _zid + " AND xpaydate>='" + xdate1 + "' and xflags='1'");

                        if (chk_fpay != "")
                        {
                            message.InnerHtml = "Can't Save <br/>Final Payroll already Processed.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }

                        //btnSave_Click(sender, e);

                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xsubmitdt = DateTime.Now;
                                xstatus = "Confirmed";
                                string xflag10 = "";

                                string query = "";
                                //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));




                                query =
                                    "UPDATE pratdummym SET xstatusout=@xstatus " +
                                    "WHERE zid=@zid AND  xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                                    "xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "'";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.ExecuteNonQuery();

                                query =
                                     "insert into pratdummy(ztime,zid,xemp,xdate,xdesc,xref,xstatusjv,xpflag,xlocation,xcategory) " +
                                     "select '" + DateTime.Now + "','" + _zid + "',pratdummymvw.xemp,'" + xdate1 + "',pratdummymvw.xdesc02,'','0','Manually Attd.','" + xlocation.Text.ToString().Trim() + "', '" + xtype.Text.Trim().ToString() + "' " +
                                     "from pratdummymvw " +
                                     "WHERE zid=@zid AND  xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                                     "xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "' and xisabsent=0";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.ExecuteNonQuery();

                                string xstatus11 = zglobal.fnGetValue("xstatusin", "pratdummym",
                              "zid=" + _zid + " AND xdate='" + xdate1 + "' and xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString() + "'");

                                string xstatus22 = zglobal.fnGetValue("xstatusout", "pratdummym",
                                               "zid=" + _zid + " AND xdate='" + xdate1 + "' and xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString() + "'");


                                if (xstatus11 == "Confirmed" && xstatus22 == "Confirmed")
                                {
                                    query =
                                    "UPDATE pratdummym SET xstatus=@xstatus " +
                                    "WHERE zid=@zid AND  xlocation='" + xlocation.Text.ToString().Trim() + "' and " +
                                    "xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "'";
                                    cmd.Parameters.Clear();

                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                    cmd.ExecuteNonQuery();
                                }

                            }

                            tran.Complete();
                        }

                        message.InnerHtml = "<font color=blue>Confirmed Successfully</font>";
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "Approved";
                        hxstatus.Value = "Approved";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        hiddenxstatus.Value = "Approved";
                        fnButtonState();
                        BindGrid();
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                DateTime xdate1 = xdate.Text.Trim() != string.Empty
                               ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                               : DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                message.InnerText = "";
                //fnCheckRow();

                

                

                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xstatus;

                        string xstatus1 = "";
                        if (ViewState["xrow"] != null)
                        {
                            xstatus1 = zglobal.fnGetValue("xstatus", "pratdummym",
                                  "zid=" + _zid + " AND xlocation='" + xlocation.Text.ToString().Trim() + "' and xcategory='" + xtype.Text.Trim().ToString() + "' and xdate='" + xdate1 + "'");
                            if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                            {
                                message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                                message.Style.Value = zglobal.warningmsg;
                                return;
                            }
                        }


                        string chk_fpay = zglobal.fnGetValue("xflags", "prpay",
                             "zid=" + _zid + " AND xpaydate>='" + xdate1 + "' and xflags='1'");

                        if (chk_fpay != "")
                        {
                            message.InnerHtml = "Can't Save <br/>Final Payroll already Processed.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }


                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM pratdummy WHERE zid=@zid AND xlocation=@xlocation and xcategory=@xcategory and xdate=@xdate and xpflag='Manually Attd.' ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xlocation", xlocation.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xcategory", xtype.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xdate", xdate1);
                                cmd.ExecuteNonQuery();

                                query = "DELETE FROM pratdummym WHERE zid=@zid AND xlocation=@xlocation and xcategory=@xcategory and xdate=@xdate ";
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
                        //fnCheckRow();
                        ViewState["xrow"] = null;
                        fnButtonState();
                        BindGrid();
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


                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnRefresh1_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";




                fnCheckRow();





                BindGrid();
                //    fnFillGrid2();

                fnButtonState();

                //                if (ViewState["xrow"] == null)
                //                {
                //                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //                    {
                //                        using (DataSet dts1 = new DataSet())
                //                        {
                //                            string query = @"select zid,xsession,xclass,xclassconf from
                //(
                //select zid,xsession,xstdid,xname,xclass,xcodealt, codealt1,
                //                    (select xcode from mscodesam where zid=tbl.zid and xtype='Class' and cast(xcodealt as int)=codealt1)   as xclassconf
                //                    from 
                //                    (
                //                    select zid,xsession,xstdid,xname,xclass, (select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as xcodealt,
                //                    case when cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int) =
                //                    (select max(cast(xcodealt as int)) from mscodesam where zid=a.zid and xtype='Class'  ) 
                //                    then   cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int) else
                //                     cast((select xcodealt from mscodesam where zid=a.zid and xtype='Class'  and xcode=a.xclass) as int)+1 end as codealt1
                //                     from amstudentvw as a 
                //                     )tbl
                //					 )tbl1
                //where zid=@zid and xsession=@xsession and xclass=@xclass
                //					 group by zid,xsession,xclass,xclassconf
                //                     ";

                //                            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                //                            da1.SelectCommand.Parameters.AddWithValue("zid", Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
                //                            da1.SelectCommand.Parameters.AddWithValue("xsession", xsession.Text.ToString().Trim());
                //                            da1.SelectCommand.Parameters.AddWithValue("xclass", xclass.Text.ToString().Trim());
                //                            da1.Fill(dts1, "tblamadmisd");
                //                            amexamd = dts1.Tables[0];
                //                            if (amexamd.Rows.Count > 0)
                //                            {
                //                                xclasspro.Text = amexamd.Rows[0]["xclassconf"].ToString();
                //                            }
                //                            else
                //                            {
                //                                xclasspro.Text = "";
                //                            }
                //                        }

                //                    }

                //                    xsessionpro.Text = zglobal.fnDefaults("xsessiononline", "Student");
                //                }

                //  Response.Redirect(Request.RawUrl);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }




    }
}