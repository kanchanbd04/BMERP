<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="hrcoachconfig.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.hrcoachconfig" %>

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

        .right {
            text-align: right;
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
                                    <%--{ "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xstdid.ClientID%>", "prop": "listtext", "tab": "0" },
                                    { "id": "<%= xcdate.ClientID%>", "prop": "combo", "tab": "0" },
                                    { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                                      { "id": "<%= xbank.ClientID%>", "prop": "combo", "tab": "0" }--%>
                                    <%--    { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" },
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

                <%-- $("body").on("keypress", "#<%=xrow1.ClientID%>", function() {
                    if (window.event.keyCode == 13) {
                        //alert("Hi");
                        //alert(document.getElementById("<%=xrow1.ClientID %>").value);
                       
                        document.getElementById("<%=Button2.ClientID %>").click();
                    }
                });--%>

                <%--$("body").on("blur", "#<%=xstdid.ClientID%>", function() {
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
                            //alert(student.xclass);
                            $("#<%=xname.ClientID%>").val(student.xname);
                            $("#<%=xclass.ClientID%>").val(student.xclass);
                            $("#<%=xgroup.ClientID%>").val(student.xgroup);
                          
                            document.getElementById("<%=Button1.ClientID %>").click();

                            if (student.xclass == '') {
                                alert('Student not yet assigned for any class in this session.');
                            }
                        },
                      error: function (r) {
                          alert(r.responseText);
                      },
                      failure: function (r) {
                          alert(r.responseText);
                      }
                  });

                });--%>

                <%--  $("body").on("change", "#<%=xsession.ClientID%>", function() {
                    //alert("hi");
                    $("#<%=xcdate.ClientID%>").val("");
                });--%>
            <%--    $("body").on("change", "#<%=xclass.ClientID%>", function() {
                    //alert("hi");
                   $("#<%=xcdate.ClientID%>").val("");
                });
                $("body").on("change", "#<%=xgroup.ClientID%>", function() {
                    //alert("hi");
                  $("#<%=xcdate.ClientID%>").val("");
                  });--%>
                
                $("body").on("click", ".bm_tfccode", function () {
                    <%-- var row = this.parentNode.parentNode.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.parentNode.parentNode.cellIndex;


                    var grid = document.getElementById('<%=GridView1.ClientID %>');--%>

                    //alert("Row - " + row + ", Index - " + rowIndex + ", Cell - " + cell);
                    <%-- //alert($("#<%=GridView1.ClientID%>").attr("ID"));--%>
                    //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    <%--  if($("#<%=hxstatus.ClientID%>").val()=="")--%>
                    var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                    if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1')
                    {
                        fnOpenTFCCodeList1(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());

                    }
                 
                         <%--//fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));--%>
                });

                $("body").on("blur", "[id*=xtfccode]", function() {
                    //alert("hi");
                    var row = this.parentNode.parentNode.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.parentNode.parentNode.cellIndex;


                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    //alert($("#" + this.id).val());
                    //alert(row.cells[1].getElementsByTagName("input")[1].value);
                    //row.cells[1].getElementsByTagName("input")[0].value = "Hi";
                    //row.cells[2].getElementsByTagName("input")[0].value = "Hi";

                  <%--  var zid1 = <%= HttpContext.Current.Session["business"] %>;
                    var xrow1 = $("#<%=hiddenxrow.ClientID%>").val();
                    var xclass1 = $("#<%=xclass.ClientID%>").val();
                    var xgroup1 = $("#<%=xgroup.ClientID%>").val();
                    var xstdid1 = $("#<%=xstdid.ClientID%>").val();
                    var xeffdate1 = $("#<%=xcdate.ClientID%>").val();
                    var xtfccode1 = $("#" + this.id).val();
                    var xsession1 = $("#<%=xsession.ClientID%>").val();--%>
                   
                    //var zid1 = '100012';
                    //var xstdid1 = '3036';
                    //alert(zid1);

                    $.ajax({
                        type: "POST",
                        url: "/edusoft.asmx/TFCCodeInfo2",
                        data: "{ zid: '" + zid1 + "', xrow:'" + xrow1 + "', xclass: '" + xclass1 + "', xgroup: '"+xgroup1+"', xstdid: '"+xstdid1+"', xeffdate: '"+xeffdate1+"', xtfccode: '"+xtfccode1+"', xsession:'"+xsession1+"' }",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            //alert(data.d);
                            var tfccode = JSON.parse(data.d);
                            //alert(student.xclass);
                            <%--    //$("#<%=xname.ClientID%>").val(student.xname);
                            //$("#<%=xclass.ClientID%>").val(student.xclass);
                            //$("#<%=xgroup.ClientID%>").val(student.xgroup);--%>
                            <%--$("#<%=xsection.ClientID%>").val(student.xsection);--%>
                            
                            //grid.rows[rowIndex+1].getElementById("input[id*='xdesc']").value = tfccode.xdescdet;
                            //grid.rows[rowIndex+1].find("input[id*='xamtdue']").value = tfccode.xamount;
                            row.cells[0].getElementsByTagName("input")[0].value = tfccode.xtfccode;
                            row.cells[1].getElementsByTagName("input")[0].value = tfccode.xdescdet;
                            row.cells[2].getElementsByTagName("input")[0].value = tfccode.xdamount;
                            row.cells[3].getElementsByTagName("input")[0].value = tfccode.xdue;
                            row.cells[4].getElementsByTagName("input")[0].value = tfccode.xamount;

                            var grid = document.getElementById('<%=GridView1.ClientID %>');
                            //Calculate and update Grand Total.
                            var grandTotal = 0;

                            for (var i = 1; i < grid.rows.length - 1; i++) {
                                var xreceived1 = parseFloat(grid.rows[i].cells[4].children[0].value );

                                if (isNaN(xreceived1)) {
                                    xreceived1 = 0;
                                }

                                grandTotal = grandTotal + xreceived1;
                            }
                            grid.rows[grid.rows.length - 1].cells[4].children[0].value = grandTotal;

                        },
                        error: function (r) {
                            alert(r.responseText);
                        },
                        failure: function (r) {
                            alert(r.responseText);
                        }
                    });
                });

                $("body").on("keyup", "[id*=xreceived]", function() {
                    enter(this, event);
                });
                $("body").on("keyup", "[id*=xremarks]", function() {
                    enter(this, event);
                });
                //$("body").on("keyup", "[id*=xtfccode]", function() {
                //    enter(this, event);
                //});

                $("body").on("click", ".bm_student", function () {
                    //alert("Hi");
                    //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
               <%--     if ($("#<%=hxstatus.ClientID%>").val() == "")--%>
                    var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                    if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1'){
                        fnOpenStudentList3(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    }

                    <%--  $("#<%=xstdid.ClientID%>").focus();

                   // var zid1 = <%= HttpContext.Current.Session["business"] %>;
                   // var xstdid1 = $("#<%=xstdid.ClientID%>").val();
                    //var zid1 = '100012';
                    //var xstdid1 = '3036';
                    //alert(zid1);--%>

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


                $("body").on("keyup", "[id*=xreceived]", function () {

                    //alert("Hi");
                    if (window.event.keyCode == 67) {
                        //alert("c");
                        var row = this.parentNode.parentNode;
                        var rowIndex = row.rowIndex - 1;
                        //$(this).val(row.cells[2].getElementsByTagName("input")[0].value);
                        $(this).val(row.cells[2].innerHTML);
                        ////alert(row.cells[2].innerHTML);
                    }

                    //Check whether Quantity value is valid Float number.
                    var quantity = parseFloat($.trim($(this).val()));
                    if (isNaN(quantity)) {
                        quantity = 0;
                    }

                    //Update the Quantity TextBox.
                    $(this).val(quantity);

                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    //Calculate and update Grand Total.
                    var grandTotal = 0;
                    //$("[id*=xreceived]").each(function () {
                    //    var quantity1 = parseFloat($.trim($(this).val()));
                    //    if (isNaN(quantity1)) {
                    //        quantity1 = 0;
                    //    }
                    //    grandTotal = grandTotal + quantity1;
                    //});
                    for (var i = 1; i < grid.rows.length - 1; i++) {
                        var xreceived1 = parseFloat(grid.rows[i].cells[4].children[0].value );

                        if (isNaN(xreceived1)) {
                            xreceived1 = 0;
                        }

                        grandTotal = grandTotal + xreceived1;
                    }

                   
                    //grid.rows[grid.rows.length - 1].cells[4].children[0].value = grandTotal;
                    grid.rows[grid.rows.length - 1].cells[4].innerHTML = grandTotal;

                });


                function ConfirmMessage() {
                    var selectedvalue = confirm("Do you want to payment transaction? After payment cann't change record.");
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

                function fnPrintReceipt() {
                   <%-- // alert("Hi");
                    var zid = <%= HttpContext.Current.Session["business"] %>;
                    var xrow = $("#<%= hiddenxrow.ClientID%>").val();
                    var xtype = "Tuition Fee";
                    var xsession =  $("#<%= xsession.ClientID%>").val();
                    var xstdid =  $("#<%= xstdid.ClientID%>").val();
                    var xclass =  $("#<%= xclass.ClientID%>").val();

                      var openwin = window.open('/forms/academic/reports/rptamtfc1.aspx?zid=' + zid + '&xrow=' + xrow + '&xtype=' + xtype + '&xsession=' + xsession + '&xstdid=' + xstdid + '&xclass=' + xclass, 'rptamtfc1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
                      openwin.focus();
                      //openwin.print();
                      //return false;--%>
                }

                //$.key('alt+s', function() {
                    
                //    $("[id*=btnSave]").click();
                
                //});

                //shortcut.add("Ctrl+S",function() { alert("Hi"); } );
                
               <%-- $.hotkeys.add('f10',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnSave.ClientID%>").click();
                });--%>

                //$.key('alt+d', function() {

                //    $("[id*=btnDelete]").click();

                //});

                //shortcut.add("Ctrl+D",function() { $("[id*=btnDelete]").click(); },{ 'type':'keydown', 'propagate':false, 'target':document} );

                $.hotkeys.add('f6',function(){
                    //alert('Pressed Ctrl+s');
                    <%-- $("#<%= btnDelete.ClientID%>").click();--%>
                });

                //$.key('alt+p', function() {

                //    $("[id*=btnPaid]").click();

                //});

                //shortcut.add("Ctrl+P",function() { $("[id*=btnDelete]").click(); },{ 'type':'keydown', 'propagate':false, 'target':document} );

                //$.key('alt+shift+p', function() {

                //    $("[id*=btnPrint]").click();

                //});

                <%-- //shortcut.add("Ctrl+P",function() { $("#<%= btnPrint.ClientID%>").click(); },{ 'type':'keydown', 'propagate':true, 'target':document} );--%>

              <%-- $.hotkeys.add('f9',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnPrint.ClientID%>").click();
                });--%>

                //$.key('alt+r', function() {

                //    $("[id*=btnRefresh]").click();

                //});

                //shortcut.add("Ctrl+R",function() { $("[id*=btnRefresh]").click(); },{ 'type':'keydown', 'propagate':false, 'target':document} );

                $.hotkeys.add('f5',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnRefresh.ClientID%>").click();
                });

                //$.key('alt+a', function() {

                //    $("[id*=btnAddRow]").click();

                //});

                function ConfirmMessage1() {
                    var selectedvalue = confirm("Do you want to parmanently delete this record?");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "Yes";
                    } else {
                        document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "No";
                    }
                }

                function ConfirmMessage2() {
                    var selectedvalue = confirm("Do you want to parmanently delete this record?");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue2.ClientID %>').value = "Yes";
                    } else {
                        document.getElementById('<%=txtconformmessageValue2.ClientID %>').value = "No";
                    }
                }

              <%--  $("body").on("click", ".bm_convenor_day", function () {
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= xcoach.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });--%>

                $("body").on("click", ".bm_convenor_day", function () {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _coach.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });

                $("body").on("click", ".bm_convenor_day1", function () {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _teacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });

            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Coach Setup</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                        <%-----THIS IS MESSAGE SECTION-----%>
                    </div>
                </div>
                <div class="bm_academic_container_body1">
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding" style="border-bottom: 0px; padding-bottom: 0px">
                            <div class="button_section_style1" style="text-align: left; margin-bottom: 5px;">
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <%--<asp:Button ID="btnShow" runat="server" Text="Show" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnShow_OnClick" />--%>
                                <%--  <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                    OnClick="btnSave_Click" />--%>
                                <%--     <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                    OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnConfirm_Click" Visible="False" />
                                <asp:Button ID="btnPaid" runat="server" Text="Paid" CssClass="bm_academic_button3 bm_am_btn_paid"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnPaid_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    Visible="False" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="bm_academic_button3 bm_am_btn_print"
                                    OnClientClick="fnPrintReceipt();" />--%>
                                <%--<asp:Button ID="btnRefresh" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    Visible="False" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100">


                                <div class="bm_layout_box_padding" style="padding-top: 10px;">

                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both; min-height: 300px">

                                       <%-- <fieldset style="margin-left: 10px; margin-right: 10px;">
                                            <legend>Coach Information:</legend>--%>
                                            <div style="display: inline-block; width: 500px; vertical-align: top;">
                                                <div class="bm_ctl_container_100_30" style="width: 400px">
                                                    <div class="bm_ctl_label_align_right_100_30 label_bg" style="width: 100px">
                                                        <asp:Label ID="Label6" runat="server" Text="Coach :" AssociatedControlID="xcoach"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_30" style="width: 298px">
                                                        <div class="bm_list_text" style="width: 270px">
                                                            <asp:TextBox ID="xcoach" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                        </div>
                                                        <div class="bm_list_img">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_convenor_day" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="bm_clt_padding">
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="width: 300px;">
                                                    <div class="bm_ctl_label_align_right_100_special" style="width: 100px">
                                                        <asp:Label ID="Label31" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special" style="width: 198px">
                                                        <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                            AutoPostBack="True" OnTextChanged="xclass_OnTextChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="width: 300px;">
                                                    <div class="bm_ctl_label_align_right_100_special" style="width: 100px">
                                                        <asp:Label ID="Label3" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special" style="width: 198px">
                                                        <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                            AutoPostBack="True" OnTextChanged="xsubject_OnTextChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>--%>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <asp:Button ID="btnAddCoach" runat="server" Text="Add Coach" CssClass="bm_academic_button5 bm_am_btn_addnew" Width="120px"
                                                    OnClick="btnAddCoach_OnClick" />
                                                

                                                <div style="width: 100%; clear: both; padding-top: 5px">
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                        CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                                        RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                        PagerStyle-CssClass="PagerStyle" GridLines="None" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="xsl" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <%-- <asp:BoundField DataField="xsl" HeaderText="ID" ItemStyle-Width="50px"
                                                                ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />--%>
                                                            <asp:TemplateField HeaderText="ID">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                   <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xcoach") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <%--<asp:BoundField DataField="xcoach" HeaderText="ID" ItemStyle-Width="100px"
                                                                ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />--%>
                                                              <asp:BoundField DataField="xname" HeaderText="Coach Name" ItemStyle-Width="250px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                             <%--<asp:BoundField DataField="xclass" HeaderText="Subject" ItemStyle-Width="100px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                            <asp:BoundField DataField="xsubject" HeaderText="Subject" ItemStyle-Width="150px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />--%>
                                                            
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>

                                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="javascript:ConfirmMessage1();" OnClick="ImageButton1_OnClick">Remove</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="xrow" HeaderText="" ItemStyle-Width=""
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5 hiddencol" HeaderStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol"/>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                            </div>
                                            <div style="display: inline-block; width: 600px; vertical-align: top; padding-left: 40px" id="teacher" runat="server">
                                                <%--<fieldset style="">
                                        <legend>Teacher's Information:</legend>--%>
                                                <div style="width: 100%; height: 25px; background-color: #a9a9a9; padding-top: 5px; padding-left: 5px; color: white;font-size:16px" id="teacherheader" runat="server">
                                                    List(s) of Teacher's
                                                    
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div class="bm_ctl_container_100_30" style="width: 400px">
                                                    <div class="bm_ctl_label_align_right_100_30 label_bg" style="width: 100px">
                                                        <asp:Label ID="Label1" runat="server" Text="Teacher :" AssociatedControlID="xteacher"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_30" style="width: 298px">
                                                        <div class="bm_list_text" style="width: 270px">
                                                            <asp:TextBox ID="xteacher" runat="server" CssClass="bm_academic_textbox_100_30 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                        </div>
                                                        <div class="bm_list_img">
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_convenor_day1" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="bm_clt_padding">
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="width: 300px;">
                                                    <div class="bm_ctl_label_align_right_100_special" style="width: 100px">
                                                        <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass1"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special" style="width: 198px">
                                                        <asp:DropDownList ID="xclass1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                            AutoPostBack="True" OnTextChanged="xclass_OnTextChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <div class="bm_ctl_container_100_special" style="width: 300px;">
                                                    <div class="bm_ctl_label_align_right_100_special" style="width: 100px">
                                                        <asp:Label ID="Label4" runat="server" Text="Subject :" AssociatedControlID="xsubject1"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_100_special" style="width: 198px">
                                                        <asp:DropDownList ID="xsubject1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                            AutoPostBack="True" OnTextChanged="xsubject_OnTextChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>--%>
                                                <div class="bm_clt_padding">
                                                </div>
                                                <asp:Button ID="btnAddTeacher" runat="server" Text="Add Teacher" CssClass="bm_academic_button5 bm_am_btn_addnew" Width="120px"
                                                    OnClick="btnAddTeacher_OnClick" />
                                                

                                                <div style="width: 100%; clear: both; padding-top: 5px">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                        CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                                        RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                        PagerStyle-CssClass="PagerStyle" GridLines="None" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="xsl" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <%-- <asp:BoundField DataField="xsl" HeaderText="ID" ItemStyle-Width="50px"
                                                                ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />--%>
                                                           <%-- <asp:TemplateField HeaderText="ID">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                   <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xteacher") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                           <asp:BoundField DataField="xteacher" HeaderText="ID" ItemStyle-Width="100px"
                                                                ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                              <asp:BoundField DataField="xname" HeaderText="Teacher Name" ItemStyle-Width="250px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                             <%--<asp:BoundField DataField="xclass" HeaderText="Subject" ItemStyle-Width="100px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                            <asp:BoundField DataField="xsubject" HeaderText="Subject" ItemStyle-Width="150px"
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />--%>
                                                            
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>

                                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="javascript:ConfirmMessage2();" OnClick="ImageButton2_OnClick">Remove</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="xline" HeaderText="" ItemStyle-Width=""
                                                                ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5 hiddencol" HeaderStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol"/>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <%--  </fieldset>--%>
                                            </div>
                                        <%--</fieldset>--%>

                                        <%--<div style="width: 100%">
                                            <div style="float: left;">
                                                <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                                    <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                        <asp:Label ID="Label3" runat="server" Text="Transaction No :" AssociatedControlID="xrow1"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_50_50" style="width: 148px">

                                                        <asp:TextBox ID="xrow1" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"
                                                            AutoPostBack="True" OnTextChanged="FillControl2"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 3px;">
                                                <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/search32x32.png" runat="server"
                                                    CssClass="bm_academic_list" Width="20px" Height="20px" OnClick="FillControl2" />
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_100_special" style="width: 270px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xcdate_OnTextChanged"> 
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <%--<div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label4" runat="server" Text=" Student ID :" AssociatedControlID="xstdid"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xstdid" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                             OnTextChanged="xstdid_OnTextChanged" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_student" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xstdname" runat="server" Text="" CssClass="xstdname"></asp:Label>
                                            </div>

                                        </div>--%>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_50_50" style="float: left; width: 350px; display: none;">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label18" runat="server" Text="Student Name :" AssociatedControlID="xname"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 228px">

                                                <asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                              
                                                <asp:TextBox ID="xclass" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                               
                                                <asp:TextBox ID="xgroup" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--     <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                               
                                                <asp:TextBox ID="xsection" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" Text="Charge Period :" AssociatedControlID="xcdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">

                                                <asp:DropDownList ID="xcdate" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass"
                                                    AutoPostBack="True" OnTextChanged="xcdate_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <%--<div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="Transaction Date :" AssociatedControlID="xtdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xtdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>

                                        <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 365px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label6" runat="server" Text="Bank Name :" AssociatedControlID="xbank"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 243px">
                                                <asp:DropDownList ID="xbank" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--  <div class="bm_clt_padding">
                                        </div>--%>
                                        <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 270px;display:none">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="Cheque Date :" AssociatedControlID="xchqdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xchqdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>--%>

                                        <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 270px;display:none">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label8" runat="server" Text="Cheque No. :" AssociatedControlID="xchqno"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xchqno" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                            </div>
                                        </div>--%>

                                        <%--<div class="bm_clt_padding">
                                        </div>--%>
                                        <%--<div style="width: 100%; text-align: left;display:none">
                                            <div class="bm_ctl_container_50_50" style="width: 120px; margin-bottom: 10px; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_50" style="width: 118px">
                                                    <asp:Label ID="Label14" runat="server" Text="Note (if any) :"
                                                        CssClass="label "></asp:Label>
                                                </div>
                                            </div>
                                            <div style="width: 400px; float: left;">
                                                <asp:TextBox ID="xremarks" runat="server" Height="80px" TextMode="MultiLine" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray"></asp:TextBox>
                                            </div>
                                        </div>--%>

                                        <%--<div class="bm_ctl_container_100_special" style="width: 300px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 90px">
                                                <asp:Label ID="Label31" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 208px">
                                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xclass_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="width: 300px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 90px">
                                                <asp:Label ID="Label3" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 208px">
                                                <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                    AutoPostBack="True" OnTextChanged="xsubject_OnTextChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div>
                                            <div class="bm_ctl_container_100_special" style="width: 90px; float: left">
                                                <div class="bm_ctl_label_align_right_100_special" style="width: 90px">
                                                    <asp:Label ID="Label1" runat="server" Text="Paper :"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                              
                                            </div>
                                            <div style="border: 1px solid #696969; width: 1000px; float: left; min-height: 25px">
                                                <asp:CheckBoxList ID="xpaper" runat="server" RepeatDirection="Horizontal" CellSpacing="10"></asp:CheckBoxList>
                                            </div>
                                        </div>

                                        <div class="bm_clt_padding">
                                        </div>
                                        <div>
                                            <div class="bm_ctl_container_100_special" style="width: 90px; float: left">
                                                <div class="bm_ctl_label_align_right_100_special" style="width: 90px">
                                                    <asp:Label ID="Label2" runat="server" Text="Extension :"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                             
                                            </div>
                                            <div style="border: 1px solid #696969; width: 1000px; float: left; min-height: 25px">
                                                <asp:CheckBoxList ID="xext" runat="server" RepeatDirection="Horizontal" CellSpacing="10"></asp:CheckBoxList>
                                            </div>
                                        </div>--%>
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>--%>
                                        <%-- <asp:Button ID="btnAddSubject" runat="server" Text="Add Subject" CssClass="bm_academic_button5 bm_am_btn_addnew" Width="120px"
                                            OnClick="btnAddSubject_OnClick" />

                                        <div style="width: 100%; clear: both; padding-top: 5px">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound"
                                                UseAccessibleHeaderText="true" OnDataBound="GridView1_DataBound1">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL">
                                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="xsl" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="xsubject" HeaderText="Subject" ItemStyle-Width="250px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xpaper" HeaderText="Paper" ItemStyle-Width="250px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xext" HeaderText="Extention" ItemStyle-Width="450px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            
                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="javascript:ConfirmMessage1();" OnClick="ImageButton1_OnClick">Remove</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="xrow" HeaderText="" ItemStyle-Width=""
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5 hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>--%>
                                    </div>


                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px; min-height: 0px; padding-bottom: 0px;">
                                <div class="bm_academic_grid_container2" style="width: 100%; margin-top: 0px; padding-top: 0px" id="divliststd" runat="server">

                                    <div style="width: 98%; margin-bottom: 10px; margin-left: 10px;">


                                        <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                            CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None">
                                            <Columns>
                                               <asp:TemplateField HeaderText="TFC Code">
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                            <div class="bm_list_text" style="width: 120px">
                                                                <asp:TextBox ID="xtfccode" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                            </div>
                                                            <div class="bm_list_img">
                                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_tfccode" Height="22px" />
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Left" />
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnAddRow" runat="server" CssClass="bm_academic_button3 bm_am_btn_addrow"
                                                            Text="Add New Row" Width="100px" OnClick="btnAddRow_Click" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemStyle Width="250px" HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:TextBox ID="xdescdet" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox " Enabled="False" ForeColor="black"></asp:TextBox>

                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text="Total" ForeColor="#FFFFFF" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Default Amount">
                                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:TextBox ID="xamount" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox right" Enabled="False" ForeColor="black"></asp:TextBox>

                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Receivable Amount">
                                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:TextBox ID="xreceivable" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox right" Enabled="False" ForeColor="black"></asp:TextBox>

                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Left" />
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="xreceivabletot" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox right bakcolorstyle"
                                                            BorderStyle="None" Enabled="False" ForeColor="#FFFFFF" Font-Bold="True" ViewStateMode="Enabled"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Received Amount">
                                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:TextBox ID="xreceived" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox right"></asp:TextBox>

                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Left" />
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="xreceivedtot" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox right bakcolorstyle"
                                                            BorderStyle="None" Enabled="False" ForeColor="#FFFFFF" Font-Bold="True" ViewStateMode="Enabled"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemStyle Width="250px" HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:TextBox ID="xremarks" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnRemove" runat="server" OnClick="btnRemove_Click">Remove</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                        <%-- <asp:BoundField DataField="xsession" HeaderText="Session" ItemStyle-Width="150px"
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
                                                <asp:BoundField DataField="xdate" HeaderText="Dropout Date" DataFormatString="{0:dd/MM/yyyy}"
                                                    ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xtype" HeaderText="Type" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xreason" HeaderText="Reason" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="pad5" />
                                                <asp:BoundField DataField="xstatus" HeaderText="Status" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />--%>


                                        <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                        <%-- </Columns>
                                        </asp:GridView>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="bm_academic_container_body_button_section">
                                <div class="button_section_padding">
                                    <div class="button_section_style1" style="text-align: left; margin-top: 10px;">
                                        <asp:Button ID="btnRefresh1" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                            OnClick="btnRefresh_Click" />
                                       <%-- <asp:Button ID="Button3" runat="server" Text="Show" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                            OnClick="btnShow_OnClick" />--%>
                                        <%-- <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                            OnClick="btnSave_Click" />--%>
                                        <%--    <asp:Button ID="btnDelete1" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                            OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                        <asp:Button ID="btnConfirm1" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                            OnClientClick="javascript:ConfirmMessage();" OnClick="btnConfirm_Click" Visible="False" />
                                        <asp:Button ID="btnSubmit1" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                            Visible="False" />--%>
                                        <%-- <asp:Button ID="btnRefresh1" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    Visible="False" />--%>
                                        <%-- <asp:Button ID="btnPaid1" runat="server" Text="Paid" CssClass="bm_academic_button3 bm_am_btn_paid"
                                            OnClientClick="javascript:ConfirmMessage();" OnClick="btnPaid_Click" />
                                        <asp:Button ID="btnPrint1" runat="server" Text="Print" CssClass="bm_academic_button3 bm_am_btn_print"
                                            OnClientClick="fnPrintReceipt();" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="bm_academic_container_footer">
                                <div class="footer_list_padding">
                                    <div class="bm_academic_grid_container" id="list" runat="server">
                                        <div class="grid_header">
                                            <div class="grid_header_label" id="_grid_header" runat="server">
                                                List(s) of Classwise Subject 
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
                                            <asp:GridView ID="dgvclasssub" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL">
                                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="xsl" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="100px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xsubject" HeaderText="Subject" ItemStyle-Width="250px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xpaper" HeaderText="Paper" ItemStyle-Width="250px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xext" HeaderText="Extention" ItemStyle-Width="450px"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="pad5" />

                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>--%>

                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="bm_academic_container_footer">
                                <div class="footer_list_padding">
                                    <div class="bm_academic_grid_container" id="Div1" runat="server">
                                        <div class="grid_header">
                                            <div class="grid_header_label" id="Div2" runat="server">
                                                List of Collection (Paid)
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
                                            <asp:GridView ID="dgvcollectionpaid" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Transaction No.">
                                                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>


                                                    <asp:BoundField DataField="xsession" HeaderText="Session" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xstdid" HeaderText="Student ID" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xname" HeaderText="Student Name" ItemStyle-Width="250px"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xgroup" HeaderText="Group" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    <asp:BoundField DataField="xcdate" HeaderText="Charge Period" DataFormatString="{0:dd/MM/yyyy}"
                                                        ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />


                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <%-- <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowList"
                PopupControlID="pnlpopup" CancelControlID="btnCancel"  BackgroundCssClass="modal">
           
            </cc1:ModalPopupExtender>--%>
                <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="530px" Width="800px"
                    Style="display: none" ScrollBars="Auto">
                    <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
                        cellpadding="0" cellspacing="0">
                        <tr style="background-color: #619CFD; height: 30px; text-align: right;">
                            <td>
                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close-window.png"
                                    Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                            </td>
                        </tr>
                        <tr>
                            <td>kjslfjklfjksl
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:HiddenField ID="_coach" runat="server" />
                <asp:HiddenField ID="_teacher" runat="server" />
                <asp:HiddenField ID="_subject" runat="server" />
                <asp:HiddenField ID="_classteacher" runat="server" />
                <asp:HiddenField ID="_subteacher" runat="server" />
                <asp:HiddenField ID="_xperiod" runat="server" />
                <asp:HiddenField ID="_xsection" runat="server" />
                <asp:HiddenField ID="_xdate" runat="server" />
                <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                <asp:HiddenField ID="txtconformmessageValue1" runat="server" />
                 <asp:HiddenField ID="txtconformmessageValue2" runat="server" />
                <asp:HiddenField ID="hiddenxdate" runat="server" />
                <asp:HiddenField ID="hiddenxrow" runat="server" />
                <asp:HiddenField ID="hiddenxstatus" runat="server" />
                <asp:HiddenField ID="hxstatus" runat="server" />
                <asp:HiddenField ID="xnsdate" runat="server" />
                <asp:HiddenField ID="hxeffdate" runat="server" />
                <asp:HiddenField ID="hxclass" runat="server" />
                <div style="display: none">
                    <asp:Button ID="Button1" runat="server" Text="Button1" CssClass="bm_academic_button3  " OnClick="xcdate_OnTextChanged" />
                    <asp:Button ID="Button2" runat="server" Text="Button1" CssClass="bm_academic_button3  " OnClick="FillControl2" />
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
