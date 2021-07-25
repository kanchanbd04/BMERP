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
    public partial class ztrole : System.Web.UI.Page
    {
        private string pk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////Check Permission
                //SiteMaster sm = new SiteMaster();
                //string s = sm.fnChkPagePermis("ztrole");
                //if (s == "n" || s == "e")
                //{
                //    HttpContext.Current.Session["curuser"] = null;
                //    Session.Abandon();
                //    Response.Redirect("~/forms/zlogin.aspx");
                //}

                zactive.Checked = true;

                populateDataGrid();

            }
        }


        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xrole,zactive FROM ztrole  ORDER BY xrole";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempzuser");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzuser = new DataTable();
            dtzuser = dts.Tables[0];
            GridView1.DataSource = dtzuser;
            GridView1.DataBind();
            dts.Dispose();
            dtzuser.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "Role : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xrole1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM ztrole where xrole=@xrole1";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xrole1", xrole1);
                da.Fill(dts, "tempzuser");

                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];

                xrole.Text = dtzuser.Rows[0][0].ToString();
                xsrtnm.Text = dtzuser.Rows[0][1].ToString();
                xdesc.Value = dtzuser.Rows[0][2].ToString();
            
                if ((int)dtzuser.Rows[0][3] == 1)
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

        private void saveAndUpdate(string str)
        {


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn1;
            string query;
            if (str == "save")
            {
                query = "INSERT INTO ztrole" +
                               "(xrole,xsrtnm,xdesc,zactive,xpermisst) " +
                               "VALUES (@xrole,@xsrtnm,@xdesc,@zactive,@xpermisst) ";
            }
            else if (str == "update")
            {
                query = "UPDATE ztrole SET " +
                               "xsrtnm=@xsrtnm,xdesc=@xdesc,zactive=@zactive " +
                               "WHERE xrole=@xrole";
            }
            else
            {
                query = "DELETE FROM ztrole WHERE xrole=@xrole";
            }
            dataCmd.CommandText = query;

            string xrole1 = xrole.Text.ToString().Trim();

            dataCmd.Parameters.AddWithValue("@xrole", xrole1);

            //if (str != "delete")
            //{


            string xsrtnm1 = xsrtnm.Text.ToString().Trim();

            string xdesc1 = xdesc.Value.ToString().Trim();
          
            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }
          
            int xpermisst = 0;

            dataCmd.Parameters.AddWithValue("@xsrtnm", xsrtnm1);
            dataCmd.Parameters.AddWithValue("@xdesc", xdesc1);
             
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
    
            dataCmd.Parameters.AddWithValue("@xpermisst", xpermisst);

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
            string str = "SELECT xrole FROM ztrole ";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == xrole.Text.ToString().Trim())
                    {
                        pk = xrole.Text.ToString();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            xrole.Text = "";
            xsrtnm.Text = "";
            xdesc.Value = "";
            zactive.Checked = true;
            msg.InnerHtml = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xrole.Text != "")
                {
                    checkpk();

                    if (pk == "false")
                    {
                        

                        saveAndUpdate("save");





                    }
                    else
                    {
                        string message = "Add data unsuccessfull. Because user you enter already exist into database. Please enter another.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                        xrole.Focus();
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


                if (xrole.Text != "")
                {



                    checkpk();
                    if (pk != "false")
                    {
                        

                        saveAndUpdate("update");

                    }
                    else
                    {
                        msg.InnerHtml = "User you provide don't found in database, please select user from list ";
                        xrole.Focus();
                    }


                }
                else
                {
                    msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                    xrole.Focus();
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

                    if (xrole.Text != "")
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
                            xrole.Focus();
                        }


                    }
                    else
                    {
                        msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                        xrole.Focus();
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