using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace OnlineTicketingSystem.forms
{
    public partial class ztsequence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                populateDataGrid();

                if (!IsPostBack)
                {

                    rtcount.Value = "";

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    DataSet dts = new DataSet();
                    dts.Reset();

                    string str = "SELECT (xmf + '-' + xmt) as mainrt, xmrid FROM ztrtm WHERE zactive=1 AND xhsub=1";

                    SqlDataAdapter da2 = new SqlDataAdapter(str, conn1);
                    da2.Fill(dts, "tempdtrtm");
                    DataTable dtrtm = new DataTable();
                    dtrtm = dts.Tables[0];

                    if (dtrtm.Rows.Count > 0)
                    {
                        xmainrt.Items.Add("[Select]");
                        for (int i = 0; i < dtrtm.Rows.Count; i++)
                        {
                            xmainrt.Items.Add(new ListItem(dtrtm.Rows[i][0].ToString(), dtrtm.Rows[i][1].ToString()));
                        }
                        xmainrt.Text = "[Select]";
                    }





                }
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }

            fnCrCtl();
        }

        protected void FillControls(object sender, EventArgs e)
        {

        }

        protected void populateDataGrid()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();


            dts.Reset();
            string str = "select xmrid,(select xmf+'-'+xmt from ztrtm where ztrtm.xmrid=ztsequence.xmrid) as xmrt,(xroute+'-'+cast(xseq as varchar))as xsequence,xstatus  from ztsequence order by xmrid,xseq";
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

        protected void xmainrt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn1;
                conn1 = new SqlConnection(zglobal.constring);
                DataSet dts = new DataSet();


                dts.Reset();
                string str = "select xstatus from ztsequence where xmrid=@xmrid";
                SqlDataAdapter da = new SqlDataAdapter(str, conn1);
                string xmrid1 = xmainrt.SelectedItem.Value;
                da.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
                da.Fill(dts, "temp");
                //DataView dv = new DataView(dts.Tables[0]);
                DataTable dtztemp = new DataTable();
                dtztemp = dts.Tables[0];
                if (dtztemp.Rows.Count > 0)
                {
                    if (dtztemp.Rows[0][0].ToString() == "Confirm")
                    {
                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                PlaceHolder1.Controls.Clear();
                fnCrCtl();
            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void fnCrCtl()
        {

            if (xmainrt.SelectedItem.Text == "[Select]")
            {
                return;
            }

            string[] mrid = xmainrt.SelectedItem.Text.ToString().Split('-');

            string xmf1 = mrid[0];
            string xmt1 = mrid[1];


            SqlConnection conn;
            conn = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            string str = "select xsf,xst from ztrts where xmrid=@xmrid";

            string xmrid1 = xmainrt.SelectedItem.Value;
            //msg.InnerHtml = xmrid1;

            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            da.SelectCommand.Parameters.AddWithValue("@xmrid", xmrid1);
            dts.Reset();
            da.Fill(dts, "tempdtrt");

            DataTable ztrt = new DataTable();
            ztrt = dts.Tables[0];

            DropDownList mydw = new DropDownList();
            Label mylabel = new Label();
            mylabel.Text = xmf1;
            mylabel.ID = "label1";

            //mydw.Items.Clear();
            mydw.Items.Add("1");
            mydw.ID = "dw1";

            PlaceHolder1.Controls.Add(new LiteralControl("<table>"));

            PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

            PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
            PlaceHolder1.Controls.Add(mylabel);
            PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

            PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
            PlaceHolder1.Controls.Add(mydw);
            PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

            PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

            List<string> rt = new List<string>();
            int rowct = 0;

            if (ztrt.Rows.Count > 0)
            {
                rtcount.Value = ztrt.Rows.Count.ToString();

                for (int i = 0; i < ztrt.Rows.Count; i++)
                {
                    rt.Add(ztrt.Rows[i][0].ToString());
                    rt.Add(ztrt.Rows[i][1].ToString());
                }

                List<string> distinct = rt.Distinct().ToList();
                rowct = distinct.Count;

                List<string> subrt = new List<string>();

                foreach (string value in distinct)
                {
                    if (value != xmf1 && value != xmt1)
                    {

                        //PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

                        //PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        //PlaceHolder1.Controls.Add(new LiteralControl(value));
                        //PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                        //PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                        //PlaceHolder1.Controls.Add(new LiteralControl("null"));
                        //PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                        //PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));
                        subrt.Add(value);
                    }
                    else
                    {
                        rowct = rowct - 1;
                    }

                }


                int ct = 2;
                int cid = 2;
                foreach (string value in subrt)
                {


                    DropDownList mydw2 = new DropDownList();
                    for (int i = 0; i < subrt.Count; i++)
                    {

                        //mydw2.Items.Clear();
                        mydw2.Items.Add(ct.ToString());

                        ct = ct + 1;
                    }
                    mydw2.ID = "dw" + cid.ToString();
                    //re initialize ct

                    Label mylabel2 = new Label();
                    mylabel2.Text = value;
                    mylabel2.ID = "label" + cid.ToString();

                    ct = 2;
                    cid = cid + 1;


                    PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

                    PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                    PlaceHolder1.Controls.Add(mylabel2);
                    PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                    PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
                    PlaceHolder1.Controls.Add(mydw2);
                    PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

                    PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

                }


            }


            string rowcount = Convert.ToString(rowct + 2);
            rowcount123.Value = rowcount;

            DropDownList mydw1 = new DropDownList();
            mydw1.Items.Clear();
            mydw1.Items.Add(rowcount);
            mydw1.ID = "dw" + rowcount;

            Label mylabel3 = new Label();
            mylabel3.Text = xmt1;
            mylabel3.ID = "label" + rowcount;

            PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

            PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
            PlaceHolder1.Controls.Add(mylabel3);
            PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

            PlaceHolder1.Controls.Add(new LiteralControl("<td>"));
            PlaceHolder1.Controls.Add(mydw1);
            PlaceHolder1.Controls.Add(new LiteralControl("</td>"));

            PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

            PlaceHolder1.Controls.Add(new LiteralControl("</table>"));


        }

        private void saveAndUpdate(string str)
        {

            using (TransactionScope tran = new TransactionScope())
            {

                SqlConnection conn1;
                SqlCommand dataCmd;
                conn1 = new SqlConnection(zglobal.constring);
                dataCmd = new SqlCommand();
                dataCmd.Connection = conn1;
                string query;

                if (str == "save")
                {
                    query = "INSERT INTO ztsequence" +
                                   "(xrow,xmrid,xroute,xseq,xcreatedby,xcreatedt,xloc,xstatus) " +
                                   "VALUES (@xrow,@xmrid,@xroute,@xseq,@xcreatedby,@xcreatedt,@xloc,'New') ";
                }
                else if (str == "update")
                {

                    query = "UPDATE ztsequence SET " +
                                          "xroute=@xroute,xseq=@xseq,xupdby=@xupdby,xupdt=@xupdt,xuploc=@xuploc " +
                                          "WHERE xmrid=@xmrid";

                }
                else if (str == "confirm")
                {

                    query = "UPDATE ztsequence SET " +
                                          "xstatus='Confirm',xupdby=@xupdby,xupdt=@xupdt,xuploc=@xuploc " +
                                          "WHERE xmrid=@xmrid";

                }
                else
                {
                    query = "DELETE FROM ztsequence WHERE xmrid=@xmrid";
                }


                dataCmd.CommandText = query;

                conn1.Close();
                conn1.Open();
                if (str == "delete" || str == "confirm")
                {
                    string xmrid1 = xmainrt.SelectedItem.Value;
                    string xupdby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    DateTime xupdt1 = DateTime.Now;
                    string xuploc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);
                    dataCmd.Parameters.AddWithValue("@xupdby", xupdby1);
                    dataCmd.Parameters.AddWithValue("@xupdt", xupdt1);
                    dataCmd.Parameters.AddWithValue("@xuploc", xuploc1);

                    dataCmd.ExecuteNonQuery();
                }
                else
                {
                    for (int i = 1; i <= Convert.ToInt32(rowcount123.Value); i++)
                    {
                        dataCmd.Parameters.Clear();

                        if (str == "save")
                        {
                            string xrow1 = zglobal.fnmaxid("SELECT max(xrow) FROM ztsequence where getdate() between @firstdate and @lastdate");
                            dataCmd.Parameters.AddWithValue("@xrow", xrow1);
                        }
                        string xmrid1 = xmainrt.SelectedItem.Value;
                        string xroute1 = ((Label)PlaceHolder1.FindControl("label" + i)).Text.ToString();
                        string xseq1 = Convert.ToString(((DropDownList)PlaceHolder1.FindControl("dw" + i)).SelectedItem.Text);
                        string xcreatedby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xcreatedt1 = DateTime.Now;
                        string xloc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);
                        string xupdby1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                        DateTime xupdt1 = DateTime.Now;
                        string xuploc1 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                        
                        dataCmd.Parameters.AddWithValue("@xmrid", xmrid1);
                        dataCmd.Parameters.AddWithValue("@xroute", xroute1);
                        dataCmd.Parameters.AddWithValue("@xseq", xseq1);
                        dataCmd.Parameters.AddWithValue("@xcreatedby", xcreatedby1);
                        dataCmd.Parameters.AddWithValue("@xcreatedt", xcreatedt1);
                        dataCmd.Parameters.AddWithValue("@xloc", xloc1);
                        dataCmd.Parameters.AddWithValue("@xupdby", xupdby1);
                        dataCmd.Parameters.AddWithValue("@xupdt", xupdt1);
                        dataCmd.Parameters.AddWithValue("@xuploc", xuploc1);

                        dataCmd.ExecuteNonQuery();

                    }
                }

                conn1.Close();

                tran.Complete();
            }

            //-------------------------------------------------//
            populateDataGrid();

            //-------------------------------------------------//


            if (str == "save")
            {
                msg.InnerText = "Successfully add data.";
                //msg.InnerHtml = Convert.ToString(dtztcc.Rows.Count);
            }
            else if (str == "update")
            {
                msg.InnerText = "Successfully update data.";
            }
            else if (str == "confirm")
            {
                msg.InnerText = "Successfully Confirm.";
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                msg.InnerText = "Successfully delete data.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            xmainrt.Text = "[Select]";
            PlaceHolder1.Controls.Clear();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            msg.InnerHtml = "";
        }

        string pk;

        private void checkpk()
        {
            SqlConnection conn1;
            conn1 = new SqlConnection(zglobal.constring);
            DataSet dts = new DataSet();

            dts.Reset();
            string str = "SELECT xmrid FROM ztsequence ";
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
                    if (dtztemp.Rows[i][0].ToString().Trim() == xmainrt.SelectedItem.Value)
                    {
                        pk = dtztemp.Rows[i][0].ToString();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (xmainrt.Text == "[Select]")
                {
                    msg.InnerHtml = "Please Select Main Route.";
                    return;
                }

                checkpk();
                if (pk != "false")
                {
                    msg.InnerHtml = "Cann't insert duplicate data. Please try again";

                }
                else
                {

                    saveAndUpdate("save");

                }

            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (xmainrt.Text == "[Select]")
            //    {
            //        msg.InnerHtml = "Please Select Main Route.";
            //        return;
            //    }

            //    checkpk();
            //    if (pk == "false")
            //    {
            //        msg.InnerHtml = "Data not found";

            //    }
            //    else
            //    {

            //        saveAndUpdate("update");

            //    }

            //}
            //catch (Exception exp)
            //{
            //    msg.InnerHtml = exp.Message;
            //}
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtconformmessageValue.Value == "Yes")
                {

                    if (xmainrt.Text == "[Select]")
                    {
                        msg.InnerHtml = "Please Select Main Route.";
                        return;
                    }

                    checkpk();
                    if (pk == "false")
                    {
                        msg.InnerHtml = "Data not found";

                    }
                    else
                    {

                        saveAndUpdate("delete");

                    }

                }


            }
            catch (Exception exp)
            {
                msg.InnerHtml = exp.Message;
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (comfirmmsg.Value == "Yes")
                {

                    if (xmainrt.Text == "[Select]")
                    {
                        msg.InnerHtml = "Please Select Main Route.";
                        return;
                    }
                    checkpk();
                    if (pk == "false")
                    {
                        msg.InnerHtml = "Data not found";

                    }
                    else
                    {

                        saveAndUpdate("confirm");

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