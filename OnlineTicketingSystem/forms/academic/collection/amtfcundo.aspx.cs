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
    public partial class amtfcundo : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    

                }

                
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }





        protected void rdo_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                xrow.Text = "";
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }
        

       

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {

                message.InnerText = "";

                if (rdoDue.Checked == false && rdoCollection.Checked == false)
                {
                    message.InnerHtml = "Select transaction type.";
                    message.Style.Value = zglobal.am_warningmsg;
                    return;
                }

                if (xrow.Text.Trim().ToString() == String.Empty)
                {
                    ViewState["xrow"] = null;
                }
                else
                {
                    ViewState["xrow"] = xrow.Text.Trim().ToString();
                }

                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {
                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                
                                xstatus = "New";
                                string xundoby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xundodt = DateTime.Now;

                                string query = "";

                                string xtransac = "";
                                string xtable = "";
                                if (rdoDue.Checked)
                                {
                                    xtransac = zglobal.fnGetValue("xstatus", "amtfcdueh",
                                        "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]) +
                                        " AND xtype in ('Studentwise','Headwise')");
                                    xtable = "amtfcdueh";
                                }
                                else
                                {
                                    xtransac = zglobal.fnGetValue("xstatus", "amtfch",
                                        "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]) +
                                        " AND xtype in ('Admission','Tuition Fee','Readmission')");
                                    xtable = "amtfch";
                                }

                                if (xtransac == "")
                                {
                                    message.InnerHtml = "Wrong transaction code.";
                                    message.Style.Value = zglobal.am_warningmsg;
                                    return;
                                }



                                query =
                                    "UPDATE " + xtable + " SET xstatus=@xstatus,xundoby=@xundoby,xundodt=@xundodt " +
                                    "WHERE zid=@zid AND xrow=@xrow ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.Parameters.AddWithValue("@xundoby", xundoby);
                                cmd.Parameters.AddWithValue("@xundodt", xundodt);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.undosuccmsg;
                        message.Style.Value = zglobal.successmsg;
                    }
                }
                else
                {
                    message.InnerHtml = "No record found for undo.";
                    message.Style.Value = zglobal.warningmsg;
                }


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

       
        

       
    }
}