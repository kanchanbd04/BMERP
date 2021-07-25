<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zunitpermis.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.zunitpermis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
   
  <script type="text/javascript">
      $(function () {
          //debugger
          $("[id*=TreeView1] input[type=checkbox]").bind("click", function () {
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
    <div>
    
        <table class="style1">
            <tr align="center">
                <td>
                    <div id="xuser" 
                        style="font-weight: bold; color: #FFFFFF; font-size: medium; background-color: #996633;" 
                        runat="server">

                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; background-color: #FFFFFF">
                    <div id="msg" runat="server">
</div></td>
            </tr>
           
            <tr>
                <td>
                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" 
                        ShowCheckBoxes="All" class="tree">
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
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                            HorizontalPadding="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="btnPermission" runat="server" Text="Save" Width="99px" 
                        onclick="btnPermission_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="99px" 
                        onclick="btnUpdate_Click" />
                    </td>
                    
            </tr>
            <tr align="center">
                <td>
                      <div id="dialog" style="display: none">
</div></td>
                    
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
