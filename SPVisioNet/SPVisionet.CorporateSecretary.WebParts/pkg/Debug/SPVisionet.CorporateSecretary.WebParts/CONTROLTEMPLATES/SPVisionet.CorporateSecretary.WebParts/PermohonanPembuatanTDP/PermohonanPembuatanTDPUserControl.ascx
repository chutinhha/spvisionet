<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermohonanPembuatanTDPUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PermohonanPembuatanTDP.PermohonanPembuatanTDPUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permohonan Pembuatan TDP</b></h3>
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
                    <td>
                        Alasan Pembuatan <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAlasanPembuatan" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAlasanPembuatan_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqddlAlasanPembuatan" ValidationGroup="Save" Display="Dynamic"
                            runat="server" ControlToValidate="ddlAlasanPembuatan" ErrorMessage="Required Field" />
                        <asp:Literal ID="ltrAlasanPembuatan" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <fieldset>
        <legend><b>Data Perusahaan</b></legend>
        <asp:UpdatePanel ID="upDataPerusahaan" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" width="100%">
                    <tr>
                        <td width="200px">
                            Kode Perusahaan <span style="color: Red">*</span>
                        </td>
                        <td width="3px">
                            :
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtKodePerusahaan" runat="server" Width="200px" Enabled="false" />
                                        <asp:RequiredFieldValidator ID="reqtxtKodePerusahaan" ValidationGroup="Save" Display="Dynamic"
                                            runat="server" ControlToValidate="txtKodePerusahaan" ErrorMessage="Required Field" />
                                        <asp:Literal ID="ltrKodePerusahaan" runat="server" />
                                    </td>
                                    <td align="right">
                                        <asp:Literal ID="ltrlinkDocument" runat="server" />
                                    </td>
                                </tr>
                            </table>
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
                            <asp:TextBox ID="txtNamaPerusahaan" runat="server" Width="250px" />
                            <asp:ImageButton ID="imgbtnNamaPerusahaan" ValidationGroup="popup" runat="server"
                                ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                                ToolTip="Search" OnClientClick="openDialog(event, 'Search Company', 'divPerusahaanSearch')"
                                CausesValidation="false" OnClick="imgbtnNamaPerusahaan_Click" />
                            <asp:RequiredFieldValidator ID="reqtxtNamaPerusahaan" ValidationGroup="Save" Display="Dynamic"
                                runat="server" ControlToValidate="txtNamaPerusahaan" ErrorMessage="Required Field" />
                            <asp:Literal ID="ltrNamaPerusahaan" runat="server" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
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
                        Corporate Secretary (<asp:Literal ID="ltrCS" runat="server" />)
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
                        Div Head (<asp:Literal ID="ltrDivHead" runat="server" />)
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <asp:Panel ID="pnlOriginator" runat="server" Visible="false">
        <fieldset>
            <legend><b>Laporan Pembuatan TDP</b></legend>
            <table border="0">
                <tr>
                    <td valign="top" width="250px">
                        TDP <span style="color: Red">*</span>
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
                                    <asp:TextBox ID="txtKeteranganTDP" runat="server" Width="350px" Rows="4" TextMode="MultiLine" />
                                    <asp:Literal ID="ltrKeteranganTDP" runat="server" />
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
<div id="divPerusahaanDlgContainer">
    <div id="divPerusahaanSearch" style="display: none">
        <asp:UpdatePanel ID="upPerusahaan" runat="server">
            <ContentTemplate>
                <table width="100%" border="0">
                    <tr>
                        <td>
                            <table cellpadding="0" border="0">
                                <tr>
                                    <td>
                                        Search :
                                        <asp:TextBox ID="txtSearch" runat="server" Width="200px" />
                                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    </td>
                                    <td>
                                        <asp:UpdateProgress ID="upProg" AssociatedUpdatePanelID="upPerusahaan" runat="server"
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
                            <asp:GridView ID="grv" runat="server" AutoGenerateColumns="false" CssClass="table"
                                Width="100%" EmptyDataText="No Data Available" DataSourceID="ods" AllowPaging="true"
                                PageSize="10" OnRowDataBound="grv_RowDataBound">
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
                                    <asp:BoundField DataField="CompanyCodeAPV" HeaderText="Kode Perusahaan" />
                                    <asp:BoundField DataField="NamaPerusahaan" HeaderText="Nama Perusahaan" />
                                    <asp:BoundField DataField="TempatKedudukan" HeaderText="Tempat Kedudukan" />
                                    <asp:BoundField DataField="MaksudTujuan" HeaderText="Maksud dan Tujuan" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ods" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
                                SelectMethod="GetItemDataTable" SelectCountMethod="ListItemCount" StartRowIndexParameterName="pageIndex"
                                TypeName="SPVisionet.CorporateSecretary.Common.Util">
                                <SelectParameters>
                                    <asp:Parameter Name="ListURL" Type="String" DefaultValue="" ConvertEmptyStringToNull="false" />
                                    <asp:Parameter Name="pageSize" Type="Int32" />
                                    <asp:Parameter Name="pageIndex" Type="Int32" />
                                    <asp:Parameter Name="strSortFieldName" Type="String" DefaultValue="NamaPerusahaan"
                                        ConvertEmptyStringToNull="false" />
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
                            <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" />
                            <asp:Button ID="btnCloseSearch" runat="server" Text="Close" OnClientClick="closeDialog('divPerusahaanSearch')" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
