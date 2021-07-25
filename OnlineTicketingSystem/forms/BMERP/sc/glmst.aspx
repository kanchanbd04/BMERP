<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="glmst.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.sc.glmst"
    EnableEventValidation="false" %>

<%@ Import Namespace="OnlineTicketingSystem" %>
<%@ Import Namespace="OnlineTicketingSystem.Forms" %>
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
            text-align: right;
        }
        .style8
        {
            width: 346px;
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
        #xdesc
        {
        }
        .style30
        {
            text-align: right;
            vertical-align: top;
        }
        .style31
        {
            text-align: right;
            height: 21px;
        }
        .style32
        {
            width: 157px;
            text-align: right;
            vertical-align: top;
            height: 24px;
        }
        .style34
        {
            width: 346px;
            height: 24px;
        }
        .style400
        {
            width: 938px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #F5F5F5;
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
    <%--<asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px" OnClick="btnUpdate_Click" />--%>
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
    <script>
        $(function () {
            $("#<%=xeffdt.ClientID %>").datepicker();
        });
    </script>
    <%--<asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                            OnClick="btnDelete_Click" Visible="False" />--%>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#<%=business.ClientID %>').live('click', function (e) {
//                alert($("#<%= key.ClientID%>").val());
                var key1 = $("#<%= key.ClientID%>").val();
                // var page = $(this).attr("href")  //get url of link
                var page = "../../BMERP/zbusiness_sel_glmst_new.aspx?key=" + key1;
                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 600,
                    width: 1100,
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
                <strong>Chart of Accounts</strong>
            </td>
            <td class="style2" rowspan="2">
                <table class="style23">
                    <tr>
                        <td class="style400">
                            <asp:Label ID="Label1" runat="server" Text="Subaccount(s) of ()"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" Height="502px" ScrollBars="Auto" Width="536px">
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="City Name">
                                            <ItemTemplate>
                                                <%-- <asp:LinkButton ID="xrole" runat="server" Text='<%#Eval("xname") %>' OnClick="FillControls"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="xsrtnm" HeaderText="Sort Name" />
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
                </table>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <table style="width: 100%;">
                    <tr>
                        <td class="style31" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center;"
                                        runat="server">
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Row
                        </td>
                        <td class="style8">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="xrow" runat="server" Text="Label" Style="text-align: center; font-weight: 700;"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Account
                        </td>
                        <td class="style8">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="xacc" runat="server" Width="151px"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Description
                        </td>
                        <td class="style8">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="xdesc" runat="server" Width="221px" Height="22px"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Account Type
                        </td>
                        <td class="style8">
                            <table class="style23">
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Asset" value="Asset" runat="server" Text="Asset" ForeColor="Black"
                                                    GroupName="acctype" Checked="true" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Expenditure" value="Expenditure" Text="Expenditure" runat="server"
                                                    ForeColor="Black" GroupName="acctype" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Income" value="Income" Text="Income" runat="server" ForeColor="Black"
                                                    GroupName="acctype" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Liability" Value="Liability" Text="Liability" runat="server"
                                                    ForeColor="Black" GroupName="acctype" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Account Usage
                        </td>
                        <td class="style34">
                            <table class="style23">
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel22" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="AP" Value="AP" Text="AP" runat="server" ForeColor="Black" GroupName="accusage" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel23" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="AR" Value="AR" Text="AR" runat="server" ForeColor="Black" GroupName="accusage" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel24" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Bank" Value="Bank" Text="Bank" runat="server" ForeColor="Black"
                                                    GroupName="accusage" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel25" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Cash" Value="Cash" Text="Cash" runat="server" ForeColor="Black"
                                                    GroupName="accusage" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Ledger" Value="Ledger" Text="Ledger" runat="server" ForeColor="Black"
                                                    GroupName="accusage" Checked="true" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Account Source
                        </td>
                        <td class="style34">
                            <table class="style23">
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel26" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Customer" Value="Customer" Text="Customer" runat="server" ForeColor="Black"
                                                    GroupName="accsource" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel27" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Employee" Value="Employee" Text="Employee" runat="server" ForeColor="Black"
                                                    GroupName="accsource" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="None" Value="None" Text="None" runat="server" ForeColor="Black"
                                                    GroupName="accsource" Checked="true" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel28" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Subaccount" Value="Subaccount" Text="Subaccount" runat="server"
                                                    ForeColor="Black" GroupName="accsource" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel29" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Supplier" Value="Supplier" Text="Supplier" runat="server" ForeColor="Black"
                                                    GroupName="accsource" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel30" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="Bank1" Value="Bank" Text="Bank" runat="server" ForeColor="Black"
                                                    GroupName="accsource" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Level1
                        </td>
                        <td class="style34">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="xhrc1" runat="server" Height="21px" Width="221px" AutoPostBack="True"
                                        OnSelectedIndexChanged="xhrc1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%--<asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px" OnClick="btnUpdate_Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Level2
                        </td>
                        <td class="style34">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="xhrc2" runat="server" Height="21px" Width="221px" AutoPostBack="True"
                                        OnSelectedIndexChanged="xhrc2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%--<asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                            OnClick="btnDelete_Click" Visible="False" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Level3
                        </td>
                        <td class="style34">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="xhrc3" runat="server" Height="21px" Width="221px" AutoPostBack="True"
                                        OnSelectedIndexChanged="xhrc3_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc2" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%--<asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Level4
                        </td>
                        <td class="style34">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="xhrc4" runat="server" Height="21px" Width="221px" AutoPostBack="True"
                                        OnSelectedIndexChanged="xhrc4_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc2" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc3" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Level5
                        </td>
                        <td class="style34">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="xhrc5" runat="server" Height="21px" Width="221px" AutoPostBack="True">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc2" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc3" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="xhrc4" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%-- <select id="xhrc5" runat="server">
                            </select>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Special Account Group
                        </td>
                        <td class="style34">
                            <asp:DropDownList ID="xspaccgp" runat="server" Height="21px" Width="221px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Indirect Cash Flow Setup
                        </td>
                        <td class="style34">
                            <asp:DropDownList ID="xcf1" runat="server" Height="21px" Width="221px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Effected Date
                        </td>
                        <td class="style34">
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="xeffdt" runat="server" Width="151px"></asp:TextBox>
                                    [MM/DD/YYYY]
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Active?
                        </td>
                        <td class="style8">
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:CheckBox ID="zactive" runat="server" Text="Active" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Business
                        </td>
                        <td class="style8">
                            <asp:LinkButton ID="business" runat="server">Select Business</asp:LinkButton>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Entry By
                        </td>
                        <td class="style8">
                            <asp:UpdatePanel ID="UpdatePanel17" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="zemail" runat="server"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            Update By
                        </td>
                        <td class="style8">
                            <asp:UpdatePanel ID="UpdatePanel18" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="xemail" runat="server"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table class="style23">
                                        <tr>
                                            <td class="style27">
                                                <%--<asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" Font-Bold="True"
                                            Height="30px" OnClick="btnClear_Click" />--%>
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" Font-Bold="True"
                                                    Height="30px" OnClick="btnClear_Click" />
                                            </td>
                                            <td class="style26">
                                                <%--<asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Font-Bold="True"
                                            Height="30px" OnClick="btnAdd_Click" />--%>
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Font-Bold="True"
                                                    Height="30px" OnClick="btnAdd_Click" />
                                            </td>
                                            <td class="style25">
                                                <%--<asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px" OnClick="btnUpdate_Click" />--%>
                                                <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                                    Text="Update" Width="100px" OnClick="btnUpdate_Click" />
                                            </td>
                                            <td class="style28">
                                                <%--<asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                            OnClick="btnDelete_Click" Visible="False" />--%>
                                                <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                                    Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                                    OnClick="btnDelete_Click" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <%--<asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />--%>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style400" colspan="2">
                            <asp:Label ID="level1" runat="server" Text="List of Account(s)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style30" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Height="410px">
                                        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                            AutoGenerateColumns="False">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Row">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' OnClick="FillControls"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="xacc" HeaderText="Account" />
                                                <asp:BoundField DataField="xdesc" HeaderText="Description" />
                                                <asp:BoundField DataField="xacctype" HeaderText="Account Type" />
                                                <asp:BoundField DataField="xaccsource" HeaderText="Account Source" />
                                                <asp:BoundField DataField="xeffdt" HeaderText="Effected Date" DataFormatString="{0:d}" />
                                                <asp:TemplateField HeaderText="Active?">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="status0" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            &nbsp;&nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                            <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                            <asp:UpdatePanel ID="UpdatePanel31" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                            <asp:HiddenField
                                ID="key" runat="server" />
                            </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                     <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                      <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
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
