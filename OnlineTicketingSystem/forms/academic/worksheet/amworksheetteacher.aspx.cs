using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace OnlineTicketingSystem.forms.academic.worksheet
{
    public partial class amworksheetteacher : System.Web.UI.Page
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

                //if (HttpContext.Current.Request.Url.AbsolutePath == "/forms/academic/worksheet/amworksheetteacher.aspx" && HttpContext.Current.Session["xrole"] == "Student")
                //{
                //    Response.Redirect("~/forms/academic/worksheet/student/amworksheetstudent.aspx");
                //}

                if (Convert.ToString(HttpContext.Current.Session["xrole"]) == "Student")
                {
                    Response.Redirect("~/forms/academic/worksheet/student/amworksheetstudent.aspx");
                }

                if (!IsPostBack)
                {
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    string xemp1 = zglobal.fnGetValue("xempcode", "ztuser", "xuser='" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "'");

                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts1 = new DataSet())
                        {
                            string query =
                           "SELECT * FROM hrmst " +
                           "WHERE zid=@zid  AND xemp=@xemp ";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                            da1.Fill(dts1, "tempztcode");
                            DataTable dtamexamd = new DataTable();
                            dtamexamd = dts1.Tables[0];
                            if (dtamexamd.Rows.Count > 0)
                            {
                                if (dtamexamd.Rows[0]["xlink"].ToString() == "" ||
                                    Convert.IsDBNull(dtamexamd.Rows[0]["xlink"]) == true)
                                {
                                    ximagelink.Attributes.Add("src", "/images/no-image.png");
                                }
                                else
                                {
                                    ximagelink.Attributes.Add("src", dtamexamd.Rows[0]["xlink"].ToString().Substring(1, dtamexamd.Rows[0]["xlink"].ToString().Length - 1));
                                }

                                xstudentname.InnerHtml = dtamexamd.Rows[0]["xname"].ToString();
                                //xstudentclasssection.InnerHtml = dtamexamd.Rows[0]["xclass"].ToString() + "<br/>" + dtamexamd.Rows[0]["xsection"].ToString();

                                //HttpContext.Current.Session["xclass"] = dtamexamd.Rows[0]["xclass"].ToString();
                                //HttpContext.Current.Session["xsection"] = dtamexamd.Rows[0]["xsection"].ToString();
                            }

                        }
                    }

                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    zglobal.fnGetComboDataCD("Section", xsection);

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //xclass.Items[1].Selected = true;
                    //xsection.Items[1].Selected = true;
                    //xclass.Text = "Playgroup";
                    xclass.Text = xclass.Items[1].Text;
                    xsection.Text = xsection.Items[1].Text;

                    zglobal.fnGetComboDataCD("Session", xsession1);
                    zglobal.fnGetComboDataCD("Term", xterm1);
                    zglobal.fnGetComboDataCD("Class", xclass1);
                    zglobal.fnGetComboDataCD("Education Group", xgroup1);
                    zglobal.fnGetComboDataCD("Section", xsection1);

                    xsession1.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm1.Text = zglobal.fnDefaults("xterm", "Student");
                    xclass1.Text = xclass1.Items[1].Text;
                    xsection1.Text = xsection1.Items[1].Text;


                    zglobal.fnGetComboDataCD("Session", xsession2);
                    zglobal.fnGetComboDataCD("Term", xterm2);
                    zglobal.fnGetComboDataCD("Class", xclass2);
                    zglobal.fnGetComboDataCD("Education Group", xgroup2);
                    zglobal.fnGetComboDataCD("Section", xsection2);
                    //xsection2.Items.Add("All");


                    xsession2.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm2.Text = zglobal.fnDefaults("xterm", "Student");
                    xclass2.Text = xclass2.Items[1].Text;
                    xsection2.Text = xsection2.Items[1].Text;


                    ViewState["ispostback"] = "yes";
                    ViewState["ispostback1"] = "yes";
                    ViewState["ispostback2"] = "yes";

                }

                fnStudentFeedback(null, null);
                fnTeacherFeedback(null, null);
                fnUploadHomeworks(null, null);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        public void fnUploadHomeworks(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                myModal.Attributes.Add("style", "display:none;");
                myModal1.Attributes.Add("style", "display:none;");
                myModal2.Attributes.Add("style", "display:none;");

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    if (ViewState["ispostback"].ToString() != "yes")
                    {
                        bool isValid = true;
                        string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                        if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Session</li>";
                            isValid = false;
                        }
                        if (xterm.Text == "" || xterm.Text == string.Empty || xterm.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Term</li>";
                            isValid = false;
                        }
                        if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Class</li>";
                            isValid = false;
                        }
                        if (xsection.Text == "" || xsection.Text == string.Empty || xsection.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Section</li>";
                            isValid = false;
                        }


                        rtnMessage = rtnMessage + "</ol></div>";
                        if (!isValid)
                        {
                            message.InnerHtml = rtnMessage;
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }
                    }

                    ViewState["ispostback"] = "no";

                    string query = "SELECT xsubject,xpapext,xpaper,xext FROM amclasssubvw WHERE zid=@zid AND xclass=@xclass order by xsubject";

                    SqlCommand cmd = new SqlCommand(query, con);
                    string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                    cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    upload_homeworks.Controls.Clear();
                    while (rdr.Read())
                    {
                        //combo.Items.Add(rdr["xsubject"].ToString());

                        //<div class="link_con">
                        //    <a href="#">
                        //        <div style="text-align: center">
                        //            <img class="image" src="images/Routine.png" width="75px" height="75px" />
                        //        </div>
                        //        <div class="class">
                        //            Routine
                        //        </div>
                        //    </a>
                        //</div>

                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        div1.Attributes.Add("class", "link_con image");
                        upload_homeworks.Controls.Add(div1);

                        string xpaper123 = rdr["xpaper"].ToString() == "" ? "" : rdr["xpaper"].ToString();
                        string xext123 = rdr["xext"].ToString() == "" ? "" : rdr["xext"].ToString();
                        string xclass123 = xclass.Text.Trim().ToString();
                        string xsection123 = xsection.Text.Trim().ToString();

                        HtmlGenericControl a = new HtmlGenericControl("a");
                        //a.Attributes.Add("href","#");
                        a.Attributes.Add("id", "_link");
                        //a.Attributes.Add("onclick", "fnOpenUpload('" + rdr["xsubject"].ToString() + "','" + xpaper123 + "','" + xext123 + "');");
                        a.Attributes.Add("onclick", "fnOpenUpload1('" + rdr["xsubject"].ToString() + "','" + xpaper123 + "','" + xext123 + "','" + xclass123 + "','" + xsection123 + "');");
                        //a.Attributes.Add("onclick", "window.open('/forms/academic/worksheet/amuploadteacher.aspx?zid="+_zid+"&xsession="+xsession.Text.ToString().Trim()
                        //    +"&xterm="+xterm.Text.Trim().ToString()+"&xclass="+xclass.Text.Trim().ToString()+"&xsection="+xsection.Text.Trim().ToString()+"&xsubject="+rdr["xsubject"].ToString()+"&xpaper="+rdr["xpaper"].ToString()+"&xext="+rdr["xext"].ToString()+"', " +
                        //    "'uploadteacher', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');openwin.focus(); return false;");
                        div1.Controls.Add(a);

                        HtmlGenericControl div2 = new HtmlGenericControl("div");
                        div2.Attributes.Add("style", "text-align: center");
                        a.Controls.Add(div2);

                        HtmlGenericControl img = new HtmlGenericControl("img");
                        //img.Attributes.Add("class", "image");
                        //img.Attributes.Add("src", "/images/folder.png");
                        img.Attributes.Add("src", "/images/green_folder.png");
                        img.Attributes.Add("width", "55px");
                        img.Attributes.Add("height", "55px");
                        div2.Controls.Add(img);

                        HtmlGenericControl div3 = new HtmlGenericControl("div");
                        div3.Attributes.Add("class", "link");
                        if (rdr["xpapext"].ToString() == "")
                        {
                            div3.InnerHtml = rdr["xsubject"].ToString();
                        }
                        else
                        {
                            div3.InnerHtml = rdr["xsubject"].ToString() + " - " + rdr["xpapext"].ToString();
                        }

                        a.Controls.Add(div3);

                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        public void fnTeacherFeedback(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                myModal.Attributes.Add("style", "display:none;");
                myModal1.Attributes.Add("style", "display:none;");
                myModal2.Attributes.Add("style", "display:none;");

                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);

                using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                            "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,xsubject,xpaper,xext FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection  and xtype='Teacher Feedback' and zemail=@zemail"; //and xstatus='New'

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", int.Parse(_zid));
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession2.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm2.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass2.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection2.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@zemail",
                         HttpContext.Current.Session["curuser"].ToString());
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amworksheet"] = dtamexamd;

                        //dtamexamd.Dispose();
                    }
                }

                using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                            "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,xsubject,xpaper,xext FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection and xstatus='Send' and xtype='Teacher Feedback' and zemail=@zemail";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", int.Parse(_zid));
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession2.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm2.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass2.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection2.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@zemail",
                         HttpContext.Current.Session["curuser"].ToString());
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amworksheet1"] = dtamexamd;

                        //dtamexamd.Dispose();
                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    if (ViewState["ispostback1"].ToString() != "yes")
                    {
                        bool isValid = true;
                        string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                        if (xsession2.Text == "" || xsession2.Text == string.Empty || xsession2.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Session</li>";
                            isValid = false;
                        }
                        if (xterm2.Text == "" || xterm2.Text == string.Empty || xterm2.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Term</li>";
                            isValid = false;
                        }
                        if (xclass2.Text == "" || xclass2.Text == string.Empty || xclass2.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Class</li>";
                            isValid = false;
                        }
                        if (xsection2.Text == "" || xsection2.Text == string.Empty || xsection2.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Section</li>";
                            isValid = false;
                        }


                        rtnMessage = rtnMessage + "</ol></div>";
                        if (!isValid)
                        {
                            message.InnerHtml = rtnMessage;
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }
                    }

                    ViewState["ispostback1"] = "no";

                    string query = "SELECT xsubject,xpapext,xpaper,xext FROM amclasssubvw WHERE zid=@zid AND xclass=@xclass order by xsubject";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                    cmd.Parameters.AddWithValue("@xclass", xclass2.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    teachers_feedback.Controls.Clear();
                    while (rdr.Read())
                    {

                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        div1.Attributes.Add("class", "link_con image");
                        teachers_feedback.Controls.Add(div1);

                        string xpaper123 = rdr["xpaper"].ToString() == "" ? "" : rdr["xpaper"].ToString();
                        string xext123 = rdr["xext"].ToString() == "" ? "" : rdr["xext"].ToString();
                        string xclass123 = xclass2.Text.Trim().ToString();
                        string xsection123 = xsession2.Text.ToString().Trim();

                        DataRow[] xnotification = ((DataTable)ViewState["amworksheet"]).Select("xsubject='" + rdr["xsubject"].ToString() + "' and xpaper='" + xpaper123 + "' and xext='" + xext123 + "'");

                        DataRow[] xnotification1 = ((DataTable)ViewState["amworksheet1"]).Select("xsubject='" + rdr["xsubject"].ToString() + "' and xpaper='" + xpaper123 + "' and xext='" + xext123 + "'");


                        HtmlGenericControl a = new HtmlGenericControl("a");
                        //a.Attributes.Add("href","#");
                        a.Attributes.Add("id", "_link99");
                        //a.Attributes.Add("runat", "server");
                        a.Attributes.Add("onclick", "fnOpenStudentFeedback1('" + rdr["xsubject"].ToString() + "','" + xpaper123 + "','" + xext123 + "','" + xclass123 + "','" + xsection123 + "');");
                        //a.Attributes.Add("onclick", "window.open('/forms/academic/worksheet/amuploadteacher.aspx?zid="+_zid+"&xsession="+xsession.Text.ToString().Trim()
                        //    +"&xterm="+xterm.Text.Trim().ToString()+"&xclass="+xclass.Text.Trim().ToString()+"&xsection="+xsection.Text.Trim().ToString()+"&xsubject="+rdr["xsubject"].ToString()+"&xpaper="+rdr["xpaper"].ToString()+"&xext="+rdr["xext"].ToString()+"', " +
                        //    "'uploadteacher', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');openwin.focus(); return false;");
                        div1.Controls.Add(a);

                        HtmlGenericControl div2 = new HtmlGenericControl("div");
                        div2.Attributes.Add("style", "text-align: center;position: relative;");
                        a.Controls.Add(div2);

                        HtmlGenericControl img = new HtmlGenericControl("img");
                        //img.Attributes.Add("class", "image");

                        int count = xnotification.Length - xnotification1.Length;

                        if (count > 0)
                        {
                            img.Attributes.Add("src", "/images/folder.png");
                        }
                        else
                        {
                            img.Attributes.Add("src", "/images/green_folder.png");
                        }

                        img.Attributes.Add("width", "55px");
                        img.Attributes.Add("height", "55px");
                        div2.Controls.Add(img);

                        if (count > 0)
                        {
                            HtmlGenericControl div21 = new HtmlGenericControl("div"); //ec7063
                            div21.Attributes.Add("style", "position: absolute;top:8px; right: 16px;color:#fff;background-color: #ff0000;padding:1px 6px;border-radius: 50%; -moz-border-radius: 50%;font-weight:bold;");
                            div2.Controls.Add(div21);
                            div21.InnerHtml = count.ToString();
                            //div21.InnerHtml = 100.ToString();

                        }

                        HtmlGenericControl div3 = new HtmlGenericControl("div");
                        div3.Attributes.Add("class", "link");
                        if (rdr["xpapext"].ToString() == "")
                        {
                            div3.InnerHtml = rdr["xsubject"].ToString();
                        }
                        else
                        {
                            div3.InnerHtml = rdr["xsubject"].ToString() + " - " + rdr["xpapext"].ToString();
                        }

                        a.Controls.Add(div3);

                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        public void fnLoadFiles5(object sender, EventArgs e)
        {
            try
            {
                message3.InnerHtml = "";
                //myModal2.Attributes.Add("style", "display:block;");


                BindGrid1();

            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }
        public void fnLoadFiles6(object sender, EventArgs e)
        {
            try
            {
                message3.InnerHtml = "";
                myModal2.Attributes.Add("style", "display:block;");


                BindGrid1();

            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }

        private void BindGrid1()
        {
            BoundField bfield;

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            string xsession123 = xsession.Text.Trim().ToString();
            string xterm123 = xterm.Text.Trim().ToString();
            string xclass123 = xclass.Text.Trim().ToString();
            string xsection123 = xsection.Text.Trim().ToString();
            string xsubject123 = hxsubject3.Value.ToString();
            string xpaper123 = hxpaper3.Value.ToString();
            string xext123 = hxext3.Value.ToString();

            xsession3.InnerHtml = xsession123;
            xterm3.InnerHtml = xterm123;
            xclass3.InnerHtml = xclass123;
            xsection3.InnerHtml = xsection123;
            xsubject3.InnerHtml = hdxsubject3.Value.ToString();

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            string str = "";

            //str = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,right(xwsno,3) as xwsno,substring(xlink,2,len(xlink)) as xlink_f1, xwsno as xwsno1,xremarks FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext AND zemail=@zemail and xstatus='New' and xtype='Upload Homework' ORDER BY xdate desc";

            str = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,right(xwsno,3) as xwsno,substring(xlink,2,len(xlink)) as xlink_f1, xwsno as xwsno1,xremarks,xstatus FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext AND zemail=@zemail and xtype='Upload Homework' ORDER BY xdate desc";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession123);
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm123);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass123);
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection123);
            da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject123);
            da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper123);
            da.SelectCommand.Parameters.AddWithValue("@xext", xext123);
            da.SelectCommand.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {
                //GridView1.Columns.Clear();

                //TemplateField tfield119 = new TemplateField();
                //tfield119.HeaderText = "No.";
                //tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield119.ItemStyle.Width = 35;
                //GridView1.Columns.Add(tfield119);

                //TemplateField tfield1192 = new TemplateField();
                //tfield1192.HeaderText = "WS No.";
                //tfield1192.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield1192.ItemStyle.Width = 50;
                //GridView1.Columns.Add(tfield1192);

                //TemplateField tfield1190 = new TemplateField();
                //tfield1190.HeaderText = "File Name";
                //tfield1190.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                //tfield1190.ItemStyle.Width = 250;
                //GridView1.Columns.Add(tfield1190);

                //bfield = new BoundField();
                //bfield.HeaderText = "Date Send";
                //bfield.DataField = "xdatesend";
                //bfield.ItemStyle.Width = 50;
                //bfield.DataFormatString = "{0:dd/MM/yyyy}";
                //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //GridView1.Columns.Add(bfield);

                //TemplateField tfield11906 = new TemplateField();
                //tfield11906.HeaderText = "HW File";
                //tfield11906.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                //tfield11906.ItemStyle.Width = 200;
                //GridView1.Columns.Add(tfield11906);

                //TemplateField tfield11900 = new TemplateField();
                //tfield11900.HeaderText = "Action";
                //tfield11900.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                ////tfield11900.ItemStyle.Width = 250;
                //GridView1.Columns.Add(tfield11900);

                //BoundField bfield1 = new BoundField();
                //bfield1.DataField = "xrow";
                //GridView1.Columns.Add(bfield1);

                //BoundField bfield11 = new BoundField();
                //bfield11.DataField = "xlink";
                //GridView1.Columns.Add(bfield11);

                //TemplateField tfield1198 = new TemplateField();
                //tfield1198.HeaderText = "No.";
                //tfield1198.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield1198.ItemStyle.Width = 35;
                //tfield1198.ItemStyle.CssClass = "disnone";
                //tfield1198.HeaderStyle.CssClass = "disnone";
                //tfield1198.FooterStyle.CssClass = "disnone";
                //GridView1.Columns.Add(tfield1198);

                GridView3.DataSource = dtmarks;
                GridView3.DataBind();

                _uploaddiv.InnerHtml = "";

                //btnRemove.Visible = true;
                //btnSend.Visible = true;

                //int i = 1;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    if (row.Visible == true)
                //    {
                //        Label lbl = (Label)row.FindControl("lblno2");
                //        lbl.Text = i.ToString();
                //        i++;
                //    }
                //}

                //bfield1.Visible = false;
                //bfield11.Visible = false;

            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();

                _uploaddiv.InnerHtml = "No file available.";

                //btnRemove.Visible = false;
                //btnSend.Visible = false;
            }

            SqlConnection conn11;
            conn11 = new SqlConnection(zglobal.constring);
            DataSet dts1 = new DataSet();

            dts1.Reset();

            string str1 = "";

            str1 = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,right(xwsno,3) as xwsno,substring(xlink,2,len(xlink)) as xlink_f1,xdatesend, xwsno as xwsno1,xremarks FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext AND zemail=@zemail and xstatus='Send' and xtype='Upload Homework' ORDER BY xdate desc";

            SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);
            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession123);
            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm123);
            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass123);
            da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection123);
            da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject123);
            da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper123);
            da1.SelectCommand.Parameters.AddWithValue("@xext", xext123);
            da1.SelectCommand.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
            da1.Fill(dts1, "tempztcode");
            DataTable dtmarks1 = new DataTable();
            dtmarks1 = dts1.Tables[0];

            if (dtmarks1.Rows.Count > 0)
            {

                GridView4.DataSource = dtmarks1;
                GridView4.DataBind();


                _uploaddiv1.InnerHtml = "";


            }
            else
            {
                GridView4.DataSource = null;
                GridView4.DataBind();

                _uploaddiv1.InnerHtml = "No file available.";

            }
        }

        protected void OnRowDataBound4(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.DataItem as DataRowView).Row["xremarks"].ToString() != "")
                    {
                        ImageButton imgbttn = (ImageButton)e.Row.FindControl("btnNote");

                        imgbttn.ImageUrl = "~/images/green_button.png";

                        imgbttn.ToolTip = (e.Row.DataItem as DataRowView).Row["xremarks"].ToString();
                    }

                    if ((e.Row.DataItem as DataRowView).Row["xstatus"].ToString() != "New")
                    {
                        if (e.Row.RowIndex % 2 == 0)
                        {
                            e.Row.BackColor = ColorTranslator.FromHtml("#58d68d");
                        }
                        else
                        {
                            e.Row.BackColor = ColorTranslator.FromHtml(" #82e0aa");
                        }
                    }


                    //ScriptManager1.RegisterPostBackControl(e.Row.FindControl("imgbtn2"));
                }
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.errormsg;
            }
        }

        protected void OnRowDataBound5(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.DataItem as DataRowView).Row["xremarks"].ToString() != "")
                    {
                        ImageButton imgbttn = (ImageButton)e.Row.FindControl("btnNote");

                        imgbttn.ImageUrl = "~/images/green_button.png";

                        imgbttn.ToolTip = (e.Row.DataItem as DataRowView).Row["xremarks"].ToString();
                    }



                    //ScriptManager1.RegisterPostBackControl(e.Row.FindControl("imgbtn"));
                }
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.errormsg;
            }
        }
        public void fnLoadFiles1(object sender, EventArgs e)
        {
            try
            {
                message2.InnerHtml = "";
                myModal1.Attributes.Add("style", "display:block;");


                BindGrid();

            }
            catch (Exception exp)
            {
                message2.InnerHtml = exp.Message;
            }
        }

        public void fnLoadFiles2(object sender, EventArgs e)
        {
            try
            {
                message2.InnerHtml = "";
                BindGrid();
                //UpdatePanel2.Update();
                //UpdatePanel3.Update();
                //message2.InnerHtml = "Hi";
            }
            catch (Exception exp)
            {
                message2.InnerHtml = exp.Message;
            }
        }

        private void BindGrid()
        {
            BoundField bfield;

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            string xsession123 = xsession2.Text.Trim().ToString();
            string xterm123 = xterm2.Text.Trim().ToString();
            string xclass123 = xclass2.Text.Trim().ToString();
            string xsection123 = xsection2.Text.Trim().ToString();
            string xsubject123 = hxsubject1.Value.ToString();
            string xpaper123 = hxpaper1.Value.ToString();
            string xext123 = hxext1.Value.ToString();

            xsession_ph.InnerHtml = xsession123;
            xterm_ph.InnerHtml = xterm123;
            xclass_ph.InnerHtml = xclass123;
            xsection_ph.InnerHtml = xsection123;
            xsubject_ph.InnerHtml = hdxsubject1.Value.ToString();

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            string str = "";

            str = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,right(xwsno,3) as xwsno,xwsno as xwsno1,coalesce(xremarks,'') as xremarks, " +
                  "(select xdatesend from amworksheet as a where a.zid=amworksheet.zid and a.xrow=amworksheet.xref) as xdatesend," +
                  "(select xfile from amworksheet as a where a.zid=amworksheet.zid and a.xrow=amworksheet.xref) as xfile_ref,xreff " +
                  "FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND " +
                  "xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext AND zemail=@zemail and xstatus='New' and xtype='Teacher Feedback' ORDER BY xreff desc";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession123);
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm123);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass123);
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection123);
            da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject123);
            da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper123);
            da.SelectCommand.Parameters.AddWithValue("@xext", xext123);
            da.SelectCommand.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {
                //GridView1.Columns.Clear();

                //TemplateField tfield119 = new TemplateField();
                //tfield119.HeaderText = "No.";
                //tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield119.ItemStyle.Width = 35;
                //GridView1.Columns.Add(tfield119);

                //TemplateField tfield1192 = new TemplateField();
                //tfield1192.HeaderText = "WS No.";
                //tfield1192.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield1192.ItemStyle.Width = 50;
                //GridView1.Columns.Add(tfield1192);

                //TemplateField tfield1190 = new TemplateField();
                //tfield1190.HeaderText = "File Name";
                //tfield1190.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                //tfield1190.ItemStyle.Width = 250;
                //GridView1.Columns.Add(tfield1190);

                //bfield = new BoundField();
                //bfield.HeaderText = "Date Send";
                //bfield.DataField = "xdatesend";
                //bfield.ItemStyle.Width = 50;
                //bfield.DataFormatString = "{0:dd/MM/yyyy}";
                //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //GridView1.Columns.Add(bfield);

                //TemplateField tfield11906 = new TemplateField();
                //tfield11906.HeaderText = "HW File";
                //tfield11906.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                //tfield11906.ItemStyle.Width = 200;
                //GridView1.Columns.Add(tfield11906);

                //TemplateField tfield11900 = new TemplateField();
                //tfield11900.HeaderText = "Action";
                //tfield11900.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                ////tfield11900.ItemStyle.Width = 250;
                //GridView1.Columns.Add(tfield11900);

                //BoundField bfield1 = new BoundField();
                //bfield1.DataField = "xrow";
                //GridView1.Columns.Add(bfield1);

                //BoundField bfield11 = new BoundField();
                //bfield11.DataField = "xlink";
                //GridView1.Columns.Add(bfield11);

                //TemplateField tfield1198 = new TemplateField();
                //tfield1198.HeaderText = "No.";
                //tfield1198.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield1198.ItemStyle.Width = 35;
                //tfield1198.ItemStyle.CssClass = "disnone";
                //tfield1198.HeaderStyle.CssClass = "disnone";
                //tfield1198.FooterStyle.CssClass = "disnone";
                //GridView1.Columns.Add(tfield1198);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();

                _pendinghw.InnerHtml = "";

                //btnRemove.Visible = true;
                //btnSend.Visible = true;

                //int i = 1;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    if (row.Visible == true)
                //    {
                //        Label lbl = (Label)row.FindControl("lblno2");
                //        lbl.Text = i.ToString();
                //        i++;
                //    }
                //}

                //bfield1.Visible = false;
                //bfield11.Visible = false;

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

                _pendinghw.InnerHtml = "No file available.";

                //btnRemove.Visible = false;
                //btnSend.Visible = false;
            }

            SqlConnection conn11;
            conn11 = new SqlConnection(zglobal.constring);
            DataSet dts1 = new DataSet();

            dts1.Reset();

            string str1 = "";

            str1 = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,right(xwsno,3) as xwsno,xwsno as xwsno1,coalesce(xremarks,'') as xremarks, " +
                  "(select xdatesend from amworksheet as a where a.zid=amworksheet.zid and a.xrow=amworksheet.xref) as xdatesend," +
                  "(select xfile from amworksheet as a where a.zid=amworksheet.zid and a.xrow=amworksheet.xref) as xfile_ref,substring(xlink,2,len(xlink)) as xlink_f1,xdatesend as xdatesend1 " +
                  "FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND " +
                  "xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext AND zemail=@zemail and xstatus='Send' and xtype='Teacher Feedback' ORDER BY xreff desc";

            SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);
            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession123);
            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm123);
            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass123);
            da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection123);
            da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject123);
            da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper123);
            da1.SelectCommand.Parameters.AddWithValue("@xext", xext123);
            da1.SelectCommand.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
            da1.Fill(dts1, "tempztcode");
            DataTable dtmarks1 = new DataTable();
            dtmarks1 = dts1.Tables[0];

            if (dtmarks1.Rows.Count > 0)
            {

                GridView2.DataSource = dtmarks1;
                GridView2.DataBind();


                _send.InnerHtml = "";


            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();

                _send.InnerHtml = "No file available.";

            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.DataItem as DataRowView).Row["xremarks"].ToString() != "")
                    {
                        ImageButton imgbttn = (ImageButton)e.Row.FindControl("btnNote");

                        imgbttn.ImageUrl = "~/images/green_button.png";

                        imgbttn.ToolTip = (e.Row.DataItem as DataRowView).Row["xremarks"].ToString();
                    }

                    //        //int xrow = int.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

                    //        //string xlink_f = (e.Row.DataItem as DataRowView).Row["xlink"].ToString();
                    //        //string xlink_f1 = xlink_f.Substring(1, xlink_f.Length - 1);

                    //        Label lblno = new Label();
                    //        lblno.ID = "lblno2";
                    //        e.Row.Cells[0].Controls.Add(lblno);

                    //        Label lblws = new Label();
                    //        lblws.ID = "xwsno_phw";
                    //        lblws.Text = (e.Row.DataItem as DataRowView).Row["xwsno"].ToString();
                    //        e.Row.Cells[1].Controls.Add(lblws);

                    //        Label lblfile = new Label();
                    //        lblfile.ID = "xfile_phw";
                    //        lblfile.ToolTip = (e.Row.DataItem as DataRowView).Row["xfile_ref"].ToString();
                    //        lblfile.Text = (e.Row.DataItem as DataRowView).Row["xfile_ref"].ToString();
                    //        e.Row.Cells[2].Controls.Add(lblfile);




                    //        FileUpload fileUpload = new FileUpload();
                    //        fileUpload.ID = "xlink_phw";
                    //        fileUpload.EnableViewState = true;
                    //        fileUpload.Width = Unit.Pixel(198);
                    //        e.Row.Cells[4].Controls.Add(fileUpload);


                    //        //HtmlGenericControl input = new HtmlGenericControl("input");
                    //        //input.Attributes.Add("type", "image");
                    //        //input.Attributes.Add("id", "image_phw");
                    //        //input.Attributes.Add("title", "Submit file");
                    //        //input.Attributes.Add("src", "/images/send_icon64x64.png");
                    //        //input.Attributes.Add("style", "width:16px;height:16px;");
                    //        //input.Attributes.Add("class", "bm_academic_button_zoom");
                    //        //input.Attributes.Add("onclick", "fnSubmitHW('" + (e.Row.DataItem as DataRowView).Row["xrow"].ToString() + "','"+e.Row.RowIndex+"');");
                    //        //e.Row.Cells[5].Controls.Add(input);

                    //        ImageButton imgbtn = new ImageButton();
                    //        imgbtn.ImageUrl = "~/images/send_icon64x64.png";
                    //        imgbtn.Width=Unit.Pixel(16);
                    //        imgbtn.Height=Unit.Pixel(16);
                    //        imgbtn.CssClass = "bm_academic_button_zoom";
                    //        e.Row.Cells[5].Controls.Add(imgbtn);
                    //        imgbtn.Click += ImgbtnOnClick;

                    //        TextBox lblno2 = new TextBox();
                    //        lblno2.ID = "labelLink";
                    //        lblno2.Text = "text";
                    //        lblno2.EnableViewState = true;
                    //        e.Row.Cells[8].Controls.Add(lblno2);

                    ScriptManager1.RegisterPostBackControl(e.Row.FindControl("imgbtn"));
                }
            }
            catch (Exception exp)
            {
                message2.InnerHtml = exp.Message;
                message2.Style.Value = zglobal.errormsg;
            }
        }

        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    if ((e.Row.DataItem as DataRowView).Row["xremarks"].ToString() != "")
                    {
                        ImageButton imgbttn = (ImageButton)e.Row.FindControl("btnNote");

                        imgbttn.ImageUrl = "~/images/green_button.png";

                        imgbttn.ToolTip = (e.Row.DataItem as DataRowView).Row["xremarks"].ToString();
                    }


                }
            }
            catch (Exception exp)
            {
                message2.InnerHtml = exp.Message;
                message2.Style.Value = zglobal.errormsg;
            }
        }

        public void ImgbtnOnClick(object sender, ImageClickEventArgs imageClickEventArgs)
        {
            try
            {
                //message2.InnerHtml = "Hi";

                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                if (row != null)
                {


                    string folderPath = HttpContext.Current.Server.MapPath("~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    //message2.InnerHtml = row.RowIndex.ToString();

                    FileUpload xlink = GridView1.Rows[row.RowIndex].FindControl("xlink_phw") as FileUpload;
                    //AsyncFileUpload xlink = GridView1.Rows[row.RowIndex].FindControl("xlink_phw") as AsyncFileUpload;

                    if (xlink.HasFile == false)
                    {
                        message2.InnerHtml = "Please select a file";
                        message2.Style.Value = zglobal.am_warningmsg;
                        //return;
                    }
                    else
                    {
                        //message2.InnerHtml = "file";

                        string xrow123 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();
                        string xreff123 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("xwsno1")).Text.ToString();

                        //message2.InnerHtml = xrow123;

                        string extension = Path.GetExtension(xlink.PostedFile.FileName);
                        //string fileName = Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                        string fileName = xreff123.ToString().Substring(xreff123.ToString().Length - 3) + "_" + hxsubject1.Value + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                        string xfile123 = xreff123.ToString().Substring(xreff123.ToString().Length - 3) + "_" + hxsubject1.Value + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + extension;
                        string imagePath = folderPath + fileName;
                        xlink.SaveAs(imagePath);
                        string _xlink = "~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/" + fileName;

                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd = new SqlCommand();
                        dataCmd.Connection = conn1;
                        string query;

                        query = "UPDATE amworksheet SET zutime=@zutime,xlink=@xlink,xstatus='Send',xdatesend=@xdatesend,xfile=@xfile,xfile1=@xfile1,xfileext=@xfileext,xflag1='Submitted' " +
                                "WHERE zid=@zid AND xrow=@xrow";

                        int xrow = int.Parse(xrow123);

                        dataCmd.CommandText = query;

                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                        dataCmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                        dataCmd.Parameters.AddWithValue("@zid", _zid);
                        dataCmd.Parameters.AddWithValue("@xrow", xrow);
                        dataCmd.Parameters.AddWithValue("@xlink", _xlink);
                        dataCmd.Parameters.AddWithValue("@xdatesend", DateTime.Now);
                        //dataCmd.Parameters.AddWithValue("@xfile", Path.GetFileName(xlink.PostedFile.FileName));
                        dataCmd.Parameters.AddWithValue("@xfile", xfile123);
                        dataCmd.Parameters.AddWithValue("@xfile1", fileName);
                        dataCmd.Parameters.AddWithValue("@xfileext", extension);

                        conn1.Close();
                        conn1.Open();
                        dataCmd.ExecuteNonQuery();
                        conn1.Close();

                        dataCmd.Dispose();
                        conn1.Dispose();

                        message2.InnerHtml = "Submit Successfull.";
                        message2.Style.Value = zglobal.am_successmsg;
                    }


                }





                BindGrid();

                //message2.InnerHtml = "";

                UpdatePanel3.Update();
                //UpdatePanel2.Update();

                myModal1.Attributes.Add("style", "display:block;");


            }
            catch (Exception exp)
            {
                message2.InnerHtml = exp.Message;
                message2.Style.Value = zglobal.errormsg;
            }
        }

        public void ImgbtndeleteOnClick(object sender, ImageClickEventArgs imageClickEventArgs)
        {
            try
            {
                //message2.InnerHtml = "Hi";

                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                if (row != null)
                {


                    string xrow123 = ((TextBox)GridView2.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();

                    //message2.InnerHtml = xrow123;

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            conn.Open();

                            string query1 = "SELECT * FROM amworksheet WHERE zid=@zid and xref=@xref ";
                            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xref", xrow123);
                            DataTable tempTable = new DataTable();
                            da.Fill(dts, "tempTable");
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {
                                message2.InnerHtml = "Delete Failed.";
                                message2.Style.Value = zglobal.am_warningmsg;
                                return;
                            }

                        }
                    }

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    query = "UPDATE amworksheet SET zutime=@zutime,xstatus='New',xdatesend=NULL,xfile=NULL,xfile1=NULL,xfileext=NULL,xflag1='Returned',xlink=NULL " +
                            "WHERE zid=@zid AND xrow=@xrow";

                    int xrow = int.Parse(xrow123);

                    dataCmd.CommandText = query;

                    string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                    dataCmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                    dataCmd.Parameters.AddWithValue("@zid", _zid);
                    dataCmd.Parameters.AddWithValue("@xrow", xrow);

                    conn1.Close();
                    conn1.Open();
                    dataCmd.ExecuteNonQuery();
                    conn1.Close();

                    dataCmd.Dispose();
                    conn1.Dispose();

                    File.Delete(Server.MapPath(((TextBox)GridView2.Rows[row.RowIndex].FindControl("xlink")).Text.ToString()));

                    message2.InnerHtml = "Delete Successfull.";
                    message2.Style.Value = zglobal.am_successmsg;


                }





                BindGrid();

                //message2.InnerHtml = "";

                UpdatePanel3.Update();
                //UpdatePanel2.Update();

                //myModal1.Attributes.Add("style", "display:block;");


            }
            catch (Exception exp)
            {
                message2.InnerHtml = exp.Message;
                message2.Style.Value = zglobal.errormsg;
            }
        }

        public void fnStudentFeedback(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                myModal.Attributes.Add("style", "display:none;");
                myModal1.Attributes.Add("style", "display:none;");
                myModal2.Attributes.Add("style", "display:none;");

                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);

                using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                            "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,xsubject,xpaper,xext FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection and xstatus='Send' and xtype='Student Feedback' and " +
                            "xref in (select xrow from amworksheet where zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection and xstatus='Send' and xtype='Upload Homework' and zemail=@zemail)";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", int.Parse(_zid));
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm1.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection1.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@zemail",
                           HttpContext.Current.Session["curuser"].ToString());
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amworksheet"] = dtamexamd;

                        //dtamexamd.Dispose();
                    }
                }

                using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                            "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,xsubject,xpaper,xext,xref FROM xnotificationvw WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection  and xtype='Student Feedback' and zemail1=@zemail1";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm1.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection1.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@zemail1",
                           HttpContext.Current.Session["curuser"].ToString());
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["xnotificationvw"] = dtamexamd;

                        //dtamexamd.Dispose();
                    }
                }

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    if (ViewState["ispostback2"].ToString() != "yes")
                    {
                        bool isValid = true;
                        string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                        if (xsession1.Text == "" || xsession1.Text == string.Empty || xsession1.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Session</li>";
                            isValid = false;
                        }
                        if (xterm1.Text == "" || xterm1.Text == string.Empty || xterm1.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Term</li>";
                            isValid = false;
                        }
                        if (xclass1.Text == "" || xclass1.Text == string.Empty || xclass1.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Class</li>";
                            isValid = false;
                        }
                        if (xsection1.Text == "" || xsection1.Text == string.Empty || xsection1.Text == "[Select]")
                        {
                            rtnMessage = rtnMessage + "<li>Section</li>";
                            isValid = false;
                        }


                        rtnMessage = rtnMessage + "</ol></div>";
                        if (!isValid)
                        {
                            message.InnerHtml = rtnMessage;
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }
                    }

                    ViewState["ispostback2"] = "no";

                    string query = "SELECT xsubject,xpapext,xpaper,xext FROM amclasssubvw WHERE zid=@zid AND xclass=@xclass order by xsubject";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                    cmd.Parameters.AddWithValue("@xclass", xclass1.Text.ToString().Trim());
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    students_feedback.Controls.Clear();
                    while (rdr.Read())
                    {

                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        div1.Attributes.Add("class", "link_con image");
                        students_feedback.Controls.Add(div1);

                        string xpaper123 = rdr["xpaper"].ToString() == "" ? "" : rdr["xpaper"].ToString();
                        string xext123 = rdr["xext"].ToString() == "" ? "" : rdr["xext"].ToString();
                        string xclass123 = xclass1.Text.Trim().ToString();
                        string xsection123 = xsection1.Text.Trim().ToString();

                        DataRow[] xnotification = ((DataTable)ViewState["amworksheet"]).Select("xsubject='" + rdr["xsubject"].ToString() + "' and xpaper='" + xpaper123 + "' and xext='" + xext123 + "'");

                        DataRow[] xnotification1 = ((DataTable)ViewState["xnotificationvw"]).Select("xsubject='" + rdr["xsubject"].ToString() + "' and xpaper='" + xpaper123 + "' and xext='" + xext123 + "'");


                        HtmlGenericControl a = new HtmlGenericControl("a");
                        //a.Attributes.Add("href","#");
                        a.Attributes.Add("id", "_link");
                        a.Attributes.Add("onclick", "fnOpenStudentFeedback('" + rdr["xsubject"].ToString() + "','" + xpaper123 + "','" + xext123 + "','" + xclass123 + "','" + xsection123 + "');");
                        //a.Attributes.Add("onclick", "window.open('/forms/academic/worksheet/amuploadteacher.aspx?zid="+_zid+"&xsession="+xsession.Text.ToString().Trim()
                        //    +"&xterm="+xterm.Text.Trim().ToString()+"&xclass="+xclass.Text.Trim().ToString()+"&xsection="+xsection.Text.Trim().ToString()+"&xsubject="+rdr["xsubject"].ToString()+"&xpaper="+rdr["xpaper"].ToString()+"&xext="+rdr["xext"].ToString()+"', " +
                        //    "'uploadteacher', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');openwin.focus(); return false;");
                        div1.Controls.Add(a);

                        HtmlGenericControl div2 = new HtmlGenericControl("div");
                        div2.Attributes.Add("style", "text-align: center;position: relative;");
                        a.Controls.Add(div2);

                        HtmlGenericControl img = new HtmlGenericControl("img");
                        //img.Attributes.Add("class", "image");

                        int count = xnotification.Length - xnotification1.Length;

                        if (count > 0)
                        {
                            img.Attributes.Add("src", "/images/folder.png");
                        }
                        else
                        {
                            img.Attributes.Add("src", "/images/green_folder.png");
                        }

                        img.Attributes.Add("width", "55px");
                        img.Attributes.Add("height", "55px");
                        div2.Controls.Add(img);

                        if (count > 0)
                        {
                            HtmlGenericControl div21 = new HtmlGenericControl("div"); //ec7063
                            div21.Attributes.Add("style", "position: absolute;top:8px; right: 16px;color:#fff;background-color: #ff0000;padding:1px 6px;border-radius: 50%; -moz-border-radius: 50%;font-weight:bold;");
                            div2.Controls.Add(div21);
                            div21.InnerHtml = count.ToString();
                            //div21.InnerHtml = 100.ToString();
                        }

                        HtmlGenericControl div3 = new HtmlGenericControl("div");
                        div3.Attributes.Add("class", "link");
                        if (rdr["xpapext"].ToString() == "")
                        {
                            div3.InnerHtml = rdr["xsubject"].ToString();
                        }
                        else
                        {
                            div3.InnerHtml = rdr["xsubject"].ToString() + " - " + rdr["xpapext"].ToString();
                        }

                        a.Controls.Add(div3);

                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        public void fnLoadFiles(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                myModal.Attributes.Add("style", "display:block;");


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query =
                            "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,xsubject,xpaper,xext,xref FROM xnotificationvw WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection  and xtype='Student Feedback' and zemail1=@zemail1";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con1);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm1.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass1.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection1.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@zemail1",
                           HttpContext.Current.Session["curuser"].ToString());
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["xnotificationvw"] = dtamexamd;

                        //dtamexamd.Dispose();
                    }
                }


                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);



                string xsession123 = xsession1.Text.Trim().ToString();
                string xterm123 = xterm1.Text.Trim().ToString();
                string xclass123 = xclass1.Text.Trim().ToString();
                string xsection123 = xsection1.Text.Trim().ToString();
                string xsubject123 = hxsubject.Value.ToString();
                string xpaper123 = hxpaper.Value.ToString();
                string xext123 = hxext.Value.ToString();

                xsession_dw.InnerHtml = xsession123;
                xterm_dw.InnerHtml = xterm123;
                xclass_dw.InnerHtml = xclass123;
                xsection_dw.InnerHtml = xsection123;
                xsubject_dw.InnerHtml = hdxsubject.Value.ToString();

                string str = "";

                str = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,xdatesend, " +
                      "coalesce((select xname from amadmis where zid=@zid and xstdid=xstudent),'') " +
                      "as xname,xflag,xref,xwsno as xwsno1 FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject " +
                      "AND xpaper=@xpaper AND xext=@xext and xstatus='Send' and xtype='Student Feedback' and " +
                      "xref in (select xrow from amworksheet where zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject " +
                      "AND xpaper=@xpaper AND xext=@xext and xstatus='Send' and xtype='Upload Homework' and zemail=@zemail) " +
                      "ORDER BY xdatesend desc";

                SqlCommand cmd = new SqlCommand(str, conn1);

                cmd.Parameters.AddWithValue("@zid", _zid);
                cmd.Parameters.AddWithValue("@xsession", xsession123);
                cmd.Parameters.AddWithValue("@xterm", xterm123);
                cmd.Parameters.AddWithValue("@xclass", xclass123);
                cmd.Parameters.AddWithValue("@xsection", xsection123);
                cmd.Parameters.AddWithValue("@xsubject", xsubject123);
                cmd.Parameters.AddWithValue("@xpaper", xpaper123);
                cmd.Parameters.AddWithValue("@xext", xext123);
                cmd.Parameters.AddWithValue("@zemail",
                           HttpContext.Current.Session["curuser"].ToString());
                cmd.CommandType = CommandType.Text;
                conn1.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                _storeddiv.Controls.Clear();

                if (rdr.HasRows == true)
                {
                    _soterd.InnerHtml = "";
                }
                else
                {
                    _soterd.InnerHtml = "No file available.";
                }

                while (rdr.Read())
                {
                    //combo.Items.Add(rdr["xsubject"].ToString());

                    //<div class="link_con">
                    //    <a href="#">
                    //        <div style="text-align: center">
                    //            <img class="image" src="images/Routine.png" width="75px" height="75px" />
                    //        </div>
                    //        <div class="link">
                    //            Routine
                    //        </div>
                    //    </a>
                    //</div>

                    HtmlGenericControl div1 = new HtmlGenericControl("div");
                    div1.Attributes.Add("class", "link_con _width");
                    div1.Attributes.Add("title", "Submit date : " + Convert.ToDateTime(rdr["xdatesend"]).ToString("dd/MM/yyyy") + "\nSubmit by : " + rdr["xname"].ToString());
                    _storeddiv.Controls.Add(div1);

                    //string xpaper123 = rdr["xpaper"].ToString() == "" ? "" : rdr["xpaper"].ToString();
                    //string xext123 = rdr["xext"].ToString() == "" ? "" : rdr["xext"].ToString();
                    //string xclass123 = HttpContext.Current.Session["xclass"].ToString();
                    //string xsection123 = HttpContext.Current.Session["xsection"].ToString();

                    //DataRow[] xnotification = ((DataTable)ViewState["xnotificationvw"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");
                    DataRow[] xnotification = ((DataTable)ViewState["xnotificationvw"]).Select("xref='" + rdr["xrow"].ToString() + "'");

                    string xlink_f = rdr["xlink"].ToString();
                    string xlink_f1 = xlink_f.Substring(1, xlink_f.Length - 1);

                    HtmlGenericControl a = new HtmlGenericControl("a");
                    //a.Attributes.Add("href","#");
                    a.Attributes.Add("id", "_link1|" + rdr["xrow"].ToString() + "|" + rdr["xref"].ToString() + "|" + rdr["xwsno1"].ToString());
                    //a.Attributes.Add("onclick", "fnOnLinkClick");
                    //a.Attributes.Add("onclick", "fnOpenDownload('" + rdr["xsubject"].ToString() + "','" + xpaper123 + "','" + xext123 + "','" + xclass123 + "','" + xsection123 + "');");
                    //a.Attributes.Add("onclick", "window.open('/forms/academic/worksheet/amuploadteacher.aspx?zid="+_zid+"&xsession="+xsession.Text.ToString().Trim()
                    //    +"&xterm="+xterm.Text.Trim().ToString()+"&xclass="+xclass.Text.Trim().ToString()+"&xsection="+xsection.Text.Trim().ToString()+"&xsubject="+rdr["xsubject"].ToString()+"&xpaper="+rdr["xpaper"].ToString()+"&xext="+rdr["xext"].ToString()+"', " +
                    //    "'uploadteacher', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');openwin.focus(); return false;");
                    a.Attributes.Add("href", xlink_f1);
                    //a.Attributes.Add("download", rdr["xfile1"].ToString());
                    a.Attributes.Add("download", rdr["xfile"].ToString());
                    //a.InnerHtml = rdr["xfile"].ToString();
                    div1.Controls.Add(a);



                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Attributes.Add("style", "text-align: center;position: relative;");
                    a.Controls.Add(div2);

                    HtmlGenericControl img = new HtmlGenericControl("img");
                    img.Attributes.Add("class", "image");

                    if (rdr["xfileext"].ToString() == ".doc" || rdr["xfileext"].ToString() == ".docx")
                    {
                        img.Attributes.Add("src", "/images/msword_logo.png");
                    }
                    else if (rdr["xfileext"].ToString() == ".xls" || rdr["xfileext"].ToString() == ".xlsx")
                    {
                        img.Attributes.Add("src", "/images/msexcel_logo.png");
                    }
                    else if (rdr["xfileext"].ToString() == ".ppt" || rdr["xfileext"].ToString() == ".pptx")
                    {
                        img.Attributes.Add("src", "/images/powerpoint_icon.png");
                    }
                    else if (rdr["xfileext"].ToString() == ".pdf")
                    {
                        img.Attributes.Add("src", "/images/pdf_logo.png");
                    }
                    else if (rdr["xfileext"].ToString() == ".jpg" || rdr["xfileext"].ToString() == ".jpeg" || rdr["xfileext"].ToString() == ".png" || rdr["xfileext"].ToString() == ".gif" || rdr["xfileext"].ToString() == ".bmp")
                    {
                        img.Attributes.Add("src", "/images/image_logo.png");
                    }
                    else
                    {
                        img.Attributes.Add("src", "/images/text_logo.png");
                    }

                    img.Attributes.Add("width", "65px");
                    img.Attributes.Add("height", "65px");
                    div2.Controls.Add(img);

                    if (xnotification.Length <= 0)
                    {
                        HtmlGenericControl div21 = new HtmlGenericControl("div"); //ec7063
                        div21.Attributes.Add("style", "position: absolute;top:8px; right: 16px;color:#fff;background-color: #ff0000;padding:3px;border-radius: 50%; -moz-border-radius: 50%;font-weight:bold;");
                        div2.Controls.Add(div21);
                        //div21.InnerHtml = xnotification.Length.ToString();
                        div21.InnerHtml = "New";

                    }

                    HtmlGenericControl div3 = new HtmlGenericControl("div");
                    div3.Attributes.Add("class", "link");
                    div3.InnerHtml = rdr["xfile"].ToString();
                    a.Controls.Add(div3);

                    //HtmlGenericControl div31 = new HtmlGenericControl("span");
                    //div31.Attributes.Add("class", "tooltiptext");
                    //div31.InnerHtml = Convert.ToDateTime(rdr["xdatesend"]).ToString("dd/MM/yyyy");
                    //div1.Controls.Add(div31);

                }
            }
            catch (Exception exp)
            {
                message1.InnerHtml = exp.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string fnInsert(string zid9, string xsession9, string xterm9, string xclass9, string xsection9, string xsubject9, string xpaper9, string xext9, string xref9, string xreff9, string xwsno9)
        {

            try
            {
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        conn.Open();

                        string query1 = "SELECT * FROM amworksheet WHERE zid=@zid and xsession=@xsession and xterm=@xterm and xclass=@xclass and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and zemail=@zemail and xtype='Teacher Feedback' and xref=@xref";
                        SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                        da.SelectCommand.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
                        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession9);
                        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm9);
                        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass9);
                        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection9);
                        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject9);
                        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper9);
                        da.SelectCommand.Parameters.AddWithValue("@xext", xext9);
                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xref", xref9);
                        DataTable tempTable = new DataTable();
                        da.Fill(dts, "tempTable");
                        tempTable = dts.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            return "success";
                        }

                    }
                }



                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "INSERT INTO amworksheet (ztime,zid,xrow,xsession,xterm,xclass,xsection,xsubject,xpaper,xext,xref,xflag,zemail,xstatus,xtype,xteacher,xdate,xreff,xwsno) " +
                        "VALUES (@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xsection,@xsubject,@xpaper,@xext,@xref,@xflag,@zemail,@xstatus,@xtype,@xteacher,@xdate,@xreff,@xwsno)";

                int xrow = zglobal.GetMaximumIdInt("xrow", "amworksheet", " zid=" + _zid, 1, 1);

                dataCmd.CommandText = query;

                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //string xdate1 = xdate2;
                //string xcoach1 = xcoach2;

                dataCmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                dataCmd.Parameters.AddWithValue("@zid", _zid);
                dataCmd.Parameters.AddWithValue("@xrow", xrow);
                dataCmd.Parameters.AddWithValue("@xsession", xsession9);
                dataCmd.Parameters.AddWithValue("@xterm", xterm9);
                dataCmd.Parameters.AddWithValue("@xclass", xclass9);
                dataCmd.Parameters.AddWithValue("@xsection", xsection9);
                dataCmd.Parameters.AddWithValue("@xsubject", xsubject9);
                dataCmd.Parameters.AddWithValue("@xpaper", xpaper9);
                dataCmd.Parameters.AddWithValue("@xext", xext9);
                dataCmd.Parameters.AddWithValue("@xref", xref9);
                dataCmd.Parameters.AddWithValue("@xflag", "Download");
                dataCmd.Parameters.AddWithValue("@zemail", zemail1);
                dataCmd.Parameters.AddWithValue("@xstatus", "New");
                dataCmd.Parameters.AddWithValue("@xtype", "Teacher Feedback");
                dataCmd.Parameters.AddWithValue("@xteacher", zemail1);
                dataCmd.Parameters.AddWithValue("@xdate", DateTime.Now);
                dataCmd.Parameters.AddWithValue("@xreff", xreff9);
                dataCmd.Parameters.AddWithValue("@xwsno", xwsno9);

                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                dataCmd.Dispose();
                conn1.Dispose();

                return "success";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }


        }

        public void ImgbtnOnClick1(object sender, ImageClickEventArgs imageClickEventArgs)
        {
            try
            {
                //message2.InnerHtml = "Hi";

                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                if (row != null)
                {




                    string xrow123 = ((TextBox)GridView3.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    query = "UPDATE amworksheet SET zutime=@zutime,xstatus='Send',xdatesend=@xdatesend,xflag1='Submitted',xemail=@xemail " +
                            "WHERE zid=@zid AND xrow=@xrow";

                    int xrow = int.Parse(xrow123);

                    dataCmd.CommandText = query;

                    string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                    dataCmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                    dataCmd.Parameters.AddWithValue("@xemail", zemail1);
                    dataCmd.Parameters.AddWithValue("@zid", _zid);
                    dataCmd.Parameters.AddWithValue("@xrow", xrow);
                    dataCmd.Parameters.AddWithValue("@xdatesend", DateTime.Now);

                    conn1.Close();
                    conn1.Open();
                    dataCmd.ExecuteNonQuery();
                    conn1.Close();

                    dataCmd.Dispose();
                    conn1.Dispose();

                    message3.InnerHtml = "Upload Successfull.";
                    message3.Style.Value = zglobal.am_successmsg;


                }





                BindGrid1();

                //message2.InnerHtml = "";

                UpdatePanel2.Update();
                //UpdatePanel2.Update();

                //myModal2.Attributes.Add("style", "display:block;");


            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.errormsg;
            }
        }

        public void ImgbtndeleteOnClick1(object sender, ImageClickEventArgs imageClickEventArgs)
        {
            try
            {
                //message2.InnerHtml = "Hi";

                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                if (row != null)
                {


                    string xrow123 = ((TextBox)GridView3.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();

                    //message2.InnerHtml = xrow123;

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            conn.Open();

                            string query1 = "SELECT * FROM amworksheet WHERE zid=@zid and xref=@xref ";
                            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xref", xrow123);
                            DataTable tempTable = new DataTable();
                            da.Fill(dts, "tempTable");
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {
                                message3.InnerHtml = "Delete Failed.";
                                message3.Style.Value = zglobal.am_warningmsg;
                                return;
                            }

                        }
                    }


                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    query = "DELETE amworksheet WHERE zid=@zid and xrow=@xrow ";



                    int xrow = int.Parse(xrow123);

                    dataCmd.CommandText = query;

                    dataCmd.Parameters.AddWithValue("@zid", _zid);
                    dataCmd.Parameters.AddWithValue("@xrow", xrow);

                    conn1.Close();
                    conn1.Open();
                    dataCmd.ExecuteNonQuery();
                    conn1.Close();

                    dataCmd.Dispose();
                    conn1.Dispose();

                    File.Delete(Server.MapPath(((TextBox)GridView3.Rows[row.RowIndex].FindControl("xlink")).Text.ToString()));

                    message3.InnerHtml = "Delete Successfull.";
                    message3.Style.Value = zglobal.am_successmsg;


                }





                BindGrid1();

                //message2.InnerHtml = "";

                UpdatePanel2.Update();
                //UpdatePanel2.Update();

                //myModal1.Attributes.Add("style", "display:block;");


            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.errormsg;
            }
        }

        public void ImgbtndeleteOnClick3(object sender, ImageClickEventArgs imageClickEventArgs)
        {
            try
            {
                //message2.InnerHtml = "Hi";

                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                if (row != null)
                {


                    string xrow123 = ((TextBox)GridView4.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();

                    //message2.InnerHtml = xrow123;

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            conn.Open();

                            string query1 = "SELECT * FROM amworksheet WHERE zid=@zid and xref=@xref ";
                            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xref", xrow123);
                            DataTable tempTable = new DataTable();
                            da.Fill(dts, "tempTable");
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {
                                message3.InnerHtml = "Return Failed.";
                                message3.Style.Value = zglobal.am_warningmsg;
                                return;
                            }

                        }
                    }


                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;

                    query = "UPDATE amworksheet SET xstatus='New' WHERE zid=@zid and xrow=@xrow ";



                    int xrow = int.Parse(xrow123);

                    dataCmd.CommandText = query;

                    dataCmd.Parameters.AddWithValue("@zid", _zid);
                    dataCmd.Parameters.AddWithValue("@xrow", xrow);

                    conn1.Close();
                    conn1.Open();
                    dataCmd.ExecuteNonQuery();
                    conn1.Close();

                    dataCmd.Dispose();
                    conn1.Dispose();



                    message3.InnerHtml = "Return Successfull.";
                    message3.Style.Value = zglobal.am_successmsg;


                }





                BindGrid1();

                //message2.InnerHtml = "";

                UpdatePanel2.Update();
                //UpdatePanel2.Update();

                //myModal1.Attributes.Add("style", "display:block;");


            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.errormsg;
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

        protected void btnClose_OnClick(object sender, EventArgs e)
        {
            message.InnerHtml = "";
        }


        protected void btnNote_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string xrow123 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();


                        string query =
                       "SELECT xremarks FROM amworksheet " +
                       "WHERE zid=@zid AND xrow=@xrow";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow123);
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            TextBox xremarks123 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtnote"));
                            xremarks123.Text = dtamexamd.Rows[0]["xremarks"].ToString();
                        }

                    }
                }


                Panel _note = (Panel)GridView1.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = true;
            }
            catch (Exception exp)
            {
                message1.InnerHtml = exp.Message;
                message1.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnNote_OnClick1(object sender, ImageClickEventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string xrow123 = ((TextBox)GridView2.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();


                        string query =
                       "SELECT xremarks FROM amworksheet " +
                       "WHERE zid=@zid AND xrow=@xrow";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow123);
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            TextBox xremarks123 = ((TextBox)GridView2.Rows[row.RowIndex].FindControl("txtnote"));
                            xremarks123.Text = dtamexamd.Rows[0]["xremarks"].ToString();
                        }

                    }
                }


                Panel _note = (Panel)GridView2.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = true;
            }
            catch (Exception exp)
            {
                message1.InnerHtml = exp.Message;
                message1.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnNote_OnClick2(object sender, ImageClickEventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string xrow123 = ((TextBox)GridView3.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();


                        string query =
                       "SELECT xremarks FROM amworksheet " +
                       "WHERE zid=@zid AND xrow=@xrow";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow123);
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            TextBox xremarks123 = ((TextBox)GridView3.Rows[row.RowIndex].FindControl("txtnote"));
                            xremarks123.Text = dtamexamd.Rows[0]["xremarks"].ToString();
                        }

                    }
                }


                Panel _note = (Panel)GridView3.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = true;
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnNote_OnClick3(object sender, ImageClickEventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string xrow123 = ((TextBox)GridView4.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();


                        string query =
                       "SELECT xremarks FROM amworksheet " +
                       "WHERE zid=@zid AND xrow=@xrow";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xrow", xrow123);
                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            TextBox xremarks123 = ((TextBox)GridView4.Rows[row.RowIndex].FindControl("txtnote"));
                            xremarks123.Text = dtamexamd.Rows[0]["xremarks"].ToString();
                        }

                    }
                }


                Panel _note = (Panel)GridView4.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = true;
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnClose_OnClick1(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                Panel _note = (Panel)GridView1.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message1.InnerHtml = exp.Message;
                message1.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnClose_OnClick11(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                Panel _note = (Panel)GridView2.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message1.InnerHtml = exp.Message;
                message1.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnClose_OnClick2(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                Panel _note = (Panel)GridView3.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnClose_OnClick3(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                Panel _note = (Panel)GridView4.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                //ImageButton imgbttn = (ImageButton)GridView1.Rows[row.RowIndex].FindControl("btnNote");

                //imgbttn.ImageUrl = "~/images/green_button.png";

                string xrow123 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();
                string xremarks123 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtnote")).Text.ToString();

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "UPDATE amworksheet SET xremarks=@xremarks " +
                        "WHERE zid=@zid AND xrow=@xrow";

                int xrow = int.Parse(xrow123);

                dataCmd.CommandText = query;

                //string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                //dataCmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                dataCmd.Parameters.AddWithValue("@zid", _zid);
                dataCmd.Parameters.AddWithValue("@xrow", xrow);
                dataCmd.Parameters.AddWithValue("@xremarks", xremarks123);

                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                dataCmd.Dispose();
                conn1.Dispose();



                BindGrid();

                Panel _note = (Panel)GridView1.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message1.InnerHtml = exp.Message;
                message1.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnOk_OnClick1(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message2.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                //ImageButton imgbttn = (ImageButton)GridView1.Rows[row.RowIndex].FindControl("btnNote");

                //imgbttn.ImageUrl = "~/images/green_button.png";

                string xrow123 = ((TextBox)GridView2.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();
                string xremarks123 = ((TextBox)GridView2.Rows[row.RowIndex].FindControl("txtnote")).Text.ToString();

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "UPDATE amworksheet SET xremarks=@xremarks " +
                        "WHERE zid=@zid AND xrow=@xrow";

                int xrow = int.Parse(xrow123);

                dataCmd.CommandText = query;

                //string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                //dataCmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                dataCmd.Parameters.AddWithValue("@zid", _zid);
                dataCmd.Parameters.AddWithValue("@xrow", xrow);
                dataCmd.Parameters.AddWithValue("@xremarks", xremarks123);

                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                dataCmd.Dispose();
                conn1.Dispose();



                BindGrid();

                Panel _note = (Panel)GridView2.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message1.InnerHtml = exp.Message;
                message1.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnOk_OnClick2(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                //ImageButton imgbttn = (ImageButton)GridView1.Rows[row.RowIndex].FindControl("btnNote");

                //imgbttn.ImageUrl = "~/images/green_button.png";

                string xrow123 = ((TextBox)GridView3.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();
                string xremarks123 = ((TextBox)GridView3.Rows[row.RowIndex].FindControl("txtnote")).Text.ToString();

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "UPDATE amworksheet SET xremarks=@xremarks " +
                        "WHERE zid=@zid AND xrow=@xrow";

                int xrow = int.Parse(xrow123);

                dataCmd.CommandText = query;

                //string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                //dataCmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                dataCmd.Parameters.AddWithValue("@zid", _zid);
                dataCmd.Parameters.AddWithValue("@xrow", xrow);
                dataCmd.Parameters.AddWithValue("@xremarks", xremarks123);

                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                dataCmd.Dispose();
                conn1.Dispose();



                BindGrid1();

                Panel _note = (Panel)GridView3.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnOk_OnClick3(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message3.InnerHtml = "";

                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                Button ib = (Button)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                //ImageButton imgbttn = (ImageButton)GridView1.Rows[row.RowIndex].FindControl("btnNote");

                //imgbttn.ImageUrl = "~/images/green_button.png";

                string xrow123 = ((TextBox)GridView4.Rows[row.RowIndex].FindControl("xrow")).Text.ToString();
                string xremarks123 = ((TextBox)GridView4.Rows[row.RowIndex].FindControl("txtnote")).Text.ToString();

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "UPDATE amworksheet SET xremarks=@xremarks " +
                        "WHERE zid=@zid AND xrow=@xrow";

                int xrow = int.Parse(xrow123);

                dataCmd.CommandText = query;

                //string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);


                //dataCmd.Parameters.AddWithValue("@zutime", DateTime.Now);
                dataCmd.Parameters.AddWithValue("@zid", _zid);
                dataCmd.Parameters.AddWithValue("@xrow", xrow);
                dataCmd.Parameters.AddWithValue("@xremarks", xremarks123);

                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                dataCmd.Dispose();
                conn1.Dispose();



                BindGrid1();

                Panel _note = (Panel)GridView4.Rows[row.RowIndex].FindControl("pnlnote");
                _note.Visible = false;
            }
            catch (Exception exp)
            {
                message3.InnerHtml = exp.Message;
                message3.Style.Value = zglobal.am_errormsg;
            }
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                message3.InnerHtml = "";
                btnUpload.Enabled = false;

                bool isValid = true;
                //string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xlink.HasFile == false)
                {
                    //rtnMessage = rtnMessage + "<li>Select a file</li>";
                    isValid = false;
                }

                //rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    //message3.InnerHtml = rtnMessage;
                    message3.InnerHtml = "Please select a file.";
                    message3.Style.Value = zglobal.warningmsg;
                    btnUpload.Enabled = true;

                    myModal2.Attributes.Add("style", "display:block;");

                    return;
                }

                int xrow;
                int xwsno;
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                xrow = zglobal.GetMaximumIdInt("xrow", "amworksheet", " zid=" + _zid, 1, 1);
                // xwsno = zglobal.GetMaximumIdInt("xwsno", "amworksheet", " zid=" + _zid , 1, 1);

                //string folderPath = HttpContext.Current.Server.MapPath("~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/");
                //if (!Directory.Exists(folderPath))
                //{
                //    Directory.CreateDirectory(folderPath);
                //}
                //string extension = Path.GetExtension(xlink.PostedFile.FileName);
                ////string fileName = Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                //string fileName = xrow.ToString().Substring(xrow.ToString().Length - 3) + "_" + xsubject.InnerHtml.ToString() + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                //string xfile = xrow.ToString().Substring(xrow.ToString().Length - 3) + "_" + xsubject.InnerHtml.ToString() + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + extension;
                //string imagePath = folderPath + fileName;
                //xlink.SaveAs(imagePath);
                //string _xlink = "~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/" + fileName;

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        DateTime ztime = DateTime.Now;
                        DateTime zutime = DateTime.Now;
                        DateTime xdate1 = DateTime.Now;

                        string xsession1 = "";
                        string xterm1 = "";
                        string xclass1 = "";
                        string xgroup1 = "";
                        string xsection1 = "";
                        string xsubject1 = "";
                        string xpaper1 = "";
                        string xext1 = "";
                        string xlink1 = "";
                        string xremarks1 = "";
                        string xteacher1 = "";
                        string xtype1 = "Upload Homework";
                        string xstatus1 = "New";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                        string query =
                                    "INSERT INTO amworksheet (ztime,zid,xrow,xsession,xterm,xclass,xsection,xsubject,xpaper,xext,xlink,xremarks,xteacher,xtype,xstatus,zemail,xdate,xfile,xfile1,xfileext,xwsno) " +
                                    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xsection,@xsubject,@xpaper,@xext,@xlink,@xremarks,@xteacher,@xtype,@xstatus,@zemail,@xdate,@xfile,@xfile1,@xfileext,@xwsno) ";


                        xsession1 = xsession.Text.Trim().ToString();
                        xterm1 = xterm.Text.Trim().ToString();
                        xclass1 = xclass.Text.Trim().ToString();
                        xsection1 = xsection.Text.Trim().ToString();
                        xsubject1 = hxsubject3.Value.ToString();
                        xpaper1 = hxpaper3.Value.ToString();
                        xext1 = hxext3.Value.ToString();
                        xdate1 = DateTime.Now;

                        string folderPath = HttpContext.Current.Server.MapPath("~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/");
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        xwsno = zglobal.GetMaximumIdInt("xwsno", "amworksheet", " zid=" + _zid + " and xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xclass='" + xclass1 + "' and xsection='" + xsection1 + "' and xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'", 1, 1);

                        string extension = Path.GetExtension(xlink.PostedFile.FileName);
                        //string fileName = Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                        string fileName = xwsno.ToString().Substring(xwsno.ToString().Length - 3) + "_" + hdxsubject3.Value.ToString() + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                        string xfile = xwsno.ToString().Substring(xwsno.ToString().Length - 3) + "_" + hdxsubject3.Value.ToString() + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + extension;
                        string imagePath = folderPath + fileName;
                        xlink.SaveAs(imagePath);
                        string _xlink = "~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/" + fileName;

                        xlink1 = _xlink;
                        //xremarks1 = xremarks.Text.Trim().ToString();
                        xremarks1 = "";
                        xteacher1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        //string xfile = Path.GetFileName(xlink.PostedFile.FileName);
                        string xfile1 = fileName;
                        string xfileext = extension;


                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xsession", xsession1);
                        cmd.Parameters.AddWithValue("@xterm", xterm1);
                        cmd.Parameters.AddWithValue("@xclass", xclass1);
                        cmd.Parameters.AddWithValue("@xsection", xsection1);
                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                        cmd.Parameters.AddWithValue("@xext", xext1);
                        cmd.Parameters.AddWithValue("@xlink", xlink1);
                        cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                        cmd.Parameters.AddWithValue("@xteacher", xteacher1);
                        cmd.Parameters.AddWithValue("@xtype", xtype1);
                        cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xdate", xdate1);
                        cmd.Parameters.AddWithValue("@xfile", xfile);
                        cmd.Parameters.AddWithValue("@xfile1", xfile1);
                        cmd.Parameters.AddWithValue("@xfileext", xfileext);
                        cmd.Parameters.AddWithValue("@xwsno", xwsno);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Complete();
                }

                message.InnerHtml = "Upload Successfull!";
                message.Style.Value = zglobal.successmsg;

                //btnUpload.Enabled = false;
                //xremarks.Text = "";

                BindGrid1();

                UpdatePanel2.Update();

                myModal2.Attributes.Add("style", "display:block;");

                btnUpload.Enabled = true;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
                btnUpload.Enabled = true;
            }
        }
    }
}