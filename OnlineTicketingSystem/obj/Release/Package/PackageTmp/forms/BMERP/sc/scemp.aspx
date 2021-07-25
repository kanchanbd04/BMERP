<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="scemp.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.sc.scemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <link rel="stylesheet" href="../../../Styles/bm.css">
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
    <script language="javascript" type="text/javascript">
        function openModalForm() {
            window.showModalDialog('ztselcounter.aspx', '', 'status:1; resizable:1; dialogWidth:900px; dialogHeight:500px; dialogTop=50px; dialogLeft:100px')
        }
    </script>
    <script type="text/javascript">
        function selcounter() {
            $(function () {
                $("#dialog").html("");
                $("#dialog").dialog({
                    title: "Select Counter",
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
            var selectedvalue = confirm("Do you want to Confirm?");
            if (selectedvalue) {
                document.getElementById('<%=confmsg.ClientID %>').value = "Yes";
            } else {
                document.getElementById('<%=confmsg.ClientID %>').value = "No";
            }
        }
          
    </script>
    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!");
        }
    </script>
    <script>
        $(function () {
            $("#<%=xdob.ClientID %>").datepicker();
            $("#<%=xjoindate.ClientID %>").datepicker();
            $("#<%=xeffdt.ClientID %>").datepicker();
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('a#popup').live('click', function (e) {

                var page = $(this).attr("href")  //get url of link

                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 600,
                    //                    width: 'auto',
                    width: 500,
                    title: "User Permission",

                    buttons: {
                        "Close": function () { $dialog.dialog('close'); }
                    },
                    close: function (event, ui) {

                        //                        __doPostBack(', '');  // To refresh gridview when user close dialog
                    }
                });
                $dialog.dialog('open');
                e.preventDefault();
            });



            $('ul.tabs li').click(function () {
                var tab_id = $(this).attr('data-tab');

                $('ul.tabs li').removeClass('current');
                $('.tab-content').removeClass('current');

                $(this).addClass('current');
                $("#" + tab_id).addClass('current');
            });


        });

       
        
       


    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%=business.ClientID %>').live('click', function (e) {

                // var page = $(this).attr("href")  //get url of link
                var key1 = $("#<%= key.ClientID%>").val();
                var page = "../../BMERP/zbusiness_sel_all.aspx?key=" + key1 + "&tbl=scempbiz&zid=zid6";
                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 600,
                    width: 800,
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


            });
        });

       
    </script>
    <style type="text/css">
        .style2
        {
            vertical-align: top;
        }
        .style3
        {
            height: 123px;
            width: 836px;
            vertical-align: top;
        }
        .style4
        {
            height: 30px;
            width: 836px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #999966;
        }
        .style6
        {
            text-align: right;
        }
        .style7
        {
            width: 254px;
            text-align: right;
        }
        #Password1
        {
            width: 151px;
        }
        #Password2
        {
            width: 151px;
        }
        #TextArea1
        {
            height: 68px;
            width: 188px;
        }
        #xuserinfo
        {
            height: 83px;
            width: 441px;
        }
        #xpass
        {
            width: 151px;
        }
        #expass
        {
            width: 151px;
        }
        #exrepass
        {
            width: 151px;
        }
        #exuserinfo
        {
            width: 180px;
            height: 74px;
            margin-top: 0px;
        }
        .style23
        {
            width: 98%;
            height: 10px;
        }
        .style25
        {
            width: 93px;
        }
        .style26
        {
            width: 78px;
        }
        .style27
        {
            width: 88px;
        }
        .style28
        {
            width: 68px;
        }
        .style29
        {
            width: 167px;
        }
        .style32
        {
            text-align: right;
            width: 292px;
        }
        .style33
        {
        }
        .style34
        {
            width: 254px;
        }
        #xadd1
        {
            width: 449px;
            height: 53px;
        }
        #xadd
        {
            width: 454px;
            height: 59px;
        }
        .style35
        {
            text-align: right;
            width: 292px;
            height: 29px;
        }
        .style36
        {
            height: 29px;
            width: 120px;
        }
        .style37
        {
            width: 254px;
            text-align: right;
            height: 29px;
        }
        .style38
        {
            width: 167px;
            height: 29px;
        }
        .style39
        {
            width: 120px;
        }
        .style40
        {
            width: 79px;
        }
        .style41
        {
            width: 102px;
        }
        .style42
        {
            width: 129px;
            text-align: left;
        }
        .style400
    {
       width: 938px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #F5F5F5;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog" style="display: none">
    </div>
    <table style="width: 98%; height: 111px;">
        <tr>
            <td class="style4">
                <strong>Employee Info</strong>
            </td>
            <td class="style2" rowspan="2">
                
                <table width="100%">
         <tr>
        <td class="style400" colspan="4">
            Confirmed Employee Record(s) List</td>
    </tr>
    <tr><td>
                <asp:Panel ID="Panel1" runat="server" Height="387px" ScrollBars="Auto" Width="536px">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Row">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' OnClick="FillControls"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="xemp" HeaderText="Emp ID" />
                            <asp:BoundField DataField="xeffdt" HeaderText="Effected Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="xname" HeaderText="Emp Name" />
                            <asp:BoundField DataField="xdesig" HeaderText="Emp Designation" />
                            <asp:BoundField DataField="xmobile" HeaderText="Contact" />
                            <asp:TemplateField HeaderText="Active?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' /></ItemTemplate>
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
                </asp:Panel>
                </td></tr>
            </table>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <table width="100%">
                    <tr>
                        <td class="style6" colspan="4">
                            <div id="msg" style="font-weight: bold; font-size: 12; color: Red; text-align: center;"
                                runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style40">
                            Employee ID
                        </td>
                        <td class="style26">
                            <asp:Label ID="sxemp" runat="server" Text="" Style="color: #00CC00; font-weight: 700"></asp:Label>
                        </td>
                        <td class="style41">
                            Employee Name
                        </td>
                        <td>
                            <asp:Label ID="sxname" runat="server" Text="" Style="color: #33CC33; font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="container">
                    <ul class="tabs">
                        <li class="tab-link current" data-tab="tab-1">Employee Information</li>
                        <li class="tab-link" data-tab="tab-2">Image Upload</li>
                    </ul>
                    <div id="tab-1" class="tab-content current">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style32">
                                    &nbsp;
                                </td>
                                <td class="style39">
                                    &nbsp;
                                </td>
                                <td class="style34">
                                    &nbsp;
                                </td>
                                <td class="style29">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Employee ID
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="xemp" runat="server" Width="151px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="xemp"
                                        ErrorMessage="Only Numbers" ValidationExpression="^\d+$" ValidationGroup="check"
                                        ForeColor="#FF3300" />
                                </td>
                                <td class="style7">
                                    &nbsp;Name
                                </td>
                                <td class="style29">
                                    <asp:TextBox ID="xname" runat="server" Width="151px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style35">
                                    Designation
                                </td>
                                <td class="style36">
                                    <asp:DropDownList ID="xdesig" runat="server" Height="20px" Width="151px">
                                        <asp:ListItem>[Select]</asp:ListItem>
                                        <asp:ListItem>Manager</asp:ListItem>
                                        <asp:ListItem>Assistant Manager</asp:ListItem>
                                        <asp:ListItem>Sr. Execuive</asp:ListItem>
                                        <asp:ListItem>Executive</asp:ListItem>
                                        <asp:ListItem>Officer</asp:ListItem>
                                        <asp:ListItem>Assistant Officer</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style37">
                                    Joining Date
                                </td>
                                <td class="style38">
                                    <asp:TextBox ID="xjoindate" runat="server" Width="151px"></asp:TextBox>
                                    [MM/DD/YYYY]
                                </td>
                            </tr>
                            <tr>
                                <td class="style35">
                                    Father&#39;s Name
                                </td>
                                <td class="style36">
                                    <asp:TextBox ID="xfather" runat="server" Width="151px"></asp:TextBox>
                                </td>
                                <td class="style37">
                                    Mother&#39;s Name
                                </td>
                                <td class="style38">
                                    <asp:TextBox ID="xmother" runat="server" Width="151px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Address
                                </td>
                                <td class="style33" colspan="3">
                                    <textarea id="xadd" name="S1" runat="server" width="151px"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    State/Province
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="xstate" runat="server" Width="151px"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    Country
                                </td>
                                <td class="style29">
                                    <asp:DropDownList ID="xcountry1" runat="server" Height="20px" Width="151px">
                                        <asp:ListItem>Bangladesh</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Mobile
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="xmobile" runat="server" Width="151px"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    Email
                                </td>
                                <td class="style29">
                                    <asp:TextBox ID="xemail1" runat="server" Width="151px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Religion
                                </td>
                                <td class="style39">
                                    <asp:DropDownList ID="xreligi" runat="server" Height="20px" Width="151px">
                                        <asp:ListItem>[Select]</asp:ListItem>
                                        <asp:ListItem>Buddist</asp:ListItem>
                                        <asp:ListItem>Christian</asp:ListItem>
                                        <asp:ListItem>Hindu</asp:ListItem>
                                        <asp:ListItem>Islam</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style7">
                                    Gender
                                </td>
                                <td class="style29">
                                    <asp:DropDownList ID="xsex" runat="server" Height="20px" Width="151px">
                                        <asp:ListItem>[Select]</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    &nbsp;Date of Birth
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="xdob" runat="server" Width="151px"></asp:TextBox>
                                    [MM/DD/YYYY]
                                </td>
                                <td class="style7">
                                    Monthly Salary
                                </td>
                                <td class="style29">
                                    <asp:TextBox ID="xsalary" runat="server" Width="151px" Height="21px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="xsalary"
                                        ErrorMessage="Only Numbers" ValidationExpression="^\d+$" ValidationGroup="check"
                                        ForeColor="#FF3300" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    &nbsp;Effected Date
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="xeffdt" runat="server" Width="151px"></asp:TextBox>
                                    [MM/DD/YYYY]
                                </td>
                                <td class="style7">
                                    Active?
                                </td>
                                <td class="style29">
                                    &nbsp;
                                    <asp:CheckBox ID="zactive" runat="server" Text="Active" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Select Business
                                </td>
                                <td class="style39">
                                    <asp:LinkButton ID="business" runat="server">Select Business</asp:LinkButton>
                                </td>
                                <td class="style34">
                                    &nbsp;
                                </td>
                                <td class="style29">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Status</td>
                                <td class="style39">
                                    <asp:Label ID="xstatus" runat="server"></asp:Label>
                                </td>
                                <td class="style34">
                                    &nbsp;</td>
                                <td class="style29">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Entry By
                                </td>
                                <td class="style39">
                                    <asp:Label ID="zemail" runat="server"></asp:Label>
                                </td>
                                <td class="style34">
                                    &nbsp;
                                </td>
                                <td class="style29">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    Update By
                                </td>
                                <td class="style39">
                                    <asp:Label ID="xemail" runat="server"></asp:Label>
                                </td>
                                <td class="style34">
                                    &nbsp;
                                </td>
                                <td class="style29">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    &nbsp;
                                </td>
                                <td class="style39">
                                    &nbsp;
                                </td>
                                <td class="style34">
                                    &nbsp;
                                </td>
                                <td class="style29">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style6" colspan="4">
                                    <table class="style23">
                                        <tr>
                                            <td class="style27">
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" Font-Bold="True"
                                                    Height="30px" OnClick="btnClear_Click" />
                                            </td>
                                            <td class="style26">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Font-Bold="True"
                                                    Height="30px" OnClick="btnAdd_Click" />
                                            </td>
                                            <td class="style25">
                                                <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" Style="text-align: center"
                                                    Text="Update" Width="100px" OnClick="btnUpdate_Click" />
                                            </td>
                                            <td class="style28">
                                                <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" Text="Delete"
                                                    Width="100px" ClientIDMode="Static" OnClientClick="javascript:ConfirmMessage()"
                                                    OnClick="btnDelete_Click"/>
                                            </td>
                                            <td class="style42">
                                            <asp:Button ID="btnConfirm" runat="server" Font-Bold="True" Height="30px" 
                                        Text="Confirm" Width="100px"  ClientIDMode="Static"   OnClientClick="javascript:ConfirmMessage1()" 
                                         OnClick="btnConfirm_Click" 
                                          />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="style32">
                                    &nbsp;
                                </td>
                                <td class="style39">
                                    &nbsp;
                                </td>
                                <td class="style34">
                                    &nbsp;
                                </td>
                                <td class="style29">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            </table>
                        
                    </div>
                    <div id="tab-2" class="tab-content">
                    </div>
                </div>
                <table width=100%>
                    <tr>
                               <td class="style400" >
            New Employee Record(s) List</td>
                            </tr>
                            <tr><td>
                                
                                <asp:Panel ID="Panel2" runat="server" Height="387px" ScrollBars="Auto" Width="536px">
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Row">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xrow" runat="server" Text='<%#Eval("xrow") %>' OnClick="FillControls"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="xemp" HeaderText="Emp ID" />
                            <asp:BoundField DataField="xeffdt" HeaderText="Effected Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="xname" HeaderText="Emp Name" />
                            <asp:BoundField DataField="xdesig" HeaderText="Emp Designation" />
                            <asp:BoundField DataField="xmobile" HeaderText="Contact" />
                            <asp:TemplateField HeaderText="Active?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' /></ItemTemplate>
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
                </asp:Panel>

                            </td></tr>
                     <tr>
                                
                                <td class="style29">
                                    <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                                    <asp:HiddenField ID="key" runat="server" />
                                    <asp:HiddenField ID="confmsg" runat="server" />
                                </td>
                            </tr>
                        </table>
            </td>
        </tr>
    </table>
    <div id="message" runat="server">
    </div>
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
    <div id="dialog" style="display: none">
        Hello kanchan
    </div>
</asp:Content>
