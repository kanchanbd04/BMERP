using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CrystalDecisions.ReportAppServer;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class amtfcadmitcard : System.Web.UI.Page
    {

        public static void fnGetComboDataCDWithValue(string xtype, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add(new ListItem("", ""));
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                string query = "SELECT xcode,xdescdet FROM mscodesam WHERE zid=@zid AND xtype in ('Term','Mock No') AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(new ListItem(rdr["xdescdet"].ToString(), rdr["xcode"].ToString()));
                }
            }
            //combo.Text = "[Select]";
            combo.SelectedValue = "";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //xfdate.Text = zgetvalue.xfdate;
                    //string xdate = zglobal.fnDefaults("xstdageday", "Student");
                    //string xmonth = zglobal.fnDefaults("xstdagemonth", "Student");
                    //xfdate.Text = zgetvalue.fnFdate();

                    //xtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Session", xsession);
                    fnGetComboDataCDWithValue("'Term','Mock No'", xterm);
                    //xterm.Items.Add("Mock 1");
                    //xterm.Items.Add("Mock 2");
                    //xterm.Items.Add("Mock 3");
                    //xterm.Items.Add("Mock 4");
                    //xterm.Items.Add("Mock 5");
                    //xterm.Items.Add("Mock Final");

                    xsession.Text = zglobal.fnDefaults("xsessionacc", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                }

                //xstdname.Text = zglobal.fnGetValue("xname", "amadmis",
                //       "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //       xstdid.Text.ToString().Trim() + "'");


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }





        
        

       

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                message.InnerText = "";

                


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

       
        

       
    }
}