<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="booklist.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.booklist"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Styles/bmerp.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/bmscript.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>


    <script type="text/javascript">


        function update(updstr) {
            //alert("Hi");
            //alert(updstr);
            var ctlid = $("#<%= ctlid_v.ClientID%>").val();
            //alert(ctlid);
            window.opener.update(updstr, ctlid);
            self.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>
        <div>
            <div class="bm_academic_container_footer">
                <div class="footer_list_padding">
                    <div class="bm_academic_grid_container" id="list" runat="server">
                        <div class="grid_header">
                            <div class="grid_header_label" id="_grid_header" runat="server">
                                Book List(s) :
                            </div>
                            <div class="grid_header_control">
                            </div>
                            <div class="flot_right">
                                <%-- <div class="grid_header_searchbox">
                                <asp:TextBox ID="_searchbox" runat="server" AutoPostBack="True" CssClass="_searchbox"></asp:TextBox>
                            </div>--%>
                                <div class="grid_header_row">
                                    <asp:TextBox ID="_gridrow" runat="server" AutoPostBack="True" CssClass="_gridrow" OnTextChanged="fnFilterByRow"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="grid_body">
                            <asp:GridView ID="_grid_emp" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                CssClass="bm_academic_grid" HeaderStyle-CssClass="HeaderStyle" FooterStyle-CssClass="FooterStyle"
                                RowStyle-CssClass="RowStyle" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                                PagerStyle-CssClass="PagerStyle" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="Book Code">
                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="xlbord" runat="server" Text='<%#Eval("xlbord") %>' OnClientClick='<%# String.Format("update(\"{0}\");", Eval("xlbord")) %>' CssClass="_gridrow_link"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="xlbtitle" HeaderText="Title" ItemStyle-Width="250px" ItemStyle-CssClass="_grid_text_padding" />
                                    <asp:BoundField DataField="xlbstatus" HeaderText="Title" ItemStyle-Width="150px" ItemStyle-CssClass="_grid_text_padding" />
                                   <%-- <asp:BoundField DataField="xname" HeaderText="Name" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" />--%>
                                    <%--<asp:BoundField DataField="xsession" HeaderText="Session" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" />
                                    <asp:BoundField DataField="xclass" HeaderText="Class" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" />
                                    <asp:BoundField DataField="xgroup" HeaderText="Group" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" />
                                    <asp:BoundField DataField="xsection" HeaderText="Section" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" />--%>
                                    <%--<asp:BoundField DataField="xname" HeaderText="Employee Name" ItemStyle-Width="150px" ItemStyle-CssClass="_grid_text_padding"/>
                                <asp:BoundField DataField="xdesig" HeaderText="Designation" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding"/>
                                <asp:BoundField DataField="xdept" HeaderText="Department" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding"/>--%>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate></ItemTemplate>

                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="ctlid_v" runat="server" />
        <asp:HiddenField ID="ctlid1_v" runat="server" />
    </form>
</body>
</html>
