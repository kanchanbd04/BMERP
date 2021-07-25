using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.worksheet
{
    public partial class amuploadteacher : System.Web.UI.Page
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
            DataSet dts = new DataSet();

            dts.Reset();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
            string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
            string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
            string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
            string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
            string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
            string xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";

            string str = "";

            str = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext AND zemail=@zemail and xstatus='New' and xtype='Upload Homework' ORDER BY xdate desc";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            da.SelectCommand.Parameters.AddWithValue("@xext", xext1);
            da.SelectCommand.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {
                GridView1.Columns.Clear();

                TemplateField tfield119 = new TemplateField();
                tfield119.HeaderText = "No.";
                tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield119.ItemStyle.Width = 35;
                GridView1.Columns.Add(tfield119);

                TemplateField tfield1190 = new TemplateField();
                tfield1190.HeaderText = "File Name";
                tfield1190.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield1190.ItemStyle.Width = 250;
                GridView1.Columns.Add(tfield1190);

                bfield = new BoundField();
                bfield.HeaderText = "Date";
                bfield.DataField = "xdate1";
                bfield.ItemStyle.Width = 50;
                bfield.DataFormatString = "{0:dd/MM/yyyy}";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(bfield);

                TemplateField tfield11900 = new TemplateField();
                tfield11900.HeaderText = "Action";
                tfield11900.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield11900.ItemStyle.Width = 250;
                GridView1.Columns.Add(tfield11900);

                BoundField bfield1 = new BoundField();
                bfield1.DataField = "xrow";
                GridView1.Columns.Add(bfield1);

                BoundField bfield11 = new BoundField();
                bfield11.DataField = "xlink";
                GridView1.Columns.Add(bfield11);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();


                _soterd.InnerHtml = "";

                btnRemove.Visible = true;
                btnSend.Visible = true;

                int i = 1;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Visible == true)
                    {
                        Label lbl = (Label)row.FindControl("lblno");
                        lbl.Text = i.ToString();
                        i++;
                    }
                }

                bfield1.Visible = false;
                bfield11.Visible = false;

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();


                _soterd.InnerHtml = "No file available.";

                btnRemove.Visible = false;
                btnSend.Visible = false;
            }


            SqlConnection conn11;
            conn11 = new SqlConnection(zglobal.constring);
            DataSet dts1 = new DataSet();

            dts1.Reset();

            int _zid1 = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string xsession11 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
            string xterm11 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
            string xclass11 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
            string xsection11 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
            string xsubject11 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
            string xpaper11 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
            string xext11 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";

            string str1 = "";

            str1 = "SELECT   xrow, xlink,xfile,xfile1,xdate,CONVERT(date, xdate) as xdate1,xfileext FROM amworksheet WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext AND zemail=@zemail and xstatus='Send' and xtype='Upload Homework' ORDER BY xdate desc";

            SqlDataAdapter da1 = new SqlDataAdapter(str1, conn11);
            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid1);
            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession11);
            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm11);
            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass11);
            da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection11);
            da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject11);
            da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper11);
            da1.SelectCommand.Parameters.AddWithValue("@xext", xext11);
            da1.SelectCommand.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
            da1.Fill(dts1, "tempztcode");
            DataTable dtmarks1 = new DataTable();
            dtmarks1 = dts1.Tables[0];

            if (dtmarks1.Rows.Count > 0)
            {
                GridView2.Columns.Clear();

                TemplateField tfield119 = new TemplateField();
                tfield119.HeaderText = "No.";
                tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield119.ItemStyle.Width = 35;
                GridView2.Columns.Add(tfield119);

                TemplateField tfield1190 = new TemplateField();
                tfield1190.HeaderText = "File Name";
                tfield1190.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield1190.ItemStyle.Width = 250;
                GridView2.Columns.Add(tfield1190);

                bfield = new BoundField();
                bfield.HeaderText = "Date";
                bfield.DataField = "xdate1";
                bfield.ItemStyle.Width = 50;
                bfield.DataFormatString = "{0:dd/MM/yyyy}";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView2.Columns.Add(bfield);

                TemplateField tfield11900 = new TemplateField();
                tfield11900.HeaderText = "Action";
                tfield11900.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield11900.ItemStyle.Width = 250;
                GridView2.Columns.Add(tfield11900);

                BoundField bfield1 = new BoundField();
                bfield1.DataField = "xrow";
                GridView2.Columns.Add(bfield1);

                GridView2.DataSource = dtmarks1;
                GridView2.DataBind();


                _send.InnerHtml = "";

                btnRemove1.Visible = true;

                int i = 1;
                foreach (GridViewRow row in GridView2.Rows)
                {
                    if (row.Visible == true)
                    {
                        Label lbl = (Label)row.FindControl("lblno");
                        lbl.Text = i.ToString();
                        i++;
                    }
                }

                bfield1.Visible = false;

            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();


                _send.InnerHtml = "No file available.";

                btnRemove1.Visible = false;
            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int xrow = int.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

                    string xlink_f = (e.Row.DataItem as DataRowView).Row["xlink"].ToString();
                    string xlink_f1 = xlink_f.Substring(1, xlink_f.Length - 1);

                    Label lblno = new Label();
                    lblno.ID = "lblno";
                    e.Row.Cells[0].Controls.Add(lblno);

                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", xlink_f1);
                    //a.Attributes.Add("download", (e.Row.DataItem as DataRowView).Row["xfile1"].ToString());
                    a.Attributes.Add("download", (e.Row.DataItem as DataRowView).Row["xfile"].ToString());
                    a.InnerHtml = (e.Row.DataItem as DataRowView).Row["xfile"].ToString();
                    e.Row.Cells[1].Controls.Add(a);

                    CheckBox chkCheckBox = new CheckBox();
                    chkCheckBox.ID = "xaction";
                    e.Row.Cells[3].Controls.Add(chkCheckBox);

                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int xrow = int.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

                    string xlink_f = (e.Row.DataItem as DataRowView).Row["xlink"].ToString();
                    string xlink_f1 = xlink_f.Substring(1, xlink_f.Length - 1);

                    Label lblno = new Label();
                    lblno.ID = "lblno";
                    e.Row.Cells[0].Controls.Add(lblno);

                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", xlink_f1);
                    //a.Attributes.Add("download", (e.Row.DataItem as DataRowView).Row["xfile1"].ToString());
                    a.Attributes.Add("download", (e.Row.DataItem as DataRowView).Row["xfile"].ToString());
                    a.InnerHtml = (e.Row.DataItem as DataRowView).Row["xfile"].ToString();
                    e.Row.Cells[1].Controls.Add(a);

                    CheckBox chkCheckBox = new CheckBox();
                    chkCheckBox.ID = "xaction";
                    e.Row.Cells[3].Controls.Add(chkCheckBox);

                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xlink.HasFile == false)
                {
                    rtnMessage = rtnMessage + "<li>Select a file</li>";
                    isValid = false;
                }

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                int xrow;
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                xrow = zglobal.GetMaximumIdInt("xrow", "amworksheet", " zid=" + _zid, 1, 1);

                string folderPath = HttpContext.Current.Server.MapPath("~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string extension = Path.GetExtension(xlink.PostedFile.FileName);
                //string fileName = Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                string fileName = xrow.ToString().Substring(xrow.ToString().Length - 3) + "_" + xsubject.InnerHtml.ToString() + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + extension;
                string xfile = xrow.ToString().Substring(xrow.ToString().Length - 3) + "_" + xsubject.InnerHtml.ToString() + "_" + Path.GetFileNameWithoutExtension(xlink.PostedFile.FileName) + extension;
                string imagePath = folderPath + fileName;
                xlink.SaveAs(imagePath);
                string _xlink = "~/documents/teacher/" + _zid.ToString() + "/" + Convert.ToString(HttpContext.Current.Session["curuser"]) + "/" + fileName;

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
                                    "INSERT INTO amworksheet (ztime,zid,xrow,xsession,xterm,xclass,xsection,xsubject,xpaper,xext,xlink,xremarks,xteacher,xtype,xstatus,zemail,xdate,xfile,xfile1,xfileext) " +
                                    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xsection,@xsubject,@xpaper,@xext,@xlink,@xremarks,@xteacher,@xtype,@xstatus,@zemail,@xdate,@xfile,@xfile1,@xfileext) ";


                        xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                        xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                        xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                        xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                        xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
                        xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
                        xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";
                        xdate1 = DateTime.Now;
                        xlink1 = _xlink;
                        xremarks1 = xremarks.Text.Trim().ToString();
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
                        cmd.ExecuteNonQuery();
                    }

                    tran.Complete();
                }

                message.InnerHtml = "Upload Successfull!";
                message.Style.Value = zglobal.successmsg;

                btnUpload.Enabled = false;

                BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
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
            try
            {
                message.InnerHtml = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";

                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

                            if (chkCheckBox.Checked == true)
                            {
                                query = "UPDATE amworksheet SET xstatus='Send',xdatesend=@xdatesend WHERE zid=@zid and xrow=@xrow ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(row.Cells[4].Text.ToString()));
                                cmd.Parameters.AddWithValue("@xdatesend", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tran.Complete();
                }

                message.InnerHtml = "Send Successfull!";
                message.Style.Value = zglobal.successmsg;


                BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";

                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

                            if (chkCheckBox.Checked == true)
                            {
                                query = "DELETE amworksheet WHERE zid=@zid and xrow=@xrow ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(row.Cells[4].Text.ToString()));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tran.Complete();

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

                        if (chkCheckBox.Checked == true)
                        {
                            File.Delete(Server.MapPath(row.Cells[5].Text.ToString()));
                        }
                    }

                }

                message.InnerHtml = "Remove Successfull!";
                message.Style.Value = zglobal.successmsg;


                BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnRemove1_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";

                        foreach (GridViewRow row in GridView2.Rows)
                        {
                            CheckBox chkCheckBox = row.FindControl("xaction") as CheckBox;

                            if (chkCheckBox.Checked == true)
                            {
                                query = "UPDATE amworksheet SET xstatus='New' WHERE zid=@zid and xrow=@xrow ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(row.Cells[4].Text.ToString()));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tran.Complete();
                }

                message.InnerHtml = "Return Successfull!";
                message.Style.Value = zglobal.successmsg;


                BindGrid();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}