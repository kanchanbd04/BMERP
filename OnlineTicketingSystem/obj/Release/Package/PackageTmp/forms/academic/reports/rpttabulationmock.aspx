<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rpttabulationmock.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.reports.rpttabulationmock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head runat="server">
    
    <meta  charset=UTF-8" />
<meta name="viewport" content="width=device-width,initial-scale=1"/>

    <title></title>
    
     <link href="~/Styles/amSite.css?version=1.16" rel="stylesheet" type="text/css" />
    <link href="~/Styles/bmerp.css?version=1.16" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/jquery-1.8.3.js"
        type="text/javascript"></script>

   <style>
        tr.BorderRow td
        {
            border-top: 2px solid #000000;
        }
        
       @page
        {
           size: landscape; /* auto is the initial value */ /* this affects the margin in the printer settings */
           margin-top: 25mm;
           margin-bottom: 12mm;
           margin-left: 25mm;
           margin-right: 12mm;
        }  
        
        body
        {
            /* this affects the margin on the content before sending to printer */
            margin: 0px;
        }
     
    </style>
    
    <script>
        $(document).ready(function () {


           var grid = document.getElementById('<%= GridView1.ClientID %>');

            var tbody = grid.getElementsByTagName("tbody")[0]; //gets the first and only tbody
            var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's
            var secondTr = tbody.getElementsByTagName("tr")[1];
            //firstTr.classList.add("GridViewScrollHeader");
            //secondTr.classList.add("GridViewScrollHeader");

            tbody.removeChild(firstTr); //remove tr's from table
            tbody.removeChild(secondTr);

            //alert(tbody.getElementsByTagName("tr")[0]);
            //alert(tbody.rows.length);
            //for (var i = 0; i < tbody.rows.length; i++) {
            //    var trb = tbody.getElementsByTagName("tr")[i];
            //    trb.classList.add("GridViewScrollItem");
            //}

          <%--  <div style="font-weight: bold; font-size: 1.2em;"> <asp:Label ID="xorg" runat="server" Text="Presidency International School"></asp:Label> </div>
          <div><asp:Label ID="Label6" runat="server" Text="Tabulation Sheet"></asp:Label></div>
           <hr/>
           <div>
               <table>
              <tr> <td>Session</td><td> : </td> <td> <asp:Label ID="hxsession" runat="server" Text="Session"></asp:Label> </td> </tr>
           <tr><td>Term</td><td> :</td><td> <asp:Label ID="hxterm" runat="server" Text="Term"></asp:Label></td></tr>
               <tr><td>Class</td><td> :</td><td> <asp:Label ID="hxclass" runat="server" Text="Class"></asp:Label></td></tr>
           <tr><td>Group</td><td> : </td><td><asp:Label ID="hxgroup" runat="server" Text="Group"></asp:Label></td></tr>
           <tr><td>Section</td><td> : </td><td><asp:Label ID="hxsection" runat="server" Text="Section"></asp:Label></td></tr>
            
           </table>
           </div> --%>

            var newTh = document.createElement('thead'); //creates thead
            //var newThTR1 = newTh.insertRow();
            //var newThTR1Cell1 = newThTR1.insertCell();
            //newThTR1Cell1.textContent = "Presidency International School";
            //newThTR1Cell1.colspan = grid.rows[0].cells.length - 5;
            //alert(grid.rows[0].cells.length);
            //newTh.appendChild(newThTR1);
            newTh.appendChild(firstTr); //puts ths in thead
            newTh.appendChild(secondTr);

            //newTh.rows[0].cells[0].colSpan = grid.rows[0].cells.length - 5;
            //newTh.style = "border-top:none;";

            grid.insertBefore(newTh, tbody); //puts thead behore tbody

        });
    </script>

</head>
<body class="body_report">
    <form id="form1" runat="server">
    <div>
    
    
    
        

    <div class="bm_academic_container" >
        <div class="bm_academic_container_header">
           <%-- <div class="header_label1" id="header_label" runat="server">
                <span class="bm_am_header_round">Class Test Schedule (Section wise)</span>
            </div>--%>
          <div style="font-weight: bold; font-size: 1.2em;"> <asp:Label ID="xorg" runat="server" Text="Presidency International School"></asp:Label> </div>
           <div><asp:Label ID="Label6" runat="server" Text="Tabulation Sheet"></asp:Label></div>
            <hr/>
            <div>
                <table>
               <tr> <td>Session</td><td> : </td> <td> <asp:Label ID="hxsession" runat="server" Text="Session"></asp:Label> </td> </tr>
            <tr><td>Term</td><td> :</td><td> <asp:Label ID="hxterm" runat="server" Text="Term"></asp:Label></td></tr>
                <tr><td>Class</td><td> :</td><td> <asp:Label ID="hxclass" runat="server" Text="Class"></asp:Label></td></tr>
            <tr><td>Group</td><td> : </td><td><asp:Label ID="hxgroup" runat="server" Text="Group"></asp:Label></td></tr>
            <tr><td>Section</td><td> : </td><td><asp:Label ID="hxsection" runat="server" Text="Section"></asp:Label></td></tr>
            
            </table>
            </div>
        </div>
      
        <div class="bm_academic_container_footer">
            <div class="footer_list_padding2">
                <div class="bm_academic_grid_container" id="list" runat="server">
                  
                    <div class="grid_body1">
                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                CssClass="bm_academic_grid20" FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle"
                                AlternatingRowStyle-CssClass="AlternatingRowStyle" PagerStyle-CssClass="PagerStyle"
                                GridLines="None" OnDataBound="GridView1_DataBound1" OnRowDataBound="OnRowDataBound"
                                UseAccessibleHeaderText="true"  >
                                <%--<HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>--%>
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Days">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("SelectedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Section">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelRequest" runat="server" Text='<%# Bind("section") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="120px" Wrap="True" />
                                </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="_gridrow" Visible="False" runat="server" AutoPostBack="True" CssClass="_gridrow"
        OnTextChanged="fnFilterByRow"></asp:TextBox>
    <asp:HiddenField ID="ctlid_v" runat="server" />
    
    
    
    

    </div>
    </form>
</body>
</html>
