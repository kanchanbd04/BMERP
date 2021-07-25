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


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class amstdstrength : System.Web.UI.Page
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

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xclass,xdescdet,xboy,xgirl,xtotal,xyeardrop,xdropout,xstdiddropout,xname,xreason " +
                         "FROM amstdstrength  " +
                         "WHERE zid=@zid AND xschool = @xschool  and xsession=@xsession " +
                         "ORDER BY zid,xsession,xcodealtclass,xcodealtsection ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));


            //message.InnerHtml = xfrom1 + " " + xto1;
            da.SelectCommand.Parameters.Add("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xschool", xschool.Text.ToString().Split(' ').First().Trim());
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView1.DataSource = dtztcode;
            GridView1.DataBind();



            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            //        //string query =
            //        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            //        string query =
            //       "SELECT  xsession,xprevious, xreadmis, xnew, xtotal " +
            //             "FROM amnumstudentvw2 as b  " +
            //             "WHERE zid=@zid AND xsession in(select top 2 xsession from amnumstudentvw2 as a where zid=b.zid and xsession<=@xsession order by xsession desc)" ;

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());

            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];

            //        if (dtamexamd.Rows.Count > 0)
            //        {
            //            Chart1.DataSource = dtamexamd;
            //            Chart1.DataBind();
            //        }
            //        else
            //        {
            //            Chart1.DataSource = null;
            //            Chart1.DataBind();
            //        }

            //    }
            //}

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            //        //string query =
            //        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            //        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            //        string query =
            //       "SELECT  xprevious, xreadmis, xnew, xtotal " +
            //             "FROM amnumstudentvw2   " +
            //             "WHERE zid=@zid AND xsession =@xsession";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());

            //        da1.Fill(dts1, "tempztcode");
            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];

            //        if (dtamexamd.Rows.Count > 0)
            //        {
            //            DataTable dt = new DataTable();
            //            dt.Columns.Add("key",typeof(string));
            //            dt.Columns.Add("value", typeof (int));

            //            //for (int i = 0; i < dt.Columns.Count; i++)
            //            //{
            //            dt.Rows.Add("Last Session", Convert.ToInt32(dtamexamd.Rows[0]["xprevious"].ToString()));
            //                dt.Rows.Add("Re-Admission", Convert.ToInt32(dtamexamd.Rows[0]["xreadmis"].ToString()));
            //                dt.Rows.Add("New", Convert.ToInt32(dtamexamd.Rows[0]["xnew"].ToString()));
            //                dt.Rows.Add("Total", Convert.ToInt32(dtamexamd.Rows[0]["xtotal"].ToString()));
            //            //}

            //                string[] XPointMember = new string[dt.Rows.Count];
            //                int[] YPointMember = new int[dt.Rows.Count];

            //                for (int count = 0; count < dt.Rows.Count; count++)
            //                {
            //                    //storing Values for X axis  
            //                    XPointMember[count] = dt.Rows[count]["key"].ToString();
            //                    //storing values for Y Axis  
            //                    YPointMember[count] = Convert.ToInt32(dt.Rows[count]["value"]);

            //                }

            //                //binding chart control  
            //                Chart2.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //                //Setting width of line  
            //                //Chart2.Series[0].BorderWidth = 10;
            //                //setting Chart type   
            //                Chart2.Series[0].ChartType = SeriesChartType.Pie;
            //                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true; 

            //                foreach (Series charts in Chart2.Series)
            //                {
            //                    foreach (DataPoint point in charts.Points)
            //                    {
            //                        switch (point.AxisLabel)
            //                        {
            //                            case "Last Session": point.Color = Color.RoyalBlue; break;
            //                            case "Re-Admission": point.Color = Color.SaddleBrown; break;
            //                            case "New": point.Color = Color.SpringGreen; break;
            //                            case "Total": point.Color = Color.ForestGreen; break;
            //                        }
            //                        //point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);
            //                        point.Label = string.Format("{0}", point.AxisLabel);

            //                    }
            //                }     

            //            //Chart2.DataSource = dt;
            //            //Chart2.DataBind();
            //        }
            //        else
            //        {
            //            Chart2.DataSource = null;
            //            Chart2.DataBind();
            //        }

            //    }
            //}

            int RowSpan = 2;
            int RowSpan3 = 2;
            int sl = 1;
            for (int i = GridView1.Rows.Count - 2; i >= 0; i--)
            {
                GridViewRow currRow = GridView1.Rows[i];
                GridViewRow prevRow = GridView1.Rows[i + 1];

               

                string txt1 = currRow.Cells[1].Text;
                string  txt2 = prevRow.Cells[1].Text;

                if (txt1 == txt2)
                {
                   
                    currRow.Cells[1].RowSpan = RowSpan;
                    prevRow.Cells[1].Visible = false;
                    currRow.Cells[0].RowSpan = RowSpan;
                    prevRow.Cells[0].Visible = false;
                   
                    RowSpan += 1;
                }
                else
                {
                    RowSpan = 2;
                  
                }

            }

            int RowSpan1 = 2;
            int j = 0;
            int k = 0;
            //List<int> listcount = new List<int>();
            for (int i = 0; i <= GridView1.Rows.Count - 2; i++)
            {

                GridViewRow currRow = GridView1.Rows[i];
                GridViewRow nextRow = GridView1.Rows[i + 1];

                string txt1 = currRow.Cells[1].Text;
                string txt2 = nextRow.Cells[1].Text;

                Label lbl1 = currRow.Cells[0].FindControl("lblsl") as Label;
                Label lbl2 = nextRow.Cells[0].FindControl("lblsl") as Label;

                lbl1.Text = (j + 1).ToString();
                lbl2.Text = (j + 2).ToString();

                string htmlColorCode = "";

                if (txt1 == txt2)
                {
                    if (RowSpan1 == 2)
                    {
                        j += 1;
                    }

                    RowSpan1 += 1;
                    k += 1;
                }
                else
                {
                    RowSpan1 = 2;
                    if (k > 0)
                    {
                        k = 0;
                    }
                    else
                    {
                        j += 1;
                    }
                }

                if (j % 2 == 0)
                {
                    htmlColorCode = "#E1DFEF";
                }
                else
                {
                    htmlColorCode = "#F0EFF7";
                }

                currRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[7].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[8].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                currRow.Cells[9].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                nextRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[7].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[8].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                nextRow.Cells[9].BackColor = ColorTranslator.FromHtml(htmlColorCode);

               

                if (i == GridView1.Rows.Count - 2 && txt1 != txt2)
                {
                    if ((j + 1) % 2 == 0)
                    {
                        htmlColorCode = "#E1DFEF";
                    }
                    else
                    {
                        htmlColorCode = "#F0EFF7";
                    }

                    nextRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[7].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[8].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[9].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                }
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




                for (int i = subTotalRowIndex; i < GridView1.Rows.Count; i++)
                {
                    subTotalBoys += Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text);
                    subTotalGirls += Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
                    subTotalDropout += Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);
                    subTotalYearEndDropout += Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
                    subTotal += Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);
                }
                this.AddTotalRow("Sub Total", subTotalBoys.ToString("N0"), subTotalGirls.ToString("N0"), subTotal.ToString("N0"), subTotalDropout.ToString("N0"), subTotalYearEndDropout.ToString("N0"));
                this.AddTotalRow("Total", totalBoys.ToString("N0"), totalGirls.ToString("N0"), total.ToString("N0"), totalDropout.ToString("N0"), totalYearEndDropout.ToString("N0"));

                //int rowIndex = 0;
                //int rowno = 1;
                //int l = 0;
                //int k = 1;
                //for (k = 1; k < GridView1.Rows.Count; k++)
                //{
                //    //GridViewRow gvRow = GridView1.Rows[k];

                //    //if (l != 0)
                //    //{
                //    //    gvRow.CssClass = "BorderRow";
                //    //}

                //    if (GridView1.Rows[k].Cells[1].Text == GridView1.Rows[k - 1].Cells[1].Text)
                //    {
                //        l = l + 1;
                //    }
                //    else
                //    {
                //        if (l != 0)
                //        {
                //            //GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
                //            GridView1.Rows[k - l - 1].Cells[1].RowSpan = l + 1;
                //            //GridView1.Rows[k - l - 1].Cells[0].RowSpan = l + 1;
                //            for (int p = 0; p < l; p++)
                //            {
                //                //GridView1.HeaderRow.Cells[k - l + p].Visible = false;
                //                GridView1.Rows[k - l + p].Cells[1].Visible = false;
                //                //GridView1.Rows[k - l + p].Cells[0].Visible = false;
                //            }

                //            //if (rowno != 1)
                //            //{
                //            //    GridView1.Rows[k - l - 1].CssClass = "BorderRow";
                //            //}

                //            ////Label lbl = (Label)GridView1.Rows[k - l - 1].FindControl("lblno");
                //            ////lbl.Text = rowno.ToString();

                //            //rowno = rowno + 1;
                //        }
                //        //else
                //        //{
                //        l = 0;
                //        //}
                //    }
                //}

                //if (l != 0)
                //{
                //    //GridView1.HeaderRow.Cells[k - l - 1].ColumnSpan = l + 1;
                //    GridView1.Rows[k - l - 1].Cells[1].RowSpan = l + 1;
                //    GridView1.Rows[k - l - 1].Cells[0].RowSpan = l + 1;
                //    for (int p = 0; p < l; p++)
                //    {
                //        //GridView1.HeaderRow.Cells[k - l + p].Visible = false;
                //        GridView1.Rows[k - l + p].Cells[1].Visible = false;
                //        //GridView1.Rows[k - l + p].Cells[0].Visible = false;
                //    }
                //    //GridView1.Rows[k - l - 1].CssClass = "BorderRow";
                //    //Label lbl = (Label)GridView1.Rows[k - l - 1].FindControl("lblno");
                //    //lbl.Text = rowno.ToString();

                //    rowno = rowno + 1;
                //}


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

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
        decimal subTotalYearEndDropout = 0;
        decimal totalYearEndDropout = 0;
        decimal subTotalDropout = 0;
        decimal totalDropout = 0;
        decimal subTotal = 0;
        decimal total = 0;
        int subTotalRowIndex = 0;
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.DataItem as DataRowView).Row["xdropout"].ToString() != "0")
                    {
                        string[] student = (e.Row.DataItem as DataRowView).Row["xstdiddropout"].ToString().Split(',');
                        string[] name = (e.Row.DataItem as DataRowView).Row["xname"].ToString().Split(',');
                        string[] reason = (e.Row.DataItem as DataRowView).Row["xreason"].ToString().Split(',');

                        int i = 0;
                        foreach (string str in student)
                        {
                            Label lbl4 = new Label();
                            //lbl4.Style["display"] = "block";
                            //lbl4.Style["width"] = "80px";
                            //lbl4.Style["text-align"] = "center";
                            lbl4.CssClass = "lblstd";
                            e.Row.Cells[8].Controls.Add(lbl4);

                            
                            lbl4.Text = str + " ";

                            lbl4.ToolTip = "Name : " + name[i] + " \n Reason : " + reason[i];

                            i = i + 1;
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

        private void AddTotalRow(string labelText, string value1, string value2, string value3, string value4, string value5)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            //row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
            if (labelText == "Total")
            {
                row.BackColor = ColorTranslator.FromHtml("#79B7E4");
            }
            else
            {
                row.BackColor = Color.PowderBlue;
            }
            
            row.ForeColor = Color.White;
            if (labelText == "Total")
            {
                row.Cells.AddRange(new TableCell[10] { 
                                               
                                                  new TableCell (), //Empty Cell
                                                   new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right, ForeColor = Color.White,},
                                                  new TableCell (),
                                                  new TableCell { Text = value1, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
                                                   new TableCell { Text = value2, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
                                                    new TableCell { Text = value3, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
                                                    new TableCell { Text = value5, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
                                                     new TableCell { Text = value4, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.White },
                                                      new TableCell (),
                                                      new TableCell ()
            });
            }
            else
            {
                row.Cells.AddRange(new TableCell[10] { 
                                               
                                                  new TableCell (), //Empty Cell
                                                   new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right, ForeColor = Color.Brown,},
                                                  new TableCell (),
                                                  new TableCell { Text = value1, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
                                                   new TableCell { Text = value2, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
                                                    new TableCell { Text = value3, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
                                                    new TableCell { Text = value5, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
                                                     new TableCell { Text = value4, HorizontalAlign = HorizontalAlign.Center, ForeColor = Color.Brown },
                                                      new TableCell (),
                                                      new TableCell ()
            });
            }

            GridView1.Controls[0].Controls.Add(row);
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

                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Location", xschool);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnPermission(xclass);



                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
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



        [WebMethod]
        public static string GetClasswiseNumStudent(string xsession)
        {

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT xcodealt,xclass, xprevious, xreadmis, xnew, xtotal " +
                         "FROM amnumstudentvw1  " +
                         "WHERE zid=@zid AND xsession = @xsession " +
                         "ORDER BY xcodealt ";

                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession);
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds.GetXml();
                    }

                }
            }
        }


        [WebMethod]
        public static string GetClasswiseNumStudent1(string xsession)
        {

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT xprevious, xreadmis, xnew, xtotal " +
                         "FROM amnumstudentvw2  " +
                         "WHERE zid=@zid AND xsession = @xsession ";

                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession);
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds.GetXml();
                    }

                }
            }
        }


        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                subTotalBoys = 0;
                subTotalGirls = 0;
                subTotalDropout = 0;
                subTotalYearEndDropout = 0;
                subTotal = 0;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                    DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;

                    string xclass = dt.Rows[e.Row.RowIndex]["xclass"].ToString();


                    totalBoys += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xboy"]);
                    totalGirls += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xgirl"]);
                    totalDropout += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xdropout"]);
                    totalYearEndDropout += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xyeardrop"]);
                    total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["xtotal"]);

                    if (xclass != currentClass)
                    {
                        if (e.Row.RowIndex > 0)
                        {
                            for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
                            {
                                subTotalBoys += Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text);
                                subTotalGirls += Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
                                subTotalYearEndDropout += Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
                                subTotalDropout += Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);
                                subTotal += Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);
                            }
                            this.AddTotalRow("Sub Total", subTotalBoys.ToString("N0"), subTotalGirls.ToString("N0"), subTotal.ToString("N0"), subTotalDropout.ToString("N0"), subTotalYearEndDropout.ToString("N0"));
                            subTotalRowIndex = e.Row.RowIndex;
                        }
                        currentClass = xclass;
                    }

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