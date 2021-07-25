﻿<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="teacher_old1.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.teacher_old1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .bm_academic_tab_250 .ajax__tab_tab
        {
            color: #949599;
            width: 260px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //alert("Hi!");
            //alert("<%= HttpContext.Current.Session["business"] %>");
            //$('.bm_academic_datepicker').attr('placeholder', 'DD/MM/YYYY');
            //ns.dp_placeholder();



            $('.bm_am_btn_save').click(function () {
                var mendatoryFields = [
                    { "id": "<%= xemp.ClientID%>", "prop": "text", "tab": "0" },
                    { "id": "<%= xname.ClientID%>", "prop": "text", "tab": "0" },
                    { "id": "<%= xcontact.ClientID%>", "prop": "text", "tab": "0" },
                    { "id": "<%= getActiveTabIndex.ClientID%>", "prop": "tab", "tab": "-1" }
                ];
                var mendatoryString = JSON.stringify(mendatoryFields);
                if (!fnMendatoryFields(mendatoryString)) {
                    return false;
                }


                return true;
            });

            $('.bm_am_btn_edit').click(function () {
                var getActiveTab = $("#<%= getActiveTabIndex.ClientID%>").val();

                var mendatoryFields = [
                                { "id": "<%= xemp.ClientID%>", "prop": "text", "tab": "0" },
                    { "id": "<%= xname.ClientID%>", "prop": "text", "tab": "0" },
                    { "id": "<%= xcontact.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= getActiveTabIndex.ClientID%>", "prop": "tab", "tab": "-1" }
                                ];
                var mendatoryString = JSON.stringify(mendatoryFields);
                if (!fnMendatoryFields(mendatoryString)) {
                    return false;
                }


                return true;
            });

            $('.bm_academic_list').click(function () {
                //                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

              $("#<%= rdoCapture.ClientID %>").click(function () {
                //$("#<%= FileUpload1.ClientID%>").css('visibility', 'hidden');
                //$("#<%= ImageButton3.ClientID%>").css('visibility', 'hidden');
                fnImageCapture(<%= HttpContext.Current.Session["business"] %>,'~/images/profile/teacher/',$("#<%= ximage.ClientID%>").attr("ID"),$("#<%= _teacherimageurl.ClientID%>").attr("ID"),$("[id$='_row']").val(),"teacher");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label1" id="header_label" runat="server">
                <span class="bm_am_header_round">Teacher's Profile</span>
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
                <%-----THIS IS MESSAGE SECTION-----%>
            </div>
        </div>
        <div style="width: 100%; margin-top: 5px; margin-bottom: 5px; border: 1px solid #1e90ff;
            padding: 5px; text-align: center">
            <font style="font-weight: bold; color: #0000cd">Teacher's ID :</font>
            <asp:Label ID="xempd" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label><span
                style="margin-left: 15px;"></span> <font style="font-weight: bold; color: #0000cd">Teacher's
                    Name :</font>
            <asp:Label ID="xnamed" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label><span
                style="margin-left: 15px;"></span>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="bm_academic_tab_250 bm_am_tab1"
                    Height="750px" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="True"
                    ScrollBars="Auto">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Personal Information</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_60">
                                    <div class="bm_layout_box_padding">
                                        <div class="bm_ctl_container_60_50">
                                            <div class="bm_ctl_label_align_right_60_50">
                                                <asp:Label ID="Label79" runat="server" Text="Teacher's ID :" AssociatedControlID="xemp"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_50">
                                                <asp:TextBox ID="xemp" runat="server" CssClass="bm_academic_textbox_60_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label59" runat="server" Text="Name :" AssociatedControlID="xname"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div class="float_left" style="width: 50%;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label51" runat="server" Text="Date of Birth :" AssociatedControlID="xdob"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:TextBox ID="xdob" runat="server" CssClass="bm_academic_textbox_60_100_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="float_left" style="width: 48%; margin-left: 13px;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label49" runat="server" Text="Nationality :" AssociatedControlID="xnationality"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:DropDownList ID="xnationality" runat="server" CssClass="bm_academic_dropdown_60_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div class="float_left" style="width: 50%;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label1" runat="server" Text="National ID :" AssociatedControlID="xnid"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:TextBox ID="xnid" runat="server" CssClass="bm_academic_textbox_60_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="float_left" style="width: 30%; margin-left: 13px;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label2" runat="server" Text="Blood Group :" AssociatedControlID="xblood"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:DropDownList ID="xblood" runat="server" CssClass="bm_academic_dropdown_60_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="float_left" style="width: 15%; margin-left: 20px;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label3" runat="server" Text="Sex :" AssociatedControlID="xsex" CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:DropDownList ID="xsex" runat="server" CssClass="bm_academic_dropdown_60_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label54" runat="server" Text="Father's Name :" AssociatedControlID="xfather"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xfather" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label4" runat="server" Text="Mother's Name :" AssociatedControlID="xmother"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xmother" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <%--<div class="bm_ctl_container_60_50">
                                            <div class="bm_ctl_label_align_right_60_50">
                                                <asp:Label ID="Label5" runat="server" Text="Number of Siblings :" AssociatedControlID="xnosibling"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_50">
                                                <asp:TextBox ID="xnosibling" runat="server" CssClass="bm_academic_textbox_60_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <div style="width: 100%;">
                                            <div class="float_left" style="width: 50%;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label5" runat="server" Text="Number of Siblings :" AssociatedControlID="xnosibling"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:TextBox ID="xnosibling" runat="server" CssClass="bm_academic_textbox_60_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="float_left" style="width: 48%; margin-left: 13px;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label80" runat="server" Text="Religion :" AssociatedControlID="xreligion"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:DropDownList ID="xreligion" runat="server" CssClass="bm_academic_dropdown_60_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label6" runat="server" Text="Present Address :" AssociatedControlID="xpadd"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xpadd" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label7" runat="server" Text="Permanent Address :" AssociatedControlID="xperadd"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xperadd" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label8" runat="server" Text="Contact Number :" AssociatedControlID="xcontact"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xcontact" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label44" runat="server" Text="Emergency Contact :" AssociatedControlID="xecontact"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xecontact" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="float_left" style="width: 65%;">
                                                <div class="bm_ctl_container_60_100" style="width: 100%">
                                                    <div class="bm_ctl_label_align_right_60_100" style="width: 36.8%">
                                                        <asp:Label ID="Label65" runat="server" Text="Contact Name :" AssociatedControlID="xeconname"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100" style="width: 63.2%">
                                                        <asp:TextBox ID="xeconname" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="float_left" style="width: 33.5%; margin-left: 10px;">
                                                <div class="bm_ctl_container_60_100" style="width: 100%">
                                                    <div class="bm_ctl_label_align_right_60_100" style="width: 30%">
                                                        <asp:Label ID="Label66" runat="server" Text="Relation :" AssociatedControlID="xeconrelation"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100" style="width: 70%">
                                                        <asp:TextBox ID="xeconrelation" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label62" runat="server" Text="Facebook ID :" AssociatedControlID="xfbid"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xfbid" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label46" runat="server" Text="Email :" AssociatedControlID="xemail1"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xemail1" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label63" runat="server" Text="Hobbies :" AssociatedControlID="xhobbies"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xhobbies" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label64" runat="server" Text="Extra-curriculam Activity :" AssociatedControlID="xexactivity"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xexactivity" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%;">
                                            <div class="float_left" style="width: 50%;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label47" runat="server" Text="Marital Status :" AssociatedControlID="xmstatus"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:DropDownList ID="xmstatus" runat="server" CssClass="bm_academic_dropdown_60_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="float_left" style="width: 48%; margin-left: 13px;">
                                                <div class="bm_ctl_container_60_100_50">
                                                    <div class="bm_ctl_label_align_right_60_100_50">
                                                        <asp:Label ID="Label48" runat="server" Text="Marriage Day :" AssociatedControlID="xmday"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100_50">
                                                        <asp:TextBox ID="xmday" runat="server" CssClass="bm_academic_textbox_60_100_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label50" runat="server" Text="Spouse Name :" AssociatedControlID="xspouse"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xspouse" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label53" runat="server" Text="Spouse's Occupation :" AssociatedControlID="xsocupation"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="xsocupation" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_50">
                                            <div class="bm_ctl_label_align_right_60_50">
                                                <asp:Label ID="Label55" runat="server" Text="Number of Childrens :" AssociatedControlID="xnochild"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_50">
                                                <asp:TextBox ID="xnochild" runat="server" CssClass="bm_academic_textbox_60_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="bm_ctl_container_dynamic_60_100">
                                                    <div class="bm_ctl_container_dynamic_60_100_l_50">
                                                        <div class="bm_ctl_label_align_left_dynamic_60_100_l" style="padding-left: 25px;">
                                                            <asp:Label ID="Label56" runat="server" Text="Name, Academic Institution & Class :"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                        Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton1_Click" />
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div style="width: 100%;" id="placeholder" runat="server">
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
                                        <div class="bm_clt_padding">
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="bm_ctl_container_dynamic_60_100">
                                                    <div class="bm_ctl_container_dynamic_60_100_l_50">
                                                        <div class="bm_ctl_label_align_left_dynamic_60_100_l" style="padding-left: 25px;">
                                                            <asp:Label ID="Label58" runat="server" Text="Tour in Abroad: Country Name & Year :"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                    <asp:ImageButton ID="ImageButton2" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                        Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton2_Click" />
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div style="width: 100%;" id="placeholder1" runat="server">
                                                    <%--<div class="bm_ctl_container_dynamic_100_80_nl">
                                                        <asp:Label ID="Label60" runat="server" Text="1." CssClass="label"></asp:Label>
                                                    </div>
                                                   
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 320px">
                                                        <asp:TextBox ID="TextBox17" runat="server" Style="width: 316px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                     <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 204px">
                                                        <asp:TextBox ID="TextBox16" runat="server" Style="width: 200px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>--%>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="bm_layout_box_40">
                                    <div class="bm_layout_box_padding">
                                        <%--<div style="text-align: center;">
                                            <div>
                                                <asp:Image ID="ximage" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image"
                                                    runat="server" Height="300px" Width="300px" /></div>
                                            <div id="ErrorMsg" style="margin-top: 3px; text-align: center;" runat="server">
                                            </div>
                                            <div style="margin-top: 10px;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                <asp:ImageButton ID="ImageButton3" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                    runat="server" OnClick="ImageButton3_Click" />
                                            </div>
                                        </div>
                                        <div style="margin-top: 20px; margin-left: 80px;">
                                            <b>Instruction</b>
                                            <ol type="1">
                                                <li>Only support jpg,jpeg,bmp,png image.</li>
                                                <li>Maximum image size 100KB.</li>
                                                <li>Image dimension must be 300x300 pixel.</li>
                                            </ol>
                                        </div>--%>
                                        <div style="width: 100%; padding-left: 35px">
                                            <asp:Panel ID="Panel1" runat="server">
                                                <div style="float: left;">
                                                    <div>
                                                        <table style="border: none;">
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:RadioButton ID="rdoUpload" runat="server" Checked="True" GroupName="image" OnCheckedChanged="fnImageCheckedChanged"
                                                                        Text="Upload" AutoPostBack="True" />
                                                                </td>
                                                                <td style="width: 100px">
                                                                    <asp:RadioButton ID="rdoCapture" runat="server" GroupName="image" Text="Capture"
                                                                        OnCheckedChanged="fnImageCheckedChanged" AutoPostBack="True" CssClass="teacherimagecapture" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div>
                                                        <asp:Image ID="ximage" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image"
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
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Educational Informations</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div style="width: 60%; margin: 0 auto">
                                            <div id="school" runat="server">
                                                <fieldset>
                                                    <legend>Primary</legend>
                                                    <div style="width: 100%;">
                                                        <div class="float_left" style="width: 70%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_50">
                                                                    <asp:Label ID="Label10" runat="server" Text="School's Name :" AssociatedControlID="xorg_pri"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50">
                                                                    <asp:TextBox ID="xorg_pri" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 28%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_20" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_20" style="width: 29%;">
                                                                    <asp:Label ID="Label12" runat="server" Text="District" AssociatedControlID="xdist_pri"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_20" style="width: 71%;">
                                                                    <asp:DropDownList ID="xdist_pri" runat="server" CssClass="bm_academic_dropdown_100_20 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                                <fieldset>
                                                    <legend>Secondery</legend>
                                                    <div style="width: 100%;">
                                                        <div class="float_left" style="width: 70%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_50">
                                                                    <asp:Label ID="Label9" runat="server" Text="School's Name :" AssociatedControlID="xorg"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50">
                                                                    <asp:TextBox ID="xorg" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 28%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_20" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_20" style="width: 29%;">
                                                                    <asp:Label ID="Label11" runat="server" Text="District" AssociatedControlID="xdist"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_20" style="width: 71%;">
                                                                    <asp:DropDownList ID="xdist" runat="server" CssClass="bm_academic_dropdown_100_20 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 70%">
                                                        <div class="bm_ctl_label_align_right_100_50">
                                                            <asp:Label ID="Label34" runat="server" Text="Education System :" AssociatedControlID="xedusys"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50">
                                                            <asp:DropDownList ID="xedusys" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 70%">
                                                        <div class="bm_ctl_label_align_right_100_50">
                                                            <asp:Label ID="Label23" runat="server" Text="Name of Exam :" AssociatedControlID="xexamname_sec"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50">
                                                            <asp:DropDownList ID="xexamname_sec" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 70%;">
                                                        <div class="float_left" style="width: 60%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 48.2%;">
                                                                    <asp:Label ID="Label13" runat="server" Text="Education Board :" AssociatedControlID="xboard"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 51.8%;">
                                                                    <asp:DropDownList ID="xboard" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 37.8%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 36%">
                                                                    <asp:Label ID="Label14" runat="server" Text="Group :" AssociatedControlID="xedugroup"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 64%">
                                                                    <asp:DropDownList ID="xedugroup" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 100%;">
                                                        <div style="width: 70%; float: left">
                                                            <div class="float_left" style="width: 60%;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 48%;">
                                                                        <asp:Label ID="Label15" runat="server" Text="Passing Year :" AssociatedControlID="xyear"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 52%;">
                                                                        <asp:DropDownList ID="xyear" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="float_left" style="width: 37.8%; margin-left: 10px;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 36%">
                                                                        <asp:Label ID="Label16" runat="server" Text="Div/GPA" AssociatedControlID="xgpa_s"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 64%">
                                                                        <asp:DropDownList ID="xgpa_s" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div style="width: 30%; float: left">
                                                            <div style="width: 50%; margin-left: 10px; float: left" id="xpoints_div" runat="server">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                    <div class="bm_ctl_label_align_right_100_20" style="width: 50%;">
                                                                        <asp:Label ID="Label17" runat="server" Text="Point :" AssociatedControlID="xpoint_s"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_20" style="width: 50%;">
                                                                        <asp:TextBox ID="xpoint_s" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 70%;">
                                                        <div class="float_left" style="width: 37%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 79%;">
                                                                    <asp:Label ID="Label18" runat="server" Text="Number of Subjects" AssociatedControlID="xnumsub"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 21%;">
                                                                    <asp:TextBox ID="xnumsub" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 21%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 70%;">
                                                                    <asp:Label ID="Label19" runat="server" Text="No. of A+" AssociatedControlID="xnaa"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 30%;">
                                                                    <asp:TextBox ID="xnaa" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 11%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 50%;">
                                                                    <asp:Label ID="Label21" runat="server" Text="A" AssociatedControlID="xna" CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 50%;">
                                                                    <asp:TextBox ID="xna" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 11%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 50%;">
                                                                    <asp:Label ID="Label20" runat="server" Text="B" AssociatedControlID="xnb" CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 50%;">
                                                                    <asp:TextBox ID="xnb" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 11%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 50%;">
                                                                    <asp:Label ID="Label22" runat="server" Text="C" AssociatedControlID="xnc" CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 50%;">
                                                                    <asp:TextBox ID="xnc" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                                <fieldset>
                                                    <legend>Higher Secondery</legend>
                                                    <div style="width: 100%;">
                                                        <div class="float_left" style="width: 70%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_50">
                                                                    <asp:Label ID="Label24" runat="server" Text="College's Name :" AssociatedControlID="xorg_high"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50">
                                                                    <asp:TextBox ID="xorg_high" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 28%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_20" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_20" style="width: 29%;">
                                                                    <asp:Label ID="Label25" runat="server" Text="District" AssociatedControlID="xdist_high"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_20" style="width: 71%;">
                                                                    <asp:DropDownList ID="xdist_high" runat="server" CssClass="bm_academic_dropdown_100_20 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 70%">
                                                        <div class="bm_ctl_label_align_right_100_50">
                                                            <asp:Label ID="Label26" runat="server" Text="Education System :" AssociatedControlID="xedusys_high"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50">
                                                            <asp:DropDownList ID="xedusys_high" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 70%">
                                                        <div class="bm_ctl_label_align_right_100_50">
                                                            <asp:Label ID="Label27" runat="server" Text="Name of Exam :" AssociatedControlID="xexamname_high"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50">
                                                            <asp:DropDownList ID="xexamname_high" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 70%;">
                                                        <div class="float_left" style="width: 60%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 48.2%;">
                                                                    <asp:Label ID="Label28" runat="server" Text="Education Board :" AssociatedControlID="xboard_high"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 51.8%;">
                                                                    <asp:DropDownList ID="xboard_high" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 37.8%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 36%">
                                                                    <asp:Label ID="Label29" runat="server" Text="Group :" AssociatedControlID="xedugroup_high"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 64%">
                                                                    <asp:DropDownList ID="xedugroup_high" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 100%;">
                                                        <div style="width: 70%; float: left">
                                                            <div class="float_left" style="width: 60%;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 48%;">
                                                                        <asp:Label ID="Label30" runat="server" Text="Passing Year :" AssociatedControlID="xyear_high"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 52%;">
                                                                        <asp:DropDownList ID="xyear_high" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="float_left" style="width: 37.8%; margin-left: 10px;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 36%">
                                                                        <asp:Label ID="Label31" runat="server" Text="Div/GPA" AssociatedControlID="xgpa_high"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 64%">
                                                                        <asp:DropDownList ID="xgpa_high" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>First Division</asp:ListItem>
                                                                            <asp:ListItem>GPA</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div style="width: 30%; float: left">
                                                            <div style="width: 50%; margin-left: 10px; float: left" id="Div1" runat="server">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                    <div class="bm_ctl_label_align_right_100_20" style="width: 50%;">
                                                                        <asp:Label ID="Label32" runat="server" Text="Point :" AssociatedControlID="xpoint_high"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_20" style="width: 50%;">
                                                                        <asp:TextBox ID="xpoint_high" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 70%;">
                                                        <div class="float_left" style="width: 37%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 79%;">
                                                                    <asp:Label ID="Label33" runat="server" Text="Number of Subjects" AssociatedControlID="xnumsub_high"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 21%;">
                                                                    <asp:TextBox ID="xnumsub_high" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 21%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 70%;">
                                                                    <asp:Label ID="Label35" runat="server" Text="No. of A+" AssociatedControlID="xnaa_high"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 30%;">
                                                                    <asp:TextBox ID="xnaa_high" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 11%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 50%;">
                                                                    <asp:Label ID="Label36" runat="server" Text="A" AssociatedControlID="xna_high" CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 50%;">
                                                                    <asp:TextBox ID="xna_high" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 11%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 50%;">
                                                                    <asp:Label ID="Label37" runat="server" Text="B" AssociatedControlID="xnb_high" CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 50%;">
                                                                    <asp:TextBox ID="xnb_high" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 11%; margin-left: 10px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 50%;">
                                                                    <asp:Label ID="Label38" runat="server" Text="C" AssociatedControlID="xnc_high" CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 50%;">
                                                                    <asp:TextBox ID="xnc_high" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                            </div>
                                            <div id="graduateschool" runat="server">
                                                <fieldset>
                                                    <legend>Graduation</legend>
                                                    <div style="width: 100%;">
                                                        <div class="float_left" style="width: 75%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                                    <asp:Label ID="Label39" runat="server" Text="Graduation Under/From " AssociatedControlID="xunderorg"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                                    <asp:TextBox ID="xunderorg" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 24%; margin-left: 5px;">
                                                            <div class="bm_ctl_container_100_20" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_20" style="width: 38%;">
                                                                    <asp:Label ID="Label40" runat="server" Text="Country " AssociatedControlID="xcountry"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_20" style="width: 62%;">
                                                                    <asp:TextBox ID="xcountry" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%;">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%;">
                                                            <asp:Label ID="Label41" runat="server" Text="University/ College :" AssociatedControlID="xorggs"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%;">
                                                            <asp:TextBox ID="xorggs" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                            <asp:Label ID="Label43" runat="server" Text="Name of Degree :" AssociatedControlID="xexamname_gra"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                            <asp:DropDownList ID="xexamname_gra" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                            <asp:Label ID="Label45" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                            <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 100%;">
                                                        <div style="width: 75%; float: left">
                                                            <div class="float_left" style="width: 55%;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 56.8%;">
                                                                        <asp:Label ID="Label52" runat="server" Text="Passing Year :" AssociatedControlID="xyeargs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 43.2%;">
                                                                        <asp:DropDownList ID="xyeargs" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="float_left" style="width: 43%; margin-left: 9.9px;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 40%">
                                                                        <asp:Label ID="Label57" runat="server" Text="Class/GPA :" AssociatedControlID="xgpa_gs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 60%">
                                                                        <asp:DropDownList ID="xgpa_gs" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>First Division</asp:ListItem>
                                                                            <asp:ListItem>GPA</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div style="width: 16%; float: left" id="xpoints_divgs" runat="server">
                                                            <div class="float_left" style="width: 100%; margin-left: 5px;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                    <div class="bm_ctl_label_align_right_100_20" style="width: 60%;">
                                                                        <asp:Label ID="Label60" runat="server" Text="Point :" AssociatedControlID="xpoint_gs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_20" style="width: 40%;">
                                                                        <asp:TextBox ID="xpoint_gs" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 75%;">
                                                        <div class="float_left" style="width: 55%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 56.8%;">
                                                                    <asp:Label ID="Label42" runat="server" Text="Course Duration :" AssociatedControlID="xduration"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 43.2%;">
                                                                    <asp:DropDownList ID="xduration" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 43%; margin-left: 9.9px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 40%">
                                                                    <asp:Label ID="Label61" runat="server" Text="Position :" AssociatedControlID="xposition"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 60%">
                                                                    <asp:DropDownList ID="xposition" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                                <%--  <fieldset>
                                                    <legend>Post Graduation</legend>
                                                    <div style="width: 100%;">
                                                        <div class="float_left" style="width: 75%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                                    <asp:Label ID="Label62" runat="server" Text="Graduation Under/From " AssociatedControlID="xunderorg"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 24%; margin-left: 5px;">
                                                            <div class="bm_ctl_container_100_20" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_20" style="width: 38%;">
                                                                    <asp:Label ID="Label63" runat="server" Text="Country " AssociatedControlID="xcountry"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_20" style="width: 62%;">
                                                                    <asp:TextBox ID="TextBox10" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%;">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%;">
                                                            <asp:Label ID="Label64" runat="server" Text="University/ College :" AssociatedControlID="xorggs"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%;">
                                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                            <asp:Label ID="Label65" runat="server" Text="Name of Degree :" AssociatedControlID="xexamname_gra"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                            <asp:DropDownList ID="DropDownList7" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                            <asp:Label ID="Label66" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                            <asp:DropDownList ID="DropDownList8" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 100%;">
                                                        <div style="width: 75%; float: left">
                                                            <div class="float_left" style="width: 55%;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 56.8%;">
                                                                        <asp:Label ID="Label67" runat="server" Text="Passing Year :" AssociatedControlID="xyeargs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 43.2%;">
                                                                        <asp:DropDownList ID="DropDownList9" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="float_left" style="width: 43%; margin-left: 9.9px;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 40%">
                                                                        <asp:Label ID="Label68" runat="server" Text="Class/GPA :" AssociatedControlID="xgpa_gs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 60%">
                                                                        <asp:DropDownList ID="DropDownList10" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown"
                                                                          >
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div style="width: 16%; float: left" id="Div2" runat="server">
                                                            <div class="float_left" style="width: 100%; margin-left: 5px;">
                                                                <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                    <div class="bm_ctl_label_align_right_100_20" style="width: 60%;">
                                                                        <asp:Label ID="Label69" runat="server" Text="Point :" AssociatedControlID="xpoint_gs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_20" style="width: 40%;">
                                                                        <asp:TextBox ID="TextBox12" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 75%;">
                                                        <div class="float_left" style="width: 55%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 56.8%;">
                                                                    <asp:Label ID="Label70" runat="server" Text="Course Duration :" AssociatedControlID="xduration"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 43.2%;">
                                                                    <asp:DropDownList ID="DropDownList11" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 43%; margin-left: 9.9px;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 40%">
                                                                    <asp:Label ID="Label71" runat="server" Text="Position :" AssociatedControlID="xposition"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 60%">
                                                                    <asp:DropDownList ID="DropDownList12" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>--%>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                            <asp:ImageButton ID="ImageButton4" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                                Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton4_Click" />
                                                        </div>
                                                        <div class="bm_clt_padding" style="padding-bottom: 0px; padding-top: 0px">
                                                        </div>
                                                        <div id="placeholder3" runat="server" style="width: 100%;">
                                                            <%-- <fieldset>
                                                    <legend>Post Graduation</legend>
                                                    <div style="width: 100%;">
                                                        <div class="float_left" style="width: 75%;">
                                                            <div class="bm_ctl_container_100_50" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                                    <asp:Label ID="Label81" runat="server" Text="Graduation Under/From " AssociatedControlID="xunderorg"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                                    <asp:TextBox ID="TextBox13" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 24%; margin-left: 5px;">
                                                            <div class="bm_ctl_container_100_20" style="width: 100%;">
                                                                <div class="bm_ctl_label_align_right_100_20" style="width: 38%;">
                                                                    <asp:Label ID="Label82" runat="server" Text="Country " AssociatedControlID="xcountry"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_20" style="width: 62%;">
                                                                    <asp:TextBox ID="TextBox14" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%;">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%;">
                                                            <asp:Label ID="Label83" runat="server" Text="University/ College :" AssociatedControlID="xorggs"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%;">
                                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                            <asp:Label ID="Label84" runat="server" Text="Name of Degree :" AssociatedControlID="xexamname_gra"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                            <asp:DropDownList ID="DropDownList13" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_100_50" style="width: 75%">
                                                        <div class="bm_ctl_label_align_right_100_50" style="width: 31%">
                                                            <asp:Label ID="Label85" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_50" style="width: 69%">
                                                            <asp:DropDownList ID="DropDownList14" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 100%;">9
                                                        <div style="width: 75%; float: left">91
                                                            <div class="float_left" style="width: 55%;">911
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">9111
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 56.8%;">91111
                                                                        <asp:Label ID="Label86" runat="server" Text="Passing Year :" AssociatedControlID="xyeargs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 43.2%;">91112
                                                                        <asp:DropDownList ID="DropDownList15" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="float_left" style="width: 43%; margin-left: 9.9px;">912
                                                                <div class="bm_ctl_container_100_50" style="width: 100%">9121
                                                                    <div class="bm_ctl_label_align_right_100_50" style="width: 40%">91211
                                                                        <asp:Label ID="Label87" runat="server" Text="Class/GPA :" AssociatedControlID="xgpa_gs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_50" style="width: 60%">91212
                                                                        <asp:DropDownList ID="DropDownList16" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown"
                                                                            OnTextChanged="fnDivGPA_gs" AutoPostBack="True">
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>First Division</asp:ListItem>
                                                                            <asp:ListItem>GPA</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div style="width: 16%; float: left" id="Div3" runat="server" visible="False">92
                                                            <div class="float_left" style="width: 100%; margin-left: 5px;">921
                                                                <div class="bm_ctl_container_100_50" style="width: 100%;">9211
                                                                    <div class="bm_ctl_label_align_right_100_20" style="width: 60%;">92111
                                                                        <asp:Label ID="Label88" runat="server" Text="Point :" AssociatedControlID="xpoint_gs"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_100_20" style="width: 40%;">92112
                                                                        <asp:TextBox ID="TextBox16" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div style="width: 75%;">_1
                                                        <div class="float_left" style="width: 55%;">_11
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">_111
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 56.8%;">_1111
                                                                    <asp:Label ID="Label89" runat="server" Text="Course Duration :" AssociatedControlID="xduration"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 43.2%;">_1112
                                                                    <asp:DropDownList ID="DropDownList17" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="float_left" style="width: 43%; margin-left: 9.9px;">_12
                                                            <div class="bm_ctl_container_100_50" style="width: 100%">_121
                                                                <div class="bm_ctl_label_align_right_100_50" style="width: 40%">_1211
                                                                    <asp:Label ID="Label90" runat="server" Text="Position :" AssociatedControlID="xposition"
                                                                        CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_clt_ctl_100_50" style="width: 60%">_1212
                                                                    <asp:DropDownList ID="DropDownList18" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>--%>
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
                            Training/ Courses/ Experiances
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding" style="margin-top: 0px;">
                                        <%--Control section start--%>
                                        <div style="width: 50%; margin: 0 auto">
                                            <%-- <div class="bm_ctl_container_60_50" style="width: 220px">
                                                <div class="bm_ctl_label_align_left_60_50" style="width: 100%">
                                                    <asp:Label ID="Label67" runat="server" Text="Training/ Courses/ Workshop " 
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">
                                            </div>--%>
                                            <h3>
                                                Training/ Courses/ Workshop
                                            </h3>
                                            <hr style="border: 2px solid">
                                            <br>
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <div class="bm_ctl_container_dynamic_100_80_imgbtn" style="margin: 0px">
                                                        <asp:ImageButton ID="ImageButton5" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                            Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton5_Click" />
                                                    </div>
                                                    <div class="bm_clt_padding" style="padding: 0px;">
                                                    </div>
                                                    <div id="placeholder4" runat="server" style="width: 100%;">
                                                        <%--  <fieldset>
                                                <legend>Training 1</legend>
                                            <div class="bm_ctl_container_50_100">1
                                                <div class="bm_ctl_label_align_right_50_100">11
                                                    <asp:Label ID="Label72" runat="server" Text="Name of the Training :" AssociatedControlID="xname_train"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100">12
                                                    <asp:TextBox ID="xname_train" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">2
                                            </div>
                                            <div class="bm_ctl_container_50_100">3
                                                <div class="bm_ctl_label_align_right_50_100">31
                                                    <asp:Label ID="Label73" runat="server" Text="Organized By :" AssociatedControlID="xorganised"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100">32
                                                    <asp:TextBox ID="xorganised" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">4
                                            </div>
                                            <div class="bm_ctl_container_50_100">5
                                                <div class="bm_ctl_label_align_right_50_100">51
                                                    <asp:Label ID="Label74" runat="server" Text="Vanue :" AssociatedControlID="xvanue"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100">52
                                                    <asp:TextBox ID="xvanue" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">6
                                            </div>
                                            <div class="bm_ctl_container_50_100">7
                                                <div class="bm_ctl_label_align_right_50_100">71
                                                    <asp:Label ID="Label75" runat="server" Text="Country :" AssociatedControlID="xcountry_train"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100">72
                                                    <asp:TextBox ID="xcountry_train" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">8
                                            </div>
                                            <div class="bm_ctl_container_50_100">9
                                                <div class="bm_ctl_label_align_right_50_100">91
                                                    <asp:Label ID="Label76" runat="server" Text="Trainer :" AssociatedControlID="xtrainer"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100">92
                                                    <asp:TextBox ID="xtrainer" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">01
                                            </div>
                                            <div style="width: 100%">02
                                                <div style="float: left; width: 50%;">021
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">0211
                                                        <div class="bm_ctl_label_align_right_50_50">02111
                                                            <asp:Label ID="Label77" runat="server" Text="Course Duration :" AssociatedControlID="xfdate_train"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50">02112
                                                            <asp:TextBox ID="xfdate_train" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 2%; margin-left: 10px; line-height: 1.8em;">022
                                                    to
                                                </div>
                                                <div style="float: left; width: 21%; margin-left: 1px;">023
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">0231
                                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">02311
                                                            <asp:TextBox ID="xtdate_train" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">03
                                            </div>
                                            <div class="bm_ctl_container_dynamic_100_80" style="width: 100%">04
                                                <div class="bm_ctl_container_dynamic_100_80_l" style="width: 28.8%">041
                                                    <div class="bm_ctl_label_align_right_dynamic_100_80_l">0411
                                                        <asp:Label ID="Label78" runat="server" Text="Description :" AssociatedControlID="xremarks_train"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="bm_clt_ctl_dynamic_100_80" style="width: 70%">042
                                                    <div class="_ctl_padding">0421
                                                        <textarea id="xremarks_train" class="bm_academic_textarea_100_50  bm_academic_textarea" style="width:380px"
                                                            runat="server"></textarea>
                                                    </div>
                                                </div>
                                            </div>
                                            </fieldset>--%>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <h3>
                                                Experiences
                                            </h3>
                                            <hr style="border: 2px solid">
                                            <br>
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <div class="bm_ctl_container_dynamic_100_80_imgbtn" style="margin: 0px">
                                                        <asp:ImageButton ID="ImageButton6" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                            Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton6_Click" />
                                                    </div>
                                                    <div class="bm_clt_padding" style="padding: 0px;">
                                                    </div>
                                                    <div id="placeholder5" runat="server" style="width: 100%;">
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Official Informations</HeaderTemplate>
                        <ContentTemplate>
                            <%-- Left layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div style="width: 45%; margin: 0 auto">
                                            <h3>
                                                Joining Information
                                            </h3>
                                            <hr style="border: 2px solid">
                                            <br>
                                            <div style="width: 100%">
                                                <div style="float: left; width: 50%;">
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 42%">
                                                            <asp:Label ID="Label68" runat="server" Text="Joining Position :" AssociatedControlID="xjposition"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 58%">
                                                            <asp:DropDownList ID="xjposition" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                
                                                <%--<div style="float: left; width: 2%; margin-left: 10px; line-height: 1.8em;">
                                                    to
                                                </div>--%>
                                                <div style="float: left; width: 48%; margin-left: 10px;">
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 42%">
                                                            <asp:Label ID="Label67" runat="server" Text="Joining Salary :" AssociatedControlID="xjsalary"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 58%">
                                                            <asp:TextBox ID="xjsalary" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">
                                            </div>
                                            <div style="width: 100%">
                                                 <div style="float: left; width: 50%;">
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 42%">
                                                            <asp:Label ID="Label69" runat="server" Text="School :" AssociatedControlID="xjschool"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 58%">
                                                            <asp:DropDownList ID="xjschool" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div style="float: left; width: 2%; margin-left: 10px; line-height: 1.8em;">
                                                    to
                                                </div>--%>
                                               
                                                 <div style="float: left; width: 48%; margin-left: 10px;">
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 42%">
                                                            <asp:Label ID="Label70" runat="server" Text="Class :" AssociatedControlID="xjclass"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 58%">
                                                            <asp:DropDownList ID="xjclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">
                                            </div>
                                            <div style="width: 100%">
                                               
                                                <div style="float: left; width: 50%;">
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 42%">
                                                            <asp:Label ID="Label71" runat="server" Text="Section :" AssociatedControlID="xjsection"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 58%">
                                                            <asp:DropDownList ID="xjsection" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div style="float: left; width: 2%; margin-left: 10px; line-height: 1.8em;">
                                                    to
                                                </div>--%>
                                                <div style="float: left; width: 48%; margin-left: 10px;">
                                                    <div class="bm_ctl_container_50_50" style="width: 100%;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 42%">
                                                            <asp:Label ID="Label77" runat="server" Text="Joining Date :" AssociatedControlID="xjdate"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 58%">
                                                            <asp:TextBox ID="xjdate" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                            <div class="bm_clt_padding">
                                            </div>
                                            <div style="width: 100%">
                                                <div style="width: 21.2%; float: left;">
                                                    <div class="bm_ctl_container_100_80" style="width: 100%;">
                                                        <div class="bm_ctl_label_align_right_100_80" style="width: 100%">
                                                            <asp:Label ID="Label72" runat="server" Text="Responsibilities :" AssociatedControlID="xjresponsibility"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <%--div class="bm_clt_ctl_100_80" style="width: 58%">
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="bm_academic_textbox_100_80 bm_academic_ctl_global bm_academic_textbox" TextMode="MultiLine"></asp:TextBox>
                                                    </div>--%>
                                                    </div>
                                                </div>
                                                <div style="width: 76.8%; float: left; margin-left: 10px;">
                                                    <div class="bm_ctl_container_100_80" style="width: 100%; border: none;">
                                                        <%-- <div class="bm_ctl_label_align_right_100_80" style="width: 100%">
                                                            <asp:Label ID="Label73" runat="server" Text="Responsibilities :" AssociatedControlID="xfdate_train"
                                                                CssClass="label"></asp:Label>
                                                        </div>--%>
                                                        <div class="bm_clt_ctl_100_80" style="width: 100%;">
                                                            <asp:TextBox ID="xjresponsibility" runat="server" CssClass="bm_academic_textbox_100_80 bm_academic_ctl_global bm_academic_textbox"
                                                                TextMode="MultiLine" Width="100%" Height="80px"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="margin-top: 100px">
                                                <h3>
                                                    Present Position Information
                                                </h3>
                                                <hr style="border: 2px solid">
                                                <br>
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <div class="bm_ctl_container_dynamic_100_80_imgbtn" style="margin: 0px">
                                                            <asp:ImageButton ID="ImageButton7" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                                Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton7_Click" />
                                                        </div>
                                                        <div class="bm_clt_padding" style="padding: 0px; border-bottom: solid 1px; margin-bottom: 10px;">
                                                        </div>
                                                        <div id="placeholder7" runat="server" style="width: 100%;">
                                                           <%-- <fieldset>--%>
                                                                <%--<legend>Training 1</legend>--%>
                                                                <%--<div style="width: 100%">1
                                                                    <div style="float: left; width: 50%;">11
                                                                        <div class="bm_ctl_container_50_50" style="width: 100%;">111
                                                                            <div class="bm_ctl_label_align_right_50_50" style="width: 42%">1111
                                                                                <asp:Label ID="Label75" runat="server" Text="Present Position :" AssociatedControlID="xposition"
                                                                                    CssClass="label"></asp:Label>
                                                                            </div>
                                                                            <div class="bm_clt_ctl_50_50" style="width: 58%">1112
                                                                                <asp:DropDownList ID="xposition" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div style="float: left; width: 48%; margin-left: 10px;">12
                                                                        <div class="bm_ctl_container_50_50" style="width: 100%;">121
                                                                            <div class="bm_ctl_label_align_right_50_50" style="width: 42%">1211
                                                                                <asp:Label ID="Label74" runat="server" Text="Present Salary :" AssociatedControlID="xfdate_train"
                                                                                    CssClass="label"></asp:Label>
                                                                            </div>
                                                                            <div class="bm_clt_ctl_50_50" style="width: 58%">1212
                                                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="bm_clt_padding">2
                                                                </div>
                                                                <div style="width: 100%">3
                                                                    <div style="float: left; width: 50%;">31
                                                                        <div class="bm_ctl_container_50_50" style="width: 100%;">311
                                                                            <div class="bm_ctl_label_align_right_50_50" style="width: 42%">3111
                                                                                <asp:Label ID="Label78" runat="server" Text="School :" AssociatedControlID="xfdate_train"
                                                                                    CssClass="label"></asp:Label>
                                                                            </div>
                                                                            <div class="bm_clt_ctl_50_50" style="width: 58%">3112
                                                                                <asp:DropDownList ID="DropDownList6" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div style="float: left; width: 48%; margin-left: 10px;">32
                                                                        <div class="bm_ctl_container_50_50" style="width: 100%;">321
                                                                            <div class="bm_ctl_label_align_right_50_50" style="width: 42%">3211
                                                                                <asp:Label ID="Label76" runat="server" Text="Class :" AssociatedControlID="xfdate_train"
                                                                                    CssClass="label"></asp:Label>
                                                                            </div>
                                                                            <div class="bm_clt_ctl_50_50" style="width: 58%">3212
                                                                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="bm_clt_padding">4
                                                                </div>
                                                                <div style="width: 100%">5
                                                                    <div style="float: left; width: 50%;">51
                                                                        <div class="bm_ctl_container_50_50" style="width: 100%;">511
                                                                            <div class="bm_ctl_label_align_right_50_50" style="width: 42%">5111
                                                                                <asp:Label ID="Label81" runat="server" Text="Section :" AssociatedControlID="xfdate_train"
                                                                                    CssClass="label"></asp:Label>
                                                                            </div>
                                                                            <div class="bm_clt_ctl_50_50" style="width: 58%">5112
                                                                                <asp:DropDownList ID="DropDownList7" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div style="float: left; width: 48%; margin-left: 10px;">52
                                                                        <div class="bm_ctl_container_50_50" style="width: 100%;">521
                                                                            <div class="bm_ctl_label_align_right_50_50" style="width: 42%">5211
                                                                                <asp:Label ID="Label73" runat="server" Text="From :" AssociatedControlID="xfdate_train"
                                                                                    CssClass="label"></asp:Label>
                                                                            </div>
                                                                            <div class="bm_clt_ctl_50_50" style="width: 58%">5212
                                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="bm_clt_padding">6
                                                                </div>
                                                                <div style="width: 100%">7
                                                                    <div style="width: 21.2%; float: left;">71
                                                                        <div class="bm_ctl_container_100_80" style="width: 100%;">711
                                                                            <div class="bm_ctl_label_align_right_100_80" style="width: 100%">7111
                                                                                <asp:Label ID="Label82" runat="server" Text="Responsibilities :" AssociatedControlID="xfdate_train"
                                                                                    CssClass="label"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div style="width: 76.8%; float: left; margin-left: 10px;">72
                                                                        <div class="bm_ctl_container_100_80" style="width: 100%; border: none;">721
                                                                            <div class="bm_clt_ctl_100_80" style="width: 100%;">7211
                                                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="bm_academic_textbox_100_80 bm_academic_ctl_global bm_academic_textbox"
                                                                                    TextMode="MultiLine" Width="100%" Height="80px"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div style="border-bottom: solid 1px; padding: 10px; clear: both;"></div>8--%>
                                                                
                                                         <%--   </fieldset>--%>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
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
                    <div class="button_section_style">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button bm_am_btn_save"
                            OnClick="btnSave_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Save" CssClass="bm_academic_button bm_am_btn_edit"
                            OnClick="btnEdit_Click" />
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button bm_am_btn_refresh"
                            OnClick="btnRefresh_Click" />
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
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div class="bm_academic_grid_container" id="list" runat="server">
                            <div class="grid_header">
                                <div class="grid_header_label" id="_grid_header" runat="server">
                                    Teacher Personal Information (Quick Contact) :
                                </div>
                                <div class="grid_header_control">
                                    <div class="grid_ctl_padding">
                                        <%--  <div class="bm_ctl_container_100_ses_grid">
                                    <div class="bm_ctl_label_align_right_100_ses_grid">
                                        <asp:Label ID="Label54" runat="server" Text="Class :" AssociatedControlID="grid_xlocation"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_ses_grid">
                                        <asp:DropDownList ID="grid_xlocation" AutoPostBack="True" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location"
                                            OnTextChanged="fnFillDataGrid">
                                        </asp:DropDownList>
                                    </div>
                                </div>--%>
                                    </div>
                                </div>
                                <div class="flot_right">
                                    <div class="grid_header_searchbox">
                                        <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"
                                            Width="300px" OnTextChanged="fnFilterByRow"></asp:TextBox>
                                    </div>
                                    <div class="grid_header_row">
                                        <asp:TextBox ID="_gridrow" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                            OnTextChanged="fnFilterByRow"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="grid_body">
                                <asp:GridView ID="_grid_teacherinfo_breakup" runat="server" AutoGenerateColumns="False"
                                    ShowFooter="true" CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle"
                                    FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="xemp" runat="server" Text='<%#Eval("xemp") %>' CssClass="_gridrow_link"
                                                    OnClick="FillControls"></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="xname" HeaderText="Teacher's Name" ItemStyle-Width="250px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xfather" HeaderText="Father's Name" ItemStyle-Width="250px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xcontact" HeaderText="Contact" ItemStyle-Width="200px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xemail1" HeaderText="Email" ItemStyle-Width="200px" ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xblood" HeaderText="Blood Group" ItemStyle-Width="100px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:GridView ID="_grid_education" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Row">
                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="xline" runat="server" Text='<%#Eval("xline") %>' CssClass="_gridrow_link"
                                                    OnClick="FillControls"></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="xexamname" HeaderText="Exam Name / Name of Degree" ItemStyle-Width="350px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xsubject" HeaderText="Group/Subject" ItemStyle-Width="350px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xorg" HeaderText="School/College/University" ItemStyle-Width="350px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xyear" HeaderText="Passing Year" ItemStyle-Width="120px"
                                            ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xresult" HeaderText="Result" ItemStyle-Width="100px" ItemStyle-CssClass="pad5" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="getActiveTabIndex" runat="server" />
    <asp:HiddenField ID="_row" runat="server" />
    <asp:HiddenField ID="type" runat="server" />
    <asp:HiddenField ID="_teacherimageurl" runat="server" />
</asp:Content>
