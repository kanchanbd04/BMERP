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
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class asctvwsw : System.Web.UI.Page
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
        List<string> listtest = new List<string>();
        List<int> listretest = new List<int>();
        List<int> listmissedtest = new List<int>();
        List<string> listtrow = new List<string>();
        List<string> listmaxrtcount = new List<string>();
        List<string> listretestrow = new List<string>();
        private void BindGrid()
        {

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ViewState["xrow"] = null;

            string xrow = zglobal.fnGetValue("xrow", "amexamh",
                 "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
                 "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xsubject='" + xsubject.Text.Trim().ToString() + "' and xpaper='" + xpaper.Text.Trim().ToString() + "' and coalesce(xext,'')='" + xext.Text.Trim().ToString() + "'" + " and xstatus in('Approved2','Approved3') and xtype='Class Test'");
            //if (ViewState["xrow"] == null)
            if (xrow == "")
            {
                message.InnerHtml = "No data found.";
                message.Style.Value = zglobal.am_warningmsg;
                //dxstatus.Visible = false;
                //dxstatus.Text = "Status : ";
                //dxstatus.Style.Value = zglobal.am_submited;
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
            string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xname";

            //string str = "SELECT ROW_NUMBER() OVER (ORDER BY xcttype desc, xctno asc) AS xid,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //    "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper order by xstdid";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
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

                bfield = new BoundField();
                bfield.HeaderText = "No.";
                //bfield.ShowHeader = false;
                bfield.DataField = "xid";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.ItemStyle.Width = 35;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

                //bfield = new BoundField();
                //bfield.HeaderText = "ID";
                ////bfield.ShowHeader = false;
                //bfield.DataField = "xstdid";
                //bfield.ItemStyle.Width = 50;
                //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //bfield.HtmlEncode = false;
                //GridView1.Columns.Add(bfield);

                TemplateField tfield3 = new TemplateField();
                tfield3.HeaderText = "ID";
                tfield3.ItemStyle.Width = 50;
                tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield3);

                bfield = new BoundField();
                bfield.HeaderText = "Student's Name";
                //bfield.ShowHeader = false;
                bfield.DataField = "xname";
                bfield.ItemStyle.Width = 200;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

              

                //Generating coloum for all test
                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    string query = "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xcttype in('Test','Test (WS)') AND xstatus in('Approved2','Approved3') ORDER BY xdate";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    int rowCount = 0;
                    listtest.Clear();
                    listtrow.Clear();
                    listretest.Clear();
                    listmissedtest.Clear();
                    listmaxrtcount.Clear();
                    listretestrow.Clear();

                    while (rdr.Read())
                    {
                        //if (rowCount == 0)
                        //{
                        //    dxstatus.Visible = true;
                        //    dxstatus.Text = "Status : " + rdr["xstatus"].ToString();
                        //    dxstatus.Style.Value = zglobal.am_submited;
                        //}

                        tfield = new TemplateField();
                        tfield.HeaderText = Convert.ToDateTime(rdr["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(rdr["xmarks"].ToString()).ToString("###");
                        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        tfield.ItemStyle.Width = 80;
                        GridView1.Columns.Add(tfield);


                        listtest.Add(rdr["xcttype"].ToString() + "-" + rdr["xctno"].ToString());
                        listtrow.Add(rdr["xrow"].ToString());
                        rowCount = rowCount + 1;

                        //Generate column for retest
                        string maxretest = zglobal.fnGetValue("max(xid)", "amexamretestvw",
                           "zid='" + _zid + "' AND xsession='" + xsession.Text.ToString().Trim() + "' AND xclass='" + xclass.Text.ToString().Trim() +
                           "' AND xterm='" + xterm.Text.ToString().Trim() + "' AND xgroup='" + xgroup.Text.ToString().Trim() +
                           "' AND xtype='Class Test'  AND xsection='" + xsection.Text.ToString().Trim() +
                           "' AND xsubject='" + xsubject.Text.ToString().Trim() + "' AND xpaper='" + xpaper.Text.ToString().Trim() +
                           "' AND coalesce(xext,'')='"+xext.Text.Trim().ToString()+"' AND xcttype in('Retest') AND xrefcttype='" + rdr["xcttype"].ToString() + "' AND xrefctno='" + rdr["xctno"].ToString() + "' AND xstatus in('Approved2','Approved3')");
                        //message.InnerHtml = message.InnerHtml + maxretest;
                        int retest_count = 0;
                        int maxrtcount = 0;
                        if (maxretest != null && maxretest != "")
                        {

                            for (int i = 1; i <= Convert.ToInt32(maxretest); i++)
                            {
                                tfield = new TemplateField();
                                //tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                                tfield.HeaderText = "Retest";
                                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                tfield.ItemStyle.Width = 40;
                                tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#FAD5E5");
                                tfield.HeaderStyle.ForeColor = Color.DimGray;
                                tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#F2D8E8");
                                GridView1.Columns.Add(tfield);
                                retest_count = retest_count + 1;
                                rowCount = rowCount + 1;

                                listtrow.Add("-1");
                            }
                        }
                       
                        listretest.Add(retest_count);


                        ////Generate column for missed-test
                        //string maxmissedtest = zglobal.fnGetValue("max(xid)", "amexammissedtestvw",
                        //   "zid='" + _zid + "' AND xsession='" + xsession.Text.ToString().Trim() + "' AND xclass='" + xclass.Text.ToString().Trim() +
                        //   "' AND xterm='" + xterm.Text.ToString().Trim() + "' AND xgroup='" + xgroup.Text.ToString().Trim() +
                        //   "' AND xtype='Class Test'  AND xsection='" + xsection.Text.ToString().Trim() +
                        //   "' AND xsubject='" + xsubject.Text.ToString().Trim() + "' AND xpaper='" + xpaper.Text.ToString().Trim() +
                        //   "' AND coalesce(xext,'')='" + xext.Text.Trim().ToString() + "' AND xcttype in('Missed Test') AND xrefcttype='" + rdr["xcttype"].ToString() + "' AND xrefctno='" + rdr["xctno"].ToString() + "' AND xstatus in('Approved2','Approved3')");
                        ////message.InnerHtml = message.InnerHtml + maxretest;
                        //int missedtest_count = 0;
                        //int maxmtcount = 0;
                        //if (maxmissedtest != null && maxmissedtest != "")
                        //{

                        //    for (int i = 1; i <= Convert.ToInt32(maxmissedtest); i++)
                        //    {
                        //        tfield = new TemplateField();
                        //        //tfield.HeaderText = Convert.ToDateTime(row["xdate"].ToString()).ToString("dd/MM/yy") + "<br/>" + "Marks:" + Convert.ToDecimal(row["xmarks"].ToString()).ToString("###");
                        //        tfield.HeaderText = "Missed Test";
                        //        tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //        tfield.ItemStyle.Width = 40;
                        //        tfield.HeaderStyle.BackColor = ColorTranslator.FromHtml("#8ED8F8");
                        //        tfield.HeaderStyle.ForeColor = Color.DimGray;
                        //        tfield.ItemStyle.BackColor = ColorTranslator.FromHtml("#8ED8F8");
                        //        GridView1.Columns.Add(tfield);
                        //        missedtest_count = missedtest_count + 1;
                        //        rowCount = rowCount + 1;

                        //        listtrow.Add("-2");
                        //    }
                        //}

                        //listmissedtest.Add(missedtest_count);



                    }

                    //if (rowCount == 0)
                    //{
                    //    dxstatus.Visible = false;
                    //    dxstatus.Text = "Status : ";
                    //    dxstatus.Style.Value = zglobal.am_submited;
                    //}

                    ViewState["listretest"] = listretest;
                    ViewState["listmissedtest"] = listmissedtest;
                    ViewState["listtest"] = listtest;
                    ViewState["listtrow"] = listtrow;
                    ViewState["rowCount"] = rowCount;
                }

                string xrow2 = "";

                for (int i = 0; i < listtrow.Count; i++)
                {
                    if (i == listtrow.Count - 1)
                    {
                        xrow2 = xrow2 + listtrow[i].ToString();
                    }
                    else
                    {
                        xrow2 = xrow2 + listtrow[i].ToString() + ",";
                    }
                }


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xcttype,amexamh.xctno,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        string query = "SELECT xgetmark,xtopic,xdetails,xcttype,xctno,zid,xrow, xsrow,xismissedtest FROM amexamvw_getmark1 WHERE zid=@zid AND xrow in (" + xrow2 + ")";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        // da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow2);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamd"] = dtamexamd;

                    }
                }






                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xgetmark,xtopic,xdetails,* FROM amexamretestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xcttype in('Retest') AND xstatus in('Approved2','Approved3')";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamretestvw"] = dtamexamd;

                    }
                }

                //Missed Test
                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts1 = new DataSet())
                //    {
                //        string query = "SELECT xgetmark,xtopic,xdetails,* FROM amexammissedtestvw WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xcttype in('Missed Test') AND xstatus in('Approved2','Approved3')";

                //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                //        da1.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());

                //        da1.Fill(dts1, "tempztcode");
                //        DataTable dtamexamd = new DataTable();
                //        dtamexamd = dts1.Tables[0];

                //        ViewState["amexammissedtestvw"] = dtamexamd;

                //    }
                //}

                ////foreach (DataRow row in ((DataTable)ViewState["amexamd"]).Rows)
                ////{
                ////    Response.Write(row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " <br>");
                ////}

                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield2);

                BoundField bfield1 = new BoundField();
                bfield1.DataField = "xrow";
                GridView1.Columns.Add(bfield1);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                //int i = 1;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Label lbl = (Label)row.FindControl("lblno");
                //    lbl.Text = i.ToString();
                //    i++;
                //}

                bfield1.Visible = false;




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


                ////for merging retest column
                //int k = 3;
                //int l = k;
                ////foreach (int data in (List<int>)ViewState["listretest"])
                ////{
                ////    if (data != 0)
                ////    {
                ////        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = data;
                ////        for (int m = 2; m <= data; m++)
                ////        {
                ////            GridView1.HeaderRow.Cells[k + m].Visible = false;
                ////        }
                ////        k = k + data + 1;
                ////    }
                ////    else
                ////    {
                ////        k = k + 1;
                ////    }

                ////}

                //List<int> listrt = (List<int>)ViewState["listretest"];
                //List<int> listmt = (List<int>)ViewState["listmissedtest"];

                //for (int j = 0; j < listrt.Count; j++)
                //{
                //    if (listrt[j] != 0)
                //    {
                //        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = listrt[j];
                //        for (int m = 2; m <= listrt[j]; m++)
                //        {
                //            GridView1.HeaderRow.Cells[k + m].Visible = false;
                //        }
                //        k = k + listrt[j] + 1;
                //    }
                //    else
                //    {
                //        k = k + 1;
                //    }

                //    l = k;

                //    if (listmt[j] != 0)
                //    {
                //        GridView1.HeaderRow.Cells[l].ColumnSpan = listmt[j];
                //        for (int m = 1; m <= listmt[j]; m++)
                //        {
                //            GridView1.HeaderRow.Cells[l + m].Visible = false;
                //        }
                //        //l = l + listrt[j] + 1;
                //    }
                //    //else
                //    //{
                //    //    l = l + 1;
                //    //}
                //}

                int l = 0;
                for (int k = 1; k <= (int)ViewState["rowCount"]; k++)
                {
                    if (GridView1.HeaderRow.Cells[k].Text == GridView1.HeaderRow.Cells[k - 1].Text)
                    {
                        l = l + 1;
                    }
                    else
                    {
                        if (l != 0)
                        {
                            GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
                            for (int p = 0; p < l; p++)
                            {
                                GridView1.HeaderRow.Cells[k - l + p].Visible = false;
                            }
                        }
                        //else
                        //{
                        l = 0;
                        //}
                    }
                }


                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();

                GridView1.HeaderRow.Cells[0].Visible = false;
                GridView1.HeaderRow.Cells[1].Visible = false;
                GridView1.HeaderRow.Cells[2].Visible = false;


                cell = new TableHeaderCell();
                cell.Text = "No.";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "ID";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.Text = "Student's Name";
                cell.RowSpan = 2;
                row.Controls.Add(cell);

                //GridView1.Rows[0].Cells[0].RowSpan = 2;
                //GridView1.Rows[0].Cells[1].RowSpan = 2;
                //GridView1.Rows[0].Cells[2].RowSpan = 2;
                int i = 0;
                foreach (string date in (List<string>)ViewState["listtest"])
                {
                    cell = new TableHeaderCell();
                    //cell.ColumnSpan = ((List<int>)ViewState["listretest"])[i] + listmt[i] + 1;
                    cell.ColumnSpan = ((List<int>)ViewState["listretest"])[i]  + 1;
                    //cell.ColumnSpan = ((List<int>)ViewState["listretest"])[i]  + 1;
                    //cell.Text = date;
                    cell.Text = "Test-" + (i+1).ToString();
                    cell.BorderStyle = BorderStyle.Solid;
                    cell.BorderWidth = 2;
                    cell.BorderColor = Color.White;
                    row.Controls.Add(cell);

                    i = i + 1;
                }


                cell = new TableHeaderCell();
                row.Controls.Add(cell);
                // row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
                GridView1.HeaderRow.Parent.Controls.AddAt(0, row);




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
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    HyperLink hlink = new HyperLink();
                    hlink.ID = "xtsdid";
                    hlink.CssClass = "_gridrow_link";
                    hlink.ForeColor = Color.Blue;
                    //hlink.NavigateUrl = "<%# Eval('FileLink', 'javascript:openWindow(&#039;{0}&#039;);') %>";
                    //hlink.Target = "_blank";
                    hlink.Text = (e.Row.DataItem as DataRowView).Row["xstdid"].ToString();
                    hlink.Attributes["style"] = "cursor: pointer;";
                    hlink.Attributes["onclick"] = "fnPrintInfo(" + (e.Row.DataItem as DataRowView).Row["xrow"].ToString() + ",'" + (e.Row.DataItem as DataRowView).Row["xname"].ToString() + "');";
                    e.Row.Cells[1].Controls.Add(hlink);

                    List<string> list_t_row = (List<string>)ViewState["listtrow"];
                    int retestcount = 0;
                    int mtcount = 0;
                    string xrefcttype1 = "";
                    string xrefctno1 = "";
                    for (int i = 3; i < 3 + (int)ViewState["rowCount"]; i = i + 1)
                    {

                        Label lblmarks = new Label();
                        lblmarks.Text = "";
                        lblmarks.ID = "lblmarks" + i.ToString();
                        lblmarks.ForeColor = Color.Black;
                        lblmarks.Attributes.Add("runat", "server");
                        //lblmarks.Text = "1.00";
                        //lnkbtn.Click += OnLinkClick;
                        e.Row.Cells[i].Controls.Add(lblmarks);

                        //e.Row.Cells[i].ToolTip = "Hi";

                        //message.InnerHtml = message.InnerHtml + " " +e.Row.Cells[4 + (int) ViewState["rowCount"]].Text;
                        Int64 xsrow = Convert.ToInt64(e.Row.Cells[4 + (int)ViewState["rowCount"]].Text);

                        ////var xmarks = from amexamd in ((DataTable)ViewState["amexamd"]).AsEnumerable()
                        ////             where amexamd.Field<int>("zid") == _zid && amexamd.Field<int>("xrow") == Convert.ToInt32(list_t_row[i]) && amexamd.Field<Int64>("xsrow") == xsrow
                        ////             select amexamd;

                        DataRow[] result =
                            ((DataTable)ViewState["amexamd"]).Select("zid=" + _zid + " and xrow=" +
                                                                      Convert.ToInt32(((List<string>)ViewState["listtrow"])[i - 3]) + " and xsrow=" +
                                                                      xsrow);


                        //foreach (DataRow row in result)
                        //{
                        //    lblmarks.Text = row[7].ToString();
                        //}
                        if (result.Length > 0)
                        {
                            if (result[0][0].ToString() != "-1.00")
                            {
                                lblmarks.Text = result[0][0].ToString();
                                e.Row.Cells[i].ToolTip = "Topic : " + result[0][1].ToString() + "\n" + "Details : " +
                                                         "\n" + result[0][2].ToString() + "\n" + result[0]["xcttype"].ToString() + "-" + result[0]["xctno"].ToString();
                            }
                            else
                            {
                                lblmarks.Text = "";
                            }

                            if (Convert.ToInt32(result[0]["xismissedtest"].ToString()) == 1)
                            {
                                e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#8ED8F8");
                            }

                            retestcount = 0;
                            mtcount = 0;
                            xrefcttype1 = result[0][3].ToString();
                            xrefctno1 = result[0][4].ToString();
                            //message.InnerHtml = message.InnerHtml + xrefcttype1 + "-" + xrefctno1 + "<br>";

                        }
                        else
                        {
                            //lblmarks.Text = "";

                            if (Convert.ToInt32(((List<string>)ViewState["listtrow"])[i - 3]) == -1)
                            {
                                retestcount = retestcount + 1;
                                int xid = retestcount;

                                DataRow[] result1 = ((DataTable)ViewState["amexamretestvw"]).Select("zid=" + _zid + " and xid=" +
                                                                      xid + " and xsrow=" +
                                                                      xsrow + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'");


                                if (result1.Length > 0)
                                {
                                    lblmarks.Text = result1[0][0].ToString();
                                    e.Row.Cells[i].ToolTip = "Topic : " + result1[0][1].ToString() + "\n" + "Details : " +
                                                             "\n" + result1[0][2].ToString();
                                }
                                else
                                {
                                    lblmarks.Text = "";
                                }

                                //message.InnerHtml = message.InnerHtml + xid + " " + xrefcttype1 + " " + xrefctno1 + " " +
                                //                    xsrow + "<br>";
                            }
                                //Missed Test
                            //else if (Convert.ToInt32(((List<string>)ViewState["listtrow"])[i - 3]) == -2)
                            //{
                            //    mtcount = mtcount + 1;
                            //    int xid1 = mtcount;

                            //    DataRow[] result11 = ((DataTable)ViewState["amexammissedtestvw"]).Select("zid=" + _zid + " and xid=" +
                            //                                          xid1 + " and xsrow=" +
                            //                                          xsrow + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'");


                            //    if (result11.Length > 0)
                            //    {
                            //        lblmarks.Text = result11[0][0].ToString();
                            //        e.Row.Cells[i].ToolTip = "Topic : " + result11[0][1].ToString() + "\n" + "Details : " +
                            //                                 "\n" + result11[0][2].ToString();
                            //    }
                            //    else
                            //    {
                            //        lblmarks.Text = "";
                            //    }

                            //    //message.InnerHtml = message.InnerHtml + xid + " " + xrefcttype1 + " " + xrefctno1 + " " +
                            //    //                    xsrow + "<br>";
                            //}
                            else
                            {
                                //lblmarks.Text = "U";
                                lblmarks.Text = "- -";
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


        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {

                message.InnerHtml = "";

                //dxstatus.Visible = false;
                //dxstatus.Text = "Status : ";

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
                    zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    zglobal.fnGetComboDataCD("Subject Extension", xext);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;

                    //dxstatus.Visible = false;
                    //dxstatus.Text = "Status : ";
                    //dxstatus.Style.Value = zglobal.am_submited;

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    _xext.Visible = false;
                    _xpaper.Visible = false;
                    //BindGrid();

                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
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

                if (xext.Items.Count <= 1)
                {
                    _xext.Visible = false;
                }
                else
                {
                    _xext.Visible = true;
                }

                if (xpaper.Items.Count <= 1)
                {
                    _xpaper.Visible = false;
                }
                else
                {
                    _xpaper.Visible = true;
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