<%@ Page Title="" Language="C#" MasterPageFile="~/Master_ACHEQA.Master" AutoEventWireup="true"
    CodeBehind="ProcedureSelection.aspx.cs" Inherits="ACHEQA_Parametric_Automation.ProcedureSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblerr" runat="server"></asp:Label>
    <asp:Button ID="btnSaveProc" runat="server" Text="Save" 
        onclick="btnSaveProc_Click" />
    <asp:CheckBoxList ID="chkProcs" runat="server">
    </asp:CheckBoxList>
</asp:Content>
