<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermohonanPerdaftaranPMAPMDNUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PermohonanPerdaftaranPMAPMDN.PermohonanPerdaftaranPMAPMDNUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permohonan Pendaftaran PMA / PMDN</b></h3>
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
                Tujuan Penggunaan
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtTujuanPenggunaan" runat="server" />
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
            </td>
        </tr>
    </table>
    <br />
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
                    <asp:TextBox ID="txtTempatKedudukan" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Bidang Usaha
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtBidangUsaha" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Klasifikasi Lapangan Usaha
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKlasifikasi" runat="server" />
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
                    <asp:DropDownList ID="ddlStatusPerseroan" runat="server">
                        <asp:ListItem Text="--Select--" Value="" />
                        <asp:ListItem Text="PMA" Value="PMA" />
                        <asp:ListItem Text="PMDN" Value="PMDN" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>Struktur Permodalan</b></legend>
        <table border="0">
            <tr>
                <td width="100px">
                    Mata Uang <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlMataUang" runat="server" />
                    <asp:RequiredFieldValidator ID="reqddlMataUang" Display="Dynamic" ValidationGroup="Save"
                        runat="server" ControlToValidate="ddlMataUang" ErrorMessage="Required Field" />
                </td>
            </tr>
        </table>
        <table border="0">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td align="center">
                    Saham
                </td>
                <td align="center">
                    Nominal
                </td>
            </tr>
            <tr>
                <td>
                    Modal Dasar <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtModalDasar" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtModalDasar" Display="Dynamic" ValidationGroup="Save"
                        runat="server" ControlToValidate="txtModalDasar" ErrorMessage="Required Field" />
                </td>
                <td>
                    <asp:TextBox ID="txtNominalModalDasar" Enabled="false" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Modal Setor <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtModalSetor" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtModalSetor" Display="Dynamic" ValidationGroup="Save"
                        runat="server" ControlToValidate="txtModalSetor" ErrorMessage="Required Field" />
                </td>
                <td>
                    <asp:TextBox ID="txtNominalModalSetor" Enabled="false" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Nominal Saham <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNominalSaham" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtNominalSaham" Display="Dynamic" ValidationGroup="Save"
                        runat="server" ControlToValidate="txtNominalSaham" ErrorMessage="Required Field" />
                </td>
                <td>
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
                <asp:TemplateColumn HeaderText="Jumlah Saham">
                    <ItemTemplate>
                        <asp:Label ID="lblJumlahSaham" runat="server" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtJumlahSahamAdd" runat="server" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtJumlahSahamEdit" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Jumlah Nominal">
                    <ItemTemplate>
                        <asp:Label ID="lblJumlahNominal" runat="server" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtJumlahNominalAdd" runat="server" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtJumlahNominalEdit" runat="server" />
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
                        <asp:CheckBox ID="chkPartnerAdd" runat="server" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkPartnerEdit" runat="server" />
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
        <table border="0">
            <tr>
                <td>
                    Nilai Investasi
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNilaiInvestasi" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Cara Pembiayaan
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlCaraPembiayaan" runat="server">
                        <asp:ListItem Text="--Select--" Value="" />
                        <asp:ListItem Text="Modal Sendiri" Value="Modal Sendiri" />
                        <asp:ListItem Text="Modal Pinjaman" Value="Modal Pinjaman" />
                        <asp:ListItem Text="Laba ditanam kembali" Value="Laba ditanam kembali" />
                    </asp:DropDownList>
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
                    <asp:TextBox ID="txtKeterangan" runat="server" TextMode="MultiLine" Width="450" Rows="6" />
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
                    PIC Corsec
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
                    DIV Head
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
                    Chief Corporate Secretary
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>Laporan Pendaftaran PMA / PMDN</b></legend>
        <table border="0">
            <tr>
                <td valign="top" width="250px">
                    Surat Persetujuan PMA / PMDN Baru
                    <br />
                    <br />
                    <asp:FileUpload ID="fu" runat="server" />
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
                                <asp:TextBox ID="txtNo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tanggal Mulai Berlaku
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <%--  <sharepoint:datetimecontrol id="dtTanggalMulaiBerlaku" dateonly="true" runat="server"></sharepoint:datetimecontrol>--%>
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
                                <%--  <sharepoint:datetimecontrol id="dtTanggalAkhirBerlaku" dateonly="true" runat="server"></sharepoint:datetimecontrol>--%>
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
                                <asp:TextBox ID="txtKeteranganPMAPMDN" runat="server" Width="350px" Rows="4" TextMode="MultiLine" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    Dilaporkan Oleh:
                    <br />
                    <br />
                    <br />
                    Corporate Secretary
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <div style="text-align: right">
            <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </div>
    </fieldset>
</fieldset>
