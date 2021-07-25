using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using OnlineTicketingSystem.forms.sc;


namespace OnlineTicketingSystem
{
    /// <summary>
    /// Summary description for edusoft
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class edusoft : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string StudentInformation(string zid, string xstdid, string xsession)
        {

            int _zid = Convert.ToInt32(zid);
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = "SELECT * FROM amstudentvw WHERE zid=@zid AND xstdid=@xstdid AND xsession=@xsession";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dtstudent = new DataTable();
                    dtstudent = dts1.Tables[0];


                    if (dtstudent.Rows.Count > 0)
                    {

                        student.xsession = dtstudent.Rows[0]["xsession"].ToString();
                        student.xclass = dtstudent.Rows[0]["xclass"].ToString();
                        student.xsection = dtstudent.Rows[0]["xsection"].ToString();
                        student.xgroup = dtstudent.Rows[0]["xgroup"].ToString();
                        student.xstdid = dtstudent.Rows[0]["xstdid"].ToString();
                        student.xname = dtstudent.Rows[0]["xname"].ToString();
                        student.xmname = dtstudent.Rows[0]["xmname"].ToString();
                        student.xfname = dtstudent.Rows[0]["xfname"].ToString();
                        student.xcellno = dtstudent.Rows[0]["xcellno"].ToString();
                        student.xcellno1 = dtstudent.Rows[0]["xcellno1"].ToString();
                        student.xblood = dtstudent.Rows[0]["xblood"].ToString();
                        student.xdob = dtstudent.Rows[0]["xdob"].ToString();
                        student.xexamdate = dtstudent.Rows[0]["xexamdate"].ToString();
                        student.xexamvenue = dtstudent.Rows[0]["xexamvenue"].ToString();
                        student.xgender = dtstudent.Rows[0]["xgender"].ToString();
                    }
                    else
                    {

                        student.xsession = String.Empty;
                        student.xclass = String.Empty;
                        student.xsection = String.Empty;
                        student.xgroup = String.Empty;
                        student.xstdid = String.Empty;
                        student.xname = zglobal.fnGetValue("xname", "amadmis",
                        "zid=" + _zid + " AND xstdid='" + xstdid + "' ");
                        student.xmname = String.Empty;
                        student.xfname = String.Empty;
                        student.xcellno = String.Empty;
                        student.xcellno1 = String.Empty;
                        student.xblood = String.Empty;
                        student.xdob = String.Empty;
                        student.xexamdate = String.Empty;
                        student.xexamvenue = String.Empty;
                        student.xgender = String.Empty;
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(student);
                }
            }

        }

        [WebMethod]
        public string StudentInformationAccounts(string zid, string xstdid, string xsession, string xcdate, string xtfccode)
        {

            int _zid = Convert.ToInt32(zid);
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = "SELECT * FROM amstudentvwextacc WHERE zid=@zid AND xstdid=@xstdid AND xsession=@xsession AND zactiveacc=1";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dtstudent = new DataTable();
                    dtstudent = dts1.Tables[0];


                    if (dtstudent.Rows.Count > 0)
                    {

                        student.xsession = dtstudent.Rows[0]["xsession"].ToString();
                        student.xclass = dtstudent.Rows[0]["xclass"].ToString();
                        student.xsection = dtstudent.Rows[0]["xsection"].ToString();
                        student.xgroup = dtstudent.Rows[0]["xgroup"].ToString();
                        student.xstdid = dtstudent.Rows[0]["xstdid"].ToString();
                        student.xname = dtstudent.Rows[0]["xname"].ToString();
                        student.xmname = dtstudent.Rows[0]["xmname"].ToString();
                        student.xfname = dtstudent.Rows[0]["xfname"].ToString();
                        student.xcellno = dtstudent.Rows[0]["xcellno"].ToString();
                        student.xcellno1 = dtstudent.Rows[0]["xcellno1"].ToString();
                        student.xblood = dtstudent.Rows[0]["xblood"].ToString();
                        student.xdob = dtstudent.Rows[0]["xdob"].ToString();
                        student.xexamdate = dtstudent.Rows[0]["xexamdate"].ToString();
                        student.xexamvenue = dtstudent.Rows[0]["xexamvenue"].ToString();
                        student.xgender = dtstudent.Rows[0]["xgender"].ToString();

                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts11 = new DataSet())
                            {
                                string[] date = new string[2];
                                date = xcdate.Split('-');

                                int year = Int32.Parse(date[1]);
                                int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                                DateTime xdate1 = new DateTime(year, month, 1);

                                string query11 = @"SELECT  xamount FROM amtfcconfig
                                            WHERE zid=@zid AND zactive=1  and  coalesce(xclass,'')=@xclass and  coalesce(xsrow,'')=''
                                            AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfig as a where a.zid=amtfcconfig.zid AND zactive=1 
                                            and coalesce(xclass,'')=@xclass and  coalesce(xsrow,'')='' and a.xtfccode=amtfcconfig.xtfccode and a.xeffdate<= @xdate ) and xtfccode=@xtfccode";
                                SqlDataAdapter da11 = new SqlDataAdapter(query11, conn);
                                da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da11.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                                da11.SelectCommand.Parameters.AddWithValue("@xsrow", dtstudent.Rows[0]["xrow"].ToString());
                                da11.SelectCommand.Parameters.AddWithValue("@xtfccode", xtfccode);
                                da11.SelectCommand.Parameters.AddWithValue("@xclass", dtstudent.Rows[0]["xclass"].ToString());
                                da11.Fill(dts11, "tblamadmisd");

                                DataTable amexamd = dts11.Tables[0];

                                if (amexamd.Rows.Count > 0)
                                {
                                    student.xamount = Convert.ToDecimal(amexamd.Rows[0]["xamount"].ToString());
                                }
                                else
                                {
                                    student.xamount = 0;
                                }
                            }
                        }

                    }
                    else
                    {

                        student.xsession = String.Empty;
                        student.xclass = String.Empty;
                        student.xsection = String.Empty;
                        student.xgroup = String.Empty;
                        student.xstdid = String.Empty;
                        student.xname = zglobal.fnGetValue("xname", "amadmis",
                        "zid=" + _zid + " AND xstdid='" + xstdid + "' ");
                        student.xmname = String.Empty;
                        student.xfname = String.Empty;
                        student.xcellno = String.Empty;
                        student.xcellno1 = String.Empty;
                        student.xblood = String.Empty;
                        student.xdob = String.Empty;
                        student.xexamdate = String.Empty;
                        student.xexamvenue = String.Empty;
                        student.xgender = String.Empty;
                        student.xamount = 0;
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(student);
                }
            }

        }

        [WebMethod]
        public string StudentInformationAccounts1(string zid, string xstdid, string xsession, string xcdate, string xtfccode)
        {

            int _zid = Convert.ToInt32(zid);
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    //string query = "SELECT * FROM amstudentvwext1 WHERE zid=@zid AND xstdid=@xstdid AND xsession=@xsession AND zactiveacc=1";
                    string query = "SELECT * FROM amstudentvwext1 WHERE zid=@zid AND xstdid=@xstdid AND xsession=@xsession ";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dtstudent = new DataTable();
                    dtstudent = dts1.Tables[0];


                    if (dtstudent.Rows.Count > 0)
                    {

                        student.xsession = dtstudent.Rows[0]["xsession"].ToString();
                        student.xclass = dtstudent.Rows[0]["xclass"].ToString();
                        student.xsection = dtstudent.Rows[0]["xsection"].ToString();
                        student.xgroup = dtstudent.Rows[0]["xgroup"].ToString();
                        student.xstdid = dtstudent.Rows[0]["xstdid"].ToString();
                        student.xname = dtstudent.Rows[0]["xname"].ToString();
                        student.xmname = dtstudent.Rows[0]["xmname"].ToString();
                        student.xfname = dtstudent.Rows[0]["xfname"].ToString();
                        student.xcellno = dtstudent.Rows[0]["xcellno"].ToString();
                        student.xcellno1 = dtstudent.Rows[0]["xcellno1"].ToString();
                        student.xblood = dtstudent.Rows[0]["xblood"].ToString();
                        student.xdob = dtstudent.Rows[0]["xdob"].ToString();
                        student.xexamdate = dtstudent.Rows[0]["xexamdate"].ToString();
                        student.xexamvenue = dtstudent.Rows[0]["xexamvenue"].ToString();
                        student.xgender = dtstudent.Rows[0]["xgender"].ToString();

                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts11 = new DataSet())
                            {
                                string[] date = new string[2];
                                date = xcdate.Split('-');

                                int year = Int32.Parse(date[1]);
                                int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
                                DateTime xdate1 = new DateTime(year, month, 1);

                                string query11 = @"SELECT  xamount FROM amtfcconfig
                                            WHERE zid=@zid AND zactive=1  and  coalesce(xclass,'')=@xclass and  coalesce(xsrow,'')=''
                                            AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfig as a where a.zid=amtfcconfig.zid AND zactive=1 
                                            and coalesce(xclass,'')=@xclass and  coalesce(xsrow,'')='' and a.xtfccode=amtfcconfig.xtfccode and a.xeffdate<= @xdate ) and xtfccode=@xtfccode";
                                SqlDataAdapter da11 = new SqlDataAdapter(query11, conn);
                                da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da11.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                                da11.SelectCommand.Parameters.AddWithValue("@xsrow", dtstudent.Rows[0]["xrow"].ToString());
                                da11.SelectCommand.Parameters.AddWithValue("@xtfccode", xtfccode);
                                da11.SelectCommand.Parameters.AddWithValue("@xclass", dtstudent.Rows[0]["xclass"].ToString());
                                da11.Fill(dts11, "tblamadmisd");

                                DataTable amexamd = dts11.Tables[0];

                                if (amexamd.Rows.Count > 0)
                                {
                                    student.xamount = Convert.ToDecimal(amexamd.Rows[0]["xamount"].ToString());
                                }
                                else
                                {
                                    student.xamount = 0;
                                }
                            }
                        }

                    }
                    else
                    {

                        student.xsession = String.Empty;
                        student.xclass = String.Empty;
                        student.xsection = String.Empty;
                        student.xgroup = String.Empty;
                        student.xstdid = String.Empty;
                        student.xname = zglobal.fnGetValue("xname", "amadmis",
                        "zid=" + _zid + " AND xstdid='" + xstdid + "' ");
                        student.xmname = String.Empty;
                        student.xfname = String.Empty;
                        student.xcellno = String.Empty;
                        student.xcellno1 = String.Empty;
                        student.xblood = String.Empty;
                        student.xdob = String.Empty;
                        student.xexamdate = String.Empty;
                        student.xexamvenue = String.Empty;
                        student.xgender = String.Empty;
                        student.xamount = 0;
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(student);
                }
            }

        }

        [WebMethod]
        public string ItemInfo1(string zid, string xitem)
        {

            int _zid = Convert.ToInt32(zid);
            ItemInfo item = new ItemInfo();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = "SELECT xdesc,xunitiss,xunitpur,xitem,coalesce(xcfiss,1) as xcfiss,coalesce(xcfpur,1) as xcfpur " +
                                   "FROM msitem WHERE zid=@zid AND xitem=@xitem";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xitem", xitem);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dtstudent = new DataTable();
                    dtstudent = dts1.Tables[0];


                    if (dtstudent.Rows.Count > 0)
                    {
                        item.xitem = dtstudent.Rows[0]["xitem"].ToString();
                        item.xdesc = dtstudent.Rows[0]["xdesc"].ToString();
                        item.xunitpur = dtstudent.Rows[0]["xunitpur"].ToString();
                        item.xunitiss = dtstudent.Rows[0]["xunitiss"].ToString();
                        item.xcfiss = Convert.ToDecimal(dtstudent.Rows[0]["xcfiss"]);
                        item.xcfpur = Convert.ToDecimal(dtstudent.Rows[0]["xcfpur"]);
                    }
                    else
                    {
                        item.xitem = String.Empty;
                        item.xdesc = String.Empty;
                        item.xunitpur = String.Empty;
                        item.xunitiss = String.Empty;
                        item.xcfiss = 1;
                        item.xcfpur = 1;
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(item);
                }
            }

        }

        [WebMethod]
        public string ItemInfo(string zid, string xitem, string xwh)
        {

            int _zid = Convert.ToInt32(zid);
            ItemInfo item = new ItemInfo();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = "SELECT xdesc,xunitiss,xunitpur,xitem,coalesce(xcfiss,1) as xcfiss,coalesce(xcfpur,1) as xcfpur, " +
                                   "coalesce((select sum(xqty*xsign) from imtrn where zid=@zid and xwh=@xwh and xitem=@xitem ),0) as xstock " +
                                   "FROM msitem WHERE zid=@zid AND xitem=@xitem";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xitem", xitem);
                    da1.SelectCommand.Parameters.AddWithValue("@xwh", xwh);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dtstudent = new DataTable();
                    dtstudent = dts1.Tables[0];


                    if (dtstudent.Rows.Count > 0)
                    {
                        item.xitem = dtstudent.Rows[0]["xitem"].ToString();
                        item.xdesc = dtstudent.Rows[0]["xdesc"].ToString();
                        item.xunitpur = dtstudent.Rows[0]["xunitpur"].ToString();
                        item.xunitiss = dtstudent.Rows[0]["xunitiss"].ToString();
                        item.xcfiss = Convert.ToDecimal(dtstudent.Rows[0]["xcfiss"]);
                        item.xcfpur = Convert.ToDecimal(dtstudent.Rows[0]["xcfpur"]);
                        item.xstock = Convert.ToDecimal(dtstudent.Rows[0]["xstock"]);
                    }
                    else
                    {
                        item.xitem = String.Empty;
                        item.xdesc = String.Empty;
                        item.xunitpur = String.Empty;
                        item.xunitiss = String.Empty;
                        item.xcfiss = 1;
                        item.xcfpur = 1;
                        item.xstock = 0;
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(item);
                }
            }

        }

        [WebMethod]
        public string TFCCodeInfo(string zid, string xrow, string xclass, string xgroup, string xstdid, string xeffdate, string xtfccode)
        {
            //try
            //{
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            int _zid = Convert.ToInt32(zid);
            int xrow1 = xrow != "" ? Convert.ToInt32(xrow) : 0;

            string[] date = new string[2];
            if (xeffdate == "")
            {
                date[0] = "Jan";
                date[1] = "1800";
            }
            else
            {
                date = xeffdate.Split('-');
            }

            int year = Int32.Parse(date[1]);
            int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
            DateTime xeffdate1 = new DateTime(year, month, 1);

            TFCInfo tfcinfo = new TFCInfo();
            string xsrow = zglobal.fnGetValue("xrow", "amadmis",
                      "zid=" + _zid + " AND xstdid='" + xstdid + "'");

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = "";

                    if (xrow1 != 0)
                    {
                        query = " SELECT xtfccode1 as xtfccode,xdescdet,xamtdue as xnettotal1 FROM amtfcduevw WHERE zid=@zid AND xrow=@xrow and xtfccode1=@xtfccode";
                    }
                    else
                    {
                        query = zglobal.xtfcdefault2;
                    }
                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
                    da1.SelectCommand.Parameters.AddWithValue("@xtfccode", xtfccode);
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass);
                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup);
                    da1.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow);
                    da1.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dttfc = new DataTable();
                    dttfc = dts1.Tables[0];


                    if (dttfc.Rows.Count > 0)
                    {
                        //return "success" + "|" + dtamexamd.Rows[0]["xremarks"].ToString();
                        tfcinfo.xtfccode = dttfc.Rows[0]["xtfccode"].ToString();
                        tfcinfo.xdescdet = dttfc.Rows[0]["xdescdet"].ToString();
                        tfcinfo.xamount = dttfc.Rows[0]["xnettotal1"].ToString();

                    }
                    else
                    {
                        //return "nodata";
                        string xdescdet1 = zglobal.fnGetValue("xdescdet", "mscodesam",
                            "zid=" + _zid + " AND xtype='TFC Code' AND xcode='" + xtfccode + "'");
                        if (xdescdet1 == "")
                        {
                            tfcinfo.xtfccode = String.Empty;
                            tfcinfo.xdescdet = String.Empty;
                            tfcinfo.xamount = String.Empty;
                        }
                        else
                        {
                            tfcinfo.xtfccode = xtfccode;
                            tfcinfo.xdescdet = zglobal.fnGetValue("xdescdet", "mscodesam",
                          "zid=" + _zid + " AND xtype='TFC Code' AND xcode='" + xtfccode + "'");
                            tfcinfo.xamount = String.Empty;
                        }

                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(tfcinfo);
                }
            }

            //return student;

            //}
            //catch (Exception exp)
            //{
            //    //return exp.Message;
            //}
        }

        [WebMethod]
        public string TFCCodeInfo1(string zid, string xtfccode)
        {

            int _zid = Convert.ToInt32(zid);



            TFCInfo tfcinfo = new TFCInfo();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = " SELECT xdescdet FROM mscodesam WHERE zid=@zid AND xtype='TFC Code' and xcode=@xcode";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xcode", xtfccode);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dttfc = new DataTable();
                    dttfc = dts1.Tables[0];


                    if (dttfc.Rows.Count > 0)
                    {
                        tfcinfo.xtfccode = xtfccode;
                        tfcinfo.xdescdet = dttfc.Rows[0]["xdescdet"].ToString();

                    }
                    else
                    {
                        tfcinfo.xtfccode = String.Empty;
                        tfcinfo.xdescdet = String.Empty;
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(tfcinfo);
                }
            }


        }

        [WebMethod]
        public string TFCCodeInfo2(string zid, string xrow, string xclass, string xgroup, string xstdid, string xeffdate, string xtfccode, string xsession)
        {

            int _zid = Convert.ToInt32(zid);
            int xrow1 = xrow != "" ? Convert.ToInt32(xrow) : 0;

            string[] date = new string[2];
            if (xeffdate == "")
            {
                date[0] = "Jan";
                date[1] = "1800";
            }
            else
            {
                date = xeffdate.Split('-');
            }

            int year = Int32.Parse(date[1]);
            int month = Int32.Parse(zgetvalue.GetMonthNo(date[0]));
            DateTime xeffdate1 = new DateTime(year, month, 1);

            TFCInfo tfcinfo = new TFCInfo();
            string xsrow = zglobal.fnGetValue("xrow", "amadmis",
                      "zid=" + _zid + " AND xstdid='" + xstdid + "'");

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = "";

                    if (xrow1 != 0)
                    {
                        query = " SELECT xtfccode,xdescdet, xamount as xnettotal1, xreceived, " +
                                "(select xdue from amtfcduecalvw1 where zid=amtfcvw.zid and xsession=amtfcvw.xsession and xsrow=amtfcvw.xsrow and xtfccode=amtfcvw.xtfccode) as xdue " +
                                "FROM amtfcvw WHERE zid=@zid AND xrow=@xrow and xtfccode=@xtfccode";
                    }
                    else
                    {
                        query = zglobal.xtfcdefault3;
                    }
                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
                    da1.SelectCommand.Parameters.AddWithValue("@xtfccode", xtfccode);
                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass);
                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup);
                    da1.SelectCommand.Parameters.AddWithValue("@xsrow", xsrow);
                    da1.SelectCommand.Parameters.AddWithValue("@xeffdate", xeffdate1);
                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dttfc = new DataTable();
                    dttfc = dts1.Tables[0];


                    if (dttfc.Rows.Count > 0)
                    {
                        tfcinfo.xtfccode = dttfc.Rows[0]["xtfccode"].ToString();
                        tfcinfo.xdescdet = dttfc.Rows[0]["xdescdet"].ToString();
                        tfcinfo.xdamount = dttfc.Rows[0]["xnettotal1"].ToString();
                        tfcinfo.xdue = dttfc.Rows[0]["xdue"].ToString();
                        if (xrow1 != 0)
                        {
                            tfcinfo.xamount = dttfc.Rows[0]["xreceived"].ToString();
                        }
                        else
                        {
                            tfcinfo.xamount = "0";
                        }

                    }
                    else
                    {
                        string xdescdet1 = zglobal.fnGetValue("xdescdet", "mscodesam",
                            "zid=" + _zid + " AND xtype='TFC Code' AND xcode='" + xtfccode + "'");
                        if (xdescdet1 == "")
                        {
                            tfcinfo.xtfccode = String.Empty;
                            tfcinfo.xdescdet = String.Empty;
                            tfcinfo.xamount = String.Empty;
                            tfcinfo.xdamount = String.Empty;
                            tfcinfo.xdue = String.Empty;
                        }
                        else
                        {
                            tfcinfo.xtfccode = xtfccode;
                            tfcinfo.xdescdet = zglobal.fnGetValue("xdescdet", "mscodesam",
                          "zid=" + _zid + " AND xtype='TFC Code' AND xcode='" + xtfccode + "'");
                            tfcinfo.xamount = "0";
                            tfcinfo.xdamount = String.Empty;
                            tfcinfo.xdue = String.Empty;
                        }

                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(tfcinfo);
                }
            }

        }


        [WebMethod]
        public static string GetClasswiseNumStudent(string xsession)
        {

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT xcodealt,xclass, xprevious, xreadmis, xnew, xtotal " +
                         "FROM amnumstudentvw1  " +
                         "WHERE zid=@zid AND xsession = @xsession " +
                         "ORDER BY xcodealt ";

                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession);
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds.GetXml();
                    }

                }
            }
        }


        [WebMethod]
        public static string GetClasswiseNumStudent1(string xsession)
        {

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT xprevious, xreadmis, xnew, xtotal " +
                         "FROM amnumstudentvw2  " +
                         "WHERE zid=@zid AND xsession = @xsession ";

                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession);
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds.GetXml();
                    }

                }
            }
        }

        [WebMethod]
        public string BookInfo(string zid, string xlbord)
        {

            int _zid = Convert.ToInt32(zid);
            BookInfo lbord = new BookInfo();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    string query = "SELECT xlbord,xlbtitle,coalesce(xlbstatus,'') as xlbstatus  " +
                                   "FROM lbbook WHERE zid=@zid AND xlbord=@xlbord";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da1.SelectCommand.Parameters.AddWithValue("@xlbord", xlbord);

                    da1.Fill(dts1, "tempztcode");
                    DataTable dtstudent = new DataTable();
                    dtstudent = dts1.Tables[0];


                    if (dtstudent.Rows.Count > 0)
                    {
                        lbord.xlbtitle = dtstudent.Rows[0]["xlbtitle"].ToString();
                        lbord.xlbstatus = dtstudent.Rows[0]["xlbstatus"].ToString();
                    }
                    else
                    {
                        lbord.xlbtitle = String.Empty;
                        lbord.xlbstatus = String.Empty;
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    //Context.Response.Write(js.Serialize(student));
                    return js.Serialize(lbord);
                }
            }

        }

        [WebMethod]
        public string ListStudentGrade(string zid, string xsession, string xterm, string xclass, string xgroup, string xsubject, string xpaper, string xgrade)
        {

            int _zid = Convert.ToInt32(zid);
            Student std = new Student();

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {

                SqlCommand cmd = new SqlCommand("amgradesp2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@zid", _zid);
                cmd.Parameters.AddWithValue("@xsession", xsession);
                cmd.Parameters.AddWithValue("@xclass", xclass);
                cmd.Parameters.AddWithValue("@xterm", xterm);
                cmd.Parameters.AddWithValue("@xgroup", xgroup);
                cmd.Parameters.AddWithValue("@xsubject", xsubject);
                cmd.Parameters.AddWithValue("@xpaper", xpaper);
                cmd.Parameters.AddWithValue("@xgrade", xgrade);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    std.xstdid = reader["xstdid"].ToString();
                    std.xname = reader["xname"].ToString();

                }

                con.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                //Context.Response.Write(js.Serialize(student));
                return js.Serialize(std);

            }

        }


    }
}
