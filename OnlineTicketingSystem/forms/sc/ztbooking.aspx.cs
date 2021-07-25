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

    public class seatprocess
    {
        private string seatid;
        private string userid;



        public seatprocess()
        {
            this.seatid = "";
            this.userid = "";
        }

        public seatprocess(string sid, string uid)
        {
            this.seatid = sid;
            this.userid = uid;
        }

        public string Seatid
        {
            get { return seatid; }
            set { seatid = value; }
        }

        public string Userid
        {
            get { return userid; }
            set { userid = value; }

        }
    }


    public partial class zttestbus : System.Web.UI.Page
    {




        protected static string fnmaxrow(string query)
        {
            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2 = query;
            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            da2.Fill(dts2, "temp");
            DataTable supcode = new DataTable();
            supcode = dts2.Tables["temp"];

            string maxrow;
            if (!Convert.IsDBNull(supcode.Rows[0][0]))
            {
                string s = supcode.Rows[0][0].ToString();
                int supcd = Convert.ToInt32(s);

                int supcd1 = supcd + 1;
                string s2 = Convert.ToString(supcd1);

                maxrow = s2;

            }
            else
            {
                maxrow = "1";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }


        //public List<string> fnReturnVal(string entrytype, string type)
        //{
        //string xid1 = zttestbus.fnmaxrow("select max(xid) from ztsaleh");
        //string xdate1 = xdate.Text.ToString();
        //string xcoach1 = xcoachno.Text.ToString();
        //string xname1 = xname.Text.ToString();
        //string xphone1 = xphone.Text.ToString();
        //string xvotid1 = xvotid.Text.ToString();
        //string xboarding1 = xboarding.Text.ToString();
        //string xseat1 = xseat.Text.ToString();
        //string xrate1 = xrate.Text.ToString();
        //string xamount1 = xamount.Text.ToString();
        //string xdateexp1 = xdateexp.Text.ToString();
        //string xtimeexp1 = mydwh + ":" + mydwm + " " + mydwi;
        //string xcur1 = "BDT";
        //string xexchange1 = "1";
        //string xcreatedby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
        //string xcreatedt1 = Convert.ToString(DateTime.Now);
        //string xlocation1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

        //string xbookingno1;
        //string xticket1;

        //if (type == "b")
        //{
        //    xbookingno1 = fnmaxidno("b");
        //    xticket1 = "0";

        //}
        //{
        //    xbookingno1 = "0";
        //    xticket1 = fnmaxidno("t");
        //}

        //string xentrytype1 = entrytype;


        //List<string> val = new List<string>();

        //val.Add(xid1);
        //val.Add(xdate1);
        //val.Add(xcoach1);
        //val.Add(xname1);
        //val.Add(xphone1);
        //val.Add(xvotid1);
        //val.Add(xboarding1);
        //val.Add(xseat1);
        //val.Add(xrate1);
        //val.Add(xamount1);
        //val.Add(xdateexp1);
        //val.Add(xtimeexp1);
        //val.Add(xcur1);
        //val.Add(xexchange1);
        //val.Add(xcreatedby1);
        //val.Add(xcreatedt1);
        //val.Add(xlocation1);
        //val.Add(xbookingno1);
        //val.Add(xticket1);
        //val.Add(xentrytype1);

        //return val;

        //}

        public static string fnmaxidforlog(string dtt)
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

            str2 = "SELECT max(xrow) FROM ztlogs where xdate between @firstdate and @lastdate";
            prefix = "l";

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

        public static string fnmaxidno(string type, string dtt)
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
            if (type == "b")
            {
                str2 = "SELECT max(xbookingno) FROM ztsaleh where xdate between @firstdate and @lastdate";
                prefix = "BK";
            }
            //else if(type == "l")
            //{
            //    str2 = "SELECT max(xrow) FROM ztlogs where xdate between @firstdate and @lastdate";
            //    prefix = "l";
            //}
            else if (type == "d")
            {
                str2 = "SELECT max(xrow) FROM ztsaled where xdate between @firstdate and @lastdate";
                prefix = "d";
            }
            else if (type == "h")
            {
                str2 = "SELECT max(xid) FROM ztsaleh where xdate between @firstdate and @lastdate";
                prefix = "h";
            }
            else
            {
                str2 = "SELECT max(xticket) FROM ztsaleh where xdate between @firstdate and @lastdate and xentrytype='online'";
                prefix = "SL";
            }
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
                int vno = Convert.ToInt32(s.Substring(s.Length - 6));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "00000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 5)
                {
                    s2 = "0" + s2;
                }


                if (type == "s")
                {
                    maxrow = dt.ToString("MMyyyy") + "-" + s2;
                }
                else
                {
                    maxrow = prefix + "-" + dt.ToString("MM-yyyy") + "-" + s2;
                }
                //txtVoucherNo.Text = "";
            }
            else
            {
                if (type == "s")
                {
                    maxrow = dt.ToString("MMyyyy") + "-" + "000001";
                }
                else
                {
                    maxrow = prefix + "-" + dt.ToString("MM-yyyy") + "-" + "000001";
                }
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }

        public static string fnmaxidno123(string type, string dtt)
        {
            DateTime dt = Convert.ToDateTime(dtt);
            //DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            //DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            //DateTime lastDate = lastDate1.Date.AddMinutes(1439);
            DateTime firstDate = new DateTime(dt.Year, 1, 1);
            DateTime lastDate1 = firstDate.AddYears(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2;
            string prefix;
            if (type == "b")
            {
                str2 = "SELECT max(xbookingno) FROM ztsaleh where xdate between @firstdate and @lastdate";
                prefix = "BK";
            }
            //else if(type == "l")
            //{
            //    str2 = "SELECT max(xrow) FROM ztlogs where xdate between @firstdate and @lastdate";
            //    prefix = "l";
            //}
            else if (type == "d")
            {
                str2 = "SELECT max(xrow) FROM ztsaled where xdate between @firstdate and @lastdate";
                prefix = "d";
            }
            else if (type == "h")
            {
                str2 = "SELECT max(xid) FROM ztsaleh where xdate between @firstdate and @lastdate";
                prefix = "h";
            }
            else
            {
               // str2 = "SELECT max(xticket) FROM ztsaleh where xdate between @firstdate and @lastdate and xentrytype='online'";
                str2 = "SELECT max(rtrim(right(xticket,6))) FROM ztsaleh  where xdate between @firstdate and @lastdate and xentrytype='online'";
                prefix = "SL";
            }
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
            string counter;
            string emp;

            str2 = "select UPPER(SUBSTRING(xid,0,LEN(xid)-4))+ Cast(Cast(RIGHT(xid,4) as INT) as varchar) from ztcounter where xcname=@xcname";
            SqlDataAdapter dac = new SqlDataAdapter(str2, conn2);
            DataSet dtsc = new DataSet();

            string xcname = Convert.ToString( HttpContext.Current.Session["xlocation"]);
            dac.SelectCommand.Parameters.AddWithValue("@xcname", xcname);
            dac.Fill(dtsc, "temp");
            DataTable tbl_counter = new DataTable();
            tbl_counter = dtsc.Tables["temp"];
            counter = tbl_counter.Rows[0][0].ToString();

            str2 = "select Coalesce(NullIf(rtrim(RIGHT(xempcode,3)),''),'***')  from ztuser where xuser=@xuser";
            SqlDataAdapter dae = new SqlDataAdapter(str2, conn2);
            DataSet dtse = new DataSet();

            string xuser = Convert.ToString(HttpContext.Current.Session["curuser"]);
            dae.SelectCommand.Parameters.AddWithValue("@xuser", xuser);
            dae.Fill(dtse, "temp");
            DataTable tbl_user = new DataTable();
            tbl_user = dtse.Tables["temp"];
            emp = tbl_user.Rows[0][0].ToString();




            if (!Convert.IsDBNull(voucher.Rows[0][0]) && voucher.Rows[0][0].ToString() != "")
            {
                string s = voucher.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 6));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "00000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 5)
                {
                    s2 = "0" + s2;
                }


                if (type == "s")
                {
                    maxrow = counter+ emp + dt.ToString("yy") + s2;
                }
                else
                {
                    maxrow = prefix + "-" + dt.ToString("MM-yyyy") + "-" + s2;
                }
                //txtVoucherNo.Text = "";
            }
            else
            {
                if (type == "s")
                {
                    maxrow = counter + emp + dt.ToString("yy") + "000001";
                }
                else
                {
                    maxrow = prefix + "-" + dt.ToString("MM-yyyy") + "-" + "000001";
                }
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }

        [WebMethod(EnableSession = true)]
        public static string fnSaveBooking(string chkst2, string xstatus2, string xdate2, string xcoach2, string xname2, string xphone2, string xvotid2, string xboarding2, string xseat2, string xrate2, string xamount2, string xdateexp2, string xtimeexp2, string xbutton2, string xseatid2, string xforsale, string xrttime2, string xroute2, string xticket2, string xrouteid, string xdiscount)
        {

            try
            {
                if (HttpContext.Current.Session["curuser"] == null || Convert.ToString(HttpContext.Current.Session["curuser"]) == "" )
                {
                    HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Redirect("~/forms/zlogin.aspx");
                }



                ////////get the route id from ztroute view////////////////
                SqlConnection conn12345678;
                conn12345678 = new SqlConnection(zglobal.constring);
                DataSet dts123 = new DataSet();
                dts123.Reset();
                string str123 = "select srt from ztroute where mrt = (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and route=@route";
                SqlDataAdapter da123 = new SqlDataAdapter(str123, conn12345678);

                da123.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
                da123.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                da123.SelectCommand.Parameters.AddWithValue("@route", xroute2);

                dts123.Reset();
                da123.Fill(dts123, "temp1");
                DataTable dttemp123 = new DataTable();
                dttemp123 = dts123.Tables[0];

                string xroute1 = dttemp123.Rows[0][0].ToString();

                ////////////////////////////////////////////////////////////

                //check manual ticket double sale

                if (xstatus2 == "manticapppen")
                {
                   
                    SqlConnection conn12345;
                    conn12345 = new SqlConnection(zglobal.constring);
                    DataSet dts12345 = new DataSet();



                    string str55 = "select * from ztsaleh where cast(xcreatedt as date)=cast(GETDATE() as date) and xticket=@xticket";

                    SqlDataAdapter da55 = new SqlDataAdapter(str55, conn12345);


                    da55.SelectCommand.Parameters.AddWithValue("@xticket", xticket2);
                 


                    dts12345.Reset();

                    da55.Fill(dts12345, "tempzt");
                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable dtztemp55 = new DataTable();
                    dtztemp55 = dts12345.Tables[0];
                    if (dtztemp55.Rows.Count > 0)
                    {
                        return "Ticket already sold, please try another.";
                    }
                }

                //zttestbus bus = new zttestbus();
                /*  check if seat already booked*/
                if (xstatus2 == "booking" || xstatus2 == "confbooking")
                {

                    /* Check sequence */
                    SqlConnection conn1234;
                    conn1234 = new SqlConnection(zglobal.constring);
                    DataSet dts1234 = new DataSet();

                    int hassub = 0;

                    string str5 = "select xhsub from ztrtm where xmrid= (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and zactive=1";

                    SqlDataAdapter da5 = new SqlDataAdapter(str5, conn1234);


                    da5.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
                    da5.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);


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
                        string selroute = xroute1;
                        string jdate = xdate2;
                        string jcoach = xcoach2;
                        string xseatid = xseat2;
                        string xstatus678 = @"'sold','mansale','confbooking','booking','manticapppen','cancelpending'";
                        string result = fnChkMultirouteSale(selroute, jcoach, jdate, xseatid, xstatus678);

                        //msg.InnerHtml = result;
                        
                        if (result == "true")
                        {
                            //if (result == "booking")
                            //{
                            //    string xid1 = dtzt.Rows[0][1].ToString();



                            //    int res = ztsales.fnAutoCancelBooking(xid1, xseat2, xdate1.ToString(), xcoach1, xroute1000);

                            //    if (res == 1)
                            //    {
                            //        result = "btn";
                            //    }
                            //}

                            return "Please reload the coach before sale ticket. Your time period has expired.";
                        }
                    }
                    ////////////////////

                    else
                    {
                        SqlConnection conn2;
                        conn2 = new SqlConnection(zglobal.constring);
                        DataSet dts2 = new DataSet();
                        dts2.Reset();

                        string str2 = "select xseat from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','mansale','confbooking','booking','manticapppen','cancelpending') and xroute=@xroute";
                        SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                        da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                        da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                        da2.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                        da2.Fill(dts2, "temp");
                        DataTable dtztemp = new DataTable();
                        dtztemp = dts2.Tables["temp"];

                        if (dtztemp.Rows.Count > 0)
                        {

                            string[] xseat9 = xseat2.Split(',');
                            for (int i = 0; i < xseat9.Length; i++)
                            {
                                for (int j = 0; j < dtztemp.Rows.Count; j++)
                                {
                                    if (xseat9[i] == dtztemp.Rows[j][0].ToString())
                                    {
                                        //zttestbus bus = new zttestbus();

                                        //bus.fnBusLoad();

                                        return "booked";
                                    }
                                }
                            }
                        }
                    }
                }




                /*  check if seat already sale*/
                if (chkst2 == "sale" || chkst2 == "mansale")
                {


                    /* Check sequence */
                    SqlConnection conn1234;
                    conn1234 = new SqlConnection(zglobal.constring);
                    DataSet dts1234 = new DataSet();

                    int hassub = 0;

                    string str5 = "select xhsub from ztrtm where xmrid= (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and zactive=1";

                    SqlDataAdapter da5 = new SqlDataAdapter(str5, conn1234);


                    da5.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
                    da5.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);


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
                        string selroute = xroute1;
                        string jdate = xdate2;
                        string jcoach = xcoach2;
                        string xseatid = xseat2;
                        string xstatus678 = @"'sold','mansale','confbooking','booking','manticapppen','cancelpending'";
                        string result = fnChkMultirouteSale(selroute, jcoach, jdate, xseatid, xstatus678);

                       
                        //msg.InnerHtml = result;
                        if (result == "true")
                        {
                            //if (result == "booking")
                            //{
                            //    string xid1 = dtzt.Rows[0][1].ToString();



                            //    int res = ztsales.fnAutoCancelBooking(xid1, xseat2, xdate1.ToString(), xcoach1, xroute1000);

                            //    if (res == 1)
                            //    {
                            //        result = "btn";
                            //    }
                            //}

                            return "Please reload the coach before sale ticket. Your time period has expired.";
                        }
                    }
                    ////////////////////

                    else
                    {
                        SqlConnection conn2;
                        conn2 = new SqlConnection(zglobal.constring);
                        DataSet dts2 = new DataSet();
                        dts2.Reset();

                        //string str2 = "SELECT * FROM ztsaled WHERE xcoach=@xcoach AND xdate=@xdate AND xseatid=@xseat AND xroute=@xroute AND xstatus IN ('sold','mansale','confbooking','booking','manticapppen','cancelpending')";
                        string str2 = "select xseat from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','mansale','confbooking','booking','manticapppen','cancelpending') and xroute=@xroute";

                        SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                        da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                        da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                        da2.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                        da2.Fill(dts2, "temp");
                        DataTable dtztemp = new DataTable();
                        dtztemp = dts2.Tables["temp"];

                        if (dtztemp.Rows.Count > 0)
                        {

                            string[] xseat9 = xseat2.Split(',');
                            for (int i = 0; i < xseat9.Length; i++)
                            {
                                for (int j = 0; j < dtztemp.Rows.Count; j++)
                                {
                                    if (xseat9[i] == dtztemp.Rows[j][0].ToString())
                                    {
                                        //zttestbus bus = new zttestbus();

                                        //bus.fnBusLoad();

                                        return "Please reload the coach before sale ticket. Your time period has expired.";
                                    }
                                }
                            }
                        }
                    }
                }


                /*  check if seat already sale*/
                if (chkst2 == "booked" || chkst2 == "confbooked")
                {


                    /* Check sequence */
                    SqlConnection conn1234;
                    conn1234 = new SqlConnection(zglobal.constring);
                    DataSet dts1234 = new DataSet();

                    int hassub = 0;

                    string str5 = "select xhsub from ztrtm where xmrid= (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and zactive=1";

                    SqlDataAdapter da5 = new SqlDataAdapter(str5, conn1234);


                    da5.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
                    da5.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);


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
                        string selroute = xroute1;
                        string jdate = xdate2;
                        string jcoach = xcoach2;
                        string xseatid = xseat2;
                        string xstatus678 = @"'sold','mansale','manticapppen','cancelpending'";
                        string result = fnChkMultirouteSale(selroute, jcoach, jdate, xseatid, xstatus678);
                        //msg.InnerHtml = result;
                        if (result == "true")
                        {
                            //if (result == "booking")
                            //{
                            //    string xid1 = dtzt.Rows[0][1].ToString();



                            //    int res = ztsales.fnAutoCancelBooking(xid1, xseat2, xdate1.ToString(), xcoach1, xroute1000);

                            //    if (res == 1)
                            //    {
                            //        result = "btn";
                            //    }
                            //}

                            return "Please reload the coach before sale ticket. Your time period has expired.";
                        }
                    }
                    ////////////////////
                    else
                    {
                        SqlConnection conn2;
                        conn2 = new SqlConnection(zglobal.constring);
                        DataSet dts2 = new DataSet();
                        dts2.Reset();

                        //string str2 = "SELECT * FROM ztsaled WHERE xcoach=@xcoach AND xdate=@xdate AND xseatid=@xseat AND xroute=@xroute AND xstatus IN ('sold','mansale','manticapppen','cancelpending')";
                        string str2 = "select xseat from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','mansale','manticapppen','cancelpending') and xroute=@xroute";

                        SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                        da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                        da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                        da2.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                        da2.Fill(dts2, "temp");
                        DataTable dtztemp = new DataTable();
                        dtztemp = dts2.Tables["temp"];

                        if (dtztemp.Rows.Count > 0)
                        {

                            string[] xseat9 = xseat2.Split(',');
                            for (int i = 0; i < xseat9.Length; i++)
                            {
                                for (int j = 0; j < dtztemp.Rows.Count; j++)
                                {
                                    if (xseat9[i] == dtztemp.Rows[j][0].ToString())
                                    {
                                        //zttestbus bus = new zttestbus();

                                        //bus.fnBusLoad();

                                        return "Please reload the coach before sale ticket. Your time period has expired.";
                                    }
                                }
                            }
                        }
                    }
                }


                using (TransactionScope tran = new TransactionScope())
                {


                    /////////  delete from ztsaled when forsale seat on precessing  ////////////////////


                    if (xforsale != "null")
                    {


                        string[] xseat99 = xforsale.Split(',');
                        string xid11 = "";
                        string str222 = "";
                        //ArrayList arr = new ArrayList();


                        for (int i = 0; i < xseat99.Length; i++)
                        {
                            SqlConnection conn222;
                            conn222 = new SqlConnection(zglobal.constring);
                            DataSet dts222 = new DataSet();
                            dts222.Reset();

                            str222 = "select xid,xrow from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus='forsale'";
                            SqlDataAdapter da222 = new SqlDataAdapter(str222, conn222);

                            da222.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                            da222.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                            da222.SelectCommand.Parameters.AddWithValue("@xseat", xseat99[i]);
                            da222.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                            da222.Fill(dts222, "temp");
                            DataTable dtztemp = new DataTable();
                            dtztemp = dts222.Tables["temp"];

                            xid11 = dtztemp.Rows[0][0].ToString();
                            string xrowd = dtztemp.Rows[0][1].ToString();

                            /* delete data from ztsaled */

                            str222 = "UPDATE ztsaled SET xstatus='forsalesold' " +
                                             "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xseat=@xseat and xroute=@xroute and xstatus='forsale'";

                            SqlCommand cmd222 = new SqlCommand();

                            cmd222.Connection = conn222;
                            cmd222.CommandText = str222;

                            cmd222.Parameters.AddWithValue("@xid", xid11);
                            cmd222.Parameters.AddWithValue("@xdate", xdate2);
                            cmd222.Parameters.AddWithValue("@xcoach", xcoach2);
                            cmd222.Parameters.AddWithValue("@xseat", xseat99[i]);
                            cmd222.Parameters.AddWithValue("@xroute", xroute1);

                            conn222.Close();
                            conn222.Open();
                            cmd222.ExecuteNonQuery();
                            conn222.Close();



                            str222 = "INSERT INTO ztcancelreq" +
                                "(xrow,xid,xdate,xtime,xcoach,xseat,xremark,xreqdt,xreqby,xreqloc,xapprovedt,xapproveby,xapproveloc,xstatus,xroute,xrowd) " +
                                "VALUES (@xrow,@xid,@xdate,@xtime,@xcoach,@xseat,@xremark,@xreqdt,@xreqby,@xreqloc,@xapprovedt,@xapproveby,@xapproveloc,@xstatus,@xroute,@xrowd) ";


                            string xrow4;
                            string xdate4 = xdate2;
                            string xtime4 = "12:00 am";
                            string xcoach4 = xcoach2;
                            string xremark4 = "forsalesold";
                            string xstatus4 = "approved";
                            string xreqdt = Convert.ToString(DateTime.Now);
                            string xreqby = xreqby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            string xreqloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                            string xapprovedt = Convert.ToString(DateTime.Now);
                            string xapproveby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            string xapproveloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);



                            cmd222.CommandText = str222;



                            xrow4 = ztsales.fnmaxid(xdate2);






                            cmd222.Parameters.Clear();

                            cmd222.Parameters.AddWithValue("@xrow", xrow4);
                            cmd222.Parameters.AddWithValue("@xid", xid11);
                            cmd222.Parameters.AddWithValue("@xrowd", xrowd);
                            cmd222.Parameters.AddWithValue("@xdate", xdate4);
                            cmd222.Parameters.AddWithValue("@xtime", xtime4);
                            cmd222.Parameters.AddWithValue("@xcoach", xcoach4);
                            cmd222.Parameters.AddWithValue("@xremark", xremark4);
                            cmd222.Parameters.AddWithValue("@xreqdt", xreqdt);
                            cmd222.Parameters.AddWithValue("@xreqby", xreqby);
                            cmd222.Parameters.AddWithValue("@xreqloc", xreqloc);

                            cmd222.Parameters.AddWithValue("@xapprovedt", xapprovedt);
                            cmd222.Parameters.AddWithValue("@xapproveby", xapproveby);
                            cmd222.Parameters.AddWithValue("@xapproveloc", xapproveloc);
                            cmd222.Parameters.AddWithValue("@xstatus", xstatus4);
                            cmd222.Parameters.AddWithValue("@xseat", xseat99[i]);
                            cmd222.Parameters.AddWithValue("@xroute", xroute1);




                            conn222.Close();
                            conn222.Open();
                            cmd222.ExecuteNonQuery();
                            conn222.Close();


                            ////get the value of seat no from ztsaleh and subtruct it from cxseat

                            //SqlConnection conn123;
                            //conn123 = new SqlConnection(zglobal.constring);
                            //DataSet dts123 = new DataSet();
                            //dts123.Reset();

                            //string str123 = "select xseat,xrate from ztsaleh where xid=@xid";
                            //SqlDataAdapter da123 = new SqlDataAdapter(str123, conn123);

                            ////da2.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
                            ////da2.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
                            //da123.SelectCommand.Parameters.AddWithValue("@xid", xid11);

                            //da123.Fill(dts123, "temp");
                            //DataTable dtztemp123 = new DataTable();
                            //dtztemp123 = dts123.Tables["temp"];

                            //int xseat0 = Convert.ToInt32(dtztemp123.Rows[0][0].ToString()) - 1;
                            //double xamount0 = Convert.ToDouble(dtztemp123.Rows[0][1].ToString()) * xseat0;
                            //string xseat10 = Convert.ToString(xseat0);
                            //string xamount10 = Convert.ToString(xamount0);

                            //string query123 = "UPDATE ztsaleh SET " +
                            //                 "xseat=@xseat, xamount=@xamount " +
                            //                 "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach";


                            //SqlCommand dataCmd123 = new SqlCommand();
                            //dataCmd123.Connection = conn123;

                            //dataCmd123.CommandText = query123;




                            ////dataCmd123.Parameters.Clear();

                            //dataCmd123.Parameters.AddWithValue("@xid", xid11);
                            //dataCmd123.Parameters.AddWithValue("@xdate", xdate2);
                            //dataCmd123.Parameters.AddWithValue("@xcoach", xcoach2);
                            //dataCmd123.Parameters.AddWithValue("@xseat", xseat10);
                            //dataCmd123.Parameters.AddWithValue("@xamount", xamount10);



                            //conn123.Close();
                            //conn123.Open();

                            //dataCmd123.ExecuteNonQuery();


                            //conn123.Close();


                        }





                    }


                    ////////////////////////////////////////////////////////////////////////////////////



                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    //if (chkst2 == "booked" || chkst2 == "confbooked")
                    //{
                    //    query = "UPDATE ztsaleh SET " +
                    //            " xname=@xname, xphone=@xphone, xvotid=@xvotid, xboarding=@xboarding, xticket=@xticket, xsoldby=@xsoldby, xsoldloc=@xsoldloc, xentrytype=@xentrytype " +
                    //            " WHERE xid=@xid ";
                    //}
                    //else
                    //{
                    query = "INSERT INTO ztsaleh" +
                                      "(xid,xdate,xcoach,xname,xphone,xvotid,xboarding,xseat,xrate,xamount,xdateexp,xtimeexp,xcur,xexchange,xcreatedby,xcreatedt,xlocation,xbookingno,xticket,xentrytype,xsoldby,xsoldloc,xdiscount) " +
                                      "VALUES (@xid,@xdate,@xcoach,@xname,@xphone,@xvotid,@xboarding,@xseat,@xrate,@xamount,@xdateexp,@xtimeexp,@xcur,@xexchange,@xcreatedby,@xcreatedt,@xlocation,@xbookingno,@xticket,@xentrytype,@xsoldby,@xsoldloc,@xdiscount) ";
                    //}

                    dataCmd.CommandText = query;



                    //string xid1 = zttestbus.fnmaxrow("select max(xid) from ztsaleh");
                    string xid1;

                    //////////Code for query xid when  chkst=booked,forsale, confbooked//////////////
                    //if (chkst2 == "booked" || chkst2 == "forsale" || chkst2 == "confbooked")
                    if (chkst2 == "forsale")
                    {
                        string[] xseat9 = xseat2.Split(',');

                        xid1 = "";

                        SqlConnection conn2;
                        conn2 = new SqlConnection(zglobal.constring);
                        DataSet dts2 = new DataSet();
                        dts2.Reset();

                        //string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                        string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('sold','mansale')";
                        SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                        da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                        da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                        da2.SelectCommand.Parameters.AddWithValue("@xseat", xseat9[0]);
                        da2.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                        da2.Fill(dts2, "temp");
                        DataTable dtztemp = new DataTable();
                        dtztemp = dts2.Tables["temp"];

                        xid1 = dtztemp.Rows[0][0].ToString();
                        HttpContext.Current.Session["ticket"] = xid1;
                    }
                    else
                    {
                        xid1 = zttestbus.fnmaxidno("h", xdate2);
                        if (chkst2 == "sale" || chkst2 == "booked" || chkst2 == "confbooked")
                        {
                            HttpContext.Current.Session["ticket"] = xid1;
                        }
                    }

                    /////////////////////////////////////////////////////////////



                    string xdate1 = xdate2;
                    string xcoach1 = xcoach2;
                    string xname1 = xname2;
                    string xphone1 = xphone2;
                    string xvotid1 = xvotid2;
                    string xboarding1 = xboarding2;
                    string[] xseat1 = xseat2.Split(',');
                    string xseat19 = Convert.ToString(xseat1.Length);
                    string xrate1 = xrate2;
                    string xamount1 = xamount2;
                    string xdateexp1 = xdateexp2;
                    string xtimeexp1 = xtimeexp2;
                    string xcur1 = "BDT";
                    string xexchange1 = "1";
                    string xcreatedby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xcreatedt1 = Convert.ToString(DateTime.Now);
                    string xlocation1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    string xbookingno1;
                    string xticket1;
                    if (xstatus2 == "booking" || xstatus2 == "confbooking")
                    {
                        xbookingno1 = zttestbus.fnmaxidno("b", xdate2);
                        xticket1 = "";
                    }
                    else
                    {
                        if (xticket2 == "online")
                        {
                            xticket1 = zttestbus.fnmaxidno123("s", xdate2);
                        }
                        else
                        {
                            xticket1 = xticket2;
                        }


                        if (chkst2 == "booked" || chkst2 == "confbooked")
                        {
                            string[] xseat9999 = xseat2.Split(',');




                            SqlConnection conn22222 = new SqlConnection(zglobal.constring);
                            DataSet dts22222 = new DataSet();
                            dts22222.Reset();

                            //string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                            string str22222 = "select (select xbookingno from ztsaleh where xid=ztsaled.xid) as xbookingno from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking')";
                            SqlDataAdapter da22222 = new SqlDataAdapter(str22222, conn22222);

                            da22222.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                            da22222.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                            da22222.SelectCommand.Parameters.AddWithValue("@xseat", xseat9999[0]);
                            da22222.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                            da22222.Fill(dts22222, "temp");
                            DataTable dtztemp2222 = new DataTable();
                            dtztemp2222 = dts22222.Tables["temp"];

                            xbookingno1 = dtztemp2222.Rows[0][0].ToString();

                        }
                        else
                        {
                            xbookingno1 = "";
                        }
                    }

                    string xentrytype1;

                    if (xstatus2 == "manticapppen")
                    {
                        xentrytype1 = "manual";
                    }
                    else
                    {
                        xentrytype1 = "online";
                    }

                    string xsoldby1;
                    string xsoldloc1;
                    if (xstatus2 == "booking" || xstatus2 == "confbooking")
                    {
                        xsoldby1 = "";
                        xsoldloc1 = "";
                    }
                    else
                    {
                        xsoldby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        xsoldloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                    }

                    dataCmd.Parameters.AddWithValue("@xid", xid1);
                    dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                    dataCmd.Parameters.AddWithValue("@xname", xname1);
                    dataCmd.Parameters.AddWithValue("@xphone", xphone1);
                    dataCmd.Parameters.AddWithValue("@xvotid", xvotid1);
                    dataCmd.Parameters.AddWithValue("@xboarding", xboarding1);
                    dataCmd.Parameters.AddWithValue("@xseat", xseat19);
                    dataCmd.Parameters.AddWithValue("@xrate", xrate1);
                    dataCmd.Parameters.AddWithValue("@xamount", xamount1);
                    dataCmd.Parameters.AddWithValue("@xdateexp", xdateexp1);
                    dataCmd.Parameters.AddWithValue("@xtimeexp", xtimeexp1);
                    dataCmd.Parameters.AddWithValue("@xcur", xcur1);
                    dataCmd.Parameters.AddWithValue("@xexchange", xexchange1);
                    dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby1);
                    dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt1);
                    dataCmd.Parameters.AddWithValue("@xlocation", xlocation1);
                    dataCmd.Parameters.AddWithValue("@xbookingno", xbookingno1);
                    dataCmd.Parameters.AddWithValue("@xticket", xticket1);
                    dataCmd.Parameters.AddWithValue("@xentrytype", xentrytype1);
                    dataCmd.Parameters.AddWithValue("@xsoldby", xsoldby1);
                    dataCmd.Parameters.AddWithValue("@xsoldloc", xsoldloc1);
                    dataCmd.Parameters.AddWithValue("@xdiscount", xdiscount);

                    conn1.Close();
                    conn1.Open();
                    //SqlTransaction transec = conn1.BeginTransaction();
                    //dataCmd.Transaction = transec;

                    try
                    {

                        /*  insert ztsaleh table  */
                        if (chkst2 != "forsale")
                        {
                            dataCmd.ExecuteNonQuery();
                        }


                        /*  code for insert into ztsaled table  */
                        string xid123456 = "";
                        if (chkst2 == "booked" || chkst2 == "confbooked")
                        {
                            string[] xseat999 = xseat2.Split(',');




                            SqlConnection conn2222 = new SqlConnection(zglobal.constring);
                            DataSet dts2222 = new DataSet();
                            dts2222.Reset();

                            //string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                            string str2222 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking')";
                            SqlDataAdapter da2222 = new SqlDataAdapter(str2222, conn2222);

                            da2222.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                            da2222.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                            da2222.SelectCommand.Parameters.AddWithValue("@xseat", xseat999[0]);
                            da2222.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                            da2222.Fill(dts2222, "temp");
                            DataTable dtztemp222 = new DataTable();
                            dtztemp222 = dts2222.Tables["temp"];

                            xid123456 = dtztemp222.Rows[0][0].ToString();

                            query = "UPDATE ztsaled SET " +
                                    " xid=@xid, xstatus=@xstatus, xsolddt=@xsolddt, xrate=@xrate, xuser=@xuser, xloc=@xloc, xrttime=@xrttime, xroute=@xroute, xoptdate=@xoptdate,xdiscount=@xdiscount " +
                                    " WHERE xid=@xid123456 AND xseat=@xseat and xstatus in ('booking','confbooking')";
                        }
                        else if (chkst2 == "forsale")
                        {
                            //query = "UPDATE ztsaled SET " +
                            //            " xstatus=@xstatus, xrate=@xrate, xuser=@xuser, xloc=@xloc, xrttime=@xrttime, xroute=@xroute, xoptdate=@xoptdate,xdiscount=@xdiscount " +
                            //            " WHERE xid=@xid  AND xseat=@xseat and xstatus in ('sold','mansale')";
                            query = "UPDATE ztsaled SET " +
                                        " xstatus=@xstatus " +
                                        " WHERE xid=@xid  AND xseat=@xseat and xstatus in ('sold','mansale')";
                        }
                        else
                        {
                            query = "INSERT INTO ztsaled " +
                                         "(xrow,xid,xdate,xcoach,xseat,xstatus,xsolddt,xseatid,xrate,xuser,xloc,xrttime,xroute,xoptdate,xdiscount) " +
                                         "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xstatus,@xsolddt,@xseatid,@xrate,@xuser,@xloc,@xrttime,@xroute,@xoptdate,@xdiscount) ";
                        }



                        string[] xseat3;
                        string[] xseatid3 = xseatid2.Split(',');
                        //string[] dataCmd1;
                        string xrow1;
                        string xstatus1;

                        //if (chkst2 == "forsale")
                        //{
                        //    xstatus1 = "forsale";
                        //}
                        //else
                        //{
                        xstatus1 = xstatus2;
                        //}


                        string xsolddt1;
                        if (xstatus2 == "booking" || xstatus2 == "confbooking")
                        {
                            xsolddt1 = "01/01/1900 00:00:00";
                        }
                        else
                        {
                            xsolddt1 = Convert.ToString(DateTime.Now);
                        }

                        string xoptdate1 = Convert.ToString(DateTime.Now);

                        xseat3 = xseat1;

                        //////////get the route id from ztroute view////////////////

                        //DataSet dts123 = new DataSet();
                        //dts123.Reset();
                        //string str123 = "select srt from ztroute where mrt = (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and route=@route";
                        //SqlDataAdapter da123 = new SqlDataAdapter(str123, conn1);

                        //da123.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
                        //da123.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                        //da123.SelectCommand.Parameters.AddWithValue("@route", xroute2);

                        //dts123.Reset();
                        //da123.Fill(dts123, "temp1");
                        //DataTable dttemp123 = new DataTable();
                        //dttemp123 = dts123.Tables[0];

                        //string xroute1 = dttemp123.Rows[0][0].ToString();

                        //////////////////////////////////////////////////////////////


                        SqlCommand dataCmd1 = new SqlCommand();
                        dataCmd1.Connection = conn1;
                        dataCmd1.CommandText = query;
                        // dataCmd1.Transaction = transec;

                        for (int i = 0; i < xseat3.Length; i++)
                        {


                            //SqlCommand dataCmd1 = new SqlCommand();
                            //dataCmd1.Connection = conn1;
                            dataCmd1.CommandText = query;
                            ////dataCmd1.Transaction = transec;

                            //xrow1 = zttestbus.fnmaxrow("select max(xrow) from ztsaled");
                            xrow1 = zttestbus.fnmaxidno("d", xdate2);

                            dataCmd1.Parameters.Clear();
                            dataCmd1.Parameters.AddWithValue("@xrow", xrow1);
                            dataCmd1.Parameters.AddWithValue("@xid", xid1);
                            dataCmd1.Parameters.AddWithValue("@xdate", xdate1);
                            dataCmd1.Parameters.AddWithValue("@xcoach", xcoach1);
                            dataCmd1.Parameters.AddWithValue("@xseat", xseat3[i]);
                            dataCmd1.Parameters.AddWithValue("@xstatus", xstatus1);
                            dataCmd1.Parameters.AddWithValue("@xsolddt", xsolddt1);
                            if (chkst2 != "booked" && chkst2 != "forsale" && chkst2 != "confbooked")
                            {
                                dataCmd1.Parameters.AddWithValue("@xseatid", xseatid3[i]);
                            }
                            dataCmd1.Parameters.AddWithValue("@xrate", xrate2);
                            dataCmd1.Parameters.AddWithValue("@xuser", xcreatedby1);
                            dataCmd1.Parameters.AddWithValue("@xloc", xlocation1);
                            dataCmd1.Parameters.AddWithValue("@xrttime", xrttime2);
                            dataCmd1.Parameters.AddWithValue("@xoptdate", xoptdate1);
                            dataCmd1.Parameters.AddWithValue("@xroute", xroute1);
                            dataCmd1.Parameters.AddWithValue("@xdiscount", xdiscount);
                            if (chkst2 == "booked" || chkst2 == "confbooked")
                            {
                                dataCmd1.Parameters.AddWithValue("@xid123456", xid123456);
                            }



                            dataCmd1.ExecuteNonQuery();

                            //dataCmd1.Dispose();
                        }


                        /* insert data into ztlog  */

                        query = "INSERT INTO ztlogs" +
                                     "(xrow,xid,xdate,xcoach,xseat,xdatetime,xform,xbutton,xstatus,xuser,xlocation,xname,xphone,xvotid,xboarding,xrate,xroute,xdiscount) " +
                                     "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xdatetime,@xform,@xbutton,@xstatus,@xuser,@xlocation,@xname,@xphone,@xvotid,@xboarding,@xrate,@xroute,@xdiscount) ";




                        string xrow3;
                        string xid3 = xid1;
                        string xdate3 = xdate1;
                        string xcoach3 = xcoach1;
                        string[] xseat4 = xseat3;
                        string xdatetime3 = Convert.ToString(DateTime.Now);

                        string xform3;
                        if (xstatus2 == "booking")
                        {
                            xform3 = "booking";
                        }
                        else if (xstatus2 == "manticapppen")
                        {
                            xform3 = "mansale";
                        }
                        else
                        {
                            xform3 = "sale";
                        }
                        string xbutton3 = xbutton2;

                        string xstatus3 = xstatus1;
                        //if (xstatus2 == "booking")
                        //{
                        //    xstatus3 = "booking";
                        //}
                        //else
                        //{
                        //    xstatus3 = "sold";
                        //}

                        string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);


                        SqlCommand dataCmd2 = new SqlCommand();
                        dataCmd2.Connection = conn1;
                        dataCmd2.CommandText = query;
                        // dataCmd1.Transaction = transec;

                        for (int i = 0; i < xseat4.Length; i++)
                        {



                            dataCmd2.CommandText = query;


                            //xrow3 = zttestbus.fnmaxrow("select max(xrow) from ztlogs");
                            xrow3 = zttestbus.fnmaxidforlog(xdate2);

                            dataCmd2.Parameters.Clear();
                            dataCmd2.Parameters.AddWithValue("@xrow", xrow3);
                            dataCmd2.Parameters.AddWithValue("@xid", xid3);
                            dataCmd2.Parameters.AddWithValue("@xdate", xdate3);
                            dataCmd2.Parameters.AddWithValue("@xcoach", xcoach3);
                            dataCmd2.Parameters.AddWithValue("@xseat", xseat4[i]);
                            dataCmd2.Parameters.AddWithValue("@xdatetime", xdatetime3);
                            dataCmd2.Parameters.AddWithValue("@xform", xform3);
                            dataCmd2.Parameters.AddWithValue("@xbutton", xbutton3);
                            dataCmd2.Parameters.AddWithValue("@xstatus", xstatus3);
                            dataCmd2.Parameters.AddWithValue("@xuser", xuser3);
                            dataCmd2.Parameters.AddWithValue("@xlocation", xlocation3);
                            dataCmd2.Parameters.AddWithValue("@xname", xname1);
                            dataCmd2.Parameters.AddWithValue("@xphone", xphone1);
                            dataCmd2.Parameters.AddWithValue("@xvotid", xvotid1);
                            dataCmd2.Parameters.AddWithValue("@xboarding", xboarding1);
                            dataCmd2.Parameters.AddWithValue("@xrate", xrate1);
                            dataCmd2.Parameters.AddWithValue("@xroute", xroute1);
                            dataCmd2.Parameters.AddWithValue("@xdiscount", xdiscount);


                            dataCmd2.ExecuteNonQuery();

                            //dataCmd1.Dispose();
                        }

                      

                        if (xstatus2 == "manticapppen")
                        {
                            query = "INSERT INTO ztmanticapppen" +
                                         "(xrow,xid,xdate,xtime,xcoach,xseat,xreqdt,xreqby,xreqloc,xstatus,xroute) " +
                                         "VALUES (@xrow,@xid,@xdate,@xtime,@xcoach,@xseat,@xreqdt,@xreqby,@xreqloc,@xstatus,@xroute) ";


                            string xrow5 = zglobal.fnmaxidlong("SELECT max(xrow) FROM ztmanticapppen where xreqdt between @firstdate and @lastdate");
                            //return xrow5;
                            string xid5 = xid1;
                            string xdate5 = xdate1;
                            string xtime5 = xrttime2;
                            string xcoach5 = xcoach1;
                            string xseat5 = xseat2;
                            DateTime xreqdt5 = DateTime.Now;
                            string xreqby5 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            string xreqloc5 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                            string xstatus5 = "pending";
                            string xroute5 = xroute1;

                            SqlCommand dataCmd5 = new SqlCommand();
                            dataCmd5.Connection = conn1;
                            dataCmd5.CommandText = query;

                            dataCmd5.Parameters.Clear();
                            dataCmd5.Parameters.AddWithValue("@xrow", xrow5);
                            dataCmd5.Parameters.AddWithValue("@xid", xid5);
                            dataCmd5.Parameters.AddWithValue("@xdate", xdate5);
                            dataCmd5.Parameters.AddWithValue("@xtime", xtime5);
                            dataCmd5.Parameters.AddWithValue("@xcoach", xcoach5);
                            dataCmd5.Parameters.AddWithValue("@xseat", xseat5);
                            dataCmd5.Parameters.AddWithValue("@xreqdt", xreqdt5);
                            dataCmd5.Parameters.AddWithValue("@xreqloc", xreqloc5);
                            dataCmd5.Parameters.AddWithValue("@xreqby", xreqby5);
                            dataCmd5.Parameters.AddWithValue("@xstatus", xstatus5);
                            dataCmd5.Parameters.AddWithValue("@xroute", xroute5);


                            dataCmd5.ExecuteNonQuery();

                        }

                        if (Convert.ToString(HttpContext.Current.Session["isreturn"]) == "y")
                        {
                            string chkst132 = chkst2;
                            string xstatus132 = "sold";
                            string xdate132 = Convert.ToString(HttpContext.Current.Session["date"]);
                            string xcoach132 = Convert.ToString(HttpContext.Current.Session["coach"]);
                            string xname132 = Convert.ToString(HttpContext.Current.Session["name"]);
                            string xphone132 = Convert.ToString(HttpContext.Current.Session["phone"]);
                            string xvotid132 = Convert.ToString(HttpContext.Current.Session["votid"]); ;
                            string xboarding132 = Convert.ToString(HttpContext.Current.Session["boarding"]);
                            string xseat132 = Convert.ToString(HttpContext.Current.Session["seat"]);
                            string xrate132 = Convert.ToString(HttpContext.Current.Session["rate"]);
                            string xamount132 = Convert.ToString(HttpContext.Current.Session["amount"]);
                            string xdateexp132 = xdateexp2;
                            string xtimeexp132 = xtimeexp2;
                            string xbutton132 = "return-sale";
                            string xseatid132 = Convert.ToString( HttpContext.Current.Session["seatid"]);
                            string xforsale132 = "null";
                            string xrttime132 = Convert.ToString(HttpContext.Current.Session["time"]);
                            string xroute132 = Convert.ToString(HttpContext.Current.Session["route"]);
                            string xticket132 = zttestbus.fnmaxidno123("s", xdate2);
                            string xref123 = xticket1;

                            string xdiscount132 = Convert.ToString(HttpContext.Current.Session["discount"]);
                            string returnsale = fnSaleReturn( chkst132,  xstatus132,  xdate132, xcoach132,  xname132,  xphone132,  xvotid132, xboarding132, xseat132, xrate132, xamount132, xdateexp132, xtimeexp132, xbutton132, xseatid132, xforsale132, xrttime132, xroute132, xticket132, xdiscount132, xref123);


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
                            HttpContext.Current.Session["print"] = "y";

                        }


                        //transec.Commit();


                        conn1.Close();

                        fnDelectSelBtn(xdate3, xcoach3, xroute1);

                        tran.Complete();

                        // bus.fnBusLoad();

                    }
                    catch (Exception exp)
                    {

                        //transec.Rollback();
                        conn1.Close();

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


                        return exp.Message;
                    }

                    dataCmd.Dispose();
                    conn1.Dispose();
                }
            }
            catch (Exception exp)
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


                return exp.Message;
            }

            return "success";

        }

        public static string fnSaleReturn(string chkst2, string xstatus2, string xdate2, string xcoach2, string xname2, string xphone2, string xvotid2, string xboarding2, string xseat2, string xrate2, string xamount2, string xdateexp2, string xtimeexp2, string xbutton2, string xseatid2, string xforsale, string xrttime2, string xroute2, string xticket2, string xdiscount, string xref)
        {
            ////////get the route id from ztroute view////////////////
            SqlConnection conn12345678;
            conn12345678 = new SqlConnection(zglobal.constring);
            DataSet dts123 = new DataSet();
            dts123.Reset();
            string str123 = "select srt from ztroute where mrt = (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and route=@route";
            SqlDataAdapter da123 = new SqlDataAdapter(str123, conn12345678);

            da123.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
            da123.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da123.SelectCommand.Parameters.AddWithValue("@route", xroute2);

            dts123.Reset();
            da123.Fill(dts123, "temp1");
            DataTable dttemp123 = new DataTable();
            dttemp123 = dts123.Tables[0];

            string xroute1 = dttemp123.Rows[0][0].ToString();

            ////////////////////////////////////////////////////////////

            /*  check if seat already sale*/
            if (chkst2 == "sale" || chkst2 == "mansale")
            {


                /* Check sequence */
                SqlConnection conn1234;
                conn1234 = new SqlConnection(zglobal.constring);
                DataSet dts1234 = new DataSet();

                int hassub = 0;

                string str5 = "select xhsub from ztrtm where xmrid= (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and zactive=1";

                SqlDataAdapter da5 = new SqlDataAdapter(str5, conn1234);


                da5.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
                da5.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);


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
                    string selroute = xroute1;
                    string jdate = xdate2;
                    string jcoach = xcoach2;
                    string xseatid = xseat2;
                    string xstatus678 = @"'sold','mansale','confbooking','booking','manticapppen','cancelpending'";
                    string result = fnChkMultirouteSale(selroute, jcoach, jdate, xseatid, xstatus678);


                    //msg.InnerHtml = result;
                    if (result == "true")
                    {
                        //if (result == "booking")
                        //{
                        //    string xid1 = dtzt.Rows[0][1].ToString();



                        //    int res = ztsales.fnAutoCancelBooking(xid1, xseat2, xdate1.ToString(), xcoach1, xroute1000);

                        //    if (res == 1)
                        //    {
                        //        result = "btn";
                        //    }
                        //}

                        return "Please reload the coach before sale ticket. Your time period has expired.";
                    }
                }
                ////////////////////

                else
                {
                    SqlConnection conn2;
                    conn2 = new SqlConnection(zglobal.constring);
                    DataSet dts2 = new DataSet();
                    dts2.Reset();

                    //string str2 = "SELECT * FROM ztsaled WHERE xcoach=@xcoach AND xdate=@xdate AND xseatid=@xseat AND xroute=@xroute AND xstatus IN ('sold','mansale','confbooking','booking','manticapppen','cancelpending')";
                    string str2 = "select xseat from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','mansale','confbooking','booking','manticapppen','cancelpending') and xroute=@xroute";

                    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                    da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                    da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                    da2.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                    da2.Fill(dts2, "temp");
                    DataTable dtztemp = new DataTable();
                    dtztemp = dts2.Tables["temp"];

                    if (dtztemp.Rows.Count > 0)
                    {

                        string[] xseat9 = xseat2.Split(',');
                        for (int i = 0; i < xseat9.Length; i++)
                        {
                            for (int j = 0; j < dtztemp.Rows.Count; j++)
                            {
                                if (xseat9[i] == dtztemp.Rows[j][0].ToString())
                                {
                                    //zttestbus bus = new zttestbus();

                                    //bus.fnBusLoad();

                                    return "Please reload the coach before sale ticket. Your time period has expired.";
                                }
                            }
                        }
                    }
                }
            }

            /////////  delete from ztsaled when forsale seat on precessing  ////////////////////


            if (xforsale != "null")
            {


                string[] xseat99 = xforsale.Split(',');
                string xid11 = "";
                string str222 = "";
                //ArrayList arr = new ArrayList();


                for (int i = 0; i < xseat99.Length; i++)
                {
                    SqlConnection conn222;
                    conn222 = new SqlConnection(zglobal.constring);
                    DataSet dts222 = new DataSet();
                    dts222.Reset();

                    str222 = "select xid,xrow from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus='forsale'";
                    SqlDataAdapter da222 = new SqlDataAdapter(str222, conn222);

                    da222.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                    da222.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                    da222.SelectCommand.Parameters.AddWithValue("@xseat", xseat99[i]);
                    da222.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                    da222.Fill(dts222, "temp");
                    DataTable dtztemp = new DataTable();
                    dtztemp = dts222.Tables["temp"];

                    xid11 = dtztemp.Rows[0][0].ToString();
                    string xrowd = dtztemp.Rows[0][1].ToString();

                    /* delete data from ztsaled */

                    str222 = "UPDATE ztsaled SET xstatus='forsalesold' " +
                                     "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xseat=@xseat and xroute=@xroute and xstatus='forsale'";

                    SqlCommand cmd222 = new SqlCommand();

                    cmd222.Connection = conn222;
                    cmd222.CommandText = str222;

                    cmd222.Parameters.AddWithValue("@xid", xid11);
                    cmd222.Parameters.AddWithValue("@xdate", xdate2);
                    cmd222.Parameters.AddWithValue("@xcoach", xcoach2);
                    cmd222.Parameters.AddWithValue("@xseat", xseat99[i]);
                    cmd222.Parameters.AddWithValue("@xroute", xroute1);

                    conn222.Close();
                    conn222.Open();
                    cmd222.ExecuteNonQuery();
                    conn222.Close();



                    str222 = "INSERT INTO ztcancelreq" +
                        "(xrow,xid,xdate,xtime,xcoach,xseat,xremark,xreqdt,xreqby,xreqloc,xapprovedt,xapproveby,xapproveloc,xstatus,xroute,xrowd) " +
                        "VALUES (@xrow,@xid,@xdate,@xtime,@xcoach,@xseat,@xremark,@xreqdt,@xreqby,@xreqloc,@xapprovedt,@xapproveby,@xapproveloc,@xstatus,@xroute,@xrowd) ";


                    string xrow4;
                    string xdate4 = xdate2;
                    string xtime4 = "12:00 am";
                    string xcoach4 = xcoach2;
                    string xremark4 = "forsalesold";
                    string xstatus4 = "approved";
                    string xreqdt = Convert.ToString(DateTime.Now);
                    string xreqby = xreqby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xreqloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                    string xapprovedt = Convert.ToString(DateTime.Now);
                    string xapproveby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xapproveloc = Convert.ToString(HttpContext.Current.Session["xlocation"]);



                    cmd222.CommandText = str222;



                    xrow4 = ztsales.fnmaxid(xdate2);






                    cmd222.Parameters.Clear();

                    cmd222.Parameters.AddWithValue("@xrow", xrow4);
                    cmd222.Parameters.AddWithValue("@xid", xid11);
                    cmd222.Parameters.AddWithValue("@xrowd", xrowd);
                    cmd222.Parameters.AddWithValue("@xdate", xdate4);
                    cmd222.Parameters.AddWithValue("@xtime", xtime4);
                    cmd222.Parameters.AddWithValue("@xcoach", xcoach4);
                    cmd222.Parameters.AddWithValue("@xremark", xremark4);
                    cmd222.Parameters.AddWithValue("@xreqdt", xreqdt);
                    cmd222.Parameters.AddWithValue("@xreqby", xreqby);
                    cmd222.Parameters.AddWithValue("@xreqloc", xreqloc);

                    cmd222.Parameters.AddWithValue("@xapprovedt", xapprovedt);
                    cmd222.Parameters.AddWithValue("@xapproveby", xapproveby);
                    cmd222.Parameters.AddWithValue("@xapproveloc", xapproveloc);
                    cmd222.Parameters.AddWithValue("@xstatus", xstatus4);
                    cmd222.Parameters.AddWithValue("@xseat", xseat99[i]);
                    cmd222.Parameters.AddWithValue("@xroute", xroute1);




                    conn222.Close();
                    conn222.Open();
                    cmd222.ExecuteNonQuery();
                    conn222.Close();


                    ////get the value of seat no from ztsaleh and subtruct it from cxseat

                    //SqlConnection conn123;
                    //conn123 = new SqlConnection(zglobal.constring);
                    //DataSet dts123 = new DataSet();
                    //dts123.Reset();

                    //string str123 = "select xseat,xrate from ztsaleh where xid=@xid";
                    //SqlDataAdapter da123 = new SqlDataAdapter(str123, conn123);

                    ////da2.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
                    ////da2.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
                    //da123.SelectCommand.Parameters.AddWithValue("@xid", xid11);

                    //da123.Fill(dts123, "temp");
                    //DataTable dtztemp123 = new DataTable();
                    //dtztemp123 = dts123.Tables["temp"];

                    //int xseat0 = Convert.ToInt32(dtztemp123.Rows[0][0].ToString()) - 1;
                    //double xamount0 = Convert.ToDouble(dtztemp123.Rows[0][1].ToString()) * xseat0;
                    //string xseat10 = Convert.ToString(xseat0);
                    //string xamount10 = Convert.ToString(xamount0);

                    //string query123 = "UPDATE ztsaleh SET " +
                    //                 "xseat=@xseat, xamount=@xamount " +
                    //                 "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach";


                    //SqlCommand dataCmd123 = new SqlCommand();
                    //dataCmd123.Connection = conn123;

                    //dataCmd123.CommandText = query123;




                    ////dataCmd123.Parameters.Clear();

                    //dataCmd123.Parameters.AddWithValue("@xid", xid11);
                    //dataCmd123.Parameters.AddWithValue("@xdate", xdate2);
                    //dataCmd123.Parameters.AddWithValue("@xcoach", xcoach2);
                    //dataCmd123.Parameters.AddWithValue("@xseat", xseat10);
                    //dataCmd123.Parameters.AddWithValue("@xamount", xamount10);



                    //conn123.Close();
                    //conn123.Open();

                    //dataCmd123.ExecuteNonQuery();


                    //conn123.Close();


                }





            }


            ////////////////////////////////////////////////////////////////////////////////////

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn1;
            string query;

            //if (chkst2 == "booked" || chkst2 == "confbooked")
            //{
            //    query = "UPDATE ztsaleh SET " +
            //            " xname=@xname, xphone=@xphone, xvotid=@xvotid, xboarding=@xboarding, xticket=@xticket, xsoldby=@xsoldby, xsoldloc=@xsoldloc, xentrytype=@xentrytype " +
            //            " WHERE xid=@xid ";
            //}
            //else
            //{
            query = "INSERT INTO ztsaleh" +
                              "(xid,xdate,xcoach,xname,xphone,xvotid,xboarding,xseat,xrate,xamount,xdateexp,xtimeexp,xcur,xexchange,xcreatedby,xcreatedt,xlocation,xbookingno,xticket,xentrytype,xsoldby,xsoldloc,xdiscount) " +
                              "VALUES (@xid,@xdate,@xcoach,@xname,@xphone,@xvotid,@xboarding,@xseat,@xrate,@xamount,@xdateexp,@xtimeexp,@xcur,@xexchange,@xcreatedby,@xcreatedt,@xlocation,@xbookingno,@xticket,@xentrytype,@xsoldby,@xsoldloc,@xdiscount) ";
            //}

            dataCmd.CommandText = query;



            //string xid1 = zttestbus.fnmaxrow("select max(xid) from ztsaleh");
            string xid1;

            //////////Code for query xid when  chkst=booked,forsale, confbooked//////////////
            //if (chkst2 == "booked" || chkst2 == "forsale" || chkst2 == "confbooked")
            if (chkst2 == "forsale")
            {
                string[] xseat9 = xseat2.Split(',');

                xid1 = "";

                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                //string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('sold','mansale')";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                da2.SelectCommand.Parameters.AddWithValue("@xseat", xseat9[0]);
                da2.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];

                xid1 = dtztemp.Rows[0][0].ToString();
                HttpContext.Current.Session["ticket123"] = xid1;
            }
            else
            {
                xid1 = zttestbus.fnmaxidno("h", xdate2);
                if (chkst2 == "sale" || chkst2 == "booked" || chkst2 == "confbooked")
                {
                    HttpContext.Current.Session["ticket123"] = xid1;
                }
            }

            /////////////////////////////////////////////////////////////



            string xdate1 = xdate2;
            string xcoach1 = xcoach2;
            string xname1 = xname2;
            string xphone1 = xphone2;
            string xvotid1 = xvotid2;
            string xboarding1 = xboarding2;
            string[] xseat1 = xseat2.Split(',');
            string xseat19 = Convert.ToString(xseat1.Length);
            string xrate1 = xrate2;
            string xamount1 = xamount2;
            string xdateexp1 = xdateexp2;
            string xtimeexp1 = xtimeexp2;
            string xcur1 = "BDT";
            string xexchange1 = "1";
            string xcreatedby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            string xcreatedt1 = Convert.ToString(DateTime.Now);
            string xlocation1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

            string xbookingno1;
            string xticket1;
            if (xstatus2 == "booking" || xstatus2 == "confbooking")
            {
                xbookingno1 = zttestbus.fnmaxidno("b", xdate2);
                xticket1 = "";
            }
            else
            {
                if (xticket2 == "online")
                {
                    xticket1 = zttestbus.fnmaxidno123("s", xdate2);
                }
                else
                {
                    xticket1 = xticket2;
                }


                if (chkst2 == "booked" || chkst2 == "confbooked")
                {
                    string[] xseat9999 = xseat2.Split(',');




                    SqlConnection conn22222 = new SqlConnection(zglobal.constring);
                    DataSet dts22222 = new DataSet();
                    dts22222.Reset();

                    //string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                    string str22222 = "select (select xbookingno from ztsaleh where xid=ztsaled.xid) as xbookingno from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking')";
                    SqlDataAdapter da22222 = new SqlDataAdapter(str22222, conn22222);

                    da22222.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                    da22222.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                    da22222.SelectCommand.Parameters.AddWithValue("@xseat", xseat9999[0]);
                    da22222.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                    da22222.Fill(dts22222, "temp");
                    DataTable dtztemp2222 = new DataTable();
                    dtztemp2222 = dts22222.Tables["temp"];

                    xbookingno1 = dtztemp2222.Rows[0][0].ToString();

                }
                else
                {
                    xbookingno1 = "";
                }
            }

            string xentrytype1;

            if (xstatus2 == "manticapppen")
            {
                xentrytype1 = "manual";
            }
            else
            {
                xentrytype1 = "online";
            }

            string xsoldby1;
            string xsoldloc1;
            if (xstatus2 == "booking" || xstatus2 == "confbooking")
            {
                xsoldby1 = "";
                xsoldloc1 = "";
            }
            else
            {
                xsoldby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                xsoldloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
            }

            dataCmd.Parameters.AddWithValue("@xid", xid1);
            dataCmd.Parameters.AddWithValue("@xdate", xdate1);
            dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
            dataCmd.Parameters.AddWithValue("@xname", xname1);
            dataCmd.Parameters.AddWithValue("@xphone", xphone1);
            dataCmd.Parameters.AddWithValue("@xvotid", xvotid1);
            dataCmd.Parameters.AddWithValue("@xboarding", xboarding1);
            dataCmd.Parameters.AddWithValue("@xseat", xseat19);
            dataCmd.Parameters.AddWithValue("@xrate", xrate1);
            dataCmd.Parameters.AddWithValue("@xamount", xamount1);
            dataCmd.Parameters.AddWithValue("@xdateexp", xdateexp1);
            dataCmd.Parameters.AddWithValue("@xtimeexp", xtimeexp1);
            dataCmd.Parameters.AddWithValue("@xcur", xcur1);
            dataCmd.Parameters.AddWithValue("@xexchange", xexchange1);
            dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby1);
            dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt1);
            dataCmd.Parameters.AddWithValue("@xlocation", xlocation1);
            dataCmd.Parameters.AddWithValue("@xbookingno", xbookingno1);
            dataCmd.Parameters.AddWithValue("@xticket", xticket1);
            dataCmd.Parameters.AddWithValue("@xentrytype", xentrytype1);
            dataCmd.Parameters.AddWithValue("@xsoldby", xsoldby1);
            dataCmd.Parameters.AddWithValue("@xsoldloc", xsoldloc1);
            dataCmd.Parameters.AddWithValue("@xdiscount", xdiscount);

            conn1.Close();
            conn1.Open();
            //SqlTransaction transec = conn1.BeginTransaction();
            //dataCmd.Transaction = transec;

            /*  insert ztsaleh table  */
            if (chkst2 != "forsale")
            {
                dataCmd.ExecuteNonQuery();
            }


            /*  code for insert into ztsaled table  */
            string xid123456 = "";
            if (chkst2 == "booked" || chkst2 == "confbooked")
            {
                string[] xseat999 = xseat2.Split(',');




                SqlConnection conn2222 = new SqlConnection(zglobal.constring);
                DataSet dts2222 = new DataSet();
                dts2222.Reset();

                //string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking','sold','mansale')";
                string str2222 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus in ('booking','confbooking')";
                SqlDataAdapter da2222 = new SqlDataAdapter(str2222, conn2222);

                da2222.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                da2222.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                da2222.SelectCommand.Parameters.AddWithValue("@xseat", xseat999[0]);
                da2222.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);

                da2222.Fill(dts2222, "temp");
                DataTable dtztemp222 = new DataTable();
                dtztemp222 = dts2222.Tables["temp"];

                xid123456 = dtztemp222.Rows[0][0].ToString();

                query = "UPDATE ztsaled SET " +
                        " xid=@xid, xstatus=@xstatus, xsolddt=@xsolddt, xrate=@xrate, xuser=@xuser, xloc=@xloc, xrttime=@xrttime, xroute=@xroute, xoptdate=@xoptdate,xdiscount=@xdiscount " +
                        " WHERE xid=@xid123456 AND xseat=@xseat and xstatus in ('booking','confbooking')";
            }
            else if (chkst2 == "forsale")
            {
                //query = "UPDATE ztsaled SET " +
                //            " xstatus=@xstatus, xrate=@xrate, xuser=@xuser, xloc=@xloc, xrttime=@xrttime, xroute=@xroute, xoptdate=@xoptdate,xdiscount=@xdiscount " +
                //            " WHERE xid=@xid  AND xseat=@xseat and xstatus in ('sold','mansale')";
                query = "UPDATE ztsaled SET " +
                            " xstatus=@xstatus " +
                            " WHERE xid=@xid  AND xseat=@xseat and xstatus in ('sold','mansale')";
            }
            else
            {
                query = "INSERT INTO ztsaled " +
                             "(xrow,xid,xdate,xcoach,xseat,xstatus,xsolddt,xseatid,xrate,xuser,xloc,xrttime,xroute,xoptdate,xdiscount,xref) " +
                             "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xstatus,@xsolddt,@xseatid,@xrate,@xuser,@xloc,@xrttime,@xroute,@xoptdate,@xdiscount,@xref) ";
            }



            string[] xseat3;
            string[] xseatid3 = xseatid2.Split(',');
            //string[] dataCmd1;
            string xrow1;
            string xstatus1;

            //if (chkst2 == "forsale")
            //{
            //    xstatus1 = "forsale";
            //}
            //else
            //{
            xstatus1 = xstatus2;
            //}


            string xsolddt1;
            if (xstatus2 == "booking" || xstatus2 == "confbooking")
            {
                xsolddt1 = "01/01/1900 00:00:00";
            }
            else
            {
                xsolddt1 = Convert.ToString(DateTime.Now);
            }

            string xoptdate1 = Convert.ToString(DateTime.Now);

            xseat3 = xseat1;

            //////////get the route id from ztroute view////////////////

            //DataSet dts123 = new DataSet();
            //dts123.Reset();
            //string str123 = "select srt from ztroute where mrt = (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno) and route=@route";
            //SqlDataAdapter da123 = new SqlDataAdapter(str123, conn1);

            //da123.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
            //da123.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            //da123.SelectCommand.Parameters.AddWithValue("@route", xroute2);

            //dts123.Reset();
            //da123.Fill(dts123, "temp1");
            //DataTable dttemp123 = new DataTable();
            //dttemp123 = dts123.Tables[0];

            //string xroute1 = dttemp123.Rows[0][0].ToString();

            //////////////////////////////////////////////////////////////


            SqlCommand dataCmd1 = new SqlCommand();
            dataCmd1.Connection = conn1;
            dataCmd1.CommandText = query;
            // dataCmd1.Transaction = transec;

            for (int i = 0; i < xseat3.Length; i++)
            {


                //SqlCommand dataCmd1 = new SqlCommand();
                //dataCmd1.Connection = conn1;
                dataCmd1.CommandText = query;
                ////dataCmd1.Transaction = transec;

                //xrow1 = zttestbus.fnmaxrow("select max(xrow) from ztsaled");
                xrow1 = zttestbus.fnmaxidno("d", xdate2);

                dataCmd1.Parameters.Clear();
                dataCmd1.Parameters.AddWithValue("@xrow", xrow1);
                dataCmd1.Parameters.AddWithValue("@xid", xid1);
                dataCmd1.Parameters.AddWithValue("@xdate", xdate1);
                dataCmd1.Parameters.AddWithValue("@xcoach", xcoach1);
                dataCmd1.Parameters.AddWithValue("@xseat", xseat3[i]);
                dataCmd1.Parameters.AddWithValue("@xstatus", xstatus1);
                dataCmd1.Parameters.AddWithValue("@xsolddt", xsolddt1);
                if (chkst2 != "booked" && chkst2 != "forsale" && chkst2 != "confbooked")
                {
                    dataCmd1.Parameters.AddWithValue("@xseatid", xseatid3[i]);
                }
                dataCmd1.Parameters.AddWithValue("@xrate", xrate2);
                dataCmd1.Parameters.AddWithValue("@xuser", xcreatedby1);
                dataCmd1.Parameters.AddWithValue("@xloc", xlocation1);
                dataCmd1.Parameters.AddWithValue("@xrttime", xrttime2);
                dataCmd1.Parameters.AddWithValue("@xoptdate", xoptdate1);
                dataCmd1.Parameters.AddWithValue("@xroute", xroute1);
                dataCmd1.Parameters.AddWithValue("@xdiscount", xdiscount);
                if (chkst2 == "booked" || chkst2 == "confbooked")
                {
                    dataCmd1.Parameters.AddWithValue("@xid123456", xid123456);
                }
                dataCmd1.Parameters.AddWithValue("@xref", xref);


                dataCmd1.ExecuteNonQuery();

                //dataCmd1.Dispose();
            }


            /* insert data into ztlog  */

            query = "INSERT INTO ztlogs" +
                         "(xrow,xid,xdate,xcoach,xseat,xdatetime,xform,xbutton,xstatus,xuser,xlocation,xname,xphone,xvotid,xboarding,xrate,xroute,xdiscount) " +
                         "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xdatetime,@xform,@xbutton,@xstatus,@xuser,@xlocation,@xname,@xphone,@xvotid,@xboarding,@xrate,@xroute,@xdiscount) ";




            string xrow3;
            string xid3 = xid1;
            string xdate3 = xdate1;
            string xcoach3 = xcoach1;
            string[] xseat4 = xseat3;
            string xdatetime3 = Convert.ToString(DateTime.Now);

            string xform3;
            if (xstatus2 == "booking")
            {
                xform3 = "booking";
            }
            else if (xstatus2 == "manticapppen")
            {
                xform3 = "mansale";
            }
            else
            {
                xform3 = "sale";
            }
            string xbutton3 = xbutton2;

            string xstatus3 = xstatus1;
            //if (xstatus2 == "booking")
            //{
            //    xstatus3 = "booking";
            //}
            //else
            //{
            //    xstatus3 = "sold";
            //}

            string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);


            SqlCommand dataCmd2 = new SqlCommand();
            dataCmd2.Connection = conn1;
            dataCmd2.CommandText = query;
            // dataCmd1.Transaction = transec;

            for (int i = 0; i < xseat4.Length; i++)
            {



                dataCmd2.CommandText = query;


                //xrow3 = zttestbus.fnmaxrow("select max(xrow) from ztlogs");
                xrow3 = zttestbus.fnmaxidforlog(xdate2);

                dataCmd2.Parameters.Clear();
                dataCmd2.Parameters.AddWithValue("@xrow", xrow3);
                dataCmd2.Parameters.AddWithValue("@xid", xid3);
                dataCmd2.Parameters.AddWithValue("@xdate", xdate3);
                dataCmd2.Parameters.AddWithValue("@xcoach", xcoach3);
                dataCmd2.Parameters.AddWithValue("@xseat", xseat4[i]);
                dataCmd2.Parameters.AddWithValue("@xdatetime", xdatetime3);
                dataCmd2.Parameters.AddWithValue("@xform", xform3);
                dataCmd2.Parameters.AddWithValue("@xbutton", xbutton3);
                dataCmd2.Parameters.AddWithValue("@xstatus", xstatus3);
                dataCmd2.Parameters.AddWithValue("@xuser", xuser3);
                dataCmd2.Parameters.AddWithValue("@xlocation", xlocation3);
                dataCmd2.Parameters.AddWithValue("@xname", xname1);
                dataCmd2.Parameters.AddWithValue("@xphone", xphone1);
                dataCmd2.Parameters.AddWithValue("@xvotid", xvotid1);
                dataCmd2.Parameters.AddWithValue("@xboarding", xboarding1);
                dataCmd2.Parameters.AddWithValue("@xrate", xrate1);
                dataCmd2.Parameters.AddWithValue("@xroute", xroute1);
                dataCmd2.Parameters.AddWithValue("@xdiscount", xdiscount);


                dataCmd2.ExecuteNonQuery();

                //dataCmd1.Dispose();
            }

            return "success";
        }


        [WebMethod(EnableSession = true)]
        public static string fnBookingCancel(string cxdate2, string cxcoach2, string cxseat2, string cxnoofseat2, string xrouteid)
        {
            try
            {


                /*  check if multiple passenger booking cancel at a time*/
                string[] xseat9 = cxseat2.Split(',');
                ArrayList arr = new ArrayList();

                string routeid;
                for (int i = 0; i < xseat9.Length; i++)
                {
                    SqlConnection conn2;
                    conn2 = new SqlConnection(zglobal.constring);
                    DataSet dts2 = new DataSet();
                    dts2.Reset();

                    string str2 = "select xid from ztsaled where xdate=@xdate and xcoach=@xcoach and xseat=@xseat and xroute=@xroute and xstatus='booking'";
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

                string xid1 = "";

                foreach (string xid123 in arr)
                {
                    foreach (string xid321 in arr)
                    {
                        if (xid123 != xid321)
                        {
                            return "Select only one passenger.";
                        }
                    }

                    xid1 = xid123;
                }





                using (TransactionScope tran = new TransactionScope())
                {

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;


                    /* insert data into ztlog  */

                    query = "INSERT INTO ztlogs" +
                                 "(xrow,xid,xdate,xcoach,xseat,xdatetime,xform,xbutton,xstatus,xuser,xlocation,xroute) " +
                                 "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xdatetime,@xform,@xbutton,@xstatus,@xuser,@xlocation,@xroute) ";




                    string xrow3;
                    string xdate3 = cxdate2;
                    string xcoach3 = cxcoach2;
                    string[] xseat4 = cxseat2.Split(',');
                    string xdatetime3 = Convert.ToString(DateTime.Now);
                    string xform3 = "booking";
                    string xbutton3 = "cancel";
                    string xstatus3 = "cancel";
                    string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    conn1.Close();
                    conn1.Open();

                    dataCmd.CommandText = query;
                    // dataCmd1.Transaction = transec;

                    for (int i = 0; i < xseat4.Length; i++)
                    {



                        dataCmd.CommandText = query;


                        //xrow3 = zttestbus.fnmaxrow("select max(xrow) from ztlogs");
                        xrow3 = zttestbus.fnmaxidforlog(xdate3);

                        dataCmd.Parameters.Clear();
                        dataCmd.Parameters.AddWithValue("@xrow", xrow3);
                        dataCmd.Parameters.AddWithValue("@xid", xid1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate3);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach3);
                        dataCmd.Parameters.AddWithValue("@xseat", xseat4[i]);
                        dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime3);
                        dataCmd.Parameters.AddWithValue("@xform", xform3);
                        dataCmd.Parameters.AddWithValue("@xbutton", xbutton3);
                        dataCmd.Parameters.AddWithValue("@xstatus", xstatus3);
                        dataCmd.Parameters.AddWithValue("@xuser", xuser3);
                        dataCmd.Parameters.AddWithValue("@xlocation", xlocation3);
                        dataCmd.Parameters.AddWithValue("@xroute", xrouteid);



                        dataCmd.ExecuteNonQuery();

                        //dataCmd1.Dispose();
                    }

                    /* delete data from ztsaled */

                    query = "UPDATE ztsaled SET xstatus='bookingcancel' " +
                                     "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach AND xseat=@xseat AND xroute=@xroute and xstatus = 'booking'";

                    //string xstatus5 = "cancel";
                    string xdate5 = cxdate2;
                    string xcoach5 = cxcoach2;
                    // string[] xseat5 = cxseat2.Split(',');


                    dataCmd.CommandText = query;


                    for (int i = 0; i < xseat4.Length; i++)
                    {



                        dataCmd.CommandText = query;




                        dataCmd.Parameters.Clear();

                        dataCmd.Parameters.AddWithValue("@xid", xid1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate5);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach5);
                        dataCmd.Parameters.AddWithValue("@xseat", xseat4[i]);
                        dataCmd.Parameters.AddWithValue("@xroute", xrouteid);




                        dataCmd.ExecuteNonQuery();

                    }

                    //get the value of seat no from ztsaleh and subtruct it from cxseat

                    //SqlConnection conn2;
                    //conn2 = new SqlConnection(zglobal.constring);
                    //DataSet dts2 = new DataSet();
                    //dts2.Reset();

                    //string str2 = "select xseat,xrate from ztsaleh where xid=@xid";
                    //SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                    ////da2.SelectCommand.Parameters.AddWithValue("@xdate", cxdate2);
                    ////da2.SelectCommand.Parameters.AddWithValue("@xcoach", cxcoach2);
                    //da2.SelectCommand.Parameters.AddWithValue("@xid", xid1);

                    //da2.Fill(dts2, "temp");
                    //DataTable dtztemp = new DataTable();
                    //dtztemp = dts2.Tables["temp"];

                    //int xseat0 = Convert.ToInt32(dtztemp.Rows[0][0].ToString()) - Convert.ToInt32(cxnoofseat2);
                    //double xamount0 = Convert.ToDouble(dtztemp.Rows[0][1].ToString()) * xseat0;
                    //string xseat10 = Convert.ToString(xseat0);
                    //string xamount10 = Convert.ToString(xamount0);

                    //query = "UPDATE ztsaleh SET " +
                    //                 "xseat=@xseat, xamount=@xamount " +
                    //                 "WHERE xid=@xid AND xdate=@xdate AND xcoach=@xcoach";




                    //dataCmd.CommandText = query;




                    //dataCmd.Parameters.Clear();

                    //dataCmd.Parameters.AddWithValue("@xid", xid1);
                    //dataCmd.Parameters.AddWithValue("@xdate", xdate5);
                    //dataCmd.Parameters.AddWithValue("@xcoach", xcoach5);
                    //dataCmd.Parameters.AddWithValue("@xseat", xseat10);
                    //dataCmd.Parameters.AddWithValue("@xamount", xamount10);





                    //dataCmd.ExecuteNonQuery();


                    conn1.Close();

                    // fnDelectSelBtn(xdate3, xcoach3);



                    tran.Complete();


                    dataCmd.Dispose();
                    conn1.Dispose();
                }

            }
            catch (Exception exp)
            {

                return exp.Message;
            }




            return "success";
        }


        [WebMethod(EnableSession = true)]
        public static string fnDelectSelBtn(string xdate2, string xcoach2, string xrouteid)
        {

            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "DELETE FROM ztcurseat WHERE xuser=@xuser AND xdate=@xdate AND xcoach=@xcoach";

                dataCmd.CommandText = query;

                string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xdate1 = xdate2;
                string xcoach1 = xcoach2;

                dataCmd.Parameters.AddWithValue("@xuser", xuser1);
                dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                //dataCmd.Parameters.AddWithValue("@xroute", xrouteid);


                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                dataCmd.Dispose();
                conn1.Dispose();

                return "success";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }


        }



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
                }



            }



            return Fare;
        }



        [WebMethod(EnableSession = true)]
        public static int process(string sid, string xdate2, string xcoach2, string xrouteid)
        {


            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();
            string str2;

            str2 = "SELECT * FROM ztsaled WHERE xcoach=@xcoach AND xdate=@xdate AND xseatid=@xseat AND xroute=@xroute AND xstatus IN ('sold','mansale','confbooking','booking','manticapppen','cancelpending')";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);





            da2.SelectCommand.Parameters.Clear();
            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
            da2.SelectCommand.Parameters.AddWithValue("@xseat", sid);
            da2.SelectCommand.Parameters.AddWithValue("@xroute", xrouteid);
            dts2.Reset();
            da2.Fill(dts2, "temp");
            DataTable ztmstk = new DataTable();
            ztmstk = dts2.Tables["temp"];
            if (ztmstk.Rows.Count > 0)
            {
                return 180;
            }

            /*** For Refresh the application state***/

            //List<seatprocess> checkappst;

            //if (HttpContext.Current.Application["curseat"] == null)
            //{
            //    checkappst = new List<seatprocess>();

            //}
            //else
            //{
            //    checkappst = (List<seatprocess>)HttpContext.Current.Application["curseat"];

            //    foreach (seatprocess st in checkappst)
            //    {
            //        //xtime.Text = xtime.Text + st.Seatid + " " + st.Userid + ", ";
            //    }

            //}









            //List<seatprocess> UserBtn = new List<seatprocess>();


            string uid = Convert.ToString(HttpContext.Current.Session["curuser"]);
            string xdate1 = xdate2;
            string xcoach1 = xcoach2;
            //string uid = zttestbus.userid;
            //seatprocess user = new seatprocess(sid,uid);

            string u = getuser(sid, xdate2, xcoach2, xrouteid);

            //return "u:" +u + " id: " + uid;
            if (u != "")
            {
                if (u != uid)
                {
                    return 1;
                }

                //removeseat(sid, uid, xdate1, xcoach1, xrouteid);
                //removeseat(user);
                return 0;




            }

            //addseat(user);

            addseat(sid, uid, xdate1, xcoach1, xrouteid);

            System.Timers.Timer timer = new System.Timers.Timer();


            timer.Elapsed += (sender, e) => OnElapsed(sender, e, sid, uid, xdate2, xcoach2, xrouteid);
            timer.Interval = 300000;
            timer.Enabled = true;
            timer.AutoReset = false;
            timer.Start();


            return 0;
        }

        public static void OnElapsed(object sender, ElapsedEventArgs e, string ssid1, string uuid1, string xdate3, string xcoach3, string xrouteid)
        {



            ////zttestbus.removeseat(u);
            //List<seatprocess> remove;
            //System.Timers.Timer timer = (System.Timers.Timer)sender;


            //if (System.Web.HttpContext.Current.Application["curseat"] == null)
            //{
            //    remove = new List<seatprocess>();


            //    timer.Stop();
            //    timer.Dispose();
            //    return;
            //}
            //else
            //{
            //    remove = (List<seatprocess>)System.Web.HttpContext.Current.Application["curseat"];
            //}



            //int i;
            //for (i = 0; i < remove.Count; i++)
            //{
            //    seatprocess remst = remove[i];
            //    if (u.Seatid == remst.Seatid && u.Userid == remst.Userid)
            //    {
            //        break;
            //    }
            //}

            //remove.RemoveAt(i);

            //System.Web.HttpContext.Current.Application.Lock();
            //System.Web.HttpContext.Current.Application["curseat"] = remove;
            //System.Web.HttpContext.Current.Application.UnLock();

            removeseat(ssid1, uuid1, xdate3, xcoach3, xrouteid);


            System.Timers.Timer timer = (System.Timers.Timer)sender;
            timer.Stop();
            timer.Dispose();
        }
        //public static void addseat(string sid1, string uid1)

        //public static void addseat(seatprocess u)
        public static void addseat(string ssid, string uuid, string xdate2, string xcoach2, string xrouteid)
        {


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn1;
            string query;

            query = "INSERT INTO ztcurseat" +
                               "(xdate,xcoach,xuser,xseat,xdatetime) " +
                               "VALUES (@xdate,@xcoach,@xuser,@xseat,@xdatetime) ";

            dataCmd.CommandText = query;

            DateTime xdate1 = Convert.ToDateTime(xdate2);
            string xcoach1 = xcoach2;
            string xuser1 = uuid;
            string xseat1 = ssid;

            DateTime xdatetime = DateTime.Now;


            dataCmd.Parameters.AddWithValue("@xdate", xdate1);
            dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
            dataCmd.Parameters.AddWithValue("@xuser", xuser1);
            dataCmd.Parameters.AddWithValue("@xseat", xseat1);
            dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime);
            // dataCmd.Parameters.AddWithValue("@xroute", xrouteid);

            conn1.Close();
            conn1.Open();
            dataCmd.ExecuteNonQuery();
            conn1.Close();

            dataCmd.Dispose();
            conn1.Dispose();

            // List<seatprocess> adds;

            // if (HttpContext.Current.Application["curseat"] == null)
            // {
            //     adds = new List<seatprocess>();
            //     //return;
            // }
            // else
            // {
            //     adds = (List<seatprocess>)HttpContext.Current.Application["curseat"];
            // }

            //// adds.Add(new seatprocess(sid1,uid1));

            // adds.Add(u);

            // HttpContext.Current.Application.Lock();
            // HttpContext.Current.Application["curseat"] = adds;
            // HttpContext.Current.Application.UnLock();

        }


        //public static void removeseat(string sid1, string uid1)

        // public static void removeseat(seatprocess u)
        public static void removeseat(string ssid, string uuid, string xdate2, string xcoach2, string xrouteid)
        {


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn1;
            string query;

            query = "DELETE FROM ztcurseat WHERE xuser=@xuser AND xseat=@xseat AND xdate=@xdate AND xcoach=@xcoach";

            dataCmd.CommandText = query;

            string xuser1 = uuid;
            string xseat1 = ssid;
            DateTime xdate1 = Convert.ToDateTime(xdate2);
            string xcoach1 = xcoach2;

            dataCmd.Parameters.AddWithValue("@xuser", xuser1);
            dataCmd.Parameters.AddWithValue("@xseat", xseat1);
            dataCmd.Parameters.AddWithValue("@xdate", xdate1);
            dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
            //dataCmd.Parameters.AddWithValue("@xroute", xrouteid);

            conn1.Close();
            conn1.Open();
            dataCmd.ExecuteNonQuery();
            conn1.Close();

            dataCmd.Dispose();
            conn1.Dispose();



            //List<seatprocess> remove;

            //if (HttpContext.Current.Application["curseat"] == null)
            //{
            //    remove = new List<seatprocess>();
            //    return;
            //}
            //else
            //{
            //    remove = (List<seatprocess>)HttpContext.Current.Application["curseat"];
            //}

            ////remove.Remove(new seatprocess() { Seatid=sid1, Userid=uid1});

            ////remove.Remove(new seatprocess(sid1, uid1));
            ////seatprocess remst = remove.Where(t => t.Seatid == u.Seatid && t.Userid == u.Userid).SingleOrDefault();

            ////if (remst != null)
            ////{
            ////    remove.Remove(remst);
            ////}

            //int i;
            //for (i = 0; i < remove.Count; i++)
            //{
            //    seatprocess remst = remove[i];
            //    if (u.Seatid == remst.Seatid && u.Userid == remst.Userid)
            //    {
            //        break;
            //    }
            //}

            //remove.RemoveAt(i);

            //HttpContext.Current.Application.Lock();
            //HttpContext.Current.Application["curseat"] = remove;
            //HttpContext.Current.Application.UnLock();
        }


        public static string getuser(string sid1, string xdate2, string xcoach2, string xrouteid)
        {
            string uid1 = "";
            string getusr = "";

            //List<seatprocess> getusr = new List<seatprocess>();

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT xuser from ztcurseat where xseat = @xseat and xdate=@xdate and xcoach=@xcoach";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xseat1 = sid1;
            DateTime xdate1 = Convert.ToDateTime(xdate2);
            string xcoach1 = xcoach2;

            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);
            da.SelectCommand.Parameters.AddWithValue("@xseat", xseat1);
            //da.SelectCommand.Parameters.AddWithValue("@xroute", xrouteid);

            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcurseat = new DataTable();
            dtztcurseat = dts.Tables[0];

            if (dtztcurseat.Rows.Count > 0)
            {
                getusr = dtztcurseat.Rows[0][0].ToString();

                return getusr;
            }


            //if (getusr != null)
            //{
            //    foreach (seatprocess st in getusr)
            //    {
            //        if (st.Seatid == sid1)
            //        {
            //            return st.Userid;
            //        }
            //    }



            ////if (HttpContext.Current.Application["curseat"] == null)
            ////{
            ////    getusr = new List<seatprocess>();
            ////}
            ////else
            ////{
            ////    getusr = (List<seatprocess>)HttpContext.Current.Application["curseat"];
            ////}

            ////if (getusr != null)
            ////{
            ////    foreach (seatprocess st in getusr)
            ////    {
            ////        if (st.Seatid == sid1)
            ////        {
            ////            return st.Userid;
            ////        }
            ////    }

            //    //foreach (List<seatprocess> st in getusr)
            //    //{
            //    //    if (st. == sid1)
            //    //    {
            //    //        return st.Userid;
            //    //    }
            //    //}

            //}


            return uid1;
        }


        //protected void treq_tick(object sender, EventArgs e)
        //{

        //    fnLoadRequestStatus();
        //}

        private void fnLoadRequestStatus()
        {
            //SqlConnection conn11;
            //conn11 = new SqlConnection(zglobal.constring);
            //DataSet dts11 = new DataSet();


            //dts11.Reset();
            //string str11 = "SELECT count(*) FROM ztcancelreq  WHERE xstatus='pending'";
            //SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
            //da11.Fill(dts11, "tempztcode");
            ////DataView dv = new DataView(dts.Tables[0]);
            //DataTable dtztcode = new DataTable();
            //dtztcode = dts11.Tables[0];
            //if (dtztcode.Rows[0][0].ToString() != "0")
            //{
            //    xcancel.Text = dtztcode.Rows[0][0].ToString();
            //}
            //else
            //{
            //    xcancel.Text = "0";
            //}

            //dts11.Dispose();
            //dtztcode.Dispose();
            //da11.Dispose();
            //conn11.Dispose();

            //SqlConnection conn111;
            //conn111 = new SqlConnection(zglobal.constring);
            //DataSet dts111 = new DataSet();


            //dts111.Reset();
            //string str111 = "SELECT count(*) FROM ztmanticapppen  WHERE xstatus='pending'";
            //SqlDataAdapter da111 = new SqlDataAdapter(str111, conn111);
            //da111.Fill(dts111, "tempztcode");
            ////DataView dv = new DataView(dts.Tables[0]);
            //DataTable dtztcode1 = new DataTable();
            //dtztcode1 = dts111.Tables[0];
            //if (dtztcode1.Rows[0][0].ToString() != "0")
            //{
            //    xapprove.Text = dtztcode1.Rows[0][0].ToString();
            //}
            //else
            //{
            //    xapprove.Text = "0";
            //}

            //dts111.Dispose();
            //dtztcode1.Dispose();
            //da111.Dispose();
            //conn111.Dispose();
        }

        public class clsLoadReq
        {
            private string xcancel;
            private string xapprove;

            public string Xcancel
            {
                get { return xcancel; }
                set { xcancel = value; }
            }

            public string Xapprove
            {
                get { return xapprove; }
                set { xapprove = value; }
            }
        }

        [WebMethod]
        public static string fnLoadReq()
        {

            string loadreq = "";

            try
            {
                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts11 = new DataSet();
                string xcanreq;
                string xapp;

                dts11.Reset();
                string str11 = "SELECT count(*) FROM ztcancelreq  WHERE xstatus='pending'";
                SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                da11.Fill(dts11, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts11.Tables[0];
                if (dtztcode.Rows[0][0].ToString() != "0")
                {
                    xcanreq = dtztcode.Rows[0][0].ToString();
                }
                else
                {
                    xcanreq = "0";
                }

                dts11.Dispose();
                dtztcode.Dispose();
                da11.Dispose();
                conn11.Dispose();

                SqlConnection conn111;
                conn111 = new SqlConnection(zglobal.constring);
                DataSet dts111 = new DataSet();


                dts111.Reset();
                string str111 = "SELECT count(*) FROM ztmanticapppen  WHERE xstatus='pending'";
                SqlDataAdapter da111 = new SqlDataAdapter(str111, conn111);
                da111.Fill(dts111, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode1 = new DataTable();
                dtztcode1 = dts111.Tables[0];
                if (dtztcode1.Rows[0][0].ToString() != "0")
                {
                    xapp = dtztcode1.Rows[0][0].ToString();
                }
                else
                {
                    xapp = "0";
                }

                dts111.Dispose();
                dtztcode1.Dispose();
                da111.Dispose();
                conn111.Dispose();

                loadreq = "success|" + xcanreq + "|" + xapp;

                return loadreq;

            }
            catch (Exception exp)
            {
                return exp.Message;
            }

            
        }

        static string userid;
        static string location;

        protected void Page_Load(object sender, EventArgs e)
        {

            //userid = this.Page.User.Identity.Name;

            userid = Convert.ToString(HttpContext.Current.Session["curuser"]);
            location = Convert.ToString(HttpContext.Current.Session["xlocation"]);

            if (!IsPostBack)
            {
                //try
                //{
                    //Check Permission
                    SiteMaster sm = new SiteMaster();
                    string s = sm.fnChkPagePermis("ztbooking");
                    if (s == "n" || s == "e")
                    {
                        HttpContext.Current.Session["curuser"] = null;
                        Session.Abandon();
                        Response.Redirect("~/forms/zlogin.aspx");
                    }


                    xpdate.Text = "";
                    xpcoachno.Text = "";
                    xptime.Text = "";
                    xpbus.Text = "";
                    xpdriver.Text = "";
                    xpguide.Text = "";
                    xproute.Text = "";
                    //load user status

                    string xdate1 = DateTime.Now.ToString("MM/dd/yyyy");
                    string xcoach1 = "null";
                    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                   xsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xsold");
                   xcan.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xcan");
                   xtotalsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtotalsold");


                    xemp.Text = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    xcounter.Text = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    //xsold.Text = "";
                    //xcan.Text = "";
                    //xtotalsold.Text = "";
                    xtbooked.Text = "";
                    xtsold.Text = "";
                    xtamount.Text = "";


                    xseat.ReadOnly = true;


                    mydwh.Items.Add("--");
                    mydwh.Items.Add("01");
                    mydwh.Items.Add("02");
                    mydwh.Items.Add("03");
                    mydwh.Items.Add("04");
                    mydwh.Items.Add("05");
                    mydwh.Items.Add("06");
                    mydwh.Items.Add("07");
                    mydwh.Items.Add("08");
                    mydwh.Items.Add("09");
                    mydwh.Items.Add("10");
                    mydwh.Items.Add("11");
                    mydwh.Items.Add("12");

                    mydwm.Items.Add("00");
                    mydwm.Items.Add("01");
                    mydwm.Items.Add("02");
                    mydwm.Items.Add("03");
                    mydwm.Items.Add("04");
                    mydwm.Items.Add("05");
                    mydwm.Items.Add("06");
                    mydwm.Items.Add("07");
                    mydwm.Items.Add("08");
                    mydwm.Items.Add("09");
                    for (int i = 10; i < 60; i++)
                    {
                        mydwm.Items.Add(i.ToString());
                    }

                    mydwi.Items.Add("am");
                    mydwi.Items.Add("pm");


                    xtime.ReadOnly = true;
                    // Label6.Text = "";

                    xdate.Text = DateTime.Now.ToShortDateString();

                    fnxcoach();

                    //fnLoadRequestStatus();

                    //System.Timers.Timer trequest = new System.Timers.Timer();


                    //trequest.Elapsed += (sender1, e1) => OnElapsed1(sender1, e1);
                    //trequest.Interval = 1000;
                    //trequest.Enabled = true;
                    //trequest.AutoReset = false;
                    //trequest.Start();

                //}
                //catch (Exception exp)
                //{
                //    string message = exp.Message;
                //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                //}
            }
        }
        //public static void OnElapsed1(object sender, ElapsedEventArgs e)
        //{
        //    SqlConnection conn11;
        //    conn11 = new SqlConnection(zglobal.constring);
        //    DataSet dts11 = new DataSet();


        //    dts11.Reset();
        //    string str11 = "SELECT count(*) FROM ztcancelreq  WHERE xstatus='pending'";
        //    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
        //    da11.Fill(dts11, "tempztcode");
        //    //DataView dv = new DataView(dts.Tables[0]);
        //    DataTable dtztcode = new DataTable();
        //    dtztcode = dts11.Tables[0];
        //    if (dtztcode.Rows[0][0].ToString() != "0")
        //    {
        //        zttestbus.xcancel.Text = dtztcode.Rows[0][0].ToString();
        //    }
        //    else
        //    {
        //        zttestbus.xcancel.Text = "0";
        //    }

        //    dts11.Dispose();
        //    dtztcode.Dispose();
        //    da11.Dispose();
        //    conn11.Dispose();

        //    SqlConnection conn111;
        //    conn111 = new SqlConnection(zglobal.constring);
        //    DataSet dts111 = new DataSet();


        //    dts111.Reset();
        //    string str111 = "SELECT count(*) FROM ztmanticapppen  WHERE xstatus='pending'";
        //    SqlDataAdapter da111 = new SqlDataAdapter(str111, conn111);
        //    da111.Fill(dts111, "tempztcode");
        //    //DataView dv = new DataView(dts.Tables[0]);
        //    DataTable dtztcode1 = new DataTable();
        //    dtztcode1 = dts111.Tables[0];
        //    if (dtztcode1.Rows[0][0].ToString() != "0")
        //    {
        //        zttestbus.xapprove.Text = dtztcode1.Rows[0][0].ToString();
        //    }
        //    else
        //    {
        //       zttestbus.xapprove.Text = "0";
        //    }

        //    dts111.Dispose();
        //    dtztcode1.Dispose();
        //    da111.Dispose();
        //    conn111.Dispose();
        //}
        protected void fnFillPassengerListDriverInfo()
        {
            try
            {
                string xdate2 = xdate.Text.ToString();
                string xcoach2 = xcoachno.Text.ToString();

                string xchkdriver = ztsales.fnChkDriver(xdate2, xcoach2);

                if (xchkdriver == "success")
                {


                    xpdate.Text = xdate2.ToString();
                    xpcoachno.Text = xcoach2.ToString();

                    SqlConnection conn2;
                    conn2 = new SqlConnection(zglobal.constring);
                    DataSet dts2 = new DataSet();
                    dts2.Reset();

                    string str2 = "select xbus,xdriver, xguide from ztsaledriver where xdate=@xdate and xcoach=@xcoach and xrow=(select max(xrow) from ztsaledriver where xdate=@xdate and xcoach=@xcoach)";
                    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                    da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                    da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

                    da2.Fill(dts2, "temp");
                    DataTable dtztemp = new DataTable();
                    dtztemp = dts2.Tables["temp"];

                    xpbus.Text = dtztemp.Rows[0][0].ToString();
                    xpdriver.Text = dtztemp.Rows[0][1].ToString();
                    xpguide.Text = dtztemp.Rows[0][2].ToString();

                    /* Retrive route and time from ztcoach */

                    dts2.Reset();

                    str2 = "select (select xmf + '-' + xmt from ztrtm where xmrid=ztcoach.xmrid) as xroute, (xmrtimeh +':'+ xmrtimem +' '+xmrtimei) as xtime from ztcoach where xcoachno=@xcoachno";

                    SqlDataAdapter da3 = new SqlDataAdapter(str2, conn2);

                    da3.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoach2);
                    da3.Fill(dts2, "temp1");

                    dtztemp.Reset();
                    dtztemp = dts2.Tables["temp1"];

                    xproute.Text = dtztemp.Rows[0][0].ToString();
                    xptime.Text = dtztemp.Rows[0][1].ToString();

                }
                else
                {
                    xpdate.Text = "";
                    xpcoachno.Text = "";
                    xptime.Text = "";
                    xpbus.Text = "";
                    xpdriver.Text = "";
                    xpguide.Text = "";
                    xproute.Text = "";
                }
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
        protected void xcoachno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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


        //string rt1stseq = "";
        //string rt2ndseq = "";
        //int hassub = 0;

        protected void xroute_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

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
                string str = "select mrt,srt from ztroute where route=@route and mrt= (select distinct xmrid from zttrip  WHERE  @xdate between xstdt and xendt AND zactive=1 AND xcoachno= @xcoachno)";
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
            try
            {
                //PlaceHolder1.Controls.Clear();
                if (xdate.Text == "" || xcoachno.Text == "" || xroute.Text == "")
                {
                    if (xdate.Text == "")
                    {
                        xdate.BackColor = System.Drawing.Color.Pink;
                        //xdate.BorderColor = System.Drawing.Color.DarkRed;

                    }
                    else
                    {
                        xdate.BackColor = System.Drawing.Color.White;
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
                    if (xroute.Text == "")
                    {
                        xroute.BackColor = System.Drawing.Color.Pink;
                        //xroute.BorderColor = System.Drawing.Color.DarkRed;

                    }
                    else
                    {
                        xroute.BackColor = System.Drawing.Color.White;
                    }

                    return;
                }

                xdate.BackColor = System.Drawing.Color.White;
                //xdate.BorderColor = System.Drawing.Color.White;

                xcoachno.BackColor = System.Drawing.Color.White;
                //xcoachno.BorderColor = System.Drawing.Color.White;

                xroute.BackColor = System.Drawing.Color.White;
                //xroute.BorderColor = System.Drawing.Color.White;

                //msg.InnerHtml = selected_route.Value;

                /* Auto cancel booking*/

                ztsales.fnAutoCancelBooking(xdate.Text.ToString(), xcoachno.Text.ToString());

                /*  Load Bus */
                fnBusLoad();



                /* Side List Load */
                fnFillPassengerListDriverInfo();

                string xdate1 = Convert.ToDateTime(xdate.Text).ToString();
                string xcoach1 = xcoachno.Text;
                string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                xsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xsold");
                //xcan.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xcan");
                //xtotalsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtotalsold");
                xtbooked.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtbooked");
                xtsold.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtsold");
                xtamount.Text = zglobal.fnSideList(xdate1, xcoach1, xuser1, xloc1, "xtamount");


                DataTable ztpasslist = new DataTable();
                ztpasslist = zglobal.fnSideGridView(xdate1, xcoach1, "sold");
                GridView1.DataSource = ztpasslist;
                GridView1.DataBind();

                DataTable ztbooklist = new DataTable();
                ztbooklist = zglobal.fnSideGridView(xdate1, xcoach1, "booking");
                GridView2.DataSource = ztbooklist;
                GridView2.DataBind();

                //upbustype.ContentTemplateContainer.Controls.Clear();
                //upbustype.ContentTemplateContainer.Controls.Add(eclasss);

                //Load Cancel and Manual ticket request

                string loadreq = zttestbus.fnLoadReq();

                string[] reqarr = loadreq.Split('|');

                if (reqarr[0] == "success")
                {
                    if (reqarr[1] == "0")
                    {
                        LinkButton1.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        LinkButton1.ForeColor = System.Drawing.Color.Red;
                    }
                    if (reqarr[2] == "0")
                    {
                        LinkButton2.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        LinkButton2.ForeColor = System.Drawing.Color.Red;
                    }

                    LinkButton1.Text = "Cancel Ticket: " + reqarr[1];
                    LinkButton2.Text = "Manual Ticket: " + reqarr[2];
                }
 

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }

        }




        protected void fnBusLoad()
        {
            //int isEnable = 1;
            //string attIsEnable;

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

            //if (Convert.ToDateTime(xdate.Text).Date < DateTime.Now.Date)
            //{
            //    isEnable = 0;
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
                string bustype = dtzt.Rows[0][0].ToString();
                if (bustype == "E-Class(B)")
                {
                    //if (isEnable == 0)
                    //{
                    //    eclassb.Enabled = false;
                    //}
                    //else
                    //{
                    //    eclassb.Enabled = true;
                    //}

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
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id='" + cid + "'  value='" + cvalue + "' class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:
                                    cid = "bb" + i;
                                    cvalue = "B" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
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
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
                                    eclassb.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "bd" + i;
                                    cvalue = "D" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclassb.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
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
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
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
                                    eclassb.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
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
                    //if (isEnable == 0)
                    //{
                    //    eclasss.Enabled = false;
                    //}
                    //else
                    //{
                    //    eclasss.Enabled = true;
                    //}

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
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id='" + cid + "'  value='" + cvalue + "' class='" + cbtclass + "'" + attIsEnable + " />"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:
                                    cid = "sb" + i;
                                    cvalue = "B" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus25' height='40px' width='40px' colspan='3'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
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
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "sd" + i;
                                    cvalue = "D" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
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
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                case 2:

                                    c = c + 1;
                                    cid = "sf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus250' height='40px' colspan='5'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "'" + attIsEnable + " />"));
                                    eclasss.Controls.Add(new LiteralControl("</td>"));
                                    break;


                                default:
                                    c = c + 1;
                                    cid = "sf" + c;
                                    cvalue = "F" + c;
                                    cbtclass = fnSeatStatus(cvalue);

                                    eclasss.Controls.Add(new LiteralControl(" <td class='bus25000' height='40px' colspan='2'>"));
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
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
                                    eclasss.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
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

                    //if (isEnable == 0)
                    //{
                    //    hinoac.Enabled = false;
                    //}
                    //else
                    //{
                    //    hinoac.Enabled = true;
                    //}

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
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
                                    hinoac.Controls.Add(new LiteralControl("</td>"));
                                    break;
                                default:
                                    cid = "hd" + i;
                                    cvalue = "D" + i;
                                    cbtclass = fnSeatStatus(cvalue);

                                    hinoac.Controls.Add(new LiteralControl("<td class='bus13' height='40px' width='40px'>"));
                                    hinoac.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
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

                    //if (isEnable == 0)
                    //{
                    //    sclass.Enabled = false;
                    //}
                    //else
                    //{
                    //    sclass.Enabled = true;
                    //}

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
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id='" + cid + "'  value='" + cvalue + "' class='" + cbtclass + "'" + attIsEnable + " />"));
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
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
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
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + " />"));
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
                                    sclass.Controls.Add(new LiteralControl("<input type='button' id=" + cid + "  value=" + cvalue + " class='" + cbtclass + "' " + attIsEnable + "/>"));
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

        public void fnSequence()
        {
            try
            {

            }
            catch (Exception exp)
            {
                string message = exp.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
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

                string result = fnMultipleRouteSequence(selroute, jcoach, jdate, xseatid);
                //msg.InnerHtml = result;
                if (result != "empty")
                {
                    //if (result == "booking")
                    //{
                    //    string xid1 = dtzt.Rows[0][1].ToString();



                    //    int res = ztsales.fnAutoCancelBooking(xid1, xseat2, xdate1.ToString(), xcoach1, xroute1000);

                    //    if (res == 1)
                    //    {
                    //        result = "btn";
                    //    }
                    //}

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



                //    int res = ztsales.fnAutoCancelBooking(xid1, xseat2, xdate1.ToString(), xcoach1, xroute1000);

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


        public static string fnMultipleRouteSequence(string xroute2, string xcoach2, string xdate2, string xseat)
        {
            string res = "empty";

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT xstatus,xroute FROM ztsaled  WHERE  xdate=@xdate and xcoach= @xcoach and xseat=@xseat and xstatus NOT IN ('autocancelbooking', 'reqcancel','forsalesold','bookingcancel','omited','busreserve','manticappcan','cancel','confcan','cancelsold','cancelms','cancelconf')";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            DateTime xdate1 = Convert.ToDateTime(xdate2);
            string xcoach1 = xcoach2;
            string xseat1 = xseat;

            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);
            da.SelectCommand.Parameters.AddWithValue("@xseat", xseat1);

            da.Fill(dts, "tempzt");

            DataTable dtzt = new DataTable();
            dtzt = dts.Tables[0];

            int selected_route = Convert.ToInt32(xroute2);
            List<Int32> seat_route_list = new List<Int32>();

            if (dtzt.Rows.Count > 0)
            {
                //build seat route list
                for (int i = 0; i < dtzt.Rows.Count; i++)
                {
                    seat_route_list.Add(Convert.ToInt32(dtzt.Rows[i][1]));
                }

                //check if the selected route is same as any of the seat route list 
                for (int i = 0; i < dtzt.Rows.Count; i++)
                {
                    if (selected_route == seat_route_list[i])
                    {
                        return dtzt.Rows[i][0].ToString();
                    }
                }

                //check where the selected route is main or sub route
                if (Convert.ToString(selected_route).Length == 3)
                {
                    //check is there have any sub route
                    for (int j = 0; j < dtzt.Rows.Count; j++)
                    {
                        if (Convert.ToString(seat_route_list[j]).Length > 3)
                        {
                            //return dtzt.Rows[j][0].ToString();
                            //for chittagong-kolkata (border) subroute
                            if (selected_route == 106 || selected_route == 10601 || selected_route == 10602 || selected_route == 10603 || selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10602 || seat_route_list[i] == 10603)
                                    {
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10604 || seat_route_list[i] == 10605 || seat_route_list[i] == 10606)
                                    {
                                        if (selected_route == 10601)
                                        {
                                            return "btn";
                                        }
                                        if (selected_route == 10602 || selected_route == 10603 || selected_route == 106)
                                        {
                                            for (int p = 0; p < dtzt.Rows.Count; p++)
                                            {
                                                if (seat_route_list[p] == 10601)
                                                {
                                                    if (selected_route != 10604 || selected_route != 10605 || selected_route != 10606)
                                                    {
                                                        return dtzt.Rows[p][0].ToString();
                                                    }

                                                }
                                            }
                                        }
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10601)
                                    {
                                        if (selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                                        {
                                            return "btn";
                                        }
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                            }

                            ///////////////////////////////////////////////////////

                            if (selected_route == 107 || selected_route == 10701 || selected_route == 10702 || selected_route == 10703 || selected_route == 10704 || selected_route == 10705)
                            {
                                //for Banapole-Chittagong-107 subroute

                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10704)
                                    {
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10702 || seat_route_list[i] == 10703)
                                    {
                                        if (selected_route == 10705)
                                        {
                                            return "btn";
                                        }
                                        if (selected_route == 10704 || selected_route == 107)
                                        {
                                            for (int p = 0; p < dtzt.Rows.Count; p++)
                                            {
                                                if (seat_route_list[p] == 10705)
                                                {
                                                    if (selected_route != 10702 || selected_route != 10703)
                                                    {
                                                        return dtzt.Rows[p][0].ToString();
                                                    }

                                                }
                                            }
                                        }
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10705)
                                    {
                                        if (selected_route == 10702 || selected_route == 10703)
                                        {
                                            return "btn";
                                        }
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                            }

                            ///////////////////////////////////////

                            //for Dhaka-Cox Bazar-108 subroute
                            if (selected_route == 108 || selected_route == 10801)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10801)
                                    {
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                            }

                            ////////////////////////////////

                            //for Cox Bazar-Dhaka-109 subroute
                            if (selected_route == 109 || selected_route == 10901 || selected_route == 10903)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10901)
                                    {
                                        if (selected_route == 109)
                                        {
                                            return dtzt.Rows[i][0].ToString();
                                        }
                                        return "btn";
                                    }
                                }

                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10903)
                                    {
                                        if (selected_route == 109)
                                        {
                                            return dtzt.Rows[i][0].ToString();
                                        }
                                        return "btn";
                                    }
                                }
                            }

                            ////////////////////////////////

                            //for Dhaka-Kolkata(Bondar)-110 subroute
                            if (selected_route == 110 || selected_route == 11001 || selected_route == 11002)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 11001)
                                    {
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }

                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 11002)
                                    {
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                            }

                            ////////////////////////////////

                            //for Benapole-Dhaka-111 subroute
                            if (selected_route == 111 || selected_route == 11102)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 11102)
                                    {
                                        return dtzt.Rows[i][0].ToString();
                                    }
                                }
                            }

                            ////////////////////////////////





                        }
                    }

                    return "btn";
                }
                else //if subroute
                {

                    //check is there have any main route
                    for (int i = 0; i < dtzt.Rows.Count; i++)
                    {
                        if (Convert.ToString(seat_route_list[i]).Length == 3)
                        {
                            return dtzt.Rows[i][0].ToString();
                        }
                    }

                    //if there is no main route then 

                    //for chittagong-kolkata (border) subroute
                    if (selected_route == 106 || selected_route == 10601 || selected_route == 10602 || selected_route == 10603 || selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10602 || seat_route_list[i] == 10603)
                            {
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10604 || seat_route_list[i] == 10605 || seat_route_list[i] == 10606)
                            {
                                if (selected_route == 10601)
                                {
                                    return "btn";
                                }
                                if (selected_route == 10602 || selected_route == 10603 || selected_route == 106)
                                {
                                    for (int p = 0; p < dtzt.Rows.Count; p++)
                                    {
                                        if (seat_route_list[p] == 10601)
                                        {
                                            if (selected_route != 10604 || selected_route != 10605 || selected_route != 10606)
                                            {
                                                return dtzt.Rows[p][0].ToString();
                                            }

                                        }
                                    }
                                }
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10601)
                            {
                                if (selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                                {
                                    return "btn";
                                }
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                    }

                    ///////////////////////////////////////////////////////

                    //for Banapole-Chittagong-107 subroute
                    if (selected_route == 107 || selected_route == 10701 || selected_route == 10702 || selected_route == 10703 || selected_route == 10704 || selected_route == 10705)
                    {


                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10704)
                            {
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10702 || seat_route_list[i] == 10703)
                            {
                                if (selected_route == 10705)
                                {
                                    return "btn";
                                }
                                if (selected_route == 10704 || selected_route == 107)
                                {
                                    for (int p = 0; p < dtzt.Rows.Count; p++)
                                    {
                                        if (seat_route_list[p] == 10705)
                                        {
                                            if (selected_route != 10702 || selected_route != 10703)
                                            {
                                                return dtzt.Rows[p][0].ToString();
                                            }

                                        }
                                    }
                                }
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10705)
                            {
                                if (selected_route == 10702 || selected_route == 10703)
                                {
                                    return "btn";
                                }
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                    }

                    ///////////////////////////////////////

                    //for Dhaka-Cox Bazar-108 subroute
                    if (selected_route == 108 || selected_route == 10801)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10801)
                            {
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                    }

                    ////////////////////////////////

                    //for Cox Bazar-Dhaka-109 subroute
                    if (selected_route == 109 || selected_route == 10901 || selected_route == 10903)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10901)
                            {
                                if (selected_route == 109)
                                {
                                    return dtzt.Rows[i][0].ToString();
                                }
                                return "btn";
                            }
                        }

                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10903)
                            {
                                if (selected_route == 109)
                                {
                                    return dtzt.Rows[i][0].ToString();
                                }
                                return "btn";
                            }
                        }
                    }

                    ////////////////////////////////

                    //for Dhaka-Kolkata(Bondar)-110 subroute
                    if (selected_route == 110 || selected_route == 11001 || selected_route == 11002)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 11001)
                            {
                                return dtzt.Rows[i][0].ToString();
                            }
                        }

                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 11002)
                            {
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                    }

                    ////////////////////////////////

                    //for Benapole-Dhaka-111 subroute
                    if (selected_route == 111 || selected_route == 11102)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 11102)
                            {
                                return dtzt.Rows[i][0].ToString();
                            }
                        }
                    }

                    ////////////////////////////////


                    ////selected route start and end point
                    //str = "select frt,trt from ztroute where srt=@xroute";

                    //string xroute1 = xroute2;

                    //SqlDataAdapter da10 = new SqlDataAdapter(str, conn1);

                    //da10.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);
                    //dts.Reset();
                    //da10.Fill(dts, "tempzt");

                    //DataTable dttemp = new DataTable();
                    //dttemp = dts.Tables[0];

                    //string sel_rt_st_point = dttemp.Rows[0][0].ToString();
                    //string sel_rt_end_point = dttemp.Rows[0][1].ToString();
                    //////////////////////////////

                    //////check if there is have as like as start point in the seat route list

                    //for (int i = 0; i < dtzt.Rows.Count; i++)
                    //{
                    //    if (Convert.ToString(seat_route_list[i]).Length != 3)
                    //    {


                    //        str = "select frt from ztroute where srt=@xroute";

                    //        string xroute11 = Convert.ToString(seat_route_list[i]);

                    //        SqlDataAdapter da101 = new SqlDataAdapter(str, conn1);

                    //        da101.SelectCommand.Parameters.AddWithValue("@xroute", xroute11);
                    //        dts.Reset();
                    //        da101.Fill(dts, "tempzt");

                    //        DataTable dttemp1 = new DataTable();
                    //        dttemp1 = dts.Tables[0];

                    //        string seat_rt_st_point = dttemp1.Rows[0][0].ToString();
                    //        //string seat_rt_end_point = dttemp1.Rows[0][1].ToString();

                    //        if (Convert.ToInt32(seat_rt_st_point) == Convert.ToInt32(sel_rt_st_point))
                    //        {
                    //            return dtzt.Rows[i][0].ToString();
                    //        }


                    //    }
                    //}

                    //////check if there is have as like as end point in the seat route list

                    //for (int i = 0; i < dtzt.Rows.Count; i++)
                    //{
                    //    if (Convert.ToString(seat_route_list[i]).Length != 3)
                    //    {


                    //        str = "select trt from ztroute where srt=@xroute";

                    //        string xroute111 = Convert.ToString(seat_route_list[i]);

                    //        SqlDataAdapter da1011 = new SqlDataAdapter(str, conn1);

                    //        da1011.SelectCommand.Parameters.AddWithValue("@xroute", xroute111);
                    //        dts.Reset();
                    //        da1011.Fill(dts, "tempzt");

                    //        DataTable dttemp11 = new DataTable();
                    //        dttemp11 = dts.Tables[0];

                    //        string seat_rt_end_point = dttemp11.Rows[0][0].ToString();
                    //        //string seat_rt_end_point = dttemp1.Rows[0][1].ToString();

                    //        if (Convert.ToInt32(seat_rt_end_point) == Convert.ToInt32(sel_rt_end_point))
                    //        {
                    //            return dtzt.Rows[i][0].ToString();
                    //        }
                    //    }
                    //}


                    return "btn";
                }


            }

            return res;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {



        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnBusOmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtconformmessageValue.Value == "No")
                {
                    return;
                }
                else
                {
                    using (TransactionScope tran = new TransactionScope())
                    {

                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd = new SqlCommand();
                        dataCmd.Connection = conn1;
                        string query;
                        query = "UPDATE ztsaled SET xstatus='omited' " +
                                                 "WHERE xdate=@xdate AND xcoach=@xcoach";

                        dataCmd.CommandText = query;

                        string xdate1 = xdate.Text.ToString().Trim();
                        string xcoach1 = xcoachno.Text.ToString().Trim();

                        dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);

                        conn1.Close();
                        conn1.Open();
                        //dataCmd.ExecuteNonQuery();

                        query = "INSERT INTO ztbusomit " +
                                    " (xrow,xdate,xcoach,xuser,xdt,xloc,xopt) " +
                                    " VALUES (@xrow,@xdate,@xcoach,@xuser,@xdt,@xloc,'omit') ";

                        dataCmd.CommandText = query;

                        string xrow1 = zglobal.fnmaxid("SELECT max(xrow) FROM ztbusomit where getdate() between @firstdate and @lastdate");
                        string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xdt1 = DateTime.Now;
                        string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                        dataCmd.Parameters.Clear();
                        dataCmd.Parameters.AddWithValue("@xrow", xrow1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                        dataCmd.Parameters.AddWithValue("@xuser", xuser1);
                        dataCmd.Parameters.AddWithValue("@xdt", xdt1);
                        dataCmd.Parameters.AddWithValue("@xloc", xloc1);

                        dataCmd.ExecuteNonQuery();

                        conn1.Close();

                        tran.Complete();


                    }

                    fnBusLoad();
                }

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btncanbusomit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtconformmessageValue.Value == "No")
                {
                    return;
                }
                else
                {
                    using (TransactionScope tran = new TransactionScope())
                    {

                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd = new SqlCommand();
                        dataCmd.Connection = conn1;
                        string query;




                        query = "UPDATE ztbusomit SET " +
                                    " xcanby=@xuser,xcandt=@xdt,xcanloc=@xloc,xopt='canceled' " +
                                    " WHERE xdate=@xdate AND xcoach=@xcoach AND xopt='omit'";

                        dataCmd.CommandText = query;

                        string xdate1 = xdate.Text.ToString().Trim();
                        string xcoach1 = xcoachno.Text.ToString().Trim();
                        string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xdt1 = DateTime.Now;
                        string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                        dataCmd.Parameters.Clear();
                        dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                        dataCmd.Parameters.AddWithValue("@xuser", xuser1);
                        dataCmd.Parameters.AddWithValue("@xdt", xdt1);
                        dataCmd.Parameters.AddWithValue("@xloc", xloc1);

                        conn1.Close();
                        conn1.Open();

                        dataCmd.ExecuteNonQuery();

                        conn1.Close();

                        tran.Complete();

                    }

                    fnBusLoad();
                }

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }



        [WebMethod(EnableSession = true)]
        public static string fnSideList123(string xdate2, string xcoach2, string optfor)
        {
            try
            {
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();
                string str2;

                if (optfor == "xsold")
                {
                    //str2 = "SELECT COUNT(*) FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('sold','forsale','mansale') AND xuser=@xuser AND xloc=@xloc";
                    //str2 = "SELECT SUM(c) FROM " +
                    //       " (SELECT COUNT(*) as c FROM ztsaled WHERE xsolddt=@xdate AND xstatus IN ('sold','forsale','mansale') AND xuser=@xuser AND xloc=@xloc " +
                    //       "  UNION ALL " +
                    //       "  SELECT COUNT(*) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xsolddt=@xdate AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold') AND xuser=@xuser AND xloc=@xloc) as b";
                    //str2 = "select " +
                    //       " ((select count(*) from ztsalevw where xaction='Sold' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc) " +
                    //       " - (select count(*) from ztsalevw where xaction='Canceled' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc)) as b";
                    str2 = "select count(*) from ztsalevw where xaction='Sold' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc";
                }
                else if (optfor == "xtotalsold")
                {
                    //str2 = "select SUM(xrate) from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','forsale','mansale') and xuser=@xuser AND xloc=@xloc";
                    //str2 = "SELECT SUM(c) FROM " +
                    //      " (SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled WHERE xsolddt=@xdate AND xstatus IN ('sold','forsale','mansale') and xuser=@xuser AND xloc=@xloc " +
                    //      "  UNION ALL " +
                    //      "  SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xsolddt=@xdate AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold') and xuser=@xuser AND xloc=@xloc) as b";

                    str2 = "select " +
                           " ((select COALESCE (sum(xnetamt), 0) from ztsalevw where xaction='Sold' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc) " +
                           " - (select COALESCE (sum(xnetamt), 0) from ztsalevw where xaction='Canceled' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc)) as b";

                }
                else if (optfor == "xtbooked")
                {
                    str2 = "SELECT COUNT(*) FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('booking','confbooking')";
                }
                else if (optfor == "xtsold")
                {
                    str2 = "SELECT SUM(c) FROM " +
                           " (SELECT COUNT(*) as c FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('sold','forsale','mansale') " +
                           "  UNION ALL " +
                           "  SELECT COUNT(*) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xdate=@xdate AND ztsaled.xcoach=@xcoach AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold')) as b";
                }
                else if (optfor == "xtamount")
                {
                    //str2 = "select SUM(xrate) from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','forsale','mansale')";
                    str2 = "SELECT SUM(c) FROM " +
                         " (SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('sold','forsale','mansale') " +
                         "  UNION ALL " +
                         "  SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xdate=@xdate AND ztsaled.xcoach=@xcoach AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold')) as b";

                }
                else
                {
                    //str2 = "select COUNT(*) from ztcancelreq where xapprovedt=@xdate and xreqby=@xreqby and xreqloc=@xreqloc and xstatus='approved' and xremark not in('confbooking')";
                    str2 = "select count(*) from ztsalevw where xaction='Canceled' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc";
                }


                if (optfor == "xsold" || optfor == "xcan" || optfor == "xtotalsold")
                {
                    xdate2 = DateTime.Now.ToString("MM/dd/yyyy");
                }


                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                string xuser2 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string xloc2 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                //da2.SelectCommand.Parameters.AddWithValue("@xstatus",xstatus2);
                da2.SelectCommand.Parameters.AddWithValue("@xuser", xuser2);
                da2.SelectCommand.Parameters.AddWithValue("@xloc", xloc2);
                da2.SelectCommand.Parameters.AddWithValue("@xreqby", xuser2);
                da2.SelectCommand.Parameters.AddWithValue("@xreqloc", xloc2);

                da2.Fill(dts2, "temp");
                DataTable zttemp = new DataTable();
                zttemp = dts2.Tables["temp"];

                if (!Convert.IsDBNull(zttemp.Rows[0][0]))
                {
                    return zttemp.Rows[0][0].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception exp)
            {
                return "Side List Load Error : " + exp.Message;
            }


        }

        public class soldgrid
        {
            private string xseat;
            private string xname;
            private string xphone;
            private string xticket;
            private string xboarding;
            private string xdestination;
            private string xuser;



            public string Xseat
            {
                get { return xseat; }
                set { xseat = value; }
            }

            public string Xname
            {
                get { return xname; }
                set { xname = value; }

            }

            public string Xphone
            {
                get { return xphone; }
                set { xphone = value; }

            }

            public string Xticket
            {
                get { return xticket; }
                set { xticket = value; }

            }

            public string Xboarding
            {
                get { return xboarding; }
                set { xboarding = value; }

            }
            public string Xdestination
            {
                get { return xdestination; }
                set { xdestination = value; }

            }

            public string Xuser
            {
                get { return xuser; }
                set { xuser = value; }

            }
        }

        public class bookinggrid
        {
            private string xseat;
            private string xname;
            private string xphone;
            private string xuser;
            private string xboarding;
            private string xdestination;
            private string xexpired;


            public string Xseat
            {
                get { return xseat; }
                set { xseat = value; }
            }

            public string Xname
            {
                get { return xname; }
                set { xname = value; }

            }

            public string Xphone
            {
                get { return xphone; }
                set { xphone = value; }

            }

            public string Xuser
            {
                get { return xuser; }
                set { xuser = value; }

            }

            public string Xboarding
            {
                get { return xboarding; }
                set { xboarding = value; }

            }
            public string Xdestination
            {
                get { return xdestination; }
                set { xdestination = value; }

            }

            public string Xexpired
            {
                get { return xexpired; }
                set { xexpired = value; }

            }
        }



        [WebMethod(EnableSession = true)]
        public static List<soldgrid> fnSideGridViewSold(string xdate2, string xcoach2)
        {
            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();
            string str2;
            List<soldgrid> gridsold = new List<soldgrid>();

            //str2 = " select ztsaled.xseat as xseat, ztsaleh.xname as xname, ztsaleh.xphone as xphone, ztsaleh.xticket as xticket,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser from ztsaleh " +
            //       " inner join ztsaled on ztsaleh.xid=ztsaled.xid where ztsaled.xdate=@xdate " +
            //       " and ztsaled.xcoach=@xcoach and xstatus IN ('sold','forsale','mansale')"; //,'cancelpending'
            //str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser from ztsaleh " +
            //           " inner join ztsaled on ztsaleh.xid=ztsaled.xid where ztsaled.xdate=@xdate " +
            //           " and ztsaled.xcoach=@xcoach and xstatus IN ('sold','forsale','mansale') " +
            //           " UNION ALL " +
            //           " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby) as xuser from ztsaleh " +
            //           " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd where ztsaled.xdate=@xdate " +
            //           " and ztsaled.xcoach=@xcoach and ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in('mansale','sold')";

            str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztseatsl.xline from ztsaleh " +
                       " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                       " and ztsaled.xcoach=@xcoach and xstatus IN ('sold','forsale','mansale')  " +
                       " UNION ALL " +
                       " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztseatsl.xline from ztsaleh " +
                       " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                       " and ztsaled.xcoach=@xcoach and ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in('mansale','sold') order by ztseatsl.xline";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

            da2.Fill(dts2, "temp");
            DataTable zttemp = new DataTable();
            zttemp = dts2.Tables["temp"];


            foreach (DataRow row in zttemp.Rows)
            {
                soldgrid gsold = new soldgrid();
                gsold.Xseat = row["xseat"].ToString();
                gsold.Xname = row["xname"].ToString();
                gsold.Xphone = row["xphone"].ToString();
                gsold.Xticket = row["xticket"].ToString();
                gsold.Xboarding = row["xboarding"].ToString();
                gsold.Xdestination = row["xdestination"].ToString();
                gsold.Xuser = row["xuser"].ToString();

                gridsold.Add(gsold);

            }

            return gridsold;


        }

        [WebMethod(EnableSession = true)]
        public static List<bookinggrid> fnSideGridViewBooking(string xdate2, string xcoach2)
        {
            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();
            string str2;
            List<bookinggrid> gridbooking = new List<bookinggrid>();

            //str2 = " select ztsaled.xseat as xseat, ztsaleh.xname as xname, ztsaleh.xphone as xphone, (select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser, (cast(ztsaleh.xdateexp as varchar) + ' ' + ztsaleh.xtimeexp) as xexpired  from ztsaleh " +
            //       " inner join ztsaled on ztsaleh.xid=ztsaled.xid where ztsaled.xdate=@xdate " +
            //       " and ztsaled.xcoach=@xcoach and xstatus IN ('booking','confbooking')";

            str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, (select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination, (cast(ztsaleh.xdateexp as varchar) + ' ' + ztsaleh.xtimeexp) as xexpired,ztseatsl.xline  from ztsaleh " +
                      " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                      " and ztsaled.xcoach=@xcoach and xstatus IN ('booking','confbooking')  " +
                       " UNION ALL " +
                      " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, (select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination, (cast(ztsaleh.xdateexp as varchar) + ' ' + ztsaleh.xtimeexp) as xexpired,ztseatsl.xline  from ztsaleh  " +
                      " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                      " and ztsaled.xcoach=@xcoach and ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in('confbooking') order by ztseatsl.xline";


            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

            da2.Fill(dts2, "temp");
            DataTable zttemp = new DataTable();
            zttemp = dts2.Tables["temp"];


            foreach (DataRow row in zttemp.Rows)
            {
                bookinggrid gbooking = new bookinggrid();
                gbooking.Xseat = row["xseat"].ToString();
                gbooking.Xname = row["xname"].ToString();
                gbooking.Xphone = row["xphone"].ToString();
                gbooking.Xuser = row["xuser"].ToString();
                gbooking.Xboarding = row["xboarding"].ToString();
                gbooking.Xdestination = row["xdestination"].ToString();
                gbooking.Xexpired = row["xexpired"].ToString();

                gridbooking.Add(gbooking);

            }

            return gridbooking;


        }

        [WebMethod(EnableSession = true)]
        public static string fnChkSeatSt(string xdate2, string xcoach2, string xseat2)
        {
            try
            {
                string res = "nai";

                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();
                string str2;

                str2 = "SELECT * FROM ztsaled WHERE xcoach=@xcoach AND xdate=@xdate AND xseat=@xseat ";

                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                string[] xseat3 = xseat2.Split(',');


                for (int i = 0; i < xseat3.Length; i++)
                {
                    da2.SelectCommand.Parameters.Clear();
                    da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                    da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
                    da2.SelectCommand.Parameters.AddWithValue("@xseat", xseat3[i]);
                    dts2.Reset();
                    da2.Fill(dts2, "temp");
                    DataTable ztmstk = new DataTable();
                    ztmstk = dts2.Tables["temp"];
                    if (ztmstk.Rows.Count > 0)
                    {
                        return "ache";
                    }

                }

                return res;
            }
            catch (Exception exp)
            {
                return exp.Message;
            }

        }


        public static string fnChkMultirouteSale(string xroute2, string xcoach2, string xdate2, string xseat, string xstatus2)
        {
            string res = "empty";

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();

            string[] xseat9 = xseat.Split(',');

            string xseat1 = "'";
            for (int i = 0; i < xseat9.Length; i++)
            {

                xseat1 = xseat1 + xseat9[i] + "'";
                if (i != xseat9.Length - 1)
                {
                    xseat1 += ",'";
                }
            }
            
            string str = "SELECT xstatus,xroute FROM ztsaled  WHERE  xdate=@xdate and xcoach= @xcoach and xseat IN (" + xseat1 + ") and xstatus IN (" + xstatus2 + ")";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            DateTime xdate1 = Convert.ToDateTime(xdate2);
            string xcoach1 = xcoach2;

            //string[] xseat9 = xseat.Split(',');

            //string xseat1 = "'";
            //for (int i = 0; i < xseat9.Length; i++)
            //{

            //    xseat1 = xseat1 + xseat9[i] + "'";
            //    if (i != xseat9.Length - 1)
            //    {
            //        xseat1 += ",'";
            //    }
            //}


            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);
            //da.SelectCommand.Parameters.AddWithValue("@xseat", xseat1);

            da.Fill(dts, "tempzt");

            DataTable dtzt = new DataTable();
            dtzt = dts.Tables[0];

            int selected_route = Convert.ToInt32(xroute2);
            List<Int32> seat_route_list = new List<Int32>();

            if (dtzt.Rows.Count > 0)
            {
                //build seat route list
                for (int i = 0; i < dtzt.Rows.Count; i++)
                {
                    seat_route_list.Add(Convert.ToInt32(dtzt.Rows[i][1]));
                }

                //check if the selected route is same as any of the seat route list 
                for (int i = 0; i < dtzt.Rows.Count; i++)
                {
                    if (selected_route == seat_route_list[i])
                    {
                        return "true";
                    }
                }

                //check where the selected route is main or sub route
                if (Convert.ToString(selected_route).Length == 3)
                {
                    //check is there have any sub route
                    for (int j = 0; j < dtzt.Rows.Count; j++)
                    {
                        if (Convert.ToString(seat_route_list[j]).Length > 3)
                        {
                            //return dtzt.Rows[j][0].ToString();
                            //for chittagong-kolkata (border) subroute
                            if (selected_route == 106 || selected_route == 10601 || selected_route == 10602 || selected_route == 10603 || selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10602 || seat_route_list[i] == 10603)
                                    {
                                        return "true";
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10604 || seat_route_list[i] == 10605 || seat_route_list[i] == 10606)
                                    {
                                        if (selected_route == 10601)
                                        {
                                            return "false";
                                        }
                                        if (selected_route == 10602 || selected_route == 10603 || selected_route == 106)
                                        {
                                            for (int p = 0; p < dtzt.Rows.Count; p++)
                                            {
                                                if (seat_route_list[p] == 10601)
                                                {
                                                    if (selected_route != 10604 || selected_route != 10605 || selected_route != 10606)
                                                    {
                                                        return "true";
                                                    }

                                                }
                                            }
                                        }
                                        return "true";
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10601)
                                    {
                                        if (selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                                        {
                                            return "false";
                                        }
                                        return "true";
                                    }
                                }
                            }

                            ///////////////////////////////////////////////////////

                            if (selected_route == 107 || selected_route == 10701 || selected_route == 10702 || selected_route == 10703 || selected_route == 10704 || selected_route == 10705)
                            {
                                //for Banapole-Chittagong-107 subroute

                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10704)
                                    {
                                        return "true";
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10702 || seat_route_list[i] == 10703)
                                    {
                                        if (selected_route == 10705)
                                        {
                                            return "false";
                                        }
                                        if (selected_route == 10704 || selected_route == 107)
                                        {
                                            for (int p = 0; p < dtzt.Rows.Count; p++)
                                            {
                                                if (seat_route_list[p] == 10705)
                                                {
                                                    if (selected_route != 10702 || selected_route != 10703)
                                                    {
                                                        return "true";
                                                    }

                                                }
                                            }
                                        }
                                        return "true";
                                    }
                                }
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10705)
                                    {
                                        if (selected_route == 10702 || selected_route == 10703)
                                        {
                                            return "false";
                                        }
                                        return "true";
                                    }
                                }
                            }

                            ///////////////////////////////////////

                            //for Dhaka-Cox Bazar-108 subroute
                            if (selected_route == 108 || selected_route == 10801)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10801)
                                    {
                                        return "true";
                                    }
                                }
                            }

                            ////////////////////////////////

                            //for Cox Bazar-Dhaka-109 subroute
                            if (selected_route == 109 || selected_route == 10901 || selected_route == 10903)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10901)
                                    {
                                        if (selected_route == 109)
                                        {
                                            return "true";
                                        }
                                        return "false";
                                    }
                                }

                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 10903)
                                    {
                                        if (selected_route == 109)
                                        {
                                            return "true";
                                        }
                                        return "false";
                                    }
                                }
                            }

                            ////////////////////////////////

                            //for Dhaka-Kolkata(Bondar)-110 subroute
                            if (selected_route == 110 || selected_route == 11001 || selected_route == 11002)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 11001)
                                    {
                                        return "true";
                                    }
                                }

                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 11002)
                                    {
                                        if (seat_route_list[i] == 11001)
                                        {
                                            return "true";
                                        }
                                    }
                                }
                            }

                            ////////////////////////////////

                            //for Benapole-Dhaka-111 subroute
                            if (selected_route == 111 || selected_route == 11102)
                            {
                                for (int i = 0; i < dtzt.Rows.Count; i++)
                                {
                                    if (seat_route_list[i] == 11102)
                                    {
                                        return "true";
                                    }
                                }
                            }

                            ////////////////////////////////





                        }
                    }

                    return "false";
                }
                else //if subroute
                {

                    //check is there have any main route
                    for (int i = 0; i < dtzt.Rows.Count; i++)
                    {
                        if (Convert.ToString(seat_route_list[i]).Length == 3)
                        {
                            return "true";
                        }
                    }

                    //if there is no main route then 

                    //for chittagong-kolkata (border) subroute
                    if (selected_route == 106 || selected_route == 10601 || selected_route == 10602 || selected_route == 10603 || selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10602 || seat_route_list[i] == 10603)
                            {
                                return "true";
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10604 || seat_route_list[i] == 10605 || seat_route_list[i] == 10606)
                            {
                                if (selected_route == 10601)
                                {
                                    return "false";
                                }
                                if (selected_route == 10602 || selected_route == 10603 || selected_route == 106)
                                {
                                    for (int p = 0; p < dtzt.Rows.Count; p++)
                                    {
                                        if (seat_route_list[p] == 10601)
                                        {
                                            if (selected_route != 10604 || selected_route != 10605 || selected_route != 10606)
                                            {
                                                return "true";
                                            }

                                        }
                                    }
                                }
                                return "true";
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10601)
                            {
                                if (selected_route == 10604 || selected_route == 10605 || selected_route == 10606)
                                {
                                    return "false";
                                }
                                return "true";
                            }
                        }
                    }

                    ///////////////////////////////////////////////////////

                    //for Banapole-Chittagong-107 subroute
                    if (selected_route == 107 || selected_route == 10701 || selected_route == 10702 || selected_route == 10703 || selected_route == 10704 || selected_route == 10705)
                    {


                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10704)
                            {
                                return "true";
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10702 || seat_route_list[i] == 10703)
                            {
                                if (selected_route == 10705)
                                {
                                    return "false";
                                }
                                if (selected_route == 10704 || selected_route == 107)
                                {
                                    for (int p = 0; p < dtzt.Rows.Count; p++)
                                    {
                                        if (seat_route_list[p] == 10705)
                                        {
                                            if (selected_route != 10702 || selected_route != 10703)
                                            {
                                                return "true";
                                            }

                                        }
                                    }
                                }
                                return "true";
                            }
                        }
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10705)
                            {
                                if (selected_route == 10702 || selected_route == 10703)
                                {
                                    return "false";
                                }
                                return "true";
                            }
                        }
                    }

                    ///////////////////////////////////////

                    //for Dhaka-Cox Bazar-108 subroute
                    if (selected_route == 108 || selected_route == 10801)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10801)
                            {
                                return "true";
                            }
                        }
                    }

                    ////////////////////////////////

                    //for Cox Bazar-Dhaka-109 subroute
                    if (selected_route == 109 || selected_route == 10901 || selected_route == 10903)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10901)
                            {
                                if (selected_route == 109)
                                {
                                    return "true";
                                }
                                return "false";
                            }
                        }

                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 10903)
                            {
                                if (selected_route == 109)
                                {
                                    return "true";
                                }
                                return "false";
                            }
                        }
                    }

                    ////////////////////////////////

                    //for Dhaka-Kolkata(Bondar)-110 subroute
                    if (selected_route == 110 || selected_route == 11001 || selected_route == 11002)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 11001)
                            {
                                return "true";
                            }
                        }

                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 11002)
                            {
                                return "true";
                            }
                        }
                    }

                    ////////////////////////////////

                    //for Benapole-Dhaka-111 subroute
                    if (selected_route == 111 || selected_route == 11102)
                    {
                        for (int i = 0; i < dtzt.Rows.Count; i++)
                        {
                            if (seat_route_list[i] == 11102)
                            {
                                return "true";
                            }
                        }
                    }

                    ////////////////////////////////


                    ////selected route start and end point
                    //str = "select frt,trt from ztroute where srt=@xroute";

                    //string xroute1 = xroute2;

                    //SqlDataAdapter da10 = new SqlDataAdapter(str, conn1);

                    //da10.SelectCommand.Parameters.AddWithValue("@xroute", xroute1);
                    //dts.Reset();
                    //da10.Fill(dts, "tempzt");

                    //DataTable dttemp = new DataTable();
                    //dttemp = dts.Tables[0];

                    //string sel_rt_st_point = dttemp.Rows[0][0].ToString();
                    //string sel_rt_end_point = dttemp.Rows[0][1].ToString();
                    //////////////////////////////

                    //////check if there is have as like as start point in the seat route list

                    //for (int i = 0; i < dtzt.Rows.Count; i++)
                    //{
                    //    if (Convert.ToString(seat_route_list[i]).Length != 3)
                    //    {


                    //        str = "select frt from ztroute where srt=@xroute";

                    //        string xroute11 = Convert.ToString(seat_route_list[i]);

                    //        SqlDataAdapter da101 = new SqlDataAdapter(str, conn1);

                    //        da101.SelectCommand.Parameters.AddWithValue("@xroute", xroute11);
                    //        dts.Reset();
                    //        da101.Fill(dts, "tempzt");

                    //        DataTable dttemp1 = new DataTable();
                    //        dttemp1 = dts.Tables[0];

                    //        string seat_rt_st_point = dttemp1.Rows[0][0].ToString();
                    //        //string seat_rt_end_point = dttemp1.Rows[0][1].ToString();

                    //        if (Convert.ToInt32(seat_rt_st_point) == Convert.ToInt32(sel_rt_st_point))
                    //        {
                    //            return dtzt.Rows[i][0].ToString();
                    //        }


                    //    }
                    //}

                    //////check if there is have as like as end point in the seat route list

                    //for (int i = 0; i < dtzt.Rows.Count; i++)
                    //{
                    //    if (Convert.ToString(seat_route_list[i]).Length != 3)
                    //    {


                    //        str = "select trt from ztroute where srt=@xroute";

                    //        string xroute111 = Convert.ToString(seat_route_list[i]);

                    //        SqlDataAdapter da1011 = new SqlDataAdapter(str, conn1);

                    //        da1011.SelectCommand.Parameters.AddWithValue("@xroute", xroute111);
                    //        dts.Reset();
                    //        da1011.Fill(dts, "tempzt");

                    //        DataTable dttemp11 = new DataTable();
                    //        dttemp11 = dts.Tables[0];

                    //        string seat_rt_end_point = dttemp11.Rows[0][0].ToString();
                    //        //string seat_rt_end_point = dttemp1.Rows[0][1].ToString();

                    //        if (Convert.ToInt32(seat_rt_end_point) == Convert.ToInt32(sel_rt_end_point))
                    //        {
                    //            return dtzt.Rows[i][0].ToString();
                    //        }
                    //    }
                    //}


                    return "false";
                }


            }

            return res;

        }



        protected void treq_tick(object sender, EventArgs e)
        {
            try
            {
              

           
                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts11 = new DataSet();
                string xcanreq;
                string xapp;

                dts11.Reset();
                string str11 = "SELECT count(*) FROM ztcancelreq  WHERE xstatus='pending'";
                SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                da11.Fill(dts11, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts11.Tables[0];
                if (dtztcode.Rows[0][0].ToString() != "0")
                {
                     LinkButton1.ForeColor=System.Drawing.Color.Red;
                    xcanreq = dtztcode.Rows[0][0].ToString();
                }
                else
                {
                    LinkButton1.ForeColor=System.Drawing.Color.Blue;
                    xcanreq = "0";
                }

                dts11.Dispose();
                dtztcode.Dispose();
                da11.Dispose();
                conn11.Dispose();

                LinkButton1.Text="Cancel Ticket: " + xcanreq;

                SqlConnection conn111;
                conn111 = new SqlConnection(zglobal.constring);
                DataSet dts111 = new DataSet();


                dts111.Reset();
                string str111 = "SELECT count(*) FROM ztmanticapppen  WHERE xstatus='pending'";
                SqlDataAdapter da111 = new SqlDataAdapter(str111, conn111);
                da111.Fill(dts111, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode1 = new DataTable();
                dtztcode1 = dts111.Tables[0];
                if (dtztcode1.Rows[0][0].ToString() != "0")
                {
                    xapp = dtztcode1.Rows[0][0].ToString();
                    LinkButton2.ForeColor=System.Drawing.Color.Red;
                }
                else
                {
                    xapp = "0";
                     LinkButton2.ForeColor=System.Drawing.Color.Blue;
                }

                dts111.Dispose();
                dtztcode1.Dispose();
                da111.Dispose();
                conn111.Dispose();

                LinkButton2.Text= "Manual Ticket: " + xapp;
               

               
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }



        [WebMethod(EnableSession = true)]
        public static List<string> fnAutoFill(string cxdate2, string cxcoach2, string cxseat2, string cxnoofseat2, string xrouteid)
        {
            try
            {
                List<string> list = new List<string>();
                list.Add("");
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string str2 = "select xname from ztsaleh where convert(datetime, xcreatedt, 101)  BETWEEN (Getdate() - 6) AND Getdate()";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
                da2.Fill(dts2, "temp");
                DataTable supcode = new DataTable();
                supcode = dts2.Tables["temp"];

                if (supcode.Rows.Count > 0)
                {
                    foreach (DataRow row in supcode.Rows)
                    {
                        list.Add(row.ToString());
                    }
                }

                return list;
            }
            catch (Exception exp)
            {
                List<string> list = new List<string>();
                list.Add("");
                return list;
            }
        }

        protected void btnBooking_Click(object sender, EventArgs e)
        {

        }


    }
}