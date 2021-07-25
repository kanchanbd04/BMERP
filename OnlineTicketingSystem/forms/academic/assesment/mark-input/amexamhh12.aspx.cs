﻿using System;
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
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using AjaxControlToolkit.Design;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class amexamhh12 : System.Web.UI.Page
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
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                message.InnerHtml = "";
                result.Visible = false;
                barchart.Visible = false;
                if (ViewState["msg"].ToString() != "1")
                {
                    //btnApprove.Visible = true;
                    //btnSave.Visible = true;

                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts1 = new DataSet())
                        {
                            //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                            //string query =
                            //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                            //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                            string query =
                           "select count(*) from amexamhh where zid=@zid and xsession=@xsession and xterm=@xterm and xclass=@xclass  and xgroup=@xgroup and xstatus='Approved3'  ";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                            //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                            da1.Fill(dts1, "tempztcode");
                            DataTable dtamexamd = new DataTable();
                            dtamexamd = dts1.Tables[0];

                            //xnostd.Text = dtamexamd.Rows[0][0].ToString();
                            //ts = Convert.ToInt32(dtamexamd.Rows[0][0].ToString());

                            //ViewState["amstudentvw1"] = dtamexamd;

                            if (dtamexamd.Rows[0][0].ToString() == "0")
                            {
                                message.InnerHtml = "CT best result not yet approved.";
                                message.Style.Value = zglobal.am_warningmsg;
                                btnApprove.Visible = false;
                                btnSave.Visible = false;
                                GridView1.DataSource = null;
                                GridView1.DataBind();
                                return;
                            }

                        }
                    }


                }

                btnApprove.Visible = false;
                btnSave.Visible = false;

               


                



                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                       "select count(xstdid) from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession  ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        //xnostd.Text = dtamexamd.Rows[0][0].ToString();
                        //ts = Convert.ToInt32(dtamexamd.Rows[0][0].ToString());

                        ViewState["amstudentvw1"] = dtamexamd;

                    }
                }

                //////////////////////////////////////////////

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                       "select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["amstd1"] = dtamexamd;
                        }
                        else
                        {
                            ViewState["amstd1"] = null;
                        }

                    }
                }

//                using (SqlConnection con = new SqlConnection(zglobal.constring))
//                {
//                    using (DataSet dts1 = new DataSet())
//                    {
//                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
//                        //string query =
//                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
//                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

//                       // string query =
//                       //"select xstdid,xsubject,xpaper from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
//                       //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
//                       //"and  xgetmark<>-1 and  coalesce(xna,0) <> 1";

//                       // string query =
//                       //"select xstdid,xsubject,xpaper from amexamvw where zid=@zid AND xtype='Class Test'  " +
//                       //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
//                       //"and  xgetmark<>-1 and  coalesce(xna,0) <> 1";

//                        string query =
//                        "select xstdid,xsubject,xpaper,count(xstdid) as xnumexam from amexamvw where zid=@zid AND xtype='Class Test'  " +
//                       "and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
//                       "and  (coalesce(xgetmark,-1)=-1 or (coalesce(xgetmark,-1)<>-1 and coalesce(xna,0) = 1)) and xcttype in ('Test','Test (WS)') " +
//                       "group by zid,xtype,xsession,xterm,xclass,xgroup,xsubject,xpaper,xstdid";

                    

////                        string query =
////                            @"select xstdid,xsubject,xpaper,count(xstdid) as xnumexam from amexamvw where zid=@zid AND xtype='Class Test' 
////and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup  
////and    case when coalesce((select top 1 coalesce(xgetmark,0) as xgetmark from amexamvw as a where zid=amexamvw.zid and xtype='Class Test' and xsession=amexamvw.xsession
////and xterm=amexamvw.xterm and xclass=amexamvw.xclass and xgroup=amexamvw.xgroup and xcttype='Missed Test' and xsubject=amexamvw.xsubject and xpaper=amexamvw.xpaper and 
////xext=amexamvw.xext and xrefcttype=amexamvw.xcttype and xrefctno=amexamvw.xctno and xstdid=amexamvw.xstdid ), 0) = 0 then coalesce(xgetmark,0) else  coalesce((select top 1 coalesce(xgetmark,0) as xgetmark from amexamvw as a where zid=amexamvw.zid and xtype='Class Test' and xsession=amexamvw.xsession
////and xterm=amexamvw.xterm and xclass=amexamvw.xclass and xgroup=amexamvw.xgroup and xcttype='Missed Test' and xsubject=amexamvw.xsubject and xpaper=amexamvw.xpaper and 
////xext=amexamvw.xext and xrefcttype=amexamvw.xcttype and xrefctno=amexamvw.xctno and xstdid=amexamvw.xstdid ), 0) end  < 0 and xcttype in ('Test','Test (WS)')
////group by zid,xtype,xsession,xterm,xclass,xgroup,xsubject,xpaper,xstdid";

//                    //    string query =
//                    // "select xstdid,xsubject,xpaper,count(xstdid) as xnumexam," +
//                    // "sum(case when  coalesce(xgetmark,-1)=-1 or (coalesce(xgetmark,-1)<>-1 and coalesce(xna,0) = 1) then 1 else 0 end) as xabsent  " +
//                    // " from amexamvw where zid=@zid AND xtype='Class Test'  " +
//                    //"and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
//                    //"and xcttype in ('Test','Test (WS)') " +
//                    //"group by zid,xtype,xsession,xterm,xclass,xgroup,xsubject,xpaper,xstdid";

//                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
//                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
//                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
//                        ////da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
//                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
//                        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
//                        //da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);

//                        da1.Fill(dts1, "tempztcode");
//                        DataTable dtamexamd = new DataTable();
//                        dtamexamd = dts1.Tables[0];

//                        if (dtamexamd.Rows.Count > 0)
//                        {
//                            ViewState["amstd2"] = dtamexamd;
//                        }
//                        else
//                        {
//                            ViewState["amstd2"] = null;
//                        }

//                    }
//                }


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        // string query =
                        //"select xstdid,xsubject,xpaper from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                        //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
                        //"and  xgetmark<>-1 and  coalesce(xna,0) <> 1";

                       // string query =
                       //"select xstdid,xsubject,xpaper,count(xstdid) as xnumexam from amexamvw where zid=@zid AND xtype='Class Test'  " +
                       //"and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
                       //"and  coalesce(xna,0) = 1 and xcttype in ('Test','Test (WS)') " +
                       //"group by zid,xtype,xsession,xterm,xclass,xgroup,xsubject,xpaper,xstdid";

                   string query =
                   "select amexamvw.xstdid,xsubject,xpaper,count(amexamvw.xstdid) as xnumexam, sum(coalesce(xna,0)) as xna from amexamvw " +
                   "left join amdropout on  amdropout.zid=amexamvw.zid and amdropout.xsession=amexamvw.xsession and amdropout.xsrow=amexamvw.xsrow " +
                   "where amexamvw.zid=@zid AND amexamvw.xtype='Class Test'  " +
                   "and amexamvw.xsession=@xsession and amexamvw.xterm=@xterm and amexamvw.xclass=@xclass and amexamvw.xgroup=@xgroup   " +
                   "and xcttype in ('Test','Test (WS)') and amdropout.xstdid is null " +
                   "group by amexamvw.zid,amexamvw.xtype,amexamvw.xsession,amexamvw.xterm,amexamvw.xclass,amexamvw.xgroup,xsubject,xpaper,amexamvw.xstdid";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        ////da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["amstd3"] = dtamexamd;
                        }
                        else
                        {
                            ViewState["amstd3"] = null;
                        }

                    }
                }


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        // string query =
                        //"select xstdid,xsubject,xpaper from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                        //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
                        //"and  xgetmark<>-1 and  coalesce(xna,0) <> 1";

                        // string query =
                        //"select xstdid,xsubject,xpaper,count(xstdid) as xnumexam from amexamvw where zid=@zid AND xtype='Class Test'  " +
                        //"and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup   " +
                        //"and  coalesce(xna,0) = 1 and xcttype in ('Test','Test (WS)') " +
                        //"group by zid,xtype,xsession,xterm,xclass,xgroup,xsubject,xpaper,xstdid";

                   //     string query =
                   //"select amexamvw.xstdid,xsubject,xpaper,count(amexamvw.xstdid) as xnumexam, sum(coalesce(xna,0)) as xna from amexamvw " +
                   //"left join amdropout on  amdropout.zid=amexamvw.zid and amdropout.xsession=amexamvw.xsession and amdropout.xsrow=amexamvw.xsrow " +
                   //"where amexamvw.zid=@zid AND amexamvw.xtype='Class Test'  " +
                   //"and amexamvw.xsession=@xsession and amexamvw.xterm=@xterm and amexamvw.xclass=@xclass and amexamvw.xgroup=@xgroup   " +
                   //"and xcttype in ('Test','Test (WS)') and amdropout.xstdid is null " +
                   //"group by amexamvw.zid,amexamvw.xtype,amexamvw.xsession,amexamvw.xterm,amexamvw.xclass,amexamvw.xgroup,xsubject,xpaper,amexamvw.xstdid";

                        string query =
                            @"select xsubject,xpaper,amstudentvw.xstdid from amstudentvw left join amexamvw 
                            on amstudentvw.zid=amexamvw.zid and amstudentvw.xsession=amexamvw.xsession and amstudentvw.xstdid=amexamvw.xstdid
                            where amstudentvw.zid=@zid AND amexamvw.xtype='Class Test'
                            and amstudentvw.xsession=@xsession and amexamvw.xterm=@xterm and amstudentvw.xclass=@xclass and amstudentvw.xgroup=@xgroup 
                            and xcttype in ('Test','Test (WS)') and amexamvw.xstdid is null 
                            group by amstudentvw.zid,amexamvw.xtype,amstudentvw.xsession,amexamvw.xterm,amstudentvw.xclass,amstudentvw.xgroup,
                            xsubject,xpaper,amstudentvw.xstdid";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        ////da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["amstd4"] = dtamexamd;
                        }
                        else
                        {
                            ViewState["amstd4"] = null;
                        }

                    }
                }

                /////////////////////////////


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                       "select xsection,xsubject,xpaper from amexamh " +
                       "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and " +
                       "xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                       "group by xsection,xsubject,xpaper";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamh = new DataTable();
                        dtamexamh = dts1.Tables[0];

                        if (dtamexamh.Rows.Count > 0)
                        {
                            ViewState["amexamh10"] = dtamexamh;
                        }
                        else
                        {
                            ViewState["amexamh10"] = null;
                        }

                    }
                }

                ////////////////////////////////////

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts1 = new DataSet())
                //    {
                //       string query = "select * from amexamhh where zid=@zid and xsession=@xsession and xterm=@xterm and " +
                //                                                "xclass=@xclass and xgroup=@xgroup and xtype='Class Test' and xstatus in ('New','Approved3')";

                //        SqlDataAdapter da11 = new SqlDataAdapter(query, con);
                //        da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                //        //da11.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                //        //da11.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                //        //da11.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                //        dts1.Reset();
                //        da11.Fill(dts1, "tempztcode");
                //        DataTable dtamexamhh = new DataTable();
                //        dtamexamhh = dts1.Tables[0];
                //        if (dtamexamhh.Rows.Count > 0)
                //        {
                //            ViewState["dtamexamhh10"] = null;
                //        }
                //        else
                //        {
                //            ViewState["dtamexamhh10"] = dtamexamhh;
                //        }
                //    }
                //}

                ///////////////////////////////////

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts1 = new DataSet())
                //    {
                //        string query =
                //                  "select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh " +
                //                  "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                //                  "group by xsubject,xpaper,xext,xsection  ";

                //        SqlDataAdapter da1t = new SqlDataAdapter(query, con);
                //        da1t.SelectCommand.CommandTimeout = 0;
                //        da1t.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da1t.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da1t.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da1t.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da1t.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        //da1t.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                //        //da1t.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                //        //da1t.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                //        dts1.Reset();
                //        da1t.Fill(dts1, "tempztcode");
                //        DataTable dtamexamh = new DataTable();
                //        dtamexamh = dts1.Tables[0];
                //        if (dtamexamh.Rows.Count > 0)
                //        {
                //            ViewState["dtamexamh123"] = dtamexamh;
                //        }
                //        else
                //        {
                //            ViewState["dtamexamh123"] = null;
                //        }
                //    }
                //}

                ////////////////////////////////////////////////
                

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (DataSet dts1 = new DataSet())
                //    {
                //        string query =
                //                           "select xsubject,xpaper,xsection from amexamh  " +
                //                           "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                //                           "group by xsubject,xpaper,xsection";

                //        SqlDataAdapter da12t = new SqlDataAdapter(query, con);
                //        da12t.SelectCommand.CommandTimeout = 0;
                //        da12t.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                //        da12t.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        da12t.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        da12t.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        da12t.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                //        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                //        dts1.Reset();
                //        da12t.Fill(dts1, "tempztcode");
                //        DataTable dtamexamh = new DataTable();
                //        dtamexamh = dts1.Tables[0];
                //        if (dtamexamh.Rows.Count > 0)
                //        {
                //            ViewState["dtamexamh124"] = dtamexamh;
                //        }
                //        else
                //        {
                //            ViewState["dtamexamh124"] = null;
                //        }
                //    }
                //}

                ////////////////////////////////////////////////////////////

                BindGrid();
            
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        BoundField bfield;
        TemplateField tfield;
        DataTable dt;
        private DataTable dtsec;
        //private int check = 0;
        List<string> listsec = new List<string>();
        List<string> listperiod = new List<string>();
        List<int> listmaxnum = new List<int>();
        List<int> listtest = new List<int>();
        List<int> listretest = new List<int>();
        List<string> listtrow = new List<string>();
        List<string> listmaxrtcount = new List<string>();
        List<string> listretestrow = new List<string>();
        List<string> listsubject = new List<string>();
        List<string> listpaper = new List<string>();
        List<string> listgrade = new List<string>();
        private void BindGrid()
        {

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //ViewState["xrow"] = null;

            //string xrow = zglobal.fnGetValue("xrow", "amexamh",
            //     "zid=" + _zid + " and xsession='" + xsession.Text.Trim().ToString() + "' and xterm='" + xterm.Text.Trim().ToString() + "' and xclass='" + xclass.Text.Trim().ToString() +
            //     "' and xgroup='" + xgroup.Text.Trim().ToString() + "' and xsection='" + xsection.Text.Trim().ToString() + "' and xstatus in('Approved2','Approved3')");
            ////if (ViewState["xrow"] == null)
            //if (xrow == "")
            //{
            //    message.InnerHtml = "No data found.";
            //    message.Style.Value = zglobal.am_warningmsg;
            //    return;
            //}

            SqlConnection conn11;
            conn11 = new SqlConnection(zglobal.constring);
            DataSet dts11 = new DataSet();

            dts11.Reset();

            string str1 = "SELECT ROW_NUMBER() OVER (ORDER BY xcttype desc, xctno asc) AS xid,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                "WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'   order by xsection";


            SqlDataAdapter da11 = new SqlDataAdapter(str1, conn11);
            da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //da11.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //da11.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            da11.Fill(dts11, "tempztcode");
            DataTable dtmarks1 = new DataTable();
            dtmarks1 = dts11.Tables[0];

            if (dtmarks1.Rows.Count <= 0 && ViewState["msg"].ToString() != "1")
            {
                message.InnerHtml = "No data found.";
                message.Style.Value = zglobal.am_warningmsg;

                _student.Value = "";

                GridView1.DataSource = null;
                GridView1.DataBind();
                result.Visible = false;
                barchart.Visible = false;
                btnApprove.Visible = false;
                btnSave.Visible = false;

                return;
            }


            ViewState["msg"] = "2";





            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string xsession1 = xsession.Text.Trim().ToString();
            string xclass1 = xclass.Text.Trim().ToString();
            //string xgroup1 = xgroup.Text.Trim().ToString();
            //string xsection1 = xsection.Text.Trim().ToString();
            //message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            //return;
            //string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";

            string str = "SELECT distinct xsubject,xpaper,coalesce(xext,'') as xext FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow  " +
                " WHERE amexamh.zid=@zid AND amexamh.xsession=@xsession AND amexamh.xclass=@xclass AND amexamh.xterm=@xterm AND amexamh.xgroup=@xgroup AND amexamh.xtype='Class Test'  order by xsubject,xpaper,xext";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {

                GridView1.Columns.Clear();

                TemplateField tfield119 = new TemplateField();
                tfield119.HeaderText = "No.";
                tfield119.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield119.ItemStyle.Width = 35;
                GridView1.Columns.Add(tfield119);

                TemplateField tfield120 = new TemplateField();
                tfield120.HeaderText = "Subjects";
                tfield120.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield120.ItemStyle.Width = 180;
                GridView1.Columns.Add(tfield120);

                TemplateField tfield12000 = new TemplateField();
                tfield12000.HeaderText = "Paper";
                tfield12000.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield12000.ItemStyle.Width = 180;
                GridView1.Columns.Add(tfield12000);

                TemplateField tfield1200 = new TemplateField();
                tfield1200.HeaderText = "Extension";
                tfield1200.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                tfield1200.ItemStyle.Width = 180;
                GridView1.Columns.Add(tfield1200);

                TemplateField tfield121 = new TemplateField();
                tfield121.HeaderText = "Best";
                tfield121.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield121.ItemStyle.Width = 80;
                GridView1.Columns.Add(tfield121);

                TemplateField tfield1230 = new TemplateField();
                tfield1230.HeaderText = "Weight\n(%)";
                tfield1230.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield1230.ItemStyle.Width = 100;
                GridView1.Columns.Add(tfield1230);

                TemplateField tfield122 = new TemplateField();
                tfield122.HeaderText = "%";
                tfield122.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield122.ItemStyle.Width = 100;
                GridView1.Columns.Add(tfield122);



                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                       "select xsubject,xpaper,coalesce(xext,'') as xext,MAX(tbl.best) as best1 from " +
                       " (select zid,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,coalesce(xext,'') as xext ,count(*) as best " +
                       " from amexamh where xcttype in ('Test','Test (WS)') AND xtype='Class Test' " +
                       " group by zid,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,coalesce(xext,'')) as tbl " +
                       "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup  " +
                       " group by xsubject,xpaper,coalesce(xext,'') ";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["amexamh"] = dtamexamd;

                    }
                }


                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {

                        string query =
                       "SELECT zid,xsubject,xpaper,coalesce(xext,'') as xext,xstatus,xtype,xtype1,xperc,xtbest FROM amexamhh " +
                       "WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test' AND xstatus in ('New','Approved3')";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamhh = new DataTable();
                        dtamexamhh = dts1.Tables[0];

                        if (dtamexamhh.Rows.Count > 0)
                        {
                            ViewState["amexamhh"] = dtamexamhh;
                            if (dtamexamhh.Rows[0]["xstatus"].ToString() == "Approved3")
                            {

                                btnApprove.Enabled = false;
                                btnSave.Enabled = false;
                            }
                            else
                            {
                                btnApprove.Enabled = true;
                                btnSave.Enabled = true;
                            }

                        }
                        else
                        {
                            ViewState["amexamhh"] = null;
                            btnApprove.Enabled = true;
                            btnSave.Enabled = true;
                        }


                    }
                }




                TemplateField tfield124 = new TemplateField();
                tfield124.HeaderText = "";
                //tfield124.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield124.ItemStyle.Width = 50;
                tfield124.Visible = false;
                GridView1.Columns.Add(tfield124);

                TemplateField tfield125 = new TemplateField();
                tfield125.HeaderText = "";
                //tfield124.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield124.ItemStyle.Width = 50;
                tfield125.Visible = false;
                GridView1.Columns.Add(tfield125);

                TemplateField tfield126 = new TemplateField();
                tfield126.HeaderText = "";
                //tfield124.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //tfield124.ItemStyle.Width = 50;
                tfield126.Visible = false;
                GridView1.Columns.Add(tfield126);

                TemplateField tfield123 = new TemplateField();
                tfield123.HeaderText = "";
                tfield123.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield123.ItemStyle.Width = 50;
                tfield123.Visible = false;
                GridView1.Columns.Add(tfield123);

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        // //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        // //string query =
                        // //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        // //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                        string query =
                            "select * from amgradeconf where zid=@zid and xeffdate=(select MAX(xeffdate) from amgradeconf as a " +
                            " where zid=amgradeconf.zid and xeffdate<= " +
                            " (select max(xdate) from amexamh where xcttype in ('Test','Test (WS)') AND xtype='Class Test' and zid=@zid and " +
                            " xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup ) " +
                            " )";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.CommandTimeout = 0;
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];

                        ViewState["noofgrade"] = 0;
                        ViewState["xgrade"] = null;

                        if (dtamexamd.Rows.Count > 0)
                        {
                            ViewState["noofgrade"] = dtamexamd.Rows.Count;

                            foreach (DataRow row in dtamexamd.Rows)
                            {
                                tfield = new TemplateField();
                                tfield.HeaderText = row["xgrade"].ToString();
                                tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                //tfield.ItemStyle.Width = Unit.Pixel(120);
                                //tfield.HeaderStyle.Width = Unit.Pixel(120);
                                GridView1.Columns.Add(tfield);
                                listgrade.Add(row["xgrade"].ToString());

                            }

                            ViewState["xgrade"] = listgrade;
                        }
                    }
                }

                TemplateField tfield129 = new TemplateField();
                tfield129.HeaderText = "Students";
                tfield129.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield129.HeaderStyle.Width = 100;
                tfield129.ItemStyle.Width = 100;
                GridView1.Columns.Add(tfield129);

                TemplateField tfield12912 = new TemplateField();
                tfield12912.HeaderText = "Exam Given";
                tfield12912.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield12912.HeaderStyle.Width = 100;
                tfield12912.ItemStyle.Width = 100;
                GridView1.Columns.Add(tfield12912);

                TemplateField tfield1291 = new TemplateField();
                tfield1291.HeaderText = "Late \nAdmission";
                tfield1291.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield1291.HeaderStyle.Width = 100;
                tfield1291.ItemStyle.Width = 100;
                //tfield1291.Visible = false;
                GridView1.Columns.Add(tfield1291);

                TemplateField tfield12911 = new TemplateField();
                tfield12911.HeaderText = "N/A";
                tfield12911.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                tfield12911.HeaderStyle.Width = 100;
                tfield12911.ItemStyle.Width = 100;
                GridView1.Columns.Add(tfield12911);

                TemplateField tfield129114 = new TemplateField();
                tfield129114.HeaderText = "";
                tfield129114.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield129114);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();


                int ctn = Convert.ToInt32(ViewState["noofgrade"]);
                int RowSpan = 2;
                int RowSpan3 = 2;

                //int j = GridView1.Rows.Count;
                //List<int> listcount = new List<int>();
                for (int i = GridView1.Rows.Count - 2; i >= 0; i--)
                {
                    GridViewRow currRow = GridView1.Rows[i];
                    GridViewRow prevRow = GridView1.Rows[i + 1];
                    Label txt1 = currRow.Cells[1].FindControl("txtSubject") as Label;
                    Label txt2 = prevRow.Cells[1].FindControl("txtSubject") as Label;

                    Label lblpap1 = currRow.Cells[2].FindControl("txtPaper") as Label;
                    Label lblpap2 = prevRow.Cells[2].FindControl("txtPaper") as Label;

                    //Label lbl1 = currRow.Cells[0].FindControl("lblno") as Label;
                    //Label lbl2 = prevRow.Cells[0].FindControl("lblno") as Label;


                    //lbl1.Text = (j-1).ToString();
                    //lbl2.Text = (j).ToString();

                    if (txt1.Text == txt2.Text)
                    {
                        //if (RowSpan == 2)
                        //{
                        //    j -= 1;
                        //}

                        //string htmlColorCode ="";
                        ////if (RowSpan == 2)
                        ////{
                        ////    if (i%2 == 0)
                        ////    {
                        ////        htmlColorCode = "#FEE7DC";
                        ////    }
                        ////    else
                        ////    {
                        //        htmlColorCode = "#FBC8B4";
                        ////    }
                        ////}

                        //currRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //currRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //currRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //currRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //currRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //currRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //currRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //currRow.Cells[10].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                        //prevRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //prevRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //prevRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //prevRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //prevRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //prevRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //prevRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        //prevRow.Cells[10].BackColor = ColorTranslator.FromHtml(htmlColorCode);


                        currRow.Cells[1].RowSpan = RowSpan;
                        //currRow.Cells[1].BackColor = Color.LightBlue;
                        prevRow.Cells[1].Visible = false;
                        currRow.Cells[0].RowSpan = RowSpan;
                        prevRow.Cells[0].Visible = false;
                        //currRow.Cells[6].RowSpan = RowSpan;
                        ////currRow.Cells[5].BackColor = Color.LightBlue;
                        //prevRow.Cells[6].Visible = false;

                        //currRow.Cells[10].RowSpan = RowSpan;
                        //prevRow.Cells[10].Visible = false;

                        RowSpan += 1;

                        if (lblpap1.Text == lblpap2.Text)
                        {
                            currRow.Cells[2].RowSpan = RowSpan3;
                            prevRow.Cells[2].Visible = false;
                            currRow.Cells[6].RowSpan = RowSpan3;
                            prevRow.Cells[6].Visible = false;

                            currRow.Cells[10].RowSpan = RowSpan3;
                            prevRow.Cells[10].Visible = false;

                            if (ctn != 0)
                            {
                                for (int m = 1; m <= ctn; m++)
                                {
                                    currRow.Cells[m + 10].RowSpan = RowSpan3;
                                    prevRow.Cells[m + 10].Visible = false;
                                }
                            }

                            currRow.Cells[ctn + 11].RowSpan = RowSpan3;
                            prevRow.Cells[ctn + 11].Visible = false;

                            currRow.Cells[ctn + 12].RowSpan = RowSpan3;
                            prevRow.Cells[ctn + 12].Visible = false;

                            currRow.Cells[ctn + 13].RowSpan = RowSpan3;
                            prevRow.Cells[ctn + 13].Visible = false;

                            currRow.Cells[ctn + 14].RowSpan = RowSpan3;
                            prevRow.Cells[ctn + 14].Visible = false;

                            currRow.Cells[ctn + 15].RowSpan = RowSpan3;
                            prevRow.Cells[ctn + 15].Visible = false;

                            RowSpan3 += 1;
                        }
                        else
                        {
                            RowSpan3 = 2;
                        }
                    }
                    else
                    {
                        //listcount.Add(RowSpan);
                        RowSpan = 2;
                        RowSpan3 = 2;
                        //j -= 1;
                    }


                }

                //listcount.Add(RowSpan);

                //int i1 = 1;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Label lbl = (Label)row.FindControl("lblno");
                //    lbl.Text = i1.ToString();
                //    i1++;
                //}

                int RowSpan1 = 2;
                int j = 0;
                int k = 0;
                //List<int> listcount = new List<int>();
                for (int i = 0; i <= GridView1.Rows.Count - 2; i++)
                {

                    GridViewRow currRow = GridView1.Rows[i];
                    GridViewRow nextRow = GridView1.Rows[i + 1];

                    Label txt1 = currRow.Cells[1].FindControl("txtSubject") as Label;
                    Label txt2 = nextRow.Cells[1].FindControl("txtSubject") as Label;

                    Label lbl1 = currRow.Cells[0].FindControl("lblno") as Label;
                    Label lbl2 = nextRow.Cells[0].FindControl("lblno") as Label;

                    lbl1.Text = (j + 1).ToString();
                    lbl2.Text = (j + 2).ToString();

                    string htmlColorCode = "";
                    string htmlColorCode1 = "";

                    if (txt1.Text == txt2.Text)
                    {
                        if (RowSpan1 == 2)
                        {
                            j += 1;
                        }

                        RowSpan1 += 1;
                        k += 1;
                    }
                    else
                    {
                        //listcount.Add(RowSpan);
                        RowSpan1 = 2;
                        if (k > 0)
                        {
                            k = 0;
                            //j -= 1;
                        }
                        else
                        {
                            j += 1;
                        }
                    }

                    if (j % 2 == 0)
                    {
                        htmlColorCode = "#FEE7DC";
                        htmlColorCode1 = "#D3EAD9";
                    }
                    else
                    {
                        htmlColorCode = "#FFF6F1";
                        htmlColorCode1 = "#E4F2E7";
                    }

                    currRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[10].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                    if (ctn != 0)
                    {
                        for (int m = 1; m <= ctn; m++)
                        {
                            //ctn = 10 + i;
                            currRow.Cells[m+10].BackColor = ColorTranslator.FromHtml(htmlColorCode1);

                        }
                    }

                    currRow.Cells[ctn + 11].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[ctn + 12].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[ctn + 13].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[ctn + 14].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    currRow.Cells[ctn + 15].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                    //ctn = Convert.ToInt32(ViewState["noofgrade"]);

                    nextRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[10].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                    if (ctn != 0)
                    {
                        for (int m = 1; m <= ctn; m++)
                        {
                            //ctn = 10 + i;
                            nextRow.Cells[m+10].BackColor = ColorTranslator.FromHtml(htmlColorCode1);
                        }
                    }

                    nextRow.Cells[ctn + 11].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[ctn + 12].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[ctn + 13].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[ctn + 14].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    nextRow.Cells[ctn + 15].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                    //ctn = Convert.ToInt32(ViewState["noofgrade"]);

                    if (i == GridView1.Rows.Count - 2 && txt1.Text!=txt2.Text)
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            htmlColorCode = "#FEE7DC";
                            htmlColorCode1 = "#D3EAD9";
                        }
                        else
                        {
                            htmlColorCode = "#FFF6F1";
                            htmlColorCode1 = "#E4F2E7";
                        }

                        nextRow.Cells[0].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[1].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[2].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[3].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[4].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[5].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[6].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[10].BackColor = ColorTranslator.FromHtml(htmlColorCode);

                        if (ctn != 0)
                        {
                            for (int m = 1; m <= ctn; m++)
                            {
                                //ctn = 10 + i;
                                nextRow.Cells[m+10].BackColor = ColorTranslator.FromHtml(htmlColorCode1);
                            }
                        }

                        nextRow.Cells[ctn + 11].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[ctn + 12].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[ctn + 13].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[ctn + 14].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                        nextRow.Cells[ctn + 15].BackColor = ColorTranslator.FromHtml(htmlColorCode);
                    }
                }

                ctn = Convert.ToInt32(ViewState["noofgrade"].ToString());
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lblstd1 = row.Cells[ctn + 11].FindControl("lblstd") as Label;
                    Label lblpresent1 = row.Cells[ctn + 11].FindControl("lblpresent") as Label;
                    Label lblabsent1 = row.Cells[ctn + 11].FindControl("lblabsent") as Label;
                    Label lblna1 = row.Cells[ctn + 11].FindControl("lblna") as Label;
                    Label txtSubject1 = row.Cells[1].FindControl("txtSubject") as Label;
                    Label txtPaper1 = row.Cells[2].FindControl("txtPaper") as Label;

                    DataRow[] amstudentvw1 =
                           ((DataTable)ViewState["amstudentvw1"]).Select();
                    lblstd1.Text = amstudentvw1[0][0].ToString();

                    int ts = Convert.ToInt32(amstudentvw1[0][0].ToString());


                    DataRow[] result =
                           ((DataTable)ViewState["amexamh"]).Select("xsubject='" + txtSubject1.Text + "' and xpaper='" + txtPaper1.Text + "'");

                    //if (ViewState["amstd2"] != null && ViewState["amstd1"] != null)
                    if (ViewState["amstd4"] != null)
                    {
                        //var query1 = from row4 in ((DataTable)ViewState["amstd2"]).AsEnumerable()
                        //             where row4.Field<string>("xsubject") == txtSubject1.Text && row4.Field<string>("xpaper") == txtPaper1.Text &&
                        //              row4.Field<int>("xnumexam") == Convert.ToInt32(result[0]["best1"].ToString())
                        //             select new
                        //             {
                        //                 xstdid = row4.Field<string>("xstdid")
                        //             };

                        var query1 = from row4 in ((DataTable)ViewState["amstd4"]).AsEnumerable()
                                     where row4.Field<string>("xsubject") == txtSubject1.Text && row4.Field<string>("xpaper") == txtPaper1.Text 
                                     select new
                                     {
                                         xstdid = row4.Field<string>("xstdid")
                                     };

                        //var query1 = from row4 in ((DataTable)ViewState["amstd2"]).AsEnumerable()
                        //             where row4.Field<string>("xsubject") == txtSubject1.Text && row4.Field<string>("xpaper") == txtPaper1.Text &&
                        //              row4.Field<int>("xnumexam") == row4.Field<int>("xabsent")
                        //             select new
                        //             {
                        //                 xstdid = row4.Field<string>("xstdid")
                        //             };

                        //var query2 = from row5 in ((DataTable)ViewState["amstd1"]).AsEnumerable()
                        //             select new
                        //             {
                        //                 xstdid = row5.Field<string>("xstdid")
                        //             };

                        //var std = query2.Except(query1);

                        var std = query1.Distinct();

                        if (std.Count() > 0)
                        {
                            lblabsent1.Text = std.Count().ToString();
                           // lblpresent1.Text = (ts - std.Count()).ToString();
                        }
                        else
                        {
                            lblabsent1.Text = "0";
                           // lblpresent1.Text = ts.ToString();
                        }

                    }
                    else
                    {
                        lblabsent1.Text = "0";
                       // lblpresent1.Text = ts.ToString();
                    }

                    if (ViewState["amstd3"] != null && ViewState["amstd1"] != null)
                    {


                        //var query1 = from row4 in ((DataTable)ViewState["amstd3"]).AsEnumerable()
                        //             where row4.Field<string>("xsubject") == txtSubject1.Text && row4.Field<string>("xpaper") == txtPaper1.Text &&
                        //             row4.Field<int>("xnumexam") == Convert.ToInt32(result[0]["best1"].ToString())
                        //             select new
                        //             {
                        //                 xstdid = row4.Field<string>("xstdid")
                        //             };

                        var query1 = from row4 in ((DataTable)ViewState["amstd3"]).AsEnumerable()
                                     where row4.Field<string>("xsubject") == txtSubject1.Text && row4.Field<string>("xpaper") == txtPaper1.Text &&
                                     row4.Field<int>("xnumexam") == row4.Field<int>("xna")
                                     select new
                                     {
                                         xstdid = row4.Field<string>("xstdid")
                                     };

                        //var query2 = from row5 in ((DataTable)ViewState["amstd1"]).AsEnumerable()
                        //             select new
                        //             {
                        //                 xstdid = row5.Field<string>("xstdid")
                        //             };

                        var std = query1.Distinct();

                        if (std.Count() > 0)
                        {
                            lblna1.Text = std.Count().ToString();
                            //lblpresent1.Text = (ts - std.Count()).ToString();
                        }
                        else
                        {
                            lblna1.Text = "0";
                            //lblpresent1.Text = ts.ToString();
                        }

                    }
                    else
                    {
                        lblna1.Text = "0";
                    }

                    lblpresent1.Text =
                        (ts - (Convert.ToInt32(lblabsent1.Text) + Convert.ToInt32(lblna1.Text))).ToString();
                }

                foreach (GridViewRow row in GridView1.Rows)
                {
                    //ImageButton btn = row.FindControl("gradebutton") as ImageButton;

                    //ImageOnClick(,null);

                    GradeCal(row);
                }

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.DataSource == null)
                {
                    return;
                }

                //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                //TableHeaderCell cell = new TableHeaderCell();

                //GridView1.HeaderRow.Cells[0].Visible = false;
                //GridView1.HeaderRow.Cells[1].Visible = false;


                //cell = new TableHeaderCell();
                //cell.Text = "No.";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.Text = "Subject's Name";
                //cell.RowSpan = 2;
                //row.Controls.Add(cell);

                ////GridView1.Rows[0].Cells[0].RowSpan = 2;
                ////GridView1.Rows[0].Cells[1].RowSpan = 2;
                ////GridView1.Rows[0].Cells[2].RowSpan = 2;
                //int i = 4;
                //foreach (string val in (List<string>)ViewState["listtrow"])
                //{
                //    cell = new TableHeaderCell();
                //    cell.ColumnSpan = 5;
                //    cell.Text = val;
                //    cell.BorderStyle = BorderStyle.Solid;
                //    cell.BorderWidth = 2;
                //    cell.BorderColor = Color.White;
                //    row.Controls.Add(cell);

                //    GridView1.HeaderRow.Cells[i+1].Visible = false;
                //    GridView1.HeaderRow.Cells[i + 2].Visible = false;

                //    GridView1.HeaderRow.Cells[i].ColumnSpan = 3;

                //    i = i + 5;
                //}


                //cell = new TableHeaderCell();
                //row.Controls.Add(cell);
                //// row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
                //GridView1.HeaderRow.Parent.Controls.AddAt(0, row);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }




        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Int64 xrow = Int64.Parse((e.Row.DataItem as DataRowView).Row["xrow"].ToString());

                    Label lblno = new Label();
                    lblno.ID = "lblno";
                    lblno.Style["display"] = "block";
                    lblno.Style["width"] = "40px";
                    lblno.Style["text-align"] = "center";
                    e.Row.Cells[0].Controls.Add(lblno);

                    Label txtSubject = new Label();
                    txtSubject.ID = "txtSubject";
                    txtSubject.Style["display"] = "block";
                    txtSubject.Style["width"] = "150px";
                    txtSubject.Style["text-align"] = "left";
                    //txtSubject.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    e.Row.Cells[1].Controls.Add(txtSubject);

                    Label txtPaper = new Label();
                    txtPaper.ID = "txtPaper";
                    txtPaper.Style["display"] = "block";
                    txtPaper.Style["width"] = "50px";
                    txtPaper.Style["text-align"] = "left";
                    //txtSubject.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    e.Row.Cells[2].Controls.Add(txtPaper);

                    Label txtExtension = new Label();
                    txtExtension.ID = "txtExtension";
                    txtExtension.Style["display"] = "block";
                    txtExtension.Style["width"] = "100px";
                    txtExtension.Style["text-align"] = "left";
                    //txtSubject.CssClass = "bm_academic_textbox_grid bm_academic_ctl_global bm_academic_textbox";
                    e.Row.Cells[3].Controls.Add(txtExtension);


                    Label lblSubject = new Label();
                    lblSubject.ID = "lblSubject";
                    e.Row.Cells[7].Controls.Add(lblSubject);

                    lblSubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();

                    Label lblPaper = new Label();
                    lblPaper.ID = "lblPaper";
                    e.Row.Cells[8].Controls.Add(lblPaper);

                    lblPaper.Text = (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();

                    Label lblExtension = new Label();
                    lblExtension.ID = "lblExtension";
                    e.Row.Cells[9].Controls.Add(lblExtension);

                    lblExtension.Text = (e.Row.DataItem as DataRowView).Row["xext"].ToString();

                    //DropDownList dlistBest = new DropDownList();
                    //dlistBest.ID = "dlistBest";
                    //dlistBest.BorderColor = Color.Silver;
                    //dlistBest.BorderStyle = BorderStyle.Solid;
                    //dlistBest.BorderWidth = Unit.Pixel(1);
                    //dlistBest.Width = Unit.Pixel(40);
                    //e.Row.Cells[4].Controls.Add(dlistBest);

                    TextBox dlistBest = new TextBox();
                    dlistBest.ID = "dlistBest";
                    dlistBest.BorderColor = Color.Silver;
                    dlistBest.BorderStyle = BorderStyle.Solid;
                    dlistBest.BorderWidth = Unit.Pixel(1);
                    dlistBest.Width = Unit.Pixel(40);
                    e.Row.Cells[4].Controls.Add(dlistBest);

                    //message.InnerHtml = message.InnerHtml + e.Row.Cells[4].Text.ToString() + " " + e.Row.Cells[5].Text.ToString() + "<br>";
                    //string paper = e.Row.Cells[5].Text.ToString() != String.Empty && e.Row.Cells[5].Text.ToString() != "" ? e.Row.Cells[5].Text.ToString() : "";
                    DataRow[] result =
                           ((DataTable)ViewState["amexamh"]).Select("xsubject='" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" + (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xext='" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'");

                    //if (result.Length > 0)
                    //{
                    //    dlistBest.Items.Add("");
                    //    for (int i = 1; i <= Convert.ToInt32(result[0]["best1"].ToString()); i = i + 1)
                    //    {
                    //        dlistBest.Items.Add(i.ToString() + "/" + result[0]["best1"].ToString());
                    //    }
                        dlistBest.Text = "";
                    //}

                    TextBox txtWeight = new TextBox();
                    txtWeight.ID = "txtWeight";
                    txtWeight.Width = Unit.Pixel(35);
                    txtWeight.BorderColor = Color.Silver;
                    txtWeight.BorderStyle = BorderStyle.Solid;
                    txtWeight.BorderWidth = Unit.Pixel(1);
                    txtWeight.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[5].Controls.Add(txtWeight);

                    if ((e.Row.DataItem as DataRowView).Row["xext"].ToString() == "" ||
                        (e.Row.DataItem as DataRowView).Row["xext"].ToString() == String.Empty)
                    {
                        txtWeight.Enabled = false;
                        txtWeight.Visible = false;
                        txtWeight.Text = 100.ToString();
                    }

                    //DropDownList dlistPerc = new DropDownList();
                    //dlistPerc.ID = "dlistPerc";
                    //dlistPerc.BorderColor = Color.Silver;
                    //dlistPerc.BorderStyle=BorderStyle.Solid;
                    //dlistPerc.BorderWidth = Unit.Pixel(1);
                    //e.Row.Cells[5].Controls.Add(dlistPerc);

                    //dlistPerc.Items.Add("");
                    //for (int i = 10; i <= 100; i = i + 5)
                    //{
                    //    dlistPerc.Items.Add(i.ToString());
                    //}
                    //dlistPerc.Text = "";

                    TextBox dlistPerc = new TextBox();
                    dlistPerc.ID = "dlistPerc";
                    dlistPerc.Width = Unit.Pixel(35);
                    dlistPerc.BorderColor = Color.Silver;
                    dlistPerc.BorderStyle = BorderStyle.Solid;
                    dlistPerc.BorderWidth = Unit.Pixel(1);
                    dlistPerc.Attributes.Add("onkeyup", "enter(this,event)");
                    e.Row.Cells[6].Controls.Add(dlistPerc);




                    ImageButton image = new ImageButton();
                    image.ID = "gradebutton";
                    image.ImageUrl = "/images/reload-blue1.png";
                    image.CssClass = "bm_academic_button_zoom";
                    image.Width = Unit.Pixel(15);
                    image.Height = Unit.Pixel(15);
                    image.Click += ImageOnClick;
                    e.Row.Cells[10].Controls.Add(image);

                    int ctn = 10;
                    if (Convert.ToInt32(ViewState["noofgrade"] )!= 0)
                    {
                        for (int i = 1; i <= Convert.ToInt32(ViewState["noofgrade"]); i++)
                        {
                            ctn = 10 + i;
                            TextBox lbl = new TextBox();
                            lbl.ID = "lblGrade" + listgrade[i-1];
                            //lbl.Width = Unit.Pixel(50);
                            lbl.Style["display"] = "block";
                            lbl.Style["width"] = "40px";
                            lbl.Style["text-align"] = "center";
                            e.Row.Cells[ctn].Controls.Add(lbl);
                            lbl.EnableViewState = true;
                            lbl.Style["background-color"] = "transparent";
                            lbl.Enabled = false;
                            lbl.BorderStyle = BorderStyle.None;
                            lbl.BorderColor = System.Drawing.Color.White;
                            lbl.ForeColor = Color.Black;
                            lbl.Font.Bold = true;
                            lbl.Font.Size = FontUnit.Point(10);
                        }
                    }

                    Label lbl1 = new Label();
                    lbl1.ID = "lblstd";
                    //lbl1.Width = Unit.Pixel(50);
                    lbl1.Style["display"] = "block";
                    lbl1.Style["width"] = "80px";
                    lbl1.Style["text-align"] = "center";
                    e.Row.Cells[ctn + 1].Controls.Add(lbl1);

                    Label lbl4 = new Label();
                    lbl4.ID = "lblpresent";
                    //lbl2.Width = Unit.Pixel(50);
                    lbl4.Style["display"] = "block";
                    lbl4.Style["width"] = "80px";
                    lbl4.Style["text-align"] = "center";
                    e.Row.Cells[ctn + 2].Controls.Add(lbl4);

                    Label lbl2 = new Label();
                    lbl2.ID = "lblabsent";
                    //lbl2.Width = Unit.Pixel(50);
                    lbl2.Style["display"] = "block";
                    lbl2.Style["width"] = "80px";
                    lbl2.Style["text-align"] = "center";
                    e.Row.Cells[ctn + 3].Controls.Add(lbl2);

                    Label lbl3 = new Label();
                    lbl3.ID = "lblna";
                    //lbl3.Width = Unit.Pixel(50);
                    lbl3.Style["display"] = "block";
                    lbl3.Style["width"] = "80px";
                    lbl3.Style["text-align"] = "center";
                    e.Row.Cells[ctn + 4].Controls.Add(lbl3);

                    //HtmlGenericControl image = new HtmlGenericControl("img");
                    //image.Attributes.Add("src", "/images/reload-blue1.png");
                    //image.Attributes.Add("class", "bm_academic_button_zoom bm_button_reload");
                    //image.Attributes.Add("style", "width:15px;height=15px;cursor:pointer;");
                    ////image.Click += ImageOnClick;
                    //e.Row.Cells[10].Controls.Add(image);

                    //if ((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == "")
                    //{
                    //    txtSubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    //}
                    //else
                    //{
                    //    txtSubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
                    //                      (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    //}

                    if ((e.Row.DataItem as DataRowView).Row["xsubject"].ToString() == "")
                    {
                        txtSubject.Text = "";
                    }
                    else
                    {
                        txtSubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
                    }

                    if ((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == "")
                    {
                        txtPaper.Text = "";
                    }
                    else
                    {
                        txtPaper.Text = (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
                    }

                    if ((e.Row.DataItem as DataRowView).Row["xext"].ToString() == "")
                    {
                        txtExtension.Text = "";
                    }
                    else
                    {
                        txtExtension.Text = (e.Row.DataItem as DataRowView).Row["xext"].ToString();
                    }

                    if (ViewState["amexamhh"] != null)
                    {
                        DataRow[] result50 =
                          ((DataTable)ViewState["amexamhh"]).Select("xsubject='" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" + (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xtype1='Class Test'");

                        if (result50.Length > 0)
                        {

                            //dlistBest.Text = result50[0]["xtbest"].ToString();
                            dlistPerc.Text = result50[0]["xperc"].ToString() == "0" ? "" : result50[0]["xperc"].ToString();

                            if (result50[0]["xstatus"].ToString() == "Approved3")
                            {
                                //dlistBest.Enabled = false;
                                dlistPerc.Enabled = false;
                            }
                            else
                            {
                                // dlistBest.Enabled = true;
                                dlistPerc.Enabled = true;
                            }
                        }

                    }

                    if (ViewState["amexamhh"] != null)
                    {
                        DataRow[] result50 =
                          ((DataTable)ViewState["amexamhh"]).Select("xsubject='" + (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" + (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xtype1='Subject Extension'" + " and xext='" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'");

                        if (result50.Length > 0)
                        {

                            dlistBest.Text = result50[0]["xtbest"].ToString() == "0" ? "" : result50[0]["xtbest"].ToString() + "/" + result[0]["best1"].ToString();
                            txtWeight.Text = result50[0]["xperc"].ToString() == "0" ? "" : result50[0]["xperc"].ToString();
                            //dlistPerc.Text = result50[0]["xperc"].ToString();

                            if (result50[0]["xstatus"].ToString() == "Approved3")
                            {
                                dlistBest.Enabled = false;
                                txtWeight.Enabled = false;
                                //dlistPerc.Enabled = false;
                            }
                            else
                            {
                                dlistBest.Enabled = true;
                                txtWeight.Enabled = true;
                                //dlistPerc.Enabled = true;
                            }
                        }

                    }


                }
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }

        private void GradeCal(GridViewRow row)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                //ImageButton ib = (ImageButton)sender;
                //GridViewRow row = (GridViewRow)ib.NamingContainer;

                if (row != null)
                {


                    string xpaper1 = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblPaper")).Text.ToString();
                    string xsubject1 = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblSubject")).Text.ToString();
                    //string xext1 = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblExtension")).Text.ToString();
                    string xext1 = "";
                    //string xbest1 = ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString();
                    string xbest1 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString();
                    string[] xbst = xbest1.Split('/');
                    xbest1 = Convert.ToString(xbst[0]);
                    //string xperc1 = ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString();
                    string xperc1 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString();
                    string xperc_weight = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString();



                    #region Check for approval
                    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //{
                    //    using (DataSet dts1 = new DataSet())
                    //    {

                    //        string query =
                    //       "select xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and " +
                    //       "amexamh.xsection=mscodesam.xcode " +
                    //       "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and " +
                    //       "xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper  " +
                    //       "group by xsection  order by min(cast(xcodealt as int))";

                    //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                    //        da1.Fill(dts1, "tempztcode");
                    //        DataTable dtamexamh = new DataTable();
                    //        dtamexamh = dts1.Tables[0];

                    //        if (dtamexamh.Rows.Count > 0)
                    //        {
                    //            string subj = "";
                    //            //if (xpaper1 == "")
                    //            //{
                    //            //    subj = xsubject1;
                    //            //}
                    //            //else
                    //            //{
                    //            //    subj = xsubject1 + "-" + xpaper1;
                    //            //}

                    //            if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    //            {
                    //                subj = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                    //            }
                    //            else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    //            {
                    //                subj = xsubject1 + "-" + xpaper1;
                    //            }
                    //            else if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 == "" || xpaper1 == String.Empty))
                    //            {
                    //                subj = xsubject1 + "(" + xext1 + ")";
                    //            }
                    //            else
                    //            {
                    //                subj = xsubject1;
                    //            }


                    //            message.InnerHtml = "Please check for approval.<br/>Subject : " + subj + "<br/>Section : ";
                    //            int h = 0;
                    //            foreach (DataRow val in dtamexamh.Rows)
                    //            {
                    //                if (h == dtamexamh.Rows.Count - 1)
                    //                {
                    //                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ". ";
                    //                }
                    //                else
                    //                {
                    //                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ", ";
                    //                }

                    //                h = h + 1;

                    //            }
                    //            message.Style.Value = zglobal.am_warningmsg;

                    //            result.Visible = false;
                    //            barchart.Visible = false;
                    //            return;
                    //        }

                    //    }
                    //}

                    if (ViewState["amexamh10"] != null)
                    {
                        DataRow[] amexamh10 =
                          ((DataTable)ViewState["amexamh10"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
                        string subj = "";
                        //if (xpaper1 == "")
                        //{
                        //    subj = xsubject1;
                        //}
                        //else
                        //{
                        //    subj = xsubject1 + "-" + xpaper1;
                        //}
                        if (amexamh10.Length > 0)
                        {
                            if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                            {
                                subj = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                            }
                            else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                            {
                                subj = xsubject1 + "-" + xpaper1;
                            }
                            else if ((xext1 != "" || xext1 != String.Empty) &&
                                     (xpaper1 == "" || xpaper1 == String.Empty))
                            {
                                subj = xsubject1 + "(" + xext1 + ")";
                            }
                            else
                            {
                                subj = xsubject1;
                            }


                            message.InnerHtml = "Please check for approval.<br/>Subject : " + subj + "<br/>Section : ";
                            int h = 0;
                            foreach (DataRow val in amexamh10)
                            {
                                if (h == amexamh10.Length - 1)
                                {
                                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ". ";
                                }
                                else
                                {
                                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ", ";
                                }

                                h = h + 1;

                            }
                            message.Style.Value = zglobal.am_warningmsg;

                            result.Visible = false;
                            barchart.Visible = false;
                            return;
                        }
                    }

                    #endregion

                    #region Construct Table
                    //result.Visible = true;
                    //barchart.Visible = true;


                    //DataRow[] result10 =
                    //       ((DataTable)ViewState["amexamh"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");



                    //if (xpaper1 == "")
                    //{
                    //    xsubject.Text = xsubject1;
                    //}
                    //else
                    //{
                    //    xsubject.Text = xsubject1 + "-" + xpaper1;
                    //}

                    ////if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    ////{
                    ////    xsubject.Text = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                    ////}
                    ////else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    ////{
                    ////    xsubject.Text = xsubject1 + "-" + xpaper1;
                    ////}
                    ////else if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 == "" || xpaper1 == String.Empty))
                    ////{
                    ////    xsubject.Text = xsubject1 + "(" + xext1 + ")";
                    ////}
                    ////else
                    ////{
                    ////    xsubject.Text = xsubject1;
                    ////}

                    //if (xbest1 != "" && result10.Length>0)
                    //{
                    //    xbest.Text = xbest1;

                    //    if (xperc1 != "")
                    //    {
                    //        xbest.Text = xbest1 + " out of " + result10[0]["best1"].ToString() + " (" + xperc1 + "%)";
                    //    }
                    //}
                    //else
                    //{
                    //    xbest.Text = "";
                    //}

                    //int ts = 0;
                    ////using (SqlConnection con = new SqlConnection(zglobal.constring))
                    ////{
                    ////    using (DataSet dts1 = new DataSet())
                    ////    {
                    ////        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    ////        //string query =
                    ////        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    ////        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    ////        string query =
                    ////       "select count(xstdid) from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession  ";

                    ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                    ////        da1.Fill(dts1, "tempztcode");
                    ////        DataTable dtamexamd = new DataTable();
                    ////        dtamexamd = dts1.Tables[0];

                    ////        xnostd.Text = dtamexamd.Rows[0][0].ToString();
                    ////        ts = Convert.ToInt32(dtamexamd.Rows[0][0].ToString());

                    ////    }
                    ////} ViewState["amstudentvw1"]

                    //DataRow[] amstudentvw1 =
                    //       ((DataTable)ViewState["amstudentvw1"]).Select();
                    //xnostd.Text = amstudentvw1[0][0].ToString();
                    //ts = Convert.ToInt32(amstudentvw1[0][0].ToString());

                    ////using (SqlConnection con = new SqlConnection(zglobal.constring))
                    ////{
                    ////    using (DataSet dts1 = new DataSet())
                    ////    {
                    ////        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    ////        //string query =
                    ////        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    ////        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    ////        string query =
                    ////       "select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
                    ////       " except " +
                    ////       "select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                    ////       " and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper  " +
                    ////       "and  xgetmark<>-1 and  coalesce(xna,0) <> 1";

                    ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                    ////        da1.Fill(dts1, "tempztcode");
                    ////        DataTable dtamexamd = new DataTable();
                    ////        dtamexamd = dts1.Tables[0];

                    ////        if (dtamexamd.Rows.Count > 0)
                    ////        {
                    ////            xabsent.Text = dtamexamd.Rows.Count.ToString();
                    ////            xtaken.Text = (ts - dtamexamd.Rows.Count).ToString();
                    ////        }
                    ////        else
                    ////        {
                    ////            xabsent.Text = "0";
                    ////            xtaken.Text = ts.ToString();
                    ////        }

                    ////    }
                    ////}

                    //if (ViewState["amstd2"] != null && ViewState["amstd1"] != null)
                    //{
                    //    var query1 = from row4 in ((DataTable)ViewState["amstd2"]).AsEnumerable()
                    //                 where row4.Field<string>("xsubject")==xsubject1 &&  row4.Field<string>("xpaper")==xpaper1  
                    //                 select new
                    //                 {
                    //                     xstdid = row4.Field<string>("xstdid")
                    //                 };
                    //    var query2 = from row5 in ((DataTable)ViewState["amstd1"]).AsEnumerable()
                    //                 select new
                    //                 {
                    //                     xstdid = row5.Field<string>("xstdid")
                    //                 };

                    //    var std = query2.Except(query1);

                    //    if (std.Count() > 0)
                    //    {
                    //        xabsent.Text = std.Count().ToString();
                    //        xtaken.Text = (ts - std.Count()).ToString();
                    //    }
                    //    else
                    //    {
                    //        xabsent.Text = "0";
                    //        xtaken.Text = ts.ToString();
                    //    }

                    //}
                    //else
                    //{
                    //    xabsent.Text = "0";
                    //    xtaken.Text = ts.ToString();
                    //}

                    #endregion

                    //if (xbest1 != "" && xperc1 != "" && xperc_weight!="")
                    if (xperc1 != "" && xperc_weight != "")
                    {
                        using (SqlConnection con = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts1 = new DataSet())
                            {
                                //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                                //string query =
                                //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                                //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                                // string query =
                                //"select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
                                //" except " +
                                //"select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                                //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and  xgetmark<>-1";

                                //string query = "select grade,count(*) as nostd from " +
                                //    "(select xsrow,SUM(case when xbest=-1 then 0 else xbest end) as xgetmark,SUM(xmarks) as xmark, " +
                                //    "(SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks)) as xperc, " +
                                //    "((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) as xperc1, " +
                                //    " (select xgrade from amgradeconf where ((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) >=xmin and " +
                                //    " ((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) <=xmax and " +
                                //    "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //    "(select max(xdate) from amexamh where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper )  )) as grade " +
                                //    "from amexammaxmarkvw3 " +
                                //    " where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and xid <=@xid and xbestflag=1 " +
                                //    "group by xsrow) tbl " +
                                //"group by grade";

                                //         string query = "select grade,count(*) as nostd from " +
                                //    "(select xsrow,SUM(case when xbest=-1 then 0 else xbest end) as xgetmark,SUM(xmarks) as xmark, " +
                                //    "(SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks)) as xperc, " +
                                //    "((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) as xperc1, " +
                                //    " (select xgrade from amgradeconf where round(((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc),0) >=xmin and " +
                                //    " round(((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc),0) <=xmax and " +
                                //    "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //    "(select max(xdate) from amexamh where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper )  )) as grade " +
                                //    "from amexammaxmarkvw3 " +
                                //    " where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and xid <=@xid and xbestflag=1 " +
                                //    "group by xsrow) tbl " +
                                //"group by grade";

                                string query = "";

                                //query = "select * from amexamhh where zid=@zid and xsession=@xsession and xterm=@xterm and " +
                                //        "xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject " +
                                //        "and xpaper=@xpaper and xtype='Class Test' and xstatus in ('New','Approved3')";

                                //SqlDataAdapter da11 = new SqlDataAdapter(query, con);
                                //da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //da11.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //da11.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                                //dts1.Reset();
                                //da11.Fill(dts1, "tempztcode");
                                //DataTable dtamexamhh = new DataTable();
                                //dtamexamhh = dts1.Tables[0];
                                //int isAccess = 0;
                                //if (ViewState["dtamexamhh10"] != null)
                                //{
                                //    DataRow[] dtamexamhh10 =
                                //        ((DataTable) ViewState["dtamexamhh10"]).Select("xsubject='" + xsubject1 +
                                //                                                       "' and xpaper='" + xpaper1 + "'");
                                //    if (dtamexamhh10.Length > 0)
                                //    {
                                //        isAccess = 0;
                                //    }
                                //    else
                                //    {
                                //        isAccess = 1;
                                //    }
                                //}

                                #region Insert into amexamhh
                                //if (isAccess == 1)
                                //{
                                //    //int flag = 0;

                                //    //int RowSpan1 = 2;
                                //    //int RowSpan2 = 2;

                                //    //string perc = "";
                                //    //string perc1 = "";
                                //    //List<int> listcount = new List<int>();
                                //    //for (int i = 0; i <= GridView1.Rows.Count - 2; i++)
                                //    //{

                                //    //    GridViewRow currRow = GridView1.Rows[i];
                                //    //    GridViewRow nextRow = GridView1.Rows[i + 1];

                                //    //    Label txt1 = currRow.Cells[1].FindControl("txtSubject") as Label;
                                //    //    Label txt2 = nextRow.Cells[1].FindControl("txtSubject") as Label;

                                //    //    Label lblpap1 = currRow.Cells[2].FindControl("txtPaper") as Label;
                                //    //    Label lblpap2 = nextRow.Cells[2].FindControl("txtPaper") as Label;

                                //    //    Label lblext1 = currRow.Cells[2].FindControl("txtExtension") as Label;
                                //    //    Label lblext2 = nextRow.Cells[2].FindControl("txtExtension") as Label;

                                //    //    xext1 = lblext1.Text;

                                //    //    DropDownList dlistBest1 = currRow.FindControl("dlistBest") as DropDownList;
                                //    //    //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                                //    //    TextBox txtWeight1 = currRow.FindControl("txtWeight") as TextBox;
                                //    //    TextBox dlistPerc1 = currRow.FindControl("dlistPerc") as TextBox;

                                //    //    DropDownList dlistBest2 = nextRow.FindControl("dlistBest") as DropDownList;
                                //    //    //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                                //    //    TextBox txtWeight2 = nextRow.FindControl("txtWeight") as TextBox;
                                //    //    TextBox dlistPerc2 = nextRow.FindControl("dlistPerc") as TextBox;
                                //    //    if (txt1.Text == xsubject1 && lblpap1.Text == xpaper1)
                                //    //    {
                                //    //        if (txt1.Text == txt2.Text)
                                //    //        {
                                //    //            if (lblpap1.Text == lblpap2.Text)
                                //    //            {
                                //    //                if (RowSpan2 == 2)
                                //    //                {
                                //    //                    perc = dlistPerc1.Text.Trim().ToString();
                                //    //                }

                                //    //                ((TextBox)nextRow.FindControl("dlistPerc")).Text = perc.ToString();


                                //    //                RowSpan2 += 1;
                                //    //            }
                                //    //            else
                                //    //            {
                                //    //                RowSpan2 = 2;
                                //    //            }




                                //    //            RowSpan1 += 1;

                                //    //        }
                                //    //        else
                                //    //        {
                                //    //            //listcount.Add(RowSpan);
                                //    //            RowSpan1 = 2;
                                //    //            RowSpan2 = 2;
                                //    //        }
                                //    //    }


                                //    //}



                                //    string xstatus;

                                //    using (TransactionScope tran = new TransactionScope())
                                //    {
                                //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                //        {
                                //            conn.Open();
                                //            SqlCommand cmd = new SqlCommand();
                                //            //SqlTransaction tran;
                                //            //tran = conn.BeginTransaction("SampleTransaction");

                                //            cmd.Connection = conn;
                                //            //cmd.Transaction = tran;
                                //            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                //            string zemail1t = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //            DateTime ztime1t = DateTime.Now;
                                //            xstatus = "Test";

                                //            query =
                                //                                "UPDATE amexamvw set amexamvw.xbflag=0  " +
                                //                                "WHERE amexamvw.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                                " AND xsubject=@xsubject AND xpaper=@xpaper  and xtype='Class Test'";

                                //            cmd.Parameters.Clear();
                                //            cmd.CommandTimeout = 0;
                                //            cmd.CommandText = query;
                                //            cmd.Parameters.AddWithValue("@zid", _zid);
                                //            //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //            //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //            //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //            //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //            //cmd.Parameters.AddWithValue("@xid", _xid);
                                //            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //            cmd.Parameters.AddWithValue("@xext", xext1);
                                //            cmd.ExecuteNonQuery();

                                //            DataTable dtamexamh;

                                //            using (SqlConnection con1t = new SqlConnection(zglobal.constring))
                                //            {
                                //                using (DataSet dts1t = new DataSet())
                                //                {

                                //           //         query =
                                //           //"select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                                //           //"where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                                //           //"and xsubject=@xsubject and xpaper=@xpaper  " +
                                //           //"group by xsubject,xpaper,xext,xsection  order by min(cast(xcodealt as int))";

                                //     //               query =
                                //     //"select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh " +
                                //     //"where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                                //     //"and xsubject=@xsubject and xpaper=@xpaper  " +
                                //     //"group by xsubject,xpaper,xext,xsection  )";

                                //     //               SqlDataAdapter da1t = new SqlDataAdapter(query, con1t);
                                //     //               da1t.SelectCommand.CommandTimeout = 0;
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                                //     //               //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //     //               //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                //     //               da1t.Fill(dts1t, "tempztcode");
                                //     //               dtamexamh = new DataTable();
                                //     //               dtamexamh = dts1t.Tables[0];

                                //                    if (ViewState["dtamexamh123"] != null)
                                //                    {
                                //                        DataRow[] dtamexamh123 =
                                //                            ((DataTable) ViewState["dtamexamh123"]).Select(
                                //                                "xsubject='" + xsubject1 +
                                //                                "' and xpaper='" + xpaper1 + "'");
                                //                        if (dtamexamh123.Length > 0)
                                //                        {
                                //                            //ViewState["amexamh1t"] = dtamexamh123;
                                //                            ViewState["amexamh1t"] = ViewState["dtamexamh123"];
                                //                            //message.InnerHtml = "yes";
                                //                            //return;
                                //                        }
                                //                        else
                                //                        {
                                //                            ViewState["amexamh1t"] = null;
                                //                            //message.InnerHtml = "no";
                                //                            //return;
                                //                        }

                                //                    }
                                //                    else
                                //                    {
                                //                        ViewState["amexamh1t"] = null;
                                //                        //message.InnerHtml = "no";
                                //                        //return;
                                //                    }

                                //                }
                                //            }


                                //            if (ViewState["amexamh1t"] != null)
                                //            //if (dtamexamh.Rows.Count > 0)
                                //            {

                                //                foreach (GridViewRow row1 in GridView1.Rows)
                                //                {
                                //                    //string xpaper1t = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                //                    //string xsubject1t = ((Label)row1.FindControl("lblSubject")).Text.ToString();
                                //                    //string xext1t = ((Label)row1.FindControl("lblExtension")).Text.ToString();
                                //                    //int _xid = Convert.ToInt32(((DropDownList)row1.FindControl("dlistBest")).Text.ToString() == "" ? "0" : ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());

                                //                    string xpaper1t = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblPaper")).Text.ToString();
                                //                    string xsubject1t = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblSubject")).Text.ToString();
                                //                    string xext1t = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblExtension")).Text.ToString();
                                //                    int _xid = Convert.ToInt32(((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == "" ? "0" : ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString());





                                //                    //query =
                                //                    //        "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
                                //                    //        "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
                                //                    //        "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
                                //                    //        "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                    //        "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

                                //                    //cmd.Parameters.Clear();
                                //                    //cmd.CommandTimeout = 0;
                                //                    //cmd.CommandText = query;
                                //                    //cmd.Parameters.AddWithValue("@zid", _zid);
                                //                    ////cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                    ////cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                    ////cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                    ////cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                    //cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xid", _xid);
                                //                    //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                    //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                    //cmd.Parameters.AddWithValue("@xext", xext1t);
                                //                    //cmd.ExecuteNonQuery();

                                //                    if (xpaper1t == xpaper1 && xsubject1t == xsubject1)
                                //                    {

                                //                        query =
                                //                            "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
                                //                            "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
                                //                            "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
                                //                            "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                            "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

                                //                        cmd.Parameters.Clear();
                                //                        cmd.CommandTimeout = 0;
                                //                        cmd.CommandText = query;
                                //                        cmd.Parameters.AddWithValue("@zid", _zid);
                                //                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xid", _xid);
                                //                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                        cmd.Parameters.AddWithValue("@xext", xext1t);
                                //                        cmd.ExecuteNonQuery();



                                //                        DataRow[] result600 = ((DataTable)ViewState["amexamh1t"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1t + "'");
                                //                        //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                //                        if (result600.Length > 0)
                                //                        {
                                //                            foreach (DataRow row2 in result600)
                                //                            {


                                //                                //query =
                                //                                //        "DELETE FROM amexamhh " +
                                //                                //        "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                                //        "AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test' and xstatus='Test' and xtype1='Subject Extension'";

                                //                                //cmd.Parameters.Clear();

                                //                                //cmd.CommandText = query;
                                //                                //cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                ////cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                                ////cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                ////cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                                ////cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                                //cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xid", _xid);
                                //                                //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                //cmd.Parameters.AddWithValue("@xext", xext1);
                                //                                //cmd.ExecuteNonQuery();

                                //                                string xsection1t = row2["xsection"].ToString();


                                //                                query =
                                //                                    "delete from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                    "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension' and xstatus='Test'";

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;
                                //                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection1t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                cmd.Parameters.AddWithValue("@xext", xext1t);

                                //                                cmd.ExecuteNonQuery();


                                //                                //query =
                                //                                //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xapproved1by,xapproved1dt) " +
                                //                                //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xapproved1by,@xapproved1dt) ";

                                //                                // query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test') " +
                                //                                //"UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xapproved1by=@xapproved1by,xapproved1dt=@xapproved1dt,xstatus=@xstatus " +
                                //                                //"where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' " +
                                //                                // "ELSE " +
                                //                                // "INSERT INTO amexamhh (zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,xapproved1by,xapproved1dt) " +
                                //                                // "VALUES(@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@xapproved1by,@xapproved1dt) ";

                                //                                //query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension' and xstatus='Test') " +
                                //                                //"UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xstatus=@xstatus " +
                                //                                //"where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1=@xtype1 " +
                                //                                //"ELSE " +
                                //                                query = "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";



                                //                                // query = 
                                //                                //"INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                //"VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";



                                //                                int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                //                                string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                                //                                string xapproved1by =
                                //                                    Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                DateTime xapproved1dt = DateTime.Now;
                                //                                DateTime ztime1 = DateTime.Now;

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;
                                //                                cmd.Parameters.AddWithValue("@ztime", ztime1);
                                //                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection1t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                cmd.Parameters.AddWithValue("@xext", xext1t);
                                //                                cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                //                                cmd.Parameters.AddWithValue("@xtbest",
                                //                                    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xperc",
                                //                                    ((TextBox)row1.FindControl("txtWeight")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                cmd.Parameters.AddWithValue("@zemail", zemail);
                                //                                cmd.Parameters.AddWithValue("@xapproved1by", xapproved1by);
                                //                                cmd.Parameters.AddWithValue("@xapproved1dt", xapproved1dt);
                                //                                cmd.Parameters.AddWithValue("@xtype1", "Subject Extension");
                                //                                cmd.ExecuteNonQuery();


                                //                            }
                                //                        }
                                //                    }

                                //                }
                                //            }

                                //            using (SqlConnection con2t = new SqlConnection(zglobal.constring))
                                //            {
                                //                using (DataSet dts12t = new DataSet())
                                //                {

                                //           //         query =
                                //           //"select xsubject,xpaper,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                                //           //"where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                                //           //"group by xsubject,xpaper,xsection  order by min(cast(xcodealt as int))";

                                //           //         SqlDataAdapter da12t = new SqlDataAdapter(query, con2t);
                                //           //         da12t.SelectCommand.CommandTimeout = 0;
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                //           //         da12t.Fill(dts12t, "tempztcode");
                                //           //         dtamexamh = new DataTable();
                                //           //         dtamexamh = dts12t.Tables[0];
                                //                    if (ViewState["dtamexamh124"] != null)
                                //                    {
                                //                        DataRow[] dtamexamh124 =
                                //                            ((DataTable)ViewState["dtamexamh124"]).Select(
                                //                                "xsubject='" + xsubject1 +
                                //                                "' and xpaper='" + xpaper1 + "'");
                                //                        if (dtamexamh124.Length > 0)
                                //                        {
                                //                            //ViewState["amexamh1t"] = dtamexamh123;
                                //                            ViewState["amexamh2t"] = ViewState["dtamexamh124"];
                                //                            //message.InnerHtml = "yes";
                                //                            //return;
                                //                        }
                                //                        else
                                //                        {
                                //                            ViewState["amexamh2t"] = null;
                                //                            //message.InnerHtml = "no";
                                //                            //return;
                                //                        }

                                //                    }
                                //                    else
                                //                    {
                                //                        ViewState["amexamh2t"] = null;
                                //                        //message.InnerHtml = "no";
                                //                        //return;
                                //                    }


                                //                }
                                //            }

                                //            if (ViewState["amexamh2t"] != null)
                                //            {

                                //                foreach (GridViewRow row1 in GridView1.Rows)
                                //                {
                                //                    string xpaper12t = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                //                    string xsubject12t = ((Label)row1.FindControl("lblSubject")).Text.ToString();



                                //                    if (xpaper12t == xpaper1 && xsubject12t == xsubject1)
                                //                    {
                                //                        DataRow[] result60000 = ((DataTable)ViewState["amexamh2t"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
                                //                        //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                //                        if (result60000.Length > 0)
                                //                        {
                                //                            foreach (DataRow row2 in result60000)
                                //                            {
                                //                                string xsection12t = row2["xsection"].ToString();

                                //                                query = "delete from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                           "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test' and xstatus='Test'";

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;

                                //                                cmd.Parameters.AddWithValue("@zid", _zid);

                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection12t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject12t);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper12t);

                                //                                cmd.ExecuteNonQuery();

                                //                                //query =
                                //                                //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
                                //                                //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

                                //                                //query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //        "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test' and xstatus='Test') " +
                                //                                //        "UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xstatus=@xstatus " +
                                //                                //        "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //        "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' and xtype1=@xtype1 " +
                                //                                //        "ELSE " +
                                //                                query = "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                        "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

                                //                                //query = 
                                //                                //        "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                //        "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";



                                //                                int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                //                                string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);


                                //                                string xapproved1by = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                DateTime xapproved1dt = DateTime.Now;
                                //                                DateTime ztime1 = DateTime.Now;
                                //                                DateTime zutime1 = DateTime.Now;

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;
                                //                                cmd.Parameters.AddWithValue("@ztime", ztime1);
                                //                                cmd.Parameters.AddWithValue("@zutime", zutime1);
                                //                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection12t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject12t);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper12t);
                                //                                cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                //                                //cmd.Parameters.AddWithValue("@xtbest",
                                //                                //    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xtbest",
                                //                                   0);
                                //                                cmd.Parameters.AddWithValue("@xperc",
                                //                                    ((TextBox)row1.FindControl("dlistPerc")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                cmd.Parameters.AddWithValue("@zemail", zemail);
                                //                                cmd.Parameters.AddWithValue("@xemail", xemail);
                                //                                cmd.Parameters.AddWithValue("@xapproved1by", xapproved1by);
                                //                                cmd.Parameters.AddWithValue("@xapproved1dt", xapproved1dt);
                                //                                cmd.Parameters.AddWithValue("@xtype1", "Class Test");
                                //                                cmd.ExecuteNonQuery();



                                //                            }
                                //                        }
                                //                    }


                                //                }
                                //            }

                                //            // tran.Commit();
                                //        }

                                //        tran.Complete();
                                //    }
                                //}
                                #endregion


                                #region insert into amexamhh2


                                //                                string xstatus;

                                //                                using (TransactionScope tran = new TransactionScope())
                                //                                {
                                //                                    using (SqlConnection conn1 = new SqlConnection(zglobal.constring))
                                //                                    {
                                //                                        conn1.Open();
                                //                                        SqlCommand cmd = new SqlCommand();

                                //                                        cmd.Connection = conn1;

                                //                                        string xapproved3by = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                        DateTime xapproved3dt = DateTime.Now;
                                //                                        xstatus = "New";





                                //                                        query =
                                //                                                "UPDATE amexamvw set amexamvw.xbflag=0  " +
                                //                                                "WHERE amexamvw.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                                                "and xsubject=@xsubject and xpaper=@xpaper  " +
                                //                                                "and xtype='Class Test'";

                                //                                        cmd.Parameters.Clear();

                                //                                        cmd.CommandText = query;
                                //                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                        //cmd.Parameters.AddWithValue("@xid", _xid);
                                //                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                        //cmd.Parameters.AddWithValue("@xext", xext1);
                                //                                        cmd.ExecuteNonQuery();



                                //                                        query =
                                //                                                "DELETE FROM amexamhh " +
                                //                                                "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                                                "and xtype='Class Test' and xstatus='Test' and xsubject=@xsubject and xpaper=@xpaper ";

                                //                                        cmd.Parameters.Clear();

                                //                                        cmd.CommandText = query;
                                //                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                        //cmd.Parameters.AddWithValue("@xid", _xid);
                                //                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                        //cmd.Parameters.AddWithValue("@xext", xext1);
                                //                                        cmd.ExecuteNonQuery();

                                //                                        DataTable dtamexamh;

                                //                                        using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                                //                                        {
                                //                                            using (DataSet dts11 = new DataSet())
                                //                                            {

                                //                                                query =
                                //                                       "select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh  " +
                                //                                       "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and " +
                                //                                       "xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper  " +
                                //                                       "group by xsubject,xpaper,xext,xsection ";

                                //                                                SqlDataAdapter da11 = new SqlDataAdapter(query, con1);
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                                //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //                                                //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                //                                                da11.Fill(dts11, "tempztcode");
                                //                                                dtamexamh = new DataTable();
                                //                                                dtamexamh = dts11.Tables[0];

                                //                                                if (dtamexamh.Rows.Count > 0)
                                //                                                {
                                //                                                    ViewState["amexamh1"] = dtamexamh;
                                //                                                    //message.InnerHtml = "yes";
                                //                                                    //return;
                                //                                                }
                                //                                                else
                                //                                                {
                                //                                                    ViewState["amexamh1"] = null;
                                //                                                    //message.InnerHtml = "no";
                                //                                                    //return;
                                //                                                }

                                //                                            }
                                //                                        }

                                //                                        if (ViewState["amexamh1"] != null)
                                //                                        //if (dtamexamh.Rows.Count > 0)
                                //                                        {

                                //                                            //foreach (GridViewRow row1 in GridView1.Rows)
                                //                                            //{
                                //                                            //    string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                //                                            //    string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();
                                //                                            //    string xext1 = ((Label)row1.FindControl("lblExtension")).Text.ToString();

                                //                                            int _xid = Convert.ToInt32(((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == "" ? "0" : ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString());


                                //                                                query =
                                //                                                    "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
                                //                                                    "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
                                //                                                    "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
                                //                                                    "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                                                    "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

                                //                                                cmd.Parameters.Clear();

                                //                                                cmd.CommandText = query;
                                //                                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                                //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                                                //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                                //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                                                //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                                cmd.Parameters.AddWithValue("@xid", _xid);
                                //                                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                                cmd.Parameters.AddWithValue("@xext", xext1);
                                //                                                cmd.ExecuteNonQuery();



                                //                                                DataRow[] result60 = ((DataTable)ViewState["amexamh1"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");
                                //                                                //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                //                                                if (result60.Length > 0)
                                //                                                {
                                //                                                    foreach (DataRow row2 in result60)
                                //                                                    {
                                //                                                        string xsection1 = row2["xsection"].ToString();


                                //                                                        //query =
                                //                                                        //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
                                //                                                        //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

                                //                                                        query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension') " +
                                //                                                                "UPDATE amexamhh SET zutime=@zutime,xtbest=@xtbest,xperc=@xperc,xemail=@xemail " +
                                //                                                                "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1=@xtype1 " +
                                //                                                                "ELSE " +
                                //                                                                "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

                                //                                                        int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                //                                                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                                //                                                        DateTime ztime1 = DateTime.Now;
                                //                                                        DateTime zutime1 = DateTime.Now;

                                //                                                        cmd.Parameters.Clear();

                                //                                                        cmd.CommandText = query;
                                //                                                        cmd.Parameters.AddWithValue("@ztime", ztime1);
                                //                                                        cmd.Parameters.AddWithValue("@zutime", zutime1);
                                //                                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                                        cmd.Parameters.AddWithValue("@xrow", xrow);
                                //                                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xsection", xsection1);
                                //                                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                                        cmd.Parameters.AddWithValue("@xext", xext1);
                                //                                                        cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                //                                                        cmd.Parameters.AddWithValue("@xtbest",
                                //                                                            ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == "" ||
                                //                                                            ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == String.Empty
                                //                                                            ? "0" :
                                //                                                            ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString());
                                //                                                        cmd.Parameters.AddWithValue("@xperc",
                                //                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString() == "" ||
                                //                                                         ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString() == String.Empty
                                //                                                         ? "0" :
                                //                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString());
                                //                                                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                                        cmd.Parameters.AddWithValue("@zemail", zemail);
                                //                                                        cmd.Parameters.AddWithValue("@xemail", xemail);
                                //                                                        cmd.Parameters.AddWithValue("@xtype1", "Subject Extension");
                                //                                                        cmd.ExecuteNonQuery();



                                //                                                    }
                                //                                                }
                                //                                            //}
                                //                                        }


                                //                                        using (SqlConnection con1 = new SqlConnection(zglobal.constring))
                                //                                        {
                                //                                            using (DataSet dts11 = new DataSet())
                                //                                            {

                                //                                                query =
                                //                                       "select xsubject,xpaper,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                                //                                       "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper " +
                                //                                       "group by xsubject,xpaper,xsection  order by min(cast(xcodealt as int))";

                                //                                                SqlDataAdapter da11 = new SqlDataAdapter(query, con1);
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                                da11.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                                //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //                                                //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                //                                                da11.Fill(dts11, "tempztcode");
                                //                                                dtamexamh = new DataTable();
                                //                                                dtamexamh = dts11.Tables[0];

                                //                                                if (dtamexamh.Rows.Count > 0)
                                //                                                {
                                //                                                    ViewState["amexamh2"] = dtamexamh;
                                //                                                    //message.InnerHtml = "yes";
                                //                                                    //return;
                                //                                                }
                                //                                                else
                                //                                                {
                                //                                                    ViewState["amexamh2"] = null;
                                //                                                    //message.InnerHtml = "no";
                                //                                                    //return;
                                //                                                }

                                //                                            }
                                //                                        }

                                //                                        if (ViewState["amexamh2"] != null)
                                //                                        {

                                //                                            //foreach (GridViewRow row1 in GridView1.Rows)
                                //                                            //{
                                //                                            //    string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                //                                            //    string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();





                                //                                                DataRow[] result60 = ((DataTable)ViewState["amexamh2"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
                                //                                                //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                //                                                if (result60.Length > 0)
                                //                                                {
                                //                                                    foreach (DataRow row2 in result60)
                                //                                                    {
                                //                                                        string xsection1 = row2["xsection"].ToString();


                                //                                                        //query =
                                //                                                        //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
                                //                                                        //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

                                //                                                        query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test') " +
                                //                                                                "UPDATE amexamhh SET zutime=@zutime,xtbest=@xtbest,xperc=@xperc,xemail=@xemail " +
                                //                                                                "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' and xtype1=@xtype1 " +
                                //                                                                "ELSE " +
                                //                                                                "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

                                //                                                        int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                //                                                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                                //                                                        DateTime ztime1 = DateTime.Now;
                                //                                                        DateTime zutime1 = DateTime.Now;

                                //                                                        cmd.Parameters.Clear();

                                //                                                        cmd.CommandText = query;
                                //                                                        cmd.Parameters.AddWithValue("@ztime", ztime1);
                                //                                                        cmd.Parameters.AddWithValue("@zutime", zutime1);
                                //                                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                                        cmd.Parameters.AddWithValue("@xrow", xrow);
                                //                                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                                        cmd.Parameters.AddWithValue("@xsection", xsection1);
                                //                                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                                        cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                //                                                        //cmd.Parameters.AddWithValue("@xtbest",
                                //                                                        //    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                //                                                        cmd.Parameters.AddWithValue("@xtbest",
                                //                                                           0);
                                //                                                        cmd.Parameters.AddWithValue("@xperc",
                                //                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString() == "" ||
                                //                                                        ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString() == string.Empty
                                //                                                        ? "0" :
                                //                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString());
                                //                                                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                                        cmd.Parameters.AddWithValue("@zemail", zemail);
                                //                                                        cmd.Parameters.AddWithValue("@xemail", xemail);
                                //                                                        cmd.Parameters.AddWithValue("@xtype1", "Class Test");
                                //                                                        cmd.ExecuteNonQuery();



                                //                                                    }
                                //                                                }
                                //                                            //}
                                //                                        }



                                //                                        // tran.Commit();
                                //                                    }

                                //                                    tran.Complete();
                                //                                }


                                #endregion insert into amexamhh2

                                //query = "select grade,count(*) as nostd from " +
                                //               "(select b.xsrow,SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end) as xgetmark,SUM(xmarks) as xmark, " +

                                //               "(SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks)) as xperc, " +
                                //               "((SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks))*100/@perc) as xperc1, " +
                                //               "(select xgrade from amgradeconf where round(((SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks))*100/@perc),0) >=xmin and " +
                                //               " round(((SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks))*100/@perc),0) <=xmax and " +
                                //               "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //               "(select max(xdate) from amexamh where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //               "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper )  )) as grade " +
                                //               "from amexammaxmarkvw2  as b inner join amexamvw on b.zid=amexamvw.zid and b.xrow=amexamvw.xrow and b.xline=amexamvw.xline and b.xsrow=amexamvw.xsrow " +
                                //               "where b.zid=@zid and xcttype in ('Test','Test (WS)') AND b.xtype='Class Test' and b.xsession=@xsession and " +
                                //               "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper and xid <=1 " +
                                //               "group by b.xsrow) tbl " +
                                //               "group by grade ";

                                //query = "select grade,count(*) as nostd from " +
                                //        "(select *, (select xgrade from amgradeconf where round(xpercexam100,0) >=xmin and " +
                                //        "round(xpercexam100,0) <=xmax and " +
                                //        "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //        "(select max(xdate) from amexamh where zid=b.zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' " +
                                //        "and xsession=b.xsession and " +
                                //        "xterm=b.xterm and xclass=b.xclass and xgroup=b.xgroup and xsubject=b.xsubject and xpaper=b.xpaper  ) " +
                                //        "  )) as grade " +
                                //        "from amexamvw_sumext_exam2  as b " +
                                //        "where b.zid=@zid and b.xsession=@xsession and " +
                                //        "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  " +
                                //        ") tbl " +
                                //        "group by grade";

                                //query = "insert into test (zid,xsession,xclass,xterm,xgroup,xsubject,xpaper,xgrade,xcount) " +
                                //        "select zid,xsession,xclass,xterm,xgroup,xsubject,xpaper,xgrade,count(*) as xcount from amexamvw_sumext_exam2_sub " +
                                //        "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                               "and xsubject=@xsubject and xpaper=@xpaper   " +
                                //        "group by zid,xsession,xclass,xterm,xgroup,xsubject,xpaper,xgrade";
                                //SqlCommand cmd123 = new SqlCommand();
                                //con.Open();
                                //cmd123.Connection = con;
                                //cmd123.Parameters.Clear();
                                //cmd123.CommandTimeout = 0;
                                //cmd123.CommandText = query;

                                //cmd123.Parameters.AddWithValue("@zid", _zid);

                                //cmd123.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xsubject", xsubject1);
                                //cmd123.Parameters.AddWithValue("@xpaper", xpaper1);
                                //cmd123.ExecuteNonQuery();

                                //query = "select xgrade as grade,xcount as nostd from test as b " +
                                //    "where b.zid=@zid and b.xsession=@xsession and " +
                                //      "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  ";

                                ////query = "select xgrade as grade,count(*) as nostd  " +
                                ////        "from  amexamvw_sumext_exam2_sub as b " +
                                ////        "where b.zid=@zid and b.xsession=@xsession and " +
                                ////        "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  " +
                                ////        "group by xgrade";

                                ////query = "select xgrade as grade,count(*) as nostd  " +
                                ////        "from amexamvw_sumext_exam2_sub  as b inner join amstudentvw as a on a.zid=b.zid and a.xsession=b.xsession and a.xrow=b.xsrow " +
                                ////        "where b.zid=@zid and b.xsession=@xsession and " +
                                ////        "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  " +
                                ////        "group by xgrade";

                                //SqlDataAdapter da111 = new SqlDataAdapter(query, con);
                                //da111.SelectCommand.CommandTimeout = 0;
                                //da111.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //da111.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //da111.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                ////da1.SelectCommand.Parameters.AddWithValue("@xid", Convert.ToInt32(xbest1));
                                ////da1.SelectCommand.Parameters.AddWithValue("@perc", Convert.ToInt32(xperc1));

                                //dts1.Reset();
                                //da111.Fill(dts1, "tempztcode");
                                //DataTable dtamexamd = new DataTable();
                                //dtamexamd = dts1.Tables[0];

                                //if (dtamexamd.Rows.Count > 0)
                                //{
                                //    //ViewState["amresult"] = dtamexamd;

                                //    int ctn = 10;
                                //    List<string> gradeList = (List<string>) ViewState["xgrade"];


                                //    for (int i = 1; i <= Convert.ToInt32(ViewState["noofgrade"].ToString()); i++)
                                //    {
                                //        //if (gradeList[i - 1] == dtamexamd.Rows[0]["xgrade"])
                                //        //{
                                //        //((Label)GridView1.Rows[row.RowIndex].FindControl("lblGrade" + gradeList[i - 1])).Text =
                                //        //    dtamexamd.Rows[0]["xgrade"].ToString();
                                //        //}

                                //        message.InnerHtml = message.InnerHtml + (dtamexamd.Rows[0]["xgrade"] + "\n");
                                //    }
                                //}
                                //else
                                //{
                                //    //ViewState["amresult"] = null;
                                //}

                                string connectionString = zglobal.constring;
                                SqlConnection con123 = new SqlConnection(connectionString);

                                SqlCommand cmd = new SqlCommand("amgradesp", con123);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);

                                con123.Open();
                                SqlDataReader reader = cmd.ExecuteReader();

                                //foreach (var VARIABLE in COLLECTION)
                                //{

                                //}
                                while (reader.Read())
                                {
                                    //message.InnerHtml = message.InnerHtml + (reader["grade"].ToString() + "\n");
                                    ((TextBox)GridView1.Rows[row.RowIndex].FindControl("lblGrade" + reader["grade"].ToString())).Text = reader["nostd"].ToString();

                                }

                                con123.Close();

                            }
                        }
                    }

                    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //{
                    //    using (DataSet dts1 = new DataSet())
                    //    {
                    //        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    //        //string query =
                    //        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    //        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    //        // string query =
                    //        //"select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
                    //        //" except " +
                    //        //"select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                    //        //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and  xgetmark<>-1";

                    //        string query =
                    //            "select * from amgradeconf where zid=@zid and xeffdate=(select MAX(xeffdate) from amgradeconf as a " +
                    //            "where zid=amgradeconf.zid and xeffdate<= (select max(xdate) from amexamh " +
                    //            "where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                    //            " and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper))";

                    //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xid", Convert.ToInt32(xbest1));
                    //        //da1.SelectCommand.Parameters.AddWithValue("@perc", Convert.ToInt32(xperc1));

                    //        da1.Fill(dts1, "tempztcode");
                    //        DataTable dtamexamd = new DataTable();
                    //        dtamexamd = dts1.Tables[0];

                    //        if (dtamexamd.Rows.Count > 0)
                    //        {
                    //            ViewState["amgrade"] = dtamexamd;
                    //        }
                    //        else
                    //        {
                    //            ViewState["amgrade"] = null;
                    //            message.InnerHtml = "Grading System Not Configured.";
                    //            message.Style.Value = zglobal.am_warningmsg;
                    //        }


                    //    }
                    //}

                    //if (ViewState["amresult"] != null && ViewState["amgrade"] != null)
                    //{

                    //}


                    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //{
                    //    using (DataSet dts1 = new DataSet())
                    //    {
                    //       // //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    //       // //string query =
                    //       // //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    //       // //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    //        string query =
                    //       "select * from amgradeconf where zid=@zid and xeffdate=(select MAX(xeffdate) from amgradeconf as a " +
                    //       " where zid=amgradeconf.zid and xeffdate<= " +
                    //       " (select max(xdate) from amexamh where xcttype in ('Test','Test (WS)') AND xtype='Class Test' and zid=@zid and " +
                    //       " xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper) " +
                    //       " )";

                    //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    //        da1.SelectCommand.CommandTimeout = 0;
                    //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);

                    //        da1.Fill(dts1, "tempztcode");
                    //        DataTable dtamexamd = new DataTable();
                    //        dtamexamd = dts1.Tables[0];




                    //        if (dtamexamd.Rows.Count > 0)
                    //        //if (ViewState["dtamexamd200"] != null)
                    //        {
                    //     //       DataRow[] dtamexamd =
                    //     //((DataTable)ViewState["dtamexamd200"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                    //            grade.Controls.Clear();
                    //            colorcode.Controls.Clear();

                    //            HtmlGenericControl table = new HtmlGenericControl("table");
                    //            table.Attributes.Add("style", "width: 100%; border-collapse: collapse; border: none;color: #000000");

                    //            grade.Controls.Add(table);

                    //            HtmlGenericControl table1 = new HtmlGenericControl("table");
                    //            table1.Attributes.Add("style", "width: 100%;  border: 1px solid #FFFFFF; border-spacing: 5px;color: #000000");

                    //            colorcode.Controls.Add(table1);


                    //            Chart1.Series["Series1"].Points.Clear();

                    //            Series series = Chart1.Series["Series1"];

                    //            int count = 1;
                    //            foreach (DataRow _row in dtamexamd.Rows)
                    //            //foreach (DataRow _row in dtamexamd)
                    //            {
                    //                HtmlGenericControl tr = new HtmlGenericControl("tr");
                    //                if (count % 2 != 0)
                    //                {
                    //                    tr.Attributes.Add("style", "background-color: #CEE5B7");
                    //                }
                    //                table.Controls.Add(tr);

                    //                HtmlGenericControl td1 = new HtmlGenericControl("td");
                    //                td1.Attributes.Add("style", "width: 50%; text-align: right; padding-right: 30px;");
                    //                //td1.InnerHtml = dtamexamd.Rows[count - 1]["xcaption"].ToString();
                    //                td1.InnerHtml = _row["xcaption"].ToString();
                    //                tr.Controls.Add(td1);

                    //                HtmlGenericControl td2 = new HtmlGenericControl("td");
                    //                td2.Attributes.Add("style", "width: 20%;");
                    //                //td2.InnerHtml = dtamexamd.Rows[count - 1]["xgrade"].ToString();
                    //                td2.InnerHtml = _row["xgrade"].ToString();
                    //                tr.Controls.Add(td2);

                    //                HtmlGenericControl td3 = new HtmlGenericControl("td");
                    //                td3.Attributes.Add("style", "width: 30%; padding-left: 10px;");
                    //                if (xbest1 != "" && xperc1 != "")
                    //                {
                    //                    if (ViewState["amresult"] != null)
                    //                    {
                    //                        //DataRow[] result20 =
                    //                        //    ((DataTable)ViewState["amresult"]).Select("grade='" + dtamexamd.Rows[count - 1]["xgrade"].ToString() + "'");
                    //                        DataRow[] result20 =
                    //                           ((DataTable)ViewState["amresult"]).Select("grade='" + _row["xgrade"].ToString() + "'");
                    //                        if (result20.Length > 0)
                    //                        {
                    //                            td3.InnerHtml = result20[0][1].ToString();

                    //                            series.Points.AddXY(result20[0][0].ToString(), result20[0][1].ToString());
                    //                            //series.Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
                    //                            //series.Points[count - 1].Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
                    //                            series.Color = ColorTranslator.FromHtml(_row["xcolor"].ToString());
                    //                            series.Points[count - 1].Color = ColorTranslator.FromHtml(_row["xcolor"].ToString());
                    //                        }
                    //                        else
                    //                        {
                    //                            td3.InnerHtml = "0";
                    //                            //series.Points.AddXY(dtamexamd.Rows[count - 1]["xgrade"].ToString(), 0);
                    //                            //series.Points[count - 1].Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
                    //                            series.Points.AddXY(_row["xgrade"].ToString(), 0);
                    //                            series.Points[count - 1].Color = ColorTranslator.FromHtml(_row["xcolor"].ToString());
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        td3.InnerHtml = "-";
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    td3.InnerHtml = "";
                    //                }

                    //                tr.Controls.Add(td3);




                    //                //Add color code


                    //                HtmlGenericControl tr2 = new HtmlGenericControl("tr");
                    //                table1.Controls.Add(tr2);

                    //                HtmlGenericControl td4 = new HtmlGenericControl("td");
                    //                //string _color = dtamexamd.Rows[count - 1]["xcolor"].ToString();
                    //                string _color = _row["xcolor"].ToString();
                    //                td4.Attributes.Add("style", "width:20px;height:10px;background-color:" + _color + ";color:" + _color);
                    //                td4.InnerHtml = "---";
                    //                tr2.Controls.Add(td4);

                    //                HtmlGenericControl td5 = new HtmlGenericControl("td");
                    //                //td5.InnerHtml = dtamexamd.Rows[count - 1]["xgrade"].ToString();
                    //                td5.InnerHtml = _row["xgrade"].ToString();
                    //                tr2.Controls.Add(td5);

                    //                ///////////
                    //                /// 
                    //                /// 
                    //                /// 
                    //                count = count + 1;
                    //            }
                    //        }
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

        protected void ImageOnClick(object sender, EventArgs e)
        {
            try
            {
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                ImageButton ib = (ImageButton)sender;
                GridViewRow row = (GridViewRow)ib.NamingContainer;

                if (row != null)
                {

                    string xpaper1 = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblPaper")).Text.ToString();
                    string xsubject1 = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblSubject")).Text.ToString();
                    //string xext1 = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblExtension")).Text.ToString();
                    string xext1 = "";
                    string xbest1 = ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString();
                    //string xperc1 = ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString();
                    string xperc1 = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString();
                    string xperc_weight = ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString();



                    #region Check for approval
                    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //{
                    //    using (DataSet dts1 = new DataSet())
                    //    {
                           
                    //        string query =
                    //       "select xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and " +
                    //       "amexamh.xsection=mscodesam.xcode " +
                    //       "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and " +
                    //       "xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper  " +
                    //       "group by xsection  order by min(cast(xcodealt as int))";

                    //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                    //        da1.Fill(dts1, "tempztcode");
                    //        DataTable dtamexamh = new DataTable();
                    //        dtamexamh = dts1.Tables[0];

                    //        if (dtamexamh.Rows.Count > 0)
                    //        {
                    //            string subj = "";
                    //            //if (xpaper1 == "")
                    //            //{
                    //            //    subj = xsubject1;
                    //            //}
                    //            //else
                    //            //{
                    //            //    subj = xsubject1 + "-" + xpaper1;
                    //            //}

                    //            if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    //            {
                    //                subj = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                    //            }
                    //            else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    //            {
                    //                subj = xsubject1 + "-" + xpaper1;
                    //            }
                    //            else if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 == "" || xpaper1 == String.Empty))
                    //            {
                    //                subj = xsubject1 + "(" + xext1 + ")";
                    //            }
                    //            else
                    //            {
                    //                subj = xsubject1;
                    //            }


                    //            message.InnerHtml = "Please check for approval.<br/>Subject : " + subj + "<br/>Section : ";
                    //            int h = 0;
                    //            foreach (DataRow val in dtamexamh.Rows)
                    //            {
                    //                if (h == dtamexamh.Rows.Count - 1)
                    //                {
                    //                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ". ";
                    //                }
                    //                else
                    //                {
                    //                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ", ";
                    //                }

                    //                h = h + 1;

                    //            }
                    //            message.Style.Value = zglobal.am_warningmsg;

                    //            result.Visible = false;
                    //            barchart.Visible = false;
                    //            return;
                    //        }

                    //    }
                    //}

                    if (ViewState["amexamh10"] != null)
                    {
                        DataRow[] amexamh10 =
                          ((DataTable)ViewState["amexamh10"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
                        string subj = "";
                        //if (xpaper1 == "")
                        //{
                        //    subj = xsubject1;
                        //}
                        //else
                        //{
                        //    subj = xsubject1 + "-" + xpaper1;
                        //}
                        if (amexamh10.Length > 0)
                        {
                            if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                            {
                                subj = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                            }
                            else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                            {
                                subj = xsubject1 + "-" + xpaper1;
                            }
                            else if ((xext1 != "" || xext1 != String.Empty) &&
                                     (xpaper1 == "" || xpaper1 == String.Empty))
                            {
                                subj = xsubject1 + "(" + xext1 + ")";
                            }
                            else
                            {
                                subj = xsubject1;
                            }


                            message.InnerHtml = "Please check for approval.<br/>Subject : " + subj + "<br/>Section : ";
                            int h = 0;
                            foreach (DataRow val in amexamh10)
                            {
                                if (h == amexamh10.Length - 1)
                                {
                                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ". ";
                                }
                                else
                                {
                                    message.InnerHtml = message.InnerHtml + val[0].ToString() + ", ";
                                }

                                h = h + 1;

                            }
                            message.Style.Value = zglobal.am_warningmsg;

                            result.Visible = false;
                            barchart.Visible = false;
                            return;
                        }
                    }

#endregion

#region Construct Table
                    //result.Visible = true;
                    //barchart.Visible = true;


                    //DataRow[] result10 =
                    //       ((DataTable)ViewState["amexamh"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");



                    //if (xpaper1 == "")
                    //{
                    //    xsubject.Text = xsubject1;
                    //}
                    //else
                    //{
                    //    xsubject.Text = xsubject1 + "-" + xpaper1;
                    //}

                    ////if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    ////{
                    ////    xsubject.Text = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                    ////}
                    ////else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                    ////{
                    ////    xsubject.Text = xsubject1 + "-" + xpaper1;
                    ////}
                    ////else if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 == "" || xpaper1 == String.Empty))
                    ////{
                    ////    xsubject.Text = xsubject1 + "(" + xext1 + ")";
                    ////}
                    ////else
                    ////{
                    ////    xsubject.Text = xsubject1;
                    ////}

                    //if (xbest1 != "" && result10.Length>0)
                    //{
                    //    xbest.Text = xbest1;

                    //    if (xperc1 != "")
                    //    {
                    //        xbest.Text = xbest1 + " out of " + result10[0]["best1"].ToString() + " (" + xperc1 + "%)";
                    //    }
                    //}
                    //else
                    //{
                    //    xbest.Text = "";
                    //}

                    //int ts = 0;
                    ////using (SqlConnection con = new SqlConnection(zglobal.constring))
                    ////{
                    ////    using (DataSet dts1 = new DataSet())
                    ////    {
                    ////        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    ////        //string query =
                    ////        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    ////        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    ////        string query =
                    ////       "select count(xstdid) from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession  ";

                    ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                    ////        da1.Fill(dts1, "tempztcode");
                    ////        DataTable dtamexamd = new DataTable();
                    ////        dtamexamd = dts1.Tables[0];

                    ////        xnostd.Text = dtamexamd.Rows[0][0].ToString();
                    ////        ts = Convert.ToInt32(dtamexamd.Rows[0][0].ToString());

                    ////    }
                    ////} ViewState["amstudentvw1"]

                    //DataRow[] amstudentvw1 =
                    //       ((DataTable)ViewState["amstudentvw1"]).Select();
                    //xnostd.Text = amstudentvw1[0][0].ToString();
                    //ts = Convert.ToInt32(amstudentvw1[0][0].ToString());

                    ////using (SqlConnection con = new SqlConnection(zglobal.constring))
                    ////{
                    ////    using (DataSet dts1 = new DataSet())
                    ////    {
                    ////        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    ////        //string query =
                    ////        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    ////        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    ////        string query =
                    ////       "select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
                    ////       " except " +
                    ////       "select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                    ////       " and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper  " +
                    ////       "and  xgetmark<>-1 and  coalesce(xna,0) <> 1";

                    ////        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    ////        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                    ////        da1.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                    ////        da1.Fill(dts1, "tempztcode");
                    ////        DataTable dtamexamd = new DataTable();
                    ////        dtamexamd = dts1.Tables[0];

                    ////        if (dtamexamd.Rows.Count > 0)
                    ////        {
                    ////            xabsent.Text = dtamexamd.Rows.Count.ToString();
                    ////            xtaken.Text = (ts - dtamexamd.Rows.Count).ToString();
                    ////        }
                    ////        else
                    ////        {
                    ////            xabsent.Text = "0";
                    ////            xtaken.Text = ts.ToString();
                    ////        }

                    ////    }
                    ////}

                    //if (ViewState["amstd2"] != null && ViewState["amstd1"] != null)
                    //{
                    //    var query1 = from row4 in ((DataTable)ViewState["amstd2"]).AsEnumerable()
                    //                 where row4.Field<string>("xsubject")==xsubject1 &&  row4.Field<string>("xpaper")==xpaper1  
                    //                 select new
                    //                 {
                    //                     xstdid = row4.Field<string>("xstdid")
                    //                 };
                    //    var query2 = from row5 in ((DataTable)ViewState["amstd1"]).AsEnumerable()
                    //                 select new
                    //                 {
                    //                     xstdid = row5.Field<string>("xstdid")
                    //                 };

                    //    var std = query2.Except(query1);

                    //    if (std.Count() > 0)
                    //    {
                    //        xabsent.Text = std.Count().ToString();
                    //        xtaken.Text = (ts - std.Count()).ToString();
                    //    }
                    //    else
                    //    {
                    //        xabsent.Text = "0";
                    //        xtaken.Text = ts.ToString();
                    //    }

                    //}
                    //else
                    //{
                    //    xabsent.Text = "0";
                    //    xtaken.Text = ts.ToString();
                    //}

#endregion

                    //if (xbest1 != "" && xperc1 != "" && xperc_weight!="")
                    if (xperc1 != "" && xperc_weight != "")
                    {
                        using (SqlConnection con = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts1 = new DataSet())
                            {
                                //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                                //string query =
                                //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                                //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                                // string query =
                                //"select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
                                //" except " +
                                //"select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                                //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and  xgetmark<>-1";

                                //string query = "select grade,count(*) as nostd from " +
                                //    "(select xsrow,SUM(case when xbest=-1 then 0 else xbest end) as xgetmark,SUM(xmarks) as xmark, " +
                                //    "(SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks)) as xperc, " +
                                //    "((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) as xperc1, " +
                                //    " (select xgrade from amgradeconf where ((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) >=xmin and " +
                                //    " ((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) <=xmax and " +
                                //    "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //    "(select max(xdate) from amexamh where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper )  )) as grade " +
                                //    "from amexammaxmarkvw3 " +
                                //    " where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and xid <=@xid and xbestflag=1 " +
                                //    "group by xsrow) tbl " +
                                //"group by grade";

                                //         string query = "select grade,count(*) as nostd from " +
                                //    "(select xsrow,SUM(case when xbest=-1 then 0 else xbest end) as xgetmark,SUM(xmarks) as xmark, " +
                                //    "(SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks)) as xperc, " +
                                //    "((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc) as xperc1, " +
                                //    " (select xgrade from amgradeconf where round(((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc),0) >=xmin and " +
                                //    " round(((SUM(case when xbest=-1 then 0 else xbest end)*@perc/SUM(xmarks))*100/@perc),0) <=xmax and " +
                                //    "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //    "(select max(xdate) from amexamh where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper )  )) as grade " +
                                //    "from amexammaxmarkvw3 " +
                                //    " where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //    "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and xid <=@xid and xbestflag=1 " +
                                //    "group by xsrow) tbl " +
                                //"group by grade";

                                string query = "";

                                //query = "select * from amexamhh where zid=@zid and xsession=@xsession and xterm=@xterm and " +
                                //        "xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject " +
                                //        "and xpaper=@xpaper and xtype='Class Test' and xstatus in ('New','Approved3')";

                                //SqlDataAdapter da11 = new SqlDataAdapter(query, con);
                                //da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                                //da11.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //da11.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //da11.SelectCommand.Parameters.AddWithValue("@xext", xext1);

                                //dts1.Reset();
                                //da11.Fill(dts1, "tempztcode");
                                //DataTable dtamexamhh = new DataTable();
                                //dtamexamhh = dts1.Tables[0];
                                //int isAccess = 0;
                                //if (ViewState["dtamexamhh10"] != null)
                                //{
                                //    DataRow[] dtamexamhh10 =
                                //        ((DataTable) ViewState["dtamexamhh10"]).Select("xsubject='" + xsubject1 +
                                //                                                       "' and xpaper='" + xpaper1 + "'");
                                //    if (dtamexamhh10.Length > 0)
                                //    {
                                //        isAccess = 0;
                                //    }
                                //    else
                                //    {
                                //        isAccess = 1;
                                //    }
                                //}

                                #region Insert into amexamhh
                                //if (isAccess == 1)
                                //{
                                //    //int flag = 0;

                                //    //int RowSpan1 = 2;
                                //    //int RowSpan2 = 2;

                                //    //string perc = "";
                                //    //string perc1 = "";
                                //    //List<int> listcount = new List<int>();
                                //    //for (int i = 0; i <= GridView1.Rows.Count - 2; i++)
                                //    //{

                                //    //    GridViewRow currRow = GridView1.Rows[i];
                                //    //    GridViewRow nextRow = GridView1.Rows[i + 1];

                                //    //    Label txt1 = currRow.Cells[1].FindControl("txtSubject") as Label;
                                //    //    Label txt2 = nextRow.Cells[1].FindControl("txtSubject") as Label;

                                //    //    Label lblpap1 = currRow.Cells[2].FindControl("txtPaper") as Label;
                                //    //    Label lblpap2 = nextRow.Cells[2].FindControl("txtPaper") as Label;

                                //    //    Label lblext1 = currRow.Cells[2].FindControl("txtExtension") as Label;
                                //    //    Label lblext2 = nextRow.Cells[2].FindControl("txtExtension") as Label;

                                //    //    xext1 = lblext1.Text;

                                //    //    DropDownList dlistBest1 = currRow.FindControl("dlistBest") as DropDownList;
                                //    //    //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                                //    //    TextBox txtWeight1 = currRow.FindControl("txtWeight") as TextBox;
                                //    //    TextBox dlistPerc1 = currRow.FindControl("dlistPerc") as TextBox;

                                //    //    DropDownList dlistBest2 = nextRow.FindControl("dlistBest") as DropDownList;
                                //    //    //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                                //    //    TextBox txtWeight2 = nextRow.FindControl("txtWeight") as TextBox;
                                //    //    TextBox dlistPerc2 = nextRow.FindControl("dlistPerc") as TextBox;
                                //    //    if (txt1.Text == xsubject1 && lblpap1.Text == xpaper1)
                                //    //    {
                                //    //        if (txt1.Text == txt2.Text)
                                //    //        {
                                //    //            if (lblpap1.Text == lblpap2.Text)
                                //    //            {
                                //    //                if (RowSpan2 == 2)
                                //    //                {
                                //    //                    perc = dlistPerc1.Text.Trim().ToString();
                                //    //                }

                                //    //                ((TextBox)nextRow.FindControl("dlistPerc")).Text = perc.ToString();


                                //    //                RowSpan2 += 1;
                                //    //            }
                                //    //            else
                                //    //            {
                                //    //                RowSpan2 = 2;
                                //    //            }




                                //    //            RowSpan1 += 1;

                                //    //        }
                                //    //        else
                                //    //        {
                                //    //            //listcount.Add(RowSpan);
                                //    //            RowSpan1 = 2;
                                //    //            RowSpan2 = 2;
                                //    //        }
                                //    //    }


                                //    //}



                                //    string xstatus;

                                //    using (TransactionScope tran = new TransactionScope())
                                //    {
                                //        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                                //        {
                                //            conn.Open();
                                //            SqlCommand cmd = new SqlCommand();
                                //            //SqlTransaction tran;
                                //            //tran = conn.BeginTransaction("SampleTransaction");

                                //            cmd.Connection = conn;
                                //            //cmd.Transaction = tran;
                                //            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                                //            string zemail1t = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //            DateTime ztime1t = DateTime.Now;
                                //            xstatus = "Test";

                                //            query =
                                //                                "UPDATE amexamvw set amexamvw.xbflag=0  " +
                                //                                "WHERE amexamvw.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                                " AND xsubject=@xsubject AND xpaper=@xpaper  and xtype='Class Test'";

                                //            cmd.Parameters.Clear();
                                //            cmd.CommandTimeout = 0;
                                //            cmd.CommandText = query;
                                //            cmd.Parameters.AddWithValue("@zid", _zid);
                                //            //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //            //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //            //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //            //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //            //cmd.Parameters.AddWithValue("@xid", _xid);
                                //            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //            cmd.Parameters.AddWithValue("@xext", xext1);
                                //            cmd.ExecuteNonQuery();

                                //            DataTable dtamexamh;

                                //            using (SqlConnection con1t = new SqlConnection(zglobal.constring))
                                //            {
                                //                using (DataSet dts1t = new DataSet())
                                //                {

                                //           //         query =
                                //           //"select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                                //           //"where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                                //           //"and xsubject=@xsubject and xpaper=@xpaper  " +
                                //           //"group by xsubject,xpaper,xext,xsection  order by min(cast(xcodealt as int))";

                                //     //               query =
                                //     //"select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh " +
                                //     //"where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                                //     //"and xsubject=@xsubject and xpaper=@xpaper  " +
                                //     //"group by xsubject,xpaper,xext,xsection  )";

                                //     //               SqlDataAdapter da1t = new SqlDataAdapter(query, con1t);
                                //     //               da1t.SelectCommand.CommandTimeout = 0;
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //     //               da1t.SelectCommand.Parameters.AddWithValue("@xext", xext1);
                                //     //               //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //     //               //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                //     //               da1t.Fill(dts1t, "tempztcode");
                                //     //               dtamexamh = new DataTable();
                                //     //               dtamexamh = dts1t.Tables[0];

                                //                    if (ViewState["dtamexamh123"] != null)
                                //                    {
                                //                        DataRow[] dtamexamh123 =
                                //                            ((DataTable) ViewState["dtamexamh123"]).Select(
                                //                                "xsubject='" + xsubject1 +
                                //                                "' and xpaper='" + xpaper1 + "'");
                                //                        if (dtamexamh123.Length > 0)
                                //                        {
                                //                            //ViewState["amexamh1t"] = dtamexamh123;
                                //                            ViewState["amexamh1t"] = ViewState["dtamexamh123"];
                                //                            //message.InnerHtml = "yes";
                                //                            //return;
                                //                        }
                                //                        else
                                //                        {
                                //                            ViewState["amexamh1t"] = null;
                                //                            //message.InnerHtml = "no";
                                //                            //return;
                                //                        }

                                //                    }
                                //                    else
                                //                    {
                                //                        ViewState["amexamh1t"] = null;
                                //                        //message.InnerHtml = "no";
                                //                        //return;
                                //                    }

                                //                }
                                //            }


                                //            if (ViewState["amexamh1t"] != null)
                                //            //if (dtamexamh.Rows.Count > 0)
                                //            {

                                //                foreach (GridViewRow row1 in GridView1.Rows)
                                //                {
                                //                    //string xpaper1t = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                //                    //string xsubject1t = ((Label)row1.FindControl("lblSubject")).Text.ToString();
                                //                    //string xext1t = ((Label)row1.FindControl("lblExtension")).Text.ToString();
                                //                    //int _xid = Convert.ToInt32(((DropDownList)row1.FindControl("dlistBest")).Text.ToString() == "" ? "0" : ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                                    
                                //                    string xpaper1t = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblPaper")).Text.ToString();
                                //                    string xsubject1t = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblSubject")).Text.ToString();
                                //                    string xext1t = ((Label)GridView1.Rows[row.RowIndex].FindControl("lblExtension")).Text.ToString();
                                //                    int _xid = Convert.ToInt32(((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == "" ? "0" : ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString());





                                //                    //query =
                                //                    //        "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
                                //                    //        "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
                                //                    //        "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
                                //                    //        "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                    //        "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

                                //                    //cmd.Parameters.Clear();
                                //                    //cmd.CommandTimeout = 0;
                                //                    //cmd.CommandText = query;
                                //                    //cmd.Parameters.AddWithValue("@zid", _zid);
                                //                    ////cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                    ////cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                    ////cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                    ////cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                    //cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                    //cmd.Parameters.AddWithValue("@xid", _xid);
                                //                    //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                    //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                    //cmd.Parameters.AddWithValue("@xext", xext1t);
                                //                    //cmd.ExecuteNonQuery();

                                //                    if (xpaper1t == xpaper1 && xsubject1t == xsubject1)
                                //                    {

                                //                        query =
                                //                            "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
                                //                            "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
                                //                            "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
                                //                            "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                            "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

                                //                        cmd.Parameters.Clear();
                                //                        cmd.CommandTimeout = 0;
                                //                        cmd.CommandText = query;
                                //                        cmd.Parameters.AddWithValue("@zid", _zid);
                                //                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                        cmd.Parameters.AddWithValue("@xid", _xid);
                                //                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                        cmd.Parameters.AddWithValue("@xext", xext1t);
                                //                        cmd.ExecuteNonQuery();



                                //                        DataRow[] result600 = ((DataTable)ViewState["amexamh1t"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1t + "'");
                                //                        //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                //                        if (result600.Length > 0)
                                //                        {
                                //                            foreach (DataRow row2 in result600)
                                //                            {


                                //                                //query =
                                //                                //        "DELETE FROM amexamhh " +
                                //                                //        "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                //                                //        "AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test' and xstatus='Test' and xtype1='Subject Extension'";

                                //                                //cmd.Parameters.Clear();

                                //                                //cmd.CommandText = query;
                                //                                //cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                ////cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //                                ////cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                ////cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //                                ////cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                //                                //cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                //cmd.Parameters.AddWithValue("@xid", _xid);
                                //                                //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                //cmd.Parameters.AddWithValue("@xext", xext1);
                                //                                //cmd.ExecuteNonQuery();

                                //                                string xsection1t = row2["xsection"].ToString();


                                //                                query =
                                //                                    "delete from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                    "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension' and xstatus='Test'";

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;
                                //                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection1t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                cmd.Parameters.AddWithValue("@xext", xext1t);
                                                                
                                //                                cmd.ExecuteNonQuery();


                                //                                //query =
                                //                                //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xapproved1by,xapproved1dt) " +
                                //                                //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xapproved1by,@xapproved1dt) ";

                                //                                // query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test') " +
                                //                                //"UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xapproved1by=@xapproved1by,xapproved1dt=@xapproved1dt,xstatus=@xstatus " +
                                //                                //"where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' " +
                                //                                // "ELSE " +
                                //                                // "INSERT INTO amexamhh (zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,xapproved1by,xapproved1dt) " +
                                //                                // "VALUES(@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@xapproved1by,@xapproved1dt) ";

                                //                                //query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension' and xstatus='Test') " +
                                //                                //"UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xstatus=@xstatus " +
                                //                                //"where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1=@xtype1 " +
                                //                                //"ELSE " +
                                //                                query = "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";



                                //                                // query = 
                                //                                //"INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                //"VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";



                                //                                int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                //                                string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                                //                                string xapproved1by =
                                //                                    Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                DateTime xapproved1dt = DateTime.Now;
                                //                                DateTime ztime1 = DateTime.Now;

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;
                                //                                cmd.Parameters.AddWithValue("@ztime", ztime1);
                                //                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection1t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                //                                cmd.Parameters.AddWithValue("@xext", xext1t);
                                //                                cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                //                                cmd.Parameters.AddWithValue("@xtbest",
                                //                                    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xperc",
                                //                                    ((TextBox)row1.FindControl("txtWeight")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                cmd.Parameters.AddWithValue("@zemail", zemail);
                                //                                cmd.Parameters.AddWithValue("@xapproved1by", xapproved1by);
                                //                                cmd.Parameters.AddWithValue("@xapproved1dt", xapproved1dt);
                                //                                cmd.Parameters.AddWithValue("@xtype1", "Subject Extension");
                                //                                cmd.ExecuteNonQuery();


                                //                            }
                                //                        }
                                //                    }

                                //                }
                                //            }

                                //            using (SqlConnection con2t = new SqlConnection(zglobal.constring))
                                //            {
                                //                using (DataSet dts12t = new DataSet())
                                //                {

                                //           //         query =
                                //           //"select xsubject,xpaper,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                                //           //"where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                                //           //"group by xsubject,xpaper,xsection  order by min(cast(xcodealt as int))";

                                //           //         SqlDataAdapter da12t = new SqlDataAdapter(query, con2t);
                                //           //         da12t.SelectCommand.CommandTimeout = 0;
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //           //         da12t.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //           //         //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                //           //         da12t.Fill(dts12t, "tempztcode");
                                //           //         dtamexamh = new DataTable();
                                //           //         dtamexamh = dts12t.Tables[0];
                                //                    if (ViewState["dtamexamh124"] != null)
                                //                    {
                                //                        DataRow[] dtamexamh124 =
                                //                            ((DataTable)ViewState["dtamexamh124"]).Select(
                                //                                "xsubject='" + xsubject1 +
                                //                                "' and xpaper='" + xpaper1 + "'");
                                //                        if (dtamexamh124.Length > 0)
                                //                        {
                                //                            //ViewState["amexamh1t"] = dtamexamh123;
                                //                            ViewState["amexamh2t"] = ViewState["dtamexamh124"];
                                //                            //message.InnerHtml = "yes";
                                //                            //return;
                                //                        }
                                //                        else
                                //                        {
                                //                            ViewState["amexamh2t"] = null;
                                //                            //message.InnerHtml = "no";
                                //                            //return;
                                //                        }

                                //                    }
                                //                    else
                                //                    {
                                //                        ViewState["amexamh2t"] = null;
                                //                        //message.InnerHtml = "no";
                                //                        //return;
                                //                    }
                                                    

                                //                }
                                //            }

                                //            if (ViewState["amexamh2t"] != null)
                                //            {

                                //                foreach (GridViewRow row1 in GridView1.Rows)
                                //                {
                                //                    string xpaper12t = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                //                    string xsubject12t = ((Label)row1.FindControl("lblSubject")).Text.ToString();



                                //                    if (xpaper12t == xpaper1 && xsubject12t == xsubject1)
                                //                    {
                                //                        DataRow[] result60000 = ((DataTable)ViewState["amexamh2t"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
                                //                        //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                //                        if (result60000.Length > 0)
                                //                        {
                                //                            foreach (DataRow row2 in result60000)
                                //                            {
                                //                                string xsection12t = row2["xsection"].ToString();

                                //                                query = "delete from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                           "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test' and xstatus='Test'";

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;

                                //                                cmd.Parameters.AddWithValue("@zid", _zid);

                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection12t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject12t);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper12t);
                                                                
                                //                                cmd.ExecuteNonQuery();

                                //                                //query =
                                //                                //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
                                //                                //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

                                //                                //query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //        "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test' and xstatus='Test') " +
                                //                                //        "UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xstatus=@xstatus " +
                                //                                //        "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                //        "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' and xtype1=@xtype1 " +
                                //                                //        "ELSE " +
                                //                                query = "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                        "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

                                //                                //query = 
                                //                                //        "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                //                                //        "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";



                                //                                int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                //                                string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);


                                //                                string xapproved1by = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                //                                DateTime xapproved1dt = DateTime.Now;
                                //                                DateTime ztime1 = DateTime.Now;
                                //                                DateTime zutime1 = DateTime.Now;

                                //                                cmd.Parameters.Clear();
                                //                                cmd.CommandTimeout = 0;
                                //                                cmd.CommandText = query;
                                //                                cmd.Parameters.AddWithValue("@ztime", ztime1);
                                //                                cmd.Parameters.AddWithValue("@zutime", zutime1);
                                //                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //                                cmd.Parameters.AddWithValue("@xrow", xrow);
                                //                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //                                cmd.Parameters.AddWithValue("@xsection", xsection12t);
                                //                                cmd.Parameters.AddWithValue("@xsubject", xsubject12t);
                                //                                cmd.Parameters.AddWithValue("@xpaper", xpaper12t);
                                //                                cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                //                                //cmd.Parameters.AddWithValue("@xtbest",
                                //                                //    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xtbest",
                                //                                   0);
                                //                                cmd.Parameters.AddWithValue("@xperc",
                                //                                    ((TextBox)row1.FindControl("dlistPerc")).Text.ToString());
                                //                                cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //                                cmd.Parameters.AddWithValue("@zemail", zemail);
                                //                                cmd.Parameters.AddWithValue("@xemail", xemail);
                                //                                cmd.Parameters.AddWithValue("@xapproved1by", xapproved1by);
                                //                                cmd.Parameters.AddWithValue("@xapproved1dt", xapproved1dt);
                                //                                cmd.Parameters.AddWithValue("@xtype1", "Class Test");
                                //                                cmd.ExecuteNonQuery();



                                //                            }
                                //                        }
                                //                    }


                                //                }
                                //            }

                                //            // tran.Commit();
                                //        }

                                //        tran.Complete();
                                //    }
                                //}
                                #endregion


                               #region insert into amexamhh2


//                                string xstatus;

//                                using (TransactionScope tran = new TransactionScope())
//                                {
//                                    using (SqlConnection conn1 = new SqlConnection(zglobal.constring))
//                                    {
//                                        conn1.Open();
//                                        SqlCommand cmd = new SqlCommand();

//                                        cmd.Connection = conn1;

//                                        string xapproved3by = Convert.ToString(HttpContext.Current.Session["curuser"]);
//                                        DateTime xapproved3dt = DateTime.Now;
//                                        xstatus = "New";





//                                        query =
//                                                "UPDATE amexamvw set amexamvw.xbflag=0  " +
//                                                "WHERE amexamvw.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
//                                                "and xsubject=@xsubject and xpaper=@xpaper  " +
//                                                "and xtype='Class Test'";

//                                        cmd.Parameters.Clear();

//                                        cmd.CommandText = query;
//                                        cmd.Parameters.AddWithValue("@zid", _zid);
//                                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
//                                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
//                                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
//                                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
//                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                                        //cmd.Parameters.AddWithValue("@xid", _xid);
//                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
//                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
//                                        //cmd.Parameters.AddWithValue("@xext", xext1);
//                                        cmd.ExecuteNonQuery();



//                                        query =
//                                                "DELETE FROM amexamhh " +
//                                                "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
//                                                "and xtype='Class Test' and xstatus='Test' and xsubject=@xsubject and xpaper=@xpaper ";

//                                        cmd.Parameters.Clear();

//                                        cmd.CommandText = query;
//                                        cmd.Parameters.AddWithValue("@zid", _zid);
//                                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
//                                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
//                                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
//                                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
//                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                                        //cmd.Parameters.AddWithValue("@xid", _xid);
//                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
//                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
//                                        //cmd.Parameters.AddWithValue("@xext", xext1);
//                                        cmd.ExecuteNonQuery();

//                                        DataTable dtamexamh;

//                                        using (SqlConnection con1 = new SqlConnection(zglobal.constring))
//                                        {
//                                            using (DataSet dts11 = new DataSet())
//                                            {

//                                                query =
//                                       "select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh  " +
//                                       "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and " +
//                                       "xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper  " +
//                                       "group by xsubject,xpaper,xext,xsection ";

//                                                SqlDataAdapter da11 = new SqlDataAdapter(query, con1);
//                                                da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
//                                                da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
//                                                da11.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
//                                                //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
//                                                //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

//                                                da11.Fill(dts11, "tempztcode");
//                                                dtamexamh = new DataTable();
//                                                dtamexamh = dts11.Tables[0];

//                                                if (dtamexamh.Rows.Count > 0)
//                                                {
//                                                    ViewState["amexamh1"] = dtamexamh;
//                                                    //message.InnerHtml = "yes";
//                                                    //return;
//                                                }
//                                                else
//                                                {
//                                                    ViewState["amexamh1"] = null;
//                                                    //message.InnerHtml = "no";
//                                                    //return;
//                                                }

//                                            }
//                                        }

//                                        if (ViewState["amexamh1"] != null)
//                                        //if (dtamexamh.Rows.Count > 0)
//                                        {

//                                            //foreach (GridViewRow row1 in GridView1.Rows)
//                                            //{
//                                            //    string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
//                                            //    string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();
//                                            //    string xext1 = ((Label)row1.FindControl("lblExtension")).Text.ToString();

//                                            int _xid = Convert.ToInt32(((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == "" ? "0" : ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString());


//                                                query =
//                                                    "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
//                                                    "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
//                                                    "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
//                                                    "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
//                                                    "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

//                                                cmd.Parameters.Clear();

//                                                cmd.CommandText = query;
//                                                cmd.Parameters.AddWithValue("@zid", _zid);
//                                                //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
//                                                //cmd.Parameters.AddWithValue("@xstatus", xstatus);
//                                                //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
//                                                //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
//                                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                                                cmd.Parameters.AddWithValue("@xid", _xid);
//                                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
//                                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
//                                                cmd.Parameters.AddWithValue("@xext", xext1);
//                                                cmd.ExecuteNonQuery();



//                                                DataRow[] result60 = ((DataTable)ViewState["amexamh1"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");
//                                                //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

//                                                if (result60.Length > 0)
//                                                {
//                                                    foreach (DataRow row2 in result60)
//                                                    {
//                                                        string xsection1 = row2["xsection"].ToString();


//                                                        //query =
//                                                        //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
//                                                        //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

//                                                        query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
//                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension') " +
//                                                                "UPDATE amexamhh SET zutime=@zutime,xtbest=@xtbest,xperc=@xperc,xemail=@xemail " +
//                                                                "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
//                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1=@xtype1 " +
//                                                                "ELSE " +
//                                                                "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
//                                                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

//                                                        int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
//                                                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
//                                                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



//                                                        DateTime ztime1 = DateTime.Now;
//                                                        DateTime zutime1 = DateTime.Now;

//                                                        cmd.Parameters.Clear();

//                                                        cmd.CommandText = query;
//                                                        cmd.Parameters.AddWithValue("@ztime", ztime1);
//                                                        cmd.Parameters.AddWithValue("@zutime", zutime1);
//                                                        cmd.Parameters.AddWithValue("@zid", _zid);
//                                                        cmd.Parameters.AddWithValue("@xrow", xrow);
//                                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xsection", xsection1);
//                                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
//                                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
//                                                        cmd.Parameters.AddWithValue("@xext", xext1);
//                                                        cmd.Parameters.AddWithValue("@xtype", "Class Test");
//                                                        cmd.Parameters.AddWithValue("@xtbest",
//                                                            ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == "" ||
//                                                            ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString() == String.Empty
//                                                            ? "0" :
//                                                            ((DropDownList)GridView1.Rows[row.RowIndex].FindControl("dlistBest")).Text.ToString());
//                                                        cmd.Parameters.AddWithValue("@xperc",
//                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString() == "" ||
//                                                         ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString() == String.Empty
//                                                         ? "0" :
//                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("txtWeight")).Text.ToString());
//                                                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
//                                                        cmd.Parameters.AddWithValue("@zemail", zemail);
//                                                        cmd.Parameters.AddWithValue("@xemail", xemail);
//                                                        cmd.Parameters.AddWithValue("@xtype1", "Subject Extension");
//                                                        cmd.ExecuteNonQuery();



//                                                    }
//                                                }
//                                            //}
//                                        }


//                                        using (SqlConnection con1 = new SqlConnection(zglobal.constring))
//                                        {
//                                            using (DataSet dts11 = new DataSet())
//                                            {

//                                                query =
//                                       "select xsubject,xpaper,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
//                                       "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test' and xsubject=@xsubject and xpaper=@xpaper " +
//                                       "group by xsubject,xpaper,xsection  order by min(cast(xcodealt as int))";

//                                                SqlDataAdapter da11 = new SqlDataAdapter(query, con1);
//                                                da11.SelectCommand.Parameters.AddWithValue("@zid", _zid);
//                                                da11.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                                                da11.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
//                                                da11.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
//                                                //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
//                                                //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

//                                                da11.Fill(dts11, "tempztcode");
//                                                dtamexamh = new DataTable();
//                                                dtamexamh = dts11.Tables[0];

//                                                if (dtamexamh.Rows.Count > 0)
//                                                {
//                                                    ViewState["amexamh2"] = dtamexamh;
//                                                    //message.InnerHtml = "yes";
//                                                    //return;
//                                                }
//                                                else
//                                                {
//                                                    ViewState["amexamh2"] = null;
//                                                    //message.InnerHtml = "no";
//                                                    //return;
//                                                }

//                                            }
//                                        }

//                                        if (ViewState["amexamh2"] != null)
//                                        {

//                                            //foreach (GridViewRow row1 in GridView1.Rows)
//                                            //{
//                                            //    string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
//                                            //    string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();





//                                                DataRow[] result60 = ((DataTable)ViewState["amexamh2"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
//                                                //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

//                                                if (result60.Length > 0)
//                                                {
//                                                    foreach (DataRow row2 in result60)
//                                                    {
//                                                        string xsection1 = row2["xsection"].ToString();


//                                                        //query =
//                                                        //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
//                                                        //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

//                                                        query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
//                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test') " +
//                                                                "UPDATE amexamhh SET zutime=@zutime,xtbest=@xtbest,xperc=@xperc,xemail=@xemail " +
//                                                                "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
//                                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' and xtype1=@xtype1 " +
//                                                                "ELSE " +
//                                                                "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
//                                                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

//                                                        int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
//                                                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
//                                                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



//                                                        DateTime ztime1 = DateTime.Now;
//                                                        DateTime zutime1 = DateTime.Now;

//                                                        cmd.Parameters.Clear();

//                                                        cmd.CommandText = query;
//                                                        cmd.Parameters.AddWithValue("@ztime", ztime1);
//                                                        cmd.Parameters.AddWithValue("@zutime", zutime1);
//                                                        cmd.Parameters.AddWithValue("@zid", _zid);
//                                                        cmd.Parameters.AddWithValue("@xrow", xrow);
//                                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
//                                                        cmd.Parameters.AddWithValue("@xsection", xsection1);
//                                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
//                                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
//                                                        cmd.Parameters.AddWithValue("@xtype", "Class Test");
//                                                        //cmd.Parameters.AddWithValue("@xtbest",
//                                                        //    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
//                                                        cmd.Parameters.AddWithValue("@xtbest",
//                                                           0);
//                                                        cmd.Parameters.AddWithValue("@xperc",
//                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString() == "" ||
//                                                        ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString() == string.Empty
//                                                        ? "0" :
//                                                            ((TextBox)GridView1.Rows[row.RowIndex].FindControl("dlistPerc")).Text.ToString());
//                                                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
//                                                        cmd.Parameters.AddWithValue("@zemail", zemail);
//                                                        cmd.Parameters.AddWithValue("@xemail", xemail);
//                                                        cmd.Parameters.AddWithValue("@xtype1", "Class Test");
//                                                        cmd.ExecuteNonQuery();



//                                                    }
//                                                }
//                                            //}
//                                        }



//                                        // tran.Commit();
//                                    }

//                                    tran.Complete();
//                                }


#endregion insert into amexamhh2

                                //query = "select grade,count(*) as nostd from " +
                                //               "(select b.xsrow,SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end) as xgetmark,SUM(xmarks) as xmark, " +

                                //               "(SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks)) as xperc, " +
                                //               "((SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks))*100/@perc) as xperc1, " +
                                //               "(select xgrade from amgradeconf where round(((SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks))*100/@perc),0) >=xmin and " +
                                //               " round(((SUM(case when amexamvw.xgetmark<0 then 0 else amexamvw.xgetmark end)*@perc/SUM(xmarks))*100/@perc),0) <=xmax and " +
                                //               "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //               "(select max(xdate) from amexamh where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' and xsession=@xsession and " +
                                //               "xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper )  )) as grade " +
                                //               "from amexammaxmarkvw2  as b inner join amexamvw on b.zid=amexamvw.zid and b.xrow=amexamvw.xrow and b.xline=amexamvw.xline and b.xsrow=amexamvw.xsrow " +
                                //               "where b.zid=@zid and xcttype in ('Test','Test (WS)') AND b.xtype='Class Test' and b.xsession=@xsession and " +
                                //               "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper and xid <=1 " +
                                //               "group by b.xsrow) tbl " +
                                //               "group by grade ";

                                //query = "select grade,count(*) as nostd from " +
                                //        "(select *, (select xgrade from amgradeconf where round(xpercexam100,0) >=xmin and " +
                                //        "round(xpercexam100,0) <=xmax and " +
                                //        "xeffdate=(select MAX(xeffdate) from amgradeconf as a where zid=amgradeconf.zid and xeffdate<= " +
                                //        "(select max(xdate) from amexamh where zid=b.zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test' " +
                                //        "and xsession=b.xsession and " +
                                //        "xterm=b.xterm and xclass=b.xclass and xgroup=b.xgroup and xsubject=b.xsubject and xpaper=b.xpaper  ) " +
                                //        "  )) as grade " +
                                //        "from amexamvw_sumext_exam2  as b " +
                                //        "where b.zid=@zid and b.xsession=@xsession and " +
                                //        "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  " +
                                //        ") tbl " +
                                //        "group by grade";

                                //query = "insert into test (zid,xsession,xclass,xterm,xgroup,xsubject,xpaper,xgrade,xcount) " +
                                //        "select zid,xsession,xclass,xterm,xgroup,xsubject,xpaper,xgrade,count(*) as xcount from amexamvw_sumext_exam2_sub " +
                                //        "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                //                                               "and xsubject=@xsubject and xpaper=@xpaper   " +
                                //        "group by zid,xsession,xclass,xterm,xgroup,xsubject,xpaper,xgrade";
                                //SqlCommand cmd123 = new SqlCommand();
                                //con.Open();
                                //cmd123.Connection = con;
                                //cmd123.Parameters.Clear();
                                //cmd123.CommandTimeout = 0;
                                //cmd123.CommandText = query;

                                //cmd123.Parameters.AddWithValue("@zid", _zid);

                                //cmd123.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //cmd123.Parameters.AddWithValue("@xsubject", xsubject1);
                                //cmd123.Parameters.AddWithValue("@xpaper", xpaper1);
                                //cmd123.ExecuteNonQuery();

                                //query = "select xgrade as grade,xcount as nostd from test as b " +
                                //    "where b.zid=@zid and b.xsession=@xsession and " +
                                //      "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  ";

                                ////query = "select xgrade as grade,count(*) as nostd  " +
                                ////        "from  amexamvw_sumext_exam2_sub as b " +
                                ////        "where b.zid=@zid and b.xsession=@xsession and " +
                                ////        "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  " +
                                ////        "group by xgrade";

                                ////query = "select xgrade as grade,count(*) as nostd  " +
                                ////        "from amexamvw_sumext_exam2_sub  as b inner join amstudentvw as a on a.zid=b.zid and a.xsession=b.xsession and a.xrow=b.xsrow " +
                                ////        "where b.zid=@zid and b.xsession=@xsession and " +
                                ////        "b.xterm=@xterm and b.xclass=@xclass and b.xgroup=@xgroup and b.xsubject=@xsubject and b.xpaper=@xpaper  " +
                                ////        "group by xgrade";

                                //SqlDataAdapter da111 = new SqlDataAdapter(query, con);
                                //da111.SelectCommand.CommandTimeout = 0;
                                //da111.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                //da111.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                ////da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                                //da111.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //da111.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                ////da1.SelectCommand.Parameters.AddWithValue("@xid", Convert.ToInt32(xbest1));
                                ////da1.SelectCommand.Parameters.AddWithValue("@perc", Convert.ToInt32(xperc1));

                                //dts1.Reset();
                                //da111.Fill(dts1, "tempztcode");
                                //DataTable dtamexamd = new DataTable();
                                //dtamexamd = dts1.Tables[0];

                                //if (dtamexamd.Rows.Count > 0)
                                //{
                                //    //ViewState["amresult"] = dtamexamd;

                                //    int ctn = 10;
                                //    List<string> gradeList = (List<string>) ViewState["xgrade"];
                                   

                                //    for (int i = 1; i <= Convert.ToInt32(ViewState["noofgrade"].ToString()); i++)
                                //    {
                                //        //if (gradeList[i - 1] == dtamexamd.Rows[0]["xgrade"])
                                //        //{
                                //        //((Label)GridView1.Rows[row.RowIndex].FindControl("lblGrade" + gradeList[i - 1])).Text =
                                //        //    dtamexamd.Rows[0]["xgrade"].ToString();
                                //        //}

                                //        message.InnerHtml = message.InnerHtml + (dtamexamd.Rows[0]["xgrade"] + "\n");
                                //    }
                                //}
                                //else
                                //{
                                //    //ViewState["amresult"] = null;
                                //}

                                string connectionString = zglobal.constring;
                                SqlConnection con123 = new SqlConnection(connectionString);

                                SqlCommand cmd = new SqlCommand("amgradesp", con123);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);

                                con123.Open();
                                SqlDataReader reader = cmd.ExecuteReader();

                                //foreach (var VARIABLE in COLLECTION)
                                //{
                                    
                                //}
                                while (reader.Read())
                                {
                                    //message.InnerHtml = message.InnerHtml + (reader["grade"].ToString() + "\n");
                                    ((TextBox)GridView1.Rows[row.RowIndex].FindControl("lblGrade" + reader["grade"].ToString())).Text = reader["nostd"].ToString();
                                   
                                }

                                con123.Close();

                            }
                        }
                    }

                    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //{
                    //    using (DataSet dts1 = new DataSet())
                    //    {
                    //        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    //        //string query =
                    //        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    //        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    //        // string query =
                    //        //"select xstdid from amstudentvw where zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession " +
                    //        //" except " +
                    //        //"select xstdid from amexamvw where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                    //        //" and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper and  xgetmark<>-1";

                    //        string query =
                    //            "select * from amgradeconf where zid=@zid and xeffdate=(select MAX(xeffdate) from amgradeconf as a " +
                    //            "where zid=amgradeconf.zid and xeffdate<= (select max(xdate) from amexamh " +
                    //            "where zid=@zid and xcttype in ('Test','Test (WS)') AND xtype='Class Test'  " +
                    //            " and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper))";

                    //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xid", Convert.ToInt32(xbest1));
                    //        //da1.SelectCommand.Parameters.AddWithValue("@perc", Convert.ToInt32(xperc1));

                    //        da1.Fill(dts1, "tempztcode");
                    //        DataTable dtamexamd = new DataTable();
                    //        dtamexamd = dts1.Tables[0];

                    //        if (dtamexamd.Rows.Count > 0)
                    //        {
                    //            ViewState["amgrade"] = dtamexamd;
                    //        }
                    //        else
                    //        {
                    //            ViewState["amgrade"] = null;
                    //            message.InnerHtml = "Grading System Not Configured.";
                    //            message.Style.Value = zglobal.am_warningmsg;
                    //        }


                    //    }
                    //}

                    //if (ViewState["amresult"] != null && ViewState["amgrade"] != null)
                    //{

                    //}


                    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //{
                    //    using (DataSet dts1 = new DataSet())
                    //    {
                    //       // //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                    //       // //string query =
                    //       // //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                    //       // //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                    //        string query =
                    //       "select * from amgradeconf where zid=@zid and xeffdate=(select MAX(xeffdate) from amgradeconf as a " +
                    //       " where zid=amgradeconf.zid and xeffdate<= " +
                    //       " (select max(xdate) from amexamh where xcttype in ('Test','Test (WS)') AND xtype='Class Test' and zid=@zid and " +
                    //       " xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup and xsubject=@xsubject and xpaper=@xpaper) " +
                    //       " )";

                    //        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                    //        da1.SelectCommand.CommandTimeout = 0;
                    //        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                    //        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());
                    //        da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                    //        da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);

                    //        da1.Fill(dts1, "tempztcode");
                    //        DataTable dtamexamd = new DataTable();
                    //        dtamexamd = dts1.Tables[0];




                    //        if (dtamexamd.Rows.Count > 0)
                    //        //if (ViewState["dtamexamd200"] != null)
                    //        {
                    //     //       DataRow[] dtamexamd =
                    //     //((DataTable)ViewState["dtamexamd200"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                    //            grade.Controls.Clear();
                    //            colorcode.Controls.Clear();

                    //            HtmlGenericControl table = new HtmlGenericControl("table");
                    //            table.Attributes.Add("style", "width: 100%; border-collapse: collapse; border: none;color: #000000");

                    //            grade.Controls.Add(table);

                    //            HtmlGenericControl table1 = new HtmlGenericControl("table");
                    //            table1.Attributes.Add("style", "width: 100%;  border: 1px solid #FFFFFF; border-spacing: 5px;color: #000000");

                    //            colorcode.Controls.Add(table1);


                    //            Chart1.Series["Series1"].Points.Clear();

                    //            Series series = Chart1.Series["Series1"];

                    //            int count = 1;
                    //            foreach (DataRow _row in dtamexamd.Rows)
                    //            //foreach (DataRow _row in dtamexamd)
                    //            {
                    //                HtmlGenericControl tr = new HtmlGenericControl("tr");
                    //                if (count % 2 != 0)
                    //                {
                    //                    tr.Attributes.Add("style", "background-color: #CEE5B7");
                    //                }
                    //                table.Controls.Add(tr);

                    //                HtmlGenericControl td1 = new HtmlGenericControl("td");
                    //                td1.Attributes.Add("style", "width: 50%; text-align: right; padding-right: 30px;");
                    //                //td1.InnerHtml = dtamexamd.Rows[count - 1]["xcaption"].ToString();
                    //                td1.InnerHtml = _row["xcaption"].ToString();
                    //                tr.Controls.Add(td1);

                    //                HtmlGenericControl td2 = new HtmlGenericControl("td");
                    //                td2.Attributes.Add("style", "width: 20%;");
                    //                //td2.InnerHtml = dtamexamd.Rows[count - 1]["xgrade"].ToString();
                    //                td2.InnerHtml = _row["xgrade"].ToString();
                    //                tr.Controls.Add(td2);

                    //                HtmlGenericControl td3 = new HtmlGenericControl("td");
                    //                td3.Attributes.Add("style", "width: 30%; padding-left: 10px;");
                    //                if (xbest1 != "" && xperc1 != "")
                    //                {
                    //                    if (ViewState["amresult"] != null)
                    //                    {
                    //                        //DataRow[] result20 =
                    //                        //    ((DataTable)ViewState["amresult"]).Select("grade='" + dtamexamd.Rows[count - 1]["xgrade"].ToString() + "'");
                    //                        DataRow[] result20 =
                    //                           ((DataTable)ViewState["amresult"]).Select("grade='" + _row["xgrade"].ToString() + "'");
                    //                        if (result20.Length > 0)
                    //                        {
                    //                            td3.InnerHtml = result20[0][1].ToString();

                    //                            series.Points.AddXY(result20[0][0].ToString(), result20[0][1].ToString());
                    //                            //series.Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
                    //                            //series.Points[count - 1].Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
                    //                            series.Color = ColorTranslator.FromHtml(_row["xcolor"].ToString());
                    //                            series.Points[count - 1].Color = ColorTranslator.FromHtml(_row["xcolor"].ToString());
                    //                        }
                    //                        else
                    //                        {
                    //                            td3.InnerHtml = "0";
                    //                            //series.Points.AddXY(dtamexamd.Rows[count - 1]["xgrade"].ToString(), 0);
                    //                            //series.Points[count - 1].Color = ColorTranslator.FromHtml(dtamexamd.Rows[count - 1]["xcolor"].ToString());
                    //                            series.Points.AddXY(_row["xgrade"].ToString(), 0);
                    //                            series.Points[count - 1].Color = ColorTranslator.FromHtml(_row["xcolor"].ToString());
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        td3.InnerHtml = "-";
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    td3.InnerHtml = "";
                    //                }

                    //                tr.Controls.Add(td3);




                    //                //Add color code


                    //                HtmlGenericControl tr2 = new HtmlGenericControl("tr");
                    //                table1.Controls.Add(tr2);

                    //                HtmlGenericControl td4 = new HtmlGenericControl("td");
                    //                //string _color = dtamexamd.Rows[count - 1]["xcolor"].ToString();
                    //                string _color = _row["xcolor"].ToString();
                    //                td4.Attributes.Add("style", "width:20px;height:10px;background-color:" + _color + ";color:" + _color);
                    //                td4.InnerHtml = "---";
                    //                tr2.Controls.Add(td4);

                    //                HtmlGenericControl td5 = new HtmlGenericControl("td");
                    //                //td5.InnerHtml = dtamexamd.Rows[count - 1]["xgrade"].ToString();
                    //                td5.InnerHtml = _row["xgrade"].ToString();
                    //                tr2.Controls.Add(td5);

                    //                ///////////
                    //                /// 
                    //                /// 
                    //                /// 
                    //                count = count + 1;
                    //            }
                    //        }
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


        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {

                message.InnerHtml = "";

                //xname.Text = "";
                _student.Value = "";

                GridView1.DataSource = null;
                GridView1.DataBind();
                result.Visible = false;
                barchart.Visible = false;
                btnApprove.Visible = false;
                btnSave.Visible = false;

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }


        protected void combo1_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                // message.InnerHtml = "";

                //// BindGrid(1999, 1);

                // if (ViewState["xrow"] == null)
                // {
                //     message.InnerHtml = "No data found.";
                //     message.Style.Value = zglobal.am_warningmsg;
                //     return;
                // }


                //// hiddenxdate.Value = xdate.SelectedValue.ToString();


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

                fnFillDataGrid(null, null);

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerText = "";

                //if (ViewState["xrow"] != null)
                //{
                if (txtconformmessageValue3.Value == "Yes")
                {
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                    using (SqlConnection con = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts1 = new DataSet())
                        {
                            //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                            //string query =
                            //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                            //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                            string query =
                           "select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                           "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                           "group by xsubject,xpaper,xext,xsection  order by min(cast(xcodealt as int))";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                            //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                            //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                            //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                            da1.Fill(dts1, "tempztcode");
                            DataTable dtamexamh = new DataTable();
                            dtamexamh = dts1.Tables[0];

                            if (dtamexamh.Rows.Count > 0)
                            {
                                message.InnerHtml = "Please check for approval.";

                                foreach (GridViewRow row1 in GridView1.Rows)
                                {

                                    string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                    string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();
                                    string xext1 = ((Label)row1.FindControl("lblExtension")).Text.ToString();

                                    string subj = "";
                                    //if (xpaper1 == "")
                                    //{
                                    //    subj = xsubject1;
                                    //}
                                    //else
                                    //{
                                    //    subj = xsubject1 + "-" + xpaper1;
                                    //}

                                    if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                                    {
                                        subj = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                                    }
                                    else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                                    {
                                        subj = xsubject1 + "-" + xpaper1;
                                    }
                                    else if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 == "" || xpaper1 == String.Empty))
                                    {
                                        subj = xsubject1 + "(" + xext1 + ")";
                                    }
                                    else
                                    {
                                        subj = xsubject1;
                                    }



                                    DataRow[] result20 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");

                                    if (result20.Length > 0)
                                    {
                                        message.InnerHtml = message.InnerHtml + "<br/>Subject : " + subj + "<br/>Section : ";

                                        int h = 0;
                                        foreach (DataRow val in result20)
                                        {
                                            if (h == result20.Length - 1)
                                            {
                                                message.InnerHtml = message.InnerHtml + result20[h]["xsection"].ToString() + ". <br/>";
                                            }
                                            else
                                            {
                                                message.InnerHtml = message.InnerHtml + result20[h]["xsection"].ToString() + ", ";
                                            }

                                            h = h + 1;

                                        }
                                    }


                                }




                                message.Style.Value = zglobal.am_warningmsg;
                                result.Visible = false;
                                barchart.Visible = false;
                                return;
                            }

                        }
                    }



                    int flag = 0;
                 

                    int RowSpan1 = 2;
                    int RowSpan2 = 2;

                    string perc = "";
                    string perc1 = "";
                    //List<int> listcount = new List<int>();
                    for (int i = 0; i <= GridView1.Rows.Count - 2; i++)
                    {
                        GridViewRow currRow = GridView1.Rows[i];
                        GridViewRow nextRow = GridView1.Rows[i + 1];

                        Label txt1 = currRow.Cells[1].FindControl("txtSubject") as Label;
                        Label txt2 = nextRow.Cells[1].FindControl("txtSubject") as Label;

                        Label lblpap1 = currRow.Cells[2].FindControl("txtPaper") as Label;
                        Label lblpap2 = nextRow.Cells[2].FindControl("txtPaper") as Label;

                        DropDownList dlistBest1 = currRow.FindControl("dlistBest") as DropDownList;
                        //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                        TextBox txtWeight1 = currRow.FindControl("txtWeight") as TextBox;
                        TextBox dlistPerc1 = currRow.FindControl("dlistPerc") as TextBox;

                        DropDownList dlistBest2 = nextRow.FindControl("dlistBest") as DropDownList;
                        //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                        TextBox txtWeight2 = nextRow.FindControl("txtWeight") as TextBox;
                        TextBox dlistPerc2 = nextRow.FindControl("dlistPerc") as TextBox;

                        if (txt1.Text == txt2.Text)
                        {
                            if (lblpap1.Text == lblpap2.Text)
                            {
                                if (RowSpan2 == 2)
                                {
                                    perc = dlistPerc1.Text.Trim().ToString();
                                }

                                ((TextBox)nextRow.FindControl("dlistPerc")).Text = perc.ToString();

                                //    if (dlistBest1.Text.Trim().ToString() == "" || perc.ToString() == "" ||
                                //txtWeight1.Text.Trim().ToString() == "" || dlistBest2.Text.Trim().ToString() == "" ||
                                //txtWeight2.Text.Trim().ToString() == "")
                                //    {
                                //        currRow.Cells[0].BackColor = zglobal.rowerr;
                                //        currRow.Cells[1].BackColor = zglobal.rowerr;
                                //        currRow.Cells[2].BackColor = zglobal.rowerr;
                                //        currRow.Cells[3].BackColor = zglobal.rowerr;
                                //        currRow.Cells[4].BackColor = zglobal.rowerr;
                                //        currRow.Cells[5].BackColor = zglobal.rowerr;
                                //        currRow.Cells[6].BackColor = zglobal.rowerr;
                                //        currRow.Cells[10].BackColor = zglobal.rowerr;

                                //        nextRow.Cells[0].BackColor = zglobal.rowerr;
                                //        nextRow.Cells[1].BackColor = zglobal.rowerr;
                                //        nextRow.Cells[2].BackColor = zglobal.rowerr;
                                //        nextRow.Cells[3].BackColor = zglobal.rowerr;
                                //        nextRow.Cells[4].BackColor = zglobal.rowerr;
                                //        nextRow.Cells[5].BackColor = zglobal.rowerr;
                                //        nextRow.Cells[6].BackColor = zglobal.rowerr;
                                //        nextRow.Cells[10].BackColor = zglobal.rowerr;

                                //        flag = 1;
                                //    }

                                RowSpan2 += 1;
                            }
                            else
                            {
                                RowSpan2 = 2;
                            }



                            if (RowSpan1 == 2)
                            {
                                perc1 = dlistPerc1.Text.Trim().ToString();
                            }

                            if (dlistBest1.Text.Trim().ToString() == "" || perc1.ToString() == "" ||
                                txtWeight1.Text.Trim().ToString() == "" || dlistBest2.Text.Trim().ToString() == "" ||
                                txtWeight2.Text.Trim().ToString() == "")
                            {
                                currRow.Cells[0].BackColor = zglobal.rowerr;
                                currRow.Cells[1].BackColor = zglobal.rowerr;
                                currRow.Cells[2].BackColor = zglobal.rowerr;
                                currRow.Cells[3].BackColor = zglobal.rowerr;
                                currRow.Cells[4].BackColor = zglobal.rowerr;
                                currRow.Cells[5].BackColor = zglobal.rowerr;
                                currRow.Cells[6].BackColor = zglobal.rowerr;
                                currRow.Cells[10].BackColor = zglobal.rowerr;

                                nextRow.Cells[0].BackColor = zglobal.rowerr;
                                nextRow.Cells[1].BackColor = zglobal.rowerr;
                                nextRow.Cells[2].BackColor = zglobal.rowerr;
                                nextRow.Cells[3].BackColor = zglobal.rowerr;
                                nextRow.Cells[4].BackColor = zglobal.rowerr;
                                nextRow.Cells[5].BackColor = zglobal.rowerr;
                                nextRow.Cells[6].BackColor = zglobal.rowerr;
                                nextRow.Cells[10].BackColor = zglobal.rowerr;

                                flag = 1;
                            }


                            RowSpan1 += 1;



                        }
                        else
                        {
                            //listcount.Add(RowSpan);
                            RowSpan1 = 2;
                            RowSpan2 = 2;
                            if (dlistBest1.Text.Trim().ToString() == "" || dlistPerc1.Text.Trim().ToString() == "" || txtWeight1.Text.Trim().ToString() == "")
                            {
                                //currRow.BackColor = zglobal.rowerr;
                                currRow.Cells[0].BackColor = zglobal.rowerr;
                                currRow.Cells[1].BackColor = zglobal.rowerr;
                                currRow.Cells[2].BackColor = zglobal.rowerr;
                                currRow.Cells[3].BackColor = zglobal.rowerr;
                                currRow.Cells[4].BackColor = zglobal.rowerr;
                                currRow.Cells[5].BackColor = zglobal.rowerr;
                                currRow.Cells[6].BackColor = zglobal.rowerr;
                                currRow.Cells[10].BackColor = zglobal.rowerr;

                                flag = 1;
                            }

                            if ((i + 1) == GridView1.Rows.Count - 1)
                            {
                                if (dlistBest2.Text.Trim().ToString() == "" || dlistPerc2.Text.Trim().ToString() == "" || txtWeight2.Text.Trim().ToString() == "")
                                {
                                    //nextRow.BackColor = zglobal.rowerr;
                                    nextRow.Cells[0].BackColor = zglobal.rowerr;
                                    nextRow.Cells[1].BackColor = zglobal.rowerr;
                                    nextRow.Cells[2].BackColor = zglobal.rowerr;
                                    nextRow.Cells[3].BackColor = zglobal.rowerr;
                                    nextRow.Cells[4].BackColor = zglobal.rowerr;
                                    nextRow.Cells[5].BackColor = zglobal.rowerr;
                                    nextRow.Cells[6].BackColor = zglobal.rowerr;
                                    nextRow.Cells[10].BackColor = zglobal.rowerr;

                                    flag = 1;
                                }
                            }

                        }
                    }

                    if (flag == 1)
                    {
                        //message.InnerText = "Must select best taken and percentage of all subjects.";
                        message.InnerText = "Please fill all field(s) properly.";
                        message.Style.Value = zglobal.warningmsg;
                        return;
                    }


                    string xstatus;

                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            //SqlTransaction tran;
                            //tran = conn.BeginTransaction("SampleTransaction");

                            cmd.Connection = conn;
                            //cmd.Transaction = tran;
                            //int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                            string xapproved3by = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            DateTime xapproved3dt = DateTime.Now;
                            xstatus = "Approved3";




                            string query =
                                "UPDATE amexamh SET xstatus=@xstatus,xapproved3by=@xapproved3by,xapproved3dt=@xapproved3dt " +
                                "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup and xtype='Class Test'";
                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            cmd.Parameters.AddWithValue("@xstatus", xstatus);
                            cmd.Parameters.AddWithValue("@xapproved3by", xapproved3by);
                            cmd.Parameters.AddWithValue("@xapproved3dt", xapproved3dt);
                            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            cmd.ExecuteNonQuery();

                            query =
                                "UPDATE amexamvw set amexamvw.xbflag=0  " +
                                "WHERE amexamvw.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                "  and xtype='Class Test'";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                            //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                            //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            //cmd.Parameters.AddWithValue("@xid", _xid);
                            //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                            //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                            //cmd.Parameters.AddWithValue("@xext", xext1);
                            cmd.ExecuteNonQuery();

                            //query =
                            //    "UPDATE amexamd set amexamd.xbflag=amexammaxmarkvw3.xbestflag from amexamd inner join amexammaxmarkvw3 " +
                            //    "on amexamd.zid=amexammaxmarkvw3.zid and amexamd.xrow=amexammaxmarkvw3.xrow " +
                            //    "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup AND xid<=@xid";

                            //cmd.Parameters.Clear();

                            //cmd.CommandText = query;
                            //cmd.Parameters.AddWithValue("@zid", _zid);
                            ////cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            ////cmd.Parameters.AddWithValue("@xstatus", xstatus);
                            ////cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                            ////cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                            //cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            //cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            //cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            //cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            //cmd.ExecuteNonQuery();

                            query =
                                    "DELETE FROM amexamhh " +
                                    "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                    "and xtype='Class Test' and xstatus='Test' ";

                            cmd.Parameters.Clear();

                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zid", _zid);
                            //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                            //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                            //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                            //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                            //cmd.Parameters.AddWithValue("@xid", _xid);
                            //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                            //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                            //cmd.Parameters.AddWithValue("@xext", xext1);
                            cmd.ExecuteNonQuery();

                            DataTable dtamexamh;

                            using (SqlConnection con = new SqlConnection(zglobal.constring))
                            {
                                using (DataSet dts1 = new DataSet())
                                {

                                    query =
                           "select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                           "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                           "group by xsubject,xpaper,xext,xsection  order by min(cast(xcodealt as int))";

                                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                    da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                    //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                    //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                    //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                    //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                    da1.Fill(dts1, "tempztcode");
                                    dtamexamh = new DataTable();
                                    dtamexamh = dts1.Tables[0];

                                    if (dtamexamh.Rows.Count > 0)
                                    {
                                        ViewState["amexamh1"] = dtamexamh;
                                        //message.InnerHtml = "yes";
                                        //return;
                                    }
                                    else
                                    {
                                        ViewState["amexamh1"] = null;
                                        //message.InnerHtml = "no";
                                        //return;
                                    }

                                }
                            }

                            if (ViewState["amexamh1"] != null)
                            //if (dtamexamh.Rows.Count > 0)
                            {

                                foreach (GridViewRow row1 in GridView1.Rows)
                                {
                                    string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                    string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();
                                    string xext1 = ((Label)row1.FindControl("lblExtension")).Text.ToString();
                                    int _xid = Convert.ToInt32(((DropDownList)row1.FindControl("dlistBest")).Text.ToString());


                                    query =
                                        "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
                                        "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
                                        "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
                                        "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                        "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

                                    cmd.Parameters.Clear();

                                    cmd.CommandText = query;
                                    cmd.Parameters.AddWithValue("@zid", _zid);
                                    //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                    //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                    //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                    //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                    cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                    cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                    cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                    cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                    cmd.Parameters.AddWithValue("@xid", _xid);
                                    cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                    cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                    cmd.Parameters.AddWithValue("@xext", xext1);
                                    cmd.ExecuteNonQuery();

                                    DataRow[] result60 = ((DataTable)ViewState["amexamh1"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");
                                    //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                    if (result60.Length > 0)
                                    {
                                        foreach (DataRow row2 in result60)
                                        {


                                            string xsection1 = row2["xsection"].ToString();


                                            //query =
                                            //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xapproved1by,xapproved1dt) " +
                                            //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xapproved1by,@xapproved1dt) ";

                                            // query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                            //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test') " +
                                            //"UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xapproved1by=@xapproved1by,xapproved1dt=@xapproved1dt,xstatus=@xstatus " +
                                            //"where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                            //"and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' " +
                                            // "ELSE " +
                                            // "INSERT INTO amexamhh (zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,xapproved1by,xapproved1dt) " +
                                            // "VALUES(@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@xapproved1by,@xapproved1dt) ";

                                            query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                            "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension') " +
                                            "UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xstatus=@xstatus,xapproved1by=@xapproved1by,xapproved1dt=@xapproved1dt " +
                                            "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                            "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1=@xtype1 " +
                                            "ELSE " +
                                            "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xapproved1by,xapproved1dt,xtype1) " +
                                            "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xapproved1by,@xapproved1dt,@xtype1) ";





                                            int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                            string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                            string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                                            string xapproved1by =
                                                Convert.ToString(HttpContext.Current.Session["curuser"]);
                                            DateTime xapproved1dt = DateTime.Now;
                                            DateTime ztime1 = DateTime.Now;

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@ztime", ztime1);
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xrow", xrow);
                                            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xsection", xsection1);
                                            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                            cmd.Parameters.AddWithValue("@xext", xext1);
                                            cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                            cmd.Parameters.AddWithValue("@xtbest",
                                                ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                            cmd.Parameters.AddWithValue("@xperc",
                                                ((TextBox)row1.FindControl("txtWeight")).Text.ToString());
                                            cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                            cmd.Parameters.AddWithValue("@zemail", zemail);
                                            cmd.Parameters.AddWithValue("@xapproved1by", xapproved1by);
                                            cmd.Parameters.AddWithValue("@xapproved1dt", xapproved1dt);
                                            cmd.Parameters.AddWithValue("@xtype1", "Subject Extension");
                                            cmd.ExecuteNonQuery();


                                            //query =
                                            //    "INSERT INTO amexamhhd (ztime,zid,xrow,xline,xsrow,xremarks,zemail) " +
                                            //    "SELECT @ztime,zid,@xrow,row_number() over(order by xrow) as xline,xrow, " +
                                            //    "coalesce((select top 1 xremarks from amexamhhdtemp where zid=a.zid AND xsession=a.xsession AND xterm=@xterm AND " +
                                            //    "xclass=a.xclass AND xgroup=a.xgroup AND xsection=@xsection AND xsubject=@xsubject AND xpaper=@xpaper AND xsrow=a.xrow AND xtype='Class Test'),'') as xremarks " +
                                            //    ",@zemail FROM amstudentvw as a WHERE zid=@zid AND xsession=@xsession AND xclass=@xclass AND xgroup=@xgroup";

                                            ////int xline = zglobal.GetMaximumIdInt("xline", "amexamhhd", " zid=" + _zid + " and xrow=" + xrow, "line");



                                            //cmd.Parameters.Clear();

                                            //cmd.CommandText = query;
                                            //cmd.Parameters.AddWithValue("@ztime", ztime1);
                                            //cmd.Parameters.AddWithValue("@zid", _zid);
                                            //cmd.Parameters.AddWithValue("@xrow", xrow);
                                            ////cmd.Parameters.AddWithValue("@xline", xline);
                                            //cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                            //cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                            //cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                            //cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                            //cmd.Parameters.AddWithValue("@xsection", xsection1);
                                            //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                            //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                            ////cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                            ////cmd.Parameters.AddWithValue("@xtbest", ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                            ////cmd.Parameters.AddWithValue("@xperc", ((DropDownList)row1.FindControl("dlistPerc")).Text.ToString());
                                            ////cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                            //cmd.Parameters.AddWithValue("@zemail", zemail);
                                            ////cmd.Parameters.AddWithValue("@xapproved1by", xapproved1by);
                                            ////cmd.Parameters.AddWithValue("@xapproved1dt", xapproved1dt);
                                            //cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            using (SqlConnection con = new SqlConnection(zglobal.constring))
                            {
                                using (DataSet dts1 = new DataSet())
                                {

                                    query =
                           "select xsubject,xpaper,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                           "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                           "group by xsubject,xpaper,xsection  order by min(cast(xcodealt as int))";

                                    SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                                    da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                    da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                    da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                    da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                    da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                    //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                    //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                    //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                    //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                    da1.Fill(dts1, "tempztcode");
                                    dtamexamh = new DataTable();
                                    dtamexamh = dts1.Tables[0];

                                    if (dtamexamh.Rows.Count > 0)
                                    {
                                        ViewState["amexamh2"] = dtamexamh;
                                        //message.InnerHtml = "yes";
                                        //return;
                                    }
                                    else
                                    {
                                        ViewState["amexamh2"] = null;
                                        //message.InnerHtml = "no";
                                        //return;
                                    }

                                }
                            }

                            if (ViewState["amexamh2"] != null)
                            {

                                foreach (GridViewRow row1 in GridView1.Rows)
                                {
                                    string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                    string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();





                                    DataRow[] result60 = ((DataTable)ViewState["amexamh2"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
                                    //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                    if (result60.Length > 0)
                                    {
                                        foreach (DataRow row2 in result60)
                                        {
                                            string xsection1 = row2["xsection"].ToString();


                                            //query =
                                            //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
                                            //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

                                            query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                                    "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test') " +
                                                    "UPDATE amexamhh SET xtbest=@xtbest,xperc=@xperc,xstatus=@xstatus,xapproved1by=@xapproved1by,xapproved1dt=@xapproved1dt " +
                                                    "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                                    "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' and xtype1=@xtype1 " +
                                                    "ELSE " +
                                                    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xapproved1by,xapproved1dt,xtype1) " +
                                                    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xapproved1by,@xapproved1dt,@xtype1) ";

                                            int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                            string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                            string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);


                                            string xapproved1by = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                            DateTime xapproved1dt = DateTime.Now;
                                            DateTime ztime1 = DateTime.Now;
                                            DateTime zutime1 = DateTime.Now;

                                            cmd.Parameters.Clear();

                                            cmd.CommandText = query;
                                            cmd.Parameters.AddWithValue("@ztime", ztime1);
                                            cmd.Parameters.AddWithValue("@zutime", zutime1);
                                            cmd.Parameters.AddWithValue("@zid", _zid);
                                            cmd.Parameters.AddWithValue("@xrow", xrow);
                                            cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                            cmd.Parameters.AddWithValue("@xsection", xsection1);
                                            cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                            cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                            cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                            //cmd.Parameters.AddWithValue("@xtbest",
                                            //    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                            cmd.Parameters.AddWithValue("@xtbest",
                                               0);
                                            cmd.Parameters.AddWithValue("@xperc",
                                                ((TextBox)row1.FindControl("dlistPerc")).Text.ToString());
                                            cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                            cmd.Parameters.AddWithValue("@zemail", zemail);
                                            cmd.Parameters.AddWithValue("@xemail", xemail);
                                            cmd.Parameters.AddWithValue("@xapproved1by", xapproved1by);
                                            cmd.Parameters.AddWithValue("@xapproved1dt", xapproved1dt);
                                            cmd.Parameters.AddWithValue("@xtype1", "Class Test");
                                            cmd.ExecuteNonQuery();



                                        }
                                    }
                                }
                            }

                           
                            // tran.Commit();
                        }

                        tran.Complete();
                    }

                    //using (SqlConnection con = new SqlConnection(zglobal.constring))
                    //{
                    //    using (SqlCommand cmd1 = new SqlCommand("sp_GenerateTabulation3", con))
                    //    {
                    //        cmd1.CommandType = CommandType.StoredProcedure;
                    //        cmd1.CommandTimeout = 0;
                    //        cmd1.Parameters.AddWithValue("@zid", _zid);
                    //        cmd1.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                    //        cmd1.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                    //        cmd1.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                    //        cmd1.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                    //        con.Open();
                    //        cmd1.ExecuteNonQuery();
                    //    }
                    //}

                    message.InnerHtml = zglobal.appsuccmsg;
                    message.Style.Value = zglobal.successmsg;
                    //btnSubmit.Enabled = false;
                    //btnSubmit1.Enabled = false;
                    //btnSave.Enabled = false;
                    //btnSave1.Enabled = false;
                    //btnDelete.Enabled = false;
                    //btnDelete1.Enabled = false;
                    btnApprove.Enabled = false;
                    btnSave.Enabled = false;
                    //btnApprove1.Enabled = false;
                    //btnUndo.Enabled = false;
                    //btnUndo1.Enabled = false;
                    ViewState["xstatus"] = "Approved3";
                    // hxstatus.Value = "Approved2";
                    hiddenxstatus.Value = "Approved3";
                    // fnButtonState();
                    BindGrid();
                    //fnFillGrid2();
                }
                //}
                //else
                //{
                //    message.InnerHtml = "No data found for approved.";
                //    message.Style.Value = zglobal.warningmsg;
                //}
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
                // tran.Rollback();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                message.InnerText = "";

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        //string query = "SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow WHERE amexamd.zid=@zid AND amexamd.xrow in (" + xrow2 + ")";
                        //string query =
                        //"SELECT amexamd.xgetmark,amexamh.xtopic,amexamh.xdetails,amexamh.xdate,amexamh.xmarks,* FROM amexamh inner join amexamd on amexamh.zid=amexamd.zid and amexamh.xrow=amexamd.xrow " +
                        //"WHERE amexamh.zid=@zid AND xsession=@xsession AND xclass=@xclass AND xterm=@xterm AND xgroup=@xgroup AND xtype='Class Test'  AND xsection=@xsection ";

                       string query =
                       "select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                       "where xstatus not in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                       "group by xsubject,xpaper,xext,xsection  order by min(cast(xcodealt as int))";

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                        //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                        //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamh = new DataTable();
                        dtamexamh = dts1.Tables[0];

                        //if (ViewState["amexamh10"] != null)
                        if (dtamexamh.Rows.Count > 0)
                        {
                            message.InnerHtml = "Please check for approval.";

                            foreach (GridViewRow row1 in GridView1.Rows)
                            {

                                string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();
                                string xext1 = ((Label)row1.FindControl("lblExtension")).Text.ToString();

                                string subj = "";
                                //if (xpaper1 == "")
                                //{
                                //    subj = xsubject1;
                                //}
                                //else
                                //{
                                //    subj = xsubject1 + "-" + xpaper1;
                                //}

                                if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                                {
                                    subj = xsubject1 + "(" + xext1 + ")" + "-" + xpaper1;
                                }
                                else if ((xext1 == "" || xext1 == String.Empty) && (xpaper1 != "" || xpaper1 != String.Empty))
                                {
                                    subj = xsubject1 + "-" + xpaper1;
                                }
                                else if ((xext1 != "" || xext1 != String.Empty) && (xpaper1 == "" || xpaper1 == String.Empty))
                                {
                                    subj = xsubject1 + "(" + xext1 + ")";
                                }
                                else
                                {
                                    subj = xsubject1;
                                }



                                DataRow[] result20 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");
                                //DataRow[] result20 = ((DataTable)ViewState["amexamh10"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");

                                if (result20.Length > 0)
                                {
                                    message.InnerHtml = message.InnerHtml + "<br/>Subject : " + subj + "<br/>Section : ";

                                    int h = 0;
                                    foreach (DataRow val in result20)
                                    {
                                        if (h == result20.Length - 1)
                                        {
                                            message.InnerHtml = message.InnerHtml + result20[h]["xsection"].ToString() + ". <br/>";
                                        }
                                        else
                                        {
                                            message.InnerHtml = message.InnerHtml + result20[h]["xsection"].ToString() + ", ";
                                        }

                                        h = h + 1;

                                    }
                                }


                            }




                            message.Style.Value = zglobal.am_warningmsg;
                            result.Visible = false;
                            barchart.Visible = false;
                            return;
                        }

                        da1.Dispose();

                        dtamexamh.Dispose();
                    }
                }

                int flag = 0;


                int RowSpan1 = 2;
                int RowSpan2 = 2;

                string perc = "";
                string perc1 = "";
                //List<int> listcount = new List<int>();
                for (int i = 0; i <= GridView1.Rows.Count - 2; i++)
                {
                    GridViewRow currRow = GridView1.Rows[i];
                    GridViewRow nextRow = GridView1.Rows[i + 1];

                    Label txt1 = currRow.Cells[1].FindControl("txtSubject") as Label;
                    Label txt2 = nextRow.Cells[1].FindControl("txtSubject") as Label;

                    Label lblpap1 = currRow.Cells[2].FindControl("txtPaper") as Label;
                    Label lblpap2 = nextRow.Cells[2].FindControl("txtPaper") as Label;

                    DropDownList dlistBest1 = currRow.FindControl("dlistBest") as DropDownList;
                    //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                    TextBox txtWeight1 = currRow.FindControl("txtWeight") as TextBox;
                    TextBox dlistPerc1 = currRow.FindControl("dlistPerc") as TextBox;

                    DropDownList dlistBest2 = nextRow.FindControl("dlistBest") as DropDownList;
                    //DropDownList dlistPerc1 = row.FindControl("dlistPerc") as DropDownList;txtWeight
                    TextBox txtWeight2 = nextRow.FindControl("txtWeight") as TextBox;
                    TextBox dlistPerc2 = nextRow.FindControl("dlistPerc") as TextBox;

                    if (txt1.Text == txt2.Text)
                    {
                        if (lblpap1.Text == lblpap2.Text)
                        {
                            if (RowSpan2 == 2)
                            {
                                perc = dlistPerc1.Text.Trim().ToString();
                            }

                            ((TextBox)nextRow.FindControl("dlistPerc")).Text = perc.ToString();

                            //    if (dlistBest1.Text.Trim().ToString() == "" || perc.ToString() == "" ||
                            //txtWeight1.Text.Trim().ToString() == "" || dlistBest2.Text.Trim().ToString() == "" ||
                            //txtWeight2.Text.Trim().ToString() == "")
                            //    {
                            //        currRow.Cells[0].BackColor = zglobal.rowerr;
                            //        currRow.Cells[1].BackColor = zglobal.rowerr;
                            //        currRow.Cells[2].BackColor = zglobal.rowerr;
                            //        currRow.Cells[3].BackColor = zglobal.rowerr;
                            //        currRow.Cells[4].BackColor = zglobal.rowerr;
                            //        currRow.Cells[5].BackColor = zglobal.rowerr;
                            //        currRow.Cells[6].BackColor = zglobal.rowerr;
                            //        currRow.Cells[10].BackColor = zglobal.rowerr;

                            //        nextRow.Cells[0].BackColor = zglobal.rowerr;
                            //        nextRow.Cells[1].BackColor = zglobal.rowerr;
                            //        nextRow.Cells[2].BackColor = zglobal.rowerr;
                            //        nextRow.Cells[3].BackColor = zglobal.rowerr;
                            //        nextRow.Cells[4].BackColor = zglobal.rowerr;
                            //        nextRow.Cells[5].BackColor = zglobal.rowerr;
                            //        nextRow.Cells[6].BackColor = zglobal.rowerr;
                            //        nextRow.Cells[10].BackColor = zglobal.rowerr;

                            //        flag = 1;
                            //    }

                            RowSpan2 += 1;
                        }
                        else
                        {
                            RowSpan2 = 2;
                        }



                        if (RowSpan1 == 2)
                        {
                            perc1 = dlistPerc1.Text.Trim().ToString();
                        }

                        if (dlistBest1.Text.Trim().ToString() == "" || perc1.ToString() == "" ||
                            txtWeight1.Text.Trim().ToString() == "" || dlistBest2.Text.Trim().ToString() == "" ||
                            txtWeight2.Text.Trim().ToString() == "")
                        {
                            currRow.Cells[0].BackColor = zglobal.rowerr;
                            currRow.Cells[1].BackColor = zglobal.rowerr;
                            currRow.Cells[2].BackColor = zglobal.rowerr;
                            currRow.Cells[3].BackColor = zglobal.rowerr;
                            currRow.Cells[4].BackColor = zglobal.rowerr;
                            currRow.Cells[5].BackColor = zglobal.rowerr;
                            currRow.Cells[6].BackColor = zglobal.rowerr;
                            currRow.Cells[10].BackColor = zglobal.rowerr;

                            nextRow.Cells[0].BackColor = zglobal.rowerr;
                            nextRow.Cells[1].BackColor = zglobal.rowerr;
                            nextRow.Cells[2].BackColor = zglobal.rowerr;
                            nextRow.Cells[3].BackColor = zglobal.rowerr;
                            nextRow.Cells[4].BackColor = zglobal.rowerr;
                            nextRow.Cells[5].BackColor = zglobal.rowerr;
                            nextRow.Cells[6].BackColor = zglobal.rowerr;
                            nextRow.Cells[10].BackColor = zglobal.rowerr;

                            flag = 1;
                        }


                        RowSpan1 += 1;



                    }
                    else
                    {
                        //listcount.Add(RowSpan);
                        RowSpan1 = 2;
                        RowSpan2 = 2;
                        if (dlistBest1.Text.Trim().ToString() == "" || dlistPerc1.Text.Trim().ToString() == "" || txtWeight1.Text.Trim().ToString() == "")
                        {
                            //currRow.BackColor = zglobal.rowerr;
                            currRow.Cells[0].BackColor = zglobal.rowerr;
                            currRow.Cells[1].BackColor = zglobal.rowerr;
                            currRow.Cells[2].BackColor = zglobal.rowerr;
                            currRow.Cells[3].BackColor = zglobal.rowerr;
                            currRow.Cells[4].BackColor = zglobal.rowerr;
                            currRow.Cells[5].BackColor = zglobal.rowerr;
                            currRow.Cells[6].BackColor = zglobal.rowerr;
                            currRow.Cells[10].BackColor = zglobal.rowerr;

                            flag = 1;
                        }

                        if ((i + 1) == GridView1.Rows.Count - 1)
                        {
                            if (dlistBest2.Text.Trim().ToString() == "" || dlistPerc2.Text.Trim().ToString() == "" || txtWeight2.Text.Trim().ToString() == "")
                            {
                                //nextRow.BackColor = zglobal.rowerr;
                                nextRow.Cells[0].BackColor = zglobal.rowerr;
                                nextRow.Cells[1].BackColor = zglobal.rowerr;
                                nextRow.Cells[2].BackColor = zglobal.rowerr;
                                nextRow.Cells[3].BackColor = zglobal.rowerr;
                                nextRow.Cells[4].BackColor = zglobal.rowerr;
                                nextRow.Cells[5].BackColor = zglobal.rowerr;
                                nextRow.Cells[6].BackColor = zglobal.rowerr;
                                nextRow.Cells[10].BackColor = zglobal.rowerr;

                                flag = 1;
                            }
                        }

                    }
                }

                //if (flag == 1)
                //{
                //    //message.InnerText = "Must select best taken and percentage of all subjects.";
                //    message.InnerText = "Please fill all field(s) properly.";
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

                        string xapproved3by = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xapproved3dt = DateTime.Now;
                        xstatus = "New";




                        string query = "";

                        query =
                                "UPDATE amexamvw set amexamvw.xbflag=0  " +
                                "WHERE amexamvw.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                "  and xtype='Class Test'";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //cmd.Parameters.AddWithValue("@xid", _xid);
                        //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                        //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                        //cmd.Parameters.AddWithValue("@xext", xext1);
                        cmd.ExecuteNonQuery();



                        query =
                                "DELETE FROM amexamhh " +
                                "WHERE zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                "and xtype='Class Test' and xstatus='Test' ";

                        cmd.Parameters.Clear();

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                        //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                        //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                        //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                        //cmd.Parameters.AddWithValue("@xid", _xid);
                        //cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                        //cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                        //cmd.Parameters.AddWithValue("@xext", xext1);
                        cmd.ExecuteNonQuery();

                        DataTable dtamexamh;

                        using (SqlConnection con = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts1 = new DataSet())
                            {

                                query =
                       "select xsubject,xpaper,coalesce(xext,'') as xext,xsection from amexamh  " +
                       "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and " +
                       "xterm=@xterm and amexamh.xtype='Class Test'  " +
                       "group by xsubject,xpaper,xext,xsection ";

                                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                                da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                da1.Fill(dts1, "tempztcode");
                                dtamexamh = new DataTable();
                                dtamexamh = dts1.Tables[0];

                                if (dtamexamh.Rows.Count > 0)
                                {
                                    ViewState["amexamh1"] = dtamexamh;
                                    //message.InnerHtml = "yes";
                                    //return;
                                }
                                else
                                {
                                    ViewState["amexamh1"] = null;
                                    //message.InnerHtml = "no";
                                    //return;
                                }

                                da1.Dispose();
                                dtamexamh.Dispose();
                            }
                        }

                        if (ViewState["amexamh1"] != null)
                        //if (dtamexamh.Rows.Count > 0)
                        {

                            foreach (GridViewRow row1 in GridView1.Rows)
                            {
                                string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();
                                string xext1 = ((Label)row1.FindControl("lblExtension")).Text.ToString();

                                int _xid = Convert.ToInt32(((DropDownList)row1.FindControl("dlistBest")).Text.ToString() == "" ? "0" : ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());


                                query =
                                    "UPDATE amexamd set amexamd.xbflag=1 from amexamd inner join amexammaxmarkvw2 " +
                                    "on amexamd.zid=amexammaxmarkvw2.zid and amexamd.xrow=amexammaxmarkvw2.xrow and " +
                                    "amexamd.xline=amexammaxmarkvw2.xline and amexamd.xsrow=amexammaxmarkvw2.xsrow " +
                                    "WHERE amexamd.zid=@zid AND xsession=@xsession AND xterm=@xterm AND xclass=@xclass AND xgroup=@xgroup " +
                                    "AND xid<=@xid AND xsubject=@xsubject AND xpaper=@xpaper AND xext=@xext and xtype='Class Test'";

                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                //cmd.Parameters.AddWithValue("@xrow", Convert.ToInt32(ViewState["xrow"]));
                                //cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                //cmd.Parameters.AddWithValue("@xapproved2by", xapproved3by);
                                //cmd.Parameters.AddWithValue("@xapproved2dt", xapproved3dt);
                                cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                cmd.Parameters.AddWithValue("@xid", _xid);
                                cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                cmd.Parameters.AddWithValue("@xext", xext1);
                                cmd.ExecuteNonQuery();



                                DataRow[] result60 = ((DataTable)ViewState["amexamh1"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "' and xext='" + xext1 + "'");
                                //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                if (result60.Length > 0)
                                {
                                    foreach (DataRow row2 in result60)
                                    {
                                        string xsection1 = row2["xsection"].ToString();


                                        //query =
                                        //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
                                        //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

                                        query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1='Subject Extension') " +
                                                "UPDATE amexamhh SET zutime=@zutime,xtbest=@xtbest,xperc=@xperc,xemail=@xemail " +
                                                "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xext=@xext and xtype='Class Test' and xtype1=@xtype1 " +
                                                "ELSE " +
                                                "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xext,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xext,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

                                        int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                                        DateTime ztime1 = DateTime.Now;
                                        DateTime zutime1 = DateTime.Now;

                                        cmd.Parameters.Clear();

                                        cmd.CommandText = query;
                                        cmd.Parameters.AddWithValue("@ztime", ztime1);
                                        cmd.Parameters.AddWithValue("@zutime", zutime1);
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@xrow", xrow);
                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xsection", xsection1);
                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                        cmd.Parameters.AddWithValue("@xext", xext1);
                                        cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                        cmd.Parameters.AddWithValue("@xtbest",
                                            ((DropDownList)row1.FindControl("dlistBest")).Text.ToString() == "" || 
                                            ((DropDownList)row1.FindControl("dlistBest")).Text.ToString() == String.Empty
                                            ? "0" : 
                                            ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                        cmd.Parameters.AddWithValue("@xperc",
                                            ((TextBox)row1.FindControl("txtWeight")).Text.ToString() == "" ||
                                         ((TextBox)row1.FindControl("txtWeight")).Text.ToString() == String.Empty
                                         ? "0" : 
                                            ((TextBox)row1.FindControl("txtWeight")).Text.ToString());
                                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                        cmd.Parameters.AddWithValue("@zemail", zemail);
                                        cmd.Parameters.AddWithValue("@xemail", xemail);
                                        cmd.Parameters.AddWithValue("@xtype1", "Subject Extension");
                                        cmd.ExecuteNonQuery();



                                    }
                                }
                            }
                        }


                        using (SqlConnection con = new SqlConnection(zglobal.constring))
                        {
                            using (DataSet dts1 = new DataSet())
                            {

                                query =
                       "select xsubject,xpaper,xsection from amexamh inner join mscodesam on amexamh.zid=mscodesam.zid and mscodesam.xtype='Section' and amexamh.xsection=mscodesam.xcode " +
                       "where xstatus  in ('Approved2','Approved3') and amexamh.zid=@zid and xclass=@xclass  and xgroup=@xgroup and xsession=@xsession and xterm=@xterm and amexamh.xtype='Class Test'  " +
                       "group by xsubject,xpaper,xsection  order by min(cast(xcodealt as int))";

                                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                                da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                da1.SelectCommand.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                da1.SelectCommand.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                da1.SelectCommand.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                //da1.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject1);
                                //da1.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper1);
                                //da1.SelectCommand.Parameters.AddWithValue("@xsection", xsection.Text.ToString().Trim());
                                //da1.SelectCommand.Parameters.AddWithValue("@xsrow", _student.Value.ToString().Trim());

                                da1.Fill(dts1, "tempztcode");
                                dtamexamh = new DataTable();
                                dtamexamh = dts1.Tables[0];

                                if (dtamexamh.Rows.Count > 0)
                                {
                                    ViewState["amexamh2"] = dtamexamh;
                                    //message.InnerHtml = "yes";
                                    //return;
                                }
                                else
                                {
                                    ViewState["amexamh2"] = null;
                                    //message.InnerHtml = "no";
                                    //return;
                                }

                                da1.Dispose();
                                dtamexamh.Dispose();
                            }
                        }

                        if (ViewState["amexamh2"] != null)
                        {

                            foreach (GridViewRow row1 in GridView1.Rows)
                            {
                                string xpaper1 = ((Label)row1.FindControl("lblPaper")).Text.ToString();
                                string xsubject1 = ((Label)row1.FindControl("lblSubject")).Text.ToString();





                                DataRow[] result60 = ((DataTable)ViewState["amexamh2"]).Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");
                                //DataRow[] result60 = dtamexamh.Select("xsubject='" + xsubject1 + "' and xpaper='" + xpaper1 + "'");

                                if (result60.Length > 0)
                                {
                                    foreach (DataRow row2 in result60)
                                    {
                                        string xsection1 = row2["xsection"].ToString();


                                        //query =
                                        //    "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail) " +
                                        //    "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail) ";

                                        query = "IF EXISTS(select * from amexamhh where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper  and xtype='Class Test' and xtype1='Class Test') " +
                                                "UPDATE amexamhh SET zutime=@zutime,xtbest=@xtbest,xperc=@xperc,xemail=@xemail " +
                                                "where zid=@zid  and xsession=@xsession and xterm=@xterm and xclass=@xclass and xgroup=@xgroup " +
                                                "and xsection=@xsection and xsubject=@xsubject and xpaper=@xpaper and xtype='Class Test' and xtype1=@xtype1 " +
                                                "ELSE " +
                                                "INSERT INTO amexamhh (ztime,zid,xrow,xsession,xterm,xclass,xgroup,xsection,xsubject,xpaper,xtype,xtbest,xperc,xstatus,zemail,xtype1) " +
                                                "VALUES(@ztime,@zid,@xrow,@xsession,@xterm,@xclass,@xgroup,@xsection,@xsubject,@xpaper,@xtype,@xtbest,@xperc,@xstatus,@zemail,@xtype1) ";

                                        int xrow = zglobal.GetMaximumIdInt("xrow", "amexamhh", " zid=" + _zid, 1, 1);
                                        string zemail = Convert.ToString(HttpContext.Current.Session["curuser"]);
                                        string xemail = Convert.ToString(HttpContext.Current.Session["curuser"]);



                                        DateTime ztime1 = DateTime.Now;
                                        DateTime zutime1 = DateTime.Now;

                                        cmd.Parameters.Clear();

                                        cmd.CommandText = query;
                                        cmd.Parameters.AddWithValue("@ztime", ztime1);
                                        cmd.Parameters.AddWithValue("@zutime", zutime1);
                                        cmd.Parameters.AddWithValue("@zid", _zid);
                                        cmd.Parameters.AddWithValue("@xrow", xrow);
                                        cmd.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                                        cmd.Parameters.AddWithValue("@xsection", xsection1);
                                        cmd.Parameters.AddWithValue("@xsubject", xsubject1);
                                        cmd.Parameters.AddWithValue("@xpaper", xpaper1);
                                        cmd.Parameters.AddWithValue("@xtype", "Class Test");
                                        //cmd.Parameters.AddWithValue("@xtbest",
                                        //    ((DropDownList)row1.FindControl("dlistBest")).Text.ToString());
                                        cmd.Parameters.AddWithValue("@xtbest",
                                           0);
                                        cmd.Parameters.AddWithValue("@xperc",
                                            ((TextBox)row1.FindControl("dlistPerc")).Text.ToString() == "" ||
                                        ((TextBox)row1.FindControl("dlistPerc")).Text.ToString() == string.Empty 
                                        ? "0" : 
                                            ((TextBox)row1.FindControl("dlistPerc")).Text.ToString());
                                        cmd.Parameters.AddWithValue("@xstatus", xstatus);
                                        cmd.Parameters.AddWithValue("@zemail", zemail);
                                        cmd.Parameters.AddWithValue("@xemail", xemail);
                                        cmd.Parameters.AddWithValue("@xtype1", "Class Test");
                                        cmd.ExecuteNonQuery();



                                    }
                                }
                            }
                        }

                        cmd.Dispose();
                        
                        // tran.Commit();
                    }

                    tran.Complete();
                   
                }

                //using (SqlConnection con = new SqlConnection(zglobal.constring))
                //{
                //    using (SqlCommand cmd1 = new SqlCommand("sp_GenerateTabulation3", con))
                //    {
                //        cmd1.CommandType = CommandType.StoredProcedure;
                //        cmd1.CommandTimeout = 0;
                //        cmd1.Parameters.AddWithValue("@zid", _zid);
                //        cmd1.Parameters.AddWithValue("@xsession", xsession.Text.ToString().Trim());
                //        cmd1.Parameters.AddWithValue("@xclass", xclass.Text.ToString().Trim());
                //        cmd1.Parameters.AddWithValue("@xterm", xterm.Text.ToString().Trim());
                //        cmd1.Parameters.AddWithValue("@xgroup", xgroup.Text.ToString().Trim());
                //        con.Open();
                //        cmd1.ExecuteNonQuery();
                //    }
                //}

                
                message.InnerHtml = zglobal.savesuccmsg;
                message.Style.Value = zglobal.successmsg;
                //btnSubmit.Enabled = false;
                //btnSubmit1.Enabled = false;
                //btnSave.Enabled = false;
                //btnSave1.Enabled = false;
                //btnDelete.Enabled = false;
                //btnDelete1.Enabled = false;
                //btnApprove.Enabled = false;
                //btnSave.Enabled = false;
                //btnApprove1.Enabled = false;
                //btnUndo.Enabled = false;
                //btnUndo1.Enabled = false;
                ViewState["xstatus"] = "New";
                // hxstatus.Value = "Approved2";
                hiddenxstatus.Value = "New";
                // fnButtonState();
                BindGrid();
                //fnFillGrid2();

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
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
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCalendar(xdate);

                    zglobal.fnGetComboDataCD("Session", xsession);
                    zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    zglobal.fnPermission(xclass);



                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;

                    ViewState["msg"] = "1";
                    result.Visible = false;
                    barchart.Visible = false;
                    btnApprove.Visible = false;
                    btnSave.Visible = false;
                    //BindGrid();

                }

                fnFillDataGrid(null, null);
                // message.InnerHtml = "";

            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }

        }







    }
}