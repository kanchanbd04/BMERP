<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="imtemptrnsrtn.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.imtemptrnsrtn" %>

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

                $("body").on("click", ".bm_xstdid", function () {
                    //alert($("#<%=GridView1.ClientID%>").attr("ID"));
                     //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    <%--if($("#<%=hxstatus.ClientID%>").val()=="")--%>
                     var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                     if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1' || xst == 'Open')
                     {
                         fnOpenStudentList6(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xnamestd").attr("ID"));
                         $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").focus();
                     }
                 
                     //fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                });

                $("body").on("click", ".bm_xref", function () {
                    //alert($("#<%=GridView1.ClientID%>").attr("ID"));
                     //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    <%--if($("#<%=hxstatus.ClientID%>").val()=="")--%>
                     var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                     if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1' || xst == 'Open')
                     {
                         var xwh = $("#<%= xtwh.ClientID%>").val();
                         var xstdid = $("#<%= xstdid.ClientID%>").val();

                         fnOpenIssueList(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xreflbl").attr("ID"),xwh,xstdid);
                         $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").focus();
                     }
                 
                     //fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                 });

                $("body").on("click", ".bm_list", function () {
                    //alert("Button was clicked.");
                    // alert(this.getAttribute("rowno"));
                    //                 alert(document.getElementById('<%=hxstatus.ClientID %>').value);
                    //                 return;
                    var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                    if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1' || xst == 'Open') {
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
                             <%-- { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },--%>
                                   <%-- { "id": "<%= xtfccode.ClientID%>", "prop": "listtext", "tab": "0" },
                                    { "id": "<%= xcdate.ClientID%>", "prop": "combo", "tab": "0" }--%>
                                { "id": "<%= xdate.ClientID%>", "prop": "text", "tab": "0" },
                                { "id": "<%= xstdid.ClientID%>", "prop": "listtext", "tab": "0" },
                                { "id": "<%= xref.ClientID%>", "prop": "listtext", "tab": "0" },
                                    <%--{ "id": "<%= xsup.ClientID%>", "prop": "listtext", "tab": "0" },--%>
                                    { "id": "<%= xtwh.ClientID%>", "prop": "combo", "tab": "0" }
                    ];
                    var mendatoryString = JSON.stringify(mendatoryFields);
                    if (!fnMendatoryFields1(mendatoryString)) {
                        return false;
                    }


                    return true;
                });

               <%--$("body").on("blur", "#<%=xtfccode.ClientID%>", function() {
                    //alert("hi");
                    var zid1 = <%= HttpContext.Current.Session["business"] %>;
                   var xtfccode1 = $("#<%=xtfccode.ClientID%>").val();
                    //var zid1 = '100012';
                    //var xstdid1 = '3036';
                    //alert(zid1);

                    $.ajax({
                        type: "POST",
                        url: "/edusoft.asmx/TFCCodeInfo1",
                        data: "{ zid: '" + zid1 + "', xtfccode:'" + xtfccode1 + "' }",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            //alert(data.d);
                            var tfcinfo = JSON.parse(data.d);
                            //alert(student.xclass);
                            $("#<%=xtfccode.ClientID%>").val(tfcinfo.xtfccode);
                            $("#<%=xtfccodetitle.ClientID%>").val(tfcinfo.xdescdet);
                            $("#<%=xdescdet.ClientID%>").val(tfcinfo.xdescdet);
                         
                           
                        },
                        error: function (r) {
                            alert(r.responseText);
                        },
                        failure: function (r) {
                            alert(r.responseText);
                        }
                    });
                });--%>

                
                $("body").on("click", ".bm_xsup", function () {
                    //alert($("#<%=GridView1.ClientID%>").attr("ID"));
                    //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    <%--if($("#<%=hxstatus.ClientID%>").val()=="")--%>
                    var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                    if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1' || xst == 'Open')
                    {
                        fnOpenSupplierList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"),$("#<%=GridView1.ClientID%>").attr("ID"));
                        $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").focus();
                    }
                 
                    //fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                });

                $("body").on("blur", "[id*=xitem]", function() {
                    //alert("hi");
                    var row = this.parentNode.parentNode.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.parentNode.parentNode.cellIndex;


                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    //alert($("#" + this.id).val());
                    //alert(row.cells[1].getElementsByTagName("input")[1].value);
                    //row.cells[1].getElementsByTagName("input")[0].value = "Hi";
                    //row.cells[2].getElementsByTagName("input")[0].value = "Hi";

                    var zid1 = <%= HttpContext.Current.Session["business"] %>;
                    var xrow1 = $("#<%=hiddenxrow.ClientID%>").val();
                  <%--  var xclass1 = $("#<%=xclass.ClientID%>").val();
                    var xgroup1 = $("#<%=xgroup.ClientID%>").val();--%>
                    var xitem1 = $("#" + this.id).val();
                    <%--   var xsession1 = $("#<%=xsession.ClientID%>").val();--%>
                   <%-- var xeffdate1 = $("#<%=xcdate.ClientID%>").val();
                    var xtfccode1 = $("#" + this.id).val();
                    //var xsession1 = $("#<%=xsession.ClientID%>").val();--%>
                   
                    //var zid1 = '100012';
                    //var xstdid1 = '3036';
                    //alert(zid1);

                    $.ajax({
                        type: "POST",
                        url: "/edusoft.asmx/ItemInfo1",
                        data: "{ zid: '" + zid1 + "', xitem:'" + xitem1 + "' }",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            //alert(data.d);
                            var stdinfo = JSON.parse(data.d);
                            //alert(student.xclass);
                     <%--    //$("#<%=xname.ClientID%>").val(student.xname);
                            //$("#<%=xclass.ClientID%>").val(student.xclass);
                            //$("#<%=xgroup.ClientID%>").val(student.xgroup);
                            //$("#<%=xsection.ClientID%>").val(student.xsection);--%>
                            
                            //grid.rows[rowIndex+1].getElementById("input[id*='xdesc']").value = tfccode.xdescdet;
                            //grid.rows[rowIndex+1].find("input[id*='xamtdue']").value = tfccode.xamount;
                            //row.cells[1].getElementsByTagName("input")[0].value = stdinfo.xname;
                            row.cells[2].getElementsByTagName("input")[0].value = stdinfo.xdesc;
                            row.cells[4].getElementsByTagName("input")[0].value = stdinfo.xunitpur;
                            row.cells[8].getElementsByTagName("input")[0].value = stdinfo.xcfpur;
                            //row.cells[0].getElementsByTagName("input")[0].value = stdinfo.xstdid;
                            //if (stdinfo.xdesc == "") {
                            //    row.cells[1].getElementsByTagName("input")[0].value = "";
                            //    row.cells[2].getElementsByTagName("input")[0].value = "";
                            //    row.cells[4].getElementsByTagName("input")[0].value = "";
                            //} else {
                            //    row.cells[2].getElementsByTagName("input")[0].value = stdinfo.xdesc;
                            //    row.cells[4].getElementsByTagName("input")[0].value = stdinfo.xunitpur;
                            //}

                        },
                        error: function (r) {
                            alert(r.responseText);
                        },
                        failure: function (r) {
                            alert(r.responseText);
                        }
                    });
                });

                $("body").on("keyup", "[id*=xqty]", function() {
                    enter(this, event);
                });
                $("body").on("keyup", "[id*=xrate]", function() {
                    enter(this, event);
                });
                $("body").on("keyup", "[id*=xremarks]", function() {
                    enter(this, event);
                });
                //$("body").on("keyup", "[id*=xtfccode]", function() {
                //    enter(this, event);
                //});

                $("body").on("click", ".bm_item", function () {
                    //alert("Hi");
                    //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    <%-- if ($("#<%=hxstatus.ClientID%>").val() == "")--%> 
                    var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                    if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1' || xst == 'Open')
                    {
                        fnOpenItemList1(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                    }

                  <%--  $("#<%=xstdid.ClientID%>").focus();

                    var zid1 = <%= HttpContext.Current.Session["business"] %>;
                    var xstdid1 = $("#<%=xstdid.ClientID%>").val();--%>
                   

                    return false;
                });

                

              

                function ConfirmMessage() {
                    var selectedvalue = confirm("Do you want to confirm transaction? After confirm cann't change transaction.");
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

                function ConfirmMessage2() {
                    var selectedvalue = confirm("Do you want to undo this record?");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue2.ClientID %>').value = "Yes";
                    } else {
                        document.getElementById('<%=txtconformmessageValue2.ClientID %>').value = "No";
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

                //$.key('alt+s', function() {
                    
                //    $("[id*=btnSave]").click();
                
                //});

                $.hotkeys.add('f10',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnSave.ClientID%>").click();
                });

                //$.key('alt+d', function() {

                //    $("[id*=btnDelete]").click();

                //});

                $.hotkeys.add('f6',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnDelete.ClientID%>").click();
                });


                //$.key('alt+r', function() {

                //    $("[id*=btnRefresh]").click();

                //});

                $.hotkeys.add('f5',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnRefresh.ClientID%>").click();
                });

                //$.key('alt+a', function() {

                //    $("[id*=btnAddRow]").click();

                //});

                $.hotkeys.add('f12',function(){
                    //alert('Pressed Ctrl+s');
                    $("[id*=btnAddRow]").click();
                });

                $.hotkeys.add('f8',function(){
                    //alert('Pressed Ctrl+s');
                    $("[id*=btnConfirm]").click();
                });

            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Sales Return</span>
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
                            <div class="button_section_style1" style="text-align: left; margin-bottom: 5px;">
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                    OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnConfirm_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    Visible="False" />
                                 <asp:Button ID="btnUndo" runat="server" Text="Undo" CssClass="bm_academic_button3 bm_am_btn_undo"
                                    OnClientClick="javascript:ConfirmMessage2();" OnClick="btnUndo_Click" />
                                <%--<asp:Button ID="btnRefresh" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    Visible="False" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100">
                                <div class="bm_hotkey" style="clear: both; padding-left: 10px; padding-bottom: 5px">
                                    <table style="border: 1px solid white">
                                        <tr style="border: 1px solid white">
                                            <td style="background-color: Gray; color: black; margin: 1px">Hotkeys</td>
                                            <td style="background-color: silver; color: green; margin: 1px">Save - F10</td>
                                            <td style="background-color: silver; color: red; margin: 1px">Delete - F6</td>
                                            <td style="background-color: silver; color: blue; margin: 1px">Confirm - F8</td>
                                            <td style="background-color: silver; color: black; margin: 1px">Refresh - F5</td>
                                            <td style="background-color: silver; color: darkcyan; margin: 1px">Add New Row - F12</td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="bm_layout_box_padding" style="padding-top: 0px;">
                                    <%--Control section start--%>
                                    <div style="width: 100%; clear: both;">

                                        <div class="bm_ctl_container_100_special" style="width: 270px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                <asp:Label ID="Label8" runat="server" Text="Transactoin Prefix :" AssociatedControlID="xtrnim"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                <asp:TextBox ID="xtrnim" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                    Enabled="False" Text="RE--" BackColor="Transparent" ForeColor="Black"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%">
                                            <div style="float: left;">
                                                <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                                    <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                        <asp:Label ID="Label3" runat="server" Text="Transaction No :" AssociatedControlID="ximtmptrn"
                                                            CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                        <asp:TextBox ID="ximtmptrn" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_textbox"
                                                            AutoPostBack="True" OnTextChanged="FillControl2"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 3px;">
                                                <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/search32x32.png" runat="server"
                                                    CssClass="bm_academic_list" Width="20px" Height="20px" OnClick="FillControl2" />
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="Date :" AssociatedControlID="xdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                       <%-- <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="width: 270px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="Receive Type :" AssociatedControlID="xtyperec"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                <asp:DropDownList ID="xtyperec" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                       
                                        <%--<div class="bm_clt_padding">
                                        </div>
                                          <div class="bm_ctl_container_100_special" style="width: 270px; ">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Reference :" AssociatedControlID="xref"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                <asp:TextBox ID="xref" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                            </div>
                                        </div>--%>

                                       <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                        <div style="display: none;">
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label6" runat="server" Text=" Supplier No :" AssociatedControlID="xsup"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xsup" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                            AutoPostBack="True" OnTextChanged="xtfccode_OnTextChanged"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_xsup" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xorg" runat="server" Text="" CssClass="xtfccodetitle"></asp:Label>
                                            </div>

                                        </div>
                                        
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label1" runat="server" Text="Student :" AssociatedControlID="xstdid"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xstdid" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                            AutoPostBack="True" OnTextChanged="xtfccode_OnTextChanged"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_xstdid" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="xnamestd" runat="server" Text="" CssClass="xnamestd"></asp:Label>
                                            </div>

                                        </div>
                                        

                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_100_special" style="width: 270px;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                <asp:Label ID="Label31" runat="server" Text="Warehouse :" AssociatedControlID="xtwh"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                <asp:DropDownList ID="xtwh" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div>
                                            <div class="bm_ctl_container_50_100" style="width: 270px; float: left">
                                                <div class="bm_ctl_label_align_right_50_100" style="width: 120px">
                                                    <asp:Label ID="Label2" runat="server" Text="Reference :" AssociatedControlID="xref"
                                                        CssClass="label"></asp:Label>
                                                </div>
                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                    <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                                    <div class="bm_list_text" style="width: 120px">
                                                        <asp:TextBox ID="xref" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                            ></asp:TextBox>
                                                    </div>
                                                    <div class="bm_list_img">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_xref" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 5px; padding-top: 1px">
                                                <asp:Label ID="Label7" runat="server" Text="" CssClass="xreflbl"></asp:Label>
                                            </div>

                                        </div>


                                        <%-- <div class="bm_clt_padding">
                                        </div>--%>
                                      <%--  <div class="bm_ctl_container_100_special" style="width: 270px; display: none;">
                                            <div class="bm_ctl_label_align_right_100_special" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Reference :" AssociatedControlID="xref"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_100_special" style="width: 148px">
                                                <asp:TextBox ID="xref" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                            </div>
                                        </div>--%>


                                        <div class="bm_clt_padding">
                                        </div>
                                        <div style="width: 100%; text-align: left;">
                                            <div class="bm_ctl_container_50_50" style="width: 120px; margin-bottom: 10px; margin-right: 10px; float: left;">
                                                <div class="bm_ctl_label_align_right_50_50" style="width: 118px">
                                                    <asp:Label ID="Label14" runat="server" Text="Note :"
                                                        CssClass="label "></asp:Label>
                                                </div>
                                            </div>
                                            <div style="width: 400px; float: left;">
                                                <asp:TextBox ID="xremarks" runat="server" Height="80px" TextMode="MultiLine" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label13" runat="server" Text="Status :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="xstatustrn" runat="server">
                                                    New
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l" style="">
                                                    <asp:Label ID="Label11" runat="server" Text="Entered By :" CssClass="label"></asp:Label>
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
                                                    <asp:Label ID="Label12" runat="server" Text="Updated By :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="xemail" runat="server">
                                                    xemail@bm.com
                                                </div>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_dynamic_100_80">
                                            <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                                                <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                                                    <asp:Label ID="Label4" runat="server" Text="Confirm By :" CssClass="label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label">
                                                <div id="xconfirmby" runat="server">
                                                    xemail@bm.com
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                    <div style="width: 100%; clear: both; padding-top: 5px">
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px; min-height: 0px; padding-bottom: 0px;">

                                <div class="bm_academic_grid_container2" style="width: 100%" id="divliststd" runat="server">
                                    <div style="width: 98%; margin-bottom: 10px; margin-left: 10px;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                    PagerStyle-CssClass="PagerStyle" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                               <%-- <asp:Label ID="lblsl" runat="server" Text=""></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Item Code">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <div class="bm_clt_ctl_50_100" style="width: 148px">
                                                                    <div class="bm_list_text" style="width: 120px">
                                                                        <asp:TextBox ID="xitem" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                    </div>
                                                                    <div class="bm_list_img">
                                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_item" Height="22px" />
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
                                                            <ItemStyle Width="400px" HorizontalAlign="Center" />
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="xdesc" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox " Enabled="False" ForeColor="black" BackColor="Transparent"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Class">
                                                            <ItemStyle Width="150px" HorizontalAlign="left" />
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="xclass" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox " Enabled="False" ForeColor="black"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                  

                                                          <asp:TemplateField HeaderText="Quantity">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="xqty" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                                              <asp:TemplateField HeaderText="Unit">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="xunit" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox " Enabled="False" BackColor="Transparent" ForeColor="Black"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" CssClass="displaynone"/>
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="xrate" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                             
                                                        <asp:TemplateField HeaderText="Remarks">
                                                            <ItemStyle Width="300px" HorizontalAlign="Center" />
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="xremarks" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                          <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnRemove" runat="server" OnClick="btnRemove_Click">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="" HeaderStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone">
                                                            <ItemStyle Width="250px" HorizontalAlign="Center" CssClass="displaynone"/>
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="xcf" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox " ></asp:TextBox>

                                                            </ItemTemplate>
                                                              
                                                        </asp:TemplateField>

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


                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>

                                        </asp:UpdatePanel>
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
                                        <asp:Button ID="btnConfirm1" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                            OnClientClick="javascript:ConfirmMessage();" OnClick="btnConfirm_Click" />
                                        <asp:Button ID="btnSubmit1" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                            Visible="False" />
                                        
                                          <asp:Button ID="btnUndo1" runat="server" Text="Undo" CssClass="bm_academic_button3 bm_am_btn_undo"
                                    OnClientClick="javascript:ConfirmMessage2();" OnClick="btnUndo_Click" />
                                        <%-- <asp:Button ID="btnRefresh1" runat="server" Text="Confirm" CssClass="bm_academic_button3 bm_am_btn_edit"
                                    Visible="False" />--%>
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
                                                Sales Return Transaction List - New
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
                                            <asp:GridView ID="dgvgenerateduesnew" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Transaction No.">
                                                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("ximtmptrn") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    
                                                    <asp:BoundField DataField="xdate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />

                                                   <asp:BoundField DataField="xtwh" HeaderText="Warehouse" ItemStyle-Width="200px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    
                                                     <asp:BoundField DataField="xstdid" HeaderText="ID" ItemStyle-Width="100px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    
                                                     <asp:BoundField DataField="xname" HeaderText="Student Name" ItemStyle-Width="250px"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="pad5" />
                                                    
                                                     <asp:BoundField DataField="xref" HeaderText="Reference" ItemStyle-Width="200px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                    <asp:BoundField DataField="xaction" HeaderText="Action" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                    <asp:BoundField DataField="xstatustrn" HeaderText="Status" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                   

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
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="bm_academic_container_footer">
                                <div class="footer_list_padding">
                                    <div class="bm_academic_grid_container" id="Div1" runat="server">
                                        <div class="grid_header">
                                            <div class="grid_header_label" id="Div2" runat="server">
                                                Confirmed Transaction List
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
                                            <asp:GridView ID="dgvgenerateduesconfirmed" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                PagerStyle-CssClass="PagerStyle" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Transaction No.">
                                                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("ximtmptrn") %>' CssClass="_gridrow_link"
                                                                OnClick="FillControl"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    
                                                    <asp:BoundField DataField="xdate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />

                                                    <asp:BoundField DataField="xtwh" HeaderText="Warehouse" ItemStyle-Width="200px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    
                                                      <asp:BoundField DataField="xstdid" HeaderText="ID" ItemStyle-Width="100px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />
                                                    
                                                     <asp:BoundField DataField="xname" HeaderText="Student Name" ItemStyle-Width="250px"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="pad5" />
                                                    
                                                     <asp:BoundField DataField="xref" HeaderText="Reference" ItemStyle-Width="200px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                    <asp:BoundField DataField="xaction" HeaderText="Action" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                    <asp:BoundField DataField="xstatustrn" HeaderText="Status" ItemStyle-Width="150px"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                   

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
                    </asp:UpdatePanel>

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
                                    Width="25px" Height="25px" CssClass="bm_academic_button_zoom" />
                            </td>
                        </tr>
                        <tr>
                            <td>kjslfjklfjksl
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
                <asp:HiddenField ID="txtconformmessageValue2" runat="server" />
                <asp:HiddenField ID="hiddenxdate" runat="server" />
                <asp:HiddenField ID="hiddenxrow" runat="server" />
                <asp:HiddenField ID="hiddenxstatus" runat="server" />
                <asp:HiddenField ID="hxstatus" runat="server" />
                <asp:HiddenField ID="xnsdate" runat="server" />
                <asp:HiddenField ID="hxeffdate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
