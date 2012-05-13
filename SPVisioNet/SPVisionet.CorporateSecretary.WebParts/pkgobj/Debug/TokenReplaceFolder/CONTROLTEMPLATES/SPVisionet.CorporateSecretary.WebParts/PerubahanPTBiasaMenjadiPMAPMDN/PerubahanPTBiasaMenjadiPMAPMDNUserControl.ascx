<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PerubahanPTBiasaMenjadiPMAPMDNUserControl.ascx.cs" Inherits="SPVisionet.CorporateSecretary.WebParts.PerubahanPTBiasaMenjadiPMAPMDN.PerubahanPTBiasaMenjadiPMAPMDNUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Perubahan PT Biasa Menjadi PMA / PMDN</b></h3>
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
                Alasan Perubahan
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtAlasanPerubahan" runat="server" />
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
                    Kode Perusahaan
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKodePerusahaan" runat="server" />
                </td>
            </tr>
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
        <legend>Struktur Permodalan</legend>
        <table border="0">
            <tr>
                <td>
                    Mata Uang (SGD/IDR/USD)
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlMataUang" runat="server">
                        <asp:ListItem Text="--Select--" Value="" />
                        <asp:ListItem Text="SGD" Value="SGD" />
                        <asp:ListItem Text="IDR" Value="IDR" />
                        <asp:ListItem Text="USD" Value="USD" />
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td align="center">
                    <b>Saham</b>
                </td>
                <td align="center">
                    <b>Nominal</b>
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
                <td>
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
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Nominal (Mata Uang / 1 Saham)
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNominal" runat="server" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
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
    </table>
    <br />
    <fieldset>
        <legend><b>Laporan Perubahan PMA / PMDN</b></legend>
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
