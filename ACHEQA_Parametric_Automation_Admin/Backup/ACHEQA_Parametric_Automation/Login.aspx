<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ACHEQA_Parametric_Automation.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .logindiv
        {
            background-repeat: no-repeat;
            height: 280px;
            width: 720px;
            text-align: center;
            border: 1px solid #aaaaaa;
        }
        body
        {
            margin: 0px;
        }
        .Hyplnkbtn
        {
            font-family: Arial;
            color: #105CB6;
            height: 18px;
            display: block;
            text-decoration: none;
            white-space: nowrap;
        }
        a:hover.Hyplnkbtn
        {
            font-family: Arial;
            color: Black;
            text-decoration: underline;
            white-space: nowrap;
        }
        .footertxt
        {
            color: #666666;
            font-family: Arial;
            font-size: 7.5pt;
        }
        .btn
        {
            font-size: .9em;
            line-height: 1.7em;
        }
        .lotusBtnImg
        {
            background-color: #f1f1f1;
            background-image: -moz-linear-gradient(top, #ffffff 0%, #ebebeb 100%);
            background-image: -webkit-gradient(linear, left top, left bottom, from(#ffffff), to(#ebebeb));
            color: #000 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position: relative; left: 0px; top: 0px; width: 100%; height: 35px; background-color: #2e2e2e;
        white-space: nowrap;">
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr>
                <td width="10%" align="left" valign="middle">
                    <img src="Images/jordlogo.png" alt="JordLogo" />
                </td>
            </tr>
        </table>
        <div>
            <br />
            <br />
            <br />
            <br />
            <center>
                <div class="logindiv" style="background-color: White;"  onkeypress="javascript:return WebForm_FireDefaultButton(event, 'lnkLogin')">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="0" style="height: 280px; text-align: left; width: 100%; font-family: Arial;
                                font-weight: normal; font-size: 9pt; letter-spacing: 1px;" cellpadding="2" cellspacing="10">
                                <tr>
                                    <td align="center">
                                        <div style="width: 300px;">
                                            <img src="Images/JordLogo.gif" alt="JordSewonLogo"  style="width: 310px;height: 95px" /><br />
                                            <br />
                                            <br />
                                        </div>
                                    </td>
                                    <td style="border-right: 1px solid #aaaaaa;">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Welcome to Jord Eclipse" Font-Names="Arial"
                                                        Style="font-size: 20px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="color: black; font-size: 12pt;">ACHE QA Parametric Automation Program</span><br />
                                                    <br />
                                                    <asp:Label ID="Label2" runat="server" Text="User name:" Font-Bold="true" Font-Names="Arial"
                                                        Style="font-size: 12px;"></asp:Label>
                                                    <br />
                                                    <asp:TextBox runat="server" ID="txtUname" Width="250px" onfocus="clearlabel()"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Password:" Font-Bold="true" Font-Names="Arial"
                                                        Style="font-size: 12px;"></asp:Label>
                                                    <br />
                                                    <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" Width="250px" onfocus="clearlabel()">123</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" Style="font-size: 12px;"
                                                        Text="Domain:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td>
                                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                                        <asp:ListItem>Jord</asp:ListItem>
                                                        <asp:ListItem>Jord Sewon</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image1" runat="server" Height="25px" ImageUrl="~/Images/run.gif" Width="25px" />
                                                            &nbsp;Logging..
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblinvaliduser" ForeColor="Red"></asp:Label><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkLogin" runat="server" onclick="lnkLogin_Click"><img src="Images/LoginBtn.PNG" alt="Login"  border="0"/></asp:LinkButton>
                                                    <asp:HiddenField ID="hf_autologin" runat="server" Value="false" />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="footertxt">
                    <br />
                    © Copyright Jord international
                    <% = System.DateTime.Now.Year.ToString() %>. All rights reserved.
                    <asp:HyperLink ID="hyplnkJord" runat="server" Text="www.jord.com.au" NavigateUrl="http://www.jord.com.au/"
                        Target="_blank" CssClass="Hyplnkbtn"></asp:HyperLink>
                </div>
            </center>
        </div>
    </div>
    <div style="height: 6px; background-image: url('Images/blueline.png'); background-repeat: repeat-x;
        width: 100%;">
    </div>
    </form>
</body>
</html>
