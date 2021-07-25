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
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Org.BouncyCastle.Bcpg.Attr;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class teacherdegree : System.Web.UI.Page
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
                //result.Visible = false;
                //barchart.Visible = false;
                //if (ViewState["msg"].ToString() != "1")
                //{
                //    btnApprove.Visible = true;
                //    btnSave.Visible = true;
                //}

                //message.InnerHtml = xschool.Text.ToString().Trim().Split(' ').First();

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
        private void BindGrid()
        {

            //SqlConnection conn12;
            //conn12 = new SqlConnection(zglobal.constring);
            //DataSet dts2 = new DataSet();


            //dts2.Reset();

            //string str2 = "select zid,xemp,xname,xposition from hrjobpositionvw " +
            //              "where zid=@zid group by zid,xemp,xname,xposition ";


            //SqlDataAdapter da2 = new SqlDataAdapter(str2, conn12);
            //int _zid2 = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));


            //da2.SelectCommand.Parameters.Add("@zid", _zid2);
            //da2.Fill(dts2, "tempztcode");
            //DataTable dtztcode2 = new DataTable();
            //dtztcode2 = dts2.Tables[0];



            //dts2.Dispose();
            //dtztcode2.Dispose();
            //da2.Dispose();
            //conn12.Dispose();



            SqlConnection conn13;
            conn13 = new SqlConnection(zglobal.constring);
            DataSet dts3 = new DataSet();

            dts3.Reset();

            string str3 = "SELECT * from hredugradunpostvw where zid=@zid and xstatusemp='A-Active' and xtypeemp='teacher'";

            SqlDataAdapter da3 = new SqlDataAdapter(str3, conn13);
            int _zid3 = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            da3.SelectCommand.Parameters.Add("@zid", _zid3);
            //da3.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da3.Fill(dts3, "tempztcode");
            DataTable dtztcode3 = new DataTable();
            dtztcode3 = dts3.Tables[0];



            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "";

            if (_searchbox.Text.Trim().ToString() != String.Empty)
            {
                str = "SELECT zid,xemp,xname from hredugradunpostvw where zid=@zid and xstatusemp='A-Active' and xtypeemp='teacher' and (xemp like '%" + _searchbox.Text.Trim().ToString() + "%' or xname like '%" + _searchbox.Text.Trim().ToString() + "%') " +
                 "Group by zid,xemp,xname " +
                 "ORDER BY xemp";
            }
            else
            {
                if (xdegree.Text.Trim().ToString() != "All" && xsubject.Text.Trim().ToString() == "All")
                {
                    str = "SELECT zid,xemp,xname from hredugradunpostvw where zid=@zid and xstatusemp='A-Active' and xtypeemp='teacher' and xexamname=@xexamname " +
                  "Group by zid,xemp,xname " +
                  "ORDER BY xemp";
                }
                else if (xdegree.Text.Trim().ToString() == "All" && xsubject.Text.Trim().ToString() != "All")
                {
                    str = "SELECT zid,xemp,xname from hredugradunpostvw where zid=@zid and xstatusemp='A-Active' and xtypeemp='teacher' and xsubject=@xsubject " +
                  "Group by zid,xemp,xname " +
                  "ORDER BY xemp";
                }
                else if (xdegree.Text.Trim().ToString() != "All" && xsubject.Text.Trim().ToString() != "All")
                {
                    str = "SELECT zid,xemp,xname from hredugradunpostvw where zid=@zid and xstatusemp='A-Active' and xtypeemp='teacher' and xsubject=@xsubject and xexamname=@xexamname " +
                  "Group by zid,xemp,xname " +
                  "ORDER BY xemp";
                }
                else
                {
                    str = "SELECT zid,xemp,xname from hredugradunpostvw where zid=@zid and xstatusemp='A-Active' and xtypeemp='teacher' " +
                  "Group by zid,xemp,xname " +
                  "ORDER BY xemp";
                }
                
            }
            

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xexamname", xdegree.Text.Trim().ToString());
            da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.Trim().ToString());
            da.Fill(dts, "tempztcode");
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                HtmlGenericControl div12 = new HtmlGenericControl("div");
                div12.Attributes["style"] = "width: 100%; border: solid 1px #00A5E8; ";
                div12.Attributes["class"] = "bm_table";
                grid.Controls.Add(div12);

                HtmlGenericControl table = new HtmlGenericControl("table");
                //table.Attributes["class"] = "bm_table";
                div12.Controls.Add(table);

                HtmlGenericControl thead = new HtmlGenericControl("thead");
                table.Controls.Add(thead);

                HtmlGenericControl tr1 = new HtmlGenericControl("tr");
                thead.Controls.Add(tr1);

                HtmlGenericControl th = new HtmlGenericControl("th");
                tr1.Controls.Add(th);
                th.InnerHtml = "No.";
                th.Attributes["style"] = "width: 30px;";

                HtmlGenericControl th1 = new HtmlGenericControl("th");
                tr1.Controls.Add(th1);
                th1.InnerHtml = "ID";
                th1.Attributes["style"] = "width: 60px;";

                HtmlGenericControl th2 = new HtmlGenericControl("th");
                tr1.Controls.Add(th2);
                th2.InnerHtml = "Name";
                th2.Attributes["style"] = "width: 200px;";

                HtmlGenericControl th3 = new HtmlGenericControl("th");
                tr1.Controls.Add(th3);
                th3.InnerHtml = "Graduations";
                th3.Attributes["style"] = "width: 400px;";
                th3.Attributes["colspan"] = "2";

                HtmlGenericControl th4 = new HtmlGenericControl("th");
                tr1.Controls.Add(th4);
                th4.InnerHtml = "Post Graduations";
                th4.Attributes["style"] = "width: 400px;";
                th4.Attributes["colspan"] = "2";

                HtmlGenericControl th5 = new HtmlGenericControl("th");
                tr1.Controls.Add(th5);

                HtmlGenericControl tbody = new HtmlGenericControl("tbody");
                table.Controls.Add(tbody);

                int k = 0;
                string color;
                int i = 1;

                foreach (DataRow _xemp in dtztcode.Rows)
                {

                    if (k % 2 == 0)
                    {
                        color = "#F0EFF7";
                    }
                    else
                    {
                        color = "#E1DFEF";
                    }

                    HtmlGenericControl tr123 = new HtmlGenericControl("tr");
                    tbody.Controls.Add(tr123);
                    tr123.Attributes["style"] = "background-color:" + color;

                    HtmlGenericControl td1 = new HtmlGenericControl("td");
                    td1.Attributes["Style"] = " text-align: center;width: 30px;";
                    td1.InnerHtml = i.ToString();
                    //td1.Attributes["rowspan"] = m.ToString();
                    tr123.Controls.Add(td1);

                    HtmlGenericControl td2 = new HtmlGenericControl("td");
                    td2.Attributes["Style"] = " text-align: center;width: 60px;";
                    td2.InnerHtml = _xemp["xemp"].ToString();
                    //td2.Attributes["rowspan"] = m.ToString();
                    tr123.Controls.Add(td2);

                    HtmlGenericControl td3 = new HtmlGenericControl("td");
                    td3.Attributes["Style"] = " text-align: left;width: 200px;padding-left:5px";
                    td3.InnerHtml = _xemp["xname"].ToString();
                    //td3.Attributes["rowspan"] = m.ToString();
                    tr123.Controls.Add(td3);

                    HtmlGenericControl td4 = new HtmlGenericControl("td");
                    td4.Attributes["Style"] = " text-align: left;width: 150px;padding-left:5px";
                   // td4.InnerHtml = _xemp["xname"].ToString();
                    //td3.Attributes["rowspan"] = m.ToString();
                    tr123.Controls.Add(td4);

                    HtmlGenericControl td5 = new HtmlGenericControl("td");
                    td5.Attributes["Style"] = " text-align: left;width: 250px;padding-left:5px";
                    // td4.InnerHtml = _xemp["xname"].ToString();
                    //td3.Attributes["rowspan"] = m.ToString();
                    tr123.Controls.Add(td5);

                    DataRow[] result1 = dtztcode3.Select("xemp='" + _xemp["xemp"] + "' and xtype='graduation'");
                    if (result1.Length > 0)
                    {
                        td4.InnerHtml = result1[0]["xexamname"].ToString() + ", " + result1[0]["xresult1"].ToString();
                        td5.InnerHtml = result1[0]["xsubject"].ToString();
                    }
                    else
                    {
                        td4.InnerHtml = "";
                        td5.InnerHtml = "";
                    }

                    HtmlGenericControl td6 = new HtmlGenericControl("td");
                    td6.Attributes["Style"] = " text-align: left;width: 150px;padding-left:5px";
                    // td4.InnerHtml = _xemp["xname"].ToString();
                    //td3.Attributes["rowspan"] = m.ToString();
                    tr123.Controls.Add(td6);

                    HtmlGenericControl td7 = new HtmlGenericControl("td");
                    td7.Attributes["Style"] = " text-align: left;width: 250px;padding-left:5px";
                    // td4.InnerHtml = _xemp["xname"].ToString();
                    //td3.Attributes["rowspan"] = m.ToString();
                    tr123.Controls.Add(td7);

                    DataRow[] result2 = dtztcode3.Select("xemp='" + _xemp["xemp"] + "' and xtype='postgraduation'");
                    if (result2.Length > 0)
                    {
                         td6.InnerHtml = result2[0]["xexamname"].ToString() +", "+result2[0]["xresult1"].ToString();
                         td7.InnerHtml = result2[0]["xsubject"].ToString();
                    }
                    else
                    {
                        td6.InnerHtml = "";
                        td7.InnerHtml = "";
                    }

                    HtmlGenericControl td8 = new HtmlGenericControl("td");
                    tr123.Controls.Add(td8);


                    k = k + 1;
                    i = i + 1;

                }




            }

            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();

        }

      

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (GridView1.DataSource == null)
            //    {
            //        return;
            //    }




            //    for (int i = subTotalRowIndex; i < GridView1.Rows.Count; i++)
            //    {
            //        subTotalBoys += Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text);
            //        subTotalGirls += Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
            //        subTotalDropout += Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
            //        subTotal += Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);
            //    }
            //    this.AddTotalRow("Sub Total", subTotalBoys.ToString("N0"), subTotalGirls.ToString("N0"), subTotal.ToString("N0"), subTotalDropout.ToString("N0"));
            //    this.AddTotalRow("Total", totalBoys.ToString("N0"), totalGirls.ToString("N0"), total.ToString("N0"), totalDropout.ToString("N0"));

            //    //int rowIndex = 0;
            //    //int rowno = 1;
            //    //int l = 0;
            //    //int k = 1;
            //    //for (k = 1; k < GridView1.Rows.Count; k++)
            //    //{
            //    //    //GridViewRow gvRow = GridView1.Rows[k];

            //    //    //if (l != 0)
            //    //    //{
            //    //    //    gvRow.CssClass = "BorderRow";
            //    //    //}

            //    //    if (GridView1.Rows[k].Cells[1].Text == GridView1.Rows[k - 1].Cells[1].Text)
            //    //    {
            //    //        l = l + 1;
            //    //    }
            //    //    else
            //    //    {
            //    //        if (l != 0)
            //    //        {
            //    //            //GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
            //    //            GridView1.Rows[k - l - 1].Cells[1].RowSpan = l + 1;
            //    //            //GridView1.Rows[k - l - 1].Cells[0].RowSpan = l + 1;
            //    //            for (int p = 0; p < l; p++)
            //    //            {
            //    //                //GridView1.HeaderRow.Cells[k - l + p].Visible = false;
            //    //                GridView1.Rows[k - l + p].Cells[1].Visible = false;
            //    //                //GridView1.Rows[k - l + p].Cells[0].Visible = false;
            //    //            }

            //    //            //if (rowno != 1)
            //    //            //{
            //    //            //    GridView1.Rows[k - l - 1].CssClass = "BorderRow";
            //    //            //}

            //    //            ////Label lbl = (Label)GridView1.Rows[k - l - 1].FindControl("lblno");
            //    //            ////lbl.Text = rowno.ToString();

            //    //            //rowno = rowno + 1;
            //    //        }
            //    //        //else
            //    //        //{
            //    //        l = 0;
            //    //        //}
            //    //    }
            //    //}

            //    //if (l != 0)
            //    //{
            //    //    //GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
            //    //    GridView1.Rows[k - l - 1].Cells[1].RowSpan = l + 1;
            //    //    GridView1.Rows[k - l - 1].Cells[0].RowSpan = l + 1;
            //    //    for (int p = 0; p < l; p++)
            //    //    {
            //    //        //GridView1.HeaderRow.Cells[k - l + p].Visible = false;
            //    //        GridView1.Rows[k - l + p].Cells[1].Visible = false;
            //    //        //GridView1.Rows[k - l + p].Cells[0].Visible = false;
            //    //    }
            //    //    //GridView1.Rows[k - l - 1].CssClass = "BorderRow";
            //    //    //Label lbl = (Label)GridView1.Rows[k - l - 1].FindControl("lblno");
            //    //    //lbl.Text = rowno.ToString();

            //    //    rowno = rowno + 1;
            //    //}


            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}

        }


        private int xprevious = 0;
        private int xreadmis = 0;
        private int xnew = 0;
        private int xtotal = 0;

        private string currentClass = "";
        int currentId = 0;
        decimal subTotalBoys = 0;
        decimal totalBoys = 0;
        decimal subTotalGirls = 0;
        decimal totalGirls = 0;
        decimal subTotalDropout = 0;
        decimal totalDropout = 0;
        decimal subTotal = 0;
        decimal total = 0;
        int subTotalRowIndex = 0;
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    subTotalBoys = 0;
            //    subTotalGirls = 0;
            //    subTotalDropout = 0;
            //    subTotal = 0;

            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        //xprevious += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xprevious"));
            //        //xreadmis += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xreadmis"));
            //        //xnew += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xnew"));
            //        //xtotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xtotal"));
            //        DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;

            //        string xclass = dt.Rows[e.Row.RowIndex]["xclass"].ToString();

            //        //if (e.Row.RowIndex > 0)
            //        //{
            //        //    xclass = dt.Rows[e.Row.RowIndex-1]["xclass"].ToString();
            //        //}

            //        totalBoys += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xboy"]);
            //        totalGirls += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xgirl"]);
            //        totalDropout += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xdropout"]);
            //        total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xtotal"]);

            //        if (xclass != currentClass)
            //        {
            //            if (e.Row.RowIndex > 0)
            //            {
            //                for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
            //                {
            //                    subTotalBoys += Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text);
            //                    subTotalGirls += Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
            //                    subTotalDropout += Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
            //                    subTotal += Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);
            //                }
            //                this.AddTotalRow("Sub Total", subTotalBoys.ToString("N0"), subTotalGirls.ToString("N0"), subTotal.ToString("N0"), subTotalDropout.ToString("N0"));
            //                subTotalRowIndex = e.Row.RowIndex;
            //            }
            //            currentClass = xclass;
            //        }

            //    }
            //    //    if (e.Row.RowType == DataControlRowType.Footer)
            //    //    {
            //    //        e.Row.Cells[1].Text = "Grand Total :";
            //    //        e.Row.Cells[1].Font.Bold = true;
            //    //        e.Row.Cells[1].ForeColor = Color.White;


            //    //        e.Row.Cells[2].Text = xprevious.ToString();
            //    //        e.Row.Cells[2].Font.Bold = true;
            //    //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            //    //        e.Row.Cells[2].ForeColor = Color.White;

            //    //        e.Row.Cells[3].Text = xreadmis.ToString();
            //    //        e.Row.Cells[3].Font.Bold = true;
            //    //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //    //        e.Row.Cells[3].ForeColor = Color.White;

            //    //        e.Row.Cells[4].Text = xnew.ToString();
            //    //        e.Row.Cells[4].Font.Bold = true;
            //    //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            //    //        e.Row.Cells[4].ForeColor = Color.White;

            //    //        e.Row.Cells[5].Text = xtotal.ToString();
            //    //        e.Row.Cells[5].Font.Bold = true;
            //    //        e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            //    //        e.Row.Cells[5].ForeColor = Color.White;
            //    //    }

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        private void AddTotalRow(string labelText, string value1, string value2, string value3, string value4)
        {
            //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            ////row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
            //if (labelText == "Total")
            //{
            //    row.BackColor = ColorTranslator.FromHtml("#79B7E4");
            //}
            //else
            //{
            //    row.BackColor = Color.PowderBlue;
            //}

            //row.ForeColor = Color.White;
            //if (labelText == "Total")
            //{
            //    row.Cells.AddRange(new TableCell[9] { 

            //                                      new TableCell (), //Empty Cell
            //                                       new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right, ForeColor = Color.White,},
            //                                      new TableCell (),
            //                                      new TableCell { Text = value1, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
            //                                       new TableCell { Text = value2, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
            //                                        new TableCell { Text = value3, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
            //                                         new TableCell { Text = value4, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
            //                                          new TableCell (),
            //                                          new TableCell ()
            //});
            //}
            //else
            //{
            //    row.Cells.AddRange(new TableCell[9] { 

            //                                      new TableCell (), //Empty Cell
            //                                       new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right, ForeColor = Color.Brown,},
            //                                      new TableCell (),
            //                                      new TableCell { Text = value1, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
            //                                       new TableCell { Text = value2, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
            //                                        new TableCell { Text = value3, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
            //                                         new TableCell { Text = value4, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
            //                                          new TableCell (),
            //                                          new TableCell ()
            //});
            //}

            //GridView1.Controls[0].Controls.Add(row);
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
                    // _gridrow.Text = zglobal._grid_row_value;

                    //xfrom.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //xto.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //fnFillDataGrid(null,null);
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCalendar(xdate);

                    //zglobal.fnGetComboDataCD("Session", xsession);

                    //zglobal.fnGetComboDataCD("Location", xschool);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //xclass.Items.Add("All");
                    //xclass.Text = "All";
                    //zglobal.fnPermission(xclass);

                    //zglobal.fnGetComboDataCDWithProp1("Designation", xdesig, "showinlist");
                    ////zglobal.fnGetComboDataCD("Designation", xdesig);
                    //xdesig.Items.Add("All");
                    //xdesig.Text = "All";

                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;

                    ViewState["msg"] = "1";
                    //result.Visible = false;
                    //barchart.Visible = false;
                    //btnApprove.Visible = false;
                    //btnSave.Visible = false;
                    ////BindGrid();
                    /// 
                    /// 

                    //xdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    //DataTable dummy = new DataTable();
                    //dummy.Columns.Add("");
                    //dummy.Columns.Add("xclass");
                    //dummy.Columns.Add("xprevious");
                    //dummy.Columns.Add("xreadmis");
                    //dummy.Columns.Add("xnew");
                    //dummy.Columns.Add("xtotal");
                    //dummy.Rows.Add();
                    //GridView1.DataSource = dummy;
                    //GridView1.DataBind();
                    //GridView1.Visible = false;

                    xdegree.Items.Clear();
                    //combo.Items.Add("[Select]");
                    xdegree.Items.Add("");
                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                        SqlCommand cmd = new SqlCommand(query, con);
                        string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                        cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                        cmd.Parameters.AddWithValue("@xtype", "Name of Exam");
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            string xprop = zglobal.fnProperty2("Name of Exam", rdr["xcode"].ToString(), "school");
                            if (xprop.ToLower() == "3" || xprop.ToLower() == "4")
                            {
                                xdegree.Items.Add(rdr["xcode"].ToString());
                            }
                        }
                    }
                    //combo.Text = "[Select]";
                    xdegree.Items.Add("All");
                    xdegree.Text = "All";


                    zglobal.fnGetComboDataCD("Subject", xsubject);
                    xsubject.Items.Add("All");
                    xsubject.Text = "All";

                }

                //if (IsPostBack)
                //{
                //    xprevious = 0;
                //    xreadmis = 0;
                //    xnew = 0;
                //    xtotal = 0;
                //fnFillDataGrid(null, null);
                // message.InnerHtml = "";
                //}

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }

        }





        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    subTotalBoys = 0;
            //    subTotalGirls = 0;
            //    subTotalDropout = 0;
            //    subTotal = 0;

            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {

            //        DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;

            //        string xclass = dt.Rows[e.Row.RowIndex]["xclass"].ToString();


            //        totalBoys += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xboy"]);
            //        totalGirls += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xgirl"]);
            //        totalDropout += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xdropout"]);
            //        total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xtotal"]);

            //        if (xclass != currentClass)
            //        {
            //            if (e.Row.RowIndex > 0)
            //            {
            //                for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
            //                {
            //                    subTotalBoys += Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text);
            //                    subTotalGirls += Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
            //                    subTotalDropout += Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
            //                    subTotal += Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);
            //                }
            //                this.AddTotalRow("Sub Total", subTotalBoys.ToString("N0"), subTotalGirls.ToString("N0"), subTotal.ToString("N0"), subTotalDropout.ToString("N0"));
            //                subTotalRowIndex = e.Row.RowIndex;
            //            }
            //            currentClass = xclass;
            //        }

            //    }

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


     

    }
}