<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zbusiness_sel_all_code.aspx.cs"
    Inherits="OnlineTicketingSystem.forms.BMERP.zbusiness_sel_all_code" EnableEventValidation="false" %>

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
   
    <script type="text/javascript" language="javascript">
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

        var row ;
        function ow(zid, ctlid, rowid) {
            row = rowid.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            //document.getElementById("msg").innerHTML = "Hi!";
            //alert(row.cells[3].children[0].value);
            var left = Math.round((screen.width / 2) - (500 / 2));
            var top = Math.round((screen.height / 2) - (500 / 2));
            var q_val = row.cells[3].children[0].value;
            var openwin = window.open("multiple_accounts_sel.aspx?zid=" + zid + "&ctlid=" + ctlid + "&rowid=" + rowIndex + "&q_val=" + q_val, '', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
            openwin.focus();
        }

        function update(updatestr, ctlid, rowid) {
            //alert(rowid);
            var s_val = updatestr;
            var grdvw = document.getElementById('<%= GridView1.ClientID %>');
            //alert(grid);
             //for (i = 1; i < grid.rows.length; i++) {
            //alert(i);
            var txtbx = grdvw.rows[parseInt(rowid) + 1].cells[3].children[0];
            txtbx.value = s_val;
            //}
            //document.getElementById("msg").innerHTML = updatestr;
            // $("#<%= ctlid_hf.ClientID%>").val(ctlid);

            //alert($("#<%= ctlid_hf.ClientID%>").val());
            return false;
        }

        function messagebox(msg,id) {
            alert(msg+'</br>'+id);
        }

        function test(id) {
            //var row = id.parentNode.parentNode;
            //var rowIndex = row.rowIndex - 1;
            //var customerId = row.cells[2].innerHTML;
            //alert(customerId);
            document.getElementByID("GridView1_accounts_0").innerHTML = "Hi!";
            //row.getElementsByTagName('input')[0].innerHTML= "Hi!";
            //document.getElementById("msg").innerHTML = "Hi!";
        }

        function SetPIN(val) {
            //if (Searching == 'eID') {

            var num = val;
            var grdvw = document.getElementById('<%= GridView1.ClientID %>');

            //for (var rowId = 1; rowId < grdvw.rows.length; rowId++) {
                var txtbx = grdvw.rows[1].cells[3].children[0];
                txtbx.value = num;
            //}
            // }
            return false;
        }

       
    </script>
    
    <%-- <script type="text/javascript" language="javascript">
         $(document).ready(function()
         {
            $('.acclistClass').unbind("click");
            $('.acclistClass').bind("click", function() {
                alert("Hi!");
                $("#popuphistory").dialog({
                    title: "History",
                    resizable: false,

                    height: 215,

                    width: 450,

                    modal: true
//                                       buttons: {
//                                           Save: function () {
//                                               $(this).dialog('close');
//                                           },

//                                           Close: function () {
//                                               $(this).dialog('close');
//                                           }
//                                       }
                });
                 return false;
            });
         });
    </script>--%>
    
     
    

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
                                                <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="selbiz" runat="server"  />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="zid" HeaderText="Business ID" />
                                        <asp:BoundField DataField="zorg" HeaderText="Business" />
                                        
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
                    <asp:Button ID="btnPermission" runat="server" Text="Save" Width="99px" OnClick="btnPermission_Click1" />
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
    
    
    <div id="popuphistory" style="height: 183px; width: 449px; vertical-align: middle;
        text-align: center; display: none;">
        <table class="style1102" style="width: 100%">
            <tr>
                <td class="style1111409">
                    &nbsp;
                </td>
                <td class="style1111414">
                    &nbsp;
                </td>
                <td class="style1111412">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1111413">
                    From:
                </td>
                <td class="style1111414">
                    &nbsp;
                    <asp:TextBox ID="xfromdt" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style1111412">
                    To:
                </td>
                <td class="style1135">
                    <asp:TextBox ID="xtodt" runat="server" Width="151px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1111409">
                    &nbsp;
                </td>
                <td class="style1111414">
                    <input id="btnshowhis" type="button" value="Show" style="height: 27px; width: 131px;
                        background-color: #33CCCC; border-color: #996633; font-weight: bold; font-size: medium;
                        color: White;" />
                </td>
                <td class="style1111412">
                    &nbsp;
                </td>
                <td class="style1135">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="ctlid_hf" runat="server" />

    </form>
    
     

</body>
</html>
