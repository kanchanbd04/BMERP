<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="amworksheetteacher1.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.amworksheetteacher1"
    EnableEventValidation="false" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        tr.BorderRow td {
            border-top: 2px solid #000000;
        }

        .link {
            text-align: center;
            font-size: 16px;
        }

        .image:hover {
            /*width: 85px;
            height: 85px;*/
            transform: scale(1.2);
        }

        a {
            text-decoration: none;
        }

            a:hover {
                text-decoration: underline;
            }

        .link_con {
            display: inline-block;
            vertical-align: top;
            text-align: center;
            /*width: -moz-min-content;
  width: -webkit-min-content;
    width: min-content;*/
            width: 100px;
            padding: 0 10px;
        }

        #_link {
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        function fnPrintNumSchedule() {
            // alert("Hi");
            var zid1 = <%= HttpContext.Current.Session["business"] %>;
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var xterm1 = $("#<%= xterm.ClientID%>").val();
            var xclass1 = $("#<%= xclass.ClientID%>").val();
            var xgroup1 = $("#<%= xgroup.ClientID%>").val();
            var xsection1 = $("#<%= xsection.ClientID%>").val();

             

            var openwin = window.open('/forms/academic/reports/rpttabulation.aspx?zid=' + zid1 + '&xsession=' + xsession1 + '&xterm=' + xterm1 + '&xclass=' + xclass1 + '&xgroup=' + xgroup1 + '&xsection=' + xsection1 , 'tabulation', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            //openwin.print();
            //return false;
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
            <script>
                
                function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
                    var tbl = document.getElementById(gridId);

                    var tbody = tbl.getElementsByTagName("tbody")[0]; //gets the first and only tbody
                    var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's
                    var secondTr = tbody.getElementsByTagName("tr")[1];
                    headerHeight = firstTr.offsetHeight + secondTr.offsetHeight - 10;

                    if (tbl) {
                        var DivHR = document.getElementById('DivHeaderRow');
                        var DivMC = document.getElementById('DivMainContent');
                        var DivFR = document.getElementById('DivFooterRow');

                        //*** Set divheaderRow Properties ****
                        DivHR.style.height = headerHeight + 'px';
                        DivHR.style.width = (parseInt(width) - 17) + 'px';
                        DivHR.style.position = 'relative';
                        DivHR.style.top = '0px';
                        DivHR.style.zIndex = '10';
                        DivHR.style.verticalAlign = 'top';

                        //*** Set divMainContent Properties ****
                        DivMC.style.width = width + 'px';
                        DivMC.style.height = height + 'px';
                        DivMC.style.position = 'relative';
                        DivMC.style.top = -headerHeight + 'px';
                        DivMC.style.zIndex = '1';

                        //*** Set divFooterRow Properties ****
                        DivFR.style.width = (parseInt(width) - 16) + 'px';
                        DivFR.style.position = 'relative';
                        DivFR.style.top = -headerHeight + 'px';
                        DivFR.style.verticalAlign = 'top';
                        DivFR.style.paddingtop = '2px';

                        if (isFooter) {
                            var tblfr = tbl.cloneNode(true);
                            tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
                            var tblBody = document.createElement('tbody');
                            tblfr.style.width = '100%';
                            tblfr.cellSpacing = "0";
                            tblfr.border = "0px";
                            tblfr.rules = "none";
                            //*****In the case of Footer Row *******
                            tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
                            tblfr.appendChild(tblBody);
                            DivFR.appendChild(tblfr);
                        }
                        //****Copy Header in divHeaderRow****
                        DivHR.appendChild(tbl.cloneNode(true));
                    }
                }



                function OnScrollDiv(Scrollablediv) {
                    document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
                    document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
                }


                function fnPageLoad() {

                    <%--$("#<%= GridView1.ClientID %>").chromatable({

                        width: "100%", // specify 100%, auto, or a fixed pixel amount
                        height: "500px",
                        scrolling: "yes" // must have the jquery-1.3.2.min.js script installed to use

                    });--%>
                }

                $(document).ready(function () {


                    //fnPageLoad();
                });

                //var prm = Sys.WebForms.PageRequestManager.getInstance();
                //prm.add_endRequest(function () {
                //    fnPageLoad();
                //});

                $("body").on("change", ".bm_academic_dropdown", function () {

                    $("#<%= message.ClientID %>").empty();
                    //$(".grid_body").empty();
                    $("#DivRoot").empty();
                    //return false;
                });

                function fnOpenUpload(xsubject,xpaper,xext) {
                     //alert("Hi");
                   var zid = <%= HttpContext.Current.Session["business"] %>;
                    var xsession = $("#<%= xsession.ClientID%>").val();
                    var xterm = $("#<%= xterm.ClientID%>").val();
                    var xclass = $("#<%= xclass.ClientID%>").val();
                    var xsection = $("#<%= xsection.ClientID%>").val();

                    var openwin = window.open('/forms/academic/worksheet/amuploadteacher.aspx?zid='+zid+'&xsession='+xsession+'&xterm='+xterm+'&xclass='+xclass+'&xsection='+xsection+'&xsubject='+xsubject.replace(/&/gi, "%26")+'&xpaper='+xpaper+'&xext='+xext,'uploadteacher', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
                    openwin.focus();
                    //openwin.print();
                    return false;
                }

                $("body").on("click", ".bm_uploadhomework", function () {

                    //                alert("Hi");
                    //                return false;

                    var mendatoryFields = [
                                         { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xterm.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" }
                    ];
                    var mendatoryString = JSON.stringify(mendatoryFields);
                    if (!fnMendatoryFields1(mendatoryString)) {
                        return false;
                    }
                    return true;
                });

            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Homework</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>
                <div class="bm_academic_container_footer">
                    <div class="footer_list_padding2">



                        <div class="bm_academic_grid_container" id="list" runat="server">
                            <div class="grid_header" style="background-color: #40803C;">
                                <div class="grid_header_label" id="_grid_header" runat="server" style="font-size: 20px; line-height: 1.5em">
                                    Upload Homeworks
                                </div>
                                <div class="grid_header_control">
                                </div>
                                <div class="flot_right">
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px; width: 122px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px; display: none">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label4" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="bm_ctl_container_100_special" style="float: left; width: 210px; margin-top: 3px;
                                margin-right: 10px;">
                                <div class="bm_ctl_label_align_right_100_special">
                                    <asp:Label ID="Label5" runat="server" Text="Month :" AssociatedControlID="xdate"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_special">
                                    <asp:DropDownList ID="xdate" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown" AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px; margin-right: 20px;">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnUploadHomeworks" CssClass="bm_academic_button_zoom bm_uploadhomework" />
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
                            <div id="DivRoot" align="left" style="display: none">
                                <div style="overflow: hidden;" id="DivHeaderRow">
                                </div>

                                <div style="overflow: auto;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                                    <%--<div class="grid_body" style="width: 1229.4px; overflow: auto;height: 600px">--%>
                                    <%--style="width: 1229.4px; overflow: auto;height: 600px"--%>
                                    <%-- <div id="GHead"></div>--%>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                        CssClass="bm_academic_grid10" FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle"
                                        AlternatingRowStyle-CssClass="AlternatingRowStyle" PagerStyle-CssClass="PagerStyle"
                                        GridLines="None" OnDataBound="GridView1_DataBound1" OnRowDataBound="OnRowDataBound">
                                        <%--<HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>--%>
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
                                    <%--</div>--%>
                                </div>

                                <div id="DivFooterRow" style="overflow: hidden">
                                </div>
                            </div>

                            <div runat="server" id="upload_homeworks" style="width: 100%; margin-top: 5px;">
                            </div>

                        </div>



                        <div class="bm_academic_grid_container" id="Div1" runat="server" style="margin-top: 40px">
                            <div class="grid_header" style="background-color: #6852A2;">
                                <div class="grid_header_label" id="Div2" runat="server" style="font-size: 20px; line-height: 1.5em">
                                    Students' Feedback
                                </div>
                                <div class="grid_header_control">
                                </div>
                                <div class="flot_right">
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label5" runat="server" Text="Session :" AssociatedControlID="xsession1"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsession1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px; width: 122px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label6" runat="server" Text="Term :" AssociatedControlID="xterm1" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xterm1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label7" runat="server" Text="Class :" AssociatedControlID="xclass1"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xclass1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px; display: none">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label8" runat="server" Text="Group :" AssociatedControlID="xgroup1"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xgroup1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label9" runat="server" Text="Section :" AssociatedControlID="xsection1"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px; margin-right: 20px;">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnStudentFeedback" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div runat="server" id="students_feedback" style="width: 100%; margin-top: 5px;">
                            </div>

                        </div>



                        <div class="bm_academic_grid_container" id="Div3" runat="server" style="margin-top: 40px">
                            <div class="grid_header">
                                <div class="grid_header_label" id="Div4" runat="server" style="font-size: 20px; line-height: 1.5em">
                                    Teachers' Feedback
                                </div>
                                <div class="grid_header_control" style="background-color: #007DC5;">
                                </div>
                                <div class="flot_right">
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label10" runat="server" Text="Session :" AssociatedControlID="xsession2"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsession2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px; width: 122px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label11" runat="server" Text="Term :" AssociatedControlID="xterm2" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xterm2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label12" runat="server" Text="Class :" AssociatedControlID="xclass2"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xclass2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px; display: none">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label13" runat="server" Text="Group :" AssociatedControlID="xgroup2"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xgroup2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label14" runat="server" Text="Section :" AssociatedControlID="xsection2"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px; margin-right: 20px;">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnTeacherFeedback" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div runat="server" id="teachers_feedback" style="width: 100%; margin-top: 5px;">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
