﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master_ACHEQA.Master" AutoEventWireup="true"
    CodeBehind="lookups.aspx.cs" Inherits="ACHEQA_Parametric_Automation_Admin.lookups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">

        function AllValidate() {

            var lookCat = document.getElementById("<%= DDL_LOOKUP_CATG_ID.ClientID %>");
            var valueDisc = document.getElementById("<%= TXT_DISPLAYTEXT.ClientID %>");

            if (valueDisc.value == '' || lookCat.value == '-1') {

                alert('Fields mark with * must have values');
                return false;
            }
            else return true;
        }
        function clearLable() {
            //        alert(document.getElementById("MainContent_lblerr").innerHTML);
            document.getElementById("MainContent_lblerr").innerHTML = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Lookups Entry</h2>
    <br />
    <br />
    <div>
        <table class='tabletext'>
            <tr>
                <td>
                    Lookup Category
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="DDL_LOOKUP_CATG_ID" AutoPostBack="true" OnSelectedIndexChanged="DDL_LOOKUP_CATG_ID_SelectedIndexChanged"
                        Width="503px" Height="20px" onfocus="clearLable(); this.select();">
                    </asp:DropDownList>
                    <span style="color: Red; font-size: medium">*</span>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    Valuetext
                </td>
                <td>
                    <asp:TextBox runat="server" class="entrytextbox" ID="TXT_VALUETEXT" Width="500px"
                        onfocus="clearLable(); this.select();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Displaytext
                </td>
                <td>
                    <asp:TextBox runat="server" class="entrytextbox" ID="TXT_DISPLAYTEXT" Width="500px"
                        onfocus="clearLable(); this.select();"></asp:TextBox>
                    <span style="color: Red; font-size: medium">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    Flexfield1 &nbsp;&nbsp;<asp:Label runat="server" ID="lblff1" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD1" Width="500px"
                        onfocus="clearLable(); this.select();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Flexfield2 &nbsp;&nbsp;<asp:Label runat="server" ID="lblff2" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD2" Width="500px"
                        onfocus="clearLable(); this.select();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Flexfield3 &nbsp;&nbsp;<asp:Label runat="server" ID="lblff3" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD3" Width="500px"
                        onfocus="clearLable(); this.select();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Flexfield4 &nbsp;&nbsp;<asp:Label runat="server" ID="lblff4" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD4" Width="500px"
                        onfocus="clearLable(); this.select();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Flexfield5 &nbsp;&nbsp;<asp:Label runat="server" ID="lblff5" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD5" Width="500px"
                        onfocus="clearLable(); this.select();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Rowactive
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="CHK_ROWACTIVE"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnsave" runat="server" Text="Save" CommandName="SAVE" OnClick="btnsave_Click"
                        OnClientClick="return AllValidate();" /><br />
                    <asp:Label runat="server" ID="lblerr" ForeColor="Red" />
                </td>
            </tr>
        </table>
        <asp:DataList RepeatLayout="Table" CellSpacing="0" CellPadding="0" runat="server"
            ID="dlentry" OnItemCommand="dlentry_ItemCommand" OnItemDataBound="dlentry_ItemDataBound">
            <HeaderTemplate>
                <table cellspacing="0" cellpadding="4" rules="none" border="0" style="border-style: none;
                    width: 100%; color: #333333; font-size: 8pt;">
                    <tr style="color: White; background-color: #5D7B9D; font-weight: bold;">
                        <th>
                            Lookup catg id
                        </th>
                        <th style="display: none">
                            Valuetext
                        </th>
                        <th style="width: 300px">
                            Displaytext
                        </th>
                        <th>
                            Flexfield1<br />
                            <asp:Label runat="server" ID="hlblff1" ForeColor="White"></asp:Label>
                        </th>
                        <th>
                            Flexfield2<br />
                            <asp:Label runat="server" ID="hlblff2" ForeColor="White"></asp:Label>
                        </th>
                        <th>
                            Flexfield3<br />
                            <asp:Label runat="server" ID="hlblff3" ForeColor="White"></asp:Label>
                        </th>
                        <th>
                            Flexfield4<br />
                            <asp:Label runat="server" ID="hlblff4" ForeColor="White"></asp:Label>
                        </th>
                        <th>
                            Flexfield5<br />
                            <asp:Label runat="server" ID="hlblff5" ForeColor="White"></asp:Label>
                        </th>
                        <th>
                            Rowactive
                        </th>
                        <th>
                            &nbsp;
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="color: #333333; background-color: #F7F6F3;">
                    <td>
                        <%#Eval("LOOKUP_CATG_ID")%>
                    </td>
                    <td style="display: none">
                        <%#Eval("VALUETEXT")%>
                    </td>
                    <td>
                        <%#Eval("DISPLAYTEXT")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD1")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD2")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD3")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD4")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD5")%>
                    </td>
                    <td>
                        <%#Eval("ROWACTIVE")%>
                    </td>
                    <td>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="EDIT" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="color: #333333; background-color: #cae6e8;">
                    <td>
                        <%#Eval("LOOKUP_CATG_ID")%>
                    </td>
                    <td style="display: none">
                        <%#Eval("VALUETEXT")%>
                    </td>
                    <td>
                        <%#Eval("DISPLAYTEXT")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD1")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD2")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD3")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD4")%>
                    </td>
                    <td>
                        <%#Eval("FLEXFIELD5")%>
                    </td>
                    <td>
                        <%#Eval("ROWACTIVE")%>
                    </td>
                    <td>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="EDIT" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #cccccc;">
                    <td valign='top' colspan="7">
                        <%-- <table>
                            <tr>
                                <td valign='top'>--%>
                        <table style="border: 1px solid black; width: 100%;">
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Lookup catg id
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="DDL_LOOKUP_CATG_ID_1" Width="504px" Height="20">
                                    </asp:DropDownList>
                                    <asp:HiddenField runat="server" ID="hf_rowID" Value='<%#Eval("Row_ID")%>' />
                                    <span style="color: Red; font-size: medium">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: none">
                                    Valuetext
                                </td>
                                <td style="display: none">
                                    <asp:TextBox runat="server" Text='<%#Eval("VALUETEXT")%>' class="entrytextbox" ID="TXT_VALUETEXT_1"
                                        Width="500px" Height="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Displaytext
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Text='<%#Eval("DISPLAYTEXT")%>' class="entrytextbox"
                                        ID="TXT_DISPLAYTEXT_1" Width="500px"></asp:TextBox>
                                    <span style="color: Red; font-size: medium">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Flexfield1
                                    <br />
                                    <asp:Label runat="server" ID="edlblff1" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD1")%>' class="entrytextbox" ID="TXT_FLEXFIELD1_1"
                                        Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Flexfield2
                                    <br />
                                    <asp:Label runat="server" ID="edlblff2" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD2")%>' class="entrytextbox" ID="TXT_FLEXFIELD2_1"
                                        Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Flexfield3
                                    <br />
                                    <asp:Label runat="server" ID="edlblff3" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD3")%>' class="entrytextbox" ID="TXT_FLEXFIELD3_1"
                                        Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Flexfield4
                                    <br />
                                    <asp:Label runat="server" ID="edlblff4" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD4")%>' class="entrytextbox" ID="TXT_FLEXFIELD4_1"
                                        Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Flexfield5
                                    <br />
                                    <asp:Label runat="server" ID="edlblff5" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD5")%>' class="entrytextbox" ID="TXT_FLEXFIELD5_1"
                                        Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; font-weight: bold;">
                                    Rowactive
                                </td>
                                <td>
                                    <asp:CheckBox runat="server" ID="CHK_ROWACTIVE_1"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnupdate" runat="server" Text="Update" CommandName="UPDATE" />&nbsp;
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CommandName="CANCEL" />&nbsp;
                                    <br />
                                    <asp:Label runat="server" ID="lblerrlab" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <%--</td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
            </EditItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:DataList>
    </div>
</asp:Content>
