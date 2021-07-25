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
    public partial class driverinforpt : System.Web.UI.Page
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






                str2 = "select CONVERT(VARCHAR(11),xdate,106),xcoach,xbus,xbustype,xdriver,xguide,xentdt,(select ztuser.xusername from ztuser where ztuser.xuser=xentby) from ztsaledriver where xdate between @xfrom and @xto order by xdate,xcoach";




                dts2.Reset();

                SqlDataAdapter da4 = new SqlDataAdapter(str2, conn2);

                da4.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da4.SelectCommand.Parameters.AddWithValue("@xto", xto2);



                da4.Fill(dts2, "temp");

                DataTable dtztemp = dts2.Tables["temp"];

                passlist.Controls.Clear();

                passlist.Controls.Add(new LiteralControl(
                                                          "<tr>"
                                                          + "<td scope='col' class='mystyle228'><strong>JDate</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Coach</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Bus No</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Bus Type</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Driver</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Guide</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Entry Date</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Entry By</strong></td>"
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