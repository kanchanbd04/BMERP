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
    public partial class multiple_accounts_sel : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string rowid;
        object row;
        private string q_val;
        

        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "select glmstd.xacc,xdesc from glmstd inner join glmstbiz on glmstd.xrow=glmstbiz.xrowglmstd where " + 
                         " (glmstd.xacc like '%" + q_val + "%' or glmstd.xdesc like '%" + q_val + "%' or glmstd.xacc like '" + q_val + "%' or glmstd.xdesc like '" + q_val + "%') " +
                         " and glmstd.xrow=(select MAX(xrow) from glmstd as a where a.xacc=glmstd.xacc) and zid=@zid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.Add("@zid", Int32.Parse(zid));
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView2.DataSource = dtztcode;
            GridView2.DataBind();



            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();


        }

        protected void FillControls(object sender, EventArgs e)
        {
            

           
        }

        protected void fnDeleteAcc(object sender, EventArgs e)
        {
            
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


                if (!IsPostBack)
                {
                    zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                    ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                    rowid = Request.QueryString["rowid"] != "" ? Request.QueryString["rowid"] : "-1";
                    q_val = Request.QueryString["q_val"] != "" ? Request.QueryString["q_val"] : "";
                    ctlid_v.Value = ctlid;
                    rowid_v.Value = rowid;;
                    //msg.InnerHtml = zid.ToString();
                    //zorg = Request.QueryString["zorg"] != "" ? Request.QueryString["zorg"] : "-1";
                   

                    //zglobal.fnDeleteBusinessCusAR(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());

                    fnFillDataGrid();
                    //msg.InnerHtml = zorg.ToString();
                    
                    
                }

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
            
        }

     

        protected void btnPermission_Click(object sender, EventArgs e)
        {
            
        }

        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnPermission_Click1(object sender, EventArgs e)
        {
           
        }

        

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            
        }

        protected void btnUpdate0_Click(object sender, EventArgs e)
        {
           
        }

       

        


 

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
           
        }


        
    }
}