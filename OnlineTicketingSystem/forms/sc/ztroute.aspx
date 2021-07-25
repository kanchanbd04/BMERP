<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ztroute.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztroute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
<%--   <link rel="stylesheet" href="../../Scripts/jquery-ui-1.8.17/themes/base/jquery.ui.all.css">
--%>    <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
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
            width: 836px;
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
        .style6
        {
        }
        .style8
        {
            width: 15px;
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
        #TextArea1
        {
            height: 68px;
            width: 188px;
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
        .style23
        {
            width: 100%;
        }
        .style25
        {
            width: 93px;
        }
        .style26
        {
            width: 78px;
        }
        .style27
        {
            width: 88px;
        }
        .style28
        {
            width: 68px;
        }
        .style29
        {
            width: 167px;
        }
        #xdesc
        {
            height: 71px;
            width: 179px;
        }
        .style31
        {
            width: 83px;
            text-align: left;
        }
        .style32
        {
        }
        .style34
        {
            width: 24px;
        }
        .style35
        {
            width: 115px;
        }
        .style36
        {
            width: 61px;
        }
        .style37
        {
            width: 122px;
        }
        .style38
        {
            width: 37px;
        }
        .style39
        {
            width: 172px;
            text-align: center;
        }
        .style40
        {
            text-align: right;
            width: 83px;
        }
        .style41
        {
            width: 162px;
            text-align: left;
        }
        .style42
        {
            width: 83px;
        }
        .style43
        {
            text-align: right;
            width: 83px;
            height: 22px;
        }
        .style44
        {
            width: 162px;
            text-align: left;
            height: 22px;
        }
        .style45
        {
            width: 15px;
            text-align: right;
            height: 22px;
        }
        .style46
        {
            width: 167px;
            height: 22px;
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
    <%#Eval("xmf") + " - " + Eval("xmt")%>
    <script type="text/javascript">

        $(document).ready(function () {
            $('a#popup').live('click', function (e) {

                var page = $(this).attr("href")  //get url of link

                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 600,
                    width: 'auto',
                    title: "Role Permission",

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog" style="display: none">
    </div>
    <table style="width: 98%; height: 111px;">
        <tr>
            <td class="style4">
                <strong>Route View</strong>
            </td>
            <td class="style2" rowspan="2">
                <asp:Panel ID="Panel1" runat="server" Height="259px" ScrollBars="Auto" 
                    Width="536px">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False" Width="358px" Height="128px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Route ID">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xmrid" runat="server" Text='<%#Eval("xmrid") %>' OnClick="FillControls"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Main Route">
                                <ItemTemplate>
                                    <%#Eval("xmf") + " - " + Eval("xmt")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' /></ItemTemplate>
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
            </td>
        </tr>
        <tr>
            <td class="style3">
                <table style="width: 100%;">
                    <tr>
                        <td class="style6" colspan="4">
                            <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center;"
                                runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style40">
                            Main Route ID
                        </td>
                        <td class="style41">
                            <asp:Label ID="xmrid" runat="server" Font-Bold="True" Font-Size="Medium" Text="Route"></asp:Label>
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style43">
                            From
                        </td>
                        <td class="style44">
                            <asp:TextBox ID="xmf" runat="server" Width="151px" 
                                OnTextChanged="xmf_TextChanged"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"
                                Text="*"></asp:Label>
                        </td>
                        <td class="style45">
                            To
                        </td>
                        <td class="style46">
                            <asp:TextBox ID="xmt" runat="server" Width="151px"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"
                                Text="*"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style40">
                            Active?
                        </td>
                        <td class="style41">
                            <asp:CheckBox ID="zactive" runat="server" Text="Active" Checked="True" />
                        </td>
                        <td class="style8">
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style40">
                            Sub Route?
                        </td>
                        <td class="style41">
                            <asp:CheckBox ID="xhsub" runat="server" Text="Sub Route" AutoPostBack="True" OnCheckedChanged="xhsub_CheckedChanged" />
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style40">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" colspan="4">
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
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                            OnClick="btnDelete_Click" Visible="False" />
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
                    <tr>
                        <td class="style31">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                        </td>
                        <td class="style8">
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" colspan="4">
                            <asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Auto" Visible="False">
                                <table class="style23">
                                    <tr>
                                        <td class="style38">
                                            From
                                        </td>
                                        <td class="style37">
                                            <asp:DropDownList ID="xsf" runat="server" Height="18px" Width="151px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style34">
                                            To
                                        </td>
                                        <td class="style35">
                                            <asp:TextBox ID="xst" runat="server" Width="150px" 
                                                OnTextChanged="xst_TextChanged"></asp:TextBox>
                                        </td>
                                        <td class="style36">
                                            <asp:CheckBox ID="zactivesub" runat="server" Text="Active?" Checked="True" />
                                        </td>
                                        <td class="style39">
                                            <asp:Button ID="btnaddsub" runat="server" Text=" Add Sub" Width="93px" Style="text-align: center"
                                                OnClick="btnaddsub_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style38">
                                            &nbsp;
                                        </td>
                                        <td class="style37">
                                            &nbsp;
                                        </td>
                                        <td class="style34">
                                            &nbsp;
                                        </td>
                                        <td class="style35">
                                            &nbsp;
                                        </td>
                                        <td class="style36">
                                            &nbsp;
                                        </td>
                                        <td class="style39">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style32" colspan="7">
                                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                AutoGenerateColumns="False" Width="328px" Height="115px">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    
                                                    <asp:TemplateField HeaderText="Sub Route">
                                                        <ItemTemplate>
                                                            <%#Eval("xsf") + " - " + Eval("xst")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Active?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' /></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="Edit"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="srid" Value='<%# Eval("xsrid") %>'
                                                                runat="server" />
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
                                    <tr>
                                        <td class="style38">
                                            &nbsp;
                                        </td>
                                        <td class="style37">
                                            &nbsp;
                                        </td>
                                        <td class="style34">
                                            &nbsp;
                                        </td>
                                        <td class="style35">
                                            &nbsp;
                                        </td>
                                        <td class="style36">
                                            &nbsp;
                                        </td>
                                        <td class="style39">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                            &nbsp;
                        </td>
                        <td class="style41">
                            &nbsp;
                            <asp:HiddenField ID="xsrid" runat="server" />
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td class="style29">
                            <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="message" runat="server">
    </div>
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
</asp:Content>
