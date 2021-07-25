using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Transactions;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class stdbirthday : System.Web.UI.Page
    {
       

        string zid;
        string zorg;
        string ctlid;
        string rowid;
        object row;
        private string q_val;
        private string filter;
        

        public void fnFillDataGrid(object sender,EventArgs e)
        {
            try
            {
                message.InnerHtml = "";

                //if (xoption.Text == "Today & Tomorrow")
                //{
                //    month.Visible = true;
                //    tomorrow.Visible = true;

                //    todathead.InnerHtml = "";
                //    tomorrowhead.InnerHtml = "";

                //}
                //else
                //{
                //    month.Visible = true;
                //    tomorrow.Visible = false;

                //    todathead.InnerHtml = "";
                //    tomorrowhead.InnerHtml = "";

                //}


                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                string xclass1 = "";
               
                if (xclass.Text.Trim().ToString() == "All")
                {
                    
                    for (int i = 0; i < xclass.Items.Count; i++)
                    {
                        
                        if (i == xclass.Items.Count - 1)
                        {
                            xclass1 = xclass1 + "'" + xclass.Items[i].ToString() + "'";
                        }
                        else
                        {
                            xclass1 = xclass1 + "'" + xclass.Items[i].ToString() + "',";
                        }
                       

                    }
                }
                else
                {
                    xclass1 = "'" + xclass.Text.Trim().ToString() + "'";
                }

                dts.Reset();
                string str = "";

                if (xoption.Text.Trim().ToString() == "Today & Tomorrow")
                {
                    str = "SELECT  xname,xstdid,xexamdate,xdob,xblood, (xclass + '  (' +left(xsection,1) + ')')  as xclass FROM amstudentvw " +
                          "inner join mscodesam on mscodesam.zid=amstudentvw.zid and mscodesam.xtype='Section' and xcode=amstudentvw.xsection " +
                          "where amstudentvw.zid=@zid and day(xdob)=day(GETDATE()) and month(xdob) =month(getdate()) and xsession=@xsession " +
                           "and amstudentvw.xclass in(" + xclass1 + ") " +
                          "order by day(xdob),month(xdob),year(xdob) ";

                    todathead.InnerHtml = "Today (" + DateTime.Today.ToString("dd/MM/yyyy") + ")";
                }
                else if (xoption.Text.Trim().ToString() == "Birthday List (Class Wise)")
                {
                    str = "SELECT  xname,xstdid,xexamdate,xdob,xblood, (xclass + '  (' +left(xsection,1) + ')')  as xclass FROM amstudentvw " +
                          "inner join mscodesam on mscodesam.zid=amstudentvw.zid and mscodesam.xtype='Section' and xcode=amstudentvw.xsection " +
                          "where amstudentvw.zid=@zid and day(xdob)=day(GETDATE()) and month(xdob) =month(getdate()) and xsession=@xsession " +
                          "and amstudentvw.xclass in(" + xclass1 + ") " +
                          "order by day(xdob),month(xdob),year(xdob) ";

                    todathead.InnerHtml = "Today (" + DateTime.Today.ToString("dd/MM/yyyy") + ")";
                }
                else if (xoption.Text.Trim().ToString() == "Birthday List (Month Wise)")
                {
                    str = "SELECT  xname,xstdid,xexamdate,xdob,xblood, (xclass + '  (' +left(xsection,1) + ')')  as xclass FROM amstudentvw " +
                          "inner join mscodesam on mscodesam.zid=amstudentvw.zid and mscodesam.xtype='Section' and xcode=amstudentvw.xsection " +
                          "where amstudentvw.zid=@zid and month(xdob) =@month and xsession=@xsession " +
                          "and amstudentvw.xclass in(" + xclass1 + ") " +
                          "order by day(xdob),month(xdob),year(xdob) ";

                    todathead.InnerHtml = "Month : " + xmonth.SelectedItem.Text;
                }


                //and amstudentvw.xclass in(" + xclass1 + ")

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                da.SelectCommand.Parameters.AddWithValue("@month", Convert.ToInt32(xmonth.SelectedItem.Value.Trim().ToString()));
                da.Fill(dts, "tempztcode");

                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];
                if (dtztcode.Rows.Count > 0)
                {

                    GridView1.DataSource = dtztcode;
                    GridView1.DataBind();

                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    if (xoption.Text.Trim().ToString() == "Today & Tomorrow")
                    {
                        todathead.InnerHtml = "Today have no birthday.";
                    }
                    else if (xoption.Text.Trim().ToString() == "Birthday List (Class Wise)")
                    {
                        todathead.InnerHtml = "Today have no birthday.";
                    }
                    else if (xoption.Text.Trim().ToString() == "Birthday List (Month Wise)")
                    {
                        todathead.InnerHtml = "Have no birthday in month '"+xmonth.SelectedItem.Text+"'.";
                    }
                    
                }

                if (xoption.Text.Trim().ToString() == "Today & Tomorrow")
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts1 = new DataSet())
                        {
                            string query = "SELECT  xname,xstdid,xexamdate,xdob,xblood, (xclass + '  (' +left(xsection,1) + ')')  as xclass FROM amstudentvw " +
                          "inner join mscodesam on mscodesam.zid=amstudentvw.zid and mscodesam.xtype='Section' and xcode=amstudentvw.xsection " +
                          "where amstudentvw.zid=@zid and day(xdob)=day(dateadd(day,1,getdate())) and month(xdob) =month(getdate()) and xsession=@xsession " +
                          "and amstudentvw.xclass in(" + xclass1 + ") " +
                          "order by day(xdob),month(xdob),year(xdob) ";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                            da1.Fill(dts1, "tempTable");
                            
                           
                            DataTable tempTable = new DataTable();
                            tempTable = dts1.Tables["tempTable"];

                            if (tempTable.Rows.Count > 0)
                            {
                                tomorrowhead.InnerHtml = "Tomorrow (" + DateTime.Today.AddDays(1).ToString("dd/MM/yyyy") + ")";

                                GridView2.DataSource = tempTable;
                                GridView2.DataBind();
                            }
                            else
                            {
                                tomorrowhead.InnerHtml = "Tomorrow have no birthday.";

                                GridView2.DataSource = null;
                                GridView2.DataBind();
                            }



                            da1.Dispose();
                        }
                    }
                }
                else
                {
                    tomorrowhead.InnerHtml = "";

                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }

                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }


        }

        //private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        //{
        //    row.BackColor = Color.Gray;
        //    row.Cells[0].ForeColor = Color.White;
        //    row.Cells[0].Attributes.Add("style", "padding-left:30px");
        //    //Color.FromArgb(236, 236, 236);
        //}

        private int xboy1 = 0;
        private int xgirl1 = 0;
        private int xtotal1 = 0;
        private int xblank1 = 0;

        protected void _grid_emp_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    //if (e.Row.RowType == DataControlRowType.DataRow)
            //    //{
            //    //    xboy1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem,"xboy"));
            //    //    xgirl1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xgirl"));
            //    //    xblank1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xblank"));
            //    //    xtotal1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xtotal"));
            //    //}
            //    //if (e.Row.RowType == DataControlRowType.Footer)
            //    //{
            //    //    e.Row.Cells[1].Text = "Grand Total :";
            //    //    e.Row.Cells[1].Font.Bold = true;
            //    //    e.Row.Cells[1].ForeColor = Color.White;


            //    //    e.Row.Cells[2].Text = xboy1.ToString();
            //    //    e.Row.Cells[2].Font.Bold = true;
            //    //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            //    //    e.Row.Cells[2].ForeColor = Color.White;

            //    //    e.Row.Cells[3].Text = xgirl1.ToString();
            //    //    e.Row.Cells[3].Font.Bold = true;
            //    //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //    //    e.Row.Cells[3].ForeColor = Color.White;

            //    //    e.Row.Cells[4].Text = xblank1.ToString();
            //    //    e.Row.Cells[4].Font.Bold = true;
            //    //    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            //    //    e.Row.Cells[4].ForeColor = Color.White;

            //    //    e.Row.Cells[5].Text = xtotal1.ToString();
            //    //    e.Row.Cells[5].Font.Bold = true;
            //    //    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            //    //    e.Row.Cells[5].ForeColor = Color.White;
            //    //}
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //}
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            
        }
        protected void fnFilterByRow(object sender, EventArgs e)
        {
            //try
            //{
                
            //    fnFillDataGrid(null,null);

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //}
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            //    //////Check Permission
            //    ////SiteMaster sm = new SiteMaster();
            //    ////string s = sm.fnChkPagePermis("ztpermis");
            //    ////if (s == "n" || s == "e")
            //    ////{
            //    ////    HttpContext.Current.Session["curuser"] = null;
            //    ////    Session.Abandon();
            //    ////    Response.Redirect("~/forms/zlogin.aspx");
            //    ////}


            //    //pagew = Request.QueryString["page"];
            //    //if (pagew == "user")
            //    //{
            //    //    curuser = Request.QueryString["xuser"];
            //    //    xuser.InnerHtml = "User : " + curuser;
            //    //}
            //    //else
            //    //{
            //    //    curuser = Request.QueryString["xrole"];
            //    //    xuser.InnerHtml = "Role : " + curuser;
            //    //}

                //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                if (!IsPostBack)
                {
                   // //zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                   // ctlid = Request.QueryString["ctlid"] != "" ? Request.QueryString["ctlid"] : "-1";
                   // //filter = Request.QueryString["filter"] != "" ? Request.QueryString["filter"] : "";
                   // ctlid_v.Value = ctlid;
                   //// Response.Write(ctlid_v.Value);
                    _gridrow.Text = zglobal._grid_row_value;

                    //xfrom.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //xto.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //fnFillDataGrid(null,null);

                     zglobal.fnGetComboDataCD("Session", xsession);
                    //xsession.Items.Add("All");
                    //xsession.Text = "All";

                    
                    zglobal.fnGetComboDataCD("Class", xclass);
                    xclass.Items.Add("All");
                    xclass.Text = "All";

                    //xclass.Items.Add("All");
                    //xclass.Text = "All";

                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //xgroup.Items.Add("All");
                    //xgroup.Text = "All";

                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //xsection.Items.Add("All");
                    //xsection.Text = "All";

                    xoption.Items.Add("Today & Tomorrow");
                    xoption.Items.Add("Birthday List (Class Wise)");
                    xoption.Items.Add("Birthday List (Month Wise)");
                    xoption.Text = "Today & Tomorrow";

                    zglobal.fnComboMonth(xmonth);

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");

                    //today.Visible = false;
                    //tomorrow.Visible = false;
                    month.Visible = false;


                    fnFillDataGrid(sender, e);
                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }


        protected void xoption_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                //today.Visible = false;
                //tomorrow.Visible = false;
                if (xoption.Text == "Birthday List (Month Wise)")
                {
                    month.Visible = true;
                    xmonth.SelectedValue = "01";

                }
                else
                {
                    month.Visible = false;
                }

                
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }


    }
}