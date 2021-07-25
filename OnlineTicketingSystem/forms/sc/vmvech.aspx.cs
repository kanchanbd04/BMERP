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
    public partial class vmvech : System.Web.UI.Page
    {

        string pk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("vmvech");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                zactive.Checked = true;

                /////////////////////////////////////////////
                //Fill Business field////////////////////////

                zid.Items.Add("[Select]");

                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts1 = new DataSet();


                dts1.Reset();
                string str1 = "SELECT zorg FROM zbusiness WHERE xbusscat ='04-Motors Division' ORDER BY zid";
                SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);
                da1.Fill(dts1, "tempdt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dttemp1 = new DataTable();
                dttemp1 = dts1.Tables[0];

                if (dttemp1.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemp1.Rows.Count; i++)
                    {
                        zid.Items.Add(dttemp1.Rows[i][0].ToString());
                    }
                }

                dts1.Dispose();
                dttemp1.Dispose();
                da1.Dispose();
                conn11.Dispose();

                zid.Text = "[Select]";

                /////////////////////////////////////////////

                populateDataGrid();

            }

        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT * FROM ztvech  ORDER BY xvehicle";
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

        private void saveAndUpdate(string str)
        {


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn1;
            string query;
            if (str == "save")
            {
                query = "INSERT INTO vmvech" +
                               "(zid,xvehicle,xchasis,xengine,xregdate,zactive) " +
                               "VALUES (@zid,@xvehicle,@xchasis,@xengine,@xregdate,@zactive) ";
            }
            else if (str == "update")
            {

                query = "UPDATE vmvech SET " +
                                      "zid=@zid,xchasis=@xchasis,xengine=@xengine,xregdate=@xregdate,zactive=@zactive " +
                                      "WHERE xvehicle=@xvehicle";

            }
            else
            {
                query = "";
            }
            dataCmd.CommandText = query;

            string xvehicle1;
            xvehicle1 = xvehicle.Text.ToString();




            dataCmd.Parameters.AddWithValue("@xvehicle", xvehicle1);

            //if (str != "delete")
            //{

            //////////////////////////////
            //get zid of the unit//


            SqlConnection conn11;
            conn11 = new SqlConnection(zglobal.constring);
            DataSet dts1 = new DataSet();


            dts1.Reset();
            string str1 = "SELECT zid FROM zbusiness WHERE zorg=@zorg AND xbusscat ='04-Motors Division'";
            SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);

            string zorg = zid.Text.ToString();
            da1.SelectCommand.Parameters.AddWithValue("@zorg", zorg);

            da1.Fill(dts1, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dttemp1 = new DataTable();
            dttemp1 = dts1.Tables[0];

            string zid1 = dttemp1.Rows[0][0].ToString();

            //////////////////////////////


            string xchasis1 = xchasis.Text.ToString().Trim();
            string xengine1 = xengine.Text.ToString().Trim();
            string xregdate1 = xregdate.Text.ToString().Trim();
            
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


            dataCmd.Parameters.AddWithValue("@xchasis", xchasis1);
            dataCmd.Parameters.AddWithValue("@zid", zid1);
            dataCmd.Parameters.AddWithValue("@xengine", xengine1);
            dataCmd.Parameters.AddWithValue("@xregdate", xregdate1);
      
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
                xvehicle.ReadOnly = true;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xvehicle1 = ((LinkButton)sender).Text;

                xvehicle.Text = ((LinkButton)sender).Text;

                string str = "SELECT (select zorg from zbusiness where zbusiness.zid=vmvech.zid) as zid,xchasis,xengine,xregdate,zactive FROM vmvech where xvehicle=@xvehicle";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xvehicle", xvehicle1);
                da.Fill(dts, "tempzuser");

                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];


                xchasis.Text = dtzuser.Rows[0][1].ToString();
                DateTime dt = Convert.ToDateTime(dtzuser.Rows[0][3].ToString());
                xregdate.Text = dt.ToShortDateString();
                xengine.Text = dtzuser.Rows[0][2].ToString();
                

                zid.Text = dtzuser.Rows[0][0].ToString();

                if ((int)dtzuser.Rows[0][4] == 1)
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
            xvehicle.ReadOnly = false;
            xvehicle.Text = "";
            xchasis.Text = "";
            xengine.Text = "";
            xregdate.Text = "";
            zactive.Checked = true;
            zid.Text = "[Select]";
        }

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xvehicle FROM vmvech";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == xvehicle.Text.ToString().Trim())
                    {
                        pk = xvehicle.Text.ToString();
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
                if (xvehicle.Text == "")
                {
                    msg.InnerHtml = "Please enter vehicle number";
                    return;
                }
               
                if (zid.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select unit";
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
                if (xvehicle.Text == "")
                {
                    msg.InnerHtml = "Please enter vehicle number";
                    return;
                }

                if (zid.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select unit";
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