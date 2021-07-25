<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="salehis2.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.Reports.salehis2" %>

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
        .style4
        {
            text-align: center;
            text-decoration: underline;
            font-size: x-large;
            height: 36px;
        }
        .style8
        {
            text-align: left;
            width: 35px;
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
        .style16
        {
            width: 1063px;
            height: 6px;
            text-align: right;
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
        .style20
        {
            width: 728px;
            height: 6px;
        }
        .style21
        {
            width: 1301px;
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
        <div id="printable" style="width: 1123px; height: 794px;">
            <table class="style1" style="width: 100%">
                <tr>
                    <td class="style4" colspan="7">
                        <strong><span class="style18">History</span></strong>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <strong>User:</strong></td>
                    <td class="style21">
                        <asp:Label ID="xuser" runat="server" Font-Bold="True" Text="xuser"></asp:Label>
                    </td>
                    <td class="style9">
                        <asp:Label ID="xfrom" runat="server" Font-Bold="True" Text="xfrom"></asp:Label>
                    </td>
                    <td class="style10">
                        <strong>To</strong></td>
                    <td class="style16">
                        &nbsp;
                        <asp:Label ID="xto" runat="server" Font-Bold="True" style="text-align: left" 
                            Text="xto"></asp:Label>
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
                            <td colspan="10"><strong>Total Income : </strong>
                                <asp:Label ID="xtotal" runat="server" style="font-weight: 700" Text="xtotal"></asp:Label>
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
