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
    public partial class stdquickcon : System.Web.UI.Page
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
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                string xsession1 = "";
                string xclass1 = "";
                string xgroup1 = "";
                string xsection1 = "";


                if (xsession.Text.Trim().ToString() == "All")
                {
                    //ArrayList value = zglobal.fnGetValue1("xcode", "mscodesam", "zid="+ _zid.ToString() +" and  xtype='Session'");

                    //for(int i=0;i<value.Count;i++)
                    //{
                    //    if (i == value.Count + -1)
                    //    {
                    //        xsession1 = xsession1 + "'" + value[i] + "'";
                    //    }
                    //    else
                    //    {
                    //        xsession1 = xsession1 + "'" + value[i] + "',";
                    //    }

                    //}

                    for (int i = 0; i < xsession.Items.Count; i++)
                    {
                        //if (xsession.Items[i].ToString() != "All")
                        //{
                        if (i == xsession.Items.Count - 1)
                        {
                            xsession1 = xsession1 + "'" + xsession.Items[i].ToString() + "'";
                        }
                        else
                        {
                            xsession1 = xsession1 + "'" + xsession.Items[i].ToString() + "',";
                        }
                        //}

                    }
                }
                else
                {
                    xsession1 = "'" + xsession.Text.Trim().ToString() + "'";
                }

                if (xclass.Text.Trim().ToString() == "All")
                {
                    //ArrayList value = zglobal.fnGetValue1("xcode", "mscodesam", "zid=" + _zid.ToString() + " and  xtype='Class'");

                    //for (int i = 0; i < value.Count; i++)
                    //{
                    //    if (i == value.Count + -1)
                    //    {
                    //        xclass1 = xclass1 + "'" + value[i] + "'";
                    //    }
                    //    else
                    //    {
                    //        xclass1 = xclass1 + "'" + value[i] + "',";
                    //    }

                    //}

                    for (int i = 0; i < xclass.Items.Count; i++)
                    {
                        //if (xclass.Items[i].ToString() != "All")
                        //{
                        if (i == xclass.Items.Count - 1)
                        {
                            xclass1 = xclass1 + "'" + xclass.Items[i].ToString() + "'";
                        }
                        else
                        {
                            xclass1 = xclass1 + "'" + xclass.Items[i].ToString() + "',";
                        }
                        //}

                    }
                }
                else
                {
                    xclass1 = "'" + xclass.Text.Trim().ToString() + "'";
                }

                if (xgroup.Text.Trim().ToString() == "All")
                {
                    //ArrayList value = zglobal.fnGetValue1("xcode", "mscodesam", "zid=" + _zid.ToString() + " and  xtype='Education Group'");

                    //for (int i = 0; i < value.Count; i++)
                    //{
                    //    if (i == value.Count + -1)
                    //    {
                    //        xgroup1 = xgroup1 + "'" + value[i] + "'";
                    //    }
                    //    else
                    //    {
                    //        xgroup1 = xgroup1 + "'" + value[i] + "',";
                    //    }

                    //}

                    for (int i = 0; i < xgroup.Items.Count; i++)
                    {
                        //if (xgroup.Items[i].ToString() != "All")
                        //{
                        if (i == xgroup.Items.Count - 1)
                        {
                            xgroup1 = xgroup1 + "'" + xgroup.Items[i].ToString() + "'";
                        }
                        else
                        {
                            xgroup1 = xgroup1 + "'" + xgroup.Items[i].ToString() + "',";
                        }
                        //}

                    }
                }
                else
                {
                    xgroup1 = "'" + xgroup.Text.Trim().ToString() + "'";
                }

                if (xsection.Text.Trim().ToString() == "All")
                {
                    //ArrayList value = zglobal.fnGetValue1("xcode", "mscodesam", "zid=" + _zid.ToString() + " and  xtype='Section'");

                    //for (int i = 0; i < value.Count; i++)
                    //{
                    //    if (i == value.Count + -1)
                    //    {
                    //        xsection1 = xsection1 + "'" + value[i] + "'";
                    //    }
                    //    else
                    //    {
                    //        xsection1 = xsection1 + "'" + value[i] + "',";
                    //    }

                    //}

                    for (int i = 0; i < xsection.Items.Count; i++)
                    {
                        //if (xsection.Items[i].ToString() != "All")
                        //{
                        if (i == xsection.Items.Count - 1)
                        {
                            xsection1 = xsection1 + "'" + xsection.Items[i].ToString() + "'";
                        }
                        else
                        {
                            xsection1 = xsection1 + "'" + xsection.Items[i].ToString() + "',";
                        }
                        //}

                    }
                }
                else
                {
                    xsection1 = "'" + xsection.Text.Trim().ToString() + "'";
                }



                dts.Reset();
                string str = "";


                /*
                 
                            select * from  amstudentvw where xsection in (select xcode from mscodesam where zid=amstudentvw.zid and  xtype='Section')
							and xsession in (select xcode from mscodesam where zid=amstudentvw.zid and  xtype='Session')
							and xclass in (select xcode from mscodesam where zid=amstudentvw.zid and  xtype='Class')
							and (xname like '%1422%' or xstdid like '%1422%' or xcellno like '%1422%' or xcellno1 like '%1422%')
                 
                 */


                //if (xgroup.Text == "All")
                //{
                //    //str = "SELECT  RIGHT(xrow,3) as xrow,xname,xsection,xstdid,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,xfname,xmname FROM amadmis where zid=@zid and xsession=@xsession and xclass=@xclass and xgroup=@xgroup  and coalesce(xstdid,'') <> ''  ORDER BY xstdid ";
                //    //str = "SELECT  RIGHT(xrow,3) as xrow,xname,xsection,xstdid,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,(xfname + '<br>' + xcellno1) as xfname,(xmname + '<br>' + xcellno) as xmname,xcellno,xcellno1,xdob,xblood,xsession,xclass,xgroup FROM amstudentvw where zid=@zid and xsession=@xsession and xclass=@xclass and xgroup=@xgroup  and coalesce(xstdid,'') <> ''  ORDER BY xstdid ";
                //    str = "SELECT  RIGHT(xrow,3) as xrow,xname,xsection,xstdid,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,(xfname + '<br>' + xcellno1) as xfname,(xmname + '<br>' + xcellno) as xmname,xcellno,xcellno1,xdob,xblood,xsession,xclass,xgroup FROM amstudentvw where zid=@zid and xsession in(@xsession) and xclass in(@xclass) and xsection in(@xsection)  "+
                //        " and (xname like '%@per%' or xstdid like '%@per%' or xcellno like '%@per%' or xcellno1 like '%@per%')   ORDER BY xstdid ";
                //}
                //else
                //{
                    //str = "SELECT  RIGHT(xrow,3) as xrow,xname,xsection,xstdid,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,(xfname + '<br>' + xcellno1) as xfname,(xmname + '<br>' + xcellno) as xmname,xcellno,xcellno1,xdob,xblood,xsession,xclass,xgroup FROM amstudentvw where zid=@zid and xsession=@xsession and xclass=@xclass and xgroup=@xgroup  AND xsection=@xsection and coalesce(xstdid,'') <> '' ORDER BY xstdid ";

                if (xclass.Text.Trim().ToString() == "" && _searchbox.Text.Trim().ToString() != "")
                {
                    str = "SELECT  RIGHT(xrow,3) as xrow,xname,xsection,xstdid,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,(xfname + '<br>' + xcellno1) as xfname, (select case when coalesce(xadmitdate,'1999-01-01')='1999-01-01' then '' else xadmitdate end from amadmis where zid=amstudentvw.zid and xrow=amstudentvw.xrow) as  xadmitdate,  " +
                          "(xmname + '<br>' + xcellno) as xmname,xcellno,xcellno1,xdob,xblood,coalesce((select xsession from amadmis where zid=amstudentvw.zid and xrow=amstudentvw.xrow),'') as xsession,xclass,xgroup FROM amstudentvw where zid=@zid and xsession in(" + xsession1 + ") and " +
                          "coalesce(xsection,'') in(" + xsection1 + ") and xgroup in(" + xgroup1 + ") " +
                          "   and (xname like '%" + _searchbox.Text.Trim().ToString() + "%' or xstdid like '%" + _searchbox.Text.Trim().ToString() + "%' or xcellno like '%" +
                          _searchbox.Text.Trim().ToString() + "%' or xcellno1 like '%" + _searchbox.Text.Trim().ToString() + "%' or xfname like '%" + _searchbox.Text.Trim().ToString() + "%' or xemail1 like '%" + _searchbox.Text.Trim().ToString() + "%')  ORDER BY xstdid ";
                }
                else
                {
                    str = "SELECT  RIGHT(xrow,3) as xrow,xname,xsection,xstdid,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,(xfname + '<br>' + xcellno1) as xfname,(select case when coalesce(xadmitdate,'1999-01-01')='1999-01-01' then '' else xadmitdate end from amadmis where zid=amstudentvw.zid and xrow=amstudentvw.xrow) as  xadmitdate, " +
                          "(xmname + '<br>' + xcellno) as xmname,xcellno,xcellno1,xdob,xblood,coalesce((select xsession from amadmis where zid=amstudentvw.zid and xrow=amstudentvw.xrow),'') as xsession,xclass,xgroup FROM amstudentvw where zid=@zid and xsession in(" + xsession1 + ") and " +
                          "xclass in(" + xclass1 + ") and coalesce(xsection,'') in(" + xsection1 + ") and xgroup in(" + xgroup1 + ") " +
                          "   and (xname like '%" + _searchbox.Text.Trim().ToString() + "%' or xstdid like '%" + _searchbox.Text.Trim().ToString() + "%' or xcellno like '%" +
                          _searchbox.Text.Trim().ToString() + "%' or xcellno1 like '%" + _searchbox.Text.Trim().ToString() + "%' or xfname like '%" + _searchbox.Text.Trim().ToString() + "%' or xemail1 like '%" + _searchbox.Text.Trim().ToString() + "%')  ORDER BY xstdid ";
                }
                
               // }

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                

               // message.InnerHtml = xfrom1 + " " + xto1;
                //message.InnerHtml = xsession1 + "     " + xclass1;
                //return;
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                //da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                //da.SelectCommand.Parameters.AddWithValue("@per", _searchbox.Text.Trim().ToString());
                da.Fill(dts, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];
                _grid_emp.DataSource = dtztcode;
                _grid_emp.DataBind();

                //int totboy = dtztcode.AsEnumerable().Sum(row => row.Field<int>("xboy"));
                //int totgirl = dtztcode.AsEnumerable().Sum(row => row.Field<int>("xgirl"));
                //int total = dtztcode.AsEnumerable().Sum(row => row.Field<int>("xtotal"));
                //_grid_emp.FooterRow.Cells[1].Text = "Grand Total";
                // _grid_emp.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                //_grid_emp.FooterRow.Cells[2].Text = totboy.ToString();
                //_grid_emp.FooterRow.Cells[3].Text = totgirl.ToString();
                //_grid_emp.FooterRow.Cells[4].Text = total.ToString();

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

        private int xboy1 = 0;
        private int xgirl1 = 0;
        private int xtotal1 = 0;
        private int xblank1 = 0;

        protected void _grid_emp_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    xboy1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem,"xboy"));
                //    xgirl1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xgirl"));
                //    xblank1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xblank"));
                //    xtotal1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xtotal"));
                //}
                //if (e.Row.RowType == DataControlRowType.Footer)
                //{
                //    e.Row.Cells[1].Text = "Grand Total :";
                //    e.Row.Cells[1].Font.Bold = true;
                //    e.Row.Cells[1].ForeColor = Color.White;


                //    e.Row.Cells[2].Text = xboy1.ToString();
                //    e.Row.Cells[2].Font.Bold = true;
                //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                //    e.Row.Cells[2].ForeColor = Color.White;

                //    e.Row.Cells[3].Text = xgirl1.ToString();
                //    e.Row.Cells[3].Font.Bold = true;
                //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                //    e.Row.Cells[3].ForeColor = Color.White;

                //    e.Row.Cells[4].Text = xblank1.ToString();
                //    e.Row.Cells[4].Font.Bold = true;
                //    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                //    e.Row.Cells[4].ForeColor = Color.White;

                //    e.Row.Cells[5].Text = xtotal1.ToString();
                //    e.Row.Cells[5].Font.Bold = true;
                //    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                //    e.Row.Cells[5].ForeColor = Color.White;
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        
        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                
                fnFillDataGrid(null,null);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
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

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");

                    zglobal.fnGetComboDataCD("Class", xclass);
                    //xclass.Items.Add("All");
                    //xclass.Text = "All";

                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    xgroup.Items.Add("All");
                    xgroup.Text = "All";

                    zglobal.fnGetComboDataCD("Section", xsection);
                    xsection.Items.Add("All");
                    xsection.Text = "All";


                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }

     

       


        
    }
}