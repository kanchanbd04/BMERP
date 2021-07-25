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
    public partial class glmst : System.Web.UI.Page
    {
       

        [WebMethod(EnableSession = true)]
        public static object Level1()
        {
            //try
            //{
                var objList = (new[] {new {Text = "[Select]", Value = "-1"}}).ToList();
         
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
                        objList.Add(new {Text = rdr["xhrc1"].ToString(), Value = rdr["xhrc1"].ToString()});
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
                    xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();

                    fnFillLevel("load");
                    fnFillDataGrid();
                    zactive.Checked = true;
                    key.Value = "";
                    //ViewState["key"] = null;
                    zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                }

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

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
                Ledger.Checked = true;
                None.Checked = true;
                //xhrc1.Text = "[Select]";
                xspaccgp.Text = "";
                xcf1.Text = "";
                xeffdt.Text = "";
                zactive.Checked = true;
                ViewState["key"] = null;
                key.Value = "";
                fnFillLevel("load");
                xrow.Text = zglobal.GetMaximumIdInt("xrow", "glmstd").ToString();
                fnFillDataGrid();
                btnClear.Style.Value = zglobal.btncolor;
                zglobal.ltZbusinessGlmst.Clear();
                zglobal.ltZbusinessGlmstPermis.Clear();
                zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid2 IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {
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
                    if (xeffdt.Text == "" || xeffdt.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Account Effected Date";
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
                                    "SELECT * FROM glmsth WHERE xacc=@xacc";
                                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                                da.SelectCommand.Parameters.AddWithValue("@xacc",xacc.Text.ToString().Trim());
                                //DataTable tempTable = new DataTable();
                                da.Fill(dts, "tempTable");
                                tempTable = dts.Tables["tempTable"];
                            }
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO glmsth (xacc) " +
                                           "VALUES(@xacc) ";
                            string xacc1 = xacc.Text.ToString().Trim();
                            int zactive1 = zactive.Checked ? 1 : 0;
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xacc", xacc1);
                            //cmd.Parameters.AddWithValue("@zactive", zactive1);
                            if (tempTable.Rows.Count <= 0)
                            {
                                cmd.ExecuteNonQuery(); 
                            }
                            
                            //Insert data into glmstd
                            cmd.Parameters.Clear();
                            query = "INSERT INTO glmstd (ztime,xrow,xacc,xeffdt,xdesc,xacctype,xaccusage,xaccsource,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,xspaccgp,xcf1,zemail,zactive) " +
                                           "VALUES(@ztime,@xrow,@xacc,@xeffdt,@xdesc,@xacctype,@xaccusage,@xaccsource,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xhrc5,@xspaccgp,@xcf1,@zemail,@zactive) ";
                            DateTime ztime = DateTime.Now;
                            int xrow1 = zglobal.GetMaximumIdInt("xrow","glmstd");
                            //string xacc1 = xacc.Text.ToString().Trim();
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string xdesc1 = xdesc.Text.ToString().Trim();
                            string xacctype1;
                            if (Asset.Checked)
                                xacctype1 = "Asset";
                            else if (Expenditure.Checked)
                                xacctype1 = "Expenditure";
                            else if (Income.Checked)
                                xacctype1 = "Income";
                            else
                                xacctype1 = "Liability";
                            string xaccusage1;
                            if (AP.Checked)
                                xaccusage1 = "AP";
                            else if (AR.Checked)
                                xaccusage1 = "AR";
                            else if (Bank.Checked)
                                xaccusage1 = "Bank";
                            else if (Cash.Checked)
                                xaccusage1 = "Cash";
                            else
                                xaccusage1 = "Ledger";
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
                            else
                                xaccsource1 = "None";
                            string xhrc11 = xhrc1.Text.ToString().Trim() == "[Select]" ? "" : xhrc1.Text.ToString().Trim();
                            string xhrc22 = xhrc2.Text.ToString().Trim() == "[Select]" ? "" : xhrc2.Text.ToString().Trim();
                            string xhrc33 = xhrc3.Text.ToString().Trim() == "[Select]" ? "" : xhrc3.Text.ToString().Trim();
                            string xhrc44 = xhrc4.Text.ToString().Trim() == "[Select]" ? "" : xhrc4.Text.ToString().Trim();
                            string xhrc55 = xhrc5.Text.ToString().Trim() == "[Select]" ? "" : xhrc5.Text.ToString().Trim();
                            string xspaccgp1 = "";
                            string xcf11 = "";
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]); 
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@ztime", ztime);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xacc", xacc1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                            cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                            cmd.Parameters.AddWithValue("@xaccusage", xaccusage1);
                            cmd.Parameters.AddWithValue("@xaccsource", xaccsource1);
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc22);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc33);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc44);
                            cmd.Parameters.AddWithValue("@xhrc5", xhrc55);
                            cmd.Parameters.AddWithValue("@xspaccgp", xspaccgp1);
                            cmd.Parameters.AddWithValue("@xcf1", xcf11);
                            cmd.Parameters.AddWithValue("@zemail", zemail1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            int xflag;
                            //Insert into glmstbiz
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "glmstbiz");
                                xhrc11 = "";
                                xhrc22 = "";
                                xhrc33 = "";
                                xhrc44 = "";
                                xhrc55 = "";
                                if (zid["xst2"].ToString() == "1")
                                {
                                    xflag = 1;
                                    xhrc11 = zid["xhrc12"].ToString();
                                    xhrc22 = zid["xhrc22"].ToString();
                                    xhrc33 = zid["xhrc32"].ToString();
                                    xhrc44 = zid["xhrc42"].ToString();
                                    xhrc55 = zid["xhrc52"].ToString();
                                }
                                else
                                {
                                    xflag = 0;
                                }
                                query = "INSERT INTO glmstbiz (xrow,xrowglmstd,zid,xacc,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,xflag) " +
                                           "VALUES(@xrow,@xrowglmstd,@zid,@xacc,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xhrc5,@xflag) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowglmstd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid2"]);
                                cmd.Parameters.AddWithValue("@xacc", xacc1);
                                cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                                cmd.Parameters.AddWithValue("@xhrc2", xhrc22);
                                cmd.Parameters.AddWithValue("@xhrc3", xhrc33);
                                cmd.Parameters.AddWithValue("@xhrc4", xhrc44);
                                cmd.Parameters.AddWithValue("@xhrc5", xhrc55);
                                cmd.Parameters.AddWithValue("@xflag", xflag);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());

                        

                        fnFillDataGrid();
                        zemail.Text = HttpContext.Current.Session["curuser"].ToString();
                        tran.Complete();

                    }
                    msg.InnerHtml = "Add comlpeted";
                    msg.Style.Value = zglobal.successmsg;
                    btnAdd.Style.Value = zglobal.btncolor;
                    fnButtonFace("save");
                    ViewState["key"] = xrow.Text.ToString();
                    key.Value = xrow.Text.ToString();
                }
                else
                {
                    msg.InnerHtml = "There is no business select yet. Cann't [Add]";
                    msg.Style.Value = zglobal.errormsg;
                    btnAdd.Style.Value = zglobal.btnerr;
                }
                
                
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
                DataTable tbl = zglobal.fnCheckBusiness("SELECT * FROM ztemporary WHERE zid2 IS NOT NULL and zemail=@zemail and xsession=@xsession");
                if (tbl.Rows.Count > 0)
                {
                    //if (xacc.Text == "" || xacc.Text == string.Empty)
                    //{
                    //    msg.InnerHtml = "Enter Account Code";
                    //    msg.Style.Value = zglobal.warningmsg;
                    //    btnAdd.Style.Value = zglobal.btnerr;
                    //    return;
                    //}
                    if (xdesc.Text == "" || xdesc.Text == string.Empty)
                    {
                        msg.InnerHtml = "Enter Account Description";
                        msg.Style.Value = zglobal.warningmsg;
                        btnUpdate.Style.Value = zglobal.btnerr;
                        return;
                    }
                    //if (xeffdt.Text == "" || xeffdt.Text == string.Empty)
                    //{
                    //    msg.InnerHtml = "Enter Account Effected Date";
                    //    msg.Style.Value = zglobal.warningmsg;
                    //    btnAdd.Style.Value = zglobal.btnerr;
                    //    return;
                    //}
                    using (TransactionScope tran = new TransactionScope())
                    {
                        using (SqlConnection conn = new SqlConnection(zglobal.constring))
                        {
                            conn.Open();
                            //Insert data into glmsth
                            //Check header tavle duplicate entry
                            //DataTable tempTable = new DataTable();
                            //using (DataSet dts = new DataSet())
                            //{
                            //    string query1 =
                            //        "SELECT * FROM glmsth WHERE xacc=@xacc";
                            //    SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                            //    da.SelectCommand.Parameters.AddWithValue("@xacc", xacc.Text.ToString().Trim());
                            //    //DataTable tempTable = new DataTable();
                            //    da.Fill(dts, "tempTable");
                            //    tempTable = dts.Tables["tempTable"];
                            //}
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string query = "INSERT INTO glmsth (xacc) " +
                                           "VALUES(@xacc) ";
                            string xacc1 = xacc.Text.ToString().Trim();
                            int zactive1 = zactive.Checked ? 1 : 0;
                            //cmd.CommandText = query;
                            //cmd.Parameters.AddWithValue("@xacc", xacc1);
                            ////cmd.Parameters.AddWithValue("@zactive", zactive1);
                            //if (tempTable.Rows.Count <= 0)
                            //{
                            //    cmd.ExecuteNonQuery();
                            //}

                            //Insert data into glmstd
                            cmd.Parameters.Clear();
                            //query = "INSERT INTO glmstd (ztime,xrow,xacc,xeffdt,xdesc,xacctype,xaccusage,xaccsource,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,xspaccgp,xcf1,zemail,zactive) " +
                            //               "VALUES(@ztime,@xrow,@xacc,@xeffdt,@xdesc,@xacctype,@xaccusage,@xaccsource,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xhrc5,@xspaccgp,@xcf1,@zemail,@zactive) ";
                            query = "UPDATE glmstd SET zutime=@zutime,xdesc=@xdesc,xacctype=@xacctype,xaccusage=@xaccusage,xaccsource=@xaccsource,xhrc1=@xhrc1,xhrc2=@xhrc2,xhrc3=@xhrc3,xhrc4=@xhrc4,xhrc5=@xhrc5,xspaccgp=@xspaccgp,xcf1=@xcf1,xemail=@xemail,zactive=@zactive " +
                                           "WHERE xrow=@xrow ";
                            DateTime ztime = DateTime.Now;
                            //int xrow1 = zglobal.GetMaximumIdInt("xrow", "glmstd");
                            int xrow1 = Int32.Parse(xrow.Text.ToString().Trim());
                            //string xacc1 = xacc.Text.ToString().Trim();
                            DateTime xeffdt1 = Convert.ToDateTime(xeffdt.Text.ToString().Trim());
                            string xdesc1 = xdesc.Text.ToString().Trim();
                            string xacctype1;
                            if (Asset.Checked)
                                xacctype1 = "Asset";
                            else if (Expenditure.Checked)
                                xacctype1 = "Expenditure";
                            else if (Income.Checked)
                                xacctype1 = "Income";
                            else
                                xacctype1 = "Liability";
                            string xaccusage1;
                            if (AP.Checked)
                                xaccusage1 = "AP";
                            else if (AR.Checked)
                                xaccusage1 = "AR";
                            else if (Bank.Checked)
                                xaccusage1 = "Bank";
                            else if (Cash.Checked)
                                xaccusage1 = "Cash";
                            else
                                xaccusage1 = "Ledger";
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
                            else
                                xaccsource1 = "None";
                            string xhrc11 = xhrc1.Text.ToString().Trim() == "[Select]" ? "" : xhrc1.Text.ToString().Trim();
                            string xhrc22 = xhrc2.Text.ToString().Trim() == "[Select]" ? "" : xhrc2.Text.ToString().Trim();
                            string xhrc33 = xhrc3.Text.ToString().Trim() == "[Select]" ? "" : xhrc3.Text.ToString().Trim();
                            string xhrc44 = xhrc4.Text.ToString().Trim() == "[Select]" ? "" : xhrc4.Text.ToString().Trim();
                            string xhrc55 = xhrc5.Text.ToString().Trim() == "[Select]" ? "" : xhrc5.Text.ToString().Trim();
                            string xspaccgp1 = "";
                            string xcf11 = "";
                            string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@zutime", ztime);
                            cmd.Parameters.AddWithValue("@xrow", xrow1);
                            cmd.Parameters.AddWithValue("@xacc", xacc1);
                            cmd.Parameters.AddWithValue("@xeffdt", xeffdt1);
                            cmd.Parameters.AddWithValue("@xdesc", xdesc1);
                            cmd.Parameters.AddWithValue("@xacctype", xacctype1);
                            cmd.Parameters.AddWithValue("@xaccusage", xaccusage1);
                            cmd.Parameters.AddWithValue("@xaccsource", xaccsource1);
                            cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                            cmd.Parameters.AddWithValue("@xhrc2", xhrc22);
                            cmd.Parameters.AddWithValue("@xhrc3", xhrc33);
                            cmd.Parameters.AddWithValue("@xhrc4", xhrc44);
                            cmd.Parameters.AddWithValue("@xhrc5", xhrc55);
                            cmd.Parameters.AddWithValue("@xspaccgp", xspaccgp1);
                            cmd.Parameters.AddWithValue("@xcf1", xcf11);
                            cmd.Parameters.AddWithValue("@xemail", zemail1);
                            cmd.Parameters.AddWithValue("@zactive", zactive1);
                            cmd.ExecuteNonQuery();
                            int xrow2;
                            int xflag;


                            //Insert into glmstbiz
                            cmd.Parameters.Clear();
                            query = "DELETE FROM glmstbiz where xrowglmstd=@xrowglmstd";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@xrowglmstd", xrow1);
                            cmd.ExecuteNonQuery();
                            foreach (DataRow zid in tbl.Rows)
                            {
                                cmd.Parameters.Clear();
                                xrow2 = zglobal.GetMaximumIdInt("xrow", "glmstbiz");
                                xhrc11 = "";
                                xhrc22 = "";
                                xhrc33 = "";
                                xhrc44 = "";
                                xhrc55 = "";
                                if (zid["xst2"].ToString() == "1")
                                {
                                    xflag = 1;
                                    xhrc11 = zid["xhrc12"].ToString();
                                    xhrc22 = zid["xhrc22"].ToString();
                                    xhrc33 = zid["xhrc32"].ToString();
                                    xhrc44 = zid["xhrc42"].ToString();
                                    xhrc55 = zid["xhrc52"].ToString();
                                }
                                else
                                {
                                    xflag = 0;
                                }
                                query = "INSERT INTO glmstbiz (xrow,xrowglmstd,zid,xacc,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,xflag) " +
                                           "VALUES(@xrow,@xrowglmstd,@zid,@xacc,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xhrc5,@xflag) ";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@xrow", xrow2);
                                cmd.Parameters.AddWithValue("@xrowglmstd", xrow1);
                                cmd.Parameters.AddWithValue("@zid", zid["zid2"]);
                                cmd.Parameters.AddWithValue("@xacc", xacc1);
                                cmd.Parameters.AddWithValue("@xhrc1", xhrc11);
                                cmd.Parameters.AddWithValue("@xhrc2", xhrc22);
                                cmd.Parameters.AddWithValue("@xhrc3", xhrc33);
                                cmd.Parameters.AddWithValue("@xhrc4", xhrc44);
                                cmd.Parameters.AddWithValue("@xhrc5", xhrc55);
                                cmd.Parameters.AddWithValue("@xflag", xflag);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        zglobal.ltZbusinessGlmst.Clear();
                        zglobal.ltZbusinessGlmstPermis.Clear();
                        zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());



                        fnFillDataGrid();
                        xemail.Text = HttpContext.Current.Session["curuser"].ToString();
                        tran.Complete();

                    }
                    msg.InnerHtml = "Update comlpeted";
                    msg.Style.Value = zglobal.successmsg;
                    btnUpdate.Style.Value = zglobal.btncolor;
                    fnButtonFace("save");
                    ViewState["key"] = xrow.Text.ToString();
                    key.Value = xrow.Text.ToString();
                }
                else
                {
                    msg.InnerHtml = "There is no business select yet. Cann't [Update]";
                    msg.Style.Value = zglobal.errormsg;
                    btnUpdate.Style.Value = zglobal.btnerr;
                }


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
                zglobal.ltZbusinessGlmst.Clear();
                zglobal.ltZbusinessGlmstPermis.Clear();
                zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                
            }
            catch (Exception exp)
            {

                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        private void fnFillLevel(string flag)
        {
            try
            {
                string cs = zglobal.constring;

                if (flag == "load")
                {
                    xhrc1.Items.Clear();
                    xhrc1.Items.Add("[Select]");
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string query = "SELECT xhrc1 FROM glhrc11";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
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
                        string query = "SELECT xhrc2 FROM glhrc21 WHERE xhrc1=@xhrc1";
                        SqlCommand cmd = new SqlCommand(query, con);
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
                        string query = "SELECT xhrc3 FROM glhrc31 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2";
                        SqlCommand cmd = new SqlCommand(query, con);
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
                        string query = "SELECT xhrc4 FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3";
                        SqlCommand cmd = new SqlCommand(query, con);
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
                        string query = "SELECT xhrc5 FROM glhrc51 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
                        SqlCommand cmd = new SqlCommand(query, con);
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
                //msg.InnerHtml = "City : " + ((LinkButton)sender).Text;
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xrow1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM glmstd WHERE xrow=@xrow";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xrow", ((LinkButton)sender).Text);
                da.Fill(dts, "tempztcode");
                DataTable dtztcode = new DataTable();
                dtztcode = dts.Tables[0];

                xrow.Text = ((LinkButton) sender).Text;
                xacc.Text = dtztcode.Rows[0]["xacc"].ToString();
                xdesc.Text = dtztcode.Rows[0]["xdesc"].ToString();

                string xacctype1 = dtztcode.Rows[0]["xacctype"].ToString();
                //msg.InnerHtml = xacctype1;
                if (xacctype1 == "Asset")
                {
                    Asset.Checked = true;
                    UpdatePanel12.Update();
                }
                else if (xacctype1 == "Expenditure")
                {
                    Expenditure.Checked = true;
                    UpdatePanel19.Update();
                }
                else if (xacctype1 == "Income")
                {
                    Income.Checked = true;
                    UpdatePanel20.Update();
                }
                else
                {
                    Liability.Checked = true;
                    UpdatePanel21.Update();
                }

                string xaccusage1 = dtztcode.Rows[0]["xaccusage"].ToString();
                if (xaccusage1 == "AP")
                {
                    AP.Checked = true;
                    UpdatePanel22.Update();
                }
                else if (xaccusage1 == "AR")
                {
                    AR.Checked = true;
                    UpdatePanel23.Update();
                }
                else if (xaccusage1 == "Bank")
                {
                    Bank.Checked = true;
                    UpdatePanel24.Update();
                }
                else if (xaccusage1 == "Cash")
                {
                    Cash.Checked = true;
                    UpdatePanel25.Update();
                }
                else
                {
                    Ledger.Checked = true;
                    UpdatePanel3.Update();
                }

                string xaccsource1 = dtztcode.Rows[0]["xaccsource"].ToString();
                if (xaccsource1 == "Customer")
                {
                    Customer.Checked = true;
                    UpdatePanel26.Update();
                }
                else if (xaccsource1 == "Supplier")
                {
                    Supplier.Checked = true;
                    UpdatePanel29.Update();
                }
                else if (xaccsource1 == "Employee")
                {
                    Employee.Checked = true;
                    UpdatePanel27.Update();
                }
                else if (xaccsource1 == "Subaccount")
                {
                    Subaccount.Checked = true;
                    UpdatePanel28.Update();
                }
                else if (xaccsource1 == "Bank")
                {
                    Bank1.Checked = true;
                    UpdatePanel30.Update();
                }
                else
                {
                    None.Checked = true;
                    UpdatePanel14.Update();
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
                xeffdt.Text = Convert.ToDateTime(dtztcode.Rows[0]["xeffdt"].ToString()).ToShortDateString();
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
                UpdatePanel5.Update();
                UpdatePanel10.Update();
                UpdatePanel11.Update();
                UpdatePanel4.Update();
                UpdatePanel6.Update();
                UpdatePanel7.Update();
                UpdatePanel8.Update();
                UpdatePanel15.Update();
                UpdatePanel16.Update();
                UpdatePanel17.Update();
                UpdatePanel18.Update();
                UpdatePanel13.Update();
                UpdatePanel31.Update();
                
                zglobal.fnDeleteBusinessGLMSTPermis(HttpContext.Current.Session["curuser"].ToString(), HttpContext.Current.Session.SessionID.ToString());
                
                //fnFillDataGrid();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
                msg.Style.Value = zglobal.errormsg;
            }
        }

        public void fnFillDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xrow,xacc,xdesc,xacctype,xaccsource,xeffdt,zactive FROM glmstd ORDER BY xacc,xeffdt";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempztcode");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztcode = new DataTable();
            dtztcode = dts.Tables[0];
            GridView2.DataSource = dtztcode;
            GridView2.DataBind();




            dts.Dispose();
            dtztcode.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        

        
        
    }
}