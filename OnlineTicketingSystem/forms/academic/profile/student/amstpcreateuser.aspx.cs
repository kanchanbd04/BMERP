using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.profile.student
{
    public partial class amstpcreateuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    divchk.Visible = false;
                    divcre.Visible = false;
                    divreset.Visible = false;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnCheck_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                string student = zglobal.fnGetValue("xname", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_chk.Text.Trim().ToString() + "'");

                if (student == "")
                {
                    lblchk.Text = "Invalid Student ID.";
                    lblchk.ForeColor = Color.Red;
                    divchk.Visible = false;
                    return;
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xuser FROM ztuser WHERE xuser=@xuser and xrole=@xrole";
                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                        da1.SelectCommand.Parameters.AddWithValue("@xuser", xstdid_chk.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xrole", "Student");
                        da1.Fill(dts1, "tblamadmisd");
                        //tblamadmisd = new DataTable();
                       DataTable amexamd = dts1.Tables[0];

                        if (amexamd.Rows.Count > 0)
                        {
                            lblchk.Text = "User Already Exists.";
                            lblchk.ForeColor = Color.Green;
                            divchk.Visible = true;

                            imgchk.ImageUrl = zglobal.fnGetValue("coalesce(ximagelink,'~/images/no-image.png')", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_chk.Text.Trim().ToString() + "'");

                            xname_chk.Text = zglobal.fnGetValue("coalesce(xname,'')", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_chk.Text.Trim().ToString() + "'");
                        }
                        else
                        {
                            lblchk.Text = "User Not Exists.";
                            lblchk.ForeColor = Color.Red;
                            divchk.Visible = false;
                        }
                    }
                }


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnCreate_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                string student = zglobal.fnGetValue("xname", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_cre.Text.Trim().ToString() + "'");

                if (student == "")
                {
                    lblcre.Text = "Invalid Student ID.";
                    lblcre.ForeColor = Color.Red;
                    divcre.Visible = false;
                    return;
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xuser FROM ztuser WHERE xuser=@xuser and xrole=@xrole";
                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                        da1.SelectCommand.Parameters.AddWithValue("@xuser", xstdid_cre.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xrole", "Student");
                        da1.Fill(dts1, "tblamadmisd");
                        //tblamadmisd = new DataTable();
                        DataTable amexamd = dts1.Tables[0];

                        if (amexamd.Rows.Count > 0)
                        {
                            lblcre.Text = "User Already Exists.";
                            lblcre.ForeColor = Color.Green;
                            divcre.Visible = true;

                            imgcre.ImageUrl = zglobal.fnGetValue("coalesce(ximagelink,'~/images/no-image.png')", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_cre.Text.Trim().ToString() + "'");

                            xname_cre.Text = "Name : " + zglobal.fnGetValue("coalesce(xname,'')", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_cre.Text.Trim().ToString() + "'");

                            xuserid_cre.Text = "User ID : " + xstdid_cre.Text.Trim().ToString();
                            xpass_cre.Text = "";
                        }
                        else
                        {
                            ///////////////////////////////////////
                            /// 
                            /// 

                            using (SqlConnection conn1 = new SqlConnection(zglobal.constringstdp))
                            {
                                using (DataSet dts11 = new DataSet())
                                {
                                    string query1 = "SELECT xname FROM amstudentvw WHERE zid=@zid  and xstdid=@xstdid";
                                    SqlDataAdapter da11 = new SqlDataAdapter(query1, conn1);
                                    da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                    da11.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid_cre.Text.Trim().ToString());
                                    da11.Fill(dts11, "tblamadmisd");
                                    //tblamadmisd = new DataTable();
                                    DataTable amexamd1 = dts11.Tables[0];

                                    if (amexamd1.Rows.Count > 0)
                                    {
                                        using (SqlConnection conn11 = new SqlConnection(zglobal.constringstdp))
                                        {
                                            conn11.Open();
                                            SqlCommand cmd = new SqlCommand();
                                            cmd.Connection = conn11;


                                            string query11 = "INSERT INTO ztuser(xuser,xpass,xusername,xuserinfo,xempcode,xaccess,xdateformat,zactive,xphone,xrole,xdatetime,xpermisst,xlocst,xpermisstunit) " +
                                                             "VALUES(@xuser, '123', @xusername, NULL, @xuser,'', '[Select]', 1,'', 'Student', getdate(), 0, 'all', 0)";
                                            
                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query11;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xuser", xstdid_cre.Text.ToString());
                                            cmd.Parameters.AddWithValue("@xusername", zglobal.fnGetValue("coalesce(xname,'')", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_cre.Text.Trim().ToString() + "'"));
                                            cmd.ExecuteNonQuery();

                                        }

                                        lblcre.Text = "User Created.";
                                        lblcre.ForeColor = Color.Green;
                                        divcre.Visible = true;

                                        imgcre.ImageUrl = zglobal.fnGetValue("coalesce(ximagelink,'~/images/no-image.png')", "amadmis",
                                "zid=" + _zid + " and xstdid='" + xstdid_cre.Text.Trim().ToString() + "'");

                                        xname_cre.Text = "Name : " + zglobal.fnGetValue("coalesce(xname,'')", "amadmis",
                                "zid=" + _zid + " and xstdid='" + xstdid_cre.Text.Trim().ToString() + "'");

                                        xuserid_cre.Text = "User ID : " + xstdid_cre.Text.Trim().ToString();
                                        xpass_cre.Text = "Password : 123";
                                    }
                                    else
                                    {
                                        lblcre.Text = "This id not found in student portal. Please contact with system administrator.";
                                        lblcre.ForeColor = Color.Red;
                                        divcre.Visible = false;
                                    }
                                }
                            }



                            ////////////////////////
                        }
                    }
                }


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                string student = zglobal.fnGetValue("xname", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_reset.Text.Trim().ToString() + "'");

                if (student == "")
                {
                    lblreset.Text = "Invalid Student ID.";
                    lblreset.ForeColor = Color.Red;
                    divreset.Visible = false;
                    return;
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xuser FROM ztuser WHERE xuser=@xuser and xrole=@xrole";
                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                        da1.SelectCommand.Parameters.AddWithValue("@xuser", xstdid_reset.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xrole", "Student");
                        da1.Fill(dts1, "tblamadmisd");
                        //tblamadmisd = new DataTable();
                        DataTable amexamd = dts1.Tables[0];

                        if (amexamd.Rows.Count > 0)
                        {
                            using (SqlConnection conn11 = new SqlConnection(zglobal.constringstdp))
                            {
                                conn11.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn11;


                                string query11 = "UPDATE ztuser SET xpass='123' WHERE xuser=@xuser";

                                cmd.Parameters.Clear();

                                cmd.CommandText = query11;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xuser", xstdid_reset.Text.ToString());
                                cmd.ExecuteNonQuery();

                            }

                            lblreset.Text = "Password reset completed.";
                            lblreset.ForeColor = Color.Green;
                            divreset.Visible = true;

                            imgreset.ImageUrl = zglobal.fnGetValue("coalesce(ximagelink,'~/images/no-image.png')", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_reset.Text.Trim().ToString() + "'");

                            xname_reset.Text = zglobal.fnGetValue("coalesce(xname,'')", "amadmis",
                    "zid=" + _zid + " and xstdid='" + xstdid_reset.Text.Trim().ToString() + "'");
                        }
                        else
                        {
                            lblreset.Text = "User Not Exists.";
                            lblreset.ForeColor = Color.Red;
                            divreset.Visible = false;
                        }
                    }
                }


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.am_errormsg;
            }
        }
    }
}