using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.profile.student
{
    public partial class amstddeparture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["curuser"] == null || Convert.ToString(HttpContext.Current.Session["curuser"]) == "")
                {
                    //FormsAuthentication.SignOut();
                    //FormsAuthentication.RedirectToLoginPage();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Location", xschool);
                    xsession.Text = zglobal.fnDefaults("xsession", "Student");

                    //fnFetchValue();

                    Timer1.Enabled = true;
                }

                //////xstdid.Text = string.Empty;
                //xstdid.Focus();
                //xstdid.Attributes.Add("onfocus", "javascript:this.select();");
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void xstdid_OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //Label1.Text = Label1.Text + xstdid.Text.ToString() + "<br>";

            //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //    {
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = conn;

            //        DateTime xdate = DateTime.Now;
            //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //        string query =
            //                        "INSERT INTO amstddeparture (ztime,zid,xrow,xstdid,xsession,xdate) " +
            //                        "VALUES(@ztime,@zid,@xrow,@xstdid,@xsession,@xdate) ";

            //        int xrow = zglobal.GetMaximumIdInt("xrow", "amstddeparture", " zid=" + _zid, 1, 1);
            //        string xsession1 = xsession.Text.Trim().ToString();
            //        string xstdid1 = xstdid.Text.Trim().ToString();

            //        cmd.CommandText = query;
            //        cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
            //        cmd.Parameters.AddWithValue("@zid", _zid);
            //        cmd.Parameters.AddWithValue("@xrow", xrow);
            //        cmd.Parameters.AddWithValue("@xstdid", xstdid1);
            //        cmd.Parameters.AddWithValue("@xsession", xsession1);
            //        cmd.Parameters.AddWithValue("@xdate", xdate);
            //        cmd.ExecuteNonQuery();

            //    }
            //    fnFetchValue();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        private void fnFetchValue()
        {
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dtssection = new DataSet())
                {
                    string query = "SELECT xstdid,xname,ximagelink,xclass+'<br>('+xsectionsrt+')' as xclass FROM amstddeparturevw8 WHERE zid=@zid AND xsession=@xsession AND zactive=1 AND xdate1=@xdate AND CHARINDEX(xschool,@xschool) > 0 " +
                                   " order by xdate";

                    SqlDataAdapter dasection = new SqlDataAdapter(query, con);
                    string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                    dasection.SelectCommand.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                    dasection.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                    dasection.SelectCommand.Parameters.AddWithValue("@xschool", xschool.Text.Trim().ToString());
                    dasection.SelectCommand.Parameters.AddWithValue("@xdate", DateTime.Now.Date);
                    dasection.SelectCommand.CommandType = CommandType.Text;
                    dasection.Fill(dtssection, "temptsection");
                    DataTable tblsection = new DataTable();
                    tblsection = dtssection.Tables[0];

                    if (tblsection.Rows.Count > 0)
                    {
                        _grid_std.DataSource = tblsection;
                        _grid_std.DataBind();
                    }
                    else
                    {
                        _grid_std.DataSource = null;
                        _grid_std.DataBind();
                    }
                }
            }
        }

        protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnRefresh_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                fnFetchValue();
                //xstdid.Focus();
                //xstdid.Attributes.Add("onfocus", "javascript:this.select();");
                //xstdid.Text = "";
                //xsession.Text = zglobal.fnDefaults("xsession", "Student");
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void TimerTick(object sender, EventArgs e)
        {
            try
            {
                fnFetchValue();
                //xstdid.Focus();
                //xstdid.Attributes.Add("onfocus", "javascript:this.select();");
                //xstdid.Text = "";
                //xsession.Text = zglobal.fnDefaults("xsession", "Student");
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}