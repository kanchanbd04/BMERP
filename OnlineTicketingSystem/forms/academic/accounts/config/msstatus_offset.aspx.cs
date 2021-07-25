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
    public partial class msstatus_offset : System.Web.UI.Page
    {

        public string xtypestatus1 = "";
        public string zid1 = "";
        public string xaction1 = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //xtypestatus1 = Request.QueryString["xtypestatus"];
                //xaction1 = Request.QueryString["xaction"];
                //xtype2.Value = xtypestatus1;
                header_label.InnerHtml = "Set Period Offset";
                xtypestatus.InnerHtml = "GL Period Offset";
                xtypestatus1 = "GL Period Offset";
                if (!IsPostBack)
                {

                    //TabContainer1.ActiveTabIndex = 0;
                    //fnGridVisibleProp("_grid_day_o");
                    //_gridrow.Text = zglobal._grid_row_value;
                    //fnFillDataGrid();
                    //zactive.Checked = true;
                    //zemail.InnerHtml = "";
                    //xemail.InnerHtml = "";

                    //zglobal.fnGetComboDataCDWithValue(xaction1, xaction);

                    //xaction.Items.Add(new ListItem("", ""));
                    //xaction.Items.Add(new ListItem("Issue", "Issue"));
                    //xaction.Items.Add(new ListItem("Receipt", "Receipt"));
                    //xaction.SelectedValue = "";

                    //xnum.Text = "0";
                    //xinc.Text = "1";
                    //xinteger.Text = "0";

                    fnGetOffset();
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        private void fnGetOffset()
        {
          


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string str = "SELECT coalesce(xinteger,0) as xinteger FROM msstatus WHERE xtypestatus=@xtypestatus and zid=@zid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            da.SelectCommand.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.Fill(dts, "tempztcode");
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                xinteger.Text = dtztcode.Rows[0]["xinteger"].ToString();
            }
            else
            {
                xinteger.Text = "0";
            }




            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();

           
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                
                xtypestatus.InnerHtml = xtypestatus1;

                fnGetOffset();
                //key.Value = "";
             
                //_searchbox.Text = "";
              
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
                string xkey = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xinteger.Text == "" || xinteger.Text == string.Empty || xinteger.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Period Offset</li>";
                    isValid = false;
                }
                //if (xaction.Text == "" || xaction.Text == string.Empty || xaction.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Action Code</li>";
                //    isValid = false;
                //}

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";

                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        int xinteger1 = Convert.ToInt32(xinteger.Text.Trim().ToString());

                        query = "DELETE FROM msstatus WHERE xtypestatus=@xtypestatus and zid=@zid";

                        cmd.CommandText = query;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
                        cmd.ExecuteNonQuery();

                        query = "INSERT INTO msstatus (ztime,zid,xtypestatus,xinteger,xdate) " +
                                       "VALUES(@ztime,@zid,@xtypestatus,@xinteger,@xdate) ";
                        
                        cmd.CommandText = query;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
                        cmd.Parameters.AddWithValue("@xinteger", xinteger1);
                        cmd.Parameters.AddWithValue("@xdate", ztime);
                        cmd.ExecuteNonQuery();

                    }

                   
                    tran.Complete();

                  
                }
                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;
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
            //try
            //{

            //    bool isValid = true;
            //    string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
            //    if (xinteger.Text == "" || xinteger.Text == string.Empty || xinteger.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Period Offset</li>";
            //        isValid = false;
            //    }
            //    //if (xaction.Text == "" || xaction.Text == string.Empty || xaction.Text == "[Select]")
            //    //{
            //    //    rtnMessage = rtnMessage + "<li>Action Code</li>";
            //    //    isValid = false;
            //    //}

            //    rtnMessage = rtnMessage + "</ol></div>";
            //    if (!isValid)
            //    {
            //        message.InnerHtml = rtnMessage;
            //        message.Style.Value = zglobal.warningmsg;
            //        return;
            //    }


            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            conn.Open();
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;
            //            string query = "UPDATE msstatus SET zutime=@zutime,xinteger=@xinteger,xdate=@xdate " +
            //                               "WHERE xtypestatus=@xtypestatus and zid=@zid ";
            //            DateTime ztime = DateTime.Now;
            //            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //            int xinteger1 = Convert.ToInt32(xinteger.Text.Trim().ToString());

            //            cmd.CommandText = query;
            //            cmd.Parameters.AddWithValue("@zutime", ztime);
            //            cmd.Parameters.AddWithValue("@zid", _zid);
            //            cmd.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            //            cmd.Parameters.AddWithValue("@xinteger", xinteger1);
            //            cmd.Parameters.AddWithValue("@xdate", ztime);
            //            cmd.ExecuteNonQuery();

            //        }

                   
            //        tran.Complete();
                    

            //    }
            //    message.InnerHtml = zglobal.updatesuccmsg;
            //    message.Style.Value = zglobal.successmsg;
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        protected void FillControls(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    DataSet dts = new DataSet();

            //    dts.Reset();

            //    string xcode1 = ((LinkButton)sender).Text;
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    string str = "SELECT * FROM mstrn WHERE xtypestatus=@xtypestatus and xtrn=@xtrn and zid=@zid";
            //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            //    da.SelectCommand.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            //    da.SelectCommand.Parameters.AddWithValue("@xtrn", ((LinkButton)sender).Text);
            //    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    da.Fill(dts, "tempztcode");
            //    DataTable dtztcode = new DataTable();
            //    dtztcode = dts.Tables[0];

            //    xtypestatus.InnerHtml = dtztcode.Rows[0]["xtypestatus"].ToString();
            //    xtrn.Text = dtztcode.Rows[0]["xtrn"].ToString();
            //    xaction.SelectedValue = dtztcode.Rows[0]["xaction"].ToString();
            //    xdesc.Text = dtztcode.Rows[0]["xdesc"].ToString();
            //    xnum.Text = dtztcode.Rows[0]["xnum"].ToString();
            //    xinc.Text = dtztcode.Rows[0]["xinc"].ToString();
            //    zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
            //    zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
            //    xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();


            //    dts.Dispose();
            //    dtztcode.Dispose();
            //    da.Dispose();
            //    conn1.Dispose();
            //    key.Value = ((LinkButton)sender).Text;
            //    message.InnerHtml = "";

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        public void fnFillDataGrid()
        {

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            ////int _row = Convert.ToInt32(_gridrow.Text);
            //dts.Reset();
            ////string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtypestatus,xtrn,(select xdescdet from mscodesam where zid=mstrn.zid and xtype=@xtype and xcode=mstrn.xaction) as xaction,xdesc,xnum,xinc,zactive FROM mstrn where xtypestatus=@xtypestatus and zid=@zid ORDER BY ztime"; //ORDER BY xtype,xcode
            //string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtypestatus,xtrn,xaction,xdesc,xnum,xinc,zactive FROM mstrn where xtypestatus=@xtypestatus and zid=@zid ORDER BY ztime"; //ORDER BY xtype,xcode
            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////da.SelectCommand.Parameters.AddWithValue("@row", _row);
            //da.SelectCommand.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            //da.SelectCommand.Parameters.AddWithValue("@xtype", xaction1);
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