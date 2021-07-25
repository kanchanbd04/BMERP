using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace OnlineTicketingSystem.forms.sc.Reports
{
    public partial class saledtl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime xfrom2 = Convert.ToDateTime(Request.QueryString["xfrom1"]).Date;
                DateTime xto2 = Convert.ToDateTime(Request.QueryString["xto1"]).Date;
                //string xuser2 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //string xloc2 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                string xdtype2 = Convert.ToString(Request.QueryString["xdtype1"]);
                string xrcri2 = Convert.ToString(Request.QueryString["xrcri"]);
                if (xrcri2 == "ondate")
                {
                    Label1.Text = "Ondate";
                }
                else if (xrcri2 == "advanced")
                {
                    Label1.Text = "Advanced";
                }
                else
                {
                    Label1.Text = "Total";
                }
                xfrom.Text = xfrom2.ToString("dd MMM, yyyy");
                xto.Text = xto2.ToString("dd MMM, yyyy");

                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string str2;

                if (xrcri2 == "ondate")
                {
                    str2 = "SELECT a.xuser, " +
                                  " (select xusername from ztuser where xuser=a.xuser) as xuser,a.xloc, " +
                                  " (select count(xnetamt) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and xaction='Sold' and xsolddt between @xfrom and @xto and xsolddt=xdate) as sold, " +
                                  " (select count(xnetamt) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xsolddt=xdate) as canceled, " +
                                  " (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto and xsolddt=xdate) as total, " +
                                  " (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xsolddt=xdate) as 'return', " +

                                  " ((select COALESCE(SUM(xdiscount),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto and xsolddt=xdate) - (select COALESCE(SUM(xdiscount),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xsolddt=xdate)) as discount, " +


                                  " ((select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto and xsolddt=xdate) - (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xsolddt=xdate)) as income " +

                                  " FROM ztsalevw as a " +
                                  " where xsolddt between @xfrom and @xto and xsolddt=xdate" +
                                  " GROUP BY xuser,xloc";
                }
                else if (xrcri2 == "advanced")
                {
                    str2 = "SELECT a.xuser, " +
                                   " (select xusername from ztuser where xuser=a.xuser) as xuser,a.xloc, " +
                                  " (select count(xnetamt) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) as sold, " +
                                  " (select count(xnetamt) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt) as canceled, " +
                                  " (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) as total, " +
                                  " (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt) as 'return', " +

                                  " ((select COALESCE(SUM(xdiscount),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) - (select COALESCE(SUM(xdiscount),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt)) as discount, " +


                                  " ((select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) - (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt)) as income " +

                                  " FROM ztsalevw as a " +
                                  " where xsolddt between @xfrom and @xto and xdate>xsolddt " +
                                  " GROUP BY xuser,xloc";
                }
                else
                {
                    str2 = "SELECT a.xuser, " +
                                  " (select xusername from ztuser where xuser=a.xuser) as xuser,a.xloc, " +
                                  " (select count(xnetamt) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and xaction='Sold' and xsolddt between @xfrom and @xto) as sold, " +
                                  " (select count(xnetamt) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto) as canceled, " +
                                  " (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto) as total, " +
                                  " (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto) as 'return', " +

                                  " ((select COALESCE(SUM(xdiscount),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto) - (select COALESCE(SUM(xdiscount),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto)) as discount, " +


                                  " ((select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto) - (select COALESCE(SUM(xnetamt),0) " +
                                  " from ztsalevw " +
                                  " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto)) as income " +

                                  " FROM ztsalevw as a " +
                                  " where xsolddt between @xfrom and @xto " +
                                  " GROUP BY xuser,xloc";
                }

                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da2.SelectCommand.Parameters.AddWithValue("@xto", xto2);
                //da2.SelectCommand.Parameters.AddWithValue("@xuser", xuser2);
                //da2.SelectCommand.Parameters.AddWithValue("@xloc", xloc2);

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];



                passlist.Controls.Clear();

                passlist.Controls.Add(new LiteralControl(
                                                          "<tr>"
                                                          + "<td scope='col' class='mystyle228'><strong>Employee</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Counter</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Sold</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Canceled</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Total</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Return</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Discount</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Income</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Remarks</strong></td>"
                                                         
                                                          + "</tr>"));

                if (dtztemp.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dtztemp.Rows.Count; i++)
                    {

                        

                        passlist.Controls.Add(new LiteralControl("<tr>"));
                        for (int j = 1; j < dtztemp.Columns.Count; j++)
                        {

                            
                            passlist.Controls.Add(new LiteralControl("<td>" + dtztemp.Rows[i][j].ToString()));
                            
                           
                            passlist.Controls.Add(new LiteralControl("</td>"));
                            //passlist.Controls.Add(new LiteralControl("<a id='showdtl' href='ztpermis.aspx?xuser=" + +">Details</a>"));
                        }
                        passlist.Controls.Add(new LiteralControl("<td align='center'><a id='showdtl'href='salehis2.aspx?xuser1=" + dtztemp.Rows[i][0].ToString() + "&xloc1=" + dtztemp.Rows[i][2].ToString()  + "&xrcri1="+ xrcri2 +"&xfrom1="+ xfrom2 +"&xto1="+ xto2 +"' target='_blank'>Details</a></td>"));
                        passlist.Controls.Add(new LiteralControl("</tr>"));
                    }
                }


                dts2.Reset();



                if (xrcri2 == "ondate")
                {
                    str2 = "SELECT TOP 1 " +

                                 " (select count(xnetamt) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto and xsolddt=xdate) as sold, " +
                                 " (select count(xnetamt) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled'  and xsolddt between @xfrom and @xto and xsolddt=xdate) as canceled, " +
                                 " (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold'  and xsolddt between @xfrom and @xto and xsolddt=xdate) as total, " +
                                 " (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto and xsolddt=xdate) as 'return', " +

                                 " ((select COALESCE(SUM(xdiscount),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto and xsolddt=xdate) - (select COALESCE(SUM(xdiscount),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto and xsolddt=xdate)) as discount, " +


                                 " ((select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto and xsolddt=xdate) - (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto and xsolddt=xdate)) as income " +

                                 " FROM ztsalevw as a " +
                                 " where xsolddt between @xfrom and @xto and xsolddt=xdate ";
                }
                else if (xrcri2 == "advanced")
                {
                    str2 = "SELECT TOP 1 " +

                                 " (select count(xnetamt) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) as sold, " +
                                 " (select count(xnetamt) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt) as canceled, " +
                                 " (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) as total, " +
                                 " (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt) as 'return', " +

                                 " ((select COALESCE(SUM(xdiscount),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) - (select COALESCE(SUM(xdiscount),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt)) as discount, " +


                                 " ((select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto and xdate>xsolddt) - (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto and xdate>xsolddt)) as income " +

                                  " FROM ztsalevw as a " +
                                  " where xsolddt between @xfrom and @xto and xdate>xsolddt ";
                }
                else
                {
                    str2 = "SELECT TOP 1 " +

                                " (select count(xnetamt) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto) as sold, " +
                                 " (select count(xnetamt) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto) as canceled, " +
                                 " (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto) as total, " +
                                 " (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto) as 'return', " +

                                 " ((select COALESCE(SUM(xdiscount),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto) - (select COALESCE(SUM(xdiscount),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto)) as discount, " +


                                 " ((select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Sold' and xsolddt between @xfrom and @xto) - (select COALESCE(SUM(xnetamt),0) " +
                                 " from ztsalevw " +
                                 " where xaction='Canceled' and xsolddt between @xfrom and @xto)) as income " +

                                  " FROM ztsalevw as a " +
                                  " where xsolddt between @xfrom and @xto ";
                }

                SqlDataAdapter da222 = new SqlDataAdapter(str2, conn2);

                da222.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da222.SelectCommand.Parameters.AddWithValue("@xto", xto2);
              

                da222.Fill(dts2, "temp");
                DataTable dtztemp22 = new DataTable();
                dtztemp22 = dts2.Tables["temp"];

                xsold.Text = dtztemp22.Rows[0][0].ToString();
                xcan.Text = dtztemp22.Rows[0][1].ToString();
                xtotal.Text = dtztemp22.Rows[0][2].ToString();
                xreturn.Text = dtztemp22.Rows[0][3].ToString();
                xdiscount.Text = dtztemp22.Rows[0][4].ToString();
                xincome.Text = dtztemp22.Rows[0][5].ToString();


            }
            catch(Exception exp)
            {
                Response.Write(exp.Message);
            }

        }
    }
}