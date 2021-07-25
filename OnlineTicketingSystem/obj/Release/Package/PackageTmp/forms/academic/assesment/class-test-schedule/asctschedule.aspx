<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="asctschedule.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.asctschedule" %>

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
        /*.bm_academic_grid1 tr:nth-child(6) td{
    padding: 2px; 
    border-bottom: solid 2px #000000; 
    color: #000000;
    padding-left: 3px;
    font-weight: normal;
     font-size: 14px;
     font-family: Myriad Pro,tahoma; 
}*/


        tr.BorderRow td {
            border-top: 3px solid #000000;
        }





        .divgrid {
            height: 200px;
            width: 100%;
        }

            .divgrid table {
                width: 100%;
            }

                .divgrid table th {
                }
    </style>
    <script type="text/javascript">
        
        
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

                //function fnPageLoad() {

                //    $(".divgrid").each(function () {

                //        var grid = $(this).find("table")[0];

                //        var ScrollHeight = $(this).height() - 30;

                //        var gridWidth = $(this).width() - 20;

                //        var headerCellWidths = new Array();

                //        for (var i = 0; i < grid.getElementsByTagName('TH').length; i++) {

                //            headerCellWidths[i] = grid.getElementsByTagName('TH')[i].offsetWidth;

                //        }

                //        grid.parentNode.appendChild(document.createElement('div'));

                //        var parentDiv = grid.parentNode; 
                //        var table = document.createElement('table');

                //        for (i = 0; i < grid.attributes.length; i++) {

                //            if (grid.attributes[i].specified && grid.attributes[i].name != 'id') {

                //                table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);

                //            }

                //        }

                //        table.style.cssText = grid.style.cssText;

                //        table.style.width = gridWidth + 'px';

                //        table.appendChild(document.createElement('tbody'));

                //        table.getElementsByTagName('tbody')[0].appendChild(grid.getElementsByTagName('TR')[0]);

                //        var cells = table.getElementsByTagName('TH');

                //        var gridRow = grid.getElementsByTagName('TR')[0];

                //        for (var i = 0; i < cells.length; i++) {

                //            var width; 
                //            if (headerCellWidths[i] > gridRow.getElementsByTagName('TD')[i].offsetWidth) {

                //                width = headerCellWidths[i];

                //            } else {

                //                width = gridRow.getElementsByTagName('TD')[i].offsetWidth;

                //            } 
                //            cells[i].style.width = parseInt(width - 3) + 'px';

                //            gridRow.getElementsByTagName('TD')[i].style.width = parseInt(width - 3) + 'px';

                //        }

                //        var gridHeight = grid.offsetHeight;
               

                //        if (gridHeight < ScrollHeight)

                //            ScrollHeight = gridHeight;

                //        parentDiv.removeChild(grid);

                //        var dummyHeader = document.createElement('div');

                //        dummyHeader.appendChild(table); 
                //        parentDiv.appendChild(dummyHeader);

                //        var scrollableDiv = document.createElement('div');

                //        if (parseInt(gridHeight) > ScrollHeight) {

                //            gridWidth = parseInt(gridWidth) + 17;

                //        }

                //        scrollableDiv.style.cssText = 'overflow:auto;height:' + ScrollHeight + 'px;width:' + gridWidth + 'px';

                //        scrollableDiv.appendChild(grid);

                //        parentDiv.appendChild(scrollableDiv);

                //    }); 

                //        }

                function fnPageLoad() {

                    $("#<%= GridView1.ClientID %>").chromatable({

                        width: "100%", // specify 100%, auto, or a fixed pixel amount
                        height: "540px",
                        scrolling: "yes" // must have the jquery-1.3.2.min.js script installed to use

                    });
                }


                $(document).ready(function () {

                    BlockUI("<%=pnlpopup.ClientID %>");
                    $.blockUI.defaults.css = {};

                    fnPageLoad();
                });

                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    fnPageLoad();
                });





                $("body").on("click", ".bm_subject_teacher", function () {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _subteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
        });

            $("body").on("click", ".bm_class_teacher", function () {
                //alert("Button was clicked.");
                fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _classteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            // $("body").on("click", ".bm_subject", function () {
            //alert("Button was clicked.");
            //fnOpenSubjectList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                // });

                $("body").on("click", ".bm_subject", function () {
                    //alert("Button was clicked.");
                    fnOpenSubjectList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });


                $("body").on("click", ".bm_am_btn_save", function () {

                    //                alert("Hi");
                    //                return false;

                    var mendatoryFields = [
                        { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                        { "id": "<%= xterm.ClientID%>", "prop": "combo", "tab": "0" },
                        { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                        { "id": "<%= xdate.ClientID%>", "prop": "combo", "tab": "0" }
                    ];
                    var mendatoryString = JSON.stringify(mendatoryFields);
                    if (!fnMendatoryFields1(mendatoryString)) {
                        return false;
                    }


                    return true;
                });

                $("body").on("click", ".bm_am_btn_show", function () {

                    //                alert("Hi");
                    //                return false;

                    var mendatoryFields = [
                        { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                        { "id": "<%= xterm.ClientID%>", "prop": "combo", "tab": "0" },
                        { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                        { "id": "<%= xdate.ClientID%>", "prop": "combo", "tab": "0" }
                    ];
                    var mendatoryString = JSON.stringify(mendatoryFields);
                    if (!fnMendatoryFields1(mendatoryString)) {
                        return false;
                    }


                    return true;
                });

                

                $("body").on("click", ".btnSchedule", function() {

                    fnDefaultStyle("<%= xsubject.ClientID %>");
                    fnDefaultStyleList("<%= xsteacher.ClientID %>");
                    fnDefaultStyleList("<%= xcteacher.ClientID %>");
                    //alert("Hi");
                    var row = this.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.cellIndex;

                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    var btnid = grid.rows[rowIndex + 1].cells[cell].children[0].id.split("_");
                    //alert(btnid[2].substr(11));
                    $('#hbtnid').val(grid.rows[rowIndex + 1].cells[cell].children[0].id);

                    $("#<%= message.ClientID %>").empty();
                   <%-- alert(parseInt($("#<%= hrowcount.ClientID%>").val()));--%>
                    var xdate1= grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length-2].innerText;
                    var xsection1= grid.rows[rowIndex + 1].cells[grid.rows[rowIndex + 1].cells.length-1].innerText;
                    var xperiod1 = grid.rows[0].cells[btnid[2].substr(11)].innerText;
                    //alert(xdate1);
                    $("#<%= lbldate.ClientID%>").html($.date(xdate1));
                    $("#<%= lblsection.ClientID%>").html(xsection1);
                    $("#<%= lblperiod.ClientID%>").html(xperiod1);

                    $("#<%= _xsection.ClientID%>").val(xsection1);
                    $("#<%= _xdate.ClientID%>").val(xdate1);
                    $("#<%= _xperiod.ClientID%>").val(xperiod1);
                   <%-- alert($("#<%= _xperiod.ClientID%>").val());--%>

                    $.ajax({
                        url: "asctschedule.aspx/fnFetchValue",

                        type: "POST",

                        data: "{'xrow1' : '" + $('#<%= hxrow.ClientID%>').val() + "', 'xdate1':'" + $("#<%= _xdate.ClientID%>").val() + "', 'xperiod1' : '" + $("#<%= _xperiod.ClientID%>").val() + "', 'xsection1' : '" + $("#<%= _xsection.ClientID%>").val() + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            var xcom = r.split("|");
                            if (xcom[0] == "success") {
                                $("#<%= xsubject.ClientID%>").val(xcom[1]);
                                $("#<%= xpaper.ClientID%>").val(xcom[2]);
                                $("#<%= xtopic.ClientID%>").val(xcom[3]);
                                $("#<%= xdetails.ClientID%>").val(xcom[4]);
                                $("#<%= xcteacher.ClientID%>").val(xcom[5]);
                                $("#<%= xsteacher.ClientID%>").val(xcom[6]);
                                $("#<%= _classteacher.ClientID%>").val(xcom[7]);
                                $("#<%= _subteacher.ClientID%>").val(xcom[8]);
                                $("#<%= xext.ClientID%>").val(xcom[9]);
                            }
                            else if (xcom[0] == "nodata") {
                                $fnResetval();
                            } else {
                                alert(r);
                                $fnResetval();
                            }


                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                            $fnResetval();

                        }


                    });


                    $find('modalpopup').show();
                });

                $fnResetval = function () {
                    $("#<%= xsubject.ClientID%>").val('');
                   $("#<%= xext.ClientID%>").val('');
                   $("#<%= xpaper.ClientID%>").val('');
                   $("#<%= xtopic.ClientID%>").val('');
                   $("#<%= xdetails.ClientID%>").val('');
                   $("#<%= xcteacher.ClientID%>").val('');
                   $("#<%= xsteacher.ClientID%>").val('');
                   $("#<%= _classteacher.ClientID%>").val('');
                   $("#<%= _subteacher.ClientID%>").val('');
               };

               $("body").on("click", "#btnOk", function () {
                   var mendatoryFields = [
                        { "id": "<%= xsubject.ClientID%>", "prop": "combo", "tab": "0" },
                        { "id": "<%= xcteacher.ClientID%>", "prop": "listtext", "tab": "0" },
                        { "id": "<%= xsteacher.ClientID%>", "prop": "listtext", "tab": "0" }
                   ];
                   var mendatoryString = JSON.stringify(mendatoryFields);
                   if (!fnMendatoryFields1(mendatoryString)) {
                       return false;
                   }

                   //alert('Hi');
                   // $("#" + $('#hbtnid').val()).css("background-color", "#8A2BE2");
                   //$("#" + $('#hbtnid').val()).attr("title", $('#xdetails').val());
                   //alert($('#xdetails').val());
                   var xrow1 = $('#<%= hxrow.ClientID%>').val();
                    var xsection1 = $("#<%= _xsection.ClientID%>").val();
                    var xcperiod1 = $("#<%= _xperiod.ClientID%>").val();
                    var xdate1 = $("#<%= _xdate.ClientID%>").val();
                    var xsubject1 = $("#<%= xsubject.ClientID%>").val();
                    var xext1 = $("#<%= xext.ClientID%>").val();
                    var xpaper1 = $("#<%= xpaper.ClientID%>").val();
                   var xtopic1 = $("#<%= xtopic.ClientID%>").val().replace(/(['"])/g, "\\$1");
                   var xdetails1 = $("#<%= xdetails.ClientID%>").val().replace(/(['"])/g, "\\$1");
                    var xcteacher1 = $("#<%= _classteacher.ClientID%>").val();
                    var xsteacher1 = $("#<%= _subteacher.ClientID%>").val();

                    $.ajax({
                        url: "asctschedule.aspx/fnInsertDetails",

                        type: "POST",

                        data: "{'xrow1' : '" + xrow1 + "', 'xsection1':'" + xsection1 + "', 'xcperiod1' : '" + xcperiod1 + "', 'xdate1' : '" + xdate1 
                              + "', 'xsubject1' : '" + xsubject1 + "', 'xext1' : '" + xext1 + "' , 'xpaper1' : '" + xpaper1 + "' , 'xtopic1' : '" + xtopic1 
                              + "', 'xdetails1' : '" + xdetails1 + "', 'xcteacher1' : '" + xcteacher1 + "', 'xsteacher1' : '" + xsteacher1 + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            if (r != "success") {
                                alert(r);

                            }
                            else {
                                $("#" + $('#hbtnid').val()).css("background-color", "#BAD980");
                                if (xpaper1 != '' && xext1 != '') {
                                    $("#" + $('#hbtnid').val()).attr("value", xsubject1 + "("+ xext1 +")" + "-" + xpaper1);
                                }else if (xpaper1 != '' && xext1 == '') {
                                    $("#" + $('#hbtnid').val()).attr("value", xsubject1 + "-" + xpaper1);
                                }else if (xpaper1 == '' && xext1 != '') {
                                    $("#" + $('#hbtnid').val()).attr("value", xsubject1 + "(" + xext1 + ")");
                                }else {
                                    $("#" + $('#hbtnid').val()).attr("value", xsubject1);
                                }
                                
                                $find('modalpopup').hide();
                            }


                        },
                        error: function (err) {
                            alert("ERROR : " + err);

                        }


                    });

                    //                        $find('modalpopup').hide();

                });


                $("body").on("click", "#btnDelete", function () {
                  
                    //$("#dialog").dialog({
                    //    modal: true,
                    //    buttons: {
                    //        "Yes": function() { $( this ).dialog( "close" );},
                    //        "No": function() { $( this ).dialog( "close" );}
                    //    }
                    //});

                    var selectedvalue = confirm("Do you want to delete record?");
                    if (selectedvalue) {
                        
                        var xrow1 = $('#<%= hxrow.ClientID%>').val();
                        var xsection1 = $("#<%= _xsection.ClientID%>").val();
                        var xcperiod1 = $("#<%= _xperiod.ClientID%>").val();
                        var xdate1 = $("#<%= _xdate.ClientID%>").val();
                        var xsubject1 = $("#<%= xsubject.ClientID%>").val();
                        var xext1 = $("#<%= xext.ClientID%>").val();
                        var xpaper1 = $("#<%= xpaper.ClientID%>").val();
                        var xtopic1 = $("#<%= xtopic.ClientID%>").val();
                        var xdetails1 = $("#<%= xdetails.ClientID%>").val();
                        var xcteacher1 = $("#<%= _classteacher.ClientID%>").val();
                        var xsteacher1 = $("#<%= _subteacher.ClientID%>").val();

                        $.ajax({
                            url: "asctschedule.aspx/fnDeleteDetails",

                            type: "POST",

                            data: "{'xrow1' : '" + xrow1 + "', 'xsection1':'" + xsection1 + "', 'xcperiod1' : '" + xcperiod1 + "', 'xdate1' : '" + xdate1 
                                  + "', 'xsubject1' : '" + xsubject1 + "', 'xext1' : '" + xext1 + "' , 'xpaper1' : '" + xpaper1 + "' , 'xtopic1' : '" + xtopic1 
                                  + "', 'xdetails1' : '" + xdetails1 + "', 'xcteacher1' : '" + xcteacher1 + "', 'xsteacher1' : '" + xsteacher1 + "'}",

                            //dataType: "json",
                            contentType: "application/json; charset=utf-8",

                            async: false,
                            success: function (res) {

                                var r = res.d;
                                if (r != "success") {
                                    alert(r);

                                }
                                else {
                                    $("#" + $('#hbtnid').val()).css("background-color", "#F8C1D9");
                                    $("#" + $('#hbtnid').val()).attr("value", "N/S");
                                
                                    $find('modalpopup').hide();
                                }


                            },
                            error: function (err) {
                                alert("ERROR : " + err);

                            }


                        });

                    } 
                    
                    

                   
                });


                <%--     $("body").on("change", ".bm_academic_dropdown", function () {

                    $("#<%= message.ClientID %>").empty();
                        $(".grid_body").empty();
                        //return false;
                    });--%>

                function ConfirmMessage() {
                    var selectedvalue = confirm("Do you want to submit record? After submit cann't change record.");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
                    } else {
                        document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
                    }
                }


                function fnPrintSchedule() {
                    // alert("Hi");
                    var zid = <%= HttpContext.Current.Session["business"] %>;
                    var xsession = $("#<%= xsession.ClientID%>").val();
                    var xterm = $("#<%= xterm.ClientID%>").val();
                    var xclass = $("#<%= xclass.ClientID%>").val();
                    var xgroup = $("#<%= xgroup.ClientID%>").val();
                    var xdate = $("#<%= hiddenxdate.ClientID%>").val();
                    var xrow = $("#<%= hxrow.ClientID%>").val();
                    var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
                    var openwin = window.open('/forms/academic/reports/rptasctschvwsw.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup  + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
                    openwin.focus();
                    openwin.print();
                    //return false;
                }




               


            </script>

            <%--     <div id="dialog" title="Delete Confirmation" style="display: none;">
  <p>Do you want to delete record?</p>
</div>--%>

            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Make Class Test Schedule </span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                        <%-----THIS IS MESSAGE SECTION-----%>
                    </div>
                </div>
                <div class="bm_academic_container_body1">
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding">
                            <div class="button_section_style1">
                               <%-- <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="bm_academic_button1 bm_am_btn_show"
                                    OnClick="btnShow_Click" />--%>
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button1 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Create" CssClass="bm_academic_button1 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="bm_academic_button1 bm_am_btn_edit"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
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
                                                <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 122px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged_class">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block;">
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
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; width: 210px">
                                            <div class="bm_ctl_label_align_right_100_special">
                                                <asp:Label ID="Label3" runat="server" Text="Month :" AssociatedControlID="xdate"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special">
                                                <asp:DropDownList ID="xdate" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<div class="bm_ctl_container_100_special" style="width: 32px; padding-top: 6px;
                                            border: none; height: 32px;display: inline-block">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                    Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>--%>
                                        <div class="bm_ctl_container_100_special" style="width: 32px; padding-top: 6px; border: none; height: 32px; display: inline-block; padding-left: 5px;">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/reload70.png"
                                                    Width="25px" Height="25px"  CssClass="bm_academic_button_zoom"  OnClick="btnShow_Click"/>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="display: inline-block; padding-left: 15px; border: none">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="width: 32px; padding-top: 6px; border: none; height: 32px; display: inline-block; padding-left: 40px;">
                                            <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                    Width="25px" Height="25px" OnClientClick="fnPrintSchedule();" CssClass="bm_academic_button_zoom" />
                                            </div>
                                        </div>
                                    </div>
                                    <%--Control section end--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_footer">
                        <div class="footer_list_padding1">
                            <%-- <div class="bm_ac_grid_calendar">
                                <div class="bm_ctl_container_100_special2" style="display: inline-block">
                                    <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                        <asp:Button ID="Button3" runat="server" Text="&#8249;" CssClass="bm_academic_button2  bm_ac_btn_round_bc" />
                                    </div>
                                </div>
                                <div class="bm_ctl_container_100_special1" style="display: inline-block">
                                    <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                        <asp:DropDownList ID="xdate" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                            AutoPostBack="True" OnTextChanged="xdate_OnTextChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="bm_ctl_container_100_special2" style="display: inline-block">
                                    <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                        <asp:Button ID="Button4" runat="server" Text="&#8250;" CssClass="bm_academic_button2  bm_ac_btn_round_fc" />
                                    </div>
                                </div>
                            </div>--%>
                            <div class="bm_academic_grid_container1 grid_body" style="height: 550px;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                    CssClass="bm_academic_grid1" FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle"
                                    AlternatingRowStyle-CssClass="AlternatingRowStyle" PagerStyle-CssClass="PagerStyle"
                                    GridLines="None" OnDataBound="GridView1_DataBound1" OnRowDataBound="OnRowDataBound"
                                    UseAccessibleHeaderText="true" OnPreRender="gvTheGrid_PreRender">
                                    <%--<HeaderStyle CssClass="HeaderFreez"></HeaderStyle>--%>
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
                                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound"
                                    OnDataBound="GridView1_DataBound">
                                    <Columns>
                                    </Columns>
                                </asp:GridView>--%>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding">
                            <div class="button_section_style1">
                              <%--  <asp:Button ID="btnShow1" runat="server" Text="Show" CssClass="bm_academic_button1 bm_am_btn_show"
                                    OnClick="btnShow_Click" />--%>
                                <asp:Button ID="btnRefresh1" runat="server" Text="Refresh" CssClass="bm_academic_button1 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave1" runat="server" Text="Create" CssClass="bm_academic_button1 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnSubmit1" runat="server" Text="Submit" CssClass="bm_academic_button1 bm_am_btn_edit"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
                PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modal" BehaviorID="modalpopup">
            </cc1:ModalPopupExtender>
            <%-- PopupDragHandleControlID="pnlpopup" --%>>
            <%-- <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="530px" Width="400px"
                Style="display:none">
                </asp:Panel>--%>
            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="560px" Width="400px"
                Style="display: none">
                <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Add Details
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding: 5px;">
                            <table style="border: none;">
                                <tr>
                                    <td>Date
                                    </td>
                                    <td>:
                                    </td>
                                    <td id="lbldate11">
                                        <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Section
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblsection" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Period
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblperiod" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Subject, Extension & Paper
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding: 5px;">
                            <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px">
                                <%--<div class="bm_ctl_label_align_right_100_special" style="width: 30%">
                                    <asp:Label ID="Label3" runat="server" Text="Subject :" AssociatedControlID="xsubject" CssClass="label"></asp:Label>
                                </div>--%>
                                <div class="bm_clt_ctl_100_special" style="width: 100%">
                                    <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                       >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--  <div class="bm_ctl_container_50_60" style="width: 280px; display: inline-block;">
                                <div class="bm_clt_ctl_50_60" style="width: 100%">
                                    <div class="bm_list_text" style="width: 92%">
                                        <asp:TextBox ID="xsubject" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                    </div>
                                    <div class="bm_list_img" style="width: 8%">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_subject" />
                                    </div>
                                </div>
                            </div>--%>
                            <div class="bm_ctl_container_100_special" style="display: inline-block; width: 80px" runat="server" id="_xpaper">
                                <%-- <div class="bm_ctl_label_align_right_100_special" style="width: 50%">
                                    <asp:Label ID="Label5" runat="server" Text="Paper :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                </div>--%>
                                <div class="bm_clt_ctl_100_special" style="width: 100%">
                                    <asp:DropDownList ID="xpaper" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="bm_ctl_container_100_special" style="width: 250px" runat="server" id="_xext">
                                <%-- <div class="bm_ctl_label_align_right_100_special" style="width: 50%">
                                    <asp:Label ID="Label5" runat="server" Text="Paper :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                </div>--%>
                                <div class="bm_clt_ctl_100_special" style="width: 100%">
                                    <asp:DropDownList ID="xext" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <%-- <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px;" align="left">Extention
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding: 5px;">
                             <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px">
                                
                                <div class="bm_clt_ctl_100_special" style="width: 100%">
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </td>
                    </tr>--%>
                    <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px" align="left">Topic/Chapter
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding: 5px;">
                            <textarea id="xtopic" class="bm_academic_textarea_100_50  bm_academic_textarea" style="width: 100%; height: 50px;"
                                runat="server"></textarea>
                        </td>
                    </tr>
                    <tr style="background-color: #619CFD">
                        <td style="height: 15px; color: white; font-size: 14px" align="left">Details
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <td align="left" style="padding: 5px;">
                                <textarea id="xdetails" class="bm_academic_textarea_100_50  bm_academic_textarea"
                                    style="width: 100%; height: 120px;" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr style="background-color: #619CFD">
                            <td style="height: 15px; color: white; font-size: 14px" align="left">Class Teacher
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding: 5px">
                                <div class="bm_ctl_container_50_60" style="width: 100%">
                                    <div class="bm_clt_ctl_50_60" style="width: 100%">
                                        <div class="bm_list_text" style="width: 94%">
                                            <asp:TextBox ID="xcteacher" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                        </div>
                                        <div class="bm_list_img" style="width: 6%">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_class_teacher" />
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr style="background-color: #619CFD">
                            <td style="height: 15px; color: white; font-size: 14px" align="left">Subject Teacher
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding: 5px">
                                <div class="bm_ctl_container_50_60" style="width: 100%">
                                    <div class="bm_clt_ctl_50_60" style="width: 100%">
                                        <div class="bm_list_text" style="width: 94%">
                                            <asp:TextBox ID="xsteacher" runat="server" CssClass="bm_academic_textbox_50_60 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                        </div>
                                        <div class="bm_list_img" style="width: 6%">
                                            <asp:Image ID="Image8" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_subject_teacher" />
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding-bottom: 5px;">
                                <%--<asp:Button ID="btnOk" runat="server" Text="Save" CssClass="bm_academic_button1 bm_am_btn_ok"
                                    OnClick="btnOk_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"
                                    OnClick="btnDelete_Click" />--%>
                                <%--<asp:Button ID="btnOk" runat="server" Text="Save" CssClass="bm_academic_button1 bm_am_btn_ok"/>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"/>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="bm_academic_button1 bm_am_btn_cancel" />--%>

                                <input type="button" id="btnOk" value="Save" class="bm_academic_button1 bm_am_btn_ok">
                                <input type="button" id="btnDelete" value="Delete" class="bm_academic_button1 bm_am_btn_delete">
                                <input type="button" id="btnCancel" value="Cancel" class="bm_academic_button1 bm_am_btn_cancel">
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
            <asp:HiddenField ID="hiddenxdate" runat="server" />
            <asp:HiddenField ID="hiddenxrow" runat="server" />
            <asp:HiddenField ID="hiddenxstatus" runat="server" />
            <asp:HiddenField ID="hrowcount" runat="server" />
            <asp:HiddenField ID="hxrow" runat="server" />
            <input id="hbtnid" type="hidden" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
