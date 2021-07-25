using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem
{
    public class zgetvalue
    {
        public static string GetMonthNo(string MonthName)
        {
            Dictionary<string, int> MonthNo = new Dictionary<string, int>();
            MonthNo.Add("Jan", 1);
            MonthNo.Add("Feb", 2);
            MonthNo.Add("Mar", 3);
            MonthNo.Add("Apr", 4);
            MonthNo.Add("May", 5);
            MonthNo.Add("Jun", 6);
            MonthNo.Add("Jul", 7);
            MonthNo.Add("Aug", 8);
            MonthNo.Add("Sep", 9);
            MonthNo.Add("Oct", 10);
            MonthNo.Add("Nov", 11);
            MonthNo.Add("Dec", 12);


            return MonthNo[MonthName].ToString();
        }

        public static string GetMonthNo1(string MonthName)
        {
            Dictionary<string, int> MonthNo = new Dictionary<string, int>();
            MonthNo.Add("January", 1);
            MonthNo.Add("February", 2);
            MonthNo.Add("March", 3);
            MonthNo.Add("April", 4);
            MonthNo.Add("May", 5);
            MonthNo.Add("June", 6);
            MonthNo.Add("July", 7);
            MonthNo.Add("August", 8);
            MonthNo.Add("September", 9);
            MonthNo.Add("October", 10);
            MonthNo.Add("November", 11);
            MonthNo.Add("December", 12);


            return MonthNo[MonthName].ToString();
        }

        public static string GetMonthName(int MonthNo)
        {
            Dictionary<int, string> MonthName = new Dictionary<int, string>();
            MonthName.Add(1, "Jan");
            MonthName.Add(2, "Feb");
            MonthName.Add(3, "Mar");
            MonthName.Add(4, "Apr");
            MonthName.Add(5, "May");
            MonthName.Add(6, "Jun");
            MonthName.Add(7, "Jul");
            MonthName.Add(8, "Aug");
            MonthName.Add(9, "Sep");
            MonthName.Add(10, "Oct");
            MonthName.Add(11, "Nov");
            MonthName.Add(12, "Dec");


            return MonthName[MonthNo].ToString();
        }

        public static string fnFdate()
        {
            string xdate = zglobal.fnDefaults("xstdageday", "Student");
            string xmonth = zglobal.fnDefaults("xstdagemonth", "Student");



            string xyear1 = zglobal.fnDefaults("xsessionacc", "Student");
            string xyear = xyear1.Substring(0, 4);
            string xfdate = xdate + "/" + xmonth + "/" + xyear;

            return xfdate;
        }


    }
}