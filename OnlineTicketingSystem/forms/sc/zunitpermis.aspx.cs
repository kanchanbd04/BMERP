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
    public partial class zunitpermis : System.Web.UI.Page
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

                //////Check Permission
                ////SiteMaster sm = new SiteMaster();
                ////string s = sm.fnChkPagePermis("ztpermis");
                ////if (s == "n" || s == "e")
                ////{
                ////    HttpContext.Current.Session["curuser"] = null;
                ////    Session.Abandon();
                ////    Response.Redirect("~/forms/zlogin.aspx");
                ////}


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
                    string str = "SELECT xpermisunit FROM ztpermis WHERE xid=@xid";

                    SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                    string xid = curuser;
                    da.SelectCommand.Parameters.AddWithValue("@xid", xid);


                    da.Fill(dts, "tempdt");

                    SqlDataAdapter da1;

                    if (pagew == "user")
                    {
                        str = "SELECT xpermisstunit FROM ztuser WHERE xuser=@xuser";

                        da1 = new SqlDataAdapter(str, conn1);

                        da1.SelectCommand.Parameters.AddWithValue("@xuser", xid);
                    }
                    else
                    {
                        str = "SELECT xpermisstunit FROM ztrole WHERE xrole=@xrole";

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

        protected void btnPermission_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    if (btnPermission.Text == "Save")
                    {

                        foreach (TreeNode node in TreeView1.CheckedNodes)
                        {
                            if (node.Parent == null)
                            {
                                arr.Add(node.Value);
                            }
                            else
                            {
                                arr.Add(node.Value);
                                //node.Parent.Checked = true;
                                SelectParent(node.Parent);

                            }


                        }

                        ArrayList permission = RemoveDuplicate(arr);

                        string uwmpermis = "";

                        foreach (string permis in permission)
                        {
                            uwmpermis = uwmpermis + "|" + permis;
                        }


                        if (uwmpermis == "")
                        {
                            //string message = "You are not select any permission. Save unsuccessfull.";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                            msg.InnerHtml = "You are not select any permission. Save unsuccessfull.";
                            return;
                        }
                        SqlConnection conn;
                        conn = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd = new SqlCommand();
                        dataCmd.Connection = conn;

                        string str = "INSERT INTO ztpermis (xid,xpermisunit) VALUES (@xid,@xpermis)";
                        dataCmd.CommandText = str;

                        string xid = curuser;
                        string xpermis = uwmpermis;

                        dataCmd.Parameters.AddWithValue("@xid", xid);
                        dataCmd.Parameters.AddWithValue("@xpermis", xpermis);



                        conn.Close();
                        conn.Open();
                        dataCmd.ExecuteNonQuery();
                        conn.Close();

                        //dataCmd.Dispose();
                        //conn.Dispose();


                        SqlConnection conn1;
                        conn1 = new SqlConnection(zglobal.constring);
                        SqlCommand dataCmd1 = new SqlCommand();
                        dataCmd1.Connection = conn1;

                        string str1;

                        if (pagew == "user")
                        {
                            str1 = "UPDATE ztuser SET xpermisstunit=1 WHERE xuser=@xuser";
                            dataCmd1.CommandText = str1;

                            string xuser = curuser;


                            dataCmd1.Parameters.AddWithValue("@xuser", xuser);
                        }
                        else
                        {
                            str1 = "UPDATE ztrole SET xpermisstunit=1 WHERE xrole=@xrole";
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
                            str1 = "UPDATE ztuser SET xpermisstunit=0 WHERE xuser=@xuser";
                            dataCmd1.CommandText = str1;

                            string xuser = curuser;


                            dataCmd1.Parameters.AddWithValue("@xuser", xuser);
                        }
                        else
                        {
                            str1 = "UPDATE ztrole SET xpermisstunit=0 WHERE xrole=@xrole";
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
                arr.Add(node.Value);
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
            string str = "SELECT zid,zorg FROM zbusiness";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);


            da.Fill(dts, "tempdt");
            DataTable temp = new DataTable();
            temp = dts.Tables[0];

            //dts.Relations.Add("ChildRows", dts.Tables[0].Columns["xid"], dts.Tables[0].Columns["xparentid"]);

            foreach (DataRow level1DataRows in dts.Tables[0].Rows)
            {
                //if (string.IsNullOrEmpty(level1DataRows["xparentid"].ToString()))
                //{
                    TreeNode parentitem = new TreeNode();
                    parentitem.Text = level1DataRows["zorg"].ToString();
                    // parentitem.NavigateUrl = level1DataRows["xurl"].ToString();
                    parentitem.Value = level1DataRows["zid"].ToString();

                    //GetChildRows(level1DataRows, parentitem);

                    TreeView1.Nodes.Add(parentitem);

                    if (checkuser)
                    {
                        foreach (string st in permis)
                        {
                            if (st.Trim() == parentitem.Value.Trim())
                            {
                                parentitem.Checked = true;
                                break;
                            }
                        }
                    }
                //}
            }

            conn1.Dispose();
            da.Dispose();
            dts.Dispose();
        }

        private void GetChildRows(DataRow dataRow, TreeNode mnitem)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");

            foreach (DataRow childRow in childRows)
            {
                TreeNode childitem = new TreeNode();
                childitem.Text = childRow["xmenunm"].ToString();
                // childitem.NavigateUrl = childRow["xurl"].ToString();
                childitem.Value = childRow["xid"].ToString();

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

                if (childRow.GetChildRows("ChildRows").Length > 0)
                {
                    GetChildRows(childRow, childitem);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //if (btnPermission.Text == "Save")
                //{
                arr.Clear();
                foreach (TreeNode node in TreeView1.CheckedNodes)
                {
                    if (node.Parent == null)
                    {
                        arr.Add(node.Value);
                    }
                    else
                    {
                        arr.Add(node.Value);
                        //node.Parent.Checked = true;
                        SelectParent(node.Parent);

                    }


                }

                ArrayList permission = RemoveDuplicate(arr);

                string uwmpermis = "";

                foreach (string permis in permission)
                {
                    uwmpermis = uwmpermis + "|" + permis;
                }


                if (uwmpermis == "")
                {
                    //string message = "You are not select any permission. Save unsuccessfull.";
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                    msg.InnerHtml = "You are not select any permission. Update unsuccessfull.";
                    return;
                }
                SqlConnection conn;
                conn = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd = new SqlCommand();
                dataCmd.Connection = conn;

                string str = "UPDATE ztpermis SET xpermisunit=@xpermis WHERE xid=@xid";
                dataCmd.CommandText = str;

                string xid = curuser;
                string xpermis = uwmpermis;

                dataCmd.Parameters.AddWithValue("@xid", xid);
                dataCmd.Parameters.AddWithValue("@xpermis", xpermis);



                conn.Close();
                conn.Open();
                dataCmd.ExecuteNonQuery();
                conn.Close();

                dataCmd.Dispose();
                conn.Dispose();



                //}

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }




    }
}