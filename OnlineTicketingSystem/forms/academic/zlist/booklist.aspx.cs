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
    public partial class booklist : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string ctlid1;
        string rowid;
        object row;
        private string q_val;
        private string filter;
        

        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + "  * FROM lbbook WHERE (xlbord like '%" + filter + "%' or xlbtitle like N'%" + filter + "%') and zid=@zid ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
            da.SelectCommand.Parameters.AddWithValue("@zid", Int32.Parse(zid));
            //da.SelectCommand.Parameters.AddWithValue("@filter", filter);
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
                if (!IsPostBack)
                {
                    //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                    ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                    
                    //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                    ctlid_v.Value = ctlid;
                   
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