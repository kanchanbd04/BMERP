<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="imstkg2_cb10_up.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.imstkg2_cb10_up" %>

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
          <%--  var fware1 = $("#<%= fware.ClientID%>").val();
            var tware1 = $("#<%= tware.ClientID%>").val();--%>
            var fgitem1 = $("#<%= fgitem.ClientID%>").val();
            var tgitem1 = $("#<%= tgitem.ClientID%>").val();
            var dateParts = $("#<%= fdate.ClientID%>").val().split("/");
            //var xfdate1 = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
            var fdate1 = dateParts[1] + "/" + dateParts[0] + "/" + dateParts[2];
           //alert(xfdate1);

            var dateParts1 = $("#<%= tdate.ClientID%>").val().split("/");
           //var xfdate1 = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
           var tdate1 = dateParts1[1] + "/" + dateParts1[0] + "/" + dateParts1[2];

         <%--  var fstd1 = $("#<%= xfstd.ClientID%>").val();
           var tstd1 = $("#<%= xtstd.ClientID%>").val();--%>
            

           var openwin = window.open('/forms/academic/reports/inventory/imstkg2_cb10_uprpt.aspx?zid=' + zid + '&fdate=' + fdate1 + '&tdate=' + tdate1 + '&fgitem=' + fgitem1 + '&tgitem=' + tgitem1, 'valuerpt', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
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


                
         <%--   
                $("body").on("click", ".bm_xstdid", function () {
            
                    fnOpenEMPList1(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xnamestd").attr("ID"));
                      $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").focus();
  
                });

                $("body").on("click", ".bm_xstdid1", function () {
            
                    fnOpenEMPList1(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xnamestd1").attr("ID"));
                      $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").focus();
  
                  });--%>


            

              <%--  $("body").on("click", ".bm_tfccode", function () {
                    fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").focus();


                    return false;
                });--%>

            <%--    $("body").on("click", ".bm_student", function () {
                    //alert("Hi");
                   
                    fnOpenStudentList3(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    $("#<%=xstdid.ClientID%>").focus();

                    return false;
                });--%>


            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Valuation Statement </span>
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
                            <div class="bm_layout_box_100">

                                <div class="bm_layout_box_padding" style="padding-top: 10px; min-height: 300px;">

                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both;">
                                        <%--<div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                     <%--   <div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label4" runat="server" Text=" Student ID :" AssociatedControlID="xstdid"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xstdid" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_student" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xstdname" runat="server" Text="" CssClass="xstdname"></asp:Label>
                                            </div>

                                        </div>--%>
                                        
                                       <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" Text="From Date :" AssociatedControlID="fdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="fdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                         <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" Text="To Date :" AssociatedControlID="tdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="tdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="To Date :" AssociatedControlID="xtdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xtdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="From Warehouse :" AssociatedControlID="fware"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="fware" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="To Warehouse :" AssociatedControlID="tware"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="tware" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>--%>
                                        
                                         <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="From Item Group :" AssociatedControlID="fgitem"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="fgitem" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        
                                         <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label4" runat="server" Text="To Item Group :" AssociatedControlID="tgitem"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="tgitem" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label4" runat="server" Text="From Teacher/Emp. :" AssociatedControlID="xfstd"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xfstd" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                            ></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_xstdid" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xnamestd" runat="server" Text="" CssClass="xnamestd"></asp:Label>
                                            </div>

                                        </div>--%>
                                        
                                         <%--<div class="bm_clt_padding">
                                        </div>
                                        <div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label6" runat="server" Text="To Teacher/Emp. :" AssociatedControlID="xtstd"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xtstd" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                            ></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_xstdid1" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xnamestd1" runat="server" Text="" CssClass="xnamestd1"></asp:Label>
                                            </div>

                                        </div>--%>

                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_100_special" style="width: 120px; float: left;">
                                                <div class="bm_ctl_label_align_right_100_special" style="width: 100%">
                                                    <asp:Label ID="Label31" runat="server" Text="Activity Type :"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px">
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="All Collection" Value="All Collection" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="My Collection" Value="My Collection"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>--%>

                                       <%-- <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" Text="Paper Size :" AssociatedControlID="xsize"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xsize" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="Paper Orientation :" AssociatedControlID="xorientation"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xorientation" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>

                                            </div>
                                        </div>--%>
                                    </div>
                                    <%-- <div style="width: 100%; clear: both; padding-top: 5px">
                                    </div>--%>
                                </div>
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
