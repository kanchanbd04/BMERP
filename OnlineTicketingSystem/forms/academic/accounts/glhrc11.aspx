<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="glhrc11.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.Accounts.glhrc11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <script src="../../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
    <script>
        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Message",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };
    </script>
    <style type="text/css">
        .style2
        {
            vertical-align: top;
        }
        .style3
        {
            height: 123px;
            width: 938px;
            vertical-align: top;
        }
        .style4
        {
            width: 100%;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #999966;
        }
        #Password1
        {
            width: 151px;
        }
        #Password2
        {
            width: 151px;
        }
        #TextArea1
        {
            height: 68px;
            width: 251px;
        }
        #xuserinfo
        {
            height: 83px;
            width: 181px;
        }
        #xpass
        {
            width: 151px;
        }
        #expass
        {
            width: 151px;
        }
        #exrepass
        {
            width: 151px;
        }
        #exuserinfo
        {
            width: 180px;
            height: 74px;
            margin-top: 0px;
        }
        #xlong
        {
            height: 71px;
            width: 179px;
        }
        .style5
        {
            width: 100%;
        }
        .style7
        {
            text-align: left;
        }
        .style8
        {
            text-align: right;
        }
        .style10
        {
            height: 21px;
        }
        .style11
        {
            width: 93px;
        }
        .auto-style1 {
            width: 781px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #999966;
        }
        .auto-style2 {
            height: 123px;
            width: 781px;
            vertical-align: top;
        }
    </style>
    <script language="javascript">

        function ConfirmMessage() {
            var selectedvalue = confirm("Do you want to delete data?");
            if (selectedvalue) {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
            }
        }

    </script>
    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!")
        }
    </script>
    <%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%>
    <script type="text/javascript">

        $(document).ready(function () {
           <%-- $('#<%=business.ClientID %>').live('click', function (e) {

                // var page = $(this).attr("href")  //get url of link
                var page = "../../BMERP/zbusiness_sel.aspx?level=level1&xhrc1=<%= ViewState["level1"] %>"
                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 600,
                    width: 'auto',
                    title: "Select Business",

                    buttons: {
                        "Close": function () { $dialog.dialog('close'); }
                    },
                    close: function (event, ui) {

                        //                        __doPostBack(', '');  // To refresh gridview when user close dialog
                    }
                });
                $dialog.dialog('open');
                e.preventDefault();
            });--%>
        });

       
    </script>
    <%--  <script>
          $(function () {
              $("#<%=xeffdt.ClientID %>").datepicker();
          });
	</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog" style="display: none">
    </div>
    
    <div style="width: 60%; display: inline-block; vertical-align: top;">
    
    <table style="width: 100%; height: 111px;">
        <tr style="width: 100%;">
            <td class="auto-style1" colspan="2">
                <strong>Accounts Group Level 1</strong>
            </td>
           <%-- <td class="style2" >
                <asp:Panel ID="Panel1" runat="server" Height="363px" ScrollBars="Auto" Width="400px">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Level1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xhrc1" runat="server" Text='<%#Eval("xhrc1") %>' OnClick="FillControls"></asp:LinkButton>
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
                </asp:Panel>
            </td>--%>
        </tr>
        <tr style="width: 100%;">
            <td class="auto-style2">
                <table class="style5">
                    <tr>
                        <td class="style7">
                            <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">level2&gt;&gt;</asp:LinkButton>
                           <%-- <a id="lavel1" href='zunitpermis.aspx?xuser=<%# Eval("xhrc1") %>&page=user'>level2&gt;&gt;</a>--%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7" colspan="3">
                            <div id="msg" style="font-weight: bold; font-size: 12px; color: Red; text-align: center;"
                                runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            Level 1
                        </td>
                        <td class="style10">
                        </td>
                        <td class="style10">
                            <asp:TextBox ID="xhrc1" runat="server" Width="251px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            Description
                        </td>
                        <td class="style10">
                        </td>
                        <td class="style10">
                            <textarea runat="server" id="xlong" name="S1" rows="2"></textarea>
                        </td>
                    </tr>
                <%--    <tr>
                        <td class="style8">
                            Business
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:LinkButton ID="business" runat="server">Select Business</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7" colspan="3">
                            <table class="style23">
                                <tr>
                                    <td class="style27">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" Font-Bold="True"
                                            Height="30px" OnClick="btnClear_Click" />
                                    </td>
                                    <td class="style26">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Font-Bold="True"
                                            Height="30px" OnClick="btnAdd_Click" />
                                    </td>
                                    <td class="style25">
                                        <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px" OnClick="btnUpdate_Click" />
                                    </td>
                                    <td class="style28">
                                        <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage();"
                                            OnClick="btnDelete_Click" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="style11">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7" colspan="3">
                            <%--<asp:Panel ID="Panel2" runat="server" Height="363px" ScrollBars="Auto" Width="400px">--%>
                                <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Level2">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="xhrc2" runat="server" Text='<%#Eval("xhrc2") %>' OnClick="fnGoToNextLevel"></asp:LinkButton>
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
                            <%--</asp:Panel>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

        </div>
    <div style="width: 38%; display: inline-block; vertical-align: top;">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Level1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xhrc1" runat="server" Text='<%#Eval("xhrc1") %>' OnClick="FillControls"></asp:LinkButton>
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
        </div>
    <div id="message" runat="server">
    </div>
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
</asp:Content>
