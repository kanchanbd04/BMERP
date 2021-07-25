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
    public partial class ztbusexch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Check Permission
                    SiteMaster sm = new SiteMaster();
                    string s = sm.fnChkPagePermis("ztbusexch");
                    if (s == "n" || s == "e")
                    {
                        HttpContext.Current.Session["curuser"] = null;
                        Session.Abandon();
                        Response.Redirect("~/forms/zlogin.aspx");
                    }

                    xfdate.Text = DateTime.Now.ToShortDateString();
                    xtdate.Text = xfdate.Text.ToString().Trim();
                    fnxcoach();
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (xfdate.Text == "")
                {
                    msg.InnerHtml = "Please select date.";
                    xfdate.Focus();
                    return;
                }
                else if (xfcoach.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select coach from.";
                    xfcoach.Focus();
                    return;
                }
                else if (xtcoach.Text == "[Select]")
                {
                    msg.InnerHtml = "Please select coach to.";
                    xtcoach.Focus();
                    return;
                }
                else if (xfmrid.Value != xtmrid.Value)
                {
                    msg.InnerHtml = "Route must be same.";
                    return;
                }
                
                /*Chack the coach if has seat sold or booking*/

                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string str2;
                

                str2 = "SELECT * from ztsaled where xdate=@xdate and xcoach=@xcoach";
              

                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
                string xdate123 = xtdate.Text.ToString().Trim();
                string xcoach123 = xtcoach.Text.ToString().Trim();
                //txtDue.Text = date;
                da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate123);
                da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach123);
                da2.Fill(dts2, "temp");
                DataTable zttemp123 = new DataTable();
                zttemp123 = dts2.Tables["temp"];

                if (zttemp123.Rows.Count > 0)
                {
                    msg.InnerHtml = "Coach(To) must be empty.";
                    return;
                }

                ///////////////////////////////////////////////

                using (TransactionScope tran = new TransactionScope())
                {
                    //////ztsalh xid////////
                    SqlConnection conn222;
                    conn222 = new SqlConnection(zglobal.constring);
                    DataSet dts222 = new DataSet();
                    dts222.Reset();

                    string str222 = "select top 1 xid from ztsaled where xdate=@xdate and xcoach=@xcoach";
                    SqlDataAdapter da222 = new SqlDataAdapter(str222, conn222);

                    da222.SelectCommand.Parameters.AddWithValue("@xdate", xfdate.Text.ToString().Trim());
                    da222.SelectCommand.Parameters.AddWithValue("@xcoach", xfcoach.Text.ToString().Trim());
                    

                    da222.Fill(dts222, "temp");
                    DataTable dtztemp = new DataTable();
                    dtztemp = dts222.Tables["temp"];

                    string xid11 = dtztemp.Rows[0][0].ToString();

                    ////////////////////////




                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    //query = "UPDATE ztsaleh SET " +
                    //            " xcoach=@xcoach " +
                    //            " WHERE xid=@xid ";
                    query = "UPDATE ztsaleh SET " +
                               " xcoach=@xtcoach " +
                               " WHERE xdate=@xdate and xcoach=@xcoach ";

                    dataCmd.CommandText = query;

                    string xid1 = xid11;
                    string xcoach1 = xtcoach.Text.ToString().Trim();


                    //dataCmd.Parameters.Clear();
                   // dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.Parameters.AddWithValue("@xtcoach", xcoach1);
                    dataCmd.Parameters.AddWithValue("@xdate", xfdate.Text.ToString().Trim());
                    dataCmd.Parameters.AddWithValue("@xcoach", xfcoach.Text.ToString().Trim());

                    conn1.Close();
                    conn1.Open();
                    dataCmd.ExecuteNonQuery();

                    query = "UPDATE ztsaled SET " +
                                    "  xcoach=@xtcoach " +
                                    " WHERE xdate=@xdate and xcoach=@xfcoach";
                    
                    dataCmd.CommandText = query;
                    dataCmd.Parameters.Clear();

                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.Parameters.AddWithValue("@xtcoach", xcoach1);
                    dataCmd.Parameters.AddWithValue("@xdate", xfdate.Text.ToString().Trim());
                    dataCmd.Parameters.AddWithValue("@xfcoach", xfcoach.Text.ToString().Trim());

                    dataCmd.ExecuteNonQuery();

                    query = "INSERT INTO ztbusexch " +
                              " (xtcd,xfdate,xfcoach,xfroute,xtdate,xtcoach,xtroute,xcreatedby,xcreatedt,xloc) " +
                              " VALUES (@xtcd,@xfdate,@xfcoach,@xfroute,@xtdate,@xtcoach,@xtroute,@xcreatedby,@xcreatedt,@xloc) ";


                    string xtcd1 = zglobal.fnmaxid("SELECT max(xtcd) FROM ztbusexch where getdate() between @firstdate and @lastdate");
                    string xfdate1 = xfdate.Text.ToString().Trim();
                    string xfcoach1 = xfcoach.Text.ToString().Trim();
                    string xfroute1 = xfmrid.Value.ToString().Trim();
                    string xtdate1 = xtdate.Text.ToString().Trim();
                    string xtcoach1 = xtcoach.Text.ToString().Trim();
                    string xtroute1 = xtmrid.Value.ToString().Trim();
                    string xcreatedby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    DateTime xcreatedt1 = DateTime.Now;
                    string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    dataCmd.CommandText = query;
                    dataCmd.Parameters.Clear();

                    dataCmd.Parameters.AddWithValue("@xtcd",xtcd1);
                    dataCmd.Parameters.AddWithValue("@xfdate", xfdate1);
                    dataCmd.Parameters.AddWithValue("@xfcoach", xfcoach1);
                    dataCmd.Parameters.AddWithValue("@xfroute", xfroute1);
                    dataCmd.Parameters.AddWithValue("@xtdate", xtdate1);
                    dataCmd.Parameters.AddWithValue("@xtcoach", xtcoach1);
                    dataCmd.Parameters.AddWithValue("@xtroute", xtroute1);
                    dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby1);
                    dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt1);
                    dataCmd.Parameters.AddWithValue("@xloc", xloc1);


                    dataCmd.ExecuteNonQuery();



                    conn1.Close();

                    tran.Complete();
                }

                msg.InnerHtml = "Successfully Exchange Bus.";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void xfdate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                xtdate.Text = xfdate.Text.ToString().Trim();
                fnxcoach();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }


        }

        protected void fnxcoach()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT distinct xcoachno FROM zttrip  WHERE @xdate between xstdt and xendt AND zactive=1 ORDER BY xcoachno";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xdate1 = xfdate.Text.ToString();
            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                xfcoach.Items.Clear();
                xtcoach.Items.Clear();

                xfcoach.Items.Add(new ListItem("[Select]", string.Empty));
                xtcoach.Items.Add(new ListItem("[Select]", string.Empty));

                for (int i = 0; i < dtztcode.Rows.Count; i++)
                {
                    xfcoach.Items.Add(dtztcode.Rows[i][0].ToString());
                    xtcoach.Items.Add(dtztcode.Rows[i][0].ToString());
                }

                xfcoach.Text = "";
                xtcoach.Text = "";
            }
            else
            {
                xfcoach.Items.Clear();
                xtcoach.Items.Clear();

                xfcoach.Items.Add(new ListItem("[Select]", string.Empty));
                xtcoach.Items.Add(new ListItem("[Select]", string.Empty));
            }
           
        }

        protected void fnSelRoute(string q)
        {
            try
            {
                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts1 = new DataSet();
                dts1.Reset();
                string str1 = "SELECT (SELECT (xmf + '-' + xmt) FROM ztrtm WHERE ztrtm.xmrid=ztcoach.xmrid) as xdeptplace,xmrid FROM ztcoach WHERE xcoachno = @xcoachno";
                SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);

                string xcoachno11;
                if (q == "f")
                {
                    xcoachno11 = xfcoach.Text.ToString();
                }
                else
                {
                    xcoachno11 = xtcoach.Text.ToString();
                }


                da1.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno11);

                da1.Fill(dts1, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode1 = new DataTable();
                dtztcode1 = dts1.Tables[0];

                if (q == "f")
                {
                    xfroute.Text = dtztcode1.Rows[0][0].ToString();
                    xfmrid.Value = dtztcode1.Rows[0][1].ToString();
                }
                else
                {
                    xtroute.Text = dtztcode1.Rows[0][0].ToString();
                    xtmrid.Value = dtztcode1.Rows[0][1].ToString();
                }
                
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void xfcoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnSelRoute("f");
        }

        protected void xtcoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnSelRoute("t");
        }

    }
}