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


namespace OnlineTicketingSystem.forms.sc
{
    public partial class zupermis : System.Web.UI.Page
    {
        string curuser;
        string pagew;
        bool checkuser = false;
        ArrayList menu = new ArrayList();

        ArrayList permis = new ArrayList();
        string permission = "";

        private void fnChangeTextofButton()
        {
            btnPermission.Text = "Reset";
            btnUpdate.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                ////Check Permission
                //SiteMaster sm = new SiteMaster();
                //string s = sm.fnChkPagePermis("ztpermis");
                //if (s == "n" || s == "e")
                //{
                //    HttpContext.Current.Session["curuser"] = null;
                //    Session.Abandon();
                //    Response.Redirect("~/forms/zlogin.aspx");
                //}


                pagew = Request.QueryString["page"];

                if (pagew == "user")
                {
                    curuser = Request.QueryString["xuser"];
                    xuser.InnerHtml = "User : " + curuser;
                }
                else
                {
                    curuser = Request.QueryString["xrole"];
                    xuser.InnerHtml = "Role : " + curuser;
                }

                if (!IsPostBack)
                {
                    btnUpdate.Visible = false;
                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts = new DataSet();


                    dts.Reset();
                    string str = "SELECT xpermis FROM ztpermis WHERE xid=@xid";

                    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                    string xid = curuser;
                    da.SelectCommand.Parameters.AddWithValue("@xid", xid);


                    da.Fill(dts, "tempdt");

                    SqlDataAdapter da1;

                    if (pagew == "user")
                    {
                        str = "SELECT xpermisst FROM ztuser WHERE xuser=@xuser";

                        da1 = new SqlDataAdapter(str, conn1);

                        da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);
                    }
                    else
                    {
                        str = "SELECT xpermisst FROM ztrole WHERE xrole=@xrole";

                        da1 = new SqlDataAdapter(str, conn1);

                        da1.SelectCommand.Parameters.AddWithValue("@xrole", xid);
                    }

                    da1.Fill(dts, "temdt1");

                    //DataView dv = new DataView(dts.Tables[0]);
                    DataTable temp = new DataTable();
                    DataTable temp1 = new DataTable();

                    temp1 = dts.Tables[1];
                    temp = dts.Tables[0];

                    if ((int)temp1.Rows[0][0] == 1)
                    {
                        fnChangeTextofButton();
                    }

                    if (temp.Rows.Count > 0)
                    {
                        checkuser = true;
                        //msg.InnerHtml = xid + temp.Rows[0][0].ToString();
                        permission = temp.Rows[0][0].ToString();

                        string[] xxid = permission.Split('|');
                        foreach (string id in xxid)
                        {
                            permis.Add(id.Trim());
                        }
                    }

                    conn1.Dispose();
                    da.Dispose();
                    da1.Dispose();
                    dts.Dispose();


                    GetTreeItem();
                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
            ////
        }

        ArrayList arr = new ArrayList();
        //ArrayList arrParent = new ArrayList();

        protected void fnMenuPer(string zid)
        {
            ArrayList permission = RemoveDuplicate(arr);
            //ArrayList permissionUnit = RemoveDuplicate(arrParent);

            string uwmpermis = "";

            foreach (string permis in permission)
            {
                uwmpermis = uwmpermis + "|" + permis;
            }

            //string uwmpermisUnit = "";

            //foreach (string permis in permissionUnit)
            //{
            //    uwmpermisUnit = uwmpermisUnit + "|" + permis;
            //}


            if (uwmpermis == "")
            {
                //string message = "You are not select any permission. Save unsuccessfull.";
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                // msg.InnerHtml = "You are not select any permission. Save unsuccessfull.";
                return;
            }
            SqlConnection conn;
            conn = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
            dataCmd.Connection = conn;

            string str = "INSERT INTO ztpermis (xid,zid,xpermis,zemail,ztime) VALUES (@xid,@zid,@xpermis,@zemail,@ztime)";
            dataCmd.CommandText = str;

            string xid = curuser;
            string xpermis = uwmpermis;
            //string xpermisunit = uwmpermisUnit;
            string zemail = HttpContext.Current.Session["curuser"].ToString();
            DateTime ztime = DateTime.Now;

            dataCmd.Parameters.AddWithValue("@xid", xid);
            dataCmd.Parameters.AddWithValue("@xpermis", xpermis);
            dataCmd.Parameters.AddWithValue("@zid", zid);
            dataCmd.Parameters.AddWithValue("@zemail", zemail);
            dataCmd.Parameters.AddWithValue("@ztime", ztime);



            conn.Close();
            conn.Open();
            dataCmd.ExecuteNonQuery();
            conn.Close();

            //dataCmd.Dispose();
            //conn.Dispose();
            arr.Clear();

        }

        protected void btnPermission_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    if (btnPermission.Text == "Save")
                    {

                        //foreach (TreeNode node in TreeView1.CheckedNodes)
                        //{
                        //    if (node.Parent == null)
                        //    {
                        //        //arrParent.Add(node.Value);
                        //        fnMenuPer(node.Value);
                        //    }
                        //    else
                        //    {
                        //        arr.Add(node.Value);
                        //        //node.Parent.Checked = true;
                        //        SelectParent(node.Parent);

                        //    }


                        //}


                        TreeNodeCollection nodes = this.TreeView1.Nodes;
                        foreach (TreeNode n in nodes)
                        {
                            arr.Clear();
                            GetNodeRecursive(n);
                            if (arr.Count > 0)
                            {
                                fnMenuPer(n.Value);
                            }

                        }

                        ///////////////////////////

                        //////////////////////////////


                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd1 = new SqlCommand();
                        dataCmd1.Connection = conn1;

                        string str1;

                        if (pagew == "user")
                        {
                            str1 = "UPDATE ztuser SET xpermisst=1 WHERE xuser=@xuser";
                            dataCmd1.CommandText = str1;

                            string xuser = curuser;


                            dataCmd1.Parameters.AddWithValue("@xuser", xuser);
                        }
                        else
                        {
                            str1 = "UPDATE ztrole SET xpermisst=1 WHERE xrole=@xrole";
                            dataCmd1.CommandText = str1;

                            string xrole = curuser;


                            dataCmd1.Parameters.AddWithValue("@xrole", xrole);
                        }




                        conn1.Close();
                        conn1.Open();
                        dataCmd1.ExecuteNonQuery();
                        conn1.Close();

                        //dataCmd1.Dispose();
                        //conn1.Dispose();
                        fnChangeTextofButton();
                    }
                    else
                    {
                        SqlConnection conn;
                        conn = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd = new SqlCommand();
                        dataCmd.Connection = conn;

                        string str = "DELETE FROM ztpermis WHERE xid=@xid";
                        dataCmd.CommandText = str;

                        string xid = curuser;

                        dataCmd.Parameters.AddWithValue("@xid", xid);

                        conn.Close();
                        conn.Open();
                        dataCmd.ExecuteNonQuery();
                        conn.Close();

                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd1 = new SqlCommand();
                        dataCmd1.Connection = conn1;


                        string str1;

                        if (pagew == "user")
                        {
                            str1 = "UPDATE ztuser SET xpermisst=0 WHERE xuser=@xuser";
                            dataCmd1.CommandText = str1;

                            string xuser = curuser;


                            dataCmd1.Parameters.AddWithValue("@xuser", xuser);
                        }
                        else
                        {
                            str1 = "UPDATE ztrole SET xpermisst=0 WHERE xrole=@xrole";
                            dataCmd1.CommandText = str1;

                            string xrole = curuser;


                            dataCmd1.Parameters.AddWithValue("@xrole", xrole);
                        }




                        conn1.Close();
                        conn1.Open();
                        dataCmd1.ExecuteNonQuery();
                        conn1.Close();

                        CheckUncheckTreeNode(TreeView1.Nodes, false);
                        btnPermission.Text = "Save";
                        btnUpdate.Visible = false;
                    }
                    tran.Complete();


                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }

        private void GetNodeRecursive(TreeNode treeNode)
        {
            if (treeNode.Checked == true && treeNode.Parent != null)
            {
                //Response.Write("<br/>" + treeNode.Text + "<br/>");
                //Your Code Goes Here to perform any action on checked node
                arr.Add(treeNode.Value);
            }
            foreach (TreeNode tn in treeNode.ChildNodes)
            {
                GetNodeRecursive(tn);
            }

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
                //arrParent.Add(node.Value);
                fnMenuPer(node.Value);
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
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "";

            string curuser1 = HttpContext.Current.Session["curuser"].ToString();
            //str = "SELECT zid,zorg FROM zbusiness";

            if (curuser1 == "bm")
            {
                str = "SELECT zid,zorg from zbusiness";
            }
            else
            {
                str = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
            }

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@xid", curuser1);

            da.Fill(dts, "tempdt");
            DataTable tempTable = new DataTable();
            tempTable = dts.Tables[0];

            if (tempTable.Rows.Count <= 0)
            {
                str = "SELECT xrole FROM ztuser WHERE xuser=@xuser";

                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                //xid = this.Page.User.Identity.Name;
                da1.SelectCommand.Parameters.AddWithValue("@xuser", curuser1);

                dts.Reset();

                da1.Fill(dts, "tempdt");
                //DataTable temp1 = new DataTable();
                tempTable.Reset();
                tempTable = dts.Tables[0];

                if (tempTable.Rows.Count > 0)
                {
                    str = "SELECT zid,(select zorg from zbusiness where zid=ztpermis.zid) as zorg FROM ztpermis WHERE xid = @xid";
                    SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);

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
                //else
                //{
                //    FailureText.Text = "Your Id have not any permission to access any business";
                //    return;
                //}

                da1.Dispose();
            }




            foreach (DataRow level1DataRows in tempTable.Rows)
            {
                //if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
                //{
                    TreeNode parentitem = new TreeNode();
                    parentitem.Text = level1DataRows["zorg"].ToString();
                    // parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                    parentitem.Value = level1DataRows["zid"].ToString();

                    GetChildRowsRoot(parentitem);

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


                    //str = "SELECT xpermis FROM ztpermis where xid=@xid and zid=@zid";
                    //SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                    //da1.SelectCommand.Parameters.AddWithValue("@xid", curuser);
                    //da1.SelectCommand.Parameters.AddWithValue("@zid", parentitem.Value);
                    //da1.Fill(dts, "tempdt1");
                    //DataTable temp1 = new DataTable();
                    //temp1 = dts.Tables[1];
                    //if (temp1.Rows.Count > 0)
                    //{
                    //    string prm = temp1.Rows[0][0].ToString();
                    //   // ArrayList prm1 = new ArrayList();

                    //    string[] xxid1 = prm.Split('|');
                    //    foreach (string id in xxid1)
                    //    {
                    //        //prm1.Add(id.Trim());
                    //    }
                    //}



                    //da1.Dispose();
                    //temp1.Dispose();
                
                //}


            }

            conn1.Dispose();
            da.Dispose();
            
            dts.Dispose();
        }

        //private void GetTreeItem()
        //{
        //    SqlConnection conn1;
        //    conn1 = new SqlConnection(zglobal.constring);
        //    DataSet dts = new DataSet();


        //    dts.Reset();
        //    string str = "SELECT * FROM ztmenu";

        //    SqlDataAdapter da = new SqlDataAdapter(str, conn1);


        //    da.Fill(dts, "tempdt");
        //    //DataView dv = new DataView(dts.Tables[0]);
        //    DataTable temp = new DataTable();
        //    temp = dts.Tables[0];

        //    dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

        //    foreach (DataRow level1DataRows in dts.Tables[0].Rows)
        //    {
        //        if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
        //        {
        //            TreeNode parentitem = new TreeNode();
        //            parentitem.Text = level1DataRows["xmenunm"].ToString();
        //            // parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
        //            parentitem.Value = level1DataRows["xid"].ToString();

        //            GetChildRows(level1DataRows, parentitem);

        //            TreeView1.Nodes.Add(parentitem);

        //            if (checkuser)
        //            {
        //                foreach (string st in permis)
        //                {
        //                    if (st.Trim() == parentitem.Value.Trim())
        //                    {
        //                        parentitem.Checked = true;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    conn1.Dispose();
        //    da.Dispose();
        //    dts.Dispose();
        //}

        private void GetChildRowsRoot(TreeNode mnitem)
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT * FROM ztmenu";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable temp = new DataTable();
            temp = dts.Tables[0];

            dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

            str = "SELECT xmod FROM zmodper where zid=@zid";

            SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);
            string zid1 = mnitem.Value;
            da2.SelectCommand.Parameters.AddWithValue("@zid", zid1);
            da2.Fill(dts, "tempdt2");
            DataTable temp2 = new DataTable();
            temp2 = dts.Tables[1];

            str = "SELECT xmodper FROM zbusiness where zid=@zid";

            SqlDataAdapter da3 = new SqlDataAdapter(str, conn1);
            da3.SelectCommand.Parameters.AddWithValue("@zid", zid1);
            da3.Fill(dts, "tempdt3");
            DataTable temp3 = new DataTable();
            temp3 = dts.Tables[2];


            ArrayList permis1 = new ArrayList();
            if (temp2.Rows.Count > 0)
            {
                string permission1 = temp2.Rows[0][0].ToString();

                string[] xxid = permission1.Split('|');
                foreach (string id in xxid)
                {
                    permis1.Add(id.Trim());
                }
            }

            foreach (DataRow level1DataRows in dts.Tables[0].Rows)
            {
                if (temp3.Rows.Count > 0)
                {
                    if (temp3.Rows[0][0].ToString() == "sel")
                    {
                        foreach (string modp in permis1)
                        {
                            if (modp == level1DataRows["xid"].ToString())
                            {
                                fnRootMenu(level1DataRows, mnitem);
                            }
                        }
                    }
                    else
                    {
                        fnRootMenu(level1DataRows, mnitem);
                    }
                }


            }

            conn1.Dispose();
            da.Dispose();
            dts.Dispose();
        }

        private void fnRootMenu(DataRow level1DataRows, TreeNode mnitem)
        {
            if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
            {
                string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);

                if ((level1DataRows["xid"].ToString() == "105" || level1DataRows["xid"].ToString() == "170" || level1DataRows["xid"].ToString() == "175" || level1DataRows["xid"].ToString() == "180") && xuser1 != "bm")
                {
                    return;
                }

                TreeNode parentitemroot = new TreeNode();

                parentitemroot.Text = level1DataRows["xmenunm"].ToString();
                // parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                parentitemroot.Value = level1DataRows["xid"].ToString();

                GetChildRows(level1DataRows, parentitemroot,mnitem);

                //TreeView1.Nodes.Add(parentitemroot);

                mnitem.ChildNodes.Add(parentitemroot);

                //if (checkuser)
                //{
                //    foreach (string st in permis)
                //    {
                //        if (st.Trim() == parentitemroot.Value.Trim())
                //        {
                //            parentitemroot.Checked = true;
                //            break;
                //        }
                //    }
                //}
                SqlConnection conn1 = new SqlConnection(zglobal.constring);
                string str = "SELECT xpermis FROM ztpermis where xid=@xid and zid=@zid";
                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                da1.SelectCommand.Parameters.AddWithValue("@xid", curuser);
                da1.SelectCommand.Parameters.AddWithValue("@zid", mnitem.Value);
                DataSet dts = new DataSet();
                da1.Fill(dts, "tempdt1");
                DataTable temp1 = new DataTable();
                temp1 = dts.Tables["tempdt1"];
                if (temp1.Rows.Count > 0)
                {
                    string prm = temp1.Rows[0][0].ToString();
                    // ArrayList prm1 = new ArrayList();

                    string[] xxid1 = prm.Split('|');
                    foreach (string id in xxid1)
                    {
                        //prm1.Add(id.Trim());
                        if (id.Trim() == parentitemroot.Value.Trim())
                        {
                            parentitemroot.Checked = true;
                            break;
                        }
                    }
                }



                da1.Dispose();
                temp1.Dispose();
                conn1.Dispose();
                dts.Dispose();
            }
        }

        private void GetChildRows(DataRow dataRow, TreeNode mnitem,TreeNode root)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");

            foreach (DataRow childRow in childRows)
            {
                TreeNode childitem = new TreeNode();
                childitem.Text = childRow["xmenunm"].ToString();
                // childitem.NavigateUrl = childRow["xurl"].ToString();
                childitem.Value = childRow["xid"].ToString();

                mnitem.ChildNodes.Add(childitem);

                //if (checkuser)
                //{
                //    foreach (string st in permis)
                //    {
                //        if (st.Trim() == childitem.Value.Trim())
                //        {
                //            childitem.Checked = true;
                //            break;
                //        }
                //    }
                //}

                SqlConnection conn1 = new SqlConnection(zglobal.constring);
                string str = "SELECT xpermis FROM ztpermis where xid=@xid and zid=@zid";
                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                da1.SelectCommand.Parameters.AddWithValue("@xid", curuser);
                da1.SelectCommand.Parameters.AddWithValue("@zid", root.Value);
                DataSet dts = new DataSet();
                da1.Fill(dts, "tempdt1");
                DataTable temp1 = new DataTable();
                temp1 = dts.Tables["tempdt1"];
                if (temp1.Rows.Count > 0)
                {
                    string prm = temp1.Rows[0][0].ToString();
                    // ArrayList prm1 = new ArrayList();

                    string[] xxid1 = prm.Split('|');
                    foreach (string id in xxid1)
                    {
                        //prm1.Add(id.Trim());
                        if (id.Trim() == childitem.Value.Trim())
                        {
                            childitem.Checked = true;
                            break;
                        }
                    }
                }



                da1.Dispose();
                temp1.Dispose();
                conn1.Dispose();
                dts.Dispose();



                if (childRow.GetChildRows("ChildRows").Length > 0)
                {
                    GetChildRows(childRow, childitem,root);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    ////if (btnPermission.Text == "Save")
                    ////{
                    //arr.Clear();
                    ////arrParent.Clear();
                    //foreach (TreeNode node in TreeView1.CheckedNodes)
                    //{
                    //    if (node.Parent == null)
                    //    {
                    //        //arrParent.Add(node.Value);
                    //        fnMenuPer(node.Value);
                    //    }
                    //    else
                    //    {
                    //        arr.Add(node.Value);
                    //        //node.Parent.Checked = true;
                    //        SelectParent(node.Parent);

                    //    }


                    //}

                    //ArrayList permission = RemoveDuplicate(arr);
                    ////ArrayList permissionUnit = RemoveDuplicate(arrParent);

                    //string uwmpermis = "";

                    //foreach (string permis in permission)
                    //{
                    //    uwmpermis = uwmpermis + "|" + permis;
                    //}


                    //string uwmpermisUnit = "";

                    //foreach (string permis in permissionUnit)
                    //{
                    //    uwmpermisUnit = uwmpermisUnit + "|" + permis;
                    //}

                    //if (uwmpermis == "")
                    //{
                    //    //string message = "You are not select any permission. Save unsuccessfull.";
                    //    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                    //    msg.InnerHtml = "You are not select any permission. Update unsuccessfull.";
                    //    return;
                    //}
                    SqlConnection conn;
                    conn = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn;

                    // string str = "UPDATE ztpermis SET xpermis=@xpermis,xpermisunit=@xpermisunit,zuemail=@zuemail,zutime=@zutime WHERE xid=@xid";
                    string str = "DELETE FROM ztpermis WHERE xid=@xid";
                    dataCmd.CommandText = str;

                    string xid = curuser;
                    //string xpermis = uwmpermis;
                    //string xpermisunit = uwmpermisUnit;
                    //string zemail = HttpContext.Current.Session["curuser"].ToString();
                    //DateTime ztime = DateTime.Now;

                    dataCmd.Parameters.AddWithValue("@xid", xid);
                    //dataCmd.Parameters.AddWithValue("@xpermis", xpermis);
                    //dataCmd.Parameters.AddWithValue("@xpermisunit", xpermisunit);
                    //dataCmd.Parameters.AddWithValue("@zuemail", zemail);
                    //dataCmd.Parameters.AddWithValue("@zutime", ztime);



                    conn.Close();
                    conn.Open();
                    dataCmd.ExecuteNonQuery();
                    conn.Close();

                    dataCmd.Dispose();
                    conn.Dispose();


                    //if (btnPermission.Text == "Save")
                    //{
                    arr.Clear();
                    //arrParent.Clear();
                    //foreach (TreeNode node in TreeView1.CheckedNodes)
                    //{
                    //    if (node.Parent == null)
                    //    {
                    //        //arrParent.Add(node.Value);
                    //        fnMenuPer(node.Value);
                    //    }
                    //    else
                    //    {
                    //        arr.Add(node.Value);
                    //        //node.Parent.Checked = true;
                    //        SelectParent(node.Parent);

                    //    }


                    //}

                    TreeNodeCollection nodes = this.TreeView1.Nodes;
                    foreach (TreeNode n in nodes)
                    {
                        arr.Clear();
                        GetNodeRecursive(n);
                        if (arr.Count > 0)
                        {
                            fnMenuPer(n.Value);
                        }

                    }



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