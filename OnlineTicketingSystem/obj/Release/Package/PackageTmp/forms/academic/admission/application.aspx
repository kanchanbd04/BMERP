<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="application.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.application" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.2.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //alert("Hi!");
            //            $('.bm_academic_datepicker').attr('placeholder', 'DD/MM/YYYY');
            //ns.dp_placeholder();
        });
        
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label" id="header_label" runat="server">
                ---THIS IS HEADER SECTION---
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
                ---THIS IS MESSAGE SECTION---
            </div>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="bm_academic_tab" Height="3000px"
                    ActiveTabIndex="0">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            Info. For Admission Test</HeaderTemplate>
                        <ContentTemplate>
                            <div class="bm_layout_container">
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <h4>
                                            <center>
                                                50% Layout Left</center>
                                        </h4>
                                        <hr>
                                        <h3>
                                            40% Control's in 50% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_50_40">
                                            <div class="bm_ctl_label_align_right_50_40">
                                                <asp:Label ID="Label1" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList1" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_40">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="bm_academic_dropdown_50_40 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_40">
                                            <div class="bm_ctl_label_align_right_50_40">
                                                <asp:Label ID="Label2" runat="server" Text="Text Box :" AssociatedControlID="TextBox1" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_40">
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_40">
                                            <div class="bm_ctl_label_align_right_50_40">
                                                <asp:Label ID="Label3" runat="server" Text="Datepicker :" AssociatedControlID="TextBox2" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_40">
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            50% Control's in 50% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label4" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList2" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label5" runat="server" Text="Text Box :" AssociatedControlID="TextBox3" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50">
                                            <div class="bm_ctl_label_align_right_50_50">
                                                <asp:Label ID="Label6" runat="server" Text="Datepicker :" AssociatedControlID="TextBox4" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50">
                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            60% Control's in 50% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label7" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList3" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label8" runat="server" Text="Text Box :" AssociatedControlID="TextBox5" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="TextBox5" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_60">
                                            <div class="bm_ctl_label_align_right_50_60">
                                                <asp:Label ID="Label9" runat="server" Text="Datepicker :" AssociatedControlID="TextBox6" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_60">
                                                <asp:TextBox ID="TextBox6" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            80% Control's in 50% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label10" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList4" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="bm_academic_dropdown_50_80 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label11" runat="server" Text="Text Box :" AssociatedControlID="TextBox7" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="TextBox7" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_80">
                                            <div class="bm_ctl_label_align_right_50_80">
                                                <asp:Label ID="Label12" runat="server" Text="Datepicker :" AssociatedControlID="TextBox8" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_80">
                                                <asp:TextBox ID="TextBox8" runat="server" CssClass="bm_academic_textbox_50_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                         <h3>
                                            100% Control's in 50% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label13" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList5" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="bm_academic_dropdown_50_100 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label14" runat="server" Text="Text Box :" AssociatedControlID="TextBox9" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="TextBox9" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_100">
                                            <div class="bm_ctl_label_align_right_50_100">
                                                <asp:Label ID="Label15" runat="server" Text="Datepicker :" AssociatedControlID="TextBox10" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_100">
                                                <asp:TextBox ID="TextBox10" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                    </div>
                                </div>
                                <div class="bm_layout_box_50">
                                    <div class="bm_layout_box_padding">
                                        <h4>
                                            <center>
                                                50% Layout Right</center>
                                        </h4>
                                        <hr>
                                        <h3>
                                            40% Control's in 50% Layout</h3>
                                        <br></br>
                                    </div>
                                </div>
                                <div class="clear"></div>
                                 <div class="bm_layout_box_100">
                                    <div class="bm_layout_box_padding">
                                        <h4>100% Layout </h4>
                                        <hr>
                                        <h3>
                                            20% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_20">
                                            <div class="bm_ctl_label_align_right_100_20">
                                                <asp:Label ID="Label16" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList6" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_20">
                                                <asp:DropDownList ID="DropDownList6" runat="server" CssClass="bm_academic_dropdown_100_20 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_20">
                                            <div class="bm_ctl_label_align_right_100_20">
                                                <asp:Label ID="Label17" runat="server" Text="Text Box :" AssociatedControlID="TextBox11" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_20">
                                                <asp:TextBox ID="TextBox11" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_20">
                                            <div class="bm_ctl_label_align_right_100_20">
                                                <asp:Label ID="Label18" runat="server" Text="Datepicker :" AssociatedControlID="TextBox12" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_20">
                                                <asp:TextBox ID="TextBox12" runat="server" CssClass="bm_academic_textbox_100_20 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            25% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_25">
                                            <div class="bm_ctl_label_align_right_100_25">
                                                <asp:Label ID="Label22" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList8" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:DropDownList ID="DropDownList8" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_25">
                                            <div class="bm_ctl_label_align_right_100_25">
                                                <asp:Label ID="Label23" runat="server" Text="Text Box :" AssociatedControlID="TextBox15" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:TextBox ID="TextBox15" runat="server" CssClass="bm_academic_textbox_100_25 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_25">
                                            <div class="bm_ctl_label_align_right_100_25">
                                                <asp:Label ID="Label24" runat="server" Text="Datepicker :" AssociatedControlID="TextBox16" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_25">
                                                <asp:TextBox ID="TextBox16" runat="server" CssClass="bm_academic_textbox_100_25 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            30% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label19" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList7" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:DropDownList ID="DropDownList7" runat="server" CssClass="bm_academic_dropdown_100_30 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label20" runat="server" Text="Text Box :" AssociatedControlID="TextBox13" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="TextBox13" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_30">
                                            <div class="bm_ctl_label_align_right_100_30">
                                                <asp:Label ID="Label21" runat="server" Text="Datepicker :" AssociatedControlID="TextBox14" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_30">
                                                <asp:TextBox ID="TextBox14" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            35% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_35">
                                            <div class="bm_ctl_label_align_right_100_35">
                                                <asp:Label ID="Label25" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList9" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_35">
                                                <asp:DropDownList ID="DropDownList9" runat="server" CssClass="bm_academic_dropdown_100_35 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_35">
                                            <div class="bm_ctl_label_align_right_100_35">
                                                <asp:Label ID="Label26" runat="server" Text="Text Box :" AssociatedControlID="TextBox17" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_35">
                                                <asp:TextBox ID="TextBox17" runat="server" CssClass="bm_academic_textbox_100_35 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_35">
                                            <div class="bm_ctl_label_align_right_100_35">
                                                <asp:Label ID="Label27" runat="server" Text="Datepicker :" AssociatedControlID="TextBox18" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_35">
                                                <asp:TextBox ID="TextBox18" runat="server" CssClass="bm_academic_textbox_100_35 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            40% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_40">
                                            <div class="bm_ctl_label_align_right_100_40">
                                                <asp:Label ID="Label28" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList10" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_40">
                                                <asp:DropDownList ID="DropDownList10" runat="server" CssClass="bm_academic_dropdown_100_40 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_40">
                                            <div class="bm_ctl_label_align_right_100_40">
                                                <asp:Label ID="Label29" runat="server" Text="Text Box :" AssociatedControlID="TextBox19" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_40">
                                                <asp:TextBox ID="TextBox19" runat="server" CssClass="bm_academic_textbox_100_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_40">
                                            <div class="bm_ctl_label_align_right_100_40">
                                                <asp:Label ID="Label30" runat="server" Text="Datepicker :" AssociatedControlID="TextBox20" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_40">
                                                <asp:TextBox ID="TextBox20" runat="server" CssClass="bm_academic_textbox_100_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            45% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_45">
                                            <div class="bm_ctl_label_align_right_100_45">
                                                <asp:Label ID="Label31" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList11" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_45">
                                                <asp:DropDownList ID="DropDownList11" runat="server" CssClass="bm_academic_dropdown_100_45 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_45">
                                            <div class="bm_ctl_label_align_right_100_45">
                                                <asp:Label ID="Label32" runat="server" Text="Text Box :" AssociatedControlID="TextBox21" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_45">
                                                <asp:TextBox ID="TextBox21" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_45">
                                            <div class="bm_ctl_label_align_right_100_45">
                                                <asp:Label ID="Label33" runat="server" Text="Datepicker :" AssociatedControlID="TextBox22" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_45">
                                                <asp:TextBox ID="TextBox22" runat="server" CssClass="bm_academic_textbox_100_45 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                    
                                    <h3>
                                            50% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_50">
                                            <div class="bm_ctl_label_align_right_100_50">
                                                <asp:Label ID="Label34" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList12" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_50">
                                                <asp:DropDownList ID="DropDownList12" runat="server" CssClass="bm_academic_dropdown_100_50 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_50">
                                            <div class="bm_ctl_label_align_right_100_50">
                                                <asp:Label ID="Label35" runat="server" Text="Text Box :" AssociatedControlID="TextBox23" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_50">
                                                <asp:TextBox ID="TextBox23" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_50">
                                            <div class="bm_ctl_label_align_right_100_50">
                                                <asp:Label ID="Label36" runat="server" Text="Datepicker :" AssociatedControlID="TextBox24" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_50">
                                                <asp:TextBox ID="TextBox24" runat="server" CssClass="bm_academic_textbox_100_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            55% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_55">
                                            <div class="bm_ctl_label_align_right_100_55">
                                                <asp:Label ID="Label37" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList13" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_55">
                                                <asp:DropDownList ID="DropDownList13" runat="server" CssClass="bm_academic_dropdown_100_55 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_55">
                                            <div class="bm_ctl_label_align_right_100_55">
                                                <asp:Label ID="Label38" runat="server" Text="Text Box :" AssociatedControlID="TextBox25" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_55">
                                                <asp:TextBox ID="TextBox25" runat="server" CssClass="bm_academic_textbox_100_55 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_55">
                                            <div class="bm_ctl_label_align_right_100_55">
                                                <asp:Label ID="Label39" runat="server" Text="Datepicker :" AssociatedControlID="TextBox26" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_55">
                                                <asp:TextBox ID="TextBox26" runat="server" CssClass="bm_academic_textbox_100_55 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                         <h3>
                                            60% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_60">
                                            <div class="bm_ctl_label_align_right_100_60">
                                                <asp:Label ID="Label40" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList14" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_60">
                                                <asp:DropDownList ID="DropDownList14" runat="server" CssClass="bm_academic_dropdown_100_60 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_60">
                                            <div class="bm_ctl_label_align_right_100_60">
                                                <asp:Label ID="Label41" runat="server" Text="Text Box :" AssociatedControlID="TextBox27" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_60">
                                                <asp:TextBox ID="TextBox27" runat="server" CssClass="bm_academic_textbox_100_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_60">
                                            <div class="bm_ctl_label_align_right_100_60">
                                                <asp:Label ID="Label42" runat="server" Text="Datepicker :" AssociatedControlID="TextBox28" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_60">
                                                <asp:TextBox ID="TextBox28" runat="server" CssClass="bm_academic_textbox_100_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            80% Control's in 100% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_100_80">
                                            <div class="bm_ctl_label_align_right_100_80">
                                                <asp:Label ID="Label43" runat="server" Text="8888888888888888888" AssociatedControlID="DropDownList15" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_80">
                                                <asp:DropDownList ID="DropDownList15" runat="server" CssClass="bm_academic_dropdown_100_80 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_80">
                                            <div class="bm_ctl_label_align_right_100_80">
                                                <asp:Label ID="Label44" runat="server" Text="Text Box :" AssociatedControlID="TextBox29" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_80">
                                                <asp:TextBox ID="TextBox29" runat="server" CssClass="bm_academic_textbox_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_80">
                                            <div class="bm_ctl_label_align_right_100_80">
                                                <asp:Label ID="Label45" runat="server" Text="Datepicker :" AssociatedControlID="TextBox30" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_80">
                                                <asp:TextBox ID="TextBox30" runat="server" CssClass="bm_academic_textbox_100_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
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
                                <div class="bm_layout_box_60">
                                    <div class="bm_layout_box_padding">
                                        <h4>
                                            <center>
                                                60% Layout Left</center>
                                        </h4>
                                        <hr>
                                        <h3>
                                            40% Control's in 60% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_60_40">
                                            <div class="bm_ctl_label_align_right_60_40">
                                                <asp:Label ID="Label46" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList16" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_40">
                                                <asp:DropDownList ID="DropDownList16" runat="server" CssClass="bm_academic_dropdown_60_40 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_40">
                                            <div class="bm_ctl_label_align_right_60_40">
                                                <asp:Label ID="Label47" runat="server" Text="Text Box :" AssociatedControlID="TextBox31" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_40">
                                                <asp:TextBox ID="TextBox31" runat="server" CssClass="bm_academic_textbox_60_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_40">
                                            <div class="bm_ctl_label_align_right_60_40">
                                                <asp:Label ID="Label48" runat="server" Text="Datepicker :" AssociatedControlID="TextBox32" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_40">
                                                <asp:TextBox ID="TextBox32" runat="server" CssClass="bm_academic_textbox_60_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            50% Control's in 60% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_60_50">
                                            <div class="bm_ctl_label_align_right_60_50">
                                                <asp:Label ID="Label49" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList17" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_50">
                                                <asp:DropDownList ID="DropDownList17" runat="server" CssClass="bm_academic_dropdown_60_50 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_50">
                                            <div class="bm_ctl_label_align_right_60_50">
                                                <asp:Label ID="Label50" runat="server" Text="Text Box :" AssociatedControlID="TextBox33" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_50">
                                                <asp:TextBox ID="TextBox33" runat="server" CssClass="bm_academic_textbox_60_50 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_50">
                                            <div class="bm_ctl_label_align_right_60_50">
                                                <asp:Label ID="Label51" runat="server" Text="Datepicker :" AssociatedControlID="TextBox34" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_50">
                                                <asp:TextBox ID="TextBox34" runat="server" CssClass="bm_academic_textbox_60_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            60% Control's in 60% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_60_60">
                                            <div class="bm_ctl_label_align_right_60_60">
                                                <asp:Label ID="Label52" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList18" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_60">
                                                <asp:DropDownList ID="DropDownList18" runat="server" CssClass="bm_academic_dropdown_60_60 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_60">
                                            <div class="bm_ctl_label_align_right_60_60">
                                                <asp:Label ID="Label53" runat="server" Text="Text Box :" AssociatedControlID="TextBox35" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_60">
                                                <asp:TextBox ID="TextBox35" runat="server" CssClass="bm_academic_textbox_60_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_60">
                                            <div class="bm_ctl_label_align_right_60_60">
                                                <asp:Label ID="Label54" runat="server" Text="Datepicker :" AssociatedControlID="TextBox36" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_60">
                                                <asp:TextBox ID="TextBox36" runat="server" CssClass="bm_academic_textbox_60_60 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                        <h3>
                                            80% Control's in 60% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_60_80">
                                            <div class="bm_ctl_label_align_right_60_80">
                                                <asp:Label ID="Label55" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList19" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80">
                                                <asp:DropDownList ID="DropDownList19" runat="server" CssClass="bm_academic_dropdown_60_80 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_80">
                                            <div class="bm_ctl_label_align_right_60_80">
                                                <asp:Label ID="Label56" runat="server" Text="Text Box :" AssociatedControlID="TextBox37" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80">
                                                <asp:TextBox ID="TextBox37" runat="server" CssClass="bm_academic_textbox_60_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_80">
                                            <div class="bm_ctl_label_align_right_60_80">
                                                <asp:Label ID="Label57" runat="server" Text="Datepicker :" AssociatedControlID="TextBox38" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_80">
                                                <asp:TextBox ID="TextBox38" runat="server" CssClass="bm_academic_textbox_60_80 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                         <h3>
                                            100% Control's in 60% Layout</h3>
                                        <br></br>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label58" runat="server" Text="Dropdown :" AssociatedControlID="DropDownList20" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:DropDownList ID="DropDownList20" runat="server" CssClass="bm_academic_dropdown_60_100 bm_academic_ctl_global bm_academic_dropdown">
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2014-15</asp:ListItem>
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label59" runat="server" Text="Text Box :" AssociatedControlID="TextBox39" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="TextBox39" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_60_100">
                                            <div class="bm_ctl_label_align_right_60_100">
                                                <asp:Label ID="Label60" runat="server" Text="Datepicker :" AssociatedControlID="TextBox40" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_60_100">
                                                <asp:TextBox ID="TextBox40" runat="server" CssClass="bm_academic_textbox_60_100 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="bm_clt_padding">
                                        </div>
                                    </div>
                                </div>
                                <div class="bm_layout_box_40">
                                    <div class="bm_layout_box_padding">
                                        <h4>
                                            <center>
                                                40% Layout Right</center>
                                        </h4>
                                        <hr>
                                        <h3>
                                            40% Control's in 40% Layout</h3>
                                        <br></br>
                                    </div>
                                </div>
                                <div class="clear"></div>
                                </div>
                           
                           
                           </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                            Information For Admission</HeaderTemplate>
                        <ContentTemplate>
                           
                             <asp:TextBox ID="Label61" runat="server" Text="To select a Client, Please Click here"></asp:TextBox>
      <ajaxToolkit:DropDownExtender runat="server" ID="popupdropdown" DropDownControlID="pnlGrid"
          TargetControlID="Label61" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </div>
            <div class="bm_academic_container_body_button_section">
                <div class="button_section_padding">
                    <div class="button_section_style">
                        <asp:Button ID="Button1" runat="server" Text="Save" CssClass="bm_academic_button" />
                        <asp:Button ID="Button2" runat="server" Text="Edit" CssClass="bm_academic_button" />
                        <asp:Button ID="Button3" runat="server" Text="Refresh" CssClass="bm_academic_button" />
                    </div>
                </div>
            </div>
        </div>
        <div class="bm_academic_container_footer">
            <div class="footer_list_padding">
                <div class="bm_academic_grid_container" id="list" runat="server">
                    <div class="grid_header">
                        <div class="grid_header_label">
                            Days Observations :
                        </div>
                        <div class="grid_header_control">
                        </div>
                        <div class="flot_right">
                            <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>
                            <div class="grid_header_row">
                                <asp:TextBox ID="_gridrow" runat="server" AutoPostBack="True" CssClass="_gridrow"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="grid_body">
                        <asp:GridView ID="_grid" runat="server" AutoGenerateColumns="False" ShowFooter="true" CssClass="bm_academic_grid"
                        HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle" 
                        AlternatingRowStyle-CssClass="AlternatingRowStyle" PagerStyle-CssClass="PagerStyle" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Row" >
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:label id="footerlabel" Text="Total" CssClass="footer_label_total" runat="server"/>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="xuser" HeaderText="User" />
                                <asp:BoundField DataField="xlogin" HeaderText="Login Time" DataFormatString="{0:HH/mm}" />
                                <asp:BoundField DataField="xlogout" HeaderText="Logout Time" DataFormatString="{0:HH/mm}" />
                                <asp:BoundField DataField="xloc" HeaderText="Location" />
                                <asp:BoundField DataField="xdate" HeaderText="Date" DataFormatString="{0:d}" />
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
        
        <asp:Panel runat="server" ID="pnlGrid" Style="display: none; visibility: hidden">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                   GridLines="Both"
                    SelectedRowStyle-BackColor="#336699">
                    <Columns>
                        <%--<asp:BoundField DataField="ClientID" HeaderText="ClientID" InsertVisible="False"
                            ReadOnly="True" SortExpression="ClientID" />
                        <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                        <asp:BoundField DataField="IsValid" HeaderText="IsValid" SortExpression="IsValid" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="Select" CommandArgument='<%# Eval("FullName") %>' ID="LinkButton1"
                                    runat="server">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                         <asp:BoundField DataField="xuser" HeaderText="User"  />
                        <asp:BoundField DataField="xdate" HeaderText="Date"  />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

    </div>
    

</asp:Content>
