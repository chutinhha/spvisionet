<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveRejectEdit.aspx.cs"
    Inherits="InfinysWorkflowPrj.WFBasicApproval.Layouts.WFBasicApproval.ApproveRejectEdit"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td valign="top">
                <table cellspacing="0" cellpadding="4" border="0" width="100%">
                    <tr>
                        <td class="ms-vb">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table border="0" width="100%" >
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" width="100%" class="ms-formtable">
                                <tr>
                                    <td class="ms-formlabel" valign="top" nowrap width="25%">
                                        <b>Title:</b>
                                    </td>
                                    <td class="ms-formbody" valign="top" width="75%">
                                        <asp:Literal ID="ltlTitle" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ms-formlabel" valign="top" nowrap width="25%">
                                        <b>Related list item:</b>
                                    </td>
                                    <td class="ms-formbody" valign="top" width="75%">
                                        <asp:HyperLink ID="linkRelatedItem" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="ms-formlabel">
                                        <h3 class="ms-standardheader">
                                            <nobr>Comment<span class="ms-formvalidation" title="This is a required field." > *</span></nobr>
                                        </h3>
                                    </td>
                                    <td width="75%" class="ms-formbody">
                                        <asp:TextBox ID="tbxRemarksTxt" runat="server" Columns="50" Rows="5" TextMode="MultiLine" />
                                        <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                        <br />
                                        <asp:RequiredFieldValidator ID="ReqRemarks" runat="server" ControlToValidate="tbxRemarksTxt"
                                            ErrorMessage="Must be filled" Display="Dynamic" ValidationGroup="Reject"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="4" border="0" width="100%">
                    <tr>
                        <td nowrap class="ms-vb" align="center">
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />&nbsp;<asp:Button
                                ID="btnReject" runat="server" Text="Reject"  OnClick="btnReject_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
