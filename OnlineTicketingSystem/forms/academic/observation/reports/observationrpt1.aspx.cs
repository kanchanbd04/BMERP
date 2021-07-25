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
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class observationrpt1 : System.Web.UI.Page
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
                message.InnerHtml = "";
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
        List<int> listmissedtest = new List<int>();
        List<string> listtrow = new List<string>();
        List<string> listmaxrtcount = new List<string>();
        List<string> listretestrow = new List<string>();
        private void BindGrid()
        {

            int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string xsession1 = xsession.Text.Trim().ToString();
            string xteacher1 = _teacher.Value.Trim().ToString();
            //message.InnerHtml = _zid.ToString() + " " + xsession1 + " " + xnumexam1 + " " + xclass1 + " " + xgroup1;
            //return;
            //string str = "SELECT   xrow,ROW_NUMBER() OVER (ORDER BY xstdid) AS xid, xname,xstdid FROM amstudentvw WHERE zid=@zid AND xsession=@xsession  AND xclass=@xclass AND xgroup=@xgroup AND xsection=@xsection ORDER BY xstdid";

            string str = "SELECT * FROM hrgrowthvw3 " +
                "WHERE zid=@zid and xtype='Teachers' and xsession=@xsession and xteacher=@xteacher order by xcodealt";


            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
            da.SelectCommand.Parameters.AddWithValue("@xteacher", xteacher1);
            
            //da.SelectCommand.Parameters.AddWithValue("@xsubject", xsubject.Text.ToString().Trim());
            //da.SelectCommand.Parameters.AddWithValue("@xpaper", xpaper.Text.ToString().Trim());
            da.Fill(dts, "tempztcode");
            DataTable dtmarks = new DataTable();
            dtmarks = dts.Tables[0];

            if (dtmarks.Rows.Count > 0)
            {
                observation.Visible = true;
                GridView1.Columns.Clear();

                bfield = new BoundField();
                bfield.HeaderText = "Details in Percentage:";
                bfield.HeaderStyle.HorizontalAlign=HorizontalAlign.Left;
                bfield.DataField = "xcat";
                bfield.ItemStyle.Width = 350;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                //bfield.ItemStyle.CssClass = "padding";
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

                bfield = new BoundField();
                bfield.HeaderText = "%";
                bfield.DataField = "xperc1";
                bfield.ItemStyle.Width = 50;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                bfield.HtmlEncode = false;
                GridView1.Columns.Add(bfield);

                TemplateField tfield2 = new TemplateField();
                tfield2.HeaderText = "";
                tfield2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(tfield2);

                decimal average = 0;
                int count1 = 0;
                foreach (DataRow row in dtmarks.Rows)
                {
                    average = average + Int32.Parse(row["xperc"].ToString());
                    count1 = count1 + 1;
                }

                average = Math.Ceiling(average/count1);

                DataRow row1 = dtmarks.NewRow();
                row1["xcat"] = "Average";
                row1["xperc1"] = average.ToString() + "%";
                dtmarks.Rows.Add(row1);

                GridView1.DataSource = dtmarks;
                GridView1.DataBind();
                message.InnerHtml = "";

                GridView1.Rows[GridView1.Rows.Count - 1].BackColor = Color.Pink;
                GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].ForeColor = Color.Brown;
                GridView1.Rows[GridView1.Rows.Count - 1].Cells[1].ForeColor = Color.Brown;
                GridView1.Rows[GridView1.Rows.Count - 1].Height = 30;

                HtmlGenericControl image = new HtmlGenericControl("img");
                image.ID = "image2";
                image.Attributes.Add("src", "/images/graph.jpg");
                image.Attributes.Add("class", "bm_academic_list2 bm_list");
                image.Attributes.Add("rowno", GridView1.Rows[GridView1.Rows.Count - 1].RowIndex.ToString());
                GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].Controls.Add(image);
                GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].HorizontalAlign=HorizontalAlign.Left;
                //GridView1.Rows[GridView1.Rows.Count - 1].Cells[2].VerticalAlign = VerticalAlign.Middle;

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Teacher Name
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                dts.Reset();

                str = "SELECT xname FROM hrmst " +
                    "WHERE zid=@zid and xemp=@xemp";


                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da1.SelectCommand.Parameters.AddWithValue("@xemp", xteacher1);

                da1.Fill(dts, "tempztcode");
                DataTable dttemp1 = new DataTable();
                dttemp1 = dts.Tables[0];
                xname.InnerHtml = dttemp1.Rows[0][0].ToString();
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                dts.Reset();

                str = "SELECT *,(SELECT xname FROM hrmst WHERE zid=hrgrowthh.zid and xemp=hrgrowthh.xpeer) as xpeer1, " +
                      "(CONVERT(varchar(3), xdate, 100)+'-'+CONVERT(varchar(10),day(xdate))) as xdate1 FROM hrgrowthh " +
                      "WHERE zid=@zid and xteacher=@xteacher and xsession=@xsession and xtype='Teachers' and xstatus='Submited'";


                SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);
                da2.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da2.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                da2.SelectCommand.Parameters.AddWithValue("@xteacher", xteacher1);

                da2.Fill(dts, "tempztcode");
                DataTable dttemp2 = new DataTable();
                dttemp2 = dts.Tables[0];
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Observation No
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                var query = from row in dttemp2.AsEnumerable()
                            group row by row.Field<string>("xaction") into action
                            orderby action.Key
                            select new
                            {
                                xaction = action.Key,
                                xcount = action.Count()
                            };

                string c = dttemp2.Rows.Count.ToString() + " [ ";
                int k = 1;
                foreach (var count in query)
                {
                    if (query.Count() == k)
                    {
                        c = c + count.xaction + "-" + count.xcount;
                    }
                    else
                    {
                        c = c + count.xaction + "-" + count.xcount + ", ";
                    }
                    k = k + 1;
                }
                c = c + " ]";

                xobserno.InnerHtml = c;
                ////////////////////////////////////////////////////////////////////////////////////////////////////


                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Observer
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                var query1 = from row in dttemp2.AsEnumerable()
                            group row by row.Field<string>("xpeer1") into peer
                             orderby peer.Key
                            select new
                            {
                                xpeer = peer.Key,
                                xcount = peer.Count()
                            };

                string c1 = query1.Count().ToString() + " [ ";
                k = 1;
                foreach (var count in query1)
                {
                    if (query1.Count() == k)
                    {
                        c1 = c1 + count.xpeer + "-" + count.xcount;
                    }
                    else
                    {
                        c1 = c1 + count.xpeer + "-" + count.xcount + ", ";
                    }
                    k = k + 1;
                }
                c1 = c1 + " ]";

                xpeer.InnerHtml = c1;
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Subject
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                var query2 = from row in dttemp2.AsEnumerable()
                             group row by row.Field<string>("xsubject") into subject
                             orderby subject.Key
                             select new
                             {
                                 xsubject = subject.Key,
                                 xcount = subject.Count()
                             };

                string c2 = query2.Count().ToString() + " [ ";
                k = 1;
                foreach (var count in query2)
                {
                    if (query2.Count() == k)
                    {
                        c2 = c2 + count.xsubject + "-" + count.xcount;
                    }
                    else
                    {
                        c2 = c2 + count.xsubject + "-" + count.xcount + ", ";
                    }
                    k = k + 1;
                }
                c2 = c2 + " ]";

                xsubject.InnerHtml = c2;
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //Date
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                var query3 = from row in dttemp2.AsEnumerable()
                             group row by row.Field<string>("xdate1") into date
                             orderby date.Key
                             select new
                             {
                                 xdate = date.Key,
                                 //xcount = peer.Count()
                             };

                string c3 = "";
                k = 1;
                foreach (var count in query3)
                {
                    if (query3.Count() == k)
                    {
                        c3 = c3 + count.xdate;
                    }
                    else
                    {
                        c3 = c3 + count.xdate + ", ";
                    }
                    k = k + 1;
                }

                xdate.InnerHtml = c3;
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                
               
            
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                observation.Visible = false;
                message.InnerHtml = "No data found";
            }



        }

        protected void GridView1_DataBound1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (GridView1.DataSource == null)
            //    {
            //        return;
            //    }

            //    //for merging retest column
            //    int k = 3;
            //    int l = k;
            //    //foreach (int data in (List<int>)ViewState["listretest"])
            //    //{
            //    //    GridView1.HeaderRow.Cells[k - 1].ColumnSpan = 2;
            //    //    GridView1.HeaderRow.Cells[k].Visible = false;

            //    //    if (data != 0)
            //    //    {
            //    //        GridView1.HeaderRow.Cells[k + 1].ColumnSpan = data;
            //    //        for (int m = 2; m <= data; m++)
            //    //        {
            //    //            GridView1.HeaderRow.Cells[k + m].Visible = false;
            //    //        }
            //    //        k = k + data + 2;
            //    //    }
            //    //    else
            //    //    {
            //    //        k = k + 2;
            //    //    }

            //    //}

            //    List<int> listrt = (List<int>)ViewState["listretest"];
            //    List<int> listmt = (List<int>)ViewState["listmissedtest"];

            //    for (int j = 0; j < listrt.Count; j++)
            //    {
            //        GridView1.HeaderRow.Cells[l - 1].ColumnSpan = 2;
            //        GridView1.HeaderRow.Cells[l].Visible = false;

            //        if (listrt[j] != 0)
            //        {
            //            GridView1.HeaderRow.Cells[k + 1].ColumnSpan = listrt[j];
            //            for (int m = 2; m <= listrt[j]; m++)
            //            {
            //                GridView1.HeaderRow.Cells[k + m].Visible = false;
            //            }
            //            k = k + listrt[j] + 2;
            //        }
            //        else
            //        {
            //            k = k + 2;
            //        }

            //        l = k;

            //        if (listmt[j] != 0)
            //        {
            //            GridView1.HeaderRow.Cells[l].ColumnSpan = listmt[j];
            //            for (int m = 1; m <= listmt[j]; m++)
            //            {
            //                GridView1.HeaderRow.Cells[l + m].Visible = false;
            //            }
            //            //l = l + listrt[j] + 2;
            //        }
            //        //else
            //        //{
            //        //    l = l + 2;
            //        //}
            //    }




            //}
            //catch (Exception exp)
            //{
            //    message.InnerHtml = exp.Message;
            //    message.Style.Value = zglobal.errormsg;
            //}

        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{

            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {

            //        Label lblno = new Label();
            //        lblno.Text = "";
            //        lblno.ID = "lblno";
            //        lblno.ForeColor = Color.Black;
            //        e.Row.Cells[0].Controls.Add(lblno);

            //        Label lblsubject = new Label();
            //        lblsubject.Text = "";
            //        lblsubject.ID = "lblsubject";
            //        lblsubject.ForeColor = Color.Black;
            //        e.Row.Cells[1].Controls.Add(lblsubject);

            //        //if ((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "")
            //        //{
            //        //    lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
            //        //                      (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
            //        //}
            //        //else
            //        //{
            //        //    lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
            //        //}

            //        if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != String.Empty) &&
            //            ((e.Row.DataItem as DataRowView).Row["xext"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() != String.Empty))
            //        {
            //            lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "(" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + ")" + "-" +
            //                              (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
            //        }
            //        else if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() != String.Empty) &&
            //       ((e.Row.DataItem as DataRowView).Row["xext"].ToString() == "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() == String.Empty))
            //        {
            //            lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "-" +
            //                              (e.Row.DataItem as DataRowView).Row["xpaper"].ToString();
            //        }
            //        else if (((e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == "" || (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() == String.Empty) &&
            //       ((e.Row.DataItem as DataRowView).Row["xext"].ToString() != "" || (e.Row.DataItem as DataRowView).Row["xext"].ToString() != String.Empty))
            //        {
            //            lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "(" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + ")";
            //        }
            //        else
            //        {
            //            lblsubject.Text = (e.Row.DataItem as DataRowView).Row["xsubject"].ToString();
            //        }


            //        int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
            //        List<string> list_t_row = (List<string>)ViewState["listtrow"];
            //        int retestcount = 0;
            //        int mtcount = 0;
            //        string xrefcttype1 = "";
            //        string xrefctno1 = "";
            //        for (int i = 2; i < 2 + (int)ViewState["rowCount"]; )
            //        {

            //            //Label lblmarks = new Label();
            //            //lblmarks.Text = "";
            //            //lblmarks.ID = "lblmarks" + i.ToString();
            //            //lblmarks.ForeColor = Color.Black;
            //            //lblmarks.Attributes.Add("runat", "server");
            //            ////lblmarks.Text = "1.00";
            //            ////lnkbtn.Click += OnLinkClick;
            //            //e.Row.Cells[i].Controls.Add(lblmarks);

            //            //e.Row.Cells[i].ToolTip = "Hi";

            //            //message.InnerHtml = message.InnerHtml + " " +e.Row.Cells[4 + (int) ViewState["rowCount"]].Text;
            //            // Int64 xsrow = Convert.ToInt64(e.Row.Cells[3 + (int)ViewState["rowCount"]].Text);


            //            ////var xmarks = from amexamd in ((DataTable)ViewState["amexamd"]).AsEnumerable()
            //            ////             where amexamd.Field<int>("zid") == _zid && amexamd.Field<int>("xrow") == Convert.ToInt32(list_t_row[i]) && amexamd.Field<Int64>("xsrow") == xsrow
            //            ////             select amexamd;
            //            /// 

            //            //message.InnerHtml = message.InnerHtml + ((List<string>) ViewState["listtrow"])[i - 2].ToString() + "<br>";
            //            Label lblmarks1 = new Label();
            //            Label lblmarks2 = new Label();
            //            Label lblmarks3 = new Label();
            //            Label lblmarks4 = new Label();

            //            if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-2")
            //            {
            //                lblmarks4 = new Label();
            //                lblmarks4.Text = "";
            //                lblmarks4.ID = "lblmarks" + i.ToString();
            //                lblmarks4.ForeColor = Color.Black;
            //                lblmarks4.Attributes.Add("runat", "server");
            //                //lblmarks.Text = "1.00";
            //                //lnkbtn.Click += OnLinkClick;
            //                e.Row.Cells[i].Controls.Add(lblmarks4);

            //            }
            //            else if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-1")
            //            {
            //                lblmarks1 = new Label();
            //                lblmarks1.Text = "";
            //                lblmarks1.ID = "lblmarks" + i.ToString();
            //                lblmarks1.ForeColor = Color.Black;
            //                lblmarks1.Attributes.Add("runat", "server");
            //                //lblmarks.Text = "1.00";
            //                //lnkbtn.Click += OnLinkClick;
            //                e.Row.Cells[i].Controls.Add(lblmarks1);

            //            }
            //            else
            //            {
            //                lblmarks2 = new Label();
            //                lblmarks2.Text = "";
            //                lblmarks2.ID = "lblmarks" + i.ToString();
            //                lblmarks2.ForeColor = Color.Black;
            //                lblmarks2.Attributes.Add("runat", "server");
            //                //lblmarks.Text = "1.00";
            //                //lnkbtn.Click += OnLinkClick;
            //                e.Row.Cells[i].Controls.Add(lblmarks2);

            //                lblmarks3 = new Label();
            //                lblmarks3.Text = "";
            //                lblmarks3.ID = "lblmarks" + (i + 1).ToString();
            //                lblmarks3.ForeColor = Color.Black;
            //                lblmarks3.Attributes.Add("runat", "server");
            //                //lblmarks.Text = "1.00";
            //                //lnkbtn.Click += OnLinkClick;
            //                e.Row.Cells[i + 1].Controls.Add(lblmarks3);

            //                string[] type = ((List<string>)ViewState["listtrow"])[i - 2].Split('-');
            //                xrefcttype1 = type[0];
            //                xrefctno1 = type[1];
            //                retestcount = 0;
            //                mtcount = 0;

            //            }

            //            //message.InnerHtml = message.InnerHtml + xrefcttype1 + "-" + xrefctno1 + "<br>";
            //            DataRow[] result =
            //                ((DataTable)ViewState["amexamd"]).Select("zid=" + _zid + " and xsubject='" +
            //                                                         (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
            //                                                         (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "'" + " and xext='" +
            //                                                         (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'" + " and xcttype='" + xrefcttype1 + "' and xctno='" + xrefctno1 + "'");

            //            if (result.Length > 0)
            //            {
            //                //if (result[0][0].ToString() != "-1.00")
            //                //{
            //                if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-2")
            //                {
            //                    //lblmarks1.Text = result[0][0].ToString();
            //                    //e.Row.Cells[i].ToolTip = "Topic : " + result[0][1].ToString() + "\n" + "Details : " +
            //                    //"\n" + result[0][2].ToString();

            //                    mtcount = mtcount + 1;
            //                    int xid = mtcount;

            //                    DataRow[] result1 = ((DataTable)ViewState["amexammissedtestvw"]).Select("zid=" + _zid + " and xsubject='" +
            //                                                     (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
            //                                                     (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xext='" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'" + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'" + " and xid=" +
            //                                                      xid);


            //                    if (result1.Length > 0)
            //                    {
            //                        lblmarks4.Text = result1[0][0].ToString();
            //                        e.Row.Cells[i].ToolTip = "Topic : " + result1[0][1].ToString() + "\n" + "Details : " +
            //                                                 "\n" + result1[0][2].ToString();
            //                    }
            //                    else
            //                    {
            //                        lblmarks4.Text = "";
            //                    }

            //                }
            //                else if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-1")
            //                {
            //                    //lblmarks1.Text = result[0][0].ToString();
            //                    //e.Row.Cells[i].ToolTip = "Topic : " + result[0][1].ToString() + "\n" + "Details : " +
            //                    //"\n" + result[0][2].ToString();

            //                    retestcount = retestcount + 1;
            //                    int xid = retestcount;

            //                    DataRow[] result1 = ((DataTable)ViewState["amexamretestvw"]).Select("zid=" + _zid + " and xsubject='" +
            //                                                     (e.Row.DataItem as DataRowView).Row["xsubject"].ToString() + "' and xpaper='" +
            //                                                     (e.Row.DataItem as DataRowView).Row["xpaper"].ToString() + "' and xext='" + (e.Row.DataItem as DataRowView).Row["xext"].ToString() + "'" + " and xrefcttype='" + xrefcttype1 + "' and xrefctno='" + xrefctno1 + "'" + " and xid=" +
            //                                                      xid);


            //                    if (result1.Length > 0)
            //                    {
            //                        lblmarks1.Text = result1[0][0].ToString();
            //                        e.Row.Cells[i].ToolTip = "Topic : " + result1[0][1].ToString() + "\n" + "Details : " +
            //                                                 "\n" + result1[0][2].ToString();
            //                    }
            //                    else
            //                    {
            //                        lblmarks1.Text = "";
            //                    }

            //                }
            //                else
            //                {
            //                    if (result[0][0].ToString() != "-1.00")
            //                    {
            //                        lblmarks2.Text =
            //                            Convert.ToDateTime(result[0][3].ToString()).ToString("dd/MM/yy") + "<br/>" +
            //                            "Marks:" + Convert.ToDecimal(result[0][4].ToString()).ToString("###");
            //                        lblmarks2.Font.Size = 9;
            //                        lblmarks3.Text = result[0][0].ToString();
            //                        e.Row.Cells[i + 1].ToolTip = "Topic : " + result[0][1].ToString() + "\n" +
            //                                                     "Details : " +
            //                                                     "\n" + result[0][2].ToString();
            //                    }
            //                    else
            //                    {
            //                        lblmarks2.Text = "";
            //                        lblmarks3.Text = "";
            //                    }
            //                }
            //                //}
            //                //else
            //                //{
            //                //    lblmarks1.Text = "";
            //                //    lblmarks2.Text = "";
            //                //    lblmarks3.Text = "";
            //                //    lblmarks4.Text = "";
            //                //}
            //            }
            //            else
            //            {
            //                lblmarks1.Text = "";
            //                lblmarks2.Text = "";
            //                lblmarks3.Text = "";
            //            }

            //            if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-2")
            //            {
            //                i = i + 1;
            //            }
            //            else if (((List<string>)ViewState["listtrow"])[i - 2].ToString() == "-1")
            //            {
            //                i = i + 1;
            //            }
            //            else
            //            {
            //                i = i + 2;
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


        protected void combo_OnTextChanged(object sender, EventArgs e)
        {
            try
            {

                message.InnerHtml = "";

                ////xname.Text = "";
                //_student.Value = "";
                //xteacher.Text = "";
                //_teacher.Value = "";

                ////GridView1.DataSource = null;
                ////GridView1.DataBind();

                //observation.

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
                    //zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    //zglobal.fnGetComboDataCalendar(xdate);

                    zglobal.fnGetComboDataCD("Session", xsession);
                    //zglobal.fnGetComboDataCD("Term", xterm);
                    //zglobal.fnGetComboDataCD("Class", xclass);
                    //zglobal.fnGetComboDataCD("Education Group", xgroup);
                    ////zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                    //zglobal.fnGetComboDataCD("Section", xsection);
                    ////zglobal.fnGetComboDataCD("Class Subject", xsubject);

                    ViewState["xrow"] = null;

                    xsession.Text = zglobal.fnDefaults("xsession", "Student");
                    //xterm.Text = zglobal.fnDefaults("xterm", "Student");

                    //BindGrid();
                    observation.Visible = false;

                }



            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
            }
            
        }



        [WebMethod(EnableSession = true)]
        public static string fnFetchData(string xsession1, string xteacher1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));



                using (SqlConnection con = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts1 = new DataSet())
                    {
                        string query = "select zid,xtype,xsession,xteacher,xobserno,count(xcomment) as xtotal , " +
                                       "sum(xyes) as xyes,round(sum(xyes)*100/count(xcomment),0) as xperc " +
                                       "from hrgrowthvw " +
                                       "where xcomment<>'N/A' and xstatus='Submited' " +
                                       "and zid=@zid AND xteacher=@xteacher and xtype='Teachers' " +
                                       "group by zid,xtype,xsession,xteacher,xobserno " ;

                        SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                        da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da1.SelectCommand.Parameters.AddWithValue("@xsession", xsession1);
                        da1.SelectCommand.Parameters.AddWithValue("@xteacher", xteacher1);

                        da1.Fill(dts1, "tempztcode");
                        DataTable dtamexamd = new DataTable();
                        dtamexamd = dts1.Tables[0];
                        if (dtamexamd.Rows.Count > 0)
                        {
                            string obserno = "";
                            string perc = "";

                            for (int i = 0; i < dtamexamd.Rows.Count; i++)
                            {
                                if (i == dtamexamd.Rows.Count - 1)
                                {
                                    obserno = obserno + dtamexamd.Rows[i]["xobserno"].ToString();
                                    perc = perc + dtamexamd.Rows[i]["xperc"].ToString();
                                }
                                else
                                {
                                    obserno = obserno + dtamexamd.Rows[i]["xobserno"].ToString() + ",";
                                    perc = perc + dtamexamd.Rows[i]["xperc"].ToString() + ",";
                                }
                            }

                            return "success" + "|" + obserno + "|" + perc ;
                        }
                        else
                        {
                            return "nodata";
                        }
                    }
                }



            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }


        
    }
}