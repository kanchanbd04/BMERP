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
    public partial class zbusiness_sel_all : System.Web.UI.Page
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
        string zid;
        ArrayList menu = new ArrayList();

        ArrayList permis = new ArrayList();
        //private List<zbusiness_glmst> ltZbusinessGlmst = new List<zbusiness_glmst>(); 
        string permission = "";

        public void fnFillDataGrid()
        {

            
        }

        protected void FillControls(object sender, EventArgs e)
        {
           
        }
        private void fnFillLevel(string flag,DropDownList xhrc1, DropDownList xhrc2,DropDownList xhrc3, DropDownList xhrc4, DropDownList xhrc5)
        {
           

        }

        
        private void fnChangeTextofButton()
        {
           
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

                    
                    key = Request.QueryString["key"] != "" ? Request.QueryString["key"] : "-1";
                    string tbl = Request.QueryString["tbl"] != "" ? Request.QueryString["tbl"] : "";
                    zid = Request.QueryString["zid"] != "" ? Request.QueryString["zid"] : "-1";
                    zglobal.fnDeleteBusiness1(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString(), zid);
                    //msg.InnerHtml = key + " " + tbl + " " + zid;
                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts4 = new DataSet();


                    dts4.Reset();
                    
                    string str = "select zid from "+ tbl +" where xrowd=@xrowd";



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
                                    //TextBox xar = (TextBox)gdrow.FindControl("accounts");
                                    //ImageButton acclist = (ImageButton) gdrow.FindControl("acclist");

                                    foreach (DataRow dbrow in temp.Rows)
                                    {
                                        if (gdrow.Cells[1].Text.ToString() == dbrow["zid"].ToString())
                                        {
                                            chk.Checked = true;
                                           // xar.Text = dbrow["xap"].ToString();
                                           // acclist.Enabled = true;
                                           // xar.Enabled = true;

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
            
        }

        //private void GetChildRows(DataRow dataRow, TreeNode mnitem)
        private void GetChildRows(TreeNode mnitem)
        {
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnPermission_Click1(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                SqlCommand dataCmd1 = new SqlCommand();
                dataCmd1.Connection = conn1;

                string str1;

                
                using (TransactionScope tran = new TransactionScope())
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox) row.FindControl("selbiz");
                        

                        if (chk.Checked)
                        {
                            str1 = "INSERT INTO ztemporary ("+ Request.QueryString["zid"] +",zorg,xsession,zemail) VALUES (@zid,@zorg,@xsession,@zemail)";
                            msg.InnerHtml = str1;
                            dataCmd1.CommandText = str1;
                            dataCmd1.Parameters.Clear();
                            dataCmd1.Parameters.AddWithValue("@zid", row.Cells[1].Text.ToString());
                            dataCmd1.Parameters.AddWithValue("@zorg", row.Cells[2].Text.ToString());
                            dataCmd1.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
                            dataCmd1.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
                            conn1.Close();
                            conn1.Open();
                            dataCmd1.ExecuteNonQuery();
                            conn1.Close();
                           
                        }

                                     
                    }
                    

                    dataCmd1.Dispose();
                    conn1.Dispose();


                    tran.Complete();

                    btnPermission.Enabled = false;
                    msg.InnerHtml = "Save completed successfully.";
                    msg.Style.Value = zglobal.successmsg;
                    btnPermission.Style.Value = zglobal.btncolor;
                }
                
            }
            catch (Exception exp)
            {
                btnPermission.Style.Value = zglobal.btnerr;
                Response.Write(exp.Message);
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            
        }

        protected void btnUpdate0_Click(object sender, EventArgs e)
        {
           
        }

       

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            
        }


 

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {

        }


        protected void selbiz_OnCheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}