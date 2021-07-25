<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="hrcoach.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.hrcoach" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .modalBackground {
            /*background-color: Gray;
            z-index: 10000;*/
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            left: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .modal {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            left: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 110px;
            }

        .right {
            text-align: right;
        }
        /*.bm_academic_grid1 tr:nth-child(6) td{
    padding: 2px; 
    border-bottom: solid 2px #000000; 
    color: #000000;
    padding-left: 3px;
    font-weight: normal;
     font-size: 14px;
     font-family: Myriad Pro,tahoma; 
}*/
    </style>
    <%-- <style type="text/css">
 
 .GridViewScrollHeader TH, .GridViewScrollHeader TD {
    padding: 10px;
    font-weight: normal;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #F4F4F4;
    color: #999999;
    text-align: left;
    vertical-align: bottom;
}

.GridViewScrollItem TD {
    padding: 10px;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #FFFFFF;
    color: #444444;
}

.GridViewScrollItemFreeze TD {
    padding: 10px;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #FAFAFA;
    color: #444444;
}

.GridViewScrollFooterFreeze TD {
    padding: 10px;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-top: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #F4F4F4;
    color: #444444;
}
    </style>--%>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
                            '<img src="/images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();

            });
        }
        $(document).ready(function () {

            BlockUI("<%=pnlpopup.ClientID %>");
            $.blockUI.defaults.css = {};

            //             $('.bm_subject_teacher').click(function () {
            //            //alert("Hi");
            //            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _subteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            //            });



        });




        function fnShowReport() {
           

            var openwin = window.open('/forms/academic/reports/hrcoachrpt.aspx', 'hrcoach', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            //openwin.print();
            return false;
        }




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:LinkButton ID="LinkButton1" runat="server">Reveal Modal...</asp:LinkButton> 

 <asp:Panel ID="Panel1" runat="server"  CssClass="modalPopup" Style="display: none">
                this is the modal<br /><br />
                <asp:Button ID="Button5" runat="server" Text="OK" />
                <asp:Button ID="Button6" runat="server" Text="Cancel" />
</asp:Panel>

<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1" CancelControlID="Button1" DropShadow="true" OkControlID="Button2" PopupControlID="Panel1" BackgroundCssClass="modalBackground">
 </cc1:ModalPopupExtender>--%>
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
            <script type="text/javascript">



            



            

                $("body").on("click", ".bm_tfccode", function () {
                    fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").focus();


                    return false;
                });

                $("body").on("click", ".bm_student", function () {
                    //alert("Hi");
                   
                    fnOpenStudentList3(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                   <%-- $("#<%=xstdid.ClientID%>").focus();--%>

                    return false;
                });


            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Coach List</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                        <%-----THIS IS MESSAGE SECTION-----%>
                    </div>
                </div>
                <div class="bm_academic_container_body1">
                    <%-- <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding" style="border-bottom: 0px; padding-bottom: 0px">
                            <div class="button_section_style1" style="text-align: left; margin-bottom: 5px;">
                               <asp:Button ID="btnShow" runat="server" Text="Show Report" CssClass="bm_academic_button3 bm_am_btn_show"
                                    OnClientClick="javascript:fnShowReport(); " Width="100px" />

                            </div>
                        </div>
                    </div>--%>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container" style="padding-top: 0px">
                            <div class="bm_layout_box_100" style="padding-top: 0px">

                                <div class="bm_layout_box_padding" style="padding-top: 0px;">

                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both;">
                                    </div>
                                    <%-- <div style="width: 100%; clear: both; padding-top: 5px">
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer" style="padding-top: 0px; min-height: 500px;">
                            <div class="bm_academic_container_footer">
                                <div class="footer_list_padding2">
                                    <div class="bm_academic_grid_container" id="list" runat="server">
                                        <div class="grid_header">
                                            <div class="grid_header_control">
                                            </div>
                                            <div class="flot_right">
                                                <%--<div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px">
                                                    <div class="bm_ctl_label_align_right_100_special">
                                                        <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special">
                                                        <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px; width: 122px">
                                                    <div class="bm_ctl_label_align_right_100_special">
                                                        <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special">
                                                        <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                                    <div class="bm_ctl_label_align_right_100_special">
                                                        <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special">
                                                        <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                                    <div class="bm_ctl_label_align_right_100_special">
                                                        <asp:Label ID="Label4" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special">
                                                        <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                                    <div class="bm_ctl_label_align_right_100_special">
                                                        <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special">
                                                        <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>--%>
                                                <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px">
                                                    <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                                        <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                            Width="25px" Height="25px" CssClass="bm_academic_button_zoom" OnClick="btnRefresh_OnClick" />
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                                    <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                            Width="25px" Height="25px" OnClientClick="javascript:fnShowReport();"
                                                            CssClass="bm_academic_button_zoom" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="grid" align="left" style="width: 100%">
                                            <div style="display: inline-block; width: 500px; vertical-align: top;">
                                                <div style="width: 100%; height: 25px; background-color: #a9a9a9; padding-top: 3px; padding-left: 5px; color: white; font-size: 16px;margin-top: 10px" id="Div1" runat="server">
                                                    List(s) of Coach
                                                    
                                                </div>
                                               <%-- <div class="bm_clt_padding">
                                                </div>--%>
                                                <div style="width: 100%; clear: both; padding-top: 5px">
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                        CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                                        RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                        PagerStyle-CssClass="PagerStyle" GridLines="None" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="xsl" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                   <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xcoach") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                              <asp:BoundField DataField="xname" HeaderText="Coach Name" ItemStyle-Width="250px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                            
                                                            
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="xrow" HeaderText="" ItemStyle-Width=""
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5 hiddencol" HeaderStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol"/>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                            </div>
                                            <div style="display: inline-block; width: 600px; vertical-align: top; padding-left: 40px;padding-top: 10px" id="teacher" runat="server">
                                                
                                                
                                                
                                                 <div style="width: 100%; height: 25px; background-color: #a9a9a9; padding-top: 3px; padding-left: 5px; color: white;font-size:16px" id="teacherheader" runat="server">
                                                    List(s) of Teacher's
                                                    
                                                </div>
                                               <%-- <div class="bm_clt_padding">
                                                </div>--%>

                                                <div style="width: 100%; clear: both; padding-top: 5px">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                        CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                                        RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                        PagerStyle-CssClass="PagerStyle" GridLines="None" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="xsl" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <asp:BoundField DataField="xteacher" HeaderText="ID" ItemStyle-Width="100px"
                                                                ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                              <asp:BoundField DataField="xname" HeaderText="Teacher Name" ItemStyle-Width="250px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                            
                                                            
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="xline" HeaderText="" ItemStyle-Width=""
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5 hiddencol" HeaderStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol"/>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>
                            <div class="bm_academic_container_body_button_section">
                                <div class="button_section_padding">
                                    <div class="button_section_style1" style="text-align: left; margin-top: 10px;">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>

                <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="530px" Width="800px"
                    Style="display: none" ScrollBars="Auto">
                    <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
                        cellpadding="0" cellspacing="0">
                        <tr style="background-color: #619CFD; height: 30px; text-align: right;">
                            <td></td>
                        </tr>
                        <tr>
                            <td>kjslfjklfjksl
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                 <asp:HiddenField ID="_coach" runat="server" />
                <asp:HiddenField ID="_teacher" runat="server" />
                <asp:HiddenField ID="_subject" runat="server" />
                <asp:HiddenField ID="_classteacher" runat="server" />
                <asp:HiddenField ID="_subteacher" runat="server" />
                <asp:HiddenField ID="_xperiod" runat="server" />
                <asp:HiddenField ID="_xsection" runat="server" />
                <asp:HiddenField ID="_xdate" runat="server" />
                <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                <asp:HiddenField ID="txtconformmessageValue1" runat="server" />
                <asp:HiddenField ID="hiddenxdate" runat="server" />
                <asp:HiddenField ID="hiddenxrow" runat="server" />
                <asp:HiddenField ID="hiddenxstatus" runat="server" />
                <asp:HiddenField ID="hxstatus" runat="server" />
                <asp:HiddenField ID="xnsdate" runat="server" />
                <asp:HiddenField ID="hxeffdate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
