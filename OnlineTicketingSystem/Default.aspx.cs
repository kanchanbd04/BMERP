using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Web.UI.HtmlControls;


namespace OnlineTicketingSystem
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(HttpContext.Current.Session["xrole"])!="SRO" )
                //{
                //    if (Convert.ToString(HttpContext.Current.Session["curuser"]) != "bm")
                //    {
                //        admissionOnline.Visible = false;
                //        candidateInfo.Visible = false;
                //    }
                //}

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();
                //string str = "SELECT * FROM ztmenu WHERE coalesce(xshowindashboard,'No')='Yes' and coalesce(xgroup,'')='Group1' order by xsequence";
                string str = "SELECT row_number() over(order by convert(int,xid) ) as sl,*,coalesce(xshowindashboard,'No') as xshowindashboard1, coalesce(xgroup,'') as xgroup1  FROM ztmenu order by convert(int,xid)";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                string xid = Convert.ToString(HttpContext.Current.Session["curuser"]);
                string zid = Convert.ToString(HttpContext.Current.Session["business"]);
                da.SelectCommand.Parameters.AddWithValue("@xid", xid);
                da.SelectCommand.Parameters.AddWithValue("@zid", zid);

                da.Fill(dts, "tempdt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable temp = new DataTable();
                temp = dts.Tables[0];

                if (temp.Rows.Count > 0)
                {
                    DataRow[] result = temp.Select("xshowindashboard1='Yes' and xgroup1='Group1'","xsequence");

                    if (result.Length > 0)
                    {
                        group1.Controls.Clear();

                        if (Convert.ToString(HttpContext.Current.Session["curuser"]) == "bm")
                        {
                            foreach (DataRow row in result)
                            {
                                //string id = "1";
                                //var xparentid1 = row["xparentid"];

                                //do
                                //{
                                //    DataRow[] row1 = temp.Select("xid='" + xparentid1.ToString() + "'");
                                //    id = row1[0]["sl"].ToString();

                                //    xparentid1 = row1[0]["xparentid"];
                                //} while (!string.IsNullOrEmpty(xparentid1.ToString()));

                                //HttpContext.Current.Session["subnav"] = "myDropdown" + id;
                                //HttpContext.Current.Session["link"] = "LinkButton" + id;
                                //HttpContext.Current.Session["xid"] = row["xid"].ToString();

                                HtmlGenericControl div = new HtmlGenericControl("div");
                                div.Attributes["class"] = "link_con";
                                group1.Controls.Add(div);

                                HtmlGenericControl a = new HtmlGenericControl("a");
                                //a.Attributes["href"] = row["xurl"].ToString() + "?subnav=" + HttpContext.Current.Session["subnav"].ToString() + "&link="+HttpContext.Current.Session["link"].ToString()+"&xid=" + row["xid"].ToString();
                                a.Attributes["href"] = row["xurl"].ToString() + "?xid=" + row["xid"].ToString();
                                div.Controls.Add(a);

                                HtmlGenericControl img = new HtmlGenericControl("img");
                                img.Attributes["class"] = "image";
                                img.Attributes["src"] = row["ximagepath"].ToString();
                                a.Controls.Add(img);

                            }
                        }
                        else
                        {
                            ArrayList permis = new ArrayList();
                            string permission = "";

                            DataSet dts1 = new DataSet();
                            dts1.Reset();

                            str = "SELECT xpermis FROM ztpermis WHERE xid=@xid and zid=@zid";

                            SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                            da1.SelectCommand.Parameters.AddWithValue("@xid", xid);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", zid);


                            da1.Fill(dts1, "tempdt");
                            DataTable temp1 = new DataTable();
                            temp1 = dts1.Tables[0];

                            string[] xxid;

                            if (temp1.Rows.Count > 0)
                            {
                                permission = temp1.Rows[0][0].ToString();

                                xxid = permission.Split('|');
                                foreach (string id in xxid)
                                {
                                    permis.Add(id.Trim());
                                }
                            }
                            else
                            {
                                str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                                SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

                                da2.SelectCommand.Parameters.AddWithValue("@xuser", xid);

                                DataSet dts2 = new DataSet();

                                dts2.Reset();

                                da2.Fill(dts2, "tempdt");
                                DataTable temp2 = new DataTable();
                                temp2 = dts2.Tables[0];

                                if (temp2.Rows.Count > 0)
                                {
                                    str = "SELECT xpermis FROM ztpermis WHERE xid=@xid and zid=@zid";
                                    SqlDataAdapter da3 = new SqlDataAdapter(str, conn1);

                                    xid = temp2.Rows[0][0].ToString();
                                    da3.SelectCommand.Parameters.AddWithValue("@xid", xid);
                                    da3.SelectCommand.Parameters.AddWithValue("@zid", zid);

                                    DataSet dts3 = new DataSet();
                                    dts3.Reset();

                                    da3.Fill(dts3, "tempdt");
                                    DataTable temp3 = new DataTable();
                                    temp3 = dts3.Tables[0];

                                    if (temp3.Rows.Count > 0)
                                    {
                                        permission = temp3.Rows[0][0].ToString();

                                        xxid = permission.Split('|');
                                        foreach (string id in xxid)
                                        {
                                            permis.Add(id.Trim());
                                        }
                                    }

                                    da3.Dispose();
                                    dts3.Dispose();
                                    temp3.Dispose();
                                }

                                da2.Dispose();
                                dts2.Dispose();
                                temp2.Dispose();
                            }

                            da1.Dispose();
                            dts1.Dispose();
                            temp1.Dispose();

                            foreach (DataRow row in result)
                            {
                                //Response.Write("DashBoard  : " + row["xid"].ToString().Trim() + " ");
                                foreach (string _permis in permis)
                                {
                                    //Response.Write("Permis : " + _permis + " ");
                                    if (row["xid"].ToString().Trim() == _permis)
                                    {
                                        HtmlGenericControl div = new HtmlGenericControl("div");
                                        div.Attributes["class"] = "link_con";
                                        group1.Controls.Add(div);

                                        HtmlGenericControl a = new HtmlGenericControl("a");
                                        a.Attributes["href"] = row["xurl"].ToString() + "?xid=" + row["xid"].ToString();
                                        div.Controls.Add(a);

                                        HtmlGenericControl img = new HtmlGenericControl("img");
                                        img.Attributes["class"] = "image";
                                        img.Attributes["src"] = row["ximagepath"].ToString();
                                        a.Controls.Add(img);
                                        break;
                                    }
                                }
                                //Response.Write("<br>");

                            }

                        }
                    }

                }

                dts.Dispose();
                da.Dispose();
                temp.Dispose();

                

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }


    }
}
