<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="observationrpt1.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.observationrpt1"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
      function fnPrintNumSchedule() {
            <%--// alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession = $("#<%= xsession.ClientID%>").val();
            var xterm = $("#<%= xterm.ClientID%>").val();
            var xclass = $("#<%= xclass.ClientID%>").val();
            var xgroup = $("#<%= xgroup.ClientID%>").val();
            var xsection = $("#<%= xsection.ClientID%>").val();
            var xdate = $("#<%= hiddenxdate.ClientID%>").val();
            var xrow = $("#<%= hiddenxrow.ClientID%>").val();
            var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/rptasctschvwsw1.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup + '&xsection=' + xsection + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            openwin.print();
            //return false;--%>
        }
    </script>
    
    <style>
        .bm_academic_grid1 td:first-child {
            padding-left: 100px;
        }

        .bm_academic_grid1 th:first-child {
            padding-left: 50px;
        }

        .bm_academic_grid1 {
            background-color: #EEEDF6;
        }

            .bm_academic_grid1 th {
                background: #BBB8DC;
            }

            .bm_academic_grid1 .AlternatingRowStyle {
                background: #E0DEF0;
            }
    </style>
</asp:Content>
<asp:content id="Content2" contentplaceholderid="MainContent" runat="server">
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
                $("body").on("click", ".bm_teacher", function () {
                
                    fnOpenEMPList(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").attr("ID"),$("#<%= _teacher.ClientID%>").attr("ID"),$(this).parent(".bm_list_img").siblings(".bm_list_text").find(".bm_academic_textbox").val());
                });

                function fnPageLoad() {


                     if(this.myChart){
                         this.myChart.destroy();
                     }

                     var ctx = document.getElementById('canvas').getContext('2d');
                     window.myChart = new Chart(ctx, {
                         type: 'bar',
                         data: barChartData,
                         options: {
                             responsive: true,
                             legend: {
                                 display: false,
                                 position: 'top'
                             },
                             title: {
                                 display: false,
                                 text: 'Chart.js Bar Chart'
                             },
                             scales: {
                                 xAxes: [{
                                     display: true,
                                     scaleLabel: {
                                         display: true,
                                         labelString: 'Observation No'
                                     },
                                     maxBarThickness: 50
                                 }],
                                 yAxes: [
                                     {
                                         display: true,
                                         scaleLabel: {
                                             display: true,
                                             labelString: 'Percentage (%)'
                                         },
                                         ticks: {
                                             min: 0,
                                             max: 100,

                                             // forces step size to be 5 units
                                             stepSize: 10
                                         }
                                     }
                                 ]
                             }
                         }
                     });
                }

                $("body").on("click", ".bm_list", function() {


                    $.ajax({
                        url: "observationrpt1.aspx/fnFetchData",

                        type: "POST",

                        data: "{'xsession1' : '" + $("#<%= xsession.ClientID%>").val() + "', 'xteacher1':'" + $("#<%= _teacher.ClientID%>").val()  + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            var xcom = r.split("|");
                            if (xcom[0] == "success") {
                                var sub = xcom[1].split(",");
                                var raw = xcom[2].split(",");
                                
                        
                                barChartData = {
                                    
                                    labels: sub,
                                    datasets: [{
                                        label: 'Observation',
                                        backgroundColor: color("#BFD730").alpha(0.75).rgbString(),
                                        borderColor: "#BFD730",
                                        borderWidth: 1,
                                        data: raw
                                    }]

                                };
                            }
                            else if (xcom[0] == "nodata") {
                                barChartData = {
                                    labels: [],
                                    datasets: [
                                        {
                                            label: 'Observation',
                                            backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                                            borderColor: "#BFD730",
                                            borderWidth: 1,
                                            data: [
                                            ]
                                        }
                                    ]

                                };

                            } else {
                                alert(r);
                                barChartData = {
                                    labels: [],
                                    datasets: [
                                        {
                                            label: 'Observation',
                                            backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                                            borderColor: "#BFD730",
                                            borderWidth: 1,
                                            data: [
                                            ]
                                        }
                                    ]

                                };
                            }


                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                            barChartData = {
                                labels: [],
                                datasets: [
                                    {
                                        label: 'Observation',
                                        backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                                        borderColor: "#BFD730",
                                        borderWidth: 1,
                                        data: [
                                        ]
                                    }
                                ]

                            };

                        }


                    });





                    fnPageLoad();


                    $find('modalpopup').show();
                });

                var color = Chart.helpers.color;
                var barChartData = {
                    


                    labels: [],
                    datasets: [{
                        label: 'Observation',
                        backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                        borderColor: "#BFD730",
                        borderWidth: 1,
                        data: [
                            
                        ]
                    }]

                };


            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Observation Report</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>
                <div class="bm_academic_container_footer">
                    <div class="footer_list_padding2">
                        <div style="margin-left: 15px; margin-bottom: 5px; width: 100%;">
                            <%--<div class="bm_ctl_container_100_special" style="display: inline-block;">
                                <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                    <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_special" style="width: 103px">
                                    <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                        AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                    <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_special" style="width: 58px">
                                    <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                        AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <%--<div class="bm_ctl_container_100_special" style="display: inline-block; margin-left: 700px;
                                border: none">
                                <div class="bm_clt_ctl_100_special" style="width: 100%;">
                                    <asp:Label ID="dxstatus" runat="server" Text="Status  : New" CssClass="xstatus"></asp:Label>
                                </div>
                            </div>--%>
                        </div>
                        <div class="bm_academic_grid_container" id="list" runat="server">
                            <div class="grid_header">
                                <%--<div class="grid_header_label" id="_grid_header" runat="server">
                           
                        </div>--%>
                                <div class="grid_header_control" style="margin-left: 15px; margin-top: 5px;">
                                    <%--<div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 103px">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block; width: 160px">
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
                                    <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label5" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                            <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 103px">
                                            <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_100" style="display: inline-block; width: 400px; margin-right: 3px;">
                                        <div class="bm_ctl_label_align_right_50_100" style="width: 110px">
                                            <asp:Label ID="Label14" runat="server" Text=" Teacher's Name :" AssociatedControlID="xteacher"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_50_100" style="width: 288px">
                                            <%--<asp:TextBox ID="xname" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox"></asp:TextBox>--%>
                                            <div class="bm_list_text" style="width: 260px;">
                                                <asp:TextBox ID="xteacher" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "></asp:TextBox>
                                            </div>
                                            <div class="bm_list_img" style="width: 20px;">
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" CssClass="bm_academic_list bm_teacher" />
                                            </div>
                                        </div>
                                    </div>
                                    <%--<div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                            <asp:Label ID="Label6" runat="server" Text="Subject :" AssociatedControlID="xsubject"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 184px">
                                            <asp:DropDownList ID="xsubject" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block; width: 250px;">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 64px">
                                            <asp:Label ID="Label7" runat="server" Text="Paper :" AssociatedControlID="xpaper"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 184px;">
                                            <asp:DropDownList ID="xpaper" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class="flot_right">
                                    <%-- <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>--%>
                                    <%-- <div class="grid_header_row">
                                <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                                    OnTextChanged="fnFilterByRow"></asp:TextBox>
                            </div>--%>
                                    <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 200px; margin-top: 3px;margin-right: 10px">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label12" runat="server" Text="From :" AssociatedControlID="xfrom"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 74%; ">
                                    <asp:TextBox ID="xfrom" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="bm_ctl_container_50_50" style="float: left; width: 200px; margin-top: 3px;margin-right: 10px">
                                <div class="bm_ctl_label_align_right_50_50" style="width: 25%">
                                    <asp:Label ID="Label1" runat="server" Text="To :" AssociatedControlID="xto"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_50_50" style="width: 74%; ">
                                    <asp:TextBox ID="xto" runat="server" CssClass="bm_academic_textbox_50_50 bm_academic_ctl_global bm_academic_datepicker"></asp:TextBox>
                                </div>
                            </div>--%>
                                    <%--  <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                margin-right: 10px">
                                <div class="bm_ctl_label_align_right_100_special">
                                    <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_special">
                                    <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown" AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                                    <%-- <div class="bm_ctl_container_100_special" style="float: left; margin-top: 3px; margin-right: 10px;
                                        width: 122px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <%--<div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                        margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                        margin-right: 10px;">
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
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 3px;
                                        margin-right: 10px; display: none;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xgroup"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 210px; margin-top: 3px;
                                        margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label5" runat="server" Text="Month :" AssociatedControlID="xdate"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xdate" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                Width="25px" Height="25px" OnClientClick="fnPrintNumSchedule();" OnClick="fnFillDataGrid"
                                                CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="grid_body" style="width: 1229.4px; overflow: auto;">
                                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                    CssClass="bm_academic_grid1 bm_academic_grid4" FooterStyle-CssClass="FooterStyle"
                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnDataBound="GridView1_DataBound1"
                                    OnRowDataBound="OnRowDataBound" UseAccessibleHeaderText="true">
                                    <HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>
                                    <Columns>
                                       
                                    </Columns>
                                </asp:GridView>--%>


                                <div id="observation" runat="server" style="width: 100%;padding-top: 5px">
                                    <div style="width: 100%; background-color: #A7D8B7; padding: 3px 0px 5px 50px;
                                            color: #fff;font-family: Myriad Pro,tahoma; font-weight: 100;font-size: 14px; ">Observation Report:</div>
                                    
                                     <div style="width: 100%; background-color: #E3F2EB; padding: 3px 0px 5px 100px;
                                                  color: #000;font-family: Myriad Pro,tahoma; font-weight: lighter;font-size: 14px; margin-top: 2px;">
                                        <span>Teacher</span><span style="padding-left: 127px">:</span>
                                         <span runat="server" ID="xname" style="padding-left: 10px"></span>
                                    </div>

                                    <div style="width: 100%; background-color: #CBE8DD; padding: 3px 0px 5px 100px;
                                                    color: #000;font-family: Myriad Pro,tahoma; font-weight: lighter;font-size: 14px; margin-top: 2px;">
                                        <span>No. of observations</span><span style="padding-left: 60px">:</span>
                                        <span runat="server" ID="xobserno" style="padding-left: 10px"></span>
                                    </div>
                                    
                                    <div style="width: 100%; background-color: #E3F2EB; padding: 3px 0px 5px 100px;
                                                               color: #000;font-family: Myriad Pro,tahoma; font-weight: lighter;font-size: 14px; margin-top: 2px;">
                                        <span >Observer</span><span style="padding-left: 119px">:</span>
                                        <span runat="server" ID="xpeer" style="padding-left: 10px"></span>
                                    </div>
                                    
                                    <div style="width: 100%; background-color: #CBE8DD; padding: 3px 0px 5px 100px;
                                                    color: #000;font-family: Myriad Pro,tahoma; font-weight: lighter;font-size: 14px; margin-top: 2px;">
                                        <span>No. of subject observed</span><span style="padding-left: 35px">:</span>
                                        <span runat="server" ID="xsubject" style="padding-left: 10px"></span>
                                    </div>
                                    
                                     <div style="width: 100%; background-color: #E3F2EB; padding: 3px 0px 5px 100px;
                                                                            color: #000;font-family: Myriad Pro,tahoma; font-weight: lighter;font-size: 14px; margin-top: 2px;">
                                        <span>Observation (month wise)</span><span style="padding-left: 21px">:</span>
                                         <span runat="server" ID="xdate" style="padding-left: 10px"></span>
                                    </div>
                                </div>
                                <div id="detail" runat="server" style="padding-top: 10px; overflow: hidden; width: 100%;">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                    CssClass="bm_academic_grid1 " FooterStyle-CssClass="FooterStyle"
                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None" OnDataBound="GridView1_DataBound1"
                                    OnRowDataBound="OnRowDataBound" UseAccessibleHeaderText="true">
                                    <HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>
                                    <Columns>
                                       
                                    </Columns>
                                </asp:GridView>
                                </div>
                                <%--bm_academic_grid4--%>
                              <%--  <div style="width: 300px; height: 250px; position: absolute; background-color: #00bfff; top: 80px; left: 800px;">
                                    
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            
            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modal1" BehaviorID="modalpopup" PopupDragHandleControlID="pnlpopup" >
    </cc1:ModalPopupExtender>

    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="350px" Width="300px"
        Style="display: none; ">
        <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
            cellpadding="0" cellspacing="0">
            <tr style="background-color: #619CFD">
                <td style="height: 15px; color: white; font-size: 14px;" align="left">
                    <div style="float: left;padding-left: 5px">Observation</div>
                    <div style="float: right"><img id="btnCancel" style="cursor: pointer" src="../../../../images/close-window.png" width="20px" height="20px" class="bm_academic_button_zoom"/></div>
                    
                </td>
               
            </tr>
            <tr>
                <td align="left" style="padding: 5px;">
               <%--     <div style="padding-bottom: 10px">
                    <table style="border: none;">
                        <tr>
                           
                            <td>Student ID
                            </td>
                            <td>:
                            </td>
                            <td id="stdid">
                               
                            </td>
                            <td style="padding-left: 30px">Student Name
                            </td>
                            <td>:
                            </td>
                            <td id="stdname">
                               
                            </td>
                        </tr>
                       


                    </table>
                        </div>--%>
                    <div>
                    <canvas id="canvas" height="100%" width="100%"></canvas>
                        </div>
                </td>
            </tr>
           
        </table>
    </asp:Panel>
            

            <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                OnTextChanged="fnFilterByRow"></asp:TextBox>
            <asp:HiddenField ID="ctlid_v" runat="server" />
            <asp:HiddenField ID="_xdate" runat="server" />
            <asp:HiddenField ID="hiddenxdate" runat="server" />
            <asp:HiddenField ID="hiddenxrow" runat="server" />
            <asp:HiddenField ID="hiddenxstatus" runat="server" />
            <asp:HiddenField ID="_student" runat="server" />
            <asp:HiddenField ID="_teacher" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:content>

