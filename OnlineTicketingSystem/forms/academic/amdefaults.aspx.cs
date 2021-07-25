using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic
{
    public partial class amdefaults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    zglobal.fnComboMonth(stdagemonth);
                    zglobal.fnComboDays(stdageday, 1, 31);
                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Session", xsessiononline);
                    zglobal.fnGetComboDataCD("Session", xsessionacc);
                    zglobal.fnGetComboDataCD("Session", xsessionaccseatconf);
                    zglobal.fnGetComboDataCD("Exam Venue", xexamvenue);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    zglobal.fnGetComboDataCD("VAT Calculation Type", xvatcaltype);
                    zglobal.fnGetComboDataCD("Bank", xbank);
                    stdpassmethod.Items.Add("Single Subject");
                    stdpassmethod.Items.Add("All Subject");
                    stdpassmethod.Text = "Single Subject";

                    xduedaystype.Items.Add("Date");
                    xduedaystype.Items.Add("Month");
                    xduedaystype.Items.Add("Year");
                    xduedaystype.Text = "Date";

                    xadvyesno.Items.Add("Yes");
                    xadvyesno.Items.Add("No");
                    xadvyesno.Text = "Yes";

                    TabContainer1.ActiveTabIndex = 0;
                    FillControls("General");


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

                        string xstdageday = "";
                        string xstdagemonth = "";
                        string xstdpassmethod = "";
                        string xsession1 = "";
                        string xexamvenue1 = "";
                        string xterm1 = "";
                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        int xduedays1 = 0; 
                        string xduedaystype1 = "";
                        string xlatefeeac1 = "";
                        string xvatcaltype1 = "";
                        decimal xvatperc1 = 0;
                        int xiddigit1 = 0;
                        string xidprefix1 = "";
                        int xidstart1 = 0;
                        DateTime xfperiod1 = DateTime.Now;
                        DateTime xtperiod1 = DateTime.Now;
                        string query = "";
                        string xbank1 = "";
                        string xsessiononline1 = "";
                        string xsessionacc1 = "";
                        string xsessionaccseatconf1 = "";
                        string xadvyesno1 = "";

                        if (TabContainer1.ActiveTabIndex == 0)
                        {

                        }
                        else if (TabContainer1.ActiveTabIndex == 1)
                        {
                            xtype = "Student";
                            query = "DELETE FROM amdefaults WHERE zid=@zid and xtype=@xtype";
                            cmd.Parameters.Clear();
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            cmd.Parameters.AddWithValue("@xtype", xtype);
                            cmd.ExecuteNonQuery();

                            query =
                                "INSERT INTO amdefaults (ztime,zid,xrow,xtype,xstdageday,xstdagemonth,xstdpassmethod,zemail,xsession,xexamvenue,xterm " +
                                ",xduedays,xduedaystype,xlatefeeac,xvatcaltype,xvatperc,xiddigit,xidprefix,xidstart,xfperiod,xtperiod,xbank,xsessiononline,xsessionacc,xsessionaccseatconf,xadvyesno) " +
                                "VALUES(@ztime,@zid,@xrow,@xtype,@xstdageday,@xstdagemonth,@xstdpassmethod,@zemail,@xsession,@xexamvenue,@xterm " +
                                ",@xduedays,@xduedaystype,@xlatefeeac,@xvatcaltype,@xvatperc,@xiddigit,@xidprefix,@xidstart,@xfperiod,@xtperiod,@xbank,@xsessiononline,@xsessionacc,@xsessionaccseatconf,@xadvyesno) ";
                            
                            xrow = zglobal.GetMaximumIdInt("xrow", "amdefaults",
                                " zid=" + _zid + " and xtype='" + xtype + "'");
                            xstdageday = stdageday.Text.Trim().ToString();
                            xstdagemonth = stdagemonth.Text.Trim().ToString();
                            xstdpassmethod = stdpassmethod.Text.Trim().ToString();
                            xsession1 = xsession.Text.Trim().ToString();
                            xexamvenue1 = xexamvenue.Text.Trim().ToString();
                            xterm1 = xterm.Text.Trim().ToString();
                            xduedays1 = Convert.ToInt32(xduedays.Text.Trim().ToString());
                            xduedaystype1 = xduedaystype.Text.Trim().ToString();
                            xlatefeeac1 = xlatefeeac.Text.Trim().ToString();
                            xvatcaltype1 = xvatcaltype.Text.Trim().ToString();
                            xvatperc1 = Convert.ToDecimal(xvatperc.Text.Trim().ToString());
                            xiddigit1 = Convert.ToInt32(xiddigit.Text.Trim().ToString());
                            xidprefix1 = xidprefix.Text.Trim().ToString();
                            xidstart1 = Convert.ToInt32(xidstart.Text.Trim().ToString());
                            xfperiod1 = xfperiod.Text.Trim() != string.Empty
                                ? DateTime.ParseExact(xfperiod.Text.Trim().ToString(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xtperiod1 = xtperiod.Text.Trim() != string.Empty
                                ? DateTime.ParseExact(xtperiod.Text.Trim().ToString(), "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture)
                                : DateTime.ParseExact("31/12/2999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            xbank1 = xbank.Text.Trim().ToString();
                            xsessiononline1 = xsessiononline.Text.Trim().ToString();
                            xsessionacc1 = xsessionacc.Text.Trim().ToString();
                            xsessionaccseatconf1 = xsessionaccseatconf.Text.Trim().ToString();
                            xadvyesno1 = xadvyesno.Text.Trim().ToString();
                        }
                        else if (TabContainer1.ActiveTabIndex == 2)
                        {

                        }

                        cmd.Parameters.Clear();
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xtype", xtype);
                        cmd.Parameters.AddWithValue("@xrow", xrow);
                        cmd.Parameters.AddWithValue("@xstdageday", xstdageday);
                        cmd.Parameters.AddWithValue("@xstdagemonth", xstdagemonth);
                        cmd.Parameters.AddWithValue("@xstdpassmethod", xstdpassmethod);
                        cmd.Parameters.AddWithValue("@zemail", zemail);
                        cmd.Parameters.AddWithValue("@xsession", xsession1);
                        cmd.Parameters.AddWithValue("@xexamvenue", xexamvenue1);
                        cmd.Parameters.AddWithValue("@xterm", xterm1);
                        cmd.Parameters.AddWithValue("@xduedays", xduedays1);
                        cmd.Parameters.AddWithValue("@xduedaystype", xduedaystype1);
                        cmd.Parameters.AddWithValue("@xlatefeeac", xlatefeeac1);
                        cmd.Parameters.AddWithValue("@xvatcaltype", xvatcaltype1);
                        cmd.Parameters.AddWithValue("@xvatperc", xvatperc1);
                        cmd.Parameters.AddWithValue("@xiddigit", xiddigit1);
                        cmd.Parameters.AddWithValue("@xidprefix", xidprefix1);
                        cmd.Parameters.AddWithValue("@xidstart", xidstart1);
                        cmd.Parameters.AddWithValue("@xfperiod", xfperiod1);
                        cmd.Parameters.AddWithValue("@xtperiod", xtperiod1);
                        cmd.Parameters.AddWithValue("@xbank", xbank1);
                        cmd.Parameters.AddWithValue("@xsessiononline", xsessiononline1);
                        cmd.Parameters.AddWithValue("@xsessionacc", xsessionacc1);
                        cmd.Parameters.AddWithValue("@xsessionaccseatconf", xsessionaccseatconf1);
                        cmd.Parameters.AddWithValue("@xadvyesno", xadvyesno1);
                        cmd.ExecuteNonQuery();

                        //Insert into zreclog
                        //zglobal.fnRecordLog(xrow.ToString(), "Save", "eventinfo", xtype, "", 0, xdate);

                    }

                    //fnFillDataGrid();
                    //zemail.InnerHtml = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();
                }
                //btnSave.Enabled = false;
                message.InnerHtml = zglobal.insertsuccmsg;
                message.Style.Value = zglobal.successmsg;
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

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
               
                if (TabContainer1.ActiveTabIndex == 0)
                {
                    
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                   FillControls("Student");
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    
                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        protected void FillControls(string xtype)
        {
            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
               
                string str = "SELECT * FROM amdefaults WHERE zid=@zid AND xtype=@xtype";

                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xtype", xtype);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                if (TabContainer1.ActiveTabIndex == 0)
                {
                    
                }
                else if (TabContainer1.ActiveTabIndex == 1)
                {
                    stdageday.Text = dtztcode.Rows[0]["xstdageday"].ToString();
                    stdagemonth.Text = dtztcode.Rows[0]["xstdagemonth"].ToString();
                    stdpassmethod.Text = dtztcode.Rows[0]["xstdpassmethod"].ToString();
                    xsession.Text = dtztcode.Rows[0]["xsession"].ToString();
                    xexamvenue.Text = dtztcode.Rows[0]["xexamvenue"].ToString();
                    xterm.Text = dtztcode.Rows[0]["xterm"].ToString();
                    xduedays.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xduedays"]) ? dtztcode.Rows[0]["xduedays"].ToString() : "";
                    xduedaystype.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xduedaystype"]) ? dtztcode.Rows[0]["xduedaystype"].ToString() : "Date";
                    xlatefeeac.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xlatefeeac"]) ? dtztcode.Rows[0]["xlatefeeac"].ToString() : "";
                    xlatefeeactitle.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xlatefeeac"]) ? zglobal.fnGetValue("xdescdet", "mscodesam", "zid="+ _zid +" and xtype='TFC Code' and xcode=" + dtztcode.Rows[0]["xlatefeeac"].ToString()) : "";
                    xvatcaltype.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xvatcaltype"]) ? dtztcode.Rows[0]["xvatcaltype"].ToString() : "";
                    xvatperc.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xvatperc"]) ? dtztcode.Rows[0]["xvatperc"].ToString() : "";
                    xiddigit.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xiddigit"]) ? dtztcode.Rows[0]["xiddigit"].ToString() : "";
                    xidprefix.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xidprefix"]) ? dtztcode.Rows[0]["xidprefix"].ToString() : "";
                    xidstart.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xidstart"]) ? dtztcode.Rows[0]["xidstart"].ToString() : "";
                    xfperiod.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xfperiod"]) ? Convert.ToDateTime(dtztcode.Rows[0]["xfperiod"]).ToString("dd/MM/yyyy") : "";
                    xtperiod.Text = !Convert.IsDBNull(dtztcode.Rows[0]["xtperiod"]) ? Convert.ToDateTime(dtztcode.Rows[0]["xtperiod"]).ToString("dd/MM/yyyy") : "";
                    xbank.Text = dtztcode.Rows[0]["xbank"].ToString();
                    xsessiononline.Text = dtztcode.Rows[0]["xsessiononline"].ToString();
                    xsessionacc.Text = dtztcode.Rows[0]["xsessionacc"].ToString();
                    xsessionaccseatconf.Text = dtztcode.Rows[0]["xsessionaccseatconf"].ToString();
                    xadvyesno.Text = dtztcode.Rows[0]["xadvyesno"].ToString();
                }
                else if (TabContainer1.ActiveTabIndex == 2)
                {
                    
                }
                
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
    }
}