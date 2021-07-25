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
    public partial class amattninput : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            //if (ViewState["xrow"] == null)
            //{
            //    btnSubmit.Enabled = false;
            //    btnSubmit1.Enabled = false;
            //    btnPrint.Enabled = false;
            //    btnPrint1.Enabled = false;
            //    btnSave.Enabled = true;
            //    btnSave1.Enabled = true;
            //    btnDelete.Enabled = true;
            //    btnDelete1.Enabled = true;
            //    //dxstatus.Visible = false;
            //    dxstatus.Text = "-";
            //}
            //else
            //{
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    string xstatus1 = zglobal.fnGetValue("xstatus", "hrgrowthh",
            //                   "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    //dxstatus.Visible = true;
            //    if (xstatus1 == "New" || xstatus1 == "Undo")
            //    {
            //        btnSubmit.Enabled = true;
            //        btnSubmit1.Enabled = true;
            //        btnPrint.Enabled = false;
            //        btnPrint1.Enabled = false;
            //        btnSave.Enabled = true;
            //        btnSave1.Enabled = true;
            //        btnDelete.Enabled = true;
            //        btnDelete1.Enabled = true;
            //        dxstatus.Text = xstatus1;
            //        hxstatus.Value = xstatus1;
            //        dxstatus.Style.Value = zglobal.am_new;

            //    }
            //    else
            //    {
            //        btnSubmit.Enabled = false;
            //        btnSubmit1.Enabled = false;
            //        btnPrint.Enabled = true;
            //        btnPrint1.Enabled = true;
            //        btnSave.Enabled = false;
            //        btnSave1.Enabled = false;
            //        btnDelete.Enabled = false;
            //        btnDelete1.Enabled = false;
            //        dxstatus.Text = xstatus1;
            //        hxstatus.Value = xstatus1;
            //        dxstatus.Style.Value = zglobal.am_submited;


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
                    zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Test Type", xcttype);
                    //zglobal.fnGetComboDataCD("Observation Action", xaction);

                    zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    ViewState["xrow"] = null;
                    hiddenxrow.Value = "";
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";
                    _xpeer.Value = "";
                    _xteacher.Value = "";
                    xdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    fnButtonState();
                    //btnShowList.Visible = false;
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

                    //xobserno.Items.Add("");
                    //for (int i = 1; i <= 5; i++)
                    //{
                    //    xobserno.Items.Add(i.ToString());
                    //}
                    //xobserno.Text = "";

                    //xhour.Items.Add("H");
                    //for (int i = 1; i <= 3; i++)
                    //{
                    //    xhour.Items.Add(i.ToString());
                    //}
                    //xhour.Text = "H";

                    //xminitue.Items.Add("M");
                    //for (int i = 5; i <= 55; i = i + 5)
                    //{
                    //    xminitue.Items.Add(i.ToString());
                    //}
                    //xminitue.Text = "M";

                    _gridrow.Text = zglobal._grid_row_value;
                    _gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();

                }


                //GridViewHelper helper = new GridViewHelper(GridView1);
                //helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                //helper.RegisterGroup("xcat", true, true);
                //helper.ApplyGroupSort();

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
            foreach (GridViewRow row in dgvOBListNew.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            foreach (GridViewRow row in dgvOBListSubmitted.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }
        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            row.BackColor = Color.Gray;
            row.Cells[0].ForeColor = Color.White;
            row.Cells[0].Attributes.Add("style","padding-left:30px");
            //Color.FromArgb(236, 236, 236);
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        private void BindGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string xsession1 = xsession.Text.Trim().ToString();
            string xterm1 = xterm.Text.Trim().ToString();
            string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            string xsection1 = xsection.Text.Trim().ToString();

            string str = "";


            str = "select ROW_NUMBER() OVER (ORDER BY xname) AS xid,xrow,xstdid,xname FROM amstudentvw " +
                  "WHERE zid=@zid AND xsession=@xsession and xclass=@xclass and xsection=@xsection order by xname ";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {
                _abbr.Visible = true;
                GridView1.Columns.Clear();


                bfield = new BoundField();
                bfield.HeaderText = "No.";
                bfield.DataField = "xid";
                bfield.ItemStyle.Width = 35;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "ID";
                bfield.DataField = "xstdid";
                bfield.ItemStyle.Width = 70;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "Students' Name";
                bfield.DataField = "xname";
                bfield.ItemStyle.Width = 250;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                GridView1.Columns.Add(bfield);


                //TemplateField tfield119 = new TemplateField();
                //tfield119.HeaderText = "Stages";
                //tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                //tfield119.ItemStyle.Width = 450;
                //GridView1.Columns.Add(tfield119);



                tfield = new TemplateField();
                tfield.HeaderText = "P";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield.ItemStyle.Width = 30;
                GridView1.Columns.Add(tfield);


                tfield = new TemplateField();
                tfield.HeaderText = "A";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield.ItemStyle.Width = 30;
                GridView1.Columns.Add(tfield);

                tfield = new TemplateField();
                tfield.HeaderText = "LT";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield.ItemStyle.Width = 30;
                GridView1.Columns.Add(tfield);

                //tfield = new TemplateField();
                //tfield.HeaderText = "L";
                //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield.ItemStyle.Width = 30;
                //GridView1.Columns.Add(tfield);



                TemplateField tfield1 = new TemplateField();
                tfield1.HeaderText = "Remarks";
                tfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield1.ItemStyle.Width = Unit.Pixel(350);
                GridView1.Columns.Add(tfield1);


                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield2.ItemStyle.Width = Unit.Pixel(30);
                GridView1.Columns.Add(tfield2);

                //BoundField bfield1 = new BoundField();
                //bfield1.DataField = "xcat";
                //GridView1.Columns.Add(bfield1);

                BoundField bfield2 = new BoundField();
                bfield2.DataField = "xrow";
                GridView1.Columns.Add(bfield2);

                if (ViewState["xrow"] != null)
                {
                    //using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    //{
                    //    using (DataSet dts1 = new DataSet())
                    //    {
                    //        string query = "SELECT * FROM hrgrowthd WHERE zid=@zid AND xrow=@xrow";
                    //        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                    //        da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
                    //        da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
                    //        da1.Fill(dts1, "tblamadmisd");
                    //        //tblamadmisd = new DataTable();
                    //        amexamd = dts1.Tables[0];
                    //    }
                    //}


                    //string xstatus1 = zglobal.fnGetValue("xstatus", "hrgrowthh",
                    //       "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                    //ViewState["xstatus"] = xstatus1;
                    //hxstatus.Value = xstatus1;
                }
                else
                {
                    //hxstatus.Value = "";
                }


                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                             "SELECT * FROM amattnspvw WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass and xsection=@xsection and xdate=@xdate";
                        

                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);

                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        DateTime xdate1 = xdate.Text.Trim() != string.Empty
                            ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                                CultureInfo.InvariantCulture)
                            : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        da1.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                        da1.Fill(dts1, "tblamadmisd");
                        amexamd = dts1.Tables[0];
                        if (amexamd.Rows.Count > 0)
                        {
                            ViewState["xst"] = amexamd;
                        }
                        else
                        {
                            ViewState["xst"] = null;
                        }
                    }
                }

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();


                //bfield1.Visible = false;
                bfield2.Visible = false;

                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    RadioButton rdopresent = (RadioButton)row.FindControl("rdopresent");
                //    RadioButton rdoabsent = (RadioButton)row.FindControl("rdoabsent");
                //    RadioButton rdolate = (RadioButton)row.FindControl("rdolate");
                //    RadioButton rdoleave = (RadioButton)row.FindControl("rdoleave");
                //    rdopresent.Checked = true;

                //    if (rdoleave.Checked)
                //    {
                //        rdoleave.BackColor = Color.Blue;
                //    }
                //    else
                //    {
                //        rdoleave.BackColor = Color.Silver;
                //    }

                //    if (rdolate.Checked)
                //    {
                //        rdolate.BackColor = Color.Yellow;
                //    }
                //    else
                //    {
                //        rdolate.BackColor = Color.Silver;
                //    }

                //    if (rdoabsent.Checked)
                //    {
                //        rdoabsent.BackColor = Color.Red;
                //    }
                //    else
                //    {
                //        rdoabsent.BackColor = Color.Silver;
                //    }

                //    if (rdopresent.Checked)
                //    {
                //        rdopresent.BackColor = Color.Green;
                //    }
                //    else
                //    {
                //        rdopresent.BackColor = Color.Silver;
                //    }
                //}

                //if (ViewState["xrow"] == null)
                //{
                //    foreach (GridViewRow row in GridView1.Rows)
                //    {
                //        RadioButton rdopresent = (RadioButton)row.FindControl("rdopresent");
                //        rdopresent.Checked = true;
                //    }
                //}

            }
            else
            {
                _abbr.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

        }

        TextBox txTextBox;

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

                    HtmlGenericControl lbl = new HtmlGenericControl("label");
                    lbl.Attributes.Add("class", "container");
                    e.Row.Cells[3].Controls.Add(lbl);

                    RadioButton rdoyes = new RadioButton();
                    rdoyes.ID = "rdopresent";
                    rdoyes.GroupName = "xcom" + (e.Row.DataItem as DataRowView).Row["xid"].ToString();
                    //rdoyes.BackColor = Color.Silver;
                    //rdoyes.CheckedChanged += new EventHandler(rdoyes_CheckedChanged);
                    //rdoyes.AutoPostBack = true;
                    //rdoyes.CssClass = "borrad";
                    rdoyes.Checked = true;
                    //e.Row.Cells[3].Controls.Add(rdoyes);
                    lbl.Controls.Add(rdoyes);

                    HtmlGenericControl spn = new HtmlGenericControl("span");
                    spn.Attributes.Add("class", "checkmark");
                    lbl.Controls.Add(spn);

                    HtmlGenericControl lbl1 = new HtmlGenericControl("label");
                    lbl1.Attributes.Add("class", "container");
                    e.Row.Cells[4].Controls.Add(lbl1);

                    RadioButton rdono = new RadioButton();
                    rdono.ID = "rdoabsent";
                    rdono.GroupName = "xcom" + (e.Row.DataItem as DataRowView).Row["xid"].ToString();
                    //rdono.BackColor = Color.Silver;
                    //rdono.CheckedChanged += new EventHandler(RdonoOnCheckedChanged);
                    //rdono.AutoPostBack = true;
                    //rdono.CssClass = "borrad";
                    //e.Row.Cells[4].Controls.Add(rdono);
                    //rdono.Checked = true;
                    lbl1.Controls.Add(rdono);

                    HtmlGenericControl spn1 = new HtmlGenericControl("span");
                    spn1.Attributes.Add("class", "checkmark1");
                    lbl1.Controls.Add(spn1);

                    HtmlGenericControl lbl2 = new HtmlGenericControl("label");
                    lbl2.Attributes.Add("class", "container");
                    e.Row.Cells[5].Controls.Add(lbl2);

                    RadioButton rdona = new RadioButton();
                    rdona.ID = "rdolate";
                    rdona.GroupName = "xcom" + (e.Row.DataItem as DataRowView).Row["xid"].ToString();
                    //rdona.BackColor = Color.Silver;
                    //rdona.CheckedChanged += new EventHandler(rdona_CheckedChanged);
                    //rdona.AutoPostBack = true;
                    //rdona.CssClass = "borrad";
                    //e.Row.Cells[5].Controls.Add(rdona);
                    lbl2.Controls.Add(rdona);

                    HtmlGenericControl spn2 = new HtmlGenericControl("span");
                    spn2.Attributes.Add("class", "checkmark2");
                    lbl2.Controls.Add(spn2);

                    //HtmlGenericControl lbl3 = new HtmlGenericControl("label");
                    //lbl3.Attributes.Add("class", "container");
                    //e.Row.Cells[6].Controls.Add(lbl3);

                    //RadioButton rdona1 = new RadioButton();
                    //rdona1.ID = "rdoleave";
                    //rdona1.GroupName = "xcom" + (e.Row.DataItem as DataRowView).Row["xid"].ToString();
                    ////rdona1.BackColor = Color.Silver;
                    ////rdona1.CheckedChanged += new EventHandler(rdona1_CheckedChanged);
                    ////rdona1.AutoPostBack = true;
                    ////rdona1.CssClass = "borrad";
                    ////e.Row.Cells[6].Controls.Add(rdona1);
                    //lbl3.Controls.Add(rdona1);

                    //HtmlGenericControl spn3 = new HtmlGenericControl("span");
                    //spn3.Attributes.Add("class", "checkmark3");
                    //lbl3.Controls.Add(spn3);

                    TextBox txtComments = new TextBox();
                    txtComments.ID = "txtremarks";
                    txtComments.CssClass = "bm_academic_textbox_grid1 bm_academic_ctl_global";
                    txtComments.TextMode = TextBoxMode.MultiLine;
                    txtComments.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[6].Controls.Add(txtComments);

                    //HtmlGenericControl image = new HtmlGenericControl("img");
                    //image.ID = "image2";
                    //image.Attributes.Add("src", "/images/list-am16x16.png");
                    //image.Attributes.Add("class", "bm_academic_list1 bm_list");
                    //image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
                    //e.Row.Cells[6].Controls.Add(image);

                    //Label lblxdesc = new Label();
                    //lblxdesc.ID = "xdesc";
                    //lblxdesc.Text = (e.Row.DataItem as DataRowView).Row["xdesc"].ToString();
                    //e.Row.Cells[1].Controls.Add(lblxdesc);

                    //rdoyes.Checked = true;

                    //if (ViewState["xrow"] != null)
                    //{
                    //    if (Convert.ToString(ViewState["xstatus"]) != "New" && Convert.ToString(ViewState["xstatus"]) != "Undo" && Convert.ToString(ViewState["xstatus"]) != "Undo1")
                    //    {
                    //        txtComments.Enabled = false;
                    //        rdoyes.Enabled = false;
                    //        rdono.Enabled = false;
                    //        rdona.Enabled = false;
                    //    }



                        if (amexamd.Rows.Count > 0)
                        {
                            foreach (DataRow row in amexamd.Rows)
                            {
                                if (row["xstdid"].ToString() == (e.Row.DataItem as DataRowView).Row["xstdid"].ToString())
                                {

                                    if (row["xstatus"].ToString() == "P")
                                    {
                                        rdoyes.Checked = true;
                                        rdono.Checked = false;
                                        rdona.Checked = false;
                                    }
                                    else if (row["xstatus"].ToString() == "A")
                                    {
                                        rdoyes.Checked = false;
                                        rdono.Checked = true;
                                        rdona.Checked = false;
                                    }
                                    else //if (row["xstatus"].ToString() == "LT")
                                    {
                                        rdoyes.Checked = false;
                                        rdono.Checked = false;
                                        rdona.Checked = true;
                                    }
                                    //else
                                    //{
                                    //    rdoyes.Checked = true;
                                    //    rdono.Checked = false;
                                    //    rdona.Checked = false;
                                    //}

                                    txtComments.Text = row["xremarks"].ToString();

                                    break;
                                }
                            }
                        }


                    //}

                    //if (rdona1.Checked)
                    //{
                    //    rdona1.BackColor = Color.Blue;
                    //}
                    //else
                    //{
                    //    rdona1.BackColor = Color.Silver;
                    //}

                    //if (rdona.Checked)
                    //{
                    //    rdona.BackColor = Color.Yellow;
                    //}
                    //else
                    //{
                    //    rdona.BackColor = Color.Silver;
                    //}

                    //if (rdono.Checked)
                    //{
                    //    rdono.BackColor = Color.Red;
                    //}
                    //else
                    //{
                    //    rdono.BackColor = Color.Silver;
                    //}

                    //if (rdoyes.Checked)
                    //{
                    //    rdoyes.BackColor = Color.Green;
                    //}
                    //else
                    //{
                    //    rdoyes.BackColor = Color.Silver;
                    //}

                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        void rdona1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;

            if (rdo.Checked)
            {
                rdo.BackColor = Color.Blue;
            }
            else
            {
                rdo.BackColor = Color.Silver;
            }
        }

        void rdona_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;

            if (rdo.Checked)
            {
                rdo.BackColor = Color.Yellow;
            }
            else
            {
                rdo.BackColor = Color.Silver;
            }
        }

        private void RdonoOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RadioButton rdo = (RadioButton)sender;

            if (rdo.Checked)
            {
                rdo.BackColor = Color.Red;
            }
            else
            {
                rdo.BackColor = Color.Silver;
            }
        }

        void rdoyes_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;

            if (rdo.Checked)
            {
                rdo.BackColor = Color.Green;
            }
            else
            {
                rdo.BackColor = Color.Silver;
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
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {
                    con.Open();
                    string query;

                    //if (xctno.Text != "")
                    //{
                    //    query =
                    //    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno AND xdate=@xdate";
                    //}
                    //else
                    // {
                    query =
                        //"SELECT * FROM hrgrowthh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass  AND xgroup=@xgroup   AND xsection=@xsection AND xsubject=@xsubject AND xobserno=@xobserno AND xteacher=@xteacher";
                    //"SELECT * FROM amattnspvw WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass and xsection=@xsection and xdate=@xdate";
                    "SELECT * FROM amattnspvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass and xsection=@xsection and xdate=@xdate";
                    // }

                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                    //da.SelectCommand.Parameters.AddWithValue("@xobserno", Int32.Parse(xobserno.Text.ToString().Trim()));
                    //da.SelectCommand.Parameters.AddWithValue("@xteacher", _xteacher.Value.ToString().Trim());
                    DateTime xdate1 = xdate.Text.Trim() != string.Empty
                                ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


                    DataTable tempTable = new DataTable();
                    da.Fill(dts, "tempTable");
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        if (tempTable.Rows[0]["xterm"].ToString() != xterm.Text.ToString().Trim())
                        {
                            ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
                            ViewState["xvalues"] = "Record found on the same date in the " +
                                                   tempTable.Rows[0]["xclass"].ToString() + " " +
                                                   tempTable.Rows[0]["xterm"].ToString() +
                                                   " term. Can't insert a duplicate record in the same date and same class.";
                            hiddenxrow.Value = ViewState["xrow"].ToString();
                        }
                        else
                        {
                            ViewState["xrow"] = null;
                            hiddenxrow.Value = "";
                        }
                    }
                    else
                    {
                        ViewState["xrow"] = null;
                        hiddenxrow.Value = "";
                    }


                }
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
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
                if (xterm.Text == "" || xterm.Text == string.Empty || xterm.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Term</li>";
                    isValid = false;
                }
                if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Class</li>";
                    isValid = false;
                }
                if (xsection.Text == "" || xsection.Text == string.Empty || xsection.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Section</li>";
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

                if (ViewState["xrow"] != null)
                {
                    message.InnerHtml = ViewState["xvalues"].ToString();
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                string xstatus1 = "";

                DateTime zutime = DateTime.Now;
                DateTime ztime = DateTime.Now;
                DateTime xdate1 = xdate.Text.Trim() != string.Empty
                                ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

                using (TransactionScope tran = new TransactionScope())
                {
                    if (GridView1.Rows.Count > 0)
                    {
                        
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;

                            foreach (GridViewRow row in GridView1.Rows)
                            {


                                TextBox txtTextBox2 = row.FindControl("txtremarks") as TextBox;
                                
                                Label lblxdesc = row.FindControl("xdesc") as Label;

                                RadioButton rdopresent = row.FindControl("rdopresent") as RadioButton;
                                RadioButton rdoabsent = row.FindControl("rdoabsent") as RadioButton;
                                RadioButton rdolate = row.FindControl("rdolate") as RadioButton;

                                string xstatus123 = "";
                                if (rdopresent.Checked)
                                {
                                    xstatus123 = "P";
                                }
                                else if (rdoabsent.Checked)
                                {
                                    xstatus123 = "A";
                                }
                                //else if (rdonaa.Checked)
                                //{
                                //    xstatus123 = "N/A";
                                //}
                                else
                                {
                                    xstatus123 = "LT";
                                }

                                string query =
                                "IF EXISTS(SELECT * FROM amattn WHERE zid=@zid AND xsession=@xsession AND xstdid=@xstdid AND xdate=@xdate AND xterm=@xterm AND xtype=@xtype) " +
                                "UPDATE amattn SET zutime=@zutime,xstatus=@xstatus,xemail=@xemail,xremarks=@xremarks " +
                                "WHERE zid=@zid AND xsession=@xsession AND xstdid=@xstdid AND xdate=@xdate " +
                                "ELSE " +
                                "INSERT INTO amattn (ztime,zid,xrow,xstdid,xsession,xdate,xstatus,zemail,xterm,xtype,xremarks) " +
                                "VALUES(@ztime,@zid,@xrow,@xstdid,@xsession,@xdate,@xstatus,@zemail,@xterm,@xtype,@xremarks) ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xstdid", row.Cells[1].Text.ToString());
                                cmd.Parameters.AddWithValue("@xdate", xdate1);
                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xtype", "Attendance");
                                cmd.Parameters.AddWithValue("@zutime", zutime);
                                cmd.Parameters.AddWithValue("@ztime", ztime);
                                cmd.Parameters.AddWithValue("@xstatus", xstatus123);
                                cmd.Parameters.AddWithValue("@xemail", xemail);
                                cmd.Parameters.AddWithValue("@zemail", zemail);
                                cmd.Parameters.AddWithValue("@xremarks", txtTextBox2.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xrow", zglobal.GetMaximumIdInt("xrow", "amattn", " zid=" + _zid, 1, 1));
                                cmd.ExecuteNonQuery();
                                //}

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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    //int xrow = int.Parse(ViewState["xrow"].ToString());
            //    //int xline1 = 0;
            //    //message.InnerHtml = "";

            //    //using (TransactionScope tran = new TransactionScope())
            //    //{
            //    //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //    //    {

            //    //        using (DataSet dts = new DataSet())
            //    //        {

            //    //            DateTime xdate2 = Convert.ToDateTime(_xdate.Value);
            //    //            string xperiod2 = _xperiod.Value;
            //    //            string xsection2 = _xsection.Value;

            //    //            string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
            //    //            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
            //    //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
            //    //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
            //    //            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
            //    //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            //    //            da.Fill(dts, "tempTable");
            //    //            DataTable tempTable = new DataTable();
            //    //            tempTable = dts.Tables["tempTable"];

            //    //            if (tempTable.Rows.Count > 0)
            //    //            {
            //    //                xline1 = Convert.ToInt32(tempTable.Rows[0][0].ToString());
            //    //            }


            //    //            da.Dispose();
            //    //        }


            //    //        conn.Open();
            //    //        SqlCommand cmd = new SqlCommand();
            //    //        cmd.Connection = conn;


            //    //        //if (xline1 != 0)
            //    //        //{
            //    //        //    string query2 = "DELETE FROM amexamschd WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
            //    //        //    cmd.Parameters.Clear();
            //    //        //    cmd.CommandText = query2;
            //    //        //    cmd.Parameters.AddWithValue("@zid", _zid);
            //    //        //    cmd.Parameters.AddWithValue("@xrow", xrow);
            //    //        //    cmd.Parameters.AddWithValue("@xline", xline1);
            //    //        //    cmd.ExecuteNonQuery();
            //    //        //}


            //    //        DateTime ztime = DateTime.Now;
            //    //        DateTime zutime = DateTime.Now;
            //    //        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    //        int xline = zglobal.GetMaximumIdInt("xline", "amexamschd", " zid=" + _zid + " and xrow=" + xrow, "line");
            //    //        string xsubject1 = "";
            //    //        string xpaper1 = "";
            //    //        DateTime xdate1 = DateTime.Now;
            //    //        string xsection1 = "";
            //    //        string xcperiod1 = "";
            //    //        string xcteacher1 = "";
            //    //        string xsteacher1 = "";
            //    //        string xtopic1 = "";
            //    //        string xdetails1 = "";
            //    //        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //    //        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

            //    //        string query;
            //    //        if (xline1 != 0)
            //    //        {
            //    //            query = "UPDATE amexamschd SET zutime=@zutime, xsubject=@xsubject, xpaper=@xpaper, xtopic=@xtopic, xdetails=@xdetails, xcteacher=@xcteacher, xsteacher=@xsteacher, xemail=@xemail WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
            //    //            xline = xline1;
            //    //        }
            //    //        else
            //    //        {
            //    //            query = "INSERT INTO amexamschd (ztime,zid,xrow,xline,xsubject,xpaper,xdate,xsection,xcperiod,xcteacher,xsteacher,xtopic,xdetails,zemail) " +
            //    //                   "VALUES(@ztime,@zid,@xrow,@xline,@xsubject,@xpaper,@xdate,@xsection,@xcperiod,@xcteacher,@xsteacher,@xtopic,@xdetails,@zemail) ";
            //    //        }


            //    //        xsubject1 = xsubject.Text.ToString().Trim();
            //    //        xpaper1 = xpaper.Text.Trim().ToString();
            //    //        xdate1 = Convert.ToDateTime(_xdate.Value.ToString());
            //    //        xsection1 = _xsection.Value.ToString();
            //    //        xcperiod1 = _xperiod.Value.ToString();
            //    //        xcteacher1 = _classteacher.Value.ToString();
            //    //        xsteacher1 = _subteacher.Value.ToString();
            //    //        xtopic1 = xtopic.Value.Trim().ToString();
            //    //        xdetails1 = xdetails.Value.Trim().ToString();

            //    //        cmd.CommandText = query;
            //    //        cmd.Parameters.Clear();
            //    //        cmd.Parameters.AddWithValue("@ztime", ztime);
            //    //        cmd.Parameters.AddWithValue("@zutime", ztime);
            //    //        cmd.Parameters.AddWithValue("@zid", _zid);
            //    //        cmd.Parameters.AddWithValue("@xrow", xrow);
            //    //        cmd.Parameters.AddWithValue("@xline", xline);
            //    //        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
            //    //        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
            //    //        cmd.Parameters.AddWithValue("@xdate", xdate1);
            //    //        cmd.Parameters.AddWithValue("@xsection", xsection1);
            //    //        cmd.Parameters.AddWithValue("@xcperiod", xcperiod1);
            //    //        cmd.Parameters.AddWithValue("@xcteacher", xcteacher1);
            //    //        cmd.Parameters.AddWithValue("@xsteacher", xsteacher1);
            //    //        cmd.Parameters.AddWithValue("@xtopic", xtopic1);
            //    //        cmd.Parameters.AddWithValue("@xdetails", xdetails1);
            //    //        cmd.Parameters.AddWithValue("@zemail", zemail);
            //    //        cmd.Parameters.AddWithValue("@xemail", xemail);
            //    //        //if (xsubject.Text != "" && xpaper.Text != "")
            //    //        //{
            //    //            cmd.ExecuteNonQuery();
            //    //        //}


            //    //    }

            //    //    tran.Complete();

            //    //}




            //    //if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
            //    //{
            //    //    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
            //    //    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

            //    //    BindGrid(year, month);
            //    //}
            //    //else
            //    //{
            //    //    BindGrid(1999, 1);
            //    //}
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void fnFillDataGrid(object sender, EventArgs e)
        {
            //try
            //{
            //    ////System.Threading.Thread.Sleep(1000);
            //    //message.InnerHtml = "";


            //    //if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
            //    //{
            //    //    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
            //    //    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

            //    //    BindGrid(year, month);
            //    //}
            //    //else
            //    //{
            //    //    BindGrid(1999, 1);
            //    //    //GridView1.DataSource = null;
            //    //    //GridView1.DataBind();
            //    //}



            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
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

            //string xrole = zglobal.fnGetValue("xrole", "ztuser",
            //            " xuser='" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "'");
            //bool xshowall = false;

            //if (Convert.ToString(HttpContext.Current.Session["curuser"]) == "bm")
            //{
            //    xshowall = true;
            //}
            //else if (xrole == "Director" || xrole == "Super Admin" || xrole == "Director L-A" || xrole == "Director L-B" || xrole == "Vice Principals")
            //{
            //    xshowall = true;
            //}
            //else
            //{
            //    xshowall = false;
            //}

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();



                    string query = "";

                    //if (!xshowall)
                    //{
                    //    query =
                    //        "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) +
                    //        " xrow,xsession,xclass,xgroup,xsection,xsubject,xobserno,xdate, " +
                    //        " (select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xpeer) as xpeer, " +
                    //        "(select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xteacher) as xteacher " +
                    //        "FROM hrgrowthh WHERE zid=@zid AND xtype='Teachers' AND xstatus='New' and zemail=@zemail order by xrow desc";
                    //}
                    //else
                    //{
                    //    query =
                    //        "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) +
                    //        " xrow,xsession,xclass,xgroup,xsection,xsubject,xobserno,xdate, " +
                    //        " (select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xpeer) as xpeer, " +
                    //        "(select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xteacher) as xteacher " +
                    //        "FROM hrgrowthh WHERE zid=@zid AND xtype='Teachers' AND xstatus='New' order by xrow desc";
                    //}

                    query =
                            "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) +
                            " zid,xsession,xterm,xclass,xsection,xdate " +
                            "FROM amattnspvw WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass and xsection=@xsection and xtype='Attendance' " +
                            "group by zid,xsession,xterm,xclass,xsection,xdate " +
                            "order by xsession,xdate desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvOBListNew.DataSource = tempTable;
                        dgvOBListNew.DataBind();
                    }
                    else
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvOBListNew.DataSource = null;
                        dgvOBListNew.DataBind();
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

            //        string query = "";

            //        if (!xshowall)
            //        {
            //            query =
            //             "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xrow,xsession,xclass,xgroup,xsection,xsubject,xobserno,xdate, " +
            //             " (select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xpeer) as xpeer, " +
            //             "(select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xteacher) as xteacher " +
            //             "FROM hrgrowthh WHERE zid=@zid AND xtype='Teachers' AND xstatus='Submited' and zemail=@zemail order by xrow desc";
            //        }
            //        else
            //        {
            //            query =
            //             "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xrow,xsession,xclass,xgroup,xsection,xsubject,xobserno,xdate, " +
            //             " (select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xpeer) as xpeer, " +
            //             "(select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xteacher) as xteacher " +
            //             "FROM hrgrowthh WHERE zid=@zid AND xtype='Teachers' AND xstatus='Submited'  order by xrow desc";
            //        }

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));



            //        DataTable tempTable = new DataTable();
            //        da1.Fill(dts1, "tempTable");
            //        tempTable = dts1.Tables["tempTable"];

            //        if (tempTable.Rows.Count > 0)
            //        {
            //            // btnShowList.Visible = true;
            //            //pnllistct.Visible = true;
            //            dgvOBListSubmitted.DataSource = tempTable;
            //            dgvOBListSubmitted.DataBind();
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
            //    hiddenxrow.Value = "";
            //    //fnGetScheduleDate();


            //    xaction.Text = "";
            //    xobserno.Text = "";
            //    xdate.Text = "";
            //    xlearnerno.Text = "";
            //    xhour.Text = "H";
            //    xminitue.Text = "M";
            //    xaim.Value = "";
            //    xremarks.Value = "";
            //    //xcteacher.Text = "-";
            //    xpeer.Text = "";
            //    //xsteacher.Text = "-";
            //    xteacher.Text = "";
            //    dxstatus.Text = "-";
            //    fnButtonState();
            //    _xpeer.Value = "";
            //    _xteacher.Value = "";

            //    //fnFillGrid2();
            //    //zglobal.fnComboBoxValueWithItem(xreference, "(xcttype + '-' + xctno) as xtext,(xcttype + '|' + xctno) as xvalue", "amexamh", "zid=" + _zid + " and xsession='" + xsession.Text + "' and xterm='" + xterm.Text +
            //    //     "' and xclass='" + xclass.Text + "' and xgroup='" + xgroup.Text + "' and xsection='" + xsection.Text + "' and xsubject='" + xsubject.Text + "' and xpaper='" + xpaper.Text + "' and coalesce(xext,'')='" + xext.Text + "' and xtype='Class Test' and xcttype in ('Test','Test (WS)') order by xctno");


            //    //fnGetScheduleDate("comval");
            //    BindGrid();
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
            //try
            //{
            //    //LinkButton lb = (LinkButton)sender;
            //    //GridViewRow row = (GridViewRow)lb.NamingContainer;
            //    //if (row != null)
            //    //{
            //    //    int index = row.RowIndex; //gets the row index selected


            //    //    //xcttype.Text = GridView2.Rows[index].Cells[1].Text;
            //    //    //fnEventValue("xcttype", sender, e);

            //    //    //xctno.Text = GridView2.Rows[index].Cells[2].Text;
            //    //    //fnEventValue("xctno", sender, e);

            //    //    //xdate.Text = GridView2.Rows[index].Cells[3].Text;
            //    //    //fnEventValue("xdate", sender, e);




            //    //    //// xdate.Enabled = true;

            //    //    //btnRefresh_Click(sender, e);

            //    //    //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
            //    //    //{
            //    //    //    xreference_Click(sender, e);
            //    //    //}
            //    //}

            //    message.InnerHtml = "";

            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    DataSet dts = new DataSet();

            //    dts.Reset();


            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    string xsession = Convert.ToString(((LinkButton)sender).Text);

            //    string str = "SELECT  xsession,xclass,xgroup,xsection,xsubject,xext,xpaper,xaction,xobserno,xdate,xlearnerno,xhour,xminitue,xaim,xremarks,xpeer,xteacher, " +
            //                 "(select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xpeer) as xpeer1, " +
            //                 "(select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xteacher) as xteacher1 " +
            //                 "FROM hrgrowthh where zid=@zid  and xrow=@xrow ";





            //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
            //    da.Fill(dts, "tempztcode");
            //    DataTable dttemp = new DataTable();
            //    dttemp = dts.Tables[0];

            //    ViewState["xrow"] = xrow.ToString();
            //    hiddenxrow.Value = ViewState["xrow"].ToString();

            //    xsession.Text = dttemp.Rows[0]["xsession"].ToString();
            //    xclass.Text = dttemp.Rows[0]["xclass"].ToString();
            //    xgroup.Text = dttemp.Rows[0]["xgroup"].ToString();
            //    xsection.Text = dttemp.Rows[0]["xsection"].ToString();
            //    xsubject.Text = dttemp.Rows[0]["xsubject"].ToString();
            //    xext.Text = dttemp.Rows[0]["xext"].ToString();
            //    xpaper.Text = dttemp.Rows[0]["xpaper"].ToString();
            //    xaction.Text = dttemp.Rows[0]["xaction"].ToString();
            //    xobserno.Text = dttemp.Rows[0]["xobserno"].ToString();
            //    if (dttemp.Rows[0]["xdate"].Equals(DBNull.Value) == false)
            //    {
            //        if (Convert.ToDateTime(dttemp.Rows[0]["xdate"]).ToString("dd/MM/yyyy") != "01/01/1999" &&
            //            Convert.ToDateTime(dttemp.Rows[0]["xdate"]).ToString("dd/MM/yyyy") != "31/12/2999")
            //        {
            //            xdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
            //        }
            //    }
            //    xlearnerno.Text = dttemp.Rows[0]["xlearnerno"].ToString() == "0" ? "" : dttemp.Rows[0]["xlearnerno"].ToString();
            //    xhour.Text = dttemp.Rows[0]["xhour"].ToString() == "0" ? "H" : dttemp.Rows[0]["xhour"].ToString();
            //    xminitue.Text = dttemp.Rows[0]["xminitue"].ToString() == "0" ? "M" : dttemp.Rows[0]["xminitue"].ToString();
            //    xaim.Value = dttemp.Rows[0]["xaim"].ToString();
            //    xremarks.Value = dttemp.Rows[0]["xremarks"].ToString();
            //    _xpeer.Value = dttemp.Rows[0]["xpeer"].ToString();
            //    _xteacher.Value = dttemp.Rows[0]["xteacher"].ToString();
            //    xpeer.Text = dttemp.Rows[0]["xpeer1"].ToString();
            //    xteacher.Text = dttemp.Rows[0]["xteacher1"].ToString();

            //    //GridViewHelper helper = new GridViewHelper(GridView1);
            //    //helper.GroupHeader += new GroupEvent(helper_GroupHeader);
            //    //helper.RegisterGroup("xcat", true, true);
            //    //helper.ApplyGroupSort();

            //    fnButtonState();
            //    BindGrid();
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
            //    if (ViewState["xrow"] != null)
            //    {
                    
            //        if (txtconformmessageValue.Value == "Yes")
            //        {
            //            int flag = 0;
            //            foreach (GridViewRow row in GridView1.Rows)
            //            {
            //                RadioButton rdoy = row.FindControl("rdoyes") as RadioButton;
            //                RadioButton rdon = row.FindControl("rdono") as RadioButton;
            //                RadioButton rdonaa = row.FindControl("rdona") as RadioButton;


            //                if (rdoy.Checked == false && rdon.Checked == false && rdonaa.Checked == false)
            //                {
            //                    row.BackColor = zglobal.rowerr;
            //                    flag = 1;
            //                }
            //            }
            //            if (flag == 1)
            //            {
            //                //message.InnerText = "Must select best taken and percentage of all subjects.";
            //                message.InnerText = "Please fill all field(s) properly.";
            //                message.Style.Value = zglobal.warningmsg;
            //                return;
            //            }

            //            btnSave_Click(sender,e);

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
            //                        "UPDATE hrgrowthh SET xstatus=@xstatus,xsubmitedby=@xsubmitedby,xsubmitdt=@xsubmitdt " +
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

                //if (ViewState["xrow"] != null)
                //{
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


                                string query = "DELETE FROM amattn WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm and xdate=@xdate and xtype=@xtype and " +
                                               "xstdid in (select xstdid from amattnspvw WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm and xdate=@xdate and xtype=@xtype and xclass=@xclass and xsection=@xsection)";
                                cmd.Parameters.Clear();

                                DateTime xdate1 = xdate.Text.Trim() != string.Empty
                               ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture)
                               : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xdate", xdate1);
                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xsection", xsection.Text.Trim().ToString());
                                cmd.Parameters.AddWithValue("@xtype", "Attendance");
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
                        BindGrid();
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


        protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xterm.Text == "" || xterm.Text == string.Empty || xterm.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Term</li>";
                    isValid = false;
                }
                if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Class</li>";
                    isValid = false;
                }
                if (xsection.Text == "" || xsection.Text == string.Empty || xsection.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Section</li>";
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
                    _abbr.Visible = false;
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    return;
                }

                 BindGrid();
                fnFillGrid2();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}