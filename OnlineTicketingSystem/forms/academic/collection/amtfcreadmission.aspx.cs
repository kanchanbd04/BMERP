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
    public partial class amtfcreadmission : System.Web.UI.Page
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
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "";

                //if (xnumexam.Text == "All")
                //{
                //    str = "SELECT  RIGHT(xrow,3) as xrow,xname,xexamroll,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,xfname,xmname,xrow as xrow1,xstdid,coalesce((select xstatus from amtfch where zid=amadmis.zid and xsrow=amadmis.xrow and xtype='Admission'),'') as xstatus FROM amadmis where zid=@zid and xsession=@xsession and xclass=@xclass and xgroup=@xgroup and xstatus1='Approved' AND coalesce(xstatus3,'')<>'Revised' ORDER BY xname ASC";
                //}
                //else
                //{
                //    str = "SELECT  RIGHT(xrow,3) as xrow,xname,xexamroll,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact,xgender,xfname,xmname,xrow as xrow1,xstdid,coalesce((select xstatus from amtfch where zid=amadmis.zid and xsrow=amadmis.xrow and xtype='Admission'),'') as xstatus FROM amadmis where zid=@zid and xsession=@xsession and xclass=@xclass and xgroup=@xgroup and xstatus1='Approved' AND xnumexam=@xnumexam AND coalesce(xstatus3,'')<>'Revised' ORDER BY xname ASC";
                //}

                //str = "SELECT  xrow,xname,xexamroll,xexamdate,xexamvenue,(xcellno +', '+ xcellno1) as xcontact," +
                //      "xfname,xmname,xstdid,coalesce((select xstatus from amtfch where zid=amadmis.zid and" +
                //      " xsrow=amadmis.xrow and xtype='Readmission'),'') as xstatus,xsection, xrow as xrow1 FROM amstudentvw where zid=@zid and xsession=@xsession and " +
                //      "xclass=@xclass and xgroup=@xgroup  ORDER BY xname ASC";

                str = @"select 
                       (select xstdid from amadmis where xrow=d.xsrow and zid=h.zid) as xstdid,
                       (select xname from amadmis where xrow=d.xsrow and zid=h.zid)  as xname,
                       (select xmname from amadmis where xrow=d.xsrow and zid=h.zid)  as xmname,
                       (select xfname from amadmis where xrow=d.xsrow and zid=h.zid)  as xfname,
                       (select xcellno +', '+ xcellno1 from amadmis where xrow=d.xsrow and zid=h.zid) as xcontact,
                       d.xsrow as xrow1,
                       coalesce((select xstatus from amtfch where zid=h.zid and
                       xsrow=d.xsrow and xtype='Readmission' and xsession=h.xsessionpro),'') as xstatus
                       from ampromotionh as h inner join ampromotiond as d on h.zid=d.zid and h.xrow=d.xrow 
                       WHERE h.zid=@zid AND h.xsessionpro=@xsessionpro  AND h.xclasspro=@xclasspro AND h.xgrouppro=@xgrouppro and h.xstatus='Approved' and 
                       coalesce(d.xpromoted,0)=1
                       ORDER BY (select xname from amadmis where xrow=d.xsrow and zid=h.zid)";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                string xsession1 = xsession.Text.Trim().ToString();
                string xclass1 = xclass.Text.Trim().ToString();
                string xgroup1 = xgroup.Text.Trim().ToString();
               // string xnumexam1 = xnumexam.Text.Trim().ToString();
                //message.InnerHtml = xfrom1 + " " + xto1;
                da.SelectCommand.Parameters.Add("@zid", _zid);
                da.SelectCommand.Parameters.Add("@xsessionpro", xsession1);
                da.SelectCommand.Parameters.Add("@xclasspro", xclass1);
                da.SelectCommand.Parameters.Add("@xgrouppro", xgroup1);
               // da.SelectCommand.Parameters.Add("@xnumexam", xnumexam1);
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
                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("No of Exam", xnumexam);
                    //xnumexam.Items.Add("All");
                    //xnumexam.Text = "All";


                }

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }

     

       


        
    }
}