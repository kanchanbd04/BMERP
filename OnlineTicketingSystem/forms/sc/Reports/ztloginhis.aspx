<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ztloginhis.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.Reports.ztloginhis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <%--   <link rel="stylesheet" href="../../Scripts/jquery-ui-1.8.17/themes/base/jquery.ui.all.css">
    --%>
    <link rel="stylesheet" href="../../../Styles/coach.css">
    <link rel="stylesheet" href="../../../Styles/buslayout.css">
    <link rel="stylesheet" href="../../../Styles/bm.css">
    <script src="../../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
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
            width: 207px;
            text-align: right;
        }
        .style22
        {
            text-align: right;
        }
        .style23
        {
            width: 178px;
        }
        .style24
        {
            width: 181px;
        }
        </style>
    <script>
        $(function () {
            $("#<%=xfrom.ClientID %>").datepicker();
            $("#<%=xto.ClientID %>").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <br>
            <table>
                <tr>
                    <td class="style19">
                        From :
                    </td>
                    <td class="style23">
                        <asp:TextBox ID="xfrom" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style22">
                        To :
                    </td>
                    <td class="style24">
                        <asp:TextBox ID="xto" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" Width="86px" OnClick="btnShow_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="printable" style="width: 1123px; height: 794px; overflow: scroll">
            <table class="style1" style="width: 100%">
                <tr>
                    <td class="style4" colspan="6">
                        <strong><span class="style18">Login History</span></strong>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        &nbsp;
                    </td>
                    <td class="style21">
                        &nbsp;
                    </td>
                    <td class="style9">
                        <asp:Label ID="xfromdt" runat="server" Font-Bold="True" Text="xfrom"></asp:Label>
                    </td>
                    <td class="style10">
                        <strong>To</strong>
                    </td>
                    <td class="style16">
                        &nbsp;
                        <asp:Label ID="xtodt" runat="server" Font-Bold="True" Style="text-align: left" Text="xto"></asp:Label>
                    </td>
                    <td class="style20">
                    </td>
                    <td class="style11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="6">
                        <table border="1" frame='border' style='border-style: ridge; border-width: thin;
                            border-collapse: collapse; width: 100%;' align="center">
                            <asp:PlaceHolder ID="passlist" runat="server"></asp:PlaceHolder>
                        </table>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="3">
                    </td>
                    <td class="style2" colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr style="text-align: right">
                    <td colspan="3">
                        &nbsp;
                    </td>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
