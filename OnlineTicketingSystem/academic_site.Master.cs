using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Timers;
using System.Web.UI.HtmlControls;

namespace OnlineTicketingSystem
{
    public partial class academic_site : System.Web.UI.MasterPage
    {
        ArrayList menu = new ArrayList();

        ArrayList permis = new ArrayList();
        string permission = "";

        protected void Page_Init(object sender, EventArgs e)
        {
            //GetMenuItem();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["curuser"] == null || Convert.ToString(HttpContext.Current.Session["curuser"]) == "")
            {
                //FormsAuthentication.SignOut();
                //FormsAuthentication.RedirectToLoginPage();
                Response.Redirect("~/forms/zlogin.aspx");
            }
            //if (!this.Page.User.Identity.IsAuthenticated)
            //{

            //    Session.Abandon();
            //    FormsAuthentication.RedirectToLoginPage();

            //}

            try
            {

                if (!IsPostBack)
                {

                    //fnDelCurSeat();
                    lblUser.Text = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    lblBusiness.Text = zglobal.fnGetBusinessName(Convert.ToString(HttpContext.Current.Session["business"]));

                    //if (Convert.ToString(HttpContext.Current.Session["curuser"]) != "bm")
                    //{
                    //    SqlConnection conn1;
                    //    conn1 = new SqlConnection(zglobal.constring);
                    //    DataSet dts = new DataSet();


                    //    dts.Reset();
                    //    string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid and zid=@zid";

                    //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                    //    string xid = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    //    string zid = Convert.ToString(HttpContext.Current.Session["business"]);
                    //    da.SelectCommand.Parameters.AddWithValue("@xid", xid);
                    //    da.SelectCommand.Parameters.AddWithValue("@zid", zid);


                    //    da.Fill(dts, "tempdt");
                    //    //DataView dv = new DataView(dts.Tables[0]);
                    //    DataTable temp = new DataTable();
                    //    temp = dts.Tables[0];

                    //    string[] xxid;

                    //    if (temp.Rows.Count > 0)
                    //    {
                    //        //msg.InnerHtml = xid + temp.Rows[0][0].ToString();
                    //        permission = temp.Rows[0][0].ToString();

                    //        xxid = permission.Split('|');
                    //        foreach (string id in xxid)
                    //        {
                    //            permis.Add(id.Trim());
                    //        }
                    //    }

                    //    /////This is the code for if User permission not set then load menu as role permission
                    //    else
                    //    {

                    //        str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                    //        SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                    //        //xid = this.Page.User.Identity.Name;
                    //        da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);

                    //        dts.Reset();

                    //        da1.Fill(dts, "tempdt");
                    //        DataTable temp1 = new DataTable();
                    //        temp1 = dts.Tables[0];


                    //        if (temp1.Rows.Count > 0)
                    //        {



                    //            str = "SELECT xpermis FROM ztpermis WHERE xid=@xid and zid=@zid";
                    //            SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

                    //            xid = temp1.Rows[0][0].ToString();
                    //            da2.SelectCommand.Parameters.AddWithValue("@xid", xid);
                    //            da2.SelectCommand.Parameters.AddWithValue("@zid", zid);

                    //            dts.Reset();

                    //            da2.Fill(dts, "tempdt");
                    //            DataTable temp2 = new DataTable();
                    //            temp2 = dts.Tables[0];


                    //            if (temp2.Rows.Count > 0)
                    //            {
                    //                permission = temp2.Rows[0][0].ToString();

                    //                xxid = permission.Split('|');
                    //                foreach (string id in xxid)
                    //                {
                    //                    permis.Add(id.Trim());
                    //                }
                    //            }
                    //            else
                    //            {
                    //                Label1.Visible = true;
                    //                Label1.Text = "You have no permission set yet. Please contact to your system administrator. ";
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Label1.Visible = true;
                    //            Label1.Text = "You are not belong to any role/group. Please contact to your system administrator. ";
                    //        }


                    //        da1.Dispose();
                    //    }
                    //    conn1.Dispose();
                    //    da.Dispose();

                    //    dts.Dispose();

                    //}

                    //zglobal.fnDeleteBusinessGLMSTPermis(Convert.ToString(HttpContext.Current.Session["curuser"]), HttpContext.Current.Session.SessionID.ToString());
                    //if (HttpContext.Current.Session["menu"] != null )
                    //{
                    //GetMenuItem();
                    //}



                }

                //GetMenuItem();

                

                // HttpContext.Current.Session["menu"] = null;
                permis.Clear();
                if (Convert.ToString(HttpContext.Current.Session["curuser"]) != "bm")
                {
                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts = new DataSet();


                    dts.Reset();
                    string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid and zid=@zid";

                    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                    string xid = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string zid = Convert.ToString(HttpContext.Current.Session["business"]);
                    da.SelectCommand.Parameters.AddWithValue("@xid", xid);
                    da.SelectCommand.Parameters.AddWithValue("@zid", zid);


                    da.Fill(dts, "tempdt");
                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable temp = new DataTable();
                    temp = dts.Tables[0];

                    string[] xxid;

                    if (temp.Rows.Count > 0)
                    {
                        //msg.InnerHtml = xid + temp.Rows[0][0].ToString();
                        permission = temp.Rows[0][0].ToString();

                        xxid = permission.Split('|');
                        foreach (string id in xxid)
                        {
                            permis.Add(id.Trim());
                        }
                    }

                    /////This is the code for if User permission not set then load menu as role permission
                    else
                    {

                        str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                        SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                        //xid = this.Page.User.Identity.Name;
                        da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);

                        dts.Reset();

                        da1.Fill(dts, "tempdt");
                        DataTable temp1 = new DataTable();
                        temp1 = dts.Tables[0];


                        if (temp1.Rows.Count > 0)
                        {



                            str = "SELECT xpermis FROM ztpermis WHERE xid=@xid and zid=@zid";
                            SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

                            xid = temp1.Rows[0][0].ToString();
                            da2.SelectCommand.Parameters.AddWithValue("@xid", xid);
                            da2.SelectCommand.Parameters.AddWithValue("@zid", zid);

                            dts.Reset();

                            da2.Fill(dts, "tempdt");
                            DataTable temp2 = new DataTable();
                            temp2 = dts.Tables[0];


                            if (temp2.Rows.Count > 0)
                            {
                                permission = temp2.Rows[0][0].ToString();

                                xxid = permission.Split('|');
                                foreach (string id in xxid)
                                {
                                    permis.Add(id.Trim());
                                }
                            }
                            else
                            {
                                Label1.Visible = true;
                                Label1.Text = "You have no permission set yet. Please contact to your system administrator. ";
                            }
                        }
                        else
                        {
                            Label1.Visible = true;
                            Label1.Text = "You are not belong to any role/group. Please contact to your system administrator. ";
                        }


                        da1.Dispose();
                    }
                    conn1.Dispose();
                    da.Dispose();

                    dts.Dispose();

                }


                if (Request.QueryString["subnav"] != null && Request.QueryString["link"] != null)
                {
                    if (Request.QueryString["subnav"].ToString() != "" && Request.QueryString["subnav"].ToString() != String.Empty && Request.QueryString["link"].ToString() != "" && Request.QueryString["link"].ToString() != String.Empty)
                    {
                        //HtmlGenericControl div = (HtmlGenericControl)subnavbar.FindControl(Request.QueryString["subnav"].ToString());
                        //LinkButton link = (LinkButton)navbar.FindControl(Request.QueryString["link"].ToString());
                        //div.Attributes.Add("style", "display:block");
                        //link.Attributes.Add("style", "background-color: #16C1F3;");


                        //Response.Write(Request.QueryString["subnav"].ToString());
                        GetMenuItem(Request.QueryString["subnav"].ToString(), Request.QueryString["link"].ToString());
                    }
                }
                else
                {
                    HttpContext.Current.Session["subnav"] = null;
                    HttpContext.Current.Session["link"] = null;
                    HttpContext.Current.Session["xid"] = null;
                    GetMenuItem("myDropdown1", "LinkButton1");
                }

                if (Request.QueryString["xid"] != "" && Request.QueryString["xid"] != String.Empty)
                {
                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts = new DataSet();


                    dts.Reset();
                    string str = "SELECT xmenunm,xparentid,xid FROM ztmenu ";

                    SqlDataAdapter da = new SqlDataAdapter(str, conn1);


                    da.Fill(dts, "tempdt");
                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable temp = new DataTable();
                    temp = dts.Tables[0];

                    //dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

                    if (temp.Rows.Count > 0)
                    {
                        string xid1 = Request.QueryString["xid"].ToString();
                        List<string> listsitemappath = new List<string>();

                        DataRow[] row = temp.Select("xid='" + xid1 + "'");
                        listsitemappath.Add(row[0]["xmenunm"].ToString());
                        var xparentid1 = row[0]["xparentid"];

                        //HtmlGenericControl span = new HtmlGenericControl("span");
                        //span.InnerHtml = row[0]["xmenunm"].ToString();
                        //sitemappath.Controls.Add(span);

                        //HtmlGenericControl span1 = new HtmlGenericControl("span");
                        //span1.InnerHtml = " &gt; ";
                        //sitemappath.Controls.Add(span1);

                        do
                        {
                            DataRow[] row1 = temp.Select("xid='" + xparentid1.ToString()+"'");
                            listsitemappath.Add(row1[0]["xmenunm"].ToString());

                            xparentid1 = row1[0]["xparentid"];
                        } while (!string.IsNullOrEmpty(xparentid1.ToString()));

                        for (int i = listsitemappath.Count; i > 0; i--)
                        {
                            HtmlGenericControl span = new HtmlGenericControl("span");
                            span.InnerHtml = listsitemappath[i - 1].ToString();
                            sitemappath.Controls.Add(span);
                            if (i > 1)
                            {
                                HtmlGenericControl span1 = new HtmlGenericControl("span");
                                span1.InnerHtml = " &gt; ";
                                sitemappath.Controls.Add(span1);
                            }
                        }
                    }
                    else
                    {
                        sitemappath.Controls.Clear();
                    }

                    conn1.Dispose();
                    dts.Dispose();
                    da.Dispose();
                    temp.Dispose();
                }
                else
                {
                    sitemappath.Controls.Clear();
                }

                if (Convert.ToString(HttpContext.Current.Session["curuser"]) != "bm")
                {
                    if (Request.QueryString["xid"] != "" && Request.QueryString["xid"] != String.Empty)
                    {
                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        DataSet dts = new DataSet();

                        dts.Reset();
                        string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";

                        SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                        string xid = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        da.SelectCommand.Parameters.AddWithValue("@xid", xid);

                        da.Fill(dts, "tempdt");
                        DataTable temp = new DataTable();
                        temp = dts.Tables[0];

                        string[] permis2;

                        if (temp.Rows.Count > 0)
                        {
                            string permission111 = temp.Rows[0][0].ToString();

                            permis2 = permission111.Split('|');

                            bool c = false;
                            for (int i = 0; i < permis2.Length; i++)
                            {
                                if (permis2[i] == Request.QueryString["xid"].ToString())
                                {
                                    c = true;
                                    break;
                                }
                            }

                            if (!c)
                            {
                                Response.Redirect("~/Default.aspx?subnav=myDropdown1&link=LinkButton1");
                            }
                        }
                        else
                        {
                            str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                            SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                            //xid = this.Page.User.Identity.Name;
                            da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);

                            dts.Reset();

                            da1.Fill(dts, "tempdt");
                            DataTable temp1 = new DataTable();
                            temp1 = dts.Tables[0];

                            if (temp1.Rows.Count > 0)
                            {
                                str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";
                                SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

                                xid = temp1.Rows[0][0].ToString();
                                da2.SelectCommand.Parameters.AddWithValue("@xid", xid);

                                dts.Reset();

                                da2.Fill(dts, "tempdt");
                                DataTable temp2 = new DataTable();
                                temp2 = dts.Tables[0];

                                if (temp2.Rows.Count > 0)
                                {
                                    string permission222 = temp2.Rows[0][0].ToString();

                                    permis2 = permission222.Split('|');

                                    bool c = false;
                                    for (int i = 0; i < permis2.Length; i++)
                                    {
                                        if (permis2[i] == Request.QueryString["xid"].ToString())
                                        {
                                            c = true;
                                            break;
                                        }
                                    }

                                    if (!c)
                                    {
                                        Response.Redirect("~/Default.aspx?subnav=myDropdown1&link=LinkButton1");
                                    }
                                }
                            }
                        }
                       
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx?subnav=myDropdown1&link=LinkButton1");
                    }
                }


                //Button Level Permission Check
               fnButtonLevelPermissionCheck(MainContent.Controls);
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                // Response.Write(exp.Message);
            }


        }

        private void fnButtonLevelPermissionCheck(ControlCollection controlCollection)
        {
            if (Convert.ToString(HttpContext.Current.Session["curuser"]) == "bm")
            {
                return;
            }

            foreach (Control control in controlCollection)
            {
                if (control is Button)
                {
                    

                    if (Request.QueryString["xid"] != "" && Request.QueryString["xid"] != String.Empty)
                    {
                       
                        string xid1 = Request.QueryString["xid"].ToString();

                        string xvoucher1 = Request.QueryString["xvoucher"] != null ? Request.QueryString["xvoucher"].ToString() : "";

                        if (((Button)control).Text == "Post" && xvoucher1 == "" && xid1 != "170014001")
                        {
                            ((Button)control).Visible = false;
                        }

                        if (xid1 == "175010001" || xid1 == "175010005" || xid1 == "175010010" )
                        {
                            string ximtmptrn1 = Request.QueryString["ximtmptrn"] != null ? Request.QueryString["ximtmptrn"].ToString() : "";

                            //if (((Button)control).Text == "Confirm" && ximtmptrn1 == "")
                            //{
                            //    ((Button)control).Visible = false;
                            //}

                            if (((Button)control).Text == "Undo" && Convert.ToString(HttpContext.Current.Session["curuser"]).ToLower() != "noyeem")
                            {
                                ((Button)control).Visible = false;
                            }

                            
                        }

                        if (((Button)control).Text == "Post" && xid1 == "175005005")
                        {
                            ((Button)control).Visible = true;
                        }

                        if (xid1 == "180010001" || xid1 == "180010005" || xid1 == "180015001" || xid1 == "180015005" || xid1 == "180020001" || xid1 == "180020005")
                        {
                            //string ximtmptrn1 = Request.QueryString["ximtmptrn"] != null ? Request.QueryString["ximtmptrn"].ToString() : "";

                            //if (((Button)control).Text == "Confirm" && ximtmptrn1 == "")
                            //{
                            //    ((Button)control).Visible = false;
                            //}

                            if (((Button)control).Text == "Undo" && !(Convert.ToString(HttpContext.Current.Session["curuser"]).ToLower() == "mak" || Convert.ToString(HttpContext.Current.Session["curuser"]).ToLower() == "jasimaccounts"))
                            {
                                ((Button)control).Visible = false;
                            }
                        }

                        if (xid1 == "125003")
                        {
                            

                            //if (((Button)control).Text == "Confirm" && ximtmptrn1 == "")
                            //{
                            //    ((Button)control).Visible = false;
                            //}

                            if (((Button)control).Text == "Undo" && Convert.ToString(HttpContext.Current.Session["curuser"]).ToLower() != "sakawat")
                            {
                                ((Button)control).Visible = false;
                            }
                        }

                        if (xid1 == "115005001")
                        {
                            

                            if (((Button)control).Text == "Delete")
                            {
                                ((Button)control).Visible = false;
                            }
                        }
                    }
                }

                if (control.Controls != null)
                {
                    fnButtonLevelPermissionCheck(control.Controls);
                }
            }
        }


        DataTable dtRootMenuURl = new DataTable();

        private void GetMenuItem(string subnav, string link)
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xid,xmenunm,xurl,xparentid,xvalue,xtarget,coalesce(ximage,'') as ximage FROM ztmenu order by convert(int,xid)";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable temp = new DataTable();
            temp = dts.Tables[0];

            dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

            dtRootMenuURl.Columns.Add("link");
            dtRootMenuURl.Columns.Add("url");
            dtRootMenuURl.Rows.Clear();
            int id = 1;
            foreach (DataRow level1DataRows in dts.Tables[0].Rows)
            {
                string mnuid = level1DataRows["xid"].ToString();


                if (Convert.ToString(HttpContext.Current.Session["curuser"]) == "bm")
                {
                    if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
                    {
                        MenuItem parentitem = new MenuItem();
                        //parentitem.Text = level1DataRows["xmenunm"].ToString();
                        //parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                        //parentitem.Value = level1DataRows["xvalue"].ToString();
                        //parentitem.Target = level1DataRows["xtarget"].ToString();

                        if (level1DataRows.GetChildRows("ChildRows").Length > 0)
                        {
                            //HtmlGenericControl div1 = new HtmlGenericControl("div");
                            //HtmlGenericControl button = new HtmlGenericControl("button");
                            //HtmlGenericControl div2 = new HtmlGenericControl("div");

                            //div1.Attributes["class"] = "dropdown";
                            //button.Attributes["class"] = "dropbtn";
                            //button.Attributes["onclick"] = "myFunction()";
                            //button.Attributes["type"] = "button";
                            //button.Attributes["id"] = "myButton-" + id.ToString();
                            //div2.Attributes["class"] = "dropdown-content";
                            //div2.Attributes["id"] = "myDropdown" + id.ToString();

                            //Label mylbl = new Label();


                            //mylbl.Text =  level1DataRows["xmenunm"].ToString();
                            //button.Controls.Add(mylbl);

                            //navbar.Controls.Add(div1);
                            //div1.Controls.Add(button);
                            //div1.Controls.Add(div2);
                            // GetChildRows(level1DataRows, div2,1);

                            LinkButton lnkbtn = new LinkButton();
                            lnkbtn.ID = "LinkButton" + id.ToString();
                            lnkbtn.Attributes.Add("runat", "server");
                            lnkbtn.Click += fnRootMenuEvt;
                            lnkbtn.Text = level1DataRows["xmenunm"].ToString();
                            dtRootMenuURl.Rows.Add(lnkbtn.ID.ToString(), level1DataRows["xurl"].ToString());


                            navbar.Controls.Add(lnkbtn);

                            HtmlGenericControl div = new HtmlGenericControl("div");
                            div.Attributes["class"] = "dropdown-content";
                            div.Attributes["id"] = "myDropdown" + id.ToString();
                            div.Attributes.Add("runat", "server");

                            if (link != "" && subnav != "")
                            {
                                if (link.Substring(10) == id.ToString())
                                {
                                    lnkbtn.Attributes.Add("style", "background-color: #16C1F3;");
                                    div.Attributes.Add("style", "display:block");
                                }
                            }

                            subnavbar.Controls.Add(div);

                            GetChildRows(level1DataRows, div, 1);
                        }
                        else
                        {
                            //HtmlGenericControl a = new HtmlGenericControl("a");

                            //a.Attributes["href"] = level1DataRows["xurl"].ToString();
                            //=



                            //if (level1DataRows["ximage"].ToString() == "")
                            //{
                            //    Label mylbl = new Label();
                            //    mylbl.Text = level1DataRows["xmenunm"].ToString();
                            //    a.Controls.Add(mylbl);
                            //}
                            //else
                            //{
                            //    HtmlGenericControl img = new HtmlGenericControl("img");
                            //    img.Attributes["src"] = level1DataRows["ximage"].ToString();
                            //    img.Attributes["style"] = "width:16px; height:16px;";
                            //    a.Controls.Add(img);
                            //}

                            //navbar.Controls.Add(a);




                            LinkButton lnkbtn = new LinkButton();
                            lnkbtn.ID = "LinkButton" + id.ToString();
                            lnkbtn.Attributes.Add("runat", "server");
                            lnkbtn.Click += fnRootMenuEvt;
                            dtRootMenuURl.Rows.Add(lnkbtn.ID.ToString(), level1DataRows["xurl"].ToString());

                            if (level1DataRows["ximage"].ToString() == "")
                            {
                                lnkbtn.Text = level1DataRows["xmenunm"].ToString();
                            }
                            else
                            {
                                HtmlGenericControl img = new HtmlGenericControl("img");
                                img.Attributes["src"] = level1DataRows["ximage"].ToString();
                                img.Attributes["style"] = "width:16px; height:16px;";
                                lnkbtn.Controls.Add(img);
                            }

                            navbar.Controls.Add(lnkbtn);

                            HtmlGenericControl div = new HtmlGenericControl("div");
                            div.Attributes["class"] = "dropdown-content";
                            div.Attributes["id"] = "myDropdown" + id.ToString();
                            div.Attributes.Add("runat", "server");

                            if (link != "" && subnav != "")
                            {
                                if (link.Substring(10) == id.ToString())
                                {
                                    lnkbtn.Attributes.Add("style", "background-color: #16C1F3;");
                                    div.Attributes.Add("style", "display:block");
                                }
                            }

                            HtmlGenericControl a = new HtmlGenericControl("a");
                            a.Attributes.Add("href", "javascript:void(0)");
                            div.Controls.Add(a);

                            HtmlGenericControl font = new HtmlGenericControl("font");
                            font.Attributes.Add("style", "color: #16C1F3");
                            a.Controls.Add(font);
                            Label lbl = new Label();
                            lbl.Text = ".";
                            font.Controls.Add(lbl);

                            subnavbar.Controls.Add(div);



                        }


                        //Check for cancel request

                        //if (parentitem.Text == "CANCEL")
                        //{
                        //    SqlConnection conn11;
                        //    conn11 = new SqlConnection(zglobal.constring);
                        //    DataSet dts11 = new DataSet();


                        //    dts11.Reset();
                        //    string str11 = "SELECT count(*) FROM ztcancelreq  WHERE xstatus='pending'";
                        //    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                        //    da11.Fill(dts11, "tempztcode");
                        //    //DataView dv = new DataView(dts.Tables[0]);
                        //    DataTable dtztcode = new DataTable();
                        //    dtztcode = dts11.Tables[0];
                        //    if (dtztcode.Rows[0][0].ToString() != "0")
                        //    {
                        //        parentitem.Text = "CANCEL (" + dtztcode.Rows[0][0].ToString() + ")";
                        //    }

                        //    dts11.Dispose();
                        //    dtztcode.Dispose();
                        //    da11.Dispose();
                        //    conn11.Dispose();

                        //}
                        //if (parentitem.Text == "TIC. APPROVAL")
                        //{
                        //    SqlConnection conn11;
                        //    conn11 = new SqlConnection(zglobal.constring);
                        //    DataSet dts11 = new DataSet();


                        //    dts11.Reset();
                        //    string str11 = "SELECT count(*) FROM ztmanticapppen  WHERE xstatus='pending'";
                        //    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                        //    da11.Fill(dts11, "tempztcode");
                        //    //DataView dv = new DataView(dts.Tables[0]);
                        //    DataTable dtztcode = new DataTable();
                        //    dtztcode = dts11.Tables[0];
                        //    if (dtztcode.Rows[0][0].ToString() != "0")
                        //    {
                        //        parentitem.Text = "TIC. APPROVAL (" + dtztcode.Rows[0][0].ToString() + ")";
                        //    }

                        //    dts11.Dispose();
                        //    dtztcode.Dispose();
                        //    da11.Dispose();
                        //    conn11.Dispose();

                        //}

                        //bmmenu.Items.Add(parentitem);
                    }
                }
                else
                {
                    foreach (string mpermis in permis)
                    {


                        if (mpermis.Trim() == mnuid.Trim())
                        {
                            ////if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
                            ////{
                            ////    MenuItem parentitem = new MenuItem();
                            ////    //parentitem.Text = level1DataRows["xmenunm"].ToString();
                            ////    //parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                            ////    //parentitem.Value = level1DataRows["xvalue"].ToString();
                            ////    //parentitem.Target = level1DataRows["xtarget"].ToString();

                            ////    if (level1DataRows.GetChildRows("ChildRows").Length > 0)
                            ////    {
                            ////        //HtmlGenericControl div1 = new HtmlGenericControl("div");
                            ////        //HtmlGenericControl button = new HtmlGenericControl("button");
                            ////        //HtmlGenericControl div2 = new HtmlGenericControl("div");

                            ////        //div1.Attributes["class"] = "dropdown";
                            ////        //button.Attributes["class"] = "dropbtn";
                            ////        //button.Attributes["onclick"] = "myFunction()";
                            ////        //button.Attributes["type"] = "button";
                            ////        //div2.Attributes["class"] = "dropdown-content";
                            ////        //div2.Attributes["id"] = "myDropdown" + id.ToString();

                            ////        //Label mylbl = new Label();


                            ////        //mylbl.Text = level1DataRows["xmenunm"].ToString();
                            ////        //button.Controls.Add(mylbl);

                            ////        //navbar.Controls.Add(div1);
                            ////        //div1.Controls.Add(button);
                            ////        //div1.Controls.Add(div2);
                            ////        //GetChildRows(level1DataRows, div2, 1);

                            ////        LinkButton lnkbtn = new LinkButton();
                            ////        lnkbtn.ID = "LinkButton" + id.ToString();
                            ////        lnkbtn.Attributes.Add("runat", "server");
                            ////        lnkbtn.Click += fnRootMenuEvt;
                            ////        lnkbtn.Text = level1DataRows["xmenunm"].ToString();
                            ////        dtRootMenuURl.Rows.Add(lnkbtn.ID.ToString(), level1DataRows["xurl"].ToString());


                            ////        navbar.Controls.Add(lnkbtn);

                            ////        HtmlGenericControl div = new HtmlGenericControl("div");
                            ////        div.Attributes["class"] = "dropdown-content";
                            ////        div.Attributes["id"] = "myDropdown" + id.ToString();
                            ////        div.Attributes.Add("runat", "server");

                            ////        if (link != "" && subnav != "")
                            ////        {
                            ////            if (link.Substring(10) == id.ToString())
                            ////            {
                            ////                lnkbtn.Attributes.Add("style", "background-color: #16C1F3;");
                            ////                div.Attributes.Add("style", "display:block");
                            ////            }
                            ////        }

                            ////        subnavbar.Controls.Add(div);

                            ////        GetChildRows(level1DataRows, div, 1);


                            ////    }
                            ////    else
                            ////    {
                            ////        //HtmlGenericControl a = new HtmlGenericControl("a");

                            ////        //a.Attributes["href"] = level1DataRows["xurl"].ToString();

                            ////        //if (level1DataRows["ximage"].ToString() == "")
                            ////        //{
                            ////        //    Label mylbl = new Label();
                            ////        //    mylbl.Text = level1DataRows["xmenunm"].ToString();
                            ////        //    a.Controls.Add(mylbl);
                            ////        //}
                            ////        //else
                            ////        //{
                            ////        //    HtmlGenericControl img = new HtmlGenericControl("img");
                            ////        //    img.Attributes["src"] = level1DataRows["ximage"].ToString();
                            ////        //    img.Attributes["style"] = "width:20px; height:20px;";
                            ////        //    a.Controls.Add(img);
                            ////        //}


                            ////        //navbar.Controls.Add(a);

                            ////        LinkButton lnkbtn = new LinkButton();
                            ////        lnkbtn.ID = "LinkButton" + id.ToString();
                            ////        lnkbtn.Attributes.Add("runat", "server");
                            ////        lnkbtn.Click += fnRootMenuEvt;
                            ////        dtRootMenuURl.Rows.Add(lnkbtn.ID.ToString(), level1DataRows["xurl"].ToString());

                            ////        if (level1DataRows["ximage"].ToString() == "")
                            ////        {
                            ////            lnkbtn.Text = level1DataRows["xmenunm"].ToString();
                            ////        }
                            ////        else
                            ////        {
                            ////            HtmlGenericControl img = new HtmlGenericControl("img");
                            ////            img.Attributes["src"] = level1DataRows["ximage"].ToString();
                            ////            img.Attributes["style"] = "width:16px; height:16px;";
                            ////            lnkbtn.Controls.Add(img);
                            ////        }

                            ////        navbar.Controls.Add(lnkbtn);

                            ////        HtmlGenericControl div = new HtmlGenericControl("div");
                            ////        div.Attributes["class"] = "dropdown-content";
                            ////        div.Attributes["id"] = "myDropdown" + id.ToString();
                            ////        div.Attributes.Add("runat", "server");

                            ////        if (link != "" && subnav != "")
                            ////        {
                            ////            if (link.Substring(10) == id.ToString())
                            ////            {
                            ////                lnkbtn.Attributes.Add("style", "background-color: #16C1F3;");
                            ////                div.Attributes.Add("style", "display:block");
                            ////            }
                            ////        }

                            ////        HtmlGenericControl a = new HtmlGenericControl("a");
                            ////        a.Attributes.Add("href", "javascript:void(0)");
                            ////        div.Controls.Add(a);
                            ////        HtmlGenericControl font = new HtmlGenericControl("font");
                            ////        font.Attributes.Add("style", "color: #16C1F3");
                            ////        a.Controls.Add(font);
                            ////        Label lbl = new Label();
                            ////        lbl.Text = ".";
                            ////        font.Controls.Add(lbl);
                            ////        subnavbar.Controls.Add(div);


                            ////        subnavbar.Controls.Add(div);

                            ////    }

                            ////    //Check for cancel request

                            ////    //if (parentitem.Text == "CANCEL")
                            ////    //{
                            ////    //    SqlConnection conn11;
                            ////    //    conn11 = new SqlConnection(zglobal.constring);
                            ////    //    DataSet dts11 = new DataSet();


                            ////    //    dts11.Reset();
                            ////    //    string str11 = "SELECT count(*) FROM ztcancelreq  WHERE xstatus='pending'";
                            ////    //    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                            ////    //    da11.Fill(dts11, "tempztcode");
                            ////    //    //DataView dv = new DataView(dts.Tables[0]);
                            ////    //    DataTable dtztcode = new DataTable();
                            ////    //    dtztcode = dts11.Tables[0];
                            ////    //    if (dtztcode.Rows[0][0].ToString() != "0")
                            ////    //    {
                            ////    //        parentitem.Text = "CANCEL (" + dtztcode.Rows[0][0].ToString() + ")";
                            ////    //    }

                            ////    //    dts11.Dispose();
                            ////    //    dtztcode.Dispose();
                            ////    //    da11.Dispose();
                            ////    //    conn11.Dispose();

                            ////    //}
                            ////    //if (parentitem.Text == "TIC. APPROVAL")
                            ////    //{
                            ////    //    SqlConnection conn11;
                            ////    //    conn11 = new SqlConnection(zglobal.constring);
                            ////    //    DataSet dts11 = new DataSet();


                            ////    //    dts11.Reset();
                            ////    //    string str11 = "SELECT count(*) FROM ztmanticapppen  WHERE xstatus='pending'";
                            ////    //    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                            ////    //    da11.Fill(dts11, "tempztcode");
                            ////    //    //DataView dv = new DataView(dts.Tables[0]);
                            ////    //    DataTable dtztcode = new DataTable();
                            ////    //    dtztcode = dts11.Tables[0];
                            ////    //    if (dtztcode.Rows[0][0].ToString() != "0")
                            ////    //    {
                            ////    //        parentitem.Text = "TIC. APPROVAL (" + dtztcode.Rows[0][0].ToString() + ")";
                            ////    //    }

                            ////    //    dts11.Dispose();
                            ////    //    dtztcode.Dispose();
                            ////    //    da11.Dispose();
                            ////    //    conn11.Dispose();

                            ////    //}

                            ////    //bmmenu.Items.Add(parentitem);
                            ////}

                            if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
                            {
                                MenuItem parentitem = new MenuItem();
                                //parentitem.Text = level1DataRows["xmenunm"].ToString();
                                //parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                                //parentitem.Value = level1DataRows["xvalue"].ToString();
                                //parentitem.Target = level1DataRows["xtarget"].ToString();

                                if (level1DataRows.GetChildRows("ChildRows").Length > 0)
                                {
                                    //HtmlGenericControl div1 = new HtmlGenericControl("div");
                                    //HtmlGenericControl button = new HtmlGenericControl("button");
                                    //HtmlGenericControl div2 = new HtmlGenericControl("div");

                                    //div1.Attributes["class"] = "dropdown";
                                    //button.Attributes["class"] = "dropbtn";
                                    //button.Attributes["onclick"] = "myFunction()";
                                    //button.Attributes["type"] = "button";
                                    //button.Attributes["id"] = "myButton-" + id.ToString();
                                    //div2.Attributes["class"] = "dropdown-content";
                                    //div2.Attributes["id"] = "myDropdown" + id.ToString();

                                    //Label mylbl = new Label();


                                    //mylbl.Text =  level1DataRows["xmenunm"].ToString();
                                    //button.Controls.Add(mylbl);

                                    //navbar.Controls.Add(div1);
                                    //div1.Controls.Add(button);
                                    //div1.Controls.Add(div2);
                                    // GetChildRows(level1DataRows, div2,1);

                                    LinkButton lnkbtn = new LinkButton();
                                    lnkbtn.ID = "LinkButton" + id.ToString();
                                    lnkbtn.Attributes.Add("runat", "server");
                                    lnkbtn.Click += fnRootMenuEvt;
                                    lnkbtn.Text = level1DataRows["xmenunm"].ToString();
                                    dtRootMenuURl.Rows.Add(lnkbtn.ID.ToString(), level1DataRows["xurl"].ToString());


                                    navbar.Controls.Add(lnkbtn);

                                    HtmlGenericControl div = new HtmlGenericControl("div");
                                    div.Attributes["class"] = "dropdown-content";
                                    div.Attributes["id"] = "myDropdown" + id.ToString();
                                    div.Attributes.Add("runat", "server");

                                    if (link != "" && subnav != "")
                                    {
                                        if (link.Substring(10) == id.ToString())
                                        {
                                            lnkbtn.Attributes.Add("style", "background-color: #16C1F3;");
                                            div.Attributes.Add("style", "display:block");
                                        }
                                    }

                                    subnavbar.Controls.Add(div);

                                    GetChildRows(level1DataRows, div, 1);
                                }
                                else
                                {
                                    //HtmlGenericControl a = new HtmlGenericControl("a");

                                    //a.Attributes["href"] = level1DataRows["xurl"].ToString();
                                    //=



                                    //if (level1DataRows["ximage"].ToString() == "")
                                    //{
                                    //    Label mylbl = new Label();
                                    //    mylbl.Text = level1DataRows["xmenunm"].ToString();
                                    //    a.Controls.Add(mylbl);
                                    //}
                                    //else
                                    //{
                                    //    HtmlGenericControl img = new HtmlGenericControl("img");
                                    //    img.Attributes["src"] = level1DataRows["ximage"].ToString();
                                    //    img.Attributes["style"] = "width:16px; height:16px;";
                                    //    a.Controls.Add(img);
                                    //}

                                    //navbar.Controls.Add(a);




                                    LinkButton lnkbtn = new LinkButton();
                                    lnkbtn.ID = "LinkButton" + id.ToString();
                                    lnkbtn.Attributes.Add("runat", "server");
                                    lnkbtn.Click += fnRootMenuEvt;
                                    dtRootMenuURl.Rows.Add(lnkbtn.ID.ToString(), level1DataRows["xurl"].ToString());

                                    if (level1DataRows["ximage"].ToString() == "")
                                    {
                                        lnkbtn.Text = level1DataRows["xmenunm"].ToString();
                                    }
                                    else
                                    {
                                        HtmlGenericControl img = new HtmlGenericControl("img");
                                        img.Attributes["src"] = level1DataRows["ximage"].ToString();
                                        img.Attributes["style"] = "width:16px; height:16px;";
                                        lnkbtn.Controls.Add(img);
                                    }

                                    navbar.Controls.Add(lnkbtn);

                                    HtmlGenericControl div = new HtmlGenericControl("div");
                                    div.Attributes["class"] = "dropdown-content";
                                    div.Attributes["id"] = "myDropdown" + id.ToString();
                                    div.Attributes.Add("runat", "server");

                                    if (link != "" && subnav != "")
                                    {
                                        if (link.Substring(10) == id.ToString())
                                        {
                                            lnkbtn.Attributes.Add("style", "background-color: #16C1F3;");
                                            div.Attributes.Add("style", "display:block");
                                        }
                                    }

                                    HtmlGenericControl a = new HtmlGenericControl("a");
                                    a.Attributes.Add("href", "javascript:void(0)");
                                    div.Controls.Add(a);

                                    HtmlGenericControl font = new HtmlGenericControl("font");
                                    font.Attributes.Add("style", "color: #16C1F3");
                                    a.Controls.Add(font);
                                    Label lbl = new Label();
                                    lbl.Text = ".";
                                    font.Controls.Add(lbl);

                                    subnavbar.Controls.Add(div);

                                }


                                //Check for cancel request

                                //if (parentitem.Text == "CANCEL")
                                //{
                                //    SqlConnection conn11;
                                //    conn11 = new SqlConnection(zglobal.constring);
                                //    DataSet dts11 = new DataSet();


                                //    dts11.Reset();
                                //    string str11 = "SELECT count(*) FROM ztcancelreq  WHERE xstatus='pending'";
                                //    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                                //    da11.Fill(dts11, "tempztcode");
                                //    //DataView dv = new DataView(dts.Tables[0]);
                                //    DataTable dtztcode = new DataTable();
                                //    dtztcode = dts11.Tables[0];
                                //    if (dtztcode.Rows[0][0].ToString() != "0")
                                //    {
                                //        parentitem.Text = "CANCEL (" + dtztcode.Rows[0][0].ToString() + ")";
                                //    }

                                //    dts11.Dispose();
                                //    dtztcode.Dispose();
                                //    da11.Dispose();
                                //    conn11.Dispose();

                                //}
                                //if (parentitem.Text == "TIC. APPROVAL")
                                //{
                                //    SqlConnection conn11;
                                //    conn11 = new SqlConnection(zglobal.constring);
                                //    DataSet dts11 = new DataSet();


                                //    dts11.Reset();
                                //    string str11 = "SELECT count(*) FROM ztmanticapppen  WHERE xstatus='pending'";
                                //    SqlDataAdapter da11 = new SqlDataAdapter(str11, conn11);
                                //    da11.Fill(dts11, "tempztcode");
                                //    //DataView dv = new DataView(dts.Tables[0]);
                                //    DataTable dtztcode = new DataTable();
                                //    dtztcode = dts11.Tables[0];
                                //    if (dtztcode.Rows[0][0].ToString() != "0")
                                //    {
                                //        parentitem.Text = "TIC. APPROVAL (" + dtztcode.Rows[0][0].ToString() + ")";
                                //    }

                                //    dts11.Dispose();
                                //    dtztcode.Dispose();
                                //    da11.Dispose();
                                //    conn11.Dispose();

                                //}

                                //bmmenu.Items.Add(parentitem);
                            }

                            break;
                        }

                    }
                }

                id = id + 1;
            }

            conn1.Dispose();
            da.Dispose();
            dts.Dispose();
        }

        private void GetChildRows(DataRow dataRow, HtmlGenericControl htmlctl, int l)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");

            string subnav1 = HttpContext.Current.Session["subnav"] == null
                ? "myDropdown1"
                : HttpContext.Current.Session["subnav"].ToString();
            string link1 = HttpContext.Current.Session["link"] == null
                ? "LinkButton1"
                : HttpContext.Current.Session["link"].ToString();

            foreach (DataRow childRow in childRows)
            {
                MenuItem childitem = new MenuItem();
                string childid = childRow["xid"].ToString();
                if (Convert.ToString(HttpContext.Current.Session["curuser"]) == "bm")
                {
                    //childitem.Text = childRow["xmenunm"].ToString();
                    //childitem.NavigateUrl = childRow["xurl"].ToString();
                    //childitem.Value = childRow["xvalue"].ToString();
                    //childitem.Target = childRow["xtarget"].ToString();
                    //mnitem.ChildItems.Add(childitem);
                    if (childRow.GetChildRows("ChildRows").Length > 0)
                    {
                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        HtmlGenericControl button = new HtmlGenericControl("button");
                        HtmlGenericControl div2 = new HtmlGenericControl("div");
                        HtmlGenericControl i = new HtmlGenericControl("i");

                        div1.Attributes["class"] = "dropdown" + l.ToString();
                        button.Attributes["class"] = "dropbtn" + l.ToString();
                        div2.Attributes["class"] = "dropdown-content" + l.ToString();
                        if (l == 1)
                        {
                            i.Attributes["class"] = "fa fa-caret-down";
                        }
                        else
                        {
                            i.Attributes["class"] = "fa fa-caret-right";
                        }


                        Label mylbl = new Label();


                        mylbl.Text = childRow["xmenunm"].ToString() + " ";
                        button.Controls.Add(mylbl);
                        button.Controls.Add(i);

                        htmlctl.Controls.Add(div1);
                        div1.Controls.Add(button);
                        div1.Controls.Add(div2);

                        GetChildRows(childRow, div2, l + 1);

                    }
                    else
                    {
                        HtmlGenericControl a = new HtmlGenericControl("a");

                        if (childRow["xurl"].ToString().Contains("?"))
                        {
                            a.Attributes["href"] = childRow["xurl"].ToString() + "&subnav=" + subnav1 + "&link=" + link1 + "&xid=" + childRow["xid"].ToString();
                        }
                        else
                        {
                            a.Attributes["href"] = childRow["xurl"].ToString() + "?subnav=" + subnav1 + "&link=" + link1 + "&xid=" + childRow["xid"].ToString();
                        }


                        if (childRow["ximage"].ToString() == "")
                        {
                            Label mylbl = new Label();
                            mylbl.Text = childRow["xmenunm"].ToString();
                            a.Controls.Add(mylbl);
                        }
                        else
                        {
                            HtmlGenericControl img = new HtmlGenericControl("img");
                            img.Attributes["src"] = childRow["ximage"].ToString();
                            img.Attributes["style"] = "width:20px; height:20px;";
                            a.Controls.Add(img);
                        }


                        htmlctl.Controls.Add(a);

                    }
                }
                else
                {
                    foreach (string mpermis in permis)
                    {

                        if (mpermis.Trim() == childid.Trim())
                        {


                            ////childitem.Text = childRow["xmenunm"].ToString();
                            ////childitem.NavigateUrl = childRow["xurl"].ToString();
                            ////childitem.Value = childRow["xvalue"].ToString();
                            ////childitem.Target = childRow["xtarget"].ToString();
                            ////mnitem.ChildItems.Add(childitem);

                            //if (childRow.GetChildRows("ChildRows").Length > 0)
                            //{
                            //    ////HtmlGenericControl div1 = new HtmlGenericControl("div");
                            //    ////HtmlGenericControl button = new HtmlGenericControl("button");
                            //    ////HtmlGenericControl div2 = new HtmlGenericControl("div");
                            //    ////HtmlGenericControl i = new HtmlGenericControl("i");

                            //    ////div1.Attributes["class"] = "dropdown" + l.ToString();
                            //    ////button.Attributes["class"] = "dropbtn" + l.ToString();
                            //    ////div2.Attributes["class"] = "dropdown-content" + l.ToString();
                            //    ////if (l == 1)
                            //    ////{
                            //    ////    i.Attributes["class"] = "fa fa-caret-down";
                            //    ////}
                            //    ////else
                            //    ////{
                            //    ////    i.Attributes["class"] = "fa fa-caret-right";
                            //    ////}


                            //    ////Label mylbl = new Label();


                            //    ////mylbl.Text = childRow["xmenunm"].ToString() + " ";
                            //    ////button.Controls.Add(mylbl);
                            //    ////button.Controls.Add(i);

                            //    ////htmlctl.Controls.Add(div1);
                            //    ////div1.Controls.Add(button);
                            //    ////div1.Controls.Add(div2);

                            //    ////GetChildRows(childRow, div2, l + 1);
                            //    /// 

                            //    HtmlGenericControl div1 = new HtmlGenericControl("div");
                            //    HtmlGenericControl button = new HtmlGenericControl("button");
                            //    HtmlGenericControl div2 = new HtmlGenericControl("div");
                            //    HtmlGenericControl i = new HtmlGenericControl("i");

                            //    div1.Attributes["class"] = "dropdown" + l.ToString();
                            //    button.Attributes["class"] = "dropbtn" + l.ToString();
                            //    div2.Attributes["class"] = "dropdown-content" + l.ToString();
                            //    if (l == 1)
                            //    {
                            //        i.Attributes["class"] = "fa fa-caret-down";
                            //    }
                            //    else
                            //    {
                            //        i.Attributes["class"] = "fa fa-caret-right";
                            //    }


                            //    Label mylbl = new Label();


                            //    mylbl.Text = childRow["xmenunm"].ToString() + " ";
                            //    button.Controls.Add(mylbl);
                            //    button.Controls.Add(i);

                            //    htmlctl.Controls.Add(div1);
                            //    div1.Controls.Add(button);
                            //    div1.Controls.Add(div2);

                            //    GetChildRows(childRow, div2, l + 1);



                            //}
                            //else
                            //{
                            //    //HtmlGenericControl a = new HtmlGenericControl("a");

                            //    //if (childRow["xurl"].ToString().Contains("?"))
                            //    //{
                            //    //    a.Attributes["href"] = childRow["xurl"].ToString() + "&subnav=" + subnav1 + "&link=" + link1;
                            //    //}
                            //    //else
                            //    //{
                            //    //    a.Attributes["href"] = childRow["xurl"].ToString() + "?subnav=" + subnav1 + "&link=" + link1;
                            //    //}

                            //    //if (childRow["ximage"].ToString() == "")
                            //    //{
                            //    //    Label mylbl = new Label();
                            //    //    mylbl.Text = childRow["xmenunm"].ToString();
                            //    //    a.Controls.Add(mylbl);
                            //    //}
                            //    //else
                            //    //{
                            //    //    HtmlGenericControl img = new HtmlGenericControl("img");
                            //    //    img.Attributes["src"] = childRow["ximage"].ToString();
                            //    //    img.Attributes["style"] = "width:20px; height:20px;";
                            //    //    a.Controls.Add(img);
                            //    //}


                            //    //htmlctl.Controls.Add(a);

                            //    HtmlGenericControl a = new HtmlGenericControl("a");

                            //    if (childRow["xurl"].ToString().Contains("?"))
                            //    {
                            //        a.Attributes["href"] = childRow["xurl"].ToString() + "&subnav=" + subnav1 + "&link=" + link1;
                            //    }
                            //    else
                            //    {
                            //        a.Attributes["href"] = childRow["xurl"].ToString() + "?subnav=" + subnav1 + "&link=" + link1;
                            //    }


                            //    if (childRow["ximage"].ToString() == "")
                            //    {
                            //        Label mylbl = new Label();
                            //        mylbl.Text = childRow["xmenunm"].ToString();
                            //        a.Controls.Add(mylbl);
                            //    }
                            //    else
                            //    {
                            //        HtmlGenericControl img = new HtmlGenericControl("img");
                            //        img.Attributes["src"] = childRow["ximage"].ToString();
                            //        img.Attributes["style"] = "width:20px; height:20px;";
                            //        a.Controls.Add(img);
                            //    }


                            //    htmlctl.Controls.Add(a);

                            //}


                            if (childRow.GetChildRows("ChildRows").Length > 0)
                            {
                                HtmlGenericControl div1 = new HtmlGenericControl("div");
                                HtmlGenericControl button = new HtmlGenericControl("button");
                                HtmlGenericControl div2 = new HtmlGenericControl("div");
                                HtmlGenericControl i = new HtmlGenericControl("i");

                                div1.Attributes["class"] = "dropdown" + l.ToString();
                                button.Attributes["class"] = "dropbtn" + l.ToString();
                                div2.Attributes["class"] = "dropdown-content" + l.ToString();
                                if (l == 1)
                                {
                                    i.Attributes["class"] = "fa fa-caret-down";
                                }
                                else
                                {
                                    i.Attributes["class"] = "fa fa-caret-right";
                                }


                                Label mylbl = new Label();


                                mylbl.Text = childRow["xmenunm"].ToString() + " ";
                                button.Controls.Add(mylbl);
                                button.Controls.Add(i);

                                htmlctl.Controls.Add(div1);
                                div1.Controls.Add(button);
                                div1.Controls.Add(div2);

                                GetChildRows(childRow, div2, l + 1);

                            }
                            else
                            {
                                HtmlGenericControl a = new HtmlGenericControl("a");

                                if (childRow["xurl"].ToString().Contains("?"))
                                {
                                    a.Attributes["href"] = childRow["xurl"].ToString() + "&subnav=" + subnav1 + "&link=" + link1 + "&xid=" + childRow["xid"].ToString();
                                }
                                else
                                {
                                    a.Attributes["href"] = childRow["xurl"].ToString() + "?subnav=" + subnav1 + "&link=" + link1 + "&xid=" + childRow["xid"].ToString();
                                }


                                if (childRow["ximage"].ToString() == "")
                                {
                                    Label mylbl = new Label();
                                    mylbl.Text = childRow["xmenunm"].ToString();
                                    a.Controls.Add(mylbl);
                                }
                                else
                                {
                                    HtmlGenericControl img = new HtmlGenericControl("img");
                                    img.Attributes["src"] = childRow["ximage"].ToString();
                                    img.Attributes["style"] = "width:20px; height:20px;";
                                    a.Controls.Add(img);
                                }


                                htmlctl.Controls.Add(a);

                            }




                            break;
                        }

                    }
                }






                //if (childRow.GetChildRows("ChildRows").Length > 0)
                //{
                //    //GetChildRows(childRow, childitem);
                //}
            }
        }

        protected void fnRootMenuEvt(object sender, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session["url"] = null;
                HttpContext.Current.Session["link"] = ((LinkButton)sender).ID.ToString();
                //Response.Write(((LinkButton)sender).ID.ToString().Substring(10));
                HttpContext.Current.Session["subnav"] = "myDropdown" + ((LinkButton)sender).ID.ToString().Substring(10);

                foreach (DataRow row in dtRootMenuURl.Rows)
                {
                    if (row["link"].ToString() == ((LinkButton)sender).ID.ToString())
                    {
                        HttpContext.Current.Session["url"] = row["url"].Equals(DBNull.Value) == true ||
                                                             row["url"].ToString() == ""
                            ? "/Default1.aspx"
                            : row["url"].ToString();
                        break;
                    }
                }

                if (HttpContext.Current.Session["url"] != null)
                {
                    if (HttpContext.Current.Session["url"].ToString().Contains("?"))
                    {
                        Response.Redirect("~" + HttpContext.Current.Session["url"].ToString() + "&subnav=" +
                                     HttpContext.Current.Session["subnav"].ToString() + "&link=" +
                                     HttpContext.Current.Session["link"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~" + HttpContext.Current.Session["url"].ToString() + "?subnav=" +
                                      HttpContext.Current.Session["subnav"].ToString() + "&link=" +
                                      HttpContext.Current.Session["link"].ToString());
                    }
                }

                //if (((LinkButton)sender).ID == "LinkButton1")
                //{

                //    Response.Redirect("~/Default.aspx?subnav=myDropdown1&link=LinkButton1");
                //}
                //else if (((LinkButton)sender).ID == "LinkButton2")
                //{
                //    Response.Redirect("~/Default.aspx?subnav=myDropdown2&link=LinkButton2");
                //}
                //else if (((LinkButton)sender).ID == "LinkButton3")
                //{
                //    Response.Redirect("~/Default.aspx?subnav=myDropdown3&link=LinkButton3");
                //}
                //else if (((LinkButton)sender).ID == "LinkButton4")
                //{
                //    Response.Redirect("~/forms/academic/profile/teacher/teacher.aspx?subnav=myDropdown1&link=LinkButton4");
                //}
                //else if (((LinkButton)sender).ID == "LinkButton5")
                //{
                //    Response.Redirect("~/forms/academic/profile/student/student.aspx?subnav=myDropdown1&link=LinkButton5");
                //}
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
            }

        }

        protected void bmmenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {


        }

        protected void bmmenu_PreRender(object sender, EventArgs e)
        {


        }

        protected void bmmenu_Load(object sender, EventArgs e)
        {

        }


        protected void LoginStatus_LoggedOut(Object sender, System.EventArgs e)
        {

            //try
            //{

            //    fnDelCurSeat();

            //    //Build login history

            //    SqlConnection conn678;
            //    conn678 = new SqlConnection(zglobal.constring);
            //    SqlCommand dataCmd = new SqlCommand();
            //    dataCmd.Connection = conn678;
            //    string query;

            //    query = "UPDATE ztloginhis SET " +
            //                       "xlogout=@xlogout " +
            //                       "WHERE xuser=@xuser AND xlogin=(select max(xlogin) from ztloginhis where xuser=@xuser)";
            //    dataCmd.CommandText = query;

            //    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //    DateTime xlogout1 = DateTime.Now;



            //    dataCmd.Parameters.AddWithValue("@xuser", xuser1);

            //    dataCmd.Parameters.AddWithValue("@xlogout", xlogout1);

            //    conn678.Close();
            //    conn678.Open();
            //    dataCmd.ExecuteNonQuery();
            //    conn678.Close();

            //    /////////////////////
            //}
            //catch (Exception exp)
            //{
            //    Session.Abandon();
            //}

            //Session.Abandon();
            //HttpContext.Current.Session["menu"] = null;
        }

        protected void HeadLoginView_ViewChanged(object sender, EventArgs e)
        {
            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //SqlCommand dataCmd = new SqlCommand();
            //dataCmd.Connection = conn1;
            //string query;

            //query = "DELETE FROM ztcurseat WHERE xuser=@xuser";

            //dataCmd.CommandText = query;

            //string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);

            //dataCmd.Parameters.AddWithValue("@xuser", xuser1);


            //conn1.Close();
            //conn1.Open();
            //dataCmd.ExecuteNonQuery();
            //conn1.Close();

            //dataCmd.Dispose();
            //conn1.Dispose();
        }

        protected void MainContent_Unload(object sender, EventArgs e)
        {
            //fnDelCurSeat();
        }

        private void fnDelCurSeat()
        {
            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "DELETE FROM ztcurseat WHERE xuser=@xuser";

                dataCmd.CommandText = query;

                string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);

                dataCmd.Parameters.AddWithValue("@xuser", xuser1);


                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                dataCmd.Dispose();
                conn1.Dispose();
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
            }
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {

        //SqlConnection conn1;
        //conn1 = new SqlConnection(zglobal.constring);
        //DataSet dts = new DataSet();


        //dts.Reset();
        //string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";

        //SqlDataAdapter da = new SqlDataAdapter(str, conn1);

        //string xid = this.Page.User.Identity.Name;
        //da.SelectCommand.Parameters.AddWithValue("@xid", xid);


        //da.Fill(dts, "tempdt");
        ////DataView dv = new DataView(dts.Tables[0]);
        //DataTable temp = new DataTable();
        //temp = dts.Tables[0];

        //string[] xxid;

        //if (temp.Rows.Count > 0)
        //{
        //    //msg.InnerHtml = xid + temp.Rows[0][0].ToString();
        //    permission = temp.Rows[0][0].ToString();

        //    xxid = permission.Split('|');
        //    foreach (string id in xxid)
        //    {
        //        permis.Add(id.Trim());
        //    }
        //}

        ///////This is the code for if User permission not set then load menu as role permission
        //else
        //{

        //    str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

        //    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

        //    //xid = this.Page.User.Identity.Name;
        //    da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);

        //    dts.Reset();

        //    da1.Fill(dts, "tempdt");
        //    DataTable temp1 = new DataTable();
        //    temp1 = dts.Tables[0];


        //    if (temp1.Rows.Count > 0)
        //    {


        //        str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";
        //        SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

        //        xid = temp1.Rows[0][0].ToString();
        //        da2.SelectCommand.Parameters.AddWithValue("@xid", xid);

        //        dts.Reset();

        //        da2.Fill(dts, "tempdt");
        //        DataTable temp2 = new DataTable();
        //        temp2 = dts.Tables[0];


        //        if (temp2.Rows.Count > 0)
        //        {
        //            permission = temp2.Rows[0][0].ToString();

        //            xxid = permission.Split('|');
        //            foreach (string id in xxid)
        //            {
        //                permis.Add(id.Trim());
        //            }
        //        }
        //        else
        //        {
        //            Label1.Visible = true;
        //            Label1.Text = "You have no permission set yet. Please contact to your system administrator. ";
        //        }
        //    }
        //    else
        //    {
        //        Label1.Visible = true;
        //        Label1.Text = "You are not belong to any role/group. Please contact to your system administrator. ";
        //    }


        //    da1.Dispose();
        //}

        //conn1.Dispose();
        //da.Dispose();

        //dts.Dispose();



        //        GetMenuItem();
        //    }
        //    catch (Exception exp)
        //    {
        //        Label1.Text = exp.Message;
        //    }
        //}

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    bmmenu.Items.Clear();

        //    //    SqlConnection conn1;
        //    //    conn1 = new SqlConnection(zglobal.constring);
        //    //    DataSet dts = new DataSet();


        //    //    dts.Reset();
        //    //    string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";

        //    //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

        //    //    string xid = Convert.ToString(HttpContext.Current.Session["curuser"]); 
        //    //    da.SelectCommand.Parameters.AddWithValue("@xid", xid);


        //    //    da.Fill(dts, "tempdt");
        //    //    //DataView dv = new DataView(dts.Tables[0]);
        //    //    DataTable temp = new DataTable();
        //    //    temp = dts.Tables[0];

        //    //    string[] xxid;

        //    //    if (temp.Rows.Count > 0)
        //    //    {
        //    //        //msg.InnerHtml = xid + temp.Rows[0][0].ToString();
        //    //        permission = temp.Rows[0][0].ToString();

        //    //        xxid = permission.Split('|');
        //    //        foreach (string id in xxid)
        //    //        {
        //    //            permis.Add(id.Trim());
        //    //        }
        //    //    }

        //    //    /////This is the code for if User permission not set then load menu as role permission
        //    //    else
        //    //    {

        //    //        str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

        //    //        SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

        //    //        //xid = this.Page.User.Identity.Name;
        //    //        da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);

        //    //        dts.Reset();

        //    //        da1.Fill(dts, "tempdt");
        //    //        DataTable temp1 = new DataTable();
        //    //        temp1 = dts.Tables[0];


        //    //        if (temp1.Rows.Count > 0)
        //    //        {


        //    //            str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";
        //    //            SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

        //    //            xid = temp1.Rows[0][0].ToString();
        //    //            da2.SelectCommand.Parameters.AddWithValue("@xid", xid);

        //    //            dts.Reset();

        //    //            da2.Fill(dts, "tempdt");
        //    //            DataTable temp2 = new DataTable();
        //    //            temp2 = dts.Tables[0];


        //    //            if (temp2.Rows.Count > 0)
        //    //            {
        //    //                permission = temp2.Rows[0][0].ToString();

        //    //                xxid = permission.Split('|');
        //    //                foreach (string id in xxid)
        //    //                {
        //    //                    permis.Add(id.Trim());
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                Label1.Visible = true;
        //    //                Label1.Text = "You have no permission set yet. Please contact to your system administrator. ";
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            Label1.Visible = true;
        //    //            Label1.Text = "You are not belong to any role/group. Please contact to your system administrator. ";
        //    //        }


        //    //        da1.Dispose();
        //    //    }

        //    //    conn1.Dispose();
        //    //    da.Dispose();

        //    //    dts.Dispose();

        //    //    GetMenuItem();
        //    //}
        //    //catch (Exception exp)
        //    //{
        //    //    Label1.Text = exp.Message;
        //    //}
        //}

        // protected void Timer2_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        fnDelCurSeat();

        //        //Build login history

        //        SqlConnection conn678;
        //        conn678 = new SqlConnection(zglobal.constring);
        //        SqlCommand dataCmd = new SqlCommand();
        //        dataCmd.Connection = conn678;
        //        string query;

        //        query = "UPDATE ztloginhis SET " +
        //                           "xlogout=@xlogout " +
        //                           "WHERE xuser=@xuser AND xlogin=(select max(xlogin) from ztloginhis where xuser=@xuser)";
        //        dataCmd.CommandText = query;

        //        string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
        //        DateTime xlogout1 = DateTime.Now;



        //        dataCmd.Parameters.AddWithValue("@xuser", xuser1);

        //        dataCmd.Parameters.AddWithValue("@xlogout", xlogout1);

        //        conn678.Close();
        //        conn678.Open();
        //        dataCmd.ExecuteNonQuery();
        //        conn678.Close();

        //        /////////////////////
        //        Session.Abandon();
        //        FormsAuthentication.SignOut();
        //        FormsAuthentication.RedirectToLoginPage();

        //    }
        //    catch (Exception exp)
        //    {
        //        Session.Abandon();
        //        FormsAuthentication.SignOut();
        //        FormsAuthentication.RedirectToLoginPage();
        //    }
        //}


        public string fnChkPagePermis(string pageName)
        {


            try
            {

                string result = "y";

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                string xid = Convert.ToString(HttpContext.Current.Session["curuser"]);
                da.SelectCommand.Parameters.AddWithValue("@xid", xid);


                da.Fill(dts, "tempdt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable temp = new DataTable();
                temp = dts.Tables[0];

                string[] permis2;

                if (temp.Rows.Count > 0)
                {
                    //msg.InnerHtml = xid + temp.Rows[0][0].ToString();
                    string permission111 = temp.Rows[0][0].ToString();

                    permis2 = permission111.Split('|');


                    //////////////////////////////////////////////

                    if (pageName == "ztroute")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "10")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztcoach")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "11")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztfare")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "12")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "zttrip")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "13")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztrole")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "17")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztuser")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "18")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztcounter")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "19")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "prmst")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "20")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztcity")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "21")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztdriver")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "22")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztdesig")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "23")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "vmvech")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "30")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztbusexch")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "31")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztreceive")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "32")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztissue")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "33")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "saledetails")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "34")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztbooking")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "4")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "cancelparam")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "41")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "mansaleparam")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "42")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztreservehistory")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "43")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztmanticapppen")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "44")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztloginhis")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "45")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "vahicleparam")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "46")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztcancelreq")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "5")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztsales")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "8")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "driverinfoparam")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "47")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztruncostsetup")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "49")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztruncost")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "50")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else if (pageName == "ztdisc")
                    {
                        bool c = false;
                        for (int i = 0; i < permis2.Length; i++)
                        {
                            if (permis2[i] == "51")
                            {
                                c = true;
                                break;
                            }
                        }

                        if (!c)
                        {
                            result = "n";
                        }
                    }
                    else
                    {

                    }


                    /////////////////////////////////////////////////
                }
                else
                {
                    str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                    //xid = this.Page.User.Identity.Name;
                    da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);

                    dts.Reset();

                    da1.Fill(dts, "tempdt");
                    DataTable temp1 = new DataTable();
                    temp1 = dts.Tables[0];


                    if (temp1.Rows.Count > 0)
                    {


                        str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";
                        SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

                        xid = temp1.Rows[0][0].ToString();
                        da2.SelectCommand.Parameters.AddWithValue("@xid", xid);

                        dts.Reset();

                        da2.Fill(dts, "tempdt");
                        DataTable temp2 = new DataTable();
                        temp2 = dts.Tables[0];


                        if (temp2.Rows.Count > 0)
                        {
                            string permission222 = temp2.Rows[0][0].ToString();

                            permis2 = permission222.Split('|');



                            ///////////////////////////////////

                            if (pageName == "ztroute")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "10")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztcoach")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "11")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztfare")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "12")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "zttrip")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "13")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztrole")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "17")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztuser")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "18")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztcounter")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "19")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "prmst")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "20")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztcity")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "21")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztdriver")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "22")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztdesig")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "23")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "vmvech")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "30")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztbusexch")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "31")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztreceive")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "32")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztissue")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "33")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "saledetails")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "34")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztbooking")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "4")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "cancelparam")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "41")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "mansaleparam")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "42")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztreservehistory")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "43")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztmanticapppen")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "44")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztloginhis")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "45")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "vahicleparam")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "46")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztcancelreq")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "5")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztsales")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "8")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "driverinfoparam")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "47")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztruncostsetup")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "49")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztruncost")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "50")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else if (pageName == "ztdisc")
                            {
                                bool c = false;
                                for (int i = 0; i < permis2.Length; i++)
                                {
                                    if (permis2[i] == "51")
                                    {
                                        c = true;
                                        break;
                                    }
                                }

                                if (!c)
                                {
                                    result = "n";
                                }
                            }
                            else
                            {

                            }



                            //////////////////////////////////////////////////////
                        }
                        else
                        {
                            //Label1.Visible = true;
                            //Label1.Text = "You have no permission set yet. Please contact to your system administrator. ";
                        }
                    }
                    else
                    {
                        //Label1.Visible = true;
                        //Label1.Text = "You are not belong to any role/group. Please contact to your system administrator. ";
                    }
                }


                return result;
            }
            catch (Exception exp)
            {
                //Response.Write(exp.Message);
                return "e";
            }




        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {

                //fnDelCurSeat();
                //zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                //Build login history

                SqlConnection conn678;
                conn678 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn678;
                string query;

                query = "UPDATE ztloginhis SET " +
                                   "xlogout=@xlogout " +
                                   "WHERE xuser=@xuser AND xlogin=(select max(xlogin) from ztloginhis where xuser=@xuser)";
                dataCmd.CommandText = query;

                string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                DateTime xlogout1 = DateTime.Now;



                dataCmd.Parameters.AddWithValue("@xuser", xuser1);

                dataCmd.Parameters.AddWithValue("@xlogout", xlogout1);

                conn678.Close();
                conn678.Open();
                dataCmd.ExecuteNonQuery();
                conn678.Close();

                /////////////////////
                /// 
                /// 
                /// 

                HttpContext.Current.Session["curuser"] = null;
                HttpContext.Current.Session["business"] = null;
                HttpContext.Current.Session["menu"] = null;
                Session.Abandon();
                Response.Redirect("~/forms/zlogin.aspx");

            }
            catch (Exception exp)
            {
                HttpContext.Current.Session["curuser"] = null;
                HttpContext.Current.Session["business"] = null;
                HttpContext.Current.Session["menu"] = null;
                Session.Abandon();
                Response.Redirect("~/forms/zlogin.aspx");
            }

        }
    }
}