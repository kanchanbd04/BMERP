using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem.forms.academic.admission
{
    public partial class msdef_gl : System.Web.UI.Page
    {

        public string xtypestatus1 = "";
        public string zid1 = "";
        public string xaction1 = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //xtypestatus1 = Request.QueryString["xtypestatus"];
                //xaction1 = Request.QueryString["xaction"];
                //xtype2.Value = xtypestatus1;
                header_label.InnerHtml = "Accounts Default Setup";
                xtypestatus.InnerHtml = "GL Period Offset";
                xtypestatus1 = "GL Period Offset";
                if (!IsPostBack)
                {

                    //TabContainer1.ActiveTabIndex = 0;
                    //fnGridVisibleProp("_grid_day_o");
                    //_gridrow.Text = zglobal._grid_row_value;
                    //fnFillDataGrid();
                    //zactive.Checked = true;
                    //zemail.InnerHtml = "";
                    //xemail.InnerHtml = "";

                    //zglobal.fnGetComboDataCDWithValue(xaction1, xaction);

                    //xaction.Items.Add(new ListItem("", ""));
                    //xaction.Items.Add(new ListItem("Issue", "Issue"));
                    //xaction.Items.Add(new ListItem("Receipt", "Receipt"));
                    //xaction.SelectedValue = "";

                    //xnum.Text = "0";
                    //xinc.Text = "1";
                    //xinteger.Text = "0";

                    //fnGetOffset();
                    xsubcpv.Text = "";
                    xsubcpvtitle.Text = "";
                    hxacccpv.Value = "";
                    hxsubcpv.Value = "";

                    xsubcrv.Text = "";
                    xsubcrvtitle.Text = "";
                    hxacccrv.Value = "";
                    hxsubcrv.Value = "";

                    xsubbpv.Text = "";
                    xsubbpvtitle.Text = "";
                    hxaccbpv.Value = "";
                    hxsubbpv.Value = "";

                    xsubbrv.Text = "";
                    xsubbrvtitle.Text = "";
                    hxaccbrv.Value = "";
                    hxsubbrv.Value = "";


                    xsubbb.Text = "";
                    xsubbbtitle.Text = "";

                    xsubcb.Text = "";
                    xsubcbtitle.Text = "";

                    fnGetInfo();
                }

                xsubcpvtitle.Text = zglobal.fnGetValue("xdesc1", "glmstvw1",
                     "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + hxacccpv.Value.ToString() + "' " +
                     "and xsub='" + hxsubcpv.Value.ToString() + "'");

                xsubcrvtitle.Text = zglobal.fnGetValue("xdesc1", "glmstvw1",
                    "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + hxacccrv.Value.ToString() + "' " +
                    "and xsub='" + hxsubcrv.Value.ToString() + "'");

                xsubbrvtitle.Text = zglobal.fnGetValue("xdesc1", "glmstvw1",
                  "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + hxaccbrv.Value.ToString() + "' " +
                  "and xsub='" + hxsubbrv.Value.ToString() + "'");

                xsubbpvtitle.Text = zglobal.fnGetValue("xdesc1", "glmstvw1",
                 "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + hxaccbpv.Value.ToString() + "' " +
                 "and xsub='" + hxsubbpv.Value.ToString() + "'");

                xsubbbtitle.Text = zglobal.fnGetValue("xdesc", "glmst",
                 "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xsubbb.Text.ToString().Trim() + "' " );

                xsubcbtitle.Text = zglobal.fnGetValue("xdesc", "glmst",
                 "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xsubcb.Text.ToString().Trim() + "' ");

                xaccyearendtitle.Text = zglobal.fnGetValue("xdesc", "glmst",
                 "zid=" + Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"])) + " and xacc='" + xaccyearend.Text.ToString().Trim() + "' ");

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        //private void fnGetOffset()
        //{
          


        //    SqlConnection conn1;
        //    conn1 = new SqlConnection(zglobal.constring);
        //    DataSet dts = new DataSet();

        //    dts.Reset();

        //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
        //    string str = "SELECT coalesce(xinteger,0) as xinteger FROM msstatus WHERE xtypestatus=@xtypestatus and zid=@zid";
        //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

        //    da.SelectCommand.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
        //    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
        //    da.Fill(dts, "tempztcode");
        //    DataTable dtztcode = new DataTable();
        //    dtztcode = dts.Tables[0];

        //    if (dtztcode.Rows.Count > 0)
        //    {
        //        xinteger.Text = dtztcode.Rows[0]["xinteger"].ToString();
        //    }
        //    else
        //    {
        //        xinteger.Text = "0";
        //    }




        //    dts.Dispose();
        //    dtztcode.Dispose();
        //    da.Dispose();
        //    conn1.Dispose();

           
        //}

        private void fnGetInfo()
        {



            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            string str = "SELECT coalesce(xacccpv,'') as xacccpv,coalesce(xsubcpv,'') as xsubcpv, " +
                         "coalesce(xacccrv,'') as xacccrv,coalesce(xsubcrv,'') as xsubcrv, " +
                         "coalesce(xaccbpv,'') as xaccbpv,coalesce(xsubbpv,'') as xsubbpv, " +
                         "coalesce(xaccbrv,'') as xaccbrv,coalesce(xsubbrv,'') as xsubbrv,coalesce(xaccyearend,'') as xaccyearend, " +
                         "coalesce(xaccbb,'') as xaccbb,coalesce(xacccb,'') as xacccb,coalesce(xacccb,'') as xacccb, " +
                         "(select xdesc1 from glmstvw1 where zid=msdef.zid and xacc=msdef.xacccpv and xsub=msdef.xsubcpv) as xdesccpv, " +
                         "(select xdesc1 from glmstvw1 where zid=msdef.zid and xacc=msdef.xacccrv and xsub=msdef.xsubcrv) as xdesccrv, " +
                         "(select xdesc1 from glmstvw1 where zid=msdef.zid and xacc=msdef.xaccbrv and xsub=msdef.xsubbrv) as xdescbrv, " +
                         "(select xdesc1 from glmstvw1 where zid=msdef.zid and xacc=msdef.xaccbpv and xsub=msdef.xsubbpv) as xdescbpv, " +
                         "(select xdesc from glmst where zid=msdef.zid and xacc=msdef.xaccbb) as xdescbb, " +
                         "(select xdesc from glmst where zid=msdef.zid and xacc=msdef.xacccb) as xdesccb, " +
                         "(select xdesc from glmst where zid=msdef.zid and xacc=msdef.xaccyearend) as xaccyearendtt " +
                         "FROM msdef WHERE  zid=@zid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            //da.SelectCommand.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.Fill(dts, "tempztcode");
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                xsubcpv.Text = dtztcode.Rows[0]["xsubcpv"].ToString();
                xsubcpvtitle.Text = dtztcode.Rows[0]["xdesccpv"].ToString();
                hxacccpv.Value = dtztcode.Rows[0]["xacccpv"].ToString();
                hxsubcpv.Value = dtztcode.Rows[0]["xsubcpv"].ToString();

                xsubcrv.Text = dtztcode.Rows[0]["xsubcrv"].ToString();
                xsubcrvtitle.Text = dtztcode.Rows[0]["xdesccrv"].ToString();
                hxacccrv.Value = dtztcode.Rows[0]["xacccrv"].ToString();
                hxsubcrv.Value = dtztcode.Rows[0]["xsubcrv"].ToString();

                xsubbpv.Text = dtztcode.Rows[0]["xsubbpv"].ToString();
                xsubbpvtitle.Text = dtztcode.Rows[0]["xdescbpv"].ToString();
                hxaccbpv.Value = dtztcode.Rows[0]["xaccbpv"].ToString();
                hxsubbpv.Value = dtztcode.Rows[0]["xsubbpv"].ToString();

                xsubbrv.Text = dtztcode.Rows[0]["xsubbrv"].ToString();
                xsubbrvtitle.Text = dtztcode.Rows[0]["xdescbrv"].ToString();
                hxaccbrv.Value = dtztcode.Rows[0]["xaccbrv"].ToString();
                hxsubbrv.Value = dtztcode.Rows[0]["xsubbrv"].ToString();

                xsubbb.Text = dtztcode.Rows[0]["xaccbb"].ToString();
                xsubbbtitle.Text = dtztcode.Rows[0]["xdescbb"].ToString();

                xsubcb.Text = dtztcode.Rows[0]["xacccb"].ToString();
                xsubcbtitle.Text = dtztcode.Rows[0]["xdesccb"].ToString();

                xaccyearend.Text = dtztcode.Rows[0]["xaccyearend"].ToString();
                xaccyearendtitle.Text = dtztcode.Rows[0]["xaccyearendtt"].ToString();

            }
            else
            {
                xsubcpv.Text = "";
                xsubcpvtitle.Text = "";
                hxacccpv.Value = "";
                hxsubcpv.Value = "";

                xsubcrv.Text = "";
                xsubcrvtitle.Text = "";
                hxacccrv.Value = "";
                hxsubcrv.Value = "";

                xsubbpv.Text = "";
                xsubbpvtitle.Text = "";
                hxaccbpv.Value = "";
                hxsubbpv.Value = "";

                xsubbrv.Text = "";
                xsubbrvtitle.Text = "";
                hxaccbrv.Value = "";
                hxsubbrv.Value = "";

                xsubbb.Text = "";
                xsubbbtitle.Text = "";

                xsubcb.Text = "";
                xsubcbtitle.Text = "";

                xaccyearend.Text = "";
                xaccyearendtitle.Text = "";
            }




            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();


        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerHtml = "";
                
                xtypestatus.InnerHtml = xtypestatus1;

                fnGetInfo();

                //fnGetOffset();
                //key.Value = "";

                //_searchbox.Text = "";

                //fnFillDataGrid();
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
                string xkey = "";

                bool isValid = true;
                string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
                //if (xinteger.Text == "" || xinteger.Text == string.Empty || xinteger.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Period Offset</li>";
                //    isValid = false;
                //}
                //if (xaction.Text == "" || xaction.Text == string.Empty || xaction.Text == "[Select]")
                //{
                //    rtnMessage = rtnMessage + "<li>Action Code</li>";
                //    isValid = false;
                //}

                rtnMessage = rtnMessage + "</ol></div>";
                if (!isValid)
                {
                    message.InnerHtml = rtnMessage;
                    message.Style.Value = zglobal.warningmsg;
                    return;
                }

                if (xsubcpv.Text.Trim().ToString() == String.Empty)
                {
                    hxacccpv.Value = "";
                    hxsubcpv.Value = "";
                }

                if (xsubcrv.Text.Trim().ToString() == String.Empty)
                {
                    hxacccrv.Value = "";
                    hxsubcrv.Value = "";
                }

                if (xsubbpv.Text.Trim().ToString() == String.Empty)
                {
                    hxaccbpv.Value = "";
                    hxsubbpv.Value = "";
                }

                if (xsubbrv.Text.Trim().ToString() == String.Empty)
                {
                    hxaccbrv.Value = "";
                    hxsubbrv.Value = "";
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";

                        DateTime ztime = DateTime.Now;
                        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                        //int xinteger1 = Convert.ToInt32(xinteger.Text.Trim().ToString());

                        //query = "DELETE FROM msstatus WHERE xtypestatus=@xtypestatus and zid=@zid";

                        //cmd.CommandText = query;
                        //cmd.Parameters.Clear();
                        //cmd.Parameters.AddWithValue("@zid", _zid);
                        //cmd.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
                        //cmd.ExecuteNonQuery();

                        //query = "INSERT INTO msstatus (ztime,zid,xtypestatus,xinteger,xdate) " +
                        //               "VALUES(@ztime,@zid,@xtypestatus,@xinteger,@xdate) ";

                        query = "UPDATE msdef SET xacccpv=@xacccpv,xsubcpv=@xsubcpv, xacccrv=@xacccrv,xsubcrv=@xsubcrv, " +
                                "xaccbpv=@xaccbpv,xsubbpv=@xsubbpv, xaccbrv=@xaccbrv,xsubbrv=@xsubbrv,xaccbb=@xaccbb,xacccb=@xacccb,xaccyearend=@xaccyearend " +
                                "WHERE zid=@zid ";
                        
                        cmd.CommandText = query;
                        cmd.Parameters.Clear();
                        //cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xacccpv", hxacccpv.Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xsubcpv", hxsubcpv.Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xacccrv", hxacccrv.Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xsubcrv", hxsubcrv.Value.ToString().Trim());

                        cmd.Parameters.AddWithValue("@xaccbpv", hxaccbpv.Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xsubbpv", hxsubbpv.Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xaccbrv", hxaccbrv.Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xsubbrv", hxsubbrv.Value.ToString().Trim());

                        cmd.Parameters.AddWithValue("@xaccbb", xsubbb.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xacccb", xsubcb.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xaccyearend", xaccyearend.Text.ToString().Trim());
                        cmd.ExecuteNonQuery();

                    }

                   
                    tran.Complete();

                  
                }
                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;
                //key.Value = xkey;
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    bool isValid = true;
            //    string rtnMessage = "<div style=\"text-align:left;\">Must Fill All Mendatory Field(s) :- <ol>";
            //    if (xinteger.Text == "" || xinteger.Text == string.Empty || xinteger.Text == "[Select]")
            //    {
            //        rtnMessage = rtnMessage + "<li>Period Offset</li>";
            //        isValid = false;
            //    }
            //    //if (xaction.Text == "" || xaction.Text == string.Empty || xaction.Text == "[Select]")
            //    //{
            //    //    rtnMessage = rtnMessage + "<li>Action Code</li>";
            //    //    isValid = false;
            //    //}

            //    rtnMessage = rtnMessage + "</ol></div>";
            //    if (!isValid)
            //    {
            //        message.InnerHtml = rtnMessage;
            //        message.Style.Value = zglobal.warningmsg;
            //        return;
            //    }


            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //        {
            //            conn.Open();
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = conn;
            //            string query = "UPDATE msstatus SET zutime=@zutime,xinteger=@xinteger,xdate=@xdate " +
            //                               "WHERE xtypestatus=@xtypestatus and zid=@zid ";
            //            DateTime ztime = DateTime.Now;
            //            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //            int xinteger1 = Convert.ToInt32(xinteger.Text.Trim().ToString());

            //            cmd.CommandText = query;
            //            cmd.Parameters.AddWithValue("@zutime", ztime);
            //            cmd.Parameters.AddWithValue("@zid", _zid);
            //            cmd.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            //            cmd.Parameters.AddWithValue("@xinteger", xinteger1);
            //            cmd.Parameters.AddWithValue("@xdate", ztime);
            //            cmd.ExecuteNonQuery();

            //        }

                   
            //        tran.Complete();
                    

            //    }
            //    message.InnerHtml = zglobal.updatesuccmsg;
            //    message.Style.Value = zglobal.successmsg;
            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        protected void FillControls(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    DataSet dts = new DataSet();

            //    dts.Reset();

            //    string xcode1 = ((LinkButton)sender).Text;
            //    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //    string str = "SELECT * FROM mstrn WHERE xtypestatus=@xtypestatus and xtrn=@xtrn and zid=@zid";
            //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            //    da.SelectCommand.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            //    da.SelectCommand.Parameters.AddWithValue("@xtrn", ((LinkButton)sender).Text);
            //    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            //    da.Fill(dts, "tempztcode");
            //    DataTable dtztcode = new DataTable();
            //    dtztcode = dts.Tables[0];

            //    xtypestatus.InnerHtml = dtztcode.Rows[0]["xtypestatus"].ToString();
            //    xtrn.Text = dtztcode.Rows[0]["xtrn"].ToString();
            //    xaction.SelectedValue = dtztcode.Rows[0]["xaction"].ToString();
            //    xdesc.Text = dtztcode.Rows[0]["xdesc"].ToString();
            //    xnum.Text = dtztcode.Rows[0]["xnum"].ToString();
            //    xinc.Text = dtztcode.Rows[0]["xinc"].ToString();
            //    zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
            //    zemail.InnerHtml = dtztcode.Rows[0]["zemail"].ToString();
            //    xemail.InnerHtml = dtztcode.Rows[0]["xemail"].ToString();


            //    dts.Dispose();
            //    dtztcode.Dispose();
            //    da.Dispose();
            //    conn1.Dispose();
            //    key.Value = ((LinkButton)sender).Text;
            //    message.InnerHtml = "";

            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}
        }


        public void fnFillDataGrid()
        {

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();

            ////int _row = Convert.ToInt32(_gridrow.Text);
            //dts.Reset();
            ////string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtypestatus,xtrn,(select xdescdet from mscodesam where zid=mstrn.zid and xtype=@xtype and xcode=mstrn.xaction) as xaction,xdesc,xnum,xinc,zactive FROM mstrn where xtypestatus=@xtypestatus and zid=@zid ORDER BY ztime"; //ORDER BY xtype,xcode
            //string str = "SELECT TOP " + _gridrow.Text.Trim().ToString() + " xtypestatus,xtrn,xaction,xdesc,xnum,xinc,zactive FROM mstrn where xtypestatus=@xtypestatus and zid=@zid ORDER BY ztime"; //ORDER BY xtype,xcode
            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            ////da.SelectCommand.Parameters.AddWithValue("@row", _row);
            //da.SelectCommand.Parameters.AddWithValue("@xtypestatus", xtypestatus1);
            //da.SelectCommand.Parameters.AddWithValue("@xtype", xaction1);
            ////da.SelectCommand.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
            //da.Fill(dts, "tempztcode");
            ////DataView dv = new DataView(dts.Tables[0]);
            //DataTable dtztcode = new DataTable();
            //dtztcode = dts.Tables[0];
            //_grid_codes.DataSource = dtztcode;
            //_grid_codes.DataBind();





            //dts.Dispose();
            //dtztcode.Dispose();
            //da.Dispose();
            //conn1.Dispose();
        }


        protected void fnFilterByRow(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn1;
                //conn1 = new SqlConnection(zglobal.constring);
                //DataSet dts = new DataSet();

                //int _row = Convert.ToInt32(_gridrow.Text);
                //dts.Reset();
                //string str = "SELECT TOP @row xtype,xcode,xdescdet,xprops,xcodealt,zactive FROM mscodesam where xtype=@xtype and zid=@zid ORDER BY xtype,xcode";
                //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //da.SelectCommand.Parameters.AddWithValue("@row", _row);
                //da.SelectCommand.Parameters.AddWithValue("@xtype", xtype1);
                ////da.SelectCommand.Parameters.AddWithValue("@xcode", xcode.Text.ToString().Trim());
                //da.Fill(dts, "tempztcode");
                ////DataView dv = new DataView(dts.Tables[0]);
                //DataTable dtztcode = new DataTable();
                //dtztcode = dts.Tables[0];
                //_grid_codes.DataSource = dtztcode;
                //_grid_codes.DataBind();





                //dts.Dispose();
                //dtztcode.Dispose();
                //da.Dispose();
                //conn1.Dispose();
                fnFillDataGrid();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


    }
}