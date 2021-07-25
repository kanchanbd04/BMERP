<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true" CodeBehind="amsynchro.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.amsynchro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 10px;" runat="server" id="message">
        </div>
     <div style="margin-top: 20px; font-weight: bold; font-size: 16px; text-decoration: underline;">
         Database Synchronization With Remote Server (Student Portal) :
     </div>
    <div style="margin-top: 10px;">
        
        <table >
            <tr>
                <td style="font-weight: bold; font-size: 14px;">1. Student (note: manually copy-past students' image from this serve to portal server.) </td>
                <td style="padding-left: 10px;">Session :</td>
                <td><asp:DropDownList ID="xsession_admit" runat="server"></asp:DropDownList></td>
                <td><asp:Button ID="btnAdmitSync" runat="server" Text="Synchronize" OnClick="btnAdmitSync_OnClick"/></td>
                <td><asp:Label ID="lbladmit" runat="server" Text=""></asp:Label></td>
                
                
            </tr>
        </table>
        
        </div>
    <div style="margin-top: 10px;">
        
        <table >
            <tr>
                <td style="font-weight: bold; font-size: 14px;">2. Result </td>
                <td style="padding-left: 10px;">Session :</td>
                <td><asp:DropDownList ID="xsession_report" runat="server"></asp:DropDownList></td>
                <%--<td style="padding-left: 10px;">Term :</td>
                <td><asp:DropDownList ID="xterm_report" runat="server"></asp:DropDownList></td>--%>
                <td><asp:Button ID="btnReportSync" runat="server" Text="Synchronize" OnClick="btnReportSync_OnClick"/></td>
                 <td><asp:Label ID="lblReport" runat="server" Text=""></asp:Label></td>
                
            </tr>
        </table>
        
        </div>
    
   <%-- <div style="margin-top: 10px;">
        
        <table >
            <tr>
                <td style="font-weight: bold; font-size: 14px;">3. User </td>
                
                <td><asp:Button ID="btnUserSync" runat="server" Text="Synchronization" OnClick="btnUserSync_OnClick"/></td>
                 <td><asp:Label ID="lblUser" runat="server" Text=""></asp:Label></td>
                
            </tr>
        </table>
        
        </div>--%>
    
    <div style="margin-top: 10px;">
        
        <table >
            <tr>
                <td style="font-weight: bold; font-size: 14px;">3. Default Setup </td>
                
                <td><asp:Button ID="btnDefaultSet" runat="server" Text="Synchronize" OnClick="btnDefaultSet_OnClick"/></td>
                 <td><asp:Label ID="lblDefault" runat="server" Text=""></asp:Label></td>
                
            </tr>
        </table>
        
        </div>
    
    <div style="margin-top: 10px;">
        
        <table >
            <tr>
                <td style="font-weight: bold; font-size: 14px;">4. Clearance </td>
                <td style="padding-left: 10px;">Session :</td>
                <td><asp:DropDownList ID="xsession_clear" runat="server"></asp:DropDownList></td>
                <td style="padding-left: 10px;">Term :</td>
                <td><asp:DropDownList ID="xterm_clear" runat="server"></asp:DropDownList></td>
                <td><asp:Button ID="btnClearance" runat="server" Text="Synchronize" OnClick="btnClearance_OnClick"/></td>
                 <td><asp:Label ID="lblClearance" runat="server" Text=""></asp:Label></td>
                
            </tr>
        </table>
        
        </div>

</asp:Content>
