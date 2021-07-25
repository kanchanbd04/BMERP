<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ztruncost.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztruncost" %>

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
            width: 100%;
            height: 539px;
        }
        .style2
        {
            width: 77%;
            height: 352px;
        }
        .style6
        {
            height: 30px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #999966;
        }
        .style7
        {
            height: 26px;
        }
        .style14
        {
            height: 33px;
        }
        .style19
        {
            width: 84px;
            height: 192px;
        }
        .style20
        {
            text-align: right;
        }
        .style23
        {
            height: 33px;
            width: 250px;
        }
        .style24
        {
            width: 250px;
            height: 192px;
        }
        .style25
        {
            width: 501px;
        }
        .style26
        {
            width: 501px;
            height: 192px;
        }
        .style27
        {
            height: 192px;
        }
        .style28
        {
            width: 100%;
            height: 78px;
        }
        .style29
        {
            width: 101px;
        }
        .style30
        {
            width: 104px;
        }
        .style31
        {
            width: 105px;
        }
        .style32
        {
            height: 37px;
        }
        .style33
        {
            text-align: right;
            height: 37px;
        }
        .style34
        {
            height: 37px;
            width: 250px;
        }
        #TextArea1
        {
            height: 83px;
            width: 217px;
        }
        #xremarks
        {
            height: 95px;
        }
    </style>
    <script>

        function pageLoad(sender, args) {
            $("#<%=xdate.ClientID %>").datepicker();


        }

        function ConfirmMessage1() {
            var selectedvalue = confirm("Do you want to Confirm?");
            if (selectedvalue) {
                document.getElementById('<%=comfirmmsg.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=comfirmmsg.ClientID %>').value = "No";
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td align="left" valign="top">
                <table class="style2">
                    <tr>
                        <td colspan="4" class="style6">
                            <center style="width: 819px">
                                <strong>Running Cost</strong></center>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="style7">
                            <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center;"
                                runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20" valign="top" align="left" colspan="2" rowspan="2">
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <table class="style28">
                                        <tr>
                                            <td>
                                                Date:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="xdate" runat="server" Height="27px" Width="151px" 
                                                    OnTextChanged="xdate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style32">
                                                Coach No:
                                            </td>
                                            <td align="left" class="style32" valign="top">
                                                <asp:DropDownList ID="xcoachno" runat="server" Height="34px" Width="151px" 
                                                    AutoPostBack="True" onselectedindexchanged="xcoachno_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="style32">
                                                Remarks:
                                            </td>
                                            <td align="left" class="style32" valign="top">
                                                <textarea id="xremarks" cols="20" rows="2" runat="server"></textarea>
                                            </td>
                                        </tr>
                                    </table>
                            <%--    </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td class="style25" align="left" valign="top" rowspan="7">
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" Height="332px" ScrollBars="Auto">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </asp:Panel>

                            </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="xcoachno" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="style14" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td class="style14" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td class="style20" valign="top">
                            &nbsp;
                        </td>
                        <td class="style23" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td class="style14" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td class="style20" valign="top">
                            &nbsp;
                        </td>
                        <td class="style23" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td class="style14" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style20" valign="top">
                            &nbsp;
                        </td>
                        <td class="style23" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td class="style14" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style20" valign="top">
                            &nbsp;
                        </td>
                        <td class="style23" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td class="style14" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style33" valign="top">
                            &nbsp;
                        </td>
                        <td class="style34" align="left" valign="top">
                            &nbsp;
                        </td>
                        <td class="style32" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style287" valign="top" colspan="4">
                            <table class="style28">
                                <tr>
                                    <td class="style29">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" Font-Bold="True"
                                            Height="30px" onclick="btnClear_Click" />
                                    </td>
                                    <td class="style30">
                                        <asp:Button ID="btnShow" runat="server" Text="Show" Width="100px" Font-Bold="True"
                                            Height="30px" onclick="btnShow_Click" />
                                    </td>
                                    <td class="style31">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Font-Bold="True"
                                            Height="30px" onclick="btnAdd_Click" />
                                    </td>
                                    <td class="style31">
                                        <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px"  onclick="btnUpdate_Click" />
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnComfirm" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Confirm" Width="100px" OnClientClick="javascript:ConfirmMessage1()" 
                                            onclick="btnComfirm_Click" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                        </td>
                        <td class="style24">
                        </td>
                        <td class="style26">
                        </td>
                        <td class="style27">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="comfirmmsg" runat="server" />
</asp:Content>
