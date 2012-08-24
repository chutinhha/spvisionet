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
    <br />
    <div style="text-align: right">
        <span style="color: Red">*</span> indicates a required field</div>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
                    <td valign="top">
                        Tujuan Penggunaan <span style="color: Red">*</span>
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtTujuanPenggunaan" runat="server" Width="400px" TextMode="MultiLine"
                            Rows="3" />
                        <asp:RequiredFieldValidator ID="reqtxtTujuanPenggunaan" ValidationGroup="Save" Display="Dynamic"
                            runat="server" ControlToValidate="txtTujuanPenggunaan" ErrorMessage="Required Field" />
                        <asp:Literal ID="ltrTujuanPenggunaan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Nama Pemohon <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:HiddenField ID="hfIDPemohon" runat="server" />
                        <asp:TextBox ID="txtNamaPemohon" runat="server" Width="250px" Enabled="false" />
                        <asp:Literal ID="ltrNamaPemohon" runat="server" />
                        <asp:ImageButton ID="imgbtnNamaPemohon" ValidationGroup="popup" runat="server" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                            ToolTip="Search" OnClientClick="openDialog(event, 'Cari Nama Pemohon', 'divPemohonSearch')"
                            CausesValidation="false" OnClick="imgbtnNamaPemohon_Click" />
                        <asp:RequiredFieldValidator ID="reqtxtNamaPemohon" ValidationGroup="Save" Display="Dynamic"
                            runat="server" ControlToValidate="txtNamaPemohon" ErrorMessage="Required Field" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Email Pemohon <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailPemohon" runat="server" Width="250px" Enabled="false" />
                        <asp:RequiredFieldValidator ID="reqtxtEmailPemohon" ValidationGroup="Save" Display="Dynamic"
                            runat="server" ControlToValidate="txtEmailPemohon" ErrorMessage="Required Field" />
                        <asp:Literal ID="ltrEmailPemohon" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <fieldset>
        <legend><b>Data Perusahaan</b></legend>
        <asp:UpdatePanel ID="upDataPerusahaan" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td>
                            Nama Perusahaan <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtNamaPerusahaan" runat="server" Width="250px" />
                            <asp:RequiredFieldValidator ID="reqtxtNamaPerusahaan" ValidationGroup="Save" Display="Dynamic"
                                runat="server" ControlToValidate="txtNamaPerusahaan" ErrorMessage="Required Field" />
                            <asp:Literal ID="ltrNamaPerusahaaan" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tempat Kedudukan <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTempatKedudukan" runat="server" />
                            <asp:RequiredFieldValidator ID="reqddlTempatKedudukan" ValidationGroup="Save" Display="Dynamic"
                                runat="server" ControlToValidate="ddlTempatKedudukan" ErrorMessage="Required Field" />
                            <asp:Literal ID="ltrTempatKedudukan" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bidang Usaha <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtBidangUsaha" runat="server" Width="350px" />
                            <asp:RequiredFieldValidator ID="reqtxtBidangUsaha" ValidationGroup="Save" Display="Dynamic"
                                runat="server" ControlToValidate="txtBidangUsaha" ErrorMessage="Required Field" />
                            <asp:Literal ID="ltrBidangUsaha" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Klasifikasi Lapangan Usaha <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtKlasifikasi" runat="server" Width="350px" />
                            <asp:RequiredFieldValidator ID="reqtxtKlasifikasi" ValidationGroup="Save" Display="Dynamic"
                                runat="server" ControlToValidate="txtKlasifikasi" ErrorMessage="Required Field" />
                            <asp:Literal ID="ltrKlasifikasi" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status Perseroan <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatusPerseroan" runat="server" />
                            <asp:RequiredFieldValidator ID="reqddlStatusPerseroan" ValidationGroup="Save" Display="Dynamic"
                                runat="server" ControlToValidate="ddlStatusPerseroan" ErrorMessage="Required Field" />
                            <asp:Literal ID="ltrStatusPerseroan" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <fieldset>
        <legend><b>Struktur Permodalan</b></legend>
        <asp:UpdatePanel ID="upStrukturPermodalan" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td width="100px">
                            Mata Uang <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMataUang" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMataUang_SelectedIndexChanged" />
                            <asp:Literal ID="ltrMataUang" runat="server" />
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
                            <asp:TextBox ID="txtModalDasar" runat="server" CssClass="textRight" />
                            <asp:Literal ID="ltrModalDasar" runat="server" />
                            <asp:RequiredFieldValidator ID="reqtxtModalDasar" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="txtModalDasar" ErrorMessage="Required Field" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtNominalModalDasar" Enabled="false" runat="server" CssClass="textRight" />
                            <asp:Literal ID="ltrNominalModalDasar" runat="server" />
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
                            <asp:TextBox ID="txtModalSetor" runat="server" CssClass="textRight" />
                            <asp:Literal ID="ltrModalSetor" runat="server" />
                            <asp:RequiredFieldValidator ID="reqtxtModalSetor" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="txtModalSetor" ErrorMessage="Required Field" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtNominalModalSetor" Enabled="false" runat="server" CssClass="textRight" />
                            <asp:Literal ID="ltrNominalModalSetor" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nominal Saham (<asp:Literal ID="ltrMataUangSelected" runat="server" Text="Mata Uang" />
                            / 1 Saham) <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtNominalSaham" runat="server" CssClass="textRight" />
                            <asp:Literal ID="ltrNominalSaham" runat="server" />
                            <asp:RequiredFieldValidator ID="reqtxtNominalSaham" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="txtNominalSaham" ErrorMessage="Required Field" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <fieldset>
        <legend><b>Pemegang Saham</b></legend>
        <br />
        <asp:UpdatePanel ID="upPemegangSaham" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataGrid ID="dgPemegangSaham" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%" OnItemCommand="dgPemegangSaham_ItemCommand" OnItemDataBound="dgPemegangSaham_ItemDataBound">
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
                        <asp:TemplateColumn HeaderText="Nama Pemegang Saham">
                            <ItemTemplate>
                                <asp:Label ID="lblNamaPemegangSaham" runat="server" Text='<%# Eval("Nama") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNamaPemegangSahamAdd" Width="200px" runat="server" />
                                <asp:RequiredFieldValidator ID="reqtxtNamaPemegangSahamAdd" runat="server" ControlToValidate="txtNamaPemegangSahamAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgPemegangSaham" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNamaPemegangSahamEdit" Width="200px" runat="server" Text='<%# Eval("Nama") %>' />
                                <asp:RequiredFieldValidator ID="reqtxtNamaPemegangSahamEdit" runat="server" ControlToValidate="txtNamaPemegangSahamEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgPemegangSaham" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Jumlah Saham" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblJumlahSaham" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JumlahSaham", "{0:#,##0}") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtJumlahSahamAdd" runat="server" CssClass="textRight" />
                                <asp:RequiredFieldValidator ID="reqtxtJumlahSahamAdd" runat="server" ControlToValidate="txtJumlahSahamAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgPemegangSaham" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtJumlahSahamEdit" runat="server" CssClass="textRight" Text='<%# DataBinder.Eval(Container.DataItem, "JumlahSaham", "{0:#,##0}") %>' />
                                <asp:RequiredFieldValidator ID="reqtxtJumlahSahamEdit" runat="server" ControlToValidate="txtJumlahSahamEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgPemegangSaham" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Jumlah Nominal" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblJumlahNominal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JumlahNominal", "{0:#,##0}") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtJumlahNominalAdd" CssClass="textRight" runat="server" Enabled="false" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtJumlahNominalEdit" CssClass="textRight" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JumlahNominal", "{0:#,##0}") %>'
                                    Enabled="false" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Percentages" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="lblPercentages" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Percentages", "{0:#,##0.00}") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPercentagesAdd" runat="server" CssClass="textRight" Enabled="false" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPercentagesEdit" runat="server" CssClass="textRight" Text='<%# DataBinder.Eval(Container.DataItem, "Percentages", "{0:#,##0.00}") %>'
                                    Enabled="false" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Partner" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPartner" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="cboPartnerAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="cboPartnerEdit" runat="server" Checked='<%# Eval("Partner") %>' />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <fieldset>
        <table border="0">
            <tr>
                <td>
                    Nilai Investasi <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNilaiInvestasi" runat="server" CssClass="textRight" />
                    <asp:RequiredFieldValidator ID="reqtxtNilaiInvestasi" ValidationGroup="Save" Display="Dynamic"
                        runat="server" ControlToValidate="txtNilaiInvestasi" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrNilaiInvestasi" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <b>Pembiayaan</b>
                    <table>
                        <tr>
                            <td>
                                Modal Sendiri <span style="color: Red">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtModalSendiri" runat="server" CssClass="textRight" Enabled="false" />
                                <asp:RequiredFieldValidator ID="reqtxtModalSendiri" ValidationGroup="Save" Display="Dynamic"
                                    runat="server" ControlToValidate="txtModalSendiri" ErrorMessage="Required Field" />
                                <asp:Literal ID="ltrModalSendiri" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Modal Laba ditanam kembali <span style="color: Red">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtModalDitanamKembali" runat="server" CssClass="textRight" />
                                <asp:RequiredFieldValidator ID="reqtxtModalDitanamKembali" ValidationGroup="Save"
                                    Display="Dynamic" runat="server" ControlToValidate="txtModalDitanamKembali" ErrorMessage="Required Field" />
                                <asp:Literal ID="ltrModalDitanamKembali" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Modal Pinjaman <span style="color: Red">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtModalPinjaman" runat="server" CssClass="textRight" Enabled="false" />
                                <asp:RequiredFieldValidator ID="reqtxtModalPinjaman" ValidationGroup="Save" Display="Dynamic"
                                    runat="server" ControlToValidate="txtModalPinjaman" ErrorMessage="Required Field" />
                                <asp:Literal ID="ltrModalPinjaman" runat="server" />
                            </td>
                        </tr>
                    </table>
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
                    <asp:Literal ID="ltrKeterangan" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:Panel ID="pnlAssign" runat="server" Visible="false">
        <fieldset>
            <table border="0">
                <tr>
                    <td>
                        Diajukan oleh
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        PIC Corsec (<asp:Literal ID="ltrPICCorsec" runat="server" />)
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
                        Div Head (<asp:Literal ID="ltrDivHead" runat="server" />)
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
                        Chief Corporate Secretary (<asp:Literal ID="ltrChiefCS" runat="server" />)
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <asp:Panel ID="pnlOriginator" runat="server" Visible="false">
        <fieldset>
            <legend><b>Laporan Pendaftaran PMA / PMDN</b></legend>
            <table border="0">
                <tr>
                    <td valign="top" width="250px">
                        Surat Persetujuan PMA / PMDN Baru <span style="color: Red">*</span>
                        <br />
                        <br />
                        <asp:Literal ID="ltrfu" runat="server" />
                        <br />
                        <br />
                        <asp:FileUpload ID="fu" runat="server" />
                        <asp:RequiredFieldValidator ID="reqfu" Display="Dynamic" ValidationGroup="Save" runat="server"
                            ControlToValidate="fu" ErrorMessage="Required Field" />
                    </td>
                    <td>
                        <table border="0">
                            <tr>
                                <td width="150px">
                                    No <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNo" runat="server" />
                                    <asp:RequiredFieldValidator ID="reqtxtNo" ValidationGroup="Save" Display="Dynamic"
                                        runat="server" ControlToValidate="txtNo" ErrorMessage="Required Field" />
                                    <asp:Literal ID="ltrNo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tanggal Mulai Berlaku <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalMulaiBerlaku" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                                <asp:Literal ID="ltrTanggalMulaiBerlaku" runat="server" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiBerlaku" ValidationGroup="Save"
                                                    runat="server" ControlToValidate="dtTanggalMulaiBerlaku$dtTanggalMulaiBerlakuDate"
                                                    ErrorMessage="Required Field" Display="Dynamic" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tanggal Akhir Berlaku <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalAkhirBerlaku" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                                <asp:Literal ID="ltrTanggalAkhirBerlaku" runat="server" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalAkhirBerlaku" ValidationGroup="Save"
                                                    runat="server" ControlToValidate="dtTanggalAkhirBerlaku$dtTanggalAkhirBerlakuDate"
                                                    ErrorMessage="Required Field" Display="Dynamic" />
                                            </td>
                                        </tr>
                                    </table>
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
                                    <asp:Literal ID="ltrKeteranganPMAPMDN" runat="server" />
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
    </asp:Panel>
    <fieldset>
        <div style="text-align: right">
            <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" ValidationGroup="Save"
                OnClick="btnSaveUpdate_Click" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </fieldset>
</fieldset>
<div id="divPemohonDlgContainer">
    <div id="divPemohonSearch" style="display: none">
        <asp:UpdatePanel ID="upPemohon" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlPemohon" runat="server">
                    <table width="100%" border="0">
                        <tr>
                            <td>
                                <table cellpadding="0" border="0">
                                    <tr>
                                        <td>
                                            Search :
                                            <asp:TextBox ID="txtSearchPemohon" runat="server" Width="200px" />
                                            &nbsp;<asp:Button ID="btnSearchPemohon" runat="server" Text="Search" OnClick="btnSearchPemohon_Click" />
                                            &nbsp;<asp:Button ID="btnAddPemohon" runat="server" Text="Add New" OnClick="btnAddPemohon_Click" />
                                        </td>
                                        <td>
                                            <asp:UpdateProgress ID="upProgPemohon" AssociatedUpdatePanelID="upPemohon" runat="server"
                                                DynamicLayout="true">
                                                <ProgressTemplate>
                                                    <img border="0" src="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/loading.gif"
                                                        title="Loading" alt="Loading" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grvPemohon" runat="server" AutoGenerateColumns="false" CssClass="table"
                                    Width="100%" EmptyDataText="No Data Available" DataSourceID="odsPemohon" AllowPaging="true"
                                    PageSize="10" OnRowCommand="grvPemohon_RowCommand" OnRowDataBound="grvPemohon_RowDataBound">
                                    <HeaderStyle CssClass="header" />
                                    <RowStyle CssClass="odd" />
                                    <AlternatingRowStyle CssClass="even" />
                                    <PagerStyle CssClass="pager" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrrb" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Title" HeaderText="Nama Pemohon" />
                                        <asp:BoundField DataField="EmailPemohon" HeaderText="Email Pemohon" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="ubah"
                                                    CommandArgument='<%# Eval("ID") %>'>Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsPemohon" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
                                    SelectMethod="GetItemDataTable" SelectCountMethod="ListItemCount" StartRowIndexParameterName="pageIndex"
                                    TypeName="SPVisionet.CorporateSecretary.Common.Util">
                                    <SelectParameters>
                                        <asp:Parameter Name="ListURL" Type="String" DefaultValue="" ConvertEmptyStringToNull="false" />
                                        <asp:Parameter Name="pageSize" Type="Int32" />
                                        <asp:Parameter Name="pageIndex" Type="Int32" />
                                        <asp:Parameter Name="strSortFieldName" Type="String" DefaultValue="Title" ConvertEmptyStringToNull="false" />
                                        <asp:Parameter Name="strDataType" Type="String" DefaultValue="String" ConvertEmptyStringToNull="false" />
                                        <asp:Parameter Name="blAscendingTrueFalse" Type="Boolean" DefaultValue="false" />
                                        <asp:Parameter Name="strViewFields" Type="String" DefaultValue="" ConvertEmptyStringToNull="false" />
                                        <asp:Parameter Name="strQuery" Type="String" DefaultValue="" ConvertEmptyStringToNull="false" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr align="right">
                            <td>
                                <asp:Button ID="btnSelectPemohon" runat="server" Text="Select" OnClick="btnSelectPemohon_Click" />
                                <asp:Button ID="btnCloseSearchPemohon" runat="server" Text="Close" OnClientClick="closeDialog('divPemohonSearch')" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPemohonAddEdit" runat="server" Visible="false">
                    <table width="100%" border="0">
                        <tr>
                            <td width="100px">
                                Nama Pemohon
                            </td>
                            <td width="5px">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtNamaPemohonAddEdit" runat="server" Width="220px" />
                                <asp:RequiredFieldValidator ID="reqtxtNamaPemohonAddEdit" Display="Dynamic" ValidationGroup="SavePemohon"
                                    runat="server" ControlToValidate="txtNamaPemohonAddEdit" ErrorMessage="Required Field" />
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
                                <asp:TextBox ID="txtEmailPemohonAddEdit" runat="server" Width="220px" />
                                <asp:RequiredFieldValidator ID="reqtxtEmailPemohonAddEdit" Display="Dynamic" ValidationGroup="SavePemohon"
                                    runat="server" ControlToValidate="txtEmailPemohonAddEdit" ErrorMessage="Required Field" />
                                <asp:RegularExpressionValidator ID="regtxtEmailPemohonAddEdit" runat="server" ErrorMessage="Invalid Email"
                                    ControlToValidate="txtEmailPemohonAddEdit" Display="Dynamic" ValidationGroup="SavePemohon"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSavePemohon" runat="server" Text="Save" ValidationGroup="SavePemohon"
                                                OnClick="btnSavePemohon_Click" />&nbsp;
                                            <asp:Button ID="btnCancelPemohon" runat="server" Text="Cancel" OnClick="btnCancelPemohon_Click" />
                                        </td>
                                        <td>
                                            <asp:UpdateProgress ID="upProgPemohonAddEdit" AssociatedUpdatePanelID="upPemohon"
                                                runat="server" DynamicLayout="true">
                                                <ProgressTemplate>
                                                    <img border="0" src="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/loading.gif"
                                                        title="Loading" alt="Loading" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
