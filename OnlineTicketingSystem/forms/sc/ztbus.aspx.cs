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
    public partial class ztbus : System.Web.UI.Page
    {

        private string pk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztbus");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

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
            string str = "SELECT xname,xsrtnm,zactive FROM ztcode  WHERE xtype='Bus' ORDER BY xname";
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
                msg.InnerHtml = "Bus : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xname1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM ztcode WHERE xtype='Bus' AND xname=@xname";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xname", xname1);
                da.Fill(dts, "tempztcode");

                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xname.Text = dtztcode.Rows[0][1].ToString();
                xsrtnm.Text = dtztcode.Rows[0][2].ToString();
                xdesc.Value = dtztcode.Rows[0][3].ToString();

                if ((int)dtztcode.Rows[0][4] == 1)
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }



                dts.Dispose();
                dtztcode.Dispose();
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
                query = "INSERT INTO ztcode" +
                               "(xtype,xname,xsrtnm,xdesc,zactive) " +
                               "VALUES ('Bus',@xname,@xsrtnm,@xdesc,@zactive) ";
            }
            else if (str == "update")
            {
                query = "UPDATE ztcode SET " +
                               "xsrtnm=@xsrtnm,xdesc=@xdesc,zactive=@zactive " +
                               "WHERE xname=@xname AND xtype='Bus'";
            }
            else
            {
                query = "DELETE FROM ztcode WHERE xname=@xname AND xtype='Bus'";
            }
            dataCmd.CommandText = query;

            string xname1 = xname.Text.ToString().Trim();

            dataCmd.Parameters.AddWithValue("@xname", xname1);

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



            dataCmd.Parameters.AddWithValue("@xsrtnm", xsrtnm1);
            dataCmd.Parameters.AddWithValue("@xdesc", xdesc1);

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
            string str = "SELECT xname FROM ztcode WHERE xtype='Bus'";
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
                    if (dtztcode.Rows[i][0].ToString().Trim() == xname.Text.ToString().Trim())
                    {
                        pk = xname.Text.ToString();
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
            xname.Text = "";
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
                if (xname.Text != "")
                {
                    if (xsrtnm.Text == "")
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
                        xname.Focus();
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


                if (xname.Text != "")
                {

                    if (xsrtnm.Text == "")
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
                        xname.Focus();
                    }


                }
                else
                {
                    msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                    xname.Focus();
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

                    if (xname.Text != "")
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
                            msg.InnerHtml = "Delete not successful. Data not found. ";
                            xname.Focus();
                        }


                    }
                    else
                    {
                        msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                        xname.Focus();
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