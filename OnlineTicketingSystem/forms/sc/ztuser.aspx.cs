using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace OnlineTicketingSystem.Forms
{
    public partial class ztuser : System.Web.UI.Page
    {

        private string pk;
        private int isPassFildEmpty = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////Check Permission
                //SiteMaster sm = new SiteMaster();
                //string s = sm.fnChkPagePermis("ztuser");
                //if (s == "n" || s == "e")
                //{
                //    HttpContext.Current.Session["curuser"] = null;
                //    Session.Abandon();
                //    Response.Redirect("~/forms/zlogin.aspx");
                //}


                //xloc.Items.Add("[Select]");
                xloc.Items.Add("All");
                xloc.Items.Add("Selected Counter");
                xloc.Text = "All";

                xdateformat.Items.Add("[Select]");
                xdateformat.Items.Add("dd/MM/yyyy");
                xdateformat.Items.Add("MM/dd/yyyy");
                xdateformat.Items.Add("yyyy/MM/dd");


                //Code for fill list of role

                xrole.Items.Add("[Select]");

                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "SELECT xrole FROM ztrole WHERE zactive=1 ORDER BY xrole";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                da.Fill(dts, "tempzuser");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dttemp = new DataTable();
                dttemp = dts.Tables[0];

                if (dttemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {
                        xrole.Items.Add(dttemp.Rows[i][0].ToString());
                    }
                }



                xrole.Text = "[Select]";

                //End code for fill list of role

                zactive.Checked = true;

                //DateTime dt = DateTime.Now;
                //string sdt = String.Format("{0:MM/dd/yyyy}", dt);
                xdatetime.Text = DateTime.Now.ToString("M/d/yyyy");


                //Listbox1 All counter fill with data




                dts.Reset();
                str = "SELECT xcname FROM ztcounter WHERE zactive=1 ORDER BY xcname";
                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                da1.Fill(dts, "tempz");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dttemp1 = new DataTable();
                dttemp1 = dts.Tables[0];

                if (dttemp1.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemp1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dttemp1.Columns.Count; j++)
                        {
                            ListBox1.Items.Add(dttemp1.Rows[i][j].ToString());
                        }
                    }
                }

                dts.Dispose();
                dttemp.Dispose();
                da1.Dispose();
                conn1.Dispose();
                // dts.Dispose();
                dttemp1.Dispose();
                da.Dispose();
                conn1.Dispose();

                //end listbox1 data fillup

                populateDataGrid();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xuser,xusername,xrole,zactive FROM ztuser  ORDER BY xuser";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempzuser");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtzuser = new DataTable();
            dtzuser = dts.Tables[0];
            GridView1.DataSource = dtzuser;
            GridView1.DataBind();
            dts.Dispose();
            dtzuser.Dispose();
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
                query = "INSERT INTO ztuser" +
                               "(xuser,xpass,xusername,xuserinfo,xempcode,xaccess,xdateformat,zactive,xphone,xrole,xdatetime,xpermisst,xlocst) " +
                               "VALUES (@xuser,@xpass,@xusername,@xuserinfo,@xempcode,@xaccess,@xdateformat,@zactive,@xphone,@xrole,@xdatetime,@xpermisst,@xlocst) ";
            }
            else if (str == "update")
            {
                if (isPassFildEmpty == 0)
                {
                    query = "UPDATE ztuser SET " +
                                   "xpass=@xpass,xusername=@xusername,xuserinfo=@xuserinfo,xempcode=@xempcode,xaccess=@xaccess,xdateformat=@xdateformat,zactive=@zactive,xphone=@xphone,xrole=@xrole,xdatetime=@xdatetime,xlocst=@xlocst " +
                                   "WHERE xuser=@xuser";
                }
                else
                {
                    query = "UPDATE ztuser SET " +
                                      "xusername=@xusername,xuserinfo=@xuserinfo,xempcode=@xempcode,xaccess=@xaccess,xdateformat=@xdateformat,zactive=@zactive,xphone=@xphone,xrole=@xrole,xdatetime=@xdatetime,xlocst=@xlocst " +
                                      "WHERE xuser=@xuser";
                }
            }
            else
            {
                query = "DELETE FROM ztuser WHERE xuser=@xuser";
            }
            dataCmd.CommandText = query;

            string xuser1 = xuser.Text.ToString().Trim();

            dataCmd.Parameters.AddWithValue("@xuser", xuser1);

            //if (str != "delete")
            //{


            string xpass1 = xpass.Value.ToString().Trim();
            string xusername1 = xusername.Text.ToString().Trim();
            string xuserinfo1 = xuserinfo.Value.ToString().Trim();
            string xempcode1 = xempcode.Text.ToString().Trim();
            string xaccess1 = xaccess.Text.ToString().Trim();
            string xdateformat1 = xdateformat.Text.ToString().Trim();
            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }
            string xphone1 = xphone.Text.ToString().Trim();
            string xrole1 = xrole.Text.ToString().Trim();
            DateTime xdatetime1 = DateTime.Parse(xdatetime.Text.ToString().Trim());
            int xpermisst = 0;

            string xlocst;
            string xlocst1 = xloc.Text.ToString().Trim();
            if (xlocst1 == "All")
            {
                xlocst = "all";
            }
            else
            {
                xlocst = "sel";
            }

            dataCmd.Parameters.AddWithValue("@xpass", xpass1);
            dataCmd.Parameters.AddWithValue("@xusername", xusername1);
            dataCmd.Parameters.AddWithValue("@xuserinfo", xuserinfo1);
            dataCmd.Parameters.AddWithValue("@xempcode", xempcode1);
            dataCmd.Parameters.AddWithValue("@xaccess", xaccess1);
            dataCmd.Parameters.AddWithValue("@xdateformat", xdateformat1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
            dataCmd.Parameters.AddWithValue("@xphone", xphone1);
            dataCmd.Parameters.AddWithValue("@xrole", xrole1);
            dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime1);
            dataCmd.Parameters.AddWithValue("@xpermisst", xpermisst);
            dataCmd.Parameters.AddWithValue("@xlocst", xlocst);

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

                SqlCommand datacmd1 = new SqlCommand();

                if (xlocst == "sel")
                {
                    
                    datacmd1.Connection = conn1;

                    if (str == "save")
                    {
                        query = "INSERT INTO ztuserloc (xuser,xloc) VALUES (@xuser,@xloc)";
                    }
                    else if (str == "update")
                    {
                        query = "UPDATE ztuserloc SET xloc=@xloc WHERE xuser=@xuser";
                    }
                    else
                    {
                        query = "DELETE FROM ztuserloc WHERE xuser=@xuser";
                    }

                    datacmd1.CommandText = query;

                    string xloc1 = "";

                    for (int i = 0; i < ListBox2.Items.Count; i++)
                    {
                        xloc1 = xloc1 + "|" + ListBox2.Items[i].ToString();
                    }


                    datacmd1.Parameters.AddWithValue("@xuser", xuser1);
                    datacmd1.Parameters.AddWithValue("@xloc", xloc1);

                    conn1.Close();
                    conn1.Open();
                    datacmd1.ExecuteNonQuery();
                    conn1.Close();

                    
                    

                }






                tran.Complete();

                datacmd1.Dispose();
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
            string str = "SELECT xuser FROM ztuser ";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == xuser.Text.ToString().Trim())
                    {
                        pk = xuser.Text.ToString();
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
                if (xuser.Text != "")
                {
                    checkpk();

                    if (pk == "false")
                    {
                        if (xpass.Value != xrepass.Value)
                        {
                            string message = "Password not matched";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                            return;
                        }
                        if (xrole.Text != "[Select]")
                        {
                            saveAndUpdate("save");
                        }
                        else
                        {
                            msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                        }




                    }
                    else
                    {
                        string message = "Add data unsuccessfull. Because user you enter already exist into database. Please enter another.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                        xuser.Focus();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            xuser.Text = "";
            xpass.Value = "";
            xrepass.Value = "";
            xphone.Text = "";
            xrole.Text = "[Select]";
            xuserinfo.Value = "";
            xusername.Text = "";
            zactive.Checked = true;
            xaccess.Text = "";
            xdateformat.Text = "[Select]";
            xdatetime.Text = DateTime.Now.ToString("M/d/yyyy");
            xempcode.Text = "";
            msg.InnerHtml = "";

            ListBox2.Items.Clear();
        }


        //protected void btnShowPopup_Click(object sender, EventArgs e)
        //{
        //    string message = "Message from server side";
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowAlert('" + message + "');", true);
        //}

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "User : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xuser1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM ztuser where xuser=@xuser1";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xuser1", xuser1);
                da.Fill(dts, "tempzuser");

                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];

                xuser.Text = dtzuser.Rows[0][0].ToString();
                xusername.Text = dtzuser.Rows[0][2].ToString();
                xuserinfo.Value = dtzuser.Rows[0][3].ToString();
                xempcode.Text = dtzuser.Rows[0][4].ToString();
                xaccess.Text = dtzuser.Rows[0][5].ToString();
                xdateformat.Text = dtzuser.Rows[0][6].ToString();
                if ((int)dtzuser.Rows[0][7] == 1)
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }

                xphone.Text = dtzuser.Rows[0][8].ToString();
                xrole.Text = dtzuser.Rows[0][9].ToString();
                xdatetime.Text = ((DateTime)dtzuser.Rows[0][10]).ToString("M/d/yyyy");

                if (dtzuser.Rows[0][12].ToString() == "all")
                {
                    xloc.Text = "All";
                    Panel2.Visible = false;
                }
                else
                {
                    xloc.Text = "Selected Counter";
                    Panel2.Visible = true;

                    str = "SELECT xloc FROM ztuserloc WHERE xuser=@xuser";
                    SqlDataAdapter da3 = new SqlDataAdapter(str, conn1);

                    dts.Reset();

                    da3.SelectCommand.Parameters.AddWithValue("@xuser", xuser1);
                    da3.Fill(dts, "tempz");

                    DataTable dtxloc = new DataTable();
                    dtxloc = dts.Tables[0];

                    if (dtxloc.Rows.Count > 0)
                    {
                        string temploc = dtxloc.Rows[0][0].ToString();
                        string[] xxloc;
                        //ArrayList ztxloc = new ArrayList();
                        xxloc = temploc.Split('|');
                        ListBox2.Items.Clear();
                        foreach (string loc in xxloc)
                        {
                            //ztxloc.Add(loc.Trim());
                            if (loc != "")
                            {
                                ListBox2.Items.Add(loc.Trim());
                            }
                        }


                    }

                }

                dts.Dispose();
                dtzuser.Dispose();
                da.Dispose();
                conn1.Dispose();
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


                if (xuser.Text != "")
                {



                    checkpk();
                    if (pk != "false")
                    {
                        if (xpass.Value != xrepass.Value)
                        {
                            string message = "Password not matched";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                            return;
                        }

                        if (xrole.Text != "[Select]")
                        {
                            if (xpass.Value == "")
                            {
                                isPassFildEmpty = 1;
                            }
                            saveAndUpdate("update");
                        }
                        else
                        {
                            msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";

                        }

                    }
                    else
                    {
                        msg.InnerHtml = "User you provide don't found in database, please select user from list ";
                        xuser.Focus();
                    }


                }
                else
                {
                    msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                    xuser.Focus();
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

                    if (xuser.Text != "")
                    {



                        checkpk();
                        if (pk != "false")
                        {
                            //string message = "Do you really want to delete?";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowYesNo('" + message + "');", true);


                            saveAndUpdate("delete");

                        }
                        else
                        {
                            msg.InnerHtml = "User you provide don't found in database, please select user from list ";
                            xuser.Focus();
                        }


                    }
                    else
                    {
                        msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                        xuser.Focus();
                    }
                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void rdosel_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdosel.Checked == true)
            //{
            //    string message = "Password not matched";
            //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            //    return;
            //}
        }

        protected void xloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xloc.Text == "Selected Counter")
            {

                Panel2.Visible = true;
            }
            else
            {

                Panel2.Visible = false;
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





    }
}