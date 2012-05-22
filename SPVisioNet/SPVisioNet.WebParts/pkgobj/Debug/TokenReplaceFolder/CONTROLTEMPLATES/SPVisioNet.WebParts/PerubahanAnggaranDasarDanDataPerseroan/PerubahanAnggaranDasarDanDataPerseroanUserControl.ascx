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
<asp:UpdatePanel ID="upMain" runat="server">
    <ContentTemplate>
        <fieldset>
            <legend>
                <h3>
                    <b>Perubahan Anggaran Dasar & Data Perseroan</b></h3>
            </legend>
            <table border="0">
                <tr>
                    <td>
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
                    </td>
                </tr>
                <tr>
                    <td>
                        Requestor
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRequestor" runat="server" />
                        <asp:ImageButton ID="imgbtntxtRequestor" runat="server" ValidationGroup="popup" ImageUrl="/_layouts/images/SPVisioNet.WebParts/popup.gif"
                            ToolTip="Search" OnClientClick="openDialog('Search Requestor', 'divMainSearch')"
                            CausesValidation="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Requestor Email
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRequestorEmail" runat="server" />
                        <img src="/_layouts/images/SPVisioNet.WebParts/popup.gif" alt="Search" />
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend><b>Data Perusahaan</b></legend>
                <table border="0">
                    <tr>
                        <td>
                            Company Code
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyCode" runat="server" />
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
                            <asp:TextBox ID="txtCompanyName" runat="server" />
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
                            Maksud Dan Tujuan
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtMaksudDanTujuan" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>Perubahan Anggaran Dasar</b></legend>
                <table>
                    <tr>
                        <td>
                            Mata Uang (SGD/IDR/USD)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddMataUang" runat="server">
                                <asp:ListItem Text="SGD" Value="SGD"></asp:ListItem>
                                <asp:ListItem Text="IDR" Value="IDR" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                            </asp:DropDownList>
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
                            <b>Semula</b>
                        </td>
                        <td>
                            <b>Menjadi</b>
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
                            <asp:TextBox ID="txtModalDasarNominalSemula" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModalDasarNominalMenjadi" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="txtModalSetorNominalSemula" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModalSetorNominalMenjadi" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nominal (Mata Uang / 1 saham)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtNominalMataUang" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br />
            <br />
            <b>Perubahan Data Perseroan</b>
            <fieldset>
                <legend><b>Komisaris dan Direksi</b></legend>
                <br />
                <b>Semula</b>
                <asp:DataGrid ID="dgShareholderSemula" runat="server" AutoGenerateColumns="false"
                    CssClass="table" ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Nama">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNameAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNameEdit" runat="server" />
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
                        <asp:TemplateColumn HeaderText="Tanggal Mulai Menjabat">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalMulaiMenjabat" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTanggalMulaiMenjabatAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTanggalMulaiMenjabatEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Tanggal Akhir Menjabat">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalAkhirMenjabat" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTanggalAkhirMenjabatAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTanggalAkhirMenjabatEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
                <br />
                <b>Menjadi</b>
                <asp:DataGrid ID="dgShareholderMenjadi" runat="server" AutoGenerateColumns="false"
                    CssClass="table" ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNameAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNameEdit" runat="server" />
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
                        <asp:TemplateColumn HeaderText="Tanggal Mulai Menjabat">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalMulaiMenjabat" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTanggalMulaiMenjabatAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTanggalMulaiMenjabatEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Tanggal Akhir Menjabat">
                            <ItemTemplate>
                                <asp:Label ID="lblTanggalAkhirMenjabat" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTanggalAkhirMenjabatAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTanggalAkhirMenjabatEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgShareholderMenjadi"
                                    CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgShareholderMenjadi"
                                    CommandName="save">Save</asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <fieldset>
                <legend><b>Pemegang Saham</b></legend>
                <br />
                <b>Semula</b>
                <asp:DataGrid ID="dgPemegangSahamSemula" runat="server" AutoGenerateColumns="false"
                    CssClass="table" ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Nama Pemegang Saham">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNameAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNameEdit" runat="server" />
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
                    </Columns>
                </asp:DataGrid>
                <br />
                <b>Menjadi</b>
                <asp:DataGrid ID="dgPemegangSahamMenjadi" runat="server" AutoGenerateColumns="false"
                    CssClass="table" ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Nama Pemegang Saham">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNameAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNameEdit" runat="server" />
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
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgPemegangSahamMenjadi"
                                    CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgPemegangSahamMenjadi"
                                    CommandName="save">Save</asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <table border="0">
                <tr>
                    <td valign="top">
                        Remarks
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
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
        </fieldset>
        <br />
        <br />
        <fieldset>
            <legend><b>Perubahan Anggaran Dasar & Data Perseroan (<asp:Label ID="lblPerusahaanName"
                runat="server"></asp:Label>)</b></legend>
            <table width="100%" border="0">
                <tr>
                    <td colspan="5">
                        SK atau Penerimaan Pemberitahuan Tentang Perubahan Anggaran Dasar :
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        No:<br />
                        <asp:TextBox runat="server" ID="txtNo"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Dilaporkan Oleh :<br />
                        (full name,signature,date)
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Tanggal Mulai Berlaku:<br />
                        <SharePoint:DateTimeControl ID="DateTimeControl1" runat="server" DateOnly="true" />
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Keterangan:<br />
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="70px" Width="230px"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Corporate Secretary
                    </td>
                </tr>
                <tr>
                    <td>
                        BNRI<br />
                        (Lampiran Dokumen)
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        No:<br />
                        <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Tanggal Mulai Berlaku:<br />
                        <SharePoint:DateTimeControl ID="DateTimeControl2" runat="server" DateOnly="true" />
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Keterangan:<br />
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="70px" Width="230px"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        SKDP<br />
                        (Lampiran Dokumen)
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Dilaporkan Oleh :<br />
                        (full name,signature,date)
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        No:<br />
                        <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Tanggal Mulai Berlaku:<br />
                        <SharePoint:DateTimeControl ID="DateTimeControl3" runat="server" DateOnly="true" />
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Keterangan:<br />
                        <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Height="70px" Width="230px"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Corporate Secretary
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend>NPWP</legend>
            <asp:DataGrid ID="dgNPWP" runat="server" AutoGenerateColumns="false" CssClass="table"
                ShowFooter="true" Width="100%">
                <HeaderStyle CssClass="header" />
                <ItemStyle CssClass="odd" />
                <AlternatingItemStyle CssClass="white" />
                <Columns>
                    <asp:TemplateColumn HeaderText="No">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNoAdd" runat="server" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNoEdit" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Tanggal Berlaku">
                        <ItemTemplate>
                            <asp:Label ID="lblTanggalBerlaku" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTanggalBerlakuAdd" runat="server" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTanggalBerlakuEdit" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Keterangan">
                        <ItemTemplate>
                            <asp:Label ID="lblKeterangan" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtKeteranganAdd" runat="server" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtKeteranganEdit" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Dilaporkan Oleh">
                        <ItemTemplate>
                            <asp:Label ID="lblDilaporkanOleh" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtDilaporkanOlehAdd" runat="server" />
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDilaporkanOlehEdit" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgNPWP" CommandName="add">Add</asp:LinkButton>
                        </FooterTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgNPWP" CommandName="save">Save</asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
            <br />
            <table width="100%" border="0">
                <tr>
                    <td>
                        NPWP<br />
                        (Lampiran Dokumen)
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Dilaporkan Oleh :<br />
                        (full name,signature,date)
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        No:<br />
                        <asp:TextBox runat="server" ID="TextBox6"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Tanggal Mulai Berlaku:<br />
                        <SharePoint:DateTimeControl ID="DateTimeControl4" runat="server" DateOnly="true" />
                    </td>
                    <td width="5">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Keterangan:<br />
                        <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Height="70px" Width="230px"></asp:TextBox>
                    </td>
                    <td width="5">
                    </td>
                    <td>
                        Tax
                    </td>
                </tr>
                <table width="100%" border="0">
                    <tr>
                        <td>
                            SKT<br />
                            (Lampiran Dokumen)
                        </td>
                        <td width="5">
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server"></asp:Label>
                        </td>
                        <td width="5">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
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
