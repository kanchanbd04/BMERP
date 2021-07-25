<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="numcandidates.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.numcandidates"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function fnPrintNumCandidate() {
            // alert("Hi");
            <%--  var xfrom = $("#<%= xfrom.ClientID%>").val();
            var xto = $("#<%= xto.ClientID%>").val();--%>
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/stnumcandidate.aspx?xsession=' + xsession1, 'numcan', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bm_academic_container">
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
            </div>
        </div>
        <div class="bm_academic_container_footer">
            <div class="footer_list_padding">
                <div class="bm_academic_grid_container" id="list" runat="server">
                    <div class="grid_header">
                        <div class="grid_header_label" id="_grid_header" runat="server">
                            Number of Candidates :
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

                            <%--<div class="bm_ctl_container_50_50" style="float: left; width: 200px; margin-top: 3px;margin-right: 10px">
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
                            <div class="bm_ctl_container_50_50" style="width: 180px; float: left; margin-right: 10px; margin-top: 5px;">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 75px;">
                                    <asp:Label ID="Label41" runat="server" Text="Session :" AssociatedControlID="xsession"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 103px;">
                                    <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xsession">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px">
                                <%--<div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label2" runat="server" Text="To :" AssociatedControlID="xexamdate"
                                        CssClass="label"></asp:Label>
                                </div>--%>
                                <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                    <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                    <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png" Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                </div>
                            </div>
                            <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                <%--<div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label2" runat="server" Text="To :" AssociatedControlID="xexamdate"
                                        CssClass="label"></asp:Label>
                                </div>--%>
                                <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                    <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png" Width="25px" Height="25px" OnClientClick="fnPrintNumCandidate();" CssClass="bm_academic_button_zoom" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="grid_body">
                        <asp:GridView ID="_grid_emp" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                            PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="_grid_emp_OnRowDataBound">
                            <Columns>
                                <%--<asp:BoundField DataField="xno" HeaderText="No" ItemStyle-Width="50px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />--%>

                                <asp:TemplateField HeaderText="No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="xclass" HeaderText="Classes" ItemStyle-Width="250px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Left" />
                                
                                <asp:BoundField DataField="xphysical" HeaderText="Physically" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                
                                <asp:BoundField DataField="xonline" HeaderText="Online" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                
                               <%-- <asp:BoundField DataField="xblank" HeaderText="**Blank" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />--%>
                                <asp:BoundField DataField="xtotal" HeaderText="Total Applicants" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                
                                <asp:BoundField DataField="xboy" HeaderText="Boys" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                
                                <asp:BoundField DataField="xgirl" HeaderText="Girls" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                
                                 <asp:BoundField DataField="xqualified" HeaderText="Qualified for Admission" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                
                                <asp:BoundField DataField="xnew" HeaderText="Admission Taken" ItemStyle-Width="100px"
                                    ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                
                                <%--<asp:TemplateField HeaderText="Remarks" ItemStyle-Width="350px">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>


                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow" OnTextChanged="fnFilterByRow"></asp:TextBox>
    <asp:HiddenField ID="ctlid_v" runat="server" />
</asp:Content>
