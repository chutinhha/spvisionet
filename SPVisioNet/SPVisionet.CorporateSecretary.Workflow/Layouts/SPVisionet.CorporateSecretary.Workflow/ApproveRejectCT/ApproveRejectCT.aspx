<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Page Language="C#" DynamicMasterPageFile="~masterurl/default.master" AutoEventWireup="true"
    Inherits="SPVisionet.CorporateSecretary.Workflow.Layouts.SPVisionet.CorporateSecretary.Workflow.ApproveRejectCT.ApproveRejectCT"
    CodeBehind="ApproveRejectCT.aspx.cs" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <fieldset>
        <legend>Task</legend>
        <br />
        <table border="0" width="100%">
            <tr>
                <td width="120px">
                    Title
                </td>
                <td width="5px">
                    :
                </td>
                <td>
                    <asp:Literal ID="ltlTitle" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Approval Status
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlApprovalStatus" runat="server">
                        <asp:ListItem Selected="True" Text="--Select--" Value="" />
                        <asp:ListItem Text="Approve" Value="Approve" />
                        <asp:ListItem Text="Reject" Value="Reject" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Related list item
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:HyperLink ID="linkRelatedItem" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <table border="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSave" runat="server" Text="Complete Task" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
