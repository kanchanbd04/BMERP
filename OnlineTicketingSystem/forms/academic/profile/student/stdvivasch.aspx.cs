using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


namespace OnlineTicketingSystem.forms.academic.admission
{
    public partial class stdvivasch : System.Web.UI.Page
    {

        private void fnGridVisibleProp(string _grid)
        {

            if (_grid == _grid_admis_test.ID)
            {
                _grid_admis_test.Visible = true;
            }
            else
            {
                _grid_admis_test.Visible = false;
            }

            if (_grid == _grid_admis_res.ID)
            {
                _grid_admis_res.Visible = true;
            }
            else
            {
                _grid_admis_res.Visible = false;
            }
            if (_grid == _grid_admis_stdinfo.ID)
            {
                _grid_admis_stdinfo.Visible = true;
            }
            else
            {
                _grid_admis_stdinfo.Visible = false;
            }

        }

        private int flag1 = 0;
        protected void Page_Init(object o, EventArgs e)
        {
            try
            {
                zglobal.calculateage = zglobal.fnDefaults("xstdageday", "Student") + "/" +
                                       zglobal.fnDefaults("xstdagemonth", "Student") + "/1999";
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            //dtmarks.Reset();
            //if ((xclass_res.Text != "" || xclass_res.Text != string.Empty || xclass_res.Text != "[Select]"))
            //{
            //    fnCreateConteolMarks(xclass_res.Text.ToString());
            //    //flag1 = 0;
            //}
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //if ((xclass_res.Text != "" || xclass_res.Text != string.Empty || xclass_res.Text != "[Select]"))
            //{
            //    fnCreateConteolMarks(xclass_res.Text.ToString());
            //    //flag1 = 0;
            //}
        }
        protected void Page_Render(object sender, EventArgs e)
        {
            //if ((xclass_res.Text != "" || xclass_res.Text != string.Empty || xclass_res.Text != "[Select]"))
            //{
            //    fnCreateConteolMarks(xclass_res.Text.ToString());
            //    //flag1 = 0;
            //}
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //if ((xclass_res.Text != "" || xclass_res.Text != string.Empty || xclass_res.Text != "[Select]"))
            //{
            //    fnCreateConteolMarks(xclass_res.Text.ToString());
            //    //flag1 = 0;
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    TabContainer1.ActiveTabIndex = 1;
                    //getActiveTabIndex.Value = "1";
                    //fnGridVisibleProp("_grid_admis_res");

                    list.Visible = false;
                    list_res.Visible = true;
                    // _grid_header_res.InnerHtml = "Marks Obtained";
                    fnGridVisibleProp("_grid_admis_res");
                    //_grid_admis_res.DataSource = null;
                    //_grid_admis_res.DataBind();
                    getActiveTabIndex.Value = "1";
                    type.Value = "out";
                    TabContainer1.Height = 140;

                    fnButtonVisible();

                    //xsession_res.Text = "";
                    //xnumexam.Text = "";
                    //xexamdate_res.Text = "";
                    //xclass_res.Text = "";
                    //xtotalmaks.Text = "";
                    //xpassmarks.Text = "";
                    //xexamroll_res.Text = "";
                    //xname_res.Text = "";
                    //xmother_res.Text = "";
                    //xfather_res.Text = "";
                    // xpassmethod.Text = "";
                    btnPrint.Visible = false;



                    _row.Value = "";
                    //    type.Value = "day_o";
                    //DateTime calage = DateTime.ParseExact(zglobal.calculateage, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //string[] ordinals = new string[] { "", "st", "nd", "rd", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "st", "nd", "rd", "th", "th", "th", "th", "th", "th", "th", "st" };
                    //lblAge.Text = string.Format("Age ({0}{1} {2}) :", calage.Day.ToString(), ordinals[calage.Day], calage.ToString("MMMM"));
                    _gridrow.Text = zglobal._grid_row_value;
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Nationality", xnation);
                    //zglobal.fnGetComboDataCD("Religion", xreligion);
                    //zglobal.fnGetComboDataCD("Gender", xgender);
                    //zglobal.fnGetComboDataCD("Session", grid_xsession);
                    //zglobal.fnGetComboDataCD("Class", grid_xclass);
                    zglobal.fnGetComboDataCD("Session", xsession_res);
                    zglobal.fnGetComboDataCD("Class", xclass_res);
                    //zglobal.fnGetComboDataCD("No of Exam", xnumexam);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Blood Group", xblood);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    zglobal.fnGetComboDataCD("Education Group", xgroup_res);
                    //zglobal.fnGetComboDataCD("Profession", xprofession);
                    //zglobal.fnGetComboDataCD("Profession", xprofession1);
                    //zglobal.fnGetComboDataCD("Exam Venue", xexamvenue);
                    //xcellnom.Text = "+880";
                    //xcellno1f.Text = "+880";
                    //xcontact.Text = "+880";
                    //xgroup.Items.Clear();
                    //xgroup.Items.Add("");
                    //xgroup.Items.Add("Science");
                    //xgroup.Items.Add("Commerce");
                    //xgroup.Text = "";

                    //xnumexam.Items.Clear();
                    //xnumexam.Items.Add("");
                    //xnumexam.Items.Add("1st");
                    //xnumexam.Items.Add("2nd");
                    //xnumexam.Items.Add("3rd");
                    //xnumexam.Items.Add("4th");
                    //xnumexam.Items.Add("5th");
                    //xnumexam.Items.Add("6th");
                    //xnumexam.Items.Add("7th");
                    //xnumexam.Items.Add("8th");
                    //xnumexam.Items.Add("9th");
                    //xnumexam.Items.Add("10th");
                    //xnumexam.Text = "";

                    //xnumexam_res.Items.Clear();
                    //xnumexam_res.Items.Add("");
                    //xnumexam_res.Items.Add("1st");
                    //xnumexam_res.Items.Add("2nd");
                    //xnumexam_res.Items.Add("3rd");
                    //xnumexam_res.Items.Add("4th");
                    //xnumexam_res.Items.Add("5th");
                    //xnumexam_res.Items.Add("6th");
                    //xnumexam_res.Items.Add("7th");
                    //xnumexam_res.Items.Add("8th");
                    //xnumexam_res.Items.Add("9th");
                    //xnumexam_res.Items.Add("10th");
                    //xnumexam_res.Text = "";

                    zglobal.fnGetComboDataCD("No of Exam", xnumexam_res);

                    //xhour.Items.Clear();
                    //xhour.Items.Add("");
                    //for (int i = 1; i <= 12; i++)
                    //{
                    //    xhour.Items.Add(i < 10 ? "0" + i.ToString() : i.ToString());
                    //}
                    //xhour.Text = "09";

                    //xminitue.Items.Clear();
                    //xminitue.Items.Add("");
                    //for (int i = 0; i < 60; i++)
                    //{
                    //    xminitue.Items.Add(i < 10 ? "0" + i.ToString() : i.ToString());
                    //}
                    //xminitue.Text = "00";

                    //xperiod.Items.Clear();
                    //xperiod.Items.Add("");
                    //xperiod.Items.Add("AM");
                    //xperiod.Items.Add("PM");
                    //xperiod.Text = "AM";
                    //xpassmethod.Items.Add("");
                    //xpassmethod.Items.Add("All Subjects");
                    //xpassmethod.Items.Add("Single Subject");
                    //xpassmethod.Text = "";
                    flag.Value = "0";

                    //Default's Value
                    //xnation.Text = "Bangladeshi";
                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //xexamvenue.Text = zglobal.fnDefaults("xexamvenue", "Student").Trim().ToString();
                    //xsession_res.Text = zglobal.fnDefaults("xsession", "Student");
                    xsession_res.Text = zglobal.fnDefaults("xsessiononline", "Student");

                    //list.Visible = true;
                    //list_res.Visible = false;

                    xschfor.Items.Add("");
                    xschfor.Items.Add("Qualified");
                    xschfor.Items.Add("Waiting");
                    xschfor.Text = "";

                    TabContainer1.Tabs[0].Visible = false;
                    TabContainer1.Tabs[2].Visible = false;
                    TabContainer1.Tabs[3].Visible = false;
                    btnApproved.Visible = false;

                }
                catch (Exception exp)
                {
                    message.InnerHtml = exp.Message;
                }

            }

            
            try
            {

                if (TabContainer1.ActiveTabIndex == 1)
                {

                    BindGrid();
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }

        }



        public void fnFillDataGrid(object sender, EventArgs e)
        {
            try
            {
                if (grid_xsession.Text == "" || grid_xsession.Text == string.Empty || grid_xsession.Text == "[Select]")
                {
                    message.InnerHtml = "Please Select Session";
                    return;
                }
                if (grid_xclass.Text == "" || grid_xclass.Text == string.Empty || grid_xclass.Text == "[Select]")
                {
                    message.InnerHtml = "Please Select Class";
                    return;
                }

                message.InnerHtml = "";
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                string str = "";
                dts.Reset();
                GridView grid = new GridView();
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xname,xexamroll,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender FROM amadmis where zid=@zid and xsession=@xsession and xclass=@xclass ORDER BY xrow DESC";
                    grid = _grid_admis_test;
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xname,xexamroll,xexamdate,xexamvenue,xcontact FROM amadmis where zid=@zid and xsession=@xsession and xclass=@xclass ORDER BY xrow DESC";
                    grid = _grid_admis_res;
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xstdid,xname,xmname,xfname,xcontact FROM amadmis where zid=@zid and xsession=@xsession and xclass=@xclass ORDER BY xrow DESC";
                    grid = _grid_admis_stdinfo;
                }
                //else if (TabContainer1.ActiveTabIndex == 2)
                //{
                //    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xdate,xfdate,xallconvenor,xcoconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                //    grid = _grid_sport;
                //}
                //else if (TabContainer1.ActiveTabIndex == 3)
                //{
                //    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xexam,xfclass,xfdate,xtdate,xresultdate,xconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                //    grid = _grid_exam;
                //}
                //else if (TabContainer1.ActiveTabIndex == 4)
                //{
                //    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xname,xfclass,xtclass,xffdate,xtdate,xresultdate,xconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                //    grid = _grid_other;
                //}

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xtype = type.Value;
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xsession", grid_xsession.Text.Trim().ToString());
                da.SelectCommand.Parameters.AddWithValue("@xclass", grid_xclass.Text.Trim().ToString());
                da.Fill(dts, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];
                if (dtztcode.Rows.Count > 0)
                {
                    grid.DataSource = dtztcode;
                    grid.DataBind();
                }
                else
                {
                    grid.DataSource = null;
                    grid.DataBind();
                }





                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnClearGrid(object sender, EventArgs e)
        {
            try
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                xtotalmaks.Text = "";
                xpassmarks.Text = "";
                message.InnerHtml = "";
                xnumexam_res.Text = "";
                xexamdate_res.Text = "";
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        protected void fnGetDate(object sender, EventArgs e)
        {
            try
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                xtotalmaks.Text = "";
                xpassmarks.Text = "";
                xexamdate_res.Text = fnGetExamDate() == DateTime.Today ? "" : fnGetExamDate().ToString("dd/MM/yyyy");
                message.InnerHtml = "";
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        private DateTime fnGetExamDate()
        {
            DateTime date = DateTime.Today;

            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    string xsession1 = xsession_res.Text.Trim().ToString();
                    string xnumexam1 = xnumexam_res.Text.Trim().ToString();
                    string xclass1 = xclass_res.Text.Trim().ToString();
                    string xgroup1 = xgroup_res.Text.Trim().ToString();
                    string query = "select top 1 cast(coalesce(xexamdate,getdate()) as date) from amadmis where zid=@zid and xsession=@xsession and xclass=@xclass and xgroup=@xgroup and xnumexam=@xnumexam";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                    da.SelectCommand.Parameters.AddWithValue("@xnumexam", xnumexam1);
                    da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                    da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                    da.Fill(dts, "tempztcode");
                    DataTable dtexam = new DataTable();
                    dtexam = dts.Tables[0];
                    if (dtexam.Rows.Count > 0)
                    {
                        date = Convert.ToDateTime(dtexam.Rows[0][0]);
                    }
                }
            }

            return date;
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;

        private void BindGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string xsession1 = xsession_res.Text.Trim().ToString();
            string xnumexam1 = xnumexam_res.Text.Trim().ToString();
            string xclass1 = xclass_res.Text.Trim().ToString();
            string xgroup1 = xgroup_res.Text.Trim().ToString();
            string xstatus2 = xschfor.Text.Trim().ToString();
            if (xstatus2 == "Qualified")
            {
                xstatus2 = "Approved";
            }
            else if (xstatus2 == "Waiting")
            {
                xstatus2 = "Waiting";
            }
            else
            {
                xstatus2 = "undefined";
            }
            string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xrow) AS xid, xname, xexamroll, coalesce(xstatus,'n') AS xstatus,xfname,coalesce(xremarks,'') as xremarks,coalesce(xstatus1,'n') AS xstatus1,coalesce(xvivadate,'') as xvivadate,coalesce(xhour1,'') as xhour1,coalesce(xminitue1,'') as xminitue1,coalesce(xperiod1,'') as xperiod1,coalesce(xexamvenue1,'') as xexamvenue1 FROM amadmis WHERE zid=@zid AND xsession=@xsession AND xnumexam=@xnumexam AND xclass=@xclass AND xgroup=@xgroup AND xstatus=@xstatus";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            da.SelectCommand.Parameters.AddWithValue("@xnumexam", xnumexam1);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            da.SelectCommand.Parameters.AddWithValue("@xstatus", xstatus2);
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {
                ////Disable update button
                //if (dtmarks.Rows[0]["xstatus"].ToString() != "n")
                //{
                //    btnEdit.Enabled = false;
                //    btnApproved.Enabled = false;
                //}
                //else
                //{
                //    btnEdit.Enabled = true;
                //    btnApproved.Enabled = true;
                //}
                //int i = 1;
                //totmarks = 0;
                //int tmarks = 0;
                //int passm = 0;
                //foreach (DataRow row in dtmarks.Rows)
                //{
                //    //fnCreateControl(i, row, _zid, xrow, xclass1);
                //    i = i + 1;
                //    tmarks = tmarks + Convert.ToInt32(row["xmark"].ToString());
                //    passm = passm + Convert.ToInt32(row["xpassmark"].ToString());
                //}

                //xtotalmaks.Text = tmarks.ToString();
                //int pass = (100 * passm) / tmarks;
                //xpassmarks.Text = pass.ToString();


                DataSet dts2 = new DataSet();

                dts2.Reset();

                DateTime xexamdate1 = fnGetExamDate();
                string str2 = "SELECT xsubject,xmark, xpassmark FROM  ammarks " +
                             "WHERE zid=@zid AND xclass=@xclass  AND xtype='admistest' AND " +
                             "xeffdate=(SELECT MAX(xeffdate)FROM ammarks WHERE zid=@zid and xclass=@xclass and xgroup=@xgroup " +
                             "and xeffdate<=@xexamdate and xtype='admistest' AND zactive=1 AND xstatus='Approved' ) AND zactive=1 AND xstatus='Approved' AND xgroup=@xgroup";

                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn1);
                da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da2.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                da2.SelectCommand.Parameters.AddWithValue("@xexamdate", xexamdate1);
                da2.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                da2.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                da2.Fill(dts2, "tempztcode");
                DataTable dtmarks2 = new DataTable();
                dtmarks2 = dts2.Tables[0];
                if (dtmarks2.Rows.Count > 0)
                {
                    
                    GridView1.Columns.Clear();
                    //Change Index
                    ViewState["numrow"] = dtmarks2.Rows.Count;

                    bfield = new BoundField();
                    bfield.HeaderText = "No.";
                    bfield.DataField = "xid";
                    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bfield.ItemStyle.Width = 35;
                    GridView1.Columns.Add(bfield);

                    bfield = new BoundField();
                    bfield.HeaderText = "Name of Candidate";
                    bfield.DataField = "xname";
                    bfield.ItemStyle.Width = 200;
                    GridView1.Columns.Add(bfield);

                    bfield = new BoundField();
                    bfield.HeaderText = "Roll";
                    bfield.DataField = "xexamroll";
                    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bfield.ItemStyle.Width = 35;
                    GridView1.Columns.Add(bfield);

                    bfield = new BoundField();
                    bfield.HeaderText = "Father's Name";
                    bfield.DataField = "xfname";
                    bfield.ItemStyle.Width = 200;
                    GridView1.Columns.Add(bfield);


                    int tmarks = 0;
                    int passm = 0;
                    dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[3] { 
                        new DataColumn("xsubject", typeof(string)),
                        new DataColumn("xmark", typeof(string)),
                        new DataColumn("xpassmark",typeof(string)) });
                    foreach (DataRow row in dtmarks2.Rows)
                    {
                        tfield = new TemplateField();
                        tfield.HeaderText = row["xsubject"].ToString() + " (" + row["xmark"].ToString() + ")";
                        //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        tfield.ItemStyle.Width = 50;
                        GridView1.Columns.Add(tfield);
                        tfield.Visible = false;
                        tmarks = tmarks + Convert.ToInt32(row["xmark"].ToString());
                        passm = passm + Convert.ToInt32(row["xpassmark"].ToString());
                        dt.Rows.Add(row["xsubject"].ToString(), row["xmark"].ToString(), row["xpassmark"].ToString());
                    }

                    xtotalmaks.Text = tmarks.ToString();
                    int pass = (100 * passm) / tmarks;
                    xpassmarks.Text = pass.ToString() + "%";

                    tfield = new TemplateField();
                    tfield.HeaderText = "Total Marks";
                    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield.ItemStyle.Width = 70;
                    GridView1.Columns.Add(tfield);
                    tfield.Visible = false;

                    tfield = new TemplateField();
                    tfield.HeaderText = "%";
                    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield.ItemStyle.Width = 70;
                    GridView1.Columns.Add(tfield);
                    tfield.Visible = false;

                    BoundField bfield1 = new BoundField();
                    bfield1.HeaderText = "Ref. No.";
                    bfield1.DataField = "xrow";
                    bfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bfield1.ItemStyle.Width = 50;
                    //bfield.Visible = false;
                    GridView1.Columns.Add(bfield1);

                    BoundField bfield2 = new BoundField();
                    bfield2.HeaderText = "Status";
                    bfield2.DataField = "xstatus";
                    bfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bfield2.ItemStyle.Width = 50;
                    //bfield.Visible = false;
                    GridView1.Columns.Add(bfield2);

                    TemplateField tfield1 = new TemplateField();
                    tfield1.HeaderText = "Remarks";
                    tfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //tfield1.ItemStyle.Width = 70;
                    GridView1.Columns.Add(tfield1);
                    tfield1.Visible = false;

                    TemplateField tfield2 = new TemplateField();
                    tfield2.HeaderText = "Qualified?";
                    tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield2.ItemStyle.Width = 20;
                    GridView1.Columns.Add(tfield2);
                    tfield2.Visible = false;

                    TemplateField tfield3 = new TemplateField();
                    tfield3.HeaderText = "Date";
                    tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield3.ItemStyle.Width = 150;
                    GridView1.Columns.Add(tfield3);

                    tfield3 = new TemplateField();
                    tfield3.HeaderText = "Time";
                    tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    tfield3.ItemStyle.Width = 170;
                    GridView1.Columns.Add(tfield3);

                    tfield3 = new TemplateField();
                    tfield3.HeaderText = "Exam Vanue";
                    tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield3.ItemStyle.Width = 200;
                    GridView1.Columns.Add(tfield3);



                    BoundField bfield3 = new BoundField();
                    bfield3.HeaderText = "Status1";
                    bfield3.DataField = "xstatus1";
                    bfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bfield3.ItemStyle.Width = 50;
                    //bfield.Visible = false;
                    GridView1.Columns.Add(bfield3);


                    TemplateField tfield70 = new TemplateField();
                    tfield70.HeaderText = "";
                    tfield70.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //tfield1.ItemStyle.Width = 70;
                    GridView1.Columns.Add(tfield70);

                 

                    GridView1.DataSource = dtmarks;
                    GridView1.DataBind();

                    bfield1.Visible = false;
                    bfield2.Visible = false;
                    bfield3.Visible = false;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    xtotalmaks.Text = "";
                    xpassmarks.Text = "";
                    ViewState["numrow"] = null;
                }

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                xtotalmaks.Text = "";
                xpassmarks.Text = "";
                ViewState["numrow"] = null;
            }

            //dtmarks.Reset();
            //ViewState["ctladded"] = dtmarks.Rows.Count;

        }

        TextBox txTextBox;
        Label lblSub;
        Label lblMarks;
        Label lblPass;
        CheckBox chkCheckBox;
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int i = 0;
                    string xst = (e.Row.DataItem as DataRowView).Row["xstatus"].ToString();
                    string xst1 = (e.Row.DataItem as DataRowView).Row["xstatus1"].ToString();
                    Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    DataTable tblamadmisd = new DataTable(); 
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            string query = "SELECT * FROM amadmisd WHERE zid=@zid AND xrow=@xrow";
                            SqlDataAdapter da = new SqlDataAdapter(query,conn);
                            da.SelectCommand.Parameters.AddWithValue("zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("xrow", xrow);
                            da.Fill(dts, "tblamadmisd");
                            //tblamadmisd = new DataTable();
                            tblamadmisd = dts.Tables[0];
                        }
                    }
                    int j = 0;
                    int totmark = 0;
                    //Change Index
                    for (i = 4; i < 4 + (int)ViewState["numrow"]; i++)
                    {
                        txTextBox = new TextBox();
                        txTextBox.ID = "txtSub" + i.ToString();
                        txTextBox.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                        e.Row.Cells[i].Controls.Add(txTextBox);
                        if (xst != "n")
                        {
                            txTextBox.Enabled = false;
                        }

                        if (tblamadmisd.Rows.Count > 0)
                        {
                            
                            foreach (DataRow row in tblamadmisd.Rows)
                            {
                                if (row["xsubject"].ToString() == dt.Rows[j][0].ToString())
                                {
                                    txTextBox.Text = row["xgetmark"].ToString();
                                    totmark = totmark + Int32.Parse(row["xgetmark"].ToString());
                                    break;
                                }
                            }
                        }
                        //lblSub = new Label();
                        //lblSub.ID = "lblSub" + i.ToString();
                        //lblSub.Text = dt.Rows[j][0].ToString();
                        //lblSub.Visible = false;
                        //e.Row.Cells[i].Controls.Add(lblSub);

                        //lblMarks = new Label();
                        //lblMarks.ID = "lblMarks" + i.ToString();
                        //lblMarks.Text = dt.Rows[j][1].ToString();
                        //lblMarks.Visible = false;
                        //e.Row.Cells[i].Controls.Add(lblMarks);

                        //lblPass = new Label();
                        //lblPass.ID = "lblPass" + i.ToString();
                        //lblPass.Text = dt.Rows[j][2].ToString();
                        //lblPass.Visible = false;
                        //e.Row.Cells[i].Controls.Add(lblPass);

                        j = j + 1;
                    }

                    int percent = 100*totmark/Int32.Parse(xtotalmaks.Text);
                    Label lbLabel = new Label();
                    lbLabel.ID = "xstotmarks";
                    lbLabel.Text = totmark.ToString();
                    //lbLabel.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    e.Row.Cells[i].Controls.Add(lbLabel);

                    lbLabel = new Label();
                    lbLabel.ID = "xspercent";
                    lbLabel.Text = percent.ToString()+"%";
                    //lbLabel.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    e.Row.Cells[i + 1].Controls.Add(lbLabel);

                    txTextBox = new TextBox();
                    txTextBox.ID = "txtRemarks";
                    txTextBox.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    txTextBox.TextMode=TextBoxMode.MultiLine;
                    e.Row.Cells[i+4].Controls.Add(txTextBox);
                    //if (tblamadmisd.Rows.Count > 0)
                    //{
                    txTextBox.Text = (e.Row.DataItem as DataRowView).Row["xremarks"].ToString();
                    //}
                    if (xst != "n")
                    {
                        txTextBox.Enabled = false;
                    }
                    chkCheckBox = new CheckBox();
                    chkCheckBox.ID = "promoted";
                    e.Row.Cells[i + 5].Controls.Add(chkCheckBox);
                    //chkCheckBox = new CheckBox();
                    //chkCheckBox.ID = "chkall";
                    //e.HeaderRow.Cells[i + 5].Controls.Add(chkCheckBox);
                    int passmarks = Int32.Parse(xpassmarks.Text.TrimEnd('%'));
                    if (percent >= passmarks)
                    {
                        chkCheckBox.Checked = true;
                    }

                    if (xst != "n")
                    {
                        chkCheckBox.Enabled = false;
                    }

                    txTextBox = new TextBox();
                    txTextBox.ID = "txtDate";
                    txTextBox.CssClass = "bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker";
                    e.Row.Cells[i + 6].Controls.Add(txTextBox);
                    if(xst1!="n")
                    {
                        txTextBox.Enabled = false;
                    }

                    if (Convert.ToDateTime((e.Row.DataItem as DataRowView).Row["xvivadate"].ToString()) != DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture) &&
                        Convert.ToDateTime((e.Row.DataItem as DataRowView).Row["xvivadate"].ToString()) != DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    {
                        txTextBox.Text =
                            Convert.ToDateTime((e.Row.DataItem as DataRowView).Row["xvivadate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txTextBox.Text = "";
                    }

                    DropDownList xhour1 = new DropDownList();
                    xhour1.ID = "xhour1";
                    xhour1.Items.Clear();
                    xhour1.Items.Add("");
                    for (int k = 1; k <= 12; k++)
                    {
                        xhour1.Items.Add(k < 10 ? "0" + k.ToString() : k.ToString());
                    }
                    if ((e.Row.DataItem as DataRowView).Row["xhour1"].ToString() != "")
                    {
                        xhour1.Text = (e.Row.DataItem as DataRowView).Row["xhour1"].ToString();
                    }
                    else
                    {
                        xhour1.Text = "09";
                    }
                    xhour1.CssClass = "bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown";
                    xhour1.Width = 52;
                    e.Row.Cells[i + 7].Controls.Add(xhour1);

                    DropDownList xminitue1 = new DropDownList();
                    xminitue1.ID = "xminitue1";
                    xminitue1.Items.Clear();
                    xminitue1.Items.Add("");
                    for (int k = 0; k < 60; k++)
                    {
                        xminitue1.Items.Add(k < 10 ? "0" + k.ToString() : k.ToString());
                    }
                    if ((e.Row.DataItem as DataRowView).Row["xminitue1"].ToString() != "")
                    {
                        xminitue1.Text = (e.Row.DataItem as DataRowView).Row["xminitue1"].ToString();
                    }
                    else
                    {
                        xminitue1.Text = "00";
                    }
                    xminitue1.CssClass = "bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown";
                    xminitue1.Width = 52;
                    e.Row.Cells[i + 7].Controls.Add(xminitue1);

                    DropDownList xperiod1 = new DropDownList();
                    xperiod1.ID = "xperiod1";
                    xperiod1.Items.Clear();
                    xperiod1.Items.Add("");
                    xperiod1.Items.Add("AM");
                    xperiod1.Items.Add("PM");
                    if ((e.Row.DataItem as DataRowView).Row["xperiod1"].ToString() != "")
                    {
                        xperiod1.Text = (e.Row.DataItem as DataRowView).Row["xperiod1"].ToString();
                    }
                    else
                    {
                        xperiod1.Text = "AM";
                    }
                    xperiod1.CssClass = "bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown";
                    xperiod1.Width = 52;
                    e.Row.Cells[i + 7].Controls.Add(xperiod1);

                    DropDownList xexamvenue1 = new DropDownList();
                    xexamvenue1.ID = "xexamvenue1";
                    
                    zglobal.fnGetComboDataCD("Exam Venue", xexamvenue1);
                    xexamvenue1.Text = (e.Row.DataItem as DataRowView).Row["xexamvenue1"].ToString();
                    xexamvenue1.CssClass = "bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown";
                    e.Row.Cells[i + 8].Controls.Add(xexamvenue1);

                    if (xst1 != "n")
                    {
                        xhour1.Enabled = false;
                        xperiod1.Enabled = false;
                        xminitue1.Enabled = false;
                        xexamvenue1.Enabled = false;
                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        //protected void OnDataBound(object sender, EventArgs e)
        //{
        //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //    TableHeaderCell cell = new TableHeaderCell();
        //    cell.Text = "Customers";
        //    cell.ColumnSpan = 2;
        //    row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.ColumnSpan = 2;
        //    cell.Text = "Employees";
        //    row.Controls.Add(cell);

        //    row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        //    GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
        //}


        public void fnFillDataGrid2(object sender, EventArgs e)
        {
            try
            {
                //GridView1.DataSource = null;
                //GridView1.DataBind();
                BindGrid();
                message.InnerHtml = "";
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                fnFillDataGrid(sender, e);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                //zglobal.ClearApplicationCache();
                flag.Value = "1";
                btnSave.Enabled = false;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = Convert.ToInt32(((LinkButton)sender).Text);
                string str = "SELECT  * FROM amadmis where zid=@zid  and xrow=@xrow ";





                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                //xtype.InnerHtml = dtztcode.Rows[0]["xtype"].ToString();
                //xcode.Text = dtztcode.Rows[0]["xcode"].ToString();
                //xdescdet.Value = dtztcode.Rows[0]["xdescdet"].ToString();
                //xcodealt.Text = dtztcode.Rows[0]["xcodealt"].ToString();
                //xprops.Value = dtztcode.Rows[0]["xprops"].ToString();
                //zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                //zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
                //xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    xsession.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xname.Text = dtztcode.Rows[0]["xname"].ToString();
                    xclass.Text = dtztcode.Rows[0]["xclass"].ToString();
                    xexamroll.Text = dtztcode.Rows[0]["xexamroll"].ToString();
                    xexamdate.Text = Convert.ToDateTime(dtztcode.Rows[0]["xexamdate"]).ToString("dd/MM/yyyy");
                    xexamvenue.Text = dtztcode.Rows[0]["xexamvenue"].ToString();
                    xpschool.Text = dtztcode.Rows[0]["xpschool"].ToString();
                    xmname.Text = dtztcode.Rows[0]["xmname"].ToString();
                    xprofession.Text = dtztcode.Rows[0]["xprofession"].ToString();
                    xfname.Text = dtztcode.Rows[0]["xfname"].ToString();
                    xprofession1.Text = dtztcode.Rows[0]["xprofession1"].ToString();
                    xcontact.Text = dtztcode.Rows[0]["xcontact"].ToString();
                    xphone.Text = dtztcode.Rows[0]["xphone"].ToString();
                    xpadd.Text = dtztcode.Rows[0]["xpadd"].ToString();
                    xperadd.Text = dtztcode.Rows[0]["xperadd"].ToString();
                    xemail1.Text = dtztcode.Rows[0]["xemail1"].ToString();
                    xnation.Text = dtztcode.Rows[0]["xnation"].ToString();
                    xdob.Text = dtztcode.Rows[0]["xdob"].Equals(DBNull.Value) == true ? "" : Convert.ToDateTime(dtztcode.Rows[0]["xdob"]).ToString("dd/MM/yyyy");
                    fnCalculateAge(null, null);
                    xreligion.Text = dtztcode.Rows[0]["xreligion"].ToString();
                    xgender.Text = dtztcode.Rows[0]["xgender"].ToString();
                    ximagelink.ImageUrl = dtztcode.Rows[0]["ximagelink"].ToString();
                    xgroup.Text = dtztcode.Rows[0]["xgroup"].ToString();
                    xnumexam.Text = dtztcode.Rows[0]["xnumexam"].ToString();
                    xcellnom.Text = dtztcode.Rows[0]["xcellno"].ToString();
                    xcellno1f.Text = dtztcode.Rows[0]["xcellno1"].ToString();
                    xhour.Text = dtztcode.Rows[0]["xhour"].Equals(DBNull.Value) == true
                        ? "12"
                        : dtztcode.Rows[0]["xhour"].ToString();
                    xminitue.Text = dtztcode.Rows[0]["xminitue"].Equals(DBNull.Value) == true
                       ? "00"
                       : dtztcode.Rows[0]["xminitue"].ToString();
                    xperiod.Text = dtztcode.Rows[0]["xperiod"].Equals(DBNull.Value) == true
                       ? "AM"
                       : dtztcode.Rows[0]["xperiod"].ToString();
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    btnSave.Enabled = true;
                    xsession_res.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xnumexam.Text = dtztcode.Rows[0]["xnumexam"].ToString();
                    xclass_res.Text = dtztcode.Rows[0]["xclass"].ToString();
                    xexamroll_res.Text = dtztcode.Rows[0]["xexamroll"].ToString();
                    xexamdate_res.Text = Convert.ToDateTime(dtztcode.Rows[0]["xexamdate"]).ToString("dd/MM/yyyy");
                    xname_res.Text = dtztcode.Rows[0]["xname"].ToString();
                    xmother_res.Text = dtztcode.Rows[0]["xmname"].ToString();
                    xfather_res.Text = dtztcode.Rows[0]["xfname"].ToString();
                    //placeholder.Controls.Clear();
                    //fnCreateConteolMarks(dtztcode.Rows[0]["xclass"].ToString(), xrow);
                    //flag1 = 1;
                    //dtmarks.Reset();
                    //Page_Load(null,null);

                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    xstdid.Text = dtztcode.Rows[0]["xstdid"].ToString();
                    xsession_admis.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xname_admis.Text = dtztcode.Rows[0]["xname"].ToString();
                    xpschool_admis.Text = dtztcode.Rows[0]["xpschool"].ToString();
                    xmname_admis.Text = dtztcode.Rows[0]["xmname"].ToString();
                    xprofession_admis.Text = dtztcode.Rows[0]["xprofession"].ToString();
                    xoffadd.Value = dtztcode.Rows[0]["xoffadd"].ToString();
                    xcellno.Text = dtztcode.Rows[0]["xcellno"].ToString();
                    xmailid.Text = dtztcode.Rows[0]["xmailid"].ToString();
                    xfname_admis.Text = dtztcode.Rows[0]["xfname"].ToString();
                    xprofession1_admis.Text = dtztcode.Rows[0]["xprofession1"].ToString();
                    xoffadd1.Value = dtztcode.Rows[0]["xoffadd1"].ToString();
                    xcellno1.Text = dtztcode.Rows[0]["xcellno1"].ToString();
                    xclass_admis.Text = dtztcode.Rows[0]["xclass"].ToString();
                    xsection.Text = dtztcode.Rows[0]["xsection"].ToString();
                    xadmitdate.Text = dtztcode.Rows[0]["xadmitdate"].Equals(DBNull.Value) == true ? "" : Convert.ToDateTime(dtztcode.Rows[0]["xadmitdate"]).ToString("dd/MM/yyyy");
                    xdob_admis.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdob"]).ToString("dd/MM/yyyy");
                    fnAge(xage_admis, xdob_admis);
                    xnation_admis.Text = dtztcode.Rows[0]["xnation"].ToString();
                    xreligion_admis.Text = dtztcode.Rows[0]["xreligion"].ToString();
                    xgender_admis.Text = dtztcode.Rows[0]["xgender"].ToString();
                    xpadd_admis.Text = dtztcode.Rows[0]["xpadd"].ToString();
                    xperadd_admis.Text = dtztcode.Rows[0]["xperadd"].ToString();
                    xcontact_admis.Text = dtztcode.Rows[0]["xcontact"].ToString();
                    xemail1_admis.Text = dtztcode.Rows[0]["xemail1"].ToString();
                    ximagelink_admis.ImageUrl = dtztcode.Rows[0]["ximagelink"].ToString();
                    xmimagelink.ImageUrl = dtztcode.Rows[0]["xmimagelink"].ToString();
                    xfimagelink.ImageUrl = dtztcode.Rows[0]["xfimagelink"].ToString();
                    xblood.Text = dtztcode.Rows[0]["xblood"].ToString();
                    xq1.Text = dtztcode.Rows[0]["xq1"].ToString();
                    xq2.Text = dtztcode.Rows[0]["xq2"].ToString();
                    xq2d.Value = dtztcode.Rows[0]["xq2d"].ToString();
                    xq3.Text = dtztcode.Rows[0]["xq3"].ToString();
                    xq3d.Value = dtztcode.Rows[0]["xq3d"].ToString();
                    xnumchild.Text = dtztcode.Rows[0]["xnumchild"].ToString();
                    xchildpos.Text = dtztcode.Rows[0]["xchildpos"].ToString();
                    xsibling.Text = dtztcode.Rows[0]["xsibling"].ToString();
                    xq4.Text = dtztcode.Rows[0]["xq4"].ToString();
                    xq5.Text = dtztcode.Rows[0]["xq5"].ToString();
                    xq6.Text = dtztcode.Rows[0]["xq6"].ToString();
                    xq7.Text = dtztcode.Rows[0]["xq7"].ToString();
                    xname_driver.Text = dtztcode.Rows[0]["xnamedriver"].ToString();
                    xcellno_driver.Text = dtztcode.Rows[0]["xcellnodriver"].ToString();
                    xnid_driver.Text = dtztcode.Rows[0]["xniddriver"].ToString();
                    xpadd_driver.Value = dtztcode.Rows[0]["xpadddriver"].ToString();
                    xperadd_driver.Value = dtztcode.Rows[0]["xperadddriver"].ToString();
                    ximage.ImageUrl = dtztcode.Rows[0]["ximagedriver"].ToString();
                    xcellno.Text = dtztcode.Rows[0]["xcellno"].ToString();
                    xcellno1.Text = dtztcode.Rows[0]["xcellno1"].ToString();

                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    //xsession_exam.Text = dtztcode.Rows[0]["xsession"].ToString();
                    //xlocation_exam.Text = dtztcode.Rows[0]["xlocation"].ToString();
                    //xdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
                    //xexam_exam.Text = dtztcode.Rows[0]["xexam"].ToString();
                    //xclass_exam.Text = dtztcode.Rows[0]["xfclass"].ToString();
                    //xfdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfdate"]).ToString("dd/MM/yyyy");
                    //xtdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
                    //xsubmission_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xffdate"]).ToString("dd/MM/yyyy");
                    //xresultdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xresultdate"]).ToString("dd/MM/yyyy");
                    //xconvenor_exam.Text = dtztcode.Rows[0]["xconvenor"].ToString();
                    //xprogdetail_exam.InnerHtml = dtztcode.Rows[0]["xprogdetail"].ToString();
                }



                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                _row.Value = ((LinkButton)sender).Text;
                message.InnerHtml = "";


            }
            catch (Exception exp)
            {
                //dtmarks.Reset();
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void FillControls2(object sender, EventArgs e)
        {
            try
            {
                //message.InnerHtml = "jkljldsjflkjkdsl";
                if (_student.Value == null || _student.Value == "" || _student.Value == string.Empty)
                {
                    return;
                }

                zglobal.ClearApplicationCache();
                flag.Value = "1";
                btnSave.Enabled = false;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = Convert.ToInt32(_student.Value);
                string str = "SELECT  * FROM amadmis where zid=@zid  and xrow=@xrow ";





                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                //xtype.InnerHtml = dtztcode.Rows[0]["xtype"].ToString();
                //xcode.Text = dtztcode.Rows[0]["xcode"].ToString();
                //xdescdet.Value = dtztcode.Rows[0]["xdescdet"].ToString();
                //xcodealt.Text = dtztcode.Rows[0]["xcodealt"].ToString();
                //xprops.Value = dtztcode.Rows[0]["xprops"].ToString();
                //zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                //zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
                //xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    xsession.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xname.Text = dtztcode.Rows[0]["xname"].ToString();
                    xclass.Text = dtztcode.Rows[0]["xclass"].ToString();
                    xexamroll.Text = dtztcode.Rows[0]["xexamroll"].ToString();
                    xexamdate.Text = Convert.ToDateTime(dtztcode.Rows[0]["xexamdate"]).ToString("dd/MM/yyyy");
                    xexamvenue.Text = dtztcode.Rows[0]["xexamvenue"].ToString();
                    xpschool.Text = dtztcode.Rows[0]["xpschool"].ToString();
                    xmname.Text = dtztcode.Rows[0]["xmname"].ToString();
                    xprofession.Text = dtztcode.Rows[0]["xprofession"].ToString();
                    xfname.Text = dtztcode.Rows[0]["xfname"].ToString();
                    xprofession1.Text = dtztcode.Rows[0]["xprofession1"].ToString();
                    xcontact.Text = dtztcode.Rows[0]["xcontact"].ToString();
                    xphone.Text = dtztcode.Rows[0]["xphone"].ToString();
                    xpadd.Text = dtztcode.Rows[0]["xpadd"].ToString();
                    xperadd.Text = dtztcode.Rows[0]["xperadd"].ToString();
                    xemail1.Text = dtztcode.Rows[0]["xemail1"].ToString();
                    xnation.Text = dtztcode.Rows[0]["xnation"].ToString();
                    xdob.Text = dtztcode.Rows[0]["xdob"].Equals(DBNull.Value) == true ? "" : Convert.ToDateTime(dtztcode.Rows[0]["xdob"]).ToString("dd/MM/yyyy");
                    fnCalculateAge(null, null);
                    xreligion.Text = dtztcode.Rows[0]["xreligion"].ToString();
                    xgender.Text = dtztcode.Rows[0]["xgender"].ToString();
                    ximagelink.ImageUrl = dtztcode.Rows[0]["ximagelink"].ToString();
                    xgroup.Text = dtztcode.Rows[0]["xgroup"].ToString();
                    xnumexam.Text = dtztcode.Rows[0]["xnumexam"].ToString();
                    xcellnom.Text = dtztcode.Rows[0]["xcellno"].ToString();
                    xcellno1f.Text = dtztcode.Rows[0]["xcellno1"].ToString();
                    xhour.Text = dtztcode.Rows[0]["xhour"].Equals(DBNull.Value) == true
                       ? "12"
                       : dtztcode.Rows[0]["xhour"].ToString();
                    xminitue.Text = dtztcode.Rows[0]["xminitue"].Equals(DBNull.Value) == true
                       ? "00"
                       : dtztcode.Rows[0]["xminitue"].ToString();
                    xperiod.Text = dtztcode.Rows[0]["xperiod"].Equals(DBNull.Value) == true
                       ? "AM"
                       : dtztcode.Rows[0]["xperiod"].ToString();
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    btnSave.Enabled = true;
                    xsession_res.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xnumexam.Text = dtztcode.Rows[0]["xnumexam"].ToString();
                    xclass_res.Text = dtztcode.Rows[0]["xclass"].ToString();
                    xexamroll_res.Text = dtztcode.Rows[0]["xexamroll"].ToString();
                    xexamdate_res.Text = Convert.ToDateTime(dtztcode.Rows[0]["xexamdate"]).ToString("dd/MM/yyyy");
                    xname_res.Text = dtztcode.Rows[0]["xname"].ToString();
                    xmother_res.Text = dtztcode.Rows[0]["xmname"].ToString();
                    xfather_res.Text = dtztcode.Rows[0]["xfname"].ToString();
                    //placeholder.Controls.Clear();
                    //fnCreateConteolMarks(dtztcode.Rows[0]["xclass"].ToString(), xrow);
                    //flag1 = 1;
                    //dtmarks.Reset();
                    //Page_Load(null,null);

                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    xstdid.Text = dtztcode.Rows[0]["xstdid"].ToString();
                    xsession_admis.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xname_admis.Text = dtztcode.Rows[0]["xname"].ToString();
                    xpschool_admis.Text = dtztcode.Rows[0]["xpschool"].ToString();
                    xmname_admis.Text = dtztcode.Rows[0]["xmname"].ToString();
                    xprofession_admis.Text = dtztcode.Rows[0]["xprofession"].ToString();
                    xoffadd.Value = dtztcode.Rows[0]["xoffadd"].ToString();
                    xcellno.Text = dtztcode.Rows[0]["xcellno"].ToString();
                    xmailid.Text = dtztcode.Rows[0]["xmailid"].ToString();
                    xfname_admis.Text = dtztcode.Rows[0]["xfname"].ToString();
                    xprofession1_admis.Text = dtztcode.Rows[0]["xprofession1"].ToString();
                    xoffadd1.Value = dtztcode.Rows[0]["xoffadd1"].ToString();
                    xcellno1.Text = dtztcode.Rows[0]["xcellno1"].ToString();
                    xclass_admis.Text = dtztcode.Rows[0]["xclass"].ToString();
                    xsection.Text = dtztcode.Rows[0]["xsection"].ToString();
                    xadmitdate.Text = dtztcode.Rows[0]["xadmitdate"].Equals(DBNull.Value) == true ? "" : Convert.ToDateTime(dtztcode.Rows[0]["xadmitdate"]).ToString("dd/MM/yyyy");
                    xdob_admis.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdob"]).ToString("dd/MM/yyyy");
                    fnAge(xage_admis, xdob_admis);
                    xnation_admis.Text = dtztcode.Rows[0]["xnation"].ToString();
                    xreligion_admis.Text = dtztcode.Rows[0]["xreligion"].ToString();
                    xgender_admis.Text = dtztcode.Rows[0]["xgender"].ToString();
                    xpadd_admis.Text = dtztcode.Rows[0]["xpadd"].ToString();
                    xperadd_admis.Text = dtztcode.Rows[0]["xperadd"].ToString();
                    xcontact_admis.Text = dtztcode.Rows[0]["xcontact"].ToString();
                    xemail1_admis.Text = dtztcode.Rows[0]["xemail1"].ToString();
                    ximagelink_admis.ImageUrl = dtztcode.Rows[0]["ximagelink"].ToString();
                    xmimagelink.ImageUrl = dtztcode.Rows[0]["xmimagelink"].ToString();
                    xfimagelink.ImageUrl = dtztcode.Rows[0]["xfimagelink"].ToString();
                    xblood.Text = dtztcode.Rows[0]["xblood"].ToString();
                    xq1.Text = dtztcode.Rows[0]["xq1"].ToString();
                    xq2.Text = dtztcode.Rows[0]["xq2"].ToString();
                    xq2d.Value = dtztcode.Rows[0]["xq2d"].ToString();
                    xq3.Text = dtztcode.Rows[0]["xq3"].ToString();
                    xq3d.Value = dtztcode.Rows[0]["xq3d"].ToString();
                    xnumchild.Text = dtztcode.Rows[0]["xnumchild"].ToString();
                    xchildpos.Text = dtztcode.Rows[0]["xchildpos"].ToString();
                    xsibling.Text = dtztcode.Rows[0]["xsibling"].ToString();
                    xq4.Text = dtztcode.Rows[0]["xq4"].ToString();
                    xq5.Text = dtztcode.Rows[0]["xq5"].ToString();
                    xq6.Text = dtztcode.Rows[0]["xq6"].ToString();
                    xq7.Text = dtztcode.Rows[0]["xq7"].ToString();
                    xname_driver.Text = dtztcode.Rows[0]["xnamedriver"].ToString();
                    xcellno_driver.Text = dtztcode.Rows[0]["xcellnodriver"].ToString();
                    xnid_driver.Text = dtztcode.Rows[0]["xniddriver"].ToString();
                    xpadd_driver.Value = dtztcode.Rows[0]["xpadddriver"].ToString();
                    xperadd_driver.Value = dtztcode.Rows[0]["xperadddriver"].ToString();
                    ximage.ImageUrl = dtztcode.Rows[0]["ximagedriver"].ToString();
                    xcellno.Text = dtztcode.Rows[0]["xcellno"].ToString();
                    xcellno1.Text = dtztcode.Rows[0]["xcellno1"].ToString();

                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    //xsession_exam.Text = dtztcode.Rows[0]["xsession"].ToString();
                    //xlocation_exam.Text = dtztcode.Rows[0]["xlocation"].ToString();
                    //xdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
                    //xexam_exam.Text = dtztcode.Rows[0]["xexam"].ToString();
                    //xclass_exam.Text = dtztcode.Rows[0]["xfclass"].ToString();
                    //xfdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfdate"]).ToString("dd/MM/yyyy");
                    //xtdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
                    //xsubmission_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xffdate"]).ToString("dd/MM/yyyy");
                    //xresultdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xresultdate"]).ToString("dd/MM/yyyy");
                    //xconvenor_exam.Text = dtztcode.Rows[0]["xconvenor"].ToString();
                    //xprogdetail_exam.InnerHtml = dtztcode.Rows[0]["xprogdetail"].ToString();
                }



                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                _row.Value = _student.Value;
                message.InnerHtml = "";
                _student.Value = null;

            }
            catch (Exception exp)
            {
                //dtmarks.Reset();
                _student.Value = null;
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {


            //if (ViewState["ctladded"] == null)
            //{
            //    ViewState["ctladded"] = 1;
            //}

            //ViewState["ctladded"] = 1 + (int)ViewState["ctladded"];



            //fnCreateControl((int)ViewState["ctladded"]);

        }

        protected void fnCreateDynamicControlAtPageLoad()
        {
            //if (ViewState["ctladded"] != null)
            //{
            //    int howMany = (int)ViewState["ctladded"];
            //    for (int i = 1; i <= howMany; i++)
            //    {
            //        fnCreateControl(i);
            //    }
            //}
        }

        //DataTable dtmarks = new DataTable();
        private int totmarks;
        protected void fnCreateConteolMarks(string xclass1, int xrow)
        {
            try
            {

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string str = "select amadmis.zid as zid, amadmis.xclass as xclass, amadmis.xrow as xrow, ammarks.xsubject as xsubject, ammarks.xmark as xmark, amadmisd.xgetmark as xgetmark,ammarks.xpassmark as xpassmark from amadmis inner join  amadmisd on amadmis.zid=amadmisd.zid and amadmis.xrow=amadmisd.xrow and amadmis.xrow=@xrow " +
                                " right outer join ammarks on amadmisd.zid=ammarks.zid and amadmisd.xrowmarks=ammarks.xrow " +
                                " where ammarks.zid=@zid and ammarks.xclass=@xclass  and xtype='admistest' and " +
                                "xeffdate=(select MAX(xeffdate)from ammarks where zid=@zid and ammarks.xclass=@xclass and xeffdate<=coalesce(xexamdate,getdate()) and xtype='admistest') ";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                da.Fill(dts, "tempztcode");
                DataTable dtmarks = new DataTable();
                dtmarks = dts.Tables[0];

                if (dtmarks.Rows.Count > 0)
                {
                    int i = 1;
                    totmarks = 0;
                    int tmarks = 0;
                    int passm = 0;
                    foreach (DataRow row in dtmarks.Rows)
                    {
                        fnCreateControl(i, row, _zid, xrow, xclass1);
                        i = i + 1;
                        tmarks = tmarks + Convert.ToInt32(row["xmark"].ToString());
                        passm = passm + Convert.ToInt32(row["xpassmark"].ToString());
                    }

                    xtotalmaks.Text = tmarks.ToString();
                    int pass = (100 * passm) / tmarks;
                    xpassmarks.Text = pass.ToString();

                }
                else
                {
                    xtotalmaks.Text = "";
                    xpassmarks.Text = "";
                }

                //dtmarks.Reset();
                ViewState["ctladded"] = dtmarks.Rows.Count;

                //if (ViewState["ctladded"] != null)
                //{
                //    int howMany = (int)ViewState["ctladded"];
                //    for (int i = 1; i <= howMany; i++)
                //    {
                //        fnCreateControl(i);
                //    }
                //}
            }
            catch (Exception exp)
            {
                //dtmarks.Reset();
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnCreateControl(int k, DataRow row, int _zid_, int _xrow_, string _xclass_)
        {
            try
            {

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                HtmlGenericControl div11 = new HtmlGenericControl("div");
                HtmlGenericControl div111 = new HtmlGenericControl("div");
                HtmlGenericControl div1111 = new HtmlGenericControl("div");
                HtmlGenericControl div1112 = new HtmlGenericControl("div");
                HtmlGenericControl div112 = new HtmlGenericControl("div");
                HtmlGenericControl div1121 = new HtmlGenericControl("div");
                HtmlGenericControl div1122 = new HtmlGenericControl("div");
                HtmlGenericControl div12 = new HtmlGenericControl("div");
                HtmlGenericControl div121 = new HtmlGenericControl("div");
                HtmlGenericControl div1211 = new HtmlGenericControl("div");
                HtmlGenericControl div1212 = new HtmlGenericControl("div");
                HtmlGenericControl div122 = new HtmlGenericControl("div");
                HtmlGenericControl div1221 = new HtmlGenericControl("div");
                HtmlGenericControl div1222 = new HtmlGenericControl("div");
                HtmlGenericControl div13 = new HtmlGenericControl("div");
                HtmlGenericControl div131 = new HtmlGenericControl("div");
                HtmlGenericControl div1311 = new HtmlGenericControl("div");
                HtmlGenericControl div132 = new HtmlGenericControl("div");
                HtmlGenericControl div1321 = new HtmlGenericControl("div");
                HtmlGenericControl div2 = new HtmlGenericControl("div");

                div11.Attributes["style"] = "float: left";
                div111.Attributes["class"] = "bm_ctl_container_100_50";
                div111.Attributes["style"] = "width: 190px";
                div1111.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div1111.Attributes["style"] = "width: 80%";
                div1112.Attributes["class"] = "bm_clt_ctl_100_50";
                div1112.Attributes["style"] = "width: 20%";
                div112.Attributes["class"] = "bm_ctl_container_100_50";
                div112.Attributes["style"] = "width: 190px; margin-top: 2px; border: none;";
                div1121.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div1121.Attributes["style"] = "width: 80%; background-color: inherit;";
                div1122.Attributes["class"] = "bm_clt_ctl_100_50 border_";
                div1122.Attributes["style"] = "width: 20%;";
                div12.Attributes["style"] = "float: left; margin-left: 21px";
                div121.Attributes["class"] = "bm_ctl_container_100_50";
                div121.Attributes["style"] = "width: 190px";
                div1211.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div1211.Attributes["style"] = "width: 80%";
                div1212.Attributes["class"] = "bm_clt_ctl_100_50";
                div1212.Attributes["style"] = "width: 20%";
                div122.Attributes["class"] = "bm_ctl_container_100_50";
                div122.Attributes["style"] = "width: 190px; margin-top: 2px; border: none;";
                div1221.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div1221.Attributes["style"] = "width: 80%; background-color: inherit;";
                div1222.Attributes["class"] = "bm_clt_ctl_100_50 border_";
                div1222.Attributes["style"] = "width: 20%;";
                div13.Attributes["style"] = "float: left; margin-left: 40px";
                div131.Attributes["class"] = "bm_ctl_container_100_50";
                div131.Attributes["style"] = "width: 190px";
                div1311.Attributes["class"] = "bm_ctl_label_align_center_100_50";
                div1311.Attributes["style"] = "width: 100%";
                div132.Attributes["class"] = "bm_ctl_container_100_50";
                div132.Attributes["style"] = "width: 190px; margin-top: 2px;";
                div1321.Attributes["class"] = "bm_clt_ctl_100_50";
                div1321.Attributes["style"] = "width: 100%;";
                div2.Attributes["class"] = "clear";
                div2.Attributes["style"] = "margin-bottom: 10px";


                placeholder.Controls.Add(div1);
                div1.Controls.Add(div11);
                div1.Controls.Add(div12);
                if (k % 2 != 0)
                {
                    div11.Controls.Add(div111);
                    div11.Controls.Add(div112);
                }
                //div12.Controls.Add(div121);
                //div12.Controls.Add(div122);

                div111.Controls.Add(div1111);
                div111.Controls.Add(div1112);
                div112.Controls.Add(div1121);
                div112.Controls.Add(div1122);
                div121.Controls.Add(div1211);
                div121.Controls.Add(div1212);
                div122.Controls.Add(div1221);
                div122.Controls.Add(div1222);

                if (k == 2)
                {
                    div1.Controls.Add(div13);
                    div13.Controls.Add(div131);
                    div13.Controls.Add(div132);
                    div131.Controls.Add(div1311);
                    div132.Controls.Add(div1321);
                }
                if (k % 2 == 0)
                {
                    div12.Controls.Add(div121);
                    div12.Controls.Add(div122);
                    placeholder.Controls.Add(div2);
                }


                Label lblsub1 = new Label();
                TextBox txtmark1 = new TextBox();
                Label lbl1 = new Label();
                TextBox txtgetm1 = new TextBox();
                Label lblsub2 = new Label();
                TextBox txtmark2 = new TextBox();
                Label lbl2 = new Label();
                TextBox txtgetm2 = new TextBox();
                Label lbltot = new Label();
                TextBox txttot = new TextBox();

                lblsub1.CssClass = "label";
                txtmark1.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox";
                lbl1.CssClass = "label";
                txtgetm1.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox";
                lblsub2.CssClass = "label";
                txtmark2.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox";
                lbl2.CssClass = "label";
                txtgetm2.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox";
                lbltot.CssClass = "label";
                txttot.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox center_";

                txtmark1.Enabled = false;
                txtmark2.Enabled = false;
                txttot.Enabled = false;
                //txtgetm1.AutoPostBack = true;
                //txtgetm2.AutoPostBack = true;
                //txtgetm1.TextChanged += new EventHandler(textBox_TextChanged);
                //txtgetm1.TextChanged += new EventHandler(textBox_TextChanged);

                lblsub1.Text = row["xsubject"].ToString() + " :";
                txtmark1.Text = row["xmark"].ToString();
                txtgetm1.Text = row["xgetmark"].ToString();
                lblsub2.Text = row["xsubject"].ToString() + " :";
                txtmark2.Text = row["xmark"].ToString();
                txtgetm2.Text = row["xgetmark"].ToString();
                //totmarks = totmarks + Convert.ToInt32(row["xgetmark"].ToString());
                //txttot.Text = totmarks.ToString();
                if (k == 2)
                {
                    lbltot.Text = "Total";

                    SqlConnection conn2;
                    conn2 = new SqlConnection(zglobal.constring);
                    DataSet dts1 = new DataSet();

                    dts1.Reset();
                    string str1 = "select coalesce(sum(amadmisd.xgetmark),0) from amadmis inner join  amadmisd on amadmis.zid=amadmisd.zid and amadmis.xrow=amadmisd.xrow and amadmis.xrow=@xrow " +
                                    " right outer join ammarks on amadmisd.zid=ammarks.zid and amadmisd.xrowmarks=ammarks.xrow " +
                                    " where ammarks.zid=@zid and ammarks.xclass=@xclass and xtype='admistest' and " +
                                    "xeffdate=(select MAX(xeffdate)from ammarks where zid=@zid and ammarks.xclass=@xclass and xeffdate<=coalesce(xexamdate,getdate()) and xtype='admistest') ";

                    SqlDataAdapter da = new SqlDataAdapter(str1, conn2);
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid_);
                    da.SelectCommand.Parameters.AddWithValue("@xrow", _xrow_);
                    da.SelectCommand.Parameters.AddWithValue("@xclass", _xclass_);
                    da.Fill(dts1, "tempztcode");
                    DataTable dtotomarks = new DataTable();
                    dtotomarks = dts1.Tables[0];
                    txttot.Text = dtotomarks.Rows[0][0].ToString();
                }


                lblsub1.ID = "lblsub1" + k.ToString();
                txtmark1.ID = "txtmark1" + k.ToString();
                lbl1.ID = "lbl1" + k.ToString();
                txtgetm1.ID = "txtgetm1" + k.ToString();
                lblsub2.ID = "lblsub2" + k.ToString();
                txtmark2.ID = "txtmark2" + k.ToString();
                lbl2.ID = "lbl2" + k.ToString();
                txtgetm2.ID = "txtgetm2" + k.ToString();
                lbltot.ID = "lbltot" + k.ToString();
                txttot.ID = "txttot" + k.ToString();

                lblsub1.EnableViewState = true;
                txtmark1.EnableViewState = true;
                lbl1.EnableViewState = true;
                txtgetm1.EnableViewState = true;
                lblsub2.EnableViewState = true;
                txtmark2.EnableViewState = true;
                lbl2.EnableViewState = true;
                txtgetm2.EnableViewState = true;
                lbltot.EnableViewState = true;
                txttot.EnableViewState = true;

                div1111.Controls.Add(lblsub1);
                div1112.Controls.Add(txtmark1);
                div1121.Controls.Add(lbl1);
                div1122.Controls.Add(txtgetm1);
                div1211.Controls.Add(lblsub2);
                div1212.Controls.Add(txtmark2);
                div1221.Controls.Add(lbl2);
                div1222.Controls.Add(txtgetm2);
                div1311.Controls.Add(lbltot);
                div1321.Controls.Add(txttot);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        //protected void textBox_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        totmarks=totmarks
        //    }
        //    catch (Exception exp)
        //    {
        //        message.InnerHtml = exp.Message;
        //        message.Style.Value = zglobal.errormsg;
        //    }
        //}

        private void fnButtonVisible()
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {
                btnEdit.Visible = true;
                btnSave.Visible = true;
                btnRefresh.Visible = true;
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                btnSave.Visible = false;
                //btnEdit.Visible = false;
                //btnRefresh.Visible = false;
            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
                btnSave.Visible = false;
                btnEdit.Visible = true;
                btnRefresh.Visible = true;
            }
            else
            {
                btnEdit.Visible = true;
                btnSave.Visible = true;
                btnRefresh.Visible = true;
            }
        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                _row.Value = "";
                //type.Value = "";
                _gridrow.Text = zglobal._grid_row_value;
                grid_xsession.Text = "";
                grid_xclass.Text = "";
                btnSave.Enabled = true;
                fnButtonVisible();
                ViewState["ctladded"] = null;
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    list.Visible = true;
                    list_res.Visible = false;
                    _grid_header.InnerHtml = "Info. For Admission Test :";
                    fnGridVisibleProp("_grid_admis_test");
                    _grid_admis_test.DataSource = null;
                    _grid_admis_test.DataBind();
                    getActiveTabIndex.Value = "0";
                    type.Value = "day_o";
                    TabContainer1.Height = 530;
                    //btnPrint.Visible = true;
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    // _grid_header.InnerHtml = "Student Info";
                    list.Visible = false;
                    list_res.Visible = true;
                   // _grid_header_res.InnerHtml = "Marks Obtained";
                    fnGridVisibleProp("_grid_admis_res");
                    _grid_admis_res.DataSource = null;
                    _grid_admis_res.DataBind();
                    getActiveTabIndex.Value = "1";
                    type.Value = "out";
                    TabContainer1.Height = 120;

                    //xsession_res.Text = "";
                    //xnumexam.Text = "";
                    //xexamdate_res.Text = "";
                    //xclass_res.Text = "";
                    //xtotalmaks.Text = "";
                    //xpassmarks.Text = "";
                    //xexamroll_res.Text = "";
                    //xname_res.Text = "";
                    //xmother_res.Text = "";
                    //xfather_res.Text = "";
                    // xpassmethod.Text = "";
                    btnPrint.Visible = false;
                    //xsession_res.Text = zglobal.fnDefaults("xsession", "Student");
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    list.Visible = true;
                    list_res.Visible = false;
                    _grid_header.InnerHtml = "Information For Admission :";
                    fnGridVisibleProp("_grid_admis_stdinfo");
                    _grid_admis_stdinfo.DataSource = null;
                    _grid_admis_stdinfo.DataBind();
                    getActiveTabIndex.Value = "2";
                    type.Value = "day_o";
                    TabContainer1.Height = 1750;
                    btnPrint.Visible = false;
                }
                else
                {
                    list.Visible = true;
                    list_res.Visible = false;
                    btnPrint.Visible = false;
                }
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
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //Duplicate entry check
                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    string checkuser = "SELECT COUNT(*) FROM amadmis WHERE zid=@zid AND xname=@xname AND xfname=@xfname AND xmname=@xmname AND xdob=@xdob AND (xcellno=@xcellno OR xcellno1=@xcellno1)";

                    SqlParameter objParameter = null;
                    // string xuser = Login1.UserName;
                    SqlCommand cmd = new SqlCommand(checkuser, conn);
                    objParameter = cmd.Parameters.Add("zid",SqlDbType.Int);
                    objParameter = cmd.Parameters.Add("xname", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xfname", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xmname", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xdob", SqlDbType.Date);
                    objParameter = cmd.Parameters.Add("xcellno", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xcellno1", SqlDbType.VarChar);

                    cmd.Parameters["zid"].Value = _zid;
                    cmd.Parameters["xname"].Value = xname.Text.ToString().Trim();
                    cmd.Parameters["xfname"].Value = xfname.Text.ToString().Trim();
                    cmd.Parameters["xmname"].Value = xmname.Text.ToString().Trim();
                    cmd.Parameters["xdob"].Value = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    cmd.Parameters["xcellno"].Value = xcellnom.Text.ToString().Trim();
                    cmd.Parameters["xcellno1"].Value = xcellno1f.Text.ToString().Trim();
                    conn.Open();
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    if (temp >=1)
                    {
                        message.InnerHtml = "Student already exist in the database. Cann't insert duplicate record.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }
                }

               
                string xkey = "";
                string xtype = "";
                message.InnerHtml = "";
                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xname.Text == "" || xname.Text == string.Empty || xname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Student Name</li>";
                        isValid = false;
                    }
                    if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Class</li>";
                        isValid = false;
                    }
                    if (xmname.Text == "" || xmname.Text == string.Empty || xmname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Mother's Name</li>";
                        isValid = false;
                    }
                    if (xcellnom.Text == "" || xcellnom.Text == string.Empty || xcellnom.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Cell No</li>";
                        isValid = false;
                    }
                    if (xfname.Text == "" || xfname.Text == string.Empty || xfname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Father's Name</li>";
                        isValid = false;
                    }
                    if (xcellno1f.Text == "" || xcellno1f.Text == string.Empty || xcellno1f.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Cell No</li>";
                        isValid = false;
                    }
                    if (xdob.Text == "" || xdob.Text == string.Empty || xdob.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Date of Birth</li>";
                        isValid = false;
                    }
                    if (xreligion.Text == "" || xreligion.Text == string.Empty || xreligion.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Religion</li>";
                        isValid = false;
                    }
                    if (xgender.Text == "" || xgender.Text == string.Empty || xgender.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Gender</li>";
                        isValid = false;
                    }
                    if (xnumexam.Text == "" || xnumexam.Text == string.Empty || xnumexam.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Number of Exam</li>";
                        isValid = false;
                    }
                    //if (xexamdate.Text == "" || xexamdate.Text == string.Empty || xexamdate.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Exam Date</li>";
                    //    isValid = false;
                    //}
                    //if (xexamvenue.Text == "" || xexamvenue.Text == string.Empty || xexamvenue.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Exam Venue</li>";
                    //    isValid = false;
                    //}
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    if (xsession_res.Text == "" || xsession_res.Text == string.Empty || xsession_res.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xclass_res.Text == "" || xclass_res.Text == string.Empty || xclass_res.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Class</li>";
                        isValid = false;
                    }
                    if (xexamroll_res.Text == "" || xexamroll_res.Text == string.Empty || xexamroll_res.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Exam Roll No</li>";
                        isValid = false;
                    }
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    //if (xsession_sport.Text == "" || xsession_sport.Text == string.Empty || xsession_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Session</li>";
                    //    isValid = false;
                    //}
                    //if (xprogramme_sport.Text == "" || xprogramme_sport.Text == string.Empty || xprogramme_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    //    isValid = false;
                    //}
                    //if (xlocation_sport.Text == "" || xlocation_sport.Text == string.Empty || xlocation_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    //    isValid = false;
                    //}
                    //if (xdate_sport.Text == "" || xdate_sport.Text == string.Empty || xdate_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    //    isValid = false;
                    //}
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    //if (xsession_exam.Text == "" || xsession_exam.Text == string.Empty || xsession_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Session</li>";
                    //    isValid = false;
                    //}
                    //if (xlocation_exam.Text == "" || xlocation_exam.Text == string.Empty || xlocation_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>School</li>";
                    //    isValid = false;
                    //}
                    //if (xdate_exam.Text == "" || xdate_exam.Text == string.Empty || xdate_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>End of Mid Term</li>";
                    //    isValid = false;
                    //}
                    //if (xexam_exam.Text == "" || xexam_exam.Text == string.Empty || xexam_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Name of The Exam</li>";
                    //    isValid = false;
                    //}
                    //if (xclass_exam.Text == "" || xclass_exam.Text == string.Empty || xclass_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Class </li>";
                    //    isValid = false;
                    //}
                }

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
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

                        DateTime ztime = DateTime.Now;
                        DateTime zutime = DateTime.Now;
                        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        Int64 xrow = 0;

                        string xsession1 = "";
                        string xname1 = "";
                        string xclass1 = "";
                        string xexamroll1 = "";
                        DateTime xexamdate1 = Convert.ToDateTime("01/01/1900");
                        string xexamvenue1 = "";
                        string xpschool1 = "";
                        string xmname1 = "";
                        string xprofession11 = "";
                        string xfname1 = "";
                        string xprofession12 = "";
                        string xcontact1 = "";
                        string xphone1 = "";
                        string xpadd1 = "";
                        string xperadd1 = "";
                        string xemail11 = "";
                        string xnation1 = "";
                        DateTime xdob1 = DateTime.Now;
                        string xreligion1 = "";
                        string xgender1 = "";
                        string ximagelink1 = "";
                        string calage = zglobal.calculateage;
                        string xnumexam1 = "";
                        string xgroup1 = "";
                        string xcellno11 = "";
                        string xcellno12 = "";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xhour1 = "12";
                        string xminitue1 = "00";
                        string xperiod1 = "AM";
                        DateTime xdate11 = DateTime.Today;
                        string xremarks = "";

                        string query = "";
                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            query = "INSERT INTO amadmis (ztime,zid,xrow,xsession,xname,xclass,xexamroll,xexamdate,xexamvenue,xpschool,xmname,xprofession,xfname,xprofession1,xcontact,xphone,xpadd,xperadd,xemail1,xnation,xdob,xreligion,xgender,ximagelink,zemail,xgroup,xcellno,xcellno1,xnumexam,xhour,xminitue,xperiod,xdate1) " +
                                    "VALUES(@ztime,@zid,@xrow,@xsession,@xname,@xclass,@xexamroll,@xexamdate,@xexamvenue,@xpschool,@xmname,@xprofession,@xfname,@xprofession1,@xcontact,@xphone,@xpadd,@xperadd,@xemail1,@xnation,@xdob,@xreligion,@xgender,@ximagelink,@zemail,@xgroup,@xcellno,@xcellno1,@xnumexam,@xhour,@xminitue,@xperiod,@xdate1) ";
                            //xtype = "day_o";
                            xrow = zglobal.GetMaximumIdInt("xrow", "amadmis", " zid=" + _zid, 1);
                            xkey = xrow.ToString();
                            xsession1 = xsession.Text.Trim().ToString();
                            xname1 = xname.Text.Trim().ToString();
                            xclass1 = xclass.Text.Trim().ToString();
                            xexamroll1 = Convert.ToString(zglobal.GetMaximumIdInt("xexamroll", "amadmis", " xsession='" + xsession.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() + "'", "r"));
                            xexamroll.Text = xexamroll1;
                            xexamdate1 = xexamdate.Text.Trim() != string.Empty ? DateTime.ParseExact(xexamdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xexamvenue1 = xexamvenue.Text.Trim().ToString();
                            xpschool1 = xpschool.Text.Trim().ToString();
                            xmname1 = xmname.Text.Trim().ToString();
                            xprofession11 = xprofession.Text.Trim().ToString();
                            xfname1 = xfname.Text.Trim().ToString();
                            xprofession12 = xprofession1.Text.Trim().ToString();
                            xcontact1 = xcontact.Text.Trim().ToString();
                            xphone1 = xphone.Text.Trim().ToString();
                            xpadd1 = xpadd.Text.Trim().ToString();
                            xperadd1 = xperadd.Text.Trim().ToString();
                            xemail11 = xemail1.Text.Trim().ToString();
                            xnation1 = xnation.Text.Trim().ToString();
                            xdob1 = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xreligion1 = xreligion.Text.Trim().ToString();
                            xgender1 = xgender.Text.Trim().ToString();
                            if (rdoCapture.Checked)
                            {
                                ximagelink1 = _stdimageurl.Value.ToString();
                                ximagelink.ImageUrl = ximagelink1;
                            }
                            else
                            {
                                ximagelink1 = ximagelink.ImageUrl.ToString();
                            }
                            xnumexam1 = xnumexam.Text.Trim().ToString();
                            xcellno11 = xcellnom.Text.ToString().Trim();
                            xcellno12 = xcellno1f.Text.ToString().Trim();
                            xgroup1 = xgroup.Text.ToString().Trim();
                            xhour1 = xhour.Text.Trim().ToString();
                            xminitue1 = xminitue.Text.Trim().ToString();
                            xperiod1 = xperiod.Text.Trim().ToString();

                        }
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            //query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xprogram,xlocation,xdate,xfdate,xallconvenor,xcoconvenor,xprogdetail,xfclass,xtclass,xffdate,xtdate,xvenue,xconvenor,xcalendertype,zemail) " +
                            //        "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xprogram,@xlocation,@xdate,@xfdate,@xallconvenor,@xcoconvenor,@xprogdetail,@xfclass,@xtclass,@xffdate,@xtdate,@xvenue,@xconvenor,@xcalendertype,@zemail) ";
                            //xtype = "out";
                            //xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            //xkey = xrow.ToString();
                            //xsession = xsession_out.Text.Trim().ToString();
                            //xprogram = xprogramme_out.Text.Trim().ToString();
                            //xlocation = xlocation_out.Text.Trim().ToString();
                            //xdate = xdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfdate = xfdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_out.Text.Trim().ToString();
                            //xcoconvenor = xcoconvenor_out.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_out.InnerText.Trim().ToString();
                            //xfclass = xfclass_out.Text.Trim().ToString();
                            //xtclass = xtclass_out.Text.Trim().ToString();
                            //xffdate = xffdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xvenue = xvenue_out.Text.Trim().ToString();
                            //xconvenor = xconvenor_out.Text.Trim().ToString();
                        }
                        else if (TabContainer1.ActiveTabIndex == 2)
                        {
                            //query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xprogram,xlocation,xdate,xfdate,xallconvenor,xcoconvenor,xprogdetail,xfclass,xtclass,xffdate,xtdate,xfinaldate,xcalendertype,zemail) " +
                            //        "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xprogram,@xlocation,@xdate,@xfdate,@xallconvenor,@xcoconvenor,@xprogdetail,@xfclass,@xtclass,@xffdate,@xtdate,@xfinaldate,@xcalendertype,@zemail) ";
                            //xtype = "sport";
                            //xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            //xkey = xrow.ToString();
                            //xsession = xsession_sport.Text.Trim().ToString();
                            //xprogram = xprogramme_sport.Text.Trim().ToString();
                            //xlocation = xlocation_sport.Text.Trim().ToString();
                            //xdate = xdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfdate = xfdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                            //xcoconvenor = xcoconvenor_sport.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_sport.InnerText.Trim().ToString();
                            //xfclass = xfclass_sport.Text.Trim().ToString();
                            //xtclass = xtclass_sport.Text.Trim().ToString();
                            //xffdate = xffdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfinaldate = xfinaldate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfinaldate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        else if (TabContainer1.ActiveTabIndex == 3)
                        {
                            //query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xlocation,xdate,xexam,xfclass,xfdate,xtdate,xffdate,xresultdate,xconvenor,xprogdetail,xcalendertype,zemail) " +
                            //        "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xlocation,@xdate,@xexam,@xfclass,@xfdate,@xtdate,@xffdate,@xresultdate,@xconvenor,@xprogdetail,@xcalendertype,@zemail) ";
                            //xtype = "exam";
                            //xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            //xkey = xrow.ToString();
                            //xsession = xsession_exam.Text.Trim().ToString();
                            //xlocation = xlocation_exam.Text.Trim().ToString();
                            //xdate = xdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xexam = xexam_exam.Text.Trim().ToString();
                            //xfclass = xclass_exam.Text.Trim().ToString();
                            //xfdate = xfdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xffdate = xsubmission_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xsubmission_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xresultdate = xresultdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                            //xconvenor = xconvenor_exam.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_exam.InnerText.Trim().ToString();
                        }




                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        //cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xsession", xsession1);
                        cmd.Parameters.AddWithValue("@xname", xname1);
                        cmd.Parameters.AddWithValue("@xclass", xclass1);
                        cmd.Parameters.AddWithValue("@xexamroll", xexamroll1);
                        cmd.Parameters.AddWithValue("@xexamdate", xexamdate1);
                        cmd.Parameters.AddWithValue("@xexamvenue", xexamvenue1);
                        cmd.Parameters.AddWithValue("@xpschool", xpschool1);
                        cmd.Parameters.AddWithValue("@xmname", xmname1);
                        cmd.Parameters.AddWithValue("@xprofession", xprofession11);
                        cmd.Parameters.AddWithValue("@xfname", xfname1);
                        cmd.Parameters.AddWithValue("@xprofession1", xprofession12);
                        cmd.Parameters.AddWithValue("@xcontact", xcontact1);
                        cmd.Parameters.AddWithValue("@xphone", xphone1);
                        cmd.Parameters.AddWithValue("@xpadd", xpadd1);
                        cmd.Parameters.AddWithValue("@xperadd", xperadd1);
                        cmd.Parameters.AddWithValue("@xemail1", xemail11);
                        cmd.Parameters.AddWithValue("@xnation", xnation1);
                        cmd.Parameters.AddWithValue("@xdob", xdob1);
                        cmd.Parameters.AddWithValue("@xreligion", xreligion1);
                        cmd.Parameters.AddWithValue("@xgender", xgender1);
                        cmd.Parameters.AddWithValue("@ximagelink", ximagelink1);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xemail", xemail);
                        cmd.Parameters.AddWithValue("@xnumexam", xnumexam1);
                        cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                        cmd.Parameters.AddWithValue("@xcellno", xcellno11);
                        cmd.Parameters.AddWithValue("@xcellno1", xcellno12);
                        cmd.Parameters.AddWithValue("@xhour", xhour1);
                        cmd.Parameters.AddWithValue("@xminitue", xminitue1);
                        cmd.Parameters.AddWithValue("@xperiod", xperiod1);
                        cmd.Parameters.AddWithValue("@xdate1", xdate11);
                        //cmd.Parameters.AddWithValue("@xremarks", xremarks);
                        cmd.ExecuteNonQuery();



                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            //if (ViewState["ctladded"] != null)
                            //{
                            //    query = "DELETE FROM mscalenderevn WHERE zid=@zid and xtype=@xtype and xrow=@xrow";
                            //    cmd.Parameters.Clear();
                            //    cmd.CommandText = query;
                            //    cmd.Parameters.AddWithValue("@zid", _zid);
                            //    cmd.Parameters.AddWithValue("@xtype", xtype);
                            //    cmd.Parameters.AddWithValue("@xrow", xrow);
                            //    cmd.ExecuteNonQuery();

                            //    for (int i = 1; i <= (int)ViewState["ctladded"]; i++)
                            //    {
                            //        cmd.Parameters.Clear();
                            //        int xline = zglobal.GetMaximumIdInt("xline", "mscalenderevn", " zid=" + _zid + " and xtype='" + xtype + "' and xrow=" + xrow, "line");
                            //        string xname_evn = ((TextBox)placeholder.FindControl("mytxt" + i)).Text.ToString().Trim();
                            //        string xfclass_evn = ((DropDownList)placeholder.FindControl("mydwf" + i)).SelectedItem.Text.ToString();
                            //        string xtclass_evn = ((DropDownList)placeholder.FindControl("mydwt" + i)).SelectedItem.Text.ToString();
                            //        DateTime xdate_evn = ((TextBox)placeholder.FindControl("mydtp" + i)).Text.ToString().Trim() != string.Empty ? DateTime.ParseExact(((TextBox)placeholder.FindControl("mydtp" + i)).Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //        query = "INSERT INTO mscalenderevn (zid,xtype,xrow,xline,xname,xfclass,xtclass,xdate) " +
                            //            "VALUES(@zid,@xtype,@xrow,@xline,@xname,@xfclass,@xtclass,@xdate) ";
                            //        cmd.CommandText = query;
                            //        cmd.Parameters.AddWithValue("@zid", _zid);
                            //        cmd.Parameters.AddWithValue("@xtype", xtype);
                            //        cmd.Parameters.AddWithValue("@xrow", xrow);
                            //        cmd.Parameters.AddWithValue("@xline", xline);
                            //        cmd.Parameters.AddWithValue("@xname", xname_evn);
                            //        cmd.Parameters.AddWithValue("@xfclass", xfclass_evn);
                            //        cmd.Parameters.AddWithValue("@xtclass", xtclass_evn);
                            //        cmd.Parameters.AddWithValue("@xdate", xdate_evn);
                            //        if (xname_evn != "" || xname_evn != string.Empty)
                            //        {
                            //            cmd.ExecuteNonQuery();
                            //        }

                            //    }
                            //}

                        }



                        //Insert into zreclog
                        //zglobal.fnRecordLog(xrow.ToString(), "Save", "eventinfo", xtype, "", 0, xdate);


                    }

                    //fnFillDataGrid();
                    //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();


                }
                btnSave.Enabled = false;
                message.InnerHtml = zglobal.insertsuccmsg;
                message.Style.Value = zglobal.successmsg;
                _row.Value = xkey;
                type.Value = xtype;
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
                zglobal.ClearApplicationCache();
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid;
                Int64 xrow;
                string xkey = "";
                string xtype = "";
                message.InnerHtml = "";
                bool isValid = true;
                string xstatus;
                if (GridView1.Rows.Count > 0)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                string xapprovedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xapproveddt = DateTime.Now;
                                xrow = Int64.Parse(row.Cells[6 + (int)ViewState["numrow"]].Text.ToString());

                                CheckBox chkPromoted = row.FindControl("promoted") as CheckBox;
                                if (chkPromoted.Checked)
                                {
                                    xstatus = "Approved";
                                }
                                else
                                {
                                    xstatus = "Canceled";
                                }

                                string query = "UPDATE amadmis SET xstatus=@xstatus,xapprovedby=@xapprovedby,xapproveddt=@xapproveddt " +
                                                "WHERE zid=@zid AND xrow=@xrow ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.Parameters.AddWithValue("@xapprovedby", xapprovedby);
                                cmd.Parameters.AddWithValue("@xapproveddt", xapproveddt);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        BindGrid();
                        message.InnerHtml = zglobal.appsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid;
                string xkey = "";
                string xtype = "";
                message.InnerHtml = "";
                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xname.Text == "" || xname.Text == string.Empty || xname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Student Name</li>";
                        isValid = false;
                    }
                    if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Class</li>";
                        isValid = false;
                    }
                    if (xmname.Text == "" || xmname.Text == string.Empty || xmname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Mother's Name</li>";
                        isValid = false;
                    }
                    if (xcellnom.Text == "" || xcellnom.Text == string.Empty || xcellnom.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Cell No</li>";
                        isValid = false;
                    }
                    if (xfname.Text == "" || xfname.Text == string.Empty || xfname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Father's Name</li>";
                        isValid = false;
                    }
                    if (xcellno1f.Text == "" || xcellno1f.Text == string.Empty || xcellno1f.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Cell No</li>";
                        isValid = false;
                    }
                    if (xdob.Text == "" || xdob.Text == string.Empty || xdob.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Date of Birth</li>";
                        isValid = false;
                    }
                    if (xreligion.Text == "" || xreligion.Text == string.Empty || xreligion.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Religion</li>";
                        isValid = false;
                    }
                    if (xgender.Text == "" || xgender.Text == string.Empty || xgender.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Gender</li>";
                        isValid = false;
                    }
                    if (xnumexam.Text == "" || xnumexam.Text == string.Empty || xnumexam.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Number of Exam</li>";
                        isValid = false;
                    }
                    //if (xexamdate.Text == "" || xexamdate.Text == string.Empty || xexamdate.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Exam Date</li>";
                    //    isValid = false;
                    //}
                    //if (xexamvenue.Text == "" || xexamvenue.Text == string.Empty || xexamvenue.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Exam Venue</li>";
                    //    isValid = false;
                    //}
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    if (xsession_res.Text == "" || xsession_res.Text == string.Empty || xsession_res.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xclass_res.Text == "" || xclass_res.Text == string.Empty || xclass_res.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Class</li>";
                        isValid = false;
                    }
                    //if (xexamroll_res.Text == "" || xexamroll_res.Text == string.Empty || xexamroll_res.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Exam Roll No</li>";
                    //    isValid = false;
                    //}
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    //if (xsession_sport.Text == "" || xsession_sport.Text == string.Empty || xsession_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Session</li>";
                    //    isValid = false;
                    //}
                    //if (xprogramme_sport.Text == "" || xprogramme_sport.Text == string.Empty || xprogramme_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    //    isValid = false;
                    //}
                    //if (xlocation_sport.Text == "" || xlocation_sport.Text == string.Empty || xlocation_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    //    isValid = false;
                    //}
                    //if (xdate_sport.Text == "" || xdate_sport.Text == string.Empty || xdate_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    //    isValid = false;
                    //}
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    //if (xsession_exam.Text == "" || xsession_exam.Text == string.Empty || xsession_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Session</li>";
                    //    isValid = false;
                    //}
                    //if (xlocation_exam.Text == "" || xlocation_exam.Text == string.Empty || xlocation_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>School</li>";
                    //    isValid = false;
                    //}
                    //if (xdate_exam.Text == "" || xdate_exam.Text == string.Empty || xdate_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>End of Mid Term</li>";
                    //    isValid = false;
                    //}
                    //if (xexam_exam.Text == "" || xexam_exam.Text == string.Empty || xexam_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Name of The Exam</li>";
                    //    isValid = false;
                    //}
                    //if (xclass_exam.Text == "" || xclass_exam.Text == string.Empty || xclass_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Class </li>";
                    //    isValid = false;
                    //}
                }
                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
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

                        DateTime ztime = DateTime.Now;
                        DateTime zutime = DateTime.Now;
                        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        Int64 xrow = Convert.ToInt64(_row.Value != "" ? _row.Value : "0");

                        string xsession1 = "";
                        string xname1 = "";
                        string xclass1 = "";
                        string xexamroll1 = "";
                        DateTime xexamdate1 = Convert.ToDateTime("01/01/1900");
                        string xexamvenue1 = "";
                        string xpschool1 = "";
                        string xmname1 = "";
                        string xprofession11 = "";
                        string xfname1 = "";
                        string xprofession12 = "";
                        string xcontact1 = "";
                        string xphone1 = "";
                        string xpadd1 = "";
                        string xperadd1 = "";
                        string xemail11 = "";
                        string xnation1 = "";
                        DateTime xdob1 = DateTime.Now;
                        string xreligion1 = "";
                        string xgender1 = "";
                        string ximagelink1 = "";
                        string calage = zglobal.calculateage;
                        string xnumexam1 = "";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xstdid1 = "";
                        string xsection1 = "";
                        DateTime xadmitdate1 = DateTime.Now;
                        string xoffadd11 = "";
                        string xcellno11 = "";
                        string xmailid11 = "";
                        string xoffadd12 = "";
                        string xcellno12 = "";
                        string xmailid12 = "";
                        string xfimagelink1 = "";
                        string xmimagelink1 = "";
                        string xblood1 = "";
                        string xq11 = "";
                        string xq21 = "";
                        string xq2d1 = "";
                        string xq31 = "";
                        string xq3d1 = "";
                        string xnumchild1 = "";
                        string xchildpos1 = "";
                        string xsibling1 = "";
                        string xq41 = "";
                        string xq51 = "";
                        string xq61 = "";
                        string xq71 = "";
                        string xnamedriver1 = "";
                        string xcellnodriver1 = "";
                        string xniddriver1 = "";
                        string xpadddriver1 = "";
                        string xperadddriver1 = "";
                        string ximagedriver1 = "";
                        string xgroup1 = "";
                        string xhour1 = "12";
                        string xminitue1 = "00";
                        string xperiod1 = "AM";

                        string query = "";
                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            query = "UPDATE amadmis SET zutime=@zutime, xsession=@xsession, xname=@xname, xclass=@xclass, xexamdate=@xexamdate, xexamvenue=@xexamvenue, xpschool=@xpschool, xmname=@xmname, xprofession=@xprofession, xfname=@xfname, xprofession1=@xprofession1, xcontact=@xcontact, xphone=@xphone, xpadd=@xpadd, xperadd=@xperadd, xemail1=@xemail1, xnation=@xnation, xdob=@xdob, xreligion=@xreligion, xgender=@xgender, ximagelink=@ximagelink, xemail=@xemail, xgroup=@xgroup, xcellno=@xcellno, xcellno1=@xcellno1, xnumexam=@xnumexam, xhour=@xhour, xminitue=@xminitue, xperiod=@xperiod  " +
                                    "WHERE zid=@zid  AND xrow=@xrow ";
                            xtype = "day_o";
                            xsession1 = xsession.Text.Trim().ToString();
                            xname1 = xname.Text.Trim().ToString();
                            xclass1 = xclass.Text.Trim().ToString();
                            xexamdate1 = xexamdate.Text.Trim() != string.Empty ? DateTime.ParseExact(xexamdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xexamvenue1 = xexamvenue.Text.Trim().ToString();
                            xpschool1 = xpschool.Text.Trim().ToString();
                            xmname1 = xmname.Text.Trim().ToString();
                            xprofession11 = xprofession.Text.Trim().ToString();
                            xfname1 = xfname.Text.Trim().ToString();
                            xprofession12 = xprofession1.Text.Trim().ToString();
                            xcontact1 = xcontact.Text.Trim().ToString();
                            xphone1 = xphone.Text.Trim().ToString();
                            xpadd1 = xpadd.Text.Trim().ToString();
                            xperadd1 = xperadd.Text.Trim().ToString();
                            xemail11 = xemail1.Text.Trim().ToString();
                            xnation1 = xnation.Text.Trim().ToString();
                            xdob1 = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xreligion1 = xreligion.Text.Trim().ToString();
                            xgender1 = xgender.Text.Trim().ToString();
                            if (rdoCapture.Checked)
                            {
                                ximagelink1 = _stdimageurl.Value.ToString();
                                ximagelink.ImageUrl = ximagelink1;
                            }
                            else
                            {
                                ximagelink1 = ximagelink.ImageUrl.ToString();
                            }
                            xnumexam1 = xnumexam.Text.Trim().ToString();
                            xgroup1 = xgroup.Text.Trim().ToString();
                            xcellno11 = xcellnom.Text.ToString().Trim();
                            xcellno12 = xcellno1f.Text.Trim().ToString();
                            xhour1 = xhour.Text.Trim().ToString();
                            xminitue1 = xminitue.Text.Trim().ToString();
                            xperiod1 = xperiod.Text.Trim().ToString();
                        }
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            //query = "UPDATE amadmis SET zutime=@zutime,xemail=@xemail " +
                            //        "WHERE zid=@zid AND xrow=@xrow ";
                            //xtype = "out";
                            ////xnumexam1 = xnumexam.Text.Trim().ToString();
                            //xclass1 = xclass_res.Text.Trim().ToString();

                        }
                        else if (TabContainer1.ActiveTabIndex == 2)
                        {
                            query = "UPDATE amadmis SET zutime=@zutime,xstdid=@xstdid,xsection=@xsection,xadmitdate=@xadmitdate,xoffadd=@xoffadd, " +
                                     "xcellno=@xcellno,xmailid=@xmailid,xoffadd1=@xoffadd1,xcellno1=@xcellno1,xmailid1=@xmailid1,xfimagelink=@xfimagelink, " +
                                     "xmimagelink=@xmimagelink,xblood=@xblood,xq1=@xq1,xq2=@xq2,xq2d=@xq2d,xq3=@xq3,xq3d=@xq3d,xnumchild=@xnumchild, " +
                                     "xchildpos=@xchildpos,xsibling=@xsibling,xq4=@xq4,xq5=@xq5,xq6=@xq6,xq7=@xq7,xnamedriver=@xnamedriver, " +
                                     "xcellnodriver=@xcellnodriver,xniddriver=@xniddriver,xpadddriver=@xpadddriver,xperadddriver=@xperadddriver, " +
                                     "ximagedriver=@ximagedriver,xemail=@xemail " +
                                    "WHERE zid=@zid AND xrow=@xrow ";
                            xtype = "sport";
                            string xroll = zglobal.fnChkRoll(_zid, xrow);
                            if (xroll == "")
                            {
                                xstdid1 = zglobal.GetRollNo("xstdid", "amadmis", "zid=" + _zid + " AND xsession='" + xsession_admis.Text.ToString().Trim() + "' AND xclass= '" + xclass_admis.Text.Trim().ToString() + "'", 2);
                                //xstdid1 = zglobal.GetRollNo("xstdid", "amadmis", "zid=" + _zid + " AND xrow=" + xrow , 2);
                            }
                            else
                            {
                                xstdid1 = xroll;
                            }
                            xstdid.Text = xstdid1;
                            xsection1 = xsection.Text.Trim().ToString();
                            xadmitdate1 = xadmitdate.Text.Trim() != string.Empty ? DateTime.ParseExact(xadmitdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xoffadd11 = xoffadd.Value.Trim().ToString();
                            xcellno11 = xcellno.Text.Trim().ToString();
                            xmailid11 = xmailid.Text.Trim().ToString();
                            xoffadd12 = xoffadd1.Value.Trim().ToString();
                            xcellno12 = xcellno1.Text.Trim().ToString();
                            xmailid12 = xmailid1.Text.Trim().ToString();
                            xfimagelink1 = xfimagelink.ImageUrl.ToString();
                            xmimagelink1 = xmimagelink.ImageUrl.ToString();
                            xblood1 = xblood.Text.Trim().ToString();
                            xq11 = xq1.Text.Trim().ToString();
                            xq21 = xq2.Text.Trim().ToString();
                            xq2d1 = xq2d.Value.Trim().ToString();
                            xq31 = xq3.Text.Trim().ToString();
                            xq3d1 = xq3d.Value.Trim().ToString();
                            xnumchild1 = xnumchild.Text.Trim().ToString();
                            xchildpos1 = xchildpos.Text.Trim().ToString();
                            xsibling1 = xsibling.Text.Trim().ToString();
                            xq41 = xq4.Text.Trim().ToString();
                            xq51 = xq5.Text.Trim().ToString();
                            xq61 = xq6.Text.Trim().ToString();
                            xq71 = xq7.Text.Trim().ToString();
                            xnamedriver1 = xname_driver.Text.Trim().ToString();
                            xcellnodriver1 = xcellno_driver.Text.Trim().ToString();
                            xniddriver1 = xnid_driver.Text.Trim().ToString();
                            xpadddriver1 = xpadd_driver.Value.Trim().ToString();
                            xperadddriver1 = xperadd_driver.Value.Trim().ToString();
                            ximagedriver1 = ximage.ImageUrl.ToString();

                        }
                        else if (TabContainer1.ActiveTabIndex == 3)
                        {
                            //query = "UPDATE mscalender SET zutime=@zutime,xsession=@xsession,xlocation=@xlocation,xdate=@xdate,xexam=@xexam,xfclass=@xfclass,xfdate=@xfdate,xtdate=@xtdate,xffdate=@xffdate,xresultdate=@xresultdate,xconvenor=@xconvenor,xprogdetail=@xprogdetail,xcalendertype=@xcalendertype,xemail=@xemail " +
                            //        "WHERE zid=@zid AND xtype=@xtype AND xrow=@xrow ";
                            //xtype = "exam";
                            //xrow = Convert.ToInt32(_row.Value != "" ? _row.Value : "0");
                            //xsession = xsession_exam.Text.Trim().ToString();
                            //xlocation = xlocation_exam.Text.Trim().ToString();
                            //xdate = xdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xexam = xexam_exam.Text.Trim().ToString();
                            //xfclass = xclass_exam.Text.Trim().ToString();
                            //xfdate = xfdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xffdate = xsubmission_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xsubmission_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xresultdate = xresultdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                            //xconvenor = xconvenor_exam.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_exam.InnerText.Trim().ToString();
                        }



                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        //cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xsession", xsession1);
                        cmd.Parameters.AddWithValue("@xname", xname1);
                        cmd.Parameters.AddWithValue("@xclass", xclass1);
                        cmd.Parameters.AddWithValue("@xexamroll", xexamroll1);
                        cmd.Parameters.AddWithValue("@xexamdate", xexamdate1);
                        cmd.Parameters.AddWithValue("@xexamvenue", xexamvenue1);
                        cmd.Parameters.AddWithValue("@xpschool", xpschool1);
                        cmd.Parameters.AddWithValue("@xmname", xmname1);
                        cmd.Parameters.AddWithValue("@xprofession", xprofession11);
                        cmd.Parameters.AddWithValue("@xfname", xfname1);
                        cmd.Parameters.AddWithValue("@xprofession1", xprofession12);
                        cmd.Parameters.AddWithValue("@xcontact", xcontact1);
                        cmd.Parameters.AddWithValue("@xphone", xphone1);
                        cmd.Parameters.AddWithValue("@xpadd", xpadd1);
                        cmd.Parameters.AddWithValue("@xperadd", xperadd1);
                        cmd.Parameters.AddWithValue("@xemail1", xemail11);
                        cmd.Parameters.AddWithValue("@xnation", xnation1);
                        cmd.Parameters.AddWithValue("@xdob", xdob1);
                        cmd.Parameters.AddWithValue("@xreligion", xreligion1);
                        cmd.Parameters.AddWithValue("@xgender", xgender1);
                        cmd.Parameters.AddWithValue("@ximagelink", ximagelink1);
                        cmd.Parameters.AddWithValue("@xnumexam", xnumexam1);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xemail", xemail);
                        cmd.Parameters.AddWithValue("@xstdid", xstdid1);
                        cmd.Parameters.AddWithValue("@xsection", xsection1);
                        cmd.Parameters.AddWithValue("@xadmitdate", xadmitdate1);
                        cmd.Parameters.AddWithValue("@xoffadd", xoffadd11);
                        cmd.Parameters.AddWithValue("@xcellno", xcellno11);
                        cmd.Parameters.AddWithValue("@xmailid", xmailid11);
                        cmd.Parameters.AddWithValue("@xoffadd1", xoffadd12);
                        cmd.Parameters.AddWithValue("@xcellno1", xcellno12);
                        cmd.Parameters.AddWithValue("@xmailid1", xmailid12);
                        cmd.Parameters.AddWithValue("@xfimagelink", xfimagelink1);
                        cmd.Parameters.AddWithValue("@xmimagelink", xmimagelink1);
                        cmd.Parameters.AddWithValue("@xblood", xblood1);
                        cmd.Parameters.AddWithValue("@xq1", xq11);
                        cmd.Parameters.AddWithValue("@xq2", xq21);
                        cmd.Parameters.AddWithValue("@xq2d", xq2d1);
                        cmd.Parameters.AddWithValue("@xq3", xq31);
                        cmd.Parameters.AddWithValue("@xq3d", xq3d1);
                        cmd.Parameters.AddWithValue("@xnumchild", xnumchild1);
                        cmd.Parameters.AddWithValue("@xchildpos", xchildpos1);
                        cmd.Parameters.AddWithValue("@xsibling", xsibling1);
                        cmd.Parameters.AddWithValue("@xq4", xq41);
                        cmd.Parameters.AddWithValue("@xq5", xq51);
                        cmd.Parameters.AddWithValue("@xq6", xq61);
                        cmd.Parameters.AddWithValue("@xq7", xq71);
                        cmd.Parameters.AddWithValue("@xnamedriver", xnamedriver1);
                        cmd.Parameters.AddWithValue("@xcellnodriver", xcellnodriver1);
                        cmd.Parameters.AddWithValue("@xniddriver", xniddriver1);
                        cmd.Parameters.AddWithValue("@xpadddriver", xpadddriver1);
                        cmd.Parameters.AddWithValue("@xperadddriver", xperadddriver1);
                        cmd.Parameters.AddWithValue("@ximagedriver", ximagedriver1);
                        cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                        cmd.Parameters.AddWithValue("@xhour", xhour1);
                        cmd.Parameters.AddWithValue("@xminitue", xminitue1);
                        cmd.Parameters.AddWithValue("@xperiod", xperiod1);
                        if (TabContainer1.ActiveTabIndex != 1)
                        {
                            cmd.ExecuteNonQuery();
                        }


                        //message.InnerHtml = "Update";
                        if (TabContainer1.ActiveTabIndex == 1)
                        {
                            //message.InnerHtml = message.InnerHtml + "Inner Tab";
                            if (GridView1.Rows.Count > 0)
                            {

                                ////message.InnerHtml = message.InnerHtml + "Inner Grid";
                                //query = "DELETE FROM amadmisd WHERE zid=@zid AND xrow IN (SELECT xrow FROM amadmis WHERE  zid=@zid AND xsession=@xsession AND xnumexam=@xnumexam AND xclass=@xclass AND xgroup=@xgroup)";
                                //cmd.Parameters.Clear();
                                //xsession1 = xsession_res.Text.Trim().ToString();
                                //xnumexam1 = xnumexam_res.Text.Trim().ToString();
                                //xclass1 = xclass_res.Text.Trim().ToString();
                                //xgroup1 = xgroup_res.Text.Trim().ToString();

                                //cmd.CommandText = query;
                                //cmd.Parameters.AddWithValue("@zid", _zid);
                                //cmd.Parameters.AddWithValue("@xsession", xsession1);
                                //cmd.Parameters.AddWithValue("@xnumexam", xnumexam1);
                                //cmd.Parameters.AddWithValue("@xclass", xclass1);
                                //cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                                //cmd.ExecuteNonQuery();

                                //int i = 1;
                                int totmark = 0;
                                int j;
                                string xstatus = "";
                                string xstatus1 = "";
                                string xremarks = "";
                                foreach (GridViewRow row in GridView1.Rows)
                                {
                                    //Change Index
                                    j = 0;
                                    totmark = 0;
                                    xrow = Int64.Parse(row.Cells[6 + (int)ViewState["numrow"]].Text.ToString());
                                    xstatus = row.Cells[7 + (int) ViewState["numrow"]].Text.ToString();
                                    xstatus1 = row.Cells[13 + (int)ViewState["numrow"]].Text.ToString();
                                    TextBox txtTextBox1 = row.FindControl("txtRemarks") as TextBox;
                                    TextBox txtDate1 = row.FindControl("txtDate") as TextBox;
                                    DateTime xvivadate11 = txtDate1.Text.Trim() != string.Empty ? DateTime.ParseExact(txtDate1.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    DropDownList xhour11 = row.FindControl("xhour1") as DropDownList;
                                    DropDownList xminitue11 = row.FindControl("xminitue1") as DropDownList;
                                    DropDownList xperiod11 = row.FindControl("xperiod1") as DropDownList;
                                    DropDownList xexamvenue11 = row.FindControl("xexamvenue1") as DropDownList;
                                    xremarks = txtTextBox1.Text.Trim().ToString();

                                    if (xstatus1 == "n")
                                    {
                                        query = "UPDATE amadmis SET xvivadate=@xvivadate,xhour1=@xhour1,xminitue1=@xminitue1,xperiod1=@xperiod1,xexamvenue1=@xexamvenue1,xremarks=@xremarks,zutime=@zutime,xemail=@xemail " +
                                                "WHERE zid=@zid AND xrow=@xrow ";
                                        cmd.Parameters.Clear();

                                        cmd.CommandText = query;
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@xrow", xrow);
                                        cmd.Parameters.AddWithValue("@zutime", zutime);
                                        cmd.Parameters.AddWithValue("@xemail", xemail);
                                        cmd.Parameters.AddWithValue("@xremarks", xremarks);
                                        cmd.Parameters.AddWithValue("@xvivadate", xvivadate11);
                                        cmd.Parameters.AddWithValue("@xhour1", xhour11.Text.Trim().ToString());
                                        cmd.Parameters.AddWithValue("@xminitue1", xminitue11.Text.Trim().ToString());
                                        cmd.Parameters.AddWithValue("@xperiod1", xperiod11.Text.Trim().ToString());
                                        cmd.Parameters.AddWithValue("@xexamvenue1", xexamvenue11.Text.Trim().ToString());
                                        cmd.ExecuteNonQuery();

                                        query = "DELETE FROM amadmisd WHERE zid=@zid AND xrow=@xrow";
                                        cmd.Parameters.Clear();

                                        cmd.CommandText = query;
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@xrow", xrow);
                                        cmd.ExecuteNonQuery();

                                        for (int i = 4; i < 4 + (int) ViewState["numrow"]; i++)
                                        {
                                            //message.InnerHtml = message.InnerHtml + " " +
                                            //    row.Cells[5 + (int) ViewState["numrow"]].Text.ToString();
                                            //    row.Cells[9].Text;
                                            cmd.Parameters.Clear();

                                            int xline = zglobal.GetMaximumIdInt("xline", "amadmisd",
                                                " zid=" + _zid + " and xrow=" + xrow, "line");
                                            int xgetmark = 0;
                                            TextBox txtTextBox = row.FindControl("txtSub" + i.ToString()) as TextBox;
                                            if (txtTextBox.Text == "" || txtTextBox.Text == String.Empty)
                                            {
                                                xgetmark = 0;
                                            }
                                            else
                                            {
                                                xgetmark = Int32.Parse(txtTextBox.Text.Trim().ToString());
                                            }

                                            //string xremarks = "";
                                            //TextBox txtTextBox1 = row.FindControl("txtRemarks") as TextBox;
                                            //xremarks = txtTextBox1.Text.Trim().ToString();
                                            //string marks2;
                                            //string marks1;

                                            //    if (i % 2 == 0)
                                            //    {
                                            //        marks2 = ((TextBox)placeholder.FindControl("txtgetm2" + i)).Text.ToString().Trim();
                                            //        //message.InnerHtml = message.InnerHtml + marks2 + " - ";
                                            //        if (marks2 == "" || marks2 == String.Empty)
                                            //        {
                                            //            marks2 = "0";
                                            //        }
                                            //        xgetmark = Convert.ToInt32(marks2);
                                            //    }
                                            //    else
                                            //    {
                                            //        marks1 = ((TextBox)placeholder.FindControl("txtgetm1" + i)).Text.ToString().Trim();
                                            //        //message.InnerHtml = message.InnerHtml + marks1 + " - ";
                                            //        if (marks1 == "" || marks1 == String.Empty)
                                            //        {
                                            //            marks1 = "0";
                                            //        }
                                            //        xgetmark = Convert.ToInt32(marks1);
                                            //    }

                                            query =
                                                "INSERT INTO amadmisd (zid,xrow,xline,xsubject,xmark,xpassmark,xgetmark) " +
                                                "VALUES(@zid,@xrow,@xline,@xsubject,@xmark,@xpassmark,@xgetmark) ";

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xrow", xrow);
                                            cmd.Parameters.AddWithValue("@xline", xline);
                                            //cmd.Parameters.AddWithValue("@xrowmarks", Convert.ToInt32(row["xrowmarks"]));
                                            cmd.Parameters.AddWithValue("@xsubject", dt.Rows[j][0].ToString());
                                            cmd.Parameters.AddWithValue("@xmark",
                                                Convert.ToInt32(dt.Rows[j][1].ToString()));
                                            cmd.Parameters.AddWithValue("@xpassmark",
                                                Convert.ToInt32(dt.Rows[j][2].ToString()));
                                            cmd.Parameters.AddWithValue("@xgetmark", xgetmark);
                                            //    //message.InnerHtml = row["zid"] + " - " + row["xrow"] + " - " + xline + " - " + row["xrowmarks"] + " - " + row["xsubject"] + " - " + row["xmark"] + " - " + row["xpassmark"];
                                            //if (xgetmark != 0)
                                            //{
                                                cmd.ExecuteNonQuery();
                                            //}
                                            totmark = totmark + xgetmark;
                                            //    i = i + 1;

                                            j = j + 1;
                                        }

                                        Label lblMarks = row.FindControl("xstotmarks") as Label;
                                        Label lblPass = row.FindControl("xspercent") as Label;

                                        lblMarks.Text = totmark.ToString();
                                        lblPass.Text = (100*totmark/Int32.Parse(xtotalmaks.Text)).ToString() + "%";

                                        int passmarks = Int32.Parse(xpassmarks.Text.TrimEnd('%'));
                                        if ((100 * totmark / Int32.Parse(xtotalmaks.Text)) >= passmarks)
                                        {
                                            CheckBox chkPromoted = row.FindControl("promoted") as CheckBox;
                                            chkPromoted.Checked = true;
                                        }
                                    }
                                }

                                //((TextBox)placeholder.FindControl("txttot2")).Text = totmark.ToString();
                            }

                        }



                        //Insert into zreclog
                        //zglobal.fnRecordLog(xrow.ToString(), "Edit", "", "", "", 0, xdate);


                    }

                    //fnFillDataGrid();
                    //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();


                }
                message.InnerHtml = zglobal.updatesuccmsg;
                message.Style.Value = zglobal.successmsg;
                //_row.Value = xkey;
                //type.Value = xtype;
                // message.InnerHtml = _row.Value;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //try
            //{
            //    ErrorMsg.InnerHtml = "";
            //    bool isValidFile = false;

            //    if (FileUpload1.HasFile)
            //    {
            //        string[] validFileTypes = { "bmp", "png", "jpg", "jpeg" };

            //        string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);



            //        for (int i = 0; i < validFileTypes.Length; i++)
            //        {

            //            if (ext == "." + validFileTypes[i])
            //            {

            //                isValidFile = true;

            //                break;

            //            }

            //        }

            //        if (!isValidFile)
            //        {


            //            ErrorMsg.InnerHtml = "Invalid File. Please upload a File with extension<br> " +

            //                           string.Join(",", validFileTypes);
            //            //ErrorMsg.Style.Value = zglobal.errormsg;
            //            //return;
            //        }


            //        if (FileUpload1.PostedFile.ContentLength > 100000)
            //        {
            //            ErrorMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image size. (Max size 100KB)<br>";
            //            //ErrorMsg.Style.Value = zglobal.errormsg;
            //            isValidFile = false;
            //            //return;
            //        }
            //        else
            //        {
            //            isValidFile = true;
            //        }

            //        Bitmap bitmp = new Bitmap(FileUpload1.PostedFile.InputStream);
            //        if (bitmp.Width != 300 & bitmp.Height != 300)
            //        {
            //            ErrorMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image dimension. (Dimension must be 300x300)";
            //            //ErrorMsg.Style.Value = zglobal.errormsg;
            //            isValidFile = false;
            //            //return;
            //        }
            //        else
            //        {
            //            isValidFile = true;
            //        }

            //        if (!isValidFile)
            //        {
            //            return;
            //        }

            //        //if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
            //        //{
            //        string filename = FileUpload1.FileName;
            //        FileUpload1.SaveAs(Server.MapPath("~/images/profile/student/") + filename);
            //        ximagelink.ImageUrl = "~/images/profile/student/" + filename;
            //        ErrorMsg.InnerHtml = "";
            //        //}
            //        //else
            //        //{
            //        //    ErrorMsg.Visible = true;
            //        //    ErrorMsg.InnerHtml = "Invalid File, Cannot Upload!";
            //        //}
            //    }
            //    else
            //    {
            //        ErrorMsg.Visible = true;
            //        ErrorMsg.InnerHtml = "Please select a File";
            //        //ErrorMsg.Style.Value = zglobal.errormsg;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
            fnImageUpload(ErrorMsg, FileUpload1, "~/images/profile/student/", ximagelink);
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            fnImageUpload(Div1, FileUpload2, "~/images/profile/student/", ximagelink_admis);
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            fnImageUpload(Div2, FileUpload4, "~/images/profile/mother/", xmimagelink);
        }
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            fnImageUpload(Div3, FileUpload5, "~/images/profile/father/", xfimagelink);
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            fnImageUpload(Div4, FileUpload3, "~/images/profile/guardian/", ximage);
        }

        private void fnImageUpload(HtmlGenericControl ErrMsg, FileUpload fileUpload, string path, System.Web.UI.WebControls.Image image)
        {
            try
            {
                ErrMsg.InnerHtml = "";
                bool isValidFile = false;

                if (fileUpload.HasFile)
                {
                    string[] validFileTypes = { "bmp", "png", "jpg", "jpeg" };

                    string ext = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);



                    for (int i = 0; i < validFileTypes.Length; i++)
                    {

                        if (ext == "." + validFileTypes[i])
                        {

                            isValidFile = true;

                            break;

                        }

                    }

                    if (!isValidFile)
                    {


                        ErrMsg.InnerHtml = "Invalid File. Please upload a File with extension<br> " +

                                       string.Join(",", validFileTypes);
                        //ErrorMsg.Style.Value = zglobal.errormsg;
                        //return;
                    }


                    if (fileUpload.PostedFile.ContentLength > 100000)
                    {
                        ErrMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image size. (Max size 100KB)<br>";
                        //ErrorMsg.Style.Value = zglobal.errormsg;
                        isValidFile = false;
                        //return;
                    }
                    else
                    {
                        isValidFile = true;
                    }

                    Bitmap bitmp = new Bitmap(fileUpload.PostedFile.InputStream);
                    if (bitmp.Width != 300 & bitmp.Height != 300)
                    {
                        ErrMsg.InnerHtml = ErrMsg.InnerHtml + "Invalid image dimension. (Dimension must be 300x300)";
                        //ErrorMsg.Style.Value = zglobal.errormsg;
                        isValidFile = false;
                        //return;
                    }
                    else
                    {
                        isValidFile = true;
                    }

                    if (!isValidFile)
                    {
                        return;
                    }

                    //if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                    //{
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    //string filename = fileUpload.FileName;
                    string folderPath = HttpContext.Current.Server.MapPath(path + _zid.ToString() + "/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    Int64 xrow;
                    if (_row.Value.ToString() == "" || _row.Value.ToString() == String.Empty)
                    {
                        xrow = zglobal.GetMaximumIdInt("xrow", "amadmis", " zid=" + _zid, 1);
                    }
                    else
                    {
                        xrow = Int64.Parse(_row.Value.ToString());
                    }
                    string fileName = _zid.ToString() + "_" + xrow.ToString() + "_" + DateTime.Now.Ticks.ToString() + extension;
                    string imagePath = folderPath + fileName;
                    fileUpload.SaveAs(imagePath);
                    image.ImageUrl = path + _zid.ToString() + "/" + fileName;
                    ErrMsg.InnerHtml = "";
                    //}
                    //else
                    //{
                    //    ErrorMsg.Visible = true;
                    //    ErrorMsg.InnerHtml = "Invalid File, Cannot Upload!";
                    //}
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.InnerHtml = "Please select a File";
                    //ErrorMsg.Style.Value = zglobal.errormsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected bool IsImageFile(HttpPostedFile file)
        {
            bool isImage = false;
            System.IO.FileStream fs = new System.IO.FileStream(file.FileName,
              System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            string fileclass = "";
            byte buffer = br.ReadByte();
            fileclass = buffer.ToString();
            buffer = br.ReadByte();
            fileclass += buffer.ToString();
            br.Close();
            fs.Close();

            //only allow images    jpg       gif     bmp     png      
            String[] fileType = { "255216", "7173", "6677", "13780" };
            for (int i = 0; i < fileType.Length; i++)
            {
                if (fileclass == fileType[i])
                {
                    isImage = true;
                    break;
                }
            }
            return isImage;
        }

        protected void fnImageCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoCapture.Checked)
                {
                    FileUpload1.Visible = false;
                    ImageButton3.Visible = false;
                    ErrorMsg.InnerText = "";
                }
                if (rdoUpload.Checked)
                {
                    FileUpload1.Visible = true;
                    ImageButton3.Visible = true;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }


        protected void fnCalculateAge(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime age = DateTime.ParseExact(zglobal.calculateage, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    int day = Convert.ToInt32(age.Day);
            //    int month = Convert.ToInt32(age.Month);
            //    int year = Convert.ToInt32(DateTime.Now.Year);
            //    DateTime Now = new DateTime(year, month, day);
            //    DateTime dob = DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    int Years = new DateTime(Now.Subtract(dob).Ticks).Year - 1;
            //    DateTime PastYearDate = dob.AddYears(Years);
            //    int Months = 0;
            //    for (int i = 1; i <= 12; i++)
            //    {
            //        if (PastYearDate.AddMonths(i) == Now)
            //        {
            //            Months = i;
            //            break;
            //        }
            //        else if (PastYearDate.AddMonths(i) >= Now)
            //        {
            //            Months = i - 1;
            //            break;
            //        }
            //    }

            //    xage.Text = String.Format("{0}Y - {1}M ", Years, Months);
            //    message.InnerHtml = "";
            //}
            //catch (Exception exp)
            //{
            //    xage.Text = "";
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
            if (TabContainer1.TabIndex == 0)
            {
                fnAge(xage, xdob);
            }
            else if (TabContainer1.TabIndex == 1)
            {
                fnAge(xage_admis, xdob_admis);
            }
        }

        private void fnAge(TextBox calAge, TextBox txtdob)
        {
            try
            {
                DateTime age = DateTime.ParseExact(zglobal.calculateage, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int day = Convert.ToInt32(age.Day);
                int month = Convert.ToInt32(age.Month);
                int year = Convert.ToInt32(DateTime.Now.Year);
                DateTime Now = new DateTime(year, month, day);
                DateTime dob = DateTime.ParseExact(txtdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int Years = new DateTime(Now.Subtract(dob).Ticks).Year - 1;
                DateTime PastYearDate = dob.AddYears(Years);
                int Months = 0;
                for (int i = 1; i <= 12; i++)
                {
                    if (PastYearDate.AddMonths(i) == Now)
                    {
                        Months = i;
                        break;
                    }
                    else if (PastYearDate.AddMonths(i) >= Now)
                    {
                        Months = i - 1;
                        break;
                    }
                }

                calAge.Text = String.Format("{0}Y - {1}M ", Years, Months);
                message.InnerHtml = "";
            }
            catch (Exception exp)
            {
                xage.Text = "";
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        //static string CalculateAge(DateTime Dob)
        //{
        //    DateTime Now = DateTime.Now;
        //    int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
        //    DateTime PastYearDate = Dob.AddYears(Years);
        //    int Months = 0;
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        if (PastYearDate.AddMonths(i) == Now)
        //        {
        //            Months = i;
        //            break;
        //        }
        //        else if (PastYearDate.AddMonths(i) >= Now)
        //        {
        //            Months = i - 1;
        //            break;
        //        }
        //    }
        //    int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
        //    int Hours = Now.Subtract(PastYearDate).Hours;
        //    int Minutes = Now.Subtract(PastYearDate).Minutes;
        //    int Seconds = Now.Subtract(PastYearDate).Seconds;
        //    return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
        //    Years, Months, Days, Hours, Seconds);
        //}  


        protected void fnExportToPdf(object sender, EventArgs e)
        {
            try
            {

                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //GridView1.AllowPaging = false;
                //GridView1.DataBind();
                //GridView1.RenderControl(hw);
                //StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();

                //PdfPTable pdfPTable  = new PdfPTable(GridView1.HeaderRow.Cells.Count);
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    foreach (TableCell cell in row.Cells)
                //    {
                //        PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Text));
                //        pdfPTable.AddCell(pdfCell);
                //    }
                //}
                //Document pdfDocument = new Document(PageSize.A4,10f,10f,10f,10f);
                //PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
                //pdfDocument.Open();
                //pdfDocument.Add(pdfPTable);
                //pdfDocument.Close();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition","attachment;filename=Result.pdf");
                //Response.Write(pdfDocument);
                //Response.Flush();
                //Response.End();
                try
                {
                    if (TabContainer1.ActiveTabIndex == 1)
                    {
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        string xsession1 = xsession_res.Text.Trim().ToString();
                        string xclass1 = xclass_res.Text.Trim().ToString();
                        string xgroup1 = xgroup_res.Text.Trim().ToString();
                        string xnumexam1 = xnumexam_res.Text.Trim().ToString();
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        //crystalReport.DataSourceConnections.Clear();
                        crystalReport.Load(Server.MapPath("~/reports/stdadmisresult.rpt")); // path of report 
                        crystalReport.SetParameterValue("zid", _zid);
                        crystalReport.SetParameterValue("xsession", xsession1);
                        crystalReport.SetParameterValue("xclass", xclass1);
                        crystalReport.SetParameterValue("xgroup", xgroup1);
                        crystalReport.SetParameterValue("xnumexam", xnumexam1);
                        //crystalReport.SetDataSource(datatable); // binding datatable
                        //CrystalReportViewer1.ReportSource = crystalReport;

                        crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "result");
                    }
                }
                catch (Exception exp)
                {
                    xage.Text = "";
                    message.InnerHtml = exp.Message;
                    message.Style.Value = zglobal.errormsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        protected void fnExportToWord(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (TabContainer1.ActiveTabIndex == 1)
                    {
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        string xsession1 = xsession_res.Text.Trim().ToString();
                        string xclass1 = xclass_res.Text.Trim().ToString();
                        string xgroup1 = xgroup_res.Text.Trim().ToString();
                        string xnumexam1 = xnumexam_res.Text.Trim().ToString();
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        //crystalReport.DataSourceConnections.Clear();
                        crystalReport.Load(Server.MapPath("~/reports/stdadmisresult.rpt")); // path of report 
                        crystalReport.SetParameterValue("zid", _zid);
                        crystalReport.SetParameterValue("xsession", xsession1);
                        crystalReport.SetParameterValue("xclass", xclass1);
                        crystalReport.SetParameterValue("xgroup", xgroup1);
                        crystalReport.SetParameterValue("xnumexam", xnumexam1);
                        //crystalReport.SetDataSource(datatable); // binding datatable
                        //CrystalReportViewer1.ReportSource = crystalReport;

                        crystalReport.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "result");
                    }
                }
                catch (Exception exp)
                {
                    xage.Text = "";
                    message.InnerHtml = exp.Message;
                    message.Style.Value = zglobal.errormsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        protected void fnExportToExcel(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (TabContainer1.ActiveTabIndex == 1)
                    {
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        string xsession1 = xsession_res.Text.Trim().ToString();
                        string xclass1 = xclass_res.Text.Trim().ToString();
                        string xgroup1 = xgroup_res.Text.Trim().ToString();
                        string xnumexam1 = xnumexam_res.Text.Trim().ToString();
                        ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report
                        //crystalReport.DataSourceConnections.Clear();
                        crystalReport.Load(Server.MapPath("~/reports/stdadmisresult.rpt")); // path of report 
                        crystalReport.SetParameterValue("zid", _zid);
                        crystalReport.SetParameterValue("xsession", xsession1);
                        crystalReport.SetParameterValue("xclass", xclass1);
                        crystalReport.SetParameterValue("xgroup", xgroup1);
                        crystalReport.SetParameterValue("xnumexam", xnumexam1);
                        //crystalReport.SetDataSource(datatable); // binding datatable
                        //CrystalReportViewer1.ReportSource = crystalReport;

                        crystalReport.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "result");
                    }
                }
                catch (Exception exp)
                {
                    xage.Text = "";
                    message.InnerHtml = exp.Message;
                    message.Style.Value = zglobal.errormsg;
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