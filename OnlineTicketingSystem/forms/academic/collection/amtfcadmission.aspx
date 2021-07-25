<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="amtfcadmission.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.assesment.class_test_schedule.amtfcadmission" %>

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
        .bm_academic_textarea:focus {
            background-color: #f7dc6f;
            -webkit-border-radius: 0px;
            -moz-border-radius: 0px;
            border-radius: 0px;
        }
    </style>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
                        '<img src="/images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6
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

            <%--   //             $('.bm_subject_teacher').click(function () {
            //            //alert("Hi");
            //            fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _subteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            //            });--%>











        });



    




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
              

                $("body").on("change keyup", "[id*=xreceived]", function () {

                    //alert("Hi");
                    //c=67
                    if (window.event.keyCode == 67) {
                        //alert("c");
                        var row = this.parentNode.parentNode;
                        var rowIndex = row.rowIndex - 1;
                        $(this).val(row.cells[5].innerHTML);
                        //alert(row.cells[2].innerHTML);
                    }

                    //Check whether Quantity value is valid Float number.
                    //var quantity = parseFloat($.trim($(this).val()));
                    //if (isNaN(quantity)) {
                    //    quantity = 0;
                    //}

                    ////Update the Quantity TextBox.
                    //$(this).val(quantity);

                    //var ex = /^[0-9]+\.?[0-9]*$/;
                    //if (ex.test($.trim($(this).val())) == false) {

                    //    if ($.trim($(this).val()).length > 0) {
                    //        var quantity = parseFloat($.trim($.trim($(this).val()).substring(0, $.trim($(this).val()).length - 1).replace(/^0+/, '')));

                    //        if (isNaN(quantity)) {
                    //            quantity = 0;
                    //        }

                    //        $(this).val(quantity);

                    //    } else {
                    //        $(this).val(0);
                    //    }


                    //} else {
                    //    var quantity = $.trim($(this).val().replace(/^0+/, ''));

                    //    if (quantity.length <=0) {
                    //        quantity = 0;
                    //    }

                    //    $(this).val(quantity);
                    //}

                    //Calculate and update Grand Total.
                    var grandTotal = 0;
                    $("[id*=xreceived]").each(function () {
                        var quantity1 = parseFloat($.trim($(this).val()));
                        if (isNaN(quantity1)) {
                            quantity1 = 0;
                        }
                        grandTotal = grandTotal + quantity1;
                    });

                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    //alert(grid);
                    grid.rows[grid.rows.length - 1].cells[6].innerHTML = grandTotal;

                    //var grandTotal1 = 0;

                    //for (var i = 2; i < grid.rows.length - 1; i++) {
                    //    var xreceived1 = parseFloat(grid.rows[i].cells[3].children[0].value);
                    //    //var xnettotal1 = parseFloat(grid.rows[i].cells[10].innerHTML);
                    //    //var xdue = xnettotal1 - xreceived1;
                    //    //grid.rows[i].cells[12].innerHTML = xdue;

                    //    grandTotal1 = grandTotal1 + xdue;
                    //}

                    ////grid.rows[grid.rows.length - 1].cells[12].innerHTML = grandTotal1;

                });

                function fnCalculateDiscount(grandTotal,index) {
                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    
                    //alert(grid);
                    grid.rows[grid.rows.length - 1].cells[index].innerHTML = grandTotal;

                    var grandTotal1 = 0;
                    var grandTotal2 = 0;
                    var grandTotal3 = 0;
                    var grandTotal4 = 0;
                    //alert(grid.rows.length);
                    for (var i = 2; i < grid.rows.length-1; i++) {
                        //alert(grid.rows[i].cells[2].innerHTML);
                        var xdisfixed = parseFloat(grid.rows[i].cells[3].children[0].value);
                        var xdisperc = parseFloat(grid.rows[i].cells[4].children[0].value);
                        var xamount = parseFloat(grid.rows[i].cells[2].innerHTML);

                        if (isNaN(xdisfixed)) {
                            xdisfixed = 0;
                        }

                        if (isNaN(xdisperc)) {
                            xdisperc = 0;
                        }

                        if (isNaN(xamount)) {
                            xamount = 0;
                        }

                        var xtotal = parseFloat(xdisfixed + (xamount * xdisperc / 100));

                        grid.rows[i].cells[5].innerHTML = xtotal;


                        grandTotal1 = grandTotal1 + xdisperc;
                        grandTotal2 = grandTotal2 + xtotal;
                        //alert("Amount : " + xamount + "<br>" +
                        //    "Fixed : " + xdisfixed + "<br>" +
                        //    "% : " + xdisperc + "<br>" +
                        //    "Total : " + parseFloat(xdisfixed + (xamount * xdisperc / 100)));

                        var xnettotal = xamount - xtotal;
                        grid.rows[i].cells[6].innerHTML = xnettotal;

                        grandTotal3 = grandTotal3 + xnettotal;

                        var xvat = parseFloat(grid.rows[i].cells[9].innerHTML);
                        if (isNaN(xvat)) {
                            xvat = 0;
                        }

                        var xnettotal1 = xvat + xnettotal;
                        grid.rows[i].cells[10].innerHTML = xnettotal1;

                        grandTotal4 = grandTotal4 + xnettotal1;

                        if (isNaN(xnettotal1)) {
                            xnettotal1 = 0;
                        }

                        grid.rows[i].cells[11].children[0].value = xnettotal1;

                    }

                    grid.rows[grid.rows.length - 1].cells[4].innerHTML = grandTotal1;
                    grid.rows[grid.rows.length - 1].cells[5].innerHTML = grandTotal2;
                    grid.rows[grid.rows.length - 1].cells[6].innerHTML = grandTotal3;
                    grid.rows[grid.rows.length - 1].cells[10].innerHTML = grandTotal4;
                    grid.rows[grid.rows.length - 1].cells[11].innerHTML = grandTotal4;
                }

                $("body").on("change keyup", "[id*=xdisfixed]", function () {

                    //alert("Hi");
                    //Check whether Quantity value is valid Float number.
                    var quantity = parseFloat($.trim($(this).val()));
                    if (isNaN(quantity)) {
                        quantity = 0;
                    }

                    //Update the Quantity TextBox.
                    $(this).val(quantity);

                    //Calculate and update Grand Total.
                    var grandTotal = 0;
                    $("[id*=xdisfixed]").each(function () {
                        var quantity1 = parseFloat($.trim($(this).val()));
                        if (isNaN(quantity1)) {
                            quantity1 = 0;
                        }
                        grandTotal = grandTotal + quantity1;
                    });

                    fnCalculateDiscount(grandTotal,3);

                });

                $("body").on("change keyup", "[id*=xdisperc]", function () {

                    //alert("Hi");
                    //Check whether Quantity value is valid Float number.
                    var quantity = parseFloat($.trim($(this).val()));
                    if (isNaN(quantity)) {
                        quantity = 0;
                    }

                    //Update the Quantity TextBox.
                    $(this).val(quantity);

                    //Calculate and update Grand Total.
                    var grandTotal = 0;
                    $("[id*=xdisperc]").each(function () {
                        var quantity1 = parseFloat($.trim($(this).val()));
                        if (isNaN(quantity1)) {
                            quantity1 = 0;
                        }
                        grandTotal = grandTotal + quantity1;
                    });

                    fnCalculateDiscount(grandTotal,4);

                });

                function fnCalculateVAT(grandTotal,index) {
                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                    
                    //alert(grid);
                    grid.rows[grid.rows.length - 1].cells[index].innerHTML = grandTotal;

                    var grandTotal1 = 0;
                    var grandTotal2 = 0;
                    var grandTotal3 = 0;
                    //alert(grid.rows.length);
                    for (var i = 2; i < grid.rows.length-1; i++) {
                        //alert(grid.rows[i].cells[2].innerHTML);
                        var xvatfixed = parseFloat(grid.rows[i].cells[7].children[0].value);
                        var xvatperc = parseFloat(grid.rows[i].cells[8].children[0].value);
                        var xnettotal = parseFloat(grid.rows[i].cells[6].innerHTML);

                        if (isNaN(xvatfixed)) {
                            xvatfixed = 0;
                        }

                        if (isNaN(xvatperc)) {
                            xvatperc = 0;
                        }

                        if (isNaN(xnettotal)) {
                            xnettotal = 0;
                        }

                        var xtotal = parseFloat(xvatfixed + (xnettotal * xvatperc / 100));

                        grid.rows[i].cells[9].innerHTML = xtotal;


                        grandTotal1 = grandTotal1 + xvatperc;
                        grandTotal2 = grandTotal2 + xtotal;
                        //alert("Amount : " + xamount + "<br>" +
                        //    "Fixed : " + xdisfixed + "<br>" +
                        //    "% : " + xdisperc + "<br>" +
                        //    "Total : " + parseFloat(xdisfixed + (xamount * xdisperc / 100)));

                        var xnettotal1 = xnettotal + xtotal;
                        grid.rows[i].cells[10].innerHTML = xnettotal1;

                        grandTotal3 = grandTotal3 + xnettotal1;

                       
                        

                        grid.rows[i].cells[11].children[0].value = xnettotal1;

                    }

                    grid.rows[grid.rows.length - 1].cells[9].innerHTML = grandTotal2;
                    grid.rows[grid.rows.length - 1].cells[10].innerHTML = grandTotal3;
                    grid.rows[grid.rows.length - 1].cells[11].innerHTML = grandTotal3;
                }

                $("body").on("change keyup", "[id*=xvatfixed]", function () {

                    //alert("Hi");
                    //Check whether Quantity value is valid Float number.
                    var quantity = parseFloat($.trim($(this).val()));
                    if (isNaN(quantity)) {
                        quantity = 0;
                    }

                    //Update the Quantity TextBox.
                    $(this).val(quantity);

                    //Calculate and update Grand Total.
                    var grandTotal = 0;
                    $("[id*=xvatfixed]").each(function () {
                        var quantity1 = parseFloat($.trim($(this).val()));
                        if (isNaN(quantity1)) {
                            quantity1 = 0;
                        }
                        grandTotal = grandTotal + quantity1;
                    });

                    fnCalculateVAT(grandTotal,7);

                });

                $("body").on("change keyup", "[id*=xvatperc]", function () {

                    //alert("Hi");
                    //Check whether Quantity value is valid Float number.
                    var quantity = parseFloat($.trim($(this).val()));
                    if (isNaN(quantity)) {
                        quantity = 0;
                    }

                    //Update the Quantity TextBox.
                    $(this).val(quantity);

                    //Calculate and update Grand Total.
                    var grandTotal = 0;
                    $("[id*=xvatperc]").each(function () {
                        var quantity1 = parseFloat($.trim($(this).val()));
                        if (isNaN(quantity1)) {
                            quantity1 = 0;
                        }
                        grandTotal = grandTotal + quantity1;
                    });

                    fnCalculateVAT(grandTotal,8);

                });

                <%--                $("body").on("click", ".bm_subject_teacher", function() {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $("#<%= _subteacher.ClientID%>").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });--%>

                <%--                $("body").on("click", ".bm_class_teacher", function () {
                    //alert("Button was clicked.");
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _classteacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });--%>

                <%--                // $("body").on("click", ".bm_subject", function () {
                //alert("Button was clicked.");
                //fnOpenSubjectList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                // });--%>
                
               
                <%--                    $("body").on("click", "#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox", function () {
                    //Get number of checkboxes in list either checked or not checked
                    var totalCheckboxes = $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox").size();
                    //Get number of checked checkboxes in list
                    var checkedCheckboxes = $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox:checked").size();
                    //Check / Uncheck top checkbox if all the checked boxes in list are checked
                    $("#<%=GridView1.ClientID%> input[id*='chkall']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
                });--%>

                
                <%-- $("body").on("click", "#<%=GridView1.ClientID%> input[id*='chkall']:checkbox", function () {
                    //Check/uncheck all checkboxes in list according to main checkbox 
                    $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox").attr('checked', $(this).is(':checked'));
                 });--%>

                <%--$("body").on("click", ".bm_tfccode", function () {
                     //alert($("#<%=GridView1.ClientID%>").attr("ID"));
                     //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                    if($("#<%=hxstatus.ClientID%>").val()=="")
                     {
                        fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"),$("#<%=GridView1.ClientID%>").attr("ID"));
                     }
                 
                     //fnOpenTFCCodeList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(),$(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xtfccodetitle").attr("ID"));
                });--%>
                
                
                <%--$("body").on("click", ".bm_student", function () {
                    //alert("Hi");
                    //alert($(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    if ($("#<%=hxstatus.ClientID%>").val() == "") {
                        fnOpenStudentList2(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val(), $(this).parent(".bm_list_img").parent(".bm_clt_ctl_50_100").parent(".bm_ctl_container_50_100").siblings().find(".xstdname").attr("ID"));
                    }
                });--%>

                $("body").on("click", ".bm_list", function () {
                    <%--//alert("Button was clicked.");
                    // alert(this.getAttribute("rowno"));
                    //                 alert(document.getElementById('<%=hxstatus.ClientID %>').value);
                 //                 return;
                 var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                 var xcttype1 = document.getElementById('<%=xcttype.ClientID %>').value;
                 if (xst == '' || xst == 'New' || xst == 'Undo' || xst == 'Undo1') {
                     var row = this.parentNode.parentNode;
                     var rowIndex = row.rowIndex - 1;
                     // alert(row.cells[4].getElementsByTagName("textarea")[0].id);
                     if (xcttype1 == 'Extra Test' || xcttype1 == 'Retest') {
                         fnOpenCommentsList(<%= HttpContext.Current.Session["business"] %>, row.cells[5].getElementsByTagName("textarea")[0].id, row.cells[5].getElementsByTagName("textarea")[0].value);
                     } else {
                         fnOpenCommentsList(<%= HttpContext.Current.Session["business"] %>, row.cells[4].getElementsByTagName("textarea")[0].id, row.cells[4].getElementsByTagName("textarea")[0].value);
                     }
                 }--%>
                });

                <%--//              $("body").on("click", ".bm_marks", function () {

             //                 var xst = document.getElementById('<%=hxstatus.ClientID %>').value;
                //                 var xcttype1 = document.getElementById('<%=xcttype.ClientID %>').value;
                //                 if (xst == '' || xst == 'New') {
                //                     var row = this.parentNode.parentNode;
                //                     var rowIndex = row.rowIndex - 1;
                //                     alert(row.cells[3].getElementsByTagName("input")[0].value);
                //                 }
                //             });--%>



                $("body").on("click", ".bm_am_btn_save", function () {

                    <%--//                alert("Hi");
                    //                return false;

                    var mendatoryFields = [
                                         { "id": "<%= xtfccode.ClientID%>", "prop": "listtext", "tab": "0" },
                                    { "id": "<%= xeffdate.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= xamount.ClientID%>", "prop": "text", "tab": "0" },
                                    { "id": "<%= xsign.ClientID%>", "prop": "text", "tab": "0" }
            ];
            var mendatoryString = JSON.stringify(mendatoryFields);
            if (!fnMendatoryFields1(mendatoryString)) {
                return false;
            }


            return true;--%>
                });


                $("body").on("change keyup", "[id*=xdiscount]", function () {

                    //alert("Hi"); 
                    //c=67
                    //if (window.event.keyCode == 67) {
                    //    //alert("c");
                    //    var row = this.parentNode.parentNode;
                    //    var rowIndex = row.rowIndex - 1;
                    //    $(this).val(row.cells[2].innerHTML);
                    //    //alert(row.cells[2].innerHTML);
                    //}

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
                    var i = 1;
                    $("[id*=xdiscount]").each(function () {
                        var quantity1 = parseFloat($.trim($(this).val()));
                        if (isNaN(quantity1)) {
                            quantity1 = 0;
                        }
                        //grandTotal = grandTotal + quantity1;

                        if(quantity1!=0 || $.trim($(this).val())!="") {
                            
                            var xdefamount = parseFloat(grid.rows[i].cells[2].innerHTML);

                            if (isNaN(xdefamount)) {
                                xdefamount = 0;
                            }

                            var xdistype = grid.rows[i].cells[4].children[0].value;

                            var discount;
                            var netamount;
                            if (xdistype == "%") {
                                discount = xdefamount * quantity1 / 100;
                                netamount= parseFloat(xdefamount - discount);
                            } else {
                                //discount = xdefamount - quantity1;
                                netamount= parseFloat(xdefamount - quantity1);
                            }

                             

                            grid.rows[i].cells[5].innerHTML = netamount;

                            //grid.rows[i].cells[5].getElementsByTagName("span")[0].innerHTML = netamount;

                            grandTotal = grandTotal + netamount;

                        }
                        

                        i = i + 1;
                    });

                    <%--var grid = document.getElementById('<%=GridView1.ClientID %>');--%>
                    //alert(grid);
                    grid.rows[grid.rows.length - 1].cells[5].innerHTML = grandTotal;

                    //var grandTotal1 = 0;

                    //for (var i = 2; i < grid.rows.length - 1; i++) {
                    //    var xreceived1 = parseFloat(grid.rows[i].cells[3].children[0].value);
                    //    //var xnettotal1 = parseFloat(grid.rows[i].cells[10].innerHTML);
                    //    //var xdue = xnettotal1 - xreceived1;
                    //    //grid.rows[i].cells[12].innerHTML = xdue;

                    //    grandTotal1 = grandTotal1 + xdue;
                    //}

                    ////grid.rows[grid.rows.length - 1].cells[12].innerHTML = grandTotal1;
                    //alert(grid.rows[2].cells[4].children[0].value);

                });

                $("body").on("change keyup", "[id*=xdistype]", function () {

                    var row = this.parentNode.parentNode;
                    //alert(row.rowIndex);
                    var rowIndex = row.rowIndex ;
                    //alert("Hi"); 
                    var grid = document.getElementById('<%=GridView1.ClientID %>');

                    //alert(grid.rows[rowIndex].cells[3].children[0].value);
                    //Check whether Quantity value is valid Float number.
                    //var quantity = parseFloat($.trim($(this).val()));
                    var quantity = parseFloat($.trim(grid.rows[rowIndex].cells[3].children[0].value));
                    if (isNaN(quantity)) {
                        quantity = 0;
                        
                    }

                    //Update the Quantity TextBox.
                    //$(this).val(quantity);
                    grid.rows[rowIndex].cells[3].children[0].value = quantity;

                    

                    //Calculate and update Grand Total.
                    var grandTotal = 0;
                    var i = 1;
                    $("[id*=xdiscount]").each(function () {
                        //var quantity1 = parseFloat($.trim($(this).val()));
                        var quantity1 = parseFloat($.trim(grid.rows[i].cells[3].children[0].value));
                        if (isNaN(quantity1)) {
                            quantity1 = 0;
                        }
                        //grandTotal = grandTotal + quantity1;

                        if(quantity1!=0 || $.trim($(this).val())!="") {
                            
                            var xdefamount = parseFloat(grid.rows[i].cells[2].innerHTML);

                            if (isNaN(xdefamount)) {
                                xdefamount = 0;
                            }

                            var xdistype = grid.rows[i].cells[4].children[0].value;

                            var discount;
                            var netamount;
                            if (xdistype == "%") {
                                discount = xdefamount * quantity1 / 100;
                                netamount= parseFloat(xdefamount - discount);
                            } else {
                                //discount = xdefamount - quantity1;
                                netamount= parseFloat(xdefamount - quantity1);
                            }

                             

                            grid.rows[i].cells[5].innerHTML = netamount;

                            grandTotal = grandTotal + netamount;

                        }
                        

                        i = i + 1;
                    });

                    
                     //alert(grid);
                     grid.rows[grid.rows.length - 1].cells[5].innerHTML = grandTotal;

                     

                });


                function ConfirmMessage() {
                    var selectedvalue = confirm("Do you want to paid? After paid cann't change record.");
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


                function fnPrintReceipt() {
                    // alert("Hi");
                    var zid = <%= HttpContext.Current.Session["business"] %>;
                    var xrow = $("#<%= hiddenxrow.ClientID%>").val();
                    var xtype = "Admission";
                    var openwin = window.open('/forms/academic/reports/rptamtfc.aspx?zid=' + zid + '&xrow=' + xrow + '&xtype=' + xtype, 'rptamtfc', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
                    openwin.focus();
                    //openwin.print();
                    //return false;
                }

                

                //$.key('alt+s', function() {
                    
                //        $("[id*=btnSave]").click();
                
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

                //$.key('alt+p', function() {

                //    $("[id*=btnPaid]").click();

                //});

                //$.key('alt+shift+p', function() {

                //    $("[id*=btnPrint]").click();

                //});

                $.hotkeys.add('f9',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnPrint.ClientID%>").click();
                });

                //$.key('alt+c', function() {

                //    $("[id*=btnClose]").click();

                //});

                $.hotkeys.add('f4',function(){
                    //alert('Pressed Ctrl+s');
                    $("#btnClose").click();
                });

                //$.key('alt+g', function() {

                //    $("[id*=btnGenerateID]").click();

                //});

                $.hotkeys.add('f2',function(){
                    //alert('Pressed Ctrl+s');
                    $("#<%= btnGenerateID.ClientID%>").click();
                });

                //$(document).bind('keydown', 'alt+s', function() {
                //    $("[id*=btnSave]").click();
                //});
                
                $("body").on("keyup", "[id*=xreceived]", function() {
                    enter(this, event);
                });
                $("body").on("keyup", "[id*=xremarks]", function() {
                    enter(this, event);
                });
                //$("body").on("keyup", "[id*=xtfccode]", function() {
                //    enter(this, event);
                //});

                $("body").on("keyup", "[id*=xdiscount]", function() {
                    enter(this, event);
                });

                $("body").on("keyup", "[id*=xnetamount]", function() {
                    enter(this, event);
                });

            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Admission Receipts</span>
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
                            <div class="button_section_style1" style="text-align: left;">
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                    OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnPaid" runat="server" Text="Paid" CssClass="bm_academic_button3 bm_am_btn_paid"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnPaid_Click" />
                                <%-- <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="bm_academic_button3 bm_am_btn_active"
                                    OnClick="btnActive_Click" />
                                <asp:Button ID="btnInactive" runat="server" Text="Inactive" CssClass="bm_academic_button3 bm_am_btn_inactive"
                                    OnClick="btnInactive_Click" />--%>
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="bm_academic_button3 bm_am_btn_print"
                                    OnClientClick="fnPrintReceipt();" />
                                <input type="button" id="btnClose" value="Close" class="bm_academic_button3 bm_am_btn_close" onclick="self.close();">
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_input_section">
                        <div class="bm_layout_container">
                            <div class="bm_layout_box_100">
                                <div class="bm_layout_box_padding" style="padding-top: 0px;">
                                </div>
                            </div>
                        </div>
                        <div class="bm_academic_container_footer">
                            <div class="footer_list_padding1" style="padding-top: 0px">
                                <div class="bm_academic_grid_container2" style="width: 100%">
                                    <div class="bm_hotkey" style="clear: both; padding-left: 10px;padding-bottom: 5px">
                                        <table style="border:1px solid white"><tr style="border: 1px solid white">
                                            <td style="background-color: Gray; color: black;margin: 1px">Hotkeys</td>
                                            <td style="background-color: silver; color: green;margin: 1px">Save - F10</td>
                                            <td style="background-color: silver; color: red;margin: 1px">Delete - F6</td>
                                            <%--<td style="background-color: silver; color: blue;margin: 1px">Paid - Alt + P</td>--%>
                                            <td style="background-color: silver; color: chocolate;margin: 1px">Print - F9</td>
                                            <td style="background-color: silver; color: black;margin: 1px">Close - F4</td>
                                            <td style="background-color: silver; color:darkcyan;margin: 1px">GenerateID - F2</td>
                                            <td style="background-color: silver; color:darkgreen; margin: 1px">Press 'c' for copy net amount</td>
                                            </tr></table>
                                    </div>
                                    <div style="width: 40%; padding: 0px 2px 10px 10px; float: left;">
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" Text="Student ID :" AssociatedControlID="xstdid"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xstdid" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div style="float: left; width: 200px; padding-left: 10px;">
                                            <asp:Button ID="btnGenerateID" runat="server" Text="Generate ID" CssClass="bm_academic_button3 bm_am_btn_save"
                                                OnClick="btnGenerateID_Click" />
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 365px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label9" runat="server" Text="Student Name :" AssociatedControlID="xname"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 243px">
                                                <%--<asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label7" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%--<asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xclass" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label8" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%-- <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xgroup" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label2" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%--<asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="xsession" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" Text="Charge Period :" AssociatedControlID="xcdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%-- <asp:TextBox ID="xcperiod" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                                <asp:DropDownList ID="xcdate" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass"
                                                    OnTextChanged="xcdate_OnTextChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label1" runat="server" Text="Transaction Date :" AssociatedControlID="xtdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xtdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label12" runat="server" Text="Advance Received :" AssociatedControlID="xadvreceive"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <%-- <asp:TextBox ID="xcperiod" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>--%>
                                                <asp:DropDownList ID="xadvreceive" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass"
                                                    >
                                                </asp:DropDownList>
                                            </div>
                                        </div> 
                                        <div style="float: left; margin-left: 10px; color: #0000cd; font-size: 14px;">
                                        [Session Perspective]
                                            </div>

                                        <div class="bm_clt_padding">
                                        </div>

                                        <div class="bm_ctl_container_50_50" style="float: left; width: 365px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label4" runat="server" Text="Bank Name :" AssociatedControlID="xbank"
                                                    CssClass="label"></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 243px">
                                                <asp:DropDownList ID="xbank" runat="server" CssClass="bm_academic_dropdown_50_50 bm_academic_ctl_global bm_academic_dropdown bm_xclass">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>
                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label5" runat="server" Text="Cheque Date :" AssociatedControlID="xchqdate"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xchqdate" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bm_clt_padding">
                                        </div>

                                        <div class="bm_ctl_container_50_50" style="float: left; width: 270px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 120px">
                                                <asp:Label ID="Label6" runat="server" Text="Cheque No. :" AssociatedControlID="xchqno"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                            <div class="bm_clt_ctl_50_50" style="width: 148px">
                                                <asp:TextBox ID="xchqno" runat="server" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                            </div>
                                        </div>




                                    </div>

                                    <div style="width: 40%; float: left; margin-top: 150px; text-align: left;">
                                        <div class="bm_ctl_container_50_50" style="width: 120px; margin-bottom: 10px">
                                            <div class="bm_ctl_label_align_right_50_50" style="width: 118px">
                                                <asp:Label ID="Label11" runat="server" Text="Note (if any) :"
                                                    CssClass="label "></asp:Label>
                                            </div>
                                        </div>
                                        <div style="width: 80%;">
                                            <asp:TextBox ID="xremarks" runat="server" Height="100px" TextMode="MultiLine" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%--<div style="clear: both"></div>--%>
                                    <div style="width: 100%; padding: 0px 2px 0px 10px; clear: both">
                                        <%-- <div style="background-color: #556b2f; color: #FFFFFF;padding: 5px">
                                            
                                            </div>--%>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                            CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                            RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                            PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound"
                                            UseAccessibleHeaderText="true" OnDataBound="GridView1_DataBound1">
                                            <%--<HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>--%>
                                            <Columns>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="bm_academic_container_body_button_section">
                        <div class="button_section_padding">
                            <div class="button_section_style1" style="text-align: left">
                                <asp:Button ID="btnRefresh1" runat="server" Text="Refresh" CssClass="bm_academic_button3 bm_am_btn_refresh"
                                    OnClick="btnRefresh_Click" />
                                <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="bm_academic_button3 bm_am_btn_save"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete1" runat="server" Text="Delete" CssClass="bm_academic_button3 bm_am_btn_delete"
                                    OnClientClick="javascript:ConfirmMessage1();" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnPaid1" runat="server" Text="Paid" CssClass="bm_academic_button3 bm_am_btn_paid"
                                    OnClientClick="javascript:ConfirmMessage();" OnClick="btnPaid_Click" />
                                <%-- <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="bm_academic_button3 bm_am_btn_active"
                                    OnClick="btnActive_Click" />
                                <asp:Button ID="btnInactive" runat="server" Text="Inactive" CssClass="bm_academic_button3 bm_am_btn_inactive"
                                    OnClick="btnInactive_Click" />--%>
                                <asp:Button ID="btnPrint1" runat="server" Text="Print" CssClass="bm_academic_button3 bm_am_btn_print"
                                    OnClientClick="fnPrintReceipt();" />
                                <input type="button" id="btnClose1" value="Close" class="bm_academic_button3 bm_am_btn_close" onclick="self.close();">
                            </div>
                        </div>
                    </div>
                </div>



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

   
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
