<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
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
                    Keterangan
                </td>
                <td valign="top">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtKeterangan" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
                    <asp:Literal ID="ltrKeterangan" runat="server" />
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
    <fieldset>
        <div style="text-align: right">
            <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" ValidationGroup="Save"
                OnClick="btnSaveUpdate_Click" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </fieldset>
</fieldset>
<fieldset runat="server" visible="false">
    <legend>
        <h3>
            <b>Company Data</b></h3>
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
                <asp:Literal ID="ltrDateDP" runat="server" />
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
                <asp:Literal ID="ltrRequestCodeDP" runat="server" />
            </td>
        </tr>
    </table>
    <br />
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
                Company's Name
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtCompanyNameDP" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Country of Establishment
            </td>
            <td>
                :
            </td>
            <td>
                <asp:Literal ID="ltrCountryEstablishment" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Registration Number
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtRegistrationNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Date of Establishment
            </td>
            <td>
                :
            </td>
            <td>
                <SharePoint:DateTimeControl ID="dtEstablishment" DateOnly="true" runat="server">
                </SharePoint:DateTimeControl>
            </td>
        </tr>
        <tr>
            <td>
                Activity
            </td>
            <td>
                :
            </td>
            <td>
                <asp:Literal ID="ltrActivity" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Activity Code
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtActivityCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                Ownership Status
            </td>
            <td valign="top">
                :
            </td>
            <td>
                <asp:Literal ID="ltrOwnershipStatusDP" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Type of Company
            </td>
            <td>
                :
            </td>
            <td>
                <asp:Literal ID="ltrTypeOfCompany" runat="server" />
            </td>
        </tr>
    </table>
    <fieldset>
        <legend><b>Capital Structure</b></legend>
        <table border="0">
            <tr>
                <td>
                    Rate
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlRateDP" runat="server" />
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
                    <asp:TextBox ID="txtModalDasar" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtModalDasar" Display="Dynamic" ValidationGroup="Save"
                        runat="server" ControlToValidate="txtModalDasar" ErrorMessage="Required Field" />
                </td>
                <td>
                    <asp:TextBox ID="txtNominalModalDasar" Enabled="false" runat="server" />
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
                    <asp:TextBox ID="txtModalSetor" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtModalSetor" Display="Dynamic" ValidationGroup="Save"
                        runat="server" ControlToValidate="txtModalSetor" ErrorMessage="Required Field" />
                </td>
                <td>
                    <asp:TextBox ID="txtNominalModalSetor" Enabled="false" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Nominal Saham <span style="color: Red">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNominalSaham" runat="server" />
                    <asp:RequiredFieldValidator ID="reqtxtNominalSaham" Display="Dynamic" ValidationGroup="Save"
                        runat="server" ControlToValidate="txtNominalSaham" ErrorMessage="Required Field" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><b>Shareholder</b></legend>
        <asp:DataGrid ID="dgShareholderDP" runat="server" AutoGenerateColumns="false" CssClass="table"
            ShowFooter="true" Width="100%">
            <HeaderStyle CssClass="header" />
            <ItemStyle CssClass="odd" />
            <AlternatingItemStyle CssClass="white" />
            <Columns>
                <asp:TemplateColumn HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Country of Establishment">
                    <ItemTemplate>
                        <asp:Label ID="lblCountryEstablishment" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Share">
                    <ItemTemplate>
                        <asp:Label ID="lblShare" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Nominal">
                    <ItemTemplate>
                        <asp:Label ID="lblNominal" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="%">
                    <ItemTemplate>
                        <asp:Label ID="lblPersen" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </fieldset>
    <fieldset>
        <legend><b>Officer</b></legend>
        <asp:DataGrid ID="dgOfficerDP" runat="server" AutoGenerateColumns="false" CssClass="table"
            ShowFooter="true" Width="100%">
            <HeaderStyle CssClass="header" />
            <ItemStyle CssClass="odd" />
            <AlternatingItemStyle CssClass="white" />
            <Columns>
                <asp:TemplateColumn HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Roles">
                    <ItemTemplate>
                        <asp:Label ID="lblRole" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Date of Appointment">
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Tanggal Akhir Menjabat">
                    <ItemTemplate>
                    </ItemTemplate>
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
                <asp:TextBox ID="txtRemarksDP" runat="server" Width="400px" Rows="5" TextMode="MultiLine" />
            </td>
        </tr>
        <tr>
            <td>
                Diupdate Oleh
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
                Dibuat Oleh
            </td>
            <td>
                :
            </td>
            <td>
                Accounting
            </td>
        </tr>
    </table>
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
