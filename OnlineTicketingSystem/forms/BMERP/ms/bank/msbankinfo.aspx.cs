using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.BMERP.ms.bank
{
    public partial class msbankinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                    //
                    //fnFillLevel("load");
                    //fnFillDataGrid();
                    //zactive.Checked = true;
                    //key.Value = "";
                    //ViewState["key"] = null;
                    zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid7");
                    fnFillDataGrid();
                }

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                //msg.InnerHtml = "City : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xname1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM msbankd where xrow=@xrow";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xrow", ((LinkButton)sender).Text);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xtrn.Text = dtztcode.Rows[0]["xtrn"].ToString();
                xbank.Text = dtztcode.Rows[0]["xbank"].ToString();
                xorg.Text = dtztcode.Rows[0]["xorg"].ToString();
                xbankacc.Text = dtztcode.Rows[0]["xbankacc"].ToString();
                xbankbr.Text = dtztcode.Rows[0]["xbankbr"].ToString();
                xacctype.Text = dtztcode.Rows[0]["xacctype"].ToString();
                xbankadd.Value = dtztcode.Rows[0]["xbankadd"].ToString();
                xemail1.Text = dtztcode.Rows[0]["xemail1"].ToString();
                xphone.Text = dtztcode.Rows[0]["xphone"].ToString();
                xfax.Text = dtztcode.Rows[0]["xfax"].ToString();
                xmanager.Text = dtztcode.Rows[0]["xmanager"].ToString();
                xcontact.Text = dtztcode.Rows[0]["xcontact"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                xeffdt.Text = Convert.ToDateTime(dtztcode.Rows[0]["xeffdt"].ToString()).ToShortDateString();
                zemail.Text = dtztcode.Rows[0]["zemail"].ToString();
                xemail.Text = dtztcode.Rows[0]["xemail"].ToString();
                xstatus.Text = dtztcode.Rows[0]["xstatus"].ToString();// == String.Empty || dtztcode.Rows[0]["xstatus"].ToString() == "" ? "" : dtztcode.Rows[0]["xstatus"].ToString();

                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();

                //ViewState["level1"] = ((LinkButton)sender).Text;
                key.Value = ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                //fnFillDataGrid();
                 string status = zglobal.fnChkStatus("xstatus", "msbankd", Convert.ToInt32(key.Value.ToString()));
                if (status == "Confirmed")
                {
                    fnButtonFace("confirm");
                }
                else
                {
                    fnButtonFace("save");
                }
                
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                msg.InnerHtml = "";
                btnAdd.Style.Value = zglobal.btncolor;
                btnUpdate.Style.Value = zglobal.btncolor;
                btnDelete.Style.Value = zglobal.btncolor;
                fnButtonFace("clear");
                zemail.Text = "";
                xemail.Text = "";
                xtrn.Text = "BANK";
                xbank.Text = "";
                xorg.Text = "";
                xbankacc.Text = "";
                xbankbr.Text = "";
                xacctype.Text = "[Select]";
                xbankadd.Value = "";
                xemail1.Text = "";
                xphone.Text = "";
                xfax.Text = "";
                xmanager.Text = "";
                xcontact.Text = "";
                xstatus.Text = "";
                zactive.Checked = true;
                xeffdt.Text = "";
                ViewState["key"] = null;
                key.Value = "";
                //fnFillLevel("load");
                //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                fnFillDataGrid();
                btnClear.Style.Value = zglobal.btncolor;
                zglobal.ltZbusinessGlmst.Clear();
                zglobal.ltZbusinessGlmstPermis.Clear();
                zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid7");
            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                btnClear.Style.Value = zglobal.btnerr;
            }
        }

        private void fnButtonFace(string flag)
        {
            if (flag == "save")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnConfirm.Enabled = true;
            }
            else if (flag == "update")
            {
                btnUpdate.Enabled = false;
            }
            else if (flag == "clear")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnConfirm.Enabled = true;
            }
            else if (flag == "confirm")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnConfirm.Enabled = false;
            }
            btnClear.Style.Value = zglobal.btncolor;
            btnAdd.Style.Value = zglobal.btncolor;
            btnUpdate.Style.Value = zglobal.btncolor;
            btnDelete.Style.Value = zglobal.btncolor;
            btnConfirm.Style.Value = zglobal.btncolor;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string xkey = "";
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid7 IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {

                    if (xbankacc.Text == "" || xbankacc.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Bank Account Number";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    if (xacctype.Text == "[Select]")
                    {
                        msg.InnerHtml = "Select Account Type";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    if (xorg.Text == "" || xorg.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Bank Name";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    if (xeffdt.Text == "" || xeffdt.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Effected Date";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            //Insert data into mscush
                            //Check header table duplicate entry
                            DataTable tempTable = new DataTable();
                            using (DataSet dts = new DataSet())
                            {
                                string query1 =
                                    "SELECT * FROM msbankd WHERE xbank=@xbank";
                                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                                da.SelectCommand.Parameters.AddWithValue("@xbank", xbank.Text.ToString().Trim());
                                //DataTable tempTable = new DataTable();
                                da.Fill(dts, "tempTable");
                                tempTable = dts.Tables["tempTable"];
                            }
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO msbankh (xbank,xprefix) " +
                                           "VALUES(@xbank,@xprefix) ";
                            string xbank1;
                            if (tempTable.Rows.Count <= 0)
                            {
                                xbank1 = zglobal.fnMaxIDWPrefix(xtrn.Text.ToString().Trim(), "SELECT MAX(xbank) from msbankh WHERE xprefix='" + xtrn.Text.ToString().Trim() + "'");
                            }
                            else
                            {
                                xbank1 = xbank.Text.ToString().Trim();
                            }
                            xbank.Text = xbank1;
                            string xprefix1 = xtrn.Text.ToString().Trim();
                            //int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xbank", xbank1);
                            cmd.Parameters.AddWithValue("@xprefix", xprefix1);
                            //cmd.Parameters.AddWithValue("@zactive", zactive1);
                            if (tempTable.Rows.Count <= 0)
                            {
                                cmd.ExecuteNonQuery();
                            }

                            //Insert data into mscusd
                            cmd.Parameters.Clear();
                            query = "INSERT INTO msbankd (ztime,xrow,xtrn,xbank,xorg,xbankacc,xbankbr,xacctype,xbankadd,xemail1,xphone,xfax,xmanager,xcontact,zactive,xeffdt,zemail,xstatus) " +
                                           "VALUES(@ztime,@xrow,@xtrn,@xbank,@xorg,@xbankacc,@xbankbr,@xacctype,@xbankadd,@xemail1,@xphone,@xfax,@xmanager,@xcontact,@zactive,@xeffdt,@zemail,'Open') ";
                            DateTime ztime = DateTime.Now;
                            int xrow1 = zglobal.GetMaximumIdInt("xrow", "msbankd");
                            xkey = xrow1.ToString();
                            //string xacc1 = xacc.Text.ToString().Trim();
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string xorg1 = xorg.Text.ToString().Trim();
                            string xtrn1 = xtrn.Text.ToString().Trim();
                            string xbankacc1 = xbankacc.Text.ToString().Trim();
                            string xbankbr1 = xbankbr.Text.ToString().Trim();
                            string xacctype1 = xacctype.Text.ToString().Trim();
                            string xbankadd1 = xbankadd.Value.ToString().Trim();
                            string xemail11 = xemail1.Text.ToString().Trim();
                            string xphone1 = xphone.Text.ToString().Trim();
                            string xfax1 = xfax.Text.ToString().Trim();
                            string xmanager1 = xmanager.Text.ToString().Trim();
                            string xcontact1 = xcontact.Text.ToString().Trim();
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xtrn", xtrn1);
                            cmd.Parameters.AddWithValue("@xbank", xbank1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.Parameters.AddWithValue("@xorg", xorg1);
                            cmd.Parameters.AddWithValue("@xbankacc", xbankacc1);
                            cmd.Parameters.AddWithValue("@xbankbr", xbankbr1);
                            cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                            cmd.Parameters.AddWithValue("@xbankadd", xbankadd1);
                            cmd.Parameters.AddWithValue("@xemail1", xemail11);
                            cmd.Parameters.AddWithValue("@xphone", xphone1);
                            cmd.Parameters.AddWithValue("@xfax", xfax1);
                            cmd.Parameters.AddWithValue("@xmanager", xmanager1);
                            cmd.Parameters.AddWithValue("@xcontact", xcontact1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            int xflag;
                            //Insert into mscusbiz
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "msbankbiz");

                                query = "INSERT INTO msbankbiz (xrow,xrowd,xbank,zid) " +
                                           "VALUES(@xrow,@xrowd,@xbank,@zid) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid7"]);
                                cmd.Parameters.AddWithValue("@xbank", xbank1);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid7");



                        fnFillDataGrid();
                        zemail.Text = HttpContext.Current.Session["curuser"].ToString();
                        xstatus.Text = "Open";
                        tran.Complete();


                    }
                    msg.InnerHtml = "Add comlpeted";
                    msg.Style.Value = zglobal.successmsg;
                    btnAdd.Style.Value = zglobal.btncolor;
                    fnButtonFace("save");
                    //ViewState["key"] = xrow.Text.ToString();
                    key.Value = xkey;

                }
                else
                {
                    msg.InnerHtml = "There is no business select yet. Cann't [Add]";
                    msg.Style.Value = zglobal.errormsg;
                    btnAdd.Style.Value = zglobal.btnerr;
                }


            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                btnAdd.Style.Value = zglobal.btnerr;
                key.Value = "";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid7 IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {
                    if (xbankacc.Text == "" || xbankacc.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Bank Account Number";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    if (xacctype.Text == "[Select]")
                    {
                        msg.InnerHtml = "Select Account Type";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    if (xorg.Text == "" || xorg.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Bank Name";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    if (xeffdt.Text == "" || xeffdt.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Effected Date";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            //Insert data into glmsth
                            //Check header tavle duplicate entry
                            //DataTable tempTable = new DataTable();
                            //using (DataSet dts = new DataSet())
                            //{
                            //    string query1 =
                            //        "SELECT * FROM glmsth WHERE xacc=@xacc";
                            //    SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            //    da.SelectCommand.Parameters.AddWithValue("@xacc", xacc.Text.ToString().Trim());
                            //    //DataTable tempTable = new DataTable();
                            //    da.Fill(dts, "tempTable");
                            //    tempTable = dts.Tables["tempTable"];
                            //}
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO glmsth (xacc) " +
                                           "VALUES(@xacc) ";
                            string xbank1 = xbank.Text.ToString().Trim();
                            //int zactive1 = zactive.Checked ? 1 : 0;
                            //cmd.CommandText = query;
                            //cmd.Parameters.AddWithValue("@xacc", xacc1);
                            ////cmd.Parameters.AddWithValue("@zactive", zactive1);
                            //if (tempTable.Rows.Count <= 0)
                            //{
                            //    cmd.ExecuteNonQuery();
                            //}

                            //Insert data into glmstd
                            cmd.Parameters.Clear();
                            //query = "INSERT INTO glmstd (ztime,xrow,xacc,xeffdt,xdesc,xacctype,xaccusage,xaccsource,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,xspaccgp,xcf1,zemail,zactive) " +
                            //               "VALUES(@ztime,@xrow,@xacc,@xeffdt,@xdesc,@xacctype,@xaccusage,@xaccsource,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xhrc5,@xspaccgp,@xcf1,@zemail,@zactive) ";
                            query = "UPDATE msbankd SET zutime=@zutime,xorg=@xorg,xbankacc=@xbankacc,xbankbr=@xbankbr,xacctype=@xacctype,xbankadd=@xbankadd,xemail1=@xemail1,xphone=@xphone,xfax=@xfax,xmanager=@xmanager,xcontact=@xcontact,xeffdt=@xeffdt,xemail=@xemail,zactive=@zactive,xstatus='Open' " +
                                           "WHERE xrow=@xrow ";
                            DateTime ztime = DateTime.Now;
                            int xrow1 = Convert.ToInt32(key.Value);
                            //string xacc1 = xacc.Text.ToString().Trim();
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string xorg1 = xorg.Text.ToString().Trim();
                            string xtrn1 = xtrn.Text.ToString().Trim();
                            string xbankacc1 = xbankacc.Text.ToString().Trim();
                            string xbankbr1 = xbankbr.Text.ToString().Trim();
                            string xacctype1 = xacctype.Text.ToString().Trim();
                            string xbankadd1 = xbankadd.Value.ToString().Trim();
                            string xemail11 = xemail1.Text.ToString().Trim();
                            string xphone1 = xphone.Text.ToString().Trim();
                            string xfax1 = xfax.Text.ToString().Trim();
                            string xmanager1 = xmanager.Text.ToString().Trim();
                            string xcontact1 = xcontact.Text.ToString().Trim();
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zutime", ztime);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xtrn", xtrn1);
                            cmd.Parameters.AddWithValue("@xbank", xbank1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.Parameters.AddWithValue("@xorg", xorg1);
                            cmd.Parameters.AddWithValue("@xbankacc", xbankacc1);
                            cmd.Parameters.AddWithValue("@xbankbr", xbankbr1);
                            cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                            cmd.Parameters.AddWithValue("@xbankadd", xbankadd1);
                            cmd.Parameters.AddWithValue("@xemail1", xemail11);
                            cmd.Parameters.AddWithValue("@xphone", xphone1);
                            cmd.Parameters.AddWithValue("@xfax", xfax1);
                            cmd.Parameters.AddWithValue("@xmanager", xmanager1);
                            cmd.Parameters.AddWithValue("@xcontact", xcontact1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.Parameters.AddWithValue("@xemail", zemail1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            //int xflag;


                            //Insert into mscusbiz
                            cmd.Parameters.Clear();
                            query = "DELETE FROM msbankbiz where xrowd=@xrowd";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrowd", xrow1);
                            cmd.ExecuteNonQuery();
                            //Insert into mscusbiz
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "msbankbiz");

                                query = "INSERT INTO msbankbiz (xrow,xrowd,xbank,zid) " +
                                           "VALUES(@xrow,@xrowd,@xbank,@zid) ";

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid7"]);
                                cmd.Parameters.AddWithValue("@xbank", zglobal.fnRowValue("xbank", "msbankd", xrow1));
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid7");



                        fnFillDataGrid();
                        xemail.Text = HttpContext.Current.Session["curuser"].ToString();
                        xstatus.Text = "Open";
                        tran.Complete();

                    }
                    msg.InnerHtml = "Update comlpeted";
                    msg.Style.Value = zglobal.successmsg;
                    btnUpdate.Style.Value = zglobal.btncolor;
                    fnButtonFace("save");
                    //ViewState["key"] = xrow.Text.ToString();
                    //key.Value = 
                }
                else
                {
                    msg.InnerHtml = "There is no business select yet. Cann't [Update]";
                    msg.Style.Value = zglobal.errormsg;
                    btnUpdate.Style.Value = zglobal.btnerr;
                }


            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                btnUpdate.Style.Value = zglobal.btnerr;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = ""; 
                //msg.InnerHtml = zglobal.fnRowValue("xbank", "msbankd", Convert.ToInt32(key.Value.ToString()));
                //return;
               // msg.InnerText = key.Value;
               // return;
                if (txtconformmessageValue.Value == "Yes")
                {
                    if (key.Value == "" || key.Value == string.Empty || key.Value == null)
                    {
                        msg.InnerHtml = "Value Not Set";
                        msg.Style.Value = zglobal.errormsg;
                        return;
                    }

                    string status = zglobal.fnChkStatus("xstatus", "msbankd", Convert.ToInt32(key.Value.ToString()));
                    if (status == "Confirmed")
                    {
                        msg.InnerHtml = "Record Already Confirmed. Cann't Delete Record.";
                        msg.Style.Value = zglobal.errormsg;
                        return;
                    }

                    string xbank1 = zglobal.fnRowValue("xbank", "msbankd", Convert.ToInt32(key.Value.ToString()));

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {

                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            //DELETE Business Table
                            int xrow1 = Convert.ToInt32(key.Value.ToString());
                            string query = "DELETE FROM msbankbiz WHERE xrowd=@xrowd ";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrowd", xrow1);
                            cmd.ExecuteNonQuery();
                            //DELETE Detail Table
                            query = "DELETE FROM msbankd WHERE xrow=@xrow";
                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.ExecuteNonQuery();
                            //DELETE Header Table
                            query = "DELETE FROM msbankh WHERE xbank=@xbank";
                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@xbank", xbank1);
                            cmd.ExecuteNonQuery();
                            //zglobal.ltZbusinessGlmst.Clear();
                            //zglobal.ltZbusinessGlmstPermis.Clear();
                            zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid7");
                            
                           
                        }

                        tran.Complete();
                       
                    }

                    fnFillDataGrid();
                    btnClear_Click(null, null);
                    msg.InnerHtml = "Delete comlpeted";
                    msg.Style.Value = zglobal.successmsg;
                    //btnUpdate.Style.Value = zglobal.btncolor;
                    //fnButtonFace("delete");
                }

            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (confmsg.Value == "Yes")
                {
                    if (key.Value == "" || key.Value == string.Empty || key.Value == null)
                    {
                        msg.InnerHtml = "Value Not Set";
                        msg.Style.Value = zglobal.errormsg;
                        return;
                    }

                    string status = zglobal.fnChkStatus("xstatus", "msbankd", Convert.ToInt32(key.Value.ToString()));
                    if (status == "Confirmed")
                    {
                        msg.InnerHtml = "Record Already Confirmed.";
                        msg.Style.Value = zglobal.errormsg;
                        return;
                    }

                    

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {

                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            //UPDATE Detail Table
                            int xrow1 = Convert.ToInt32(key.Value.ToString());
                            string query = "UPDATE msbankd SET xstatus='Confirmed' WHERE xrow=@xrow ";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.ExecuteNonQuery();
                            
                            zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid7");


                        }

                        tran.Complete();

                    }

                    fnFillDataGrid();
                    
                    msg.InnerHtml = "Record Confirmed";
                    msg.Style.Value = zglobal.successmsg;
                    //btnUpdate.Style.Value = zglobal.btncolor;
                    fnButtonFace("confirm");
                }

            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xrow,xbank,xorg,xeffdt,xcontact,zactive FROM msbankd where coalesce(xstatus,'Open')='Confirmed' ORDER BY xbank,xeffdt";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView1.DataSource = dtztcode;
            GridView1.DataBind();

            str = "SELECT xrow,xbank,xorg,xeffdt,xcontact,zactive FROM msbankd where coalesce(xstatus,'Open') <>'Confirmed' ORDER BY xbank,xeffdt";
            dts.Reset();
            da = new SqlDataAdapter(str,conn1);
            da.Fill(dts, "temp");
            dtztcode.Clear();
            dtztcode = dts.Tables[0];
            GridView2.DataSource = dtztcode;
            GridView2.DataBind();



            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();
        }



    }
}