<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="astabulationmock1.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.astabulationmock1"
    EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        tr.BorderRow td
        {
            border-top: 2px solid #000000;
        }

        .pointer {
            cursor: pointer;
        }

        canvas {
		-moz-user-select: none;
		-webkit-user-select: none;
		-ms-user-select: none;
	}
    </style>
    <script type="text/javascript">
        function fnPrintNumSchedule() {
            // alert("Hi");
            var zid1 = <%= HttpContext.Current.Session["business"] %>;
            var xsession1 = $("#<%= xsession.ClientID%>").val();
            var xterm1 = $("#<%= xterm.ClientID%>").val();
            var xclass1 = $("#<%= xclass.ClientID%>").val();
            var xgroup1 = $("#<%= xgroup.ClientID%>").val();
            var xsection1 = $("#<%= xsection.ClientID%>").val();

             

            var openwin = window.open('/forms/academic/reports/rpttabulationmock.aspx?zid=' + zid1 + '&xsession=' + xsession1 + '&xterm=' + xterm1 + '&xclass=' + xclass1 + '&xgroup=' + xgroup1 + '&xsection=' + xsection1 , 'tabulation', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            //openwin.print();
            //return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
            <script>
                
                function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
                    var tbl = document.getElementById(gridId);

                    var tbody = tbl.getElementsByTagName("tbody")[0]; //gets the first and only tbody
                    var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's
                    var secondTr = tbody.getElementsByTagName("tr")[1];
                    headerHeight = firstTr.offsetHeight + secondTr.offsetHeight;

                    if (tbl) {
                        var DivHR = document.getElementById('DivHeaderRow');
                        var DivMC = document.getElementById('DivMainContent');
                        var DivFR = document.getElementById('DivFooterRow');

                        //*** Set divheaderRow Properties ****
                        DivHR.style.height = headerHeight + 'px';
                        DivHR.style.width = (parseInt(width) - 17) + 'px';
                        DivHR.style.position = 'relative';
                        DivHR.style.top = '0px';
                        DivHR.style.zIndex = '10';
                        DivHR.style.verticalAlign = 'top';

                        //*** Set divMainContent Properties ****
                        DivMC.style.width = width + 'px';
                        DivMC.style.height = height + 'px';
                        DivMC.style.position = 'relative';
                        DivMC.style.top = -headerHeight + 'px';
                        DivMC.style.zIndex = '1';

                        //*** Set divFooterRow Properties ****
                        DivFR.style.width = (parseInt(width) - 16) + 'px';
                        DivFR.style.position = 'relative';
                        DivFR.style.top = -headerHeight + 'px';
                        DivFR.style.verticalAlign = 'top';
                        DivFR.style.paddingtop = '2px';

                        if (isFooter) {
                            var tblfr = tbl.cloneNode(true);
                            tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
                            var tblBody = document.createElement('tbody');
                            tblfr.style.width = '100%';
                            tblfr.cellSpacing = "0";
                            tblfr.border = "0px";
                            tblfr.rules = "none";
                            //*****In the case of Footer Row *******
                            tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
                            tblfr.appendChild(tblBody);
                            DivFR.appendChild(tblfr);
                        }
                        //****Copy Header in divHeaderRow****
                        DivHR.appendChild(tbl.cloneNode(true));
                    }
                }



                function OnScrollDiv(Scrollablediv) {
                    document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
                    document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
                }


                function fnPageLoad() {

                    <%--$("#<%= GridView1.ClientID %>").chromatable({

                        width: "100%", // specify 100%, auto, or a fixed pixel amount
                        height: "500px",
                        scrolling: "yes" // must have the jquery-1.3.2.min.js script installed to use

                    });--%>

                    //if(window.myChart!=undefined) {
                    //    var oldcanvasid= window.myChart.chart.ctx.canvas.id;
                    //    if(chardcanvasid==oldcanvasid) {
                    //        window.myChart.clear();
                    //    }
                    //}

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
                                position: 'top'
                            },
                            title: {
                                display: false,
                                text: 'Chart.js Bar Chart'
                            },
                            scales: {
                                xAxes: [{
                                    display: true,
                                    //scaleLabel: {
                                    //    display: true,
                                    //    labelString: 'Subjects'
                                    //},
                                    maxBarThickness: 50
                                }],
                                yAxes: [
                                    {
                                        display: true,
                                        scaleLabel: {
                                            display: true,
                                            labelString: 'Marks'
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

                //$(document).ready(function () {


                //    fnPageLoad();
                //});

                //var prm = Sys.WebForms.PageRequestManager.getInstance();
                //prm.add_endRequest(function () {
                //    fnPageLoad();
                //});

                $("body").on("change", ".bm_academic_dropdown", function () {

                    $("#<%= message.ClientID %>").empty();
                    //$(".grid_body").empty();
                    $("#DivRoot").empty();
                    //return false;
                });

                $("body").on("click", ".pointer", function () {

                    //alert("Hi");
                    var row = this.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var cell = this.parentNode.cellIndex;

                  <%--  //alert($("#<%= xrowcount.ClientID%>").val());--%>
                    var rowcount = $("#<%= xrowcount.ClientID%>").val();

                    var grid = document.getElementById('<%=GridView1.ClientID %>');
            var term = grid.rows[rowIndex + 1].cells[ eval(rowcount) + 10].innerText;
            //var btnid = grid.rows[rowIndex + 1].cells[cell].children[0].id;
                   // alert(term);
                    //return;
                    //var student = grid.rows[rowIndex + 1].cells[1].innerText.split("\n");
                    //alert(btnid);
                    //return;
           // $('#hbtnid').val(btnid);
                        <%--$('#term').html($("#<%= xterm.ClientID%>").val() + " Term");--%>
                   // $('#term').html(term + " Term");
                    $('#stdid').html(grid.rows[rowIndex + 1].cells[eval(rowcount) + 9].innerText);
                    $('#stdname').html(grid.rows[rowIndex + 1].cells[eval(rowcount) + 8].innerText);
                    //$("#" + btnid).css("background-color", "#8A2BE2");
                    //alert(grid.rows[rowIndex + 1].cells[cell + 2].innerText);
                    //return;
                    $('#hxsession').val($("#<%= xsession.ClientID%>").val());
            $('#hxterm').val(term);
            $('#hxclass').val($("#<%= xclass.ClientID%>").val());
                        $('#hxgroup').val($("#<%= xgroup.ClientID%>").val());
                    $('#hxsection').val(grid.rows[rowIndex + 1].cells[eval(rowcount) + 7].innerText);
                    $('#hxsrow').val(grid.rows[rowIndex + 1].cells[eval(rowcount) + 6].innerText);
                    //$('#xdetails').val('');


                    $.ajax({
                        url: "astabulationmock1.aspx/fnFetchData",

                        type: "POST",

                        data: "{'xsession1' : '" + $('#hxsession').val() + "', 'xterm1':'" + $('#hxterm').val() + "', 'xclass1' : '" + $('#hxclass').val() + "', 'xgroup1' : '" + $('#hxgroup').val() + "', 'xsection1' : '" + $('#hxsection').val() + "', 'xsrow1' : '" + $('#hxsrow').val() + "'}",

                        //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            var xcom = r.split("|");
                            if (xcom[0] == "success") {
                                var sub = xcom[1].split(",");
                                var raw = xcom[2].split(",");
                                var highest = xcom[3].split(",");
                        
                                barChartData = {
                                    
                                    labels: sub,
                                    datasets: [{
                                        label: 'Highest Mark',
                                        backgroundColor: color("#BFD730").alpha(0.75).rgbString(),
                                        borderColor: "#BFD730",
                                        borderWidth: 1,
                                        data: highest
                                    }, {
                                        label: 'Raw Mark',
                                        backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
                                        borderColor: window.chartColors.blue,
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
                                            label: 'Highest Mark',
                                            backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                                            borderColor: "#BFD730",
                                            borderWidth: 1,
                                            data: [
                                            ]
                                        }, {
                                            label: 'Raw Mark',
                                            backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
                                            borderColor: window.chartColors.blue,
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
                                            label: 'Highest Mark',
                                            backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                                            borderColor: "#BFD730",
                                            borderWidth: 1,
                                            data: [
                                            ]
                                        }, {
                                            label: 'Raw Mark',
                                            backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
                                            borderColor: window.chartColors.blue,
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
                                        label: 'Highest Mark',
                                        backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                                        borderColor: "#BFD730",
                                        borderWidth: 1,
                                        data: [
                                        ]
                                    }, {
                                        label: 'Raw Mark',
                                        backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
                                        borderColor: window.chartColors.blue,
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

                //var MONTHS = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
                var color = Chart.helpers.color;
                var barChartData = {
                    //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
                    //datasets: [{
                    //    label: 'Highest Mark',
                    //    backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                    //    borderColor: "#BFD730",
                    //    borderWidth: 1,
                    //    data: [
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor()
                    //    ]
                    //}, {
                    //    label: 'Raw Mark',
                    //    backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
                    //    borderColor: window.chartColors.blue,
                    //    borderWidth: 1,
                    //    data: [
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor(),
                    //        randomScalingFactor()
                    //    ]
                    //}]


                    labels: [],
                    datasets: [{
                        label: 'Highest Mark',
                        backgroundColor: color("#BFD730").alpha(0.5).rgbString(),
                        borderColor: "#BFD730",
                        borderWidth: 1,
                        data: [
                            
                        ]
                    }, {
                        label: 'Raw Mark',
                        backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
                        borderColor: window.chartColors.blue,
                        borderWidth: 1,
                        data: [
                            
                        ]
                    }]

                };

             


               

              


             


            

             




            </script>
            <div class="bm_academic_container">
                <div class="bm_academic_container_header">
                    <div class="header_label1" id="header_label" runat="server">
                        <span class="bm_am_header_round">Mock Exam Result (Sectionwise)</span>
                    </div>
                </div>
                <div class="bm_academic_container_message">
                    <div class="message" id="message" runat="server">
                    </div>
                </div>
                <div class="bm_academic_container_footer">
                    <div class="footer_list_padding2">
                        <div class="bm_academic_grid_container" id="list" runat="server">
                            <div class="grid_header">
                                <%--<div class="grid_header_label" id="_grid_header" runat="server">
                           
                        </div>--%>
                                <div class="grid_header_control">
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
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px;
                                        margin-right: 10px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; margin-top: 5px; margin-right: 10px;
                                        width: 160px">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label1" runat="server" Text="Mock :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px;
                                        margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px;
                                        margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label4" runat="server" Text="Group :" AssociatedControlID="xgroup"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xgroup" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="float: left; width: 165px; margin-top: 5px;
                                        margin-right: 10px;">
                                        <div class="bm_ctl_label_align_right_100_special">
                                            <asp:Label ID="Label3" runat="server" Text="Section :" AssociatedControlID="xsection"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special">
                                            <asp:DropDownList ID="xsection" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="bm_ctl_container_100_special" style="float: left; width: 210px; margin-top: 3px;
                                margin-right: 10px;">
                                <div class="bm_ctl_label_align_right_100_special">
                                    <asp:Label ID="Label5" runat="server" Text="Month :" AssociatedControlID="xdate"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_special">
                                    <asp:DropDownList ID="xdate" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown" AutoPostBack="True" OnTextChanged="combo_OnTextChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        border: none; height: 32px">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                Width="25px" Height="25px" OnClientClick="fnPrintNumSchedule();" OnClick="fnFillDataGrid"
                                                CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="DivRoot" align="left">
                                    <div style="overflow: hidden;" id="DivHeaderRow">
                                    </div>

                                    <div style="overflow: auto;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                                        <%--<div class="grid_body" style="width: 1229.4px; overflow: auto;height: 600px">--%>
                                        <%--style="width: 1229.4px; overflow: auto;height: 600px"--%>
                                        <%-- <div id="GHead"></div>--%>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                            CssClass="bm_academic_grid10" FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle"
                                            AlternatingRowStyle-CssClass="AlternatingRowStyle" PagerStyle-CssClass="PagerStyle"
                                            GridLines="None" OnDataBound="GridView1_DataBound1" OnRowDataBound="OnRowDataBound">
                                            <%--<HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>--%>
                                            <Columns>
                                                <%--<asp:TemplateField HeaderText="Days">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("SelectedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("section") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                        <%--</div>--%>
                                    </div>

                                    <div id="DivFooterRow" style="overflow: hidden">
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modal" BehaviorID="modalpopup" >
    </cc1:ModalPopupExtender>

    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="500px" Width="650px"
        Style="display: none">
        <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
            cellpadding="0" cellspacing="0">
            <tr style="background-color: #619CFD">
                <td style="height: 15px; color: white; font-size: 14px;" align="left">
                    <div style="float: left;padding-left: 5px">Student Result at Glance</div>
                    <div style="float: right"><img id="btnCancel" style="cursor: pointer" src="../../../../images/close-window.png" width="20px" height="20px" class="bm_academic_button_zoom"/></div>
                    
                </td>
               
            </tr>
            <tr>
                <td align="left" style="padding: 5px;">
                    <div style="padding-bottom: 10px">
                    <table style="border: none;">
                        <tr>
                           
                            <td>Student ID
                            </td>
                            <td>:
                            </td>
                            <td id="stdid">
                                <%--<asp:Label ID="lblstdid" runat="server" Text=""></asp:Label>--%>
                            </td>
                            <td style="padding-left: 30px">Student Name
                            </td>
                            <td>:
                            </td>
                            <td id="stdname">
                                <%-- <asp:Label ID="lblsection" runat="server" Text=""></asp:Label>--%>
                            </td>
                        </tr>
                       


                    </table>
                        </div>
                    <div>
                    <canvas id="canvas" height="200px"></canvas>
                        </div>
                </td>
            </tr>
           <%-- <tr style="background-color: #619CFD">
                <td style="height: 15px; color: white; font-size: 14px;" align="left">Comments for <span id="term"></span>
                </td>
            </tr>--%>


            <%--<tr>
                <td align="left" style="padding: 5px;">
                    <%--<textarea id="xdetails" class="bm_academic_textarea_100_50  bm_academic_textarea"
                        style="width: 100%; height: 120px;"></textarea>
                   <canvas id="canvas"></canvas>
                </td>
            </tr>--%>




           <%-- <tr>
                <td align="center" style="padding-bottom: 5px;">
                    
                    <input type="button" id="btnCancel" value="Close" class="bm_academic_button1 bm_am_btn_cancel" />
                </td>
            </tr>--%>
        </table>
    </asp:Panel>
            <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
                OnTextChanged="fnFilterByRow"></asp:TextBox>
            <asp:HiddenField ID="ctlid_v" runat="server" />
            <asp:HiddenField ID="_xdate" runat="server" />
            <asp:HiddenField ID="hiddenxdate" runat="server" />
            <asp:HiddenField ID="hiddenxrow" runat="server" />
            <asp:HiddenField ID="hiddenxstatus" runat="server" />
            <asp:HiddenField ID="xrowcount" runat="server" />
              <input id="hbtnid" type="hidden" />
    <input id="hxsession" type="hidden" />
    <input id="hxterm" type="hidden" />
    <input id="hxclass" type="hidden" />
    <input id="hxgroup" type="hidden" />
    <input id="hxsection" type="hidden" />
    <input id="hxsrow" type="hidden" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
