<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true" CodeBehind="amstpcreateuser.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.profile.student.amstpcreateuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label1" id="header_label" runat="server">
                <span class="bm_am_header_round">Student Portal Manager</span>
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
                </div>
            </div>

            <div class="bm_academic_container_body_input_section">
                <div class="bm_layout_container">
                    <div class="bm_layout_box_100">
                        <div class="bm_layout_box_padding" style="padding-top: 0px;">

                            <div style="width: 100%">

                                <div style="width: 30%; margin-left: 20px; display: inline-block; vertical-align: top;">
                                    <fieldset style="height: 250px;">
                                        <legend>Check User</legend>

                                        <div class="bm_ctl_container_100_special" style=" width: 220px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label2" runat="server" Text="Student ID :" AssociatedControlID="xstdid_chk"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:TextBox ID="xstdid_chk" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div style="margin-top: 20px;">
                                            <asp:Button ID="btnCheck" runat="server" Text="Check" CssClass="bm_academic_button3 bm_am_btn_sendmail" OnClick="btnCheck_OnClick"/>
                                        </div>
                                        
                                         <div style="margin-top: 10px;">
                                             <asp:Label ID="lblchk" runat="server" Text=""></asp:Label>
                                        </div>
                                        
                                        <div style="margin-top: 5px;" runat="server" id="divchk">
                                             <div style="float: left; margin-right: 10px;">
                                                 <asp:Image ID="imgchk" runat="server" Width="80px" Height="80px" />
                                                 </div>
                                            <div style="float: left; ">
                                                <asp:Label ID="xname_chk" runat="server" Text=""></asp:Label><br/>
                                                <asp:Label ID="xuserid_chk" runat="server" Text=""></asp:Label><br/>
                                                 </div>
                                           
                                        </div>

                                    </fieldset>
                                </div>

                                <div style="width: 30%; margin-left: 20px; display: inline-block;vertical-align: top;">
                                    <fieldset style="height: 250px;">
                                        <legend>Create User</legend>
                                        
                                        <div class="bm_ctl_container_100_special" style=" width: 220px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label1" runat="server" Text="Student ID :" AssociatedControlID="xstdid_cre"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:TextBox ID="xstdid_cre" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div style="margin-top: 20px;">
                                            <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="bm_academic_button3 bm_am_btn_sendmail" OnClick="btnCreate_OnClick"/>
                                        </div>
                                        
                                         <div style="margin-top: 10px;">
                                             <asp:Label ID="lblcre" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="margin-top: 5px;" runat="server" id="divcre">
                                             <div style="float: left; margin-right: 10px;">
                                                 <asp:Image ID="imgcre" runat="server" Width="80px" Height="80px" />
                                                 </div>
                                            <div style="float: left; ">
                                                <asp:Label ID="xname_cre" runat="server" Text="Name : Kanchan Dey"></asp:Label><br/>
                                                <asp:Label ID="xuserid_cre" runat="server" Text="User ID : 3131"></asp:Label><br/>
                                                <asp:Label ID="xpass_cre" runat="server" Text="Password : 123"></asp:Label>
                                                 </div>
                                           
                                        </div>

                                    </fieldset>
                                </div>

                                <div style="width: 30%; margin-left: 20px; display: inline-block;vertical-align: top;">
                                    <fieldset style="height: 250px;">
                                        <legend>Reset Password</legend>
                                        
                                        <div style="margin-top: 0px;">
                                             <asp:Label ID="Label4" runat="server" Text="After reset password will be '123'"></asp:Label>
                                        </div>

                                        <div class="bm_ctl_container_100_special" style="width: 220px; margin-top: 10px;">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label3" runat="server" Text="Student ID :" AssociatedControlID="xstdid_reset"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:TextBox ID="xstdid_reset" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div style="margin-top: 20px;">
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="bm_academic_button3 bm_am_btn_sendmail" OnClick="btnReset_OnClick"/>
                                        </div>
                                        
                                         <div style="margin-top: 10px;">
                                             <asp:Label ID="lblreset" runat="server" Text=""></asp:Label>
                                        </div>
                                        
                                        <div style="margin-top: 5px;" runat="server" id="divreset">
                                             <div style="float: left; margin-right: 10px;">
                                                 <asp:Image ID="imgreset" runat="server" Width="80px" Height="80px" />
                                                 </div>
                                            <div style="float: left; ">
                                                <asp:Label ID="xname_reset" runat="server" Text=""></asp:Label><br/>
                                                <asp:Label ID="xuserid_reset" runat="server" Text=""></asp:Label><br/>
                                                 </div>
                                           
                                        </div>

                                    </fieldset>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="bm_academic_container_footer">
                <div class="footer_list_padding1" style="padding-top: 0px;">
                </div>
            </div>

            <div class="bm_academic_container_body_button_section">
                <div class="button_section_padding">
                </div>
            </div>

        </div>

    </div>

</asp:Content>
