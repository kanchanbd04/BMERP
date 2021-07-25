<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="amstddeparture.aspx.cs" Inherits="OnlineTicketingSystem.forms.academic.profile.student.amstddeparture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <title>Students' Departure</title>
    <link rel="shortcut icon" type="image/x-icon" href="/images/edusoft.ico" />
    <link href="~/Styles/amSite.css?version=21.0.0.1" rel="stylesheet" type="text/css" />
    <link href="~/Styles/bmerp.css?version=21.0.0.2" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/jquery-1.8.3.js"
        type="text/javascript"></script>

</head>
<body style="background-color: #16C1F3;">
 
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <div style="width: 1229.4px; margin: 0 auto; background-color: #0095DA; padding-bottom: 5px;">
                    <div style="margin-left: 10px; margin-top: 8px; display: inline-block">
                        <%--<asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/Edusoft.png"
                            Height="44px" Width="100px" />--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" ImageUrl="~/images/Edusoft.png"
                            Height="44px" Width="100px" OnClick="ImageButton1_OnClick" />
                    </div>
                    <div style="margin-left: 300px; margin-top: 5px; display: inline-block">
                        <asp:Image ID="Image2" runat="server" ImageAlign="Middle" ImageUrl="~/images/PIS Logo final 163X50.png"
                            Height="50px" Width="163px" />
                    </div>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            
                    <div style="width: 100%; background-color: #16C1F3; min-height: 1000px; border-top: 2px solid #FFFFFF">
                        <div class="bm_academic_container_message">
                            <div class="message" id="message" runat="server">
                                <%-----THIS IS MESSAGE SECTION-----%>
                            </div>
                        </div>
                        <div style="width: 1229.4px; margin: 0 auto; background-color: #16C1F3;">
                            <%--<div style="width:100%" >
                        <div style="display: inline-block">
                            Enter Student ID : 
                        </div>
                        <div style="display: inline-block">
                            <asp:TextBox ID="xstdid" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                                             OnTextChanged="xstdid_OnTextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                    </div>--%>
                            <div style="width: 100%">
                                <div class="bm_ctl_container_100_special" style="display: inline-block;width: 220px">
                                    <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                        <asp:Label ID="Label1" runat="server" Text="School :" AssociatedControlID="xschool"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_special" style="width: 143px">
                                        <asp:DropDownList ID="xschool" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="bm_ctl_container_100_special" style="display: inline-block;">
                                    <div class="bm_ctl_label_align_right_100_special" style="width: 75px">
                                        <asp:Label ID="Label31" runat="server" Text="Session :" AssociatedControlID="xsession"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_special" style="width: 103px">
                                        <asp:DropDownList ID="xsession" runat="server" CssClass="bm_academic_dropdown_100_special bm_academic_ctl_global bm_academic_dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="bm_ctl_container_100_special" style="display:none; width: 210px"
                                    runat="server" id="schedule_d" >
                                    <div class="bm_ctl_label_align_right_100_special" style="width: 100px">
                                        <asp:Label ID="Label13" runat="server" Text="Student ID :" AssociatedControlID="xstdid"
                                            CssClass="label"></asp:Label>
                                    </div>
                                    <div class="bm_clt_ctl_100_special" style="width: 108px">
                                        <asp:TextBox ID="xstdid" runat="server" CssClass="bm_academic_textbox_50_100 bm_academic_ctl_global bm_academic_textbox "
                                            OnTextChanged="xstdid_OnTextChanged" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="bm_ctl_container_50_50" style="display: none; width: 32px; border: none; height: 32px; padding-top: 5px">
                                    <div class="bm_clt_ctl_50_50" style="width: 100%;">
                                        <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/reload70.png"
                                            Width="25px" Height="25px" CssClass="bm_academic_button_zoom" OnClick="btnRefresh_OnClick" />
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                            <div style="width: 100%">
                                
                                <%--<asp:Label ID="Label1" runat="server" Text="" ForeColor="white"></asp:Label>--%>
                                <asp:GridView ID="_grid_std" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                    CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                    RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                    PagerStyle-CssClass="PagerStyle" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-Font-Size="30px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="xstdid" HeaderText="ID" ItemStyle-Width="100px"
                                            ItemStyle-CssClass="pad5" ItemStyle-Font-Size="30px" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="700px"
                                            ItemStyle-CssClass="pad5" ItemStyle-Font-Size="40px" />
                                        <asp:ImageField DataImageUrlField="ximagelink" HeaderText="" ItemStyle-Width="100px" ItemStyle-Height="100px"
                                            ControlStyle-Width="100px" ControlStyle-Height="100px" />
                                        <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="250px"
                                            ItemStyle-CssClass="pad5" ItemStyle-Font-Size="40px" ItemStyle-HorizontalAlign="Center" HtmlEncode="False" />

                                        <asp:TemplateField>
                                            <ItemTemplate></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                      <asp:Timer ID="Timer1" runat="server" OnTick="TimerTick" Interval="5000" Enabled="False"/>
                     </ContentTemplate>
            </asp:UpdatePanel>
                        </div>
                    </div>

                  

               
            <%--<div class="footer" runat="server" id="footer">
                <div style="width: 1229.4px; margin: 0 auto; height: 50px; background: #b6b7bc; padding-top: 8px;">
                    ©<%= DateTime.Today.Year %> Business Manager
                </div>
            </div>--%>
        </div>
    </form>
</body>
</html>
