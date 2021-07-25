using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineTicketingSystem.forms
{
    public partial class ztchngpass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                xoldpass.Value = "";
                xnewpass.Value = "";
                xconfpass.Value = "";
                Label1.Text = "User : " + Convert.ToString(HttpContext.Current.Session["curuser"]);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (xnewpass.Value == "")
                {
                    msg.InnerHtml = "Password must not empty";
                    return;
                }
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                string str = "select xpass from ztuser where xuser=@xuser";
                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                da1.SelectCommand.Parameters.AddWithValue("@xuser", xuser1);
                da1.Fill(dts, "dt1");
                DataTable dt1 = new DataTable();
                dt1 = dts.Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    if (xoldpass.Value == dt1.Rows[0][0].ToString())
                    {
                        if (xnewpass.Value == xconfpass.Value)
                        {
                            SqlConnection conn2;
                            conn2 = new SqlConnection(zglobal.constring);
                            SqlCommand dataCmd = new SqlCommand();
                            dataCmd.Connection = conn2;
                            string query;
                            query = "UPDATE ztuser SET " +
                                   "xpass=@xpass " +
                                   "WHERE xuser=@xuser";
                            dataCmd.CommandText = query;
                            string xpass1 = xnewpass.Value;
                            dataCmd.Parameters.AddWithValue("@xpass", xpass1);
                            dataCmd.Parameters.AddWithValue("@xuser", xuser1);
                            conn2.Close();
                            conn2.Open();
                            dataCmd.ExecuteNonQuery();
                            conn2.Close();

                            conn2.Dispose();
                            dataCmd.Dispose();
                            msg.InnerHtml = "Change password successfull.";
                        }
                        else
                        {
                            msg.InnerHtml = "Confirm password not matched. Please try again";
                        }
                    }
                    else
                    {
                        msg.InnerHtml = "Old password not matched. Please try again.";
                    }
                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }
}