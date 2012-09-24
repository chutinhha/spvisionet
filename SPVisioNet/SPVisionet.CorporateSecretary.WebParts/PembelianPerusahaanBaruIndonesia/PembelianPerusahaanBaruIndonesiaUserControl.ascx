<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PembelianPerusahaanBaruIndonesiaUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PembelianPerusahaanBaruIndonesia.PembelianPerusahaanBaruIndonesiaUserControl" %>
<%@ Register Src="~/_controltemplates/Lippo/Pemohon.ascx" TagName="Pemohon" TagPrefix="uc" %>
<%@ Register Src="~/_controltemplates/Lippo/SKDPLog.ascx" TagName="SKDPLog" TagPrefix="uc" %>
<%@ Register Src="~/_controltemplates/Lippo/PemegangSahamKomisarisMasterData.ascx"
    TagName="PemegangSahamKomisaris" TagPrefix="uc" %>
<%@ Register Src="~/_controltemplates/Lippo/PemegangSahamKomisarisInfo.ascx" TagName="PemegangSahamKomisarisInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/_controltemplates/Lippo/PerusahaanPMAPMDN.ascx" TagName="Perusahaan"
    TagPrefix="uc" %>
<fieldset>
    <legend>
        <h3>
            <b>Pembelian Perusahaan Baru (Indonesia)</b></h3>
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
                        <asp:Literal ID="ltrRequestCode" runat="server" Text="Auto Generate" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Tujuan Penggunaan PT <span style="color: Red">*</span>
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtTujuanPenggunaan" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
                        <asp:Literal ID="ltrTujuanPenggunaan" runat="server" />
                        <asp:RequiredFieldValidator ID="reqtxtTujuanPenggunaan" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="txtTujuanPenggunaan" ErrorMessage="Required Field" />
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
                        <asp:TextBox ID="txtNamaPemohon" runat="server" Enabled="false" Width="250px" />
                        <asp:Literal ID="ltrNamaPemohon" runat="server" />
                        <asp:ImageButton ID="imgbtnNamaPemohon" ValidationGroup="popup" runat="server" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                            ToolTip="Search" OnClientClick="openDialog(event, 'Cari Nama Pemohon', 'divPemohonSearch')"
                            CausesValidation="false" OnClick="imgbtnNamaPemohon_Click" />
                        <asp:RequiredFieldValidator ID="reqtxtNamaPemohon" Display="Dynamic" ValidationGroup="Save"
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
                        <asp:TextBox ID="txtEmailPemohon" runat="server" Enabled="false" Width="250px" />
                        <asp:Literal ID="ltrEmailPemohon" runat="server" />
                        <asp:RequiredFieldValidator ID="reqtxtEmailPemohon" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="txtEmailPemohon" ErrorMessage="Required Field" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upDataPerusahaan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend><b>Data Perusahaan</b></legend>
                <table border="0">
                    <tr>
                        <td>
                            Status Perseroan <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatusPerseroan" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusPerseroan_SelectedIndexChanged" />
                            <asp:Literal ID="ltrStatusPerseroan" runat="server" />
                            <asp:RequiredFieldValidator ID="reqddlStatusPerseroan" ValidationGroup="Save" runat="server"
                                ControlToValidate="ddlStatusPerseroan" ErrorMessage="Required Field" Display="Dynamic" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nama Perusahaan <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtNamaPerusahaan" runat="server" Width="350px" />
                            <asp:Literal ID="ltrNamaPerusahaan" runat="server" />
                            <asp:ImageButton ID="imgbtnNamaPerusahaan" ValidationGroup="popup" runat="server"
                                ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                                ToolTip="Search" OnClientClick="openDialog(event, 'Cari Nama Perusahaan', 'divPerusahaanSearch')"
                                CausesValidation="false" />
                            <asp:RequiredFieldValidator ID="reqtxtNamaPerusahaan" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="txtNamaPerusahaan" ErrorMessage="Required Field" />
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
                            <asp:Literal ID="ltrTempatKedudukan" runat="server" />
                            <asp:RequiredFieldValidator ID="reqddlTempatKedudukan" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="ddlTempatKedudukan" ErrorMessage="Required Field" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Maksud dan Tujuan <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMaksudTujuan" runat="server" />
                            <asp:Literal ID="ltrMaksudTujuan" runat="server" />
                            <asp:RequiredFieldValidator ID="reqddlMaksudTujuan" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="ddlMaksudTujuan" ErrorMessage="Required Field" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status Ownership <span style="color: Red">*</span>
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatusOwnership" runat="server" />
                            <asp:Literal ID="ltrStatusOwnership" runat="server" />
                            <asp:RequiredFieldValidator ID="reqddlStatusOwnership" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="ddlStatusOwnership" ErrorMessage="Required Field" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                            <asp:Label ID="ltrModalDasar" runat="server" />
                            <asp:RequiredFieldValidator ID="reqtxtModalDasar" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="txtModalDasar" ErrorMessage="Required Field" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtNominalModalDasar" Enabled="false" runat="server" CssClass="textRight" />
                            <asp:Label ID="ltrNominalModalDasar" runat="server" />
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
                            <asp:Label ID="ltrModalSetor" runat="server" />
                            <asp:RequiredFieldValidator ID="reqtxtModalSetor" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="txtModalSetor" ErrorMessage="Required Field" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtNominalModalSetor" Enabled="false" runat="server" CssClass="textRight" />
                            <asp:Label ID="ltrNominalModalSetor" runat="server" />
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
                            <asp:Label ID="ltrNominalSaham" runat="server" />
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
                                <asp:LinkButton ID="lbNamaPemegangSaham" runat="server" CommandName="pemegangsaham"
                                    Text='<%# Eval("Nama") %>' CausesValidation="false" ValidationGroup="popup" OnClientClick="openDialog(event, 'Pemegang Saham Info', 'divPemegangSahamInfoSearch')" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="lbNamaPemegangSahamAdd" runat="server" CommandName="pemegangsaham"
                                    CausesValidation="false" ValidationGroup="popup" OnClientClick="openDialog(event, 'Pemegang Saham Info', 'divPemegangSahamInfoSearch')" />
                                <asp:ImageButton ID="imgbtnNamaPemegangSahamAdd" ValidationGroup="popup" runat="server"
                                    CausesValidation="False" CommandName="popup" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                                    ToolTip="Search" OnClientClick="openDialog(event, 'Cari Pemegang Saham', 'divPemegangSahamSearch')"
                                    OnClick="imgbtnPemegangSaham_Click" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lbNamaPemegangSahamEdit" runat="server" CommandName="pemegangsaham"
                                    Text='<%# Eval("Nama") %>' CausesValidation="false" ValidationGroup="popup" OnClientClick="openDialog(event, 'Pemegang Saham Info', 'divPemegangSahamInfoSearch')" />
                                <asp:ImageButton ID="imgbtnNamaPemegangSahamEdit" ValidationGroup="popup" runat="server"
                                    CausesValidation="False" CommandName="popup" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                                    ToolTip="Search" OnClientClick="openDialog(event, 'Cari Pemegang Saham', 'divPemegangSahamSearch')"
                                    OnClick="imgbtnPemegangSaham_Click" />
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
                        <asp:TemplateColumn HeaderText="IDPemegangSaham" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIDPemegangSaham" runat="server" Text='<%# Eval("IDPemegangSaham") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblIDPemegangSahamEdit" runat="server" Text='<%# Eval("IDPemegangSaham") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblIDPemegangSahamAdd" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <fieldset>
        <legend><b>Komisaris dan Direksi</b></legend>
        <br />
        <asp:UpdatePanel ID="upKomisarisDireksi" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataGrid ID="dgKomisaris" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%" OnItemCommand="dgKomisaris_ItemCommand" OnItemDataBound="dgKomisaris_ItemDataBound">
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
                        <asp:TemplateColumn HeaderText="Nama">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbNamaKomisaris" runat="server" CommandName="komisaris" Text='<%# Eval("Nama") %>'
                                    CausesValidation="false" ValidationGroup="popup" OnClientClick="openDialog(event, 'Komisaris dan Direksi Info', 'divKomisarisInfoSearch')" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="lbNamaKomisarisAdd" runat="server" CommandName="komisaris" CausesValidation="false"
                                    ValidationGroup="popup" OnClientClick="openDialog(event, 'Komisaris dan Direksi Info', 'divKomisarisInfoSearch')" />
                                <asp:ImageButton ID="imgbtnNamaKomisarisAdd" ValidationGroup="popup" runat="server"
                                    CausesValidation="False" CommandName="popup" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                                    ToolTip="Search" OnClientClick="openDialog(event, 'Cari Komisaris dan Direksi', 'divKomisarisSearch')"
                                    OnClick="imgbtnKomisaris_Click" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lbNamaKomisarisEdit" runat="server" CommandName="komisaris" Text='<%# Eval("Nama") %>'
                                    CausesValidation="false" ValidationGroup="popup" OnClientClick="openDialog(event, 'Komisaris dan Direksi Info', 'divKomisarisInfoSearch')" />
                                <asp:ImageButton ID="imgbtnNamaKomisarisAdd" ValidationGroup="popup" runat="server"
                                    CausesValidation="False" CommandName="popup" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                                    ToolTip="Search" OnClientClick="openDialog(event, 'Cari Komisaris dan Direksi', 'divKomisarisSearch')"
                                    OnClick="imgbtnKomisaris_Click" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Jabatan">
                            <ItemTemplate>
                                <asp:Label ID="lblJabatan" runat="server" Text='<%# Eval("Jabatan") %>' />
                                <asp:Label ID="lblJabatanID" runat="server" Text='<%# Eval("IDJabatan") %>' Visible="false" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlJabatanAdd" runat="server" />
                                <asp:RequiredFieldValidator ID="reqddlJabatanAdd" runat="server" ControlToValidate="ddlJabatanAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgKomisaris" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlJabatanEdit" runat="server" />
                                <asp:RequiredFieldValidator ID="reqddlJabatanEdit" runat="server" ControlToValidate="ddlJabatanEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgKomisaris" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Mulai Menjabat" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalMulaiMenjabat" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <div id="spdtinput">
                                    <table>
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalMulaiMenjabatAdd" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiMenjabatAdd" ValidationGroup="dgKomisaris"
                                                    runat="server" ControlToValidate="dtTanggalMulaiMenjabatAdd$dtTanggalMulaiMenjabatAddDate"
                                                    ErrorMessage="*" Display="Dynamic" ToolTip="Required Field" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <div id="spdtinput">
                                    <table>
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalMulaiMenjabatEdit" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiMenjabatEdit" ValidationGroup="dgKomisaris"
                                                    runat="server" ControlToValidate="dtTanggalMulaiMenjabatEdit$dtTanggalMulaiMenjabatEditDate"
                                                    ErrorMessage="*" Display="Dynamic" ToolTip="Required Field" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Akhir Menjabat" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalAkhirMenjabat" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <div id="spdtinput">
                                    <table>
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalAkhirMenjabatAdd" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalAkhirMenjabatAdd" ValidationGroup="dgKomisaris"
                                                    runat="server" ControlToValidate="dtTanggalAkhirMenjabatAdd$dtTanggalAkhirMenjabatAddDate"
                                                    ErrorMessage="*" Display="Dynamic" ToolTip="Required Field" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <div id="spdtinput">
                                    <table>
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalAkhirMenjabatEdit" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalAkhirMenjabatEdit" ValidationGroup="dgKomisaris"
                                                    runat="server" ControlToValidate="dtTanggalAkhirMenjabatEdit$dtTanggalAkhirMenjabatEditDate"
                                                    ErrorMessage="*" Display="Dynamic" ToolTip="Required Field" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
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
                        <asp:TemplateColumn HeaderText="IDKomisaris" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIDKomisaris" runat="server" Text='<%# Eval("IDKomisaris") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblIDKomisarisEdit" runat="server" Text='<%# Eval("IDKomisaris") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblIDKomisarisAdd" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <fieldset>
        <legend><b>Wewenang Direksi</b></legend>
        <br />
        <asp:UpdatePanel ID="upWewenangDireksi" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataGrid ID="dgWewenangDireksi" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" OnItemCommand="dgWewenangDireksi_ItemCommand" OnItemDataBound="dgWewenangDireksi_ItemDataBound">
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
                        <asp:TemplateColumn HeaderText="Wewenang">
                            <ItemTemplate>
                                <asp:Label ID="lblNama" runat="server" Text='<%# Eval("Nama") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNamaAdd" runat="server" Width="250px" />
                                <asp:RequiredFieldValidator ID="reqtxtNamaAdd" runat="server" ControlToValidate="txtNamaAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgWewenangDireksi" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNamaEdit" runat="server" Width="250px" Text='<%# Eval("Nama") %>' />
                                <asp:RequiredFieldValidator ID="reqtxtNamaEdit" runat="server" ControlToValidate="txtNamaEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgWewenangDireksi" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <fieldset>
        <table border="0">
            <tr>
                <td valign="top">
                    Keterangan
                </td>
                <td valign="top">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKeterangan" runat="server" Width="350px" Rows="5" TextMode="MultiLine" />
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
                        Diajukan Oleh
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        PIC Corporate Secretary
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
                        Div Head Corporate Secretary & Chief Corporate Secreatry
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
                        CEO
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <fieldset>
        <legend><b>Laporan Perkembangan Pembelian</b></legend>
        <asp:Panel ID="pnlPICCorsec" runat="server" Visible="false">
            <fieldset>
                <legend><b>Akta [ dilaporkan oleh Corporate Secretary (<asp:Literal ID="ltrUsernameAkte"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuAkte" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuAkte" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuAkte" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuAkte" ErrorMessage="Required Field" />
                            <br />
                            <br />
                            Original/Copy? :
                            <asp:CheckBox ID="chkOriginalAkte" runat="server" Text="Original di-check. Copy di-uncheck" />
                            <asp:Literal ID="ltrOriginalAkte" runat="server" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        No Akta <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoAkte" runat="server" />
                                        <asp:Literal ID="ltrNoAkte" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNoAkte" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNoAkte" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal Akta <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalAkte" DateOnly="true" runat="server"></SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalAkte" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalAkte" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtTanggalAkte$dtTanggalAkteDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Notaris <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNotarisAkte" runat="server" />
                                        <asp:Literal ID="ltrNotarisAkte" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNotarisAkte" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNotarisAkte" ErrorMessage="Required Field" />
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
                                        <asp:TextBox ID="txtKeteranganAkte" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        <asp:Literal ID="ltrKeteranganAkte" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>SKDP [ dilaporkan oleh Corporate Secretary (<asp:Literal ID="ltrUsernameSKDP"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <asp:UpdatePanel ID="upSKDP" runat="server" UpdateMode="Conditional" Visible="false">
                                <ContentTemplate>
                                    <br />
                                    <asp:LinkButton ID="lnbSKDPLog" runat="server" ValidationGroup="SKDPLog" Text="SKDP Log"
                                        OnClientClick="openDialog(event, 'SKDP Log', 'divSKDPLog')" CausesValidation="false"
                                        OnClick="lnbSKDPLog_Click" /></ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuSKDP" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuSKDP" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuSKDP" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuSKDP" ErrorMessage="Required Field" />
                            <br />
                            <br />
                            Original/Copy? :
                            <asp:CheckBox ID="chkOriginalSKDP" runat="server" Text="Original di-check. Copy di-uncheck" />
                            <asp:Literal ID="ltrOriginalSKDP" runat="server" />
                        </td>
                        <td>
                            <table border="0" width="100%">
                                <tr>
                                    <td width="150px">
                                        No <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoSKDP" runat="server" />
                                        <asp:Literal ID="ltrNoSKDP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNoSKDP" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNoSKDP" ErrorMessage="Required Field" />
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
                                                    <SharePoint:DateTimeControl ID="dtTanggalBerlakuSKDP" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalBerlakuSKDP" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalBerlakuSKDP" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtTanggalBerlakuSKDP$dtTanggalBerlakuSKDPDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />
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
                                                    <SharePoint:DateTimeControl ID="dtTanggalAkhirBerlakuSKDP" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalAkhirBerlakuSKDP" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalAkhirBerlakuSKDP" ValidationGroup="Save"
                                                        runat="server" ControlToValidate="dtTanggalAkhirBerlakuSKDP$dtTanggalAkhirBerlakuSKDPDate"
                                                        ErrorMessage="Required Field" Display="Dynamic" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Alamat <span style="color: Red">*</span>
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAlamatSKDP" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        <asp:Literal ID="ltrAlamatSKDP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtAlamatSKDP" ValidationGroup="Save" runat="server"
                                            ControlToValidate="txtAlamatSKDP" ErrorMessage="Required Field" Display="Dynamic" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>Setoran Modal [ dilaporkan oleh Finance (<asp:Literal ID="ltrUsernameSetoran"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuSetoranModal" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuSetoranModal" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuSetoranModal" ValidationGroup="Save" runat="server"
                                ControlToValidate="fuSetoranModal" ErrorMessage="Required Field" Display="Dynamic" />
                            <br />
                            <br />
                            Original/Copy? :
                            <asp:CheckBox ID="chkOriginalSetoranModal" runat="server" Text="Original di-check. Copy di-uncheck" />
                            <asp:Literal ID="ltrOriginalSetoranModal" runat="server" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        Tanggal Setoran
                                        <asp:Label ID="lblTanggalSetoranRequired" runat="server" Style="color: Red">*</asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalSetoran" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalSetoran" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalSetoran" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtTanggalSetoran$dtTanggalSetoranDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />
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
                                        <asp:TextBox ID="txtKeteranganSetoran" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        <asp:Literal ID="ltrKeteranganSetoran" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Modal telah disetor?
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkStatusSetoran" runat="server" Text="Jika YA maka Bukti Setor harus di upload dan Tanggal Setor harus diisi"
                                            OnCheckedChanged="chkStatusSetoran_CheckedChanged" AutoPostBack="true" Checked="true" />
                                        <asp:Literal ID="ltrStatusSetoran" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>SK Pengesahan Pendirian [ dilaporkan oleh Corporate Secretary (<asp:Literal
                    ID="ltrUsernameSKPengesahan" runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <div style="display: none">
                                <br />
                                <br />
                                <asp:Literal ID="ltrfuSKPengesahan" runat="server" Visible="false" />
                                <br />
                                <br />
                                <asp:FileUpload ID="fuSKPengesahan" runat="server" Visible="false" />
                                <br />
                                <asp:RequiredFieldValidator ID="reqfuSKPengesahan" ValidationGroup="Save" runat="server"
                                    ControlToValidate="fuSKPengesahan" ErrorMessage="Required Field" Display="Dynamic"
                                    Visible="false" />
                                <br />
                                <br />
                                Original/Copy? :
                                <asp:CheckBox ID="chkOriginalSKPengesahan" runat="server" Text="Original di-check. Copy di-uncheck" />
                                <asp:Literal ID="ltrOriginalSKPengesahan" runat="server" /></div>
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
                                        <asp:TextBox ID="txtNoSK" runat="server" />
                                        <asp:Literal ID="ltrNoSK" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNoSK" ValidationGroup="Save" runat="server"
                                            ControlToValidate="txtNoSK" ErrorMessage="Required Field" Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal Diterbitkan <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalDiterbitkanSK" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalDiterbitkanSK" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalDiterbitkanSK" ValidationGroup="Save"
                                                        runat="server" ControlToValidate="dtTanggalDiterbitkanSK$dtTanggalDiterbitkanSKDate"
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
                                        <asp:TextBox ID="txtKeteranganSK" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        <asp:Literal ID="ltrKeteranganSK" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>NPWP [ dilaporkan oleh Tax (<asp:Literal ID="ltrUsernameNPWP" runat="server" />)
                    ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuNPWP" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuNPWP" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuNPWP" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuNPWP" ErrorMessage="Required Field" />
                            <br />
                            <br />
                            Original/Copy? :
                            <asp:CheckBox ID="chkOriginalNPWP" runat="server" Text="Original di-check. Copy di-uncheck" />
                            <asp:Literal ID="ltrOriginalNPWP" runat="server" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        No SKT <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNOSKTNPWP" runat="server" />
                                        <asp:Literal ID="ltrNOSKTNPWP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNOSKTNPWP" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNOSKTNPWP" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal SKT <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalSKTNPWP" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalSKTNPWP" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalSKTNPWP" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtTanggalSKTNPWP$dtTanggalSKTNPWPDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        No NPWP <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoNPWP" runat="server" />
                                        <asp:Literal ID="ltrNoNPWP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNoNPWP" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNoNPWP" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal Terdaftar <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalTerdaftarNPWP" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalTerdaftarNPWP" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalTerdaftarNPWP" ValidationGroup="Save"
                                                        runat="server" ControlToValidate="dtTanggalTerdaftarNPWP$dtTanggalTerdaftarNPWPDate"
                                                        ErrorMessage="Required Field" Display="Dynamic" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nama KPP <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNamaKPP" runat="server" />
                                        <asp:Literal ID="ltrNamaKPP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNamaKPP" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNamaKPP" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Alamat <span style="color: Red">*</span>
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAlamatNPWP" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        <asp:Literal ID="ltrAlamatNPWP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtAlamatNPWP" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtAlamatNPWP" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <fieldset>
                    <legend><b>NPWP Lainnya</b></legend>
                    <br />
                    <asp:DataGrid ID="dgNPWPLainnya" runat="server" AutoGenerateColumns="false" CssClass="table"
                        ShowFooter="true" Width="100%" OnItemCommand="dgNPWPLainnya_ItemCommand" OnItemDataBound="dgNPWPLainnya_ItemDataBound">
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
                            <asp:TemplateColumn HeaderText="Attachment" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <asp:Label ID="lblAtttachmentHidden" runat="server" Text='<%# Eval("NamaFile") %>'
                                        Visible="false" />
                                    <asp:Label ID="lblAtttachment" runat="server" Text='<%# Eval("NamaFile") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:FileUpload ID="fuAdd" runat="server" />
                                    <asp:RequiredFieldValidator ID="reqfuAdd" runat="server" ControlToValidate="fuAdd"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgNPWPLainnya" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:FileUpload ID="fuEdit" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="No. NPWP" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <asp:Label ID="lblNPWP" runat="server" Text='<%# Eval("NoNPWP") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNPWPAdd" runat="server" Width="200px" />
                                    <asp:RequiredFieldValidator ID="reqtxtNPWPAdd" runat="server" ControlToValidate="txtNPWPAdd"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgNPWPLainnya" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNPWPEdit" runat="server" Width="200px" Text='<%# Eval("NoNPWP") %>' />
                                    <asp:RequiredFieldValidator ID="reqtxtNPWPEdit" runat="server" ControlToValidate="txtNPWPEdit"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgNPWPLainnya" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Keterangan">
                                <ItemTemplate>
                                    <asp:Label ID="lblKeterangan" runat="server" Text='<%# Eval("Keterangan") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtKeteranganAdd" runat="server" Rows="3" TextMode="MultiLine" Width="350px" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtKeteranganEdit" runat="server" Rows="3" TextMode="MultiLine"
                                        Width="350px" Text='<%# Eval("Keterangan") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgNPWPLainnya" CommandName="add">Add</asp:LinkButton>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgNPWPLainnya" CommandName="save">Save</asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </fieldset>
            </fieldset>
            <fieldset>
                <legend><b>PKP [ dilaporkan oleh Tax (<asp:Literal ID="ltrUsernamePKP" runat="server" />)
                    ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuPKP" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuPKP" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuPKP" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuPKP" ErrorMessage="Required Field" />
                            <br />
                            <br />
                            Original/Copy? :
                            <asp:CheckBox ID="chkOriginalPKP" runat="server" Text="Original di-check. Copy di-uncheck" />
                            <asp:Literal ID="ltrOriginalPKP" runat="server" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        No PKP
                                        <asp:Label ID="lblNoPKPRequired" runat="server" Style="color: Red">*</asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoPKP" runat="server" />
                                        <asp:Literal ID="ltrNoPKP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNoPKP" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNoPKP" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal Terdaftar
                                        <asp:Label ID="lblTanggalTerdaftarRequired" runat="server" Style="color: Red">*</asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalTerdaftarPKP" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalTerdaftarPKP" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalTerdaftarPKP" ValidationGroup="Save"
                                                        runat="server" ControlToValidate="dtTanggalTerdaftarPKP$dtTanggalTerdaftarPKPDate"
                                                        ErrorMessage="Required Field" Display="Dynamic" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nama PKP
                                        <asp:Label ID="lblNamaPKPRequired" runat="server" Style="color: Red">*</asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNamaPKP" runat="server" />
                                        <asp:Literal ID="ltrNamaPKP" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNamaPKP" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNamaPKP" ErrorMessage="Required Field" />
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
                                        <asp:Literal ID="ltrKeteranganPKP" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ada PKP?
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkStatusPKP" runat="server" Checked="true" AutoPostBack="true"
                                            OnCheckedChanged="chkStatusPKP_CheckedChanged" Text="Jika YA maka bukti PKP harus diupload dan No.PKP, Tanggal Terdaftar dan Nama PKP harus diisi" />
                                        <asp:Literal ID="ltrStatusPKP" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <fieldset>
                    <legend><b>PKP Lainnya</b></legend>
                    <br />
                    <asp:DataGrid ID="dgPKPLainnya" runat="server" AutoGenerateColumns="false" CssClass="table"
                        ShowFooter="true" Width="100%" OnItemCommand="dgPKPLainnya_ItemCommand" OnItemDataBound="dgPKPLainnya_ItemDataBound">
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
                            <asp:TemplateColumn HeaderText="Attachment" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <asp:Label ID="lblAtttachmentHidden" runat="server" Text='<%# Eval("NamaFile") %>'
                                        Visible="false" />
                                    <asp:Label ID="lblAtttachment" runat="server" Text='<%# Eval("NamaFile") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:FileUpload ID="fuAdd" runat="server" />
                                    <asp:RequiredFieldValidator ID="reqfuAdd" runat="server" ControlToValidate="fuAdd"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgPKPLainnya" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:FileUpload ID="fuEdit" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="No. PKP" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <asp:Label ID="lblPKP" runat="server" Text='<%# Eval("NoPKP") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtPKPAdd" runat="server" Width="200px" />
                                    <asp:RequiredFieldValidator ID="reqtxtPKPAdd" runat="server" ControlToValidate="txtPKPAdd"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgPKPLainnya" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPKPEdit" runat="server" Width="200px" Text='<%# Eval("NoPKP") %>' />
                                    <asp:RequiredFieldValidator ID="reqtxtPKPEdit" runat="server" ControlToValidate="txtPKPEdit"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgPKPLainnya" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Keterangan">
                                <ItemTemplate>
                                    <asp:Label ID="lblKeterangan" runat="server" Text='<%# Eval("Keterangan") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtKeteranganAdd" runat="server" Rows="3" TextMode="MultiLine" Width="350px" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtKeteranganEdit" runat="server" Rows="3" TextMode="MultiLine"
                                        Text='<%# Eval("Keterangan") %>' Width="350px" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgPKPLainnya" CommandName="add">Add</asp:LinkButton>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgPKPLainnya" CommandName="save">Save</asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </fieldset>
            </fieldset>
            <fieldset>
                <legend><b>BNRI [ dilaporkan oleh PIC Corporate Secretary (<asp:Literal ID="ltrUsernameBNRI"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuBNRI" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuBNRI" runat="server" />
                            <br />
                            <%--  <asp:RequiredFieldValidator ID="reqfuBNRI" ValidationGroup="Save" runat="server"
                                ControlToValidate="fuBNRI" ErrorMessage="Required Field" Display="Dynamic" />--%>
                            <br />
                            <br />
                            Original/Copy? :
                            <asp:CheckBox ID="chkOriginalBNRI" runat="server" Text="Original di-check. Copy di-uncheck" />
                            <asp:Literal ID="ltrOriginalBNRI" runat="server" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        No
                                        <%--<span style="color: Red">*</span>--%>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoBNRI" runat="server" />
                                        <asp:Literal ID="ltrNoBNRI" runat="server" />
                                        <%--   <asp:RequiredFieldValidator ID="reqtxtNoBNRI" ValidationGroup="Save" runat="server"
                                            ControlToValidate="txtNoBNRI" ErrorMessage="Required Field" Display="Dynamic" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal
                                        <%--<span style="color: Red">*</span>--%>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalBNRI" DateOnly="true" runat="server"></SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalBNRI" runat="server" />
                                                </td>
                                                <td>
                                                    <%--  <asp:RequiredFieldValidator ID="reqdtTanggalBNRI" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtTanggalBNRI$dtTanggalBNRIDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Tambahan No
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTambahanNoBNRI" runat="server" />
                                        <asp:Literal ID="ltrTambahanNoBNRI" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlAccounting" runat="server" Visible="false">
            <fieldset>
                <legend><b>Journal Voucher (JV) [ dilaporkan oleh Accounting (<asp:Literal ID="ltrUsernameAPV"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="320px">
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuAPV" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuAPV" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuAPV" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuAPV" ErrorMessage="Required Field" />
                            <br />
                            <br />
                            Original/Copy? :
                            <asp:CheckBox ID="chkOriginalAPV" runat="server" Text="Original di-check. Copy di-uncheck" />
                            <asp:Literal ID="ltrOriginalAPV" runat="server" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        Kode Perusahaan <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtKodePerusahaanAPV" runat="server" />
                                        <asp:Literal ID="ltrKodePerusahaanAPV" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtKodePerusahaanAPV" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtKodePerusahaanAPV" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        No Journal Voucher (JV) <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoAPV" runat="server" />
                                        <asp:Literal ID="ltrNoAPV" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNoAPV" Display="Dynamic" ValidationGroup="Save"
                                            runat="server" ControlToValidate="txtNoAPV" ErrorMessage="Required Field" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal Journal Voucher (JV) <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <SharePoint:DateTimeControl ID="dtTanggalAPV" DateOnly="true" runat="server"></SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrTanggalAPV" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalAPV" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtTanggalAPV$dtTanggalAPVDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />
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
                                        <asp:TextBox ID="txtKeteranganAPV" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        <asp:Literal ID="ltrKeteranganAPV" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
    </fieldset>
    <fieldset>
        <legend><b>Dokumen Lainnya</b></legend>
        <br />
        <asp:DataGrid ID="dgDokumenLainnya" runat="server" AutoGenerateColumns="false" CssClass="table"
            ShowFooter="true" Width="100%" OnItemCommand="dgDokumenLainnya_ItemCommand" OnItemDataBound="dgDokumenLainnya_ItemDataBound">
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
                <asp:TemplateColumn HeaderText="Tipe Dokumen" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblTipeDokumen" runat="server" Text='<%# Eval("TipeDokumen") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlTipeDokumenAdd" runat="server">
                            <asp:ListItem Selected="True" Text="--Select--" Value="" />
                            <asp:ListItem Text="Sertifikat" />
                            <asp:ListItem Text="Asset" />
                            <asp:ListItem Text="Insurance" />
                            <asp:ListItem Text="Ijin Operasional" />
                            <asp:ListItem Text="Compliance" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqddlTipeDokumenAdd" runat="server" ControlToValidate="ddlTipeDokumenAdd"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="dgDokumenLainnya" ToolTip="Required Field" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTipeDokumenEdit" runat="server">
                            <asp:ListItem Selected="True" Text="--Select--" Value="" />
                            <asp:ListItem Text="Sertifikat" />
                            <asp:ListItem Text="Asset" />
                            <asp:ListItem Text="Insurance" />
                            <asp:ListItem Text="Ijin Operasional" />
                            <asp:ListItem Text="Compliance" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqddlTipeDokumenEdit" runat="server" ControlToValidate="ddlTipeDokumenEdit"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="dgDokumenLainnya" ToolTip="Required Field" />
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Penjelasan">
                    <ItemTemplate>
                        <asp:Label ID="lblPenjelasan" runat="server" Text='<%# Eval("Penjelasan") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPenjelasanAdd" runat="server" Rows="3" TextMode="MultiLine" Width="300px" />
                        <asp:RequiredFieldValidator ID="reqtxtPenjelasanAdd" runat="server" ControlToValidate="txtPenjelasanAdd"
                            Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgDokumenLainnya" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPenjelasanEdit" runat="server" Rows="3" TextMode="MultiLine"
                            Text='<%# Eval("Penjelasan") %>' Width="300px" />
                        <asp:RequiredFieldValidator ID="reqtxtPenjelasanEdit" runat="server" ControlToValidate="txtPenjelasanEdit"
                            Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgDokumenLainnya" />
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Attachment" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblAtttachmentHidden" runat="server" Text='<%# Eval("NamaFile") %>'
                            Visible="false" />
                        <asp:Label ID="lblAtttachment" runat="server" Text='<%# Eval("NamaFile") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuAdd" runat="server" />
                        <asp:RequiredFieldValidator ID="reqfuAdd" runat="server" ControlToValidate="fuAdd"
                            Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgDokumenLainnya" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:FileUpload ID="fuEdit" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgDokumenLainnya" CommandName="add">Add</asp:LinkButton>
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgDokumenLainnya" CommandName="save">Save</asp:LinkButton>
                        <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </fieldset>
</fieldset>
<fieldset>
    <div style="text-align: right">
        <asp:Button ID="btnSaveUpdate" runat="server" ValidationGroup="Save" Text="Save"
            OnClick="btnSaveUpdate_Click" />&nbsp;
        <asp:Button ID="btnSaveUpdateRunWf" runat="server" Text="Save & Run Workflow" ValidationGroup="Save"
            OnClick="btnSaveUpdateRunWf_Click" Width="160px" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</fieldset>
<div id="divPemohonDlgContainer">
    <div id="divPemohonSearch" style="display: none">
        <uc:Pemohon ID="Pemohon" runat="server" />
    </div>
</div>
<div id="divPemegangSahamDlgContainer">
    <div id="divPemegangSahamSearch" style="display: none">
        <uc:PemegangSahamKomisaris ID="ucPemegangSaham" runat="server" />
    </div>
</div>
<div id="divKomisarisDlgContainer">
    <div id="divKomisarisSearch" style="display: none">
        <uc:PemegangSahamKomisaris ID="ucKomisaris" runat="server" />
    </div>
</div>
<div id="divPemegangSahamInfoDlgContainer">
    <div id="divPemegangSahamInfoSearch" style="display: none">
        <uc:PemegangSahamKomisarisInfo ID="ucPemegangSahamInfo" runat="server" />
    </div>
</div>
<div id="divKomisarisInfoDlgContainer">
    <div id="divKomisarisInfoSearch" style="display: none">
        <uc:PemegangSahamKomisarisInfo ID="ucKomisarisInfo" runat="server" />
    </div>
</div>
<div id="divSKDPLogDlgContainer">
    <div id="divSKDPLog" style="display: none">
        <uc:SKDPLog ID="SKDPLog" runat="server" />
    </div>
</div>
<div id="divPerusahaanDlgContainer">
    <div id="divPerusahaanSearch" style="display: none">
        <uc:Perusahaan ID="Perusahaan" runat="server" />
        
    </div>
</div>
