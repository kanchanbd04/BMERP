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
    public partial class ztdriver : System.Web.UI.Page
    {

        string pk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztdriver");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }


                zactive.Checked = true;
                xdname.ReadOnly = true;

                ///////////////////////////////////////

                xdriver.Items.Add("[Select]");

                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts1 = new DataSet();


                dts1.Reset();
                string str1 = "SELECT xemp FROM prmst WHERE xyesno ='yes' and zactive=1 ORDER BY xemp";
                SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);
                da1.Fill(dts1, "tempdt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dttemp1 = new DataTable();
                dttemp1 = dts1.Tables[0];

                if (dttemp1.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemp1.Rows.Count; i++)
                    {
                        xdriver.Items.Add(dttemp1.Rows[i][0].ToString());
                    }
                }

                dts1.Dispose();
                dttemp1.Dispose();
                da1.Dispose();
                conn11.Dispose();

                xdriver.Text = "[Select]";

                /////////////////////////////////////////

                populateDataGrid();
            }
        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xdriver,xdname,xbusno,zactive FROM ztdriver  ORDER BY xdriver";
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

        protected void xdriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts1 = new DataSet();


                dts1.Reset();
                string str1 = "SELECT xname FROM prmst WHERE xemp=@xemp";


                SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);

                string xemp1 = xdriver.Text.ToString();
                da1.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);

                da1.Fill(dts1, "tempdt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dttemp1 = new DataTable();
                dttemp1 = dts1.Tables[0];

                xdname.Text=dttemp1.Rows[0][0].ToString();
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
                query = "INSERT INTO ztdriver" +
                               "(xdriver,xdname,xbusno,xdlicence,xdesc,zactive) " +
                               "VALUES (@xdriver,@xdname,@xbusno,@xdlicence,@xdesc,@zactive) ";
            }
            else if (str == "update")
            {

                query = "UPDATE ztdriver SET " +
                                      "xdname=@xdname,xbusno=@xbusno,xdlicence=@xdlicence,xdesc=@xdesc,zactive=@zactive " +
                                      "WHERE xdriver=@xdriver";

            }
            else
            {
                query = "";
            }
            dataCmd.CommandText = query;

            string xdriver1;
            xdriver1 = xdriver.Text.ToString();




            dataCmd.Parameters.AddWithValue("@xdriver", xdriver1);

            //if (str != "delete")
            //{

           


            string xdname1 = xdname.Text.ToString().Trim();
            string xbusno1 = xbusno.Text.ToString().Trim();
            string xdlicence1 = xdlicence.Text.ToString().Trim();
            string xdesc1 = xdesc.Text.ToString().Trim();

            //string xyesno = "yes";
            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }


            dataCmd.Parameters.AddWithValue("@xdname", xdname1);
            dataCmd.Parameters.AddWithValue("@xbusno", xbusno1);
            dataCmd.Parameters.AddWithValue("@xdlicence", xdlicence1);
            dataCmd.Parameters.AddWithValue("@xdesc", xdesc1);

            //dataCmd.Parameters.AddWithValue("@xyesno", xyesno);
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

                string xdriver1 = ((LinkButton)sender).Text;

                xdriver.Text = ((LinkButton)sender).Text;

                string str = "SELECT * FROM ztdriver where xdriver=@xdriver";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xdriver", xdriver1);
                da.Fill(dts, "tempzuser");

                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];


                xdname.Text = dtzuser.Rows[0][1].ToString();
                
                xbusno.Text = dtzuser.Rows[0][2].ToString();


                xdlicence.Text = dtzuser.Rows[0][3].ToString();
                xdesc.Text = dtzuser.Rows[0][4].ToString();

                if ((int)dtzuser.Rows[0][5] == 1)
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            msg.InnerHtml = "";
            xdriver.Text = "[Select]";
            xdname.Text = "";
            xdlicence.Text = "";
            xbusno.Text = "";
            xdesc.Text = "";
            zactive.Checked = true;
        }

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xdriver FROM ztdriver";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == xdriver.Text.ToString().Trim())
                    {
                        pk = xdriver.Text.ToString();
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
                if (xdriver.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select driver";
                    return;
                }

             

                checkpk();
                if (pk == "false")
                {
                    saveAndUpdate("save");
                }
                else
                {
                    string message = "Cann't insert duplicate data";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
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
                if (xdriver.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select driver";
                    return;
                }

               
                checkpk();
                if (pk != "false")
                {
                    saveAndUpdate("update");
                }
                else
                {
                    string message = "Data not found";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}