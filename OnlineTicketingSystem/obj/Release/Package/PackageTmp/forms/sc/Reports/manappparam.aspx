<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="manappparam.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.Reports.manappparam" %>

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
        .style19
        {
            width: 95px;
            text-align: right;
        }
        .style22
        {
            text-align: right;
            width: 27px;
        }
        .style23
        {
            width: 178px;
        }
        .style24
        {
            width: 181px;
        }
        .style25
        {
            width: 36px;
        }
        .style26
        {
            width: 46px;
        }
        </style>
    <script>

        $(function () {
            $("#<%=xfrom.ClientID %>").datepicker();
            $("#<%=xto.ClientID %>").datepicker();
        });



        $("[id*=btnShow]").live("click", function () {


            var xfrom1;
            var xto1;
            var xtype1;
            var xuser1;



            xfrom1 = $("#<%= xfrom.ClientID%>").val();
            xto1 = $("#<%= xto.ClientID%>").val();
            xtype1 = $("#<%= xtype.ClientID%>").val();
            xuser1 = $("#<%= xuser.ClientID%>").val();





            window.open("manapprpt.aspx?xfrom1=" + xfrom1 + "&xto1=" + xto1 + "&xtype1=" + xtype1 + "&xuser1=" + xuser1);
        });

    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div>
        <div>
            <br>
            <table style="height: 48px">
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
                    <td class="style25">
                        Type:</td>
                    <td class="style24">
                        <asp:DropDownList ID="xtype" runat="server" Height="31px" Width="151px">
                        </asp:DropDownList>
                    </td>
                    <td class="style26">
                        User:</td>
                    <td class="style24">
                        <asp:DropDownList ID="xuser" runat="server" Height="31px" Width="151px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" Width="86px"/>
                    </td>
                </tr>
            </table>
        </div>
        <div id="printable" style="width: 1123px; height: 794px;">
        </div>
    </div>

</asp:Content>
