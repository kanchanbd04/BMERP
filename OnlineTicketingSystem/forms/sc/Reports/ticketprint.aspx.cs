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
    public partial class ticketprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string xid = Convert.ToString(HttpContext.Current.Session["ticket"]);

                xcoach.Text = "";
                xseat.Text = "";
                xname.Text = "";
                xcontact.Text = "";
                xvotid.Text = "";
                xnseat.Text = "";
                xpissue.Text="";
                xroute.Text = "";
                xboarding.Text = "";
                xrtime.Text = "";
                xfare.Text = "";
                xticket.Text = "";
                xsdate.Text = "";
                xjdate.Text = "";
                xjtime.Text = "";
                xtotal.Text = "";
                xsoldby.Text = "";
                xgticket.Text = "";
                xgpissue.Text = "";
                xgcoach.Text = "";
                xgroute.Text = "";
                xgjdate.Text = "";
                xgseat.Text = "";
                xgtotal.Text = "";
                xgsoldby.Text = "";
                xcticket.Text = "";
                xcpissue.Text = "";
                xccoach.Text = "";
                xcroute.Text = "";
                xcjdate.Text = "";
                xcjdate.Text = "";
                xcseat.Text = "";
                xctotal.Text = "";
                xcsoldby.Text = "";
                xcjtime.Text = "";
                xgjtime.Text = "";
                


                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string str2 = "select xcoach,xseat,xname,xphone,xvotid,xlocation,xboarding,xticket,xcreatedt,xdate,(select xusername from ztuser where xuser=xsoldby) as xsoldby from ztsaleh where xid=@xid";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xid", xid);
               

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];

                string xcoach1 = "";
                string xname1 = "";
                string xphone1 = "";
                string xvotid1 = "";
                string xlocation1 = "";
                string xboarding1 = "";
                string xticket1 = "";
                string xcreatedt1 = "";
                string xdate1 = "";
                string xsoldby1 = "";

                if (dtztemp.Rows.Count > 0)
                {
                    xcoach1 = dtztemp.Rows[0][0].ToString();
                    //string xseat1 = dtztemp.Rows[0][1].ToString();
                    xname1 = dtztemp.Rows[0][2].ToString();
                    xphone1 = dtztemp.Rows[0][3].ToString();
                    xvotid1 = dtztemp.Rows[0][4].ToString();
                    xlocation1 = dtztemp.Rows[0][5].ToString();
                    xboarding1 = dtztemp.Rows[0][6].ToString();
                    xticket1 = dtztemp.Rows[0][7].ToString();
                    xcreatedt1 = Convert.ToDateTime( dtztemp.Rows[0][8]).ToString("dd MMM, yyyy");
                    xdate1 = Convert.ToDateTime(dtztemp.Rows[0][9]).ToString("dd MMM, yyyy");
                    xsoldby1 = dtztemp.Rows[0][10].ToString();
                }

                str2 = "select xseat,(select route from ztroute where srt=xroute) as xroute,xrttime,xrate from ztsaled where xid=@xid and xstatus='sold'";

                dts2.Reset();
                SqlDataAdapter da02 = new SqlDataAdapter(str2,conn2);
                da02.SelectCommand.Parameters.AddWithValue("@xid",xid);

                da02.Fill(dts2,"temp");

                DataTable tbl02 = new DataTable();
                tbl02 = dts2.Tables[0];
                string xseat1 = "";
                string xnseat1 = tbl02.Rows.Count.ToString();
                string xroute1 = "";
                string xreptime1 = "";
                string xdtime1 = "";
                string xfare1 = "";
                string xtotal1 = "";
                if (tbl02.Rows.Count > 0)
                {
                    for (int i = 0; i < tbl02.Rows.Count; i++)
                    {
                        xseat1 = xseat1 + tbl02.Rows[i][0].ToString();
                        if (i < (tbl02.Rows.Count - 1))
                        {
                            xseat1 = xseat1 + ",";
                        }
                    }

                    xroute1 = tbl02.Rows[0][1].ToString();
                    xdtime1 = tbl02.Rows[0][2].ToString();
                    DateTime dtime1 = Convert.ToDateTime(xdtime1).AddMinutes(-15);
                    xreptime1 = dtime1.ToString("hh:mm tt");
                    xfare1 = tbl02.Rows[0][3].ToString();
                    xtotal1 = (Convert.ToDouble(xfare1) * tbl02.Rows.Count).ToString();
                }

                xcoach.Text = xcoach1;
                xseat.Text = xseat1;
                xname.Text = xname1; 
                xcontact.Text = xphone1;
                xvotid.Text = xvotid1;
                xnseat.Text = xnseat1;
                xpissue.Text = xlocation1;
                xroute.Text = xroute1;
                xboarding.Text = xboarding1;
                xjtime.Text = xdtime1.ToUpper();
                xrtime.Text = xreptime1;
                xfare.Text = xfare1;
                xticket.Text = xticket1;
                xsdate.Text = xcreatedt1;
                xjdate.Text = xdate1;
                xtotal.Text = xtotal1;
                xsoldby.Text = xsoldby1;

                xgticket.Text = xticket1;
                xgpissue.Text = xlocation1;
                xgcoach.Text = xcoach1;
                xgroute.Text = xroute1;
                xgjdate.Text = xdate1;
                xgjtime.Text = xdtime1.ToUpper();
                xgseat.Text = xseat1;
                xgtotal.Text = xtotal1;
                xgsoldby.Text = xsoldby1;

                xcticket.Text = xticket1;
                xcpissue.Text = xlocation1;
                xccoach.Text = xcoach1;
                xcroute.Text = xroute1;
                xcjdate.Text = xdate1;
                xcjtime.Text = xdtime1.ToUpper();
                xcseat.Text = xseat1;
                xctotal.Text = xtotal1;
                xcsoldby.Text = xsoldby1;

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}