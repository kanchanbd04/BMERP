using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OnlineTicketingSystem.Forms;

namespace OnlineTicketingSystem.forms.BMERP.sc
{
    public partial class glmst1 : System.Web.UI.Page
    {


        [WebMethod(EnableSession = true)]
        public static object Level1()
        {
            //try
            //{
            var objList = (new[] { new { Text = "[Select]", Value = "-1" } }).ToList();

            string cs = zglobal.constring;
            //List<xhrc1> xhrc1List = new List<xhrc1>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT xhrc1 FROM glhrc11";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //xhrc1 objhrc = new xhrc1();
                    //objhrc.xhrc11 = rdr["xhrc1"].ToString();
                    //objhrc.value = rdr["xhrc1"].ToString();
                    //xhrc1List.Add(objhrc);
                    objList.Add(new { Text = rdr["xhrc1"].ToString(), Value = rdr["xhrc1"].ToString() });
                }
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //HttpContext.Current.Response.Write(js.Serialize(xhrc1List));

            return objList;
            //}
            //catch (Exception exp)
            //{
            //    var  objList1 = (new[] {new {Text = exp.Message, Value = "err"}}).ToList();
            //    return objList1;
            //}
        }

        [WebMethod(EnableSession = true)]
        public static object Level2(string xhrc1)
        {
            var objList = (new[] { new { Text = "[Select]", Value = "-1" } }).ToList();

            string cs = zglobal.constring;
            //List<xhrc1> xhrc1List = new List<xhrc1>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT xhrc2 FROM glhrc21 WHERE xhrc1=@xhrc1";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@xhrc1", xhrc1);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //xhrc1 objhrc = new xhrc1();
                    //objhrc.xhrc11 = rdr["xhrc1"].ToString();
                    //objhrc.value = rdr["xhrc1"].ToString();
                    //xhrc1List.Add(objhrc);
                    objList.Add(new { Text = rdr["xhrc2"].ToString(), Value = rdr["xhrc2"].ToString() });
                }
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //HttpContext.Current.Response.Write(js.Serialize(xhrc1List));

            return objList;
        }

        [WebMethod(EnableSession = true)]
        public static object Level3(string xhrc1, string xhrc2)
        {
            var objList = (new[] { new { Text = "[Select]", Value = "-1" } }).ToList();

            string cs = zglobal.constring;
            //List<xhrc1> xhrc1List = new List<xhrc1>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT xhrc3 FROM glhrc31 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@xhrc1", xhrc1);
                cmd.Parameters.AddWithValue("@xhrc2", xhrc2);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //xhrc1 objhrc = new xhrc1();
                    //objhrc.xhrc11 = rdr["xhrc1"].ToString();
                    //objhrc.value = rdr["xhrc1"].ToString();
                    //xhrc1List.Add(objhrc);
                    objList.Add(new { Text = rdr["xhrc3"].ToString(), Value = rdr["xhrc3"].ToString() });
                }
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //HttpContext.Current.Response.Write(js.Serialize(xhrc1List));

            return objList;
        }

        [WebMethod(EnableSession = true)]
        public static object Level4(string xhrc1, string xhrc2, string xhrc3)
        {
            var objList = (new[] { new { Text = "[Select]", Value = "-1" } }).ToList();

            string cs = zglobal.constring;
            //List<xhrc1> xhrc1List = new List<xhrc1>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT xhrc4 FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@xhrc1", xhrc1);
                cmd.Parameters.AddWithValue("@xhrc2", xhrc2);
                cmd.Parameters.AddWithValue("@xhrc3", xhrc3);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //xhrc1 objhrc = new xhrc1();
                    //objhrc.xhrc11 = rdr["xhrc1"].ToString();
                    //objhrc.value = rdr["xhrc1"].ToString();
                    //xhrc1List.Add(objhrc);
                    objList.Add(new { Text = rdr["xhrc4"].ToString(), Value = rdr["xhrc4"].ToString() });
                }
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //HttpContext.Current.Response.Write(js.Serialize(xhrc1List));

            return objList;
        }

        [WebMethod(EnableSession = true)]
        public static object Level5(string xhrc1, string xhrc2, string xhrc3, string xhrc4)
        {
            var objList = (new[] { new { Text = "[Select]", Value = "-1" } }).ToList();

            string cs = zglobal.constring;
            //List<xhrc1> xhrc1List = new List<xhrc1>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT xhrc5 FROM glhrc51 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@xhrc1", xhrc1);
                cmd.Parameters.AddWithValue("@xhrc2", xhrc2);
                cmd.Parameters.AddWithValue("@xhrc3", xhrc3);
                cmd.Parameters.AddWithValue("@xhrc4", xhrc4);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //xhrc1 objhrc = new xhrc1();
                    //objhrc.xhrc11 = rdr["xhrc1"].ToString();
                    //objhrc.value = rdr["xhrc1"].ToString();
                    //xhrc1List.Add(objhrc);
                    objList.Add(new { Text = rdr["xhrc5"].ToString(), Value = rdr["xhrc5"].ToString() });
                }
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //HttpContext.Current.Response.Write(js.Serialize(xhrc1List));

            return objList;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();

                    fnFillLevel("load");
                    fnFillDataGrid();
                    zactive.Checked = true;
                    key.Value = "";
                    subacc.Visible = false;
                    ViewState["key"] = null;
                    Asset.Checked = true;
                    Ledger.Checked = true;
                    None.Checked = true;
                    //zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                    //fnLoadSpAcc();
                    //fnLoadCF();
                }

              

                //fnRegisterPostBack();
                //fnFillDataGrid();

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        private void fnLoadSpAcc()
        {
            //int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
            //string cs = zglobal.constring;
            //xtempstr1.Items.Clear();
            //xtempstr1.Items.Add("");
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    string query = "SELECT distinct xtempstr1 FROM glmst where zid=@zid";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddWithValue("@zid", _zid);
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        xtempstr1.Items.Add(rdr["xtempstr1"].ToString());
            //    }
            //}
            //xtempstr1.Text = "";
        }

        private void fnLoadCF()
        {
            //int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
            //string cs = zglobal.constring;
            //xcf1.Items.Clear();
            //xcf1.Items.Add("");
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    string query = "SELECT distinct xcf1 FROM glmst where zid=@zid";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddWithValue("@zid", _zid);
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        xcf1.Items.Add(rdr["xcf1"].ToString());
            //    }
            //}
            //xcf1.Text = "";
        }

        //public void fnRegisterPostBack()
        //{
        //    foreach (GridViewRow row in GridView2.Rows)
        //    {
        //        LinkButton lnkFull1 = row.FindControl("xacc") as LinkButton;
        //        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull1);
        //    }

        //}

        private void fnButtonFace(string flag)
        {
            if (flag == "save")
            {
                btnAdd.Enabled = false;
            }
            else if (flag == "update")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else if (flag == "clear")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                msg.InnerHtml = "";
                btnAdd.Style.Value = zglobal.btncolor;
                btnUpdate.Style.Value = zglobal.btncolor;
                btnDelete.Style.Value = zglobal.btncolor;
                fnButtonFace("clear");
                zemail.Text = "";
                xemail.Text = "";
                xacc.Text = "";
                xdesc.Text = "";

                Asset.Checked = true;
                Expenditure.Checked = false;
                Income.Checked = false;
                Liability.Checked = false;


                Ledger.Checked = true;
                AP.Checked = false;
                AR.Checked = false;
                Bank.Checked = false;
                Cash.Checked = false;

                Customer.Checked = false;
                Employee.Checked = false;
                Subaccount.Checked = false;
                Supplier.Checked = false;
                Bank1.Checked = false;
                Student1.Checked = false;
                None.Checked = true;

                //xhrc1.Text = "[Select]";
                xtempstr1.Text = "";
                xcf1.Text = "";
                //xeffdt.Text = "";
                zactive.Checked = true;
                ViewState["key"] = null;
                key.Value = "";
                fnFillLevel("load");
                //xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                fnFillDataGrid();
                btnClear.Style.Value = zglobal.btncolor;
                //zglobal.ltZbusinessGlmst.Clear();
                //zglobal.ltZbusinessGlmstPermis.Clear();
                //zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                lblSubAcc.Text = "Subaccount(s) of ()";
                subacc.Visible = false;

                GridView1.DataSource = null;
                GridView1.DataBind();
                UpdatePanel15.Update();
                //UpdatePanel12.Update();
                //UpdatePanel3.Update();
                //UpdatePanel28.Update();

                UpdatePanel32.Update();
                UpdatePanel30.Update();
                UpdatePanel29.Update();
                UpdatePanel28.Update();
                UpdatePanel14.Update();
                UpdatePanel27.Update();
                UpdatePanel26.Update();
                UpdatePanel13.Update();
                UpdatePanel25.Update();
                UpdatePanel24.Update();
                UpdatePanel23.Update();
                UpdatePanel22.Update();
                UpdatePanel21.Update();
                UpdatePanel20.Update();
                UpdatePanel19.Update();
                UpdatePanel12.Update();
            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                btnClear.Style.Value = zglobal.btnerr;
            }

        }

        //private DataTable fnCheckBusiness()
        //{
        //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //    {
        //        using (DataSet dts = new DataSet())
        //        {
        //            conn.Open();

        //            //try
        //            //{
        //            string query = "SELECT * FROM ztemporary WHERE zid2 IS NOT NULL and zemail=@zemail and xsession=@xsession";
        //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //            da.SelectCommand.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
        //            da.SelectCommand.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
        //            DataTable tempTable = new DataTable();
        //            da.Fill(dts, "tempTable");
        //            tempTable = dts.Tables["tempTable"];
        //            return tempTable;
        //            //}

        //            //catch (Exception exp)
        //            //{
        //            //    Response.Write(exp.Message);
        //            //}
        //        }
        //    }
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                if (xacc.Text == "" || xacc.Text == string.Empty)
                {
                    msg.InnerHtml = "Enter Account Code";
                    msg.Style.Value = zglobal.warningmsg;
                    btnAdd.Style.Value = zglobal.btnerr;
                    return;
                }
                if (xdesc.Text == "" || xdesc.Text == string.Empty)
                {
                    msg.InnerHtml = "Enter Account Description";
                    msg.Style.Value = zglobal.warningmsg;
                    btnAdd.Style.Value = zglobal.btnerr;
                    return;
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        //Insert data into glmsth
                        //Check header tavle duplicate entry
                        DataTable tempTable = new DataTable();
                        using (DataSet dts = new DataSet())
                        {
                            string query1 =
                                "SELECT * FROM glmst WHERE zid=@zid and xacc=@xacc";
                            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xacc", xacc.Text.ToString().Trim());
                            //DataTable tempTable = new DataTable();
                            da.Fill(dts, "tempTable");
                            tempTable = dts.Tables["tempTable"];
                        }

                        if (tempTable.Rows.Count > 0)
                        {
                            msg.InnerHtml = "Do not allowed duplicate entry.";
                            msg.Style.Value = zglobal.errormsg;
                            btnAdd.Style.Value = zglobal.btnerr;
                            return;
                        }

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";


                        //Insert data into glmstd
                        cmd.Parameters.Clear();
                        query = @"INSERT INTO glmst (ztime,zid,xacc,xdesc,xacctype, xaccusage, xaccsource,zemail,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,zactive,xtempstr1,xcf1,xmsttype,xcashacc)  
                                      VALUES(@ztime,@zid,@xacc,@xdesc,@xacctype, @xaccusage, @xaccsource,@zemail,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xhrc5,@zactive,@xtempstr1,@xcf1,@xmsttype,@xcashacc) ";


                        int zactive1 = zactive.Checked ? 1 : 0;


                        DateTime ztime = DateTime.Now;
                        string xacc1 = xacc.Text.ToString().Trim();
                        //string xacc1 = xacc.Text.ToString().Trim();
                        //DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                        string xdesc1 = xdesc.Text.ToString().Trim();
                        string xacctype1;
                        string xmsttype1;
                        if (Asset.Checked)
                        {
                            xacctype1 = "Asset";
                            xmsttype1 = "Balance Sheet";
                        }
                        else if (Expenditure.Checked)
                        {
                            xacctype1 = "Expenditure";
                            xmsttype1 = "Revenue";
                        }
                        else if (Income.Checked)
                        {
                            xacctype1 = "Income";
                            xmsttype1 = "Revenue";
                        }
                        else
                        {
                            xmsttype1 = "Balance Sheet";
                            xacctype1 = "Liability";
                        }

                        string xaccusage1;
                        string xcashacc1;
                        if (AP.Checked)
                        {
                            xaccusage1 = "AP";
                            xcashacc1 = "";
                        }
                        else if (AR.Checked)
                        {
                            xaccusage1 = "AR";
                            xcashacc1 = "";
                        }
                        else if (Bank.Checked)
                        {
                            xaccusage1 = "Bank";
                            xcashacc1 = "Cash";
                        }
                        else if (Cash.Checked)
                        {
                            xaccusage1 = "Cash";
                            xcashacc1 = "Cash";
                        }
                        else
                        {
                            xaccusage1 = "Ledger";
                            xcashacc1 = "";
                        }

                        if (xaccusage1 == "AP")
                        {
                            Supplier.Checked = true;
                        }

                        if (xaccusage1 == "AR")
                        {
                            Customer.Checked = true;
                        }

                        string xaccsource1;
                        if (Customer.Checked)
                            xaccsource1 = "Customer";
                        else if (Supplier.Checked)
                            xaccsource1 = "Supplier";
                        else if (Employee.Checked)
                            xaccsource1 = "Employee";
                        else if (Subaccount.Checked)
                            xaccsource1 = "Subaccount";
                        else if (Bank1.Checked)
                            xaccsource1 = "Bank";
                        else if (Student1.Checked)
                            xaccsource1 = "Student";
                        else
                            xaccsource1 = "None";


                        string xhrc11 = xhrc1.Text.ToString().Trim() == "[Select]" ? "" : xhrc1.Text.ToString().Trim();
                        string xhrc22 = xhrc2.Text.ToString().Trim() == "[Select]" ? "" : xhrc2.Text.ToString().Trim();
                        string xhrc33 = xhrc3.Text.ToString().Trim() == "[Select]" ? "" : xhrc3.Text.ToString().Trim();
                        string xhrc44 = xhrc4.Text.ToString().Trim() == "[Select]" ? "" : xhrc4.Text.ToString().Trim();
                        string xhrc55 = xhrc5.Text.ToString().Trim() == "[Select]" ? "" : xhrc5.Text.ToString().Trim();
                        string xtempstr11 = xtempstr1.Text.Trim().ToString();
                        string xcf11 = xcf1.Text.Trim().ToString();
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xacc", xacc1);
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                        cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                        cmd.Parameters.AddWithValue("@xaccusage", xaccusage1);
                        cmd.Parameters.AddWithValue("@xaccsource", xaccsource1);
                        cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                        cmd.Parameters.AddWithValue("@xhrc2", xhrc22);
                        cmd.Parameters.AddWithValue("@xhrc3", xhrc33);
                        cmd.Parameters.AddWithValue("@xhrc4", xhrc44);
                        cmd.Parameters.AddWithValue("@xhrc5", xhrc55);
                        cmd.Parameters.AddWithValue("@xtempstr1", xtempstr11);
                        cmd.Parameters.AddWithValue("@xcf1", xcf11);
                        cmd.Parameters.AddWithValue("@zemail", zemail1);
                        cmd.Parameters.AddWithValue("@zactive", zactive1);
                        cmd.Parameters.AddWithValue("@xmsttype", xmsttype1);
                        cmd.Parameters.AddWithValue("@xcashacc", xcashacc1);
                        cmd.ExecuteNonQuery();

                        if (xaccsource1 == "Subaccount")
                        {
                            subacc.Visible = true;
                            UpdatePanel5.Update();
                        }
                        else
                        {
                            subacc.Visible = false;
                            UpdatePanel5.Update();
                        }

                        lblSubAcc.Text = "Subaccount(s) " + xacc1 + " of (" + xdesc1 + ")";
                        UpdatePanel9.Update();

                    }


                    zemail.Text = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();

                }


                fnFillDataGrid();
                msg.InnerHtml = "Add comlpeted";
                msg.Style.Value = zglobal.successmsg;
                btnAdd.Style.Value = zglobal.btncolor;
                fnButtonFace("save");
                ViewState["key"] = xacc.Text.ToString();
                key.Value = xacc.Text.ToString();



            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                btnAdd.Style.Value = zglobal.btnerr;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                if (xacc.Text == "" || xacc.Text == string.Empty)
                {
                    msg.InnerHtml = "Enter Account Code";
                    msg.Style.Value = zglobal.warningmsg;
                    btnAdd.Style.Value = zglobal.btnerr;
                    return;
                }
                if (xdesc.Text == "" || xdesc.Text == string.Empty)
                {
                    msg.InnerHtml = "Enter Account Description";
                    msg.Style.Value = zglobal.warningmsg;
                    btnUpdate.Style.Value = zglobal.btnerr;
                    return;
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";
                        int zactive1 = zactive.Checked ? 1 : 0;

                        query = "UPDATE glmst SET zutime=@zutime,xdesc=@xdesc,xacctype=@xacctype,xaccusage=@xaccusage,xaccsource=@xaccsource,xhrc1=@xhrc1," +
                                "xhrc2=@xhrc2,xhrc3=@xhrc3,xhrc4=@xhrc4,xhrc5=@xhrc5,xtempstr1=@xtempstr1,xcf1=@xcf1,xemail=@xemail,zactive=@zactive,xmsttype=@xmsttype,xcashacc=@xcashacc " +
                                "WHERE zid=@zid and xacc=@xacc ";
                        DateTime ztime = DateTime.Now;
                        string xacc1 = xacc.Text.ToString().Trim();
                        string xdesc1 = xdesc.Text.ToString().Trim();
                        string xacctype1;
                        string xmsttype1;
                        if (Asset.Checked)
                        {
                            xacctype1 = "Asset";
                            xmsttype1 = "Balance Sheet";
                        }
                        else if (Expenditure.Checked)
                        {
                            xacctype1 = "Expenditure";
                            xmsttype1 = "Revenue";
                        }
                        else if (Income.Checked)
                        {
                            xacctype1 = "Income";
                            xmsttype1 = "Revenue";
                        }
                        else
                        {
                            xmsttype1 = "Balance Sheet";
                            xacctype1 = "Liability";
                        }

                        string xaccusage1;
                        string xcashacc1;
                        if (AP.Checked)
                        {
                            xaccusage1 = "AP";
                            xcashacc1 = "";
                        }
                        else if (AR.Checked)
                        {
                            xaccusage1 = "AR";
                            xcashacc1 = "";
                        }
                        else if (Bank.Checked)
                        {
                            xaccusage1 = "Bank";
                            xcashacc1 = "Cash";
                        }
                        else if (Cash.Checked)
                        {
                            xaccusage1 = "Cash";
                            xcashacc1 = "Cash";
                        }
                        else
                        {
                            xaccusage1 = "Ledger";
                            xcashacc1 = "";
                        }

                        if (xaccusage1 == "AP")
                        {
                            Supplier.Checked = true;
                        }

                        if (xaccusage1 == "AR")
                        {
                            Customer.Checked = true;
                        }

                        string xaccsource1;
                        if (Customer.Checked)
                            xaccsource1 = "Customer";
                        else if (Supplier.Checked)
                            xaccsource1 = "Supplier";
                        else if (Employee.Checked)
                            xaccsource1 = "Employee";
                        else if (Subaccount.Checked)
                            xaccsource1 = "Subaccount";
                        else if (Bank1.Checked)
                            xaccsource1 = "Bank";
                        else if (Student1.Checked)
                            xaccsource1 = "Student";
                        else
                            xaccsource1 = "None";

                        string xhrc11 = xhrc1.Text.ToString().Trim() == "[Select]" ? "" : xhrc1.Text.ToString().Trim();
                        string xhrc22 = xhrc2.Text.ToString().Trim() == "[Select]" ? "" : xhrc2.Text.ToString().Trim();
                        string xhrc33 = xhrc3.Text.ToString().Trim() == "[Select]" ? "" : xhrc3.Text.ToString().Trim();
                        string xhrc44 = xhrc4.Text.ToString().Trim() == "[Select]" ? "" : xhrc4.Text.ToString().Trim();
                        string xhrc55 = xhrc5.Text.ToString().Trim() == "[Select]" ? "" : xhrc5.Text.ToString().Trim();
                        string xtempstr11 = xtempstr1.Text.Trim().ToString();
                        string xcf11 = xcf1.Text.Trim().ToString();
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xacc", xacc1);
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                        cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                        cmd.Parameters.AddWithValue("@xaccusage", xaccusage1);
                        cmd.Parameters.AddWithValue("@xaccsource", xaccsource1);
                        cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                        cmd.Parameters.AddWithValue("@xhrc2", xhrc22);
                        cmd.Parameters.AddWithValue("@xhrc3", xhrc33);
                        cmd.Parameters.AddWithValue("@xhrc4", xhrc44);
                        cmd.Parameters.AddWithValue("@xhrc5", xhrc55);
                        cmd.Parameters.AddWithValue("@xtempstr1", xtempstr11);
                        cmd.Parameters.AddWithValue("@xcf1", xcf11);
                        cmd.Parameters.AddWithValue("@xemail", zemail1);
                        cmd.Parameters.AddWithValue("@zactive", zactive1);
                        cmd.Parameters.AddWithValue("@xmsttype", xmsttype1);
                        cmd.Parameters.AddWithValue("@xcashacc", xcashacc1);
                        cmd.ExecuteNonQuery();

                        if (xaccsource1 == "Subaccount")
                        {
                            subacc.Visible = true;
                            UpdatePanel5.Update();
                        }
                        else
                        {
                            subacc.Visible = false;
                            UpdatePanel5.Update();
                        }

                        lblSubAcc.Text = "Subaccount(s) " + xacc1 + " of (" + xdesc1 + ")";
                        UpdatePanel9.Update();

                    }



                    xemail.Text = HttpContext.Current.Session["curuser"].ToString();
                    tran.Complete();

                }
                fnFillDataGrid();
                msg.InnerHtml = "Update comlpeted";
                msg.Style.Value = zglobal.successmsg;
                btnUpdate.Style.Value = zglobal.btncolor;
                fnButtonFace("save");
                ViewState["key"] = xacc.Text.ToString();
                key.Value = xacc.Text.ToString();



            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                btnUpdate.Style.Value = zglobal.btnerr;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                if (ViewState["key"] != null)
                {
                    if (txtconformmessageValue.Value == "Yes")
                    {

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM glmst WHERE zid=@zid AND xacc=@xacc";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xacc", Convert.ToString(ViewState["key"]));
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        //msg.InnerHtml = zglobal.delsuccmsg;
                        //msg.Style.Value = zglobal.successmsg;
                        //btnDelete.Style.Value = zglobal.btncolor;
                        fnFillDataGrid();
                        btnClear_Click(sender, e);
                        msg.InnerHtml = zglobal.delsuccmsg;
                        msg.Style.Value = zglobal.successmsg;
                        btnDelete.Style.Value = zglobal.btncolor;
                    }
                }
                else
                {
                    msg.InnerHtml = "No data found for delete.";
                    msg.Style.Value = zglobal.warningmsg;
                    btnDelete.Style.Value = zglobal.btnerr;
                }

            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                btnDelete.Style.Value = zglobal.btnerr;
            }
        }

        private void fnFillLevel(string flag)
        {
            try
            {
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                string cs = zglobal.constring;

                if (flag == "load")
                {
                    xhrc1.Items.Clear();
                    xhrc1.Items.Add("[Select]");
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT xhrc1 FROM glhrc1 where zid=@zid";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            xhrc1.Items.Add(rdr["xhrc1"].ToString());
                        }
                    }
                    xhrc1.Text = "[Select]";
                }


                if (xhrc1.Text != "[Select]" && flag == "level1")
                {
                    xhrc2.Items.Clear();
                    xhrc2.Items.Add("[Select]");
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT xhrc2 FROM glhrc2 WHERE zid=@zid and xhrc1=@xhrc1";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            xhrc2.Items.Add(rdr["xhrc2"].ToString());
                        }
                    }
                    xhrc2.Enabled = true;
                }

                if (xhrc2.Text != "[Select]" && flag == "level2")
                {
                    xhrc3.Items.Clear();
                    xhrc3.Items.Add("[Select]");
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT xhrc3 FROM glhrc3 WHERE zid=@zid and xhrc1=@xhrc1 and xhrc2=@xhrc2";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
                        cmd.Parameters.AddWithValue("@xhrc2", xhrc2.Text);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            xhrc3.Items.Add(rdr["xhrc3"].ToString());
                        }
                    }
                    xhrc3.Enabled = true;
                }
                if (xhrc3.Text != "[Select]" && flag == "level3")
                {
                    xhrc4.Items.Clear();
                    xhrc4.Items.Add("[Select]");
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT xhrc4 FROM glhrc4 WHERE zid=@zid and xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
                        cmd.Parameters.AddWithValue("@xhrc2", xhrc2.Text);
                        cmd.Parameters.AddWithValue("@xhrc3", xhrc3.Text);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            xhrc4.Items.Add(rdr["xhrc4"].ToString());
                        }
                    }
                    xhrc4.Enabled = true;
                }
                if (xhrc4.Text != "[Select]" && flag == "level4")
                {
                    xhrc5.Items.Clear();
                    xhrc5.Items.Add("[Select]");
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT xhrc5 FROM glhrc5 WHERE zid=@zid and xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xhrc1", xhrc1.Text);
                        cmd.Parameters.AddWithValue("@xhrc2", xhrc2.Text);
                        cmd.Parameters.AddWithValue("@xhrc3", xhrc3.Text);
                        cmd.Parameters.AddWithValue("@xhrc4", xhrc4.Text);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            xhrc5.Items.Add(rdr["xhrc5"].ToString());
                        }
                    }
                    xhrc5.Enabled = true;
                }
                if (xhrc1.Text == "[Select]")
                {
                    xhrc2.Items.Clear();
                    xhrc3.Items.Clear();
                    xhrc4.Items.Clear();
                    xhrc5.Items.Clear();
                    xhrc2.Enabled = false;
                    xhrc3.Enabled = false;
                    xhrc4.Enabled = false;
                    xhrc5.Enabled = false;
                }
                if (xhrc2.Text == "[Select]")
                {
                    //xhrc2.Items.Clear();
                    xhrc3.Items.Clear();
                    xhrc4.Items.Clear();
                    xhrc5.Items.Clear();
                    //xhrc2.Enabled = false;
                    xhrc3.Enabled = false;
                    xhrc4.Enabled = false;
                    xhrc5.Enabled = false;
                }
                if (xhrc3.Text == "[Select]")
                {
                    //xhrc2.Items.Clear();
                    //xhrc3.Items.Clear();
                    xhrc4.Items.Clear();
                    xhrc5.Items.Clear();
                    //xhrc2.Enabled = false;
                    //xhrc3.Enabled = false;
                    xhrc4.Enabled = false;
                    xhrc5.Enabled = false;
                }
                if (xhrc4.Text == "[Select]")
                {
                    //xhrc2.Items.Clear();
                    //xhrc3.Items.Clear();
                    //xhrc4.Items.Clear();
                    xhrc5.Items.Clear();
                    //xhrc2.Enabled = false;
                    //xhrc3.Enabled = false;
                    //xhrc4.Enabled = false;
                    xhrc5.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }

        }

        protected void xhrc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnFillLevel("level1");
        }

        protected void xhrc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnFillLevel("level2");
        }

        protected void xhrc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnFillLevel("level3");
        }

        protected void xhrc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnFillLevel("level4");
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                //msg.InnerHtml = "City : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xrow1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM glmst WHERE zid=@zid and xacc=@xacc";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xacc", ((LinkButton)sender).Text);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                //xrow.Text = ((LinkButton) sender).Text;
                xacc.Text = dtztcode.Rows[0]["xacc"].ToString();
                xdesc.Text = dtztcode.Rows[0]["xdesc"].ToString();

               
                string xacctype1 = dtztcode.Rows[0]["xacctype"].ToString();
                //msg.InnerHtml = xacctype1;
                if (xacctype1 == "Asset")
                {
                    Asset.Checked = true;
                    Expenditure.Checked = false;
                    Income.Checked = false;
                    Liability.Checked = false;
                    UpdatePanel12.Update();
                }
                else if (xacctype1 == "Expenditure")
                {
                    Asset.Checked = false;
                    Expenditure.Checked = true;
                    Income.Checked = false;
                    Liability.Checked = false;
                    UpdatePanel19.Update();
                }
                else if (xacctype1 == "Income")
                {
                    Asset.Checked = false;
                    Expenditure.Checked = false;
                    Income.Checked = true;
                    Liability.Checked = false;
                    UpdatePanel20.Update();
                }
                else
                {
                    Asset.Checked = false;
                    Expenditure.Checked = false;
                    Income.Checked = false;
                    Liability.Checked = true;
                    UpdatePanel21.Update();
                }


                string xaccusage1 = dtztcode.Rows[0]["xaccusage"].ToString();
                if (xaccusage1 == "AP")
                {
                    Ledger.Checked = false;
                    AP.Checked = true;
                    AR.Checked = false;
                    Bank.Checked = false;
                    Cash.Checked = false;
                    UpdatePanel22.Update();
                }
                else if (xaccusage1 == "AR")
                {
                    Ledger.Checked = false;
                    AP.Checked = false;
                    AR.Checked = true;
                    Bank.Checked = false;
                    Cash.Checked = false;
                    UpdatePanel23.Update();
                }
                else if (xaccusage1 == "Bank")
                {
                    Ledger.Checked = false;
                    AP.Checked = false;
                    AR.Checked = false;
                    Bank.Checked = true;
                    Cash.Checked = false;
                    UpdatePanel24.Update();
                }
                else if (xaccusage1 == "Cash")
                {
                    Ledger.Checked = false;
                    AP.Checked = false;
                    AR.Checked = false;
                    Bank.Checked = false;
                    Cash.Checked = true;
                    UpdatePanel25.Update();
                }
                else
                {
                    Ledger.Checked = true;
                    AP.Checked = false;
                    AR.Checked = false;
                    Bank.Checked = false;
                    Cash.Checked = false;
                    UpdatePanel3.Update();
                }

                string xaccsource1 = dtztcode.Rows[0]["xaccsource"].ToString();
                if (xaccsource1 == "Customer")
                {
                    Customer.Checked = true;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel26.Update();
                }
                else if (xaccsource1 == "Supplier")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = true;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel29.Update();
                }
                else if (xaccsource1 == "Employee")
                {
                    Customer.Checked = false;
                    Employee.Checked = true;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel27.Update();
                }
                else if (xaccsource1 == "Subaccount")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = true;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel28.Update();
                }
                else if (xaccsource1 == "Bank")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = true;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel30.Update();
                }
                else if (xaccsource1 == "Student")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = true;
                    None.Checked = false;
                    UpdatePanel32.Update();
                }
                else
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = true;
                    UpdatePanel14.Update();
                }

                if (xaccsource1 == "Subaccount")
                {
                    subacc.Visible = true;
                    UpdatePanel5.Update();
                }
                else
                {
                    subacc.Visible = false;
                    UpdatePanel5.Update();
                }

                if (dtztcode.Rows[0]["xhrc1"].ToString() != "")
                {
                    xhrc1.Text = dtztcode.Rows[0]["xhrc1"].ToString();
                    fnFillLevel("level1");
                }
                if (dtztcode.Rows[0]["xhrc2"].ToString() != "")
                {
                    xhrc2.Text = dtztcode.Rows[0]["xhrc2"].ToString();
                    fnFillLevel("level2");
                }
                if (dtztcode.Rows[0]["xhrc3"].ToString() != "")
                {
                    xhrc3.Text = dtztcode.Rows[0]["xhrc3"].ToString();
                    fnFillLevel("level3");
                }
                if (dtztcode.Rows[0]["xhrc4"].ToString() != "")
                {
                    xhrc4.Text = dtztcode.Rows[0]["xhrc4"].ToString();
                    fnFillLevel("level4");
                }
                if (dtztcode.Rows[0]["xhrc5"].ToString() != "")
                {
                    xhrc5.Text = dtztcode.Rows[0]["xhrc5"].ToString();
                }
                //xeffdt.Text = Convert.ToDateTime(dtztcode.Rows[0]["xeffdt"].ToString()).ToShortDateString();
                xtempstr1.Text = dtztcode.Rows[0]["xtempstr1"].ToString();
                xcf1.Text = dtztcode.Rows[0]["xcf1"].ToString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                zemail.Text = dtztcode.Rows[0]["zemail"].ToString();
                xemail.Text = dtztcode.Rows[0]["xemail"].ToString();
                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                fnButtonFace("save");
                //fnButtonFace("update");
                msg.InnerHtml = "";
                ViewState["key"] = ((LinkButton)sender).Text;
                key.Value = ((LinkButton)sender).Text;
                UpdatePanel1.Update();
                //UpdatePanel2.Update();

                UpdatePanel10.Update();
                UpdatePanel11.Update();
                UpdatePanel4.Update();
                UpdatePanel6.Update();
                UpdatePanel7.Update();
                UpdatePanel8.Update();
                //UpdatePanel15.Update();
                UpdatePanel16.Update();
                UpdatePanel17.Update();
                UpdatePanel18.Update();
                UpdatePanel13.Update();
                UpdatePanel31.Update();



                lblSubAcc.Text = "Subaccount(s) " + dtztcode.Rows[0]["xacc"].ToString() + " of (" + dtztcode.Rows[0]["xdesc"].ToString() + ")";
                //zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                UpdatePanel9.Update();
                fnFillDataGrid();
                UpdatePanel15.Update();

                UpdatePanel32.Update();
                UpdatePanel30.Update();
                UpdatePanel29.Update();
                UpdatePanel28.Update();
                UpdatePanel14.Update();
                UpdatePanel27.Update();
                UpdatePanel26.Update();
                UpdatePanel13.Update();
                UpdatePanel25.Update();
                UpdatePanel24.Update();
                UpdatePanel23.Update();
                UpdatePanel22.Update();
                UpdatePanel21.Update();
                UpdatePanel20.Update();
                UpdatePanel19.Update();
                UpdatePanel12.Update();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        public void fnFillDataGrid()
        {
            msg.InnerHtml = "";
            int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xacc,xdesc,xacctype,xaccsource,zactive FROM glmst where zid=@zid ORDER BY xacc";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
            da.Fill(dts, "tempztcode");

            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView2.DataSource = dtztcode;
            GridView2.DataBind();

            if (ViewState["key"] != null)
            {
                dts.Reset();
                str = "SELECT * FROM glsub where zid=@zid and xacc=@xacc ORDER BY xsub";
                da = new SqlDataAdapter(str, conn1);
                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xacc", ViewState["key"].ToString());
                da.Fill(dts, "tempztcode");

                //DataView dv = new DataView(dts.Tables[0]);
                dtztcode = new DataTable();
                dtztcode = dts.Tables[0];
                GridView1.DataSource = dtztcode;
                GridView1.DataBind();
            }



            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();
        }


        protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                if (xacc.Text.Trim().ToString() == "")
                {
                    return;
                }


                string xacccheck = zglobal.fnGetValue("xacc", "glmst",
                    "zid=" + _zid + " and xacc='" + xacc.Text.Trim().ToString() + "'");

                if (xacccheck == "")
                {
                    btnClear_Click(sender, e);
                    msg.InnerHtml = "Invalid Account";
                    msg.Style.Value = zglobal.errormsg;

                    return;
                }

                //msg.InnerHtml = "City : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xrow1 = xacc.Text.Trim().ToString();


                string str = "SELECT * FROM glmst WHERE zid=@zid and xacc=@xacc";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                da.SelectCommand.Parameters.AddWithValue("@xacc", xacc.Text.Trim().ToString());
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                //xrow.Text = ((LinkButton) sender).Text;
                xacc.Text = dtztcode.Rows[0]["xacc"].ToString();
                xdesc.Text = dtztcode.Rows[0]["xdesc"].ToString();

                string xacctype1 = dtztcode.Rows[0]["xacctype"].ToString();
                //msg.InnerHtml = xacctype1;
                if (xacctype1 == "Asset")
                {
                    Asset.Checked = true;
                    Expenditure.Checked = false;
                    Income.Checked = false;
                    Liability.Checked = false;
                    UpdatePanel12.Update();
                }
                else if (xacctype1 == "Expenditure")
                {
                    Asset.Checked = false;
                    Expenditure.Checked = true;
                    Income.Checked = false;
                    Liability.Checked = false;
                    UpdatePanel19.Update();
                }
                else if (xacctype1 == "Income")
                {
                    Asset.Checked = false;
                    Expenditure.Checked = false;
                    Income.Checked = true;
                    Liability.Checked = false;
                    UpdatePanel20.Update();
                }
                else
                {
                    Asset.Checked = false;
                    Expenditure.Checked = false;
                    Income.Checked = false;
                    Liability.Checked = true;
                    UpdatePanel21.Update();
                }


                string xaccusage1 = dtztcode.Rows[0]["xaccusage"].ToString();
                if (xaccusage1 == "AP")
                {
                    Ledger.Checked = false;
                    AP.Checked = true;
                    AR.Checked = false;
                    Bank.Checked = false;
                    Cash.Checked = false;
                    UpdatePanel22.Update();
                }
                else if (xaccusage1 == "AR")
                {
                    Ledger.Checked = false;
                    AP.Checked = false;
                    AR.Checked = true;
                    Bank.Checked = false;
                    Cash.Checked = false;
                    UpdatePanel23.Update();
                }
                else if (xaccusage1 == "Bank")
                {
                    Ledger.Checked = false;
                    AP.Checked = false;
                    AR.Checked = false;
                    Bank.Checked = true;
                    Cash.Checked = false;
                    UpdatePanel24.Update();
                }
                else if (xaccusage1 == "Cash")
                {
                    Ledger.Checked = false;
                    AP.Checked = false;
                    AR.Checked = false;
                    Bank.Checked = false;
                    Cash.Checked = true;
                    UpdatePanel25.Update();
                }
                else
                {
                    Ledger.Checked = true;
                    AP.Checked = false;
                    AR.Checked = false;
                    Bank.Checked = false;
                    Cash.Checked = false;
                    UpdatePanel3.Update();
                }

                string xaccsource1 = dtztcode.Rows[0]["xaccsource"].ToString();
                if (xaccsource1 == "Customer")
                {
                    Customer.Checked = true;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel26.Update();
                }
                else if (xaccsource1 == "Supplier")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = true;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel29.Update();
                }
                else if (xaccsource1 == "Employee")
                {
                    Customer.Checked = false;
                    Employee.Checked = true;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel27.Update();
                }
                else if (xaccsource1 == "Subaccount")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = true;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel28.Update();
                }
                else if (xaccsource1 == "Bank")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = true;
                    Student1.Checked = false;
                    None.Checked = false;
                    UpdatePanel30.Update();
                }
                else if (xaccsource1 == "Student")
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = true;
                    None.Checked = false;
                    UpdatePanel32.Update();
                }
                else
                {
                    Customer.Checked = false;
                    Employee.Checked = false;
                    Subaccount.Checked = false;
                    Supplier.Checked = false;
                    Bank1.Checked = false;
                    Student1.Checked = false;
                    None.Checked = true;
                    UpdatePanel14.Update();
                }

                if (xaccsource1 == "Subaccount")
                {
                    subacc.Visible = true;
                    UpdatePanel5.Update();
                }
                else
                {
                    subacc.Visible = false;
                    UpdatePanel5.Update();
                }

                if (dtztcode.Rows[0]["xhrc1"].ToString() != "")
                {
                    xhrc1.Text = dtztcode.Rows[0]["xhrc1"].ToString();
                    fnFillLevel("level1");
                }
                if (dtztcode.Rows[0]["xhrc2"].ToString() != "")
                {
                    xhrc2.Text = dtztcode.Rows[0]["xhrc2"].ToString();
                    fnFillLevel("level2");
                }
                if (dtztcode.Rows[0]["xhrc3"].ToString() != "")
                {
                    xhrc3.Text = dtztcode.Rows[0]["xhrc3"].ToString();
                    fnFillLevel("level3");
                }
                if (dtztcode.Rows[0]["xhrc4"].ToString() != "")
                {
                    xhrc4.Text = dtztcode.Rows[0]["xhrc4"].ToString();
                    fnFillLevel("level4");
                }
                if (dtztcode.Rows[0]["xhrc5"].ToString() != "")
                {
                    xhrc5.Text = dtztcode.Rows[0]["xhrc5"].ToString();
                }
                xtempstr1.Text = dtztcode.Rows[0]["xtempstr1"].ToString();
                xcf1.Text = dtztcode.Rows[0]["xcf1"].ToString();
                //xeffdt.Text = Convert.ToDateTime(dtztcode.Rows[0]["xeffdt"].ToString()).ToShortDateString();
                zactive.Checked = dtztcode.Rows[0]["zactive"].ToString() == "1" ? true : false;
                zemail.Text = dtztcode.Rows[0]["zemail"].ToString();
                xemail.Text = dtztcode.Rows[0]["xemail"].ToString();
                dts.Dispose();
                dtztcode.Dispose();
                da.Dispose();
                conn1.Dispose();
                fnButtonFace("save");
                //fnButtonFace("update");
                msg.InnerHtml = "";
                ViewState["key"] = xacc.Text.Trim().ToString();
                key.Value = xacc.Text.Trim().ToString();
                UpdatePanel1.Update();
                //UpdatePanel2.Update();
                //UpdatePanel5.Update();
                UpdatePanel10.Update();
                UpdatePanel11.Update();
                UpdatePanel4.Update();
                UpdatePanel6.Update();
                UpdatePanel7.Update();
                UpdatePanel8.Update();
                //UpdatePanel15.Update();
                UpdatePanel16.Update();
                UpdatePanel17.Update();
                UpdatePanel18.Update();
                UpdatePanel13.Update();
                UpdatePanel31.Update();


                lblSubAcc.Text = "Subaccount(s) " + dtztcode.Rows[0]["xacc"].ToString() + " of (" + dtztcode.Rows[0]["xdesc"].ToString() + ")";
                //zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                UpdatePanel9.Update();
                fnFillDataGrid();
                UpdatePanel15.Update();

                UpdatePanel32.Update();
                UpdatePanel30.Update();
                UpdatePanel29.Update();
                UpdatePanel28.Update();
                UpdatePanel14.Update();
                UpdatePanel27.Update();
                UpdatePanel26.Update();
                UpdatePanel13.Update();
                UpdatePanel25.Update();
                UpdatePanel24.Update();
                UpdatePanel23.Update();
                UpdatePanel22.Update();
                UpdatePanel21.Update();
                UpdatePanel20.Update();
                UpdatePanel19.Update();
                UpdatePanel12.Update();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string fnFetchValue(string xacc1, string xsub1)
        {
            try
            {

                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));

                using (SqlConnection conn = new SqlConnection(zglobal.constring))
                {
                    using (DataSet dts = new DataSet())
                    {



                        string query = "SELECT xacc,xsub,xoffadd,xdesc  FROM glsub WHERE zid=@zid and xacc=@xacc and xsub=@xsub";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                        da.SelectCommand.Parameters.AddWithValue("@xacc", xacc1);
                        da.SelectCommand.Parameters.AddWithValue("@xsub", xsub1);
                        da.Fill(dts, "tempTable");
                        DataTable tempTable = new DataTable();
                        tempTable = dts.Tables["tempTable"];

                        if (tempTable.Rows.Count > 0)
                        {
                            return "success" + "|" + tempTable.Rows[0]["xsub"].ToString() + "|" + tempTable.Rows[0]["xdesc"].ToString()
                                + "|" + tempTable.Rows[0]["xoffadd"].ToString() ;
                        }
                        else
                        {
                            return "nodata";
                        }



                    }
                }



            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        protected void btnSave1_OnClick(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                if (xsub.Text == "" || xsub.Text == string.Empty)
                {
                    //msg.InnerHtml = "Enter Account Code";
                    //msg.Style.Value = zglobal.warningmsg;
                    //btnAdd.Style.Value = zglobal.btnerr;
                    return;
                }
                if (xdesc1.Text == "" || xdesc1.Text == string.Empty)
                {
                    //msg.InnerHtml = "Enter Account Description";
                    //msg.Style.Value = zglobal.warningmsg;
                    //btnAdd.Style.Value = zglobal.btnerr;
                    return;
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();
                        //Insert data into glmsth
                        //Check header tavle duplicate entry
                        DataTable tempTable = new DataTable();
                        using (DataSet dts = new DataSet())
                        {
                            string query1 =
                                "SELECT * FROM glsub WHERE zid=@zid and xacc=@xacc and xsub=@xsub";
                            SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da.SelectCommand.Parameters.AddWithValue("@xacc", xacc.Text.ToString().Trim());
                            da.SelectCommand.Parameters.AddWithValue("@xsub", xsub.Text.ToString().Trim());
                            //DataTable tempTable = new DataTable();
                            da.Fill(dts, "tempTable");
                            tempTable = dts.Tables["tempTable"];
                        }

                        if (tempTable.Rows.Count > 0)
                        {
                            //msg.InnerHtml = "Do not allowed duplicate entry.";
                            //msg.Style.Value = zglobal.errormsg;
                            //btnAdd.Style.Value = zglobal.btnerr;
                            return;
                        }

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";


                        //Insert data into glmstd
                        cmd.Parameters.Clear();
                        query = @"INSERT INTO glsub (ztime,zid,xacc,xsub,xdesc,xoffadd,zemail)  
                                      VALUES(@ztime,@zid,@xacc,@xsub,@xdesc,@xoffadd,@zemail) ";


                        int zactive1 = zactive.Checked ? 1 : 0;


                        DateTime ztime = DateTime.Now;
                        string xacc1 = xacc.Text.ToString().Trim();
                        //string xacc1 = xacc.Text.ToString().Trim();
                        //DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                        


                        
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ztime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xacc", key.Value);
                        cmd.Parameters.AddWithValue("@xsub", xsub.Text.Trim().ToString());
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1.Text.Trim().ToString());
                        cmd.Parameters.AddWithValue("@xoffadd", xoffadd.Text.Trim().ToString());
                        cmd.Parameters.AddWithValue("@zemail", zemail1);
                        cmd.ExecuteNonQuery();


                    }


                   
                    tran.Complete();

                }


                fnFillDataGrid();
                //msg.InnerHtml = "Add comlpeted";
                //msg.Style.Value = zglobal.successmsg;
                //btnAdd.Style.Value = zglobal.btncolor;
                //fnButtonFace("save");
                //ViewState["key"] = xacc.Text.ToString();
                //key.Value = xacc.Text.ToString();



            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                //btnAdd.Style.Value = zglobal.btnerr;
            }
        }

        protected void btnUpdate1_OnClick(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                if (xsub.Text == "" || xsub.Text == string.Empty)
                {
                    //msg.InnerHtml = "Enter Account Code";
                    //msg.Style.Value = zglobal.warningmsg;
                    //btnAdd.Style.Value = zglobal.btnerr;
                    return;
                }
                if (xdesc1.Text == "" || xdesc1.Text == string.Empty)
                {
                    //msg.InnerHtml = "Enter Account Description";
                    //msg.Style.Value = zglobal.warningmsg;
                    //btnAdd.Style.Value = zglobal.btnerr;
                    return;
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(zglobal.constring))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        string query = "";
                        int zactive1 = zactive.Checked ? 1 : 0;

                        query = "UPDATE glsub SET zutime=@zutime,xdesc=@xdesc,xoffadd=@xoffadd,xemail=@xemail " +
                                "WHERE zid=@zid and xacc=@xacc and xsub=@xsub ";
                        DateTime ztime = DateTime.Now;
                        
                        string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@zutime", ztime);
                        cmd.Parameters.AddWithValue("@zid", _zid);
                        cmd.Parameters.AddWithValue("@xacc", key.Value);
                        cmd.Parameters.AddWithValue("@xsub", xsub.Text.Trim().ToString());
                        cmd.Parameters.AddWithValue("@xdesc", xdesc1.Text.Trim().ToString());
                        cmd.Parameters.AddWithValue("@xoffadd", xoffadd.Text.Trim().ToString());
                        cmd.Parameters.AddWithValue("@xemail", zemail1);
                        cmd.ExecuteNonQuery();

                    }

                    tran.Complete();

                }

                fnFillDataGrid();
                //msg.InnerHtml = "Update comlpeted";
                //msg.Style.Value = zglobal.successmsg;
                //btnUpdate.Style.Value = zglobal.btncolor;
                //fnButtonFace("save");
                //ViewState["key"] = xacc.Text.ToString();
                //key.Value = xacc.Text.ToString();



            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
                //btnUpdate.Style.Value = zglobal.btnerr;
            }
        }

        protected void btnDeleteSub_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerHtml = "";
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

                if (ViewState["key"] != null)
                {
                    if (txtconformmessageValue1.Value == "Yes")
                    {

                        using (TransactionScope tran = new TransactionScope())
                        {
                            using (SqlConnection conn = new SqlConnection(zglobal.constring))
                            {
                                LinkButton lb = (LinkButton)sender;
                                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                                int rowID = gvRow.RowIndex;

                                string xsub1 = gvRow.Cells[1].Text;

                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;


                                string query = "DELETE FROM glsub WHERE zid=@zid AND xacc=@xacc and xsub=@xsub";
                                cmd.Parameters.Clear();

                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@zid", _zid);
                                cmd.Parameters.AddWithValue("@xacc", Convert.ToString(ViewState["key"]));
                                cmd.Parameters.AddWithValue("@xsub", xsub1);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Complete();
                        }

                        //msg.InnerHtml = zglobal.delsuccmsg;
                        //msg.Style.Value = zglobal.successmsg;
                        //btnDelete.Style.Value = zglobal.btncolor;
                        fnFillDataGrid();
                        //btnClear_Click(sender, e);
                        //msg.InnerHtml = zglobal.delsuccmsg;
                        //msg.Style.Value = zglobal.successmsg;
                        //btnDelete.Style.Value = zglobal.btncolor;
                    }
                }
                else
                {
                    //msg.InnerHtml = "No data found for delete.";
                    //msg.Style.Value = zglobal.warningmsg;
                    //btnDelete.Style.Value = zglobal.btnerr;
                }

            }
            catch (Exception exp)
            {

                //msg.InnerHtml = exp.Message;
                //msg.Style.Value = zglobal.errormsg;
                //btnDelete.Style.Value = zglobal.btnerr;
            }
        }

    }
}