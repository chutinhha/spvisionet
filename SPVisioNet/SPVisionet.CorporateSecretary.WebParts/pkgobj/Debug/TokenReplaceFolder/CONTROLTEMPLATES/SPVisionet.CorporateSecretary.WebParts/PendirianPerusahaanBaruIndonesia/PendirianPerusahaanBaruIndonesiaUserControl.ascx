<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendirianPerusahaanBaruIndonesiaUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruIndonesia.PendirianPerusahaanBaruIndonesiaUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permohonan Pendirian Perusahaan (Indonesia)</b></h3>
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
    <fieldset>
        <legend><b>Data Perusahaan</b></legend>
        <table border="0">
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
            <tr>
                <td>
                    Status Perseroan <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatusPerseroan" runat="server" />
                    <asp:Literal ID="ltrStatusPerseroan" runat="server" />
                    <asp:RequiredFieldValidator ID="reqddlStatusPerseroan" ValidationGroup="Save" runat="server"
                        ControlToValidate="ddlStatusPerseroan" ErrorMessage="Required Field" Display="Dynamic" />
                </td>
            </tr>
        </table>
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
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiMenjabatAdd" ValidationGroup="dgPemegangSaham"
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
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiMenjabatEdit" ValidationGroup="dgPemegangSaham"
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
                                                <asp:RequiredFieldValidator ID="reqdtTanggalAkhirMenjabatAdd" ValidationGroup="dgPemegangSaham"
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
                                                <asp:RequiredFieldValidator ID="reqdtTanggalAkhirMenjabatEdit" ValidationGroup="dgPemegangSaham"
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
                                <asp:Label ID="lblNama" runat="server" Text='<%# Eval("Nama") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNamaAdd" runat="server" Width="200px" />
                                <asp:RequiredFieldValidator ID="reqtxtNamaAdd" runat="server" ControlToValidate="txtNamaAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgKomisaris" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNamaEdit" runat="server" Width="200px" Text='<%# Eval("Nama") %>' />
                                <asp:RequiredFieldValidator ID="reqtxtNamaEdit" runat="server" ControlToValidate="txtNamaEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgKomisaris" />
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
                        <asp:TemplateColumn HeaderText="No. KTP">
                            <ItemTemplate>
                                <asp:Label ID="lblNoKTP" runat="server" Text='<%# Eval("NoKTP") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNoKTPAdd" runat="server" />
                                <asp:RequiredFieldValidator ID="reqtxtNoKTPAdd" runat="server" ControlToValidate="txtNoKTPAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgKomisaris" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNoKTPEdit" runat="server" Text='<%# Eval("NoKTP") %>' />
                                <asp:RequiredFieldValidator ID="reqtxtNoKTPEdit" runat="server" ControlToValidate="txtNoKTPEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgKomisaris" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="No. NPWP">
                            <ItemTemplate>
                                <asp:Label ID="lblNoNPWP" runat="server" Text='<%# Eval("NoNPWP") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNoNPWPAdd" runat="server" />
                                <asp:RequiredFieldValidator ID="reqtxtNoNPWPAdd" runat="server" ControlToValidate="txtNoNPWPAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgKomisaris" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNoNPWPEdit" runat="server" Text='<%# Eval("NoNPWP") %>' />
                                <asp:RequiredFieldValidator ID="reqtxtNoNPWPEdit" runat="server" ControlToValidate="txtNoNPWPEdit"
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
                        <asp:TemplateColumn HeaderText="Nama">
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
        <legend><b>Laporan Perkembangan Pendirian</b></legend>
        <asp:Panel ID="pnlPICCorsec1" runat="server" Visible="false">
            <fieldset>
                <legend><b>Akta [ dilaporkan oleh Corporate Secretary (<asp:Literal ID="ltrUsernameAkte"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuAkte" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuAkte" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuAkte" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuAkte" ErrorMessage="Required Field" />
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
        </asp:Panel>
        <asp:Panel ID="pnlPICCorsec2" runat="server" Visible="false">
            <fieldset>
                <legend><b>SKDP [ dilaporkan oleh Corporate Secretary (<asp:Literal ID="ltrUsernameSKDP"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuSKDP" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuSKDP" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuSKDP" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuSKDP" ErrorMessage="Required Field" />
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
        </asp:Panel>
        <asp:Panel ID="pnlAccounting" runat="server" Visible="false">
            <fieldset>
                <legend><b>APV [ dilaporkan oleh Accounting (<asp:Literal ID="ltrUsernameAPV" runat="server" />)
                    ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuAPV" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuAPV" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuAPV" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuAPV" ErrorMessage="Required Field" />
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
                                        No APV <span style="color: Red">*</span>
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
                                        Tanggal APV <span style="color: Red">*</span>
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
        <asp:Panel ID="pnlFinance" runat="server" Visible="false">
            <fieldset>
                <legend><b>Setoran Modal [ dilaporkan oleh Finance (<asp:Literal ID="ltrUsernameSetoran"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuSetoranModal" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuSetoranModal" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuSetoranModal" ValidationGroup="Save" runat="server"
                                ControlToValidate="fuSetoranModal" ErrorMessage="Required Field" Display="Dynamic" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        Tanggal Setoran <span style="color: Red">*</span>
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
                                        Status
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkStatusSetoran" runat="server" />
                                        <asp:Literal ID="ltrStatusSetoran" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlPICCorsec3" runat="server" Visible="false">
            <fieldset>
                <legend><b>SK Pengesahan Pendirian [ dilaporkan oleh Corporate Secretary (<asp:Literal
                    ID="ltrUsernameSKPengesahan" runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <div style="display: none">
                                <br />
                                <b>Note:
                                    <br />
                                    Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                                <br />
                                <br />
                                <asp:Literal ID="ltrfuSKPengesahan" runat="server" Visible="false" />
                                <br />
                                <br />
                                <asp:FileUpload ID="fuSKPengesahan" runat="server" Visible="false" />
                                <br />
                                <asp:RequiredFieldValidator ID="reqfuSKPengesahan" ValidationGroup="Save" runat="server"
                                    ControlToValidate="fuSKPengesahan" ErrorMessage="Required Field" Display="Dynamic"
                                    Visible="false" /></div>
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
                <legend><b>BNRI [ dilaporkan oleh PIC Corporate Secretary (<asp:Literal ID="ltrUsernameBNRI"
                    runat="server" />) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuBNRI" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuBNRI" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuBNRI" ValidationGroup="Save" runat="server"
                                ControlToValidate="fuBNRI" ErrorMessage="Required Field" Display="Dynamic" />
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
                                        <asp:TextBox ID="txtNoBNRI" runat="server" />
                                        <asp:Literal ID="ltrNoBNRI" runat="server" />
                                        <asp:RequiredFieldValidator ID="reqtxtNoBNRI" ValidationGroup="Save" runat="server"
                                            ControlToValidate="txtNoBNRI" ErrorMessage="Required Field" Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tanggal <span style="color: Red">*</span>
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
                                                    <asp:RequiredFieldValidator ID="reqdtTanggalBNRI" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtTanggalBNRI$dtTanggalBNRIDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />
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
        <asp:Panel ID="pnlTax" runat="server" Visible="false">
            <fieldset>
                <legend><b>NPWP [ dilaporkan oleh Tax (<asp:Literal ID="ltrUsernameNPWP" runat="server" />)
                    ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuNPWP" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuNPWP" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuNPWP" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuNPWP" ErrorMessage="Required Field" />
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
                                        Keterangan
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtKeteranganNPWP" runat="server" Width="350px" Rows="3" TextMode="MultiLine" />
                                        <asp:Literal ID="ltrKeteranganNPWP" runat="server" />
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
                            <asp:TemplateColumn HeaderText="NPWP" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
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
        </asp:Panel>
        <asp:Panel ID="pnlTax2" runat="server" Visible="false">
            <fieldset>
                <legend><b>PKP [ dilaporkan oleh Tax (<asp:Literal ID="ltrUsernamePKP" runat="server" />)
                    ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuPKP" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuPKP" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="reqfuPKP" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuPKP" ErrorMessage="Required Field" />
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td>
                                        No PKP <span style="color: Red">*</span>
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
                                        Tanggal Terdaftar <span style="color: Red">*</span>
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
                                        Nama PKP <span style="color: Red">*</span>
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
                                        Status <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkStatusPKP" runat="server" Checked="true" AutoPostBack="true"
                                            OnCheckedChanged="chkStatusPKP_CheckedChanged" Text="" />
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
                            <asp:TemplateColumn HeaderText="PKP" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
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
                            <asp:ListItem Text="Aset" />
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
                            <asp:ListItem Text="Aset" />
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
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
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
                                            <asp:UpdateProgress ID="upProg" AssociatedUpdatePanelID="upPemohon" runat="server"
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
                                <table cellpadding="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSavePemohon" runat="server" Text="Save" ValidationGroup="SavePemohon"
                                                OnClick="btnSavePemohon_Click" />&nbsp;
                                            <asp:Button ID="btnCancelPemohon" runat="server" Text="Cancel" OnClick="btnCancelPemohon_Click" />
                                        </td>
                                        <td>
                                            <asp:UpdateProgress ID="upProgAdd" AssociatedUpdatePanelID="upPemohon" runat="server"
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
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
