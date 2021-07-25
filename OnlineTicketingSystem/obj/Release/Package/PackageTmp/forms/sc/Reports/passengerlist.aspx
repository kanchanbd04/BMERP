<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="passengerlist.aspx.cs"
    Inherits="OnlineTicketingSystem.forms.sc.Reports.passengerlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../../Styles/bm.css">
    <style type="text/css">
     
   
   
 

  
        .style1
        {
            width: 814px;;
        }
        .style2
        {
        }
        .style3
        {
            width: 1336px;
            background-color: #C0C0C0;
        }
        .style4
        {
            text-align: center;
            text-decoration: underline;
            font-size: x-large;
            height: 36px;
        }
        .style5
        {
            width: 1101px;
            text-align: left;
            background-color: #C0C0C0;
        }
        .style7
        {
            width: 297px;
        }
        .style8
        {
            text-align: right;
            width: 504px;
            height: 6px;
        }
        .style9
        {
            width: 1101px;
            text-align: left;
            height: 6px;
        }
        .style10
        {
            width: 297px;
            height: 6px;
        }
        .style11
        {
            width: 329px;
            height: 6px;
        }
        .style12
        {
            text-align: right;
            width: 504px;
        }
         .style13
        {
            width: 30px;
            text-align: left;
        }
        .style14
        {
            width: 30px;
            text-align: left;
            height: 6px;
        }
        .style15
        {
            width: 231px;
        }
        .style16
        {
            width: 231px;
            height: 6px;
        }
        .style17
        {
            text-align: right;
            width: 297px;
        }
         .mystyle228
         {
             height: 21px;
            
             font-size: medium;
             text-align:center;
         }
        #btnprint
        {
            height: 16px;
            width: 92px;
        }
        #Button1
        {
            height: 27px;
            width: 101px;
        }
        #printbtn
        {
            height: 27px;
            width: 106px;
        }
        .style18
        {
            font-size: medium;
        }
        .style19
        {
            width: 329px;
            background-color: #FFFFFF;
        }
        .style20
        {
            width: 1336px;
            height: 6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <input id="printbtn" type="button" value="Print" onclick="window.print()" />
        </div>
        <div id="printable" style="border-style: solid; width: 816px">
            <table class="style1">
                <tr>
                    <td class="style4" colspan="7">
                        <strong><span class="style18">Passenger List</span></strong>
                    </td>
                </tr>
                <tr>
                    <td class="style12">
                        Date :
                    </td>
                    <td class="style13">
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:Label ID="xdate" runat="server" Text="xdate"></asp:Label>
                    </td>
                    <td class="style17">
                        Coach :
                    </td>
                    <td class="style15">
                        &nbsp;
                    </td>
                    <td class="style3">
                        <asp:Label ID="xcoach" runat="server" Text="xcoach"></asp:Label>
                    </td>
                    <td class="style19">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style12">
                        Time :
                    </td>
                    <td class="style13">
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:Label ID="xtime" runat="server" Text="xtime"></asp:Label>
                    </td>
                    <td class="style17">
                        Bus No :
                    </td>
                    <td class="style15">
                        &nbsp;
                    </td>
                    <td class="style3">
                        <asp:Label ID="xbus" runat="server" Text="xbus"></asp:Label>
                    </td>
                    <td class="style19">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style12">
                        Driver :
                    </td>
                    <td class="style13">
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:Label ID="xdriver" runat="server" Text="xdriver"></asp:Label>
                    </td>
                    <td class="style17">
                        Guide :
                    </td>
                    <td class="style15">
                        &nbsp;
                    </td>
                    <td class="style3">
                        <asp:Label ID="xguide" runat="server" Text="xguide"></asp:Label>
                    </td>
                    <td class="style19">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style12">
                        Route :
                    </td>
                    <td class="style13">
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:Label ID="xroute" runat="server" Text="xroute"></asp:Label>
                    </td>
                    <td class="style7">
                        &nbsp;
                    </td>
                    <td class="style15">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style19">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                    </td>
                    <td class="style14">
                        &nbsp;
                    </td>
                    <td class="style9">
                    </td>
                    <td class="style10">
                    </td>
                    <td class="style16">
                        &nbsp;
                    </td>
                    <td class="style20">
                    </td>
                    <td class="style11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="7">
                        <table border="1" frame='border' style='border-style: ridge; border-width: thin;
                            border-collapse: collapse; width:100%;' align="center">
                            <asp:PlaceHolder ID="passlist" runat="server"></asp:PlaceHolder>
                            <tr>
                            <td colspan="7"><asp:Label ID="xtotal" runat="server" Style="font-weight: 700; font-size: medium"
                            Text="xtotal"></asp:Label>
                            </td>
                            </tr>
                        </table>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="6">
                        
                    </td>
                    <td class="style2">
                        &nbsp;
                    </td>
                </tr>
                <tr style="text-align: right">
                    <td colspan="6">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
