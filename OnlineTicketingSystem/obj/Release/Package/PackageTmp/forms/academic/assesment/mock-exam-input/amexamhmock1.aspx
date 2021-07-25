<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="amexamhmock1.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.amexamhmock1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
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
        $("body").on("click", ".bm_subject_teacher", function() {
            //alert("Button was clicked.");
            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $("#<%= _subteacher.ClientID%>").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
        });

          $("body").on("click", ".bm_class_teacher", function () {
            //alert("Button was clicked.");
            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _classteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
        });

        // $("body").on("click", ".bm_subject", function () {
                //alert("Button was clicked.");
                //fnOpenSubjectList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
           // });

             $("body").on("click", ".bm_list", function () {
            //alert("Button was clicked.");
                // alert(this.getAttribute("rowno"));
//                 alert(document.getElementById('<%=hxstatus.ClientID %>').value);
//                 return;
                 var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                 if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1') {
                     var row = this.parentNode.parentNode;
                     var rowIndex = row.rowIndex - 1;
                     // alert(row.cells[4].getElementsByTagName("textarea")[0].id);
                    
                     fnOpenCommentsList(<%= HttpContext.Current.Session["business"] %>, row.cells[4].getElementsByTagName("textarea")[0].id, row.cells[4].getElementsByTagName("textarea")[0].value);
                     
                 }
             });

//              $("body").on("click", ".bm_marks", function () {

//                 var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
//                 if (xst == '' || xst == 'New') {
//                     var row = this.parentNode.parentNode;
//                     var rowIndex = row.rowIndex - 1;
//                     alert(row.cells[3].getElementsByTagName("input")[0].value);
//                 }
//             });



        $("body").on("click", ".bm_am_btn_save", function () {

            //                alert("Hi");
            //                return false;

            var mendatoryFields = [
                                 { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xterm.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsubject.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xdate.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= xmarks.ClientID%>", "prop": "text", "tab": "0" }
                                ];
            var mendatoryString = JSON.stringify(mendatoryFields);
            if (!fnMendatoryFields1(mendatoryString)) {
                return false;
            }


            return true;
        });

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
                        <span class="bm_am_header_round">Mock Exam Marks Input</span>
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
                                                <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 103px">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                            <div class="bm_ctl_label_align_right_100_special" >
                                                <asp:Label ID="Label1" runat="server" Text="Mock :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" >
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
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button1 bm_am_btn_save"
                                                OnClick="btnSave_Click" />
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"
                                                OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="bm_academic_button1 bm_am_btn_edit"
                                                OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
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
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
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
                                       <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                         <div class="bm_ctl_container_100_special" style="display: inline-block; ">
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
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px">
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
                                        <div class="bm_ctl_container_100_special" style="display: none; width: 260px">
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
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px;">
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
                                        <%--    <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
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
                                       <%-- <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label8" runat="server" Text="Test Type :" AssociatedControlID="xcttype"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 103px">
                                                <asp:DropDownList ID="xcttype" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xcttype_Click">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                       <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 130px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 65px">
                                                <asp:Label ID="Label9" runat="server" Text="Test No :" AssociatedControlID="xctno"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 63px">
                                                <asp:DropDownList ID="xctno" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xctno_Click">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                       <%-- <div class="bm_ctl_container_100_special" style="display: inline-block;" runat="server"
                                            id="retestfor">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label11" runat="server" Text="Reference :" AssociatedControlID="xreference"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 103px">
                                                <asp:DropDownList ID="xreference" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xreference_Click">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                       <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 210px"
                                            runat="server" id="schedule_d">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 100px">
                                                <asp:Label ID="Label13" runat="server" Text="Schedule Date :" AssociatedControlID="xschdate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 108px">
                                               
                                                <asp:TextBox ID="xschdate" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 210px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label3" runat="server" Text="Exam Date :" AssociatedControlID="xdate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 133px">
                                                <asp:TextBox ID="xdate" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_datepicker"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; width: 350px"
                                            runat="server" id="xreason_d">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 65px">
                                                <asp:Label ID="Label12" runat="server" Text="Reason :" AssociatedControlID="xreason"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 282px">
                                                <asp:TextBox ID="xreason" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 100px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                                <asp:Label ID="Label10" runat="server" Text="Marks :" AssociatedControlID="xmarks"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 48px">
                                                <asp:TextBox ID="xmarks" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                     <%--   <div class="bm_ctl_container_100_special" style="display: inline-block; width: 90px">
                                            <div class="bm_ctl_label_align_center_100_special" style="width: 30px">
                                                <asp:Label ID="Label9" runat="server" Text="% " AssociatedControlID="xperc" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xperc" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px;
                                            margin-left: 158px;">
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
                                        <%-- <div style="display: inline-block; width: 24%; margin-left: 11px;">
                                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="30px" Height="30px" CssClass="bm_academic_button_zoom" />
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; padding-left: 15px; padding-top: 5px;
                                            border: none">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; border: none;">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%; padding-top: 5px;">
                                                <asp:LinkButton ID="btnShowList" runat="server">List of Class Test Taken Out</asp:LinkButton>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <%--Control section end--%>
                                   <%-- <div class="am_collapsible_panel" runat="server" id="pnllistct">
                                        <asp:Panel runat="server" ID="panel1" CssClass="am_collapsible_panel_header">
                                            <div class="am_collapsible_panel_htext">
                                                Class Test Taken
                                                <asp:Label runat="server" ID="textLabel" />
                                            </div>
                                            <div class="am_collapsible_panel_himage">
                                                <asp:Image ID="Image1" runat="server" Height="15px" Width="15px" />
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="panel2" CssClass="am_collapsible_panel_body">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="bm_academic_grid2 bm_academic_grid4"
                                                HeaderStyle-CssClass="HeaderStyle" RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xno" runat="server" Text='<%#Eval("xno") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="xcttype" HeaderText="Test Type" ItemStyle-Width="100px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xctno" HeaderText="Test No" ItemStyle-Width="100px" ItemStyle-CssClass="pad5"
                                                        ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="xdate" HeaderText="Test Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="xtopic" HeaderText="Topic" ItemStyle-Width="150px" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xcteacher" HeaderText="Class Teacher" ItemStyle-Width="200px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xsteacher" HeaderText="Subject Teacher" ItemStyle-Width="200px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xremarks" HeaderText="Remarks" ItemStyle-Width="200px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xstatus" HeaderText="Status" ItemStyle-Width="120px" ItemStyle-CssClass="pad5"
                                                        ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="xrow" HeaderText="Test No" ItemStyle-Width="120px" ItemStyle-CssClass="pad5"
                                                        ItemStyle-HorizontalAlign="Center" Visible="False" />
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                        <cc1:CollapsiblePanelExtender runat="server" ID="cpe" TargetControlID="panel2" CollapseControlID="panel1"
                                            ExpandControlID="panel1" Collapsed="true" CollapsedSize="0" ExpandedText="(Hide List...)"
                                            CollapsedText="(Show List...)" TextLabelID="textLabel" ImageControlID="Image1"
                                            ExpandedImage="~/images/collaps.png" CollapsedImage="~/images/expand.png" ExpandDirection="Vertical">
                                        </cc1:CollapsiblePanelExtender>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px;">
                                <div class="bm_academic_grid_container2" style="width: 100%">
                                    <div style="float: left; width: 20%; margin: 4px 2px 0px 10px;">
                                        <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%;
                                            border-collapse: collapse;" cellpadding="0" cellspacing="0">
                                          <%--  <tr style="background-color: #619CFD">
                                                <td style="height: 15px; color: white; font-size: 14px" align="left">
                                                    Topic/Chapter
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px;">
                                                    <textarea id="xtopic" class="bm_academic_textarea_100_50  bm_academic_textarea" style="width: 100%;
                                                        height: 50px;" runat="server"></textarea>
                                                </td>
                                            </tr>--%>
                                            <tr style="background-color: #619CFD">
                                                <td style="height: 15px; color: white; font-size: 14px" align="left">
                                                    Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px;">
                                                        <textarea id="xdetails" class="bm_academic_textarea_100_50  bm_academic_textarea"
                                                            style="width: 100%; height: 130px;" runat="server"></textarea>
                                                    </td>
                                                </tr>
                                                <tr style="background-color: #619CFD">
                                                    <td style="height: 15px; color: white; font-size: 14px" align="left">
                                                        Class Teacher
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px">
                                                        <%-- <div class="bm_ctl_container_50_60" style="width: 100%">
                                                        <div class="bm_clt_ctl_50_60" style="width: 100%">
                                                            <div class="bm_list_text" style="width: 100%">
                                                                <asp:TextBox ID="xcteacher" Enabled="False" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                        <%--<asp:Label ID="xcteacher" runat="server" Text="-"></asp:Label>--%>
                                                        <div class="bm_ctl_container_50_60" style="width: 100%">
                                                            <div class="bm_clt_ctl_50_60" style="width: 100%">
                                                                <div class="bm_list_text" style="width: 90%">
                                                                    <asp:TextBox ID="xcteacher" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                                <div class="bm_list_img" style="width: 10%">
                                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_class_teacher" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="background-color: #619CFD">
                                                    <td style="height: 15px; color: white; font-size: 14px" align="left">
                                                        Subject Teacher
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px">
                                                        <%--<div class="bm_ctl_container_50_60" style="width: 100%">
                                                        <div class="bm_clt_ctl_50_60" style="width: 100%">
                                                            <div class="bm_list_text" style="width: 100%">
                                                                <asp:TextBox ID="xsteacher" Enabled="False" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                        <%-- <asp:Label ID="xsteacher" runat="server" Text="-"></asp:Label>--%>
                                                        <div class="bm_ctl_container_50_60" style="width: 100%">
                                                            <div class="bm_clt_ctl_50_60" style="width: 100%">
                                                                <div class="bm_list_text" style="width: 90%">
                                                                    <asp:TextBox ID="xsteacher" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                                <div class="bm_list_img" style="width: 10%">
                                                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_subject_teacher" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="background-color: #619CFD">
                                                    <td style="height: 15px; color: white; font-size: 14px" align="left">
                                                        Status
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px">
                                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; padding-left: 15px;
                                                        padding-top: 5px; border: none">
                                                        <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                            <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                                        </div>
                                                    </div>--%>
                                                        <asp:Label ID="dxstatus" runat="server" Text="-" CssClass="xstatus"></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                                <tr style="background-color: #619CFD">
                                                    <td style="height: 15px; color: white; font-size: 14px" align="left">
                                                        Question Upload
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px">
                                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; padding-left: 15px;
                                                        padding-top: 5px; border: none">
                                                        <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                            <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                                        </div>
                                                    </div>--%>
                                                        <asp:Label ID="Label8" runat="server" Text="-" CssClass="xstatus"></asp:Label>
                                                    </td>
                                                </tr>
                                        </table>
                                    </div>
                                    <div style="float: left; width: 78%; margin-bottom: 10px;">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                            CssClass="bm_academic_grid1 bm_academic_grid4" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound"
                                            UseAccessibleHeaderText="true" AllowSorting="True" OnSorting="GridView1_Sorting">
                                            <%--<HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>--%>
                                            <Columns>
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
                                    <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="bm_academic_button1 bm_am_btn_save"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnDelete1" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"
                                        OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btnSubmit1" runat="server" Text="Submit" CssClass="bm_academic_button1 bm_am_btn_edit"
                                        OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
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
                <asp:HiddenField ID="hiddenxdate" runat="server" />
                <asp:HiddenField ID="hiddenxrow" runat="server" />
                <asp:HiddenField ID="hiddenxstatus" runat="server" />
                <asp:HiddenField ID="hxstatus" runat="server" />
                <asp:HiddenField ID="xnsdate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
