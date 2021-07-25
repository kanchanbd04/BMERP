using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Transactions;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class hrgrowthh_rpt : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string rowid;
        object row;
        private string q_val;
        private string filter;
        

        public void fnFillDataGrid(object sender,EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
               
                if (xfdate.Text == "" || xfdate.Text == string.Empty || xfdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>From Date</li>";
                    isValid = false;
                }

                if (xtdate.Text == "" || xtdate.Text == string.Empty || xtdate.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>To Date</li>";
                    isValid = false;
                }

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                DateTime xfdate1 = DateTime.ParseExact(xfdate.Text.Trim().ToString(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                DateTime xtdate1 = DateTime.ParseExact(xtdate.Text.Trim().ToString(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        con.Open();

                        string query = query =
                             "SELECT xrow,xsession,xdate,coalesce((select xusername from ztuser where xuser=hrgrowthh.zemail),'bm') as xname,xclass,xsection " +
                             "FROM hrgrowthh WHERE zid=@zid AND xtype='Class Teacher' AND xstatus='Submited' and xdate between @xfdate and @xtdate order by xdate";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xfdate", xfdate1);
                        da1.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate1);

                        DataTable tempTable = new DataTable();
                        da1.Fill(dts1, "tempTable");
                        tempTable = dts1.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            ctvw.DataSource = tempTable;
                            ctvw.DataBind();
                        }
                        else
                        {
                            ctvw.DataSource = null;
                            ctvw.DataBind();
                        }
                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        con.Open();

                        string query = query =
                             "SELECT xrow,xsession,xdate,coalesce((select xusername from ztuser where xuser=hrgrowthh.zemail),'bm') as xname,xclass " +
                             "FROM hrgrowthh WHERE zid=@zid AND xtype='Coordinator' AND xstatus='Submited' and xdate between @xfdate and @xtdate order by xdate";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xfdate", xfdate1);
                        da1.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate1);

                        DataTable tempTable = new DataTable();
                        da1.Fill(dts1, "tempTable");
                        tempTable = dts1.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            coordinatorvw.DataSource = tempTable;
                            coordinatorvw.DataBind();
                        }
                        else
                        {
                            coordinatorvw.DataSource = null;
                            coordinatorvw.DataBind();
                        }
                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        con.Open();

                        string query = query =
                             "SELECT xrow,xsession,xdate,coalesce((select xusername from ztuser where xuser=hrgrowthh.zemail),'bm') as xname,xsubject " +
                             "FROM hrgrowthh WHERE zid=@zid AND xtype='HOD' AND xstatus='Submited' and xdate between @xfdate and @xtdate order by xdate";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xfdate", xfdate1);
                        da1.SelectCommand.Parameters.AddWithValue("@xtdate", xtdate1);

                        DataTable tempTable = new DataTable();
                        da1.Fill(dts1, "tempTable");
                        tempTable = dts1.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            hodgv.DataSource = tempTable;
                            hodgv.DataBind();
                        }
                        else
                        {
                            hodgv.DataSource = null;
                            hodgv.DataBind();
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

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable dtsec;
        //private int check = 0;
        List<string> listsec = new List<string>();
        List<string> listperiod = new List<string>();
        List<int> listmaxnum = new List<int>();
        private void BindGrid(int year1, int month1, int day1)
        {
            ////if (ViewState["xrow"] == null)
            ////{
            ////    message.InnerHtml = "No data found.";
            ////    message.Style.Value = zglobal.am_warningmsg;
            ////    return;
            ////}

            ////if (ViewState["xrow"] == null)
            ////{
            ////    xdate.Enabled = false;
            ////}
            ////else
            ////{
            ////    xdate.Enabled = true;
            ////}

            ////if (year1 == 1999 && month1 == 1)
            ////{
            ////    ViewState["check"] = "1";
            ////}
            ////else
            ////{
            ////    ViewState["check"] = "0";
            ////}

            //GridView1.Columns.Clear();



            //dt = new DataTable();
            //dt.Columns.Add("xclass");
            ////dt.Columns.Add("xsection");
            ////dt.Columns.Add("xdate1");
            ////dt.Columns.Add("xsection1");



            //int year = year1;
            //int month = month1;
            //int day = day1;

            //DateTime date = new DateTime(year, month, day);
            //// message.InnerHtml = date.ToString().Trim();
            ////return;
            ////string sdt = date.ToString("ddd") + "<br/>" + date.ToString("dd/MM");

            ////SqlConnection conn1;
            ////conn1 = new SqlConnection(zglobal.constring);
            ////DataSet dts = new DataSet();

            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            ////string str = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Section' AND zactive=1 ORDER BY xcodealt";

            ////SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            ////da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////da.Fill(dts, "tempztcode");
            ////dtsec = new DataTable();
            ////dtsec = dts.Tables[0];

            //bfield = new BoundField();
            //bfield.HeaderText = "Class";
            //bfield.DataField = "xclass";
            //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //bfield.ItemStyle.Width = 30;
            //bfield.HtmlEncode = false;
            //GridView1.Columns.Add(bfield);


            //listmaxnum.Clear();

            ////do
            ////{
            ////    int value = 1;
            ////    using (SqlConnection conn = new SqlConnection(zglobal.constring))
            ////    {
            ////        using (DataSet dts = new DataSet())
            ////        {
            ////            string query = "select MAX(mycount) from  " +
            ////                           "(select xsection,count(xsection) as mycount from amexamschd " +
            ////                           "where zid=@zid and  xrow=@xrow and xdate=@xdate group by xsection) as tbl";
            ////            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            ////            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////            da.SelectCommand.Parameters.AddWithValue("@xrow", int.Parse(ViewState["xrow"].ToString()));
            ////           da.SelectCommand.Parameters.AddWithValue("@xdate", Convert.ToDateTime(date.ToString().Trim()));
            ////            da.Fill(dts, "tempTable");
            ////            DataTable tempTable = new DataTable();
            ////            tempTable = dts.Tables["tempTable"];

            ////            if (tempTable.Rows.Count > 0)
            ////            {
            ////                if (tempTable.Rows[0][0].Equals(DBNull.Value) == false)
            ////                {
            ////                    value = Convert.ToInt32(tempTable.Rows[0][0].ToString());
            ////                }
            ////            }


            ////            da.Dispose();
            ////        }
            ////    }

            ////    //listmaxnum.Add(value);
            ////    for (int i = 0; i < value; i++)
            ////    {
            ////        dt.Rows.Add(sdt,date);
            ////        listmaxnum.Add(value);
            ////    }

            ////    date = date.AddDays(1);
            ////    sdt = date.ToString("ddd") + "<br/>" + date.ToString("dd/MM");
            ////} while (date.Month == month);

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    string query;

            //    if (xclass.Text == "All")
            //    {
            //        query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Class' AND zactive=1 ORDER BY xcodealt";
            //    }
            //    else
            //    {
            //        query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Class' AND xcode=@xcode AND zactive=1 ORDER BY xcodealt";
            //    }

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@zid", _zid);
            //    cmd.Parameters.AddWithValue("@xcode", xclass.Text.Trim().ToString());
            //    cmd.CommandType = CommandType.Text;
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        int value = 1;
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            using (DataSet dts = new DataSet())
            //            {
            //                query = "select MAX(mycount) from " +
            //                        " (select xsection,COUNT(xsection) as mycount " +
            //                        " from amexamschh inner join amexamschd on amexamschh.zid=amexamschd.zid and amexamschh.xrow=amexamschd.xrow " +
            //                        " where amexamschh.zid=@zid  and xdate=@xdate and xclass=@xclass and xsession=@xsession and xterm=@xterm" +
            //                        " group by xsection) as tbl";
            //                SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                da.SelectCommand.Parameters.AddWithValue("@xclass", rdr["xcode"].ToString());
            //                da.SelectCommand.Parameters.AddWithValue("@xdate", Convert.ToDateTime(date.ToString().Trim()));
            //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
            //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
            //                //da.SelectCommand.Parameters.AddWithValue("@xyear", year);
            //                //da.SelectCommand.Parameters.AddWithValue("@xmonth", month);
            //                da.Fill(dts, "tempTable");
            //                DataTable tempTable = new DataTable();
            //                tempTable = dts.Tables["tempTable"];

            //                if (tempTable.Rows.Count > 0)
            //                {
            //                    if (tempTable.Rows[0][0].Equals(DBNull.Value) == false)
            //                    {
            //                        value = Convert.ToInt32(tempTable.Rows[0][0].ToString());
            //                    }
            //                }


            //                da.Dispose();
            //            }
            //        }

            //        //listmaxnum.Add(value);
            //        for (int i = 0; i < value; i++)
            //        {
            //            dt.Rows.Add(rdr["xcode"].ToString());
            //            listmaxnum.Add(value);
            //        }


            //    }



            //}

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Section' AND zactive=1 ORDER BY xcodealt";

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@zid", _zid);
            //    cmd.CommandType = CommandType.Text;
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    int rowCount = 0;
            //    listsec.Clear();
            //    while (rdr.Read())
            //    {
            //        tfield = new TemplateField();
            //        tfield.HeaderText = "Subj. & Teacher";
            //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        tfield.ItemStyle.Width = 120;
            //        GridView1.Columns.Add(tfield);

            //        tfield = new TemplateField();
            //        tfield.HeaderText = "Pr.";
            //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        tfield.ItemStyle.Width = 20;
            //        GridView1.Columns.Add(tfield);

            //        rowCount = rowCount + 2;
            //        listsec.Add(rdr["xcode"].ToString());
            //    }

            //    ViewState["rowCount"] = rowCount;

            //}



            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Period' AND zactive=1 ORDER BY xcodealt";

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@zid", _zid);
            //    cmd.CommandType = CommandType.Text;
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    listperiod.Clear();
            //    while (rdr.Read())
            //    {
            //        listperiod.Add(rdr["xcode"].ToString());
            //    }

            //}
            ////dt.Rows.Add("Title1", "3", "3/27/2015");
            ////dt.Rows.Add("Title2", "5", "3/26/2015");
            ////dt.Rows.Add("Title3", "2", "3/27/2015");
            ////dt.Rows.Add("Title4", "8", "3/27/2015");
            ////dt.Rows.Add("Title5", "9", "3/28/2015");

            ////bfield = new BoundField();
            ////bfield.HeaderText = "Days";
            ////bfield.DataField = "xdate";
            ////bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            ////bfield.ItemStyle.Width = 30;
            ////bfield.HtmlEncode = false;
            ////GridView1.Columns.Add(bfield);

            ////bfield = new BoundField();
            ////bfield.HeaderText = "Subject & Teacher";
            ////bfield.DataField = "xsection";
            ////bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            ////bfield.ItemStyle.Width = 10;
            ////GridView1.Columns.Add(bfield);




            ////using (SqlConnection con = new SqlConnection(zglobal.constring))
            ////{
            ////    string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Section' AND zactive=1 ORDER BY xcodealt";

            ////    SqlCommand cmd = new SqlCommand(query, con);
            ////    cmd.Parameters.AddWithValue("@zid", _zid);
            ////    cmd.CommandType = CommandType.Text;
            ////    con.Open();
            ////    SqlDataReader rdr = cmd.ExecuteReader();
            ////    int rowCount = 0;
            ////    while (rdr.Read())
            ////    {
            ////        tfield = new TemplateField();
            ////        tfield.HeaderText = rdr["xcode"].ToString();
            ////        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            ////        tfield.ItemStyle.Width = 120;
            ////        GridView1.Columns.Add(tfield);
            ////        rowCount = rowCount + 1;
            ////    }

            ////    ViewState["rowCount"] = rowCount;

            ////}


            //// BoundField bfield1 = new BoundField();
            //// bfield1.HeaderText = "";
            ////bfield1.DataField = "xdate1";
            ////bfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            ////bfield1.ItemStyle.Width = 50;
            //////bfield.Visible = false;
            ////GridView1.Columns.Add(bfield1);

            ////BoundField bfield2 = new BoundField();
            ////// bfield2.HeaderText = "";
            ////bfield2.DataField = "xsection1";
            ////bfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            ////bfield2.ItemStyle.Width = 50;
            //////bfield.Visible = false;
            ////GridView1.Columns.Add(bfield2);

            ////BoundField bfield3 = new BoundField();
            ////// bfield3.HeaderText = "";
            ////bfield3.DataField = "xcellno";
            ////bfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            ////bfield3.ItemStyle.Width = 50;
            //////bfield.Visible = false;
            ////GridView1.Columns.Add(bfield3);


            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            ////bfield1.Visible = false;
            ////bfield2.Visible = false;
            ////bfield3.Visible = false;



            ////da.Dispose();
            ////dts.Dispose();
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            //try
            //{
            //    int rowIndex = 0;
            //    //for (int rowIndex = 0; rowIndex < GridView1.Rows.Count; rowIndex = rowIndex + listmaxnum[rowIndex])
            //    while (rowIndex < GridView1.Rows.Count)
            //    {

            //        GridViewRow gvRow = GridView1.Rows[rowIndex];

            //        //GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];

            //        //for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            //        //for (int cellCount = 0; cellCount == 0; cellCount++)
            //        int cellCount = 0;
            //        {
            //            gvRow.Cells[cellCount].RowSpan = listmaxnum[rowIndex];
            //            // gvRow.Style.Add("border-bottom-color", "#000000");
            //            // gvRow.BorderColor = Color.Black;
            //            //if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
            //            //{

            //            //    if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
            //            //    {

            //            //        gvRow.Cells[cellCount].RowSpan = 2;

            //            //    }

            //            //    else
            //            //    {

            //            //        gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;

            //            //    }
            //            for (int i = 1; i < listmaxnum[rowIndex]; i++)
            //            {
            //                GridView1.Rows[rowIndex + i].Cells[cellCount].Visible = false;
            //            }

            //            //}

            //        }

            //        rowIndex = rowIndex + listmaxnum[rowIndex];

            //    }

            //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            //    TableHeaderCell cell = new TableHeaderCell();

            //    cell = new TableHeaderCell();
            //    //cell.RowSpan = 2;
            //    row.Controls.Add(cell);

            //    foreach (string sec in listsec)
            //    {
            //        cell = new TableHeaderCell();
            //        cell.ColumnSpan = 2;
            //        cell.Text = sec;
            //        cell.BorderStyle = BorderStyle.Solid;
            //        cell.BorderWidth = 2;
            //        cell.BorderColor = Color.White;
            //        row.Controls.Add(cell);
            //    }

            //    // row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            //    GridView1.HeaderRow.Parent.Controls.AddAt(0, row);


            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}

        }


        List<string> listperiod_track = new List<string>();
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    //e.Row.BorderColor=Color.Black;
            //    int track = 0;
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        if (ViewState["xclass"] != null)
            //        {
            //            if (e.Row.Cells[0].Text == ViewState["xclass"].ToString())
            //            {
            //                track = 1;
            //            }
            //        }

            //        // message.InnerHtml = message.InnerHtml + track.ToString() + "<br>";

            //        int j = 0;
            //        string[] templist = new string[listperiod_track.Count];
            //        listperiod_track.CopyTo(templist);
            //        // message.InnerHtml = message.InnerHtml + listperiod_track.Count.ToString();
            //        //foreach (string  val in listperiod_track)
            //        //{
            //        //    message.InnerHtml = message.InnerHtml + " " + val;
            //        //}
            //        //message.InnerHtml = message.InnerHtml +  " " + listperiod_track.Count.ToString() + "<br>";
            //        listperiod_track.Clear();
            //        //message.InnerHtml = message.InnerHtml + templist.Count();
            //        //foreach (string val in templist)
            //        //{
            //        //    message.InnerHtml = message.InnerHtml + " " + val;
            //        //}
            //        //message.InnerHtml = message.InnerHtml + " " + templist.Count() + "<br>";

            //        for (int i = 1; i < 1 + (int)ViewState["rowCount"]; i = i + 2)
            //        {

            //            Label lblsub = new Label();
            //            lblsub.Text = "";
            //            lblsub.ID = "subject" + i.ToString();
            //            lblsub.ForeColor = Color.Black;
            //            lblsub.Attributes.Add("runat", "server");
            //            //lnkbtn.Click += OnLinkClick;
            //            e.Row.Cells[i].Controls.Add(lblsub);

            //            Label lblper = new Label();
            //            lblper.Text = "";
            //            lblper.ID = "period" + i.ToString();
            //            lblper.ForeColor = Color.Black;
            //            lblper.Attributes.Add("runat", "server");
            //            //lnkbtn.Click += OnLinkClick;
            //            e.Row.Cells[i + 1].Controls.Add(lblper);
            //            int k = 0;

            //            if (track == 1)
            //            {
            //                if (templist[j] != "")
            //                {
            //                    k = listperiod.IndexOf(templist[j]) + 1;
            //                }
            //                else
            //                {
            //                    k = listperiod.Count;
            //                }
            //                //List<string> _track = new List<string>();

            //                //_track = (List<string>) ViewState["track"];
            //                //if (_track[j] != "")
            //                //{
            //                //    k = listperiod.IndexOf(_track[j]) + 1;
            //                //}
            //                //else
            //                //{
            //                //    k = listperiod.Count;
            //                //}
            //            }

            //            while (k < listperiod.Count)
            //            {
            //                using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //                {
            //                    using (DataSet dts = new DataSet())
            //                    {

            //                        int year = int.Parse(DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Year.ToString());
            //                        int month = int.Parse(DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Month.ToString());
            //                        int day = int.Parse(DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).Day.ToString());
            //                        DateTime date = new DateTime(year, month, day);

            //                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //                        //int xrow = Convert.ToInt32(ViewState["xrow"]);
            //                        string xclass2 = e.Row.Cells[0].Text.ToString();
            //                        string xsection2 = listsec[j];
            //                        string xperiod2 = listperiod[k];
            //                        //message.InnerHtml = message.InnerHtml + xrow.ToString() + " " + xdate.ToString() + " " + xsection2 + "<br/>";
            //                        string query =
            //                             "SELECT xsubject,xpaper,amexamschd.xext,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher, " +
            //                            "(select xdescdet from mscodesam where zid=amexamschd.zid and xtype='Period' and xcode=amexamschd.xcperiod) as xcperiod " +
            //                            "from amexamschh inner join amexamschd on amexamschh.zid=amexamschd.zid and amexamschh.xrow=amexamschd.xrow " +
            //                            " WHERE amexamschh.zid=@zid and xsection=@xsection and xcperiod=@xcperiod and xclass=@xclass and xsession=@xsession and " +
            //                            "xterm=@xterm and xdate=@xdate";

            //                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                        da.SelectCommand.Parameters.AddWithValue("@xdate", date);
            //                        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
            //                        da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
            //                        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass2);
            //                        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
            //                        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
            //                        //da.SelectCommand.Parameters.AddWithValue("@xyear", year);
            //                        //da.SelectCommand.Parameters.AddWithValue("@xmonth", month);
            //                        //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.Trim().ToString());
            //                        da.Fill(dts, "tempTable");
            //                        DataTable tempTable = new DataTable();
            //                        tempTable = dts.Tables["tempTable"];

            //                        if (tempTable.Rows.Count > 0)
            //                        {
            //                            if ((tempTable.Rows[0]["xpaper"].ToString() != "" ||
            //                                tempTable.Rows[0]["xpaper"].ToString() != String.Empty) &&
            //                                (tempTable.Rows[0]["xext"].ToString() != "" ||
            //                                tempTable.Rows[0]["xext"].ToString() != String.Empty))
            //                            {
            //                                lblsub.Text = tempTable.Rows[0]["xsubject"].ToString() + "(" + tempTable.Rows[0]["xext"].ToString() + ")" + "-" +
            //                                              tempTable.Rows[0]["xpaper"].ToString() + "<br/>" +
            //                                              tempTable.Rows[0]["xsteacher"].ToString();

            //                            }
            //                            else if ((tempTable.Rows[0]["xpaper"].ToString() != "" ||
            //                         tempTable.Rows[0]["xpaper"].ToString() != String.Empty) &&
            //                         (tempTable.Rows[0]["xext"].ToString() == "" ||
            //                         tempTable.Rows[0]["xext"].ToString() == String.Empty))
            //                            {
            //                                lblsub.Text = tempTable.Rows[0]["xsubject"].ToString() + "-" +
            //                                              tempTable.Rows[0]["xpaper"].ToString() + "<br/>" +
            //                                              tempTable.Rows[0]["xsteacher"].ToString();

            //                            }
            //                            else if ((tempTable.Rows[0]["xpaper"].ToString() == "" ||
            //                         tempTable.Rows[0]["xpaper"].ToString() == String.Empty) &&
            //                         (tempTable.Rows[0]["xext"].ToString() != "" ||
            //                         tempTable.Rows[0]["xext"].ToString() != String.Empty))
            //                            {
            //                                lblsub.Text = tempTable.Rows[0]["xsubject"].ToString() + "(" + tempTable.Rows[0]["xext"].ToString() + ")" + "<br/>" +
            //                                              tempTable.Rows[0]["xsteacher"].ToString();

            //                            }
            //                            else
            //                            {
            //                                lblsub.Text = tempTable.Rows[0]["xsubject"].ToString() + "<br/>" +
            //                                              tempTable.Rows[0]["xsteacher"].ToString();
            //                            }

            //                            lblper.Text = tempTable.Rows[0]["xcperiod"].ToString();
            //                            break;
            //                        }


            //                        da.Dispose();
            //                    }
            //                }

            //                k = k + 1;
            //            }

            //            if (k < listperiod.Count)
            //            {
            //                listperiod_track.Add(listperiod[k]);
            //            }
            //            else
            //            {
            //                listperiod_track.Add("");
            //            }

            //            j = j + 1;
            //        }

            //        ViewState["xclass"] = e.Row.Cells[0].Text;
            //        //ViewState["track"] = listperiod_track;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //System.Threading.Thread.Sleep(1000);
            //    message.InnerHtml = "";

            //    //using (SqlConnection connRowConnection = new SqlConnection(zglobal.constring))
            //    //{
            //    //    using (DataSet dtsRowDataSet = new DataSet())
            //    //    {
            //    //        string query = "SELECT xrow FROM amexamschh WHERE xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND zid=@zid";

            //    //        // return query;
            //    //        SqlDataAdapter daRowValueAdapter = new SqlDataAdapter(query, connRowConnection);
            //    //        daRowValueAdapter.SelectCommand.Parameters.AddWithValue("@xrow", row);
            //    //        daRowValueAdapter.Fill(dtsRowDataSet, "tempTable");
            //    //        DataTable tempTableRowDataTable = new DataTable();
            //    //        tempTableRowDataTable = dtsRowDataSet.Tables["tempTable"];

            //    //        value = tempTableRowDataTable.Rows[0][0].ToString();

            //    //        daRowValueAdapter.Dispose();
            //    //        dtsRowDataSet.Clear();
            //    //        tempTableRowDataTable.Dispose();
            //    //    }
            //    //}
            //    //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    //string xsession1 = xsession.Text.Trim().ToString();
            //    //string xterm1 = xterm.Text.Trim().ToString();
            //    //string xclass1 = xclass.Text.Trim().ToString();
            //    //string xgroup1 = xgroup.Text.Trim().ToString();

            //    //string xrow = zglobal.fnGetValue("xrow", "amexamschh",
            //    //    "zid=" + _zid + " and xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xclass='" + xclass1 +
            //    //    "' and xgroup='" + xgroup1 + "'");
            //    //if (xrow == "")
            //    //{
            //    //    ViewState["xrow"] = null;
            //    //    hiddenxrow.Value = null;
            //    //}
            //    //else
            //    //{
            //    //    ViewState["xrow"] = xrow;
            //    //    hiddenxrow.Value = xrow;
            //    //}


            //    //xdate.Text = "";
            //    //BindGrid(1999, 1,1);
            //    //GridView1.DataSource = null;
            //    //GridView1.DataBind();
                
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        protected void combo1_OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";


            //    if (ViewState["xrow"] == null)
            //    {
            //        message.InnerHtml = "No data found.";
            //        message.Style.Value = zglobal.am_warningmsg;
            //        return;
            //    }


            //    hiddenxdate.Value = xdate.SelectedValue.ToString();


            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                
                fnFillDataGrid(null,null);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    _gridrow.Text = zglobal._grid_row_value;

                    zglobal.fnGetComboDataCD("Session", xsession);
                   
                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }

     

       


        
    }
}