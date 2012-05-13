<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermintaanDokumenUserControl.ascx.cs" Inherits="SPVisionet.CorporateSecretary.WebParts.PermintaanDokumen.PermintaanDokumenUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permintaan Dokumen</b></h3>
    </legend>
    <table border="0">
        <tr>
            <td>
                Tanggal
            </td>
            <td>
                :
            </td>
            <td>
                <asp:Literal ID="ltrDate" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Request Code
            </td>
            <td>
                :
            </td>
            <td>
                <asp:Literal ID="ltrRequestCode" Text="Auto Generate" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Nama Peminjam
            </td>
            <td>
                :
            </td>
            <td>
                <asp:DropDownList ID="ddlNamaPeminjam" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Divisi Peminjam
            </td>
            <td>
                :
            </td>
            <td>
                <asp:Literal ID="ltrDivisiPeminjam" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <asp:DataGrid ID="dgDokumen" runat="server" AutoGenerateColumns="false" CssClass="table"
        ShowFooter="true" Width="100%">
        <HeaderStyle CssClass="header" />
        <ItemStyle CssClass="odd" />
        <AlternatingItemStyle CssClass="white" />
        <Columns>
            <asp:TemplateColumn HeaderText="Nama Dokumen">
                <ItemTemplate>
                    <asp:Label ID="lblNamaDokumen" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNamaDokumen" runat="server" />
                </FooterTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNamaDokumen" runat="server" />
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Tipe Dokumen">
                <ItemTemplate>
                    <asp:Label ID="lblTipeDokumen" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlTipeDokumenAdd" runat="server" />
                </FooterTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlTipeDokumenEdit" runat="server" />
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Softcopy/Original">
                <ItemTemplate>
                    <asp:Label ID="lblSoftcopyOriginal" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlSoftcopyOriginalAdd" runat="server">
                        <asp:ListItem Text="--Select--" Value="" />
                        <asp:ListItem Text="Softcopy" Value="Softcopy" />
                        <asp:ListItem Text="Original" Value="Original" />
                    </asp:DropDownList>
                </FooterTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSoftcopyOriginalEdit" runat="server">
                        <asp:ListItem Text="--Select--" Value="" />
                        <asp:ListItem Text="Softcopy" Value="Softcopy" />
                        <asp:ListItem Text="Original" Value="Original" />
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Tujuan Peminjaman">
                <ItemTemplate>
                    <asp:Label ID="lblTujuanPeminjaman" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTujuanPeminjamanAdd" runat="server" />
                </FooterTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTujuanPeminjamanEdit" runat="server" />
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Tanggal dibutuhkan">
                <ItemTemplate>
                    <asp:Label ID="lblTanggaldibutuhkan" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <%--<sharepoint:datetimecontrol id="dtTanggaldibutuhkanAdd" dateonly="true" runat="server">
                        </sharepoint:datetimecontrol>--%>
                </FooterTemplate>
                <EditItemTemplate>
                    <%-- <sharepoint:datetimecontrol id="dtTanggaldibutuhkanEdit" dateonly="true" runat="server">
                        </sharepoint:datetimecontrol>--%>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Tanggal Estimasi Pengembalian">
                <ItemTemplate>
                    <asp:Label ID="lblTanggalEstimasi" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <%--  <sharepoint:datetimecontrol id="dtTanggalEstimasiAdd" dateonly="true" runat="server">
                        </sharepoint:datetimecontrol>--%>
                </FooterTemplate>
                <EditItemTemplate>
                    <%-- <sharepoint:datetimecontrol id="dtTanggalEstimasiEdit" dateonly="true" runat="server">
                        </sharepoint:datetimecontrol>--%>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgShareholder" CommandName="add">Add</asp:LinkButton>
                </FooterTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgShareholder" CommandName="save">Save</asp:LinkButton>
                    <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    <br />
    <table>
        <tr>
            <td valign="top">
                Keterangan :
            </td>
            <td>
                <asp:TextBox ID="txtKeterangan" runat="server" TextMode="MultiLine" Width="450" Rows="6" />
            </td>
        </tr>
    </table>
    <fieldset>
        <div style="text-align: right">
            <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </div>
    </fieldset>
</fieldset>
