<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="teacher_coordi.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.teacher_coordi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .bm_academic_tab_250 .ajax__tab_tab {
            color: #949599;
            width: 215px;
        }

        .bm_paddiing_right {
            margin-right: 30px;
        }

        .disnone {
            display: none;
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

            $('.bm_teacher').click(function () {
                //alert("Hi");
                 fnOpenEMPList2(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),'teacher',$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });


        });

        function ConfirmMessage() {
            var selectedvalue = confirm("Do you want to delete data?");
            if (selectedvalue) {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
            }
        }

       

       

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
        <div style="width: 100%; margin-top: 5px; margin-bottom: 5px; border: 1px solid #1e90ff; padding: 5px; text-align: center">
            <font style="font-weight: bold; color: #0000cd">Teacher's ID :</font>
            <asp:Label ID="xempd" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label><span
                style="margin-left: 15px;"></span> <font style="font-weight: bold; color: #0000cd">Teacher's
                    Name :</font>
            <asp:Label ID="xnamed" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label><span
                style="margin-left: 15px;"></span><font style="font-weight: bold; color: #0000cd">Status :</font>
            <asp:Label ID="xstatusemph" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label><span
                style="margin-left: 15px;"></span>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="bm_academic_tab_250 bm_am_tab1"
                    Height="750px" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="True"
                    ScrollBars="Auto">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Personal Information
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_60">
                                    <div class="bm_layout_box_padding">
                                        <div style="width: 100%">
                                            <div style="float: left; width: 360px;">
                                                
                                                <div class="bm_ctl_container_60_100" >
                                                    <div class="bm_ctl_label_align_right_60_100" style="width:170px;">
                                                        <asp:Label ID="Label79" runat="server" Text="Teacher's ID :" AssociatedControlID="xemp"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_60_100" style="width: 185px;">
                                                        <div class="bm_list_text" style="width: 85%; float: left;">
                                                            <asp:TextBox ID="xemp" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox " AutoPostBack="True" OnTextChanged="FillControls"></asp:TextBox>
                                                        </div>
                                                        <div class="bm_list_img" style="float: left;">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_teacher" />
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div style="float: left; padding-left: 3px;">
                                                <asp:ImageButton ID="ImageButton8" ImageUrl="~/images/search32x32.png" runat="server"
                                                    CssClass="bm_academic_list" Width="25px" Height="25px" OnClick="FillControls"/>
                                            </div>

                                        </div>

                                        <div class="bm_clt_padding" style="padding-bottom: 0px;">
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
                                                            runat="server" Height="200px" Width="200px" />
                                                    </div>
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
                            Educational Informations
                        </HeaderTemplate>
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
                            Courses/ Experiences
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
                                            <h3>Training/ Courses/ Workshop
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
                                            <h3>Experiences
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
                            Job Position Informations
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100" style="padding-bottom: 0px;">
                                    <div class="bm_layout_box_padding">
                                        <h3>Joining Information
                                        </h3>
                                        <hr style="border: 2px solid">
                                        <br>
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_60_80" style="width: 300px; display: inline-block; margin-right: 10px;">
                                            <div class="bm_ctl_label_align_right_60_80" style="width: 37.8%">
                                                <asp:Label ID="Label74" runat="server" Text="Joining Position :" AssociatedControlID="xjposition_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80" style="width: 62.2%">
                                                <asp:DropDownList ID="xjposition_job" runat="server" CssClass="bm_academic_dropdown_60_80 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_60_80" style="width: 300px; display: inline-block; margin-right: 10px;">
                                            <div class="bm_ctl_label_align_right_60_80" style="width: 37.8%">
                                                <asp:Label ID="Label85" runat="server" Text="Joining School :" AssociatedControlID="xjschool_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80" style="width: 62.2%">
                                                <asp:DropDownList ID="xjschool_job" runat="server" CssClass="bm_academic_dropdown_60_80 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_60_80" style="width: 250px; display: inline-block">
                                            <div class="bm_ctl_label_align_right_60_80" style="width: 37.8%">
                                                <asp:Label ID="Label73" runat="server" Text="Joining Date :" AssociatedControlID="xjdate_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80" style="width: 62.2%">
                                                <asp:TextBox ID="xjdate_job" runat="server" CssClass="bm_academic_textbox_60_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100" style="padding-bottom: 0px;">
                                    <div class="bm_layout_box_padding">
                                        <h3>Job Position Information
                                        </h3>
                                        <hr style="border: 2px solid #007DC5">
                                        <br>
                                        <%--Control section start--%>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Left layout side start--%>

                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50" style="width: 23%;">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_60_80" style="width: 100%">
                                            <div class="bm_ctl_label_align_right_60_80">
                                                <asp:Label ID="Label67" runat="server" Text="Position :" AssociatedControlID="xposition_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80">
                                                <asp:DropDownList ID="xposition_job" runat="server" CssClass="bm_academic_dropdown_60_80 bm_academic_ctl_global bm_academic_dropdown" AutoPostBack="True" OnTextChanged="xposition_job_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_80" style="width: 100%" runat="server" id="xsubject_job_div">
                                            <div class="bm_ctl_label_align_right_60_80">
                                                <asp:Label ID="Label70" runat="server" Text="Subject :" AssociatedControlID="xsubject_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80">
                                                <asp:DropDownList ID="xsubject_job" runat="server" CssClass="bm_academic_dropdown_60_80 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_80" style="width: 100%">
                                            <div class="bm_ctl_label_align_right_60_80">
                                                <asp:Label ID="Label68" runat="server" Text="School :" AssociatedControlID="xschool_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80">
                                                <asp:DropDownList ID="xschool_job" runat="server" CssClass="bm_academic_dropdown_60_80 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <%--  <div class="bm_ctl_container_60_80" style="width: 24.5%">
                                            <div class="bm_ctl_label_align_right_60_80" style="width: 100%">
                                                <asp:Label ID="Label69" runat="server" Text="Class :" CssClass="label"></asp:Label>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_clt_padding">
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel2" runat="server" Height="180px" Width="421px">
                                                    <table class="style23">
                                                        <tr>
                                                            <td class="style30" rowspan="2" valign="top">
                                                                <asp:Label ID="Label70" runat="server" Font-Bold="True" Text="All Class's"></asp:Label>
                                                                <br />
                                                                <asp:ListBox ID="xclass_all" runat="server" Height="149px" SelectionMode="Multiple"
                                                                    Width="166px"></asp:ListBox>
                                                            </td>
                                                            <td align="center" class="style31" valign="bottom">
                                                                <asp:Button ID="btnforward" runat="server" Text="&gt;" Width="35px" onclick="btnforward_Click"/>
                                                            </td>
                                                            <td rowspan="2" valign="top">
                                                                <asp:Label ID="Label71" runat="server" Font-Bold="True" Text="Selected Class/'s"></asp:Label>
                                                                <br />
                                                                <asp:ListBox ID="xclass_job" runat="server" Height="149px" SelectionMode="Multiple"
                                                                    Width="166px"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="style31" valign="top">
                                                                <asp:Button ID="btnbackword" runat="server" Text="&lt;" Width="35px"  onclick="btnbackword_Click"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="bm_clt_padding">
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_60_80" style="width: 24.5%">
                                            <div class="bm_ctl_label_align_right_60_80" style="width: 100%">
                                                <asp:Label ID="Label72" runat="server" Text="Section :" CssClass="label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel3" runat="server" Height="120px" Width="421px">
                                                    <table class="style23">
                                                        <tr>
                                                            <td class="style30" rowspan="2" valign="top">
                                                                <asp:Label ID="Label73" runat="server" Font-Bold="True" Text="All Section's"></asp:Label>
                                                                <br />
                                                                <asp:ListBox ID="xsection_all" runat="server" Height="80px" SelectionMode="Multiple"
                                                                    Width="166px"></asp:ListBox>
                                                            </td>
                                                            <td align="center" class="style31" valign="bottom">
                                                                <asp:Button ID="btnforward1" runat="server" Text="&gt;" Width="35px" onclick="btnforward1_Click"/>
                                                            </td>
                                                            <td rowspan="2" valign="top">
                                                                <asp:Label ID="Label74" runat="server" Font-Bold="True" Text="Selected Section/'s"></asp:Label>
                                                                <br />
                                                                <asp:ListBox ID="xsection_job" runat="server" Height="80px" SelectionMode="Multiple"
                                                                    Width="166px"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="style31" valign="top">
                                                                <asp:Button ID="btnbackword1" runat="server" Text="&lt;" Width="35px" onclick="btnbackword1_Click"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                        <div class="bm_ctl_container_60_80" style="width: 80%;">
                                            <div class="bm_ctl_label_align_right_60_80" style="width: 37.8%">
                                                <asp:Label ID="Label76" runat="server" Text="From Date :" AssociatedControlID="xfdate_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80" style="width: 62.2%">
                                                <asp:TextBox ID="xfdate_job" runat="server" CssClass="bm_academic_textbox_60_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div style="width: 100%; display: none">
                                            <div style="width: 26.2%; float: left;">
                                                <div class="bm_ctl_container_60_40" style="width: 100%;">
                                                    <div class="bm_ctl_label_align_right_60_80" style="width: 100%">
                                                        <asp:Label ID="Label82" runat="server" Text="Responsibilities :" CssClass="label"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div style="width: 100%; display: none;">
                                            <%--<div style="width: 26.2%; float: left;">
                                                <div class="bm_ctl_container_60_40" style="width: 100%;">
                                                    <div class="bm_ctl_label_align_right_60_80" style="width: 100%">
                                                        <asp:Label ID="Label69" runat="server" Text="Responsibilities :" CssClass="label"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <div style="width: 96%; float: left; margin-left: 0px;">
                                                <div class="bm_ctl_container_100_80" style="width: 100%; border: none;">
                                                    <div class="bm_clt_ctl_100_80" style="width: 100%;">
                                                        <asp:TextBox ID="xrepons_job" runat="server" CssClass="bm_academic_textbox_100_80 bm_academic_ctl_global bm_academic_textbox"
                                                            TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="bm_clt_padding" style="padding-bottom: 15px;">
                                        </div>--%>
                                        <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <div style="width: 100%;">
                                                    <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                        <asp:ImageButton ID="ImageButton9" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                            Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton9_Click" />
                                                    </div>
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 17px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label77" runat="server" Text="#" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 184px; margin-right: 10px;
                                                    text-align: center;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label78" runat="server" Text="Subject" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 50px; margin-right: 10px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label81" runat="server" Text="Paper" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 130px; margin-right: 10px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label83" runat="server" Text="Class" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 130px">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label84" runat="server" Text="Section" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div style="width: 100%;" id="placeholder9" runat="server">--%>
                                        <%-- <div class="bm_ctl_container_dynamic_100_80_nl">
                                                        <asp:Label ID="Label157" runat="server" Text="1." CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 184px">
                                                        <asp:DropDownList ID="xsubject_job" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 50px">
                                                        <asp:DropDownList ID="xpaper_job" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 130px">
                                                        <asp:DropDownList ID="xclass_job1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 130px">
                                                        <asp:DropDownList ID="xsection_job1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>--%>
                                        <%-- </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>


                            </div>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50" style="width: 75%;">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <%-- <div class="bm_ctl_container_60_40" style="width: 50%">
                                            <div class="bm_ctl_label_align_right_60_40" style="width: 41.8%">
                                                <asp:Label ID="Label76" runat="server" Text="From Date:" AssociatedControlID="xfdate_job"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_40" style="width: 58.2%">
                                                <asp:TextBox ID="xfdate_job" runat="server" CssClass="bm_academic_textbox_60_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>--%>
                                        <%--<div style="width: 100%">
                                            <div style="width: 21.2%; float: left;">
                                                <div class="bm_ctl_container_60_40" style="width: 100%;">
                                                    <div class="bm_ctl_label_align_right_60_80" style="width: 100%">
                                                        <asp:Label ID="Label82" runat="server" Text="Responsibilities :" CssClass="label"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="width: 70%; float: left; margin-left: 10px;">
                                                <div class="bm_ctl_container_100_80" style="width: 100%; border: none;">
                                                    <div class="bm_clt_ctl_100_80" style="width: 100%;">
                                                        <asp:TextBox ID="xrepons_job" runat="server" CssClass="bm_academic_textbox_100_80 bm_academic_ctl_global bm_academic_textbox"
                                                            TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding" style="padding-bottom: 15px;">
                                        </div>--%>
                                        <%-- <div class="bm_academic_grid_container" id="Div2" runat="server">
                                            <div class="grid_header">
                                                <div class="grid_header_label" id="Div3" runat="server">
                                                    Position (Breakup) :
                                                </div>
                                                <div class="flot_right">
                                                    
                                                    <div class="grid_header_row">
                                                        <asp:TextBox ID="_gridrow1" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                                            OnTextChanged="fnFilterByRow"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="grid_body">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
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
                                                        <asp:BoundField DataField="xposition" HeaderText="Position" ItemStyle-CssClass="pad5" />
                                                        <asp:BoundField DataField="xfdate" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                        <asp:BoundField DataField="xtdate" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>--%>

                                        <div id="classsection" runat="server">
                                            <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 95%">
                                                <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                    <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                        <asp:Label ID="Label69" runat="server" Text="Class(s) & Section" CssClass="label"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="bm_clt_padding">
                                            </div>
                                            <div style="width: 95%;" id="hrclass" runat="server">
                                                <asp:CheckBoxList ID="xclasschk" runat="server" RepeatDirection="Horizontal" AutoPostBack="False" RepeatLayout="Table" CellSpacing="1" CellPadding="5" RepeatColumns="15" TextAlign="Right"></asp:CheckBoxList>
                                            </div>

                                            <div class="bm_clt_padding">
                                            </div>
                                            <%--<div class="bm_clt_padding">
                                            </div>

                                            <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 95%; border: none; background-color: inherit;">
                                                <div class="bm_ctl_container_60_80" style="width: 100%; float: left; background-color: inherit; border: none;">
                                                    <div class="bm_ctl_label_align_center_60_80" style="width: 100%; background-color: inherit; border: none;">
                                                        <asp:Label ID="Label70" runat="server" Text="Section(s)" CssClass="label"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="bm_clt_padding">
                                            </div>
                                            <div style="border-bottom: 1px solid black;"></div>
                                            <div style="width: 95%;" id="Div2" runat="server">--%>
                                            <%--<asp:CheckBoxList ID="xsectionchk" runat="server" RepeatDirection="Horizontal" AutoPostBack="False" RepeatLayout="Table" CellSpacing="5" CellPadding="5" RepeatColumns="9"></asp:CheckBoxList>--%>
                                            <asp:RadioButtonList ID="xsectionrdo" runat="server" RepeatDirection="Horizontal" AutoPostBack="False" RepeatLayout="Table" CellSpacing="5" CellPadding="5" RepeatColumns="9"></asp:RadioButtonList>
                                            <%--</div>

                                            <div class="bm_clt_padding">
                                            </div>--%>
                                        </div>

                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>

                            <div style="clear: both;"></div>
                            <div runat="server" id="otherpos">
                                <div class="bm_layout_container">
                                    <div class="bm_layout_box_100" style="padding-bottom: 0px; padding-top: 0px;">
                                        <div class="bm_layout_box_padding">
                                            <h3>Other Position(s)
                                            </h3>
                                            <hr style="border: 2px solid">
                                            <br>
                                            <%--Control section start--%>
                                            <%--Control section end--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="bm_layout_container" style="margin-bottom: 0px;">
                                    <div class="bm_layout_box_100" style="padding-top: 0px;">
                                        <div class="bm_layout_box_padding" style="padding-top: 0px;">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <div style="width: 100%;">
                                                        <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                            <asp:ImageButton ID="ImageButton7" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                                Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton7_Click" />
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 17px;">
                                                        <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                            <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                                <asp:Label ID="Label71" runat="server" Text="#" CssClass="label"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 250px; margin-right: 10px; text-align: center;">
                                                        <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                            <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                                <asp:Label ID="Label72" runat="server" Text="Position" CssClass="label"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%--<div class="bm_ctl_container_dynamic_100_80_nl" style="width: 50px; margin-right: 10px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label73" runat="server" Text="Paper" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                                    <%--<div class="bm_ctl_container_dynamic_100_80_nl" style="width: 130px; margin-right: 10px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label74" runat="server" Text="Class" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                                    <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 850px">
                                                        <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                            <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                                <asp:Label ID="Label75" runat="server" Text="Class(s) & Section" CssClass="label"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>

                                                    <div style="width: 100%;" id="placeholder7" runat="server">
                                                        <%-- <div style="width: 100%;" id="Div2" runat="server">
                                                        <div class="bm_ctl_container_dynamic_100_80_nl" style="margin-right: 12px">
                                                            <asp:Label ID="Label157" runat="server" Text="1." CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 250px;">
                                                            <asp:DropDownList ID="xposition_job" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div style="width: 850px; border: none; margin-right: 10px; float: left;">
                                                            <div>
                                                                <asp:CheckBoxList ID="xclasschk" runat="server" RepeatDirection="Horizontal" AutoPostBack="False" RepeatLayout="Table" CellSpacing="1" CellPadding="5" RepeatColumns="15" TextAlign="Right"></asp:CheckBoxList>
                                                            </div>
                                                            <div>
                                                                <asp:RadioButtonList ID="xsectionrdo" runat="server" RepeatDirection="Horizontal" AutoPostBack="False" RepeatLayout="Table" CellSpacing="5" CellPadding="5" RepeatColumns="9"></asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                        <div class="bm_clt_padding">
                                                        </div>
                                                        <hr />
                                                    </div>--%>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <%-- Left layout side end--%>
                            <%-- Right layout side start--%>

                            <div style="clear: both;"></div>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100" style="padding-bottom: 0px; padding-top: 0px;">
                                    <div class="bm_layout_box_padding">
                                        <h3>Subject Allocation (If Required)
                                        </h3>
                                        <hr style="border: 2px solid">
                                        <br>
                                        <%--Control section start--%>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100" style="padding-top: 0px;">
                                    <div class="bm_layout_box_padding" style="padding-top: 0px;">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <div style="width: 100%;">
                                                    <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                        <asp:ImageButton ID="ImageButton9" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                            Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton9_Click" />
                                                    </div>
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 17px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label77" runat="server" Text="#" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 184px; margin-right: 10px; text-align: center;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label78" runat="server" Text="Subject" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 50px; margin-right: 10px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label81" runat="server" Text="Paper" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 130px; margin-right: 10px;">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label83" runat="server" Text="Class" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 62%">
                                                    <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                        <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                            <asp:Label ID="Label84" runat="server" Text="Section(s)" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div style="width: 100%;" id="placeholder9" runat="server">
                                                    <%-- <div class="bm_ctl_container_dynamic_100_80_nl">
                                                        <asp:Label ID="Label157" runat="server" Text="1." CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 184px">
                                                        <asp:DropDownList ID="xsubject_job" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 50px">
                                                        <asp:DropDownList ID="xpaper_job" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 130px">
                                                        <asp:DropDownList ID="xclass_job1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 130px">
                                                        <asp:DropDownList ID="xsection_job1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>--%>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <%-- Right layout side end--%>
                        </ContentTemplate>
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Official Informations
                        </HeaderTemplate>
                        <ContentTemplate>

                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100" style="padding-bottom: 0px;">
                                    <div class="bm_layout_box_padding">
                                        <h3>Employment Information
                                        </h3>
                                        <hr style="border: 2px solid">
                                        <br>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div class="bm_ctl_container_60_100" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_60_100" style="width: 120px">
                                                            <asp:Label ID="Label89" runat="server" Text="Join Salary :" AssociatedControlID="xjsalary"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_60_100" style="width: 148px">
                                                            <asp:TextBox ID="xjsalary" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_50_50" style="float: left; width: 270px;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                            <asp:Label ID="Label90" runat="server" Text="Joining Date :" AssociatedControlID="xjdate"
                                                                CssClass="label "></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                            <asp:TextBox ID="xjdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label91" runat="server" Text="Department :" AssociatedControlID="xdept"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xdept" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label92" runat="server" Text="Designation :" AssociatedControlID="xdesig"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xdesig" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label93" runat="server" Text="Location :" AssociatedControlID="xlocation"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xlocation" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label94" runat="server" Text="Section :" AssociatedControlID="xsec"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xsec" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label95" runat="server" Text="Category :" AssociatedControlID="xcat"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xcat" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label96" runat="server" Text="Shift Code :" AssociatedControlID="xshift"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xshift" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label98" runat="server" Text="Pay Type :" AssociatedControlID="xpaytyp"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xpaytyp" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label99" runat="server" Text="Salary Scale :" AssociatedControlID="xpsclcode"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xpsclcode" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label86" runat="server" Text="Employee Status :" AssociatedControlID="xstatusemp"
                                                                CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xstatusemp" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label97" runat="server" Text="Nature of Employment :" AssociatedControlID="xempnature"
                                                                CssClass="label" Font-Size="11px"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xempnature" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                            <tr>
                                                <td>
                                                    <div class="bm_ctl_container_50_50" style="float: left; width: 270px;">
                                                        <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                            <asp:Label ID="Label87" runat="server" Text=" Hold/Resign Eff. Date :" AssociatedControlID="xtemdate"
                                                                CssClass="label " Font-Size="12px"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                            <asp:TextBox ID="xtemdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="bm_ctl_container_100_special" style="width: 270px;">
                                                        <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                            <asp:Label ID="Label100" runat="server" Text="Provident Fund Eligibility" AssociatedControlID="xpfflag"
                                                                CssClass="label" Font-Size="11px"></asp:Label>
                                                        </div>
                                                        <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                            <asp:DropDownList ID="xpfflag" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>

                                            </tr>
                                            <%-- <div class="bm_clt_padding">
                                        </div>--%>

                                            <%--<div class="bm_clt_padding">
                                        </div>--%>
                                            <tr>
                                                <td>
                                                    <div style="width: 100%; text-align: left;">
                                                        <div class="bm_ctl_container_50_50" style="width: 120px; margin-bottom: 10px; margin-right: 10px; float: left;">
                                                            <div class="bm_ctl_label_align_right_50_50" style="width: 118px">
                                                                <asp:Label ID="Label88" runat="server" Text="Note :"
                                                                    CssClass="label "></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div style="width: 400px; float: left;">
                                                            <asp:TextBox ID="xdescst" runat="server" Height="80px" TextMode="MultiLine" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td></td>
                                            </tr>

                                            <%--<div class="bm_clt_padding">
                                        </div>--%>

                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="bm_academic_button5 bm_am_btn_save1"
                                                        OnClick="btnSave1_Click" /></td>
                                            </tr>
                                        </table>


                                        <br>
                                        <div style="display: none;">
                                            <h3>Pay Package</h3>
                                            <hr style="border: 2px solid">
                                            <br>

                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                                ShowFooter="true" CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle"
                                                FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None" Width="400px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Pay Code">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:LinkButton ID="xpaycode" runat="server" Text='<%#Eval("xpaycode") %>' CssClass="_gridrow_link"
                                                    OnClick="FillControls"></asp:LinkButton>--%>
                                                            <asp:Label ID="xpaycode" runat="server" Text='<%#Eval("xpaycode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="xdesc" HeaderText="Description" ItemStyle-Width="200px"
                                                        ItemStyle-CssClass="pad5" />

                                                    <asp:BoundField DataField="xamount" HeaderText="Amount" ItemStyle-Width="150px"
                                                        ItemStyle-CssClass="pad5" ItemStyle-HorizontalAlign="Right" />


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
                                        <asp:BoundField DataField="xblood" HeaderText="B/G" ItemStyle-Width="50px"
                                            ItemStyle-CssClass="pad5" ItemStyle-HorizontalAlign="Center" />

                                        <asp:BoundField DataField="xstatusemp" HeaderText="Status" ItemStyle-Width="100px"
                                            ItemStyle-CssClass="pad5" ItemStyle-HorizontalAlign="Center" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%>
                                            </ItemTemplate>
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
                                                <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="bm_academic_grid_container" id="position" runat="server">
                            <div class="grid_header">
                                <div class="grid_header_label" id="Div3" runat="server">
                                    Position (Breakup) :
                                </div>
                                <div class="flot_right">
                                    <div class="grid_header_row">
                                        <asp:TextBox ID="_gridrow1" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                            OnTextChanged="fnFilterByRow"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="grid_body">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No">
                                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Row">
                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="xline" runat="server" Text='<%#Eval("xline") %>' CssClass="_gridrow_link"
                                                    OnClick="FillControls"></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Position">
                                            <ItemStyle Width="200px" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="xposition" runat="server" Text='<%#Eval("xposition") %>' CssClass="_gridrow_link"
                                                    OnClick="FillControls"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="xposition" HeaderText="Position" ItemStyle-CssClass="pad5" />--%>
                                        <asp:BoundField DataField="xfdate" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px" ItemStyle-CssClass="pad5" />
                                        <asp:BoundField DataField="xtdate" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px" ItemStyle-CssClass="pad5" />

                                        <asp:TemplateField FooterStyle-CssClass="disnone" HeaderStyle-CssClass="disnone">
                                            <ItemStyle CssClass="disnone" />
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="xline" HeaderText="xline" ItemStyle-CssClass="pad5" />

                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="xdelete" runat="server" Text="Delete" CssClass="_gridrow_link" OnClientClick="javascript:ConfirmMessage()"
                                                    OnClick="xdelete_OnClick"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemStyle />
                                            <ItemTemplate>
                                            </ItemTemplate>
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
    <asp:HiddenField ID="txtconformmessageValue" runat="server" />
</asp:Content>
