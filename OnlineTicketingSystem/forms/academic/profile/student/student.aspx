<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="student.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.student" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .bttn
        {
            padding: 3px 20px;
            margin-right: 7px;
            cursor: pointer;
            background-color: #007DC5;
            border: none;
            color: #FFFFFF;
            font-family: Myriad Pro,tahoma;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            -webkit-transition-duration: 0.2s; /* Safari */
            transition-duration: 0.2s;
            width: 100px;
        }
        
        
        
        .bttn:hover
        {
            background-color: #F68814;
            color: #C7EBFC;
        }
        .bttn:active
        {
            /*background-color: #F68814;
    color:  #C7EBFC;*/
            background-color: #C7EBFC;
            color: #F68814;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            //alert("Hi!");
            //alert("<%= HttpContext.Current.Session["business"] %>");
            //            $('.bm_academic_datepicker').attr('placeholder', 'DD/MM/YYYY');
            //ns.dp_placeholder();
            //$("[id$='rdoUpload']").prop('checked', true); 

             //if ($("[id$='rdoCapture']").is(':checked')) {
             //     $("#<%= FileUpload1.ClientID%>").css('visibility', 'hidden');
             //     $("#<%= ImageButton3.ClientID%>").css('visibility', 'hidden');
             //};

            $('.bm_am_btn_save').click(function () {

                var getActiveTab = $("#<%= getActiveTabIndex.ClientID%>").val();

                var mendatoryFields = [
                 { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                    { "id": "<%= xname.ClientID%>", "prop": "listtext", "tab": "0" },
                    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                     { "id": "<%= xmname.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xcellnom.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xfname.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xcellno1f.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xdob.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xreligion.ClientID%>", "prop": "combo", "tab": "0" },
                      { "id": "<%= xgender.ClientID%>", "prop": "combo", "tab": "0" },
//                       { "id": "<%= xnumexam.ClientID%>", "prop": "combo", "tab": "0" },
//                    { "id": "<%= xexamdate.ClientID%>", "prop": "text", "tab": "0" },
//                    { "id": "<%= xexamvenue.ClientID%>", "prop": "text", "tab": "0" },
//                    { "id": "<%= xsession_res.ClientID%>", "prop": "text", "tab": "1" },
//                    { "id": "<%= xclass_res.ClientID%>", "prop": "combo", "tab": "1" },
//                    { "id": "<%= xexamroll_res.ClientID%>", "prop": "text", "tab": "1" },
  { "id": "<%= xstdid.ClientID%>", "prop": "text", "tab": "2" },
  { "id": "<%= xsection.ClientID%>", "prop": "text", "tab": "2" },
                    { "id": "<%= getActiveTabIndex.ClientID%>", "prop": "tab", "tab": "-1" }
                ];
                var mendatoryString = JSON.stringify(mendatoryFields);
                if (!fnMendatoryFields(mendatoryString)) {
                    return false;
                }


                return true;
            });

            $('.bm_am_btn_edit').click(function () {
                //                var getActiveTab = $("#<%= getActiveTabIndex.ClientID%>").val(); 

                //                var mendatoryFields = [

                //                    { "id": "<%= getActiveTabIndex.ClientID%>", "prop": "tab", "tab":"-1" }
                //                ];
                //                var mendatoryString = JSON.stringify(mendatoryFields);
                //                if (!fnMendatoryFields(mendatoryString)) {
                //                    return false;
                //                }


                //                return true;

                var getActiveTab = $("#<%= getActiveTabIndex.ClientID%>").val();

                var mendatoryFields = [
                 { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                    { "id": "<%= xname.ClientID%>", "prop": "listtext", "tab": "0" },
                    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                     { "id": "<%= xmname.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xcellnom.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xfname.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xcellno1f.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xdob.ClientID%>", "prop": "text", "tab": "0" },
                     { "id": "<%= xreligion.ClientID%>", "prop": "combo", "tab": "0" },
                      { "id": "<%= xgender.ClientID%>", "prop": "combo", "tab": "0" },
//                       { "id": "<%= xnumexam.ClientID%>", "prop": "combo", "tab": "0" },
//                    { "id": "<%= xexamdate.ClientID%>", "prop": "text", "tab": "0" },
//                    { "id": "<%= xexamvenue.ClientID%>", "prop": "text", "tab": "0" },
{ "id": "<%= xstdid.ClientID%>", "prop": "text", "tab": "2" },
{ "id": "<%= xsection.ClientID%>", "prop": "text", "tab": "2" },
                    { "id": "<%= getActiveTabIndex.ClientID%>", "prop": "tab", "tab": "-1" }
                ];
                var mendatoryString = JSON.stringify(mendatoryFields);
                if (!fnMendatoryFields(mendatoryString)) {
                    return false;
                }


                return true;


            });

           // $('.bm_academic_list').click(function () {
                //alert($(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"));
                //alert("<%= HttpContext.Current.Session["business"] %>");
                //alert($(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                //var _zid = '<%= HttpContext.Current.Session["business"] %>';
                //var ctlid = $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID");
                //var filterstr = $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val();
                //fnOpenEMPList(_zid, ctlid, filterstr);
                //fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
           // });

             $('.bm_nationality').click(function () {
                fnOpenNationalityList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });
            
            $('.bm_profession').click(function () {
                fnOpenProfessionList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_student').click(function () {
                //alert($("#<%= _student.ClientID%>").attr("ID"));
                fnOpenStudentList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _student.ClientID%>").attr("ID"),$(".bm_xclass").val(),$(".bm_xsession").val(),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.stdimagecapture').click(function () {
                //alert($("#<%= _student.ClientID%>").attr("ID"));
                //$("#<%= FileUpload1.ClientID%>").css('visibility', 'hidden');
                //$("#<%= ImageButton3.ClientID%>").css('visibility', 'hidden');
                fnImageCapture(<%= HttpContext.Current.Session["business"] %>,'~/images/profile/student/',$("#<%= ximagelink.ClientID%>").attr("ID"),$("#<%= _stdimageurl.ClientID%>").attr("ID"),$("[id$='_row']").val(),"student");
            });
            //
            // $('.stdimageupload').click(function () {
            //    //alert($("#<%= _student.ClientID%>").attr("ID"));
            //    $("#<%= FileUpload1.ClientID%>").css('visibility', 'visible');
            //      $("#<%= ImageButton3.ClientID%>").css('visibility', 'visible');
            //   
            //});
        });

        function fnPrintAdmit() {
            //alert("Hi");
            var xrow_1 = $("#<%= _row.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/stappform.aspx?xrow=' + xrow_1, 'admit', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+screen.width+', height='+screen.height+', top=0, left=0, targets=_blank');
            openwin.focus();
            return false;
        }

        
        function fnRevisedConfrim() {
               var selectedvalue = confirm("Do you really want to revised this student?");
               if (selectedvalue) {
                   document.getElementById('<%=xrevisedst.ClientID %>').value = "Yes";
               } else {
                   document.getElementById('<%=xrevisedst.ClientID %>').value = "No";
               }
           }

           
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label1" id="header_label" runat="server">
               <span class="bm_am_header_round"> Student's Information </span>
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
                <%-----THIS IS MESSAGE SECTION-----%>
            </div>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="bm_academic_tab_250 bm_am_tab1"
                    Height="620px" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="True"
                    ScrollBars="Auto">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Info. for Admission Test</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label4" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xsession">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div style="float: left; width: 95%">
                                                <div class="bm_ctl_container_50_100">
                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                        <asp:Label ID="Label14" runat="server" Text=" Student's Name :" AssociatedControlID="xname"
                                                            CssClass="label mendatory"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                        <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                        <div class="bm_list_text" style="width: 93.5%">
                                                            <asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox " AutoPostBack="True" OnTextChanged="FillControls2"></asp:TextBox>
                                                        </div>
                                                        <div class="bm_list_img">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_student" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 3px;">
                                                <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/search32x32.png" runat="server"
                                                    CssClass="bm_academic_list" OnClick="FillControls2" Width="25px" Height="25px" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_50_50" style="float: left;">
                                                <div class="bm_ctl_label_align_right_50_50">
                                                    <asp:Label ID="Label1" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                        CssClass="label mendatory"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_50">
                                                    <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="bm_ctl_container_50_40" style="float: left; margin-left: 11px; width: 48%">
                                                <div class="bm_ctl_label_align_right_50_40" style="width: 40%">
                                                    <asp:Label ID="Label11" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_40" style="width: 60%">
                                                    <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_50_50" style="float: left">
                                                <div class="bm_ctl_label_align_right_50_50">
                                                    <asp:Label ID="Label12" runat="server" Text="Exam Date :" AssociatedControlID="xexamdate"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_50">
                                                    <asp:TextBox ID="xexamdate" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="bm_ctl_container_50_50" style="float: left; margin-left: 11px; width: 7%">
                                                <div class="bm_ctl_label_align_right_50_50" style="width: 100%">
                                                    <asp:Label ID="Label68" runat="server" Text="Time" CssClass="label"></asp:Label>
                                                </div>
                                                <%--<div class="bm_clt_ctl_50_50">
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                </div>--%>
                                            </div>
                                            <div class="bm_ctl_container_50_50" style="float: left; margin-left: 3px; width: 9%">
                                                <%-- <div class="bm_ctl_label_align_right_50_50" style="width:25%">
                                                    <asp:Label ID="Label69" runat="server" Text="H" AssociatedControlID="xexamdate"
                                                        CssClass="label"></asp:Label>
                                                </div>--%>
                                                <div class="bm_clt_ctl_50_50" style="width: 100%">
                                                    <asp:DropDownList ID="xhour" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown"
                                                        Style="padding-left: 2px;">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="bm_ctl_container_50_50" style="float: left; margin-left: 3px; width: 9%">
                                                <%--<div class="bm_ctl_label_align_right_50_50" style="width:25%">
                                                    <asp:Label ID="Label70" runat="server" Text="M" AssociatedControlID="xexamdate"
                                                        CssClass="label"></asp:Label>
                                                </div>--%>
                                                <div class="bm_clt_ctl_50_50" style="width: 100%">
                                                    <asp:DropDownList ID="xminitue" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown"
                                                        Style="padding-left: 2px;">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="bm_ctl_container_50_50" style="float: left; margin-left: 3px; width: 9%">
                                                <%--<div class="bm_ctl_label_align_right_50_50" style="width:25%">
                                                    <asp:Label ID="Label71" runat="server" Text="P" AssociatedControlID="xexamdate"
                                                        CssClass="label"></asp:Label>
                                                </div>--%>
                                                <div class="bm_clt_ctl_50_50" style="width: 100%">
                                                    <asp:DropDownList ID="xperiod" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown"
                                                        Style="padding-left: 2px;">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="bm_ctl_container_50_40" style="float: left; margin-left: 5px; width: 11.5%">
                                                <div class="bm_ctl_label_align_right_50_40" style="width: 40%">
                                                    <asp:Label ID="Label41" runat="server" Text="Roll" AssociatedControlID="xexamroll"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_40" style="width: 60%">
                                                    <asp:TextBox ID="xexamroll" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"
                                                        ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label2" runat="server" Text="Exam Venue :" AssociatedControlID="xexamvenue"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <%--<asp:TextBox ID="xexamvenue" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                <asp:DropDownList ID="xexamvenue" runat="server" CssClass="bm_academic_dropdown_50_100 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label3" runat="server" Text="Previous School :" AssociatedControlID="xpschool"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xpschool" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label5" runat="server" Text="Mother's Name :" AssociatedControlID="xmname"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xmname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label6" runat="server" Text="Profession :" AssociatedControlID="xprofession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <%--<asp:TextBox ID="xprofession" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                <%--<asp:DropDownList ID="xprofession" runat="server" CssClass="bm_academic_dropdown_50_100 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>--%>
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xprofession" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_profession" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label22" runat="server" Text="Cell No :" AssociatedControlID="xcellnom"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="xcellnom" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label7" runat="server" Text="Father's Name :" AssociatedControlID="xfname"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xfname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label8" runat="server" Text="Profession :" AssociatedControlID="xprofession1"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <%--<asp:TextBox ID="xprofession1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                <%-- <asp:DropDownList ID="xprofession1" runat="server" CssClass="bm_academic_dropdown_50_100 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>--%>
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xprofession1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_profession" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label67" runat="server" Text="Cell No :" AssociatedControlID="xcellno1f"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="xcellno1f" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_80" style="display: none">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label9" runat="server" Text="Mobile :" AssociatedControlID="xcontact"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="xcontact" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label10" runat="server" Text="Land Phone :" AssociatedControlID="xphone"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="xphone" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label13" runat="server" Text="Present Address :" AssociatedControlID="xpadd"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xpadd" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label15" runat="server" Text="Permanent Address :" AssociatedControlID="xperadd"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xperadd" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label16" runat="server" Text="Email :" AssociatedControlID="xemail1"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xemail1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <%--<div class="bm_ctl_container_dynamic_60_100">
                                                    <div class="bm_ctl_container_dynamic_60_100_l_50">
                                                        <div class="bm_ctl_label_align_left_dynamic_60_100_l" style="padding-left: 25px;">
                                                            <asp:Label ID="Label31" runat="server" Text="Siblings ID,Name & Class (if any) :"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                                <div class="bm_ctl_container_dynamic_60_100" style="padding-top: 10px; font-style: italic;">
                                                    <div class="bm_ctl_container_dynamic_60_100_l_50" style="border: none; width: 180px;">
                                                    Siblings at Presidency (if any).
                                                          </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                    <asp:ImageButton ID="ImageButton9" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                        Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton9_Click" />
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 15px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label77" runat="server" Text="#" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 98px; margin-right: 12px; text-align: center;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label78" runat="server" Text="ID" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 288px; margin-right: 12px; text-align: center;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label75" runat="server" Text="Name" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 112px; margin-right: 10px; text-align: center;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label76" runat="server" Text="Class" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="bm_clt_padding">
                                                </div>
                                                
                                                 <div class="bm_clt_padding">
                                                </div>

                                                <div style="width: 100%;" id="placeholder9" runat="server">
                                                    <%--<div class="bm_ctl_container_dynamic_100_80_nl">
                                                        <asp:Label ID="Label57" runat="server" Text="1." CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 202px">
                                                        <asp:TextBox ID="TextBox13" runat="server" Style="width: 198px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 320px">
                                                        <asp:TextBox ID="TextBox13" runat="server" Style="width: 316px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 120px">
                                                        <asp:TextBox ID="TextBox15" runat="server" Style="width: 116px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                </div>--%>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding" style="padding-left: 50px;">
                                        <%--<div style="margin-bottom: 32px">
                                        </div>--%>
                                        <div class="bm_ctl_container_50_60" style="border: none; width: 95%; text-align: right">
                                            <%--<div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label69" runat="server" Text="Date of Birth :" AssociatedControlID="xdob"
                                                    CssClass="label"></asp:Label>
                                            </div>--%>
                                            <div class="bm_clt_ctl_50_60" style="width: 100%">
                                                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                    Width="32px" Height="32px" OnClientClick="fnPrintAdmit();" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-top: 0px">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label17" runat="server" Text="Nationality :" AssociatedControlID="xnation"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <%--<asp:DropDownList ID="xnation" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>--%>
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xnation" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_nationality" />
                                                </div>
                                                <%-- <cc1:ComboBox ID="xnation" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown" AutoCompleteMode="SuggestAppend" DropDownStyle="DropDown" EnableTheming="False" ViewStateMode="Enabled">
                                                </cc1:ComboBox>--%>
                                                <%-- <asp:TextBox ID="xnation" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                --%>
                                                <%--  <editable:EditableDropDownList ID="xnation" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </editable:EditableDropDownList>--%>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label18" runat="server" Text="Date of Birth :" AssociatedControlID="xdob"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xdob" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"
                                                    AutoPostBack="True" OnTextChanged="fnCalculateAge"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="lblAge" runat="server" Text="Age (1st July) :" AssociatedControlID="xage"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xage" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label20" runat="server" Text="Religion :" AssociatedControlID="xreligion"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xreligion" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label21" runat="server" Text="Gender :" AssociatedControlID="xgender"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xgender" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label66" runat="server" Text="Number of Exam :" AssociatedControlID="xnumexam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xnumexam" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div style="float: left;">
                                                <div>
                                                    <table style="border: none;">
                                                        <tr>
                                                            <td style="width: 100px">
                                                                <asp:RadioButton ID="rdoUpload" runat="server" Checked="True" GroupName="image" Text="Upload"
                                                                    CssClass="stdimageupload" AutoPostBack="True" OnCheckedChanged="fnImageCheckedChanged" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <asp:RadioButton ID="rdoCapture" runat="server" GroupName="image" Text="Capture"
                                                                    CssClass="stdimagecapture" AutoPostBack="True" OnCheckedChanged="fnImageCheckedChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div>
                                                    <asp:Image ID="ximagelink" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image"
                                                        runat="server" Height="200px" Width="200px" /></div>
                                                <div id="ErrorMsg" style="margin-top: 3px; font-size: 12px; color: #FF0000;" runat="server">
                                                </div>
                                                <div style="margin-top: 10px;">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="170px" />
                                                    <asp:ImageButton ID="ImageButton3" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                        runat="server" OnClick="ImageButton3_Click" Width="30px" />
                                                </div>
                                            </div>
                                            <%--<div style="float: left; margin-top: 120px;">
                                            <b>Instruction</b>
                                            <ol type="1" style="font-size: 12px;">
                                                <li>Only support jpg,jpeg,bmp,png format.</li>
                                                <li>Maximum Image size 100KB.</li>
                                                <li>Image dimension must be 300x300 pixel.</li>
                                            </ol>
                                        </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Admission Test Result</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_100_25">
                                            <div class="bm_ctl_label_align_right_100_25">
                                                <asp:Label ID="Label19" runat="server" Text="Session :" AssociatedControlID="xsession_res"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:DropDownList ID="xsession_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnSelectedIndexChanged="fnClearGrid">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div style="float: left; width: 25%">
                                                <div class="bm_ctl_container_100_25" style="width: 100%">
                                                    <div class="bm_ctl_label_align_right_100_25">
                                                        <asp:Label ID="Label222" runat="server" Text="Class :" AssociatedControlID="xclass_res"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_25">
                                                        <asp:DropDownList ID="xclass_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown"
                                                            AutoPostBack="True" OnSelectedIndexChanged="fnClearGrid">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 24%; margin-left: 10px;">
                                                <div class="bm_ctl_container_100_25" style="width: 100%">
                                                    <div class="bm_ctl_label_align_right_100_25">
                                                        <asp:Label ID="Label23" runat="server" Text="Group :" AssociatedControlID="xgroup_res"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_25">
                                                        <asp:DropDownList ID="xgroup_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown"
                                                            AutoPostBack="True" OnSelectedIndexChanged="fnClearGrid">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div style="float: left; width: 25%">
                                                <div class="bm_ctl_container_100_25" style="width: 100%">
                                                    <div class="bm_ctl_label_align_right_100_25">
                                                        <asp:Label ID="Label24" runat="server" Text="Number of Exam :" AssociatedControlID="xnumexam_res"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_25">
                                                        <asp:DropDownList ID="xnumexam_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown"
                                                            AutoPostBack="True" OnSelectedIndexChanged="fnGetDate">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 24%; margin-left: 10px;">
                                                <div class="bm_ctl_container_100_25" style="width: 100%">
                                                    <div class="bm_ctl_label_align_right_100_25">
                                                        <asp:Label ID="Label69" runat="server" Text="Exam Date :" AssociatedControlID="xexamdate_res"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_25">
                                                        <asp:TextBox ID="xexamdate_res" runat="server" CssClass="bm_academic_textbox_100_25 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 24%; margin-left: 10px;">
                                                <div style="float: left; width: 48%;">
                                                    <div class="bm_ctl_container_100_25" style="width: 100%">
                                                        <div class="bm_ctl_label_align_left_100_25" style="width: 70%">
                                                            <asp:Label ID="Label25" runat="server" Text="Total Marks :" AssociatedControlID="xtotalmaks"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_25" style="width: 30%">
                                                            <asp:TextBox ID="xtotalmaks" runat="server" CssClass="bm_academic_textbox_100_25 bm_academic_ctl_global bm_academic_textbox"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 48%; margin-left: 11px;">
                                                    <div class="bm_ctl_container_100_25" style="width: 100%">
                                                        <div class="bm_ctl_label_align_left_100_25" style="width: 70%">
                                                            <asp:Label ID="Label26" runat="server" Text="Pass Marks :" AssociatedControlID="xpassmarks"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_25" style="width: 30%">
                                                            <asp:TextBox ID="xpassmarks" runat="server" CssClass="bm_academic_textbox_100_25 bm_academic_ctl_global bm_academic_textbox"
                                                                ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 24%; margin-left: 11px;">
                                                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/images/reload70.png"
                                                    Width="30px" Height="30px" OnClick="fnFillDataGrid2" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_100_25" style="display: none">
                                            <div class="bm_ctl_label_align_right_100_25">
                                                <asp:Label ID="Label27" runat="server" Text="Exam Roll No :" AssociatedControlID="xexamroll_res"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:TextBox ID="xexamroll_res" runat="server" CssClass="bm_academic_textbox_100_25 bm_academic_ctl_global bm_academic_textbox"
                                                    ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_100_50" style="display: none">
                                            <div class="bm_ctl_label_align_right_100_50">
                                                <asp:Label ID="Label28" runat="server" Text="Student's Name :" AssociatedControlID="xname_res"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_50">
                                                <asp:TextBox ID="xname_res" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"
                                                    ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_100_50" style="display: none">
                                            <div class="bm_ctl_label_align_right_100_50">
                                                <asp:Label ID="Label29" runat="server" Text="Mother's Name :" AssociatedControlID="xmother_res"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_50">
                                                <asp:TextBox ID="xmother_res" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"
                                                    ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div class="bm_ctl_container_100_50" style="display: none">
                                            <div class="bm_ctl_label_align_right_100_50">
                                                <asp:Label ID="Label30" runat="server" Text="Father's Name :" AssociatedControlID="xfather_res"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_50">
                                                <asp:TextBox ID="xfather_res" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"
                                                    ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_25">
                                            <div class="bm_ctl_label_align_right_100_25">
                                                <asp:Label ID="Label41" runat="server" Text="Passing Method :" AssociatedControlID="xpassmethod"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:DropDownList ID="xpassmethod" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <%-- <div style="float: left; width: 14.7%; margin-right: 10px">
                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 100%">
                                                        <asp:Label ID="Label31" runat="server" Text="Marks Obtained :" AssociatedControlID="xfather_res"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <div style="float: left; width: 70%">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <div id="placeholder" runat="server" style="width: 100%;">
                                                            <%--div1<div>
                                                                div11<div style="float: left">
                                                                    div111<div class="bm_ctl_container_100_50" style="width: 190px">
                                                                        div1111<div class="bm_ctl_label_align_right_100_50" style="width: 80%">
                                                                            <asp:Label ID="Label32" runat="server" Text="Bangla :" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        div1112<div class="bm_clt_ctl_100_50" style="width: 20%">
                                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"
                                                                                Text="100" Enabled="False"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                     div112<div class="bm_ctl_container_100_50" style="width: 190px; margin-top: 2px; border: none;">
                                                                        div1121<div class="bm_ctl_label_align_right_100_50" style="width: 80%; background-color: inherit;">
                                                                            <asp:Label ID="Label34" runat="server" Text="" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        div1122<div class="bm_clt_ctl_100_50 border_" style="width: 20%;">
                                                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                div12<div style="float: left; margin-left: 21px">
                                                                     div121<div class="bm_ctl_container_100_50" style="width: 190px">
                                                                        div1211<div class="bm_ctl_label_align_right_100_50" style="width: 80%">
                                                                            <asp:Label ID="Label33" runat="server" Text="English :" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        div1212<div class="bm_clt_ctl_100_50" style="width: 20%">
                                                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"
                                                                                Text="100" Enabled="False"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                     div122<div class="bm_ctl_container_100_50" style="width: 190px; margin-top: 2px; border: none;">
                                                                        div1221<div class="bm_ctl_label_align_right_100_50" style="width: 80%; background-color: inherit;">
                                                                            <asp:Label ID="Label35" runat="server" Text="" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        div1222<div class="bm_clt_ctl_100_50 border_" style="width: 20%;">
                                                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                 div13<div style="float: left; margin-left: 40px">
                                                                     div131<div class="bm_ctl_container_100_50" style="width: 190px">
                                                                        div1311<div class="bm_ctl_label_align_center_100_50" style="width: 100%">
                                                                            <asp:Label ID="Label40" runat="server" Text="Total " AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                     div132<div class="bm_ctl_container_100_50" style="width: 190px; margin-top: 2px;">
                                                                        div1321<div class="bm_clt_ctl_100_50" style="width: 100%;">
                                                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox center_" Enabled="False"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            div2<div class="clear" style="margin-bottom: 10px"></div>
                                                            div3<div>
                                                                <div style="float: left">
                                                                    <div class="bm_ctl_container_100_50" style="width: 190px">
                                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 80%">
                                                                            <asp:Label ID="Label36" runat="server" Text="Maths :" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        <div class="bm_clt_ctl_100_50" style="width: 20%">
                                                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"
                                                                                Text="100" Enabled="False"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                     <div class="bm_ctl_container_100_50" style="width: 190px; margin-top: 2px; border: none;">
                                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 80%; background-color: inherit;">
                                                                            <asp:Label ID="Label37" runat="server" Text="" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        <div class="bm_clt_ctl_100_50 border_" style="width: 20%;">
                                                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div style="float: left; margin-left: 21px">
                                                                     <div class="bm_ctl_container_100_50" style="width: 190px">
                                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 80%">
                                                                            <asp:Label ID="Label38" runat="server" Text="General Knowledge :" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        <div class="bm_clt_ctl_100_50" style="width: 20%">
                                                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"
                                                                                Text="100" Enabled="False"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                     <div class="bm_ctl_container_100_50" style="width: 190px; margin-top: 2px; border: none;">
                                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 80%; background-color: inherit;">
                                                                            <asp:Label ID="Label39" runat="server" Text="" AssociatedControlID="xfather_res"
                                                                                CssClass="label"></asp:Label>
                                                                        </div>
                                                                        <div class="bm_clt_ctl_100_50 border_" style="width: 20%;">
                                                                            <asp:TextBox ID="TextBox8" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox" AutoPostBack="True"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>--%>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Information For Admission</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label57" runat="server" Text="Student ID :" AssociatedControlID="xstdid"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:TextBox ID="xstdid" runat="server" Enabled="False" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                <%--will be read only--%>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label32" runat="server" Text="Session :" AssociatedControlID="xsession_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:TextBox ID="xsession_admis" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label33" runat="server" Text="Student's Name :" AssociatedControlID="xname_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xname_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label34" runat="server" Text="Previous School :" AssociatedControlID="xpschool_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xpschool_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label35" runat="server" Text="Mother's Name :" AssociatedControlID="xmname_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xmname_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label36" runat="server" Text="Occupation :" AssociatedControlID="xprofession_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xprofession_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div class="bm_ctl_container_50_100" style="width: 28.5%; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 100%">
                                                    <asp:Label ID="Label37" runat="server" Text="Office Address :" AssociatedControlID="xoffadd"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 60%">
                                                <textarea id="xoffadd" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                                    style="width: 400px; height: 50px;" runat="server"></textarea>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label38" runat="server" Text="Cell No :" AssociatedControlID="xcellno"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xcellno" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label39" runat="server" Text="Mail ID :" AssociatedControlID="xmailid"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xmailid" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label40" runat="server" Text="Father's Name :" AssociatedControlID="xfname_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xfname_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label42" runat="server" Text="Occupation :" AssociatedControlID="xprofession1_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xprofession1_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div class="bm_ctl_container_50_100" style="width: 28.5%; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 100%">
                                                    <asp:Label ID="Label43" runat="server" Text="Office Address :" AssociatedControlID="xoffadd1"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 60%">
                                                <textarea id="xoffadd1" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                                    style="width: 400px; height: 50px;" runat="server"></textarea>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label44" runat="server" Text="Cell No :" AssociatedControlID="xcellno1"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xcellno1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                   ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label45" runat="server" Text="Mail ID :" AssociatedControlID="xmailid1"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xmailid1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label47" runat="server" Text="Class :" AssociatedControlID="xclass_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:TextBox ID="xclass_admis" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label74" runat="server" Text="Group :" AssociatedControlID="xgroup_admis"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xgroup_admis" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label48" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                    CssClass="label mendatory"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label49" runat="server" Text="Admission Date :" AssociatedControlID="xadmitdate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xadmitdate" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label50" runat="server" Text="Marks Obtained :" AssociatedControlID="xmarks_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xmarks_admis" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label51" runat="server" Text="Date of Birth :" AssociatedControlID="xdob_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xdob_admis" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"
                                                   Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="lblAge1" runat="server" Text="Age (1st July) :" AssociatedControlID="xage_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xage_admis" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"
                                                   Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label53" runat="server" Text="Nationality :" AssociatedControlID="xnation_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xnation_admis" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label55" runat="server" Text="Religion :" AssociatedControlID="xreligion_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xreligion_admis" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label56" runat="server" Text="Gender :" AssociatedControlID="xgender_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xgender_admis" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"
                                                    Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label46" runat="server" Text="Present Address :" AssociatedControlID="xpadd_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xpadd_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label58" runat="server" Text="Permanent Address :" AssociatedControlID="xperadd_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xperadd_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                   ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100" style="display: none">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label59" runat="server" Text="Mobile :" AssociatedControlID="xcontact_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xcontact_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label72" runat="server" Text="Land Phone :" AssociatedControlID="xphone_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xphone_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label60" runat="server" Text="Email :" AssociatedControlID="xemail1_admis"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="xemail1_admis" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"
                                                   ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                         <div style="width: 100%;">
                                            <div class="bm_ctl_container_50_100" style="width: 28.5%; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 100%">
                                                    <asp:Label ID="Label73" runat="server" Text="Active? " AssociatedControlID="zactive"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 60%">
                                                <asp:CheckBox ID="zactive" runat="server" />
                                            </div>
                                        </div>
                                        

                                        <div class="bm_clt_padding">
                                        </div>
                                        <%--Control section end--%>
                                        <br>
                                        <br>
                                    </div>
                                </div>
                                <div class="clear">
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="bm_layout_box_100">
                                            <div class="bm_layout_box_padding">
                                                <h3>
                                                    Image Upload
                                                </h3>
                                                <hr style="border: 2px solid">
                                                <br>
                                                <div style="width: 100%;">
                                                    <div style="float: left; margin-right: 20px; margin-left: 20px">
                                                        <div>
                                                            <table style="border: none;">
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center; border: 1px solid #00ced1">
                                                                        Student
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="image1"
                                                                            OnCheckedChanged="fnImageCheckedChanged" Text="Upload" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="image1" Text="Capture"
                                                                            OnCheckedChanged="fnImageCheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <asp:Image ID="ximagelink_admis" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image"
                                                                runat="server" Height="200px" Width="200px" /></div>
                                                        <div id="Div1" style="margin-top: 3px; font-size: 12px; color: #FF0000;" runat="server">
                                                        </div>
                                                        <div style="margin-top: 10px;">
                                                            <asp:FileUpload ID="FileUpload2" runat="server" Width="170px" />
                                                            <asp:ImageButton ID="ImageButton6" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                                runat="server" OnClick="ImageButton6_Click" Width="30px" />
                                                        </div>
                                                    </div>
                                                    <div style="float: left; margin-right: 20px">
                                                        <div>
                                                            <table style="border: none;">
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center; border: 1px solid #00ced1">
                                                                        Mother
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton3" runat="server" Checked="True" GroupName="image2"
                                                                            OnCheckedChanged="fnImageCheckedChanged" Text="Upload" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="image2" Text="Capture"
                                                                            OnCheckedChanged="fnImageCheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <asp:Image ID="xmimagelink" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image"
                                                                runat="server" Height="200px" Width="200px" /></div>
                                                        <div id="Div2" style="margin-top: 3px; font-size: 12px; color: #FF0000;" runat="server">
                                                        </div>
                                                        <div style="margin-top: 10px;">
                                                            <asp:FileUpload ID="FileUpload4" runat="server" Width="170px" />
                                                            <asp:ImageButton ID="ImageButton4" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                                runat="server" OnClick="ImageButton4_Click" Width="30px" />
                                                        </div>
                                                    </div>
                                                    <div style="float: left; margin-right: 20px">
                                                        <div>
                                                            <table style="border: none;">
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center; border: 1px solid #00ced1">
                                                                        Father
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton5" runat="server" Checked="True" GroupName="image3"
                                                                            OnCheckedChanged="fnImageCheckedChanged" Text="Upload" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton6" runat="server" GroupName="image3" Text="Capture"
                                                                            OnCheckedChanged="fnImageCheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <asp:Image ID="xfimagelink" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image"
                                                                runat="server" Height="200px" Width="200px" /></div>
                                                        <div id="Div3" style="margin-top: 3px; font-size: 12px; color: #FF0000;" runat="server">
                                                        </div>
                                                        <div style="margin-top: 10px;">
                                                            <asp:FileUpload ID="FileUpload5" runat="server" Width="170px" />
                                                            <asp:ImageButton ID="ImageButton5" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                                runat="server" OnClick="ImageButton5_Click" Width="30px" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br>
                                                <br>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="ImageButton4" />
                                        <asp:PostBackTrigger ControlID="ImageButton5" />
                                        <asp:PostBackTrigger ControlID="ImageButton6" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="clear">
                                </div>
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <h3>
                                            Other Information's
                                        </h3>
                                        <hr style="border: 2px solid">
                                    </div>
                                </div>
                            </div>
                            <%-- Left layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding" style="margin-left: 60px">
                                        <%--Control section start--%>
                                        <%-- <div style="width: 100%">
                                            <div class="bm_ctl_container_50_40" style="float: left">
                                                <div class="bm_ctl_label_align_right_50_40">
                                                    <asp:Label ID="Label61" runat="server" Text="Blood Group :" AssociatedControlID="DropDownList2"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_40">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="bm_academic_dropdown_50_40 bm_academic_ctl_global bm_academic_dropdown">
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>AB</asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="bm_ctl_container_50_40" style="float: left; margin-left: 10px">
                                                <div class="bm_ctl_label_align_right_50_40">
                                                    <asp:Label ID="Label62" runat="server" Text="Using Spectacles :" AssociatedControlID="DropDownList2"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_40">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="bm_academic_dropdown_50_40 bm_academic_ctl_global bm_academic_dropdown">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_80" style="width: 82%;border: none">
                                            <div class="bm_ctl_label_align_right_50_80" style="width: 85.8%;background-color: inherit">
                                                <asp:Label ID="Label63" runat="server" Text="Has the child suffered from any serious diesease? "
                                                    AssociatedControlID="DropDownList2" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80 border_ " style="width: 14.2%">
                                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                         <div class="bm_ctl_container_50_80" style="width: 29.8%;border: none ">
                                            <div class="bm_ctl_label_align_right_50_80" style="width: 100%;background-color: inherit">
                                                <asp:Label ID="Label64" runat="server" Text="Mention in Details : "
                                                    AssociatedControlID="DropDownList2" CssClass="label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div  style="margin-left:70px ">
                                            
                                                <textarea id="Textarea2" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                                    style="width: 340px; height: 50px;" runat="server"></textarea>
                                           
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_80" style="width: 82%">
                                            <div class="bm_ctl_label_align_right_50_80" style="width: 85.8%">
                                                <asp:Label ID="Label65" runat="server" Text="Has the child undergone any serious operation? "
                                                    AssociatedControlID="DropDownList2" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80" style="width: 14.2%">
                                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                         <div class="bm_ctl_container_50_80" style="width: 29.8%">
                                            <div class="bm_ctl_label_align_right_50_80" style="width: 100%">
                                                <asp:Label ID="Label66" runat="server" Text="Mention in Details : "
                                                    AssociatedControlID="DropDownList2" CssClass="label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div  style="margin-left:70px ">
                                            
                                                <textarea id="Textarea3" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                                    style="width: 340px; height: 50px;" runat="server"></textarea>
                                           
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>--%>
                                        <table style="width: 80%; border: none; font-family: Myriad Pro,tahoma; color: #000000;
                                            font-size: 14px;">
                                            <tr>
                                                <td>
                                                    Blood Group :
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xblood" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    Using Spectacles :
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xq1" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    Has the child suffered any serious disease?
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xq2" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    Mention in details :
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div style="margin-left: 50px">
                                                        <textarea id="xq2d" class="bm_academic_textarea_50_100  bm_academic_textarea" style="width: 340px;
                                                            height: 70px;" runat="server"></textarea>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    Has the child undergone any serious operation?
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xq3" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    Mention in details :
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div style="margin-left: 50px">
                                                        <textarea id="xq3d" class="bm_academic_textarea_50_100  bm_academic_textarea" style="width: 340px;
                                                            height: 70px;" runat="server"></textarea>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Left layout side end--%>
                            <%-- Right layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <table style="width: 60%; border: none; font-family: Myriad Pro,tahoma; color: #000000;
                                            font-size: 14px;">
                                            <tr>
                                                <td>
                                                    Number of childern in the family :
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:TextBox ID="xnumchild" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Childern's position in order of age :
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:TextBox ID="xchildpos" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Number of siblings in Presidency :
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:TextBox ID="xsibling" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Is the child alergic to any food?
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xq4" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Is the child alergic to any medicine?
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xq5" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Dose the child need any medicine like inhaler regulerly in the class?
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xq6" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Will the Child avail school transport?
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_80" style="width: 60px; border: none">
                                                        <div class="bm_clt_ctl_50_80 border_" style="width: 100%">
                                                            <asp:DropDownList ID="xq7" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Right layout side end--%>
                            <div class="clear">
                            </div>
                            <div class="bm_layout_box_100">
                                <div class="bm_layout_box_padding">
                                    <h3>
                                        Driver Information's
                                    </h3>
                                    <hr style="border: 2px solid">
                                </div>
                            </div>
                            <%-- Left layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label61" runat="server" Text="Driver Name :" AssociatedControlID="xname_driver"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="xname_driver" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label62" runat="server" Text="Cell No :" AssociatedControlID="xcellno_driver"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="xcellno_driver" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label63" runat="server" Text="National ID :" AssociatedControlID="xnid_driver"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="xnid_driver" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div class="bm_ctl_container_50_100" style="width: 28.5%; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 100%">
                                                    <asp:Label ID="Label64" runat="server" Text="Present Address :" AssociatedControlID="xpadd_driver"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 60%">
                                                <textarea id="xpadd_driver" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                                    style="width: 285px; height: 80px;" runat="server"></textarea>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div class="bm_ctl_container_50_100" style="width: 28.5%; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 100%">
                                                    <asp:Label ID="Label65" runat="server" Text="Permanent Address :" AssociatedControlID="xperadd_driver"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 60%">
                                                <textarea id="xperadd_driver" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                                    style="width: 285px; height: 80px;" runat="server"></textarea>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Left layout side end--%>
                            <%-- Right layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div style="width: 100%">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div style="float: left; margin-right: 20px; margin-left: 20px">
                                                        <div>
                                                            <table style="border: none;">
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center; border: 1px solid #00ced1">
                                                                        Driver
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton7" runat="server" Checked="True" GroupName="image5"
                                                                            OnCheckedChanged="fnImageCheckedChanged" Text="Upload" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="width: 100px">
                                                                        <asp:RadioButton ID="RadioButton8" runat="server" GroupName="image5" Text="Capture"
                                                                            OnCheckedChanged="fnImageCheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <asp:Image ID="ximage" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image"
                                                                runat="server" Height="200px" Width="200px" /></div>
                                                        <div id="Div4" style="margin-top: 3px; font-size: 12px; color: #FF0000;" runat="server">
                                                        </div>
                                                        <div style="margin-top: 10px;">
                                                            <asp:FileUpload ID="FileUpload3" runat="server" Width="170px" />
                                                            <asp:ImageButton ID="ImageButton2" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                                runat="server" OnClick="ImageButton2_Click" Width="30px" />
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="ImageButton2" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Right layout side end--%>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Official Information</HeaderTemplate>
                        <ContentTemplate>
                            <%-- Left layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Left layout side end--%>
                            <%-- Right layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Right layout side end--%>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </div>
            <div class="bm_academic_container_body_button_section">
                <div class="button_section_padding">
                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                    <div class="button_section_style" style="display: inline-block; width: 78%; text-align: left;
                        padding-left: 500px">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button bm_am_btn_save"
                            OnClick="btnSave_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Update" CssClass="bm_academic_button bm_am_btn_edit"
                            OnClick="btnEdit_Click" />
                            <asp:Button ID="btnRevised" runat="server" Text="Revised" CssClass="bm_academic_button bm_am_btn_refresh"
                            OnClientClick="fnRevisedConfrim();" OnClick="btnRevised_Click"/>
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button bm_am_btn_refresh"
                            OnClick="btnRefresh_Click" />
                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="bm_academic_button bm_am_btn_refresh"
                            Visible="False" OnClientClick="fnPrintAdmit();" />
                        <%-- <input id="btnSave" type="button" value="Save" class="bm_academic_button bm_am_btn_save" />
                        <input id="btnEdit" type="button" value="Edit" class="bm_academic_button bm_am_btn_edit" />--%>
                        <%--<input id="btnPrint"  type="button" value="Print" class="bm_academic_button bm_am_btn_refresh" onclick="fnPrintAdmit();" />--%>
                    </div>
                    <div style="display: inline-block; width: 20%; padding-left: 130px">
                        <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/images/pdf.png" Width="30px"
                            Height="30px" CssClass="bm_academic_button_zoom" OnClick="fnExportToPdf" />
                        <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/images/word.png" Width="30px"
                            Height="30px" CssClass="bm_academic_button_zoom" OnClick="fnExportToWord" />
                        <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/images/excel.png"
                            Width="30px" Height="30px" CssClass="bm_academic_button_zoom" OnClick="fnExportToExcel" />
                    </div>
                    <%--</ContentTemplate>
                     </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
        <div class="bm_academic_grid_container" id="list_res" runat="server" style="padding: 0px">
            <%-- <div class="grid_header">
                        <div class="grid_header_label" id="_grid_header_res" runat="server">
                            Info. For Admission Test
                        </div>
                        
                        <div class="flot_right" style="margin-top: 5px">
                            
                            <asp:Button ID="Button1" runat="server"  Text="UPDATE" CssClass="bttn"
                                   OnClick="btnEdit_Click" />
                        </div>
                    </div>--%>
            <div class="grid_body" style="padding: 0px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound">
                    <Columns>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
       <ContentTemplate>
        <div class="bm_academic_container_footer">
            <div class="footer_list_padding">
                <div class="bm_academic_grid_container" id="list" runat="server">
                    <div class="grid_header">
                        <div class="grid_header_label" id="_grid_header" runat="server">
                            Info. For Admission Test
                        </div>
                        <div class="grid_header_control">
                            <div class="grid_ctl_padding" style="margin-left: 70px">
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
                                
                                 <div style="float: left; color: #800000; font-weight: bold;">
                                     <asp:CheckBox ID="chkIsPassed" runat="server" Text="Passed in Admission Test" AutoPostBack="True" OnCheckedChanged="fnFillDataGrid"/>
                                </div>

                            </div>
                        </div>
                        <div class="flot_right">
                            <%-- <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>--%>
                            <div class="grid_header_row">
                                <asp:TextBox ID="_gridrow" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                    OnTextChanged="fnFilterByRow"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="grid_body">
                        <asp:GridView ID="_grid_admis_test" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="SL#">
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
    <ItemTemplate >
        <%# Container.DataItemIndex + 1 %>
    </ItemTemplate>
</asp:TemplateField>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                            OnClick="FillControls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="xname" HeaderText="Student's Name" ItemStyle-Width="250px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xexamroll" HeaderText="Exam Roll" ItemStyle-Width="50px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xexamdate" HeaderText="Exam Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xexamvenue" HeaderText="Exam Vanue" ItemStyle-Width="220px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xcontact" HeaderText="Contact No." ItemStyle-Width="270px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xgender" HeaderText="Gender" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-CssClass="pad5" />
                                 <asp:BoundField DataField="xstdid" HeaderText="Student's ID" ItemStyle-Width="80px"  ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-CssClass="pad5" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="_grid_admis_res" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                            OnClick="FillControls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xname" HeaderText="Student's Name" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xexamroll" HeaderText="Exam Roll" ItemStyle-Width="200px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xexamdate" HeaderText="Exam Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xexamvenue" HeaderText="Exam Vanue" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xcontact" HeaderText="Contact No." ItemStyle-Width="200px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="_grid_admis_stdinfo" runat="server" AutoGenerateColumns="False"
                            ShowFooter="true" CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle"
                            FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                            OnClick="FillControls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xstdid" HeaderText="Student ID" ItemStyle-Width="200px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xname" HeaderText="Student's Name" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xmname" HeaderText="Mother's Name" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xfname" HeaderText="Father's Name" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xcontact" HeaderText="Contact No." ItemStyle-Width="200px"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
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
    <asp:HiddenField ID="getActiveTabIndex" runat="server" />
    <asp:HiddenField ID="_row" runat="server" />
    <asp:HiddenField ID="_glob_zid" runat="server" />
    <asp:HiddenField ID="type" runat="server" />
    <asp:HiddenField ID="flag" runat="server" />
    <asp:HiddenField ID="_student" runat="server" />
    <asp:HiddenField ID="_stdimageurl" runat="server" />
    <asp:HiddenField ID="_row_global" runat="server" />
    <asp:HiddenField ID="xrevisedst" runat="server" />
</asp:Content>
