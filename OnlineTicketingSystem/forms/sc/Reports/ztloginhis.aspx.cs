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
    public partial class ztloginhis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            xfromdt.Text = "";
            xtodt.Text = "";
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

               
                //xfromdt.Text = "";
                //xtodt.Text = "";



                DateTime xfrom2 = Convert.ToDateTime(xfrom.Text.ToString()).Date;
                DateTime xto2 = Convert.ToDateTime(xto.Text.ToString()).Date;
                

                xfromdt.Text = xfrom2.ToString("dd MMM, yyyy");
                xtodt.Text = xto2.ToString("dd MMM, yyyy");
                //xuser.Text = xuser2.ToString();

                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string str2 = "select (select xusername from ztuser where xuser=ztloginhis.xuser) as xuser,xlogin,xlogout,xloc from ztloginhis where  xdate between @xfrom and @xto order by xlogin";

                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xfrom", xfrom2);
                da2.SelectCommand.Parameters.AddWithValue("@xto", xto2);
                

                da2.Fill(dts2, "temp");
                DataTable dtztemp = new DataTable();
                dtztemp = dts2.Tables["temp"];



                passlist.Controls.Clear();

                passlist.Controls.Add(new LiteralControl(
                                                          "<tr>"
                                                          + "<td scope='col' class='mystyle228'><strong>User</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Login Time</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Logout Time</strong></td>"
                                                          + "<td scope='col' class='mystyle228'><strong>Location</strong></td>"
                                                       
                                                          + "</tr>"));

                if (dtztemp.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dtztemp.Rows.Count; i++)
                    {

                       

                        passlist.Controls.Add(new LiteralControl("<tr>"));
                        for (int j = 0; j < dtztemp.Columns.Count; j++)
                        {
                            if (j == 2)
                            {
                                if (Convert.ToDateTime(dtztemp.Rows[i][j]) == Convert.ToDateTime("1900-01-01 00:00:00.000"))
                                {
                                    passlist.Controls.Add(new LiteralControl("<td>"));
                                }
                                else
                                {
                                    passlist.Controls.Add(new LiteralControl("<td>" + dtztemp.Rows[i][j].ToString()));
                                }
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

                

              


            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}