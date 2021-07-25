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
    public partial class numcandidates : System.Web.UI.Page
    {


        string zid;
        string zorg;
        string ctlid;
        string rowid;
        object row;
        private string q_val;
        private string filter;


        public void fnFillDataGrid(object sender, EventArgs e)
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            //string str = "SELECT ROW_NUMBER() OVER (ORDER BY xclass) AS xno,xcodealt,xclass,SUM(CASE WHEN xgender='Boy' THEN 1 ELSE 0 END) AS xboy, " +
            //             "SUM(CASE WHEN xgender='Girl' THEN 1 ELSE 0 END) AS xgirl, SUM(CASE WHEN xgender='' THEN 1 ELSE 0 END) AS xblank," +
            //             "SUM(CASE WHEN xgender='Boy' THEN 1 ELSE 0 END + CASE WHEN xgender='Girl' THEN 1 ELSE 0 END + CASE WHEN xgender='' THEN 1 ELSE 0 END) AS xtotal, " +
            //             "SUM(CASE WHEN coalesce(xreference,'')='' THEN 1 ELSE 0 END) AS xphysical, " +
            //             "SUM(CASE WHEN coalesce(xreference,'')<>'' THEN 1 ELSE 0 END) AS xonline " +
            //             "FROM amadmis INNER JOIN mscodesam on amadmis.zid=mscodesam.zid and mscodesam.xtype='Class' and xclass=xcode WHERE amadmis.zid=@zid AND xexamdate > '01/01/1900' AND xdate1>=@xfrom AND xdate1<=@xto AND coalesce(xstatus2,'') = '' " +
            //             "GROUP BY xcodealt,xclass " +
            //             "ORDER BY xcodealt ";

            string str = "select  zid,xsession,xcodealt,xclass,sum(xboy) as xboy,sum(xgirl) as xgirl,sum(xblank) as xblank,sum(xtotal) as xtotal, sum(xphysical) as xphysical,sum(xonline) as xonline , " +
                         "(select count(*) from amadmis INNER JOIN mscodesam on amadmis.zid=mscodesam.zid and mscodesam.xtype='Class' and xclass=xcode " +
                         "where  COALESCE (xstatus3, '') <> 'Revised'  and (select count(*) from amtfch where zid=tbl.zid and xsession=tbl.xsession and xsrow=amadmis.xrow ) >= 1 and amadmis.zid=tbl.zid " +
                         "and xsession=tbl.xsession and xclass=tbl.xclass and coalesce(xstatus4,'') <> 'old'  ) as xnew, " +
                         "(select count(*) from amadmis INNER JOIN mscodesam on amadmis.zid=mscodesam.zid and mscodesam.xtype='Class' and xclass=xcode " +
                         "where  COALESCE (xstatus3, '') <> 'Revised'  and COALESCE (xstatus1, '') = 'Approved' and amadmis.zid=tbl.zid " +
                         "and xsession=tbl.xsession and xclass=tbl.xclass and coalesce(xstatus4,'') <> 'old'  ) as xqualified " +
                         "from " +
                         "(" +
                         "SELECT amadmis.zid,xsession,xcodealt,xclass,(CASE WHEN xgender='Boy' THEN 1 ELSE 0 END) AS xboy, " +
                         "(CASE WHEN xgender='Girl' THEN 1 ELSE 0 END) AS xgirl, " +
                         "(CASE WHEN xgender='' THEN 1 ELSE 0 END) AS xblank," +
                         "(CASE WHEN xgender='Boy' THEN 1 ELSE 0 END + CASE WHEN xgender='Girl' THEN 1 ELSE 0 END + CASE WHEN xgender='' THEN 1 ELSE 0 END) AS xtotal, " +
                         "(CASE WHEN coalesce(xreference,'')='' THEN 1 ELSE 0 END) AS xphysical, " +
                         "(CASE WHEN coalesce(xreference,'')<>'' THEN 1 ELSE 0 END) AS xonline " +
                         //"(CASE WHEN COALESCE (xstatus3, '') <> 'Revised'  and COALESCE (xstatus1, '') = 'Approved'  THEN 1 ELSE 0 END) AS xqualified, " +
                         //"(CASE WHEN (select count(*) from amtfch where zid=amadmis.zid and xsession=amadmis.xsession and xsrow=amadmis.xrow ) >= 1 and COALESCE (xstatus3, '') <> 'Revised'  " +
                         //"THEN 1 ELSE 0 END) AS xnew " + //and COALESCE (xstatus1, '') = 'Approved' 
                         "FROM amadmis INNER JOIN mscodesam on amadmis.zid=mscodesam.zid and mscodesam.xtype='Class' and xclass=xcode " +
                         "WHERE amadmis.zid=@zid AND coalesce(xstatus4,'') <> 'old' AND xsession=@xsession AND coalesce(xstatus2,'') = '' " +
                         ")tbl " +
                         "GROUP BY zid,xsession,xcodealt,xclass " +
                         "ORDER BY xcodealt ";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

            //DateTime xfrom1 = DateTime.ParseExact(xfrom.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime xto1 = DateTime.ParseExact(xto.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //message.InnerHtml = xfrom1 + " " + xto1;
            da.SelectCommand.Parameters.Add("@zid", _zid);
            da.SelectCommand.Parameters.Add("@xsession", xsession.Text.ToString().Trim());
            //da.SelectCommand.Parameters.Add("@xfrom", xfrom1);
            //da.SelectCommand.Parameters.Add("@xto", xto1);
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

        private int xboy1 = 0;
        private int xgirl1 = 0;
        private int xtotal1 = 0;
        private int xblank1 = 0;
        private int xphysical1 = 0;
        private int xonline1 = 0;
        private int xqualified1 = 0;
        private int xnew1 = 0;

        protected void _grid_emp_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    xboy1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem,"xboy"));
                    xgirl1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xgirl"));
                    xblank1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xblank"));
                    xtotal1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xtotal"));
                    xphysical1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xphysical"));
                    xonline1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xonline"));
                    xqualified1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xqualified"));
                    xnew1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "xnew"));

                        if (e.Row.RowIndex % 2 == 0)
                        {
                            e.Row.Cells[5].BackColor = ColorTranslator.FromHtml("#d4f5dd");
                            e.Row.Cells[6].BackColor = ColorTranslator.FromHtml("#f2deea");
                        }
                        else
                        {
                            e.Row.Cells[5].BackColor = ColorTranslator.FromHtml("#b3f7c5");
                            e.Row.Cells[6].BackColor = ColorTranslator.FromHtml("#f3c9e2");
                        }

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[1].Text = "Grand Total :";
                    e.Row.Cells[1].Font.Bold = true;
                    e.Row.Cells[1].ForeColor = Color.White;


                    e.Row.Cells[2].Text = xphysical1.ToString();
                    e.Row.Cells[2].Font.Bold = true;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[2].ForeColor = Color.White;

                    e.Row.Cells[3].Text = xonline1.ToString();
                    e.Row.Cells[3].Font.Bold = true;
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[3].ForeColor = Color.White;

                    e.Row.Cells[4].Text = xtotal1.ToString();
                    e.Row.Cells[4].Font.Bold = true;
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[4].ForeColor = Color.White;

                    e.Row.Cells[5].Text = xboy1.ToString();
                    e.Row.Cells[5].Font.Bold = true;
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[5].ForeColor = Color.White;

                    e.Row.Cells[6].Text = xgirl1.ToString();
                    e.Row.Cells[6].Font.Bold = true;
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[6].ForeColor = Color.White;

                    e.Row.Cells[7].Text = xqualified1.ToString();
                    e.Row.Cells[7].Font.Bold = true;
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[7].ForeColor = Color.White;

                    e.Row.Cells[8].Text = xnew1.ToString();
                    e.Row.Cells[8].Font.Bold = true;
                    e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[8].ForeColor = Color.White;
                }
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

                fnFillDataGrid(null, null);

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

                    zglobal.fnGetComboDataCD("Session", xsession);
                    xsession.Text = zglobal.fnDefaults("xsessiononline", "Student");

                    //xfrom.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //xto.Text = DateTime.Today.ToString("dd/MM/yyyy");

                    fnFillDataGrid(null, null);


                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }

        }







    }
}