<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="amexamhh1Copy.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.amexamhh1Copy"
    EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function fnPrintNumSchedule() {
            // alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession = $("#<%= xsession.ClientID%>").val();
            var xterm = $("#<%= xterm.ClientID%>").val();
            var xclass = $("#<%= xclass.ClientID%>").val();
            var xdate = $("#<%= hiddenxdate.ClientID%>").val();
            var xrow = $("#<%= hiddenxrow.ClientID%>").val();
            var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/rptasctschvwsw1.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup + '&xsection=' + xsection + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            openwin.print();
            //return false;
        }
    </script>
    <style>
        .bm_academic_grid1, .bm_academic_grid1 td
        {
            border: 2px solid #939598;
        }
        
        .bm_academic_grid1 th, .bm_academic_grid1 .FooterStyle
        {
            border-left: 2px solid #939598;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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


                $("body").on("click", ".bm_circle_button_coordinator", function () {

                    //alert("Hi");
                    var row = this.parentNode.parentNode.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.parentNode.parentNode.cellIndex;

                    //alert(this.name);

                    var grid = document.getElementById('<%=GridView1.ClientID %>');


                    // alert(grid.rows[rowIndex+1].cells[cell].children[0].children[0].children[0].title);

                    var allparam = document.getElementsByName(this.name);
                    var param = allparam[0].title.split("\n");
                    var test1 = param[0].split("-");
                    //                    alert(test1[0]);
                    ////                 var col = grid.rows[rowIndex + 1].cells.length;
                    ////                 alert(grid.rows[rowIndex + 1].cells[1].innerText);
                    var subject = param[3].split("-");
                    ////                 if (typeof subject[1] != 'undefined') {
                    ////                  alert(subject[1]);
                    ////                 }

                    //                               alert(subject[0]);
                    //                    alert(param[3]);

                    var xsession1 = $("#<%= xsession.ClientID%>").val();
                    var xterm1 = $("#<%= xterm.ClientID%>").val();
                    var xclass1 = $("#<%= xclass.ClientID%>").val();
                    var xgroup1 = param[2];
                    var xsection1 = param[1];
                    var xsubject1 = subject[0];
                    var xpaper1 = "";
                    if (typeof subject[1] != 'undefined') {
                        xpaper1 = subject[1];
                    }

                    var xcttype1 = test1[0];
                    var xctno1 = test1[1];

                    var left = Math.round((screen.width / 2) - (500 / 2));
                    var top = Math.round((screen.height / 2) - (500 / 2));
                    var openwin = window.open("/forms/academic/assesment/mark-input/amexamh2.aspx?subnav=myDropdown44&link=LinkButton44&xsession=" + xsession1 + "&xterm=" + xterm1 + "&xclass=" + xclass1 + "&xgroup=" + xgroup1 + "&xsection=" + xsection1 + "&xsubject=" + xsubject1.replace(/&/gi, "%26") + "&xpaper=" + xpaper1 + "&xcttype=" + xcttype1 + "&xctno=" + xctno1, 'ctstco', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=600, height=500, top=' + top + ', left=' + left + ', targets=_blank');
                    openwin.focus();

                });

                function ConfirmMessage3() {
                    var selectedvalue = confirm("Do you want to approved this record?");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue3.ClientID %>').value = "Yes";
                    } else {
                        document.getElementById('<%=txtconformmessageValue3.ClientID %>').value = "No";
                    }
                }

                $("body").on("change", ".bm_academic_dropdown", function() {
                    //alert("hi");
                    document.getElementById('<%=message.ClientID %>').innerHTML = "";
                    document.getElementById('<%=_student.ClientID %>').value = "";
                    $('#<%=GridView1.ClientID %>').empty();
                    $('#<%=result.ClientID %>').hide();
                    $('#<%=barchart.ClientID %>').hide();
                    $('#<%=btnApprove.ClientID %>').hide();
                    $('#<%=btnSave.ClientID %>').hide();
                });

                $("body").on("click", ".bm_button_reload", function() {
                    alert("hi");
                });

            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">All Class Test Approval</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>
                <%--  <div class="bm_academic_container_body_button_section">
                    <div class="button_section_padding" >
                        <div class="button_section_style1">
                            
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="bm_academic_button1 bm_am_btn_approve"
                               />
                        </div>
                    </div>
                </div>--%>
                <div class="bm_academic_container_footer">
                    <div class="footer_list_padding2">
                        <div style="margin-left: 15px; margin-bottom: 5px; width: 100%;">
                            <%--<div class="bm_ctl_container_100_special" style="display: inline-block;">
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
                            <%--<div class="bm_ctl_container_100_special" style="display: inline-block; margin-left: 700px;
                                border: none">
                                <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                    <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                </div>
                            </div>--%>
                        </div>
                        <div class="bm_academic_grid_container" id="list" runat="server">
                            <div class="grid_header">
                                <%--<div class="grid_header_label" id="_grid_header" runat="server">
                           
                        </div>--%>
                                <div class="grid_header_control" style="margin-left: 15px; margin-top: 5px;">
                                    <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                            <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 103px">
                                            <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                            <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 58px">
                                            <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 103px">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                >
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
                                               >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%-- <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label5" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <%--<div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                            <asp:Label ID="Label6" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 184px">
                                            <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px;">
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
                                </div>
                                <div class="flot_right">
                                    <%-- <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>--%>
                                    <%-- <div class="grid_header_row">
                                <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                    OnTextChanged="fnFilterByRow"></asp:TextBox>
                            </div>--%>
                                    <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 200px; margin-top: 3px;margin-right: 10px">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label12" runat="server" Text="From :" AssociatedControlID="xfrom"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 74%; ">
                                    <asp:TextBox ID="xfrom" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="bm_ctl_container_50_50" style="float: left; width: 200px; margin-top: 3px;margin-right: 10px">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label1" runat="server" Text="To :" AssociatedControlID="xto"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 74%; ">
                                    <asp:TextBox ID="xto" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                </div>
                            </div>--%>
                                    <%--  <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                margin-right: 10px">
                                <div class="bm_ctl_label_align_right_100_special">
                                    <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_special">
                                    <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown" AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                                    <%-- <div class="bm_ctl_container_100_special" style="float: left; margin-top: 3px; margin-right: 10px;
                                        width: 122px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <%--<div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                        margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                        margin-right: 10px;">
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
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                        margin-right: 10px; display: none;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xgroup"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 210px; margin-top: 3px;
                                        margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label5" runat="server" Text="Month :" AssociatedControlID="xdate"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xdate" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        border: none; height: 32px; margin-right: 15px">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                    <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                Width="25px" Height="25px" OnClientClick="fnPrintNumSchedule();" OnClick="fnFillDataGrid"
                                                CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="grid_body">
                                <div style="float: left; width: 350px; margin-top: 18px;">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="false"
                                        CssClass="bm_academic_grid5 bm_academic_grid4" FooterStyle-CssClass="FooterStyle"
                                        RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                        PagerStyle-CssClass="PagerStyle" GridLines="None" OnDataBound="GridView1_DataBound1"
                                        OnRowDataBound="OnRowDataBound" UseAccessibleHeaderText="true" RowStyle-Height="30" >
                                        <HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="Days">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("SelectedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("section") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="bm_academic_container_body_button_section" >
                                        <div class="button_section_padding" style="margin-top: 8px; padding-left: 0px;">
                                            
                                            <div class="button_section_style1" style="text-align: left;">
                                                 <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button4 bm_am_btn_save" 
                                                OnClick="btnSave_Click"/>
                                                <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="bm_academic_button4 bm_am_btn_approve" 
                                                OnClientClick="javascript:ConfirmMessage3();" OnClick="btnApprove_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="float: left; width: 300px; border: 1px solid #65BC46; margin-top: 20px;
                                    margin-left: 50px;" runat="server" id="result">
                                    <div style="text-align: center; color: #fff; background-color: #65BC46; padding-bottom: 5px;
                                        padding-top: 5px; font-size: 14px; font-weight: bold;">
                                        CLASS TEST RESULT AT A GLANCE
                                    </div>
                                    <div style="text-align: center; color: #fff; background-color: #ABD693; padding-bottom: 5px;
                                        padding-top: 5px;">
                                        <table style="width: 100%; border-collapse: collapse; border: none;color: #000000">
                                            <tr>
                                                <td style="width: 30%;">
                                                    Subject
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="xsubject" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%;">
                                                    Take Best
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="xbest" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 100%; background-color: #E5F1D4; padding-top: 10px; padding-left: 10px;">
                                        <table style="width: 100%; border-collapse: collapse; border: none;color: #000000">
                                            <tr>
                                                <td style="width: 60%;">
                                                    Number of students
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="xnostd" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 60%;">
                                                    Subject taken
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="xtaken" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 60%;">
                                                    Absent in exam
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="xabsent" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 100%; background-color: #E5F1D4; padding-top: 15px;" runat="server"
                                        id="grade">
                                        <%--  <table style="width: 100%; border-collapse: collapse; border: none;">
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    90% - 100%
                                                </td>
                                                <td style="width: 20%;">
                                                    A*
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="xaa" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    80% - 89%
                                                </td>
                                                <td style="width: 20%;">
                                                    A
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="xa" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    70% - 79%
                                                </td>
                                                <td style="width: 20%;">
                                                    B
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="xb" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    60% - 69%
                                                </td>
                                                <td style="width: 20%;">
                                                    C
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    50% - 59%
                                                </td>
                                                <td style="width: 20%;">
                                                    D
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    Bellow 50%
                                                </td>
                                                <td style="width: 20%;">
                                                    U
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #CEE5B7">
                                                <td style="width: 50%; text-align: right; padding-right: 30px;">
                                                    Bellow 40%
                                                </td>
                                                <td style="width: 20%;">
                                                </td>
                                                <td style="width: 30%; padding-left: 10px;">
                                                    <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </div>
                                    <div style="width: 100%; background-color: #E5F1D4; padding-top: 10px; padding-left: 10px;
                                        padding-top: 5px; padding-bottom: 10px">
                                        <table style="width: 100%; border-collapse: collapse; border: none;color: #000000">
                                            <tr>
                                                <td style="width: 30%;">
                                                    Subj. Teacher
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%;">
                                                    Class Teacher
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%;">
                                                    C.Coordinator
                                                </td>
                                                <td style="width: 10%;">
                                                    :
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div style="float: left; width: 420px; margin-left: 20px;" runat="server" id="barchart">
                                    <div style="float: left; width: 400px;"  runat="server" id="barchart1">
                                        <asp:Chart ID="Chart1" runat="server" Width="400" Height="440">
                                            <%--  <Titles>
                                                <asp:Title Text="Class test result statistics">
                                                </asp:Title>
                                            </Titles>--%>
                                            <Series>
                                                <asp:Series Name="Series1" ChartArea="ChartArea1"  >
                                                    <%--   <Points>
                                                    <asp:DataPoint AxisLabel="A*" YValues="56" />
                                                    <asp:DataPoint AxisLabel="A" YValues="25" />
                                                    <asp:DataPoint AxisLabel="B" YValues="11" />
                                                    <asp:DataPoint AxisLabel="C" YValues="10" />
                                                    <asp:DataPoint AxisLabel="D" YValues="5" />
                                                    <asp:DataPoint AxisLabel="U" YValues="2" />
                                                </Points>--%>
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1">
                                                    <AxisX Title="Grade" LineColor="Black">
                                                        <MajorGrid Enabled="False" />
                                                    </AxisX>
                                                    <%-- <AxisY Title="Marks" Minimum="0" Maximum="100" IntervalOffset="10" Interval="10" IntervalOffsetType="Number" IntervalType="Number">
                                                </AxisY>--%>
                                                    <AxisY Title="Student" LineColor="Black" Interval="10">
                                                        <MajorGrid Enabled="true" LineColor="Silver" />
                                                    </AxisY>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                        <%--<asp:Chart ID="Chart1" runat="server">
                                        <Series>
                                            <asp:Series Name="Series1">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>--%>
                                    </div>
                                    <div style="float: left; width: 20px; padding-top: 20px;" runat="server" id="colorcode">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 100%; height: 15px; margin-bottom: 15px; color: #fff; clear: both;">
                ------
            </div>
            <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                OnTextChanged="fnFilterByRow"></asp:TextBox>
            <asp:HiddenField ID="ctlid_v" runat="server" />
            <asp:HiddenField ID="_xdate" runat="server" />
            <asp:HiddenField ID="hiddenxdate" runat="server" />
            <asp:HiddenField ID="hiddenxrow" runat="server" />
            <asp:HiddenField ID="hiddenxstatus" runat="server" />
            <asp:HiddenField ID="_student" runat="server" />
            <asp:HiddenField ID="txtconformmessageValue3" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
