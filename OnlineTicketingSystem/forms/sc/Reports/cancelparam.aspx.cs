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
    public partial class cancelparam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    xtype.Items.Add("[Select]");
                    xtype.Items.Add("Online");
                    xtype.Items.Add("Manual");
                    xtype.Items.Add("Conf. Booking");
                    xtype.Text = "[Select]";

                    SqlConnection conn12345;
                    conn12345 = new SqlConnection(zglobal.constring);
                    DataSet dts12345 = new DataSet();



                    string str55 = "select xuser from ztuser";

                    SqlDataAdapter da55 = new SqlDataAdapter(str55, conn12345);





                    dts12345.Reset();

                    da55.Fill(dts12345, "tempzt");
                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable dtztemp55 = new DataTable();
                    dtztemp55 = dts12345.Tables[0];

                    xuser.Items.Add("[Select]");
                    if (dtztemp55.Rows.Count > 0)
                    {
                        foreach (DataRow xusr in dtztemp55.Rows)
                        {
                            xuser.Items.Add(xusr[0].ToString());
                        }
                    }
                    xuser.Text = "[Select]";
                }
            }
            catch(Exception exp)
            {
                Response.Write(exp.Message);
            }
        }

       
    }
}