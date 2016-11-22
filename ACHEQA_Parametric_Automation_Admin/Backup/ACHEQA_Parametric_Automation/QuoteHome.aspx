<%@ Page Title="ACHE QA Quotes" Language="C#" MasterPageFile="~/Master_ACHEQA.Master"
    AutoEventWireup="true" CodeBehind="QuoteHome.aspx.cs" Inherits="ACHEQA_Parametric_Automation.QA_QuoteHome" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <asp:UpdatePanel ID="upmain" runat="server">
        <ContentTemplate>
           <%-- <div class="lotusMain">--%>
                <!--end colLeft-->
                <%--<a id="lotusMainContent" name="lotusMainContent"></a>--%>
              <%--  <div class="lotusContent">--%>
                    <div class="lotusBtnContainer">
                        <!-- **** NOTE These buttons are using the span method, there is also a method using <button> and <input type="submit/button"> -->
                        <asp:Button ID="btn_newquote" runat="server" Text="Start a new Quote" Width="150px"
                            Font-Size="11px" CssClass="lotusBtn lotusBtnAction lotusLeft" 
                            OnClick="btn_newquote_Click" Visible="False" />
                    </div>
                    <!--end button container-->
                    <asp:GridView ID="dgvJobs" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        CssClass="lotusTable lotusChunk" GridLines="None" AutoGenerateSelectButton="False"
                        AllowSorting="True" Width="100%" onrowcommand="dgvJobs_OnRowCommand">
                        <Columns>
                             <asp:TemplateField HeaderText="Job No" SortExpression="Job_NUMBER">
                                <ItemTemplate>
                                    <asp:Label ID="lblJobNumber" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Job_NUMBER")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tag Number" SortExpression="TAG_NUMBER">
                                <ItemTemplate>
                                    <b>
                                        <asp:LinkButton ID="lnkTagReference" runat="server" Text='<%# Eval("TAG_NUMBER") %>'
                                            CommandName="lnkTagReference" CommandArgument='<%# Eval("TAG_NUMBER") %>'  Font-Size="8.5pt"></asp:LinkButton>
                                    </b>
                                    <%--  <asp:Label ID="lblquote" runat="server" 
                                            Text='<%# DataBinder.Eval (Container.DataItem, "Quote No")  %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Name" SortExpression="Customer Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Customer Name")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Name" SortExpression="Project Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProject" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Project Name")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Created By" SortExpression="FullName">
                                <ItemTemplate>
                                    <asp:Label ID="lblCrBy" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FullName")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="QID" SortExpression="FullName" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblqid" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "DesignSetID")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="MaterialName" SortExpression="MaterialName">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaterialName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "MaterialName")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="StandardName" SortExpression="StandardName" >
                                <ItemTemplate>
                                    <asp:Label ID="lblStandardName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "StandardName")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="ITPCodeName" SortExpression="ITPCodeName" >
                                <ItemTemplate>
                                    <asp:Label ID="lblITPCodeName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ITPCodeName")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="APIEditionName" SortExpression="APIEditionName" >
                                <ItemTemplate>
                                    <asp:Label ID="lblAPIEditionName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "APIEditionName")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="ITPClientName" SortExpression="ITPClientName" >
                                <ItemTemplate>
                                    <asp:Label ID="lblITPClientName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ITPClientName")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Last Updated" SortExpression="maxQD" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblLUQ" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "maxQD","{0:dd/MM/yyyy}")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Updated" SortExpression="maxDD">
                                <ItemTemplate>
                                    <asp:Label ID="lblLUD" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "maxDD","{0:dd/MM/yyyy}")  %>'
                                        class="lotusMeta"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Delete.png" CommandName="btndel" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Select Procedures">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnLink" runat="server" ImageUrl="~/Images/Link1.jpg" CommandName="btnLink" Height="19" Width="19" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblnorecord" runat="server" Font-Bold="True" ForeColor="Red" Text="No Record Found"></asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle ForeColor="#2C70D5" />
                    </asp:GridView>
                    <asp:Label ID="lblerr" runat="server" CssClass="styleLabel" ForeColor="Red"></asp:Label>
                    <!--end button container-->
              <%--  </div>--%>
                <!--end content-->
            <%--</div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
