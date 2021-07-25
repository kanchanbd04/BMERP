using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.sc.Reports
{
    public partial class saledetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("saledetails");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                xdtype.Items.Add(new ListItem("Date Range","drange"));
                xdtype.Items.Add(new ListItem("Single Date", "sdate"));

                xrcriteria.Items.Add(new ListItem("On Date", "ondate"));
                xrcriteria.Items.Add(new ListItem("Advanced", "advanced"));
                xrcriteria.Items.Add(new ListItem("Total", "total"));
            }
        }

        //protected void xdtype_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (xdtype.SelectedItem.Value == "sdate")
        //    {
        //        xto.Enabled = false;
        //    }
        //    else
        //    {
        //        xto.Enabled = true;
        //    }
        //}
    }
}