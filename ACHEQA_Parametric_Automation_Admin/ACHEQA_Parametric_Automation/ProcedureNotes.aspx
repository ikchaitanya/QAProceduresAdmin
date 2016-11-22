<%@ Page Title="" Language="C#" MasterPageFile="~/Master_ACHEQA.Master" AutoEventWireup="true" CodeBehind="ProcedureNotes.aspx.cs" Inherits="ACHEQA_Parametric_Automation_Admin.ProcedureNotes" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" language="javascript">
        function Showalert_ProcedureList() {
            alert('Please Select "Procedure".');
        }
        function Showalert_Notes() {
            alert('Please Enter "Notes".');
        }
        function Showalert_Node() {
            alert('Please Select "Node".');
        }
    </script>
    <script type="text/javascript">
        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                if (src.checked == true) {
                    var nodeText = getNextSibling(src).innerText || getNextSibling(src).innerHTML;

                    var nodeValue = GetNodeValue(getNextSibling(src));

                    document.getElementById("label").innerHTML += nodeText + ",";
                }
                else {
                    var nodeText = getNextSibling(src).innerText || getNextSibling(src).innerHTML;
                    var nodeValue = GetNodeValue(getNextSibling(src));
                    var val = document.getElementById("label").innerHTML;
                    document.getElementById("label").innerHTML = val.replace(nodeText + ",", "");
                }
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;
                //check if nxt sibling is not null & is an element node
                if (nxtSibling && nxtSibling.nodeType == 1) {
                    //if node has children   
                    if (nxtSibling.tagName.toLowerCase() == "div") {
                        //check or uncheck children at all levels
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                    }
                }
                //check or uncheck parents at all levels
                CheckUncheckParents(src, src.checked);
            }
        }
        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }

        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;
            if (parentNodeTable) {
                var checkUncheckSwitch;
                //checkbox checked
                if (check) {
                    var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                    if (isAllSiblingsChecked)
                        checkUncheckSwitch = true;
                    else
                        return; //do not need to check parent if any(one or more) child not checked
                }
                else //checkbox unchecked
                {
                    checkUncheckSwitch = false;
                }
                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }

        function AreAllSiblingsChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) {
                    //check if the child node is an element node
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (!prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //utility function to get the container of an element by tagname
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }

        function getNextSibling(element) {
            var n = element;
            do n = n.nextSibling;
            while (n && n.nodeType != 1);
            return n;
        }
        //returns NodeValue
        function GetNodeValue(node) {
            var nodeValue = "";
            var nodePath = node.href.substring(node.href.indexOf(",") + 2, node.href.length - 2);
            var nodeValues = nodePath.split("\\");
            if (nodeValues.length > 1)
                nodeValue = nodeValues[nodeValues.length - 1];
            else
                nodeValue = nodeValues[0].substr(1);
            return nodeValue;
        }
    </script>

    <style type="text/css">
        .SelectedNodeStyle {
            font-weight: bold;
            color: #6799D1;
            display: block;
            padding: 2px 0 2px 3px;
        }

        .button {
            text-decoration: none;
            /*color: #3AC0F2;*/
            color: green;
            font-size: 10pt;
        }

        .disabled {
            /*color: #737373;*/
            color: red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="overflow: auto;">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left" valign="top" style="width: 100px;">
                                        <asp:Label ID="lblProcedureList" runat="server" Text="Procedures : "></asp:Label>
                                    </td>
                                    <td align="left" valign="top" style="width: 580px;">
                                        <asp:DropDownList ID="ddlProcedureList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProcedureList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" valign="top" style="width:100px;">
                                        <div class="lotusBtnContainer">
                                            <span class="lotusBtn lotusBtnAction lotusLeft" role="button">
                                                <asp:LinkButton ID="lnkbtnAddNode" runat="server" OnClick="lnkbtnAddNode_Click">Add Node</asp:LinkButton>
                                            </span>
                                        </div>
                                    </td>
                                     <td align="left" valign="top">
                                        <div class="lotusBtnContainer">
                                            <span class="lotusBtn lotusBtnAction lotusLeft" role="button">
                                                <asp:LinkButton ID="lnkbtnDeleteNode" runat="server" Visible="false" OnClick="lnkbtnDeleteNode_Click">Delete Node</asp:LinkButton>
                                            </span>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0" style="border-width: 0;" width="100%">
                                            <tr>
                                                <td>
                                                    <%--  <asp:UpdatePanel ID="UPDLHS" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>--%>
                                                    <asp:TreeView ID="tvProcNotes" runat="server" RootNodeStyle-Width="200px" LeafNodeStyle-Width="200px" ShowCheckBoxes="All" OnClick="OnTreeClick(event)"
                                                        SelectedNodeStyle-CssClass="SelectedNodeStyle"
                                                        ShowExpandCollapse="true"
                                                        NodeIndent="20"
                                                        ExpandDepth="10"
                                                        NodeStyle-HorizontalPadding="2"
                                                        ShowLines="true"
                                                        ExpandImageUrl="~/Images/MyPlus.png"
                                                        CollapseImageUrl="~/Images/MyMinus.png"
                                                        OnTreeNodeCollapsed="tvProcNotes_TreeNodeCollapsed"
                                                        OnTreeNodeExpanded="tvProcNotes_TreeNodeExpanded"
                                                        OnSelectedNodeChanged="tvProcNotes_SelectedNodeChanged">
                                                        <RootNodeStyle ImageUrl="~/Images/ClosedBookColorInBlue.png"></RootNodeStyle>
                                                        <LeafNodeStyle ImageUrl="~/Images/ClosedBookColorInBrown.png"></LeafNodeStyle>
                                                    </asp:TreeView>


                                                    <%--  </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0" style="border-width: 0;">
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="rbtnlstNotesType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Text" Value="Text" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Table" Value="Table"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%--  <asp:UpdatePanel ID="UPDRHS" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>--%>
                                                    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" AutoPostBack="false"></CKEditor:CKEditorControl>
                                                    <%-- </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tvProcNotes" EventName="SelectedNodeChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="rbtnlstActiveInActive" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Active" Value="Active" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <div class="lotusBtnContainer">
                                                        <span class="lotusBtn lotusBtnAction lotusLeft" role="button">
                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkbtnAddLine" runat="server" OnClick="lnkbtnAddLine_Click">Add Line</asp:LinkButton>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkbtnUpdateNotes" runat="server" Visible="false" OnClick="lnkbtnUpdateNotes_Click">Update Notes</asp:LinkButton>&nbsp;
                                                                    </td>
                                                                    <td>&nbsp;&nbsp;&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkbtnCancel" runat="server" Visible="false" OnClick="lnkbtnCancel_Click">Cancel</asp:LinkButton>&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:GridView ID="gvProcNotesLines" runat="server" AutoGenerateColumns="False" CssClass="lotusTable lotusChunk" GridLines="None" AutoGenerateSelectButton="False" Width="60%" OnRowCommand="gvProcNotesLines_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Line Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProcNotes_Line_ID" runat="server" Text='<%#Eval("ProcNotes_Line_ID") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblProcNotes_ID" runat="server" Text='<%#Eval("ProcNotes_ID") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblLineNumber" runat="server" Text='<%#Eval("LineNumber") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Notes Type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNotes_Type" runat="server" Text='<%#Eval("Notes_Type") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Notes">
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Notes_Type").ToString() == "Table" ? "<img alt='' src='Images/Table-icon.png' />" : Eval("Notes").ToString().Substring(0,Math.Min(25,Eval("Notes").ToString().Length))+" ....."%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Image runat="server" ID="img" ImageUrl='<%# (Eval("IsActive").ToString().ToLower() == "true" ? "~/Images/Active.png" : "~/Images/InActive.png" ) %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td align="right" valign="middle" style="border-style: none">
                                                                                <asp:LinkButton ID="lnkProcNotes_Line_ID" runat="server" CommandName="UpdateProcNotesLine" CommandArgument='<%#Eval("ProcNotes_Line_ID") %>'
                                                                                    CausesValidation="false" ToolTip="Update Procedure Notes Line" OnClientClient="return false;"><img src="Images/Edit.png" alt="Edit"  border="0"/></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 0px;">
                                                                                <asp:LinkButton ID="lnkUp" CommandArgument="up" runat="server" OnClick="ChangePreference"><img src="Images/Button-Up-icon.png" alt="Edit"  border="0"/></asp:LinkButton>
                                                                            </td>
                                                                            <td style="height: 0px;">
                                                                                <asp:LinkButton ID="lnkDown" CommandArgument="down" runat="server" OnClick="ChangePreference"><img src="Images/Button-Down-icon.png" alt="Edit"  border="0"/></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <asp:Label ID="lblnorecord" runat="server" Font-Bold="True" ForeColor="Red" Text="No Record Found"></asp:Label>
                                                        </EmptyDataTemplate>
                                                        <HeaderStyle ForeColor="#2C70D5" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hfProcNotes_ID" runat="server" />
                            <asp:HiddenField ID="hfParentID" runat="server" />
                            <asp:HiddenField ID="hfSequenceNumber" runat="server" />
                            <asp:HiddenField ID="hfSerialNumber" runat="server" />
                            <asp:HiddenField ID="hfProcNotes_Line_ID" runat="server" />
                            <asp:Label ID="lblProcNotes_Line_ID" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblProcNotes_ID" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblLineNumber" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblParentID" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
