<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ztreservehistory.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztreservehistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 <link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
     <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>


    <script>

        $(function () {
            $("#<%=xfrom.ClientID %>").datepicker();
        });

        $(function () {
            $("#<%=xto.ClientID %>").datepicker();
        });

	</script>


        <script type="text/javascript">

            $(document).ready(function () {
                $('a#popup').live('click', function (e) {

                    var page = $(this).attr("href")  //get url of link

                    var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 500,
                    width: 900,
                    title: "Reservation Details",

                    buttons: {
                        "Close": function () { $dialog.dialog('close'); }
                    },
                    close: function (event, ui) {

                        //                        __doPostBack(', '');  // To refresh gridview when user close dialog
                    }
                });
                    $dialog.dialog('open');
                    e.preventDefault();
                });
            });

       
    </script>



    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 46px;
            text-align: right;
            width: 85px;
        }
        .style3
        {
            width: 42px;
            height: 46px;
        }
        .style4
        {
            height: 46px;
        }
        .style5
        {
            width: 26px;
            height: 46px;
        }
        .style6
        {
            height: 46px;
            width: 110px;
        }
        .style7
        {
            height: 21px;
            text-align: center;
        }
    </style>



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <table class="style1">
        <tr>
            <td class="style7" colspan="5">
                 <div id="msg" style="font-weight:bold; font-size:12; color:Red; text-align:center; " runat="server" > </div></td>
        </tr>
        <tr>
            <td class="style2">
                From :
            </td>
            <td class="style3">
                <asp:TextBox ID="xfrom" runat="server" Width="151px"></asp:TextBox>
            </td>
            <td class="style5">
                To :</td>
            <td class="style6">
                <asp:TextBox ID="xto" runat="server" Width="151px"></asp:TextBox>
            </td>
            <td class="style4">
                <asp:Button ID="btnSubmit" runat="server" Height="32px" Text="Submit" 
                    Width="101px" onclick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
           
                
                

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False">



                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="xcoach" HeaderText="Coach No" />

                            <asp:BoundField DataField="xdest" HeaderText="Route" />

                            <asp:BoundField DataField="xdate" HeaderText="JDate" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="xfare" HeaderText="Rent Amount" />

                            
                            <asp:BoundField DataField="xpayment"  HeaderText="Pay Amount" />

                            
                            <asp:BoundField DataField="xdue" HeaderText="Due Amount" />

                            
                            <asp:BoundField DataField="xresby" HeaderText="Reserve By" />
                            <asp:BoundField DataField="xcreatedby" HeaderText="Issue By" />
                            <asp:BoundField DataField="xpayinfo" HeaderText="Status" />
                            <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                 <a id="popup" href='ztreservedetails.aspx?xcoach=<%# Eval("xcoach") %>&xdplace=<%# Eval("xdplace") %>&xdest=<%# Eval("xdest") %>&xdate=<%# Eval("xdate","{0:MMM dd, yyyy}") %>&xtime=<%# Eval("xtime") %>&xresby=<%# Eval("xresby") %>&xcontact=<%# Eval("xcontact") %>&xrefby=<%# Eval("xrefby") %>&xfare=<%# Eval("xfare") %>&xdue=<%# Eval("xdue") %>  '>Detail</a>
                            </ItemTemplate>
                        </asp:TemplateField>

                            
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />



                    </asp:GridView>



                
            </td>
        </tr>
    </table>



</asp:Content>
