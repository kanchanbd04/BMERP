using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.BMERP.sc
{
    public partial class scemp : System.Web.UI.Page
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
                    zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(),"zid6");
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

                string xrow = ((LinkButton)sender).Text;


                string str = "SELECT * FROM scempd where xrow=@xrow";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xrow", ((LinkButton)sender).Text);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xemp.Text = dtztcode.Rows[0]["xemp"].ToString();
                sxemp.Text = dtztcode.Rows[0]["xemp"].ToString();
                xname.Text = dtztcode.Rows[0]["xname"].ToString();
                sxname.Text = dtztcode.Rows[0]["xname"].ToString();
                xdesig.Text = dtztcode.Rows[0]["xdesig"].ToString();
                xjoindate.Text = Convert.ToDateTime(dtztcode.Rows[0]["xjoindate"].ToString()).ToShortDateString();
                xfather.Text = dtztcode.Rows[0]["xfather"].ToString();
                xmother.Text = dtztcode.Rows[0]["xmother"].ToString();
                xadd.Value = dtztcode.Rows[0]["xadd"].ToString();
                xstate.Text = dtztcode.Rows[0]["xstate"].ToString();
                xcountry1.Text = dtztcode.Rows[0]["xcountry1"].ToString();
                xmobile.Text = dtztcode.Rows[0]["xmobile"].ToString();
                xemail1.Text = dtztcode.Rows[0]["xemail1"].ToString();
                xreligi.Text = dtztcode.Rows[0]["xreligi"].ToString();
                xsex.Text = dtztcode.Rows[0]["xsex"].ToString();
                xdob.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdob"].ToString()).ToShortDateString();
                xsalary.Text = dtztcode.Rows[0]["xsalary"].ToString();
                zemail.Text = dtztcode.Rows[0]["zemail"].ToString();
                xemail.Text = dtztcode.Rows[0]["xemail"].ToString();
                xeffdt.Text = Convert.ToDateTime(dtztcode.Rows[0]["xeffdt"].ToString()).ToShortDateString();
                xstatus.Text = dtztcode.Rows[0]["xstatus"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;

                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();

                //ViewState["level1"] = ((LinkButton)sender).Text;
                key.Value = ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                //fnFillDataGrid();
                string status = zglobal.fnChkStatus("xstatus", "scempd", Convert.ToInt32(key.Value.ToString()));
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
                xstatus.Text = "";
                xemp.Text = "";
                xname.Text = "";
                xdesig.Text = "[Select]";
                xjoindate.Text = "";
                xfather.Text = "";
                xmother.Text = "";
                xadd.Value = "";
                xstate.Text = "";
                xcountry1.Text = "Bangladesh";
                xmobile.Text = "";
                xemail1.Text = "";
                xreligi.Text = "[Select]";
                xsex.Text = "[Select]";
                xdob.Text = "";
                xsalary.Text = "0";
                sxemp.Text = "";
                sxname.Text = "";
                zactive.Checked = true;
                xeffdt.Text = "";
                //ViewState["key"] = null;
                key.Value = "";
                //fnFillLevel("load");
                //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                fnFillDataGrid();
                btnClear.Style.Value = zglobal.btncolor;
                zglobal.ltZbusinessGlmst.Clear();
                zglobal.ltZbusinessGlmstPermis.Clear();
                zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid6");
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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid6 IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {
                  
                    if (xemp.Text == "" || xemp.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Employee Name";
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
                    //if (xtype.Text == "" || xtype.Text == string.Empty)
                    //{
                    //    msg.InnerHtml = "Enter Supplier Type";
                    //    msg.Style.Value = zglobal.warningmsg;
                    //    btnAdd.Style.Value = zglobal.btnerr;
                    //    return;
                    //}
                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            //Insert data into scemph
                            //Check header table duplicate entry
                            DataTable tempTable = new DataTable();
                            using (DataSet dts = new DataSet())
                            {
                                string query1 =
                                    "SELECT * FROM scemph WHERE xemp=@xemp";
                                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                                da.SelectCommand.Parameters.AddWithValue("@xemp", xemp.Text.ToString().Trim());
                                //DataTable tempTable = new DataTable();
                                da.Fill(dts, "tempTable");
                                tempTable = dts.Tables["tempTable"];
                            }
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO scemph (xemp) " +
                                           "VALUES(@xemp) ";
                            //string xemp1 = zglobal.fnMaxIDWPrefix(xtrn.Text.ToString().Trim(), "SELECT MAX(xsup) from mssuph WHERE xprefix='" + xtrn.Text.ToString().Trim() + "'");
                            string xemp1 = xemp.Text.ToString().Trim();
                            //string xprefix1 = xtrn.Text.ToString().Trim();
                            //int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            //cmd.Parameters.AddWithValue("@xprefix", xprefix1);
                            //cmd.Parameters.AddWithValue("@zactive", zactive1);
                            if (tempTable.Rows.Count <= 0)
                            {
                                cmd.ExecuteNonQuery();
                            }

                            //Insert data into mscusd
                            cmd.Parameters.Clear();
                            query = "INSERT INTO scempd (ztime,xrow,xemp,xname,xdesig,xjoindate,xfather,xmother,xadd,xstate,xcountry1,xmobile,xemail1,xreligi,xsex,xdob,xsalary,zactive,zemail,xeffdt,xstatus) " +
                                           "VALUES(@ztime,@xrow,@xemp,@xname,@xdesig,@xjoindate,@xfather,@xmother,@xadd,@xstate,@xcountry1,@xmobile,@xemail1,@xreligi,@xsex,@xdob,@xsalary,@zactive,@zemail,@xeffdt,'Open') ";
                            DateTime ztime = DateTime.Now;
                            int xrow1 = zglobal.GetMaximumIdInt("xrow", "scempd");
                            //string xemp1 = xemp.Text.ToString().Trim();
                            xkey = xrow1.ToString();
                            //string xacc1 = xacc.Text.ToString().Trim();
                            string xname1 = xname.Text.ToString().Trim();
                            string xdesig1 = xdesig.Text.ToString().Trim();
                            DateTime xjoindate1 = Convert.ToDateTime(xjoindate.Text.ToString().Trim());
                            string xfather1 = xfather.Text.ToString().Trim();
                            string xmother1 = xmother.Text.ToString().Trim();
                            string xadd1 = xadd.Value.ToString().Trim();
                            string xstate1 = xstate.Text.ToString().Trim();
                            string xcountry11 = xcountry1.Text.ToString().Trim();
                            string xmobile1 = xmobile.Text.ToString().Trim();
                            string xemail11 = xemail1.Text.ToString().Trim();
                            string xreligi1 = xreligi.Text.ToString().Trim();
                            string xsex1 = xsex.Text.ToString().Trim();
                            DateTime xdob1 = Convert.ToDateTime(xdob.Text.ToString().Trim());
                            decimal xsalary1 = Convert.ToDecimal(xsalary.Text.ToString().Trim());
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.Parameters.AddWithValue("@xname", xname1);
                            cmd.Parameters.AddWithValue("@xdesig", xdesig1);
                            cmd.Parameters.AddWithValue("@xjoindate", xjoindate1);
                            cmd.Parameters.AddWithValue("@xfather", xfather1);
                            cmd.Parameters.AddWithValue("@xmother", xmother1);
                            cmd.Parameters.AddWithValue("@xadd", xadd1);
                            cmd.Parameters.AddWithValue("@xstate", xstate1);
                            cmd.Parameters.AddWithValue("@xcountry1", xcountry11);
                            cmd.Parameters.AddWithValue("@xmobile", xmobile1);
                            cmd.Parameters.AddWithValue("@xemail1", xemail11);
                            cmd.Parameters.AddWithValue("@xreligi", xreligi1);
                            cmd.Parameters.AddWithValue("@xsex", xsex1);
                            cmd.Parameters.AddWithValue("@xdob", xdob1);
                            cmd.Parameters.AddWithValue("@xsalary", xsalary1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            int xflag;
                            //Insert into scempbiz
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "scempbiz");
                                
                                query = "INSERT INTO scempbiz (xrow,xrowd,xemp,zid) " +
                                           "VALUES(@xrow,@xrowd,@xemp,@zid) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid6"]);
                                cmd.Parameters.AddWithValue("@xemp", xemp1);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid6");



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
                    sxemp.Text = xemp.Text;
                    sxname.Text = xname.Text;

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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid6 IS NOT NULL and zemail=@zemail and xsession=@xsession");
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
                    //if (xtype.Text == "" || xtype.Text == string.Empty)
                    //{
                    //    msg.InnerHtml = "Enter Supplier Type";
                    //    msg.Style.Value = zglobal.warningmsg;
                    //    btnAdd.Style.Value = zglobal.btnerr;
                    //    return;
                    //}
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
                            string xemp1 = xemp.Text.ToString().Trim();
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
                            query = "UPDATE scempd SET zutime=@zutime,xname=@xname,xdesig=@xdesig,xjoindate=@xjoindate,xfather=@xfather,xmother=@xmother,xadd=@xadd,xstate=@xstate,xcountry1=@xcountry1,xmobile=@xmobile,xemail1=@xemail1,xreligi=@xreligi,xsex=@xsex,xdob=@xdob,xsalary=@xsalary,xeffdt=@xeffdt,xemail=@xemail,zactive=@zactive,xstatus='Open' " +
                                           "WHERE xrow=@xrow ";
                            DateTime ztime = DateTime.Now;
                            int xrow1 = Convert.ToInt32(key.Value);
                            //string xemp1 = xemp.Text.ToString().Trim();
                            //string xacc1 = xacc.Text.ToString().Trim();
                            string xname1 = xname.Text.ToString().Trim();
                            string xdesig1 = xdesig.Text.ToString().Trim();
                            DateTime xjoindate1 = Convert.ToDateTime(xjoindate.Text.ToString().Trim());
                            string xfather1 = xfather.Text.ToString().Trim();
                            string xmother1 = xmother.Text.ToString().Trim();
                            string xadd1 = xadd.Value.ToString().Trim();
                            string xstate1 = xstate.Text.ToString().Trim();
                            string xcountry11 = xcountry1.Text.ToString().Trim();
                            string xmobile1 = xmobile.Text.ToString().Trim();
                            string xemail11 = xemail1.Text.ToString().Trim();
                            string xreligi1 = xreligi.Text.ToString().Trim();
                            string xsex1 = xsex.Text.ToString().Trim();
                            DateTime xdob1 = Convert.ToDateTime(xdob.Text.ToString().Trim());
                            decimal xsalary1 = Convert.ToDecimal(xsalary.Text.ToString().Trim());
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zutime", ztime);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.Parameters.AddWithValue("@xname", xname1);
                            cmd.Parameters.AddWithValue("@xdesig", xdesig1);
                            cmd.Parameters.AddWithValue("@xjoindate", xjoindate1);
                            cmd.Parameters.AddWithValue("@xfather", xfather1);
                            cmd.Parameters.AddWithValue("@xmother", xmother1);
                            cmd.Parameters.AddWithValue("@xadd", xadd1);
                            cmd.Parameters.AddWithValue("@xstate", xstate1);
                            cmd.Parameters.AddWithValue("@xcountry1", xcountry11);
                            cmd.Parameters.AddWithValue("@xmobile", xmobile1);
                            cmd.Parameters.AddWithValue("@xemail1", xemail11);
                            cmd.Parameters.AddWithValue("@xreligi", xreligi1);
                            cmd.Parameters.AddWithValue("@xsex", xsex1);
                            cmd.Parameters.AddWithValue("@xdob", xdob1);
                            cmd.Parameters.AddWithValue("@xsalary", xsalary1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.Parameters.AddWithValue("@xemail", zemail1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            //int xflag;


                            //Insert into mscusbiz
                            cmd.Parameters.Clear();
                            query = "DELETE FROM scempbiz where xrowd=@xrowd";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrowd", xrow1);
                            cmd.ExecuteNonQuery();
                            //Insert into mscusbiz
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "scempbiz");

                                query = "INSERT INTO scempbiz (xrow,xrowd,xemp,zid) " +
                                           "VALUES(@xrow,@xrowd,@xemp,@zid) ";

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid6"]);
                                cmd.Parameters.AddWithValue("@xemp", zglobal.fnRowValue("xemp","scempd",xrow1));
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid6");



                        fnFillDataGrid();
                        xemail.Text = HttpContext.Current.Session["curuser"].ToString();
                        xstatus.Text = "Open";
                        tran.Complete();

                    }
                    msg.InnerHtml = "Update comlpeted";
                    msg.Style.Value = zglobal.successmsg;
                    btnUpdate.Style.Value = zglobal.btncolor;
                    fnButtonFace("save");
                    sxemp.Text = xemp.Text;
                    sxname.Text = xname.Text;
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

                    string status = zglobal.fnChkStatus("xstatus", "scempd", Convert.ToInt32(key.Value.ToString()));
                    if (status == "Confirmed")
                    {
                        msg.InnerHtml = "Record Already Confirmed. Cann't Delete Record.";
                        msg.Style.Value = zglobal.errormsg;
                        return;
                    }

                    string xemp1 = zglobal.fnRowValue("xemp", "scempd", Convert.ToInt32(key.Value.ToString()));

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {

                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            //DELETE Business Table
                            int xrow1 = Convert.ToInt32(key.Value.ToString());
                            string query = "DELETE FROM scempbiz WHERE xrowd=@xrowd ";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrowd", xrow1);
                            cmd.ExecuteNonQuery();
                            //DELETE Detail Table
                            query = "DELETE FROM scempd WHERE xrow=@xrow";
                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.ExecuteNonQuery();
                            //DELETE Header Table
                            query = "DELETE FROM scemph WHERE xemp=@xemp";
                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.ExecuteNonQuery();
                            //zglobal.ltZbusinessGlmst.Clear();
                            //zglobal.ltZbusinessGlmstPermis.Clear();
                            zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid6");


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

                    string status = zglobal.fnChkStatus("xstatus", "scempd", Convert.ToInt32(key.Value.ToString()));
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
                            string query = "UPDATE scempd SET xstatus='Confirmed' WHERE xrow=@xrow ";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.ExecuteNonQuery();

                            zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid6");


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
            string str = "SELECT xrow,xemp,xeffdt,xname,xdesig,xmobile,zactive FROM scempd where coalesce(xstatus,'Open')='Confirmed' ORDER BY xemp,xeffdt";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView1.DataSource = dtztcode;
            GridView1.DataBind();

            str = "SELECT xrow,xemp,xeffdt,xname,xdesig,xmobile,zactive FROM scempd where coalesce(xstatus,'Open')<>'Confirmed' ORDER BY xemp,xeffdt";
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