using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class amdoublepro_preapp : System.Web.UI.Page
    {
        private void fnButtonState()
        {
            if (ViewState["xrow"] == null)
            {
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete1.Enabled = true;
                //dxstatus.Visible = false;
                //dxstatus.Text = "-";
                //xsessionpro.Text = "";
                //xclasspro.Text = "";
                //xgrouppro.Text = "";
                xsession.Enabled = true;
                xstdid.Enabled = true;
                hxstatus.Value = "";
                xstatus.InnerHtml = "";
                zemail.InnerHtml = "";
                xapprovedby.InnerHtml = "";
            }
            else
            {
                xsession.Enabled = false;
                xstdid.Enabled = false;

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xstatus1 = zglobal.fnGetValue("xstatus", "amdoublepro",
                               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                hxstatus.Value = xstatus1;
                xstatus.InnerHtml = xstatus1;
                zemail.InnerHtml = zglobal.fnGetValue("coalesce(zemail,'') as zemail", "amdoublepro",
                               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                xapprovedby.InnerHtml = zglobal.fnGetValue("coalesce(xapprovedby,'') as xapprovedby", "amdoublepro",
                               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                //xsessionpro.Text = zglobal.fnGetValue("xsessionpro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                //xclasspro.Text = zglobal.fnGetValue("xclasspro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                //xgrouppro.Text = zglobal.fnGetValue("xgrouppro", "ampromotionh",
                //               "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //dxstatus.Visible = true;

                if (xstatus1 == "New" || xstatus1 == "Undo")
                {
                    btnSubmit.Enabled = true;
                    btnSubmit1.Enabled = true;
                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDelete1.Enabled = true;
                    //dxstatus.Text = xstatus1;
                    hxstatus.Value = xstatus1;
                    //dxstatus.Style.Value = zglobal.am_new;

                    //xsessionpro.Enabled = true;
                    //xclasspro.Enabled = true;
                    //xgrouppro.Enabled = true;

                    //xsession.Enabled = false;
                    //xstdid.Enabled = false;

                }
                else
                {
                    btnSubmit.Enabled = false;
                    btnSubmit1.Enabled = false;
                    btnSave.Enabled = false;
                    btnSave1.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDelete1.Enabled = false;
                    //dxstatus.Text = xstatus1;
                    hxstatus.Value = xstatus1;
                    //dxstatus.Style.Value = zglobal.am_submited;

                    //xsessionpro.Enabled = false;
                    //xclasspro.Enabled = false;
                    //xgrouppro.Enabled = false;
                }

                //if (xstatus1 == "New" || xstatus1 == "Undo")
                //{
                //    dxstatus.Style.Value = zglobal.am_new;
                //}
                //else
                //{
                //    dxstatus.Style.Value = zglobal.am_submited;
                //}
                if (xstatus1 == "Undo1")
                {
                    //int t = 0;
                    //foreach (GridViewRow row in GridView1.Rows)
                    //{
                    //    Label lblxflag1 = row.FindControl("xflag1") as Label;
                    //    Label lblxflag2 = row.FindControl("xflag2") as Label;

                    //    if (lblxflag1.Text == "Wrong" || lblxflag2.Text == "Missing")
                    //    {
                    //        t = 1;
                    //        break;
                    //    }
                    //}

                    //if (t == 1)
                    //{
                    //    btnSave.Enabled = true;
                    //    btnSave1.Enabled = true;
                    //    btnDelete.Enabled = false;
                    //    btnDelete1.Enabled = false;
                    //    btnSubmit.Enabled = true;
                    //    btnSubmit1.Enabled = true;
                    //}
                    //else
                    //{
                    //    btnSave.Enabled = false;
                    //    btnSave1.Enabled = false;
                    //    btnDelete.Enabled = false;
                    //    btnDelete1.Enabled = false;
                    //    btnSubmit.Enabled = false;
                    //    btnSubmit1.Enabled = false;
                    //}

                    btnSave.Enabled = true;
                    btnSave1.Enabled = true;
                    //btnDelete.Enabled = false;
                    //btnDelete1.Enabled = false;
                    btnDelete.Enabled = true;
                    btnDelete1.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnSubmit1.Enabled = true;

                    //xsessionpro.Enabled = true;
                    //xclasspro.Enabled = true;
                    //xgrouppro.Enabled = true;
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ////zglobal.fnGetComboDataCD("Session", xsession);
                    ////        zglobal.fnGetComboDataCD("Session", xsessionpro);
                    ////        //zglobal.fnGetComboDataCD("Term", xterm);
                    ////        zglobal.fnGetComboDataCD("Education Group", xgroup);
                    ////        zglobal.fnGetComboDataCD("Education Group", xgrouppro);
                    ////        // zglobal.fnGetComboDataCD("Test Type", xcttype);

                    ////        zglobal.fnGetComboDataCD("Class", xclass);
                    ////        zglobal.fnGetComboDataCD("Class", xclasspro);
                    ////        //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    ////        //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    ////        zglobal.fnGetComboDataCD("Section", xsection);
                    ////        //zglobal.fnGetComboDataCD("Class Subject", xsubject);
                    //zglobal.fnGetComboDataCD("Dropout Type", xtype);
                    //zglobal.fnGetComboDataCD("Dropout Reason", xreason);
                    //xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    ////        //xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    ////        //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    ////        //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    ViewState["xrow"] = null;
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";

                    //        fnButtonState();
                    //        //btnShowList.Visible = false;
                    //        // pnllistct.Visible = false;
                    //        //retestfor.Visible = false;
                    //        //xreason_d.Visible = false;
                    //        //xschdate.Enabled = false;
                    //        //schedule_d.Visible = false;

                    //        //string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                    //        //string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                    //        //string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                    //        //string xgroup1 = Request.QueryString["xgroup"] != null ? Request.QueryString["xgroup"].ToString() : "";
                    //        //string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                    //        //string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
                    //        //string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
                    //        //string xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";
                    //        ////string xcttype1 = Request.QueryString["xcttype"] != null ? Request.QueryString["xcttype"].ToString() : "";
                    //        ////string xctno1 = Request.QueryString["xctno"] != null ? Request.QueryString["xctno"].ToString() : "";

                    //        //if (xsession1 != "" && xterm1 != "" && xclass1 != "" && xsection1 != "" && xsubject1 != "")
                    //        //{
                    //        //    xsession.Text = xsession1;
                    //        //    xterm.Text = xterm1;
                    //        //    xclass.Text = xclass1;
                    //        //    xgroup.Text = xgroup1;
                    //        //    xsection.Text = xsection1;
                    //        //    xsubject.Text = xsubject1;
                    //        //    xpaper.Text = xpaper1;
                    //        //    xext.Text = xext1;

                    //        //    combo_OnTextChanged(null, null);

                    //        //    //xcttype.Text = xcttype1;
                    //        //    //xcttype_Click(null, null);

                    //        //    //xctno.Text = xctno1;
                    //        //    //xctno_Click(null, null);
                    //        //}

                    //        divliststd.Visible = false;

                    xstatus.InnerHtml = "";
                    zemail.InnerHtml = "";
                    xapprovedby.InnerHtml = "";

                    _gridrow.Text = "10";
                    TextBox1.Text = "10";
                    _gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();

                    hstdrow.Value = "";
                    hstdsession.Value = "";
                    hstdid.Value = "";
                    hstdname.Value = "";

                }

                //       xstdname.Text = zglobal.fnGetValue("xname", "amstudentvw",
                //           "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //           xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xclass.Text = zglobal.fnGetValue("xclass", "amstudentvw",
                //          "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //          xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xgroup.Text = zglobal.fnGetValue("xgroup", "amstudentvw",
                //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //    xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xsection.Text = zglobal.fnGetValue("xsection", "amstudentvw",
                //    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //    xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xname.Text = zglobal.fnGetValue("xname", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xfname.Text = zglobal.fnGetValue("xfname", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");
                //       xmname.Text = zglobal.fnGetValue("xmname", "amstudentvw",
                //"zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xstdid='" +
                //xstdid.Text.ToString().Trim() + "' and xsession='" + xsession.Text.ToString().Trim() + "'");

                //BindGrid();
                //fnRegisterPostBack();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        public void fnRegisterPostBack()
        {
            foreach (GridViewRow row in dgvPromotedistNew.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }

            foreach (GridViewRow row in dgvPromotedistSubmitted.Rows)
            {
                LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            }
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        List<string> listsubject = new List<string>();
        private void BindGrid()
        {

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            //dts.Reset();

            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //string xsession1 = xsession.Text.Trim().ToString();
            //string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            //string xsection1 = xsection.Text.Trim().ToString();
            ////message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            ////return;
            //string str = "";

            ////if (ViewState["sortdr"] != null)
            ////{
            ////    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY " + Convert.ToString(ViewState["colid"]) + " " + Convert.ToString(ViewState["sortdr"]);
            ////}
            ////else
            ////{
            //    str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xname";
            ////}


            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //da.Fill(dts, "tempztcode");
            //DataTable dtmarks = new DataTable();
            //dtmarks = dts.Tables[0];

            //if (dtmarks.Rows.Count > 0)
            //{




            //    DataSet dts2 = new DataSet();

            //    dts2.Reset();

            //    //DateTime xexamdate1 = fnGetExamDate();
            //    string str2 = "SELECT xsubject FROM  amexamph_result_avg1 " +
            //                  "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass " +
            //                  "AND xgroup=@xgroup AND xsection=@xsection " +
            //                  "GROUP BY xsubject";

            //    SqlDataAdapter da2 = new SqlDataAdapter(str2, conn1);
            //    da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    da2.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //    da2.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //    da2.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //    da2.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //    da2.Fill(dts2, "tempztcode");
            //    DataTable dtmarks2 = new DataTable();
            //    dtmarks2 = dts2.Tables[0];
            //    //ViewState["amexamph_result_avg1"] = dtmarks2;
            //    if (dtmarks2.Rows.Count > 0)
            //    {
            //        ViewState["amexamph_result_avg1"] = dtmarks2;

            //        GridView1.Columns.Clear();


            //        DataSet dts3 = new DataSet();

            //        dts3.Reset();

            //        //DateTime xexamdate1 = fnGetExamDate();
            //        str2 = "SELECT * FROM  amexamph_result_avg1 " +
            //                      "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass " +
            //                      "AND xgroup=@xgroup AND xsection=@xsection ";

            //        SqlDataAdapter da3 = new SqlDataAdapter(str2, conn1);
            //        da3.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da3.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //        da3.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //        da3.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //        da3.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //        da3.Fill(dts3, "tempztcode");
            //        DataTable dtmarks3 = new DataTable();
            //        dtmarks3 = dts3.Tables[0];

            //        ViewState["amexamph_result_avg12"] = dtmarks3;

            //        //Change Index
            //        //ViewState["numrow"] = dtmarks2.Rows.Count;

            //        TemplateField tfield119 = new TemplateField();
            //        tfield119.HeaderText = "No.";
            //        tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        tfield119.ItemStyle.Width = 35;
            //        GridView1.Columns.Add(tfield119);

            //        //bfield = new BoundField();
            //        //bfield.HeaderText = "No.";
            //        //bfield.DataField = "xid";
            //        //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //bfield.ItemStyle.Width = 35;
            //        //GridView1.Columns.Add(bfield);

            //        bfield = new BoundField();
            //        bfield.HeaderText = "ID";
            //        //bfield.SortExpression = "xstdid";
            //        bfield.DataField = "xstdid";
            //        bfield.ItemStyle.Width = 50;
            //        bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        GridView1.Columns.Add(bfield);

            //        bfield = new BoundField();
            //        bfield.HeaderText = "Student's Name";
            //        //bfield.SortExpression = "xname";
            //        bfield.DataField = "xname";
            //        bfield.ItemStyle.Width = 200;
            //        GridView1.Columns.Add(bfield);



            //        //int tmarks = 0;
            //        //int passm = 0;
            //        //dt = new DataTable();
            //        //dt.Columns.AddRange(new DataColumn[3] { 
            //        //    new DataColumn("xsubject", typeof(string)),
            //        //    new DataColumn("xmark", typeof(string)),
            //        //    new DataColumn("xpassmark",typeof(string)) });
            //        listsubject.Clear();

            //        foreach (DataRow row in dtmarks2.Rows)
            //        {
            //            tfield = new TemplateField();
            //            tfield.HeaderText = row["xsubject"].ToString() ;
            //            tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //            tfield.ItemStyle.Width = 50;
            //            GridView1.Columns.Add(tfield);

            //            listsubject.Add(row["xsubject"].ToString());
            //            //tmarks = tmarks + Convert.ToInt32(row["xmark"].ToString());
            //            //passm = passm + Convert.ToInt32(row["xpassmark"].ToString());
            //            //dt.Rows.Add(row["xsubject"].ToString(), row["xmark"].ToString(), row["xpassmark"].ToString());
            //        }

            //         ViewState["xsubject"] = listsubject;

            //        //xtotalmaks.Text = tmarks.ToString();
            //        //int pass = (100 * passm) / tmarks;
            //        //xpassmarks.Text = pass.ToString() + "%";

            //        //TemplateField tfield9 = new TemplateField();
            //        //tfield9.HeaderText = "Pre. Marks";
            //        //tfield9.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield9.ItemStyle.Width = 70;
            //        //GridView1.Columns.Add(tfield9);

            //        ////if (xcttype.Text == "Extra Test" && xreference.SelectedItem.Text!="")
            //        //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
            //        //{
            //        //    tfield9.Visible = true;
            //        //}
            //        //else
            //        //{
            //        //    tfield9.Visible = false;
            //        //}

            //        //tfield = new TemplateField();
            //        //tfield.HeaderText = "Marks";
            //        //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield.ItemStyle.Width = 70;
            //        //GridView1.Columns.Add(tfield);

            //        //tfield = new TemplateField();
            //        //tfield.HeaderText = "%";
            //        //tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield.ItemStyle.Width = 70;
            //        //GridView1.Columns.Add(tfield);





            //        //TemplateField tfield1 = new TemplateField();
            //        //tfield1.HeaderText = "Comments";
            //        //tfield1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        ////tfield1.ItemStyle.Width = Unit.Pixel(250);
            //        //GridView1.Columns.Add(tfield1);




            //        //TemplateField tfield2 = new TemplateField();
            //        //tfield2.HeaderText = "";
            //        //tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield2.ItemStyle.Width = Unit.Pixel(30);
            //        //GridView1.Columns.Add(tfield2);

            //        //TemplateField tfield3 = new TemplateField();
            //        //tfield3.HeaderText = "";
            //        //tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        ////tfield1.ItemStyle.Width = 50;
            //        //GridView1.Columns.Add(tfield3);




            //         if (ViewState["xrow"] != null)
            //         {
            //             using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //             {
            //                 using (DataSet dts1 = new DataSet())
            //                 {
            //                     string query = "SELECT xsrow,coalesce(xpromoted,0) as xpromoted FROM ampromotiond WHERE zid=@zid AND xrow=@xrow";
            //                     SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
            //                     da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
            //                     da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
            //                     da1.Fill(dts1, "tblamadmisd");
            //                     //tblamadmisd = new DataTable();
            //                     amexamd = dts1.Tables[0];
            //                 }
            //             }

            //             ViewState["ampromotiond"] = amexamd;
            //             string xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
            //                    "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //             ViewState["xstatus"] = xstatus1;
            //             hxstatus.Value = xstatus1;
            //         }
            //         else
            //         {
            //             hxstatus.Value = "";
            //             ViewState["ampromotiond"] = null;
            //         }


            //        //TemplateField tfield4 = new TemplateField();
            //        //tfield4.HeaderText = "";
            //        //tfield4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield4.Visible = false;
            //        //GridView1.Columns.Add(tfield4);

            //        //TemplateField tfield5 = new TemplateField();
            //        //tfield5.HeaderText = "";
            //        //tfield5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield5.Visible = false;
            //        //GridView1.Columns.Add(tfield5);

            //        //TemplateField tfield6 = new TemplateField();
            //        //tfield6.HeaderText = "";
            //        //tfield6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield6.Visible = false;
            //        //GridView1.Columns.Add(tfield6);

            //        TemplateField tfield7 = new TemplateField();
            //        tfield7.HeaderText = "Promoted";
            //        tfield7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        tfield7.ItemStyle.Width = Unit.Pixel(30);
            //        // tfield7.Visible = false;
            //        GridView1.Columns.Add(tfield7);

            //        TemplateField tfield3 = new TemplateField();
            //        tfield3.HeaderText = "";
            //        tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //        //tfield1.ItemStyle.Width = 50;
            //        GridView1.Columns.Add(tfield3);

            //        BoundField bfield1 = new BoundField();
            //        bfield1.DataField = "xrow";
            //        GridView1.Columns.Add(bfield1);

            //        GridView1.DataSource = dtmarks;
            //        GridView1.DataBind();

            //        divliststd.Visible = true;

            //        int i = 1;
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            Label lbl = (Label) row.FindControl("lblno");
            //            lbl.Text = i.ToString();
            //            i++;
            //        }

            //        ViewState["dirState"] = dtmarks;
            //        // ViewState["sortdr"] = "Asc";


            //        bfield1.Visible = false;

            //        //}
            //        //else
            //        //{
            //        //    GridView1.DataSource = null;
            //        //    GridView1.DataBind();
            //        //    xtotalmaks.Text = "";
            //        //    xpassmarks.Text = "";
            //        //    ViewState["numrow"] = null;
            //        //}
            //        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 50, 78% , 60 ,false); </script>", false);

            //    }
            //    else
            //    {
            //        ViewState["amexamph_result_avg1"] = null;
            //        ViewState["amexamph_result_avg12"] = null;
            //        ViewState["xsubject"] = null;
            //        ViewState["ampromotiond"] = null;
            //        GridView1.DataSource = null;
            //        GridView1.DataBind();
            //        message.InnerHtml = "Generate final result before promotion.";
            //        message.Style.Value = zglobal.warningmsg;
            //        divliststd.Visible = false;
            //    }
            //}
            //else
            //{
            //    ViewState["amexamph_result_avg1"] = null;
            //    ViewState["amexamph_result_avg12"] = null;
            //    ViewState["xsubject"] = null;
            //    ViewState["ampromotiond"] = null;
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    //message.InnerHtml = "Student not found.";
            //    //message.Style.Value = zglobal.warningmsg;
            //    divliststd.Visible = false;
            //}

        }

        TextBox txTextBox;

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        if (ViewState["amexamph_result_avg1"] != null)
            //        {
            //            DataTable amexamph_result_avg1 = (DataTable) ViewState["amexamph_result_avg1"];

            //            Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

            //            Label lblno = new Label();
            //            lblno.ID = "lblno";
            //            e.Row.Cells[0].Controls.Add(lblno);

            //            //TextBox txtPreMarks = new TextBox();
            //            //txtPreMarks.ID = "txtPreMarks";
            //            //txtPreMarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //            //e.Row.Cells[3].Controls.Add(txtPreMarks);
            //            //txtPreMarks.Enabled = false;

            //            //TextBox txtMarks = new TextBox();
            //            //txtMarks.ID = "txtMarks";
            //            //txtMarks.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox bm_marks";
            //            ////txtMarks.AutoPostBack = true;
            //            ////txtMarks.TextChanged += OnTextChanged;
            //            //txtMarks.Attributes.Add("onkeyup", "enter(this,event)");
            //            //e.Row.Cells[4].Controls.Add(txtMarks);

            //            //TextBox txtComments = new TextBox();
            //            //txtComments.ID = "txtComments";
            //            //txtComments.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
            //            //txtComments.TextMode = TextBoxMode.MultiLine;
            //            //txtComments.Attributes.Add("onkeyup", "enter(this,event)");
            //            //e.Row.Cells[5].Controls.Add(txtComments);

            //            //HtmlGenericControl image = new HtmlGenericControl("img");
            //            //image.ID = "image2";
            //            //image.Attributes.Add("src", "/images/list-am32x32.png");
            //            //image.Attributes.Add("class", "bm_academic_list bm_list");
            //            //image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
            //            //e.Row.Cells[7].Controls.Add(image);

            //            //Label lblxline = new Label();
            //            //lblxline.ID = "xline";
            //            //e.Row.Cells[8].Controls.Add(lblxline);

            //            //Label lblxflag1 = new Label();
            //            //lblxflag1.ID = "xflag1";
            //            //e.Row.Cells[9].Controls.Add(lblxflag1);

            //            //Label lblxflag2 = new Label();
            //            //lblxflag2.ID = "xflag2";
            //            //e.Row.Cells[10].Controls.Add(lblxflag2);

            //            HtmlGenericControl lbl = new HtmlGenericControl("label");
            //            lbl.Attributes.Add("class", "switch");
            //            e.Row.Cells[amexamph_result_avg1.Rows.Count + 3].Controls.Add(lbl);

            //            CheckBox chkCheckBox = new CheckBox();
            //            chkCheckBox.ID = "xpromotion";
            //            //chkCheckBox.CssClass = "toggle-checkbox";
            //            //e.Row.Cells[amexamph_result_avg1.Rows.Count+3].Controls.Add(chkCheckBox);
            //            lbl.Controls.Add(chkCheckBox);

            //            HtmlGenericControl spn = new HtmlGenericControl("span");
            //            spn.Attributes.Add("class", "slider round");
            //            lbl.Controls.Add(spn);

            //            //ImageButton image = new ImageButton();
            //            //image.ID = "image2";
            //            //image.Attributes.Add("src", "/images/list-am32x32.png");
            //            //image.Attributes.Add("class", "bm_academic_list bm_list");
            //            //image.Attributes.Add("rowno", e.Row.RowIndex.ToString());
            //            //e.Row.Cells[6].Controls.Add(image);

            //            //if (ViewState["xrow"] != null)
            //            //{
            //            //    if (Convert.ToString(ViewState["xstatus"]) != "New" && Convert.ToString(ViewState["xstatus"]) != "Undo" && Convert.ToString(ViewState["xstatus"]) != "Undo1")
            //            //    {
            //            //        txtComments.Enabled = false;
            //            //        txtMarks.Enabled = false;
            //            //        chkCheckBox.Enabled = false;
            //            //        //image.Enabled = false;
            //            //        //Page.ClientScript.RegisterHiddenField("hxstatus", ViewState["xstatus"].ToString());
            //            //    }



            //            //    if (amexamd.Rows.Count > 0)
            //            //    {
            //            //        foreach (DataRow row in amexamd.Rows)
            //            //        {
            //            //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
            //            //            {
            //            //                if (row["xgetmark"].ToString() == "-1.00")
            //            //                {
            //            //                    txtMarks.Text = "";
            //            //                }
            //            //                else
            //            //                {
            //            //                    txtMarks.Text = row["xgetmark"].ToString();
            //            //                }

            //            //                int chk = DBNull.Value.Equals(row["xna"]) == true
            //            //                    ? 0
            //            //                    : Convert.ToInt32(row["xna"].ToString());

            //            //                if (chk == 1)
            //            //                {
            //            //                    chkCheckBox.Checked = true;
            //            //                }
            //            //                else
            //            //                {
            //            //                    chkCheckBox.Checked = false;
            //            //                }

            //            //                txtComments.Text = row["xremarks"].ToString();
            //            //                lblxline.Text = row["xline"].ToString();
            //            //                lblxflag1.Text = row["xflag11"].ToString();
            //            //                lblxflag2.Text = row["xflag22"].ToString();

            //            //                //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
            //            //                //{
            //            //                //    //if (row["xflag11"].ToString() == "Wrong" ||
            //            //                //    //    row["xflag22"].ToString() == "Missing" || row["xflag11"].ToString() == "Corrected" ||
            //            //                //    //    row["xflag22"].ToString() == "Taken")
            //            //                //    //if (row["xflag11"].ToString() == "" ||
            //            //                //    //    row["xflag22"].ToString() == "")
            //            //                //    if (row["xflag11"].ToString() == "Wrong" || row["xflag22"].ToString() == "Missing")
            //            //                //    {
            //            //                //        txtComments.Enabled = true;
            //            //                //        txtMarks.Enabled = true;
            //            //                //        chkCheckBox.Enabled = true;
            //            //                //    }

            //            //                //    //if (lblxline.Text == "" || lblxline.Text == String.Empty)
            //            //                //    //{
            //            //                //    //    txtComments.Enabled = true;
            //            //                //    //    txtMarks.Enabled = true;
            //            //                //    //}

            //            //                //}
            //            //                break;
            //            //            }
            //            //        }

            //            //        //if (Convert.ToString(ViewState["xstatus"]) == "Undo1")
            //            //        //{
            //            //        //    if (lblxline.Text == "" || lblxline.Text == String.Empty)
            //            //        //    {
            //            //        //        txtComments.Enabled = true;
            //            //        //        txtMarks.Enabled = true;
            //            //        //        chkCheckBox.Enabled = true;
            //            //        //    }
            //            //        //}
            //            //    }


            //            //}

            //            if (ViewState["ampromotiond"] != null)
            //            {
            //                if (ViewState["xstatus"].ToString() == "Approved")
            //                {
            //                    chkCheckBox.InputAttributes.Add("disabled", "disabled");
            //                }
            //                else
            //                {
            //                    chkCheckBox.InputAttributes.Remove("disabled");
            //                }

            //                DataTable ampromotiond = (DataTable) ViewState["ampromotiond"];
            //                DataRow[] result =
            //                   ampromotiond.Select("xsrow=" +
            //                                                xrow );
            //                if (result.Length > 0)
            //                {
            //                    if (result[0]["xpromoted"].ToString() == "1")
            //                    {
            //                        chkCheckBox.Checked = true;
            //                    }
            //                    else
            //                    {
            //                        chkCheckBox.Checked = false;
            //                    }
            //                }



            //            }

            //            //if (ViewState["dtprectmarks"] != null)
            //            //{
            //            //    DataTable dtprectmarks = (DataTable)ViewState["dtprectmarks"];
            //            //    if (dtprectmarks.Rows.Count > 0)
            //            //    {
            //            //        foreach (DataRow row in dtprectmarks.Rows)
            //            //        {
            //            //            if (row["xsrow"].ToString() == (e.Row.DataItem as DataRowView).Row["xrow"].ToString())
            //            //            {
            //            //                if (row["xgetmark"].ToString() == "-1.00")
            //            //                {
            //            //                    txtPreMarks.Text = "";
            //            //                }
            //            //                else
            //            //                {
            //            //                    txtPreMarks.Text = row["xgetmark"].ToString();
            //            //                }

            //            //                int chk = DBNull.Value.Equals(row["xna"]) == true
            //            //                  ? 0
            //            //                  : Convert.ToInt32(row["xna"].ToString());

            //            //                if (chk == 1)
            //            //                {
            //            //                    chkCheckBox.Checked = true;
            //            //                }
            //            //                else
            //            //                {
            //            //                    chkCheckBox.Checked = false;
            //            //                }

            //            //                break;
            //            //            }
            //            //        }
            //            //    }
            //            //}
            //            //else
            //            //{
            //            //    txtPreMarks.Text = "";
            //            //}

            //            DataTable amexamph_result_avg12 = (DataTable)ViewState["amexamph_result_avg12"];
            //            if (amexamph_result_avg12.Rows.Count > 0)
            //            {
            //                //DataRow[] result;

            //                for (int i = 3; i < amexamph_result_avg1.Rows.Count + 3; i++)
            //                {
            //                    DataRow[] result =
            //                    amexamph_result_avg12.Select("xsrow=" +
            //                                                 xrow + " and xsubject='" + ((List<string>)ViewState["xsubject"])[i - 3] + "'");
            //                    if (result.Length > 0)
            //                    {
            //                        e.Row.Cells[i].Text = result[0]["xgrade"].ToString();
            //                        e.Row.Cells[i].ToolTip = result[0]["xsubject"].ToString() + "\n Marks: " +
            //                                                 result[0]["xaveragemarks"].ToString();
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int i = 3; i < amexamph_result_avg1.Rows.Count + 3; i++)
            //                {
            //                    e.Row.Cells[i].Text = "";
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //DataTable dtrslt = (DataTable)ViewState["dirState"];
            ////message.InnerHtml = e.SortExpression;
            //if (dtrslt.Rows.Count > 0)
            //{
            //    ViewState["colid"] = e.SortExpression;
            //    if (ViewState["sortdr"] != null)
            //    {
            //        if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            //        {
            //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
            //            ViewState["sortdr"] = "Desc";
            //        }
            //        else
            //        {
            //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
            //            ViewState["sortdr"] = "Asc";
            //        }
            //    }
            //    else
            //    {
            //        dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
            //        ViewState["sortdr"] = "Desc";
            //    }
            //    GridView1.DataSource = dtrslt;
            //    GridView1.DataBind();

            //    int i = 1;
            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        Label lbl = (Label)row.FindControl("lblno");
            //        lbl.Text = i.ToString();
            //        i++;
            //    }
            //    //UpdatePanel1.Update();
            //}
        }

        protected void OnLinkClick(object sender, EventArgs e)
        {
            try
            {
                //LinkButton lb = (LinkButton) sender;
                //GridViewRow row = (GridViewRow) lb.NamingContainer;
                //if (row != null)
                //{
                //    //message.InnerHtml = lb.ID.ToString();
                //    int xcellno = int.Parse(lb.ID.ToString().Substring(9));
                //    //message.InnerHtml = lb.ID.ToString().Substring(9);
                //    lbldate.Text = Convert.ToDateTime(row.Cells[2 + (int) ViewState["rowCount"]].Text).ToString("dddd, MMMM dd, yyyy");
                //    lblperiod.Text = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //    lblsection.Text = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //    _xdate.Value = row.Cells[2 + (int) ViewState["rowCount"]].Text.ToString();
                //    _xperiod.Value = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //    _xsection.Value = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {
                //        using (DataSet dts = new DataSet())
                //        {
                //            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //            int xrow = Convert.ToInt32(ViewState["xrow"]);
                //            DateTime xdate2 = Convert.ToDateTime(row.Cells[2 + (int)ViewState["rowCount"]].Text);
                //            string xperiod2 = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
                //            string xsection2 = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

                //            string query = "SELECT xsubject,xpaper,xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, " +
                //                " (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1,xcteacher,xsteacher FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                //            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                //            da.Fill(dts, "tempTable");
                //            DataTable tempTable = new DataTable();
                //            tempTable = dts.Tables["tempTable"];

                //            if (tempTable.Rows.Count > 0)
                //            {
                //                xsubject.Text = tempTable.Rows[0]["xsubject"].ToString();
                //                xpaper.Text = tempTable.Rows[0]["xpaper"].ToString();
                //                xtopic.Value = tempTable.Rows[0]["xtopic"].ToString();
                //                xdetails.Value = tempTable.Rows[0]["xdetails"].ToString();
                //                xcteacher.Text = tempTable.Rows[0]["xcteacher1"].ToString();
                //                xsteacher.Text = tempTable.Rows[0]["xsteacher1"].ToString();
                //                _classteacher.Value = tempTable.Rows[0]["xcteacher"].ToString();
                //                _subteacher.Value = tempTable.Rows[0]["xsteacher"].ToString();
                //            }
                //            else
                //            {
                //                xsubject.Text = "";
                //                xpaper.Text = "";
                //                xtopic.Value = "";
                //                xdetails.Value = "";
                //                xcteacher.Text = "";
                //                xsteacher.Text = "";
                //                _classteacher.Value = "";
                //                _subteacher.Value = "";
                //            }


                //            da.Dispose();
                //        }
                //    }

                //    this.ModalPopupExtender1.Show();
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    TextBox tb = (TextBox)sender;
            //    GridViewRow row = (GridViewRow)tb.NamingContainer;
            //    if (row != null)
            //    {
            //        //    //message.InnerHtml = lb.ID.ToString();
            //        //    int xcellno = int.Parse(lb.ID.ToString().Substring(9));
            //        //    //message.InnerHtml = lb.ID.ToString().Substring(9);
            //        //    lbldate.Text = Convert.ToDateTime(row.Cells[2 + (int) ViewState["rowCount"]].Text).ToString("dddd, MMMM dd, yyyy");
            //        //    lblperiod.Text = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
            //        //    lblsection.Text = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();

            //        //    _xdate.Value = row.Cells[2 + (int) ViewState["rowCount"]].Text.ToString();
            //        //    _xperiod.Value = GridView1.HeaderRow.Cells[xcellno].Text.ToString();
            //        //    _xsection.Value = row.Cells[3 + (int)ViewState["rowCount"]].Text.ToString();
            //        int val = 4;
            //        //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //        //{
            //        //    val = 4;
            //        //}
            //        //else
            //        //{
            //        //    val = 3;
            //        //}

            //        if (Convert.ToDecimal(row.Cells[val].Text.ToString()) > Convert.ToDecimal(xmarks.Text.Trim()))
            //        {
            //            row.Cells[val].BackColor = Color.Bisque;
            //        }

            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        private void fnCheckRow()
        {
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts = new DataSet())
            //    {
            //        con.Open();
            //        string query =

            //        "SELECT * FROM ampromotionh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection";


            //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());

            //        DataTable tempTable = new DataTable();
            //        da.Fill(dts, "tempTable");
            //        tempTable = dts.Tables["tempTable"];

            //        if (tempTable.Rows.Count > 0)
            //        {
            //            ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
            //        }
            //        else
            //        {
            //            ViewState["xrow"] = null;
            //        }


            //    }
            //}
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //btnRefresh_Click(sender,e);
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    int xrow = 0;
            //    message.InnerHtml = "";

            //    ////Check for final approval
            //    //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    //{
            //    //    using (DataSet dts = new DataSet())
            //    //    {
            //    //        con.Open();
            //    //        string query =
            //    //            //"SELECT count(*) FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND coalesce(xext,'')=@xext AND xstatus='Approved3' ";
            //    //            "SELECT count(*) FROM amexamhh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test' AND xstatus='Approved3' ";

            //    //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //    //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsession",
            //    //            xsession.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xsection",
            //    //        //    xsection.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xsubject",
            //    //        //    xsubject.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //    //        //da.SelectCommand.Parameters.AddWithValue("@xext", xext.Text.ToString().Trim());



            //    //        DataTable tempTable = new DataTable();
            //    //        da.Fill(dts, "tempTable");
            //    //        tempTable = dts.Tables["tempTable"];

            //    //        if (Convert.ToInt32(tempTable.Rows[0][0]) > 0)
            //    //        {
            //    //            message.InnerHtml = "Best test selection already approved. Cann't insert new record for this term.";
            //    //            message.Style.Value = zglobal.warningmsg;
            //    //            return;
            //    //        }
            //    //    }
            //    //}


            //    bool isValid = true;
            //    string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

            //    if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Session</li>";
            //        isValid = false;
            //    }
            //    if (xstdid.Text == "" || xstdid.Text == string.Empty || xstdid.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Student ID</li>";
            //        isValid = false;
            //    }
            //    if (xreason.Text == "" || xreason.Text == string.Empty || xreason.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Reason</li>";
            //        isValid = false;
            //    }
            //    if (xdate.Text == "" || xdate.Text == string.Empty || xdate.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Dropout Date</li>";
            //        isValid = false;
            //    }
            //    //if (xamount.Text == "" || xamount.Text == string.Empty || xamount.Text == "[Select]")
            //    //{
            //    //    rtnMessage = rtnMessage + "<li>Default Amount</li>";
            //    //    isValid = false;
            //    //}
            //    //if (xsign.Text == "" || xsign.Text == string.Empty || xsign.Text == "[Select]")
            //    //{
            //    //    rtnMessage = rtnMessage + "<li>Sign</li>";
            //    //    isValid = false;
            //    //}


            //    rtnMessage = rtnMessage + "</ol></div>";
            //    if (!isValid)
            //    {
            //        message.InnerHtml = rtnMessage;
            //        message.Style.Value = zglobal.warningmsg;
            //        return;
            //    }

            //    //fnCheckRow();
            //    string xstatus2 = "";
            //    if (ViewState["xrow"] != null)
            //    {
            //        xstatus2 = zglobal.fnGetValue("xstatus", "amdoublepro",
            //              "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
            //        if (xstatus2 != "New" && xstatus2 != "Undo" && xstatus2 != "Undo1")
            //        {
            //            message.InnerHtml = "Status : " + xstatus2 + ". Cann't change data.";
            //            message.Style.Value = zglobal.warningmsg;
            //            return;
            //        }
            //    }

            //    //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    //{
            //    //    using (DataSet dts = new DataSet())
            //    //    {
            //    //        con.Open();
            //    //        string query =
            //    //            "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";

            //    //        SqlDataAdapter da = new SqlDataAdapter(query, con);

            //    //        da.SelectCommand.Parameters.AddWithValue("@zid",_zid);
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xcttype", xcttype.Text.ToString().Trim());
            //    //        da.SelectCommand.Parameters.AddWithValue("@xctno", xctno.Text.ToString().Trim());



            //    //        DataTable tempTable = new DataTable();
            //    //        da.Fill(dts, "tempTable");
            //    //        tempTable = dts.Tables["tempTable"];

            //    //        if (tempTable.Rows.Count > 0)
            //    //        {
            //    //            ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
            //    //        }
            //    //        else
            //    //        {
            //    //            ViewState["xrow"] = null;
            //    //        }


            //    //    }
            //    //}

            //    ////Duplicate entry check
            //    //if (ViewState["xrow"] != null)
            //    //{
            //    //    message.InnerHtml = "Cann't insert duplicate record.";
            //    //    message.Style.Value = zglobal.warningmsg;
            //    //    return;
            //    //}



            //    string xsession1 = "";
            //    string xstdid1 = "";
            //    string xtype1 = "";
            //    string xreason1 = "";
            //    string xtccertificate1 = "";
            //    string xmarksheet1 = "";
            //    string xcharcertificate1 = "";
            //    string xreference1 = "";
            //    DateTime xdate1 = new DateTime(2999, 12, 31);
            //    string xstatus1 = "New";
            //    string xremarks1 = "";
            //    string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //    string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //    string xapprovedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //    DateTime xapproveddt = DateTime.Now;
            //    string xname1 = "";
            //    string xclass1 = "";
            //    string xgroup1 = "";
            //    string xsection1 = "";


            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        //if (GridView1.Rows.Count > 0)
            //        //{
            //        if (ViewState["xrow"] == null)
            //        {


            //            //Duplicate entry check
            //            using (SqlConnection con = new SqlConnection(zglobal.constring))
            //            {
            //                using (DataSet dts = new DataSet())
            //                {
            //                    con.Open();
            //                    string query =
            //                        "SELECT * FROM amdoublepro WHERE zid=@zid AND xsession=@xsession AND xsrow=(select xrow from amadmis where xstdid=@xstdid) ";

            //                    SqlDataAdapter da = new SqlDataAdapter(query, con);

            //                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                    da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                    da.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid.Text.ToString().Trim());

            //                    DataTable tempTable = new DataTable();
            //                    da.Fill(dts, "tempTable");
            //                    tempTable = dts.Tables["tempTable"];

            //                    if (tempTable.Rows.Count > 0)
            //                    {
            //                        message.InnerHtml = "Cann't insert duplicate record.";
            //                        message.Style.Value = zglobal.warningmsg;
            //                        return;
            //                    }
            //                }
            //            }


            //            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //            {
            //                conn.Open();
            //                SqlCommand cmd = new SqlCommand();
            //                cmd.Connection = conn;

            //                DateTime ztime = DateTime.Now;
            //                DateTime zutime = DateTime.Now;
            //                _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //                xrow = 0;

            //                //string xtfccode1 = "";
            //                //string xclass1 = "";
            //                //string xgroup1 = "";
            //                //string xsection1 = "";
            //                //string xstdid1 = "";
            //                //decimal xamount1 = 0;
            //                //decimal xdisfixed1 = 0;
            //                //decimal xdisperc1 = 0;
            //                //decimal xvatfixed1 = 0;
            //                //decimal xvatperc1 = 0;
            //                //int xsign1 = 1;
            //                //DateTime xeffdate1 = DateTime.Now;
            //                //int zactive1 = 1;
            //                //string xstatus1 = "New";
            //                //string xremarks1 = "";
            //                //string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                //string xemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                //string xsubmitedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //                //DateTime xsubmitdt = DateTime.Now;


            //                string query =
            //                    "INSERT INTO amdoublepro (ztime,zid,xrow,xsession,xsrow,xtype,xreason,xtccertificate,xmarksheet,xcharcertificate,xreference,xdate,xstatus,xremarks,zemail,xstdid,xname,xclass,xgroup,xsection) " +
            //                    "VALUES(@ztime,@zid,@xrow,@xsession,(select xrow from amadmis where zid=@zid and xstdid=@xstdid),@xtype,@xreason,@xtccertificate,@xmarksheet,@xcharcertificate,@xreference,@xdate,@xstatus,@xremarks,@zemail,@xstdid," +
            //                    "(select xname from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession), " +
            //                    "(select xclass from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession), " +
            //                    "(select xgroup from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession), " +
            //                    "(select xsection from amstudentvw where zid=@zid and xstdid=@xstdid and xsession=@xsession)) ";

            //                xrow = zglobal.GetMaximumIdInt("xrow", "amdoublepro", " zid=" + _zid, 1, 1);
            //                ViewState["xrow"] = xrow;
            //                xsession1 = xsession.Text.Trim().ToString();
            //                xstdid1 = xstdid.Text.Trim().ToString();
            //                xtype1 = xtype.Text.Trim().ToString();
            //                xreason1 = xreason.Text.Trim().ToString();
            //                xtccertificate1 = xtccertificate.Text.Trim().ToString();
            //                xmarksheet1 = xmarksheet.Text.Trim().ToString();
            //                xcharcertificate1 = xcharcertificate.Text.Trim().ToString();
            //                xreference1 = xreference.Text.Trim().ToString();
            //                xdate1 = xdate.Text.ToString().Trim() != string.Empty
            //                    ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : new DateTime(2999, 12, 31);
            //                xremarks1 = xremarks.Text.Trim().ToString();



            //                cmd.CommandText = query;
            //                cmd.Parameters.AddWithValue("@ztime", ztime);
            //                cmd.Parameters.AddWithValue("@zid", _zid);
            //                cmd.Parameters.AddWithValue("@xrow", xrow);
            //                cmd.Parameters.AddWithValue("@xsession", xsession1);
            //                cmd.Parameters.AddWithValue("@xstdid", xstdid1);
            //                cmd.Parameters.AddWithValue("@xtype", xtype1);
            //                cmd.Parameters.AddWithValue("@xreason", xreason1);
            //                cmd.Parameters.AddWithValue("@xtccertificate", xtccertificate1);
            //                cmd.Parameters.AddWithValue("@xmarksheet", xmarksheet1);
            //                cmd.Parameters.AddWithValue("@xcharcertificate", xcharcertificate1);
            //                cmd.Parameters.AddWithValue("@xreference", xreference1);
            //                cmd.Parameters.AddWithValue("@xdate", xdate1);
            //                cmd.Parameters.AddWithValue("@xstatus", xstatus1);
            //                cmd.Parameters.AddWithValue("@xremarks", xremarks1);
            //                cmd.Parameters.AddWithValue("@zemail", zemail1);
            //                cmd.ExecuteNonQuery();
            //            }
            //        }



            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            conn.Open();
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;

            //            string query = "";
            //            //string query = "DELETE FROM amtfcconfigt WHERE zid=@zid AND xrow=@xrow";
            //            //cmd.Parameters.Clear();

            //            //cmd.CommandText = query;
            //            //cmd.Parameters.AddWithValue("@zid", _zid);
            //            //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //            ////if (xstatus1 != "Undo1" && xstatus1 != "Undo")
            //            ////if (xstatus1 != "Undo1")
            //            ////{
            //            //cmd.ExecuteNonQuery();
            //            ////}


            //            if (xrow == 0)
            //            {
            //                xsession1 = xsession.Text.Trim().ToString();
            //                xtype1 = xtype.Text.Trim().ToString();
            //                xreason1 = xreason.Text.Trim().ToString();
            //                xtccertificate1 = xtccertificate.Text.Trim().ToString();
            //                xmarksheet1 = xmarksheet.Text.Trim().ToString();
            //                xcharcertificate1 = xcharcertificate.Text.Trim().ToString();
            //                xreference1 = xreference.Text.Trim().ToString();
            //                xdate1 = xdate.Text.ToString().Trim() != string.Empty
            //                    ? DateTime.ParseExact(xdate.Text.ToString().Trim(), "dd/MM/yyyy",
            //                        CultureInfo.InvariantCulture)
            //                    : new DateTime(2999, 12, 31);
            //                xremarks1 = xremarks.Text.Trim().ToString();

            //                query = "UPDATE amdoublepro SET zutime=@zutime,xemail=@xemail, " +
            //                       "xtype=@xtype,xreason=@xreason, xtccertificate=@xtccertificate, xmarksheet=@xmarksheet,xcharcertificate=@xcharcertificate, " +
            //                       "xreference=@xreference, xdate=@xdate, xremarks=@xremarks " +
            //                       "WHERE zid=@zid AND xrow=@xrow ";

            //                cmd.Parameters.Clear();

            //                cmd.CommandText = query;
            //                cmd.Parameters.AddWithValue("@zid", _zid);
            //                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //                cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
            //                cmd.Parameters.AddWithValue("@xemail",
            //                    Convert.ToString(HttpContext.Current.Session["curuser"]));
            //                cmd.Parameters.AddWithValue("@xsession", xsession1);
            //                cmd.Parameters.AddWithValue("@xtype", xtype1);
            //                cmd.Parameters.AddWithValue("@xreason", xreason1);
            //                cmd.Parameters.AddWithValue("@xtccertificate", xtccertificate1);
            //                cmd.Parameters.AddWithValue("@xmarksheet", xmarksheet1);
            //                cmd.Parameters.AddWithValue("@xcharcertificate", xcharcertificate1);
            //                cmd.Parameters.AddWithValue("@xreference", xreference1);
            //                cmd.Parameters.AddWithValue("@xdate", xdate1);
            //                cmd.Parameters.AddWithValue("@xremarks", xremarks1);
            //                cmd.ExecuteNonQuery();


            //            }



            //            ////int flag = 0;
            //            ////foreach (GridViewRow row in GridView1.Rows)
            //            ////{


            //            ////    TextBox txtTextBox1 = row.FindControl("txtMarks") as TextBox;
            //            ////    decimal getmarks;
            //            ////    if (txtTextBox1.Text.Trim().ToString() == "" || txtTextBox1.Text.Trim().ToString() == String.Empty)
            //            ////    {
            //            ////        getmarks = 0;
            //            ////    }
            //            ////    else
            //            ////    {
            //            ////        getmarks = decimal.Parse(txtTextBox1.Text.Trim().ToString());
            //            ////    }

            //            ////    if (getmarks > decimal.Parse(xmarks.Text.Trim().ToString()))
            //            ////    {
            //            ////        row.BackColor = zglobal.rowerr;
            //            ////        flag = 1;
            //            ////    }
            //            ////}

            //            ////if (flag == 1)
            //            ////{
            //            ////    message.InnerText = "Student marks can not greater than exam marks.";
            //            ////    message.Style.Value = zglobal.warningmsg;
            //            ////    return;
            //            ////}


            //            //foreach (GridViewRow row in GridView1.Rows)
            //            //{

            //            //    int xline = zglobal.GetMaximumIdInt("xline", "amtfcconfigt", " zid=" + _zid + " and xrow=" + Convert.ToInt32(ViewState["xrow"]), "line");
            //            //    TextBox txtTextBox1 = row.FindControl("xamount") as TextBox;
            //            //    decimal xamount12;
            //            //    if (txtTextBox1.Text.Trim().ToString() == "" || txtTextBox1.Text.Trim().ToString() == String.Empty)
            //            //    {
            //            //        //getmarks = 0;
            //            //        xamount12 = 0;
            //            //    }
            //            //    else
            //            //    {
            //            //        xamount12 = decimal.Parse(txtTextBox1.Text.Trim().ToString());
            //            //    }

            //            //    CheckBox chkCheckBox = row.FindControl("selbiz") as CheckBox;

            //            //    int xna1;
            //            //    if (chkCheckBox.Checked == true)
            //            //    {
            //            //        //xna1 = 1;
            //            //        query = "INSERT INTO amtfcconfigt (zid,xrow,xline,xtype,xamount) " +
            //            //            "VALUES(@zid,@xrow,@xline,@xtype,@xamount) ";

            //            //        cmd.CommandText = query;
            //            //        cmd.Parameters.Clear();
            //            //        cmd.Parameters.AddWithValue("@zid", _zid);
            //            //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //            //        cmd.Parameters.AddWithValue("@xline", xline);
            //            //        cmd.Parameters.AddWithValue("@xtype", row.Cells[1].Text.ToString());
            //            //        cmd.Parameters.AddWithValue("@xamount", xamount12);
            //            //        cmd.ExecuteNonQuery();

            //            //    }
            //            //    //else
            //            //    //{
            //            //    //    xna1 = 0;
            //            //    //}

            //            //    //string xflag1 = "";
            //            //    //string xflag2 = "";

            //            //    //if (xstatus1 == "Undo1" || xstatus1 == "Undo")
            //            //    //if (xstatus1 == "Undo1")
            //            //    //{
            //            //    //    //Label lxflag1 = row.FindControl("xflag1") as Label;
            //            //    //    //Label lxflag2 = row.FindControl("xflag2") as Label;
            //            //    //    Label lxline = row.FindControl("xline") as Label;
            //            //    //    ////if (lxflag1.Text.ToString() == "Wrong" || lxflag1.Text.ToString() == "Corrected")
            //            //    //    //if (lxflag1.Text.ToString() == "Wrong")
            //            //    //    //{
            //            //    //    //    xflag1 = "Corrected";
            //            //    //    //}
            //            //    //    ////if (lxflag2.Text.ToString() == "Missing" || lxflag2.Text.ToString() == "Taken")
            //            //    //    //if (lxflag2.Text.ToString() == "Missing")
            //            //    //    //{
            //            //    //    //    xflag2 = "Taken";
            //            //    //    //}
            //            //    //    if (lxline.Text == "" || lxline.Text == String.Empty)
            //            //    //    {
            //            //    //        query = "INSERT INTO amexamd (zid,xrow,xline,xstdid,xsrow,xgetmark,xremarks,xna) " +
            //            //    //                "VALUES(@zid,@xrow,@xline,@xstdid,@xsrow,@xgetmark,@xremarks,@xna) ";

            //            //    //        cmd.CommandText = query;
            //            //    //        cmd.Parameters.Clear();
            //            //    //        cmd.Parameters.AddWithValue("@zid", _zid);
            //            //    //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //            //    //        cmd.Parameters.AddWithValue("@xline", xline);
            //            //    //        cmd.Parameters.AddWithValue("@xstdid", row.Cells[1].Text.ToString());
            //            //    //        cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[6].Text.ToString()));
            //            //    //        cmd.Parameters.AddWithValue("@xgetmark", getmarks);
            //            //    //        cmd.Parameters.AddWithValue("@xremarks", txtTextBox2.Text.Trim().ToString());
            //            //    //        cmd.Parameters.AddWithValue("@xna", xna1);
            //            //    //        cmd.ExecuteNonQuery();
            //            //    //    }
            //            //    //    else
            //            //    //    {
            //            //    //        query =
            //            //    //            "UPDATE amexamd SET zutime=@zutime,xemail=@xemail,xgetmark=@xgetmark,xremarks=@xremarks,xna=@xna " +
            //            //    //            "WHERE zid=@zid AND xrow=@xrow AND xline=@xline";

            //            //    //        cmd.CommandText = query;
            //            //    //        cmd.Parameters.Clear();
            //            //    //        cmd.Parameters.AddWithValue("@zid", _zid);
            //            //    //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //            //    //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lxline.Text));
            //            //    //        cmd.Parameters.AddWithValue("@xgetmark", getmarks);
            //            //    //        cmd.Parameters.AddWithValue("@xremarks", txtTextBox2.Text.Trim().ToString());
            //            //    //        cmd.Parameters.AddWithValue("@zutime", DateTime.Now);
            //            //    //        cmd.Parameters.AddWithValue("@xemail",
            //            //    //            Convert.ToString(HttpContext.Current.Session["curuser"]));
            //            //    //        cmd.Parameters.AddWithValue("@xna", xna1);
            //            //    //        cmd.ExecuteNonQuery();
            //            //    //    }
            //            //    //}
            //            //    //else
            //            //    //{
            //            //    //query = "INSERT INTO amexamd (zid,xrow,xline,xstdid,xsrow,xgetmark,xremarks,xna) " +
            //            //    //    "VALUES(@zid,@xrow,@xline,@xstdid,@xsrow,@xgetmark,@xremarks,@xna) ";

            //            //    //cmd.CommandText = query;
            //            //    //cmd.Parameters.Clear();
            //            //    //cmd.Parameters.AddWithValue("@zid", _zid);
            //            //    //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
            //            //    //cmd.Parameters.AddWithValue("@xline", xline);
            //            //    //cmd.Parameters.AddWithValue("@xstdid", row.Cells[1].Text.ToString());
            //            //    //cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[6].Text.ToString()));
            //            //    //cmd.Parameters.AddWithValue("@xgetmark", getmarks);
            //            //    //cmd.Parameters.AddWithValue("@xremarks", txtTextBox2.Text.Trim().ToString());
            //            //    //cmd.Parameters.AddWithValue("@xna", xna1);
            //            //    //cmd.ExecuteNonQuery();
            //            //    //}

            //            //}

            //            using (DataSet dts = new DataSet())
            //            {
            //                //conn.Open();
            //                //query =
            //                //    "SELECT * FROM ampromotionh as h inner join ampromotiond as d on  h.xrow=d.xrow and h.zid=d.zid " +
            //                //    "WHERE h.zid=@zid AND  d.xsrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid) AND h.xsession=@xsession and coalesce(xpromoted,0) = 1";

            //                query =
            //                   "SELECT * FROM ampromotionh as h inner join ampromotiond as d on  h.xrow=d.xrow and h.zid=d.zid " +
            //                   "WHERE h.zid=@zid AND  d.xsrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid) AND h.xsessionpro=@xsession";

            //                SqlDataAdapter da = new SqlDataAdapter(query, conn);

            //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //                da.SelectCommand.Parameters.AddWithValue("@xstdid", xstdid.Text.ToString().Trim());

            //                DataTable tempTable = new DataTable();
            //                da.Fill(dts, "tempTable");
            //                tempTable = dts.Tables["tempTable"];

            //                if (tempTable.Rows.Count > 0)
            //                {
            //                    query =
            //                        "UPDATE ampromotiond SET zactive=0 WHERE zid=@zid AND xrow=@xrow AND xsrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid)";

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.Clear();
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable.Rows[0]["xrow"].ToString()));
            //                    cmd.Parameters.AddWithValue("@xstdid", xstdid.Text.ToString().Trim());
            //                    cmd.ExecuteNonQuery();
            //                }
            //                else
            //                {
            //                    query =
            //                       "UPDATE amadmis SET zactive=0 WHERE zid=@zid AND xrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid)";

            //                    cmd.CommandText = query;
            //                    cmd.Parameters.Clear();
            //                    cmd.Parameters.AddWithValue("@zid", _zid);
            //                    cmd.Parameters.AddWithValue("@xstdid", xstdid.Text.ToString().Trim());
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }

            //        }
            //        //}
            //        //else
            //        //{
            //        //    message.InnerHtml = "No student found.";
            //        //    message.Style.Value = zglobal.warningmsg;
            //        //    return;
            //        //}

            //        tran.Complete();

            //    }

            //    //btnSave.Enabled = false;
            //    //btnSave1.Enabled = false;
            //    // btnRefresh_Click(null, null);
            //    message.InnerHtml = zglobal.savesuccmsg;
            //    message.Style.Value = zglobal.successmsg;
            //    //ViewState["xrow"] = xrow;
            //    //ViewState["xstatus"] = "New";
            //    //hiddenxstatus.Value = "New";

            //    //BindGrid();

            //    fnButtonState();
            //    fnFillGrid2();


            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //int xrow = int.Parse(ViewState["xrow"].ToString());
                //int xline1 = 0;
                //message.InnerHtml = "";

                //using (TransactionScope tran = new TransactionScope())
                //{
                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {

                //        using (DataSet dts = new DataSet())
                //        {

                //            DateTime xdate2 = Convert.ToDateTime(_xdate.Value);
                //            string xperiod2 = _xperiod.Value;
                //            string xsection2 = _xsection.Value;

                //            string query1 = "SELECT xline FROM amexamschd WHERE zid=@zid and xrow=@xrow and xsection=@xsection and xcperiod=@xcperiod and xdate=@xdate";
                //            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection2);
                //            da.SelectCommand.Parameters.AddWithValue("@xcperiod", xperiod2);
                //            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                //            da.Fill(dts, "tempTable");
                //            DataTable tempTable = new DataTable();
                //            tempTable = dts.Tables["tempTable"];

                //            if (tempTable.Rows.Count > 0)
                //            {
                //                xline1 = Convert.ToInt32(tempTable.Rows[0][0].ToString());
                //            }


                //            da.Dispose();
                //        }


                //        conn.Open();
                //        SqlCommand cmd = new SqlCommand();
                //        cmd.Connection = conn;


                //        //if (xline1 != 0)
                //        //{
                //        //    string query2 = "DELETE FROM amexamschd WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                //        //    cmd.Parameters.Clear();
                //        //    cmd.CommandText = query2;
                //        //    cmd.Parameters.AddWithValue("@zid", _zid);
                //        //    cmd.Parameters.AddWithValue("@xrow", xrow);
                //        //    cmd.Parameters.AddWithValue("@xline", xline1);
                //        //    cmd.ExecuteNonQuery();
                //        //}


                //        DateTime ztime = DateTime.Now;
                //        DateTime zutime = DateTime.Now;
                //        _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //        int xline = zglobal.GetMaximumIdInt("xline", "amexamschd", " zid=" + _zid + " and xrow=" + xrow, "line");
                //        string xsubject1 = "";
                //        string xpaper1 = "";
                //        DateTime xdate1 = DateTime.Now;
                //        string xsection1 = "";
                //        string xcperiod1 = "";
                //        string xcteacher1 = "";
                //        string xsteacher1 = "";
                //        string xtopic1 = "";
                //        string xdetails1 = "";
                //        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                //        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);

                //        string query;
                //        if (xline1 != 0)
                //        {
                //            query = "UPDATE amexamschd SET zutime=@zutime, xsubject=@xsubject, xpaper=@xpaper, xtopic=@xtopic, xdetails=@xdetails, xcteacher=@xcteacher, xsteacher=@xsteacher, xemail=@xemail WHERE zid=@zid AND xrow=@xrow AND xline=@xline";
                //            xline = xline1;
                //        }
                //        else
                //        {
                //            query = "INSERT INTO amexamschd (ztime,zid,xrow,xline,xsubject,xpaper,xdate,xsection,xcperiod,xcteacher,xsteacher,xtopic,xdetails,zemail) " +
                //                   "VALUES(@ztime,@zid,@xrow,@xline,@xsubject,@xpaper,@xdate,@xsection,@xcperiod,@xcteacher,@xsteacher,@xtopic,@xdetails,@zemail) ";
                //        }


                //        xsubject1 = xsubject.Text.ToString().Trim();
                //        xpaper1 = xpaper.Text.Trim().ToString();
                //        xdate1 = Convert.ToDateTime(_xdate.Value.ToString());
                //        xsection1 = _xsection.Value.ToString();
                //        xcperiod1 = _xperiod.Value.ToString();
                //        xcteacher1 = _classteacher.Value.ToString();
                //        xsteacher1 = _subteacher.Value.ToString();
                //        xtopic1 = xtopic.Value.Trim().ToString();
                //        xdetails1 = xdetails.Value.Trim().ToString();

                //        cmd.CommandText = query;
                //        cmd.Parameters.Clear();
                //        cmd.Parameters.AddWithValue("@ztime", ztime);
                //        cmd.Parameters.AddWithValue("@zutime", ztime);
                //        cmd.Parameters.AddWithValue("@zid", _zid);
                //        cmd.Parameters.AddWithValue("@xrow", xrow);
                //        cmd.Parameters.AddWithValue("@xline", xline);
                //        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                //        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                //        cmd.Parameters.AddWithValue("@xdate", xdate1);
                //        cmd.Parameters.AddWithValue("@xsection", xsection1);
                //        cmd.Parameters.AddWithValue("@xcperiod", xcperiod1);
                //        cmd.Parameters.AddWithValue("@xcteacher", xcteacher1);
                //        cmd.Parameters.AddWithValue("@xsteacher", xsteacher1);
                //        cmd.Parameters.AddWithValue("@xtopic", xtopic1);
                //        cmd.Parameters.AddWithValue("@xdetails", xdetails1);
                //        cmd.Parameters.AddWithValue("@zemail", zemail);
                //        cmd.Parameters.AddWithValue("@xemail", xemail);
                //        //if (xsubject.Text != "" && xpaper.Text != "")
                //        //{
                //            cmd.ExecuteNonQuery();
                //        //}


                //    }

                //    tran.Complete();

                //}




                //if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                //{
                //    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                //    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                //    BindGrid(year, month);
                //}
                //else
                //{
                //    BindGrid(1999, 1);
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnFillDataGrid(object sender, EventArgs e)
        {
            try
            {
                ////System.Threading.Thread.Sleep(1000);
                // message.InnerHtml = "";


                //if (xdate.Text != "" && xdate.Text != string.Empty && xdate.Text != "[Select]")
                //{
                //    int year = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Year.ToString());
                //    int month = int.Parse(Convert.ToDateTime(xdate.SelectedValue).Month.ToString());

                //    BindGrid(year, month);
                //}
                //else
                //{
                //    BindGrid(1999, 1);
                //    //GridView1.DataSource = null;
                //    //GridView1.DataBind();
                //}

                //BindGrid();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        private void fnGetScheduleDate(string xflag)
        {
            //using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts = new DataSet())
            //    {
            //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //        string xsession1 = xsession.Text.Trim().ToString();
            //        string xterm1 = xterm.Text.Trim().ToString();
            //        string xclass1 = xclass.Text.Trim().ToString();
            //        string xgroup1 = xgroup.Text.Trim().ToString();
            //        string xsection1 = xsection.Text.Trim().ToString();
            //        string xsubject1 = xsubject.Text.Trim().ToString();
            //        string xpaper1 = xpaper.Text.Trim().ToString();

            //        //string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //        //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited'";
            //        string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
            //                       "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test'";

            //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
            //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
            //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
            //        da.Fill(dts, "tempztcode");
            //        DataTable dtexam = new DataTable();
            //        dtexam = dts.Tables[0];
            //        //xdate.Items.Clear();
            //        //xdate.Items.Add("");
            //        if (dtexam.Rows.Count > 0)
            //        {
            //            ViewState["xnumsch"] = dtexam.Rows.Count;
            //            //foreach (DataRow row in dtexam.Rows)
            //            //{
            //            //    if (row["xdate"].Equals(DBNull.Value) == false)
            //            //    {
            //            //        // xdate.Items.Add(Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy"));
            //            //        //xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
            //            //    }
            //            //}
            //            //if (xflag == "comval")
            //            //{
            //            //    //xcttype.Text = "Test";
            //            //    fnEventValue("xcttype", null, null);
            //            //}
            //        }
            //        else
            //        {
            //            ViewState["xnumsch"] = null;
            //            //if (xflag == "comval")
            //            //{
            //            //    xcttype.Text = "Test (WS)";
            //            //    fnEventValue("xcttype", null, null);
            //            //}
            //        }
            //        //xdate.Text = "";
            //    }
            //}
        }

        private void fnFillGrid2()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    //string query =
                    //     "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession, " +
                    //     "(select xname from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xname, " +
                    //     "(select xstdid from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xstdid, " +
                    //     "(select xclass from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xclass, " +
                    //     "(select xgroup from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xgroup, " +
                    //     "(select xsection from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xsection, " +
                    //     "xtype, xreason, xstatus, xdate " +
                    //     "FROM amdoublepro WHERE zid=@zid AND xstatus='New' order by xrow desc";

                    string query =
                      "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession," +
                       "(select xname from amadmis where zid=amdoublepro.zid and xstdid=amdoublepro.xstdid) as xname," +
                       "xstdid, xclass, xgroup, xsection, " +
                       "xclasspro, xgrouppro, xsectionpro, xdate " +
                       "FROM amdoublepro WHERE zid=@zid AND xstatus='New' order by xrow desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvPromotedistNew.DataSource = tempTable;
                        dgvPromotedistNew.DataBind();
                    }
                    else
                    {
                        // btnShowList.Visible = false;
                        //pnllistct.Visible = false;
                        dgvPromotedistNew.DataSource = null;
                        dgvPromotedistNew.DataBind();
                    }


                }
            }

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    //string query =
                    //     "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession, " +
                    //     "(select xname from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xname, " +
                    //     "(select xstdid from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xstdid, " +
                    //     "(select xclass from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xclass, " +
                    //     "(select xgroup from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xgroup, " +
                    //     "(select xsection from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xsection, " +
                    //     "xtype, xreason, xstatus, xdate " +
                    //     "FROM amdoublepro WHERE zid=@zid AND xstatus='New' order by xrow desc";

                    string query =
                      "SELECT Top " + Int32.Parse(TextBox1.Text.Trim().ToString()) + " xrow,xsession," +
                       "(select xname from amadmis where zid=amdoublepro.zid and xstdid=amdoublepro.xstdid) as xname," +
                       "xstdid, xclass, xgroup, xsection, " +
                       "xclasspro, xgrouppro, xsectionpro, xdate " +
                       "FROM amdoublepro WHERE zid=@zid AND xstatus='Pre-approved' order by xrow desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        GridView1.DataSource = tempTable;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // btnShowList.Visible = false;
                        //pnllistct.Visible = false;
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }


                }
            }

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts1 = new DataSet())
                {
                    con.Open();
                    //string query =
                    //     "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " xrow,xsession, " +
                    //      "(select xname from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xname, " +
                    //     "(select xstdid from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xstdid, " +
                    //     "(select xclass from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xclass, " +
                    //     "(select xgroup from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xgroup, " +
                    //     "(select xsection from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xsection, " +
                    //     "xtype, xreason, xstatus, xdate " +
                    //     "FROM amdoublepro WHERE zid=@zid AND xstatus='Approved' order by xrow desc";

                    string query =
                           "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " xrow,xsession," +
                       "(select xname from amadmis where zid=amdoublepro.zid and xstdid=amdoublepro.xstdid) as xname," +
                       "xstdid, xclass, xgroup, xsection, " +
                       "xclasspro, xgrouppro, xsectionpro, xdate " +
                       "FROM amdoublepro WHERE zid=@zid AND xstatus='Approved' order by xrow desc";

                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);

                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



                    DataTable tempTable = new DataTable();
                    da1.Fill(dts1, "tempTable");
                    tempTable = dts1.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        // btnShowList.Visible = true;
                        //pnllistct.Visible = true;
                        dgvPromotedistSubmitted.DataSource = tempTable;
                        dgvPromotedistSubmitted.DataBind();
                    }
                    else
                    {
                        // btnShowList.Visible = false;
                        //pnllistct.Visible = false;
                        dgvPromotedistSubmitted.DataSource = null;
                        dgvPromotedistSubmitted.DataBind();
                    }


                }
            }
        }

        protected void fnFillGrid6(object sender, EventArgs e)
        {
            try
            {
                fnFillGrid2();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            //try
            //{
            ////    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ////    ////System.Threading.Thread.Sleep(1000);
            //    message.InnerHtml = "";
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    ViewState["xrow"] = null;
            //    divliststd.Visible = false;
            //    //    //fnGetScheduleDate();
            //    //    xdate.Text = "";
            //    //    //xctno.Items.Clear();
            //    //    //xctno.Items.Add("");
            //    //    //xcttype.Text = "";
            //    //    //xctno.Text = "";
            //    //    xmarks.Text = "";
            //    //    //xtopic.Value = "";
            //    //    xdetails.Value = "";
            //    //    //xcteacher.Text = "-";
            //    //    xcteacher.Text = "";
            //    //    //xsteacher.Text = "-";
            //    //    xsteacher.Text = "";
            //    //    dxstatus.Text = "-";
            //    //    fnButtonState();
            //    //    _classteacher.Value = "";
            //    //    _subteacher.Value = "";

            //    //    //fnFillGrid2();

            //    //    btnRefresh_Click(sender,e);
            //    //    //zglobal.fnComboBoxValueWithItem(xreference, "(xcttype + '-' + xctno) as xtext,(xcttype + '|' + xctno) as xvalue", "amexamh", "zid=" + _zid + " and xsession='" + xsession.Text + "' and xterm='" + xterm.Text +
            //    //    //     "' and xclass='" + xclass.Text + "' and xgroup='" + xgroup.Text + "' and xsection='" + xsection.Text + "' and xsubject='" + xsubject.Text + "' and xpaper='" + xpaper.Text + "' and xtype='Class Test' and xcttype in ('Test','Test (WS)') order by xctno");


            //    //    //fnGetScheduleDate("comval");

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //try 
        //    //{
        //        if (e.CommandName == "xno")
        //        {
        //            int rowIndex = Convert.ToInt32(e.CommandArgument);
        //            GridViewRow row = GridView1.Rows[rowIndex];
        //            //xdate.Text = row.Cells[1].Text;
        //            //xcttype.Text = row.Cells[2].Text;
        //            //xctno.Text = row.Cells[3].Text;
        //           // btnRefresh_Click(null,null);
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Date: " + row.Cells[1].Text + "\\Type: " + row.Cells[2].Text + "');", true);
        //        }
        //    //}
        //    //catch (Exception exp)
        //    //{
        //    //    message.InnerHtml = exp.Message;
        //    //    message.Style.Value = zglobal.errormsg;
        //    //}
        //}

        protected void FillControl(object sender, EventArgs e)
        {
            try
            {
                //LinkButton lb = (LinkButton)sender;
                //GridViewRow row = (GridViewRow)lb.NamingContainer;
                //if (row != null)
                //{
                //    int index = row.RowIndex; //gets the row index selected


                //    //xcttype.Text = GridView2.Rows[index].Cells[1].Text;
                //    //fnEventValue("xcttype", sender, e);

                //    //xctno.Text = GridView2.Rows[index].Cells[2].Text;
                //    //fnEventValue("xctno", sender, e);

                //    //xdate.Text = GridView2.Rows[index].Cells[3].Text;
                //    //fnEventValue("xdate", sender, e);




                //    //// xdate.Enabled = true;

                //    //btnRefresh_Click(sender, e);

                //    //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest" || xcttype.Text == "Missed Test")
                //    //{
                //    //    xreference_Click(sender, e);
                //    //}
                //}

                message.InnerHtml = "";

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();


                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = Convert.ToInt32(((LinkButton)sender).Text);

                //string str = "SELECT  xsession, " +
                //             "(select xstdid from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xstdid, " +
                //             "(select xname from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xname, " +
                //             "(select xclass from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xclass, " +
                //             "(select xgroup from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xgroup, " +
                //             "(select xsection from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xsection, " +
                //             "(select xfname from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xfname, " +
                //             "(select xmname from amstudentvw where zid=amdoublepro.zid and xsession=amdoublepro.xsession and xrow=amdoublepro.xsrow) as xmname, " +
                //             "xtype,xreason,xtccertificate,xmarksheet,xcharcertificate,xreference,xdate,xstatus,zemail,xapprovedby,xremarks " +
                //             " FROM amdoublepro where zid=@zid  and xrow=@xrow ";


                string str = "SELECT  xsession, xstdid, xname, xclass, xgroup, xsection, " +
                             "(select xfname from amadmis where zid=amdoublepro.zid and xrow=amdoublepro.xsrow) as xfname, " +
                             "(select xmname from amadmis where zid=amdoublepro.zid and xrow=amdoublepro.xsrow) as xmname, " +
                             "xtype,xreason,xtccertificate,xmarksheet,xcharcertificate,xreference,xdate,xstatus,zemail,xapprovedby,xremarks " +
                             "FROM amdoublepro where zid=@zid  and xrow=@xrow ";




                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.Fill(dts, "tempztcode");
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                ViewState["xrow"] = xrow.ToString();
                hiddenxrow.Value = ViewState["xrow"].ToString();

                xsession.Text = dttemp.Rows[0]["xsession"].ToString();
                xstdid.Text = dttemp.Rows[0]["xstdid"].ToString();
                xstdname.Text = dttemp.Rows[0]["xname"].ToString();
                xclass.Text = dttemp.Rows[0]["xclass"].ToString();
                xgroup.Text = dttemp.Rows[0]["xgroup"].ToString();
                xsection.Text = dttemp.Rows[0]["xsection"].ToString();
                xname.Text = dttemp.Rows[0]["xname"].ToString();
                xfname.Text = dttemp.Rows[0]["xfname"].ToString();
                xmname.Text = dttemp.Rows[0]["xmname"].ToString();
                xtype.Text = dttemp.Rows[0]["xtype"].ToString();
                xreason.Text = dttemp.Rows[0]["xreason"].ToString();
                xtccertificate.Text = dttemp.Rows[0]["xtccertificate"].ToString();
                xmarksheet.Text = dttemp.Rows[0]["xmarksheet"].ToString();
                xcharcertificate.Text = dttemp.Rows[0]["xcharcertificate"].ToString();
                xreference.Text = dttemp.Rows[0]["xreference"].ToString();
                xdate.Text = Convert.ToDateTime(dttemp.Rows[0]["xdate"]).ToString("dd/MM/yyyy");
                xremarks.Text = dttemp.Rows[0]["xremarks"].ToString();
                xstatus.InnerHtml = dttemp.Rows[0]["xstatus"].ToString();
                zemail.InnerHtml = dttemp.Rows[0]["zemail"].ToString();
                xapprovedby.InnerHtml = dttemp.Rows[0]["xapprovedby"].ToString();


                fnButtonState();
                BindGrid();
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
                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {
                        btnSave_Click(sender, e);

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
                                xstatus = "Approved";
                                string xflag10 = "";

                                string query = "";
                                //string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh", "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));

                                //if (xstatus1 == "Undo1")
                                //{
                                //    xflag10 = "Undo1";
                                //    foreach (GridViewRow row in GridView1.Rows)
                                //    {
                                //        Label lblxline = row.FindControl("xline") as Label;
                                //        Label lxflag1 = row.FindControl("xflag1") as Label;
                                //        Label lxflag2 = row.FindControl("xflag2") as Label;
                                //        //string xflag1 = "";
                                //        //string xflag2 = "";

                                //        string xflag1 = lxflag1.Text;
                                //        string xflag2 = lxflag2.Text;

                                //        if (lxflag1.Text.ToString() == "Wrong")
                                //        {
                                //            xflag1 = "Corrected";
                                //        }

                                //        if (lxflag2.Text.ToString() == "Missing")
                                //        {
                                //            xflag2 = "Taken";
                                //        }

                                //        query =
                                //            "UPDATE amexamd SET xflag1=@xflag1,xflag2=@xflag2,xundoby=@xundoby,xundodt=@xundodt " +
                                //            "WHERE zid=@zid AND xrow=@xrow AND xline=@xline";

                                //        cmd.Parameters.Clear();

                                //        cmd.CommandText = query;
                                //        cmd.Parameters.AddWithValue("@zid", _zid);
                                //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //        cmd.Parameters.AddWithValue("@xline", Int32.Parse(lblxline.Text));
                                //        cmd.Parameters.AddWithValue("@xflag1", xflag1);
                                //        cmd.Parameters.AddWithValue("@xflag2", xflag2);
                                //        cmd.Parameters.AddWithValue("@xundoby", Convert.ToString(HttpContext.Current.Session["curuser"]));
                                //        cmd.Parameters.AddWithValue("@xundodt", DateTime.Now);
                                //        cmd.ExecuteNonQuery();
                                //    }
                                //}


                                query =
                                    "UPDATE amdoublepro SET xstatus=@xstatus,xapprovedby=@xapprovedby,xapproveddt=@xapproveddt " +
                                    "WHERE zid=@zid AND xrow=@xrow ";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                cmd.Parameters.AddWithValue("@xapprovedby", xsubmitedby);
                                cmd.Parameters.AddWithValue("@xapproveddt", xsubmitdt);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.appsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        btnSubmit.Enabled = false;
                        btnSubmit1.Enabled = false;
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                        ViewState["xstatus"] = "Approved";
                        hxstatus.Value = "Approved";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        hiddenxstatus.Value = "Approved";
                        fnButtonState();
                        //BindGrid();
                        fnFillGrid2();
                    }
                }
                else
                {
                    message.InnerHtml = "No record found for approved.";
                    message.Style.Value = zglobal.warningmsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                message.InnerText = "";
                //fnCheckRow();

                //if (ViewState["xrow"] != null)
                //{
                //    string xstatus1 = zglobal.fnGetValue("xstatus", "amexamh",
                //         "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    if (xstatus1 != "New" && xstatus1 != "Undo" && xstatus1 != "Undo1")
                //    {
                //        message.InnerHtml = "Status : " + xstatus1 + ". Cann't change data.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}

                if (ViewState["xrow"] != null)
                {
                    if (txtconformmessageValue1.Value == "Yes")
                    {
                        string xstatus;


                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM amdoublepro WHERE zid=@zid AND xrow=@xrow";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.ExecuteNonQuery();

                                //query = "DELETE FROM ampromotionh WHERE zid=@zid AND xrow=@xrow";
                                //cmd.CommandText = query;
                                //cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        message.InnerHtml = zglobal.delsuccmsg;
                        message.Style.Value = zglobal.successmsg;
                        //btnSubmit.Enabled = false;
                        //btnSubmit1.Enabled = false;
                        //btnSave.Enabled = false;
                        //btnSave1.Enabled = false;
                        //btnDelete.Enabled = false;
                        //btnDelete1.Enabled = false;
                        //ViewState["xstatus"] = "Submited";
                        //hxstatus.Value = "Submited";
                        //dxstatus.Visible = true;
                        //btnPrint.Visible = true;
                        //dxstatus.Text = "Status : Submited";
                        //hiddenxstatus.Value = "Submited";
                        fnButtonState();
                        //BindGrid();
                        fnFillGrid2();
                    }
                }
                else
                {
                    message.InnerHtml = "No data found for delete.";
                    message.Style.Value = zglobal.warningmsg;
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        //protected void fnEventValue(string evnt, object sender, EventArgs e)
        //{
        //    //if (xcttype.Text == "Test")
        //    //{
        //    //    xschdate.Enabled = false;
        //    //    schedule_d.Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    schedule_d.Visible = false;
        //    //}

        //    //if ((xcttype.Text == "Extra Test" || xcttype.Text == "Retest") && xreference.Text == "")
        //    //{
        //    //    ViewState["dtprectmarks"] = null;
        //    //}

        //    //if (evnt == "xcttype")
        //    //{
        //    //    if (xcttype.Text == "Test")
        //    //    {
        //    //        ViewState["xnumsch"] = null;
        //    //        xdate.Text = "";
        //    //        xnsdate.Value = "";
        //    //        //xdate.Enabled = false;
        //    //        xschdate.Text = "";
        //    //        //xschdate.Enabled = false;
        //    //        //schedule_d.Visible = true;
        //    //        fnGetScheduleDate("evnval");
        //    //        if (ViewState["xnumsch"] != null)
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 1, Convert.ToInt32(ViewState["xnumsch"]));
        //    //        }
        //    //        else
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 2, 1);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        if (xcttype.Text != "")
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 1, 15);
        //    //        }
        //    //        else
        //    //        {
        //    //            zsetvalue.SetDWNumItem(xctno, 2, 1);
        //    //        }
        //    //        xdate.Text = "";
        //    //        xnsdate.Value = "";
        //    //        // xdate.Enabled = true;
        //    //        // schedule_d.Visible = false;

        //    //    }

        //    //    if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test")
        //    //    {
        //    //        retestfor.Visible = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        retestfor.Visible = false;
        //    //    }

        //        ////xreason_d.Visible = false;
        //        //ViewState["xdate1"] = null;
        //        //xnsdate.Value = "";
        //        //xreference.Text = "";
        //        //xreason.Text = "";
        //    }
        //    else if (evnt == "xctno")
        //    {
        //        if (xcttype.Text == "Test")
        //        {
        //            if (xctno.Text != "")
        //            {
        //                fnGetDate(sender, e);
        //                //xdate.Enabled = true;

        //                if (xdate.Text == "")
        //                {
        //                    ViewState["xdate1"] = null;
        //                }
        //                else
        //                {
        //                    ViewState["xdate1"] = xdate.Text.ToString().Trim();
        //                }

        //            }
        //            else
        //            {
        //                xdate.Text = "";
        //                xnsdate.Value = "";
        //                xschdate.Text = "";
        //                //xdate.Enabled = false;
        //                ViewState["xdate1"] = null;
        //            }
        //        }
        //        else
        //        {
        //            xdate.Text = "";
        //            xnsdate.Value = "";
        //            ViewState["xdate1"] = null;
        //            xschdate.Text = "";
        //            //schedule_d.Visible = false;

        //        }

        //        //xreason_d.Visible = false;
        //        xreason.Text = "";
        //    }
        //    else if (evnt == "xdate")
        //    {
        //        xreason.Text = "";
        //        if (xcttype.Text == "Test")
        //        {
        //            if (xctno.Text != "")
        //            {

        //                if (ViewState["xdate1"] != null)
        //                {
        //                    DateTime xnsdate1 = xnsdate.Value != ""
        //                        ? DateTime.ParseExact(xnsdate.Value.ToString(), "dd/MM/yyyy",
        //                            CultureInfo.InvariantCulture)
        //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //                    DateTime xdate1 = xdate.Text.Trim() != string.Empty
        //                        ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
        //                            CultureInfo.InvariantCulture)
        //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


        //                    DateTime xpsdate = ViewState["xdate1"] != null
        //                        ? DateTime.ParseExact(Convert.ToString(ViewState["xdate1"]), "dd/MM/yyyy",
        //                            CultureInfo.InvariantCulture)
        //                        : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);


        //                    if (xdate1.Date >= xnsdate1.Date || xdate1.Date < xpsdate.Date)
        //                    {
        //                        xdate.Text = Convert.ToString(ViewState["xdate1"]);
        //                        message.InnerHtml = "Cann't exceed next schedule date. Select a date between '" + xpsdate.ToString("dd/MM/yyyy") + "' and '" + xnsdate1.ToString("dd/MM/yyyy") + "'";
        //                        //return;
        //                        message.Style.Value = zglobal.warningmsg;
        //                        ViewState["xreturn"] = 1;
        //                    }

        //                    //if (Convert.ToString(ViewState["xdate1"]) != xdate.Text.ToString().Trim())
        //                    //{
        //                    //    xreason_d.Visible = true;
        //                    //}
        //                    //else
        //                    //{
        //                    //    xreason_d.Visible = false;
        //                    //    xreason.Text = "";
        //                    //}
        //                }
        //            }
        //            else
        //            {
        //                //xreason_d.Visible = false;
        //                xreason.Text = "";
        //                ViewState["xdate1"] = null;
        //                xnsdate.Value = "";
        //            }
        //        }
        //        else
        //        {
        //            //xreason_d.Visible = false;
        //            xreason.Text = "";
        //            ViewState["xdate1"] = null;
        //            xnsdate.Value = "";
        //        }

        //    }
        //}

        protected void xcttype_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    //fnEventValue("xcttype", sender, e);

            //    btnRefresh_Click(sender, e);
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void xctno_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    //fnEventValue("xctno", sender, e);

            //    btnRefresh_Click(sender, e);

            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //    {
            //        xreference_Click(sender, e);
            //    }
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void xdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";
            //    fnEventValue("xdate", sender, e);

            //    if (Convert.ToInt32(ViewState["xreturn"]) == 1)
            //    {
            //        ViewState["xreturn"] = null;
            //        return;
            //    }

            //    string xdate10 = xdate.Text;

            //    btnRefresh_Click(sender, e);

            //    if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //    {
            //        xreference_Click(sender, e);
            //    }

            //    xdate.Text = xdate10;
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // message.InnerHtml = "";
                ////    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                ////    //ViewState["dtprectmarks"] = null;



                //    fnCheckRow();


                ////    if (ViewState["xrow"] != null)
                ////    {
                ////        string xmarks1 = zglobal.fnGetValue("xmarks", "amexamh",
                ////            "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                ////        xmarks.Text = xmarks1;

                ////        string xdate1 = zglobal.fnGetValue("xdate", "amexamh",
                ////            "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                ////        xdate.Text = Convert.ToDateTime(xdate1).ToString("dd/MM/yyyy");
                ////    }
                ////    else
                ////    {


                ////        //if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test")
                ////        //{
                ////        //    xmarks.Text = "";
                ////        //}
                ////    }

                ////    if (ViewState["xrow"] == null )
                ////    {
                ////        //using (SqlConnection conn = new SqlConnection(zglobal.constring))
                ////        //{
                ////        //    using (DataSet dts = new DataSet())
                ////        //    {

                ////        //        string xsession1 = xsession.Text.Trim().ToString();
                ////        //        string xterm1 = xterm.Text.Trim().ToString();
                ////        //        string xclass1 = xclass.Text.Trim().ToString();
                ////        //        string xgroup1 = xgroup.Text.Trim().ToString();
                ////        //        string xsection1 = xsection.Text.Trim().ToString();
                ////        //        string xsubject1 = xsubject.Text.Trim().ToString();
                ////        //        string xpaper1 = xpaper.Text.Trim().ToString();
                ////        //        //DateTime xdate1 = xdate.Text.Trim() != string.Empty
                ////        //        //    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                ////        //        //        CultureInfo.InvariantCulture)
                ////        //        //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ////        //        //string query = "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher,xretestfor " +
                ////        //        //               "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                ////        //        //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' AND xdate=@xdate";
                ////        //        string query =
                ////        //            "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamschd.zid and xemp=amexamschd.xsteacher) as xsteacher1, xcteacher,xsteacher " +
                ////        //            "FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                ////        //            "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test'  AND xdate=@xdate";

                ////        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                ////        //        da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                ////        //        //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                ////        //        da.Fill(dts, "tempztcode");
                ////        //        DataTable dtexam = new DataTable();
                ////        //        dtexam = dts.Tables[0];


                ////        //        if (dtexam.Rows.Count > 0)
                ////        //        {
                ////        //            //xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
                ////        //            xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
                ////        //            xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
                ////        //            xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
                ////        //            _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
                ////        //            _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();


                ////        //        }
                ////        //        else
                ////        //        {
                ////        //            if (ViewState["xdate1"] == null)
                ////        //            {
                ////        //                //xtopic.Value = "";
                ////        //                xdetails.Value = "";
                ////        //                //xsteacher.Text = "-";
                ////        //                //xcteacher.Text = "-";
                ////        //                xsteacher.Text = "";
                ////        //                xcteacher.Text = "";
                ////        //                dxstatus.Text = "-";
                ////        //                _classteacher.Value = "";
                ////        //                _subteacher.Value = "";
                ////        //            }

                ////        //        }



                ////        //    }
                ////        //}
                ////    }
                ////    else
                ////    {
                ////        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                ////        {
                ////            using (DataSet dts = new DataSet())
                ////            {

                ////                string query =
                ////                    "SELECT xtopic,xdetails,(select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xcteacher) as xcteacher1, (select xname from hrmst where zid=amexamh.zid and xemp=amexamh.xsteacher) as xsteacher1, xcteacher,xsteacher,xrefcttype,xrefctno,xreason,xdate,xschdate " +
                ////                    "FROM amexamh " +
                ////                    "WHERE zid=@zid AND xrow=@xrow";

                ////                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                ////                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////                da.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                ////                da.Fill(dts, "tempztcode");
                ////                DataTable dtexam = new DataTable();
                ////                dtexam = dts.Tables[0];


                ////                if (dtexam.Rows.Count > 0)
                ////                {
                ////                    //xtopic.Value = dtexam.Rows[0]["xtopic"].ToString();
                ////                    xdetails.Value = dtexam.Rows[0]["xdetails"].ToString();
                ////                    xsteacher.Text = dtexam.Rows[0]["xsteacher1"].ToString();
                ////                    xcteacher.Text = dtexam.Rows[0]["xcteacher1"].ToString();
                ////                    _classteacher.Value = dtexam.Rows[0]["xcteacher"].ToString();
                ////                    _subteacher.Value = dtexam.Rows[0]["xsteacher"].ToString();
                ////                    //xdate.Text = Convert.ToDateTime(dtexam.Rows[0]["xdate"]).ToString("dd/MM/yyyy");


                ////                    //if (xreference.Items.Contains(new ListItem(dtexam.Rows[0]["xretestfor"].ToString())))
                ////                    //{
                ////                    //    xreference.Text = dtexam.Rows[0]["xretestfor"].ToString();
                ////                    //}

                ////                    //string xref = dtexam.Rows[0]["xrefcttype"].ToString() + "|" +
                ////                    //              dtexam.Rows[0]["xrefctno"].ToString();

                ////                    //if (dtexam.Rows[0]["xrefcttype"].ToString() != "" &&
                ////                    //    dtexam.Rows[0]["xrefcttype"].ToString() != "")
                ////                    //{
                ////                    //    //xreference.SelectedValue = xref;
                ////                    //}
                ////                    // xreason.Text = dtexam.Rows[0]["xreason"].ToString();

                ////                    //if (dtexam.Rows[0]["xdate"].ToString() != dtexam.Rows[0]["xschdate"].ToString() && xcttype.Text=="Test")
                ////                    //{
                ////                    //    xreason_d.Visible = true;
                ////                    //   // ViewState["xdate1"] = dtexam.Rows[0]["xdate"];
                ////                    //}
                ////                    //else
                ////                    //{
                ////                    //    xreason_d.Visible = false;
                ////                    //   // ViewState["xdate1"] = null;
                ////                    //}
                ////                }
                ////                else
                ////                {
                ////                    //if (xcttype.Text != "Retest" && xcttype.Text != "Extra Test")
                ////                    //{
                ////                    //    xtopic.Value = "";
                ////                    //}

                ////                    xdetails.Value = "";
                ////                    //xsteacher.Text = "-";
                ////                    //xcteacher.Text = "-";
                ////                    xsteacher.Text = "";
                ////                    xcteacher.Text = "";
                ////                    dxstatus.Text = "-";
                ////                    _classteacher.Value = "";
                ////                    _subteacher.Value = "";
                ////                }



                ////            }
                ////        }



                ////    }


                ////    //if (xcttype.Text == "Extra Test")
                ////    //{
                ////    //    if (xreference.SelectedItem.Text != "")
                ////    //    {
                ////    //        string[] sch = xreference.SelectedValue.Split('|');
                ////    //        string xrefcttype1 = sch[0];
                ////    //        string xrefctno1 = sch[1];

                ////    //        //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                ////    //        using (SqlConnection con = new SqlConnection(zglobal.constring))
                ////    //        {
                ////    //            using (DataSet dts = new DataSet())
                ////    //            {
                ////    //                con.Open();
                ////    //                string query;


                ////    //                query =
                ////    //                    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";


                ////    //                SqlDataAdapter da = new SqlDataAdapter(query, con);

                ////    //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xcttype", xrefcttype1);
                ////    //                da.SelectCommand.Parameters.AddWithValue("@xctno", xrefctno1);
                ////    //                //DateTime xdate1 = xdate.Text.Trim() != string.Empty
                ////    //                //    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
                ////    //                //        CultureInfo.InvariantCulture)
                ////    //                //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ////    //                //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


                ////    //                DataTable tempTable10 = new DataTable();
                ////    //                da.Fill(dts, "tempTable");
                ////    //                tempTable10 = dts.Tables["tempTable"];

                ////    //                if (tempTable10.Rows.Count > 0)
                ////    //                {
                ////    //                    query = "SELECT * FROM amexamd WHERE zid=@zid AND xrow=@xrow";


                ////    //                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                ////    //                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                ////    //                    da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable10.Rows[0]["xrow"]));

                ////    //                    dts.Reset();
                ////    //                    da1.Fill(dts, "tempztcode");
                ////    //                    DataTable dtexam1 = new DataTable();
                ////    //                    dtexam1 = dts.Tables[0];
                ////    //                    ViewState["dtprectmarks"] = dtexam1;
                ////    //                    dtprectmarks = dtexam1;
                ////    //                }
                ////    //                else
                ////    //                {
                ////    //                    ViewState["dtprectmarks"] = null;
                ////    //                    dtprectmarks = null;
                ////    //                }



                ////    //            }
                ////    //        }
                ////    //    }
                ////    //}


                //    BindGrid();
                ////    fnFillGrid2();
                /// 
                /// 

                //xsession.Text = "";
                //xstdid.Text = "";

                //ViewState["xrow"] = null;

                //fnButtonState();

                Response.Redirect(Request.RawUrl);


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void fnGetDate(object sender, EventArgs e)
        {
            try
            {
                //if (xctno.Text != "" && xctno.Text != string.Empty && xctno.Text != "[Select]")
                //{
                //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                //    {
                //        using (DataSet dts = new DataSet())
                //        {
                //            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //            string xsession1 = xsession.Text.Trim().ToString();
                //            string xterm1 = xterm.Text.Trim().ToString();
                //            string xclass1 = xclass.Text.Trim().ToString();
                //            string xgroup1 = xgroup.Text.Trim().ToString();
                //            string xsection1 = xsection.Text.Trim().ToString();
                //            string xsubject1 = xsubject.Text.Trim().ToString();
                //            string xpaper1 = xpaper.Text.Trim().ToString();

                //            //string query = "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                //            //               "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' AND xstatus='Submited' ";

                //            string query =
                //                "SELECT * FROM amexamschh INNER JOIN amexamschd ON amexamschh.zid=amexamschd.zid AND amexamschh.xrow=amexamschd.xrow " +
                //                "WHERE amexamschh.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xtype='Class Test' ORDER BY xdate ";

                //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                //            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm1);
                //            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
                //            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
                //            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
                //            da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                //            da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                //            da.Fill(dts, "tempztcode");
                //            DataTable dtexam = new DataTable();
                //            dtexam = dts.Tables[0];

                //            if (dtexam.Rows.Count > 0)
                //            {
                //                int count = 1;
                //                foreach (DataRow row in dtexam.Rows)
                //                {
                //                    if (row["xdate"].Equals(DBNull.Value) == false)
                //                    {
                //                        if (count == Int32.Parse(xctno.Text.Trim().ToString()))
                //                        {
                //                            xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
                //                            xschdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
                //                            if (count < dtexam.Rows.Count)
                //                            {
                //                                xnsdate.Value =
                //                                    Convert.ToDateTime(dtexam.Rows[count]["xdate"])
                //                                        .ToString("dd/MM/yyyy");
                //                            }
                //                            else
                //                            {
                //                                xnsdate.Value = "";
                //                            }
                //                            break;
                //                        }
                //                        else
                //                        {
                //                            xdate.Text = "";
                //                            xnsdate.Value = "";
                //                            xschdate.Text = "";
                //                        }

                //                        count = count + 1;
                //                    }
                //                }

                //                //for (int i = 1; i <= dtexam.Rows.Count; i++)
                //                //{
                //                //    if (dtexam.Rows[i-1]["xdate"].Equals(DBNull.Value) == false)
                //                //    {
                //                //        if (i == Int32.Parse(xctno.Text.Trim().ToString()))
                //                //        {
                //                //            xdate.Text = Convert.ToDateTime(row["xdate"]).ToString("dd/MM/yyyy");
                //                //            if (count < dtexam.Rows.Count)
                //                //            {
                //                //                xnsdate.Value =
                //                //                    Convert.ToDateTime(dtexam.Rows[count + 1]["xdate"])
                //                //                        .ToString("dd/MM/yyyy");
                //                //            }
                //                //            else
                //                //            {
                //                //                xnsdate.Value = "";
                //                //            }
                //                //            break;
                //                //        }
                //                //        else
                //                //        {
                //                //            xdate.Text = "";
                //                //            xnsdate.Value = "";
                //                //        }
                //                //    }
                //                //}
                //            }


                //        }
                //    }
                //}
                //else
                //{
                //    xdate.Text = "";
                //    xschdate.Text = "";
                //}

                //btnRefresh_Click(null, null);
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void xreference_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    message.InnerHtml = "";

            //    //string xrefcttype1 = "";
            //    //string xrefctno1 = "";
            //    //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    //if (xcttype.Text == "Retest" || xcttype.Text == "Extra Test")
            //    //{
            //    //    if (xreference.Text != "")
            //    //    {
            //    //        string[] sch = xreference.SelectedValue.Split('|');
            //    //        xrefcttype1 = sch[0];
            //    //        xrefctno1 = sch[1];

            //    //        if (xcttype.Text == xrefcttype1 && xctno.Text == xrefctno1)
            //    //        {
            //    //            message.InnerText = "Cann't reference same exam.";
            //    //            message.Style.Value = zglobal.warningmsg;
            //    //            xreference.Text = "";
            //    //            return;
            //    //        }
            //    //    }
            //    //}

            //    //string xref = xreference.SelectedValue;



            //    //if (xcttype.Text == "Extra Test" || xcttype.Text == "Retest")
            //    //{
            //    //    if (xreference.Text != "")
            //    //    {
            //    //        string[] sch = xreference.SelectedValue.Split('|');
            //    //        xrefcttype1 = sch[0];
            //    //        xrefctno1 = sch[1];

            //    //        //message.InnerText = xrefcttype1 + "-" + xrefctno1;
            //    //        //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    //        using (SqlConnection con = new SqlConnection(zglobal.constring))
            //    //        {
            //    //            using (DataSet dts = new DataSet())
            //    //            {
            //    //                con.Open();
            //    //                string query;


            //    //                query =
            //    //                    "SELECT * FROM amexamh WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xcttype=@xcttype AND xctno=@xctno";


            //    //                SqlDataAdapter da = new SqlDataAdapter(query, con);

            //    //                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //                da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            //    //                da.SelectCommand.Parameters.AddWithValue("@xcttype", xrefcttype1);
            //    //                da.SelectCommand.Parameters.AddWithValue("@xctno", xrefctno1);
            //    //                //DateTime xdate1 = xdate.Text.Trim() != string.Empty
            //    //                //    ? DateTime.ParseExact(xdate.Text.Trim().ToString(), "dd/MM/yyyy",
            //    //                //        CultureInfo.InvariantCulture)
            //    //                //    : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    //                //da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);


            //    //                DataTable tempTable10 = new DataTable();
            //    //                da.Fill(dts, "tempTable");
            //    //                tempTable10 = dts.Tables["tempTable"];

            //    //                if (tempTable10.Rows.Count > 0)
            //    //                {
            //    //                    query = "SELECT * FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamh.zid=@zid AND amexamh.xrow=@xrow";


            //    //                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
            //    //                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    //                    da1.SelectCommand.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable10.Rows[0]["xrow"]));

            //    //                    dts.Reset();
            //    //                    da1.Fill(dts, "tempztcode");
            //    //                    DataTable dtexam1 = new DataTable();
            //    //                    dtexam1 = dts.Tables[0];
            //    //                    ViewState["dtprectmarks"] = dtexam1;
            //    //                    dtprectmarks = dtexam1;

            //    //                    xmarks.Text = dtexam1.Rows[0]["xmarks"].ToString();
            //    //                    xtopic.Value = dtexam1.Rows[0]["xtopic"].ToString();
            //    //                    //foreach (DataRow row in dtprectmarks.Rows)
            //    //                    //{
            //    //                    //    message.InnerText = message.InnerText + " " + row["xgetmark"].ToString();
            //    //                    //}
            //    //                }
            //    //                else
            //    //                {
            //    //                    ViewState["dtprectmarks"] = null;
            //    //                    dtprectmarks = null;
            //    //                }



            //    //            }
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        ViewState["dtprectmarks"] = null;
            //    //        dtprectmarks = null;
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    ViewState["dtprectmarks"] = null;
            //    //    dtprectmarks = null;
            //    //}

            //    ////BindGrid();

            //    //btnRefresh_Click(sender, e);

            //    //xreference.SelectedValue = xref;

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            try
            {
                message.InnerText = "";

                //lblstdrow.Text = hstdrow.Value;
                //lblstdsession.Text = hstdsession.Value;
                //lblstdid.Text = hstdid.Value;
                //lblstdname.Text = hstdname.Value;

                //bool isValid = true;
                //string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";

                //if (xdateacc.Text == "" || xdateacc.Text == string.Empty || xdateacc.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Dropout Date</li>";
                //    isValid = false;
                //}

                //if (lblstdrow.Text == "" || lblstdrow.Text == string.Empty || lblstdrow.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Row</li>";
                //    isValid = false;
                //}

                //rtnMessage = rtnMessage + "</ol></div>";
                //if (!isValid)
                //{
                //    message.InnerHtml = rtnMessage;
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}

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
                        xstatus = "Pre-approved";

                        //DateTime xdateacc1 = xdateacc.Text.ToString().Trim() != string.Empty
                        //    ? DateTime.ParseExact(xdateacc.Text.ToString().Trim(), "dd/MM/yyyy",
                        //        CultureInfo.InvariantCulture)
                        //    : new DateTime(2999, 12, 31);

                        //string xremarksacc1 = xdetails.Value.Trim().ToString();

                        string query =
                            "UPDATE amdoublepro SET xstatus=@xstatus,xpreapprovedby=@xpreapprovedby,xpreapproveddt=@xpreapproveddt " +
                            "WHERE zid=@zid AND xrow=@xrow ";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(hstdrow.Value));
                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
                        cmd.Parameters.AddWithValue("@xpreapprovedby", xsubmitedby);
                        cmd.Parameters.AddWithValue("@xpreapproveddt", xsubmitdt);
                        cmd.ExecuteNonQuery();

                        //using (DataSet dts = new DataSet())
                        //{
                        //    //conn.Open();
                        //    //query =
                        //    //    "SELECT * FROM ampromotionh as h inner join ampromotiond as d on  h.xrow=d.xrow and h.zid=d.zid " +
                        //    //    "WHERE h.zid=@zid AND  d.xsrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid) AND h.xsession=@xsession and coalesce(xpromoted,0) = 1";

                        //    query =
                        //       "SELECT * FROM ampromotionh as h inner join ampromotiond as d on  h.xrow=d.xrow and h.zid=d.zid " +
                        //       "WHERE h.zid=@zid AND  d.xsrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid) AND h.xsessionpro=@xsession";

                        //    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                        //    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        //    da.SelectCommand.Parameters.AddWithValue("@xsession", lblstdsession.Text.ToString().Trim());
                        //    da.SelectCommand.Parameters.AddWithValue("@xstdid", lblstdid.Text.ToString().Trim());

                        //    DataTable tempTable = new DataTable();
                        //    da.Fill(dts, "tempTable");
                        //    tempTable = dts.Tables["tempTable"];

                        //    if (tempTable.Rows.Count > 0)
                        //    {
                        //        query =
                        //            "UPDATE ampromotiond SET zactiveacc=0 WHERE zid=@zid AND xrow=@xrow AND xsrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid)";

                        //        cmd.CommandText = query;
                        //        cmd.Parameters.Clear();
                        //        cmd.Parameters.AddWithValue("@zid", _zid);
                        //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable.Rows[0]["xrow"].ToString()));
                        //        cmd.Parameters.AddWithValue("@xstdid", lblstdid.Text.ToString().Trim());
                        //        cmd.ExecuteNonQuery();

                        //        query =
                        //          "UPDATE amadmis SET zactiveacccoa=0 WHERE zid=@zid AND xrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid)";

                        //        cmd.CommandText = query;
                        //        cmd.Parameters.Clear();
                        //        cmd.Parameters.AddWithValue("@zid", _zid);
                        //        cmd.Parameters.AddWithValue("@xstdid", lblstdid.Text.ToString().Trim());
                        //        cmd.ExecuteNonQuery();

                        //    }
                        //    else
                        //    {
                        //        query =
                        //           "UPDATE amadmis SET zactiveacc=0,zactiveacccoa=0 WHERE zid=@zid AND xrow=(select xrow from amadmis where zid=@zid AND xstdid=@xstdid)";

                        //        cmd.CommandText = query;
                        //        cmd.Parameters.Clear();
                        //        cmd.Parameters.AddWithValue("@zid", _zid);
                        //        cmd.Parameters.AddWithValue("@xstdid", lblstdid.Text.ToString().Trim());
                        //        cmd.ExecuteNonQuery();
                        //    }

                        //    query =
                        //       "SELECT * FROM amtfcseatconf " +
                        //       "WHERE zid=@zid AND  xstdid=@xstdid AND xsession=@xsession";

                        //    da = new SqlDataAdapter(query, conn);

                        //    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        //    da.SelectCommand.Parameters.AddWithValue("@xsession", lblstdsession.Text.ToString().Trim());
                        //    da.SelectCommand.Parameters.AddWithValue("@xstdid", lblstdid.Text.ToString().Trim());

                        //    dts.Reset();
                        //    tempTable = new DataTable();
                        //    da.Fill(dts, "tempTable");
                        //    tempTable = dts.Tables["tempTable"];

                        //    if (tempTable.Rows.Count > 0)
                        //    {
                        //        query =
                        //            "UPDATE amtfcseatconf SET zactive=0, zactiveacc=0 WHERE zid=@zid AND xrow=@xrow AND xstdid=@xstdid";

                        //        cmd.CommandText = query;
                        //        cmd.Parameters.Clear();
                        //        cmd.Parameters.AddWithValue("@zid", _zid);
                        //        cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(tempTable.Rows[0]["xrow"].ToString()));
                        //        cmd.Parameters.AddWithValue("@xstdid", lblstdid.Text.ToString().Trim());
                        //        cmd.ExecuteNonQuery();
                        //    }

                        //}
                    }

                    tran.Complete();
                }

                //message.InnerHtml = zglobal.appsuccmsg;
                //message.Style.Value = zglobal.successmsg;
                btnSubmit.Enabled = false;
                btnSubmit1.Enabled = false;
                btnSave.Enabled = false;
                btnSave1.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
                ViewState["xstatus"] = "Pre-approved";
                hxstatus.Value = "Pre-approved";
                //dxstatus.Visible = true;
                //btnPrint.Visible = true;
                //dxstatus.Text = "Status : Submited";
                hiddenxstatus.Value = "Pre-approved";
                fnButtonState();
                //BindGrid();
                fnFillGrid2();


            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}