<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ztchngpass.aspx.cs" Inherits="OnlineTicketingSystem.forms.ztchngpass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 29%;
        }
        .style2
        {
            font-size: x-large;
        }
        .style4
        {
        }
        .style5
        {
            width: 129px;
            text-align: right;
        }
        #Password1
        {
            width: 151px;
        }
        #Password2
        {
            width: 151px;
        }
        #Password3
        {
            width: 151px;
        }
        .style6
        {
            width: 129px;
            text-align: right;
            height: 34px;
        }
        .style7
        {
            height: 34px;
        }
        #xoldpass
        {
            width: 151px;
        }
        #xnewpass
        {
            width: 151px;
        }
        #xconfpass
        {
            width: 151px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-left: 20%">
    
        <table class="style1" 
            
            style="border-style: solid; border-width: thin; background-color: #FFFFFF; width: 29%;">
            <tr>
                <td class="style2" colspan="2" 
                    style="text-align: center; color: #FFFFFF; background-color: #996633">
                    <strong>Change Password</strong></td>
            </tr>
            <tr>
                <td class="style2" colspan="2" 
                    style="text-align: center; color: #000000; background-color: #FFFFFF">
                    <asp:Label ID="Label1" runat="server" style="font-size: large; color: #006600" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    <div id="msg" style="font-weight:bold; font-size:12; color:Red; text-align:center; " runat="server" > </div></td>
            </tr>
            <tr>
                <td class="style6">
                    Old Password :</td>
                <td class="style7">
                    <input id="xoldpass" type="password" runat="server"/></td>
            </tr>
            <tr>
                <td class="style6">
                    New Password :</td>
                <td class="style7">
                    <input id="xnewpass" type="password" runat="server"/></td>
            </tr>
            <tr>
                <td class="style6">
                    Confirm Password :</td>
                <td class="style7">
                    <input id="xconfpass" type="password" runat="server"/></td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:Button ID="btnsave" runat="server" Text="Save" Width="91px" 
                        onclick="btnsave_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
