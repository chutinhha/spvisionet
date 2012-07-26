<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Redirect.aspx.cs" Inherits="SPVisionet.CorporateSecretary.WebControls.Redirect" %>

<%@ Register Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"
    Namespace="Microsoft.SharePoint.WebControls" TagPrefix="sharepoint" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Redirect</title>
    <base target="_self" />
    <style type="text/css">
        body
        {
            font-size: 12px;
            font-family: "trebuchet ms" ,helvetica,sans-serif;
            margin: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
        <legend>Redirect Task</legend>
        <table border="0" width="100%">
            <tr>
                <td>
                    <b>Title:</b>
                </td>
                <td>
                    <asp:Literal ID="ltlTitle" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Redirect to:</b>
                </td>
                <td>
                    <sharepoint:PeopleEditor ID="pe" runat="server" IsValid="true" AllowEmpty="false"
                        Height="20px" Width="200px" AllowTypeIn="true" MultiSelect="false" />
                    <br />
                    <asp:Label ID="lblErrorMsg" runat="server" Text="Must be filled" Style="color: Red"
                        Visible="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="4" border="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnRedirect" runat="server" Text="Redirect" OnClick="btnRedirect_Click" />&nbsp;<asp:Button
                        ID="btnCancel" ValidationGroup="Cancel" runat="server" Text="Close" OnClientClick="javascript:window.close();" />
                </td>
            </tr>
        </table>
    </fieldset>
    </form>
</body>
</html>
