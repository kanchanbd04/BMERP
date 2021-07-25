using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.BMERP.ms.common_codes
{
    public partial class mscodes : System.Web.UI.Page
    {
        public string xtype1 = "";
        public string zid1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                xtype1 = Request.QueryString["xtype"];
                xtype2.Value = xtype1;
                zid.Value = Request.QueryString["zid"];
                sxcode.Text = xtype1;
                xtype.Text = xtype1;
                if (!IsPostBack)
                {
                    //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                    //
                    //fnFillLevel("load");
                    //fnFillDataGrid();
                    //zactive.Checked = true;
                    //key.Value = "";
                    //ViewState["key"] = null;
                    
                    zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), zid.Value.ToString());
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

                string xcode1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM mscodes WHERE xtype=@xtype and xcode=@xcode";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
                da.SelectCommand.Parameters.AddWithValue("@xcode", ((LinkButton)sender).Text);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xtype.Text = dtztcode.Rows[0]["xtype"].ToString();
                xcode.Text = dtztcode.Rows[0]["xcode"].ToString();
                xdescdet.Value = dtztcode.Rows[0]["xdescdet"].ToString();
                xcodealt.Text = dtztcode.Rows[0]["xcodealt"].ToString();
                xprops.Value = dtztcode.Rows[0]["xprops"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                zemail.Text = dtztcode.Rows[0]["zemail"].ToString();
                xemail.Text = dtztcode.Rows[0]["xemail"].ToString();
                //xstatus.Text = dtztcode.Rows[0]["xstatus"].ToString();// == String.Empty || dtztcode.Rows[0]["xstatus"].ToString() == "" ? "" : dtztcode.Rows[0]["xstatus"].ToString();

                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();

                //ViewState["level1"] = ((LinkButton)sender).Text;
                key.Value = ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                //fnFillDataGrid();
                // string status = zglobal.fnChkStatus("xstatus", "msbankd", Convert.ToInt32(key.Value.ToString()));
                //if (status == "Confirmed")
                //{
                //    fnButtonFace("confirm");
                //}
                //else
                //{
                    fnButtonFace("save");
                //}
                
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
                xtype.Text = xtype1;
                xcode.Text = "";
                xdescdet.Value = "";
                xcodealt.Text = "";
                xprops.Value = "";
                zactive.Checked = true;
                ViewState["key"] = null;
                key.Value = "";
                //fnFillLevel("load");
                //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                fnFillDataGrid();
                btnClear.Style.Value = zglobal.btncolor;
                zglobal.ltZbusinessGlmst.Clear();
                zglobal.ltZbusinessGlmstPermis.Clear();
                zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), zid.Value.ToString());
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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE "+ zid.Value.ToString() +" IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {

                    if (xcode.Text == "" || xcode.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Code";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                    

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO mscodes (ztime,xtype,xcode,xdescdet,xprops,xcodealt,zactive,zemail) " +
                                           "VALUES(@ztime,@xtype,@xcode,@xdescdet,@xprops,@xcodealt,@zactive,@zemail) ";
                            DateTime ztime = DateTime.Now;
                            string xcode1 = xcode.Text.ToString().Trim();
                            xkey = xcode1;
                            string xdescdet1 = xdescdet.Value.ToString().Trim();
                            string xcodealt1 = xcodealt.Text.ToString().Trim();
                            string xprops1 = xprops.Value.ToString().Trim();
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xcode", xcode1);
                            cmd.Parameters.AddWithValue("@xdescdet", xdescdet1);
                            cmd.Parameters.AddWithValue("@xprops", xprops1);
                            cmd.Parameters.AddWithValue("@xcodealt", xcodealt1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.ExecuteNonQuery();
                            //Insert into business table
                            int xrow2;
                            foreach (DataRow zid1 in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "mscodesbiz");

                                query = "INSERT INTO mscodesbiz (xrow,xtype,xcode,zid) " +
                                           "VALUES(@xrow,@xtype,@xcode,@zid) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xtype", xtype1);
                                cmd.Parameters.AddWithValue("@zid", zid1[zid.Value.ToString()]);
                                cmd.Parameters.AddWithValue("@xcode", xcode1);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), zid.Value.ToString());



                        fnFillDataGrid();
                        zemail.Text = HttpContext.Current.Session["curuser"].ToString();
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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE " + zid.Value.ToString() + " IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {
                    if (xcode.Text == "" || xcode.Text == string.Empty)
                    {
                        msg.InnerHtml = "Select Code";
                        msg.Style.Value = zglobal.warningmsg;
                        btnAdd.Style.Value = zglobal.btnerr;
                        return;
                    }
                   
                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "UPDATE mscodes SET zutime=@zutime,xdescdet=@xdescdet,xprops=@xprops,xcodealt=@xcodealt,xemail=@xemail,zactive=@zactive " +
                                           "WHERE xtype=@xtype and xcode=@xcode ";
                            DateTime ztime = DateTime.Now;
                            string xcode1 = xcode.Text.ToString().Trim();
                            string xdescdet1 = xdescdet.Value.ToString().Trim();
                            string xcodealt1 = xcodealt.Text.ToString().Trim();
                            string xprops1 = xprops.Value.ToString().Trim();
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zutime", ztime);
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xcode", xcode1);
                            cmd.Parameters.AddWithValue("@xdescdet", xdescdet1);
                            cmd.Parameters.AddWithValue("@xprops", xprops1);
                            cmd.Parameters.AddWithValue("@xcodealt", xcodealt1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.Parameters.AddWithValue("@xemail", zemail1);
                            cmd.ExecuteNonQuery();
                            int xrow2;

                            //Insert into business table
                            cmd.Parameters.Clear();
                            query = "DELETE FROM mscodesbiz where xtype=@xtype and xcode=@xcode";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xcode", xcode1);
                            cmd.ExecuteNonQuery();

                            //Insert into business table
                           
                            foreach (DataRow zid1 in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "mscodesbiz");

                                query = "INSERT INTO mscodesbiz (xrow,xtype,xcode,zid) " +
                                           "VALUES(@xrow,@xtype,@xcode,@zid) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xtype", xtype1);
                                cmd.Parameters.AddWithValue("@zid", zid1[zid.Value.ToString()]);
                                cmd.Parameters.AddWithValue("@xcode", xcode1);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), zid.Value.ToString());



                        fnFillDataGrid();
                        xemail.Text = HttpContext.Current.Session["curuser"].ToString();
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

                    //string status = zglobal.fnChkStatus("xstatus", "msbankd", Convert.ToInt32(key.Value.ToString()));
                    //if (status == "Confirmed")
                    //{
                    //    msg.InnerHtml = "Record Already Confirmed. Cann't Delete Record.";
                    //    msg.Style.Value = zglobal.errormsg;
                    //    return;
                    //}

                    //string xbank1 = zglobal.fnRowValue("xbank", "msbankd", Convert.ToInt32(key.Value.ToString()));

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {

                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            //DELETE Business Table
                            int xrow1 = Convert.ToInt32(key.Value.ToString());
                            string query = "DELETE FROM mscodesbiz WHERE xtype=@xtype and xcode=@xcode";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
                            cmd.ExecuteNonQuery();
                            //DELETE Detail Table
                            query = "DELETE FROM mscodes WHERE xtype=@xtype and xcode=@xcode";
                            cmd.CommandText = query;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@xtype", xtype1);
                            cmd.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
                            cmd.ExecuteNonQuery();
                            //zglobal.ltZbusinessGlmst.Clear();
                            //zglobal.ltZbusinessGlmstPermis.Clear();
                            zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), zid.Value.ToString());
                            
                           
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
            //try
            //{
            //    msg.InnerText = "";
            //    if (confmsg.Value == "Yes")
            //    {
            //        if (key.Value == "" || key.Value == string.Empty || key.Value == null)
            //        {
            //            msg.InnerHtml = "Value Not Set";
            //            msg.Style.Value = zglobal.errormsg;
            //            return;
            //        }

            //        string status = zglobal.fnChkStatus("xstatus", "msbankd", Convert.ToInt32(key.Value.ToString()));
            //        if (status == "Confirmed")
            //        {
            //            msg.InnerHtml = "Record Already Confirmed.";
            //            msg.Style.Value = zglobal.errormsg;
            //            return;
            //        }

                    

            //        using (TransactionScope tran = new TransactionScope())
            //        {
            //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //            {

            //                conn.Open();
            //                SqlCommand cmd = new SqlCommand();
            //                cmd.Connection = conn;
            //                //UPDATE Detail Table
            //                int xrow1 = Convert.ToInt32(key.Value.ToString());
            //                string query = "UPDATE msbankd SET xstatus='Confirmed' WHERE xrow=@xrow ";
            //                cmd.CommandText = query;
            //                cmd.Parameters.AddWithValue("@xrow", xrow1);
            //                cmd.ExecuteNonQuery();
                            
            //                zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), "zid7");


            //            }

            //            tran.Complete();

            //        }

            //        fnFillDataGrid();
                    
            //        msg.InnerHtml = "Record Confirmed";
            //        msg.Style.Value = zglobal.successmsg;
            //        //btnUpdate.Style.Value = zglobal.btncolor;
            //        fnButtonFace("confirm");
            //    }

            //}
            //catch (Exception exp)
            //{

            //    msg.InnerHtml = exp.Message;
            //    msg.Style.Value = zglobal.errormsg;
            //}
        }

        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xtype,xcode,xdescdet,xprops,xcodealt,zactive FROM mscodes where xtype=@xtype ORDER BY xtype,xcode";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
            //da.SelectCommand.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView1.DataSource = dtztcode;
            GridView1.DataBind();

           



            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();
        }



    }
}