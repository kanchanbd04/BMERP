<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="glmst1.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.sc.glmst1"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="OnlineTicketingSystem" %>
<%@ Import Namespace="OnlineTicketingSystem.Forms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" href="../../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <script src="../../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
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
        .style2 {
            vertical-align: top;
        }

        .style3 {
            height: 123px;
            width: 836px;
        }

        .style4 {
            height: 30px;
            width: 836px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #999966;
        }

        .style6 {
            text-align: right;
        }

        .style8 {
            width: 346px;
        }

        #Password1 {
            width: 151px;
        }

        #Password2 {
            width: 151px;
        }

        #TextArea1 {
            height: 68px;
            width: 188px;
        }

        #xuserinfo {
            height: 83px;
            width: 181px;
        }

        #xpass {
            width: 151px;
        }

        #expass {
            width: 151px;
        }

        #exrepass {
            width: 151px;
        }

        #exuserinfo {
            width: 180px;
            height: 74px;
            margin-top: 0px;
        }

        .style23 {
            width: 100%;
        }

        .style25 {
            width: 93px;
        }

        .style26 {
            width: 78px;
        }

        .style27 {
            width: 88px;
        }

        .style28 {
            width: 68px;
        }

        #xdesc {
        }

        .style30 {
            text-align: right;
            vertical-align: top;
        }

        .style31 {
            text-align: right;
            height: 21px;
        }

        .style32 {
            width: 157px;
            text-align: right;
            vertical-align: top;
            height: 24px;
        }

        .style34 {
            width: 346px;
            height: 24px;
        }

        .style400 {
            width: 938px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #F5F5F5;
        }

        #xhrc1 {
            width: 221px;
        }

        #xhrc2 {
            width: 221px;
        }

        #xhrc3 {
            width: 221px;
        }

        #xhrc4 {
            width: 221px;
        }

        #xhrc5 {
            width: 221px;
        }

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
    </style>
    <script language="javascript">

        function ConfirmMessage() {
            var selectedvalue = confirm("Do you want to delete data?");
            if (selectedvalue) {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=txtconformmessageValue.ClientID %>').value = "No";
            }
        }

        function ConfirmMessage1() {
            var selectedvalue = confirm("Do you want to delete data?");
            if (selectedvalue) {
                document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=txtconformmessageValue1.ClientID %>').value = "No";
            }
        }

        //function BlockUI(elementID) {
        //    var prm = Sys.WebForms.PageRequestManager.getInstance();
        //    prm.add_beginRequest(function () {
        //        $("#" + elementID).block({
        //            message: '<table align = "center"><tr><td>' +
        //                    '<img src="/images/loadingAnim.gif"/></td></tr></table>',
        //            css: {},
        //            overlayCSS: {
        //                backgroundColor: '#000000', opacity: 0.6
        //            }
        //        });
        //    });
        //    prm.add_endRequest(function () {
        //        $("#" + elementID).unblock();
        //    });
        //}

    </script>
    <script type="text/javascript" language="javascript">
        //function Func() {
        //    alert("hello!")
        //}
    </script>
    <%--<asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px" OnClick="btnUpdate_Click" />--%>
    <script type="text/javascript">

        $(document).ready(function () {
            //$('a#popup').live('click', function (e) {

            //    var page = $(this).attr("href")  //get url of link

            //    var $dialog = $('<div></div>')
            //        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
            //        .dialog({
            //            autoOpen: false,
            //            modal: true,
            //            height: 600,
            //            width: 'auto',
            //            title: "Role Permission",

            //            buttons: {
            //                "Close": function () { $dialog.dialog('close'); }
            //            },
            //            close: function (event, ui) {

            //                //                        __doPostBack(', '');  // To refresh gridview when user close dialog
            //            }
            //        });
            //    $dialog.dialog('open');
            //    e.preventDefault();
            //});

            <%-- BlockUI("<%=pnlpopup.ClientID %>");
            $.blockUI.defaults.css = {};--%>

        });

       
    </script>
    <%--   <script>
        $(function () {
            $("#<%=xeffdt.ClientID %>").datepicker();
        });
    </script>--%>
    <%--<asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                            OnClick="btnDelete_Click" Visible="False" />--%>
    <script type="text/javascript">

        $(document).ready(function () {

            <%-- $('#<%=business.ClientID %>').live('click', function (e) {
//                alert($("#<%= key.ClientID%>").val());
                var key1 = $("#<%= key.ClientID%>").val();
                // var page = $(this).attr("href")  //get url of link
                var page = "../../BMERP/zbusiness_sel_glmst_new.aspx?key=" + key1;
                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 600,
                    width: 1100,
                    title: "Select Business",

                    buttons: {
                        "Close": function () { $dialog.dialog('close'); }
                    },
                    close: function (event, ui) {

                        //                        __doPostBack(', '');  // To refresh gridview when user close dialog
                    }
                });
                $dialog.dialog('open');
                e.preventDefault();
            });--%>

            //$('.bm_tfccode').click(function () {
            $("body").on("click", ".bm_tfccode",function () {
                //alert($(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
                fnOpenChartofAccounts(<%= HttpContext.Current.Session["business"] %>,$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"),$(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(),$(this).parent(".bm_span2").siblings(".bm_span3").find(".bm_label1").attr("ID"));
            });

            $("body").on("click", ".bm_tempstr1",function () {
               
                fnOpenList(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"), $(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(), "glmst","xtempstr1");
                  

                $("#<%=xtempstr1.ClientID%>").focus();

                return false;
            });

            $("body").on("click", ".bm_cf1",function () {
               
                fnOpenList(<%= HttpContext.Current.Session["business"] %>, $(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").attr("ID"), $(this).parent(".bm_span2").siblings(".bm_span1").find(".bm_text1").val(), "glmst","xcf1");
                  

                $("#<%=xcf1.ClientID%>").focus();

                return false;
            });

        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog" style="display: none">
    </div>

    <div style="width: 60%; display: inline-block; vertical-align: top;">
        <table style="width: 98%; height: 111px; border: 1px solid black;">
            <tr>
                <td class="style4" colspan="2">
                    <strong>Chart of Accounts</strong>
                </td>
                <%--  <td class="style2" rowspan="2">
               
            </td>--%>
            </tr>
            <tr>
                <td class="style3">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style31" colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div id="msg" style="font-weight: bold; font-size: 12px; color: Red; text-align: center;"
                                            runat="server">
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                      <%--  <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <%--<tr>
                        <td class="style30">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                    </tr>--%>
                        <%-- <tr>
                        <td class="style32">
                            Row
                        </td>
                        <td class="style8">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="xrow" runat="server" Text="Label" Style="text-align: center; font-weight: 700;"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>--%>

                        <tr>
                            <td colspan="2">
                                <div class="bm_hotkey" style="clear: both; padding-left: 10px; padding-bottom: 5px">
                                    <table style="border: 1px solid white">
                                        <tr style="border: 1px solid white">
                                            <td style="background-color: Gray; color: black; margin: 1px">Hotkeys</td>
                                            <td style="background-color: silver; color: green; margin: 1px">Save - F10</td>
                                            <td style="background-color: silver; color: blue; margin: 1px">Update - F9</td>
                                            <td style="background-color: silver; color: red; margin: 1px">Delete - F6</td>

                                            <td style="background-color: silver; color: black; margin: 1px">Clear - F5</td>
                                            <%--   <td style="background-color: silver; color: darkcyan; margin: 1px">Add New Row - F12</td>--%>
                                        </tr>
                                    </table>
                                </div>
                            </td>

                        </tr>

                        <tr style="">
                            <td class="style32">Account
                            </td>
                            <td class="style8">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>

                                                    <span class="bm_span1">
                                                        <%-- <asp:TextBox ID="xlatefeeac" runat="server" Height="20px" Width="100px" CssClass="bm_text1"></asp:TextBox>--%>
                                                        <asp:TextBox ID="xacc" runat="server" Width="151px" CssClass="bm_text1"></asp:TextBox>
                                                    </span>
                                                    <span class="bm_span2">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_tfccode" />
                                                    </span>
                                                    <span class="bm_span3" style="display: none;">
                                                        <asp:Label ID="xlatefeeactitle" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                    </span>

                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/search32x32.png" runat="server"
                                                CssClass="bm_academic_list" Width="20px" Height="20px" OnClick="ImageButton1_OnClick" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Description
                            </td>
                            <td class="style8">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="xdesc" runat="server" Width="300px" Height="22px"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Account Type
                            </td>
                            <td class="style8">
                                <table class="style23">
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Asset" value="Asset" runat="server" Text="Asset" ForeColor="Black"
                                                        GroupName="acctype"  />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Expenditure" value="Expenditure" Text="Expenditure" runat="server"
                                                        ForeColor="Black" GroupName="acctype" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Income" value="Income" Text="Income" runat="server" ForeColor="Black"
                                                        GroupName="acctype" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel21" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Liability" Value="Liability" Text="Liability" runat="server"
                                                        ForeColor="Black" GroupName="acctype" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Account Usage
                            </td>
                            <td class="style34">
                                <table class="style23">
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="AP" Value="AP" Text="AP" runat="server" ForeColor="Black" GroupName="accusage" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel23" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="AR" Value="AR" Text="AR" runat="server" ForeColor="Black" GroupName="accusage" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Bank" Value="Bank" Text="Bank" runat="server" ForeColor="Black"
                                                        GroupName="accusage" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel25" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Cash" Value="Cash" Text="Cash" runat="server" ForeColor="Black"
                                                        GroupName="accusage" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Ledger" Value="Ledger" Text="Ledger" runat="server" ForeColor="Black"
                                                        GroupName="accusage"  />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Account Source
                            </td>
                            <td class="style34">
                                <table class="style23">
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel26" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Customer" Value="Customer" Text="Customer" runat="server" ForeColor="Black"
                                                        GroupName="accsource" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel27" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Employee" Value="Employee" Text="Employee" runat="server" ForeColor="Black"
                                                        GroupName="accsource" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="None" Value="None" Text="None" runat="server" ForeColor="Black"
                                                        GroupName="accsource"  />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel28" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Subaccount" Value="Subaccount" Text="Subaccount" runat="server"
                                                        ForeColor="Black" GroupName="accsource" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel29" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Supplier" Value="Supplier" Text="Supplier" runat="server" ForeColor="Black"
                                                        GroupName="accsource" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel30" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Bank1" Value="Bank" Text="Bank" runat="server" ForeColor="Black"
                                                        GroupName="accsource" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel32" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton ID="Student1" Value="Student" Text="Student" runat="server" ForeColor="Black"
                                                        GroupName="accsource" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Level1
                            </td>
                            <td class="style34">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="xhrc1" runat="server" Height="21px" Width="300px" AutoPostBack="True"
                                            OnSelectedIndexChanged="xhrc1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%--<asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px" OnClick="btnUpdate_Click" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Level2
                            </td>
                            <td class="style34">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="xhrc2" runat="server" Height="21px" Width="300px" AutoPostBack="True"
                                            OnSelectedIndexChanged="xhrc2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%--<asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                            OnClick="btnDelete_Click" Visible="False" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Level3
                            </td>
                            <td class="style34">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="xhrc3" runat="server" Height="21px" Width="300px" AutoPostBack="True"
                                            OnSelectedIndexChanged="xhrc3_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc2" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%--<asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Level4
                            </td>
                            <td class="style34">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="xhrc4" runat="server" Height="21px" Width="300px" AutoPostBack="True"
                                            OnSelectedIndexChanged="xhrc4_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc3" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Level5
                            </td>
                            <td class="style34">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="xhrc5" runat="server" Height="21px" Width="300px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc1" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc2" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc3" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="xhrc4" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%-- <select id="xhrc5" runat="server">
                            </select>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Special Account Group
                            </td>
                            <td class="style34">
                                 <asp:UpdatePanel ID="UpdatePanel34" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                <%--<asp:DropDownList ID="xtempstr1" runat="server" Height="21px" Width="300px">
                                </asp:DropDownList>--%>
                                <span class="bm_span1">
                                                        
                                                        <asp:TextBox ID="xtempstr1" runat="server" Width="300px" CssClass="bm_text1"></asp:TextBox>
                                                    </span>
                                                    <span class="bm_span2">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_tempstr1" />
                                                    </span>
                                                    <span class="bm_span3" style="display: none;">
                                                        <asp:Label ID="xtempstr1lbl" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                    </span>
                                
                                 
                                                   
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr>
                            <td class="style32">Indirect Cash Flow Setup
                            </td>
                            <td class="style34">
                                 <asp:UpdatePanel ID="UpdatePanel35" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                <%--<asp:DropDownList ID="xcf1" runat="server" Height="21px" Width="300px">
                                </asp:DropDownList>--%>
                                
                                 <span class="bm_span1">
                                                        
                                                        <asp:TextBox ID="xcf1" runat="server" Width="300px" CssClass="bm_text1"></asp:TextBox>
                                                    </span>
                                                    <span class="bm_span2">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/list-am32x32.png" Height="20px" Width="20px" ImageAlign="Top" CssClass="bm_academic_list3 bm_cf1" />
                                                    </span>
                                                    <span class="bm_span3" style="display: none;">
                                                        <asp:Label ID="Label1" runat="server" Text="" CssClass="bm_label1"></asp:Label>
                                                    </span>
                                                    
                                                     </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                            </td>
                        </tr>

                        <%-- <tr>
                        <td class="style32">
                            Effected Date
                        </td>
                        <td class="style34">
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="xeffdt" runat="server" Width="151px"></asp:TextBox>
                                    [MM/DD/YYYY]
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        </tr>--%>

                        <tr>
                            <td class="style32">Active?
                            </td>
                            <td class="style8">
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="zactive" runat="server" Text="Active" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <%-- <tr>
                        <td class="style32">
                            Business
                        </td>
                        <td class="style8">
                            <asp:LinkButton ID="business" runat="server">Select Business</asp:LinkButton>
                            
                        </td>
                    </tr>--%>
                        <tr>
                            <td class="style32">Entry By
                            </td>
                            <td class="style8">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="zemail" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                 <%--       <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">Update By
                            </td>
                            <td class="style8">
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="xemail" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        <%--<asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">&nbsp;
                            </td>
                            <td class="style8">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table class="style23">
                                            <tr>
                                                <td class="style27">
                                                    <%--<asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" Font-Bold="True"
                                            Height="30px" OnClick="btnClear_Click" />--%>
                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" Font-Bold="True"
                                                        Height="30px" OnClick="btnClear_Click" />
                                                </td>
                                                <td class="style26">
                                                    <%--<asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Font-Bold="True"
                                            Height="30px" OnClick="btnAdd_Click" />--%>
                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Font-Bold="True"
                                                        Height="30px" OnClick="btnAdd_Click" />
                                                </td>
                                                <td class="style25">
                                                    <%--<asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                            Text="Update" Width="100px" OnClick="btnUpdate_Click" />--%>
                                                    <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                                        Text="Update" Width="100px" OnClick="btnUpdate_Click" />
                                                </td>
                                                <td class="style28">
                                                    <%--<asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                            Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                            OnClick="btnDelete_Click" Visible="False" />--%>
                                                    <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                                        Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage();"
                                                        OnClick="btnDelete_Click" />
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%--<asp:PostBackTrigger ControlID="btnClear" />--%>
                                        <asp:PostBackTrigger ControlID="btnAdd" />
                                        <asp:PostBackTrigger ControlID="btnUpdate" />
                                        <asp:PostBackTrigger ControlID="btnDelete" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <%--   <tr>
                        <td class="style30">
                            &nbsp;
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                    </tr>--%>


                        <tr>
                            <td class="style30">
                                <%-- &nbsp;&nbsp;--%>
                            </td>
                            <td class="style8">&nbsp;
                            <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                                 <asp:HiddenField ID="txtconformmessageValue1" runat="server" />
                                <asp:UpdatePanel ID="UpdatePanel31" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:HiddenField
                                            ID="key" runat="server" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        <%--<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <table style="margin-top: 10px;">
            <tr>
                <td class="style400" colspan="2">
                    <asp:Label ID="level1" runat="server" Text="List of Account(s)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30" colspan="2">
                    <%-- <asp:UpdatePanel ID="UpdatePanel999" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>--%>

                    <%--<asp:Panel ID="Panel2" runat="server" Height="410px">--%>

                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <%--<asp:TemplateField HeaderText="Row">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' OnClick="FillControls"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="No" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <%-- <asp:Label ID="lblsl" runat="server" Text=""></asp:Label>--%>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Account" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xacc" runat="server" Text='<%#Eval("xacc") %>' OnClick="FillControls"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>

                            <%--  <asp:BoundField DataField="xacc" HeaderText="Account" />--%>
                            <asp:BoundField DataField="xdesc" HeaderText="Description" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="xacctype" HeaderText="Account Type" />
                            <asp:BoundField DataField="xaccsource" HeaderText="Account Source" />
                            <%--<asp:BoundField DataField="xeffdt" HeaderText="Effected Date" DataFormatString="{0:d}" />--%>
                            <asp:TemplateField HeaderText="Active?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="status0" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                    <%-- </asp:Panel>--%>
                    <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>--%>

                </td>
            </tr>
        </table>
    </div>

    <div style="width: 38%; display: inline-block; vertical-align: top;">
        <table class="style23">
            <tr>
                <td class="style400">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblSubAcc" runat="server" Text="Subaccount(s) of ()"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                           <%-- <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="style8">

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <script>
                                $("body").on("click", ".btnAddSub", function () {
                                    $('#<%= xsub.ClientID%>').val("");
                                    $('#<%= xdesc1.ClientID%>').val("");
                                    $('#<%= xoffadd.ClientID%>').val("");
                                    var lblsubtitle1 = $('#<%= lblSubAcc.ClientID%>').text();
                                    $('#<%= subtitle.ClientID%>').html(lblsubtitle1);
                                    //alert(lblsubtitle1);

                                    document.getElementById("<%= btnUpdate1.ClientID%>").style.visibility = 'hidden';
                                    document.getElementById("<%= btnSave1.ClientID%>").style.visibility = 'visible';

                                    <%-- document.getElementById("<%= xsub.ClientID%>").disabled = false;--%>

                                    $("#<%=xsub.ClientID%>").prop('readonly', false);

                                    var xacc1 = $('#<%= key.ClientID%>').val();
                                    $find('modalpopup').show();
                                    //alert("hi");
                                    //alert($('#<%= key.ClientID%>').val());

                                });
                            </script>

                            <asp:LinkButton ID="subacc" runat="server" CssClass="btnAddSub">Add Subaccount</asp:LinkButton>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                           <%-- <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <script>
                                $("body").on("click", ".btnEditSub", function () {

                                 var row = this.parentNode.parentNode;
                                    var rowIndex = row.rowIndex - 1;
                                    //var cell = this.parentNode.cellIndex;

                                    var grid = document.getElementById('<%=GridView1.ClientID %>');
                                    var xsub1 = grid.rows[rowIndex + 1].cells[1].innerHTML;
                                    var xacc1 = $('#<%= key.ClientID%>').val();
                                    //alert(xsub1);

                                    <%--  document.getElementById("<%= xsub.ClientID%>").disabled = true;--%>
                                    $("#<%=xsub.ClientID%>").prop('readonly', true);

                                    $('#<%= xsub.ClientID%>').val(xsub1);
                                      $('#<%= xdesc1.ClientID%>').val("");
                                      $('#<%= xoffadd.ClientID%>').val("");
                                      var lblsubtitle1 = $('#<%= lblSubAcc.ClientID%>').text();
                                      $('#<%= subtitle.ClientID%>').html(lblsubtitle1);
                                      //alert(lblsubtitle1);

                                    document.getElementById("<%= btnSave1.ClientID%>").style.visibility = 'hidden';
                                    document.getElementById("<%= btnUpdate1.ClientID%>").style.visibility = 'visible';

                                    
                                     
                                    $.ajax({
                                        url: "glmst1.aspx/fnFetchValue",

                                        type: "POST",

                                        data: "{'xacc1' : '" + xacc1 + "', 'xsub1':'" + xsub1 + "'}",

                                         //dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {

                            var r = res.d;
                            var xcom = r.split("|");
                            if (xcom[0] == "success") {
                                $("#<%= xdesc1.ClientID%>").val(xcom[2]);
                                $("#<%= xoffadd.ClientID%>").val(xcom[3]);
                            }
                            else if (xcom[0] == "nodata") {
                                $('#<%= xdesc1.ClientID%>').val("");
                                $('#<%= xoffadd.ClientID%>').val("");
                            } else {
                                alert(r);
                                $('#<%= xdesc1.ClientID%>').val("");
                                $('#<%= xoffadd.ClientID%>').val("");
                            }


                        },
                                         error: function (err) {
                                             alert("ERROR : " + err);
                                             $('#<%= xdesc1.ClientID%>').val("");
                                             $('#<%= xoffadd.ClientID%>').val("");

                                         }


                                    });

                                      $find('modalpopup').show();
                                      //alert("hi");
                                      //alert($('#<%= key.ClientID%>').val());

                                  });
                            </script>

                            <%--<asp:Panel ID="Panel1" runat="server" Height="502px" ScrollBars="Auto" Width="536px">--%>
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                AutoGenerateColumns="False">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                            <%-- <asp:Label ID="lblsl" runat="server" Text=""></asp:Label>--%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="xsub" HeaderText="Sub Account" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="xdesc" HeaderText="Description" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="xoffadd" HeaderText="Address" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="subedit" runat="server" CssClass="btnEditSub">Edit</asp:LinkButton>
                                            <asp:LinkButton ID="subdelete" runat="server" CssClass="btnDeleteSub" OnClientClick="javascript:ConfirmMessage1();"
                                                        OnClick="btnDeleteSub_Click">Delete</asp:LinkButton>
                                            <%--<asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

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
                            <%--</asp:Panel>--%>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                           <%-- <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>

    <div id="message" runat="server">
    </div>
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>

    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modal" BehaviorID="modalpopup">
    </cc1:ModalPopupExtender>
    <%-- PopupDragHandleControlID="pnlpopup" --%>>
            <%-- <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="530px" Width="400px"
                Style="display:none">
                </asp:Panel>--%>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="300px" Width="400px"
        Style="display: none">
        <table width="100%" style="border: Solid 3px #619CFD; width: 100%; height: 100%; border-collapse: collapse;"
            cellpadding="0" cellspacing="0">
            <tr style="background-color: #619CFD">
                <td style="height: 20px; color: white; font-size: 16px;" align="left" runat="server" id="subtitle">Sub Account of : 
                </td>
            </tr>
            <tr>
                <td align="left" style="padding: 5px;">
                    <table style="border: none;">
                        <tr>
                            <td>Sub Account
                            </td>
                            <td>:
                            </td>
                            <td id="lbldate11">
                                <asp:TextBox ID="xsub" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Description
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:TextBox ID="xdesc1" runat="server" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Address
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:TextBox ID="xoffadd" runat="server" Width="250px" TextMode="MultiLine" Height="60px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>


            <tr>
                <td align="center" style="padding-bottom: 5px;">
                    <%--<asp:Button ID="btnOk" runat="server" Text="Save" CssClass="bm_academic_button1 bm_am_btn_ok"
                                    OnClick="btnOk_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"
                                    OnClick="btnDelete_Click" />--%>
                    <%--<asp:Button ID="btnOk" runat="server" Text="Save" CssClass="bm_academic_button1 bm_am_btn_ok"/>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="bm_academic_button1 bm_am_btn_delete"/>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="bm_academic_button1 bm_am_btn_cancel" />--%>

                    <%--<input type="button" id="btnClear1" value="Clear">--%>
                    <%-- <input type="button" id="btnSave1" value="Save">--%>
                    <%--  <input type="button" id="btnUpdate1" value="Update">--%>
                    <%--<input type="button" id="btnDelete1" value="Delete">--%>

                    <%--  <asp:UpdatePanel ID="UpdatePanel33" runat="server" >
                        <ContentTemplate>--%>
                    <asp:Button ID="btnSave1" runat="server" Text="Save" OnClick="btnSave1_OnClick"/>
                    <asp:Button ID="btnUpdate1" runat="server" Text="Update" OnClick="btnUpdate1_OnClick"/>

                    <%--           </ContentTemplate>
                        <Triggers>
                         
                        </Triggers>
                    </asp:UpdatePanel>--%>
                    <input type="button" id="btnCancel" value="Close">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
