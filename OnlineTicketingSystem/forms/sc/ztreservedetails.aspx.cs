using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineTicketingSystem.forms.sc
{
    public partial class ztreservedetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    

                    xcoach.Text = Request.QueryString["xcoach"];
                    xdplace.Text = Request.QueryString["xdplace"];
                    xdest.Text = Request.QueryString["xdest"];
                    xdate.Text = Request.QueryString["xdate"];
                    xtime.Text = Request.QueryString["xtime"];
                    xresby.Text = Request.QueryString["xresby"];
                    xcontact.Text = Request.QueryString["xcontact"];
                    xrefby.Text = Request.QueryString["xrefby"];
                    xfare.Text = Request.QueryString["xfare"];
                    xdue.Text = Request.QueryString["xdue"];

                    populatedatagrid();
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        private void populatedatagrid()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xpayment,xpayby,(select xusername from ztuser where xuser=ztreserve.xcreatedby)AS xcreatedby,xcreatedt,(select xpayment from ztrespayhis where ztrespayhis.xcoach=ztreserve.xcoach and ztrespayhis.xdate=ztreserve.xdate) as xpayment FROM ztreserve  WHERE xdate=@xdate AND xcoach=@xcoach ORDER BY xcreatedt";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            DateTime xdate1 = Convert.ToDateTime(Request.QueryString["xdate"]);
            string xcoach1 = Request.QueryString["xcoach"];

            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);

            da.Fill(dts, "tempzuser");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzuser = new DataTable();
            dtzuser = dts.Tables[0];
            GridView1.DataSource = dtzuser;
            GridView1.DataBind();

            xtotalpayment.Text = dtzuser.Rows[0][4].ToString();
            dts.Dispose();
            dtzuser.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (xpayment.Text == "")
                {
                    msg.InnerHtml = "Please enter pay amount.";
                    xpayment.Focus();
                    return;
                }
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;



                query = "INSERT INTO ztreserve " +
                            " (xrow,xcoach,xdate,xfare,xpayment,xpayby,xcreatedby,xcreatedt,xloc,xstatus) " +
                            " VALUES (@xrow,@xcoach,@xdate,0.00,@xpayment,@xpayby,@xcreatedby,@xcreatedt,@xloc,'reserve') ";

                dataCmd.CommandText = query;

                string xrow1 = zglobal.fnmaxid("SELECT max(xrow) FROM ztreserve where getdate() between @firstdate and @lastdate");
                string xcoach2 = Request.QueryString["xcoach"];
                DateTime xdate2 = Convert.ToDateTime(Request.QueryString["xdate"]);
                string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                DateTime xdt1 = DateTime.Now;
                string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                double xpayment3 = Convert.ToDouble(xpayment.Text);
                string xpayby2 = xpayby.Text.ToString().Trim();

                dataCmd.Parameters.Clear();
                dataCmd.Parameters.AddWithValue("@xrow", xrow1);
                dataCmd.Parameters.AddWithValue("@xcoach", xcoach2);
                dataCmd.Parameters.AddWithValue("@xdate", xdate2);
                dataCmd.Parameters.AddWithValue("@xpayment", xpayment3);
                dataCmd.Parameters.AddWithValue("@xpayby", xpayby2);
                dataCmd.Parameters.AddWithValue("@xcreatedby", xuser1);
                dataCmd.Parameters.AddWithValue("@xcreatedt", xdt1);
                dataCmd.Parameters.AddWithValue("@xloc", xloc1);


                conn1.Close();
                conn1.Open();

                dataCmd.ExecuteNonQuery();

                conn1.Close();


                populatedatagrid();

                SqlConnection conn11;
                conn11 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "select xdue from ztrespayhis where xcoach=@xcoach and xdate=@xdate";
                SqlDataAdapter da = new SqlDataAdapter(str, conn11);

                DateTime xdate1 = Convert.ToDateTime(Request.QueryString["xdate"]);
                string xcoach1 = Request.QueryString["xcoach"];

                da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);

                da.Fill(dts, "tempzuser");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztemp = new DataTable();
                dtztemp = dts.Tables[0];

                xdue.Text = dtztemp.Rows[0][0].ToString();

                msg.InnerHtml = "";

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }
    }
}