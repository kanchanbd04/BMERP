<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mscodes.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.ms.common_codes.mscodes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
     <link rel="stylesheet" href="../../../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
        

     <script src="../../../../Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
     <script src="../../../../Scripts/jquery-ui-1.8.17/ui/jquery-ui.js"></script>
     <script src="../../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.datepicker.js"></script>
     <script src="../../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.core.js"></script>
     <script src="../../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.dialog.js"></script>
     <script src="../../../../Scripts/jquery-ui-1.8.17/ui/jquery.ui.widget.js"></script>

    


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


     <script language=javascript type="text/javascript">
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
        });

       
    </script>


    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%=business.ClientID %>').live('click', function (e) {

                // var page = $(this).attr("href")  //get url of link
                var key1 = $("#<%= key.ClientID%>").val();
                var zid1 = $("#<%= zid.ClientID%>").val();
                var xtype1 = $("#<%= xtype2.ClientID%>").val();
                var page = "../../../BMERP/zbusiness_sel_all_code.aspx?xcode=" + key1 + "&tbl=mscodesbiz&zid=" + zid1 + "&xtype=" + xtype1;
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
    .style400
    {
       width: 938px;
            color: #546E96;
            font-size: large;
            text-align: center;
            background-color: #F5F5F5;
    }
    .style6
    {            text-align: right;
        }
    .style7
    {
            width: 200px;
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
        .style33
        {
        }
        .style34
        {
            width: 200px;
        }
        #xadd1
        {
            width: 449px;
            height: 53px;
        }
        #xbankadd
        {
            width: 367px;
            height: 54px;
        }
        .style401
        {
            text-align: right;
            width: 356px;
        }
        #xdescdet
        {
            width: 414px;
            height: 51px;
        }
        #xdescdet0
        {
            width: 414px;
            height: 51px;
        }
        #xprops
        {
            width: 411px;
            height: 52px;
        }
    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="dialog" style="display: none">
</div>



    <table style="width:98%; height: 111px;">
    <tr>
        <td class="style4">
            <strong>
                <asp:Label ID="sxcode" runat="server" Text="Label"></asp:Label></strong></td>
        <td class="style2" rowspan="3">
        <table width="100%">
         <tr>
        <td class="style400" colspan="4">
            Code List(s)</td>
    </tr>
    <tr><td>
            <asp:Panel ID="Panel1" runat="server" Height="387px" ScrollBars="Auto" 
                Width="536px">
           
                
                

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False" Width="520px">



                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                           <asp:BoundField DataField="xtype" HeaderText="Code Type" />
                            <asp:TemplateField HeaderText="Code">
                              <ItemTemplate>
                        <asp:LinkButton ID="xcode" runat="server"  Text='<%#Eval("xcode") %>' OnClick="FillControls"></asp:LinkButton>
                       
                    </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="xdescdet" HeaderText="Long Description" />
                            <asp:BoundField DataField="xcodealt" HeaderText="Alternate Code" />
                            <asp:BoundField DataField="xprops" HeaderText="Property List"  />


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
            </td></tr>
            </table>
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
                    <td class="style401">
                        &nbsp;</td>
                    <td class="style33">
                        &nbsp;</td>
                    <td class="style34">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                        Code Type</td>
                    <td class="style33">
                        <asp:Label ID="xtype" runat="server"></asp:Label>
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                        Code</td>
                    <td class="style33">
                        <asp:TextBox ID="xcode" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                        Long Description</td>
                    <td class="style33" colspan="3">
                        <textarea id="xdescdet" name="S1" runat="server"></textarea></td>
                </tr>
                <tr>
                    <td class="style401">
                        Alternate Code</td>
                    <td class="style33">
                        <asp:TextBox ID="xcodealt" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                        Property List</td>
                    <td class="style33" colspan="3">
                        <textarea id="xprops" name="S2" runat="server" ></textarea></td>
                </tr>
                <tr>
                    <td class="style401">
                        Active?</td>
                    <td class="style33">
                        <asp:CheckBox ID="zactive" runat="server" Text="Active" />
                    </td>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                        Select Business</td>
                    <td class="style33">
                            <asp:LinkButton ID="business" runat="server" >Select Business</asp:LinkButton>
                        </td>
                    <td class="style34">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                            Entry By
                        </td>
                    <td class="style33">
                                    <asp:Label ID="zemail" runat="server"></asp:Label>
                                </td>
                    <td class="style34">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                        Update By</td>
                    <td class="style33">
                                    <asp:Label ID="xemail" runat="server"></asp:Label>
                                </td>
                    <td class="style34">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style401">
                        &nbsp;</td>
                    <td class="style33">
                        &nbsp;</td>
                    <td class="style34">
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
                                          />
                                </td>
                                <td style="text-align: left">
                                    <asp:Button ID="btnConfirm" runat="server" Font-Bold="True" Height="30px" 
                                        Text="Confirm" Width="100px"  ClientIDMode="Static"   OnClientClick="javascript:ConfirmMessage1()" 
                                         OnClick="btnConfirm_Click" Visible="False"
                                          />
                                </td>
                                <td>
                                    &nbsp;</td>
                                
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style401">
                        &nbsp;</td>
                    <td class="style33">
                        &nbsp;</td>
                    <td class="style34">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                    
                <tr>
                    <td class="style401">
                        &nbsp;</td>
                    <td class="style33">
                        &nbsp;</td>
                    <td class="style34">
                        &nbsp;</td>
                    <td class="style29">
                                    <asp:HiddenField ID="txtconformmessageValue" runat="server" />
                                     <asp:HiddenField
                                ID="key" runat="server" />
                                 <asp:HiddenField
                                ID="zid" runat="server" />
                                <asp:HiddenField ID="confmsg" runat="server" />
                                <asp:HiddenField ID="xtype2" runat="server" />
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
