﻿<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="amdoublepro_approve.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.amdoublepro_approve" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .modalBackground {
            /*background-color: Gray;
            z-index: 10000;*/
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            left: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .modal {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            left: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 110px;
            }

            .displaynone {
                display: none;
            }

        /*.bm_academic_grid1 tr:nth-child(6) td{
    padding: 2px; 
    border-bottom: solid 2px #000000; 
    color: #000000;
    padding-left: 3px;
    font-weight: normal;
     font-size: 14px;
     font-family: Myriad Pro,tahoma; 
}*/
    </style>
    <%-- <style type="text/css">
 
 .GridViewScrollHeader TH, .GridViewScrollHeader TD {
    padding: 10px;
    font-weight: normal;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #F4F4F4;
    color: #999999;
    text-align: left;
    vertical-align: bottom;
}

.GridViewScrollItem TD {
    padding: 10px;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #FFFFFF;
    color: #444444;
}

.GridViewScrollItemFreeze TD {
    padding: 10px;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #FAFAFA;
    color: #444444;
}

.GridViewScrollFooterFreeze TD {
    padding: 10px;
    white-space: nowrap;
    border-right: 1px solid #e6e6e6;
    border-top: 1px solid #e6e6e6;
    border-bottom: 1px solid #e6e6e6;
    background-color: #F4F4F4;
    color: #444444;
}
    </style>--%>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({ message: '<table align = "center"><tr><td>' +
                        '<img src="/images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: { backgroundColor: '#000000', opacity: 0.6
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
             
            });
        }

        $(document).ready(function () {

            BlockUI("<%=pnlpopup.ClientID %>");
            $.blockUI.defaults.css = {};

            //             $('.bm_subject_teacher').click(function () {
            //            //alert("Hi");
            //            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _subteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            //            });

         

        });

      
        //function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
        //    var tbl = document.getElementById(gridId);

        //    var tbody = tbl.getElementsByTagName("tbody")[0]; //gets the first and only tbody
        //    var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's
        //    //var secondTr = tbody.getElementsByTagName("tr")[1];
        //    //headerHeight = firstTr.offsetHeight + secondTr.offsetHeight;
        //    headerHeight = firstTr.offsetHeight;

        //    if (tbl) {
        //        var DivHR = document.getElementById('DivHeaderRow');
        //        var DivMC = document.getElementById('DivMainContent');
        //        var DivFR = document.getElementById('DivFooterRow');

        //        //*** Set divheaderRow Properties ****
        //        DivHR.style.height = headerHeight + 'px';
        //        DivHR.style.width = (parseInt(width) - 17) + 'px';
        //        DivHR.style.position = 'relative';
        //        DivHR.style.top = '0px';
        //        DivHR.style.zIndex = '10';
        //        DivHR.style.verticalAlign = 'top';

        //        //*** Set divMainContent Properties ****
        //        DivMC.style.width = width + 'px';
        //        DivMC.style.height = height + 'px';
        //        DivMC.style.position = 'relative';
        //        DivMC.style.top = -headerHeight + 'px';
        //        DivMC.style.zIndex = '1';

        //        //*** Set divFooterRow Properties ****
        //        DivFR.style.width = (parseInt(width) - 16) + 'px';
        //        DivFR.style.position = 'relative';
        //        DivFR.style.top = -headerHeight + 'px';
        //        DivFR.style.verticalAlign = 'top';
        //        DivFR.style.paddingtop = '2px';

        //        if (isFooter) {
        //            var tblfr = tbl.cloneNode(true);
        //            tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
        //            var tblBody = document.createElement('tbody');
        //            tblfr.style.width = '100%';
        //            tblfr.cellSpacing = "0";
        //            tblfr.border = "0px";
        //            tblfr.rules = "none";
        //            //*****In the case of Footer Row *******
        //            tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
        //            tblfr.appendChild(tblBody);
        //            DivFR.appendChild(tblfr);
        //        }
        //        //****Copy Header in divHeaderRow****
        //        DivHR.appendChild(tbl.cloneNode(true));
        //    }
        //}



        //function OnScrollDiv(Scrollablediv) {
        //    document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        //    document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        //}


        
    

       

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:LinkButton ID="LinkButton1" runat="server">Reveal Modal...</asp:LinkButton> 

 <asp:Panel ID="Panel1" runat="server"  CssClass="modalPopup" Style="display: none">
                this is the modal<br /><br />
                <asp:Button ID="Button5" runat="server" Text="OK" />
                <asp:Button ID="Button6" runat="server" Text="Cancel" />
</asp:Panel>

<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1" CancelControlID="Button1" DropShadow="true" OkControlID="Button2" PopupControlID="Panel1" BackgroundCssClass="modalBackground">
 </cc1:ModalPopupExtender>--%>
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
                $("body").on("click", ".bm_subject_teacher", function() {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $("#<%= _subteacher.ClientID%>").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });

                $("body").on("click", ".bm_class_teacher", function () {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _classteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });

                // $("body").on("click", ".bm_subject", function () {
                //alert("Button was clicked.");
                //fnOpenSubjectList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                // });

                $("body").on("click", ".bm_list", function () {
                    //alert("Button was clicked.");
                    // alert(this.getAttribute("rowno"));
                    //                 alert(document.getElementById('<%=hxstatus.ClientID %>').value);
                    //                 return;
                    var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                    if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1') {
                        var row = this.parentNode.parentNode;
                        var rowIndex = row.rowIndex - 1;
                        // alert(row.cells[4].getElementsByTagName("textarea")[0].id);
                    
                        fnOpenCommentsList(<%= HttpContext.Current.Session["business"] %>, row.cells[4].getElementsByTagName("textarea")[0].id, row.cells[4].getElementsByTagName("textarea")[0].value);
                     
                    }
                });

                //              $("body").on("click", ".bm_marks", function () {

                //                 var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                //                 if (xst == '' || xst == 'New') {
                //                     var row = this.parentNode.parentNode;
                //                     var rowIndex = row.rowIndex - 1;
                //                     alert(row.cells[3].getElementsByTagName("input")[0].value);
                //                 }
                //             });



                $("body").on("click", ".bm_am_btn_save", function () {

                    //                alert("Hi");
                    //                return false;

                    var mendatoryFields = [
                              { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xstdid.ClientID%>", "prop": "listtext", "tab": "0" }
                                <%--    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsubject.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xdate.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= xmarks.ClientID%>", "prop": "text", "tab": "0" }--%>
                    ];
                    var mendatoryString = JSON.stringify(mendatoryFields);
                    if (!fnMendatoryFields1(mendatoryString)) {
                        return false;
                    }


                    return true;
                });

                $("body").on("click", ".btnok", function () {

                    //                alert("Hi");
                    //                return false;

                    var mendatoryFields = [
                             <%-- { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xstdid.ClientID%>", "prop": "listtext", "tab": "0" }--%>
                                <%--    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xsubject.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xdate.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= xmarks.ClientID%>", "prop": "text", "tab": "0" }--%>
                    ];
                    //var mendatoryString = JSON.stringify(mendatoryFields);
                    //if (!fnMendatoryFields1(mendatoryString)) {
                    //    return false;
                    //}

               <%--     var xdateacc1 = $("#<%=xdateacc.ClientID%>").val();

                    if (xdateacc1 == "") {
                        alert("Must enter dropout date.");
                        $("#<%=xdateacc.ClientID%>").focus();
                        return false;
                    }--%>

                    return true;
                });

                $("body").on("blur", "#<%=xstdid.ClientID%>", function() {
                    // alert("hi");
                    var zid1 = <%= HttpContext.Current.Session["business"] %>;
                    var xstdid1 = $("#<%=xstdid.ClientID%>").val();
                    var xsession1 = $("#<%=xsession.ClientID%>").val();
                    //var zid1 = '100012';
                    //var xstdid1 = '3036';
                    //alert(zid1);

                    $.ajax({
                     type: "POST",
                     url: "/edusoft.asmx/StudentInformation",
                     data: "{ zid: '" + zid1 + "', xstdid:'" + xstdid1 + "', xsession: '" + xsession1 + "' }",
                     dataType: "json",
                     contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            //alert(data.d);
                            var student = JSON.parse(data.d);
                            //alert(student.xclass);xstdname
                            $("#<%=xname.ClientID%>").val(student.xname);
                            $("#<%=xclass.ClientID%>").val(student.xclass);
                            $("#<%=xgroup.ClientID%>").val(student.xgroup);
                            $("#<%=xsection.ClientID%>").val(student.xsection);
                            $("#<%=xfname.ClientID%>").val(student.xfname);
                            $("#<%=xmname.ClientID%>").val(student.xmname);
                        },
                        error: function (r) {
                            alert(r.responseText);
                        },
                        failure: function (r) {
                            alert(r.responseText);
                        }
                    });
                });


                $("body").on("click", ".bm_student", function () {
                    //alert("Hi");
                    //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                   if ($("#<%=hxstatus.ClientID%>").val() == "") {
                         fnOpenStudentList2(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    }

                    $("#<%=xstdid.ClientID%>").focus();

                    var zid1 = <%= HttpContext.Current.Session["business"] %>;
                    var xstdid1 = $("#<%=xstdid.ClientID%>").val();
                    //var zid1 = '100012';
                    //var xstdid1 = '3036';
                    //alert(zid1);

                    <%--$.ajax({
                        url: "/edusoft.asmx/StudentInformation",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify({ zid: zid1, xstdid:xstdid1 }),
                        dataType: "json",
                        method: 'post',
                        success: function (data) {
                            //alert(data.d);
                            $("#<%=xclass.ClientID%>").val(data.d.xclass);
                        },
                        error: function (r) {
                            alert(r.responseText);
                        },
                        failure: function (r) {
                            alert(r.responseText);
                        }
                    });--%>

                    return false;
                });


                $("body").on("click", ".btnpreapp", function () {
                    //alert("Hi");
                    var row = this.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.cellIndex;


                    var grid = document.getElementById('<%=dgvPromotedistNew.ClientID %>');
                    //var term = grid.rows[rowIndex + 1].cells[cell + 6].innerText;
                    //var btnid = grid.rows[rowIndex + 1].cells[cell].children[0].id;
                    //var student = grid.rows[rowIndex + 1].cells[1].innerText.split("\n");
                    //alert(btnid);
                    //return;
                    //$('#hbtnid').val(btnid);
                  <%--  $("#<%=xdateacc.ClientID%>").val("");
                    $("#<%=xdetails.ClientID%>").val("");--%>
                    //$('#term').html(term + " Term");
                    $('#stdid').html(grid.rows[rowIndex + 1].cells[2].innerText);
                    //$('#stdname').html(grid.rows[rowIndex + 1].cells[3].innerText);
                    //$('#stdsession').html(grid.rows[rowIndex + 1].cells[1].innerText);
                    //$('#stdrow').html(grid.rows[rowIndex + 1].cells[cell+2].innerText);

                   <%-- $("#<%=lblstdid.ClientID%>").val(grid.rows[rowIndex + 1].cells[2].innerText);
                    $("#<%=lblstdname.ClientID%>").val(grid.rows[rowIndex + 1].cells[3].innerText);
                    $("#<%=lblstdsession.ClientID%>").val(grid.rows[rowIndex + 1].cells[1].innerText);--%>
                   <%-- $("#<%=lblstdrow.ClientID%>").val(grid.rows[rowIndex + 1].cells[cell+2].innerText);--%>

                    <%-- 
                    $("#<%=hstdname.ClientID%>").val(grid.rows[rowIndex + 1].cells[3].innerText);
                    --%>
                    $("#<%=hstdid.ClientID%>").val(grid.rows[rowIndex + 1].cells[2].innerText);
                    $("#<%=hstdsession.ClientID%>").val(grid.rows[rowIndex + 1].cells[1].innerText);
                    $("#<%=hstdrow.ClientID%>").val(grid.rows[rowIndex + 1].cells[cell+2].innerText);

                    //alert(grid.rows[rowIndex + 1].cells[cell + 2].innerText);

                    //$("#" + btnid).css("background-color", "#8A2BE2");
                    //alert(grid.rows[rowIndex + 1].cells[cell + 3].innerText);
                    <%--$('#hxsession').val($("#<%= xsession.ClientID%>").val());
                        $('#hxterm').val(term);
                        $('#hxclass').val($("#<%= xclass.ClientID%>").val());
                        $('#hxgroup').val($("#<%= xgroup.ClientID%>").val());
                    $('#hxsection').val(grid.rows[rowIndex + 1].cells[cell + 3].innerText);
                    $('#hxsrow').val(grid.rows[rowIndex + 1].cells[cell + 2].innerText);--%>
                    //$('#xdetails').val('');

                    //$.ajax({
                    //    url: "amexamhh2.aspx/fnFetchComments",

                    //    type: "POST",

                    //    data: "{'xsession1' : '" + $('#hxsession').val() + "', 'xterm1':'" + $('#hxterm').val() + "', 'xclass1' : '" + $('#hxclass').val() + "', 'xgroup1' : '" + $('#hxgroup').val() + "', 'xsection1' : '" + $('#hxsection').val() + "', 'xsrow1' : '" + $('#hxsrow').val() + "'}",

                    //    //dataType: "json",
                    //    contentType: "application/json; charset=utf-8",

                    //    async: false,
                    //    success: function(res) {

                    //        var r = res.d;
                    //        var xcom = r.split("|");
                    //        if (xcom[0] == "success") {
                    //            $('#xdetails').val(xcom[1]);
                    //        } else if (xcom[0] == "nodata") {
                    //            $('#xdetails').val('');
                    //        } else {
                    //            alert(r);
                    //            $('#xdetails').val('');
                    //        }


                    //    },
                    //    error: function(err) {
                    //        alert("ERROR : " + err);
                    //        $('#xdetails').val('');

                    //    }


                    //});

                    $find('modalpopup').show();


                });
              

                function ConfirmMessage() {
                    var selectedvalue = confirm("Do you want to submit record? After submit cann't change record.");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
                    } else {
                        document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
                    }
                }

                function ConfirmMessage1() {
                    var selectedvalue = confirm("Do you want to parmanently delete this record?");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "No";
            }
        }


        function fnPrintSchedule() {
            // alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
                    <%-- var xsession = $("#<%= xsession.ClientID%>").val();
            var xterm = $("#<%= xterm.ClientID%>").val();--%>
                    <%--var xclass = $("#<%= xclass.ClientID%>").val();
                    var xgroup = $("#<%= xgroup.ClientID%>").val();--%>
                    var xdate = $("#<%= hiddenxdate.ClientID%>").val();
                    var xrow = $("#<%= hiddenxrow.ClientID%>").val();
                    var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
                    var openwin = window.open('/forms/academic/reports/rptasctschvwsw.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup  + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
                    openwin.focus();
                    openwin.print();
                    //return false;
                }


                <%--   window.onload = function () {
                    var gridViewScroll = new GridViewScroll({
                        elementID : "<%= GridView1.ClientID%>" // Target element id
                    });
                    gridViewScroll.enhance();
                }--%>
           
                <%--$(document).ready(function () {
          //gridviewScroll();
            var gridViewScroll = new GridViewScroll({
                elementID : "<%=GridView1.ClientID%>", // Target element id
                width : "100%", // Integer or String(Percentage)
                height : 500, // Integer or String(Percentage)
                freezeColumn : true, // Boolean
            freezeFooter : false, // Boolean
            freezeColumnCssClass : "GridViewScrollItem", // String
            freezeFooterCssClass : "", // String
            freezeHeaderRowCount : 1, // Integer
            freezeColumnCount : 1 // Integer
            });

            gridViewScroll.enhance();--%>
                <%-- var html=$("#<%=GridView1.ClientID%>").html();
            $("#<%=GridView1.ClientID%>").html($("#<%=GridView1.ClientID%>").html().replace("<tbody>", "").replace("</tbody>", ""));

            var options = new GridViewScrollOptions();
            options.elementID = "<%=GridView1.ClientID%>";
            options.width = 450;
            options.height = 400;
            options.freezeColumn = true;
            options.freezeFooter = false;
            options.freezeColumnCssClass = "GridViewScrollItemFreeze";
            options.freezeFooterCssClass = "";
            options.freezeHeaderRowCount = 1;
            options.freezeColumnCount = 3;

            gridViewScroll = new GridViewScroll(options);

            gridViewScroll.enhance();
        });--%>
  
                <%--  function gridviewScroll() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                        width: 200,
                        height: 100,
                        freezesize: 1
                    });
                }--%> 
            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Class Interchange Approve</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                        <%-----THIS IS MESSAGE SECTION-----%>
                    </div>
                </div>
                <div class="bm_academic_container_body1" >
                    <div class="bm_academic_container_body_button_section" style="display: none;">
                        <div class="button_section_padding" style="border-bottom: 0px;">
                            <div class="button_section_style1" style="text-align: left; margin-bottom: 5px;">
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                    OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Approve" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section" style="display: none;">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100">
                                <div class="bm_layout_box_padding" style="padding-top: 0px;">
                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both;">

                                        <%--  <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                    <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                        <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_special" style="width: 103px">
                                        <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                            AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                                <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--  <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                    <div class="bm_ctl_label_align_right_100_special">
                                        <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_special">
                                        <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                            AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>--%>
                                        <%--  <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
                                    <div class="bm_ctl_label_align_right_100_special">
                                        <asp:Label ID="Label4" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_special">
                                        <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                            AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>--%>
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
                                        <%-- <div class="bm_ctl_container_50_50" style="display: inline-block; width: 32px; margin-top: 5px; border: none; height: 32px; padding-top: 6px">

                                    <div class="bm_clt_ctl_50_50" style="width: 100%;">

                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/reload70.png"
                                            Width="25px" Height="25px" OnClick="btnRefresh_Click" CssClass="bm_academic_button_zoom" />
                                    </div>
                                </div>--%>

                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                                <asp:Label ID="Label6" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 184px">
                                                <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--  <div class="bm_ctl_container_100_special" style="display: inline-block; width: 260px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 74px">
                                                <asp:Label ID="Label14" runat="server" Text="Extension :" AssociatedControlID="xext"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 184px">
                                                <asp:DropDownList ID="xext" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 55px">
                                                <asp:Label ID="Label7" runat="server" Text="Paper :" AssociatedControlID="xpaper"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 53px;">
                                                <asp:DropDownList ID="xpaper" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--    <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                                <asp:Label ID="Label7" runat="server" Text="Paper :" AssociatedControlID="xpaper"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xpaper" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="width: 32px; padding-top: 6px;
                                            border: none; height: 32px;display: inline-block">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                    Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; padding-left: 15px;
                                            border: none">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="width: 32px; padding-top: 6px; border: none;
                                            height: 32px; display: inline-block; padding-left: 60px;">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                    Width="25px" Height="25px" OnClientClick="fnPrintSchedule();" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div style="width: 100%; clear: both; padding-top: 5px">

                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label8" runat="server" Text="Test Type :" AssociatedControlID="xcttype"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 103px">
                                                <asp:DropDownList ID="xcttype" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xcttype_Click">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 130px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 65px">
                                                <asp:Label ID="Label9" runat="server" Text="Test No :" AssociatedControlID="xctno"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 63px">
                                                <asp:DropDownList ID="xctno" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xctno_Click">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block;" runat="server"
                                            id="retestfor">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label11" runat="server" Text="Reference :" AssociatedControlID="xreference"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 103px">
                                                <asp:DropDownList ID="xreference" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xreference_Click">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 210px"
                                            runat="server" id="schedule_d">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 100px">
                                                <asp:Label ID="Label13" runat="server" Text="Schedule Date :" AssociatedControlID="xschdate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 108px">
                                               
                                                <asp:TextBox ID="xschdate" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--  <div class="bm_ctl_container_100_special" style="display: inline-block; width: 210px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                                <asp:Label ID="Label3" runat="server" Text="Exam Date :" AssociatedControlID="xdate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 133px">
                                                <asp:TextBox ID="xdate" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_datepicker"
                                                    ></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; width: 350px"
                                            runat="server" id="xreason_d">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 65px">
                                                <asp:Label ID="Label12" runat="server" Text="Reason :" AssociatedControlID="xreason"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 282px">
                                                <asp:TextBox ID="xreason" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--  <div class="bm_ctl_container_100_special" style="display: inline-block; width: 100px">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                                <asp:Label ID="Label10" runat="server" Text="Marks :" AssociatedControlID="xmarks"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 48px">
                                                <asp:TextBox ID="xmarks" runat="server" CssClass="bm_academic_textbox_100_special bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--   <div class="bm_ctl_container_100_special" style="display: inline-block; width: 90px">
                                            <div class="bm_ctl_label_align_center_100_special" style="width: 30px">
                                                <asp:Label ID="Label9" runat="server" Text="% " AssociatedControlID="xperc" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 58px">
                                                <asp:DropDownList ID="xperc" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px;
                                            margin-left: 158px;">
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
                                        <%-- <div style="display: inline-block; width: 24%; margin-left: 11px;">
                                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="30px" Height="30px" CssClass="bm_academic_button_zoom" />
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; padding-left: 15px; padding-top: 5px;
                                            border: none">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_100_special" style="display: inline-block; border: none;">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%; padding-top: 5px;">
                                                <asp:LinkButton ID="btnShowList" runat="server">List of Class Test Taken Out</asp:LinkButton>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <%--Control section end--%>
                                    <%-- <div class="am_collapsible_panel" runat="server" id="pnllistct">
                                        <asp:Panel runat="server" ID="panel1" CssClass="am_collapsible_panel_header">
                                            <div class="am_collapsible_panel_htext">
                                                Class Test Taken
                                                <asp:Label runat="server" ID="textLabel" />
                                            </div>
                                            <div class="am_collapsible_panel_himage">
                                                <asp:Image ID="Image1" runat="server" Height="15px" Width="15px" />
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="panel2" CssClass="am_collapsible_panel_body">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="bm_academic_grid2 bm_academic_grid4"
                                                HeaderStyle-CssClass="HeaderStyle" RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xno" runat="server" Text='<%#Eval("xno") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="xcttype" HeaderText="Test Type" ItemStyle-Width="100px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xctno" HeaderText="Test No" ItemStyle-Width="100px" ItemStyle-CssClass="pad5"
                                                        ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="xdate" HeaderText="Test Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="xtopic" HeaderText="Topic" ItemStyle-Width="150px" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xcteacher" HeaderText="Class Teacher" ItemStyle-Width="200px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xsteacher" HeaderText="Subject Teacher" ItemStyle-Width="200px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xremarks" HeaderText="Remarks" ItemStyle-Width="200px"
                                                        ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xstatus" HeaderText="Status" ItemStyle-Width="120px" ItemStyle-CssClass="pad5"
                                                        ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="xrow" HeaderText="Test No" ItemStyle-Width="120px" ItemStyle-CssClass="pad5"
                                                        ItemStyle-HorizontalAlign="Center" Visible="False" />
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                        <cc1:CollapsiblePanelExtender runat="server" ID="cpe" TargetControlID="panel2" CollapseControlID="panel1"
                                            ExpandControlID="panel1" Collapsed="true" CollapsedSize="0" ExpandedText="(Hide List...)"
                                            CollapsedText="(Show List...)" TextLabelID="textLabel" ImageControlID="Image1"
                                            ExpandedImage="~/images/collaps.png" CollapsedImage="~/images/expand.png" ExpandDirection="Vertical">
                                        </cc1:CollapsiblePanelExtender>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px;">
                                <div class="bm_academic_grid_container2" style="width: 100%" id="divliststd" runat="server">


                                    <div style="width: 98%; margin-bottom: 10px; margin-left: 10px;">

                                        <div class="bm_ctl_container_100_special" style="width: 270px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label4" runat="server" Text=" Student ID :" AssociatedControlID="xstdid"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xstdid" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_student" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xstdname" runat="server" Text="" CssClass="xstdname"></asp:Label>
                                            </div>

                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%--<asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass" Enabled="False">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xclass" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%--<asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass" Enabled="False">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xgroup" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%--<asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass" Enabled="False">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xsection" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                          <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 350px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label18" runat="server" Text="Name :" AssociatedControlID="xname"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 228px">
                                                <%--<asp:DropDownList ID="xfname" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox bm_xclass" Enabled="False">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 350px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="Father's Name :" AssociatedControlID="xfname"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 228px">
                                                <%--<asp:DropDownList ID="xfname" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox bm_xclass" Enabled="False">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xfname" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 350px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label6" runat="server" Text="Mother's Name :" AssociatedControlID="xmname"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 228px">
                                              <%--  <asp:DropDownList ID="xmname" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_textbox bm_xclass" Enabled="False">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xmname" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="Dropout Type :" AssociatedControlID="xtype"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:DropDownList ID="xtype" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 350px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label8" runat="server" Text="Reason :" AssociatedControlID="xreason"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 228px">
                                                <asp:DropDownList ID="xreason" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label9" runat="server" Text="Certificate/TC :" AssociatedControlID="xtccertificate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xtccertificate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" Text="Marksheet :" AssociatedControlID="xmarksheet"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xmarksheet" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label11" runat="server" Text="Char. Certificate :" AssociatedControlID="xcharcertificate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xcharcertificate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label12" runat="server" Text="Reference :" AssociatedControlID="xreference"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xreference" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label13" runat="server" Text="Dropout Date :" AssociatedControlID="xdate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%; text-align: left;">
                                            <div class="bm_ctl_container_50_50" style="width: 120px; margin-bottom: 10px; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_50" style="width: 118px">
                                                    <asp:Label ID="Label14" runat="server" Text="Remarks :"
                                                        CssClass="label "></asp:Label>
                                                </div>
                                            </div>
                                            <div style="width: 400px;float: left;">
                                                <asp:TextBox ID="xremarks" runat="server" Height="80px" TextMode="MultiLine" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label15" runat="server" Text="Status :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="xstatus" runat="server">
                                                    New
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l" style="">
                                                    <asp:Label ID="Label16" runat="server" Text="Entered By :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="zemail" runat="server">
                                                    zemail@bm.com
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label17" runat="server" Text="Approved By :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="xapprovedby" runat="server">
                                                    xemail@bm.com
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="bm_academic_container_body_button_section">
                                <div class="button_section_padding">
                                    <div class="button_section_style1" style="text-align: left; margin-top: 10px;">
                                        <asp:Button ID="btnRefresh1" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                            OnClick="btnRefresh_Click" />
                                        <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                            OnClick="btnSave_Click" />
                                        <asp:Button ID="btnDelete1" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                            OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                        <asp:Button ID="btnSubmit1" runat="server" Text="Approve" CssClass="bm_academic_button3 bm_am_btn_edit"
                                            OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="bm_academic_container_footer">
                                <div class="footer_list_padding">
                                    <div class="bm_academic_grid_container" id="list" runat="server">
                                        <div class="grid_header">
                                            <div class="grid_header_label" id="_grid_header" runat="server">
                                                Pending List for Class Interchange Approve
                                            </div>
                                            <div class="grid_header_control">
                                            </div>
                                            <div class="flot_right">

                                                <div class="grid_header_row">
                                                    <asp:TextBox ID="_gridrow" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                                        OnTextChanged="fnFillGrid6"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="grid_body">
                                            <asp:GridView ID="dgvPromotedistNew" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None">
                                                <Columns>
                                                    <%--<asp:TemplateField HeaderText="No.">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>--%>
                                                    
                                                    <asp:TemplateField HeaderText="No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                   <%-- <asp:BoundField DataField="xrow" HeaderText="Row" ItemStyle-Width="100px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />--%>

                                                   <asp:BoundField DataField="xsession" HeaderText="Session" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xstdid" HeaderText="Student ID" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xgroup" HeaderText="Group" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xsection" HeaderText="Section" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xdate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                      <asp:BoundField DataField="xclasspro" HeaderText="New Class" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xgrouppro" HeaderText="New Group" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xsectionpro" HeaderText="New Section" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <input id="btnPreApprove" type="button" value="Approve" style="width: 100px" class="bm_academic_button5 bm_am_btn_edit btnpreapp"/>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    
                                                    
                                                     

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:BoundField DataField="xrow" HeaderText="Row" ItemStyle-Width="100px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5 displaynone" HeaderStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"/>

                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                           
                            

                      <%--  </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                            <div class="bm_academic_container_footer">
                                <div class="footer_list_padding">
                                    <div class="bm_academic_grid_container" id="Div1" runat="server">
                                        <div class="grid_header">
                                            <div class="grid_header_label" id="Div2" runat="server">
                                               Class Interchange Approved
                                            </div>
                                            <div class="grid_header_control">
                                            </div>
                                            <div class="flot_right">

                                                <div class="grid_header_row">
                                                    <asp:TextBox ID="_gridrow1" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                                        OnTextChanged="fnFillGrid6"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="grid_body">
                                            <asp:GridView ID="dgvPromotedistSubmitted" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None">
                                                <Columns>
                                                   <%-- <asp:TemplateField HeaderText="No.">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>--%>
                                                    
                                                     <asp:TemplateField HeaderText="No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                    
                                                 <%--   <asp:BoundField DataField="xrow" HeaderText="Row" ItemStyle-Width="100px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />--%>

                                                    <asp:BoundField DataField="xsession" HeaderText="Session" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xstdid" HeaderText="Student ID" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xgroup" HeaderText="Group" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xsection" HeaderText="Section" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xdate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                      <asp:BoundField DataField="xclasspro" HeaderText="New Class" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xgrouppro" HeaderText="New Group" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xsectionpro" HeaderText="New Section" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                  

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                     <asp:BoundField DataField="xrow" HeaderText="Row" ItemStyle-Width="100px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5 displaynone" HeaderStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"/>

                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
                
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
                PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modal" BehaviorID="modalpopup" PopupDragHandleControlID="pnlpopup">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="150px" Width="400px"
                Style="display: none">
                <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Class Interchange Approve
                        </td>
                    </tr>
                   <%-- <tr>
                        <td align="left" style="padding: 5px;">
                            <table style="border: none;">
                                 <tr class="displaynone">
                                    <td>Row
                                    </td>
                                    <td>:
                                    </td>
                                    <td id="stdrow">
                                        <asp:TextBox ID="lblstdrow" runat="server" ReadOnly="True" BackColor="Transparent" BorderStyle="None" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Session
                                    </td>
                                    <td>:
                                    </td>
                                    <td id="stdsession">
                                        <asp:TextBox ID="lblstdsession" runat="server" ReadOnly="True" BackColor="Transparent" BorderStyle="None" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Student ID
                                    </td>
                                    <td>:
                                    </td>
                                    <td id="stdid">
                                        <asp:TextBox ID="lblstdid" runat="server" ReadOnly="True" BackColor="Transparent" BorderStyle="None" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Student Name
                                    </td>
                                    <td>:
                                    </td>
                                    <td id="stdname">
                                         <asp:TextBox ID="lblstdname" runat="server" ReadOnly="True" BackColor="Transparent" BorderStyle="None" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>--%>
                    
                   <%-- <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Dropout Date<span id="term"></span>
                        </td>
                    </tr>--%>
                    
                    
                    <%--<tr>
                        <td align="left" style="padding: 5px;">
                           <asp:TextBox ID="xdateacc" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                        </td>
                    </tr>--%>

                  <%--  <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Remarks<span id="term1"></span>
                        </td>
                    </tr>--%>


                    <tr>
                        <td align="left" style="padding: 5px;">
                           <%-- <textarea id="xdetails" class="bm_academic_textarea_100_50  bm_academic_textarea"
                                style="width: 100%; height: 120px;" runat="server"></textarea>--%>
                            Are you sure you want to approving class interchange of the student with ID <span id="stdid"></span>? 

                        </td>
                    </tr>




                    <tr>
                        <td align="center" style="padding-bottom: 5px;">
                            <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="bm_academic_button1 bm_am_btn_ok btnok" OnClick="btnOk_OnClick"/>
                           <%-- <input type="button" id="btnOk" value="OK" class="bm_academic_button1 bm_am_btn_ok" />--%>
                            <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="bm_academic_button1 bm_am_btn_cancel" />--%>
                            <input type="button" id="btnCancel" value="Cancel" class="bm_academic_button1 bm_am_btn_cancel" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

              

                <asp:HiddenField ID="_subject" runat="server" />
                <asp:HiddenField ID="_classteacher" runat="server" />
                <asp:HiddenField ID="_subteacher" runat="server" />
                <asp:HiddenField ID="_xperiod" runat="server" />
                <asp:HiddenField ID="_xsection" runat="server" />
                <asp:HiddenField ID="_xdate" runat="server" />
                <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                <asp:HiddenField ID="txtconformmessageValue1" runat="server" />
                <asp:HiddenField ID="hiddenxdate" runat="server" />
                <asp:HiddenField ID="hiddenxrow" runat="server" />
                <asp:HiddenField ID="hiddenxstatus" runat="server" />
                <asp:HiddenField ID="hxstatus" runat="server" />
                <asp:HiddenField ID="xnsdate" runat="server" />
                <asp:HiddenField ID="hstdrow" runat="server" />
                <asp:HiddenField ID="hstdsession" runat="server" />
                <asp:HiddenField ID="hstdid" runat="server" />
                <asp:HiddenField ID="hstdname" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
