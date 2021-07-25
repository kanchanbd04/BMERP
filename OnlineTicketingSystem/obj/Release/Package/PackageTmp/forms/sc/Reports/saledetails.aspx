<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="saledetails.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.Reports.saledetails" %>

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
            width: 814px;
        }
        .style2
        {
        }
        .style4
        {
            text-align: center;
            text-decoration: underline;
            font-size: x-large;
            height: 45px;
        }
        .style8
        {
            text-align: left;
            width: 87px;
            height: 61px;
        }
        .style9
        {
            width: 28px;
            text-align: left;
            height: 61px;
        }
        .style11
        {
            width: 329px;
            height: 61px;
        }
        .style16
        {
            width: 128px;
            height: 61px;
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
        .style21
        {
            width: 167px;
            height: 61px;
        }
        .style22
        {
            width: 462px;
            height: 61px;
        }
        .style23
        {
            width: 169px;
            height: 61px;
        }
    </style>
    <script type="text/javascript">

        $("[id*=xdtype]").live("change", function () {
            var dtype = $("#<%= xdtype.ClientID%>").val();



            if (dtype == "sdate") {
                $("#<%= xto.ClientID%>").attr("disabled", "disabled");
            }
            else {
                $("#<%= xto.ClientID%>").removeAttr('disabled');
            }


        });

        $(function () {
            $("#<%=xfrom.ClientID %>").datepicker();
            $("#<%=xto.ClientID %>").datepicker();
        });



        $("[id*=btnsubmit]").live("click", function () {

            var dtype = $("#<%= xdtype.ClientID%>").val();
            var xfrom1;
            var xto1;
            var xcri = $("#<%= xrcriteria.ClientID%>").val();

            if (dtype == "sdate") {

                xfrom1 = $("#<%= xfrom.ClientID%>").val();
                xto1 = $("#<%= xfrom.ClientID%>").val();

                if (xfrom1 == "") {
                    alert("Please Enter Date.")
                    return;
                }
            }
            else {
                xfrom1 = $("#<%= xfrom.ClientID%>").val();
                xto1 = $("#<%= xto.ClientID%>").val();
                if (xfrom1 == "" || xto1 == "") {
                    alert("Please Enter Date.")
                    return;
                }
            }


            window.open("saledtl.aspx?xfrom1=" + xfrom1 + "&xto1=" + xto1 + "&xdtype1=" + dtype + "&xrcri=" + xcri);
        });

       

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div id="msg" runat="server">
        </div>
        <div id="printable" style="width: 1123px; height: 794px;">
            <table class="style1" style="width: 100%">
                <tr>
                    <td class="style4" colspan="7">
                        <strong><span class="style18">Employeewise Report</span></strong>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        Date Type:
                    </td>
                    <td class="style21">
                        <asp:DropDownList ID="xdtype" runat="server" Height="25px" Width="151px">
                        </asp:DropDownList>
                    </td>
                    <td class="style9">
                        Date:
                    </td>
                    <td class="style22">
                        <asp:TextBox ID="xfrom" runat="server" Width="151px"></asp:TextBox>&nbsp; - &nbsp;<asp:TextBox
                            ID="xto" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style16">
                        Report Criteria:
                    </td>
                    <td class="style23">
                        <asp:DropDownList ID="xrcriteria" runat="server" Height="27px" Width="151px">
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                        <input id="btnsubmit" type="button" value="Submit Report"  />
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
</asp:Content>
