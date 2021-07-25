<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="prmst.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.prmst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 

<link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">



 <link rel="stylesheet" href="../../Styles/bm.css">

     <script src="../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
     <script src="../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>
     
   


     
     <script>
         $(function () {
             $("#<%=xjoindate.ClientID %>").datepicker();
         });
	</script>
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
        .style2
    {
        vertical-align:top;
        }
    .style3
    {
        height: 123px;
        width: 932px;
        vertical-align: top;
    }
    .style4
    {
        height: 30px;
        width: 932px;
        color: #546E96;
        font-size: large;
        text-align: center;
        background-color: #999966;
    }
    .style6
    {                text-align: right;
            }
    .style7
    {
        width: 103px;
        text-align: right;
                height: 38px;
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
        .style11
        {
            width: 103px;
            text-align: right;
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
            #xdesc
            {
                height: 71px;
                width: 179px;
            }
            #xaddress
            {
                height: 71px;
                width: 173px;
            }
            #xadd
            {
                height: 86px;
                width: 172px;
            }
            .style30
            {
                height: 37px;
            }
            .style32
            {
                height: 40px;
            }
            .style33
            {
                height: 41px;
            }
            .style34
            {
                width: 167px;
                height: 38px;
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
          
    </script>


    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!");
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

     


            $('ul.tabs li').click(function() {
                var tab_id = $(this).attr('data-tab');

                $('ul.tabs li').removeClass('current');
                $('.tab-content').removeClass('current');

                $(this).addClass('current');
                $("#" + tab_id).addClass('current');
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
            <strong>Employee Info</strong></td>
        <td class="style2" rowspan="4">

        
            <asp:Panel ID="Panel1" runat="server" Height="363px" ScrollBars="Auto" 
                Width="536px">
           
                
                

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False">



                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Emp ID">
                              <ItemTemplate>
                        <asp:LinkButton ID="xid" runat="server"  Text='<%#Eval("xemp") %>'  OnClick="FillControls"></asp:LinkButton>
                       
                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="xname" HeaderText="Emp Name" />
                            <asp:BoundField DataField="xdesig" HeaderText="Emp Designation" />

                            <asp:BoundField  DataField="xmobile" HeaderText="Contact" />

                            <asp:TemplateField HeaderText="Active?">
            <ItemTemplate><asp:CheckBox ID="status" runat="server" Enabled="false" Checked='<%# (Eval("zactive").ToString() == "1" ? true : false) %>' /></ItemTemplate>
            
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
            
        </td>
    </tr>
    <tr>
        <td class="style3">
        
        <div class="container">
            
            <ul class="tabs">
		<li class="tab-link current" data-tab="tab-1">Employee Information</li>
		<li class="tab-link" data-tab="tab-2">Image Upload</li>
	</ul>
    <div id="tab-1" class="tab-content current">
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
                    <td class="style30">
                        &nbsp;Employee ID</td>
                    <td class="style37">
                        <asp:TextBox ID="xemp" runat="server" Width="151px"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style32">
                        </td>
                    <td class="style38">
                        </td>
                </tr>
                <tr>
                    <td class="style32">
                        Employee&nbsp; Name</td>
                    <td class="style32">
                        <asp:TextBox ID="xname" runat="server" Width="151px"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style32">
                        Joining Date</td>
                    <td class="style32">
                        <asp:TextBox ID="xjoindate" runat="server" Width="151px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style33">
                        Designation</td>
                    <td class="style33">
                        <asp:DropDownList ID="xdesig" runat="server" Height="20px" Width="151px">
                        </asp:DropDownList>
                    </td>
                    <td class="style33">
                        Job Location</td>
                    <td class="style33">
                        <asp:DropDownList ID="xlocation" runat="server" Height="20px" Width="151px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        Father&#39;s Name</td>
                    <td class="style30">
                        <asp:TextBox ID="xfather" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style30">
                        Monthly Salary</td>
                    <td class="style30">
                        <asp:TextBox ID="xdtwotax" runat="server" Width="151px" Height="21px"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server"
                   ControlToValidate="xdtwotax"
                 ErrorMessage="Only Numbers"  ValidationExpression="^\d+$" ValidationGroup="check" 
                            ForeColor="#FF3300" />

                    </td>
                </tr>
                <tr>
                    <td class="style11" rowspan="3">
                        Address</td>
                    <td class="style10" rowspan="3">
                        <textarea id="xadd" name="S1" runat="server"></textarea></td>
                    <td class="style32">
                        Contact No</td>
                    <td class="style32">
                        <asp:TextBox ID="xmobile" runat="server" Width="151px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        Unit</td>
                    <td class="style30">
                        <asp:DropDownList ID="zid" runat="server" Height="20px" Width="151px">
                        </asp:DropDownList>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Active?</td>
                    <td class="style34">
                        <asp:CheckBox ID="zactive" runat="server" Text="Active" />
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
                                        OnClientClick="javascript:ConfirmMessage()" OnClick="btnDelete_Click" 
                                        Visible="False"  />
                                </td>
                                <td>
                                    &nbsp;</td>
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
                    <td class="style6">
                        
                    </td>
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
            </div>
            
            <div id="tab-2" class="tab-content">
            </div>

            </div>
        </td>
       
    </tr>
  
    <tr>
        <td class="style3">
            </td>
       
    </tr>
</table>



 <div id="message" runat="server">
        </div>

       <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>


</asp:Content>
