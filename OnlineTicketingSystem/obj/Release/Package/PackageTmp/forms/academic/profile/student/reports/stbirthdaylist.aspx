<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="stbirthdaylist.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.stbirthdaylist" %>

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
            // alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var xclass1 = $("#<%= xclass.ClientID%>").val();
           <%-- var xgroup1 = $("#<%= xgroup.ClientID%>").val();--%>
            var xsection1 = $("#<%= xsection.ClientID%>").val();
            <%-- var xtype1 = $("#<%= xtype.ClientID%>").val();
            var xrtype1 = $("#<%= xrtype.ClientID%>").val();--%>

            var dateParts = $("#<%= xfdate.ClientID%>").val().split("/");
            //var xfdate1 = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
            var xfdate1 = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
            //alert(xfdate1);
            var dateParts1 = $("#<%= xtdate.ClientID%>").val().split("/");
            // var xtdate1 = new Date(+dateParts1[2], dateParts1[1] - 1, +dateParts1[0]);
            var xtdate1 = dateParts1[1] + "/" + dateParts1[0] + "/" + dateParts1[2];

            //if (xclass1 == "") {
            //    xclass1 = "All";
            //}

            //if (xsection1 == "") {
            //    xsection1 = "All";
            //}

            var openwin = window.open('/forms/academic/reports/stbirthdaylistrpt.aspx?zid=' + zid + '&xsession=' + xsession1 + '&xclass=' + xclass1 + '&xsection=' + xsection1 + '&xfdate=' + xfdate1 + '&xtdate=' + xtdate1, 'rptbirthdaylist', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            //openwin.print();
            return false;
        }

        function fnShowReport1() {
            // alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var xclass1 = $("#<%= xclass.ClientID%>").val();
           <%-- var xgroup1 = $("#<%= xgroup.ClientID%>").val();--%>
            var xsection1 = $("#<%= xsection.ClientID%>").val();
            <%-- var xtype1 = $("#<%= xtype.ClientID%>").val();
            var xrtype1 = $("#<%= xrtype.ClientID%>").val();--%>

            var dateParts = $("#<%= xfdate.ClientID%>").val().split("/");
            //var xfdate1 = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
            var xfdate1 = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
            //alert(xfdate1);
            var dateParts1 = $("#<%= xtdate.ClientID%>").val().split("/");
            // var xtdate1 = new Date(+dateParts1[2], dateParts1[1] - 1, +dateParts1[0]);
            var xtdate1 = dateParts1[1] + "/" + dateParts1[0] + "/" + dateParts1[2];

            //if (xclass1 == "") {
            //    xclass1 = "All";
            //}

            //if (xsection1 == "") {
            //    xsection1 = "All";
            //}

            var openwin = window.open('/forms/academic/reports/stbirthdaylistrpt.aspx?zid=' + zid + '&xsession=' + xsession1 + '&xclass=' + xclass1 + '&xsection=' + xsection1 + '&xfdate=' + xfdate1 + '&xtdate=' + xtdate1, 'rptbirthdaylist', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
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

              <%--  $("body").on("click", ".bm_student", function () {
                    //alert("Hi");
                   
                    fnOpenStudentList3(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    $("#<%=xstdid.ClientID%>").focus();

                    return false;
                });--%>


            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Birthday List</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                        <%-----THIS IS MESSAGE SECTION-----%>
                    </div>
                </div>
                <div class="bm_academic_container_body1">
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding" style="border-bottom: 0px; padding-bottom: 0px">
                            <div class="button_section_style1" style="text-align: left; margin-bottom: 5px;">
                                <asp:Button ID="btnShow" runat="server" Text="Show Report" CssClass="bm_academic_button3 bm_am_btn_show"
                                    OnClientClick="javascript:fnShowReport(); " Width="100px" />

                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100" style="width: 500px;display: inline-block">

                                <div class="bm_layout_box_padding" style="padding-top: 10px; min-height: 300px;">

                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both;">
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px; display: none;">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label4" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" Text="From Date :" AssociatedControlID="xfdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:TextBox ID="xfdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="To Date :" AssociatedControlID="xtdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:TextBox ID="xtdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>

                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px; display: none;">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="Type :" AssociatedControlID="xtype"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:DropDownList ID="xtype" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                     <%--   <div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 290px; display: none;">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label6" runat="server" Text="Report Type :" AssociatedControlID="xrtype"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 168px">
                                                <asp:DropDownList ID="xrtype" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                    <%-- <div style="width: 100%; clear: both; padding-top: 5px">
                                    </div>--%>
                                </div>
                            </div>
                            <div style="display: none; vertical-align: top; ">
                                <fieldset>
                                    <legend>Download Parents' Mobile Number for Sending SMS</legend>
                                    <%--<div class="bm_ctl_container_50_50" style="width: 270px;margin-bottom: 10px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="Download? :" AssociatedControlID="xdownload"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xdownload" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>--%>
                                    <div style="horiz-align: right">
                                        <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="bm_academic_button3 bm_am_btn_download"
                                            OnClientClick="javascript:fnShowReport1();" Width="100px" />
                                    </div>
                                    </fieldset>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px; min-height: 0px; padding-bottom: 0px;">
                                <div class="bm_academic_grid_container2" style="width: 100%" id="divliststd" runat="server">
                                    <div style="width: 98%; margin-bottom: 10px; margin-left: 10px;">
                                    </div>
                                </div>
                            </div>
                            <div class="bm_academic_container_body_button_section">
                                <div class="button_section_padding">
                                    <div class="button_section_style1" style="text-align: left; margin-top: 10px;">
                                        <asp:Button ID="btnShow1" runat="server" Text="Show Report" CssClass="bm_academic_button3 bm_am_btn_show"
                                            OnClientClick="javascript:fnShowReport();" Width="100px" />

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
