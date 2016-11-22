<%@ Page Title="" Language="C#" MasterPageFile="~/Master_ACHEQA.Master" AutoEventWireup="true"
    CodeBehind="lookupcategories.aspx.cs" Inherits="ACHEQA_Parametric_Automation_Admin.lookupcategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">

        function AllValidate() {

            var catName = document.getElementById("<%= TXT_LOOKUP_CATG_NAME.ClientID %>");
            var catDisc = document.getElementById("<%= TXT_CATG_DESCRIPTION.ClientID %>");

            if (catName.value == '' || catDisc.value == '') {
                
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
        Lookup Categories</h2>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--  <table class='tabletext'>
                <tr>
                    <td valign='top'>--%>
            <table border="0" width="50%">
               
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Lookup category name
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="entrytextbox" ID="TXT_LOOKUP_CATG_NAME" onfocus="clearLable(); this.select();" Width="500px"></asp:TextBox>
                        <span style="color: Red; font-size: medium">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Category description
                    </td>
                    <td>
                        <asp:TextBox runat="server" class="entrytextbox" ID="TXT_CATG_DESCRIPTION" Width="500px"></asp:TextBox>
                        <span style="color: Red; font-size: medium">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Reference Clause
                    </td>
                    <td>
                        <asp:TextBox runat="server" class="entrytextbox" ID="TXT_REF_CLAUSE" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Flexfield1 name
                    </td>
                    <td>
                        <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD1_NAME" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Flexfield2 name
                    </td>
                    <td>
                        <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD2_NAME" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Flexfield3 name
                    </td>
                    <td>
                        <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD3_NAME" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Flexfield4 name
                    </td>
                    <td>
                        <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD4_NAME" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Flexfield5 name
                    </td>
                    <td>
                        <asp:TextBox runat="server" class="entrytextbox" ID="TXT_FLEXFIELD5_NAME" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; font-weight:bold;">
                        Sort Expression
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="DDL_SORTEXPRESSION">
                            <asp:ListItem Text="DisplayText" Value="DisplayText"></asp:ListItem>
                            <asp:ListItem Text="ValueText" Value="ValueText"></asp:ListItem>
                            <asp:ListItem Text="FlexField1" Value="FlexField1"></asp:ListItem>
                            <asp:ListItem Text="FlexField2" Value="FlexField2"></asp:ListItem>
                            <asp:ListItem Text="FlexField3" Value="FlexField3"></asp:ListItem>
                            <asp:ListItem Text="FlexField4" Value="FlexField4"></asp:ListItem>
                            <asp:ListItem Text="FlexField5" Value="FlexField5"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList runat="server" ID="ddl_direction">
                            <asp:ListItem Text="Ascending" Value="ASC"></asp:ListItem>
                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnsave" runat="server" Text="Save" CommandName="SAVE" OnClick="btnsave_Click"
                            OnClientClick="return AllValidate();" /><br>
                        <asp:Label runat="server" ID="lblerr" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%-- </td>
                    
                </tr>
            </table>--%>
            <p style="color:Blue;">
                Points to note :
                <ul  style="color:Blue;">
                    <li>Use unique names while creating a new Lookup Category</li>
                </ul>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
            </p>
            <asp:DataList RepeatLayout="Table" CellSpacing="0" CellPadding="0" runat="server"
                ID="dlentry" Width="90%" OnItemCommand="dlentry_ItemCommand" OnItemDataBound="dlentry_ItemDataBound">
                <HeaderTemplate>
                    <table cellspacing="0" cellpadding="4" rules="none" border="0" style="width: 100%;
                        color: #333333; font-size: 8pt;">
                        <tr style="color: White; background-color: #5D7B9D; font-weight: bold;">
                            <%-- <th>ApplicationID</th>--%>
                            <th>
                                Lookup category name
                            </th>
                            <th>
                                Category description
                            </th>
                            <th>
                                Reference Clause
                            </th>
                            <th>
                                Flexfield1 name
                            </th>
                            <th>
                                Flexfield2 name
                            </th>
                            <th>
                                Flexfield3 name
                            </th>
                            <th>
                                Flexfield4 name
                            </th>
                            <th>
                                Flexfield5 name
                            </th>
                            <th>
                                SortExpression
                            </th>
                            <th>
                                &nbsp;
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="color: #333333; background-color: #F7F6F3;">
                        <%-- <td><%#Eval("ApplicationID")%></td>--%>
                        <td>
                            <%#Eval("LOOKUP_CATG_NAME")%>
                        </td>
                        <td>
                            <%#Eval("CATG_DESCRIPTION")%>
                        </td>
                        <td>
                            <%#Eval("RefClause")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD1_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD2_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD3_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD4_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD5_NAME")%>
                        </td>
                        <td>
                            <%#Eval("SORTEXPRESSION")%>
                        </td>
                        <td>
                            <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="EDIT" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="color: #333333; background-color: #cae6e8;">
                        <%--   <td><%#Eval("ApplicationID")%></td>--%>
                        <td>
                            <%#Eval("LOOKUP_CATG_NAME")%>
                        </td>
                        <td>
                            <%#Eval("CATG_DESCRIPTION")%>
                        </td>
                        <td>
                            <%#Eval("RefClause")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD1_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD2_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD3_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD4_NAME")%>
                        </td>
                        <td>
                            <%#Eval("FLEXFIELD5_NAME")%>
                        </td>
                        <td>
                            <%#Eval("SORTEXPRESSION")%>
                        </td>
                        <td>
                            <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="EDIT" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #CCCCCC;">
                        <td valign='top' colspan="3">
                            <table style="border: 1px solid black; width: 100%;">
                               
                                <tr style="border: 1px solid black;">
                                    <td style="width: 150px; font-weight:bold;">
                                        Lookup category name
                                    </td>
                                    <td>
                                        <asp:HiddenField runat="server" ID="hf_nlookupcatid" Value='<%#Eval("Lookup_Catg_ID")%>' />
                                        <asp:TextBox runat="server" Text='<%#Eval("LOOKUP_CATG_NAME")%>' CssClass="entrytextbox"
                                            ID="TXT_LOOKUP_CATG_NAME_1" Width="500px"></asp:TextBox>
                                        <span style="color: Red; font-size: medium">*</span>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblinfo"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Catg description
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Text='<%#Eval("CATG_DESCRIPTION")%>' class="entrytextbox"
                                            ID="TXT_CATG_DESCRIPTION_1" Width="500px"></asp:TextBox>
                                        <span style="color: Red; font-size: medium">*</span>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Referemce Clause
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Text='<%#Eval("RefClause")%>' class="entrytextbox" ID="TXT_REF_CLAUSE_1" Width="500px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Flexfield1 name
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD1_NAME")%>' class="entrytextbox"
                                            ID="TXT_FLEXFIELD1_NAME_1" Width="500px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblff1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Flexfield2 name
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD2_NAME")%>' class="entrytextbox"
                                            ID="TXT_FLEXFIELD2_NAME_1" Width="500px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblff2"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Flexfield3 name
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD3_NAME")%>' class="entrytextbox"
                                            ID="TXT_FLEXFIELD3_NAME_1" Width="500px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblff3"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Flexfield4 name
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD4_NAME")%>' class="entrytextbox"
                                            ID="TXT_FLEXFIELD4_NAME_1" Width="500px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblff4"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Flexfield5 name
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Text='<%#Eval("FLEXFIELD5_NAME")%>' class="entrytextbox"
                                            ID="TXT_FLEXFIELD5_NAME_1" Width="500px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblff5"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; font-weight:bold;">
                                        Sort Expression
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="DDL_SORTEXPRESSION" Width="245px" Height="20px">
                                            <asp:ListItem Text="DisplayText" Value="DisplayText"></asp:ListItem>
                                            <asp:ListItem Text="ValueText" Value="ValueText"></asp:ListItem>
                                            <asp:ListItem Text="FlexField1" Value="FlexField1"></asp:ListItem>
                                            <asp:ListItem Text="FlexField2" Value="FlexField2"></asp:ListItem>
                                            <asp:ListItem Text="FlexField3" Value="FlexField3"></asp:ListItem>
                                            <asp:ListItem Text="FlexField4" Value="FlexField4"></asp:ListItem>
                                            <asp:ListItem Text="FlexField5" Value="FlexField5"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:DropDownList runat="server" ID="ddl_direction" Width="250px" Height="20px">
                                            <asp:ListItem Text="Ascending" Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CommandName="UPDATE" Width="80" />&nbsp;
                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CommandName="CANCEL" Width="80" />&nbsp;
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
