using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class asctschedule : System.Web.UI.Page
    {
        // List<string> sec = new List<string>() { "P", "M", "J", "S", "K" };
        // List<string> period = new List<string>() { "1st Period", "2nd Period", "3rd Period", "4th Period", "5th Period", "6th Period", "7th Period", "8th Period", "9th Period" };

        private void fnPageLoad()
        {
            zglobal.fnGetComboDataCD("Session", xsession);
            zglobal.fnGetComboDataCD("Term", xterm);
            zglobal.fnGetComboDataCD("Class", xclass);
            zglobal.fnGetComboDataCD("Education Group", xgroup);
            zglobal.fnGetComboDataCD("Class Subject", xsubject);
            zglobal.fnGetComboDataCD("Subject Paper", xpaper);
            xpaper.Items.Remove("C. C. E");
            xpaper.Items.Remove("C. P. E");
            xpaper.Items.Remove("Cr. Writing");
            xpaper.Items.Remove("Ext. Spk.");
            xpaper.Items.Remove("P. E");
            xpaper.Items.Remove("Reading");
            xpaper.Items.Remove("Spl. Dict.");
            xpaper.Items.Remove("Spl. Dict. & Reading");
            zglobal.fnGetComboDataCD("Subject Extension", xext);
            zglobal.fnGetComboDataCalendar(xdate);
            //xdate.Items.Add(new ListItem("January 1999","1/1/1999"));
            //xdate.SelectedIndex = xdate.Items.IndexOf(xdate.Items.FindByText("January 1999"));
            ViewState["xrow"] = null;
            hxrow.Value = "";
            ViewState["xstatus"] = null;
            dxstatus.Visible = false;
            btnPrint.Visible = false;
            _classteacher.Value = "";
            _subteacher.Value = "";
            //xdate.Enabled = false;
            //btnSubmit.Enabled = false;
            //BindGrid(1999, 1);

            xsession.Text = zglobal.fnDefaults("xsession", "Student");
            xterm.Text = zglobal.fnDefaults("xterm", "Student");

            btnSave.Enabled = true;
            btnSave1.Enabled = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCalendar(xdate);
                    ////xdate.Items.Add(new ListItem("January 1999","1/1/1999"));
                    ////xdate.SelectedIndex = xdate.Items.IndexOf(xdate.Items.FindByText("January 1999"));
                    //ViewState["xrow"] = null;
                    //hxrow.Value = "";
                    //ViewState["xstatus"] = null;
                    //dxstatus.Visible = false;
                    //btnPrint.Visible = false;
                    //_classteacher.Value = "";
                    //_subteacher.Value = "";
                    ////xdate.Enabled = false;
                    ////btnSubmit.Enabled = false;
                    ////BindGrid(1999, 1);

                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    fnPageLoad();
                }


                if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                {
                    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                    BindGrid(year, month);
                }
                else
                {
                    BindGrid(1999, 1);
                    //GridView1.DataSource = null;
                    //GridView1.DataBind();
                }

                btnSubmit.Visible = false;
                btnSubmit1.Visible = false;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable dtsec;
        //private int check = 0;

        private void BindGrid(int year1, int month1)
        {

            if (ViewState["xrow"] == null)
            {
                //xdate.Enabled = false;
                //xdate.Enabled = false;
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
            }
            else
            {
                //xdate.Enabled = true;

                if (ViewState["xstatus"].ToString() == "New")
                {
                    btnSubmit.Enabled = true;
                    btnSubmit1.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = false;
                    btnSubmit1.Enabled = false;
                }
            }



            if (year1 == 1999 && month1 == 1)
            {
                ViewState["check"] = "1";
            }
            else
            {
                ViewState["check"] = "0";
            }

            GridView1.Columns.Clear();



            dt = new DataTable();
            dt.Columns.Add("xdate");
            dt.Columns.Add("xsection");
            dt.Columns.Add("xdate1");
            dt.Columns.Add("xsection1");



            int year = year1;
            int month = month1;

            DateTime date = new DateTime(year, month, 1);
            string sdt = date.ToString("ddd") + "<br/>" + date.ToString("dd/MM");

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            string str = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Section' AND zactive=1 ORDER BY xcodealt";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.Fill(dts, "tempztcode");
            dtsec = new DataTable();
            dtsec = dts.Tables[0];





            do
            {
                foreach (DataRow val in dtsec.Rows)
                {
                    dt.Rows.Add(sdt, val["xdescdet"].ToString(), date, val["xcode"].ToString());
                }
                // dt.Rows.Add("", "", "","na");
                date = date.AddDays(1);
                sdt = date.ToString("ddd") + "<br/>" + date.ToString("dd/MM");
            } while (date.Month == month);

            //dt.Rows.Add("Title1", "3", "3/27/2015");
            //dt.Rows.Add("Title2", "5", "3/26/2015");
            //dt.Rows.Add("Title3", "2", "3/27/2015");
            //dt.Rows.Add("Title4", "8", "3/27/2015");
            //dt.Rows.Add("Title5", "9", "3/28/2015");

            bfield = new BoundField();
            bfield.HeaderText = "Days";
            bfield.DataField = "xdate";
            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfield.ItemStyle.Width = 30;
            bfield.HeaderStyle.Width = 30;
            bfield.HtmlEncode = false;
            GridView1.Columns.Add(bfield); ;

            bfield = new BoundField();
            bfield.HeaderText = "Sec";
            bfield.DataField = "xsection";
            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfield.ItemStyle.Width = 10;
            bfield.HeaderStyle.Width = 10;
            GridView1.Columns.Add(bfield);




            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Period' AND zactive=1 ORDER BY xcodealt";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@zid", _zid);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int rowCount = 0;
                while (rdr.Read())
                {
                    tfield = new TemplateField();
                    tfield.HeaderText = rdr["xcode"].ToString();
                    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield.ItemStyle.Width = 120;
                    tfield.HeaderStyle.Width = 120;
                    GridView1.Columns.Add(tfield);
                    rowCount = rowCount + 1;
                }

                ViewState["rowCount"] = rowCount;
                hrowcount.Value = rowCount.ToString();

            }


            BoundField bfield1 = new BoundField();
            // bfield1.HeaderText = "";
            bfield1.DataField = "xdate1";
            bfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfield1.ItemStyle.Width = 50;
            bfield1.HeaderStyle.Width = 50;
            //bfield.Visible = false;
            GridView1.Columns.Add(bfield1);

            BoundField bfield2 = new BoundField();
            // bfield2.HeaderText = "";
            bfield2.DataField = "xsection1";
            bfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfield2.ItemStyle.Width = 50;
            bfield1.HeaderStyle.Width = 50;
            //bfield.Visible = false;
            GridView1.Columns.Add(bfield2);

            //BoundField bfield3 = new BoundField();
            //// bfield3.HeaderText = "";
            //bfield3.DataField = "xcellno";
            //bfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //bfield3.ItemStyle.Width = 50;
            ////bfield.Visible = false;
            //GridView1.Columns.Add(bfield3);
            if (ViewState["xrow"] != null)
            {

                using (SqlConnection conn11 = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {

                        int xrow1 = Convert.ToInt32(ViewState["xrow"]);


                        string query1 =
                            "SELECT xsubject,xpaper,coalesce(xext,'') as xext,xsection,xcperiod,xdate FROM amexamschd WHERE zid=@zid and xrow=@xrow ";
                        SqlDataAdapter da1 = new SqlDataAdapter(query1, conn11);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
                        da1.Fill(dts1, "tempTable");
                        DataTable tempTable1 = new DataTable();
                        tempTable1 = dts1.Tables["tempTable"];

                        if (tempTable1.Rows.Count > 0)
                        {
                            ViewState["amexamschd"] = tempTable1;
                        }
                        else
                        {
                            ViewState["amexamschd"] = null;
                        }


                        da1.Dispose();
                    }
                }
            }


            GridView1.DataSource = dt;
            GridView1.DataBind();

            //bfield1.Visible = false;
            //bfield2.Visible = false;
            //bfield3.Visible = false;

            bfield1.ItemStyle.CssClass = "hiddencol";
            bfield1.HeaderStyle.CssClass = "hiddencol";
            bfield2.ItemStyle.CssClass = "hiddencol";
            bfield2.HeaderStyle.CssClass = "hiddencol";



            da.Dispose();
            dts.Dispose();
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            try
            {
                for (int rowIndex = 0; rowIndex < GridView1.Rows.Count; rowIndex = rowIndex + dtsec.Rows.Count)
                {

                    GridViewRow gvRow = GridView1.Rows[rowIndex];

                    //GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];

                    //for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
                    //for (int cellCount = 0; cellCount == 0; cellCount++)
                    int cellCount = 0;
                    {
                        gvRow.Cells[cellCount].RowSpan = dtsec.Rows.Count;
                        // gvRow.Style.Add("border-bottom-color", "#000000");
                        // gvRow.BorderColor = Color.Black;
                        //if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
                        //{

                        //    if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        //    {

                        //        gvRow.Cells[cellCount].RowSpan = 2;

                        //    }

                        //    else
                        //    {

                        //        gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;

                        //    }
                        for (int i = 1; i < dtsec.Rows.Count; i++)
                        {
                            GridView1.Rows[rowIndex + i].Cells[cellCount].Visible = false;
                        }

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
        private int RowCount { get; set; }
        //int tempcounter;
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:
                        {
                            RowCount = 0;
                        }
                        break;
                    case DataControlRowType.DataRow:
                        {
                            RowCount += 1;
                            if (RowCount == dtsec.Rows.Count + 1)
                            {
                                e.Row.CssClass = "BorderRow";
                                RowCount = 1;
                            }
                        }
                        break;
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    for (int i = 2; i < 2 + (int)ViewState["rowCount"]; i++)
                    {

                        HtmlGenericControl btnSchedule = new HtmlGenericControl("input");
                        btnSchedule.ID = "btnSchedule" + i.ToString();
                        btnSchedule.Attributes.Add("type", "button");
                        btnSchedule.Attributes.Add("class", "btnSchedule");
                        btnSchedule.Attributes.Add("value", "N/S");
                        //btnComments.Attributes.Add("runat", "server");
                        btnSchedule.Attributes.Add("style", "padding-top:2px;padding-bottom:2px;white-space: normal;text-align:center;color:black; background-color: #F8C1D9;cursor: pointer; border: none;text-decoration: none;display: block;width:100px;");
                        e.Row.Cells[i].Controls.Add(btnSchedule);

                        //LinkButton lnkbtn = new LinkButton();
                        //lnkbtn.Text = "Add Subject";
                        //lnkbtn.ID = "adddetail" + i.ToString();
                        //lnkbtn.ForeColor = Color.CornflowerBlue;
                        //lnkbtn.Attributes.Add("runat", "server");
                        //lnkbtn.Click += OnLinkClick;
                        //e.Row.Cells[i].Controls.Add(lnkbtn);

                        if (ViewState["xrow"] == null || xdate.Text == "")
                        {
                            //lnkbtn.Enabled = false;
                            btnSchedule.Disabled = true;
                        }
                        else
                        {
                            if (ViewState["xstatus"].ToString() != "New")
                            {
                                //lnkbtn.Enabled = false;
                                btnSchedule.Disabled = true;
                            }
                            else
                            {
                                //lnkbtn.Enabled = true;
                                btnSchedule.Disabled = false;
                            }
                            if (ViewState["amexamschd"] != null)
                            {

                                DateTime xdate2 = Convert.ToDateTime(e.Row.Cells[2 + (int) ViewState["rowCount"]].Text);
                                string xperiod2 = GridView1.HeaderRow.Cells[i].Text.ToString();
                                string xsection2 = e.Row.Cells[3 + (int) ViewState["rowCount"]].Text.ToString();

                                DataRow[] result =
                                    ((DataTable) ViewState["amexamschd"]).Select("xsection='" + xsection2 +
                                                                                 "' and xcperiod='" + xperiod2 +
                                                                                 "' and xdate='" + xdate2 + "'");


                                if (result.Length > 0)
                                {
                                    if ((result[0]["xpaper"].ToString() != "" ||
                                         result[0]["xpaper"].ToString() != String.Empty) &&
                                        (result[0]["xext"].ToString() != "" ||
                                         result[0]["xext"].ToString() != String.Empty))
                                    {
                                        //lnkbtn.Text = result[0]["xsubject"].ToString() + "(" + result[0]["xext"].ToString() + ")" + "-" +
                                        //              result[0]["xpaper"].ToString();

                                        btnSchedule.Attributes.Add("value",
                                            result[0]["xsubject"].ToString() + "(" + result[0]["xext"].ToString() + ")" +
                                            "-" + result[0]["xpaper"].ToString());
                                    }
                                    else if ((result[0]["xpaper"].ToString() != "" ||
                                              result[0]["xpaper"].ToString() != String.Empty) &&
                                             (result[0]["xext"].ToString() == "" ||
                                              result[0]["xext"].ToString() == String.Empty))
                                    {
                                        //lnkbtn.Text = result[0]["xsubject"].ToString() + "-" +
                                        //              result[0]["xpaper"].ToString();

                                        btnSchedule.Attributes.Add("value",
                                            result[0]["xsubject"].ToString() + "-" + result[0]["xpaper"].ToString());
                                    }
                                    else if ((result[0]["xpaper"].ToString() == "" ||
                                              result[0]["xpaper"].ToString() == String.Empty) &&
                                             (result[0]["xext"].ToString() != "" ||
                                              result[0]["xext"].ToString() != String.Empty))
                                    {
                                        //lnkbtn.Text = result[0]["xsubject"].ToString() + "-" +
                                        //              result[0]["xpaper"].ToString();

                                        btnSchedule.Attributes.Add("value",
                                            result[0]["xsubject"].ToString() + "(" + result[0]["xext"].ToString() + ")");
                                    }
                                    else
                                    {
                                        //lnkbtn.Text = result[0]["xsubject"].ToString();

                                        btnSchedule.Attributes.Add("value", result[0]["xsubject"].ToString());
                                    }
                                    //lnkbtn.ForeColor = Color.Black;
                                    //e.Row.Cells[i].BackColor = Color.LightPink;

                                    btnSchedule.Style.Add("background-color", "#BAD980");
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void gvTheGrid_PreRender(object sender, EventArgs e)
        {


            if (GridView1.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                GridView1.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void OnLinkClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                LinkButton lb = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lb.NamingContainer;
                if (row != null)
                {
                    //message.InnerHtml = lb.ID.ToString();
                    int xcellno = int.Parse(lb.ID.ToString().Substring(9));
                    //message.InnerHtml = lb.ID.ToString().Substring(9);
                    lbldate.Text = Convert.ToDateTime(row.Cells[2 + (int)ViewState["rowCount"]].Text).ToString("dddd, MMMM dd, yyyy");
                    lblperiod.Text = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                    lblsection.Text = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                    _xdate.Value = row.Cells[2 + (int)ViewState["rowCount"]].Text.ToString();
                    _xperiod.Value = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                    _xsection.Value = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                            int xrow = Convert.ToInt32(ViewState["xrow"]);
                            DateTime xdate2 = Convert.ToDateTime(row.Cells[2 + (int)ViewState["rowCount"]].Text);
                            string xperiod2 = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                            string xsection2 = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                            string query = "SELECT xsubject,xpaper,xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, " +
                                " (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1,xcteacher,xsteacher FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                            da.Fill(dts, "tempTable");
                            DataTable tempTable = new DataTable();
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {
                                xsubject.Text = tempTable.Rows[0]["xsubject"].ToString();
                                xpaper.Text = tempTable.Rows[0]["xpaper"].ToString();
                                xtopic.Value = tempTable.Rows[0]["xtopic"].ToString();
                                xdetails.Value = tempTable.Rows[0]["xdetails"].ToString();
                                xcteacher.Text = tempTable.Rows[0]["xcteacher1"].ToString();
                                xsteacher.Text = tempTable.Rows[0]["xsteacher1"].ToString();
                                _classteacher.Value = tempTable.Rows[0]["xcteacher"].ToString();
                                _subteacher.Value = tempTable.Rows[0]["xsteacher"].ToString();
                            }
                            else
                            {
                                xsubject.Text = "";
                                xpaper.Text = "";
                                xtopic.Value = "";
                                xdetails.Value = "";
                                xcteacher.Text = "";
                                xsteacher.Text = "";
                                _classteacher.Value = "";
                                _subteacher.Value = "";
                            }


                            da.Dispose();
                        }
                    }

                    this.ModalPopupExtender1.Show();
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
                //System.Threading.Thread.Sleep(1000);
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
                if (xdate.Text == "" || xdate.Text == string.Empty || xdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Month</li>";
                    isValid = false;
                }
                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }


                //Duplicate entry check
                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    string checkuser = "SELECT COUNT(*) FROM amexamschh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test' AND xyear=@xyear AND xmonth=@xmonth";

                    SqlParameter objParameter = null;
                    // string xuser = Login1.UserName;
                    SqlCommand cmd = new SqlCommand(checkuser, conn);
                    objParameter = cmd.Parameters.Add("zid", SqlDbType.Int);
                    objParameter = cmd.Parameters.Add("xsession", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xclass", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xterm", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xgroup", SqlDbType.VarChar);
                    objParameter = cmd.Parameters.Add("xyear", SqlDbType.Int);
                    objParameter = cmd.Parameters.Add("xmonth", SqlDbType.Int);

                    cmd.Parameters["zid"].Value = _zid;
                    cmd.Parameters["xsession"].Value = xsession.Text.ToString().Trim();
                    cmd.Parameters["xclass"].Value = xclass.Text.ToString().Trim();
                    cmd.Parameters["xterm"].Value = xterm.Text.ToString().Trim();
                    cmd.Parameters["xgroup"].Value = xgroup.Text.ToString().Trim();
                    cmd.Parameters["xyear"].Value = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                    cmd.Parameters["xmonth"].Value = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());
                    conn.Open();
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    if (temp >= 1)
                    {
                        message.InnerHtml = "Cann't insert duplicate record.";
                        message.Style.Value = zglobal.warningmsg;
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

                        DateTime ztime = DateTime.Now;
                        DateTime zutime = DateTime.Now;
                        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        xrow = 0;

                        string xsession1 = "";
                        string xterm1 = "";
                        string xclass1 = "";
                        string xgroup1 = "";
                        string xtype = "Class Test";
                        string xstatus = "New";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xsubmitdt = DateTime.Now;
                        int xyear1 = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                        int xmonth1 = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                        string query = "INSERT INTO amexamschh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xtype,xstatus,zemail,xyear,xmonth) " +
                                    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xtype,@xstatus,@zemail,@xyear,@xmonth) ";

                        xrow = zglobal.GetMaximumIdInt("xrow", "amexamschh", " zid=" + _zid);
                        xsession1 = xsession.Text.Trim().ToString();
                        xterm1 = xterm.Text.Trim().ToString();
                        xclass1 = xclass.Text.Trim().ToString();
                        xgroup1 = xgroup.Text.Trim().ToString();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xsession", xsession1);
                        cmd.Parameters.AddWithValue("@xterm", xterm1);
                        cmd.Parameters.AddWithValue("@xclass", xclass1);
                        cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                        cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xyear", xyear1);
                        cmd.Parameters.AddWithValue("@xmonth", xmonth1);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Complete();

                }

                btnSave.Enabled = false;
                btnSave1.Enabled = false;
                message.InnerHtml = "Successfully create schedule.";
                message.Style.Value = zglobal.successmsg;
                ViewState["xrow"] = xrow;
                hxrow.Value = xrow.ToString();
                ViewState["xstatus"] = "New";
                dxstatus.Visible = true;
                btnPrint.Visible = true;
                dxstatus.Text = "Status : New";
                hiddenxstatus.Value = "New";
                //if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                //{
                int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                BindGrid(year, month);
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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = int.Parse(ViewState["xrow"].ToString());
                int xline1 = 0;
                message.InnerHtml = "";

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {

                        using (DataSet dts = new DataSet())
                        {

                            DateTime xdate2 = Convert.ToDateTime(_xdate.Value);
                            string xperiod2 = _xperiod.Value;
                            string xsection2 = _xsection.Value;

                            string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                            da.Fill(dts, "tempTable");
                            DataTable tempTable = new DataTable();
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {

                                xline1 = Convert.ToInt32(tempTable.Rows[0][0].ToString());

                                query1 = "SELECT * FROM amexamschh inner join amexamschd on amexamschh.zid=amexamschd.zid and amexamschh.xrow=amexamschd.xrow WHERE amexamschh.zid=@zid and amexamschh.xrow=@xrow and amexamschd.xline=@xline";

                                dts.Reset();
                                SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
                                da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                                da1.SelectCommand.Parameters.AddWithValue("@xline", xline1);
                                da1.Fill(dts, "tempTable");
                                DataTable tempTable1 = new DataTable();
                                tempTable1 = dts.Tables["tempTable"];

                                if (tempTable1.Rows.Count > 0)
                                {
                                    query1 = "SELECT * FROM amexamh  WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xschdate=@xschdate";


                                    SqlDataAdapter da2 = new SqlDataAdapter(query1, conn);
                                    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                    da2.SelectCommand.Parameters.AddWithValue("@xsession", tempTable1.Rows[0]["xsession"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xclass", tempTable1.Rows[0]["xclass"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xterm", tempTable1.Rows[0]["xterm"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xgroup", tempTable1.Rows[0]["xgroup"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xsection", tempTable1.Rows[0]["xsection"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xsubject", tempTable1.Rows[0]["xsubject"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xpaper", tempTable1.Rows[0]["xpaper"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xschdate", tempTable1.Rows[0]["xdate"].ToString());

                                    dts.Reset();
                                    da2.Fill(dts, "tempTable");
                                    DataTable tempTable2 = new DataTable();
                                    tempTable2 = dts.Tables["tempTable"];

                                    if (tempTable2.Rows.Count > 0)
                                    {
                                        message.InnerHtml = "Test already taken. Cann't edit record.";
                                        message.Style.Value = zglobal.warningmsg;
                                        return;
                                    }
                                }
                            }


                            da.Dispose();
                        }


                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        //if (xline1 != 0)
                        //{
                        //    string query2 = "DELETE FROM amexamschd WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                        //    cmd.Parameters.Clear();
                        //    cmd.CommandText = query2;
                        //    cmd.Parameters.AddWithValue("@zid", _zid);
                        //    cmd.Parameters.AddWithValue("@xrow", xrow);
                        //    cmd.Parameters.AddWithValue("@xline", xline1);
                        //    cmd.ExecuteNonQuery();
                        //}


                        DateTime ztime = DateTime.Now;
                        DateTime zutime = DateTime.Now;
                        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        int xline = zglobal.GetMaximumIdInt("xline", "amexamschd", " zid=" + _zid + " and xrow=" + xrow, "line");
                        string xsubject1 = "";
                        string xpaper1 = "";
                        DateTime xdate1 = DateTime.Now;
                        string xsection1 = "";
                        string xcperiod1 = "";
                        string xcteacher1 = "";
                        string xsteacher1 = "";
                        string xtopic1 = "";
                        string xdetails1 = "";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

                        string query;
                        if (xline1 != 0)
                        {
                            query = "UPDATE amexamschd SET zutime=@zutime, xsubject=@xsubject, xpaper=@xpaper, xtopic=@xtopic, xdetails=@xdetails, xcteacher=@xcteacher, xsteacher=@xsteacher, xemail=@xemail WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                            xline = xline1;
                        }
                        else
                        {
                            query = "INSERT INTO amexamschd (ztime,zid,xrow,xline,xsubject,xpaper,xdate,xsection,xcperiod,xcteacher,xsteacher,xtopic,xdetails,zemail) " +
                                   "VALUES(@ztime,@zid,@xrow,@xline,@xsubject,@xpaper,@xdate,@xsection,@xcperiod,@xcteacher,@xsteacher,@xtopic,@xdetails,@zemail) ";
                        }


                        xsubject1 = xsubject.Text.ToString().Trim();
                        xpaper1 = xpaper.Text.Trim().ToString();
                        xdate1 = Convert.ToDateTime(_xdate.Value.ToString());
                        xsection1 = _xsection.Value.ToString();
                        xcperiod1 = _xperiod.Value.ToString();
                        xcteacher1 = _classteacher.Value.ToString();
                        xsteacher1 = _subteacher.Value.ToString();
                        xtopic1 = xtopic.Value.Trim().ToString();
                        xdetails1 = xdetails.Value.Trim().ToString();

                        cmd.CommandText = query;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xline", xline);
                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                        cmd.Parameters.AddWithValue("@xdate", xdate1);
                        cmd.Parameters.AddWithValue("@xsection", xsection1);
                        cmd.Parameters.AddWithValue("@xcperiod", xcperiod1);
                        cmd.Parameters.AddWithValue("@xcteacher", xcteacher1);
                        cmd.Parameters.AddWithValue("@xsteacher", xsteacher1);
                        cmd.Parameters.AddWithValue("@xtopic", xtopic1);
                        cmd.Parameters.AddWithValue("@xdetails", xdetails1);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xemail", xemail);
                        if (xsubject.Text != "")
                        {
                            cmd.ExecuteNonQuery();
                        }


                    }

                    tran.Complete();

                }



                if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                {
                    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                    BindGrid(year, month);
                }
                else
                {
                    BindGrid(1999, 1);
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
                int xrow = int.Parse(ViewState["xrow"].ToString());
                int xline1 = 0;
                message.InnerHtml = "";

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {

                        using (DataSet dts = new DataSet())
                        {

                            DateTime xdate2 = Convert.ToDateTime(_xdate.Value);
                            string xperiod2 = _xperiod.Value;
                            string xsection2 = _xsection.Value;

                            string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                            da.Fill(dts, "tempTable");
                            DataTable tempTable = new DataTable();
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {
                                xline1 = Convert.ToInt32(tempTable.Rows[0][0].ToString());

                                query1 = "SELECT * FROM amexamschh inner join amexamschd on amexamschh.zid=amexamschd.zid and amexamschh.xrow=amexamschd.xrow WHERE amexamschh.zid=@zid and amexamschh.xrow=@xrow and amexamschd.xline=@xline";

                                dts.Reset();
                                SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
                                da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                                da1.SelectCommand.Parameters.AddWithValue("@xline", xline1);
                                da1.Fill(dts, "tempTable");
                                DataTable tempTable1 = new DataTable();
                                tempTable1 = dts.Tables["tempTable"];

                                if (tempTable1.Rows.Count > 0)
                                {
                                    query1 = "SELECT * FROM amexamh  WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xschdate=@xschdate";


                                    SqlDataAdapter da2 = new SqlDataAdapter(query1, conn);
                                    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                    da2.SelectCommand.Parameters.AddWithValue("@xsession", tempTable1.Rows[0]["xsession"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xclass", tempTable1.Rows[0]["xclass"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xterm", tempTable1.Rows[0]["xterm"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xgroup", tempTable1.Rows[0]["xgroup"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xsection", tempTable1.Rows[0]["xsection"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xsubject", tempTable1.Rows[0]["xsubject"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xpaper", tempTable1.Rows[0]["xpaper"].ToString());
                                    da2.SelectCommand.Parameters.AddWithValue("@xschdate", tempTable1.Rows[0]["xdate"].ToString());

                                    dts.Reset();
                                    da2.Fill(dts, "tempTable");
                                    DataTable tempTable2 = new DataTable();
                                    tempTable2 = dts.Tables["tempTable"];

                                    if (tempTable2.Rows.Count > 0)
                                    {
                                        message.InnerHtml = "Test already taken. Cann't delete record.";
                                        message.Style.Value = zglobal.warningmsg;
                                        return;
                                    }
                                }

                            }


                            da.Dispose();
                        }


                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        int xline;



                        string query;
                        if (xline1 != 0)
                        {
                            query = "DELETE FROM amexamschd  WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                            xline = xline1;


                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", xrow);
                            cmd.Parameters.AddWithValue("@xline", xline);
                            cmd.ExecuteNonQuery();

                        }
                    }

                    tran.Complete();

                }



                if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                {
                    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                    BindGrid(year, month);
                }
                else
                {
                    BindGrid(1999, 1);
                }
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
                //System.Threading.Thread.Sleep(1000);
                message.InnerHtml = "";


                if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                {
                    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                    BindGrid(year, month);
                }
                else
                {
                    BindGrid(1999, 1);
                    //GridView1.DataSource = null;
                    //GridView1.DataBind();
                }



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

                message.InnerHtml = "";

                hiddenxdate.Value = new DateTime(1999, 1, 1).ToString();

                dxstatus.Visible = false;
                btnPrint.Visible = false;
                hiddenxrow.Value = null;
                ViewState["xrow"] = null;
                hxrow.Value = "";
                btnSave.Enabled = true;
                btnSave1.Enabled = true;

                BindGrid(1999, 1);
                

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void combo_OnTextChanged_class(object sender, EventArgs e)
        {
            try
            {
                combo_OnTextChanged(sender, e);
                zglobal.fnGetComboDataCDSubject(xclass.Text.ToString().Trim(), xsubject);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void combo_OnTextChanged_subject(object sender, EventArgs e)
        {
            try
            {
                combo_OnTextChanged(sender, e);
                zglobal.fnGetComboDataCDPaper(xclass.Text.ToString().Trim(), xsubject.Text.ToString().Trim(), xpaper);
                zglobal.fnGetComboDataCDExtension(xclass.Text.ToString().Trim(), xsubject.Text.ToString().Trim(), xext);

                
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xsession1 = xsession.Text.Trim().ToString();
                string xterm1 = xterm.Text.Trim().ToString();
                string xclass1 = xclass.Text.Trim().ToString();
                string xgroup1 = xgroup.Text.Trim().ToString();
                int xyear = 1999;
                int xmonth = 1;
                if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                {
                    xyear = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                    xmonth = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());
                }

                string xrow = zglobal.fnGetValue("xrow", "amexamschh",
                    "zid=" + _zid + " and xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xclass='" + xclass1 +
                    "' and xgroup='" + xgroup1 + "' and xyear=" + xyear + " and xmonth=" + xmonth);
                string xstatus = zglobal.fnGetValue("xstatus", "amexamschh",
                    "zid=" + _zid + " and xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xclass='" + xclass1 +
                    "' and xgroup='" + xgroup1 + "'and xyear=" + xyear + " and xmonth=" + xmonth);
                if (xrow == "")
                {
                    ViewState["xrow"] = null;
                    hxrow.Value = "";
                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    dxstatus.Visible = false;
                    btnPrint.Visible = false;
                    hiddenxrow.Value = null;
                    message.InnerHtml = "No data found.";
                    message.Style.Value = zglobal.am_warningmsg;

                }
                else
                {
                    ViewState["xrow"] = xrow;
                    hxrow.Value = xrow;
                    btnSave.Enabled = false;
                    btnSave1.Enabled = false;
                    dxstatus.Visible = true;
                    btnPrint.Visible = true;
                    hiddenxrow.Value = xrow;
                }

                if (xstatus == "")
                {
                    ViewState["xstatus"] = "New";
                    dxstatus.Text = "Status : New";
                    hiddenxstatus.Value = "New";
                }
                else
                {
                    ViewState["xstatus"] = xstatus;
                    dxstatus.Text = "Status : " + xstatus;
                    if (xstatus == "New")
                    {
                        dxstatus.Style.Value = zglobal.am_new;
                    }
                    else
                    {
                        dxstatus.Style.Value = zglobal.am_submited;
                    }

                    hiddenxstatus.Value = xstatus;
                }


                if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                {
                    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                    BindGrid(year, month);
                    hiddenxdate.Value = xdate.SelectedValue.ToString();
                }
                else
                {
                    BindGrid(1999, 1);
                    //GridView1.DataSource = null;
                    //GridView1.DataBind();
                    hiddenxdate.Value = new DateTime(1999, 1, 1).ToString();
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

                message.InnerHtml = "";


                fnPageLoad();

                BindGrid(1999, 1);
                hiddenxdate.Value = new DateTime(1999, 1, 1).ToString();

               


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
                message.InnerText = "";
                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {
                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xsubmitdt = DateTime.Now;
                                xstatus = "Submited";




                                string query =
                                    "UPDATE amexamschh SET xstatus=@xstatus,xsubmitedby=@xsubmitedby,xsubmitdt=@xsubmitdt " +
                                    "WHERE zid=@zid AND xrow=@xrow ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", ViewState["xrow"].ToString());
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.Parameters.AddWithValue("@xsubmitedby", xsubmitedby);
                                cmd.Parameters.AddWithValue("@xsubmitdt", xsubmitdt);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.subsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        ViewState["xstatus"] = "Submited";
                        dxstatus.Visible = true;
                        btnPrint.Visible = true;
                        dxstatus.Text = "Status : Submited";
                        hiddenxstatus.Value = "Submited";
                        if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                        {
                            int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                            int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                            BindGrid(year, month);
                        }
                        else
                        {
                            BindGrid(1999, 1);
                        }
                    }
                }
                else
                {
                    message.InnerHtml = "Cann't submit information.";
                    message.Style.Value = zglobal.warningmsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string fnFetchValue(string xrow1, string xdate1, string xperiod1, string xsection1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        
                        int xrow = Convert.ToInt32(xrow1);
                        DateTime xdate2 = Convert.ToDateTime(xdate1);
                        string xperiod2 = xperiod1;
                        string xsection2 = xsection1;

                        string query = "SELECT xsubject,xpaper,xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, " +
                            " (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1,xcteacher,xsteacher,coalesce(xext,'') as xext FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                        da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                        da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                        da.Fill(dts, "tempTable");
                        DataTable tempTable = new DataTable();
                        tempTable = dts.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            return "success" + "|" + tempTable.Rows[0]["xsubject"].ToString() + "|" + tempTable.Rows[0]["xpaper"].ToString()
                                + "|" + tempTable.Rows[0]["xtopic"].ToString() + "|" + tempTable.Rows[0]["xdetails"].ToString()
                                + "|" + tempTable.Rows[0]["xcteacher1"].ToString() + "|" + tempTable.Rows[0]["xsteacher1"].ToString()
                                + "|" + tempTable.Rows[0]["xcteacher"].ToString() + "|" + tempTable.Rows[0]["xsteacher"].ToString()
                                + "|" + tempTable.Rows[0]["xext"].ToString();
                        }
                        else
                        {
                            return "nodata";
                        }


                        
                    }
                }



            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string fnInsertDetails(string xrow1, string xsection1, string xcperiod1, string xdate1, string xsubject1, string xext1, string xpaper1, string xtopic1, string xdetails1, string xcteacher1, string xsteacher1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xline1 = 0;

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        conn.Open();

                        if (xsubject1 == "")
                        {
                            return "Please enter subject.";
                        }
                        else if (xtopic1 == "")
                        {
                            return "Please enter topic.";
                        }
                        else if (xcteacher1 == "")
                        {
                            return "Please select class teacher.";
                        }
                        else if (xsteacher1 == "")
                        {
                            return "Please select subject teacher.";
                        }

                        string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                        SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(xrow1));
                        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                        da.SelectCommand.Parameters.AddWithValue("@xcperiod", xcperiod1);
                        da.SelectCommand.Parameters.AddWithValue("@xdate", Convert.ToDateTime(xdate1));
                        da.Fill(dts, "tempTable");
                        DataTable tempTable = new DataTable();
                        tempTable = dts.Tables["tempTable"];
                        if (tempTable.Rows.Count > 0)
                        {

                            xline1 = Convert.ToInt32(tempTable.Rows[0][0].ToString());

                            query1 = "SELECT * FROM amexamschh inner join amexamschd on amexamschh.zid=amexamschd.zid and amexamschh.xrow=amexamschd.xrow WHERE amexamschh.zid=@zid and amexamschh.xrow=@xrow and amexamschd.xline=@xline";

                            dts.Reset();
                            SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(xrow1));
                            da1.SelectCommand.Parameters.AddWithValue("@xline", xline1);
                            da1.Fill(dts, "tempTable");
                            DataTable tempTable1 = new DataTable();
                            tempTable1 = dts.Tables["tempTable"];

                            if (tempTable1.Rows.Count > 0)
                            {
                                query1 = "SELECT * FROM amexamh  WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xschdate=@xschdate";


                                SqlDataAdapter da2 = new SqlDataAdapter(query1, conn);
                                da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da2.SelectCommand.Parameters.AddWithValue("@xsession", tempTable1.Rows[0]["xsession"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xclass", tempTable1.Rows[0]["xclass"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xterm", tempTable1.Rows[0]["xterm"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xgroup", tempTable1.Rows[0]["xgroup"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xsection", tempTable1.Rows[0]["xsection"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xsubject", tempTable1.Rows[0]["xsubject"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xpaper", tempTable1.Rows[0]["xpaper"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xschdate", tempTable1.Rows[0]["xdate"].ToString());

                                dts.Reset();
                                da2.Fill(dts, "tempTable");
                                DataTable tempTable2 = new DataTable();
                                tempTable2 = dts.Tables["tempTable"];

                                if (tempTable2.Rows.Count > 0)
                                {
                                    return "Test already taken. Cann't edit record.";
                                }
                            }
                        }

                        SqlTransaction tran = conn.BeginTransaction();
                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.Transaction = tran;
                            //cmd.CommandTimeout = 0;

                            DateTime ztime = DateTime.Now;
                            DateTime zutime = DateTime.Now;
                            //_zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                            int xline = zglobal.GetMaximumIdInt("xline", "amexamschd", " zid=" + _zid + " and xrow=" + Convert.ToInt32(xrow1), "line");
                            string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

                            string query;
                            if (xline1 != 0)
                            {
                                query = "UPDATE amexamschd SET zutime=@zutime, xsubject=@xsubject, xext=@xext, xpaper=@xpaper, xtopic=@xtopic, xdetails=@xdetails, xcteacher=@xcteacher, xsteacher=@xsteacher, xemail=@xemail WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                                xline = xline1;
                            }
                            else
                            {
                                query = "INSERT INTO amexamschd (ztime,zid,xrow,xline,xsubject,xext,xpaper,xdate,xsection,xcperiod,xcteacher,xsteacher,xtopic,xdetails,zemail) " +
                                       "VALUES(@ztime,@zid,@xrow,@xline,@xsubject,@xext,@xpaper,@xdate,@xsection,@xcperiod,@xcteacher,@xsteacher,@xtopic,@xdetails,@zemail) ";
                            }


                            

                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@zutime", zutime);
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(xrow1));
                            cmd.Parameters.AddWithValue("@xline", xline);
                            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                            cmd.Parameters.AddWithValue("@xext", xext1);
                            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                            cmd.Parameters.AddWithValue("@xdate", Convert.ToDateTime(xdate1));
                            cmd.Parameters.AddWithValue("@xsection", xsection1);
                            cmd.Parameters.AddWithValue("@xcperiod", xcperiod1);
                            cmd.Parameters.AddWithValue("@xcteacher", xcteacher1);
                            cmd.Parameters.AddWithValue("@xsteacher", xsteacher1);
                            cmd.Parameters.AddWithValue("@xtopic", xtopic1);
                            cmd.Parameters.AddWithValue("@xdetails", xdetails1);
                            cmd.Parameters.AddWithValue("@zemail", zemail);
                            cmd.Parameters.AddWithValue("@xemail", xemail);
                            cmd.ExecuteNonQuery();

                            tran.Commit();
                        }
                        catch (Exception exp)
                        {
                            tran.Rollback();
                            return exp.Message;
                        }
                    }
                }


                return "success";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string fnDeleteDetails(string xrow1, string xsection1, string xcperiod1, string xdate1, string xsubject1, string xext1, string xpaper1, string xtopic1, string xdetails1, string xcteacher1, string xsteacher1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xline1 = 0;

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        conn.Open();

                        string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                        SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(xrow1));
                        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                        da.SelectCommand.Parameters.AddWithValue("@xcperiod", xcperiod1);
                        da.SelectCommand.Parameters.AddWithValue("@xdate", Convert.ToDateTime(xdate1));
                        da.Fill(dts, "tempTable");
                        DataTable tempTable = new DataTable();
                        tempTable = dts.Tables["tempTable"];
                        if (tempTable.Rows.Count > 0)
                        {

                            xline1 = Convert.ToInt32(tempTable.Rows[0][0].ToString());

                            query1 = "SELECT * FROM amexamschh inner join amexamschd on amexamschh.zid=amexamschd.zid and amexamschh.xrow=amexamschd.xrow WHERE amexamschh.zid=@zid and amexamschh.xrow=@xrow and amexamschd.xline=@xline";

                            dts.Reset();
                            SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(xrow1));
                            da1.SelectCommand.Parameters.AddWithValue("@xline", xline1);
                            da1.Fill(dts, "tempTable");
                            DataTable tempTable1 = new DataTable();
                            tempTable1 = dts.Tables["tempTable"];

                            if (tempTable1.Rows.Count > 0)
                            {
                                query1 = "SELECT * FROM amexamh  WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xschdate=@xschdate";


                                SqlDataAdapter da2 = new SqlDataAdapter(query1, conn);
                                da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da2.SelectCommand.Parameters.AddWithValue("@xsession", tempTable1.Rows[0]["xsession"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xclass", tempTable1.Rows[0]["xclass"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xterm", tempTable1.Rows[0]["xterm"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xgroup", tempTable1.Rows[0]["xgroup"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xsection", tempTable1.Rows[0]["xsection"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xsubject", tempTable1.Rows[0]["xsubject"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xpaper", tempTable1.Rows[0]["xpaper"].ToString());
                                da2.SelectCommand.Parameters.AddWithValue("@xschdate", tempTable1.Rows[0]["xdate"].ToString());

                                dts.Reset();
                                da2.Fill(dts, "tempTable");
                                DataTable tempTable2 = new DataTable();
                                tempTable2 = dts.Tables["tempTable"];

                                if (tempTable2.Rows.Count > 0)
                                {
                                    return "Test already taken. Cann't delete record.";
                                }
                            }
                        }

                        SqlTransaction tran = conn.BeginTransaction();
                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.Transaction = tran;

                            int xline;

                            string query;
                            if (xline1 != 0)
                            {
                                query = "DELETE FROM amexamschd  WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                                xline = xline1;


                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(xrow1));
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.ExecuteNonQuery();

                            }

                            tran.Commit();
                        }
                        catch (Exception exp)
                        {
                            tran.Rollback();
                            return exp.Message;
                        }
                    }
                }


                return "success";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

    }
}