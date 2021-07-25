using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace OnlineTicketingSystem
{
    /// <summary>
    /// Summary description for soudia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class soudia : System.Web.Services.WebService
    {

        [WebMethod]
        public void Level1()
        {
            string cs = zglobal.constring;
            List<xhrc1> xhrc1List = new List<xhrc1>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT xhrc1 FROM glhrc11";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    xhrc1 objhrc = new xhrc1();
                    objhrc.xhrc11 = rdr["xhrc1"].ToString();
                    objhrc.value = rdr["xhrc1"].ToString();
                    xhrc1List.Add(objhrc);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(xhrc1List));
        }

        [WebMethod]
        public void Level2(string xhrc1)
        {
            string cs = zglobal.constring;
            List<xhrc2> xhrc2List = new List<xhrc2>();
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
                    xhrc2 objhrc = new xhrc2();
                    objhrc.xhrc22 = rdr["xhrc2"].ToString();
                    objhrc.value = rdr["xhrc2"].ToString();
                    xhrc2List.Add(objhrc);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(xhrc2List));
        }

        [WebMethod]
        public void Level3(string xhrc1, string xhrc2)
        {
            string cs = zglobal.constring;
            List<xhrc3> xhrc3List = new List<xhrc3>();
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
                    xhrc3 objhrc = new xhrc3();
                    objhrc.xhrc33 = rdr["xhrc3"].ToString();
                    objhrc.value = rdr["xhrc3"].ToString();
                    xhrc3List.Add(objhrc);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(xhrc3List));
        }

        [WebMethod]
        public void Level4(string xhrc1, string xhrc2, string xhrc3)
        {
            string cs = zglobal.constring;
            List<xhrc4> xhrc4List = new List<xhrc4>();
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
                    xhrc4 objhrc = new xhrc4();
                    objhrc.xhrc44 = rdr["xhrc4"].ToString();
                    objhrc.value = rdr["xhrc4"].ToString();
                    xhrc4List.Add(objhrc);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(xhrc4List));
        }

        [WebMethod]
        public void Level5(string xhrc1, string xhrc2, string xhrc3, string xhrc4)
        {
            string cs = zglobal.constring;
            List<xhrc5> xhrc5List = new List<xhrc5>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT xhrc4 FROM glhrc41 WHERE xhrc1=@xhrc1 and xhrc2=@xhrc2 and xhrc3=@xhrc3 and xhrc4=@xhrc4";
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
                    xhrc5 objhrc = new xhrc5();
                    objhrc.xhrc55 = rdr["xhrc5"].ToString();
                    objhrc.value = rdr["xhrc5"].ToString();
                    xhrc5List.Add(objhrc);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(xhrc5List));
        }



    }
}
