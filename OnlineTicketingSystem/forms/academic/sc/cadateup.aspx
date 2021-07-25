<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="cadateup.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.cadateup" %>


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
                Transaction Code : 
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
            </div>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <div class="bm_layout_container">
                    <div class="bm_layout_box_100" style="min-height: 250px;">
                        <div class="bm_layout_box_padding">

                            
                                       <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" Text="From Date :" AssociatedControlID="xdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="bm_clt_padding">
                                        </div>

                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="To Date :" AssociatedControlID="xdatedue"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xdatedue" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                            <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Default Holiday :" AssociatedControlID="xremark"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xremark" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
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
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                            CssClass="bm_academic_button bm_am_btn_refresh" onclick="btnRefresh_Click" Visible="False"/>

                        <asp:Button ID="btnSave" runat="server" Text="Process" 
                            CssClass="bm_academic_button bm_am_btn_save" onclick="btnSave_Click" />
                        <%--<asp:Button ID="btnEdit" runat="server" Text="Update" 
                            CssClass="bm_academic_button bm_am_btn_edit" onclick="btnEdit_Click" />--%>
                        
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
                <div class="bm_academic_grid_container" id="list" runat="server" style="display: none;">
                    <div class="grid_header">
                        <div class="grid_header_label" id="_grid_header" runat="server">
                            Code List(s) :
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
                                <asp:TemplateField HeaderText="Code">
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xcode" runat="server" Text='<%#Eval("xtrn") %>' CssClass="_gridrow_link" OnClick="FillControls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xaction" HeaderText="Action" />
                                <asp:BoundField DataField="xdesc" HeaderText="Description" />
                                <asp:BoundField DataField="xnum" HeaderText="Starting Number" ItemStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="xinc" HeaderText="Increment" ItemStyle-HorizontalAlign="Center"/>
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
