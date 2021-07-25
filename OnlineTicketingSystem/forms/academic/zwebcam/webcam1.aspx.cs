using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Services;

namespace OnlineTicketingSystem.forms.academic.zwebcam
{
    public partial class webcam1 : System.Web.UI.Page
    {
        public static int _zid;
        public static Int64 xrow;
        public static string xpath;
        public static string ctlid;
        public static string ctlid2;
        public static string page;

        [WebMethod(EnableSession = true)]
        public static string fnSaveImage1(string dataurl)
        {
            try
            {
                string str = "";
                int _zid = webcam1._zid;
                Int64 xrow = webcam1.xrow;
                string xpath = webcam1.xpath;
                string folderPath = HttpContext.Current.Server.MapPath(xpath + _zid.ToString() + "/");
                ////folderPath = folderPath + _zid.ToString() + "/";

                //return _zid.ToString() + " - " + xrow.ToString() + " - " + folderPath;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //Create a Folder in your Root directory on your solution.
                string fileName = _zid.ToString() + "_" + xrow.ToString() + "_" + DateTime.Now.Ticks.ToString() + ".jpg";
                string imagePath = folderPath + fileName;

                string base64StringData = dataurl; // Your base 64 string data
                string cleandata = base64StringData.Replace("data:image/jpeg;base64,", "");
                byte[] data = System.Convert.FromBase64String(cleandata);
                MemoryStream ms = new MemoryStream(data);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                str = "success|" + xpath + _zid.ToString() + "/" + fileName;

                return str;
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    _zid = Int32.Parse(Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1");
                    page = Request.QueryString["page"].ToString();
                    if (Request.QueryString["_row"].ToString() == "" || Request.QueryString["_row"].ToString() == String.Empty)
                    {
                        if (page == "student")
                        {
                            xrow = zglobal.GetMaximumIdInt("xrow", "amadmis", " zid=" + _zid, 1);
                        }
                        else
                        {
                            xrow = 0;
                        }

                        if (page == "studenton")
                        {
                            xrow = zglobal.GetMaximumIdInt("xrow", "amadmison", " zid=" + _zid, 1);
                        }
                        else
                        {
                            xrow = 0;
                        }
                    }
                    else
                    {
                        xrow = Int64.Parse(Request.QueryString["_row"]);
                    }
                    xpath = xpath = Request.QueryString["xpath"] != "" ? Request.QueryString["xpath"] : "-1";
                    ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                    ctlid2 = Request.QueryString["ctlid2"] != "" ? Request.QueryString["ctlid2"] : "-1";
                    ctlid_v.Value = ctlid;
                    ctlid2_v.Value = ctlid2;
                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}