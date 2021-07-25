<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="busstyle.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.busstyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <link rel="stylesheet" href="../../Styles/coach.css">
    <link rel="stylesheet" href="../../Styles/buslayout.css">
     <style type="text/css">
       
       
       .bus1
{
    width: 99%;
    height: 539px;
}
.bus24
{
    text-align: center;
    height: 37px;
    font-size: x-large;
    color: #FFFFFF;
}
.bus1121
{
    width: 50px;
    text-align: center;
    height: 5px;
}
.bus27
{
    height: 5px;
    width: 50px;
}
.bus1122
{
    width: 12px;
    height: 5px;
}
.bus9
{
    height: 5px;
    width: 60px;
}
.bus1123
{
    height: 5px;
}
.bus25
{
    text-align: center;
}
.bus1124
{
    width: 12px;
}
.bus18
{
    width: 60px;
    text-align: center;
}
.bus13
{
    text-align: center;
}
.bus2500
{
    text-align: left;
}
.bus250
{
    text-align: center;
}
.bus25000
{
    text-align: right;
}
.bus1125
{
    height: 5px;
    width: 36px;
}
.bus1126
{
    text-align: center;
    width: 36px;
}
    
   
   #seatInfo
   {
       background-image:url('../../images/back.jpg'); 
       background-repeat: no-repeat; 
       text-align: center; 
       font-size: 70px; 
       font-weight: bold; 
       color: white;
   }
   
    .btn
    {
        
        width:40px;
        height:40px;
        background-color:#D3D3D3;
        
        border: 1px solid #808080;
        border-radius: 10px;
    }
    
    .processing
    {
       
        background-color:#BC8F8F;
        color:White;
    }
    
         .style26
         {
             height: 4px;
         }
         .style27
         {
             height: 47px;
         }
         .style28
         {
             height: 21px;
             color: #FFFFFF;
             font-size: large;
         }
            
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
   
               <%-- <table class="style1">
                    <tr>
                        <td bgcolor="#996633" class="style24" colspan="5">
                            <strong>E-Class (B)</strong></td>
                    </tr>
                    <tr>
                        <td class="style1121">
                        </td>
                        <td class="style27">
                        </td>
                        <td class="style1122">
                        </td>
                        <td class="style9">
                        </td>
                        <td class="style1123">
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ba1"  value="A1" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bb1"  value="B1" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bc1"  value="C1" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bd1"  value="D1" class="btn" />
                        </td>
                    </tr>--%>
<%--                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ba2"  value="A2" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bb2"  value="B2" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bc2"  value="C2" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bd2"  value="D2" class="btn" />
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ba3"  value="A3" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bb3"  value="B3" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bc3"  value="C3" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bd3"  value="D3" class="btn" />
                        </td>
                    </tr>--%>
               <%--     <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ba4"  value="A4" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bb4"  value="B4" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bc4"  value="C4" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bd4"  value="D4" 
                                class="btn" />
                        </td>
                    </tr>--%>
 <%--                   <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ba5"  value="A5" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bb5"  value="B5" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bc5"  value="C5" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bd5"  value="D5" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ba6"  value="A6" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bb6"  value="B6" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bc6"  value="C6" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bd6"  value="D6" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bf1"  value="F1" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bf2"  value="F2" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bf3"  value="F3" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bf4" runat="server" value="F4" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bf5" runat="server" value="F5" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bf6"  value="F6" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bf7"  value="F7" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bf8"  value="F8" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bf9"  value="F9" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bf10"  value="F10" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bf11"  value="F11" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bf12"  value="F12" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bs1"  value="S1" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="bs2"  value="S2" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="bs3"  value="S3" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="bs4"  value="S4" 
                                class="btn" />
                        </td>
                    </tr>
                </table>--%>

              <%--   <table class="style1">
                    <tr>
                        <td bgcolor="#996633" class="style24" colspan="9">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" 
                                ForeColor="White" Text="E-Class (S) " style="font-size: large"></asp:Label>
                        </td>
                    </tr>--%>
                 <%--   <tr>
                        <td class="style1121">
                        </td>
                        <td class="style27" colspan="3">
                        </td>
                        <td class="style1122">
                        </td>
                        <td class="style9" colspan="3">
                        </td>
                        <td class="style1123">
                        </td>
                    </tr>--%>
<%--                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sa1"    value="A1"  class="btn"  />
                        </td>
                        <td class="style25" height="40px" width="40px" colspan="3">
                            <input type="button" id="sb1"  value="B1"  class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px" colspan="3">
                            <input type="button" id="sc1"   value="C1" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="sd1"  value="D1" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sa2"  value="A2" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px" colspan="3">
                            <input type="button" id="sb2"  value="B2" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px" colspan="3">
                            <input type="button" id="sc2"  value="C2" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="sd2"  value="D2" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sa3"  value="A3" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px" colspan="3">
                            <input type="button" id="sb3"  value="B3" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px" colspan="3">
                            <input type="button" id="sc3"  value="C3" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="sd3"  value="D3" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sa4"  value="A4" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px" colspan="3">
                            <input type="button" id="sb4"  value="B4" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px" colspan="3">
                            <input type="button" id="sc4"  value="C4" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="sd4"  value="D4" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sa5"  value="A5" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px" colspan="3">
                            <input type="button" id="sb5" value="B5" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px" colspan="3">
                            <input type="button" id="sc5"  value="C5" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="sd5"  value="D5" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sa6"  value="A6" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px" colspan="3">
                            <input type="button" id="sb6"  value="B6" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px" colspan="3">
                            <input type="button" id="sc6"  value="C6" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="sd6"  value="D6" 
                                class="btn" />
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td class="style250" height="40px" colspan="2">
                            <input type="button" id="sf1"  value="F1" class="btn" />
                        </td>
                        <td class="style250" colspan="5" height="40px">
                            <input type="button" id="sf2"  value="F2" class="btn" />
                        </td>
                        <td class="style250" colspan="2" height="40px">
                            <input type="button" id="sf3"  value="F3" class="btn" />
                        </td>
                    </tr>
                    <tr>
                       <td class="style250" height="40px" colspan="2">
                            <input type="button" id="sf4"  value="F4" class="btn" />
                        </td>
                        <td class="style250" colspan="5" height="40px">
                            <input type="button" id="sf5"  value="F5" class="btn" />
                        </td>
                        <td class="style250" colspan="2" height="40px">
                            <input type="button" id="sf6"  value="F6" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style250" height="40px" colspan="2">
                            <input type="button" id="sf7"  value="F7" class="btn" />
                        </td>
                        <td class="style250" colspan="5" height="40px">
                            <input type="button" id="sf8"  value="F8" class="btn" />
                        </td>
                        <td class="style250" colspan="2" height="40px">
                            <input type="button" id="sf9"  value="F9" class="btn" />
                        </td>
                    </tr>--%>
              <%--      <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ss1"  value="S1" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px" colspan="3">
                            <input type="button" id="ss2"  value="S2" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px" colspan="3">
                            <input type="button" id="ss3"  value="S3" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="ss4"  value="S4" 
                                class="btn" />
                        </td>
                    </tr>
                </table>--%>
            

<%--             <table class="style1h">
                    <tr>
                        <td bgcolor="#996633" class="style24" colspan="5">
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" 
                                ForeColor="White" Text="Hino-AC" style="font-size: large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1121">
                        </td>
                        <td class="style27">
                        </td>
                        <td class="style1122">
                        </td>
                        <td class="style9">
                        </td>
                        <td class="style1123">
                        </td>
                    </tr>--%>
<%--                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ha1"  value="A1" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hb1"  value="B1" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hc1"  value="C1" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hd1"  value="D1" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ha2"  value="A2" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hb2"  value="B2" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hc2"  value="C2" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hd2"  value="D2" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ha3"  value="A3" class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hb3"  value="B3" class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hc3"  value="C3" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hd3"  value="D3" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ha4"  value="A4" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hb4"  value="B4" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hc4"  value="C4" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hd4"  value="D4" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ha5"  value="A5" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hb5"  value="B5" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hc5"  value="C5" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hd5"  value="D5" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="ha6"  value="A6" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hb6"  value="B6" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hc6"  value="C6" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hd6"  value="D6" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hf1"  value="F1" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hf2"  value="F2" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hf3"  value="F3" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hf4"  value="F4" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hf5"  value="F5" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hf6"  value="F6" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hf7"  value="F7" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hf8"  value="F8" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hf9"  value="F9" 
                                class="btn" />
                        </td>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="hf10"  value="F10" 
                                class="btn" />
                        </td>
                        <td class="style1124" height="40px" width="40px">
                            &nbsp;</td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="hf11" value="F11" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="hf12"  value="F12" 
                                class="btn" />
                        </td>
                    </tr>
                </table>--%>


               <table class="style1sc">
                    <tr>
                        <td bgcolor="#996633" class="style24" colspan="4">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" 
                                ForeColor="White" Text="S-Class" style="font-size: large"></asp:Label>
                        </td>
                    </tr>
                <tr>
                        <td class="style1121">
                        </td>
                        <td class="style1125">
                        </td>
                        <td class="style9">
                        </td>
                        <td class="style1123">
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sca1"  value="A1" class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scc1" value="C1" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scd1" value="D1" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sca2"  value="A2" class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scc2"  value="C2" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scd2"  value="D2" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sca3"  value="A3" class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scc3"  value="C3" class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scd3" value="D3" class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sca4"  value="A4" 
                                class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scc4"  value="C4" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scd4"  value="D4" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sca5" value="A5" 
                                class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scc5" value="C5" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scd5"  value="D5" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sca6"  value="A6" 
                                class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scc6"  value="C6" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scd6" value="D6" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="sca7"  value="A7" 
                                class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scc7"  value="C7" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scd7"  value="D7" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="scf1"  value="F1" 
                               class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scf2"  value="F2" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scf3"  value="F3" 
                                class="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style25" height="40px" width="40px">
                            <input type="button" id="scf4"  value="F4" 
                                class="btn" />
                        </td>
                        <td class="style1126" height="40px">&nbsp;
                            </td>
                        <td class="style18" height="40px" width="40px">
                            <input type="button" id="scf5"  value="F5" 
                                class="btn" />
                        </td>
                        <td class="style13" height="40px" width="40px">
                            <input type="button" id="scf6"  value="F6" 
                                class="btn" />
                        </td>
                    </tr>
                </table>




               <table width="849" height="189" border="1" frame="border" 
                   
                   style="border-style: ridge; border-width: thin; border-collapse: collapse; border-spacing: 10px;">
  <tr bgcolor="#666666">
    <th scope="col" class="style28"><strong>Seat</strong></th>
    <th scope="col" class="style28"><strong>Passenger</strong></th>
    <th scope="col" class="style28"><strong>Phone</strong></th>
    <th scope="col" class="style28"><strong>Tic. No</strong></th>
    <th scope="col" class="style28"><strong>Destination</strong></th>
  </tr>
  <tr>
    <td class="style26"></td>
    <td class="style26"></td>
    <td class="style26"></td>
    <td class="style26"></td>
    <td class="style26"></td>
  </tr>
  <tr>
    <td class="style27"></td>
    <td class="style27"></td>
    <td class="style27"></td>
    <td class="style27"></td>
    <td class="style27"></td>
  </tr>
</table>
</body>
</html>




    </div>
    </form>
</body>
</html>
