using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineTicketingSystem.forms.sc
{
    public partial class ztroute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check Permission
                SiteMaster sm = new SiteMaster();
                string s = sm.fnChkPagePermis("ztroute");
                if (s == "n" || s== "e")
                {
                    HttpContext.Current.Session["curuser"] = null;
                    Session.Abandon();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                xmrid.Text = "";

                populateDataGrid();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                xmrid.Text = "";
                xmf.Text = "";
                xmt.Text = "";
                zactive.Checked = true;
                xhsub.Checked = false;
                xsf.Items.Clear();
                xst.Text = "";
                zactivesub.Checked = true;
                GridView2.DataSource = null;
                GridView2.DataBind();
                xsrid.Value = "";
                Panel2.Visible = false;
                btnaddsub.Text = "Add Sub";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }
        private int fnmaxrow()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT MAX(xmrid) FROM ztrtm";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);



            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];







            int maxrow;
            if (!Convert.IsDBNull(dttemp.Rows[0][0]))
            {
                int srtnm = int.Parse(dttemp.Rows[0][0].ToString());
                maxrow = srtnm + 1;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = 100;
            }


            da.Dispose();
            dts.Dispose();
            conn1.Dispose();

            return maxrow;

        }
        public void populateDataGrid()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT xmrid,xmf,xmt,zactive FROM ztrtm  ORDER BY xmrid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "temp");
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
                query = "INSERT INTO ztrtm" +
                               "(xmrid,xmf,xmt,zactive,xhsub) " +
                               "VALUES (@xmrid,@xmf,@xmt,@zactive,@xhsub) ";
            }
            else if (str == "update")
            {

                query = "UPDATE ztrtm SET " +
                                      "xmf=@xmf,xmt=@xmt,zactive=@zactive,xhsub=@xhsub " +
                                      "WHERE xmrid=@xmrid";

            }
            else
            {
                query = "";
            }
            dataCmd.CommandText = query;

            int xmrid1;
            if (str == "save")
            {
                xmrid1 = fnmaxrow();
                xmrid.Text = xmrid1.ToString();
            }
            else
            {
                xmrid1 = int.Parse(xmrid.Text);
            }



            dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);

            //if (str != "delete")
            //{


            string xmf1 = xmf.Text.ToString().Trim();
            string xmt1 = xmt.Text.ToString().Trim();


            int zactive1;
            if (zactive.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }

            int xhsub1;
            if (xhsub.Checked == true)
            {
                xhsub1 = 1;
            }
            else
            {
                xhsub1 = 0;
            }


            dataCmd.Parameters.AddWithValue("@xmf", xmf1);
            dataCmd.Parameters.AddWithValue("@xmt", xmt1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
            dataCmd.Parameters.AddWithValue("@xhsub", xhsub1);


            //}

            conn1.Close();
            conn1.Open();
            SqlTransaction transec = conn1.BeginTransaction("tran");
            dataCmd.Transaction = transec;

            try
            {

                dataCmd.ExecuteNonQuery();
               



                transec.Commit();
                conn1.Close();
               
            }
            catch(Exception exp)
            {
                msg.InnerHtml = exp.Message;
                transec.Rollback();
            }

            //if (xhsub1 == 1 && str == "update")
            //{
                

            //}

            //-------------------------------------------------//
            populateDataGrid();

            //-------------------------------------------------//

            dataCmd.Dispose();
            conn1.Dispose();
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
        string pk;
        string pksub;
        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xmf,xmt,xmrid FROM ztrtm ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            da.Fill(dts, "tempz");

            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];

            if (dtztemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtztemp.Rows.Count; i++)
                {
                    //for (int j = 0; j < 1; j++)
                    //{
                    if (dtztemp.Rows[i][0].ToString().Trim() == xmf.Text.ToString().Trim() && dtztemp.Rows[i][1].ToString().Trim() == xmt.Text.ToString().Trim())
                    {
                        pk = dtztemp.Rows[i][2].ToString();
                        //currow = i;
                        dts.Dispose();
                        dtztemp.Dispose();
                        da.Dispose();
                        conn1.Dispose();
                        return;
                    }
                    //}
                }
            }
            pk = "false";

            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        private void checkpksub()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xsf,xst,xsrid FROM ztrts WHERE xmrid=@xmrid ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
           // string xsrid1 = xsrid.Value.ToString();
            string xmrid1 = xmrid.Text.ToString();
            da.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
            da.Fill(dts, "tempz");

            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];

            if (dtztemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtztemp.Rows.Count; i++)
                {
                    //for (int j = 0; j < 1; j++)
                    //{
                    if (dtztemp.Rows[i][0].ToString().Trim() == xsf.Text.ToString().Trim() && dtztemp.Rows[i][1].ToString().Trim()==xst.Text.ToString().Trim())
                    {
                        pksub = dtztemp.Rows[i][2].ToString();
                        //currow = i;
                        dts.Dispose();
                        dtztemp.Dispose();
                        da.Dispose();
                        conn1.Dispose();
                        return;
                    }
                    //}
                }
            }
            pksub = "false";

            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xmf.Text != "" && xmt.Text != "")
                {
                    checkpk();

                    if (pk == "false")
                    {


                        saveAndUpdate("save");





                    }
                    else
                    {
                        string message = "Cann't Insert Duplicate Data";
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
                if (xmf.Text != "" && xmt.Text != "")
                {
                    checkpk();

                    if (pk != "false")
                    {


                        saveAndUpdate("update");





                    }
                    else
                    {
                        string message = "Unable to update data. Data Not found";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnaddsub_Click(object sender, EventArgs e)
        {
            try
            {
                msg.InnerText = "";
                if (xsf.Text != "" && xst.Text != "")
                {
                    checkpksub();

                    //if (pk == "false")
                    //{
                    if (btnaddsub.Text == "Update")
                    {
                        if (pksub != "false")
                        {
                            saveAndUpdate1("update");

                            SqlConnection conn1;
                            conn1 = new SqlConnection(zglobal.constring);
                            DataSet dts = new DataSet();

                            dts.Reset();
                            xsf.Items.Clear();

                            string str = "(select distinct frt from ztroute where mrt=@xmrid) " +
                                  " union " +
                                  " (select distinct trt from ztroute where mrt=@xmrid)";

                            SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                            string xmrid1 = xmrid.Text.ToString();
                            da1.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                            dts.Reset();
                            da1.Fill(dts, "tmp");

                            DataTable tbl = new DataTable();
                            tbl = dts.Tables[0];

                            if (tbl.Rows.Count > 0)
                            {
                                for (int i = 0; i < tbl.Rows.Count; i++)
                                {
                                    for (int j = 0; j < tbl.Columns.Count; j++)
                                    {
                                        xsf.Items.Add(tbl.Rows[i][j].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            string message = "Unable to update data. Data Not found";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                        }
                    }
                    else
                    {
                        if (pksub == "false")
                        {
                            saveAndUpdate1("save");

                            SqlConnection conn1;
                            conn1 = new SqlConnection(zglobal.constring);
                            DataSet dts = new DataSet();

                            dts.Reset();
                            xsf.Items.Clear();

                            string str = "(select distinct frt from ztroute where mrt=@xmrid) " +
                                  " union " +
                                  " (select distinct trt from ztroute where mrt=@xmrid)";

                            SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                            string xmrid1 = xmrid.Text.ToString();
                            da1.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                            dts.Reset();
                            da1.Fill(dts, "tmp");

                            DataTable tbl = new DataTable();
                            tbl = dts.Tables[0];

                            if (tbl.Rows.Count > 0)
                            {
                                for (int i = 0; i < tbl.Rows.Count; i++)
                                {
                                    for (int j = 0; j < tbl.Columns.Count; j++)
                                    {
                                        xsf.Items.Add(tbl.Rows[i][j].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            string message = "Can not insert duplicate data";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
                        }
                    }

                        





                    //}
                    //else
                    //{
                    //    string message = "Add data unsuccessfull. Because user you enter already exist into database. Please enter another.";
                    //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);

                    //    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                    //}
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

        public void populateDataGrid2()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT * FROM ztrts  WHERE xmrid=@xmrid ORDER BY xsrid";
            SqlDataAdapter da = new SqlDataAdapter(str, conn1);
            string xmrid1 = xmrid.Text.ToString();
            da.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
            da.Fill(dts, "temp");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dtztemp = new DataTable();
            dtztemp = dts.Tables[0];
            GridView2.DataSource = dtztemp;
            GridView2.DataBind();
            dts.Dispose();
            dtztemp.Dispose();
            da.Dispose();
            conn1.Dispose();
        }

        protected void FillControls(object sender, EventArgs e)
        {
            try
            {
                //msg.InnerHtml = "User : " + ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xmrid1 = ((LinkButton)sender).Text;


                string str = "SELECT * FROM ztrtm where xmrid=@xmrid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                da.Fill(dts, "temp");

                DataTable dtztrtm = new DataTable();
                dtztrtm = dts.Tables[0];

                xmrid.Text = dtztrtm.Rows[0][0].ToString();
                xmf.Text = dtztrtm.Rows[0][1].ToString();
                xmt.Text = dtztrtm.Rows[0][2].ToString();

                if ((int)dtztrtm.Rows[0][3] == 1)
                {
                    zactive.Checked = true;
                }
                else
                {
                    zactive.Checked = false;
                }

                if ((int)dtztrtm.Rows[0][4] == 1)
                {
                    xhsub.Checked = true;
                    Panel2.Visible = true;
                    populateDataGrid2();
                    xsrid.Value = "";
                    

                    xsf.Items.Clear();

                    str = "(select distinct frt from ztroute where mrt=@xmrid) " +
                          " union " +
                          " (select distinct trt from ztroute where mrt=@xmrid)";

                    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                    da1.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                    dts.Reset();
                    da1.Fill(dts, "tmp");

                    DataTable tbl = new DataTable();
                    tbl = dts.Tables[0];

                    if (tbl.Rows.Count > 0)
                    {
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            for (int j = 0; j < tbl.Columns.Count; j++)
                            {
                                xsf.Items.Add(tbl.Rows[i][j].ToString());
                            }
                        }
                    }

                }
                else
                {
                    xhsub.Checked = false;

                    Panel2.Visible = false;

                    xsf.Items.Clear();
                    xst.Text = "";
                    zactivesub.Checked = true;
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    xsrid.Value = "";
                }

                dts.Dispose();
                dtztrtm.Dispose();
                da.Dispose();
                conn1.Dispose();

                btnaddsub.Text = "Add Sub";
                xst.Text = "";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }


        protected void Edit(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkedit = sender as LinkButton;

                GridViewRow gvrow = (GridViewRow)lnkedit.NamingContainer;

                HiddenField theHiddenField = gvrow.FindControl("srid") as HiddenField;
                //msg.InnerHtml = "User : " + ((LinkButton)sender).Text;
                msg.InnerHtml = "";
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();

                dts.Reset();

                string xsrid1 = theHiddenField.Value;


                string str = "SELECT * FROM ztrts where xsrid=@xsrid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);

                da.SelectCommand.Parameters.AddWithValue("@xsrid", xsrid1);
                da.Fill(dts, "temp");

                DataTable dtztrtm = new DataTable();
                dtztrtm = dts.Tables[0];

                xsrid.Value = xsrid1;
             //   xsf.Text = dtztrtm.Rows[0][2].ToString();
                xst.Text = dtztrtm.Rows[0][3].ToString();

                if ((int)dtztrtm.Rows[0][4] == 1)
                {
                    zactivesub.Checked = true;
                }
                else
                {
                    zactivesub.Checked = false;
                }

                xsf.Items.Clear();

                str = "(select distinct frt from ztroute where mrt=@xmrid) " +
                                 " union " +
                                 " (select distinct trt from ztroute where mrt=@xmrid)";

                SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);
                string xmrid1 = xmrid.Text.ToString();
                da1.SelectCommand.Parameters.AddWithValue("@xmrid",xmrid1);
                //dts.Reset();
                da1.Fill(dts,"tmp");

                DataTable tbl = new DataTable();
                tbl=dts.Tables[1];

                if (tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        for (int j=0; j < tbl.Columns.Count; j++)
                        {
                            xsf.Items.Add(tbl.Rows[i][j].ToString());
                        }
                    }
                }

                xsf.Text = dtztrtm.Rows[0][2].ToString();
                dts.Dispose();
                dtztrtm.Dispose();
                da.Dispose();
                da1.Dispose();
                conn1.Dispose();

                btnaddsub.Text = "Update";
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }
        //protected void Edit(object sender, EventArgs e)
        //{
        //    LinkButton btndetails = sender as LinkButton;

        //    GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;


        //}

        protected void xhsub_CheckedChanged(object sender, EventArgs e)
        {
            if (xhsub.Checked == true)
            {
                if (xmrid.Text != "")
                {
                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);

                   string  query = "SELECT * FROM ztrts WHERE xmrid=@xmrid";
                    DataSet dts = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn1);
                    string xmrid1 = xmrid.Text.ToString();
                    da.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                    da.Fill(dts, "temp");
                    DataTable tb = new DataTable();
                    tb = dts.Tables[0];


                    //fill subroute 

                    xsf.Items.Clear();

                    string str = "(select distinct frt from ztroute where mrt=@xmrid) " +
                                 " union " +
                                 " (select distinct trt from ztroute where mrt=@xmrid)";

                    SqlDataAdapter da1 = new SqlDataAdapter(str, conn1);

                    da1.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                    dts.Reset();
                    da1.Fill(dts, "tmp");

                    DataTable tbl = new DataTable();
                    tbl = dts.Tables[0];


                    if (tbl.Rows.Count > 0)
                    {
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            for (int j = 0; j < tbl.Columns.Count; j++)
                            {
                                xsf.Items.Add(tbl.Rows[i][j].ToString());

                            }
                        }
                    }
                    /////////////////

                    if (tb.Rows.Count > 0)
                    {
                        populateDataGrid2();



                    }
                    Panel2.Visible = true;
                }
                else
                {
                    xhsub.Checked = false;
                    string message = "Please add main route first";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);

                }
            }
            else
            {
                Panel2.Visible = false;
            }
        }

        protected void xmf_TextChanged(object sender, EventArgs e)
        {
            //xsf.Items.Add(xmf.Text);
        }

        protected void xst_TextChanged(object sender, EventArgs e)
        {
            //xsf.Items.Add(xst.Text);
        }


        private void saveAndUpdate1(string str)
        {


            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            SqlCommand dataCmd = new SqlCommand();
           
            dataCmd.Connection = conn1;
            string query;
            if (str == "save")
            {
                query = "INSERT INTO ztrts" +
                               "(xsrid,xmrid,xsf,xst,zactive) " +
                               "VALUES (@xsrid,@xmrid,@xsf,@xst,@zactive) ";
            }
            else if (str == "update")
            {

                query = "UPDATE ztrts SET " +
                                      "xmrid=@xmrid,xsf=@xsf,xst=@xst,zactive=@zactive " +
                                      "WHERE xsrid=@xsrid";

            }
            else
            {
                query = "";
            }
            dataCmd.CommandText = query;

            int xsrid1;
            if (str == "save")
            {
                xsrid1 = fnmaxrow1();
                xsrid.Value = xsrid1.ToString();
                
            }
            else
            {
                xsrid1 = int.Parse(xsrid.Value);
            }



            dataCmd.Parameters.AddWithValue("@xsrid", xsrid1);

            //if (str != "delete")
            //{

            string xmrid1 = xmrid.Text.ToString();
            string xsf1 = xsf.Text.ToString().Trim();
            string xst1 = xst.Text.ToString().Trim();


            int zactive1;
            if (zactivesub.Checked == true)
            {
                zactive1 = 1;
            }
            else
            {
                zactive1 = 0;
            }



            dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);
            dataCmd.Parameters.AddWithValue("@xsf", xsf1);
            dataCmd.Parameters.AddWithValue("@xst", xst1);
            dataCmd.Parameters.AddWithValue("@zactive", zactive1);
           

             conn1.Close();
                conn1.Open();
                SqlTransaction transec = conn1.BeginTransaction("tran");
            //}
            try
            {
               
                dataCmd.Transaction = transec;

                dataCmd.ExecuteNonQuery();

                if (str == "save")
                {
                    string query1 = "UPDATE ztrtm SET " +
                                     "xhsub=@xhsub " +
                                     "WHERE xmrid=@xmrid";
                    int xhsub1 = 1;
                    dataCmd.CommandText = query1;
                    dataCmd.Parameters.AddWithValue("@xhsub",xhsub1);

                    dataCmd.ExecuteNonQuery();
                }

                transec.Commit();
                conn1.Close();
            }
            catch(Exception exp)
            {
                msg.InnerHtml = exp.Message;
                transec.Rollback();
            }

            //-------------------------------------------------//
            populateDataGrid2();

            //-------------------------------------------------//

            dataCmd.Dispose();
            conn1.Dispose();
            if (str == "save")
            {
                msg.InnerText = "Successfully add data.";
            }
            else if (str == "update")
            {
                msg.InnerText = "Successfully update data.";
                btnaddsub.Text = "Add Sub";
            }
            else
            {
                msg.InnerText = "Successfully delete data.";
            }

        }

        private int fnmaxrow1()
        {

            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "SELECT MAX(xsrid) FROM ztrts WHERE xmrid=@xmrid";

            SqlDataAdapter da = new SqlDataAdapter(str, conn1);

            string xmrid1 = xmrid.Text.ToString();
            da.SelectCommand.Parameters.AddWithValue("@xmrid",xmrid1);

            da.Fill(dts, "tempdt");
            //DataView dv = new DataView(dts.Tables[0]);
            DataTable dttemp = new DataTable();
            dttemp = dts.Tables[0];







            int maxrow;
            if (!Convert.IsDBNull(dttemp.Rows[0][0]))
            {
                int srtnm = int.Parse(dttemp.Rows[0][0].ToString());
                maxrow = srtnm + 1;
                //txtVoucherNo.Text = "";
            }
            else
            {
                string mxr = xmrid1 + "01";
                maxrow = int.Parse(mxr);
            }


            da.Dispose();
            dts.Dispose();
            conn1.Dispose();

            return maxrow;

        }
    }
}