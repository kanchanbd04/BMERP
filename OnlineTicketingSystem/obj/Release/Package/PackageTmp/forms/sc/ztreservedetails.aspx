<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ztreservedetails.aspx.cs" Inherits="OnlineTicketingSystem.forms.sc.ztreservedetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 115px;
        }
        .style4
        {
            width: 169px;
        }
        .style5
        {
            width: 90px;
        }
        .style6
        {
            width: 175px;
        }
        .style8
        {
            width: 88px;
        }
        .style12
        {
            width: 81%;
            float: left;
        }
        .style14
        {
            width: 83px;
        }
        .style15
        {
            width: 109px;
        }
        .style16
        {
            background-color: #999999;
        }
        .style18
        {
            width: 109px;
            color: #FFFFFF;
            background-color: #999999;
        }
        .style20
        {
            width: 83px;
            color: #FFFFFF;
            background-color: #999999;
        }
        .style21
        {
            color: #FFFFFF;
        }
        .style22
        {
            width: 88px;
            color: #FFFFFF;
            background-color: #999999;
        }
        .style23
        {
            width: 109px;
            color: #FFFFFF;
            background-color: #999999;
        }
        .style24
        {
            color: #00FFFF;
            font-weight: bold;
        }
        .style25
        {
            color: #FF66FF;
            font-weight: bold;
        }
        .style26
        {
            text-decoration: underline;
            text-align: left;
            height: 29px;
            font-size: large;
        }
        .style27
        {
            width: 87px;
        }
        .style28
        {
            background-color: #999999;
            width: 293px;
        }
        .style29
        {
            width: 293px;
        }
    </style>

    <script language="javascript">

        $("[id*=xpayment]").live("keydown", function (event) {

            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
            // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||

            // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            } else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }

        });


    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
        <tr>
            <td style="text-align: center" colspan="7">
                <div id="msg" style="font-weight:bold; font-size:12; color:Red; text-align:center; " runat="server" > </div></td>
        </tr>
        <tr>
            <td style="text-align: right" colspan="7">
                <table align="left" class="style12">
                    <tr>
                        <td class="style20">
                            Coach No:</td>
                        <td style="text-align: left" class="style28">
                            <asp:Label ID="xcoach" runat="server" Text="xcoach" CssClass="style24"></asp:Label>
                        </td>
                        <td class="style18">
                            <span class="style21">Journey Date</span>:</td>
                        <td style="text-align: left" class="style16">
                            <asp:Label ID="xdate" runat="server" Text="xdate" CssClass="style24"></asp:Label>
                        </td>
                        <td class="style22">
                            Journey Time:</td>
                        <td style="text-align: left" class="style16">
                            <asp:Label ID="xtime" runat="server" Text="xtime" CssClass="style24"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            Destination:</td>
                        <td style="text-align: left" class="style29">
                            <asp:Label ID="xdest" runat="server" Text="xdest" CssClass="style25"></asp:Label>
                        </td>
                        <td class="style15">
                            Departure Place:</td>
                        <td style="text-align: left">
                            <asp:Label ID="xdplace" runat="server" Text="xdplace" CssClass="style25"></asp:Label>
                        </td>
                        <td class="style8">
                            Reserve By:</td>
                        <td style="text-align: left">
                            <asp:Label ID="xresby" runat="server" Text="xresby" CssClass="style25"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20">
                            Contact No:</td>
                        <td style="text-align: left" class="style28">
                            <asp:Label ID="xcontact" runat="server" Text="xcontact" CssClass="style24"></asp:Label>
                        </td>
                        <td class="style23">
                            Reffered By:</td>
                        <td style="text-align: left" class="style16">
                            <asp:Label ID="xrefby" runat="server" Text="xrefby" CssClass="style24"></asp:Label>
                        </td>
                        <td class="style22">
                            Rent Amount:</td>
                        <td style="text-align: left" class="style16">
                            <asp:Label ID="xfare" runat="server" Text="xfare" CssClass="style24"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style27" style="text-align: right">
                Due Amount:</td>
            <td class="style2">
                <asp:TextBox ID="xdue" runat="server" ReadOnly="True" Width="151px"></asp:TextBox>
            </td>
            <td class="style8" style="text-align: right">
                Pay Amount:</td>
            <td class="style4">
                <asp:TextBox ID="xpayment" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td class="style5" style="text-align: right">
                Payment By:</td>
            <td class="style6">
                <asp:TextBox ID="xpayby" runat="server" Width="151px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Height="32px" Text="Submit" 
                    Width="101px" onclick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td class="style26" colspan="7">
                <strong>Payment Details</strong></td>
        </tr>
        <tr>
            <td colspan="7">
           
                
                

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False">



                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField  DataField="xpayment" HeaderText="Pay Amount" />

                            <asp:BoundField  DataField="xpayby" HeaderText="Payment By" />

                            <asp:BoundField  DataField="xcreatedby" HeaderText="Received By"/>
                            <asp:BoundField  DataField="xcreatedt" HeaderText="Received Date" />

                            
              


                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />



                    </asp:GridView>



                
            </td>
        </tr>
        <tr>
            <td colspan="7">
           
                
                

                    <strong>Total Payment : 
                    <asp:Label ID="xtotalpayment" runat="server" style="color: #00CC00" 
                        Text="xtotalpayment"></asp:Label>
                    </strong>



                
            </td>
        </tr>
    </table>



    </div>
    </form>
</body>
</html>
