<%@ Page Title="" Language="C#" MasterPageFile="~/Master_ACHEQA.Master" AutoEventWireup="true"
    CodeBehind="ProcedureInputs.aspx.cs" Inherits="ACHEQA_Parametric_Automation.ProcedureInputs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upProcInput" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlProcedures" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstProcList_SelectedIndexChanged" Visible="False">
            </asp:DropDownList>
          
            <asp:Label ID="lblMandatory" runat="server" ForeColor="Red">Fields marked with * are mandatory.</asp:Label>
            <br />
            <br />
            <asp:GridView ID="dgvInputVariables" runat="server" AutoGenerateColumns="False" 
                CssClass="lotusTable lotusChunk" GridLines="None" AutoGenerateSelectButton="False"
                AllowSorting="True" Width="35%" OnRowDataBound="dgvInputVariables_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="CatID" SortExpression="Lookup Category" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblLookCatID" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "LookupCatID")  %>'
                                class="lotusMeta" Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Procedure Name" SortExpression="Variable Name" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblProcname" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProcName")  %>'
                                class="lotusMeta"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DESCRIPTION" SortExpression="Display Name" >
                        <ItemTemplate>
                            <asp:Label ID="lblDispNAme" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Display Name")  %>'
                                class="lotusMeta" Width="130px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VID" SortExpression="FullName" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblVarID" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "VarID")  %>'
                                class="lotusMeta"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VALUE" SortExpression="Control Type">
                        <ItemTemplate>
                            <asp:TextBox ID="txtInput" runat="server" class="lotusMeta" Width="300px"  Height="18px"></asp:TextBox>
                            <asp:DropDownList ID="ddlInput" runat="server" class="lotusMeta" Width="305px" Height="22px">
                            </asp:DropDownList>
                            <asp:Label ID="lblControlType" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Control Type")  %>'
                                class="lotusMeta" Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" SortExpression="IsRequried">
                        <ItemTemplate>
                            <asp:Label ID="lblIsRequried" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "IsRequried")  %>'
                                class="lotusMeta" Visible="False"></asp:Label>
                            <asp:Label ID="lblShowRequried" runat="server" Text="*" class="lotusMeta" ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Active Status" SortExpression="IsActive">
                    <ItemTemplate>
                        <asp:Label ID="lblisActive" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "IsActive")  %>'
                            class="lotusMeta"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <%-- <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Edit.png" CommandName="btnEdit" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lblnorecord" runat="server" Font-Bold="True" ForeColor="Red" Text="No Record Found"></asp:Label>
                </EmptyDataTemplate>
                <HeaderStyle ForeColor="#2C70D5" />
            </asp:GridView>
            <asp:Label ID="lblerr" runat="server" ForeColor="Red"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
