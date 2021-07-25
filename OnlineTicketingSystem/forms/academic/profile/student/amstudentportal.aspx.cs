using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OnlineTicketingSystem.forms.academic.assesment.class_test_schedule
{
    public partial class amstudentportal : System.Web.UI.Page
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
            }
            else
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
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

            btnSubmit.Visible = false;
            btnSubmit1.Visible = false;
            btnDelete.Visible = false;
            btnDelete1.Visible = false;

            //UpdatePanel2.Visible = false;
            //UpdatePanel5.Visible = false;
            //btnSubmit.Enabled = true;
            //btnSubmit1.Enabled = true;

            btnSave.Enabled = true;
            btnSave1.Enabled = true;

            //divinfo.Visible = false;
            //xsessionpro.Enabled = false;
            //xclasspro.Enabled = false;
            //xgrouppro.Enabled = false;

            btnRefresh.Visible = false;
            btnRefresh1.Visible = false;
            btnSend.Visible = false;
            btnSend1.Visible = false;
            btnSave.Visible = false;
            btnSave1.Visible = false;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Session", xsessionpro);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    xgroup.Items.Add("All");
                    xgroup.Text = "All";
                    //zglobal.fnGetComboDataCD("Education Group", xgrouppro);
                    // zglobal.fnGetComboDataCD("Test Type", xcttype);

                    zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclasspro);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Subject Extension", xext);
                    zglobal.fnGetComboDataCD("Section", xsection);
                    xsection.Items.Add("All");
                    //xsection.Text = "All";
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");
                    //zsetvalue.SetDWNumItem(xctno, 1, 15);
                    //zsetvalue.SetDWNumItem(xctno, 2, 1);
                    ViewState["xrow"] = null;
                    ViewState["xstatus"] = null;
                    ViewState["dtprectmarks"] = null;
                    ViewState["colid"] = null;
                    ViewState["sortdr"] = null;
                    hxstatus.Value = "";
                    _classteacher.Value = "";
                    _subteacher.Value = "";

                    ViewState["ispostback"] = "yes";
                    ViewState["xtype"] = "Report Card";

                    fnButtonState();
                    //btnShowList.Visible = false;
                    // pnllistct.Visible = false;
                    //retestfor.Visible = false;
                    //xreason_d.Visible = false;
                    //xschdate.Enabled = false;
                    //schedule_d.Visible = false;

                    //string xsession1 = Request.QueryString["xsession"] != null ? Request.QueryString["xsession"].ToString() : "";
                    //string xterm1 = Request.QueryString["xterm"] != null ? Request.QueryString["xterm"].ToString() : "";
                    //string xclass1 = Request.QueryString["xclass"] != null ? Request.QueryString["xclass"].ToString() : "";
                    //string xgroup1 = Request.QueryString["xgroup"] != null ? Request.QueryString["xgroup"].ToString() : "";
                    //string xsection1 = Request.QueryString["xsection"] != null ? Request.QueryString["xsection"].ToString() : "";
                    //string xsubject1 = Request.QueryString["xsubject"] != null ? Request.QueryString["xsubject"].ToString() : "";
                    //string xpaper1 = Request.QueryString["xpaper"] != null ? Request.QueryString["xpaper"].ToString() : "";
                    //string xext1 = Request.QueryString["xext"] != null ? Request.QueryString["xext"].ToString() : "";
                    ////string xcttype1 = Request.QueryString["xcttype"] != null ? Request.QueryString["xcttype"].ToString() : "";
                    ////string xctno1 = Request.QueryString["xctno"] != null ? Request.QueryString["xctno"].ToString() : "";

                    //if (xsession1 != "" && xterm1 != "" && xclass1 != "" && xsection1 != "" && xsubject1 != "")
                    //{
                    //    xsession.Text = xsession1;
                    //    xterm.Text = xterm1;
                    //    xclass.Text = xclass1;
                    //    xgroup.Text = xgroup1;
                    //    xsection.Text = xsection1;
                    //    xsubject.Text = xsubject1;
                    //    xpaper.Text = xpaper1;
                    //    xext.Text = xext1;

                    //    combo_OnTextChanged(null, null);

                    //    //xcttype.Text = xcttype1;
                    //    //xcttype_Click(null, null);

                    //    //xctno.Text = xctno1;
                    //    //xctno_Click(null, null);
                    //}

                    divliststd.Visible = false;

                    //_gridrow.Text = zglobal._grid_row_value;
                    //_gridrow1.Text = zglobal._grid_row_value;
                    fnFillGrid2();

                    xstdcount.Visible = false;

                }


                GridViewHelper helper = new GridViewHelper(GridView1);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                helper.RegisterGroup("xsection", true, true);
                helper.ApplyGroupSort();


                BindGrid();
                fnRegisterPostBack();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            row.BackColor = Color.Gray;
            row.Cells[0].ForeColor = Color.White;
            row.Cells[0].Attributes.Add("style", "padding-left:30px");
            //Color.FromArgb(236, 236, 236);
        }

        public void fnRegisterPostBack()
        {
            //foreach (GridViewRow row in dgvPromotedistNew.Rows)
            //{
            //    LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            //}

            //foreach (GridViewRow row in dgvPromotedistSubmitted.Rows)
            //{
            //    LinkButton lnkFull1 = row.FindControl("xrow") as LinkButton;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
            //}
        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable amexamd;
        private DataTable dtprectmarks;
        List<string> listsubject = new List<string>();
        private void BindGrid()
        {
            if (ViewState["ispostback"] == "yes")
            {
                ViewState["ispostback"] = "no";
                return;
            }

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string xsession1 = xsession.Text.Trim().ToString();
            string xclass1 = xclass.Text.Trim().ToString();
            string xgroup1 = "";
            string xsection1 = "";

            if (xsection.Text.Trim().ToString() == "All")
            {
                
                for (int i = 0; i < xsection.Items.Count; i++)
                {
                    if (i == xsection.Items.Count - 1)
                    {
                        xsection1 = xsection1 + "'" + xsection.Items[i].ToString() + "'";
                    }
                    else
                    {
                        xsection1 = xsection1 + "'" + xsection.Items[i].ToString() + "',";
                    }

                }
            }
            else
            {
                xsection1 = "'" + xsection.Text.Trim().ToString() + "'";
            }

            if (xgroup.Text.Trim().ToString() == "All")
            {
               

                for (int i = 0; i < xgroup.Items.Count; i++)
                {
                    if (i == xgroup.Items.Count - 1)
                    {
                        xgroup1 = xgroup1 + "'" + xgroup.Items[i].ToString() + "'";
                    }
                    else
                    {
                        xgroup1 = xgroup1 + "'" + xgroup.Items[i].ToString() + "',";
                    }
                }
            }
            else
            {
                xgroup1 = "'" + xgroup.Text.Trim().ToString() + "'";
            }

            string str = "";

          

//            str = @"select d.xsrow as xrow,ROW_NUMBER() OVER (ORDER BY (select xstdid from amadmis where xrow=d.xsrow and zid=h.zid)) AS xid, 
//                   (select xname from amadmis where xrow=d.xsrow and zid=h.zid)  as xname,
//                   (select xstdid from amadmis where xrow=d.xsrow and zid=h.zid) as xstdid,
//                   case when (select count(*) from amexamvwnew as a where h.zid=a.zid and h.xsessionpro=a.xsession and d.xsrow=a.xsrow) > 0 then 'Locked' else 'Open' end
//                   as xstatus, coalesce(d.xsection,'') as xsection, coalesce(d.xgroup,'') as xgroup, h.xrow as xrow1
//                   from ampromotionh as h inner join ampromotiond as d on h.zid=d.zid and h.xrow=d.xrow 
//                   WHERE h.zid=@zid AND h.xsessionpro=@xsession  AND h.xclasspro=@xclass AND d.xgroup=@xgroup AND d.xsection=@xsection and h.xstatus='Approved' 
//                   and coalesce(d.xpromoted,0) = 1
//                   ORDER BY xname";
            //ROW_NUMBER() OVER (partition by zid,xsection order by zid,xsection,xname) AS xid,

            str = @"select xrow, xname, xstdid,xemail1,
                   xsection, xgroup, xprow as xrow1,xtype,(SELECT xcodealt FROM mscodesam WHERE zid=amstudentvw.zid AND xtype='Section' AND zactive=1 and xcode=amstudentvw.xsection) as xcodealt
                   from amstudentvw
                   WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup in(" + xgroup1 + ")  AND " +
                  "coalesce(xsection,'') in(" + xsection1 + ") " +
                  "ORDER BY xcodealt,xname";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass1);
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup1);
            da.SelectCommand.Parameters.AddWithValue("@xsection", xsection1);
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {
                

                xtotal.Text = zglobal.fnGetValue("count(xgender)", "amstudentvw",
                       "zid=" + _zid + " and xsession ='" + xsession1 + "' and xclass ='" + xclass1 + "' and xsection in(" +
                       xsection1 + ") and xgroup in(" + xgroup1 + ") ");

                xadmit.Text = zglobal.fnGetValue("count(xstdid)", "amaccclearance",
                       "zid=" + _zid + " and xsession ='" + xsession1 + "' and (select xclass from amstudentvw where zid=amaccclearance.zid and xsession=amaccclearance.xsession and xrow=amaccclearance.xsrow) ='" + xclass1 + "' and (select xsection from amstudentvw where zid=amaccclearance.zid and xsession=amaccclearance.xsession and xrow=amaccclearance.xsrow) in(" +
                       xsection1 + ") and (select xgroup from amstudentvw where zid=amaccclearance.zid and xsession=amaccclearance.xsession and xrow=amaccclearance.xsrow) in(" + xgroup1 + ") and xclearance=1 and xtype='Admit card'");

                xreport.Text = zglobal.fnGetValue("count(xstdid)", "amaccclearance",
                       "zid=" + _zid + " and xsession ='" + xsession1 + "' and (select xclass from amstudentvw where zid=amaccclearance.zid and xsession=amaccclearance.xsession and xrow=amaccclearance.xsrow) ='" + xclass1 + "' and (select xsection from amstudentvw where zid=amaccclearance.zid and xsession=amaccclearance.xsession and xrow=amaccclearance.xsrow) in(" +
                       xsection1 + ") and (select xgroup from amstudentvw where zid=amaccclearance.zid and xsession=amaccclearance.xsession and xrow=amaccclearance.xsrow) in(" + xgroup1 + ") and xclearance=1 and xtype='Report card'");

                xstdcount.Visible = true;

                //ViewState["ampromotiond"] = dtmarks;
                //string xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
                //       "zid=" + _zid + " AND xrow=" + Convert.ToInt32(dtmarks.Rows[0]["xrow1"]));
                //ViewState["xstatus"] = xstatus1;
                //hxstatus.Value = xstatus1;

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xsrow,coalesce(xclearance,0) as xclearance FROM amaccclearance WHERE zid=@zid AND xsession=@xsession and xterm=@xterm and xtype=@xtype";
                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xtype", "Admit Card");
                        da1.Fill(dts1, "tblamadmisd");
                        //tblamadmisd = new DataTable();
                        amexamd = dts1.Tables[0];

                        if (amexamd.Rows.Count > 0)
                        {
                            ViewState["ampromotiond"] = amexamd;
                        }
                        else
                        {
                            ViewState["ampromotiond"] = null;
                        }
                    }
                }

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "SELECT xsrow,coalesce(xclearance,0) as xclearance FROM amaccclearance WHERE zid=@zid AND xsession=@xsession and xterm=@xterm and xtype=@xtype";
                        SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.Trim().ToString());
                        da1.SelectCommand.Parameters.AddWithValue("@xtype", Convert.ToString(ViewState["xtype"]));
                        da1.Fill(dts1, "tblamadmisd");
                        //tblamadmisd = new DataTable();
                        amexamd = dts1.Tables[0];

                        if (amexamd.Rows.Count > 0)
                        {
                            ViewState["reportcard"] = amexamd;
                        }
                        else
                        {
                            ViewState["reportcard"] = null;
                        }
                    }
                }



                


                string str2 = "";                
                
               

                    GridView1.Columns.Clear();




                    TemplateField tfield119 = new TemplateField();
                    tfield119.HeaderText = "No.";
                    tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield119.ItemStyle.Width = 35;
                    GridView1.Columns.Add(tfield119);

                    //bfield = new BoundField();
                    //bfield.HeaderText = "No.";
                    //bfield.DataField = "xid";
                    //bfield.ItemStyle.Width = 35;
                    //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //GridView1.Columns.Add(bfield);
                   

                    bfield = new BoundField();
                    bfield.HeaderText = "ID";
                    //bfield.SortExpression = "xstdid";
                    bfield.DataField = "xstdid";
                    bfield.ItemStyle.Width = 50;
                    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    GridView1.Columns.Add(bfield);

                    bfield = new BoundField();
                    bfield.HeaderText = "Student's Name";
                    //bfield.SortExpression = "xname";
                    bfield.DataField = "xname";
                    bfield.ItemStyle.Width = 200;
                    GridView1.Columns.Add(bfield);


                     //if (ViewState["xrow"] != null)
                     //{
                     //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                     //    {
                     //        using (DataSet dts1 = new DataSet())
                     //        {
                     //            string query = "SELECT xsrow,coalesce(xpromoted,0) as xpromoted,coalesce(xsection,'') as xsection FROM ampromotiond " +
                     //                           "WHERE zid=@zid AND xrow=@xrow";
                     //            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);
                     //            da1.SelectCommand.Parameters.AddWithValue("zid", _zid);
                     //            da1.SelectCommand.Parameters.AddWithValue("xrow", Convert.ToInt32(ViewState["xrow"]));
                     //            da1.Fill(dts1, "tblamadmisd");
                     //            //tblamadmisd = new DataTable();
                     //            amexamd = dts1.Tables[0];
                     //        }
                     //    }

                     //    ViewState["ampromotiond"] = amexamd;
                     //    string xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
                     //           "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                     //    ViewState["xstatus"] = xstatus1;
                     //    hxstatus.Value = xstatus1;
                     //}
                     //else
                     //{
                     //    hxstatus.Value = "";
                     //    ViewState["ampromotiond"] = null;
                     //}


                    // TemplateField tfield10 = new TemplateField();
                    // tfield10.HeaderText = "Group";
                    // tfield10.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    // tfield10.ItemStyle.Width = Unit.Pixel(200);
                    // GridView1.Columns.Add(tfield10);

                    //TemplateField tfield7 = new TemplateField();
                    //tfield7.HeaderText = "Section";
                    //tfield7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //tfield7.ItemStyle.Width = Unit.Pixel(200);
                    //// tfield7.Visible = false;
                    //GridView1.Columns.Add(tfield7);

                    //bfield = new BoundField();
                    //bfield.HeaderText = "Group";
                    ////bfield.SortExpression = "xname";
                    //bfield.DataField = "xgroup";
                    //bfield.ItemStyle.Width = 150;
                    //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //GridView1.Columns.Add(bfield);

                    //bfield = new BoundField();
                    //bfield.HeaderText = "Section";
                    ////bfield.SortExpression = "xname";
                    //bfield.DataField = "xsection";
                    //bfield.ItemStyle.Width = 150;
                    //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //GridView1.Columns.Add(bfield);

                    //bfield = new BoundField();
                    //bfield.HeaderText = "Status";
                    ////bfield.SortExpression = "xname";
                    //bfield.DataField = "xstatus";
                    //bfield.ItemStyle.Width = 100;
                    //bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //GridView1.Columns.Add(bfield);

                    TemplateField tfield7 = new TemplateField();
                    tfield7.HeaderText = "Admit Card";
                    tfield7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield7.ItemStyle.Width = Unit.Pixel(150);
                    // tfield7.Visible = false;
                    GridView1.Columns.Add(tfield7);

                    TemplateField tfield70 = new TemplateField();
                    tfield70.HeaderText = "Report Card";
                    tfield70.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfield70.ItemStyle.Width = Unit.Pixel(150);
                    // tfield7.Visible = false;
                    GridView1.Columns.Add(tfield70);

                    bfield = new BoundField();
                    bfield.HeaderText = "Email";
                    //bfield.SortExpression = "xname";
                    bfield.DataField = "xemail1";
                    //bfield.ItemStyle.Width = 200;
                    GridView1.Columns.Add(bfield);

                    //TemplateField tfield3 = new TemplateField();
                    //tfield3.HeaderText = "";
                    //tfield3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    ////tfield1.ItemStyle.Width = 50;
                    //GridView1.Columns.Add(tfield3);

                    BoundField bfield3 = new BoundField();
                    bfield3.DataField = "xtype";
                    GridView1.Columns.Add(bfield3);

                    BoundField bfield2 = new BoundField();
                    bfield2.DataField = "xrow1";
                    GridView1.Columns.Add(bfield2);

                    BoundField bfield1 = new BoundField();
                    bfield1.DataField = "xrow";
                    GridView1.Columns.Add(bfield1);

                 
                   

                    GridView1.DataSource = dtmarks;
                    GridView1.DataBind();

                    divliststd.Visible = true;

                    int i = 1;
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        Label lbl = (Label)row.FindControl("lblno");
                        lbl.Text = i.ToString();
                        i++;
                    }

                    ViewState["dirState"] = dtmarks;
                    // ViewState["sortdr"] = "Asc";


                    bfield1.Visible = false;
                    bfield2.Visible = false;
                    bfield3.Visible = false;

                    
            }
            else
            {
                ViewState["amexamph_result_avg1"] = null;
                ViewState["amexamph_result_avg12"] = null;
                ViewState["xsubject"] = null;
                ViewState["ampromotiond"] = null;
                ViewState["reportcard"] = null;
                GridView1.DataSource = null;
                GridView1.DataBind();
                message.InnerHtml = "Student not found.";
                message.Style.Value = zglobal.warningmsg;
                divliststd.Visible = false;
                hxstatus.Value = "";
                //    ViewState["ampromotiond"] = null;
            }

        }

        TextBox txTextBox;

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //if (ViewState["amexamph_result_avg1"] != null)
                    //{
                        //DataTable amexamph_result_avg1 = (DataTable) ViewState["amexamph_result_avg1"];

                        Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

                        Label lblno = new Label();
                        lblno.ID = "lblno";
                        e.Row.Cells[0].Controls.Add(lblno);

                        HtmlGenericControl lbl = new HtmlGenericControl("label");
                        lbl.Attributes.Add("class", "switch");
                        //e.Row.Cells[amexamph_result_avg1.Rows.Count + 3].Controls.Add(lbl);
                        e.Row.Cells[3].Controls.Add(lbl);

                        CheckBox chkCheckBox = new CheckBox();
                        chkCheckBox.ID = "xclearance";
                        chkCheckBox.Checked = false;
                    //chkCheckBox.Enabled = false;
                        //e.Row.Cells[3].Controls.Add(chkCheckBox);
                        lbl.Controls.Add(chkCheckBox);

                        HtmlGenericControl spn = new HtmlGenericControl("span");
                        spn.Attributes.Add("class", "slider round");
                        lbl.Controls.Add(spn);

                        if (ViewState["ampromotiond"] != null)
                        {
                            DataTable ampromotiond = (DataTable)ViewState["ampromotiond"];
                            DataRow[] result =
                                ampromotiond.Select("xsrow=" +
                                                    xrow);
                            if (result.Length > 0)
                            {
                                if (result[0]["xclearance"].ToString() == "1")
                                {
                                    chkCheckBox.Checked = true;
                                }
                                else
                                {
                                    chkCheckBox.Checked = false;
                                }
                            }
                        }

                        //chkCheckBox.Enabled = false;
                        chkCheckBox.InputAttributes.Add("disabled", "disabled");


                        HtmlGenericControl lbl1 = new HtmlGenericControl("label");
                        lbl1.Attributes.Add("class", "switch");
                        //e.Row.Cells[amexamph_result_avg1.Rows.Count + 3].Controls.Add(lbl);
                        e.Row.Cells[4].Controls.Add(lbl1);

                        CheckBox chkCheckBox1 = new CheckBox();
                        chkCheckBox1.ID = "xreportcard";
                        chkCheckBox1.Checked = false;
                        //e.Row.Cells[3].Controls.Add(chkCheckBox);
                        lbl1.Controls.Add(chkCheckBox1);

                        HtmlGenericControl spn1 = new HtmlGenericControl("span");
                        spn1.Attributes.Add("class", "slider round");
                        lbl1.Controls.Add(spn1);

                        if (ViewState["reportcard"] != null)
                        {
                            DataTable ampromotiond = (DataTable)ViewState["reportcard"];
                            DataRow[] result =
                                ampromotiond.Select("xsrow=" +
                                                    xrow);
                            if (result.Length > 0)
                            {
                                if (result[0]["xclearance"].ToString() == "1")
                                {
                                    chkCheckBox1.Checked = true;
                                }
                                else
                                {
                                    chkCheckBox1.Checked = false;
                                }
                            }
                        }

                        chkCheckBox1.InputAttributes.Add("disabled", "disabled");

                    //    DropDownList dlistxgroup = new DropDownList();
                    //    dlistxgroup.ID = "xgroup";
                    //    e.Row.Cells[3].Controls.Add(dlistxgroup);
                    //    zglobal.fnGetComboDataCD("Education Group", dlistxgroup);

                    //DropDownList dlistxsection = new DropDownList();
                    //dlistxsection.ID = "xsection";
                    //e.Row.Cells[4].Controls.Add(dlistxsection);

                    //zglobal.fnGetComboDataCD("Section", dlistxsection);

                        

                        //if (ViewState["ampromotiond"] != null)
                        //{
                           

                        //    if ((e.Row.DataItem as DataRowView).Row["xstatus"].ToString() == "Locked")
                        //    {
                        //        //chkCheckBox.InputAttributes.Add("disabled", "disabled");
                        //        dlistxsection.Enabled = false;
                        //        dlistxgroup.Enabled = false;
                        //    }
                        //    else
                        //    {
                        //        //chkCheckBox.InputAttributes.Remove("disabled");
                        //        dlistxsection.Enabled = true;
                        //        dlistxgroup.Enabled = true;
                        //    }
                   



                    //}

                        
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
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

       

       


        private void fnCheckRow()
        {
            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {
                    con.Open();
                    string query =

                    "SELECT * FROM ampromotionh  WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection";


                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());

                    DataTable tempTable = new DataTable();
                    da.Fill(dts, "tempTable");
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        ViewState["xrow"] = tempTable.Rows[0]["xrow"].ToString();
                    }
                    else
                    {
                        ViewState["xrow"] = null;
                    }


                }
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = 0;
                message.InnerHtml = "";

                


                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Class</li>";
                    isValid = false;
                }
                if (xsection.Text == "" || xsection.Text == string.Empty || xsection.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Section</li>";
                    isValid = false;
                }
                if (xterm.Text == "" || xterm.Text == string.Empty || xterm.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Term</li>";
                    isValid = false;
                }
            
                

                

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                //fnCheckRow();
                string xstatus1 = "";
                //if (ViewState["xrow"] != null)
                //{
                //    xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
                //          "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //}
               


                //using (TransactionScope tran = new TransactionScope())
                //{
                    if (GridView1.Rows.Count > 0)
                    {
                        //if (ViewState["xrow"] == null)
                        //{
                            

                        //    message.InnerHtml = "Cann't find any data for save.";
                        //    message.Style.Value = zglobal.warningmsg;
                        //    return;
                        //}



                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;

                            string query = "";
                            string xsession1 = xsession.Text.Trim().ToString();
                            string xclass1 = xclass.Text.Trim().ToString();
                            string xterm1 = xterm.Text.Trim().ToString();
                            string xgroup1 = "";
                            string xsection1 = "";

                            foreach (GridViewRow row in GridView1.Rows)
                            {

                                query = "DELETE FROM amaccclearance WHERE zid=@zid AND xsession=@xsession AND xsrow=@xsrow and xtype=@xtype and xterm=@xterm";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession1);
                                cmd.Parameters.AddWithValue("@xtype", Convert.ToString(ViewState["xtype"]));
                                cmd.Parameters.AddWithValue("@xterm", xterm1);
                                cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                                cmd.ExecuteNonQuery();


                                CheckBox xclearance = row.FindControl("xreportcard") as CheckBox;

                                int xclearance1;
                                if (xclearance.Checked == true)
                                {
                                    xclearance1 = 1;
                                }
                                else
                                {
                                    xclearance1 = 0;
                                }

                                query = "INSERT INTO amaccclearance (ztime,zid,xsession,xsrow,xclearance,zemail,xterm,xtype,xstdid) " +
                                       "VALUES(@ztime,@zid,@xsession,@xsrow,@xclearance,@zemail,@xterm,@xtype,@xstdid) ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession1);
                                cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                                cmd.Parameters.AddWithValue("@xstdid", row.Cells[1].Text.ToString());
                                cmd.Parameters.AddWithValue("@xclearance", xclearance1);
                                cmd.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
                                cmd.Parameters.AddWithValue("@xterm", xterm1);
                                cmd.Parameters.AddWithValue("@xtype", Convert.ToString(ViewState["xtype"]));
                                
                                cmd.ExecuteNonQuery();
                               

                            }
                        }

                        using (SqlConnection conn = new SqlConnection(zglobal.constringstdp))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;

                            string query = "";
                            string xsession1 = xsession.Text.Trim().ToString();
                            string xterm1 = xterm.Text.Trim().ToString();
                            string xclass1 = xclass.Text.Trim().ToString();
                            string xgroup1 = "";
                            string xsection1 = "";

                            foreach (GridViewRow row in GridView1.Rows)
                            {

                                query = "DELETE FROM amaccclearance WHERE zid=@zid AND xsession=@xsession AND xsrow=@xsrow and xtype=@xtype and xterm=@xterm";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession1);
                                cmd.Parameters.AddWithValue("@xtype", Convert.ToString(ViewState["xtype"]));
                                cmd.Parameters.AddWithValue("@xterm", xterm1);
                                cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                                cmd.ExecuteNonQuery();

                                CheckBox xclearance = row.FindControl("xreportcard") as CheckBox;

                                int xclearance1;
                                if (xclearance.Checked == true)
                                {
                                    xclearance1 = 1;
                                }
                                else
                                {
                                    xclearance1 = 0;
                                }

                                query = "INSERT INTO amaccclearance (ztime,zid,xsession,xsrow,xclearance,zemail,xterm,xtype,xstdid) " +
                                        "VALUES(@ztime,@zid,@xsession,@xsrow,@xclearance,@zemail,@xterm,@xtype,@xstdid) ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession1);
                                cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                                cmd.Parameters.AddWithValue("@xstdid", row.Cells[1].Text.ToString());
                                cmd.Parameters.AddWithValue("@xclearance", xclearance1);
                                cmd.Parameters.AddWithValue("@zemail", Convert.ToString(HttpContext.Current.Session["curuser"]));
                                cmd.Parameters.AddWithValue("@xterm", xterm1);
                                cmd.Parameters.AddWithValue("@xtype", Convert.ToString(ViewState["xtype"]));

                                cmd.ExecuteNonQuery();



                            }
                        }
                    }
                    else
                    {
                        message.InnerHtml = "No student found.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }

                //    tran.Complete();

                //}

                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                // btnRefresh_Click(null, null);
                message.InnerHtml = "Successfully uploaded.";
                message.Style.Value = zglobal.successmsg;
                //ViewState["xrow"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";

                //BindGrid();

                fnButtonState();
                //fnFillGrid2();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
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
            ////int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ////using (SqlConnection con = new SqlConnection(zglobal.constring))
            ////{
            ////    using (DataSet dts1 = new DataSet())
            ////    {
            ////        con.Open();
            ////        string query =
            ////             "SELECT Top " + Int32.Parse(_gridrow.Text.Trim().ToString()) + " * " +
            ////             "FROM ampromotionh WHERE zid=@zid AND xstatus='New' order by xrow desc";

            ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



            ////        DataTable tempTable = new DataTable();
            ////        da1.Fill(dts1, "tempTable");
            ////        tempTable = dts1.Tables["tempTable"];

            ////        if (tempTable.Rows.Count > 0)
            ////        {
            ////            // btnShowList.Visible = true;
            ////            //pnllistct.Visible = true;
            ////            dgvPromotedistNew.DataSource = tempTable;
            ////            dgvPromotedistNew.DataBind();
            ////        }
            ////        //else
            ////        //{
            ////        //    // btnShowList.Visible = false;
            ////        //    pnllistct.Visible = false;
            ////        //    GridView2.DataSource = null;
            ////        //    GridView2.DataBind();
            ////        //}


            ////    }
            //}


            //using (SqlConnection con = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts1 = new DataSet())
            //    {
            //        con.Open();
            //        string query =
            //             "SELECT Top " + Int32.Parse(_gridrow1.Text.Trim().ToString()) + " * " +
            //             "FROM ampromotionh WHERE zid=@zid AND xstatus='Approved' order by xrow desc";

            //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);

            //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);



            //        DataTable tempTable = new DataTable();
            //        da1.Fill(dts1, "tempTable");
            //        tempTable = dts1.Tables["tempTable"];

            //        if (tempTable.Rows.Count > 0)
            //        {
            //            // btnShowList.Visible = true;
            //            //pnllistct.Visible = true;
            //            dgvPromotedistSubmitted.DataSource = tempTable;
            //            dgvPromotedistSubmitted.DataBind();
            //        }
            //        //else
            //        //{
            //        //    // btnShowList.Visible = false;
            //        //    pnllistct.Visible = false;
            //        //    GridView2.DataSource = null;
            //        //    GridView2.DataBind();
            //        //}


            //    }
            //}
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
            try
            {
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    ////System.Threading.Thread.Sleep(1000);
                message.InnerHtml = "";
                //GridView1.DataSource = null;
                //GridView1.DataBind();
                ViewState["xrow"] = null;
                divliststd.Visible = false;
                //    //fnGetScheduleDate();
                //    xdate.Text = "";
                //    //xctno.Items.Clear();
                //    //xctno.Items.Add("");
                //    //xcttype.Text = "";
                //    //xctno.Text = "";
                //    xmarks.Text = "";
                //    //xtopic.Value = "";
                //    xdetails.Value = "";
                //    //xcteacher.Text = "-";
                //    xcteacher.Text = "";
                //    //xsteacher.Text = "-";
                //    xsteacher.Text = "";
                //    dxstatus.Text = "-";
                //    fnButtonState();
                //    _classteacher.Value = "";
                //    _subteacher.Value = "";

                //    //fnFillGrid2();

                //    btnRefresh_Click(sender,e);
                //    //zglobal.fnComboBoxValueWithItem(xreference, "(xcttype + '-' + xctno) as xtext,(xcttype + '|' + xctno) as xvalue", "amexamh", "zid=" + _zid + " and xsession='" + xsession.Text + "' and xterm='" + xterm.Text +
                //    //     "' and xclass='" + xclass.Text + "' and xgroup='" + xgroup.Text + "' and xsection='" + xsection.Text + "' and xsubject='" + xsubject.Text + "' and xpaper='" + xpaper.Text + "' and xtype='Class Test' and xcttype in ('Test','Test (WS)') order by xctno");


                //    //fnGetScheduleDate("comval");

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
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

                string str = "SELECT  * FROM ampromotionh where zid=@zid  and xrow=@xrow ";





                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow);
                da.Fill(dts, "tempztcode");
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                ViewState["xrow"] = xrow.ToString();
                hiddenxrow.Value = ViewState["xrow"].ToString();

                xsession.Text = dttemp.Rows[0]["xsession"].ToString();
                xclass.Text = dttemp.Rows[0]["xclass"].ToString();
                xgroup.Text = dttemp.Rows[0]["xgroup"].ToString();
                xsection.Text = dttemp.Rows[0]["xsection"].ToString();
                //xsessionpro.Text = dttemp.Rows[0]["xsessionpro"].ToString();
                //xclasspro.Text = dttemp.Rows[0]["xclasspro"].ToString();
                //xgrouppro.Text = dttemp.Rows[0]["xgrouppro"].ToString();
                

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


                                //query =
                                //    "UPDATE ampromotionh SET xstatus=@xstatus,xapprovedby=@xapprovedby,xapproveddt=@xapproveddt " +
                                //    "WHERE zid=@zid AND xrow=@xrow ";
                                //cmd.Parameters.Clear();

                                //cmd.CommandText = query;
                                //cmd.Parameters.AddWithValue("@zid", _zid);
                                //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //cmd.Parameters.AddWithValue("@xapprovedby", xsubmitedby);
                                //cmd.Parameters.AddWithValue("@xapproveddt", xsubmitdt);
                                //cmd.ExecuteNonQuery();

                                foreach (GridViewRow row in GridView1.Rows)
                                {

                                    

                                    query = "UPDATE ampromotiond SET xstatus2='Approved' " +
                                            "WHERE zid=@zid and xrow=@xrow and xsrow=@xsrow and coalesce(xstatus1,'')='meetvp' and coalesce(xpromoted,0)=1";

                                    cmd.CommandText = query;
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                    cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                                    cmd.ExecuteNonQuery();


                                }

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
                        BindGrid();
                        //fnFillGrid2();
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


                                string query = "DELETE FROM ampromotiond WHERE zid=@zid AND xrow=@xrow";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                cmd.ExecuteNonQuery();

                                query = "DELETE FROM ampromotionh WHERE zid=@zid AND xrow=@xrow";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
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
                        BindGrid();
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
                message.InnerHtml = "";
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //ViewState["dtprectmarks"] = null;

                //fnCheckRow();
                string xstatus1 = "";
                //if (ViewState["xrow"] != null)
                //{
                //    xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
                //          "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //    if (xstatus1 != "Approved" )
                //    {
                //        message.InnerHtml = "Student's not yet promoted. Please contact with class coordinator.";
                //        message.Style.Value = zglobal.warningmsg;
                //        return;
                //    }
                //}
                //else
                //{
                //    message.InnerHtml = "Student's not yet promoted. Please contact with class coordinator.";
                //    message.Style.Value = zglobal.warningmsg;
                //    return;
                //}

                BindGrid();
                
                fnButtonState();



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


        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                int xrow = 0;
                message.InnerHtml = "";




                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                if (xsession.Text == "" || xsession.Text == string.Empty || xsession.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Session</li>";
                    isValid = false;
                }
                if (xclass.Text == "" || xclass.Text == string.Empty || xclass.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Class</li>";
                    isValid = false;
                }
                if (xsection.Text == "" || xsection.Text == string.Empty || xsection.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Section</li>";
                    isValid = false;
                }
                if (xterm.Text == "" || xterm.Text == string.Empty || xterm.Text == "[Select]")
                {
                    rtnMessage = rtnMessage + "<li>Term</li>";
                    isValid = false;
                }





                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                //fnCheckRow();
                string xstatus1 = "";
                //if (ViewState["xrow"] != null)
                //{
                //    xstatus1 = zglobal.fnGetValue("xstatus", "ampromotionh",
                //          "zid=" + _zid + " AND xrow=" + Convert.ToInt32(ViewState["xrow"]));
                //}



                //using (TransactionScope tran = new TransactionScope())
                //{
                if (GridView1.Rows.Count > 0)
                {
                    //if (ViewState["xrow"] == null)
                    //{


                    //    message.InnerHtml = "Cann't find any data for save.";
                    //    message.Style.Value = zglobal.warningmsg;
                    //    return;
                    //}



                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        string query = "";
                        string xsession1 = xsession.Text.Trim().ToString();
                        string xclass1 = xclass.Text.Trim().ToString();
                        string xterm1 = xterm.Text.Trim().ToString();
                        string xgroup1 = "";
                        string xsection1 = "";

                        foreach (GridViewRow row in GridView1.Rows)
                        {

                            //query = "DELETE FROM amaccclearance WHERE zid=@zid AND xsession=@xsession AND xsrow=@xsrow and xtype=@xtype";
                            //cmd.Parameters.Clear();

                            //cmd.CommandText = query;
                            //cmd.Parameters.AddWithValue("@zid", _zid);
                            //cmd.Parameters.AddWithValue("@xsession", xsession1);
                            //cmd.Parameters.AddWithValue("@xtype", Convert.ToString(ViewState["xtype"]));
                            //cmd.Parameters.AddWithValue("@xsrow", Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                            //cmd.ExecuteNonQuery();

                            xstatus1 = zglobal.fnGetValue("coalesce(xemailst,'') as xstdid", "amaccclearance",
                               "zid=" + _zid + " AND xsession='" + xsession1 + "' and xterm='" + xterm1 + "' and xsrow=" + Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()) + " and xtype='Email Admit'");

                            CheckBox xclearance = row.FindControl("xclearance") as CheckBox;

                            int xclearance1;
                            int xemailst1;
                            if (xclearance.Checked == true)
                            {
                                xclearance1 = 1;
                                xemailst1 = 1;
                            }
                            else
                            {
                                xclearance1 = 0;
                                xemailst1 = 0;
                            }

                            if (xstatus1 == "")
                            {
                                if (xemailst1 == 1)
                                {
                                    SendMail(_zid, xsession1, xterm1, row.Cells[1].Text.ToString());
                                }

                                query =
                                    "INSERT INTO amaccclearance (ztime,zid,xsession,xsrow,xclearance,zemail,xterm,xtype,xemailst,xstdid) " +
                                    "VALUES(@ztime,@zid,@xsession,@xsrow,@xclearance,@zemail,@xterm,@xtype,@xemailst,@xstdid) ";

                                cmd.CommandText = query;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession1);
                                cmd.Parameters.AddWithValue("@xsrow",
                                    Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                                 cmd.Parameters.AddWithValue("@xstdid", row.Cells[1].Text.ToString());
                                cmd.Parameters.AddWithValue("@xclearance", xclearance1);
                                cmd.Parameters.AddWithValue("@xemailst", xemailst1);
                                cmd.Parameters.AddWithValue("@zemail",
                                    Convert.ToString(HttpContext.Current.Session["curuser"]));
                                cmd.Parameters.AddWithValue("@xterm", xterm1);
                                cmd.Parameters.AddWithValue("@xtype", "Email Admit");

                                cmd.ExecuteNonQuery();
                            }
                            else
                            {

                                if (xemailst1 == 1)
                                {
                                    if (xstatus1 == "0")
                                    {
                                        SendMail(_zid, xsession1, xterm1, row.Cells[1].Text.ToString());

                                        query =
                                    "UPDATE amaccclearance SET xclearance=@xclearance,xemailst=1 " +
                                    "WHERE zid=@zid AND xsession=@xsession AND xsrow=@xsrow and xtype=@xtype and xterm=@xterm ";

                                        cmd.CommandText = query;
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("@ztime", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@xsession", xsession1);
                                        cmd.Parameters.AddWithValue("@xsrow",
                                            Int64.Parse(row.Cells[row.Cells.Count - 1].Text.ToString()));
                                        cmd.Parameters.AddWithValue("@xclearance", xclearance1);
                                        cmd.Parameters.AddWithValue("@zemail",
                                            Convert.ToString(HttpContext.Current.Session["curuser"]));
                                        cmd.Parameters.AddWithValue("@xterm", xterm1);
                                        cmd.Parameters.AddWithValue("@xtype", "Email Admit");

                                        cmd.ExecuteNonQuery();
                                    }
                                   
                                }

                                
                            }


                        }
                    }

                    
                }
                else
                {
                    message.InnerHtml = "No student found.";
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                //    tran.Complete();

                //}

                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                // btnRefresh_Click(null, null);
                message.InnerHtml = "Successfully send email.";
                message.Style.Value = zglobal.successmsg;
                //ViewState["xrow"] = xrow;
                //ViewState["xstatus"] = "New";
                //hiddenxstatus.Value = "New";

                BindGrid();

                fnButtonState();
                //fnFillGrid2();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void SendMail(int zid1, string xsession1, string xterm1, string xstdid1)
        {
            //string xrowval1 = xrowval.Substring(xrowval.Length - 4);
            string filename = Server.MapPath("~/event.html");
            string mailbody = System.IO.File.ReadAllText(filename);
            //mailbody = mailbody.Replace("##NAME##", xname.Text.ToString().Trim());
            //mailbody = mailbody.Replace("##REFNO##", xrowval1);
            //mailbody = mailbody.Replace("##SESSION##", xsession1);

            //StreamReader reader = new StreamReader(Server.MapPath("~/event.html"));
            //string body = reader.ReadToEnd().Replace("##NAME##", xname.Text.ToString().Trim()).Replace("##REFNO##", xrowval);

            //AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

            //string imageSource = (Server.MapPath("~/images/school_logo.png"));
            //LinkedResource PictureRes = new LinkedResource(imageSource, MediaTypeNames.Image.Jpeg);
            //PictureRes.ContentId = "logo_sml.jpg";
            //altView.LinkedResources.Add(PictureRes);


            //string to = xemail1.Text.ToString().Trim();
            string to = zglobal.fnGetValue("coalesce(xemail1,'Return Mail <no.reply.pisbd@gmail.com>')", "amadmis",
                         "zid=" + zid1 + " AND xstdid='"+xstdid1+"'");

            string from = "Presidency International School <no.reply.pisbd@gmail.com>";
            //string from = "admission@presidency.ac.bd";
            MailMessage message1 = new MailMessage(from, to);
            message1.Subject = "Download Admit Card";
            message1.Body = mailbody;
            //message1.AlternateViews.Add(altView);
            message1.BodyEncoding = Encoding.UTF8;
            message1.IsBodyHtml = true;

            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/reports/amtfcadmitcard1.rpt"));
            crystalReport.SetParameterValue("zid", zid1);
            crystalReport.SetParameterValue("xsession", xsession1);
            crystalReport.SetParameterValue("xterm", xterm1);
            crystalReport.SetParameterValue("xstdid", xstdid1);
            message1.Attachments.Add(new Attachment(crystalReport.ExportToStream(ExportFormatType.PortableDocFormat), "AdmitCard.pdf"));

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            //SmtpClient client = new SmtpClient("74.125.24.108", 587);
            //SmtpClient client = new SmtpClient("smtp.presidency.ac.bd", 587);
            System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("no.reply.pisbd@gmail.com", "pisbdctg");
            //System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("admission@presidency.ac.bd", "Admission$$20&&21");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential;

            crystalReport.Close();
            crystalReport.Dispose();

            try
            {
                client.Send(message1);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }



    }
}