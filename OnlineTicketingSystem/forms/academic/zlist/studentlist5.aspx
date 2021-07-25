<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentlist5.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.studentlist5"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="~/Styles/bmerp.css" rel="stylesheet" type="text/css" />
      <script src="/Scripts/bmscript.js" type="text/javascript"></script>
         <script src="/Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>
   
   
    <script type="text/javascript">


        function update(updstr, updstr2) {
            //alert("Hi");
            //alert(updstr);
            var ctlid = $("#<%= ctlid_v.ClientID%>").val();
            var ctlid2 = $("#<%= ctlid2_v.ClientID%>").val();
            //alert(ctlid);
            window.opener.update2(updstr, updstr2, ctlid, ctlid2);
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
                            Student List(s) :
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
                            PagerStyle-CssClass="PagerStyle" GridLines="None" >
                            <Columns>
                                <asp:TemplateField HeaderText="Ref.">
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xref" runat="server" Text='<%#Eval("xref") %>' OnClientClick='<%# String.Format("update(\"{0}\",\"{1}\");", Eval("xref"),Eval("xrow")) %>' CssClass="_gridrow_link"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="xref" HeaderText="Ref." ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center"/>--%>
                                 <asp:BoundField DataField="xsession" HeaderText="Session" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center"/>
                                 <asp:BoundField DataField="xclass" HeaderText="Applying For" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding" ItemStyle-HorizontalAlign="Center"/>
                                <%--<asp:TemplateField HeaderText="Student Name">
                                    <ItemStyle Width="200px" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="xname" runat="server" Text='<%#Eval("xname") %>' OnClientClick='<%# String.Format("update(\"{0}\",\"{1}\");", Eval("xref"),Eval("xrow")) %>' CssClass="_gridrow_link"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="xname" HeaderText="Student Name" ItemStyle-Width="200px" ItemStyle-CssClass="_grid_text_padding" HtmlEncode="False"/>
                                <asp:BoundField DataField="xmname" HeaderText="Mother's Name" ItemStyle-Width="150px" ItemStyle-CssClass="_grid_text_padding" HtmlEncode="False"/>
                                <asp:BoundField DataField="xfname" HeaderText="Father's Name" ItemStyle-Width="150px" ItemStyle-CssClass="_grid_text_padding" HtmlEncode="False"/>
                               
                                
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
     <asp:HiddenField ID="ctlid2_v" runat="server" />
    </form>
</body>
</html>
