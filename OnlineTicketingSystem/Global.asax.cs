using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using OnlineTicketingSystem.forms.sc;
using System.Data;
using System.Data.SqlClient;

namespace OnlineTicketingSystem
{
    public class Global : System.Web.HttpApplication
    {


        public static List<seatprocess> CurrentButtons = new List<seatprocess>();


        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            //if (HttpContext.Current.Session["curuser"] != null || HttpContext.Current.Session["curuser"] != "")
            //{
            //    SqlConnection conn1;
            //    conn1 = new SqlConnection(zglobal.constring);
            //    SqlCommand dataCmd = new SqlCommand();
            //    dataCmd.Connection = conn1;
            //    string query;

            //    query = "DELETE FROM ztcurseat WHERE xuser=@xuser";

            //    dataCmd.CommandText = query;

            //    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);

            //    dataCmd.Parameters.AddWithValue("@xuser", xuser1);


            //    conn1.Close();
            //    conn1.Open();
            //    dataCmd.ExecuteNonQuery();
            //    conn1.Close();

            //    dataCmd.Dispose();
            //    conn1.Dispose();
            //}


            //try
            //{

            //    fnDelCurSeat();

            //    //Build login history

            //    SqlConnection conn678;
            //    conn678 = new SqlConnection(zglobal.constring);
            //    SqlCommand dataCmd = new SqlCommand();
            //    dataCmd.Connection = conn678;
            //    string query;

            //    query = "UPDATE ztloginhis SET " +
            //                       "xlogout=@xlogout " +
            //                       "WHERE xuser=@xuser AND xlogin=(select max(xlogin) from ztloginhis where xuser=@xuser)";
            //    dataCmd.CommandText = query;

            //    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
            //    DateTime xlogout1 = DateTime.Now;



            //    dataCmd.Parameters.AddWithValue("@xuser", xuser1);

            //    dataCmd.Parameters.AddWithValue("@xlogout", xlogout1);

            //    conn678.Close();
            //    conn678.Open();
            //    dataCmd.ExecuteNonQuery();
            //    conn678.Close();

            //    /////////////////////
            //    Session.Abandon();
            //    Response.Redirect("~/forms/zlogin.aspx");
            //    //FormsAuthentication.SignOut();
            //    //FormsAuthentication.RedirectToLoginPage();

            //}
            //catch (Exception exp)
            //{
            //    Session.Abandon();
            //    Response.Redirect("~/forms/zlogin.aspx");
            //    //FormsAuthentication.SignOut();
            //    //FormsAuthentication.RedirectToLoginPage();
            //}

        }

        //private void fnDelCurSeat()
        //{

        //    SqlConnection conn1;
        //    conn1 = new SqlConnection(zglobal.constring);
        //    SqlCommand dataCmd = new SqlCommand();
        //    dataCmd.Connection = conn1;
        //    string query;

        //    query = "DELETE FROM ztcurseat WHERE xuser=@xuser";

        //    dataCmd.CommandText = query;

        //    string xuser1 = Convert.ToString(HttpContext.Current.Session["curuser"]);

        //    dataCmd.Parameters.AddWithValue("@xuser", xuser1);


        //    conn1.Close();
        //    conn1.Open();
        //    dataCmd.ExecuteNonQuery();
        //    conn1.Close();

        //    dataCmd.Dispose();
        //    conn1.Dispose();

        //}


    }
}
