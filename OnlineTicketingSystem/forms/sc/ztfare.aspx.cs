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
    public partial class ztfare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztfare");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                GridView2.Visible = false;
                msg.InnerText = "";

                xfareid.Text = "";

                zactive.Checked = true;

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                string str = "SELECT xname FROM ztcode  WHERE xtype='Bus' AND zactive=1 ORDER BY xname";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                if (dtztcode.Rows.Count > 0)
                {
                    xbustype.Items.Add("[Select]");
                    for (int i = 0; i < dtztcode.Rows.Count; i++)
                    {
                        xbustype.Items.Add(dtztcode.Rows[i][0].ToString());
                    }

                    xbustype.Text = "[Select]";
                }

                str = "SELECT (xmf + '-' + xmt) as mainrt, xmrid FROM ztrtm WHERE zactive=1 ";

                SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);
                da2.Fill(dts, "tempdtrtm");
                DataTable dtrtm = new DataTable();
                dtrtm = dts.Tables[1];

                if (dtrtm.Rows.Count > 0)
                {
                    xmrid.Items.Add("[Select]");
                    for (int i = 0; i < dtrtm.Rows.Count; i++)
                    {
                        xmrid.Items.Add(dtrtm.Rows[i][0].ToString());
                    }
                    xmrid.Text = "[Select]";
                }



                populateDataGrid();

            }
        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xfareid,xbustype,(select (xmf + '-' + xmt) from ztrtm where ztrtm.xmrid=ztfare.xmrid ) as xmrid,(select (xsf + '-' + xst) from ztrts where ztrts.xsrid=ztfare.xsrid ) as xsrid,xfare, zactive, xapprove FROM ztfare  ORDER BY xfareid";
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
                msg.InnerHtml = "";
                xfareid.Text = ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xfareid1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM ztfare WHERE xfareid=@xfareid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xfareid", xfareid1);
                da.Fill(dts, "tempzuser");

                DataTable dtz = new DataTable();
                dtz = dts.Tables[0];

                xbustype.Text = dtz.Rows[0][1].ToString();
                xfare.Text = dtz.Rows[0][4].ToString();
              

                if ((int)dtz.Rows[0][5] == 1)
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }

                ////////////////////////////////////////////
                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts1 = new DataSet();
                dts1.Reset();
                string str1 = "SELECT (xmf + '-' + xmt) FROM ztrtm WHERE xmrid=@xmrid";
                SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);

                string mrid1 = dtz.Rows[0][2].ToString();


                da1.SelectCommand.Parameters.AddWithValue("@xmrid", mrid1);

                da1.Fill(dts1, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode1 = new DataTable();
                dtztcode1 = dts1.Tables[0];

                xmrid.Text=dtztcode1.Rows[0][0].ToString();

                xmrid_SelectedIndexChanged(null, null);

                if (dtz.Rows[0][2].ToString() == dtz.Rows[0][3].ToString())
                {
                   xsrid.Text = xmrid.Text;
                }
                else
                {
                    SqlConnection conn111;
                    conn111 = new SqlConnection(zglobal.constring);
                    DataSet dts11 = new DataSet();
                    dts11.Reset();
                    string str11 = "SELECT (xsf + '-' + xst) FROM ztrts WHERE xsrid=@xsrid";
                    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn111);

                    string srid1 = dtz.Rows[0][3].ToString();


                    da11.SelectCommand.Parameters.AddWithValue("@xsrid", srid1);

                    da11.Fill(dts11, "tempzt");
                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable dtztcode11 = new DataTable();
                    dtztcode11 = dts11.Tables[0];

                    xsrid.Text = dtztcode11.Rows[0][0].ToString();
                }
                /////////////////////////////////////////////

                DateTime dt1 = Convert.ToDateTime(dtz.Rows[0][8].ToString());
                xeffdate.Text = dt1.ToShortDateString();

                if (dtz.Rows[0][9].ToString() == "Confirmed")
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
                //dtz.Dispose();
                da.Dispose();
                conn1.Dispose();

                /* Fare History */
                GridView2.Visible = true;

                SqlConnection conn123;
                conn123 = new SqlConnection(zglobal.constring);
                DataSet dts123 = new DataSet();
                dts123.Reset();
                string str123 = "SELECT * FROM ztfarehis WHERE xsrid=@xsrid and xbustype=@xbustype";
                SqlDataAdapter da123 = new SqlDataAdapter(str123, conn123);

                string srid123 = dtz.Rows[0][3].ToString();
                string xbustype123 = dtz.Rows[0][1].ToString();


                da123.SelectCommand.Parameters.AddWithValue("@xsrid", srid123);
                da123.SelectCommand.Parameters.AddWithValue("@xbustype", xbustype123);

                da123.Fill(dts123, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode123 = new DataTable();
                dtztcode123 = dts123.Tables[0];
                GridView2.DataSource = dtztcode123;
                GridView2.DataBind();

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void xmrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                string str = "SELECT (xsf + '-' + xst) as xsubrt FROM ztrts WHERE zactive=1 AND xmrid=(select xmrid from ztrtm where xmf=@xmf and xmt=@xmt)";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                string[] mrid = xmrid.Text.ToString().Split('-');

                string xmf = mrid[0];
                string xmt = mrid[1];

                da.SelectCommand.Parameters.AddWithValue("@xmf",xmf);
                da.SelectCommand.Parameters.AddWithValue("@xmt",xmt);

                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];


                xsrid.Items.Clear();

                xsrid.Items.Add("[Select]");
                xsrid.Items.Add(xmrid.Text.ToString());

                if (dtztcode.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dtztcode.Rows.Count; i++)
                    {
                        xsrid.Items.Add(dtztcode.Rows[i][0].ToString());
                    }

                    xsrid.Text = "[Select]";
                }
               
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            msg.InnerText = "";
            zactive.Checked = true;
            xfareid.Text = "";
            xfare.Text = "";
            xsrid.Items.Clear();
            xmrid.Text = "[Select]";
            xbustype.Text = "[Select]";
            xeffdate.Text = "";
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            GridView2.Visible = false;
            
        }

        string pk;
        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xfareid FROM ztfare ";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == xfareid.Text.ToString().Trim())
                    {
                        pk = xfareid.Text.ToString();
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


        private int maxrow(string query)
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = query;

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);



            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];







            int maxrow;
            if (!Convert.IsDBNull(dttemp.Rows[0][0]))
            {
                int srtnm = int.Parse(dttemp.Rows[0][0].ToString());
                maxrow = srtnm + 1;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = 100;
            }


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
                query = "INSERT INTO ztfare" +
                               "(xfareid,xbustype,xmrid,xsrid,xfare,zactive,xcreatedby,xcreatedt,xeffdate,xapprove) " +
                               "VALUES (@xfareid,@xbustype,@xmrid,@xsrid,@xfare,@zactive,@xcreatedby,@xcreatedt,@xeffdate,'New') ";
            }
            else if (str == "update")
            {
                query = "UPDATE ztfare SET " +
                               "xbustype=@xbustype,xmrid=@xmrid,xsrid=@xsrid,xfare=@xfare,zactive=@zactive,xeffdate=@xeffdate " +
                               "WHERE xfareid=@xfareid";
            }
            else if (str == "confirm")
            {
                query = "UPDATE ztfare SET " +
                                   "zactive=1, xapprove='Confirmed' " +
                                   "WHERE xfareid=@xfareid";
            }
            else
            {
                query = "DELETE FROM ztfare WHERE xfareid=@xfareid";
            }
            dataCmd.CommandText = query;

            int xfareid1;
            if (str == "save")
            {
                xfareid1 = maxrow("select max(xfareid) from ztfare");
            }
            else
            {
                xfareid1 = int.Parse(xfareid.Text.ToString());
            }

            dataCmd.Parameters.AddWithValue("@xfareid", xfareid1);

            //if (str != "delete")
            //{


            string xbustype1 = xbustype.Text.ToString().Trim();


            /////////////////////////////////////////////

            string qur = "select xmrid from ztrtm where xmf=@xmf and xmt=@xmt";
            SqlDataAdapter da = new SqlDataAdapter(qur, conn1);
            DataSet dts = new DataSet();
            string[] mrid = xmrid.Text.ToString().Split('-');
            string xmf = mrid[0];
            string xmt = mrid[1];
            da.SelectCommand.Parameters.AddWithValue("@xmf", xmf);
            da.SelectCommand.Parameters.AddWithValue("@xmt", xmt);
            da.Fill(dts, "temp");
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];

            /////////////////////////////////////////////

            string xmrid1 = dttemp.Rows[0][0].ToString();


            /////////////////////////////////////////////
            string xsrid1;

            if (xsrid.Text != xmrid.Text)
            {
                string qur1 = "select xsrid from ztrts where xsf=@xsf and xst=@xst and xmrid=@xmrid";
                SqlDataAdapter da1 = new SqlDataAdapter(qur1, conn1);
                DataSet dts1 = new DataSet();
                string[] srid = xsrid.Text.ToString().Split('-');
                string xsf = srid[0];
                string xst = srid[1];
                da1.SelectCommand.Parameters.AddWithValue("@xsf", xsf);
                da1.SelectCommand.Parameters.AddWithValue("@xst", xst);
                da1.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                da1.Fill(dts1, "temp");
                DataTable dttemp1 = new DataTable();
                dttemp1 = dts1.Tables[0];

                xsrid1 = dttemp1.Rows[0][0].ToString();
            }
            else
            {
                xsrid1 = xmrid1;
            }

            /////////////////////////////////////////////

           

            string xfare1 = xfare.Text.ToString(); 

            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }

            string xcreatedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            string xcreatedt = DateTime.Now.ToString();
            string xeffdate1 = xeffdate.Text.ToString().Trim();

            dataCmd.Parameters.AddWithValue("@xbustype", xbustype1);
            dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);
            dataCmd.Parameters.AddWithValue("@xsrid", xsrid1);
            dataCmd.Parameters.AddWithValue("@xfare", xfare1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
            dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby);
            dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt);
            dataCmd.Parameters.AddWithValue("@xeffdate", xeffdate1);

           

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
                xfareid.Text = Convert.ToString( xfareid1);
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xbustype.Text != "[SELECT]" && xmrid.Text != "[Select]" && xsrid.Text != "[Select]" && xeffdate.Text!="")
                {
                    checkpk();

                    if (pk == "false")
                    {


                        saveAndUpdate("save");





                    }
                    else
                    {
                        string message = "Can not insert duplacate data.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                        
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                    }
                }
                else
                {
                    msg.InnerHtml = "Please Fill all the mendatory field";
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
                GridView2.Visible = false;
                msg.InnerText = "";
                if (xbustype.Text != "[SELECT]" && xmrid.Text != "[Select]" && xsrid.Text != "[Select]" && xeffdate.Text != "")
                {
                    checkpk();

                    if (pk != "false")
                    {


                        saveAndUpdate("update");





                    }
                    else
                    {
                        string message = "Data not found";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);

                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                    }
                }
                else
                {
                    msg.InnerHtml = "Please Fill all the mendatory field";
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
                GridView2.Visible = false;
                msg.InnerText = "";
                if (txtconformmessageValue.Value == "Yes")
                {

                    if (xfareid.Text != "")
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

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            try
            {
                GridView2.Visible = false;
                msg.InnerText = "";
                if (comfirmmsg.Value == "Yes")
                {

                    if (xfareid.Text != "")
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