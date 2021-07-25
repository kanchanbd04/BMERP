using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic
{
    public partial class amsynchro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Session", xsession_admit);
                    xsession_admit.Items.Add("All");
                    xsession_admit.Text = "All";

                    zglobal.fnGetComboDataCD("Session", xsession_report);
                    zglobal.fnGetComboDataCD("Session", xsession_clear);
                    //zglobal.fnGetComboDataCD("Term", xterm_report);
                    zglobal.fnGetComboDataCD("Term", xterm_clear);
                    //xsession_admit.Text = zglobal.fnDefaults("xsession", "Student");
                    xsession_report.Text = zglobal.fnDefaults("xsession", "Student");
                    xsession_clear.Text = zglobal.fnDefaults("xsession", "Student");
                   // xterm_report.Text = zglobal.fnDefaults("xterm", "Student");
                    xterm_clear.Text = zglobal.fnDefaults("xterm", "Student");
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

        protected void btnAdmitSync_OnClick(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                message.InnerHtml = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xsession_admit.Text == "" || xsession_admit.Text == string.Empty || xsession_admit.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                
                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    lbladmit.Text = rtnMessage;
                    lbladmit.Style.Value = zglobal.warningmsg;
                    return;
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                        string query = "DELETE FROM amadmis WHERE zid=@zid AND xsession=@xsession";

                    if (xsession_admit.Text == "All")
                    {
                        query = "DELETE FROM amadmis WHERE zid=@zid ";
                    }

                    cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xsession", xsession_admit.Text.ToString());
                        cmd.ExecuteNonQuery();

                }


                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "amadmis";

                    if (xsession_admit.Text == "All")
                    {
                        cmd.CommandText = "select * from amadmis WHERE zid=@zid ";
                    }
                    else
                    {
                        cmd.CommandText = "select * from amadmis WHERE zid=@zid AND xsession=@xsession ";
                    }
                    
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_admit.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    string query = "DELETE FROM ampromotiond WHERE zid=@zid AND xrow in (select xrow from ampromotionh where zid=@zid and xsessionpro=@xsession)";

                    if (xsession_admit.Text == "All")
                    {
                        query = "DELETE FROM ampromotiond WHERE zid=@zid ";
                    }

                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_admit.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    string query = "DELETE FROM ampromotionh WHERE zid=@zid AND xsessionpro=@xsession";
                    if (xsession_admit.Text == "All")
                    {
                        query = "DELETE FROM ampromotionh WHERE zid=@zid ";
                    }
                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_admit.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "ampromotionh";
                    if (xsession_admit.Text == "All")
                    {
                        cmd.CommandText = "select * from ampromotionh WHERE zid=@zid  ";
                    }
                    else
                    {
                        cmd.CommandText = "select * from ampromotionh WHERE zid=@zid AND xsessionpro=@xsession ";
                    }
                    
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_admit.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "ampromotiond";
                    if (xsession_admit.Text == "All")
                    {
                        cmd.CommandText = "select * from ampromotiond WHERE zid=@zid  ";
                    }
                    else
                    {
                        cmd.CommandText = "select * from ampromotiond WHERE zid=@zid AND  xrow in (select xrow from ampromotionh where zid=@zid and xsessionpro=@xsession) ";
                    }
                    
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_admit.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                lbladmit.Text = "Synchronization Completed.";


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnReportSync_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    //string query = "DELETE FROM amexamph_sumext_exam2_wt1 WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm";
                    string query = "DELETE FROM amexamph_sumext_exam2_wt1 WHERE zid=@zid AND xsession=@xsession ";
                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "amexamph_sumext_exam2_wt1";
                    //cmd.CommandText = "select * from amexamph_sumext_exam2_wt1 WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm ";
                    cmd.CommandText = "select * from amexamph_sumext_exam2_wt1 WHERE zid=@zid AND xsession=@xsession  ";
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    string query = "DELETE FROM amexamhhd1 WHERE zid=@zid AND xsession=@xsession ";
                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "amexamhhd1";
                    cmd.CommandText = "select * from amexamhhd1 WHERE zid=@zid AND xsession=@xsession  ";
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    string query = "DELETE FROM amexamna WHERE zid=@zid AND xsession=@xsession ";
                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "amexamna";
                    cmd.CommandText = "select * from amexamna WHERE zid=@zid AND xsession=@xsession  ";
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    string query = "DELETE FROM amattn WHERE zid=@zid AND xsession=@xsession ";
                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "amattn";
                    cmd.CommandText = "select * from amattn WHERE zid=@zid AND xsession=@xsession  ";
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                lblReport.Text = "Synchronization Completed.";

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnUserSync_OnClick(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //    using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
            //    {
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = conn;


            //        string query = "DELETE FROM ztuser";
            //        cmd.Parameters.Clear();

            //        cmd.CommandText = query;
            //        //cmd.Parameters.AddWithValue("@zid", _zid);
            //        //cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
            //        //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
            //        cmd.ExecuteNonQuery();

            //    }

            //    using (SqlConnection connSource = new SqlConnection(zglobal.constring))
            //    using (SqlCommand cmd = connSource.CreateCommand())
            //    using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
            //    {
            //        bcp.DestinationTableName = "ztuser";
            //        cmd.CommandText = "select * from ztuser WHERE xrole='Student' ";
            //        //cmd.Parameters.AddWithValue("@zid", _zid);
            //        //cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
            //        //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
            //        //cmd.CommandType = CommandType.StoredProcedure;
            //        connSource.Open();
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            bcp.WriteToServer(reader);
            //        }
            //    }

            //    lblUser.Text = "Synchronization Completed.";

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnDefaultSet_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    string query = "DELETE FROM amdefaults where zid=@zid";
                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    //cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "amdefaults";
                    cmd.CommandText = "select * from amdefaults WHERE zid=@zid ";
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    //cmd.Parameters.AddWithValue("@xsession", xsession_report.Text.ToString());
                    //cmd.Parameters.AddWithValue("@xterm", xterm_report.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                lblDefault.Text = "Synchronization Completed.";

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnClearance_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    string query = "DELETE FROM amaccclearance where zid=@zid and xsession=@xsession and xterm=@xterm";
                    cmd.Parameters.Clear();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_clear.Text.ToString());
                    cmd.Parameters.AddWithValue("@xterm", xterm_clear.Text.ToString());
                    cmd.ExecuteNonQuery();

                }

                using (SqlConnection connSource = new SqlConnection(zglobal.constring))
                using (SqlCommand cmd = connSource.CreateCommand())
                using (SqlBulkCopy bcp = new SqlBulkCopy(zglobal.constringstdp))
                {
                    bcp.DestinationTableName = "amaccclearance";
                    cmd.CommandText = "select * from amaccclearance WHERE zid=@zid and xsession=@xsession and xterm=@xterm ";
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xsession", xsession_clear.Text.ToString());
                    cmd.Parameters.AddWithValue("@xterm", xterm_clear.Text.ToString());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    connSource.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bcp.WriteToServer(reader);
                    }
                }

                lblClearance.Text = "Synchronization Completed.";

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}