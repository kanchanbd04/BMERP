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
    public partial class commentsbank : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string ctlid1;
        string ctlid2;
        string rowid;
        string xclass;
        string xtype;
        object row;
        private string q_val;
        private string filter;
        

        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            //string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + "  xacc,xdesc,xsub,xdescsub, xdescsub, xdesc1,xacctype,xaccusage,xaccsource FROM glmstvw1 " +
            //             "WHERE (xacc like '%" + filter + "%' or xdesc like '%" + filter + "%' or xsub like '%" + filter + "%' or xdescsub like '%" + filter + "%') " +
            //             "and zid=@zid and zactive=1";

            string str = "SELECT * FROM mscommentsbank " +
                         "WHERE xclass=@xclass and xtype=@xtype and xcat1=@xcat1 and xcat2=@xcat2 " +
                         "and zid=@zid ";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", Int32.Parse(zid));
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.ToString());
            da.SelectCommand.Parameters.AddWithValue("@xtype", xtype.ToString());
            da.SelectCommand.Parameters.AddWithValue("@xcat1", xcat1.Text.ToString() == "[Select]" ? "" : xcat1.Text.ToString());
            da.SelectCommand.Parameters.AddWithValue("@xcat2", xcat2.Text.ToString() == "[Select]" ? "" : xcat2.Text.ToString());
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                _grid_emp.DataSource = dtztcode;
                _grid_emp.DataBind();
            }
            else
            {
                _grid_emp.DataSource = null;
                _grid_emp.DataBind();
            }



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
                //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                xclass = Request.QueryString["xclass"] != "" ? Request.QueryString["xclass"] : "";
                xtype = Request.QueryString["xtype"] != "" ? Request.QueryString["xtype"] : "";

                if (!IsPostBack)
                {

                    //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                    ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                    xclass = Request.QueryString["xclass"] != "" ? Request.QueryString["xclass"] : "";
                    xtype = Request.QueryString["xtype"] != "" ? Request.QueryString["xtype"] : "";
                    //ctlid1 = Request.QueryString["ctlid1"] != "" ? Request.QueryString["ctlid1"] : "-1";
                    //ctlid2 = Request.QueryString["ctlid2"] != "" ? Request.QueryString["ctlid2"] : "-1";
                    //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                    ctlid_v.Value = ctlid;
                    ctlid1_v.Value = ctlid1;
                    ctlid2_v.Value = ctlid2;
                   // Response.Write(ctlid_v.Value);
                    //_gridrow.Text = zglobal._grid_row_value;

                    xcat1.Items.Clear();

                    //zglobal.fnGetComboDataCD("Comments Category 1", xcat1);
                    xcat1.Items.Add("[Select]");
                    xcat1.Text = "[Select]";

                   
                    //combo.Items.Add("[Select]");
                    xcat1.Items.Add("");
                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        string query = "SELECT distinct xcat1 FROM mscommentsbank WHERE zid=@zid AND xtype=@xtype AND xclass=@xclass ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                        cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                        cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xclass", xclass);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            xcat1.Items.Add(rdr["xcat1"].ToString());
                        }
                    }
                    //combo.Text = "[Select]";
                    //xcat1.Text = "";

                    xcat2.Items.Clear();

                    //zglobal.fnGetComboDataCD("Comments Category 2", xcat2);
                    xcat2.Items.Add("[Select]");
                    xcat2.Text = "[Select]";

                  
                    //combo.Items.Add("[Select]");
                    xcat2.Items.Add("");
                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        string query = "SELECT distinct xcat2 FROM mscommentsbank WHERE zid=@zid AND xtype=@xtype AND xclass=@xclass ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                        cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                        cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xclass", xclass);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            xcat2.Items.Add(rdr["xcat2"].ToString());
                        }
                    }
                    //combo.Text = "[Select]";
                    //xcat2.Text = "";

                    _grid_emp.DataSource = null;
                    _grid_emp.DataBind();

                    //fnFillDataGrid();
                    
                }

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
            
        }


        protected void xcat1_OnSelectedIndexChanged(object sender, EventArgs e)
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
    }
}