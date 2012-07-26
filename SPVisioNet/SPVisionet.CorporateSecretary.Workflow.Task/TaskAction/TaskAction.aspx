
<%@ Page Language="C#" MasterPageFile="~/_layouts/application.master" EnableSessionState="true"
    ValidateRequest="False" AutoEventWireup="true" CodeBehind="TaskAction.aspx.cs"
    Inherits="SPVisionet.CorporateSecretary.Workflow.Task.TaskAction.TaskAction" %>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="PlaceHolderMain">
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
                <table border="0" width="100%">
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="ms-formlabel" valign="top" nowrap width="25%">
                                        <b>Title:</b>
                                    </td>
                                    <td class="ms-formbody" valign="top" width="75%">
                                        <asp:Literal ID="ltlTitle" runat="server" />
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="ms-formlabel" valign="top" nowrap width="25%">
                                        <b>Approval Status:</b>
                                    </td>
                                    <td class="ms-formbody" valign="top" width="75%">
                                        <asp:RadioButtonList ID="rbApprovalStatus" runat="server" style="font-size:11px">
                                            <asp:ListItem Text="Approve" Value="Approve" />
                                            <asp:ListItem Text="Reject" Value="Reject" />
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td width="25%" class="ms-formlabel">
                                        <b>Remarks:</b>
                                    </td>
                                    <td width="75%" class="ms-formbody">
                                        <asp:TextBox ID="tbxRemarksTxt" runat="server" Columns="50" Rows="5" TextMode="MultiLine" />
                                        <br /><asp:RequiredFieldValidator ID="ReqRemarks" runat="server" ControlToValidate="tbxRemarksTxt"
                                            ErrorMessage="Must be filled" Display="Dynamic" ValidationGroup="Reject"></asp:RequiredFieldValidator>
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
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="4" border="0" width="100%">
                    <tr>
                        <td nowrap class="ms-vb">
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" 
                                onclick="btnApprove_Click" />
                        </td>
                        <td nowrap class="ms-vb"> 
                            <asp:Button ID="btnReject" runat="server" Text="Reject" 
                                ValidationGroup="Reject" onclick="btnReject_Click" />
                        </td>
                        <td nowrap class="ms-vb" width="99%">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
