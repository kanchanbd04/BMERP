<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="amtfcconfig.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.amtfcconfig" %>

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
        /*.bm_academic_grid1 tr:nth-child(6) td{
    padding: 2px; 
    border-bottom: solid 2px #000000; 
    color: #000000;
    padding-left: 3px;
    font-weight: normal;
     font-size: 14px;
     font-family: Myriad Pro,tahoma; 
}*/
        .bm_academic_textarea:focus {
            background-color: #f7dc6f;
            -webkit-border-radius: 0px;
            -moz-border-radius: 0px;
            border-radius: 0px;
        }
    </style>
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

            <%--   //             $('.bm_subject_teacher').click(function () {
            //            //alert("Hi");
            //            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _subteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            //            });--%>











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
                <%--                $("body").on("click", ".bm_subject_teacher", function() {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $("#<%= _subteacher.ClientID%>").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });--%>

                <%--                $("body").on("click", ".bm_class_teacher", function () {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _classteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });--%>

                <%--                // $("body").on("click", ".bm_subject", function () {
                //alert("Button was clicked.");
                //fnOpenSubjectList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                // });--%>
                
               
                    $("body").on("click", "#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox", function () {
                    //Get number of checkboxes in list either checked or not checked
                    var totalCheckboxes = $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox").size();
                    //Get number of checked checkboxes in list
                    var checkedCheckboxes = $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox:checked").size();
                    //Check / Uncheck top checkbox if all the checked boxes in list are checked
                    $("#<%=GridView1.ClientID%> input[id*='chkall']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
                });

                
                    $("body").on("click", "#<%=GridView1.ClientID%> input[id*='chkall']:checkbox", function () {
                    //Check/uncheck all checkboxes in list according to main checkbox 
                    $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox").attr('checked', $(this).is(':checked'));
                 });

                 $("body").on("click", ".bm_tfccode", function () {
                     //alert($("#<%=GridView1.ClientID%>").attr("ID"));
                     //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    if($("#<%=hxstatus.ClientID%>").val()=="")
                     {
                        fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"),$("#<%=GridView1.ClientID%>").attr("ID"));
                     }
                 
                     //fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                });
                
                
                $("body").on("click", ".bm_student", function () {
                    //alert("Hi");
                    //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    if ($("#<%=hxstatus.ClientID%>").val() == "") {
                        fnOpenStudentList2(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    }
                });

                $("body").on("click", ".bm_list", function () {
                    <%--//alert("Button was clicked.");
                    // alert(this.getAttribute("rowno"));
                    //                 alert(document.getElementById('<%=hxstatus.ClientID %>').value);
                 //                 return;
                 var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                 var xcttype1 = document.getElementById('<%=xcttype.ClientID %>').value;
                 if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1') {
                     var row = this.parentNode.parentNode;
                     var rowIndex = row.rowIndex - 1;
                     // alert(row.cells[4].getElementsByTagName("textarea")[0].id);
                     if (xcttype1 == 'Extra Test' || xcttype1 == 'Retest') {
                         fnOpenCommentsList(<%= HttpContext.Current.Session["business"] %>, row.cells[5].getElementsByTagName("textarea")[0].id, row.cells[5].getElementsByTagName("textarea")[0].value);
                     } else {
                         fnOpenCommentsList(<%= HttpContext.Current.Session["business"] %>, row.cells[4].getElementsByTagName("textarea")[0].id, row.cells[4].getElementsByTagName("textarea")[0].value);
                     }
                 }--%>
                });

             <%--//              $("body").on("click", ".bm_marks", function () {

             //                 var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                //                 var xcttype1 = document.getElementById('<%=xcttype.ClientID %>').value;
                //                 if (xst == '' || xst == 'New') {
                //                     var row = this.parentNode.parentNode;
                //                     var rowIndex = row.rowIndex - 1;
                //                     alert(row.cells[3].getElementsByTagName("input")[0].value);
                //                 }
                //             });--%>



                $("body").on("click", ".bm_am_btn_save", function () {

                   //                alert("Hi");
                    //                return false;

                    var mendatoryFields = [
                                         { "id": "<%= xtfccode.ClientID%>", "prop": "listtext", "tab": "0" },
                                    { "id": "<%= xeffdate.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= xamount.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= xsign.ClientID%>", "prop": "text", "tab": "0" }
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
              <%-- // alert("Hi");
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
                //return false;--%>
                }





            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Tuition Fees & Chrages Setup</span>
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
                            <div class="button_section_style1" style="text-align: left">
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                    OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="bm_academic_button3 bm_am_btn_submit"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="bm_academic_button3 bm_am_btn_active"
                                     OnClick="btnActive_Click" />
                                 <asp:Button ID="btnInactive" runat="server" Text="Inactive" CssClass="bm_academic_button3 bm_am_btn_inactive"
                                     OnClick="btnInactive_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100">
                                <div class="bm_layout_box_padding" style="padding-top: 0px;">
                                    <%--Control section start--%>
                                    <%-- <div style="width: 100%; clear: both;">
                                    </div>
                                    <div style="width: 100%; clear: both; padding-top: 5px">
                                    </div>--%>
                                    <%--Control section end--%>
                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px">
                                <div class="bm_academic_grid_container2" style="width: 100%">

                                    <div style="float: left; width: 50%; padding: 0px 2px 10px 10px;">



                                        <div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label14" runat="server" Text=" TFC Code :" AssociatedControlID="xtfccode"
                                                        CssClass="label mendatory"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xtfccode" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_tfccode" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xtfccodetitle" runat="server" Text="" CssClass="xtfccodetitle" EnableViewState="True"></asp:Label>
                                                <%--<div class="xtfccodetitle" id="xtfccodetitle"></div>--%>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" Text="Effected Date :" AssociatedControlID="xeffdate"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xeffdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px;display:none">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                       <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px;display:none">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                       <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div style="display: none;">
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label4" runat="server" Text=" Student ID :" AssociatedControlID="xstdid"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
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
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="Default Amount :" AssociatedControlID="xamount"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xamount" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="Sign :" AssociatedControlID="xsign"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xsign" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label15" runat="server" Text="Payment Type :" AssociatedControlID="xtype1"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xtype1" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <%-- <div style=" width: 270px;">--%>
                                        <%--<fieldset>
                                                <legend>Discount</legend>--%>

                                        <%--   <div class="bm_ctl_container_50_50" style=" width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label6" runat="server" Text="Discount :" AssociatedControlID="xdisfixed"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xdisfixed" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style=" width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="Percentage (%) :" AssociatedControlID="xdisperc"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xdisperc" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--</fieldset>--%>
                                        <%--</div>--%>
                                        <div class="bm_ctl_container_50_50" style="width: 271px; height: 90px; ">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px; height: 100%; padding-top: 33px">
                                                <asp:Label ID="Label6" runat="server" Text="Discount :" AssociatedControlID="xdisfixed"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px; height: 100%">
                                                <div style="width: 100%; height: 20px; background-color: #c0c0c0; color: #000000; text-align: center">
                                                    Fixed Amount
                                                </div>
                                                <div style="width: 100%; height: 20px">
                                                    <asp:TextBox ID="xdisfixed" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div style="width: 100%; height: 20px; background-color: #c0c0c0; color: #000000; text-align: center; margin-top: 3px">
                                                    Percentage %
                                                </div>
                                                <div style="width: 100%; height: 20px">
                                                    <asp:TextBox ID="xdisperc" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="width: 271px; height: 90px;display: none;">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px; height: 100%; padding-top: 33px">
                                                <asp:Label ID="Label8" runat="server" Text="VAT :" AssociatedControlID="xvatfixed"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px; height: 100%">
                                                <div style="width: 100%; height: 20px; background-color: #c0c0c0; color: #000000; text-align: center">
                                                    Fixed Amount
                                                </div>
                                                <div style="width: 100%; height: 20px">
                                                    <asp:TextBox ID="xvatfixed" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div style="width: 100%; height: 20px; background-color: #c0c0c0; color: #000000; text-align: center; margin-top: 3px">
                                                    Percentage %
                                                </div>
                                                <div style="width: 100%; height: 20px">
                                                    <asp:TextBox ID="xvatperc" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="width: 450px; height: 70px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px; height: 100%; padding-top: 20px">
                                                <asp:Label ID="Label9" runat="server" Text="Remarks :" AssociatedControlID="xremarks"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px; height: 66px">

                                                <div style="width: 100%; height: 100%">
                                                    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" TextMode="MultiLine"></asp:TextBox>--%>
                                                    <textarea id="xremarks" style="width: 328px; height: 100%; border: none" class="bm_academic_textarea_100_80  bm_academic_textarea" runat="server"></textarea>
                                                </div>


                                            </div>
                                        </div>
                                        
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 270px;">
                                            <div class="bm_ctl_container_50_100" style="width: 120px; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 100%">
                                                    <asp:Label ID="Label73" runat="server" Text="Active? " AssociatedControlID="zactive"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 137px">
                                                <asp:CheckBox ID="zactive" runat="server" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label13" runat="server" Text="Status :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="xstatus" runat="server">
                                                    New
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l" style="">
                                                    <asp:Label ID="Label11" runat="server" Text="Entered By :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="zemail" runat="server">
                                                    zemail@bm.com
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label12" runat="server" Text="Updated By :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="xemail" runat="server">
                                                    xemail@bm.com
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div style="float: left; width: 48%; padding-bottom: 10px; margin-top: 0px;">
                                        <div style="background-color: #556b2f; color: #FFFFFF;padding: 5px">
                                            TFC Code Relationship With :
                                            </div>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                            CssClass="bm_academic_grid1 bm_academic_grid4" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound"
                                            UseAccessibleHeaderText="true" OnDataBound="GridView1_DataBound1">
                                            <%--<HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>--%>
                                            <Columns>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding">
                            <div class="button_section_style1" style="text-align: left">
                                <asp:Button ID="btnRefresh1" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete1" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                    OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnSubmit1" runat="server" Text="Submit" CssClass="bm_academic_button3 bm_am_btn_submit"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnActive1" runat="server" Text="Active" CssClass="bm_academic_button3 bm_am_btn_active"
                                     OnClick="btnActive_Click" />
                                 <asp:Button ID="btnInactive1" runat="server" Text="Inactive" CssClass="bm_academic_button3 bm_am_btn_inactive"
                                     OnClick="btnInactive_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding">
                                <div class="bm_academic_grid_container" id="list" runat="server">
                                    <div class="grid_header">
                                        <div class="grid_header_label" id="_grid_header" runat="server">
                                            Tuition Fees & Chrages List (New)
                                        </div>
                                        <div class="grid_header_control">
                                            <%--<div class="grid_ctl_padding" style="margin-left: 80px">
                                <div class="bm_ctl_container_100_s_grid">
                                    <div class="bm_ctl_label_align_right_100_s_grid">
                                        <asp:Label ID="Label52" runat="server" Text="Session :" AssociatedControlID="grid_xsession"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_s_grid">
                                        <asp:DropDownList ID="grid_xsession" AutoPostBack="True" runat="server" CssClass="bm_academic_dropdown_100_s_grid bm_academic_ctl_global bm_academic_dropdown"
                                            OnTextChanged="fnFillDataGrid">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="bm_ctl_container_100_s_grid">
                                    <div class="bm_ctl_label_align_right_100_s_grid">
                                        <asp:Label ID="Label54" runat="server" Text="Class :" AssociatedControlID="grid_xclass"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_s_grid">
                                        <asp:DropDownList ID="grid_xclass" AutoPostBack="True" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location"
                                            OnTextChanged="fnFillDataGrid">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="bm_ctl_container_100_s_grid">
                                    <div class="bm_ctl_label_align_right_100_s_grid">
                                        <asp:Label ID="Label70" runat="server" Text="Group :" AssociatedControlID="grid_xgroup"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_s_grid">
                                        <asp:DropDownList ID="grid_xgroup" AutoPostBack="True" runat="server" CssClass="bm_academic_dropdown_100_s_grid bm_academic_ctl_global bm_academic_dropdown"
                                            OnTextChanged="fnFillDataGrid">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="bm_ctl_container_100_s_grid">
                                    <div class="bm_ctl_label_align_right_100_s_grid" style="width:60%">
                                        <asp:Label ID="Label71" runat="server" Text="No of Exam :" AssociatedControlID="grid_xnumexam"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_s_grid" style="width:40%">
                                        <asp:DropDownList ID="grid_xnumexam" AutoPostBack="True" runat="server" CssClass="bm_academic_dropdown_100_s_grid bm_academic_ctl_global bm_academic_dropdown"
                                            OnTextChanged="fnFillDataGrid">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>--%>
                                        </div>
                                        <div class="flot_right">
                                            <%-- <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>--%>
                                            <div class="grid_header_row">
                                                <asp:TextBox ID="_gridrow" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                                   OnTextChanged="fnFillGrid6"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="grid_body">
                                        <asp:GridView ID="dgvTFCListNew" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                                            OnClick="FillControl"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <%--  <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="xtfccode" HeaderText="TFC Code" ItemStyle-Width="120px"
                                                    ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xtfccodetitle" HeaderText="Title" ItemStyle-Width="250px"
                                                    ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xeffdate" HeaderText="Effected Date"  DataFormatString="{0:dd/MM/yyyy}"
                                                    ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xgroup" HeaderText="Group" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xsection" HeaderText="Section" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xstdid" HeaderText="Student ID" ItemStyle-Width="120px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="250px"
                                                    ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xamount" HeaderText="Amount"  
                                                    ItemStyle-Width="120px" ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5"/>
                                                  <asp:TemplateField HeaderText="Active?" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate >
                                                        <asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />
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
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding">
                                <div class="bm_academic_grid_container" id="Div1" runat="server">
                                    <div class="grid_header">
                                        <div class="grid_header_label" id="Div2" runat="server">
                                            Tuition Fees & Chrages List (Submitted)
                                        </div>
                                        <div class="grid_header_control">
                                        </div>
                                        <div class="flot_right">
                                            <%-- <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>--%>
                                            <div class="grid_header_row">
                                                <asp:TextBox ID="_gridrow1" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                                    OnTextChanged="fnFillGrid6"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="grid_body">
                                        <asp:GridView ID="dgvTFCListSubmitted" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                                            OnClick="FillControl"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <%--  <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="xtfccode" HeaderText="TFC Code" ItemStyle-Width="120px"
                                                    ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xtfccodetitle" HeaderText="Title" ItemStyle-Width="250px"
                                                    ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xeffdate" HeaderText="Effected Date"  DataFormatString="{0:dd/MM/yyyy}"
                                                    ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xgroup" HeaderText="Group" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xsection" HeaderText="Section" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xstdid" HeaderText="Student ID" ItemStyle-Width="120px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="250px"
                                                    ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xamount" HeaderText="Amount"  
                                                    ItemStyle-Width="120px" ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5"/>
                                                   <asp:TemplateField HeaderText="Active?" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%-- <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowList"
                PopupControlID="pnlpopup" CancelControlID="btnCancel"  BackgroundCssClass="modal">
           
            </cc1:ModalPopupExtender>--%>
            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="530px" Width="800px"
                Style="display: none" ScrollBars="Auto">
                <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #619CFD; height: 30px; text-align: right;">
                        <td>
                            <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close-window.png"
                                Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                        </td>
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


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
