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
    public partial class vahiclerpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {



                string xfrom2 = Request.QueryString["xfrom1"];
                string xto2 = Request.QueryString["xto1"];

                xfrom.Text = xfrom2.ToString();
                xto.Text = xto2.ToString();




                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();
                string str2;


                //str2 = "select a.xcoach, " +
                //     " (select ztsaledriver.xbus from ztsaledriver where ztsaledriver.xentdt=(select MAX(ztsaledriver.xentdt) from ztsaledriver where ztsaledriver.xdate=a.xdate and ztsaledriver.xcoach=a.xcoach)), " +
                //     " (select ztroute.route from ztroute where ztroute.srt= " +
                //     " (select ztroute.mrt from ztroute where ztroute.srt=(select top 1 ztsaled.xroute from ztsaled where ztsaled.xdate=a.xdate and ztsaled.xcoach=a.xcoach))), " +
                //     " CONVERT(VARCHAR(11),a.xdate,106), " +
                //     " SUM(a.xsign), " +
                //     " SUM(a.xsign*a.xnetamt), " +
                //     " '0','0','0','0','0','0','0','0','0','0', " +
                //     " SUM(a.xsign*a.xnetamt) " +
                //     " from ztsalevw as a " +
                //     " where a.xdate between @xfrom and @xto " +
                //     " group by a.xcoach,a.xdate ";



                str2 = " select ztsalevw.xcoach, " +
                       " ztsaledriver.xbus , " +
                       " (select ztroute.route from ztroute where ztroute.srt= " +
                       " (select ztroute.mrt from ztroute where ztroute.srt=(select top 1 ztsaled.xroute from ztsaled where ztsaled.xdate=ztsalevw.xdate and ztsaled.xcoach=ztsalevw.xcoach))), " +
                       " CONVERT(VARCHAR(11),ztsalevw.xdate,106), " +
                       " SUM(ztsalevw.xsign), " +
                       " SUM(ztsalevw.xsign*ztsalevw.xnetamt), " +
                       " '0','0','0','0','0','0','0','0','0','0', " +
                       " SUM(ztsalevw.xsign*ztsalevw.xnetamt) " +
                       " from ztsalevw inner join ztsaledriver on ztsalevw.xcoach=ztsaledriver.xcoach and ztsalevw.xdate=ztsaledriver.xdate " +
                       " where ztsaledriver.xentdt=(select MAX(ztsaledriver.xentdt) from ztsaledriver where ztsaledriver.xdate=ztsalevw.xdate and ztsaledriver.xcoach=ztsalevw.xcoach) " +
                       " and ztsalevw.xdate between @xfrom and @xto" +
                       " group by ztsalevw.xcoach,ztsalevw.xdate,ztsalevw.mainroute, ztsaledriver.xbus ";




                dts2.Reset();

                SqlDataAdapter da4 = new SqlDataAdapter(str2, conn2);

                da4.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da4.SelectCommand.Parameters.AddWithValue("@xto", xto2);
           


                da4.Fill(dts2, "temp");

                DataTable dtztemp = dts2.Tables["temp"];

                passlist.Controls.Clear();

                passlist.Controls.Add(new LiteralControl(
                                                          "<tr>"
                                                          + "<td scope='col' class='mystyle228'><strong>Coach</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Bus</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Route</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>JDate</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Sold</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Ticket Fare</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Fuel</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Driver</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Helper</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Guide</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Tole</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>SubsFee</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Water</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Polybag</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Wash</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Total Exp</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Income</strong></td>"
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