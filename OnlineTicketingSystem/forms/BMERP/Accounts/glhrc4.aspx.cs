using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Transactions;

namespace OnlineTicketingSystem.forms.BMERP.Accounts
{
    public partial class glhrc4 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ViewState["level1"] = Request.QueryString["level1"];
                    ViewState["level2"] = Request.QueryString["level2"];
                    ViewState["level3"] = Request.QueryString["level3"];
                    ViewState["level4"] = Request.QueryString["level4"];
                    level3.Text = "List of " + ViewState["level3"];
                    if (ViewState["level4"] != null)
                    {
                        //Response.Write(ViewState["level2"].ToString());
                        LinkButton lb = new LinkButton();
                        lb.Text = ViewState["level4"].ToString();
                        FillControls(lb,null);
                    }
                    //Response.Write(ViewState["level1"]);
                   // msg.InnerHtml = "Hi";
                    fnFillDataGrid();
                    fnDeleteBusinessPermis();
                }
                msg.InnerHtml = "";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        private void fnDeleteBusinessPermis()
        {
            using (var conn = new SqlConnection(zglobal.constring))
            {
                conn.Open();

                SqlTransaction tran;
                tran = conn.BeginTransaction("tran");
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                try
                {
                    string query = zglobal.delglhrc1zid;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }

                catch (Exception exp)
                {
                    tran.Rollback();
                    msg.InnerHtml = exp.Message;
                    msg.Style.Value = zglobal.errormsg;
                }
            }
        }

        private DataTable fnCheckBusiness()
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {
                    conn.Open();

                    //try
                    //{
                        string query = "SELECT * FROM ztemporary WHERE zid IS NOT NULL";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        DataTable tempTable = new DataTable();
                        da.Fill(dts, "tempTable");
                        tempTable = dts.Tables["tempTable"];
                    if (tempTable.Rows.Count <= 0)
                    {
                        dts.Reset();
                        query = "SELECT zid FROM glhrc32 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3";
                        da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                        da.SelectCommand.Parameters.AddWithValue("@xhrc2", ViewState["level2"]);
                        da.SelectCommand.Parameters.AddWithValue("@xhrc3", ViewState["level3"]);
                        da.Fill(dts, "tempTable");
                        tempTable.Reset();
                        tempTable = dts.Tables["tempTable"];
                    }
                    return tempTable;
                    //}

                    //catch (Exception exp)
                    //{
                    //    Response.Write(exp.Message);
                    //}
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["level4"] = null;
                xhrc4.Text = "";
                xdesc.InnerText = "";
                fnDeleteBusinessPermis();
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


                string str = "SELECT xhrc4,xdesc FROM glhrc41 where xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                da.SelectCommand.Parameters.AddWithValue("@xhrc2", ViewState["level2"]);
                da.SelectCommand.Parameters.AddWithValue("@xhrc3", ViewState["level3"]);
                da.SelectCommand.Parameters.AddWithValue("@xhrc4", ((LinkButton) sender).Text);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xhrc4.Text = dtztcode.Rows[0][0].ToString();
                xdesc.Value = dtztcode.Rows[0][1].ToString();

                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                ViewState["level4"] = ((LinkButton)sender).Text;
                fnFillDataGrid();
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
            string str = "SELECT xhrc4 FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
            da.SelectCommand.Parameters.AddWithValue("@xhrc2", ViewState["level2"]);
            da.SelectCommand.Parameters.AddWithValue("@xhrc3", ViewState["level3"]);
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            if (dtztcode.Rows.Count > 0)
            {
                GridView1.DataSource = dtztcode;
                GridView1.DataBind();


                if (ViewState["level1"] == null)
                {
                    dts.Reset();

                    str = "SELECT TOP 1 xhrc1 FROM glhrc11";
                    da = new SqlDataAdapter(str, conn1);
                    da.Fill(dts, "tempztcode");
                    dtztcode.Reset();
                    dtztcode = dts.Tables[0];

                    ViewState["level1"] = dtztcode.Rows[0][0].ToString();
                }

                if (ViewState["level2"] == null)
                {
                    dts.Reset();

                    str = "SELECT TOP 1 xhrc2 FROM glhrc21 WHERE xhrc1=@xhrc1";
                    da = new SqlDataAdapter(str, conn1);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                    da.Fill(dts, "tempztcode");
                    dtztcode.Reset();
                    dtztcode = dts.Tables[0];

                    ViewState["level2"] = dtztcode.Rows[0][0].ToString();
                }

                if (ViewState["level3"] == null)
                {
                    dts.Reset();

                    str = "SELECT TOP 1 xhrc3 FROM glhrc31 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2";
                    da = new SqlDataAdapter(str, conn1);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc2", ViewState["level2"]);
                    da.Fill(dts, "tempztcode");
                    dtztcode.Reset();
                    dtztcode = dts.Tables[0];

                    ViewState["level3"] = dtztcode.Rows[0][0].ToString();
                }
                if (ViewState["level4"] == null)
                {
                    dts.Reset();

                    str = "SELECT TOP 1 xhrc4 FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 xhrc3=@xhrc3";
                    da = new SqlDataAdapter(str, conn1);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc2", ViewState["level2"]);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc3", ViewState["level3"]);
                    da.Fill(dts, "tempztcode");
                    dtztcode.Reset();
                    dtztcode = dts.Tables[0];

                    ViewState["level4"] = dtztcode.Rows[0][0].ToString();
                }

                dts.Reset();
                str = "SELECT xhrc5 FROM glhrc51 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                da.SelectCommand.Parameters.AddWithValue("@xhrc2", ViewState["level2"]);
                da.SelectCommand.Parameters.AddWithValue("@xhrc3", ViewState["level3"]);
                da.SelectCommand.Parameters.AddWithValue("@xhrc4", ViewState["level4"]);
                da.Fill(dts, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                //DataTable dtztcode = new DataTable();
                dtztcode.Reset();
                dtztcode = dts.Tables[0];
                GridView2.DataSource = dtztcode;
                GridView2.DataBind();
            }
            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = fnCheckBusiness();
                if (tbl.Rows.Count > 0)
                {
                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO glhrc41 (ztime,xhrc1,xhrc2,xhrc3,xhrc4,xdesc) " +
                                           "VALUES(@ztime,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xdesc) ";
                            DateTime ztime = DateTime.Now;
                            string xhrc11 = ViewState["level1"].ToString();
                            string xhrc21 = ViewState["level2"].ToString();
                            string xhrc31 = ViewState["level3"].ToString();
                            string xhrc411 = xhrc4.Text.ToString().Trim();
                            string xdesc1 = xdesc.InnerText.ToString().Trim();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                            cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                            cmd.ExecuteNonQuery();

                            //cmd.Parameters.Clear();
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                query = "INSERT INTO glhrc42 (xhrc1,xhrc2,xhrc3,xhrc4,zid) " +
                                           "VALUES(@xhrc1,@xhrc2,@xhrc3,@xhrc4,@zid) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                                cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                                cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                                cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                                cmd.Parameters.AddWithValue("@zid", zid["zid"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Complete();
                       
                    }
                    msg.InnerHtml = "Add comlpeted";
                    msg.Style.Value = zglobal.successmsg;
                    
                    fnFillDataGrid();
                }
                else
                {
                    msg.InnerHtml = "There is no business select yet. Cann't [Add]";
                    msg.Style.Value = zglobal.errormsg;
                }
                
                fnDeleteBusinessPermis();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = fnCheckBusiness();
                if (tbl.Rows.Count > 0)
                {
                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "UPDATE glhrc41 SET zutime=@zutime,xdesc=@xdesc " +
                                           "WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                            DateTime zutime = DateTime.Now;
                            string xhrc11 = ViewState["level1"].ToString();
                            string xhrc21 = ViewState["level2"].ToString();
                            string xhrc31 = ViewState["level3"].ToString();
                            string xhrc411 = xhrc4.Text.ToString().Trim();
                            string xdesc1 = xdesc.InnerText.ToString().Trim();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zutime", zutime);
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                            cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();
                            query = "DELETE FROM glhrc42 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4 ";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                            cmd.ExecuteNonQuery();

                            //cmd.Parameters.Clear();
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                query = "INSERT INTO glhrc42 (xhrc1,xhrc2,xhrc3,xhrc4,zid) " +
                                           "VALUES(@xhrc1,@xhrc2,@xhrc3,@xhrc4,@zid) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                                cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                                cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                                cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                                cmd.Parameters.AddWithValue("@zid", zid["zid"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Complete();

                    }
                    msg.InnerHtml = "Update comlpeted";
                    msg.Style.Value = zglobal.successmsg;

                    fnFillDataGrid();
                }
                else
                {
                    msg.InnerHtml = "There is no business select yet. Cann't [Update]";
                    msg.Style.Value = zglobal.errormsg;
                }

                fnDeleteBusinessPermis();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtconformmessageValue.Value == "Yes")
                {

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "DELETE FROM glhrc42 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                            string xhrc11 = ViewState["level1"].ToString();
                            string xhrc21 = ViewState["level2"].ToString();
                            string xhrc31 = ViewState["level3"].ToString();
                            string xhrc411 = xhrc4.Text.ToString().Trim();
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();
                            query = "DELETE FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();
                            query = "DELETE FROM glhrc52 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();
                            query = "DELETE FROM glhrc51 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc21);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc31);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc411);
                            cmd.ExecuteNonQuery();

                        }

                        tran.Complete();
                        btnClear_Click(null, null);
                        msg.InnerHtml = "Delete comlpeted";
                        msg.Style.Value = zglobal.successmsg;

                    }
                    //msg.InnerHtml = "Delete comlpeted";
                    //msg.Style.Value = zglobal.successmsg;

                    fnFillDataGrid();

                    //fnDeleteBusinessPermis();
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ViewState["level1"] == null)
                //{
                //    //SqlConnection conn1;
                //    //conn1 = new SqlConnection(zglobal.constring);
                //    //DataSet dts = new DataSet();

                //    //dts.Reset();


                //    //string str = "SELECT TOP 1 xhrc1 FROM glhrc11";
                //    //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //    //da.Fill(dts, "tempztcode");
                //    //DataTable dtztcode = new DataTable();
                //    //dtztcode = dts.Tables[0];

                //    //ViewState["level1"] = dtztcode.Rows[0][0].ToString();


                //    //dts.Dispose();
                //    //dtztcode.Dispose();
                //    //da.Dispose();
                //    //conn1.Dispose();
                //}
                Response.Redirect("~/forms/BMERP/Accounts/glhrc.aspx?level1="+Server.UrlEncode(ViewState["level1"].ToString()));
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["level4"] == null)
                {
                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts = new DataSet();

                    dts.Reset();


                    string str = "SELECT TOP 1 xhrc4 FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3";
                    SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc2", ViewState["level2"]);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc3", ViewState["level3"]);
                    da.Fill(dts, "tempztcode");
                    DataTable dtztcode = new DataTable();
                    dtztcode = dts.Tables[0];

                    ViewState["level4"] = dtztcode.Rows[0][0].ToString();


                    dts.Dispose();
                    dtztcode.Dispose();
                    da.Dispose();
                    conn1.Dispose();
                    //ViewState["level4"] = "0";
                }
                Response.Redirect("~/forms/BMERP/Accounts/glhrc5.aspx?level1=" + Server.UrlEncode(ViewState["level1"].ToString()) + "&level2=" + Server.UrlEncode(ViewState["level2"].ToString()) + "&level3=" + Server.UrlEncode(ViewState["level3"].ToString()) + "&level4=" + Server.UrlEncode(ViewState["level4"].ToString()));
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ViewState["level1"] == null)
                //{
                //    //SqlConnection conn1;
                //    //conn1 = new SqlConnection(zglobal.constring);
                //    //DataSet dts = new DataSet();

                //    //dts.Reset();


                //    //string str = "SELECT TOP 1 xhrc1 FROM glhrc11";
                //    //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //    //da.Fill(dts, "tempztcode");
                //    //DataTable dtztcode = new DataTable();
                //    //dtztcode = dts.Tables[0];

                //    //ViewState["level1"] = dtztcode.Rows[0][0].ToString();


                //    //dts.Dispose();
                //    //dtztcode.Dispose();
                //    //da.Dispose();
                //    //conn1.Dispose();
                //}
                Response.Redirect("~/forms/BMERP/Accounts/glhrc2.aspx?level1=" + Server.UrlEncode(ViewState["level1"].ToString()) + "&level2=" + Server.UrlEncode(ViewState["level2"].ToString()));
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        public void fnGoToNextLevel(object sender, EventArgs e)
        {
            try
            {
                //if (ViewState["level1"] == null)
                //{
                //    SqlConnection conn1;
                //    conn1 = new SqlConnection(zglobal.constring);
                //    DataSet dts = new DataSet();

                //    dts.Reset();


                //    string str = "SELECT TOP 1 xhrc1 FROM glhrc11";
                //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //    da.Fill(dts, "tempztcode");
                //    DataTable dtztcode = new DataTable();
                //    dtztcode = dts.Tables[0];

                //    ViewState["level1"] = dtztcode.Rows[0][0].ToString();

                //    dts.Reset();
                //    str = "SELECT xhrc2 FROM glhrc21 WHERE xhrc1=@xhrc1";
                //    da = new SqlDataAdapter(str, conn1);
                //    da.SelectCommand.Parameters.AddWithValue("@xhrc1", ViewState["level1"]);
                //    da.Fill(dts, "tempztcode");
                //    dtztcode.Reset();
                //    dtztcode = dts.Tables[0];

                //    ViewState["level2"] = dtztcode.Rows[0][0].ToString();

                //    dts.Dispose();
                //    dtztcode.Dispose();
                //    da.Dispose();
                //    conn1.Dispose();
                //}
                Response.Redirect("~/forms/BMERP/Accounts/glhrc5.aspx?level1=" + Server.UrlEncode(ViewState["level1"].ToString()) + "&level2=" + Server.UrlEncode(ViewState["level2"].ToString()) + "&level3=" + Server.UrlEncode(ViewState["level3"].ToString()) + "&level4=" + Server.UrlEncode(ViewState["level4"].ToString()) + "&level5=" + Server.UrlEncode(((LinkButton)sender).Text));
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ViewState["level1"] == null)
                //{
                //    //SqlConnection conn1;
                //    //conn1 = new SqlConnection(zglobal.constring);
                //    //DataSet dts = new DataSet();

                //    //dts.Reset();


                //    //string str = "SELECT TOP 1 xhrc1 FROM glhrc11";
                //    //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //    //da.Fill(dts, "tempztcode");
                //    //DataTable dtztcode = new DataTable();
                //    //dtztcode = dts.Tables[0];

                //    //ViewState["level1"] = dtztcode.Rows[0][0].ToString();


                //    //dts.Dispose();
                //    //dtztcode.Dispose();
                //    //da.Dispose();
                //    //conn1.Dispose();
                //}
                Response.Redirect("~/forms/BMERP/Accounts/glhrc3.aspx?level1=" + Server.UrlEncode(ViewState["level1"].ToString()) + "&level2=" + Server.UrlEncode(ViewState["level2"].ToString()) + "&level3=" + Server.UrlEncode(ViewState["level3"].ToString()));
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

    }
}