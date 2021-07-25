<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="stdbirthday.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.stdbirthday"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        <%-- function fnPrintNumCandidate() {
            // alert("Hi");
            var xclass1 = $("#<%= xclass.ClientID%>").val();
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var xgroup1 = $("#<%= xgroup.ClientID%>").val();
            var xtype1 = $("#<%= xsection.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/stdlistrt.aspx?xsession=' + xsession1 + '&xclass=' + xclass1 + '&xgroup=' + xgroup1 + '&xtype=' + xtype1, 'numcan', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            return false;
        }--%>
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
                                    Birthday:
                                </div>
                                <div class="grid_header_control">
                                </div>
                                <div class="flot_right">
                                     <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px; margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 35%">
                                            <asp:Label ID="Label2" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 65%;">
                                            <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 255px; margin-top: 5px; margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                            <asp:Label ID="Label52" runat="server" Text="Options :" AssociatedControlID="xoption"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 75%;">
                                            <asp:DropDownList ID="xoption" runat="server" CssClass="bm_academic_dropdown_100_s_grid bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="xoption_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px; margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 30%">
                                            <asp:Label ID="Label540" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 70%;">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px; margin-right: 10px"
                                        id="month" runat="server">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 30%">
                                            <asp:Label ID="Label1" runat="server" Text="Month :" AssociatedControlID="xmonth"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 70%;">
                                            <asp:DropDownList ID="xmonth" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 5px;
                                        margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_50_50" style="width: 35%">
                                            <asp:Label ID="Label2" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_50" style="width: 65%;">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>

                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; margin-right: 20px; border: none; height: 32px">

                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                            <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                    <%--<div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                       
                                       <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                Width="25px" Height="25px" OnClientClick="fnPrintNumCandidate();" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="grid_body">
                                <div style="width: 48%; display: inline-block; vertical-align: top;" id="today" runat="server">
                                    <div style="width: 100%; text-align: center; padding: 10px; font-size: large; font-weight: bold;" id="todathead" runat="server">
                                        
                                    </div>
                                    <div>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                                            <Columns>
                                               
                                            <asp:TemplateField HeaderText="No" HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>

                                                <asp:BoundField DataField="xstdid" HeaderText="ID" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="200px"
                                                    ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="150px"
                                                    ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xdob" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}"
                                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div style="width: 48%; display: inline-block; vertical-align: top;" runat="server"
                                    id="tomorrow">
                                    <div style="width: 100%; text-align: center; padding: 10px;font-size: large; font-weight: bold;" id="tomorrowhead" runat="server">
                                        
                                    </div>
                                    <div>
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                                            <Columns>
                                             
                                            <asp:TemplateField HeaderText="No" HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>

                                                <asp:BoundField DataField="xstdid" HeaderText="ID" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="200px"
                                                    ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="150px"
                                                    ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xdob" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}"
                                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
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
