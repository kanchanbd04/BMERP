using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.admission
{
    public partial class eventinfo : System.Web.UI.Page
    {

        private void fnGridVisibleProp(string _grid)
        {

            if (_grid == _grid_day_o.ID)
            {
                _grid_day_o.Visible = true;
            }
            else
            {
                _grid_day_o.Visible = false;
            }

            if (_grid == _grid_out.ID)
            {
                _grid_out.Visible = true;
            }
            else
            {
                _grid_out.Visible = false;
            }

            if (_grid == _grid_exam.ID)
            {
                _grid_exam.Visible = true;
            }
            else
            {
                _grid_exam.Visible = false;
            }

            if (_grid == _grid_sport.ID)
            {
                _grid_sport.Visible = true;
            }
            else
            {
                _grid_sport.Visible = false;
            }

            if (_grid == _grid_other.ID)
            {
                _grid_other.Visible = true;
            }
            else
            {
                _grid_other.Visible = false;
            }
        }

        public void fnRegisterPostBack()
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {
                if (_grid_day_o.Rows.Count > 0)
                {
                    foreach (GridViewRow row in _grid_day_o.Rows)
                    {
                        LinkButton lnkFull0 = row.FindControl("xrow") as LinkButton;
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull0);
                    }
                }
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                if (_grid_out.Rows.Count > 0)
                {
                    foreach (GridViewRow row in _grid_out.Rows)
                    {
                        LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
                    }
                }
            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
                if (_grid_sport.Rows.Count > 0)
                {
                    foreach (GridViewRow row in _grid_sport.Rows)
                    {
                        LinkButton lnkFull2 = row.FindControl("xrow") as LinkButton;
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull2);
                    }
                }
            }
            else if (TabContainer1.ActiveTabIndex == 3)
            {
                if (_grid_exam.Rows.Count > 0)
                {
                    foreach (GridViewRow row in _grid_exam.Rows)
                    {
                        LinkButton lnkFull3 = row.FindControl("xrow") as LinkButton;
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull3);
                    }
                }
            }
            else if (TabContainer1.ActiveTabIndex == 4)
            {
                if (_grid_other.Rows.Count > 0)
                {
                    foreach (GridViewRow row in _grid_other.Rows)
                    {
                        LinkButton lnkFull4 = row.FindControl("xrow") as LinkButton;
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull4);
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    TabContainer1.ActiveTabIndex = 0;
                    getActiveTabIndex.Value = "0";
                    fnGridVisibleProp("_grid_day_o");
                    _row.Value = "";
                    type.Value = "day_o";
                    _gridrow.Text = zglobal._grid_row_value;
                    zglobal.fnGetComboDataCD("Session", xsession_day_o);
                    zglobal.fnGetComboDataCD("Programme Name", "Days Observation", xprogramme_day_o);
                    zglobal.fnGetComboDataCD("Location", xlocation_day_o);
                    zglobal.fnGetComboDataCD("Session", xsession_out);
                    zglobal.fnGetComboDataCD("Programme Name", "Outings/Duke", xprogramme_out);
                    zglobal.fnGetComboDataCD("Location", xlocation_out);
                    zglobal.fnGetComboDataCD("Class", xfclass_out);
                    zglobal.fnGetComboDataCD("Class", xtclass_out);
                    zglobal.fnGetComboDataCD("Session", xsession_sport);
                    zglobal.fnGetComboDataCD("Programme Name", "Sports/Coaching", xprogramme_sport);
                    zglobal.fnGetComboDataCD("Location", xlocation_sport);
                    zglobal.fnGetComboDataCD("Class", xfclass_sport);
                    zglobal.fnGetComboDataCD("Class", xtclass_sport);
                    zglobal.fnGetComboDataCD("Session", xsession_exam);
                    zglobal.fnGetComboDataCD("Location", xlocation_exam);
                    zglobal.fnGetComboDataCD("Programme Name", "Exam/Test", xexam_exam);
                    zglobal.fnGetComboDataCD("Class", xclass_exam);
                    zglobal.fnGetComboDataCD("Session", xsession_others);
                    zglobal.fnGetComboDataCD("Location", xlocation_others);
                    zglobal.fnGetComboDataCD("Programme Name", "Others", xname_others);
                    zglobal.fnGetComboDataCD("Class", xfclass_others);
                    zglobal.fnGetComboDataCD("Class", xtclass_others);
                    zglobal.fnGetComboDataCD("Session", grid_xsession);
                    zglobal.fnGetComboDataCD("Location", grid_xlocation);
                    cpday_value.Attributes.Add("readonly", "readonly");
                    cpout_value.Attributes.Add("readonly", "readonly");
                    cpsport_value.Attributes.Add("readonly", "readonly");
                    cpexam_value.Attributes.Add("readonly", "readonly");
                    cpother_value.Attributes.Add("readonly", "readonly");
                   //cpday_value.Text = "#0000FF";

                }
                catch (Exception exp)
                {
                    message.InnerHtml = exp.Message;
                }

            }

            try
            {
                if (ViewState["ctladded"] == null)
                {
                    ViewState["ctladded"] = 1;
                }

                fnCreateDynamicControlAtPageLoad();

                fnRegisterPostBack();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            

        }



        public void fnFillDataGrid(object sender, EventArgs e)
        {
            try
            {
                if (grid_xsession.Text == "" || grid_xsession.Text == string.Empty || grid_xsession.Text == "[Select]")
                {
                    message.InnerHtml = "Please Select Session";
                    return;
                }
                if (grid_xlocation.Text == "" || grid_xlocation.Text == string.Empty || grid_xlocation.Text == "[Select]")
                {
                    message.InnerHtml = "Please Select School";
                    return;
                }

                message.InnerHtml = "";
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                string str = "";
                dts.Reset();
                GridView grid = new GridView();
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xdate,xfdate,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xconvenor ) as xconvenor,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xcoconvenor ) as xcoconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                    grid = _grid_day_o;
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xdate,xfdate,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xallconvenor ) as xallconvenor,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xcoconvenor ) as xcoconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                    grid = _grid_out;
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xdate,xfdate,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xallconvenor ) as xallconvenor,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xcoconvenor ) as xcoconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                    grid = _grid_sport;
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xfclass,xfdate,xtdate,xresultdate,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xconvenor ) as xconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                    grid = _grid_exam;
                }
                else if (TabContainer1.ActiveTabIndex == 4)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xfclass,xtclass,xffdate,xtdate,xresultdate,( select xname from hrmst where zid=mscalender.zid and xemp=mscalender.xconvenor ) xconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                    grid = _grid_other;
                }

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xtype = type.Value;
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xtype", xtype);
                da.SelectCommand.Parameters.AddWithValue("@xsession", grid_xsession.Text.Trim().ToString());
                da.SelectCommand.Parameters.AddWithValue("@xlocation", grid_xlocation.Text.Trim().ToString());
                da.Fill(dts, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];
                if (dtztcode.Rows.Count > 0)
                {
                    grid.DataSource = dtztcode;
                    grid.DataBind();
                }
                else
                {
                    grid.DataSource = null;
                    grid.DataBind();
                }




                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();

                fnRegisterPostBack();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                fnFillDataGrid(sender, e);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xtype = type.Value.ToString();
                int xrow = Convert.ToInt32(((LinkButton)sender).Text);
                string str = "SELECT  * FROM mscalender where zid=@zid and xtype=@xtype and xrow=@xrow ";





                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xtype", xtype);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                //xtype.InnerHtml = dtztcode.Rows[0]["xtype"].ToString();
                //xcode.Text = dtztcode.Rows[0]["xcode"].ToString();
                //xdescdet.Value = dtztcode.Rows[0]["xdescdet"].ToString();
                //xcodealt.Text = dtztcode.Rows[0]["xcodealt"].ToString();
                //xprops.Value = dtztcode.Rows[0]["xprops"].ToString();
                //zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                //zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
                //xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    xsession_day_o.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xprogramme_day_o.Text = dtztcode.Rows[0]["xprogram"].ToString();
                    xlocation_day_o.Text = dtztcode.Rows[0]["xlocation"].ToString();
                    xdate_day_o.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
                    xfdate_day_o.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfdate"]).ToString("dd/MM/yyyy");
                    xconvenor_day_o.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xconvenor"].ToString() + "'");
                    _convenor_day.Value = dtztcode.Rows[0]["xconvenor"].ToString();
                    xcoconvenor_day_o.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xcoconvenor"].ToString() + "'");
                    _coconvenor_day.Value = dtztcode.Rows[0]["xcoconvenor"].ToString(); 
                    xprogdetail_day_o.InnerHtml = dtztcode.Rows[0]["xprogdetail"].ToString();
                    cpday_value.Text = dtztcode.Rows[0]["xcolor"].Equals(DBNull.Value) == true ? "FFFFFF" : dtztcode.Rows[0]["xcolor"].ToString();
                    //fff.Attributes.Add(); = dtztcode.Rows[0]["xcolor"].Equals(DBNull.Value) == true ? "FFFFFF" : dtztcode.Rows[0]["xcolor"].ToString();

                    ////////////////////////////////
                    dts.Reset();

                    str = "SELECT * FROM mscalenderevn WHERE zid=@zid AND xtype=@xtype AND xrow=@xrow";

                    SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

                    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da2.SelectCommand.Parameters.AddWithValue("@xtype", xtype);
                    da2.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                    dts.Reset();
                    da2.Fill(dts, "temp");
                    DataTable dttemp = new DataTable();
                    dttemp = dts.Tables[0];
                    placeholder.Controls.Clear();
                    if (dttemp.Rows.Count > 0)
                    {
                        ViewState["ctladded"] = dttemp.Rows.Count;

                        //placeholder.Controls.Clear();

                        int howMany = (int) ViewState["ctladded"];
                        for (int i = 1; i <= howMany; i++)
                        {
                            fnCreateControl(i);
                            ((TextBox) placeholder.FindControl("mytxt" + i)).Text =
                                dttemp.Rows[i - 1]["xname"].ToString();
                            ((DropDownList) placeholder.FindControl("mydwf" + i)).Text =
                                dttemp.Rows[i - 1]["xfclass"].ToString();
                            ((DropDownList) placeholder.FindControl("mydwt" + i)).Text =
                                dttemp.Rows[i - 1]["xtclass"].ToString();
                            ((TextBox) placeholder.FindControl("mydtp" + i)).Text =
                                Convert.ToDateTime(dttemp.Rows[i - 1]["xdate"]).ToString("dd/MM/yyyy");
                        }
                    }
                    else
                    {
                        ViewState["ctladded"] = 1;
                        fnCreateDynamicControlAtPageLoad();
                    }
                    ///////////////////////////////////////
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    xsession_out.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xprogramme_out.Text = dtztcode.Rows[0]["xprogram"].ToString();
                    xlocation_out.Text = dtztcode.Rows[0]["xlocation"].ToString();
                    xdate_out.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
                    xfdate_out.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfdate"]).ToString("dd/MM/yyyy");
                    xallconvenor_out.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xallconvenor"].ToString() + "'");
                    _allconvenor_out.Value = dtztcode.Rows[0]["xallconvenor"].ToString();
                    xcoconvenor_out.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xcoconvenor"].ToString() + "'");
                    _coconvenor_out.Value = dtztcode.Rows[0]["xcoconvenor"].ToString();
                    xfclass_out.Text = dtztcode.Rows[0]["xfclass"].ToString();
                    xtclass_out.Text = dtztcode.Rows[0]["xtclass"].ToString();
                    xffdate_out.Text = Convert.ToDateTime(dtztcode.Rows[0]["xffdate"]).ToString("dd/MM/yyyy");
                    xtdate_out.Text = Convert.ToDateTime(dtztcode.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
                    xvenue_out.Text = dtztcode.Rows[0]["xvenue"].ToString();
                    xconvenor_out.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xconvenor"].ToString() + "'");
                    _convenor_out.Value = dtztcode.Rows[0]["xconvenor"].ToString();
                    xprogdetail_out.InnerHtml = dtztcode.Rows[0]["xprogdetail"].ToString();
                    cpout_value.Text = dtztcode.Rows[0]["xcolor"].Equals(DBNull.Value) == true ? "FFFFFF" : dtztcode.Rows[0]["xcolor"].ToString();
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    xsession_sport.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xprogramme_sport.Text = dtztcode.Rows[0]["xprogram"].ToString();
                    xlocation_sport.Text = dtztcode.Rows[0]["xlocation"].ToString();
                    xdate_sport.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
                    xfdate_sport.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfdate"]).ToString("dd/MM/yyyy");
                    xallconvenor_sport.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xallconvenor"].ToString() + "'");
                    _allconvenor_sport.Value = dtztcode.Rows[0]["xallconvenor"].ToString();
                    xcoconvenor_sport.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xcoconvenor"].ToString() + "'");
                    _coconvenor_sport.Value = dtztcode.Rows[0]["xcoconvenor"].ToString();
                    xfclass_sport.Text = dtztcode.Rows[0]["xfclass"].ToString();
                    xtclass_sport.Text = dtztcode.Rows[0]["xtclass"].ToString();
                    xffdate_sport.Text = Convert.ToDateTime(dtztcode.Rows[0]["xffdate"]).ToString("dd/MM/yyyy");
                    xtdate_sport.Text = Convert.ToDateTime(dtztcode.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
                    xfinaldate_sport.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfinaldate"]).ToString("dd/MM/yyyy");
                    xprogdetail_sport.InnerHtml = dtztcode.Rows[0]["xprogdetail"].ToString();
                    cpsport_value.Text = dtztcode.Rows[0]["xcolor"].Equals(DBNull.Value) == true ? "FFFFFF" : dtztcode.Rows[0]["xcolor"].ToString();
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    xsession_exam.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xlocation_exam.Text = dtztcode.Rows[0]["xlocation"].ToString();
                    xdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
                    xexam_exam.Text = dtztcode.Rows[0]["xprogram"].ToString();
                    xclass_exam.Text = dtztcode.Rows[0]["xfclass"].ToString();
                    xfdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfdate"]).ToString("dd/MM/yyyy");
                    xtdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
                    xsubmission_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xffdate"]).ToString("dd/MM/yyyy");
                    xresultdate_exam.Text = Convert.ToDateTime(dtztcode.Rows[0]["xresultdate"]).ToString("dd/MM/yyyy");
                    xconvenor_exam.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xconvenor"].ToString() + "'");
                    _convenor_exam.Value = dtztcode.Rows[0]["xconvenor"].ToString();
                    xprogdetail_exam.InnerHtml = dtztcode.Rows[0]["xprogdetail"].ToString();
                    cpexam_value.Text = dtztcode.Rows[0]["xcolor"].Equals(DBNull.Value) == true ? "FFFFFF" : dtztcode.Rows[0]["xcolor"].ToString();
                }
                else if (TabContainer1.ActiveTabIndex == 4)
                {
                    xsession_others.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xlocation_others.Text = dtztcode.Rows[0]["xlocation"].ToString();
                    xname_others.Text = dtztcode.Rows[0]["xprogram"].ToString();
                    xfclass_others.Text = dtztcode.Rows[0]["xfclass"].ToString();
                    xtclass_others.Text = dtztcode.Rows[0]["xtclass"].ToString();
                    xffdate_others.Text = Convert.ToDateTime(dtztcode.Rows[0]["xffdate"]).ToString("dd/MM/yyyy");
                    xtdate_others.Text = Convert.ToDateTime(dtztcode.Rows[0]["xtdate"]).ToString("dd/MM/yyyy");
                    xfdate_others.Text = Convert.ToDateTime(dtztcode.Rows[0]["xfdate"]).ToString("dd/MM/yyyy");
                    xconvenor_others.Text = zglobal.fnGetValue("xname", "hrmst", "zid=" + _zid + " and xemp='" + dtztcode.Rows[0]["xconvenor"].ToString() + "'");
                    _convenor_other.Value = dtztcode.Rows[0]["xconvenor"].ToString();
                    xresultdate_others.Text = Convert.ToDateTime(dtztcode.Rows[0]["xresultdate"]).ToString("dd/MM/yyyy");
                    xprogdetail_others.InnerHtml = dtztcode.Rows[0]["xprogdetail"].ToString();
                    cpother_value.Text = dtztcode.Rows[0]["xcolor"].Equals(DBNull.Value) == true ? "FFFFFF" : dtztcode.Rows[0]["xcolor"].ToString();
                }


                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                _row.Value = ((LinkButton)sender).Text;
                message.InnerHtml = "";

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {


            if (ViewState["ctladded"] == null)
            {
                ViewState["ctladded"] = 1;
            }

            ViewState["ctladded"] = 1 + (int)ViewState["ctladded"];



            fnCreateControl((int)ViewState["ctladded"]);

        }

        protected void fnCreateDynamicControlAtPageLoad()
        {
            if (ViewState["ctladded"] != null)
            {
                int howMany = (int)ViewState["ctladded"];
                for (int i = 1; i <= howMany; i++)
                {
                    fnCreateControl(i);
                }
            }
        }
        private void fnCreateControl(int k)
        {
            try
            {

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                HtmlGenericControl div11 = new HtmlGenericControl("div");
                HtmlGenericControl div12 = new HtmlGenericControl("div");
                HtmlGenericControl div13 = new HtmlGenericControl("div");
                HtmlGenericControl div14 = new HtmlGenericControl("div");
                HtmlGenericControl div15 = new HtmlGenericControl("div");
                HtmlGenericControl div16 = new HtmlGenericControl("div");
                HtmlGenericControl div2 = new HtmlGenericControl("div");

                div1.Attributes["class"] = "_ctl_container";
                div11.Attributes["class"] = "bm_ctl_container_dynamic_100_80_nl";
                div12.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div13.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div14.Attributes["class"] = "bm_ctl_container_dynamic_100_80_nl";
                div15.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div16.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div2.Attributes["class"] = "bm_clt_padding";


                placeholder.Controls.Add(div1);
                div1.Controls.Add(div11);
                div1.Controls.Add(div12);
                div1.Controls.Add(div13);
                div1.Controls.Add(div14);
                div1.Controls.Add(div15);
                div1.Controls.Add(div16);
                placeholder.Controls.Add(div2);


                Label mylbl = new Label();
                Label mylbl1 = new Label();
                TextBox mytxt = new TextBox();
                DropDownList mydwf = new DropDownList();
                DropDownList mydwt = new DropDownList();
                TextBox mydtp = new TextBox();

                mytxt.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                mylbl.CssClass = "label";
                mylbl1.CssClass = "label";
                mydwf.CssClass = "bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown";
                mydwt.CssClass = "bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown";
                mydtp.CssClass = "bm_academic_datepicker_dynamic_100_80 bm_academic_ctl_global bm_academic_datepicker";



                mylbl.Text = k.ToString() + ".";


                mylbl1.Text = "to";


                zglobal.fnGetComboDataCD("Class", mydwf);


                zglobal.fnGetComboDataCD("Class", mydwt);


                mylbl.ID = "mylbl" + k.ToString();
                mydwf.ID = "mydwf" + k.ToString();
                mydwt.ID = "mydwt" + k.ToString();
                mytxt.ID = "mytxt" + k.ToString();
                mydtp.ID = "mydtp" + k.ToString();

                mylbl.EnableViewState = true;
                mydwf.EnableViewState = true;
                mydwt.EnableViewState = true;
                mytxt.EnableViewState = true;
                mydtp.EnableViewState = true;

                div11.Controls.Add(mylbl);
                div12.Controls.Add(mytxt);
                div13.Controls.Add(mydwf);
                div14.Controls.Add(mylbl1);
                div15.Controls.Add(mydwt);
                div16.Controls.Add(mydtp);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                _row.Value = "";
                //type.Value = "";
                _gridrow.Text = zglobal._grid_row_value;
                grid_xsession.Text = "";
                grid_xlocation.Text = "";
                btnSave.Enabled = true;
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    _grid_header.InnerHtml = "Days Observations :";
                    fnGridVisibleProp("_grid_day_o");
                    _grid_day_o.DataSource = null;
                    _grid_day_o.DataBind();
                    getActiveTabIndex.Value = "0";
                    type.Value = "day_o";
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    _grid_header.InnerHtml = "Outings / Duke";
                    fnGridVisibleProp("_grid_out");
                    _grid_out.DataSource = null;
                    _grid_out.DataBind();
                    getActiveTabIndex.Value = "1";
                    type.Value = "out";
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    _grid_header.InnerHtml = "Sports / Coaching";
                    fnGridVisibleProp("_grid_sport");
                    _grid_sport.DataSource = null;
                    _grid_sport.DataBind();
                    getActiveTabIndex.Value = "2";
                    type.Value = "sport";
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    _grid_header.InnerHtml = "Exam / Test";
                    fnGridVisibleProp("_grid_exam");
                    _grid_exam.DataSource = null;
                    _grid_exam.DataBind();
                    getActiveTabIndex.Value = "3";
                    type.Value = "exam";
                }
                else if (TabContainer1.ActiveTabIndex == 4)
                {
                    _grid_header.InnerHtml = "Others";
                    fnGridVisibleProp("_grid_other");
                    _grid_other.DataSource = null;
                    _grid_other.DataBind();
                    getActiveTabIndex.Value = "4";
                    type.Value = "others";
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid;
                string xkey = "";
                string xtype = "";
                message.InnerHtml = "";
                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    if (xsession_day_o.Text == "" || xsession_day_o.Text == string.Empty || xsession_day_o.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xprogramme_day_o.Text == "" || xprogramme_day_o.Text == string.Empty || xprogramme_day_o.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                        isValid = false;
                    }
                    if (xlocation_day_o.Text == "" || xlocation_day_o.Text == string.Empty || xlocation_day_o.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                        isValid = false;
                    }
                    if (xdate_day_o.Text == "" || xdate_day_o.Text == string.Empty || xdate_day_o.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Observation Date</li>";
                        isValid = false;
                    }
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    if (xsession_out.Text == "" || xsession_out.Text == string.Empty || xsession_out.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xprogramme_out.Text == "" || xprogramme_out.Text == string.Empty || xprogramme_out.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                        isValid = false;
                    }
                    if (xlocation_out.Text == "" || xlocation_out.Text == string.Empty || xlocation_out.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                        isValid = false;
                    }
                    if (xdate_out.Text == "" || xdate_out.Text == string.Empty || xdate_out.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Observation Date</li>";
                        isValid = false;
                    }
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    if (xsession_sport.Text == "" || xsession_sport.Text == string.Empty || xsession_sport.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xprogramme_sport.Text == "" || xprogramme_sport.Text == string.Empty || xprogramme_sport.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                        isValid = false;
                    }
                    if (xlocation_sport.Text == "" || xlocation_sport.Text == string.Empty || xlocation_sport.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                        isValid = false;
                    }
                    if (xdate_sport.Text == "" || xdate_sport.Text == string.Empty || xdate_sport.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Observation Date</li>";
                        isValid = false;
                    }
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    if (xsession_exam.Text == "" || xsession_exam.Text == string.Empty || xsession_exam.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xlocation_exam.Text == "" || xlocation_exam.Text == string.Empty || xlocation_exam.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>School</li>";
                        isValid = false;
                    }
                    if (xdate_exam.Text == "" || xdate_exam.Text == string.Empty || xdate_exam.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>End of Mid Term</li>";
                        isValid = false;
                    }
                    if (xexam_exam.Text == "" || xexam_exam.Text == string.Empty || xexam_exam.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Name of The Exam</li>";
                        isValid = false;
                    }
                    if (xclass_exam.Text == "" || xclass_exam.Text == string.Empty || xclass_exam.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Class </li>";
                        isValid = false;
                    }
                }
                else if (TabContainer1.ActiveTabIndex == 4)
                {
                    if (xsession_others.Text == "" || xsession_others.Text == string.Empty || xsession_others.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Session</li>";
                        isValid = false;
                    }
                    if (xlocation_others.Text == "" || xlocation_others.Text == string.Empty || xlocation_others.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>School</li>";
                        isValid = false;
                    }
                    if (xname_others.Text == "" || xname_others.Text == string.Empty || xname_others.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Name of The Event</li>";
                        isValid = false;
                    }
                }
                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        DateTime ztime = DateTime.Now;
                        DateTime zutime = DateTime.Now;
                        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        int xrow = 0;

                        string xsession = "";
                        string xprogram = "";
                        string xlocation = "";
                        DateTime xdate = DateTime.Now;
                        DateTime xfdate = DateTime.Now;
                        DateTime xffdate = DateTime.Now;
                        DateTime xtdate = DateTime.Now;
                        string xfclass = "";
                        string xtclass = "";
                        string xconvenor = "";
                        string xcoconvenor = "";
                        string xallconvenor = "";
                        string xprogdetail = "";
                        string xvenue = "";
                        DateTime xfinaldate = DateTime.Now;
                        DateTime xresultdate = DateTime.Now;
                        string xexam = "";
                        string xname = "";
                        string xcalendertype = zglobal.calendertype;
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xcolor = "FFFFFF";

                        string query = "";
                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xprogram,xlocation,xdate,xfdate,xconvenor,xcoconvenor,xprogdetail,xcalendertype,zemail,xcolor) " +
                                    "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xprogram,@xlocation,@xdate,@xfdate,@xconvenor,@xcoconvenor,@xprogdetail,@xcalendertype,@zemail,@xcolor) ";
                            xtype = "day_o";
                            xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            xkey = xrow.ToString();
                            xsession = xsession_day_o.Text.Trim().ToString();
                            xprogram = xprogramme_day_o.Text.Trim().ToString();
                            xlocation = xlocation_day_o.Text.Trim().ToString();
                            xdate = xdate_day_o.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_day_o.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xfdate = xfdate_day_o.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_day_o.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xconvenor = _convenor_day.Value != null && _convenor_day.Value != "" ?_convenor_day.Value.ToString( ):"";
                            xcoconvenor = _coconvenor_day.Value != null && _coconvenor_day.Value != "" ? _coconvenor_day.Value.ToString() : "";
                            xprogdetail = xprogdetail_day_o.InnerText.Trim().ToString();
                            if (cpday_value.Text != "" && cpday_value.Text != string.Empty)
                            {
                                xcolor = cpday_value.Text.ToString().Trim();
                            }

                        }
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xprogram,xlocation,xdate,xfdate,xallconvenor,xcoconvenor,xprogdetail,xfclass,xtclass,xffdate,xtdate,xvenue,xconvenor,xcalendertype,zemail,xcolor) " +
                                    "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xprogram,@xlocation,@xdate,@xfdate,@xallconvenor,@xcoconvenor,@xprogdetail,@xfclass,@xtclass,@xffdate,@xtdate,@xvenue,@xconvenor,@xcalendertype,@zemail,@xcolor) ";
                            xtype = "out";
                            xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            xkey = xrow.ToString();
                            xsession = xsession_out.Text.Trim().ToString();
                            xprogram = xprogramme_out.Text.Trim().ToString();
                            xlocation = xlocation_out.Text.Trim().ToString();
                            xdate = xdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xfdate = xfdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xallconvenor = _allconvenor_out.Value != null && _allconvenor_out.Value != "" ? _allconvenor_out.Value.ToString() : "";
                            xcoconvenor = _coconvenor_out.Value != null && _coconvenor_out.Value != "" ? _coconvenor_out.Value.ToString() : "";
                            xprogdetail = xprogdetail_out.InnerText.Trim().ToString();
                            xfclass = xfclass_out.Text.Trim().ToString();
                            xtclass = xtclass_out.Text.Trim().ToString();
                            xffdate = xffdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xtdate = xtdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xvenue = xvenue_out.Text.Trim().ToString();
                            xconvenor = _convenor_out.Value != null && _convenor_out.Value != "" ? _convenor_out.Value.ToString() : "";
                            if (cpout_value.Text != "" && cpout_value.Text != String.Empty)
                            {
                                xcolor = cpout_value.Text.Trim().ToString();
                            }
                        }
                        else if (TabContainer1.ActiveTabIndex == 2)
                        {
                            query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xprogram,xlocation,xdate,xfdate,xallconvenor,xcoconvenor,xprogdetail,xfclass,xtclass,xffdate,xtdate,xfinaldate,xcalendertype,zemail,xcolor) " +
                                    "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xprogram,@xlocation,@xdate,@xfdate,@xallconvenor,@xcoconvenor,@xprogdetail,@xfclass,@xtclass,@xffdate,@xtdate,@xfinaldate,@xcalendertype,@zemail,@xcolor) ";
                            xtype = "sport";
                            xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            xkey = xrow.ToString();
                            xsession = xsession_sport.Text.Trim().ToString();
                            xprogram = xprogramme_sport.Text.Trim().ToString();
                            xlocation = xlocation_sport.Text.Trim().ToString();
                            xdate = xdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xfdate = xfdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xallconvenor = _allconvenor_sport.Value != null && _allconvenor_sport.Value != "" ? _allconvenor_sport.Value.ToString() : "";
                            xcoconvenor = _coconvenor_sport.Value != null && _coconvenor_sport.Value != "" ? _coconvenor_sport.Value.ToString() : "";
                            xprogdetail = xprogdetail_sport.InnerText.Trim().ToString();
                            xfclass = xfclass_sport.Text.Trim().ToString();
                            xtclass = xtclass_sport.Text.Trim().ToString();
                            xffdate = xffdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xtdate = xtdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xfinaldate = xfinaldate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfinaldate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            if (cpsport_value.Text != "" && cpsport_value.Text != String.Empty)
                            {
                                xcolor = cpsport_value.Text.Trim().ToString();
                            }
                        }
                        else if (TabContainer1.ActiveTabIndex == 3)
                        {
                            query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xlocation,xdate,xprogram,xfclass,xfdate,xtdate,xffdate,xresultdate,xconvenor,xprogdetail,xcalendertype,zemail,xcolor) " +
                                    "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xlocation,@xdate,@xprogram,@xfclass,@xfdate,@xtdate,@xffdate,@xresultdate,@xconvenor,@xprogdetail,@xcalendertype,@zemail,@xcolor) ";
                            xtype = "exam";
                            xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            xkey = xrow.ToString();
                            xsession = xsession_exam.Text.Trim().ToString();
                            xlocation = xlocation_exam.Text.Trim().ToString();
                            xdate = xdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xprogram = xexam_exam.Text.Trim().ToString();
                            xfclass = xclass_exam.Text.Trim().ToString();
                            xfdate = xfdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xtdate = xtdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xffdate = xsubmission_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xsubmission_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xresultdate = xresultdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                            xconvenor = _convenor_exam.Value != null && _convenor_exam.Value != "" ? _convenor_exam.Value.ToString() : "";
                            xprogdetail = xprogdetail_exam.InnerText.Trim().ToString();
                            if (cpexam_value.Text != "" && cpexam_value.Text != String.Empty)
                            {
                                xcolor = cpexam_value.Text.Trim().ToString();
                            }
                        }
                        else if (TabContainer1.ActiveTabIndex == 4)
                        {
                            query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xlocation,xprogram,xfclass,xtclass,xffdate,xtdate,xfdate,xconvenor,xresultdate,xprogdetail,xcalendertype,zemail,xcolor) " +
                                    "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xlocation,@xprogram,@xfclass,@xtclass,@xffdate,@xtdate,@xfdate,@xconvenor,@xresultdate,@xprogdetail,@xcalendertype,@zemail,@xcolor) ";
                            xtype = "others";
                            xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            xkey = xrow.ToString();
                            xsession = xsession_others.Text.Trim().ToString();
                            xlocation = xlocation_others.Text.Trim().ToString();
                            xprogram = xname_others.Text.Trim().ToString();
                            xfclass = xfclass_others.Text.Trim().ToString();
                            xtclass = xtclass_others.Text.Trim().ToString();
                            xfdate = xfdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xtdate = xtdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xffdate = xffdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xresultdate = xresultdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xconvenor = _convenor_other.Value != null && _convenor_other.Value != "" ? _convenor_other.Value.ToString() : "";
                            xprogdetail = xprogdetail_others.InnerText.Trim().ToString();
                            if (cpother_value.Text != "" && cpother_value.Text != String.Empty)
                            {
                                xcolor = cpother_value.Text.Trim().ToString();
                            }
                        }



                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xsession", xsession);
                        cmd.Parameters.AddWithValue("@xprogram", xprogram);
                        cmd.Parameters.AddWithValue("@xlocation", xlocation);
                        cmd.Parameters.AddWithValue("@xdate", xdate);
                        cmd.Parameters.AddWithValue("@xfdate", xfdate);
                        cmd.Parameters.AddWithValue("@xffdate", xffdate);
                        cmd.Parameters.AddWithValue("@xtdate", xtdate);
                        cmd.Parameters.AddWithValue("@xfclass", xfclass);
                        cmd.Parameters.AddWithValue("@xtclass", xtclass);
                        cmd.Parameters.AddWithValue("@xconvenor", xconvenor);
                        cmd.Parameters.AddWithValue("@xcoconvenor", xcoconvenor);
                        cmd.Parameters.AddWithValue("@xallconvenor", xallconvenor);
                        cmd.Parameters.AddWithValue("@xprogdetail", xprogdetail);
                        cmd.Parameters.AddWithValue("@xvenue", xvenue);
                        cmd.Parameters.AddWithValue("@xfinaldate", xfinaldate);
                        cmd.Parameters.AddWithValue("@xresultdate", xresultdate);
                        cmd.Parameters.AddWithValue("@xexam", xexam);
                        cmd.Parameters.AddWithValue("@xname", xname);
                        cmd.Parameters.AddWithValue("@xcalendertype", xcalendertype);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xemail", xemail);
                        cmd.Parameters.AddWithValue("@xcolor", xcolor);
                        cmd.ExecuteNonQuery();



                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            if (ViewState["ctladded"] != null)
                            {
                                query = "DELETE FROM mscalenderevn WHERE zid=@zid and xtype=@xtype and xrow=@xrow";
                                cmd.Parameters.Clear();
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xtype", xtype);
                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                cmd.ExecuteNonQuery();

                                for (int i = 1; i <= (int)ViewState["ctladded"]; i++)
                                {
                                    cmd.Parameters.Clear();
                                    int xline = zglobal.GetMaximumIdInt("xline", "mscalenderevn", " zid=" + _zid + " and xtype='" + xtype + "' and xrow=" + xrow, "line");
                                    string xname_evn = ((TextBox)placeholder.FindControl("mytxt" + i)).Text.ToString().Trim();
                                    string xfclass_evn = ((DropDownList)placeholder.FindControl("mydwf" + i)).SelectedItem.Text.ToString();
                                    string xtclass_evn = ((DropDownList)placeholder.FindControl("mydwt" + i)).SelectedItem.Text.ToString();
                                    DateTime xdate_evn = ((TextBox)placeholder.FindControl("mydtp" + i)).Text.ToString().Trim() != string.Empty ? DateTime.ParseExact(((TextBox)placeholder.FindControl("mydtp" + i)).Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    query = "INSERT INTO mscalenderevn (zid,xtype,xrow,xline,xname,xfclass,xtclass,xdate) " +
                                        "VALUES(@zid,@xtype,@xrow,@xline,@xname,@xfclass,@xtclass,@xdate) ";
                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xtype", xtype);
                                    cmd.Parameters.AddWithValue("@xrow", xrow);
                                    cmd.Parameters.AddWithValue("@xline", xline);
                                    cmd.Parameters.AddWithValue("@xname", xname_evn);
                                    cmd.Parameters.AddWithValue("@xfclass", xfclass_evn);
                                    cmd.Parameters.AddWithValue("@xtclass", xtclass_evn);
                                    cmd.Parameters.AddWithValue("@xdate", xdate_evn);
                                    if (xname_evn != "" || xname_evn != string.Empty)
                                    {
                                        cmd.ExecuteNonQuery();
                                    }

                                }
                            }

                        }



                        //Insert into zreclog
                        //zglobal.fnRecordLog(xrow.ToString(), "Save", "eventinfo", xtype, "", 0, xdate);


                    }

                    //fnFillDataGrid();
                    //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();


                }
                btnSave.Enabled = false;
                message.InnerHtml = zglobal.insertsuccmsg;
                message.Style.Value = zglobal.successmsg;
                _row.Value = xkey;
                type.Value = xtype;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
            int _zid;
            string xkey = "";
            string xtype = "";
            message.InnerHtml = "";
            bool isValid = true;
            string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
            if (TabContainer1.ActiveTabIndex == 0)
            {
                if (xsession_day_o.Text == "" || xsession_day_o.Text == string.Empty || xsession_day_o.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xprogramme_day_o.Text == "" || xprogramme_day_o.Text == string.Empty || xprogramme_day_o.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    isValid = false;
                }
                if (xlocation_day_o.Text == "" || xlocation_day_o.Text == string.Empty || xlocation_day_o.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    isValid = false;
                }
                if (xdate_day_o.Text == "" || xdate_day_o.Text == string.Empty || xdate_day_o.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    isValid = false;
                }
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                if (xsession_out.Text == "" || xsession_out.Text == string.Empty || xsession_out.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xprogramme_out.Text == "" || xprogramme_out.Text == string.Empty || xprogramme_out.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    isValid = false;
                }
                if (xlocation_out.Text == "" || xlocation_out.Text == string.Empty || xlocation_out.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    isValid = false;
                }
                if (xdate_out.Text == "" || xdate_out.Text == string.Empty || xdate_out.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    isValid = false;
                }
            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
                if (xsession_sport.Text == "" || xsession_sport.Text == string.Empty || xsession_sport.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xprogramme_sport.Text == "" || xprogramme_sport.Text == string.Empty || xprogramme_sport.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    isValid = false;
                }
                if (xlocation_sport.Text == "" || xlocation_sport.Text == string.Empty || xlocation_sport.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    isValid = false;
                }
                if (xdate_sport.Text == "" || xdate_sport.Text == string.Empty || xdate_sport.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    isValid = false;
                }
            }
            else if (TabContainer1.ActiveTabIndex == 3)
            {
                if (xsession_exam.Text == "" || xsession_exam.Text == string.Empty || xsession_exam.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xlocation_exam.Text == "" || xlocation_exam.Text == string.Empty || xlocation_exam.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>School</li>";
                    isValid = false;
                }
                if (xdate_exam.Text == "" || xdate_exam.Text == string.Empty || xdate_exam.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>End of Mid Term</li>";
                    isValid = false;
                }
                if (xexam_exam.Text == "" || xexam_exam.Text == string.Empty || xexam_exam.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Name of The Exam</li>";
                    isValid = false;
                }
                if (xclass_exam.Text == "" || xclass_exam.Text == string.Empty || xclass_exam.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Class </li>";
                    isValid = false;
                }
            }
            else if (TabContainer1.ActiveTabIndex == 4)
            {
                if (xsession_others.Text == "" || xsession_others.Text == string.Empty || xsession_others.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xlocation_others.Text == "" || xlocation_others.Text == string.Empty || xlocation_others.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>School</li>";
                    isValid = false;
                }
                if (xname_others.Text == "" || xname_others.Text == string.Empty || xname_others.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Name of The Event</li>";
                    isValid = false;
                }
            }
            rtnMessage = rtnMessage + "</ol></div>";
            if (!isValid)
            {
                message.InnerHtml = rtnMessage;
                message.Style.Value = zglobal.warningmsg;
                return;
            }

            using (TransactionScope tran = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    DateTime ztime = DateTime.Now;
                    DateTime zutime = DateTime.Now;
                    _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    int xrow = 0;

                    string xsession = "";
                    string xprogram = "";
                    string xlocation = "";
                    DateTime xdate = DateTime.Now;
                    DateTime xfdate = DateTime.Now;
                    DateTime xffdate = DateTime.Now;
                    DateTime xtdate = DateTime.Now;
                    string xfclass = "";
                    string xtclass = "";
                    string xconvenor = "";
                    string xcoconvenor = "";
                    string xallconvenor = "";
                    string xprogdetail = "";
                    string xvenue = "";
                    DateTime xfinaldate = DateTime.Now;
                    DateTime xresultdate = DateTime.Now;
                    string xexam = "";
                    string xname = "";
                    string xcalendertype = zglobal.calendertype;
                    string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xcolor = "FFFFFF";

                    string query = "";
                    if (TabContainer1.ActiveTabIndex == 0)
                    {
                        query = "UPDATE mscalender SET zutime=@zutime, xsession=@xsession, xprogram=@xprogram, xlocation=@xlocation, xdate=@xdate, xfdate=@xfdate, xconvenor=@xconvenor, xcoconvenor=@xcoconvenor, xprogdetail=@xprogdetail, xcalendertype=@xcalendertype, xemail=@xemail, xcolor=@xcolor  " +
                                "WHERE zid=@zid AND xtype=@xtype AND xrow=@xrow ";
                        xtype = "day_o";
                        xrow = Convert.ToInt32(_row.Value != "" ? _row.Value : "0");
                        xsession = xsession_day_o.Text.Trim().ToString();
                        xprogram = xprogramme_day_o.Text.Trim().ToString();
                        xlocation = xlocation_day_o.Text.Trim().ToString();
                        xdate = xdate_day_o.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_day_o.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xfdate = xfdate_day_o.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_day_o.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xconvenor = _convenor_day.Value != null && _convenor_day.Value != "" ? _convenor_day.Value.ToString() : "";
                        xcoconvenor = _coconvenor_day.Value != null && _coconvenor_day.Value != "" ? _coconvenor_day.Value.ToString() : "";
                        xprogdetail = xprogdetail_day_o.InnerText.Trim().ToString();
                        if (cpday_value.Text != "" && cpday_value.Text != String.Empty)
                        {
                            xcolor = cpday_value.Text.Trim().ToString();
                        }
                        //Response.Write("<h1>" + _colorvalue.Value + " test</h1>");
                    }
                    else if (TabContainer1.ActiveTabIndex == 1)
                    {
                        query = "UPDATE mscalender SET zutime=@zutime,xsession=@xsession,xprogram=@xprogram,xlocation=@xlocation,xdate=@xdate,xfdate=@xfdate,xallconvenor=@xallconvenor,xcoconvenor=@xcoconvenor,xprogdetail=@xprogdetail,xfclass=@xfclass,xtclass=@xtclass,xffdate=@xffdate,xtdate=@xtdate,xvenue=@xvenue,xconvenor=@xconvenor,xcalendertype=@xcalendertype,xemail=@xemail, xcolor=@xcolor " +
                                "WHERE zid=@zid AND xtype=@xtype AND xrow=@xrow ";
                        xtype = "out";
                        xrow = Convert.ToInt32(_row.Value != "" ? _row.Value : "0");
                        xsession = xsession_out.Text.Trim().ToString();
                        xprogram = xprogramme_out.Text.Trim().ToString();
                        xlocation = xlocation_out.Text.Trim().ToString();
                        xdate = xdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xfdate = xfdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xallconvenor = _allconvenor_out.Value != null && _allconvenor_out.Value != "" ? _allconvenor_out.Value.ToString() : "";
                        xcoconvenor = _coconvenor_out.Value != null && _coconvenor_out.Value != "" ? _coconvenor_out.Value.ToString() : "";
                        xprogdetail = xprogdetail_out.InnerText.Trim().ToString();
                        xfclass = xfclass_out.Text.Trim().ToString();
                        xtclass = xtclass_out.Text.Trim().ToString();
                        xffdate = xffdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xtdate = xtdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xvenue = xvenue_out.Text.Trim().ToString();
                        xconvenor = _convenor_out.Value != null && _convenor_out.Value != "" ? _convenor_out.Value.ToString() : "";
                        if (cpout_value.Text != "" && cpout_value.Text != String.Empty)
                        {
                            xcolor = cpout_value.Text.Trim().ToString();
                        }
                    }
                    else if (TabContainer1.ActiveTabIndex == 2)
                    {
                        query = "UPDATE mscalender SET zutime=@zutime,xsession=@xsession,xprogram=@xprogram,xlocation=@xlocation,xdate=@xdate,xfdate=@xfdate,xallconvenor=@xallconvenor,xcoconvenor=@xcoconvenor,xprogdetail=@xprogdetail,xfclass=@xfclass,xtclass=@xtclass,xffdate=@xffdate,xtdate=@xtdate,xfinaldate=@xfinaldate,xcalendertype=@xcalendertype,xemail=@xemail,xcolor=@xcolor " +
                                "WHERE zid=@zid AND xtype=@xtype AND xrow=@xrow ";
                        xtype = "sport";
                        xrow = Convert.ToInt32(_row.Value != "" ? _row.Value : "0");
                        xsession = xsession_sport.Text.Trim().ToString();
                        xprogram = xprogramme_sport.Text.Trim().ToString();
                        xlocation = xlocation_sport.Text.Trim().ToString();
                        xdate = xdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xfdate = xfdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xallconvenor = _allconvenor_sport.Value != null && _allconvenor_sport.Value != "" ? _allconvenor_sport.Value.ToString() : "";
                        xcoconvenor = _coconvenor_sport.Value != null && _coconvenor_sport.Value != "" ? _coconvenor_sport.Value.ToString() : "";
                        xprogdetail = xprogdetail_sport.InnerText.Trim().ToString();
                        xfclass = xfclass_sport.Text.Trim().ToString();
                        xtclass = xtclass_sport.Text.Trim().ToString();
                        xffdate = xffdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xtdate = xtdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xfinaldate = xfinaldate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfinaldate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        if (cpsport_value.Text != "" && cpsport_value.Text != String.Empty)
                        {
                            xcolor = cpsport_value.Text.Trim().ToString();
                        }
                    }
                    else if (TabContainer1.ActiveTabIndex == 3)
                    {
                        query = "UPDATE mscalender SET zutime=@zutime,xsession=@xsession,xlocation=@xlocation,xdate=@xdate,xprogram=@xprogram,xfclass=@xfclass,xfdate=@xfdate,xtdate=@xtdate,xffdate=@xffdate,xresultdate=@xresultdate,xconvenor=@xconvenor,xprogdetail=@xprogdetail,xcalendertype=@xcalendertype,xemail=@xemail,xcolor=@xcolor " +
                                "WHERE zid=@zid AND xtype=@xtype AND xrow=@xrow ";
                        xtype = "exam";
                        xrow = Convert.ToInt32(_row.Value != "" ? _row.Value : "0");
                        xsession = xsession_exam.Text.Trim().ToString();
                        xlocation = xlocation_exam.Text.Trim().ToString();
                        xdate = xdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xprogram = xexam_exam.Text.Trim().ToString();
                        xfclass = xclass_exam.Text.Trim().ToString();
                        xfdate = xfdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xtdate = xtdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xffdate = xsubmission_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xsubmission_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xresultdate = xresultdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                        xconvenor = _convenor_exam.Value != null && _convenor_exam.Value != "" ? _convenor_exam.Value.ToString() : "";
                        xprogdetail = xprogdetail_exam.InnerText.Trim().ToString();
                        if (cpexam_value.Text != "" && cpexam_value.Text != String.Empty)
                        {
                            xcolor = cpexam_value.Text.Trim().ToString();
                        }
                    }
                    else if (TabContainer1.ActiveTabIndex == 4)
                    {
                        query = "UPDATE mscalender SET zutime=@zutime,xsession=@xsession,xlocation=@xlocation,xprogram=@xprogram,xfclass=@xfclass,xtclass=@xtclass,xffdate=@xffdate,xtdate=@xtdate,xfdate=@xfdate,xconvenor=@xconvenor,xresultdate=@xresultdate,xprogdetail=@xprogdetail,xcalendertype=@xcalendertype,xemail=@xemail,xcolor=@xcolor " +
                                "WHERE zid=@zid AND xtype=@xtype AND xrow=@xrow ";
                        xtype = "others";
                        xrow = Convert.ToInt32(_row.Value != "" ? _row.Value : "0");
                        xsession = xsession_others.Text.Trim().ToString();
                        xlocation = xlocation_others.Text.Trim().ToString();
                        xprogram = xname_others.Text.Trim().ToString();
                        xfclass = xfclass_others.Text.Trim().ToString();
                        xtclass = xtclass_others.Text.Trim().ToString();
                        xfdate = xfdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xtdate = xtdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xffdate = xffdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xresultdate = xresultdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xconvenor = _convenor_other.Value != null && _convenor_other.Value != "" ? _convenor_other.Value.ToString() : "";
                        xprogdetail = xprogdetail_others.InnerText.Trim().ToString();
                        if (cpother_value.Text != "" && cpother_value.Text != String.Empty)
                        {
                            xcolor = cpother_value.Text.Trim().ToString();
                        }
                    }



                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@ztime", ztime);
                    cmd.Parameters.AddWithValue("@zutime", ztime);
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xtype", xtype);
                    cmd.Parameters.AddWithValue("@xrow", xrow);
                    cmd.Parameters.AddWithValue("@xsession", xsession);
                    cmd.Parameters.AddWithValue("@xprogram", xprogram);
                    cmd.Parameters.AddWithValue("@xlocation", xlocation);
                    cmd.Parameters.AddWithValue("@xdate", xdate);
                    cmd.Parameters.AddWithValue("@xfdate", xfdate);
                    cmd.Parameters.AddWithValue("@xffdate", xffdate);
                    cmd.Parameters.AddWithValue("@xtdate", xtdate);
                    cmd.Parameters.AddWithValue("@xfclass", xfclass);
                    cmd.Parameters.AddWithValue("@xtclass", xtclass);
                    cmd.Parameters.AddWithValue("@xconvenor", xconvenor);
                    cmd.Parameters.AddWithValue("@xcoconvenor", xcoconvenor);
                    cmd.Parameters.AddWithValue("@xallconvenor", xallconvenor);
                    cmd.Parameters.AddWithValue("@xprogdetail", xprogdetail);
                    cmd.Parameters.AddWithValue("@xvenue", xvenue);
                    cmd.Parameters.AddWithValue("@xfinaldate", xfinaldate);
                    cmd.Parameters.AddWithValue("@xresultdate", xresultdate);
                    cmd.Parameters.AddWithValue("@xexam", xexam);
                    cmd.Parameters.AddWithValue("@xname", xname);
                    cmd.Parameters.AddWithValue("@xcalendertype", xcalendertype);
                    cmd.Parameters.AddWithValue("@zemail", zemail);
                    cmd.Parameters.AddWithValue("@xemail", xemail);
                    cmd.Parameters.AddWithValue("@xcolor", xcolor);
                    cmd.ExecuteNonQuery();



                    if (TabContainer1.ActiveTabIndex == 0)
                    {
                        if (ViewState["ctladded"] != null)
                        {
                            query = "DELETE FROM mscalenderevn WHERE zid=@zid and xtype=@xtype and xrow=@xrow";
                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xtype", xtype);
                            cmd.Parameters.AddWithValue("@xrow", xrow);
                            cmd.ExecuteNonQuery();

                            for (int i = 1; i <= (int)ViewState["ctladded"]; i++)
                            {
                                cmd.Parameters.Clear();
                                int xline = zglobal.GetMaximumIdInt("xline", "mscalenderevn", " zid=" + _zid + " and xtype='" + xtype + "' and xrow=" + xrow, "line");
                                string xname_evn = ((TextBox)placeholder.FindControl("mytxt" + i)).Text.ToString().Trim();
                                string xfclass_evn = ((DropDownList)placeholder.FindControl("mydwf" + i)).SelectedItem.Text.ToString();
                                string xtclass_evn = ((DropDownList)placeholder.FindControl("mydwt" + i)).SelectedItem.Text.ToString();
                                DateTime xdate_evn = ((TextBox)placeholder.FindControl("mydtp" + i)).Text.ToString().Trim() != string.Empty ? DateTime.ParseExact(((TextBox)placeholder.FindControl("mydtp" + i)).Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                query = "INSERT INTO mscalenderevn (zid,xtype,xrow,xline,xname,xfclass,xtclass,xdate) " +
                                    "VALUES(@zid,@xtype,@xrow,@xline,@xname,@xfclass,@xtclass,@xdate) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xtype", xtype);
                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.Parameters.AddWithValue("@xname", xname_evn);
                                cmd.Parameters.AddWithValue("@xfclass", xfclass_evn);
                                cmd.Parameters.AddWithValue("@xtclass", xtclass_evn);
                                cmd.Parameters.AddWithValue("@xdate", xdate_evn);
                                if (xname_evn != "" || xname_evn != string.Empty)
                                {
                                    cmd.ExecuteNonQuery();
                                }

                            }
                        }

                    }



                    //Insert into zreclog
                    //zglobal.fnRecordLog(xrow.ToString(), "Edit", "eventinfo", xtype, "", 0, xdate);


                }

                //fnFillDataGrid();
                //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                tran.Complete();


            }
            message.InnerHtml = zglobal.updatesuccmsg;
            message.Style.Value = zglobal.successmsg;
            //_row.Value = xkey;
            //type.Value = xtype;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }




    }
}