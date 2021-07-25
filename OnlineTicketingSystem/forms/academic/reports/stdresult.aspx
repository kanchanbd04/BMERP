<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stdresult.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.reports.stdresult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/bmerp.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="bm_academic_container">
            <div class="bm_academic_container_header">
                <div class="header_label" id="header_label" runat="server">
                    PRINT VIVA LIST
                </div>
            </div>
            <div class="bm_academic_container_message">
                <div id="message" runat="server">
                </div>
            </div>
            <div class="bm_academic_container_body">
                <div class="bm_academic_container_body_input_section">
                    <div class="bm_layout_container">
                        <div class="bm_layout_box_100">
                            <div class="bm_layout_box_padding">
                                <div style="margin: 0 auto; width: 300px">
                                    <div class="bm_ctl_container_100_25" style="width: 100%">
                                        <div class="bm_ctl_label_align_right_100_25" style="width: 40%">
                                            <asp:Label ID="Label31" runat="server" Text="Print List For :" AssociatedControlID="xprintlistfor"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_25" style="width: 60%">
                                            <asp:DropDownList ID="xprintlistfor" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_clt_padding">
                                    </div>
                                    <div class="bm_ctl_container_100_25" style="width: 100%">
                                        <div class="bm_ctl_label_align_right_100_25" style="width: 40%">
                                            <asp:Label ID="Label19" runat="server" Text="Session :" AssociatedControlID="xsession_res"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_25" style="width: 60%">
                                            <asp:DropDownList ID="xsession_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_clt_padding">
                                    </div>
                                    <div class="bm_ctl_container_100_25" style="width: 100%">
                                        <div class="bm_ctl_label_align_right_100_25" style="width: 40%">
                                            <asp:Label ID="Label222" runat="server" Text="Class :" AssociatedControlID="xclass_res"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_25" style="width: 60%">
                                            <asp:DropDownList ID="xclass_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_clt_padding">
                                    </div>
                                    <div class="bm_ctl_container_100_25" style="width: 100%; display: none;">
                                        <div class="bm_ctl_label_align_right_100_25" style="width: 40%">
                                            <asp:Label ID="Label23" runat="server" Text="Group :" AssociatedControlID="xgroup_res"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_25" style="width: 60%">
                                            <asp:DropDownList ID="xgroup_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="bm_clt_padding">
                                    </div>--%>
                                    <div class="bm_ctl_container_100_25" style="width: 100%">
                                        <div class="bm_ctl_label_align_right_100_25" style="width: 40%">
                                            <asp:Label ID="Label24" runat="server" Text="Number of Exam :" AssociatedControlID="xnumexam_res"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_25" style="width: 60%">
                                            <asp:DropDownList ID="xnumexam_res" runat="server" CssClass="bm_academic_dropdown_100_25 bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_clt_padding">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="bm_academic_container_body_button_section">
                    <div class="button_section_padding" style="text-align: center;">
                     <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="bm_academic_button bm_am_btn_refresh"  OnClick="fnPrintList"/>
                     <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="bm_academic_button bm_am_btn_refresh"  OnClientClick="self.close();"/>
                    </div>
                </div>
            </div>
            <div class="bm_academic_container_footer">
                <div id="list" runat="server">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
