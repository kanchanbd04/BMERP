<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zbusiness_sel_glmst_new.aspx.cs"
    Inherits="OnlineTicketingSystem.forms.BMERP.zbusiness_sel_glmst_new" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        #TextArea1
        {
            height: 191px;
        }
        #TextArea2
        {
            height: 190px;
            width: 162px;
        }
        #TextArea3
        {
            height: 193px;
            width: 182px;
        }
        #msg
        {
            color: #FF0000;
        }
        #xhrc1
        {
            width: 221px;
        }
        #xhrc2
        {
            width: 221px;
        }
        #xhrc3
        {
            width: 221px;
        }
        #xhrc4
        {
            width: 221px;
        }
        #xhrc5
        {
            width: 221px;
        }
    </style>
    <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript">
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
    <%--<script type="text/javascript">
        $(document).ready(function () {
            var xhrc11 = $("#<%= xhrc1.ClientID%>");
            var xhrc22 = $("#<%= xhrc2.ClientID%>");
            var xhrc33 = $("#<%= xhrc3.ClientID%>");
            var xhrc44 = $("#<%= xhrc4.ClientID%>");
            var xhrc55 = $("#<%= xhrc5.ClientID%>");

            $.ajax({
                url: "zbusiness_sel_glmst.aspx/Level1",

                type: "POST",

                data: "{}",

                dataType: "json",
                contentType: "application/json; charset=utf-8",

                async: false,
                success: function (res) {
                    //xhrc11.empty();
                    xhrc22.append($("<option>").val("-1").text("[Select]"));
                    xhrc33.append($("<option>").val("-1").text("[Select]"));
                    xhrc44.append($("<option>").val("-1").text("[Select]"));
                    xhrc55.append($("<option>").val("-1").text("[Select]"));
                    //alert("success");
                    r = res.d;

                    if (r) {
                        //alert("success");
                        //xhrc22.append($("<option>").val("-1").text("[Select]"));
                        xhrc22.prop("disabled", true);
                        xhrc33.prop("disabled", true);
                        xhrc44.prop("disabled", true);
                        xhrc55.prop("disabled", true);
                        $(r).each(function (index, item) {
                            xhrc11.append($("<option>").val(item.Value).text(item.Text));
                        });
                    }
                },
                error: function (err) {
                    alert("ERROR : " + err);
                }


            });

            xhrc11.change(function () {
                if ($(this).val() == "-1") {
                    xhrc22.empty();
                    xhrc33.empty();
                    xhrc44.empty();
                    xhrc55.empty();
                    xhrc22.append($("<option>").val("-1").text("[Select]"));
                    xhrc33.append($("<option>").val("-1").text("[Select]"));
                    xhrc44.append($("<option>").val("-1").text("[Select]"));
                    xhrc55.append($("<option>").val("-1").text("[Select]"));
                    xhrc22.val("-1");
                    xhrc33.val("-1");
                    xhrc44.val("-1");
                    xhrc55.val("-1");
                    xhrc22.prop("disabled", "disabled");
                    xhrc33.prop("disabled", "disabled");
                    xhrc44.prop("disabled", "disabled");
                    xhrc55.prop("disabled", "disabled");
                } else {

                    //alert($(this).val());
                    $.ajax({
                        url: "zbusiness_sel_glmst.aspx/Level2",

                        type: "POST",

                        data: "{'xhrc1': '" + $(this).val() + "'}",
                        //data: "{}",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {
                            xhrc22.empty();
                            xhrc33.empty();
                            xhrc44.empty();
                            xhrc55.empty();
                            //xhrc22.append($("<option>").val("-1").text("[Select]"));
                            xhrc33.append($("<option>").val("-1").text("[Select]"));
                            xhrc44.append($("<option>").val("-1").text("[Select]"));
                            xhrc55.append($("<option>").val("-1").text("[Select]"));
                            //alert("success");
                            r = res.d;

                            if (r) {
                                //alert("success");
                                //xhrc22.append($("<option>").val("-1").text("[Select]"));
                                xhrc22.prop("disabled", false);
                                xhrc33.prop("disabled", true);
                                xhrc44.prop("disabled", true);
                                xhrc55.prop("disabled", true);
                                $(r).each(function (index, item) {
                                    xhrc22.append($("<option>").val(item.Value).text(item.Text));
                                });
                            }
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });
                }
            });

            xhrc22.change(function () {
                if ($(this).val() == "-1") {
                    //xhrc22.empty();
                    xhrc33.empty();
                    xhrc44.empty();
                    xhrc55.empty();
                    //xhrc22.append($("<option>").val("-1").text("[Select]"));
                    xhrc33.append($("<option>").val("-1").text("[Select]"));
                    xhrc44.append($("<option>").val("-1").text("[Select]"));
                    xhrc55.append($("<option>").val("-1").text("[Select]"));
                    //xhrc22.val("-1");
                    xhrc33.val("-1");
                    xhrc44.val("-1");
                    xhrc55.val("-1");
                    //xhrc22.prop("disabled", "disabled");
                    xhrc33.prop("disabled", "disabled");
                    xhrc44.prop("disabled", "disabled");
                    xhrc55.prop("disabled", "disabled");
                } else {

                    //alert($(this).val());
                    $.ajax({
                        url: "zbusiness_sel_glmst.aspx/Level3",

                        type: "POST",

                        data: "{'xhrc1': '" + xhrc11.val() + "', 'xhrc2' : '" + $(this).val() + "'}",
                        //data: "{}",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {
                            //xhrc22.empty();
                            xhrc33.empty();
                            xhrc44.empty();
                            xhrc55.empty();
                            //xhrc22.append($("<option>").val("-1").text("[Select]"));
                            //xhrc33.append($("<option>").val("-1").text("[Select]"));
                            xhrc44.append($("<option>").val("-1").text("[Select]"));
                            xhrc55.append($("<option>").val("-1").text("[Select]"));
                            //alert("success");
                            r = res.d;

                            if (r) {
                                //alert("success");
                                //xhrc22.append($("<option>").val("-1").text("[Select]"));
                                //xhrc22.prop("disabled", false);
                                xhrc33.prop("disabled", false);
                                xhrc44.prop("disabled", true);
                                xhrc55.prop("disabled", true);
                                $(r).each(function (index, item) {
                                    xhrc33.append($("<option>").val(item.Value).text(item.Text));
                                });
                            }
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });
                }
            });

            xhrc33.change(function () {
                if ($(this).val() == "-1") {
                    //xhrc22.empty();
                    //xhrc33.empty();
                    xhrc44.empty();
                    xhrc55.empty();
                    //xhrc22.append($("<option>").val("-1").text("[Select]"));
                    //xhrc33.append($("<option>").val("-1").text("[Select]"));
                    xhrc44.append($("<option>").val("-1").text("[Select]"));
                    xhrc55.append($("<option>").val("-1").text("[Select]"));
                    //xhrc22.val("-1");
                    //xhrc33.val("-1");
                    xhrc44.val("-1");
                    xhrc55.val("-1");
                    //xhrc22.prop("disabled", "disabled");
                    //xhrc33.prop("disabled", "disabled");
                    xhrc44.prop("disabled", "disabled");
                    xhrc55.prop("disabled", "disabled");
                } else {

                    //alert($(this).val());
                    $.ajax({
                        url: "zbusiness_sel_glmst.aspx/Level4",

                        type: "POST",

                        data: "{'xhrc1': '" + xhrc11.val() + "', 'xhrc2' : '" + xhrc22.val() + "', 'xhrc3' : '" + $(this).val() + "'}",
                        //data: "{}",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {
                            //xhrc22.empty();
                            //xhrc33.empty();
                            xhrc44.empty();
                            xhrc55.empty();
                            //xhrc22.append($("<option>").val("-1").text("[Select]"));
                            //xhrc33.append($("<option>").val("-1").text("[Select]"));
                            //xhrc44.append($("<option>").val("-1").text("[Select]"));
                            xhrc55.append($("<option>").val("-1").text("[Select]"));
                            //alert("success");
                            r = res.d;

                            if (r) {
                                //alert("success");
                                //xhrc22.append($("<option>").val("-1").text("[Select]"));
                                //xhrc22.prop("disabled", false);
                                //xhrc33.prop("disabled", false);
                                xhrc44.prop("disabled", false);
                                xhrc55.prop("disabled", true);
                                $(r).each(function (index, item) {
                                    xhrc44.append($("<option>").val(item.Value).text(item.Text));
                                });
                            }
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });
                }
            });

            xhrc44.change(function () {
                if ($(this).val() == "-1") {
                    //xhrc22.empty();
                    //xhrc33.empty();
                    //xhrc44.empty();
                    xhrc55.empty();
                    //xhrc22.append($("<option>").val("-1").text("[Select]"));
                    //xhrc33.append($("<option>").val("-1").text("[Select]"));
                    //xhrc44.append($("<option>").val("-1").text("[Select]"));
                    xhrc55.append($("<option>").val("-1").text("[Select]"));
                    //xhrc22.val("-1");
                    //xhrc33.val("-1");
                    //xhrc44.val("-1");
                    xhrc55.val("-1");
                    //xhrc22.prop("disabled", "disabled");
                    //xhrc33.prop("disabled", "disabled");
                    //xhrc44.prop("disabled", "disabled");
                    xhrc55.prop("disabled", "disabled");
                } else {

                    //alert($(this).val());
                    $.ajax({
                        url: "zbusiness_sel_glmst.aspx/Level5",

                        type: "POST",

                        data: "{'xhrc1': '" + xhrc11.val() + "', 'xhrc2' : '" + xhrc22.val() + "', 'xhrc3' : '" + xhrc33.val() + "',  'xhrc4' : '" + $(this).val() + "'}",
                        //data: "{}",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",

                        async: false,
                        success: function (res) {
                            //xhrc22.empty();
                            //xhrc33.empty();
                            //xhrc44.empty();
                            xhrc55.empty();
                            //xhrc22.append($("<option>").val("-1").text("[Select]"));
                            //xhrc33.append($("<option>").val("-1").text("[Select]"));
                            //xhrc44.append($("<option>").val("-1").text("[Select]"));
                            //xhrc55.append($("<option>").val("-1").text("[Select]"));
                            //alert("success");
                            r = res.d;

                            if (r) {
                                //alert("success");
                                //xhrc22.append($("<option>").val("-1").text("[Select]"));
                                //xhrc22.prop("disabled", false);
                                //xhrc33.prop("disabled", false);
                                //xhrc44.prop("disabled", false);
                                xhrc55.prop("disabled", false);
                                $(r).each(function (index, item) {
                                    xhrc44.append($("<option>").val(item.Value).text(item.Text));
                                });
                            }
                        },
                        error: function (err) {
                            alert("ERROR : " + err);
                        }


                    });
                }
            });

        });
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox").click(function () {
                //Get number of checkboxes in list either checked or not checked
                var totalCheckboxes = $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox").size();
                //Get number of checked checkboxes in list
                var checkedCheckboxes = $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox:checked").size();
                //Check / Uncheck top checkbox if all the checked boxes in list are checked
                $("#<%=GridView1.ClientID%> input[id*='chkall']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
            });

            $("#<%=GridView1.ClientID%> input[id*='chkall']:checkbox").click(function () {
                //Check/uncheck all checkboxes in list according to main checkbox 
                $("#<%=GridView1.ClientID%> input[id*='selbiz']:checkbox").attr('checked', $(this).is(':checked'));
            });
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <div>
        <table class="style1">
            <tr align="center">
                <td>
                    <div id="xuser" style="font-weight: bold; color: #FFFFFF; font-size: medium; background-color: #996633;"
                        runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; background-color: #FFFFFF">
                    <div id="msg" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <%--<table width="100%">
                        <tr>
                            <td class="style2">
                                <strong>Select Business</strong></td>
                            <td>
                                <asp:DropDownList ID="xorg" runat="server" Height="22px" Width="381px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <%--     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>--%>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateColumns="False" Style="font-size: small" OnRowDataBound="GridView1_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select Business">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True"/>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="selbiz" runat="server" AutoPostBack="True" OnCheckedChanged="selbiz_OnCheckedChanged" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="zid" HeaderText="Business ID" />
                                        <asp:BoundField DataField="zorg" HeaderText="Business" />
                                        <asp:TemplateField HeaderText="Level1">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="level1" runat="server" Width="150" AutoPostBack="true" OnSelectedIndexChanged="level1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level2">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="level2" runat="server" Width="150" AutoPostBack="true" OnSelectedIndexChanged="level2_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level3">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="level3" runat="server" Width="150" AutoPostBack="true" OnSelectedIndexChanged="level3_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level4">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="level4" runat="server" Width="150" AutoPostBack="true" OnSelectedIndexChanged="level4_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level5">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="level5" runat="server" Width="150" AutoPostBack="true" OnSelectedIndexChanged="level5_SelectedIndexChanged">
                                                </asp:DropDownList>
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
                                <%--    </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </td>
                        </tr>
                        <%--<tr><td>
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td></tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="btnPermission" runat="server" Text="Save" Width="99px" 
                        OnClick="btnPermission_Click1" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="99px" Visible="False"
                        OnClick="btnUpdate_Click1" />
                </td>
            </tr>
            <tr align="center">
                <td>
                    <div id="dialog" style="display: none">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
