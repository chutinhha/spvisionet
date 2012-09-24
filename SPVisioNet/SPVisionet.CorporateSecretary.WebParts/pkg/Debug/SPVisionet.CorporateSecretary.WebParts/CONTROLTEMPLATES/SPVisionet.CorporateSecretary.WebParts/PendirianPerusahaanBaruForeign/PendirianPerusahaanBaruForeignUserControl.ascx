<%@ Assembly Name="SPVisionet.CorporateSecretary.WebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a5ab65cbe4901d02" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendirianPerusahaanBaruForeignUserControl.ascx.cs"
    Inherits="SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruForeign.PendirianPerusahaanBaruForeignUserControl" %>
<fieldset>
    <legend>
        <h3>
            <b>Permohonan Pendirian Perusahaan (Foreign)</b></h3>
    </legend>
    <br />
    <div style="text-align: right">
        <span style="color: Red">*</span> indicates a required field</div>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
                        <asp:Literal ID="ltrRequestCode" runat="server" Text="Auto Generate" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Project <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtProject" runat="server" Width="350px" />
                        <asp:RequiredFieldValidator ID="reqtxtProject" ValidationGroup="Save" Display="Dynamic"
                            runat="server" ControlToValidate="txtProject" ErrorMessage="Required Field" />
                        <asp:Literal ID="ltrProject" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Requestor <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:HiddenField ID="hfIDRequestor" runat="server" />
                        <asp:TextBox ID="txtRequestor" runat="server" Enabled="false" Width="250px" />
                        <asp:ImageButton ID="imgbtnNamaPemohon" ValidationGroup="popup" runat="server" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
                            ToolTip="Search" OnClientClick="openDialog(event, 'Search Requestor', 'divPemohonSearch')"
                            CausesValidation="false" OnClick="imgbtnNamaPemohon_Click" />
                        <asp:RequiredFieldValidator ID="reqtxtRequestor" ValidationGroup="Save" Display="Dynamic"
                            runat="server" ControlToValidate="txtRequestor" ErrorMessage="Required Field" />
                        <asp:Literal ID="ltrRequestor" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Requestor Email <span style="color: Red">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRequestorEmail" runat="server" Enabled="false" Width="250px" />
                        <asp:RequiredFieldValidator ID="reqtxtRequestorEmail" ValidationGroup="Save" Display="Dynamic"
                            runat="server" ControlToValidate="txtRequestorEmail" ErrorMessage="Required Field" />
                        <asp:Literal ID="ltrRequestorEmail" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <fieldset>
        <legend><b>Company's Data</b></legend>
        <table border="0">
            <tr>
                <td>
                    Company's Name <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyName" runat="server" Width="350px" />
                    <asp:RequiredFieldValidator ID="reqtxtCompanyName" ValidationGroup="Save" Display="Dynamic"
                        runat="server" ControlToValidate="txtCompanyName" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrCompanyName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Country of Establishment <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtCountryEst" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtCountryEst" ValidationGroup="Save" Display="Dynamic"
                        runat="server" ControlToValidate="txtCountryEst" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrCountryEst" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Activities <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtActivities" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtActivities" ValidationGroup="Save" Display="Dynamic"
                        runat="server" ControlToValidate="txtActivities" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrActivities" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>Capital Structure</b></legend>
        <table>
            <tr>
                <td>
                    Authorized Capital <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtAuthorizedCapital" runat="server" CssClass="textRight" />
                    <asp:RequiredFieldValidator ID="reqtxtAuthorizedCapital" ValidationGroup="Save" Display="Dynamic"
                        runat="server" ControlToValidate="txtAuthorizedCapital" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrAuthorizedCapital" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Paid Up Capital <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtPaidUpCapital" runat="server" CssClass="textRight" />
                    <asp:RequiredFieldValidator ID="reqtxtPaidUpCapital" ValidationGroup="Save" Display="Dynamic"
                        runat="server" ControlToValidate="txtPaidUpCapital" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrPaidUpCapital" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Par Value <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtParValue" runat="server" CssClass="textRight" />
                    <asp:RequiredFieldValidator ID="reqtxtParValue" ValidationGroup="Save" Display="Dynamic"
                        runat="server" ControlToValidate="txtParValue" ErrorMessage="Required Field" />
                    <asp:Literal ID="ltrParValue" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>Shareholder</b></legend>
        <br />
        <asp:UpdatePanel ID="upShareholder" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataGrid ID="dgShareholder" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%" OnItemCommand="dgShareholder_ItemCommand">
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
                        <asp:TemplateColumn HeaderText="Name" ItemStyle-VerticalAlign="Top" FooterStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNameAdd" runat="server" Text='<%# Eval("Name") %>' Width="250px" />
                                <asp:RequiredFieldValidator ID="reqtxtNameAdd" runat="server" ControlToValidate="txtNameAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgShareholder" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNameEdit" runat="server" Text='<%# Eval("Name") %>' Width="250px" />
                                <asp:RequiredFieldValidator ID="reqtxtNameEdit" runat="server" ControlToValidate="txtNameEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgShareholder" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtAddressAdd" runat="server" Text='<%# Eval("Address") %>' Width="300px"
                                    TextMode="MultiLine" Rows="3" />
                                <asp:RequiredFieldValidator ID="reqtxtAddressAdd" runat="server" ControlToValidate="txtAddressAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgShareholder" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAddressEdit" runat="server" Text='<%# Eval("Address") %>' Width="300px"
                                    TextMode="MultiLine" Rows="3" />
                                <asp:RequiredFieldValidator ID="reqtxtAddressEdit" runat="server" ControlToValidate="txtAddressEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgShareholder" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Country of Establishment" ItemStyle-VerticalAlign="Top"
                            FooterStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label ID="lblCountryEstablishment" runat="server" Text='<%# Eval("Country") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtCountryEstablishmentAdd" runat="server" Text='<%# Eval("Country") %>'
                                    Width="250px" />
                                <asp:RequiredFieldValidator ID="reqtxtCountryEstablishmentAdd" runat="server" ControlToValidate="txtCountryEstablishmentAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgShareholder" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCountryEstablishmentEdit" runat="server" Text='<%# Eval("Country") %>'
                                    Width="250px" />
                                <asp:RequiredFieldValidator ID="reqtxtCountryEstablishmentEdit" runat="server" ControlToValidate="txtCountryEstablishmentEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgShareholder" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgShareholder" CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgShareholder" CommandName="save">Save</asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid></ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <fieldset>
        <legend><b>Officer</b></legend>
        <br />
        <asp:UpdatePanel ID="upOfficer" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataGrid ID="dgOfficer" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%" OnItemCommand="dgOfficer_ItemCommand" OnItemDataBound="dgOfficer_ItemDataBound">
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
                        <asp:TemplateColumn HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNameAdd" runat="server" Width="350px" />
                                <asp:RequiredFieldValidator ID="reqtxtNameAdd" runat="server" ControlToValidate="txtNameAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgOfficer" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNameEdit" runat="server" Text='<%# Eval("Name") %>' Width="350px" />
                                <asp:RequiredFieldValidator ID="reqtxtNameEdit" runat="server" ControlToValidate="txtNameEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgOfficer" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Role">
                            <ItemTemplate>
                                <asp:Label ID="lblRoleID" runat="server" Text='<%# Eval("RoleID") %>' Visible="false" />
                                <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddRoleAdd" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="reqddRoleAdd" runat="server" ControlToValidate="ddRoleAdd"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgOfficer" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRoleEdit" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="reqddlRoleEdit" runat="server" ControlToValidate="ddlRoleEdit"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Required Field" ValidationGroup="dgOfficer" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgOfficer" CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgOfficer" CommandName="save">Save</asp:LinkButton>
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
                    Note
                </td>
                <td valign="top">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKeterangan" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
                    <asp:Literal ID="ltrKeterangan" runat="server" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:Panel ID="pnlPICCorsec" runat="server" Visible="false">
        <fieldset>
            <legend><b>M&A</b> <span style="color: Red">*</span></legend>
            <table border="0">
                <tr>
                    <td valign="top" width="335px">
                        <br />
                        <b>Note:
                            <br />
                            The file name should be [ORI]xxxxx / [Soft]xxxxx</b>
                        <br />
                        <br />
                        <asp:Literal ID="ltrfuMA" runat="server" />
                        <br />
                        <br />
                        <asp:FileUpload ID="fuMA" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ID="reqfuMA" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="fuMA" ErrorMessage="Required Field" />
                    </td>
                    <td>
                        <table border="0">
                            <tr>
                                <td width="190px">
                                    No <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNoMA" runat="server" />
                                    <asp:RequiredFieldValidator ID="reqtxtNoMA" Display="Dynamic" ValidationGroup="Save"
                                        runat="server" ControlToValidate="txtNoMA" ErrorMessage="Required Field" />
                                    <asp:Literal ID="ltrNoMA" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date of Entry <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalMulaiBerlakuMA" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                                <asp:Literal ID="ltrTanggalMulaiBerlakuMA" runat="server" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiBerlakuMA" ValidationGroup="Save"
                                                    runat="server" ControlToValidate="dtTanggalMulaiBerlakuMA$dtTanggalMulaiBerlakuMADate"
                                                    ErrorMessage="Required Field" Display="Dynamic" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Note
                                </td>
                                <td valign="top">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKeteranganMA" runat="server" Width="350px" Rows="4" TextMode="MultiLine" />
                                    <asp:Literal ID="ltrKeteranganMA" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend><b>Certification of Incorporation</b> <span style="color: Red">*</span></legend>
            <table border="0">
                <tr>
                    <td valign="top" width="335px">
                        <br />
                        <b>Note:
                            <br />
                            The file name should be [ORI]xxxxx / [Soft]xxxxx</b>
                        <br />
                        <br />
                        <asp:Literal ID="ltrfuCI" runat="server" />
                        <br />
                        <br />
                        <asp:FileUpload ID="fuCI" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ID="reqfuCI" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="fuCI" ErrorMessage="Required Field" />
                    </td>
                    <td>
                        <table border="0">
                            <tr>
                                <td width="190px">
                                    Company Registration Number <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNoCI" runat="server" />
                                    <asp:RequiredFieldValidator ID="reqtxtNoCI" Display="Dynamic" ValidationGroup="Save"
                                        runat="server" ControlToValidate="txtNoCI" ErrorMessage="Required Field" />
                                    <asp:Literal ID="ltrNoCI" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date of Entry <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalMulaiBerlakuCI" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                                <asp:Literal ID="ltrTanggalMulaiBerlakuCI" runat="server" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiBerlakuCI" ValidationGroup="Save"
                                                    runat="server" ControlToValidate="dtTanggalMulaiBerlakuCI$dtTanggalMulaiBerlakuCIDate"
                                                    ErrorMessage="Required Field" Display="Dynamic" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Note
                                </td>
                                <td valign="top">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKeteranganCI" runat="server" Width="350px" Rows="4" TextMode="MultiLine" />
                                    <asp:Literal ID="ltrKeteranganCI" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend><b>Business Profile</b> <span style="color: Red">*</span></legend>
            <table border="0">
                <tr>
                    <td valign="top" width="335px">
                        <br />
                        <b>Note:
                            <br />
                            The file name should be [ORI]xxxxx / [Soft]xxxxx</b>
                        <br />
                        <br />
                        <asp:Literal ID="ltrfuBP" runat="server" />
                        <br />
                        <br />
                        <asp:FileUpload ID="fuBP" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ID="reqfuBP" Display="Dynamic" ValidationGroup="Save"
                            runat="server" ControlToValidate="fuBP" ErrorMessage="Required Field" />
                    </td>
                    <td>
                        <table border="0">
                            <tr>
                                <td width="190px">
                                    No <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNoBP" runat="server" />
                                    <asp:RequiredFieldValidator ID="reqtxtNoBP" Display="Dynamic" ValidationGroup="Save"
                                        runat="server" ControlToValidate="txtNoBP" ErrorMessage="Required Field" />
                                    <asp:Literal ID="ltrNoBP" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date of Entry <span style="color: Red">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <SharePoint:DateTimeControl ID="dtTanggalMulaiBerlakuBP" DateOnly="true" runat="server">
                                                </SharePoint:DateTimeControl>
                                                <asp:Literal ID="ltrTanggalMulaiBerlakuBP" runat="server" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="reqdtTanggalMulaiBerlakuBP" ValidationGroup="Save"
                                                    runat="server" ControlToValidate="dtTanggalMulaiBerlakuBP$dtTanggalMulaiBerlakuBPDate"
                                                    ErrorMessage="Required Field" Display="Dynamic" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Note
                                </td>
                                <td valign="top">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKeteranganBP" runat="server" Width="350px" Rows="4" TextMode="MultiLine" />
                                    <asp:Literal ID="ltrKeteranganBP" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <asp:Panel ID="pnlAssigned" runat="server" Visible="false">
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
                        Div Head Corporate Secretary & Chief
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
        <div style="text-align: right">
            <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" ValidationGroup="Save"
                OnClick="btnSaveUpdate_Click" />&nbsp;
            <asp:Button ID="btnSaveUpdateRunWf" runat="server" Text="Save & Run Workflow" ValidationGroup="Save"
                OnClick="btnSaveUpdateRunWf_Click" Width="160px" />&nbsp;
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
                                <asp:Button ID="btnCloseSearchPemohon" runat="server" Text="Close" OnClientClick="closeDialog('divPemohonSearch')"
                                    OnClick="btnCloseSearchPemohon_Click" />
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
