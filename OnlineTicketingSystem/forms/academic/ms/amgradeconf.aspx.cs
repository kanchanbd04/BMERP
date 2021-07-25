using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.admission
{
    public partial class amgradeconf : System.Web.UI.Page
    {

        public string xtype1 = "";
        public string zid1 = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //xtype1 = Request.QueryString["xtype"];
                //xtype2.Value = xtype1;
                ////header_label.InnerHtml = "CODES : " + xtype1;
                ////xtype.InnerHtml = xtype1;
                //if (!IsPostBack)
                //{

                //    //TabContainer1.ActiveTabIndex = 0;
                //    //fnGridVisibleProp("_grid_day_o");
                //    _gridrow.Text = zglobal._grid_row_value;
                //    fnFillDataGrid();
                //    zactive.Checked = true;
                //    zemail.InnerHtml = "";
                //    xemail.InnerHtml = "";
                //}
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
                //message.InnerHtml = "";
                //zemail.InnerHtml = "";
                //xemail.InnerHtml = "";
                //xtype.InnerHtml = xtype1;
                //xcode.Text = "";
                //xdescdet.Value = "";
                //xcodealt.Text = "";
                //xprops.Value = "";
                //key.Value = "";
                //_searchbox.Text = "";
                //zactive.Checked = true;
                //fnFillDataGrid();
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
                //string xkey = "";

                //if (xcode.Text == "" || xcode.Text == string.Empty)
                //{
                //    message.InnerHtml = "Must be enter a code.";
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}

                //using (TransactionScope tran = new TransactionScope())
                //{
                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {
                //        conn.Open();
                //        SqlCommand cmd = new SqlCommand();
                //        cmd.Connection = conn;
                //        string query = "INSERT INTO mscodesam (ztime,zid,xtype,xcode,xdescdet,xprops,xcodealt,zactive,zemail) " +
                //                       "VALUES(@ztime,@zid,@xtype,@xcode,@xdescdet,@xprops,@xcodealt,@zactive,@zemail) ";
                //        DateTime ztime = DateTime.Now;
                //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //        string xcode1 = xcode.Text.ToString().Trim();
                //        xkey = xcode1;
                //        string xdescdet1 = xdescdet.Value.ToString().Trim();
                //        string xcodealt1 = xcodealt.Text.ToString().Trim();
                //        string xprops1 = xprops.Value.ToString().Trim();
                //        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //        int zactive1 = zactive.Checked ? 1 : 0;
                //        cmd.CommandText = query;
                //        cmd.Parameters.AddWithValue("@ztime", ztime);
                //        cmd.Parameters.AddWithValue("@zid", _zid);
                //        cmd.Parameters.AddWithValue("@xtype", xtype1);
                //        cmd.Parameters.AddWithValue("@xcode", xcode1);
                //        cmd.Parameters.AddWithValue("@xdescdet", xdescdet1);
                //        cmd.Parameters.AddWithValue("@xprops", xprops1);
                //        cmd.Parameters.AddWithValue("@xcodealt", xcodealt1);
                //        cmd.Parameters.AddWithValue("@zactive", zactive1);
                //        cmd.Parameters.AddWithValue("@zemail", zemail1);
                //        cmd.ExecuteNonQuery();
                        
                //    }

                //    fnFillDataGrid();
                //    zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                //    tran.Complete();


                //}
                //message.InnerHtml = zglobal.insertsuccmsg;
                //message.Style.Value = zglobal.successmsg;
                //key.Value = xkey;
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

                //if (xcode.Text == "" || xcode.Text == string.Empty)
                //{
                //    message.InnerHtml = "Select Code from list";
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}

                //using (TransactionScope tran = new TransactionScope())
                //{
                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {
                //        conn.Open();
                //        SqlCommand cmd = new SqlCommand();
                //        cmd.Connection = conn;
                //        string query = "UPDATE mscodesam SET zutime=@zutime,xdescdet=@xdescdet,xprops=@xprops,xcodealt=@xcodealt,xemail=@xemail,zactive=@zactive " +
                //                           "WHERE xtype=@xtype and xcode=@xcode and zid=@zid ";
                //        DateTime ztime = DateTime.Now;
                //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //        string xcode1 = xcode.Text.ToString().Trim();
                //        string xdescdet1 = xdescdet.Value.ToString().Trim();
                //        string xcodealt1 = xcodealt.Text.ToString().Trim();
                //        string xprops1 = xprops.Value.ToString().Trim();
                //        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //        int zactive1 = zactive.Checked ? 1 : 0;
                //        cmd.CommandText = query;
                //        cmd.Parameters.AddWithValue("@zutime", ztime);
                //        cmd.Parameters.AddWithValue("@zid", _zid);
                //        cmd.Parameters.AddWithValue("@xtype", xtype1);
                //        cmd.Parameters.AddWithValue("@xcode", xcode1);
                //        cmd.Parameters.AddWithValue("@xdescdet", xdescdet1);
                //        cmd.Parameters.AddWithValue("@xprops", xprops1);
                //        cmd.Parameters.AddWithValue("@xcodealt", xcodealt1);
                //        cmd.Parameters.AddWithValue("@zactive", zactive1);
                //        cmd.Parameters.AddWithValue("@xemail", zemail1);
                //        cmd.ExecuteNonQuery();

                //    }

                //    fnFillDataGrid();
                //    xemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                //    tran.Complete();


                //}
                //message.InnerHtml = zglobal.updatesuccmsg;
                //message.Style.Value = zglobal.successmsg;
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
                //SqlConnection conn1;
                //conn1 = new SqlConnection(zglobal.constring);
                //DataSet dts = new DataSet();

                //dts.Reset();

                //string xcode1 = ((LinkButton)sender).Text;
                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //string str = "SELECT * FROM mscodesam WHERE xtype=@xtype and xcode=@xcode and zid=@zid";
                //SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                //da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
                //da.SelectCommand.Parameters.AddWithValue("@xcode", ((LinkButton)sender).Text);
                //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //da.Fill(dts, "tempztcode");
                //DataTable dtztcode = new DataTable();
                //dtztcode = dts.Tables[0];

                //xtype.InnerHtml = dtztcode.Rows[0]["xtype"].ToString();
                //xcode.Text = dtztcode.Rows[0]["xcode"].ToString();
                //xdescdet.Value = dtztcode.Rows[0]["xdescdet"].ToString();
                //xcodealt.Text = dtztcode.Rows[0]["xcodealt"].ToString();
                //xprops.Value = dtztcode.Rows[0]["xprops"].ToString();
                //zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                //zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
                //xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();
                

                //dts.Dispose();
                //dtztcode.Dispose();
                //da.Dispose();
                //conn1.Dispose();
                //key.Value = ((LinkButton)sender).Text;
                //message.InnerHtml = "";

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        public void fnFillDataGrid()
        {

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            ////int _row = Convert.ToInt32(_gridrow.Text);
            //dts.Reset();
            //string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtype,xcode,xdescdet,xprops,xcodealt,zactive FROM mscodesam where xtype=@xtype and zid=@zid ORDER BY xtype,xcode";
            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////da.SelectCommand.Parameters.AddWithValue("@row", _row);
            //da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
            ////da.SelectCommand.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
            //da.Fill(dts, "tempztcode");
            ////DataView dv = new DataView(dts.Tables[0]);
            //DataTable dtztcode = new DataTable();
            //dtztcode = dts.Tables[0];
            //_grid_codes.DataSource = dtztcode;
            //_grid_codes.DataBind();





            //dts.Dispose();
            //dtztcode.Dispose();
            //da.Dispose();
            //conn1.Dispose();
        }


        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn1;
                //conn1 = new SqlConnection(zglobal.constring);
                //DataSet dts = new DataSet();

                //int _row = Convert.ToInt32(_gridrow.Text);
                //dts.Reset();
                //string str = "SELECT TOP @row xtype,xcode,xdescdet,xprops,xcodealt,zactive FROM mscodesam where xtype=@xtype and zid=@zid ORDER BY xtype,xcode";
                //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //da.SelectCommand.Parameters.AddWithValue("@row", _row);
                //da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
                ////da.SelectCommand.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
                //da.Fill(dts, "tempztcode");
                ////DataView dv = new DataView(dts.Tables[0]);
                //DataTable dtztcode = new DataTable();
                //dtztcode = dts.Tables[0];
                //_grid_codes.DataSource = dtztcode;
                //_grid_codes.DataBind();





                //dts.Dispose();
                //dtztcode.Dispose();
                //da.Dispose();
                //conn1.Dispose();
                fnFillDataGrid();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


    }
}