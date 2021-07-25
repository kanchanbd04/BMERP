using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;


namespace OnlineTicketingSystem.forms.sc
{
    public partial class ztdisc : System.Web.UI.Page
    {
        private string pk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Check Permission
                    SiteMaster sm = new SiteMaster();
                    string s = sm.fnChkPagePermis("ztdisc");
                    if (s == "n" || s == "e")
                    {
                        HttpContext.Current.Session["curuser"] = null;
                        Session.Abandon();
                        Response.Redirect("~/forms/zlogin.aspx");
                    }

                    xrow.Text = zglobal.fnmaxid("SELECT max(xrow) FROM ztdisc where xcreatedt between @firstdate and @lastdate");

                    xeffdate.Text = DateTime.Now.ToShortDateString();
                    xexpdate.Text = DateTime.Now.ToShortDateString();

                    xclasstype.Items.Add("[Select]");
                    xclasstype.Items.Add("Same Class");
                    xclasstype.Items.Add("Different Class");
                    xclasstype.Text = "Same Class";
                    xclasstype.Enabled = false;

                    xdiscratetype.Items.Add("[Select]");
                    xdiscratetype.Items.Add("Fixed Amount");
                    xdiscratetype.Items.Add("Percentage");

                    xdisctype.Items.Add("[Select]");
                    xdisctype.Items.Add("Departure");
                    xdisctype.Items.Add("Return");
                    xdisctype.Items.Add("Both");
                    xdiscratetype.Text = "Return";
                    xdiscratetype.Enabled = false;

                    ListBox1.Items.Add("Saturday");
                    ListBox1.Items.Add("Sunday");
                    ListBox1.Items.Add("Monday");
                    ListBox1.Items.Add("Tuesday");
                    ListBox1.Items.Add("Wednesday");
                    ListBox1.Items.Add("Thursday");
                    ListBox1.Items.Add("Friday");

                    xuptripc.Enabled = false;
                    xdowntripc.Enabled = false;


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
                        xuptripc.Items.Add("[Select]");
                        xdowntripc.Items.Add("[Select]");
                        for (int i = 0; i < dtztcode.Rows.Count; i++)
                        {
                            xuptripc.Items.Add(dtztcode.Rows[i][0].ToString());
                            xdowntripc.Items.Add(dtztcode.Rows[i][0].ToString());
                        }

                        xuptripc.Text = "[Select]";
                        xdowntripc.Text = "[Select]";
                    }

                    conn1.Dispose();
                    dts.Dispose();
                    da.Dispose();

                    zactive.Checked = true;

                    populateDataGrid();

                }
                catch(Exception exp)
                {
                    msg.InnerHtml = exp.Message;
                }



            }
        }

        protected void btnforward_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox1.Items[i].Selected == true)
                    {
                        if (!ListBox2.Items.Contains(ListBox1.Items[i]))
                        {
                            ListBox2.Items.Add(ListBox1.Items[i]);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnbackword_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = ListBox2.Items.Count - 1; i >= 0; i--)
                {
                    if (ListBox2.Items[i].Selected == true)
                    {
                        //ListBox1.Items.Add(ListBox2.Items[i]);
                        ListItem li = ListBox2.Items[i];
                        ListBox2.Items.Remove(li);
                    }
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void xclasstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xclasstype.Text == "Different Class")
            {
                xuptripc.Enabled = true;
                xdowntripc.Enabled = true;
            }
            else
            {
                xuptripc.Enabled = false;
                xdowntripc.Enabled = false;
            }
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xrow1 = ((LinkButton)sender).Text;


                string str = "SELECT xrow,xclasstype,xuptripc,xdowntripc,xeffdate,xexpdate,xdayname,xdiscratetype,xdiscamt,xdisctype,zactive,xstatus FROM ztdisc where xrow=@xrow";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xrow", xrow1);
                da.Fill(dts, "temptbl");

                DataTable dtztemp = new DataTable();
                dtztemp = dts.Tables[0];

                xrow.Text = dtztemp.Rows[0][0].ToString();
                xclasstype.Text = dtztemp.Rows[0][1].ToString();
                if (dtztemp.Rows[0][1].ToString() != "Same Class")
                {
                    xuptripc.Text = dtztemp.Rows[0][2].ToString();
                    xdowntripc.Text = dtztemp.Rows[0][3].ToString();
                }
                else
                {
                    xuptripc.Text = "[Select]";
                    xdowntripc.Text = "[Select]";
                }
                xeffdate.Text = Convert.ToDateTime(dtztemp.Rows[0][4]).ToShortDateString();
                xexpdate.Text = Convert.ToDateTime(dtztemp.Rows[0][5]).ToShortDateString();

                string[] xdayname1 = new string[7];
                string xdaynm = dtztemp.Rows[0][6].ToString();
                xdayname1 = xdaynm.Split('|');

                ListBox2.Items.Clear();
                foreach (string day in xdayname1)
                {
                    if (day != "")
                    {
                        ListBox2.Items.Add(day.Trim());
                    }
                }


                xdiscratetype.Text = dtztemp.Rows[0][7].ToString();
                xdiscamt.Text = dtztemp.Rows[0][8].ToString();
                xdisctype.Text = dtztemp.Rows[0][9].ToString();


                if (Convert.ToInt32(dtztemp.Rows[0][10]) == 1)
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }

                if (dtztemp.Rows[0][11].ToString() == "Confirmed")
                {
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }

                dts.Dispose();
                dtztemp.Dispose();
                da.Dispose();
                conn1.Dispose();
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
                msg.InnerHtml = "";
                xrow.Text = zglobal.fnmaxid("SELECT max(xrow) FROM ztdisc where xcreatedt between @firstdate and @lastdate");
                //xclasstype.Text = "[Select]";
                xclasstype.Text = "Same Class";
                xuptripc.Enabled = false;
                xdowntripc.Enabled = false;
                xuptripc.Text = "[Select]";
                xdowntripc.Text = "[Select]";
                xeffdate.Text = DateTime.Now.ToShortDateString();
                xexpdate.Text = DateTime.Now.ToShortDateString();
                xdiscratetype.Text = "[Select]";
                xdiscamt.Text = "";
                //xdisctype.Text = "[Select]";
                xdisctype.Text = "Return";
                zactive.Checked = true;
                ListBox2.Items.Clear();
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xrow,xclasstype,xeffdate,xexpdate,xstatus,zactive FROM ztdisc  ORDER BY xrow";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "temptbl");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];
            GridView1.DataSource = dtztemp;
            GridView1.DataBind();
            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        private void saveAndUpdate(string str)
        {


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn1;
            string query;
            if (str == "save")
            {
                query = "INSERT INTO ztdisc" +
                               "(xrow,xclasstype,xuptripc,xdowntripc,xeffdate,xexpdate,xdayname,xdiscratetype,xdiscamt,xdisctype,xstatus,xcreatedby,xcreatedt,xloc,zactive) " +
                               "VALUES (@xrow,@xclasstype,@xuptripc,@xdowntripc,@xeffdate,@xexpdate,@xdayname,@xdiscratetype,@xdiscamt,@xdisctype,@xstatus,@xcreatedby,@xcreatedt,@xloc,@zactive) ";
            }
            else if (str == "update")
            {

                query = "UPDATE ztdisc SET " +
                       "xclasstype=@xclasstype,xuptripc=@xuptripc,xdowntripc=@xdowntripc,xeffdate=@xeffdate,xexpdate=@xexpdate,xdayname=@xdayname,xdiscratetype=@xdiscratetype,xdiscamt=@xdiscamt,xdisctype=@xdisctype,xstatus=@xstatus,xupdby=@xupdby,xupddt=@xupddt,xupdloc=@xupdloc,zactive=@zactive " +
                       "WHERE xrow=@xrow";
           
            }
            else if (str == "confirm")
            {
                query = "UPDATE ztdisc SET " +
                         "zactive=1, xstatus='Confirmed' " +
                                                 "WHERE xrow=@xrow";
            }
            else
            {
                query = "DELETE FROM ztdisc WHERE xrow=@xrow";
            }
            dataCmd.CommandText = query;

            string xrow1;
            if (str == "save")
            {
                xrow1 = zglobal.fnmaxid("SELECT max(xrow) FROM ztdisc where xcreatedt between @firstdate and @lastdate");
            }
            else
            {
                xrow1 = xrow.Text.ToString().Trim();
            }

            dataCmd.Parameters.AddWithValue("@xrow", xrow1);

            //if (str != "delete")
            //{


            string xclasstype1 = xclasstype.Text.ToString().Trim();
            string xuptripc1 = xuptripc.Text.ToString().Trim();
            string xdowntripc1 = xdowntripc.Text.ToString().Trim();
            string xeffdate1 = xeffdate.Text.ToString().Trim();
            string xexpdate1 = xexpdate.Text.ToString().Trim();
            string xdayname1 = "";
            for (int j = 0; j < ListBox2.Items.Count; j++)
            {
                xdayname1 = xdayname1 + "|" + ListBox2.Items[j].ToString();
            }
            string xdiscratetype1 = xdiscratetype.Text.ToString().Trim();
            string xdiscamt1 = xdiscamt.Text.ToString().Trim();
            string xdisctype1 = xdisctype.Text.ToString().Trim();
            string xstatus1;
            if (str == "confirm")
            {
                xstatus1 = "Confirmed";
            }
            else
            {
                xstatus1 = "New";
            }

            string xcreatedby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            string xcreatedt1 = Convert.ToString(DateTime.Now);
            string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
            string xupdby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            string xupddt1 = Convert.ToString(DateTime.Now);
            string xupdloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }
       

            //dataCmd.Parameters.AddWithValue("@xrow", xrow1);
            dataCmd.Parameters.AddWithValue("@xclasstype", xclasstype1);
            dataCmd.Parameters.AddWithValue("@xuptripc", xuptripc1);
            dataCmd.Parameters.AddWithValue("@xdowntripc", xdowntripc1);
            dataCmd.Parameters.AddWithValue("@xeffdate", xeffdate1);
            dataCmd.Parameters.AddWithValue("@xexpdate", xexpdate1);
            dataCmd.Parameters.AddWithValue("@xdayname", xdayname1);
            dataCmd.Parameters.AddWithValue("@xdiscratetype", xdiscratetype1);
            dataCmd.Parameters.AddWithValue("@xdiscamt", xdiscamt1);
            dataCmd.Parameters.AddWithValue("@xdisctype", xdisctype1);
            dataCmd.Parameters.AddWithValue("@xstatus", xstatus1);
            dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby1);
            dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt1);
            dataCmd.Parameters.AddWithValue("@xloc", xloc1);
            dataCmd.Parameters.AddWithValue("@xupdby", xupdby1);
            dataCmd.Parameters.AddWithValue("@xupddt", xupddt1);
            dataCmd.Parameters.AddWithValue("@xupdloc", xupdloc1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);

            //}

            using (TransactionScope tran = new TransactionScope())
            {
                conn1.Close();
                conn1.Open();
                dataCmd.ExecuteNonQuery();
                conn1.Close();

                //-------------------------------------------------//
                populateDataGrid();

                //-------------------------------------------------//

               






                tran.Complete();

                
                dataCmd.Dispose();
                conn1.Dispose();
            }


            if (str == "save")
            {
                msg.InnerText = "Successfully add data.";
            }
            else if (str == "update")
            {
                msg.InnerText = "Successfully update data.";
            }
            else if (str == "confirm")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                msg.InnerText = "Successfully delete data.";
            }

        }

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xrow FROM ztdisc ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempzuser");

            DataTable dtzuser = new DataTable();
            dtzuser = dts.Tables[0];

            if (dtzuser.Rows.Count > 0)
            {
                for (int i = 0; i < dtzuser.Rows.Count; i++)
                {
                    //for (int j = 0; j < 1; j++)
                    //{
                    if (dtzuser.Rows[i][0].ToString().Trim() == xrow.Text.ToString().Trim())
                    {
                        pk = xrow.Text.ToString();
                        //currow = i;
                        dts.Dispose();
                        dtzuser.Dispose();
                        da.Dispose();
                        conn1.Dispose();
                        return;
                    }
                    //}
                }
            }
            pk = "false";

            dts.Dispose();
            dtzuser.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xrow.Text != "" && xclasstype.Text!="[Select]" && xeffdate.Text!="" && xexpdate.Text!="" && xdiscratetype.Text!="[Select]" && xdiscamt.Text!="" && xdisctype.Text!="[Select]" && ListBox2.Items.Count>0 )
                {
                    checkpk();

                    if (pk == "false")
                    {
                        if (xclasstype.Text == "Different Class")
                        {
                            if (xuptripc.Text == "[Select]" && xdowntripc.Text == "[Select]")
                            {
                                msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                                return;
                            }
                        }
                        saveAndUpdate("save");
                        
                    }
                    else
                    {
                        string message = "Add data unsuccessfull. Because data you enter already exist into database. Please enter another.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                      
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                    }
                }
                else
                {
                    msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
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
                msg.InnerText = "";
                if (xrow.Text != "" && xclasstype.Text != "[Select]" && xeffdate.Text != "" && xexpdate.Text != "" && xdiscratetype.Text != "[Select]" && xdiscamt.Text != "" && xdisctype.Text != "[Select]" && ListBox2.Items.Count > 0)
                {
                    checkpk();

                    if (pk != "false")
                    {
                        if (xclasstype.Text == "Different Class")
                        {
                            if (xuptripc.Text == "[Select]" && xdowntripc.Text == "[Select]")
                            {
                                msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                                return;
                            }
                        }
                        saveAndUpdate("update");

                    }
                    else
                    {
                        msg.InnerHtml = "Data you provide don't found in database, please select data from list ";

                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                    }
                }
                else
                {
                    msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                }
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
                    msg.InnerText = "";
                    if (xrow.Text != "" && xclasstype.Text != "[Select]" && xeffdate.Text != "" && xexpdate.Text != "" && xdiscratetype.Text != "[Select]" && xdiscamt.Text != "" && xdisctype.Text != "[Select]" && ListBox2.Items.Count > 0)
                    {
                        checkpk();

                        if (pk != "false")
                        {
                            if (xclasstype.Text == "Different Class")
                            {
                                if (xuptripc.Text == "[Select]" && xdowntripc.Text == "[Select]")
                                {
                                    msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                                    return;
                                }
                            }
                            saveAndUpdate("delete");

                        }
                        else
                        {
                            msg.InnerHtml = "Data you provide don't found in database, please select data from list ";

                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                        }
                    }
                    else
                    {
                        msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                    }
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
                if (comfirmmsg.Value == "Yes")
                {

                    
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