<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="amexamhh3.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.amexamhh3"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        <%--   //        function fnPrintNumSchedule() {
        //           // alert("Hi");
        //            var zid = <%= HttpContext.Current.Session["business"] %>;
        //            var xsession = $("#<%= xsession.ClientID%>").val();
        //            var xterm = $("#<%= xterm.ClientID%>").val();
        //            var xclass = $("#<%= xclass.ClientID%>").val();
        //            var xgroup = $("#<%= xgroup.ClientID%>").val();
        //           
        //            var xdate = $("#<%= hiddenxdate.ClientID%>").val();
        //           var xrow = $("#<%= hiddenxrow.ClientID%>").val();
        //           var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
        //              var openwin = window.open('/forms/academic/reports/rptasctschvwsw1.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup + '&xsection=' + xsection + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
        //              openwin.focus();
        //            openwin.print();
        //            //return false;
        //        }--%>
    </script>
    <style>
        tr.BorderRow td {
            border-top: 2px solid #000000;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
        <ContentTemplate>

            <script type="text/javascript" language="javascript">

                function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
                    var tbl = document.getElementById(gridId);

                    var tbody = tbl.getElementsByTagName("tbody")[0]; //gets the first and only tbody
                    var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's
                    var secondTr = tbody.getElementsByTagName("tr")[1];
                    headerHeight = firstTr.offsetHeight + secondTr.offsetHeight;

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

                    <%-- $("#<%= GridView1.ClientID %>").chromatable({

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


                $("body").on("click", ".btnComments", function () {
                    //alert("Hi");
                    var row = this.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.cellIndex;


                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    var term = grid.rows[rowIndex + 1].cells[cell + 6].innerText;
                    var btnid = grid.rows[rowIndex + 1].cells[cell].children[0].id;
                    //var student = grid.rows[rowIndex + 1].cells[1].innerText.split("\n");
                    //alert(btnid);
                    //return;
                    $('#hbtnid').val(btnid);
                    <%--$('#term').html($("#<%= xterm.ClientID%>").val() + " Term");--%>
                    $('#term').html(term + " Term");
                    $('#stdid').html(grid.rows[rowIndex + 1].cells[cell + 5].innerText);
                    $('#stdname').html(grid.rows[rowIndex + 1].cells[cell + 4].innerText);
                    //$("#" + btnid).css("background-color", "#8A2BE2");
                    //alert(grid.rows[rowIndex + 1].cells[cell + 3].innerText);
                    $('#hxsession').val($("#<%= xsession.ClientID%>").val());
                    $('#hxterm').val(term);
                    $('#hxclass').val($("#<%= xclass.ClientID%>").val());
                    $('#hxgroup').val($("#<%= xgroup.ClientID%>").val());
                    $('#hxsection').val(grid.rows[rowIndex + 1].cells[cell + 3].innerText);
                    $('#hxsrow').val(grid.rows[rowIndex + 1].cells[cell + 2].innerText);
                    //$('#xdetails').val('');

                    $.ajax({
                        url: "amexamhh2.aspx/fnFetchComments",

                        type: "POST",

                        data: "{'xsession1' : '" + $('#hxsession').val() + "', 'xterm1':'" + $('#hxterm').val() + "', 'xclass1' : '" + $('#hxclass').val() + "', 'xgroup1' : '" + $('#hxgroup').val() + "', 'xsection1' : '" + $('#hxsection').val() + "', 'xsrow1' : '" + $('#hxsrow').val() + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            var xcom = r.split("|");
                            if (xcom[0] == "success") {
                                $('#xdetails').val(xcom[1]);
                            }
                            else if (xcom[0] == "nodata") {
                                $('#xdetails').val('');
                            } else {
                                alert(r);
                                $('#xdetails').val('');
                            }


                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                            $('#xdetails').val('');

                        }


                    });

                    $find('modalpopup').show();


                });

                $("body").on("click", "#btnOk", function () {

                    //alert('Hi');
                    // $("#" + $('#hbtnid').val()).css("background-color", "#8A2BE2");
                    //$("#" + $('#hbtnid').val()).attr("title", $('#xdetails').val());
                    //alert($('#xdetails').val());

                    $.ajax({
                        url: "amexamhh2.aspx/fnInsetComments",

                        type: "POST",

                        data: "{'xsession1' : '" + $('#hxsession').val() + "', 'xterm1':'" + $('#hxterm').val() + "', 'xclass1' : '" + $('#hxclass').val() + "', 'xgroup1' : '" + $('#hxgroup').val() + "', 'xsection1' : '" + $('#hxsection').val() + "', 'xsrow1' : '" + $('#hxsrow').val() + "' , 'xremarks1' : '" + $('#xdetails').val() + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            if (r != "success") {
                                alert(r);

                            }
                            else {
                                $("#" + $('#hbtnid').val()).css("background-color", "#64B446");
                                $("#" + $('#hbtnid').val()).attr("title", $('#xdetails').val());
                                $find('modalpopup').hide();
                            }


                        },
                        error: function (err) {
                            alert("ERROR : " + err);

                        }


                    });

                    //                        $find('modalpopup').hide();

                });

                $("body").on("change", ".bm_academic_dropdown", function () {

                    $("#<%= message.ClientID %>").empty();
                    //$(".grid_body").empty();
                    $("#DivRoot").empty();
                    //return false;
                });
            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Overall Comments on Result</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>
                <div class="bm_academic_container_body1">
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding">
                            <div class="button_section_style1">
                                <%--  <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="bm_academic_button1 bm_am_btn_generate"
                             OnClick="btnGenerate_Click" />--%>
                                <asp:Button ID="btnRefresh" runat="server" Text="Show" CssClass="bm_academic_button1 bm_am_btn_refresh"
                                    OnClick="fnFillDataGrid" />
                                <%--<asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="bm_academic_button1 bm_am_btn_approve" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100">
                                <div class="bm_layout_box_padding">
                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both;">
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label3" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <%--   <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                            AutoPostBack="True" OnTextChanged="combo_OnTextChanged">--%>
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 122px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label8" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label9" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label10" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label5" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <%--Control section end--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_footer">
                        <div class="footer_list_padding2" style="min-height: 320px;">
                            <div class="bm_academic_grid_container" id="list" runat="server">
                                <div id="DivRoot" align="left">
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
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding">
                            <div class="button_section_style1">
                                <%-- <asp:Button ID="btnGenerate1" runat="server" Text="Generate" CssClass="bm_academic_button1 bm_am_btn_generate"
                             OnClick="btnGenerate_Click"/>--%>
                                <asp:Button ID="btnRefresh1" runat="server" Text="Show" CssClass="bm_academic_button1 bm_am_btn_refresh"
                                    OnClick="fnFillDataGrid" />
                                <%-- <asp:Button ID="btnApprove1" runat="server" Text="Approve" CssClass="bm_academic_button1 bm_am_btn_approve" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
                PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modal" BehaviorID="modalpopup" PopupDragHandleControlID="pnlpopup">
            </cc1:ModalPopupExtender>

            <script>
                
                $("body").on("click", ".bm_am_btn_comments", function () {
                    //alert("Button was clicked.");
                    //alert($("#xdetails").attr("ID"));
                    //return;
                    <%--//fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _classteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());--%>
                    fnOpenCommentsBank(<%= HttpContext.Current.Session["business"] %>,$("#xdetails").attr("ID"),$("#<%= xclass.ClientID%>").val(),"Overall Comments");
                });

            </script>

            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="280px" Width="400px"
                Style="display: none">
                <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Add Comments
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding: 5px;">
                            <table style="border: none;">
                                <tr>
                                    <td>Student ID
                                    </td>
                                    <td>:
                                    </td>
                                    <td id="stdid">
                                        <%--<asp:Label ID="lblstdid" runat="server" Text=""></asp:Label>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Student Name
                                    </td>
                                    <td>:
                                    </td>
                                    <td id="stdname">
                                        <%-- <asp:Label ID="lblsection" runat="server" Text=""></asp:Label>--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                      <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Comments for <span id="term"></span>
                        </td>
                    </tr>

                    <tr>
                        <td style="height: 15px; color: white; font-size: 14px; padding-top: 2px; padding-left: 5px;" align="center">
                          <input type="button" id="btnComments" value="Comments Bank" class="bm_academic_button5 bm_am_btn_comments" style="width: 120px;"/>
                        </td>
                    </tr>


                    <tr>
                        <td align="left" style="padding: 5px; ">
                            <textarea id="xdetails" class="bm_academic_textarea_100_50  bm_academic_textarea"
                                style="width: 100%; height: 120px;"></textarea>
                        </td>
                    </tr>




                    <tr>
                        <td align="center" style="padding-bottom: 5px;">
                            <%--<asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="bm_academic_button1 bm_am_btn_ok"
                                     />--%>
                            <input type="button" id="btnOk" value="OK" class="bm_academic_button1 bm_am_btn_ok" />
                            <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="bm_academic_button1 bm_am_btn_cancel" />--%>
                            <input type="button" id="btnCancel" value="Cancel" class="bm_academic_button1 bm_am_btn_cancel" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>



            <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                OnTextChanged="fnFilterByRow"></asp:TextBox>
            <asp:HiddenField ID="ctlid_v" runat="server" />
            <asp:HiddenField ID="_xdate" runat="server" />
            <asp:HiddenField ID="hiddenxdate" runat="server" />
            <asp:HiddenField ID="hiddenxrow" runat="server" />
            <asp:HiddenField ID="hiddenxstatus" runat="server" />
            <input id="hbtnid" type="hidden" />
            <input id="hxsession" type="hidden" />
            <input id="hxterm" type="hidden" />
            <input id="hxclass" type="hidden" />
            <input id="hxgroup" type="hidden" />
            <input id="hxsection" type="hidden" />
            <input id="hxsrow" type="hidden" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
