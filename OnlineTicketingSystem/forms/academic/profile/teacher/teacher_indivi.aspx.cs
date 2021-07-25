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
    public partial class teacher_indivi : System.Web.UI.Page
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

        public void fnRegisterPostBack()
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {
                if (_grid_teacherinfo_breakup.Rows.Count > 0)
                {
                    foreach (GridViewRow row in _grid_teacherinfo_breakup.Rows)
                    {
                        LinkButton lnkFull1 = row.FindControl("xemp") as LinkButton;
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
                    }
                }
            }

            if (TabContainer1.ActiveTabIndex == 3)
            {
                if (GridView1.Rows.Count > 0)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        LinkButton lnkFull1 = row.FindControl("xposition") as LinkButton;
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
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
                    TabContainer1.Height = 820;
                    getActiveTabIndex.Value = "0";
                    fnGridVisibleProp("_grid_teacherinfo_breakup");
                    //_row.Value = "";
                    type.Value = "teacherinfo";
                    _gridrow.Text = zglobal._grid_row_value;
                    _gridrow1.Text = zglobal._grid_row_value;
                    //_gridrow_h.Text = zglobal._grid_row_value;
                    //xpoint_s.Enabled = false;
                    zglobal.fnGetComboDataCD("Nationality", xnationality);
                    zglobal.fnGetComboDataCD("Blood Group", xblood);
                    zglobal.fnGetComboDataCD("Sex", xsex);
                    zglobal.fnGetComboDataCD("Marital Status", xmstatus);
                    zglobal.fnGetComboDataCD("Religion", xreligion);
                    zglobal.fnGetComboDataCD("Name of Exam", "school", xexamname_sec, 1, 1);
                    zglobal.fnGetComboDataCD("Name of Exam", "school", xexamname_high, 2, 1);
                    zglobal.fnGetComboDataCD("Name of Exam", "school", xexamname_gra, 3, 1);
                    zglobal.fnGetComboDataCD("Education System", xedusys);
                    zglobal.fnGetComboDataCD("Education System", xedusys_high);
                    zglobal.fnGetComboDataCD("Education Board", xboard);
                    zglobal.fnGetComboDataCD("Education Board", xboard_high);
                    zglobal.fnGetComboDataCD("Education Group", xedugroup);
                    zglobal.fnGetComboDataCD("Education Group", xedugroup_high);
                    zglobal.fnGetComboDataCD("Subject", xsubject);
                    zglobal.fnGetComboDataCD("District", xdist_pri);
                    zglobal.fnGetComboDataCD("District", xdist);
                    zglobal.fnGetComboDataCD("District", xdist_high);
                    zglobal.fnGetComboDataCD("Designation", xposition_job);
                    zglobal.fnGetComboDataCD("Location", xschool_job);
                    if (HttpContext.Current.Session["business"].ToString() == "100012")
                    {
                        xschool_job.Items.Add("Middle School & Senior School");
                        xschool_job.Text = "";
                    }
                    //zglobal.fnGetListboxValue("Class", xclass_all);
                    //zglobal.fnGetListboxValue("Section", xsection_all);
                    zglobal.fnGetComboDataCD(xyear);
                    zglobal.fnGetComboDataCD(xyeargs);
                    zglobal.fnGetComboDataCD(xyear_high);

                    xgpa_s.Items.Clear();
                    xgpa_s.Items.Add("");
                    xgpa_s.Items.Add("1st Devision");
                    xgpa_s.Items.Add("2nd Devision");
                    xgpa_s.Items.Add("3rd Devision");
                    xgpa_s.Items.Add("GPA");
                    xgpa_s.Text = "";

                    xgpa_high.Items.Clear();
                    xgpa_high.Items.Add("");
                    xgpa_high.Items.Add("1st Devision");
                    xgpa_high.Items.Add("2nd Devision");
                    xgpa_high.Items.Add("3rd Devision");
                    xgpa_high.Items.Add("GPA");
                    xgpa_high.Text = "";

                    xgpa_gs.Items.Clear();
                    xgpa_gs.Items.Add("");
                    xgpa_gs.Items.Add("1st Class");
                    xgpa_gs.Items.Add("2nd Class");
                    xgpa_gs.Items.Add("3rd Class");
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
                    //fnFillDataGrid(null, null);
                    //xpoints_divgs.Visible = false;
                    //xpoints_div.Visible = false;
                    //school.Visible = false;
                    //graduateschool.Visible = false;
                    for (int i = 1; i < TabContainer1.Tabs.Count; i++)
                    {
                        TabContainer1.Tabs[i].Enabled = false;
                    }

                    Panel1.Enabled = false;
                    btnEdit.Visible = false;
                    btnSave.Visible = true;
                    TabContainer1.Tabs[3].Visible = false;
                    xemp.AutoPostBack = false;
                    xemp.ReadOnly = true;
                    list.Visible = false;
                    ViewState["xline9"] = null;
                    position.Visible = false;


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

                if (ViewState["ctladded2"] == null)
                {
                    ViewState["ctladded2"] = 1;
                }

                fnCreateDynamicControlAtPageLoad2();

                if (ViewState["ctladded3"] == null)
                {
                    ViewState["ctladded3"] = 1;
                }

                fnCreateDynamicControlAtPageLoad3();

                if (ViewState["ctladded4"] == null)
                {
                    ViewState["ctladded4"] = 1;
                }

                fnCreateDynamicControlAtPageLoad4();

                if (ViewState["ctladded5"] == null)
                {
                    ViewState["ctladded5"] = 1;
                }

                fnCreateDynamicControlAtPageLoad5();

                //if (TabContainer1.ActiveTabIndex == 3)
                //{
                if (ViewState["ctladded9"] == null)
                {
                    ViewState["ctladded9"] = 1;
                }

                fnCreateDynamicControlAtPageLoad9();
                //}

                //list.Visible = false;

                if (!IsPostBack)
                {
                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            string query = "SELECT * FROM ztuser WHERE  xuser=@xuser";

                            SqlDataAdapter da = new SqlDataAdapter(query, con);
                            string xuser = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            da.SelectCommand.Parameters.AddWithValue("@xuser", xuser);
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.Fill(dts, "temp");
                            DataTable temp = new DataTable();
                            temp = dts.Tables[0];
                            if (temp.Rows.Count > 0 && temp.Rows[0]["xempcode"].ToString().Trim() != "")
                            {
                                ViewState["xemp"] = temp.Rows[0]["xempcode"].ToString().Trim();
                                FillControls(sender, e);


                                dts.Reset();
                                query = "SELECT * FROM hrmst WHERE  zid=@zid AND xemp=@xemp";

                                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                                string xemp = ViewState["xemp"].ToString();
                                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da1.SelectCommand.Parameters.AddWithValue("@xemp", xemp);
                                da1.SelectCommand.CommandType = CommandType.Text;
                                da1.Fill(dts, "temp");
                                temp = new DataTable();
                                temp = dts.Tables[0];
                                if (temp.Rows.Count > 0)
                                {
                                    if (temp.Rows[0]["xstatus"].ToString() == "Submited")
                                    {
                                        btnSave.Visible = false;
                                        btnEdit.Visible = false;
                                        btnSubmit.Visible = false;
                                        btnRefresh.Visible = true;
                                    }
                                }
                            }
                            else
                            {
                                btnSave.Visible = false;
                                btnEdit.Visible = false;
                                btnSubmit.Visible = false;
                                btnRefresh.Visible = true;
                            }



                            temp.Dispose();
                        }
                    }
                }

                fnRegisterPostBack();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }




        }

        private void fnChkSubmited()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {
                        if (ViewState["xemp"] != null)
                        {
                            string query = "SELECT * FROM hrmst WHERE  zid=@zid AND xemp=@xemp";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                            string xemp = ViewState["xemp"].ToString();
                            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xemp", xemp);
                            da1.SelectCommand.CommandType = CommandType.Text;
                            da1.Fill(dts, "temp");
                            DataTable temp = new DataTable();
                            temp = dts.Tables[0];
                            if (temp.Rows.Count > 0)
                            {
                                if (temp.Rows[0]["xstatus"].ToString() == "Submited")
                                {
                                    btnSave.Visible = false;
                                    btnEdit.Visible = false;
                                    btnSubmit.Visible = false;
                                    btnRefresh.Visible = true;
                                }
                            }




                            temp.Dispose();
                        }
                        else
                        {
                            btnSave.Visible = false;
                            btnEdit.Visible = false;
                            btnSubmit.Visible = false;
                            btnRefresh.Visible = true;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        public void fnSelSchoole(object sender, EventArgs e)
        {
            //try
            //{
            //    if (xexamname.SelectedValue == "")
            //    {
            //        school.Visible = false;
            //        graduateschool.Visible = false;
            //        TabContainer1_ActiveTabChanged(sender,e);
            //        return;
            //    }

            //    xorg.Text = "";
            //    xdist.Text = "";
            //    xedusys.Text = "";
            //    xboard.Text = "";
            //    xedugroup.Text = "";
            //    xyear.Text = "";
            //    xgpa_s.Text = "";
            //    xpoint_s.Text = "";
            //    xnumsub.Text = "";
            //    xnaa.Text = "";
            //    xna.Text = "";
            //    xnb.Text = "";
            //    xnc.Text = "";
            //    xunderorg.Text = "";
            //    xorggs.Text = "";
            //    xcountry.Text = "";
            //    xsubject.Text = "";
            //    xyeargs.Text = "";
            //    xgpa_gs.Text = "";
            //    xpoint_gs.Text = "";
            //    xduration.Text = "";
            //    xposition.Text = "";

            //    string[] val = xexamname.SelectedValue.Split('-');
            //    if (val[1] == "1")
            //    {
            //        school.Visible = true;
            //        graduateschool.Visible = false;
            //    }
            //    if (val[1] == "2")
            //    {
            //        school.Visible = false;
            //        graduateschool.Visible = true;
            //    }
            //    btnSave.Enabled = true;
            //    message.InnerHtml = "";
            //    ViewState["xline"] = null;
            //    btnSave.Visible = true;
            //    btnEdit.Visible = false;
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
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
                    str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xemp,xname,xcontact,xemail1,xblood FROM hrmst where zid=@zid and xname like '%" + _searchbox.Text.Trim().ToString() + "%'  ORDER BY xemp ";
                    grid = _grid_teacherinfo_breakup;
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    return;
                    //str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xline,xexamname,case when coalesce(xunderorg,'')='' then xorg else xunderorg end as xorg," +
                    //    "case when coalesce(xsubject,'')='' then xedugroup else xsubject end as xsubject,xyear," +
                    //    "case when coalesce(xresult,'')='GPA' then CAST(xgpa AS varchar(50)) else xresult end as xresult " + 
                    //    " FROM hredu where zid=@zid and xemp=@xemp  ORDER BY xline DESC";
                    //grid = _grid_education;
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    return;
                    //str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xprogram,xdate,xfdate,xallconvenor,xcoconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                    //grid = _grid_sport;
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    str = "SELECT TOP " + _gridrow1.Text.Trim().ToString() + " xline,xposition,xfdate,coalesce((select DATEADD(dd,-1,MIN(xfdate)) from hrjobs as a where a.xfdate> hrjobs.xfdate and a.zid=hrjobs.zid and a.xemp=hrjobs.xemp ),'2999-12-31') as xtdate FROM hrjobs where zid=@zid and xemp=@xemp   ORDER BY xfdate ";
                    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                    int _zid1 = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    string xtype1 = type.Value;
                    dts.Reset();
                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid1);
                    da1.SelectCommand.Parameters.AddWithValue("@xemp", ViewState["xemp"] == null ? "-1" : ViewState["xemp"].ToString());
                    da1.Fill(dts, "tempztcode");
                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable dtztcode1 = new DataTable();
                    dtztcode1 = dts.Tables[0];

                    GridView1.Columns[5].Visible = true;

                    GridView1.DataSource = dtztcode1;
                    GridView1.DataBind();

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        if (row.Cells[3].Text == "31/12/2999")
                        {
                            row.Cells[3].Text = "Continue";
                        }
                    }

                    GridView1.Columns[5].Visible = false;
                    return;
                    //str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xrow,xexam,xfclass,xfdate,xtdate,xresultdate,xconvenor FROM mscalender where zid=@zid and xtype=@xtype and xsession=@xsession and xlocation=@xlocation ORDER BY xrow DESC";
                    //grid = _grid_exam;
                }
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



                fnRegisterPostBack();

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
                string xemp1 = "";
                string str = "";
                //string xemp1 = ((LinkButton)sender).Text;
                //string str = "SELECT  * FROM hrmst where zid=@zid and xemp=@xemp  ";





                //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //da.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                //da.Fill(dts, "tempztcode");
                //DataTable dtztcode = new DataTable();
                //dtztcode = dts.Tables[0];
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    //ViewState["xemp"] = ((LinkButton) sender).Text;
                    //_row.Value = ViewState["xemp"].ToString();
                    //xempd.Text = ViewState["xemp"].ToString();
                    //xnamed.Text = dtztcode.Rows[0]["xname"].ToString();
                }

                if (TabContainer1.ActiveTabIndex == 0)
                {
                    if (sender is TextBox)
                    {
                        xemp1 = ((TextBox)sender).Text;

                    }
                    else if (sender is LinkButton)
                    {
                        xemp1 = ((LinkButton)sender).Text;
                    }
                    else
                    {
                        xemp1 = ViewState["xemp"].ToString();
                    }
                    str = "SELECT  * FROM hrmst where zid=@zid and xemp=@xemp  ";



                    SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    da.Fill(dts, "tempztcode");
                    DataTable dtztcode = new DataTable();
                    dtztcode = dts.Tables[0];

                    if (dtztcode.Rows.Count <= 0)
                    {
                        //btnRefresh_Click(null, null);
                        return;
                    }

                    if (sender is TextBox)
                    {
                        ViewState["xemp"] = ((TextBox)sender).Text;
                    }
                    else if (sender is LinkButton)
                    {
                        ViewState["xemp"] = ((LinkButton)sender).Text;
                    }


                    //ViewState["xemp"] = ((LinkButton)sender).Text;
                    _row.Value = ViewState["xemp"].ToString();
                    xempd.Text = ViewState["xemp"].ToString();
                    xnamed.Text = dtztcode.Rows[0]["xname"].ToString();

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
                    xfbid.Text = dtztcode.Rows[0]["xfbid"].ToString();
                    xhobbies.Text = dtztcode.Rows[0]["xhobbies"].ToString();
                    xexactivity.Text = dtztcode.Rows[0]["xexactivity"].ToString();
                    xeconname.Text = dtztcode.Rows[0]["xeconname"].ToString();
                    xeconrelation.Text = dtztcode.Rows[0]["xeconrelation"].ToString();
                    xjdate_job.Text = DBNull.Value.Equals(dtztcode.Rows[0]["xjdate"])? "" : Convert.ToDateTime(dtztcode.Rows[0]["xjdate"]).ToString("dd/MM/yyyy");

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

                    dtztcode.Dispose();
                    da.Dispose();
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {

                    //str = "SELECT  * FROM hredu where zid=@zid and xemp=@xemp and xline=@xline ";
                    //dts.Reset();
                    //SqlDataAdapter da4 = new SqlDataAdapter(str, conn1);
                    //da4.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //da4.SelectCommand.Parameters.AddWithValue("@xemp", ViewState["xemp"]==null?"-1":ViewState["xemp"].ToString());
                    //da4.SelectCommand.Parameters.AddWithValue("@xline", ((LinkButton)sender).Text); 
                    //da4.Fill(dts, "tempztcode");
                    //DataTable dtztcode4 = new DataTable();
                    //dtztcode4 = dts.Tables[0];

                    //xexamname.SelectedValue = dtztcode4.Rows[0]["xexamname"].ToString().Trim() + "-" + zglobal.fnProperty("Name of Exam", dtztcode4.Rows[0]["xexamname"].ToString().Trim(), "school");
                    //xorg.Text = dtztcode4.Rows[0]["xorg"].ToString().Trim();
                    //xdist.Text = dtztcode4.Rows[0]["xdist"].ToString().Trim();
                    //xedusys.Text = dtztcode4.Rows[0]["xedusys"].ToString().Trim();
                    //xboard.Text = dtztcode4.Rows[0]["xboard"].ToString().Trim();
                    //xedugroup.Text = dtztcode4.Rows[0]["xedugroup"].ToString().Trim();
                    //xyear.Text = dtztcode4.Rows[0]["xyear"].ToString().Trim();
                    //xgpa_s.Text = dtztcode4.Rows[0]["xresult"].ToString().Trim();
                    //xpoint_s.Text = dtztcode4.Rows[0]["xgpa"].ToString().Trim();
                    //xnumsub.Text = dtztcode4.Rows[0]["xnumsub"].ToString().Trim();
                    //xnaa.Text = dtztcode4.Rows[0]["xnaa"].ToString().Trim();
                    //xna.Text = dtztcode4.Rows[0]["xna"].ToString().Trim();
                    //xnb.Text = dtztcode4.Rows[0]["xnb"].ToString().Trim();
                    //xnc.Text = dtztcode4.Rows[0]["xnc"].ToString().Trim();
                    //xunderorg.Text = dtztcode4.Rows[0]["xunderorg"].ToString().Trim();
                    //xcountry.Text = dtztcode4.Rows[0]["xcountry"].ToString().Trim();
                    //xorggs.Text = dtztcode4.Rows[0]["xorg"].ToString().Trim();
                    //xsubject.Text = dtztcode4.Rows[0]["xsubject"].ToString().Trim();
                    //xyeargs.Text = dtztcode4.Rows[0]["xyear"].ToString().Trim();
                    //xgpa_gs.Text = dtztcode4.Rows[0]["xresult"].ToString().Trim();
                    //xpoint_gs.Text = dtztcode4.Rows[0]["xgpa"].ToString().Trim();
                    //xduration.Text = dtztcode4.Rows[0]["xduration"].ToString().Trim();
                    //xposition.Text = dtztcode4.Rows[0]["xposition"].ToString().Trim();

                    //string value = zglobal.fnProperty("Name of Exam", dtztcode4.Rows[0]["xexamname"].ToString().Trim(), "school");

                    //if (value == "1")
                    //{
                    //    school.Visible = true;
                    //    graduateschool.Visible = false;
                    //}
                    //else if (value == "2")
                    //{
                    //    school.Visible = false;
                    //    graduateschool.Visible = true;
                    //}
                    //ViewState["xline"] = ((LinkButton) sender).Text;
                    xemp1 = ViewState["xemp"].ToString();

                    dts.Reset();

                    str = "SELECT * FROM hredu WHERE zid=@zid AND xemp=@xemp AND xtype='postgraduation'";

                    SqlDataAdapter da5 = new SqlDataAdapter(str, conn1);

                    da5.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da5.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da5.Fill(dts, "temp");
                    DataTable dttemp5 = new DataTable();
                    dttemp5 = dts.Tables[0];
                    placeholder3.Controls.Clear();
                    if (dttemp5.Rows.Count > 0)
                    {

                        ViewState["ctladded3"] = dttemp5.Rows.Count;

                        //placeholder.Controls.Clear();

                        int howMany = (int)ViewState["ctladded3"];
                        for (int i = 1; i <= howMany; i++)
                        {
                            fnCreateControl3(i);
                            ((TextBox)placeholder3.FindControl("txtxunderorg_post" + i)).Text =
                                dttemp5.Rows[i - 1]["xunderorg"].ToString();
                            ((TextBox)placeholder3.FindControl("txtxcountry_post" + i)).Text =
                               dttemp5.Rows[i - 1]["xcountry"].ToString();
                            ((TextBox)placeholder3.FindControl("txtxorg_post" + i)).Text =
                               dttemp5.Rows[i - 1]["xorg"].ToString();
                            ((DropDownList)placeholder3.FindControl("dwxexamname_post" + i)).Text =
                              dttemp5.Rows[i - 1]["xexamname"].ToString();
                            ((DropDownList)placeholder3.FindControl("dwxsubject_post" + i)).Text =
                              dttemp5.Rows[i - 1]["xsubject"].ToString();
                            ((DropDownList)placeholder3.FindControl("dwxyear_post" + i)).Text =
                              dttemp5.Rows[i - 1]["xyear"].ToString();
                            ((DropDownList)placeholder3.FindControl("dwxgpa_post" + i)).Text =
                              dttemp5.Rows[i - 1]["xresult"].ToString();
                            ((TextBox)placeholder3.FindControl("txtxpoint_post" + i)).Text =
                             dttemp5.Rows[i - 1]["xgpa"].ToString();
                            ((DropDownList)placeholder3.FindControl("dwxduration_post" + i)).Text =
                             dttemp5.Rows[i - 1]["xduration"].ToString();
                            ((DropDownList)placeholder3.FindControl("dwxposition_post" + i)).Text =
                             dttemp5.Rows[i - 1]["xposition"].ToString();
                        }

                        dttemp5.Dispose();
                    }
                    else
                    {
                        ViewState["ctladded3"] = 1;
                        fnCreateDynamicControlAtPageLoad3();
                    }

                    ////////////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    str = "SELECT * FROM hredu WHERE zid=@zid AND xemp=@xemp AND xtype='primary'";

                    SqlDataAdapter da6 = new SqlDataAdapter(str, conn1);

                    da6.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da6.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da6.Fill(dts, "temp");
                    DataTable dttemp6 = new DataTable();
                    dttemp6 = dts.Tables[0];

                    for (int i = 1; i <= dttemp6.Rows.Count; i++)
                    {
                        xorg_pri.Text = dttemp6.Rows[i - 1]["xorg"].ToString();
                        xdist_pri.Text = dttemp6.Rows[i - 1]["xdist"].ToString();
                    }


                    dttemp6.Dispose();

                    //////////////
                    /// 
                    /// 
                    /// 
                    /// 

                    ////////////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    str = "SELECT * FROM hredu WHERE zid=@zid AND xemp=@xemp AND xtype='secondery'";

                    SqlDataAdapter da7 = new SqlDataAdapter(str, conn1);

                    da7.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da7.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da7.Fill(dts, "temp");
                    DataTable dttemp7 = new DataTable();
                    dttemp7 = dts.Tables[0];

                    for (int i = 1; i <= dttemp7.Rows.Count; i++)
                    {
                        xorg.Text = dttemp7.Rows[i - 1]["xorg"].ToString();
                        xdist.Text = dttemp7.Rows[i - 1]["xdist"].ToString();
                        xedusys.Text = dttemp7.Rows[i - 1]["xedusys"].ToString();
                        xexamname_sec.Text = dttemp7.Rows[i - 1]["xexamname"].ToString();
                        xboard.Text = dttemp7.Rows[i - 1]["xboard"].ToString();
                        xedugroup.Text = dttemp7.Rows[i - 1]["xedugroup"].ToString();
                        xyear.Text = dttemp7.Rows[i - 1]["xyear"].ToString();
                        xgpa_s.Text = dttemp7.Rows[i - 1]["xresult"].ToString();
                        xpoint_s.Text = dttemp7.Rows[i - 1]["xgpa"].ToString();
                        xnumsub.Text = dttemp7.Rows[i - 1]["xnumsub"].ToString();
                        xnaa.Text = dttemp7.Rows[i - 1]["xnaa"].ToString();
                        xna.Text = dttemp7.Rows[i - 1]["xna"].ToString();
                        xnb.Text = dttemp7.Rows[i - 1]["xnb"].ToString();
                        xnc.Text = dttemp7.Rows[i - 1]["xnc"].ToString();
                    }


                    dttemp7.Dispose();

                    //////////////
                    /// 
                    /// 
                    /// 

                    ////////////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    str = "SELECT * FROM hredu WHERE zid=@zid AND xemp=@xemp AND xtype='highersecondery'";

                    SqlDataAdapter da8 = new SqlDataAdapter(str, conn1);

                    da8.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da8.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da8.Fill(dts, "temp");
                    DataTable dttemp8 = new DataTable();
                    dttemp8 = dts.Tables[0];

                    for (int i = 1; i <= dttemp8.Rows.Count; i++)
                    {
                        xorg_high.Text = dttemp8.Rows[i - 1]["xorg"].ToString();
                        xdist_high.Text = dttemp8.Rows[i - 1]["xdist"].ToString();
                        xedusys_high.Text = dttemp8.Rows[i - 1]["xedusys"].ToString();
                        xexamname_high.Text = dttemp8.Rows[i - 1]["xexamname"].ToString();
                        xboard_high.Text = dttemp8.Rows[i - 1]["xboard"].ToString();
                        xedugroup_high.Text = dttemp8.Rows[i - 1]["xedugroup"].ToString();
                        xyear_high.Text = dttemp8.Rows[i - 1]["xyear"].ToString();
                        xgpa_high.Text = dttemp8.Rows[i - 1]["xresult"].ToString();
                        xpoint_high.Text = dttemp8.Rows[i - 1]["xgpa"].ToString();
                        xnumsub_high.Text = dttemp8.Rows[i - 1]["xnumsub"].ToString();
                        xnaa_high.Text = dttemp8.Rows[i - 1]["xnaa"].ToString();
                        xna_high.Text = dttemp8.Rows[i - 1]["xna"].ToString();
                        xnb_high.Text = dttemp8.Rows[i - 1]["xnb"].ToString();
                        xnc_high.Text = dttemp8.Rows[i - 1]["xnc"].ToString();
                    }


                    dttemp8.Dispose();

                    //////////////
                    /// 
                    /// 

                    ////////////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    str = "SELECT * FROM hredu WHERE zid=@zid AND xemp=@xemp AND xtype='graduation'";

                    SqlDataAdapter da9 = new SqlDataAdapter(str, conn1);

                    da9.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da9.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da9.Fill(dts, "temp");
                    DataTable dttemp9 = new DataTable();
                    dttemp9 = dts.Tables[0];

                    for (int i = 1; i <= dttemp9.Rows.Count; i++)
                    {
                        xunderorg.Text = dttemp9.Rows[i - 1]["xunderorg"].ToString();
                        xcountry.Text = dttemp9.Rows[i - 1]["xcountry"].ToString();
                        xorggs.Text = dttemp9.Rows[i - 1]["xorg"].ToString();
                        xexamname_gra.Text = dttemp9.Rows[i - 1]["xexamname"].ToString();
                        xsubject.Text = dttemp9.Rows[i - 1]["xsubject"].ToString();
                        xyeargs.Text = dttemp9.Rows[i - 1]["xyear"].ToString();
                        xgpa_gs.Text = dttemp9.Rows[i - 1]["xresult"].ToString();
                        xpoint_gs.Text = dttemp9.Rows[i - 1]["xgpa"].ToString();
                        xduration.Text = dttemp9.Rows[i - 1]["xduration"].ToString();
                        xposition.Text = dttemp9.Rows[i - 1]["xposition"].ToString();
                    }


                    dttemp9.Dispose();

                    //////////////
                    /// 
                    /// 
                    /// 
                    /// 


                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    xemp1 = ViewState["xemp"].ToString();

                    dts.Reset();

                    str = "SELECT * FROM hrtrain WHERE zid=@zid AND xemp=@xemp";

                    SqlDataAdapter da10 = new SqlDataAdapter(str, conn1);

                    da10.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da10.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da10.Fill(dts, "temp");
                    DataTable dttemp10 = new DataTable();
                    dttemp10 = dts.Tables[0];
                    placeholder4.Controls.Clear();
                    if (dttemp10.Rows.Count > 0)
                    {

                        ViewState["ctladded4"] = dttemp10.Rows.Count;

                        //placeholder.Controls.Clear();

                        int howMany = (int)ViewState["ctladded4"];
                        for (int i = 1; i <= howMany; i++)
                        {
                            fnCreateControl4(i);
                            ((TextBox)placeholder4.FindControl("txname_train" + i)).Text =
                                dttemp10.Rows[i - 1]["xname"].ToString();
                            ((TextBox)placeholder4.FindControl("txorganised" + i)).Text =
                                dttemp10.Rows[i - 1]["xorganised"].ToString();
                            ((TextBox)placeholder4.FindControl("txvanue" + i)).Text =
                               dttemp10.Rows[i - 1]["xvanue"].ToString();
                            ((TextBox)placeholder4.FindControl("txcountry_train" + i)).Text =
                               dttemp10.Rows[i - 1]["xcountry"].ToString();
                            ((TextBox)placeholder4.FindControl("txtrainer" + i)).Text =
                               dttemp10.Rows[i - 1]["xtrainer"].ToString();
                            ((TextBox)placeholder4.FindControl("txfdate_train" + i)).Text =
                              Convert.ToDateTime(dttemp10.Rows[i - 1]["xfdate"].ToString()).ToString("dd/MM/yyyy");
                            ((TextBox)placeholder4.FindControl("txtdate_train" + i)).Text =
                             Convert.ToDateTime(dttemp10.Rows[i - 1]["xtdate"].ToString()).ToString("dd/MM/yyyy");
                            ((HtmlTextArea)placeholder4.FindControl("txremarks_train" + i)).Value =
                              dttemp10.Rows[i - 1]["xremarks"].ToString();


                        }

                        dttemp10.Dispose();
                    }
                    else
                    {
                        ViewState["ctladded4"] = 1;
                        fnCreateDynamicControlAtPageLoad4();
                    }


                    //////////////
                    /// 
                    /// 


                    dts.Reset();

                    str = "SELECT * FROM hrexp WHERE zid=@zid AND xemp=@xemp";

                    SqlDataAdapter da11 = new SqlDataAdapter(str, conn1);

                    da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da11.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    dts.Reset();
                    da11.Fill(dts, "temp");
                    DataTable dttemp11 = new DataTable();
                    dttemp11 = dts.Tables[0];
                    placeholder5.Controls.Clear();
                    if (dttemp11.Rows.Count > 0)
                    {

                        ViewState["ctladded5"] = dttemp11.Rows.Count;

                        //placeholder.Controls.Clear();

                        int howMany = (int)ViewState["ctladded5"];
                        for (int i = 1; i <= howMany; i++)
                        {
                            fnCreateControl5(i);
                            ((TextBox)placeholder5.FindControl("txorg_exp" + i)).Text =
                                dttemp11.Rows[i - 1]["xorg"].ToString();
                            ((TextBox)placeholder5.FindControl("txlastpos_exp" + i)).Text =
                                dttemp11.Rows[i - 1]["xlastpos"].ToString();
                            ((TextBox)placeholder5.FindControl("txfdate_exp" + i)).Text =
                              Convert.ToDateTime(dttemp11.Rows[i - 1]["xfdate"].ToString()).ToString("dd/MM/yyyy");
                            ((TextBox)placeholder5.FindControl("txtdate_exp" + i)).Text =
                             Convert.ToDateTime(dttemp11.Rows[i - 1]["xtdate"].ToString()).ToString("dd/MM/yyyy");
                            ((HtmlTextArea)placeholder5.FindControl("txreponsibility" + i)).Value =
                              dttemp11.Rows[i - 1]["xreponsibility"].ToString();


                        }

                        dttemp11.Dispose();
                    }
                    else
                    {
                        ViewState["ctladded5"] = 1;
                        fnCreateDynamicControlAtPageLoad5();
                    }


                    ////////////////////////
                    /// 
                    /// 
                    /// 
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    xemp1 = ViewState["xemp"].ToString();
                    //ViewState["xline9"] = ((LinkButton)sender).Text

                    LinkButton lb = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)lb.NamingContainer;
                    int index = row.RowIndex; //gets the row index selected
                    string xline9 = GridView1.Rows[index].Cells[5].Text.Trim().ToString(); // here we are
                    ViewState["xline9"] = xline9;
                    //try
                    //{
                    //    message.InnerHtml = "Hi";
                    //    message.InnerHtml = message.InnerHtml + GridView1.Rows[index].Cells[4].Text.Trim().ToString();
                    //}
                    //catch (Exception exp)
                    //{
                    //    message.InnerHtml = exp.Message + "\n" + exp.Source;

                    //}
                    //return;

                    dts.Reset();

                    str = "SELECT * FROM hrjobs WHERE zid=@zid AND xemp=@xemp AND xline=@xline";

                    SqlDataAdapter da11 = new SqlDataAdapter(str, conn1);

                    da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da11.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    da11.SelectCommand.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                    dts.Reset();
                    da11.Fill(dts, "temp");
                    DataTable dttemp11 = new DataTable();
                    dttemp11 = dts.Tables[0];

                    if (dttemp11.Rows.Count > 0)
                    {
                        //message.InnerHtml = "hi";
                        xposition_job.Text = dttemp11.Rows[0]["xposition"].ToString();
                        xfdate_job.Text = Convert.ToDateTime(dttemp11.Rows[0]["xfdate"].ToString()).ToString("dd/MM/yyyy");
                        xrepons_job.Text = dttemp11.Rows[0]["xrepons"].ToString();
                    }

                    ///////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    str = "SELECT * FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='School'";

                    SqlDataAdapter da12 = new SqlDataAdapter(str, conn1);

                    da12.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da12.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    da12.SelectCommand.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                    dts.Reset();
                    da12.Fill(dts, "temp");
                    DataTable dttemp12 = new DataTable();
                    dttemp12 = dts.Tables[0];

                    string xschool = "";
                    if (dttemp12.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttemp12.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                xschool = dttemp12.Rows[i]["xschool"].ToString();
                            }
                            else
                            {
                                xschool = xschool + " & " + dttemp12.Rows[i]["xschool"].ToString();
                            }
                        }
                    }

                    xschool_job.Text = xschool;

                    ////////////
                    /// 
                    /// 
                    /// 
                    /// 
                    /// 

                    ///////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    str = "SELECT * FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Class'";

                    SqlDataAdapter da13 = new SqlDataAdapter(str, conn1);

                    da13.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da13.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    da13.SelectCommand.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                    dts.Reset();
                    da13.Fill(dts, "temp");
                    DataTable dttemp13 = new DataTable();
                    dttemp13 = dts.Tables[0];

                    //xclass_job.Items.Clear();
                    //if (dttemp13.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dttemp13.Rows.Count; i++)
                    //    {
                    //        xclass_job.Items.Add(dttemp13.Rows[i]["xclass"].ToString());
                    //    }
                    //}


                    ////////////
                    /// 
                    /// 


                    ///////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    str = "SELECT * FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Section'";

                    SqlDataAdapter da14 = new SqlDataAdapter(str, conn1);

                    da14.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da14.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    da14.SelectCommand.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                    dts.Reset();
                    da14.Fill(dts, "temp");
                    DataTable dttemp14 = new DataTable();
                    dttemp14 = dts.Tables[0];

                    //xsection_job.Items.Clear();
                    //if (dttemp14.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dttemp14.Rows.Count; i++)
                    //    {
                    //        xsection_job.Items.Add(dttemp14.Rows[i]["xsection"].ToString());
                    //    }
                    //}


                    ////////////
                    /// 
                    /// 

                    ///////////////////////////
                    /// 
                    /// 

                    dts.Reset();

                    //str = "SELECT * FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject'";
                    str = "select xsubject,xpaper,xsclass,min(xline1) as xline1 from hrjobsd where zid=@zid and xemp=@xemp and xline=@xline and xtype='subject' group by xsubject,xpaper,xsclass order by MIN(xline1)";

                    SqlDataAdapter da19 = new SqlDataAdapter(str, conn1);

                    da19.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da19.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                    da19.SelectCommand.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                    dts.Reset();
                    da19.Fill(dts, "temp");
                    DataTable dttemp19 = new DataTable();
                    dttemp19 = dts.Tables[0];

                    placeholder9.Controls.Clear();
                    if (dttemp19.Rows.Count > 0)
                    {

                        ViewState["ctladded9"] = dttemp19.Rows.Count;

                        //placeholder.Controls.Clear();

                        int howMany = (int)ViewState["ctladded9"];
                        for (int i = 1; i <= howMany; i++)
                        {
                            fnCreateControl9(i);
                            ((DropDownList)placeholder9.FindControl("xsubject_job" + i)).Text =
                                dttemp19.Rows[i - 1]["xsubject"].ToString();
                            ((DropDownList)placeholder9.FindControl("xpaper_job" + i)).Text =
                               dttemp19.Rows[i - 1]["xpaper"].ToString();
                            ((DropDownList)placeholder9.FindControl("xclass_job" + i)).Text =
                               dttemp19.Rows[i - 1]["xsclass"].ToString();
                            //((DropDownList)placeholder9.FindControl("xsection_job" + i)).Text =
                            //  dttemp19.Rows[i - 1]["xssection"].ToString();

                            DataSet dts199 = new DataSet();

                            //str = "SELECT * FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject'";
                            str = "select xssection from hrjobsd where zid=@zid and xemp=@xemp and xline=@xline and xtype='subject' and xsclass=@xsclass ";

                            SqlDataAdapter da199 = new SqlDataAdapter(str, conn1);

                            da199.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da199.SelectCommand.Parameters.AddWithValue("@xemp", xemp1);
                            da199.SelectCommand.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                            da199.SelectCommand.Parameters.AddWithValue("@xsclass", dttemp19.Rows[i - 1]["xsclass"].ToString());
                            dts199.Reset();
                            da199.Fill(dts199, "temp");
                            DataTable dttemp199 = new DataTable();
                            dttemp199 = dts199.Tables[0];
                            if (dttemp199.Rows.Count > 0 && dttemp199.Rows[0][0].ToString() != "")
                            {
                                for (int j = 0; j < dttemp199.Rows.Count; j++)
                                {
                                    foreach (ListItem item in ((CheckBoxList)placeholder9.FindControl("xsection_job" + i)).Items)
                                    {
                                        if (item.Text == dttemp199.Rows[j][0].ToString())
                                        {
                                            item.Selected = true;
                                            item.Attributes.Add("style", "color:#0000FF");
                                        }
                                    }
                                }
                            }

                            //dts199.Dispose();
                            //da199.Dispose();

                        }

                        dttemp19.Dispose();
                    }
                    else
                    {
                        ViewState["ctladded9"] = 1;
                        fnCreateDynamicControlAtPageLoad9();
                    }


                    ////////////
                    /// 
                    /// 

                }


                //ViewState["xemp"] = ((LinkButton)sender).Text;
                //xempd.Text = ViewState["xemp"].ToString();
                //xnamed.Text = dtztcode.Rows[0]["xname"].ToString();
                //_row.Value = ((LinkButton)sender).Text;
                dts.Dispose();

                conn1.Dispose();

                message.InnerHtml = "";

                fnChkSubmited();

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

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["ctladded3"] == null)
            {
                ViewState["ctladded3"] = 1;
            }

            ViewState["ctladded3"] = 1 + (int)ViewState["ctladded3"];



            fnCreateControl3((int)ViewState["ctladded3"]);

        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["ctladded4"] == null)
            {
                ViewState["ctladded4"] = 1;
            }

            ViewState["ctladded4"] = 1 + (int)ViewState["ctladded4"];



            fnCreateControl4((int)ViewState["ctladded4"]);

        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["ctladded5"] == null)
            {
                ViewState["ctladded5"] = 1;
            }

            ViewState["ctladded5"] = 1 + (int)ViewState["ctladded5"];



            fnCreateControl5((int)ViewState["ctladded5"]);

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

        protected void fnCreateDynamicControlAtPageLoad3()
        {
            if (ViewState["ctladded3"] != null)
            {
                int howMany = (int)ViewState["ctladded3"];
                for (int i = 1; i <= howMany; i++)
                {
                    fnCreateControl3(i);
                }
            }
        }

        protected void fnCreateDynamicControlAtPageLoad4()
        {
            if (ViewState["ctladded4"] != null)
            {
                int howMany = (int)ViewState["ctladded4"];
                for (int i = 1; i <= howMany; i++)
                {
                    fnCreateControl4(i);
                }
            }
        }

        protected void fnCreateDynamicControlAtPageLoad5()
        {
            if (ViewState["ctladded5"] != null)
            {
                int howMany = (int)ViewState["ctladded5"];
                for (int i = 1; i <= howMany; i++)
                {
                    fnCreateControl5(i);
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
                mtxt2.Text = "Presidency International School";


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

        private void fnCreateControl3(int k)
        {
            try
            {

                HtmlGenericControl fieldset = new HtmlGenericControl("fieldset");
                HtmlGenericControl legend = new HtmlGenericControl("legend");
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                HtmlGenericControl div11 = new HtmlGenericControl("div");
                HtmlGenericControl div111 = new HtmlGenericControl("div");
                HtmlGenericControl div1111 = new HtmlGenericControl("div");
                HtmlGenericControl div1112 = new HtmlGenericControl("div");
                HtmlGenericControl div12 = new HtmlGenericControl("div");
                HtmlGenericControl div121 = new HtmlGenericControl("div");
                HtmlGenericControl div1211 = new HtmlGenericControl("div");
                HtmlGenericControl div1212 = new HtmlGenericControl("div");
                HtmlGenericControl div2 = new HtmlGenericControl("div");
                HtmlGenericControl div3 = new HtmlGenericControl("div");
                HtmlGenericControl div31 = new HtmlGenericControl("div");
                HtmlGenericControl div32 = new HtmlGenericControl("div");
                HtmlGenericControl div4 = new HtmlGenericControl("div");
                HtmlGenericControl div5 = new HtmlGenericControl("div");
                HtmlGenericControl div51 = new HtmlGenericControl("div");
                HtmlGenericControl div52 = new HtmlGenericControl("div");
                HtmlGenericControl div6 = new HtmlGenericControl("div");
                HtmlGenericControl div7 = new HtmlGenericControl("div");
                HtmlGenericControl div71 = new HtmlGenericControl("div");
                HtmlGenericControl div72 = new HtmlGenericControl("div");
                HtmlGenericControl div8 = new HtmlGenericControl("div");
                HtmlGenericControl div9 = new HtmlGenericControl("div");
                HtmlGenericControl div91 = new HtmlGenericControl("div");
                HtmlGenericControl div911 = new HtmlGenericControl("div");
                HtmlGenericControl div9111 = new HtmlGenericControl("div");
                HtmlGenericControl div91111 = new HtmlGenericControl("div");
                HtmlGenericControl div91112 = new HtmlGenericControl("div");
                HtmlGenericControl div912 = new HtmlGenericControl("div");
                HtmlGenericControl div9121 = new HtmlGenericControl("div");
                HtmlGenericControl div91211 = new HtmlGenericControl("div");
                HtmlGenericControl div91212 = new HtmlGenericControl("div");
                HtmlGenericControl div92 = new HtmlGenericControl("div");
                HtmlGenericControl div921 = new HtmlGenericControl("div");
                HtmlGenericControl div9211 = new HtmlGenericControl("div");
                HtmlGenericControl div92111 = new HtmlGenericControl("div");
                HtmlGenericControl div92112 = new HtmlGenericControl("div");
                HtmlGenericControl div10 = new HtmlGenericControl("div");
                HtmlGenericControl div_1 = new HtmlGenericControl("div");
                HtmlGenericControl div_11 = new HtmlGenericControl("div");
                HtmlGenericControl div_111 = new HtmlGenericControl("div");
                HtmlGenericControl div_1111 = new HtmlGenericControl("div");
                HtmlGenericControl div_1112 = new HtmlGenericControl("div");
                HtmlGenericControl div_12 = new HtmlGenericControl("div");
                HtmlGenericControl div_121 = new HtmlGenericControl("div");
                HtmlGenericControl div_1211 = new HtmlGenericControl("div");
                HtmlGenericControl div_1212 = new HtmlGenericControl("div");

                legend.InnerText = "Post Graduation";
                div1.Attributes["style"] = "width: 100%;";
                div11.Attributes["class"] = "float_left";
                div11.Attributes["style"] = "width: 75%";
                div111.Attributes["class"] = "bm_ctl_container_100_50";
                div111.Attributes["style"] = "width: 100%";
                div1111.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div1111.Attributes["style"] = "width: 31%";
                div1112.Attributes["class"] = "bm_clt_ctl_100_50";
                div1112.Attributes["style"] = "width: 69%";
                div12.Attributes["class"] = "float_left";
                div12.Attributes["style"] = "width: 24%; margin-left: 5px;";
                div121.Attributes["class"] = "bm_ctl_container_100_20";
                div121.Attributes["style"] = "width: 100%";
                div1211.Attributes["class"] = "bm_ctl_label_align_right_100_20";
                div1211.Attributes["style"] = "width: 38%;";
                div1212.Attributes["class"] = "bm_clt_ctl_100_20";
                div1212.Attributes["style"] = "width: 62%;";
                div2.Attributes["class"] = "bm_clt_padding";
                div3.Attributes["class"] = "bm_ctl_container_100_50";
                div3.Attributes["style"] = "width: 75%;";
                div31.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div31.Attributes["style"] = "width: 31%;";
                div32.Attributes["class"] = "bm_clt_ctl_100_50";
                div32.Attributes["style"] = "width: 69%;";
                div4.Attributes["class"] = "bm_clt_padding";
                div5.Attributes["class"] = "bm_ctl_container_100_50";
                div5.Attributes["style"] = "width: 75%;";
                div51.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div51.Attributes["style"] = "width: 31%;";
                div52.Attributes["class"] = "bm_clt_ctl_100_50";
                div52.Attributes["style"] = "width: 69%;";
                div6.Attributes["class"] = "bm_clt_padding";
                div7.Attributes["class"] = "bm_ctl_container_100_50";
                div7.Attributes["style"] = "width: 75%;";
                div71.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div71.Attributes["style"] = "width: 31%;";
                div72.Attributes["class"] = "bm_clt_ctl_100_50";
                div72.Attributes["style"] = "width: 69%;";
                div8.Attributes["class"] = "bm_clt_padding";
                div9.Attributes["style"] = "width: 100%;";
                div91.Attributes["style"] = "width: 75%; float: left";
                div911.Attributes["class"] = "float_left";
                div911.Attributes["style"] = "width: 55%;";
                div9111.Attributes["class"] = "bm_ctl_container_100_50";
                div9111.Attributes["style"] = "width: 100%";
                div91111.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div91111.Attributes["style"] = "width: 56.8%;";
                div91112.Attributes["class"] = "bm_clt_ctl_100_50";
                div91112.Attributes["style"] = "width: 43.2%;";
                div912.Attributes["class"] = "float_left";
                div912.Attributes["style"] = "width: 43%; margin-left: 9.9px;";
                div9121.Attributes["class"] = "bm_ctl_container_100_50";
                div9121.Attributes["style"] = "width: 100%";
                div91211.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div91211.Attributes["style"] = "width: 40%;";
                div91212.Attributes["class"] = "bm_clt_ctl_100_50";
                div91212.Attributes["style"] = "width: 60%;";
                div92.Attributes["style"] = "width: 16%; float: left";
                div921.Attributes["class"] = "float_left";
                div921.Attributes["style"] = "width: 100%; margin-left: 5px;";
                div9211.Attributes["class"] = "bm_ctl_container_100_50";
                div9211.Attributes["style"] = "width: 100%;";
                div92111.Attributes["class"] = "bm_ctl_label_align_right_100_20";
                div92111.Attributes["style"] = "width: 60%;";
                div92112.Attributes["class"] = "bm_clt_ctl_100_20";
                div92112.Attributes["style"] = "width: 40%;";
                div10.Attributes["class"] = "bm_clt_padding";
                div_1.Attributes["style"] = "width: 75%;";
                div_11.Attributes["class"] = "float_left";
                div_11.Attributes["style"] = "width: 55%;";
                div_111.Attributes["class"] = "bm_ctl_container_100_50";
                div_111.Attributes["style"] = "width: 100%;";
                div_1111.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div_1111.Attributes["style"] = "width: 56.8%;";
                div_1112.Attributes["class"] = "bm_clt_ctl_100_50";
                div_1112.Attributes["style"] = "width: 43.2%;";
                div_12.Attributes["class"] = "float_left";
                div_12.Attributes["style"] = "width: 43%; margin-left: 9.9px;";
                div_121.Attributes["class"] = "bm_ctl_container_100_50";
                div_121.Attributes["style"] = "width: 100%;";
                div_1211.Attributes["class"] = "bm_ctl_label_align_right_100_50";
                div_1211.Attributes["style"] = "width: 40%;";
                div_1212.Attributes["class"] = "bm_clt_ctl_100_50";
                div_1212.Attributes["style"] = "width: 60%;";



                placeholder3.Controls.Add(fieldset);
                fieldset.Controls.Add(legend);
                fieldset.Controls.Add(div1);
                div1.Controls.Add(div11);
                div11.Controls.Add(div111);
                div111.Controls.Add(div1111);
                div111.Controls.Add(div1112);
                div1.Controls.Add(div12);
                div12.Controls.Add(div121);
                div121.Controls.Add(div1211);
                div121.Controls.Add(div1212);
                fieldset.Controls.Add(div2);
                fieldset.Controls.Add(div3);
                div3.Controls.Add(div31);
                div3.Controls.Add(div32);
                fieldset.Controls.Add(div4);
                fieldset.Controls.Add(div5);
                div5.Controls.Add(div51);
                div5.Controls.Add(div52);
                fieldset.Controls.Add(div6);
                fieldset.Controls.Add(div7);
                div7.Controls.Add(div71);
                div7.Controls.Add(div72);
                fieldset.Controls.Add(div8);
                fieldset.Controls.Add(div9);
                div9.Controls.Add(div91);
                div91.Controls.Add(div911);
                div911.Controls.Add(div9111);
                div9111.Controls.Add(div91111);
                div9111.Controls.Add(div91112);
                div91.Controls.Add(div912);
                div912.Controls.Add(div9121);
                div9121.Controls.Add(div91211);
                div9121.Controls.Add(div91212);
                div9.Controls.Add(div92);
                div92.Controls.Add(div921);
                div921.Controls.Add(div9211);
                div9211.Controls.Add(div92111);
                div9211.Controls.Add(div92112);
                fieldset.Controls.Add(div10);
                fieldset.Controls.Add(div_1);
                div_1.Controls.Add(div_11);
                div_11.Controls.Add(div_111);
                div_111.Controls.Add(div_1111);
                div_111.Controls.Add(div_1112);
                div_1.Controls.Add(div_12);
                div_12.Controls.Add(div_121);
                div_121.Controls.Add(div_1211);
                div_121.Controls.Add(div_1212);


                Label lblxunderorg_post = new Label();
                TextBox txtxunderorg_post = new TextBox();
                Label lblxcountry_post = new Label();
                TextBox txtxcountry_post = new TextBox();
                Label lblxorg_post = new Label();
                TextBox txtxorg_post = new TextBox();
                Label lblxexamname_post = new Label();
                DropDownList dwxexamname_post = new DropDownList();
                Label lblxsubject_post = new Label();
                DropDownList dwxsubject_post = new DropDownList();
                Label lblxyear_post = new Label();
                DropDownList dwxyear_post = new DropDownList();
                Label lblxgpa_post = new Label();
                DropDownList dwxgpa_post = new DropDownList();
                Label lblxpoint_post = new Label();
                TextBox txtxpoint_post = new TextBox();
                Label lblxduration_post = new Label();
                DropDownList dwxduration_post = new DropDownList();
                Label lblxposition_post = new Label();
                DropDownList dwxposition_post = new DropDownList();


                lblxunderorg_post.CssClass = "label";
                txtxunderorg_post.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox";
                lblxcountry_post.CssClass = "label";
                txtxcountry_post.CssClass = "bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox";
                lblxorg_post.CssClass = "label";
                txtxorg_post.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox";
                lblxexamname_post.CssClass = "label";
                dwxexamname_post.CssClass = "bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown";
                lblxsubject_post.CssClass = "label";
                dwxsubject_post.CssClass = "bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown";
                lblxyear_post.CssClass = "label";
                dwxyear_post.CssClass = "bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown";
                lblxgpa_post.CssClass = "label";
                dwxgpa_post.CssClass = "bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_dropdown";
                lblxpoint_post.CssClass = "label";
                txtxpoint_post.CssClass = "bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox";
                lblxduration_post.CssClass = "label";
                dwxduration_post.CssClass = "bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown";
                lblxposition_post.CssClass = "label";
                dwxposition_post.CssClass = "bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown";


                //mylbl.Text = k.ToString() + ".";
                lblxunderorg_post.Text = "Graduation Under/From";
                lblxcountry_post.Text = "Country";
                lblxorg_post.Text = "University/ College :";
                lblxexamname_post.Text = "Name of Degree :";
                lblxsubject_post.Text = "Subject :";
                lblxyear_post.Text = "Passing Year :";
                lblxgpa_post.Text = "Class/GPA :";
                lblxpoint_post.Text = "Point :";
                lblxduration_post.Text = "Course Duration :";
                lblxposition_post.Text = "Position :";


                lblxunderorg_post.ID = "lblxunderorg_post" + k.ToString();
                txtxunderorg_post.ID = "txtxunderorg_post" + k.ToString();
                lblxcountry_post.ID = "lblxcountry_post" + k.ToString();
                txtxcountry_post.ID = "txtxcountry_post" + k.ToString();
                lblxorg_post.ID = "lblxorg_post" + k.ToString();
                txtxorg_post.ID = "txtxorg_post" + k.ToString();
                lblxexamname_post.ID = "lblxexamname_post" + k.ToString();
                dwxexamname_post.ID = "dwxexamname_post" + k.ToString();
                lblxsubject_post.ID = "lblxsubject_post" + k.ToString();
                dwxsubject_post.ID = "dwxsubject_post" + k.ToString();
                lblxyear_post.ID = "lblxyear_post" + k.ToString();
                dwxyear_post.ID = "dwxyear_post" + k.ToString();
                lblxgpa_post.ID = "lblxgpa_post" + k.ToString();
                dwxgpa_post.ID = "dwxgpa_post" + k.ToString();
                lblxpoint_post.ID = "lblxpoint_post" + k.ToString();
                txtxpoint_post.ID = "txtxpoint_post" + k.ToString();
                lblxduration_post.ID = "lblxduration_post" + k.ToString();
                dwxduration_post.ID = "dwxduration_post" + k.ToString();
                lblxposition_post.ID = "lblxposition_post" + k.ToString();
                dwxposition_post.ID = "dwxposition_post" + k.ToString();

                zglobal.fnGetComboDataCD("Name of Exam", "school", dwxexamname_post, 4, 1);
                zglobal.fnGetComboDataCD(dwxyear_post);

                dwxgpa_post.Items.Clear();
                dwxgpa_post.Items.Add("");
                dwxgpa_post.Items.Add("1st Class");
                dwxgpa_post.Items.Add("2nd Class");
                dwxgpa_post.Items.Add("3rd Class");
                dwxgpa_post.Items.Add("GPA");
                dwxgpa_post.Text = "";

                zglobal.fnGetComboDataCD("Subject", dwxsubject_post);

                dwxduration_post.Items.Clear();
                dwxduration_post.Items.Add("");
                dwxduration_post.Items.Add("1 Years");
                dwxduration_post.Items.Add("2 Years");
                dwxduration_post.Text = "";

                dwxposition_post.Items.Clear();
                dwxposition_post.Items.Add("");
                for (int i = 1; i <= 20; i++)
                {
                    if (i == 1)
                    {
                        dwxposition_post.Items.Add(i.ToString() + "st Position");
                    }
                    else if (i == 2)
                    {
                        dwxposition_post.Items.Add(i.ToString() + "nd Position");
                    }
                    else if (i == 3)
                    {
                        dwxposition_post.Items.Add(i.ToString() + "rd Position");
                    }
                    else
                    {
                        dwxposition_post.Items.Add(i.ToString() + "th Position");
                    }
                }
                dwxposition_post.Text = "";

                txtxunderorg_post.EnableViewState = true;
                txtxcountry_post.EnableViewState = true;
                txtxorg_post.EnableViewState = true;
                dwxexamname_post.EnableViewState = true;
                dwxsubject_post.EnableViewState = true;
                dwxyear_post.EnableViewState = true;
                dwxgpa_post.EnableViewState = true;
                txtxpoint_post.EnableViewState = true;
                dwxduration_post.EnableViewState = true;
                dwxposition_post.EnableViewState = true;

                div1111.Controls.Add(lblxunderorg_post);
                div1112.Controls.Add(txtxunderorg_post);
                div1211.Controls.Add(lblxcountry_post);
                div1212.Controls.Add(txtxcountry_post);
                div31.Controls.Add(lblxorg_post);
                div32.Controls.Add(txtxorg_post);
                div51.Controls.Add(lblxexamname_post);
                div52.Controls.Add(dwxexamname_post);
                div71.Controls.Add(lblxsubject_post);
                div72.Controls.Add(dwxsubject_post);
                div91111.Controls.Add(lblxyear_post);
                div91112.Controls.Add(dwxyear_post);
                div91211.Controls.Add(lblxgpa_post);
                div91212.Controls.Add(dwxgpa_post);
                div92111.Controls.Add(lblxpoint_post);
                div92112.Controls.Add(txtxpoint_post);
                div_1111.Controls.Add(lblxduration_post);
                div_1112.Controls.Add(dwxduration_post);
                div_1211.Controls.Add(lblxposition_post);
                div_1212.Controls.Add(dwxposition_post);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        private void fnCreateControl4(int k)
        {
            try
            {

                HtmlGenericControl fieldset = new HtmlGenericControl("fieldset");
                HtmlGenericControl legend = new HtmlGenericControl("legend");
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                HtmlGenericControl div11 = new HtmlGenericControl("div");
                HtmlGenericControl div12 = new HtmlGenericControl("div");
                HtmlGenericControl div2 = new HtmlGenericControl("div");
                HtmlGenericControl div3 = new HtmlGenericControl("div");
                HtmlGenericControl div31 = new HtmlGenericControl("div");
                HtmlGenericControl div32 = new HtmlGenericControl("div");
                HtmlGenericControl div4 = new HtmlGenericControl("div");
                HtmlGenericControl div5 = new HtmlGenericControl("div");
                HtmlGenericControl div51 = new HtmlGenericControl("div");
                HtmlGenericControl div52 = new HtmlGenericControl("div");
                HtmlGenericControl div6 = new HtmlGenericControl("div");
                HtmlGenericControl div7 = new HtmlGenericControl("div");
                HtmlGenericControl div71 = new HtmlGenericControl("div");
                HtmlGenericControl div72 = new HtmlGenericControl("div");
                HtmlGenericControl div8 = new HtmlGenericControl("div");
                HtmlGenericControl div9 = new HtmlGenericControl("div");
                HtmlGenericControl div91 = new HtmlGenericControl("div");
                HtmlGenericControl div92 = new HtmlGenericControl("div");
                HtmlGenericControl div01 = new HtmlGenericControl("div");
                HtmlGenericControl div02 = new HtmlGenericControl("div");
                HtmlGenericControl div021 = new HtmlGenericControl("div");
                HtmlGenericControl div0211 = new HtmlGenericControl("div");
                HtmlGenericControl div02111 = new HtmlGenericControl("div");
                HtmlGenericControl div02112 = new HtmlGenericControl("div");
                HtmlGenericControl div022 = new HtmlGenericControl("div");
                HtmlGenericControl div023 = new HtmlGenericControl("div");
                HtmlGenericControl div0231 = new HtmlGenericControl("div");
                HtmlGenericControl div02311 = new HtmlGenericControl("div");
                HtmlGenericControl div03 = new HtmlGenericControl("div");
                HtmlGenericControl div04 = new HtmlGenericControl("div");
                HtmlGenericControl div041 = new HtmlGenericControl("div");
                HtmlGenericControl div0411 = new HtmlGenericControl("div");
                HtmlGenericControl div042 = new HtmlGenericControl("div");
                HtmlGenericControl div0421 = new HtmlGenericControl("div");

                legend.InnerText = "Training/ Courses/ Workshop (" + k.ToString() + ")";
                div1.Attributes["class"] = "bm_ctl_container_50_100";
                div11.Attributes["class"] = "bm_ctl_label_align_right_50_100";
                div12.Attributes["class"] = "bm_clt_ctl_50_100";
                div2.Attributes["class"] = "bm_clt_padding";
                div3.Attributes["class"] = "bm_ctl_container_50_100";
                div31.Attributes["class"] = "bm_ctl_label_align_right_50_100";
                div32.Attributes["class"] = "bm_clt_ctl_50_100";
                div4.Attributes["class"] = "bm_clt_padding";
                div5.Attributes["class"] = "bm_ctl_container_50_100";
                div51.Attributes["class"] = "bm_ctl_label_align_right_50_100";
                div52.Attributes["class"] = "bm_clt_ctl_50_100";
                div6.Attributes["class"] = "bm_clt_padding";
                div7.Attributes["class"] = "bm_ctl_container_50_100";
                div71.Attributes["class"] = "bm_ctl_label_align_right_50_100";
                div72.Attributes["class"] = "bm_clt_ctl_50_100";
                div8.Attributes["class"] = "bm_clt_padding";
                div9.Attributes["class"] = "bm_ctl_container_50_100";
                div91.Attributes["class"] = "bm_ctl_label_align_right_50_100";
                div92.Attributes["class"] = "bm_clt_ctl_50_100";
                div01.Attributes["class"] = "bm_clt_padding";
                div02.Attributes["style"] = "width: 100%";
                div021.Attributes["style"] = "float: left; width: 50%;";
                div0211.Attributes["class"] = "bm_ctl_container_50_50";
                div0211.Attributes["style"] = "width: 100%";
                div02111.Attributes["class"] = "bm_ctl_label_align_right_50_50";
                div02112.Attributes["class"] = "bm_clt_ctl_50_50";
                div022.Attributes["style"] = "float: left; width: 2%; margin-left: 10px; line-height: 1.8em;";
                div022.InnerText = "to";
                div023.Attributes["style"] = "float: left; width: 21%; margin-left: 1px;";
                div0231.Attributes["class"] = "bm_ctl_container_50_50";
                div0231.Attributes["style"] = "width: 100%;";
                div02311.Attributes["class"] = "bm_clt_ctl_50_50";
                div02311.Attributes["style"] = "width: 100%;";
                div03.Attributes["class"] = "bm_clt_padding";
                div04.Attributes["class"] = "bm_ctl_container_dynamic_100_80";
                div04.Attributes["style"] = "width: 100%";
                div041.Attributes["class"] = "bm_ctl_container_dynamic_100_80_l";
                div041.Attributes["style"] = "width: 28.8%";
                div0411.Attributes["class"] = "bm_ctl_label_align_right_dynamic_100_80_l";
                div042.Attributes["class"] = "bm_clt_ctl_dynamic_100_80";
                div042.Attributes["style"] = "width: 70%";
                div0421.Attributes["class"] = "_ctl_padding";



                placeholder4.Controls.Add(fieldset);
                fieldset.Controls.Add(legend);
                fieldset.Controls.Add(div1);
                div1.Controls.Add(div11);
                div1.Controls.Add(div12);
                fieldset.Controls.Add(div2);
                fieldset.Controls.Add(div3);
                div3.Controls.Add(div31);
                div3.Controls.Add(div32);
                fieldset.Controls.Add(div4);
                fieldset.Controls.Add(div5);
                div5.Controls.Add(div51);
                div5.Controls.Add(div52);
                fieldset.Controls.Add(div6);
                fieldset.Controls.Add(div7);
                div7.Controls.Add(div71);
                div7.Controls.Add(div72);
                fieldset.Controls.Add(div8);
                fieldset.Controls.Add(div9);
                div9.Controls.Add(div91);
                div9.Controls.Add(div92);
                fieldset.Controls.Add(div01);
                fieldset.Controls.Add(div02);
                div02.Controls.Add(div021);
                div021.Controls.Add(div0211);
                div0211.Controls.Add(div02111);
                div0211.Controls.Add(div02112);
                div02.Controls.Add(div022);
                div02.Controls.Add(div023);
                div023.Controls.Add(div0231);
                div0231.Controls.Add(div02311);
                fieldset.Controls.Add(div03);
                fieldset.Controls.Add(div04);
                div04.Controls.Add(div041);
                div041.Controls.Add(div0411);
                div04.Controls.Add(div042);
                div042.Controls.Add(div0421);


                Label lxname_train = new Label();
                TextBox txname_train = new TextBox();
                Label lxorganised = new Label();
                TextBox txorganised = new TextBox();
                Label lxvanue = new Label();
                TextBox txvanue = new TextBox();
                Label lxcountry_train = new Label();
                TextBox txcountry_train = new TextBox();
                Label lxtrainer = new Label();
                TextBox txtrainer = new TextBox();
                Label lxfdate_train = new Label();
                TextBox txfdate_train = new TextBox();
                TextBox txtdate_train = new TextBox();
                Label lxremarks_train = new Label();
                HtmlTextArea txremarks_train = new HtmlTextArea();


                lxname_train.CssClass = "label";
                txname_train.CssClass = "bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox";
                lxorganised.CssClass = "label";
                txorganised.CssClass = "bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox";
                lxvanue.CssClass = "label";
                txvanue.CssClass = "bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox";
                lxcountry_train.CssClass = "label";
                txcountry_train.CssClass = "bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox";
                lxtrainer.CssClass = "label";
                txtrainer.CssClass = "bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox";
                lxfdate_train.CssClass = "label";
                txfdate_train.CssClass = "bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker";
                txtdate_train.CssClass = "bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker";
                lxfdate_train.CssClass = "lxremarks_train";
                txremarks_train.Attributes["class"] = "bm_academic_textarea_100_50  bm_academic_textarea";
                lxremarks_train.CssClass = "label";
                txremarks_train.Attributes["style"] = "width:380px";


                //mylbl.Text = k.ToString() + ".";
                lxname_train.Text = "Title :";
                lxorganised.Text = "Organized By :";
                lxvanue.Text = "Venue :";
                lxcountry_train.Text = "Country :";
                lxtrainer.Text = "Trainer :";
                lxfdate_train.Text = "Course Duration :";
                lxremarks_train.Text = "Description :";

                lxname_train.ID = "lxname_train" + k.ToString();
                txname_train.ID = "txname_train" + k.ToString();
                lxorganised.ID = "lxorganised" + k.ToString();
                txorganised.ID = "txorganised" + k.ToString();
                lxvanue.ID = "lxvanue" + k.ToString();
                txvanue.ID = "txvanue" + k.ToString();
                lxcountry_train.ID = "lxcountry_train" + k.ToString();
                txcountry_train.ID = "txcountry_train" + k.ToString();
                lxtrainer.ID = "lxtrainer" + k.ToString();
                txtrainer.ID = "txtrainer" + k.ToString();
                lxfdate_train.ID = "lxfdate_train" + k.ToString();
                txfdate_train.ID = "txfdate_train" + k.ToString();
                txtdate_train.ID = "txtdate_train" + k.ToString();
                lxremarks_train.ID = "lxremarks_train" + k.ToString();
                txremarks_train.ID = "txremarks_train" + k.ToString();


                txname_train.EnableViewState = true;
                txorganised.EnableViewState = true;
                txvanue.EnableViewState = true;
                txcountry_train.EnableViewState = true;
                txtrainer.EnableViewState = true;
                txfdate_train.EnableViewState = true;
                txtdate_train.EnableViewState = true;
                txremarks_train.EnableViewState = true;

                div11.Controls.Add(lxname_train);
                div12.Controls.Add(txname_train);
                div31.Controls.Add(lxorganised);
                div32.Controls.Add(txorganised);
                div51.Controls.Add(lxvanue);
                div52.Controls.Add(txvanue);
                div71.Controls.Add(lxcountry_train);
                div72.Controls.Add(txcountry_train);
                div91.Controls.Add(lxtrainer);
                div92.Controls.Add(txtrainer);
                div02111.Controls.Add(lxfdate_train);
                div02112.Controls.Add(txfdate_train);
                div02311.Controls.Add(txtdate_train);
                div0411.Controls.Add(lxremarks_train);
                div0421.Controls.Add(txremarks_train);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        private void fnCreateControl5(int k)
        {
            try
            {

                HtmlGenericControl fieldset = new HtmlGenericControl("fieldset");
                HtmlGenericControl legend = new HtmlGenericControl("legend");
                HtmlGenericControl div7 = new HtmlGenericControl("div");
                HtmlGenericControl div71 = new HtmlGenericControl("div");
                HtmlGenericControl div72 = new HtmlGenericControl("div");
                HtmlGenericControl div8 = new HtmlGenericControl("div");
                HtmlGenericControl div9 = new HtmlGenericControl("div");
                HtmlGenericControl div91 = new HtmlGenericControl("div");
                HtmlGenericControl div92 = new HtmlGenericControl("div");
                HtmlGenericControl div01 = new HtmlGenericControl("div");
                HtmlGenericControl div02 = new HtmlGenericControl("div");
                HtmlGenericControl div021 = new HtmlGenericControl("div");
                HtmlGenericControl div0211 = new HtmlGenericControl("div");
                HtmlGenericControl div02111 = new HtmlGenericControl("div");
                HtmlGenericControl div02112 = new HtmlGenericControl("div");
                HtmlGenericControl div022 = new HtmlGenericControl("div");
                HtmlGenericControl div023 = new HtmlGenericControl("div");
                HtmlGenericControl div0231 = new HtmlGenericControl("div");
                HtmlGenericControl div02311 = new HtmlGenericControl("div");
                HtmlGenericControl div03 = new HtmlGenericControl("div");
                HtmlGenericControl div04 = new HtmlGenericControl("div");
                HtmlGenericControl div041 = new HtmlGenericControl("div");
                HtmlGenericControl div0411 = new HtmlGenericControl("div");
                HtmlGenericControl div042 = new HtmlGenericControl("div");
                HtmlGenericControl div0421 = new HtmlGenericControl("div");

                legend.InnerText = "Experiances " + k.ToString();
                div7.Attributes["class"] = "bm_ctl_container_50_100";
                div71.Attributes["class"] = "bm_ctl_label_align_right_50_100";
                div72.Attributes["class"] = "bm_clt_ctl_50_100";
                div8.Attributes["class"] = "bm_clt_padding";
                div9.Attributes["class"] = "bm_ctl_container_50_100";
                div91.Attributes["class"] = "bm_ctl_label_align_right_50_100";
                div92.Attributes["class"] = "bm_clt_ctl_50_100";
                div01.Attributes["class"] = "bm_clt_padding";
                div02.Attributes["style"] = "width: 100%";
                div021.Attributes["style"] = "float: left; width: 50%;";
                div0211.Attributes["class"] = "bm_ctl_container_50_50";
                div0211.Attributes["style"] = "width: 100%";
                div02111.Attributes["class"] = "bm_ctl_label_align_right_50_50";
                div02112.Attributes["class"] = "bm_clt_ctl_50_50";
                div022.Attributes["style"] = "float: left; width: 2%; margin-left: 10px; line-height: 1.8em;";
                div022.InnerText = "to";
                div023.Attributes["style"] = "float: left; width: 21%; margin-left: 1px;";
                div0231.Attributes["class"] = "bm_ctl_container_50_50";
                div0231.Attributes["style"] = "width: 100%;";
                div02311.Attributes["class"] = "bm_clt_ctl_50_50";
                div02311.Attributes["style"] = "width: 100%;";
                div03.Attributes["class"] = "bm_clt_padding";
                div04.Attributes["class"] = "bm_ctl_container_dynamic_100_80";
                div04.Attributes["style"] = "width: 100%";
                div041.Attributes["class"] = "bm_ctl_container_dynamic_100_80_l";
                div041.Attributes["style"] = "width: 28.8%";
                div0411.Attributes["class"] = "bm_ctl_label_align_right_dynamic_100_80_l";
                div042.Attributes["class"] = "bm_clt_ctl_dynamic_100_80";
                div042.Attributes["style"] = "width: 70%";
                div0421.Attributes["class"] = "_ctl_padding";



                placeholder5.Controls.Add(fieldset);
                fieldset.Controls.Add(legend);
                fieldset.Controls.Add(div7);
                div7.Controls.Add(div71);
                div7.Controls.Add(div72);
                fieldset.Controls.Add(div8);
                fieldset.Controls.Add(div9);
                div9.Controls.Add(div91);
                div9.Controls.Add(div92);
                fieldset.Controls.Add(div01);
                fieldset.Controls.Add(div02);
                div02.Controls.Add(div021);
                div021.Controls.Add(div0211);
                div0211.Controls.Add(div02111);
                div0211.Controls.Add(div02112);
                div02.Controls.Add(div022);
                div02.Controls.Add(div023);
                div023.Controls.Add(div0231);
                div0231.Controls.Add(div02311);
                fieldset.Controls.Add(div03);
                fieldset.Controls.Add(div04);
                div04.Controls.Add(div041);
                div041.Controls.Add(div0411);
                div04.Controls.Add(div042);
                div042.Controls.Add(div0421);



                Label lxorg_exp = new Label();
                TextBox txorg_exp = new TextBox();
                Label lxlastpos_exp = new Label();
                TextBox txlastpos_exp = new TextBox();
                Label lxfdate_exp = new Label();
                TextBox txfdate_exp = new TextBox();
                TextBox txtdate_exp = new TextBox();
                Label lxreponsibility = new Label();
                HtmlTextArea txreponsibility = new HtmlTextArea();



                lxorg_exp.CssClass = "label";
                txorg_exp.CssClass = "bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox";
                lxlastpos_exp.CssClass = "label";
                txlastpos_exp.CssClass = "bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox";
                lxfdate_exp.CssClass = "label";
                txfdate_exp.CssClass = "bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker";
                txtdate_exp.CssClass = "bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker";
                lxfdate_exp.CssClass = "lxremarks_train";
                txreponsibility.Attributes["class"] = "bm_academic_textarea_100_50  bm_academic_textarea";
                lxreponsibility.CssClass = "label";
                txreponsibility.Attributes["style"] = "width:380px";


                //mylbl.Text = k.ToString() + ".";

                lxorg_exp.Text = "Organisation :";
                lxlastpos_exp.Text = "Last Position :";
                lxfdate_exp.Text = "Duration :";
                lxreponsibility.Text = "Responsibilities :";


                lxorg_exp.ID = "lxorg_exp" + k.ToString();
                txorg_exp.ID = "txorg_exp" + k.ToString();
                lxlastpos_exp.ID = "lxlastpos_exp" + k.ToString();
                txlastpos_exp.ID = "txlastpos_exp" + k.ToString();
                lxfdate_exp.ID = "lxfdate_exp" + k.ToString();
                txfdate_exp.ID = "txfdate_exp" + k.ToString();
                txtdate_exp.ID = "txtdate_exp" + k.ToString();
                lxreponsibility.ID = "lxreponsibility" + k.ToString();
                txreponsibility.ID = "txreponsibility" + k.ToString();



                txorg_exp.EnableViewState = true;
                txlastpos_exp.EnableViewState = true;
                txfdate_exp.EnableViewState = true;
                txtdate_exp.EnableViewState = true;
                txreponsibility.EnableViewState = true;


                div71.Controls.Add(lxorg_exp);
                div72.Controls.Add(txorg_exp);
                div91.Controls.Add(lxlastpos_exp);
                div92.Controls.Add(txlastpos_exp);
                div02111.Controls.Add(lxfdate_exp);
                div02112.Controls.Add(txfdate_exp);
                div02311.Controls.Add(txtdate_exp);
                div0411.Controls.Add(lxreponsibility);
                div0421.Controls.Add(txreponsibility);


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
                _gridrow1.Text = zglobal._grid_row_value;
                // _gridrow_h.Text = zglobal._grid_row_value;
                //grid_xsession.Text = "[Select]";
                //grid_xlocation.Text = "[Select]";
                //btnSave.Enabled = true;

                if (TabContainer1.ActiveTabIndex == 0)
                {
                    TabContainer1.Height = 820;
                    //list.Visible = true;
                    list.Visible = false;
                    position.Visible = false;
                    _grid_header.InnerHtml = "Teacher Personal Information (Quick Contact) :";
                    fnGridVisibleProp("_grid_teacherinfo_breakup");
                    //_grid_teacherinfo_breakup.DataSource = null;
                    //_grid_teacherinfo_breakup.DataBind();
                    //_grid_teacherinfo.DataSource = null;
                    // _grid_teacherinfo.DataBind();
                    getActiveTabIndex.Value = "0";
                    type.Value = "teacherinfo";
                    //fnFillDataGrid(null, null);
                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                    btnRefresh.Visible = true;

                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    TabContainer1.Height = 1400;
                    // _grid_header.InnerHtml = "Educational Information :";
                    //fnGridVisibleProp("_grid_education");
                    //_grid_out.DataSource = null;
                    //_grid_out.DataBind();
                    getActiveTabIndex.Value = "1";
                    //type.Value = "out";
                    // fnFillDataGrid(null, null);
                    // xexamname.Text = "";
                    //school.Visible = false;
                    //graduateschool.Visible = false;
                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                    btnRefresh.Visible = true;
                    list.Visible = false;
                    position.Visible = false;
                    FillControls(sender, e);

                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    TabContainer1.Height = 2000;
                    // _grid_header.InnerHtml = "Training & Other Courses :";
                    //fnGridVisibleProp("_grid_sport");
                    //_grid_sport.DataSource = null;
                    //_grid_sport.DataBind();
                    getActiveTabIndex.Value = "2";
                    type.Value = "sport";
                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                    btnRefresh.Visible = true;
                    list.Visible = false;
                    position.Visible = false;
                    FillControls(sender, e);
                }
                else if (TabContainer1.ActiveTabIndex == 3)
                {
                    TabContainer1.Height = 450;
                    //_grid_header.InnerHtml = "Official Informations :";
                    //fnGridVisibleProp("_grid_exam");
                    //_grid_exam.DataSource = null;
                    //_grid_exam.DataBind();
                    getActiveTabIndex.Value = "3";
                    type.Value = "exam";
                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                    btnRefresh.Visible = true;
                    list.Visible = false;
                    position.Visible = true;
                    fnFillDataGrid(sender,e);
                    fnRegisterPostBack();

                    xposition_job.Text = "";
                    xschool_job.Text = "";
                    xfdate_job.Text = "";
                    xrepons_job.Text = "";
                    placeholder9.Controls.Clear();
                    ViewState["ctladded9"] = 1;
                    fnCreateDynamicControlAtPageLoad9();
                }

                fnChkSubmited();
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
                    if (xdob.Text == "" || xdob.Text == string.Empty || xdob.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Date of Birth</li>";
                        isValid = false;
                    }
                    if (xjdate_job.Text == "" || xjdate_job.Text == string.Empty || xjdate_job.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Joining Date</li>";
                        isValid = false;
                    }
                    if (xnid.Text == "" || xnid.Text == string.Empty || xnid.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>National ID</li>";
                        isValid = false;
                    }
                    if (xblood.Text == "" || xblood.Text == string.Empty || xblood.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Blood Group</li>";
                        isValid = false;
                    }
                    if (xfather.Text == "" || xfather.Text == string.Empty || xfather.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Father's Name</li>";
                        isValid = false;
                    }
                    if (xmother.Text == "" || xmother.Text == string.Empty || xmother.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Mother's Name</li>";
                        isValid = false;
                    }

                    if (xreligion.Text == "" || xreligion.Text == string.Empty || xreligion.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Religion</li>";
                        isValid = false;
                    }
                    if (xpadd.Text == "" || xpadd.Text == string.Empty || xpadd.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Present Address</li>";
                        isValid = false;
                    }
                    if (xperadd.Text == "" || xperadd.Text == string.Empty || xperadd.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Permanent Address</li>";
                        isValid = false;
                    }
                    if (xcontact.Text == "" || xcontact.Text == string.Empty || xcontact.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Contact Number</li>";
                        isValid = false;
                    }
                    if (xecontact.Text == "" || xecontact.Text == string.Empty || xecontact.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Emergency Contact</li>";
                        isValid = false;
                    }
                    if (xeconname.Text == "" || xeconname.Text == string.Empty || xeconname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Contact Name</li>";
                        isValid = false;
                    }
                    if (xeconrelation.Text == "" || xeconrelation.Text == string.Empty || xeconrelation.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Relation</li>";
                        isValid = false;
                    }
                    if (xemail1.Text == "" || xemail1.Text == string.Empty || xemail1.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Email</li>";
                        isValid = false;
                    }
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    //if (xexamname.SelectedValue == "" || xexamname.Text == "" || xexamname.Text == string.Empty || xexamname.Text == "[Select]")
                    //{
                    //    rtnMessage = rtnMessage + "<li>Exam Name / Name of Degree </li>";
                    //    isValid = false;
                    //}
                    ////if (xprogramme_out.Text == "" || xprogramme_out.Text == string.Empty || xprogramme_out.Text == "[Select]")
                    ////{
                    ////    rtnMessage = rtnMessage + "<li>Programme's Name</li>";
                    ////    isValid = false;
                    ////}
                    ////if (xlocation_out.Text == "" || xlocation_out.Text == string.Empty || xlocation_out.Text == "[Select]")
                    ////{
                    ////    rtnMessage = rtnMessage + "<li>Will Be Observed In</li>";
                    ////    isValid = false;
                    ////}
                    ////if (xdate_out.Text == "" || xdate_out.Text == string.Empty || xdate_out.Text == "[Select]")
                    ////{
                    ////    rtnMessage = rtnMessage + "<li>Observation Date</li>";
                    ////    isValid = false;
                    ////}
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
                        string xfbid1 = "";
                        string xhobbies1 = "";
                        string xexactivity1 = "";
                        string xeconname1 = "";
                        string xeconrelation1 = "";

                        string query = "";
                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            query = "INSERT INTO hrmst (ztime,zid,xemp,xname,xdob,xnationality,xnid,xblood,xsex,xfather,xmother,xnosibling,xreligion,xpadd,xperadd,xcontact,xecontact,xemail1,xmstatus,xmday,xlink,xspouse,xsocupation,xnochild,zemail,xfbid,xhobbies,xexactivity,xeconname,xeconrelation,xjdate) " +
                                    "VALUES(@ztime,@zid,@xemp,@xname,@xdob,@xnationality,@xnid,@xblood,@xsex,@xfather,@xmother,@xnosibling,@xreligion,@xpadd,@xperadd,@xcontact,@xecontact,@xemail1,@xmstatus,@xmday,@xlink,@xspouse,@xsocupation,@xnochild,@zemail,@xfbid,@xhobbies,@xexactivity,@xeconname,@xeconrelation,@xjdate) ";

                            xemp1 = xemp.Text.Trim().ToString();
                            xkey = xemp1;
                            ViewState["xemp"] = xemp.Text.Trim().ToString();
                            _row.Value = ViewState["xemp"].ToString();
                            xname1 = xname.Text.Trim().ToString();
                            xdob1 = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            xmday1 = xmday.Text.Trim() != string.Empty ? DateTime.ParseExact(xmday.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xjdate1 = xjdate_job.Text.Trim() != string.Empty ? DateTime.ParseExact(xjdate_job.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            xfbid1 = xfbid.Text.Trim().ToString();
                            xhobbies1 = xhobbies.Text.Trim().ToString();
                            xexactivity1 = xexactivity.Text.Trim().ToString();
                            xeconname1 = xeconname.Text.Trim().ToString();
                            xeconrelation1 = xeconrelation.Text.Trim().ToString();
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
                            //xdate = xdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfdate = xfdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_out.Text.Trim().ToString();
                            //xcoconvenor = xcoconvenor_out.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_out.InnerText.Trim().ToString();
                            //xfclass = xfclass_out.Text.Trim().ToString();
                            //xtclass = xtclass_out.Text.Trim().ToString();
                            //xffdate = xffdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_out.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_out.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            //xdate = xdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfdate = xfdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xallconvenor = xallconvenor_sport.Text.Trim().ToString();
                            //xcoconvenor = xcoconvenor_sport.Text.Trim().ToString();
                            //xprogdetail = xprogdetail_sport.InnerText.Trim().ToString();
                            //xfclass = xfclass_sport.Text.Trim().ToString();
                            //xtclass = xtclass_sport.Text.Trim().ToString();
                            //xffdate = xffdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xfinaldate = xfinaldate_sport.Text.Trim() != string.Empty ? DateTime.ParseExact(xfinaldate_sport.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            //xdate = xdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xexam = xexam_exam.Text.Trim().ToString();
                            //xfclass = xclass_exam.Text.Trim().ToString();
                            //xfdate = xfdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xffdate = xsubmission_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xsubmission_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xresultdate = xresultdate_exam.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_exam.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            //xfdate = xfdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xfdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xtdate = xtdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xtdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xffdate = xffdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xffdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            //xresultdate = xresultdate_others.Text.Trim() != string.Empty ? DateTime.ParseExact(xresultdate_others.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                        cmd.Parameters.AddWithValue("@xfbid", xfbid1);
                        cmd.Parameters.AddWithValue("@xhobbies", xhobbies1);
                        cmd.Parameters.AddWithValue("@xexactivity", xexactivity1);
                        cmd.Parameters.AddWithValue("@xeconname", xeconname1);
                        cmd.Parameters.AddWithValue("@xeconrelation", xeconrelation1);
                        //cmd.Parameters.AddWithValue("@xjdate", xjdate1);
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
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            //if (ViewState["xemp"] != null)
                            //{

                            //    cmd.Parameters.Clear();
                            //    int xline = zglobal.GetMaximumIdInt("xline", "hredu"," zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                            //    ViewState["xline"] = xline.ToString();
                            //    string xexamname1 = xexamname.SelectedItem.Text.Trim().ToString();
                            //    string xorg1 = "";
                            //    string xdist1 = "";
                            //    string xedusys1 = "";
                            //    string xboard1 = "";
                            //    string xedugroup1 = "";
                            //    string xyear1 = "";
                            //    string xresult1 = "";
                            //    decimal xgpa1 = 0;
                            //    int xnumsub1 = 0;
                            //    int xnaa1 = 0;
                            //    int xna1 = 0;
                            //    int xnb1 = 0;
                            //    int xnc1 = 0;
                            //    string xunderorg1 = "";
                            //    string xcountry1 = "";
                            //    string xsubject1 = "";
                            //    string xduration1 = "";
                            //    string xposition1 = "";

                            //    query = "INSERT INTO hredu (zid,xemp,xline,xexamname,xorg,xdist,xedusys,xboard,xedugroup,xyear,xresult,xgpa,xnumsub,xnaa,xna,xnb,xnc,xunderorg,xcountry,xsubject,xduration,xposition) " +
                            //            "VALUES(@zid,@xemp,@xline,@xexamname,@xorg,@xdist,@xedusys,@xboard,@xedugroup,@xyear,@xresult,@xgpa,@xnumsub,@xnaa,@xna,@xnb,@xnc,@xunderorg,@xcountry,@xsubject,@xduration,@xposition) ";

                            //    string[] val = xexamname.SelectedValue.Split('-');
                            //    if (val[1] == "1")
                            //    {
                            //        xorg1 = xorg.Text.Trim().ToString();
                            //        xdist1 = xdist.Text.Trim().ToString();
                            //        xedusys1 = xedusys.Text.Trim().ToString();
                            //        xboard1 = xboard.Text.Trim().ToString();
                            //        xedugroup1 = xedugroup.Text.Trim().ToString();
                            //        xyear1 = xyear.Text.Trim().ToString();
                            //        xresult1 = xgpa_s.Text.Trim().ToString();
                            //        if (xresult1.ToUpper() == "GPA")
                            //        {
                            //            xgpa1 = xpoint_s.Text.Trim().ToString()==String.Empty || xpoint_s.Text.Trim().ToString()=="" ? xgpa1 : Convert.ToDecimal(xpoint_s.Text.Trim().ToString());
                            //        }
                            //        xnumsub1 = xnumsub.Text.Trim().ToString()==String.Empty || xnumsub.Text.Trim().ToString() == "" ? xnumsub1 : Convert.ToInt32(xnumsub.Text.Trim().ToString());
                            //        xnaa1 = xnaa.Text.Trim().ToString() == String.Empty || xnaa.Text.Trim().ToString() == "" ? xnaa1 : Convert.ToInt32(xnaa.Text.Trim().ToString());
                            //        xna1 = xna.Text.Trim().ToString() == String.Empty || xna.Text.Trim().ToString() == "" ? xna1 : Convert.ToInt32(xna.Text.Trim().ToString());
                            //        xnb1 = xnb.Text.Trim().ToString() == String.Empty || xnb.Text.Trim().ToString()=="" ? xnb1 :Convert.ToInt32(xnb.Text.Trim().ToString());
                            //        xnc1 = xnc.Text.Trim().ToString() == String.Empty || xnc.Text.Trim().ToString() == "" ? xnc1 : Convert.ToInt32(xnc.Text.Trim().ToString());
                            //    }
                            //    else if (val[1] == "2")
                            //    {
                            //        xorg1 = xorggs.Text.Trim().ToString();
                            //        xcountry1 = xcountry.Text.Trim().ToString();
                            //        xunderorg1 = xunderorg.Text.Trim().ToString();
                            //        xsubject1 = xsubject.Text.Trim().ToString();
                            //        xyear1 = xyeargs.Text.Trim().ToString();
                            //        xresult1 = xgpa_gs.Text.Trim().ToString();
                            //        if (xresult1.ToUpper() == "GPA")
                            //        {
                            //            xgpa1 = Convert.ToDecimal(xpoint_gs.Text.Trim().ToString());
                            //        }
                            //        xduration1 = xduration.Text.Trim().ToString();
                            //        xposition1 = xposition.Text.Trim().ToString();
                            //    }

                            //    cmd.CommandText = query;
                            //    cmd.Parameters.AddWithValue("@zid", _zid);
                            //    cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                            //    cmd.Parameters.AddWithValue("@xline", xline);
                            //    cmd.Parameters.AddWithValue("@xexamname", xexamname1);
                            //    cmd.Parameters.AddWithValue("@xorg", xorg1);
                            //    cmd.Parameters.AddWithValue("@xdist", xdist1);
                            //    cmd.Parameters.AddWithValue("@xedusys", xedusys1);
                            //    cmd.Parameters.AddWithValue("@xboard", xboard1);
                            //    cmd.Parameters.AddWithValue("@xedugroup", xedugroup1);
                            //    cmd.Parameters.AddWithValue("@xyear", xyear1);
                            //    cmd.Parameters.AddWithValue("@xresult", xresult1);
                            //    cmd.Parameters.AddWithValue("@xgpa", xgpa1);
                            //    cmd.Parameters.AddWithValue("@xnumsub", xnumsub1);
                            //    cmd.Parameters.AddWithValue("@xnaa", xnaa1);
                            //    cmd.Parameters.AddWithValue("@xna", xna1);
                            //    cmd.Parameters.AddWithValue("@xnb", xnb1);
                            //    cmd.Parameters.AddWithValue("@xnc", xnc1);
                            //    cmd.Parameters.AddWithValue("@xunderorg", xunderorg1);
                            //    cmd.Parameters.AddWithValue("@xcountry", xcountry1);
                            //    cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                            //    cmd.Parameters.AddWithValue("@xduration", xduration1);
                            //    cmd.Parameters.AddWithValue("@xposition", xposition1);
                            //    cmd.ExecuteNonQuery();
                            //}
                            //else
                            //{
                            //    message.InnerHtml = "No Teacher Select To Save Record.";
                            //    message.Style.Value = zglobal.warningmsg;
                            //    return;
                            //}
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
                //if (TabContainer1.ActiveTabIndex == 0)
                //{
                Response.Redirect(Request.RawUrl);
                //}
                //else //if (TabContainer1.ActiveTabIndex==1)
                //{
                //    TabContainer1_ActiveTabChanged(sender,e);
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerText = "";
                if (ViewState["xemp"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {
                        string xstatus;

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                DateTime xsubmitdt = DateTime.Now;
                                xstatus = "Submited";




                                string query =
                                    "UPDATE hrmst SET xstatus=@xstatus,xsubmitedby=@xsubmitedby,xsubmitdt=@xsubmitdt,xstatusemp='A-Active' " +
                                    "WHERE zid=@zid AND xemp=@xemp ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.Parameters.AddWithValue("@xsubmitedby", xsubmitedby);
                                cmd.Parameters.AddWithValue("@xsubmitdt", xsubmitdt);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.subsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnEdit.Visible = false;
                        btnSave.Visible = false;
                        btnRefresh.Visible = true;
                        btnSubmit.Visible = false;
                    }
                }
                else
                {
                    message.InnerHtml = "Cann't submit information.";
                    message.Style.Value = zglobal.warningmsg;
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
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xkey = "";
                string xtype = "";
                message.InnerHtml = "";
                bool isValid = true;

                string xstatus200 = zglobal.fnGetValue("xstatus", "hrmst", "zid=" + _zid + " AND xemp='" + ViewState["xemp"].ToString() + "'");
                if (xstatus200 == "Submited")
                {
                    message.InnerHtml = "Already submitted record. Cann't update.";
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

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
                    if (xdob.Text == "" || xdob.Text == string.Empty || xdob.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Date of Birth</li>";
                        isValid = false;
                    }
                    if (xjdate_job.Text == "" || xjdate_job.Text == string.Empty || xjdate_job.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Joining Date</li>";
                        isValid = false;
                    }
                    if (xnid.Text == "" || xnid.Text == string.Empty || xnid.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>National ID</li>";
                        isValid = false;
                    }
                    if (xblood.Text == "" || xblood.Text == string.Empty || xblood.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Blood Group</li>";
                        isValid = false;
                    }
                    if (xfather.Text == "" || xfather.Text == string.Empty || xfather.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Father's Name</li>";
                        isValid = false;
                    }
                    if (xmother.Text == "" || xmother.Text == string.Empty || xmother.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Mother's Name</li>";
                        isValid = false;
                    }

                    if (xreligion.Text == "" || xreligion.Text == string.Empty || xreligion.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Religion</li>";
                        isValid = false;
                    }
                    if (xpadd.Text == "" || xpadd.Text == string.Empty || xpadd.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Present Address</li>";
                        isValid = false;
                    }
                    if (xperadd.Text == "" || xperadd.Text == string.Empty || xperadd.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Permanent Address</li>";
                        isValid = false;
                    }
                    if (xcontact.Text == "" || xcontact.Text == string.Empty || xcontact.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Contact Number</li>";
                        isValid = false;
                    }
                    if (xecontact.Text == "" || xecontact.Text == string.Empty || xecontact.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Emergency Contact</li>";
                        isValid = false;
                    }
                    if (xeconname.Text == "" || xeconname.Text == string.Empty || xeconname.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Contact Name</li>";
                        isValid = false;
                    }
                    if (xeconrelation.Text == "" || xeconrelation.Text == string.Empty || xeconrelation.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Relation</li>";
                        isValid = false;
                    }
                    if (xemail1.Text == "" || xemail1.Text == string.Empty || xemail1.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Email</li>";
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
                    if (xposition_job.Text == "" || xposition_job.Text == string.Empty || xposition_job.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>Position</li>";
                        isValid = false;
                    }
                    if (xfdate_job.Text == "" || xfdate_job.Text == string.Empty || xfdate_job.Text == "[Select]")
                    {
                        rtnMessage = rtnMessage + "<li>From Date</li>";
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
                        string xfbid1 = "";
                        string xhobbies1 = "";
                        string xexactivity1 = "";
                        string xeconname1 = "";
                        string xeconrelation1 = "";

                        string query = "";
                        if (TabContainer1.ActiveTabIndex == 0)
                        {
                            query = "UPDATE hrmst SET zutime=@zutime, xname=@xname, xdob=@xdob, xnationality=@xnationality, xnid=@xnid, xblood=@xblood, xsex=@xsex, xfather=@xfather, " +
                                    "xmother=@xmother, xnosibling=@xnosibling, xreligion=@xreligion, xpadd=@xpadd, xperadd=@xperadd, xcontact=@xcontact, xecontact=@xecontact, xemail1=@xemail1, " +
                                    "xmstatus=@xmstatus, xmday=@xmday, xlink=@xlink, xspouse=@xspouse, xsocupation=@xsocupation, xnochild=@xnochild, xemail=@xemail, xfbid=@xfbid, xhobbies=@xhobbies, " +
                                    "xexactivity=@xexactivity, xeconname=@xeconname, xeconrelation=@xeconrelation, xjdate=@xjdate  " +
                                    "WHERE zid=@zid AND xemp=@xemp";

                            xname1 = xname.Text.Trim().ToString();
                            xdob1 = xdob.Text.Trim() != string.Empty ? DateTime.ParseExact(xdob.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            xmday1 = xmday.Text.Trim() != string.Empty ? DateTime.ParseExact(xmday.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            xfbid1 = xfbid.Text.Trim().ToString();
                            xhobbies1 = xhobbies.Text.Trim().ToString();
                            xexactivity1 = xexactivity.Text.Trim().ToString();
                            xeconname1 = xeconname.Text.Trim().ToString();
                            xeconrelation1 = xeconrelation.Text.Trim().ToString();
                            xjdate1 = xjdate_job.Text.Trim() != string.Empty ? DateTime.ParseExact(xjdate_job.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                        cmd.Parameters.AddWithValue("@xfbid", xfbid1);
                        cmd.Parameters.AddWithValue("@xhobbies", xhobbies1);
                        cmd.Parameters.AddWithValue("@xexactivity", xexactivity1);
                        cmd.Parameters.AddWithValue("@xeconname", xeconname1);
                        cmd.Parameters.AddWithValue("@xeconrelation", xeconrelation1);
                        //cmd.Parameters.AddWithValue("@xjdate", xjdate1);
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
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            query = "DELETE FROM hredu WHERE zid=@zid and xemp=@xemp";
                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xemp", xemp1);
                            cmd.ExecuteNonQuery();


                            int xline = 0;
                            //ViewState["xline"] = xline.ToString();
                            string xexamname1 = "";
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
                            string xtype1 = "";

                            query = "INSERT INTO hredu (zid,xemp,xline,xexamname,xorg,xdist,xedusys,xboard,xedugroup,xyear,xresult,xgpa,xnumsub,xnaa,xna,xnb,xnc,xunderorg,xcountry,xsubject,xduration,xposition,xtype) " +
                                    "VALUES(@zid,@xemp,@xline,@xexamname,@xorg,@xdist,@xedusys,@xboard,@xedugroup,@xyear,@xresult,@xgpa,@xnumsub,@xnaa,@xna,@xnb,@xnc,@xunderorg,@xcountry,@xsubject,@xduration,@xposition,@xtype) ";

                            for (int i = 0; i < 4; i++)
                            {
                                if (i == 0)
                                {
                                    xline = zglobal.GetMaximumIdInt("xline", "hredu", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                    xorg1 = xorg_pri.Text.Trim().ToString();
                                    xdist1 = xdist_pri.Text.Trim().ToString();
                                    xtype1 = "primary";
                                }
                                else if (i == 1)
                                {
                                    xline = zglobal.GetMaximumIdInt("xline", "hredu", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
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
                                    xtype1 = "secondery";
                                    xexamname1 = xexamname_sec.Text.Trim().ToString();
                                }
                                else if (i == 2)
                                {
                                    xline = zglobal.GetMaximumIdInt("xline", "hredu", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                    xorg1 = xorg_high.Text.Trim().ToString();
                                    xdist1 = xdist_high.Text.Trim().ToString();
                                    xedusys1 = xedusys_high.Text.Trim().ToString();
                                    xboard1 = xboard_high.Text.Trim().ToString();
                                    xedugroup1 = xedugroup_high.Text.Trim().ToString();
                                    xyear1 = xyear_high.Text.Trim().ToString();
                                    xresult1 = xgpa_high.Text.Trim().ToString();
                                    if (xresult1.ToUpper() == "GPA")
                                    {
                                        xgpa1 = xpoint_high.Text.Trim().ToString() == String.Empty || xpoint_high.Text.Trim().ToString() == "" ? xgpa1 : Convert.ToDecimal(xpoint_high.Text.Trim().ToString());
                                    }
                                    xnumsub1 = xnumsub_high.Text.Trim().ToString() == String.Empty || xnumsub_high.Text.Trim().ToString() == "" ? xnumsub1 : Convert.ToInt32(xnumsub_high.Text.Trim().ToString());
                                    xnaa1 = xnaa_high.Text.Trim().ToString() == String.Empty || xnaa_high.Text.Trim().ToString() == "" ? xnaa1 : Convert.ToInt32(xnaa_high.Text.Trim().ToString());
                                    xna1 = xna_high.Text.Trim().ToString() == String.Empty || xna_high.Text.Trim().ToString() == "" ? xna1 : Convert.ToInt32(xna_high.Text.Trim().ToString());
                                    xnb1 = xnb_high.Text.Trim().ToString() == String.Empty || xnb_high.Text.Trim().ToString() == "" ? xnb1 : Convert.ToInt32(xnb_high.Text.Trim().ToString());
                                    xnc1 = xnc_high.Text.Trim().ToString() == String.Empty || xnc_high.Text.Trim().ToString() == "" ? xnc1 : Convert.ToInt32(xnc_high.Text.Trim().ToString());
                                    xtype1 = "highersecondery";
                                    xexamname1 = xexamname_high.Text.Trim().ToString();
                                }
                                else if (i == 3)
                                {
                                    xline = zglobal.GetMaximumIdInt("xline", "hredu", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                    xorg1 = xorggs.Text.Trim().ToString();
                                    xcountry1 = xcountry.Text.Trim().ToString();
                                    xunderorg1 = xunderorg.Text.Trim().ToString();
                                    xsubject1 = xsubject.Text.Trim().ToString();
                                    xyear1 = xyeargs.Text.Trim().ToString();
                                    xresult1 = xgpa_gs.Text.Trim().ToString();
                                    if (xresult1.ToUpper() == "GPA")
                                    {
                                        xgpa1 = xpoint_gs.Text.Trim().ToString() == String.Empty || xpoint_gs.Text.Trim().ToString() == "" ? xgpa1 : Convert.ToDecimal(xpoint_gs.Text.Trim().ToString());
                                    }
                                    xduration1 = xduration.Text.Trim().ToString();
                                    xposition1 = xposition.Text.Trim().ToString();
                                    xtype1 = "graduation";
                                    xexamname1 = xexamname_gra.Text.Trim().ToString();
                                }

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
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
                                cmd.Parameters.AddWithValue("@xtype", xtype1);
                                cmd.ExecuteNonQuery();
                            }


                            if (ViewState["ctladded3"] != null)
                            {
                                for (int i = 1; i <= (int)ViewState["ctladded3"]; i++)
                                {

                                    xline = zglobal.GetMaximumIdInt("xline", "hredu", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                    xorg1 = ((TextBox)placeholder3.FindControl("txtxorg_post" + i)).Text.ToString().Trim();
                                    xcountry1 = ((TextBox)placeholder3.FindControl("txtxcountry_post" + i)).Text.ToString().Trim();
                                    xunderorg1 = ((TextBox)placeholder3.FindControl("txtxunderorg_post" + i)).Text.ToString().Trim();
                                    xsubject1 = ((DropDownList)placeholder3.FindControl("dwxsubject_post" + i)).Text.ToString().Trim();
                                    xyear1 = ((DropDownList)placeholder3.FindControl("dwxyear_post" + i)).Text.ToString().Trim();
                                    xresult1 = ((DropDownList)placeholder3.FindControl("dwxgpa_post" + i)).Text.ToString().Trim();
                                    if (xresult1.ToUpper() == "GPA")
                                    {
                                        xgpa1 = ((TextBox)placeholder3.FindControl("txtxpoint_post" + i)).Text.ToString().Trim() == String.Empty ||
                                            ((TextBox)placeholder3.FindControl("txtxpoint_post" + i)).Text.ToString().Trim() == "" ?
                                                xgpa1 : Convert.ToDecimal(((TextBox)placeholder3.FindControl("txtxpoint_post" + i)).Text.ToString().Trim());
                                    }
                                    xduration1 = ((DropDownList)placeholder3.FindControl("dwxduration_post" + i)).Text.ToString().Trim();
                                    xposition1 = ((DropDownList)placeholder3.FindControl("dwxposition_post" + i)).Text.ToString().Trim();
                                    xtype1 = "postgraduation";
                                    xexamname1 = ((DropDownList)placeholder3.FindControl("dwxexamname_post" + i)).Text.ToString().Trim();

                                    cmd.Parameters.Clear();
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
                                    cmd.Parameters.AddWithValue("@xtype", xtype1);
                                    if (xorg1 != "")
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        else if (TabContainer1.ActiveTabIndex == 2)
                        {



                            if (ViewState["ctladded4"] != null)
                            {
                                query = "DELETE FROM hrtrain WHERE zid=@zid and xemp=@xemp";
                                cmd.Parameters.Clear();
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", xemp1);
                                cmd.ExecuteNonQuery();


                                int xline = 0;
                                //ViewState["xline"] = xline.ToString();
                                string xname11 = "";
                                string xorganised1 = "";
                                string xvanue1 = "";
                                string xcountry11 = "";
                                string xtrainer1 = "";
                                DateTime xfdate1 = DateTime.Now;
                                DateTime xtdate1 = DateTime.Now;
                                string xremarks1 = "";

                                query = "INSERT INTO hrtrain (zid,xemp,xline,xname,xorganised,xvanue,xcountry,xtrainer,xfdate,xtdate,xremarks) " +
                                        "VALUES(@zid,@xemp,@xline,@xname,@xorganised,@xvanue,@xcountry,@xtrainer,@xfdate,@xtdate,@xremarks) ";

                                for (int i = 1; i <= (int)ViewState["ctladded4"]; i++)
                                {

                                    xline = zglobal.GetMaximumIdInt("xline", "hrtrain", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                    xname11 = ((TextBox)placeholder4.FindControl("txname_train" + i)).Text.ToString().Trim();
                                    xorganised1 = ((TextBox)placeholder4.FindControl("txorganised" + i)).Text.ToString().Trim();
                                    xvanue1 = ((TextBox)placeholder4.FindControl("txvanue" + i)).Text.ToString().Trim();
                                    xcountry11 = ((TextBox)placeholder4.FindControl("txcountry_train" + i)).Text.ToString().Trim();
                                    xtrainer1 = ((TextBox)placeholder4.FindControl("txtrainer" + i)).Text.ToString().Trim();
                                    xfdate1 = ((TextBox)placeholder4.FindControl("txfdate_train" + i)).Text.ToString().Trim() != string.Empty
                                        ? DateTime.ParseExact(((TextBox)placeholder4.FindControl("txfdate_train" + i)).Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    xtdate1 = ((TextBox)placeholder4.FindControl("txtdate_train" + i)).Text.ToString().Trim() != string.Empty
                                        ? DateTime.ParseExact(((TextBox)placeholder4.FindControl("txtdate_train" + i)).Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    xremarks1 = ((HtmlTextArea)placeholder4.FindControl("txremarks_train" + i)).Value.ToString().Trim();


                                    cmd.Parameters.Clear();
                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                    cmd.Parameters.AddWithValue("@xline", xline);
                                    cmd.Parameters.AddWithValue("@xname", xname11);
                                    cmd.Parameters.AddWithValue("@xorganised", xorganised1);
                                    cmd.Parameters.AddWithValue("@xvanue", xvanue1);
                                    cmd.Parameters.AddWithValue("@xcountry", xcountry11);
                                    cmd.Parameters.AddWithValue("@xtrainer", xtrainer1);
                                    cmd.Parameters.AddWithValue("@xfdate", xfdate1);
                                    cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                                    cmd.Parameters.AddWithValue("@xremarks", xremarks1);
                                    if (xname11 != "")
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }


                            if (ViewState["ctladded5"] != null)
                            {
                                query = "DELETE FROM hrexp WHERE zid=@zid and xemp=@xemp";
                                cmd.Parameters.Clear();
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xemp", xemp1);
                                cmd.ExecuteNonQuery();


                                int xline = 0;
                                //ViewState["xline"] = xline.ToString();
                                string xorg1 = "";
                                string xlastpos1 = "";
                                DateTime xfdate1 = DateTime.Now;
                                DateTime xtdate1 = DateTime.Now;
                                string xreponsibility1 = "";

                                query = "INSERT INTO hrexp (zid,xemp,xline,xorg,xlastpos,xfdate,xtdate,xreponsibility) " +
                                        "VALUES(@zid,@xemp,@xline,@xorg,@xlastpos,@xfdate,@xtdate,@xreponsibility) ";

                                for (int i = 1; i <= (int)ViewState["ctladded5"]; i++)
                                {

                                    xline = zglobal.GetMaximumIdInt("xline", "hrexp", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                    xorg1 = ((TextBox)placeholder5.FindControl("txorg_exp" + i)).Text.ToString().Trim();
                                    xlastpos1 = ((TextBox)placeholder5.FindControl("txlastpos_exp" + i)).Text.ToString().Trim();
                                    xfdate1 = ((TextBox)placeholder5.FindControl("txfdate_exp" + i)).Text.ToString().Trim() != string.Empty
                                        ? DateTime.ParseExact(((TextBox)placeholder5.FindControl("txfdate_exp" + i)).Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    xtdate1 = ((TextBox)placeholder5.FindControl("txtdate_exp" + i)).Text.ToString().Trim() != string.Empty
                                        ? DateTime.ParseExact(((TextBox)placeholder5.FindControl("txtdate_exp" + i)).Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    xreponsibility1 = ((HtmlTextArea)placeholder5.FindControl("txreponsibility" + i)).Value.ToString().Trim();


                                    cmd.Parameters.Clear();
                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                    cmd.Parameters.AddWithValue("@xline", xline);
                                    cmd.Parameters.AddWithValue("@xorg", xorg1);
                                    cmd.Parameters.AddWithValue("@xlastpos", xlastpos1);
                                    cmd.Parameters.AddWithValue("@xfdate", xfdate1);
                                    cmd.Parameters.AddWithValue("@xtdate", xtdate1);
                                    cmd.Parameters.AddWithValue("@xreponsibility", xreponsibility1);
                                    if (xorg1 != "")
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }



                        }
                        else if (TabContainer1.ActiveTabIndex == 3)
                        {
                            string flag = "insert";

                            using (SqlConnection con = new SqlConnection(zglobal.constring))
                            {
                                query = "SELECT * FROM hrjobs WHERE zid=@zid AND xemp=@xemp";
                                SqlCommand cmd1 = new SqlCommand(query, con);
                                string _zid1 = Convert.ToString(HttpContext.Current.Session["business"]);
                                cmd1.Parameters.AddWithValue("@zid", Int32.Parse(_zid1));
                                cmd1.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                cmd1.CommandType = CommandType.Text;
                                con.Open();
                                SqlDataReader rdr = cmd1.ExecuteReader();
                                DateTime xfdate2 = xfdate_job.Text.ToString().Trim() != string.Empty
                                        ? DateTime.ParseExact(xfdate_job.Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                               
                                
                                while (rdr.Read())
                                {
                                    //string year = Convert.ToDateTime(rdr["xfdate"]).Year.ToString();
                                    //string month = Convert.ToDateTime(rdr["xfdate"]).Month.ToString();
                                    //string day = Convert.ToDateTime(rdr["xfdate"]).Day.ToString();
                                    //message.InnerHtml = Convert.ToDateTime(rdr["xfdate"].ToString()) + " " + xfdate2.ToString();
                                    //return;

                                    if (xposition_job.Text.Trim().ToString() == rdr["xposition"].ToString() && xfdate2.ToString() == Convert.ToDateTime(rdr["xfdate"].ToString()).ToString())
                                    {
                                        if (ViewState["xline9"] != null)
                                        {
                                            flag = "update";
                                        }
                                        else
                                        {
                                            message.InnerHtml = "Cann't insert duplicate record.";
                                            message.Style.Value = zglobal.warningmsg;
                                            return;
                                        }
                                    }
                                }
                            }



                            int xline = 0;
                            string xposition1 = "";
                            decimal xsalary1 = 0;
                            DateTime xfdate1;
                            string xrepons1 = "";

                            if (flag == "insert")
                            {
                                query = "INSERT INTO hrjobs (zid,xemp,xline,xposition,xsalary,xfdate,xrepons) " +
                                        "VALUES(@zid,@xemp,@xline,@xposition,@xsalary,@xfdate,@xrepons) ";
                                xline = zglobal.GetMaximumIdInt("xline", "hrjobs",
                                    " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'", "line");
                                ViewState["xline9"] = xline;
                            }
                            else
                            {
                                query = "UPDATE hrjobs SET xrepons=@xrepons  WHERE zid=@zid AND xemp=@xemp AND xline=@xline";
                                xline = Convert.ToInt32(ViewState["xline9"]);
                            }
                            xposition1 = xposition_job.Text.Trim().ToString();
                            xsalary1 = 0;
                            xfdate1 = xfdate_job.Text.ToString().Trim() != string.Empty
                                        ? DateTime.ParseExact(xfdate_job.Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xrepons1 = xrepons_job.Text.Trim().ToString();

                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                            cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                            cmd.Parameters.AddWithValue("@xposition", xposition1);
                            cmd.Parameters.AddWithValue("@xsalary", xsalary1);
                            cmd.Parameters.AddWithValue("@xfdate", xfdate1);
                            cmd.Parameters.AddWithValue("@xrepons", xrepons1);
                            cmd.ExecuteNonQuery();


                            query = "DELETE FROM hrjobsd WHERE zid=@zid and xemp=@xemp and xline=@xline";
                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                            cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                            cmd.ExecuteNonQuery();

                            if (xschool_job.Text != "")
                            {
                                string[] xschool = xschool_job.Text.Trim().ToString().Split('&');
                                query =
                                    "INSERT INTO hrjobsd (zid,xemp,xline,xline1,xtype,xschool) VALUES (@zid,@xemp,@xline,@xline1,'School',@xschool)";
                                for(int i = 0; i < xschool.Length; i++)
                                {
                                    int xline1 = zglobal.GetMaximumIdInt("xline1", "hrjobsd",
                                        " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'" +
                                        " and xline=" + Convert.ToInt32(ViewState["xline9"]), "line");

                                    cmd.Parameters.Clear();
                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                    cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                                    cmd.Parameters.AddWithValue("@xline1", xline1);
                                    cmd.Parameters.AddWithValue("@xschool", xschool[i].Trim());
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            //query = "INSERT INTO hrjobsd (zid,xemp,xline,xline1,xtype,xclass) VALUES (@zid,@xemp,@xline,@xline1,'Class',@xclass)";
                            //for (int i = 0; i < xclass_job.Items.Count; i++)
                            //{
                            //    int xline1 = zglobal.GetMaximumIdInt("xline1", "hrjobsd", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'" + " and xline=" + Convert.ToInt32(ViewState["xline9"]), "line");

                            //    cmd.Parameters.Clear();
                            //    cmd.CommandText = query;
                            //    cmd.Parameters.AddWithValue("@zid", _zid);
                            //    cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                            //    cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                            //    cmd.Parameters.AddWithValue("@xline1", xline1);
                            //    cmd.Parameters.AddWithValue("@xclass", xclass_job.Items[i].ToString());
                            //    cmd.ExecuteNonQuery();
                            //}

                            //query = "INSERT INTO hrjobsd (zid,xemp,xline,xline1,xtype,xsection) VALUES (@zid,@xemp,@xline,@xline1,'Section',@xsection)";
                            //for (int i = 0; i < xsection_job.Items.Count; i++)
                            //{
                            //    int xline1 = zglobal.GetMaximumIdInt("xline1", "hrjobsd", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'" + " and xline=" + Convert.ToInt32(ViewState["xline9"]), "line");

                            //    cmd.Parameters.Clear();
                            //    cmd.CommandText = query;
                            //    cmd.Parameters.AddWithValue("@zid", _zid);
                            //    cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                            //    cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                            //    cmd.Parameters.AddWithValue("@xline1", xline1);
                            //    cmd.Parameters.AddWithValue("@xsection", xsection_job.Items[i].ToString());
                            //    cmd.ExecuteNonQuery();
                            //}


                            if (ViewState["ctladded9"] != null)
                            {
                                query = "INSERT INTO hrjobsd (zid,xemp,xline,xline1,xtype,xsubject,xpaper,xsclass,xssection) " +
                                        "VALUES(@zid,@xemp,@xline,@xline1,'Subject',@xsubject,@xpaper,@xsclass,@xssection) ";

                                for (int i = 1; i <= (int)ViewState["ctladded9"]; i++)
                                {
                                    int xline1;
                                    string xpaper1 = ((DropDownList)placeholder9.FindControl("xpaper_job" + i)).Text.ToString().Trim();
                                    string xclass1 = ((DropDownList)placeholder9.FindControl("xclass_job" + i)).Text.ToString().Trim();
                                    //string xsection1 = ((DropDownList)placeholder9.FindControl("xsection_job" + i)).Text.ToString().Trim();
                                    string xsubject1 = ((DropDownList)placeholder9.FindControl("xsubject_job" + i)).Text.ToString().Trim();

                                    //if (xclass1 != "")
                                    //{


                                    //    cmd.Parameters.Clear();
                                    //    cmd.CommandText = query;
                                    //    cmd.Parameters.AddWithValue("@zid", _zid);
                                    //    cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                    //    cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                                    //    cmd.Parameters.AddWithValue("@xline1", xline1);
                                    //    cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                    //    cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                    //    cmd.Parameters.AddWithValue("@xsclass", xclass1);
                                    //    cmd.Parameters.AddWithValue("@xssection", xsection1);

                                    //    cmd.ExecuteNonQuery();
                                    //}

                                    //ListItem xsubject1 = ((CheckBoxList)placeholder9.FindControl("xsubject_job" + i)).Items;
                                    int count9 = 0;
                                    if (xclass1 != "")
                                    {
                                        foreach (ListItem item in ((CheckBoxList)placeholder9.FindControl("xsection_job" + i)).Items)
                                        {
                                            if (item.Selected)
                                            {
                                                xline1 = zglobal.GetMaximumIdInt("xline1", "hrjobsd", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'" + " and xline=" + Convert.ToInt32(ViewState["xline9"]), "line");
                                                cmd.Parameters.Clear();
                                                cmd.CommandText = query;
                                                cmd.Parameters.AddWithValue("@zid", _zid);
                                                cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                                cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                                                cmd.Parameters.AddWithValue("@xline1", xline1);
                                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                                cmd.Parameters.AddWithValue("@xsclass", xclass1);
                                                cmd.Parameters.AddWithValue("@xssection", item.Text);

                                                cmd.ExecuteNonQuery();
                                                count9 = count9 + 1;

                                                item.Attributes.Add("style", "color:#0000FF");
                                            }
                                        }

                                        if (count9 == 0)
                                        {
                                            xline1 = zglobal.GetMaximumIdInt("xline1", "hrjobsd", " zid=" + _zid + " and xemp='" + ViewState["xemp"].ToString() + "'" + " and xline=" + Convert.ToInt32(ViewState["xline9"]), "line");
                                            cmd.Parameters.Clear();
                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xemp", ViewState["xemp"].ToString());
                                            cmd.Parameters.AddWithValue("@xline", Convert.ToInt32(ViewState["xline9"]));
                                            cmd.Parameters.AddWithValue("@xline1", xline1);
                                            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                            cmd.Parameters.AddWithValue("@xsclass", xclass1);
                                            cmd.Parameters.AddWithValue("@xssection", "");

                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }


                            fnFillDataGrid(sender, e);

                        }



                        //Insert into zreclog
                        //zglobal.fnRecordLog(xrow.ToString(), "Edit", "eventinfo", xtype, "", 0, xdate);


                    }

                    //fnFillDataGrid();
                    //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();


                }

                //fnFillDataGrid(null, null);
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
                    string[] validFileTypes = { "jpg", "jpeg" };

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


                    //if (FileUpload1.PostedFile.ContentLength > 100000)
                    //{
                    //    ErrorMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image size. (Max size 100KB)<br>";
                    //    ErrorMsg.Style.Value = zglobal.errormsg;
                    //    isValidFile = false;
                    //    //return;
                    //}
                    //else
                    //{
                    //    isValidFile = true;
                    //}

                    //Bitmap bitmp = new Bitmap(FileUpload1.PostedFile.InputStream);
                    //if (bitmp.Width != 300 & bitmp.Height != 300)
                    //{
                    //    ErrorMsg.InnerHtml = ErrorMsg.InnerHtml + "Invalid image dimension. (Dimension must be 300x300)";
                    //    ErrorMsg.Style.Value = zglobal.errormsg;
                    //    isValidFile = false;
                    //    //return;
                    //}
                    //else
                    //{
                    //    isValidFile = true;
                    //}

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

        protected void btnforward_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    for (int i = 0; i < xclass_all.Items.Count; i++)
            //    {
            //        if (xclass_all.Items[i].Selected == true && xclass_all.Items[i].Text != "")
            //        {
            //            if (!xclass_job.Items.Contains(xclass_all.Items[i]))
            //            {
            //                xclass_job.Items.Add(xclass_all.Items[i]);
            //            }
            //        }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //}
        }

        protected void btnbackword_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    for (int i = xclass_job.Items.Count - 1; i >= 0; i--)
            //    {
            //        if (xclass_job.Items[i].Selected == true)
            //        {
            //            //ListBox1.Items.Add(ListBox2.Items[i]);
            //            ListItem li = xclass_job.Items[i];
            //            xclass_job.Items.Remove(li);
            //        }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //}
        }

        protected void btnforward1_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    for (int i = 0; i < xsection_all.Items.Count; i++)
            //    {
            //        if (xsection_all.Items[i].Selected == true && xsection_all.Items[i].Text != "")
            //        {
            //            if (!xsection_job.Items.Contains(xsection_all.Items[i]))
            //            {
            //                xsection_job.Items.Add(xsection_all.Items[i]);
            //            }
            //        }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //}
        }

        protected void btnbackword1_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    for (int i = xsection_job.Items.Count - 1; i >= 0; i--)
            //    {
            //        if (xsection_job.Items[i].Selected == true)
            //        {
            //            //ListBox1.Items.Add(ListBox2.Items[i]);
            //            ListItem li = xsection_job.Items[i];
            //            xsection_job.Items.Remove(li);
            //        }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //}
        }

        protected void fnCreateDynamicControlAtPageLoad9()
        {
            if (ViewState["ctladded9"] != null)
            {
                int howMany = (int)ViewState["ctladded9"];
                for (int i = 1; i <= howMany; i++)
                {
                    fnCreateControl9(i);
                }
            }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ViewState["ctladded9"] == null)
                {
                    ViewState["ctladded9"] = 1;
                }

                ViewState["ctladded9"] = 1 + (int)ViewState["ctladded9"];



                fnCreateControl9((int)ViewState["ctladded9"]);
            }
            catch (Exception exp)
            {

                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void fnCreateControl9(int k)
        {
            try
            {

                HtmlGenericControl div1 = new HtmlGenericControl("div");
                HtmlGenericControl div2 = new HtmlGenericControl("div");
                HtmlGenericControl div3 = new HtmlGenericControl("div");
                HtmlGenericControl div4 = new HtmlGenericControl("div");
                HtmlGenericControl div5 = new HtmlGenericControl("div");
                HtmlGenericControl div6 = new HtmlGenericControl("div");

                div1.Attributes["class"] = "bm_ctl_container_dynamic_100_80_nl";
                div2.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div2.Attributes["style"] = "width: 184px";
                div3.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div3.Attributes["style"] = "width: 50px";
                div4.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div4.Attributes["style"] = "width: 130px";
                div5.Attributes["class"] = "bm_ctl_container_dynamic_100_80_wol";
                div5.Attributes["style"] = "width: 62%;";
                div6.Attributes["class"] = "bm_clt_padding";


                placeholder9.Controls.Add(div1);
                placeholder9.Controls.Add(div2);
                placeholder9.Controls.Add(div3);
                placeholder9.Controls.Add(div4);
                placeholder9.Controls.Add(div5);
                placeholder9.Controls.Add(div6);


                Label mylbl = new Label();
                DropDownList xsubject_job = new DropDownList();
                DropDownList xpaper_job = new DropDownList();
                DropDownList xclass_job = new DropDownList();
                //DropDownList xsection_job = new DropDownList();
                CheckBoxList xsection_job = new CheckBoxList();
                xsection_job.RepeatColumns = 10;
                //xsection_job.CssClass = "bm_paddiing_right";
                //xsection_job.CellSpacing = 5;

                zglobal.fnGetComboDataCD("Class Subject", xsubject_job);
                zglobal.fnGetComboDataCD("Subject Paper", xpaper_job);
                zglobal.fnGetComboDataCD("Class", xclass_job);
                //zglobal.fnGetComboDataCD("Section", xsection_job);
                zglobal.fnGetCheckBoxListItems("Section", xsection_job);

                mylbl.CssClass = "label";
                xsubject_job.CssClass = "bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown";
                xpaper_job.CssClass = "bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown";
                xclass_job.CssClass = "bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown";
                //xsection_job.CssClass = "bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown";


                if (k <= 9)
                {
                    mylbl.Text = "0" + k.ToString() + ".";
                }
                else
                {
                    mylbl.Text = k.ToString() + ".";
                }
                // mtxt2.Text = "Presidency International School";


                mylbl.ID = "mylbl" + k.ToString();
                xsubject_job.ID = "xsubject_job" + k.ToString();
                xpaper_job.ID = "xpaper_job" + k.ToString();
                xclass_job.ID = "xclass_job" + k.ToString();
                xsection_job.ID = "xsection_job" + k.ToString();

                mylbl.EnableViewState = true;
                xsubject_job.EnableViewState = true;
                xpaper_job.EnableViewState = true;
                xclass_job.EnableViewState = true;
                xsection_job.EnableViewState = true;

                div1.Controls.Add(mylbl);
                div2.Controls.Add(xsubject_job);
                div3.Controls.Add(xpaper_job);
                div4.Controls.Add(xclass_job);
                div5.Controls.Add(xsection_job);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

    }
}