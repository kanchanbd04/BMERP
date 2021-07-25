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
    public partial class passengerlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                xdate.Text="";

                string xdate2 = Request.QueryString["xdate1"];
                string xcoach2 = Request.QueryString["xcoach1"];
                xdate.Text = xdate2.ToString();
                xcoach.Text = xcoach2.ToString();

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

                xbus.Text = dtztemp.Rows[0][0].ToString();
                xdriver.Text = dtztemp.Rows[0][1].ToString();
                xguide.Text = dtztemp.Rows[0][2].ToString();

                /* Retrive route and time from ztcoach */

                dts2.Reset();
                
                str2 = "select (select xmf + '-' + xmt from ztrtm where xmrid=ztcoach.xmrid) as xroute, (xmrtimeh +':'+ xmrtimem +' '+xmrtimei) as xtime from ztcoach where xcoachno=@xcoachno";

                SqlDataAdapter da3 = new SqlDataAdapter(str2,conn2);
                
                da3.SelectCommand.Parameters.AddWithValue("@xcoachno",xcoach2);
                da3.Fill(dts2, "temp1");

                dtztemp.Reset();
                dtztemp = dts2.Tables["temp1"];

                xroute.Text = dtztemp.Rows[0][0].ToString();
                xtime.Text = dtztemp.Rows[0][1].ToString();

                /* Build the passenger list */

                //str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select trt from ztroute where srt=ztsaled.xroute) as xroute,ztsaleh.xboarding,(select xusername from ztuser where ztuser.xuser=ztsaleh.xsoldby) as xsoldby from ztsaleh " +
                //       " inner join ztsaled on ztsaleh.xid=ztsaled.xid where ztsaled.xdate=@xdate " +
                //       " and ztsaled.xcoach=@xcoach and xstatus in ('sold','forsale','mansale') ";

                //str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select trt from ztroute where srt=ztsaled.xroute) as xroute,ztsaleh.xboarding,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser from ztsaleh " +
                //      " inner join ztsaled on ztsaleh.xid=ztsaled.xid where ztsaled.xdate=@xdate " +
                //      " and ztsaled.xcoach=@xcoach and xstatus IN ('sold','forsale','mansale') " +
                //      " UNION ALL " +
                //      " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select trt from ztroute where srt=ztsaled.xroute) as xroute,ztsaleh.xboarding,(select xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby) as xuser from ztsaleh " +
                //      " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd where ztsaled.xdate=@xdate " +
                //      " and ztsaled.xcoach=@xcoach and ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in('mansale','sold')";

                str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select trt from ztroute where srt=ztsaled.xroute) as xroute,ztsaleh.xboarding,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztseatsl.xline from ztsaleh " +
                       " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                       " and ztsaled.xcoach=@xcoach and xstatus IN ('sold','forsale','mansale')  " +
                       " UNION ALL " +
                       " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select trt from ztroute where srt=ztsaled.xroute) as xroute,ztsaleh.xboarding,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztseatsl.xline from ztsaleh " +
                       " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                       " and ztsaled.xcoach=@xcoach and ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in('mansale','sold') order by ztseatsl.xline";

                dts2.Reset();

                SqlDataAdapter da4 = new SqlDataAdapter(str2, conn2);

                da4.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                da4.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

                da4.Fill(dts2, "temp");
                dtztemp.Reset();
                dtztemp = dts2.Tables["temp"];

                passlist.Controls.Clear();

                passlist.Controls.Add(new LiteralControl(
                                                          "<tr>"
                                                          + "<td scope='col' class='mystyle228'><strong>Seat</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Passenger</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Phone</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Tic. No</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Destination</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Boarding</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Sold By</strong></td>"
                                                          + "</tr>"));

                if (dtztemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtztemp.Rows.Count; i++)
                    {
                        passlist.Controls.Add(new LiteralControl("<tr>"));
                        for (int j = 0; j < dtztemp.Columns.Count-1; j++)
                        {
                            passlist.Controls.Add(new LiteralControl("<td>" + dtztemp.Rows[i][j].ToString()));
                            //dtztemp.Rows[i][j].ToString();
                            passlist.Controls.Add(new LiteralControl("</td>"));
                        }
                        passlist.Controls.Add(new LiteralControl("</tr>"));
                    }
                }

                //passlist.Controls.Add(new LiteralControl(""));

                xtotal.Text = "Total Seats Sold : " + zglobal.fnSideList(xdate2,xcoach2,"","","xtsold");

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}