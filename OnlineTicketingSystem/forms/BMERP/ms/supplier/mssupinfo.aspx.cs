using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.BMERP.ms.supplier
{
    public partial class mssupinfo : System.Web.UI.Page
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
                    zglobal.fnDeleteBusinessSupAP(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
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


                string str = "SELECT * FROM mssupd where xrow=@xrow";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xrow", ((LinkButton)sender).Text);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xtrn.Text = dtztcode.Rows[0]["xtrn"].ToString();
                xsup.Text = dtztcode.Rows[0]["xsup"].ToString();
                xorg.Text = dtztcode.Rows[0]["xorg"].ToString();
                xdateact.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdateact"].ToString()).ToShortDateString();
                xadd1.Value = dtztcode.Rows[0]["xadd1"].ToString();
                xstate.Text = dtztcode.Rows[0]["xstate"].ToString();
                xcountry.Text = dtztcode.Rows[0]["xcountry"].ToString();
                xmobile.Text = dtztcode.Rows[0]["xmobile"].ToString();
                xemail1.Text = dtztcode.Rows[0]["xemail1"].ToString();
                xtype.Text = dtztcode.Rows[0]["xtype"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                xeffdt.Text = Convert.ToDateTime(dtztcode.Rows[0]["xeffdt"].ToString()).ToShortDateString();
                zemail.Text = dtztcode.Rows[0]["zemail"].ToString();
                xemail.Text = dtztcode.Rows[0]["xemail"].ToString();
                xstatus.Text =  dtztcode.Rows[0]["xstatus"].ToString();// == String.Empty || dtztcode.Rows[0]["xstatus"].ToString() == "" ? "" : dtztcode.Rows[0]["xstatus"].ToString();

                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();

                ViewState["level1"] = ((LinkButton)sender).Text;
                key.Value = ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                //fnFillDataGrid();
                string status = zglobal.fnChkStatus("xstatus", "mssupd", Convert.ToInt32(key.Value.ToString()));
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
                xtrn.Text = "SUP-";
                xsup.Text = "";
                xorg.Text = "";
                xdateact.Text = "";
                xadd1.Value = "";
                xstate.Text = "";
                xcountry.Text = "Bangladesh";
                xmobile.Text = "";
                xemail1.Text = "";
                xstatus.Text = "";
                xtype.Text = "[Select]";
                xeffdt.Text = "";
                zactive.Checked = true;
                ViewState["key"] = null;
                key.Value = "";
                //fnFillLevel("load");
                //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                fnFillDataGrid();
                btnClear.Style.Value = zglobal.btncolor;
                zglobal.ltZbusinessGlmst.Clear();
                zglobal.ltZbusinessGlmstPermis.Clear();
                zglobal.fnDeleteBusinessSupAP(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid5 IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {
                  
                    if (xorg.Text == "" || xorg.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Company Name";
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
                    if (xtype.Text == "" || xtype.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Supplier Type";
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
                                    "SELECT * FROM mssuph WHERE xsup=@xsup";
                                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                                da.SelectCommand.Parameters.AddWithValue("@xsup", xsup.Text.ToString().Trim());
                                //DataTable tempTable = new DataTable();
                                da.Fill(dts, "tempTable");
                                tempTable = dts.Tables["tempTable"];
                            }
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO mssuph (xsup,xprefix) " +
                                           "VALUES(@xacc,@xprefix) ";
                            string xsup1;
                            if (tempTable.Rows.Count <= 0)
                            {
                                xsup1 = zglobal.fnMaxIDWPrefix(xtrn.Text.ToString().Trim(),
                                    "SELECT MAX(xsup) from mssuph WHERE xprefix='" + xtrn.Text.ToString().Trim() + "'");
                            }
                            else
                            {
                                xsup1 = xsup.Text.ToString().Trim();
                            }
                            xsup.Text = xsup1;
                            string xprefix1 = xtrn.Text.ToString().Trim();
                            //int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xacc", xsup1);
                            cmd.Parameters.AddWithValue("@xprefix", xprefix1);
                            //cmd.Parameters.AddWithValue("@zactive", zactive1);
                            if (tempTable.Rows.Count <= 0)
                            {
                                cmd.ExecuteNonQuery();
                            }

                            //Insert data into mscusd
                            cmd.Parameters.Clear();
                            query = "INSERT INTO mssupd (ztime,xrow,xsup,xeffdt,xorg,xtrn,xadd1,xdateact,xstate,xcountry,xmobile,xemail1,xtype,zactive,zemail,xstatus) " +
                                           "VALUES(@ztime,@xrow,@xsup,@xeffdt,@xorg,@xtrn,@xadd1,@xdateact,@xstate,@xcountry,@xmobile,@xemail1,@xtype,@zactive,@zemail,'Open') ";
                            DateTime ztime = DateTime.Now;
                            int xrow1 = zglobal.GetMaximumIdInt("xrow", "mssupd");
                            xkey = xrow1.ToString();
                            //string xacc1 = xacc.Text.ToString().Trim();
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string xorg1 = xorg.Text.ToString().Trim();
                            DateTime xdateact1 = Convert.ToDateTime(xdateact.Text.ToString().Trim());
                            string xtrn1 = xtrn.Text.ToString().Trim();
                            string xadd12 = xadd1.Value.ToString().Trim();
                            string xstate1 = xstate.Text.ToString().Trim();
                            string xcountry1 = xcountry.Text.ToString().Trim();
                            string xmobile1 = xmobile.Text.ToString().Trim();
                            string xemail11 = xemail1.Text.ToString().Trim();
                            string xtype1 = xtype.Text.ToString().Trim();
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xsup", xsup1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.Parameters.AddWithValue("@xorg", xorg1);
                            cmd.Parameters.AddWithValue("@xtrn", xtrn1);
                            cmd.Parameters.AddWithValue("@xadd1", xadd12);
                            cmd.Parameters.AddWithValue("@xdateact", xdateact1);
                            cmd.Parameters.AddWithValue("@xstate", xstate1);
                            cmd.Parameters.AddWithValue("@xcountry", xcountry1);
                            cmd.Parameters.AddWithValue("@xmobile", xmobile1);
                            cmd.Parameters.AddWithValue("@xemail1", xemail11);
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            int xflag;
                            //Insert into mscusbiz
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "mssupbiz");
                                
                                query = "INSERT INTO mssupbiz (xrow,xrowd,xsup,zid,xap) " +
                                           "VALUES(@xrow,@xrowd,@xsup,@zid,@xap) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid5"]);
                                cmd.Parameters.AddWithValue("@xsup", xsup1);
                                cmd.Parameters.AddWithValue("@xap", zid["xacc"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusinessSupAP(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());



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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid5 IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {
                    //if (xorg.Text == "" || xorg.Text == string.Empty)
                    //{
                    //    msg.InnerHtml = "Enter Distributor Name";
                    //    msg.Style.Value = zglobal.warningmsg;
                    //    btnAdd.Style.Value = zglobal.btnerr;
                    //    return;
                    //}
                    if (xeffdt.Text == "" || xeffdt.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Effected Date";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    if (xtype.Text == "" || xtype.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Supplier Type";
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
                            string xsup1 = xsup.Text.ToString().Trim();
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
                            query = "UPDATE mssupd SET zutime=@zutime,xorg=@xorg,xadd1=@xadd1,xdateact=@xdateact,xstate=@xstate,xcountry=@xcountry,xmobile=@xmobile,xemail1=@xemail1,xtype=@xtype,xeffdt=@xeffdt,xemail=@xemail,zactive=@zactive,xstatus='Open' " +
                                           "WHERE xrow=@xrow ";
                            DateTime ztime = DateTime.Now;
                            int xrow1 = Convert.ToInt32(key.Value);
                            //xkey = xrow1.ToString();
                            //string xacc1 = xacc.Text.ToString().Trim();
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string xorg1 = xorg.Text.ToString().Trim();
                            DateTime xdateact1 = Convert.ToDateTime(xdateact.Text.ToString().Trim());
                           // string xtrn1 = xtrn.Text.ToString().Trim();
                            string xadd12 = xadd1.Value.ToString().Trim();
                            string xstate1 = xstate.Text.ToString().Trim();
                            string xcountry1 = xcountry.Text.ToString().Trim();
                            string xmobile1 = xmobile.Text.ToString().Trim();
                            string xemail11 = xemail1.Text.ToString().Trim();
                            string xtype1 = xtype.Text.ToString().Trim();
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zutime", ztime);
                            cmd.Parameters.AddWithValue("@xorg", xorg1);
                            cmd.Parameters.AddWithValue("@xadd1", xadd12);
                            cmd.Parameters.AddWithValue("@xdateact", xdateact1);
                            cmd.Parameters.AddWithValue("@xstate", xstate1);
                            cmd.Parameters.AddWithValue("@xcountry", xcountry1);
                            cmd.Parameters.AddWithValue("@xmobile", xmobile1);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.Parameters.AddWithValue("@xemail1", xemail11);
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xemail", zemail1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            //int xflag;


                            //Insert into mscusbiz
                            cmd.Parameters.Clear();
                            query = "DELETE FROM mssupbiz where xrowd=@xrowd";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrowd", xrow1);
                            cmd.ExecuteNonQuery();
                            //Insert into mscusbiz
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "mssupbiz");

                                query = "INSERT INTO mssupbiz (xrow,xrowd,xsup,zid,xap) " +
                                           "VALUES(@xrow,@xrowd,@xsup,@zid,@xap) ";

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid5"]);
                                cmd.Parameters.AddWithValue("@xsup", zglobal.fnRowValue("xsup","mssupd",xrow1));
                                cmd.Parameters.AddWithValue("@xap", zid["xacc"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusinessSupAP(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());



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
                if (txtconformmessageValue.Value == "Yes")
                {
                    if (key.Value == "" || key.Value == string.Empty || key.Value == null)
                    {
                        msg.InnerHtml = "Value Not Set";
                        msg.Style.Value = zglobal.errormsg;
                        return;
                    }

                    string status = zglobal.fnChkStatus("xstatus", "mssupd", Convert.ToInt32(key.Value.ToString()));
                    if (status == "Confirmed")
                    {
                        msg.InnerHtml = "Record Already Confirmed. Cann't Delete Record.";
                        msg.Style.Value = zglobal.errormsg;
                        return;
                    }

                    string xsup1 = zglobal.fnRowValue("xsup", "mssupd", Convert.ToInt32(key.Value.ToString()));

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {

                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            //DELETE Business Table
                            int xrow1 = Convert.ToInt32(key.Value.ToString());
                            string query = "DELETE FROM mssupbiz WHERE xrowd=@xrowd ";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrowd", xrow1);
                            cmd.ExecuteNonQuery();
                            //DELETE Detail Table
                            query = "DELETE FROM mssupd WHERE xrow=@xrow";
                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.ExecuteNonQuery();
                            //DELETE Header Table
                            query = "DELETE FROM mssuph WHERE xsup=@xsup";
                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@xsup", xsup1);
                            cmd.ExecuteNonQuery();
                            //zglobal.ltZbusinessGlmst.Clear();
                            //zglobal.ltZbusinessGlmstPermis.Clear();
                            zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid5");


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

                    string status = zglobal.fnChkStatus("xstatus", "mssupd", Convert.ToInt32(key.Value.ToString()));
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
                            string query = "UPDATE mssupd SET xstatus='Confirmed' WHERE xrow=@xrow ";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.ExecuteNonQuery();

                            zglobal.fnDeleteBusinessSupAP(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());


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
            string str = "SELECT xsup,xorg,xeffdt,xmobile,zactive,xrow FROM mssupd where coalesce(xstatus,'Open')='Confirmed' ORDER BY xsup,xeffdt";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView1.DataSource = dtztcode;
            GridView1.DataBind();

            str = "SELECT xsup,xorg,xeffdt,xmobile,zactive,xrow FROM mssupd where coalesce(xstatus,'Open')<>'Confirmed' ORDER BY xsup,xeffdt";
            dts.Reset();
            da = new SqlDataAdapter(str, conn1);
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