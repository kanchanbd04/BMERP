<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true" CodeBehind="ammenurearrange.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.sc.ammenurearrange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="message" runat="server" style="margin-top: 10px; margin-bottom: 20px;"></div>
    <div style="margin-top: 20px;">
        
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">Old ID</td>
                <td>:</td>
                <td><asp:textbox runat="server" ID="xidold"></asp:textbox></td>
            </tr>
          <tr>
                <td class="auto-style1">New ID</td>
                <td>:</td>
                <td><asp:textbox runat="server" ID="xidnew"></asp:textbox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick"/>
                </td>
            </tr>
        </table>

        </div>
</asp:Content>
