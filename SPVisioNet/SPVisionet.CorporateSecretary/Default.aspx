<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataGrid ID="dgWewenangDireksi" runat="server" AutoGenerateColumns="false" CssClass="table"
            ShowFooter="true" Width="100%" OnItemCommand="dgWewenangDireksi_ItemCommand">
            <HeaderStyle CssClass="header" />
            <ItemStyle CssClass="odd" />
            <AlternatingItemStyle CssClass="white" />
            <Columns>
                <%--<asp:TemplateColumn HeaderText="CityID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCityID" runat="server" Text='<%# Eval("City") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblCityEdit" runat="server" Text='<%# Eval("City") %>' />
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
                <asp:TemplateColumn HeaderText="Nama">
                    <ItemTemplate>
                        <asp:Label ID="lblNama" runat="server" Text='<%# Eval("Nama") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNamaAdd" runat="server" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNamaEdit" runat="server" Text='<%# Eval("Nama") %>' />
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgWewenangDireksi" CommandName="add">Add</asp:LinkButton>
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgWewenangDireksi" CommandName="save">Save</asp:LinkButton>
                        <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
        
    </div>
    </form>
</body>
</html>
