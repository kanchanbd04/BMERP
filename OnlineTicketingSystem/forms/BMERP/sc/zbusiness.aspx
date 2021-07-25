<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true" CodeBehind="zbusiness.aspx.cs" Inherits="OnlineTicketingSystem.Forms.zbusiness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" href="../../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%>    <%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%><%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%><%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%>

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
          
    </script>


    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!")
        }
</script>


<script>
    $(function () {
        $("#<%=xdate.ClientID %>").datepicker();
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
                    width: 'auto',
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
    {            text-align: right;
        }
    .style7
    {
        width: 103px;
        text-align: right;
    }
    .style8
    {
            width: 103px;
        text-align: right;
    }
        .style10
        {
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
            height: 46px;
            width: 450px;
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
        #xuserinfo0
        {
            height: 83px;
            width: 181px;
        }
        #xadd1
        {
            height: 74px;
        }
        #Textarea2
        {
            height: 74px;
        }
        #xadd2
        {
            height: 74px;
        }
        #xcustom
        {
            width: 452px;
            height: 50px;
        }
        </style>
</asp:Content>

  

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



  <div id="dialog" style="display: none">
</div>



    <table style="width:98%; height: 111px;">
    <tr>
        <td class="style4">
            <strong>Business</strong></td>
        <td class="style2" rowspan="2">

        
            <asp:Panel ID="Panel1" runat="server" Height="363px" ScrollBars="Auto" 
                Width="536px">
           
                
                

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False">



                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                              <ItemTemplate>
                        <asp:LinkButton ID="zid" runat="server"  Text='<%#Eval("zid") %>' OnClick="FillControls"></asp:LinkButton>
                       
                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="zorg" HeaderText="Organization" />
                           

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
                    <td class="style7">
                        ID</td>
                    <td class="style10">
                        <asp:TextBox ID="zid" runat="server" Width="151px"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="Red" Text="*"></asp:Label>
                    </td>
                    <td class="style7">
                        Organization</td>
                    <td class="style29">
                        <asp:TextBox ID="zorg" runat="server" Width="151px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Short Name</td>
                    <td class="style10">
                        <asp:TextBox ID="xshort" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style7">
                        Email</td>
                    <td class="style29">
                        <asp:TextBox ID="xemail" runat="server" Width="151px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Business Category</td>
                    <td class="style10">
                        <asp:DropDownList ID="xbusscat" runat="server" Width="151px">
                        </asp:DropDownList>
                    </td>
                    <td class="style7">
                        Base Currency</td>
                    <td class="style29">
                        <asp:DropDownList ID="xcur" runat="server" Width="151px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                        Address1</td>
                    <td class="style10">
                        <textarea id="xadd1" name="S1" runat="server"></textarea></td>
                    <td class="style11">
                        Address2</td>
                    <td class="style10">
                        <textarea id="xadd2" name="S1" runat="server"></textarea></td>
                </tr>
                <tr>
                    <td class="style6">
                        Image Path</td>
                    <td class="style10">
                        <asp:TextBox ID="xtimage" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style8">
                        Create Date</td>
                    <td class="style29">
                        <asp:TextBox ID="xdate" runat="server" Width="151px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Custom Features</td>
                    <td class="style10" >
                        <textarea id="xcustom" name="S3" runat="server"></textarea></td>
                    <td class="style7">
                        Alternative Organization</td>
                    <td class="style29">
                        <asp:TextBox ID="zorg1" runat="server" Width="151px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        URL</td>
                    <td class="style10">
                        <asp:TextBox ID="xurl" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style8">
                        Active?</td>
                    <td class="style29">
                        <asp:CheckBox ID="zactive" runat="server" Text="Active" />
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Module</td>
                    <td class="style10">
                        <asp:DropDownList ID="xmod" runat="server" Height="20px" 
                              Width="151px" 
                            AutoPostBack="True" onselectedindexchanged="xmod_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                        </td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style10" colspan="3">
                        <asp:Panel ID="Panel2" runat="server" Height="180px" Visible="False" 
                            Width="421px">
                            <table class="style23">
                                <tr>
                                    <td class="style30" rowspan="2" valign="top">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Available Module's"></asp:Label>
                                        <br />
                                        <asp:ListBox ID="ListBox1" runat="server" Height="149px" 
                                            SelectionMode="Multiple" Width="166px"></asp:ListBox>
                                    </td>
                                    <td align="center" class="style31" valign="bottom">
                                        <asp:Button ID="btnforward" runat="server" Text="&gt;" Width="35px" 
                                            onclick="btnforward_Click" />
                                    </td>
                                    <td rowspan="2" valign="top">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                                            Text="Selected Module/'s"></asp:Label>
                                        <br />
                                        <asp:ListBox ID="ListBox2" runat="server" Height="149px" 
                                            SelectionMode="Multiple" Width="166px"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="style31" valign="top">
                                        <asp:Button ID="btnbackword" runat="server" Text="&lt;" Width="35px" 
                                            onclick="btnbackword_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        
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



 <div id="message" runat="server">
        </div>

       <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
   
     <div id="dialog" style="display: none">

     Hello kanchan

</div>


</asp:Content>
