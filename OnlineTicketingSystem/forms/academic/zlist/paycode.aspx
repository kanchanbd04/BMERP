<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paycode.aspx.cs" Inherits="OnlineTicketingSystem.forms.BMERP.paycode"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Styles/bmerp.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/bmscript.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.17/jquery-1.7.1.js"></script>


    <script type="text/javascript">


        function update(updstr,updstr1) {
            //alert("Hi");
            //alert(updstr);
            var ctlid = $("#<%= ctlid_v.ClientID%>").val();
            var ctlid1 = $("#<%= ctlid1_v.ClientID%>").val();
            var gvid = $("#<%= gvid_v.ClientID%>").val();
            //alert(ctlid);
            var gvval = "INT";
            $.ajax({
                url: "tfccodelist.aspx/createjson",
                type: "POST",
                
                data: "{'i':'" + updstr + "'}",
                datatype: "json",
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    gvval = data.d;
                    //var jsonostr = data.d;
                    //gvval = jsonostr;
                    //var jsonobj = eval('(' + jsonostr + ')');
                    //for (i in jsonobj) {
                    //    $("#Display").append
                    //    ("<span>City Id - " + jsonobj[i]["id"] +
                    //    "</span>&nbsp;<span>City Name - " +
                    //    jsonobj[i]["name"] + "</span><br/>");

                    //}

                },
                error: function () { gvval = "INTERR"; }
            });

            window.opener.update7(updstr, ctlid, updstr1, ctlid1,gvid,gvval);
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
                                Pay Code List(s) :
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
                                    <asp:TemplateField HeaderText="Code">
                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="xpaycode" runat="server" Text='<%#Eval("xpaycode") %>' OnClientClick='<%# String.Format("update(\"{0}\",\"{1}\");", Eval("xpaycode"),Eval("xdesc")) %>' CssClass="_gridrow_link"></asp:LinkButton>
                                        </ItemTemplate>
                                      <%--  <FooterTemplate>
                                            <asp:Label ID="footerlabel" Text="Total" CssClass="footer_label_total" runat="server" />
                                        </FooterTemplate>--%>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="xdesc" HeaderText="Description" ItemStyle-Width="150px" ItemStyle-CssClass="_grid_text_padding" />
                                    <%--<asp:BoundField DataField="xname" HeaderText="Employee Name" ItemStyle-Width="150px" ItemStyle-CssClass="_grid_text_padding"/>
                                <asp:BoundField DataField="xdesig" HeaderText="Designation" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding"/>
                                <asp:BoundField DataField="xdept" HeaderText="Department" ItemStyle-Width="100px" ItemStyle-CssClass="_grid_text_padding"/>--%>
                                   <%-- <asp:BoundField DataField="xacctype" HeaderText="Type" ItemStyle-Width="60px" ItemStyle-CssClass="_grid_text_padding" />
                                     <asp:BoundField DataField="xaccusage" HeaderText="Usages" ItemStyle-Width="60px" ItemStyle-CssClass="_grid_text_padding" />
                                      <asp:BoundField DataField="xaccsource" HeaderText="Source" ItemStyle-Width="60px" ItemStyle-CssClass="_grid_text_padding" />--%>

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
         <asp:HiddenField ID="gvid_v" runat="server" />
    </form>
</body>
</html>
