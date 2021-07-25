using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineTicketingSystem.forms.sc
{
    public partial class ztcounter : System.Web.UI.Page
    {
        string pk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztcounter");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                xid.Text = "";

                xstatus.Items.Add("[Select]");
                xstatus.Items.Add("Ownership");
                xstatus.Items.Add("Rental");
                xstatus.Items.Add("Commission");

                //Code for fill list of role

                xcity.Items.Add("[Select]");

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "SELECT xname FROM ztcode WHERE zactive=1 AND xtype='City' ORDER BY xname";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.Fill(dts, "tempdt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                if (dttemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {
                        xcity.Items.Add(dttemp.Rows[i][0].ToString());
                    }
                }

                dts.Dispose();
                dttemp.Dispose();
                da.Dispose();
                conn1.Dispose();

                xcity.Text = "[Select]";

                //End code for fill list of role

                zactive.Checked = true;

                //DateTime dt = DateTime.Now;
                //string sdt = String.Format("{0:MM/dd/yyyy}", dt);
               

                populateDataGrid();

            }
        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xid,xcname,xcontact,zactive FROM ztcounter  ORDER BY xid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "temp");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];
            GridView1.DataSource = dtztemp;
            GridView1.DataBind();
            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        private string fnmaxrow()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT MAX(xid) FROM ztcounter WHERE xcity=@xcity";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xcity1 = xcity.Text.ToString().Trim();
            da.SelectCommand.Parameters.AddWithValue("@xcity",xcity1);

            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];

           
            str = "SELECT xsrtnm FROM ztcode WHERE xname=@xname AND xtype='City' ";

            SqlDataAdapter da2 = new SqlDataAdapter(str,conn1);
            da2.SelectCommand.Parameters.AddWithValue("@xname",xcity1);
            da2.Fill(dts,"dt2");

            DataTable dtxsrtnm = new DataTable();
            dtxsrtnm = dts.Tables["dt2"];

            string srtnm="code-";
            if (!Convert.IsDBNull(dtxsrtnm.Rows[0][0]))
            {
                srtnm = dtxsrtnm.Rows[0][0].ToString() + "-";
            }

            string maxrow;
            if (!Convert.IsDBNull(dttemp.Rows[0][0]))
            {
                string s = dttemp.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 4));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "0" + s2;
                }
                maxrow = srtnm + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = srtnm + "0001";
            }

            da2.Dispose();
            da.Dispose();
            dts.Dispose();
            conn1.Dispose();

            return maxrow;

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
                query = "INSERT INTO ztcounter" +
                               "(xid,xcname,xstatus,xowners,xlandlord,xcity,xsecurity,xmntrent,xcontact,xaddress,zactive) " +
                               "VALUES (@xid,@xcname,@xstatus,@xowners,@xlandlord,@xcity,@xsecurity,@xmntrent,@xcontact,@xaddress,@zactive) ";
            }
            else if (str == "update")
            {

                query = "UPDATE ztcounter SET " +
                                      "xcname=@xcname,xstatus=@xstatus,xowners=@xowners,xlandlord=@xlandlord,xcity=@xcity,xsecurity=@xsecurity,xmntrent=@xmntrent,xcontact=@xcontact,xaddress=@xaddress,zactive=@zactive " +
                                      "WHERE xid=@xid";
                
            }
            else
            {
                query = "DELETE FROM ztcounter WHERE xid=@xid";
            }
            dataCmd.CommandText = query;

            string xid1;
            if (str == "save")
            {
                xid1 = fnmaxrow();
                xid.Text = xid1;
            }
            else
            {
                xid1 = xid.Text.ToString();
            }

            

            dataCmd.Parameters.AddWithValue("@xid", xid1);

            //if (str != "delete")
            //{


            string xcname1 = xcname.Text.ToString().Trim();
            string xstatus1 = xstatus.Text.ToString().Trim();
            string xowners1 = xowners.Text.ToString().Trim();
            string xlandlord1 = xlandlord.Text.ToString().Trim();
            string xcity1 = xcity.Text.ToString().Trim();
            string xsecurity1 = xsecurity.Text.ToString().Trim();
            string xmntrent1 = xmntrent.Text.ToString().Trim();
            string xcontact1 = xcontact.Text.ToString().Trim();
            string xaddress1 = xaddress.Value.ToString().Trim();
            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }


            dataCmd.Parameters.AddWithValue("@xcname", xcname1);
            dataCmd.Parameters.AddWithValue("@xstatus", xstatus1);
            dataCmd.Parameters.AddWithValue("@xowners", xowners1);
            dataCmd.Parameters.AddWithValue("@xlandlord", xlandlord1);
            dataCmd.Parameters.AddWithValue("@xcity", xcity1);
            dataCmd.Parameters.AddWithValue("@xsecurity", xsecurity1);
            dataCmd.Parameters.AddWithValue("@xmntrent", xmntrent1);
            dataCmd.Parameters.AddWithValue("@xcontact", xcontact1);
            dataCmd.Parameters.AddWithValue("@xaddress", xaddress1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
          

            //}

            conn1.Close();
            conn1.Open();
            dataCmd.ExecuteNonQuery();
            conn1.Close();

            //-------------------------------------------------//
            populateDataGrid();

            //-------------------------------------------------//

            dataCmd.Dispose();
            conn1.Dispose();
            if (str == "save")
            {
                msg.InnerText = "Successfully add data.";
            }
            else if (str == "update")
            {
                msg.InnerText = "Successfully update data.";
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
            string str = "SELECT xid FROM ztcounter ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempzuser");

            DataTable dtzuser = new DataTable();
            dtzuser = dts.Tables[0];

            if (dtzuser.Rows.Count > 0)
            {
                for (int i = 0; i < dtzuser.Rows.Count; i++)
                {
                    //for (int j = 0; j < 1; j++)
                    //{
                    if (dtzuser.Rows[i][0].ToString().Trim() == xid.Text.ToString().Trim())
                    {
                        pk = xid.Text.ToString();
                        //currow = i;
                        dts.Dispose();
                        dtzuser.Dispose();
                        da.Dispose();
                        conn1.Dispose();
                        return;
                    }
                    //}
                }
            }
            pk = "false";

            dts.Dispose();
            dtzuser.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xcname.Text != "" )
                {
                    checkpk();

                    if (pk == "false")
                    {
                       
                        if (xcity.Text != "[Select]")
                        {
                            saveAndUpdate("save");
                        }
                        else
                        {
                            msg.InnerText = "Please select city";
                        }




                    }
                    else
                    {
                        string message = "Add data unsuccessfull. Because user you enter already exist into database. Please enter another.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                        xcname.Focus();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            xid.Text = "";
            xcname.Text = "";
            xstatus.Text = "[Select]";
            xowners.Text = "";
            xlandlord.Text = "";
            xcity.Text = "[Select]";
            xsecurity.Text = "";
            zactive.Checked = true;
            xmntrent.Text = "";
            xcontact.Text = "";
            xaddress.Value = "";
            msg.InnerHtml = "";


        }


        //protected void btnShowPopup_Click(object sender, EventArgs e)
        //{
        //    string message = "Message from server side";
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowAlert('" + message + "');", true);
        //}

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                //msg.InnerHtml = "User : " + ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xid1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM ztcounter where xid=@xid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xid", xid1);
                da.Fill(dts, "tempzuser");

                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];

                xid.Text = dtzuser.Rows[0][0].ToString();
                xcname.Text = dtzuser.Rows[0][1].ToString();
                xstatus.Text = dtzuser.Rows[0][2].ToString();
                xowners.Text = dtzuser.Rows[0][3].ToString();
                xlandlord.Text = dtzuser.Rows[0][4].ToString();
                xcity.Text = dtzuser.Rows[0][5].ToString();
            

                xsecurity.Text = dtzuser.Rows[0][6].ToString();
                xmntrent.Text = dtzuser.Rows[0][7].ToString();
                xcontact.Text = dtzuser.Rows[0][8].ToString();
                
                xaddress.Value = dtzuser.Rows[0][9].ToString();

                if ((int)dtzuser.Rows[0][10] == 1)
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }

                dts.Dispose();
                dtzuser.Dispose();
                da.Dispose();
                conn1.Dispose();
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


                if (xcname.Text != "" && xid.Text != "")
                {



                    checkpk();
                    if (pk != "false")
                    {
                       

                        if (xcity.Text != "[Select]")
                        {
                            
                            saveAndUpdate("update");
                        }
                        else
                        {
                            msg.InnerText = "Please select city";

                        }

                    }
                    else
                    {
                        msg.InnerHtml = "User you provide don't found in database, please select user from list ";
                        xcname.Focus();
                    }


                }
                else
                {
                    msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                    xcname.Focus();
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
                            msg.InnerHtml = "User you provide don't found in database, please select user from list ";
                            xcname.Focus();
                        }


                    }
                    else
                    {
                        msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                        xcname.Focus();
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