<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ztcancelreq.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztcancelreq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">

 <%--<link rel="stylesheet" href="../../Scripts/jquery-ui-1.8.17/themes/base/jquery.ui.all.css">--%>
    <%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%><%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%><%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%>
    <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            height: 30px;
            width: 836px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #999966;
        }
        .style5
        {
            text-align: left;
        }
        .style6
        {
            height: 51px;
            font-size: large;
        }
        .style7
        {
            width: 261px;
        }
    </style>
    <script type="text/javascript">

//        $("[id*=cancel]").live("click", function () {

//            //            alert("hi");

//            $("#popupcancel").dialog({
//                title: "Cancel Booking",
//                resizable: false,

//                height: 200,

//                width: 400,

//                modal: true,
//                buttons: {
//                    Yes: function () {
//                        alert($("#<%= xrowid.ClientID%>").val());
//                        $(this).dialog('close');
//                    },

//                    No: function () {
//                        $(this).dialog('close');
//                    }
//                }
//            });
//            return false;
//        });



//        $(document).ready(function () {
//            $('a#cancel').live('click', function (e) {

//                var page = $(this).attr("href")  //get url of link

//                var $dialog = $('<div></div>')
//                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
//                .dialog({
//                    autoOpen: false,
//                    modal: true,
//                    height: ,
//                    width: 'auto',
//                    title: "Cancel Request",

//                    buttons: {
//                        "Close": function () { $dialog.dialog('close'); }
//                    },
//                    close: function (event, ui) {

//                        //                        __doPostBack(', '');  // To refresh gridview when user close dialog
//                    }
//                });
//                $dialog.dialog('open');
//                e.preventDefault();
//            });
//        });

       
    </script>

 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
         <tr >
            <td >
                <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center;
                height: 22px;" runat="server">
            </div>
            </td>
        </tr>
        <tr class="style4">
            <td class="style5">
                <strong style="">Pending Request List for Cancelation </strong>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                    AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <%--<asp:BoundField DataField="xrow"/>--%>
                        <asp:BoundField DataField="xreqdt" HeaderText="Request Date" />
                        <asp:BoundField DataField="xdate" HeaderText="Journey Date" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="xtime" HeaderText="Journey Time" />
                        <asp:BoundField DataField="xcoach" HeaderText="Coach No" />
                        <asp:BoundField DataField="xseat" HeaderText="Seat No" />
                        <asp:BoundField DataField="xroute" HeaderText="Route" />
                        <asp:BoundField DataField="xcontact" HeaderText="Contact No." />
                        <asp:BoundField DataField="xremark" HeaderText="Remark" />
                        <asp:BoundField DataField="xreqby" HeaderText="Requested By" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%>
                                <%-- <a id="popup" href='ztpermis.aspx?xuser=<%# Eval("xuser") %>&page=user'>Set Permission</a>--%>
                                 <asp:LinkButton ID="approve" runat="server" CommandName="" CommandArgument='<%#Eval("xrow") %>' OnClick="fnApprove">Approve</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <%-- <asp:LinkButton ID="cancel" runat="server" >Cancel</asp:LinkButton>--%>
                                <%-- <a id="popup" href='ztpermis.aspx?xuser=<%# Eval("xuser") %>&page=user'>Set Permission</a>--%>
                               <asp:LinkButton ID="cancel" runat="server" CommandName="" CommandArgument='<%#Eval("xrow") %>' OnClick="fnCancel">Cancel</asp:LinkButton>
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
    <div id="popupcancel" style="height: 101px; width: 476px; vertical-align: middle;
        text-align: center; display:none;">
        <table class="style1">
            <tr>
                <td class="style6" colspan="2">
                    Do you really want to cancel this request?
                </td>
            </tr>
            <tr>
                <td class="style7" style="margin: auto; padding: 2px;">
                    &nbsp;
                </td>
                <td style="margin: auto; padding: 2px;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="xrowid" runat="server" />
</asp:Content>

