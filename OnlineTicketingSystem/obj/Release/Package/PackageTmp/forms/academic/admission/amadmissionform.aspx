<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="amadmissionform.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.admission.amadmissionform" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="shortcut icon" type="image/x-icon" href="/images/edusoft.ico" />
    <title>PIS Application Form</title>
    <link href="~/Styles/amSite.css?version=21.0.0.1" rel="stylesheet" type="text/css" />
    <link href="~/Styles/bmerp.css?version=21.0.0.3" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">--%>
    <link href="~/Styles/fontawesome/css/all.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="~/Scripts/jquery-ui-1.9.2.custom/develop<link rel="stylesheet" type="text/css" href="Styles/fontawesome-free-5.1.0-web/css/all.css" />ment-bundle/themes/base/jquery.ui.all.css">--%>
    <link href="~/Styles/redmond/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/redmond/theme.css" rel="stylesheet" type="text/css" />
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
    <script src="/Scripts/bmscript.js?version=21.0.0.1" type="text/javascript"></script>
    <script src="/Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.chromatable.js" type="text/javascript"></script>
    <script src="/Scripts/gridviewscroll.js" type="text/javascript"></script>
    <%-- <link href="~/Styles/style.css" rel="stylesheet" type="text/css" />--%>
    <script src="/Scripts/Chart.bundle.js" type="text/javascript"></script>
    <script src="/Scripts/utils.js" type="text/javascript"></script>
    <%-- <script src="/Scripts/jquery.key.js" type="text/javascript"></script>--%>
    <%--<script src="/Scripts/jquery.hotkeys.js" type="text/javascript"></script>--%>
    <%--<script src="/Scripts/shortcut.js"></script>--%>
    <script src="/Scripts/jquery.hotkeys1.js" type="text/javascript"></script>
    <script src="/Scripts/amcharts/amcharts.js"></script>
    <script src="/Scripts/amcharts/pie.js"></script>
    <script src="/Scripts/amcharts/plugins/export/export.min.js"></script>
    <link href="~/Scripts/amcharts/plugins/export/export.css" rel="stylesheet" />
    <script src="/Scripts/chartjs-plugin-label.js"></script>

    <style>
        .file-upload {
            display: inline-block;
            overflow: hidden;
            text-align: center;
            vertical-align: middle;
            font-family: Arial;
            border: 1px solid #124d77;
            background: #007dc1;
            color: #fff;
            border-radius: 6px;
            -moz-border-radius: 6px;
            cursor: pointer;
            text-shadow: #000 1px 1px 2px;
            -webkit-border-radius: 6px;
        }

            .file-upload:hover {
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #0061a7), color-stop(1, #007dc1));
                background: -moz-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -webkit-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -o-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -ms-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: linear-gradient(to bottom, #0061a7 5%, #007dc1 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#0061a7', endColorstr='#007dc1',GradientType=0);
                background-color: #0061a7;
            }

        /* The button size */
        .file-upload {
            height: 30px;
        }

            .file-upload, .file-upload span {
                width: 90px;
            }

                .file-upload input {
                    top: 0;
                    left: 0;
                    margin: 0;
                    font-size: 11px;
                    font-weight: bold;
                    /* Loses tab index in webkit if width is set to 0 */
                    opacity: 0;
                    filter: alpha(opacity=0);
                }

                .file-upload strong {
                    font: normal 12px Tahoma,sans-serif;
                    text-align: center;
                    vertical-align: middle;
                }

                .file-upload span {
                    top: 0;
                    left: 0;
                    display: inline-block;
                    /* Adjust button text vertical alignment */
                    padding-top: 5px;
                    z-index: 100;
                }


        /*input[type="file"] {
            display: none;
        }*/

        .custom-file-upload {
            background-color: #007dc1;
            display: inline-block;
            padding: 6px 12px;
            cursor: pointer;
            width: 200px;
            color: #fff;
            text-align: center;
            font-weight: bold;
            font-size: 14px;
        }

            .custom-file-upload:hover {
                background-color: #F68814;
                color: #C7EBFC;
            }

            .custom-file-upload:active {
                background-color: #C7EBFC;
                color: #C7EBFC;
            }

        .disnone {
            display: none;
        }

        .bm_academic_image1 {
            /*padding: 3px;
   background-color: #525252;
   border: 2px solid #c3cfd3;*/
        }

        .bm_academic_image2 {
            /*padding: 3px;
   background-color: #525252;
   border: 2px solid #c3cfd3;*/
            background-color: #b0c4de;
        }
        /*.bm_academic_image2:hover {
            transform: scale(3);
        }*/

        .bm_clt_padding {
            padding-bottom: 10px;
            clear: both;
        }
        /*.ui-datepicker select.ui-datepicker-month .ui-datepicker select.ui-datepicker-year { width: 30%;}*/
        #topBtn {
            display: none;
            position: fixed;
            bottom: 15px;
            right: 15px;
            z-index: 99;
            font-size: 14px;
            border: none;
            outline: none;
            background-color: #007DC5;
            color: white;
            cursor: pointer;
            padding: 2px;
            border-radius: 4px;
        }

            #topBtn:hover {
                background-color: #f7dc6f; /* #555;*/
            }



        /* ul
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
            position: -webkit-sticky; 
            position: sticky;
            top: 0;
        }
        
        li
        {
            float: left;
        }
        
        li a
        {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }
        
        li a:hover
        {
            background-color: #111;
        }
        
        .active
        {
            background-color: #4CAF50;
        }*/

        * {
            box-sizing: border-box;
        }

        .navbar {
            overflow: hidden;
            background-color: #0080C6;
            font-family: "Helvetica Neue", "Lucida Grande", "Segoe UI", Arial, Helvetica, Verdana, sans-serif;
            border: none;
            outline: none; /* height: 39.2px;*/
        }

        .subnavbar {
            overflow: hidden;
            background-color: #16C1F3;
            font-family: "Helvetica Neue", "Lucida Grande", "Segoe UI", Arial, Helvetica, Verdana, sans-serif;
            border: none;
            outline: none; /* height: 39.2px;*/
        }

        .navbar a {
            float: left;
            font-size: 1.2em;
            color: white;
            text-align: center;
            padding: 10px 12px;
            text-decoration: none;
        }


        .subnavbar a {
            float: left;
            font-size: 1.1em;
            color: white;
            text-align: center;
            padding: 10px 12px;
            text-decoration: none;
        }

        .dropdown, .dropdown1 {
            float: left;
            overflow: hidden;
            border: none;
            outline: none;
        }

        .dropdown2 {
            float: left;
            overflow: hidden;
            border: none;
            outline: none;
            width: 100%;
        }

        .dropdown3, .dropdown4, .dropdown5 {
            overflow: hidden;
            border: none;
            outline: none;
            width: 100%;
        }



        .dropdown .dropbtn {
            font-size: 1.1em;
            border: none;
            outline: none;
            color: white;
            padding: 10px 12px;
            background-color: inherit;
            font-family: inherit;
            margin: 0;
        }

        .dropdown1 .dropbtn1 {
            font-size: 1.1em;
            color: #fff;
            border: none;
            outline: none;
            padding: 8px 12px;
            background-color: inherit;
            font-family: inherit;
        }

        .dropdown2 .dropbtn2, .dropdown3 .dropbtn3, .dropdown4 .dropbtn4, .dropdown5 .dropbtn5 {
            font-size: 1.1em;
            color: #fff;
            border: none;
            outline: none;
            padding: 6px 12px;
            background-color: inherit;
            font-family: inherit;
            width: 100%;
            text-align: left;
        }


        .navbar a:hover {
            background-color: #75d5f1;
            text-decoration: none;
            cursor: pointer;
        }

        .dropdown:hover .dropbtn, .dropbtn:focus {
            background-color: #16C1F3;
            text-decoration: none;
            cursor: pointer;
        }

        .dropdown-content123 {
            display: none;
        }

        .dropdown-content {
            display: none; /*position: absolute;
            left: 0;*/
            background-color: #16C1F3;
            min-width: 160px;
            width: 100%; /* box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;*/ /*padding: 0px 5% 0px 5%;*/ /*border-top: 0.5px #FFFFFF solid;*/
        }

        .dropdown-content1 {
            display: none;
            position: absolute;
            background-color: #70D0F6;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 100;
        }

        .dropdown-content2, .dropdown-content3, .dropdown-content4, .dropdown-content5 {
            display: none;
            position: absolute;
            background-color: #70D0F6;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 100;
            left: 70%;
        }


        .dropdown-content123 a {
            /* float: none;*/
            float: left;
            color: #fff;
            padding: 8px 12px;
            text-decoration: none;
            display: block;
            text-align: left;
        }

        .dropdown-content a {
            /* float: none;*/
            float: left;
            color: #fff;
            padding: 8px 12px;
            text-decoration: none;
            display: block;
            text-align: left;
        }

        .dropdown-content1 a {
            float: none;
            color: #fff;
            padding: 6px 12px;
            text-decoration: none;
            display: block;
            text-align: left;
        }

        .dropdown-content2 a, .dropdown-content3 a, .dropdown-content4 a, .dropdown-content5 a {
            float: none;
            color: #fff;
            padding: 6px 12px;
            text-decoration: none;
            display: block;
            text-align: left;
        }


            .dropdown-content a:hover, .dropdown1:hover .dropbtn1, .dropdown-content1 a:hover, .dropdown2:hover .dropbtn2, .dropdown-content2 a:hover, .dropdown3:hover .dropbtn3, .dropdown-content3 a:hover, .dropdown4:hover .dropbtn4, .dropdown-content4 a:hover, .dropdown5:hover .dropbtn5, .dropdown-content5 a:hover {
                background-color: #f7dc6f;
                color: #465c71;
                text-decoration: none;
                cursor: pointer;
            }

        /*.dropdown:hover .dropdown-content,*/
        .dropdown1:hover .dropdown-content1, .dropdown2:hover .dropdown-content2, .dropdown3:hover .dropdown-content3, .dropdown4:hover .dropdown-content4, .dropdown5:hover .dropdown-content5 {
            display: block;
            text-decoration: none;
        }


        .show {
            display: block;
            text-decoration: none;
        }

        .sticky {
            position: fixed;
            top: 0;
            width: 100%;
            left: 0;
        }

            .sticky + .content {
                padding-top: 60px;
            }




        .nav ul {
            list-style: none;
            background-color: #0080C7;
            text-align: left;
            padding: 0;
            margin: 0;
        }

        .nav li {
            font-family: 'Oswald', sans-serif;
            text-align: left;
            border-bottom: none;
            height: 50px;
            line-height: 50px;
            font-size: 16px;
            display: inline-block;
            margin-right: -4px;
            width: auto;
            min-width: 100px;
        }

        .nav a {
            text-decoration: none;
            white-space: nowrap;
            color: #fff;
            display: block;
            padding-left: 15px;
            padding-right: 15px;
            border-bottom: none;
            transition: .3s background-color;
        }

            .nav a:hover, .nav a:focus {
                background-color: #15C2F3;
                text-decoration: none;
            }



        /* Sub Menus */
        .nav li li {
            font-size: .8em;
        }






        .nav > ul > li {
            text-align: center;
        }

        /* .nav > ul > li > a
        {
            padding-left: 0;
        }*/

        /* Sub Menus */
        .nav li ul {
            position: absolute;
            display: none;
            width: 100%;
            left: 0;
            background-color: #15C2F3;
        }

        .nav li:hover ul {
            display: block;
        }

        .nav li ul li {
            display: block;
            float: left;
        }

        html {
            position: relative;
            min-height: 100%;
        }

        body {
            margin: 0 0 50px; /* bottom = footer height */
        }

        .footer {
            position: absolute;
            left: 0;
            bottom: 0;
            height: 50px;
            width: 100%;
        }

        .bm-main {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .bm_padding_none {
            padding: 0px;
        }

        .bttn {
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



            .bttn:hover {
                background-color: #F68814;
                color: #C7EBFC;
            }

            .bttn:active {
                /*background-color: #F68814;
    color:  #C7EBFC;*/
                background-color: #C7EBFC;
                color: #F68814;
            }

        .edusoft {
            cursor: pointer;
        }

        /* The Modal (background) */
        .modalwin {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 10001; /* Sit on top */
            /*padding-top: 45px;
            padding-left: 180px;*/ /* Location of the box */
            padding-top: 50px;
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            position: relative;
            background-color: #fefefe;
            margin: 0 auto;
            padding: 0;
            border: 5px solid #40803C;
            width: 650px;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.4s;
            animation-name: animatetop;
            animation-duration: 0.4s;
            height: 520px;
        }

        /* Add Animation */
        @-webkit-keyframes animatetop {
            from {
                top: -300px;
                opacity: 0;
            }

            to {
                top: 0;
                opacity: 1;
            }
        }

        @keyframes animatetop {
            from {
                top: -300px;
                opacity: 0;
            }

            to {
                top: 0;
                opacity: 1;
            }
        }

        /* The Close Button */
        .close {
            color: white;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .modal-header {
            padding: 2px 16px;
            background-color: #40803C;
            color: #fff;
        }

        .modal-body {
            /*padding: 2px 16px;*/
            padding: 0px;
            height: 500px;
            overflow: hidden;
        }

        .modal-footer {
            padding: 2px 16px;
            background-color: #40803C;
            color: white;
        }

        .modalBackground {
            background-color: #000;
            /*filter: alpha(opacity=70);
opacity: 0.70;*/
            background-color: rgba(0,0,0,0.4);
        }

        .closepop {
            margin: 0 0 0 20px;
            /*BACKGROUND: url(../images/close.png) no-repeat 0 0;*/
            WIDTH: 26px;
            POSITION: relative;
            background-position: right;
            HEIGHT: 26px;
            cursor: pointer;
            z-index: 100000;
            float: right;
        }

        .disnone {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $('.bm_nationality').click(function () {
                fnOpenNationalityList("100012", $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.bm_profession').click(function () {
                fnOpenProfessionList("100012", $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"), $(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
            });

            $('.stdimagecapture').click(function () {
                fnImageCapture("100012", '~/images/profile/studentonline/', $("#<%= ximagelink.ClientID%>").attr("ID"), $("#<%= _stdimageurl.ClientID%>").attr("ID"), $("[id$='_row']").val(), "studenton");
            });

            $('.cerimagecapture').click(function () {
                fnImageCapture1("100012", '~/images/profile/birthcertificate/student/', $("#<%= xcertificatelink.ClientID%>").attr("ID"), $("#<%= _cerimageurl.ClientID%>").attr("ID"), $("[id$='_row']").val(), "studenton");
            });

            $('.edusoft').click(function () {
                //alert("hi");

                $("#<%= Button3.ClientID%>").click();

                return false;
            });

        });

        function fnPrintAdmit() {
            //alert("Hi");

            document.getElementById("<%= myModal.ClientID %>").style.display = "none";

            var xrow_1 = $("#<%= _row.ClientID%>").val();
            if (xrow_1 != "") {
                var openwin = window.open('/forms/academic/reports/stappformon.aspx?xrow=' + xrow_1, 'admiton', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
                openwin.focus();
            } else {
                alert("Please submit application.");
            }

            return false;
        }

       <%-- $("#<%= btnSubmit.ClientID%>").click(function (e) {
            e.preventDefault();
        });--%>

        function fnSubmitConfrim() {
            var selectedvalue = confirm("Do you really want to submit this application? After submit you can not change any record.");
            if (selectedvalue) {
                document.getElementById('<%=_submitconf.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=_submitconf.ClientID %>').value = "No";
            }
        }

        <%--  function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=Button1.ClientID %>").click();
            }
        }

        function UploadFile1(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=Button2.ClientID %>").click();
                }
            }--%>

    </script>
</head>
<body>
    <div class="bm-main">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
            </asp:ScriptManager>
            <div class="header" runat="server" id="header">
                <div style="width: 1229.4px; margin: 0 auto; background-color: #0095DA; height: 60px;">
                    <div class="title">
                        <div style="margin-left: 10px; margin-top: 8px; display: inline-block">
                            <%--<asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/Edusoft.png"
                                Height="44px" Width="100px" />--%>
                        </div>
                        <div style="margin-left: 450px; margin-top: 5px; display: inline-block">
                            <asp:Image ID="Image2" runat="server" ImageAlign="Middle" ImageUrl="~/images/PIS Logo final 163X50.png"
                                Height="50px" Width="163px" />
                        </div>
                    </div>
                    <div class="loginDisplay">
                        <%--<asp:LinkButton ID="btnLogout" runat="server" Text="Log Out" ></asp:LinkButton>
                        ] [
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/ztchngpass.aspx" Target="_blank" runat="server">Change Password</asp:HyperLink>
                        ]
                    <br />
                        Welcome <span class="bold">
                            <asp:Label ID="lblUser" runat="server" Text="admin"></asp:Label>
                        </span><span style="padding-left: 5px; padding-right: 5px;">for</span><span class="bold"><asp:Label
                            ID="lblBusiness" runat="server" Text="Business Manager"></asp:Label></span>--%>
                    </div>
                </div>
            </div>
            <table width="1229.4px" style="margin: 0 auto; border: none; background-color: #fff;">
                <tr>
                    <td>

                        <div class="page" style="width: 100%;">
                            <div class="main">
                                <div class="bm_academic_container">
                                    <div class="bm_academic_container_message">
                                        <div class="message" id="message" runat="server">
                                            <%-----THIS IS MESSAGE SECTION-----%>
                                        </div>
                                    </div>
                                    <div class="bm_academic_container_body1" style="min-height: 600px; border-top: 5px solid #007DC5;">
                                        <%--border-top: 5px solid #007DC5;--%>
                                        <div class="bm_academic_container_body_input_section">
                                            <div class="bm_layout_container" style="padding-top: 20px; margin: 0 auto; width: 900px;">
                                                <div class="bm_layout_box_100" style="width: 100%;">
                                                    <div id="xtitle" runat="server" style="font-size: 20px; border-bottom: 2px solid #007DC5;">Application for : 2020/21 session</div>
                                                    <div id="formdiv" style="width: 100%; padding-top: 20px; padding-left: 80px;">
                                                        <div style="width: 100%;">
                                                            <div style="width: 100%; font-size: 20px;">

                                                                <div style="float: left;">
                                                                    Applicant's Informations:
                                                                </div>

                                                                <div style="float: right;">
                                                                    <%--<asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                                        Width="32px" Height="32px" OnClientClick="fnPrintAdmit();" CssClass="bm_academic_button_zoom" ToolTip="Print Applicant Copy" />--%>

                                                                    <input type="image" src="/images/printer-blue-icon.png" id="ImageButton7" style="width: 32px; height: 32px;" class="bm_academic_button_zoom" 
                                                                        title="Print Applicant Copy" onclick="fnPrintAdmit(); return false;"
                                                                        />
                                                                </div>

                                                            </div>

                                                        </div>
                                                        <div id="formupper" style="width: 100%; padding-top: 0px; clear: both;">
                                                            <div id="_left" style="display: inline-block; vertical-align: top; width: 59%;">

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label14" runat="server" Text=" Student's Name :" AssociatedControlID="xname"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label1" runat="server" Text=" Date of Birth :" AssociatedControlID="xdob"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xdob" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_datepicker "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <asp:RegularExpressionValidator runat="server" ControlToValidate="xdob" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                                                    ErrorMessage="Invalid date format. Enter date in 'DD/MM/YYYY' format." Display="Dynamic" ForeColor="#FF0000" Font-Size="14" />

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label2" runat="server" Text=" Nationality :" AssociatedControlID="xnation"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 92.7%">
                                                                            <asp:TextBox ID="xnation" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                        <div class="bm_list_img" style="width: 7.3%">
                                                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_nationality" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding" style="padding-bottom: 8px;">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label3" runat="server" Text=" Gender :" AssociatedControlID="xgender"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:DropDownList ID="xgender" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label4" runat="server" Text=" Religion :" AssociatedControlID="xreligion"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:DropDownList ID="xreligion" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label5" runat="server" Text=" Applying For :" AssociatedControlID="xclass"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_50_60 bm_academic_ctl_global bm_academic_dropdown">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding" style="padding-top: 15px; font-style: italic;">
                                                                    Is the applicant attending school now? if yes, please write name &amp; location.
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label6" runat="server" Text=" Present School :" AssociatedControlID="xpschool"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xpschool" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label7" runat="server" Text=" Location :" AssociatedControlID="xlocation"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xlocation" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding" style="padding-top: 20px; font-style: italic;">
                                                                    Siblings at Presidency (if any).
                                                                </div>

                                                                <%-- <div class="bm_clt_padding">
                                                                </div>--%>

                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>

                                                                        <div class="bm_ctl_container_dynamic_100_80_imgbtn">
                                                                            <asp:ImageButton ID="ImageButton9" runat="server" CssClass="bm_academic_imgbtn_add bm_academic_button_zoom"
                                                                                Height="23px" Width="27px" ImageUrl="~/images/add.png" OnClick="ImageButton9_Click" />
                                                                        </div>

                                                                        <div class="bm_clt_padding">
                                                                        </div>
                                                                        <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 15px;">
                                                                            <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                                                <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                                                    <asp:Label ID="Label77" runat="server" Text="#" CssClass="label"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 98px; margin-right: 10px; text-align: center;">
                                                                            <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                                                <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                                                    <asp:Label ID="Label78" runat="server" Text="ID" CssClass="label"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="bm_ctl_container_dynamic_100_80_nl" style="width: 112px; margin-right: 10px; text-align: center;">
                                                                            <div class="bm_ctl_container_60_80" style="width: 100%; float: left;">
                                                                                <div class="bm_ctl_label_align_center_60_80" style="width: 100%">
                                                                                    <asp:Label ID="Label18" runat="server" Text="Class" CssClass="label"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="bm_clt_padding">
                                                                        </div>
                                                                        <div style="width: 100%;" id="placeholder9" runat="server">
                                                                            <%--<div class="bm_ctl_container_dynamic_100_80_nl">
                                                        <asp:Label ID="Label57" runat="server" Text="1." CssClass="label"></asp:Label>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 202px">
                                                        <asp:TextBox ID="TextBox13" runat="server" Style="width: 198px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 320px">
                                                        <asp:TextBox ID="TextBox13" runat="server" Style="width: 316px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_ctl_container_dynamic_100_80_wol" style="width: 120px">
                                                        <asp:TextBox ID="TextBox15" runat="server" Style="width: 116px" CssClass="bm_academic_textbox_dynamic_100_80 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>
                                                    </div>
                                                    <div class="bm_clt_padding">
                                                </div>--%>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </div>
                                                            <div id="_right" style="display: inline-block; vertical-align: top; width: 39%; padding-left: 50px;">

                                                                <%--Right Side--%>

                                                                <div style="width: 100%;">
                                                                    <div style="float: left;">

                                                                        <div style="display: none;">
                                                                            <table style="border: none;">
                                                                                <tr>
                                                                                    <td colspan="2" style="text-align: center; border: 1px solid #00ced1;">Photo
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100px">
                                                                                        <asp:RadioButton ID="rdoUpload" runat="server" Checked="True" GroupName="image1"
                                                                                            Text="Upload" CssClass="stdimageupload" AutoPostBack="True" OnCheckedChanged="fnImageCheckedChanged" />
                                                                                    </td>
                                                                                    <td style="width: 100px">
                                                                                        <asp:RadioButton ID="rdoCapture" runat="server" GroupName="image1" Text="Capture"
                                                                                            CssClass="stdimagecapture" AutoPostBack="True" OnCheckedChanged="fnImageCheckedChanged" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div style="border: 1px solid #00ced1; width: 200px; padding: 5px; text-align: center; margin-bottom: 2px;">Photo</div>
                                                                        <div>
                                                                            <asp:Image ID="ximagelink" ImageUrl="~/images/no-image.png" CssClass="bm_academic_image1"
                                                                                runat="server" Height="200px" Width="200px" />
                                                                        </div>
                                                                        <%--<div style="width: 200px; text-align: center; padding: 5px; background-color: #C7EBFC; color: #000;">
                                                                            Photo
                                                                        </div>--%>
                                                                        <div id="ErrorMsg" style="margin-top: 3px; font-size: 12px; color: #FF0000;" runat="server">
                                                                        </div>
                                                                        <div style="margin-top: 5px;">
                                                                            <%--<label class="file-upload">
                                                                                <span><strong>Upload Image</strong></span>
                                                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="170px" />
                                                                            </label>--%>

                                                                            <%--<label class="custom-file-upload">
                                                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="170px" />
                                                                                <i class="fa fa-cloud-upload"></i>Upload
                                                                            </label>--%>
                                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="170px" />

                                                                            <asp:ImageButton ID="ImageButton3" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                                                runat="server" Width="30px" OnClick="ImageButton3_Click" ToolTip="Upload Photo" />
                                                                            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="disnone" OnClick="Button1_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div style="width: 100%; margin-top: 30px;">
                                                                    <div style="float: left;">
                                                                        <%--<div style="width: 200px; text-align: center; padding: 5px; background-color: #C7EBFC; color: #000;">
                                                                            Birth Certificate
                                                                        </div>--%>
                                                                        <div style="display: none;">
                                                                            <table style="border: none;">
                                                                                <tr>
                                                                                    <td colspan="2" style="text-align: center; border: 1px solid #00ced1">Birth Certificate
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 100px">
                                                                                        <asp:RadioButton ID="rdoUpload1" runat="server" Checked="True" GroupName="image2"
                                                                                            Text="Upload" CssClass="cerimageupload" AutoPostBack="True" OnCheckedChanged="fnImageCheckedChanged1" />
                                                                                    </td>
                                                                                    <td style="width: 100px">
                                                                                        <asp:RadioButton ID="rdoCapture1" runat="server" GroupName="image2" Text="Capture"
                                                                                            CssClass="cerimagecapture" AutoPostBack="True" OnCheckedChanged="fnImageCheckedChanged1" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div style="border: 1px solid #00ced1; width: 200px; padding: 5px; text-align: center; margin-bottom: 2px;">Birth Certificate</div>
                                                                        <div>
                                                                            <asp:Image ID="xcertificatelink" CssClass="bm_academic_image2"
                                                                                runat="server" Height="100px" Width="200px" />
                                                                        </div>
                                                                        <div id="ErrorMsg1" style="margin-top: 3px; font-size: 12px; color: #FF0000;" runat="server">
                                                                        </div>
                                                                        <div style="margin-top: 5px;">

                                                                            <%--<label class="custom-file-upload">
                                                                                <asp:FileUpload ID="FileUpload2" runat="server" Width="170px" />
                                                                                <i class="fa fa-cloud-upload"></i>Upload
                                                                            </label>--%>

                                                                            <asp:FileUpload ID="FileUpload2" runat="server" Width="170px" />

                                                                            <asp:ImageButton ID="ImageButton2" ImageUrl="~/images/upload_button-512.png" CssClass="bm_academic_imagebtn"
                                                                                runat="server" Width="30px" OnClick="ImageButton2_Click" ToolTip="Upload Birth Certificate" />
                                                                            <asp:Button ID="Button2" runat="server" Text="Button" CssClass="disnone" OnClick="Button2_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>

                                                        <div style="width: 100%; margin-top: 20px; border-top: 2px solid #007DC5;">
                                                            <div style="width: 100%; font-size: 20px; margin-top: 15px;">Family Informations:</div>
                                                        </div>
                                                        <div id="formlower" style="width: 100%; margin-top: 10px;">
                                                            <div id="_left1" style="display: inline-block; vertical-align: top; width: 59%;">

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label8" runat="server" Text=" Mother's Name :" AssociatedControlID="xmname"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xmname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <%--<div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label9" runat="server" Text=" Profession :" AssociatedControlID="xprofession"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xprofession" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>--%>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label9" runat="server" Text=" Profession :" AssociatedControlID="xprofession"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 92.7%">
                                                                            <asp:TextBox ID="xprofession" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                        <div class="bm_list_img" style="width: 7.3%">
                                                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_profession" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label10" runat="server" Text=" Cell No :" AssociatedControlID="xcellno"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xcellno" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label11" runat="server" Text=" Father's Name :" AssociatedControlID="xfname"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xfname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <%-- <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label12" runat="server" Text=" Profession :" AssociatedControlID="xprofession1"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xprofession1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>--%>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label12" runat="server" Text=" Profession :" AssociatedControlID="xprofession1"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 92.7%">
                                                                            <asp:TextBox ID="xprofession1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                        <div class="bm_list_img" style="width: 7.3%">
                                                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_profession" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label13" runat="server" Text=" Cell No :" AssociatedControlID="xcellno1"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xcellno1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label15" runat="server" Text=" Email :" AssociatedControlID="xemail1"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xemail1" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="xemail1"
                                                                    ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                                    Display="Dynamic" ErrorMessage="Invalid email address" Font-Size="14" />

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label16" runat="server" Text=" Present Address :" AssociatedControlID="xpadd"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xpadd" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding">
                                                                </div>

                                                                <div class="bm_ctl_container_50_100">
                                                                    <div class="bm_ctl_label_align_right_50_100" style="width: 29.8%">
                                                                        <asp:Label ID="Label17" runat="server" Text=" Permanent Address :" AssociatedControlID="xperadd"
                                                                            CssClass="label"></asp:Label>
                                                                    </div>
                                                                    <div class="bm_clt_ctl_50_100" style="width: 70.2%">
                                                                        <div class="bm_list_text" style="width: 100%">
                                                                            <asp:TextBox ID="xperadd" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>



                                                                

                                                            </div>
                                                        </div>
														
														<div style="width: 100%; margin-top: 20px; border-top: 2px solid #007DC5;">
                                                            <div style="width: 100%; font-size: 20px; margin-top: 15px;">Declaration:</div>
                                                        </div>
														
														<div id="formlower" style="width: 100%; margin-top: 10px;">
                                                            <div id="_left1" style="display: inline-block; vertical-align: top; width: 59%;">
															
															
															<div class="bm_clt_padding" style="text-align: justify; width: 100%; margin-top: 20px; padding-bottom: 5px;">
                                                              <ul>
															  <li>Tuition fees have to be paid by 20th of every month in Bank hours (10:00 a.m. - 2:00 p.m.). From 21st to the last 
															  day of a month, Tk. 200.00 has to be paid as late fee. If paid in the following month, Tk. 500.00 has to be paid.</li>
															  <li style="padding-top:5px;">If not paid in the 2nd month, admission will be cancelled and defaulter has to be readmitted by paying the admission fee.</li>
															  </ul>
                                                            </div>
															
															
															<div class="bm_clt_padding" style="text-align: justify; width: 100%; margin-top: 15px; padding-bottom: 5px;">
                                                                    I certify that all information given on this application is correct. Failure to provide complete
                                                                      and accurate information is ground for re-evaluation of the individual application and review of
                                                                      a student's continued enrollment at Presidency International School.
                                                                </div>

                                                                <%--<div class="bm_clt_padding" style="">
                                                                </div>--%>

                                                                <div style="width: 100%; text-align: left;">
                                                                    <div style="float: right;">
                                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical">
                                                                            <asp:ListItem Text="Mother" Value="Mother" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="Father" Value="Father"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding" style="">
                                                                </div>

                                                                <div style="width: 100%; text-align: left;">
                                                                    <div style="float: right;">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="bm_academic_button bm_am_btn_submit" OnClick="btnSubmit_Click" />
                                                                    </div>
                                                                </div>

                                                                <div class="bm_clt_padding" style="">
                                                                </div>
															
															</div>
														</div>
														
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <span class="back_to_top" id="topBtn">
                                <img alt="" src="/images/top.png" width="32px" height="32px" />
                            </span>

                            <div class="clear">
                            </div>
                        </div>

                    </td>
                </tr>
            </table>

            <div class="footer" runat="server" id="footer" style="background-color: #fff; width: 100%;">


                <div style="width: 1229.4px; margin: 0 auto; height: 50px; padding-top: 0px; text-align: left;">
                    <%--©<%= DateTime.Today.Year %> Business Manager--%>
                    <div style="font-size: 10px; padding-top: 0px; padding-left: 150px; width: 100%; border-bottom: 2px solid #b6b7bc;">
                        Powered by
                    </div>
                    <div style="padding-left: 180px; padding-bottom: 20px;">
                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/Edusoft.png"
                            Height="44px" Width="100px" CssClass="edusoft" />
                    </div>
                </div>

            </div>

            <asp:HiddenField ID="_stdimageurl" runat="server" />
            <asp:HiddenField ID="_cerimageurl" runat="server" />
            <asp:HiddenField ID="_row" runat="server" />
            <asp:HiddenField ID="_submitconf" runat="server" />




            <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_OnServerClick" CssClass="disnone" />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField ID="hxsubject" runat="server" />
                    <asp:HiddenField ID="hxpaper" runat="server" />
                    <asp:HiddenField ID="hxext" runat="server" />
                    <asp:HiddenField ID="hdxsubject" runat="server" />
                    <asp:HiddenField ID="hxclass" runat="server" />
                    <asp:HiddenField ID="hxsection" runat="server" />

                    <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="fnLoadFiles" CssClass="disnone" />--%>


                    <%--<input id="Button3" type="button" value="button" runat="server" class="disnone" onserverclick="Button3_OnServerClick" />--%>



                    <div id="myModal" class="modalwin" runat="server">

                        <!-- Modal content -->
                        <div class="modal-content" style="border: 2px solid #007DC5; background-color: #eef6e8">
                            <div class="modal-header" style="background-color: #007DC5;">
                                <span class="close">&times;</span>
                                <h2 style="color: #fff;">CONTACT US</h2>
                            </div>

                            <div class="modal-body">

                                <div style="text-align: center; margin-top: 10px;">
                                    <img src="/images/Edusoft.png" height="44px" width="100px" />
                                </div>

                                <div id="_inputsec" style="display: block;">
                                    
                                    <div style="text-align: center; margin-top: 5px; color: #000;">
                                        Got a question? We'd love to hear from you. Send us a message
                                    <br />
                                        and we'll respond as soon as possible. 
                                    </div>

                                    <div style="margin-left: 132px; margin-top: 10px; color: #000;">

                                        <div style="text-align: left;" id="name">
                                            Name *
                                        </div>

                                        <div style="text-align: left; margin-top: 2px;">
                                            <asp:TextBox ID="txtName" runat="server" Width="380"></asp:TextBox>
                                        </div>

                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtName"></asp:RequiredFieldValidator>--%>

                                        <div style="text-align: left; margin-top: 5px;" id="email">
                                            Email *
                                        </div>

                                        <div style="text-align: left; margin-top: 2px;">
                                            <asp:TextBox ID="txtemail" runat="server" Width="380"></asp:TextBox>
                                        </div>

                                        <div style="text-align: left; margin-top: 2px; color: #ff0000; display: none;" id="emailmsg">
                                        </div>

                                        <div style="text-align: left; margin-top: 5px;" id="mobile">
                                            Mobile No *
                                        </div>

                                        <div style="text-align: left; margin-top: 2px;">
                                            <asp:TextBox ID="txtMobileNo" runat="server" Width="380"></asp:TextBox>
                                        </div>

                                        <div style="text-align: left; margin-top: 5px;" id="subject">
                                            Subject *
                                        </div>

                                        <div style="text-align: left; margin-top: 2px;">
                                            <asp:TextBox ID="txtSubject" runat="server" Width="380"></asp:TextBox>
                                        </div>

                                        <div style="text-align: left; margin-top: 5px;" id="message5">
                                            Message *
                                        </div>

                                        <div style="text-align: left; margin-top: 2px;">
                                            <asp:TextBox ID="txtMessage" runat="server" Width="380" TextMode="MultiLine" Height="100"></asp:TextBox>
                                        </div>

                                        <div style="text-align: left; margin-top: 5px;">
                                            <%--<asp:Button ID="btnSend" runat="server" Text="Send" CssClass="bm_academic_button bm_am_btn_send" />--%>
                                            <input id="btnSend" type="button" value="Send" class="bm_academic_button bm_am_btn_send" />
                                        </div>

                                    </div>

                                </div>
                                
                                <div id="_msgsec" style="display: none;text-align: center; margin-top: 10px; color: #0a632a; font-size: 20px;">
                                    Thanks. We have received your message. <br/>We will contact you very soon.
                                    </div>

                            </div>

                        </div>

                    </div>



                    <script>
                        $("body").on("click", ".bm_am_btn_clear", function () {


                           <%-- $("#<%= message1.ClientID %>").empty();--%>

                            return false;
                        });

                        // Get the modal
                        //var modal = document.getElementById("myModal");

                        var modal = document.getElementById("<%= myModal.ClientID %>");

                        // Get the button that opens the modal
                        var btn = document.getElementById("myBtn");

                        // Get the <span> element that closes the modal
                        var span = document.getElementsByClassName("close")[0];



                        $("body").on("click", ".close", function () {


                            document.getElementById("<%= myModal.ClientID %>").style.display = "none";
                            document.getElementById("<%= hxsubject.ClientID %>").value = "";
                            document.getElementById("<%= hxpaper.ClientID %>").value = "";
                            document.getElementById("<%= hxext.ClientID %>").value = "";

                           <%-- $("#<%= btnClose.ClientID%>").click();--%>


                            $("#<%= message.ClientID %>").empty();
                        });

                        var openwin;
                        function fnOpenStudentFeedback(xsubject, xpaper, xext, xclass, xsection) {
                            //alert("Hi");
                            //alert(xclass);


                            return false;
                        }

                        $("body").on("click", ".bm_am_btn_send", function () {

                            //alert("Hi!");

                            var flag = 0;

                            var xname1 = $("#<%= txtName.ClientID %>").val();
                            var xmobile1 = $("#<%= txtMobileNo.ClientID %>").val();
                            var xemail1 = $("#<%= txtemail.ClientID %>").val();
                            var xsubject1 = $("#<%= txtSubject.ClientID %>").val();
                            var xmessage1 = $("#<%= txtMessage.ClientID %>").val();

                            if (xname1 == "") {
                                $("#name").css('color', '#ff0000');
                                flag = 1;
                            } else {
                                $("#name").css('color', '#000');
                            }

                            if (xmobile1 == "") {
                                $("#mobile").css('color', '#ff0000');
                                flag = 1;
                            } else {
                                $("#mobile").css('color', '#000');
                            }

                            if (xemail1 == "") {
                                $("#email").css('color', '#ff0000');
                                flag = 1;
                            } else {
                                $("#email").css('color', '#000');
                            }

                            if (xsubject1 == "") {
                                $("#subject").css('color', '#ff0000');
                                flag = 1;
                            } else {
                                $("#subject").css('color', '#000');
                            }


                            if (xmessage1 == "") {
                                $("#message5").css('color', '#ff0000');
                                flag = 1;
                            } else {
                                $("#message5").css('color', '#000');
                            }

                            if (flag == 1) {
                                return false;
                            }

                            var email_regex = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                            if (!email_regex.test(xemail1)) {

                                $("#emailmsg").css('display', 'block');
                                $("#emailmsg").html("Invalid email address.");

                                return false;
                            } else {
                                $("#emailmsg").css('display', 'none');
                            }


                            //alert("Sent");

                            $.ajax({
                                url: "amadmissionform.aspx/fnSendEmail",

                                type: "POST",

                                data: "{'xname1' :'" + xname1 + "', 'xemail1' :'" + xemail1 + "', 'xmobile1': '" + xmobile1 + "', 'xmessage1' : '" + xmessage1 + "', 'xsubject1': '" + xsubject1 + "'}",

                                //dataType: "json",
                                contentType: "application/json; charset=utf-8",

                                async: false,
                                success: function (res) {

                                    var r = res.d;
                                    if (r != "success") {
                                        alert(r);
                                    } else {
                                        $("#_inputsec").css('display', 'none');
                                        $("#_msgsec").css('display', 'block');
                                    }
                                },
                                error: function (err) {
                                    alert("ERROR : " + err);
                                }
                            });

                            return false;
                        });


                    </script>



                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>







        </form>
    </div>

    <%--<script type="text/javascript">



        // When the user scrolls down 20px from the top of the document, show the button
        window.onscroll = function () { scrollFunction() };

        var navbar = document.getElementById("navbar");
        var sticky = navbar.offsetTop;

        //        function scrollFunction() {
        //            if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        //                document.getElementById("topBtn").style.display = "block";
        //            } else {
        //                document.getElementById("topBtn").style.display = "none";
        //            }

        //            //                                                if (window.pageYOffset >= sticky) {
        //            //                                                    navbar.classList.add("sticky");
        //            //                                                } else {
        //            //                                                    navbar.classList.remove("sticky");
        //            //                                                }
        //        }

        // When the user clicks on the button, scroll to the top of the document
        //        function topFunction() {
        ////            document.body.scrollTop = 0;
        //            //            document.documentElement.scrollTop = 0;
        ////            $('body, html').animate({ scrolltop: 0 }, 800);
        ////            return false;
        //        }

        /* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
        function myFunction() {
            //document.getElementById("myDropdown").classList.toggle("show");
            //alert(this.id);
        }

        // Close the dropdown if the user clicks outside of it
        window.onclick = function (event) {
            if (!event.target.matches('.dropbtn')) {

                var dropdowns = document.getElementsByClassName("dropdown-content");
                var i;
                for (i = 0; i < dropdowns.length; i++) {
                    var openDropdown = dropdowns[i];
                    if (openDropdown.classList.contains('show')) {
                        openDropdown.classList.remove('show');
                    }
                }
            }
        }


        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                //                $('.back_to_top').attr('style','display:block');
                $('.back_to_top').fadeIn();
            }
            else {
                //                $('.back_to_top').attr('style', 'display:none');
                $('.back_to_top').fadeOut();
            }
        });
        $('.back_to_top').click(function () {
            $('body,html').animate({ scrollTop: 0 }, 800);
        });

    </script>--%>
</body>
</html>
