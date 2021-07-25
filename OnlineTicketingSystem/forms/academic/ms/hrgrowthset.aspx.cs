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
    public partial class hrgrowthset : System.Web.UI.Page
    {

        public string xtype1 = "";
        public string zid1 = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Stages Category", xcat);
                    zglobal.fnGetComboDataCD("Stages Type", xtype0);
                    xcat.Items.RemoveAt(0);
                    xtype0.Items.RemoveAt(0);
                    _gridrow.Text = zglobal._grid_row_value;
                    fnFillDataGrid();
                    zactive.Checked = true;
                    zemail.InnerHtml = "";
                    xemail.InnerHtml = "";
                    xrow.InnerHtml = "";
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
                xrow.InnerHtml = "";
                xline.Text = "";
                xdesc.Value = "";
               

                key.Value = "";
                _searchbox.Text = "";
                zactive.Checked = true;
                fnFillDataGrid();
                btnSave.Enabled = true;
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
                int xkey;

                if (xdesc.Value == "" || xdesc.Value == string.Empty)
                {
                    message.InnerHtml = "Must be enter a description.";
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
                        string query = "INSERT INTO hrgrowthset (ztime,zid,xrow,xline,xdesc,xcat,xtype,zactive,zemail) " +
                                       "VALUES(@ztime,@zid,@xrow,@xline,@xdesc,@xcat,@xtype,@zactive,@zemail) ";
                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        int xrow1 = zglobal.GetMaximumIdInt("xrow", "hrgrowthset", " zid=" + _zid, 1, 1);
                        xkey = xrow1;
                        int xline1 = Int32.Parse(xline.Text.Trim().ToString());
                        string xtype1 = xtype0.SelectedValue.ToString().Trim();
                        string xcat1 = xcat.SelectedValue.ToString().Trim();
                        string xdesc1 = xdesc.Value.ToString().Trim();
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        int zactive1 = zactive.Checked ? 1 : 0;
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", xrow1);
                        cmd.Parameters.AddWithValue("@xline", xline1);
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                        cmd.Parameters.AddWithValue("@xcat", xcat1);
                        cmd.Parameters.AddWithValue("@xtype", xtype1);
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
                key.Value = xkey.ToString();
                xrow.InnerHtml = key.Value;
                btnSave.Enabled = false;
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

                if (xdesc.Value == "" || xdesc.Value == string.Empty)
                {
                    message.InnerHtml = "Must be enter a description.";
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
                        string query = "UPDATE hrgrowthset SET zutime=@zutime,xline=@xline,xdesc=@xdesc,xcat=@xcat,xtype=@xtype,xemail=@xemail,zactive=@zactive " +
                                           "WHERE xrow=@xrow and zid=@zid ";
                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        int xrow1 = int.Parse(key.Value);
                        int xline1 = Int32.Parse(xline.Text.Trim().ToString());
                        string xtype1 = xtype0.SelectedValue.ToString().Trim();
                        string xcat1 = xcat.SelectedValue.ToString().Trim();
                        string xdesc1 = xdesc.Value.ToString().Trim();
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        int zactive1 = zactive.Checked ? 1 : 0;
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", xrow1);
                        cmd.Parameters.AddWithValue("@xline", xline1);
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                        cmd.Parameters.AddWithValue("@xcat", xcat1);
                        cmd.Parameters.AddWithValue("@xtype", xtype1);
                        cmd.Parameters.AddWithValue("@zactive", zactive1);
                        cmd.Parameters.AddWithValue("@xemail", zemail1);
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
                string str = "SELECT * FROM hrgrowthset WHERE xrow=@xrow and zid=@zid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xrow", Int32.Parse(((LinkButton)sender).Text));
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xtype0.Text = dtztcode.Rows[0]["xtype"].ToString();
                xcat.Text = dtztcode.Rows[0]["xcat"].ToString();
                xrow.InnerHtml = dtztcode.Rows[0]["xrow"].ToString();
                xline.Text = dtztcode.Rows[0]["xline"].ToString();
                //string xaltcd = dtztcode.Rows[0]["xcodealt"].ToString();
                //if (xaltcd == "days")
                //    xcodealt.Text = "Days Observation";
                //else if (xaltcd == "out")
                //    xcodealt.Text = "Outings/Duke";
                //else if (xaltcd == "sport")
                //    xcodealt.Text = "Sports/Coaching";
                xdesc.Value = dtztcode.Rows[0]["xdesc"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
                xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();


                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                key.Value = ((LinkButton)sender).Text;
                message.InnerHtml = "";
                btnSave.Enabled = false;

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
            //string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtype,xcode,xdescdet,xprops, " +
            //    //"case when xcodealt='days' then 'Days Observation' " +
            //    //"when xcodealt='out' then 'Outings/Duke' " +
            //    //"else 'Sports/Coaching' end as xcodealt " +
            //    "xcodealt ,zactive FROM mscodesam where xtype=@xtype and zid=@zid and xcodealt=@xcodealt ORDER BY xtype,xcode";

            string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xline,xtype,xcat, " +
                //"case when xcodealt='days' then 'Days Observation' " +
                //"when xcodealt='out' then 'Outings/Duke' " +
                //"else 'Sports/Coaching' end as xcodealt " +
                "xdesc ,zactive FROM hrgrowthset where xtype=@xtype and zid=@zid and xcat=@xcat ORDER BY xline";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@row", _row);
            da.SelectCommand.Parameters.AddWithValue("@xtype", xtype0.SelectedValue.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xcat", xcat.SelectedValue.ToString().Trim());
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
                message.InnerHtml = "";
                zemail.InnerHtml = "";
                xemail.InnerHtml = "";
                xrow.InnerHtml = "";
                xline.Text = "";
                xdesc.Value = "";


                key.Value = "";
                _searchbox.Text = "";
                zactive.Checked = true;
                btnSave.Enabled = true;
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