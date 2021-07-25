<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="amuploadteacher.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.worksheet.amuploadteacher" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="shortcut icon" type="image/x-icon" href="/images/edusoft.ico" />
    <title>Upload Homeworks</title>
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
        html, body {
            height: 98%;
            margin: 0px;
        }
    </style>

    <script>
        //function OnClose() {

        //    if (window.opener != null && !window.opener.closed) {

        //        window.opener.HideModalDiv();

        //    }

        //}

        //window.onunload = OnClose;

    </script>
</head>
<body>
    <div class="grid_header" style="background-color: #40803C;">
        <div class="grid_header_label" id="_grid_header" runat="server" style="font-size: 20px; line-height: 1.5em; color: #fff; padding-left: 10px;">
            Upload Homeworks
        </div>
    </div>
    <div class="bm_academic_container_message">
        <div class="message" id="message" runat="server">
        </div>
    </div>
    <div style="height: 100%;">
          <form id="form1" runat="server" style="height: 100%; vertical-align: top;">
              
        <div id="_left" style="display: inline-block; background-color: #e1e5e5; width: 400px; height: 100%; vertical-align: top;">
            <div style="padding: 10px;">
                <%--<div style="width: 100%; margin-bottom: 10px; padding-bottom: 3px; color: #000; font-size: 20px; border-bottom: 2px solid #000">
                    Upload Homework
                </div>
                 <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>--%>
                <div class="bm_ctl_container_dynamic_100_80">
                    <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                        <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                            <asp:Label ID="Label13" runat="server" Text="Session :" CssClass="label"></asp:Label>
                        </div>
                    </div>
                    <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label" style="color: #000; font-weight: bold;">
                        <div id="xsession" runat="server">
                            New
                        </div>
                    </div>
                </div>
                <div class="bm_clt_padding">
                </div>
                <div class="bm_ctl_container_dynamic_100_80">
                    <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                        <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                            <asp:Label ID="Label1" runat="server" Text="Term :" CssClass="label"></asp:Label>
                        </div>
                    </div>
                    <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label" style="color: #000;font-weight: bold;">
                        <div id="xterm" runat="server">
                            New
                        </div>
                    </div>
                </div>
                <div class="bm_clt_padding">
                </div>
                <div class="bm_ctl_container_dynamic_100_80">
                    <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                        <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                            <asp:Label ID="Label2" runat="server" Text="Class :" CssClass="label"></asp:Label>
                        </div>
                    </div>
                    <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label" style="color: #000;font-weight: bold;">
                        <div id="xclass" runat="server">
                            New
                        </div>
                    </div>
                </div>
                <div class="bm_clt_padding">
                </div>
                <div class="bm_ctl_container_dynamic_100_80">
                    <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                        <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                            <asp:Label ID="Label3" runat="server" Text="Section :" CssClass="label"></asp:Label>
                        </div>
                    </div>
                    <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label" style="color: #000;font-weight: bold;">
                        <div id="xsection" runat="server">
                            New
                        </div>
                    </div>
                </div>
                <div class="bm_clt_padding">
                </div>
                <div class="bm_ctl_container_dynamic_100_80">
                    <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                        <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                            <asp:Label ID="Label4" runat="server" Text="Subject :" CssClass="label"></asp:Label>
                        </div>
                    </div>
                    <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label" style="color: #000;font-weight: bold;">
                        <div id="xsubject" runat="server">
                            New
                        </div>
                    </div>
                </div>
                <div class="bm_clt_padding">
                </div>
                <div class="bm_ctl_container_dynamic_100_80" style="width: 100%;">
                    <div class="bm_ctl_container_dynamic_100_80_l" style="width: 120px">
                        <div class="bm_ctl_label_align_right_dynamic_100_80_l">
                            <asp:Label ID="Label5" runat="server" Text="Select a file :" CssClass="label"></asp:Label>
                        </div>
                    </div>
                    <div class="bm_clt_ctl_dynamic_100_80 bm_academic_label" style="color: #000;">
                        <%--<input type="file" id="xlink" name="xlink" style="width: 350px;" />--%>
                        <asp:FileUpload ID="xlink" runat="server" Width="350px" />
                    </div>
                </div>
                <div class="bm_clt_padding">
                </div>
                <div style="width: 100%; text-align: left;">
                    <div class="bm_ctl_container_50_50" style="width: 120px; margin-bottom: 10px; margin-right: 10px; float: left;">
                        <div class="bm_ctl_label_align_right_50_50" style="width: 118px">
                            <asp:Label ID="Label14" runat="server" Text="Description :"
                                CssClass="label "></asp:Label>
                        </div>
                    </div>
                    <div style="width: 360px; float: left;">
                        <asp:TextBox ID="xremarks" runat="server" Height="80px" TextMode="MultiLine" CssClass="bm_academic_textbox_50_40 bm_academic_ctl_global bm_academic_text" BorderStyle="Solid" BorderWidth="1px" BorderColor="gray"></asp:TextBox>
                    </div>
                </div>
                <div class="bm_clt_padding">
                </div>
                <div class="bm_clt_padding">
                </div>
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="bm_academic_button3 bm_am_btn_clear"
                    OnClick="btnClear_OnClick" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="bm_academic_button3 bm_am_btn_upload"
                    OnClick="btnUpload_OnClick" />
            </div>
        </div>

        <div id="_right" runat="server" style="display: inline-block; width: 850px; height: 100%; vertical-align: top;">
          




                <div style="padding: 0px; width: 100%; height: 100%;">
                    
                    <div style="display: inline-block; width: 48%; height: 100%; vertical-align: top; padding: 0px 10px;"> <%--background-color: #bff1bd;--%>
                        <%--<div style="font-size: 20px; line-height: 1.5em; background-color: #40803C; color: #fff; width: 100%; padding-left: 10px; vertical-align: top;">
                        Stored files
                    </div>--%>
                        <div style="font-size: 20px; width: 100%; vertical-align: top; padding-left: 10px; padding-top: 3px; color: #000; border-bottom: 2px solid #000">
                            Stored files
                        </div>
                        <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                            <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="_soterd"></div>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="bm_academic_button3 bm_am_btn_remove"
                                OnClick="btnRemove_OnClick" />
                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="bm_academic_button3 bm_am_btn_Send"
                                OnClick="btnSend_OnClick" />
                        </div>
                        <div style="width: 100%; overflow-y: auto; height: 100%; vertical-align: top;" runat="server" id="_storeddiv">

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound">
                                <Columns>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>

                    <div style="display: inline-block; width: 48%; height: 100%; vertical-align: top; padding:0px 10px; "> <%--background-color: #cceacb;--%>
                        <%--<div style="font-size: 20px; line-height: 1.5em; background-color: #40803C; color: #fff; padding-left: 10px; vertical-align: top;">
                        Send to students
                    </div>--%>

                        <div style="font-size: 20px; width: 100%; padding-left: 10px; vertical-align: top; padding-top: 3px; color: #000; border-bottom: 2px solid #000">
                            Send to students
                        </div>
                        <div style="width: 100%; padding-left: 10px; vertical-align: top; text-align: right; padding-top: 5px; padding-bottom: 5px;">
                            <div style="width: 100%; vertical-align: top; text-align: center;" runat="server" id="_send"></div>
                            <asp:Button ID="btnRemove1" runat="server" Text="Return" CssClass="bm_academic_button3 bm_am_btn_remove1"
                                OnClick="btnRemove1_OnClick" />
                        </div>
                        <div style="width: 100%; overflow-y: auto; vertical-align: top;" runat="server" id="_senddiv">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                PagerStyle-CssClass="PagerStyle" GridLines="None" OnRowDataBound="OnRowDataBound1">
                                <Columns>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>



           
        </div>
         </form>
    </div>
</body>
</html>
