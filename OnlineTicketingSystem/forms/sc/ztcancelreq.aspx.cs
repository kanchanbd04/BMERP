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
    public partial class ztcancelreq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztcancelreq");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }


                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "SELECT xrow,xreqdt,xdate,xtime,xcoach,xseat,(select route from ztroute where srt=xroute) as xroute, (select xphone from ztsaleh where ztsaleh.xid=ztcancelreq.xid) as xcontact, xremark,(select xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby) as xreqby FROM ztcancelreq  WHERE xstatus='pending' ORDER BY xreqdt";
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
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }


        protected void fnFillDataGrid()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xrow,xreqdt,xdate,xtime,xcoach,xseat,(select route from ztroute where srt=xroute) as xroute, (select xphone from ztsaleh where ztsaleh.xid=ztcancelreq.xid) as xcontact, xremark,(select xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby) as xreqby FROM ztcancelreq  WHERE xstatus='pending' ORDER BY xreqdt";
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

        protected void fnCancel(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string xrow1 = ((LinkButton)sender).CommandArgument;
                string str2 = "select xid,xdate,xcoach,xseat,xremark,xroute from ztcancelreq where xrow=@xrow";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];

                string xid1 = dtztemp.Rows[0][0].ToString();
                string xdate1 = dtztemp.Rows[0][1].ToString();
                string xcoach1 = dtztemp.Rows[0][2].ToString();
                string xseat1 = dtztemp.Rows[0][3].ToString();
                string xremark1 = dtztemp.Rows[0][4].ToString();
                string xrouteid = dtztemp.Rows[0][5].ToString();

                using (TransactionScope tran = new TransactionScope())
                {

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    /* update xstatus into ztsaled */

                    query = "UPDATE ztsaled SET xstatus=@xstatus " +
                                     "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xseat=@xseat AND xroute=@xroute";

                    //string xstatus1;

                    //if (xremark1 == "Sold")
                    //{
                    //    xstatus1 = "sold";
                    //}
                    //else
                    //{
                    //    xstatus1 = "confbooking";
                    //}

                    dataCmd.CommandText = query;

                    dataCmd.Parameters.Clear();


                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                    dataCmd.Parameters.AddWithValue("@xseat", xseat1);
                    dataCmd.Parameters.AddWithValue("@xstatus", xremark1);
                    dataCmd.Parameters.AddWithValue("@xroute", xrouteid);

                    conn1.Close();
                    conn1.Open();


                    dataCmd.ExecuteNonQuery();


                    /* update xstatus into ztcancelreq */

                    query = "UPDATE ztcancelreq SET xapprovedt=@xapprovedt, xapproveby=@xapproveby, xapproveloc=@xapproveloc, xstatus=@xstatus " +
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


                    string xrow3 = zttestbus.fnmaxidforlog(xdate1);
                    string xdate3 = xdate1;
                    string xcoach3 = xcoach1;
                    string xseat3 = xseat1;
                    string xdatetime3 = Convert.ToString(DateTime.Now);
                    string xform3 = "cancelreq";
                    string xbutton3 = "cancel";
                    string xstatus4 = "canceled";
                    string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    dataCmd.CommandText = query;

                    dataCmd.Parameters.Clear();
                    dataCmd.Parameters.AddWithValue("@xrow", xrow3);
                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.Parameters.AddWithValue("@xdate", xdate3);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach3);
                    dataCmd.Parameters.AddWithValue("@xseat", xseat3);
                    dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime3);
                    dataCmd.Parameters.AddWithValue("@xform", xform3);
                    dataCmd.Parameters.AddWithValue("@xbutton", xbutton3);
                    dataCmd.Parameters.AddWithValue("@xstatus", xstatus4);
                    dataCmd.Parameters.AddWithValue("@xuser", xuser3);
                    dataCmd.Parameters.AddWithValue("@xlocation", xlocation3);
                    dataCmd.Parameters.AddWithValue("@xroute", xrouteid);



                    dataCmd.ExecuteNonQuery();


                    conn1.Close();

                    tran.Complete();


                    dataCmd.Dispose();
                    conn1.Dispose();

                }
                fnFillDataGrid();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }


        protected string fnChkDateTime(string xdate2, string xcoach2, string xloc2,string xroute2)
        {

            DateTime srvdtt = DateTime.Now;

            DateTime sdt = new DateTime(srvdtt.Year, srvdtt.Month, srvdtt.Day, srvdtt.Hour, srvdtt.Minute, srvdtt.Second);

            //Check Counter time

            SqlConnection conn01;
            conn01 = new SqlConnection(zglobal.constring);
            DataSet dts01 = new DataSet();
            dts01.Reset();

            //string str01 = "select (xctimeh+':'+xctimem+' '+xctimei) as xtime from ztcoachcounter where xcoachno=@xcoach and xcname=@xcname";
            string str01 = "select max(CONVERT(datetime,(xctimeh+':'+xctimem+' '+xctimei),120)) from ztcoachcounter where xcoachno=@xcoach";
            string xcoach01 = xcoach2;
            string xcname = xloc2;
            SqlDataAdapter da01 = new SqlDataAdapter(str01, conn01);
            da01.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach01);
            da01.SelectCommand.Parameters.AddWithValue("@xcname", xcname);
            da01.Fill(dts01, "temp");
            DataTable tbl = new DataTable();
            tbl = dts01.Tables[0];


            if (tbl.Rows.Count > 0)
            {
                string ctime = tbl.Rows[0][0].ToString();
                DateTime dtd = Convert.ToDateTime(xdate2);
                DateTime dtt = Convert.ToDateTime(ctime);

                DateTime cdt = new DateTime(dtd.Year, dtd.Month, dtd.Day, dtt.Hour, dtt.Minute, dtt.Second);



                TimeSpan datediff = cdt.Subtract(sdt);



                if (Convert.ToInt32(datediff.TotalSeconds) < 0)
                {
                    return "timeout";
                    //attIsEnable = "disabled";
                }
                return "intime";
            }
            else
            {

                //Check Route time

                str01 = "(select (xmrtimeh+':'+xmrtimem+' '+xmrtimei) as xtime from ztcoach where xcoachno=@xcoach and xmrid=@xroute) " +
                      "union " +
                      "(select (xsrtimeh+':'+xsrtimem+' '+xsrtimei) as xtime from ztcoachsubrt where xcoachno=@xcoach and xsrid=@xroute)";

                string xroute01 = xroute2;

                SqlDataAdapter da02 = new SqlDataAdapter(str01, conn01);
                da02.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach01);
                da02.SelectCommand.Parameters.AddWithValue("@xroute", xroute01);
                dts01.Reset();
                da02.Fill(dts01, "temp");
                DataTable tbl02 = new DataTable();
                tbl02 = dts01.Tables[0];


                if (tbl02.Rows.Count > 0)
                {

                    string rtime = tbl02.Rows[0][0].ToString();

                    DateTime dtd = Convert.ToDateTime(xdate2);
                    DateTime dtt = Convert.ToDateTime(rtime);

                    DateTime cdt = new DateTime(dtd.Year, dtd.Month, dtd.Day, dtt.Hour, dtt.Minute, dtt.Second);



                    TimeSpan datediff = cdt.Subtract(sdt);



                    if (Convert.ToInt32(datediff.TotalSeconds) < 0)
                    {
                        return "timeout";
                        //attIsEnable = "disabled";
                    }
                    
                }
                return "intime";
            }

        }

        protected void fnApprove(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string xrow1 = ((LinkButton)sender).CommandArgument;
                string str2 = "select xid,xdate,xcoach,xseat,xremark,xroute,xreqloc from ztcancelreq where xrow=@xrow";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];

                string xid1 = dtztemp.Rows[0][0].ToString();
                string xdate1 = dtztemp.Rows[0][1].ToString();
                string xcoach1 = dtztemp.Rows[0][2].ToString();
                string xseat1 = dtztemp.Rows[0][3].ToString();
                string xremark1 = dtztemp.Rows[0][4].ToString();
                string xrouteid = dtztemp.Rows[0][5].ToString();
                string xcounter = dtztemp.Rows[0][6].ToString();

                using (TransactionScope tran = new TransactionScope())
                {

                    string chkdttime = fnChkDateTime(xdate1,xcoach1,xcounter,xrouteid);

                    if (chkdttime == "timeout")
                    {
                        msg.InnerHtml = "Approve operation timeout.";
                        return;
                    }


                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    /* update xstatus into ztsaled */

                    string xstatus1 = "";
                    if (xremark1 == "sold")
                    {
                        xstatus1 = "cancelsold";
                    }
                    else if (xremark1 == "mansale")
                    {
                        xstatus1 = "cancelms";
                    }
                    else
                    {
                        xstatus1 = "cancelconf";
                    }
                    query = "UPDATE ztsaled SET xstatus=@xstatus " +
                                          "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xseat=@xseat AND xroute=@xroute";



                    dataCmd.CommandText = query;

                    dataCmd.Parameters.Clear();


                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                    dataCmd.Parameters.AddWithValue("@xseat", xseat1);
                    dataCmd.Parameters.AddWithValue("@xstatus", xstatus1);
                    dataCmd.Parameters.AddWithValue("@xroute", xrouteid);




                    conn1.Close();
                    conn1.Open();


                    dataCmd.ExecuteNonQuery();








                    /* update xstatus into ztcancelreq */

                    query = "UPDATE ztcancelreq SET xapprovedt=@xapprovedt, xapproveby=@xapproveby, xapproveloc=@xapproveloc, xstatus=@xstatus " +
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


                    string xrow3 = zttestbus.fnmaxidforlog(xdate1);
                    string xdate3 = xdate1;
                    string xcoach3 = xcoach1;
                    string xseat3 = xseat1;
                    string xdatetime3 = Convert.ToString(DateTime.Now);
                    string xform3 = "cancelreq";
                    string xbutton3 = "approve";
                    string xstatus4 = "approved";
                    string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    dataCmd.CommandText = query;

                    dataCmd.Parameters.Clear();
                    dataCmd.Parameters.AddWithValue("@xrow", xrow3);
                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.Parameters.AddWithValue("@xdate", xdate3);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach3);
                    dataCmd.Parameters.AddWithValue("@xseat", xseat3);
                    dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime3);
                    dataCmd.Parameters.AddWithValue("@xform", xform3);
                    dataCmd.Parameters.AddWithValue("@xbutton", xbutton3);
                    dataCmd.Parameters.AddWithValue("@xstatus", xstatus4);
                    dataCmd.Parameters.AddWithValue("@xuser", xuser3);
                    dataCmd.Parameters.AddWithValue("@xlocation", xlocation3);
                    dataCmd.Parameters.AddWithValue("@xroute", xrouteid);



                    dataCmd.ExecuteNonQuery();


                    conn1.Close();

                    tran.Complete();


                    dataCmd.Dispose();
                    conn1.Dispose();

                }
                fnFillDataGrid();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }


    }
}