<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="mstranp.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.mstranp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //alert("Hi!");
            //            $('.bm_academic_datepicker').attr('placeholder', 'DD/MM/YYYY');
            //ns.dp_placeholder();
            $('.bm_am_btn_save').click(function () {
                var mendatoryFields = [
                   <%-- { "id": "<%= xcode.ClientID%>", "prop": "text" }--%>
                ];
                var mendatoryString = JSON.stringify(mendatoryFields);
                if (!fnMendatoryFields(mendatoryString)) {
                    return false;
                }


                return true;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label" id="header_label" runat="server">
                Related Transactions Parameters : 
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
            </div>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <div class="bm_layout_container">
                    <div class="bm_layout_box_100">
                        <div class="bm_layout_box_padding">
                            <div class="bm_ctl_container_dynamic_100_80">
                                <div class="bm_ctl_container_dynamic_100_80_l">
                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                        <asp:Label ID="Label8" runat="server" Text="Transaction Type :" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                                <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                    <div id="xtypetrn" runat="server">
                                        xtypetrn</div>
                                </div>
                            </div>
                            <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_100_45 required" style="width: 300px">
                                <div class="bm_ctl_label_align_right_100_45 label_bg" style="width: 172px">
                                    <asp:Label ID="Label26" runat="server" Text="Transaction Code :" AssociatedControlID="xtrn"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_45" style="width:126px">
                                    <%--<asp:TextBox ID="xtrn" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                <asp:DropDownList ID="xtrn" runat="server" CssClass="bm_academic_dropdown_100_35 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                </div>
                            </div>
                              <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_100_35" style="display: inline-block; ">
                                            <div class="bm_ctl_label_align_right_100_35" >
                                                <asp:Label ID="Label9" runat="server" Text="Related Transection Type :" AssociatedControlID="xtyperel"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_35" >
                                                <asp:DropDownList ID="xtyperel" runat="server" CssClass="bm_academic_dropdown_100_35 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                           <%-- <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_dynamic_100_80" display>
                                <div class="bm_ctl_container_dynamic_100_80_l">
                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                        <asp:Label ID="Label1" runat="server" Text="Long Description :" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                                <div class="bm_clt_ctl_dynamic_100_80">
                                    <div class="_ctl_padding">
                                        <textarea id="xdescdet" class="bm_academic_textarea_100_80  bm_academic_textarea"
                                            style="width: 342px; height: 100px;" runat="server"></textarea>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_100_45" style="width: 300px">
                                <div class="bm_ctl_label_align_right_100_45" style="width: 172px">
                                    <asp:Label ID="Label7" runat="server" Text="Related Code :" AssociatedControlID="xrel"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_45" style="width: 126px">
                                    <%--<asp:TextBox ID="xrel" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                <asp:DropDownList ID="xrel" runat="server" CssClass="bm_academic_dropdown_100_35 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                </div>
                            </div>
                            <%--<div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_100_45">
                                <div class="bm_ctl_label_align_right_100_45">
                                    <asp:Label ID="Label2" runat="server" Text="Sequence :" AssociatedControlID="xcodealt"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_45">
                                    <asp:TextBox ID="xcodealt" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                </div>
                            </div>
                            <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_dynamic_100_80">
                                <div class="bm_ctl_container_dynamic_100_80_l">
                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                        <asp:Label ID="Label3" runat="server" Text="Property List :" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                                <div class="bm_clt_ctl_dynamic_100_80">
                                    <div class="_ctl_padding">
                                        <textarea id="xprops" class="bm_academic_textarea_100_80  bm_academic_textarea"
                                            style="width: 342px; height: 100px;" runat="server"></textarea>
                                    </div>
                                </div>
                            </div>--%>
                            <%--<div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_100_45 required" style="width: 300px">
                                <div class="bm_ctl_label_align_right_100_45 label_bg" style="width: 172px">
                                    <asp:Label ID="Label1" runat="server" Text="Starting Number :" AssociatedControlID="xnum"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_45" style="width:126px">
                                    <asp:TextBox ID="xnum" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                </div>
                            </div>
                            <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_100_45 required" style="width: 300px">
                                <div class="bm_ctl_label_align_right_100_45 label_bg" style="width: 172px">
                                    <asp:Label ID="Label2" runat="server" Text="Increment :" AssociatedControlID="xinc"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_45" style="width:126px">
                                    <asp:TextBox ID="xinc" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                </div>
                            </div>--%>
                            <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_dynamic_100_80">
                                <div class="bm_ctl_container_dynamic_100_80_l">
                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                        <asp:Label ID="Label4" runat="server" Text="Active? :" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                                <div class="bm_clt_ctl_dynamic_100_80">
                                    <div class="_ctl_padding bm_academic_chackbox">
                                        <asp:CheckBox ID="zactive" Text="Active" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_dynamic_100_80">
                                <div class="bm_ctl_container_dynamic_100_80_l">
                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                        <asp:Label ID="Label5" runat="server" Text="Entered By :" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                                <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                    <div id="zemail" runat="server">
                                        zemail@bm.com</div>
                                </div>
                            </div>
                            <div class="bm_clt_padding">
                            </div>
                            <div class="bm_ctl_container_dynamic_100_80">
                                <div class="bm_ctl_container_dynamic_100_80_l">
                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                        <asp:Label ID="Label6" runat="server" Text="Updated By :" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                                <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                    <div id="xemail" runat="server">
                                        xemail@bm.com</div>
                                </div>
                            </div>
                            <div class="bm_clt_padding">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="bm_academic_container_body_button_section">
                <div class="button_section_padding">
                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                    <div class="button_section_style">
                        <asp:Button ID="btnSave" runat="server" Text="Save" 
                            CssClass="bm_academic_button bm_am_btn_save" onclick="btnSave_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                            CssClass="bm_academic_button bm_am_btn_edit" onclick="btnEdit_Click" />
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                            CssClass="bm_academic_button bm_am_btn_refresh" onclick="btnRefresh_Click" />
                        <%-- <input id="btnSave" type="button" value="Save" class="bm_academic_button bm_am_btn_save" />
                        <input id="btnEdit" type="button" value="Edit" class="bm_academic_button bm_am_btn_edit" />
                        <input id="btnRefresh" type="button" value="Refresh" class="bm_academic_button bm_am_btn_refresh" />--%>
                    </div>
                    <%--</ContentTemplate>
                     </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
        <div class="bm_academic_container_footer">
            <div class="footer_list_padding">
                <div class="bm_academic_grid_container" id="list" runat="server">
                    <div class="grid_header">
                        <div class="grid_header_label" id="_grid_header" runat="server">
                            Related Transaction Code List(s) :
                        </div>
                        <div class="grid_header_control">
                        </div>
                        <div class="flot_right">
                            <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>
                            <div class="grid_header_row">
                                <asp:TextBox ID="_gridrow" runat="server" AutoPostBack="True" CssClass="_gridrow" OnTextChanged="fnFilterByRow"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="grid_body">
                        <asp:GridView ID="_grid_codes" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="xtypetrn" HeaderText="Transaction Type" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"/>
                                <asp:TemplateField HeaderText="Transaction Code">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xcode" runat="server" Text='<%#Eval("xtrn") %>' CssClass="_gridrow_link" OnClick="FillControls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xtyperel" HeaderText="Related Transaction Type" />
                                <asp:BoundField DataField="xrel" HeaderText="Related Code" />
                                <asp:TemplateField HeaderText="Active?">
                                    <ItemStyle HorizontalAlign="Center"/>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' /></ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="">
            <ItemTemplate></ItemTemplate>
            
                            </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="txtconformmessageValue" runat="server" />
    <asp:HiddenField ID="key" runat="server" />
    <asp:HiddenField ID="zid" runat="server" />
    <asp:HiddenField ID="confmsg" runat="server" />
    <asp:HiddenField ID="xtype2" runat="server" />
</asp:Content>
