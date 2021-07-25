<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zlogin.aspx.cs" Inherits="OnlineTicketingSystem.Forms.zlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="/images/edusoft.ico" />
    <script src="/Scripts/jquery-ui-1.9.2.custom/development-bundle/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.key.js"></script>
    <title>Login</title>
    <%-- <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        input[type=text], input[type=password]
        {
            width: 200px;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>--%>
    <style type="text/css">
        .bgtr
        {
            background-color: #D2691E;
        }
        table
        {
            border: 1px solid #ccc;
        }
        #form1
        {
            <%--height: 466px;--%>
        }
        .style1
        {
            width: 83px;
        }
        .ctl {
            
        }
        .ctl:focus {
            background-color: #f7dc6f;
        }
        
        .bttn {
    
    padding: 3px 20px;
   
            margin-right:7px;
 
    
     cursor: pointer;
    background-color: #007DC5;
    border: none;
    color: #FFFFFF;
    font-family: Myriad Pro,tahoma;
    font-size: 14px;
    font-weight: bold;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    -webkit-transition-duration: 0.2s; /* Safari */
    transition-duration: 0.2s;
    width: 255px;
}


.bttn:hover {
    background-color: #F68814;
    color:  #C7EBFC;
}
.bttn:active {
    /*background-color: #F68814;
    color:  #C7EBFC;*/
    background-color: #C7EBFC;
    color:  #F68814;
}

    </style>
    <script>
        $(document).ready(function() {
            $('.ctlu').attr('placeholder', 'Username');
            $('.ctlp').attr('placeholder', 'Password');
        });

        $.key('enter', function () {

            $("[id*=LoginButton]").click();

        });

    </script>
</head>
<%--<body bgcolor=" #C7EBFC">--%>
<body style="background-image: url(/images/background.jpeg); background-repeat: no-repeat;background-size:cover">
    <div style="margin-bottom: 50px;">
        </div>
    <div style="padding: 10px; background-color: #FFFFFF; width: 350px; height: 420px;
        margin: auto; border: solid 2px #1e90ff; border-radius: 15px; -webkit-border-radius: 15px;"> <%--#1e90ff--%>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div align="center" style="height: 40%; margin-top: 10px;">
            <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/Logo.jpg" Height="100px" />
        </div>
        &nbsp;<div align="center" style="width: 100%; height: 217px;">
            <%--<asp:Login ID="Login1" runat="server" Height="194px" Width="377px" 
            OnAuthenticate="ValidateUser" BackColor="#FFFBD6" BorderColor="#FFDFAD" 
            BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0" style="height:194px;width:377px;">
                                <tr>
                                    <td align="center" colspan="2" 
                                        
                                        
                                        
                                        style="color:White;background-color:#996633; font-size:X-Large;font-weight:bold;text-decoration:none;">
                                        Log In</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" AutoPostBack="True"  
                                             ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                            ForeColor="Red" ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                            ForeColor="Red" ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                       <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownList1">Business</asp:Label> </td>
                                    <td >
                                        <asp:DropDownList ID="DropDownList1" runat="server" Height="29px" 
                                            Width="136px"  
                                             >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                              
                                <tr>
                                    <td colspan="2" style="text-align: left">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                            ValidationGroup="Login1" onclick="LoginButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" 
                ForeColor="White" />
        </asp:Login>--%>
            <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <table cellpadding="0" style="height: 194px; width: 300px; ">
                            <tr>                                              <%--79B7E4--%>
                                <td align="center" colspan="2" style="color: #19803a; background: url('/images/ui-bg_gloss-wave_55_5c9ccc_500x100.png') repeat-x;
                                    font-size: X-Large; font-weight: bold; text-decoration: none;background-size:100% 35px;   width: 100%; height: 35px;
                                    font-family: Comic Sans MS;">
                                     <%-- Authentication--%>
                                </td>
                            </tr>
                            <tr>
                                <%--<td align="right" style="padding-right: 10px; padding-top: 10px; padding-right: 10px;"
                                    class="style1">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                </td>--%>
                                <td style="padding-top: 10px; text-align: center; padding-left: 10px;" colspan="2" >
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                   <ContentTemplate>
                                    <asp:TextBox ID="UserName" runat="server" AutoPostBack="True" OnTextChanged="UserName_TextChanged"
                                        Width="250px" CssClass="ctl ctlu"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ForeColor="Red" ToolTip="User Name is required."
                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                         </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                               <%-- <td align="right" style="padding-right: 10px; padding-right: 10px;" class="style1">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                </td>--%>
                                <td colspan="2" style="text-align: center; padding-left: 10px;">
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="250px" CssClass="ctl ctlp"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ForeColor="Red" ToolTip="Password is required."
                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <%--<td align="right" style="padding-right: 10px; padding-right: 10px;" class="style1">
                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownList1">Business</asp:Label>
                                </td>--%>
                                <td colspan="2" style="text-align: center; padding-left: 10px;">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                   <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="256px" CssClass="ctl">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="PasswordRequired0" runat="server" ControlToValidate="DropDownList1"
                                        ErrorMessage="Password is required." ForeColor="Red" ToolTip="Password is required."
                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                         </asp:UpdatePanel>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="center" colspan="2" style="color: Red; padding: 5px;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="padding-right: 5px; padding-bottom: 10px; padding-left: 10px; ">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1"
                                        OnClick="LoginButton_Click" CssClass="bttn" />
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
                <br/>
            <%--         <asp:Login ID="Login1" runat="server">
    </asp:Login>--%>
        </div>
        <div align="center" style="height: 40%; margin-top: 5px;">
            <asp:Image ID="Image2" runat="server" ImageAlign="Middle" ImageUrl="~/images/edusoft_logo.jpg" Height="70px" />
        </div>
        </form>
    </div>
    <div align="center" style="padding-top: 10px;">
        ©2020 Business Manager</div>
</body>
</html>
