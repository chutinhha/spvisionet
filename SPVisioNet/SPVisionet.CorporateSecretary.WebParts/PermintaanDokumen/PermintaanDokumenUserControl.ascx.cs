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
        private int IDP = 0;
        private string Source = string.Empty;
        private string Mode = string.Empty;
        //private Guid ListId = Guid.Empty;
        private DropDownList ddlTipeDokumenAdd = null;
        private TextBox txtNamaDokumenAdd = null;

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
            public DateTime? TanggalEstimasiPengembalian { get; set; }
            public DateTime? TanggaPengembalian { get; set; }
        }

        #endregion

        #region Methods

        private bool isAvailable(string DocumentName, int DocumentTypeID)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumenDokumen"));  //web.Lists[ListId];
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                               "<And>" +
                                  "<And>" +
                                     "<And>" +
                                        "<Eq>" +
                                            "<FieldRef Name='Title' />" +
                                            "<Value Type='Text'>" + DocumentName + "</Value>" +
                                        "</Eq>" +
                                        "<And>" +
                                            "<IsNull>" +
                                                "<FieldRef Name='TanggalPengembalian' />" +
                                            "</IsNull>" +
                                            "<Eq>" +
                                                "<FieldRef Name='TipeDokumen' LookupId='True' />" +
                                                "<Value Type='Lookup'>" + DocumentTypeID + "</Value>" +
                                            "</Eq>" +
                                        "</And>" +
                                     "</And>" +
                                     "<Eq>" +
                                         "<FieldRef Name='SoftcopyOriginal' />" +
                                         "<Value Type='Choice'>Original</Value>" +
                                     "</Eq>" +
                                  "</And>" +
                                  "<IsNull>" +
                                      "<FieldRef Name='LK_x003a_ApprovalStatus' />" +
                                  "</IsNull>" +
                               "</And>" +
                           "</Where>";

            SPListItemCollection coll = list.GetItems(query);
            if (coll.Count > 0)
                return false;
            return true;
        }

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
            if (ddlSoftcopyOriginal.SelectedItem.Text.ToLower() == "original")
            {
                if (dtTglEstimasiPengembalian.IsDateEmpty || dtTglEstimasiPengembalian.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Estimasi Pengembalian") + " \\n");

                if (!dtTglEstimasiPengembalian.IsDateEmpty)
                {
                    int i = DateTime.Compare(dtTglDibutuhkan.SelectedDate, dtTglEstimasiPengembalian.SelectedDate);
                    if (i > 0)
                        sb.Append("Tanggal dibutuhkan must be greater or equal than Tanggal Estimasi Pengembalian\\n");
                }
            }

            return sb.ToString();
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (ViewState["Status"].ToString() == string.Empty)
            {
                if (peNamaPeminjam.Accounts.Count == 0)
                    sb.Append(SR.FieldCanNotEmpty("Nama Peminjam") + " \\n");
                else
                {
                    if (peNamaPeminjam.Accounts.Count >= 2)
                        sb.Append("Only one Nama Peminjam can be selected \\n");
                }

                if (dgDokumen.Items.Count == 0)
                    sb.Append("At least one data must be inserted in Document Grid");
            }

            return sb.ToString();
        }

        private bool isExistInGrid(string NamaDokumen, string TipeDokumen, string SoftcopyOriginal)
        {
            foreach (DataGridItem item in dgDokumen.Items)
            {
                Label lblNamaDokumen = item.FindControl("lblNamaDokumen") as Label;
                Label lblTipeDokumen = item.FindControl("lblTipeDokumen") as Label;
                Label lblSoftcopyOriginal = item.FindControl("lblSoftcopyOriginal") as Label;

                if (lblNamaDokumen != null && lblTipeDokumen != null && lblSoftcopyOriginal != null)
                {
                    if (lblNamaDokumen.Text.Trim().ToLower() == NamaDokumen.Trim().ToLower() && lblTipeDokumen.Text.Trim().ToLower() == TipeDokumen.ToLower() && lblSoftcopyOriginal.Text.Trim().ToLower() == SoftcopyOriginal.ToLower())
                        return true;
                }
            }
            return false;
        }

        private void Display(string mode)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumen"));  //web.Lists[ListId];
            SPListItem item = list.GetItemById(IDP);

            ltrRequestor.Text = item["Created By"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (item["Status"] != null)
                ViewState["Status"] = item["Status"].ToString();

            if (item["ApprovalStatus"] != null)
            {
                if (item["ApprovalStatus"].ToString() == "Approved")
                {
                    dgDokumen.Columns[7].Visible = true;
                    dgDokumen.Columns[8].Visible = false;
                    dgDokumen.Columns[9].Visible = true;
                }
            }

            if (mode == "edit")
                btnSaveUpdate.Text = "Update";
            else if (mode == "display")
                btnSaveUpdate.Visible = false;

            ltrRequestCode.Text = item["Title"].ToString();
            ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
            SPFieldUserValue userVal = new SPFieldUserValue(web, item["NamaPeminjam"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            peNamaPeminjam.CommaSeparatedAccounts = userVal.User.LoginName;
            peNamaPeminjam.Validate();
            ltrDivisiPeminjam.Text = item["DivisiPeminjam"] == null ? string.Empty : item["DivisiPeminjam"].ToString();
            txtKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();

            ltrNamaPeminjam.Text = userVal.User.Name;
            ltrKeterangan.Text = txtKeterangan.Text;

            SPList document = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumenDokumen"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PermintaanDokumen' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + IDP + "</Value>" +
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
                if (i["TanggalEstimasiPengembalian"] != null)
                    o.TanggalEstimasiPengembalian = Convert.ToDateTime(i["TanggalEstimasiPengembalian"]);
                if (i["TanggalPengembalian"] != null)
                    o.TanggaPengembalian = Convert.ToDateTime(i["TanggalPengembalian"]);
                o.TipeDokumen = i["TipeDokumen"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                o.TujuanPeminjaman = i["TujuanPeminjaman"].ToString();
                collDokument.Add(o);
            }
            ViewState["Dokument"] = collDokument;
            ViewState["DokumentEdit"] = collDokument;
            BindDokumen();

            HiddenControls(mode, item["Status"] == null ? string.Empty : item["Status"].ToString());
        }

        private void HiddenControls(string mode, string status)
        {
            if (mode == "display")
            {
                txtKeterangan.Visible = false;
                peNamaPeminjam.Visible = false;

                dgDokumen.ShowFooter = false;
                dgDokumen.Columns[9].Visible = false;

                if (status == Roles.CUSTODIAN + "_2" || status == Roles.CUSTODIAN + "_3" || status == Roles.PIC_CORSEC)
                {
                    dgDokumen.Columns[7].Visible = false;
                    dgDokumen.Columns[8].Visible = true;
                    ltrKeterangan.Visible = true;
                    ltrNamaPeminjam.Visible = true;
                }
            }
            else if (mode == "edit")
            {
                if (status == Roles.CUSTODIAN + "_2" || status == Roles.CUSTODIAN + "_3" || status == Roles.PIC_CORSEC)
                {
                    peNamaPeminjam.Visible = false;
                    txtKeterangan.Visible = false;
                    dgDokumen.ShowFooter = false;

                    dgDokumen.Columns[7].Visible = true;
                    dgDokumen.Columns[9].Visible = false;
                    ltrKeterangan.Visible = true;
                    ltrNamaPeminjam.Visible = true;
                }
                else
                {
                    ltrKeterangan.Visible = false;
                    ltrNamaPeminjam.Visible = false;
                }
            }
        }

        private string SaveUpdate()
        {
            SPWeb currentWeb = SPContext.Current.Web;
            SPList list = currentWeb.GetList(Util.CreateSharePointListStrUrl(currentWeb.Url, "PermintaanDokumen")); //web.Lists[ListId];
            currentWeb.AllowUnsafeUpdates = true;
            SPList listDocument = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumenDokumen"));

            SPListItem item;

            try
            {
                if (IDP == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, RequestCode.PERMINTAAN_DOKUMEN, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(IDP);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (ViewState["Status"].ToString() == string.Empty)
                {
                    SPUser namaPeminjam = web.SiteUsers[peNamaPeminjam.CommaSeparatedAccounts];

                    item["Tanggal"] = Convert.ToDateTime(ltrDate.Text);
                    item["NamaPeminjam"] = namaPeminjam.ID.ToString();
                    item["DivisiPeminjam"] = ltrDivisiPeminjam.Text.Trim();
                    item["Keterangan"] = txtKeterangan.Text.Trim();
                    item.Update();
                }

                currentWeb.AllowUnsafeUpdates = false;

                ViewState["ID"] = item.ID;

                web.AllowUnsafeUpdates = true;
                if (IDP == 0)
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
                        if (i.TanggalEstimasiPengembalian != null)
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
                            DateTimeControl dtTanggalPengembalian = dgItem.FindControl("dtTanggalPengembalian") as DateTimeControl;

                            if (ViewState["Status"].ToString() != string.Empty)
                            {
                                if (lblSoftcopyOriginal.Text.ToLower() == "original")
                                {
                                    if (dtTanggalPengembalian.IsDateEmpty || dtTanggalPengembalian.ErrorMessage != null)
                                    {
                                        return SR.FieldCanNotEmpty("Tanggal Pengembalian for " + lblNamaDokumen.Text);
                                    }
                                }
                            }

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
                            if (lblTanggalEstimasi.Text != string.Empty)
                                itemDocument["TanggalEstimasiPengembalian"] = Convert.ToDateTime(lblTanggalEstimasi.Text);
                            if (!dtTanggalPengembalian.IsDateEmpty)
                                itemDocument["TanggalPengembalian"] = dtTanggalPengembalian.SelectedDate;
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
            Util.RegisterStartupScript(Page, "Dokumen", "RegisterDialog('divDocumentSearch','divDocumentDlgContainer', '620');");

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

                    Mode = Request.QueryString["mode"] == null ? string.Empty : Request.QueryString["mode"].ToString();
                    Source = Request.QueryString["Source"] == null ? string.Empty : Request.QueryString["Source"].ToString();

                    //if (Request.QueryString["List"] != null)
                    //    ListId = new Guid(HttpUtility.UrlDecode(Request.QueryString["List"]));

                    if (!IsPostBack)
                    {
                        ViewState["Status"] = string.Empty;

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
                            Display(Mode);
                    }

                    if (peNamaPeminjam.Accounts.Count == 1)
                    {
                        SPUser namaPeminjam = web.SiteUsers[peNamaPeminjam.CommaSeparatedAccounts];
                        ltrDivisiPeminjam.Text = Util.GetDepartment(web, namaPeminjam.ID);
                    }
                    else
                        ltrDivisiPeminjam.Text = string.Empty;
                }
            }
        }

        protected void dgDokumen_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                ddlTipeDokumenAdd = e.Item.FindControl("ddlTipeDokumenAdd") as DropDownList;
                BindTipeDokumen(ddlTipeDokumenAdd);

                txtNamaDokumenAdd = e.Item.FindControl("txtNamaDokumenAdd") as TextBox;
            }
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                Dokument o = e.Item.DataItem as Dokument;

                DateTimeControl dtTanggaldibutuhkanEdit = e.Item.FindControl("dtTanggaldibutuhkanEdit") as DateTimeControl;
                dtTanggaldibutuhkanEdit.SelectedDate = o.TanggalDibutuhkan;

                DateTimeControl dtTanggalEstimasiEdit = e.Item.FindControl("dtTanggalEstimasiEdit") as DateTimeControl;
                if (o.TanggalEstimasiPengembalian != null)
                    dtTanggalEstimasiEdit.SelectedDate = Convert.ToDateTime(o.TanggalEstimasiPengembalian);

                DropDownList ddlSoftcopyOriginalEdit = e.Item.FindControl("ddlSoftcopyOriginalEdit") as DropDownList;
                ddlSoftcopyOriginalEdit.SelectedValue = o.SoftcopyOriginal;

                DropDownList ddlTipeDokumenEdit = e.Item.FindControl("ddlTipeDokumenEdit") as DropDownList;
                BindTipeDokumen(ddlTipeDokumenEdit);
                ddlTipeDokumenEdit.SelectedValue = o.IDTipeDokumen.ToString();
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Dokument o = e.Item.DataItem as Dokument;

                //LinkButton btnDelete = e.Item.FindControl("btnDelete") as LinkButton;
                //if (ViewState["Status"] != null)
                //    btnDelete.Visible = false;

                if (o.TanggaPengembalian != null)
                {
                    Label lblTanggalPengembalian = e.Item.FindControl("lblTanggalPengembalian") as Label;
                    lblTanggalPengembalian.Text = Convert.ToDateTime(o.TanggaPengembalian).ToString("dd-MMM-yyyy");

                    DateTimeControl dtTanggalPengembalian = e.Item.FindControl("dtTanggalPengembalian") as DateTimeControl;
                    dtTanggalPengembalian.SelectedDate = Convert.ToDateTime(o.TanggaPengembalian);
                }
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

                if (isExistInGrid(txtNamaDokumenAdd.Text, ddlTipeDokumenAdd.SelectedItem.Text, ddlSoftcopyOriginalAdd.SelectedValue))
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
                if (!dtTanggalEstimasiAdd.IsDateEmpty || dtTanggalEstimasiAdd.ErrorMessage != null)
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

                if (isExistInGrid(txtNamaDokumenEdit.Text, ddlTipeDokumenEdit.SelectedItem.Text, ddlSoftcopyOriginalEdit.SelectedValue))
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
                if (!dtTanggalEstimasiEdit.IsDateEmpty || dtTanggalEstimasiEdit.ErrorMessage != null)
                    o.TanggalEstimasiPengembalian = dtTanggalEstimasiEdit.SelectedDate;

                coll[e.Item.ItemIndex] = o;
                ViewState["Dokument"] = coll;

                dgDokumen.EditItemIndex = -1;

                //if (ViewState["Status"] == null)
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
                //if (ViewState["Status"] == null)
                dgDokumen.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["Dokument"] = coll;
            }
            if (e.CommandName == "popup")
            {
                ViewState["Index"] = e.Item.ItemIndex;
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
            {
                if (Source != string.Empty)
                    SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
                else
                    Response.Redirect("/Lists/PermintaanDokumen", true);
            }
            else
                Util.ShowMessage(Page, result);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect("/Lists/PermintaanDokumen", true);
        }

        #region Search Document

        public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
        {
            DataTable dt = new DataTable();
            dt = SourceTable.Clone();
            object LastValue = null;
            foreach (DataRow dr in SourceTable.Rows)
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
                {
                    LastValue = dr[FieldName];
                    DataRow newRow = dt.NewRow();
                    newRow.ItemArray = dr.ItemArray;
                    dt.Rows.Add(newRow);
                }
            }
            return dt;
        }

        private bool ColumnEqual(object A, object B)
        {

            // Compares two values to see if they are equal. Also compares DBNULL.Value.
            // Note: If your DataTable contains object fields, then you must extend this
            // function to handle them in a meaningful way if you intend to group on them.

            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is DBNull.Value
                return false;
            return (A.Equals(B));  // value type standard comparison
        }

        private void BindSearchDocument()
        {
            grv.Visible = true;

            DataTable dt = new DataTable();
            SPQuery query;

            string Type = ddlTipeDokumen.SelectedItem.Text.ToLower();
            if (Type == "akta and sk pengesahan pendirian" || Type == "apv" || Type == "bnri" || Type == "npwp" || Type == "pkp" || Type == "setoran modal" || Type == "skdp" || Type == "apv")
            {
                query = new SPQuery();
                query.Query = "<Where>" +
                                "<And>" +
                                    "<And>" +
                                       "<Contains>" +
                                           "<FieldRef Name='LK_x003a_NamaPerusahaan' />" +
                                           "<Value Type='Lookup'>" + txtSearch.Text.Trim() + "</Value>" +
                                       "</Contains>" +
                                       "<Eq>" +
                                           "<FieldRef Name='LK_x003a_ApprovalStatus' />" +
                                           "<Value Type='Text'>Approved</Value>" +
                                       "</Eq>" +
                                    "</And>" +
                                    "<Eq>" +
                                       "<FieldRef Name='DocumentType' />" +
                                       "<Value Type='Text'>" + Type + "</Value>" +
                                    "</Eq>" +
                                "</And>" +
                              "</Where>" +
                              "<OrderBy>" +
                                 "<FieldRef Name='Created' Ascending='False' />" +
                              "</OrderBy>";
                query.ViewFields = string.Concat("<FieldRef Name='ID' />",
                                                 "<FieldRef Name='Title' />",
                                                 "<FieldRef Name='LK_x003a_NamaPerusahaan' />",
                                                 "<FieldRef Name='PerusahaanBaru' />");

                query.ViewFieldsOnly = true;
                query.ViewAttributes = "Scope=\"Recursive\"";

                SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
                dt = list.GetItems(query).GetDataTable();

                if (Type != "bnri" || Type == "akta and sk pengesahan pendirian")
                {
                    if (dt != null)
                        dt = SelectDistinct(dt, "PerusahaanBaru");
                }
            }
            else
            {
                query = new SPQuery();
                query.Query = "<Where>" +
                                "<And>" +
                                    "<Contains>" +
                                        "<FieldRef Name='LK_x003a_NamaPerusahaan' />" +
                                        "<Value Type='Lookup'>" + txtSearch.Text.Trim() + "</Value>" +
                                    "</Contains>" +
                                    "<Eq>" +
                                        "<FieldRef Name='LK_x003a_ApprovalStatus' />" +
                                        "<Value Type='Text'>Approved</Value>" +
                                    "</Eq>" +
                                "</And>" +
                              "</Where>" +
                              "<OrderBy>" +
                                 "<FieldRef Name='Created' Ascending='False' />" +
                              "</OrderBy>";
                query.ViewFieldsOnly = true;
                query.ViewAttributes = "Scope=\"Recursive\"";

                if (Type == "siup")
                {
                    query.ViewFields = string.Concat("<FieldRef Name='ID' />",
                                                     "<FieldRef Name='Title' />",
                                                     "<FieldRef Name='LK_x003a_NamaPerusahaan' />",
                                                     "<FieldRef Name='SIUP' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "SIUPDokumen"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "SIUP");
                }
                else if (Type == "tdp")
                {
                    query.ViewFields = string.Concat("<FieldRef Name='ID' />",
                                                      "<FieldRef Name='Title' />",
                                                      "<FieldRef Name='LK_x003a_NamaPerusahaan' />",
                                                      "<FieldRef Name='TDP' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "TDPDokumen"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "TDP");
                }
                else if (Type == "surat persetujuan pma / pmdn baru")
                {

                }
                else if (Type == "perubahan pt biasa menjadi pma / pmdn")
                {
                  
                }
                else if (Type == "surat izin usaha")
                {
                    
                }
            }

            grv.DataSource = dt;
            grv.DataBind();

            BindDokumen();
            upDokumen.Update();
        }

        protected void imgbtnNamaDokumen_Click(object sender, ImageClickEventArgs e)
        {
            BindTipeDokumen(ddlTipeDokumen);
            txtSearch.Text = string.Empty;
            grv.Visible = false;
        }

        protected void ddlTipeDokumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSearchDocument();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSearchDocument();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BindDokumen();
            upDokumen.Update();

            if (Request.Form["rb"] != null)
            {
                string Document = Request.Form["rb"].ToString();
                if (ViewState["Index"] != null)
                {
                    int Index = Convert.ToInt32(ViewState["Index"]);
                    string[] split = Document.Split(';');

                    if (Index != -1)
                    {
                        if (dgDokumen.Items.Count > 0)
                        {
                            TextBox txtNamaDokumenEdit = dgDokumen.Items[Index].FindControl("txtNamaDokumenEdit") as TextBox;
                            txtNamaDokumenEdit.Text = split[0];

                            DropDownList ddlTipeDokumenEdit = dgDokumen.Items[Index].FindControl("ddlTipeDokumenEdit") as DropDownList;
                            ddlTipeDokumenEdit.SelectedValue = split[1];
                        }
                    }
                    else
                    {
                        ddlTipeDokumenAdd.SelectedValue = split[1];
                        txtNamaDokumenAdd.Text = split[0];
                    }
                    upDokumen.Update();
                }
                Util.RegisterStartupScript(Page, "closeDocument", "closeDialog('divDocumentSearch');");
            }
            else
                Util.ShowMessage(Page, "Please choose Document");
        }

        protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItemIndex < 0)
                return;

            DataRowView dr = e.Row.DataItem as DataRowView;
            Literal ltrStatus = e.Row.FindControl("ltrStatus") as Literal;

            bool result = isAvailable(dr["Title"].ToString(), Convert.ToInt32(ddlTipeDokumen.SelectedValue));
            if (result)
            {
                Literal ltrrb = e.Row.FindControl("ltrrb") as Literal;
                ltrrb.Text = string.Format("<input type='radio' name='rb' id='Row{0}' value='{0};{1}' />", dr["Title"].ToString(), ddlTipeDokumen.SelectedValue);

                ltrStatus.Text = "Available";
            }
            else
                ltrStatus.Text = "Borrowed";
        }

        protected void grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv.PageIndex = e.NewPageIndex;
            BindSearchDocument();
        }

        #endregion

        #endregion
    }
}
