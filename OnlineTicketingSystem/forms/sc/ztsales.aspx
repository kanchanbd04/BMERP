<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ztsales.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztsales"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <%--   <link rel="stylesheet" href="../../Scripts/jquery-ui-1.8.17/themes/base/jquery.ui.all.css">
    --%>
    <link rel="stylesheet" href="../../Styles/coach.css">
    <link rel="stylesheet" href="../../Styles/buslayout.css">
    <link rel="stylesheet" href="../../Styles/bm.css">
    <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript">


        //           $("[id*=btnSave]").live("click", function () {

        //                   $("#popupbooking").dialog('close');
        //               });
           
    </script>
    <script type="text/javascript">

        //     function closeDialog(dlg) {

        //         $(dlg).dialog('close');
        //     }


        var SaleData = {};
        var CancelData = {};
        var BookedData = {};
        var ForSaleData = {};
        var ForSaleSold = {};
        var ConfirmBooked = {};

        SaleData.Seats = [];
        CancelData.Seats = [];
        BookedData.Seats = [];
        ForSaleData.Seats = [];
        ForSaleSold.Seats = [];
        ConfirmBooked.Seats = [];





        function resetObject() {

            SaleData.Seats = [];
            CancelData.Seats = [];
            BookedData.Seats = [];
            ForSaleData.Seats = [];
            ForSaleSold.Seats = [];
            ConfirmBooked.Seats = [];

            var xdate = $("#<%= xdate.ClientID%>").val();
            var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();

            $.ajax({
                url: "ztbooking.aspx/fnDelectSelBtn",

                type: "POST",

                data: "{'xdate2' :'" + xdate + "', 'xcoach2' :'" + xcoachno + "','xrouteid':'" + routeid + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    r = res.d;
                    if (r != "success") {
                        alert(r);
                    }
                    //alert(r);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });
        }


        function Processing(sid) {

            //alert(sid);
            var r = -1;
            var xdate = $("#<%= xdate.ClientID%>").val();
            var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();

            $.ajax({
                url: "ztbooking.aspx/process",

                type: "POST",

                data: "{'sid':'" + sid + "', 'xdate2' :'" + xdate + "', 'xcoach2' :'" + xcoachno + "','xrouteid':'" + routeid + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    r = res.d;
                    //alert(r);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            //alert(r);
            return r;
        }

        function CProcessing(sid) {


            Processing(sid);
        }


        $("input[type='button'].btn").live("click", function () {

            var flag = Processing($(this).attr("id"));
            //            alert(flag);
            //            return false;
            ////         if (flag == 2) {
            ////             alert("remove");
            ////             //return flase;
            ////         }
            if (flag == -1) {
                alert("something wrong");
                return flase;
            }
            if (flag == 1) {

                //$(this).css("background-color", "#BC8F8F");
                alert("Seat is on processing");

            }
            else if (flag == 180) {
                alert("Please refresh the coach before operation.");
            }
            else {




                var val = $(this).val();
                $("#seatInfo").html(val);
                $(this).toggleClass("processing");

                if ($(this).hasClass("processing")) {

                    $(this).css("background-color", "#BC8F8F");
                    SaleData.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });

                }
                else {

                    $(this).css("background-color", "");
                    findAndRemove(SaleData.Seats, "SeatId", $(this).attr("id"));
                }


            }



        });

        $("input[type='button'].forsale").live("click", function () {


            var flag = Processing($(this).attr("id"));

            ////         if (flag == 2) {
            ////             alert("remove");
            ////             //return flase;
            ////         }
            if (flag == -1) {
                alert("something wrong");
                return false;
            }
            if (flag == 1) {

                //$(this).css("background-color", "#BC8F8F");
                alert("Seat is on processing");

            }

            else if (flag == 180) {
                alert("Please refresh the coach before operation.");
            }
            else {


                var val = $(this).val();
                $("#seatInfo").html(val);
                $(this).toggleClass("processing");

                if ($(this).hasClass("processing")) {

                    $(this).css("background-color", "#BC8F8F");
                    ForSaleSold.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });


                }
                else {

                    $(this).css("background-color", "");
                    findAndRemove(ForSaleSold.Seats, "SeatId", $(this).attr("id"));

                }


            }



        });


        $("input[type='button'].sold").live("click", function () {


            ///////////////////
            var flag = ChkUser($(this).attr("value"));

            //            if (flag == 1) {
            //                alert("You are not authorized for operation on this seat.");
            //                return flase;
            //            }
            if (flag == -1) {
                alert("Something wrong");
                return false;
            }
            if (flag == -11) {
                alert("This seat was not sold in this route.");
                return false;
            }
            if (flag == 11) {
                alert("Database Failure. Try Again.");
                return false;
            }

            ////////////////

            var val = $(this).val();
            $("#seatInfo").html(val);
            $(this).toggleClass("fsi");

            if ($(this).hasClass("fsi")) {


                ForSaleData.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });

            }
            else {


                findAndRemove(ForSaleData.Seats, "SeatId", $(this).attr("id"));
            }






        });


        $("input[type='button'].mansale").live("click", function () {


            ///////////////////
            var flag = ChkUser($(this).attr("value"));

            //            if (flag == 1) {
            //                alert("You are not authorized for operation on this seat.");
            //                return flase;
            //            }
            if (flag == -1) {
                alert("Something wrong");
                return false;
            }
            if (flag == -11) {
                alert("This seat was not sold in this route.");
                return flase;
            }
            if (flag == 11) {
                alert("Database Failure. Try Again.");
                return false;
            }

            ////////////////

            var val = $(this).val();
            $("#seatInfo").html(val);
            $(this).toggleClass("fsi");

            if ($(this).hasClass("fsi")) {


                ForSaleData.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });

            }
            else {


                findAndRemove(ForSaleData.Seats, "SeatId", $(this).attr("id"));
            }






        });


        $("input[type='button'].booking").live("click", function () {


            //         var flag = CProcessing($(this).attr("id"));

            //         ////         if (flag == 2) {
            //         ////             alert("remove");
            //         ////             //return flase;
            //         ////         }
            //         if (flag == -1) {
            //             alert("something wrong");
            //             return flase;
            //         }
            //         if (flag == 1) {

            //             //$(this).css("background-color", "#BC8F8F");
            //             alert("Seat is on processing");

            //         }
            //         else {

            //         var xdate = $("#<%= xdate.ClientID%>").val();
            //         var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            //         var xseat = $(this).val();

            //         $.ajax({
            //             url: "ztsales.aspx/fnLoadCtlBooking",

            //             type: "POST",

            //             data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + xseat + "'}",

            //             //dataType: "json",
            //             contentType: "application/json; charset=utf-8",

            //             async: false,
            //             success: function (res) {

            //                 f = res.d;

            //                 var zseat = f.split(",");

            //                 for (i = 0; i < zseat.length; i++) { 
            //                 
            //                 }
            //                 //alert(r);
            //                 //alert("Success");
            //                 //return r;
            //             },
            //             error: function (err) {
            //                 alert("ERROR : " + err);
            //             }


            //         });



            var val = $(this).val();
            $("#seatInfo").html(val);
            $(this).toggleClass("cancelbooking");

            if ($(this).hasClass("cancelbooking")) {

                $(this).css("background-color", "#DA70D6");
                BookedData.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });

            }
            else {

                $(this).css("background-color", "");
                findAndRemove(BookedData.Seats, "SeatId", $(this).attr("id"));
            }


            // }



        });

        function ChkUser(sid) {

            var r = -1;
            var xdate = $("#<%= xdate.ClientID%>").val();
            var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();
            //alert(sid + " " + xdate + " " + xcoachno);
            $.ajax({
                url: "ztsales.aspx/fnChkUser",

                type: "POST",

                data: "{'sid':'" + sid + "', 'xdate2' :'" + xdate + "', 'xcoach2' :'" + xcoachno + "','xrouteid':'" + routeid + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    r = res.d;

                    //alert(r);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            //alert(r);
            return r;

        }

        $("input[type='button'].confbooking").live("click", function () {


            var flag = ChkUser($(this).attr("value"));

            //            if (flag == 1) {
            //                alert("You are not authorized for operation on this seat.");
            //                return flase;
            //            }
            if (flag == -1) {
                alert("Something wrong");
                return false;
            }
            if (flag == -11) {
                alert("This seat was not sold in this route.");
                return false;
            }
            if (flag == 11) {
                alert("Database Failure. Try Again.");
                return false;
            }
            //         if (flag == 1) {

            //             //$(this).css("background-color", "#BC8F8F");
            //             alert("Seat is on processing");

            //         }
            //         else {

            //         var xdate = $("#<%= xdate.ClientID%>").val();
            //         var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            //         var xseat = $(this).val();

            //         $.ajax({
            //             url: "ztsales.aspx/fnLoadCtlBooking",

            //             type: "POST",

            //             data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + xseat + "'}",

            //             //dataType: "json",
            //             contentType: "application/json; charset=utf-8",

            //             async: false,
            //             success: function (res) {

            //                 f = res.d;

            //                 var zseat = f.split(",");

            //                 for (i = 0; i < zseat.length; i++) { 
            //                 
            //                 }
            //                 //alert(r);
            //                 //alert("Success");
            //                 //return r;
            //             },
            //             error: function (err) {
            //                 alert("ERROR : " + err);
            //             }


            //         });



            var val = $(this).val();
            $("#seatInfo").html(val);
            $(this).toggleClass("cancelbooking");

            if ($(this).hasClass("cancelbooking")) {

                $(this).css("background-color", "#DA70D6");
                ConfirmBooked.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });

            }
            else {

                $(this).css("background-color", "");
                findAndRemove(ConfirmBooked.Seats, "SeatId", $(this).attr("id"));
            }


            // }



        });





        function findAndRemove(array, property, value) {
            var l = array.length;
            for (i = 0; i < l; i++) {
                if (array[i][property] == value) {
                    array.splice(i, 1);
                }
            }

        }


        function fnGetFare() {

            var f = "";
            var xdate = $("#<%= xdate.ClientID%>").val();
            var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            var xroute = $("#<%= xroute.ClientID%>").val();

            $.ajax({
                url: "ztbooking.aspx/getFare",

                type: "POST",

                data: "{'xdate2':'" + xdate + "', 'xcoachno2' : '" + xcoachno + "', 'xroute2' : '" + xroute + "' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    f = res.d;
                    //alert(f);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });



            return f;

        }

        function fnLoadSideList() {

            var xdate = $("#<%= xdate.ClientID%>").val();
            var xcoachno = $("#<%= xcoachno.ClientID%>").val();


            // load user sale amount
            $.ajax({
                url: "ztbooking.aspx/fnSideList123",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "', 'optfor':'xsold' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    $("#<%= xsold.ClientID%>").text(r);

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });


            // load user cancel amount
            $.ajax({
                url: "ztbooking.aspx/fnSideList123",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "', 'optfor':'xcan' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    $("#<%= xcan.ClientID%>").text(r);

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });


            // load user total sold amount
            $.ajax({
                url: "ztbooking.aspx/fnSideList123",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "', 'optfor':'xtotalsold' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    $("#<%= xtotalsold.ClientID%>").text(r);

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            // load total booked amount
            $.ajax({
                url: "ztbooking.aspx/fnSideList123",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "', 'optfor':'xtbooked' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    $("#<%= xtbooked.ClientID%>").text(r);

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            // load total sold amount
            $.ajax({
                url: "ztbooking.aspx/fnSideList123",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "', 'optfor':'xtsold' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    $("#<%= xtsold.ClientID%>").text(r);

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            // load total sold amount
            $.ajax({
                url: "ztbooking.aspx/fnSideList123",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "', 'optfor':'xtamount' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    $("#<%= xtamount.ClientID%>").text(r);

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            // load booking grid
            $.ajax({
                url: "ztbooking.aspx/fnSideGridViewBooking",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    //var r = res.d;
                    //$("#<%= GridView2.ClientID%>").html("");
                    $("[id*=GridView2] tr").not($("[id*=GridView2] tr:first-child")).remove();
                    for (var i = 0; i < res.d.length; i++) {
                        $("#<%= GridView2.ClientID%>").append("<tr><td>" + res.d[i].Xseat +
                                    "</td><td>" + res.d[i].Xname +
                                    "</td><td>" + res.d[i].Xphone +
                                    "</td><td>" + res.d[i].Xuser +
                                     "</td><td>" + res.d[i].Xboarding +
                                      "</td><td>" + res.d[i].Xdestination +
                                    "</td><td>" + res.d[i].Xexpired + "</td></tr>");
                    }

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            // load sold grid
            $.ajax({
                url: "ztbooking.aspx/fnSideGridViewSold",

                type: "POST",

                data: "{'xdate2' : '" + xdate + "', 'xcoach2' : '" + xcoachno + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    //var r = res.d;
                    //$("#<%= GridView1.ClientID%>").html("");
                    $("[id*=GridView1] tr").not($("[id*=GridView1] tr:first-child")).remove();
                    for (var i = 0; i < res.d.length; i++) {
                        $("#<%= GridView1.ClientID%>").append("<tr><td>" + res.d[i].Xseat +
                                    "</td><td>" + res.d[i].Xname +
                                    "</td><td>" + res.d[i].Xphone +
                                    "</td><td>" + res.d[i].Xticket +
                                    "</td><td>" + res.d[i].Xboarding +
                                    "</td><td>" + res.d[i].Xdestination +
                                    "</td><td>" + res.d[i].Xuser + "</td></tr>");
                    }

                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });


        }

        $("[id*=btndestroy]").live("click", function () {

            var xticket1 = $("#xtic").val();
            var xreason1 = $("#xreason").val();

            if (xticket1 == "[Select]") {

                alert("Please Select Ticket.");
                $("#xtic")._focus();
                return false;

            }

            if (xreason1 == "") {

                alert("Please enter reason.");
                $("#xreason")._focus();
                return false;
            }


            $.ajax({
                url: "ztsales.aspx/fnDestroyTicket",

                type: "POST",

                data: "{'xfromt1' : '" + xticket1 + "', 'xtot1':'" + xticket1 + "', 'xtotal1' : '1', 'xreason1' : '" + xreason1 + "' }",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    //alert(r);
                    if (r != "success") {
                        //                        if (r == "booked") {
                        //                            alert("Seat already booked. Your time period expired");
                        //                            fnChngBtnAppearance("booking");
                        //                            BookingData.Seats = [];
                        //                        }
                        //                        else {
                        alert(r);

                        //}
                    }
                    else {
                        fnLoadManTic("xtic");
                        $("#xreason").val("");
                        alert("Destroy successfull.");
                        //fnChngBtnAppearance("booking");
                        //SaleData.Seats = [];
                    }

                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });


            //            $("#popupdestroy").dialog('close');
            //            $("#popupmansale").dialog('close');

        });


        $("[id*=btnsale]").live("click", function () {


            $.ajax({
                url: "ztsales.aspx/fnSessionDestroy",

                type: "POST",

                data: "{}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    r = res.d;
                    //alert(r);
                    if (r != "success") {
                        alert(r);
                    }
                    //alert(r);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR (Destroy Session): " + err);
                }


            });

            var xdate = $("#<%= xdate.ClientID%>").val();

            $.ajax({
                url: "ztsales.aspx/fnChkAnyDiscount",

                type: "POST",

                data: "{'xdate1':'" + xdate + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    r = res.d;
                    //alert(r);
                    if (r == "enable_btn") {
                        $("[id*=btnreturn]").show();

                    }
                    else if (r == "disable_btn") {
                        $("[id*=btnreturn]").hide();
                    }
                    else {
                        alert(r);
                    }

                    //alert(r);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR (Destroy Session): " + err);
                }


            });


            $("[id*=btnsave]").attr("value", "Sale");
            $("#<%= xentrytype123.ClientID%>").val("sale");


            $("#<%= xname.ClientID%>").val("");
            $("#<%= xphone.ClientID%>").val("");
            $("#<%= xvotid.ClientID%>").val("");
            $("#<%= xboarding.ClientID%>").val("");
            $("#<%= xseat.ClientID%>").val("");
            $("#<%= xrate.ClientID%>").val("");
            $("#<%= xamount.ClientID%>").val("");
            var xentrytype1 = "sale";

            /*Retrive fare*/

            var fare = fnGetFare();
            //var fare = 0;

            if (SaleData.Seats.length > 0 || ForSaleSold.Seats.length > 0) {


                $("#<%= chkst.ClientID%>").val("sale");

                var txt = "";
                var ls = SaleData.Seats.length;
                var lf = ForSaleSold.Seats.length;

                var l = ls + lf;

                if (l > 3) {
                    alert("you can select maximum 3 seats");

                }

                else {

                    for (i = 0; i < ls; i++) {
                        txt += SaleData.Seats[i].SeatName;
                        if (i != ls - 1)
                            txt += ",";
                    }

                    if (lf > 0) {

                        if (ls > 0) {
                            txt += ",";
                        }

                        for (j = 0; j < lf; j++) {

                            txt += ForSaleSold.Seats[j].SeatName;
                            if (j != lf - 1)
                                txt += ",";
                        }
                    }

                    $("#<%= xseat.ClientID%>").val(txt);






                    //                    /*Retrive fare*/

                    //                    var fare = fnGetFare();

                    //             if (fare == "") {

                    //                 alert("empty");
                    //             }

                    //             else {
                    //                 alert(fare);
                    //             }

                    $("#<%= xrate.ClientID%>").val(fare);

                    var totalFare = l * fare;

                    $("#<%= xamount.ClientID%>").val(totalFare);


                    $("#popupbooking").dialog({
                        title: "Sale",
                        resizable: false,

                        height: 500,

                        width: 410,

                        modal: true
                        //                   buttons: {
                        //                       Save: function () {
                        //                           $(this).dialog('close');
                        //                       },

                        //                       Close: function () {
                        //                           $(this).dialog('close');
                        //                       }
                        //                   }
                    });

                }
            }
            else if (BookedData.Seats.length > 0) {

                $("#<%= chkst.ClientID%>").val("booked");

                var txt = "";
                var l = BookedData.Seats.length;
                if (l > 3) {
                    alert("you can select maximum 3 seats");

                }
                else {

                    var xdate = $("#<%= xdate.ClientID%>").val();
                    var xcoachno = $("#<%= xcoachno.ClientID%>").val();
                    var routeid = $("#<%= selected_route.ClientID%>").val();


                    for (i = 0; i < l; i++) {
                        txt += BookedData.Seats[i].SeatName;
                        if (i != l - 1)
                            txt += ",";
                    }




                    $.ajax({
                        url: "ztsales.aspx/fnLoadCtlBooking",

                        type: "POST",

                        data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + txt + "' , 'xstatus2' : 'booking', 'xrouteid' : '" + routeid + "', 'xentrytype2':'" + xentrytype1 + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            f = res.d;
                            if (f == "bg") {
                                alert("Select only one passenger.");
                            }
                            else {

                                if (f != "") {
                                    var xseat = f.split("|");
                                    if (xseat[0] == "success") {

                                        $("#<%= xname.ClientID%>").val(xseat[1]);
                                        $("#<%= xphone.ClientID%>").val(xseat[2]);
                                        $("#<%= xvotid.ClientID%>").val(xseat[3]);
                                        $("#<%= xboarding.ClientID%>").val(xseat[4]);
                                        $("#<%= xrate.ClientID%>").val(xseat[5]);

                                        var totalFare = l * fare;
                                        $("#<%= xamount.ClientID%>").val(totalFare);
                                        // $("#<%= xamount.ClientID%>").val(xseat[6]);
                                        $("#<%= xseat.ClientID%>").val(txt);

                                        //                                     var xst = xseat[7].split(",");

                                        //                                     for (y = 0; y < xst.length; y++) {

                                        //                                         BookedData.Seats[y].SeatName = xst[y];
                                        //                                     }

                                        //                                     $("#<%= xname.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xphone.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xvotid.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xboarding.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xrate.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xamount.ClientID%>").attr("disabled", "disabled");

                                        $("#popupbooking").dialog({
                                            title: "Sale",
                                            resizable: false,

                                            height: 500,

                                            width: 400,

                                            modal: true

                                        });
                                    }
                                    else {
                                        alert(f);
                                    }
                                }
                                else {
                                    alert("There is no row.");
                                }
                            }
                            //alert(r);
                            //alert("Success");
                            //return r;
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });




                }


            }
            else if (ConfirmBooked.Seats.length > 0) {

                $("#<%= chkst.ClientID%>").val("confbooked");

                var txt = "";
                var l = ConfirmBooked.Seats.length;
                if (l > 3) {
                    alert("you can select maximum 3 seats");

                }
                else {

                    var xdate = $("#<%= xdate.ClientID%>").val();
                    var xcoachno = $("#<%= xcoachno.ClientID%>").val();
                    var routeid = $("#<%= selected_route.ClientID%>").val();

                    for (i = 0; i < l; i++) {
                        txt += ConfirmBooked.Seats[i].SeatName;
                        if (i != l - 1)
                            txt += ",";
                    }




                    $.ajax({
                        url: "ztsales.aspx/fnLoadCtlBooking",

                        type: "POST",

                        data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + txt + "' , 'xstatus2' : 'confbooking', 'xrouteid' : '" + routeid + "','xentrytype2':'" + xentrytype1 + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            f = res.d;
                            if (f == "bg") {
                                alert("Select only one passenger.");
                            }
                            else {

                                if (f != "") {
                                    var xseat = f.split("|");
                                    if (xseat[0] == "success") {

                                        $("#<%= xname.ClientID%>").val(xseat[1]);
                                        $("#<%= xphone.ClientID%>").val(xseat[2]);
                                        $("#<%= xvotid.ClientID%>").val(xseat[3]);
                                        $("#<%= xboarding.ClientID%>").val(xseat[4]);
                                        $("#<%= xrate.ClientID%>").val(xseat[5]);
                                        var totalFare = l * fare;
                                        $("#<%= xamount.ClientID%>").val(totalFare);
                                        // $("#<%= xamount.ClientID%>").val(xseat[6]);
                                        $("#<%= xseat.ClientID%>").val(txt);

                                        //                                     var xst = xseat[7].split(",");

                                        //                                     for (y = 0; y < xst.length; y++) {

                                        //                                         BookedData.Seats[y].SeatName = xst[y];
                                        //                                     }

                                        //                                     $("#<%= xname.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xphone.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xvotid.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xboarding.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xrate.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xamount.ClientID%>").attr("disabled", "disabled");

                                        $("#popupbooking").dialog({
                                            title: "Sale",
                                            resizable: false,

                                            height: 500,

                                            width: 400,

                                            modal: true

                                        });
                                    }
                                    else {
                                        alert(f);
                                    }
                                }
                                else {
                                    alert("There is no row.");
                                }
                            }
                            //alert(r);
                            //alert("Success");
                            //return r;
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });




                }


            }
            else {
                alert("You didn't select a seat");
            }


            return false;
        });

        //Code for manual sales discount calculation
        $("[id*=xdiscount]").live("change", function () {

            var seatno = $("#<%= xmseat.ClientID%>").val();

            var xst = seatno.split(",");
            var noofseat = xst.length;

            var fare = fnGetFare();

            $("#<%= xdisrate.ClientID%>").val(fare);
            // alert(fare);

            var rate = parseInt(fare, 10);
            var rateafterdis = rate - parseInt($("#<%= xdiscount.ClientID%>").val(), 10);
            $("#<%= xmrate.ClientID%>").val(rateafterdis);

            var amount = rateafterdis * parseInt(noofseat, 10);
            $("#<%= xmamount.ClientID%>").val(amount);



        });

        $("[id*=xticket]").live("change", function () {

            //alert("test");
            if ($(this).children("option:selected").val() == "[Select]") {
                return false;
            }


            var selectedValue = $(this).children("option:selected").val();

            var firstVal = $(this).children("option:eq(1)").val();
            if (selectedValue != firstVal) {
                var re = confirm("You cannot select a ticket before using previous tickets.You have to show" +
                                " proper reason, why you are not using previous tickets.Do you want to show the reason?");
                if (re) {

                    fnLoadManTic("xtic");

                    $("#xreason").val("");

                    $("#popupdestroy").dialog({
                        title: "Destroy",
                        resizable: false,

                        height: 500,

                        width: 400,

                        modal: true,
                        dialogClass: "no-close",
                        buttons: {
                            //                                               Save: function () {
                            //                                                   $(this).dialog('close');
                            //                                               }

                            Close: function () {
                                fnLoadManTic("xticket");
                                $(this).dialog('close');
                            }
                        }
                    });



                }
                //                else {
                $(this).val($(this).children("option:eq(1)").val());
                //}
            }

        });


        function fnLoadManTic(xtic) {

            $.ajax({
                url: "ztsales.aspx/fnLoadTicket",

                type: "POST",

                data: "{}",

                dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    r = res.d;

                    var select = $("#" + xtic);
                    select.children().remove();
                    if (r) {
                        $(r).each(function (index, item) {
                            select.append($("<option>").val(item.Value).text(item.Text));
                        });
                    }
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });


        }

        $("[id*=btnmansale]").live("click", function () {

            fnLoadManTic("xticket");
            $("#<%= xentrytype123.ClientID%>").val("mansale");


            $("#<%= xmname.ClientID%>").val("");
            $("#<%= xmphone.ClientID%>").val("");
            $("#<%= xmvotid.ClientID%>").val("");
            $("#<%= xmboarding.ClientID%>").val("");
            $("#<%= xmseat.ClientID%>").val("");
            $("#<%= xmrate.ClientID%>").val("");
            $("#<%= xmamount.ClientID%>").val("");
            $("#<%= xdiscount.ClientID%>").val("");
            $("#<%= xdisrate.ClientID%>").val("");

            var xentrytype1 = "mansale";

            /*Retrive fare*/

            var fare = fnGetFare();

            if (SaleData.Seats.length > 0 || ForSaleSold.Seats.length > 0) {


                $("#<%= chkst.ClientID%>").val("mansale");

                var txt = "";
                var ls = SaleData.Seats.length;
                var lf = ForSaleSold.Seats.length;

                var l = ls + lf;

                if (l > 3) {
                    alert("you can select maximum 3 seats");

                }

                else {

                    for (i = 0; i < ls; i++) {
                        txt += SaleData.Seats[i].SeatName;
                        if (i != ls - 1)
                            txt += ",";
                    }

                    if (lf > 0) {

                        if (ls > 0) {
                            txt += ",";
                        }

                        for (j = 0; j < lf; j++) {

                            txt += ForSaleSold.Seats[j].SeatName;
                            if (j != lf - 1)
                                txt += ",";
                        }
                    }

                    $("#<%= xmseat.ClientID%>").val(txt);




                    //                    /*Retrive fare*/

                    //                    var fare = fnGetFare();

                    //             if (fare == "") {

                    //                 alert("empty");
                    //             }

                    //             else {
                    //                 alert(fare);
                    //             }

                    $("#<%= xmrate.ClientID%>").val(fare);
                    $("#<%= xdisrate.ClientID%>").val(fare);
                    var totalFare = l * fare;

                    $("#<%= xmamount.ClientID%>").val(totalFare);


                    $("#popupmansale").dialog({
                        title: "Manual Sale",
                        resizable: false,

                        height: 500,

                        width: 400,

                        modal: true
                        //                   buttons: {
                        //                       Save: function () {
                        //                           $(this).dialog('close');
                        //                       },

                        //                       Close: function () {
                        //                           $(this).dialog('close');
                        //                       }
                        //                   }
                    });

                }
            }
            else if (BookedData.Seats.length > 0) {

                $("#<%= chkst.ClientID%>").val("booked");

                var txt = "";
                var l = BookedData.Seats.length;
                if (l > 3) {
                    alert("you can select maximum 3 seats");

                }
                else {

                    var xdate = $("#<%= xdate.ClientID%>").val();
                    var xcoachno = $("#<%= xcoachno.ClientID%>").val();
                    var routeid = $("#<%= selected_route.ClientID%>").val();

                    for (i = 0; i < l; i++) {
                        txt += BookedData.Seats[i].SeatName;
                        if (i != l - 1)
                            txt += ",";
                    }



                    $.ajax({
                        url: "ztsales.aspx/fnLoadCtlBooking",

                        type: "POST",

                        data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + txt + "' , 'xstatus2' : 'booking', 'xrouteid' : '" + routeid + "','xentrytype2':'" + xentrytype1 + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            f = res.d;
                            if (f == "bg") {
                                alert("Select only one passenger.");
                            }
                            else {

                                if (f != "") {
                                    var xseat = f.split("|");
                                    if (xseat[0] == "success") {

                                        $("#<%= xmname.ClientID%>").val(xseat[1]);
                                        $("#<%= xmphone.ClientID%>").val(xseat[2]);
                                        $("#<%= xmvotid.ClientID%>").val(xseat[3]);
                                        $("#<%= xmboarding.ClientID%>").val(xseat[4]);
                                        $("#<%= xmrate.ClientID%>").val(xseat[5]);

                                        var totalFare = l * fare;
                                        $("#<%= xmamount.ClientID%>").val(totalFare);
                                        // $("#<%= xamount.ClientID%>").val(xseat[6]);
                                        $("#<%= xmseat.ClientID%>").val(txt);

                                        //                                     var xst = xseat[7].split(",");

                                        //                                     for (y = 0; y < xst.length; y++) {

                                        //                                         BookedData.Seats[y].SeatName = xst[y];
                                        //                                     }

                                        //                                     $("#<%= xname.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xphone.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xvotid.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xboarding.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xrate.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xamount.ClientID%>").attr("disabled", "disabled");

                                        $("#popupmansale").dialog({
                                            title: "Sale",
                                            resizable: false,

                                            height: 500,

                                            width: 400,

                                            modal: true

                                        });
                                    }
                                    else {
                                        alert(f);
                                    }
                                }
                                else {
                                    alert("There is no row.");
                                }
                            }
                            //alert(r);
                            //alert("Success");
                            //return r;
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });




                }


            }
            else if (ConfirmBooked.Seats.length > 0) {

                $("#<%= chkst.ClientID%>").val("confbooked");

                var txt = "";
                var l = ConfirmBooked.Seats.length;
                if (l > 3) {
                    alert("you can select maximum 3 seats");

                }
                else {

                    var xdate = $("#<%= xdate.ClientID%>").val();
                    var xcoachno = $("#<%= xcoachno.ClientID%>").val();
                    var routeid = $("#<%= selected_route.ClientID%>").val();

                    for (i = 0; i < l; i++) {
                        txt += ConfirmBooked.Seats[i].SeatName;
                        if (i != l - 1)
                            txt += ",";
                    }




                    $.ajax({
                        url: "ztsales.aspx/fnLoadCtlBooking",

                        type: "POST",

                        data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + txt + "' , 'xstatus2' : 'confbooking', 'xrouteid' : '" + routeid + "','xentrytype2':'" + xentrytype1 + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            f = res.d;
                            if (f == "bg") {
                                alert("Select only one passenger.");
                            }
                            else {

                                if (f != "") {
                                    var xseat = f.split("|");
                                    if (xseat[0] == "success") {

                                        $("#<%= xmname.ClientID%>").val(xseat[1]);
                                        $("#<%= xmphone.ClientID%>").val(xseat[2]);
                                        $("#<%= xmvotid.ClientID%>").val(xseat[3]);
                                        $("#<%= xmboarding.ClientID%>").val(xseat[4]);
                                        $("#<%= xmrate.ClientID%>").val(xseat[5]);
                                        var totalFare = l * fare;
                                        $("#<%= xmamount.ClientID%>").val(totalFare);
                                        // $("#<%= xamount.ClientID%>").val(xseat[6]);
                                        $("#<%= xmseat.ClientID%>").val(txt);

                                        //                                     var xst = xseat[7].split(",");

                                        //                                     for (y = 0; y < xst.length; y++) {

                                        //                                         BookedData.Seats[y].SeatName = xst[y];
                                        //                                     }

                                        //                                     $("#<%= xname.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xphone.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xvotid.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xboarding.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xrate.ClientID%>").attr("disabled", "disabled");
                                        //                                     $("#<%= xamount.ClientID%>").attr("disabled", "disabled");

                                        $("#popupmansale").dialog({
                                            title: "Sale",
                                            resizable: false,

                                            height: 500,

                                            width: 400,

                                            modal: true

                                        });
                                    }
                                    else {
                                        alert(f);
                                    }
                                }
                                else {
                                    alert("There is no row.");
                                }
                            }
                            //alert(r);
                            //alert("Success");
                            //return r;
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });




                }


            }

            else {
                alert("You didn't select a seat");
            }


            return false;
        });

        $("[id*=btnhistory]").live("click", function () {


            $("#popuphistory").dialog({
                title: "History",
                resizable: false,

                height: 215,

                width: 450,

                modal: true
                //                   buttons: {
                //                       Save: function () {
                //                           $(this).dialog('close');
                //                       },

                //                       Close: function () {
                //                           $(this).dialog('close');
                //                       }
                //                   }
            });
            return false;
        });


        $("[id*=btnconfbooking]").live("click", function () {


            var d1 = new Date($("#<%= xdate.ClientID%>").val());
            var JDate = d1.getDate();
            var d2;
            var CDate;
            var tommorrow;
            /*  check date within 24 hour from this day */

            $.ajax({
                url: "ztsales.aspx/fnGetDate",

                type: "POST",

                data: "{}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    f = res.d;
                    d2 = new Date(f);

                    //alert(ds.getDate());
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });


            //////////////////////////////////////////////


            CDate = d2.getDate();
            tommorrow = d2.getDate() + 1;

            if (JDate == CDate || JDate == tommorrow) {

                $("[id*=btnsave]").attr("value", "Confirm");

                $("#<%= xname.ClientID%>").val("");
                $("#<%= xphone.ClientID%>").val("");
                $("#<%= xvotid.ClientID%>").val("");
                $("#<%= xboarding.ClientID%>").val("");
                $("#<%= xseat.ClientID%>").val("");
                $("#<%= xrate.ClientID%>").val("");
                $("#<%= xamount.ClientID%>").val("");


                if (SaleData.Seats.length > 0) {


                    $("#<%= chkst.ClientID%>").val("confbooking");

                    var txt = "";


                    var l = SaleData.Seats.length;

                    if (l > 3) {
                        alert("you can select maximum 3 seats");

                    }

                    else {

                        for (i = 0; i < l; i++) {
                            txt += SaleData.Seats[i].SeatName;
                            if (i != l - 1)
                                txt += ",";
                        }



                        $("#<%= xseat.ClientID%>").val(txt);


                        /*Retrive fare*/

                        var fare = fnGetFare();

                        //             if (fare == "") {

                        //                 alert("empty");
                        //             }

                        //             else {
                        //                 alert(fare);
                        //             }

                        $("#<%= xrate.ClientID%>").val(fare);

                        var totalFare = l * fare;

                        $("#<%= xamount.ClientID%>").val(totalFare);


                        $("#popupbooking").dialog({
                            title: "Confirm Booking",
                            resizable: false,

                            height: 500,

                            width: 400,

                            modal: true
                            //                   buttons: {
                            //                       Save: function () {
                            //                           $(this).dialog('close');
                            //                       },

                            //                       Close: function () {
                            //                           $(this).dialog('close');
                            //                       }
                            //                   }
                        });

                    }
                }
                else {
                    alert("You didn't select a seat");
                }
            }
            else {
                alert("Confirm ticket available  for current date or tomorrow.");
            }


            return false;
        });





        $("[id*=btnforsale]").live("click", function () {

            $("[id*=btnsave]").attr("value", "For Sale");

            $("#<%= xname.ClientID%>").val("");
            $("#<%= xphone.ClientID%>").val("");
            $("#<%= xvotid.ClientID%>").val("");
            $("#<%= xboarding.ClientID%>").val("");
            $("#<%= xseat.ClientID%>").val("");
            $("#<%= xrate.ClientID%>").val("");
            $("#<%= xamount.ClientID%>").val("");
            var xentrytype1 = "forsale";

            if (ForSaleData.Seats.length > 0) {


                $("#<%= chkst.ClientID%>").val("forsale");

                var txt = "";
                var l = ForSaleData.Seats.length;
                if (l > 3) {
                    alert("you can select maximum 3 seats");

                }
                else {

                    var xdate = $("#<%= xdate.ClientID%>").val();
                    var xcoachno = $("#<%= xcoachno.ClientID%>").val();
                    var routeid = $("#<%= selected_route.ClientID%>").val();

                    for (i = 0; i < l; i++) {
                        txt += ForSaleData.Seats[i].SeatName;
                        if (i != l - 1)
                            txt += ",";
                    }

                    $.ajax({
                        url: "ztsales.aspx/fnLoadCtlBooking",

                        type: "POST",

                        data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + txt + "' , 'xstatus2' : 'sold','xrouteid':'" + routeid + "','xentrytype2':'" + xentrytype1 + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            f = res.d;
                            if (f == "bg") {
                                alert("Select only one passenger.");
                            }
                            else {

                                if (f != "") {
                                    var xseat = f.split("|");

                                    if (xseat[0] == "success") {

                                        $("#<%= xname.ClientID%>").val(xseat[1]);
                                        $("#<%= xphone.ClientID%>").val(xseat[2]);
                                        $("#<%= xvotid.ClientID%>").val(xseat[3]);
                                        $("#<%= xboarding.ClientID%>").val(xseat[4]);
                                        $("#<%= xrate.ClientID%>").val(xseat[5]);

                                        var fare = parseInt($("#<%= xrate.ClientID%>").val(), 10);
                                        var amount = l * fare;
                                        $("#<%= xamount.ClientID%>").val(amount);
                                        //                                        $("#<%= xseat.ClientID%>").val(xseat[7]);
                                        $("#<%= xseat.ClientID%>").val(txt);

                                        //                                     var xst = xseat[7].split(",");

                                        //                                     for (y = 0; y < xst.length; y++) {

                                        //                                         BookedData.Seats[y].SeatName = xst[y];
                                        //                                     }

                                        //                                                                          $("#<%= xname.ClientID%>").attr("disabled", "disabled");
                                        //                                                                          $("#<%= xphone.ClientID%>").attr("disabled", "disabled");
                                        //                                                                          $("#<%= xvotid.ClientID%>").attr("disabled", "disabled");
                                        //                                                                          $("#<%= xboarding.ClientID%>").attr("disabled", "disabled");
                                        //                                                                          $("#<%= xrate.ClientID%>").attr("disabled", "disabled");
                                        //                                                                          $("#<%= xamount.ClientID%>").attr("disabled", "disabled");


                                        $("#<%= xamount.ClientID%>").attr("disabled", "disabled");
                                        $("#popupbooking").dialog({
                                            title: "For Sale",
                                            resizable: false,

                                            height: 500,

                                            width: 400,

                                            modal: true

                                        });
                                    }
                                    else {
                                        alert(f);
                                    }
                                }
                                else {
                                    alert("There is no row.");
                                }
                            }
                            //alert(r);
                            //alert("Success");
                            //return r;
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });




                }
            }

            else {
                alert("You didn't select a seat");
            }


            return false;
        });


        /*  Cancel button function  */

        $("[id*=btnCancel]").live("click", function () {


            //         $("#<%= cxdate.ClientID%>").val("");
            //         $("#<%= cxcoach.ClientID%>").val("");
            //         $("#<%= cxseat.ClientID%>").val("");
            //         $("#<%= cxnoofseat.ClientID%>").val("");

            if (ConfirmBooked.Seats.length > 0 && ForSaleData.Seats.length > 0) {
                alert("Only choose one of Confirm Booking or Sold Ticket for cancel, not both at the same time.");
                return false;
            }



            if (ConfirmBooked.Seats.length > 0) {

                var txt = "";
                var l = ConfirmBooked.Seats.length;
                if (l > 3) {
                    alert("you can select maximum 3 seats per cancel");

                }

                else {

                    for (i = 0; i < l; i++) {
                        txt += ConfirmBooked.Seats[i].SeatName;
                        if (i != l - 1)
                            txt += ",";
                    }

                    var xdate1 = $("#<%= xdate.ClientID%>").val();
                    var xcoachno1 = $("#<%= xcoachno.ClientID%>").val();
                    var xtime1 = $("#<%= xtime.ClientID%>").val();
                    $("#<%= cancelst.ClientID%>").val("Comfirm Booked");

                    $("#<%= cxdate.ClientID%>").val(xdate1);
                    $("#<%= cxcoach.ClientID%>").val(xcoachno1);
                    $("#<%= cxtime.ClientID%>").val(xtime1);
                    $("#<%= cxseat.ClientID%>").val(txt);
                    $("#<%= cxnoofseat.ClientID%>").val(l);







                    $("#popupcancel").dialog({
                        title: "Cancel Booking",
                        resizable: false,

                        height: 500,

                        width: 400,

                        modal: true
                        //                   buttons: {
                        //                       Save: function () {
                        //                           $(this).dialog('close');
                        //                       },

                        //                       Close: function () {
                        //                           $(this).dialog('close');
                        //                       }
                        //                   }
                    });

                }
            }
            else if (ForSaleData.Seats.length > 0) {

                var txt = "";
                var l = ForSaleData.Seats.length;
                if (l > 3) {
                    alert("you can select maximum 3 seats per cancel");

                }

                else {

                    for (i = 0; i < l; i++) {
                        txt += ForSaleData.Seats[i].SeatName;
                        if (i != l - 1)
                            txt += ",";
                    }

                    var xdate1 = $("#<%= xdate.ClientID%>").val();
                    var xcoachno1 = $("#<%= xcoachno.ClientID%>").val();
                    var xtime1 = $("#<%= xtime.ClientID%>").val();
                    $("#<%= cancelst.ClientID%>").val("Sold");

                    $("#<%= cxdate.ClientID%>").val(xdate1);
                    $("#<%= cxcoach.ClientID%>").val(xcoachno1);
                    $("#<%= cxtime.ClientID%>").val(xtime1);
                    $("#<%= cxseat.ClientID%>").val(txt);
                    $("#<%= cxnoofseat.ClientID%>").val(l);







                    $("#popupcancel").dialog({
                        title: "Cancel Booking",
                        resizable: false,

                        height: 500,

                        width: 400,

                        modal: true
                        //                   buttons: {
                        //                       Save: function () {
                        //                           $(this).dialog('close');
                        //                       },

                        //                       Close: function () {
                        //                           $(this).dialog('close');
                        //                       }
                        //                   }
                    });

                }
            }
            else {
                alert("You didn't select a seat");
            }
            return false;
        });

        function fnLoadPasslist() {

            var xdate3 = $("#<%= xdate.ClientID %>").val();
            var xcoach3 = $("#<%= xcoachno.ClientID%>").val();

            var page = "Reports/passengerlist.aspx?xdate1=" + xdate3 + "&xcoach1=" + xcoach3;  //get url of link

            var $dialog = $('<div></div>')
                        .html('<iframe id="printf" style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 600,
                            width: 900,
                            title: "Passenger List",


                            buttons: {
                                //                                "Print": function () { window.frames["printf"].print(); },
                                "Close": function () { $dialog.dialog('close'); }

                            },
                            close: function (event, ui) {

                                //                        __doPostBack(', '');  // To refresh gridview when user close dialog
                            }

                        });
            $dialog.dialog('open');

        }



        function fnPrintTicket() {



            //            var page = "Reports/ticketprint.aspx";  //get url of link

            //            var $dialog = $('<div></div>')
            //                        .html('<iframe id="printf" style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
            //                        .dialog({
            //                            autoOpen: false,
            //                            modal: true,
            //                            height: 650,
            //                            width: 950,
            //                            title: "Print Ticket",


            //                            buttons: {
            //                                //                                "Print": function () { window.frames["printf"].print(); },
            //                                "Close": function () { $dialog.dialog('close'); }

            //                            },
            //                            close: function (event, ui) {

            //                                //                        __doPostBack(', '');  // To refresh gridview when user close dialog
            //                            }

            //                        });
            //            $dialog.dialog('open');

            window.open("Reports/ticketprint.aspx", '', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=0, left=0, targets=_blank');

        }

        function fnPrintTicketReturn() {



            //            var page = "Reports/ticketprint.aspx";  //get url of link

            //            var $dialog = $('<div></div>')
            //                        .html('<iframe id="printf" style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
            //                        .dialog({
            //                            autoOpen: false,
            //                            modal: true,
            //                            height: 650,
            //                            width: 950,
            //                            title: "Print Ticket",


            //                            buttons: {
            //                                //                                "Print": function () { window.frames["printf"].print(); },
            //                                "Close": function () { $dialog.dialog('close'); }

            //                            },
            //                            close: function (event, ui) {

            //                                //                        __doPostBack(', '');  // To refresh gridview when user close dialog
            //                            }

            //                        });
            //            $dialog.dialog('open');

            window.open("Reports/ticketprintreturn.aspx", '', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=0, left=500, targets=_blank');

        }

        $("[id*=btnreturn]").live("click", function () {

            fnLoadReturn();
        });

        function fnLoadReturn() {

            //            var xdate3 = $("#<%= xdate.ClientID %>").val();
            //            var xcoach3 = $("#<%= xcoachno.ClientID%>").val();

            //            var page = "ztsalereturn.aspx";  //get url of link

            //            var $dialog = $('<div></div>')
            //                        .html('<iframe id="printf" style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
            //                        .dialog({
            //                            autoOpen: false,
            //                            modal: true,
            //                            height: 600,
            //                            width: 900,
            //                            title: "Passenger List",


            //                            buttons: {
            //                                //                                "Print": function () { window.frames["printf"].print(); },
            //                                "Close": function () { $dialog.dialog('close'); }

            //                            },
            //                            close: function (event, ui) {

            //                                //                        __doPostBack(', '');  // To refresh gridview when user close dialog
            //                            }

            //                        });
            //            $dialog.dialog('open');
            //window.open("vahiclerpt.aspx?xfrom1=" + xfrom1 + "&xto1=" + xto1);
            var xname1 = $("#<%= xname.ClientID%>").val();
            var xphone1 = $("#<%= xphone.ClientID%>").val();
            var xvotid1 = $("#<%= xvotid.ClientID%>").val();
            var xcoachno1 = $("#<%= xcoachno.ClientID%>").val();
            var xbustype1 = $("#<%= bustype1.ClientID%>").val();

            if (xname1 == "") {

                alert("Please enter passenger name.");
                $("#<%= xname.ClientID%>")._focus();
                return false;
            }
            else if (xphone1 == "") {

                alert("Please enter passenger phone number.");
                $("#<%= xphone.ClientID%>")._focus();
                return false;
            }
            else {

                window.open("ztsalereturn.aspx?xname1=" + xname1 + "&xphone1=" + xphone1 + "&xvotid1=" + xvotid1 + "&xcoachno1=" + xcoachno1 + "&xbustype1=" + xbustype1, '', 'toolbar=no, directories=no, location=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=800, height=700, targets=_blank');
            }

            return false;

        }

        $("[id*=btnshowhis]").live("click", function () {

            var xfrom1 = $("#<%= xfromdt.ClientID%>").val();
            var xto1 = $("#<%= xtodt.ClientID%>").val();

            if (xfrom1 == "" || xto1 == "") {
                alert("Please select date range.");
                return false;
            }

            var page = "Reports/saleshistory.aspx?xfrom1=" + xfrom1 + "&xto1=" + xto1;  //get url of link

            var $dialog = $('<div></div>')
                        .html('<iframe id="printf" style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 650,
                            width: 950,
                            title: "History",


                            buttons: {
                                //                                "Print": function () { window.frames["printf"].print(); },
                                "Close": function () { $dialog.dialog('close'); }

                            },
                            close: function (event, ui) {

                                //                        __doPostBack(', '');  // To refresh gridview when user close dialog
                            }

                        });
            $dialog.dialog('open');

            $("#popuphistory").dialog('close');

            return false;
        });

        $("[id*=btnpasslist]").live("click", function () {

            //            $("#<%= xbus.ClientID%>").val("[Select]");
            //            $("#<%= xdriver.ClientID%>").text("[Select]");
            //            $("#<%= xguide.ClientID%>").text("[Select]");

            var xdate1 = $("#<%= xdate.ClientID%>").val();
            var xcoachno1 = $("#<%= xcoachno.ClientID%>").val();
            var bustype3 = $("#<%= bustype1.ClientID%>").val();

            $("#<%= xpcoach.ClientID%>").val(xcoachno1);
            $("#<%= xpbustype.ClientID%>").val(bustype3);

            //            $.ajax({
            //                url: "ztsales.aspx/fnGetBus",

            //                type: "POST",

            //                data: "{'optfor':'bus'}",

            //                dataType: "json",
            //                contentType: "application/json; charset=utf-8",

            //                async: false,
            //                success: function (res) {

            //                    r = res.d;

            //                    var select = $("#xbus");
            //                    select.children().remove();
            //                    if (r) {
            //                        $(r).each(function (index, item) {
            //                            select.append($("<option>").val(item.Value).text(item.Text));
            //                        });
            //                    }
            //                },
            //                error: function (err) {
            //                    alert("ERROR : " + err);
            //                }


            //            });

            //            $.ajax({
            //                url: "ztsales.aspx/fnGetDriverGuide",

            //                type: "POST",

            //                data: "{'optfor':'driver'}",

            //                dataType: "json",
            //                contentType: "application/json; charset=utf-8",

            //                async: false,
            //                success: function (res) {

            //                    r = res.d;

            //                    var select = $("#xdriver");
            //                    select.children().remove();
            //                    if (r) {
            //                        $(r).each(function (index, item) {
            //                            select.append($("<option>").val(item.Value).text(item.Text));
            //                        });
            //                    }
            //                },
            //                error: function (err) {
            //                    alert("ERROR : " + err);
            //                }


            //            });

            //            $.ajax({
            //                url: "ztsales.aspx/fnGetDriverGuide",

            //                type: "POST",

            //                data: "{'optfor':'guide'}",

            //                dataType: "json",
            //                contentType: "application/json; charset=utf-8",

            //                async: false,
            //                success: function (res) {

            //                    r = res.d;

            //                    var select = $("#xguide");
            //                    select.children().remove();
            //                    if (r) {
            //                        $(r).each(function (index, item) {
            //                            select.append($("<option>").val(item.Value).text(item.Text));
            //                        });
            //                    }
            //                },
            //                error: function (err) {
            //                    alert("ERROR : " + err);
            //                }


            //            });



            //            if (xdate1 == "") {
            //                alert("Please select date.");
            //                $("#<%= xdate.ClientID%>")._focus();
            //                return false;
            //            }
            //            else if (xcoachno1 == "[Select]") {
            //                alert("Please select coach.");
            //                $("#<%= xcoachno.ClientID%>")._focus();
            //                return false;
            //            }
            //            else {


            //            }


            $.ajax({
                url: "ztsales.aspx/fnChkDriver",

                type: "POST",

                data: "{'xdate2' :'" + xdate1 + "', 'xcoach2' :'" + xcoachno1 + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    r = res.d;

                    if (r == "success") {


                        //                                                var xdate3 = $("#<%= xdate.ClientID %>").val();
                        //                                                var xcoach3 = $("#<%= xcoachno.ClientID%>").val();

                        //                                                newwindow = window.open('Repotrs/passengerlist.aspx?xdate1='+ xdate3 + '&xcoach1=' + xcoach3, '_blank', 'directories=no,height=500,width=500,location=no,status=no');
                        //                                                if (window.focus) {
                        //                                                    newwindow.focus();
                        //                                                }


                        fnLoadPasslist();


                    }
                    else if (r == "0") {


                        $("#popuppasslist").dialog({
                            title: "Passenger List",
                            resizable: false,

                            height: 500,

                            width: 400,

                            modal: true
                            //                   buttons: {
                            //                       Save: function () {
                            //                           $(this).dialog('close');
                            //                       },

                            //                       Close: function () {
                            //                           $(this).dialog('close');
                            //                       }
                            //                   }
                        });


                    }
                    else {
                        alert(r);
                    }
                    //alert(r);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            return false;
        });

        $("[id*=btnEditDriver]").live("click", function () {
            $("#<%= xdriver.ClientID%>").val("");
            $("#<%= xguide.ClientID%>").val("");
            var xcoachno1 = $("#<%= xcoachno.ClientID%>").val();
            var bustype3 = $("#<%= bustype1.ClientID%>").val();
            $("#<%= xpcoach.ClientID%>").val(xcoachno1);
            $("#<%= xpbustype.ClientID%>").val(bustype3);
            $("#popuppasslist").dialog({
                title: "Passenger List",
                resizable: false,

                height: 500,

                width: 400,

                modal: true
                //                   buttons: {
                //                       Save: function () {
                //                           $(this).dialog('close');
                //                       },

                //                       Close: function () {
                //                           $(this).dialog('close');
                //                       }
                //                   }
            });

            return false;
        });


        $("[id*=buttonpasslistsave]").live("click", function () {



            var xpcoach1 = $("#<%= xpcoach.ClientID%>").val();
            var xbus1 = $("#<%= xbus.ClientID%>").val();

            var xpbustype1 = $("#<%= xpbustype.ClientID%>").val();
            var xdriver1 = $("#<%= xdriver.ClientID%>").val();
            var xguide1 = $("#<%= xguide.ClientID%>").val();
            var xdate1 = $("#<%= xdate.ClientID%>").val();




            if (xpcoach1 == "") {

                alert("Please enter coach no.");
                $("#<%= xpcoach.ClientID%>")._focus();
                return false;
            }
            else if (xbus1 == "[Select]") {

                alert("Please select bus.");
                // $("#xbus")._focus();
                return false;
            }
            else if (xpbustype1 == "") {

                alert("Please enter bus type.");
                return false;
            }

            else if (xdriver1 == "") {

                alert("Please select driver.");
                return false;
            }
            else {






                $.ajax({
                    url: "ztsales.aspx/fnSaveDriver",

                    type: "POST",

                    data: "{'xpcoach2' : '" + xpcoach1 + "', 'xbus2':'" + xbus1 + "', 'xpbustype2' : '" + xpbustype1 + "', 'xdriver2' : '" + xdriver1 + "', 'xguide2' : '" + xguide1 + "', 'xdate2' : '" + xdate1 + "'}",

                    //dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    async: false,
                    success: function (res) {

                        var r = res.d;
                        if (r != "success") {
                            alert(r);
                        }
                        else {
                            fnLoadPasslist();
                        }


                    },
                    error: function (err) {
                        alert("ERROR : " + err);

                    }


                });




                $("#popuppasslist").dialog('close');
            }


        });




        function closeDialog() {
            $(function () {
                $("#popupbooking").dialog('close');
                //return false;
            });

        }


        function fnChngBtnAppearance(param) {

            if (param == "booking") {
                for (var i = 0; i < SaleData.Seats.length; i++) {
                    //alert(SaleData.Seats[i].SeatId);
                    $("#" + SaleData.Seats[i].SeatId).removeClass("processing");
                    $("#" + SaleData.Seats[i].SeatId).removeClass("btn");

                    $("#" + SaleData.Seats[i].SeatId).addClass("booking");
                    $("#" + SaleData.Seats[i].SeatId).css("background-color", "#FFCC99");
                }
            }
            else if (param == "cancelpending") {
                if (ForSaleData.Seats.length > 0) {
                    for (var i = 0; i < ForSaleData.Seats.length; i++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + ForSaleData.Seats[i].SeatId).removeClass("processing");
                        $("#" + ForSaleData.Seats[i].SeatId).removeClass("btn");
                        $("#" + ForSaleData.Seats[i].SeatId).removeClass("booking");
                        $("#" + ForSaleData.Seats[i].SeatId).removeClass("sold");
                        $("#" + ForSaleData.Seats[i].SeatId).removeClass("fsi");

                        $("#" + ForSaleData.Seats[i].SeatId).addClass("cancelpending");
                        $("#" + ForSaleData.Seats[i].SeatId).css("background-color", "#8A2BE2");
                    }
                }
                else {
                    for (var i = 0; i < ConfirmBooked.Seats.length; i++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("processing");
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("btn");
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("booking");
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("confbooking");

                        $("#" + ConfirmBooked.Seats[i].SeatId).addClass("cancelpending");
                        $("#" + ConfirmBooked.Seats[i].SeatId).css("background-color", "#8A2BE2");
                    }
                }
            }
            else if (param == "confbooked") {
                for (var i = 0; i < ConfirmBooked.Seats.length; i++) {
                    //alert(SaleData.Seats[i].SeatId);
                    $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("processing");
                    $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("btn");
                    $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("booking");
                    $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("confbooking");

                    $("#" + ConfirmBooked.Seats[i].SeatId).addClass("sold");
                    $("#" + ConfirmBooked.Seats[i].SeatId).css("background-color", "#990033");
                }
            }
            else if (param == "sold") {
                if (SaleData.Seats.length > 0) {
                    for (var i = 0; i < SaleData.Seats.length; i++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + SaleData.Seats[i].SeatId).removeClass("processing");
                        $("#" + SaleData.Seats[i].SeatId).removeClass("btn");
                        $("#" + SaleData.Seats[i].SeatId).removeClass("booking");
                        $("#" + SaleData.Seats[i].SeatId).removeClass("confbooking");

                        $("#" + SaleData.Seats[i].SeatId).addClass("sold");
                        $("#" + SaleData.Seats[i].SeatId).css("background-color", "#990033");
                    }
                }

                if (ForSaleSold.Seats.length > 0) {
                    for (var j = 0; j < ForSaleSold.Seats.length; j++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + ForSaleSold.Seats[j].SeatId).removeClass("processing");
                        $("#" + ForSaleSold.Seats[j].SeatId).removeClass("forsale");


                        $("#" + ForSaleSold.Seats[j].SeatId).addClass("sold");
                        $("#" + ForSaleSold.Seats[j].SeatId).css("background-color", "#990033");
                    }
                }

            }
            else if (param == "mansale") {
                if (SaleData.Seats.length > 0) {
                    for (var i = 0; i < SaleData.Seats.length; i++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + SaleData.Seats[i].SeatId).removeClass("processing");
                        $("#" + SaleData.Seats[i].SeatId).removeClass("btn");
                        $("#" + SaleData.Seats[i].SeatId).removeClass("booking");
                        $("#" + SaleData.Seats[i].SeatId).removeClass("confbooking");

                        $("#" + SaleData.Seats[i].SeatId).addClass("manticapppen");
                        $("#" + SaleData.Seats[i].SeatId).css("background-color", "#00FFFF");
                    }
                }

                if (ForSaleSold.Seats.length > 0) {
                    for (var j = 0; j < ForSaleSold.Seats.length; j++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + ForSaleSold.Seats[j].SeatId).removeClass("processing");
                        $("#" + ForSaleSold.Seats[j].SeatId).removeClass("forsale");


                        $("#" + ForSaleSold.Seats[j].SeatId).addClass("manticapppen");
                        $("#" + ForSaleSold.Seats[j].SeatId).css("background-color", "#00FFFF");
                    }
                }
                if (BookedData.Seats.length > 0) {
                    for (var i = 0; i < BookedData.Seats.length; i++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + BookedData.Seats[i].SeatId).removeClass("processing");
                        $("#" + BookedData.Seats[i].SeatId).removeClass("btn");
                        $("#" + BookedData.Seats[i].SeatId).removeClass("booking");

                        $("#" + BookedData.Seats[i].SeatId).addClass("manticapppen");
                        $("#" + BookedData.Seats[i].SeatId).css("background-color", "#00FFFF");
                    }

                }
                if (ConfirmBooked.Seats.length > 0) {
                    for (var i = 0; i < ConfirmBooked.Seats.length; i++) {
                        //alert(SaleData.Seats[i].SeatId);
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("processing");
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("btn");
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("booking");
                        $("#" + ConfirmBooked.Seats[i].SeatId).removeClass("confbooking");

                        $("#" + ConfirmBooked.Seats[i].SeatId).addClass("manticapppen");
                        $("#" + ConfirmBooked.Seats[i].SeatId).css("background-color", "#00FFFF");
                    }
                }

            }
            else if (param == "confbooking") {

                for (var i = 0; i < SaleData.Seats.length; i++) {
                    //alert(SaleData.Seats[i].SeatId);
                    $("#" + SaleData.Seats[i].SeatId).removeClass("processing");
                    $("#" + SaleData.Seats[i].SeatId).removeClass("btn");
                    $("#" + SaleData.Seats[i].SeatId).removeClass("booking");


                    $("#" + SaleData.Seats[i].SeatId).addClass("confbooking");
                    $("#" + SaleData.Seats[i].SeatId).css("background-color", "#99CC00");
                }




            }
            else if (param == "booked") {

                for (var i = 0; i < BookedData.Seats.length; i++) {
                    //alert(SaleData.Seats[i].SeatId);
                    $("#" + BookedData.Seats[i].SeatId).removeClass("processing");
                    $("#" + BookedData.Seats[i].SeatId).removeClass("btn");
                    $("#" + BookedData.Seats[i].SeatId).removeClass("booking");

                    $("#" + BookedData.Seats[i].SeatId).addClass("sold");
                    $("#" + BookedData.Seats[i].SeatId).css("background-color", "#990033");
                }
            }

            else if (param == "forsale") {

                for (var i = 0; i < ForSaleData.Seats.length; i++) {
                    //alert(SaleData.Seats[i].SeatId);
                    $("#" + ForSaleData.Seats[i].SeatId).removeClass("processing");
                    $("#" + ForSaleData.Seats[i].SeatId).removeClass("btn");
                    $("#" + ForSaleData.Seats[i].SeatId).removeClass("booking");
                    $("#" + ForSaleData.Seats[i].SeatId).removeClass("sold");
                    $("#" + ForSaleData.Seats[i].SeatId).removeClass("fsi");

                    $("#" + ForSaleData.Seats[i].SeatId).addClass("forsale");
                    $("#" + ForSaleData.Seats[i].SeatId).css("background-color", "#66CCFF");
                }
            }
            else {

                for (var i = 0; i < CancelData.Seats.length; i++) {
                    //alert(SaleData.Seats[i].SeatId);
                    $("#" + CancelData.Seats[i].SeatId).removeClass("booking");
                    $("#" + CancelData.Seats[i].SeatId).removeClass("processing");
                    $("#" + CancelData.Seats[i].SeatId).removeClass("cancelbooking");

                    $("#" + CancelData.Seats[i].SeatId).addClass("btn");
                    $("#" + CancelData.Seats[i].SeatId).css("background-color", "#D3D3D3");
                }

            }
        }


        $("[id*=btnmsave]").live("click", function () {


            var xdate1 = $("#<%= xdate.ClientID%>").val();
            var xcoach1 = $("#<%= xcoachno.ClientID%>").val();

            var xname1 = $("#<%= xmname.ClientID%>").val();
            var xphone1 = $("#<%= xmphone.ClientID%>").val();
            var xvotid1 = $("#<%= xmvotid.ClientID%>").val();
            var xboarding1 = $("#<%= xmboarding.ClientID%>").val();
            var xseat1 = $("#<%= xmseat.ClientID%>").val();
            var xticket1 = $("#xticket").val();
            //var xseat1 = SaleData.Seats.length;
            var xrate1 = $("#<%= xdisrate.ClientID%>").val();
            var xamount1 = $("#<%= xmamount.ClientID%>").val();
            var Time = $("#<%= xtime.ClientID%>").val();
            var route = $("#<%= xroute.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();
            var discount = $("#<%= xdiscount.ClientID%>").val();




            if (xname1 == "") {

                alert("Please enter passenger name.");
                $("#<%= xname.ClientID%>")._focus();
                return false;
            }
            else if (xphone1 == "") {

                alert("Please enter passenger phone number.");
                $("#<%= xphone.ClientID%>")._focus();
                return false;
            }
            else if (discount == "") {

                alert("Please enter 0 if you have no discount.");
                $("#<%= xphone.ClientID%>")._focus();
                return false;
            }
            else if (xrate1 == "") {

                alert("No fare exist. Please contact to your administrator.");
                return false;
            }

            else if (xticket1 == "[Select]") {

                alert("Please select ticket.");
                return false;
            }
            else {

                var chkst2 = $("#<%= chkst.ClientID%>").val();

                var xseatid1 = "";

                if (SaleData.Seats.length > 0 || ForSaleSold.Seats.length > 0) {

                    var ls = SaleData.Seats.length;
                    var lf = ForSaleSold.Seats.length;

                    for (i = 0; i < ls; i++) {
                        xseatid1 += SaleData.Seats[i].SeatId;
                        if (i != ls - 1)
                            xseatid1 += ",";
                    }

                    if (lf > 0) {

                        if (ls > 0) {
                            xseatid1 += ",";
                        }

                        for (j = 0; j < lf; j++) {

                            xseatid1 += ForSaleSold.Seats[j].SeatId;
                            if (j != lf - 1)
                                xseatid1 += ",";
                        }
                    }
                }

                var xforsale1 = "";
                var xforsaleseat = "";

                var len = ForSaleSold.Seats.length;


                if (chkst2 == "mansale") {
                    if (len > 0) {
                        for (i = 0; i < len; i++) {
                            xforsaleseat += ForSaleSold.Seats[i].SeatName;
                            if (i != len - 1)
                                xforsaleseat += ",";
                        }
                        xforsale1 = xforsaleseat;
                    }
                    else {
                        xforsale1 = "null";
                    }

                }
                else {
                    xforsale1 = "null";
                }


                $.ajax({
                    url: "ztbooking.aspx/fnSaveBooking",

                    type: "POST",

                    data: "{'chkst2' : '" + chkst2 + "','xstatus2':'manticapppen','xdate2':'" + xdate1 + "', 'xcoach2' : '" + xcoach1 + "', 'xname2' : '" + xname1 + "', 'xphone2' : '" + xphone1 + "', 'xvotid2' : '" + xvotid1 + "', 'xboarding2' : '" + xboarding1 + "', 'xseat2' : '" + xseat1 + "', 'xrate2' : '" + xrate1 + "', 'xamount2' : '" + xamount1 + "', 'xdateexp2' : '', 'xtimeexp2' : '', 'xbutton2' : 'mansale' , 'xseatid2' : '" + xseatid1 + "' , 'xforsale' : '" + xforsale1 + "', 'xrttime2' : '" + Time + "', 'xroute2' : '" + route + "', 'xticket2' : '" + xticket1 + "','xrouteid':'" + routeid + "','xdiscount':'" + discount + "' }",

                    //dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    async: false,
                    success: function (res) {

                        var r = res.d;
                        //alert(r);
                        if (r != "success") {
                            if (r == "booked") {
                                alert("Seat already booked. Your time period expired");

                                if (chkst2 == "booked") {
                                    fnChngBtnAppearance("booked");
                                }
                                else if (chkst2 == "confbooking") {
                                    fnChngBtnAppearance("confbooking");
                                }
                                else if (chkst2 == "mansale") {
                                    fnChngBtnAppearance("mansale");
                                }
                                else {
                                    fnChngBtnAppearance("sold");
                                }
                                SaleData.Seats = [];
                                BookedData.Seats = [];
                                ForSaleData.Seats = [];
                                ForSaleSold.Seats = [];
                                ConfirmBooked.Seats = [];
                            }
                            else {
                                alert(r);
                                SaleData.Seats = [];
                                BookedData.Seats = [];
                                ForSaleData.Seats = [];
                                ForSaleSold.Seats = [];
                                ConfirmBooked.Seats = [];
                            }
                        }
                        else {
                            if (chkst2 !== "forsale") {
                                //alert("Sell successfull.");
                                //alert(r);
                                fnLoadSideList();
                            }

                            //                            if (chkst2 == "booked") {

                            //                                fnChngBtnAppearance("booked");
                            //                            }
                            //                            else if (chkst2 == "confbooking") {
                            //                                fnChngBtnAppearance("confbooking");
                            //                            }
                            //                            else if (chkst2 == "confbooked") {
                            //                                fnChngBtnAppearance("confbooked");
                            //                            }
                            //                            else if (chkst2 == "forsale") {
                            //                                fnChngBtnAppearance("forsale");
                            //                            }
                            //                            else if (chkst2 == "mansale") {
                            //                                fnChngBtnAppearance("mansale");
                            //                            }
                            //                            else {
                            //                                fnChngBtnAppearance("sold");
                            //                            }

                            fnChngBtnAppearance("mansale");
                            SaleData.Seats = [];
                            BookedData.Seats = [];
                            ForSaleData.Seats = [];
                            ForSaleSold.Seats = [];
                            ConfirmBooked.Seats = [];
                        }

                        //return r;
                    },
                    error: function (err) {
                        alert("ERROR : " + err);
                        SaleData.Seats = [];
                        BookedData.Seats = [];
                        ForSaleData.Seats = [];
                        ForSaleSold.Seats = [];
                        ConfirmBooked.Seats = [];
                    }


                });




                $("#popupmansale").dialog('close');
            }

        });

        $("[id*=btnsave]").live("click", function () {

            //         var chkst2 = $("#<%= chkst.ClientID%>").val();

            //         if (chkst2 == "forsale") {

            //             fnChngBtnAppearance("forsale");
            //             return false;
            //             $("#popupbooking").dialog('close');
            //         }




            var xdate1 = $("#<%= xdate.ClientID%>").val();
            var xcoach1 = $("#<%= xcoachno.ClientID%>").val();

            var xname1 = $("#<%= xname.ClientID%>").val();
            var xphone1 = $("#<%= xphone.ClientID%>").val();
            var xvotid1 = $("#<%= xvotid.ClientID%>").val();
            var xboarding1 = $("#<%= xboarding.ClientID%>").val();
            var xseat1 = $("#<%= xseat.ClientID%>").val();

            //var xseat1 = SaleData.Seats.length;
            var xrate1 = $("#<%= xrate.ClientID%>").val();
            var xamount1 = $("#<%= xamount.ClientID%>").val();
            var Time = $("#<%= xtime.ClientID%>").val();
            var route = $("#<%= xroute.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();




            if (xname1 == "") {

                alert("Please enter passenger name.");
                $("#<%= xname.ClientID%>")._focus();
                return false;
            }
            else if (xphone1 == "") {

                alert("Please enter passenger phone number.");
                $("#<%= xphone.ClientID%>")._focus();
                return false;
            }
            else if (xrate1 == "") {

                alert("No fare exist. Please contact to your administrator.");
                return false;
            }


            else {

                var chkst2 = $("#<%= chkst.ClientID%>").val();

                var xbutton1;

                if (chkst2 == "forsale") {
                    xbutton1 = "forsale";
                }
                else if (chkst2 == "confbooking") {
                    xbutton1 = "confbooking";
                }
                else {
                    xbutton1 = "sale";
                }

                var xseatid1 = "";

                if (chkst2 == "confbooking") {

                    var ls = SaleData.Seats.length;


                    for (i = 0; i < ls; i++) {
                        xseatid1 += SaleData.Seats[i].SeatId;
                        if (i != ls - 1)
                            xseatid1 += ",";
                    }
                }
                else if (SaleData.Seats.length > 0 || ForSaleSold.Seats.length > 0) {

                    var ls = SaleData.Seats.length;
                    var lf = ForSaleSold.Seats.length;

                    for (i = 0; i < ls; i++) {
                        xseatid1 += SaleData.Seats[i].SeatId;
                        if (i != ls - 1)
                            xseatid1 += ",";
                    }

                    if (lf > 0) {

                        if (ls > 0) {
                            xseatid1 += ",";
                        }

                        for (j = 0; j < lf; j++) {

                            xseatid1 += ForSaleSold.Seats[j].SeatId;
                            if (j != lf - 1)
                                xseatid1 += ",";
                        }
                    }
                }
                else if (chkst2 == "booked") {

                    ///////////////////////////////


                    //                    var xdate = $("#<%= xdate.ClientID%>").val();
                    //                    var xcoachno = $("#<%= xcoachno.ClientID%>").val();
                    //                    var xseat = BookedData.Seats[0].SeatName;

                    //                    $.ajax({
                    //                        url: "ztsales.aspx/fnSelectSeat",

                    //                        type: "POST",

                    //                        data: "{'cxdate2':'" + xdate + "', 'cxcoach2' : '" + xcoachno + "', 'cxseat2' : '" + xseat + "' , 'xstatus2' : 'booking'}",

                    //                        //dataType: "json",
                    //                        contentType: "application/json; charset=utf-8",

                    //                        async: false,
                    //                        success: function (res) {

                    //                            f = res.d;

                    //                            BookedData.Seats = [];

                    //                            var zseat = [];

                    //                            zseat = f.split(",");

                    //                            for (i = 0; i < zseat.length; i++) {
                    //                                BookedData.Seats.push({ SeatId: zseat[i] });
                    //                            }
                    //                            //alert(r);
                    //                            //alert("Success");
                    //                            //return r;
                    //                        },
                    //                        error: function (err) {
                    //                            alert("ERROR : " + err);
                    //                        }


                    //                    });

                    //////////////////////////


                }
                else if (chkst2 == "forsale") {

                    ///////////////////////////////


                    //                    var xdate2 = $("#<%= xdate.ClientID%>").val();
                    //                    var xcoachno2 = $("#<%= xcoachno.ClientID%>").val();
                    //                    var xseat2 = ForSaleData.Seats[0].SeatName;

                    //                    $.ajax({
                    //                        url: "ztsales.aspx/fnSelectSeat",

                    //                        type: "POST",

                    //                        data: "{'cxdate2':'" + xdate2 + "', 'cxcoach2' : '" + xcoachno2 + "', 'cxseat2' : '" + xseat2 + "' , 'xstatus2' : 'sold'}",

                    //                        //dataType: "json",
                    //                        contentType: "application/json; charset=utf-8",

                    //                        async: false,
                    //                        success: function (res) {

                    //                            f = res.d;

                    //                            ForSaleData.Seats = [];

                    //                            var zseat2 = [];

                    //                            zseat2 = f.split(",");

                    //                            for (i = 0; i < zseat2.length; i++) {
                    //                                ForSaleData.Seats.push({ SeatId: zseat2[i] });
                    //                            }
                    //                            //alert(r);
                    //                            //alert("Success");
                    //                            //return r;
                    //                        },
                    //                        error: function (err) {
                    //                            alert("ERROR : " + err);
                    //                        }


                    //                    });

                    //////////////////////////


                }
                else if (chkst2 == "confbooked") {

                    ///////////////////////////////


                    //                    var xdate2 = $("#<%= xdate.ClientID%>").val();
                    //                    var xcoachno2 = $("#<%= xcoachno.ClientID%>").val();
                    //                    var xseat2 = ConfirmBooked.Seats[0].SeatName;

                    //                    $.ajax({
                    //                        url: "ztsales.aspx/fnSelectSeat",

                    //                        type: "POST",

                    //                        data: "{'cxdate2':'" + xdate2 + "', 'cxcoach2' : '" + xcoachno2 + "', 'cxseat2' : '" + xseat2 + "' , 'xstatus2' : 'sold'}",

                    //                        //dataType: "json",
                    //                        contentType: "application/json; charset=utf-8",

                    //                        async: false,
                    //                        success: function (res) {

                    //                            f = res.d;

                    //                            ConfirmBooked.Seats = [];

                    //                            var zseat2 = [];

                    //                            zseat2 = f.split(",");

                    //                            for (i = 0; i < zseat2.length; i++) {
                    //                                ConfirmBooked.Seats.push({ SeatId: zseat2[i] });
                    //                            }
                    //                            //alert(r);
                    //                            //alert("Success");
                    //                            //return r;
                    //                        },
                    //                        error: function (err) {
                    //                            alert("ERROR : " + err);
                    //                        }


                    //                    });

                    //////////////////////////


                }
                else {

                }

                var xforsale1 = "";
                var xforsaleseat = "";

                var len = ForSaleSold.Seats.length;


                if (chkst2 == "sale") {
                    if (len > 0) {
                        for (i = 0; i < len; i++) {
                            xforsaleseat += ForSaleSold.Seats[i].SeatName;
                            if (i != len - 1)
                                xforsaleseat += ",";
                        }
                        xforsale1 = xforsaleseat;
                    }
                    else {
                        xforsale1 = "null";
                    }

                }
                else {
                    xforsale1 = "null";
                }

                var xstatus9 = "";

                if (chkst2 == "forsale") {
                    xstatus9 = "forsale";
                }
                else if (chkst2 == "confbooking") {
                    xstatus9 = "confbooking";
                }
                else {
                    xstatus9 = "sold";
                }


                $.ajax({
                    url: "ztbooking.aspx/fnSaveBooking",

                    type: "POST",

                    data: "{'chkst2' : '" + chkst2 + "','xstatus2':'" + xstatus9 + "','xdate2':'" + xdate1 + "', 'xcoach2' : '" + xcoach1 + "', 'xname2' : '" + xname1 + "', 'xphone2' : '" + xphone1 + "', 'xvotid2' : '" + xvotid1 + "', 'xboarding2' : '" + xboarding1 + "', 'xseat2' : '" + xseat1 + "', 'xrate2' : '" + xrate1 + "', 'xamount2' : '" + xamount1 + "', 'xdateexp2' : '', 'xtimeexp2' : '', 'xbutton2' : '" + xbutton1 + "' , 'xseatid2' : '" + xseatid1 + "' , 'xforsale' : '" + xforsale1 + "', 'xrttime2' : '" + Time + "', 'xroute2' : '" + route + "', 'xticket2' : 'online','xrouteid':'" + routeid + "','xdiscount':'0' }",

                    //dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    async: false,
                    success: function (res) {

                        var r = res.d;
                        //alert(r);
                        if (r != "success") {
                            if (r == "booked") {
                                alert("Seat already booked. Your time period expired");

                                if (chkst2 == "booked") {
                                    fnChngBtnAppearance("booked");
                                }
                                else if (chkst2 == "confbooking") {
                                    fnChngBtnAppearance("confbooking");
                                }
                                else {

                                    fnChngBtnAppearance("sold");
                                }
                                SaleData.Seats = [];
                                BookedData.Seats = [];
                                ForSaleData.Seats = [];
                                ForSaleSold.Seats = [];
                                ConfirmBooked.Seats = [];
                            }
                            else {
                                alert(r);
                                SaleData.Seats = [];
                                BookedData.Seats = [];
                                ForSaleData.Seats = [];
                                ForSaleSold.Seats = [];
                                ConfirmBooked.Seats = [];
                            }
                        }
                        else {
                            if (chkst2 !== "forsale") {
                                if (chkst2 == "confbooking") {
                                    //alert("Confirm successfull.");
                                    fnLoadSideList();
                                }
                                else {
                                    //                                    __doPostBack('$("#<%= ImageButton1.ClientID%>")', ''); 
                                    //alert("Sell successfull." + chkst2);

                                    if (chkst2 == "sale" || chkst2 == "confbooked" || chkst2 == "booked") {
                                        fnPrintTicket();

                                        $.ajax({
                                            url: "ztsales.aspx/fnSessionVal",

                                            type: "POST",

                                            data: "{}",

                                            //dataType: "json",
                                            contentType: "application/json; charset=utf-8",

                                            async: false,
                                            success: function (res) {

                                                r = res.d;
                                                //alert(r);
                                                if (r == "y") {
                                                    fnPrintTicketReturn();
                                                }
                                                //alert(r);
                                                //alert("Success");
                                                //return r;
                                            },
                                            error: function (err) {
                                                alert("ERROR : " + err);
                                            }


                                        });





                                        fnLoadSideList();

                                    }
                                }
                            }

                            if (chkst2 == "booked") {

                                fnChngBtnAppearance("booked");
                            }
                            else if (chkst2 == "confbooking") {
                                fnChngBtnAppearance("confbooking");
                            }
                            else if (chkst2 == "confbooked") {
                                fnChngBtnAppearance("confbooked");
                            }
                            else if (chkst2 == "forsale") {
                                fnChngBtnAppearance("forsale");
                            }
                            else {
                                fnChngBtnAppearance("sold");
                            }
                            SaleData.Seats = [];
                            BookedData.Seats = [];
                            ForSaleData.Seats = [];
                            ForSaleSold.Seats = [];
                            ConfirmBooked.Seats = [];
                        }

                        //return r;
                    },
                    error: function (err) {
                        alert("ERROR : " + err);
                        SaleData.Seats = [];
                        BookedData.Seats = [];
                        ForSaleData.Seats = [];
                        ForSaleSold.Seats = [];
                        ConfirmBooked.Seats = [];
                    }


                });




                $("#popupbooking").dialog('close');
            }





            //$("#popupbooking").dialog('close');
        });


        /*  Cancel button's OK button function */

        $("[id*=btnok]").live("click", function () {

            var cxdate1 = $("#<%= cxdate.ClientID%>").val();
            var cxtime1 = $("#<%= cxtime.ClientID%>").val();
            var cxcoach1 = $("#<%= cxcoach.ClientID%>").val();
            var cxseat1 = $("#<%= cxseat.ClientID%>").val();
            var cxnoofseat1 = $("#<%= cxnoofseat.ClientID%>").val();
            var cxremarks = $("#<%= cancelst.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();



            $.ajax({
                url: "ztsales.aspx/fnCancelRequest",

                type: "POST",

                data: "{'cxdate2':'" + cxdate1 + "', 'cxtime2' : '" + cxtime1 + "', 'cxcoach2' : '" + cxcoach1 + "', 'cxseat2' : '" + cxseat1 + "', 'cxnoofseat2' : '" + cxnoofseat1 + "', 'cxremark2' : '" + cxremarks + "', 'cxstatus2' : 'pending','xrouteid' : '" + routeid + "'}",

                //dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {

                    var r = res.d;
                    //alert(r);
                    if (r != "success") {

                        alert(r);

                    }
                    else {
                        // alert("Cancel Request successfull.");
                        fnChngBtnAppearance("cancelpending");
                        ConfirmBooked.Seats = [];
                        ForSaleData.Seats = [];
                        //fnLoadSideList();
                    }

                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }

            });

            $("#popupcancel").dialog('close');
        });


        function InternationalTime(hour, minute, period) {
            var h = 0;
            var time = 0;
            if (period == "pm") {
                if (hour == 12) {
                    h = 12 * 60;
                }
                else {
                    h = (12 + parseInt(hour, 10)) * 60;
                }
            }
            else {
                h = hour * 60;
            }
            time = h + parseInt(minute, 10);
            // alert(time + " Min: " + minute + " H: " + hour + " P: " + period);
            return time;
        }


        function toggleBgColor(elem) {

            //var curb =  <%= Application["curbtn"]%>;

            //if(curb==elem.value)
            //{

            //alert("under processing");
            //return;
            //}
            //         var style2 = elem.style;
            //         style2.backgroundColor = style2.backgroundColor ? "" : "#BC8F8F";
            //         style2.color = style2.color ? "" : "#FFFFFF";

            //document.getElementById('Label1').innerHTML = 'New';

            //    <%= Application["curbtn"] %> = elem.value;


        }

        $("[id*=xpayment]").live("keydown", function (event) {

            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
            // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||

            // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            } else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }

        });

        $("[id*=xrfare]").live("keydown", function (event) {

            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
            // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||

            // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            } else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }

        });



        $("[id*=btnreservation]").live("click", function () {

            if ($("#<%= xdate.ClientID%>").val() == "") {
                alert("Please enter date.");
                $("#<%= xdate.ClientID%>")._focus();
                return false;
            }
            else if ($("#<%= xcoachno.ClientID%>").val() == "") {
                alert("Please select coach.");
                $("#<%= xcoachno.ClientID%>")._focus();
                return false;
            }
            else if ($("#<%= xroute.ClientID%>").val() == "") {
                alert("Please select route.");
                $("#<%= xroute.ClientID%>")._focus();
                return false;
            }
            else {

                var xdate = $("#<%= xdate.ClientID%>").val();
                $("#<%= xjdate.ClientID%>").val(xdate);
                var xcoachno = $("#<%= xcoachno.ClientID%>").val();
                $("#<%= xcoach.ClientID%>").val(xcoachno);
                $("#<%= xdeplace.ClientID%>").val("");
                $("#<%= xdest.ClientID%>").val("");
                $("#<%= xdetime.ClientID%>").val("");
                $("#<%= xresby.ClientID%>").val("");
                $("#<%= xcontact.ClientID%>").val("");
                $("#<%= xrefby.ClientID%>").val("");
                $("#<%= xpayment.ClientID%>").val("");

                $("#<%= xpayby.ClientID%>").val("");


                //check if bus already booked or sold seat

                $.ajax({
                    url: "ztsales.aspx/fnCheckSeatExist",

                    type: "POST",

                    data: "{'xcoach2':'" + xcoachno + "', 'xdate2' : '" + xdate + "' }",

                    //dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    async: false,
                    success: function (res) {

                        f = res.d;
                        if (f != "success") {
                            alert(f);

                        }
                        else {
                            var fare = fnGetFare();

                            $.ajax({
                                url: "ztsales.aspx/getResFare",

                                type: "POST",

                                data: "{'xfare2':'" + fare + "', 'xcoachno2' : '" + xcoachno + "' }",

                                //dataType: "json",
                                contentType: "application/json; charset=utf-8",

                                async: false,
                                success: function (res) {

                                    f = res.d;
                                    $("#<%= xrfare.ClientID%>").val(f);

                                    //alert(r);
                                    //alert("Success");
                                    //return r;
                                },
                                error: function (err) {
                                    alert("ERROR : " + err);
                                }


                            });

                            $("#popupreservation").dialog({
                                title: "Reservation",
                                resizable: false,

                                height: 550,

                                width: 450,

                                modal: true
                                //                   buttons: {
                                //                       Save: function () {
                                //                           $(this).dialog('close');
                                //                       },

                                //                       Close: function () {
                                //                           $(this).dialog('close');
                                //                       }
                                //                   }
                            });

                        }
                        //alert(r);
                        //alert("Success");
                        //return r;
                    },
                    error: function (err) {
                        alert("ERROR : " + err);
                        return false;
                    }


                });




                return false;
            }
        });


        $("[id*=btnressave]").live("click", function () {

            if ($("#<%= xdeplace.ClientID%>").val() == "") {
                alert("Please enter departure place.");
                $("#<%= xdeplace.ClientID%>")._focus();
                return false;
            }
            else if ($("#<%= xdest.ClientID%>").val() == "") {
                alert("Please enter destination.");
                $("#<%= xdest.ClientID%>")._focus();
                return false;
            }
            else if ($("#<%= xresby.ClientID%>").val() == "") {
                alert("Please enter reserveby.");
                $("#<%= xresby.ClientID%>")._focus();
                return false;
            }
            else if ($("#<%= xcontact.ClientID%>").val() == "") {
                alert("Please enter contact number.");
                $("#<%= xcontact.ClientID%>")._focus();
                return false;
            }
            else {

                var xdate = $("#<%= xjdate.ClientID%>").val();
                var xcoachno = $("#<%= xcoach.ClientID%>").val();

                var xdeplace = $("#<%= xdeplace.ClientID%>").val();
                var xdest = $("#<%= xdest.ClientID%>").val();
                var xdetime = $("#<%= xdetime.ClientID%>").val();
                var xresby = $("#<%= xresby.ClientID%>").val();
                var xcontact = $("#<%= xcontact.ClientID%>").val();
                var xrefby = $("#<%= xrefby.ClientID%>").val();
                var xrfare = $("#<%= xrfare.ClientID%>").val();

                var xpayby = $("#<%= xpayby.ClientID%>").val();

                var xpayment = $("#<%= xpayment.ClientID%>").val();

                $.ajax({
                    url: "ztsales.aspx/fnBusReserve",

                    type: "POST",

                    data: "{'xcoach2':'" + xcoachno + "', 'xdeplace2' : '" + xdeplace + "', 'xdest2' : '" + xdest + "','xdate2' : '" + xdate + "','xtime2':'" + xdetime + "','xresby2':'" + xresby + "','xcontact2':'" + xcontact + "','xrefby2':'" + xrefby + "','xfare2':'" + xrfare + "','xpayment2':'" + xpayment + "','xpayby2':'" + xpayby + "' }",

                    //dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    async: false,
                    success: function (res) {

                        f = res.d;
                        if (f == "success") {
                            alert("Successfully reserve coach.");
                        }
                        else {
                            alert(f);
                            return false;
                        }

                        //alert(r);
                        //alert("Success");
                        //return r;
                    },
                    error: function (err) {
                        alert("ERROR : " + err);
                        return false;
                    }


                });



                $("#popupreservation").dialog('close');
            }
        });



    </script>
    <script>


        function pageLoad(sender, args) {
            $("#<%=xdate.ClientID %>").datepicker();
            $("#<%=xfromdt.ClientID %>").datepicker();
            $("#<%=xtodt.ClientID %>").datepicker();

        }
    </script>
    <script>
        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Message",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };
    </script>
    <style type="text/css">
        #Password1
        {
            width: 151px;
        }
        #Password2
        {
            width: 151px;
        }
        #TextArea1
        {
            height: 68px;
            width: 188px;
            text-align: left;
        }
        #xuserinfo
        {
            height: 83px;
            width: 181px;
        }
        #xpass
        {
            width: 151px;
        }
        #expass
        {
            width: 151px;
        }
        #exrepass
        {
            width: 151px;
        }
        #exuserinfo
        {
            width: 180px;
            height: 74px;
            margin-top: 0px;
        }
        #xdesc
        {
            height: 71px;
            width: 179px;
        }
        .style1101
        {
            width: 101%;
            height: 270px;
        }
        .style1
        {
            width: 99%;
            height: 539px;
        }
        .style1
        {
            width: 99%;
            height: 539px;
        }
        .style2
        {
        }
        .style9
        {
            height: 5px;
            width: 60px;
        }
        .style13
        {
            text-align: center;
        }
        .style18
        {
            width: 60px;
            text-align: center;
        }
        .style24
        {
            text-align: center;
            height: 37px;
            font-size: 20px;
            color: #FFFFFF;
        }
        .style25
        {
            text-align: center;
        }
        .style27
        {
            height: 5px;
            width: 50px;
        }
        .style1102
        {
            width: 99%;
            height: 166px;
        }
        .style1103
        {
            text-align: center;
        }
        .style1106
        {
            width: 77px;
            text-align: right;
            font-size: small;
            height: 30px;
        }
        .style1107
        {
            height: 30px;
        }
        .style1108
        {
            width: 77px;
            text-align: right;
            font-size: small;
            height: 29px;
        }
        .style1109
        {
            height: 29px;
        }
        .style1116
        {
            height: 68px;
            text-align: center;
        }
        .style1119
        {
            height: 30px;
            text-align: right;
            color: #000000;
        }
        .style1120
        {
            text-decoration: underline;
            height: 30px;
        }
        .style1121
        {
            width: 50px;
            text-align: center;
            height: 5px;
        }
        .style1122
        {
            width: 12px;
            height: 5px;
        }
        .style1123
        {
            height: 5px;
        }
        .style1124
        {
            width: 12px;
        }
        .style1127
        {
            height: 46px;
            text-align: center;
        }
        .style1128
        {
            height: 45px;
            text-align: center;
        }
        .style1129
        {
            height: 31px;
            text-align: right;
            color: #000000;
        }
        .style1130
        {
            height: 31px;
        }
        .style1132
        {
            width: 87px;
        }
        .style1133
        {
            width: 87px;
            text-align: right;
        }
        .style1134
        {
            width: 168px;
            text-align: right;
        }
        .style1135
        {
            width: 96px;
            text-align: left;
        }
        .style1137
        {
            width: 96px;
            text-align: left;
            color: #FF3300;
        }
        .style11350
        {
            text-align: center;
            text-decoration: underline;
            height: 30px;
        }
        .style11351
        {
            text-align: center;
            text-decoration: underline;
            height: 29px;
        }
        .style11352
        {
            height: 155px;
        }
        .style11353
        {
            width: 100%;
            height: 17px;
        }
        .style1111353
        {
            width: 93%;
            height: 784px;
        }
        .style11355
        {
            height: 70px;
            width: 40px;
        }
        .style11356
        {
            height: 70px;
        }
        .style11357
        {
            height: 70px;
            width: 35px;
        }
        .style11358
        {
            height: 70px;
            width: 45px;
        }
        .style11359
        {
            height: 70px;
            width: 79px;
        }
        .style11360
        {
            height: 70px;
            width: 48px;
        }
        .style11361
        {
            height: 70px;
            width: 51px;
        }
        .style11362
        {
            height: 70px;
            width: 101px;
        }
        .style11363
        {
            height: 70px;
            width: 52px;
        }
        .style11364
        {
            height: 70px;
            width: 46px;
        }
        .style11365
        {
            height: 70px;
            width: 73px;
        }
        .style11366
        {
            height: 70px;
            width: 93px;
        }
        .style11367
        {
            height: 70px;
            width: 47px;
        }
        .style11368
        {
            width: 87px;
            text-align: right;
            height: 35px;
        }
        .style11369
        {
            width: 168px;
            text-align: right;
            height: 35px;
        }
        .style11370
        {
            width: 96px;
            text-align: left;
            height: 35px;
        }
        #xticket
        {
            height: 32px;
            width: 152px;
            margin-left: 0px;
        }
        #Select1
        {
            width: 150px;
            height: 30px;
        }
        .style11371
        {
            width: 87px;
            text-align: right;
            height: 39px;
        }
        .style11372
        {
            width: 168px;
            text-align: right;
            height: 39px;
        }
        .style11373
        {
            width: 96px;
            text-align: left;
            color: #FF3300;
            height: 39px;
        }
        .style11374
        {
            width: 87px;
            text-align: right;
            height: 84px;
        }
        .style11375
        {
            width: 168px;
            text-align: right;
            height: 84px;
        }
        .style11376
        {
            width: 96px;
            text-align: left;
            color: #FF3300;
            height: 84px;
        }
        #xreason
        {
            height: 74px;
        }
        #xsec
        {
            height: 29px;
            width: 181px;
        }
        .style11377
        {
            width: 125px;
        }
        .style11378
        {
            width: 125px;
            text-align: right;
            color: #000000;
        }
        .style1111356
        {
            height: 411px;
            vertical-align: top;
        }
        .style1111357
        {
            height: 363px;
            vertical-align: top;
        }
        .style1111360
        {
            height: 28px;
            text-decoration: underline;
        }
        .style1111365
        {
            height: 147px;
        }
        .style1111376
        {
            width: 100%;
        }
        .style1111377
        {
            height: 197px;
        }
        .style1111379
        {
            height: 26px;
            text-decoration: underline;
        }
        #xbus
        {
            height: 30px;
            width: 151px;
        }
        #xdriver
        {
            height: 30px;
            width: 151px;
        }
        #xguide
        {
            height: 30px;
            width: 151px;
        }
        #Select2
        {
            width: 142px;
            height: 52px;
        }
        #xbud
        {
            width: 151px;
            height: 30px;
        }
        #xdriver0
        {
            height: 30px;
            width: 151px;
        }
        .style1111382
        {
            width: 96px;
            text-align: left;
            color: #FF3300;
            height: 36px;
        }
        .style1111383
        {
            width: 87px;
            text-align: right;
            height: 36px;
        }
        .style1111384
        {
            width: 168px;
            text-align: left;
            height: 36px;
        }
        .style1111387
        {
            width: 96px;
            text-align: left;
            height: 36px;
        }
        .style1111388
        {
            width: 99px;
        }
        .style1111389
        {
            width: 99px;
            text-align: right;
        }
        .style1111390
        {
            width: 125px;
            text-align: left;
        }
        .style1111391
        {
            width: 125px;
            text-align: left;
        }
        .style1111392
        {
            width: 99px;
            text-align: right;
            height: 26px;
        }
        .style1111393
        {
            width: 125px;
            text-align: left;
            height: 26px;
        }
        .style1111394
        {
            width: 96px;
            text-align: left;
            height: 26px;
        }
        .style1111395
        {
            width: 87px;
            text-align: right;
            height: 28px;
        }
        .style1111396
        {
            width: 168px;
            text-align: right;
            height: 28px;
        }
        .style1111397
        {
            width: 96px;
            text-align: left;
            height: 28px;
        }
        .style1111398
        {
            height: 70px;
            width: 54px;
        }
        .style1111399
        {
            height: 70px;
            width: 36px;
        }
        .style1111407
        {
            text-align: center;
            height: 8px;
        }
        .style1111409
        {
            height: 18px;
            width: 37px;
        }
        .style1111419
        {
            width: 372px;
        }
        .style1111421
        {
            width: 49px;
        }
        .style1111424
        {
            width: 145px;
        }
        .style1111425
        {
            width: 54px;
        }
        .CenterPB
        {
            position: absolute;
            left: 50%;
            top: 50%;
            margin-top: -30px; /* make this half your image/element height */
            margin-left: -30px; /* make this half your image/element width */
        }
        .style1111426
        {
            width: 162px;
            text-align: right;
        }
        .style1111427
        {
            width: 136px;
        }
        .style1111428
        {
            width: 136px;
            text-align: right;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!")
        }
    </script>
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
    <script type="text/javascript">

        $(document).ready(function () {
            $('a#popup').live('click', function (e) {

                var page = $(this).attr("href")  //get url of link

                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 600,
                    width: 'auto',
                    title: "Role Permission",

                    buttons: {
                        "Close": function () { $dialog.dialog('close'); }
                    },
                    close: function (event, ui) {

                        //                        __doPostBack(', '');  // To refresh gridview when user close dialog
                    }
                });
                $dialog.dialog('open');
                e.preventDefault();
            });
        });

       
    </script>
    <script type="text/javascript">
        function test() {

            PageMethods.MyMethod()

        }

        function btnsave_onclick() {

        }

        function btnsave_onclick() {

        }

        function btnsave_onclick() {

        }

        function btnsave_onclick() {

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upbustype">
        <ProgressTemplate>
            &nbsp;
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center;
                height: 22px;" runat="server">
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Panel ID="MasterPanel" runat="server" Height="853px" ScrollBars="Auto">
        <div id="LeftDiv" style="height: 793px; width: 231px; float: left;">
            <asp:UpdatePanel ID="uppersidelist" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Height="219px" BackColor="#CCCCCC">
                        <table class="style1102">
                            <tr>
                                <td class="style11350" colspan="2" style="background-color: #996633; color: #FFFFFF;
                                    font-size: medium">
                                    <strong>User Status</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1103">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style1106" style="color: #000000; font-size: small;">
                                    Employee :
                                </td>
                                <td class="style1107">
                                    <asp:Label ID="xemp" runat="server" Text="xemp"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1106" style="color: #000000; font-size: small;">
                                    Counter :
                                </td>
                                <td class="style1107">
                                    <asp:Label ID="xcounter" runat="server" Text="xcounter"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1108" style="color: #000000; font-size: small;">
                                    Seat Sold :
                                </td>
                                <td class="style1109">
                                    <asp:Label ID="xsold" runat="server" Text="xsold"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1108" style="color: #000000; font-size: small;">
                                    Cancelled :
                                </td>
                                <td class="style1109">
                                    <asp:Label ID="xcan" runat="server" Text="xcan"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1108" style="color: #000000; font-size: small;">
                                    Total Sales :
                                </td>
                                <td class="style1109">
                                    <asp:Label ID="xtotalsold" runat="server" Text="xtotalsold"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="upseltrip" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" Height="280px" BackColor="#CCCCCC">
                        <table class="style1101">
                            <tr>
                                <td class="style11351" colspan="2" style="background-color: #996633; font-size: medium;
                                    color: #FFFFFF">
                                    <strong>Select Trip</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style1129">
                                    Journey Date :
                                </td>
                                <td class="style1130">
                                    <asp:TextBox ID="xdate" runat="server" Width="132px" AutoPostBack="True" OnTextChanged="xdate_TextChanged"
                                        CausesValidation="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1119">
                                    Coach No :
                                </td>
                                <td class="style1107">
                                    <asp:DropDownList ID="xcoachno" runat="server" Height="29px" Style="margin-bottom: 14px"
                                        Width="132px" AutoPostBack="True" OnSelectedIndexChanged="xcoachno_SelectedIndexChanged"
                                        CausesValidation="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1119">
                                    Time :
                                </td>
                                <td class="style1107">
                                    <asp:TextBox ID="xtime" runat="server" Width="132px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1119">
                                    Route :
                                </td>
                                <td class="style1107">
                                    <asp:DropDownList ID="xroute" runat="server" Height="29px" Width="132px" AutoPostBack="True"
                                        OnSelectedIndexChanged="xroute_SelectedIndexChanged" CausesValidation="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1116" colspan="2">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/reload70.png"
                                        OnClientClick="JavaScript:resetObject()" OnClick="ImageButton1_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1116" colspan="2">
                                    <asp:HiddenField ID="selected_route" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="lowersidelist" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel4" runat="server" BackColor="#CCCCCC" Height="261px">
                        <table class="style1102">
                            <tr>
                                <td class="style1120" colspan="2" style="color: #FFFFFF; font-size: medium; background-color: #996633;
                                    text-align: center;">
                                    <strong>Sales Status</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style11377">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style11378">
                                    &nbsp; No of Seat Booked:
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="xtbooked" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style11378">
                                    &nbsp; No of Seat Sold:
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="xtsold" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style11378">
                                    &nbsp;&nbsp; Total Amount:
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="xtamount" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style11377">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="MiddleLeftDiv" style="margin: 0px 0px 5px 5px; padding: 10px; float: left;
            height: 557px; width: 220px; background-color: #CCCCCC;">
            <%--<div class="CenterPB" style="height:60px;width:60px;" >--%>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upseltrip">
                <ProgressTemplate>
                    <img src="../../images/load.gif" alt="" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <%-- </div>--%>
            <asp:UpdatePanel ID="upbustype" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <asp:Panel ID="Panel3" runat="server" BackColor="White" Height="545px" Width="220px"
                            Enabled="False" CssClass="aspNetDisabled aspNetDisabled aspNetDisabled aspNetDisabled aspNetDisabled">
                            <table class="style1">
                                <tr>
                                    <td bgcolor="#996633" class="style24" colspan="5">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="White"
                                            Text="E-Class (B) " Style="font-size: large"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1121">
                                    </td>
                                    <td class="style27">
                                    </td>
                                    <td class="style1122">
                                    </td>
                                    <td class="style9">
                                    </td>
                                    <td class="style1123">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="a1" runat="server" Height="40px" Text="A1" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="b1" runat="server" Height="40px" Text="B1" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="c1" runat="server" Height="40px" Text="C1" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="d1" runat="server" Height="40px" Text="D1" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="a2" runat="server" Height="40px" Text="A2" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="b2" runat="server" Height="40px" Text="B2" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="c2" runat="server" Height="40px" Text="C2" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="d2" runat="server" Height="40px" Text="D2" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="a3" runat="server" Height="40px" Text="A3" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="b3" runat="server" Height="40px" Text="B3" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="c3" runat="server" Height="40px" Text="C3" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="d3" runat="server" Height="40px" Text="D3" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="a4" runat="server" Height="40px" Text="A4" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="b4" runat="server" Height="40px" Text="B4" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="c4" runat="server" Height="40px" Text="C4" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="d4" runat="server" Height="40px" Text="D4" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="a5" runat="server" Height="40px" Text="A5" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="b5" runat="server" Height="40px" Text="B5" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="c5" runat="server" Height="40px" Text="C5" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="d5" runat="server" Height="40px" Text="D5" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="a6" runat="server" Height="40px" Text="A6" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="b6" runat="server" Height="40px" Text="B6" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="c6" runat="server" Height="40px" Text="C6" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="d6" runat="server" Height="40px" Text="D6" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="f1" runat="server" Height="40px" Text="F1" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="f2" runat="server" Height="40px" Text="F2" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="f3" runat="server" Height="40px" Text="F3" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="f4" runat="server" Height="40px" Text="F4" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="f5" runat="server" Height="40px" Text="F5" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="f6" runat="server" Height="40px" Text="F6" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="f7" runat="server" Height="40px" Text="F7" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="f8" runat="server" Height="40px" Text="F8" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="f9" runat="server" Height="40px" Text="F9" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="f10" runat="server" Height="40px" Text="F10" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="f11" runat="server" Height="40px" Text="F11" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="f12" runat="server" Height="40px" Text="F12" Width="40px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="s1" runat="server" Height="40px" Text="S1" Width="40px" />
                                    </td>
                                    <td class="style25" height="40px" width="40px">
                                        <asp:Button ID="s2" runat="server" Height="40px" Text="S2" Width="40px" />
                                    </td>
                                    <td class="style1124" height="40px" width="40px">
                                        &nbsp;
                                    </td>
                                    <td class="style18" height="40px" width="40px">
                                        <asp:Button ID="s3" runat="server" Height="40px" Text="S3" Width="40px" />
                                    </td>
                                    <td class="style13" height="40px" width="40px">
                                        <asp:Button ID="s4" runat="server" Height="40px" Text="S4" Width="40px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="xcoachno" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="xdate" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="xroute" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="MiddleRightDiv" style="float: left; height: 748px; width: 150px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel5" runat="server" Height="691px">
                        <table class="style1102">
                            <tr>
                                <td class="style1127">
                                    <asp:Button ID="btnSearch" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Search"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    <button id="btncngpass" class="mybutton">
                                        Change<br>
                                        Password</button>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    <asp:Button ID="btnhistory" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="History"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    <asp:Button ID="btnCancel" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Cancel"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td id="seatInfo" class="style11352">
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    <asp:Button ID="btnsale" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Sale"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1128">
                                    <asp:Button ID="btnmansale" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Manual Sale"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1128">
                                    <asp:Button ID="btnforsale" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="For Sale"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    <button id="btnconfbooking" class="mybutton">
                                        Confirm<br>
                                        Booking</button>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    <asp:Button ID="btnreservation" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Reservation"
                                        Width="120px" OnClick="btnreservation_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="RightDiv" style="float: left; height: 797px; width: 402px; background-color: #CCCCCC;">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel6" runat="server" Width="401px" Height="799px">
                        <table class="style1111353">
                            <tr>
                                <td class="style1111357">
                                    <asp:Panel ID="salelist" runat="server" Height="354px" ScrollBars="Both" Width="400px">
                                        <table class="style11353">
                                            <tr>
                                                <td class="style1111360" colspan="4" style="text-align: left; background-color: #996633;
                                                    color: #FFFFFF; font-size: medium">
                                                    <strong>Passenger List</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="style1111419">
                                                        <tr>
                                                            <td class="style1111421">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style1111424">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style1111425">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1111421">
                                                                Date:
                                                            </td>
                                                            <td class="style1111424">
                                                                <asp:Label ID="xpdate" runat="server" Text="xpdate"></asp:Label>
                                                            </td>
                                                            <td class="style1111425">
                                                                Coach :
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="xpcoachno" runat="server" Text="xpcoachno"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1111421">
                                                                Time :
                                                            </td>
                                                            <td class="style1111424">
                                                                <asp:Label ID="xptime" runat="server" Text="xptime"></asp:Label>
                                                            </td>
                                                            <td class="style1111425">
                                                                Bus No:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="xpbus" runat="server" Text="xpbus"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1111421">
                                                                Driver :
                                                            </td>
                                                            <td class="style1111424">
                                                                <asp:Label ID="xpdriver" runat="server" Text="xpdriver"></asp:Label>
                                                            </td>
                                                            <td class="style1111425">
                                                                Guide :
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="xpguide" runat="server" Text="xpguide"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1111421">
                                                                Route :
                                                            </td>
                                                            <td class="style1111424">
                                                                <asp:Label ID="xproute" runat="server" Text="xproute"></asp:Label>
                                                            </td>
                                                            <td class="style1111425">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1111421">
                                                                <asp:LinkButton ID="btnEditDriver" runat="server">Edit</asp:LinkButton>
                                                            </td>
                                                            <td class="style1111424">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style1111425">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1111365" colspan="4" valign="top">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        ForeColor="#333333" GridLines="None" Height="41px" ShowHeaderWhenEmpty="True">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:BoundField DataField="xseat" HeaderText="Seat" />
                                                            <asp:BoundField DataField="xname" HeaderText="Passenger" />
                                                            <asp:BoundField DataField="xphone" HeaderText="Phone" />
                                                            <asp:BoundField DataField="xticket" HeaderText="Tic. No" />
                                                            <asp:BoundField DataField="xboarding" HeaderText="Boarding" />
                                                            <asp:BoundField DataField="xdestination" HeaderText="Destination" />
                                                            <asp:BoundField DataField="xuser" HeaderText="Sold By" />
                                                        </Columns>
                                                        <EditRowStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1111407">
                                    <asp:Button ID="btnpasslist" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Print Passenger List"
                                        Width="230px" />
                                    <asp:HiddenField ID="bustype1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1111356">
                                    <asp:Panel ID="bookinglist" runat="server" Height="354px" ScrollBars="Both" Width="400px">
                                        <table class="style1111376">
                                            <tr>
                                                <td style="text-align: left; background-color: #996633; color: #FFFFFF; font-size: medium"
                                                    class="style1111379">
                                                    <strong>Booking List</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1111377" valign="top">
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        ForeColor="#333333" GridLines="None" Height="41px" ShowHeaderWhenEmpty="True">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:BoundField DataField="xseat" HeaderText="Seat" />
                                                            <asp:BoundField DataField="xname" HeaderText="Passenger" />
                                                            <asp:BoundField DataField="xphone" HeaderText="Phone" />
                                                            <asp:BoundField DataField="xuser" HeaderText="Booked By" />
                                                            <asp:BoundField DataField="xboarding" HeaderText="Boarding" />
                                                            <asp:BoundField DataField="xdestination" HeaderText="Destination" />
                                                            <asp:BoundField DataField="xexpired" HeaderText="Expired on" />
                                                        </Columns>
                                                        <EditRowStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <div style="height: 167px">
        <table class="style11353">
            <tr>
                <td class="style11355" style="vertical-align: middle">
                    <input id="Button1" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #990033;" />
                </td>
                <td class="style11357" style="vertical-align: middle">
                    Sold
                </td>
                <td class="style11358" style="vertical-align: middle">
                    <input id="Button2" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #0066FF;" />
                </td>
                <td class="style11359" style="vertical-align: middle">
                    Manual Sold
                </td>
                <td class="style11360" style="vertical-align: middle">
                    <input id="Button3" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #FFCC99;" />
                </td>
                <td class="style11361" style="vertical-align: middle">
                    Booking
                </td>
                <td class="style11360" style="vertical-align: middle">
                    <input id="Button4" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #99CC00;" />
                </td>
                <td class="style11362" style="vertical-align: middle">
                    Confirm Booking
                </td>
                <td class="style11358" style="vertical-align: middle">
                    <input id="Button5" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #66CCFF;" />
                </td>
                <td class="style11363" style="vertical-align: middle">
                    For Sale
                </td>
                <td class="style11364" style="vertical-align: middle">
                    <input id="Button6" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #32CD32;" />
                </td>
                <td class="style11365" style="vertical-align: middle">
                    Reservation
                </td>
                <td class="style11358" style="vertical-align: middle">
                    <input id="Button7" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #8A2BE2" />
                </td>
                <td class="style11366" style="vertical-align: middle">
                    Cancel Panding
                </td>
                <td class="style11367" style="vertical-align: middle">
                    <input id="Button8" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #FFA500" />
                </td>
                <td class="style1111398" style="vertical-align: middle">
                    Bus Omit
                </td>
                <td class="style1111399" style="vertical-align: middle">
                    <input id="Button9" type="button" value="" class="btncolor" disabled="disabled" style="background-color: #00FFFF" />
                </td>
                <td class="style11356" style="vertical-align: middle">
                    Manual Ticket Approval Pending
                </td>
            </tr>
        </table>
    </div>
    <div id="FooterDiv" style="display: none;">
        <asp:Panel ID="eclassb" runat="server" BackColor="White" Height="550px" Width="220px">
        </asp:Panel>
        <asp:Panel ID="eclasss" runat="server" BackColor="White" Height="550px" Width="220px">
        </asp:Panel>
        <asp:Panel ID="sclass" runat="server" BackColor="White" Height="500px" Width="204px">
        </asp:Panel>
        <asp:Panel ID="hinoac" runat="server" BackColor="White" Height="540px" Width="220px">
        </asp:Panel>
    </div>
    <div id="popupbooking" style="height: 379px; width: 432px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102">
            <tr>
                <td class="style1111427">
                    &nbsp;
                </td>
                <td class="style1111426">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111428">
                    Name :
                </td>
                <td class="style1111426">
                    <asp:TextBox ID="xname" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1137">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111428">
                    Phone:
                </td>
                <td class="style1111426">
                    <asp:TextBox ID="xphone" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1137">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111428">
                    Voter ID:
                </td>
                <td class="style1111426">
                    <asp:TextBox ID="xvotid" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111428">
                    Boarding:
                </td>
                <td class="style1111426">
                    <asp:TextBox ID="xboarding" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111428">
                    No. of Seat:
                </td>
                <td class="style1111426">
                    <asp:TextBox ID="xseat" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111428">
                    Fare:
                </td>
                <td class="style1111426">
                    <asp:TextBox ID="xrate" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    BDT
                </td>
            </tr>
            <tr>
                <td class="style1111428">
                    Total Fare:
                </td>
                <td class="style1111426">
                    <asp:TextBox ID="xamount" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    BDT
                </td>
            </tr>
            <tr>
                <td class="style1111427">
                    &nbsp;
                </td>
                <td class="style1111426">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111427">
                    &nbsp;
                </td>
                <td class="style1111426">
                    <input id="btnsave" type="button" value="Sale" style="height: 25px; width: 100px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" runat="server" onclick="return btnsave_onclick()" />
                </td>
                <td class="style1134">
                    <input id="btnreturn" type="button" value="Return" style="height: 25px; width: 100px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div id="popupcancel" style="height: 379px; width: 432px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102">
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Date :
                </td>
                <td class="style1134">
                    <asp:TextBox ID="cxdate" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1137">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Time :
                </td>
                <td class="style1134">
                    <asp:TextBox ID="cxtime" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1137">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Coach No:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="cxcoach" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1137">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Seat No:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="cxseat" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    No. of Seat:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="cxnoofseat" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    <input id="btnok" type="button" value="OK" style="height: 25px; width: 100px; background-color: #33CCCC;
                        border-color: #996633; font-weight: bold; font-size: medium; color: White;" />
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="popupmansale" style="height: 379px; width: 432px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102">
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Name :
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xmname" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1137">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Phone:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xmphone" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1137">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Voter ID:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xmvotid" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Boarding:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xmboarding" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    No. of Seat:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xmseat" runat="server" Width="151px" ReadOnly="True" Style="text-align: left"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11368">
                    Ticket:
                </td>
                <td class="style11369">
                    &nbsp;<select id="xticket" name="D1">
                        <option>[Select]</option>
                    </select>
                </td>
                <td class="style11370">
                </td>
            </tr>
            <tr>
                <td class="style1111395">
                    Discount:
                </td>
                <td class="style1111396">
                    <asp:TextBox ID="xdiscount" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1111397">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Fare:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xmrate" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    BDT
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Total Fare:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xmamount" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    BDT
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    <input id="btnmsave" type="button" value="Manual Sale" style="height: 25px; width: 116px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" />
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="popuppasslist" style="height: 379px; width: 432px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102">
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111383">
                    Coach No :
                </td>
                <td class="style1111384">
                    <asp:TextBox ID="xpcoach" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1111382">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111383">
                    Bus :
                </td>
                <td class="style1111384">
                    <asp:DropDownList ID="xbus" runat="server" Height="30px" Width="151px">
                    </asp:DropDownList>
                </td>
                <td class="style1111382">
                </td>
            </tr>
            <tr>
                <td class="style1111383">
                    Bus Type :
                </td>
                <td class="style1111384">
                    <asp:TextBox ID="xpbustype" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1111387">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111383">
                    Driver :
                </td>
                <td class="style1111384">
                    <asp:TextBox ID="xdriver" runat="server" Height="22px" Width="151px"></asp:TextBox>
                </td>
                <td class="style1111387">
                </td>
            </tr>
            <tr>
                <td class="style1111383">
                    Guide :
                </td>
                <td class="style1111384">
                    <asp:TextBox ID="xguide" runat="server" Height="22px" Width="151px"></asp:TextBox>
                </td>
                <td class="style1111387">
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    <input id="buttonpasslistsave" type="button" value="Save" style="height: 25px; width: 116px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" />
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="popupdestroy" style="height: 379px; width: 432px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102">
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11371">
                    Ticket No :
                </td>
                <td class="style11372">
                    <select id="xtic" name="D2">
                        <option></option>
                    </select>
                </td>
                <td class="style11373">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style11374">
                    Reason :
                </td>
                <td class="style11375">
                    <textarea id="xreason" name="S1"></textarea>
                </td>
                <td class="style11376">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1132">
                    &nbsp;
                </td>
                <td class="style1134">
                    <input id="btndestroy" type="button" value="Destroy" style="height: 25px; width: 116px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" />
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="popupreservation" style="height: 379px; width: 432px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102">
            <tr>
                <td class="style1111388">
                    &nbsp;
                </td>
                <td class="style1111391">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Reserve Coach :
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xcoach" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1137">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Departure Place:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xdeplace" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1137">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Destination:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xdest" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    <strong style="color: #FF3300">*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Journey Date:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xjdate" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    <strong style="color: #FF3300">*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Departure Time:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xdetime" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Reserve By:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xresby" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    <strong style="color: #FF3300">*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Contact Number:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xcontact" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    <strong style="color: #FF3300">*</strong>
                </td>
            </tr>
            <tr>
                <td class="style1111392">
                    &nbsp; Reffered By:
                </td>
                <td class="style1111393">
                    <asp:TextBox ID="xrefby" runat="server" Width="151px"></asp:TextBox>
                    &nbsp;
                </td>
                <td class="style1111394">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Reserve Fare :
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xrfare" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    BDT
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Pay Amount:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xpayment" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    BDT
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    Payment By:
                </td>
                <td class="style1111390">
                    <asp:TextBox ID="xpayby" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111389">
                    &nbsp;
                </td>
                <td class="style1111391">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111388">
                    &nbsp;
                </td>
                <td class="style1111391">
                    <input id="btnressave" type="button" value="Reservation" style="height: 27px; width: 131px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" />
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="popuphistory" style="height: 183px; width: 449px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102" style="width: 100%">
            <tr>
                <td class="style1111409">
                    &nbsp;
                </td>
                <td class="style1111414">
                    &nbsp;
                </td>
                <td class="style1111412">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111413">
                    From:
                </td>
                <td class="style1111414">
                    &nbsp;
                    <asp:TextBox ID="xfromdt" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1111412">
                    To:
                </td>
                <td class="style1135">
                    <asp:TextBox ID="xtodt" runat="server" Width="151px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1111409">
                    &nbsp;
                </td>
                <td class="style1111414">
                    <input id="btnshowhis" type="button" value="Show" style="height: 27px; width: 131px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" />
                </td>
                <td class="style1111412">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="dialog" style="display: none">
    </div>
    <asp:HiddenField ID="seatFareHidden" runat="server" />
    <asp:HiddenField ID="chkst" runat="server" />
    <asp:HiddenField ID="cancelst" runat="server" />
    <asp:HiddenField ID="xdisrate" runat="server" />
    <asp:HiddenField ID="xentrytype123" runat="server" />
</asp:Content>
