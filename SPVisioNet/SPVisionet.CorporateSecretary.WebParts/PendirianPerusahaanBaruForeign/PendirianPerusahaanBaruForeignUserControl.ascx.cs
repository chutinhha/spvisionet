using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data;
using System.Text;

using SPVisionet.CorporateSecretary.Common;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruForeign
{
    public partial class PendirianPerusahaanBaruForeignUserControl : UserControl
    {
        #region Properties

        private SPWeb web;
        private int IDP = 0;
        private string Source = string.Empty;

        [Serializable]
        private class Shareholder
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Country { get; set; }
        }

        [Serializable]
        private class Officer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public int RoleID { get; set; }
        }

        #endregion

        #region Methods

        private void BindRole(DropDownList ddl)
        {
            DataTable dt = Util.GetRoles(web);
            ddl.DataSource = dt;
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (txtProject.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Project") + " \\n");
            if (txtRequestor.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Requestor") + " \\n");
            if (txtRequestorEmail.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Requestor Email") + " \\n");
            if (txtCompanyName.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Company Name") + " \\n");
            if (txtCountryEst.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Country of Establishment") + " \\n");
            if (txtActivities.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Activities") + " \\n");
            if (txtAuthorizedCapital.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Authorized Capital") + " \\n");
            else
            {
                try
                {
                    Convert.ToDecimal(txtAuthorizedCapital.Text.Trim());
                }
                catch
                {
                    sb.Append(SR.IntegerData("Authorized Capital") + " \\n");
                }
            }
            if (txtPaidUpCapital.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Paid Up Capital") + " \\n");
            else
            {
                try
                {
                    Convert.ToDecimal(txtPaidUpCapital.Text.Trim());
                }
                catch
                {
                    sb.Append(SR.IntegerData("Paid Up Capital") + " \\n");
                }
            }
            if (txtParValue.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Par value") + " \\n");
            else
            {
                try
                {
                    Convert.ToDecimal(txtParValue.Text.Trim());
                }
                catch
                {
                    sb.Append(SR.IntegerData("Par Value") + " \\n");
                }
            }
            if (dgShareholder.Items.Count == 0)
                sb.Append("At least one data must be inserted in Shareholder Grid");
            if (dgOfficer.Items.Count == 0)
                sb.Append("At least one data must be inserted in Officer Grid");

            return sb.ToString();
        }

        private void Display(string mode)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendirianPerusahaanBaruForeign"));
            SPListItem item = list.GetItemById(IDP);

            if (mode == "edit")
            {
                btnSaveUpdate.Text = "Update";

                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Date"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                txtProject.Text = item["Project"].ToString();

                if (item["Requestor"] != null)
                {
                    int IDPemohon = Convert.ToInt32(item["Requestor"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    hfIDRequestor.Value = IDPemohon.ToString();
                    SPList listPemohon = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
                    SPListItem itemPemohon = listPemohon.GetItemById(IDPemohon);
                    txtRequestor.Text = itemPemohon.Title;
                    txtRequestorEmail.Text = itemPemohon["EmailPemohon"].ToString();
                }

                txtCompanyName.Text = item["CompanyName"].ToString();
                txtCountryEst.Text = item["CountryOfEstablishment"].ToString();
                txtActivities.Text = item["Activities"].ToString();
                txtAuthorizedCapital.Text = item["AuthorizeCapital"].ToString();
                txtPaidUpCapital.Text = item["PaidUpCapital"].ToString();
                txtParValue.Text = item["ParValue"].ToString();

                txtKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
            }
            else if (mode == "display")
            {
                btnSaveUpdate.Visible = false;

                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Date"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                ltrProject.Text = item["Project"].ToString();

                if (item["Requestor"] != null)
                {
                    int IDPemohon = Convert.ToInt32(item["Requestor"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    hfIDRequestor.Value = IDPemohon.ToString();
                    SPList listPemohon = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
                    SPListItem itemPemohon = listPemohon.GetItemById(IDPemohon);
                    ltrRequestor.Text = itemPemohon.Title;
                    ltrRequestorEmail.Text = itemPemohon["EmailPemohon"].ToString();
                }

                ltrCompanyName.Text = item["CompanyName"].ToString();
                ltrCountryEst.Text = item["CountryOfEstablishment"].ToString();
                ltrActivities.Text = item["Activities"].ToString();
                ltrAuthorizedCapital.Text = item["AuthorizeCapital"].ToString();
                ltrPaidUpCapital.Text = item["PaidUpCapital"].ToString();
                ltrParValue.Text = item["ParValue"].ToString();

                ltrKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
            }

            SPList shareholder = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Shareholder"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PendirianPerusahaanBaruForeign' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + IDP + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";
            SPListItemCollection coll = shareholder.GetItems(query);

            List<Shareholder> collShareholder = new List<Shareholder>();
            foreach (SPListItem i in coll)
            {
                Shareholder o = new Shareholder();
                o.ID = i.ID;
                o.Address = i["Address"].ToString();
                o.Country = i["CountryOfEstablishment"].ToString();
                o.Name = i.Title;
                collShareholder.Add(o);
            }
            ViewState["Shareholder"] = collShareholder;
            ViewState["ShareholderEdit"] = collShareholder;
            BindShareholder();

            SPList officer = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Officer"));
            coll = officer.GetItems(query);

            List<Officer> collOfficer = new List<Officer>();
            foreach (SPListItem i in coll)
            {
                Officer o = new Officer();
                o.ID = i.ID;
                o.Name = i.Title;
                if (i["Roles"] != null)
                {
                    o.Role = i["Roles"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    o.RoleID = Convert.ToInt32(i["Roles"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                }
                collOfficer.Add(o);
            }
            ViewState["Officer"] = collOfficer;
            ViewState["OfficerEdit"] = collOfficer;
            BindOfficer();

            HiddenControls(mode);
        }

        private void HiddenControls(string mode)
        {
            if (mode == "display")
            {
                txtProject.Visible = false;
                txtRequestor.Visible = false;
                txtRequestorEmail.Visible = false;
                txtCompanyName.Visible = false;
                txtCountryEst.Visible = false;
                txtActivities.Visible = false;
                txtAuthorizedCapital.Visible = false;
                txtPaidUpCapital.Visible = false;
                txtParValue.Visible = false;
                txtKeterangan.Visible = false;
                imgbtnNamaPemohon.Visible = false;

                dgShareholder.ShowFooter = false;
                dgShareholder.Columns[4].Visible = false;

                dgOfficer.ShowFooter = false;
                dgOfficer.Columns[3].Visible = false;
            }
            else if (mode == "edit")
            {
            }
        }

        private string SaveUpdate()
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendirianPerusahaanBaruForeign"));
            SPList listShareholder = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Shareholder"));
            SPList listOfficer = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Officer"));

            web.AllowUnsafeUpdates = true;
            SPListItem item;

            try
            {
                if (IDP == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_FOREIGN, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(IDP);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                item["Date"] = Convert.ToDateTime(ltrDate.Text);
                item["Requestor"] = hfIDRequestor.Value;
                item["Activities"] = txtActivities.Text.Trim();
                item["AuthorizeCapital"] = txtAuthorizedCapital.Text.Trim();
                item["CompanyName"] = txtCompanyName.Text.Trim();
                item["CountryOfEstablishment"] = txtCountryEst.Text.Trim();
                item["Keterangan"] = txtKeterangan.Text.Trim();
                item["PaidUpCapital"] = txtPaidUpCapital.Text.Trim();
                item["ParValue"] = txtParValue.Text.Trim();
                item["Project"] = txtProject.Text.Trim();
                item.Update();

                ViewState["ID"] = item.ID;

                if (IDP == 0)
                {
                    List<Shareholder> collShareholder = ViewState["Shareholder"] as List<Shareholder>;
                    foreach (Shareholder i in collShareholder)
                    {
                        SPListItem itemShareholder = listShareholder.Items.Add();
                        itemShareholder["PendirianPerusahaanBaruForeign"] = ViewState["ID"].ToString();
                        itemShareholder["Title"] = i.Name;
                        itemShareholder["Address"] = i.Address;
                        itemShareholder["CountryOfEstablishment"] = i.Country;
                        itemShareholder["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemShareholder.Update();
                    }

                    List<Officer> collOfficer = ViewState["Officer"] as List<Officer>;
                    foreach (Officer i in collOfficer)
                    {
                        SPListItem itemOfficer = listOfficer.Items.Add();
                        itemOfficer["PendirianPerusahaanBaruForeign"] = ViewState["ID"].ToString();
                        itemOfficer["Title"] = i.Name;
                        itemOfficer["Roles"] = i.RoleID;
                        itemOfficer["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemOfficer.Update();
                    }
                }
                else
                {
                    if (dgShareholder.Items.Count > 0)
                    {
                        foreach (DataGridItem dgItem in dgShareholder.Items)
                        {
                            Label lblID = dgItem.FindControl("lblID") as Label;
                            Label lblName = dgItem.FindControl("lblName") as Label;
                            Label lblAddress = dgItem.FindControl("lblAddress") as Label;
                            Label lblCountryEstablishment = dgItem.FindControl("lblCountryEstablishment") as Label;

                            SPListItem itemShareholder;
                            if (Convert.ToInt32(lblID.Text) != 0)
                            {
                                itemShareholder = listShareholder.GetItemById(Convert.ToInt32(lblID.Text));
                                itemShareholder["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemShareholder = listShareholder.Items.Add();
                                itemShareholder["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemShareholder["PendirianPerusahaanBaruForeign"] = ViewState["ID"].ToString();
                            itemShareholder["Title"] = lblName.Text;
                            itemShareholder["Address"] = lblAddress.Text;
                            itemShareholder["CountryOfEstablishment"] = lblCountryEstablishment.Text;
                            itemShareholder.Update();
                        }
                    }

                    if (ViewState["ShareholderEdit"] != null)
                    {
                        List<Shareholder> collShareholderEdit = ViewState["ShareholderEdit"] as List<Shareholder>;
                        foreach (Shareholder itemEdit in collShareholderEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgShareholder.Items)
                            {
                                Label lblID = dgItem.FindControl("lblID") as Label;
                                if (Convert.ToInt32(lblID.Text) == itemEdit.ID)
                                {
                                    isExist = true;
                                    break;
                                }
                            }
                            if (!isExist)
                            {
                                SPListItem itemShareholder = listShareholder.GetItemById(itemEdit.ID);
                                if (itemShareholder != null)
                                    itemShareholder.Delete();
                            }
                        }
                    }

                    if (dgOfficer.Items.Count > 0)
                    {
                        foreach (DataGridItem dgItem in dgOfficer.Items)
                        {
                            Label lblID = dgItem.FindControl("lblID") as Label;
                            Label lblName = dgItem.FindControl("lblName") as Label;
                            Label lblRoleID = dgItem.FindControl("lblRoleID") as Label;

                            SPListItem itemOfficer;
                            if (Convert.ToInt32(lblID.Text) != 0)
                            {
                                itemOfficer = listOfficer.GetItemById(Convert.ToInt32(lblID.Text));
                                itemOfficer["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemOfficer = listOfficer.Items.Add();
                                itemOfficer["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemOfficer["PendirianPerusahaanBaruForeign"] = ViewState["ID"].ToString();
                            itemOfficer["Title"] = lblName.Text;
                            itemOfficer["Roles"] = lblRoleID.Text;
                            itemOfficer.Update();
                        }
                    }

                    if (ViewState["OfficerEdit"] != null)
                    {
                        List<Officer> collOfficerEdit = ViewState["OfficerEdit"] as List<Officer>;
                        foreach (Officer itemEdit in collOfficerEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgOfficer.Items)
                            {
                                Label lblID = dgItem.FindControl("lblID") as Label;
                                if (Convert.ToInt32(lblID.Text) == itemEdit.ID)
                                {
                                    isExist = true;
                                    break;
                                }
                            }
                            if (!isExist)
                            {
                                SPListItem itemOfficer = listOfficer.GetItemById(itemEdit.ID);
                                if (itemOfficer != null)
                                    itemOfficer.Delete();
                            }
                        }
                    }
                }

                web.AllowUnsafeUpdates = false;
            }
            catch
            {
                if (IDP == 0)
                    return SR.SaveFail;
                else
                    return SR.UpdateFail;
            }
            return string.Empty;
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            Util.RegisterStartupScript(Page, "Pemohon", "RegisterDialog('divPemohonSearch','divPemohonDlgContainer', '480');");

            using (SPSite site = new SPSite(SPContext.Current.Site.Url, SPContext.Current.Site.SystemAccount.UserToken))
            {
                using (web = site.OpenWeb())
                {
                    bool isID = false;
                    if (ViewState["ID"] == null)
                    {
                        if (Request.QueryString["ID"] != null)
                            isID = int.TryParse(Request.QueryString["ID"], out IDP);
                    }
                    else
                        IDP = Convert.ToInt32(ViewState["ID"]);

                    string mode = Request.QueryString["mode"] == null ? string.Empty : Request.QueryString["mode"].ToString();
                    Source = Request.QueryString["Source"] == null ? string.Empty : Request.QueryString["Source"].ToString();

                    if (!IsPostBack)
                    {
                        txtAuthorizedCapital.Attributes.Add("onkeyup", "FormatNumber('" + txtAuthorizedCapital.ClientID + "');");
                        txtAuthorizedCapital.Attributes.Add("onblur", "FormatNumber('" + txtAuthorizedCapital.ClientID + "')");

                        txtPaidUpCapital.Attributes.Add("onkeyup", "FormatNumber('" + txtPaidUpCapital.ClientID + "');");
                        txtPaidUpCapital.Attributes.Add("onblur", "FormatNumber('" + txtPaidUpCapital.ClientID + "')");

                        txtParValue.Attributes.Add("onkeyup", "FormatNumber('" + txtParValue.ClientID + "');");
                        txtParValue.Attributes.Add("onblur", "FormatNumber('" + txtParValue.ClientID + "')");

                        ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                        if (isID)
                            Display(mode);
                        else
                        {
                            BindShareholder();
                            BindOfficer();
                        }
                    }
                }
            }
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            string msg = Validation();
            if (msg != string.Empty)
            {
                Util.ShowMessage(Page, msg);
                return;
            }
            string result = SaveUpdate();
            if (result == string.Empty)
            {
                if (Source != string.Empty)
                    SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
                else
                    Response.Redirect("/Lists/PendirianPerusahaanBaruForeign", true);
            }
            else
                Util.ShowMessage(Page, result);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect("/Lists/PendirianPerusahaanBaruForeign", true);
        }

        #region Shareholder

        private bool isExistInShareholderGrid(string Nama)
        {
            foreach (DataGridItem item in dgShareholder.Items)
            {
                Label lblNama = item.FindControl("lblName") as Label;
                if (lblNama != null)
                {
                    if (lblNama.Text.Trim().ToLower() == Nama.Trim().ToLower())
                        return true;
                }
            }
            return false;
        }

        private void BindShareholder()
        {
            List<Shareholder> coll = new List<Shareholder>();
            if (ViewState["Shareholder"] != null)
                coll = ViewState["Shareholder"] as List<Shareholder>;

            dgShareholder.DataSource = coll;
            dgShareholder.DataBind();

            upShareholder.Update();
        }

        protected void dgShareholder_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<Shareholder> coll = new List<Shareholder>();
            if (ViewState["Shareholder"] != null)
                coll = ViewState["Shareholder"] as List<Shareholder>;

            if (e.CommandName == "add")
            {
                TextBox txtNameAdd = e.Item.FindControl("txtNameAdd") as TextBox;
                TextBox txtAddressAdd = e.Item.FindControl("txtAddressAdd") as TextBox;
                TextBox txtCountryEstablishmentAdd = e.Item.FindControl("txtCountryEstablishmentAdd") as TextBox;

                if (isExistInShareholderGrid(txtNameAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNameAdd.Text.Trim()));
                    return;
                }

                Shareholder o = new Shareholder();
                o.Name = txtNameAdd.Text.Trim();
                o.Address = txtAddressAdd.Text.Trim();
                o.Country = txtCountryEstablishmentAdd.Text.Trim();
                o.ID = 0;
                coll.Add(o);

                ViewState["Shareholder"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtNameEdit = e.Item.FindControl("txtNameEdit") as TextBox;
                TextBox txtAddressEdit = e.Item.FindControl("txtAddressEdit") as TextBox;
                TextBox txtCountryEstablishmentEdit = e.Item.FindControl("txtCountryEstablishmentEdit") as TextBox;

                if (isExistInShareholderGrid(txtNameEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNameEdit.Text.Trim()));
                    return;
                }

                Shareholder o = new Shareholder();
                o.Name = txtNameEdit.Text.Trim();
                o.Address = txtAddressEdit.Text.Trim();
                o.Country = txtCountryEstablishmentEdit.Text.Trim();

                coll[e.Item.ItemIndex] = o;
                ViewState["Shareholder"] = coll;

                dgShareholder.EditItemIndex = -1;
                dgShareholder.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgShareholder.ShowFooter = false;
                dgShareholder.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgShareholder.EditItemIndex = -1;
                dgShareholder.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["Shareholder"] = coll;
            }
            BindShareholder();
        }

        #endregion

        #region Officer

        private bool isExistInOfficerGrid(string Nama)
        {
            foreach (DataGridItem item in dgOfficer.Items)
            {
                Label lblNama = item.FindControl("lblName") as Label;
                if (lblNama != null)
                {
                    if (lblNama.Text.Trim().ToLower() == Nama.Trim().ToLower())
                        return true;
                }
            }
            return false;
        }

        private void BindOfficer()
        {
            List<Officer> coll = new List<Officer>();
            if (ViewState["Officer"] != null)
                coll = ViewState["Officer"] as List<Officer>;

            dgOfficer.DataSource = coll;
            dgOfficer.DataBind();

            upOfficer.Update();
        }

        protected void dgOfficer_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddRoleAdd = e.Item.FindControl("ddRoleAdd") as DropDownList;
                BindRole(ddRoleAdd);
            }
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                Officer o = e.Item.DataItem as Officer;

                DropDownList ddlRoleEdit = e.Item.FindControl("ddlRoleEdit") as DropDownList;
                BindRole(ddlRoleEdit);
                ddlRoleEdit.SelectedValue = o.Role;
            }
        }

        protected void dgOfficer_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<Officer> coll = new List<Officer>();
            if (ViewState["Officer"] != null)
                coll = ViewState["Officer"] as List<Officer>;

            if (e.CommandName == "add")
            {
                TextBox txtNameAdd = e.Item.FindControl("txtNameAdd") as TextBox;
                DropDownList ddRoleAdd = e.Item.FindControl("ddRoleAdd") as DropDownList;

                if (isExistInOfficerGrid(txtNameAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNameAdd.Text.Trim()));
                    return;
                }

                Officer o = new Officer();
                o.Name = txtNameAdd.Text.Trim();
                o.Role = ddRoleAdd.SelectedItem.Text;
                o.RoleID = Convert.ToInt32(ddRoleAdd.SelectedValue);
                o.ID = 0;
                coll.Add(o);

                ViewState["Officer"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtNameEdit = e.Item.FindControl("txtNameEdit") as TextBox;
                DropDownList ddlRoleEdit = e.Item.FindControl("ddlRoleEdit") as DropDownList;

                if (isExistInOfficerGrid(txtNameEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNameEdit.Text.Trim()));
                    return;
                }

                Officer o = new Officer();
                o.Name = txtNameEdit.Text.Trim();
                o.Role = ddlRoleEdit.SelectedItem.Text;
                o.RoleID = Convert.ToInt32(ddlRoleEdit.SelectedValue);

                coll[e.Item.ItemIndex] = o;
                ViewState["Officer"] = coll;

                dgOfficer.EditItemIndex = -1;
                dgOfficer.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgOfficer.ShowFooter = false;
                dgOfficer.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgOfficer.EditItemIndex = -1;
                dgOfficer.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["Officer"] = coll;
            }
            BindOfficer();
        }

        #endregion

        #region Search Pemohon

        private void VisiblePanel(bool isVisible)
        {
            pnlPemohon.Visible = !isVisible;
            pnlPemohonAddEdit.Visible = isVisible;
        }

        private void ClearPemohon()
        {
            txtNamaPemohonAddEdit.Text = string.Empty;
            txtEmailPemohonAddEdit.Text = string.Empty;
        }

        private void DisplayPemohon(bool isGrid, int IDPemohon)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
            SPListItem item = list.GetItemById(IDPemohon);
            if (item != null)
            {
                if (isGrid)
                {
                    txtNamaPemohonAddEdit.Text = item.Title;
                    txtEmailPemohonAddEdit.Text = item["EmailPemohon"].ToString();
                }
                else
                {
                    hfIDRequestor.Value = IDPemohon.ToString();
                    txtRequestor.Text = item.Title;
                    txtRequestorEmail.Text = item["EmailPemohon"].ToString();
                }
            }

            BindShareholder();
            BindOfficer();

            upMain.Update();
        }

        private void BindPemohon()
        {
            string query = string.Empty;
            if (txtSearchPemohon.Text.Trim() == string.Empty)
            {
                query = "<Where>" +
                             "<IsNotNull>" +
                                "<FieldRef Name='Title' />" +
                             "</IsNotNull>" +
                        "</Where>";
            }
            else
            {
                query = "<Where>" +
                          "<Contains>" +
                            "<FieldRef Name='Title' />" +
                            "<Value Type='Text'>" + txtSearchPemohon.Text.Trim() + "</Value>" +
                          "</Contains>" +
                        "</Where>";
            }

            grvPemohon.Visible = true;
            odsPemohon.SelectParameters["ListURL"].DefaultValue = Util.CreateSharePointListStrUrl(web.Url, "Pemohon");
            odsPemohon.SelectParameters["strQuery"].DefaultValue = query;
            odsPemohon.Page.DataBind();
        }

        private string SaveUpdatePemohon()
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
            web.AllowUnsafeUpdates = true;
            SPListItem item;

            try
            {
                if (ViewState["IDPemohon"] == null)
                {
                    item = list.Items.Add();
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(Convert.ToInt32(ViewState["IDPemohon"].ToString()));
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                item["Title"] = txtNamaPemohonAddEdit.Text.Trim();
                item["EmailPemohon"] = txtEmailPemohonAddEdit.Text.Trim();
                item.Update();

                web.AllowUnsafeUpdates = false;
            }
            catch
            {
                if (ViewState["IDPemohon"] == null)
                    return SR.SaveFail;
                else
                    return SR.UpdateFail;
            }
            return string.Empty;
        }

        protected void imgbtnNamaPemohon_Click(object sender, ImageClickEventArgs e)
        {
            grvPemohon.Visible = false;
        }

        protected void btnSearchPemohon_Click(object sender, EventArgs e)
        {
            BindPemohon();
        }

        protected void btnAddPemohon_Click(object sender, EventArgs e)
        {
            ViewState["IDPemohon"] = null;
            btnSavePemohon.Text = "Save";

            VisiblePanel(true);
            ClearPemohon();
        }

        protected void grvPemohon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItemIndex < 0)
                return;

            DataRowView dr = e.Row.DataItem as DataRowView;

            Literal ltrrb = e.Row.FindControl("ltrrb") as Literal;
            ltrrb.Text = string.Format("<input type='radio' name='rbPemohon' id='Row{0}' value='{0}' />", dr["ID"].ToString());
        }

        protected void grvPemohon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IDPemohon;
            if (e.CommandName == "ubah")
            {
                VisiblePanel(true);
                ClearPemohon();

                IDPemohon = Convert.ToInt32(e.CommandArgument.ToString());
                btnSavePemohon.Text = "Update";
                ViewState["IDPemohon"] = IDPemohon;

                DisplayPemohon(true, IDPemohon);
            }
        }

        protected void btnSelectPemohon_Click(object sender, EventArgs e)
        {
            if (Request.Form["rbPemohon"] != null)
            {
                string IDPemohon = Request.Form["rbPemohon"].ToString();
                DisplayPemohon(false, Convert.ToInt32(IDPemohon));
                Util.RegisterStartupScript(Page, "closePemohon", "closeDialog('divPemohonSearch');");
            }
            else
                Util.ShowMessage(Page, "Please choose Pemohon");
        }

        protected void btnSavePemohon_Click(object sender, EventArgs e)
        {
            string result = SaveUpdatePemohon();
            if (result == string.Empty)
            {
                VisiblePanel(false);
                BindPemohon();
            }
            else
                Util.ShowMessage(Page, result);
        }

        protected void btnCancelPemohon_Click(object sender, EventArgs e)
        {
            VisiblePanel(false);
        }

        #endregion

        #endregion
    }
}
