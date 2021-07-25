using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace OnlineTicketingSystem.forms.sc
{
    public partial class ztreceive : System.Web.UI.Page
    {

        private string pk;

        public static string fnmaxid()
        {
            DateTime dt = DateTime.Now;
            DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2;
            string prefix;

            str2 = "SELECT max(xid) FROM ztmh where xdatetime between @firstdate and @lastdate and xsign=1";
            prefix = "REC";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            string firstdate = firstDate.ToString();
            string lastdate = lastDate.ToString();
            //txtDue.Text = date;
            da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstdate);
            da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastdate);
            da2.Fill(dts2, "temp");
            DataTable xid1 = new DataTable();
            xid1 = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
            {
                string s = xid1.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 3));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "0" + s2;
                }

                maxrow = prefix + "-" + dt.ToString("MMyyyy") + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = prefix + "-" + dt.ToString("MMyyyy") + "001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }

        public static string fnmaxid1()
        {
            DateTime dt = DateTime.Now;
            DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2;
            //string prefix;

            str2 = "SELECT max(xline) FROM ztmd where xdatetime between @firstdate and @lastdate";
            //prefix = "rec";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            string firstdate = firstDate.ToString();
            string lastdate = lastDate.ToString();
            //txtDue.Text = date;
            da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstdate);
            da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastdate);
            da2.Fill(dts2, "temp");
            DataTable xid1 = new DataTable();
            xid1 = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
            {
                string s = xid1.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 5));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "0" + s2;
                }

                maxrow = dt.ToString("MMyyyy") + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = dt.ToString("MMyyyy") + "00001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztreceive");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }


                xid.Text = fnmaxid();
                

                populateDataGrid();

            }
        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xid,xfromt,xtot,xtotal,xdatetime,xstatus FROM ztmh where xsign=1";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
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

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xid1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM ztmh WHERE xid=@xid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xid", xid1);
                da.Fill(dts, "tempzt");

                DataTable dtzt = new DataTable();
                dtzt = dts.Tables[0];

                xid.Text = dtzt.Rows[0][0].ToString();
                xfromt.Text = dtzt.Rows[0][1].ToString();
                xtot.Text = dtzt.Rows[0][2].ToString();
                xtotal.Text = dtzt.Rows[0][3].ToString();

                if (dtzt.Rows[0][10].ToString() == "Confirmed")
                {
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                
                dts.Dispose();
                dtzt.Dispose();
                da.Dispose();
                conn1.Dispose();
                msg.InnerHtml = "";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        private void saveAndUpdate(string str)
        {


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn1;
            string query;
            if (str == "save")
            {
                query = "INSERT INTO ztmh " +
                               " (xid,xfromt,xtot,xtotal,xfromc,xtoc,xuser,xloc,xsign,xdatetime,xstatus) " +
                               " VALUES (@xid,@xfromt,@xtot,@xtotal,@xfromc,@xtoc,@xuser,@xloc,@xsign,@xdatetime,@xstatus) ";
            }
            else if (str == "update")
            {
                query = "UPDATE ztmh SET " +
                               "xfromt=@xfromt,xtot=@xtot,xtotal=@xtotal,xfromc=@xfromc,xtoc=@xtoc,xuser=@xuser,xloc=@xloc,xsign=@xsign,xdatetime=@xdatetime,xstatus=@xstatus " +
                               "WHERE xid=@xid";
            }
            else if (str == "confirm")
            {
                query = "UPDATE ztmh SET " +
                                   "xstatus='Confirmed' " +
                                   "WHERE xid=@xid";
            }
            else
            {
                query = "DELETE FROM ztmh WHERE xid=@xid";
            }
            dataCmd.CommandText = query;

            string xid1 = xid.Text.ToString().Trim();

            dataCmd.Parameters.AddWithValue("@xid", xid1);

            //if (str != "delete")
            //{
            string xfromt1 = xfromt.Text.ToString().Trim();
            string xtot1 = xtot.Text.ToString().Trim();

            int xft = Convert.ToInt32(xfromt1);
            int xtt = Convert.ToInt32(xtot1);
            int totalt = (xtt - xft) + 1;

            if (totalt == 0)
            {
                totalt = 1;
            }

            string xtotal1 = Convert.ToString(totalt);
            string xfromc1 = "Dampara-store";
            string xtoc1 = "";
            string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
            string xsign1 = "1";
            DateTime xdatetime1 = DateTime.Now;
            string xstatus1 = "New";

            //dataCmd.Parameters.AddWithValue("@xid", xid1);
            dataCmd.Parameters.AddWithValue("@xfromt", xfromt1);

            dataCmd.Parameters.AddWithValue("@xtot", xtot1);
            dataCmd.Parameters.AddWithValue("@xtotal", xtotal1);
            dataCmd.Parameters.AddWithValue("@xfromc", xfromc1);
            dataCmd.Parameters.AddWithValue("@xtoc", xtoc1);
            dataCmd.Parameters.AddWithValue("@xuser", xuser1);
            dataCmd.Parameters.AddWithValue("@xloc", xloc1);
            dataCmd.Parameters.AddWithValue("@xsign", xsign1);
            dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime1);
            dataCmd.Parameters.AddWithValue("@xstatus", xstatus1);


            using (TransactionScope tran = new TransactionScope())
            {



                //}

                conn1.Close();
                conn1.Open();

                if (str != "delete")
                {
                    dataCmd.ExecuteNonQuery();
                }


                //operation into ztmd table//
                if (str == "update" || str == "delete")
                {
                    query = "DELETE FROM ztmd " +
                            " WHERE xid=@xid";

                    dataCmd.CommandText = query;
                    dataCmd.Parameters.Clear();
                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.ExecuteNonQuery();
                }

                if (str == "save" || str == "update")
                {
                    query = "INSERT INTO ztmd " +
                                   " (xline,xid,xticket,xdatetime) " +
                                   " VALUES (@xline,@xid,@xticket,@xdatetime) ";

                    dataCmd.CommandText = query;

                    for (int i = xft; i <= xtt; i++)
                    {
                        dataCmd.CommandText = query;

                        string xline11 = fnmaxid1();

                        dataCmd.Parameters.Clear();

                        dataCmd.Parameters.AddWithValue("@xline", xline11);
                        dataCmd.Parameters.AddWithValue("@xid", xid1);
                        dataCmd.Parameters.AddWithValue("@xticket", i);
                        dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime1);


                        dataCmd.ExecuteNonQuery();
                    }
                }

                /////////////////////////



                if (str == "delete")
                {
                    query = "DELETE FROM ztmh " +
                            " WHERE xid=@xid";

                    dataCmd.CommandText = query;
                    dataCmd.Parameters.Clear();
                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.ExecuteNonQuery();
                }

                conn1.Close();

        

                


                tran.Complete();



                dataCmd.Dispose();
                conn1.Dispose();

            }




            //-------------------------------------------------//
            populateDataGrid();

            //-------------------------------------------------//
               
            if (str == "save")
            {
                msg.InnerText = "Successfully add data.";
            }
            else if (str == "update")
            {
                msg.InnerText = "Successfully update data.";
            }
            else if (str == "confirm")
            {
                msg.InnerText = "Successfully Confirm.";
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                msg.InnerText = "Successfully delete data.";
            }

        }

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xid FROM ztmh where xsign=1";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempztcode");

            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                for (int i = 0; i < dtztcode.Rows.Count; i++)
                {
                    //for (int j = 0; j < dtztcode.Columns.Count; j++)
                    //{
                    if (dtztcode.Rows[i][0].ToString().Trim() == xid.Text.ToString().Trim())
                    {
                        pk = xid.Text.ToString();
                        //currow = i;
                        dts.Dispose();
                        dtztcode.Dispose();
                        da.Dispose();
                        conn1.Dispose();
                        return;
                    }
                    //}
                }
            }
            pk = "false";

            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            xid.Text = fnmaxid();
            pk = "";
            msg.InnerHtml = "";

            xfromt.Text = "";
            xtot.Text = "";
            xtotal.Text = "";
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnConfirm.Enabled = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xfromt.Text != "")
                {
                    if (xtot.Text == "")
                    {
                        msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                        return;
                    }
                    checkpk();

                    if (pk == "false")
                    {


                        saveAndUpdate("save");





                    }
                    else
                    {
                        string message = "Can not insert duplicate data.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                        xid.Focus();
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                    }
                }
                else
                {
                    msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                if (xid.Text != "")
                {

                    if (xtot.Text == "")
                    {
                        msg.InnerText = "Unsuccessfully update data. Please fill all the required fields, mentioned by '*'";
                        return;
                    }
                    if (xfromt.Text == "")
                    {
                        msg.InnerText = "Unsuccessfully update data. Please fill all the required fields, mentioned by '*'";
                        return;
                    }

                    checkpk();
                    if (pk != "false")
                    {


                        saveAndUpdate("update");

                    }
                    else
                    {
                        msg.InnerHtml = "Update not successful. Data not found. ";
                        
                    }


                }
                else
                {
                    msg.InnerHtml = "You didn't provide any ID. Please select ID from list.";
                    
                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtconformmessageValue.Value == "Yes")
                {

                    if (xid.Text != "")
                    {



                        checkpk();
                        if (pk != "false")
                        {
                            //string message = "Do you really want to delete?";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowYesNo('" + message + "');", true);


                            saveAndUpdate("delete");

                        }
                        else
                        {
                            msg.InnerHtml = "ID you provide don't found in database, please select ID from list ";
                           
                        }


                    }
                    else
                    {
                        msg.InnerHtml = "Delete not successful. Data not found. ";
                        
                    }
                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (comfirmmsg.Value == "Yes")
                {

                    if (xid.Text != "")
                    {

                        //if (xtot.Text == "")
                        //{
                        //    msg.InnerText = "Confirm not successfull. Please fill all the required fields, mentioned by '*'";
                        //    return;
                        //}
                        //if (xfromt.Text == "")
                        //{
                        //    msg.InnerText = "Confirm not successfull. Please fill all the required fields, mentioned by '*'";
                        //    return;
                        //}

                        checkpk();
                        if (pk != "false")
                        {
                            //string message = "Do you really want to delete?";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowYesNo('" + message + "');", true);


                            saveAndUpdate("confirm");

                        }
                        else
                        {
                            msg.InnerHtml = "ID you provide don't found in database, please select ID from list ";

                        }


                    }
                    else
                    {
                        msg.InnerHtml = "Confirm not successful. Data not found. ";

                    }
                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

       
    }
}