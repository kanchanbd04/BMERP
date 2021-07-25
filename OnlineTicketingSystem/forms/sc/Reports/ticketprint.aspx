<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ticketprint.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.Reports.ticketprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../../Styles/bm.css">
    <style type="text/css">
        @page
        {
            size: auto; /* auto is the initial value */ /* this affects the margin in the printer settings */
            margin: 2mm 2mm 2mm 2mm;
        }
        
        body
        {
            /* this affects the margin on the content before sending to printer */
            margin: 0px;
        }
        
        #printbtn
        {
            width: 104px;
        }
        .style1
        {
            width: 96%;
            font-size: x-small;
            font-family: "Times New Roman" , Times, serif;
        }
        .style2
        {
            width: 79px;
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
        }
        .style11
        {
            width: 76px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 24px;
        }
        .style13
        {
            width: 79px;
            text-align: left;
            font-size: small;
            font-weight: bold;
            height: 143px;
        }
        .style16
        {
            font-size: small;
            font-weight: bold;
            height: 143px;
        }
        .style18
        {
            width: 79px;
            text-align: left;
            height: 141px;
        }
        .style21
        {
            height: 141px;
        }
        .style22
        {
            width: 106px;
            text-align: right;
            height: 141px;
        }
        .style23
        {
            width: 106px;
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            font-size: small;
        }
        .style33
        {
            font-size: small;
        }
        .style34
        {
            width: 79px;
            text-align: left;
            font-weight: bold;
            height: 88px;
        }
        .style35
        {
            font-weight: bold;
            height: 88px;
        }
        .style36
        {
            width: 76px;
            font-weight: bold;
            height: 88px;
        }
        .style37
        {
            width: 106px;
            text-align: right;
            font-weight: bold;
            height: 88px;
        }
        .style38
        {
            height: 88px;
        }
        .style40
        {
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style51
        {
            width: 79px;
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
            height: 17px;
            font-size: small;
        }
        .style52
        {
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 17px;
        }
        .style53
        {
            width: 76px;
            font-family: Arial, Helvetica, sans-serif;
            height: 17px;
            font-size: small;
        }
        .style54
        {
            text-align: left;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 17px;
        }
        .style55
        {
            text-align: left;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style56
        {
            width: 79px;
            text-align: left;
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            height: 19px;
        }
        .style57
        {
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 19px;
        }
        .style58
        {
            width: 76px;
            font-family: Arial, Helvetica, sans-serif;
            height: 19px;
            font-size: small;
        }
        .style59
        {
            text-align: left;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 19px;
        }
        .style75
        {
            width: 105px;
            font-size: small;
            font-weight: bold;
            height: 143px;
        }
        .style77
        {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 105px;
        }
        .style78
        {
            width: 105px;
            height: 141px;
        }
        .style82
        {
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
            width: 67px;
        }
        .style83
        {
            width: 67px;
            height: 141px;
        }
        .style90
        {
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
        .style96
        {
            width: 67px;
            font-size: small;
            font-weight: bold;
            height: 143px;
        }
        .style97
        {
            width: 76px;
            font-size: small;
            font-weight: bold;
            height: 143px;
        }
        .style100
        {
            width: 76px;
            height: 141px;
        }
        .style102
        {
            width: 106px;
            font-size: small;
            font-weight: bold;
            height: 143px;
        }
        .style106
        {
            width: 79px;
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
        .style110
        {
            width: 76px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
        .style111
        {
            width: 79px;
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            height: 24px;
        }
        .style112
        {
            width: 67px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 24px;
        }
        .style113
        {
            width: 105px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            height: 24px;
        }
        .style114
        {
            width: 106px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            height: 24px;
        }
        .style115
        {
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 24px;
        }
        .style116
        {
            width: 79px;
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            height: 23px;
        }
        .style117
        {
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 23px;
        }
        .style118
        {
            width: 106px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            height: 23px;
        }
        .style121
        {
            width: 76px;
            font-family: Arial, Helvetica, sans-serif;
            height: 23px;
        }
        .style122
        {
            width: 67px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 23px;
        }
        .style123
        {
            width: 105px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            height: 23px;
        }
        .style124
        {
            width: 76px;
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
        }
        .style125
        {
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 913px">
        <div>
            <input id="printbtn" type="button" value="Print" onclick="window.print()" />
        </div>
        <div id="printable" style="width: 600px; height: 869px;">
            <table align="center" class="style1" style="width: 599px">
                <tr>
                    <td class="style13">
                    </td>
                    <td class="style96">
                    </td>
                    <td class="style75">
                    </td>
                    <td class="style97">
                    </td>
                    <td class="style102">
                    </td>
                    <td class="style16">
                    </td>
                </tr>
                <tr>
                    <td class="style111">
                        Coach No:
                    </td>
                    <td class="style112">
                        <asp:Label ID="xcoach" runat="server" Text="xcoach" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style113">
                        Palce of Issue:
                    </td>
                    <td class="style11">
                        <asp:Label ID="xpissue" runat="server" Text="xpissue" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style114">
                        PNR No:
                    </td>
                    <td class="style115">
                        <asp:Label ID="xticket" runat="server" Text="xticket" CssClass="style33" 
                            Style="font-family: Arial, Helvetica, sans-serif" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style111">
                        Seat No:
                    </td>
                    <td class="style112">
                        <asp:Label ID="xseat" runat="server" Text="xseat" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style113">
                        Route:
                    </td>
                    <td class="style115" colspan="3">
                        <asp:Label ID="xroute" runat="server" Text="xroute" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style116">
                        Name:
                    </td>
                    <td class="style117" colspan="3">
                        <asp:Label ID="xname" runat="server" Text="xname" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style118">
                        Issue Date:
                    </td>
                    <td class="style117">
                        <asp:Label ID="xsdate" runat="server" Text="xsdate" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style116">
                        Conatct No:
                    </td>
                    <td class="style122">
                        <asp:Label ID="xcontact" runat="server" Text="xcontact" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style123">
                        Boarding:
                    </td>
                    <td class="style121">
                        <asp:Label ID="xboarding" runat="server" Text="xboarding" CssClass="style33"></asp:Label>
                    </td>
                    <td class="style118">
                        Date of Journey:
                    </td>
                    <td class="style117">
                        <asp:Label ID="xjdate" runat="server" Text="xjdate" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style116">
                        Voter ID:
                    </td>
                    <td class="style122">
                        <asp:Label ID="xvotid" runat="server" Text="xvotid" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style123">
                        Reporting Time:
                    </td>
                    <td class="style121">
                        <asp:Label ID="xrtime" runat="server" Text="xrtime" CssClass="style33"></asp:Label>
                    </td>
                    <td class="style118">
                        Departure Time:
                    </td>
                    <td class="style117">
                        <asp:Label ID="xjtime" runat="server" Text="xjtime" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style116">
                        No of Seat:
                    </td>
                    <td class="style122">
                        <asp:Label ID="xnseat" runat="server" Text="xnseat" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style123">
                        Ticket Fare(TK.)
                    </td>
                    <td class="style121">
                        <asp:Label ID="xfare" runat="server" Text="xfare" CssClass="style33"></asp:Label>
                    </td>
                    <td class="style118">
                        Total Taka:
                    </td>
                    <td class="style117">
                        <asp:Label ID="xtotal" runat="server" Text="xtotal" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td class="style82">
                    </td>
                    <td class="style77">
                    </td>
                    <td class="style124">
                    </td>
                    <td class="style23">
                        Sold By
                    </td>
                    <td class="style125">
                        <asp:Label ID="xsoldby" runat="server" Text="xsoldby" Style="font-size: small" 
                            Font-Bold="False"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                    </td>
                    <td class="style83">
                    </td>
                    <td class="style78">
                    </td>
                    <td class="style100">
                    </td>
                    <td class="style22">
                    </td>
                    <td class="style21">
                    </td>
                </tr>
                <tr>
                    <td class="style106">
                        Sp:
                    </td>
                    <span class="style33">
                        <td class="style40" colspan="2">
                            &nbsp;
                        </td>
                        <td class="style110">
                            Date of Journey:
                        </td>
                        <td class="style55" colspan="2">
                            <asp:Label ID="xgjdate" runat="server" Text="xgjdate" CssClass="style33" 
                                Font-Bold="True"></asp:Label>
                    </span></td>
                </tr>
                <tr>
                    <td class="style106">
                        PNR No:
                    </td>
                        <td class="style40" colspan="2">
                            <asp:Label ID="xgticket" runat="server" Text="xgticket" CssClass="style33" 
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td class="style110">
                            Departure Time:
                        </td>
                        <td class="style55" colspan="2">
                            <asp:Label ID="xgjtime" runat="server" Text="xgjtime" CssClass="style33" 
                                Font-Bold="False"></asp:Label>
                    </span></td>
                </tr>
                <tr>
                    <td class="style106">
                        Place of Issue:
                    </td>
                        <td class="style40" colspan="2">
                            <asp:Label ID="xgpissue" runat="server" Text="xgpissue" CssClass="style33" 
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td class="style110">
                            Seats:
                        </td>
                        <td class="style55" colspan="2">
                            <asp:Label ID="xgseat" runat="server" Text="xgseat" CssClass="style33" 
                                Font-Bold="True"></asp:Label>
                    </span></td>
                </tr>
                <tr>
                    <td class="style51">
                        Coach No:
                    </td>
                        <td class="style52" colspan="2">
                            <asp:Label ID="xgcoach" runat="server" Text="xgcoach" CssClass="style33" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td class="style53">
                            Total:
                        </td>
                        <td class="style54" colspan="2">
                            <asp:Label ID="xgtotal" runat="server" Text="xgtotal" CssClass="style33" 
                                Font-Bold="False"></asp:Label>
                    </span></td>
                </tr>
                <tr>
                    <td class="style106">
                        Route:</td>
                        <td class="style40" colspan="2">
                            <asp:Label ID="xgroute" runat="server" Text="xgroute" CssClass="style33" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td class="style110">
                            Sold By:
                        </td>
                        <td class="style55" colspan="2">
                            <asp:Label ID="xgsoldby" runat="server" Text="xgsoldby" CssClass="style33" 
                                Font-Bold="False"></asp:Label>
                    </span></td>
                </tr>
                <tr>
                    <td class="style34">
                    </td>
                    <td class="style35" colspan="2">
                    </td>
                    <td class="style36">
                    </td>
                    <td class="style37">
                    </td>
                    <td class="style38">
                    </td>
                </tr>
                <tr>
                    <td class="style106">
                        Sp:
                    </td>
                    <td class="style90" colspan="2">
                        &nbsp;
                    </td>
                        <td class="style110">
                            Date of Journey:
                        </td>
                    <td class="style55" colspan="2">
                        <asp:Label ID="xcjdate" runat="server" Text="xcjdate" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style106">
                        PNR No:
                    </td>
                    <td class="style40" colspan="2">
                        <asp:Label ID="xcticket" runat="server" Text="xcticket" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                        <td class="style110">
                            Departure Time:
                        </td>
                    <td class="style55" colspan="2">
                        <asp:Label ID="xcjtime" runat="server" Text="xcjtime" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style106">
                        Place of Issue:
                    </td>
                    <td class="style40" colspan="2">
                        <asp:Label ID="xcpissue" runat="server" Text="xcpissue" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                        <td class="style110">
                            Seats:
                        </td>
                    <td class="style55" colspan="2">
                        <asp:Label ID="xcseat" runat="server" Text="xcseat" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style56">
                        Coach No:
                    </td>
                    <td class="style57" colspan="2">
                        <asp:Label ID="xccoach" runat="server" Text="xccoach" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                        <td class="style58">
                            Total:
                        </td>
                    <td class="style59" colspan="2">
                        <asp:Label ID="xctotal" runat="server" Text="xctotal" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style106">
                        Route:</td>
                    <td class="style40" colspan="2">
                        <asp:Label ID="xcroute" runat="server" Text="xcroute" CssClass="style33" 
                            Font-Bold="True"></asp:Label>
                    </td>
                        <td class="style110">
                            Sold By:
                        </td>
                    <td class="style55" colspan="2">
                        <asp:Label ID="xcsoldby" runat="server" Text="xcsoldby" CssClass="style33" 
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
