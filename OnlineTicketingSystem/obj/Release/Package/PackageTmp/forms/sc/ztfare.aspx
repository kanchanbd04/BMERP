<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ztfare.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztfare" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 <link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
<%--<link rel="stylesheet" href="../../Scripts/jquery-ui-1.8.17/themes/base/jquery.ui.all.css">
--%>
     <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>


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


    <script>
        $(function () {
            $("#<%=xeffdate.ClientID %>").datepicker();
        });
	</script>

        <style type="text/css">
        .style2
    {
        vertical-align:top;
        }
    .style3
    {
        height: 123px;
        width: 836px;
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
    {                text-align: left;
            }
    .style8
    {
            width: 103px;
        }
        .style10
        {
            width: 204px;
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
            width: 181px;
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
            width: 100%;
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
            .style30
            {
                text-align: right;
            }
            #xdesc
            {
                height: 71px;
                width: 179px;
            }
            .style31
            {
                width: 103px;
                text-align: right;
                height: 35px;
            }
            .style32
            {
                width: 204px;
                height: 35px;
            }
            .style33
            {
                width: 167px;
                height: 35px;
            }
            .style34
            {
                text-align: right;
                height: 35px;
            }
            .style36
            {
                width: 103px;
                height: 35px;
            }
            .style37
            {
                text-align: left;
                text-decoration: underline;
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
               var selectedvalue = confirm("Do you want to Confirm?");
               if (selectedvalue) {
                   document.getElementById('<%=comfirmmsg.ClientID %>').value = "Yes";
               } else {
                   document.getElementById('<%=comfirmmsg.ClientID %>').value = "No";
               }
           }
          
    </script>


    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!")
        }
</script>




<%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>



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
                    width: 'auto',
                    title: "Role Permission",

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


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div id="dialog" style="display: none">
</div>



    <table style="width:98%; height: 111px;">
    <tr>
        <td class="style4">
            <strong>Fare Edit</strong></td>
        <td class="style2" rowspan="2">

        
            <asp:Panel ID="Panel1" runat="server" Height="363px" ScrollBars="Auto" 
                Width="536px">
           
                
                

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False" 
                        >



                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                              <ItemTemplate>
                        <asp:LinkButton ID="xfareid" runat="server"  Text='<%#Eval("xfareid") %>' OnClick="FillControls"></asp:LinkButton>
                       
                    </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField  DataField="xbustype" HeaderText="Bus Type" />
                            <asp:BoundField  DataField="xmrid" HeaderText="Main Route" />
                            <asp:BoundField  DataField="xsrid" HeaderText="Sub Route" />
                            <asp:BoundField  DataField="xfare" HeaderText="Fare" />

                            <asp:TemplateField HeaderText="Active?">
            <ItemTemplate><asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' /></ItemTemplate>
            
                            </asp:TemplateField>

                            
                            <asp:BoundField DataField="xapprove" HeaderText="Status" />

                            
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
            
        </td>
    </tr>
    <tr>
        <td class="style3">
            <table style="width:100%;">
                <tr>
                    <td class="style6" colspan="4">
                        <div id="msg" style="font-weight:bold; font-size:12; color:Red; text-align:center; " runat="server" > </div></td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style34">
                        ID</td>
                    <td class="style32">
                        <asp:Label ID="xfareid" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="style36">
                        </td>
                    <td class="style33">
                        </td>
                </tr>
                <tr>
                    <td class="style31">
                        Bus Type</td>
                    <td class="style32">
                        <asp:DropDownList ID="xbustype" runat="server" Height="24px" Width="151px">
                        </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style31">
                        </td>
                    <td class="style33">
                        </td>
                </tr>
                <tr>
                    <td class="style31">
                        Main Route&nbsp; </td>
                    <td class="style32">
                        <asp:DropDownList ID="xmrid" runat="server" Width="151px" AutoPostBack="True" 
                            onselectedindexchanged="xmrid_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style31">
                        </td>
                    <td class="style33">
                        </td>
                </tr>
                <tr>
                    <td class="style31">
                        Sub Route</td>
                    <td class="style32">
                        <asp:DropDownList ID="xsrid" runat="server" Width="151px">
                        </asp:DropDownList>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style31">
                        </td>
                    <td class="style33">
                        </td>
                </tr>
                <tr>
                    <td class="style31">
                        Fare</td>
                    <td class="style32">
                        <asp:TextBox ID="xfare" runat="server" Width="151px"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style31">
                        </td>
                    <td class="style33">
                        </td>
                </tr>
                <tr>
                    <td class="style34">
                        Effected Date</td>
                    <td class="style32">
                        <asp:TextBox ID="xeffdate" runat="server" Width="151px"></asp:TextBox>
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style36">
                        &nbsp;</td>
                    <td class="style33">
                        </td>
                </tr>
                <tr>
                    <td class="style30">
                        Active?</td>
                    <td class="style10">
                        <asp:CheckBox ID="zactive" runat="server" Text="Active" />
                    </td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6" colspan="4">
                        <table class="style23">
                            <tr>
                                <td class="style27" >
                        <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" 
                            Font-Bold="True" Height="30px" onclick="btnClear_Click"/>
                            </td>
                            <td class="style26" >
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" 
                            Font-Bold="True" Height="30px" onclick="btnAdd_Click" />
                            </td>
                                
                                <td class="style25" >
                                    <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Height="30px" 
                                        style="text-align: center" Text="Update" Width="100px" 
                                        onclick="btnUpdate_Click" />
                                </td>
                                <td class="style28">
                                    <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Height="30px" 
                                        Text="Delete" Width="100px"  ClientIDMode="Static"   
                                        OnClientClick="javascript:ConfirmMessage()" OnClick="btnDelete_Click"  />
                                </td>
                                <td style="text-align: left">
                                    <asp:Button ID="btnapprove" runat="server" Height="31px" 
                                        style="text-align: center; font-weight: 700" Text="Approve" 
                                        Width="100px" OnClientClick="javascript:ConfirmMessage1()" 
                                        onclick="btnapprove_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style37" colspan="4">
                        <strong>Fare History</strong></td>
                </tr>
                <tr>
                    <td class="style6" colspan="4">
           
                
                

                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False">



                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>

                            <asp:BoundField  DataField="xfare" HeaderText="Fare" />
                            <asp:BoundField DataField="xstdt" HeaderText="Start Date" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="xendt" HeaderText="End Date" DataFormatString="{0:d}"/>

                            
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



                
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                                    <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                                    </td>
                </tr>
            </table>
        </td>
       
    </tr>
</table>

<asp:HiddenField ID="comfirmmsg" runat="server" />

 <div id="message" runat="server">
        </div>

       <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>


</asp:Content>
