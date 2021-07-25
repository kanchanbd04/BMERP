using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using System.Web.Services;

namespace OnlineTicketingSystem.forms.academic.admission
{
    public partial class amadmissionform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session["business"] = "100012";

                if (!IsPostBack)
                {
                    _row.Value = "";
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Religion", xreligion);
                    zglobal.fnGetComboDataCD("Gender", xgender);

                    xtitle.InnerHtml = "Application for : " + zglobal.fnDefaults("xsessiononline", "Student") + " session";

                    xcellno.Text = "+880";
                    xcellno1.Text = "+880";


                }

                FileUpload1.Attributes["onchange"] = "UploadFile(this)";
                FileUpload2.Attributes["onchange"] = "UploadFile1(this)";

                if (ViewState["ctladded9"] == null)
                {
                    ViewState["ctladded9"] = 3;
                }

                fnCreateDynamicControlAtPageLoad9();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        protected void fnCreateDynamicControlAtPageLoad9()
        {
            if (ViewState["ctladded9"] != null)
            {
                int howMany = (int)ViewState["ctladded9"];
                for (int i = 1; i <= howMany; i++)
                {
                    fnCreateControl9(i);
                }
            }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ViewState["ctladded9"] == null)
                {
                    ViewState["ctladded9"] = 3;
                }

                ViewState["ctladded9"] = 1 + (int)ViewState["ctladded9"];



                fnCreateControl9((int)ViewState["ctladded9"]);
            }
            catch (Exception exp)
            {

                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnCreateControl9(int k)
        {
            try
            {

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                HtmlGenericControl div2 = new HtmlGenericControl("div");
                //HtmlGenericControl div3 = new HtmlGenericControl("div");
                HtmlGenericControl div4 = new HtmlGenericControl("div");
                HtmlGenericControl div5 = new HtmlGenericControl("div");

                div1.Attributes["class"] = "bm_ctl_container_dynamic_100_80_nl";
                div2.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div2.Attributes["style"] = "width: 100px";
                //div3.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                //div3.Attributes["style"] = "width: 290px";
                div4.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div4.Attributes["style"] = "width: 114px";
                div5.Attributes["class"] = "bm_clt_padding";


                placeholder9.Controls.Add(div1);
                placeholder9.Controls.Add(div2);
                //placeholder9.Controls.Add(div3);
                placeholder9.Controls.Add(div4);
                placeholder9.Controls.Add(div5);


                //LinkButton mylbl = new LinkButton();
                Label mylbl = new Label();
                TextBox xsibid = new TextBox();
                TextBox xsibname = new TextBox();
                DropDownList xsibclass = new DropDownList();

                zglobal.fnGetComboDataCD("Class", xsibclass);

                mylbl.CssClass = "label";
                xsibid.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                xsibid.Attributes["style"] = "width: 98px";
                xsibname.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                xsibname.Attributes["style"] = "width:288px";
                xsibclass.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown";
                xsibclass.Attributes["style"] = "width: 112px";


                if (k <= 9)
                {
                    mylbl.Text = "0" + k.ToString(); //+ ".";
                }
                else
                {
                    mylbl.Text = k.ToString();
                }
                // mtxt2.Text = "Presidency International School";


                mylbl.ID = "mylbl" + k.ToString();
                xsibid.ID = "xsibid" + k.ToString();
                xsibname.ID = "xsibname" + k.ToString();
                xsibclass.ID = "xsibclass" + k.ToString();

                mylbl.EnableViewState = true;
                xsibid.EnableViewState = true;
                xsibname.EnableViewState = true;
                xsibclass.EnableViewState = true;

                div1.Controls.Add(mylbl);
                div2.Controls.Add(xsibid);
                //div3.Controls.Add(xsibname);
                div4.Controls.Add(xsibclass);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        protected void fnImageCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoCapture.Checked)
                {
                    FileUpload1.Visible = false;
                    ImageButton3.Visible = false;
                    ErrorMsg.InnerText = "";
                }
                if (rdoUpload.Checked)
                {
                    FileUpload1.Visible = true;
                    ImageButton3.Visible = true;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        protected void fnImageCheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                if (rdoCapture1.Checked)
                {
                    FileUpload2.Visible = false;
                    ImageButton2.Visible = false;
                    ErrorMsg1.InnerText = "";
                }
                if (rdoUpload1.Checked)
                {
                    FileUpload2.Visible = true;
                    ImageButton2.Visible = true;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            message.InnerHtml = "";

            myModal.Attributes.Add("style", "display:none;");

            fnImageUpload(ErrorMsg, FileUpload1, "~/images/profile/studentonline/", ximagelink);
            //fnImageUpload(ErrorMsg, FileUpload1, "http://103.111.225.75:808/images/profile/", ximagelink);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            message.InnerHtml = "";
            fnImageUpload(ErrorMsg, FileUpload1, "~/images/profile/studentonline/", ximagelink);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            message.InnerHtml = "";

            myModal.Attributes.Add("style", "display:none;");

            fnImageUpload1(ErrorMsg1, FileUpload2, "~/images/profile/birthcertificate/student/", xcertificatelink);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            message.InnerHtml = "";
            fnImageUpload1(ErrorMsg1, FileUpload2, "~/images/profile/birthcertificate/student/", xcertificatelink);
        }

        private void fnImageUpload(HtmlGenericControl ErrMsg, FileUpload fileUpload, string path, System.Web.UI.WebControls.Image image)
        {
            try
            {
                ErrMsg.InnerHtml = "";
                bool isValidFile = false;

                if (fileUpload.HasFile)
                {
                    //string[] validFileTypes = { "bmp", "png", "jpg", "jpeg" };
                    string[] validFileTypes = { "jpg", "jpeg" };

                    string ext = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);



                    for (int i = 0; i < validFileTypes.Length; i++)
                    {

                        if (ext == "." + validFileTypes[i])
                        {

                            isValidFile = true;

                            break;

                        }

                    }

                    if (!isValidFile)
                    {


                        ErrMsg.InnerHtml = "Invalid File. Please upload a File with extension<br> " +

                                       string.Join(",", validFileTypes);
                        //ErrorMsg.Style.Value = zglobal.errormsg;
                        //return;
                    }


                    //if (fileUpload.PostedFile.ContentLength > 100000)
                    //{
                    //    ErrMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image size. (Max size 100KB)<br>";
                    //    //ErrorMsg.Style.Value = zglobal.errormsg;
                    //    isValidFile = false;
                    //    //return;
                    //}
                    ////else
                    ////{
                    ////    isValidFile = true;
                    ////}

                    //if (fileUpload.PostedFile.ContentLength > 1024000)
                    //{
                    //    ErrMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image size. (Max size 1MB)<br>";
                    //    //ErrorMsg.Style.Value = zglobal.errormsg;
                    //    isValidFile = false;
                    //    //return;
                    //}

                    //Bitmap bitmp = new Bitmap(fileUpload.PostedFile.InputStream);
                    //if (bitmp.Width != 300 & bitmp.Height != 300)
                    //{
                    //    ErrMsg.InnerHtml = ErrMsg.InnerHtml + "Invalid image dimension. (Dimension must be 300x300)";
                    //    //ErrorMsg.Style.Value = zglobal.errormsg;
                    //    isValidFile = false;
                    //    //return;
                    //}
                    ////else
                    ////{
                    ////    isValidFile = true;
                    ////}

                    if (!isValidFile)
                    {
                        return;
                    }

                    //if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                    //{
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    //string filename = fileUpload.FileName;
                    string folderPath = HttpContext.Current.Server.MapPath(path + _zid.ToString() + "/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                    Int64 xrow;
                    if (_row.Value.ToString() == "" || _row.Value.ToString() == String.Empty)
                    {
                        xrow = zglobal.GetMaximumIdInt("xrow", "amadmison", " zid=" + _zid, 1);
                    }
                    else
                    {
                        xrow = Int64.Parse(_row.Value.ToString());
                    }
                    string fileName = _zid.ToString() + "_" + xrow.ToString() + "_" + DateTime.Now.Ticks.ToString() + extension;
                    string imagePath = folderPath + fileName;
                    fileUpload.SaveAs(imagePath);
                    // File.Copy(imagePath, @"http://103.111.225.75:808/images/profile/");
                    image.ImageUrl = path + _zid.ToString() + "/" + fileName;
                    ErrMsg.InnerHtml = "";
                    //}
                    //else
                    //{
                    //    ErrorMsg.Visible = true;
                    //    ErrorMsg.InnerHtml = "Invalid File, Cannot Upload!";
                    //}
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.InnerHtml = "Please select a File";
                    //ErrorMsg.Style.Value = zglobal.errormsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnImageUpload1(HtmlGenericControl ErrMsg, FileUpload fileUpload, string path, System.Web.UI.WebControls.Image image)
        {
            try
            {
                ErrMsg.InnerHtml = "";
                bool isValidFile = false;

                if (fileUpload.HasFile)
                {
                    //string[] validFileTypes = { "bmp", "png", "jpg", "jpeg" };
                    string[] validFileTypes = { "jpg", "jpeg" };

                    string ext = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);



                    for (int i = 0; i < validFileTypes.Length; i++)
                    {

                        if (ext == "." + validFileTypes[i])
                        {

                            isValidFile = true;

                            break;

                        }

                    }

                    if (!isValidFile)
                    {


                        ErrMsg.InnerHtml = "Invalid File. Please upload a File with extension<br> " +

                                       string.Join(",", validFileTypes);
                        //ErrorMsg.Style.Value = zglobal.errormsg;
                        //return;
                    }


                    //if (fileUpload.PostedFile.ContentLength > 1024000)
                    //{
                    //    ErrMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image size. (Max size 1MB)<br>";
                    //    //ErrorMsg.Style.Value = zglobal.errormsg;
                    //    isValidFile = false;
                    //    //return;
                    //}
                    ////else
                    ////{
                    ////    isValidFile = true;
                    ////}

                    //Bitmap bitmp = new Bitmap(fileUpload.PostedFile.InputStream);
                    //if (bitmp.Width != 300 & bitmp.Height != 300)
                    //{
                    //    ErrMsg.InnerHtml = ErrMsg.InnerHtml + "Invalid image dimension. (Dimension must be 300x300)";
                    //    //ErrorMsg.Style.Value = zglobal.errormsg;
                    //    isValidFile = false;
                    //    //return;
                    //}
                    //else
                    //{
                    //    isValidFile = true;
                    //}

                    if (!isValidFile)
                    {
                        return;
                    }

                    //if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                    //{
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    //string filename = fileUpload.FileName;
                    string folderPath = HttpContext.Current.Server.MapPath(path + _zid.ToString() + "/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                    Int64 xrow;
                    if (_row.Value.ToString() == "" || _row.Value.ToString() == String.Empty)
                    {
                        xrow = zglobal.GetMaximumIdInt("xrow", "amadmison", " zid=" + _zid, 1);
                    }
                    else
                    {
                        xrow = Int64.Parse(_row.Value.ToString());
                    }
                    string fileName = _zid.ToString() + "_" + xrow.ToString() + "_" + DateTime.Now.Ticks.ToString() + extension;
                    string imagePath = folderPath + fileName;
                    fileUpload.SaveAs(imagePath);
                    image.ImageUrl = path + _zid.ToString() + "/" + fileName;
                    ErrMsg.InnerHtml = "";
                    //}
                    //else
                    //{
                    //    ErrorMsg.Visible = true;
                    //    ErrorMsg.InnerHtml = "Invalid File, Cannot Upload!";
                    //}
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.InnerHtml = "Please select a File";
                    //ErrorMsg.Style.Value = zglobal.errormsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                myModal.Attributes.Add("style", "display:none;");

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                ////Duplicate entry check
                //using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //{
                //    string checkuser = "SELECT COUNT(*) FROM amadmison WHERE zid=@zid AND xname=@xname AND xfname=@xfname AND xmname=@xmname AND xdob=@xdob AND (xcellno=@xcellno OR xcellno1=@xcellno1)";

                //    SqlParameter objParameter = null;
                //    // string xuser = Login1.UserName;
                //    SqlCommand cmd = new SqlCommand(checkuser, conn);
                //    objParameter = cmd.Parameters.Add("zid", SqlDbType.Int);
                //    objParameter = cmd.Parameters.Add("xname", SqlDbType.VarChar);
                //    objParameter = cmd.Parameters.Add("xfname", SqlDbType.VarChar);
                //    objParameter = cmd.Parameters.Add("xmname", SqlDbType.VarChar);
                //    objParameter = cmd.Parameters.Add("xdob", SqlDbType.Date);
                //    objParameter = cmd.Parameters.Add("xcellno", SqlDbType.VarChar);
                //    objParameter = cmd.Parameters.Add("xcellno1", SqlDbType.VarChar);

                //    cmd.Parameters["zid"].Value = _zid;
                //    cmd.Parameters["xname"].Value = xname.Text.ToString().Trim();
                //    cmd.Parameters["xfname"].Value = xfname.Text.ToString().Trim();
                //    cmd.Parameters["xmname"].Value = xmname.Text.ToString().Trim();
                //    cmd.Parameters["xdob"].Value = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //    cmd.Parameters["xcellno"].Value = xcellno.Text.ToString().Trim();
                //    cmd.Parameters["xcellno1"].Value = xcellno1.Text.ToString().Trim();
                //    conn.Open();
                //    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //    conn.Close();
                //    if (temp >= 1)
                //    {
                //        message.InnerHtml = "Student already exist in the database. Cann't insert duplicate record.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                //Check session approved

                //using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //{
                //    string checkuser = "SELECT TOP 1 coalesce(xstatus,'n') as xstatus FROM amadmis WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup AND xnumexam=@xnumexam";

                //    SqlParameter objParameter = null;
                //    // string xuser = Login1.UserName;
                //    SqlCommand cmd = new SqlCommand(checkuser, conn);
                //    objParameter = cmd.Parameters.Add("zid", SqlDbType.Int);
                //    objParameter = cmd.Parameters.Add("xsession", SqlDbType.VarChar);
                //    objParameter = cmd.Parameters.Add("xclass", SqlDbType.VarChar);
                //    objParameter = cmd.Parameters.Add("xgroup", SqlDbType.VarChar);
                //    objParameter = cmd.Parameters.Add("xnumexam", SqlDbType.VarChar);

                //    cmd.Parameters["zid"].Value = _zid;
                //    cmd.Parameters["xsession"].Value = xsession.Text.ToString().Trim();
                //    cmd.Parameters["xclass"].Value = xclass.Text.ToString().Trim();
                //    cmd.Parameters["xgroup"].Value = xgroup.Text.ToString().Trim();
                //    cmd.Parameters["xnumexam"].Value = xnumexam.Text.ToString().Trim();
                //    conn.Open();
                //    //int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //    SqlDataReader dr = cmd.ExecuteReader();
                //    while (dr.Read())
                //    {
                //        if (dr["xstatus"].ToString() != "n" && xnumexam.Text.ToString().Trim() != "Special" && xclass.Text.Trim().ToString() != "Playgroup")
                //        {
                //            message.InnerHtml = "Result already published. Can not add new record.";
                //            message.Style.Value = zglobal.warningmsg;
                //            return;
                //        }
                //    }
                //    conn.Close();
                //}

                if (_row.Value == "")
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        string checkuser = "SELECT COUNT(*) FROM amadmison WHERE zid=@zid AND xemail1=@xemail1";

                        SqlParameter objParameter = null;
                        // string xuser = Login1.UserName;
                        SqlCommand cmd = new SqlCommand(checkuser, conn);
                        objParameter = cmd.Parameters.Add("zid", SqlDbType.Int);
                        objParameter = cmd.Parameters.Add("xemail1", SqlDbType.VarChar);

                        cmd.Parameters["zid"].Value = _zid;
                        cmd.Parameters["xemail1"].Value = xemail1.Text.ToString().Trim();
                        conn.Open();
                        int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        conn.Close();
                        if (temp > 5)
                        {
                            message.InnerHtml =
                                "Maximum attempts has been reached. You are not allowed for new application.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }
                    }
                }

                string xkey = "";
                string xtype = "";
                message.InnerHtml = "";
                bool isValid = true;

                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";


                if (xname.Text == "" || xname.Text == string.Empty || xname.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Student Name</li>";
                    isValid = false;
                }
                if (xdob.Text == "" || xdob.Text == string.Empty || xdob.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Date of Birth</li>";
                    isValid = false;
                }
                if (xgender.Text == "" || xgender.Text == string.Empty || xgender.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Gender</li>";
                    isValid = false;
                }
                if (xreligion.Text == "" || xreligion.Text == string.Empty || xreligion.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Religion</li>";
                    isValid = false;
                }
                if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Applying For</li>";
                    isValid = false;
                }
                if (xmname.Text == "" || xmname.Text == string.Empty || xmname.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Mother's Name</li>";
                    isValid = false;
                }
                if (xcellno.Text == "" || xcellno.Text == string.Empty || xcellno.Text == "[Select]" || xcellno.Text == "+880")
                {
                    rtnMessage = rtnMessage + "<li>Cell No</li>";
                    isValid = false;
                }
                if (xfname.Text == "" || xfname.Text == string.Empty || xfname.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Father's Name</li>";
                    isValid = false;
                }
                if (xcellno1.Text == "" || xcellno1.Text == string.Empty || xcellno1.Text == "[Select]" || xcellno1.Text == "+880")
                {
                    rtnMessage = rtnMessage + "<li>Cell No</li>";
                    isValid = false;
                }
                if (xemail1.Text == "" || xemail1.Text == string.Empty || xemail1.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Email</li>";
                    isValid = false;
                }
                if (xpadd.Text == "" || xpadd.Text == string.Empty || xpadd.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Present Address</li>";
                    isValid = false;
                }
                if (xperadd.Text == "" || xperadd.Text == string.Empty || xperadd.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Permanent Address</li>";
                    isValid = false;
                }
                if (rdoCapture.Checked)
                {
                    if (_stdimageurl.Value.ToString() == "")
                    {
                        rtnMessage = rtnMessage + "<li>Photo</li>";
                        isValid = false;
                    }
                }
                else
                {
                    if (ximagelink.ImageUrl == "~/images/no-image.png")
                    {
                        rtnMessage = rtnMessage + "<li>Photo</li>";
                        isValid = false;
                    }
                }


                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Confirm", "fnSubmitConfrim()",false);

                //if (_submitconf.Value == "Yes")
                //{
                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        DateTime ztime = DateTime.Now;
                        DateTime zutime = DateTime.Now;
                        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        Int64 xrow = 0;

                        string xsession1 = "";
                        string xname1 = "";
                        string xclass1 = "";
                        string xexamroll1 = "";
                        DateTime xexamdate1 = Convert.ToDateTime("01/01/1900");
                        string xexamvenue1 = "";
                        string xpschool1 = "";
                        string xmname1 = "";
                        string xprofession11 = "";
                        string xfname1 = "";
                        string xprofession12 = "";
                        string xcontact1 = "";
                        string xphone1 = "";
                        string xpadd1 = "";
                        string xperadd1 = "";
                        string xemail11 = "";
                        string xnation1 = "";
                        DateTime xdob1 = DateTime.Now;
                        string xreligion1 = "";
                        string xgender1 = "";
                        string ximagelink1 = "";
                        string calage = zglobal.calculateage;
                        string xnumexam1 = "";
                        string xgroup1 = "";
                        string xcellno11 = "";
                        string xcellno12 = "";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xhour1 = "12";
                        string xminitue1 = "00";
                        string xperiod1 = "AM";
                        DateTime xdate11 = DateTime.Today;
                        string xremarks = "";
                        int zactive1 = 1;
                        string xlocation1 = "";
                        string xauthen1 = "";
                        string xbcimagelink1 = "";
                        string xstatus1 = "New";

                        string query = "";

                        if (_row.Value == "")
                        {
                            query =
                                "INSERT INTO amadmison (ztime,zid,xrow,xsession,xname,xclass,xpschool,xmname,xprofession,xfname,xprofession1,xpadd,xperadd,xemail1,xnation,xdob,xreligion,xgender,ximagelink,xcellno,xcellno1,zactive,xstatus,xauthen,xlocation,xbcimagelink) " +
                                "VALUES(@ztime,@zid,@xrow,@xsession,@xname,@xclass,@xpschool,@xmname,@xprofession,@xfname,@xprofession1,@xpadd,@xperadd,@xemail1,@xnation,@xdob,@xreligion,@xgender,@ximagelink,@xcellno,@xcellno1,@zactive,@xstatus,@xauthen,@xlocation,@xbcimagelink) ";
                        }
                        else
                        {
                            query =
                                "UPDATE amadmison SET zutime=@ztime,xname=@xname,xclass=@xclass,xpschool=@xpschool,xmname=@xmname,xprofession=@xprofession,xfname=@xfname,xprofession1=@xprofession1,xpadd=@xpadd,xperadd=@xperadd,xemail1=@xemail1,xnation=@xnation,xdob=@xdob,xreligion=@xreligion,xgender=@xgender,ximagelink=@ximagelink,xcellno=@xcellno,xcellno1=@xcellno1,xauthen=@xauthen,xlocation=@xlocation,xbcimagelink=@xbcimagelink " +
                                "WHERE zid=@zid AND xrow=@xrow ";
                        }
                        //xtype = "day_o";
                        if (_row.Value == "")
                        {
                            xrow = zglobal.GetMaximumIdInt("xrow", "amadmison", " zid=" + _zid, 1);
                            xkey = xrow.ToString();
                        }
                        else
                        {
                            xrow = int.Parse(_row.Value);

                        }

                        xsession1 = zglobal.fnDefaults("xsessiononline", "Student");
                        xname1 = xname.Text.Trim().ToString();
                        xclass1 = xclass.Text.Trim().ToString();
                        xpschool1 = xpschool.Text.Trim().ToString();
                        xlocation1 = xlocation.Text.Trim().ToString();
                        xmname1 = xmname.Text.Trim().ToString();
                        xprofession11 = xprofession.Text.Trim().ToString();
                        xfname1 = xfname.Text.Trim().ToString();
                        xprofession12 = xprofession1.Text.Trim().ToString();
                        xpadd1 = xpadd.Text.Trim().ToString();
                        xperadd1 = xperadd.Text.Trim().ToString();
                        xemail11 = xemail1.Text.Trim().ToString();
                        xnation1 = xnation.Text.Trim().ToString();
                        xdob1 = xdob.Text.Trim() != string.Empty
                            ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy",
                                CultureInfo.InvariantCulture)
                            : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xreligion1 = xreligion.Text.Trim().ToString();
                        xgender1 = xgender.Text.Trim().ToString();
                        xcellno11 = xcellno.Text.Trim().ToString();
                        xcellno12 = xcellno1.Text.Trim().ToString();

                        if (rdoCapture.Checked)
                        {
                            ximagelink1 = _stdimageurl.Value.ToString();
                            ximagelink.ImageUrl = ximagelink1;
                        }
                        else
                        {
                            ximagelink1 = ximagelink.ImageUrl.ToString();
                        }

                        if (rdoCapture1.Checked)
                        {
                            xbcimagelink1 = _cerimageurl.Value.ToString();
                            xcertificatelink.ImageUrl = xbcimagelink1;
                        }
                        else
                        {
                            xbcimagelink1 = xcertificatelink.ImageUrl.ToString();
                        }


                        zactive1 = 1;

                        xstatus1 = "New";


                        xauthen1 = RadioButtonList1.SelectedValue.ToString();


                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        //cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xsession", xsession1);
                        cmd.Parameters.AddWithValue("@xname", xname1);
                        cmd.Parameters.AddWithValue("@xclass", xclass1);
                        cmd.Parameters.AddWithValue("@xexamroll", xexamroll1);
                        cmd.Parameters.AddWithValue("@xexamdate", xexamdate1);
                        cmd.Parameters.AddWithValue("@xexamvenue", xexamvenue1);
                        cmd.Parameters.AddWithValue("@xpschool", xpschool1);
                        cmd.Parameters.AddWithValue("@xmname", xmname1);
                        cmd.Parameters.AddWithValue("@xprofession", xprofession11);
                        cmd.Parameters.AddWithValue("@xfname", xfname1);
                        cmd.Parameters.AddWithValue("@xprofession1", xprofession12);
                        cmd.Parameters.AddWithValue("@xcontact", xcontact1);
                        cmd.Parameters.AddWithValue("@xphone", xphone1);
                        cmd.Parameters.AddWithValue("@xpadd", xpadd1);
                        cmd.Parameters.AddWithValue("@xperadd", xperadd1);
                        cmd.Parameters.AddWithValue("@xemail1", xemail11);
                        cmd.Parameters.AddWithValue("@xnation", xnation1);
                        cmd.Parameters.AddWithValue("@xdob", xdob1);
                        cmd.Parameters.AddWithValue("@xreligion", xreligion1);
                        cmd.Parameters.AddWithValue("@xgender", xgender1);
                        cmd.Parameters.AddWithValue("@ximagelink", ximagelink1);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xemail", xemail);
                        cmd.Parameters.AddWithValue("@xnumexam", xnumexam1);
                        cmd.Parameters.AddWithValue("@xgroup", xgroup1);
                        cmd.Parameters.AddWithValue("@xcellno", xcellno11);
                        cmd.Parameters.AddWithValue("@xcellno1", xcellno12);
                        cmd.Parameters.AddWithValue("@xhour", xhour1);
                        cmd.Parameters.AddWithValue("@xminitue", xminitue1);
                        cmd.Parameters.AddWithValue("@xperiod", xperiod1);
                        cmd.Parameters.AddWithValue("@xdate1", xdate11);
                        cmd.Parameters.AddWithValue("@zactive", zactive1);
                        cmd.Parameters.AddWithValue("@xlocation", xlocation1);
                        cmd.Parameters.AddWithValue("@xstatus", xstatus1);
                        cmd.Parameters.AddWithValue("@xauthen", xauthen1);
                        cmd.Parameters.AddWithValue("@xbcimagelink", xbcimagelink1);
                        //cmd.Parameters.AddWithValue("@xremarks", xremarks);
                        cmd.ExecuteNonQuery();



                        if (ViewState["ctladded9"] != null)
                        {
                            query = "DELETE FROM amadmisonsib WHERE zid=@zid and xrow=@xrow";
                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xrow", xrow);
                            cmd.ExecuteNonQuery();

                            int xline = 1;
                            for (int i = 1; i <= (int)ViewState["ctladded9"]; i++)
                            {
                                cmd.Parameters.Clear();
                                //int xline = zglobal.GetMaximumIdInt("xline", "amadmissib",
                                //    " zid=" + _zid + " and xrow='" + xrow + "'", "line");
                                string xsibid =
                                    ((TextBox)placeholder9.FindControl("xsibid" + i)).Text.ToString().Trim();
                                //string xsibname = ((TextBox)placeholder9.FindControl("xsibname" + i)).Text.ToString().Trim();
                                string xsibname = "";
                                string xsibclass =
                                    ((DropDownList)placeholder9.FindControl("xsibclass" + i)).Text.ToString()
                                        .Trim();
                                query = "INSERT INTO amadmisonsib (zid,xrow,xline,xstdid,xclass,xname) " +
                                        "VALUES(@zid,@xrow,@xline,@xstdid,@xclass,@xname) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.Parameters.AddWithValue("@xstdid", xsibid);
                                cmd.Parameters.AddWithValue("@xname", xsibname);
                                cmd.Parameters.AddWithValue("@xclass", xsibclass);
                                if (xsibid != "" && xsibid != string.Empty)
                                {
                                    cmd.ExecuteNonQuery();
                                    xline = xline + 1;
                                }

                            }
                        }



                        //Insert into zreclog
                        //zglobal.fnRecordLog(xrow.ToString(), "Save", "eventinfo", xtype, "", 0, xdate);

                        SendMail(xrow.ToString(), xsession1);

                    }

                    //fnFillDataGrid();
                    //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();


                }

                //fnFillDataGrid(null, null);
                //btnEdit.Visible = true;
                //btnSave.Visible = false;
                message.InnerHtml =
                    "Successfully submitted. A confirmation number sent to your given email address. Please check your email inbox.";
                message.Style.Value = zglobal.successmsg;
                _row.Value = xkey;
                //_row_global.Value = xkey;
                //type.Value = xtype;
                btnSubmit.Enabled = false;

                try
                {
                    //string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    //if (string.IsNullOrEmpty(ipAddress))
                    //{
                    //    ipAddress = Request.ServerVariables["REMOTE_ADDR"];

                    //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    //    {
                    //        conn.Open();
                    //        SqlCommand cmd = new SqlCommand();
                    //        cmd.Connection = conn;
                    //        int _xrow1 = Convert.ToInt32(_row.Value.ToString());

                    //        string query1 = "UPDATE amadmison SET xipaddress=@xipaddress WHERE zid=@zid AND xrow=@xrow ";

                    //        cmd.Parameters.Clear();
                    //        cmd.CommandText = query1;
                    //        cmd.Parameters.AddWithValue("@zid", _zid);
                    //        cmd.Parameters.AddWithValue("@xrow", _xrow1);
                    //        cmd.Parameters.AddWithValue("@xipaddress", ipAddress);
                    //        cmd.ExecuteNonQuery();
                    //    }
                    //}

                    string IPAddress = IPHelper.GetIPAddress(Request.ServerVariables["HTTP_VIA"],
                                                Request.ServerVariables["HTTP_X_FORWARDED_FOR"],
                                                Request.ServerVariables["REMOTE_ADDR"]);

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        int _xrow1 = Convert.ToInt32(_row.Value.ToString());

                        string query1 = "UPDATE amadmison SET xipaddress=@xipaddress WHERE zid=@zid AND xrow=@xrow ";

                        cmd.Parameters.Clear();
                        cmd.CommandText = query1;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", _xrow1);
                        cmd.Parameters.AddWithValue("@xipaddress", IPAddress);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception exp)
                {

                }
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }



        private void SendMail(string xrowval, string xsession1)
        {
            try
            {
                string xrowval1 = xrowval.Substring(xrowval.Length - 4);
                string filename = Server.MapPath("~/event.html");
                string mailbody = System.IO.File.ReadAllText(filename);

                xsession1 = xsession1.Replace("/", "-");
                mailbody = mailbody.Replace("##NAME##", xname.Text.ToString().Trim());
                mailbody = mailbody.Replace("##REFNO##", xrowval1);
                mailbody = mailbody.Replace("##SESSION##", xsession1);
                mailbody = mailbody.Replace("##CLASS##", xclass.Text.ToString().Trim());

                //StreamReader reader = new StreamReader(Server.MapPath("~/event.html"));
                //string body = reader.ReadToEnd().Replace("##NAME##", xname.Text.ToString().Trim()).Replace("##REFNO##", xrowval);

                //AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

                //string imageSource = (Server.MapPath("~/images/school_logo.png"));
                //LinkedResource PictureRes = new LinkedResource(imageSource, MediaTypeNames.Image.Jpeg);
                //PictureRes.ContentId = "logo_sml.jpg";
                //altView.LinkedResources.Add(PictureRes);


                string to = xemail1.Text.ToString().Trim();
                //string from = "Presidency International School <no.reply.pisbd@gmail.com>";
                string from = "Presidency International School <noreply@presidency.ac.bd>";
                //string from = "admission@presidency.ac.bd";
                MailMessage message1 = new MailMessage(from, to);
                message1.Subject = "Confirmation of Application Submission";
                message1.Body = mailbody;
                //message1.AlternateViews.Add(altView);
                message1.BodyEncoding = Encoding.UTF8;
                message1.IsBodyHtml = true;

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/reports/amadmissioncopy.rpt"));
                crystalReport.SetParameterValue("xname", xname.Text.ToString().Trim());
                crystalReport.SetParameterValue("xref", xrowval1);
                crystalReport.SetParameterValue("xsession", xsession1);
                crystalReport.SetParameterValue("xclass", xclass.Text.ToString().Trim());
                message1.Attachments.Add(new Attachment(crystalReport.ExportToStream(ExportFormatType.PortableDocFormat), "Confirmation.pdf"));

                //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //SmtpClient client = new SmtpClient("74.125.24.108", 587);
                //SmtpClient client = new SmtpClient("smtp.presidency.ac.bd", 587);
                //SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                SmtpClient client = new SmtpClient(zglobal.global_smtp, zglobal.global_smtp_port_587);
                //System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("no.reply.pisbd@gmail.com", "pisbdctg");
                //System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("admission@presidency.ac.bd", "Admission$$20&&21");
                //System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("admission@presidency.ac.bd", "Admission@pisctg123");
                //System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("noreply@presidency.ac.bd", "uH^WHBb6");
                System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential(zglobal.global_smtp_email, zglobal.global_smtp_email_password);
                //NetworkCredential basicCredential = new NetworkCredential("noreply@presidency.ac.bd", "Chittagong@99");
                client.EnableSsl = true;
                //client.EnableSsl = false;
                //client.UseDefaultCredentials = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;

                crystalReport.Close();
                crystalReport.Dispose();


                client.Send(message1);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void Button3_OnServerClick(object sender, EventArgs e)
        {
            try
            {
                myModal.Attributes.Add("style", "display:block;");


            }
            catch (Exception exp)
            {
                //message.InnerHtml = exp.Message;
                //message.Style.Value = zglobal.errormsg;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string fnSendEmail(string xname1, string xemail1, string xmobile1, string xmessage1, string xsubject1)
        {

            try
            {
                string mailbody = " Email From " + xname1 + " <br/>Email : " + xemail1 + " <br/>Mobile : " + xmobile1 + " <br/>Subject : " + xsubject1 + " <br/>Message : " + xmessage1;

                //StreamReader reader = new StreamReader(Server.MapPath("~/event.html"));
                //string body = reader.ReadToEnd().Replace("##NAME##", xname.Text.ToString().Trim()).Replace("##REFNO##", xrowval);

                //AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

                //string imageSource = (Server.MapPath("~/images/school_logo.png"));
                //LinkedResource PictureRes = new LinkedResource(imageSource, MediaTypeNames.Image.Jpeg);
                //PictureRes.ContentId = "logo_sml.jpg";
                //altView.LinkedResources.Add(PictureRes);


                string to = "dreamcodebd@gmail.com";
                string from = xname1 + " <no.reply.pisbd@gmail.com>";
                //string from = "admission@presidency.ac.bd";
                MailMessage message1 = new MailMessage(from, to);
                message1.Subject = xsubject1;
                message1.Body = mailbody;
                //message1.AlternateViews.Add(altView);
                message1.BodyEncoding = Encoding.UTF8;
                message1.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //SmtpClient client = new SmtpClient("74.125.24.108", 587);
                //SmtpClient client = new SmtpClient("smtp.presidency.ac.bd", 587);
                System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("no.reply.pisbd@gmail.com", "pisbdctg");
                //System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("admission@presidency.ac.bd", "Admission$$20&&21");
                client.EnableSsl = true;
                client.UseDefaultCredentials = true;
                client.Credentials = basicCredential;


                client.Send(message1);

                return "success";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }


        }
    }


    public class IPHelper
    {
        /// <summary>
        /// Gets the user's IP Address
        /// </summary>
        /// <param name="httpVia">HTTP_VIA Server variable</param>
        /// <param name="httpXForwardedFor">HTTP_X_FORWARDED Server variable</param>
        /// <param name="RemoteAddr">REMOTE_ADDR Server variable</param>
        /// <returns>user's IP Address</returns>
        public static string GetIPAddress(string HttpVia, string HttpXForwardedFor, string RemoteAddr)
        {
            // Use a default address if all else fails.
            string result = "127.0.0.1";

            // Web user - if using proxy
            string tempIP = string.Empty;
            if (HttpVia != null)
                tempIP = HttpXForwardedFor;
            else // Web user - not using proxy or can't get the Client IP
                tempIP = RemoteAddr;

            // If we can't get a V4 IP from the above, try host address list for internal users.
            if (!IsIPV4(tempIP) || tempIP == "127.0.0.1 ")
            {
                try
                {
                    string hostName = System.Net.Dns.GetHostName();
                    foreach (System.Net.IPAddress ip in System.Net.Dns.GetHostAddresses(hostName))
                    {
                        if (IsIPV4(ip))
                        {
                            result = ip.ToString();
                            break;
                        }
                    }
                }
                catch { }
            }
            else
            {
                result = tempIP;
            }

            return result;
        }

        /// <summary>
        /// Determines weather an IP Address is V4
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>Is IPV4 True or False</returns>
        private static bool IsIPV4(string input)
        {
            bool result = false;
            System.Net.IPAddress address = null;

            if (System.Net.IPAddress.TryParse(input, out address))
                result = IsIPV4(address);

            return result;
        }

        /// <summary>
        /// Determines weather an IP Address is V4
        /// </summary>
        /// <param name="address">input IP address</param>
        /// <returns>Is IPV4 True or False</returns>
        private static bool IsIPV4(System.Net.IPAddress address)
        {
            bool result = false;

            switch (address.AddressFamily)
            {
                case System.Net.Sockets.AddressFamily.InterNetwork:   // we have IPv4
                    result = true;
                    break;
                case System.Net.Sockets.AddressFamily.InterNetworkV6: // we have IPv6
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}