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
    public partial class payscale : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string ctlid1;
        string gvid1;
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
            string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + "  xpsclcode,xdesc FROM prpayscal WHERE (xpsclcode like '%" + filter + "%' or xdesc like '%" + filter + "%') and zid=@zid ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.Add("@zid", Int32.Parse(zid));
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
                    ctlid1 = Request.QueryString["ctlid1"] != "" ? Request.QueryString["ctlid1"] : "-1";
                    gvid1 = Request.QueryString["gvid"] != "" ? Request.QueryString["gvid"] : "-1";
                    //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                    ctlid_v.Value = ctlid;
                    ctlid1_v.Value = ctlid1;
                    gvid_v.Value = gvid1;
                   // Response.Write(ctlid_v.Value);
                    _gridrow.Text = "100";
                    fnFillDataGrid();
                    
                    
                }

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
            
        }


        [WebMethod(EnableSession = true)]
        public static string createjson(string i)
        {
            //try
            //{
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        string query = "select amtfcconfigt.xtype,amtfcconfigt.xamount from amtfcconfig inner join amtfcconfigt on " +
            //                       "amtfcconfig.zid=amtfcconfigt.zid and amtfcconfig.xrow=amtfcconfigt.xrow " +
            //                       "where amtfcconfig.xtfccode=@xtfccode and amtfcconfig.zid=@zid and amtfcconfig.xeffdate=(select max(a.xeffdate) " +
            //                       "from amtfcconfig as a where a.zid=amtfcconfig.zid and a.xtfccode=amtfcconfig.xtfccode)";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da1.SelectCommand.Parameters.AddWithValue("@xtfccode", i);
            //        da1.Fill(dts1, "tempztcode");

            //        DataTable dtamexamd = new DataTable();
            //        dtamexamd = dts1.Tables[0];

            JavaScriptSerializer cityjson = new JavaScriptSerializer();
            List<loadvals> cityjsonlst = new List<loadvals>();
            loadvals cityrow;
            //        if (dtamexamd.Rows.Count > 0)
            //        {

            //            foreach (DataRow citydr in dtamexamd.Rows)
            //            {
            //                cityrow = new loadvals();
            //                cityrow.xtype = citydr["xtype"].ToString();
            //                cityrow.xamount = citydr["xamount"].ToString();

            //                cityjsonlst.Add(cityrow);
            //            }
            //            return cityjson.Serialize(cityjsonlst);
            //            //return "suc";
            //        }
            //        else
            //        {

            cityrow = new loadvals();
            cityrow.xtype = "nodata";
            cityrow.xamount = "nodata";

            //            cityjsonlst.Add(cityrow);

            return cityjson.Serialize(cityjsonlst);
            //            //return "fal";

            //        }
            //    }
            //}

            //DataSet cityds = new DataSet();
            //cityds.ReadXml(HttpContext.Current.Server.MapPath("~/xml/cities.xml"));
            //DataTable citydt = cityds.Tables[0];

            //citydt = citydt.Rows.Cast<DataRow>().Skip(int.Parse(i) - 1).Take(1).CopyToDataTable();


            //// citydt.AsEnumerable().Take(int.Parse(i));
            //JavaScriptSerializer cityjson = new JavaScriptSerializer();
            //List<loadvals> cityjsonlst = new List<loadvals>();
            //loadvals cityrow;
            //foreach (DataRow citydr in citydt.Rows)
            //{
            //    cityrow = new loadvals();
            //    cityrow.id = citydr["id"].ToString();
            //    cityrow.name = citydr["name"].ToString();

            //    cityjsonlst.Add(cityrow);
            //}
            //return cityjson.Serialize(cityjsonlst);
            //}
            //catch (Exception exp)
            //{
            //    return exp.Message;
            //}
        }
       


        
    }

    //class loadvals
    //{
    //    public string xtype { get; set; }
    //    public string xamount { get; set; }
    //}


}

