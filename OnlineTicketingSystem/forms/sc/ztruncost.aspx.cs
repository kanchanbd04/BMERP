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
    public partial class ztruncost : System.Web.UI.Page
    {
        static string userid;
        static string location;
        protected void Page_Load(object sender, EventArgs e)
        {

            userid = Convert.ToString(HttpContext.Current.Session["curuser"]);
            location = Convert.ToString(HttpContext.Current.Session["xlocation"]);
            try
            {
                if (!IsPostBack)
                {
                
                    //Check Permission
                    SiteMaster sm = new SiteMaster();
                    string s = sm.fnChkPagePermis("ztruncost");
                    if (s == "n" || s == "e")
                    {
                        HttpContext.Current.Session["curuser"] = null;
                        Session.Abandon();
                        Response.Redirect("~/forms/zlogin.aspx");
                    }



                    xdate.Text = DateTime.Now.ToShortDateString();
                    fnxcoach();

                }
                

               
          
                fnChkDriver();
             }
             catch (Exception exp)
             {
                 msg.InnerHtml = exp.Message;
             }
        }


        protected void fnxcoach()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();
            dts.Reset();
            string str = "SELECT distinct xcoachno FROM zttrip  WHERE @xdate between xstdt and xendt AND zactive=1 ORDER BY xcoachno";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xdate1 = xdate.Text.ToString();
            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);

            da.Fill(dts, "tempzt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];

            if (dtztcode.Rows.Count > 0)
            {
                xcoachno.Items.Clear();

                xcoachno.Items.Add(new ListItem("[Select]", string.Empty));
                for (int i = 0; i < dtztcode.Rows.Count; i++)
                {
                    xcoachno.Items.Add(dtztcode.Rows[i][0].ToString());
                }

                xcoachno.Text = "";
            }
            else
            {
                xcoachno.Items.Clear();

                xcoachno.Items.Add(new ListItem("[Select]", string.Empty));
            }
            //da.Dispose();
            //dts.Dispose();
            //conn1.Dispose();
            
        }

        protected void fnCrCtl()
        {

            SqlConnection conn;
            conn = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            string str = "select xname from ztcode where xtype='Running Cost AC' and zactive=1";

           

            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            dts.Reset();
            da.Fill(dts, "tempdtrt");

            DataTable ztrt = new DataTable();
            ztrt = dts.Tables[0];

           

            PlaceHolder1.Controls.Add(new LiteralControl("<table>"));





            if (ztrt.Rows.Count > 0)
            {

                int cid = 1;
                for (int i = 0; i < ztrt.Rows.Count; i++)
                {
                    PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

                    PlaceHolder1.Controls.Add(new LiteralControl("<td>"));

                    Label mylabel2 = new Label();
                    mylabel2.Text = ztrt.Rows[i][0].ToString();
                    mylabel2.ID = "label" + cid.ToString();
                    
                    PlaceHolder1.Controls.Add(mylabel2);
                    PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                    PlaceHolder1.Controls.Add(new LiteralControl("<td>"));

                    TextBox mytxt = new TextBox();
                    mytxt.Text = "0";
                    mytxt.ID = "txt" + cid.ToString();
                    PlaceHolder1.Controls.Add(mytxt);
                    PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                    PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

                    cid = cid + 1;
                }

               
            } 


            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));

            conn.Dispose();
            dts.Dispose();
            da.Dispose();

        }

        protected void xdate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                fnxcoach();
                PlaceHolder1.Controls.Clear();
                xremarks.InnerText = "";

                if (xdate.Text == "")
                {
                    xdate.BackColor = System.Drawing.Color.Pink;
                  

                }
                else
                {
                    xdate.BackColor = System.Drawing.Color.White;
                }
               
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        /* Check is driver assign for coach before print passenger list*/
      
        private void fnChkDriver()
        {
            try
            {
                //msg.InnerHtml = "This coach";
                SqlConnection conn2;
                conn2 = new SqlConnection(zglobal.constring);
                DataSet dts2 = new DataSet();
                dts2.Reset();

                string xdate2 = xdate.Text.ToString();
                string xcoach2 = xcoachno.Text.ToString();
                string str2 = "select count(*) from ztsaledriver where xdate=@xdate and xcoach=@xcoach";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

                da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
                da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

                da2.Fill(dts2, "temp");
                DataTable dtztemp1 = new DataTable();
                dtztemp1 = dts2.Tables["temp"];

                if (dtztemp1.Rows[0][0].ToString() == "0")
                {
                    //msg.InnerHtml = "This coach is not departure yet";
                }
                else
                {
                    PlaceHolder1.Controls.Clear();
                    fnCrCtl();
                }

                conn2.Dispose();
                dts2.Dispose();
                da2.Dispose();
            }
            catch (Exception exp)
            {
                msg.InnerHtml= exp.Message;
                
            }

            

            //return "success";
        }

        protected void xcoachno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                fnChkDriver();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //xcoachno.Text = "[Select]";
                xremarks.InnerText = "";
                xdate.Text = DateTime.Now.ToShortDateString();
                PlaceHolder1.Controls.Clear();
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                msg.InnerHtml = "";
                fnxcoach();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        string pk;

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT count(*) FROM ztruncosth where xcoach=@xcoach and xdate=@xdate";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            
            string xcoachno1 = xcoachno.Text.ToString();
            string xdate1 = xdate.Text.ToString();

            da.SelectCommand.Parameters.AddWithValue("@xcoach",xcoachno1);
            da.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
            da.Fill(dts, "tempz");

            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];

            if (Convert.ToInt32(dtztemp.Rows[0][0]) != 0)
            {
                //for (int i = 0; i < dtztemp.Rows.Count; i++)
                //{
                    //for (int j = 0; j < 1; j++)
                    ////{
                    //if (dtztemp.Rows[i][0].ToString().Trim() == xmainrt.SelectedItem.Value)
                    //{
                    //    pk = dtztemp.Rows[i][0].ToString();
                        //currow = i;
                    pk = "true";
                        dts.Dispose();
                        dtztemp.Dispose();
                        da.Dispose();
                        conn1.Dispose();
                        return;
                    //}
                    //}
               // }
            }
            pk = "false";

            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        private void saveAndUpdate(string str)
        {

            using (TransactionScope tran = new TransactionScope())
            {

                SqlConnection conn1;
                SqlCommand dataCmd;
                conn1 = new SqlConnection(zglobal.constring);
                dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                if (str == "save")
                {
                    query = "INSERT INTO ztruncosth" +
                                   "(xvehcat,xcoach,xdate,xremarks,xcreatedby,xcreatedt,xloc,xstatus) " +
                                   "VALUES (@xvehcat,@xcoach,@xdate,@xremarks,@xcreatedby,@xcreatedt,@xloc,'New') ";
                }
                else if (str == "update")
                {

                    query = "UPDATE ztruncosth SET " +
                                          "xremarks=@xremarks,xupdby=@xupdby,xupdt=@xupdt,xuploc=@xuploc " +
                                          "WHERE xcoach=@xcoach and xdate=@xdate";

                }
                else if (str == "confirm")
                {

                    query = "UPDATE ztruncosth SET " +
                                          "xstatus='Confirm',xupdby=@xupdby,xupdt=@xupdt,xuploc=@xuploc " +
                                          "WHERE  xcoach=@xcoach and xdate=@xdate";

                }
                else
                {
                    query = "DELETE FROM ztruncosth WHERE xmrid=@xmrid";
                }


                dataCmd.CommandText = query;

                conn1.Close();
                conn1.Open();
                if (str == "delete" || str == "confirm")
                {
                    //string xmrid1 = xmainrt.SelectedItem.Value;
                    string xupdby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    DateTime xupdt1 = DateTime.Now;
                    string xuploc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                    string xcoach1 = xcoachno.Text.ToString();
                    string xdate1 = xdate.Text.ToString();


                    //dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);
                    dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                    dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                    dataCmd.Parameters.AddWithValue("@xupdby", xupdby1);
                    dataCmd.Parameters.AddWithValue("@xupdt", xupdt1);
                    dataCmd.Parameters.AddWithValue("@xuploc", xuploc1);

                    dataCmd.ExecuteNonQuery();
                }
                else
                {
                    //for (int i = 1; i <= Convert.ToInt32(rowcount123.Value); i++)
                    //{
                        //dataCmd.Parameters.Clear();

                        //if (str == "save")
                        //{
                        //    string xrow1 = zglobal.fnmaxid("SELECT max(xrow) FROM ztsequence where getdate() between @firstdate and @lastdate");
                        //    dataCmd.Parameters.AddWithValue("@xrow", xrow1);
                        //}
                        //string xmrid1 = xmainrt.SelectedItem.Value;
                        //string xroute1 = ((Label)PlaceHolder1.FindControl("label" + i)).Text.ToString();
                        //string xseq1 = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dw" + i)).SelectedItem.Text);
                        string xvehcat1 = "AC";
                        string xcoach1 = xcoachno.Text.ToString();
                        string xdate1 = xdate.Text.ToString();
                        string xremarks1 = xremarks.InnerText.ToString(); 
                        string xcreatedby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xcreatedt1 = DateTime.Now;
                        string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                        string xupdby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xupdt1 = DateTime.Now;
                        string xuploc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);


                        dataCmd.Parameters.AddWithValue("@xvehcat", xvehcat1);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                        dataCmd.Parameters.AddWithValue("@xremarks", xremarks1);
                        dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby1);
                        dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt1);
                        dataCmd.Parameters.AddWithValue("@xloc", xloc1);
                        dataCmd.Parameters.AddWithValue("@xupdby", xupdby1);
                        dataCmd.Parameters.AddWithValue("@xupdt", xupdt1);
                        dataCmd.Parameters.AddWithValue("@xuploc", xuploc1);

                        dataCmd.ExecuteNonQuery();



                  //insert into ztruncostd 

                        dataCmd.Parameters.Clear();

                        query = "DELETE FROM ztruncostd WHERE  xcoach=@xcoach and xdate=@xdate";
                        
                        dataCmd.CommandText = query;

                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate1);

                        dataCmd.ExecuteNonQuery();

                        SqlConnection conn;
                        conn = new SqlConnection(zglobal.constring);
                        DataSet dts = new DataSet();

                        string str123 = "select xname from ztcode where xtype='Running Cost AC' and zactive=1";



                        SqlDataAdapter da = new SqlDataAdapter(str123, conn);
                        dts.Reset();
                        da.Fill(dts, "tempdtrt");

                        DataTable ztrt = new DataTable();
                        ztrt = dts.Tables[0];

                        if (ztrt.Rows.Count > 0)
                        {


                            query = "INSERT INTO ztruncostd" +
                                   "(xdate,xcoach,xexptype,xamount) " +
                                   "VALUES (@xdate,@xcoach,@xexptype,@xamount) ";

                            dataCmd.CommandText = query;

                            for (int i = 1; i <= ztrt.Rows.Count; i++)
                            {
                                dataCmd.Parameters.Clear();



                                string xexptype = ((Label)PlaceHolder1.FindControl("label" + i)).Text.ToString();
                                string xamount = ((TextBox)PlaceHolder1.FindControl("txt" + i)).Text.ToString();

                                dataCmd.Parameters.AddWithValue("@xcoach", xcoach1);
                                dataCmd.Parameters.AddWithValue("@xdate", xdate1);
                                dataCmd.Parameters.AddWithValue("@xexptype", xexptype);
                                dataCmd.Parameters.AddWithValue("@xamount", xamount);

                                dataCmd.ExecuteNonQuery();
                            }
                        }

                    ///////////////////

                    //}
                }

                conn1.Close();

                tran.Complete();
            }

         


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
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                //btnDelete.Enabled = false;
            }
            else
            {
                msg.InnerText = "Successfully delete data.";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                if (xcoachno.Text == "[Select]")
                {
                    msg.InnerHtml = "Please Select Coach.";
                    return;
                }
                if (xdate.Text == "")
                {
                    msg.InnerHtml = "Please Select Date.";
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
                msg.InnerHtml = "";
                if (xcoachno.Text == "[Select]")
                {
                    msg.InnerHtml = "Please Select Coach.";
                    return;
                }
                if (xdate.Text == "")
                {
                    msg.InnerHtml = "Please Select Date.";
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

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnComfirm_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                if (comfirmmsg.Value == "Yes")
                {

                    
                    if (xcoachno.Text == "[Select]")
                    {
                        msg.InnerHtml = "Please Select Coach.";
                        return;
                    }
                    if (xdate.Text == "")
                    {
                        msg.InnerHtml = "Please Select Date.";
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();
                string str = "SELECT xremarks,xstatus FROM ztruncosth where xcoach=@xcoach and xdate=@xdate ";
                string xcoach1 = xcoachno.Text.ToString();
                string xdate1 = xdate.Text.ToString();
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@xdate",xdate1);
                da.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);
                da.Fill(dts, "tempz");

                DataTable dtztemp = new DataTable();
                dtztemp = dts.Tables[0];

                if (dtztemp.Rows.Count > 0)
                {
                    xremarks.InnerText = dtztemp.Rows[0][0].ToString();
                    if (dtztemp.Rows[0][1].ToString() == "Confirm")
                    {
                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                        btnUpdate.Enabled = true;
                    }
                    dts.Reset();
                    
                    str = "SELECT * FROM ztruncostd where xcoach=@xcoach and xdate=@xdate ";

                    SqlDataAdapter da1 = new SqlDataAdapter(str,conn1);
                    da1.SelectCommand.Parameters.AddWithValue("@xdate", xdate1);
                    da1.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach1);
                    da1.Fill(dts, "tempz");
                    DataTable ztrt = new DataTable();
                    ztrt = dts.Tables[0];

                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(new LiteralControl("<table>"));





                    if (ztrt.Rows.Count > 0)
                    {

                        int cid = 1;
                        for (int i = 0; i < ztrt.Rows.Count; i++)
                        {
                            PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

                            PlaceHolder1.Controls.Add(new LiteralControl("<td>"));

                            Label mylabel2 = new Label();
                            mylabel2.Text = ztrt.Rows[i][2].ToString();
                            mylabel2.ID = "label" + cid.ToString();

                            PlaceHolder1.Controls.Add(mylabel2);
                            PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                            PlaceHolder1.Controls.Add(new LiteralControl("<td>"));

                            TextBox mytxt = new TextBox();
                            mytxt.Text = ztrt.Rows[i][3].ToString();
                            mytxt.ID = "txt" + cid.ToString();
                            PlaceHolder1.Controls.Add(mytxt);
                            PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                            PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

                            cid = cid + 1;
                        }


                    }


                    PlaceHolder1.Controls.Add(new LiteralControl("</table>"));

                }
                else
                {
                    msg.InnerHtml = "Record Not Found.";
                }

                conn1.Dispose();
                dts.Dispose();
                da.Dispose();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

       



    }
}