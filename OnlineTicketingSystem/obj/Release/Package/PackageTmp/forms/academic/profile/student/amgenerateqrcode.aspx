<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="amgenerateqrcode.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.amgenerateqrcode"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function fnPrintQRCode() {
            // alert("Hi");
            var xclass1 = $("#<%= xclass.ClientID%>").val();
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var xgroup1 = $("#<%= xgroup.ClientID%>").val();
            var xsection1 = $("#<%= xsection.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/amstdidbarcode.aspx?xsession=' + xsession1 + '&xclass=' + xclass1 + '&xgroup=' + xgroup1 + '&xsection=' + xsection1, 'stdbarcode', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="/images/loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="bm_academic_container">
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>
                <div class="bm_academic_container_footer">
                    <div class="footer_list_padding">
                        <div class="bm_academic_grid_container" id="list" runat="server">
                            <div class="grid_header">
                                <div class="grid_header_label" id="_grid_header" style="margin-top: 3px" runat="server">
                                    Generate QR Code:
                                </div>
                                <div class="grid_header_control">
                                </div>
                                <div class="flot_right">
                                    <%-- <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>--%>
                                    <%-- <div class="grid_header_row">
                                <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                    OnTextChanged="fnFilterByRow"></asp:TextBox>
                            </div>--%>
                                    <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 200px; margin-top: 3px;margin-right: 10px">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label12" runat="server" Text="From :" AssociatedControlID="xfrom"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 74%; ">
                                    <asp:TextBox ID="xfrom" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="bm_ctl_container_50_50" style="float: left; width: 200px; margin-top: 3px;margin-right: 10px">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label1" runat="server" Text="To :" AssociatedControlID="xto"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 74%; ">
                                    <asp:TextBox ID="xto" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                </div>
                            </div>--%>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px;
                                        margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 35%">
                                            <asp:Label ID="Label52" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 65%;">
                                            <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_s_grid bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px;
                                        margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 30%">
                                            <asp:Label ID="Label540" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 70%;">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px; display: none;
                                        margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 30%">
                                            <asp:Label ID="Label1" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 70%;">
                                            <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px;
                                        margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 35%">
                                            <asp:Label ID="Label2" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 65%;">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox1"
                                    Width="200px" OnTextChanged="fnFilterByRow" ></asp:TextBox>
                            </div>--%>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        border: none; height: 32px">
                                        <%--<div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label2" runat="server" Text="To :" AssociatedControlID="xexamdate"
                                        CssClass="label"></asp:Label>
                                </div>--%>
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/gear_icon.png"
                                                Width="25px" Height="25px" OnClick="fnFillDataGrid1" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        border: none; height: 32px">
                                        <%--<div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label2" runat="server" Text="To :" AssociatedControlID="xexamdate"
                                        CssClass="label"></asp:Label>
                                </div>--%>
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                            <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                        <%--<div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label2" runat="server" Text="To :" AssociatedControlID="xexamdate"
                                        CssClass="label"></asp:Label>
                                </div>--%>
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                Width="25px" Height="25px" OnClientClick="fnPrintQRCode();" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="grid_body">
                                <div style="width: 100%; float: left;">
                                    <asp:GridView ID="_grid_emp" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                        CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                        RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                        PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="_grid_emp_OnRowDataBound">
                                        <Columns>
                                           <asp:TemplateField HeaderText="No" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-Font-Size="30px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="xstdid" HeaderText="ID" ItemStyle-Width="100px"
                                            ItemStyle-CssClass="pad5" ItemStyle-Font-Size="30px" ItemStyle-HorizontalAlign="Center" />
                                             <asp:ImageField DataImageUrlField="xqrcodelink" HeaderText="QR Code" ItemStyle-Width="100px" ItemStyle-Height="100px"
                                            ControlStyle-Width="100px" ControlStyle-Height="100px" />
                                        <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="700px"
                                            ItemStyle-CssClass="pad5" ItemStyle-Font-Size="40px" />
                                        <asp:ImageField DataImageUrlField="ximagelink" HeaderText="Image" ItemStyle-Width="100px" ItemStyle-Height="100px"
                                            ControlStyle-Width="100px" ControlStyle-Height="100px" />
                                        <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="250px"
                                            ItemStyle-CssClass="pad5" ItemStyle-Font-Size="40px" ItemStyle-HorizontalAlign="Center" HtmlEncode="False" />
                                            <asp:BoundField DataField="xsection" HeaderText="Section" ItemStyle-Width="250px"
                                            ItemStyle-CssClass="pad5" ItemStyle-Font-Size="40px" ItemStyle-HorizontalAlign="Center" HtmlEncode="False" />

                                        <asp:TemplateField>
                                            <ItemTemplate></ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <%--<div style="font-weight: bold; width: 15%; float: left; padding: 10px; border: solid 1px #000000;
                                    margin-left: 10px; margin-top: 20px; border-radius: 10px; -moz-border-radius: 10px;
                                    -webkit-border-radius: 10px; background-color: #00ffff; color: #000000" runat="server"
                                    id="xstdcount">
                                    <table>
                                        <tr>
                                            <td>
                                                Boys
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="xboys" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Girls
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="xgirls" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Total
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="xtotal" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                OnTextChanged="fnFilterByRow"></asp:TextBox>
            <asp:HiddenField ID="ctlid_v" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
