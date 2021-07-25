using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.admission
{
    public partial class teacher_old : System.Web.UI.Page
    {
        

        private void fnGridVisibleProp(string _grid)
        {

            if (_grid == _grid_teacherinfo_breakup.ID)
            {
                _grid_teacherinfo_breakup.Visible = true;
               // _grid_hidden.Visible = true;
            }
            else
            {
                _grid_teacherinfo_breakup.Visible = false;
               // _grid_hidden.Visible = false;
            }

            if (_grid == _grid_education.ID)
            {
                _grid_education.Visible = true;
            }
            else
            {
                _grid_education.Visible = false;
            }

            //if (_grid == _grid_exam.ID)
            //{
            //    _grid_exam.Visible = true;
            //}
            //else
            //{
            //    _grid_exam.Visible = false;
            //}

            //if (_grid == _grid_sport.ID)
            //{
            //    _grid_sport.Visible = true;
            //}
            //else
            //{
            //    _grid_sport.Visible = false;
            //}

            //if (_grid == _grid_other.ID)
            //{
            //    _grid_other.Visible = true;
            //}
            //else
            //{
            //    _grid_other.Visible = false;
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    TabContainer1.ActiveTabIndex = 0;
                    getActiveTabIndex.Value = "0";
                    fnGridVisibleProp("_grid_teacherinfo_breakup");
                    //_row.Value = "";
                    type.Value = "teacherinfo";
                    _gridrow.Text = zglobal._grid_row_value;
                    //_gridrow_h.Text = zglobal._grid_row_value;
                    xpoint_s.Enabled = false;
                    zglobal.fnGetComboDataCD("Nationality", xnationality);
                    zglobal.fnGetComboDataCD("Blood Group", xblood);
                    zglobal.fnGetComboDataCD("Sex", xsex);
                    zglobal.fnGetComboDataCD("Marital Status", xmstatus);
                    zglobal.fnGetComboDataCD("Religion", xreligion);
                    zglobal.fnGetComboDataCD("Name of Exam","school",xexamname,1);
                    zglobal.fnGetComboDataCD("Education System", xedusys);
                    zglobal.fnGetComboDataCD("Education Board", xboard);
                    zglobal.fnGetComboDataCD("Education Group", xedugroup);
                    zglobal.fnGetComboDataCD("Subject", xsubject);
                    zglobal.fnGetComboDataCD(xyear);
                    zglobal.fnGetComboDataCD(xyeargs);

                    xgpa_s.Items.Clear();
                    xgpa_s.Items.Add("");
                    xgpa_s.Items.Add("First Devision");
                    xgpa_s.Items.Add("Second Devision");
                    xgpa_s.Items.Add("Third Devision");
                    xgpa_s.Items.Add("GPA");
                    xgpa_s.Text = "";

                    xgpa_gs.Items.Clear();
                    xgpa_gs.Items.Add("");
                    xgpa_gs.Items.Add("First Class");
                    xgpa_gs.Items.Add("Second Class");
                    xgpa_gs.Items.Add("Third Class");
                    xgpa_gs.Items.Add("GPA");
                    xgpa_gs.Text = "";

                    xduration.Items.Clear();
                    xduration.Items.Add("");
                    xduration.Items.Add("2 Years");
                    xduration.Items.Add("3 Years");
                    xduration.Items.Add("4 Years");
                    xduration.Text = "";

                    xposition.Items.Clear();
                    xposition.Items.Add("");
                    for (int i = 1; i <= 20; i++)
                    {
                        if (i == 1)
                        {
                            xposition.Items.Add(i.ToString() + "st Position");
                        }
                        else if (i == 2)
                        {
                            xposition.Items.Add(i.ToString() + "nd Position");
                        }
                        else if (i == 3)
                        {
                            xposition.Items.Add(i.ToString() + "rd Position");
                        }
                        else
                        {
                            xposition.Items.Add(i.ToString() + "th Position");
                        }
                    }
                    xposition.Text = "";

                    ViewState["xemp"] = null;
                    _row.Value = null;
                    ViewState["xline"] = null;
                    fnFillDataGrid(null,null);
                    xpoints_divgs.Visible = false;
                    xpoints_div.Visible = false;
                    school.Visible = false;
                    graduateschool.Visible = false;
                    for (int i = 1; i < TabContainer1.Tabs.Count; i++)
                    {
                        TabContainer1.Tabs[i].Enabled = false;
                    }
                    Panel1.Enabled = false;
                    btnEdit.Visible = false;
                    btnSave.Visible = true;
                }
                catch (Exception exp)
                {
                    message.InnerHtml = exp.Message;
                }

            }

            if (ViewState["ctladded"] == null)
            {
                ViewState["ctladded"] = 1;
            }

            fnCreateDynamicControlAtPageLoad();

            if (ViewState["ctladded2"] == null)
            {
                ViewState["ctladded2"] = 1;
            }

            fnCreateDynamicControlAtPageLoad2();

        }

        public void fnSelSchoole(object sender, EventArgs e)
        {
            try
            {
                if (xexamname.SelectedValue == "")
                {
                    school.Visible = false;
                    graduateschool.Visible = false;
                    TabContainer1_ActiveTabChanged(sender,e);
                    return;
                }

                xorg.Text = "";
                xdist.Text = "";
                xedusys.Text = "";
                xboard.Text = "";
                xedugroup.Text = "";
                xyear.Text = "";
                xgpa_s.Text = "";
                xpoint_s.Text = "";
                xnumsub.Text = "";
                xnaa.Text = "";
                xna.Text = "";
                xnb.Text = "";
                xnc.Text = "";
                xunderorg.Text = "";
                xorggs.Text = "";
                xcountry.Text = "";
                xsubject.Text = "";
                xyeargs.Text = "";
                xgpa_gs.Text = "";
                xpoint_gs.Text = "";
                xduration.Text = "";
                xposition.Text = "";

                string[] val = xexamname.SelectedValue.Split('-');
                if (val[1] == "1")
                {
                    school.Visible = true;
                    graduateschool.Visible = false;
                }
                if (val[1] == "2")
                {
                    school.Visible = false;
                    graduateschool.Visible = true;
                }
                btnSave.Enabled = true;
                message.InnerHtml = "";
                ViewState["xline"] = null;
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnDivGPA_s(object sender, EventArgs e)
        {
            try
            {
                xpoint_s.Text = "";
                if (xgpa_s.Text.ToLower() == "gpa")
                {
                    xpoint_s.Enabled = true;
                    xpoints_div.Visible = true;
                }
                else
                {
                    xpoint_s.Enabled = false;
                    xpoints_div.Visible = false;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
        public void fnDivGPA_gs(object sender, EventArgs e)
        {
            try
            {
                xpoint_gs.Text = "";
                if (xgpa_gs.Text.ToLower() == "gpa")
                {
                    xpoint_gs.Enabled = true;
                    xpoints_divgs.Visible = true;
                }
                else
                {
                    xpoint_gs.Enabled = false;
                    xpoints_divgs.Visible = false;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnFillDataGrid(object sender, EventArgs e)
        {
            try
            {
                //if (grid_xsession.Text == "" || grid_xsession.Text == string.Empty || grid_xsession.Text == "[Select]")
                //{
                //    message.InnerHtml = "Please Select Session";
                //    return;
                //}
                //if (grid_xlocation.Text == "" || grid_xlocation.Text == string.Empty || grid_xlocation.Text == "[Select]")
                //{
                //    message.InnerHtml = "Please Select School";
                //    return;
                //}

                message.InnerHtml = "";
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                string str = "";
                dts.Reset();
                GridView grid = new GridView();
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xemp,xname,xcontact,xemail1,xblood FROM hrmst where zid=@zid  ORDER BY xemp ";
                    grid = _grid_teacherinfo_breakup;
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {

                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xline,xexamname,case when coalesce(xunderorg,'')='' then xorg else xunderorg end as xorg," +
                        "case when coalesce(xsubject,'')='' then xedugroup else xsubject end as xsubject,xyear," +
                        "case when coalesce(xresult,'')='GPA' then CAST(xgpa AS varchar(50)) else xresult end as xresult " + 
                        " FROM hredu where zid=@zid and xemp=@xemp  ORDER BY xline DESC";
                    grid = _grid_education;
                }
                //else if (TabContainer1.ActiveTabIndex == 2)
                //{
                //    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xdate,xfdate,xallconvenor,xcoconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                //    grid = _grid_sport;
                //}
                //else if (TabContainer1.ActiveTabIndex == 3)
                //{
                //    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xexam,xfclass,xfdate,xtdate,xresultdate,xconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                //    grid = _grid_exam;
                //}
                //else if (TabContainer1.ActiveTabIndex == 4)
                //{
                //    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xname,xfclass,xtclass,xffdate,xtdate,xresultdate,xconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                //    grid = _grid_other;
                //}

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xtype = type.Value;
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xemp", ViewState["xemp"] == null ? "-1" : ViewState["xemp"].ToString());
                da.Fill(dts, "tempztcode");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];
                grid.DataSource = dtztcode;
                grid.DataBind();





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

        protected void fnFilterByRow(object sender, EventArgs e)
        {
            //try
            //{
            //    fnFillDataGrid(sender, e);
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    for (int i = 1; i < TabContainer1.Tabs.Count; i++)
                    {
                        TabContainer1.Tabs[i].Enabled = true;
                    }
                    Panel1.Enabled = true;
                }
                //btnSave.Enabled = false;
                btnSave.Visible = false;
                btnEdit.Visible = true;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xtype = type.Value.ToString();
                string xemp1 = ((LinkButton)sender).Text;
                string str = "SELECT  * FROM hrmst where zid=@zid and xemp=@xemp  ";





                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    ViewState["xemp"] = ((LinkButton) sender).Text;
                    _row.Value = ViewState["xemp"].ToString();
                    xempd.Text = ViewState["xemp"].ToString();
                    xnamed.Text = dtztcode.Rows[0]["xname"].ToString();
                }

                if (TabContainer1.ActiveTabIndex == 0)
                {
                    xemp.Text = dtztcode.Rows[0]["xemp"].ToString();
                    xname.Text = dtztcode.Rows[0]["xname"].ToString();
                    xdob.Text = Convert.ToDateTime(dtztcode.Rows[0]["xdob"]).ToString("dd/MM/yyyy");
                    xnationality.Text = dtztcode.Rows[0]["xnationality"].ToString();
                    xnid.Text = dtztcode.Rows[0]["xnid"].ToString();
                    xblood.Text = dtztcode.Rows[0]["xblood"].ToString();
                    xsex.Text = dtztcode.Rows[0]["xsex"].ToString();
                    xfather.Text = dtztcode.Rows[0]["xfather"].ToString();
                    xmother.Text = dtztcode.Rows[0]["xmother"].ToString();
                    xnosibling.Text = dtztcode.Rows[0]["xnosibling"].ToString();
                    xreligion.Text = dtztcode.Rows[0]["xreligion"].ToString();
                    xpadd.Text = dtztcode.Rows[0]["xpadd"].ToString();
                    xperadd.Text = dtztcode.Rows[0]["xperadd"].ToString();
                    xcontact.Text = dtztcode.Rows[0]["xcontact"].ToString();
                    xecontact.Text = dtztcode.Rows[0]["xecontact"].ToString();
                    xemail1.Text = dtztcode.Rows[0]["xemail1"].ToString();
                    xmstatus.Text = dtztcode.Rows[0]["xmstatus"].ToString();
                    xmday.Text = Convert.ToDateTime(dtztcode.Rows[0]["xmday"]).ToString("dd/MM/yyyy");
                    ximage.ImageUrl = dtztcode.Rows[0]["xlink"].ToString();
                    xspouse.Text = dtztcode.Rows[0]["xspouse"].ToString();
                    xsocupation.Text = dtztcode.Rows[0]["xsocupation"].ToString();
                    xnochild.Text = dtztcode.Rows[0]["xnochild"].ToString();

                    ////////////////////////////////
                    dts.Reset();

                    str = "SELECT * FROM hrchild WHERE zid=@zid AND xemp=@xemp";

                    SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

                    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da2.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da2.Fill(dts, "temp");
                    DataTable dttemp = new DataTable();
                    dttemp = dts.Tables[0];
                    placeholder.Controls.Clear();
                    if (dttemp.Rows.Count > 0)
                    {

                        ViewState["ctladded"] = dttemp.Rows.Count;

                        //placeholder.Controls.Clear();

                        int howMany = (int)ViewState["ctladded"];
                        for (int i = 1; i <= howMany; i++)
                        {
                            fnCreateControl(i);
                            ((TextBox)placeholder.FindControl("mtxt1" + i)).Text =
                                dttemp.Rows[i - 1]["xname"].ToString();
                            ((TextBox)placeholder.FindControl("mtxt2" + i)).Text =
                               dttemp.Rows[i - 1]["xshcool"].ToString();
                            ((TextBox)placeholder.FindControl("mtxt3" + i)).Text =
                               dttemp.Rows[i - 1]["xclass"].ToString();
                        }
                    }
                    else
                    {
                        ViewState["ctladded"] = 1;
                        fnCreateDynamicControlAtPageLoad();
                    }
                    ///////////////////////////////////////
                    /// 
                    ///  ////////////////////////////////
                    ///
                    ///  
                    dts.Reset();

                    str = "SELECT * FROM hrtour WHERE zid=@zid AND xemp=@xemp";

                    SqlDataAdapter da3 = new SqlDataAdapter(str, conn1);

                    da3.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da3.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da3.Fill(dts, "temp");
                    DataTable dttemp1 = new DataTable();
                    dttemp1 = dts.Tables[0];
                    placeholder1.Controls.Clear();

                    if (dttemp1.Rows.Count > 0)
                    {

                        ViewState["ctladded2"] = dttemp1.Rows.Count;

                        //placeholder1.Controls.Clear();

                        int howMany = (int)ViewState["ctladded2"];
                        for (int i = 1; i <= howMany; i++)
                        {
                            fnCreateControl2(i);
                            ((TextBox)placeholder1.FindControl("mtxt12" + i)).Text =
                                dttemp1.Rows[i - 1]["xcountry"].ToString();
                            ((TextBox)placeholder1.FindControl("mtxt22" + i)).Text =
                               dttemp1.Rows[i - 1]["xyear"].ToString();
                        }
                    }
                    else
                    {
                        ViewState["ctladded2"] = 1;
                        fnCreateDynamicControlAtPageLoad2();
                    }

                    ///////////////////////////////////////
                    /// 
                    /// 
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {

                    str = "SELECT  * FROM hredu where zid=@zid and xemp=@xemp and xline=@xline ";
                    dts.Reset();
                    SqlDataAdapter da4 = new SqlDataAdapter(str, conn1);
                    da4.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da4.SelectCommand.Parameters.AddWithValue("@xemp", ViewState["xemp"]==null?"-1":ViewState["xemp"].ToString());
                    da4.SelectCommand.Parameters.AddWithValue("@xline", ((LinkButton)sender).Text); 
                    da4.Fill(dts, "tempztcode");
                    DataTable dtztcode4 = new DataTable();
                    dtztcode4 = dts.Tables[0];

                    xexamname.SelectedValue = dtztcode4.Rows[0]["xexamname"].ToString().Trim() + "-" + zglobal.fnProperty("Name of Exam", dtztcode4.Rows[0]["xexamname"].ToString().Trim(), "school");
                    xorg.Text = dtztcode4.Rows[0]["xorg"].ToString().Trim();
                    xdist.Text = dtztcode4.Rows[0]["xdist"].ToString().Trim();
                    xedusys.Text = dtztcode4.Rows[0]["xedusys"].ToString().Trim();
                    xboard.Text = dtztcode4.Rows[0]["xboard"].ToString().Trim();
                    xedugroup.Text = dtztcode4.Rows[0]["xedugroup"].ToString().Trim();
                    xyear.Text = dtztcode4.Rows[0]["xyear"].ToString().Trim();
                    xgpa_s.Text = dtztcode4.Rows[0]["xresult"].ToString().Trim();
                    xpoint_s.Text = dtztcode4.Rows[0]["xgpa"].ToString().Trim();
                    xnumsub.Text = dtztcode4.Rows[0]["xnumsub"].ToString().Trim();
                    xnaa.Text = dtztcode4.Rows[0]["xnaa"].ToString().Trim();
                    xna.Text = dtztcode4.Rows[0]["xna"].ToString().Trim();
                    xnb.Text = dtztcode4.Rows[0]["xnb"].ToString().Trim();
                    xnc.Text = dtztcode4.Rows[0]["xnc"].ToString().Trim();
                    xunderorg.Text = dtztcode4.Rows[0]["xunderorg"].ToString().Trim();
                    xcountry.Text = dtztcode4.Rows[0]["xcountry"].ToString().Trim();
                    xorggs.Text = dtztcode4.Rows[0]["xorg"].ToString().Trim();
                    xsubject.Text = dtztcode4.Rows[0]["xsubject"].ToString().Trim();
                    xyeargs.Text = dtztcode4.Rows[0]["xyear"].ToString().Trim();
                    xgpa_gs.Text = dtztcode4.Rows[0]["xresult"].ToString().Trim();
                    xpoint_gs.Text = dtztcode4.Rows[0]["xgpa"].ToString().Trim();
                    xduration.Text = dtztcode4.Rows[0]["xduration"].ToString().Trim();
                    xposition.Text = dtztcode4.Rows[0]["xposition"].ToString().Trim();

                    string value = zglobal.fnProperty("Name of Exam", dtztcode4.Rows[0]["xexamname"].ToString().Trim(), "school");

                    if (value == "1")
                    {
                        school.Visible = true;
                        graduateschool.Visible = false;
                    }
                    else if (value == "2")
                    {
                        school.Visible = false;
                        graduateschool.Visible = true;
                    }
                    ViewState["xline"] = ((LinkButton) sender).Text;
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                   
                }


                //ViewState["xemp"] = ((LinkButton)sender).Text;
                //xempd.Text = ViewState["xemp"].ToString();
                //xnamed.Text = dtztcode.Rows[0]["xname"].ToString();
                //_row.Value = ((LinkButton)sender).Text;
                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                
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

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["ctladded2"] == null)
            {
                ViewState["ctladded2"] = 1;
            }

            ViewState["ctladded2"] = 1 + (int)ViewState["ctladded2"];



            fnCreateControl2((int)ViewState["ctladded2"]);

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

        protected void fnCreateDynamicControlAtPageLoad2()
        {
            if (ViewState["ctladded2"] != null)
            {
                int howMany = (int)ViewState["ctladded2"];
                for (int i = 1; i <= howMany; i++)
                {
                    fnCreateControl2(i);
                }
            }
        }

        private void fnCreateControl(int k)
        {
            try
            {

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                HtmlGenericControl div2 = new HtmlGenericControl("div");
                HtmlGenericControl div3 = new HtmlGenericControl("div");
                HtmlGenericControl div4 = new HtmlGenericControl("div");
                HtmlGenericControl div5 = new HtmlGenericControl("div");

                div1.Attributes["class"] = "bm_ctl_container_dynamic_100_80_nl";
                div2.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div2.Attributes["style"] = "width: 200px";
                div3.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div3.Attributes["style"] = "width: 310px";
                div4.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div4.Attributes["style"] = "width: 110px";
                div5.Attributes["class"] = "bm_clt_padding";


                placeholder.Controls.Add(div1);
                placeholder.Controls.Add(div2);
                placeholder.Controls.Add(div3);
                placeholder.Controls.Add(div4);
                placeholder.Controls.Add(div5);


                Label mylbl = new Label();
                TextBox mtxt1 = new TextBox();
                TextBox mtxt2 = new TextBox();
                TextBox mtxt3 = new TextBox();


                mylbl.CssClass = "label";
                mtxt1.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                mtxt1.Attributes["style"] = "width: 196px";
                mtxt2.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                mtxt2.Attributes["style"] = "width: 306px";
                mtxt3.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                mtxt3.Attributes["style"] = "width: 106px";



                mylbl.Text = k.ToString() + ".";



                mylbl.ID = "mylbl" + k.ToString();
                mtxt1.ID = "mtxt1" + k.ToString();
                mtxt2.ID = "mtxt2" + k.ToString();
                mtxt3.ID = "mtxt3" + k.ToString();

                mylbl.EnableViewState = true;
                mtxt1.EnableViewState = true;
                mtxt2.EnableViewState = true;
                mtxt3.EnableViewState = true;

                div1.Controls.Add(mylbl);
                div2.Controls.Add(mtxt1);
                div3.Controls.Add(mtxt2);
                div4.Controls.Add(mtxt3);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        private void fnCreateControl2(int k)
        {
            try
            {

                HtmlGenericControl div12 = new HtmlGenericControl("div");
                HtmlGenericControl div22 = new HtmlGenericControl("div");
                HtmlGenericControl div32 = new HtmlGenericControl("div");
                HtmlGenericControl div42 = new HtmlGenericControl("div");

                div12.Attributes["class"] = "bm_ctl_container_dynamic_100_80_nl";
                div22.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div22.Attributes["style"] = "width: 320px";
                div32.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div32.Attributes["style"] = "width: 204px";
                div42.Attributes["class"] = "bm_clt_padding";


                placeholder1.Controls.Add(div12);
                placeholder1.Controls.Add(div22);
                placeholder1.Controls.Add(div32);
                placeholder1.Controls.Add(div42);


                Label mylbl2 = new Label();
                TextBox mtxt12 = new TextBox();
                TextBox mtxt22 = new TextBox();


                mylbl2.CssClass = "label";
                mtxt12.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                mtxt12.Attributes["style"] = "width: 316px";
                mtxt22.CssClass = "bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox";
                mtxt22.Attributes["style"] = "width: 200px";



                mylbl2.Text = k.ToString() + ".";



                mylbl2.ID = "mylbl2" + k.ToString();
                mtxt12.ID = "mtxt12" + k.ToString();
                mtxt22.ID = "mtxt22" + k.ToString();

                mylbl2.EnableViewState = true;
                mtxt12.EnableViewState = true;
                mtxt22.EnableViewState = true;

                div12.Controls.Add(mylbl2);
                div22.Controls.Add(mtxt12);
                div32.Controls.Add(mtxt22);

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
                ViewState["xline"] = null;
                message.InnerHtml = "";
                //_row.Value = "";
                //type.Value = "";
                _gridrow.Text = zglobal._grid_row_value;
               // _gridrow_h.Text = zglobal._grid_row_value;
                //grid_xsession.Text = "[Select]";
                //grid_xlocation.Text = "[Select]";
                //btnSave.Enabled = true;
              
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    TabContainer1.Height = 800;
                    _grid_header.InnerHtml = "Teacher Personal Information (Quick Contact) :";
                    fnGridVisibleProp("_grid_teacherinfo_breakup");
                    //_grid_teacherinfo_breakup.DataSource = null;
                    //_grid_teacherinfo_breakup.DataBind();
                    //_grid_teacherinfo.DataSource = null;
                   // _grid_teacherinfo.DataBind();
                    getActiveTabIndex.Value = "0";
                    type.Value = "teacherinfo";
                    fnFillDataGrid(null,null);
                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                    btnRefresh.Visible = true;
                    
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    TabContainer1.Height = 400;
                    _grid_header.InnerHtml = "Educational Information :";
                    fnGridVisibleProp("_grid_education");
                    //_grid_out.DataSource = null;
                    //_grid_out.DataBind();
                    getActiveTabIndex.Value = "1";
                    //type.Value = "out";
                    fnFillDataGrid(null, null);
                    xexamname.Text = "";
                    school.Visible = false;
                    graduateschool.Visible = false;
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    btnRefresh.Visible = true;

                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    TabContainer1.Height = 400;
                    _grid_header.InnerHtml = "Training & Other Courses :";
                    fnGridVisibleProp("_grid_sport");
                    //_grid_sport.DataSource = null;
                    //_grid_sport.DataBind();
                    getActiveTabIndex.Value = "2";
                    type.Value = "sport";
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    btnRefresh.Visible = true;
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    TabContainer1.Height = 800;
                    _grid_header.InnerHtml = "Official Informations :";
                    fnGridVisibleProp("_grid_exam");
                    //_grid_exam.DataSource = null;
                    //_grid_exam.DataBind();
                    getActiveTabIndex.Value = "3";
                    type.Value = "exam";
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    btnRefresh.Visible = true;
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
                    //if (xeffdate.Text == "" || xeffdate.Text == string.Empty || xeffdate.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Effected Date</li>";
                    //    isValid = false;
                    //}
                    if (xemp.Text == "" || xemp.Text == string.Empty || xemp.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Teacher's ID</li>";
                        isValid = false;
                    }
                    if (xname.Text == "" || xname.Text == string.Empty || xname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Name</li>";
                        isValid = false;
                    }
                    if (xcontact.Text == "" || xcontact.Text == string.Empty || xcontact.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Contact Number</li>";
                        isValid = false;
                    }
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    if (xexamname.SelectedValue == "" || xexamname.Text == "" || xexamname.Text == string.Empty || xexamname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Exam Name / Name of Degree </li>";
                        isValid = false;
                    }
                    //if (xprogramme_out.Text == "" || xprogramme_out.Text == string.Empty || xprogramme_out.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    //    isValid = false;
                    //}
                    //if (xlocation_out.Text == "" || xlocation_out.Text == string.Empty || xlocation_out.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    //    isValid = false;
                    //}
                    //if (xdate_out.Text == "" || xdate_out.Text == string.Empty || xdate_out.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    //    isValid = false;
                    //}
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    //if (xsession_sport.Text == "" || xsession_sport.Text == string.Empty || xsession_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Session</li>";
                    //    isValid = false;
                    //}
                    //if (xprogramme_sport.Text == "" || xprogramme_sport.Text == string.Empty || xprogramme_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    //    isValid = false;
                    //}
                    //if (xlocation_sport.Text == "" || xlocation_sport.Text == string.Empty || xlocation_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    //    isValid = false;
                    //}
                    //if (xdate_sport.Text == "" || xdate_sport.Text == string.Empty || xdate_sport.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    //    isValid = false;
                    //}
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    //if (xsession_exam.Text == "" || xsession_exam.Text == string.Empty || xsession_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Session</li>";
                    //    isValid = false;
                    //}
                    //if (xlocation_exam.Text == "" || xlocation_exam.Text == string.Empty || xlocation_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>School</li>";
                    //    isValid = false;
                    //}
                    //if (xdate_exam.Text == "" || xdate_exam.Text == string.Empty || xdate_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>End of Mid Term</li>";
                    //    isValid = false;
                    //}
                    //if (xexam_exam.Text == "" || xexam_exam.Text == string.Empty || xexam_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Name of The Exam</li>";
                    //    isValid = false;
                    //}
                    //if (xclass_exam.Text == "" || xclass_exam.Text == string.Empty || xclass_exam.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Class </li>";
                    //    isValid = false;
                    //}
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
                        DateTime xeffdate1 = DateTime.Now;
                        string xemp1 = "";
                        string xname1 = "";
                        DateTime xdob1 = DateTime.Now;
                        string xnationality1 = "";
                        string xnid1 = "";
                        string xblood1 = "";
                        string xsex1 = "";
                        string xfather1 = "";
                        string xmother1 = "";
                        int xnosibling1 = 0;
                        string xreligion1 = "";
                        string xpadd1 = "";
                        string xperadd1 = "";
                        string xcontact1 = "";
                        string xecontact1 = "";
                        string xemail11 = "";
                        string xmstatus1 = "";
                        DateTime xmday1 = DateTime.Today;
                        string xlink1 = "";
                        string xspouse1 = "";
                        string xsocupation1 = "";
                        int xnochild1 = 0;
                        decimal xjsalary1 = 0;
                        DateTime xjdate1 = DateTime.Today;
                        string xjposition1 = "";
                        string xuser1 = "";
                        string xlocation1 = "";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

                        string query = "";
                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            query = "INSERT INTO hrmst (ztime,zid,xemp,xname,xdob,xnationality,xnid,xblood,xsex,xfather,xmother,xnosibling,xreligion,xpadd,xperadd,xcontact,xecontact,xemail1,xmstatus,xmday,xlink,xspouse,xsocupation,xnochild,zemail) " +
                                    "VALUES(@ztime,@zid,@xemp,@xname,@xdob,@xnationality,@xnid,@xblood,@xsex,@xfather,@xmother,@xnosibling,@xreligion,@xpadd,@xperadd,@xcontact,@xecontact,@xemail1,@xmstatus,@xmday,@xlink,@xspouse,@xsocupation,@xnochild,@zemail) ";

                            xemp1 = xemp.Text.Trim().ToString();
                            xkey = xemp1;
                            ViewState["xemp"] = xemp.Text.Trim().ToString();
                            _row.Value = ViewState["xemp"].ToString();
                            xname1 = xname.Text.Trim().ToString();
                            xdob1 = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xnationality1 = xnationality.Text.Trim().ToString();
                            xnid1 = xnid.Text.Trim().ToString();
                            xblood1 = xblood.Text.Trim().ToString();
                            xsex1 = xsex.Text.Trim().ToString();
                            xfather1 = xfather.Text.Trim().ToString();
                            xmother1 = xmother.Text.Trim().ToString();
                            xnosibling1 = xnosibling.Text.Trim().ToString() == String.Empty || xnosibling.Text.Trim().ToString() == "" ? xnosibling1 : Convert.ToInt32(xnosibling.Text.Trim().ToString());
                            xreligion1 = xreligion.Text.Trim().ToString();
                            xpadd1 = xpadd.Text.Trim().ToString();
                            xperadd1 = xperadd.Text.Trim().ToString();
                            xcontact1 = xcontact.Text.Trim().ToString();
                            xecontact1 = xecontact.Text.Trim().ToString();
                            xemail11 = xemail1.Text.Trim().ToString();
                            xmstatus1 = xmstatus.Text.Trim().ToString();
                            xmday1 = xmday.Text.Trim() != string.Empty ? DateTime.ParseExact(xmday.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xlink1 = ximage.ImageUrl;

                            if (rdoCapture.Checked)
                            {
                                xlink1 = _teacherimageurl.Value.ToString();
                                ximage.ImageUrl = xlink1;
                            }
                            else
                            {
                                xlink1 = ximage.ImageUrl.ToString();
                            }
                            xspouse1 = xspouse.Text.Trim().ToString();
                            xsocupation1 = xsocupation.Text.Trim().ToString();
                            xnochild1 = xnochild.Text.Trim().ToString() == String.Empty || xnochild.Text.Trim().ToString() == "" ? xnochild1 : Convert.ToInt32(xnochild.Text.Trim().ToString());
                        }
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            //query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xprogram,xlocation,xdate,xfdate,xallconvenor,xcoconvenor,xprogdetail,xfclass,xtclass,xffdate,xtdate,xvenue,xconvenor,xcalendertype,zemail) " +
                            //        "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xprogram,@xlocation,@xdate,@xfdate,@xallconvenor,@xcoconvenor,@xprogdetail,@xfclass,@xtclass,@xffdate,@xtdate,@xvenue,@xconvenor,@xcalendertype,@zemail) ";
                            //xtype = "out";
                            //xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            //xkey = xrow.ToString();
                            //xsession = xsession_out.Text.Trim().ToString();
                            //xprogram = xprogramme_out.Text.Trim().ToString();
                            //xlocation = xlocation_out.Text.Trim().ToString();
                            //xdate = xdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfdate = xfdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_out.Text.Trim().ToString();
                            //xcoconvenor = xcoconvenor_out.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_out.InnerText.Trim().ToString();
                            //xfclass = xfclass_out.Text.Trim().ToString();
                            //xtclass = xtclass_out.Text.Trim().ToString();
                            //xffdate = xffdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xvenue = xvenue_out.Text.Trim().ToString();
                            //xconvenor = xconvenor_out.Text.Trim().ToString();
                        }
                        else if (TabContainer1.ActiveTabIndex == 2)
                        {
                            //query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xprogram,xlocation,xdate,xfdate,xallconvenor,xcoconvenor,xprogdetail,xfclass,xtclass,xffdate,xtdate,xfinaldate,xcalendertype,zemail) " +
                            //        "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xprogram,@xlocation,@xdate,@xfdate,@xallconvenor,@xcoconvenor,@xprogdetail,@xfclass,@xtclass,@xffdate,@xtdate,@xfinaldate,@xcalendertype,@zemail) ";
                            //xtype = "sport";
                            //xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            //xkey = xrow.ToString();
                            //xsession = xsession_sport.Text.Trim().ToString();
                            //xprogram = xprogramme_sport.Text.Trim().ToString();
                            //xlocation = xlocation_sport.Text.Trim().ToString();
                            //xdate = xdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfdate = xfdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                            //xcoconvenor = xcoconvenor_sport.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_sport.InnerText.Trim().ToString();
                            //xfclass = xfclass_sport.Text.Trim().ToString();
                            //xtclass = xtclass_sport.Text.Trim().ToString();
                            //xffdate = xffdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfinaldate = xfinaldate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfinaldate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        else if (TabContainer1.ActiveTabIndex == 3)
                        {
                            //query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xlocation,xdate,xexam,xfclass,xfdate,xtdate,xffdate,xresultdate,xconvenor,xprogdetail,xcalendertype,zemail) " +
                            //        "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xlocation,@xdate,@xexam,@xfclass,@xfdate,@xtdate,@xffdate,@xresultdate,@xconvenor,@xprogdetail,@xcalendertype,@zemail) ";
                            //xtype = "exam";
                            //xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            //xkey = xrow.ToString();
                            //xsession = xsession_exam.Text.Trim().ToString();
                            //xlocation = xlocation_exam.Text.Trim().ToString();
                            //xdate = xdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xexam = xexam_exam.Text.Trim().ToString();
                            //xfclass = xclass_exam.Text.Trim().ToString();
                            //xfdate = xfdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xffdate = xsubmission_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xsubmission_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xresultdate = xresultdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                            //xconvenor = xconvenor_exam.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_exam.InnerText.Trim().ToString();
                        }
                        else if (TabContainer1.ActiveTabIndex == 4)
                        {
                            //query = "INSERT INTO mscalender (ztime,zid,xtype,xrow,xsession,xlocation,xname,xfclass,xtclass,xffdate,xtdate,xfdate,xconvenor,xresultdate,xprogdetail,xcalendertype,zemail) " +
                            //        "VALUES(@ztime,@zid,@xtype,@xrow,@xsession,@xlocation,@xname,@xfclass,@xtclass,@xffdate,@xtdate,@xfdate,@xconvenor,@xresultdate,@xprogdetail,@xcalendertype,@zemail) ";
                            //xtype = "others";
                            //xrow = zglobal.GetMaximumIdInt("xrow", "mscalender", " zid=" + _zid + " and xtype='" + xtype + "'");
                            //xkey = xrow.ToString();
                            //xsession = xsession_others.Text.Trim().ToString();
                            //xlocation = xlocation_others.Text.Trim().ToString();
                            //xname = xname_others.Text.Trim().ToString();
                            //xfclass = xfclass_others.Text.Trim().ToString();
                            //xtclass = xtclass_others.Text.Trim().ToString();
                            //xfdate = xfdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xffdate = xffdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xresultdate = xresultdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xconvenor = xconvenor_others.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_others.InnerText.Trim().ToString();
                        }



                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xemp", xemp1);
                        cmd.Parameters.AddWithValue("@xname", xname1);
                        cmd.Parameters.AddWithValue("@xdob", xdob1);
                        cmd.Parameters.AddWithValue("@xnationality", xnationality1);
                        cmd.Parameters.AddWithValue("@xnid", xnid1);
                        cmd.Parameters.AddWithValue("@xblood", xblood1);
                        cmd.Parameters.AddWithValue("@xsex", xsex1);
                        cmd.Parameters.AddWithValue("@xfather", xfather1);
                        cmd.Parameters.AddWithValue("@xmother", xmother1);
                        cmd.Parameters.AddWithValue("@xnosibling", xnosibling1);
                        cmd.Parameters.AddWithValue("@xreligion", xreligion1);
                        cmd.Parameters.AddWithValue("@xpadd", xpadd1);
                        cmd.Parameters.AddWithValue("@xperadd", xperadd1);
                        cmd.Parameters.AddWithValue("@xcontact", xcontact1);
                        cmd.Parameters.AddWithValue("@xecontact", xecontact1);
                        cmd.Parameters.AddWithValue("@xemail1", xemail11);
                        cmd.Parameters.AddWithValue("@xmstatus", xmstatus1);
                        cmd.Parameters.AddWithValue("@xmday", xmday1);
                        cmd.Parameters.AddWithValue("@xlink", xlink1);
                        cmd.Parameters.AddWithValue("@xspouse", xspouse1);
                        cmd.Parameters.AddWithValue("@xsocupation", xsocupation1);
                        cmd.Parameters.AddWithValue("@xnochild", xnochild1);
                        cmd.Parameters.AddWithValue("@xjsalary", xjsalary1);
                        cmd.Parameters.AddWithValue("@xjdate", xjdate1);
                        cmd.Parameters.AddWithValue("@xjposition", xjposition1);
                        cmd.Parameters.AddWithValue("@xuser", xuser1);
                        cmd.Parameters.AddWithValue("@xlocation", xlocation1);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xemail", xemail);
                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            cmd.ExecuteNonQuery();
                        }



                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            if (ViewState["ctladded"] != null)
                            {
                                query = "DELETE FROM hrchild WHERE zid=@zid and xemp=@xemp";
                                cmd.Parameters.Clear();
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", xemp1);
                                cmd.ExecuteNonQuery();

                                for (int i = 1; i <= (int)ViewState["ctladded"]; i++)
                                {
                                    cmd.Parameters.Clear();
                                    int xline = zglobal.GetMaximumIdInt("xline", "hrchild", " zid=" + _zid + " and xemp='" + xemp1 +"'", "line");
                                    string xchildname = ((TextBox)placeholder.FindControl("mtxt1" + i)).Text.ToString().Trim();
                                    string xchildsch = ((TextBox)placeholder.FindControl("mtxt2" + i)).Text.ToString().Trim();
                                    string xchildclass = ((TextBox)placeholder.FindControl("mtxt3" + i)).Text.ToString().Trim();
                                    query = "INSERT INTO hrchild (zid,xemp,xline,xname,xshcool,xclass) " +
                                        "VALUES(@zid,@xemp,@xline,@xname,@xshcool,@xclass) ";
                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xemp", xemp1);
                                    cmd.Parameters.AddWithValue("@xline", xline);
                                    cmd.Parameters.AddWithValue("@xname", xchildname);
                                    cmd.Parameters.AddWithValue("@xshcool", xchildsch);
                                    cmd.Parameters.AddWithValue("@xclass", xchildclass);
                                    if (xchildname != "" || xchildname != string.Empty)
                                    {
                                        cmd.ExecuteNonQuery();
                                    }

                                }
                            }

                            if (ViewState["ctladded2"] != null)
                            {
                                query = "DELETE FROM hrtour WHERE zid=@zid and xemp=@xemp";
                                cmd.Parameters.Clear();
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", xemp1);
                                cmd.ExecuteNonQuery();

                                for (int i = 1; i <= (int)ViewState["ctladded2"]; i++)
                                {
                                    cmd.Parameters.Clear();
                                    int xline = zglobal.GetMaximumIdInt("xline", "hrtour", " zid=" + _zid + " and xemp='" + xemp1 + "'", "line");
                                    string xcountry = ((TextBox)placeholder1.FindControl("mtxt12" + i)).Text.ToString().Trim();
                                    string xyear = ((TextBox)placeholder1.FindControl("mtxt22" + i)).Text.ToString().Trim();
                                    query = "INSERT INTO hrtour (zid,xemp,xline,xcountry,xyear) " +
                                        "VALUES(@zid,@xemp,@xline,@xcountry,@xyear) ";
                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xemp", xemp1);
                                    cmd.Parameters.AddWithValue("@xline", xline);
                                    cmd.Parameters.AddWithValue("@xcountry", xcountry);
                                    cmd.Parameters.AddWithValue("@xyear", xyear);
                                    if (xcountry != "" || xcountry != string.Empty)
                                    {
                                        cmd.ExecuteNonQuery();
                                    }

                                }
                            }

                        }
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            if (ViewState["xemp"] != null)
                            {

                                cmd.Parameters.Clear();
                                int xline = zglobal.GetMaximumIdInt("xline", "hredu"," zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                ViewState["xline"] = xline.ToString();
                                string xexamname1 = xexamname.SelectedItem.Text.Trim().ToString();
                                string xorg1 = "";
                                string xdist1 = "";
                                string xedusys1 = "";
                                string xboard1 = "";
                                string xedugroup1 = "";
                                string xyear1 = "";
                                string xresult1 = "";
                                decimal xgpa1 = 0;
                                int xnumsub1 = 0;
                                int xnaa1 = 0;
                                int xna1 = 0;
                                int xnb1 = 0;
                                int xnc1 = 0;
                                string xunderorg1 = "";
                                string xcountry1 = "";
                                string xsubject1 = "";
                                string xduration1 = "";
                                string xposition1 = "";

                                query = "INSERT INTO hredu (zid,xemp,xline,xexamname,xorg,xdist,xedusys,xboard,xedugroup,xyear,xresult,xgpa,xnumsub,xnaa,xna,xnb,xnc,xunderorg,xcountry,xsubject,xduration,xposition) " +
                                        "VALUES(@zid,@xemp,@xline,@xexamname,@xorg,@xdist,@xedusys,@xboard,@xedugroup,@xyear,@xresult,@xgpa,@xnumsub,@xnaa,@xna,@xnb,@xnc,@xunderorg,@xcountry,@xsubject,@xduration,@xposition) ";
                                
                                string[] val = xexamname.SelectedValue.Split('-');
                                if (val[1] == "1")
                                {
                                    xorg1 = xorg.Text.Trim().ToString();
                                    xdist1 = xdist.Text.Trim().ToString();
                                    xedusys1 = xedusys.Text.Trim().ToString();
                                    xboard1 = xboard.Text.Trim().ToString();
                                    xedugroup1 = xedugroup.Text.Trim().ToString();
                                    xyear1 = xyear.Text.Trim().ToString();
                                    xresult1 = xgpa_s.Text.Trim().ToString();
                                    if (xresult1.ToUpper() == "GPA")
                                    {
                                        xgpa1 = xpoint_s.Text.Trim().ToString()==String.Empty || xpoint_s.Text.Trim().ToString()=="" ? xgpa1 : Convert.ToDecimal(xpoint_s.Text.Trim().ToString());
                                    }
                                    xnumsub1 = xnumsub.Text.Trim().ToString()==String.Empty || xnumsub.Text.Trim().ToString() == "" ? xnumsub1 : Convert.ToInt32(xnumsub.Text.Trim().ToString());
                                    xnaa1 = xnaa.Text.Trim().ToString() == String.Empty || xnaa.Text.Trim().ToString() == "" ? xnaa1 : Convert.ToInt32(xnaa.Text.Trim().ToString());
                                    xna1 = xna.Text.Trim().ToString() == String.Empty || xna.Text.Trim().ToString() == "" ? xna1 : Convert.ToInt32(xna.Text.Trim().ToString());
                                    xnb1 = xnb.Text.Trim().ToString() == String.Empty || xnb.Text.Trim().ToString()=="" ? xnb1 :Convert.ToInt32(xnb.Text.Trim().ToString());
                                    xnc1 = xnc.Text.Trim().ToString() == String.Empty || xnc.Text.Trim().ToString() == "" ? xnc1 : Convert.ToInt32(xnc.Text.Trim().ToString());
                                }
                                else if (val[1] == "2")
                                {
                                    xorg1 = xorggs.Text.Trim().ToString();
                                    xcountry1 = xcountry.Text.Trim().ToString();
                                    xunderorg1 = xunderorg.Text.Trim().ToString();
                                    xsubject1 = xsubject.Text.Trim().ToString();
                                    xyear1 = xyeargs.Text.Trim().ToString();
                                    xresult1 = xgpa_gs.Text.Trim().ToString();
                                    if (xresult1.ToUpper() == "GPA")
                                    {
                                        xgpa1 = Convert.ToDecimal(xpoint_gs.Text.Trim().ToString());
                                    }
                                    xduration1 = xduration.Text.Trim().ToString();
                                    xposition1 = xposition.Text.Trim().ToString();
                                }

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.Parameters.AddWithValue("@xexamname", xexamname1);
                                cmd.Parameters.AddWithValue("@xorg", xorg1);
                                cmd.Parameters.AddWithValue("@xdist", xdist1);
                                cmd.Parameters.AddWithValue("@xedusys", xedusys1);
                                cmd.Parameters.AddWithValue("@xboard", xboard1);
                                cmd.Parameters.AddWithValue("@xedugroup", xedugroup1);
                                cmd.Parameters.AddWithValue("@xyear", xyear1);
                                cmd.Parameters.AddWithValue("@xresult", xresult1);
                                cmd.Parameters.AddWithValue("@xgpa", xgpa1);
                                cmd.Parameters.AddWithValue("@xnumsub", xnumsub1);
                                cmd.Parameters.AddWithValue("@xnaa", xnaa1);
                                cmd.Parameters.AddWithValue("@xna", xna1);
                                cmd.Parameters.AddWithValue("@xnb", xnb1);
                                cmd.Parameters.AddWithValue("@xnc", xnc1);
                                cmd.Parameters.AddWithValue("@xunderorg", xunderorg1);
                                cmd.Parameters.AddWithValue("@xcountry", xcountry1);
                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                cmd.Parameters.AddWithValue("@xduration", xduration1);
                                cmd.Parameters.AddWithValue("@xposition", xposition1);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                message.InnerHtml = "No Teacher Select To Save Record.";
                                message.Style.Value = zglobal.warningmsg;
                                return;
                            }
                        }



                        //Insert into zreclog
                       // zglobal.fnRecordLog(xrow.ToString(), "Save", "eventinfo", xtype, "", 0, xdate);


                    }

                    //fnFillDataGrid();
                    //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();


                }
                fnFillDataGrid(null, null);
                //btnSave.Enabled = false;
                btnSave.Visible = false;
                btnEdit.Visible = true;
                message.InnerHtml = zglobal.insertsuccmsg;
                message.Style.Value = zglobal.successmsg;
               // _row.Value = xkey;
                type.Value = xtype;
                xempd.Text = xemp.Text.Trim().ToString();
                xnamed.Text = xname.Text.Trim().ToString();
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    ViewState["xemp"] = xemp.Text.Trim().ToString();
                    _row.Value = ViewState["xemp"].ToString();
                    for (int i = 1; i < TabContainer1.Tabs.Count; i++)
                    {
                        TabContainer1.Tabs[i].Enabled = true;
                    }
                    Panel1.Enabled = true;
                }
               
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
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    Response.Redirect(Request.RawUrl);
                }
                else //if (TabContainer1.ActiveTabIndex==1)
                {
                    TabContainer1_ActiveTabChanged(sender,e);
                }
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
                if (xemp.Text == "" || xemp.Text == string.Empty || xemp.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Teacher's ID</li>";
                    isValid = false;
                }
                if (xname.Text == "" || xname.Text == string.Empty || xname.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Name</li>";
                    isValid = false;
                }
                if (xcontact.Text == "" || xcontact.Text == string.Empty || xcontact.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Contact Number</li>";
                    isValid = false;
                }
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                
            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
               
            }
            else if (TabContainer1.ActiveTabIndex == 3)
            {
                
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
                    DateTime xeffdate1 = DateTime.Now;
                    string xemp1 = ViewState["xemp"].ToString();
                    string xname1 = "";
                    DateTime xdob1 = DateTime.Now;
                    string xnationality1 = "";
                    string xnid1 = "";
                    string xblood1 = "";
                    string xsex1 = "";
                    string xfather1 = "";
                    string xmother1 = "";
                    int xnosibling1 = 0;
                    string xreligion1 = "";
                    string xpadd1 = "";
                    string xperadd1 = "";
                    string xcontact1 = "";
                    string xecontact1 = "";
                    string xemail11 = "";
                    string xmstatus1 = "";
                    DateTime xmday1 = DateTime.Today;
                    string xlink1 = "";
                    string xspouse1 = "";
                    string xsocupation1 = "";
                    int xnochild1 = 0;
                    decimal xjsalary1 = 0;
                    DateTime xjdate1 = DateTime.Today;
                    string xjposition1 = "";
                    string xuser1 = "";
                    string xlocation1 = "";
                    string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

                    string query = "";
                    if (TabContainer1.ActiveTabIndex == 0)
                    {
                        query = "UPDATE hrmst SET zutime=@zutime, xname=@xname, xdob=@xdob, xnationality=@xnationality, xnid=@xnid, xblood=@xblood, xsex=@xsex, xfather=@xfather, xmother=@xmother, xnosibling=@xnosibling, xreligion=@xreligion, xpadd=@xpadd, xperadd=@xperadd, xcontact=@xcontact, xecontact=@xecontact, xemail1=@xemail1, xmstatus=@xmstatus, xmday=@xmday, xlink=@xlink, xspouse=@xspouse, xsocupation=@xsocupation, xnochild=@xnochild, xemail=@xemail  " +
                                "WHERE zid=@zid AND xemp=@xemp";

                        xname1 = xname.Text.Trim().ToString();
                        xdob1 = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        xnationality1 = xnationality.Text.Trim().ToString();
                        xnid1 = xnid.Text.Trim().ToString();
                        xblood1 = xblood.Text.Trim().ToString();
                        xsex1 = xsex.Text.Trim().ToString();
                        xfather1 = xfather.Text.Trim().ToString();
                        xmother1 = xmother.Text.Trim().ToString();
                        xnosibling1 = Convert.ToInt32(xnosibling.Text.Trim().ToString());
                        xreligion1 = xreligion.Text.Trim().ToString();
                        xpadd1 = xpadd.Text.Trim().ToString();
                        xperadd1 = xperadd.Text.Trim().ToString();
                        xcontact1 = xcontact.Text.Trim().ToString();
                        xecontact1 = xecontact.Text.Trim().ToString();
                        xemail11 = xemail1.Text.Trim().ToString();
                        xmstatus1 = xmstatus.Text.Trim().ToString();
                        xmday1 = xmday.Text.Trim() != string.Empty ? DateTime.ParseExact(xmday.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("01/01/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //xlink1 = ximage.ImageUrl;
                        if (rdoCapture.Checked)
                        {
                            xlink1 = _teacherimageurl.Value.ToString();
                            ximage.ImageUrl = xlink1;
                        }
                        else
                        {
                            xlink1 = ximage.ImageUrl.ToString();
                        }
                        xspouse1 = xspouse.Text.Trim().ToString();
                        xsocupation1 = xsocupation.Text.Trim().ToString();
                        xnochild1 = Convert.ToInt32(xnochild.Text.Trim().ToString());
                    }
                    else if (TabContainer1.ActiveTabIndex == 1)
                    {
                        
                    }
                    else if (TabContainer1.ActiveTabIndex == 2)
                    {
                        
                    }
                    else if (TabContainer1.ActiveTabIndex == 3)
                    {
                       
                    }




                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@ztime", ztime);
                    cmd.Parameters.AddWithValue("@zutime", ztime);
                    cmd.Parameters.AddWithValue("@zid", _zid);
                    cmd.Parameters.AddWithValue("@xemp", xemp1);
                    cmd.Parameters.AddWithValue("@xname", xname1);
                    cmd.Parameters.AddWithValue("@xdob", xdob1);
                    cmd.Parameters.AddWithValue("@xnationality", xnationality1);
                    cmd.Parameters.AddWithValue("@xnid", xnid1);
                    cmd.Parameters.AddWithValue("@xblood", xblood1);
                    cmd.Parameters.AddWithValue("@xsex", xsex1);
                    cmd.Parameters.AddWithValue("@xfather", xfather1);
                    cmd.Parameters.AddWithValue("@xmother", xmother1);
                    cmd.Parameters.AddWithValue("@xnosibling", xnosibling1);
                    cmd.Parameters.AddWithValue("@xreligion", xreligion1);
                    cmd.Parameters.AddWithValue("@xpadd", xpadd1);
                    cmd.Parameters.AddWithValue("@xperadd", xperadd1);
                    cmd.Parameters.AddWithValue("@xcontact", xcontact1);
                    cmd.Parameters.AddWithValue("@xecontact", xecontact1);
                    cmd.Parameters.AddWithValue("@xemail1", xemail11);
                    cmd.Parameters.AddWithValue("@xmstatus", xmstatus1);
                    cmd.Parameters.AddWithValue("@xmday", xmday1);
                    cmd.Parameters.AddWithValue("@xlink", xlink1);
                    cmd.Parameters.AddWithValue("@xspouse", xspouse1);
                    cmd.Parameters.AddWithValue("@xsocupation", xsocupation1);
                    cmd.Parameters.AddWithValue("@xnochild", xnochild1);
                    cmd.Parameters.AddWithValue("@xjsalary", xjsalary1);
                    cmd.Parameters.AddWithValue("@xjdate", xjdate1);
                    cmd.Parameters.AddWithValue("@xjposition", xjposition1);
                    cmd.Parameters.AddWithValue("@xuser", xuser1);
                    cmd.Parameters.AddWithValue("@xlocation", xlocation1);
                    cmd.Parameters.AddWithValue("@zemail", zemail);
                    cmd.Parameters.AddWithValue("@xemail", xemail);
                    if (TabContainer1.ActiveTabIndex == 0)
                    {
                        cmd.ExecuteNonQuery();
                    }



                    if (TabContainer1.ActiveTabIndex == 0)
                    {
                        if (ViewState["ctladded"] != null)
                        {
                            query = "DELETE FROM hrchild WHERE zid=@zid and xemp=@xemp";
                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.ExecuteNonQuery();

                            for (int i = 1; i <= (int)ViewState["ctladded"]; i++)
                            {
                                cmd.Parameters.Clear();
                                int xline = zglobal.GetMaximumIdInt("xline", "hrchild", " zid=" + _zid + " and xemp='" + xemp1 + "'", "line");
                                string xchildname = ((TextBox)placeholder.FindControl("mtxt1" + i)).Text.ToString().Trim();
                                string xchildsch = ((TextBox)placeholder.FindControl("mtxt2" + i)).Text.ToString().Trim();
                                string xchildclass = ((TextBox)placeholder.FindControl("mtxt3" + i)).Text.ToString().Trim();
                                query = "INSERT INTO hrchild (zid,xemp,xline,xname,xshcool,xclass) " +
                                    "VALUES(@zid,@xemp,@xline,@xname,@xshcool,@xclass) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", xemp1);
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.Parameters.AddWithValue("@xname", xchildname);
                                cmd.Parameters.AddWithValue("@xshcool", xchildsch);
                                cmd.Parameters.AddWithValue("@xclass", xchildclass);
                                if (xchildname != "" || xchildname != string.Empty)
                                {
                                    cmd.ExecuteNonQuery();
                                }

                            }
                        }

                        if (ViewState["ctladded2"] != null)
                        {
                            query = "DELETE FROM hrtour WHERE zid=@zid and xemp=@xemp";
                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.ExecuteNonQuery();

                            for (int i = 1; i <= (int)ViewState["ctladded2"]; i++)
                            {
                                cmd.Parameters.Clear();
                                int xline = zglobal.GetMaximumIdInt("xline", "hrtour", " zid=" + _zid + " and xemp='" + xemp1 + "'", "line");
                                string xcountry = ((TextBox)placeholder1.FindControl("mtxt12" + i)).Text.ToString().Trim();
                                string xyear = ((TextBox)placeholder1.FindControl("mtxt22" + i)).Text.ToString().Trim();
                                query = "INSERT INTO hrtour (zid,xemp,xline,xcountry,xyear) " +
                                    "VALUES(@zid,@xemp,@xline,@xcountry,@xyear) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", xemp1);
                                cmd.Parameters.AddWithValue("@xline", xline);
                                cmd.Parameters.AddWithValue("@xcountry", xcountry);
                                cmd.Parameters.AddWithValue("@xyear", xyear);
                                if (xcountry != "" || xcountry != string.Empty)
                                {
                                    cmd.ExecuteNonQuery();
                                }

                            }
                        }

                    }
                    else if(TabContainer1.ActiveTabIndex==1)
                    {
                        if (ViewState["xemp"] != null)
                        {

                            cmd.Parameters.Clear();
                            //int xline = zglobal.GetMaximumIdInt("xline", "hredu", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                            //ViewState["xline"] = xline.ToString();
                            string xexamname1 = xexamname.SelectedItem.Text.Trim().ToString();
                            string xorg1 = "";
                            string xdist1 = "";
                            string xedusys1 = "";
                            string xboard1 = "";
                            string xedugroup1 = "";
                            string xyear1 = "";
                            string xresult1 = "";
                            decimal xgpa1 = 0;
                            int xnumsub1 = 0;
                            int xnaa1 = 0;
                            int xna1 = 0;
                            int xnb1 = 0;
                            int xnc1 = 0;
                            string xunderorg1 = "";
                            string xcountry1 = "";
                            string xsubject1 = "";
                            string xduration1 = "";
                            string xposition1 = "";

                            query = "UPDATE hredu SET xexamname=@xexamname,xorg=@xorg,xdist=@xdist,xedusys=@xedusys,xboard=@xboard,xedugroup=@xedugroup,xyear=@xyear,xresult=@xresult,xgpa=@xgpa,xnumsub=@xnumsub,xnaa=@xnaa,xna=@xna,xnb=@xnb,xnc=@xnc,xunderorg=@xunderorg,xcountry=@xcountry,xsubject=@xsubject,xduration=@xduration,xposition=@xposition " +
                                    "WHERE zid=@zid AND xemp=@xemp AND xline=@xline ";

                            string[] val = xexamname.SelectedValue.Split('-');
                            if (val[1] == "1")
                            {
                                xorg1 = xorg.Text.Trim().ToString();
                                xdist1 = xdist.Text.Trim().ToString();
                                xedusys1 = xedusys.Text.Trim().ToString();
                                xboard1 = xboard.Text.Trim().ToString();
                                xedugroup1 = xedugroup.Text.Trim().ToString();
                                xyear1 = xyear.Text.Trim().ToString();
                                xresult1 = xgpa_s.Text.Trim().ToString();
                                if (xresult1.ToUpper() == "GPA")
                                {
                                    xgpa1 = xpoint_s.Text.Trim().ToString() == String.Empty || xpoint_s.Text.Trim().ToString() == "" ? xgpa1 : Convert.ToDecimal(xpoint_s.Text.Trim().ToString());
                                }
                                xnumsub1 = xnumsub.Text.Trim().ToString() == String.Empty || xnumsub.Text.Trim().ToString() == "" ? xnumsub1 : Convert.ToInt32(xnumsub.Text.Trim().ToString());
                                xnaa1 = xnaa.Text.Trim().ToString() == String.Empty || xnaa.Text.Trim().ToString() == "" ? xnaa1 : Convert.ToInt32(xnaa.Text.Trim().ToString());
                                xna1 = xna.Text.Trim().ToString() == String.Empty || xna.Text.Trim().ToString() == "" ? xna1 : Convert.ToInt32(xna.Text.Trim().ToString());
                                xnb1 = xnb.Text.Trim().ToString() == String.Empty || xnb.Text.Trim().ToString() == "" ? xnb1 : Convert.ToInt32(xnb.Text.Trim().ToString());
                                xnc1 = xnc.Text.Trim().ToString() == String.Empty || xnc.Text.Trim().ToString() == "" ? xnc1 : Convert.ToInt32(xnc.Text.Trim().ToString());
                            }
                            else if (val[1] == "2")
                            {
                                xorg1 = xorggs.Text.Trim().ToString();
                                xcountry1 = xcountry.Text.Trim().ToString();
                                xunderorg1 = xunderorg.Text.Trim().ToString();
                                xsubject1 = xsubject.Text.Trim().ToString();
                                xyear1 = xyeargs.Text.Trim().ToString();
                                xresult1 = xgpa_gs.Text.Trim().ToString();
                                if (xresult1.ToUpper() == "GPA")
                                {
                                    xgpa1 = Convert.ToDecimal(xpoint_gs.Text.Trim().ToString());
                                }
                                xduration1 = xduration.Text.Trim().ToString();
                                xposition1 = xposition.Text.Trim().ToString();
                            }

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                            cmd.Parameters.AddWithValue("@xline", ViewState["xline"].ToString());
                            cmd.Parameters.AddWithValue("@xexamname", xexamname1);
                            cmd.Parameters.AddWithValue("@xorg", xorg1);
                            cmd.Parameters.AddWithValue("@xdist", xdist1);
                            cmd.Parameters.AddWithValue("@xedusys", xedusys1);
                            cmd.Parameters.AddWithValue("@xboard", xboard1);
                            cmd.Parameters.AddWithValue("@xedugroup", xedugroup1);
                            cmd.Parameters.AddWithValue("@xyear", xyear1);
                            cmd.Parameters.AddWithValue("@xresult", xresult1);
                            cmd.Parameters.AddWithValue("@xgpa", xgpa1);
                            cmd.Parameters.AddWithValue("@xnumsub", xnumsub1);
                            cmd.Parameters.AddWithValue("@xnaa", xnaa1);
                            cmd.Parameters.AddWithValue("@xna", xna1);
                            cmd.Parameters.AddWithValue("@xnb", xnb1);
                            cmd.Parameters.AddWithValue("@xnc", xnc1);
                            cmd.Parameters.AddWithValue("@xunderorg", xunderorg1);
                            cmd.Parameters.AddWithValue("@xcountry", xcountry1);
                            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                            cmd.Parameters.AddWithValue("@xduration", xduration1);
                            cmd.Parameters.AddWithValue("@xposition", xposition1);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            message.InnerHtml = "No Teacher Select To Update Record.";
                            message.Style.Value = zglobal.warningmsg;
                            return;
                        }
                        
                    }



                    //Insert into zreclog
                    //zglobal.fnRecordLog(xrow.ToString(), "Edit", "eventinfo", xtype, "", 0, xdate);


                }

                //fnFillDataGrid();
                //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                tran.Complete();


            }

            fnFillDataGrid(null, null);
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

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ErrorMsg.InnerHtml = "";
                bool isValidFile = false;

                if (FileUpload1.HasFile)
                {
                    string[] validFileTypes = { "bmp", "png", "jpg", "jpeg" };

                    string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);

                    

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {

                        if (ext == "." + validFileTypes[i])
                        {

                            isValidFile = true;

                            break;

                        }

                    }

                    if (!isValidFile)
                    {


                        ErrorMsg.InnerHtml = "Invalid File. Please upload a File with extension<br> " +

                                       string.Join(",", validFileTypes);
                        ErrorMsg.Style.Value = zglobal.errormsg;
                        //return;
                    }


                    if (FileUpload1.PostedFile.ContentLength > 100000)
                    {
                        ErrorMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image size. (Max size 100KB)<br>";
                        ErrorMsg.Style.Value = zglobal.errormsg;
                        isValidFile = false;
                        //return;
                    }
                    else
                    {
                        isValidFile = true;
                    }

                    Bitmap bitmp = new Bitmap(FileUpload1.PostedFile.InputStream);
                    if (bitmp.Width != 300 & bitmp.Height != 300)
                    {
                        ErrorMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image dimension. (Dimension must be 300x300)";
                        ErrorMsg.Style.Value = zglobal.errormsg;
                        isValidFile = false;
                        //return;
                    }
                    else
                    {
                        isValidFile = true;
                    }

                    if (!isValidFile)
                    {
                        return;
                    }

                    //if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                    //{
                    string path = "~/images/profile/teacher/";
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    //string filename = FileUpload1.FileName;
                    string folderPath = HttpContext.Current.Server.MapPath(path + _zid.ToString() + "/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    int xrow;
                    if (_row.Value.ToString() == "" || _row.Value.ToString() == String.Empty)
                    {
                        xrow = 0;
                    }
                    else
                    {
                        xrow = Int32.Parse(_row.Value.ToString());
                    }
                    string fileName = _zid.ToString() + "_" + xrow.ToString() + "_" + DateTime.Now.Ticks.ToString() + extension;
                    string imagePath = folderPath + fileName;
                    FileUpload1.SaveAs(imagePath);
                    ximage.ImageUrl = path + _zid.ToString() + "/" + fileName;
                    ErrorMsg.InnerHtml = "";

                    //}
                    //else
                    //{
                    //    ErrorMsg.Visible = true;
                    //    ErrorMsg.InnerHtml = "Invalid File, Cannot Upload!";
                    //}
                }
                else
                {
                    ErrorMsg.Visible = true;
                    ErrorMsg.InnerHtml = "Please select a File";
                    ErrorMsg.Style.Value = zglobal.errormsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected bool IsImageFile(HttpPostedFile file)
        {
            bool isImage = false;
            System.IO.FileStream fs = new System.IO.FileStream(file.FileName,
              System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            string fileclass = "";
            byte buffer = br.ReadByte();
            fileclass = buffer.ToString();
            buffer = br.ReadByte();
            fileclass += buffer.ToString();
            br.Close();
            fs.Close();

            //only allow images    jpg       gif     bmp     png      
            String[] fileType = { "255216", "7173", "6677", "13780" };
            for (int i = 0; i < fileType.Length; i++)
            {
                if (fileclass == fileType[i])
                {
                    isImage = true;
                    break;
                }
            }
            return isImage;
        }

        protected void fnImageCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoCapture.Checked)
                {
                    FileUpload1.Visible = false;
                    ImageButton3.Visible = false;
                    ErrorMsg.InnerText = "";
                }
                if (rdoUpload.Checked)
                {
                    FileUpload1.Visible = true;
                    ImageButton3.Visible = true;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

    }
}