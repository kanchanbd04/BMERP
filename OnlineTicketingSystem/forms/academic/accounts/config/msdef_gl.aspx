<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="msdef_gl.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.msdef_gl" %>


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


            $('.bm_xsubcpv').click(function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                fnOpenChartofAccounts2(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"),$("#<%=hxacccpv.ClientID%>").attr("ID"),$("#<%=hxsubcpv.ClientID%>").attr("ID"),"Cash");
              });

            $('.bm_xsubbpv').click(function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                fnOpenChartofAccounts2(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"),$("#<%=hxaccbpv.ClientID%>").attr("ID"),$("#<%=hxsubbpv.ClientID%>").attr("ID"),"Bank");
             });

            $('.bm_xsubcrv').click(function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                fnOpenChartofAccounts2(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"),$("#<%=hxacccrv.ClientID%>").attr("ID"),$("#<%=hxsubcrv.ClientID%>").attr("ID"),"Cash");
            });

            $('.bm_xsubbrv').click(function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                fnOpenChartofAccounts2(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"),$("#<%=hxaccbrv.ClientID%>").attr("ID"),$("#<%=hxsubbrv.ClientID%>").attr("ID"),"Bank");
            });

            $('.bm_xsubbb').click(function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                //fnOpenChartofAccounts2(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"),$("#<%=hxaccbb.ClientID%>").attr("ID"),$("#<%=hxsubbb.ClientID%>").attr("ID"),"Bank");
                fnOpenChartofAccounts(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID")); 
            });

            $('.bm_xsubcb').click(function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                //fnOpenChartofAccounts2(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"),$("#<%=hxacccb.ClientID%>").attr("ID"),$("#<%=hxsubcb.ClientID%>").attr("ID"),"Cash");
                fnOpenChartofAccounts(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID")); 
            });

            
            $('.bm_xaccyearend').click(function () {
                fnOpenChartofAccounts(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID")); 
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
                            <div class="bm_ctl_container_dynamic_100_80" style="display: none;">
                                <div class="bm_ctl_container_dynamic_100_80_l">
                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                        <asp:Label ID="Label8" runat="server" Text="Status Type :" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                                <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                    <div id="xtypestatus" runat="server">
                                        xtypetrn</div>
                                </div>
                            </div>
                            <%--<div class="bm_clt_padding">
                            </div>--%>
                            <div class="bm_ctl_container_100_45 required" style="width: 300px; display: none;">
                                <div class="bm_ctl_label_align_right_100_45 label_bg" style="width: 172px">
                                    <asp:Label ID="Label26" runat="server" Text="Period Offset :" AssociatedControlID="xinteger"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_45" style="width:126px">
                                    <asp:TextBox ID="xinteger" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                </div>
                            </div>
                              
                            <table style="text-align: right; color: black;">
                                 <tr>
                                            <td>CPV Default Cash A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xsubcpv" runat="server" Height="20px" Width="150px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_xsubcpv" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xsubcpvtitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                
                                <tr>
                                            <td>BPV Default Bank A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xsubbpv" runat="server" Height="20px" Width="150px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_xsubbpv" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xsubbpvtitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                
                                <tr>
                                            <td>CRV Default Cash A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xsubcrv" runat="server" Height="20px" Width="150px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_xsubcrv" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xsubcrvtitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                
                                 <tr>
                                            <td>BRV Default Bank A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xsubbrv" runat="server" Height="20px" Width="150px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_xsubbrv" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xsubbrvtitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                
                                 <tr>
                                            <td>Bank Book Default A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xsubbb" runat="server" Height="20px" Width="150px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_xsubbb" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xsubbbtitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                
                                <tr>
                                            <td>Cash Book Default A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xsubcb" runat="server" Height="20px" Width="150px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_xsubcb" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xsubcbtitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                
                                <tr>
                                            <td>Year End Default A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xaccyearend" runat="server" Height="20px" Width="150px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_xaccyearend" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xaccyearendtitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                

                                </table>
                           
                            
                            
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
                            CssClass="bm_academic_button bm_am_btn_refresh" onclick="btnRefresh_Click" />

                        <asp:Button ID="btnSave" runat="server" Text="Save" 
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
    <asp:HiddenField ID="hxacccpv" runat="server" />
    <asp:HiddenField ID="hxacccrv" runat="server" />
    <asp:HiddenField ID="hxaccbpv" runat="server" />
    <asp:HiddenField ID="hxaccbrv" runat="server" />
     <asp:HiddenField ID="hxsubcpv" runat="server" />
    <asp:HiddenField ID="hxsubcrv" runat="server" />
    <asp:HiddenField ID="hxsubbpv" runat="server" />
    <asp:HiddenField ID="hxsubbrv" runat="server" />
    <asp:HiddenField ID="hxaccbb" runat="server" />
    <asp:HiddenField ID="hxsubbb" runat="server" />
    <asp:HiddenField ID="hxacccb" runat="server" />
    <asp:HiddenField ID="hxsubcb" runat="server" />
    <asp:HiddenField ID="hxaccyearend" runat="server" />
</asp:Content>
