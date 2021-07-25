using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class issuelist : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string ctlid1;
        string rowid;
        string xwh;
        string xstdid;
        object row;
        private string q_val;
        private string filter;
        

        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + "  ximtmptrn,xstdid,(select xname from amadmis where zid=imtemptrn.zid and xstdid=coalesce(imtemptrn.xstdid,'')) as xname," +
                         "(select xclass from amstudentvwextacc where zid=imtemptrn.zid and xstdid=coalesce(imtemptrn.xstdid,'') and xsession='" + zglobal.fnDefaults("xsessionacc", "Student") + "') as xclass,xfwh,xdate FROM imtemptrn WHERE (ximtmptrn like '%" + filter + "%' or xstdid like '%" + filter + "%') and zid=@zid and xtrnim='IS--' and xfwh=@xwh and coalesce(xstdid,'')=@xstdid and xstatustrn='Confirmed' order by ximtmptrn desc";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", Int32.Parse(zid));
            da.SelectCommand.Parameters.AddWithValue("@xwh", xwh);
            da.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid);
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            _grid_emp.DataSource = dtztcode;
            _grid_emp.DataBind();



            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();


        }


        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                
                fnFillDataGrid();

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            //    //////Check Permission
            //    ////SiteMaster sm = new SiteMaster();
            //    ////string s = sm.fnChkPagePermis("ztpermis");
            //    ////if (s == "n" || s == "e")
            //    ////{
            //    ////    HttpContext.Current.Session["curuser"] = null;
            //    ////    Session.Abandon();
            //    ////    Response.Redirect("~/forms/zlogin.aspx");
            //    ////}


            //    //pagew = Request.QueryString["page"];
            //    //if (pagew == "user")
            //    //{
            //    //    curuser = Request.QueryString["xuser"];
            //    //    xuser.InnerHtml = "User : " + curuser;
            //    //}
            //    //else
            //    //{
            //    //    curuser = Request.QueryString["xrole"];
            //    //    xuser.InnerHtml = "Role : " + curuser;
            //    //}

                zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                xwh = Request.QueryString["xwh"] != "" ? Request.QueryString["xwh"] : "";
                xstdid = Request.QueryString["xstdid"] != "" ? Request.QueryString["xstdid"] : "";
                if (!IsPostBack)
                {
                    //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                    ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                    ctlid1 = Request.QueryString["ctlid1"] != "" ? Request.QueryString["ctlid1"] : "-1";
                    //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                    ctlid_v.Value = ctlid;
                    ctlid1_v.Value = ctlid1;
                   // Response.Write(ctlid_v.Value);
                    _gridrow.Text = zglobal._grid_row_value;
                    fnFillDataGrid();
                    
                    
                }

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
            
        }

     

       


        
    }
}