<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="asctappstco_copy.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.asctappstco_copy"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function fnPrintNumSchedule() {
           <%-- // alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession = $("#<%= xsession.ClientID%>").val();
            var xterm = $("#<%= xterm.ClientID%>").val();
            var xclass = $("#<%= xclass.ClientID%>").val();
            var xgroup = $("#<%= xgroup.ClientID%>").val();
            var xsection = $("#<%= xsection.ClientID%>").val();
            var xdate = $("#<%= hiddenxdate.ClientID%>").val();
            var xrow = $("#<%= hiddenxrow.ClientID%>").val();
            var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/rptasctschvwsw1.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup + '&xsection=' + xsection + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            openwin.print();
            //return false;--%>
        }
    </script>
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
            $("body").on("click", ".bm_student", function () {
                fnOpenStudentList1(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _student.ClientID%>").attr("ID"),$("#<%= xclass.ClientID%>").val(),$("#<%= xsession.ClientID%>").val(),$("#<%= xgroup.ClientID%>").val(),$("#<%= xsection.ClientID%>").val(),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

             $("body").on("click", ".bm_circle_button_coordinator", function () {
                 var row = this.parentNode.parentNode;
                 var rowIndex = row.rowIndex - 1;
                 var cell = this.parentNode.cellIndex;

                 var grid = document.getElementById('<%=GridView1.ClientID %>');

                 //alert(grid.rows[rowIndex+1].cells[cell].children[0].title);

                 var test = grid.rows[rowIndex + 1].cells[cell].children[0].title.split("\n");
                 var test1 = test[0].split("-");
                 //alert(str[0]);
//                 var col = grid.rows[rowIndex + 1].cells.length;
//                 alert(grid.rows[rowIndex + 1].cells[1].innerText);
                 //var subject = grid.rows[rowIndex + 1].cells[1].innerText.split("-");
//                 if (typeof subject[1] != 'undefined') {
//                  alert(subject[1]);
//                 }


                 var xsession1 = $("#<%= xsession.ClientID%>").val();
                 var xterm1 = $("#<%= xterm.ClientID%>").val();
                 var xclass1 = $("#<%= xclass.ClientID%>").val();
                 var xgroup1 = $("#<%= xgroup.ClientID%>").val();
                 var xsection1 = $("#<%= xsection.ClientID%>").val();
                 //var xsubject1 = subject[0];
                 //var xpaper1 = "";
                 //if (typeof subject[1] != 'undefined') {
                 //    xpaper1 = subject[1];
                 //}

                 var xsubject1 = grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length-3].innerText;
                 var xpaper1 = "";
                 if (typeof grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length-2].innerText != 'undefined') {
                     xpaper1 = grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length-2].innerText;
                 }
                 var xext1 = "";
                 if (typeof grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length-1].innerText != 'undefined') {
                     xext1 = grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length-1].innerText;
                 }

                 var xcttype1 = test1[0];
                 var xctno1 = test1[1];

                 var left = Math.round((screen.width / 2) - (500 / 2));
                 var top = Math.round((screen.height / 2) - (500 / 2));
                 var openwin = window.open("/forms/academic/assesment/mark-input/amexamh2.aspx?subnav=myDropdown44&link=LinkButton44&xsession=" + xsession1 + "&xterm=" + xterm1 + "&xclass=" + xclass1 + "&xgroup=" + xgroup1 + "&xsection=" + xsection1 + "&xsubject=" + xsubject1.replace(/&/gi, "%26") + "&xpaper=" + xpaper1 + "&xext=" + xext1 + "&xcttype=" + xcttype1 + "&xctno=" + xctno1,'ctstco','toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=600, height=500, top=' + top + ', left=' + left + ', targets=_blank');
                 openwin.focus();

             });

            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Class Test Approval Status (Class Coordinator)</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>
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
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 103px">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
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
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label5" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
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
                            <div class="grid_body" style="width: 1229.4px; overflow: auto;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                    CssClass="bm_academic_grid1 bm_academic_grid4" FooterStyle-CssClass="FooterStyle"
                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnDataBound="GridView1_DataBound1"
                                    OnRowDataBound="OnRowDataBound" UseAccessibleHeaderText="true">
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                OnTextChanged="fnFilterByRow"></asp:TextBox>
            <asp:HiddenField ID="ctlid_v" runat="server" />
            <asp:HiddenField ID="_xdate" runat="server" />
            <asp:HiddenField ID="hiddenxdate" runat="server" />
            <asp:HiddenField ID="hiddenxrow" runat="server" />
            <asp:HiddenField ID="hiddenxstatus" runat="server" />
            <asp:HiddenField ID="_student" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
