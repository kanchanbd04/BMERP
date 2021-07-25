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
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class asteappstco : System.Web.UI.Page
    {


        string zid;
        string zorg;
        string ctlid;
        string rowid;
        object row;
        private string q_val;
        private string filter;


        public void fnFillDataGrid(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                BindGrid();

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
        List<int> listtest = new List<int>();
        List<int> listretest = new List<int>();
        List<string> listtrow = new List<string>();
        List<string> listmaxrtcount = new List<string>();
        List<string> listretestrow = new List<string>();
        List<string> listsubject = new List<string>();
        List<string> listpaper = new List<string>();
        List<string> listext = new List<string>();
        private void BindGrid()
        {

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //ViewState["xrow"] = null;

            //string xrow = zglobal.fnGetValue("xrow", "amexamh",
            //     "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
            //     "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xstatus in('Approved2','Approved3')");
            ////if (ViewState["xrow"] == null)
            //if (xrow == "")
            //{
            //    message.InnerHtml = "No data found.";
            //    message.Style.Value = zglobal.am_warningmsg;
            //    return;
            //}

            SqlConnection conn11;
            conn11 = new SqlConnection(zglobal.constring);
            DataSet dts11 = new DataSet();

            dts11.Reset();

            string str1 = "SELECT ROW_NUMBER() OVER (ORDER BY xcttype desc, xctno asc) AS xid,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xtype='Term Exam' AND xgroup=@xgroup   order by xsection";


            SqlDataAdapter da11 = new SqlDataAdapter(str1, conn11);
            da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //da11.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //da11.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            da11.Fill(dts11, "tempztcode");
            DataTable dtmarks1 = new DataTable();
            dtmarks1 = dts11.Tables[0];

            if (dtmarks1.Rows.Count <= 0)
            {
                message.InnerHtml = "No data found.";
                message.Style.Value = zglobal.am_warningmsg;
                return;
            }








            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string xsession1 = xsession.Text.Trim().ToString();
            string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            //string xsection1 = xsection.Text.Trim().ToString();
            //message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            //return;
            //string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";

            string str = "SELECT xsection FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                " WHERE amexamh.zid=@zid AND amexamh.xsession=@xsession AND amexamh.xclass=@xclass AND amexamh.xterm=@xterm AND amexamh.xtype='Term Exam' AND xgroup=@xgroup  " +
                " group by xsection  order by min(cast(xcodealt as int))";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {

                GridView1.Columns.Clear();

                //TemplateField tfield119 = new TemplateField();
                //tfield119.HeaderText = "No.";
                //tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield119.ItemStyle.Width = 35;
                //GridView1.Columns.Add(tfield119);

                //TemplateField tfield120 = new TemplateField();
                //tfield120.HeaderText = "Sec. / Sub.";
                //tfield120.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                //tfield120.ItemStyle.Width = 200;
                //GridView1.Columns.Add(tfield120);

                bfield = new BoundField();
                bfield.HeaderText = "Sec. / Sub.";
                bfield.DataField = "xsection";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                bfield.ItemStyle.Width = 80;
                bfield.ItemStyle.CssClass = "pad5";
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);


                //Generating coloum for all subject
                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    //string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xcttype asc, xctno asc";
                    string query = "SELECT distinct xsubject,xpaper,coalesce(xext,'') as xext FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                                   "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xtype='Term Exam' AND xgroup=@xgroup ORDER BY xsubject,xpaper";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int rowCount = 0;
                    listtest.Clear();
                    listtrow.Clear();
                    listretest.Clear();
                    listsubject.Clear();
                    listpaper.Clear();
                    listext.Clear();

                    int test_count = 0;

                    //int cnt = 0;
                    while (rdr.Read())
                    {
                        tfield = new TemplateField();
                        //if (rdr["xpaper"].ToString() != "")
                        //{
                        //    tfield.HeaderText = rdr["xsubject"].ToString() + "-" +rdr["xpaper"].ToString();
                        //}
                        //else
                        //{
                        //    tfield.HeaderText = rdr["xsubject"].ToString();
                        //}

                        if ((rdr["xpaper"].ToString() != "" || rdr["xpaper"].ToString() != String.Empty) && 
                            (rdr["xext"].ToString() != "" || rdr["xext"].ToString() != String.Empty))
                        {
                            tfield.HeaderText = rdr["xsubject"].ToString() + "(" + rdr["xext"].ToString() + ")" + "-" + rdr["xpaper"].ToString();
                        }
                        else if ((rdr["xpaper"].ToString() != "" || rdr["xpaper"].ToString() != String.Empty) &&
                       (rdr["xext"].ToString() == "" || rdr["xext"].ToString() == String.Empty))
                        {
                            tfield.HeaderText = rdr["xsubject"].ToString()  + "-" + rdr["xpaper"].ToString();
                        }
                        else if ((rdr["xpaper"].ToString() == "" || rdr["xpaper"].ToString() == String.Empty) &&
                       (rdr["xext"].ToString() != "" || rdr["xext"].ToString() != String.Empty))
                        {
                            tfield.HeaderText = rdr["xsubject"].ToString() + "(" + rdr["xext"].ToString() + ")" ;
                        }
                        else
                        {
                            tfield.HeaderText = rdr["xsubject"].ToString();
                        }

                        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        tfield.ItemStyle.Width = 120;
                        GridView1.Columns.Add(tfield);

                        test_count = test_count + 1;
                        listtest.Add(test_count);
                        //listtrow.Add(rdr["xrow"].ToString());
                        listsubject.Add(rdr["xsubject"].ToString());
                        listpaper.Add(rdr["xpaper"].ToString());
                        listext.Add(rdr["xext"].ToString());
                        //listtrow.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                        rowCount = rowCount + 1;
                    }

                    if (test_count == 0)
                    {
                        listtest.Add(test_count);
                    }

                    ViewState["listretest"] = listretest;
                    ViewState["listtest"] = listtest;
                    ViewState["listtrow"] = listtrow;
                    ViewState["rowCount"] = rowCount;
                    ViewState["xsubject"] = listsubject;
                    ViewState["xpaper"] = listpaper;
                    ViewState["xext"] = listext;
                }




                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                       "SELECT xcttype,xctno,xstatus,xgroup,zid,xsection,xsubject,xpaper,coalesce(xext,'') as xext, " +
                       "(select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xsteacher) as xsteacher, " +
                       "(select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xcteacher) as xcteacher,xdetails " +
                       "FROM amexamh " +
                       "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xtype='Term Exam' and xgroup=@xgroup ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamh"] = dtamexamd;

                    }
                }

              
                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield2);

                //BoundField bfield1 = new BoundField();
                //bfield1.DataField = "xsubject";
                //GridView1.Columns.Add(bfield1);

                //BoundField bfield2 = new BoundField();
                //bfield2.DataField = "xpaper";
                //GridView1.Columns.Add(bfield2);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                //bfield1.Visible = false;
                //bfield2.Visible = false;

                //int i = 1;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Label lbl = (Label)row.FindControl("lblno");
                //    lbl.Text = i.ToString();
                //    i++;
                //}

               




            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (GridView1.DataSource == null)
            //    {
            //        return;
            //    }

            //    //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            //    //TableHeaderCell cell = new TableHeaderCell();

            //    //GridView1.HeaderRow.Cells[0].Visible = false;
            //    //GridView1.HeaderRow.Cells[1].Visible = false;


            //    //cell = new TableHeaderCell();
            //    //cell.Text = "No.";
            //    //cell.RowSpan = 2;
            //    //row.Controls.Add(cell);

            //    //cell = new TableHeaderCell();
            //    //cell.Text = "Subject's Name";
            //    //cell.RowSpan = 2;
            //    //row.Controls.Add(cell);

            //    ////GridView1.Rows[0].Cells[0].RowSpan = 2;
            //    ////GridView1.Rows[0].Cells[1].RowSpan = 2;
            //    ////GridView1.Rows[0].Cells[2].RowSpan = 2;
            //    //int i = 4;
            //    //foreach (string val in (List<string>)ViewState["listtrow"])
            //    //{
            //    //    cell = new TableHeaderCell();
            //    //    cell.ColumnSpan = 5;
            //    //    cell.Text = val;
            //    //    cell.BorderStyle = BorderStyle.Solid;
            //    //    cell.BorderWidth = 2;
            //    //    cell.BorderColor = Color.White;
            //    //    row.Controls.Add(cell);

            //    //    GridView1.HeaderRow.Cells[i+1].Visible = false;
            //    //    GridView1.HeaderRow.Cells[i + 2].Visible = false;

            //    //    GridView1.HeaderRow.Cells[i].ColumnSpan = 3;

            //    //    i = i + 5;
            //    //}


            //    //cell = new TableHeaderCell();
            //    //row.Controls.Add(cell);
            //    //// row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            //    //GridView1.HeaderRow.Parent.Controls.AddAt(0, row);



            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}

        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    int i = 1;
                    for(int j =0; j< Convert.ToInt32(ViewState["rowCount"]);j++)
                    {

                        DataRow[] result = ((DataTable)ViewState["amexamh"]).Select("zid=" + _zid + " and xsection='" +
                                                                            (e.Row.DataItem as DataRowView).Row["xsection"].ToString() + "' and xsubject='" +
                                                                            ((List<string>)ViewState["xsubject"])[j] + "' and xpaper='" + ((List<string>)ViewState["xpaper"])[j] + "' and xext='" + ((List<string>)ViewState["xext"])[j] + "'");

                        if (result.Length > 0)
                        {
                            //HtmlGenericControl div1 = new HtmlGenericControl("div");
                            //e.Row.Cells[i].Controls.Add(div1);

                            for (int k = 1; k <= result.Length; k++)
                            {
                                
                                //HtmlGenericControl div2 = new HtmlGenericControl("div");
                                //div2.Attributes["style"] = "float: left;";
                                //div1.Controls.Add(div2);

                                Button btn1 = new Button();
                                //btn1.Enabled = false;
                                btn1.OnClientClick = "javascript:return false;";
                                btn1.CssClass = "bm_square_button1 bm_circle_button_coordinator";

                                if (result[k-1][2].ToString() == "Submited")
                                {
                                    //btn1.Attributes["style"] = "background-image:linear-gradient(180deg, transparent 50%, #00A651 50%)," +
                                    //    "linear-gradient(180deg, #FF0000 100%, transparent 0%);";

                                    btn1.Attributes["style"] = "background-image: linear-gradient(90deg, #0DB14B 50%, transparent 50%);";
                                }
                                if (result[k-1][2].ToString() == "Approved1")
                                {
                                    btn1.Attributes["style"] = "background-color: #0DB14B;background-image: linear-gradient(180deg, transparent 50%, #0DB14B 50%), " +
                                        "linear-gradient(90deg, transparent 50%, #FF0000 50%);";

                                  
                                }
                                if (result[k-1][2].ToString() == "Approved2" || result[0][2].ToString() == "Approved3")
                                {
                                    btn1.Attributes["style"] = "background-color: #0DB14B";
                                   
                                }



                                //btn1.CommandName = xcttype1 + "-" + xctno1;
                                //if (((List<string>) ViewState["xpaper"])[j] == "")
                                //{
                                //    btn1.ToolTip = result[k - 1][0].ToString() + "-" + result[k - 1][1].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsection"].ToString() + "\n" + result[k - 1][3].ToString() + "\n" +
                                //                   ((List<string>) ViewState["xsubject"])[j];
                                //}
                                //else
                                //{
                                //    btn1.ToolTip = result[k - 1][0].ToString() + "-" + result[k - 1][1].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsection"].ToString() + "\n" + result[k - 1][3].ToString() + "\n" +
                                //                   ((List<string>) ViewState["xsubject"])[j] + "-" +
                                //                   ((List<string>) ViewState["xpaper"])[j];
                                //}

                                if ((((List<string>)ViewState["xpaper"])[j] != "" || ((List<string>)ViewState["xpaper"])[j] != String.Empty) &&
                                    (((List<string>)ViewState["xext"])[j] != "" || ((List<string>)ViewState["xext"])[j] != String.Empty))
                                {
                                    btn1.ToolTip = result[k - 1][0].ToString() + "-" + result[k - 1][1].ToString() +
                                                   "\n" + (e.Row.DataItem as DataRowView).Row["xsection"].ToString() +
                                                   "\n" + result[k - 1][3].ToString() + "\n" +
                                                   ((List<string>) ViewState["xsubject"])[j] + "(" +
                                                   ((List<string>) ViewState["xext"])[j] + ")"
                                                   + "-" + ((List<string>) ViewState["xpaper"])[j] + "\n"
                                                   + "Teacher: " + result[k - 1]["xsteacher"].ToString() + "\n"
                                                   + "Class Teacher: " + result[k - 1]["xcteacher"].ToString() + "\n"
                                                   + "Details: " + result[k - 1]["xdetails"].ToString();
                                }
                                else if ((((List<string>)ViewState["xpaper"])[j] != "" || ((List<string>)ViewState["xpaper"])[j] != String.Empty) &&
                               (((List<string>)ViewState["xext"])[j] == "" || ((List<string>)ViewState["xext"])[j] == String.Empty))
                                {
                                    btn1.ToolTip = result[k - 1][0].ToString() + "-" + result[k - 1][1].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsection"].ToString() + "\n" + result[k - 1][3].ToString() + "\n" +
                                                   ((List<string>)ViewState["xsubject"])[j]
                                                   + "-" + ((List<string>)ViewState["xpaper"])[j] + "\n"
                                                   + "Teacher: " + result[k - 1]["xsteacher"].ToString() + "\n"
                                                   + "Class Teacher: " + result[k - 1]["xcteacher"].ToString() + "\n"
                                                   + "Details: " + result[k - 1]["xdetails"].ToString();
                                }
                                else if ((((List<string>)ViewState["xpaper"])[j] == "" || ((List<string>)ViewState["xpaper"])[j] == String.Empty) &&
                               (((List<string>)ViewState["xext"])[j] != "" || ((List<string>)ViewState["xext"])[j] != String.Empty))
                                {
                                    btn1.ToolTip = result[k - 1][0].ToString() + "-" + result[k - 1][1].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsection"].ToString() + "\n" + result[k - 1][3].ToString() + "\n" +
                                                   ((List<string>)ViewState["xsubject"])[j] + "(" + ((List<string>)ViewState["xext"])[j] + ")" + "\n"
                                                   + "Teacher: " + result[k - 1]["xsteacher"].ToString() + "\n"
                                                   + "Class Teacher: " + result[k - 1]["xcteacher"].ToString() + "\n"
                                                   + "Details: " + result[k - 1]["xdetails"].ToString();
                                }
                                else
                                {
                                    btn1.ToolTip = result[k - 1][0].ToString() + "-" + result[k - 1][1].ToString() +
                                                   "\n" + (e.Row.DataItem as DataRowView).Row["xsection"].ToString() +
                                                   "\n" + result[k - 1][3].ToString() + "\n" +
                                                   ((List<string>)ViewState["xsubject"])[j] + "\n"
                                                   + "Teacher: " + result[k - 1]["xsteacher"].ToString() + "\n"
                                                   + "Class Teacher: " + result[k - 1]["xcteacher"].ToString() + "\n"
                                                   + "Details: " + result[k - 1]["xdetails"].ToString();
                                }
                                
                                //div2.Controls.Add(btn1);
                                e.Row.Cells[i].Controls.Add(btn1);

                               //if (k%3 == 0)
                               //{
                               //    div1 = new HtmlGenericControl("div");
                               //    e.Row.Cells[i].Controls.Add(div1);
                               //}
                            }
                        }


                        i = i + 1;
                    }


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

                //xname.Text = "";
                _student.Value = "";

                GridView1.DataSource = null;
                GridView1.DataBind();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        protected void combo1_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                // message.InnerHtml = "";

                //// BindGrid(1999, 1);

                // if (ViewState["xrow"] == null)
                // {
                //     message.InnerHtml = "No data found.";
                //     message.Style.Value = zglobal.am_warningmsg;
                //     return;
                // }


                //// hiddenxdate.Value = xdate.SelectedValue.ToString();


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

                fnFillDataGrid(null, null);

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

                //    //////Check Permission
                //    ////SiteMaster sm = new SiteMaster();
                //    ////string s = sm.fnChkPagePermis("ztpermis");
                //    ////if (s == "n" || s == "e")
                //    ////{
                //    ////    HttpContext.Current.Session["curuser"] = null;
                //    ////    Session.Abandon();
                //    ////    Response.Redirect("~/forms/zlogin.aspx");
                //    ////}


                //    //pagew = Request.QueryString["page"];
                //    //if (pagew == "user")
                //    //{
                //    //    curuser = Request.QueryString["xuser"];
                //    //    xuser.InnerHtml = "User : " + curuser;
                //    //}
                //    //else
                //    //{
                //    //    curuser = Request.QueryString["xrole"];
                //    //    xuser.InnerHtml = "Role : " + curuser;
                //    //}

                //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                if (!IsPostBack)
                {
                    // //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                    // ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                    // //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                    // ctlid_v.Value = ctlid;
                    //// Response.Write(ctlid_v.Value);
                    _gridrow.Text = zglobal._grid_row_value;

                    //xfrom.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //xto.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //fnFillDataGrid(null,null);
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCalendar(xdate);

                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnPermission(xclass);



                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;


                    //BindGrid();

                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }

        }







    }
}