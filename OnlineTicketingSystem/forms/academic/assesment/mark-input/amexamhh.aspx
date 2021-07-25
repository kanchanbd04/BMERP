<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="amexamhh.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.amexamhh" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .btncolor
        {
            width: 20px;
            height: 20px;
            border: 1px solid #808080;
        }
        .modalBackground
        {
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
        
        .modal
        {
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
        .center
        {
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
        .center img
        {
            height: 128px;
            width: 110px;
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
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({ message: '<table align = "center"><tr><td>' +
                        '<img src="/images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: { backgroundColor: '#000000', opacity: 0.6
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
        $("body").on("click", ".bm_subject_teacher", function () {
            //alert("Button was clicked.");
            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _subteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
        });

          $("body").on("click", ".bm_class_teacher", function () {
            //alert("Button was clicked.");
            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _classteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
        });

<%--        // $("body").on("click", ".bm_subject", function () {
                //alert("Button was clicked.");
                //fnOpenSubjectList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
           // });--%>



<%--//                         $("body").on("click", ".bm_list", function () {
//            //alert("Button was clicked.");
//                // alert(this.getAttribute("rowno"));
////                 alert(document.getElementById('<%=hxstatus.ClientID %>').value);
////                 return;
//                 //var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
//                 //if (xst != 'Approved3') {
//                     var row = this.parentNode.parentNode;
//                     var rowIndex = row.rowIndex - 1;
//                     var gcol = document.getElementById('<%=xgcol.ClientID %>').value + 4;
//                             //alert(rowIndex);
//                              fnOpenCommentsList(<%= HttpContext.Current.Session["business"] %>, row.cells[4].getElementsByTagName("textarea")[0].id, row.cells[4].getElementsByTagName("textarea")[0].value);
//                             //}
//                         });--%>

   $("body").on("click", ".bm_list", function () {
   
    var row = this.parentNode.parentNode;
    var rowIndex = row.rowIndex - 1;
       <%-- var gcol = parseInt(document.getElementById('<%=xgcol.ClientID %>').value) + 4;--%>
       var gcol = parseInt(document.getElementById('<%=xgcol.ClientID %>').value) + 3;
      <%-- var zid_ = '<%= HttpContext.Current.Session["business"] %>';--%>
       //alert(zid_);
       //return;
      <%-- //alert(parseInt(document.getElementById('<%=xgcol.ClientID %>').value) +3);--%>
       <%--if (document.getElementById('<%=hiscom.ClientID %>').value == "0") {--%>
       fnOpenCommentsList( '<%= HttpContext.Current.Session["business"] %>' , row.cells[gcol].getElementsByTagName("textarea")[0].id, row.cells[gcol].getElementsByTagName("textarea")[0].value);
       //}
   });


   

    $("body").on("click", ".bm_am_btn_refresh", function () {

            //                alert("Hi");
            //                return false;

            var mendatoryFields = [
                                 { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xterm.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsubject.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xtbest.ClientID%>", "prop": "combo", "tab": "0" }
                                    <%--{ "id": "<%= xperc.ClientID%>", "prop": "combo", "tab": "0" }--%>
                                    
                                ];
            var mendatoryString = JSON.stringify(mendatoryFields);
            if (!fnMendatoryFields1(mendatoryString)) {
                return false;
            }


            return true;
        });

<%--//        $("body").on("click", ".bm_am_btn_save", function () {

//            //                alert("Hi");
//            //                return false;

//            var mendatoryFields = [
//                                 { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
//                                    { "id": "<%= xterm.ClientID%>", "prop": "combo", "tab": "0" },
//                                    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
//                                    { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" },
//                                    { "id": "<%= xsubject.ClientID%>", "prop": "combo", "tab": "0" },
//                                    { "id": "<%= xtbest.ClientID%>", "prop": "combo", "tab": "0" },
//                                    { "id": "<%= xperc.ClientID%>", "prop": "combo", "tab": "0" }
//                                    
//                                ];
//            var mendatoryString = JSON.stringify(mendatoryFields);
//            if (!fnMendatoryFields1(mendatoryString)) {
//                return false;
//            }--%>


//            return true;
//        });

        function ConfirmMessage() {
               var selectedvalue = confirm("Do you want to submit record? After submit cann't change record.");
               if (selectedvalue) {
                   document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
               } else {
                   document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
               }
           }

            function ConfirmMessage1() {
               var selectedvalue = confirm("Do you want to parmanently delete this record?");
               if (selectedvalue) {
                   document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "Yes";
               } else {
                   document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "No";
               }
           }

           function ConfirmMessage2() {
               var selectedvalue = confirm("Do you want to undo this record?");
               if (selectedvalue) {
                   document.getElementById('<%=txtconformmessageValue2.ClientID %>').value = "Yes";
               } else {
                   document.getElementById('<%=txtconformmessageValue2.ClientID %>').value = "No";
               }
           }

            function ConfirmMessage3() {
               var selectedvalue = confirm("Do you want to approved this record?");
               if (selectedvalue) {
                   document.getElementById('<%=txtconformmessageValue3.ClientID %>').value = "Yes";
               } else {
                   document.getElementById('<%=txtconformmessageValue3.ClientID %>').value = "No";
               }
           }


            function fnPrintSchedule() {
            // alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession = $("#<%= xsession.ClientID%>").val();
            var xterm = $("#<%= xterm.ClientID%>").val();
            var xclass = $("#<%= xclass.ClientID%>").val();
            var xgroup = $("#<%= xgroup.ClientID%>").val();
            var xdate = $("#<%= hiddenxdate.ClientID%>").val();
           var xrow = $("#<%= hiddenxrow.ClientID%>").val();
           var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
              var openwin = window.open('/forms/academic/reports/rptasctschvwsw.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup  + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
              openwin.focus();
                openwin.print();
                //return false;
            }




            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">CT Best Result at a glance</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                        <%-----THIS IS MESSAGE SECTION-----%>
                    </div>
                </div>
                <div class="bm_academic_container_body1">
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding" style="border-bottom: 0px;">
                            <table width="100%" style="border-collapse: collapse;">
                                <tr style="width: 100%">
                                    <td style="width: 60%">
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                                <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 94px">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label15" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 103px">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                                <asp:Label ID="Label16" runat="server" Text="Term :" AssociatedControlID="xterm"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </td>
                                    <td style="width: 40%">
                                        <div class="button_section_style1">
                                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button1 bm_am_btn_refresh"
                                                OnClick="btnRefresh_Click" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save Comments" CssClass="bm_academic_button1 bm_am_btn_save"
                                                OnClick="btnSave_Click" Width="120px" />
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"
                                                OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="bm_academic_button1 bm_am_btn_edit"
                                                OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
                                            <asp:Button ID="btnUndo" runat="server" Text="Undo" CssClass="bm_academic_button1 bm_am_btn_delete"
                                                OnClientClick="javascript:ConfirmMessage2();" OnClick="btnUndo_Click" />
                                            <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="bm_academic_button1 bm_am_btn_approve"
                                                OnClientClick="javascript:ConfirmMessage3();" OnClick="btnApprove_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100">
                                <div class="bm_layout_box_padding" style="padding-top: 0px;">
                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both;">
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                                <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 94px">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                                <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 103px">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged_class">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label4" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label5" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                                <asp:Label ID="Label6" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 184px">
                                                <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged_subject">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                       <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                                <asp:Label ID="Label7" runat="server" Text="Paper :" AssociatedControlID="xpaper"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 184px;">
                                                <asp:DropDownList ID="xpaper" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 260px" runat="server" id="_xext">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 74px">
                                                <asp:Label ID="Label14" runat="server" Text="Extension :" AssociatedControlID="xext"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 184px">
                                                <asp:DropDownList ID="xext" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px;" runat="server" id="_xpaper">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 55px">
                                                <asp:Label ID="Label7" runat="server" Text="Paper :" AssociatedControlID="xpaper"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 53px;">
                                                <asp:DropDownList ID="xpaper" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--            <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                                <asp:Label ID="Label7" runat="server" Text="Paper :" AssociatedControlID="xpaper"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xpaper" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="width: 32px; padding-top: 6px;
                                            border: none; height: 32px;display: inline-block">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                    Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; padding-left: 15px;
                                            border: none">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="width: 32px; padding-top: 6px; border: none;
                                            height: 32px; display: inline-block; padding-left: 60px;">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                    Width="25px" Height="25px" OnClientClick="fnPrintSchedule();" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div style="width: 100%; clear: both; padding-top: 5px">
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 135px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label8" runat="server" Text="Take Best :" AssociatedControlID="xtbest"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xtbest" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: none; width: 90px">
                                            <div class="bm_ctl_label_align_center_100_special" style="width: 30px">
                                                <asp:Label ID="Label9" runat="server" Text="% " AssociatedControlID="xperc" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xperc" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <%--Control section end--%>
                                    <div style="padding-top: 5px; width: 100%;" runat="server" ID="divresult">
                                       <div style="float: left; width: 300px; border: 1px solid #65BC46; margin-top: 20px;
                                   " runat="server" id="result">
                                    <div style="text-align: center; color: #fff; background-color: #65BC46; padding-bottom: 5px;
                                        padding-top: 5px; font-size: 14px; font-weight: bold;">
                                        Class test result at a glance
                                    </div>
                                    <div style="text-align: center; color: #fff; background-color: #ABD693; padding-bottom: 5px;
                                        padding-top: 5px;">
                                        <table style="width: 100%; border-collapse: collapse; border: none;color: #000000">
                                            <tr>
                                                <td style="width: 30%;">
                                                    Subject
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="xsubject11" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%;">
                                                    Take Best
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="xbest" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 100%; background-color: #E5F1D4; padding-top: 10px; padding-left: 10px;">
                                        <table style="width: 100%; border-collapse: collapse; border: none;color: #000000">
                                            <tr>
                                                <td style="width: 60%;">
                                                    Number of students
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="xnostd" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 60%;">
                                                    Subject taken
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="xtaken" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 60%;">
                                                    Absent in exam
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="xabsent" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 100%; background-color: #E5F1D4; padding-top: 15px;" runat="server"
                                        id="grade">
                                        <%--  <table style="width: 100%; border-collapse: collapse; border: none;">
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    90% - 100%
                                                </td>
                                                <td style="width: 20%;">
                                                    A*
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="xaa" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    80% - 89%
                                                </td>
                                                <td style="width: 20%;">
                                                    A
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="xa" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    70% - 79%
                                                </td>
                                                <td style="width: 20%;">
                                                    B
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="xb" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    60% - 69%
                                                </td>
                                                <td style="width: 20%;">
                                                    C
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    50% - 59%
                                                </td>
                                                <td style="width: 20%;">
                                                    D
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    Bellow 50%
                                                </td>
                                                <td style="width: 20%;">
                                                    U
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    Bellow 40%
                                                </td>
                                                <td style="width: 20%;">
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </div>
                                    <div style="width: 100%; background-color: #E5F1D4; padding-top: 10px; padding-left: 10px;
                                        padding-top: 5px; padding-bottom: 10px">
                                        <table style="width: 100%; border-collapse: collapse; border: none;color: #000000">
                                            <tr>
                                                <td style="width: 30%;">
                                                    Subj. Teacher
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%;">
                                                    Class Teacher
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="Label1303" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%;">
                                                    C.Coordinator
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                       <div style="float: left; width: 420px; margin-left: 20px;" runat="server" id="barchart">
                                    <div style="float: left; width: 400px;"  runat="server" id="barchart1">
                                        <asp:Chart ID="Chart1" runat="server" Width="400" Height="410" BackColor="#eaf7ff" >
                                            
                                            <Series>
                                                <asp:Series Name="Series1" ChartArea="ChartArea1" >
                                                   
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1" BackColor="#eaf7ff">
                                                    <AxisX Title="Grade" LineColor="Black" >
                                                        <MajorGrid Enabled="False" />
                                                    </AxisX>
                                                   
                                                    <AxisY Title="Student" LineColor="Black" Interval="10">
                                                        <MajorGrid Enabled="true" LineColor="Silver" />
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                       
                                    </div>
                                    <div style="float: left; width: 20px; padding-top: 20px;" runat="server" id="colorcode">
                                    </div>
                                </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px;">
                                <div class="bm_academic_grid_container2" style="width: 100%">
                                    <div class="grid_body" style="width: 1229.4px; overflow: auto;">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                            CssClass="bm_academic_grid1 bm_academic_grid4" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None" OnDataBound="GridView1_DataBound1"
                                            OnRowDataBound="OnRowDataBound" UseAccessibleHeaderText="true">
                                            <HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>
                                            <Columns>
                                                <%--<asp:TemplateField HeaderText="Days">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("SelectedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("section") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_body_button_section">
                            <div class="button_section_padding">
                                <div class="button_section_style1">
                                    <asp:Button ID="btnRefresh1" runat="server" Text="Refresh" CssClass="bm_academic_button1 bm_am_btn_refresh"
                                        OnClick="btnRefresh_Click" />
                                    <asp:Button ID="btnSave1" runat="server" Text="Save Comments" CssClass="bm_academic_button1 bm_am_btn_save"
                                        OnClick="btnSave_Click" Width="120px" />
                                    <asp:Button ID="btnDelete1" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"
                                        OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btnSubmit1" runat="server" Text="Submit" CssClass="bm_academic_button1 bm_am_btn_edit"
                                        OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnUndo1" runat="server" Text="Undo" CssClass="bm_academic_button1 bm_am_btn_delete"
                                        OnClientClick="javascript:ConfirmMessage2();" OnClick="btnUndo_Click" />
                                    <asp:Button ID="btnApprove1" runat="server" Text="Approve" CssClass="bm_academic_button1 bm_am_btn_approve"
                                        OnClientClick="javascript:ConfirmMessage3();" OnClick="btnApprove_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowList"
                PopupControlID="pnlpopup" CancelControlID="btnCancel"  BackgroundCssClass="modal">
           
            </cc1:ModalPopupExtender>--%>
                <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="530px" Width="800px"
                    Style="display: none" ScrollBars="Auto">
                    <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%;
                        border-collapse: collapse;" cellpadding="0" cellspacing="0">
                        <tr style="background-color: #619CFD; height: 30px; text-align: right;">
                            <td>
                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close-window.png"
                                    Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                kjslfjklfjksl
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
                <asp:HiddenField ID="txtconformmessageValue2" runat="server" />
                <asp:HiddenField ID="txtconformmessageValue3" runat="server" />
                <asp:HiddenField ID="hiddenxdate" runat="server" />
                <asp:HiddenField ID="hiddenxrow" runat="server" />
                <asp:HiddenField ID="hiddenxstatus" runat="server" />
                <asp:HiddenField ID="hxstatus" runat="server" />
                <asp:HiddenField ID="xnsdate" runat="server" />
                <asp:HiddenField ID="xgcol" runat="server" />
                <asp:HiddenField ID="hiscom" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
