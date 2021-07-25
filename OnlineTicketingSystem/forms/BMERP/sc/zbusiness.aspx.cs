using System;
using System.Collections;
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
    public partial class zbusiness : System.Web.UI.Page
    {

        private string pk;
        private int isPassFildEmpty = 0;
        static string userid;

        

        protected void Page_Load(object sender, EventArgs e)
        {

            userid = Convert.ToString(HttpContext.Current.Session["curuser"]);

            if (!IsPostBack)
            {

                AddComboBoxItems dl_xbusscat = new AddComboBoxItems(xbusscat, "xname", "xname", "ztcode", "xtype", "BusinessCat", "");
                AddComboBoxItems dl_xcur = new AddComboBoxItems(xcur, "xname", "xname", "ztcode", "xtype", "BaseCur", "");

                ArrayList arr = new ArrayList();
                arr.Add("All");
                arr.Add("Selected Module");
                AddComboBoxItemsSingel dl_xmod = new AddComboBoxItemsSingel(xmod, arr);

                zactive.Checked = true;

                xdate.Text = DateTime.Now.ToString("d/M/yyyy");

                string str = "select xid,xmenunm from ztmenu where xparentid is null or xparentid='' order by xid";
                AddListBoxItem lt_AddItem = new AddListBoxItem(ListBox1, str);


                populateDataGrid();
                

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void populateDataGrid()
        {

            string query = "select zid,zorg,zactive from zbusiness order by zid";
            AddDataGridViewItems gv = new AddDataGridViewItems(GridView1, query);
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
                query = "INSERT INTO zbusiness" +
                               "(zorg,xshort,xemail,xbusscat,xcur,xadd1,xadd2,xtimage,xdate,xcustom,xurl,zactive,ztime,zemail,xmodper,zorg1) " +
                               "VALUES (@zorg,@xshort,@xemail,@xbusscat,@xcur,@xadd1,@xadd2,@xtimage,@xdate,@xcustom,@xurl,@zactive,@ztime,@zemail,@xmodper,@zorg1) ";
            }
            else if (str == "update")
            {
                query = "UPDATE zbusiness SET " +
                                   "zorg=@zorg,zorg1=@zorg1,xshort=@xshort,xemail=@xemail,xbusscat=@xbusscat,xcur=@xcur,xadd1=@xadd1,xadd2=@xadd2,xtimage=@xtimage,xdate=@xdate,xcustom=@xcustom,xurl=@xurl,zactive=@zactive,zutime=@zutime,xmodper=@xmodper " +
                                   "WHERE zid=@zid";
            }
            else
            {
                query = "DELETE FROM zbusiness WHERE zid=@zid";
            }
            dataCmd.CommandText = query;

            string zid1;

            if (str == "save")
            {
                zid1 = zglobal.GetMaximumId("select MAX(zid)+1 from zbusiness");
            }
            else
            {
                zid1 = zid.Text.ToString().Trim();
            }

            dataCmd.Parameters.AddWithValue("@zid", zid1);

            //if (str != "delete")
            //{


            string zorg11 = zorg.Text.ToString().Trim();
            string zorg111 = zorg1.Text.ToString().Trim();
            string xshort1 = xshort.Text.ToString().Trim();
            string xemail1 = xemail.Text.ToString().Trim();
            string xbusscat1 = xbusscat.Text.ToString().Trim();
            string xcur1 = xcur.Text.ToString().Trim();
            string xadd11 = xadd1.Value.ToString().Trim();
            string xadd21 = xadd2.Value.ToString().Trim();
            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }
            string xtimage1 = xtimage.Text.ToString().Trim();
            string xcustom1 = xcustom.Value.ToString().Trim();
            DateTime xdate1 = DateTime.Parse(xdate.Text.ToString().Trim());

            string xurl1 = xurl.Text.ToString().Trim();
            string zemail1 = userid;
            DateTime ztime1 = DateTime.Now;

            string xmodper;
            string xmodper1 = xmod.Text.ToString().Trim();
            if (xmodper1 == "All")
            {
                xmodper = "all";
            }
            else
            {
                xmodper = "sel";
            }



            dataCmd.Parameters.AddWithValue("@zorg", zorg11);
            dataCmd.Parameters.AddWithValue("@zorg1", zorg111);
            dataCmd.Parameters.AddWithValue("@xshort", xshort1);
            dataCmd.Parameters.AddWithValue("@xemail", xemail1);
            dataCmd.Parameters.AddWithValue("@xbusscat", xbusscat1);
            dataCmd.Parameters.AddWithValue("@xcur", xcur1);
            dataCmd.Parameters.AddWithValue("@xadd1", xadd11);
            dataCmd.Parameters.AddWithValue("@xadd2", xadd21);
            dataCmd.Parameters.AddWithValue("@xtimage", xtimage1);
            dataCmd.Parameters.AddWithValue("@xdate", xdate1);
            dataCmd.Parameters.AddWithValue("@xcustom", xcustom1);
            dataCmd.Parameters.AddWithValue("@xurl", xurl1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
            dataCmd.Parameters.AddWithValue("@zemail", zemail1);
            dataCmd.Parameters.AddWithValue("@ztime", ztime1);
            dataCmd.Parameters.AddWithValue("@zutime", ztime1);
            dataCmd.Parameters.AddWithValue("@xmodper", xmodper);

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

                if (xmodper == "sel")
                {

                    datacmd1.Connection = conn1;

                    if (str == "save")
                    {
                        query = "INSERT INTO zmodper (zid,xmod) VALUES (@zid,@xmod)";
                    }
                    else if (str == "update")
                    {
                        query = "UPDATE zmodper SET xmod=@xmod WHERE zid=@zid " + 
                                "IF @@ROWCOUNT = 0 " +
                                "BEGIN " +
                                "INSERT INTO zmodper (zid,xmod) VALUES (@zid,@xmod) " +
                                "END ";
                    }
                    else
                    {
                        query = "DELETE FROM zmodper WHERE zid=@zid";
                    }

                    datacmd1.CommandText = query;

                    string xmod1 = "";

                    for (int i = 0; i < ListBox2.Items.Count; i++)
                    {
                        xmod1 = xmod1 + "|" + ListBox2.Items[i].Value.ToString();
                    }


                    datacmd1.Parameters.AddWithValue("@zid", zid1);
                    datacmd1.Parameters.AddWithValue("@xmod", xmod1);

                    conn1.Close();
                    conn1.Open();
                    datacmd1.ExecuteNonQuery();
                    conn1.Close();




                }








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
            string str = "SELECT zid FROM zbusiness ";
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
                    if (dtzuser.Rows[i][0].ToString().Trim() == zid.Text.ToString().Trim())
                    {
                        pk = zid.Text.ToString();
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
                //if (xuser.Text != "")
                //{
                    checkpk();

                    if (pk == "false")
                    {
                        if (zorg.Text == "")
                        {
                            string message = "Please Enter Business Name";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                            return;
                        }
                        //if (xrole.Text != "[Select]")
                        //{
                            saveAndUpdate("save");
                        //}
                        //else
                        //{
                        //    msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                        //}




                    }
                    else
                    {
                        string message = "Add data unsuccessfull. Because ID you enter already exist into database. Please enter another.";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                       
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                    }
                //}
                //else
                //{
                //    msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";
                //}
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            zid.Text = "";
            zorg.Text = "";
            zorg1.Text = "";
            xshort.Text = "";
            xemail.Text = "";
            xbusscat.Text = "[Select]";
            xcur.Text = "[Select]";
            xadd1.Value = "";
            xadd2.Value = "";
            zactive.Checked = true;
            xtimage.Text = "";
            xdate.Text = DateTime.Now.ToString("M/d/yyyy");
            xcustom.Value = "";
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
                msg.InnerHtml = "ID : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string zid1 = ((LinkButton)sender).Text;


                string str = "SELECT zid,zorg,xshort,xemail,xbusscat,xcur,xadd1,xadd2,xtimage,xdate,xcustom,xurl,zactive,xmodper,zorg1 FROM zbusiness where zid=@zid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@zid", zid1);
                da.Fill(dts, "tempzuser");

                DataTable dtzuser = new DataTable();
                dtzuser = dts.Tables[0];

                zid.Text = dtzuser.Rows[0][0].ToString();
                zorg.Text = dtzuser.Rows[0][1].ToString();
                xshort.Text = dtzuser.Rows[0][2].ToString();
                xemail.Text = dtzuser.Rows[0][3].ToString();
                xbusscat.Text = dtzuser.Rows[0][4].ToString();
                xcur.Text = dtzuser.Rows[0][5].ToString();
                xadd1.Value = dtzuser.Rows[0][6].ToString();
                xadd2.Value = dtzuser.Rows[0][7].ToString();
                xtimage.Text = dtzuser.Rows[0][8].ToString();
                xdate.Text = ((DateTime)dtzuser.Rows[0][9]).ToString("M/d/yyyy");
                xcustom.Value = dtzuser.Rows[0][10].ToString();
                xurl.Text = dtzuser.Rows[0][11].ToString();
                if ((int)dtzuser.Rows[0][12] == 1)
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }


                if (dtzuser.Rows[0][13].ToString() == "all")
                {
                    xmod.Text = "All";
                    Panel2.Visible = false;
                }
                else
                {
                    xmod.Text = "Selected Module";
                    Panel2.Visible = true;

                    str = "SELECT xmod FROM zmodper WHERE zid=@zid";
                    SqlDataAdapter da3 = new SqlDataAdapter(str, conn1);

                    dts.Reset();

                    da3.SelectCommand.Parameters.AddWithValue("@zid", zid1);
                    da3.Fill(dts, "tempz");

                    DataTable dtxmod = new DataTable();
                    dtxmod = dts.Tables[0];

                    if (dtxmod.Rows.Count > 0)
                    {
                        string temploc = dtxmod.Rows[0][0].ToString();
                        string[] xxmod;
                        //ArrayList ztxloc = new ArrayList();
                        xxmod = temploc.Split('|');
                        ListBox2.Items.Clear();
                        foreach (string mod in xxmod)
                        {
                            //ztxloc.Add(loc.Trim());
                            if (mod != "")
                            {
                                //ListBox2.Items.Add(mod.Trim());
                                AddListBoxItem lt_add = new AddListBoxItem(ListBox2,"select xid,xmenunm from ztmenu where xid="+ mod );
                            }
                        }


                    }

                }

                zorg1.Text = dtzuser.Rows[0]["zorg1"].ToString();

                

               
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


                //if (xuser.Text != "")
                //{



                    checkpk();
                    if (pk != "false")
                    {
                        if (zorg.Text == "")
                        {
                            string message = "Please Enter Business Name";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                            return;
                        }

                        //if (xrole.Text != "[Select]")
                        //{
                        //    if (xpass.Value == "")
                        //    {
                        //        isPassFildEmpty = 1;
                        //    }
                           saveAndUpdate("update");
                        //}
                        //else
                        //{
                        //    msg.InnerText = "Unsuccessfully add data. Please fill all the required fields, mentioned by '*'";

                        //}

                    }
                    else
                    {
                        msg.InnerHtml = "ID you provide don't found in database, please select ID from list ";
                        
                    }


                //}
                //else
                //{
                //    msg.InnerHtml = "You didn't provide any user. Please select user from list.";
                //    xuser.Focus();
                //}


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtconformmessageValue.Value == "Yes")
            //    {

            //        if (xuser.Text != "")
            //        {



            //            checkpk();
            //            if (pk != "false")
            //            {
            //                //string message = "Do you really want to delete?";
            //                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowYesNo('" + message + "');", true);


            //                saveAndUpdate("delete");

            //            }
            //            else
            //            {
            //                msg.InnerHtml = "User you provide don't found in database, please select user from list ";
            //                xuser.Focus();
            //            }


            //        }
            //        else
            //        {
            //            msg.InnerHtml = "You didn't provide any user. Please select user from list.";
            //            xuser.Focus();
            //        }
            //    }


            //}
            //catch (Exception exp)
            //{
            //    msg.InnerHtml = exp.Message;
            //}
        }


        protected void xmod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xmod.Text == "Selected Module")
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