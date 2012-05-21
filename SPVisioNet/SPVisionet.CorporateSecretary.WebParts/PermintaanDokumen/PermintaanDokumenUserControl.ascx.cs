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
using Microsoft.SharePoint.WebControls;
using System.Web;

namespace SPVisionet.CorporateSecretary.WebParts.PermintaanDokumen
{
    public partial class PermintaanDokumenUserControl : UserControl
    {
        #region Properties

        private SPWeb web;
        private int ID = 0;
        private Guid ListId = Guid.Empty;

        [Serializable]
        public class Dokument
        {
            public int ID { get; set; }
            public string NamaDokumen { get; set; }
            public int IDTipeDokumen { get; set; }
            public string TipeDokumen { get; set; }
            public string SoftcopyOriginal { get; set; }
            public string TujuanPeminjaman { get; set; }
            public DateTime TanggalDibutuhkan { get; set; }
            public DateTime TanggalEstimasiPengembalian { get; set; }
        }

        #endregion

        #region Methods

        private void BindTipeDokumen(DropDownList ddl)
        {
            DataTable dt = Util.GetTipeDokumen(web);
            ddl.DataSource = dt;
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
        }

        private void BindDokumen()
        {
            List<Dokument> coll = new List<Dokument>();
            if (ViewState["Dokument"] != null)
                coll = ViewState["Dokument"] as List<Dokument>;

            dgDokumen.DataSource = coll;
            dgDokumen.DataBind();

            upDokumen.Update();
        }

        private string DokumentValidation(TextBox txtNamaDokumen, DropDownList ddlTipeDokumen, DropDownList ddlSoftcopyOriginal, TextBox txtTujuanPeminjaman, DateTimeControl dtTglDibutuhkan, DateTimeControl dtTglEstimasiPengembalian)
        {
            StringBuilder sb = new StringBuilder();
            if (txtNamaDokumen.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Nama Dokumen") + " \\n");
            if (ddlTipeDokumen.SelectedValue == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Tipe Dokumen") + " \\n");
            if (ddlSoftcopyOriginal.SelectedValue == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Softcopy/Original") + " \\n");
            if (txtTujuanPeminjaman.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Tujuan Peminjaman") + " \\n");
            if (dtTglDibutuhkan.ErrorMessage != null)
                sb.Append(SR.FieldCanNotEmpty("Tanggal dibutuhkan") + " \\n");
            if (dtTglEstimasiPengembalian.ErrorMessage != null)
                sb.Append(SR.FieldCanNotEmpty("Tanggal Estimasi Pengembalian") + " \\n");

            return sb.ToString();
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (peNamaPeminjam.Accounts.Count == 0)
                sb.Append(SR.FieldCanNotEmpty("Nama Peminjam") + " \\n");
            else
            {
                if (peNamaPeminjam.Accounts.Count >= 2)
                    sb.Append("Only one Nama Peminjam can be selected \\n");
            }

            if (dgDokumen.Items.Count == 0)
                sb.Append("At least one data must be inserted in Document Grid");

            return sb.ToString();
        }

        private bool isExistInGrid(string NamaDokumen)
        {
            foreach (DataGridItem item in dgDokumen.Items)
            {
                Label lblNamaDokumen = item.FindControl("lblNamaDokumen") as Label;
                if (lblNamaDokumen != null)
                {
                    if (lblNamaDokumen.Text.Trim().ToLower() == NamaDokumen.Trim().ToLower())
                        return true;
                }
            }
            return false;
        }

        private void Display(string mode)
        {
            SPList list = web.Lists[ListId];
            SPListItem item = list.GetItemById(ID);

            ltrRequestor.Text = item["Created By"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (mode == "edit")
            {
                btnSaveUpdate.Text = "Update";

                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                SPFieldUserValue userVal = new SPFieldUserValue(web, item["NamaPeminjam"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                peNamaPeminjam.CommaSeparatedAccounts = userVal.User.LoginName;
                ltrDivisiPeminjam.Text = item["DivisiPeminjam"] == null ? string.Empty : item["DivisiPeminjam"].ToString();
                txtKeterangan.Text = item["Keterangan"].ToString();
            }
            else if (mode == "display")
            {
                btnSaveUpdate.Visible = false;

                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                SPFieldUserValue userVal = new SPFieldUserValue(web, item["NamaPeminjam"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                ltrNamaPeminjam.Text = userVal.User.Name;
                ltrDivisiPeminjam.Text = item["DivisiPeminjam"] == null ? string.Empty : item["DivisiPeminjam"].ToString();
                ltrKeterangan.Text = item["Keterangan"].ToString();
            }

            SPList document = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumenDokumen"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PermintaanDokumen' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + ID + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";
            SPListItemCollection coll = document.GetItems(query);

            List<Dokument> collDokument = new List<Dokument>();
            foreach (SPListItem i in coll)
            {
                Dokument o = new Dokument();
                o.ID = i.ID;
                o.IDTipeDokumen = Convert.ToInt32(i["TipeDokumen"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                o.NamaDokumen = i.Title;
                o.SoftcopyOriginal = i["SoftcopyOriginal"].ToString();
                o.TanggalDibutuhkan = Convert.ToDateTime(i["TanggalDibutuhkan"]);
                o.TanggalEstimasiPengembalian = Convert.ToDateTime(i["TanggalEstimasiPengembalian"]);
                o.TipeDokumen = i["TipeDokumen"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                o.TujuanPeminjaman = i["TujuanPeminjaman"].ToString();
                collDokument.Add(o);
            }
            ViewState["Dokument"] = collDokument;
            ViewState["DokumentEdit"] = collDokument;
            BindDokumen();

            HiddenControls(mode);
        }

        private void HiddenControls(string mode)
        {
            if (mode == "display")
            {
                txtKeterangan.Visible = false;
                peNamaPeminjam.Visible = false;

                dgDokumen.ShowFooter = false;
                dgDokumen.Columns[7].Visible = false;
            }
            else if (mode == "edit")
            {
                ltrKeterangan.Visible = false;
                ltrNamaPeminjam.Visible = false;
            }
        }

        private string SaveUpdate()
        {
            SPList list = web.Lists[ListId];
            SPList listDocument = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumenDokumen"));
            web.AllowUnsafeUpdates = true;
            SPListItem item;

            try
            {
                if (ID == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, RequestCode.PERMINTAAN_DOKUMEN, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(ID);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                SPUser namaPeminjam = web.SiteUsers[peNamaPeminjam.CommaSeparatedAccounts];

                item["Tanggal"] = Convert.ToDateTime(ltrDate.Text);
                item["NamaPeminjam"] = namaPeminjam.ID.ToString();
                item["DivisiPeminjam"] = ltrDivisiPeminjam.Text.Trim();
                item["Keterangan"] = txtKeterangan.Text.Trim();
                item.Update();

                ViewState["ID"] = item.ID;

                if (ID == 0)
                {
                    List<Dokument> coll = ViewState["Dokument"] as List<Dokument>;
                    foreach (Dokument i in coll)
                    {
                        SPListItem itemDocument = listDocument.Items.Add();
                        itemDocument["PermintaanDokumen"] = ViewState["ID"].ToString();
                        itemDocument["Title"] = i.NamaDokumen;
                        itemDocument["TipeDokumen"] = i.IDTipeDokumen;
                        itemDocument["SoftcopyOriginal"] = i.SoftcopyOriginal;
                        itemDocument["TujuanPeminjaman"] = i.TujuanPeminjaman;
                        itemDocument["TanggalDibutuhkan"] = i.TanggalDibutuhkan;
                        itemDocument["TanggalEstimasiPengembalian"] = i.TanggalEstimasiPengembalian;
                        itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemDocument.Update();
                    }
                }
                else
                {
                    if (dgDokumen.Items.Count > 0)
                    {
                        foreach (DataGridItem dgItem in dgDokumen.Items)
                        {
                            Label lblID = dgItem.FindControl("lblID") as Label;
                            Label lblNamaDokumen = dgItem.FindControl("lblNamaDokumen") as Label;
                            Label lblIDTipeDokumen = dgItem.FindControl("lblIDTipeDokumen") as Label;
                            Label lblSoftcopyOriginal = dgItem.FindControl("lblSoftcopyOriginal") as Label;
                            Label lblTujuanPeminjaman = dgItem.FindControl("lblTujuanPeminjaman") as Label;
                            Label lblTanggaldibutuhkan = dgItem.FindControl("lblTanggaldibutuhkan") as Label;
                            Label lblTanggalEstimasi = dgItem.FindControl("lblTanggalEstimasi") as Label;

                            SPListItem itemDocument;
                            if (Convert.ToInt32(lblID.Text) != 0)
                            {
                                itemDocument = listDocument.GetItemById(Convert.ToInt32(lblID.Text));
                                itemDocument["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemDocument = listDocument.Items.Add();
                                itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemDocument["PermintaanDokumen"] = ViewState["ID"].ToString();
                            itemDocument["Title"] = lblNamaDokumen.Text;
                            itemDocument["TipeDokumen"] = lblIDTipeDokumen.Text;
                            itemDocument["SoftcopyOriginal"] = lblSoftcopyOriginal.Text;
                            itemDocument["TujuanPeminjaman"] = lblTujuanPeminjaman.Text;
                            itemDocument["TanggalDibutuhkan"] = Convert.ToDateTime(lblTanggaldibutuhkan.Text);
                            itemDocument["TanggalEstimasiPengembalian"] = Convert.ToDateTime(lblTanggalEstimasi.Text);
                            itemDocument.Update();
                        }
                    }

                    if (ViewState["DokumentEdit"] != null)
                    {
                        List<Dokument> collEdit = ViewState["DokumentEdit"] as List<Dokument>;
                        foreach (Dokument itemEdit in collEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgDokumen.Items)
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
                                SPListItem itemDocument = listDocument.GetItemById(itemEdit.ID);
                                if (itemDocument != null)
                                    itemDocument.Delete();
                            }
                        }
                    }
                }

                web.AllowUnsafeUpdates = false;
            }
            catch
            {
                if (ID == 0)
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
            using (SPSite site = new SPSite(SPContext.Current.Site.Url, SPContext.Current.Site.SystemAccount.UserToken))
            {
                using (web = site.OpenWeb())
                {
                    bool isID = false;
                    if (ViewState["ID"] == null)
                    {
                        if (Request.QueryString["ID"] != null)
                            isID = int.TryParse(Request.QueryString["ID"], out ID);
                    }
                    else
                        ID = Convert.ToInt32(ViewState["ID"]);

                    string mode = Request.QueryString["mode"] == null ? string.Empty : Request.QueryString["mode"].ToString();

                    if (Request.QueryString["List"] != null)
                        ListId = new Guid(HttpUtility.UrlDecode(Request.QueryString["List"]));

                    if (peNamaPeminjam.Accounts.Count == 1)
                    {
                        SPUser namaPeminjam = web.SiteUsers[peNamaPeminjam.CommaSeparatedAccounts];
                        ltrDivisiPeminjam.Text = Util.GetDepartment(web, namaPeminjam.ID);
                    }
                    else
                        ltrDivisiPeminjam.Text = string.Empty;

                    if (!IsPostBack)
                    {
                        ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                        try
                        {
                            ltrRequestor.Text = SPUtility.GetFullNameFromLogin(site, SPContext.Current.Web.CurrentUser.LoginName);
                        }
                        catch
                        {
                            ltrRequestor.Text = "System Account";
                        }

                        BindDokumen();

                        if (isID)
                            Display(mode);
                    }
                }
            }
        }

        protected void dgDokumen_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddlTipeDokumenAdd = e.Item.FindControl("ddlTipeDokumenAdd") as DropDownList;

                BindTipeDokumen(ddlTipeDokumenAdd);
            }
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                Dokument o = e.Item.DataItem as Dokument;

                DateTimeControl dtTanggaldibutuhkanEdit = e.Item.FindControl("dtTanggaldibutuhkanEdit") as DateTimeControl;
                dtTanggaldibutuhkanEdit.SelectedDate = o.TanggalDibutuhkan;

                DateTimeControl dtTanggalEstimasiEdit = e.Item.FindControl("dtTanggalEstimasiEdit") as DateTimeControl;
                dtTanggalEstimasiEdit.SelectedDate = o.TanggalEstimasiPengembalian;

                DropDownList ddlSoftcopyOriginalEdit = e.Item.FindControl("ddlSoftcopyOriginalEdit") as DropDownList;
                ddlSoftcopyOriginalEdit.SelectedValue = o.SoftcopyOriginal;

                DropDownList ddlTipeDokumenEdit = e.Item.FindControl("ddlTipeDokumenEdit") as DropDownList;
                BindTipeDokumen(ddlTipeDokumenEdit);
                ddlTipeDokumenEdit.SelectedValue = o.IDTipeDokumen.ToString();
            }
        }

        protected void dgDokumen_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<Dokument> coll = new List<Dokument>();
            if (ViewState["Dokument"] != null)
                coll = ViewState["Dokument"] as List<Dokument>;

            if (e.CommandName == "add")
            {
                TextBox txtNamaDokumenAdd = e.Item.FindControl("txtNamaDokumenAdd") as TextBox;
                DropDownList ddlTipeDokumenAdd = e.Item.FindControl("ddlTipeDokumenAdd") as DropDownList;
                DropDownList ddlSoftcopyOriginalAdd = e.Item.FindControl("ddlSoftcopyOriginalAdd") as DropDownList;
                TextBox txtTujuanPeminjamanAdd = e.Item.FindControl("txtTujuanPeminjamanAdd") as TextBox;
                DateTimeControl dtTanggaldibutuhkanAdd = e.Item.FindControl("dtTanggaldibutuhkanAdd") as DateTimeControl;
                DateTimeControl dtTanggalEstimasiAdd = e.Item.FindControl("dtTanggalEstimasiAdd") as DateTimeControl;

                string msg = DokumentValidation(txtNamaDokumenAdd, ddlTipeDokumenAdd, ddlSoftcopyOriginalAdd, txtTujuanPeminjamanAdd, dtTanggaldibutuhkanAdd, dtTanggalEstimasiAdd);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                if (isExistInGrid(txtNamaDokumenAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaDokumenAdd.Text.Trim()));
                    return;
                }

                Dokument o = new Dokument();
                o.NamaDokumen = txtNamaDokumenAdd.Text.Trim();
                o.IDTipeDokumen = Convert.ToInt32(ddlTipeDokumenAdd.SelectedValue);
                o.TipeDokumen = ddlTipeDokumenAdd.SelectedItem.Text;
                o.SoftcopyOriginal = ddlSoftcopyOriginalAdd.SelectedValue;
                o.TujuanPeminjaman = txtTujuanPeminjamanAdd.Text.Trim();
                o.TanggalDibutuhkan = dtTanggaldibutuhkanAdd.SelectedDate;
                o.TanggalEstimasiPengembalian = dtTanggalEstimasiAdd.SelectedDate;
                o.ID = 0;
                coll.Add(o);

                ViewState["Dokument"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtNamaDokumenEdit = e.Item.FindControl("txtNamaDokumenEdit") as TextBox;
                DropDownList ddlTipeDokumenEdit = e.Item.FindControl("ddlTipeDokumenEdit") as DropDownList;
                DropDownList ddlSoftcopyOriginalEdit = e.Item.FindControl("ddlSoftcopyOriginalEdit") as DropDownList;
                TextBox txtTujuanPeminjamanEdit = e.Item.FindControl("txtTujuanPeminjamanEdit") as TextBox;
                DateTimeControl dtTanggaldibutuhkanEdit = e.Item.FindControl("dtTanggaldibutuhkanEdit") as DateTimeControl;
                DateTimeControl dtTanggalEstimasiEdit = e.Item.FindControl("dtTanggalEstimasiEdit") as DateTimeControl;

                string msg = DokumentValidation(txtNamaDokumenEdit, ddlTipeDokumenEdit, ddlSoftcopyOriginalEdit, txtTujuanPeminjamanEdit, dtTanggaldibutuhkanEdit, dtTanggalEstimasiEdit);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                if (isExistInGrid(txtNamaDokumenEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaDokumenEdit.Text.Trim()));
                    return;
                }

                Dokument o = new Dokument();
                o.NamaDokumen = txtNamaDokumenEdit.Text.Trim();
                o.IDTipeDokumen = Convert.ToInt32(ddlTipeDokumenEdit.SelectedValue);
                o.TipeDokumen = ddlTipeDokumenEdit.SelectedItem.Text;
                o.SoftcopyOriginal = ddlSoftcopyOriginalEdit.SelectedValue;
                o.TujuanPeminjaman = txtTujuanPeminjamanEdit.Text.Trim();
                o.TanggalDibutuhkan = dtTanggaldibutuhkanEdit.SelectedDate;
                o.TanggalEstimasiPengembalian = dtTanggalEstimasiEdit.SelectedDate;

                coll[e.Item.ItemIndex] = o;
                ViewState["Dokument"] = coll;

                dgDokumen.EditItemIndex = -1;
                dgDokumen.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgDokumen.ShowFooter = false;
                dgDokumen.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgDokumen.EditItemIndex = -1;
                dgDokumen.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["Dokument"] = coll;
            }
            BindDokumen();
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
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Util.ShowMessage(Page, result);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
        }

        #endregion
    }
}
