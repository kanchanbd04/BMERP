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
    public partial class prmst : System.Web.UI.Page
    {

        string pk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("prmst");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                zactive.Checked = true;

                xlocation.Items.Add("[Select]");

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                ////////////////////////////////////

             
                DataSet dts12 = new DataSet();


                dts12.Reset();
                string str12 = "SELECT xname FROM ztcode  WHERE xtype='Designation' AND zactive=1 ORDER BY xname";
                SqlDataAdapter da12 = new SqlDataAdapter(str12, conn1);
                da12.Fill(dts12, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts12.Tables[0];

                xdesig.Items.Add("[Select]");

                if (dtztcode.Rows.Count > 0)
                {
                    for (int i = 0; i < dtztcode.Rows.Count; i++)
                    {
                        xdesig.Items.Add(dtztcode.Rows[i][0].ToString());
                    }
                }

                xdesig.Text = "[Select]";
                //////////////////////////////////////////////////////////

                dts.Reset();
                string str = "SELECT xcname FROM ztcounter WHERE zactive=1 ORDER BY xcname";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.Fill(dts, "tempdt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                if (dttemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {
                        xlocation.Items.Add(dttemp.Rows[i][0].ToString());
                    }
                }

                dts.Dispose();
                dttemp.Dispose();
                da.Dispose();
                conn1.Dispose();

                xlocation.Text = "[Select]";

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
            string str = "SELECT * FROM ztemp  ORDER BY xemp";
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
                query = "INSERT INTO prmst" +
                               "(zid,xemp,xname,xjoindate,xdesig,xlocation,xfather,xadd,xmobile,xdtwotax,xyesno,zactive) " +
                               "VALUES (@zid,@xemp,@xname,@xjoindate,@xdesig,@xlocation,@xfather,@xadd,@xmobile,@xdtwotax,@xyesno,@zactive) ";
            }
            else if (str == "update")
            {

                query = "UPDATE prmst SET " +
                                      "zid=@zid,xname=@xname,xjoindate=@xjoindate,xdesig=@xdesig,xlocation=@xlocation,xfather=@xfather,xadd=@xadd,xmobile=@xmobile,xdtwotax=@xdtwotax,zactive=@zactive " +
                                      "WHERE xemp=@xemp";

            }
            else
            {
                query = "DELETE FROM ztcounter WHERE xid=@xid";
            }
            dataCmd.CommandText = query;

            string xemp1;
            xemp1 = xemp.Text.ToString();
        



            dataCmd.Parameters.AddWithValue("@xemp", xemp1);

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
            da1.SelectCommand.Parameters.AddWithValue("@zorg",zorg);

            da1.Fill(dts1, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dttemp1 = new DataTable();
            dttemp1 = dts1.Tables[0];

            string zid1 = dttemp1.Rows[0][0].ToString();

            //////////////////////////////


            string xname1 = xname.Text.ToString().Trim();
            string xjoindate1 = xjoindate.Text.ToString().Trim();
            string xdesig1 = xdesig.Text.ToString().Trim();
            string xlocation1 = xlocation.Text.ToString().Trim();
            string xfather1 = xfather.Text.ToString().Trim();
            decimal xdtwotax1 = decimal.Parse( xdtwotax.Text.ToString());
            string xadd1 = xadd.Value.ToString().Trim();
            string xmobile1 = xmobile.Text.ToString().Trim();
            string xyesno = "yes";
            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }


            dataCmd.Parameters.AddWithValue("@xname", xname1);
            dataCmd.Parameters.AddWithValue("@zid", zid1);
            dataCmd.Parameters.AddWithValue("@xjoindate", xjoindate1);
            dataCmd.Parameters.AddWithValue("@xdesig", xdesig1);
            dataCmd.Parameters.AddWithValue("@xlocation", xlocation1);
            dataCmd.Parameters.AddWithValue("@xfather", xfather1);
            dataCmd.Parameters.AddWithValue("@xdtwotax", xdtwotax1);
            dataCmd.Parameters.AddWithValue("@xadd", xadd1);
            dataCmd.Parameters.AddWithValue("@xmobile", xmobile1);
            dataCmd.Parameters.AddWithValue("@xyesno", xyesno);
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
                xemp.ReadOnly = true;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xemp1 = ((LinkButton)sender).Text;

                xemp.Text = ((LinkButton)sender).Text;

                string str = "SELECT (select zorg from zbusiness where zbusiness.zid=prmst.zid) as zid,xname,xjoindate,xdesig,xlocation,xfather,xadd,xmobile,xdtwotax,zactive FROM prmst where xemp=@xemp AND xyesno='yes'";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                da.Fill(dts, "tempzuser");

                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];

                
                xname.Text = dtzuser.Rows[0][1].ToString();
                DateTime dt = Convert.ToDateTime( dtzuser.Rows[0][2].ToString());
                xjoindate.Text = dt.ToShortDateString();
                xdesig.Text = dtzuser.Rows[0][3].ToString();
                xlocation.Text = dtzuser.Rows[0][4].ToString();
                xfather.Text = dtzuser.Rows[0][5].ToString();


                xadd.Value = dtzuser.Rows[0][6].ToString();
                xmobile.Text = dtzuser.Rows[0][7].ToString();
                xdtwotax.Text = dtzuser.Rows[0][8].ToString();

                zid.Text = dtzuser.Rows[0][0].ToString();

                if ((int)dtzuser.Rows[0][9] == 1)
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
            xemp.Text = "";
            xemp.ReadOnly = false;
            xname.Text = "";
            xjoindate.Text = "";
            xdesig.Text = "[Select]";
            xlocation.Text = "[Select]";
            xfather.Text = "";
            xdtwotax.Text = "";
            xadd.Value = "";
            xmobile.Text = "";
            zid.Text = "[Select]";
            zactive.Checked = true;
            msg.InnerHtml = "";
        }

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xemp FROM prmst where xyesno='yes' ";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == xemp.Text.ToString().Trim())
                    {
                        pk = xemp.Text.ToString();
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
                if (xemp.Text == "")
                {
                    msg.InnerHtml = "Please enter employee ID";
                    return;
                }
                if (xname.Text == "")
                {
                    msg.InnerHtml = "Please enter employee Name";
                    return;
                }
                if (zid.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select unit";
                    return;
                }
                if (xdtwotax.Text == "")
                {
                    msg.InnerHtml = "Please select salary";
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
                if (xemp.Text == "")
                {
                    msg.InnerHtml = "Please enter employee ID";
                    return;
                }
                if (xname.Text == "")
                {
                    msg.InnerHtml = "Please enter employee Name";
                    return;
                }
                if (zid.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select unit";
                    return;
                }
                if (xdtwotax.Text == "")
                {
                    msg.InnerHtml = "Please select salary";
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