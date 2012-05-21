<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermintaanDokumenUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PermintaanDokumen.PermintaanDokumenUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permintaan Dokumen</b></h3>
    </legend>
    <br />
    <div style="text-align: right">
        <span style="color: Red">*</span> indicates a required field</div>
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
                Nama Peminjam <span style="color: Red">*</span>
            </td>
            <td>
                :
            </td>
            <td>
                <SharePoint:PeopleEditor Width="250px" ValidatorEnabled="true" AutoPostBack="true"
                    ID="peNamaPeminjam" MultiSelect="false" SelectionSet="User" runat="server" />
                <%-- <asp:RequiredFieldValidator ID="reqpeNamaPeminjam" runat="server" ControlToValidate="peNamaPeminjam"
                    Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="Save" />--%>
                <asp:Literal ID="ltrNamaPeminjam" runat="server" />
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
    <asp:UpdatePanel ID="upDokumen" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:DataGrid ID="dgDokumen" runat="server" AutoGenerateColumns="false" CssClass="table"
                ShowFooter="true" Width="100%" OnItemCommand="dgDokumen_ItemCommand" OnItemDataBound="dgDokumen_ItemDataBound">
                <HeaderStyle CssClass="header" />
                <ItemStyle CssClass="odd" />
                <AlternatingItemStyle CssClass="white" />
                <Columns>
                    <asp:TemplateColumn HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblIDEdit" runat="server" Text='<%# Eval("ID") %>' />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Nama Dokumen" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top"
                        FooterStyle-Width="175" ItemStyle-Width="175">
                        <ItemTemplate>
                            <asp:Label ID="lblNamaDokumen" runat="server" Text='<%# Eval("NamaDokumen") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNamaDokumenAdd" runat="server" Width="99%" />
                            <asp:RequiredFieldValidator ID="reqtxtNamaDokumenAdd" runat="server" ControlToValidate="txtNamaDokumenAdd"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNamaDokumenEdit" runat="server" Width="99%" Text='<%# Eval("NamaDokumen") %>' />
                            <asp:RequiredFieldValidator ID="reqtxtNamaDokumenEdit" runat="server" ControlToValidate="txtNamaDokumenEdit"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Tipe Dokumen" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top"
                        FooterStyle-Width="120" ItemStyle-Width="120">
                        <ItemTemplate>
                            <asp:Label ID="lblTipeDokumen" runat="server" Text='<%# Eval("TipeDokumen") %>' />
                            <asp:Label ID="lblIDTipeDokumen" runat="server" Text='<%# Eval("IDTipeDokumen") %>' Visible="false" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlTipeDokumenAdd" runat="server" Width="120" />
                            <asp:RequiredFieldValidator ID="reqddlTipeDokumenAdd" runat="server" ControlToValidate="ddlTipeDokumenAdd"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlTipeDokumenEdit" runat="server" Width="120" />
                            <asp:RequiredFieldValidator ID="reqddlTipeDokumenEdit" runat="server" ControlToValidate="ddlTipeDokumenEdit"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Softcopy/Original" ItemStyle-VerticalAlign="Top"
                        FooterStyle-VerticalAlign="Top" FooterStyle-Width="90" ItemStyle-Width="90">
                        <ItemTemplate>
                            <asp:Label ID="lblSoftcopyOriginal" runat="server" Text='<%# Eval("SoftcopyOriginal") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlSoftcopyOriginalAdd" runat="server">
                                <asp:ListItem Text="--Select--" Value="" />
                                <asp:ListItem Text="Softcopy" Value="Softcopy" />
                                <asp:ListItem Text="Original" Value="Original" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqddlSoftcopyOriginalAdd" runat="server" ControlToValidate="ddlSoftcopyOriginalAdd"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlSoftcopyOriginalEdit" runat="server">
                                <asp:ListItem Text="--Select--" Value="" />
                                <asp:ListItem Text="Softcopy" Value="Softcopy" />
                                <asp:ListItem Text="Original" Value="Original" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqddlSoftcopyOriginalEdit" runat="server" ControlToValidate="ddlSoftcopyOriginalEdit"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Tujuan Peminjaman">
                        <ItemTemplate>
                            <asp:Label ID="lblTujuanPeminjaman" runat="server" Text='<%# Eval("TujuanPeminjaman") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTujuanPeminjamanAdd" runat="server" TextMode="MultiLine" Rows="3"
                                Width="99%" />
                            <asp:RequiredFieldValidator ID="reqtxtTujuanPeminjamanAdd" runat="server" ControlToValidate="txtTujuanPeminjamanAdd"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTujuanPeminjamanEdit" runat="server" Text='<%# Eval("TujuanPeminjaman") %>'
                                TextMode="MultiLine" Rows="3" Width="99%" />
                            <asp:RequiredFieldValidator ID="reqtxtTujuanPeminjamanEdit" runat="server" ControlToValidate="txtTujuanPeminjamanEdit"
                                Display="Dynamic" ErrorMessage="Required Field" ValidationGroup="dgDokumen" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Tanggal dibutuhkan" ItemStyle-VerticalAlign="Top"
                        FooterStyle-VerticalAlign="Top" FooterStyle-Width="115" ItemStyle-Width="115">
                        <ItemTemplate>
                            <asp:Label ID="lblTanggaldibutuhkan" runat="server" Text='<%# Eval("TanggalDibutuhkan", "{0:dd-MMM-yyyy}") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <div id="spdtinput">
                                <SharePoint:DateTimeControl ID="dtTanggaldibutuhkanAdd" DateOnly="true" runat="server">
                                </SharePoint:DateTimeControl>
                                <asp:RequiredFieldValidator ID="reqdtTanggaldibutuhkanAdd" ValidationGroup="dgDokumen"
                                    runat="server" ControlToValidate="dtTanggaldibutuhkanAdd$dtTanggaldibutuhkanAddDate"
                                    ErrorMessage="Required Field" Display="Dynamic" />
                            </div>
                        </FooterTemplate>
                        <EditItemTemplate>
                            <div id="spdtinput">
                                <SharePoint:DateTimeControl ID="dtTanggaldibutuhkanEdit" DateOnly="true" runat="server">
                                </SharePoint:DateTimeControl>
                                <asp:RequiredFieldValidator ID="reqdtTanggaldibutuhkanEdit" ValidationGroup="dgDokumen"
                                    runat="server" ControlToValidate="dtTanggaldibutuhkanEdit$dtTanggaldibutuhkanEditDate"
                                    ErrorMessage="Required Field" Display="Dynamic" />
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Tanggal Estimasi Pengembalian" ItemStyle-VerticalAlign="Top"
                        FooterStyle-VerticalAlign="Top" FooterStyle-Width="110" ItemStyle-Width="110">
                        <ItemTemplate>
                            <asp:Label ID="lblTanggalEstimasi" runat="server" Text='<%# Eval("TanggalEstimasiPengembalian", "{0:dd-MMM-yyyy}") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <div id="spdtinput">
                                <SharePoint:DateTimeControl ID="dtTanggalEstimasiAdd" DateOnly="true" runat="server">
                                </SharePoint:DateTimeControl>
                                <asp:RequiredFieldValidator ID="reqdtTanggalEstimasiAdd" ValidationGroup="dgDokumen"
                                    runat="server" ControlToValidate="dtTanggalEstimasiAdd$dtTanggalEstimasiAddDate"
                                    ErrorMessage="Required Field" Display="Dynamic" />
                            </div>
                        </FooterTemplate>
                        <EditItemTemplate>
                            <div id="spdtinput">
                                <SharePoint:DateTimeControl ID="dtTanggalEstimasiEdit" DateOnly="true" runat="server">
                                </SharePoint:DateTimeControl>
                                <asp:RequiredFieldValidator ID="reqdtTanggalEstimasiEdit" ValidationGroup="dgDokumen"
                                    runat="server" ControlToValidate="dtTanggalEstimasiEdit$dtTanggalEstimasiEditDate"
                                    ErrorMessage="Required Field" Display="Dynamic" />
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                        ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top" FooterStyle-Width="80"
                        ItemStyle-Width="80">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgDokumen" CommandName="add">Add</asp:LinkButton>
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgDokumen" CommandName="save">Save</asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <fieldset>
        <table>
            <tr>
                <td valign="top">
                    Keterangan
                </td>
                <td valign="top">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKeterangan" runat="server" TextMode="MultiLine" Width="450" Rows="6" />
                    <asp:Literal ID="ltrKeterangan" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Diajukan oleh
                </td>
                <td>
                    :
                </td>
                <td>
                    Requestor (<asp:Literal ID="ltrRequestor" runat="server" />)
                </td>
            </tr>
            <tr>
                <td>
                    Disetujui oleh
                </td>
                <td>
                    :
                </td>
                <td>
                    Authorized Person
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <div style="text-align: right">
            <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" ValidationGroup="Save"
                OnClick="btnSaveUpdate_Click" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </fieldset>
</fieldset>
