<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="CSS/Login.css" rel="stylesheet" type="text/css" />
</head>
<body style="font-family:Verdana; font-size:small">
    <form id="form1" runat="server">
    <div id="wrapper">
        <asp:Login ID="UserLogin" runat="server" OnAuthenticate="Login_Authenticate">
            <LayoutTemplate>
                <div id="headerLeft">
                    <div id="headerRight">
                        <div id="headerMid">
                            &nbsp;Login
                        </div>     
                    </div>
                </div>   
                <div id="container">
                    <asp:Panel ID="pnlLogin" runat="server" style="padding-top:30px" DefaultButton="btnLogin">
                        <table border="0" cellspacing="3" cellpadding="2" style="margin:auto">
                            <tr valign="middle">
                                <td colspan="2">
                                    <asp:Label ID="FailureText" runat="server" 
                                        ForeColor="Red" 
                                        EnableViewState="false" />
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td align="right">
                                    <asp:Label ID="lblUserName" runat="server" 
                                        Text="User Name"
                                        AssociatedControlID="UserName" 
                                        EnableViewState="false" />
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="UserName" style="text-shadow:gray" Width="150" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:label ID="lblPassword" runat="server"
                                        Text="Password"
                                        AssociateCOntrolID="Password"
                                        EnableViewState="false" />
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Password" TextMode="Password" Width="150" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:button ID="btnLogin" Text="Login" CommandName="Login" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div id="footerLeft">
                    <div id="footerRight">
                        <div id="footerMid">
                
                        </div>
                    </div>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
    </form>
</body>
</html>
