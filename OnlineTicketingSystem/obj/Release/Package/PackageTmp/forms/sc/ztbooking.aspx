<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ztbooking.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.zttestbus"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <link rel="stylesheet" href="../../Styles/coach.css">
    <link rel="stylesheet" href="../../Styles/buslayout.css">
    <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.timer.js"></script>

    <script type="text/javascript">




//        var myVar = setInterval(function () { loadReq() }, 1000);

//        function loadReq() {

//            PageMethods.fnLoadReq(onSucess, onError);

//            function onSucess(result) {


//                //document.getElementById('<%=LinkButton1.ClientID %>').innerHTML = "Hi";
//                //alert(result);


//                var s = result.split("|");
//                if (s[0] == "success") {
//                    if (s[1] == "0") {
//                        document.getElementById('<%=LinkButton1.ClientID %>').style.color = 'Blue';
//                    }
//                    else {
//                        document.getElementById('<%=LinkButton1.ClientID %>').style.color = 'Red';
//                    }
//                    if (s[2] == "0") {
//                        document.getElementById('<%=LinkButton2.ClientID %>').style.color = 'Blue';
//                    }
//                    else {
//                        document.getElementById('<%=LinkButton2.ClientID %>').style.color = 'Red';
//                    }
//                    document.getElementById('<%=LinkButton1.ClientID %>').innerHTML = "Cancel Ticket: " + s[1];
//                    document.getElementById('<%=LinkButton2.ClientID %>').innerHTML = "Manual Ticket: " + s[2];
//                }
//                else {
//                    alert(i);
//                }

//            }

//            function onError(result) {
//                //alert("ERROR : " + result);
//                alert("Error: " + result.get_message() + "; " +
//        "Stack Trace: " + result.get_stackTrace() + "; " +
//        "Status Code: " + result.get_statusCode() + "; " +
//        "Exception Type: " + result.get_exceptionType() + "; " +
//                        "Timed Out: " + result.get_timedOut());

//            }

//            return false;
//        }


        //           $("[id*=btnSave]").live("click", function () {

        //                   $("#popupbooking").dialog('close');
        //               });


        //        $(document).ready(function () {


        //            var timer = $.timer(function () {

        //                $.ajax({
        //                    url: "ztbooking.aspx/fnLoadReq",

        //                    type: "POST",

        //                    data: "{ }",

        //                    //dataType: "json",
        //                    contentType: "application/json; charset=utf-8",

        //                    async: false,
        //                    success: function (res) {

        //                        //alert("hi");
        //                        var i = res.d;
        //                        var s = i.split("|");
        //                        if (s[0] == "success") {
        //                            if (s[1] == "0") {
        //                                $("#<%= LinkButton1.ClientID%>").css('color', 'Blue');
        //                            }
        //                            else {
        //                                $("#<%= LinkButton1.ClientID%>").css('color', 'Red');
        //                            }
        //                            if (s[2] == "0") {
        //                                $("#<%= LinkButton2.ClientID%>").css('color', 'Blue');
        //                            }
        //                            else {
        //                                $("#<%= LinkButton2.ClientID%>").css('color', 'Red');
        //                            }
        //                            $("#<%= LinkButton1.ClientID%>").text("Cancel Ticket: " + s[1]);
        //                            $("#<%= LinkButton2.ClientID%>").text("Manual Ticket: " + s[2]);
        //                        }
        //                        else {
        //                            alert(i);
        //                        }

        //                    },
        //                    error: function (err) {
        //                       // alert("ERROR : " + err);
        //                    }


        //                });

        //            });


        //            timer.set({ time: 1000, autostart: true });



        //        });
       

           
    </script>
    <script type="text/javascript">



        //        $(function () {
        //            $('#<%=xname.ClientID%>').autocomplete({
        //                source: function (request, response) {

        //                    $.ajax({
        //                        url: "ztbooking.aspx/fnAutoFill",

        //                        type: "POST",

        //                        data: "{}",

        //                        //dataType: "json",
        //                        contentType: "application/json; charset=utf-8",

        //                        async: false,
        //                        success: function (res) {

        //                            r = res.d;
        //                            response($.map(r, function (item) {
        //                                return { value: item }
        //                            }))
        //                        },
        //                        error: function (err) {
        //                            alert("ERROR : " + err);
        //                        }


        //                    });
        //                    
        //                }
        //            });
        //        });



        //     function closeDialog(dlg) {

        //         $(dlg).dialog('close');
        //     }


        var BookingData = {};
        var CancelData = {};

        BookingData.Seats = [];
        CancelData.Seats = [];



        function resetObject() {

            BookingData.Seats = [];
            CancelData.Seats = [];

            var xdate = $("#<%= xdate.ClientID%>").val();
            var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();

            $.ajax({
                url: "ztbooking.aspx/fnDelectSelBtn",

                type: "POST",

                data: "{'xdate2' :'" + xdate + "', 'xcoach2' :'" + xcoachno + "', 'xrouteid' : '" + routeid + "'}",

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


            var r = -1;
            // var r = "";
            var xdate = $("#<%= xdate.ClientID%>").val();
            var xcoachno = $("#<%= xcoachno.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();

            $.ajax({
                url: "ztbooking.aspx/process",

                type: "POST",

                data: "{'sid':'" + sid + "', 'xdate2' :'" + xdate + "', 'xcoach2' :'" + xcoachno + "', 'xrouteid' : '" + routeid + "'}",

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
                    BookingData.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });

                }
                else {

                    $(this).css("background-color", "");
                    findAndRemove(BookingData.Seats, "SeatId", $(this).attr("id"));
                }


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


            var val = $(this).val();
            $("#seatInfo").html(val);
            $(this).toggleClass("cancelbooking");

            if ($(this).hasClass("cancelbooking")) {

                $(this).css("background-color", "#DA70D6");
                CancelData.Seats.push({ SeatName: $(this).val(), SeatId: $(this).attr("id") });

            }
            else {

                $(this).css("background-color", "");
                findAndRemove(CancelData.Seats, "SeatId", $(this).attr("id"));
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
                    //alert(r);
                    //alert("Success");
                    //return r;
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });



            return f;

        }




        $("[id*=btnBooking]").live("click", function () {


            $("#<%= chkst.ClientID%>").val("booking");
            var xdate = $("#<%= xdate.ClientID%>").val();
            $("#<%= xname.ClientID%>").val("");
            $("#<%= xphone.ClientID%>").val("");
            $("#<%= xvotid.ClientID%>").val("");
            $("#<%= xboarding.ClientID%>").val("");
            $("#<%= xseat.ClientID%>").val("");
            $("#<%= xrate.ClientID%>").val("");
            $("#<%= xamount.ClientID%>").val("");
            $("#<%= xdateexp.ClientID%>").val(xdate);
            $("#<%= mydwh.ClientID%>").val("");
            $("#<%= mydwm.ClientID%>").val("");
            $("#<%= mydwi.ClientID%>").val("");



            var txt = "";
            var l = BookingData.Seats.length;
            if (l > 3) {
                alert("you can select maximum 3 seats per booking");

            }
            else if (l < 1) {
                alert("You didn't select a seat");
            }
            else {

                for (i = 0; i < l; i++) {
                    txt += BookingData.Seats[i].SeatName;
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
                    title: "Booking",
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
            return false;
        });


        /*  Cancel button function  */

        $("[id*=btnCancel]").live("click", function () {


            //         $("#<%= cxdate.ClientID%>").val("");
            //         $("#<%= cxcoach.ClientID%>").val("");
            //         $("#<%= cxseat.ClientID%>").val("");
            //         $("#<%= cxnoofseat.ClientID%>").val("");




            var txt = "";
            var l = CancelData.Seats.length;
            if (l > 3) {
                alert("you can select maximum 3 seats per cancel");

            }
            else if (l < 1) {
                alert("You didn't select a seat");
            }
            else {

                for (i = 0; i < l; i++) {
                    txt += CancelData.Seats[i].SeatName;
                    if (i != l - 1)
                        txt += ",";
                }

                var xdate1 = $("#<%= xdate.ClientID%>").val();
                var xcoachno1 = $("#<%= xcoachno.ClientID%>").val();

                $("#<%= cxdate.ClientID%>").val(xdate1);
                $("#<%= cxcoach.ClientID%>").val(xcoachno1);
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
            return false;
        });




        function closeDialog() {
            $(function () {
                $("#popupbooking").dialog('close');
                //return false;
            });

        }


        function fnChngBtnAppearance(param) {

            if (param == "booking") {
                for (var i = 0; i < BookingData.Seats.length; i++) {
                    //alert(BookingData.Seats[i].SeatId);
                    $("#" + BookingData.Seats[i].SeatId).removeClass("processing");
                    $("#" + BookingData.Seats[i].SeatId).removeClass("btn");

                    $("#" + BookingData.Seats[i].SeatId).addClass("booking");
                    $("#" + BookingData.Seats[i].SeatId).css("background-color", "#FFCC99");
                }
            }
            else {

                for (var i = 0; i < CancelData.Seats.length; i++) {
                    //alert(BookingData.Seats[i].SeatId);
                    $("#" + CancelData.Seats[i].SeatId).removeClass("booking");
                    $("#" + CancelData.Seats[i].SeatId).removeClass("processing");
                    $("#" + CancelData.Seats[i].SeatId).removeClass("cancelbooking");

                    $("#" + CancelData.Seats[i].SeatId).addClass("btn");
                    $("#" + CancelData.Seats[i].SeatId).css("background-color", "#D3D3D3");
                }

            }
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

        $("[id*=btnsave]").live("click", function () {

            var xdate1 = $("#<%= xdate.ClientID%>").val();
            var xcoach1 = $("#<%= xcoachno.ClientID%>").val();

            var xname1 = $("#<%= xname.ClientID%>").val();
            var xphone1 = $("#<%= xphone.ClientID%>").val();
            var xvotid1 = $("#<%= xvotid.ClientID%>").val();
            var xboarding1 = $("#<%= xboarding.ClientID%>").val();
            var xseat1 = $("#<%= xseat.ClientID%>").val();

            //var xseat1 = BookingData.Seats.length;
            var xrate1 = $("#<%= xrate.ClientID%>").val();
            var xamount1 = $("#<%= xamount.ClientID%>").val();
            var xdateexp1 = $("#<%= xdateexp.ClientID%>").val();
            var mydwh1 = $("#<%= mydwh.ClientID%>").val();
            var mydwm = $("#<%= mydwm.ClientID%>").val();
            var mydwi = $("#<%= mydwi.ClientID%>").val();
            var Time = $("#<%= xtime.ClientID%>").val();
            var route = $("#<%= xroute.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();

            var xtimeexp1 = mydwh1 + ":" + mydwm + " " + mydwi;

            var Hour = Time.substring(0, 2);
            var Min = Time.substring(3, 5);
            var Per = Time.substring(6);

            var validTime = InternationalTime(mydwh1, mydwm, mydwi);
            var realTime = InternationalTime(Hour, Min, Per);

            //var d1 = $.datepicker.formatDate('yy-dd-mm', new Date($("#<%= xdate.ClientID%>").val()));
            //var d2 = $.datepicker.formatDate('yy-dd-mm', new Date($("#<%= xdateexp.ClientID%>").val()));

            var d1 = new Date($("#<%= xdate.ClientID%>").val());
            var d2 = new Date($("#<%= xdateexp.ClientID%>").val());






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
            else if (xdateexp1 == "") {

                alert("Please enter booking expiration date.");
                $("#<%= xdateexp.ClientID%>")._focus();
                return false;
            }
            else if (mydwh1 == "--") {

                alert("Please enter booking expiration hour.");
                //$("#<%= mydwh.ClientID%>")._focus();
                return false;
            }
            //         else if (mydwm1 == "--") {

            //             alert("Please enter booking expiration minute.");
            //             $("#<%= mydwm.ClientID%>")._focus();
            //             return false;
            //         }
            //else if ((realTime - validTime) < 60 && d2 > d1) {
            //            else if (d2 > d1) {
            //                alert("Sorry, you can book a ticket before one hour at maximum on journey date.");
            //                return false;

            //            }
            else {

                if (Date.parse(d2) > Date.parse(d1)) {
                    alert("Sorry, you can book a ticket before one hour at maximum on journey date.");
                    return false;

                }
                else {

                    if ((Date.parse(d2) == Date.parse(d1)) && ((realTime - validTime) < 60)) {
                        alert("Sorry, you can book a ticket before one hour at maximum on journey date.");
                        return false;
                    }


                }

                var chkst2 = $("#<%= chkst.ClientID%>").val();

                var l = BookingData.Seats.length;
                var xseatid1 = "";
                for (i = 0; i < l; i++) {
                    xseatid1 += BookingData.Seats[i].SeatId;
                    if (i != l - 1)
                        xseatid1 += ",";
                }

                $.ajax({
                    url: "ztbooking.aspx/fnSaveBooking",

                    type: "POST",

                    data: "{'chkst2' : '" + chkst2 + "', 'xstatus2':'booking','xdate2':'" + xdate1 + "', 'xcoach2' : '" + xcoach1 + "', 'xname2' : '" + xname1 + "', 'xphone2' : '" + xphone1 + "', 'xvotid2' : '" + xvotid1 + "', 'xboarding2' : '" + xboarding1 + "', 'xseat2' : '" + xseat1 + "', 'xrate2' : '" + xrate1 + "', 'xamount2' : '" + xamount1 + "', 'xdateexp2' : '" + xdateexp1 + "', 'xtimeexp2' : '" + xtimeexp1 + "', 'xbutton2' : 'save', 'xseatid2' : '" + xseatid1 + "' , 'xforsale' : 'null', 'xrttime2' : '" + Time + "', 'xroute2' : '" + route + "', 'xticket2': 'online', 'xrouteid' : '" + routeid + "','xdiscount':'0' }",

                    //dataType: "json",
                    contentType: "application/json; charset=utf-8",

                    async: false,
                    success: function (res) {

                        var r = res.d;
                        //alert(r);
                        if (r != "success") {
                            if (r == "booked") {
                                alert("Seat already booked. Your time period expired");
                                fnChngBtnAppearance("booking");
                                BookingData.Seats = [];
                            }
                            else {
                                alert(r);
                            }
                        }
                        else {
                            //alert("Booking successfull.");
                            fnChngBtnAppearance("booking");
                            BookingData.Seats = [];
                            fnLoadSideList();
                            //                            $("#<%= xtbooked.ClientID%>").text("haramjada");
                            //                            $("#<%= xsold.ClientID%>").text("halarput");

                        }

                        //return r;
                    },
                    error: function (err) {
                        alert("ERROR : " + err);
                    }


                });




                $("#popupbooking").dialog('close');
            }





            //$("#popupbooking").dialog('close');
        });


        /*  Cancel button's OK button function */

        $("[id*=btnok]").live("click", function () {

            var cxdate1 = $("#<%= cxdate.ClientID%>").val();
            var cxcoach1 = $("#<%= cxcoach.ClientID%>").val();
            var cxseat1 = $("#<%= cxseat.ClientID%>").val();
            var cxnoofseat1 = $("#<%= cxnoofseat.ClientID%>").val();
            var routeid = $("#<%= selected_route.ClientID%>").val();



            $.ajax({
                url: "ztbooking.aspx/fnBookingCancel",

                type: "POST",

                data: "{'cxdate2':'" + cxdate1 + "', 'cxcoach2' : '" + cxcoach1 + "', 'cxseat2' : '" + cxseat1 + "', 'cxnoofseat2' : '" + cxnoofseat1 + "', 'xrouteid' : '" + routeid + "'}",

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
                        //alert("Cancel successfull.");
                        fnChngBtnAppearance("cancel");
                        CancelData.Seats = [];
                        fnLoadSideList();
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

    </script>
    <script>
        //          $(function () {
        //              $("#<%=xdateexp.ClientID %>").datepicker();
        //          });

     
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
            height: 286px;
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
        .style1111353
        {
            width: 100%;
            height: 792px;
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
            width: 100%;
            height: 77px;
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
        .style11347
        {
            width: 87px;
            text-align: right;
            height: 28px;
        }
        .style11348
        {
            width: 168px;
            text-align: right;
            height: 28px;
        }
        .style11349
        {
            width: 96px;
            text-align: left;
            height: 28px;
        }
        .style11350
        {
            text-align: center;
            text-decoration: underline;
            height: 20px;
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
        .style11355
        {
            width: 41px;
            text-align: right;
            color: #000000;
            height: 29px;
        }
        .style11356
        {
            width: 137px;
            text-align: right;
            color: #000000;
            height: 27px;
        }
        .style11357
        {
            height: 27px;
        }
        .style1111353
        {
            width: 402px;
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
            height: 18px;
            width: 32px;
        }
        .style1111379
        {
            width: 137px;
            height: 17px;
        }
        .style1111380
        {
            width: 137px;
            text-align: right;
            color: #000000;
            height: 29px;
        }
        
        .style1111419
        {
            width: 95%;
        }
        .style1111420
        {
            width: 48px;
        }
        .style1111422
        {
            width: 52px;
        }
        .style1111423
        {
            width: 141px;
        }
        .CenterPB{
                    position: absolute;
                    left: 50%;
                    top: 50%;
                    margin-top: -30px; /* make this half your image/element height */
                    margin-left: -30px; /* make this half your image/element width */
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
      <script>


          function pageLoad(sender, args) {
              $("#<%=xdate.ClientID %>").datepicker();
           
           

          }
    </script>

    <script type="text/javascript">
        function test() {

            PageMethods.MyMethod()

        }

        function btnsave_onclick() {

        }

        function ConfirmMessage() {
            var selectedvalue = confirm("Do you want to omit the bus?");
            if (selectedvalue) {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
            }
        }


        function ConfirmMessage1() {
            var selectedvalue = confirm("Do you want to cancel busomit?");
            if (selectedvalue) {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
            }
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center;
                height: 22px;" runat="server">
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Panel ID="MasterPanel" runat="server" Height="807px" ScrollBars="Auto" Style="margin-bottom: 0px">
        <div id="LeftDiv" style="height: 789px; width: 231px; float: left;">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <%--<asp:Timer runat="server" ID="treq" Interval="5000" OnTick="treq_tick">
                        </asp:Timer>--%>
                    <asp:Panel ID="Panel6" runat="server" Height="81px" BackColor="#CCCCCC">
                        <table class="style1102">
                            <tr>
                                <td class="style11350" colspan="2" style="background-color: #996633; color: #FFFFFF;
                                    font-size: medium">
                                    <strong>Pending Request Status</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1111424" style="color: #000000; font-size: small; text-align: left;">
                                    <%-- Cancel Ticket:--%>
                                    <%-- </td>
                                <td class="style1107">--%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/forms/sc/ztcancelreq.aspx"
                                        Font-Bold="True" Font-Overline="False" Font-Size="Small">Cancel Ticket:</asp:LinkButton>
                                </td>
                                <%--</tr>
                            <tr>--%>
                                <td class="style1111424" style="color: #000000; font-size: small; text-align: left;">
                                    <%--Manual Tic. Approval:--%>
                                    <%-- </td>
                                <td class="style1107">--%>
                                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/forms/sc/ztmanticapppen.aspx"
                                        Font-Bold="True" Font-Overline="False" Font-Size="Small">Manual Ticket:</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <%-- <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="treq" EventName="Tick" />
                </Triggers>--%>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="uppersidelist" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Height="193px" BackColor="#CCCCCC">
                        <table class="style1102">
                            <tr>
                                <td class="style11350" colspan="2" style="background-color: #996633; color: #FFFFFF;
                                    font-size: medium">
                                    <strong>User Status</strong>
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
                    <br />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upseltrip" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" Height="268px" BackColor="#CCCCCC">
                        <table class="style1101">
                            <tr>
                                <td class="style11351" colspan="2" style="background-color: #996633; font-size: medium;
                                    color: #FFFFFF">
                                    <strong>Select Trip</strong>
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
                    <asp:Panel ID="Panel4" runat="server" BackColor="#CCCCCC" Height="204px">
                        <table class="style1102">
                            <tr>
                                <td class="style1120" colspan="2" style="color: #FFFFFF; font-size: medium; background-color: #996633;
                                    text-align: center;">
                                    <strong>Sales Status</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1111380">
                                    &nbsp; No of Seat Booked:
                                </td>
                                <td class="style1109">
                                    &nbsp;
                                    <asp:Label ID="xtbooked" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style11356">
                                    &nbsp; No of Seat Sold:
                                </td>
                                <td class="style11357">
                                    &nbsp;
                                    <asp:Label ID="xtsold" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1111380">
                                    &nbsp; Total Amount:
                                </td>
                                <td class="style1109">
                                    &nbsp;
                                    <asp:Label ID="xtamount" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1111379">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style1111379">
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
           <%-- <div class="CenterPB" style="height:60px;width:60px;" >--%>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upseltrip">
                <ProgressTemplate>
                    <img src="../../images/load.gif" alt="" />
                </ProgressTemplate>
            </asp:UpdateProgress>
          <%--  </div>--%>
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
                    <asp:AsyncPostBackTrigger ControlID="btnBusOmit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btncanbusomit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="xroute" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="MiddleRightDiv" style="float: left; height: 581px; width: 150px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel5" runat="server" Height="559px">
                        <table class="style1102">
                            <tr>
                                <td id="seatInfo" class="style11352">
                                </td>
                            </tr>
                            <tr>
                                <td class="style1127">
                                    <asp:Button ID="btnSearch" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Search"
                                        Width="120px" OnClick="btnSearch_Click" />
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
                                <td class="style1127">
                                    <asp:Button ID="btnBooking" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Booking"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1128">
                                    <asp:Button ID="btnBackup" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Backup"
                                        Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1128">
                                    <asp:Button ID="btnBusOmit" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Bus Omit"
                                        Width="120px" OnClientClick="javascript:ConfirmMessage()" OnClick="btnBusOmit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1128">
                                    <asp:Button ID="btncanbusomit" runat="server" BackColor="#33CCCC" BorderColor="#996633"
                                        Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="30px" Text="Cancel Bus Omit"
                                        Width="134px" OnClientClick="javascript:ConfirmMessage1()" OnClick="btncanbusomit_Click" />
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
        <div id="RightDiv" style="float: left; height: 798px; width: 402px; background-color: #CCCCCC;">
            <table class="style1111353">
                <tr>
                    <td class="style1111357" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="bookinglist" runat="server" Height="354px" ScrollBars="Both" Width="400px">
                                    <table class="style1111376">
                                        <tr>
                                            <td style="text-align: center; text-align: left; background-color: #996633; color: #FFFFFF;
                                                font-size: medium;" class="style1111360">
                                                <strong>Booking List</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                &nbsp;
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
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="style1111358">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="style1111356">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
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
                                                        <td class="style1111420">
                                                            &nbsp;
                                                        </td>
                                                        <td class="style1111423">
                                                            &nbsp;
                                                        </td>
                                                        <td class="style1111422">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1111420">
                                                            Date:
                                                        </td>
                                                        <td class="style1111423">
                                                            <asp:Label ID="xpdate" runat="server" Text="xpdate"></asp:Label>
                                                        </td>
                                                        <td class="style1111422">
                                                            Coach :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="xpcoachno" runat="server" Text="xpcoachno"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1111420">
                                                            Time :
                                                        </td>
                                                        <td class="style1111423">
                                                            <asp:Label ID="xptime" runat="server" Text="xptime"></asp:Label>
                                                        </td>
                                                        <td class="style1111422">
                                                            Bus No:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="xpbus" runat="server" Text="xpbus"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1111420">
                                                            Driver :
                                                        </td>
                                                        <td class="style1111423">
                                                            <asp:Label ID="xpdriver" runat="server" Text="xpdriver"></asp:Label>
                                                        </td>
                                                        <td class="style1111422">
                                                            Guide :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="xpguide" runat="server" Text="xpguide"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1111420">
                                                            Route :
                                                        </td>
                                                        <td class="style1111423">
                                                            <asp:Label ID="xproute" runat="server" Text="xproute"></asp:Label>
                                                        </td>
                                                        <td class="style1111422">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1111420">
                                                            &nbsp;
                                                        </td>
                                                        <td class="style1111423">
                                                            &nbsp;
                                                        </td>
                                                        <td class="style1111422">
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
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
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
                    <asp:TextBox ID="xname" runat="server" Width="151px" ></asp:TextBox>
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
                    <asp:TextBox ID="xphone" runat="server" Width="151px"></asp:TextBox>
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
                    <asp:TextBox ID="xvotid" runat="server" Width="151px"></asp:TextBox>
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
                    <asp:TextBox ID="xboarding" runat="server" Width="151px"></asp:TextBox>
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
                    <asp:TextBox ID="xseat" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Fare:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xrate" runat="server" Width="151px" ReadOnly="True"></asp:TextBox>
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
                    <asp:TextBox ID="xamount" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1135">
                    BDT
                </td>
            </tr>
            <tr>
                <td class="style1133">
                    Valid Till:
                </td>
                <td class="style1134">
                    <asp:TextBox ID="xdateexp" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1137">
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td class="style11347">
                    Time:
                </td>
                <td class="style11348">
                    <asp:DropDownList ID="mydwh" runat="server" Height="24px" Width="50px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="mydwm" runat="server" Height="25px" Width="50px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="mydwi" runat="server" Height="24px" Width="50px">
                    </asp:DropDownList>
                </td>
                <td class="style11349">
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
                    <input id="btnsave" type="button" value="Save" style="height: 25px; width: 100px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" />
                </td>
                <td class="style1135">
                    &nbsp;
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
    <div id="dialog" style="display: none">
    </div>
    <asp:HiddenField ID="seatFareHidden" runat="server" />
    <asp:HiddenField ID="chkst" runat="server" />
    <asp:HiddenField ID="txtconformmessageValue" runat="server" />
</asp:Content>
