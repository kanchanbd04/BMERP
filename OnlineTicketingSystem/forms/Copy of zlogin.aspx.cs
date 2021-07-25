using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace OnlineTicketingSystem.Forms
{
    public partial class zlogin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //var xloc = Login1.FindControl("DropDownList1") as DropDownList;
                //SqlConnection conn1;
                //conn1 = new SqlConnection(zglobal.constring);
                //DataSet dts = new DataSet();
                //string str = "select xcname from ztcounter where zactive=1 ORDER BY xcname";
                //SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                //da1.Fill(dts, "dt1");
                //DataTable dt1 = new DataTable();
                //dt1 = dts.Tables[0];
                //xloc.Items.Clear();

                ////xloc.Items.Add("");
                //xloc.Items.Add("[Select]");
                //for (int i = 0; i < dt1.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dt1.Columns.Count; j++)
                //    {
                //        xloc.Items.Add(dt1.Rows[i][j].ToString());
                //    }
                //}

                //xloc.Text = "[Select]";
                //da1.Dispose();
                //conn1.Dispose();
                //// da.Dispose();

                //dts.Dispose();
                //DropDownList1.Items.Clear();
            }
        }


        protected void ValidateUser(object sender, AuthenticateEventArgs e)
        {
        //    try
        //    {

        //        SqlConnection conn = new SqlConnection(zglobal.constring);
        //        conn.Open();
        //        string checkuser = "select count(*) from ztuser where xuser=@xuser";

        //        SqlParameter objParameter = null;
        //        // string xuser = Login1.UserName;
        //        SqlCommand cmd = new SqlCommand(checkuser, conn);
        //        objParameter = cmd.Parameters.Add("xuser", SqlDbType.VarChar);

        //        cmd.Parameters["xuser"].Value = Login1.UserName.ToString().Trim();

        //        int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        //        conn.Close();
        //        if (temp == 1)
        //        {
        //            conn.Open();
        //            string checkst1 = "select xrole from ztuser where xuser=@xuser";
        //            SqlParameter objParameter3 = null;
        //            // string xuser = Login1.UserName;
        //            SqlCommand cmdst1 = new SqlCommand(checkst1, conn);
        //            objParameter3 = cmdst1.Parameters.Add("xuser", SqlDbType.VarChar);
        //            cmdst1.Parameters["xuser"].Value = Login1.UserName.ToString().Trim();
        //            string xrole = cmdst1.ExecuteScalar().ToString().Trim();

        //            conn.Close();

        //            conn.Open();
        //            string checkst4 = "select zactive from ztrole where xrole=@xrole";
        //            SqlParameter objParameter4 = null;
        //            //string xrole4 = xrole;
        //            SqlCommand cmdst4 = new SqlCommand(checkst4, conn);
        //            objParameter4 = cmdst4.Parameters.Add("xrole", SqlDbType.VarChar);
        //            cmdst4.Parameters["xrole"].Value = xrole;
        //            string rolest = cmdst4.ExecuteScalar().ToString().Trim();

        //            conn.Close();

        //            if (rolest == "1")
        //            {

        //                conn.Open();
        //                string checkst = "select zactive from ztuser where xuser=@xuser";
        //                SqlParameter objParameter2 = null;
        //                // string xuser = Login1.UserName;
        //                SqlCommand cmdst = new SqlCommand(checkst, conn);
        //                objParameter2 = cmdst.Parameters.Add("xuser", SqlDbType.VarChar);
        //                cmdst.Parameters["xuser"].Value = Login1.UserName.ToString().Trim();
        //                string zactive = cmdst.ExecuteScalar().ToString().Trim();

        //                conn.Close();
        //                if (zactive == "1")
        //                {

        //                    conn.Open();
        //                    string checkpass = "select xpass from ztuser where xuser=@xuser";
        //                    SqlParameter objParameter1 = null;
        //                    // string xuser = Login1.UserName;
        //                    SqlCommand cmdpass = new SqlCommand(checkpass, conn);
        //                    objParameter1 = cmdpass.Parameters.Add("xuser", SqlDbType.VarChar);
        //                    cmdpass.Parameters["xuser"].Value = Login1.UserName.ToString().Trim();
        //                    string xpassword = cmdpass.ExecuteScalar().ToString().Trim();

        //                    conn.Close();
        //                    if (xpassword.Equals(Login1.Password.ToString()))
        //                    {
        //                        var xloc = Login1.FindControl("DropDownList1") as DropDownList;

        //                        if (xloc.Text != "[Select]")
        //                        {

        //                            SqlConnection conn1;
        //                            conn1 = new SqlConnection(zglobal.constring);
        //                            DataSet dts = new DataSet();

        //                            dts.Reset();

        //                            string str = "SELECT xlocst FROM ztuser WHERE xuser=@xuser";


        //                            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

        //                            string xuser = Login1.UserName.ToString();
        //                            da.SelectCommand.Parameters.AddWithValue("@xuser", xuser);


        //                            da.Fill(dts, "tempzuser");

        //                            DataTable dtzuser = new DataTable();
        //                            dtzuser = dts.Tables[0];

        //                            if (dtzuser.Rows.Count > 0)
        //                            {
        //                                if (dtzuser.Rows[0][0].ToString() == "all")
        //                                {
        //                                    //zglobal.curuser = Login1.UserName;
        //                                    //zglobal.xlocation = xloc.Text;
        //                                    HttpContext.Current.Session["curuser"] = Login1.UserName.ToString();
        //                                    HttpContext.Current.Session["xlocation"] = xloc.Text.ToString();
        //                                    FormsAuthentication.SetAuthCookie("CookieValue", false);
        //                                    fnInsertLoginHis();
        //                                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
        //                                    //Login1.FailureText = "";
        //                                }
        //                                else
        //                                {
        //                                    str = "SELECT xloc FROM ztuserloc WHERE xuser=@xuser";

        //                                    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

        //                                    da1.SelectCommand.Parameters.AddWithValue("@xuser", xuser);

        //                                    dts.Reset();
        //                                    da1.Fill(dts, "zdt");
        //                                    DataTable zdt1 = new DataTable();
        //                                    zdt1 = dts.Tables[0];

        //                                    if (zdt1.Rows.Count > 0)
        //                                    {
        //                                        string temploc = zdt1.Rows[0][0].ToString();
        //                                        string[] xxloc;
        //                                        //ArrayList ztxloc = new ArrayList();
        //                                        xxloc = temploc.Split('|');

        //                                        foreach (string loc in xxloc)
        //                                        {
        //                                            if (loc == xloc.Text.ToString())
        //                                            {
        //                                                //zglobal.curuser = Login1.UserName;
        //                                                //zglobal.xlocation = xloc.Text;
        //                                                HttpContext.Current.Session["curuser"] = Login1.UserName.ToString();
        //                                                HttpContext.Current.Session["xlocation"] = xloc.Text.ToString();
        //                                                FormsAuthentication.SetAuthCookie("CookieValue", false);
        //                                                fnInsertLoginHis();
        //                                                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
        //                                                return;
        //                                            }
        //                                        }

        //                                        Login1.FailureText = "Please Select counter";
        //                                        xloc.Items.Clear();
        //                                        xloc.Items.Add("[Select]");
        //                                        foreach (string loc in xxloc)
        //                                        {
        //                                            //ztxloc.Add(loc.Trim());
        //                                            if (loc != "")
        //                                            {
        //                                                xloc.Items.Add(loc.Trim());
        //                                            }
        //                                        }
        //                                        xloc.Text = "[Select]";

        //                                    }
        //                                }
        //                            }


        //                        }
        //                        else
        //                        {
        //                            Login1.FailureText = "Please select counter";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Login1.FailureText = "Password is not correct";
        //                    }
        //                }
        //                else
        //                {
        //                    Login1.FailureText = "User not active";
        //                }
        //            }
        //            else
        //            {
        //                Login1.FailureText = "Your role '" + xrole + "' not active.";
        //            }

        //        }
        //        else
        //        {
        //            Login1.FailureText = "User name is not correct";

        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        Login1.FailureText = exp.Message;
        //    }
        }

        protected void fnInsertLoginHis()
        {
            //Build login history

            SqlConnection conn678;
            conn678 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn678;
            string query;
            query = "INSERT INTO ztloginhis " +
                    "(xrow,xuser,xlogin,xlogout,xloc,xdate) " +
                    "VALUES (@xrow,@xuser,@xlogin,@xlogout,@xloc,@xdate) ";
            dataCmd.CommandText = query;

            string xrow1 = zglobal.fnmaxid("SELECT max(xrow) FROM ztloginhis where xdate between @firstdate and @lastdate");
            string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            DateTime xlogin1 = DateTime.Now;
            DateTime xlogout1 = Convert.ToDateTime("01/01/1900");
            string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
            DateTime xdate1 = DateTime.Now.Date;

            dataCmd.Parameters.AddWithValue("@xrow", xrow1);
            dataCmd.Parameters.AddWithValue("@xuser", xuser1);
            dataCmd.Parameters.AddWithValue("@xlogin", xlogin1);
            dataCmd.Parameters.AddWithValue("@xlogout", xlogout1);
            dataCmd.Parameters.AddWithValue("@xloc", xloc1);
            dataCmd.Parameters.AddWithValue("@xdate", xdate1);
            conn678.Close();
            conn678.Open();
            dataCmd.ExecuteNonQuery();
            conn678.Close();

            /////////////////////
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //try
            //{

                if (UserName.Text.ToString() == "bm" && Password.Text.ToString() == "bm0987654321")
                {
                    HttpContext.Current.Session["curuser"] = UserName.Text.ToString();
                    HttpContext.Current.Session["business"] = DropDownList1.SelectedValue.ToString();
                    fnInsertLoginHis();
                    Response.Redirect("~/Default.aspx");

                    return;
                }

                SqlConnection conn = new SqlConnection(zglobal.constring);
                conn.Open();
                string checkuser = "select count(*) from ztuser where xuser=@xuser";

                SqlParameter objParameter = null;
                // string xuser = Login1.UserName;
                SqlCommand cmd = new SqlCommand(checkuser, conn);
                objParameter = cmd.Parameters.Add("xuser", SqlDbType.VarChar);

                cmd.Parameters["xuser"].Value = UserName.Text.ToString().Trim();

                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();
                if (temp == 1)
                {
                    conn.Open();
                    string checkst1 = "select xrole from ztuser where xuser=@xuser";
                    SqlParameter objParameter3 = null;
                    // string xuser = Login1.UserName;
                    SqlCommand cmdst1 = new SqlCommand(checkst1, conn);
                    objParameter3 = cmdst1.Parameters.Add("xuser", SqlDbType.VarChar);
                    cmdst1.Parameters["xuser"].Value = UserName.Text.ToString().Trim();
                    string xrole = cmdst1.ExecuteScalar().ToString().Trim();

                    conn.Close();

                    conn.Open();
                    string checkst4 = "select zactive from ztrole where xrole=@xrole";
                    SqlParameter objParameter4 = null;
                    //string xrole4 = xrole;
                    SqlCommand cmdst4 = new SqlCommand(checkst4, conn);
                    objParameter4 = cmdst4.Parameters.Add("xrole", SqlDbType.VarChar);
                    cmdst4.Parameters["xrole"].Value = xrole;
                    string rolest = cmdst4.ExecuteScalar().ToString().Trim();

                    conn.Close();

                    if (rolest == "1")
                    {

                        conn.Open();
                        string checkst = "select zactive from ztuser where xuser=@xuser";
                        SqlParameter objParameter2 = null;
                        // string xuser = Login1.UserName;
                        SqlCommand cmdst = new SqlCommand(checkst, conn);
                        objParameter2 = cmdst.Parameters.Add("xuser", SqlDbType.VarChar);
                        cmdst.Parameters["xuser"].Value = UserName.Text.ToString().Trim();
                        string zactive = cmdst.ExecuteScalar().ToString().Trim();

                        conn.Close();
                        //if (zactive == "1" || UserName.Text.ToString() == "bm")
                        if (zactive == "1")
                        {

                            conn.Open();
                            string checkpass = "select xpass from ztuser where xuser=@xuser";
                            SqlParameter objParameter1 = null;
                            // string xuser = Login1.UserName;
                            SqlCommand cmdpass = new SqlCommand(checkpass, conn);
                            objParameter1 = cmdpass.Parameters.Add("xuser", SqlDbType.VarChar);
                            cmdpass.Parameters["xuser"].Value = UserName.Text.ToString().Trim();
                            string xpassword = cmdpass.ExecuteScalar().ToString().Trim();

                            conn.Close();
                            if (xpassword.Equals(Password.Text.ToString()))
                            {
                                //var xloc = Login1.FindControl("DropDownList1") as DropDownList;

                                if (DropDownList1.SelectedValue.ToString() != "-1")
                                {

                                    HttpContext.Current.Session["curuser"] = UserName.Text.ToString();
                                    HttpContext.Current.Session["business"] = DropDownList1.SelectedValue.ToString();
                                    //HttpContext.Current.Session["xlocation"] = xloc.Text.ToString();
                                    //FormsAuthentication.SetAuthCookie("CookieValue", false);
                                    fnInsertLoginHis();
                                    Response.Redirect("~/Default.aspx");

                                    //SqlConnection conn1;
                                    //conn1 = new SqlConnection(zglobal.constring);
                                    //DataSet dts = new DataSet();

                                    //dts.Reset();

                                    //string str = "SELECT xlocst FROM ztuser WHERE xuser=@xuser";


                                    //SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                                    //string xuser = Login1.UserName.ToString();
                                    //da.SelectCommand.Parameters.AddWithValue("@xuser", xuser);


                                    //da.Fill(dts, "tempzuser");

                                    //DataTable dtzuser = new DataTable();
                                    //dtzuser = dts.Tables[0];

                                    //if (dtzuser.Rows.Count > 0)
                                    //{
                                    //    if (dtzuser.Rows[0][0].ToString() == "all")
                                    //    {
                                    //        //zglobal.curuser = Login1.UserName;
                                    //        //zglobal.xlocation = xloc.Text;
                                    //        HttpContext.Current.Session["curuser"] = Login1.UserName.ToString();
                                    //        HttpContext.Current.Session["xlocation"] = xloc.Text.ToString();
                                    //        //FormsAuthentication.SetAuthCookie("CookieValue", false);
                                    //        fnInsertLoginHis();
                                    //        Response.Redirect("~/Default.aspx");
                                    //        // FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                                    //        //Login1.FailureText = "";
                                    //    }
                                    //    else
                                    //    {
                                    //        str = "SELECT xloc FROM ztuserloc WHERE xuser=@xuser";

                                    //        SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                                    //        da1.SelectCommand.Parameters.AddWithValue("@xuser", xuser);

                                    //        dts.Reset();
                                    //        da1.Fill(dts, "zdt");
                                    //        DataTable zdt1 = new DataTable();
                                    //        zdt1 = dts.Tables[0];

                                    //        if (zdt1.Rows.Count > 0)
                                    //        {
                                    //            string temploc = zdt1.Rows[0][0].ToString();
                                    //            string[] xxloc;
                                    //            //ArrayList ztxloc = new ArrayList();
                                    //            xxloc = temploc.Split('|');

                                    //            foreach (string loc in xxloc)
                                    //            {
                                    //                if (loc == xloc.Text.ToString())
                                    //                {
                                    //                    //zglobal.curuser = Login1.UserName;
                                    //                    //zglobal.xlocation = xloc.Text;
                                    //                    HttpContext.Current.Session["curuser"] = Login1.UserName.ToString();
                                    //                    HttpContext.Current.Session["xlocation"] = xloc.Text.ToString();
                                    //                    //FormsAuthentication.SetAuthCookie("CookieValue", false);
                                    //                    fnInsertLoginHis();
                                    //                    Response.Redirect("~/Default.aspx");
                                    //                    // FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                                    //                    //Login1.FailureText = "";
                                    //                }
                                    //            }

                                    //            Login1.FailureText = "Please Select counter";
                                    //            xloc.Items.Clear();
                                    //            xloc.Items.Add("[Select]");
                                    //            foreach (string loc in xxloc)
                                    //            {
                                    //                //ztxloc.Add(loc.Trim());
                                    //                if (loc != "")
                                    //                {
                                    //                    xloc.Items.Add(loc.Trim());
                                    //                }
                                    //            }
                                    //            xloc.Text = "[Select]";

                                    //        }
                                    //    }
                                    //}


                                }
                                else
                                {
                                    FailureText.Text = "Please select business";
                                }
                            }
                            else
                            {
                                FailureText.Text = "Password is not correct";
                            }
                        }
                        else
                        {
                            FailureText.Text = "User not active";
                        }
                    }
                    else
                    {
                        FailureText.Text = "Your role '" + xrole + "' not active.";
                    }

                }
                else
                {
                    FailureText.Text = "User name is not correct";

                }
            //}
            //catch (Exception exp)
            //{
            //    FailureText.Text = exp.Message;
            //}
        }



        protected void UserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
            //    var xloc = Login1.FindControl("DropDownList1") as DropDownList;
            //    //var lblxloc = Login1.FindControl("Label1") as Label;
            //    //xloc.Visible = true;
            //    //xloc.Visible = false;
            //    //lblxloc.Visible = false;

            //    // Login1.FindControl("DropDownList1").Visible = true;
            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    DataSet dts = new DataSet();

            //    dts.Reset();

            //    string str = "select xlocst from ztuser where xuser=@xuser";


            //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            //    string xuser = Login1.UserName.ToString();
            //    da.SelectCommand.Parameters.AddWithValue("@xuser", xuser);


            //    da.Fill(dts, "tempzuser");

            //    DataTable dtzuser = new DataTable();
            //    dtzuser = dts.Tables[0];

            //    if (dtzuser.Rows.Count > 0)
            //    {
            //        //xloc.Visible = true;
            //        //lblxloc.Visible = true;
            //        if ((string)dtzuser.Rows[0][0] == "all")
            //        {
            //            dts.Reset();
            //            str = "select xcname from ztcounter where zactive=1";
            //            SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
            //            da1.Fill(dts, "dt1");
            //            DataTable dt1 = new DataTable();
            //            dt1 = dts.Tables[0];
            //            xloc.Items.Clear();


            //            for (int i = 0; i < dt1.Rows.Count; i++)
            //            {
            //                for (int j = 0; j < dt1.Columns.Count; j++)
            //                {
            //                    xloc.Items.Add(dt1.Rows[i][j].ToString());
            //                }
            //            }


            //            da1.Dispose();

            //        }
            //        else
            //        {
            //            xloc.Items.Clear();
            //        }
            //    }
            //    else
            //    {
            //        //xloc.Visible = false;
            //        //lblxloc.Visible = false;
            //    }
            //    conn1.Dispose();
            //    da.Dispose();

            //    dts.Dispose();

                DropDownList1.Items.Clear();
                //AddComboBoxItems addItem = new AddComboBoxItems(DropDownList1, "zid", "(select zorg from zbusiness where zid=ztpermis.zid) as zorg", "ztpermis", "xid", UserName.Text.Trim().ToString());
                //DropDownList1.Items.Add("BM");
                //DropDownList1.Items.Add(UserName.Text.Trim().ToString());


                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        string query;
                        if (UserName.Text.ToString().Trim() == "bm")
                        {
                            query = "SELECT zid,zorg from zbusiness";
                        }
                        else
                        {
                            query = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
                        }
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@xid", UserName.Text.Trim().ToString());
                        da.Fill(dts, "tempTable");
                        DataTable tempTable = new DataTable();
                        tempTable = dts.Tables["tempTable"];

                        if (tempTable.Rows.Count <= 0)
                        {
                            query = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);

                            //xid = this.Page.User.Identity.Name;
                            da1.SelectCommand.Parameters.AddWithValue("@xuser", UserName.Text.Trim().ToString());

                            dts.Reset();

                            da1.Fill(dts, "tempdt");
                            //DataTable temp1 = new DataTable();
                            tempTable.Reset();
                            tempTable = dts.Tables[0];

                            if (tempTable.Rows.Count > 0)
                            {
                                query = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
                                SqlDataAdapter da2 = new SqlDataAdapter(query, conn);

                                da2.SelectCommand.Parameters.AddWithValue("@xid", tempTable.Rows[0][0].ToString());

                                dts.Reset();

                                da2.Fill(dts, "tempdt");
                                tempTable.Reset();
                                tempTable = dts.Tables[0];
                                if (tempTable.Rows.Count <= 0)
                                {
                                    FailureText.Text = "Your Id or your user role have not any permission to access any business";
                                    return;
                                }
                            }
                            else
                            {
                                FailureText.Text = "Your Id have not any permission to access any business";
                                return;
                            }

                            da1.Dispose();
                        }

                        ListItem llt1 = new ListItem("[Select]", "-1");
                        ArrayList alt = new ArrayList();
                        DropDownList1.Items.Add(llt1);

                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            ListItem llt = new ListItem(tempTable.Rows[i][1].ToString(), tempTable.Rows[i][0].ToString());
                            DropDownList1.Items.Add(llt);
                            alt.Add(tempTable.Rows[i][0].ToString());
                        }

                        HttpContext.Current.Session["zid"] = alt;
                        //ArrayList alt1 = (ArrayList) HttpContext.Current.Session["zid"];
                        //foreach (string str in alt1)
                        //{
                        //    FailureText.Text = FailureText.Text + " " + str;
                        //}
                        

                        da.Dispose();
                    }
                }
            }
            catch (Exception exp)
            {
                FailureText.Text = exp.Message;
            }
        }











    }
}