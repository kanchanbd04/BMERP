using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicketingSystem
{
    public class properties
    {
       
    }

    public class Student
    {
        public string xsession { get; set; }
        public string xclass { get; set; } 
        public string xsection { get; set; } 
        public string xgroup { get; set; }
        public string xstdid { get; set; }
        public string xname { get; set; }
        public string xmname { get; set; }
        public string xfname { get; set; }
        public string xcellno { get; set; }
        public string xcellno1 { get; set; }
        public string xblood { get; set; }
        public string xdob { get; set; }
        public string xexamdate { get; set; }
        public string xexamvenue { get; set; }
        public string xgender { get; set; }
        public decimal xamount { get; set; }

        public Student()
        {
            xsession = "";
            xclass = "";
            xsection = "";
            xgroup = "";
            xstdid = "";
            xname = "";
            xmname = "";
            xfname = "";
            xcellno = "";
            xcellno1 = "";
            xblood = "";
            xdob = "";
            xexamdate = "";
            xexamvenue = "";
            xgender = "";
            xamount = 0;

        }

        
    }

    public class TFCInfo
    {
        public string xtfccode { get; set; }
        public string xdescdet { get; set; }
        public string xamount { get; set; }
        public string xdue { get; set; }
        public string xdamount { get; set; }

        public TFCInfo()
        {
            xtfccode = "";
            xdescdet = "";
            xamount = "0";
            xdamount = "0";
            xdue = "0";
        }
    }

    public class ItemInfo
    {
        public string xitem { get; set; }
        public string xdesc { get; set; }
        public string xunitpur { get; set; }
        public string xunitiss { get; set; }
        public decimal xcfpur { get; set; }
        public decimal xcfiss { get; set; }
        public decimal xstock { get; set; }

        public ItemInfo()
        {
            xitem = "";
            xdesc = "";
            xunitpur = "";
            xunitiss = "";
            xcfpur = 1;
            xcfiss = 1;
            xstock = 0;

        }
    }

    public class BookInfo
    {
        public string xlbord { get; set; }
        public string xlbtitle { get; set; }
        public string xlbstatus { get; set; }

        public BookInfo()
        {
            xlbord = "";
            xlbtitle = "";
            xlbstatus = "";

        }
    }

    public class WorkSheet
    {
        public string xdatesend { get; set; }
        public string xname { get; set; }
        public string xlink { get; set; }
        public string xrow { get; set; }
        public string xfileext { get; set; }
        public string xfile { get; set; }

        public WorkSheet()
        {
            xdatesend = "";
            xname = "";
            xlink = "";
            xrow = "";
            xfileext = "";
            xfile = "";
        }
    }


}