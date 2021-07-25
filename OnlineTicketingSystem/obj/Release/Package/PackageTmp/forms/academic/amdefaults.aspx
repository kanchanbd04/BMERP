<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="amdefaults.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.amdefaults" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        /*.ajax__tab_header
        {
            float: left;
        }
        .ajax__tab_body
        {
            /*float:left;*/
        /*       margin-left: 220px;
        }
        .ajax__tab_outer
        {
            display: block !important;
        }
        .ajax__tab_tab
        {
            /*min-width:200px;*/
        /*    width: 200px;
            height: auto !important;
        }*/
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.bm_tfccode').click(function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label" id="header_label" runat="server">
                SYSTEM DEFAULT SETTING'S
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
                <%-- ---THIS IS MESSAGE SECTION-----%>
            </div>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1"
                    CssClass="bm_academic_tab" ScrollBars="Auto" OnActiveTabChanged="TabContainer1_ActiveTabChanged"
                    AutoPostBack="True">
                    <cc1:TabPanel runat="server" HeaderText="General" ID="TabPanel1" Height="500px">
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="Student" ID="TabPanel2" Height="600px">
                        <HeaderTemplate>
                            Student
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div style="width: 100%; padding-top: 50px; text-align: center">
                                <fieldset style="width: 40%; margin: 0 auto;">
                                    <legend>Student Default's</legend>
                                    <table style="text-align: right">
                                        <tr>
                                            <td>Age (Within)
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>Day
                                                        </td>
                                                        <td>-
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="stdageday" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>Month
                                                        </td>
                                                        <td>-
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="stdagemonth" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Passing Method
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="stdpassmethod" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Session (Academic)
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xsession" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Term
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xterm" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Exam Venue
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xexamvenue" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Session (Admission Online/SRO)
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xsessiononline" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Session (Accounts)
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xsessionacc" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Session (For Seat Conf. Running Info)
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xsessionaccseatconf" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Due Days (After)
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span>
                                                    <asp:TextBox ID="xduedays" runat="server" Height="20px" Width="30px"></asp:TextBox>
                                                </span>
                                                <span>
                                                    <asp:DropDownList ID="xduedaystype" runat="server">
                                                    </asp:DropDownList>
                                                </span></td>
                                        </tr>
                                        <tr>
                                            <td>Late Fine A/C
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <span class="bm_span1">
                                                    <asp:TextBox ID="xlatefeeac" runat="server" Height="20px" Width="100px" CssClass="bm_text1"></asp:TextBox>
                                                </span>
                                                <span class="bm_span2">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_tfccode" />
                                                </span>
                                                <span class="bm_span3">
                                                    <asp:Label ID="xlatefeeactitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                </span>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>VAT Calculation Type
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">

                                                <asp:DropDownList ID="xvatcaltype" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>VAT %
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">

                                                <asp:TextBox ID="xvatperc" runat="server" Height="20px" Width="40px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Charge Period
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <table>
                                                    <tr>
                                                        <td>From Date</td>
                                                        <td>-</td>
                                                        <td>
                                                            <asp:TextBox ID="xfperiod" runat="server" Height="20px" Width="100px" CssClass="bm_academic_datepicker"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>To Date</td>
                                                         <td>-</td>
                                                        <td>
                                                            <asp:TextBox ID="xtperiod" runat="server" Height="20px" Width="100px" CssClass="bm_academic_datepicker"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Bank
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xbank" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                         <tr>
                                            <td>Adv. Receive Default (Yes/No)
                                            </td>
                                            <td>:
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="xadvyesno" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <fieldset>
                                                    <legend>Student ID Info</legend>
                                                    <table>
                                                        <tr>
                                                            <td>ID Digit
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="text-align: left">

                                                                <asp:TextBox ID="xiddigit" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ID Prefix
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="text-align: left">

                                                                <asp:TextBox ID="xidprefix" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ID Start From
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="text-align: left">

                                                                <asp:TextBox ID="xidstart" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>

                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="Test" ID="TabPanel3" Height="500px">
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="Test" ID="TabPanel4" Height="500px">
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="Test" ID="TabPanel5" Height="500px">
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </div>
            <div class="bm_academic_container_body_button_section">
                <div class="button_section_padding">
                    <div class="button_section_style">
                        <asp:Button ID="btnSave" runat="server" Text="Save"
                            CssClass="bm_academic_button" OnClick="btnSave_Click" />
                        <%--<asp:Button ID="Button2" runat="server" Text="Edit" CssClass="bm_academic_button" />--%>
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh"
                            CssClass="bm_academic_button" OnClick="btnRefresh_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="_xlatefeeac" runat="server" />
</asp:Content>
