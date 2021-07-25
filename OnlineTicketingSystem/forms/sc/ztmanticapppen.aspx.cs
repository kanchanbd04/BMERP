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
    public partial class ztmanticapppen : System.Web.UI.Page
    {
        private void fnfillDataGrid()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xrow,xreqdt,xdate,xtime,xcoach,xseat,(select route from ztroute where srt=xroute) as xroute,(select xname from ztsaleh where ztsaleh.xid=ztmanticapppen.xid) as xname, (select xphone from ztsaleh where ztsaleh.xid=ztmanticapppen.xid) as xcontact, (select xrate from ztsaleh where ztsaleh.xid=ztmanticapppen.xid) as xrate,(select xamount from ztsaleh where ztsaleh.xid=ztmanticapppen.xid) as xamount,(select xdiscount from ztsaleh where ztsaleh.xid=ztmanticapppen.xid) as xdiscount,(select xusername from ztuser where ztuser.xuser=ztmanticapppen.xreqby) as xreqby FROM ztmanticapppen  WHERE xstatus='pending' ORDER BY xreqdt";
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztmanticapppen");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }


                fnfillDataGrid();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }


        protected void fnCancel(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string xrow1 = ((LinkButton)sender).CommandArgument;
                string str2 = "select xid,xdate,xcoach,xroute,xseat from ztmanticapppen where xrow=@xrow";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];

                string xid1 = dtztemp.Rows[0][0].ToString();
                string xdate1 = dtztemp.Rows[0][1].ToString();
                string xcoach1 = dtztemp.Rows[0][2].ToString();
                string xrouteid = dtztemp.Rows[0][3].ToString();
                string xseat1 = dtztemp.Rows[0][4].ToString();

                using (TransactionScope tran = new TransactionScope())
                {

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;
                    string[] xseat123 = xseat1.Split(',');

                    /* update xstatus into ztsaled */


                    query = "UPDATE ztsaled SET xstatus=@xstatus " +
                                     "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xroute=@xroute AND xseat=@xseat";



                    string xstatus22 = "manticappcan";


                    for (int i = 0; i < xseat123.Length; i++)
                    {
                        dataCmd.CommandText = query;

                        dataCmd.Parameters.Clear();


                        dataCmd.Parameters.AddWithValue("@xid", xid1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);

                        dataCmd.Parameters.AddWithValue("@xroute", xrouteid);
                        dataCmd.Parameters.AddWithValue("@xstatus", xstatus22);
                        dataCmd.Parameters.AddWithValue("@xseat", xseat123[i]);

                        conn1.Close();
                        conn1.Open();


                        dataCmd.ExecuteNonQuery();
                    }


                    /* update xstatus into ztcancelreq */

                    query = "UPDATE ztmanticapppen SET xapprovedt=@xapprovedt, xapproveby=@xapproveby, xapproveloc=@xapproveloc, xstatus=@xstatus " +
                                     "WHERE xrow=@xrow ";


                    string xapprovedt = Convert.ToString(DateTime.Now);
                    string xapproveby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xapproveloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                    string xstatus3 = "canceled";

                    dataCmd.CommandText = query;

                    dataCmd.Parameters.Clear();



                    dataCmd.Parameters.AddWithValue("@xrow", xrow1);
                    dataCmd.Parameters.AddWithValue("@xstatus", xstatus3);
                    dataCmd.Parameters.AddWithValue("@xapprovedt", xapprovedt);
                    dataCmd.Parameters.AddWithValue("@xapproveby", xapproveby);
                    dataCmd.Parameters.AddWithValue("@xapproveloc", xapproveloc);

                    dataCmd.ExecuteNonQuery();


                    /* insert data into ztlog  */

                    query = "INSERT INTO ztlogs" +
                                 "(xrow,xid,xdate,xcoach,xseat,xdatetime,xform,xbutton,xstatus,xuser,xlocation,xroute) " +
                                 "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xdatetime,@xform,@xbutton,@xstatus,@xuser,@xlocation,@xroute) ";


                    string xrow3;
                    string xdate3 = xdate1;
                    string xcoach3 = xcoach1;
                    string [] xseat3 =  xseat1.Split(',');
                    string xdatetime3 = Convert.ToString(DateTime.Now);
                    string xform3 = "mansaleapppen";
                    string xbutton3 = "cancel";
                    string xstatus4 = "man-canceled";
                    string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    for (int i = 0; i < xseat3.Length; i++)
                    {
                        xrow3 = zttestbus.fnmaxidforlog(xdate1);

                        dataCmd.CommandText = query;

                        dataCmd.Parameters.Clear();
                        dataCmd.Parameters.AddWithValue("@xrow", xrow3);
                        dataCmd.Parameters.AddWithValue("@xid", xid1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate3);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach3);
                        dataCmd.Parameters.AddWithValue("@xseat", xseat3[i]);
                        dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime3);
                        dataCmd.Parameters.AddWithValue("@xform", xform3);
                        dataCmd.Parameters.AddWithValue("@xbutton", xbutton3);
                        dataCmd.Parameters.AddWithValue("@xstatus", xstatus4);
                        dataCmd.Parameters.AddWithValue("@xuser", xuser3);
                        dataCmd.Parameters.AddWithValue("@xlocation", xlocation3);
                        dataCmd.Parameters.AddWithValue("@xroute", xrouteid);



                        dataCmd.ExecuteNonQuery();
                    }


                    conn1.Close();

                    tran.Complete();


                    dataCmd.Dispose();
                    conn1.Dispose();

                    
                }

                fnfillDataGrid();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void fnApprove(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string xrow1 = ((LinkButton)sender).CommandArgument;
                string str2 = "select xid,xdate,xcoach,xroute,xseat from ztmanticapppen where xrow=@xrow";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];

                string xid1 = dtztemp.Rows[0][0].ToString();
                string xdate1 = dtztemp.Rows[0][1].ToString();
                string xcoach1 = dtztemp.Rows[0][2].ToString();
                string xrouteid = dtztemp.Rows[0][3].ToString();
                string xseat1 = dtztemp.Rows[0][4].ToString();

                using (TransactionScope tran = new TransactionScope())
                {

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;
                    string[] xseat123 = xseat1.Split(',');

                    /* update xstatus into ztsaled */

                    query = "UPDATE ztsaled SET xstatus='mansale' " +
                                          "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xroute=@xroute AND xseat=@xseat";



                    dataCmd.CommandText = query;


                    for (int i = 0; i < xseat123.Length; i++)
                    {
                        dataCmd.Parameters.Clear();


                        dataCmd.Parameters.AddWithValue("@xid", xid1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);

                        dataCmd.Parameters.AddWithValue("@xroute", xrouteid);
                        dataCmd.Parameters.AddWithValue("@xseat", xseat123[i]);



                        conn1.Close();
                        conn1.Open();


                        dataCmd.ExecuteNonQuery();
                    }








                    /* update xstatus into ztcancelreq */

                    query = "UPDATE ztmanticapppen SET xapprovedt=@xapprovedt, xapproveby=@xapproveby, xapproveloc=@xapproveloc, xstatus=@xstatus " +
                                     "WHERE xrow=@xrow ";


                    string xapprovedt = Convert.ToString(DateTime.Now);
                    string xapproveby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xapproveloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                    string xstatus3 = "approved";

                    dataCmd.CommandText = query;

                    dataCmd.Parameters.Clear();



                    dataCmd.Parameters.AddWithValue("@xrow", xrow1);
                    dataCmd.Parameters.AddWithValue("@xstatus", xstatus3);
                    dataCmd.Parameters.AddWithValue("@xapprovedt", xapprovedt);
                    dataCmd.Parameters.AddWithValue("@xapproveby", xapproveby);
                    dataCmd.Parameters.AddWithValue("@xapproveloc", xapproveloc);

                    dataCmd.ExecuteNonQuery();


                    /* insert data into ztlog  */

                    query = "INSERT INTO ztlogs" +
                                 "(xrow,xid,xdate,xcoach,xseat,xdatetime,xform,xbutton,xstatus,xuser,xlocation,xroute) " +
                                 "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xdatetime,@xform,@xbutton,@xstatus,@xuser,@xlocation,@xroute) ";


                    string xrow3;
                    string xdate3 = xdate1;
                    string xcoach3 = xcoach1;
                    string[] xseat3 = xseat1.Split(',');
                    string xdatetime3 = Convert.ToString(DateTime.Now);
                    string xform3 = "mansaleapppen";
                    string xbutton3 = "approve";
                    string xstatus4 = "man-approved";
                    string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);


                    for (int i = 0; i < xseat3.Length; i++)
                    {
                        xrow3 = zttestbus.fnmaxidforlog(xdate1);

                        dataCmd.CommandText = query;

                        dataCmd.Parameters.Clear();
                        dataCmd.Parameters.AddWithValue("@xrow", xrow3);
                        dataCmd.Parameters.AddWithValue("@xid", xid1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate3);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach3);
                        dataCmd.Parameters.AddWithValue("@xseat", xseat3[i]);
                        dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime3);
                        dataCmd.Parameters.AddWithValue("@xform", xform3);
                        dataCmd.Parameters.AddWithValue("@xbutton", xbutton3);
                        dataCmd.Parameters.AddWithValue("@xstatus", xstatus4);
                        dataCmd.Parameters.AddWithValue("@xuser", xuser3);
                        dataCmd.Parameters.AddWithValue("@xlocation", xlocation3);
                        dataCmd.Parameters.AddWithValue("@xroute", xrouteid);



                        dataCmd.ExecuteNonQuery();
                    }


                    conn1.Close();

                    tran.Complete();


                    dataCmd.Dispose();
                    conn1.Dispose();

                }
                fnfillDataGrid();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

    }
}