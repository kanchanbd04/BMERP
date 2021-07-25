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
    public partial class mstran : System.Web.UI.Page
    {

        public string xtypetrn1 = "";
        public string zid1 = "";
        public string xaction1 = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                xtypetrn1 = Request.QueryString["xtypetrn"];
                xaction1 = Request.QueryString["xaction"];
                xtype2.Value = xtypetrn1;
                header_label.InnerHtml = "Transaction Type : " + xtypetrn1;
                xtypetrn.InnerHtml = xtypetrn1;
                if (!IsPostBack)
                {

                    //TabContainer1.ActiveTabIndex = 0;
                    //fnGridVisibleProp("_grid_day_o");
                    _gridrow.Text = zglobal._grid_row_value;
                    fnFillDataGrid();
                    zactive.Checked = true;
                    zemail.InnerHtml = "";
                    xemail.InnerHtml = "";

                    zglobal.fnGetComboDataCDWithValue(xaction1, xaction);

                    //xaction.Items.Add(new ListItem("", ""));
                    //xaction.Items.Add(new ListItem("Issue", "Issue"));
                    //xaction.Items.Add(new ListItem("Receipt", "Receipt"));
                    //xaction.SelectedValue = "";

                    xnum.Text = "0";
                    xinc.Text = "1";
                }
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
                message.InnerHtml = "";
                zemail.InnerHtml = "";
                xemail.InnerHtml = "";
                xtypetrn.InnerHtml = xtypetrn1;
                xtrn.Text = "";
                xaction.SelectedValue = "";
                xdesc.Text = "";
                xnum.Text = "";
                xinc.Text = "";
                key.Value = "";
                xnum.Text = "0";
                xinc.Text = "1";
                _searchbox.Text = "";
                zactive.Checked = true;
                fnFillDataGrid();
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
                if (xtrn.Text == "" || xtrn.Text == string.Empty || xtrn.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Transaction Code</li>";
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
                        string query = "INSERT INTO mstrn (ztime,zid,xtypetrn,xtrn,xaction,xdesc,xnum,xinc,zactive,zemail) " +
                                       "VALUES(@ztime,@zid,@xtypetrn,@xtrn,@xaction,@xdesc,@xnum,@xinc,@zactive,@zemail) ";
                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        string xtrn1 = xtrn.Text.ToString().Trim();
                        xkey = xtrn1;
                        string xaction11 = xaction.SelectedValue.ToString().Trim();
                        string xdesc1 = xdesc.Text.ToString().Trim();
                        int xnum1 = Convert.ToInt32(xnum.Text.ToString().Trim());
                        int xinc1 = Convert.ToInt32(xinc.Text.ToString().Trim());
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        int zactive1 = zactive.Checked ? 1 : 0;
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
                        cmd.Parameters.AddWithValue("@xtrn", xtrn1);
                        cmd.Parameters.AddWithValue("@xaction", xaction11);
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                        cmd.Parameters.AddWithValue("@xnum", xnum1);
                        cmd.Parameters.AddWithValue("@xinc", xinc1);
                        cmd.Parameters.AddWithValue("@zactive", zactive1);
                        cmd.Parameters.AddWithValue("@zemail", zemail1);
                        cmd.ExecuteNonQuery();

                    }

                    fnFillDataGrid();
                    zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();

                  
                }
                message.InnerHtml = zglobal.insertsuccmsg;
                message.Style.Value = zglobal.successmsg;
                key.Value = xkey;
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

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xtrn.Text == "" || xtrn.Text == string.Empty || xtrn.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Transaction Code</li>";
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
                        string query = "UPDATE mstrn SET zutime=@zutime,xaction=@xaction,xdesc=@xdesc,xnum=@xnum,xinc=@xinc,xemail=@xemail,zactive=@zactive " +
                                           "WHERE xtypetrn=@xtypetrn and xtrn=@xtrn and zid=@zid ";
                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        string xtrn1 = xtrn.Text.ToString().Trim();
                        string xaction11 = xaction.SelectedValue.ToString().Trim();
                        string xdesc1 = xdesc.Text.ToString().Trim();
                        int xnum1 = Convert.ToInt32(xnum.Text.ToString().Trim());
                        int xinc1 = Convert.ToInt32(xinc.Text.ToString().Trim());
                        string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        int zactive1 = zactive.Checked ? 1 : 0;

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
                        cmd.Parameters.AddWithValue("@xtrn", xtrn1);
                        cmd.Parameters.AddWithValue("@xaction", xaction11);
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                        cmd.Parameters.AddWithValue("@xnum", xnum1);
                        cmd.Parameters.AddWithValue("@xinc", xinc1);
                        cmd.Parameters.AddWithValue("@zactive", zactive1);
                        cmd.Parameters.AddWithValue("@xemail", xemail1);
                        cmd.ExecuteNonQuery();

                    }

                    fnFillDataGrid();
                    xemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();
                    

                }
                message.InnerHtml = zglobal.updatesuccmsg;
                message.Style.Value = zglobal.successmsg;
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
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xcode1 = ((LinkButton)sender).Text;
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string str = "SELECT * FROM mstrn WHERE xtypetrn=@xtypetrn and xtrn=@xtrn and zid=@zid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
                da.SelectCommand.Parameters.AddWithValue("@xtrn", ((LinkButton)sender).Text);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xtypetrn.InnerHtml = dtztcode.Rows[0]["xtypetrn"].ToString();
                xtrn.Text = dtztcode.Rows[0]["xtrn"].ToString();
                xaction.SelectedValue = dtztcode.Rows[0]["xaction"].ToString();
                xdesc.Text = dtztcode.Rows[0]["xdesc"].ToString();
                xnum.Text = dtztcode.Rows[0]["xnum"].ToString();
                xinc.Text = dtztcode.Rows[0]["xinc"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
                xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();


                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                key.Value = ((LinkButton)sender).Text;
                message.InnerHtml = "";

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            //int _row = Convert.ToInt32(_gridrow.Text);
            dts.Reset();
            //string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtypetrn,xtrn,(select xdescdet from mscodesam where zid=mstrn.zid and xtype=@xtype and xcode=mstrn.xaction) as xaction,xdesc,xnum,xinc,zactive FROM mstrn where xtypetrn=@xtypetrn and zid=@zid ORDER BY ztime"; //ORDER BY xtype,xcode
            string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtypetrn,xtrn,xaction,xdesc,xnum,xinc,zactive FROM mstrn where xtypetrn=@xtypetrn and zid=@zid ORDER BY ztime"; //ORDER BY xtype,xcode
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@row", _row);
            da.SelectCommand.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
            da.SelectCommand.Parameters.AddWithValue("@xtype", xaction1);
            //da.SelectCommand.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            _grid_codes.DataSource = dtztcode;
            _grid_codes.DataBind();





            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();
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