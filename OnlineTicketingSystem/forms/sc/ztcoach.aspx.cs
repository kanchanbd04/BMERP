using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace OnlineTicketingSystem.forms.sc
{
    public partial class ztcoach : System.Web.UI.Page
    {
        //int counter;
        //DataTable ztrtid = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztcoach");
                if (s == "n" || s == "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                zactive.Checked = true;

                rtcount.Value = "";

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();
                dts.Reset();
                string str = "SELECT xname FROM ztcode  WHERE xtype='Bus' AND zactive=1 ORDER BY xname";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.Fill(dts, "tempzt");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                if (dtztcode.Rows.Count > 0)
                {
                    xbustype.Items.Add("[Select]");
                    for (int i = 0; i < dtztcode.Rows.Count; i++)
                    {
                        xbustype.Items.Add(dtztcode.Rows[i][0].ToString());
                    }

                    xbustype.Text = "[Select]";
                }

                str = "SELECT (xmf + '-' + xmt) as mainrt, xmrid FROM ztrtm WHERE zactive=1 ";

                SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);
                da2.Fill(dts, "tempdtrtm");
                DataTable dtrtm = new DataTable();
                dtrtm = dts.Tables[1];

                if (dtrtm.Rows.Count > 0)
                {
                    xmainrt.Items.Add("[Select]");
                    for (int i = 0; i < dtrtm.Rows.Count; i++)
                    {
                        xmainrt.Items.Add(dtrtm.Rows[i][0].ToString());
                    }
                    xmainrt.Text = "[Select]";
                }

                populateDataGrid();


            }


            if (ViewState["labelsAdded"] == null)
            {
                ViewState["labelsAdded"] = 1;
                //counter = 1;
            }

            credyctl();

            PlaceHolder1.Controls.Clear();
            rtcon();



        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xcoachno,xbustype,(select (xmf + '-' + xmt) from ztrtm where ztrtm.xmrid=ztcoach.xmrid) as xmainrt, (xmrtimeh + ':' + xmrtimem + ' ' + xmrtimei) as xtime, zactive, xapprove FROM ztcoach  WHERE zactive=1";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "temp");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];
            GridView2.DataSource = dtztemp;
            GridView2.DataBind();
            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        private int maxrow(string query)
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = query;

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);



            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];







            int maxrow;
            if (!Convert.IsDBNull(dttemp.Rows[0][0]))
            {
                int srtnm = int.Parse(dttemp.Rows[0][0].ToString());
                maxrow = srtnm + 1;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = 100;
            }


            da.Dispose();
            dts.Dispose();
            conn1.Dispose();

            return maxrow;

        }

        private void saveAndUpdate(string str)
        {


            using (TransactionScope tran = new TransactionScope())
            {

                SqlConnection conn1;
                SqlCommand dataCmd;

                if (str == "delete")
                {
                    SqlConnection conn111;
                    SqlCommand dataCmd111;
                    conn111 = new SqlConnection(zglobal.constring);
                    dataCmd111 = new SqlCommand();
                    dataCmd111.Connection = conn111;
                    string query111;
                    try
                    {
                        if (str == "delete")
                        {
                            query111 = "DELETE FROM ztcoachcounter WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;
                            string xcoachno111 = xcoachno.Text.ToString().Trim();

                            dataCmd111.Parameters.AddWithValue("@xcoachno", xcoachno111);
                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();

                            query111 = "DELETE FROM ztcoachsubrt WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;
                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();

                            query111 = "DELETE FROM ztcoach WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;
                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();


                        }
                        else
                        {
                            query111 = "UPDATE ztcoach SET " +
                                                 "zactive=1, xapprove='Confirmed' " +
                                                 "WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;

                            string xcoachno1111 = xcoachno.Text.ToString().Trim();

                            dataCmd111.Parameters.AddWithValue("@xcoachno", xcoachno1111);

                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();
                        }
                    }
                    catch (Exception exp)
                    {
                        msg.InnerHtml = exp.Message;
                    }
                }
                else if (str == "confirm")
                {
                    SqlConnection conn111;
                    SqlCommand dataCmd111;
                    conn111 = new SqlConnection(zglobal.constring);
                    dataCmd111 = new SqlCommand();
                    dataCmd111.Connection = conn111;
                    string query111;
                    try
                    {
                        if (str == "delete")
                        {
                            query111 = "DELETE FROM ztcoachcounter WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;
                            string xcoachno111 = xcoachno.Text.ToString().Trim();

                            dataCmd111.Parameters.AddWithValue("@xcoachno", xcoachno111);
                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();

                            query111 = "DELETE FROM ztcoachsubrt WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;
                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();

                            query111 = "DELETE FROM ztcoach WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;
                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();


                        }
                        else
                        {
                            query111 = "UPDATE ztcoach SET " +
                                                 "zactive=1, xapprove='Confirmed' " +
                                                 "WHERE xcoachno=@xcoachno";

                            dataCmd111.CommandText = query111;

                            string xcoachno1111 = xcoachno.Text.ToString().Trim();

                            dataCmd111.Parameters.AddWithValue("@xcoachno", xcoachno1111);

                            conn111.Close();
                            conn111.Open();
                            dataCmd111.ExecuteNonQuery();
                            conn111.Close();
                        }
                    }
                    catch (Exception exp)
                    {
                        msg.InnerHtml = exp.Message;
                    }
                }
                else
                {

                    //SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;
                    if (str == "save")
                    {
                        query = "INSERT INTO ztcoach" +
                                       "(xcoachno,xbustype,xmrid,xmrtimeh,xmrtimem,xmrtimei,zactive,xcreatedby,xcreatedt,xapprove) " +
                                       "VALUES (@xcoachno,@xbustype,@xmrid,@xmrtimeh,@xmrtimem,@xmrtimei,@zactive,@xcreatedby,@xcreatedt,'New') ";
                    }
                    else if (str == "update")
                    {

                        query = "UPDATE ztcoach SET " +
                                              "xbustype=@xbustype,xmrid=@xmrid,xmrtimeh=@xmrtimeh,xmrtimem=@xmrtimem,xmrtimei=@xmrtimei,zactive=@zactive " +
                                              "WHERE xcoachno=@xcoachno";

                    }
                    else
                    {
                        query = "";
                    }
                    dataCmd.CommandText = query;


                    string xcoachno1 = xcoachno.Text.ToString().Trim();

                    dataCmd.Parameters.AddWithValue("@xcoachno", xcoachno1);

                    if (str == "save")
                    {

                    }
                    else
                    {

                    }








                    //if (str != "delete")
                    //{

                    string xbustype1 = xbustype.Text.ToString();

                    ///////////////////////////////////////////////////
                    string qur = "select xmrid from ztrtm where xmf=@xmf and xmt=@xmt";
                    SqlDataAdapter da = new SqlDataAdapter(qur, conn1);
                    DataSet dts = new DataSet();
                    string[] mrid = xmainrt.Text.ToString().Split('-');
                    string xmf = mrid[0];
                    string xmt = mrid[1];
                    da.SelectCommand.Parameters.AddWithValue("@xmf", xmf);
                    da.SelectCommand.Parameters.AddWithValue("@xmt", xmt);
                    da.Fill(dts, "temp");
                    DataTable dttemp = new DataTable();
                    dttemp = dts.Tables[0];
                    //////////////////////////////////////////////////////

                    string xmrid1 = dttemp.Rows[0][0].ToString();
                    string xmrtimeh = "";
                    string xmrtimem = "";
                    string xmrtimei = "";
                    //////////////////////////////////////////////////////////////////


                    string mrrow = xmainrt.Text.ToString();
                    for (int i = 0; i < int.Parse(rtcount.Value); i++)
                    {

                        if (((Label)PlaceHolder1.FindControl("rt" + i)).Text.ToString() == mrrow)
                        {
                            xmrtimeh = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dwh" + i)).SelectedItem.Text);
                            xmrtimem = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dwm" + i)).SelectedItem.Text);
                            xmrtimei = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dwi" + i)).SelectedItem.Text);
                            break;
                        }

                    }
                    //////////////////////////////////////////////////////////////////

                    int zactive1;
                    if (zactive.Checked == true)
                    {
                        zactive1 = 1;
                    }
                    else
                    {
                        zactive1 = 0;
                    }
                    string xcreatedby = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xcreatedt = DateTime.Now.ToString();


                    dataCmd.Parameters.AddWithValue("@xbustype", xbustype1);
                    dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);
                    dataCmd.Parameters.AddWithValue("@xmrtimeh", xmrtimeh);
                    dataCmd.Parameters.AddWithValue("@xmrtimem", xmrtimem);
                    dataCmd.Parameters.AddWithValue("@xmrtimei", xmrtimei);
                    dataCmd.Parameters.AddWithValue("@zactive", zactive1);
                    dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby);
                    dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt);



                    //}

                    conn1.Close();
                    conn1.Open();
                    //SqlTransaction transec = conn1.BeginTransaction("tran");
                    int xy = 0;

                    try
                    {
                        //dataCmd.Transaction = transec;

                        dataCmd.ExecuteNonQuery();

                        conn1.Close();
                        ///////////////////////////////////////////

                        if (int.Parse(rtcount.Value) > 1)
                        {



                            if (str == "update")
                            {
                                SqlConnection conn12;
                                conn12 = new SqlConnection(zglobal.constring);


                                string query123 = "DELETE FROM ztcoachsubrt WHERE xcoachno=@xcoachno";

                                SqlCommand cm1 = new SqlCommand();
                                cm1.Connection = conn12;
                                cm1.CommandText = query123;
                                cm1.Parameters.AddWithValue("@xcoachno", xcoachno1);
                                conn12.Close();
                                conn12.Open();
                                cm1.ExecuteNonQuery();
                                conn12.Close();
                            }

                            int subrtxid1;

                            string xsrid;
                            string xsrtimeh;
                            string xsrtimem;
                            string xsrtimei;

                            for (int i = 0; i < int.Parse(rtcount.Value); i++)
                            {

                                if (((Label)PlaceHolder1.FindControl("rt" + i)).Text.ToString() != mrrow)
                                {





                                    string query1 = "";



                                    SqlConnection conn11;
                                    conn11 = new SqlConnection(zglobal.constring);
                                    SqlCommand dataCmd1 = new SqlCommand();
                                    dataCmd1.Connection = conn11;


                                    query1 = "INSERT INTO ztcoachsubrt" +
                                                     "(xcsrtid,xcoachno,xsrid,xsrtimeh,xsrtimem,xsrtimei) " +
                                                     "VALUES (@xcsrtid,@xcoachno,@xsrid,@xsrtimeh,@xsrtimem,@xsrtimei) ";

                                    dataCmd1.CommandText = query1;


                                    subrtxid1 = maxrow("select max(xcsrtid) from ztcoachsubrt");
                                    //subrtxid1 = subrtxid1 + 1;
                                    dataCmd1.Parameters.AddWithValue("@xcsrtid", subrtxid1);
                                    dataCmd1.Parameters.AddWithValue("@xcoachno", xcoachno1);
                                    ////////////////////////////////

                                    string q = "select xsrid from ztrts where xsf=@xsf and xst=@xst and xmrid=@xmrid";
                                    SqlDataAdapter da1 = new SqlDataAdapter(q, conn1);
                                    DataSet dts1 = new DataSet();
                                    string[] srid = ((Label)PlaceHolder1.FindControl("rt" + i)).Text.ToString().Split('-');
                                    string xsf = srid[0];
                                    string xst = srid[1];
                                    da1.SelectCommand.Parameters.AddWithValue("@xsf", xsf);
                                    da1.SelectCommand.Parameters.AddWithValue("@xst", xst);
                                    da1.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                                    da1.Fill(dts1, "temp");
                                    DataTable dttemp1 = new DataTable();
                                    dttemp1 = dts1.Tables[0];

                                    xsrid = dttemp1.Rows[0][0].ToString();
                                    // xsrid = "10001";

                                    /////////////////////////////////

                                    xsrtimeh = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dwh" + i)).SelectedItem.Text);
                                    xsrtimem = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dwm" + i)).SelectedItem.Text);
                                    xsrtimei = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dwi" + i)).SelectedItem.Text);

                                    dataCmd1.Parameters.AddWithValue("@xsrid", xsrid);
                                    dataCmd1.Parameters.AddWithValue("@xsrtimeh", xsrtimeh);
                                    dataCmd1.Parameters.AddWithValue("@xsrtimem", xsrtimem);
                                    dataCmd1.Parameters.AddWithValue("@xsrtimei", xsrtimei);

                                    //xy = xy + 1;
                                    conn11.Close();
                                    conn11.Open();
                                    //dataCmd1.Transaction = transec;
                                    dataCmd1.ExecuteNonQuery();
                                    conn11.Close();

                                }

                            }/////////////

                            //dataCmd.ExecuteNonQuery();
                        }
                        ////////////////////////////////////////////


                        ///////////////////////////////////////////////////

                        if (ViewState["labelsAdded"] != null)
                        {

                            if (str == "update")
                            {
                                SqlConnection conn12;
                                conn12 = new SqlConnection(zglobal.constring);


                                string query111 = "DELETE FROM ztcoachcounter WHERE xcoachno=@xcoachno";

                                SqlCommand cm1 = new SqlCommand();
                                cm1.Connection = conn12;
                                cm1.CommandText = query111;
                                cm1.Parameters.AddWithValue("@xcoachno", xcoachno1);
                                conn12.Close();
                                conn12.Open();
                                cm1.ExecuteNonQuery();
                                conn12.Close();
                            }

                            for (int i = 1; i <= (int)ViewState["labelsAdded"]; i++)
                            {
                                //for (int j = 0; j < dtztcc.Columns.Count; j++)
                                //{


                                string query11 = "";




                                SqlConnection conn;
                                conn = new SqlConnection(zglobal.constring);
                                SqlCommand Cmd = new SqlCommand();
                                Cmd.Connection = conn;


                                query11 = "INSERT INTO ztcoachcounter" +
                                              "(xccid,xcoachno,xcname,xctimeh,xctimem,xctimei) " +
                                              "VALUES (@xccid,@xcoachno,@xcname,@xctimeh,@xctimem,@xctimei) ";


                                Cmd.CommandText = query11;

                                int counterxid1 = maxrow("select max(xccid) from ztcoachcounter");
                                string xcname = ((DropDownList)PlaceHolder3.FindControl("dwc" + i)).SelectedItem.Text.ToString();
                                string xctimeh = ((DropDownList)PlaceHolder3.FindControl("dwhh" + i)).SelectedItem.Text.ToString();
                                string xctimem = ((DropDownList)PlaceHolder3.FindControl("dwmm" + i)).SelectedItem.Text.ToString();
                                string xctimei = ((DropDownList)PlaceHolder3.FindControl("dwii" + i)).SelectedItem.Text.ToString();

                                //Response.Write(counterxid1 + " " + xcname + " " + xctimeh + "<br/>");

                                Cmd.Parameters.AddWithValue("@xccid", counterxid1);
                                Cmd.Parameters.AddWithValue("@xcoachno", xcoachno1);
                                Cmd.Parameters.AddWithValue("@xcname", xcname);
                                Cmd.Parameters.AddWithValue("@xctimeh", xctimeh);
                                Cmd.Parameters.AddWithValue("@xctimem", xctimem);
                                Cmd.Parameters.AddWithValue("@xctimei", xctimei);
                                //xy = xy + 1;
                                conn.Close();
                                conn.Open();

                                Cmd.ExecuteNonQuery();
                                conn.Close();
                                //}


                            }
                        }

                        ///////////////////////////////////////////////////


                        //transec.Commit();
                        conn1.Close();

                    }
                    catch (Exception exp)
                    {
                        msg.InnerHtml = exp.Message;
                        //transec.Rollback();
                    }
                }

                tran.Complete();

                //dataCmd.Dispose();
                //conn1.Dispose();
            }
            //if (xhsub1 == 1 && str == "update")
            //{


            //}

            //-------------------------------------------------//
            populateDataGrid();

            //-------------------------------------------------//

            
            if (str == "save")
            {
                msg.InnerText = "Successfully add data.";
                //msg.InnerHtml = Convert.ToString(dtztcc.Rows.Count);
            }
            else if (str == "update")
            {
                msg.InnerText = "Successfully update data.";
            }
            else if (str == "confirm")
            {
                msg.InnerText = "Successfully Confirm.";
                //btnAdd.Enabled = false;
                //btnUpdate.Enabled = false;
                //btnDelete.Enabled = false;
            }
            else
            {
                msg.InnerText = "Successfully delete data.";
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            xcoachno.Text = "";
            xcoachno.ReadOnly = false;
            xbustype.Text = "[Select]";
            xmainrt.Text = "[Select]";
            ViewState["labelsAdded"] = 1;
            PlaceHolder1.Controls.Clear();
            PlaceHolder3.Controls.Clear();
            msg.InnerHtml = "";
            zactive.Checked = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            //btnDelete.Enabled = true;

            crectl(1);
        }

        string pk;

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xcoachno FROM ztcoach ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempz");

            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];

            if (dtztemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtztemp.Rows.Count; i++)
                {
                    //for (int j = 0; j < 1; j++)
                    //{
                    if (dtztemp.Rows[i][0].ToString().Trim() == xcoachno.Text.ToString().Trim())
                    {
                        pk = dtztemp.Rows[i][0].ToString();
                        //currow = i;
                        dts.Dispose();
                        dtztemp.Dispose();
                        da.Dispose();
                        conn1.Dispose();
                        return;
                    }
                    //}
                }
            }
            pk = "false";

            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }





        //Adding columns to datatable


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (xcoachno.Text == "" || xbustype.Text == "[Select]" || xmainrt.Text == "[Select]")
                {
                    msg.InnerHtml = "Should fill the Coachno, Bus Type and Main Route field.";
                    return;
                }

                if (rtcount.Value != "")
                {
                    for (int i = 0; i < int.Parse(rtcount.Value); i++)
                    {
                        if (((DropDownList)PlaceHolder1.FindControl("dwh" + i)).SelectedItem.Text == "--")
                        {
                            msg.InnerHtml = "Should fill all time field";
                            return;
                        }

                    }
                }
                else
                {
                    return;
                }

                if (ViewState["labelsAdded"] != null)
                {
                    int howMany = (int)ViewState["labelsAdded"];
                    //counter = howMany;
                    for (int i = 1; i <= howMany; i++)
                    {
                        if (((DropDownList)PlaceHolder3.FindControl("dwhh" + i)).SelectedItem.Text == "--" || ((DropDownList)PlaceHolder3.FindControl("dwc" + i)).SelectedItem.Text == "[Select]")
                        {
                            msg.InnerHtml = "Should select counter and fill its time";


                            return;
                        }
                        //else
                        //{
                        //    int counterxid1 = maxrow("select max(xccid) from ztcoachcounter");
                        //    string dwc1 = ((DropDownList)PlaceHolder3.FindControl("dwc" + i)).SelectedItem.Text.ToString();
                        //    string dwhh1 = ((DropDownList)PlaceHolder3.FindControl("dwhh" + i)).SelectedItem.Text.ToString();
                        //    string dwmm1 = ((DropDownList)PlaceHolder3.FindControl("dwmm" + i)).SelectedItem.Text.ToString();
                        //    string dwii1 = ((DropDownList)PlaceHolder3.FindControl("dwii" + i)).SelectedItem.Text.ToString();

                        //    //Response.Write(counterxid1 + " " + dwc1 + " " + dwhh1 + "<br/>");
                        //    // Response.Write("hi");


                        //}
                    }
                }
                else
                {
                    return;
                }

                checkpk();
                if (pk != "false")
                {
                    msg.InnerHtml = "Cann't insert duplicate data. Please try again";

                }
                else
                {

                    saveAndUpdate("save");

                }
                //msg.InnerHtml = "success";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (xcoachno.Text == "" || xbustype.Text == "[Select]" || xmainrt.Text == "[Select]")
                {
                    msg.InnerHtml = "Should fill the Coachno, Bus Type and Main Route field.";
                    return;
                }

                if (rtcount.Value != "")
                {
                    for (int i = 0; i < int.Parse(rtcount.Value); i++)
                    {
                        if (((DropDownList)PlaceHolder1.FindControl("dwh" + i)).SelectedItem.Text == "--")
                        {
                            msg.InnerHtml = "Should fill all time field";
                            return;
                        }

                    }
                }
                else
                {
                    return;
                }

                if (ViewState["labelsAdded"] != null)
                {
                    int howMany = (int)ViewState["labelsAdded"];
                    //counter = howMany;
                    for (int i = 1; i <= howMany; i++)
                    {
                        if (((DropDownList)PlaceHolder3.FindControl("dwhh" + i)).SelectedItem.Text == "--" || ((DropDownList)PlaceHolder3.FindControl("dwc" + i)).SelectedItem.Text == "[Select]")
                        {
                            msg.InnerHtml = "Should select counter and fill its time";


                            return;
                        }
                        //else
                        //{
                        //    int counterxid1 = maxrow("select max(xccid) from ztcoachcounter");
                        //    string dwc1 = ((DropDownList)PlaceHolder3.FindControl("dwc" + i)).SelectedItem.Text.ToString();
                        //    string dwhh1 = ((DropDownList)PlaceHolder3.FindControl("dwhh" + i)).SelectedItem.Text.ToString();
                        //    string dwmm1 = ((DropDownList)PlaceHolder3.FindControl("dwmm" + i)).SelectedItem.Text.ToString();
                        //    string dwii1 = ((DropDownList)PlaceHolder3.FindControl("dwii" + i)).SelectedItem.Text.ToString();

                        //    //Response.Write(counterxid1 + " " + dwc1 + " " + dwhh1 + "<br/>");
                        //    // Response.Write("hi");


                        //}
                    }
                }
                else
                {
                    return;
                }

                checkpk();
                if (pk == "false")
                {
                    msg.InnerHtml = "Data not found";

                }
                else
                {

                    saveAndUpdate("update");

                }
                //msg.InnerHtml = "success";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtconformmessageValue.Value == "Yes")
                {

                    if (xcoachno.Text == "")
                    {
                        msg.InnerHtml = "Please select coach from list.";
                        return;
                    }
                    checkpk();
                    if (pk == "false")
                    {
                        msg.InnerHtml = "Data not found";

                    }
                    else
                    {

                        saveAndUpdate("delete");

                    }

                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }


        private void rtcon()
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                if (xmainrt.Text == "[Select]")
                {
                    return;
                }


                string[] mrid = xmainrt.Text.ToString().Split('-');

                string xmf1 = mrid[0];
                string xmt1 = mrid[1];

                string query = "SELECT xmrid FROM ztrtm WHERE xmf=@xmf AND xmt=@xmt";

                SqlDataAdapter da1 = new SqlDataAdapter(query, conn);

                da1.SelectCommand.Parameters.AddWithValue("@xmf", xmf1);
                da1.SelectCommand.Parameters.AddWithValue("@xmt", xmt1);

                dts.Reset();

                da1.Fill(dts, "tempdt");

                DataTable dtmrid = new DataTable();

                dtmrid = dts.Tables[0];

                string xmrid1 = dtmrid.Rows[0][0].ToString();


                query = "(SELECT (xmf + '-' + xmt) as route FROM ztrtm WHERE zactive=1 AND xmrid=@xmrid) "
                               + " UNION "
                               + " (SELECT (xsf + '-' + xst) as route FROM ztrts WHERE zactive=1 AND xmrid=@xmrid)";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                dts.Reset();
                da.Fill(dts, "tempdtrt");
                DataTable ztrt = new DataTable();
                ztrt = dts.Tables[0];

                if (ztrt.Rows.Count > 0)
                {
                    rtcount.Value = ztrt.Rows.Count.ToString();

                    PlaceHolder1.Controls.Add(new LiteralControl("<table>"));

                    for (int x = 0; x < ztrt.Rows.Count; x++)
                    {


                        Label mylabel = new Label();
                        DropDownList mydwh = new DropDownList();
                        DropDownList mydwm = new DropDownList();
                        DropDownList mydwi = new DropDownList();

                        mydwh.Items.Add("--");
                        mydwh.Items.Add("01");
                        mydwh.Items.Add("02");
                        mydwh.Items.Add("03");
                        mydwh.Items.Add("04");
                        mydwh.Items.Add("05");
                        mydwh.Items.Add("06");
                        mydwh.Items.Add("07");
                        mydwh.Items.Add("08");
                        mydwh.Items.Add("09");
                        mydwh.Items.Add("10");
                        mydwh.Items.Add("11");
                        mydwh.Items.Add("12");

                        mydwm.Items.Add("00");
                        mydwm.Items.Add("01");
                        mydwm.Items.Add("02");
                        mydwm.Items.Add("03");
                        mydwm.Items.Add("04");
                        mydwm.Items.Add("05");
                        mydwm.Items.Add("06");
                        mydwm.Items.Add("07");
                        mydwm.Items.Add("08");
                        mydwm.Items.Add("09");
                        for (int i = 10; i < 60; i++)
                        {
                            mydwm.Items.Add(i.ToString());
                        }

                        mydwi.Items.Add("am");
                        mydwi.Items.Add("pm");






                        PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

                        mylabel.Text = ztrt.Rows[x][0].ToString();
                        mylabel.ID = "rt" + x.ToString();
                        mydwh.ID = "dwh" + x.ToString();
                        mydwm.ID = "dwm" + x.ToString();
                        mydwi.ID = "dwi" + x.ToString();

                        PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        PlaceHolder1.Controls.Add(mylabel);
                        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                        PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        PlaceHolder1.Controls.Add(mydwh);
                        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                        PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        PlaceHolder1.Controls.Add(mydwm);
                        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                        PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        PlaceHolder1.Controls.Add(mydwi);
                        PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                        PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));



                    }

                    PlaceHolder1.Controls.Add(new LiteralControl("</table>"));
                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }




        protected void xmainrt_SelectedIndexChanged(object sender, EventArgs e)
        {

            PlaceHolder1.Controls.Clear();
            rtcon();
        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {


            if (ViewState["labelsAdded"] == null)
            {
                ViewState["labelsAdded"] = 1;
            }

            ViewState["labelsAdded"] = 1 + (int)ViewState["labelsAdded"];



            crectl((int)ViewState["labelsAdded"]);

        }

        protected void credyctl()
        {
            if (ViewState["labelsAdded"] != null)
            {
                int howMany = (int)ViewState["labelsAdded"];
                for (int i = 1; i <= howMany; i++)
                {
                    crectl(i);
                }
            }
        }

        private void crectl(int k)
        {
            try
            {


                DropDownList mydwc = new DropDownList();
                DropDownList mydwh = new DropDownList();
                DropDownList mydwm = new DropDownList();
                DropDownList mydwi = new DropDownList();

                SqlConnection conn;
                conn = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                string query = "SELECT xcname FROM ztcounter WHERE zactive=1";

                SqlDataAdapter da1 = new SqlDataAdapter(query, conn);



                dts.Reset();

                da1.Fill(dts, "tempdt");

                DataTable dtcoun = new DataTable();

                dtcoun = dts.Tables[0];

                mydwc.Items.Add("[Select]");
                if (dtcoun.Rows.Count > 0)
                {
                    for (int i = 0; i < dtcoun.Rows.Count; i++)
                    {
                        mydwc.Items.Add(dtcoun.Rows[i][0].ToString());
                    }
                }



                mydwh.Items.Add("--");
                mydwh.Items.Add("01");
                mydwh.Items.Add("02");
                mydwh.Items.Add("03");
                mydwh.Items.Add("04");
                mydwh.Items.Add("05");
                mydwh.Items.Add("06");
                mydwh.Items.Add("07");
                mydwh.Items.Add("08");
                mydwh.Items.Add("09");
                mydwh.Items.Add("10");
                mydwh.Items.Add("11");
                mydwh.Items.Add("12");

                mydwm.Items.Add("00");
                mydwm.Items.Add("01");
                mydwm.Items.Add("02");
                mydwm.Items.Add("03");
                mydwm.Items.Add("04");
                mydwm.Items.Add("05");
                mydwm.Items.Add("06");
                mydwm.Items.Add("07");
                mydwm.Items.Add("08");
                mydwm.Items.Add("09");
                for (int i = 10; i < 60; i++)
                {
                    mydwm.Items.Add(i.ToString());
                }

                mydwi.Items.Add("am");
                mydwi.Items.Add("pm");

                mydwc.ID = "dwc" + k.ToString();
                mydwh.ID = "dwhh" + k.ToString();
                mydwm.ID = "dwmm" + k.ToString();
                mydwi.ID = "dwii" + k.ToString();

                mydwc.EnableViewState = true;
                mydwh.EnableViewState = true;
                mydwm.EnableViewState = true;
                mydwi.EnableViewState = true;

                PlaceHolder3.Controls.Add(mydwc);
                PlaceHolder3.Controls.Add(mydwh);
                PlaceHolder3.Controls.Add(mydwm);
                PlaceHolder3.Controls.Add(mydwi);

                PlaceHolder3.Controls.Add(new LiteralControl("<br />"));


            }
            catch (Exception exp)
            {
                //msg.InnerHtml = exp.Message;
            }
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                //msg.InnerHtml = "User : " + ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                xcoachno.ReadOnly = true;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xcoachno1 = ((LinkButton)sender).Text;


                string str = "SELECT xcoachno,xbustype,(select (xmf + '-' + xmt) from ztrtm where ztrtm.xmrid=ztcoach.xmrid) as xmainrt,xmrtimeh,xmrtimem,xmrtimei,zactive,xmrid,xapprove FROM ztcoach where xcoachno=@xcoachno";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
                da.Fill(dts, "temp");

                DataTable dtztcoach = new DataTable();
                dtztcoach = dts.Tables[0];

                xcoachno.Text = dtztcoach.Rows[0][0].ToString();
                xbustype.Text = dtztcoach.Rows[0][1].ToString();
                xmainrt.Text = dtztcoach.Rows[0][2].ToString();

                if (dtztcoach.Rows[0][6].ToString() == "1")
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }

                ///////////////////////////////////////////
                ///fill subroute
                ///
                PlaceHolder1.Controls.Clear();
                rtcon();

                DataSet dts1 = new DataSet();






                //string str1 = "SELECT * FROM ztcoachsubrt where xcoachno=@xcoachno";
                //SqlDataAdapter da1 = new SqlDataAdapter(str1, conn1);

                //da1.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
                //da1.Fill(dts1, "temp");

                //DataTable dtztcoachsrt = new DataTable();
                //dtztcoachsrt = dts1.Tables[0];

                string mrrow = xmainrt.Text.ToString();

                for (int i = 0; i < int.Parse(rtcount.Value); i++)
                {

                    if (((Label)PlaceHolder1.FindControl("rt" + i)).Text.ToString() != mrrow)
                    {
                        //////////////////////////

                        string[] subrt = ((Label)PlaceHolder1.FindControl("rt" + i)).Text.ToString().Split('-');
                        string xsf = subrt[0];
                        string xst = subrt[1];
                        string xmrid1 = dtztcoach.Rows[0][7].ToString();

                        string srt = "SELECT xsrtimeh,xsrtimem,xsrtimei FROM ztcoachsubrt WHERE xsrid = (SELECT xsrid FROM ztrts where xsf=@xsf and xst=@xst and xmrid=@xmrid) AND xcoachno=@xcoachno";

                        SqlDataAdapter da1 = new SqlDataAdapter(srt, conn1);

                        da1.SelectCommand.Parameters.AddWithValue("@xsf", xsf);
                        da1.SelectCommand.Parameters.AddWithValue("@xst", xst);
                        da1.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                        da1.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);

                        dts1.Reset();
                        da1.Fill(dts1, "temp");

                        DataTable dtztrts = new DataTable();
                        dtztrts = dts1.Tables[0];


                        ((DropDownList)PlaceHolder1.FindControl("dwh" + i)).Text = dtztrts.Rows[0][0].ToString();
                        ((DropDownList)PlaceHolder1.FindControl("dwm" + i)).Text = dtztrts.Rows[0][1].ToString();
                        ((DropDownList)PlaceHolder1.FindControl("dwi" + i)).Text = dtztrts.Rows[0][2].ToString();

                        ////////////////////
                    }
                    else
                    {
                        ((DropDownList)PlaceHolder1.FindControl("dwh" + i)).Text = dtztcoach.Rows[0][3].ToString();
                        ((DropDownList)PlaceHolder1.FindControl("dwm" + i)).Text = dtztcoach.Rows[0][4].ToString();
                        ((DropDownList)PlaceHolder1.FindControl("dwi" + i)).Text = dtztcoach.Rows[0][5].ToString();

                    }
                }



                dts1.Dispose();



                /////////////////////////////////////////////////

                /////////////////////////////////////////////////
                ////fill counter with value////////////////

                DataSet dts2 = new DataSet();

                string str1 = "SELECT xcname,xctimeh,xctimem,xctimei FROM ztcoachcounter WHERE xcoachno=@xcoachno";

                SqlDataAdapter da2 = new SqlDataAdapter(str1, conn1);

                da2.SelectCommand.Parameters.AddWithValue("@xcoachno", xcoachno1);
                dts2.Reset();
                da2.Fill(dts2, "temp");
                DataTable dttemp = new DataTable();
                dttemp = dts2.Tables[0];

                if (dttemp.Rows.Count > 0)
                {

                    ViewState["labelsAdded"] = dttemp.Rows.Count;

                    PlaceHolder3.Controls.Clear();

                    int howMany = (int)ViewState["labelsAdded"];
                    for (int i = 1; i <= howMany; i++)
                    {
                        crectl(i);
                        //for (int j = 0; j < dttemp.Columns.Count; j++)
                        //{
                            ((DropDownList)PlaceHolder3.FindControl("dwc" + i)).Text = dttemp.Rows[i - 1][0].ToString();
                            ((DropDownList)PlaceHolder3.FindControl("dwhh" + i)).Text = dttemp.Rows[i - 1][1].ToString();
                            ((DropDownList)PlaceHolder3.FindControl("dwmm" + i)).Text = dttemp.Rows[i - 1][2].ToString();
                            ((DropDownList)PlaceHolder3.FindControl("dwii" + i)).Text = dttemp.Rows[i - 1][3].ToString();
                        //}
                    }






                }


                /////////////////////////////////////////////////

                if (dtztcoach.Rows[0][8].ToString() == "Confirmed")
                {
                    //btnAdd.Enabled = false;
                    //btnUpdate.Enabled = false;
                    //btnDelete.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }

                dts.Dispose();
                dtztcoach.Dispose();
                da.Dispose();

                conn1.Dispose();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (comfirmmsg.Value == "Yes")
                {

                    if (xcoachno.Text == "")
                    {
                        msg.InnerHtml = "Please select coach from list.";
                        return;
                    }
                    checkpk();
                    if (pk == "false")
                    {
                        msg.InnerHtml = "Data not found";

                    }
                    else
                    {

                        saveAndUpdate("confirm");

                    }

                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }


    }
}