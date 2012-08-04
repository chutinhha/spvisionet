<%@ Assembly Name="SPVisioNet.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=dc0df5bbccecf641" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PerubahanAnggaranDasarDanDataPerseroanUserControl.ascx.cs"
    Inherits="SPVisioNet.WebParts.PerubahanAnggaranDasarDanDataPerseroan.PerubahanAnggaranDasarDanDataPerseroanUserControl" %>
<style type="text/css">
    .style2
    {
        width: 73px;
    }
    .style3
    {
        width: 13px;
    }
</style>
<fieldset>
    <legend>
        <h3>
            <b>Perubahan Anggaran Dasar & Data Perseroan</b></h3>
    </legend>
    <div style="text-align: right">
        <span style="color: Red">*</span> indicates a required field</div>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Label ID="ltrWorkflow" runat="server" Visible="true"></asp:Label>
            <table border="0">
                <tr>
                    <td width="200px">
                        Date
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
                        <asp:Literal ID="ltrRequestCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Jenis Perubahan
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:CheckBoxList ID="chkBoxListJenisPerubahan" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Anggaran Dasar" Value="Anggaran Dasar"></asp:ListItem>
                            <asp:ListItem Text="Data Perseroan" Value="Data Perseroan"></asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:Label ID="ltrListJenisPerubahan" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Alasan Perubahan
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAlasanPerubahan" runat="server" Height="98px" TextMode="MultiLine"
                            Width="479px"></asp:TextBox>
                        <asp:Label ID="ltrAlasanPerubahan" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        BNRI
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbBNRI" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="ltrBNRI" runat="server"></asp:Label>
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
                        <asp:HiddenField ID="hfIDPemohon" runat="server" />
                        <asp:TextBox ID="txtNamaPemohon" runat="server" Enabled="false" Width="476px" />
                        <asp:Literal ID="ltrNamaPemohon" runat="server" />
                        <asp:ImageButton ID="imgbtnNamaPemohon" ValidationGroup="popup" runat="server" ImageUrl="/_layouts/images/SPVisioNet.WebParts/popup.gif"
                            ToolTip="Search" OnClientClick="openDialog(event,'Cari Nama Pemohon', 'divPemohonSearch')"
                            CausesValidation="false" OnClick="imgbtnNamaPemohon_Click" />
                        <asp:RequiredFieldValidator ID="reqtxtNamaPemohon" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="txtNamaPemohon" ErrorMessage="Required Field" />
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
                        <asp:TextBox ID="txtEmailPemohon" runat="server" Enabled="false" Width="476px" />
                        <asp:Literal ID="ltrEmailPemohon" runat="server" />
                        <asp:RequiredFieldValidator ID="reqtxtEmailPemohon" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="txtEmailPemohon" ErrorMessage="Required Field" />
                        <asp:RegularExpressionValidator ID="reqEmailPemohon" runat="server" ErrorMessage="Invalid Email"
                            ControlToValidate="txtEmailPemohon" Display="Dynamic" ValidationGroup="Save"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Enabled="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Perubahan Nama dan Tempat Kedudukan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdPerubahanNama" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="reqrdPerubahanNama" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="rdPerubahanNama" ErrorMessage="Required Field" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Perubahan Modal
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdPerubahanModal" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="reqrdPerubahanModal" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="rdPerubahanModal" ErrorMessage="Required Field" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
<fieldset>
    <legend><b>Data Perusahaan</b></legend>
    <asp:UpdatePanel ID="upDataPerusahaan" runat="server">
        <ContentTemplate>
            <table border="0">
                <tr>
                    <td width="200px">
                        Company Code <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:HiddenField ID="hfIDCompany" runat="server" />
                        <asp:TextBox ID="txtCompanyCode" runat="server" Width="476px" ReadOnly="true" />
                        <asp:Literal ID="ltrCompanyCode" runat="server" />
                        <asp:RequiredFieldValidator ID="reqtxtCompanyCode" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="txtCompanyCode" ErrorMessage="Required Field" />
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
                        <asp:TextBox ID="txtCompanyName" runat="server" Width="476px" />
                        <asp:ImageButton ID="imgbtnNamaCompany" ValidationGroup="popup" runat="server" ImageUrl="/_layouts/images/SPVisioNet.WebParts/popup.gif"
                            ToolTip="Search" OnClientClick="openDialog(event,'Cari Nama Company', 'divCompanySearch')"
                            CausesValidation="false" OnClick="imgbtnNamaCompany_Click" />
                        <asp:RequiredFieldValidator ID="reqtxtCompanyName" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="txtCompanyName" ErrorMessage="Required Field" />
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
                        <asp:Literal ID="ltrddlTempatKedudukan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Maksud Dan Tujuan
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMaksudDanTujuan" runat="server" />
                        <asp:Literal ID="ltrddlMaksudDanTujuan" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
<fieldset>
    <legend><b>Perubahan Anggaran Dasar</b></legend>
    <asp:UpdatePanel ID="upAnggaranDasar" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td width="200px">
                        Mata Uang (SGD/IDR/USD) <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMataUang" runat="server" />
                        <asp:RequiredFieldValidator ID="reqddlMataUang" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="ddlMataUang" ErrorMessage="Required Field" />
                        <asp:Label ID="ltrMataUang" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <b>Saham</b>
                    </td>
                    <td>
                        <b>Nominal</b>
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
                        <asp:TextBox ID="txtModalDasarNominalSemula" runat="server"></asp:TextBox>
                        <asp:Label ID="ltrtxtModalDasarNominalSemula" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="reqtxtModalDasarNominalSemula" Display="Dynamic"
                            ValidationGroup="Save" runat="server" ControlToValidate="txtModalDasarNominalSemula"
                            ErrorMessage="Required Field" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtModalDasarNominalMenjadi" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="ltrtxtModalDasarNominalMenjadi" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Modal Setor (nominal) <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtModalSetorNominalSemula" runat="server"></asp:TextBox>
                        <asp:Label ID="ltrtxtModalSetorNominalSemula" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="reqtxtModalSetorNominalSemula" Display="Dynamic"
                            ValidationGroup="Save" runat="server" ControlToValidate="txtModalSetorNominalSemula"
                            ErrorMessage="Required Field" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtModalSetorNominalMenjadi" runat="server" ReadOnly="true"></asp:TextBox>
                         <asp:Label ID="ltrtxtModalSetorNominalMenjadi" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nominal (Mata Uang / 1 saham) <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtNominalMataUang" runat="server" Text="1"></asp:TextBox>
                        <asp:Literal ID="ltrNominalMataUang" runat="server" />
                        <asp:RequiredFieldValidator ID="reqtxtNominalMataUang" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="txtNominalMataUang" ErrorMessage="Required Field" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
<br />
<br />
<div id="divPerubahanDataPerseroan" runat="server" visible="true">
    <b>Perubahan Data Perseroan</b>
    <fieldset>
        <legend><b>Komisaris dan Direksi</b></legend>
        <br />
        <b>Semula</b>
        <asp:UpdatePanel ID="upKomisarisSemula" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataGrid ID="dgKomisarisSemula" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="false" Width="100%" OnItemDataBound="dgKomisarisSemula_ItemDataBound">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Nama">
                            <ItemTemplate>
                                <asp:Label ID="lblNama" runat="server" Text='<%# Eval("Nama") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Jabatan">
                            <ItemTemplate>
                                <asp:Label ID="lblJabatan" runat="server" Text='<%# Eval("Jabatan") %>' />
                                <asp:Label ID="lblJabatanID" runat="server" Text='<%# Eval("IDJabatan") %>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="No. KTP">
                            <ItemTemplate>
                                <asp:Label ID="lblNoKTP" runat="server" Text='<%# Eval("NoKTP") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="No. NPWP">
                            <ItemTemplate>
                                <asp:Label ID="lblNoNPWP" runat="server" Text='<%# Eval("NoNPWP") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Mulai Menjabat" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalMulaiMenjabat" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Akhir Menjabat" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalAkhirMenjabat" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <b>Menjadi</b>
        <asp:UpdatePanel ID="upKomisarisMenjadi" runat="server" UpdateMode="Conditional">
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
                        <asp:TemplateColumn HeaderText="Mulai Menjabat" Visible="true">
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
</div>
<fieldset>
    <legend><b>Pemegang Saham</b></legend>
    <br />
    <b>Semula</b>
    <asp:UpdatePanel ID="upPemegangSahamSemula" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:DataGrid ID="dgPemegangSahamSemula" runat="server" AutoGenerateColumns="false"
                CssClass="table" Width="100%" OnItemDataBound="dgPemegangSahamSemula_ItemDataBound">
                <HeaderStyle CssClass="header" />
                <ItemStyle CssClass="odd" />
                <AlternatingItemStyle CssClass="white" />
                <Columns>
                    <asp:TemplateColumn HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Nama Pemegang Saham">
                        <ItemTemplate>
                            <asp:Label ID="lblNamaPemegangSaham" runat="server" Text='<%# Eval("Nama") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Jumlah Saham" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblJumlahSaham" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JumlahSaham", "{0:#,##0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Jumlah Nominal" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblJumlahNominal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JumlahNominal", "{0:#,##0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Percentages" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblPercentages" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Percentages", "{0:#,##0.00}") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Partner" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPartner" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Mulai Menjabat" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblTanggalMulaiMenjabat" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Akhir Menjabat" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblTanggalAkhirMenjabat" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <b>Menjadi</b>
    <asp:UpdatePanel ID="upPemegangSahamMenjadi" runat="server" UpdateMode="Conditional">
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
                    <asp:TemplateColumn HeaderText="Mulai Menjabat" Visible="true">
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
<br />
<fieldset>
    <asp:UpdatePanel ID="upRemarks" runat="server">
        <ContentTemplate>
            <table border="0">
                <tr>
                    <td valign="top" width="200px">
                        Remarks
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
                        <asp:Label ID="ltrRemarks" runat="server"></asp:Label>
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
                        Corporate Secretary
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
                        Chief Corporate Secretary
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
<br />
<div id="divPerubahanAnggaran" runat="server" visible="false">
    <fieldset>
        <legend><b>Perubahan Anggaran Dasar & Data Perseroan (<asp:Label ID="lblPerusahaanName"
            runat="server"></asp:Label>)</b></legend>
        <div id="divAkta" runat="server" visible="false">
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
        </div>
        <div id="divBNRI" runat="server" visible="false">
            <fieldset>
                <legend><b>BNRI [ dilaporkan oleh Corporate Secretary (<asp:Label ID="lblBNRIUserName"
                    runat="server"></asp:Label>) ]</b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            &nbsp;
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="150px">
                                        No BNRI <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBNRINo"></asp:TextBox>
                                        <asp:Label runat="server" ID="ltrBNRINo"></asp:Label>
                                        <asp:RequiredFieldValidator ID="reqtxtBNRINo" ValidationGroup="Save" runat="server"
                                            ControlToValidate="txtBNRINo" ErrorMessage="Required Field" Display="Dynamic" />
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
                                                    <SharePoint:DateTimeControl ID="dtBNRIMulaiBerlaku" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrBNRIMulaiBerlaku" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtBNRIMulaiBerlaku" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtBNRIMulaiBerlaku$dtBNRIMulaiBerlakuDate" ErrorMessage="Required Field"
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
                                        <asp:TextBox ID="txtBNRIKeterangan" runat="server" TextMode="MultiLine" Height="70px"
                                            Width="230px"></asp:TextBox>
                                        <asp:Label runat="server" ID="ltrBNRIKeterangan"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div id="divSKDP" runat="server" visible="false">
            <fieldset>
                <legend><b>SKDP [ dilaporkan oleh Corporate Secretary (<asp:Label ID="lblSKDPUserName"
                    runat="server"></asp:Label>) ]</b></legend>
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
                                        No SKDP <span style="color: Red">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSKDPNo"></asp:TextBox>
                                        <asp:Label runat="server" ID="ltrSKDPNo"></asp:Label>
                                        <asp:RequiredFieldValidator ID="reqtxtSKDPNo" ValidationGroup="Save" runat="server"
                                            ControlToValidate="txtSKDPNo" ErrorMessage="Required Field" Display="Dynamic" />
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
                                                    <SharePoint:DateTimeControl ID="dtSKDPTanggalMulai" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrSKDPTanggalMulai" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtSKDPTanggalMulai" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtSKDPTanggalMulai$dtSKDPTanggalMulaiDate" ErrorMessage="Required Field"
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
                                                    <SharePoint:DateTimeControl ID="dtSKDPTanggalAkhir" DateOnly="true" runat="server">
                                                    </SharePoint:DateTimeControl>
                                                    <asp:Literal ID="ltrSKDPTanggalAkhir" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="reqdtSKDPTanggalAkhir" ValidationGroup="Save" runat="server"
                                                        ControlToValidate="dtSKDPTanggalAkhir$dtSKDPTanggalAkhirDate" ErrorMessage="Required Field"
                                                        Display="Dynamic" />
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
                                <tr>
                                    <td valign="top">
                                        Keterangan
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSKDPKeterangan" runat="server" TextMode="MultiLine" Height="70px"
                                            Width="230px"></asp:TextBox>
                                        <asp:Label runat="server" ID="ltrSKDPKeterangan"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </fieldset>
    <div id="divNPWPSKT" runat="server" visible="false">
        <fieldset>
            <legend><b>NPWP & SKT [ dilaporkan oleh Tax (<asp:Literal ID="ltrUsernameNPWP" runat="server" />))
                ]</b></legend>
            <fieldset>
                <legend><b>SKT </b></legend>
                <table border="0">
                    <tr>
                        <td valign="top" width="315px">
                            <br />
                            <b>Note:
                                <br />
                                Penulisan harus ada [ORI]xxxxx / [Soft]xxxxx</b>
                            <br />
                            <br />
                            <asp:Literal ID="ltrfuSKT" runat="server" />
                            <br />
                            <br />
                            <asp:FileUpload ID="fuSKT" runat="server" /><br />
                            <asp:RequiredFieldValidator ID="reqfuSKT" Display="Dynamic" ValidationGroup="Save"
                                runat="server" ControlToValidate="fuSKT" ErrorMessage="Required Field" />
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
                            </table>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>NPWP </b></legend>
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
        </fieldset>
    </div>
    <div id="divAccounting" runat="server" visible="false">
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
    </div>
    <div id="divFinance" runat="server" visible="false">
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
    </div>
    <div id="divSK" runat="server" visible="false">
        <fieldset>
            <legend><b>SK atau Penerimaan Pemberitahuan Tentang Perubahan Anggaran Dasar [ dilaporkan
                oleh Corporate Secretary (<asp:Label ID="lblSKUserName" runat="server"></asp:Label>)
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
                        <asp:Literal ID="ltrfuSK" runat="server" />
                        <br />
                        <br />
                        <asp:FileUpload ID="fuSK" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="reqfuSK" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="fuSK" ErrorMessage="Required Field" />
                    </td>
                    <td>
                        <table border="0">
                            <tr>
                                <td width="150px">
                                    No SK <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtSKNo"></asp:TextBox>
                                    <asp:Literal ID="ltrSKNo" runat="server" /><asp:RequiredFieldValidator ID="reqltrSKNo"
                                        Display="Dynamic" ValidationGroup="Save" runat="server" ControlToValidate="txtSKNo"
                                        ErrorMessage="Required Field" />
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
                                                <SharePoint:DateTimeControl ID="dtSKMulaiBerlaku" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                                <asp:Literal ID="ltrSKMulaiBerlaku" runat="server" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtSKMulaiBerlaku" ValidationGroup="Save" runat="server"
                                                    ControlToValidate="dtSKMulaiBerlaku$dtSKMulaiBerlakuDate" ErrorMessage="Required Field"
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
                                    <asp:TextBox ID="txtSKKeterangan" runat="server" TextMode="MultiLine" Height="70px"
                                        Width="230px"></asp:TextBox>
                                    <asp:Literal ID="ltrSKKeterangan" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</div>
<div style="text-align: right">
    <asp:Button ID="btnSaveUpdate" runat="server" ValidationGroup="Save" Text="Save"
        OnClick="btnSaveUpdate_Click" Width="70px" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
        Width="70px" ValidationGroup="Cancel" />
</div>
<div id="divPemohonDlgContainer">
    <div id="divPemohonSearch" style="display: none">
        <asp:UpdatePanel ID="upPemohon" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlPemohon" runat="server">
                    <table width="100%" border="0">
                        <tr>
                            <td>
                                Search :
                                <asp:TextBox ID="txtSearchPemohon" runat="server" Width="200px" />
                                &nbsp;<asp:Button ID="btnSearchPemohon" runat="server" Text="Search" OnClick="btnSearchPemohon_Click" />
                                &nbsp;<asp:Button ID="btnAddPemohon" runat="server" Text="Add New" OnClick="btnAddPemohon_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grvPemohon" runat="server" AutoGenerateColumns="false" CssClass="table"
                                    Width="100%" EmptyDataText="No Data Available" DataSourceID="odsPemohon" AllowPaging="true"
                                    PageSize="15" OnRowCommand="grvPemohon_RowCommand" OnRowDataBound="grvPemohon_RowDataBound">
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
                                <asp:TextBox ID="txtNamaPemohonAddEdit" runat="server" Width="250px" />
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
                                <asp:TextBox ID="txtEmailPemohonAddEdit" runat="server" Width="250px" />
                                <asp:RequiredFieldValidator ID="reqtxtEmailPemohonAddEdit" Display="Dynamic" ValidationGroup="SavePemohon"
                                    runat="server" ControlToValidate="txtEmailPemohonAddEdit" ErrorMessage="Required Field" />
                                <asp:RegularExpressionValidator ID="regtxtEmailPemohonAddEdit" runat="server" ErrorMessage="Invalid Email"
                                    ControlToValidate="txtEmailPemohonAddEdit" Display="Dynamic" ValidationGroup="SavePemohon"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Button ID="btnSavePemohon" runat="server" Text="Save" ValidationGroup="SavePemohon"
                                    OnClick="btnSavePemohon_Click" />&nbsp;
                                <asp:Button ID="btnCancelPemohon" runat="server" Text="Cancel" OnClick="btnCancelPemohon_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
<div id="divCompanyDlgContainer">
    <div id="divCompanySearch" style="display: none">
        <asp:UpdatePanel ID="upCompanySearch" runat="server">
            <ContentTemplate>
                <table width="100%" border="0">
                    <tr>
                        <td>
                            Search :
                            <asp:TextBox ID="txtSearchCompany" runat="server" />
                            &nbsp;<asp:Button ID="btnSearchCompany" runat="server" Text="Search" OnClick="btnSearchCompany_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="Button1" runat="server" Text="Cancel" OnClientClick="closeDialog('divCompanySearch')" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grvCompanySearch" runat="server" AutoGenerateColumns="false" CssClass="table"
                                Width="100%" EmptyDataText="No Data Available" DataSourceID="odsCompany" AllowPaging="true"
                                PageSize="15" OnRowDataBound="grvCompanySearch_RowDataBound">
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
                                    <asp:BoundField DataField="CompanyCodeAPV" HeaderText="Company Name" />
                                    <asp:BoundField DataField="NamaPerusahaan" HeaderText="Nama Perusahaan" />
                                    <asp:BoundField DataField="MataUang" HeaderText="Mata Uang" />
                                    <asp:BoundField DataField="TempatKedudukan" HeaderText="Tempat Kedudukan" />
                                    <asp:BoundField DataField="MaksudTujuan" HeaderText="Maksud dan Tujuan" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsCompany" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
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
                            <asp:Button ID="btnSelectCompany" runat="server" Text="Select" OnClick="btnSelectCompany_Click" />
                            <asp:Button ID="btnSelectCompanyClose" runat="server" Text="Close" OnClientClick="closeDialog('divCompanySearch')" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
