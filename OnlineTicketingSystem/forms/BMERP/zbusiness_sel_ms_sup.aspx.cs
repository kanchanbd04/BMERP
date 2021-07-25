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
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml.Linq;
using OnlineTicketingSystem.Forms;


namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class zbusiness_sel_ms_sup : System.Web.UI.Page
    {
       

        string key;
        string curuser;
        string pagew;
        string level ;
        string xhrc11;
        string xhrc22;
        string xhrc33;
        string xhrc44;
        string xhrc55;
        bool checkuser = false;
        ArrayList menu = new ArrayList();

        ArrayList permis = new ArrayList();
        //private List<zbusiness_glmst> ltZbusinessGlmst = new List<zbusiness_glmst>(); 
        string permission = "";

        public void fnFillDataGrid()
        {

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();


            //dts.Reset();
            //string str = "SELECT zid1,zorg,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5 FROM ztemporary WHERE zemail=@zemail and xsession=@xsession";
            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            //da.SelectCommand.Parameters.Add("@zemail",HttpContext.Current.Session["curuser"]);
            //da.SelectCommand.Parameters.Add("@xsession", HttpContext.Current.Session.SessionID);
            //da.Fill(dts, "tempztcode");
            ////DataView dv = new DataView(dts.Tables[0]);
            //DataTable dtztcode = new DataTable();
            //dtztcode = dts.Tables[0];
            //GridView1.DataSource = dtztcode;
            //GridView1.DataBind();

            


            //dts.Dispose();
            //dtztcode.Dispose();
            //da.Dispose();
            //conn1.Dispose();
        }

        protected void FillControls(object sender, EventArgs e)
        {
            //try
            //{
            //    //msg.InnerHtml = "City : " + ((LinkButton)sender).Text;
            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    DataSet dts = new DataSet();

            //    dts.Reset();

            //    string xname1 = ((LinkButton)sender).Text;


            //    string str = "SELECT xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,zorg FROM ztemporary where zid1=@zid1 and zemail=@zemail and xsession=@xsession";
            //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            //    da.SelectCommand.Parameters.AddWithValue("@zid1", ((LinkButton)sender).Text);
            //    da.SelectCommand.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"].ToString());
            //    da.SelectCommand.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID.ToString());
            //    da.Fill(dts, "tempztcode");
            //    DataTable dtztcode = new DataTable();
            //    dtztcode = dts.Tables[0];
            //    //msg.InnerHtml = dtztcode.Rows[0][0].ToString();
            //    if (dtztcode.Rows[0]["xhrc1"].ToString() != "")
            //    {
            //        xhrc1.Text = dtztcode.Rows[0]["xhrc1"].ToString();
            //        fnFillLevel("level1");
            //    }
            //    if (dtztcode.Rows[0]["xhrc2"].ToString() != "")
            //    {
            //        xhrc2.Text = dtztcode.Rows[0]["xhrc2"].ToString();
            //        fnFillLevel("level2");
            //    }
            //    if (dtztcode.Rows[0]["xhrc3"].ToString() != "")
            //    {
            //        xhrc3.Text = dtztcode.Rows[0]["xhrc3"].ToString();
            //        fnFillLevel("level3");
            //    }
            //    if (dtztcode.Rows[0]["xhrc4"].ToString() != "")
            //    {
            //        xhrc4.Text = dtztcode.Rows[0]["xhrc4"].ToString();
            //        fnFillLevel("level4");
            //    }
            //    if (dtztcode.Rows[0]["xhrc5"].ToString() != "")
            //    {
            //        xhrc5.Text = dtztcode.Rows[0]["xhrc5"].ToString();
            //    }
            //    msg.InnerHtml = "";



            //    //if (TreeView1.SelectedNode.Value != "0" && TreeView1.SelectedNode.Value != "888888" && TreeView1.SelectedNode.Checked == true)
            //    //{

            //    Label1.Text = "Select Level for Business <font color=green>\"" + dtztcode.Rows[0]["zorg"].ToString() + "\" </font>";
            //    //}
            //    //else
            //    //{
            //    //    if (TreeView1.SelectedNode.Value != "0" && TreeView1.SelectedNode.Value != "888888" && TreeView1.Nodes[0].ChildNodes[0].Checked == true)
            //    //    {
            //    //        Label1.Text = "Select Level for Business <font color=green>\"" + TreeView1.SelectedNode.Text + "\" </font>";
            //    //    }
            //    //    else
            //    //    {
            //    //        Label1.Text = "Select Level for Business";
            //    //    }

            //    //}



            //    dts.Dispose();
            //    dtztcode.Dispose();
            //    da.Dispose();
            //    conn1.Dispose();
            //    UpdatePanel3.Update();
            //    UpdatePanel4.Update();
            //    UpdatePanel6.Update();
            //    UpdatePanel7.Update();
            //    UpdatePanel8.Update();
            //    UpdatePanel1.Update();
            //    ViewState["key"] = ((LinkButton)sender).Text;
                
            //    fnFillDataGrid();
            //}
            //catch (Exception exp)
            //{
            //    msg.InnerHtml = exp.Message;
            //    msg.Style.Value = zglobal.errormsg;
            //}
        }
        private void fnFillLevel(string flag,DropDownList xhrc1, DropDownList xhrc2,DropDownList xhrc3, DropDownList xhrc4, DropDownList xhrc5)
        {
            //try
            //{
            //    string cs = zglobal.constring;
            //    //msg.InnerHtml = xhrc1.Text;

            //    if (flag == "load")
            //    {
            //        xhrc1.Items.Clear();
            //        xhrc1.Items.Add("[Select]");
            //        using (SqlConnection con = new SqlConnection(cs))
            //        {
            //            string query = "SELECT xhrc1 FROM glhrc11";
            //            SqlCommand cmd = new SqlCommand(query, con);
            //            cmd.CommandType = CommandType.Text;
            //            con.Open();
            //            SqlDataReader rdr = cmd.ExecuteReader();
            //            while (rdr.Read())
            //            {
            //                xhrc1.Items.Add(rdr["xhrc1"].ToString());
            //            }
            //        }
            //        xhrc1.Text = "[Select]";
            //    }


            //    if (xhrc1.Text != "[Select]" && flag == "level1")
            //    {
            //        xhrc2.Items.Clear();
            //        xhrc2.Items.Add("[Select]");
            //        using (SqlConnection con = new SqlConnection(cs))
            //        {
            //            string query = "SELECT xhrc2 FROM glhrc21 WHERE xhrc1=@xhrc1";
            //            SqlCommand cmd = new SqlCommand(query, con);
            //            cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
            //            cmd.CommandType = CommandType.Text;
            //            con.Open();
            //            SqlDataReader rdr = cmd.ExecuteReader();
            //            while (rdr.Read())
            //            {
            //                xhrc2.Items.Add(rdr["xhrc2"].ToString());
            //            }
            //        }
            //        xhrc2.Enabled = true;
            //    }

            //    if (xhrc2.Text != "[Select]" && flag == "level2")
            //    {
            //        xhrc3.Items.Clear();
            //        xhrc3.Items.Add("[Select]");
            //        using (SqlConnection con = new SqlConnection(cs))
            //        {
            //            string query = "SELECT xhrc3 FROM glhrc31 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2";
            //            SqlCommand cmd = new SqlCommand(query, con);
            //            cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
            //            cmd.Parameters.AddWithValue("@xhrc2", xhrc2.Text);
            //            cmd.CommandType = CommandType.Text;
            //            con.Open();
            //            SqlDataReader rdr = cmd.ExecuteReader();
            //            while (rdr.Read())
            //            {
            //                xhrc3.Items.Add(rdr["xhrc3"].ToString());
            //            }
            //        }
            //        xhrc3.Enabled = true;
            //    }
            //    if (xhrc3.Text != "[Select]" && flag == "level3")
            //    {
            //        xhrc4.Items.Clear();
            //        xhrc4.Items.Add("[Select]");
            //        using (SqlConnection con = new SqlConnection(cs))
            //        {
            //            string query = "SELECT xhrc4 FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3";
            //            SqlCommand cmd = new SqlCommand(query, con);
            //            cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
            //            cmd.Parameters.AddWithValue("@xhrc2", xhrc2.Text);
            //            cmd.Parameters.AddWithValue("@xhrc3", xhrc3.Text);
            //            cmd.CommandType = CommandType.Text;
            //            con.Open();
            //            SqlDataReader rdr = cmd.ExecuteReader();
            //            while (rdr.Read())
            //            {
            //                xhrc4.Items.Add(rdr["xhrc4"].ToString());
            //            }
            //        }
            //        xhrc4.Enabled = true;
            //    }
            //    if (xhrc4.Text != "[Select]" && flag == "level4")
            //    {
            //        xhrc5.Items.Clear();
            //        xhrc5.Items.Add("[Select]");
            //        using (SqlConnection con = new SqlConnection(cs))
            //        {
            //            string query = "SELECT xhrc5 FROM glhrc51 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
            //            SqlCommand cmd = new SqlCommand(query, con);
            //            cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
            //            cmd.Parameters.AddWithValue("@xhrc2", xhrc2.Text);
            //            cmd.Parameters.AddWithValue("@xhrc3", xhrc3.Text);
            //            cmd.Parameters.AddWithValue("@xhrc4", xhrc4.Text);
            //            cmd.CommandType = CommandType.Text;
            //            con.Open();
            //            SqlDataReader rdr = cmd.ExecuteReader();
            //            while (rdr.Read())
            //            {
            //                xhrc5.Items.Add(rdr["xhrc5"].ToString());
            //            }
            //        }
            //        xhrc5.Enabled = true;
            //    }
            //    if (xhrc1.Text == "[Select]")
            //    {
            //        xhrc2.Items.Clear();
            //        xhrc3.Items.Clear();
            //        xhrc4.Items.Clear();
            //        xhrc5.Items.Clear();
            //        xhrc2.Enabled = false;
            //        xhrc3.Enabled = false;
            //        xhrc4.Enabled = false;
            //        xhrc5.Enabled = false;
            //    }
            //    if (xhrc2.Text == "[Select]")
            //    {
            //        //xhrc2.Items.Clear();
            //        xhrc3.Items.Clear();
            //        xhrc4.Items.Clear();
            //        xhrc5.Items.Clear();
            //        //xhrc2.Enabled = false;
            //        xhrc3.Enabled = false;
            //        xhrc4.Enabled = false;
            //        xhrc5.Enabled = false;
            //    }
            //    if (xhrc3.Text == "[Select]")
            //    {
            //        //xhrc2.Items.Clear();
            //        //xhrc3.Items.Clear();
            //        xhrc4.Items.Clear();
            //        xhrc5.Items.Clear();
            //        //xhrc2.Enabled = false;
            //        //xhrc3.Enabled = false;
            //        xhrc4.Enabled = false;
            //        xhrc5.Enabled = false;
            //    }
            //    if (xhrc4.Text == "[Select]")
            //    {
            //        //xhrc2.Items.Clear();
            //        //xhrc3.Items.Clear();
            //        //xhrc4.Items.Clear();
            //        xhrc5.Items.Clear();
            //        //xhrc2.Enabled = false;
            //        //xhrc3.Enabled = false;
            //        //xhrc4.Enabled = false;
            //        xhrc5.Enabled = false;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    msg.InnerHtml = exp.Message;
            //    msg.Style.Value = zglobal.errormsg;
            //}

        }

        //protected void xhrc1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fnFillLevel("level1");
        //}

        //protected void xhrc2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fnFillLevel("level2");
        //}

        //protected void xhrc3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fnFillLevel("level3");
        //}

        //protected void xhrc4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fnFillLevel("level4");
        //}
        private void fnChangeTextofButton()
        {
            //btnPermission.Text = "Reset";
            //btnUpdate.Visible = true;
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


                if (!IsPostBack)
                {

                    zglobal.fnDeleteBusinessSupAP(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                    key = Request.QueryString["key"] != "" ? Request.QueryString["key"] : "-1";

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts4 = new DataSet();


                    dts4.Reset();
                    //string str = "select zid,(select zorg from zbusiness where zid=glmstbiz.zid) as zorg, xhrc1,xhrc2,xhrc3,xhrc4,xhrc5 from glmstbiz where xrowglmstd=@xrowglmstd and xflag=1";
                    //string str = "select zid,(select zorg from zbusiness where zid=glmstbiz.zid) as zorg, coalesce(xhrc1,'') as xhrc1,coalesce(xhrc2,'') as xhrc2,coalesce(xhrc3,'') as xhrc3,coalesce(xhrc4,'') as xhrc4,coalesce(xhrc5,'') as xhrc5,xflag from glmstbiz where xrowglmstd=@xrowglmstd";
                    string str = "select zid,(select zorg from zbusiness where zid=mssupbiz.zid) as zorg, coalesce(xap,'') as xap from mssupbiz where xrowd=@xrowd";



                    SqlDataAdapter da4 = new SqlDataAdapter(str, conn1);

                    int xrowd = Int32.Parse(key);
                    da4.SelectCommand.Parameters.AddWithValue("@xrowd", xrowd);




                    da4.Fill(dts4, "tempdt");


                    DataTable temp = new DataTable();

                    temp = dts4.Tables[0];

            
                    DataTable tempTable = new DataTable();
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        using (DataSet dts = new DataSet())
                        {
                            string query;
                            if (HttpContext.Current.Session["curuser"].ToString() == "bm")
                            {
                                query = "SELECT zid,zorg from zbusiness";
                            }
                            else
                            {
                                query = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
                            }
                            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                            da.SelectCommand.Parameters.AddWithValue("@xid", HttpContext.Current.Session["curuser"].ToString());
                            da.Fill(dts, "tempTable");
                            //DataTable tempTable = new DataTable();
                            tempTable = dts.Tables["tempTable"];

                            if (tempTable.Rows.Count <= 0)
                            {
                                query = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                                SqlDataAdapter da1 = new SqlDataAdapter(query, conn);

                                //xid = this.Page.User.Identity.Name;
                                da1.SelectCommand.Parameters.AddWithValue("@xuser", HttpContext.Current.Session["curuser"].ToString());

                                dts.Reset();

                                da1.Fill(dts, "tempdt");
                                //DataTable temp1 = new DataTable();
                                tempTable.Reset();
                                tempTable = dts.Tables[0];

                                if (tempTable.Rows.Count > 0)
                                {
                                    query = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
                                    SqlDataAdapter da2 = new SqlDataAdapter(query, conn);

                                    da2.SelectCommand.Parameters.AddWithValue("@xid", tempTable.Rows[0][0].ToString());

                                    dts.Reset();

                                    da2.Fill(dts, "tempdt");
                                    tempTable.Reset();
                                    tempTable = dts.Tables[0];
                                    //if (tempTable.Rows.Count <= 0)
                                    //{
                                    //    FailureText.Text = "Your Id or your user role have not any permission to access any business";
                                    //    return;
                                    //}
                                    da2.Dispose();
                                }
                                else
                                {
                                    //FailureText.Text = "Your Id have not any permission to access any business";
                                    //return;
                                }

                                da1.Dispose();
                            }

                            GridView1.DataSource = tempTable;
                            GridView1.DataBind();

                            if (temp.Rows.Count > 0)
                            {
                                foreach (GridViewRow gdrow in GridView1.Rows)
                                {
                                    CheckBox chk = (CheckBox)gdrow.FindControl("selbiz");
                                    TextBox xar = (TextBox)gdrow.FindControl("accounts");
                                    ImageButton acclist = (ImageButton) gdrow.FindControl("acclist");

                                    foreach (DataRow dbrow in temp.Rows)
                                    {
                                        if (gdrow.Cells[1].Text.ToString() == dbrow["zid"].ToString())
                                        {
                                            chk.Checked = true;
                                            xar.Text = dbrow["xap"].ToString();
                                            acclist.Enabled = true;
                                            xar.Enabled = true;

                                            break;
                                        }
                                    }
                                }
                            }

                            da.Dispose();
                            da4.Dispose();
                        }
                    }

                    int count = 0;
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chksel = (CheckBox)row.FindControl("selbiz");

                        if (chksel.Checked)
                        {
                            count += 1;
                        }
                    }

                    if (count == GridView1.Rows.Count)
                    {
                        CheckBox chkalll = (CheckBox)GridView1.HeaderRow.FindControl("chkall");
                        chkalll.Checked = true;
                    }
                }

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
            
        }

        ArrayList arr = new ArrayList();

        protected void btnPermission_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        if (btnPermission.Text == "Save")
            //        {

            //            foreach (TreeNode node in TreeView1.CheckedNodes)
            //            {
            //                if (node.Parent == null)
            //                {
            //                    arr.Add(node.Value);
            //                }
            //                else
            //                {
            //                    arr.Add(node.Value);
            //                    //node.Parent.Checked = true;
            //                    SelectParent(node.Parent);

            //                }


            //            }

            //            ArrayList permission = RemoveDuplicate(arr);

            //            string uwmpermis = "";

            //            foreach (string permis in permission)
            //            {
            //                uwmpermis = uwmpermis + "|" + permis;
            //            }


            //            if (uwmpermis == "")
            //            {
            //                //string message = "You are not select any permission. Save unsuccessfull.";
            //                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            //                msg.InnerHtml = "You are not select any permission. Save unsuccessfull.";
            //                return;
            //            }
            //            SqlConnection conn;
            //            conn = new SqlConnection(zglobal.constring);
            //            SqlCommand dataCmd = new SqlCommand();
            //            dataCmd.Connection = conn;

            //            string str = "INSERT INTO ztpermis (xid,xpermisunit) VALUES (@xid,@xpermis)";
            //            dataCmd.CommandText = str;

            //            string xid = curuser;
            //            string xpermis = uwmpermis;

            //            dataCmd.Parameters.AddWithValue("@xid", xid);
            //            dataCmd.Parameters.AddWithValue("@xpermis", xpermis);



            //            conn.Close();
            //            conn.Open();
            //            dataCmd.ExecuteNonQuery();
            //            conn.Close();

            //            //dataCmd.Dispose();
            //            //conn.Dispose();


            //            SqlConnection conn1;
            //            conn1 = new SqlConnection(zglobal.constring);
            //            SqlCommand dataCmd1 = new SqlCommand();
            //            dataCmd1.Connection = conn1;

            //            string str1;

            //            if (pagew == "user")
            //            {
            //                str1 = "UPDATE ztuser SET xpermisstunit=1 WHERE xuser=@xuser";
            //                dataCmd1.CommandText = str1;

            //                string xuser = curuser;


            //                dataCmd1.Parameters.AddWithValue("@xuser", xuser);
            //            }
            //            else
            //            {
            //                str1 = "UPDATE ztrole SET xpermisstunit=1 WHERE xrole=@xrole";
            //                dataCmd1.CommandText = str1;

            //                string xrole = curuser;


            //                dataCmd1.Parameters.AddWithValue("@xrole", xrole);
            //            }




            //            conn1.Close();
            //            conn1.Open();
            //            dataCmd1.ExecuteNonQuery();
            //            conn1.Close();

            //            //dataCmd1.Dispose();
            //            //conn1.Dispose();
            //            fnChangeTextofButton();
            //        }
            //        else
            //        {
            //            SqlConnection conn;
            //            conn = new SqlConnection(zglobal.constring);
            //            SqlCommand dataCmd = new SqlCommand();
            //            dataCmd.Connection = conn;

            //            string str = "DELETE FROM ztpermis WHERE xid=@xid";
            //            dataCmd.CommandText = str;

            //            string xid = curuser;

            //            dataCmd.Parameters.AddWithValue("@xid", xid);

            //            conn.Close();
            //            conn.Open();
            //            dataCmd.ExecuteNonQuery();
            //            conn.Close();

            //            SqlConnection conn1;
            //            conn1 = new SqlConnection(zglobal.constring);
            //            SqlCommand dataCmd1 = new SqlCommand();
            //            dataCmd1.Connection = conn1;


            //            string str1;

            //            if (pagew == "user")
            //            {
            //                str1 = "UPDATE ztuser SET xpermisstunit=0 WHERE xuser=@xuser";
            //                dataCmd1.CommandText = str1;

            //                string xuser = curuser;


            //                dataCmd1.Parameters.AddWithValue("@xuser", xuser);
            //            }
            //            else
            //            {
            //                str1 = "UPDATE ztrole SET xpermisstunit=0 WHERE xrole=@xrole";
            //                dataCmd1.CommandText = str1;

            //                string xrole = curuser;


            //                dataCmd1.Parameters.AddWithValue("@xrole", xrole);
            //            }




            //            conn1.Close();
            //            conn1.Open();
            //            dataCmd1.ExecuteNonQuery();
            //            conn1.Close();

            //            CheckUncheckTreeNode(TreeView1.Nodes, false);
            //            btnPermission.Text = "Save";
            //            btnUpdate.Visible = false;
            //        }
            //        tran.Complete();


            //    }
            //}
            //catch (Exception exp)
            //{
            //    Response.Write(exp.Message);
            //}
        }

        private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                trNode.Checked = isCheck;
                if (trNode.ChildNodes.Count > 0)
                    CheckUncheckTreeNode(trNode.ChildNodes, isCheck);
            }
        }

        private void SelectParent(TreeNode node)
        {
            if (node.Parent == null)
            {
                // arr.Add(node.Value);
            }
            else
            {
                arr.Add(node.Value);
                //node.Parent.Checked = true;
                SelectParent(node.Parent);
            }
        }


        private static ArrayList RemoveDuplicate(ArrayList sourceList)
        {
            ArrayList list = new ArrayList();
            foreach (string item in sourceList)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }

            return list;
        }


        private void GetTreeItem()
        {
            ////SqlConnection conn1;
            ////conn1 = new SqlConnection(zglobal.constring);
            ////DataSet dts = new DataSet();


            ////dts.Reset();
            ////string str = "SELECT zid,zorg FROM zbusiness";

            ////SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            ////da.Fill(dts, "tempdt");
            ////DataTable temp = new DataTable();
            ////temp = dts.Tables[0];

            //////dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

            ////foreach (DataRow level1DataRows in dts.Tables[0].Rows)
            ////{
            ////    //if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
            ////    //{
            //    TreeNode parentitem = new TreeNode();
            //    //parentitem.Text = level1DataRows["zorg"].ToString();
            //    // parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
            //    //parentitem.Value = level1DataRows["zid"].ToString();

            //    parentitem.Text = "Select Business";
            //    parentitem.Value = "888888";

            //    //GetChildRows(level1DataRows,parentitem);
            //    GetChildRows(parentitem);

            //    TreeView1.Nodes.Add(parentitem);

            //    //if (checkuser)
            //    //{
            //    //    foreach (string st in permis)
            //    //    {
            //    //        if (st.Trim() == parentitem.Value.Trim())
            //    //        {
            //    //            parentitem.Checked = true;
            //    //            break;
            //    //        }
            //    //    }
            //    //}
            //    //}
            ////}

            ////conn1.Dispose();
            ////da.Dispose();
            ////dts.Dispose();
        }

        //private void GetChildRows(DataRow dataRow, TreeNode mnitem)
        private void GetChildRows(TreeNode mnitem)
        {
            //TreeNode childitem1 = new TreeNode();
            //childitem1.Text = "All Business";
            //// childitem.NavigateUrl = childRow["xurl"].ToString();
            //childitem1.Value = "0";

            //mnitem.ChildNodes.Add(childitem1);

            ////DataRow[] childRows = dataRow.GetChildRows("ChildRows");

            ////SqlConnection conn1;
            ////conn1 = new SqlConnection(zglobal.constring);
            ////DataSet dts = new DataSet();


            ////dts.Reset();
            ////string str = "SELECT zid,zorg FROM zbusiness";

            ////SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            ////da.Fill(dts, "tempdt");
            ////DataTable childRows = new DataTable();
            ////childRows = dts.Tables[0];
            //DataTable tempTable = new DataTable();
            //using (SqlConnection conn = new SqlConnection(zglobal.constring))
            //{
            //    using (DataSet dts = new DataSet())
            //    {
            //        string query;
            //        if (HttpContext.Current.Session["curuser"].ToString() == "bm")
            //        {
            //            query = "SELECT zid,zorg from zbusiness";
            //        }
            //        else
            //        {
            //            query = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
            //        }
            //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //        da.SelectCommand.Parameters.AddWithValue("@xid", HttpContext.Current.Session["curuser"].ToString());
            //        da.Fill(dts, "tempTable");
            //        //DataTable tempTable = new DataTable();
            //        tempTable = dts.Tables["tempTable"];

            //        if (tempTable.Rows.Count <= 0)
            //        {
            //            query = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

            //            SqlDataAdapter da1 = new SqlDataAdapter(query, conn);

            //            //xid = this.Page.User.Identity.Name;
            //            da1.SelectCommand.Parameters.AddWithValue("@xuser", HttpContext.Current.Session["curuser"].ToString());

            //            dts.Reset();

            //            da1.Fill(dts, "tempdt");
            //            //DataTable temp1 = new DataTable();
            //            tempTable.Reset();
            //            tempTable = dts.Tables[0];

            //            if (tempTable.Rows.Count > 0)
            //            {
            //                query = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
            //                SqlDataAdapter da2 = new SqlDataAdapter(query, conn);

            //                da2.SelectCommand.Parameters.AddWithValue("@xid", tempTable.Rows[0][0].ToString());

            //                dts.Reset();

            //                da2.Fill(dts, "tempdt");
            //                tempTable.Reset();
            //                tempTable = dts.Tables[0];
            //                //if (tempTable.Rows.Count <= 0)
            //                //{
            //                //    FailureText.Text = "Your Id or your user role have not any permission to access any business";
            //                //    return;
            //                //}
            //            }
            //            else
            //            {
            //                //FailureText.Text = "Your Id have not any permission to access any business";
            //                //return;
            //            }

            //            da1.Dispose();
            //        }

            //        //ListItem llt1 = new ListItem("[Select]", "000");
            //        //ArrayList alt = new ArrayList();
            //        //DropDownList1.Items.Add(llt1);

            //        //for (int i = 0; i < tempTable.Rows.Count; i++)
            //        //{
            //        //    ListItem llt = new ListItem(tempTable.Rows[i][1].ToString(), tempTable.Rows[i][0].ToString());
            //        //    DropDownList1.Items.Add(llt);
            //        //    alt.Add(tempTable.Rows[i][0].ToString());
            //        //}

            //        //HttpContext.Current.Session["zid"] = alt;
            //        ////ArrayList alt1 = (ArrayList) HttpContext.Current.Session["zid"];
            //        ////foreach (string str in alt1)
            //        ////{
            //        ////    FailureText.Text = FailureText.Text + " " + str;
            //        ////}


            //        da.Dispose();
            //    }
            //}

            //DataTable childRows = new DataTable();
            //childRows = tempTable;

            //foreach (DataRow childRow in childRows.Rows)
            //{
            //    ArrayList zidList = (ArrayList) HttpContext.Current.Session["zid"];
            //    foreach (string zid in zidList)
            //    {
            //        if (zid == childRow["zid"].ToString())
            //        {
            //            TreeNode childitem = new TreeNode();
            //            childitem.Text = childRow["zorg"].ToString();
            //            // childitem.NavigateUrl = childRow["xurl"].ToString();
            //            childitem.Value = childRow["zid"].ToString();

            //            mnitem.ChildNodes.Add(childitem);

            //            if (checkuser)
            //            {
            //                foreach (string st in permis)
            //                {
            //                    if (st.Trim() == childitem.Value.Trim())
            //                    {
            //                        childitem.Checked = true;
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    //if (childRow.GetChildRows("ChildRows").Length > 0)
            //    //{
            //    //    GetChildRows(childRow, childitem);
            //    //}
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //if (btnPermission.Text == "Save")
            //    //{
            //    arr.Clear();
            //    foreach (TreeNode node in TreeView1.CheckedNodes)
            //    {
            //        if (node.Parent == null)
            //        {
            //            arr.Add(node.Value);
            //        }
            //        else
            //        {
            //            arr.Add(node.Value);
            //            //node.Parent.Checked = true;
            //            SelectParent(node.Parent);

            //        }


            //    }

            //    ArrayList permission = RemoveDuplicate(arr);

            //    string uwmpermis = "";

            //    foreach (string permis in permission)
            //    {
            //        uwmpermis = uwmpermis + "|" + permis;
            //    }


            //    if (uwmpermis == "")
            //    {
            //        //string message = "You are not select any permission. Save unsuccessfull.";
            //        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
            //        msg.InnerHtml = "You are not select any permission. Update unsuccessfull.";
            //        return;
            //    }
            //    SqlConnection conn;
            //    conn = new SqlConnection(zglobal.constring);
            //    SqlCommand dataCmd = new SqlCommand();
            //    dataCmd.Connection = conn;

            //    string str = "UPDATE ztpermis SET xpermisunit=@xpermis WHERE xid=@xid";
            //    dataCmd.CommandText = str;

            //    string xid = curuser;
            //    string xpermis = uwmpermis;

            //    dataCmd.Parameters.AddWithValue("@xid", xid);
            //    dataCmd.Parameters.AddWithValue("@xpermis", xpermis);



            //    conn.Close();
            //    conn.Open();
            //    dataCmd.ExecuteNonQuery();
            //    conn.Close();

            //    dataCmd.Dispose();
            //    conn.Dispose();



            //    //}

            //}
            //catch (Exception exp)
            //{
            //    Response.Write(exp.Message);
            //}
        }

        protected void btnPermission_Click1(object sender, EventArgs e)
        {
            try
            {
                //using (TransactionScope tran = new TransactionScope())
                //{
                //if (btnPermission.Text == "Save")
                //{
                //arr.Clear();

                //////foreach (TreeNode node in TreeView1.CheckedNodes)
                //////{
                //////    if (node.Parent == null)
                //////    {
                //////        // arr.Add(node.Value);
                //////    }
                //////    else
                //////    {
                //////        arr.Add(node.Value);
                //////        //node.Parent.Checked = true;
                //////        SelectParent(node.Parent);

                //////    }


                //////}

                //////ArrayList permission = RemoveDuplicate(arr);

                //////if (permission.Count <= 0)
                //////{
                //////    msg.InnerHtml = "Please select at least one business before save.";
                //////    msg.Style.Value = zglobal.infomsg;
                //////    btnPermission.Style.Value = zglobal.btnerr;
                //////    return;
                //////}
                //////else
                //////{
                //////    msg.InnerHtml = "";
                //////}

                //string uwmpermis = "";

                //foreach (string permis in permission)
                //{
                //    uwmpermis = uwmpermis + "|" + permis;
                //}

                //msg.InnerHtml = uwmpermis;
                //return;
                //if (uwmpermis == "")
                //{
                //    //string message = "You are not select any permission. Save unsuccessfull.";
                //    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                //    msg.InnerHtml = "You are not select any permission. Save unsuccessfull.";
                //    return;
                //}

                //SqlConnection conn;
                //conn = new SqlConnection(zglobal.constring);
                //SqlCommand dataCmd = new SqlCommand();
                //dataCmd.Connection = conn;

                ////string str = "INSERT INTO ztpermis (xid,xpermisunit) VALUES (@xid,@xpermis)";
                //string str = zglobal.delglhrc1zid;
                //dataCmd.CommandText = str;

                ////string xid = curuser;
                ////string xpermis = uwmpermis;

                ////dataCmd.Parameters.AddWithValue("@xid", xid);
                ////dataCmd.Parameters.AddWithValue("@xpermis", xpermis);



                //conn.Close();
                //conn.Open();
                //dataCmd.ExecuteNonQuery();
                //conn.Close();

                //dataCmd.Dispose();
                //conn.Dispose();


                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd1 = new SqlCommand();
                dataCmd1.Connection = conn1;

                string str1;

                //if (pagew == "user")
                //{
                //    str1 = "UPDATE ztuser SET xpermisstunit=1 WHERE xuser=@xuser";
                //    dataCmd1.CommandText = str1;

                //    string xuser = curuser;


                //    dataCmd1.Parameters.AddWithValue("@xuser", xuser);
                //}
                //else
                //{
                //    str1 = "UPDATE ztrole SET xpermisstunit=1 WHERE xrole=@xrole";
                //    dataCmd1.CommandText = str1;

                //    string xrole = curuser;


                //    dataCmd1.Parameters.AddWithValue("@xrole", xrole);
                //}
                //////if (permission.Contains("0"))
                //////{
                //////    permission.Clear();
                //////    // permission.Add("0");


                //////    SqlConnection conn11;
                //////    conn11 = new SqlConnection(zglobal.constring);
                //////    DataSet dts1 = new DataSet();


                //////    dts1.Reset();
                //////    string str11 = "SELECT zid FROM zbusiness";

                //////    SqlDataAdapter da1 = new SqlDataAdapter(str11, conn11);


                //////    da1.Fill(dts1, "tempdt");
                //////    DataTable tbl = new DataTable();
                //////    tbl = dts1.Tables[0];
                //////    foreach (DataRow row in tbl.Rows)
                //////    {
                //////        permission.Add(row["zid"].ToString());
                //////    }



                //////}

                //foreach (string permis in permission)
                //{



                //    //str1 = zglobal.insglhrc1zid;
                //    //dataCmd1.CommandText = str1;
                //    //dataCmd1.Parameters.AddWithValue("@zid", permis);
                //    //conn1.Close();
                //    //conn1.Open();
                //    //dataCmd1.ExecuteNonQuery();
                //    //conn1.Close();
                //    //dataCmd1.Parameters.Clear();
                //}
                using (TransactionScope tran = new TransactionScope())
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox) row.FindControl("selbiz");
                        TextBox accounts1 = (TextBox)row.FindControl("accounts");

                        if (chk.Checked)
                        {
                            if (accounts1.Text == "" || accounts1.Text == string.Empty)
                            {
                                msg.InnerHtml = "Select Account's for business '" + row.Cells[2].Text.ToString() + "'";
                                msg.Style.Value = zglobal.warningmsg;
                                return;
                            }
                            string accounts2 = accounts1.Text.ToString().Trim();

                            str1 = zglobal.insmssupap;
                            dataCmd1.CommandText = str1;
                            dataCmd1.Parameters.Clear();
                            dataCmd1.Parameters.AddWithValue("@zid5", row.Cells[1].Text.ToString());
                            dataCmd1.Parameters.AddWithValue("@zorg", row.Cells[2].Text.ToString());
                            dataCmd1.Parameters.AddWithValue("@xacc", accounts2);
                            dataCmd1.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
                            dataCmd1.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
                            conn1.Close();
                            conn1.Open();
                            dataCmd1.ExecuteNonQuery();
                            conn1.Close();
                           
                        }

                        //msg.InnerHtml = msg.InnerHtml + chk.Checked.ToString() + row.Cells[1].Text.ToString() + row.Cells[2].Text.ToString() + xhrc11.Text + xhrc22.Text +
                        //    xhrc33.Text + xhrc44.Text + xhrc55.Text +
                        //                "</br>";
                    }
                    //////foreach (string row in permission)
                    //////{

                    //////    int zid1 = Int32.Parse(row);
                    //////    string zorg = "";
                    //////    string xhrc11 = "";
                    //////    string xhrc22 = "";
                    //////    string xhrc33 = "";
                    //////    string xhrc44 = "";
                    //////    string xhrc55 = "";
                    //////    int xst = 0;

                    //////    SqlConnection conn11;
                    //////    conn11 = new SqlConnection(zglobal.constring);
                    //////    DataSet dts1 = new DataSet();


                    //////    dts1.Reset();
                    //////    string str11 = "SELECT * FROM ztemporary where zid1 is not null and zemail=@zemail and xsession=@xsession";

                    //////    SqlDataAdapter da1 = new SqlDataAdapter(str11, conn11);
                    //////    da1.SelectCommand.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
                    //////    da1.SelectCommand.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
                    //////    da1.Fill(dts1, "tempdt");
                    //////    DataTable tbl = new DataTable();
                    //////    tbl = dts1.Tables[0];

                    //////    //foreach (zbusiness_glmst zglmst in zglobal.ltZbusinessGlmst)
                    //////    //{
                    //////    //    if (zglmst.zid == Int32.Parse(row))
                    //////    //    {
                    //////    //        xhrc11 = zglmst.xhrc1;
                    //////    //        xhrc22 = zglmst.xhrc2;
                    //////    //        xhrc33 = zglmst.xhrc3;
                    //////    //        xhrc44 = zglmst.xhrc4;
                    //////    //        xhrc55 = zglmst.xhrc5;
                    //////    //        xst = 1;
                    //////    //        break;
                    //////    //    }
                    //////    //}

                    //////    //zbusiness_glmst objZbusinessGlmstPermis = new zbusiness_glmst(zid1, zorg, xhrc11, xhrc22, xhrc33,
                    //////    //    xhrc44, xhrc55);
                    //////    //zglobal.ltZbusinessGlmstPermis.Add(objZbusinessGlmstPermis);

                    //////    foreach (DataRow zglmst in tbl.Rows)
                    //////    {
                    //////        if (Int32.Parse(zglmst["zid1"].ToString()) == Int32.Parse(row))
                    //////        {
                    //////            zorg = zglmst["zorg"].ToString();
                    //////            xhrc11 = zglmst["xhrc1"].ToString();
                    //////            xhrc22 = zglmst["xhrc2"].ToString();
                    //////            xhrc33 = zglmst["xhrc3"].ToString();
                    //////            xhrc44 = zglmst["xhrc4"].ToString();
                    //////            xhrc55 = zglmst["xhrc5"].ToString();
                    //////            xst = 1;
                    //////            break;
                    //////        }
                    //////    }


                    //////    str1 = zglobal.insglmstbiz2;
                    //////    dataCmd1.CommandText = str1;
                    //////    dataCmd1.Parameters.AddWithValue("@zid2", zid1);
                    //////    dataCmd1.Parameters.AddWithValue("@zorg12", zorg);
                    //////    dataCmd1.Parameters.AddWithValue("@xhrc12", xhrc11);
                    //////    dataCmd1.Parameters.AddWithValue("@xhrc22", xhrc22);
                    //////    dataCmd1.Parameters.AddWithValue("@xhrc32", xhrc33);
                    //////    dataCmd1.Parameters.AddWithValue("@xhrc42", xhrc44);
                    //////    dataCmd1.Parameters.AddWithValue("@xhrc52", xhrc55);
                    //////    dataCmd1.Parameters.AddWithValue("@xst2", xst);
                    //////    dataCmd1.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
                    //////    dataCmd1.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
                    //////    conn1.Close();
                    //////    conn1.Open();
                    //////    dataCmd1.ExecuteNonQuery();
                    //////    conn1.Close();
                    //////    dataCmd1.Parameters.Clear();


                    //////}

                    dataCmd1.Dispose();
                    conn1.Dispose();


                    tran.Complete();

                    btnPermission.Enabled = false;
                    msg.InnerHtml = "Save completed successfully.";
                    msg.Style.Value = zglobal.successmsg;
                    btnPermission.Style.Value = zglobal.btncolor;
                }
                //fnChangeTextofButton();
                // }
                //else
                //{
                //    SqlConnection conn;
                //    conn = new SqlConnection(zglobal.constring);
                //    SqlCommand dataCmd = new SqlCommand();
                //    dataCmd.Connection = conn;

                //    string str = "DELETE FROM ztpermis WHERE xid=@xid";
                //    dataCmd.CommandText = str;

                //    string xid = curuser;

                //    dataCmd.Parameters.AddWithValue("@xid", xid);

                //    conn.Close();
                //    conn.Open();
                //    dataCmd.ExecuteNonQuery();
                //    conn.Close();

                //    SqlConnection conn1;
                //    conn1 = new SqlConnection(zglobal.constring);
                //    SqlCommand dataCmd1 = new SqlCommand();
                //    dataCmd1.Connection = conn1;


                //    string str1;

                //    if (pagew == "user")
                //    {
                //        str1 = "UPDATE ztuser SET xpermisstunit=0 WHERE xuser=@xuser";
                //        dataCmd1.CommandText = str1;

                //        string xuser = curuser;


                //        dataCmd1.Parameters.AddWithValue("@xuser", xuser);
                //    }
                //    else
                //    {
                //        str1 = "UPDATE ztrole SET xpermisstunit=0 WHERE xrole=@xrole";
                //        dataCmd1.CommandText = str1;

                //        string xrole = curuser;


                //        dataCmd1.Parameters.AddWithValue("@xrole", xrole);
                //    }




                //    conn1.Close();
                //    conn1.Open();
                //    dataCmd1.ExecuteNonQuery();
                //    conn1.Close();

                //    CheckUncheckTreeNode(TreeView1.Nodes, false);
                //    btnPermission.Text = "Save";
                //    btnUpdate.Visible = false;
                //}
                //    tran.Complete();


                //}
            }
            catch (Exception exp)
            {
                btnPermission.Style.Value = zglobal.btnerr;
                Response.Write(exp.Message);
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            
            //if (TreeView1.SelectedNode.Value != "0" && TreeView1.SelectedNode.Value != "888888" && TreeView1.SelectedNode.Checked == true)
            //{

            //    Label1.Text = "Select Level for Business <font color=green>\"" + TreeView1.SelectedNode.Text + "\" </font>";
            //}
            //else
            //{
            //    if (TreeView1.SelectedNode.Value != "0" && TreeView1.SelectedNode.Value != "888888" && TreeView1.Nodes[0].ChildNodes[0].Checked == true)
            //    {
            //        Label1.Text = "Select Level for Business <font color=green>\"" + TreeView1.SelectedNode.Text + "\" </font>";
            //    }
            //    else
            //    {
            //        Label1.Text = "Select Level for Business";    
            //    }
                
            //}
            //fnFillLevel("load");
            //ViewState["key"] = null;
            //UpdatePanel3.Update();
            //UpdatePanel4.Update();
            //UpdatePanel6.Update();
            //UpdatePanel7.Update();
            //UpdatePanel8.Update();
            //UpdatePanel1.Update();

            //this.Panel1.Style.Add("Top", "100");
            //this.Panel1.Style.Add("Left", "100");
        
            
            ////Label1.Text = TreeView1.Nodes[0].ChildNodes[0].Value;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
                
            //    if (TreeView1.SelectedNode.Value != "0" && TreeView1.SelectedNode.Value != "888888" && TreeView1.SelectedNode.Checked == true)
            //    {

            //        Label1.Text = "Select Level for Business <font color=green>\"" + TreeView1.SelectedNode.Text + "\" </font>";
            //        int zid1 = Int32.Parse(TreeView1.SelectedNode.Value);
            //        string zorg1 = TreeView1.SelectedNode.Text;
            //        //string xhrc11 = Request.Form["xhrc1"] == "-1" ? "" : Request.Form["xhrc1"];
            //        //string xhrc22 = Request.Form["xhrc2"] == "-1" ? "" : Request.Form["xhrc2"];
            //        //string xhrc33 = Request.Form["xhrc3"] == "-1" ? "" : Request.Form["xhrc3"];
            //        //string xhrc44 = Request.Form["xhrc4"] == "-1" ? "" : Request.Form["xhrc4"];
            //        //string xhrc55 = Request.Form["xhrc5"] == "-1" ? "" : Request.Form["xhrc5"];
            //        string xhrc11 = xhrc1.Text.ToString().Trim() == "[Select]" ? "" : xhrc1.Text.ToString().Trim();
            //        string xhrc22 = xhrc2.Text.ToString().Trim() == "[Select]" ? "" : xhrc2.Text.ToString().Trim();
            //        string xhrc33 = xhrc3.Text.ToString().Trim() == "[Select]" ? "" : xhrc3.Text.ToString().Trim();
            //        string xhrc44 = xhrc4.Text.ToString().Trim() == "[Select]" ? "" : xhrc4.Text.ToString().Trim();
            //        string xhrc55 = xhrc5.Text.ToString().Trim() == "[Select]" ? "" : xhrc5.Text.ToString().Trim();
            //        //Label2.Text = xhrc1.Items[xhrc1.SelectedIndex].Text;
            //        //zbusiness_glmst objZbusinessGlmst = new zbusiness_glmst(zid1, zorg1, xhrc11, xhrc22, xhrc33, xhrc44, xhrc55);
            //        //zglobal.ltZbusinessGlmst.Add(objZbusinessGlmst);

            //        int chkduplicate = 0;

                   
            //        //GridView1.DataSource = zglobal.ltZbusinessGlmst;
            //        //GridView1.DataBind();
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {

            //            LinkButton LB = (LinkButton)row.FindControl("zid1");
            //            //Label2.Text = LB.Text == "" ? "Blank" : LB.Text;
            //            if (LB.Text.ToString() == zid1.ToString())
            //            {
            //                chkduplicate = 1;
            //                break;
            //            }
            //        }

            //        if (chkduplicate == 0)
            //        {
            //            SqlConnection conn1 = new SqlConnection(zglobal.constring);

            //            string str1 = zglobal.insglmstbiz;
            //            SqlCommand dataCmd1 = new SqlCommand();
            //            dataCmd1.Connection = conn1;
            //            dataCmd1.CommandText = str1;
            //            dataCmd1.Parameters.AddWithValue("@zid1", zid1);
            //            dataCmd1.Parameters.AddWithValue("@zorg", zorg1);
            //            dataCmd1.Parameters.AddWithValue("@xhrc1", xhrc11);
            //            dataCmd1.Parameters.AddWithValue("@xhrc2", xhrc22);
            //            dataCmd1.Parameters.AddWithValue("@xhrc3", xhrc33);
            //            dataCmd1.Parameters.AddWithValue("@xhrc4", xhrc44);
            //            dataCmd1.Parameters.AddWithValue("@xhrc5", xhrc55);
            //            dataCmd1.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
            //            dataCmd1.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
            //            conn1.Close();
            //            conn1.Open();
            //            dataCmd1.ExecuteNonQuery();
            //            conn1.Close();
            //            dataCmd1.Dispose();
            //            conn1.Dispose();

            //            fnFillDataGrid();
            //        }
                    
            //    }
            //    else
            //    {
            //        if (TreeView1.SelectedNode.Value != "0" && TreeView1.SelectedNode.Value != "888888" && TreeView1.Nodes[0].ChildNodes[0].Checked == true)
            //        {
            //            Label1.Text = "Select Level for Business <font color=green>\"" + TreeView1.SelectedNode.Text + "\" </font>";
            //            int zid1 = Int32.Parse(TreeView1.SelectedNode.Value);
            //            string zorg1 = TreeView1.SelectedNode.Text;
            //            //string xhrc11 = Request.Form["xhrc1"] == "-1" ? "" : Request.Form["xhrc1"];
            //            //string xhrc22 = Request.Form["xhrc2"] == "-1" ? "" : Request.Form["xhrc2"];
            //            //string xhrc33 = Request.Form["xhrc3"] == "-1" ? "" : Request.Form["xhrc3"];
            //            //string xhrc44 = Request.Form["xhrc4"] == "-1" ? "" : Request.Form["xhrc4"];
            //            //string xhrc55 = Request.Form["xhrc5"] == "-1" ? "" : Request.Form["xhrc5"];
            //            string xhrc11 = xhrc1.Text.ToString().Trim() == "[Select]" ? "" : xhrc1.Text.ToString().Trim();
            //            string xhrc22 = xhrc2.Text.ToString().Trim() == "[Select]" ? "" : xhrc2.Text.ToString().Trim();
            //            string xhrc33 = xhrc3.Text.ToString().Trim() == "[Select]" ? "" : xhrc3.Text.ToString().Trim();
            //            string xhrc44 = xhrc4.Text.ToString().Trim() == "[Select]" ? "" : xhrc4.Text.ToString().Trim();
            //            string xhrc55 = xhrc5.Text.ToString().Trim() == "[Select]" ? "" : xhrc5.Text.ToString().Trim();
            //            ////Label2.Text = xhrc1.Items[xhrc1.SelectedIndex].Text;
            //            //zbusiness_glmst objZbusinessGlmst = new zbusiness_glmst(zid1, zorg1, xhrc11, xhrc22, xhrc33, xhrc44, xhrc55);
            //            //zglobal.ltZbusinessGlmst.Add(objZbusinessGlmst);
            //            //GridView1.DataSource = zglobal.ltZbusinessGlmst;
            //            //GridView1.DataBind();
            //            ////Label1.Text = "Select Level for Business <font color=green>\"" + TreeView1.SelectedNode.Text + "\" </font>";

            //            int chkduplicate = 0;


            //            //GridView1.DataSource = zglobal.ltZbusinessGlmst;
            //            //GridView1.DataBind();
            //            foreach (GridViewRow row in GridView1.Rows)
            //            {
            //                LinkButton LB = (LinkButton) row.FindControl("zid1");
            //                //Label2.Text = LB.Text == "" ? "Blank" : LB.Text;
            //                if (LB.Text.ToString() == zid1.ToString())
            //                {
            //                    chkduplicate = 1;
            //                    break;
            //                }
            //            }

            //            if (chkduplicate == 0)
            //            {
            //                SqlConnection conn1 = new SqlConnection(zglobal.constring);

            //                string str1 = zglobal.insglmstbiz;
            //                SqlCommand dataCmd1 = new SqlCommand();
            //                dataCmd1.Connection = conn1;
            //                dataCmd1.CommandText = str1;
            //                dataCmd1.Parameters.AddWithValue("@zid1", zid1);
            //                dataCmd1.Parameters.AddWithValue("@zorg", zorg1);
            //                dataCmd1.Parameters.AddWithValue("@xhrc1", xhrc11);
            //                dataCmd1.Parameters.AddWithValue("@xhrc2", xhrc22);
            //                dataCmd1.Parameters.AddWithValue("@xhrc3", xhrc33);
            //                dataCmd1.Parameters.AddWithValue("@xhrc4", xhrc44);
            //                dataCmd1.Parameters.AddWithValue("@xhrc5", xhrc55);
            //                dataCmd1.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
            //                dataCmd1.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
            //                conn1.Close();
            //                conn1.Open();
            //                dataCmd1.ExecuteNonQuery();
            //                conn1.Close();
            //                dataCmd1.Dispose();
            //                conn1.Dispose();

            //                fnFillDataGrid();
            //            }
            //        }
            //        else
            //        {
            //            Label1.Text = "Select Level for Business";
            //        }
            //    }

            //    msg.InnerHtml = "";
            //}
            //catch (Exception exp)
            //{

            //    msg.InnerHtml = exp.Message;
            //    msg.Style.Value = zglobal.errormsg;
            //}
            
        }

        protected void btnUpdate0_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection conn1 = new SqlConnection(zglobal.constring);

            //    string str1 =
            //        "UPDATE ztemporary SET xhrc1=@xhrc1,xhrc2=@xhrc2,xhrc3=@xhrc3,xhrc4=@xhrc4,xhrc5=@xhrc5 WHERE zid1=@zid1 and zemail=@zemail and xsession=@xsession";
            //    SqlCommand dataCmd1 = new SqlCommand();
            //    dataCmd1.Connection = conn1;
            //    dataCmd1.CommandText = str1;
            //    string xhrc111 = xhrc1.Text.ToString().Trim() == "[Select]" ? "" : xhrc1.Text.ToString().Trim();
            //    string xhrc221 = xhrc2.Text.ToString().Trim() == "[Select]" ? "" : xhrc2.Text.ToString().Trim();
            //    string xhrc331 = xhrc3.Text.ToString().Trim() == "[Select]" ? "" : xhrc3.Text.ToString().Trim();
            //    string xhrc441 = xhrc4.Text.ToString().Trim() == "[Select]" ? "" : xhrc4.Text.ToString().Trim();
            //    string xhrc551 = xhrc5.Text.ToString().Trim() == "[Select]" ? "" : xhrc5.Text.ToString().Trim();
            //    dataCmd1.Parameters.AddWithValue("@zid1", ViewState["key"]!=null?Int32.Parse(ViewState["key"].ToString()):Int32.Parse("-1"));
            //    //dataCmd1.Parameters.AddWithValue("@zorg", zorg1);
            //    dataCmd1.Parameters.AddWithValue("@xhrc1", xhrc111);
            //    dataCmd1.Parameters.AddWithValue("@xhrc2", xhrc221);
            //    dataCmd1.Parameters.AddWithValue("@xhrc3", xhrc331);
            //    dataCmd1.Parameters.AddWithValue("@xhrc4", xhrc441);
            //    dataCmd1.Parameters.AddWithValue("@xhrc5", xhrc551);
            //    dataCmd1.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
            //    dataCmd1.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
            //    conn1.Close();
            //    conn1.Open();
            //    dataCmd1.ExecuteNonQuery();
            //    conn1.Close();
            //    dataCmd1.Dispose();
            //    conn1.Dispose();

            //    fnFillDataGrid();
            //}
            //catch (Exception exp)
            //{
            //    msg.InnerHtml = exp.Message;
            //    msg.Style.Value = zglobal.errormsg;
            //}
        }

        //private DataSet GetData(string query,string zid)
        //{
        //    string conString = zglobal.constring;
        //    SqlCommand cmd = new SqlCommand(query);
        //    using (SqlConnection con = new SqlConnection(conString))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = con;
        //            cmd.Parameters.AddWithValue("@zid", Int32.Parse(zid));
        //            sda.SelectCommand = cmd;
        //            using (DataSet ds = new DataSet())
        //            {
        //                sda.Fill(ds);
        //                return ds;
        //            }
        //        }
        //    }
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string zid1 = e.Row.Cells[1].Text.ToString();

            //    DropDownList level11 = (e.Row.FindControl("level1") as DropDownList);
            //    DropDownList level22 = (e.Row.FindControl("level2") as DropDownList);
            //    DropDownList level33 = (e.Row.FindControl("level3") as DropDownList);
            //    DropDownList level44 = (e.Row.FindControl("level4") as DropDownList);
            //    DropDownList level55 = (e.Row.FindControl("level5") as DropDownList);
            //    AddComboBoxItems levelAddComboBoxItemsSingel = new AddComboBoxItems(level11, "select glhrc12.zid,xdesc from glhrc11 inner join glhrc12 on glhrc11.xhrc1=glhrc12.xhrc1 where glhrc12.zid=@zid", Int32.Parse(zid1));
            //    level22.Items.Clear();
            //    level22.Enabled = false;
            //    level33.Items.Clear();
            //    level33.Enabled = false;
            //    level44.Items.Clear();
            //    level44.Enabled = false;
            //    level55.Items.Clear();
            //    level55.Enabled = false;
            //    level11.Enabled = false;

            //}
        }


 

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {

        }


        protected void selbiz_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (CheckBox) sender;
                GridViewRow row = (GridViewRow)chk.Parent.Parent;
                TextBox txt1 = (TextBox)row.FindControl("accounts");
                ImageButton img1 = (ImageButton)row.FindControl("acclist");  
            //    DropDownList level1 = (DropDownList)row.FindControl("level1");
            //    DropDownList level2 = (DropDownList)row.FindControl("level2");
            //    DropDownList level3 = (DropDownList)row.FindControl("level3");
            //    DropDownList level4 = (DropDownList)row.FindControl("level4");
            //    DropDownList level5 = (DropDownList)row.FindControl("level5");
                if (!chk.Checked)
                {
                    txt1.Enabled = false;
                    img1.Enabled = false;
                    //        level2.Items.Clear();
                    //        level3.Items.Clear();
                    //        level4.Items.Clear();
                    //        level5.Items.Clear();
                    //        level1.Enabled = false;
                    //        level2.Enabled = false;
                    //        level3.Enabled = false;
                    //        level4.Enabled = false;
                    //        level5.Enabled = false;
                    //        level1.Text = "[Select]";
                }
                else
                {
                    txt1.Enabled = true;
                    img1.Enabled = true;
                    //level1.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }
    }
}