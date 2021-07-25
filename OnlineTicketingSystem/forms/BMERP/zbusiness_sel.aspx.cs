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

namespace OnlineTicketingSystem.forms.BMERP
{
    public partial class zbusiness_sel : System.Web.UI.Page
    {
        string curuser;
        string pagew;
        string level ;
        string xhrc1;
        string xhrc2;
        string xhrc3;
        string xhrc4;
        string xhrc5;
        bool checkuser = false;
        ArrayList menu = new ArrayList();

        ArrayList permis = new ArrayList();
        string permission = "";

        private void fnChangeTextofButton()
        {
            //btnPermission.Text = "Reset";
            //btnUpdate.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{

                //////Check Permission
                ////SiteMaster sm = new SiteMaster();
                ////string s = sm.fnChkPagePermis("ztpermis");
                ////if (s == "n" || s == "e")
                ////{
                ////    HttpContext.Current.Session["curuser"] = null;
                ////    Session.Abandon();
                ////    Response.Redirect("~/forms/zlogin.aspx");
                ////}


                //pagew = Request.QueryString["page"];
                //if (pagew == "user")
                //{
                //    curuser = Request.QueryString["xuser"];
                //    xuser.InnerHtml = "User : " + curuser;
                //}
                //else
                //{
                //    curuser = Request.QueryString["xrole"];
                //    xuser.InnerHtml = "Role : " + curuser;
                //}


                if (!IsPostBack)
                {
                    level = Request.QueryString["level"];
                    xhrc1 = Request.QueryString["xhrc1"] == null ? "" : Request.QueryString["xhrc1"];
                    xhrc2 = Request.QueryString["xhrc2"] == null ? "" : Request.QueryString["xhrc2"];
                    xhrc3 = Request.QueryString["xhrc3"] == null ? "" : Request.QueryString["xhrc3"];
                    xhrc4 = Request.QueryString["xhrc4"] == null ? "" : Request.QueryString["xhrc4"];
                    xhrc5 = Request.QueryString["xhrc5"] == null ? "" : Request.QueryString["xhrc5"];
                    //Response.Write(level);
                    //Response.Write(xhrc1);
                    //btnUpdate.Visible = false;
                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts = new DataSet();


                    dts.Reset();
                    //string str = "SELECT xpermisunit FROM ztpermis WHERE xid=@xid";

                    string str="";

                    if (level == "level1")
                    {
                        str = "SELECT zid FROM glhrc12 WHERE xhrc1=@xhrc1";
                    }
                    else if (level == "level2")
                    {
                        str = "SELECT zid FROM glhrc22 WHERE xhrc1=@xhrc1 and xhrc2=xhrc2";
                    }
                    else if (level == "level3")
                    {
                        str = "SELECT zid FROM glhrc32 WHERE xhrc1=@xhrc1 and xhrc2=xhrc2 and xhrc3=@xhrc3";
                    }
                    else if (level == "level4")
                    {
                        str = "SELECT zid FROM glhrc42 WHERE xhrc1=@xhrc1 and xhrc2=xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                    }
                    else
                    {
                        str = "SELECT zid FROM glhrc52 WHERE xhrc1=@xhrc1 and xhrc2=xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4 and xhrc5=@xhrc5";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                    //string xid = curuser;
                    //da.SelectCommand.Parameters.AddWithValue("@xid", xid);

                    da.SelectCommand.Parameters.AddWithValue("@xhrc1", xhrc1);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc2", xhrc2);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc3", xhrc3);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc4", xhrc4);
                    da.SelectCommand.Parameters.AddWithValue("@xhrc5", xhrc5);


                    da.Fill(dts, "tempdt");

                    //SqlDataAdapter da1;

                    //if (pagew == "user")
                    //{
                    //    str = "SELECT xpermisstunit FROM ztuser WHERE xuser=@xuser";

                    //    da1 = new SqlDataAdapter(str, conn1);

                    //    da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);
                    //}
                    //else
                    //{
                    //    str = "SELECT xpermisstunit FROM ztrole WHERE xrole=@xrole";

                    //    da1 = new SqlDataAdapter(str, conn1);

                    //    da1.SelectCommand.Parameters.AddWithValue("@xrole", xid);
                    //}

                    //da1.Fill(dts, "temdt1");

                    ////DataView dv = new DataView(dts.Tables[0]);
                    DataTable temp = new DataTable();
                    //DataTable temp1 = new DataTable();

                    //temp1 = dts.Tables[1];
                    temp = dts.Tables[0];

                    //if ((int)temp1.Rows[0][0] == 1)
                    //{
                    //    fnChangeTextofButton();
                    //}

                    //if (temp.Rows.Count > 0)
                    //{
                    //    checkuser = true;
                    //    //msg.InnerHtml = xid + temp.Rows[0][0].ToString();
                    //    permission = temp.Rows[0][0].ToString();

                    //    string[] xxid = permission.Split('|');
                    //    foreach (string id in xxid)
                    //    {
                    //        permis.Add(id.Trim());
                    //    }
                    //}

                    if (temp.Rows.Count > 0)
                    {
                        checkuser = true;
                        
                        foreach (DataRow row in temp.Rows)
                        {
                            permis.Add(row["zid"].ToString());
                        }
                    }

                    conn1.Dispose();
                    da.Dispose();
                    //da1.Dispose();
                    dts.Dispose();


                    GetTreeItem();
                }

            //}
            //catch (Exception exp)
            //{
            //    Response.Write(exp.Message);
            //}
            ////
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
            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();


            //dts.Reset();
            //string str = "SELECT zid,zorg FROM zbusiness";

            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            //da.Fill(dts, "tempdt");
            //DataTable temp = new DataTable();
            //temp = dts.Tables[0];

            ////dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

            //foreach (DataRow level1DataRows in dts.Tables[0].Rows)
            //{
            //    //if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
            //    //{
                TreeNode parentitem = new TreeNode();
                //parentitem.Text = level1DataRows["zorg"].ToString();
                // parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                //parentitem.Value = level1DataRows["zid"].ToString();

                parentitem.Text = "Select Business";
                parentitem.Value = "888888";

                //GetChildRows(level1DataRows,parentitem);
                GetChildRows(parentitem);

                TreeView1.Nodes.Add(parentitem);

                //if (checkuser)
                //{
                //    foreach (string st in permis)
                //    {
                //        if (st.Trim() == parentitem.Value.Trim())
                //        {
                //            parentitem.Checked = true;
                //            break;
                //        }
                //    }
                //}
                //}
            //}

            //conn1.Dispose();
            //da.Dispose();
            //dts.Dispose();
        }

        //private void GetChildRows(DataRow dataRow, TreeNode mnitem)
        private void GetChildRows(TreeNode mnitem)
        {
            TreeNode childitem1 = new TreeNode();
            childitem1.Text = "All Business";
            // childitem.NavigateUrl = childRow["xurl"].ToString();
            childitem1.Value = "0";

            mnitem.ChildNodes.Add(childitem1);

            //DataRow[] childRows = dataRow.GetChildRows("ChildRows");

            //SqlConnection conn1;
            //conn1 = new SqlConnection(zglobal.constring);
            //DataSet dts = new DataSet();


            //dts.Reset();
            //string str = "SELECT zid,zorg FROM zbusiness";

            //SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            //da.Fill(dts, "tempdt");
            //DataTable childRows = new DataTable();
            //childRows = dts.Tables[0];
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
                        }
                        else
                        {
                            //FailureText.Text = "Your Id have not any permission to access any business";
                            //return;
                        }

                        da1.Dispose();
                    }

                    //ListItem llt1 = new ListItem("[Select]", "000");
                    //ArrayList alt = new ArrayList();
                    //DropDownList1.Items.Add(llt1);

                    //for (int i = 0; i < tempTable.Rows.Count; i++)
                    //{
                    //    ListItem llt = new ListItem(tempTable.Rows[i][1].ToString(), tempTable.Rows[i][0].ToString());
                    //    DropDownList1.Items.Add(llt);
                    //    alt.Add(tempTable.Rows[i][0].ToString());
                    //}

                    //HttpContext.Current.Session["zid"] = alt;
                    ////ArrayList alt1 = (ArrayList) HttpContext.Current.Session["zid"];
                    ////foreach (string str in alt1)
                    ////{
                    ////    FailureText.Text = FailureText.Text + " " + str;
                    ////}


                    da.Dispose();
                }
            }

            DataTable childRows = new DataTable();
            childRows = tempTable;

            foreach (DataRow childRow in childRows.Rows)
            {
                ArrayList zidList = (ArrayList) HttpContext.Current.Session["zid"];
                foreach (string zid in zidList)
                {
                    if (zid == childRow["zid"].ToString())
                    {
                        TreeNode childitem = new TreeNode();
                        childitem.Text = childRow["zorg"].ToString();
                        // childitem.NavigateUrl = childRow["xurl"].ToString();
                        childitem.Value = childRow["zid"].ToString();

                        mnitem.ChildNodes.Add(childitem);

                        if (checkuser)
                        {
                            foreach (string st in permis)
                            {
                                if (st.Trim() == childitem.Value.Trim())
                                {
                                    childitem.Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                //if (childRow.GetChildRows("ChildRows").Length > 0)
                //{
                //    GetChildRows(childRow, childitem);
                //}
            }
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
                using (TransactionScope tran = new TransactionScope())
                {
                    //if (btnPermission.Text == "Save")
                    //{
                        arr.Clear();

                        foreach (TreeNode node in TreeView1.CheckedNodes)
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

                        ArrayList permission = RemoveDuplicate(arr);

                    if (permission.Count <= 0)
                    {
                        msg.InnerHtml = "Please select at least one business before save.";
                        msg.Style.Value = zglobal.infomsg;
                        return;
                    }
                    else
                    {
                        msg.InnerHtml = "";
                    }

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

                        SqlConnection conn;
                        conn = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd = new SqlCommand();
                        dataCmd.Connection = conn;

                        //string str = "INSERT INTO ztpermis (xid,xpermisunit) VALUES (@xid,@xpermis)";
                        string str = zglobal.delglhrc1zid;
                        dataCmd.CommandText = str;

                        //string xid = curuser;
                        //string xpermis = uwmpermis;

                        //dataCmd.Parameters.AddWithValue("@xid", xid);
                        //dataCmd.Parameters.AddWithValue("@xpermis", xpermis);



                        conn.Close();
                        conn.Open();
                        dataCmd.ExecuteNonQuery();
                        conn.Close();

                        dataCmd.Dispose();
                        conn.Dispose();


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
                    if (permission.Contains("0"))
                    {
                        permission.Clear();
                        // permission.Add("0");


                        SqlConnection conn11;
                        conn11 = new SqlConnection(zglobal.constring);
                        DataSet dts1 = new DataSet();


                        dts1.Reset();
                        string str11 = "SELECT zid FROM zbusiness";

                        SqlDataAdapter da1 = new SqlDataAdapter(str11, conn11);


                        da1.Fill(dts1, "tempdt");
                        DataTable tbl = new DataTable();
                        tbl = dts1.Tables[0];
                        foreach (DataRow row in tbl.Rows)
                        {
                            permission.Add(row["zid"].ToString());
                        }
                    }

                    foreach (string permis in permission)
                    {



                        str1 = zglobal.insglhrc1zid;
                        dataCmd1.CommandText = str1;
                        dataCmd1.Parameters.AddWithValue("@zid", permis);
                        conn1.Close();
                        conn1.Open();
                        dataCmd1.ExecuteNonQuery();
                        conn1.Close();
                        dataCmd1.Parameters.Clear();
                    }

                    dataCmd1.Dispose();
                        conn1.Dispose();
                        msg.InnerHtml = "Save completed successfully.";
                        msg.Style.Value = zglobal.successmsg;
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
                    tran.Complete();


                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }



    }
}