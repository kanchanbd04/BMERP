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
    public partial class zttrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("zttrip");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }


                xtripid.Text = "";
                xdepttime.Text = "";
                xmrid.Text = "";

                zactive.Checked = true;

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                string str = "SELECT xcoachno FROM ztcoach  WHERE  zactive=1 AND xapprove='Confirmed' ORDER BY xcoachno";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                if (dtztcode.Rows.Count > 0)
                {
                    xcoachno1.Items.Add("[Select]");
                    for (int i = 0; i < dtztcode.Rows.Count; i++)
                    {
                        xcoachno1.Items.Add(dtztcode.Rows[i][0].ToString());
                    }

                    xcoachno1.Text = "[Select]";
                }

                str = "SELECT xcname FROM ztcounter WHERE zactive=1 ";

                SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);
                da2.Fill(dts, "tempdtrtm");
                DataTable dtrtm = new DataTable();
                dtrtm = dts.Tables[1];

                if (dtrtm.Rows.Count > 0)
                {
                    xdeptplace.Items.Add("[Select]");
                    for (int i = 0; i < dtrtm.Rows.Count; i++)
                    {
                        xdeptplace.Items.Add(dtrtm.Rows[i][0].ToString());
                    }
                    xdeptplace.Text = "[Select]";
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
            string str = "SELECT xtripid,xcoachno,xdepttime,xdeptplace,(select (xmf + '-' + xmt) from ztrtm where ztrtm.xmrid=zttrip.xmrid ) as xmrid,xstdt,xendt, zactive FROM zttrip  ORDER BY xtripid";
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
                xtripid.Text = ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xtripid1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM zttrip WHERE xtripid=@xtripid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xtripid", xtripid1);
                da.Fill(dts, "tempzuser");

                DataTable dtz = new DataTable();
                dtz = dts.Tables[0];

                xcoachno1.Text = dtz.Rows[0][1].ToString();
                xdepttime.Text = dtz.Rows[0][2].ToString();
                xdeptplace.Text = dtz.Rows[0][3].ToString();

                DateTime dt1 = Convert.ToDateTime(dtz.Rows[0][5].ToString());
                xstdt.Text = dt1.ToShortDateString();

                DateTime dt2 = Convert.ToDateTime(dtz.Rows[0][6].ToString());
                xendt.Text = dt2.ToShortDateString();

                if ((int)dtz.Rows[0][7] == 1)
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

                string mrid1 = dtz.Rows[0][4].ToString();


                da1.SelectCommand.Parameters.AddWithValue("@xmrid", mrid1);

                da1.Fill(dts1, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode1 = new DataTable();
                dtztcode1 = dts1.Tables[0];

                xmrid.Text = dtztcode1.Rows[0][0].ToString();

               

                
                /////////////////////////////////////////////



                dts.Dispose();
                dtz.Dispose();
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
            xtripid.Text = "";
            xcoachno1.Text = "[Select]";
            xdepttime.Text = "";
            xdeptplace.Text = "[Select]";
            xmrid.Text = "";
            xstdt.Text = "";
            xendt.Text = "";
            zactive.Checked = true;
        }

        string pk;
        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xtripid FROM zttrip ";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == xtripid.Text.ToString().Trim())
                    {
                        pk = xtripid.Text.ToString();
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
                query = "INSERT INTO zttrip" +
                               "(xtripid,xcoachno,xdepttime,xdeptplace,xmrid,xstdt,xendt,zactive,xcreatedby,xcreatedt) " +
                               "VALUES (@xtripid,@xcoachno,@xdepttime,@xdeptplace,@xmrid,@xstdt,@xendt,@zactive,@xcreatedby,@xcreatedt) ";
            }
            else if (str == "update")
            {
                query = "UPDATE zttrip SET " +
                               "xcoachno=@xcoachno,xdepttime=@xdepttime,xdeptplace=@xdeptplace,xmrid=@xmrid,xstdt=@xstdt,xendt=@xendt,zactive=@zactive " +
                               "WHERE xtripid=@xtripid";
            }
            else
            {
                query = "";
            }
            dataCmd.CommandText = query;

            int xtripid1;
            if (str == "save")
            {
                xtripid1 = maxrow("select max(xtripid) from zttrip");
            }
            else
            {
                xtripid1 = int.Parse(xtripid.Text.ToString());
            }

            dataCmd.Parameters.AddWithValue("@xtripid", xtripid1);

            //if (str != "delete")
            //{


            string xcoachno11 = xcoachno1.Text.ToString().Trim();


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
            

            /////////////////////////////////////////////



            string xdepttime1 = xdepttime.Text.ToString();
            string xdeptplace1 = xdeptplace.Text.ToString();
            string xstdt1 = xstdt.Text.ToString();
            string xendt1 = xendt.Text.ToString();

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

            dataCmd.Parameters.AddWithValue("@xcoachno", xcoachno11);
            dataCmd.Parameters.AddWithValue("@xdepttime", xdepttime1);
            dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);
            dataCmd.Parameters.AddWithValue("@xdeptplace", xdeptplace1);
            dataCmd.Parameters.AddWithValue("@xstdt", xstdt1);
            dataCmd.Parameters.AddWithValue("@xendt", xendt1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
            dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby);
            dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt);



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
                xtripid.Text = xtripid1.ToString();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xcoachno1.Text != "[SELECT]" && xdeptplace.Text != "[Select]" && xstdt.Text != "" && xendt.Text != "")
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
                msg.InnerText = "";
                if (xcoachno1.Text != "[SELECT]" && xdeptplace.Text != "[Select]" && xstdt.Text != "" && xendt.Text != "")
                {
                    checkpk();

                    if (pk != "false")
                    {


                        saveAndUpdate("update");





                    }
                    else
                    {
                        string message = "Data not found.";
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

        }

        protected void xcoachno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts1 = new DataSet();
                dts1.Reset();
                string str1 = "SELECT (SELECT (xmf + '-' + xmt) FROM ztrtm WHERE ztrtm.xmrid=ztcoach.xmrid) as xdeptplace, (xmrtimeh +':'+ xmrtimem + ' '+ xmrtimei) as xdepttime FROM ztcoach WHERE xcoachno = @xcoachno";
                SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);

                string xcoachno11 = xcoachno1.Text.ToString();


                da1.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno11);

                da1.Fill(dts1, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode1 = new DataTable();
                dtztcode1 = dts1.Tables[0];

                xmrid.Text = dtztcode1.Rows[0][0].ToString();
                xdepttime.Text = dtztcode1.Rows[0][1].ToString();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

    }
}