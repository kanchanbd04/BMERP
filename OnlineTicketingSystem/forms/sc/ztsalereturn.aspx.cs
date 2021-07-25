using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Timers;
using System.Transactions;

namespace OnlineTicketingSystem.forms.sc
{
    public partial class ztsalereturn : System.Web.UI.Page
    {

        public static string fnmaxidformanh()
        {
            DateTime dt = DateTime.Now;
            DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2;
            string prefix;

            str2 = "SELECT max(xid) FROM ztmh where xdatetime between @firstdate and @lastdate and coalesce(xreason,'')<>''";
            prefix = "DES";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            string firstdate = firstDate.ToString();
            string lastdate = lastDate.ToString();
            //txtDue.Text = date;
            da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstdate);
            da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastdate);
            da2.Fill(dts2, "temp");
            DataTable xid1 = new DataTable();
            xid1 = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
            {
                string s = xid1.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 3));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "0" + s2;
                }

                maxrow = prefix + "-" + dt.ToString("MMyyyy") + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = prefix + "-" + dt.ToString("MMyyyy") + "001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }

        public static string fnmaxidformand()
        {
            DateTime dt = DateTime.Now;
            DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2;
            //string prefix;

            str2 = "SELECT max(xline) FROM ztmd where xdatetime between @firstdate and @lastdate";
            //prefix = "rec";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            string firstdate = firstDate.ToString();
            string lastdate = lastDate.ToString();
            //txtDue.Text = date;
            da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstdate);
            da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastdate);
            da2.Fill(dts2, "temp");
            DataTable xid1 = new DataTable();
            xid1 = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
            {
                string s = xid1.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 5));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "0" + s2;
                }

                maxrow = dt.ToString("MMyyyy") + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = dt.ToString("MMyyyy") + "00001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }



        [WebMethod(EnableSession = true)]
        public static string fnReturnTic(string date1, string coach1, string seat1, string time1, string route1, string name1, string phone1, string votid1, string boarding1, string rate1, string amount1, string seatid1)
        {

            try
            {

                HttpContext.Current.Session["isreturn"] = "y";
                HttpContext.Current.Session["date"] = date1;
                HttpContext.Current.Session["coach"] = coach1;
                HttpContext.Current.Session["seat"] = seat1;
                HttpContext.Current.Session["time"] = time1;
                HttpContext.Current.Session["route"] = route1;
                HttpContext.Current.Session["name"] = name1;
                HttpContext.Current.Session["phone"] = phone1;
                HttpContext.Current.Session["votid"] = votid1;
                HttpContext.Current.Session["boarding"] = boarding1;
                HttpContext.Current.Session["rate"] = rate1;
                HttpContext.Current.Session["amount"] = amount1;
                //HttpContext.Current.Session["discount"] = "0";
                HttpContext.Current.Session["seatid"] = seatid1;


            }
            catch (Exception exp)
            {
                return exp.Message;
            }


            return "success";
        }

        //public static string getDiscount(string xdate1)
        //{
        //    string discount = "0";

        //    SqlConnection conn1;
        //    conn1 = new SqlConnection(zglobal.constring);
        //    DataSet dts = new DataSet();
        //    dts.Reset();





        //    string str = "select xdiscratetype,xdiscamt from ztdisc where @xdate between xeffdate and xexpdate and xstatus='Confirmed' and zactive=1";

        //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);


        //    da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

        //    da.Fill(dts, "tempzt");
        //    //DataView dv = new DataView(dts.Tables[0]);
        //    DataTable dtztcode = new DataTable();
        //    dtztcode = dts.Tables[0];

        //    if (dtztcode.Rows.Count > 0)
        //    { 
        //    if()
        //    }

        //    return discount;

        //}

        [WebMethod(EnableSession = true)]
        public static string getFare(string xdate2, string xcoachno2, string xroute2)
        {
            string Fare = "";



            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();


            string xcoachno1 = xcoachno2;
            string xdate1 = xdate2;


            string str = "select srt,route from ztroute where mrt = (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno)";

            SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);


            da1.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
            da1.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

            dts.Reset();
            da1.Fill(dts, "temp1");
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];

            string rid = "";

            if (dttemp.Rows.Count > 0)
            {

                for (int i = 0; i < dttemp.Rows.Count; i++)
                {
                    //for (int j = 0; j < dttemp.Columns.Count; j++)
                    //{ 
                    if (dttemp.Rows[i][1].ToString() == xroute2)
                    {
                        rid = dttemp.Rows[i][0].ToString();
                        break;
                    }
                    //}
                }

                dts.Reset();


                SqlConnection conn123;
                conn123 = new SqlConnection(zglobal.constring);
                DataSet dts123 = new DataSet();
                dts123.Reset();
                string str123 = "SELECT xbustype FROM ztcoach  WHERE  xcoachno= @xcoachno";
                SqlDataAdapter da123 = new SqlDataAdapter(str123, conn123);



                da123.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);


                da123.Fill(dts123, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtzt123 = new DataTable();
                dtzt123 = dts123.Tables[0];

                string xbustype1 = dtzt123.Rows[0][0].ToString();
                //DateTime xdt = Convert.ToDateTime(string.Format("{0:dd/MM/yyyy}", xdate2));
                //str = "select xfare from ztfare where xsrid  =@xsrid and xeffdate=(select max(xeffdate) from ztfare where xeffdate <= @xdate AND xsrid  =@xsrid and zactive=1 AND xapprove='Confirmed')";

                str = "select xfare from ztfare where xsrid  =@xsrid and xapprove='Confirmed' and xbustype=@xbustype and xeffdate=(select max(xeffdate) from ztfare where xeffdate <= @xdate " +
                      " AND xsrid  =@xsrid  and zactive=1 AND xbustype=@xbustype and xapprove='Confirmed')";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);


                da.SelectCommand.Parameters.AddWithValue("@xsrid", rid);
                da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                da.SelectCommand.Parameters.AddWithValue("@xbustype", xbustype1);

                dts.Reset();
                da.Fill(dts, "temp1");
                DataTable dttemp1 = new DataTable();
                dttemp1 = dts.Tables[0];

                if (dttemp1.Rows.Count > 0)
                {
                    //for (int i = 0; i < dttemp1.Rows.Count; i++)
                    //{ 

                    //}

                    Fare = dttemp1.Rows[0][0].ToString();


                    /////Discount


                   

                    SqlConnection conn12345;
                    conn12345 = new SqlConnection(zglobal.constring);
                    DataSet dts12345 = new DataSet();
                    dts12345.Reset();





                    string str12345 = "select xdiscratetype,xdiscamt from ztdisc where @xdate between xeffdate and xexpdate and xstatus='Confirmed' and zactive=1";

                    SqlDataAdapter da12345 = new SqlDataAdapter(str12345, conn12345);


                    da12345.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

                    da12345.Fill(dts12345, "tempzt");
                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable dtztcode = new DataTable();
                    dtztcode = dts12345.Tables[0];

                    if (dtztcode.Rows.Count > 0)
                    {
                        if (dtztcode.Rows[0][0].ToString() == "Fixed Amount")
                        {
                            double amt = Convert.ToDouble(dtztcode.Rows[0][1].ToString());
                            double totalf = Convert.ToDouble(Fare);

                            HttpContext.Current.Session["discount"] = Convert.ToString(amt);

                            double total = totalf - amt;

                            Fare = Convert.ToString(total);
                        }
                        else
                        {
                            double percent = Convert.ToDouble(dtztcode.Rows[0][1].ToString());
                            double totalf = Convert.ToDouble(Fare);

                            double total = totalf - ((totalf*percent)/100);

                            HttpContext.Current.Session["discount"] = Convert.ToString((totalf * percent) / 100);

                            Fare = Convert.ToString(total);
                        }
                    }

                    ////////////////

                }



            }



            return Fare;
        }

        public static string fnmaxid(string dtt)
        {
            DateTime dt = Convert.ToDateTime(dtt);
            DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2;
            string prefix;

            str2 = "SELECT max(xrow) FROM ztcancelreq where xdate between @firstdate and @lastdate";
            prefix = "c";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            string firstdate = firstDate.ToString();
            string lastdate = lastDate.ToString();
            //txtDue.Text = date;
            da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstdate);
            da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastdate);
            da2.Fill(dts2, "temp");
            DataTable voucher = new DataTable();
            voucher = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(voucher.Rows[0][0]) && voucher.Rows[0][0].ToString() != "")
            {
                string s = voucher.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 8));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "0000000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "000000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "00000" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 5)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 6)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 7)
                {
                    s2 = "0" + s2;
                }
                maxrow = prefix + "-" + dt.ToString("MM-yyyy") + "-" + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = prefix + "-" + dt.ToString("MM-yyyy") + "-" + "00000001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }


        [WebMethod(EnableSession = true)]
        public static string fnSaveManTicket()
        {


            return "success";
        }



        [WebMethod(EnableSession = true)]
        public static object fnLoadTicket()
        {
            var objList = (new[] { new { Text = "[Select]", Value = "[Select]" } }).ToList();

            try
            {
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();
                string query = "select xwh,xticket,SUM(xqty*xsign) from ztmstk where xwh=@xwh " +
                               " group by xwh,xticket " +
                               " having SUM(xqty*xsign)>0 " +
                               " order by CAST(xticket AS INT) ";

                SqlDataAdapter da2 = new SqlDataAdapter(query, conn2);

                string xwh1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                da2.SelectCommand.Parameters.AddWithValue("@xwh", xwh1);
                da2.Fill(dts2, "temp");
                DataTable ztmstk = new DataTable();
                ztmstk = dts2.Tables["temp"];





                if (ztmstk.Rows.Count > 0)
                {


                    for (int i = 0; i < ztmstk.Rows.Count; i++)
                    {
                        objList.Add(new { Text = ztmstk.Rows[i][1].ToString(), Value = ztmstk.Rows[i][1].ToString() });
                    }

                }
                else
                {
                    //var obj1 = (new[] { new { Text = "You are out of stock.", Value = "You are out of stock." } }).ToList();
                    //return obj1;

                }

                da2.Dispose();
                dts2.Dispose();
                conn2.Dispose();



            }
            catch (Exception exp)
            {
                //var obj2 = (new[] { new { Text = exp.Message, Value = exp.Message } }).ToList();
                //return obj2;


            }

            return objList;
        }


        //[WebMethod(EnableSession = true)]
        //public static string fnCancelRequest(string cxdate2, string cxtime2, string cxcoach2, string cxseat2, string cxnoofseat2, string cxremark2, string cxstatus2, string xrouteid)
        //{
        //    try
        //    {

        //        /*  check if multiple passenger booking cancel at a time*/
        //        string[] xseat9 = cxseat2.Split(',');
        //        ArrayList arr = new ArrayList();
        //        ArrayList xseatlist = new ArrayList();
        //        ArrayList xrow = new ArrayList();


        //        for (int i = 0; i < xseat9.Length; i++)
        //        {
        //            SqlConnection conn2;
        //            conn2 = new SqlConnection(zglobal.constring);
        //            DataSet dts2 = new DataSet();
        //            dts2.Reset();

        //            string str2 = "select xid,xstatus,xrow from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('mansale', 'sold','confbooking')";
        //            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

        //            da2.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
        //            da2.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
        //            da2.SelectCommand.Parameters.AddWithValue("@xseat", xseat9[i]);
        //            da2.SelectCommand.Parameters.AddWithValue("@xroute", xrouteid);

        //            da2.Fill(dts2, "temp");
        //            DataTable dtztemp = new DataTable();
        //            dtztemp = dts2.Tables["temp"];

        //            arr.Add(dtztemp.Rows[0][0].ToString());
        //            xseatlist.Add(dtztemp.Rows[0][1].ToString());
        //            xrow.Add(dtztemp.Rows[0][2].ToString());

        //        }

        //        string xid1 = "";

        //        foreach (string xid123 in arr)
        //        {
        //            foreach (string xid321 in arr)
        //            {
        //                if (xid123 != xid321)
        //                {
        //                    return "Select only one passenger.";
        //                }
        //            }

        //            xid1 = xid123;
        //        }


        //        using (TransactionScope tran = new TransactionScope())
        //        {





        //            SqlConnection conn1;
        //            conn1 = new SqlConnection(zglobal.constring);
        //            SqlCommand dataCmd = new SqlCommand();
        //            dataCmd.Connection = conn1;
        //            string query;


        //            /* insert data into ztlog  */

        //            query = "INSERT INTO ztlogs" +
        //                         "(xrow,xid,xdate,xcoach,xseat,xdatetime,xform,xbutton,xstatus,xuser,xlocation,xroute) " +
        //                         "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xdatetime,@xform,@xbutton,@xstatus,@xuser,@xlocation,@xroute) ";




        //            string xrow3;
        //            string xdate3 = cxdate2;
        //            string xcoach3 = cxcoach2;
        //            string[] xseat4 = cxseat2.Split(',');
        //            string xdatetime3 = Convert.ToString(DateTime.Now);
        //            string xform3 = "sale";
        //            string xbutton3 = "cancel";
        //            string xstatus3 = cxstatus2;
        //            string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
        //            string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

        //            conn1.Close();
        //            conn1.Open();

        //            dataCmd.CommandText = query;
        //            // dataCmd1.Transaction = transec;

        //            for (int i = 0; i < xseat4.Length; i++)
        //            {



        //                dataCmd.CommandText = query;


        //                //xrow3 = zttestbus.fnmaxrow("select max(xrow) from ztlogs");
        //                xrow3 = zttestbus.fnmaxidforlog(xdate3);

        //                dataCmd.Parameters.Clear();
        //                dataCmd.Parameters.AddWithValue("@xrow", xrow3);
        //                dataCmd.Parameters.AddWithValue("@xid", xid1);
        //                dataCmd.Parameters.AddWithValue("@xdate", xdate3);
        //                dataCmd.Parameters.AddWithValue("@xcoach", xcoach3);
        //                dataCmd.Parameters.AddWithValue("@xseat", xseat4[i]);
        //                dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime3);
        //                dataCmd.Parameters.AddWithValue("@xform", xform3);
        //                dataCmd.Parameters.AddWithValue("@xbutton", xbutton3);
        //                dataCmd.Parameters.AddWithValue("@xstatus", xstatus3);
        //                dataCmd.Parameters.AddWithValue("@xuser", xuser3);
        //                dataCmd.Parameters.AddWithValue("@xlocation", xlocation3);
        //                dataCmd.Parameters.AddWithValue("@xroute", xrouteid);



        //                dataCmd.ExecuteNonQuery();

        //                //dataCmd1.Dispose();
        //            }

        //            /* update xstatus into ztsaled */

        //            query = "UPDATE ztsaled SET xstatus='cancelpending' " +
        //                             "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xseat=@xseat AND xroute=@xroute and xstatus in ('mansale', 'sold','confbooking')";

        //            //string xstatus5 = "cancel";
        //            string xdate5 = cxdate2;
        //            string xcoach5 = cxcoach2;
        //            // string[] xseat5 = cxseat2.Split(',');


        //            dataCmd.CommandText = query;


        //            for (int i = 0; i < xseat4.Length; i++)
        //            {



        //                dataCmd.CommandText = query;




        //                dataCmd.Parameters.Clear();

        //                dataCmd.Parameters.AddWithValue("@xid", xid1);
        //                dataCmd.Parameters.AddWithValue("@xdate", xdate5);
        //                dataCmd.Parameters.AddWithValue("@xcoach", xcoach5);
        //                dataCmd.Parameters.AddWithValue("@xseat", xseat4[i]);
        //                dataCmd.Parameters.AddWithValue("@xroute", xrouteid);
        //                //dataCmd.Parameters.AddWithValue("@xstatus", xstatus3);




        //                dataCmd.ExecuteNonQuery();

        //            }


        //            query = "INSERT INTO ztcancelreq" +
        //                         "(xrow,xid,xdate,xtime,xcoach,xseat,xremark,xreqdt,xreqby,xreqloc,xapprovedt,xapproveby,xapproveloc,xstatus,xroute,xrowd) " +
        //                         "VALUES (@xrow,@xid,@xdate,@xtime,@xcoach,@xseat,@xremark,@xreqdt,@xreqby,@xreqloc,@xapprovedt,@xapproveby,@xapproveloc,@xstatus,@xroute,@xrowd) ";


        //            string xrow4;
        //            string xdate4 = cxdate2;
        //            string xtime4 = cxtime2;
        //            string xcoach4 = cxcoach2;
        //            string xremark4 = cxremark2;
        //            string xstatus4 = cxstatus2;
        //            string xreqdt = "";
        //            string xreqby = "";
        //            string xreqloc = "";
        //            string xapprovedt = "";
        //            string xapproveby = "";
        //            string xapproveloc = "";
        //            if (xstatus4 == "pending")
        //            {
        //                xreqdt = Convert.ToString(DateTime.Now);
        //                xreqby = Convert.ToString(HttpContext.Current.Session["curuser"]);
        //                xreqloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);
        //                //xapprovedt = "";
        //                //xapproveby = "";
        //                //xapproveloc = "";
        //            }
        //            else
        //            {
        //                //xreqdt = "";
        //                //xreqby = "";
        //                //xreqloc = "";
        //                xapprovedt = Convert.ToString(DateTime.Now);
        //                xapproveby = Convert.ToString(HttpContext.Current.Session["curuser"]);
        //                xapproveloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);
        //            }

        //            dataCmd.CommandText = query;

        //            string xrowd;
        //            for (int i = 0; i < xseat4.Length; i++)
        //            {

        //                xrow4 = fnmaxid(cxdate2);
        //                xrowd = xrow[i].ToString();
        //                dataCmd.CommandText = query;




        //                dataCmd.Parameters.Clear();

        //                dataCmd.Parameters.AddWithValue("@xrow", xrow4);
        //                dataCmd.Parameters.AddWithValue("@xid", xid1);
        //                dataCmd.Parameters.AddWithValue("@xrowd", xrowd);
        //                dataCmd.Parameters.AddWithValue("@xdate", xdate4);
        //                dataCmd.Parameters.AddWithValue("@xtime", xtime4);
        //                dataCmd.Parameters.AddWithValue("@xcoach", xcoach4);
        //                dataCmd.Parameters.AddWithValue("@xremark", xseatlist[i]);
        //                if (xstatus4 == "pending")
        //                {
        //                    dataCmd.Parameters.AddWithValue("@xreqdt", xreqdt);
        //                    dataCmd.Parameters.AddWithValue("@xreqby", xreqby);
        //                    dataCmd.Parameters.AddWithValue("@xreqloc", xreqloc);
        //                }
        //                dataCmd.Parameters.AddWithValue("@xapprovedt", xapprovedt);
        //                dataCmd.Parameters.AddWithValue("@xapproveby", xapproveby);
        //                dataCmd.Parameters.AddWithValue("@xapproveloc", xapproveloc);
        //                dataCmd.Parameters.AddWithValue("@xstatus", xstatus4);
        //                dataCmd.Parameters.AddWithValue("@xseat", xseat4[i]);
        //                dataCmd.Parameters.AddWithValue("@xroute", xrouteid);




        //                dataCmd.ExecuteNonQuery();

        //            }

        //            conn1.Close();




        //            tran.Complete();


        //            dataCmd.Dispose();
        //            conn1.Dispose();
        //        }

        //    }
        //    catch (Exception exp)
        //    {

        //        return exp.Message;
        //    }




        //    return "success";
        //}

        [WebMethod(EnableSession = true)]
        public static string fnGetDate()
        {
            string srvdate = Convert.ToString(DateTime.Now);
            return srvdate;
        }


        //[WebMethod(EnableSession = true)]
        //public static string fnSelectSeat(string cxdate2, string cxcoach2, string cxseat2, string xstatus2)
        //{

        //    string values = "";

        //    //string[] xseat9 = cxseat2.Split(',');
        //    //ArrayList arr = new ArrayList();
        //    string xid1 = "";

        //    SqlConnection conn2;
        //    conn2 = new SqlConnection(zglobal.constring);
        //    DataSet dts2 = new DataSet();
        //    dts2.Reset();

        //    string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat";
        //    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

        //    da2.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
        //    da2.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
        //    da2.SelectCommand.Parameters.AddWithValue("@xseat", cxseat2);

        //    da2.Fill(dts2, "temp");
        //    DataTable dtztemp = new DataTable();
        //    dtztemp = dts2.Tables["temp"];

        //    xid1 = dtztemp.Rows[0][0].ToString();


        //    //////////////////////////


        //    SqlConnection conn12;
        //    conn12 = new SqlConnection(zglobal.constring);
        //    DataSet dts12 = new DataSet();
        //    dts12.Reset();

        //    string str12 = "select xseatid from ztsaled where  xdate=@xdate and xcoach=@xcoach and xid=@xid and xstatus=@xstatus";
        //    SqlDataAdapter da12 = new SqlDataAdapter(str12, conn12);

        //    da12.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
        //    da12.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
        //    da12.SelectCommand.Parameters.AddWithValue("@xid", xid1);
        //    da12.SelectCommand.Parameters.AddWithValue("@xstatus", xstatus2);


        //    da12.Fill(dts12, "temp");
        //    DataTable dtztemp12 = new DataTable();
        //    dtztemp12 = dts12.Tables["temp"];

        //    string txt = "";
        //    //return dtztemp12.Rows.Count.ToString();
        //    for (int i = 0; i < dtztemp12.Rows.Count; i++)
        //    {
        //        txt += dtztemp12.Rows[i][0].ToString();
        //        if (i != dtztemp12.Rows.Count - 1)
        //        {
        //            txt += ",";
        //        }
        //    }
        //    values = txt;

        //    return values;
        //}


        [WebMethod(EnableSession = true)]
        public static string fnLoadCtlBooking(string cxdate2, string cxcoach2, string cxseat2, string xstatus2, string xrouteid, string xentrytype2)
        {
            try
            {
                string values = "";


                /*  check if multiple passenger booking cancel at a time*/
                string[] xseat9 = cxseat2.Split(',');
                ArrayList arr = new ArrayList();
                string xid1 = "";


                for (int i = 0; i < xseat9.Length; i++)
                {
                    SqlConnection conn2;
                    conn2 = new SqlConnection(zglobal.constring);
                    DataSet dts2 = new DataSet();
                    dts2.Reset();

                    string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                    da2.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
                    da2.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
                    da2.SelectCommand.Parameters.AddWithValue("@xseat", xseat9[i]);
                    da2.SelectCommand.Parameters.AddWithValue("@xroute", xrouteid);

                    da2.Fill(dts2, "temp");
                    DataTable dtztemp = new DataTable();
                    dtztemp = dts2.Tables["temp"];

                    arr.Add(dtztemp.Rows[0][0].ToString());

                }



                foreach (string xid123 in arr)
                {
                    foreach (string xid321 in arr)
                    {
                        if (xid123 != xid321)
                        {
                            return "bg";
                        }
                    }

                    xid1 = xid123;
                }

                //check if already mnual or online sale


                //SqlConnection conn123456;
                //conn123456 = new SqlConnection(zglobal.constring);
                //DataSet dts123456 = new DataSet();
                //dts123456.Reset();

                //string str123456 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                //SqlDataAdapter da123456 = new SqlDataAdapter(str123456, conn123456);

                //da123456.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
                //da123456.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
                ////da123456.SelectCommand.Parameters.AddWithValue("@xseat", xseat9[i]);
                //da123456.SelectCommand.Parameters.AddWithValue("@xroute", xrouteid);

                //da123456.Fill(dts123456, "temp");
                //DataTable dtztemp123456 = new DataTable();
                //dtztemp123456 = dts123456.Tables["temp"];

                //////////////////////////////////////

                SqlConnection conn;
                conn = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();

                string str = "select xname,xphone,xvotid,xboarding,xrate,xamount,COALESCE(ztsaleh.xticket, '') as xticket,xentrytype from ztsaleh where  xid=@xid";
                //string str = "select ztsaleh.xname,ztsaleh.xphone,ztsaleh.xvotid,ztsaleh.xboarding,ztsaled.xrate,ztsaleh.xamount from ztsaleh inner join ztsaled on ztsaleh.xid=ztsaled.xid where  xid=@xid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn);

                //da.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
                //da.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
                da.SelectCommand.Parameters.AddWithValue("@xid", xid1);


                da.Fill(dts, "temp");
                DataTable dtztemp1 = new DataTable();
                dtztemp1 = dts.Tables["temp"];
                if (dtztemp1.Rows.Count > 0)
                {
                    values = null;
                    for (int i = 0; i < dtztemp1.Rows.Count; i++)
                    {
                        //if (dtztemp1.Rows[i][6].ToString()!="" && xentrytype2!="forsale")
                        //{
                        //    if (dtztemp1.Rows[i][7].ToString() == "manual")
                        //    {
                        //        if (xentrytype2 != "mansale")
                        //        {
                        //            return "Error|This seat should be manual sale.";
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (xentrytype2 != "sale")
                        //        {
                        //            return "Error|This seat should be online sale.";
                        //        }
                        //    }
                        //}

                        //if (i != 0)
                        //{
                        //    values = values + "-" + dtztemp1.Rows[i][0].ToString();
                        //}
                        //else
                        //{
                        //    values = "success-" + dtztemp1.Rows[i][0].ToString();
                        //}
                        //string str = "select xname,xphone,xvotid,xboarding,xrate,xamount from ztsaleh where  xid=@xid";
                        values = "success|" + dtztemp1.Rows[i][0].ToString() + "|" + dtztemp1.Rows[i][1].ToString() + "|" + dtztemp1.Rows[i][2].ToString() + "|" + dtztemp1.Rows[i][3].ToString() + "|" + dtztemp1.Rows[i][4].ToString() + "|" + dtztemp1.Rows[i][5].ToString();
                    }

                    // str = "select xseat from ztsaled where  xdate=@xdate and xcoach=@xcoach and xid=@xid and xstatus='booking'";
                    //string str1 = "select xseat from ztsaled where xdate='2015-02-17' and xcoach='1101A' and xid = 'h-02-2015-000001' and xstatus='booking'";
                    SqlConnection conn12;
                    conn12 = new SqlConnection(zglobal.constring);
                    DataSet dts12 = new DataSet();
                    dts12.Reset();

                    string str12 = "select xseat from ztsaled where  xdate=@xdate and xcoach=@xcoach and xid=@xid and xstatus=@xstatus and xroute=@xroute";
                    SqlDataAdapter da12 = new SqlDataAdapter(str12, conn12);

                    da12.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
                    da12.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
                    da12.SelectCommand.Parameters.AddWithValue("@xid", xid1);
                    da12.SelectCommand.Parameters.AddWithValue("@xstatus", xstatus2);
                    da12.SelectCommand.Parameters.AddWithValue("@xroute", xrouteid);


                    da12.Fill(dts12, "temp");
                    DataTable dtztemp12 = new DataTable();
                    dtztemp12 = dts12.Tables["temp"];

                    string txt = "";
                    //return dtztemp12.Rows.Count.ToString();
                    for (int i = 0; i < dtztemp12.Rows.Count; i++)
                    {
                        txt += dtztemp12.Rows[i][0].ToString();
                        if (i != dtztemp12.Rows.Count - 1)
                        {
                            txt += ",";
                        }
                    }
                    values = values + "|" + txt;
                }
                return values;
            }
            catch (Exception exp)
            {
                return "error|" + exp.Message;
            }

        }


        string xcoachno123;
        static string userid;
        static string location;

        protected void Page_Load(object sender, EventArgs e)
        {

            userid = Convert.ToString(HttpContext.Current.Session["curuser"]);
            location = Convert.ToString(HttpContext.Current.Session["xlocation"]);


            if (!IsPostBack)
            {
                try
                {
                    //Session for return ticket
                    HttpContext.Current.Session["isreturn"] = null;
                    HttpContext.Current.Session["date"] = null;
                    HttpContext.Current.Session["coach"] = null;
                    HttpContext.Current.Session["seat"] = null;
                    HttpContext.Current.Session["time"] = null;
                    HttpContext.Current.Session["route"] = null;
                    HttpContext.Current.Session["name"] = null;
                    HttpContext.Current.Session["phone"] = null;
                    HttpContext.Current.Session["votid"] = null;
                    HttpContext.Current.Session["boarding"] = null;
                    HttpContext.Current.Session["rate"] = null;
                    HttpContext.Current.Session["amount"] = null;
                    HttpContext.Current.Session["discount"] = null;
                    HttpContext.Current.Session["seatid"] = null;
                    HttpContext.Current.Session["print"] = null;

                    ////Check Permission
                    //SiteMaster sm = new SiteMaster();
                    //string s = sm.fnChkPagePermis("ztsales");
                    //if (s == "n" || s == "e")
                    //{
                    //    HttpContext.Current.Session["curuser"] = null;
                    //    Session.Abandon();
                    //    Response.Redirect("~/forms/zlogin.aspx");
                    //}

                    xname1.Value = Request.QueryString["xname1"];
                    xphone1.Value = Request.QueryString["xphone1"];
                    xvotid1.Value = Request.QueryString["xvotid1"];
                    //xcoachno123 = Request.QueryString["xcoachno1"];


                    string xdate1 = DateTime.Now.ToString("MM/dd/yyyy");
                    string xcoach1 = "null";
                    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    xsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xsold");
                    xcan.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xcan");
                    xtotalsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtotalsold");

                    xpdate.Text = "";
                    xpcoachno.Text = "";
                    xptime.Text = "";
                    xpbus.Text = "";
                    xpdriver.Text = "";
                    xpguide.Text = "";
                    xproute.Text = "";
                    btnreservation.Enabled = false;

                    SqlConnection conn2;
                    conn2 = new SqlConnection(zglobal.constring);
                    DataSet dts2 = new DataSet();
                    dts2.Reset();
                    string query = "select xvehicle from ztvech";

                    SqlDataAdapter da2 = new SqlDataAdapter(query, conn2);

                    //string xwh1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    //da2.SelectCommand.Parameters.AddWithValue("@xwh", xwh1);

                    da2.Fill(dts2, "temp");
                    DataTable ztmstk = new DataTable();
                    ztmstk = dts2.Tables["temp"];

                    xbus.Items.Add("[Select]");
                    if (ztmstk.Rows.Count > 0)
                    {
                        for (int i = 0; i < ztmstk.Rows.Count; i++)
                            xbus.Items.Add(ztmstk.Rows[i][0].ToString());
                    }
                    xbus.Text = "[Select]";

                    //query = "select xemp,xname from ztemp where xdesig=LOWER('driver')";

                    //dts2.Reset();
                    //SqlDataAdapter da3 = new SqlDataAdapter(query, conn2);
                    //da3.Fill(dts2, "temp");
                    //DataTable zttemp = new DataTable();
                    //zttemp = dts2.Tables[0];

                    //xdriver.Items.Add(new ListItem("[Select]", "--"));
                    //if (zttemp.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < zttemp.Rows.Count; i++)
                    //        xdriver.Items.Add(new ListItem(zttemp.Rows[i][1].ToString(), zttemp.Rows[i][0].ToString()));
                    //}
                    //xdriver.Text = "[Select]";

                    //query = "select xemp,xname from ztemp where xdesig=LOWER('guide')";

                    //dts2.Reset();
                    //SqlDataAdapter da4 = new SqlDataAdapter(query, conn2);
                    //da4.Fill(dts2, "temp");
                    //DataTable zttemp1 = new DataTable();
                    //zttemp1 = dts2.Tables[0];

                    //xguide.Items.Add(new ListItem("[Select]", "--"));
                    //if (zttemp1.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < zttemp1.Rows.Count; i++)
                    //        xguide.Items.Add(new ListItem(zttemp1.Rows[i][1].ToString(), zttemp1.Rows[i][0].ToString()));
                    //}
                    //xguide.Text = "[Select]";


                    xemp.Text = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    xcounter.Text = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    //xsold.Text = "";
                    //xcan.Text = "";
                    //xtotalsold.Text = "";
                    xtbooked.Text = "";
                    xtsold.Text = "";
                    xtamount.Text = "";


                    xseat.ReadOnly = true;





                    xtime.ReadOnly = true;
                    // Label6.Text = "";

                    xdate.Text = DateTime.Now.ToShortDateString();

                    //Disable Cancel button if user role not sales
                    // dts2.Reset();

                    //string  str2 = "select xrole from ztuser where xuser=@xuser";

                    // SqlDataAdapter da22 = new SqlDataAdapter(str2, conn2);


                    // da22.SelectCommand.Parameters.AddWithValue("@xuser", Convert.ToString(HttpContext.Current.Session["curuser"]));

                    // da22.Fill(dts2, "temp");
                    // DataTable dtztemp2 = new DataTable();
                    // dtztemp2 = dts2.Tables["temp"];


                    // if (dtztemp2.Rows[0][0].ToString() != "Sales")
                    // {
                    //     btnCancel.Enabled = false;
                    // }

                    /////////////////////


                    fnxcoach();

                }
                catch (Exception exp)
                {
                    string message = exp.Message;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                }
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

            string xdate1 = xdate.Text.ToString();
            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                xcoachno.Items.Clear();

                xcoachno.Items.Add(new ListItem("[Select]", string.Empty));
                for (int i = 0; i < dtztcode.Rows.Count; i++)
                {
                    xcoachno.Items.Add(dtztcode.Rows[i][0].ToString());
                }

                xcoachno.Text = "";
            }
            else
            {
                xcoachno.Items.Clear();

                xcoachno.Items.Add(new ListItem("[Select]", string.Empty));
            }
            xtime.Text = "";
            xroute.Items.Clear();
            xroute.Items.Add(new ListItem("[Select]", string.Empty));
        }

        string mainrt = "";

        private string fnBusType()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT xbustype FROM ztcoach  WHERE  xcoachno= @xcoachno";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xcoachno1 = xcoachno.Text.ToString();

            da.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);


            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzt = new DataTable();
            dtzt = dts.Tables[0];

            if (dtzt.Rows.Count > 0)
            {
                return dtzt.Rows[0][0].ToString();
            }
            else
            {
                return "no";
            }
        }
        
        protected void xcoachno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnreservation.Enabled = false;
                msg.InnerText = "";


                if (xcoachno.Text.ToString() == Request.QueryString["xcoachno1"])
                {
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(Panel3);
                    xtime.Text = "";
                    xroute.Items.Clear();
                    xcoachno.BackColor = System.Drawing.Color.Pink;
                    return;
                }

                string bustype123 = fnBusType();
                if (bustype123 != Request.QueryString["xbustype1"])
                {
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(Panel3);
                    msg.InnerText = "Must be Same Class Type Bus";
                    xtime.Text = "";
                    xroute.Items.Clear();
                    xcoachno.BackColor = System.Drawing.Color.Pink;
                    return;
                }

                if (xcoachno.Text == "")
                {
                    xcoachno.BackColor = System.Drawing.Color.Pink;
                    //xcoachno.BorderColor = System.Drawing.Color.DarkRed;

                }
                else
                {
                    xcoachno.BackColor = System.Drawing.Color.White;
                }

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                //string str = "SELECT distinct xdepttime FROM zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno";
                string str = "select (xmrtimeh +':' + xmrtimem + ' ' + xmrtimei ) as time from ztcoach where xcoachno=@xcoachno";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                string xcoachno1 = xcoachno.Text.ToString();
                string xdate1 = xdate.Text.ToString();
                da.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
                //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                if (dtztcode.Rows.Count > 0)
                {
                    xtime.Text = dtztcode.Rows[0][0].ToString();
                }
                else
                {
                    xtime.Text = "";
                }

                str = "select route from ztroute where mrt = (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno)";

                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);


                da1.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
                da1.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

                dts.Reset();
                da1.Fill(dts, "temp1");
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                if (dttemp.Rows.Count > 0)
                {
                    xroute.Items.Clear();
                    xroute.Items.Add(new ListItem("[Select]", string.Empty));
                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {
                        xroute.Items.Add(dttemp.Rows[i][0].ToString());
                    }
                    xroute.Text = "";
                }
                else
                {
                    xroute.Items.Clear();
                    xroute.Items.Add(new ListItem("[Select]", string.Empty));
                }


                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(Panel3);

            }
            catch (Exception exp)
            {
                string message = exp.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            }
        }

        


        protected void xroute_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnreservation.Enabled = false;
                if (xroute.Text == "")
                {
                    xroute.BackColor = System.Drawing.Color.Pink;
                    //xroute.BorderColor = System.Drawing.Color.DarkRed;

                }
                else
                {
                    xroute.BackColor = System.Drawing.Color.White;
                }

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                string str = "select mrt,srt from ztroute where route=@route and mrt= ((select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) )";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                string route = xroute.Text.ToString();
                string xcoachno1 = xcoachno.Text.ToString();
                string xdate1 = xdate.Text.ToString();
                da.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
                da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                da.SelectCommand.Parameters.AddWithValue("@route", route);

                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                if (dtztcode.Rows.Count > 0)
                {

                    if (dtztcode.Rows[0][0].ToString() == dtztcode.Rows[0][1].ToString())
                    {
                        str = "select (xmrtimeh +':' + xmrtimem + ' ' + xmrtimei ) as time from ztcoach where xcoachno=@xcoachno";
                    }
                    else
                    {
                        str = "select (xsrtimeh +':' + xsrtimem + ' ' + xsrtimei ) as time from ztcoachsubrt where xcoachno=@xcoachno and xsrid=@xsrid";
                    }

                    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                    //string xcoachno1 = xcoachno.Text.ToString();
                    selected_route.Value = dtztcode.Rows[0][1].ToString();
                    string xsrid = dtztcode.Rows[0][1].ToString();
                    da1.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
                    da1.SelectCommand.Parameters.AddWithValue("@xsrid", xsrid);

                    dts.Reset();

                    da1.Fill(dts, "temp1");

                    DataTable dttemp = new DataTable();

                    dttemp = dts.Tables[0];

                    if (dttemp.Rows.Count > 0)
                    {
                        xtime.Text = dttemp.Rows[0][0].ToString();
                    }

                }
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(Panel3);
            }
            catch (Exception exp)
            {
                string message = exp.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            }
        }

        protected void xdate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btnreservation.Enabled = false;
                fnxcoach();
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(Panel3);


                if (xdate.Text == "")
                {
                    xdate.BackColor = System.Drawing.Color.Pink;
                    //xdate.BorderColor = System.Drawing.Color.DarkRed;

                }
                else
                {
                    xdate.BackColor = System.Drawing.Color.White;
                }
                //xdate.BackColor = System.Drawing.Color.White;
                //xdate.BorderColor = System.Drawing.Color.White;
                //xcoachno.Items.Clear();
            }
            catch (Exception exp)
            {
                string message = exp.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            }
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //try
            //{

            //    //PlaceHolder1.Controls.Clear();
            //    if (xdate.Text == "" || xcoachno.Text == "" || xroute.Text == "")
            //    {
            //        if (xdate.Text == "")
            //        {
            //            xdate.BackColor = System.Drawing.Color.Pink;


            //        }
            //        else
            //        {
            //            xdate.BackColor = System.Drawing.Color.White;
            //        }
            //        if (xcoachno.Text == "")
            //        {
            //            xcoachno.BackColor = System.Drawing.Color.Pink;


            //        }
            //        else
            //        {
            //            xcoachno.BackColor = System.Drawing.Color.White;
            //        }
            //        if (xroute.Text == "")
            //        {
            //            xroute.BackColor = System.Drawing.Color.Pink;


            //        }
            //        else
            //        {
            //            xroute.BackColor = System.Drawing.Color.White;
            //        }

            //        return;
            //    }

            //    xdate.BackColor = System.Drawing.Color.White;


            //    xcoachno.BackColor = System.Drawing.Color.White;


            //    xroute.BackColor = System.Drawing.Color.White;



            //    /* Auto cancel booking*/

            //    fnAutoCancelBooking(xdate.Text.ToString(), xcoachno.Text.ToString());



            //    /*  Load Bus */
            //    fnBusLoad();


            //}
            //catch (Exception exp)
            //{
            //    msg.InnerHtml = exp.Message;
            //}

        }

        //public void fnSideList()
        //{
        //    /* Side List Load */

        //    fnFillPassengerListDriverInfo();

        //    string xdate1 = Convert.ToDateTime(xdate.Text).ToString();
        //    string xcoach1 = xcoachno.Text;
        //    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
        //    string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

        //    xsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xsold");
        //    //xcan.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xcan");
        //    //xtotalsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtotalsold");
        //    xtbooked.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtbooked");
        //    xtsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtsold");
        //    xtamount.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtamount");

        //    DataTable ztpasslist = new DataTable();
        //    ztpasslist = zglobal.fnSideGridView(xdate1, xcoach1, "sold");
        //    GridView1.DataSource = ztpasslist;
        //    GridView1.DataBind();

        //    DataTable ztbooklist = new DataTable();
        //    ztbooklist = zglobal.fnSideGridView(xdate1, xcoach1, "booking");
        //    GridView2.DataSource = ztbooklist;
        //    GridView2.DataBind();
        //}

        protected void fnBusLoad()
        {
            string attIsEnable = "";

            DateTime srvdtt = DateTime.Now;

            DateTime sdt = new DateTime(srvdtt.Year, srvdtt.Month, srvdtt.Day, srvdtt.Hour, srvdtt.Minute, srvdtt.Second);

            //Check Counter time

            SqlConnection conn01;
            conn01 = new SqlConnection(zglobal.constring);
            DataSet dts01 = new DataSet();
            dts01.Reset();

            string str01 = "select (xctimeh+':'+xctimem+' '+xctimei) as xtime from ztcoachcounter where xcoachno=@xcoach and xcname=@xcname";
            string xcoach01 = xcoachno.Text.ToString();
            string xcname = Convert.ToString(HttpContext.Current.Session["xlocation"]);
            SqlDataAdapter da01 = new SqlDataAdapter(str01, conn01);
            da01.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach01);
            da01.SelectCommand.Parameters.AddWithValue("@xcname", xcname);
            da01.Fill(dts01, "temp");
            DataTable tbl = new DataTable();
            tbl = dts01.Tables[0];


            if (tbl.Rows.Count > 0)
            {
                string ctime = tbl.Rows[0][0].ToString();
                DateTime dtd = Convert.ToDateTime(xdate.Text.ToString());
                DateTime dtt = Convert.ToDateTime(ctime);

                DateTime cdt = new DateTime(dtd.Year, dtd.Month, dtd.Day, dtt.Hour, dtt.Minute, dtt.Second);



                TimeSpan datediff = cdt.Subtract(sdt);



                if (Convert.ToInt32(datediff.TotalSeconds) < 0)
                {
                    attIsEnable = "disabled";
                    btnreservation.Enabled = false;
                }
            }
            else
            {

                //Check Route time

                str01 = "(select (xmrtimeh+':'+xmrtimem+' '+xmrtimei) as xtime from ztcoach where xcoachno=@xcoach and xmrid=@xroute) " +
                      "union " +
                      "(select (xsrtimeh+':'+xsrtimem+' '+xsrtimei) as xtime from ztcoachsubrt where xcoachno=@xcoach and xsrid=@xroute)";

                string xroute01 = selected_route.Value.ToString();

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

                    DateTime dtd = Convert.ToDateTime(xdate.Text.ToString());
                    DateTime dtt = Convert.ToDateTime(rtime);

                    DateTime cdt = new DateTime(dtd.Year, dtd.Month, dtd.Day, dtt.Hour, dtt.Minute, dtt.Second);



                    TimeSpan datediff = cdt.Subtract(sdt);



                    if (Convert.ToInt32(datediff.TotalSeconds) < 0)
                    {
                        attIsEnable = "disabled";
                    }
                }
            }


            /*check if bus omit */

            SqlConnection conn123;
            conn123 = new SqlConnection(zglobal.constring);
            DataSet dts123 = new DataSet();
            dts123.Reset();
            string str123 = "SELECT * FROM ztbusomit  WHERE  xdate=@xdate and xcoach= @xcoach and xopt='omit'";
            SqlDataAdapter da123 = new SqlDataAdapter(str123, conn123);

            DateTime xdate123 = Convert.ToDateTime(xdate.Text.ToString());
            string xcoach123 = xcoachno.Text.ToString();


            da123.SelectCommand.Parameters.AddWithValue("@xdate", xdate123);
            da123.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach123);



            da123.Fill(dts123, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzt123 = new DataTable();
            dtzt123 = dts123.Tables[0];
            if (dtzt123.Rows.Count > 0)
            {
                attIsEnable = "disabled";
            }
            //string attIsEnable;

            //if (Convert.ToDateTime(xdate.Text).Date < DateTime.Now.Date)
            //{
            //    attIsEnable = "disabled";
            //}
            //else
            //{
            //    attIsEnable = "";
            //}

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT xbustype FROM ztcoach  WHERE  xcoachno= @xcoachno";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xcoachno1 = xcoachno.Text.ToString();

            da.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);


            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzt = new DataTable();
            dtzt = dts.Tables[0];


            /*  Load Bus  */
            if (dtzt.Rows.Count > 0)
            {
                bustype1.Value = dtzt.Rows[0][0].ToString();
                string bustype = dtzt.Rows[0][0].ToString();
                if (bustype == "E-Class(B)")
                {
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(eclassb);

                    eclassb.Controls.Add(new LiteralControl(" <table class='bus1'>"
                                                            + "<tr>"
                                                            + "<td bgcolor='#996633' class='bus24' colspan='5'>"
                                                            + " <strong>E-Class (B)</strong><br>"
                                                            + xcoachno.Text.ToString()
                                                            + "</td>"
                                                            + "</tr>"
                                                            + "<tr>"
                                                            + "<td class='bus1121'>"
                                                            + "</td>"
                                                            + "<td class='bus27'>"
                                                            + "</td>"
                                                            + "<td class='bus1122'>"
                                                            + "</td>"
                                                            + "<td class='bus9'>"
                                                            + "</td>"
                                                            + "<td class='bus1123'>"
                                                            + "</td>"
                                                            + "</tr>"));


                    string cid;
                    string cvalue;
                    string cbtclass;

                    for (int i = 1; i <= 6; i++)
                    {
                        eclassb.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 5; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    cid = "ba" + i;
                                    cvalue = "A" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id='" + cid + "'  value='" + cvalue + "' class='" + cbtclass + "'" + attIsEnable + " />"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:
                                    cid = "bb" + i;
                                    cvalue = "B" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 3:
                                    eclassb.Controls.Add(new LiteralControl("<td class='bus1124' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    cid = "bc" + i;
                                    cvalue = "C" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "bd" + i;
                                    cvalue = "D" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        eclassb.Controls.Add(new LiteralControl("</tr>"));
                    }

                    int c = 0;

                    for (int i = 1; i <= 3; i++)
                    {
                        eclassb.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 5; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    c = c + 1;
                                    cid = "bf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:

                                    c = c + 1;
                                    cid = "bf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 3:
                                    eclassb.Controls.Add(new LiteralControl("<td class='bus1124' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    c = c + 1;
                                    cid = "bf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    c = c + 1;
                                    cid = "bf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        eclassb.Controls.Add(new LiteralControl("</tr>"));
                    }

                    for (int i = 1; i <= 1; i++)
                    {
                        eclassb.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 5; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    cid = "bs" + j;
                                    cvalue = "S" + j;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:
                                    cid = "bs" + j;
                                    cvalue = "S" + j;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 3:
                                    eclassb.Controls.Add(new LiteralControl("<td class='bus1124' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    cid = "bs" + (j - 1);
                                    cvalue = "S" + (j - 1);
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "bs" + (j - 1);
                                    cvalue = "S" + (j - 1);
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        eclassb.Controls.Add(new LiteralControl("</tr>"));
                    }


                    eclassb.Controls.Add(new LiteralControl("</table>"));



                }
                else if (bustype == "E-Class(S)")
                {
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(eclasss);

                    eclasss.Controls.Add(new LiteralControl(" <table class='bus1'>"
                                                          + "<tr>"
                                                          + "<td bgcolor='#996633' class='bus24' colspan='9'>"
                                                          + " <strong>E-Class (S)</strong><br>"
                                                          + xcoachno.Text.ToString()
                                                          + "</td>"
                                                          + "</tr>"
                                                          + "<tr>"
                                                          + "<td class='bus1121'>"
                                                          + "</td>"
                                                          + "<td class='bus27' colspan='3'>"
                                                          + "</td>"
                                                          + "<td class='bus1122'>"
                                                          + "</td>"
                                                          + "<td class='bus9' colspan='3'>"
                                                          + "</td>"
                                                          + "<td class='bus1123'>"
                                                          + "</td>"
                                                          + "</tr>"));


                    string cid;
                    string cvalue;
                    string cbtclass;

                    for (int i = 1; i <= 6; i++)
                    {
                        eclasss.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 5; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    cid = "sa" + i;
                                    cvalue = "A" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id='" + cid + "'  value='" + cvalue + "' class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:
                                    cid = "sb" + i;
                                    cvalue = "B" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px' colspan='3'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 3:
                                    eclasss.Controls.Add(new LiteralControl("<td class='bus1124' height='40px' width='40px'>"));
                                    eclasss.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    cid = "sc" + i;
                                    cvalue = "C" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px' colspan='3'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "sd" + i;
                                    cvalue = "D" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        eclasss.Controls.Add(new LiteralControl("</tr>"));
                    }

                    int c = 0;

                    for (int i = 1; i <= 3; i++)
                    {
                        eclasss.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 3; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    c = c + 1;
                                    cid = "sf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus2500' height='40px' colspan='2'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:

                                    c = c + 1;
                                    cid = "sf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus250' height='40px' colspan='5'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;


                                default:
                                    c = c + 1;
                                    cid = "sf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus25000' height='40px' colspan='2'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        eclasss.Controls.Add(new LiteralControl("</tr>"));
                    }

                    for (int i = 1; i <= 1; i++)
                    {
                        eclasss.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 5; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    cid = "ss" + j;
                                    cvalue = "S" + j;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:
                                    cid = "ss" + j;
                                    cvalue = "S" + j;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px' colspan='3'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 3:
                                    eclasss.Controls.Add(new LiteralControl("<td class='bus1124' height='40px' width='40px'>"));
                                    eclasss.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    cid = "ss" + (j - 1);
                                    cvalue = "S" + (j - 1);
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px' colspan='3'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "ss" + (j - 1);
                                    cvalue = "S" + (j - 1);
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        eclasss.Controls.Add(new LiteralControl("</tr>"));
                    }


                    eclasss.Controls.Add(new LiteralControl("</table>"));
                }
                else if (bustype == "Hino-AC")
                {
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(hinoac);



                    hinoac.Controls.Add(new LiteralControl(" <table class='bus1'>"
                                                            + "<tr>"
                                                            + "<td bgcolor='#996633' class='bus24' colspan='5'>"
                                                            + " <strong>Hino-AC</strong><br>"
                                                            + xcoachno.Text.ToString()
                                                            + "</td>"
                                                            + "</tr>"
                                                            + "<tr>"
                                                            + "<td class='bus1121'>"
                                                            + "</td>"
                                                            + "<td class='bus27'>"
                                                            + "</td>"
                                                            + "<td class='bus1122'>"
                                                            + "</td>"
                                                            + "<td class='bus9'>"
                                                            + "</td>"
                                                            + "<td class='bus1123'>"
                                                            + "</td>"
                                                            + "</tr>"));


                    string cid;
                    string cvalue;
                    string cbtclass;

                    for (int i = 1; i <= 6; i++)
                    {
                        hinoac.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 5; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    cid = "ha" + i;
                                    cvalue = "A" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id='" + cid + "'  value='" + cvalue + "' class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:
                                    cid = "hb" + i;
                                    cvalue = "B" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 3:
                                    hinoac.Controls.Add(new LiteralControl("<td class='bus1124' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    cid = "hc" + i;
                                    cvalue = "C" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "hd" + i;
                                    cvalue = "D" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        hinoac.Controls.Add(new LiteralControl("</tr>"));
                    }

                    int c = 0;

                    for (int i = 1; i <= 3; i++)
                    {
                        hinoac.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 5; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    c = c + 1;
                                    cid = "hf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:

                                    c = c + 1;
                                    cid = "hf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 3:
                                    hinoac.Controls.Add(new LiteralControl("<td class='bus1124' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    c = c + 1;
                                    cid = "hf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    c = c + 1;
                                    cid = "hf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        hinoac.Controls.Add(new LiteralControl("</tr>"));
                    }




                    hinoac.Controls.Add(new LiteralControl("</table>"));



                }
                else if (bustype == "S-Class")
                {
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(sclass);

                    sclass.Controls.Add(new LiteralControl(" <table class='bus24'>"
                                                          + "<tr>"
                                                          + "<td bgcolor='#996633' class='bus24' colspan='4'>"
                                                          + " <strong>S-Class</strong><br>"
                                                          + xcoachno.Text.ToString()
                                                          + "</td>"
                                                          + "</tr>"
                                                          + "<tr>"
                                                          + "<td class='bus1121'>"
                                                          + "</td>"

                                                          + "<td class='bus1125'>"
                                                          + "</td>"
                                                          + "<td class='bus9'>"
                                                          + "</td>"
                                                          + "<td class='bus1123'>"
                                                          + "</td>"
                                                          + "</tr>"));


                    string cid;
                    string cvalue;
                    string cbtclass;

                    for (int i = 1; i <= 7; i++)
                    {
                        sclass.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 4; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    cid = "sca" + i;
                                    cvalue = "A" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    sclass.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id='" + cid + "'  value='" + cvalue + "' class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    sclass.Controls.Add(new LiteralControl("</td>"));
                                    break;

                                case 2:
                                    sclass.Controls.Add(new LiteralControl("<td class='bus1126' height='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 3:
                                    cid = "scc" + i;
                                    cvalue = "C" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    sclass.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    sclass.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "scd" + i;
                                    cvalue = "D" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    sclass.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    sclass.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        sclass.Controls.Add(new LiteralControl("</tr>"));
                    }

                    int c = 0;

                    for (int i = 1; i <= 2; i++)
                    {
                        sclass.Controls.Add(new LiteralControl("<tr>"));

                        for (int j = 1; j <= 4; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    c = c + 1;
                                    cid = "scf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    sclass.Controls.Add(new LiteralControl("<td class='bus25' height='40px' width='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    sclass.Controls.Add(new LiteralControl("</td>"));
                                    break;

                                case 2:
                                    sclass.Controls.Add(new LiteralControl("<td class='bus1126' height='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("&nbsp;</td>"));
                                    break;
                                case 4:
                                    c = c + 1;
                                    cid = "scf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    sclass.Controls.Add(new LiteralControl("<td class='bus18' height='40px' width='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
                                    sclass.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    c = c + 1;
                                    cid = "scf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    sclass.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    sclass.Controls.Add(new LiteralControl("</td>"));
                                    break;
                            }









                        }
                        sclass.Controls.Add(new LiteralControl("</tr>"));
                    }




                    sclass.Controls.Add(new LiteralControl("</table>"));




                }
                else
                {

                }

            }
        }

        private string fnSeatStatus(string xseat2)
        {

            /*check if bus omit */

            SqlConnection conn123;
            conn123 = new SqlConnection(zglobal.constring);
            DataSet dts123 = new DataSet();
            dts123.Reset();
            string str123 = "SELECT * FROM ztbusomit  WHERE  xdate=@xdate and xcoach= @xcoach and xopt='omit'";
            SqlDataAdapter da123 = new SqlDataAdapter(str123, conn123);

            DateTime xdate123 = Convert.ToDateTime(xdate.Text.ToString());
            string xcoach123 = xcoachno.Text.ToString();


            da123.SelectCommand.Parameters.AddWithValue("@xdate", xdate123);
            da123.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach123);



            da123.Fill(dts123, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzt123 = new DataTable();
            dtzt123 = dts123.Tables[0];
            if (dtzt123.Rows.Count > 0)
            {
                SqlConnection conn4321;
                conn4321 = new SqlConnection(zglobal.constring);
                DataSet dts4321 = new DataSet();
                dts4321.Reset();
                string str4321 = "SELECT xstatus,xid FROM ztsaled  WHERE  xdate=@xdate and xcoach= @xcoach and xseat=@xseat and xroute=@xroute and xstatus NOT IN ('autocancelbooking', 'reqcancel','forsalesold','bookingcancel','omited','busreserve','manticappcan','cancel','confcan','cancelsold','cancelms','cancelconf')";
                SqlDataAdapter da4321 = new SqlDataAdapter(str4321, conn4321);

                DateTime xdate4321 = Convert.ToDateTime(xdate.Text.ToString());
                string xcoach4321 = xcoachno.Text.ToString();
                string xseat4321 = xseat2;
                string xroute4321 = selected_route.Value;

                da4321.SelectCommand.Parameters.AddWithValue("@xdate", xdate4321);
                da4321.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach4321);
                da4321.SelectCommand.Parameters.AddWithValue("@xseat", xseat4321);
                da4321.SelectCommand.Parameters.AddWithValue("@xroute", xroute4321);


                da4321.Fill(dts4321, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtzt4321 = new DataTable();
                dtzt4321 = dts4321.Tables[0];
                string btclass4321 = "btn";

                if (dtzt4321.Rows.Count > 0)
                {
                    btclass4321 = dtzt4321.Rows[0][0].ToString();


                    //if (btclass == "booking")
                    //{
                    //    string xid1 = dtzt.Rows[0][1].ToString();


                    //    int res = ztsales.fnAutoCancelBooking(xid1,xseat2,xdate1.ToString(),xcoach1,selected_route.Value);

                    //    if (res == 1)
                    //    {
                    //        btclass = "btn";
                    //    }
                    //}


                    return btclass4321;
                }
                string btclass1 = "busomit";
                return btclass1;
            }



            ///////////////////////

            /*check if bus reserve */

            SqlConnection conn1234;
            conn1234 = new SqlConnection(zglobal.constring);
            DataSet dts1234 = new DataSet();
            dts1234.Reset();
            string str1234 = "SELECT * FROM ztreserve  WHERE  xdate=@xdate and xcoach= @xcoach and xstatus='reserve'";
            SqlDataAdapter da1234 = new SqlDataAdapter(str1234, conn1234);

            DateTime xdate1234 = Convert.ToDateTime(xdate.Text.ToString());
            string xcoach1234 = xcoachno.Text.ToString();


            da1234.SelectCommand.Parameters.AddWithValue("@xdate", xdate1234);
            da1234.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1234);



            da1234.Fill(dts1234, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzt1234 = new DataTable();
            dtzt1234 = dts1234.Tables[0];
            if (dtzt1234.Rows.Count > 0)
            {
                string btclass1 = "reserve";
                return btclass1;
            }



            ///////////////////////

            /* Check sequence */

            int hassub = 0;

            string str5 = "select xhsub from ztrtm where xmrid= (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and zactive=1";

            SqlDataAdapter da5 = new SqlDataAdapter(str5, conn1234);


            da5.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach1234);
            da5.SelectCommand.Parameters.AddWithValue("@xdate", xdate1234);


            dts1234.Reset();

            da5.Fill(dts1234, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztemp5 = new DataTable();
            dtztemp5 = dts1234.Tables[0];

            if (dtztemp5.Rows.Count > 0)
            {
                // ViewState["hassub"] = 1;
                hassub = 1;
            }


            if (hassub == 1)
            {
                string selroute = selected_route.Value;
                string jdate = xdate.Text.ToString();
                string jcoach = xcoachno.Text.ToString();
                string xseatid = xseat2;

                string result = zttestbus.fnMultipleRouteSequence(selroute, jcoach, jdate, xseatid);
                //msg.InnerHtml = result;
                if (result != "empty")
                {

                    return result;
                }
            }
            ////////////////////


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT xstatus,xid FROM ztsaled  WHERE  xdate=@xdate and xcoach= @xcoach and xseat=@xseat and xroute=@xroute and xstatus NOT IN ('autocancelbooking', 'reqcancel','forsalesold','bookingcancel','omited','busreserve','manticappcan','cancel','confcan','cancelsold','cancelms','cancelconf')";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            DateTime xdate1 = Convert.ToDateTime(xdate.Text.ToString());
            string xcoach1 = xcoachno.Text.ToString();
            string xseat1 = xseat2;
            string xroute1000 = selected_route.Value;

            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);
            da.SelectCommand.Parameters.AddWithValue("@xseat", xseat1);
            da.SelectCommand.Parameters.AddWithValue("@xroute", xroute1000);


            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzt = new DataTable();
            dtzt = dts.Tables[0];
            string btclass = "btn";

            if (dtzt.Rows.Count > 0)
            {
                btclass = dtzt.Rows[0][0].ToString();


                //if (btclass == "booking")
                //{
                //    string xid1 = dtzt.Rows[0][1].ToString();


                //    int res = ztsales.fnAutoCancelBooking(xid1,xseat2,xdate1.ToString(),xcoach1,selected_route.Value);

                //    if (res == 1)
                //    {
                //        btclass = "btn";
                //    }
                //}


                return btclass;
            }

            //if (btclass != "btn")
            //{
            //    return btclass;
            //}
            //else
            //{
            //    btclass = "btn";
            //}

            return btclass;

        }


        //Old function for booking cancel

        //public static int fnAutoCancelBooking(string xid2, string xseat3, string xdate2, string xcoach2, string xrouteid)
        //{

        //    DateTime srvdtt = DateTime.Now;

        //    DateTime sdt = new DateTime(srvdtt.Year, srvdtt.Month, srvdtt.Day, srvdtt.Hour, srvdtt.Minute, srvdtt.Second);

        //    SqlConnection conn2;
        //    conn2 = new SqlConnection(zglobal.constring);
        //    DataSet dts2 = new DataSet();
        //    dts2.Reset();

        //    string str2 = "select xdateexp,xtimeexp from ztsaleh where xid=@xid";
        //    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

        //    da2.SelectCommand.Parameters.AddWithValue("@xid",xid2);

        //    da2.Fill(dts2, "temp");
        //    DataTable dtztemp1 = new DataTable();
        //    dtztemp1 = dts2.Tables["temp"];

        //    //if (dtztemp1.Rows.Count > 0)
        //    //{
        //        DateTime dtd = Convert.ToDateTime(dtztemp1.Rows[0][0].ToString());
        //        DateTime dtt = Convert.ToDateTime(dtztemp1.Rows[0][1].ToString());

        //        DateTime cdt = new DateTime(dtd.Year, dtd.Month, dtd.Day, dtt.Hour, dtt.Minute, dtt.Second);



        //        TimeSpan datediff = cdt.Subtract(sdt);



        //        if (Convert.ToInt32(datediff.TotalSeconds) < 0)
        //        {
        //            //string xdate2 = Convert.ToDateTime(xdate.Text).ToString();
        //            //string xcoach2 = xcoachno.Text.ToString();

        //            string res = zttestbus.fnBookingCancel(xdate2, xcoach2, xseat3, "1", xrouteid);

        //            if (res == "success")
        //            {
        //                return 1;
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    //}

        //    //return 1;
        //}


        public static void fnAutoCancelBooking(string xdate2, string xcoach2)
        {

            DateTime srvdtt = DateTime.Now;

            DateTime sdt = new DateTime(srvdtt.Year, srvdtt.Month, srvdtt.Day, srvdtt.Hour, srvdtt.Minute, srvdtt.Second);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2 = "select xdateexp,xtimeexp,xid from ztsaleh where xdate=@xdate and xcoach=@xcoach and coalesce(ztsaleh.xticket,'')='' and coalesce(ztsaleh.xtimeexp,'')<>''";
            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
            da2.Fill(dts2, "temp");
            DataTable dtztemp1 = new DataTable();
            dtztemp1 = dts2.Tables["temp"];

            //if (dtztemp1.Rows.Count > 0)
            //{
            for (int i = 0; i < dtztemp1.Rows.Count; i++)
            {
                DateTime dtd = Convert.ToDateTime(dtztemp1.Rows[i][0].ToString());
                DateTime dtt = Convert.ToDateTime(dtztemp1.Rows[i][1].ToString());

                DateTime cdt = new DateTime(dtd.Year, dtd.Month, dtd.Day, dtt.Hour, dtt.Minute, dtt.Second);



                TimeSpan datediff = cdt.Subtract(sdt);



                if (Convert.ToInt32(datediff.TotalSeconds) < 0)
                {
                    //string xdate2 = Convert.ToDateTime(xdate.Text).ToString();
                    //string xcoach2 = xcoachno.Text.ToString();

                    string res = zglobal.fnBookingAutoCancel(xdate2, xcoach2, dtztemp1.Rows[i][2].ToString());


                }
                //}
            }
            //return 1;
        }




        public static void fnDisableCancelbtn(string xdate2, string xcoach2)
        {

            DateTime srvdtt = DateTime.Now;

            DateTime sdt = new DateTime(srvdtt.Year, srvdtt.Month, srvdtt.Day, srvdtt.Hour, srvdtt.Minute, srvdtt.Second);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2 = "select xdateexp,xtimeexp,xid from ztsaleh where xdate=@xdate and xcoach=@xcoach and coalesce(ztsaleh.xticket,'')='' and coalesce(ztsaleh.xtimeexp,'')<>''";
            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
            da2.Fill(dts2, "temp");
            DataTable dtztemp1 = new DataTable();
            dtztemp1 = dts2.Tables["temp"];

            //if (dtztemp1.Rows.Count > 0)
            //{
            for (int i = 0; i < dtztemp1.Rows.Count; i++)
            {
                DateTime dtd = Convert.ToDateTime(dtztemp1.Rows[i][0].ToString());
                DateTime dtt = Convert.ToDateTime(dtztemp1.Rows[i][1].ToString());

                DateTime cdt = new DateTime(dtd.Year, dtd.Month, dtd.Day, dtt.Hour, dtt.Minute, dtt.Second);



                TimeSpan datediff = cdt.Subtract(sdt);



                if (Convert.ToInt32(datediff.TotalSeconds) < 0)
                {
                    //string xdate2 = Convert.ToDateTime(xdate.Text).ToString();
                    //string xcoach2 = xcoachno.Text.ToString();

                    string res = zglobal.fnBookingAutoCancel(xdate2, xcoach2, dtztemp1.Rows[i][2].ToString());


                }
                //}
            }
            //return 1;
        }



        /* Check is driver assign for coach before print passenger list*/
        //[WebMethod(EnableSession = true)]
        //public static string fnChkDriver(string xdate2, string xcoach2)
        //{
        //    try
        //    {
        //        SqlConnection conn2;
        //        conn2 = new SqlConnection(zglobal.constring);
        //        DataSet dts2 = new DataSet();
        //        dts2.Reset();

        //        string str2 = "select count(*) from ztsaledriver where xdate=@xdate and xcoach=@xcoach";
        //        SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

        //        da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
        //        da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

        //        da2.Fill(dts2, "temp");
        //        DataTable dtztemp1 = new DataTable();
        //        dtztemp1 = dts2.Tables["temp"];

        //        if (dtztemp1.Rows[0][0].ToString() == "0")
        //        {
        //            return "0";
        //        }
        //        else
        //        {
        //            return "success";
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        return exp.Message;
        //    }



        //    //return "success";
        //}


        //[WebMethod(EnableSession = true)]
        //public static object fnGetBus(string optfor)
        //{
        //    var objList = (new[] { new { Text = "[Select]", Value = "[Select]" } }).ToList();

        //    try
        //    {
        //        SqlConnection conn2;
        //        conn2 = new SqlConnection(zglobal.constring);
        //        DataSet dts2 = new DataSet();
        //        dts2.Reset();
        //        string query = "select xvehicle from ztvech";

        //        SqlDataAdapter da2 = new SqlDataAdapter(query, conn2);

        //        //string xwh1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

        //        //da2.SelectCommand.Parameters.AddWithValue("@xwh", xwh1);

        //        da2.Fill(dts2, "temp");
        //        DataTable ztmstk = new DataTable();
        //        ztmstk = dts2.Tables["temp"];





        //        if (ztmstk.Rows.Count > 0)
        //        {


        //            for (int i = 0; i < ztmstk.Rows.Count; i++)
        //            {
        //                objList.Add(new { Text = ztmstk.Rows[i][0].ToString(), Value = ztmstk.Rows[i][0].ToString() });
        //            }

        //        }
        //        else
        //        {
        //            //var obj1 = (new[] { new { Text = "You are out of stock.", Value = "You are out of stock." } }).ToList();
        //            //return obj1;

        //        }

        //        da2.Dispose();
        //        dts2.Dispose();
        //        conn2.Dispose();



        //    }
        //    catch (Exception exp)
        //    {
        //        //var obj2 = (new[] { new { Text = exp.Message, Value = exp.Message } }).ToList();
        //        //return obj2;


        //    }

        //    return objList;
        //}

        //[WebMethod(EnableSession = true)]
        //public static object fnGetDriverGuide(string optfor)
        //{
        //    var objList = (new[] { new { Text = "[Select]", Value = "[Select]" } }).ToList();

        //    try
        //    {
        //        SqlConnection conn2;
        //        conn2 = new SqlConnection(zglobal.constring);
        //        DataSet dts2 = new DataSet();
        //        dts2.Reset();

        //        string query;
        //        if (optfor == "driver")
        //        {
        //            query = "select xemp,xname from ztemp where xdesig=LOWER('driver')";
        //        }
        //        else
        //        {
        //            query = "select xemp,xname from ztemp where xdesig=LOWER('guide')";
        //        }

        //        SqlDataAdapter da2 = new SqlDataAdapter(query, conn2);

        //        //string xwh1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

        //        //da2.SelectCommand.Parameters.AddWithValue("@xwh", xwh1);

        //        da2.Fill(dts2, "temp");
        //        DataTable ztmstk = new DataTable();
        //        ztmstk = dts2.Tables["temp"];





        //        if (ztmstk.Rows.Count > 0)
        //        {


        //            for (int i = 0; i < ztmstk.Rows.Count; i++)
        //            {
        //                objList.Add(new { Text = ztmstk.Rows[i][1].ToString(), Value = ztmstk.Rows[i][0].ToString() });
        //            }

        //        }
        //        else
        //        {
        //            //var obj1 = (new[] { new { Text = "You are out of stock.", Value = "You are out of stock." } }).ToList();
        //            //return obj1;

        //        }

        //        da2.Dispose();
        //        dts2.Dispose();
        //        conn2.Dispose();



        //    }
        //    catch (Exception exp)
        //    {
        //        //var obj2 = (new[] { new { Text = exp.Message, Value = exp.Message } }).ToList();
        //        //return obj2;


        //    }

        //    return objList;
        //}



        //public static string fnmaxidfordriverassign()
        //{
        //    DateTime dt = DateTime.Now;
        //    DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
        //    DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
        //    DateTime lastDate = lastDate1.Date.AddMinutes(1439);

        //    SqlConnection conn2;
        //    conn2 = new SqlConnection(zglobal.constring);
        //    DataSet dts2 = new DataSet();
        //    dts2.Reset();

        //    string str2;
        //    //string prefix;

        //    str2 = "SELECT max(xrow) FROM ztsaledriver where xentdt between @firstdate and @lastdate";


        //    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
        //    string firstdate = firstDate.ToString();
        //    string lastdate = lastDate.ToString();
        //    //txtDue.Text = date;
        //    da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstdate);
        //    da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastdate);
        //    da2.Fill(dts2, "temp");
        //    DataTable xid1 = new DataTable();
        //    xid1 = dts2.Tables["temp"];
        //    //txtAmount.Text = voucher.Rows.Count.ToString();

        //    string maxrow;




        //    if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
        //    {
        //        string s = xid1.Rows[0][0].ToString();
        //        int vno = Convert.ToInt32(s.Substring(s.Length - 3));
        //        ////txtDue.Text = vno.ToString();
        //        int vno1 = vno + 1;
        //        string s2 = Convert.ToString(vno1);
        //        if (s2.Length == 1)
        //        {
        //            s2 = "00" + s2;
        //        }
        //        else if (s2.Length == 2)
        //        {
        //            s2 = "0" + s2;
        //        }

        //        maxrow = dt.ToString("MMyyyy") + s2;
        //        //txtVoucherNo.Text = "";
        //    }
        //    else
        //    {
        //        maxrow = dt.ToString("MMyyyy") + "001";
        //    }
        //    da2.Dispose();
        //    dts2.Dispose();
        //    conn2.Dispose();

        //    return maxrow;

        //}

        //[WebMethod(EnableSession = true)]
        //public static string fnSaveDriver(string xpcoach2, string xbus2, string xpbustype2, string xdriver2, string xguide2, string xdate2)
        //{
        //    try
        //    {
        //        SqlConnection conn1;
        //        conn1 = new SqlConnection(zglobal.constring);
        //        SqlCommand dataCmd = new SqlCommand();
        //        dataCmd.Connection = conn1;
        //        string query;

        //        query = "INSERT INTO ztsaledriver" +
        //                 "(xrow,xdate,xcoach,xbus,xbustype,xdriver,xguide,xentdt,xentby,xentloc) " +
        //                 "VALUES (@xrow,@xdate,@xcoach,@xbus,@xbustype,@xdriver,@xguide,@xentdt,@xentby,@xentloc) ";

        //        dataCmd.CommandText = query;

        //        string xrow1 = fnmaxidfordriverassign();
        //        DateTime xentdt1 = DateTime.Now;
        //        string xentby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
        //        string xentloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

        //        dataCmd.Parameters.AddWithValue("@xrow", xrow1);
        //        dataCmd.Parameters.AddWithValue("@xdate", xdate2);
        //        dataCmd.Parameters.AddWithValue("@xcoach", xpcoach2);
        //        dataCmd.Parameters.AddWithValue("@xbus", xbus2);
        //        dataCmd.Parameters.AddWithValue("@xbustype", xpbustype2);
        //        dataCmd.Parameters.AddWithValue("@xdriver", xdriver2);
        //        dataCmd.Parameters.AddWithValue("@xguide", xguide2);
        //        dataCmd.Parameters.AddWithValue("@xentdt", xentdt1);
        //        dataCmd.Parameters.AddWithValue("@xentby", xentby1);
        //        dataCmd.Parameters.AddWithValue("@xentloc", xentloc1);

        //        conn1.Close();
        //        conn1.Open();
        //        dataCmd.ExecuteNonQuery();
        //        conn1.Close();


        //        return "success";
        //    }
        //    catch (Exception exp)
        //    {
        //        return exp.Message;
        //    }
        //}

        //protected void fnFillPassengerListDriverInfo()
        //{
        //    try
        //    {
        //        string xdate2 = xdate.Text.ToString();
        //        string xcoach2 = xcoachno.Text.ToString();

        //        string xchkdriver = fnChkDriver(xdate2, xcoach2);

        //        if (xchkdriver == "success")
        //        {


        //            xpdate.Text = xdate2.ToString();
        //            xpcoachno.Text = xcoach2.ToString();

        //            SqlConnection conn2;
        //            conn2 = new SqlConnection(zglobal.constring);
        //            DataSet dts2 = new DataSet();
        //            dts2.Reset();

        //            string str2 = "select xbus,xdriver, xguide from ztsaledriver where xdate=@xdate and xcoach=@xcoach and xrow=(select max(xrow) from ztsaledriver where xdate=@xdate and xcoach=@xcoach)";
        //            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

        //            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
        //            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

        //            da2.Fill(dts2, "temp");
        //            DataTable dtztemp = new DataTable();
        //            dtztemp = dts2.Tables["temp"];

        //            xpbus.Text = dtztemp.Rows[0][0].ToString();
        //            xpdriver.Text = dtztemp.Rows[0][1].ToString();
        //            xpguide.Text = dtztemp.Rows[0][2].ToString();

        //            /* Retrive route and time from ztcoach */

        //            dts2.Reset();

        //            str2 = "select (select xmf + '-' + xmt from ztrtm where xmrid=ztcoach.xmrid) as xroute, (xmrtimeh +':'+ xmrtimem +' '+xmrtimei) as xtime from ztcoach where xcoachno=@xcoachno";

        //            SqlDataAdapter da3 = new SqlDataAdapter(str2, conn2);

        //            da3.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
        //            da3.Fill(dts2, "temp1");

        //            dtztemp.Reset();
        //            dtztemp = dts2.Tables["temp1"];

        //            xproute.Text = dtztemp.Rows[0][0].ToString();
        //            xptime.Text = dtztemp.Rows[0][1].ToString();

        //        }
        //        else
        //        {
        //            xpdate.Text = "";
        //            xpcoachno.Text = "";
        //            xptime.Text = "";
        //            xpbus.Text = "";
        //            xpdriver.Text = "";
        //            xpguide.Text = "";
        //            xproute.Text = "";
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        msg.InnerHtml = exp.Message;
        //    }
        //}


        [WebMethod(EnableSession = true)]
        public static int fnChkUser(string sid, string xdate2, string xcoach2, string xrouteid)
        {

            try
            {


                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                string str = "select xuser from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                string xseat1 = sid;
                DateTime xdate1 = Convert.ToDateTime(xdate2);
                //string xdate1 = xdate2;
                string xcoach1 = xcoach2;

                da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);
                da.SelectCommand.Parameters.AddWithValue("@xseat", xseat1);
                da.SelectCommand.Parameters.AddWithValue("@xroute", xrouteid);

                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcurseat = new DataTable();
                dtztcurseat = dts.Tables[0];

                if (dtztcurseat.Rows.Count > 0)
                {
                    string getusr = dtztcurseat.Rows[0][0].ToString();
                    string curuser = Convert.ToString(HttpContext.Current.Session["curuser"]);

                    if (getusr == curuser)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }




                return -11;
            }
            catch (Exception exp)
            {
                return 11;
            }


        }

        [WebMethod(EnableSession = true)]
        public static string getResFare(string xfare2, string xcoachno2)
        {
            string xfare1 = "";

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT xbustype FROM ztcoach  WHERE  xcoachno= @xcoachno";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xcoachno1 = xcoachno2;

            da.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);


            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzt = new DataTable();
            dtzt = dts.Tables[0];



            if (dtzt.Rows.Count > 0)
            {

                string bustype = dtzt.Rows[0][0].ToString();
                if (bustype == "E-Class(B)")
                {
                    xfare1 = Convert.ToString(Convert.ToInt32(xfare2) * 40);
                }
                else if (bustype == "E-Class(S)")
                {
                    xfare1 = Convert.ToString(Convert.ToInt32(xfare2) * 37);
                }
                else if (bustype == "Hino-AC")
                {
                    xfare1 = Convert.ToString(Convert.ToInt32(xfare2) * 36);
                }
                else
                {
                    xfare1 = Convert.ToString(Convert.ToInt32(xfare2) * 27);
                }
            }

            return xfare1;
        }


        [WebMethod(EnableSession = true)]
        public static string fnCheckSeatExist(string xcoach2, string xdate2)
        {
            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                string str = "(SELECT xcoach  FROM ztsaled  WHERE  xdate= @xdate and xcoach=@xcoach and " +
                             " xstatus NOT IN ('autocancelbooking', 'reqcancel','forsalesold','bookingcancel','omited','busreserve','manticappcan','cancel','confcan','cancelsold','cancelms','cancelconf') " +
                             " ) UNION ALL (SELECT xcoach  FROM ztreserve  WHERE  xdate= @xdate and xcoach=@xcoach)";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);


                da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);


                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtzt = new DataTable();
                dtzt = dts.Tables[0];

                if (dtzt.Rows.Count > 0)
                {
                    return "This coach already sale or booking seat. Please exchage this coach with another coach or empty this bus before reserve. or This coach already reserved";
                }

                return "success";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }


        [WebMethod(EnableSession = true)]
        public static string fnBusReserve(string xcoach2, string xdeplace2, string xdest2, string xdate2, string xtime2, string xresby2, string xcontact2, string xrefby2, string xfare2, string xpayment2, string xpayby2)
        {
            try
            {


                using (TransactionScope tran = new TransactionScope())
                {

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;
                    query = "UPDATE ztsaled SET xstatus='busreserve' " +
                                             "WHERE xdate=@xdate AND xcoach=@xcoach";

                    dataCmd.CommandText = query;

                    string xdate1 = xdate2;
                    string xcoach1 = xcoach2;

                    dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);

                    conn1.Close();
                    conn1.Open();
                    dataCmd.ExecuteNonQuery();

                    query = "INSERT INTO ztreserve " +
                                " (xrow,xcoach,xdplace,xdest,xdate,xtime,xresby,xcontact,xrefby,xfare,xpayment,xpayby,xcreatedby,xcreatedt,xloc,xstatus) " +
                                " VALUES (@xrow,@xcoach,@xdplace,@xdest,@xdate,@xtime,@xresby,@xcontact,@xrefby,@xfare,@xpayment,@xpayby,@xcreatedby,@xcreatedt,@xloc,'reserve') ";

                    dataCmd.CommandText = query;

                    string xrow1 = zglobal.fnmaxid("SELECT max(xrow) FROM ztreserve where getdate() between @firstdate and @lastdate");
                    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    DateTime xdt1 = DateTime.Now;
                    string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                    double xfare3 = Convert.ToDouble(xfare2);
                    double xpayment3 = Convert.ToDouble(xpayment2);

                    dataCmd.Parameters.Clear();
                    dataCmd.Parameters.AddWithValue("@xrow", xrow1);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach2);
                    dataCmd.Parameters.AddWithValue("@xdplace", xdeplace2);
                    dataCmd.Parameters.AddWithValue("@xdest", xdest2);
                    dataCmd.Parameters.AddWithValue("@xdate", xdate2);
                    dataCmd.Parameters.AddWithValue("@xtime", xtime2);
                    dataCmd.Parameters.AddWithValue("@xresby", xresby2);
                    dataCmd.Parameters.AddWithValue("@xcontact", xcontact2);
                    dataCmd.Parameters.AddWithValue("@xrefby", xrefby2);
                    dataCmd.Parameters.AddWithValue("@xfare", xfare3);
                    dataCmd.Parameters.AddWithValue("@xpayment", xpayment3);
                    dataCmd.Parameters.AddWithValue("@xpayby", xpayby2);

                    dataCmd.Parameters.AddWithValue("@xcreatedby", xuser1);
                    dataCmd.Parameters.AddWithValue("@xcreatedt", xdt1);
                    dataCmd.Parameters.AddWithValue("@xloc", xloc1);

                    dataCmd.ExecuteNonQuery();

                    conn1.Close();

                    tran.Complete();


                }
            }
            catch (Exception exp)
            {
                return exp.Message;
            }


            return "success";
        }

        protected void btnreservation_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnReload_Click1(object sender, EventArgs e)
        {
            //Response.Redirect(Request.RawUrl, true);
        }

        protected void btnrefresh_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //PlaceHolder1.Controls.Clear();
                if (xdate.Text == "" || xcoachno.Text == "" || xroute.Text == "")
                {
                    if (xdate.Text == "")
                    {
                        xdate.BackColor = System.Drawing.Color.Pink;


                    }
                    else
                    {
                        xdate.BackColor = System.Drawing.Color.White;
                    }
                    if (xcoachno.Text == "")
                    {
                        xcoachno.BackColor = System.Drawing.Color.Pink;


                    }
                    else
                    {
                        xcoachno.BackColor = System.Drawing.Color.White;
                    }
                    if (xroute.Text == "")
                    {
                        xroute.BackColor = System.Drawing.Color.Pink;


                    }
                    else
                    {
                        xroute.BackColor = System.Drawing.Color.White;
                    }

                    return;
                }

                xdate.BackColor = System.Drawing.Color.White;


                xcoachno.BackColor = System.Drawing.Color.White;


                xroute.BackColor = System.Drawing.Color.White;



                /* Auto cancel booking*/

                fnAutoCancelBooking(xdate.Text.ToString(), xcoachno.Text.ToString());



                /*  Load Bus */
                fnBusLoad();


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }



    }
}