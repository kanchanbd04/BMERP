<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zbusiness_sel_ms.aspx.cs"
    Inherits="OnlineTicketingSystem.forms.BMERP.zbusiness_sel_ms" EnableEventValidation="false" %>

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
        .style2
        {
            width: 567px;
            text-align: center;
        }
        .style4
        {
            width: 192px;
            text-align: left;
        }
        .style5
        {
            width: 213px;
            text-align: left;
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
        $(function () {
            //debugger
            $("[id*=TreeView1] input[type=checkbox]").bind("click", function () {
                //<%= Label1.ClientID%>.val($(this).val()); 
                //alert($(this));
                var table = $(this).closest("table");
                if (table.next().length > 0 && table.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var parentDIV = $(this).closest("DIV");

                    var childDiv = table.next();
                    //var childDiv1 = table.prev();
                    var isChecked = $(this).is(":checked");
                    $("input[type=checkbox]", childDiv).each(function () {
                        if (isChecked) {
                            //alert('child checked1');
                            $(this).attr("checked", "checked");
                            $("input[type=checkbox]", parentDIV.prev()).prop('checked', true);

                        }

                        else {
                            $(this).removeAttr("checked");
                            if (isChecked) {
                                // alert('child checked2');
                                $("input[type=checkbox]", parentDIV.prev()).prop('checked', true);
                            }
                            else {
                                $("input[type=checkbox]", parentDIV.prev()).prop('checked', false);
                            }
                        }
                    });
                } else {
                    //Is Child CheckBox
                    var parentDIV = $(this).closest("DIV");
                    var parentdivchecked1 = $(this).is(":checked");
                    //var childDiv1 = table.next();
                    var childDiv1 = table.prev();
                    if ($("input[type=checkbox]", parentDIV).length == $("input[type=checkbox]:checked", parentDIV).length) {
                        // alert('child checked');
                        $("input[type=checkbox]", parentDIV.prev()).prop('checked', true);
                    } else {

                        $("input[type=checkbox]", parentDIV).each(function () {
                            if (parentdivchecked1) {
                                $("input[type=checkbox]", parentDIV.prev()).prop('checked', true);


                            }
                            else {
                                $("input[type=checkbox]", parentDIV.prev()).prop('checked', false);

                            }

                        });

                    }
                }
            });
        })
 
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
                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" ShowCheckBoxes="All"
                        class="tree" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <%--<Nodes>
                            
                            <asp:TreeNode Text="Super Config" Value="super">
                                <asp:TreeNode Text="Module Permission" Value="supermodper"></asp:TreeNode>
                            </asp:TreeNode>
                            
                            <asp:TreeNode Text="System Config " Value="sc">
                                <asp:TreeNode Text="Business Info" Value="scbizinfo"></asp:TreeNode>
                                <asp:TreeNode Text="User " Value="scuser">
                                    <asp:TreeNode Text="Add Button" Value="scuaddbt"></asp:TreeNode>
                                    <asp:TreeNode Text="Update Button" Value="scuupdbt"></asp:TreeNode>
                                    <asp:TreeNode Text="Delete Button" Value="scudelbt"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Reports" Value="scrpt"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Text="Master Setup " Value="ms">
                                <asp:TreeNode Text="Customer" Value="mscus">
                                    <asp:TreeNode Text="Customer Info" Value="mscusinfo">
                                        <asp:TreeNode Text="Add Button" Value="mscusaddbt"></asp:TreeNode>
                                        <asp:TreeNode Text="Update Button" Value="mscusupdbtn"></asp:TreeNode>
                                        <asp:TreeNode Text="Delete Button" Value="mscusdelbtn"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Customer Config" Value="mscusconf"></asp:TreeNode>
                                    <asp:TreeNode Text="Report" Value="mscusrpt"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Supplier" Value="mssup">
                                    <asp:TreeNode Text="Supplier Info" Value="mssupinfo"></asp:TreeNode>
                                    <asp:TreeNode Text="Supplier Config" Value="mssupconf"></asp:TreeNode>
                                    <asp:TreeNode Text="Report" Value="mssuprpt"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Item" Value="msitem">
                                    <asp:TreeNode Text="Item Info" Value="msiteminfo"></asp:TreeNode>
                                    <asp:TreeNode Text="Item Config" Value="msitemconf"></asp:TreeNode>
                                    <asp:TreeNode Text="Report" Value="msitemrpt"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Bank" Value="msbank">
                                    <asp:TreeNode Text="Bank Info" Value="msbankinfo"></asp:TreeNode>
                                    <asp:TreeNode Text="Bank Config" Value="msbankconf"></asp:TreeNode>
                                    <asp:TreeNode Text="Report" Value="msbankrpt"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Config" Value="msconf">
                                    <asp:TreeNode Text="Type" Value="msconftype"></asp:TreeNode>
                                    <asp:TreeNode Text="Code" Value="msconfcode"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Report" Value="msrpt"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>--%>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="font-size: large">
                    <asp:Label ID="Label1" runat="server" Text="Select Account(s) for Business" Style="font-weight: 700;
                        color: #0033CC; font-size: medium;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td class="style5">
                                <asp:Label ID="Label2" runat="server" Text="Account(s) List" Style="font-weight: 700;
                                    color: #0033CC; font-size: medium;"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Selected Account(s) List" Style="font-weight: 700;
                                    color: #0033CC; font-size: medium;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                <asp:Panel ID="Panel1" runat="server" Height="169px" Width="285px">
                                   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>--%>
                                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                AutoGenerateColumns="False" Style="font-size: small">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Account">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xacc0" runat="server" Text='<%#Eval("xacc") %>' OnClick="FillControls"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="xdesc" HeaderText="Description" />
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
                                       <%-- </ContentTemplate>
                                        <Triggers>
                                             <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                </asp:Panel>
                            </td>
                            <td class="style2">
                                <asp:Panel ID="Panel2" runat="server" Height="180px" Width="587px">
                                   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
                                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                AutoGenerateColumns="False" Style="font-size: small">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Account">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="xacc" runat="server" Text='<%#Eval("xacc") %>' OnClick="FillControls"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="xdesc" HeaderText="Description" />
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
                                        <%--</ContentTemplate>
                                        <Triggers>
                                             <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr align="center">
                <td class="style2">
                    <asp:Button ID="btnPermission" runat="server" Text="Save" Width="99px" OnClick="btnPermission_Click1" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="99px" Visible="False" />
                </td>
            </tr>
            <tr align="center">
                <td class="style2">
                    <div id="dialog" style="display: none">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
