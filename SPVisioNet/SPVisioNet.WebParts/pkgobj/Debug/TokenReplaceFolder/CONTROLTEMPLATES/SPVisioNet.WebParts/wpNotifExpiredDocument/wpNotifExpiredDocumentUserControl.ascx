<%@ Assembly Name="SPVisioNet.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=dc0df5bbccecf641" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpNotifExpiredDocumentUserControl.ascx.cs"
    Inherits="SPVisioNet.WebParts.wpNotifExpiredDocument.wpNotifExpiredDocumentUserControl" %>
<asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
<table width="100%">
    <tr>
        <td align="right">
            <asp:Label ID="Label2" runat="server" Font-Bold="true"></asp:Label>&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" Width="100%" BorderWidth="0px" AutoGenerateColumns="False"
                CellPadding="2" CaptionAlign="Top" DataKeyNames="Id" AllowPaging="True"  
                AllowSorting="true" OnPageIndexChanging="GridView1_PageIndexChanging"
                PageSize="50" onsorting="GridView1_Sorting">
                <EmptyDataTemplate>
                    There is no document such a criteria</EmptyDataTemplate>
                <AlternatingRowStyle CssClass="ms-AlternatingRowStyle" />
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" SortExpression="Id" Visible="false">
                        <HeaderStyle HorizontalAlign="Left" CssClass="HeaderGridView" />
                        <ItemStyle VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Request Code" SortExpression="Title">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Url") %>' Text='<%# Eval("Title")%>'
                                ToolTip='<%# Eval("Title") %>' Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" CssClass="HeaderGridView" />
                        <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="List Name" DataField="ListName" SortExpression="ListName">
                        <HeaderStyle HorizontalAlign="Left" CssClass="HeaderGridView" />
                        <ItemStyle VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status">
                        <HeaderStyle HorizontalAlign="Left" CssClass="HeaderGridView" />
                        <ItemStyle VerticalAlign="Top" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
