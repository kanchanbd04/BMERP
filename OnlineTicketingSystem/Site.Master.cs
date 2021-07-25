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
using System.Timers;

namespace OnlineTicketingSystem
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        ArrayList menu = new ArrayList();

        ArrayList permis = new ArrayList();
        string permission = "";



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


            if (!IsPostBack)
            {
                try
                {
                    //fnDelCurSeat();
                    lblUser.Text = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    lblBusiness.Text = zglobal.fnGetBusinessName(Convert.ToString(HttpContext.Current.Session["business"]));

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

                    zglobal.fnDeleteBusinessGLMSTPermis(Convert.ToString(HttpContext.Current.Session["curuser"]), HttpContext.Current.Session.SessionID.ToString());

                    GetMenuItem();
                }
                catch (Exception exp)
                {
                    Label1.Text = exp.Message;
                }
            }


        }


        private void GetMenuItem()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT * FROM ztmenu";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable temp = new DataTable();
            temp = dts.Tables[0];

            dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

            foreach (DataRow level1DataRows in dts.Tables[0].Rows)
            {
                string mnuid = level1DataRows["xid"].ToString();


                if (Convert.ToString(HttpContext.Current.Session["curuser"]) == "bm")
                {
                    if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
                    {
                        MenuItem parentitem = new MenuItem();
                        parentitem.Text = level1DataRows["xmenunm"].ToString();
                        parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                        parentitem.Value = level1DataRows["xvalue"].ToString();
                        parentitem.Target = level1DataRows["xtarget"].ToString();

                        GetChildRows(level1DataRows, parentitem);

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

                        bmmenu.Items.Add(parentitem);
                    }
                }
                else
                {
                    foreach (string mpermis in permis)
                    {


                        if (mpermis.Trim() == mnuid.Trim())
                        {
                            if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
                            {
                                MenuItem parentitem = new MenuItem();
                                parentitem.Text = level1DataRows["xmenunm"].ToString();
                                parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                                parentitem.Value = level1DataRows["xvalue"].ToString();
                                parentitem.Target = level1DataRows["xtarget"].ToString();

                                GetChildRows(level1DataRows, parentitem);

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

                                bmmenu.Items.Add(parentitem);
                            }



                            break;
                        }

                    }
                }


            }

            conn1.Dispose();
            da.Dispose();
            dts.Dispose();
        }

        private void GetChildRows(DataRow dataRow, MenuItem mnitem)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");



            foreach (DataRow childRow in childRows)
            {
                MenuItem childitem = new MenuItem();
                string childid = childRow["xid"].ToString();
                if (Convert.ToString(HttpContext.Current.Session["curuser"]) == "bm")
                {
                    childitem.Text = childRow["xmenunm"].ToString();
                    childitem.NavigateUrl = childRow["xurl"].ToString();
                    childitem.Value = childRow["xvalue"].ToString();
                    childitem.Target = childRow["xtarget"].ToString();
                    mnitem.ChildItems.Add(childitem);
                }
                else
                {
                    foreach (string mpermis in permis)
                    {

                        if (mpermis.Trim() == childid.Trim())
                        {


                            childitem.Text = childRow["xmenunm"].ToString();
                            childitem.NavigateUrl = childRow["xurl"].ToString();
                            childitem.Value = childRow["xvalue"].ToString();
                            childitem.Target = childRow["xtarget"].ToString();
                            mnitem.ChildItems.Add(childitem);

                            break;
                        }

                    }
                }






                if (childRow.GetChildRows("ChildRows").Length > 0)
                {
                    GetChildRows(childRow, childitem);
                }
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

            Session.Abandon();
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    bmmenu.Items.Clear();

            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    DataSet dts = new DataSet();


            //    dts.Reset();
            //    string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";

            //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            //    string xid = Convert.ToString(HttpContext.Current.Session["curuser"]); 
            //    da.SelectCommand.Parameters.AddWithValue("@xid", xid);


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


            //            str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";
            //            SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

            //            xid = temp1.Rows[0][0].ToString();
            //            da2.SelectCommand.Parameters.AddWithValue("@xid", xid);

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

            //    GetMenuItem();
            //}
            //catch (Exception exp)
            //{
            //    Label1.Text = exp.Message;
            //}
        }

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

                fnDelCurSeat();
                zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
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
            }
            catch (Exception exp)
            {
                Session.Abandon();
                Response.Redirect("~/forms/zlogin.aspx");
            }
            HttpContext.Current.Session["curuser"] = null;
            HttpContext.Current.Session["business"] = null;
            Session.Abandon();
            Response.Redirect("~/forms/zlogin.aspx");
        }





    }
}
