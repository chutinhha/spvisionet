<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="ChangePasswordADSIFeature.Layouts.ChangePasswordADSIFeature.ChangePassword"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/Themable/forms.css" />
    <br />
    <center>
        <table class="ms-formtable" cellspacing="0" cellpadding="2" width="99%">
            <tbody>
            <tr><td><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td></tr>
                <tr>
                    <td width="20%" class="ms-formlabel">
                        <h3 class="ms-standardheader">
                            <nobr>User</nobr>
                        </h3>
                    </td>
                    <td align="left" class="ms-formbody" valign="top">
                        <asp:Label ID="lblUserName" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ms-formlabel">
                        <h3 class="ms-standardheader">
                            <nobr>Old Password<span class="ms-formvalidation" title="This is a required field." > *</span></nobr>
                        </h3>
                    </td>
                    <td align="left" class="ms-formbody" valign="top">
                        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                            ErrorMessage="This is a required field."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="ms-formlabel">
                        <h3 class="ms-standardheader">
                            <nobr>New Password<span class="ms-formvalidation" title="This is a required field." > *</span></nobr>
                        </h3>
                    </td>
                    <td align="left" class="ms-formbody" valign="top">
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                            ErrorMessage="This is a required field."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="ms-formlabel">
                        <h3 class="ms-standardheader">
                            <nobr>Confirm Password<span class="ms-formvalidation" title="This is a required field." > *</span></nobr>
                        </h3>
                    </td>
                    <td align="left" class="ms-formbody" valign="top">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="This is a required field."></asp:RequiredFieldValidator><asp:CompareValidator
                                ID="CompareValidator1" runat="server" ErrorMessage="Confirm Password not match with New Password"
                                ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword" Operator="Equal"
                                Type="String"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="ms-formlabel">
                    </td>
                    <td align="left" class="ms-formlabel" valign="top">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left" valign="top">
                        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />&nbsp;<input
                            id="btnReset" type="reset" value="Reset" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </center>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Change Password
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    Change Password
</asp:Content>
