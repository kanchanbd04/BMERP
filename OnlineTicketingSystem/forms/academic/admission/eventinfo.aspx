<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="eventinfo.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.eventinfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //alert("Hi!");
            //alert("<%= HttpContext.Current.Session["business"] %>");
            //            $('.bm_academic_datepicker').attr('placeholder', 'DD/MM/YYYY');
            //ns.dp_placeholder();

            

            $('.bm_am_btn_save').click(function() {
                //var tabindex = document.getElementsByClassName(".bm_am_tab1");
//                alert($("#<%= getActiveTabIndex.ClientID%>").val());
//                return false;
                var getActiveTab = $("#<%= getActiveTabIndex.ClientID%>").val(); 
                var xconvenor_day_o = $("#<%= xconvenor_day_o.ClientID%>").val();
                var xprogramme_day_o = $("#<%= xprogramme_day_o.ClientID%>").val();
                //alert(xconvenor_day_o);

                var mendatoryFields = [
                    { "id": "<%= xsession_day_o.ClientID%>", "prop": "combo", "tab":"0" },
                    { "id": "<%= xlocation_day_o.ClientID%>", "prop": "combo", "tab":"0" },
                    { "id": "<%= xprogramme_day_o.ClientID%>", "prop": "combo", "tab":"0" },
                    { "id": "<%= xdate_day_o.ClientID%>", "prop": "text", "tab":"0" },
                    { "id": "<%= xsession_out.ClientID%>", "prop": "combo", "tab":"1" },
                    { "id": "<%= xlocation_out.ClientID%>", "prop": "combo", "tab":"1" },
                    { "id": "<%= xprogramme_out.ClientID%>", "prop": "combo", "tab":"1" },
                    { "id": "<%= xdate_out.ClientID%>", "prop": "text", "tab":"1" },
                    { "id": "<%= xsession_sport.ClientID%>", "prop": "combo", "tab":"2" },
                    { "id": "<%= xlocation_sport.ClientID%>", "prop": "combo", "tab":"2" },
                    { "id": "<%= xprogramme_sport.ClientID%>", "prop": "combo", "tab":"2" },
                    { "id": "<%= xdate_sport.ClientID%>", "prop": "text", "tab":"2" },
                    { "id": "<%= xsession_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xlocation_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xdate_exam.ClientID%>", "prop": "text", "tab":"3" },
                     { "id": "<%= xexam_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xclass_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xsession_others.ClientID%>", "prop": "combo", "tab":"4" },
                     { "id": "<%= xlocation_others.ClientID%>", "prop": "combo", "tab":"4" },
                     { "id": "<%= xname_others.ClientID%>", "prop": "combo", "tab":"4" },
                    { "id": "<%= getActiveTabIndex.ClientID%>", "prop": "tab", "tab":"-1" }
                ];
                var mendatoryString = JSON.stringify(mendatoryFields);
                if (!fnMendatoryFields(mendatoryString)) {
                    return false;
                }


                return true;
            });

            $('.bm_am_btn_edit').click(function() {
                var getActiveTab = $("#<%= getActiveTabIndex.ClientID%>").val(); 

                var mendatoryFields = [
                    { "id": "<%= xsession_day_o.ClientID%>", "prop": "combo", "tab":"0" },
                    { "id": "<%= xlocation_day_o.ClientID%>", "prop": "combo", "tab":"0" },
                    { "id": "<%= xprogramme_day_o.ClientID%>", "prop": "combo", "tab":"0" },
                    { "id": "<%= xdate_day_o.ClientID%>", "prop": "text", "tab":"0" },
                    { "id": "<%= xsession_out.ClientID%>", "prop": "combo", "tab":"1" },
                    { "id": "<%= xlocation_out.ClientID%>", "prop": "combo", "tab":"1" },
                    { "id": "<%= xprogramme_out.ClientID%>", "prop": "combo", "tab":"1" },
                    { "id": "<%= xdate_out.ClientID%>", "prop": "text", "tab":"1" },
                    { "id": "<%= xsession_sport.ClientID%>", "prop": "combo", "tab":"2" },
                    { "id": "<%= xlocation_sport.ClientID%>", "prop": "combo", "tab":"2" },
                    { "id": "<%= xprogramme_sport.ClientID%>", "prop": "combo", "tab":"2" },
                    { "id": "<%= xdate_sport.ClientID%>", "prop": "text", "tab":"2" },
                    { "id": "<%= xsession_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xlocation_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xdate_exam.ClientID%>", "prop": "text", "tab":"3" },
                     { "id": "<%= xexam_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xclass_exam.ClientID%>", "prop": "combo", "tab":"3" },
                     { "id": "<%= xsession_others.ClientID%>", "prop": "combo", "tab":"4" },
                     { "id": "<%= xlocation_others.ClientID%>", "prop": "combo", "tab":"4" },
                     { "id": "<%= xname_others.ClientID%>", "prop": "combo", "tab":"4" },
                    { "id": "<%= getActiveTabIndex.ClientID%>", "prop": "tab", "tab":"-1" }
                ];
                var mendatoryString = JSON.stringify(mendatoryFields);
                if (!fnMendatoryFields(mendatoryString)) {
                    return false;
                }


                return true;
            });

            $('.bm_convenor_day').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _convenor_day.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

              $('.bm_coconvenor_day').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _coconvenor_day.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_allconvenor_out').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _allconvenor_out.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_coconvenor_out').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _coconvenor_out.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_convenor_out').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _convenor_out.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_allconvenor_sport').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _allconvenor_sport.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_coconvenor_sport').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _coconvenor_sport.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

             $('.bm_convenor_exam').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _convenor_exam.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_convenor_other').click(function () {
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _convenor_other.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('._grid1').click(function() {
//                alert("Hi");
            });

//          document.getElementById('fff').style.backgroundColor = "#0000FF";
        });


        function colorChanged(sender) {
            //alert("Hi");
//  sender.get_element().style.color = 
//       "#" + sender.get_selectedColor();
        document.getElementById('fff').style.backgroundColor = "#" + sender.get_selectedColor();
//        document.getElementById('_colorvalue').value  = sender.get_selectedColor();
         // alert(sender.get_selectedColor().toString());
        }
           function colorChanged_out(sender) {
            //alert("Hi");
//  sender.get_element().style.color = 
//       "#" + sender.get_selectedColor();
        document.getElementById('cpout_sample').style.backgroundColor = "#" + sender.get_selectedColor();
        }

        function colorChanged_sport(sender) {
            //alert("Hi");
//  sender.get_element().style.color = 
//       "#" + sender.get_selectedColor();
        document.getElementById('cpsport_sample').style.backgroundColor = "#" + sender.get_selectedColor();
        }
         function colorChanged_exam(sender) {
            //alert("Hi");
//  sender.get_element().style.color = 
//       "#" + sender.get_selectedColor();
        document.getElementById('cpexam_sample').style.backgroundColor = "#" + sender.get_selectedColor();
        }
         function colorChanged_other(sender) {
            //alert("Hi");
//  sender.get_element().style.color = 
//       "#" + sender.get_selectedColor();
        document.getElementById('cpsport_other').style.backgroundColor = "#" + sender.get_selectedColor();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label" id="header_label" runat="server">
                EVENT MANAGEMENT
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
                <%-----THIS IS MESSAGE SECTION-----%>
            </div>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="bm_academic_tab bm_am_tab1"
                    Height="500px" ScrollBars="Auto" OnActiveTabChanged="TabContainer1_ActiveTabChanged"
                    AutoPostBack="True">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Days Observations</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_100_25 required">
                                            <div class="bm_ctl_label_align_right_100_25 label_bg">
                                                <asp:Label ID="Label1" runat="server" Text="Session :" AssociatedControlID="xsession_day_o"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:DropDownList ID="xsession_day_o" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_100_45 required" style="float: left">
                                                <div class="bm_ctl_label_align_right_100_45 label_bg">
                                                    <asp:Label ID="Label2" runat="server" Text="Programme's Name :" AssociatedControlID="xprogramme_day_o"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_100_45">
                                                    <asp:DropDownList ID="xprogramme_day_o" runat="server" CssClass="bm_academic_dropdown_100_45 bm_academic_ctl_global bm_academic_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div style="float: left; margin-left: 5px">
                                                <%--<asp:TextBox ID="cpday_sample" runat="server" ReadOnly="True"  CssClass="bm_cp_sample" BackColor="red"></asp:TextBox>--%>
                                                <div id="fff" class="bm_cp_sample" style="float: left; margin-right: 5px;">
                                                    <img alt="" src="/images/color-picker.png" width="26px" height="24px" style="border-radius: 2px;
                                                        border: solid 1px #BFBEBC;" id="cpday_s" />
                                                </div>
                                                <div style="float: left;">
                                                    <asp:TextBox ID="cpday_value" runat="server" CssClass="bm_cp_value" ViewStateMode="Enabled"></asp:TextBox></div>
                                                <cc1:ColorPickerExtender ID="cpeday" runat="server" TargetControlID="cpday_value"
                                                    PopupButtonID="cpday_s" SampleControlID="cpday_s" OnClientColorSelectionChanged="colorChanged"
                                                    ViewStateMode="Enabled" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" >
                                        </div>
                                        <div class="bm_ctl_container_100_30 required">
                                            <div class="bm_ctl_label_align_right_100_30 label_bg">
                                                <asp:Label ID="Label3" runat="server" Text="Will Be Observed In :" AssociatedControlID="xlocation_day_o"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:DropDownList ID="xlocation_day_o" runat="server" CssClass="bm_academic_dropdown_100_30 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30 required">
                                            <div class="bm_ctl_label_align_right_100_30 label_bg">
                                                <asp:Label ID="Label4" runat="server" Text="Observation Date :" AssociatedControlID="xdate_day_o"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="xdate_day_o" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label5" runat="server" Text="1st Seating :" AssociatedControlID="xfdate_day_o"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="xfdate_day_o" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30 required">
                                            <div class="bm_ctl_label_align_right_100_30 label_bg">
                                                <asp:Label ID="Label6" runat="server" Text="Convenor :" AssociatedControlID="xconvenor_day_o"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xconvenor_day_o" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_convenor_day" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label7" runat="server" Text="Co Convenor :" AssociatedControlID="xcoconvenor_day_o"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xcoconvenor_day_o" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_coconvenor_day" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="bm_ctl_container_dynamic_100_80">
                                                    <div class="bm_ctl_container_dynamic_100_80_l">
                                                        <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                            <asp:Label ID="Label44" runat="server" Text="Event's Name :" CssClass="label"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="bm_academic_imgbtn_add  bm_academic_button_zoom"
                                                            Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton1_Click" />
                                                    </div>
                                                    <div class="bm_clt_ctl_dynamic_100_80">
                                                        <div class="_ctl_padding" id="placeholder" runat="server">
                                                            <%--<div class="_ctl_container">
                                                                <div class="bm_ctl_container_dynamic_100_80_nl">
                                                                    <asp:Label ID="Label8" runat="server" Text="1." CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_ctl_container_dynamic_100_80_wol">
                                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                                </div>
                                                                <div class="bm_ctl_container_dynamic_100_80_wol">
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                        <asp:ListItem>[Select]</asp:ListItem>
                                                                        <asp:ListItem>Nursey</asp:ListItem>
                                                                        <asp:ListItem>Playgroup</asp:ListItem>
                                                                        <asp:ListItem>Class-l l</asp:ListItem>
                                                                        <asp:ListItem></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="bm_ctl_container_dynamic_100_80_nl">
                                                                    <asp:Label ID="Label9" runat="server" Text="to" CssClass="label"></asp:Label>
                                                                </div>
                                                                <div class="bm_ctl_container_dynamic_100_80_wol">
                                                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown">
                                                                        <asp:ListItem>[Select]</asp:ListItem>
                                                                        <asp:ListItem>Nursey</asp:ListItem>
                                                                        <asp:ListItem>Playgroup</asp:ListItem>
                                                                        <asp:ListItem>Class-l l</asp:ListItem>
                                                                        <asp:ListItem></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="bm_ctl_container_dynamic_100_80_wol">
                                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_datepicker_dynamic_100_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                                </div>
                                                            </div>--%>
                                                            <%--<table><tr><td>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                            </td></tr></table>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label8" runat="server" Text="Programmee Details :" AssociatedControlID="xprogdetail_day_o"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80">
                                                <div class="_ctl_padding">
                                                    <textarea id="xprogdetail_day_o" class="bm_academic_textarea_dynamic_100_80  bm_academic_textarea"
                                                        runat="server"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Outings / Duke</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_100_25 required">
                                            <div class="bm_ctl_label_align_right_100_25 label_bg">
                                                <asp:Label ID="Label9" runat="server" Text="Session :" AssociatedControlID="xsession_out"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:DropDownList ID="xsession_out" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_100_45 required" style="float: left">
                                                <div class="bm_ctl_label_align_right_100_45 label_bg">
                                                    <asp:Label ID="Label10" runat="server" Text="Programme's Name :" AssociatedControlID="xprogramme_out"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_100_45">
                                                    <asp:DropDownList ID="xprogramme_out" runat="server" CssClass="bm_academic_dropdown_100_45 bm_academic_ctl_global bm_academic_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div style="float: left; margin-left: 5px">
                                                <%--<asp:TextBox ID="cpday_sample" runat="server" ReadOnly="True"  CssClass="bm_cp_sample" BackColor="red"></asp:TextBox>--%>
                                                <div id="cpout_sample" class="bm_cp_sample" style="float: left; margin-right: 5px;">
                                                    <img alt="" src="/images/color-picker.png" width="26px" height="24px" style="border-radius: 2px;
                                                        border: solid 1px #BFBEBC;" id="cpout_s" />
                                                </div>
                                                <div style="float: left;">
                                                    <asp:TextBox ID="cpout_value" runat="server" CssClass="bm_cp_value"></asp:TextBox></div>
                                                <cc1:ColorPickerExtender ID="ColorPickerExtender2" runat="server" TargetControlID="cpout_value"
                                                    PopupButtonID="cpout_s" SampleControlID="cpout_s" OnClientColorSelectionChanged="colorChanged_out" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label11" runat="server" Text="Will Be Observed In :" AssociatedControlID="xlocation_out"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:DropDownList ID="xlocation_out" runat="server" CssClass="bm_academic_dropdown_100_30 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label12" runat="server" Text="Observation Date :" AssociatedControlID="xdate_out"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="xdate_out" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label13" runat="server" Text="1st Seating :" AssociatedControlID="xfdate_out"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="xfdate_out" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label14" runat="server" Text="Over All Convenor :" AssociatedControlID="xallconvenor_out"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xallconvenor_out" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_allconvenor_out" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label15" runat="server" Text="Co Convenor :" AssociatedControlID="xcoconvenor_out"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xcoconvenor_out" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_coconvenor_out" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label16" runat="server" Text="Class & Dates :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80">
                                                <div class="_ctl_padding">
                                                    <div class="_ctl_container">
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:DropDownList ID="xfclass_out" runat="server" CssClass="bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl">
                                                            <asp:Label ID="Label19" runat="server" Text="to" CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:DropDownList ID="xtclass_out" runat="server" CssClass="bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl" style="margin-right: 52px;">
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:TextBox ID="xffdate_out" runat="server" CssClass="bm_academic_datepicker_dynamic_100_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl">
                                                            <asp:Label ID="Label18" runat="server" Text="to" CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:TextBox ID="xtdate_out" runat="server" CssClass="bm_academic_datepicker_dynamic_100_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                    <div class="_ctl_container">
                                                        <div class="bm_ctl_container_dynamic_100_80_nl">
                                                            <asp:Label ID="Label22" runat="server" Text="Vanue :" CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:TextBox ID="xvenue_out" runat="server" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl" style="margin-right: 40px;">
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl">
                                                            <asp:Label ID="Label20" runat="server" Text="Convenor :" CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol_list">
                                                            <div class="bm_list_text">
                                                                <asp:TextBox ID="xconvenor_out" runat="server" CssClass="bm_academic_textbox_dynamic_100_80_list bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                            </div>
                                                            <div class="bm_list_img">
                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_convenor_out" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label17" runat="server" Text="Programmee Details :" AssociatedControlID="xprogdetail_out"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80">
                                                <div class="_ctl_padding">
                                                    <textarea id="xprogdetail_out" class="bm_academic_textarea_100_80  bm_academic_textarea"
                                                        style="width: 615px;" runat="server"></textarea>
                                                </div>
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
                            Sports / Coaching</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_100_25">
                                            <div class="bm_ctl_label_align_right_100_25">
                                                <asp:Label ID="Label21" runat="server" Text="Session :" AssociatedControlID="xsession_sport"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:DropDownList ID="xsession_sport" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_100_45" style="float: left">
                                                <div class="bm_ctl_label_align_right_100_45">
                                                    <asp:Label ID="Label23" runat="server" Text="Programme's Name :" AssociatedControlID="xprogramme_sport"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_100_45">
                                                    <asp:DropDownList ID="xprogramme_sport" runat="server" CssClass="bm_academic_dropdown_100_45 bm_academic_ctl_global bm_academic_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div style="float: left; margin-left: 5px">
                                                <%--<asp:TextBox ID="cpday_sample" runat="server" ReadOnly="True"  CssClass="bm_cp_sample" BackColor="red"></asp:TextBox>--%>
                                                <div id="cpsport_sample" class="bm_cp_sample" style="float: left; margin-right: 5px;">
                                                    <img alt="" src="/images/color-picker.png" width="26px" height="24px" style="border-radius: 2px;
                                                        border: solid 1px #BFBEBC;" id="cpsport_s" />
                                                </div>
                                                <div style="float: left;">
                                                    <asp:TextBox ID="cpsport_value" runat="server" CssClass="bm_cp_value"></asp:TextBox></div>
                                                <cc1:ColorPickerExtender ID="ColorPickerExtender3" runat="server" TargetControlID="cpsport_value"
                                                    PopupButtonID="cpsport_s" SampleControlID="cpsport_s" OnClientColorSelectionChanged="colorChanged_sport" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label24" runat="server" Text="Will Be Observed In :" AssociatedControlID="xlocation_sport"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:DropDownList ID="xlocation_sport" runat="server" CssClass="bm_academic_dropdown_100_30 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label25" runat="server" Text="Observation Date :" AssociatedControlID="xdate_sport"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="xdate_sport" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label26" runat="server" Text="1st Seating :" AssociatedControlID="xfdate_sport"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="xfdate_sport" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label27" runat="server" Text="Over All Convenor :" AssociatedControlID="xallconvenor_sport"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xallconvenor_sport" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_allconvenor_sport" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label28" runat="server" Text="Co Convenor :" AssociatedControlID="xcoconvenor_sport"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xcoconvenor_sport" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_coconvenor_sport" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label29" runat="server" Text="Class & Start Dates :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80">
                                                <div class="_ctl_padding">
                                                    <div class="_ctl_container">
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:DropDownList ID="xfclass_sport" runat="server" CssClass="bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl">
                                                            <asp:Label ID="Label30" runat="server" Text="to" CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:DropDownList ID="xtclass_sport" runat="server" CssClass="bm_academic_dropdown_dynamic_100_80 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl" style="margin-right: 52px;">
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:TextBox ID="xffdate_sport" runat="server" CssClass="bm_academic_datepicker_dynamic_100_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_nl">
                                                            <asp:Label ID="Label31" runat="server" Text="to" CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_100_80_wol">
                                                            <asp:TextBox ID="xtdate_sport" runat="server" CssClass="bm_academic_datepicker_dynamic_100_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label32" runat="server" Text="Final Day :" AssociatedControlID="xfinaldate_sport"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="xfinaldate_sport" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label34" runat="server" Text="Programmee Details :" AssociatedControlID="xprogdetail_sport"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80">
                                                <div class="_ctl_padding">
                                                    <textarea id="xprogdetail_sport" class="bm_academic_textarea_100_80  bm_academic_textarea"
                                                        style="width: 615px;" runat="server"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Exam / Test</HeaderTemplate>
                        <ContentTemplate>
                            <%-- Left layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label33" runat="server" Text="Session :" AssociatedControlID="xsession_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:DropDownList ID="xsession_exam" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label35" runat="server" Text="School :" AssociatedControlID="xlocation_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xlocation_exam" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label36" runat="server" Text="End of Mid Term :" AssociatedControlID="xdate_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xdate_exam" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_50_60" style="float: left">
                                                <div class="bm_ctl_label_align_right_50_60">
                                                    <asp:Label ID="Label37" runat="server" Text="Name of The Exam :" AssociatedControlID="xexam_exam"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_60">
                                                    <asp:DropDownList ID="xexam_exam" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div style="float: left; margin-left: 5px">
                                                <%--<asp:TextBox ID="cpday_sample" runat="server" ReadOnly="True"  CssClass="bm_cp_sample" BackColor="red"></asp:TextBox>--%>
                                                <div id="cpexam_sample" class="bm_cp_sample" style="float: left; margin-right: 5px;">
                                                    <img alt="" src="/images/color-picker.png" width="26px" height="24px" style="border-radius: 2px;
                                                        border: solid 1px #BFBEBC;" id="cpexam_s" />
                                                </div>
                                                <div style="float: left;">
                                                    <asp:TextBox ID="cpexam_value" runat="server" CssClass="bm_cp_value"></asp:TextBox></div>
                                                <cc1:ColorPickerExtender ID="ColorPickerExtender1" runat="server" TargetControlID="cpexam_value"
                                                    PopupButtonID="cpexam_s" SampleControlID="cpexam_s" OnClientColorSelectionChanged="colorChanged_exam" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label38" runat="server" Text="Class :" AssociatedControlID="xclass_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xclass_exam" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label39" runat="server" Text="Exam Starts Date :" AssociatedControlID="xfdate_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xfdate_exam" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label40" runat="server" Text="Exam Ends Date :" AssociatedControlID="xtdate_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xtdate_exam" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label41" runat="server" Text="Submission of Q/P By :" AssociatedControlID="xsubmission_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xsubmission_exam" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label42" runat="server" Text="Result Day (PTM) :" AssociatedControlID="xresultdate_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xresultdate_exam" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label43" runat="server" Text="Convenor :" AssociatedControlID="xconvenor_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xconvenor_exam" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_convenor_exam" />
                                                </div>
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
                                        <div class="bm_ctl_container_50_l_woc">
                                            <div class="bm_ctl_label_align_right_50_l">
                                                <asp:Label ID="Label45" runat="server" Text="Programmee Details :" AssociatedControlID="xprogdetail_exam"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <textarea id="xprogdetail_exam" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                            style="width: 550px;" runat="server"></textarea>
                                        <%--Control section end--%>
                                    </div>
                                </div>
                            </div>
                            <%-- Right layout side end--%>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Others</HeaderTemplate>
                        <ContentTemplate>
                            <%-- Left layout side start--%>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <%--Control section start--%>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label46" runat="server" Text="Session :" AssociatedControlID="xsession_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:DropDownList ID="xsession_others" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label47" runat="server" Text="School :" AssociatedControlID="xlocation_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="xlocation_others" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div class="bm_ctl_container_50_80" style="float: left;">
                                                <div class="bm_ctl_label_align_right_50_80">
                                                    <asp:Label ID="Label57" runat="server" Text="Name of The Event :" AssociatedControlID="xname_others"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_80">
                                                    <asp:DropDownList ID="xname_others" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div style="float: left; margin-left: 5px">
                                                <%--<asp:TextBox ID="cpday_sample" runat="server" ReadOnly="True"  CssClass="bm_cp_sample" BackColor="red"></asp:TextBox>--%>
                                                <div id="cpother_sample" class="bm_cp_sample" style="float: left; margin-right: 5px;">
                                                    <img alt="" src="/images/color-picker.png" width="26px" height="24px" style="border-radius: 2px;
                                                        border: solid 1px #BFBEBC;" id="cpother_s" />
                                                </div>
                                                <div style="float: left;">
                                                    <asp:TextBox ID="cpother_value" runat="server" CssClass="bm_cp_value" Style="width: 60px"></asp:TextBox></div>
                                                <cc1:ColorPickerExtender ID="ColorPickerExtender4" runat="server" TargetControlID="cpother_value"
                                                    PopupButtonID="cpother_s" SampleControlID="cpother_s" OnClientColorSelectionChanged="colorChanged_other" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_50_80">
                                            <div class="bm_ctl_container_dynamic_50_80_l_new">
                                                <div class="bm_ctl_label_align_right_dynamic_50_80_l">
                                                    <asp:Label ID="Label50" runat="server" Text="Class & Dates :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_50_80">
                                                <div class="_ctl_padding">
                                                    <div class="_ctl_container">
                                                        <div class="bm_ctl_container_dynamic_50_80_wol">
                                                            <asp:DropDownList ID="xfclass_others" runat="server" CssClass="bm_academic_dropdown_dynamic_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_50_80_nl">
                                                            <asp:Label ID="Label51" runat="server" Text="to" CssClass="label"></asp:Label>
                                                        </div>
                                                        <div class="bm_ctl_container_dynamic_50_80_wol">
                                                            <asp:DropDownList ID="xtclass_others" runat="server" CssClass="bm_academic_dropdown_dynamic_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label48" runat="server" Text="Event Starts Date :" AssociatedControlID="xffdate_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xffdate_others" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label58" runat="server" Text="Event Ends Date :" AssociatedControlID="xtdate_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xtdate_others" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label53" runat="server" Text="1 st Seating :" AssociatedControlID="xfdate_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xfdate_others" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label55" runat="server" Text="Convenor :" AssociatedControlID="xconvenor_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <div class="bm_list_text">
                                                    <asp:TextBox ID="xconvenor_others" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                </div>
                                                <div class="bm_list_img">
                                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_convenor_other" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding" style="padding-bottom: 1px">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label49" runat="server" Text="Result Day :" AssociatedControlID="xresultdate_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="xresultdate_others" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
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
                                        <div class="bm_ctl_container_50_l_woc">
                                            <div class="bm_ctl_label_align_right_50_l">
                                                <asp:Label ID="Label56" runat="server" Text="Programmee Details :" AssociatedControlID="xprogdetail_others"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <textarea id="xprogdetail_others" class="bm_academic_textarea_50_100  bm_academic_textarea"
                                            style="width: 550px;" runat="server"></textarea>
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
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="bm_academic_button bm_am_btn_edit"
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
               <ContentTemplate>
                <div class="bm_academic_grid_container" id="list" runat="server">
                    <div class="grid_header">
                        <div class="grid_header_label" id="_grid_header" runat="server">
                            Days Observations :
                        </div>
                        <div class="grid_header_control">
                            <div class="grid_ctl_padding">
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
                                <div class="bm_ctl_container_100_ses_grid">
                                    <div class="bm_ctl_label_align_right_100_ses_grid">
                                        <asp:Label ID="Label54" runat="server" Text="School :" AssociatedControlID="grid_xlocation"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_ses_grid">
                                        <asp:DropDownList ID="grid_xlocation" AutoPostBack="True" runat="server" CssClass="bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location"
                                            OnTextChanged="fnFillDataGrid">
                                        </asp:DropDownList>
                                    </div>
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
                        <asp:GridView ID="_grid_day_o" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link _grid1"
                                            OnClick="FillControls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xprogram" HeaderText="Programme's Name" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xdate" HeaderText="Observation Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xfdate" HeaderText="1st Seating" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xconvenor" HeaderText="Convenor" ItemStyle-Width="200px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xcoconvenor" HeaderText="Co Convenor" ItemStyle-Width="200px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="_grid_out" runat="server" AutoGenerateColumns="False" ShowFooter="true"
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
                                <asp:BoundField DataField="xprogram" HeaderText="Programme's Name" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xdate" HeaderText="Observation Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xfdate" HeaderText="1st Seating" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xallconvenor" HeaderText="Over All Convenor" ItemStyle-Width="200px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xcoconvenor" HeaderText="Co Convenor" ItemStyle-Width="200px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="_grid_sport" runat="server" AutoGenerateColumns="False" ShowFooter="true"
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
                                <asp:BoundField DataField="xprogram" HeaderText="Programme's Name" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xdate" HeaderText="Observation Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xfdate" HeaderText="1st Seating" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xallconvenor" HeaderText="Over All Convenor" ItemStyle-Width="200px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xcoconvenor" HeaderText="Co Convenor" ItemStyle-Width="200px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="_grid_exam" runat="server" AutoGenerateColumns="False" ShowFooter="true"
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
                                <asp:BoundField DataField="xprogram" HeaderText="Name of The Exam" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xfclass" HeaderText="Class" ItemStyle-Width="350px" ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xfdate" HeaderText="Exam Starts Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xtdate" HeaderText="Exam Ends Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xresultdate" HeaderText="Result Day (PTM)" DataFormatString="{0:d}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xconvenor" HeaderText="Convenor" ItemStyle-Width="200px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="_grid_other" runat="server" AutoGenerateColumns="False" ShowFooter="true"
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
                                <asp:BoundField DataField="xprogram" HeaderText="Name of The Event" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xfclass" HeaderText="From Class" ItemStyle-Width="250px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xtclass" HeaderText="To Class" ItemStyle-Width="250px"
                                    ItemStyle-CssClass="pad5" />
                                <asp:BoundField DataField="xffdate" HeaderText="Starts Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xtdate" HeaderText="Ends Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xresultdate" HeaderText="Result Day" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="xconvenor" HeaderText="Convenor" ItemStyle-Width="350px"
                                    ItemStyle-CssClass="pad5" />
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
    <asp:HiddenField ID="_colorvalue" runat="server" />
    <asp:HiddenField ID="_convenor_day" runat="server" />
    <asp:HiddenField ID="_coconvenor_day" runat="server" />
    <asp:HiddenField ID="_allconvenor_out" runat="server" />
    <asp:HiddenField ID="_coconvenor_out" runat="server" />
    <asp:HiddenField ID="_convenor_out" runat="server" />
    <asp:HiddenField ID="_allconvenor_sport" runat="server" />
    <asp:HiddenField ID="_coconvenor_sport" runat="server" />
    <asp:HiddenField ID="_convenor_exam" runat="server" />
    <asp:HiddenField ID="_convenor_other" runat="server" />
</asp:Content>
