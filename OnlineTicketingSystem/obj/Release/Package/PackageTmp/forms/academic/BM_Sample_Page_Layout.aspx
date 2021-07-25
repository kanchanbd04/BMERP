<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true" CodeBehind="BM_Sample_Page_Layout.aspx.cs" Inherits="OnlineTicketingSystem.forms.BM_Sample_Page_Layout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="bm_academic_container">
        <div class="bm_academic_container_header">
        </div>
        <div class="bm_academic_container_message">
            <div id="message" runat="server">
            </div>
        </div>
        <div class="bm_academic_container_body">
            <div class="bm_academic_container_body_input_section">
            </div>
            <div class="bm_academic_container_body_button_section">
            </div>
        </div>
        <div class="bm_academic_container_footer">
            <div id="list" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
