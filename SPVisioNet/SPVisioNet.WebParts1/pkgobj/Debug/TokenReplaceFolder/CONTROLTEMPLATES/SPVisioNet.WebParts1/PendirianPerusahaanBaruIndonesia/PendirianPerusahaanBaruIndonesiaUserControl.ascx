<%@ Assembly Name="SPVisioNet.WebParts1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9cd0a1a2a4e17477" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendirianPerusahaanBaruIndonesiaUserControl.ascx.cs" Inherits="SPVisioNet.WebParts1.PendirianPerusahaanBaruIndonesia.PendirianPerusahaanBaruIndonesiaUserControl" %>
<asp:UpdatePanel ID="upMain" runat="server">
    <ContentTemplate>
        <fieldset>
            <legend>
                <h3>
                    <b>Permohonan Pendirian Perusahaan (Indonesia)</b></h3>
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
                        <asp:Literal ID="ltrTanggal" runat="server" />
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
                        <asp:Literal ID="ltrRequestCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Tujuan Penggunaan PT
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtTujuanPenggunaan" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Nama Pemohon
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtNamaPemohon" runat="server" />
                        <asp:ImageButton ID="imgbtnNamaPemohon" ValidationGroup="popup" runat="server" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                            ToolTip="Search" OnClientClick="openDialog('Cari Nama Pemohon', 'divMainSearch')"
                            CausesValidation="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Email Pemohon
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailPemohon" runat="server" />
                        <img src="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif" alt="Search" />
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend><b>Data Perusahaan</b></legend>
                <table border="0">
                    <tr>
                        <td>
                            Nama Perusahaan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtNamaPerusahaan" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tempat Kedudukan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTempatKedudukan" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Maksud dan Tujuan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMaksudTujuan" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status Ownership
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatusOwnership" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>Struktur Permodalan</b></legend>
                <table>
                    <tr>
                        <td>
                            Mata Uang
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMataUang" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Modal Dasar
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtModalDasar" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Modal Setor
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtModalSetor" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nominal Saham
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtNominalSaham" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>Pemegang Saham</b></legend>
                <asp:DataGrid ID="dgPemegangSaham" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%">
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
                        <asp:TemplateColumn HeaderText="Nama Pemegang Saham">
                            <ItemTemplate>
                                <asp:Label ID="lblNamaPemegangSaham" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNamaPemegangSahamAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNamaPemegangSahamEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Nominal">
                            <ItemTemplate>
                                <asp:Label ID="lblNominal" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNominalAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNominalEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Percentages">
                            <ItemTemplate>
                                <asp:Label ID="lblPercentages" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPercentagesAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPercentagesEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Partner">
                            <ItemTemplate>
                                <asp:Label ID="lblPartner" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPartnerAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPartnerEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgPemegangSaham" CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgPemegangSaham" CommandName="save">Save</asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <fieldset>
                <legend><b>Komisaris dan Direksi</b></legend>
                <asp:DataGrid ID="dgKomisaris" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%">
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
                                <asp:Label ID="lblNama" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNamaAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNamaEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Jabatan">
                            <ItemTemplate>
                                <asp:Label ID="lblJabatan" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtJabatanAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtJabatanEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgKomisaris" CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgKomisaris" CommandName="save">Save</asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <table border="0">
                <tr>
                    <td>
                        Wewenang Direksi
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlWewenangDireksi" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Keterangan
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeterangan" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Diajukan Oleh
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Disetujui Oleh
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mengetahui
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend><b>Laporan Perkembangan Pendirian</b></legend>
                <fieldset>
                    <legend><b>SKDP [ dilaporkan oleh Corporate Secretary]</b></legend>
                    <table border="0">
                        <tr>
                            <td valign="top" width="250px">
                                <asp:FileUpload ID="fuSKDP" runat="server" />
                            </td>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td width="150px">
                                            No
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoSKDP" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal Berlaku
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalBerlakuSKDP" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal Akhir Berlaku
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalAkhirBerlaku" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Keterangan
                                        </td>
                                        <td valign="top">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeteranganSKDP" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend><b>NPWP [ dilaporkan oleh Tax]</b></legend>
                    <table border="0">
                        <tr>
                            <td valign="top" width="250px">
                                <asp:FileUpload ID="fuNPWP" runat="server" />
                            </td>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td width="150px">
                                            No SKT
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNOSKTNPWP" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal SKT
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalSKTNPWP" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            No NPWP
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoNPWP" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal Terdaftar
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalTerdaftarNPWP" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Nama KPP
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNamaKPP" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Keterangan
                                        </td>
                                        <td valign="top">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeteranganNPWP" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend><b>PKP [ dilaporkan oleh Tax]</b></legend>
                    <table border="0">
                        <tr>
                            <td valign="top" width="250px">
                                <asp:FileUpload ID="fuPKP" runat="server" />
                            </td>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td width="150px">
                                            No SKT
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoSKTPKP" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal SKT
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalSKTPKP" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            No PKP
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoPKP" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal Terdaftar
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalTerdaftarPKP" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Nama PKP
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNamaPKP" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Keterangan
                                        </td>
                                        <td valign="top">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeteranganPKP" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend><b>APV [ dilaporkan oleh Accounting]</b></legend>
                    <table border="0">
                        <tr>
                            <td valign="top" width="250px">
                                <asp:FileUpload ID="fuAPV" runat="server" />
                            </td>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td width="150px">
                                            No APV
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoAPV" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal APV
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalAPV" DateOnly="true" runat="server"></SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Keterangan
                                        </td>
                                        <td valign="top">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeteranganAPV" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend><b>Setoran Modal [ dilaporkan oleh Finance]</b></legend>
                    <table border="0">
                        <tr>
                            <td valign="top" width="250px">
                                <asp:FileUpload ID="fuSetoranModal" runat="server" />
                            </td>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td width="150px">
                                            Tanggal Setoran
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalSetoran" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Keterangan
                                        </td>
                                        <td valign="top">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeteranganSetoran" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend><b>SK Pengesahan Pendirian [ dilaporkan oleh Corporate Secretary]</b></legend>
                    <table border="0">
                        <tr>
                            <td valign="top" width="250px">
                                <asp:FileUpload ID="fuSKPengesahan" runat="server" />
                            </td>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td width="150px">
                                            No
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoSK" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal Berlaku
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalBerlakuSK" DateOnly="true" runat="server">
                                            </SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Keterangan
                                        </td>
                                        <td valign="top">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeteranganSK" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend><b>BNRI [ dilaporkan oleh PIC Corporate Secretary]</b></legend>
                    <table border="0">
                        <tr>
                            <td valign="top" width="250px">
                                <asp:FileUpload ID="fuBNRI" runat="server" />
                            </td>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td width="150px">
                                            No
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNoBNRI" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tanggal
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <SharePoint:DateTimeControl ID="dtTanggalBNRI" DateOnly="true" runat="server"></SharePoint:DateTimeControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            Keterangan
                                        </td>
                                        <td valign="top">
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeteranganBNRI" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </fieldset>
        </fieldset>
        <fieldset>
            <legend>
                <h3>
                    <b>Data Perusahaan</b></h3>
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
                        <asp:Literal ID="ltrTanggalDP" runat="server" />
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
                        <asp:Literal ID="ltrRequestCodeDP" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <table border="0">
                <tr>
                    <td>
                        Nama Perusahaan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtNamaPerusahaanDP" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Notaris
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtNotaris" runat="server" />
                        <img src="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif" alt="Search" />
                    </td>
                </tr>
                <tr>
                    <td>
                        No Akta
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoAkta" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Tanggal Akta
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <SharePoint:DateTimeControl ID="dtTanggalAkta" DateOnly="true" runat="server"></SharePoint:DateTimeControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tempat Kedudukan (provinsi & kota)
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTempatKedudukanDP" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Alamat
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAlamatDP" runat="server" Width="400px" TextMode="MultiLine" Rows="4" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Maksud & Tujuan
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:Literal ID="ltrMaksudTujuanDP" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        NPWP
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:Literal ID="ltrNPWPDP" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        PKP
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:Literal ID="ltrPKPDP" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Status Ownership
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:Literal ID="ltrStatusOwnershipDP" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Status Perseroan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatusPerseroanDP" runat="server" />
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend><b>Struktur Permodalan</b></legend>
                <table border="0">
                    <tr>
                        <td>
                            Mata Uang
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMataUangDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Modal Dasar (nominal)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrModalDasarDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Modal Dasar (jumlah saham)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrModalDasarJumlahSahamDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Modal Setor (nominal)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrModalSetorDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Modal Setor (jumlah saham)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrModalSetorJumlahSahamDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nominal Saham (Rp/Saham)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrNominalSahamDP" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>Pemegang Saham</b></legend>
                <asp:DataGrid ID="dgPemegangSahamDP" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Nama Pemegang Saham">
                            <ItemTemplate>
                                <asp:Label ID="lblNamaPemegangSaham" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Nominal">
                            <ItemTemplate>
                                <asp:Label ID="lblNominal" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Percentages">
                            <ItemTemplate>
                                <asp:Label ID="lblPercentages" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Partner">
                            <ItemTemplate>
                                <asp:Label ID="lblPartner" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <fieldset>
                <legend><b>Komisaris dan Direksi</b></legend>
                <asp:DataGrid ID="dgKomisarisDP" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Nama">
                            <ItemTemplate>
                                <asp:Label ID="lblNama" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Jabatan">
                            <ItemTemplate>
                                <asp:Label ID="lblJabatan" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Tanggal Mulai Menjabat">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Tanggal Akhir Menjabat">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <table border="0">
                <tr>
                    <td>
                        Wewenang Direksi
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlWewenangDireksiDP" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Keterangan
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeteranganDP" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="divMainDlgContainer">
    <div id="divMainSearch" style="display: none">
        <asp:UpdatePanel ID="upMainSearch" runat="server">
            <ContentTemplate>
                <table width="100%" border="0">
                    <tr>
                        <td>
                            Search :
                            <asp:TextBox ID="txtSearch" runat="server" />
                            &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="closeDialog('divMainSearch')" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
