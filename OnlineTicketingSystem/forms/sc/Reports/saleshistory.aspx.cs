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
    public partial class saleshistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                xuser.Text = "";
                xfrom.Text = "";
                xto.Text = "";



                DateTime xfrom2 = Convert.ToDateTime(Request.QueryString["xfrom1"]).Date;
                DateTime xto2 = Convert.ToDateTime(Request.QueryString["xto1"]).Date;
                string xuser2 = Convert.ToString( HttpContext.Current.Session["curuser"]);
                string xloc2 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                xfrom.Text = xfrom2.ToString("dd MMM, yyyy");
                xto.Text = xto2.ToString("dd MMM, yyyy");
                //xuser.Text = xuser2.ToString();

                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string str2 = "select CONVERT(VARCHAR(11),xdate,106),xsdate,xcoach,xseat,xticket,xname,xphone,xaction,xnetamt,xdiscount from ztsalevw where xuser=@xuser and xloc=@xloc and xsolddt between @xfrom and @xto";

                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da2.SelectCommand.Parameters.AddWithValue("@xto", xto2);
                da2.SelectCommand.Parameters.AddWithValue("@xuser", xuser2);
                da2.SelectCommand.Parameters.AddWithValue("@xloc", xloc2);

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];

            

                passlist.Controls.Clear();

                passlist.Controls.Add(new LiteralControl(
                                                          "<tr>"
                                                          + "<td scope='col' class='mystyle228'><strong>Journey Date</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Issue Time</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Coach No</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Seat No</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Ticket No</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Passenger</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Mobile No</strong></td>"
                                                          
                                                          + "<td scope='col' class='mystyle228'><strong>Action</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Fare</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Discount</strong></td>"
                                                          + "</tr>"));

                if (dtztemp.Rows.Count > 0)
                {
                    string action = "";
                    for (int i = 0; i < dtztemp.Rows.Count; i++)
                    {

                        if (dtztemp.Rows[i][7].ToString() == "Canceled")
                        {
                            action = "can";
                        }
                        else
                        {
                            action = "sold";
                        }

                        passlist.Controls.Add(new LiteralControl("<tr>"));
                        for (int j = 0; j < dtztemp.Columns.Count; j++)
                        {

                            if (action == "can" && j == 8)
                            {
                                passlist.Controls.Add(new LiteralControl("<td>" + "("+dtztemp.Rows[i][j].ToString()+")"));
                            }
                            else
                            {
                                passlist.Controls.Add(new LiteralControl("<td>" + dtztemp.Rows[i][j].ToString()));
                            }
                            //dtztemp.Rows[i][j].ToString();
                            passlist.Controls.Add(new LiteralControl("</td>"));
                        }
                        passlist.Controls.Add(new LiteralControl("</tr>"));
                    }
                }

                //passlist.Controls.Add(new LiteralControl(""));

                dts2.Reset();

                str2 = "select xusername,xrole from ztuser where xuser=@xuser";

                SqlDataAdapter da222 = new SqlDataAdapter(str2, conn2);

               
                da222.SelectCommand.Parameters.AddWithValue("@xuser", xuser2);

                da222.Fill(dts2, "temp");
                DataTable dtztemp22 = new DataTable();
                dtztemp22 = dts2.Tables["temp"];

                xuser.Text = dtztemp22.Rows[0][0].ToString();


                dts2.Reset();

                //str2 = "SELECT top 1 ((select COALESCE(SUM(xnetamt),0) " +
                //           " from ztsalevw where xuser=a.xuser and xloc=a.xloc and  xaction='Sold' and xsolddt between @xfrom and @xto) - (select COALESCE(SUM(xnetamt),0) from ztsalevw " +
                //           " where xuser=a.xuser and xloc=a.xloc and  xaction='Canceled' and xsolddt between @xfrom and @xto)) as income " +
                //           " FROM ztsalevw as a where xuser=@xuser and xloc=@xloc and xsolddt between @xfrom and @xto";

                str2 = "select " +
                        " ((select COALESCE (sum(xnetamt), 0) from ztsalevw where xaction='Sold' and xsolddt between @xfrom and @xto and xuser=@xuser and xloc=@xloc) " +
                        " - (select COALESCE (sum(xnetamt), 0) from ztsalevw where xaction='Canceled' and xsolddt between @xfrom and @xto and xuser=@xuser and xloc=@xloc)) as b";


                SqlDataAdapter da22 = new SqlDataAdapter(str2, conn2);


                da22.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da22.SelectCommand.Parameters.AddWithValue("@xto", xto2);
                da22.SelectCommand.Parameters.AddWithValue("@xuser", xuser2);
                da22.SelectCommand.Parameters.AddWithValue("@xloc", xloc2);

                da22.Fill(dts2, "temp");
                DataTable dtztemp2 = new DataTable();
                dtztemp2 = dts2.Tables["temp"];


                double amount = Convert.ToDouble(dtztemp2.Rows[0][0].ToString());

                xtotal.Text = Convert.ToString(amount);
               

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}