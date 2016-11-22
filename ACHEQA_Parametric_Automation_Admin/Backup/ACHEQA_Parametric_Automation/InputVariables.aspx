<%@ Page Title="" Language="C#" MasterPageFile="~/Master_ACHEQA.Master" AutoEventWireup="true"
    CodeBehind="InputVariables.aspx.cs" Inherits="ACHEQA_Parametric_Automation.InputVariables" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function DoListBoxFilter(listBoxSelector, filter, keys, values) {

            var list = $(listBoxSelector);
            var selectBase = '<option value="{0}">{1}</option>';

            list.empty();
            for (i = 0; i < values.length; ++i) {

                var value = values[i];
                if (filter == "") {
                    var temp = '<option value="' + keys[i] + '">' + value + '</option>';
                    list.append(temp);
                }
                else {
                    if (value == "" || value.toLowerCase().indexOf(filter.toLowerCase()) >= 0) {
                        var temp = '<option value="' + keys[i] + '">' + value + '</option>';
                        list.append(temp);
                    }
                }
            }
        }

        $(document).ready(function () {
            //SET LOOKUP CATEGORY TEXT BOX
            var lcat = document.getElementById("<%= txtLookupCat.ClientID %>");
            if (lcat.value == '') {
                lcat.value = 'Type here to search';
                lcat.disabled = true;
            }
            else
                lcat.disabled = false;
            $('#<% = txtLookupCat.ClientID %>').keyup(function () {
                var filter = $(this).val();
                var keys = [];
                var values = [];
                var options = $('#<% = lstLookupDataHidden.ClientID %> option');
                $.each(options, function (index, item) {
                    keys.push(item.value);
                    values.push(item.innerHTML);
                });
                DoListBoxFilter('#<% = lstLookupData.ClientID %>', filter, keys, values); // keys_<% = this.ClientID %>, values_<% = this.ClientID %>);
            });
        });
        function setLCat() {
            alert($('#<% = txtLookupCat.ClientID %>').val());
        }
    </script>
    <script language="javascript" type="text/javascript">
        function showPanel() {
            document.getElementById("<%= lstLookupData.ClientID %>").style.display = 'block';
            document.getElementById("<%= txtLookupCat.ClientID %>").style.color = 'black';
            document.getElementById("<%= txtLookupCat.ClientID %>").value = '';
            document.getElementById('bg_mask').style.visibility = 'visible';
            document.getElementById('frontlayer').style.visibility = 'visible';
            var ctrl = document.getElementById("<%= txtLookupCat.ClientID %>");
            var position = ctrl.getBoundingClientRect();
            document.getElementById('bg_mask').style.top = position.top + 20 + 'px';
            document.getElementById('bg_mask').style.left = -560 + 'px';
        }
        function hidePanel() {
            document.getElementById("<%= lstLookupData.ClientID %>").style.display = 'none';
            document.getElementById("<%= txtLookupCat.ClientID %>").style.color = 'silver';
            document.getElementById("<%= txtLookupCat.ClientID %>").value = 'Type here to search';
            document.getElementById('bg_mask').style.visibility = 'hidden';
            document.getElementById('frontlayer').style.visibility = 'hidden';
        }
        function showFrontLayer() {
            document.getElementById('bg_mask').style.visibility = 'visible';
            document.getElementById('frontlayer').style.visibility = 'visible';
        }
        function hideFrontLayer() {
            document.getElementById('bg_mask').style.visibility = 'hidden';
            document.getElementById('frontlayer').style.visibility = 'hidden';
        }
        function setLookup(ctrlType) {
            if (document.getElementById("<%= ddlControlType.ClientID %>").value == 'Lookup Value') {
                document.getElementById("<%= txtLookupCat.ClientID %>").disabled = false
            }
            else {
                document.getElementById("<%= txtLookupCat.ClientID %>").disabled = true
                document.getElementById("<%= txtLookupID.ClientID %>").value = '';
                document.getElementById("<%= txtLookupCat.ClientID %>").value = 'Type here to search';
            }
        }
    </script>
    <style type="text/css">
        #bg_mask
        {
            position: absolute;
            top: 0px;
            right: 0px;
            bottom: 0;
            left: 0px;
            margin: auto;
            margin-top: 0px;
            width: 514px;
            height: 72px;
            background-color: gray;
            z-index: 0;
            visibility: hidden;
        }
        
        #frontlayer
        {
            position: absolute;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            margin: 0px 0px 0px 0px;
            padding: 0px;
            width: 514px;
            height: 72px;
            background-color: silver;
            visibility: hidden;
            border: 0px solid black;
            z-index: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMain" runat="server">
        <ContentTemplate>
            <div id="baselayer">
                <table>
                    <tr>
                        <td>
                            Procedures
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            &nbsp;<asp:DropDownList ID="ddlProcedures" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProcedures_SelectedIndexChanged"
                                Height="20px" Width="518px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Control Type
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            &nbsp;<asp:DropDownList ID="ddlControlType" runat="server" onchange="setLookup(this);">
                                <asp:ListItem>-Select-</asp:ListItem>
                                <asp:ListItem>Free Text</asp:ListItem>
                                <asp:ListItem>Lookup Value</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Lookup Category
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtLookupCat" runat="server" ForeColor="Black" Width="478px"
                                onfocus="showPanel();" onblur="hidePanel();">Type here to search</asp:TextBox>
                            <asp:TextBox ID="txtLookupID" runat="server" Width="30px" Enabled="False"></asp:TextBox>
                            <div id="bg_mask">
                                <div id="frontlayer">
                                    <asp:ListBox ID="lstLookupData" runat="server" Rows="5" Height="72px" OnSelectedIndexChanged="lstLookupData_SelectedIndexChanged"
                                        onfocus="showPanel();" Width="514px" AutoPostBack="True" OnTextChanged="lstLookupData_TextChanged"
                                        BackColor="Silver"></asp:ListBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Variable Name:
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            &nbsp;<asp:Label ID="lblPrefix" runat="server">@XXX_</asp:Label>
                            <asp:TextBox ID="txtVariableName" runat="server" Width="469px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Display Name:
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtDiplayName" runat="server" Width="514px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mandatory
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:CheckBox ID="chkMandatory" runat="server" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Active
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;<asp:Button ID="btnSave" runat="server" Text="Add Variable" OnClick="btnSave_Click"
                                CssClass="lotusBtn lotusBtnAction lotusLeft" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click"
                                CssClass="lotusBtn lotusBtnAction lotusLeft" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblerr" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="dgvInputVariables" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    CssClass="lotusTable lotusChunk" GridLines="None" AutoGenerateSelectButton="False"
                    AllowSorting="True" Width="60%" OnRowCommand="dgvInputVariables_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Lookup Category" SortExpression="Lookup Category">
                            <ItemTemplate>
                                <asp:Label ID="lblLookCat" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Lookup Category")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Variable Name" SortExpression="Variable Name">
                            <ItemTemplate>
                                <asp:Label ID="lblVarname" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Variable Name")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Display Name" SortExpression="Display Name">
                            <ItemTemplate>
                                <asp:Label ID="lblDispNAme" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Display Name")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VID" SortExpression="FullName" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblVarID" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "VarID")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LookupCatID" SortExpression="FullName" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblLookupCatID" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "LookupCatID")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Control Type" SortExpression="Control Type">
                            <ItemTemplate>
                                <asp:Label ID="lblControlType" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Control Type")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mandatory" SortExpression="IsRequried">
                            <ItemTemplate>
                                <asp:Label ID="lblIsRequried" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "IsRequried")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active Status" SortExpression="IsActive">
                            <ItemTemplate>
                                <asp:Label ID="lblisActive" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "IsActive")  %>'
                                    class="lotusMeta"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Edit.png" CommandName="btnEdit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Link Ref Clause">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnLinkRefClause" runat="server" ImageUrl="~/Images/Link1.jpg"
                                    CommandName="btnLink" Height="19" Width="19" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblnorecord" runat="server" Font-Bold="True" ForeColor="Red" Text="No Record Found"></asp:Label>
                    </EmptyDataTemplate>
                    <HeaderStyle ForeColor="#2C70D5" />
                </asp:GridView>
            </div>
            <asp:Panel ID="pnLookupCatData" runat="server" Style="background-color: White; width: 600px;
                text-align: right; border: 1px solid black">
                <asp:ImageButton ID="imgbtnClose" runat="server" ImageUrl="~/Images/Cancel.jpg" Width="20px" />
                <div style="text-align: center; width: auto; background-color: #345c70; height: 25px;
                    vertical-align: middle;">
                    <asp:Label ID="lblGridTitle" runat="server" Text="Select related references" BackColor="#345C70"
                        ForeColor="White" Font-Bold="True" Font-Size="Medium"></asp:Label></div>
                <br />
                <div style='overflow: scroll; width: 100%; height: 400px;'>
                    <asp:GridView ID="dgvRefClause" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        AutoGenerateSelectButton="False" CssClass="lotusTable lotusChunk" GridLines="None"
                        Width="100%" OnRowDataBound="dgvRefClause_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="ProcNotes_ID" SortExpression="ProcNotes_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblProcNoteID" runat="server" class="lotusMeta" Text='<%# DataBinder.Eval (Container.DataItem, "ProcNotes_ID")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SequenceNumber" SortExpression="SequenceNumber" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblSequenceNumber" runat="server" class="lotusMeta" Text='<%# DataBinder.Eval (Container.DataItem, "SequenceNumber")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select Note">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkLink" runat="server" Width="30px" AutoPostBack="true" OnCheckedChanged="chkLink_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial Number" SortExpression="SerialNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNumber" runat="server" class="lotusMeta" Text='<%# DataBinder.Eval (Container.DataItem, "SerialNumber")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                                <ItemTemplate>
                                    <asp:Label ID="lblNotes" runat="server" class="lotusMeta" Text='<%# DataBinder.Eval (Container.DataItem, "Notes")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblnorecord" runat="server" Font-Bold="True" ForeColor="Red" Text="No Record Found"></asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle ForeColor="#2C70D5" />
                    </asp:GridView>
                </div>
                <div style="text-align: center">
                    <br />
                    <asp:Label ID="lblRefSelected" runat="server" Text="Selected Reference Clauses are: "></asp:Label>
                    <asp:Button ID="btnSaveRef" runat="server" Text="Save Reference" CssClass="lotusBtn lotusBtnAction lotusLeft"
                        OnClick="btnSaveRef_Click" />
                </div>
                <br />
                <asp:ListBox ID="lstLookupDataHidden" runat="server" Height="289px" Visible="False"
                    Width="215px"></asp:ListBox>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="modelProcNotes" runat="server" TargetControlID="btnModel"
                PopupControlID="pnLookupCatData" CancelControlID="imgbtnClose">
            </cc1:ModalPopupExtender>
            <asp:Button ID="btnModel" runat="server" Text="try" Style="display: none" />
            <asp:HiddenField ID="hf_vid" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
