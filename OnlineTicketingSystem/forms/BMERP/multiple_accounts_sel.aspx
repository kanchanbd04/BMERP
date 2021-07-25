<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="multiple_accounts_sel.aspx.cs"
    Inherits="OnlineTicketingSystem.forms.BMERP.multiple_accounts_sel" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        #TextArea1
        {
            height: 191px;
        }
        #TextArea2
        {
            height: 190px;
            width: 162px;
        }
        #TextArea3
        {
            height: 193px;
            width: 182px;
        }
        #msg
        {
            color: #FF0000;
        }
        #xhrc1
        {
            width: 221px;
        }
        #xhrc2
        {
            width: 221px;
        }
        #xhrc3
        {
            width: 221px;
        }
        #xhrc4
        {
            width: 221px;
        }
        #xhrc5
        {
            width: 221px;
        }
    </style>
    <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript">
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

        function update(zid) {
            //window.opener.update(document.getElementById('txt').value);
            var ctlid = $("#<%= ctlid_v.ClientID%>").val();
            var rowid = $("#<%= rowid_v.ClientID%>").val();
            window.opener.update(zid,ctlid,rowid);
            self.close();
            //alert("Hi!");
            //alert(ctlid);
        }
    </script>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <div>
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <%--     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>--%>
                                <%--    </ContentTemplate>
                                </asp:UpdatePanel>--%>
                                <table width="100%">
                                    <tr>
                                        <td class="style5">
                                            <asp:Panel ID="Panel1" runat="server" Height="317px" Width="385px" 
                                                ScrollBars="Auto">
                                   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>--%>
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                    CellPadding="4" ForeColor="#333333" GridLines="None" Style="font-size: small">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Account">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="xacc0" runat="server"  
                                                                    Text='<%#Eval("xacc") %>' OnClientClick='<%# String.Format("update(\"{0}\");", Eval("xacc")) %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="xdesc" HeaderText="Description" />
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
                                       <%-- </ContentTemplate>
                                        <Triggers>
                                             <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                            </asp:Panel>
                                        </td>
                                        <td class="style2">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr><td>
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td></tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr align="center">
                <td>
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td>
                    <div id="dialog" style="display: none">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="ctlid_v" runat="server" />
    <asp:HiddenField ID="rowid_v" runat="server" />
    </form>
    
</body>
</html>
