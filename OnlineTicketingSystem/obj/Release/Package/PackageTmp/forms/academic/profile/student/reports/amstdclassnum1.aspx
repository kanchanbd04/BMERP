<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/academic_site.Master"
    CodeBehind="amstdclassnum1.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.amstdclassnum1"
    EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function fnPrintNumSchedule() {
            // alert("Hi");
            var zid = <%= HttpContext.Current.Session["business"] %>;
            var xsession = $("#<%= xsession.ClientID%>").val();
           <%-- var xterm = $("#<%= xterm.ClientID%>").val();
            var xclass = $("#<%= xclass.ClientID%>").val();--%>
            var xdate = $("#<%= hiddenxdate.ClientID%>").val();
            var xrow = $("#<%= hiddenxrow.ClientID%>").val();
            var xstatus = $("#<%= hiddenxstatus.ClientID%>").val();
            var openwin = window.open('/forms/academic/reports/rptasctschvwsw1.aspx?zid=' + zid + '&xsession=' + xsession + '&xterm=' + xterm + '&xclass=' + xclass + '&xgroup=' + xgroup + '&xsection=' + xsection + '&xdate=' + xdate + '&xrow=' + xrow + '&xstatus=' + xstatus, 'schedulesw1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=' + screen.width + ', height=' + screen.height + ', top=0, left=0, targets=_blank');
            openwin.focus();
            openwin.print();
            //return false;
        }

        

    </script>
    <style>
        .bm_academic_grid1, .bm_academic_grid1 td {
            border: 2px solid #939598;
        }

            .bm_academic_grid1 th, .bm_academic_grid1 .FooterStyle {
                border-left: 2px solid #939598;
            }

        #chartdiv {
            width: 650px;
            height: 550px;
        }

        .FooterStyle td {
            color: #ffffff;
            font-weight: bold;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="/images/loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <script type="text/javascript">
        //$(function () {
        //    LoadChart();
            
        //});

        $("body").on("click", ".bm_circle_button_coordinator", function () {

            //alert("Hi");
            var row = this.parentNode.parentNode.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var cell = this.parentNode.parentNode.parentNode.cellIndex;

            //alert(this.name);

                   <%-- var grid = document.getElementById('<%=GridView1.ClientID %>');--%>


            // alert(grid.rows[rowIndex+1].cells[cell].children[0].children[0].children[0].title);

            var allparam = document.getElementsByName(this.name);
            var param = allparam[0].title.split("\n");
            var test1 = param[0].split("-");
            //                    alert(test1[0]);
            ////                 var col = grid.rows[rowIndex + 1].cells.length;
            ////                 alert(grid.rows[rowIndex + 1].cells[1].innerText);
            var subject = param[3].split("-");
            ////                 if (typeof subject[1] != 'undefined') {
            ////                  alert(subject[1]);
            ////                 }

            //                               alert(subject[0]);
            //                    alert(param[3]);

            <%-- var xsession1 = $("#<%= xsession.ClientID%>").val();--%>
                  <%--  var xterm1 = $("#<%= xterm.ClientID%>").val();
                    var xclass1 = $("#<%= xclass.ClientID%>").val();--%>
            var xgroup1 = param[2];
            var xsection1 = param[1];
            var xsubject1 = subject[0];
            var xpaper1 = "";
            if (typeof subject[1] != 'undefined') {
                xpaper1 = subject[1];
            }

            var xcttype1 = test1[0];
            var xctno1 = test1[1];

            var left = Math.round((screen.width / 2) - (500 / 2));
            var top = Math.round((screen.height / 2) - (500 / 2));
            var openwin = window.open("/forms/academic/assesment/mark-input/amexamh2.aspx?subnav=myDropdown44&link=LinkButton44&xsession=" + xsession1 + "&xterm=" + xterm1 + "&xclass=" + xclass1 + "&xgroup=" + xgroup1 + "&xsection=" + xsection1 + "&xsubject=" + xsubject1.replace(/&/gi, "%26") + "&xpaper=" + xpaper1 + "&xcttype=" + xcttype1 + "&xctno=" + xctno1, 'ctstco', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=600, height=500, top=' + top + ', left=' + left + ', targets=_blank');
            openwin.focus();

        });

               <%-- function ConfirmMessage3() {
                    var selectedvalue = confirm("Do you want to approved this record?");
                    if (selectedvalue) {
                        document.getElementById('<%=txtconformmessageValue3.ClientID %>').value = "Yes";
                    } else {
                        document.getElementById('<%=txtconformmessageValue3.ClientID %>').value = "No";
                    }
                }--%>

        $("body").on("change", ".bm_academic_dropdown", function() {
            //alert("hi");
            <%--  document.getElementById('<%=message.ClientID %>').innerHTML = "";
                    document.getElementById('<%=_student.ClientID %>').value = "";--%>
            <%--  $('#<%=GridView1.ClientID %>').empty();--%>
            <%--  $('#<%=result.ClientID %>').hide();--%>
            <%--   $('#<%=barchart.ClientID %>').hide();--%>
                    <%--$('#<%=btnApprove.ClientID %>').hide();
                    $('#<%=btnSave.ClientID %>').hide();--%>
        });

        function fnPageLoad() {
            //alert("Hi");
            

           
            //alert("hi1");
            var xsession1 = $("#<%=xsession.ClientID%>").val();

            $.ajax({
                type: "POST",
                url: "amstdclassnum1.aspx/GetClasswiseNumStudent",
                data: "{xsession:'"+xsession1+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });

           
      
              
        }

        

        function OnSuccess(r) {

            

            

            // alert("hi");
            var student = $($.parseXML(r.d)).find("Table");


            var table = $("[id*=GridView1]");


            var row = table.find("tr:last-child").prev().clone(true);
            var footer = table.find("tr:last-child").clone(true);

            //Remove the Dummy Row.
            $("tr", table).not($("tr:first-child", table)).remove();

            //Loop through the XML and add Rows to the Table.
            var i = 1;
            $.each(student, function () {
                var student = $(this);
                if (i % 2 == 0) {
                    $("td", row).css("background-color", "#E1DFEF");
                    $("td", row).eq(5).css("background-color", "#FBDBE9");
                    $("td", row).eq(6).css("background-color", "#FBDBE9");
                    $("td", row).eq(7).css("background-color", "#FBDBE9");
                    $("td", row).eq(8).css("background-color", "#FDE9F1");
                    $("td", row).eq(9).css("background-color", "#C0E2CA");
                   
                } else {
                    $("td", row).css("background-color", "#F0EFF7");
                    $("td", row).eq(5).css("background-color", "#FDE9F1");
                    $("td", row).eq(6).css("background-color", "#FDE9F1");
                    $("td", row).eq(7).css("background-color", "#FDE9F1");
                    $("td", row).eq(8).css("background-color", "#FEF3F7");
                    $("td", row).eq(9).css("background-color", "#D8EDDD");
                }
               
                $("td", row).eq(0).html(i.toString());
                $("td", row).eq(1).html($(this).find("xclass").text());
                $("td", row).eq(2).html($(this).find("xprevious").text());
                $("td", row).eq(3).html($(this).find("xpromoted").text());
                $("td", row).eq(4).html($(this).find("xyeardrop").text());
                $("td", row).eq(5).html($(this).find("xwithoutpayment").text());
                $("td", row).eq(6).html($(this).find("xreadmis").text());
                $("td", row).eq(7).html($(this).find("xnew").text());
                $("td", row).eq(8).html($(this).find("xdropout").text());
                $("td", row).eq(9).html($(this).find("xtotal").text());
                //if (i % 2 == 0) {
                //    row.addClass("RowStyle");
                //} else {
                //    row.addClass("AlternatingRowStyle");
                //}
                table.append(row);
                row = table.find("tr:last-child").clone(true);
                i = i + 1;
            });

            table.append(footer);
            table.addClass("bm_academic_grid");
            footer.addClass("FooterStyle");

            $("#<%= GridView1.ClientID%>").css("visibility", "visible"); 

            var xsession2 = $("#<%=xsession.ClientID%>").val();

            $("#chartdiv").html("");
            $("#chartdiv1").html("");
            $("#chartdiv2").html("");
            $("#chartdiv3").html("");

            $.ajax({
                type: "POST",
                url: "amstdclassnum1.aspx/GetClasswiseNumStudent1",
                data: "{xsession:'"+xsession2+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(r) {
                    var chartData = [];

                    var charvalues = $($.parseXML(r.d)).find("Table");
            
                    $.each(charvalues, function () {
                        var charvalues = $(this);
                        ////alert($(this).find("xprevious").text());
                        ////chartData.push({ xtype: "Last Session", value: $(this).find("xprevious").text() });
                        //chartData.push({ xtype: "Readmission", value: $(this).find("xreadmis").text(),  color : "#0D8ECF"});
                        //chartData.push({ xtype: "New", value: $(this).find("xnew").text(), color : "#FD4598" });
                        ////chartData.push({ xtype: "Totals", value: $(this).find("xtotal").text() });

                        //chartData.push(  $(this).find("xnew").text(), $(this).find("xreadmis").text());

                        $("td", footer).eq(0).html("");
                        $("td", footer).eq(1).html("Total :");
                        $("td", footer).eq(2).html($(this).find("xprevious").text());
                        $("td", footer).eq(3).html($(this).find("xpromoted").text());
                        $("td", footer).eq(4).html($(this).find("xyeardrop").text());
                        $("td", footer).eq(5).html($(this).find("xwithoutpayment").text());
                        $("td", footer).eq(6).html($(this).find("xreadmis").text());
                        $("td", footer).eq(7).html($(this).find("xnew").text());
                        $("td", footer).eq(8).html($(this).find("xdropout").text());
                        $("td", footer).eq(9).html($(this).find("xtotal").text());


                        var config = {
                            type: 'pie',
                            data: {
                                datasets: [{
                                    data: [
                                        $(this).find("xnew").text(), 
                                        $(this).find("xreadmis").text()
                                    ],
                                    backgroundColor: [
                                        window.chartColors.red,
                                        window.chartColors.blue
                                    ],
                                    label: 'Ratio-1'
                                }],
                                labels: [
                                    'New',
                                    'Readmission'
                                ]
                            },
                            options: {
                                responsive: true,
                                plugins: {
                                    labels: [{
                                        render: 'percentage',
                                        fontColor: '#fff',
                                        precision: 2
                                    }
                                    ]
                                }
                            }
                        };

                        $("#chartdiv").html("");
                        var el = document.createElement('canvas');
                        el.width = '288px';
                        el.height = '300px';
                        $("#chartdiv")[0].appendChild(el);
                        var ctx = el.getContext('2d');
                        var myPie = new Chart(ctx, config);


                    });

                    //var chart = AmCharts.makeChart( "chartdiv", {
                    //    "type": "pie",
                    //    "theme": "light",
                    //    "addClassNames" : true,
                    //    "dataProvider": chartData,
                    //    "valueField": "value",
                    //    "titleField": "xtype",
                    //    "colorField" : "color",
                    //    "outlineAlpha": 0.4,
                    //    "depth3D": 15,
                    //    "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
                    //    "angle": 30,
                    //    "export": {
                    //        "enabled": false
                    //    }
                    //} );

                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });


            $.ajax({
                type: "POST",
                url: "amstdclassnum1.aspx/GetBoyGirl",
                data: "{xsession:'"+xsession2+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(r) {

                    var charvalues = $($.parseXML(r.d)).find("Table");
            
                    $.each(charvalues, function () {
                       



                        var config = {
                            type: 'pie',
                            data: {
                                datasets: [{
                                    data: [
                                        $(this).find("xboy").text(), 
                                        $(this).find("xgirl").text()
                                    ],
                                    backgroundColor: [
                                        window.chartColors.green,
                                        window.chartColors.purple
                                    ],
                                    label: 'Ratio-2'
                                }],
                                labels: [
                                    'Boys',
                                    'Girls'
                                ]
                            },
                            options: {
                                responsive: true,
                                plugins: {
                                    labels: [{
                                        render: 'percentage',
                                        fontColor: '#fff',
                                        precision: 2
                                    }
                                    ]
                                }
                            }
                        };

                        $("#chartdiv1").html("");
                        var el = document.createElement('canvas');
                        el.width = '288px';
                        el.height = '300px';
                        $("#chartdiv1")[0].appendChild(el);
                        var ctx = el.getContext('2d');
                        var myPie1 = new Chart(ctx, config);


                    });


                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });



            var coloR = [];

            var dynamicColors = function() {
                var r = Math.floor(Math.random() * 255);
                var g = Math.floor(Math.random() * 255);
                var b = Math.floor(Math.random() * 255);
                return "rgb(" + r + "," + g + "," + b + ")";
            };

            

            $.ajax({
                url: "amstdclassnum1.aspx/fnFetchData",
                data: "{xsession1:'"+xsession2+"'}",

                type: "POST",

                
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            var xcom = r.split("|");
                            if (xcom[0] == "success") {
                                var xschool = xcom[1].split(",");
                                var xtotal = xcom[2].split(",");
                                
                                for (var i in xtotal) {
                                    coloR.push(dynamicColors());
                                }

                             

                                var config = {
                                    type: 'pie',
                                    data: {
                                        datasets: [{
                                            data: xtotal,
                                            backgroundColor:coloR,
                                            label: 'Ratio-2'
                                        }],
                                        labels:xschool
                                    },
                                    options: {
                                        responsive: true,
                                        plugins: {
                                            labels: [{
                                                render: 'percentage',
                                                fontColor: '#fff',
                                                precision: 2
                                            }
                                            ]
                                        }


                                    }
                                };

                                $("#chartdiv2").html("");
                                var el = document.createElement('canvas');
                                el.width = '288px';
                                el.height = '300px';
                                $("#chartdiv2")[0].appendChild(el);
                                var ctx = el.getContext('2d');
                                var myPie1 = new Chart(ctx, config);
                                

                            } else {
                                alert(r);
                                
                            }


                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                            

                        }


            });

            $.ajax({
                type: "POST",
                url: "amstdclassnum1.aspx/GetClasswiseNumStudent1",
                data: "{xsession:'"+xsession2+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(r) {

                    var charvalues = $($.parseXML(r.d)).find("Table");
            
                    $.each(charvalues, function () {
                       



                        var config = {
                            type: 'pie',
                            data: {
                                datasets: [{
                                    data: [
                                        $(this).find("xyeardrop").text(), 
                                        $(this).find("xdropout").text()
                                    ],
                                    backgroundColor: [
                                        window.chartColors.orange,
                                        window.chartColors.grey
                                    ],
                                    label: 'Ratio-4'
                                }],
                                labels: [
                                    'Year End Dropout',
                                    'Drop Out'
                                ]
                            },
                            options: {
                                responsive: true,
                                plugins: {
                                    labels: [{
                                        render: 'percentage',
                                        fontColor: '#fff',
                                        precision: 2
                                    }
                                    ]
                                }
                            }
                        };

                        $("#chartdiv3").html("");
                        var el = document.createElement('canvas');
                        el.width = '288px';
                        el.height = '300px';
                        $("#chartdiv3")[0].appendChild(el);
                        var ctx = el.getContext('2d');
                        var myPie1 = new Chart(ctx, config);


                    });


                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });


        }

        

       

        //function OnSuccess1(r) {

        //    var chartData = [];

        //    var charvalues = $($.parseXML(r.d)).find("Table");
            
        //    $.each(charvalues, function () {
        //        var charvalues = $(this);
        //        //alert($(this).find("xprevious").text());
        //        //chartData.push({ xtype: "Last Session", value: $(this).find("xprevious").text() });
        //        chartData.push({ xtype: "Readmission", value: $(this).find("xreadmis").text(),  color : "#FFFF00"});
        //        chartData.push({ xtype: "New", value: $(this).find("xnew").text(), color : "#FD4598" });
        //        //chartData.push({ xtype: "Totals", value: $(this).find("xtotal").text() });
        //    });

        //    var chart = AmCharts.makeChart( "chartdiv", {
        //        "type": "pie",
        //        "theme": "light",
        //        "addClassNames" : true,
        //        "dataProvider": chartData,
        //        "valueField": "value",
        //        "titleField": "xtype",
        //        "colorField" : "color",
        //        "outlineAlpha": 0.4,
        //        "depth3D": 15,
        //        "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
        //        "angle": 30,
        //        "export": {
        //            "enabled": false
        //        }
        //    } );
            
        //}

        $("body").on("click", ".bm_button_reload", function(e) {
            //alert("hi");
            fnPageLoad();
            //document.getElementById("barchart").innerHTML = "sdjhjksdhkjhdskhksda";
            e.preventDefault();
        });

        //fnPageLoad();
              
    </script>
    <div class="bm_academic_container">
        <div class="bm_academic_container_header">
            <div class="header_label1" id="header_label" runat="server">
                <span class="bm_am_header_round">Number of Students' With Graph</span>
            </div>
        </div>
        <div class="bm_academic_container_message">
            <div class="message" id="message" runat="server">
            </div>
        </div>
        <%--  <div class="bm_academic_container_body_button_section">
                    <div class="button_section_padding" >
                        <div class="button_section_style1">
                            
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="bm_academic_button1 bm_am_btn_approve"
                               />
                        </div>
                    </div>
                </div>--%>
        <div class="bm_academic_container_footer">
            <div class="footer_list_padding2">
                <div style="margin-left: 15px; margin-bottom: 0px; width: 100%;">
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
                            <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                    <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                        CssClass="label"></asp:Label>
                                </div>
                                <div class="bm_clt_ctl_100_special" style="width: 103px">
                                    <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--<div class="bm_ctl_container_100_special" style="display: inline-block; width: 110px">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 50px">
                                            <asp:Label ID="Label1" runat="server" Text="Term :" AssociatedControlID="xterm" CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 58px">
                                            <asp:DropDownList ID="xterm" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                        <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                            <asp:Label ID="Label2" runat="server" Text="Class :" AssociatedControlID="xclass"
                                                CssClass="label"></asp:Label>
                                        </div>
                                        <div class="bm_clt_ctl_100_special" style="width: 103px">
                                            <asp:DropDownList ID="xclass" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown"
                                                >
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
                                               >
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                            <%-- <div class="bm_ctl_container_100_special" style="display: inline-block;">
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
                            <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px; border: none; height: 32px; margin-right: 15px">
                                <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                    <%--<asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                                Width="25px" Height="25px" OnClick="fnFillDataGrid" CssClass="bm_academic_button_zoom bm_button_reload" />--%>
                                    <input type="image" src="/images/reload70.png" width="25px" height="25px" class="bm_academic_button_zoom bm_button_reload" />
                                    <%--  <input id="Button1" type="button" value="button" class="bm_button_reload"/>--%>
                                    <%--<button class="bm_button_reload"><img src="/images/reload70.png"></button>--%>
                                </div>
                            </div>
                            <%-- <div class="bm_ctl_container_50_50" style="float: left; width: 32px; margin-top: 5px;
                                        margin-left: 10px; border: none; height: 32px; margin-right: 15px">
                                        <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/printer-blue-icon.png"
                                                Width="25px" Height="25px" OnClientClick="fnPrintNumSchedule();" OnClick="fnFillDataGrid"
                                                CssClass="bm_academic_button_zoom" />
                                        </div>
                                    </div>--%>
                        </div>
                    </div>
                    <div class="grid_body">
                        <div id="grid" style="float: left; width: 600px; margin-top: 5px; visibility: hidden; ">
                            <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                PagerStyle-CssClass="PagerStyle" GridLines="None" OnDataBound="GridView1_DataBound1"
                                OnRowDataBound="OnRowDataBound" UseAccessibleHeaderText="true" RowStyle-Height="30" ShowHeaderWhenEmpty="True">--%>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                CssClass="bm_academic_grid" FooterStyle-CssClass="FooterStyle"
                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                PagerStyle-CssClass="PagerStyle" GridLines="None"
                                UseAccessibleHeaderText="true" RowStyle-Height="30" ShowHeaderWhenEmpty="False">
                                <HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="No." HeaderStyle-Width="20px" HeaderStyle-HorizontalAlign="Center">
                                          <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                       
                                      
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="xclass" HeaderText="Classes" ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Left" />

                                    <asp:BoundField DataField="xprevious" HeaderText="Previous<br/>Session" ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" HtmlEncode="False"/>

                                    <asp:BoundField DataField="xpromoted" HeaderText="Promoted<br/>To" ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" HtmlEncode="False"/>

                                    <asp:BoundField DataField="xyeardrop" HeaderText="Year End<br/>Dropout" ItemStyle-Width="120px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" HtmlEncode="False"/>

                                    <asp:BoundField DataField="xwithoutpayment" HeaderText="Waiting for Readmission" ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" HtmlEncode="False"/>

                                    <asp:BoundField DataField="xreadmis" HeaderText="Readmi- ssion"  ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="xnew" HeaderText="New Admission" ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="xdropout" HeaderText="Drop Out" ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="xtotal" HeaderText="Total" ItemStyle-Width="100px"
                                        ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>



                        </div>

                        <div style="float: left; margin-left: 2px; width: 580px;" runat="server" id="barchart">
                            <div>
                                <div id="chartdiv" style="width: 288px; height: 250px; display: inline-block; "></div>
                                <div id="chartdiv1" style="width: 288px; height: 250px; display: inline-block; "></div>
                            </div>

                            <div style="margin-top: 20px;">
                                <div id="chartdiv2" style="width: 288px; height: 250px; display: inline-block"></div>
                                <div id="chartdiv3" style="width: 288px; height: 250px; display: inline-block"></div>
                            </div>


                            <%--<div style="float: left;" runat="server" id="barchart1">
                              
                                <div id="chartdiv" ></div>

                            </div>--%>
                            <%-- <div style="float: left; width: 20px; padding-top: 20px;" runat="server" id="colorcode">
                                    </div>--%>
                        </div>
                </div>

            </div>
        </div>
    </div>
    <%--<div>
                    <asp:GridView ID="grd" ClientIDMode="Static" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">  
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />  
    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />  
    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />  
    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />  
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />  
    <SortedAscendingCellStyle BackColor="#FFF1D4" />  
    <SortedAscendingHeaderStyle BackColor="#B95C30" />  
    <SortedDescendingCellStyle BackColor="#F1E5CE" />  
    <SortedDescendingHeaderStyle BackColor="#93451F" />  
</asp:GridView>
                    </div>--%>
    <div style="clear: both; display: none;">
        <%--<asp:Chart ID="Chart2" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"
                        BorderlineWidth="0" Height="360px" Palette="None" PaletteCustomColors="Maroon"
                        Width="380px" BorderlineColor="64, 0, 64">--%>
        <asp:Chart ID="Chart2" runat="server" Height="360px"
            Width="380px">
            <Titles>
                <asp:Title ShadowOffset="10" Name="Items" />
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False"
                    LegendStyle="Row" Name="Default" />
            </Legends>
            <Series>
                <asp:Series Name="Default" />

                <%--  <asp:Series Name="Default" ChartArea="ChartArea1" XValueMember="key" YValueMembers="value" 
                                IsValueShownAsLabel="False" ChartType="Pie" >
                            </asp:Series>--%>
                <%--     <asp:Series Name="Series2" ChartArea="ChartArea1" XValueMember="xsession" YValueMembers="xprevious" LegendText="Last Session"
                                IsValueShownAsLabel="False" ChartType="Pie" Color="blue">
                            </asp:Series>
                            <asp:Series Name="Series3" ChartArea="ChartArea1" XValueMember="xsession" YValueMembers="xreadmis" LegendText="Re-Admission"
                                IsValueShownAsLabel="False" ChartType="Pie" Color="red">
                            </asp:Series>
                            <asp:Series Name="Series4" ChartArea="ChartArea1" XValueMember="xsession" YValueMembers="xnew" LegendText="New Admission"
                                IsValueShownAsLabel="False" ChartType="Pie" >
                            </asp:Series>--%>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
            </ChartAreas>
        </asp:Chart>
    </div>
    <div style="display: none">
        <asp:Chart ID="Chart1" runat="server" Width="650" Height="500">
            <%-- <Titles>
                                                <asp:Title Docking="Bottom" Text="Session Comparison">
                                                </asp:Title>
                                            </Titles>--%>
            <Series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" XValueMember="xsession" YValueMembers="xtotal" LegendText="Total"
                    IsValueShownAsLabel="False">
                </asp:Series>
                <asp:Series Name="Series2" ChartArea="ChartArea1" XValueMember="xsession" YValueMembers="xprevious" LegendText="Last Session"
                    IsValueShownAsLabel="False">
                </asp:Series>
                <asp:Series Name="Series3" ChartArea="ChartArea1" XValueMember="xsession" YValueMembers="xreadmis" LegendText="Re-Admission"
                    IsValueShownAsLabel="False">
                </asp:Series>
                <asp:Series Name="Series4" ChartArea="ChartArea1" XValueMember="xsession" YValueMembers="xnew" LegendText="New Admission"
                    IsValueShownAsLabel="False">
                </asp:Series>
            </Series>
            <Legends>
                <asp:Legend></asp:Legend>
            </Legends>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>

    </div>
    <div style="width: 100%; height: 15px; margin-bottom: 15px; color: #fff; clear: both;">
        ------
              
    </div>

    <asp:HiddenField ID="ctlid_v" runat="server" />
    <asp:HiddenField ID="_xdate" runat="server" />
    <asp:HiddenField ID="hiddenxdate" runat="server" />
    <asp:HiddenField ID="hiddenxrow" runat="server" />
    <asp:HiddenField ID="hiddenxstatus" runat="server" />
    <asp:HiddenField ID="_student" runat="server" />
    <asp:HiddenField ID="txtconformmessageValue3" runat="server" />
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
