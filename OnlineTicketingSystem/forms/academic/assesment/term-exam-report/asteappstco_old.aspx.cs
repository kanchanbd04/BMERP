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
using CrystalDecisions.CrystalReports.Engine;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class asteappstco_old : System.Web.UI.Page
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
                "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Term Exam'  AND xsection=@xsection  order by xstdid";


            SqlDataAdapter da11 = new SqlDataAdapter(str1, conn11);
            da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
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
            string xgroup1 = xgroup.Text.Trim().ToString();
            string xsection1 = xsection.Text.Trim().ToString();
            //message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            //return;
            //string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";

            string str = "SELECT xsubject,xpaper,coalesce(xext,'') as xext,count(*) FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
               "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Term Exam'  AND xsection=@xsection  " +
               "group by xsubject,xpaper,xext order by xsubject,xpaper,xext";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
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

                TemplateField tfield120 = new TemplateField();
                tfield120.HeaderText = "Subject's Name";
                tfield120.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield120.ItemStyle.Width = 200;
                GridView1.Columns.Add(tfield120);

                tfield = new TemplateField();
                tfield.HeaderText = "Taken Date";
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield.ItemStyle.Width = 80;
                GridView1.Columns.Add(tfield);

                tfield = new TemplateField();
                tfield.HeaderText = "Status";
                tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                tfield.HeaderStyle.ForeColor = Color.DimGray;
                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield.ItemStyle.Width = 60;
                tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                GridView1.Columns.Add(tfield);


                ////Generating coloum for all test
                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    //string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xcttype asc, xctno asc";
                //    string query = "SELECT distinct xcttype,xctno FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                //                   "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";


                //    SqlCommand cmd = new SqlCommand(query, con);
                //    cmd.Parameters.AddWithValue("@zid", _zid);
                //    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //    cmd.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                //    //cmd.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                //    //cmd.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                //    cmd.CommandType = CommandType.Text;
                //    con.Open();
                //    SqlDataReader rdr = cmd.ExecuteReader();
                //    int rowCount = 0;
                //    listtest.Clear();
                //    listtrow.Clear();
                //    listretest.Clear();

                //    int test_count = 0;

                //    //int cnt = 0;
                //    while (rdr.Read())
                //    {
                //        tfield = new TemplateField();
                //        //tfield.HeaderText = rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString();
                //        tfield.HeaderText = "Schedule";
                //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //        tfield.ItemStyle.Width = 60;
                //        GridView1.Columns.Add(tfield);

                //        tfield = new TemplateField();
                //        tfield.HeaderText = "Taken Date";
                //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //        tfield.ItemStyle.Width = 60;
                //        GridView1.Columns.Add(tfield);

                //        tfield = new TemplateField();
                //        tfield.HeaderText = "Status";
                //        tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                //        tfield.HeaderStyle.ForeColor = Color.DimGray;
                //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //        tfield.ItemStyle.Width = 10;
                //        tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                //        GridView1.Columns.Add(tfield);

                //        tfield = new TemplateField();
                //        tfield.HeaderText = "Status";
                //        tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                //        tfield.HeaderStyle.ForeColor = Color.DimGray;
                //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //        tfield.ItemStyle.Width = 10;
                //        tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                //        GridView1.Columns.Add(tfield);

                //        tfield = new TemplateField();
                //        tfield.HeaderText = "Status";
                //        tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                //        tfield.HeaderStyle.ForeColor = Color.DimGray;
                //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //        tfield.ItemStyle.Width = 10;
                //        tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                //        GridView1.Columns.Add(tfield);


                //        test_count = test_count + 1;
                //        listtest.Add(test_count);
                //        //listtrow.Add(rdr["xrow"].ToString());
                //        listtrow.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                //        //listtrow.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                //        rowCount = rowCount + 5;

                //        ////Generate column for retest
                //        //string maxretest = zglobal.fnGetValue("max(xid)", "amexamretestvw",
                //        //   "zid='" + _zid + "' AND xsession='" + xsession.Text.ToString().Trim() + "' AND xclass='" + xclass.Text.ToString().Trim() +
                //        //   "' AND xterm='" + xterm.Text.ToString().Trim() + "' AND xgroup='" + xgroup.Text.ToString().Trim() +
                //        //   "' AND xtype='Class Test'  AND xsection='" + xsection.Text.ToString().Trim() +
                //        //   "' AND xsrow=" + _student.Value.ToString().Trim() +
                //        //   " AND xcttype in('Retest') AND xrefcttype='" + rdr["xcttype"].ToString() + "' AND xrefctno='" + rdr["xctno"].ToString() + "' AND xstatus in('Approved2','Approved3')");
                //        ////message.InnerHtml = message.InnerHtml + maxretest;
                //        //int retest_count = 0;
                //        //int maxrtcount = 0;
                //        //if (maxretest != null && maxretest != "")
                //        //{

                //        //    for (int p = 1; p <= Convert.ToInt32(maxretest); p++)
                //        //    {
                //        //        tfield = new TemplateField();
                //        //        //tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                //        //        tfield.HeaderText = "Retest";
                //        //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //        //        tfield.ItemStyle.Width = 40;
                //        //        tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                //        //        tfield.HeaderStyle.ForeColor = Color.DimGray;
                //        //        tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                //        //        GridView1.Columns.Add(tfield);
                //        //        retest_count = retest_count + 1;
                //        //        rowCount = rowCount + 1;

                //        //        listtrow.Add("-1");
                //        //    }


                //        //}
                //        //listretest.Add(retest_count);

                //    }

                //    if (test_count == 0)
                //    {
                //        listtest.Add(test_count);
                //    }

                //    ViewState["listretest"] = listretest;
                //    ViewState["listtest"] = listtest;
                //    ViewState["listtrow"] = listtrow;
                //    ViewState["rowCount"] = rowCount;
                //}

               


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                       "SELECT xschdate,xdate,xstatus,zid,xsubject,xpaper,coalesce(xext,'') as xext FROM amexamh " +
                       "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Term Exam'  AND xsection=@xsection ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamh"] = dtamexamd;

                    }
                }

                TemplateField tfield122 = new TemplateField();
                tfield122.HeaderText = "No. of Students";
                tfield122.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield122.ItemStyle.Width = 80;
                GridView1.Columns.Add(tfield122);

                TemplateField tfield123 = new TemplateField();
                tfield123.HeaderText = "Present in the Exam";
                tfield123.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield123.ItemStyle.Width = 80;
                GridView1.Columns.Add(tfield123);

                TemplateField tfield124 = new TemplateField();
                tfield124.HeaderText = "Absent in the Exam";
                tfield124.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield124.ItemStyle.Width = 80;
                GridView1.Columns.Add(tfield124);

                TemplateField tfield125 = new TemplateField();
                tfield125.HeaderText = "Not Applicable";
                tfield125.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield125.ItemStyle.Width = 80;
                GridView1.Columns.Add(tfield125);

                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield2);

                BoundField bfield1 = new BoundField();
                bfield1.DataField = "xsubject";
                GridView1.Columns.Add(bfield1);

                BoundField bfield2 = new BoundField();
                bfield2.DataField = "xpaper";
                GridView1.Columns.Add(bfield2);

                BoundField bfield3 = new BoundField();
                bfield3.DataField = "xext";
                GridView1.Columns.Add(bfield3);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                //bfield1.Visible = false;
                //bfield2.Visible = false;
                //bfield3.Visible = false;
                bfield1.ItemStyle.CssClass = "hiddencol";
                bfield1.HeaderStyle.CssClass = "hiddencol";
                bfield2.ItemStyle.CssClass = "hiddencol";
                bfield2.HeaderStyle.CssClass = "hiddencol";
                bfield3.ItemStyle.CssClass = "hiddencol";
                bfield3.HeaderStyle.CssClass = "hiddencol";

                tfield122.ItemStyle.CssClass = "hiddencol";
                tfield122.HeaderStyle.CssClass = "hiddencol";

                tfield123.ItemStyle.CssClass = "hiddencol";
                tfield123.HeaderStyle.CssClass = "hiddencol";

                tfield124.ItemStyle.CssClass = "hiddencol";
                tfield124.HeaderStyle.CssClass = "hiddencol";

                tfield125.ItemStyle.CssClass = "hiddencol";
                tfield125.HeaderStyle.CssClass = "hiddencol";

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
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.DataSource == null)
                {
                    return;
                }

                //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                //TableHeaderCell cell = new TableHeaderCell();

                //GridView1.HeaderRow.Cells[0].Visible = false;
                //GridView1.HeaderRow.Cells[1].Visible = false;


                //cell = new TableHeaderCell();
                //cell.Text = "No.";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Subject's Name";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                ////GridView1.Rows[0].Cells[0].RowSpan = 2;
                ////GridView1.Rows[0].Cells[1].RowSpan = 2;
                ////GridView1.Rows[0].Cells[2].RowSpan = 2;
                //int i = 4;
                //foreach (string val in (List<string>)ViewState["listtrow"])
                //{
                //    cell = new TableHeaderCell();
                //    cell.ColumnSpan = 5;
                //    cell.Text = val;
                //    cell.BorderStyle = BorderStyle.Solid;
                //    cell.BorderWidth = 2;
                //    cell.BorderColor = Color.White;
                //    row.Controls.Add(cell);

                //    GridView1.HeaderRow.Cells[i+1].Visible = false;
                //    GridView1.HeaderRow.Cells[i + 2].Visible = false;

                //    GridView1.HeaderRow.Cells[i].ColumnSpan = 3;

                //    i = i + 5;
                //}


                //cell = new TableHeaderCell();
                //row.Controls.Add(cell);
                //// row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
                //GridView1.HeaderRow.Parent.Controls.AddAt(0, row);



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

                    Label lblno = new Label();
                    lblno.Text = "";
                    lblno.ID = "lblno";
                    lblno.ForeColor = Color.Black;
                    e.Row.Cells[0].Controls.Add(lblno);

                    Label lblsubject = new Label();
                    lblsubject.Text = "";
                    lblsubject.ID = "lblsubject";
                    lblsubject.ForeColor = Color.Black;
                    e.Row.Cells[1].Controls.Add(lblsubject);

                    //if ((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "")
                    //{
                    //    lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
                    //                      (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    //}
                    //else
                    //{
                    //    lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    //}

                    if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != String.Empty) &&
                        ((e.Row.DataItem as DataRowView).Row["xext"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() != String.Empty))
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "(" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + ")" + "-"
                            + (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    }
                    else if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != String.Empty) &&
                    ((e.Row.DataItem as DataRowView).Row["xext"].ToString() == "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() == String.Empty))
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-"
                            + (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    }
                    else if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == String.Empty) &&
                    ((e.Row.DataItem as DataRowView).Row["xext"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() != String.Empty))
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "(" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + ")";
                    }
                    else
                    {
                        lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    }

                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    DataRow[] result = ((DataTable)ViewState["amexamh"]).Select("zid=" + _zid + " and xsubject='" +
                                                                         (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
                                                                         (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xext='" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'");

                    if (result.Length > 0)
                    {
                        Label xdate = new Label();
                        xdate.Text = Convert.ToDateTime(result[0]["xdate"].ToString()).ToString("dd/MM/yy");
                        e.Row.Cells[2].Controls.Add(xdate);

                        Button btn1 = new Button();
                        btn1.Enabled = true;
                        btn1.OnClientClick = "javascript:return false;";
                        btn1.CssClass = "bm_square_button bm_square_button_coordinator";
                        //btn1.CommandName = xcttype1 + "-" + xctno1;
                        e.Row.Cells[3].Controls.Add(btn1);

                        if (result[0][2].ToString() == "Submited")
                        {
                            btn1.Attributes["style"] = "background-image: linear-gradient(90deg, #0DB14B 50%, transparent 50%);";

                            //btn1.Enabled = false;
                        }

                        if (result[0][2].ToString() == "Approved1")
                        {
                            btn1.Attributes["style"] = "background-color: #0DB14B;background-image: linear-gradient(180deg, transparent 50%, #0DB14B 50%), " +
                                       "linear-gradient(90deg, transparent 50%, #FF0000 50%);";

                            //btn1.Enabled = false;
                        }

                        if (result[0][2].ToString() == "Approved2" || result[0][2].ToString() == "Approved3")
                        {
                            btn1.Attributes["style"] = "background-color: #0DB14B";

                            //btn1.Enabled = false;
                        }

                       
                    }

                    //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    //int i = 4;
                    //int c = 0;
                    //foreach (string val in (List<string>)ViewState["listtrow"])
                    //{
                        



                    //   string[] type = ((List<string>)ViewState["listtrow"])[c].Split('-');
                    //   string xcttype1 = type[0];
                    //   string xctno1 = type[1];

                       

                    //   DataRow[] result = ((DataTable)ViewState["amexamh"]).Select("zid=" + _zid + " and xsubject='" +
                    //                                                        (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
                    //                                                        (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "'" + " and xcttype='" + xcttype1 + "' and xctno='" + xctno1 + "'");

                    //    if (result.Length > 0)
                    //    {

                    //        Button btn1 = new Button();
                    //        btn1.Enabled = true;
                    //        btn1.OnClientClick = "javascript:return false;";
                    //        btn1.CssClass = "bm_circle_button bm_circle_button_subject";
                    //        //btn1.CommandName = xcttype1 + "-" + xctno1;
                    //        e.Row.Cells[i].Controls.Add(btn1);


                    //        Button btn2 = new Button();
                    //        btn2.Enabled = false;
                    //        btn2.OnClientClick = "javascript:return false;";
                    //        btn2.CssClass = "bm_circle_button bm_circle_button_class";
                    //        //btn2.CommandName = xcttype1 + "-" + xctno1;
                    //        e.Row.Cells[i + 1].Controls.Add(btn2);

                    //        Button btn3 = new Button();
                    //        btn3.Enabled = false;
                    //        btn3.OnClientClick = "javascript:return false;";
                    //        btn3.CssClass = "bm_circle_button bm_circle_button_coordinator";
                    //        //btn3.CommandName = xcttype1 + "-" + xctno1;
                    //        e.Row.Cells[i + 2].Controls.Add(btn3);


                    //        if ((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "")
                    //        {
                    //            btn1.ToolTip = ((List<string>)ViewState["listtrow"])[c].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
                    //                              (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    //            btn2.ToolTip = ((List<string>)ViewState["listtrow"])[c].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
                    //                              (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    //            btn3.ToolTip = ((List<string>)ViewState["listtrow"])[c].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
                    //                              (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    //        }
                    //        else
                    //        {
                    //            btn1.ToolTip = ((List<string>)ViewState["listtrow"])[c].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    //            btn2.ToolTip = ((List<string>)ViewState["listtrow"])[c].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    //            btn3.ToolTip = ((List<string>)ViewState["listtrow"])[c].ToString() + "\n" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    //        }

                    //        if (xcttype1 == "Test")
                    //        {
                    //            Label xschdate = new Label();
                    //            xschdate.Text = Convert.ToDateTime(result[0][0].ToString()).ToString("dd/MM/yy");
                    //            e.Row.Cells[i - 2].Controls.Add(xschdate);
                    //        }

                    //        Label xdate = new Label();
                    //        xdate.Text = Convert.ToDateTime(result[0][1].ToString()).ToString("dd/MM/yy");
                    //        e.Row.Cells[i - 1].Controls.Add(xdate);

                    //        //if (result[0][1].ToString() == "New")
                    //        //{
                    //        //    btn1.Attributes["style"] = "background-color: #FF0000";
                    //        //    btn2.Attributes["style"] = "background-color: #FF0000";
                    //        //    btn3.Attributes["style"] = "background-color: #FF0000";
                    //        //}

                    //        if (result[0][2].ToString() == "Submited")
                    //        {
                    //            btn1.Attributes["style"] = "background-color: #0DB14B";
                    //            btn2.Attributes["style"] = "background-color: #FF0000";
                    //            btn3.Attributes["style"] = "background-color: #FF0000";

                    //            btn1.Enabled = false;
                    //            //btn2.Enabled = true;
                    //            //btn3.Enabled = true;
                    //        }

                    //        if (result[0][2].ToString() == "Approved1")
                    //        {
                    //            btn1.Attributes["style"] = "background-color: #0DB14B";
                    //            btn2.Attributes["style"] = "background-color: #0DB14B";
                    //            btn3.Attributes["style"] = "background-color: #FF0000";

                    //            btn1.Enabled = false;
                    //            btn2.Enabled = false;
                    //            //btn3.Enabled = true;
                    //        }

                    //        if (result[0][2].ToString() == "Approved2" || result[0][2].ToString() == "Approved3")
                    //        {
                    //            btn1.Attributes["style"] = "background-color: #0DB14B";
                    //            btn2.Attributes["style"] = "background-color: #0DB14B";
                    //            btn3.Attributes["style"] = "background-color: #0DB14B";

                    //            btn1.Enabled = false;
                    //            btn2.Enabled = false;
                    //            btn3.Enabled = false;
                    //        }
                    //    }





                    //    i = i + 5;
                    //    c = c + 1;
                    //}


                    





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
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCalendar(xdate);

                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

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