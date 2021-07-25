<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptasctschvwdw.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.reports.rptasctschvwdw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="/Styles/bmerp.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/amSite.css" rel="stylesheet" type="text/css" />
    
    
   

</head>
<body class="body_report">
    <form id="form1" runat="server">
    <div>
    
    
    
        

    <div class="bm_academic_container" style="padding: 10px;">
        <div class="bm_academic_container_header">
           <%-- <div class="header_label1" id="header_label" runat="server">
                <span class="bm_am_header_round">Class Test Schedule (Section wise)</span>
            </div>--%>
          <div style="font-weight: bold; font-size: 1.2em;"> <asp:Label ID="xorg" runat="server" Text="Presidency International School"></asp:Label> </div>
           <div><asp:Label ID="Label6" runat="server" Text="Class Test Schedule (Day wise)"></asp:Label></div>
            <hr/>
            <div>
                <table>
               <tr> <td>Session</td><td> : </td> <td> <asp:Label ID="hxsession" runat="server" Text="Session"></asp:Label> </td> </tr>
            
                <tr><td>Class</td><td> :</td><td> <asp:Label ID="hxclass" runat="server" Text="Class"></asp:Label></td></tr>
           <%-- <tr><td>Group</td><td> : </td><td><asp:Label ID="hxgroup" runat="server" Text="Group"></asp:Label></td></tr>--%>
            <tr><td>Term</td><td> :</td><td> <asp:Label ID="hxterm" runat="server" Text="Term"></asp:Label></td></tr>
            <tr><td>Date</td><td> :</td><td> <asp:Label ID="hxmonth" runat="server" Text="Month"></asp:Label></td></tr>
            </table>
            </div>
        </div>
      
        <div class="bm_academic_container_footer">
            <div class="footer_list_padding2">
                <div class="bm_academic_grid_container" id="list" runat="server">
                  
                    <div class="grid_body1">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                                    CssClass="bm_academic_grid2" FooterStyle-CssClass="FooterStyle" RowStyle-CssClass="RowStyle"
                                    AlternatingRowStyle-CssClass="AlternatingRowStyle" PagerStyle-CssClass="PagerStyle"
                                    GridLines="None" OnDataBound="GridView1_DataBound1" OnRowDataBound="OnRowDataBound" 
                                    UseAccessibleHeaderText="true">
                                    <HeaderStyle CssClass="HeaderStyle1"></HeaderStyle>
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
