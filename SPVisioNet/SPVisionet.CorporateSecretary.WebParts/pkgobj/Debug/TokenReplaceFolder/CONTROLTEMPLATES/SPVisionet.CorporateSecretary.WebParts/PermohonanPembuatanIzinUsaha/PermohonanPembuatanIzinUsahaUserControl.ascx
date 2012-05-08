<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermohonanPembuatanIzinUsahaUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PermohonanPembuatanIzinUsaha.PermohonanPembuatanIzinUsahaUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permohonan Pembuatan Izin Usaha</b></h3>
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
    </table>
    <br />
    <fieldset>
        <legend><b>Data Perusahaan</b></legend>
        <table border="0">
            <tr>
                <td>
                    Kode Perusahaan<span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKodePerusahaan" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtKodePerusahaan" Display="Dynamic" runat="server"
                        ControlToValidate="txtKodePerusahaan" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrKodePerusahaan" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Nama Perusahaan<span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNamaPerusahaan" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtNamaPerusahaan" Display="Dynamic" runat="server"
                        ControlToValidate="txtNamaPerusahaan" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrNamaPerusahaan" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Tempat Kedudukan<span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtTempatKedudukan" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtTempatKedudukan" Display="Dynamic" runat="server"
                        ControlToValidate="txtTempatKedudukan" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrTempatKedudukan" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Klasifikasi Lapangan Usaha<span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKlasifikasi" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtKlasifikasi" Display="Dynamic" runat="server"
                        ControlToValidate="txtKlasifikasi" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrKlasifikasi" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Status Perseroan<span style="color: Red">*</span>
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
                    <asp:RequiredFieldValidator ID="reqddlStatusPerseroan" Display="Dynamic" runat="server"
                        ControlToValidate="ddlStatusPerseroan" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrStatusPerseroan" runat="server" />
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
    <fieldset>
        <legend><b>Laporan Pembuatan Izin Usaha [
            <asp:Literal ID="ltrNamaPerusahaanIzinUsaha" runat="server" />
            ]</b></legend>
        <table border="0">
            <tr>
                <td valign="top" width="250px">
                    Izin Usaha<span style="color: Red">*</span>
                    <br />
                    <br />
                    <asp:Panel ID="pnlfuFile" runat="server" Visible="false">
                        <asp:Literal ID="ltrfu" runat="server" />
                        <asp:LinkButton ID="lbDelete" runat="server" Text="Delete" ValidationGroup="none"
                            OnClick="lbDelete_Click"></asp:LinkButton></asp:Panel>
                    <asp:Panel ID="pnlfu" runat="server">
                        <asp:FileUpload ID="fu" runat="server" />
                        <asp:RequiredFieldValidator ID="reqfu" Display="Dynamic" runat="server" ControlToValidate="fu"
                            ErrorMessage="Required Field" />
                    </asp:Panel>
                </td>
                <td>
                    <table border="0">
                        <tr>
                            <td width="150px">
                                No<span style="color: Red">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtNo" runat="server" />
                                <asp:RequiredFieldValidator ID="reqtxtNo" Display="Dynamic" runat="server" ControlToValidate="txtNo"
                                    ErrorMessage="Required Field" />
                                <asp:Literal ID="ltrNo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tanggal Mulai Berlaku<span style="color: Red">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <SharePoint:DateTimeControl ID="dtTanggalMulaiBerlaku" DateOnly="true" runat="server"
                                    IsRequiredField="true" ErrorMessage="Required Field"></SharePoint:DateTimeControl>
                                <asp:Literal ID="ltrTanggalMulaiBerlaku" runat="server" />
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
                                <asp:TextBox ID="txtKeteranganIzinUsaha" runat="server" Width="350px" Rows="4" TextMode="MultiLine" />
                                <asp:Literal ID="ltrKeteranganIzinUsaha" runat="server" />
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
            <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" OnClick="btnSaveUpdate_Click" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" ValidationGroup="Cancel" Text="Cancel"
                OnClick="btnCancel_Click" />
        </div>
    </fieldset>
</fieldset>
