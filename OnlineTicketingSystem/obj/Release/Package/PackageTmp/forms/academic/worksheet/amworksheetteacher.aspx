<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="amworksheetteacher.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.worksheet.amworksheetteacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="wdith_body">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="shortcut icon" type="image/x-icon" href="/images/edusoft.ico" />
    <title>My Homework</title>
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
        @media only screen and (min-width: 1200px) {
            .wdith_body {
                height: 100%;
                margin: 0px;
                width: 100%;
            }
        }

        @media only screen and (max-width: 1199px) {
            .wdith_body {
                height: 650px;
                margin: 0px;
                width: 1250px;
            }
        }

        /*html, body {
            height: 100%;
            margin: 0px;
        }*/

        .link {
            text-align: center;
            font-size: 13px;
        }

        .image {
        }

            .image:hover {
                /*width: 85px;
            height: 85px;*/
                transform: scale(1.2);
            }

        a {
            text-decoration: none;
        }

            a:hover {
                /*text-decoration: underline;*/
            }

        .link_con {
            display: inline-block;
            vertical-align: top;
            text-align: center;
            /*width: -moz-min-content;
  width: -webkit-min-content;
    width: min-content;*/
            width: 95px;
            padding: 0 10px;
            overflow-wrap: break-word;
        }

        ._width {
            width: 180px;
        }

        #_link {
            cursor: pointer;
        }

        #_link99 {
            cursor: pointer;
        }

        #_link999 {
            cursor: pointer;
        }

        /* The Modal (background) */
        .modalwin {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 10001; /* Sit on top */
            padding-top: 45px;
            padding-left: 180px; /* Location of the box */
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
            margin: auto;
            padding: 0;
            border: 5px solid #40803C;
            width: 1030px;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.4s;
            animation-name: animatetop;
            animation-duration: 0.4s;
            height: 560px;
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
    <script>
        // Get the modal
        var modal = document.getElementById("myModal");

       

        function fnOpenUpload(xsubject,xpaper,xext) {
            //alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession = $("#<%= xsession.ClientID%>").val();
            var xterm = $("#<%= xterm.ClientID%>").val();
            var xclass = $("#<%= xclass.ClientID%>").val();
            var xsection = $("#<%= xsection.ClientID%>").val();

            //document.getElementById("myModal").style.display = "block";
            var openwin = window.open('/forms/academic/worksheet/amuploadteacher.aspx?zid='+zid+'&xsession='+xsession+'&xterm='+xterm+'&xclass='+xclass+'&xsection='+xsection+'&xsubject='+xsubject.replace(/&/gi, "%26")+'&xpaper='+xpaper+'&xext='+xext,'uploadteacher', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            //openwin.print();
            return false;
        }

        $("body").on("click", ".bm_uploadhomework", function () {

            //                alert("Hi");
            //                return false;

            var mendatoryFields = [
                { "id": "<%= xsession.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xterm.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xclass.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xsection.ClientID%>", "prop": "combo", "tab": "0" }
            ];
            var mendatoryString = JSON.stringify(mendatoryFields);
            if (!fnMendatoryFields1(mendatoryString)) {
                return false;
            }
            return true;
        });

        $("body").on("click", ".bm_studentfeedback", function () {

            //                alert("Hi");
            //                return false;

            var mendatoryFields = [
                { "id": "<%= xsession1.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xterm1.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xclass1.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xsection1.ClientID%>", "prop": "combo", "tab": "0" }
            ];
            var mendatoryString = JSON.stringify(mendatoryFields);
            if (!fnMendatoryFields1(mendatoryString)) {
                return false;
            }
            return true;
        }); 

        $("body").on("click", ".bm_teacherfeedback", function () {

            //                alert("Hi");
            //                return false;

            var mendatoryFields = [
                { "id": "<%= xsession1.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xterm1.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xclass1.ClientID%>", "prop": "combo", "tab": "0" },
                { "id": "<%= xsection1.ClientID%>", "prop": "combo", "tab": "0" }
            ];
            var mendatoryString = JSON.stringify(mendatoryFields);
            if (!fnMendatoryFields1(mendatoryString)) {
                return false;
            }
            return true;
        });

        

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks on <span> (x), close the modal
        //document.getElementsByClassName("close")[0].onclick = function() {
        //    document.getElementById("myModal").style.display = "none";
        //}

        //$("[id*=close]").live("click", function () {
        //    document.getElementById("myModal").style.display = "none";
        //});


    </script>
</head>
<body class="wdith_body" style="background-color: #ebeaf5;">


    <div style="background-color: #7d7fbd; position: fixed; z-index: 1000; width: 100%; height: 40px; padding-top: 5px; padding-left: 45px; font-family: Comic Sans MS; color: #fff; font-size: x-large; font-weight: bold; box-shadow: 5px 5px 8px 1px #888888;">
        <img src="/images/myhw_logo.png" width="250px" height="95%" /></div>

    <%-- <div style="width: 1250px; height: 100%;">--%>
    <form id="form1" runat="server" style="height: 100%">

        <div style="display: inline-block; width: 250px; height: 100%; position: fixed; z-index: 999;">
            <div style="width: 100%; height: 100%; background-color: #b4b6db; vertical-align: top; position: relative;">
                <div style="width: 100%; text-align: center; padding-top: 70px;">
                    <img src="/images/school_logo.png" width="171" height="73" />
                </div>
                <%--<div style="width: 100%; text-align: center; padding-top: 10px;">
            <img src="/images/myhomework.png" style="width: 120px; height: 160px;" />
        </div>--%>
                <div style="width: 100%; text-align: center; padding-top: 60px;">
                    <img alt="No image available" src="/images/no-image.png" style="width: 120px; height: 120px; border-radius: 50%; -moz-border-radius: 50%;" runat="server" id="ximagelink" />
                </div>
                <div style="width: 100%; text-align: center; padding-top: 5px; font-size: 18px;" runat="server" id="xstudentname">
                </div>
                <div style="width: 100%; text-align: center; padding-top: 0px;" runat="server" id="xstudentclasssection">
                </div>
                <div style="width: 100%; text-align: center; padding-top: 3px;">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/ztchngpass.aspx" Target="_blank" runat="server">Change Password</asp:HyperLink>
                </div>
                <div style="width: 100%; text-align: center; padding-top: 20px; position: absolute; bottom: 100px; padding-bottom: 0px; z-index: 100;">


                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="/images/logout_icon.png"
                        Width="90px" Height="35px" CssClass="bm_academic_button_zoom" ToolTip="Logout" OnClick="btnLogout_Click" />
                </div>
                <div style="width: 100%; text-align: left; padding-top: 20px; padding-left: 25px; position: absolute; bottom: 87px; padding-bottom: 0px; border-bottom: 1px solid #fff; font-size: 12px">
                    Powered by:
                </div>
                <div style="width: 100%; text-align: center; padding-top: 20px; position: absolute; bottom: 0; padding-bottom: 30px;">
                    <img src="/images/edusoft_logo.png" />
                </div>

            </div>

        </div>

        <div style="display: inline-block; width: 100%; height: 100%; margin-left: 20px; vertical-align: top; overflow-y: auto; padding-top: 45px; padding-left: 255px; padding-right: 30px;">

            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <div class="bm_academic_container_message">
                <div class="message" id="message" runat="server">
                </div>
            </div>

            <div class="bm_academic_grid_container" id="Div60" runat="server" style="margin-bottom: 30px;">

                <div class="grid_header" style="background-color: #fcaf17;">
                    <div class="grid_header_label" id="_grid_header" runat="server" style="font-size: 16px; vertical-align: central;">
                        Upload Homeworks
                    </div>
                    <div class="grid_header_control">
                    </div>
                    <div class="flot_right">
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label31" runat="server" Text="Session " AssociatedControlID="xsession"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px; width: 122px">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label1" runat="server" Text="Term " AssociatedControlID="xterm" CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label2" runat="server" Text="Class " AssociatedControlID="xclass"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px; display: none">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label4" runat="server" Text="Group " AssociatedControlID="xgroup"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label3" runat="server" Text="Section " AssociatedControlID="xsection"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px; margin-right: 20px;">
                            <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                    Width="25px" Height="25px" CssClass="bm_academic_button_zoom bm_uploadhomework" OnClick="fnUploadHomeworks" />

                            </div>
                        </div>
                    </div>
                </div>


                <div runat="server" id="upload_homeworks" style="width: 100%; margin-top: 5px;">
                </div>


            </div>

            <div class="bm_academic_grid_container" id="Div1" runat="server" style="margin-top: 40px">
                <div class="grid_header" style="background-color: #60bc56;">
                    <div class="grid_header_label" id="Div2" runat="server" style="font-size: 16px; vertical-align: central;">
                        Students' Feedback
                    </div>
                    <div class="grid_header_control">
                    </div>
                    <div class="flot_right">
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label5" runat="server" Text="Session " AssociatedControlID="xsession1"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xsession1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px; width: 122px">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label6" runat="server" Text="Term " AssociatedControlID="xterm1" CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xterm1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label7" runat="server" Text="Class " AssociatedControlID="xclass1"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xclass1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px; display: none">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label8" runat="server" Text="Group " AssociatedControlID="xgroup1"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xgroup1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label9" runat="server" Text="Section " AssociatedControlID="xsection1"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xsection1" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px; margin-right: 20px;">
                            <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/reload70.png"
                                    Width="25px" Height="25px" CssClass="bm_academic_button_zoom bm_studentfeedback" OnClick="fnStudentFeedback" />
                            </div>
                        </div>
                    </div>
                </div>


                <div runat="server" id="students_feedback" style="width: 100%; margin-top: 5px;">
                </div>

            </div>

            <div class="bm_academic_grid_container" id="Div3" runat="server" style="margin-top: 40px">
                <div class="grid_header">
                    <div class="grid_header_label" id="Div4" runat="server" style="font-size: 16px; vertical-align: central;">
                        Teachers' Feedback
                    </div>
                    <div class="grid_header_control" style="background-color: #5087c7;">
                    </div>
                    <div class="flot_right">
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label10" runat="server" Text="Session " AssociatedControlID="xsession2"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xsession2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px; width: 122px">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label11" runat="server" Text="Term " AssociatedControlID="xterm2" CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xterm2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label12" runat="server" Text="Class " AssociatedControlID="xclass2"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xclass2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px; display: none">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label13" runat="server" Text="Group " AssociatedControlID="xgroup2"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xgroup2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px; margin-right: 10px;">
                            <div class="bm_ctl_label_align_right_100_special">
                                <asp:Label ID="Label14" runat="server" Text="Section " AssociatedControlID="xsection2"
                                    CssClass="label"></asp:Label>
                            </div>
                            <div class="bm_clt_ctl_100_special">
                                <asp:DropDownList ID="xsection2" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px; margin-right: 20px;">
                            <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/reload70.png"
                                    Width="25px" Height="25px" CssClass="bm_academic_button_zoom bm_teacherfeedback" OnClick="fnTeacherFeedback" />
                            </div>
                        </div>
                    </div>
                </div>


                <div runat="server" id="teachers_feedback" style="width: 100%; margin-top: 5px;">
                </div>

            </div>


            <asp:Button ID="btnClose" runat="server" Style="display: none" OnClick="btnClose_OnClick" />


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hxsubject" runat="server" />
                    <asp:HiddenField ID="hxpaper" runat="server" />
                    <asp:HiddenField ID="hxext" runat="server" />
                    <asp:HiddenField ID="hdxsubject" runat="server" />
                    <asp:HiddenField ID="hxclass" runat="server" />
                    <asp:HiddenField ID="hxsection" runat="server" />

                    <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="fnLoadFiles" CssClass="disnone" />--%>

                    <input id="Button1" type="button" value="button" runat="server" onserverclick="fnLoadFiles" class="disnone" />


                    <div id="myModal" class="modalwin" runat="server">

                        <!-- Modal content -->
                        <div class="modal-content" style="border: 2px solid #72bf44; background-color: #eef6e8">
                            <div class="modal-header" style="background-color: #72bf44;">
                                <span class="close">&times;</span>
                                <h2 style="color: #fff;">Students' Feedback</h2>
                            </div>

                            <div class="modal-body">



                                <div id="_left" style="background-color: #c5de92; width: 100%; vertical-align: top;">
                                    <div style="padding-left: 10px; padding-left: 10px; padding-right: 10px; padding-top: 5px; padding-bottom: 10px; width: 100%; position: relative;">

                                        <%-- <div style="display: inline-block"></div> --%>
                                        <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                            Session :
                            
                                        </div>--%>

                                        <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                            Session :
                            
                                        </div>


                                        <div style="display: inline-block;  color: #000000; padding-right: 15px;">

                                            <div id="xsession_dw" runat="server">
                                                New
                                            </div>
                                        </div>

                                        <%-- <div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                            Term :
                            
                                        </div>--%>

                                        <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                            Term :
                            
                                        </div>


                                        <div style="display: inline-block;  color: #000000; padding-right: 15px;">

                                            <div id="xterm_dw" runat="server">
                                                New
                                            </div>
                                        </div>

                                        <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                            Class :
                            
                                        </div>--%>

                                        <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                            Class :
                            
                                        </div>

                                        <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                            <div id="xclass_dw" runat="server">
                                                New
                                            </div>
                                        </div>

                                        <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                            Section :
                            
                                        </div>--%>

                                        <div style="display: inline-block; color: #000000; text-align: right; padding-right: 5px;">
                                            Section :
                            
                                        </div>

                                        <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                            <div id="xsection_dw" runat="server">
                                                New
                                            </div>
                                        </div>

                                        <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                            Subject :
                            
                                        </div>--%>

                                        <div style="display: inline-block; color: #000000; text-align: right; padding-right: 5px;">
                                            Subject :
                            
                                        </div>


                                        <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                            <div id="xsubject_dw" runat="server">
                                                New
                                            </div>
                                        </div>



                                        <div style="display: none; right: 10px; position: absolute;">
                                            <input type="button" id="btnClear" value="Clear" class="bm_academic_button3 bm_am_btn_clear" />
                                        </div>
                                    </div>
                                </div>


                                <div class="bm_academic_container_message">
                                    <div class="message" id="message1" runat="server">
                                    </div>
                                </div>

                                <div id="_right" runat="server" style="width: 100%; height: 100%; vertical-align: top;">

                                    <div style="padding: 10px; width: 100%; height: 100%;">
                                        <div style="display: inline-block; width: 100%; height: 100%; vertical-align: top;">

                                            <%-- <div style="font-size: 20px; width: 100%; vertical-align: top; padding-left: 10px; padding-top: 3px; color: #000; border-bottom: 2px solid #000">
                                                Download files from here
                                            </div>--%>
                                            <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                                                <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="_soterd"></div>
                                            </div>
                                            <div style="width: 100%; overflow-y: auto; height: 100%; vertical-align: top;" runat="server" id="_storeddiv">
                                            </div>
                                        </div>




                                    </div>
                                </div>


                            </div>
                        </div>



                    </div>



                    <script>
                        $("body").on("click", ".bm_am_btn_clear", function () {

          
                            $("#<%= message1.ClientID %>").empty();

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

                            $("#<%= btnClose.ClientID%>").click();


                            $("#<%= message.ClientID %>").empty();
                        });

                        var openwin;
                        function fnOpenStudentFeedback(xsubject,xpaper,xext,xclass,xsection) {
                            //alert("Hi");
                            //alert(xclass);
                            var zid = <%= HttpContext.Current.Session["business"] %>;
                        
                            var xsession123 = $("#<%= xsession1.ClientID%>").val();
                            var xterm123 = $("#<%= xterm1.ClientID%>").val();
                    
                            $("#<%= hxclass.ClientID%>").val(xclass);
                            $("#<%= hxsection.ClientID%>").val(xsection);
                            $("#<%= hxsubject.ClientID%>").val(xsubject);
                            $("#<%= hxpaper.ClientID%>").val(xpaper);
                            $("#<%= hxext.ClientID%>").val(xext);

                            if (xpaper != "")
                            {
                                //document.getElementById("xsubject_dw").innerHTML = xsubject + " - " + xpaper;
                                $("#<%= hdxsubject.ClientID%>").val(xsubject + " - " + xpaper);
                            }
                            else if (xext != "")
                            {
                                //document.getElementById("xsubject_dw").innerHTML = xsubject + " - " + xext;
                                $("#<%= hdxsubject.ClientID%>").val(xsubject + " - " + xext);
                            }
                            else
                            {
                                //document.getElementById("xsubject_dw").innerHTML = xsubject;
                                $("#<%= hdxsubject.ClientID%>").val(xsubject);
                            }

                            //$find('modalpopup').show();
                        $("#<%= message.ClientID %>").empty();
                            $("#<%= message1.ClientID %>").empty();

                            if ($("#<%= hxsubject.ClientID%>").val() != "") {
                                $("#<%= Button1.ClientID%>").click();
                            }
           
                            return false;
                        }

                        ////$("[id*=_link]").live("click", function () {
                        $("body").on("click", "[id*=_link1]", function () {
                            //$("[id*=Button1]").click();
                            //alert(this.id);

                            var xparam = this.id.split("|");
                            //alert(xparam[1]);

                            var zid1 = <%= HttpContext.Current.Session["business"] %>;
                            var xsession123 = $("#<%= xsession1.ClientID%>").val();
                            var xterm123 = $("#<%= xterm1.ClientID%>").val();
                            var xclass123 = $("#<%= xclass1.ClientID%>").val();
                            var xsection123 = $("#<%= xsection1.ClientID%>").val();
                            var xsubject123 =  $("#<%= hxsubject.ClientID%>").val();
                            var xpaper123 = $("#<%= hxpaper.ClientID%>").val();
                            var xext123 = $("#<%= hxext.ClientID%>").val();
                            var xrow123 = xparam[1];
                            var xreff123 = xparam[2];
                            var xwsno123 = xparam[3];

                            //alert(xsubject123);

                            $.ajax({
                                url: "amworksheetteacher.aspx/fnInsert",

                                type: "POST",

                                data: "{'zid9' :'" + zid1 + "', 'xsession9' :'" + xsession123 + "','xterm9':'" + xterm123 + "','xclass9':'"+xclass123+"', 'xsection9': '"+xsection123+"', 'xsubject9' : '"+xsubject123+"', 'xpaper9': '"+xpaper123+"', 'xext9': '"+xext123+"', 'xref9':'"+xrow123+"', 'xreff9': '"+xreff123+"', 'xwsno9' : '"+xwsno123+"'}",

                                //dataType: "json",
                                contentType: "application/json; charset=utf-8",

                                async: false,
                                success: function (res) {

                                    var r = res.d;
                                    if (r != "success") {
                                        alert(r);
                                    }
                                },
                                error: function (err) {
                                    alert("ERROR : " + err);
                                }
                            });



                        });


                    </script>



                </ContentTemplate>
            </asp:UpdatePanel>


            <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>


            <%-- <input type =hidden name ="__EVENTTARGET" value ="">  
    <input type =hidden name ="__EVENTARGUMENT" value ="">--%>

            <asp:HiddenField ID="hxsubject1" runat="server" />
            <asp:HiddenField ID="hxpaper1" runat="server" />
            <asp:HiddenField ID="hxext1" runat="server" />
            <asp:HiddenField ID="hdxsubject1" runat="server" />
            <asp:HiddenField ID="hxclass1" runat="server" />
            <asp:HiddenField ID="hxsection1" runat="server" />

            <%--<input id="Button2" type="button" value="button" runat="server" onserverclick="fnLoadFiles1" class="disnone" />--%>
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="fnLoadFiles1" CssClass="disnone" />

            <div id="myModal1" class="modalwin" runat="server">
                <!-- Modal content -->
                <div class="modal-content" style="border: 2px solid #5078c7;">
                    <div class="modal-header" style="background-color: #5078c7;">
                        <span class="close">&times;</span>
                        <h2 style="color: #fff">Teachers' Feedback</h2>
                    </div>

                    <div class="modal-body">



                        <div id="_left" style="background-color: #a3b4d6; width: 100%; vertical-align: top;">
                            <div style="padding-left: 10px; padding-left: 10px; padding-right: 10px; padding-top: 5px; padding-bottom: 10px; width: 100%; position: relative;">

                                <%-- <div style="display: inline-block"></div> --%>
                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Session :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                    Session :
                            
                                </div>


                                <div style="display: inline-block;  color: #000000; padding-right: 15px;">

                                    <div id="xsession_ph" runat="server">
                                        New
                                    </div>
                                </div>

                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Term :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                    Term :
                            
                                </div>


                                <div style="display: inline-block;  color: #000000; padding-right: 15px;">

                                    <div id="xterm_ph" runat="server">
                                        New
                                    </div>
                                </div>

                                <%-- <div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Class :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                    Class :
                            
                                </div>


                                <div style="display: inline-block;  color: #000000; padding-right: 15px;">

                                    <div id="xclass_ph" runat="server">
                                        New
                                    </div>
                                </div>

                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Section :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                    Section :
                            
                                </div>


                                <div style="display: inline-block;  color: #000000; padding-right: 15px;">

                                    <div id="xsection_ph" runat="server">
                                        New
                                    </div>
                                </div>

                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Subject :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right; padding-right: 5px;">
                                    Subject :
                            
                                </div>


                                <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                    <div id="xsubject_ph" runat="server">
                                        New
                                    </div>
                                </div>



                                <div style="display: none; right: 10px; position: absolute;">
                                    <input type="button" id="btnClear1" value="Clear" class="bm_academic_button3 bm_am_btn_clear1" />
                                </div>
                            </div>
                        </div>

                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <script>
                                
                                    function fnPageLoad() {

                                        $( ".draggable" ).draggable();
                                    }


                                    $(document).ready(function () {

                   

                                        var prm = Sys.WebForms.PageRequestManager.getInstance();
                                        prm.add_endRequest(function () {
                                            fnPageLoad();
                                        });

                                    });
                                </script>

                                <asp:Button ID="Button3" runat="server" Text="Button" OnClick="fnLoadFiles2" CssClass="disnone" />
                                <%--<asp:LinkButton ID="Button3" ClientIDMode="Static" runat="Server" Text="Link Button" CausesValidation="false" OnClick="fnLoadFiles2" CssClass="disnone" >LinkButton</asp:LinkButton>--%>

                                <div class="bm_academic_container_message">
                                    <div class="message" id="message2" runat="server">
                                    </div>
                                </div>

                                <div id="Div9" runat="server" style="width: 100%; height: 100%; vertical-align: top;">

                                    <div style="padding: 0px; width: 100%; height: 100%;">
                                        <%-- <div style="display: inline-block; width: 100%; height: 100%; vertical-align: top;">

                                        <div style="font-size: 20px; width: 100%; vertical-align: top; padding-left: 10px; padding-top: 3px; color: #000; border-bottom: 2px solid #000">
                                            Download files from here
                                        </div>
                                        <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                                            <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="Div10"></div>
                                        </div>
                                        <div style="width: 100%; overflow-y: auto; height: 100%; vertical-align: top;" runat="server" id="Div11">
                                        </div>
                                    </div>--%>

                                        <div style="display: inline-block; width: 55%; height: 500px; vertical-align: top; background-color: #EEF6E8;">

                                            <div style="font-size: 20px; width: 100%; vertical-align: top; padding-left: 10px; padding-top: 3px; color: #000; background-color: #dce9a4; text-align: center;">
                                                Pending Homeworks To Check And Feedback
                                            </div>
                                            <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                                                <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="_pendinghw"></div>
                                                <%--<asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="bm_academic_button3 bm_am_btn_remove"
                                                OnClick="btnRemove_OnClick" />
                                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="bm_academic_button3 bm_am_btn_Send"
                                                OnClick="btnSend_OnClick" />--%>
                                            </div>
                                            <div style="width: 100%; overflow-y: auto; height: 420px; vertical-align: top; padding-left: 10px; padding-right: 10px;" runat="server" id="_pending">

                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound">
                                                    <%--OnRowCommand="GridView1_RowCommand"--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL" ItemStyle-Width="35px" HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="xwsno" HeaderText="No." ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                        <%--<asp:BoundField DataField="xfile_ref" HeaderText="Worksheet/File Name" ItemStyle-Width="250px" HeaderStyle-Width="250px"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="pad5" />--%>
                                                        
                                                         <asp:TemplateField HeaderText="Worksheet/File Name" ItemStyle-Width="200px" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <div style="word-break: break-all; width: 200px; padding-left: 2px;">
                                                                <%# Eval("xfile_ref") %>
                                                                </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Browse File" ItemStyle-Width="150px" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:FileUpload ID="xlink_phw" runat="server" EnableViewState="True" Width="148px" />
                                                                <%-- <cc1:AsyncFileUpload ID="xlink_phw" runat="server" Width="198px" />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Note" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <div style="position: relative;">
                                                                    <div>
                                                                        <asp:ImageButton ToolTip="Enter Note" ID="btnNote" runat="server" ImageUrl="~/images/red_button.jpg" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="btnNote_OnClick" />
                                                                    </div>
                                                                    <div style="position: absolute; z-index: 20000; right: 20px;">
                                                                        <div class="draggable">
                                                                            <asp:Panel ID="pnlnote" runat="server" Visible="False" BackColor="Silver">
                                                                                <div style="padding: 5px;">
                                                                                    <asp:Label ID="Label6" runat="server" Text="Note"></asp:Label>
                                                                                    <asp:TextBox ID="txtnote" runat="server" TextMode="MultiLine"> </asp:TextBox>
                                                                                    <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_OnClick" />
                                                                                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_OnClick1" />
                                                                                </div>
                                                                            </asp:Panel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Submit" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ToolTip="Submit file" ID="imgbtn" runat="server" ImageUrl="~/images/send_icon64x64.png" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="ImgbtnOnClick" />
                                                                <%--CommandName="Upload"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--<asp:BoundField DataField="xrow" HeaderText="" ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone"  FooterStyle-CssClass="disnone"/>--%>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xrow" runat="server" Text='<%# Eval("xrow") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xreff" runat="server" Text='<%# Eval("xreff") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xwsno1" runat="server" Text='<%# Eval("xwsno1")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </div>

                                        <div style="display: inline-block; width: 44%; height: 500px; padding-left: 0px; background-color: #EEF6E8; margin-left: 5px;">


                                            <div style="font-size: 20px; width: 100%; padding-left: 0px; vertical-align: top; padding-top: 3px; color: #000; background-color: #dce9a4; text-align: center;">
                                                Submitted Feedback
                                            </div>
                                            <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                                                <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="_send"></div>
                                                <%--   <asp:Button ID="btnRemove1" runat="server" Text="Return" CssClass="bm_academic_button3 bm_am_btn_remove1"
                                                OnClick="btnRemove1_OnClick" />--%>
                                            </div>
                                            <div style="width: 100%; overflow-y: auto; height: 500px; vertical-align: top; padding-left: 10px; padding-right: 10px;" runat="server" id="_senddiv">
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound1">
                                                    <%--OnRowDataBound="OnRowDataBound1"--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL" ItemStyle-Width="35px" HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1%>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="xwsno" HeaderText="No." ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                        <asp:TemplateField HeaderText="Worksheet/File" ItemStyle-Width="200px" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <div style="word-break: break-all; width: 200px; padding-left: 2px;">
                                                                <a href='<%# Eval("xlink_f1")%>' download='<%# Eval("xfile")%>'><%# Eval("xfile")%> </a>
                                                                    </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="xdatesend1" HeaderText="Date" ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" DataFormatString="{0:dd/MM/yyyy}" />

                                                        <asp:TemplateField HeaderText="Note" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <div style="position: relative;">
                                                                    <div>
                                                                        <asp:ImageButton ToolTip="Enter Note" ID="btnNote" runat="server" ImageUrl="~/images/red_button.jpg" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="btnNote_OnClick1" />
                                                                    </div>
                                                                    <div style="position: absolute; z-index: 20000; right: 20px;">
                                                                        <div class="draggable">
                                                                            <asp:Panel ID="pnlnote" runat="server" Visible="False" BackColor="Silver">
                                                                                <div style="padding: 5px;">
                                                                                    <asp:Label ID="Label6" runat="server" Text="Note"></asp:Label>
                                                                                    <asp:TextBox ID="txtnote" runat="server" TextMode="MultiLine"> </asp:TextBox>
                                                                                    <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_OnClick1" />
                                                                                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_OnClick11" />
                                                                                </div>
                                                                            </asp:Panel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ToolTip="Delete file" ID="imgbtn" runat="server" ImageUrl="~/images/delete_icon64x64.png" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="ImgbtndeleteOnClick" />
                                                                <%--CommandName="Upload"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xrow" runat="server" Text='<%# Eval("xrow")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xlink" runat="server" Text='<%# Eval("xlink")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                                <script>
                                    function fnSubmitHW(xrow,_rowindex) {
                                        //alert(_rowindex);
                                        //return;
                                        //alert("hi");
                                        // alert($("#<%= hxsubject1.ClientID%>").val());

                                        $("#<%= message.ClientID%>").empty();
                                        $("#<%= message2.ClientID%>").empty();

                                            

                                        var grid = document.getElementById('<%=GridView1.ClientID%>');
                                        var filename = grid.rows[parseInt(_rowindex)+1].cells[6].children[0].value;
                                        //alert(filename);

                                        if (filename == "text") {
                                            alert("Please select a file for submit.");

                                        } else {
                                            $.ajax({
                                                url: "amworksheetstudent.aspx/fnUpdate",

                                                type: "POST",

                                                data: "{'xrow123' :'" + xrow + "', 'xfilename123' :'" + filename + "'}",

                                                //dataType: "json",
                                                contentType: "application/json; charset=utf-8",

                                                async: false,
                                                success: function (res) {

                                                    var r = res.d;
                                                    if (r != "success") {
                                                        alert(r);
                                                    }
                                                },
                                                error: function (err) {
                                                    alert("ERROR : " + err);
                                                }
                                            });
                                            
                                        }

                                            


                        
                                        <%--$("#<%= Button3.ClientID%>").click();--%>
                                            <%-- document.getElementById("<%= Button3.ClientID%>").click();--%>

                                            
                                        __doPostBack("<%=Button3.UniqueID%>", "");
                                       

                                        return false;
                                    }

                                    <%--                                        $("body").on("change", "[id*=xlink_phw]", function () {

                                             //alert("hi");
                                            var path = $(this).val();
                                            if (path != '' && path != null) {
                                                //var q = path.substring(path.lastIndexOf('\\') + 1);
                                                var row = this.parentNode.parentNode;;
                                                var _rowindex = row.rowIndex - 1;

                                                var grid = document.getElementById('<%=GridView1.ClientID %>');
                                                //alert(_rowindex);
                                                grid.rows[_rowindex+1].cells[6].children[0].value = path;
                                                //alert(grid.rows[_rowindex+1].cells[6].children[0].id);
                                                //alert(grid.rows[_rowindex + 1].cells[6].children[0].value);

                                            }

                                             return false;
                                         });--%>

                                </script>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                                <%--   <asp:PostBackTrigger ControlID="GridView1" /> --%>
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>

            <script>
                $("body").on("click", ".bm_am_btn_clear1", function () {

          
                    $("#<%= message2.ClientID%>").empty();

                    return false;
                });

                // Get the modal
                //var modal = document.getElementById("myModal");

                var modal = document.getElementById("<%= myModal1.ClientID%>");

                // Get the button that opens the modal
                var btn = document.getElementById("myBtn");

                // Get the <span> element that closes the modal
                var span = document.getElementsByClassName("close")[0];

                //// When the user clicks the button, open the modal 
                //btn.onclick = function() {
                //    modal.style.display = "block";
                //}

                // When the user clicks on <span> (x), close the modal
                //document.getElementsByClassName("close")[0].onclick = function() {
                //    modal.style.display = "none";
                //}


                $("body").on("click", ".close", function () {

          
                    document.getElementById("<%= myModal1.ClientID%>").style.display = "none";
                    document.getElementById("<%= hxsubject1.ClientID%>").value = "";
                    document.getElementById("<%= hxpaper1.ClientID%>").value = "";
                    document.getElementById("<%= hxext1.ClientID%>").value = "";

                    $("#<%= btnClose.ClientID%>").click();

                    $("#<%= message.ClientID%>").empty();

                });


                //// When the user clicks anywhere outside of the modal, close it
                //window.onclick = function(event) {
                //    if (event.target == document.getElementById("myModal")) {
                //        document.getElementById("myModal").style.display = "none";
                //    }
                //}

                var openwin1;
                function fnOpenStudentFeedback1(xsubject,xpaper,xext,xclass,xsection) {
                    //alert("Hi");
                    //alert(xclass);
                    var zid = <%= HttpContext.Current.Session["business"]%>;

                    var xsession123 = $("#<%= xsession2.ClientID%>").val();
                    var xterm123 = $("#<%= xterm2.ClientID%>").val();
                       
                    $("#<%= hxclass1.ClientID%>").val(xclass);
                    $("#<%= hxsection1.ClientID%>").val(xsection);
                    $("#<%= hxsubject1.ClientID%>").val(xsubject);
                    $("#<%= hxpaper1.ClientID%>").val(xpaper);
                    $("#<%= hxext1.ClientID%>").val(xext);

                    if (xpaper != "")
                    {
                           
                        $("#<%= hdxsubject1.ClientID%>").val(xsubject + " - " + xpaper);
                    }
                    else if (xext != "")
                    {
               
                        $("#<%= hdxsubject1.ClientID%>").val(xsubject + " - " + xext);
                    }
                    else
                    {
           
                        $("#<%= hdxsubject1.ClientID%>").val(xsubject);
                    }

                    //$find('modalpopup').show();
                $("#<%= message.ClientID%>").empty();
                    $("#<%= message2.ClientID%>").empty();

                       
                    $("#<%= Button2.ClientID%>").click();
            
           
                       
           

                    return false;
                }

                   


                $("body").on("click", "[id*=_link2]", function () {
                       

                    <%-- var xparam = this.id.split("|");
                        

                        var zid1 = <%= HttpContext.Current.Session["business"] %>;
            var xsession123 = $("#<%= xsession.ClientID%>").val();
            var xterm123 = $("#<%= xterm.ClientID%>").val();
            var xclass123 = $("#<%= hxclass.ClientID%>").val();
            var xsection123 = $("#<%= hxsection.ClientID%>").val();
            var xsubject123 =  $("#<%= hxsubject.ClientID%>").val();
            var xpaper123 = $("#<%= hxpaper.ClientID%>").val();
            var xext123 = $("#<%= hxext.ClientID%>").val();
            var xrow123 = xparam[1];--%>

            

                    //    $.ajax({
                    //        url: "amworksheetstudent.aspx/fnInsert",

                    //        type: "POST",

                    //        data: "{'zid9' :'" + zid1 + "', 'xsession9' :'" + xsession123 + "','xterm9':'" + xterm123 + "','xclass9':'"+xclass123+"', 'xsection9': '"+xsection123+"', 'xsubject9' : '"+xsubject123+"', 'xpaper9': '"+xpaper123+"', 'xext9': '"+xext123+"', 'xref9':'"+xrow123+"'}",

                    //        //dataType: "json",
                    //        contentType: "application/json; charset=utf-8",

                    //        async: false,
                    //        success: function (res) {

                    //            var r = res.d;
                    //            if (r != "success") {
                    //                alert(r);
                    //            }
                    //        },
                    //        error: function (err) {
                    //            alert("ERROR : " + err);
                    //        }
                    //    });



                });

                //function __doPostBack(eventTarget, eventArgument)  
                //{  
                //    document.Form1.__EVENTTARGET.value = eventTarget;   
                //    document.Form1.__EVENTARGUMENT.value = eventArgument;  
                //    document.Form1.submit();   
                //}
            </script>


            <%--</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>--%>

            <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>


            <%-- <input type =hidden name ="__EVENTTARGET" value ="">  
    <input type =hidden name ="__EVENTARGUMENT" value ="">--%>

            <asp:HiddenField ID="hxsubject3" runat="server" />
            <asp:HiddenField ID="hxpaper3" runat="server" />
            <asp:HiddenField ID="hxext3" runat="server" />
            <asp:HiddenField ID="hdxsubject3" runat="server" />
            <asp:HiddenField ID="hxclass3" runat="server" />
            <asp:HiddenField ID="hxsection3" runat="server" />

            <%--<input id="Button2" type="button" value="button" runat="server" onserverclick="fnLoadFiles1" class="disnone" />--%>
            <asp:Button ID="Button6" runat="server" Text="Button" OnClick="fnLoadFiles6" CssClass="disnone" />

            <div id="myModal2" class="modalwin" runat="server">
                <!-- Modal content -->
                <div class="modal-content" style="border: 2px solid #5078c7;">
                    <div class="modal-header" style="background-color: #5078c7;">
                        <span class="close">&times;</span>
                        <h2 style="color: #fff">Upload Homeworks</h2>
                    </div>

                    <div class="modal-body">



                        <div id="_left" style="background-color: #a3b4d6; width: 100%; vertical-align: top;">
                            <div style="padding-left: 10px; padding-left: 10px; padding-right: 10px; padding-top: 5px; padding-bottom: 10px; width: 100%; position: relative;">

                                <%-- <div style="display: inline-block"></div> --%>
                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Session :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right;  padding-right: 5px;">
                                    Session :
                            
                                </div>


                                <div style="display: inline-block;  color: #000000; padding-right: 15px;">

                                    <div id="xsession3" runat="server">
                                        New
                                    </div>
                                </div>

                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Term :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right; padding-right: 5px;">
                                    Term :
                            
                                </div>


                                <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                    <div id="xterm3" runat="server">
                                        New
                                    </div>
                                </div>

                                <%-- <div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Class :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right; padding-right: 5px;">
                                    Class :
                            
                                </div>


                                <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                    <div id="xclass3" runat="server">
                                        New
                                    </div>
                                </div>

                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Section :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right; padding-right: 5px;">
                                    Section :
                            
                                </div>


                                <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                    <div id="xsection3" runat="server">
                                        New
                                    </div>
                                </div>

                                <%--<div style="display: inline-block; background-color: #C7EBFC; color: #000000; border: solid 1px #BFBEBC; border-radius: 4px; text-align: right; padding-right: 5px; font-family: Myriad Pro,tahoma; height: 25px; line-height: 1.5em; width: 70px;">
                                    Subject :
                            
                                </div>--%>

                                <div style="display: inline-block; color: #000000; text-align: right; padding-right: 5px;">
                                    Subject :
                            
                                </div>


                                <div style="display: inline-block; color: #000000; padding-right: 15px;">

                                    <div id="xsubject3" runat="server">
                                        New
                                    </div>
                                </div>



                                <div style="display: none; right: 10px; position: absolute;">
                                    <input type="button" id="btnClear1" value="Clear" class="bm_academic_button3 bm_am_btn_clear1" />
                                </div>
                            </div>
                        </div>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <script>
                                
                                    function fnPageLoad() {

                                        $( ".draggable" ).draggable();
                                    }


                                    $(document).ready(function () {

                   

                                        var prm = Sys.WebForms.PageRequestManager.getInstance();
                                        prm.add_endRequest(function () {
                                            fnPageLoad();
                                        });

                                    });
                                </script>

                                <asp:Button ID="Button5" runat="server" Text="Button" OnClick="fnLoadFiles5" CssClass="disnone" />
                                <%--<asp:LinkButton ID="Button3" ClientIDMode="Static" runat="Server" Text="Link Button" CausesValidation="false" OnClick="fnLoadFiles2" CssClass="disnone" >LinkButton</asp:LinkButton>--%>

                                <div class="bm_academic_container_message">
                                    <div class="message" id="message3" runat="server">
                                    </div>
                                </div>

                                <div id="Div13" runat="server" style="width: 100%; height: 100%; vertical-align: top;">

                                    <div style="padding: 0px; width: 100%; height: 100%;">
                                        <%-- <div style="display: inline-block; width: 100%; height: 100%; vertical-align: top;">

                                        <div style="font-size: 20px; width: 100%; vertical-align: top; padding-left: 10px; padding-top: 3px; color: #000; border-bottom: 2px solid #000">
                                            Download files from here
                                        </div>
                                        <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                                            <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="Div10"></div>
                                        </div>
                                        <div style="width: 100%; overflow-y: auto; height: 100%; vertical-align: top;" runat="server" id="Div11">
                                        </div>
                                    </div>--%>

                                        <div style="display: inline-block; width: 50%; height: 500px; vertical-align: top; background-color: #EEF6E8;">

                                            <div style="font-size: 20px; width: 100%; vertical-align: top; padding-left: 10px; padding-top: 3px; color: #000; background-color: #dce9a4; text-align: center;">
                                                Stored Worksheets/Files
                                            </div>

                                            <div style="padding-left: 10px; margin-top: 10px;font-size: 14px; margin-bottom: 0px;color: #000;">
                                                <div style="float: left; width: 80px; ">Select a file</div>
                                                <div style="float: left; padding-left: 5px;padding-right: 5px;">:</div>
                                                <div id="Div5" runat="server" style="float: left; padding-right: 10px;">
                                                    <asp:FileUpload ID="xlink" runat="server" Width="320px" BackColor="white" BorderColor="black" BorderStyle="Solid" BorderWidth="1"/>
                                                </div>
                                                 <div id="Div6" runat="server" style="float: left; padding-left: 0px; padding-top: 1px;">
                                                     <asp:Button ID="btnUpload" Width="50px" runat="server" Text="OK" CssClass="bm_academic_button bm_am_btn_upload" OnClick="btnUpload_OnClick"/>
                                                </div>
                                            </div>

                                            <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px; clear: both;">
                                                <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="_uploaddiv"></div>
                                                <%--<asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="bm_academic_button3 bm_am_btn_remove"
                                                OnClick="btnRemove_OnClick" />
                                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="bm_academic_button3 bm_am_btn_Send"
                                                OnClick="btnSend_OnClick" />--%>
                                            </div>
                                            <div style="width: 100%; overflow-y: auto; height: 420px; vertical-align: top; padding-left: 10px; padding-right: 10px; padding-top: 3px;" runat="server" id="_upload">

                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound4">
                                                    <%--OnRowCommand="GridView1_RowCommand"--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL" ItemStyle-Width="35px" HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="xwsno" HeaderText="No." ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                       <%-- <asp:BoundField DataField="xfile_ref" HeaderText="Worksheet/File Name" ItemStyle-Width="300px" HeaderStyle-Width="300px"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="pad5" />--%>
                                                        
                                                         <asp:TemplateField HeaderText="Worksheet/File" ItemStyle-Width="200px" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <div style="word-break: break-all; width: 200px;">
                                                                <a href='<%# Eval("xlink_f1")%>' download='<%# Eval("xfile")%>'><%# Eval("xfile")%> </a>
                                                                    </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Note" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <div style="position: relative;">
                                                                    <div>
                                                                        <asp:ImageButton ToolTip="Enter Note" ID="btnNote" runat="server" ImageUrl="~/images/red_button.jpg" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="btnNote_OnClick2" />
                                                                    </div>
                                                                    <div style="position: absolute; z-index: 20000; right: 20px;">
                                                                        <div class="draggable">
                                                                            <asp:Panel ID="pnlnote" runat="server" Visible="False" BackColor="Silver">
                                                                                <div style="padding: 5px;">
                                                                                    <asp:Label ID="Label6" runat="server" Font-Size="10" Text="Note"></asp:Label>
                                                                                    <asp:TextBox ID="txtnote" runat="server" TextMode="MultiLine"> </asp:TextBox>
                                                                                    <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_OnClick2" />
                                                                                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_OnClick2" />
                                                                                </div>
                                                                            </asp:Panel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="xdate" HeaderText="Date" ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" DataFormatString="{0:dd/MM/yyyy}" />

                                                        <asp:TemplateField HeaderText="Upload" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ToolTip="Upload file" ID="imgbtn" runat="server" ImageUrl="~/images/send_icon64x64.png" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="ImgbtnOnClick1" />
                                                                <%--CommandName="Upload"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ToolTip="Delete file" ID="imgbtn2" runat="server" ImageUrl="~/images/delete_icon64x64.png" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="ImgbtndeleteOnClick1" />
                                                                <%--CommandName="Upload"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--<asp:BoundField DataField="xrow" HeaderText="" ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone"  FooterStyle-CssClass="disnone"/>--%>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xrow" runat="server" Text='<%# Eval("xrow") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--<asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xreff" runat="server" Text='<%# Eval("xreff") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xwsno1" runat="server" Text='<%# Eval("xwsno1")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                         <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xlink" runat="server" Text='<%# Eval("xlink")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </div>

                                        <div style="display: inline-block; width: 49%; height: 500px; padding-left: 0px; background-color: #EEF6E8; margin-left: 5px;">


                                            <div style="font-size: 20px; width: 100%; padding-left: 0px; vertical-align: top; padding-top: 3px; color: #000; background-color: #dce9a4; text-align: center;">
                                                Uploaded Worksheet/Files
                                            </div>
                                            <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                                                <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="_uploaddiv1"></div>
                                                <%--   <asp:Button ID="btnRemove1" runat="server" Text="Return" CssClass="bm_academic_button3 bm_am_btn_remove1"
                                                OnClick="btnRemove1_OnClick" />--%>
                                            </div>
                                            <div style="width: 100%; overflow-y: auto; height: 500px; vertical-align: top; padding-left: 10px; padding-right: 10px; padding-top: 36px;" runat="server" id="Div17">
                                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound5">
                                                    <%--OnRowDataBound="OnRowDataBound1"--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL" ItemStyle-Width="35px" HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1%>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="xwsno" HeaderText="No." ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" />

                                                        <asp:TemplateField HeaderText="Worksheet/File" ItemStyle-Width="300px" HeaderStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                 <div style="word-break: break-all; width: 200px;">
                                                                <a href='<%# Eval("xlink_f1")%>' download='<%# Eval("xfile")%>'><%# Eval("xfile")%> </a>
                                                                     </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="xdatesend" HeaderText="Date" ItemStyle-Width="50px" HeaderStyle-Width="50px"
                                                            ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="pad5" DataFormatString="{0:dd/MM/yyyy}" />

                                                        <asp:TemplateField HeaderText="Note" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <div style="position: relative;">
                                                                    <div>
                                                                        <asp:ImageButton ToolTip="Enter Note" ID="btnNote" runat="server" ImageUrl="~/images/red_button.jpg" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="btnNote_OnClick3" />
                                                                    </div>
                                                                    <div style="position: absolute; z-index: 20000; right: 20px;">
                                                                        <div class="draggable">
                                                                            <asp:Panel ID="pnlnote" runat="server" Visible="False" BackColor="Silver">
                                                                                <div style="padding: 5px;">
                                                                                    <asp:Label ID="Label6" runat="server" Text="Note"></asp:Label>
                                                                                    <asp:TextBox ID="txtnote" runat="server" TextMode="MultiLine"> </asp:TextBox>
                                                                                    <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_OnClick3" />
                                                                                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_OnClick3" />
                                                                                </div>
                                                                            </asp:Panel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Return" ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ToolTip="Return file" ID="imgbtn1" runat="server" ImageUrl="~/images/return_icon.png" Width="20px" Height="20px" CssClass="bm_academic_button_zoom" OnClick="ImgbtndeleteOnClick3" />
                                                                <%--CommandName="Upload"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xrow" runat="server" Text='<%# Eval("xrow")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="disnone" HeaderStyle-CssClass="disnone" FooterStyle-CssClass="disnone">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="xlink" runat="server" Text='<%# Eval("xlink")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                                <script>
                                    function fnSubmitHW(xrow,_rowindex) {
                                        //alert(_rowindex);
                                        //return;
                                        //alert("hi");
                                        // alert($("#<%= hxsubject1.ClientID%>").val());

                                        $("#<%= message.ClientID%>").empty();
                                        $("#<%= message2.ClientID%>").empty();

                                            

                                        var grid = document.getElementById('<%=GridView1.ClientID%>');
                                        var filename = grid.rows[parseInt(_rowindex)+1].cells[6].children[0].value;
                                        //alert(filename);

                                        if (filename == "text") {
                                            alert("Please select a file for submit.");

                                        } else {
                                            $.ajax({
                                                url: "amworksheetstudent.aspx/fnUpdate",

                                                type: "POST",

                                                data: "{'xrow123' :'" + xrow + "', 'xfilename123' :'" + filename + "'}",

                                                //dataType: "json",
                                                contentType: "application/json; charset=utf-8",

                                                async: false,
                                                success: function (res) {

                                                    var r = res.d;
                                                    if (r != "success") {
                                                        alert(r);
                                                    }
                                                },
                                                error: function (err) {
                                                    alert("ERROR : " + err);
                                                }
                                            });
                                            
                                        }

                                            


                        
                                        <%--$("#<%= Button3.ClientID%>").click();--%>
                                            <%-- document.getElementById("<%= Button3.ClientID%>").click();--%>

                                            
                                        __doPostBack("<%=Button3.UniqueID%>", "");
                                       

                                        return false;
                                    }

                                    <%--                                        $("body").on("change", "[id*=xlink_phw]", function () {

                                             //alert("hi");
                                            var path = $(this).val();
                                            if (path != '' && path != null) {
                                                //var q = path.substring(path.lastIndexOf('\\') + 1);
                                                var row = this.parentNode.parentNode;;
                                                var _rowindex = row.rowIndex - 1;

                                                var grid = document.getElementById('<%=GridView1.ClientID %>');
                                                //alert(_rowindex);
                                                grid.rows[_rowindex+1].cells[6].children[0].value = path;
                                                //alert(grid.rows[_rowindex+1].cells[6].children[0].id);
                                                //alert(grid.rows[_rowindex + 1].cells[6].children[0].value);

                                            }

                                             return false;
                                         });--%>

                                </script>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
                                <asp:PostBackTrigger ControlID="btnUpload"/>
                                <%--   <asp:PostBackTrigger ControlID="GridView1" /> --%>
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>

            <script>
                $("body").on("click", ".bm_am_btn_clear1", function () {

          
                    $("#<%= message3.ClientID%>").empty();

                    return false;
                });

                // Get the modal
                //var modal = document.getElementById("myModal");

                var modal = document.getElementById("<%= myModal1.ClientID%>");

                // Get the button that opens the modal
                var btn = document.getElementById("myBtn");

                // Get the <span> element that closes the modal
                var span = document.getElementsByClassName("close")[0];

                //// When the user clicks the button, open the modal 
                //btn.onclick = function() {
                //    modal.style.display = "block";
                //}

                // When the user clicks on <span> (x), close the modal
                //document.getElementsByClassName("close")[0].onclick = function() {
                //    modal.style.display = "none";
                //}


                $("body").on("click", ".close", function () {

          
                    document.getElementById("<%= myModal2.ClientID%>").style.display = "none";
                    document.getElementById("<%= hxsubject3.ClientID%>").value = "";
                    document.getElementById("<%= hxpaper3.ClientID%>").value = "";
                    document.getElementById("<%= hxext3.ClientID%>").value = "";

                    $("#<%= btnClose.ClientID%>").click();

                    $("#<%= message.ClientID%>").empty();

                });


                //// When the user clicks anywhere outside of the modal, close it
                //window.onclick = function(event) {
                //    if (event.target == document.getElementById("myModal")) {
                //        document.getElementById("myModal").style.display = "none";
                //    }
                //}

                var openwin1;
                function fnOpenUpload1(xsubject,xpaper,xext,xclass,xsection) {
                    //alert("Hi");
                    //alert(xclass);
                    var zid = <%= HttpContext.Current.Session["business"]%>;

                    var xsession123 = $("#<%= xsession3.ClientID%>").val();
                    var xterm123 = $("#<%= xterm3.ClientID%>").val();
                       
                    $("#<%= hxclass3.ClientID%>").val(xclass);
                    $("#<%= hxsection3.ClientID%>").val(xsection);
                    $("#<%= hxsubject3.ClientID%>").val(xsubject);
                    $("#<%= hxpaper3.ClientID%>").val(xpaper);
                    $("#<%= hxext3.ClientID%>").val(xext);

                    if (xpaper != "")
                    {
                           
                        $("#<%= hdxsubject3.ClientID%>").val(xsubject + " - " + xpaper);
                    }
                    else if (xext != "")
                    {
               
                        $("#<%= hdxsubject3.ClientID%>").val(xsubject + " - " + xext);
                    }
                    else
                    {
           
                        $("#<%= hdxsubject3.ClientID%>").val(xsubject);
                    }

                    //$find('modalpopup').show();
                $("#<%= message.ClientID%>").empty();
                    $("#<%= message3.ClientID%>").empty();

                       
                    $("#<%= Button6.ClientID%>").click();
            
           
                       
           

                    return false;
                }

                   


                $("body").on("click", "[id*=_link2]", function () {
                       

                    <%-- var xparam = this.id.split("|");
                        

                        var zid1 = <%= HttpContext.Current.Session["business"] %>;
            var xsession123 = $("#<%= xsession.ClientID%>").val();
            var xterm123 = $("#<%= xterm.ClientID%>").val();
            var xclass123 = $("#<%= hxclass.ClientID%>").val();
            var xsection123 = $("#<%= hxsection.ClientID%>").val();
            var xsubject123 =  $("#<%= hxsubject.ClientID%>").val();
            var xpaper123 = $("#<%= hxpaper.ClientID%>").val();
            var xext123 = $("#<%= hxext.ClientID%>").val();
            var xrow123 = xparam[1];--%>

            

                    //    $.ajax({
                    //        url: "amworksheetstudent.aspx/fnInsert",

                    //        type: "POST",

                    //        data: "{'zid9' :'" + zid1 + "', 'xsession9' :'" + xsession123 + "','xterm9':'" + xterm123 + "','xclass9':'"+xclass123+"', 'xsection9': '"+xsection123+"', 'xsubject9' : '"+xsubject123+"', 'xpaper9': '"+xpaper123+"', 'xext9': '"+xext123+"', 'xref9':'"+xrow123+"'}",

                    //        //dataType: "json",
                    //        contentType: "application/json; charset=utf-8",

                    //        async: false,
                    //        success: function (res) {

                    //            var r = res.d;
                    //            if (r != "success") {
                    //                alert(r);
                    //            }
                    //        },
                    //        error: function (err) {
                    //            alert("ERROR : " + err);
                    //        }
                    //    });



                });

                //function __doPostBack(eventTarget, eventArgument)  
                //{  
                //    document.Form1.__EVENTTARGET.value = eventTarget;   
                //    document.Form1.__EVENTARGUMENT.value = eventArgument;  
                //    document.Form1.submit();   
                //}
            </script>


            <%--</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>--%>
        </div>

    </form>
    <%--</div>--%>
</body>
</html>
