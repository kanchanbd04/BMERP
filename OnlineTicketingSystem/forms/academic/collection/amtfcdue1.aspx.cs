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
    public partial class amtfcdue1 : System.Web.UI.Page
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
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Test Type", xcttype);
                    //zglobal.fnGetComboDataCD("Observation Action", xaction);

                    zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    xsession.Text = zglobal.fnDefaults("xsessionacc", "Student");
                    //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //zsetvalue.SetDWNumItem(xctno, 2, 1);

                    //string xfperiod = zglobal.fnGetValue("xfperiod", "amdefaults",
                    //   "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    //   " and xtype='Student'");
                    //string xtperiod = zglobal.fnGetValue("xtperiod", "amdefaults",
                    //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                    //    " and xtype='Student'");

                    //zglobal.fnGetComboDataCalendar(xcdate, Convert.ToDateTime(xfperiod), Convert.ToDateTime(xtperiod));
                    //xcdate.Text = DateTime.Now.ToString("MMM-yyyy");

                    zglobal.fnGetComboDataCalendar(xcdate, Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])));
                    xcdate.Text = DateTime.Now.ToString("MMM-yyyy");

                    xtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    ViewState["xrow"] = null;
                    hiddenxrow.Value = "";
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    ViewState["xtype"] = "Auto Generated";
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";
                    _xpeer.Value = "";
                    _xteacher.Value = "";

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
                    //_gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();

                }

                xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
        xstdid.Text.ToString().Trim() + "' ");

                if (xstdid.Text.Trim().ToString() != "")
                {
                    xclass.Text = zglobal.fnGetValue("xclass", "amstudentvwextacc",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xstdid='" +
                        xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() +
                        "'  and zactiveacc=1");
                }


                GridViewHelper helper = new GridViewHelper(GridView1);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                helper.RegisterGroup("xcat", true, true);
                helper.ApplyGroupSort();

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
            //foreach (GridViewRow row in dgvOBListNew.Rows)
            //{
            //    LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            //}

            //foreach (GridViewRow row in dgvOBListSubmitted.Rows)
            //{
            //    LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            //}
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

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();

            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //string xsession1 = xsession.Text.Trim().ToString();
            //string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            //string xsection1 = xsection.Text.Trim().ToString();
            
            //string str = "";


            //str = "select ROW_NUMBER() OVER (ORDER BY xcodealt,xcat,xline) AS xid,xrow,xline,xdesc,xcat FROM hrgrowthset as a inner join mscodesam as b " +
            //      "on a.zid=b.zid and b.xtype='Stages Category' and a.xcat=b.xcode and b.zactive=1 " +
            //      "WHERE a.zid=@zid AND a.xtype='Teachers' and a.zactive=1 order by xcodealt,xcat,xline ";


            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.Fill(dts, "tempztcode");
            //DataTable dtmarks = new DataTable();
            //dtmarks = dts.Tables[0];

            //if (dtmarks.Rows.Count > 0)
            //{

            //    GridView1.Columns.Clear();
                

            //    bfield = new BoundField();
            //    bfield.HeaderText = "No.";
            //    bfield.DataField = "xid";
            //    bfield.ItemStyle.Width = 35;
            //    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    GridView1.Columns.Add(bfield);


            //    TemplateField tfield119 = new TemplateField();
            //    tfield119.HeaderText = "Stages";
            //    tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            //    tfield119.ItemStyle.Width = 450;
            //    GridView1.Columns.Add(tfield119);

                

            //    tfield = new TemplateField();
            //    tfield.HeaderText = "Y";
            //    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield.ItemStyle.Width = 30;
            //    GridView1.Columns.Add(tfield);


            //    tfield = new TemplateField();
            //    tfield.HeaderText = "N";
            //    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield.ItemStyle.Width = 30;
            //    GridView1.Columns.Add(tfield);

            //    tfield = new TemplateField();
            //    tfield.HeaderText = "N/A";
            //    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield.ItemStyle.Width = 30;
            //    GridView1.Columns.Add(tfield);



            //    TemplateField tfield1 = new TemplateField();
            //    tfield1.HeaderText = "Description/ Comments/ Evidence";
            //    tfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    //tfield1.ItemStyle.Width = Unit.Pixel(250);
            //    GridView1.Columns.Add(tfield1);


            //    TemplateField tfield2 = new TemplateField();
            //    tfield2.HeaderText = "";
            //    tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //    tfield2.ItemStyle.Width = Unit.Pixel(30);
            //    GridView1.Columns.Add(tfield2);

            //    BoundField bfield1 = new BoundField();
            //    bfield1.DataField = "xcat";
            //    GridView1.Columns.Add(bfield1);

            //    BoundField bfield2 = new BoundField();
            //    bfield2.DataField = "xrow";
            //    GridView1.Columns.Add(bfield2);

            //    if (ViewState["xrow"] != null)
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            using (DataSet dts1 = new DataSet())
            //            {
            //                string query = "SELECT * FROM hrgrowthd WHERE zid=@zid AND xrow=@xrow";
            //                SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
            //                da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
            //                da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
            //                da1.Fill(dts1, "tblamadmisd");
            //                //tblamadmisd = new DataTable();
            //                amexamd = dts1.Tables[0];
            //            }
            //        }


            //        string xstatus1 = zglobal.fnGetValue("xstatus", "hrgrowthh",
            //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //        ViewState["xstatus"] = xstatus1;
            //        hxstatus.Value = xstatus1;
            //    }
            //    else
            //    {
            //        hxstatus.Value = "";
            //    }





            //    GridView1.DataSource = dtmarks;
            //    GridView1.DataBind();


            //    bfield1.Visible = false;
            //    bfield2.Visible = false;



            //}
            //else
            //{
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //}

        }

        TextBox txTextBox;

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {


            //        int xrow = Int32.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());



            //        RadioButton rdoyes = new RadioButton();
            //        rdoyes.ID = "rdoyes";
            //        rdoyes.GroupName = "xcom" + (e.Row.DataItem as DataRowView).Row["xid"].ToString();
            //        e.Row.Cells[2].Controls.Add(rdoyes);

            //        RadioButton rdono = new RadioButton();
            //        rdono.ID = "rdono";
            //        rdono.GroupName = "xcom" + (e.Row.DataItem as DataRowView).Row["xid"].ToString();
            //        e.Row.Cells[3].Controls.Add(rdono);

            //        RadioButton rdona = new RadioButton();
            //        rdona.ID = "rdona";
            //        rdona.GroupName = "xcom" + (e.Row.DataItem as DataRowView).Row["xid"].ToString();
            //        e.Row.Cells[4].Controls.Add(rdona);

            //        TextBox txtComments = new TextBox();
            //        txtComments.ID = "txtComments";
            //        txtComments.CssClass = "bm_academic_textbox_grid1 bm_academic_ctl_global";
            //        txtComments.TextMode = TextBoxMode.MultiLine;
            //        txtComments.Attributes.Add("onkeyup", "enter(this,event)");
            //        e.Row.Cells[5].Controls.Add(txtComments);

            //        HtmlGenericControl image = new HtmlGenericControl("img");
            //        image.ID = "image2";
            //        image.Attributes.Add("src", "/images/list-am16x16.png");
            //        image.Attributes.Add("class", "bm_academic_list1 bm_list");
            //        image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
            //        e.Row.Cells[6].Controls.Add(image);

            //        Label lblxdesc = new Label();
            //        lblxdesc.ID = "xdesc";
            //        lblxdesc.Text = (e.Row.DataItem as DataRowView).Row["xdesc"].ToString();
            //        e.Row.Cells[1].Controls.Add(lblxdesc);



            //        if (ViewState["xrow"] != null)
            //        {
            //            if (Convert.ToString(ViewState["xstatus"]) != "New" && Convert.ToString(ViewState["xstatus"]) != "Undo" && Convert.ToString(ViewState["xstatus"]) != "Undo1")
            //            {
            //                txtComments.Enabled = false;
            //                rdoyes.Enabled = false;
            //                rdono.Enabled = false;
            //                rdona.Enabled = false;
            //            }



            //            if (amexamd.Rows.Count > 0)
            //            {
            //                foreach (DataRow row in amexamd.Rows)
            //                {
            //                    if (row["xrow1"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
            //                    {

            //                        if (row["xcomment"].ToString() == "Yes")
            //                        {
            //                            rdoyes.Checked = true;
            //                            rdono.Checked = false;
            //                            rdona.Checked = false;
            //                        }
            //                        else if (row["xcomment"].ToString() == "No")
            //                        {
            //                            rdoyes.Checked = false;
            //                            rdono.Checked = true;
            //                            rdona.Checked = false;
            //                        }
            //                        else if (row["xcomment"].ToString() == "N/A")
            //                        {
            //                            rdoyes.Checked = false;
            //                            rdono.Checked = false;
            //                            rdona.Checked = true;
            //                        }
            //                        else
            //                        {
            //                            rdoyes.Checked = false;
            //                            rdono.Checked = false;
            //                            rdona.Checked = false;
            //                        }

            //                        txtComments.Text = row["xremarks"].ToString();

            //                        break;
            //                    }
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
                    //"SELECT * FROM amtfcdueh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup AND xcdate=@xcdate AND xtype='Auto Generated'";
                    "SELECT * FROM amtfcdueh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xcdate=@xcdate AND xtype='Auto Generated'";
                    // }

                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                    //da.SelectCommand.Parameters.AddWithValue("@xobserno", Int32.Parse(xobserno.Text.ToString().Trim()));
                    //da.SelectCommand.Parameters.AddWithValue("@xteacher", _xteacher.Value.ToString().Trim());
                    //DateTime xdate1 = xdate.Text.Trim() != string.Empty
                    //            ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                    //                CultureInfo.InvariantCulture)
                    //            : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string[] date = new string[2];
                    date = xcdate.Text.Split('-');

                    int year = Int32.Parse(date[1]);
                    int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                    DateTime xdate1 = new DateTime(year, month, 1);
                    da.SelectCommand.Parameters.AddWithValue("@xcdate", xdate1);


                    DataTable tempTable = new DataTable();
                    da.Fill(dts, "tempTable");
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
                        hiddenxrow.Value = ViewState["xrow"].ToString();
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
            //try
            //{
            //    //btnRefresh_Click(sender,e);
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    int xrow = 0;
            //    message.InnerHtml = "";

            //    ////Check for final approval
            //    //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    //{
            //    //    using (DataSet dts = new DataSet())
            //    //    {
            //    //        con.Open();
            //    //        string query =
            //    //            //"SELECT count(*) FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xstatus='Approved3' ";
            //    //            "SELECT count(*) FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test' AND xstatus='Approved3' ";

            //    //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //    //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsession",
            //    //            xsession.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xsection",
            //    //        //    xsection.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xsubject",
            //    //        //    xsubject.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());



            //    //        DataTable tempTable = new DataTable();
            //    //        da.Fill(dts, "tempTable");
            //    //        tempTable = dts.Tables["tempTable"];

            //    //        if (Convert.ToInt32(tempTable.Rows[0][0]) > 0)
            //    //        {
            //    //            message.InnerHtml = "Best test selection already approved. Cann't insert new record for this term.";
            //    //            message.Style.Value = zglobal.warningmsg;
            //    //            return;
            //    //        }
            //    //    }
            //    //}


            //    bool isValid = true;
            //    string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
            //    if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Session</li>";
            //        isValid = false;
            //    }
            //    if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Class</li>";
            //        isValid = false;
            //    }
            //    if (xsection.Text == "" || xsection.Text == string.Empty || xsection.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Section</li>";
            //        isValid = false;
            //    }
            //    if (xsubject.Text == "" || xsubject.Text == string.Empty || xsubject.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Subject</li>";
            //        isValid = false;
            //    }
            //    if (xaction.Text == "" || xaction.Text == string.Empty || xaction.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Action</li>";
            //        isValid = false;
            //    }
            //    if (xobserno.Text == "" || xobserno.Text == string.Empty || xobserno.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Observation No</li>";
            //        isValid = false;
            //    }
            //    if (xdate.Text == "" || xdate.Text == string.Empty || xdate.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Observation Date</li>";
            //        isValid = false;
            //    }
            //    if (xaim.Value == "" || xaim.Value == string.Empty || xaim.Value == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Aim of The Lesson </li>";
            //        isValid = false;
            //    }

            //    if (xpeer.Text == "" || xpeer.Text == string.Empty || xpeer.Text == "[Select]" || _xpeer.Value=="")
            //    {
            //        rtnMessage = rtnMessage + "<li>Peer/Observer </li>";
            //        isValid = false;
            //    }
            //    if (xteacher.Text == "" || xteacher.Text == string.Empty || xteacher.Text == "[Select]" || _xteacher.Value=="")
            //    {
            //        rtnMessage = rtnMessage + "<li>Teacher Observed </li>";
            //        isValid = false;
            //    }

            //    //if (zglobal.fnProperty("Class Subject", xsubject.Text.Trim().ToString(), "xpaper") == "yes" && Convert.ToInt32(zglobal.fnGetValue("xcodealt", "mscodesam", "zid=" + _zid + " and xtype='Class' and xcode='" + xclass.Text.Trim().ToString() + "'")) > 10)
            //    //{
            //    //    if (xpaper.Text == "" || xpaper.Text == string.Empty || xpaper.Text == "[Select]")
            //    //    {
            //    //        rtnMessage = rtnMessage + "<li>Paper</li>";
            //    //        isValid = false;
            //    //    }
            //    //}

            //    //if (xcttype.Text == "Test")
            //    //{
            //    //    if (xctno.Text != "")
            //    //    {
            //    //        if (ViewState["xdate1"] != null)
            //    //        {
            //    //            if (Convert.ToString(ViewState["xdate1"]) != xdate.Text.ToString().Trim())
            //    //            {
            //    //                if (xreason.Text == "" || xreason.Text == string.Empty)
            //    //                {
            //    //                    rtnMessage = rtnMessage + "<li>Reason</li>";
            //    //                    isValid = false;
            //    //                }
            //    //            }
            //    //        }
            //    //    }
            //    //}

            //    rtnMessage = rtnMessage + "</ol></div>";
            //    if (!isValid)
            //    {
            //        message.InnerHtml = rtnMessage;
            //        message.Style.Value = zglobal.warningmsg;
            //        return;
            //    }

            //    //fnCheckRow();
            //    string xstatus1 = "";
            //    if (ViewState["xrow"] != null)
            //    {
            //        xstatus1 = zglobal.fnGetValue("xstatus", "hrgrowthh",
            //              "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //        if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
            //        {
            //            message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
            //            message.Style.Value = zglobal.warningmsg;
            //            return;
            //        }
            //    }
            //    //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    //{
            //    //    using (DataSet dts = new DataSet())
            //    //    {
            //    //        con.Open();
            //    //        string query =
            //    //            "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";

            //    //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //    //        da.SelectCommand.Parameters.AddWithValue("@zid",_zid);
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xcttype", xcttype.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xctno", xctno.Text.ToString().Trim());



            //    //        DataTable tempTable = new DataTable();
            //    //        da.Fill(dts, "tempTable");
            //    //        tempTable = dts.Tables["tempTable"];

            //    //        if (tempTable.Rows.Count > 0)
            //    //        {
            //    //            ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
            //    //        }
            //    //        else
            //    //        {
            //    //            ViewState["xrow"] = null;
            //    //        }


            //    //    }
            //    //}

            //    ////Duplicate entry check
            //    //if (ViewState["xrow"] != null)
            //    //{
            //    //    message.InnerHtml = "Cann't insert duplicate record.";
            //    //    message.Style.Value = zglobal.warningmsg;
            //    //    return;
            //    //}


            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        if (GridView1.Rows.Count > 0)
            //        {
            //            if (ViewState["xrow"] == null)
            //            {
            //                //Duplicate entry check & check sequential entry Test-1,2,3.....
            //                using (SqlConnection con = new SqlConnection(zglobal.constring))
            //                {
            //                    using (DataSet dts = new DataSet())
            //                    {
            //                        con.Open();
            //                        string query =
            //                            //"SELECT * FROM hrgrowthh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass  AND xgroup=@xgroup   AND xsection=@xsection AND xsubject=@xsubject AND xobserno=@xobserno AND xteacher=@xteacher";
            //                            "SELECT * FROM hrgrowthh WHERE zid=@zid AND xsession=@xsession AND xobserno=@xobserno AND xteacher=@xteacher";


            //                        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                        //da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                        //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                        //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //                        //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //                        da.SelectCommand.Parameters.AddWithValue("@xobserno", Int32.Parse(xobserno.Text.ToString().Trim()));
            //                        da.SelectCommand.Parameters.AddWithValue("@xteacher", _xteacher.Value.ToString().Trim());


            //                        DataTable tempTable = new DataTable();
            //                        da.Fill(dts, "tempTable");
            //                        tempTable = dts.Tables["tempTable"];

            //                        if (tempTable.Rows.Count > 0)
            //                        {
            //                            message.InnerHtml = "Cann't insert duplicate record. Observation-" + xobserno.Text.ToString().Trim() + " already inserted.";
            //                            message.Style.Value = zglobal.warningmsg;
            //                            return;
            //                        }


            //                        dts.Reset();
            //                        query =
            //                            //"SELECT coalesce(max(convert(int,xobserno)),0) FROM hrgrowthh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass  AND xgroup=@xgroup   AND xsection=@xsection AND xsubject=@xsubject  AND xteacher=@xteacher  ";
            //                            "SELECT coalesce(max(convert(int,xobserno)),0) FROM hrgrowthh WHERE zid=@zid AND xsession=@xsession   AND xteacher=@xteacher  ";

            //                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            //                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                        //da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //                        //da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //                        //da1.SelectCommand.Parameters.AddWithValue("@xobserno", Int32.Parse(xobserno.Text.ToString().Trim()));
            //                        da1.SelectCommand.Parameters.AddWithValue("@xteacher", _xteacher.Value.ToString().Trim());


            //                        DataTable tempTable1 = new DataTable();
            //                        da1.Fill(dts, "tempTable");
            //                        tempTable1 = dts.Tables["tempTable"];

            //                        if (tempTable1.Rows[0][0].ToString() != "0")
            //                        {
            //                            //if (int.Parse(xctno.Text) == int.Parse(tempTable1.Rows[0][0].ToString()))
            //                            //{
            //                            //    message.InnerHtml = "Already inserted '" + xcttype.Text + "-" + (int.Parse(tempTable1.Rows[0][0].ToString())) + "' ";
            //                            //    message.Style.Value = zglobal.warningmsg;
            //                            //    return;
            //                            //}
            //                            if (int.Parse(xobserno.Text) > int.Parse(tempTable1.Rows[0][0].ToString()) + 1)
            //                            {
            //                                message.InnerHtml = "Please insert 'Observation No-" + (int.Parse(tempTable1.Rows[0][0].ToString()) + 1) + "' before insert 'Observation No-" + xobserno.Text + "'";
            //                                message.Style.Value = zglobal.warningmsg;
            //                                return;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            if (int.Parse(xobserno.Text) != 1)
            //                            {
            //                                message.InnerHtml = "Please insert 'Observation No-1' before insert 'Observation No-" + xobserno.Text + "'";
            //                                message.Style.Value = zglobal.warningmsg;
            //                                return;
            //                            }
            //                        }


            //                    }
            //                }




            //                using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //                {
            //                    conn.Open();
            //                    SqlCommand cmd = new SqlCommand();
            //                    cmd.Connection = conn;

            //                    DateTime ztime = DateTime.Now;
            //                    DateTime zutime = DateTime.Now;
            //                    _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //                    xrow = 0;

            //                    string xsession1 = "";
            //                    string xterm1 = "";
            //                    string xclass1 = "";
            //                    string xgroup1 = "";
            //                    string xtype = "Teachers";
            //                    string xstatus = "New";
            //                    string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                    DateTime xsubmitdt = DateTime.Now;
            //                    DateTime xdate1;
            //                    string xsection1 = "";
            //                    string xsubject1 = "";
            //                    string xpaper1 = "";
            //                    string xext1 = "";
            //                    string xcttype1 = "";
            //                    string xctno1 = "";
            //                    decimal xmarks1 = 0;
            //                    string xcteacher1 = "";
            //                    string xsteacher1 = "";
            //                    string xtopic1 = "";
            //                    string xdetails1 = "";
            //                    string xretestfor1 = "";
            //                    string xrefcttype1 = "";
            //                    string xrefctno1 = "";
            //                    string xreason1 = "";
            //                    DateTime xschdate1;
            //                    string xaction1 = "";
            //                    int xobserno1;
            //                    int xlearnerno1;
            //                    int xhour1;
            //                    int xminitue1;
            //                    string xaim1 = "";
            //                    string xremarks1 = "";
            //                    string xpeer1 = "";
            //                    string xteacher1 = "";

            //                    string query =
            //                        "INSERT INTO hrgrowthh (ztime,zid,xrow,xsession,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xstatus,zemail,xdate,xaction,xobserno,xlearnerno,xhour,xminitue,xaim,xremarks,xpeer,xteacher) " +
            //                        "VALUES(@ztime,@zid,@xrow,@xsession,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xstatus,@zemail,@xdate,@xaction,@xobserno,@xlearnerno,@xhour,@xminitue,@xaim,@xremarks,@xpeer,@xteacher) ";

            //                    xrow = zglobal.GetMaximumIdInt("xrow", "hrgrowthh", " zid=" + _zid, 1, 1);
            //                    ViewState["xrow"] = xrow;
            //                    hiddenxrow.Value = ViewState["xrow"].ToString();
            //                    xsession1 = xsession.Text.Trim().ToString();
            //                    //xterm1 = xterm.Text.Trim().ToString();
            //                    xclass1 = xclass.Text.Trim().ToString();
            //                    xgroup1 = xgroup.Text.Trim().ToString();
            //                    xdate1 = xdate.Text.Trim() != string.Empty
            //                        ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                            CultureInfo.InvariantCulture)
            //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //                    xsection1 = xsection.Text.ToString().Trim();
            //                    xsubject1 = xsubject.Text.Trim().ToString();
            //                    xpaper1 = xpaper.Text.ToString().Trim();
            //                    xext1 = xext.Text.Trim().ToString();
            //                    //xcttype1 = xcttype.Text.ToString().Trim();
            //                    //xctno1 = xctno.Text.ToString().Trim();
            //                    //xmarks1 = decimal.Parse(xmarks.Text.Trim().ToString());
            //                    //xcteacher1 = _classteacher.Value.ToString().Trim();
            //                    //xsteacher1 = _subteacher.Value.ToString().Trim();
            //                    //xtopic1 = xtopic.Value.ToString().Trim();
            //                    //xdetails1 = xdetails.Value.ToString().Trim();
            //                    xaction1 = xaction.Text.ToString().Trim();
            //                    xobserno1 = xobserno.Text.Trim().ToString() != String.Empty
            //                        ? Int32.Parse(xobserno.Text.Trim().ToString())
            //                        : 0;
            //                    xlearnerno1 = xlearnerno.Text.Trim().ToString() != String.Empty && xlearnerno.Text.Trim().ToString() != ""
            //                        ? Int32.Parse(xlearnerno.Text.Trim().ToString())
            //                        : 0;
            //                    xhour1 = xhour.Text.Trim().ToString() != "H"
            //                        ? Int32.Parse(xhour.Text.Trim().ToString())
            //                        : 0;
            //                    xminitue1 = xminitue.Text.Trim().ToString() != "M"
            //                        ? Int32.Parse(xminitue.Text.Trim().ToString())
            //                        : 0;
            //                    xaim1 = xaim.Value.Trim().ToString();
            //                    xremarks1 = xremarks.Value.Trim().ToString();
            //                    xpeer1 = _xpeer.Value.Trim().ToString();
            //                    xteacher1 = _xteacher.Value.Trim();


            //                    //if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test" || xcttype.Text == "Missed Test")
            //                    //{
            //                    //    if (xreference.Text != "")
            //                    //    {
            //                    //        string[] sch = xreference.SelectedValue.Split('|');
            //                    //        xrefcttype1 = sch[0];
            //                    //        xrefctno1 = sch[1];
            //                    //    }
            //                    //}

            //                    ////if (xreason_d.Visible == true)
            //                    ////{
            //                    ////    xreason1 = xreason.Text.Trim().ToString();
            //                    ////}

            //                    ////message.InnerHtml = "Class = " + xclass.Text + "  Extension = " + xext1;
            //                    ////return;

            //                    //xretestfor1 = xreference.SelectedItem.Text.Trim().ToString();
            //                    //xschdate1 = ViewState["xdate1"] != null
            //                    //   ? DateTime.ParseExact(Convert.ToString(ViewState["xdate1"]), "dd/MM/yyyy",
            //                    //       CultureInfo.InvariantCulture)
            //                    //   : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@ztime", ztime);
            //                    cmd.Parameters.AddWithValue("@zutime", ztime);
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", xrow);
            //                    cmd.Parameters.AddWithValue("@xsession", xsession1);
            //                    //cmd.Parameters.AddWithValue("@xterm", xterm1);
            //                    cmd.Parameters.AddWithValue("@xclass", xclass1);
            //                    cmd.Parameters.AddWithValue("@xgroup", xgroup1);
            //                    cmd.Parameters.AddWithValue("@xtype", xtype);
            //                    cmd.Parameters.AddWithValue("@xstatus", xstatus);
            //                    cmd.Parameters.AddWithValue("@zemail", zemail);
            //                    cmd.Parameters.AddWithValue("@xdate", xdate1);
            //                    cmd.Parameters.AddWithValue("@xsection", xsection1);
            //                    cmd.Parameters.AddWithValue("@xsubject", xsubject1);
            //                    cmd.Parameters.AddWithValue("@xpaper", xpaper1);
            //                    cmd.Parameters.AddWithValue("@xext", xext1);
            //                    //cmd.Parameters.AddWithValue("@xcttype", xcttype1);
            //                    //cmd.Parameters.AddWithValue("@xctno", xctno1);
            //                    //cmd.Parameters.AddWithValue("@xmarks", xmarks1);
            //                    //cmd.Parameters.AddWithValue("@xcteacher", xcteacher1);
            //                    //cmd.Parameters.AddWithValue("@xsteacher", xsteacher1);
            //                    //cmd.Parameters.AddWithValue("@xtopic", xtopic1);
            //                    //cmd.Parameters.AddWithValue("@xdetails", xdetails1);
            //                    //cmd.Parameters.AddWithValue("@xrefcttype", xrefcttype1);
            //                    //cmd.Parameters.AddWithValue("@xrefctno", xrefctno1);
            //                    //cmd.Parameters.AddWithValue("@xreason", xreason1);
            //                    //cmd.Parameters.AddWithValue("@xschdate", xschdate1);
            //                    //cmd.Parameters.AddWithValue("@xretestfor", xretestfor1);
            //                    //cmd.Parameters.AddWithValue("@xreason", xreason1);
            //                    cmd.Parameters.AddWithValue("@xaction", xaction1);
            //                    cmd.Parameters.AddWithValue("@xobserno", xobserno1);
            //                    cmd.Parameters.AddWithValue("@xlearnerno", xlearnerno1);
            //                    cmd.Parameters.AddWithValue("@xhour", xhour1);
            //                    cmd.Parameters.AddWithValue("@xminitue", xminitue1);
            //                    cmd.Parameters.AddWithValue("@xaim", xaim1);
            //                    cmd.Parameters.AddWithValue("@xremarks", xremarks1);
            //                    cmd.Parameters.AddWithValue("@xpeer", xpeer1);
            //                    cmd.Parameters.AddWithValue("@xteacher", xteacher1);
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }



            //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //            {
            //                conn.Open();
            //                SqlCommand cmd = new SqlCommand();
            //                cmd.Connection = conn;


            //                string query = "DELETE FROM hrgrowthd WHERE zid=@zid AND xrow=@xrow";
            //                cmd.Parameters.Clear();

            //                cmd.CommandText = query;
            //                cmd.Parameters.AddWithValue("@zid", _zid);
            //                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                //if (xstatus1 != "Undo1" && xstatus1 != "Undo")
            //                //if (xstatus1 != "Undo1")
            //                //{
            //                cmd.ExecuteNonQuery();
            //                //}


            //                if (xrow == 0)
            //                {

            //                    DateTime xdate1 = xdate.Text.Trim() != string.Empty
            //                        ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //                            CultureInfo.InvariantCulture)
            //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //                    //string xretestfor1;
            //                    //string xrefcttype1 = "";
            //                    //string xrefctno1 = "";
            //                    //string xreason1 = "";
            //                    //DateTime xschdate1 = ViewState["xdate1"] != null
            //                    //   ? DateTime.ParseExact(Convert.ToString(ViewState["xdate1"]), "dd/MM/yyyy",
            //                    //       CultureInfo.InvariantCulture)
            //                    //   : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //                    //if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test" || xcttype.Text == "Missed Test")
            //                    //{
            //                    //    if (xreference.Text != "")
            //                    //    {
            //                    //        string[] sch = xreference.SelectedValue.Split('|');
            //                    //        xrefcttype1 = sch[0];
            //                    //        xrefctno1 = sch[1];
            //                    //    }
            //                    //}

            //                    //if (xreason_d.Visible == true)
            //                    //{
            //                    //    xreason1 = xreason.Text.Trim().ToString();
            //                    //}
            //                    string xaction1 = xaction.Text.ToString().Trim();
            //                    int xlearnerno1 = xlearnerno.Text.Trim().ToString() != String.Empty && xlearnerno.Text.Trim().ToString() != ""
            //                        ? Int32.Parse(xlearnerno.Text.Trim().ToString())
            //                        : 0;
            //                    int xhour1 = xhour.Text.Trim().ToString() != "H"
            //                        ? Int32.Parse(xlearnerno.Text.Trim().ToString())
            //                        : 0;
            //                    int xminitue1 = xminitue.Text.Trim().ToString() != "M"
            //                        ? Int32.Parse(xminitue.Text.Trim().ToString())
            //                        : 0;
            //                    string xaim1 = xaim.Value.Trim().ToString();
            //                    string xremarks1 = xremarks.Value.Trim().ToString();
            //                    string xpeer1 = _xpeer.Value.Trim().ToString();

            //                    query = "UPDATE hrgrowthh SET zutime=@zutime,xemail=@xemail,xaction=@xaction,xdate=@xdate,xlearnerno=@xlearnerno,xhour=@xhour,xminitue=@xminitue,xaim=@xaim,xremarks=@xremarks,xpeer=@xpeer " +
            //                            "WHERE zid=@zid AND xrow=@xrow ";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
            //                    cmd.Parameters.AddWithValue("@xemail",
            //                        Convert.ToString(HttpContext.Current.Session["curuser"]));
            //                    //cmd.Parameters.AddWithValue("@xmarks", xmarks.Text.Trim().ToString());
            //                    //cmd.Parameters.AddWithValue("@xcteacher", _classteacher.Value.Trim().ToString());
            //                    //cmd.Parameters.AddWithValue("@xsteacher", _subteacher.Value.Trim().ToString());
            //                    //cmd.Parameters.AddWithValue("@xtopic", xtopic.Value.Trim().ToString());
            //                    //cmd.Parameters.AddWithValue("@xdetails", xdetails.Value.Trim().ToString());
            //                    cmd.Parameters.AddWithValue("@xdate", xdate1);
            //                    //cmd.Parameters.AddWithValue("@xrefcttype", xrefcttype1);
            //                    //cmd.Parameters.AddWithValue("@xrefctno", xrefctno1);
            //                    //cmd.Parameters.AddWithValue("@xreason", xreason1);
            //                    //cmd.Parameters.AddWithValue("@xretestfor", xreference.SelectedItem.Text.Trim().ToString());
            //                    //cmd.Parameters.AddWithValue("@xschdate", xschdate1);
            //                    cmd.Parameters.AddWithValue("@xaction", xaction1);
            //                    cmd.Parameters.AddWithValue("@xlearnerno", xlearnerno1);
            //                    cmd.Parameters.AddWithValue("@xhour", xhour1);
            //                    cmd.Parameters.AddWithValue("@xminitue", xminitue1);
            //                    cmd.Parameters.AddWithValue("@xaim", xaim1);
            //                    cmd.Parameters.AddWithValue("@xremarks", xremarks1);
            //                    cmd.Parameters.AddWithValue("@xpeer", xpeer1);
            //                    cmd.ExecuteNonQuery();


            //                }



            //                //int flag = 0;
            //                //foreach (GridViewRow row in GridView1.Rows)
            //                //{


            //                //    TextBox txtTextBox1 = row.FindControl("txtMarks") as TextBox;
            //                //    decimal getmarks;
            //                //    if (txtTextBox1.Text.Trim().ToString() == "" || txtTextBox1.Text.Trim().ToString() == String.Empty)
            //                //    {
            //                //        getmarks = 0;
            //                //    }
            //                //    else
            //                //    {
            //                //        getmarks = decimal.Parse(txtTextBox1.Text.Trim().ToString());
            //                //    }

            //                //    if (getmarks > decimal.Parse(xmarks.Text.Trim().ToString()))
            //                //    {
            //                //        row.BackColor = zglobal.rowerr;
            //                //        flag = 1;
            //                //    }
            //                //}

            //                //if (flag == 1)
            //                //{
            //                //    message.InnerText = "Student marks can not greater than exam marks.";
            //                //    message.Style.Value = zglobal.warningmsg;
            //                //    return;
            //                //}


            //                foreach (GridViewRow row in GridView1.Rows)
            //                {

            //                    int xline = zglobal.GetMaximumIdInt("xline", "hrgrowthd", " zid=" + _zid + " and xrow=" + Convert.ToInt32(ViewState["xrow"]), "line");
            //                    //TextBox txtTextBox1 = row.FindControl("txtMarks") as TextBox;
            //                    //decimal getmarks;
            //                    //if (txtTextBox1.Text.Trim().ToString() == "" || txtTextBox1.Text.Trim().ToString() == String.Empty)
            //                    //{
            //                    //    //getmarks = 0;
            //                    //    getmarks = -1;
            //                    //}
            //                    //else
            //                    //{
            //                    //    getmarks = decimal.Parse(txtTextBox1.Text.Trim().ToString());
            //                    //}
            //                    TextBox txtTextBox2 = row.FindControl("txtComments") as TextBox;
            //                    //CheckBox chkCheckBox = row.FindControl("xna") as CheckBox;

            //                    //int xna1;
            //                    //if (chkCheckBox.Checked == true)
            //                    //{
            //                    //    xna1 = 1;
            //                    //}
            //                    //else
            //                    //{
            //                    //    xna1 = 0;
            //                    //}
            //                    Label lblxdesc = row.FindControl("xdesc") as Label;

            //                    RadioButton rdoy = row.FindControl("rdoyes") as RadioButton;
            //                    RadioButton rdon = row.FindControl("rdono") as RadioButton;
            //                    RadioButton rdonaa = row.FindControl("rdona") as RadioButton;

            //                    string xcomment1 = "";
            //                    if (rdoy.Checked)
            //                    {
            //                        xcomment1 = "Yes";
            //                    }
            //                    else if (rdon.Checked)
            //                    {
            //                        xcomment1 = "No";
            //                    }
            //                    else if (rdonaa.Checked)
            //                    {
            //                        xcomment1 = "N/A";
            //                    }
            //                    else
            //                    {
            //                        xcomment1 = "NV";
            //                    }

            //                    //string xflag1 = "";
            //                    //string xflag2 = "";

            //                    //if (xstatus1 == "Undo1" || xstatus1 == "Undo")
            //                    //if (xstatus1 == "Undo1")
            //                    //{
            //                    //    //Label lxflag1 = row.FindControl("xflag1") as Label;
            //                    //    //Label lxflag2 = row.FindControl("xflag2") as Label;
            //                    //    Label lxline = row.FindControl("xline") as Label;
            //                    //    ////if (lxflag1.Text.ToString() == "Wrong" || lxflag1.Text.ToString() == "Corrected")
            //                    //    //if (lxflag1.Text.ToString() == "Wrong")
            //                    //    //{
            //                    //    //    xflag1 = "Corrected";
            //                    //    //}
            //                    //    ////if (lxflag2.Text.ToString() == "Missing" || lxflag2.Text.ToString() == "Taken")
            //                    //    //if (lxflag2.Text.ToString() == "Missing")
            //                    //    //{
            //                    //    //    xflag2 = "Taken";
            //                    //    //}
            //                    //    if (lxline.Text == "" || lxline.Text == String.Empty)
            //                    //    {
            //                    //        query = "INSERT INTO amexamd (zid,xrow,xline,xstdid,xsrow,xgetmark,xremarks,xna) " +
            //                    //                "VALUES(@zid,@xrow,@xline,@xstdid,@xsrow,@xgetmark,@xremarks,@xna) ";

            //                    //        cmd.CommandText = query;
            //                    //        cmd.Parameters.Clear();
            //                    //        cmd.Parameters.AddWithValue("@zid", _zid);
            //                    //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    //        cmd.Parameters.AddWithValue("@xline", xline);
            //                    //        cmd.Parameters.AddWithValue("@xstdid", row.Cells[1].Text.ToString());
            //                    //        cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[6].Text.ToString()));
            //                    //        cmd.Parameters.AddWithValue("@xgetmark", getmarks);
            //                    //        cmd.Parameters.AddWithValue("@xremarks", txtTextBox2.Text.Trim().ToString());
            //                    //        cmd.Parameters.AddWithValue("@xna", xna1);
            //                    //        cmd.ExecuteNonQuery();
            //                    //    }
            //                    //    else
            //                    //    {
            //                    //        query =
            //                    //            "UPDATE amexamd SET zutime=@zutime,xemail=@xemail,xgetmark=@xgetmark,xremarks=@xremarks,xna=@xna " +
            //                    //            "WHERE zid=@zid AND xrow=@xrow AND xline=@xline";

            //                    //        cmd.CommandText = query;
            //                    //        cmd.Parameters.Clear();
            //                    //        cmd.Parameters.AddWithValue("@zid", _zid);
            //                    //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lxline.Text));
            //                    //        cmd.Parameters.AddWithValue("@xgetmark", getmarks);
            //                    //        cmd.Parameters.AddWithValue("@xremarks", txtTextBox2.Text.Trim().ToString());
            //                    //        cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
            //                    //        cmd.Parameters.AddWithValue("@xemail",
            //                    //            Convert.ToString(HttpContext.Current.Session["curuser"]));
            //                    //        cmd.Parameters.AddWithValue("@xna", xna1);
            //                    //        cmd.ExecuteNonQuery();
            //                    //    }
            //                    //}
            //                    //else
            //                    //{
            //                    query = "INSERT INTO hrgrowthd (zid,xrow,xline,xdesc,xcat,xcomment,xremarks,xrow1) " +
            //                        "VALUES(@zid,@xrow,@xline,@xdesc,@xcat,@xcomment,@xremarks,@xrow1) ";

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.Clear();
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.Parameters.AddWithValue("@xline", xline);
            //                    //cmd.Parameters.AddWithValue("@xdesc", row.Cells[1].Text.ToString());
            //                    cmd.Parameters.AddWithValue("@xdesc", lblxdesc.Text.ToString().Trim());
            //                    cmd.Parameters.AddWithValue("@xcat", row.Cells[7].Text.ToString());
            //                    cmd.Parameters.AddWithValue("@xcomment", xcomment1);
            //                    cmd.Parameters.AddWithValue("@xremarks", txtTextBox2.Text.Trim().ToString());
            //                    cmd.Parameters.AddWithValue("@xrow1", row.Cells[8].Text.ToString());
            //                    cmd.ExecuteNonQuery();
            //                    //}

            //                }
            //            }
            //        }
            //        else
            //        {
            //            message.InnerHtml = "No student found.";
            //            message.Style.Value = zglobal.warningmsg;
            //            return;
            //        }

            //        tran.Complete();

            //    }

            //    //btnSave.Enabled = false;
            //    //btnSave1.Enabled = false;
            //    // btnRefresh_Click(null, null);
            //    message.InnerHtml = zglobal.savesuccmsg;
            //    message.Style.Value = zglobal.successmsg;
            //    //ViewState["xrow"] = xrow;
            //    //ViewState["xstatus"] = "New";
            //    //hiddenxstatus.Value = "New";

            //    //BindGrid();

            //    fnButtonState();
            //    fnFillGrid2();

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
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
                    string query =
                         "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession,xclass,xgroup,xcdate,xtdate " +
                         "FROM amtfcdueh WHERE zid=@zid AND xtype='Auto Generated' AND xstatus='Confirmed' " +
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
                        dgvgeneratedues.DataSource = tempTable;
                        dgvgeneratedues.DataBind();
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
            //             "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xrow,xsession,xclass,xgroup,xsection,xsubject,xobserno,xdate, " +
            //             " (select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xpeer) as xpeer, " +
            //             "(select xname from hrmst where zid=hrgrowthh.zid and xemp=hrgrowthh.xteacher) as xteacher " +
            //             "FROM hrgrowthh WHERE zid=@zid AND xtype='Teachers' AND xstatus='Submited' order by xrow desc";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



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
            //    int xrow = Convert.ToInt32(((LinkButton)sender).Text);

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
            //try
            //{
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    message.InnerText = "";
            //    //fnCheckRow();

            //    //if (ViewState["xrow"] != null)
            //    //{
            //    //    string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh",
            //    //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //    //    if (xstatus1 != "New" && xstatus1 != "Undo")
            //    //    {
            //    //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
            //    //        message.Style.Value = zglobal.warningmsg;
            //    //        return;
            //    //    }
            //    //}

            //    if (ViewState["xrow"] != null)
            //    {
            //        if (txtconformmessageValue1.Value == "Yes")
            //        {
            //            string xstatus;


            //            using (TransactionScope tran = new TransactionScope())
            //            {
            //                using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //                {
            //                    conn.Open();
            //                    SqlCommand cmd = new SqlCommand();
            //                    cmd.Connection = conn;


            //                    string query = "DELETE FROM hrgrowthd WHERE zid=@zid AND xrow=@xrow";
            //                    cmd.Parameters.Clear();

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                    cmd.ExecuteNonQuery();

            //                    query = "DELETE FROM hrgrowthh WHERE zid=@zid AND xrow=@xrow";
            //                    cmd.CommandText = query;
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
            //            BindGrid();
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
                //message.InnerHtml = "";
                //btnGenerate.Enabled = true;
                //btnGenerate1.Enabled = true;
                ////   int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
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
                ////                    }

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

                //combo_OnTextChanged(sender, e);

                //xclass.Text = "";
                //xgroup.Text = "";
                //xsession.Text = "";
                //xcdate.Text = "";
                //xtdate.Text = "";
                ////xsection.Text = "";
                ////xsubject.Text = "";
                ////xext.Text = "";
                ////xpaper.Text = "";

                ////BindGrid();
                //fnFillGrid2();

                ////fnButtonState();
                /// 

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

        protected void btnGenerate_Click(object sender, EventArgs e)
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
                if (xstdid.Text.Trim().ToString() == "")
                {
                    if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Class</li>";
                        isValid = false;
                    }
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
            
                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                if (xstdid.Text.ToString().Trim() != "")
                {
                    string isStudentFound = zglobal.fnGetValue("xname", "amstudentvwextacc",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xstdid='" +
                        xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() +
                        "'  and zactiveacc=1");

                    if (isStudentFound == "")
                    {
                        message.InnerHtml = "Student not found.";
                        message.Style.Value = zglobal.warningmsg;
                        xstdname.Text = "";
                        xclass.Text = "";
                        //xsection.Text = "";
                        xgroup.Text = "";
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        return;
                    }
                    else
                    {
                        xclass.Text = zglobal.fnGetValue("xclass", "amstudentvwextacc",
                        "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) +
                        " and xstdid='" +
                        xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() +
                        "'  and zactiveacc=1");
                    }

                }

                fnCheckRow();
            //    string xstatus1 = "";
            //    if (ViewState["xrow"] != null)
            //    {
            //        xstatus1 = zglobal.fnGetValue("xstatus", "hrgrowthh",
            //              "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //        if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
            //        {
            //            message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
            //            message.Style.Value = zglobal.warningmsg;
            //            return;
            //        }
            //    }
            //    //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    //{
            //    //    using (DataSet dts = new DataSet())
            //    //    {
            //    //        con.Open();
            //    //        string query =
            //    //            "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";

            //    //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //    //        da.SelectCommand.Parameters.AddWithValue("@zid",_zid);
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xcttype", xcttype.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xctno", xctno.Text.ToString().Trim());



            //    //        DataTable tempTable = new DataTable();
            //    //        da.Fill(dts, "tempTable");
            //    //        tempTable = dts.Tables["tempTable"];

            //    //        if (tempTable.Rows.Count > 0)
            //    //        {
            //    //            ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
            //    //        }
            //    //        else
            //    //        {
            //    //            ViewState["xrow"] = null;
            //    //        }


            //    //    }
            //    //}

            //    ////Duplicate entry check
            //    //if (ViewState["xrow"] != null)
            //    //{
            //    //    message.InnerHtml = "Cann't insert duplicate record.";
            //    //    message.Style.Value = zglobal.warningmsg;
            //    //    return;
            //    //}

                string[] date = new string[2];
                date = xcdate.Text.Split('-');

                int year = Int32.Parse(date[1]);
                int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                DateTime xdate1 = new DateTime(year, month, 1);

                string xtype1 = ViewState["xtype"].ToString();
                string xsession1 = xsession.Text.Trim().ToString();
                string xclass1 = xclass.Text.Trim().ToString();
                string xgroup1 = xgroup.Text.Trim().ToString();
                DateTime xcdate1 = xdate1;
                DateTime xtdate1 = DateTime.Now;
                string xstatus1 = "Confirmed";
                string xremarks1 = "";

                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);

                btnGenerate.Enabled = false;
                btnGenerate1.Enabled = false;

                using (TransactionScope tran = new TransactionScope())
                {
                    
                        using (SqlConnection con = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts = new DataSet())
                            {
                                con.Open();
                                //string query = "SELECT   xrow, xname,xstdid FROM amstudentvw " +
                                //               "WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup";

                                //string query = "SELECT   xrow, xname,xstdid FROM amstudentvw " +
                                //              "WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup";

                                //string query = "SELECT   xrow, xname,xstdid FROM amstudentvwextacc " +
                                //             "WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND   zactiveacc=1 ";

                                //After dropout revenues not generate, here also need to implement admission student not generate revenues before admission date
//                                string query = @"select xrow, xname,xstdid from
//                                                (
//                                                SELECT   xrow, xname,xstdid,
//                                                case when zactiveacc=1 then '2999-12-31' else 
//                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
//                                                end as xdatedrop,
//                                                case when xtype='New' then coalesce((select min(xtdate) from amtfch where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'1900-01-01') else 
//                                                 '1900-01-01'
//                                                end as xdateadmis
//                                                FROM amstudentvwextacc
//                                                WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass
//                                                )tbl
//                                                where month(@xdate)<=month(xdatedrop) and year(@xdate) <= year(xdatedrop) and month(@xdate)>=month(xdateadmis) and year(@xdate) >= year(xdateadmis)";
                                string query = "";

//                                if (xstdid.Text.Trim().ToString() == "")
//                                {
//                                    query = @"select xrow, xname,xstdid from
//                                                (
//                                                SELECT   xrow, xname,xstdid,
//                                                case when zactiveacc=1 then '2999-12-31' else 
//                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
//                                                end as xdatedrop,
//                                                case when xtype='New' then coalesce((select min(xtdate) from amtfch where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'1900-01-01') else 
//                                                 '1900-01-01'
//                                                end as xdateadmis
//                                                FROM amstudentvwextacc
//                                                WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass
//                                                )tbl
//                                                where month(@xdate)<=month(xdatedrop) and year(@xdate) <= year(xdatedrop) and month(@xdate)>=month(xdateadmis) and year(@xdate) >= year(xdateadmis)";
//                                }
//                                else
//                                {
//                                    query = @"select xrow, xname,xstdid from
//                                                (
//                                                SELECT   xrow, xname,xstdid,
//                                                case when zactiveacc=1 then '2999-12-31' else 
//                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
//                                                end as xdatedrop,
//                                                case when xtype='New' then coalesce((select min(xtdate) from amtfch where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'1900-01-01') else 
//                                                 '1900-01-01'
//                                                end as xdateadmis
//                                                FROM amstudentvwextacc
//                                                WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xstdid=@xstdid
//                                                )tbl
//                                                where month(@xdate)<=month(xdatedrop) and year(@xdate) <= year(xdatedrop) and month(@xdate)>=month(xdateadmis) and year(@xdate) >= year(xdateadmis)";
//                                }

//                                if (xstdid.Text.Trim().ToString() == "")
//                                {
//                                    query = @"select xrow, xname,xstdid from
//                                                (
//                                                SELECT   xrow, xname,xstdid,
//                                                case when zactiveacc=1 then '2999-12-31' else 
//                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
//                                                end as xdatedrop,
//                                                case when xtype='New' then coalesce((select min(xtdate) from amtfch where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'1900-01-01') else 
//                                                 '1900-01-01'
//                                                end as xdateadmis
//                                                FROM amstudentvwextacc
//                                                WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass
//                                                )tbl
//                                                where cast(format(cast(@xdate as date),'yyyyMM') as int)<cast(format(xdatedrop,'yyyyMM')  as int)
//                                                and cast(format(cast(@xdate as date),'yyyyMM') as int)>=cast(format(xdateadmis,'yyyyMM')  as int)";
//                                }
//                                else
//                                {
//                                    query = @"select xrow, xname,xstdid from
//                                                (
//                                                SELECT   xrow, xname,xstdid,
//                                                case when zactiveacc=1 then '2999-12-31' else 
//                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
//                                                end as xdatedrop,
//                                                case when xtype='New' then coalesce((select min(xtdate) from amtfch where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'1900-01-01') else 
//                                                 '1900-01-01'
//                                                end as xdateadmis
//                                                FROM amstudentvwextacc
//                                                WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xstdid=@xstdid
//                                                )tbl
//                                                 where cast(format(cast(@xdate as date),'yyyyMM') as int)<cast(format(xdatedrop,'yyyyMM')  as int)
//                                                and cast(format(cast(@xdate as date),'yyyyMM') as int)>=cast(format(xdateadmis,'yyyyMM')  as int)";
//                                }

                                if (xstdid.Text.Trim().ToString() == "")
                                {
                                    query = @"select xrow, xname,xstdid from
                                                (
                                                SELECT   xrow, xname,xstdid,
                                                case when zactiveacc=1 then '2999-12-31' else 
                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
                                                end as xdatedrop,
                                                case when xtype='New' then coalesce((select min(xtdate) from amtfch where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
                                                and xsrow=amstudentvwextacc.xrow),'1900-01-01') else 
                                                 '1900-01-01'
                                                end as xdateadmis
                                                FROM amstudentvwextacc
                                                WHERE zid=@zid AND xsession=@xsession  AND coalesce((select xclass from amdoublepro where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession and xstdid=amstudentvwextacc.xstdid and cast(format(cast(xdate as date),'yyyyMM') as int)>cast(format(cast(@xdate as date),'yyyyMM') as int)),
                                                      coalesce((select xclasspro from amdoublepro where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession and xstdid=amstudentvwextacc.xstdid and cast(format(cast(xdate as date),'yyyyMM') as int)<=cast(format(cast(@xdate as date),'yyyyMM') as int)), xclass)
                                                      )=@xclass
                                                )tbl
                                                where cast(format(cast(@xdate as date),'yyyyMM') as int)<cast(format(xdatedrop,'yyyyMM')  as int)
                                                and cast(format(cast(@xdate as date),'yyyyMM') as int)>=cast(format(xdateadmis,'yyyyMM')  as int)";
                                }
                                else
                                {
                                    query = @"select xrow, xname,xstdid from
                                                (
                                                SELECT   xrow, xname,xstdid,
                                                case when zactiveacc=1 then '2999-12-31' else 
                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
                                                end as xdatedrop,
                                                case when xtype='New' then coalesce((select min(xtdate) from amtfch where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
                                                and xsrow=amstudentvwextacc.xrow),'1900-01-01') else 
                                                 '1900-01-01'
                                                end as xdateadmis
                                                FROM amstudentvwextacc
                                                WHERE zid=@zid AND xsession=@xsession AND coalesce((select xclass from amdoublepro where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession and xstdid=amstudentvwextacc.xstdid and cast(format(cast(xdate as date),'yyyyMM') as int)>cast(format(cast(@xdate as date),'yyyyMM') as int)),
                                                      coalesce((select xclasspro from amdoublepro where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession and xstdid=amstudentvwextacc.xstdid and cast(format(cast(xdate as date),'yyyyMM') as int)<=cast(format(cast(@xdate as date),'yyyyMM') as int)), xclass)
                                                      )=@xclass AND xstdid=@xstdid
                                                )tbl
                                                 where cast(format(cast(@xdate as date),'yyyyMM') as int)<cast(format(xdatedrop,'yyyyMM')  as int)
                                                and cast(format(cast(@xdate as date),'yyyyMM') as int)>=cast(format(xdateadmis,'yyyyMM')  as int)";
                                }


//                                string query = @"select xrow, xname,xstdid from
//                                                (
//                                                SELECT   xrow, xname,xstdid,
//                                                case when zactiveacc=1 then '2999-12-31' else 
//                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
//                                                end as xdatedrop
//                                                FROM amstudentvwextacc
//                                                WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass
//                                                )tbl
//                                                where month(@xdate)<=month(xdatedrop) and year(@xdate) <= year(xdatedrop) ";

//                                string query = @"select xrow, xname,xstdid from
//                                                (
//                                                SELECT   xrow, xname,xstdid,
//                                                case when zactiveacc=1 then '2999-12-31' else 
//                                                coalesce((select xdateacc from amdropout where zid=amstudentvwextacc.zid and xsession=amstudentvwextacc.xsession 
//                                                and xsrow=amstudentvwextacc.xrow),'2999-12-31') 
//                                                end as xdatedrop, xdateadmis
//                                                FROM amstudentvwextacc
//                                                WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass
//                                                )tbl
//                                                where month(@xdate)<=month(xdatedrop) and year(@xdate) <= year(xdatedrop) and month(@xdate)>=month(xdateadmis) and year(@xdate) >= year(xdateadmis)";


                                SqlDataAdapter da = new SqlDataAdapter(query, con);

                                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                                da.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid.Text.ToString().Trim());
                                //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());

                                DataTable tempTable = new DataTable();
                                da.Fill(dts, "tempTable");
                                tempTable = dts.Tables["tempTable"];

                                if (tempTable.Rows.Count > 0)
                                {
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.Connection = con;

                                    if (ViewState["xrow"] == null)
                                    {
                                         
                                           

                                            DateTime ztime = DateTime.Now;
                                            DateTime zutime = DateTime.Now;
                                            _zid =
                                                Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                            xrow = 0;
                                            query =
                                    "INSERT INTO amtfcdueh (ztime,zid,xrow,xtype,xsession,xclass,xgroup,xcdate,xtdate,xstatus,zemail,xremarks) " +
                                    "VALUES(@ztime,@zid,@xrow,@xtype,@xsession,@xclass,@xgroup,@xcdate,@xtdate,@xstatus,@zemail,@xremarks) ";

                                            xrow = zglobal.GetMaximumInvoiceResetMonthlyBusiness("xcdate","xrow","amtfcdueh",xcdate1);
                                            ViewState["xrow"] = xrow;
                                            hiddenxrow.Value = xrow.ToString();
                                            xtdate1 = xtdate.Text.ToString().Trim() != string.Empty
                                                ? DateTime.ParseExact(xtdate.Text.ToString().Trim(), "dd/MM/yyyy",
                                                    CultureInfo.InvariantCulture)
                                                : DateTime.Now;

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@ztime", ztime);
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xrow", xrow);
                                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                                            cmd.Parameters.AddWithValue("@xsession", xsession1);
                                            cmd.Parameters.AddWithValue("@xclass", xclass1);
                                            cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                                            cmd.Parameters.AddWithValue("@xcdate", xcdate1);
                                            //cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                                            cmd.Parameters.AddWithValue("@xtdate", xcdate1);
                                            cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                                            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                                            cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        query = "UPDATE amtfcdueh SET zutime=@zutime,xemail=@xemail WHERE zid=@zid AND xrow=@xrow";
                                        cmd.Parameters.Clear();

                                        cmd.CommandText = query;
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@xemail", xemail1);
                                        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                        cmd.ExecuteNonQuery();
                                        
                                    }

                                    //Delete from details table
                                    if (xstdid.Text.Trim().ToString() == "")
                                    {
                                        query = "DELETE FROM amtfcdued WHERE zid=@zid AND xrow=@xrow";
                                    }
                                    else
                                    {
                                        query = "DELETE FROM amtfcdued WHERE zid=@zid AND xrow=@xrow AND xsrow=(select xrow from amadmis where zid=@zid and xstdid=@xstdid)"; 
                                    }
                                    
                                    cmd.Parameters.Clear();
                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                    cmd.Parameters.AddWithValue("@xstdid", xstdid.Text.Trim().ToString());
                                    cmd.ExecuteNonQuery();

                                    //Insert into details table

                                    date = new string[2];
                                    if (xcdate.Text.ToString().Trim() == "")
                                    {
                                        date[0] = "Jan";
                                        date[1] = "1800";
                                    }
                                    else
                                    {
                                        date = xcdate.Text.Split('-');
                                    }

                                    year = Int32.Parse(date[1]);
                                    month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                                    DateTime xeffdate1 = new DateTime(year, month, 1);



                                    //foreach (DataRow row in tempTable.Rows)
                                    for(int i=0;i<tempTable.Rows.Count;i++)
                                    {
                                        query = zglobal.xtfcdefault1;

                                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                        da1.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
                                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                                        da1.SelectCommand.Parameters.AddWithValue("@xsrow", Convert.ToInt64(tempTable.Rows[i]["xrow"].ToString()));
                                        DataSet dts1 = new DataSet();
                                        dts1.Reset();
                                        da1.Fill(dts1, "tempztcode");
                                        DataTable dtamtfccode = new DataTable();
                                        dtamtfccode = dts1.Tables[0];
                                        Int64 xsrow1 = Convert.ToInt64(tempTable.Rows[i]["xrow"]);
                                        //message.InnerHtml = message.InnerHtml + tempTable.Rows[i]["xrow"].ToString();

                                        if (dtamtfccode.Rows.Count > 0)
                                        {
                                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                            {
                                                using (DataSet dts11 = new DataSet())
                                                {
                                                    string query1 = zglobal.fntfcSpecialDiscount();
                                                    SqlDataAdapter da11 = new SqlDataAdapter(query1, conn);
                                                    da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                                    da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                                    da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                                    da11.SelectCommand.Parameters.AddWithValue("@xsrow", Convert.ToInt64(tempTable.Rows[i]["xrow"].ToString()));
                                                    da11.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
                                                    da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                                                    da11.Fill(dts11, "tblamadmisd");
                                                    DataTable amexamd11 = dts11.Tables[0];
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

                                            //foreach (DataRow rowtfc in dtamtfccode.Rows)
                                            for (int j = 0; j < dtamtfccode.Rows.Count; j++)
                                            {
                                                //query = "INSERT INTO amtfcdued (zid,xrow,xline,xtfccode,xamount,xdisfixed,xdisperc,xdiscount,xvatfixed,xvatperc,xvat,xamtdue,xremarks,xsrow) " +
                                                //        "VALUES(@zid,@xrow,@xline,@xtfccode,@xamount,@xdisfixed,@xdisperc,@xdiscount,@xvatfixed,@xvatperc,@xvat,(xamount-xdiscount+xvat),@xremarks,@xsrow) ";

                                                if (dtamtfccode.Rows[j]["xtype1"].ToString() == "Single")
                                                {
                                                    string xstudenttype = zglobal.fnGetValue("xtype", "amstudentvwextacc",
                                                         "zid=" + _zid + " AND xsession='" + xsession.Text.Trim().ToString() + "' AND xrow=" + xsrow1);

                                                    if (xstudenttype != "New")
                                                    {
                                                        continue;
                                                    }

                                                    query = "select * from amtfcdueh as h inner join amtfcdued as d on  h.zid=d.zid and h.xrow=d.xrow " +
                                                            "where h.zid=@zid  and d.xsrow=@xsrow and d.xtfccode=@xtfccode and xtype='Auto Generated'";

                                                    SqlDataAdapter da2 = new SqlDataAdapter(query, con);

                                                    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                                    da2.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow1);
                                                    da2.SelectCommand.Parameters.AddWithValue("@xtfccode", dtamtfccode.Rows[j]["xtfccode"]);

                                                    DataSet dts2 = new DataSet();
                                                    dts2.Reset();
                                                    da2.Fill(dts2, "tempztcode");
                                                    DataTable dttemp1 = new DataTable();
                                                    dttemp1 = dts2.Tables[0];
                                                    da2.Dispose();
                                                    if (dttemp1.Rows.Count > 0)
                                                    {
                                                        dttemp1.Dispose();
                                                        dts2.Dispose();
                                                        continue;
                                                    }
                                                    //else
                                                    //{
                                                    //    query = "INSERT INTO amtfcdued (zid,xrow,xline,xtfccode,xamount,xdisfixed,xdisperc,xdiscount,xvatfixed,xvatperc,xvat,xamtdue,xremarks,xsrow) " +
                                                    //            "VALUES(@zid,@xrow,@xline,@xtfccode,@xamount,@xdisfixed,@xdisperc,@xdiscount,@xvatfixed,@xvatperc,@xvat,(xamount-xdiscount+xvat),@xremarks,@xsrow) ";
                                                    //}
                                                    dttemp1.Dispose();
                                                    dts2.Dispose();

                                                }
                                                else if (dtamtfccode.Rows[j]["xtype1"].ToString() == "Yearly")
                                                {
                                                    //query = "select * from amtfcdueh as h inner join amtfcdued as d on  h.zid=d.zid and h.xrow=d.xrow " +
                                                    //        "where h.zid=@zid  and d.xsrow=@xsrow and d.xtfccode=@xtfccode and xsession=@xsession and " +
                                                    //        "xclass=@xclass and xgroup=@xgroup and xtype='Auto Generated'";

                                                    //query = "select * from amtfcdueh as h inner join amtfcdued as d on  h.zid=d.zid and h.xrow=d.xrow " +
                                                    //       "where h.zid=@zid  and d.xsrow=@xsrow and d.xtfccode=@xtfccode and xsession=@xsession and " +
                                                    //       "xclass=@xclass and xtype='Auto Generated'";

                                                    query = "select * from amtfcdueh as h inner join amtfcdued as d on  h.zid=d.zid and h.xrow=d.xrow " +
                                                          "where h.zid=@zid  and d.xsrow=@xsrow and d.xtfccode=@xtfccode and xsession=@xsession and " +
                                                          "xtype='Auto Generated'";

                                                    SqlDataAdapter da2 = new SqlDataAdapter(query, con);

                                                    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                                    da2.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow1);
                                                    da2.SelectCommand.Parameters.AddWithValue("@xtfccode", dtamtfccode.Rows[j]["xtfccode"]);
                                                    da2.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                                                    //da2.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.Trim().ToString());
                                                    //da2.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.Trim().ToString());

                                                    DataSet dts2 = new DataSet();
                                                    dts2.Reset();
                                                    da2.Fill(dts2, "tempztcode");
                                                    DataTable dttemp1 = new DataTable();
                                                    dttemp1 = dts2.Tables[0];
                                                    da2.Dispose();
                                                    if (dttemp1.Rows.Count > 0)
                                                    {
                                                        dttemp1.Dispose();
                                                        dts2.Dispose();
                                                        continue;
                                                    }
                                                    //else
                                                    //{
                                                    //    query = "INSERT INTO amtfcdued (zid,xrow,xline,xtfccode,xamount,xdisfixed,xdisperc,xdiscount,xvatfixed,xvatperc,xvat,xamtdue,xremarks,xsrow) " +
                                                    //            "VALUES(@zid,@xrow,@xline,@xtfccode,@xamount,@xdisfixed,@xdisperc,@xdiscount,@xvatfixed,@xvatperc,@xvat,(xamount-xdiscount+xvat),@xremarks,@xsrow) ";
                                                    //}
                                                    dttemp1.Dispose();
                                                    dts2.Dispose();

                                                }
                                                else if (dtamtfccode.Rows[j]["xtype1"].ToString() == "N/A")
                                                {
                                                    continue;
                                                }
                                                //else
                                                //{
                                                query = "INSERT INTO amtfcdued (zid,xrow,xline,xtfccode,xamount,xdisfixed,xdisperc,xdiscount,xvatfixed,xvatperc,xvat,xamtdue,xremarks,xsrow,xspecialdisperc,xspecialdisfixed,xclassd) " +
                                                            "VALUES(@zid,@xrow,@xline,@xtfccode,@xamount,@xdisfixed,@xdisperc,@xdiscount,@xvatfixed,@xvatperc,@xvat,@xamtdue,@xremarks,@xsrow,@xspecialdisperc,@xspecialdisfixed,@xclassd) ";
                                                //}

                                                int xline = zglobal.GetMaximumIdInt("xline", "amtfcdued", " zid=" + _zid + " and xrow=" + Convert.ToInt32(ViewState["xrow"]), "line");

                                                decimal xamtdue1 = Convert.ToDecimal(dtamtfccode.Rows[j]["xamount"]) -
                                                                   Convert.ToDecimal(dtamtfccode.Rows[j]["xdiscount"]) +
                                                                   Convert.ToDecimal(dtamtfccode.Rows[j]["xvat"]);
                                                decimal xspecialdisperc1 = 0;
                                                decimal xspecialdisfixed1 = 0;

                                                if (ViewState["amtfcspecialdis"] != null)
                                                {
                                                    DataRow[] result80 =
                                                              ((DataTable)ViewState["amtfcspecialdis"]).Select("xtfccode=" + dtamtfccode.Rows[j]["xtfccode"]);

                                                    if (result80.Length > 0)
                                                    {
                                                        if (result80[0]["xdisperc"].ToString() == "0.00" ||
                                                            result80[0]["xdisperc"].ToString() == "0")
                                                        {
                                                            xspecialdisfixed1 = Convert.ToDecimal(result80[0]["xdisfixed"].ToString());
                                                            xamtdue1 = xamtdue1 - xspecialdisfixed1;
                                                        }
                                                        else
                                                        {
                                                            xspecialdisperc1 = Convert.ToDecimal(result80[0]["xdisperc"].ToString());
                                                            xamtdue1 = xamtdue1 - (xspecialdisperc1 * xamtdue1 / 100);
                                                        }
                                                    }
                                                }

                                                cmd.CommandText = query;
                                                cmd.Parameters.Clear();
                                                cmd.Parameters.AddWithValue("@zid", _zid);
                                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                                cmd.Parameters.AddWithValue("@xline", xline);
                                                cmd.Parameters.AddWithValue("@xtfccode", dtamtfccode.Rows[j]["xtfccode"]);
                                                cmd.Parameters.AddWithValue("@xamount", dtamtfccode.Rows[j]["xamount"]);
                                                cmd.Parameters.AddWithValue("@xdisfixed", dtamtfccode.Rows[j]["xdisfixed"]);
                                                cmd.Parameters.AddWithValue("@xdisperc", dtamtfccode.Rows[j]["xdisperc"]);
                                                cmd.Parameters.AddWithValue("@xdiscount", dtamtfccode.Rows[j]["xdiscount"]);
                                                cmd.Parameters.AddWithValue("@xvatfixed", dtamtfccode.Rows[j]["xvatfixed"]);
                                                cmd.Parameters.AddWithValue("@xvatperc", dtamtfccode.Rows[j]["xvatperc"]);
                                                cmd.Parameters.AddWithValue("@xvat", dtamtfccode.Rows[j]["xvat"]);
                                                cmd.Parameters.AddWithValue("@xamtdue", xamtdue1);
                                                cmd.Parameters.AddWithValue("@xspecialdisperc", xspecialdisperc1);
                                                cmd.Parameters.AddWithValue("@xspecialdisfixed", xspecialdisfixed1);
                                                cmd.Parameters.AddWithValue("@xremarks", "");
                                                cmd.Parameters.AddWithValue("@xsrow", xsrow1);
                                                cmd.Parameters.AddWithValue("@xclassd", xclass.Text.Trim().ToString());
                                                cmd.ExecuteNonQuery();


                                            }
                                        }

                                        dtamtfccode.Dispose();
                                        da1.Dispose();
                                        dts1.Dispose();
                                    }

                                    
                                }
                                else
                                {
                                    message.InnerHtml = "No student found.";
                                    message.Style.Value = zglobal.warningmsg;
                                    btnGenerate.Enabled = true;
                                    btnGenerate1.Enabled = true;
                                    return;
                                }
                            }
                        }
                    

                    tran.Complete();

                }

                btnGenerate.Enabled = true;
                btnGenerate1.Enabled = true;
                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                // btnRefresh_Click(null, null);
                message.InnerHtml = zglobal.gensuccmsg;
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
                btnGenerate.Enabled = true;
                btnGenerate1.Enabled = true;
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


    }
}