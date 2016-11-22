<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master_ACHEQA.Master"
    CodeBehind="Quote_Create.aspx.cs" Inherits="ACHEQA_Parametric_Automation.Quote_Create" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="lotusContent">
                    <div class="lotusHeader">
                       
                        <br />
                        <asp:HyperLink ID="hl_quotes" runat="server" NavigateUrl="~/QuoteHome.aspx">My Quotes</asp:HyperLink>
                        &gt;<asp:Label ID="hl_tags" runat="server">Create New Quote</asp:Label>
                        <br />
                        <br />
                      <%--  <h1>
                            <span class="style358">Create New Quote</span>
                        </h1>--%>
                  
                    </div>
                    <div class="lotusBtnContainer">
                        <!-- **** NOTE These buttons are using the span method, there is also a method using <button> and <input type="submit/button"> -->
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red"></asp:Label>
                    </div>
                    <!--end button container-->
                    <table class="NQstyle7" textalign="left" cellspacing="0px" 
                        style="background-color: #FFFFFF">
                        <tr>
                            <td class="style345">
                                Quote Number
                            </td>
                            <td class="style354">
                                &nbsp;</td>
                            <td class="style357">
                                <div style="width: 20%; background: transparent; display: inline-block; float: left;">
                                    <asp:DropDownList ID="ddlQuotePrefix" runat="server" Width="100%" Height="24px">
                                        <asp:ListItem>Q</asp:ListItem>
                                        <asp:ListItem>H</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                   <div style="width: 5%; display: inline-block; float: left;">&nbsp;&nbsp; </div>
                                <div style="width: 27%; display: in
                                    line-block; float: left;">
                                    <asp:TextBox ID="txtQYear" runat="server" CssClass="style351" onkeyup="flushlbl()"
                                        Width="80%" MaxLength="4"></asp:TextBox>
                                   
                                </div>
                                <div style="width: 3%; display: inline-block; float: left;"></div>
                                 <div style="width: 45%; display: inline-block; float: left;">
                                    <asp:TextBox ID="txtQuoteno" runat="server" CssClass="style351" 
                                         onkeyup="flushlbl();" onblur="PrefixZero(this);"
                                        Width="89%" MaxLength="5"></asp:TextBox>
                                    
                                </div>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuoteno"
                                    ErrorMessage="* Quote No Required" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style345">
                                Customer
                            </td>
                            <td class="style354">
                                &nbsp;</td>
                            <td class="style357">
                                <asp:TextBox ID="txtCustomer" runat="server" CssClass="style351" Width="92%"></asp:TextBox>
                               
                            </td>
                            <td>
                                &nbsp;
                                <asp:TextBox ID="txtTagNo" runat="server" CssClass="style351" Height="16px" 
                                    Visible="False" Width="14%"></asp:TextBox>
                                <asp:TextBox ID="txtRevision" runat="server" CssClass="style351" Height="16px" 
                                    Visible="False" Width="26%"></asp:TextBox>
                               
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="style345">
                                Project
                            </td>
                            <td class="style354">
                                &nbsp;</td>
                            <td class="style357">
                                <asp:TextBox ID="txtProject" runat="server" CssClass="style351" Width="92%"></asp:TextBox>
                              
                            </td>
                            <td>
                                &nbsp;
                                <asp:TextBox ID="txtTableName" runat="server" Visible="False" Height="26px" 
                                    Width="27px"></asp:TextBox>
                                <asp:TextBox ID="txtMHFUrl" runat="server" Height="17px" Visible="False" 
                                    Width="22px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style345">
                                &nbsp;</td>
                            <td class="style354">
                                &nbsp;</td>
                            <td class="style357">
                                <asp:Button ID="btnOpen" runat="server" 
                                    CssClass="lotusBtn lotusBtnAction lotusLeft" Font-Bold="True"  
                                   Text="Create" Width="150px" Font-Size="11px" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style345" colspan="4">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/run.gif" Width="25px" />
                                        Checking Quote availability
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="max-width: 890px">
                    </div>
                    <!--end button container-->
                </div>
</asp:Content>
