<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ztcoach.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztcoach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>    <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
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
            width: 99%;
            height: 53px;
        }
        #xdesc
        {
            height: 71px;
            width: 179px;
        }
        .style31
        {
            text-align: right;
            font-size: medium;
            color: #003300;
            height: 100px;
        }
        .style32
        {
            text-align: right;
            height: 30px;
        }
        .style33
        {
            width: 204px;
            height: 30px;
        }
        .style34
        {
            width: 103px;
            height: 30px;
        }
        .style35
        {
            width: 167px;
            height: 30px;
        }
        .style36
        {
            width: 103px;
            text-align: right;
            height: 30px;
        }
        .style37
        {
            text-align: left;
            height: 9px;
        }
        .style41
        {
            font-size: medium;
        }
        .style42
        {
            height: 25px;
        }
        .style46
        {
            height: 28px;
        }
        .style47
        {
            height: 21px;
        }
        .style27
        {
            width: 88px;
        }
        .style26
        {
            width: 78px;
        }
        .style25
        {
            width: 93px;
        }
        .style28
        {
            width: 68px;
        }
        .style48
        {
            text-align: right;
            height: 28px;
        }
        .style49
        {
            text-align: right;
            height: 31px;
        }
        .style50
        {
            width: 204px;
            height: 31px;
        }
        .style51
        {
            width: 103px;
            height: 31px;
        }
        .style52
        {
            width: 167px;
            height: 31px;
        }
        .style53
        {
            width: 518px;
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




        function ConfirmMessage1() {
            var selectedvalue = confirm("Do you want to Confirm?");
            if (selectedvalue) {
                document.getElementById('<%=comfirmmsg.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=comfirmmsg.ClientID %>').value = "No";
            }
        }


        /*Validation check of control*/
//        function validation()
//        {
//            if (document.getElementById('<%=xcoachno.ClientID %>').value == "") {
//                alert("Please enter coach no");
//                return false;

//            }
//            else if (document.getElementById('<%=xbustype.ClientID %>').value == "[Select]") {
//                alert("Please select bus type");
//                return false;
//            }
//            else if (document.getElementById('<%=xmainrt.ClientID %>').value == "[Select]") {
//                alert("Please select main route");
//                return false;
//            }
//            else if(document.getElementById('<%=rtcount.ClientID %>').value != "") {

//                var rtc = document.getElementById('<%=rtcount.ClientID %>').value;
//                for (i = 0; i < parseInt(rtc); i++) {
//                    document.getElementById('<%=ctlid.ClientID %>').value = "dwh" + eval(i);
//                    if (document.getElementById('<%= ctlid.ClientID %>').value == "--") {
//                        alert("Please fill all time");
//                        return false;
//                    }
//                }
//            }
//            
//        }

    </script>
    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!")
        }
    </script>
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
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
                <strong>Coach Assign</strong>
            </td>
            <td class="style2" rowspan="2">
                <asp:Panel ID="Panel1" runat="server" Height="363px" ScrollBars="Auto" Width="536px">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Coach No">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xrole" runat="server" Text='<%#Eval("xcoachno") %>' OnClick="FillControls"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="xbustype" HeaderText="Bus Type" />
                            <asp:BoundField DataField="xmainrt" HeaderText="Main Route" />
                            <asp:BoundField DataField="xtime" HeaderText="Time" />
                            <asp:TemplateField  HeaderText="Active?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="status" runat="server" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>'
                                        Enabled="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="xapprove" HeaderText="Status" />
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
                <table style="width: 100%; height: 325px;">
                    <tr>
                        <td class="style48" colspan="4" valign="top">
                            <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center; height: 22px;"
                                runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32" valign="top">
                            Coach No
                        </td>
                        <td class="style33" valign="top">
                            <asp:TextBox ID="xcoachno" runat="server" Width="151px"></asp:TextBox>
                        </td>
                        <td class="style34">
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style36" valign="top">
                            Bus Type
                        </td>
                        <td class="style33" valign="top">
                            <asp:DropDownList ID="xbustype" runat="server" Width="151px" Height="24px" ViewStateMode="Enabled">
                            </asp:DropDownList>
                        </td>
                        <td class="style36">
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style36" valign="top">
                            Main Route
                        </td>
                        <td class="style33" valign="top">
                            <asp:DropDownList ID="xmainrt" runat="server" Width="151px" AutoPostBack="True" OnSelectedIndexChanged="xmainrt_SelectedIndexChanged"
                                ViewStateMode="Enabled">
                            </asp:DropDownList>
                        </td>
                        <td class="style36">
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style49" valign="top">
                            Active?
                        </td>
                        <td class="style50" valign="top">
                            <asp:CheckBox ID="zactive" runat="server" Text="Active" />
                        </td>
                        <td class="style51">
                            &nbsp;
                        </td>
                        <td class="style52">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style31" colspan="4" valign="top">
                            <table class="style23">
                                <tr>
                                    <td class="style37">
                                        <strong>Subroutes</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style42" style="text-align: left">
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>


 <%--   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="height: 103px; width: 579px">
                <tr>
                    <td class="style46">
                        <strong><span class="style41">Counter to go through</span></strong>
                    </td>
                </tr>
                <tr>
                    <td class="style42">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/images/add.gif"
                            Width="27px" onclick="ImageButton1_Click" />
                        <asp:Label ID="Labelcounter" runat="server" Style="font-weight: 700; font-size: medium"
                            Text="Add Counter"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style47">
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>

                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
             
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table style="width: 576px">
        <tr>
                    <td __designer:mapid="5cf" class="style53">
                        <table class="style23" __designer:mapid="5d0">
                            <tr __designer:mapid="5d1">
                                <td class="style27" __designer:mapid="5d2">
                                    <asp:Button ID="btnClear" runat="server" Font-Bold="True" Height="30px" 
                                        OnClick="btnClear_Click" Text="Clear" Width="100px" />
                                </td>
                                <td class="style26" __designer:mapid="5d4">
                                    <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Height="30px"
                                         Text="Add" Width="100px" 
                                        onclick="btnAdd_Click" />
                                </td>
                                <td class="style25" __designer:mapid="5d6">
                                    <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" 
                                        OnClick="btnUpdate_Click" Style="text-align: center" Text="Update" 
                                        Width="100px" />
                                </td>
                                <td class="style28" __designer:mapid="5d8">
                                    <asp:Button ID="btnDelete" runat="server" ClientIDMode="Static" 
                                        Font-Bold="True" Height="30px" OnClick="btnDelete_Click" 
                                        OnClientClick="javascript:ConfirmMessage()" Text="Delete" Width="100px" 
                                        Enabled="False" />
                                </td>
                                <td class="style28" __designer:mapid="5d8">
                                    <asp:Button ID="btnapprove" runat="server" Font-Bold="True" Height="31px" 
                                        Text="Approve" Width="100px" OnClientClick="javascript:ConfirmMessage1()" 
                                        onclick="btnapprove_Click" />
                                </td>
                                <td __designer:mapid="5da">
                                    &nbsp;
                                </td>
                                <td __designer:mapid="5db">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
    <tr>
    <td class="style53"></td>
    </tr>
    <tr>
    <td class="style53">&nbsp;</td>
    </tr>
    <tr>
    <td class="style53">&nbsp;</td>
    </tr>
    <tr>
    <td class="style53">&nbsp;</td>
    </tr>
    </table>
    <asp:HiddenField ID="txtconformmessageValue" runat="server" />
     <asp:HiddenField ID="rtcount" runat="server" />
     <asp:HiddenField ID="ctlid" runat="server" />
     <asp:HiddenField ID="ctcount" runat="server" />
     <asp:HiddenField ID="comfirmmsg" runat="server" />
    <div id="message" runat="server">
    </div>


    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
</asp:Content>
