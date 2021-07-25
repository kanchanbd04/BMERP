using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.sc.Reports
{
    public partial class driverinfoparam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("driverinfoparam");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }
            }
        }
    }
}