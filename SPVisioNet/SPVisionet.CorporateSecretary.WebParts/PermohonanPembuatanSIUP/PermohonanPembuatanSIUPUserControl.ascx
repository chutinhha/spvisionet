<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermohonanPembuatanSIUPUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PermohonanPembuatanSIUP.PermohonanPembuatanSIUPUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permohonan Pembuatan SIUP</b></h3>
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
                Alasan Pembuatan
            </td>
            <td>
                :
            </td>
            <td>
                <asp:DropDownList ID="ddlAlasanPembuatan" runat="server">
                    <asp:ListItem Text="--Select--" Value="" />
                    <asp:ListItem Text="Baru" Value="Baru" />
                    <asp:ListItem Text="Perpanjang" Value="Perpanjang" />
                    <asp:ListItem Text="Hilang" Value="Hilang" />
                    <asp:ListItem Text="WDP" Value="WDP" />
                </asp:DropDownList>
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
                    <img src="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif" alt="Search" />
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
    </fieldset>
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
                    Div Head
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>Laporan Pembuatan SIUP</b></legend>
        <table border="0">
            <tr>
                <td valign="top" width="250px">
                    SIUP
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
                                <asp:TextBox ID="txtKeteranganSIUP" runat="server" Width="350px" Rows="4" TextMode="MultiLine" />
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
