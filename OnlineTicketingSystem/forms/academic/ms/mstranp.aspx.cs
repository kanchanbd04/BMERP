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
    public partial class mstranp : System.Web.UI.Page
    {

        public string xtypetrn1 = "";
        public string zid1 = "";
        public string option1 = "";
        public string xrel1 = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                xtypetrn1 = Request.QueryString["xtypetrn"];
                option1 = Request.QueryString["option"];
                xrel1 = Request.QueryString["xrel"];
                xtype2.Value = xtypetrn1;
                header_label.InnerHtml = "Related Transactions Parameters : " + xtypetrn1;
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

                    zglobal.fnGetComboDataCDWithValue(xtrn,"xtrn","xtrn","mstrn","xtypetrn='" + xtypetrn1 + "' and zactive=1");
                    zglobal.fnGetComboDataCDWithValue(xrel, "xtrn", "xtrn", "mstrn", "xtypetrn='" + xrel1 + "' and zactive=1");

                    xtyperel.Items.Add(new ListItem("", ""));

                    if (option1 == "Im Transaction Parameters")
                    {
                        xtyperel.Items.Add(new ListItem("Inventory Transaction:+", "Inventory Transaction:+"));
                        xtyperel.Items.Add(new ListItem("Inventory Transaction:-", "Inventory Transaction:-"));
                    }

                    xtyperel.SelectedValue = "";

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
                xtyperel.SelectedValue = "";
                xrel.Text = "";
                key.Value = "";
                _searchbox.Text = "";
                zactive.Checked = true;
                fnFillDataGrid();

                xtrn.Enabled = true;
                xtyperel.Enabled = true;
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
                if (xtyperel.Text == "" || xtyperel.Text == string.Empty || xtyperel.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Related Transaction Type</li>";
                    isValid = false;
                }
                if (xrel.Text == "" || xrel.Text == string.Empty || xrel.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Related Code</li>";
                    isValid = false;
                }

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
                        string query = "INSERT INTO mstrnp (ztime,zid,xtypetrn,xtrn,xtyperel,xrel,zactive,zemail) " +
                                       "VALUES(@ztime,@zid,@xtypetrn,@xtrn,@xtyperel,@xrel,@zactive,@zemail) ";
                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        string xtrn1 = xtrn.SelectedValue.ToString().Trim();
                        xkey = xtrn1;
                        string xtyperel1 = xtyperel.SelectedValue.ToString().Trim();
                        string xrel11 = xrel.SelectedValue.ToString().Trim();
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        int zactive1 = zactive.Checked ? 1 : 0;

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
                        cmd.Parameters.AddWithValue("@xtrn", xtrn1);
                        cmd.Parameters.AddWithValue("@xtyperel", xtyperel1);
                        cmd.Parameters.AddWithValue("@xrel", xrel11);
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
                if (xtyperel.Text == "" || xtyperel.Text == string.Empty || xtyperel.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Related Transaction Type</li>";
                    isValid = false;
                }
                if (xrel.Text == "" || xrel.Text == string.Empty || xrel.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Related Code</li>";
                    isValid = false;
                }

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
                        string query = "UPDATE mstrnp SET zutime=@zutime,xrel=@xrel,xemail=@xemail,zactive=@zactive " +
                                           "WHERE xtypetrn=@xtypetrn and xtrn=@xtrn and zid=@zid and xtyperel=@xtyperel ";
                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        string xtrn1 = xtrn.SelectedValue.ToString().Trim();
                        string xtyperel1 = xtyperel.SelectedValue.ToString().Trim();
                        string xrel11 = xrel.SelectedValue.ToString().Trim();
                        string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        int zactive1 = zactive.Checked ? 1 : 0;

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
                        cmd.Parameters.AddWithValue("@xtrn", xtrn1);
                        cmd.Parameters.AddWithValue("@xtyperel", xtyperel1);
                        cmd.Parameters.AddWithValue("@xrel", xrel11);
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

                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int i = Convert.ToInt32(row.RowIndex);

                string xcode1 = ((LinkButton)sender).Text;
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string str = "SELECT * FROM mstrnp WHERE xtypetrn=@xtypetrn and xtrn=@xtrn and zid=@zid and xtyperel=@xtyperel";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
                da.SelectCommand.Parameters.AddWithValue("@xtrn", ((LinkButton)sender).Text);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xtyperel", _grid_codes.Rows[i].Cells[2].Text.ToString());
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xtypetrn.InnerHtml = dtztcode.Rows[0]["xtypetrn"].ToString();
                xtrn.SelectedValue = dtztcode.Rows[0]["xtrn"].ToString();
                xtyperel.SelectedValue = dtztcode.Rows[0]["xtyperel"].ToString();
                xrel.SelectedValue = dtztcode.Rows[0]["xrel"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
                xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();


                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                key.Value = ((LinkButton)sender).Text;
                message.InnerHtml = "";

                xtrn.Enabled = false;
                xtyperel.Enabled = false;

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
            string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " * FROM mstrnp where zid=@zid and xtypetrn=@xtypetrn  ORDER BY ztime"; //ORDER BY xtype,xcode
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@row", _row);
            da.SelectCommand.Parameters.AddWithValue("@xtypetrn", xtypetrn1);
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