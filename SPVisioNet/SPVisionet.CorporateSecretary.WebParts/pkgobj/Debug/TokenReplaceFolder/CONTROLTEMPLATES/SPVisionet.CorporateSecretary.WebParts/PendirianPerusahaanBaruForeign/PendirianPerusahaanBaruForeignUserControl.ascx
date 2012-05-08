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
<asp:UpdatePanel ID="upMain" runat="server">
    <ContentTemplate>
        <fieldset>
            <legend>
                <h3>
                    <b>Requisition for New Company (Foreign)</b></h3>
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
                        Project
                    </td>
                    <td valign="top">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtProject" runat="server" />
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
                        <asp:ImageButton ID="imgbtntxtRequestor" runat="server" ValidationGroup="popup" ImageUrl="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif"
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
                        <img src="/_layouts/images/SPVisionet.CorporateSecretary.WebParts/popup.gif" alt="Search" />
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend><b>Company's Data</b></legend>
                <table border="0">
                    <tr>
                        <td>
                            Company Name
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
                            Country of establishment
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCountryEstablishment" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Activities
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlActivities" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status Ownership
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatusOwnership" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>Capital Structure</b></legend>
                <table>
                    <tr>
                        <td>
                            Rate
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Authorized Capital
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtAuthorizedCapital" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Paid up Capital
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtPaidUpCapital" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Par Value
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtParValue" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend><b>Shareholder</b></legend>
                <asp:DataGrid ID="dgShareholder" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <%--<asp:TemplateColumn HeaderText="CityID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCityID" runat="server" Text='<%# Eval("City") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblCityEdit" runat="server" Text='<%# Eval("City") %>' />
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
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
                        <asp:TemplateColumn HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtIDAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtIDEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtAddressAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAddressEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Country of Establishment">
                            <ItemTemplate>
                                <asp:Label ID="lblCountryEstablishment" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtCountryEstablishmentAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCountryEstablishmentEdit" runat="server" />
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
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgShareholder" CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgShareholder" CommandName="save">Save</asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" CausesValidation="False" CommandName="cancel" runat="server">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <fieldset>
                <legend><b>Commissioners and Directors</b></legend>
                <asp:DataGrid ID="dgCommissioners" runat="server" AutoGenerateColumns="false" CssClass="table"
                    ShowFooter="true" Width="100%">
                    <HeaderStyle CssClass="header" />
                    <ItemStyle CssClass="odd" />
                    <AlternatingItemStyle CssClass="white" />
                    <Columns>
                        <%--<asp:TemplateColumn HeaderText="CityID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCityID" runat="server" Text='<%# Eval("City") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblCityEdit" runat="server" Text='<%# Eval("City") %>' />
                    </EditItemTemplate>
                </asp:TemplateColumn>--%>
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
                        <asp:TemplateColumn HeaderText="Roles">
                            <ItemTemplate>
                                <asp:Label ID="lblRole" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtRoleAdd" runat="server" />
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRoleEdit" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="edit">Edit</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" ValidationGroup="dgCommissioners" CommandName="add">Add</asp:LinkButton>
                            </FooterTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="dgCommissioners" CommandName="save">Save</asp:LinkButton>
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
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
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
                        Company Name
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
                    <tr>
                        <td>
                            Issued Share (nominal)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrIssuedShareDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Issued Share (jumlah saham)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrIssuedShareJumlahSahamDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Paid up Share (nominal)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrPaidUpShareDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Paid up Share (jumlah saham)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrPaidUpShareJumlahSahamDP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Share (Rp/Saham)
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Literal ID="ltrShareDP" runat="server" />
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
                        <asp:TemplateColumn HeaderText="Nominal">
                            <ItemTemplate>
                                <asp:Label ID="lblNominal" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Percentages">
                            <ItemTemplate>
                                <asp:Label ID="lblPercentages" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Partner">
                            <ItemTemplate>
                                <asp:Label ID="lblPartner" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </fieldset>
            <fieldset>
                <legend><b>Officer</b></legend>
                <asp:DataGrid ID="dgOfficer" runat="server" AutoGenerateColumns="false" CssClass="table"
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
                        <asp:TemplateColumn HeaderText="Start Date">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="End Date">
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
