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
    public partial class cancelrpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {



                string xfrom2 = Request.QueryString["xfrom1"];
                string xto2 = Request.QueryString["xto1"];
                string xtype2 = Request.QueryString["xtype1"];
                string xuser2 = Request.QueryString["xuser1"];

                xfrom.Text = xfrom2.ToString();
                xto.Text = xto2.ToString();

                string xtype3;

                if (xtype2 == "Online")
                {
                    xtype3 = "sold";
                }
                else if (xtype2 == "Manual")
                {
                    xtype3 = "mansale";
                }
                else
                {
                    xtype3 = "confbooking";
                }


                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();
                string str2;

                if (xtype2 == "[Select]")
                {
                    if (xuser2 == "[Select]")
                    {
                        str2 = " select ztcancelreq.xcoach,(select ztroute.route from ztroute where ztroute.srt=ztcancelreq.xroute),ztcancelreq.xseat,ztsaleh.xticket, " +
                                                " ztsaleh.xname,ztsaleh.xphone,(select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby),ztcancelreq.xreqdt, " +
                                                " (select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xapproveby),ztcancelreq.xapprovedt,ztcancelreq.xremark " +
                                                " from ztsaleh  inner join ztcancelreq on ztsaleh.xid=ztcancelreq.xid " +
                                                " where convert(date,ztcancelreq.xapprovedt) between @xfrom and @xto and ztcancelreq.xstatus='approved' and ztcancelreq.xremark in('sold','mansale','confbooking') ";
                    }
                    else
                    {
                        str2 = " select ztcancelreq.xcoach,(select ztroute.route from ztroute where ztroute.srt=ztcancelreq.xroute),ztcancelreq.xseat,ztsaleh.xticket, " +
                                                " ztsaleh.xname,ztsaleh.xphone,(select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby),ztcancelreq.xreqdt, " +
                                                " (select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xapproveby),ztcancelreq.xapprovedt,ztcancelreq.xremark " +
                                                " from ztsaleh  inner join ztcancelreq on ztsaleh.xid=ztcancelreq.xid " +
                                                " where convert(date,ztcancelreq.xapprovedt) between @xfrom and @xto and ztcancelreq.xstatus='approved' and ztcancelreq.xremark in('sold','mansale','confbooking') and ztcancelreq.xapproveby =@xman";
                    }
                }
                else
                {
                    if (xuser2 == "[Select]")
                    {
                        str2 = " select ztcancelreq.xcoach,(select ztroute.route from ztroute where ztroute.srt=ztcancelreq.xroute),ztcancelreq.xseat,ztsaleh.xticket, " +
                                                    " ztsaleh.xname,ztsaleh.xphone,(select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby),ztcancelreq.xreqdt, " +
                                                    " (select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xapproveby),ztcancelreq.xapprovedt,ztcancelreq.xremark " +
                                                    " from ztsaleh  inner join ztcancelreq on ztsaleh.xid=ztcancelreq.xid " +
                                                    " where convert(date,ztcancelreq.xapprovedt) between @xfrom and @xto and ztcancelreq.xstatus='approved' and ztcancelreq.xremark =@xremark";
                    }
                    else
                    {
                        str2 = " select ztcancelreq.xcoach,(select ztroute.route from ztroute where ztroute.srt=ztcancelreq.xroute),ztcancelreq.xseat,ztsaleh.xticket, " +
                                                       " ztsaleh.xname,ztsaleh.xphone,(select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xreqby),ztcancelreq.xreqdt, " +
                                                       " (select ztuser.xusername from ztuser where ztuser.xuser=ztcancelreq.xapproveby),ztcancelreq.xapprovedt,ztcancelreq.xremark " +
                                                       " from ztsaleh  inner join ztcancelreq on ztsaleh.xid=ztcancelreq.xid " +
                                                       " where convert(date,ztcancelreq.xapprovedt) between @xfrom and @xto and ztcancelreq.xstatus='approved' and ztcancelreq.xremark =@xremark and ztcancelreq.xapproveby =@xman";
                    }
                }

               
                
               

                dts2.Reset();

                SqlDataAdapter da4 = new SqlDataAdapter(str2, conn2);

                da4.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da4.SelectCommand.Parameters.AddWithValue("@xto", xto2);
                da4.SelectCommand.Parameters.AddWithValue("@xman", xuser2);
                da4.SelectCommand.Parameters.AddWithValue("@xremark", xtype3);
               

                da4.Fill(dts2, "temp");
                
                DataTable dtztemp = dts2.Tables["temp"];

                passlist.Controls.Clear();

                passlist.Controls.Add(new LiteralControl(
                                                          "<tr>"
                                                          + "<td scope='col' class='mystyle228'><strong>Coach No</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Route</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Seat</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Ticket No</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Name</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Phone No.</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Request By</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Request Date</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Approve By</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Approve Date</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Remarks</strong></td>"
                                                          + "</tr>"));

                if (dtztemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtztemp.Rows.Count; i++)
                    {
                        passlist.Controls.Add(new LiteralControl("<tr>"));
                        for (int j = 0; j < dtztemp.Columns.Count; j++)
                        {
                            passlist.Controls.Add(new LiteralControl("<td>" + dtztemp.Rows[i][j].ToString()));
                           
                            passlist.Controls.Add(new LiteralControl("</td>"));
                        }
                        passlist.Controls.Add(new LiteralControl("</tr>"));
                    }
                }

                //passlist.Controls.Add(new LiteralControl(""));



            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}