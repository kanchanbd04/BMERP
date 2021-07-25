using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Web.Caching;
using System.Xml;
using AjaxControlToolkit;
using OnlineTicketingSystem.forms.sc;
using OnlineTicketingSystem.Forms;

namespace OnlineTicketingSystem
{
    public class zglobal
    {
        public static string reportPath = @"C:\bm\edusoft\reports\";
        public static string constring = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
        public static string constringstdp = ConfigurationManager.ConnectionStrings["mssqlstdp"].ConnectionString;
        public static string _grid_row_value = "20";
        public static string _grid_row_value100 = "100";
        public static string curuser;
        public static string xlocation;
        public static string delglhrc1zid = "DELETE FROM ztemporary WHERE zid IS NOT NULL";
        public static string delzid = "DELETE FROM ztemporary WHERE zid IS NOT NULL and zemail=@zemail and xsession=@xsession";
        public static string delglmstbiz = "DELETE FROM ztemporary WHERE zid1 IS NOT NULL and zemail=@zemail and xsession=@xsession";
        public static string delglmstbiz2 = "DELETE FROM ztemporary WHERE zid2 IS NOT NULL and zemail=@zemail and xsession=@xsession";
        public static string delmscusar = "DELETE FROM ztemporary WHERE zid3 IS NOT NULL and zemail=@zemail and xsession=@xsession";
        public static string delmscusar1 = "DELETE FROM ztemporary WHERE zid4 IS NOT NULL and zemail=@zemail and xsession=@xsession";
        public static string delmssupap = "DELETE FROM ztemporary WHERE zid5 IS NOT NULL and zemail=@zemail and xsession=@xsession";
        public static string insglhrc1zid = "INSERT INTO ztemporary (zid) VALUES (@zid)";
        public static string insglmstbiz = "INSERT INTO ztemporary (zid1,zorg,xhrc1,xhrc2,xhrc3,xhrc4,xhrc5,xsession,zemail) VALUES (@zid1,@zorg,@xhrc1,@xhrc2,@xhrc3,@xhrc4,@xhrc5,@xsession,@zemail)";
        public static string insglmstbiz2 = "INSERT INTO ztemporary (zid2,zorg12,xhrc12,xhrc22,xhrc32,xhrc42,xhrc52,xsession,zemail,xst2) VALUES (@zid2,@zorg12,@xhrc12,@xhrc22,@xhrc32,@xhrc42,@xhrc52,@xsession,@zemail,@xst2)";
        public static string insmscusar = "INSERT INTO ztemporary (zid3,xacc,xdesc,xsession,zemail) VALUES (@zid3,@xacc,@xdesc,@xsession,@zemail)";
        public static string insmscusar1 = "INSERT INTO ztemporary (zid4,zorg,xacc,xsession,zemail) VALUES (@zid4,@zorg,@xacc,@xsession,@zemail)";
        public static string insmssupap = "INSERT INTO ztemporary (zid5,zorg,xacc,xsession,zemail) VALUES (@zid5,@zorg,@xacc,@xsession,@zemail)";
        public static string insbiz = "INSERT INTO ztemporary (zid,zorg,xsession,zemail) VALUES (@zid,@zorg,@xsession,@zemail)";
        public static string successmsg = "font-weight:bold; font-size:12; color:Green; text-align:center;";
        public static string errormsg = "font-weight:bold; font-size:12; color:Red; text-align:center;";
        public static string infomsg = "font-weight:bold; font-size:12; color:Blue; text-align:center;";
        public static string warningmsg = "font-weight:bold; font-size:12; color:#FF3399; text-align:center;";
        public static string btnerr = "background-color : #CC3300";
        public static string btncolor = "background-color : #F0F0F0";
        public static string am_successmsg = "color:Green; text-align:center;font-size:12;font-weight: bold;";
        public static string am_errormsg = "color:Red; text-align:center;font-size:12;font-weight: bold;";
        public static string am_infomsg = "color:Blue; text-align:center;font-size:12;font-weight: bold;";
        public static string am_submited = "color:#ED1919;font-weight: bold;font-size:12;";
        public static string am_new = "color:#00CC00;font-weight: bold;";
        public static string am_warningmsg = "color:#FF3399; text-align:center;font-size:12;font-weight: bold;";
        public static string insertsuccmsg = "Add Completed";
        public static string revisedsuccmsg = "Revised Completed";
        public static string updatesuccmsg = "Update Completed";
        public static string delsuccmsg = "Delete Completed";
        public static string appsuccmsg = "Approved Completed";
        public static string subsuccmsg = "Successfully Submited.";
        public static string paidsuccmsg = "Successfully Paid.";
        public static string undosuccmsg = "Undo Completed";
        public static string savesuccmsg = "Successfully Saved Record.";
        public static string gensuccmsg = "Successfully Generated.";
        public static string confsuccmsg = "Successfully Confirmed.";
        public static string postsuccmsg = "Successfully Posted.";
        public static string calendertype = "academic";
        public static Color rowerr = Color.DarkSalmon;
        public static Color rowcorrected = Color.CornflowerBlue;
        public static Color rowtaken = Color.LightPink;
        public static Color rowcorrtaken = Color.DarkMagenta;
        public static string BusinessCultureInfo = "bn-BD";
        public static string CurrecnyFormatSpecifier = "C";
        public static string CurrecnyFormatSpecifierGridView = "{0:C}";
        public static string global_smtp_email = "noreply@presidency.ac.bd";
        public static string global_smtp_email_password = "Chittagong@99";
        public static string global_smtp = "smtp.office365.com";
        public static int global_smtp_port_587 = 587;
        public static int global_smtp_port_25 = 25;
        public static string xtfcdefault =

//@"WITH amtfctemp 
//AS
//(
//select ROW_NUMBER() OVER (PARTITION BY xtfccode 
//                                ORDER BY xpriority) RN,* from 
//(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence FROM amtfcconfigvw1
//WHERE zid=@zid AND xtype='Admission' AND zactive=1 and coalesce(xsrow,'')=@xsrow
//AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid and a.xdescdet=amtfcconfigvw1.xdescdet
//and a.xeffdate<= @xeffdate and a.xclass=amtfcconfigvw1.xclass and a.xgroup=amtfcconfigvw1.xgroup )
//union 
//SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence FROM amtfcconfigvw1
//WHERE zid=@zid AND xtype='Admission' AND zactive=1 and xclass=@xclass and xgroup=@xgroup and  coalesce(xsrow,'')=''
//AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid and a.xdescdet=amtfcconfigvw1.xdescdet
//and a.xeffdate<= @xeffdate and a.xclass=amtfcconfigvw1.xclass and a.xgroup=amtfcconfigvw1.xgroup )
//union
//SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence FROM amtfcconfigvw1
//WHERE zid=@zid AND xtype='Admission' AND zactive=1 and xclass='' and xgroup='' and  coalesce(xsrow,'')=''
//AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid and a.xdescdet=amtfcconfigvw1.xdescdet
//and a.xeffdate<= @xeffdate and a.xclass=amtfcconfigvw1.xclass and a.xgroup=amtfcconfigvw1.xgroup ) ) tbl  
//)
//SELECT      xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence
//FROM    amtfctemp
//WHERE   RN = 1";

@"WITH amtfctemp 
AS
(
select ROW_NUMBER() OVER (PARTITION BY xtfccode 
                                ORDER BY xpriority) RN,* from 
(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence FROM amtfcconfigvw1
WHERE zid=@zid AND xtype='Admission' AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid and a.xtype='Admission'  AND zactive=1 and coalesce(xsrow,'')=@xsrow
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate  and coalesce(xsession,'')=@xsession)
union 
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence FROM amtfcconfigvw1
WHERE zid=@zid AND xtype='Admission' AND zactive=1 and xclass=@xclass and  coalesce(xsrow,'')=''
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='Admission' AND zactive=1 and xclass=@xclass and  
coalesce(xsrow,'')='' and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate )
union
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence FROM amtfcconfigvw1
WHERE zid=@zid AND xtype='Admission' AND zactive=1 and xclass='' and  coalesce(xsrow,'')=''
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='Admission' AND zactive=1 and xclass='' and  
coalesce(xsrow,'')=''and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate ) ) tbl  
)
SELECT      xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence
FROM    amtfctemp
WHERE   RN = 1";

//        public static string xtfcdefault1 =

//@"WITH amtfctemp 
//AS
//(
//select ROW_NUMBER() OVER (PARTITION BY xtfccode 
//                                ORDER BY xpriority) RN,* from 
//(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
//WHERE zid=@zid  AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession
//AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and coalesce(xsrow,'')=@xsrow and 
//a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate and coalesce(xsession,'')=@xsession )
//union 
//SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
//WHERE zid=@zid  AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')=''
//AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' 
//and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate )
//union
//SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
//WHERE zid=@zid  AND zactive=1 and xclass=''  and  coalesce(xsrow,'')=''
//AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' 
//and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate) ) tbl  
//)
//SELECT      xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xtype1
//FROM    amtfctemp
//WHERE   RN = 1";

        public static string xtfcdefault1 =

@"WITH amtfctemp 
AS
(
select ROW_NUMBER() OVER (PARTITION BY xtfccode 
                                ORDER BY xpriority) RN,* from 
(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and coalesce(xsrow,'')=@xsrow and 
a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate and coalesce(a.xsession,'')=@xsession and xstatus='Submited' )  and xstatus='Submited'
union 
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')=''
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate and a.xstatus='Submited' ) and xstatus='Submited'
union
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and xclass=''  and  coalesce(xsrow,'')=''
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate and a.xstatus='Submited') and xstatus='Submited') tbl  
)
SELECT      xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xtype1
FROM    amtfctemp
WHERE   RN = 1";

        public static string xtfcdefault2 =

@"WITH amtfctemp 
AS
(
select ROW_NUMBER() OVER (PARTITION BY xtfccode 
                                ORDER BY xpriority) RN,* from 
(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and coalesce(xsrow,'')=@xsrow and xtfccode = @xtfccode
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid zid=@zid  AND zactive=1 and coalesce(xsrow,'')=@xsrow 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate )
union 
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and xclass=@xclass and  coalesce(xsrow,'')='' and xtfccode = @xtfccode
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass=@xclass and  coalesce(xsrow,'')='' 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate )
union
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence,xtype1 FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and xclass='' and  coalesce(xsrow,'')='' and xtfccode = @xtfccode
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass='' and  coalesce(xsrow,'')='' 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate ) ) tbl  
)
SELECT      xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xtype1
FROM    amtfctemp
WHERE   RN = 1";

        public static string xtfcdefault3 =

@"WITH amtfctemp 
AS
(
select ROW_NUMBER() OVER (PARTITION BY xtfccode 
                                ORDER BY xpriority) RN,* from 
(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence,xtype1,
(select xdue from amtfcduecalvw1 where zid=@zid and xsession=@xsession and xsrow=@xsrow and xtfccode=@xtfccode) as xdue FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and coalesce(xsrow,'')=@xsrow and xtfccode = @xtfccode
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and coalesce(xsrow,'')=@xsrow 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate )
union 
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence,xtype1,
(select xdue from amtfcduecalvw1 where zid=@zid and xsession=@xsession and xsrow=@xsrow and xtfccode=@xtfccode) as xdue FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and xclass=@xclass and  coalesce(xsrow,'')='' and xtfccode = @xtfccode
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass=@xclass and  coalesce(xsrow,'')='' 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate)
union
SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence,xtype1,
(select xdue from amtfcduecalvw1 where zid=@zid and xsession=@xsession and xsrow=@xsrow and xtfccode=@xtfccode) as xdue FROM amtfcconfigvw1
WHERE zid=@zid  AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' and xtfccode = @xtfccode
AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' 
and a.xtfccode=amtfcconfigvw1.xtfccode and a.xeffdate<= @xeffdate ) ) tbl  
)
SELECT      xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xtype1,xdue
FROM    amtfctemp
WHERE   RN = 1";

        public static string fnxtfcdefault(string xtype)
        {
            return  "WITH amtfctemp " +
"AS " +
"( " +
"select ROW_NUMBER() OVER (PARTITION BY xtfccode " +
                                "ORDER BY xpriority) RN,* from " +
"(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence,xremarks ,xtype1 FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow " +
"and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate and coalesce(xsession,'')=@xsession) " +
"union " +
"SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence,xremarks,xtype1  FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  " +
"coalesce(xsrow,'')=''and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate ) " +
"union " +
"SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence,xremarks,xtype1 FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  " +
"coalesce(xsrow,'')=''and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate  ) ) tbl  " +
") " +
"SELECT      xtfccode,xdescdet,xtype,xamount,coalesce(xdisfixed,0) as xdisfixed,coalesce(xdisperc,0) as xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xremarks,xtype1 " +
"FROM    amtfctemp " +
"WHERE   RN = 1";

        }

        public static string fnxtfcdefault4(string xtype)
        {
//            return "WITH amtfctemp " +
//"AS " +
//"( " +
//"select ROW_NUMBER() OVER (PARTITION BY xtfccode " +
//                                "ORDER BY xpriority) RN,* from " +
//"(SELECT  xtfccode,xdescdet,xtype," +
//                   "("+
//                   "SELECT top 1 xamount  FROM amtfcconfig " +
//"WHERE zid=@zid AND xclass=@xclass  AND zactive=1  and xtfccode=amtfcconfigvw1.xtfccode and coalesce(xclass,'')<>'' and coalesce(xstdid,'')=''  " +
//"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfig as a where a.zid=@zid AND xclass=@xclass AND zactive=1   and  " +
//" a.xtfccode=amtfcconfigvw1.xtfccode  " +
//"and a.xeffdate<= @xeffdate and coalesce(xclass,'')<>'' and coalesce(xstdid,'')='' )" 
//                   +") as xamount1,xamount" +
//",xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence,xspecialdis,xspecialdistype,xnetamount,xremarks ,xtype1 FROM amtfcconfigvw1 " +
//"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession " +
//"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow " +
//"and a.xtfccode=amtfcconfigvw1.xtfccode " +
//"and a.xeffdate<= @xeffdate and coalesce(xsession,'')=@xsession) " +
//"union " +
//"SELECT  xtfccode,xdescdet,xtype,xamount as xamount1,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence,xspecialdis,xspecialdistype,xnetamount,xremarks,xtype1  FROM amtfcconfigvw1 " +
//"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' " +
//"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  " +
//"coalesce(xsrow,'')=''and a.xtfccode=amtfcconfigvw1.xtfccode " +
//"and a.xeffdate<= @xeffdate ) " +
//"union " +
//"SELECT  xtfccode,xdescdet,xtype,xamount as xamount1,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence,xspecialdis,xspecialdistype,xnetamount,xremarks,xtype1 FROM amtfcconfigvw1 " +
//"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' " +
//"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  " +
//"coalesce(xsrow,'')=''and a.xtfccode=amtfcconfigvw1.xtfccode " +
//"and a.xeffdate<= @xeffdate  ) ) tbl  " +
//") " +
//"SELECT      xtfccode,xdescdet,xtype,coalesce(xamount1,0) as xamount1,coalesce(xamount,0) as xamount,coalesce(xdisfixed,0) as xdisfixed,coalesce(xdisperc,0) as xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xspecialdis,xspecialdistype,xnetamount,xremarks,xtype1 " +
//"FROM    amtfctemp " +
//"WHERE   RN = 1";

            return "WITH amtfctemp " +
"AS " +
"( " +
"select ROW_NUMBER() OVER (PARTITION BY xtfccode " +
                                "ORDER BY xpriority) RN,* from " +
"(SELECT  xtfccode,xdescdet,xtype,xamount" +
",xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence,xremarks ,xtype1 FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow " +
"and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate and coalesce(xsession,'')=@xsession) " +
"union " +
"SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence,xremarks,xtype1  FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  " +
"coalesce(xsrow,'')=''and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate ) " +
"union " +
"SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence,xremarks,xtype1 FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  " +
"coalesce(xsrow,'')=''and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate  ) ) tbl  " +
") " +
"SELECT      xtfccode,xdescdet,xtype,coalesce(xamount,0) as xamount,coalesce(xdisfixed,0) as xdisfixed,coalesce(xdisperc,0) as xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xremarks,xtype1 " +
"FROM    amtfctemp " +
"WHERE   RN = 1 and xtype1 not in ('','N/A')";

        }

        public static string fnxtfcdefault3(string xtype)
        {
            return "WITH amtfctemp " +
"AS " +
"( " +
"select ROW_NUMBER() OVER (PARTITION BY xtfccode " +
                                "ORDER BY xpriority) RN,* from " +
"(SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, 1 as xpriority,xsequence," +
"coalesce((select xdue from amtfcduecalvw1 where zid=@zid and xsession=@xsession and xsrow=@xsrow and xtfccode=amtfcconfigvw1.xtfccode),0) as xdue FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and coalesce(xsrow,'')=@xsrow " +
"and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate and coalesce(xsession,'')=@xsession ) " +
"union " +
"SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,2 as xpriority,xsequence," +
"coalesce((select xdue from amtfcduecalvw1 where zid=@zid and xsession=@xsession and xsrow=@xsrow and xtfccode=amtfcconfigvw1.xtfccode),0) as xdue FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=@xclass  and  " +
"coalesce(xsrow,'')='' and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate ) " +
"union " +
"SELECT  xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat,3 as xpriority,xsequence," +
"coalesce((select xdue from amtfcduecalvw1 where zid=@zid and xsession=@xsession and xsrow=@xsrow and xtfccode=amtfcconfigvw1.xtfccode),0) as xdue FROM amtfcconfigvw1 " +
"WHERE zid=@zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' " +
"AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcconfigvw1 as a where a.zid=amtfcconfigvw1.zid AND xtype='" + xtype + "' AND zactive=1 and xclass=''  and  " +
"coalesce(xsrow,'')='' and a.xtfccode=amtfcconfigvw1.xtfccode " +
"and a.xeffdate<= @xeffdate  ) ) tbl  " +
") " +
"SELECT      xtfccode,xdescdet,xtype,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,xnettotal,xnettotal1,xdiscount,xvat, xpriority,xsequence,xdue " +
"FROM    amtfctemp " +
"WHERE   RN = 1";

        }


//        public static string fntfcSpecialDiscount()
//        {
//            return @"WITH amtfctempsp
//                     AS 
//                     ( 
//                     select ROW_NUMBER() OVER (PARTITION BY xtfccode 
//                                                    ORDER BY xpriority) RN,* from 
//                     (SELECT  xtfccode,xdescdet,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc, 1 as xpriority,xsequence,xremarks ,xtype1 FROM amtfcspecialdisconfvw 
//                     WHERE zid=@zid AND zactive=1 and coalesce(xsrow,'')=@xsrow
//                     AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcspecialdisconfvw as a where a.zid=amtfcspecialdisconfvw.zid  AND zactive=1 and coalesce(xsrow,'')=amtfcspecialdisconfvw.xsrow
//                     and a.xtfccode=amtfcspecialdisconfvw.xtfccode 
//                     and a.xeffdate<= @xeffdate and a.xstatus='Submited') and xstatus='Submited'
//                     union 
//                     SELECT  xtfccode,xdescdet,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,2 as xpriority,xsequence,xremarks,xtype1  FROM amtfcspecialdisconfvw 
//                     WHERE zid=@zid AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' 
//                     AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcspecialdisconfvw as a where a.zid=amtfcspecialdisconfvw.zid AND zactive=1 and xclass=amtfcspecialdisconfvw.xclass  and  
//                     coalesce(xsrow,'')=''and a.xtfccode=amtfcspecialdisconfvw.xtfccode 
//                     and a.xeffdate<= @xeffdate and a.xstatus='Submited')  and xstatus='Submited'
//                     union 
//                     SELECT  xtfccode,xdescdet,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,3 as xpriority,xsequence,xremarks,xtype1 FROM amtfcspecialdisconfvw 
//                     WHERE zid=@zid AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' 
//                     AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcspecialdisconfvw as a where a.zid=amtfcspecialdisconfvw.zid AND zactive=1 and xclass=''  and  
//                     coalesce(xsrow,'')=''and a.xtfccode=amtfcspecialdisconfvw.xtfccode 
//                     and a.xeffdate<= @xeffdate  and a.xstatus='Submited') and xstatus='Submited' ) tbl  
//                     ) 
//                     SELECT      xtfccode,xdescdet,xamount,coalesce(xdisfixed,0) as xdisfixed,coalesce(xdisperc,0) as xdisperc,xvatfixed,xvatperc, xpriority,xsequence,xremarks,xtype1 
//                     FROM    amtfctempsp 
//                     WHERE   RN = 1 ";

//        }

        public static string fntfcSpecialDiscount()
        {
            return @"WITH amtfctempsp
                     AS 
                     ( 
                     select ROW_NUMBER() OVER (PARTITION BY xtfccode 
                                                    ORDER BY xpriority) RN,* from 
                     (SELECT  xtfccode,xdescdet,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc, 1 as xpriority,xsequence,xremarks ,xtype1 FROM amtfcspecialdisconfvw 
                     WHERE zid=@zid AND zactive=1 and coalesce(xsrow,'')=@xsrow and coalesce(xsession,'')=@xsession
                     AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcspecialdisconfvw as a where a.zid=amtfcspecialdisconfvw.zid  AND zactive=1 and coalesce(xsrow,'')=amtfcspecialdisconfvw.xsrow
                     and a.xtfccode=amtfcspecialdisconfvw.xtfccode and coalesce(xsession,'')=@xsession
                     and a.xeffdate<= @xeffdate and a.xstatus='Submited') and xstatus='Submited'
                     union 
                     SELECT  xtfccode,xdescdet,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,2 as xpriority,xsequence,xremarks,xtype1  FROM amtfcspecialdisconfvw 
                     WHERE zid=@zid AND zactive=1 and xclass=@xclass  and  coalesce(xsrow,'')='' 
                     AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcspecialdisconfvw as a where a.zid=amtfcspecialdisconfvw.zid AND zactive=1 and xclass=amtfcspecialdisconfvw.xclass  and  
                     coalesce(xsrow,'')=''and a.xtfccode=amtfcspecialdisconfvw.xtfccode 
                     and a.xeffdate<= @xeffdate and a.xstatus='Submited')  and xstatus='Submited'
                     union 
                     SELECT  xtfccode,xdescdet,xamount,xdisfixed,xdisperc,xvatfixed,xvatperc,3 as xpriority,xsequence,xremarks,xtype1 FROM amtfcspecialdisconfvw 
                     WHERE zid=@zid AND zactive=1 and xclass=''  and  coalesce(xsrow,'')='' 
                     AND  xeffdate=(SELECT MAX(xeffdate) FROM amtfcspecialdisconfvw as a where a.zid=amtfcspecialdisconfvw.zid AND zactive=1 and xclass=''  and  
                     coalesce(xsrow,'')=''and a.xtfccode=amtfcspecialdisconfvw.xtfccode 
                     and a.xeffdate<= @xeffdate  and a.xstatus='Submited') and xstatus='Submited' ) tbl  
                     ) 
                     SELECT      xtfccode,xdescdet,xamount,coalesce(xdisfixed,0) as xdisfixed,coalesce(xdisperc,0) as xdisperc,xvatfixed,xvatperc, xpriority,xsequence,xremarks,xtype1 
                     FROM    amtfctempsp 
                     WHERE   RN = 1 ";

        }



        public static CultureInfo GetCultureInfo ()
        {
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(zglobal.BusinessCultureInfo);
            cultureInfo.NumberFormat.CurrencySymbol = "";

            return cultureInfo;
        }

        //public static CultureInfo GetCultureInfoCurrencyWithSymbol()
        //{
        //    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(zglobal.BusinessCultureInfo);
        //    //cultureInfo.NumberFormat.CurrencySymbol = "";

        //    return cultureInfo;
        //}

        //public static string calculateage = fnDefaults("xstdageday", "Student") + "/" +
        //                                    fnDefaults("xstdagemonth", "Student") + "/1999";   

        public static string calculateage = "01/07/1999";

       

        public static List<zbusiness_glmst> ltZbusinessGlmst = new List<zbusiness_glmst>();
        public static List<zbusiness_glmst> ltZbusinessGlmstPermis = new List<zbusiness_glmst>();

        public static void fnDisableMasterPageContent(MasterPage masterpage)
        {
            masterpage.FindControl("header").Visible = false;
            masterpage.FindControl("header1").Visible = false;
            masterpage.FindControl("footer").Visible = false;
        }

        public static  void ClearApplicationCache()
        {
            //List<string> keys = new List<string>();

            //IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    keys.Add(enumerator.Key.ToString());
            //}

            //for (int i = 0; i < keys.Count; i++)
            //{
            //    HttpContext.Current.Cache.Remove(keys[i]);
            //}
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.ExpiresAbsolute = DateTime.UtcNow.AddDays(-1d);
            //HttpContext.Current.Response.Expires = -1500;
            //HttpContext.Current.Response.CacheControl = "no-Cache";
        }

        public static string fnDefaults(string xfield, string xtype)
        {
            string val = "";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {

                    //DataSet dts = new DataSet();
                    //dts.Reset();
                    string query = "SELECT * FROM amdefaults WHERE zid=@zid AND xtype=@xtype";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xtype", xtype);
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dts, "tempdtdefault");
                    DataTable dtdefault = new DataTable();
                    dtdefault = dts.Tables[0];
                    if (dtdefault.Rows.Count > 0)
                    {
                        val = dtdefault.Rows[0][xfield].ToString().Trim();
                    }
                }
            }

            return val;
        }

        public static void fnGetComboDataCD(string xtype, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(rdr["xcode"].ToString());
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGetComboDataCD(string xtype, DropDownList combo, string order)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY " + order;

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(rdr["xcode"].ToString());
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGetComboDataCDTRN(string xtypetrn, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xtrn FROM mstrn WHERE zid=@zid AND xtypetrn in ("+xtypetrn+") AND zactive=1 ORDER BY xtrn";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtypetrn", xtypetrn);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(rdr["xtrn"].ToString());
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGetComboDataCDWithValue(string xtype, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add(new ListItem("", ""));
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode,xdescdet FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(new ListItem(rdr["xdescdet"].ToString(), rdr["xcode"].ToString()));
                }
            }
            //combo.Text = "[Select]";
            combo.SelectedValue = "";

        }

        public static void fnGetComboDataCDWithValue(DropDownList combo, string xtext, string xvalue, string xtable, string xcondition)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add(new ListItem("", ""));
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT " + xtext + "," + xvalue + " FROM " + xtable + " WHERE zid=@zid and (" + xcondition + ")";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                //cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(new ListItem(rdr[xtext].ToString(), rdr[xvalue].ToString()));
                }
            }
            //combo.Text = "[Select]";
            combo.SelectedValue = "";

        }

        public static void fnGetComboDataCDWithProp(string xtype, DropDownList combo, string xprop)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string xpromotion = zglobal.fnProperty1(xtype, rdr["xcode"].ToString(), xprop);
                    if (xpromotion.ToLower() == "yes")
                    {
                        combo.Items.Add(rdr["xcode"].ToString());
                    }
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGetComboDataCDWithProp1(string xtype, DropDownList combo, string xprop)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string xpromotion = zglobal.fnProperty2(xtype, rdr["xcode"].ToString(), xprop);
                    if (xpromotion.ToLower() == "yes")
                    {
                        combo.Items.Add(rdr["xcode"].ToString());
                    }
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGetComboDataCDSubject(string xclass, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xsubject FROM amclasssubh WHERE zid=@zid AND xclass=@xclass order by xsubject";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xclass", xclass);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(rdr["xsubject"].ToString());
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGetComboDataCDPaper(string xclass, string xsubject, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xpaper FROM amclasssubh inner join amclasssubd on amclasssubh.zid=amclasssubd.zid AND amclasssubh.xrow=amclasssubd.xrow " +
                               " WHERE amclasssubh.zid=@zid AND xclass=@xclass AND xsubject=@xsubject order by xpaper";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xclass", xclass);
                cmd.Parameters.AddWithValue("@xsubject", xsubject);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(rdr["xpaper"].ToString());
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGetComboDataCDExtension(string xclass, string xsubject, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xext FROM amclasssubh inner join amclasssubex on amclasssubh.zid=amclasssubex.zid AND amclasssubh.xrow=amclasssubex.xrow " +
                               " WHERE amclasssubh.zid=@zid AND xclass=@xclass AND xsubject=@xsubject order by xext";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xclass", xclass);
                cmd.Parameters.AddWithValue("@xsubject", xsubject);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(rdr["xext"].ToString());
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static void fnGLYearCombo(DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            //combo.Items.Add("");

            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xnote,xinteger FROM msstatus " +
                               "WHERE zid=@zid AND xtypestatus='GL Year/Period' ";

                SqlCommand cmd = new SqlCommand(query, con);
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", _zid);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<string> years = new List<string>();
                while (rdr.Read())
                {
                    string[] xnote = rdr["xnote"].ToString().Split(',');

                    foreach (string note in xnote)
                    {
                        string[] year = note.Split('/');

                        years.Add(year[0]);
                    }

                    years = years.Distinct().ToList();

                    foreach (string y in years)
                    {
                        combo.Items.Add(y);
                    }
                  
                }
            }

            //combo.Text = "";


        }

        public static void fnGLPerCombo(DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            //combo.Items.Add("");

            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xnote,xinteger FROM msstatus " +
                               "WHERE zid=@zid AND xtypestatus='GL Year/Period' ";

                SqlCommand cmd = new SqlCommand(query, con);
                int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", _zid);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<string> years = new List<string>();
                while (rdr.Read())
                {
                    string[] xnote = rdr["xnote"].ToString().Split(',');

                    foreach (string note in xnote)
                    {
                        string[] year = note.Split('/');

                        years.Add(year[1]);
                    }

                    years = years.Distinct().ToList();

                    foreach (string y in years)
                    {
                        combo.Items.Add(y);
                    }

                }
            }

            //combo.Text = "";


        }

        public static void fnReportType(DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("PDF");
            combo.Items.Add("MS-Word");
            combo.Items.Add("MS-Excel");
            
            combo.Text = "PDF";
        }

        public static void fnGetCheckBoxListItems(string xtype, CheckBoxList clist)
        {
            clist.Items.Clear();
            //combo.Items.Add("[Select]");
            //clist.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clist.Items.Add(rdr["xcode"].ToString());
                }
            }
            //combo.Text = "[Select]";
            //combo.Text = "";
        }

        public static void fnGetRadioButtonBoxListItems(string xtype, RadioButtonList clist)
        {
            clist.Items.Clear();
            //combo.Items.Add("[Select]");
            //clist.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clist.Items.Add(rdr["xcode"].ToString());
                }
            }
            //combo.Text = "[Select]";
            //combo.Text = "";
        }
       
        public static void fnGetCheckBoxListItemsWithValue(string xtype, CheckBoxList clist)
        {
            clist.Items.Clear();
            //combo.Items.Add("[Select]");
            //clist.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode,xdescdet FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //clist.Items.Add(rdr["xcode"].ToString());
                    clist.Items.Add(new ListItem(rdr["xdescdet"].ToString(), rdr["xcode"].ToString()));
                }
            }
            //combo.Text = "[Select]";
            //combo.Text = "";
        }

        /*
         
         * Permission Description
         * all - All Permission
         * sh - School Head
         * class - Class
         * cs - Class & Section
         * css - Class, Section, Subject & Paper
         
         */

        public static void fnPermission(DropDownList xclass, DropDownList xsection, DropDownList xsubject, DropDownList xpaper)
        {

            if (HttpContext.Current.Session["curuser"].ToString() == "bm")
            {
                zglobal.fnGetComboDataCD("Class", xclass);
                zglobal.fnGetComboDataCD("Section", xsection);
                zglobal.fnGetComboDataCD("Class Subject", xsubject);
                zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                return;
            }

            ///////////////////Permission Check Start/////////////////////////////////

            int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {

                    //DataSet dts = new DataSet();
                    //dts.Reset();
                    string query = "SELECT * FROM ztuser WHERE xuser=@xuser";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@xuser", HttpContext.Current.Session["curuser"].ToString());
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dts, "tempztuser");
                    DataTable ztuser = new DataTable();
                    ztuser = dts.Tables[0];

                    //message.InnerHtml = ztuser.Rows[0]["xempcode"].ToString().Trim();
                    //return;

                    string xempcode = "";
                    if (ztuser.Rows.Count > 0)
                    {
                        string xrole = ztuser.Rows[0]["xrole"].ToString();

                        if (xrole == "Director" || xrole == "Super Admin" || xrole == "Director L-A" || xrole == "Director L-B" || xrole == "Administrator" || xrole == "SRO")
                        {
                            zglobal.fnGetComboDataCD("Class", xclass);
                            zglobal.fnGetComboDataCD("Section", xsection);
                            zglobal.fnGetComboDataCD("Class Subject", xsubject);
                            zglobal.fnGetComboDataCD("Subject Paper", xpaper);
                            return;
                        }


                        xempcode = ztuser.Rows[0]["xempcode"].ToString().Trim();

                        /////////Retrive Teacher's Position Start/////////////

                        using (DataSet dts1 = new DataSet())
                        {
                            query = "SELECT * FROM hrjobs WHERE zid=@zid AND xemp=@xemp AND xfdate=(SELECT MAX(xfdate) FROM hrjobs WHERE zid=@zid AND xemp=@xemp)";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                            da1.SelectCommand.CommandType = CommandType.Text;
                            da1.Fill(dts1, "temphrjobs");
                            DataTable hrjobs = new DataTable();
                            hrjobs = dts1.Tables[0];

                            //message.InnerHtml = hrjobs.Rows[0]["xposition"].ToString();
                            //return;
                            int xline;
                            if (hrjobs.Rows.Count > 0)
                            {
                                /////////////Retrive Teacher's Permission Start////////////////

                                xline = Convert.ToInt32(hrjobs.Rows[0]["xline"].ToString().Trim());

                                string permission = zglobal.fnProperty("Designation", hrjobs.Rows[0]["xposition"].ToString(), "permission");

                                if (permission == "all")
                                {

                                    zglobal.fnGetComboDataCD("Class", xclass);
                                    zglobal.fnGetComboDataCD("Section", xsection);
                                    zglobal.fnGetComboDataCD("Class Subject", xsubject);
                                    zglobal.fnGetComboDataCD("Subject Paper", xpaper);

                                }
                                else if (permission == "sh") //School Head
                                {
                                    using (DataSet dtssch = new DataSet())
                                    {
                                        query = "SELECT xschool FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='School'";

                                        SqlDataAdapter dasch = new SqlDataAdapter(query, con);
                                        dasch.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasch.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasch.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasch.SelectCommand.CommandType = CommandType.Text;
                                        dasch.Fill(dtssch, "temptschool");
                                        DataTable tblschool = new DataTable();
                                        tblschool = dtssch.Tables[0];
                                        if (tblschool.Rows.Count > 0)
                                        {
                                            string school = "";
                                            string stype = "-";

                                            for (int i = 0; i < tblschool.Rows.Count; i++)
                                            {
                                                if (tblschool.Rows[i][0].ToString() == "Junior School")
                                                {
                                                    stype = "Junior";
                                                }
                                                else if (tblschool.Rows[i][0].ToString() == "Middle School")
                                                {
                                                    stype = "Middle";
                                                }
                                                else if (tblschool.Rows[i][0].ToString() == "Senior School")
                                                {
                                                    stype = "Senior";
                                                }


                                                if (i == tblschool.Rows.Count - 1)
                                                {
                                                    school = school + "'" + stype + "'";
                                                }
                                                else
                                                {
                                                    school = school + "'" + stype + "',";
                                                }

                                            }

                                            using (DataSet dtsclass = new DataSet())
                                            {
                                                query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Class' AND xprops IN (" + school + ") ORDER BY coalesce(xcodealt,'')";

                                                SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                                daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                                daclass.SelectCommand.Parameters.AddWithValue("@xprops", school);
                                                daclass.SelectCommand.CommandType = CommandType.Text;
                                                daclass.Fill(dtsclass, "temptclass");
                                                DataTable tblclass = new DataTable();
                                                tblclass = dtsclass.Tables[0];

                                                xclass.Items.Clear();
                                                xclass.Items.Add("");

                                                if (tblclass.Rows.Count > 0)
                                                {
                                                    foreach (DataRow row in tblclass.Rows)
                                                    {
                                                        xclass.Items.Add(row["xcode"].ToString());
                                                    }
                                                }

                                                xclass.Text = "";

                                            }
                                        }

                                    }


                                    zglobal.fnGetComboDataCD("Section", xsection);
                                    zglobal.fnGetComboDataCD("Class Subject", xsubject);
                                    zglobal.fnGetComboDataCD("Subject Paper", xpaper);

                                }
                                else if (permission == "class") //Class Coordinator/ Coordinator
                                {

                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                                "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                                "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                                "group by xsclass,coalesce(xcodealt,'') " +
                                                "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                    zglobal.fnGetComboDataCD("Section", xsection);
                                    zglobal.fnGetComboDataCD("Class Subject", xsubject);
                                    zglobal.fnGetComboDataCD("Subject Paper", xpaper);

                                }
                                else if (permission == "cs") //Calss & Section
                                {
                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                                "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                                "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                                "group by xsclass,coalesce(xcodealt,'') " +
                                                "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                    using (DataSet dtssection = new DataSet())
                                    {
                                        //query = "SELECT distinct xssection FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xssection,coalesce(xcodealt,'') " +
                                                "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Section'  and hrjobsd.xssection=mscodesam.xcode " +
                                                "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                                "group by xssection,coalesce(xcodealt,'') " +
                                                "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter dasection = new SqlDataAdapter(query, con);
                                        dasection.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasection.SelectCommand.CommandType = CommandType.Text;
                                        dasection.Fill(dtssection, "temptsection");
                                        DataTable tblsection = new DataTable();
                                        tblsection = dtssection.Tables[0];

                                        xsection.Items.Clear();
                                        xsection.Items.Add("");

                                        if (tblsection.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblsection.Rows)
                                            {
                                                xsection.Items.Add(row["xssection"].ToString());
                                            }
                                        }

                                        xsection.Text = "";

                                    }


                                    zglobal.fnGetComboDataCD("Class Subject", xsubject);
                                    zglobal.fnGetComboDataCD("Subject Paper", xpaper);

                                }
                                else if (permission == "css") //Class, Section, Subject & Paper
                                {
                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                                "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                                "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                                "group by xsclass,coalesce(xcodealt,'') " +
                                                "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                    using (DataSet dtssection = new DataSet())
                                    {
                                        //query = "SELECT distinct xssection FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xssection,coalesce(xcodealt,'') " +
                                                "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Section'  and hrjobsd.xssection=mscodesam.xcode " +
                                                "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                                "group by xssection,coalesce(xcodealt,'') " +
                                                "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter dasection = new SqlDataAdapter(query, con);
                                        dasection.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasection.SelectCommand.CommandType = CommandType.Text;
                                        dasection.Fill(dtssection, "temptsection");
                                        DataTable tblsection = new DataTable();
                                        tblsection = dtssection.Tables[0];

                                        xsection.Items.Clear();
                                        xsection.Items.Add("");

                                        if (tblsection.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblsection.Rows)
                                            {
                                                xsection.Items.Add(row["xssection"].ToString());
                                            }
                                        }

                                        xsection.Text = "";

                                    }


                                    using (DataSet dtssubject = new DataSet())
                                    {
                                        query = "SELECT distinct xsubject FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";

                                        SqlDataAdapter dasubject = new SqlDataAdapter(query, con);
                                        dasubject.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasubject.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasubject.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasubject.SelectCommand.CommandType = CommandType.Text;
                                        dasubject.Fill(dtssubject, "temptsubject");
                                        DataTable tblsubject = new DataTable();
                                        tblsubject = dtssubject.Tables[0];

                                        xsubject.Items.Clear();
                                        xsubject.Items.Add("");

                                        if (tblsubject.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblsubject.Rows)
                                            {
                                                xsubject.Items.Add(row["xsubject"].ToString());
                                            }
                                        }

                                        xsubject.Text = "";

                                    }


                                    using (DataSet dtspaper = new DataSet())
                                    {
                                        query = "SELECT distinct xpaper FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";

                                        SqlDataAdapter dapaper = new SqlDataAdapter(query, con);
                                        dapaper.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dapaper.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dapaper.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dapaper.SelectCommand.CommandType = CommandType.Text;
                                        dapaper.Fill(dtspaper, "temptpaper");
                                        DataTable tblpaper = new DataTable();
                                        tblpaper = dtspaper.Tables[0];

                                        xpaper.Items.Clear();
                                        xpaper.Items.Add("");

                                        if (tblpaper.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblpaper.Rows)
                                            {
                                                xpaper.Items.Add(row["xpaper"].ToString());
                                            }
                                        }

                                        xpaper.Text = "";

                                    }
                                }

                                //message.InnerHtml = permission;
                                //return;

                                /////////////Retrive Teacher's Permission End////////////////
                            }
                        }

                        /////////Retrive Teacher's Position End/////////////
                    }
                }
            }


            ///////////////////Permission Check End/////////////////////////////////
        }

        public static void fnPermission(DropDownList xclass, DropDownList xsection, string xclassall, string xsectionall)
        {
            if (HttpContext.Current.Session["curuser"].ToString() == "bm")
            {
                zglobal.fnGetComboDataCD("Class", xclass);
                zglobal.fnGetComboDataCD("Section", xsection);

                if (xclassall == "Yes")
                {
                    xclass.Items.Add("All");
                    xclass.Text = "All";
                }

                if (xsectionall == "Yes")
                {
                    xsection.Items.Add("All");
                    xsection.Text = "All";
                }

                return;
            }

            ///////////////////Permission Check Start/////////////////////////////////

            int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {

                    //DataSet dts = new DataSet();
                    //dts.Reset();
                    string query = "SELECT * FROM ztuser WHERE xuser=@xuser";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@xuser", HttpContext.Current.Session["curuser"].ToString());
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dts, "tempztuser");
                    DataTable ztuser = new DataTable();
                    ztuser = dts.Tables[0];

                    //message.InnerHtml = ztuser.Rows[0]["xempcode"].ToString().Trim();
                    //return;

                    string xempcode = "";
                    if (ztuser.Rows.Count > 0)
                    {

                        string xrole = ztuser.Rows[0]["xrole"].ToString();

                        if (xrole == "Director" || xrole == "Super Admin" || xrole == "Director L-A" || xrole == "Director L-B" || xrole == "Administrator" || xrole == "SRO")
                        {
                            zglobal.fnGetComboDataCD("Class", xclass);
                            zglobal.fnGetComboDataCD("Section", xsection);

                            if (xclassall == "Yes")
                            {
                                xclass.Items.Add("All");
                                xclass.Text = "All";
                            }

                            if (xsectionall == "Yes")
                            {
                                xsection.Items.Add("All");
                                xsection.Text = "All";
                            }

                            return;
                        }


                        xempcode = ztuser.Rows[0]["xempcode"].ToString().Trim();

                        /////////Retrive Teacher's Position Start/////////////

                        using (DataSet dts1 = new DataSet())
                        {
                            query = "SELECT * FROM hrjobs WHERE zid=@zid AND xemp=@xemp AND xfdate=(SELECT MAX(xfdate) FROM hrjobs WHERE zid=@zid AND xemp=@xemp)";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                            da1.SelectCommand.CommandType = CommandType.Text;
                            da1.Fill(dts1, "temphrjobs");
                            DataTable hrjobs = new DataTable();
                            hrjobs = dts1.Tables[0];

                            //message.InnerHtml = hrjobs.Rows[0]["xposition"].ToString();
                            //return;
                            int xline;
                            if (hrjobs.Rows.Count > 0)
                            {
                                /////////////Retrive Teacher's Permission Start////////////////

                                xline = Convert.ToInt32(hrjobs.Rows[0]["xline"].ToString().Trim());

                                string permission = zglobal.fnProperty("Designation", hrjobs.Rows[0]["xposition"].ToString(), "permission");

                                if (permission == "all")
                                {
                                    
                                    zglobal.fnGetComboDataCD("Class", xclass);
                                    zglobal.fnGetComboDataCD("Section", xsection);

                                }
                                else if (permission == "sh") //School Head
                                {
                                    using (DataSet dtssch = new DataSet())
                                    {
                                        query = "SELECT xschool FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='School'";

                                        SqlDataAdapter dasch = new SqlDataAdapter(query, con);
                                        dasch.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasch.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasch.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasch.SelectCommand.CommandType = CommandType.Text;
                                        dasch.Fill(dtssch, "temptschool");
                                        DataTable tblschool = new DataTable();
                                        tblschool = dtssch.Tables[0];
                                        if (tblschool.Rows.Count > 0)
                                        {
                                            string school = "";
                                            string stype = "-";

                                            for (int i = 0; i < tblschool.Rows.Count; i++)
                                            {
                                                if (tblschool.Rows[i][0].ToString() == "Junior School")
                                                {
                                                    stype = "Junior";
                                                }
                                                else if (tblschool.Rows[i][0].ToString() == "Middle School")
                                                {
                                                    stype = "Middle";
                                                }
                                                else if (tblschool.Rows[i][0].ToString() == "Senior School")
                                                {
                                                    stype = "Senior";
                                                }


                                                if (i == tblschool.Rows.Count - 1)
                                                {
                                                    school = school + "'" + stype + "'";
                                                }
                                                else
                                                {
                                                    school = school + "'" + stype + "',";
                                                }

                                            }

                                            using (DataSet dtsclass = new DataSet())
                                            {
                                                query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Class' AND xprops IN (" + school + ") ORDER BY coalesce(xcodealt,'')";

                                                SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                                daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                                daclass.SelectCommand.Parameters.AddWithValue("@xprops", school);
                                                daclass.SelectCommand.CommandType = CommandType.Text;
                                                daclass.Fill(dtsclass, "temptclass");
                                                DataTable tblclass = new DataTable();
                                                tblclass = dtsclass.Tables[0];

                                                xclass.Items.Clear();
                                                xclass.Items.Add("");

                                                if (tblclass.Rows.Count > 0)
                                                {
                                                    foreach (DataRow row in tblclass.Rows)
                                                    {
                                                        xclass.Items.Add(row["xcode"].ToString());
                                                    }

                                                   
                                                }

                                                xclass.Text = "";

                                            }
                                        }

                                    }


                                    zglobal.fnGetComboDataCD("Section", xsection);

                                    if (xclassall == "Yes")
                                    {
                                        xclass.Items.Add("All");
                                        xclass.Text = "All";
                                    }

                                    if (xsectionall == "Yes")
                                    {
                                        xsection.Items.Add("All");
                                        xsection.Text = "All";
                                    }
                                }
                                else if (permission == "class") //Class Coordinator/ Coordinator
                                {

                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                              "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                              "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                              "group by xsclass,coalesce(xcodealt,'') " +
                                              "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                    zglobal.fnGetComboDataCD("Section", xsection);

                                    if (xclassall == "Yes")
                                    {
                                        xclass.Items.Add("All");
                                        xclass.Text = "All";
                                    }

                                    if (xsectionall == "Yes")
                                    {
                                        xsection.Items.Add("All");
                                        xsection.Text = "All";
                                    }

                                }
                                else if (permission == "cs") //Calss & Section
                                {
                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                             "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                             "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                             "group by xsclass,coalesce(xcodealt,'') " +
                                             "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                    using (DataSet dtssection = new DataSet())
                                    {
                                        //query = "SELECT distinct xssection FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xssection,coalesce(xcodealt,'') " +
                                                "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Section'  and hrjobsd.xssection=mscodesam.xcode " +
                                                "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                                "group by xssection,coalesce(xcodealt,'') " +
                                                "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter dasection = new SqlDataAdapter(query, con);
                                        dasection.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasection.SelectCommand.CommandType = CommandType.Text;
                                        dasection.Fill(dtssection, "temptsection");
                                        DataTable tblsection = new DataTable();
                                        tblsection = dtssection.Tables[0];

                                        xsection.Items.Clear();
                                        xsection.Items.Add("");

                                        if (tblsection.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblsection.Rows)
                                            {
                                                xsection.Items.Add(row["xssection"].ToString());
                                            }
                                        }

                                        xsection.Text = "";

                                    }

                                    if (xclassall == "Yes")
                                    {
                                        xclass.Items.Add("All");
                                        xclass.Text = "All";
                                    }

                                    if (xsectionall == "Yes")
                                    {
                                        xsection.Items.Add("All");
                                        xsection.Text = "All";
                                    }



                                }
                                else if (permission == "css") //Class, Section, Subject & Paper
                                {
                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                             "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                             "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                             "group by xsclass,coalesce(xcodealt,'') " +
                                             "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                    using (DataSet dtssection = new DataSet())
                                    {
                                        //query = "SELECT distinct xssection FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xssection,coalesce(xcodealt,'') " +
                                               "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Section'  and hrjobsd.xssection=mscodesam.xcode " +
                                               "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                               "group by xssection,coalesce(xcodealt,'') " +
                                               "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter dasection = new SqlDataAdapter(query, con);
                                        dasection.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasection.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasection.SelectCommand.CommandType = CommandType.Text;
                                        dasection.Fill(dtssection, "temptsection");
                                        DataTable tblsection = new DataTable();
                                        tblsection = dtssection.Tables[0];

                                        xsection.Items.Clear();
                                        xsection.Items.Add("");

                                        if (tblsection.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblsection.Rows)
                                            {
                                                xsection.Items.Add(row["xssection"].ToString());
                                            }
                                        }

                                        xsection.Text = "";

                                    }


                                    
                                }

                                //message.InnerHtml = permission;
                                //return;

                                /////////////Retrive Teacher's Permission End////////////////
                            }
                        }

                        /////////Retrive Teacher's Position End/////////////
                    }
                }
            }


            ///////////////////Permission Check End/////////////////////////////////
        }

        //public static void fnPermission(DropDownList xclass, DropDownList xsection, string xclassall, string xsectionall)
        //{
        //    fnPermission(xclass,xsection);

        //    if (xclassall == "Yes")
        //    {
        //        xclass.Items.Add("All");
        //        xclass.Text = "All";
        //    }

        //    if (xsectionall == "Yes")
        //    {
        //        xsection.Items.Add("All");
        //        xsection.Text = "All";
        //    }

        //}

        public static void fnPermission(DropDownList xclass)
        {

            if (HttpContext.Current.Session["curuser"].ToString() == "bm")
            {
                zglobal.fnGetComboDataCD("Class", xclass);
                return;
            }
            ///////////////////Permission Check Start/////////////////////////////////

            int _zid = Convert.ToInt32(HttpContext.Current.Session["business"]);

            using (SqlConnection con = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {

                    //DataSet dts = new DataSet();
                    //dts.Reset();
                    string query = "SELECT * FROM ztuser WHERE xuser=@xuser";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@xuser", HttpContext.Current.Session["curuser"].ToString());
                    da.SelectCommand.CommandType = CommandType.Text;
                    da.Fill(dts, "tempztuser");
                    DataTable ztuser = new DataTable();
                    ztuser = dts.Tables[0];

                    //message.InnerHtml = ztuser.Rows[0]["xempcode"].ToString().Trim();
                    //return;

                    string xempcode = "";
                    if (ztuser.Rows.Count > 0)
                    {

                        string xrole = ztuser.Rows[0]["xrole"].ToString();

                        if (xrole == "Director" || xrole == "Super Admin" || xrole == "Director L-A" || xrole == "Director L-B" || xrole == "Administrator" || xrole == "SRO")
                        {
                            zglobal.fnGetComboDataCD("Class", xclass);
                            return;
                        }


                        xempcode = ztuser.Rows[0]["xempcode"].ToString().Trim();

                        /////////Retrive Teacher's Position Start/////////////

                        using (DataSet dts1 = new DataSet())
                        {
                            query = "SELECT * FROM hrjobs WHERE zid=@zid AND xemp=@xemp AND xfdate=(SELECT MAX(xfdate) FROM hrjobs WHERE zid=@zid AND xemp=@xemp)";

                            SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                            da1.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                            da1.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                            da1.SelectCommand.CommandType = CommandType.Text;
                            da1.Fill(dts1, "temphrjobs");
                            DataTable hrjobs = new DataTable();
                            hrjobs = dts1.Tables[0];

                            //message.InnerHtml = hrjobs.Rows[0]["xposition"].ToString();
                            //return;
                            int xline;
                            if (hrjobs.Rows.Count > 0)
                            {
                                /////////////Retrive Teacher's Permission Start////////////////

                                xline = Convert.ToInt32(hrjobs.Rows[0]["xline"].ToString().Trim());

                                string permission = zglobal.fnProperty("Designation", hrjobs.Rows[0]["xposition"].ToString(), "permission");

                                if (permission == "all")
                                {

                                    zglobal.fnGetComboDataCD("Class", xclass);

                                }
                                else if (permission == "sh") //School Head
                                {
                                    using (DataSet dtssch = new DataSet())
                                    {
                                        query = "SELECT xschool FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='School'";

                                        SqlDataAdapter dasch = new SqlDataAdapter(query, con);
                                        dasch.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        dasch.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        dasch.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        dasch.SelectCommand.CommandType = CommandType.Text;
                                        dasch.Fill(dtssch, "temptschool");
                                        DataTable tblschool = new DataTable();
                                        tblschool = dtssch.Tables[0];
                                        if (tblschool.Rows.Count > 0)
                                        {
                                            string school = "";
                                            string stype = "-";

                                            for (int i = 0; i < tblschool.Rows.Count; i++)
                                            {
                                                if (tblschool.Rows[i]["xschool"].ToString() == "Junior School")
                                                {
                                                    stype = "Junior";
                                                }
                                                else if (tblschool.Rows[i]["xschool"].ToString() == "Middle School")
                                                {
                                                    stype = "Middle";
                                                }
                                                else if (tblschool.Rows[i]["xschool"].ToString() == "Senior School")
                                                {
                                                    stype = "Senior";
                                                }


                                                if (i == tblschool.Rows.Count - 1)
                                                {
                                                    school = school + "'" + stype + "'";
                                                }
                                                else
                                                {
                                                    school = school + "'" + stype + "',";
                                                }

                                            }

                                            using (DataSet dtsclass = new DataSet())
                                            {
                                                query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype='Class' AND xprops IN (" + school + ") ORDER BY coalesce(xcodealt,'')";

                                                SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                                daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                                daclass.SelectCommand.Parameters.AddWithValue("@xprops", school);
                                                daclass.SelectCommand.CommandType = CommandType.Text;
                                                daclass.Fill(dtsclass, "temptclass");
                                                DataTable tblclass = new DataTable();
                                                tblclass = dtsclass.Tables[0];

                                                xclass.Items.Clear();
                                                xclass.Items.Add("");

                                                if (tblclass.Rows.Count > 0)
                                                {
                                                    foreach (DataRow row in tblclass.Rows)
                                                    {
                                                        xclass.Items.Add(row["xcode"].ToString());
                                                    }
                                                }

                                                xclass.Text = "";

                                            }
                                        }

                                    }


                                }
                                else if (permission == "class") //Class Coordinator/ Coordinator
                                {

                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject'";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                                "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                                "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                                "group by xsclass,coalesce(xcodealt,'') " +
                                                "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                }
                                else if (permission == "cs") //Calss & Section
                                {
                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject'";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                               "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                               "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                               "group by xsclass,coalesce(xcodealt,'') " +
                                               "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }

                                    



                                }
                                else if (permission == "css") //Class, Section, Subject & Paper
                                {
                                    using (DataSet dtsclass = new DataSet())
                                    {
                                        //query = "SELECT distinct xsclass FROM hrjobsd WHERE zid=@zid AND xemp=@xemp AND xline=@xline AND xtype='Subject' ";
                                        query = "SELECT xsclass,coalesce(xcodealt,'') " +
                                               "FROM hrjobsd inner join mscodesam on hrjobsd.zid=mscodesam.zid and mscodesam.xtype='Class'  and hrjobsd.xsclass=mscodesam.xcode " +
                                               "WHERE hrjobsd.zid=@zid AND xemp=@xemp AND xline=@xline AND hrjobsd.xtype='Subject' " +
                                               "group by xsclass,coalesce(xcodealt,'') " +
                                               "order by coalesce(xcodealt,'')";

                                        SqlDataAdapter daclass = new SqlDataAdapter(query, con);
                                        daclass.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xemp", xempcode);
                                        daclass.SelectCommand.Parameters.AddWithValue("@xline", xline);
                                        daclass.SelectCommand.CommandType = CommandType.Text;
                                        daclass.Fill(dtsclass, "temptclass");
                                        DataTable tblclass = new DataTable();
                                        tblclass = dtsclass.Tables[0];

                                        xclass.Items.Clear();
                                        xclass.Items.Add("");

                                        if (tblclass.Rows.Count > 0)
                                        {
                                            foreach (DataRow row in tblclass.Rows)
                                            {
                                                xclass.Items.Add(row["xsclass"].ToString());
                                            }
                                        }

                                        xclass.Text = "";

                                    }




                                }

                                //message.InnerHtml = permission;
                                //return;

                                /////////////Retrive Teacher's Permission End////////////////
                            }
                        }

                        /////////Retrive Teacher's Position End/////////////
                    }
                }
            }


            ///////////////////Permission Check End/////////////////////////////////
        }


        public static void fnGetListboxValue(string xtype, ListBox lb)
        {
            lb.Items.Clear();
            //combo.Items.Add("[Select]");
            lb.Items.Add("");
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lb.Items.Add(rdr["xcode"].ToString());
                }
            }
            //combo.Text = "[Select]";
           // combo.Text = "";
        }

        

        public static void fnGetComboDataCalendar(DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add("");
            DateTime today = DateTime.Today;
            for (int i = -12; i <= 12; i = i + 1)
            {
                combo.Items.Add(new ListItem(today.AddMonths(i).ToString("MMMM yyyy"), today.AddMonths(i).ToString("MM/dd/yyyy")));
            }
            //using (SqlConnection con = new SqlConnection(constring))
            //{
            //    string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
            //    cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
            //    cmd.CommandType = CommandType.Text;
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        combo.Items.Add(rdr["xcode"].ToString());
            //    }
            //}
            //combo.Text = "[Select]";
            //combo.Text = "";
        }

        public static void fnGetComboDataCalendar(DropDownList combo, DateTime xfdate, DateTime xtdate)
        {
            combo.Items.Clear();

            combo.Items.Add("");

            //int fmonth = xfdate.Month;
            //int fyear = xfdate.Year;
            //int tmonth = xtdate.Month;
            //int tyear = xtdate.Year;
            int month = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "select datediff(MONTH,@xfdate,@xtdate) as month";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@xfdate", xfdate);
                cmd.Parameters.AddWithValue("@xtdate", xtdate);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                month = 0;
                while (rdr.Read())
                {
                    month = Int32.Parse(rdr["month"].ToString());
                }
            }


            for (int i = 0; i <= month; i = i + 1)
            {
                //combo.Items.Add(new ListItem(xfdate.AddMonths(i).ToString("MMM-yyyy"), xfdate.AddMonths(i).ToString("MM/dd/yyyy")));
                combo.Items.Add(xfdate.AddMonths(i).ToString("MMM-yyyy"));
            }


        }

        public static void fnGetComboDataCalendar(DropDownList combo,int _zid)
        {
            combo.Items.Clear();

            combo.Items.Add("");

            int offset;
            int per;
            int year;

            offset = zglobal.fnGetValueInt("xinteger", "msstatus",
                "zid=" + _zid + " and xtypestatus='GL Period Offset'");

            string yrper = zglobal.fnGetValue("xnote", "msstatus",
                    "zid=" + _zid + " and xtypestatus='GL Year/Period'");

            string[] xyrper1 = yrper.Split(',');

            foreach (string val in xyrper1)
            {
                string[] per1 = val.Split('/');

                per = 12 + Convert.ToInt32(per1[1]) - offset;

                if (per <= 12)
                {
                    per = per;
                    year = Convert.ToInt32(per1[0]);
                }
                else
                {
                    per = per - 12;
                    year = Convert.ToInt32(per1[0]) + 1;
                }


                combo.Items.Add(zgetvalue.GetMonthName(per) + "-" + year.ToString());
            }

        }

        public static void fnGetComboDataCD(DropDownList combo)
        {
            combo.Items.Clear();
           
            combo.Items.Add(new ListItem("",""));
            DateTime today = DateTime.Today;
            for (int i = -50; i <= 0; i = i + 1)
            {
                combo.Items.Add(new ListItem(today.AddYears(i).ToString("yyyy"), today.AddYears(i).ToString("yyyy")));
            }
            combo.SelectedValue = "";
        }

        public static void fnGetComboDataCD(string xtype, string xcodealt, DropDownList combo)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add(new ListItem("",""));
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT xcode FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 AND xcodealt=@xcodealt ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.Parameters.AddWithValue("@xcodealt", xcodealt);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    combo.Items.Add(rdr["xcode"].ToString());
                }
            }
            //combo.Text = "[Select]";
            combo.Text = "";
        }

        public static string fnProperty(string xtype, string xcode,string xprops)
        {
            string val = "";
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND xcode=@xcode AND zactive=1 ORDER BY coalesce(xcodealt,'')";
                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]); 
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.Parameters.AddWithValue("@xcode", xcode);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] props = rdr["xprops"].ToString().Split(';');
                    foreach (string prop in props)
                    {
                        string[] sch = prop.Split('=');
                        if (sch[0] == xprops)
                        {
                            val = sch[1];
                            break;
                        }
                    }
                }
            }
            return val;
        }

        public static string fnProperty1(string xtype, string xcode, string xprops)
        {
            string val = "";
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND xcode=@xcode AND zactive=1 ORDER BY coalesce(xcodealt,'')";
                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.Parameters.AddWithValue("@xcode", xcode);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] props = rdr["xcodealt1"].ToString().Split(';');
                    foreach (string prop in props)
                    {
                        string[] sch = prop.Split('=');
                        if (sch[0] == xprops)
                        {
                            val = sch[1];
                            break;
                        }
                    }
                }
            }
            return val;
        }

        public static string fnProperty2(string xtype, string xcode, string xprops)
        {
            string val = "";
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND xcode=@xcode AND zactive=1 ORDER BY coalesce(xcodealt,'')";
                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.Parameters.AddWithValue("@xcode", xcode);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] props = rdr["xprops"].ToString().Split(';');
                    foreach (string prop in props)
                    {
                        string[] sch = prop.Split('=');
                        if (sch[0] == xprops)
                        {
                            val = sch[1];
                            break;
                        }
                    }
                }
            }
            return val;
        }
        public static void fnGetComboDataCD(string xtype, string xprops, DropDownList combo,int xflag)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add(new ListItem("",""));
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                string val = "";
                while (rdr.Read())
                {
                    string[] props = rdr["xprops"].ToString().Split(';');
                    foreach (string prop in props)
                    {
                        string[] sch = prop.Split('=');
                        if (sch[0] == xprops)
                        {
                            val = sch[1];
                            break;
                        }
                    }
                    combo.Items.Add(new ListItem(rdr["xcode"].ToString(),rdr["xcode"].ToString()+"-"+val)); 
                }
            }
            //combo.Text = "[Select]";
            combo.SelectedValue = "";
        }

        public static void fnGetComboDataCD(string xtype, string xprops, DropDownList combo, int xflag,int xline)
        {
            combo.Items.Clear();
            //combo.Items.Add("[Select]");
            combo.Items.Add(new ListItem("", ""));
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT * FROM mscodesam WHERE zid=@zid AND xtype=@xtype AND zactive=1 ORDER BY coalesce(xcodealt,'')";

                SqlCommand cmd = new SqlCommand(query, con);
                string _zid = Convert.ToString(HttpContext.Current.Session["business"]);
                cmd.Parameters.AddWithValue("@zid", Int32.Parse(_zid));
                cmd.Parameters.AddWithValue("@xtype", xtype);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                string val = "";
                while (rdr.Read())
                {
                    string[] props = rdr["xprops"].ToString().Split(';');
                    foreach (string prop in props)
                    {
                        string[] sch = prop.Split('=');
                        if (sch[0] == xprops)
                        {
                            val = sch[1];
                            if (Int32.Parse(val) == xflag)
                            {
                                combo.Items.Add(rdr["xcode"].ToString());
                                break;
                            }
                        }
                    }
                    //combo.Items.Add(new ListItem(rdr["xcode"].ToString(), rdr["xcode"].ToString() + "-" + val));
                }
              
            }
            //combo.Text = "[Select]";
            combo.SelectedValue = "";
        }

        public static void fnDeleteBusinessGLMSTPermis(string zemail, string xsession)
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //string query = delglmstbiz;
                string query = delglmstbiz2;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@zemail", zemail);
                cmd.Parameters.AddWithValue("@xsession", xsession);
                cmd.ExecuteNonQuery();

                //query = delglmstbiz2;
                //cmd.CommandText = query;
                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }


        //public static void fnRecordLog(DateTime ztime, int zid, string xdesc, string xaction, string xemail, DateTime xdate, string xobject, string xname, string xvoucher, int xrow)
        //{
        //    using (SqlConnection conn = new SqlConnection(zglobal.constring))
        //    {
        //        conn.Open();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        string query = "INSERT INTO zreclog (ztime,zid,xrecnum,xdesc,xaction,xemail,xdate,xobject,xname,xvoucher,xrow) " +
        //                    "VALUES(@ztime,@zid,@xrecnum,@xdesc,@xaction,@xemail,@xdate,@xobject,@xname,@xvoucher,@xrow) ";
        //        cmd.CommandText = query;
        //        string xrecnum = "";
        //        cmd.Parameters.AddWithValue("@ztime", ztime);
        //        cmd.Parameters.AddWithValue("@zid", zid);
        //        cmd.Parameters.AddWithValue("@xrecnum", xrecnum);
        //        cmd.Parameters.AddWithValue("@xdesc", xdesc);
        //        cmd.Parameters.AddWithValue("@xaction", xaction);
        //        cmd.Parameters.AddWithValue("@xemail", xemail);
        //        cmd.Parameters.AddWithValue("@xdate", xdate);
        //        cmd.Parameters.AddWithValue("@xobject", xobject);
        //        cmd.Parameters.AddWithValue("@xname", xname);
        //        cmd.Parameters.AddWithValue("@xvoucher", xvoucher);
        //        cmd.Parameters.AddWithValue("@xrow", xrow);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //}

        public static void fnDeleteBusinessCusAR(string zemail, string xsession)
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string query = delmscusar;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@zemail", zemail);
                cmd.Parameters.AddWithValue("@xsession", xsession);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }


        public static void fnDeleteBusinessCusAR1(string zemail, string xsession)
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string query = delmscusar1;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@zemail", zemail);
                cmd.Parameters.AddWithValue("@xsession", xsession);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }


        public static void fnDeleteBusinessSupAP(string zemail, string xsession)
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string query = delmssupap;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@zemail", zemail);
                cmd.Parameters.AddWithValue("@xsession", xsession);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public static void fnDeleteBusiness(string zemail, string xsession)
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string query = delzid;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@zemail", zemail);
                cmd.Parameters.AddWithValue("@xsession", xsession);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public static void fnDeleteBusiness1(string zemail, string xsession, string zid)
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string query = "DELETE FROM ztemporary WHERE " + zid + " IS NOT NULL and zemail=@zemail and xsession=@xsession";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@zemail", zemail);
                cmd.Parameters.AddWithValue("@xsession", xsession);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public static DataTable fnCheckBusiness(string query)
        {
            using (SqlConnection conn = new SqlConnection(zglobal.constring))
            {
                using (DataSet dts = new DataSet())
                {
                    conn.Open();

                    //try
                    //{
                    //string query = "SELECT * FROM ztemporary WHERE zid2 IS NOT NULL and zemail=@zemail and xsession=@xsession";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@zemail", HttpContext.Current.Session["curuser"]);
                    da.SelectCommand.Parameters.AddWithValue("@xsession", HttpContext.Current.Session.SessionID);
                    DataTable tempTable = new DataTable();
                    da.Fill(dts, "tempTable");
                    tempTable = dts.Tables["tempTable"];
                    return tempTable;
                    //}

                    //catch (Exception exp)
                    //{
                    //    Response.Write(exp.Message);
                    //}
                }
            }
        }

        public static string fnGetBusinessName(string zid)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                conn.Open();

                DataSet dts = new DataSet();
                string query = "select zorg from zbusiness where zid=@zid";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@zid", Convert.ToInt32(zid));
                da.Fill(dts, "temp");
                DataTable temp = new DataTable();
                temp = dts.Tables["temp"];
                if (!Convert.IsDBNull(temp.Rows[0][0]))
                {
                    return temp.Rows[0][0].ToString();
                }
                else
                {
                    return "0";
                }
                dts.Dispose();
                da.Dispose();
                temp.Dispose();
            }
        }

        public static void fnRecordLog(string xdesc, string xaction, string xobject, string xname, string xvoucher, int xrow, DateTime xdate)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string query = "INSERT INTO zreclog (ztime,zid,xrecnum,xdesc,xaction,xemail,xdate,xobject,xname,xvoucher,xrow) " +
                               "VALUES(@ztime,@zid,@xrecnum,@xdesc,@xaction,@xemail,@xdate,@xobject,@xname,@xvoucher,@xrow) ";
                DateTime ztime = DateTime.Now;
                int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                string xrecnum = GetMaximumInvoiceResetMonthlyBusiness("xdate", "xrecnum", "zreclog", "LOG-", DateTime.Now, "reclog");
                string zemail1 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ztime", ztime);
                cmd.Parameters.AddWithValue("@zid", _zid);
                cmd.Parameters.AddWithValue("@xrecnum", xrecnum);
                cmd.Parameters.AddWithValue("@xdesc", xdesc);
                cmd.Parameters.AddWithValue("@xaction", xaction);
                cmd.Parameters.AddWithValue("@xemail", zemail1);
                cmd.Parameters.AddWithValue("@xdate", xdate);
                cmd.Parameters.AddWithValue("@xobject", xobject);
                cmd.Parameters.AddWithValue("@xname", xname);
                cmd.Parameters.AddWithValue("@xvoucher", xvoucher);
                cmd.Parameters.AddWithValue("@xrow", xrow);
                cmd.ExecuteNonQuery();

            }
        }

        //[WebMethod(EnableSession = true)]
        public static string fnSideList(string xdate2, string xcoach2, string xuser2, string xloc2, string optfor)
        {

            SqlConnection conn2;
            conn2 = new SqlConnection(constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();
            string str2;


            if (optfor == "xsold")
            {
                //str2 = "SELECT COUNT(*) FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('sold','forsale','mansale') AND xuser=@xuser AND xloc=@xloc";
                //str2 = "SELECT SUM(c) FROM " +
                //       " (SELECT COUNT(*) as c FROM ztsaled WHERE xsolddt=@xdate AND xstatus IN ('sold','forsale','mansale') AND xuser=@xuser AND xloc=@xloc " +
                //       "  UNION ALL " +
                //       "  SELECT COUNT(*) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xsolddt=@xdate AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold') AND xuser=@xuser AND xloc=@xloc) as b";
                //str2 = "select " +
                //       " ((select count(*) from ztsalevw where xaction='Sold' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc) " +
                //       " - (select count(*) from ztsalevw where xaction='Canceled' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc)) as b";
                str2 = "select count(*) from ztsalevw where xaction='Sold' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc";
            }
            else if (optfor == "xtotalsold")
            {
                //str2 = "select SUM(xrate) from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','forsale','mansale') and xuser=@xuser AND xloc=@xloc";
                //str2 = "SELECT SUM(c) FROM " +
                //      " (SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled WHERE xsolddt=@xdate AND xstatus IN ('sold','forsale','mansale') and xuser=@xuser AND xloc=@xloc " +
                //      "  UNION ALL " +
                //      "  SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xsolddt=@xdate AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold') and xuser=@xuser AND xloc=@xloc) as b";

                str2 = "select " +
                       " ((select COALESCE (sum(xnetamt), 0) from ztsalevw where xaction='Sold' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc) " +
                       " - (select COALESCE (sum(xnetamt), 0) from ztsalevw where xaction='Canceled' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc)) as b";

            }
            else if (optfor == "xtbooked")
            {
                str2 = "SELECT COUNT(*) FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('booking','confbooking')";
            }
            else if (optfor == "xtsold")
            {
                str2 = "SELECT SUM(c) FROM " +
                       " (SELECT COUNT(*) as c FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('sold','forsale','mansale') " +
                       "  UNION ALL " +
                       "  SELECT COUNT(*) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xdate=@xdate AND ztsaled.xcoach=@xcoach AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold')) as b";
            }
            else if (optfor == "xtamount")
            {
                //str2 = "select SUM(xrate) from ztsaled where xdate=@xdate and xcoach=@xcoach and xstatus IN ('sold','forsale','mansale')";
                str2 = "SELECT SUM(c) FROM " +
                     " (SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled WHERE xdate=@xdate AND xcoach=@xcoach AND xstatus IN ('sold','forsale','mansale') " +
                     "  UNION ALL " +
                     "  SELECT sum(COALESCE (ztsaled.xrate, 0) - COALESCE (ztsaled.xdiscount, 0)) as c FROM ztsaled inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd WHERE ztsaled.xdate=@xdate AND ztsaled.xcoach=@xcoach AND ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in ('mansale','sold')) as b";

            }
            else
            {
                //str2 = "select COUNT(*) from ztcancelreq where xapprovedt=@xdate and xreqby=@xreqby and xreqloc=@xreqloc and xstatus='approved' and xremark not in('confbooking')";
                str2 = "select count(*) from ztsalevw where xaction='Canceled' and xsolddt=convert(datetime, convert(varchar(10), GETDATE(), 101)) and xuser=@xuser and xloc=@xloc";
            }


            if (optfor == "xsold" || optfor == "xcan" || optfor == "xtotalsold")
            {
                xdate2 = DateTime.Now.ToString("MM/dd/yyyy");
            }


            if (optfor == "xsold" || optfor == "xcan" || optfor == "xtotalsold")
            {
                xdate2 = DateTime.Now.ToString("MM/dd/yyyy");
            }
            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);
            //da2.SelectCommand.Parameters.AddWithValue("@xstatus",xstatus2);
            da2.SelectCommand.Parameters.AddWithValue("@xuser", xuser2);
            da2.SelectCommand.Parameters.AddWithValue("@xloc", xloc2);
            da2.SelectCommand.Parameters.AddWithValue("@xreqby", xuser2);
            da2.SelectCommand.Parameters.AddWithValue("@xreqloc", xloc2);

            da2.Fill(dts2, "temp");
            DataTable zttemp = new DataTable();
            zttemp = dts2.Tables["temp"];

            if (!Convert.IsDBNull(zttemp.Rows[0][0]))
            {
                return zttemp.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }


        }

        public static DataTable fnSideGridView(string xdate2, string xcoach2, string optfor)
        {
            SqlConnection conn2;
            conn2 = new SqlConnection(constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();
            string str2;

            if (optfor == "sold")
            {
                //str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser from ztsaleh " +
                //       " inner join ztsaled on ztsaleh.xid=ztsaled.xid where ztsaled.xdate=@xdate " +
                //       " and ztsaled.xcoach=@xcoach and xstatus IN ('sold','forsale','mansale') "; //,'cancelpending'

                str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztseatsl.xline from ztsaleh " +
                       " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                       " and ztsaled.xcoach=@xcoach and xstatus IN ('sold','forsale','mansale') " +
                       " UNION ALL " +
                       " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, ztsaleh.xticket,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination,(select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztseatsl.xline from ztsaleh " +
                       " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                       " and ztsaled.xcoach=@xcoach and ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in('mansale','sold') order by ztseatsl.xline";
            }
            else
            {
                str2 = " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, (select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination, (cast(ztsaleh.xdateexp as varchar) + ' ' + ztsaleh.xtimeexp) as xexpired,ztseatsl.xline  from ztsaleh " +
                      " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                      " and ztsaled.xcoach=@xcoach and xstatus IN ('booking','confbooking')  " +
                       " UNION ALL " +
                      " select ztsaled.xseat, ztsaleh.xname, ztsaleh.xphone, (select xusername from ztuser where ztuser.xuser=ztsaled.xuser) as xuser,ztsaleh.xboarding,(select trt from ztroute where srt=ztsaled.xroute) as xdestination, (cast(ztsaleh.xdateexp as varchar) + ' ' + ztsaleh.xtimeexp) as xexpired,ztseatsl.xline  from ztsaleh  " +
                      " inner join ztsaled on ztsaleh.xid=ztsaled.xid inner join ztcancelreq on ztsaled.xrow=ztcancelreq.xrowd inner join ztseatsl on ztsaled.xseat=ztseatsl.xseat where ztsaled.xdate=@xdate " +
                      " and ztsaled.xcoach=@xcoach and ztsaled.xstatus IN ('cancelpending') and ztcancelreq.xstatus='pending' and ztcancelreq.xremark in('confbooking') order by ztseatsl.xline";
            }

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);

            da2.SelectCommand.Parameters.AddWithValue("@xdate", xdate2);
            da2.SelectCommand.Parameters.AddWithValue("@xcoach", xcoach2);

            da2.Fill(dts2, "temp");
            DataTable zttemp = new DataTable();
            zttemp = dts2.Tables["temp"];

            return zttemp;


        }



        public static string fnmaxid(string query)
        {
            DateTime dt = DateTime.Now;
            DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2 = query;
            //string prefix;

            //prefix = "rec";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            //string firstdate = firstDate.ToString();
            //string lastdate = lastDate.ToString();
            //txtDue.Text = date;
            da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstDate);
            da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastDate);
            da2.Fill(dts2, "temp");
            DataTable xid1 = new DataTable();
            xid1 = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
            {
                string s = xid1.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 5));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "0" + s2;
                }

                maxrow = dt.ToString("MMyyyy") + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = dt.ToString("MMyyyy") + "00001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }


        public static string fnmaxidlong(string query)
        {
            DateTime dt = DateTime.Now;
            DateTime firstDate = new DateTime(dt.Year, dt.Month, 1);
            DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
            DateTime lastDate = lastDate1.Date.AddMinutes(1439);

            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2 = query;
            //string prefix;

            //prefix = "rec";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            string firstdate = firstDate.ToString();
            string lastdate = lastDate.ToString();
            //txtDue.Text = date;
            da2.SelectCommand.Parameters.AddWithValue("@firstdate", firstdate);
            da2.SelectCommand.Parameters.AddWithValue("@lastdate", lastdate);
            da2.Fill(dts2, "temp");
            DataTable xid1 = new DataTable();
            xid1 = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
            {
                string s = xid1.Rows[0][0].ToString();
                long vno = Convert.ToInt64(s.Substring(s.Length - 8));
                ////txtDue.Text = vno.ToString();
                long vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "0000000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "000000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "00000" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 5)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 6)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 7)
                {
                    s2 = "0" + s2;
                }

                maxrow = dt.ToString("MMyyyy") + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = dt.ToString("MMyyyy") + "00000001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }


        public static string fnBookingAutoCancel(string cxdate2, string cxcoach2, string xid)
        {
            try
            {
                SqlConnection conn22;
                conn22 = new SqlConnection(constring);
                DataSet dts22 = new DataSet();
                dts22.Reset();
                string str22 = "SELECT xseat,xroute from ztsaled where xid=@xid and xstatus='booking'";

                SqlDataAdapter da22 = new SqlDataAdapter(str22, conn22);

                da22.SelectCommand.Parameters.AddWithValue("@xid", xid);

                da22.Fill(dts22, "temp");
                DataTable dttemp = new DataTable();
                dttemp = dts22.Tables[0];



                using (TransactionScope tran = new TransactionScope())
                {

                    SqlConnection conn1;
                    conn1 = new SqlConnection(zglobal.constring);
                    SqlCommand dataCmd = new SqlCommand();
                    dataCmd.Connection = conn1;
                    string query;


                    /* insert data into ztlog  */

                    query = "INSERT INTO ztlogs" +
                                 "(xrow,xid,xdate,xcoach,xseat,xdatetime,xform,xbutton,xstatus,xuser,xlocation,xroute) " +
                                 "VALUES (@xrow,@xid,@xdate,@xcoach,@xseat,@xdatetime,@xform,@xbutton,@xstatus,@xuser,@xlocation,@xroute) ";




                    string xrow3;
                    string xdate3 = cxdate2;
                    string xcoach3 = cxcoach2;
                    //string[] xseat4 = cxseat2.Split(',');
                    string xdatetime3 = Convert.ToString(DateTime.Now);
                    string xform3 = "booking";
                    string xbutton3 = "cancel";
                    string xstatus3 = "autocancelbooking";
                    string xuser3 = Convert.ToString(HttpContext.Current.Session["curuser"]);
                    string xlocation3 = Convert.ToString(HttpContext.Current.Session["xlocation"]);

                    conn1.Close();
                    conn1.Open();

                    dataCmd.CommandText = query;
                    // dataCmd1.Transaction = transec;

                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {



                        dataCmd.CommandText = query;


                        //xrow3 = zttestbus.fnmaxrow("select max(xrow) from ztlogs");
                        xrow3 = zttestbus.fnmaxidforlog(xdate3);

                        dataCmd.Parameters.Clear();
                        dataCmd.Parameters.AddWithValue("@xrow", xrow3);
                        dataCmd.Parameters.AddWithValue("@xid", xid);
                        dataCmd.Parameters.AddWithValue("@xdate", xdate3);
                        dataCmd.Parameters.AddWithValue("@xcoach", xcoach3);
                        dataCmd.Parameters.AddWithValue("@xseat", dttemp.Rows[i][0].ToString());
                        dataCmd.Parameters.AddWithValue("@xdatetime", xdatetime3);
                        dataCmd.Parameters.AddWithValue("@xform", xform3);
                        dataCmd.Parameters.AddWithValue("@xbutton", xbutton3);
                        dataCmd.Parameters.AddWithValue("@xstatus", xstatus3);
                        dataCmd.Parameters.AddWithValue("@xuser", xuser3);
                        dataCmd.Parameters.AddWithValue("@xlocation", xlocation3);
                        dataCmd.Parameters.AddWithValue("@xroute", dttemp.Rows[i][1].ToString());



                        dataCmd.ExecuteNonQuery();

                        //dataCmd1.Dispose();
                    }

                    /* delete data from ztsaled */

                    query = "UPDATE ztsaled SET xstatus='autocancelbooking' " +
                                     "WHERE xid=@xid and xstatus='booking'";

                    //string xstatus5 = "cancel";
                    string xdate5 = cxdate2;
                    string xcoach5 = cxcoach2;
                    // string[] xseat5 = cxseat2.Split(',');


                    dataCmd.CommandText = query;




                    dataCmd.Parameters.Clear();

                    dataCmd.Parameters.AddWithValue("@xid", xid);

                    dataCmd.ExecuteNonQuery();



                    tran.Complete();


                    dataCmd.Dispose();
                    conn1.Dispose();
                }

            }
            catch (Exception exp)
            {

                return exp.Message;
            }




            return "success";
        }


        public static string GetMaximumId(string query)
        {
            string maxId = "";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    maxId = tempTable.Rows[0][0].ToString();

                    da.Dispose();
                }
            }
            return maxId;
        }


        public static void fnComboMonth(DropDownList cbo)
        {

            cbo.Items.Clear();
            string[] month = new string[12]
                {
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };

            for (int i = 0; i < month.Length; i++)
            {
                cbo.Items.Add(new ListItem(month[i], i<9 ? "0"+(i + 1).ToString() :(i + 1).ToString()));
            }
        }

        public static void fnComboPayType(DropDownList cbo)
        {

            cbo.Items.Clear();
            string[] month = new string[5]
                {
                    "Monthly Rated",
                    "Held",
                    "Non-Pay",
                    "Hourly Rated",
                    "Daily Rated"
                };

            for (int i = 0; i < month.Length; i++)
            {
                cbo.Items.Add(month[i]);
            }
        }

        public static void fnComboEmpStatus(DropDownList cbo)
        {

            cbo.Items.Clear();
            cbo.Items.Add("A-Active");
            cbo.Items.Add("D-Dismissed");
            cbo.Items.Add("H-Hold");
            cbo.Items.Add("R-Resigned");
            cbo.Items.Add("T-Terminated");
            cbo.Text = "A-Active";
        }


        public static void fnComboJobNature(DropDownList cbo)
        {

            cbo.Items.Clear();
            cbo.Items.Add("");
            cbo.Items.Add("Regular");
            cbo.Items.Add("Temporary");
            cbo.Items.Add("Contact");
            cbo.Items.Add("Probation");
            cbo.Text = "";
        }

        public static void fnComboWeekDay(DropDownList cbo)
        {

            cbo.Items.Clear();
            cbo.Items.Add("");
            cbo.Items.Add("Sunday");
            cbo.Items.Add("Monday");
            cbo.Items.Add("Tuesday");
            cbo.Items.Add("Wednesday");
            cbo.Items.Add("Thursday");
            cbo.Items.Add("Friday");
            cbo.Items.Add("Saturday");
            cbo.Text = "";
        }


        public static void fnComboDays(DropDownList cbo, int min, int max)
        {

            cbo.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                cbo.Items.Add(i<10?"0"+i.ToString():i.ToString());
            }
        }

        public static int GetMaximumID(string xfield, string xtable, string condition)
        {
            int maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {

                    string query = "SELECT COALESCE(CONVERT(varchar(6),GETDATE(),112)+" +
                                   "CAST(REPLICATE(0,3-LEN(CAST(RIGHT(MAX(" + xfield + "),3) as int)+1)) as varchar(10)) +" +
                                   " CAST(CAST(RIGHT(MAX(" + xfield + "),3) as int)+1 as varchar(10))," +
                                   "CONVERT(varchar(6),GETDATE(),112)+'001') as maxid FROM " + xtable +
                                    " WHERE " + condition;
                    //string query = "SELECT COALESCE(MAX("+ xfield +")+1,1) FROM " + xtable + " WHERE " + condition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    maxId = Int32.Parse(tempTable.Rows[0][0].ToString());
                    da.Dispose();
                }
            }
            return maxId;
        }

        public static int GetMaximumIdInt(string xfield, string xtable, string condition)
        {
            int maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
                    DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    string query = "SELECT COALESCE(CONVERT(varchar(6),GETDATE(),112)+" +
                                   "CAST(REPLICATE(0,3-LEN(CAST(RIGHT(MAX(" + xfield + "),3) as int)+1)) as varchar(10)) +" +
                                   " CAST(CAST(RIGHT(MAX(" + xfield + "),3) as int)+1 as varchar(10))," +
                                   "CONVERT(varchar(6),GETDATE(),112)+'001') as maxid FROM " + xtable +
                                    " WHERE cast(ztime as date) BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND " + condition;
                    //string query = "SELECT COALESCE(MAX("+ xfield +")+1,1) FROM " + xtable + " WHERE " + condition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    maxId = Int32.Parse(tempTable.Rows[0][0].ToString());
                    da.Dispose();
                }
            }
            return maxId;
        }

        public static Int64 GetMaximumIdInt(string xfield, string xtable, string condition, int flag)
        {
            Int64 maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(DateTime.Today.Year, 1, 1);
                    DateTime lastDate = new DateTime(DateTime.Today.Year, 12, 31);
                    //DateTime lastDate = lastDate1.Date.AddMinutes(1439);
                    string query = "";

                    if (flag == 200)
                    {
                        query = "SELECT  COALESCE( CAST(REPLICATE(0,1-LEN(CAST(RIGHT(MAX(" + xfield + "),1) as int)+1)) as varchar(10)) +  " +
                                "CAST(CAST(RIGHT(MAX(" + xfield + "),1) as int)+1 as varchar(10)),'1') as maxid FROM " + xtable +
                                " WHERE cast(ztime as date) BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND " + condition;

                    }
                    else
                    {
                        query = "SELECT COALESCE(CONVERT(varchar(4),GETDATE(),112)+" +
                                "CAST(REPLICATE(0,6-LEN(CAST(RIGHT(MAX(" + xfield + "),6) as int)+1)) as varchar(10)) +" +
                                " CAST(CAST(RIGHT(MAX(" + xfield + "),6) as int)+1 as varchar(10))," +
                                "CONVERT(varchar(4),GETDATE(),112)+'000001') as maxid FROM " + xtable +
                                " WHERE cast(ztime as date) BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND " + condition;
                    }

                    //string query = "SELECT COALESCE(MAX("+ xfield +")+1,1) FROM " + xtable + " WHERE " + condition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    maxId = Int64.Parse(tempTable.Rows[0][0].ToString());
                    da.Dispose();
                }
            }
            return maxId;
        }

        public static int GetMaximumIdInt(string xfield, string xtable, string condition, int flag1, int flag2)
        {
            int maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(DateTime.Today.Year, 1, 1);
                    DateTime lastDate = new DateTime(DateTime.Today.Year, 12, 31);
                    //DateTime lastDate = lastDate1.Date.AddMinutes(1439);
                    string query = "SELECT COALESCE(CONVERT(varchar(4),GETDATE(),112)+" +
                                "CAST(REPLICATE(0,6-LEN(CAST(RIGHT(MAX(" + xfield + "),6) as int)+1)) as varchar(10)) +" +
                                " CAST(CAST(RIGHT(MAX(" + xfield + "),6) as int)+1 as varchar(10))," +
                                "CONVERT(varchar(4),GETDATE(),112)+'000001') as maxid FROM " + xtable +
                                " WHERE cast(ztime as date) BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND " + condition;

                    //string query = "SELECT COALESCE(MAX("+ xfield +")+1,1) FROM " + xtable + " WHERE " + condition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    maxId = int.Parse(tempTable.Rows[0][0].ToString());
                    da.Dispose();
                }
            }
            return maxId;
        }

        public static string GetRollNo(string xfield, string xtable, string condition, int flag)
        {
            string roll;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(DateTime.Today.Year, 1, 1);
                    DateTime lastDate = new DateTime(DateTime.Today.Year, 12, 31);
                    //DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    string query = "SELECT COALESCE(RIGHT(CONVERT(varchar(4),GETDATE(),112),2)+" +
                                   "CAST(REPLICATE(0,4-LEN(CAST(RIGHT(MAX(" + xfield + "),4) as int)+1)) as varchar(10)) +" +
                                   " CAST(CAST(RIGHT(MAX(" + xfield + "),4) as int)+1 as varchar(10))," +
                                   "RIGHT(CONVERT(varchar(4),GETDATE(),112),2)+'0001') as maxid FROM " + xtable +
                                    " WHERE cast(ztime as date) BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND " + condition;

                    //string query = "SELECT COALESCE(MAX("+ xfield +")+1,1) FROM " + xtable + " WHERE " + condition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    roll = tempTable.Rows[0][0].ToString();
                    da.Dispose();
                }
            }
            return roll;
        }

        public static int GetMaximumIdInt(string xfield, string xtable, string condition, string xline)
        {
            int maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT COALESCE(MAX(CAST(" + xfield + " AS int))+1,1) FROM " + xtable + " WHERE " + condition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    maxId = Int32.Parse(tempTable.Rows[0][0].ToString());
                    da.Dispose();
                }
            }
            return maxId;
        }

        public static int GetMaximumIdInt(string xfield, string xtable, string condition, string xline, int increment)
        {
            int maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT COALESCE(MAX(CAST(" + xfield + " AS int))+"+increment+",10) FROM " + xtable + " WHERE " + condition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    maxId = Int32.Parse(tempTable.Rows[0][0].ToString());
                    da.Dispose();
                }
            }
            return maxId;
        }

        public static int GetMaximumIdInt(string xfield, string xtable)
        {
            int maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT COALESCE(MAX(" + xfield + ")+1,1) FROM " + xtable;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    maxId = Int32.Parse(tempTable.Rows[0][0].ToString());
                    da.Dispose();
                }
            }
            return maxId;
        }

       



        public static string GetMaximumInvoiceResetMonthly(string InvoiceDateField, string InvNoField, string tblName, string prefix, DateTime InvDate)
        {
            string maxId = "";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(InvDate.Year, InvDate.Month, 1);
                    DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
                    DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    string query = "SELECT COALESCE('" + prefix + "'+CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+" +
                                   "'-'+CAST(REPLICATE(0,4-LEN(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1)) as varchar(10)) +" +
                                   " CAST(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1 as varchar(10))," +
                                   "'" + prefix + "'+CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+'-0001') as maxid FROM " + tblName +
                                    " WHERE " + InvoiceDateField + " BETWEEN '" + firstDate + "' AND '" + lastDate + "'";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    maxId = tempTable.Rows[0][0].ToString();

                    da.Dispose();
                }
            }
            return maxId;
        }


        public static string GetMaximumInvoiceResetMonthlyBusiness(string InvoiceDateField, string InvNoField, string tblName, string prefix, DateTime InvDate)
        {
            string maxId = "";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(InvDate.Year, InvDate.Month, 1);
                    DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
                    DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    string query = "SELECT COALESCE('" + prefix + "'+CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+" +
                                   "'-'+CAST(REPLICATE(0,4-LEN(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1)) as varchar(10)) +" +
                                   " CAST(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1 as varchar(10))," +
                                   "'" + prefix + "'+CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+'-0001') as maxid FROM " + tblName +
                                    " WHERE " + InvoiceDateField + " BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND zid=@zid";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    maxId = tempTable.Rows[0][0].ToString();

                    da.Dispose();
                }
            }
            return maxId;
        }

        public static int GetMaximumInvoiceResetMonthlyBusiness(string InvoiceDateField, string InvNoField, string tblName, DateTime InvDate)
        {
            int maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(InvDate.Year, InvDate.Month, 1);
                    DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
                    DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    string query = "SELECT COALESCE(CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+" +
                                   "CAST(REPLICATE(0,4-LEN(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1)) as varchar(10)) +" +
                                   " CAST(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1 as varchar(10))," +
                                   "CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+'0001') as maxid FROM " + tblName +
                                    " WHERE " + InvoiceDateField + " BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND zid=@zid";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    maxId = Convert.ToInt32(tempTable.Rows[0][0].ToString());

                    da.Dispose();
                }
            }
            return maxId;
        }

        public static string GetMaximumInvoiceResetMonthlyBusiness(string InvoiceDateField, string InvNoField, string tblName, string prefix, DateTime InvDate, string xreclog)
        {
            string maxId = "";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(InvDate.Year, InvDate.Month, 1);
                    DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
                    DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    string query = "SELECT COALESCE('" + prefix + "'+CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+" +
                                   "'-'+CAST(REPLICATE(0,8-LEN(CAST(RIGHT(MAX(" + InvNoField + "),8) as int)+1)) as varchar(10)) +" +
                                   " CAST(CAST(RIGHT(MAX(" + InvNoField + "),8) as int)+1 as varchar(10))," +
                                   "'" + prefix + "'+CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+'-00000001') as maxid FROM " + tblName +
                                    " WHERE " + InvoiceDateField + " BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND zid=@zid";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    maxId = tempTable.Rows[0][0].ToString();

                    da.Dispose();
                }
            }
            return maxId;
        }

        public static string fnRowValue(string tblField, string tblName, int row)
        {
            string value = "";
            using (SqlConnection connRowConnection = new SqlConnection(constring))
            {
                using (DataSet dtsRowDataSet = new DataSet())
                {
                    string query = "SELECT " + tblField + " FROM " + tblName + " WHERE xrow=@xrow";

                    // return query;
                    SqlDataAdapter daRowValueAdapter = new SqlDataAdapter(query, connRowConnection);
                    daRowValueAdapter.SelectCommand.Parameters.AddWithValue("@xrow", row);
                    daRowValueAdapter.Fill(dtsRowDataSet, "tempTable");
                    DataTable tempTableRowDataTable = new DataTable();
                    tempTableRowDataTable = dtsRowDataSet.Tables["tempTable"];

                    value = tempTableRowDataTable.Rows[0][0].ToString();

                    daRowValueAdapter.Dispose();
                    dtsRowDataSet.Clear();
                    tempTableRowDataTable.Dispose();
                }
            }
            return value;
        }

        public static string GetMaximumIDWithTRN(string xtrn, string xfield, string tblName)
        {
            string maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    //DateTime firstDate = new DateTime(InvDate.Year, InvDate.Month, 1);
                    //DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
                    //DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    //string query = "SELECT COALESCE(CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+" +
                    //               "CAST(REPLICATE(0,4-LEN(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1)) as varchar(10)) +" +
                    //               " CAST(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1 as varchar(10))," +
                    //               "CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+'0001') as maxid FROM " + tblName +
                    //                " WHERE " + InvoiceDateField + " BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND zid=@zid";

                    string query = " select coalesce(@xtrn + replicate(0,6-len(max(right(" + xfield +
                            ",6)+1))) + cast(max(right(" + xfield + ",6))+1 as varchar(6)), @xtrn +'000001' ) " +
                            "from  " + tblName +
                            " where left(" + xfield + ",4) like '%'+@xtrn+'%' and zid=@zid";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xtrn", xtrn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    maxId = tempTable.Rows[0][0].ToString();

                    da.Dispose();
                }
            }
            return maxId;
        }

        public static string GetMaximumIDWithTRNAcc(string xtrn, string xfield, string tblName, DateTime xdate, string InvoiceDateField)
        {
            string maxId;
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    DateTime firstDate = new DateTime(xdate.Year, xdate.Month, 1);
                    DateTime lastDate1 = firstDate.AddMonths(1).AddDays(-1);
                    DateTime lastDate = lastDate1.Date.AddMinutes(1439);

                    //string query = "SELECT COALESCE(CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+" +
                    //               "CAST(REPLICATE(0,4-LEN(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1)) as varchar(10)) +" +
                    //               " CAST(CAST(RIGHT(MAX(" + InvNoField + "),4) as int)+1 as varchar(10))," +
                    //               "CONVERT(varchar(6),cast('" + InvDate + "' as date),112)+'0001') as maxid FROM " + tblName +
                    //                " WHERE " + InvoiceDateField + " BETWEEN '" + firstDate + "' AND '" + lastDate + "' AND zid=@zid";

                    string query = " select coalesce(@xtrn + CONVERT(varchar(4),cast(@xdate as date),12) + '-' + replicate(0,4-len(max(right(" + xfield +
                            ",4)+1))) + cast(max(right(" + xfield + ",4))+1 as varchar(4)), @xtrn + CONVERT(varchar(4),cast(@xdate as date),12) + '-' +'0001' ) " +
                            "from  " + tblName +
                            " where left(" + xfield + ",4) like '%'+@xtrn+'%' and zid=@zid and " + InvoiceDateField + " BETWEEN '" + firstDate + "' AND '" + lastDate + "'";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    int _zid = Convert.ToInt32(Convert.ToString(HttpContext.Current.Session["business"]));
                    da.SelectCommand.Parameters.AddWithValue("@zid", _zid);
                    da.SelectCommand.Parameters.AddWithValue("@xtrn", xtrn);
                    da.SelectCommand.Parameters.AddWithValue("@xdate", xdate);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    maxId = tempTable.Rows[0][0].ToString();

                    da.Dispose();
                }
            }
            return maxId;
        }

        public static string fnChkStatus(string tblField, string tblName, int row)
        {
            string value = "";
            using (SqlConnection connChkStatusConnection = new SqlConnection(constring))
            {
                using (DataSet dtsChkStatusDataSet = new DataSet())
                {
                    string query = "SELECT coalesce(" + tblField + ",'Open') FROM " + tblName + " WHERE xrow=@xrow";

                    SqlDataAdapter daChkStatuSqlDataAdapter = new SqlDataAdapter(query, connChkStatusConnection);
                    daChkStatuSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@xrow", row);
                    daChkStatuSqlDataAdapter.Fill(dtsChkStatusDataSet, "tempTable");
                    DataTable tempTableChkStatusDataTable = new DataTable();
                    tempTableChkStatusDataTable = dtsChkStatusDataSet.Tables["tempTable"];

                    value = tempTableChkStatusDataTable.Rows[0][0].ToString();

                    daChkStatuSqlDataAdapter.Dispose();
                    dtsChkStatusDataSet.Clear();
                    tempTableChkStatusDataTable.Dispose();
                }
            }
            return value;
        }

        public static string fnChkRoll(int zid, Int64 row)
        {
            string value = "";
            using (SqlConnection connChkStatusConnection = new SqlConnection(constring))
            {
                using (DataSet dtsChkStatusDataSet = new DataSet())
                {
                    string query = "SELECT coalesce(xstdid,'') FROM amadmis WHERE zid=@zid AND xrow=@xrow";

                    SqlDataAdapter daChkStatuSqlDataAdapter = new SqlDataAdapter(query, connChkStatusConnection);
                    daChkStatuSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zid", zid);
                    daChkStatuSqlDataAdapter.SelectCommand.Parameters.AddWithValue("@xrow", row);
                    daChkStatuSqlDataAdapter.Fill(dtsChkStatusDataSet, "tempTable");
                    DataTable tempTableChkStatusDataTable = new DataTable();
                    tempTableChkStatusDataTable = dtsChkStatusDataSet.Tables["tempTable"];

                    value = tempTableChkStatusDataTable.Rows[0][0].ToString();

                    daChkStatuSqlDataAdapter.Dispose();
                    dtsChkStatusDataSet.Clear();
                    tempTableChkStatusDataTable.Dispose();
                }
            }
            return value;
        }

        public static string fnMaxIDWPrefix(string prefix, string query)
        {


            SqlConnection conn2;
            conn2 = new SqlConnection(zglobal.constring);
            DataSet dts2 = new DataSet();
            dts2.Reset();

            string str2 = query;
            //string prefix;

            //prefix = "rec";

            SqlDataAdapter da2 = new SqlDataAdapter(str2, conn2);
            da2.Fill(dts2, "temp");
            DataTable xid1 = new DataTable();
            xid1 = dts2.Tables["temp"];
            //txtAmount.Text = voucher.Rows.Count.ToString();

            string maxrow;




            if (!Convert.IsDBNull(xid1.Rows[0][0]) && xid1.Rows[0][0].ToString() != "")
            {
                string s = xid1.Rows[0][0].ToString();
                int vno = Convert.ToInt32(s.Substring(s.Length - 6));
                ////txtDue.Text = vno.ToString();
                int vno1 = vno + 1;
                string s2 = Convert.ToString(vno1);
                if (s2.Length == 1)
                {
                    s2 = "00000" + s2;
                }
                else if (s2.Length == 2)
                {
                    s2 = "0000" + s2;
                }
                else if (s2.Length == 3)
                {
                    s2 = "000" + s2;
                }
                else if (s2.Length == 4)
                {
                    s2 = "00" + s2;
                }
                else if (s2.Length == 5)
                {
                    s2 = "0" + s2;
                }


                maxrow = prefix + s2;
                //txtVoucherNo.Text = "";
            }
            else
            {
                maxrow = prefix + "000001";
            }
            da2.Dispose();
            dts2.Dispose();
            conn2.Dispose();

            return maxrow;

        }

        public static string ReturnStringValue(string query)
        {
            string value = "";

            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        value = tempTable.Rows[0][0].ToString();
                    }


                    da.Dispose();
                }
            }

            return value;
        }

        public  static int ReturnIntValue(string query)
        {
            int value = 0;

            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        value = Convert.ToInt32(tempTable.Rows[0][0].ToString());
                    }


                    da.Dispose();
                }
            }

            return value;
        }

        public static string fnGetValue(string xfield, string xtable, string xcondition)
        {
            string value = "";

            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT "+ xfield + " FROM " + xtable + " WHERE " + xcondition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        value = DBNull.Value.Equals(tempTable.Rows[0][0]) ? "" : tempTable.Rows[0][0].ToString();
                    }


                    da.Dispose();
                }
            }

            return value;
        }

        public static int fnGetValueInt(string xfield, string xtable, string xcondition)
        {
            int value = 0;

            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + xfield + " FROM " + xtable + " WHERE " + xcondition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        value = Convert.ToInt32(tempTable.Rows[0][0] == DBNull.Value ? 0 : tempTable.Rows[0][0]);
                    }


                    da.Dispose();
                }
            }

            return value;
        }

        public static decimal fnGetValueDecimal(string xfield, string xtable, string xcondition)
        {
            decimal value = 0;

            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + xfield + " FROM " + xtable + " WHERE " + xcondition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        value = Convert.ToDecimal(tempTable.Rows[0][0] == DBNull.Value ? 0 : tempTable.Rows[0][0]);
                    }


                    da.Dispose();
                }
            }

            return value;
        }

        public static ArrayList fnGetValue1(string xfield, string xtable, string xcondition)
        {
            ArrayList value = new ArrayList();

            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + xfield + " FROM " + xtable + " WHERE " + xcondition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    if (tempTable.Rows.Count > 0)
                    {
                        //value = tempTable.Rows[0][0].ToString();
                        foreach (DataRow row in tempTable.Rows)
                        {
                            value.Add(row[0]);
                        }
                    }


                    da.Dispose();
                }
            }

            return value;
        }

        public static void fnComboBoxValue(DropDownList dw, string xfield, string xtable, string xcondition)
        {
           

            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + xfield + " FROM " + xtable + " WHERE " + xcondition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    dw.Items.Clear();
                    dw.Items.Add("");
                    if (tempTable.Rows.Count > 0)
                    {
                        foreach (DataRow  row  in tempTable.Rows)
                        {
                            dw.Items.Add(row[0].ToString());
                        }
                    }
                    dw.Text = "";


                    da.Dispose();
                }
            }

        }

        public static void fnComboBoxValueWithItem(DropDownList dw, string xfield, string xtable, string xcondition)
        {


            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + xfield + " FROM " + xtable + " WHERE " + xcondition;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    dw.Items.Clear();
                    dw.Items.Add("");
                    if (tempTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in tempTable.Rows)
                        {
                            dw.Items.Add(new ListItem(row[0].ToString(), row[1].ToString()));
                        }
                    }
                    dw.Text = "";


                    da.Dispose();
                }
            }

        }







    }

    public class xhrc1
    {
        public string xhrc11 { get; set; }
        public string value { get; set; }
    }

    public class xhrc2
    {
        //public string xhrc1 { get; set; }
        public string xhrc22 { get; set; }
        public string value { get; set; }
    }

    public class xhrc3
    {
        //public string xhrc1 { get; set; }
        //public string xhrc2 { get; set; }
        public string xhrc33 { get; set; }
        public string value { get; set; }
    }

    public class xhrc4
    {
        //public string xhrc1 { get; set; }
        //public string xhrc2 { get; set; }
        //public string xhrc3 { get; set; }
        public string xhrc44 { get; set; }
        public string value { get; set; }
    }
    public class xhrc5
    {
        //public string xhrc1 { get; set; }
        //public string xhrc2 { get; set; }
        //public string xhrc3 { get; set; }
        //public string xhrc4 { get; set; }
        public string xhrc55 { get; set; }
        public string value { get; set; }
    }

}




namespace OnlineTicketingSystem.Forms
{

    public class AddComboBoxItems
    {
        string connectionString = zglobal.constring;
        private DropDownList cbo;
        private string value = "";
        private string text = "";
        private string tblName = "";

        public AddComboBoxItems(DropDownList cbo, string value, string text, string tblName)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + value + "," + text + " FROM " + tblName + " ORDER BY " + value;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    ComboBoxProperty comboBoxProperty = null;
                    IList list = new ArrayList();
                    comboBoxProperty = new ComboBoxProperty();
                    comboBoxProperty.Text = "[Select]";
                    comboBoxProperty.Value = "000";
                    list.Add(comboBoxProperty);

                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        comboBoxProperty = new ComboBoxProperty();
                        comboBoxProperty.Text = tempTable.Rows[i][1].ToString();
                        comboBoxProperty.Value = tempTable.Rows[i][0].ToString();
                        list.Add(comboBoxProperty);
                    }

                    cbo.DataSource = list;
                    cbo.DataTextField = "Text";
                    cbo.DataValueField = "Value";
                    cbo.Text = "[Select]";

                    da.Dispose();
                }
            }
        }

        public AddComboBoxItems(DropDownList cbo, string value, string text, string tblName, int flag)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + value + "," + text + " FROM " + tblName + " ORDER BY " + value;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    ListItem llt1 = new ListItem("[Select Business]", "-1");
                    cbo.Items.Add(llt1);
                    ListItem llt2 = new ListItem("[All Business]", "1");
                    cbo.Items.Add(llt2);
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        ListItem llt = new ListItem(tempTable.Rows[i][1].ToString(), tempTable.Rows[i][0].ToString());
                        cbo.Items.Add(llt);
                    }

                    da.Dispose();
                }
            }
        }


        public AddComboBoxItems(DropDownList cbo, string value, string text, string tblName, string conField, string conValue)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + value + "," + text + " FROM " + tblName + " WHERE " + conField + " = '" + conValue + "' ORDER BY " + value;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    //ComboBoxProperty comboBoxProperty = null;
                    //IList list = new ArrayList();
                    //comboBoxProperty = new ComboBoxProperty();
                    //comboBoxProperty.Text = "[Select]";
                    //comboBoxProperty.Value = "000";
                    //list.Add(comboBoxProperty);
                    ListItem llt1 = new ListItem("[Select]", "000");
                    cbo.Items.Add(llt1);
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        ListItem llt = new ListItem(tempTable.Rows[i][1].ToString(), tempTable.Rows[i][0].ToString());
                        //comboBoxProperty = new ComboBoxProperty();
                        //comboBoxProperty.Text = tempTable.Rows[i][1].ToString();
                        //comboBoxProperty.Value = tempTable.Rows[i][0].ToString();
                        //list.Add(comboBoxProperty);
                        cbo.Items.Add(llt);
                    }

                    //cbo.DataSource = list;
                    //cbo.DataTextField = "Text";
                    //cbo.DataValueField = "Value";
                    //cbo.Text = "[Select]";

                    da.Dispose();
                }
            }
        }

        public AddComboBoxItems(DropDownList cbo, string query, int zid)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@zid", zid);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    //ComboBoxProperty comboBoxProperty = null;
                    //IList list = new ArrayList();
                    //comboBoxProperty = new ComboBoxProperty();
                    //comboBoxProperty.Text = "[Select]";
                    //comboBoxProperty.Value = "000";
                    //list.Add(comboBoxProperty);
                    //ListItem llt1 = new ListItem("[Select]", "-1");
                    //cbo.Items.Add(llt1);
                    cbo.Items.Add("[Select]");
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        //ListItem llt = new ListItem(tempTable.Rows[i][1].ToString(), tempTable.Rows[i][0].ToString());
                        //comboBoxProperty = new ComboBoxProperty();
                        //comboBoxProperty.Text = tempTable.Rows[i][1].ToString();
                        //comboBoxProperty.Value = tempTable.Rows[i][0].ToString();
                        //list.Add(comboBoxProperty);
                        //cbo.Items.Add(llt);
                        cbo.Items.Add(tempTable.Rows[i][1].ToString());
                    }

                    //cbo.DataSource = list;
                    //cbo.DataTextField = "Text";
                    //cbo.DataValueField = "Value";
                    //cbo.Text = "[Select]";

                    da.Dispose();
                }
            }
        }

        public AddComboBoxItems(DropDownList cbo)
        {

            ComboBoxProperty comboBoxProperty = null;
            IList list = new ArrayList();
            comboBoxProperty = new ComboBoxProperty();
            comboBoxProperty.Text = "[Select]";
            comboBoxProperty.Value = "000";
            list.Add(comboBoxProperty);
            string[] month = new string[12]
                {
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };

            for (int i = 0; i < month.Length; i++)
            {
                comboBoxProperty = new ComboBoxProperty();
                comboBoxProperty.Text = month[i].ToString();
                comboBoxProperty.Value = (i + 1).ToString();
                list.Add(comboBoxProperty);
            }

            cbo.DataSource = list;
            cbo.DataTextField = "Text";
            cbo.DataValueField = "Value";
            cbo.Text = "[Select]";
        }

        public AddComboBoxItems(DropDownList cbo, string value, string text, string tblName, string conField, string conValue, string none)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + text + " FROM " + tblName + " WHERE " + conField + "='" + conValue + "' ORDER BY " + value;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    cbo.Items.Clear();
                    cbo.Items.Add("[Select]");
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        cbo.Items.Add(tempTable.Rows[i][0].ToString());
                    }
                    cbo.Text = "[Select]";


                    da.Dispose();
                }
            }
        }

        public AddComboBoxItems(DropDownList cbo, int min, int max)
        {

            cbo.Items.Clear();
            cbo.Items.Add("[Select]");
            for (int i = min; i <= max; i++)
            {
                cbo.Items.Add(i.ToString());
            }
            cbo.Text = "[Select]";
        }
    }

    public class ComboBoxProperty
    {
        private string text;
        private string value1;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        public string Value
        {
            get
            {
                return value1;
            }
            set
            {
                value1 = value;
            }
        }
    }

    public class AddComboBoxItemsSingel
    {
        string connectionString = zglobal.constring;
        private DropDownList cbo;
        private string value = "";
        private string text = "";
        private string tblName = "";



        public AddComboBoxItemsSingel(DropDownList cbo, string value, string text, string tblName)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {
                    string query = "SELECT " + text + " FROM " + tblName + " ORDER BY " + value;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    cbo.Items.Clear();
                    cbo.Items.Add("[Select]");
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        cbo.Items.Add(tempTable.Rows[i][0].ToString());
                    }
                    cbo.Text = "[Select]";


                    da.Dispose();
                }
            }
        }


        public AddComboBoxItemsSingel(DropDownList cbo, string query)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    cbo.Items.Clear();
                    cbo.Items.Add("[Select]");
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        cbo.Items.Add(tempTable.Rows[i][0].ToString());
                    }
                    cbo.Text = "[Select]";


                    da.Dispose();
                }
            }
        }



        public AddComboBoxItemsSingel(DropDownList cbo, ArrayList arr)
        {

            cbo.Items.Clear();
            //cbo.Items.Add("[Select]");

            foreach (string val in arr)
            {
                cbo.Items.Add(val);
            }

            cbo.Text = arr[0].ToString();
            //cbo.Text = "[Select]";
        }
        public AddComboBoxItemsSingel(DropDownList cbo, int min, int max)
        {

            cbo.Items.Clear();
            cbo.Items.Add("[Select]");
            for (int i = min; i <= max; i++)
            {
                cbo.Items.Add(i.ToString());
            }
            cbo.Text = "[Select]";
        }

    }


    public class AddDataGridViewItems
    {

        string connectionString = zglobal.constring;

        public AddDataGridViewItems(GridView dgGrid, string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];
                    dgGrid.DataSource = tempTable;
                    dgGrid.DataBind();
                    da.Dispose();
                }
            }
        }
    }

    class JunkObject
    {
        public JunkObject(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class AddListBoxItem
    {

        string connectionString = zglobal.constring;

        public AddListBoxItem(ListBox lt, string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataSet dts = new DataSet())
                {

                    //List<JunkObject> theList = new List<JunkObject>();

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dts, "tempTable");
                    DataTable tempTable = new DataTable();
                    tempTable = dts.Tables["tempTable"];

                    ////for(int i=0; i< tempTable.Rows.Count; i++)
                    ////{
                    ////    theList.Add(new JunkObject(tempTable.Rows[i][1].ToString(),Convert.ToInt32(tempTable.Rows[i][0].ToString())));
                    ////}
                    //theList.Add(new JunkObject("Adam", 87));
                    //theList.Add(new JunkObject("Brian", 23));
                    //theList.Add(new JunkObject("Charley", 93));
                    //theList.Add(new JunkObject("David", 1));

                    //lt.DataSource = theList;
                    //lt.DataBind();
                    //lt.DataTextField = "Name";
                    //lt.DataValueField= "ID";


                    foreach (DataRow data in tempTable.Rows)
                    {
                        ListItem llt = new ListItem(Convert.ToString(data[1]), Convert.ToString(data[0]));


                        if (!lt.Items.Equals(llt.Text))
                        {
                            lt.Items.Add(llt);
                        }
                        //lt.Items.Add(llt);
                    }
                    da.Dispose();
                }
            }
        }
    }

    public class zbusiness_glmst
    {
        public int zid { get; set; }
        public string zorg { get; set; }
        public string xhrc1 { get; set; }
        public string xhrc2 { get; set; }
        public string xhrc3 { get; set; }
        public string xhrc4 { get; set; }
        public string xhrc5 { get; set; }

        public zbusiness_glmst(int zid1, string zorg1, string xhrc11, string xhrc22, string xhrc33, string xhrc44, string xhrc55)
        {
            zid = zid1;
            zorg = zorg1;
            xhrc1 = xhrc11;
            xhrc2 = xhrc22;
            xhrc3 = xhrc33;
            xhrc4 = xhrc44;
            xhrc5 = xhrc55;
        }
    }


}