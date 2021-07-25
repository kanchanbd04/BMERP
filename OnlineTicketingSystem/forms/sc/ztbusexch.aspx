<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ztbusexch.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztbusexch" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


<link rel="stylesheet" href="../../Scripts/jquery-ui-1.9.2.custom/development-bundle/themes/base/jquery.ui.all.css">
    <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>
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



         $(function () {
             $("#<%=xfdate.ClientID %>").datepicker();
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
    {
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
        .style29
        {
            width: 167px;
        }
            #xdesc
            {
                height: 71px;
                width: 179px;
            }
            .style31
            {
                width: 139px;
            }
            .style33
            {
                width: 139px;
                text-align: right;
                height: 35px;
            }
            .style34
            {
                width: 204px;
                height: 35px;
            }
            .style35
            {
                width: 103px;
                height: 35px;
            }
            .style36
            {
                width: 167px;
                height: 35px;
            }
            .style39
            {
                width: 103px;
                text-align: right;
                height: 35px;
            }
            .style40
            {
                width: 139px;
                height: 36px;
            }
            .style41
            {
                width: 204px;
                height: 36px;
            }
            .style42
            {
                width: 103px;
                height: 36px;
            }
            .style43
            {
                width: 167px;
                height: 36px;
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
            alert("hello!")
        }
</script>




<%-- <asp:LinkButton ID="LinkButtonEdit1" runat="server" CommandName="" CommandArgument='<%#Eval("xuser") %>' >Set Permission</asp:LinkButton>--%>



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
            <strong>Bus Exchange</strong></td>
        <td class="style2" rowspan="2">

        
            <asp:Panel ID="Panel1" runat="server" Height="363px" ScrollBars="Auto" 
                Width="536px">
           
                
                

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
                    <td class="style33">
                        Trip Date From:</td>
                    <td class="style34">
                        <asp:TextBox ID="xfdate" runat="server" Width="151px" AutoPostBack="True" 
                            ontextchanged="xfdate_TextChanged"></asp:TextBox>
                    </td>
                    <td class="style35">
                        </td>
                    <td class="style36">
                        </td>
                </tr>
                <tr>
                    <td class="style33">
                        Coach From:</td>
                    <td class="style34">
                        <asp:DropDownList ID="xfcoach" runat="server" Height="30px" Width="151px" 
                            AutoPostBack="True" onselectedindexchanged="xfcoach_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="style39">
                        </td>
                    <td class="style36">
                        </td>
                </tr>
                <tr>
                    <td class="style33">
                        Route From:</td>
                    <td class="style34">
                        <asp:TextBox ID="xfroute" runat="server" ReadOnly="True" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style39">
                        </td>
                    <td class="style36">
                        </td>
                </tr>
                <tr>
                    <td class="style33">
                        Trip Date To:</td>
                    <td class="style34">
                        <asp:TextBox ID="xtdate" runat="server" ReadOnly="True" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style39">
                        </td>
                    <td class="style36">
                        </td>
                </tr>
                <tr>
                    <td class="style33">
                        Coach To:</td>
                    <td class="style34">
                        <asp:DropDownList ID="xtcoach" runat="server" Height="30px" Width="151px" 
                            AutoPostBack="True" onselectedindexchanged="xtcoach_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="style35">
                        </td>
                    <td class="style36">
                        </td>
                </tr>
                <tr>
                    <td class="style33">
                        Route To:</td>
                    <td class="style34">
                        <asp:TextBox ID="xtroute" runat="server" ReadOnly="True" Width="151px"></asp:TextBox>
                    </td>
                    <td class="style35">
                        </td>
                    <td class="style36">
                        </td>
                </tr>
                <tr>
                    <td class="style40">
                        </td>
                    <td class="style41">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="119px" 
                            Font-Bold="True" Height="30px" onclick="btnSubmit_Click"  />
                            </td>
                    <td class="style42">
                        </td>
                    <td class="style43">
                        </td>
                </tr>
                <tr>
                    <td class="style31">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style31">
                        &nbsp;</td>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style29">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style31">
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

        <asp:HiddenField ID="xfmrid" runat="server" />
        <asp:HiddenField ID="xtmrid" runat="server" />

       <%-- <a href="javascript: void(0)" id="dialog_link">I'm the link</a>--%>


</asp:Content>
