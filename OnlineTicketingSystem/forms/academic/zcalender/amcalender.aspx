<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="amcalender.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.zcalender.amcalender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="/images/edusoft.ico" />
    <title>EDUSOFT(Calender)</title>
    <link href="~/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/bmerp.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="~/Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">--%>
    <%-- <link href="~/Styles/redmond/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/redmond/theme.css" rel="stylesheet" type="text/css" />--%>
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/jquery-1.8.3.js"
        type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/ui/jquery-ui.custom.js"
        type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/ui/jquery.ui.core.js"
        type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/ui/jquery.ui.widget.js"
        type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/ui/jquery.ui.datepicker.js"
        type="text/javascript"></script>
    <script src="/Scripts/bmscript.js" type="text/javascript"></script>
    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/themes/cupertino/jquery-ui.min.css" rel="stylesheet" />--%>
    <%-- <link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.css" rel="stylesheet" />--%>
    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.css" rel="stylesheet" />--%>
    <link href="~/fullcalendar/jquery.qtip.css" rel="stylesheet" type="text/css" />
    <%-- <link href="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/themes/cupertino/jquery-ui.min.css" rel="stylesheet" />--%>
    <%--<script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.17.1/moment.min.js"></script>--%>
    <script src="/fullcalendar/moment.js" type="text/javascript"></script>
    <%-- <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>--%>
    <%--<script src="//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.js"></script>--%>
    <%-- <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.js"></script>--%>
    <script src="/fullcalendar/fullcalendar.js" type="text/javascript"></script>
    <script src="/Scripts/calendarscript.js" type="text/javascript"></script>
    <script src="/fullcalendar/jquery.qtip.js" type="text/javascript"></script>
    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/themes/cupertino/jquery-ui.min.css" rel="stylesheet" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.css" rel="stylesheet" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.css" rel="stylesheet" />
    
    <link href="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/themes/cupertino/jquery-ui.min.css" rel="stylesheet" />--%>
    <style type='text/css'>
        body
        {
            margin-top: 10px;
            text-align: center;
            font-size: 14px;
            font-family: "Myriad Pro" , Myriad Pro,tahoma,Lucida Grande,Helvetica,Arial,Verdana,sans-serif;
        }
        #calendar
        {
            width: 1165px;
            margin: 0;
        }
        /* css for timepicker */
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: -25px 0 10px 65px;
        }
        .style1
        {
            width: 100%;
        }
        
        /* table fields alignment*/
        .alignRight
        {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
        }
        .alignLeft
        {
            text-align: left;
            padding-bottom: 10px;
        }
        
        .fc-fri
        {
            background-color: #F2F2F2;
            color: #FF0000;
        }
        .fc-sat
        {
            background-color: #F2F2F2;
            color: #FF0000;
        }
        
        .fc-fri span
        {
            color: #FF0000;
        }
        
        .fc-sat span
        {
            color: #FF0000;
        }
        
        .fc-day-grid-event .fc-content
        {
            white-space: normal !important;
            padding-top: 10px;
            height: 50px;
            padding-left: 10px;
        }
        /*.fc-bgevent
        {
            background-color: green;
        }*/
        
        .bttn
        {
            padding: 3px 20px;
            margin-right: 7px;
            cursor: pointer;
            background-color: #007DC5;
            border: none;
            color: #FFFFFF;
            font-family: Myriad Pro,tahoma;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            -webkit-transition-duration: 0.2s; /* Safari */
            transition-duration: 0.2s;
            width: 100px;
        }
        
         .bttn_inactive
        {
            padding: 3px 20px;
            margin-right: 7px;
            cursor: pointer;
            background-color: #949599;
            border: none;
            color: #000000;
            font-family: Myriad Pro,tahoma;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            -webkit-transition-duration: 0.2s; /* Safari */
            transition-duration: 0.2s;
            width: 100px;
        }
        
        .bttn:hover
        {
            background-color: #F68814;
            color: #C7EBFC;
        }
        .bttn:active
        {
            /*background-color: #F68814;
    color:  #C7EBFC;*/
            background-color: #C7EBFC;
            color: #F68814;
        }
      
      .bttn_inactive:hover
        {
            background-color: #F68814;
            color: #C7EBFC;
        }
        .bttn_inactive:active
        {
            /*background-color: #F68814;
    color:  #C7EBFC;*/
            background-color: #C7EBFC;
            color: #F68814;
        }
        .font-style
        {
            font-size: 14px;
            font-weight: bold;
            border-radius: 2px;
            padding-left: 20px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //            $('.bm_academic_datepicker').attr('readonly', true);
            //            //$('.bm_academic_datepicker').attr('placeholder', 'yyyy-mm-dd');
            //            $('.bm_academic_datepicker').datepicker({
            //                inline: true,
            //                //nextText: '&rarr;',
            //                //prevText: '&larr;',
            //                showOtherMonths: true,
            //                dateFormat: 'yy-mm-dd',
            //                dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']
            //                //showOn: "button",
            //                //buttonImage: "img/calendar-blue.png",
            //                //buttonImageOnly: true,
            //            });
            //            $('.bm_academic_datepicker').change(function() {
            //                $('#calendar').fullCalendar('gotoDate', $('.bm_academic_datepicker').val());
            //            });
            //            $('.bm_academic_dropdown').change(function () {
            //                alert($('.bm_academic_dropdown').val());
            //            });
            //            $('#calendar').fullCalendar('gotoDate', $('.bm_academic_datepicker').val());
            //            function pageLoad(sender, args) {
            //                $(function () {
            //                    $('.bm_academic_datepicker').datepicker({
            //                        inline: true,
            //                        //nextText: '&rarr;',
            //                        //prevText: '&larr;',
            //                        showOtherMonths: true,
            //                        dateFormat: 'M/yy',
            //                        dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']
            //                        //showOn: "button",
            //                        //buttonImage: "img/calendar-blue.png",
            //                        //buttonImageOnly: true,
            //                    });
            //                });
            //            }
            $('#btnmonth').click(function () {
                $('#calendar').fullCalendar('changeView', 'month');
                $('#btnmonth').addClass("bttn");
                $('#btnmonth').addClass("bttn_inactive");
                $('#btnweek').addClass("bttn");
                $('#btnweek').addClass("bttn_inactive");
                $('#btnmonth').removeClass("bttn_inactive");
                $('#btnweek').removeClass("bttn");
            });
            $('#btnweek').click(function () {
                $('#calendar').fullCalendar('changeView', 'basicWeek');
                $('#btnmonth').addClass("bttn");
                $('#btnmonth').addClass("bttn_inactive");
                $('#btnweek').addClass("bttn");
                $('#btnweek').addClass("bttn_inactive");
                $('#btnmonth').removeClass("bttn");
                $('#btnweek').removeClass("bttn_inactive");
            });

            $('#grid_xdate').change(function () {
                $('#calendar').fullCalendar('gotoDate', $('#grid_xdate').val());
            });
            $('#calendar').fullCalendar('gotoDate', $('#grid_xdate').val());
//            $('#calendar').find('[data-date="2018-03-21"]').css("background-color", "#D0E9F5");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <%-- <div style="margin: 5px; text-align:left">
        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Go Home" 
             CssClass="bttn" />
    </div>--%>
    <div style="width: 1200px; text-align: center; margin: 0 auto;">
        <div class="bm_academic_container">
            <%--  <div class="bm_academic_container_header">
                <div class="header_label" id="header_label" runat="server">
                    EVENT CALENDER
                </div>
            </div>--%>
            <div style="width: 100%;margin-top: -5px">
                <table style="width: 100%;border: none; border-collapse: collapse;border-spacing: 0px;margin-bottom: -3px">
                    <tr style="margin-bottom:0px; padding: 0px;">
                        <td style="width: 85%">
                            <div class="bm_academic_container_message">
                                <div class="message" id="message" runat="server">
                                    <%-----THIS IS MESSAGE SECTION-----%>
                                </div>
                            </div>
                        </td>
                        <td style="width: 15%;">
                            <table style="width:100%; border: none; border-collapse: collapse;border-spacing: 0px;margin-right: -2px"><tr style="margin-bottom:0px;padding:0px"><td >
                           <%-- <div style="margin: 0px;margin-left: 21px">
                                <div style="margin: 0px; text-align: left; float: left">--%>
                                    <input type="button" id="btnmonth" value="MONTH" class="bttn" style="border-top-left-radius: 8px; border-top-right-radius: 8px; margin: 0px;"/>
                                </td><%--</div>
                                <div style="margin: 0px;  text-align: left; float: left">--%>
                                   <td> <input type="button" class="bttn_inactive" value="WEEK" id="btnweek" style="margin-right: 0px;border-top-left-radius: 8px; border-top-right-radius: 8px;margin: 0px" />
                              </td> <%-- </div>
                            </div>--%>
                           </tr> </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="bm_academic_container_footer" style="background-color: #007DC5; border-bottom-left-radius: 8px;border-bottom-right-radius: 8px;border-top-left-radius: 8px;
                padding-right: 20px; padding-left: 15px;padding-top: 0px">
                <div class="footer_list_padding">
                    <div class="bm_academic_grid_container" id="list" runat="server">
                        <div class="grid_header">
                            <div style="margin: 5px; text-align: left; float: left">
                                <asp:Button ID="Button1" runat="server" CommandName="Login" Text="HOME" CssClass="bttn"
                                    OnClick="fnGoBack" />
                            </div>
                            <div class="grid_header_control" style="margin-left: 20px">
                                <div class="grid_ctl_padding">
                                    <div class="bm_ctl_container_100_ses_grid" style="width: 180px">
                                        <%-- <div class="bm_ctl_label_align_right_100_ses_grid">
                                            <asp:Label ID="Label54" runat="server" Text="School :" AssociatedControlID="grid_xlocation"
                                                CssClass="label"></asp:Label>
                                        </div>--%>
                                        <div class="bm_clt_ctl_100_ses_grid" style="width: 100%">
                                            <asp:DropDownList ID="grid_xlocation" AutoPostBack="True" runat="server" CssClass="font-style bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_s_grid_c" style="width: 180px">
                                        <%-- <div class="bm_ctl_label_align_right_100_s_grid">
                                            <asp:Label ID="Label52" runat="server" Text="Date :" AssociatedControlID="grid_xdate"
                                                CssClass="label"></asp:Label>
                                        </div>--%>
                                        <div class="bm_clt_ctl_100_s_grid" style="width: 100%">
                                            <asp:DropDownList ID="grid_xdate" runat="server" CssClass="font-style bm_academic_dropdown_100_ses_grid bm_academic_ctl_global bm_academic_dropdown grid_location">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--<div style="margin-top: 5px;text-align: left; float: right">
                                <input type="button" class="bttn" value="WEEK" id="btnweek"/>
                            </div>
                            <div style="margin-top: 5px; text-align: left; float: right">
                                <input type="button" id="btnmonth"  value="MONTH" class="bttn"  />
                            </div>--%>
                        </div>
                        <div class="grid_body" style="background-color: #FFFFFF; padding: 0px; margin: 0px;
                            width: 1165px;">
                            <div id="calendar" style="margin-top: 10px;">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div runat="server" id="jsonDiv">
        </div>
        <input type="hidden" id="hdClient" runat="server" />
    </div>
    </form>
    <%-- <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.17.1/moment.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.js"></script>
    <script src="/Scripts/calendarscript.js" type="text/javascript"></script>--%>
</body>
</html>
