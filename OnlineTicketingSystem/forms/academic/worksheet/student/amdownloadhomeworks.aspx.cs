using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.worksheet
{
    public partial class amdownloadhomeworks : System.Web.UI.Page
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
                    string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                    string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                    string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                    string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                    string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
                    string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
                    string xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";

                    if (xsession1 != "" && xterm1 != "" && xclass1 != "" && xsection1 != "" && xsubject1 != "")
                    {


                        xsession.InnerHtml = xsession1;
                        xterm.InnerHtml = xterm1;
                        xclass.InnerHtml = xclass1;
                        xsection.InnerHtml = xsection1;
                        if (xpaper1 != "")
                        {
                            xsubject.InnerHtml = xsubject1 + " - " + xpaper1;
                        }
                        else if (xext1 != "")
                        {
                            xsubject.InnerHtml = xsubject1 + " - " + xext1;
                        }
                        else
                        {
                            xsubject.InnerHtml = xsubject1;
                        }


                    }

                    
                }

                BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        private void BindGrid()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
           

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
            string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
            string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
            string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
            string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
            string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
            string xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";

            string str = "";

            str = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext,xdatesend, coalesce((select xname from hrmst where zid=@zid and xemp=(select xempcode from ztuser where xuser=amworksheet.zemail) and xtype='teacher'),'') as xname FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xstatus='Send' and xtype='Upload Homework' ORDER BY xdatesend desc";

            SqlCommand cmd = new SqlCommand(str, conn1);

            cmd.Parameters.AddWithValue("@zid", _zid);
            cmd.Parameters.AddWithValue("@xsession", xsession1);
            cmd.Parameters.AddWithValue("@xterm", xterm1);
            cmd.Parameters.AddWithValue("@xclass", xclass1);
            cmd.Parameters.AddWithValue("@xsection", xsection1);
            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
            cmd.Parameters.AddWithValue("@xext", xext1);
            cmd.CommandType = CommandType.Text;
            conn1.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            _storeddiv.Controls.Clear();

            if (rdr.HasRows==true)
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
                div1.Attributes.Add("class", "link_con");
                div1.Attributes.Add("title", "Send date : " + Convert.ToDateTime(rdr["xdatesend"]).ToString("dd/MM/yyyy") + "\nSend by : " + rdr["xname"].ToString());
                _storeddiv.Controls.Add(div1);

                //string xpaper123 = rdr["xpaper"].ToString() == "" ? "" : rdr["xpaper"].ToString();
                //string xext123 = rdr["xext"].ToString() == "" ? "" : rdr["xext"].ToString();
                //string xclass123 = HttpContext.Current.Session["xclass"].ToString();
                //string xsection123 = HttpContext.Current.Session["xsection"].ToString();

                //DataRow[] xnotification = ((DataTable)ViewState["amworksheet"]).Select("xsubject='" + rdr["xsubject"].ToString() + "' and xpaper='" + xpaper123 + "' and xext='" + xext123 + "'");

                string xlink_f = rdr["xlink"].ToString();
                string xlink_f1 = xlink_f.Substring(1, xlink_f.Length - 1);

                HtmlGenericControl a = new HtmlGenericControl("a");
                //a.Attributes.Add("href","#");
                a.Attributes.Add("id", "_link|" + rdr["xrow"].ToString());
                //a.Attributes.Add("onclick", "fnOnLinkClick");
                //a.Attributes.Add("onclick", "fnOpenDownload('" + rdr["xsubject"].ToString() + "','" + xpaper123 + "','" + xext123 + "','" + xclass123 + "','" + xsection123 + "');");
                //a.Attributes.Add("onclick", "window.open('/forms/academic/worksheet/amuploadteacher.aspx?zid="+_zid+"&xsession="+xsession.Text.ToString().Trim()
                //    +"&xterm="+xterm.Text.Trim().ToString()+"&xclass="+xclass.Text.Trim().ToString()+"&xsection="+xsection.Text.Trim().ToString()+"&xsubject="+rdr["xsubject"].ToString()+"&xpaper="+rdr["xpaper"].ToString()+"&xext="+rdr["xext"].ToString()+"', " +
                //    "'uploadteacher', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');openwin.focus(); return false;");
                a.Attributes.Add("href", xlink_f1);
                a.Attributes.Add("download", rdr["xfile1"].ToString());
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

                //if (xnotification.Length > 0)
                //{
                HtmlGenericControl div21 = new HtmlGenericControl("div"); //ec7063
                    div21.Attributes.Add("style", "position: absolute;top:8px; right: 16px;color:#fff;background-color: #ff0000;padding:3px;border-radius: 50%; -moz-border-radius: 50%;font-weight:bold;");
                    div2.Controls.Add(div21);
                    //div21.InnerHtml = xnotification.Length.ToString();
                    div21.InnerHtml = "New";

                //}

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

        protected void fnLinkClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                xsubject.InnerHtml = "Link";
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {


            //        int xrow = int.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

            //        string xlink_f = (e.Row.DataItem as DataRowView).Row["xlink"].ToString();
            //        string xlink_f1 = xlink_f.Substring(1, xlink_f.Length - 1);

            //        Label lblno = new Label();
            //        lblno.ID = "lblno";
            //        e.Row.Cells[0].Controls.Add(lblno);

            //        HtmlGenericControl a = new HtmlGenericControl("a");
            //        a.Attributes.Add("href",xlink_f1);
            //        a.Attributes.Add("download", (e.Row.DataItem as DataRowView).Row["xfile1"].ToString());
            //        a.InnerHtml = (e.Row.DataItem as DataRowView).Row["xfile"].ToString();
            //        e.Row.Cells[1].Controls.Add(a);

            //        CheckBox chkCheckBox = new CheckBox();
            //        chkCheckBox.ID = "xaction";
            //        e.Row.Cells[3].Controls.Add(chkCheckBox);

            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

       

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    bool isValid = true;
            //    string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
            //    if (xlink.HasFile==false)
            //    {
            //        rtnMessage = rtnMessage + "<li>Select a file</li>";
            //        isValid = false;
            //    }

            //    rtnMessage = rtnMessage + "</ol></div>";
            //    if (!isValid)
            //    {
            //        message.InnerHtml = rtnMessage;
            //        message.Style.Value = zglobal.warningmsg;
            //        return;
            //    }

            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    string folderPath = HttpContext.Current.Server.MapPath("~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/");
            //    if (!Directory.Exists(folderPath))
            //    {
            //        Directory.CreateDirectory(folderPath);
            //    }
            //    string extension = Path.GetExtension(xlink.PostedFile.FileName);
            //    string fileName = Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
            //    string imagePath = folderPath + fileName;
            //    xlink.SaveAs(imagePath);
            //    string _xlink = "~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/" + fileName;

            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            conn.Open();

            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;

            //            DateTime ztime = DateTime.Now;
            //            DateTime zutime = DateTime.Now;
            //            DateTime xdate1 = DateTime.Now;
            //            int xrow;
            //            string xsession1 = "";
            //            string xterm1 = "";
            //            string xclass1 = "";
            //            string xgroup1 = "";
            //            string xsection1 = "";
            //            string xsubject1 = "";
            //            string xpaper1 = "";
            //            string xext1 = "";
            //            string xlink1 = "";
            //            string xremarks1 = "";
            //            string xteacher1 = "";
            //            string xtype1 = "Upload Homework";
            //            string xstatus1 = "New";
            //            string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //            string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

            //            string query =
            //                        "INSERT INTO amworksheet (ztime,zid,xrow,xsession,xterm,xclass,xsection,xsubject,xpaper,xext,xlink,xremarks,xteacher,xtype,xstatus,zemail,xdate,xfile,xfile1,xfileext) " +
            //                        "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xsection,@xsubject,@xpaper,@xext,@xlink,@xremarks,@xteacher,@xtype,@xstatus,@zemail,@xdate,@xfile,@xfile1,@xfileext) ";
            //            xrow = zglobal.GetMaximumIdInt("xrow", "amworksheet", " zid=" + _zid, 1, 1);

            //            xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
            //            xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
            //            xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
            //            xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
            //            xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
            //            xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
            //            xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";
            //            xdate1 = DateTime.Now;
            //            xlink1 = _xlink;
            //            xremarks1 = xremarks.Text.Trim().ToString();
            //            xteacher1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //            string xfile = Path.GetFileName(xlink.PostedFile.FileName);
            //            string xfile1 = fileName;
            //            string xfileext = extension;

            //            cmd.CommandText = query;
            //            cmd.Parameters.AddWithValue("@ztime", ztime);
            //            cmd.Parameters.AddWithValue("@zid", _zid);
            //            cmd.Parameters.AddWithValue("@xrow", xrow);
            //            cmd.Parameters.AddWithValue("@xsession", xsession1);
            //            cmd.Parameters.AddWithValue("@xterm", xterm1);
            //            cmd.Parameters.AddWithValue("@xclass", xclass1);
            //            cmd.Parameters.AddWithValue("@xsection", xsection1);
            //            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
            //            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
            //            cmd.Parameters.AddWithValue("@xext", xext1);
            //            cmd.Parameters.AddWithValue("@xlink", xlink1);
            //            cmd.Parameters.AddWithValue("@xremarks", xremarks1);
            //            cmd.Parameters.AddWithValue("@xteacher", xteacher1);
            //            cmd.Parameters.AddWithValue("@xtype", xtype1);
            //            cmd.Parameters.AddWithValue("@xstatus", xstatus1);
            //            cmd.Parameters.AddWithValue("@zemail", zemail);
            //            cmd.Parameters.AddWithValue("@xdate", xdate1);
            //            cmd.Parameters.AddWithValue("@xfile", xfile);
            //            cmd.Parameters.AddWithValue("@xfile1", xfile1);
            //            cmd.Parameters.AddWithValue("@xfileext", xfileext);
            //            cmd.ExecuteNonQuery();
            //        }

            //        tran.Complete();
            //    }

            //    message.InnerHtml = "Upload Successfull!";
            //    message.Style.Value = zglobal.successmsg;

            //    btnUpload.Enabled = false;

            //    BindGrid();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                xremarks.Text = "";

                btnUpload.Enabled = true;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                
            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            conn.Open();

            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;
            //            string query = "";

            //            foreach (GridViewRow row in GridView1.Rows)
            //            {
            //                CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

            //                if (chkCheckBox.Checked == true)
            //                {
            //                    query = "UPDATE amworksheet SET xstatus='Send' WHERE zid=@zid and xrow=@xrow ";

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.Clear();
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(row.Cells[4].Text.ToString()));
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }
            //        }

            //        tran.Complete();
            //    }

            //    message.InnerHtml = "Send Successfull!";
            //    message.Style.Value = zglobal.successmsg;


            //    BindGrid();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            conn.Open();

            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;
            //            string query = "";

            //            foreach (GridViewRow row in GridView1.Rows)
            //            {
            //                CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

            //                if (chkCheckBox.Checked == true)
            //                {
            //                    query = "DELETE amworksheet WHERE zid=@zid and xrow=@xrow ";

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.Clear();
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(row.Cells[4].Text.ToString()));
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }
            //        }

            //        tran.Complete();

            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

            //            if (chkCheckBox.Checked == true)
            //            {
            //                File.Delete(Server.MapPath(row.Cells[5].Text.ToString()));
            //            }
            //        }
                   
            //    }

            //    message.InnerHtml = "Remove Successfull!";
            //    message.Style.Value = zglobal.successmsg;


            //    BindGrid();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnRemove1_OnClick(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            conn.Open();

            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;
            //            string query = "";

            //            foreach (GridViewRow row in GridView2.Rows)
            //            {
            //                CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

            //                if (chkCheckBox.Checked == true)
            //                {
            //                    query = "UPDATE amworksheet SET xstatus='New' WHERE zid=@zid and xrow=@xrow ";

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.Clear();
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(row.Cells[4].Text.ToString()));
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }
            //        }

            //        tran.Complete();
            //    }

            //    message.InnerHtml = "Return Successfull!";
            //    message.Style.Value = zglobal.successmsg;


            //    BindGrid();
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        [WebMethod(EnableSession = true)]
        public static string fnInsert(string zid, string xsession, string xterm, string xclass, string xsection, string xsubject, string xpaper, string xext, string xref)
        {

            try
            {
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        conn.Open();

                        string query1 = "SELECT * FROM amworksheet WHERE zid=@zid and ";
                        SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                        da.SelectCommand.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
                        da.SelectCommand.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
                        DataTable tempTable = new DataTable();
                        da.Fill(dts, "tempTable");
                        tempTable = dts.Tables["tempTable"];
                        
                    }
                }



                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                query = "INSERT INTO amworksheet (ztime,zid,xrow,xsession,xterm,xclass,xsection,xsubject,xpaper,xext,xref,xflag,zemail,xstatus,xtype) " +
                        "VALUES (@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xsection,@xsubject,@xpaper,@xext,@xref,@xflag,@zemail,@xstatus,@xtype)";

                int xrow = zglobal.GetMaximumIdInt("xrow", "amworksheet", " zid=" + _zid, 1, 1);

                dataCmd.CommandText = query;

                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //string xdate1 = xdate2;
                //string xcoach1 = xcoach2;

                dataCmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                dataCmd.Parameters.AddWithValue("@zid", _zid);
                dataCmd.Parameters.AddWithValue("@xrow", xrow);
                dataCmd.Parameters.AddWithValue("@xsession", xsession);
                dataCmd.Parameters.AddWithValue("@xterm", xterm);
                dataCmd.Parameters.AddWithValue("@xclass", xclass);
                dataCmd.Parameters.AddWithValue("@xsection", xsection);
                dataCmd.Parameters.AddWithValue("@xsubject", xsubject);
                dataCmd.Parameters.AddWithValue("@xpaper", xpaper);
                dataCmd.Parameters.AddWithValue("@xext", xext);
                dataCmd.Parameters.AddWithValue("@xref", xref);
                dataCmd.Parameters.AddWithValue("@xflag", "Download");
                dataCmd.Parameters.AddWithValue("@zemail", zemail1);
                dataCmd.Parameters.AddWithValue("@xstatus", "New");
                dataCmd.Parameters.AddWithValue("@xtype", "Student Feedback");

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

    }
}