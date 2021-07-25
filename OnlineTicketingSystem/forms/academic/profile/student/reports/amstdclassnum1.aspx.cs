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
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class amstdclassnum1 : System.Web.UI.Page
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
            //try
            //{
            //    message.InnerHtml = "";
            //    //result.Visible = false;
            //    //barchart.Visible = false;
            //    //if (ViewState["msg"].ToString() != "1")
            //    //{
            //    //    btnApprove.Visible = true;
            //    //    btnSave.Visible = true;
            //    //}



            //    BindGrid();

               
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}

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

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();


            //dts.Reset();
            //string str = "SELECT xcodealt,xclass, xprevious, xpromoted, xyeardrop, xwithoutpayment, xreadmis, xnew, xdropout, xtotal " +
            //             "FROM amnumstudentvw1  " +
            //             "WHERE zid=@zid AND xsession = @xsession " +
            //             "ORDER BY xcodealt ";

            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

          
            ////message.InnerHtml = xfrom1 + " " + xto1;
            //da.SelectCommand.Parameters.Add("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //da.Fill(dts, "tempztcode");
            ////DataView dv = new DataView(dts.Tables[0]);
            //DataTable dtztcode = new DataTable();
            //dtztcode = dts.Tables[0];
            //GridView1.DataSource = dtztcode;
            //GridView1.DataBind();

          

            //dts.Dispose();
            //dtztcode.Dispose();
            //da.Dispose();
            //conn1.Dispose();

            ////using (SqlConnection con = new SqlConnection(zglobal.constring))
            ////{
            ////    using (DataSet dts1 = new DataSet())
            ////    {
            ////        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            ////        //string query =
            ////        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            ////        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            ////        string query =
            ////       "SELECT  xsession,xprevious, xreadmis, xnew, xtotal " +
            ////             "FROM amnumstudentvw2 as b  " +
            ////             "WHERE zid=@zid AND xsession in(select top 2 xsession from amnumstudentvw2 as a where zid=b.zid and xsession<=@xsession order by xsession desc)" ;

            ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());

            ////        da1.Fill(dts1, "tempztcode");
            ////        DataTable dtamexamd = new DataTable();
            ////        dtamexamd = dts1.Tables[0];

            ////        if (dtamexamd.Rows.Count > 0)
            ////        {
            ////            Chart1.DataSource = dtamexamd;
            ////            Chart1.DataBind();
            ////        }
            ////        else
            ////        {
            ////            Chart1.DataSource = null;
            ////            Chart1.DataBind();
            ////        }

            ////    }
            ////}

            ////using (SqlConnection con = new SqlConnection(zglobal.constring))
            ////{
            ////    using (DataSet dts1 = new DataSet())
            ////    {
            ////        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
            ////        //string query =
            ////        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
            ////        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

            ////        string query =
            ////       "SELECT  xprevious, xreadmis, xnew, xtotal " +
            ////             "FROM amnumstudentvw2   " +
            ////             "WHERE zid=@zid AND xsession =@xsession";

            ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());

            ////        da1.Fill(dts1, "tempztcode");
            ////        DataTable dtamexamd = new DataTable();
            ////        dtamexamd = dts1.Tables[0];

            ////        if (dtamexamd.Rows.Count > 0)
            ////        {
            ////            DataTable dt = new DataTable();
            ////            dt.Columns.Add("key",typeof(string));
            ////            dt.Columns.Add("value", typeof (int));

            ////            //for (int i = 0; i < dt.Columns.Count; i++)
            ////            //{
            ////            dt.Rows.Add("Last Session", Convert.ToInt32(dtamexamd.Rows[0]["xprevious"].ToString()));
            ////                dt.Rows.Add("Re-Admission", Convert.ToInt32(dtamexamd.Rows[0]["xreadmis"].ToString()));
            ////                dt.Rows.Add("New", Convert.ToInt32(dtamexamd.Rows[0]["xnew"].ToString()));
            ////                dt.Rows.Add("Total", Convert.ToInt32(dtamexamd.Rows[0]["xtotal"].ToString()));
            ////            //}

            ////                string[] XPointMember = new string[dt.Rows.Count];
            ////                int[] YPointMember = new int[dt.Rows.Count];

            ////                for (int count = 0; count < dt.Rows.Count; count++)
            ////                {
            ////                    //storing Values for X axis  
            ////                    XPointMember[count] = dt.Rows[count]["key"].ToString();
            ////                    //storing values for Y Axis  
            ////                    YPointMember[count] = Convert.ToInt32(dt.Rows[count]["value"]);

            ////                }

            ////                //binding chart control  
            ////                Chart2.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            ////                //Setting width of line  
            ////                //Chart2.Series[0].BorderWidth = 10;
            ////                //setting Chart type   
            ////                Chart2.Series[0].ChartType = SeriesChartType.Pie;
            ////                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true; 

            ////                foreach (Series charts in Chart2.Series)
            ////                {
            ////                    foreach (DataPoint point in charts.Points)
            ////                    {
            ////                        switch (point.AxisLabel)
            ////                        {
            ////                            case "Last Session": point.Color = Color.RoyalBlue; break;
            ////                            case "Re-Admission": point.Color = Color.SaddleBrown; break;
            ////                            case "New": point.Color = Color.SpringGreen; break;
            ////                            case "Total": point.Color = Color.ForestGreen; break;
            ////                        }
            ////                        //point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);
            ////                        point.Label = string.Format("{0}", point.AxisLabel);

            ////                    }
            ////                }     

            ////            //Chart2.DataSource = dt;
            ////            //Chart2.DataBind();
            ////        }
            ////        else
            ////        {
            ////            Chart2.DataSource = null;
            ////            Chart2.DataBind();
            ////        }

            ////    }
            ////}

            
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (GridView1.DataSource == null)
            //    {
            //        return;
            //    }




                



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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        xprevious += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xprevious"));
            //        xreadmis += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xreadmis"));
            //        xnew += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xnew"));
            //        xtotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xtotal"));
            //    }
            //    if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        e.Row.Cells[1].Text = "Grand Total :";
            //        e.Row.Cells[1].Font.Bold = true;
            //        e.Row.Cells[1].ForeColor = Color.White;


            //        e.Row.Cells[2].Text = xprevious.ToString();
            //        e.Row.Cells[2].Font.Bold = true;
            //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            //        e.Row.Cells[2].ForeColor = Color.White;

            //        e.Row.Cells[3].Text = xreadmis.ToString();
            //        e.Row.Cells[3].Font.Bold = true;
            //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //        e.Row.Cells[3].ForeColor = Color.White;

            //        e.Row.Cells[4].Text = xnew.ToString();
            //        e.Row.Cells[4].Font.Bold = true;
            //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            //        e.Row.Cells[4].ForeColor = Color.White;

            //        e.Row.Cells[5].Text = xtotal.ToString();
            //        e.Row.Cells[5].Font.Bold = true;
            //        e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            //        e.Row.Cells[5].ForeColor = Color.White;
            //    }
            
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
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


                    DataTable dummy = new DataTable();
                    dummy.Columns.Add("");
                    dummy.Columns.Add("xclass");
                    dummy.Columns.Add("xprevious");
                    dummy.Columns.Add("xpromoted");
                    dummy.Columns.Add("xyeardrop");
                    dummy.Columns.Add("xwithoutpayment");
                    dummy.Columns.Add("xreadmis");
                    dummy.Columns.Add("xnew");
                    dummy.Columns.Add("xdropout");
                    dummy.Columns.Add("xtotal");
                    dummy.Rows.Add();
                    GridView1.DataSource = dummy;
                    GridView1.DataBind();
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
                    cmd.CommandText = "SELECT xcodealt,xclass, xprevious, xpromoted, xyeardrop, xwithoutpayment, xreadmis, xnew, xdropout, xtotal " +
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
                   cmd.CommandText = "SELECT xprevious, xpromoted, xyeardrop, xwithoutpayment, xreadmis, xnew, xdropout, xtotal " +
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

       [WebMethod]
       public static string GetDropout(string xsession)
       {

           using (SqlConnection con = new SqlConnection(zglobal.constring))
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.CommandText = "select sum(xboy) as xboy,sum(xgirl) as xgirl from amstdstrength " +
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

       [WebMethod]
       public static string GetBoyGirl(string xsession)
       {

           using (SqlConnection con = new SqlConnection(zglobal.constring))
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.CommandText = "select sum(xboy) as xboy,sum(xgirl) as xgirl from amstdstrength " +
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


       [WebMethod]
       public static string GetChart(string xsession)
       {
           
           using (SqlConnection con = new SqlConnection(zglobal.constring))
           {
               string query = "SELECT xprevious, xpromoted, xyeardrop, xwithoutpayment, xreadmis, xnew, xdropout, xtotal " +
                        "FROM amnumstudentvw2  " +
                        "WHERE zid=@zid AND xsession = @xsession ";
               int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.CommandText = query;
                   cmd.CommandType = CommandType.Text;
                   cmd.Connection = con;
                   cmd.Parameters.AddWithValue("@zid", _zid);
                   cmd.Parameters.AddWithValue("@xsession", xsession);
                   con.Open();
                   using (SqlDataReader sdr = cmd.ExecuteReader())
                   {
                       StringBuilder sb = new StringBuilder();
                       sb.Append("[");
                       while (sdr.Read())
                       {
                           sb.Append("{");
                           //sb.Append(string.Format("new :'{0}', readmis:{1}", sdr["xnew"], sdr["xreadmis"]));
                           sb.Append(string.Format("text :'New', value:{0}", sdr["xnew"]));
                           sb.Append(string.Format("text :'Readmission', value:{0}", sdr["xreadmis"]));
                           sb.Append("},");
                       }
                       sb = sb.Remove(sb.Length - 1, 1);
                       sb.Append("]");
                       con.Close();
                       return sb.ToString();
                   }
               }
           }
       }

       [WebMethod(EnableSession = true)]
       public static string fnFetchData(string xsession1)
       {
           try
           {

               int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



               using (SqlConnection con = new SqlConnection(zglobal.constring))
               {
                   using (DataSet dts1 = new DataSet())
                   {
                       string query = "select xschool,sum(xtotal) as xtotal from amstdstrength where xsession=@xsession group by xschool ";

                       SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                       da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                       da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);

                       da1.Fill(dts1, "tempztcode");
                       DataTable dtamexamd = new DataTable();
                       dtamexamd = dts1.Tables[0];
                       if (dtamexamd.Rows.Count > 0)
                       {
                           string xschool = "";
                           string xtotal = "";

                           for (int i = 0; i < dtamexamd.Rows.Count; i++)
                           {
                               if (i == dtamexamd.Rows.Count - 1)
                               {
                                   xschool = xschool + dtamexamd.Rows[i]["xschool"].ToString();
                                   xtotal = xtotal + dtamexamd.Rows[i]["xtotal"].ToString();
                               }
                               else
                               {
                                   xschool = xschool + dtamexamd.Rows[i]["xschool"].ToString() + ",";
                                   xtotal = xtotal + dtamexamd.Rows[i]["xtotal"].ToString() + ",";
                               }
                           }

                           return "success" + "|" + xschool + "|" + xtotal;
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


    }
}