<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="stdlistadmis.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.stdlistadmis"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function fnPrintNumCandidate() {
            // alert("Hi");
            var xclass1 = $("#<%= xclass.ClientID%>").val();
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var xgroup1 = $("#<%= xgroup.ClientID%>").val();
            var xtype1 = $("#<%= xnumexam.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/stdlistadmisrt.aspx?xsession=' + xsession1 + '&xclass=' + xclass1 + '&xgroup=' + xgroup1 + '&xtype=' + xtype1, 'numcan', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            return false;
        }

        function fnTFCAdmission(link) {
            <%-- // alert("Hi");
            var xclass1 = $("#<%= xclass.ClientID%>").val();
                 var xsession1 = $("#<%= xsession.ClientID%>").val();
                 var xgroup1 = $("#<%= xgroup.ClientID%>").val();
                 var xtype1 = $("#<%= xnumexam.ClientID%>").val();--%>
         <%--   var row = link.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            //alert(row.rowIndex);
            var grid = document.getElementById('<%=_grid_emp.ClientID %>');
            //alert(grid.rows[rowIndex].cells.length);
            //alert(grid.rows[rowIndex+1].cells[grid.rows[rowIndex+1].cells.length - 2].children[0].innerText);
            var left = Math.round((screen.width / 2) - (1000 / 2));
            var top = Math.round((screen.height / 2) - (650 / 2));
            var xrow = grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length - 2].children[0].innerText;
            var openwin = window.open("/forms/academic/collection/amtfcadmission.aspx?xrow=" + xrow , 'tfcadmission', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=1000, height=650, top=' + top + ', left=' + left + ', targets=_blank');
            openwin.focus();
                 return false;--%>
        }
    </script>
    <style>
         .pointer {
            cursor: pointer;
        }
         
    </style>
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
                            Qualified Candidates for Admission :
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
                            <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 3px;
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
                            <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 3px;
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
                            <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 3px; 
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
                             <div class="bm_ctl_container_50_50" style="float: left; width: 180px; margin-top: 3px;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             margin-right: 10px">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 55%">
                                    <asp:Label ID="Label2" runat="server" Text="No. of Exam :" AssociatedControlID="xnumexam"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 45%;">
                                    <asp:DropDownList ID="xnumexam" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                    </asp:DropDownList>
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
                                        Width="25px" Height="25px" OnClientClick="fnPrintNumCandidate();" CssClass="bm_academic_button_zoom" />
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
                                <asp:TemplateField HeaderText="Ref.">
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                            ></asp:LinkButton>
                                        <%--<asp:HyperLink ID="xrow" runat="server" CssClass="pointer" OnClientClick="fnTFCAdmission();" Text='<%#Eval("xrow") %>'></asp:HyperLink>--%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xname" HeaderText="Student's Name" ItemStyle-Width="250px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xexamroll" HeaderText="Exam Roll" ItemStyle-Width="100px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xmname" HeaderText="Mother's Name" ItemStyle-Width="250px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xfname" HeaderText="Father's Name" ItemStyle-Width="250px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xcontact" HeaderText="Contact No." ItemStyle-Width="300px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xgender" HeaderText="Gender" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-CssClass="pad5" />
                                <asp:TemplateField ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <ItemTemplate >
                                        <asp:Label ID="xrow1" runat="server" Text='<%#Eval("xrow1") %>'></asp:Label>  
                                    </ItemTemplate>
                                </asp:TemplateField>
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
    <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
        OnTextChanged="fnFilterByRow"></asp:TextBox>
    <asp:HiddenField ID="ctlid_v" runat="server" />
</asp:Content>
