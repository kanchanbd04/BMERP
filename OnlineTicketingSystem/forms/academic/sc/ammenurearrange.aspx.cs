using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.sc
{
    public partial class ammenurearrange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    string xidold1 = xidold.Text.Trim().ToString();
                    string xidnew1 = xidnew.Text.ToString().Trim();
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    if (xidold1 == "" || xidnew1 == "")
                    {
                        message.InnerHtml = "Enter Old & New ID";
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        string query = "update ztmenu set xid=@xidnew where xid=@xidold";

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@xidnew", xidnew1);
                        cmd.Parameters.AddWithValue("@xidold", xidold1);
                        cmd.ExecuteNonQuery();

                        query = "update ztmenu set xparentid=@xidnew where xparentid=@xidold";

                        cmd.Parameters.Clear();
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@xidnew", xidnew1);
                        cmd.Parameters.AddWithValue("@xidold", xidold1);
                        cmd.ExecuteNonQuery();


                        DataSet dts5 = new DataSet();

                        dts5.Reset();
                        string str5 = "select * from ztpermis";

                        SqlDataAdapter da5 = new SqlDataAdapter(str5, conn);

                        

                        da5.Fill(dts5, "tempdt");
                        DataTable temp5 = new DataTable();
                        temp5 = dts5.Tables[0];

                        foreach (DataRow row in temp5.Rows)
                        {
                            //Response.Write(row["xid"] + " : ");

                            string[] permis = row["xpermis"].ToString().Split('|');

                            //permis = permis.Select(s => s.Replace("45", "4500")).ToArray();


                            string value = "";
                            for (int i = 0; i < permis.Length; i++)
                            {

                                if (permis[i] == xidold1)
                                {
                                    permis[i] = xidnew1;
                                }

                                value = value + "|" + permis[i];
                                //Response.Write(val + "  ");
                            }

                            //Response.Write(value);

                            //Response.Write("<br/>");

                            query = "update ztpermis set xpermis=@xpermis where zid=@zid and xid=@xid";

                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xid", row["xid"].ToString());
                            cmd.Parameters.AddWithValue("@xpermis", value);
                            cmd.ExecuteNonQuery();

                        }
                    }

                    tran.Complete();
                }

                message.InnerHtml = "Process Completed.";
                message.Style.Value = zglobal.am_successmsg;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}