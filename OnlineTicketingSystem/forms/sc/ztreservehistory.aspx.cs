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
    public partial class ztreservehistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check Permission
            SiteMaster sm = new SiteMaster();
            string s = sm.fnChkPagePermis("ztreservehistory");
            if (s == "n" || s == "e")
            {
                HttpContext.Current.Session["curuser"] = null;
                Session.Abandon();
                Response.Redirect("~/forms/zlogin.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "SELECT xrow,xcoach,xdest,xdate,xfare," +
                             "(select xpayment from ztrespayhis where ztrespayhis.xcoach=ztreserve.xcoach and ztrespayhis.xdate=ztreserve.xdate) as xpayment,"+
                             "(select xdue from ztrespayhis where ztrespayhis.xcoach=ztreserve.xcoach and ztrespayhis.xdate=ztreserve.xdate) as xdue,xresby,"+
                             "(select xusername from ztuser where xuser=ztreserve.xcreatedby)AS xcreatedby,"+
                             "(select xpayinfo from ztrespayhis where ztrespayhis.xcoach=ztreserve.xcoach and ztrespayhis.xdate=ztreserve.xdate) as xpayinfo,xdplace,xtime,xcontact,xrefby "+
                             "FROM ztreserve    WHERE xdate BETWEEN @xfrom AND @xto AND COALESCE (xfare, 0) <> 0 AND xstatus='reserve' ORDER BY xrow";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                DateTime xfrom1 = Convert.ToDateTime(xfrom.Text);
                DateTime xto1 = Convert.ToDateTime(xto.Text);

                da.SelectCommand.Parameters.AddWithValue("@xfrom",xfrom1);
                da.SelectCommand.Parameters.AddWithValue("@xto", xto1);

                da.Fill(dts, "tempzuser");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];
                GridView1.DataSource = dtzuser;
                GridView1.DataBind();
                dts.Dispose();
                dtzuser.Dispose();
                da.Dispose();
                conn1.Dispose();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }
    }
}