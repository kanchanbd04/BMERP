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
    public partial class asctschvwsw : System.Web.UI.Page
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
                // SqlConnection conn1;
                // conn1 = new SqlConnection(zglobal.constring);
                // DataSet dts = new DataSet();


                // dts.Reset();
                // string str = "SELECT ROW_NUMBER() OVER (ORDER BY xclass) AS xno,xcodealt,xclass,SUM(CASE WHEN xgender='Boy' THEN 1 ELSE 0 END) AS xboy, " +
                //              "SUM(CASE WHEN xgender='Girl' THEN 1 ELSE 0 END) AS xgirl, SUM(CASE WHEN xgender='' THEN 1 ELSE 0 END) AS xblank," +
                //              "SUM(CASE WHEN xgender='Boy' THEN 1 ELSE 0 END + CASE WHEN xgender='Girl' THEN 1 ELSE 0 END + CASE WHEN xgender='' THEN 1 ELSE 0 END) AS xtotal " +
                //              "FROM amadmis INNER JOIN mscodesam on amadmis.zid=mscodesam.zid and mscodesam.xtype='Class' and xclass=xcode WHERE amadmis.zid=@zid AND xexamdate > '01/01/1900' AND xdate1>=@xfrom AND xdate1<=@xto AND coalesce(xstatus2,'') = '' " +
                //              "GROUP BY xcodealt,xclass " +
                //              "ORDER BY xcodealt ";
                // SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                // int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                // //DateTime xfrom1 = DateTime.ParseExact(xfrom.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                // //DateTime xto1 = DateTime.ParseExact(xto.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                // //message.InnerHtml = xfrom1 + " " + xto1;
                // da.SelectCommand.Parameters.Add("@zid", _zid);
                // //da.SelectCommand.Parameters.Add("@xfrom", xfrom1);
                // //da.SelectCommand.Parameters.Add("@xto", xto1);
                // da.Fill(dts, "tempztcode");
                // //DataView dv = new DataView(dts.Tables[0]);
                // DataTable dtztcode = new DataTable();
                // dtztcode = dts.Tables[0];
                // _grid_emp.DataSource = dtztcode;
                // _grid_emp.DataBind();

                // //int totboy = dtztcode.AsEnumerable().Sum(row => row.Field<int>("xboy"));
                // //int totgirl = dtztcode.AsEnumerable().Sum(row => row.Field<int>("xgirl"));
                // //int total = dtztcode.AsEnumerable().Sum(row => row.Field<int>("xtotal"));
                // //_grid_emp.FooterRow.Cells[1].Text = "Grand Total";
                //// _grid_emp.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                // //_grid_emp.FooterRow.Cells[2].Text = totboy.ToString();
                // //_grid_emp.FooterRow.Cells[3].Text = totgirl.ToString();
                // //_grid_emp.FooterRow.Cells[4].Text = total.ToString();

                // dts.Dispose();
                // dtztcode.Dispose();
                // da.Dispose();
                // conn1.Dispose();
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
        private void BindGrid(int year1, int month1)
        {
            if (ViewState["xrow"] == null)
            {
                message.InnerHtml = "No data found.";
                message.Style.Value = zglobal.am_warningmsg;
                return;
            }
           
            //if (year1 == 1999 && month1 == 1)
            //{
            //    ViewState["check"] = "1";
            //}
            //else
            //{
            //    ViewState["check"] = "0";
            //}

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
            bfield.HtmlEncode = false;
            GridView1.Columns.Add(bfield); ;

            bfield = new BoundField();
            bfield.HeaderText = "Sec";
            bfield.DataField = "xsection";
            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfield.ItemStyle.Width = 10;
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
                    GridView1.Columns.Add(tfield);
                    rowCount = rowCount + 1;
                }

                ViewState["rowCount"] = rowCount;

            }


            BoundField bfield1 = new BoundField();
            // bfield1.HeaderText = "";
            bfield1.DataField = "xdate1";
            bfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfield1.ItemStyle.Width = 50;
            //bfield.Visible = false;
            GridView1.Columns.Add(bfield1);

            BoundField bfield2 = new BoundField();
            // bfield2.HeaderText = "";
            bfield2.DataField = "xsection1";
            bfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfield2.ItemStyle.Width = 50;
            //bfield.Visible = false;
            GridView1.Columns.Add(bfield2);

            //BoundField bfield3 = new BoundField();
            //// bfield3.HeaderText = "";
            //bfield3.DataField = "xcellno";
            //bfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //bfield3.ItemStyle.Width = 50;
            ////bfield.Visible = false;
            //GridView1.Columns.Add(bfield3);


            GridView1.DataSource = dt;
            GridView1.DataBind();

            bfield1.Visible = false;
            bfield2.Visible = false;
            //bfield3.Visible = false;



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

                    GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];

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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //e.Row.BorderColor=Color.Black;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    for (int i = 2; i < 2 + (int)ViewState["rowCount"]; i++)
                    {
                        //DropDownList dwsub = new DropDownList();
                        //// dwsub.Width = 60;
                        //dwsub.Items.Add("");
                        //dwsub.Items.Add("Bangla");
                        //dwsub.Items.Add("English");
                        //dwsub.Items.Add("Maths");
                        //e.Row.Cells[i].Controls.Add(dwsub);
                        //DropDownList dwpap = new DropDownList();
                        //// dwpap.Width = 20;
                        //dwpap.Items.Add("");
                        //dwpap.Items.Add("I");
                        //dwpap.Items.Add("II");
                        //dwpap.Items.Add("III");
                        //e.Row.Cells[i].Controls.Add(dwpap);
                        ////Label lbl = new Label();
                        ////lbl.Text = "Add ";
                        ////lbl.ForeColor = Color.CornflowerBlue;
                        ////e.Row.Cells[i].Controls.Add(lbl);
                        //HtmlGenericControl btn = new HtmlGenericControl("button");
                        //btn.Attributes["type"] = "button";
                        //Label lbl1 = new Label();
                        //lbl1.Text = "-";
                        //btn.Controls.Add(lbl1);
                        //btn.Attributes["style"] = "width: 20px;margin-left:5px;color: #16C1F3;text-align:left;";
                        ////btn.Attributes["class"] = "fa fa-bars";




                        Label lblsub = new Label();
                        lblsub.Text = "";
                        lblsub.ID = "adddetail" + i.ToString();
                        lblsub.ForeColor = Color.Black;
                        lblsub.Attributes.Add("runat", "server");
                        //lnkbtn.Click += OnLinkClick;
                        e.Row.Cells[i].Controls.Add(lblsub);

                        //if (ViewState["xrow"] == null || xdate.Text == "")
                        //{
                        //    lnkbtn.Enabled = false;
                        //}
                        //else
                        //{
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                using (DataSet dts = new DataSet())
                                {
                                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                    int xrow = Convert.ToInt32(ViewState["xrow"]);
                                    DateTime xdate2 = Convert.ToDateTime(e.Row.Cells[2 + (int)ViewState["rowCount"]].Text);
                                    string xperiod2 = GridView1.HeaderRow.Cells[i].Text.ToString();
                                    string xsection2 = e.Row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                                    string query = "SELECT xsubject,xpaper,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
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
                                        if (tempTable.Rows[0][1].ToString() != "" ||
                                            tempTable.Rows[0][1].ToString() != String.Empty)
                                        {
                                            lblsub.Text = tempTable.Rows[0]["xsubject"].ToString() + "-" +
                                                          tempTable.Rows[0]["xpaper"].ToString() + "<br/>" + tempTable.Rows[0]["xcteacher"].ToString();
                                        }
                                        else
                                        {
                                            lblsub.Text = tempTable.Rows[0]["xsubject"].ToString() + "<br/>" + tempTable.Rows[0]["xcteacher"].ToString();
                                        }
                                        //lnkbtn.ForeColor = Color.Black;
                                        //e.Row.Cells[i].BackColor = Color.LightPink;
                                    }


                                    da.Dispose();
                                }
                            }

                            //lblsub.Enabled = true;
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


        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                //System.Threading.Thread.Sleep(1000);
                message.InnerHtml = "";

                //using (SqlConnection connRowConnection = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dtsRowDataSet = new DataSet())
                //    {
                //        string query = "SELECT xrow FROM amexamschh WHERE xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND zid=@zid";

                //        // return query;
                //        SqlDataAdapter daRowValueAdapter = new SqlDataAdapter(query, connRowConnection);
                //        daRowValueAdapter.SelectCommand.Parameters.AddWithValue("@xrow", row);
                //        daRowValueAdapter.Fill(dtsRowDataSet, "tempTable");
                //        DataTable tempTableRowDataTable = new DataTable();
                //        tempTableRowDataTable = dtsRowDataSet.Tables["tempTable"];

                //        value = tempTableRowDataTable.Rows[0][0].ToString();

                //        daRowValueAdapter.Dispose();
                //        dtsRowDataSet.Clear();
                //        tempTableRowDataTable.Dispose();
                //    }
                //}
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xsession1 = xsession.Text.Trim().ToString();
                string xterm1 = xterm.Text.Trim().ToString();
                string xclass1 = xclass.Text.Trim().ToString();
                string xgroup1 = xgroup.Text.Trim().ToString();

                string xrow = zglobal.fnGetValue("xrow", "amexamschh",
                    "zid=" + _zid + " and xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xclass='" + xclass1 +
                    "' and xgroup='" + xgroup1 + "'");
                if (xrow == "")
                {
                    ViewState["xrow"] = null;
                    hiddenxrow.Value = null;
                }
                else
                {
                    ViewState["xrow"] = xrow;
                    hiddenxrow.Value = xrow;
                }

                //GridView1.DataSource = null;
                //GridView1.DataBind();
                //xdate.Text = "";
               // BindGrid(1999, 1);
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
                message.InnerHtml = "";

                //BindGrid(1999, 1);

                if (ViewState["xrow"] == null)
                {
                    message.InnerHtml = "No data found.";
                    message.Style.Value = zglobal.am_warningmsg;
                    return;
                }


                hiddenxdate.Value = xdate.SelectedValue.ToString();


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
                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    zglobal.fnGetComboDataCalendar(xdate);

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    //BindGrid(1999, 1);
                    
                }


                
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }

     

       


        
    }
}