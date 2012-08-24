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
using Microsoft.SharePoint.Workflow;

namespace SPVisionet.CorporateSecretary.WebParts.PermintaanDokumen
{
    public partial class PermintaanDokumenUserControl : UserControl
    {
        #region Properties

        private SPWeb web;
        private int IDP = 0;
        private string Source = string.Empty;
        private string Mode = string.Empty;
        private DropDownList ddlTipeDokumenAdd = null;
        private HyperLink hypDocumentUrlAdd = null;
        private Label lblNamaFileAdd = null;
        private const string CUSTODIAN = Roles.CUSTODIAN;
        private const string CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN = Roles.CUSTODIAN + " Update Tanggal Estimasi Pengembalian";
        private const string CHIEF_LEGAL_AND_DIV_HEAD_APPROVAL = "Chief Legal and Div Head Approval";
        private const string APPROVED = "Approved";

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
            public bool StatusTidakDikembalikan { get; set; }
            public string FileUrl { get; set; }
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
                                        "<FieldRef Name='StatusTidakDiKembalikan' />" +
                                        "<Value Type='Boolean'>0</Value>" +
                                    "</Eq>" +
                                 "</And>" +
                                 "<IsNotNull>" +
                                      "<FieldRef Name='TanggalEstimasiPengembalian' />" +
                                 "</IsNotNull>" +
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

        private string DokumentValidation(Label lblNamaFile, DropDownList ddlTipeDokumen, DropDownList ddlSoftcopyOriginal, TextBox txtTujuanPeminjaman, DateTimeControl dtTglDibutuhkan)
        {
            StringBuilder sb = new StringBuilder();

            if (lblNamaFile.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Nama Dokumen") + " \\n");
            if (ddlTipeDokumen.SelectedValue == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Tipe Dokumen") + " \\n");
            if (ddlSoftcopyOriginal.SelectedValue == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Softcopy/Original") + " \\n");
            if (txtTujuanPeminjaman.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Tujuan Peminjaman") + " \\n");
            if (dtTglDibutuhkan.IsDateEmpty || dtTglDibutuhkan.ErrorMessage != null)
                sb.Append(SR.FieldCanNotEmpty("Tanggal dibutuhkan") + " \\n");

            //if (ViewState["Status"].ToString() == CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN)
            //{
            //    if (dtTglEstimasiPengembalian.IsDateEmpty || dtTglEstimasiPengembalian.ErrorMessage != null)
            //        sb.Append(SR.FieldCanNotEmpty("Tanggal Estimasi Pengembalian") + " \\n");

            //    if (!dtTglEstimasiPengembalian.IsDateEmpty)
            //    {
            //        int i = DateTime.Compare(dtTglDibutuhkan.SelectedDate, dtTglEstimasiPengembalian.SelectedDate);
            //        if (i > 0)
            //            sb.Append("Tanggal Estimasi Pengembalian must be greater or equal than Tanggal dibutuhkan\\n");
            //    }
            //}

            return sb.ToString();
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty)
            {
                if (peNamaPeminjam.Accounts.Count == 0)
                    sb.Append(SR.FieldCanNotEmpty("Nama Peminjam") + " \\n");
                else
                {
                    if (peNamaPeminjam.Accounts.Count >= 2)
                        sb.Append("Only one Nama Peminjam can be selected \\n");
                }
            }
            if (dgDokumen.Items.Count == 0)
                sb.Append("At least one data must be inserted in Document Grid \\n");
            else
            {
                foreach (DataGridItem dgItem in dgDokumen.Items)
                {
                    Label lblSoftcopyOriginal = dgItem.FindControl("lblSoftcopyOriginal") as Label;
                    Label lblNamaFile = dgItem.FindControl("lblNamaFile") as Label;
                    Label lblTanggaldibutuhkan = dgItem.FindControl("lblTanggaldibutuhkan") as Label;
                    DateTimeControl dtTanggalEstimasiPengembalian = dgItem.FindControl("dtTanggalEstimasiPengembalian") as DateTimeControl;
                    DateTimeControl dtTanggalPengembalian = dgItem.FindControl("dtTanggalPengembalian") as DateTimeControl;
                    CheckBox chkStatusTidakDikembalikan = dgItem.FindControl("chkStatusTidakDikembalikan") as CheckBox;

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty || ViewState["Status"].ToString() == CUSTODIAN)
                    {
                        if (lblTanggaldibutuhkan.Text.Trim() == string.Empty)
                            sb.Append(SR.FieldCanNotEmpty("Tanggal dibutuhkan for " + lblNamaFile.Text) + "\\n");
                    }
                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN)
                    {
                        if (lblSoftcopyOriginal.Text.ToLower() == "original")
                        {
                            if (dtTanggalEstimasiPengembalian.IsDateEmpty || dtTanggalEstimasiPengembalian.ErrorMessage != null)
                                sb.Append(SR.FieldCanNotEmpty("Tanggal Estimasi Pengembalian for " + lblNamaFile.Text) + "\\n");
                            else
                            {
                                int i = DateTime.Compare(Convert.ToDateTime(lblTanggaldibutuhkan.Text), dtTanggalEstimasiPengembalian.SelectedDate);
                                if (i > 0)
                                    sb.Append("Tanggal Estimasi Pengembalian must be greater or equal than Tanggal Dibutuhkan\\n");
                            }
                        }
                    }
                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == APPROVED)
                    {
                        if (!chkStatusTidakDikembalikan.Checked)
                        {
                            if (dtTanggalPengembalian.IsDateEmpty || dtTanggalPengembalian.ErrorMessage != null)
                                sb.Append(SR.FieldCanNotEmpty("Tanggal Pengembalian for " + lblNamaFile.Text) + "\\n");
                            //else
                            //{
                            //    int i = DateTime.Compare(dtTanggalEstimasiPengembalian.SelectedDate, dtTanggalPengembalian.SelectedDate);
                            //    if (i > 0)
                            //        sb.Append("Tanggal Pengembalian must be greater or equal than Tanggal Estimasi Pengembalian\\n");
                            //}
                        }
                    }
                }
            }
            return sb.ToString();
        }

        private bool isExistInGrid(string NamaDokumen, string TipeDokumen, string SoftcopyOriginal)
        {
            foreach (DataGridItem item in dgDokumen.Items)
            {
                Label lblNamaFile = item.FindControl("lblNamaFile") as Label;
                Label lblTipeDokumen = item.FindControl("lblTipeDokumen") as Label;
                Label lblSoftcopyOriginal = item.FindControl("lblSoftcopyOriginal") as Label;

                if (lblNamaFile != null && lblTipeDokumen != null && lblSoftcopyOriginal != null)
                {
                    if (lblNamaFile.Text.Trim().ToLower() == NamaDokumen.Trim().ToLower() && lblTipeDokumen.Text.Trim().ToLower() == TipeDokumen.ToLower() && lblSoftcopyOriginal.Text.Trim().ToLower() == SoftcopyOriginal.ToLower())
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
            else
            {
                if (item["ApprovalStatus"] != null)
                    ViewState["Status"] = item["ApprovalStatus"].ToString();
            }

            if (item.Workflows.Count > 0 || ViewState["Status"].ToString() == "Approved")
                btnSaveUpdateRunWf.Visible = false;

            if (mode == "edit")
            {
                btnSaveUpdate.Text = "Update";
                btnSaveUpdateRunWf.Text = "Update & Run Workflow";
            }
            else if (mode == "display")
            {
                btnSaveUpdate.Visible = false;
                btnSaveUpdateRunWf.Visible = false;
            }

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
                if (i["StatusTidakDiKembalikan"] != null)
                    o.StatusTidakDikembalikan = Convert.ToBoolean(i["StatusTidakDiKembalikan"]);
                o.TipeDokumen = i["TipeDokumen"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                o.TujuanPeminjaman = i["TujuanPeminjaman"].ToString();
                if (i["FileUrl"] != null)
                    o.FileUrl = i["FileUrl"].ToString().Split(',')[0];
                collDokument.Add(o);
            }
            ViewState["Dokument"] = collDokument;
            ViewState["DokumentEdit"] = collDokument;
            BindDokumen();

            HiddenControls(mode, ViewState["Status"].ToString());
        }

        private void HiddenControls(string mode, string status)
        {
            if (mode == "display")
            {
                txtKeterangan.Visible = false;
                peNamaPeminjam.Visible = false;

                dgDokumen.ShowFooter = false;
                dgDokumen.Columns[12].Visible = false;

                if (Convert.ToBoolean(ViewState["Admin"]) == true)
                {
                    dgDokumen.Columns[6].Visible = false;
                    dgDokumen.Columns[8].Visible = false;
                    dgDokumen.Columns[10].Visible = false;

                    dgDokumen.Columns[7].Visible = true;
                    dgDokumen.Columns[9].Visible = true;
                    dgDokumen.Columns[11].Visible = true;
                }
                else
                {
                    if (status == CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN)
                        dgDokumen.Columns[7].Visible = true;
                    if (status == APPROVED)
                    {
                        dgDokumen.Columns[7].Visible = true;
                        dgDokumen.Columns[9].Visible = true;
                        dgDokumen.Columns[11].Visible = true;
                    }
                }
            }
            else if (mode == "edit")
            {
                if (Convert.ToBoolean(ViewState["Admin"]) == true || status == string.Empty)
                {
                    ltrKeterangan.Visible = false;
                    ltrNamaPeminjam.Visible = false;
                }
                else if (Convert.ToBoolean(ViewState["Admin"]) == false)
                {
                    peNamaPeminjam.Visible = false;
                    txtKeterangan.Visible = false;

                    ltrKeterangan.Visible = true;
                    ltrNamaPeminjam.Visible = true;

                    if (status == CHIEF_LEGAL_AND_DIV_HEAD_APPROVAL)
                        dgDokumen.Columns[12].Visible = false;
                    else if (status == CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN)
                    {
                        dgDokumen.Columns[6].Visible = true;
                        dgDokumen.Columns[12].Visible = false;
                    }
                    else if (status == APPROVED)
                    {
                        dgDokumen.Columns[7].Visible = true;
                        dgDokumen.Columns[8].Visible = true;
                        dgDokumen.Columns[10].Visible = true;
                        dgDokumen.Columns[12].Visible = false;
                    }
                    dgDokumen.ShowFooter = false;
                }
            }
        }

        private string SaveUpdate(string mode)
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

                int j = 0;
                if (IDP == 0)
                {
                    List<Dokument> coll = ViewState["Dokument"] as List<Dokument>;
                    foreach (Dokument i in coll)
                    {
                        SPListItem itemDocument;
                        if (i.ID == 0)
                        {
                            itemDocument = listDocument.Items.Add();
                            itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        }
                        else
                        {
                            itemDocument = listDocument.GetItemById(i.ID);
                            itemDocument["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        }

                        itemDocument["PermintaanDokumen"] = ViewState["ID"].ToString();
                        itemDocument["Title"] = i.NamaDokumen;
                        itemDocument["TipeDokumen"] = i.IDTipeDokumen;
                        itemDocument["SoftcopyOriginal"] = i.SoftcopyOriginal;
                        itemDocument["TujuanPeminjaman"] = i.TujuanPeminjaman;
                        itemDocument["TanggalDibutuhkan"] = i.TanggalDibutuhkan;
                        SPFieldUrlValue fieldURL = new SPFieldUrlValue();
                        fieldURL.Url = i.FileUrl;
                        fieldURL.Description = i.NamaDokumen;
                        itemDocument["FileUrl"] = fieldURL;
                        if (Convert.ToBoolean(ViewState["Admin"]) == true)
                        {
                            DateTimeControl dtTanggalEstimasiPengembalian = dgDokumen.Items[j].FindControl("dtTanggalEstimasiPengembalian") as DateTimeControl;
                            DateTimeControl dtTanggalPengembalian = dgDokumen.Items[j].FindControl("dtTanggalPengembalian") as DateTimeControl;
                            CheckBox chkStatusTidakDikembalikan = dgDokumen.Items[j].FindControl("chkStatusTidakDikembalikan") as CheckBox;

                            itemDocument["TanggalEstimasiPengembalian"] = dtTanggalEstimasiPengembalian.SelectedDate;
                            itemDocument["StatusTidakDiKembalikan"] = chkStatusTidakDikembalikan.Checked;
                            if (chkStatusTidakDikembalikan.Checked)
                                itemDocument["TanggalPengembalian"] = null;
                            else
                                itemDocument["TanggalPengembalian"] = dtTanggalPengembalian.SelectedDate;
                        }
                        itemDocument.Update();

                        coll[j].ID = itemDocument.ID;

                        j += 1;
                    }
                }
                else
                {
                    if (dgDokumen.Items.Count > 0)
                    {
                        j = 0;
                        List<Dokument> coll = ViewState["Dokument"] as List<Dokument>;
                        foreach (Dokument i in coll)
                        {
                            SPListItem itemDocument;
                            if (i.ID != 0)
                            {
                                itemDocument = listDocument.GetItemById(i.ID);
                                itemDocument["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemDocument = listDocument.Items.Add();
                                itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemDocument["PermintaanDokumen"] = ViewState["ID"].ToString();
                            itemDocument["Title"] = i.NamaDokumen;
                            itemDocument["TipeDokumen"] = i.IDTipeDokumen;
                            itemDocument["SoftcopyOriginal"] = i.SoftcopyOriginal;
                            itemDocument["TujuanPeminjaman"] = i.TujuanPeminjaman;
                            itemDocument["TanggalDibutuhkan"] = i.TanggalDibutuhkan;
                            SPFieldUrlValue fieldURL = new SPFieldUrlValue();
                            fieldURL.Url = i.FileUrl;
                            fieldURL.Description = i.NamaDokumen;
                            itemDocument["FileUrl"] = fieldURL;

                            DateTimeControl dtTanggalEstimasiPengembalian = dgDokumen.Items[j].FindControl("dtTanggalEstimasiPengembalian") as DateTimeControl;
                            DateTimeControl dtTanggalPengembalian = dgDokumen.Items[j].FindControl("dtTanggalPengembalian") as DateTimeControl;
                            CheckBox chkStatusTidakDikembalikan = dgDokumen.Items[j].FindControl("chkStatusTidakDikembalikan") as CheckBox;

                            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN)
                                itemDocument["TanggalEstimasiPengembalian"] = dtTanggalEstimasiPengembalian.SelectedDate;
                            if (ViewState["Status"].ToString() == APPROVED)
                            {
                                itemDocument["TanggalEstimasiPengembalian"] = dtTanggalEstimasiPengembalian.SelectedDate;
                                itemDocument["StatusTidakDiKembalikan"] = chkStatusTidakDikembalikan.Checked;
                                if (chkStatusTidakDikembalikan.Checked)
                                    itemDocument["TanggalPengembalian"] = null;
                                else
                                    itemDocument["TanggalPengembalian"] = dtTanggalPengembalian.SelectedDate;
                            }
                            itemDocument.Update();

                            coll[j].ID = itemDocument.ID;

                            j += 1;
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

                if (item["Status"] == null)
                {
                    if (mode == "SaveRunWf")
                    {
                        if (list.WorkflowAssociations.Count > 0)
                        {
                            string WfId = Util.GetSettingValue(web, "Workflow BasedId", "Permintaan Dokumen");
                            Guid wfBaseId = new Guid(WfId);
                            SPWorkflowAssociation associationTemplate = list.WorkflowAssociations.GetAssociationByBaseID(wfBaseId);
                            currentWeb.Site.WorkflowManager.StartWorkflow(item, associationTemplate, associationTemplate.AssociationData, true);
                        }
                    }
                }
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

            using (SPSite site = new SPSite(SPContext.Current.Web.Url, SPContext.Current.Site.SystemAccount.UserToken))
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

                        string AdministratorGroup = Util.GetSettingValue(web, "SharePoint Group", "Administrator");
                        ViewState["Admin"] = Util.IsUserExistInSharePointGroup(web, SPContext.Current.Web.CurrentUser.LoginName, AdministratorGroup);
                        if (Convert.ToBoolean(ViewState["Admin"]) == true)
                        {
                            dgDokumen.Columns[6].Visible = true;
                            dgDokumen.Columns[8].Visible = true;
                            dgDokumen.Columns[10].Visible = true;
                        }

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

                    try
                    {
                        if (peNamaPeminjam.Accounts.Count == 1)
                        {
                            SPUser namaPeminjam = web.Site.RootWeb.SiteUsers[peNamaPeminjam.CommaSeparatedAccounts];
                            ltrDivisiPeminjam.Text = Util.GetDepartment(web, namaPeminjam.ID);
                        }
                        else
                            ltrDivisiPeminjam.Text = string.Empty;
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected void dgDokumen_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                ddlTipeDokumenAdd = e.Item.FindControl("ddlTipeDokumenAdd") as DropDownList;
                BindTipeDokumen(ddlTipeDokumenAdd);

                hypDocumentUrlAdd = e.Item.FindControl("hypDocumentUrlAdd") as HyperLink;
                lblNamaFileAdd = e.Item.FindControl("lblNamaFileAdd") as Label;
            }
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                Dokument o = e.Item.DataItem as Dokument;

                HyperLink hypDocumentUrlEdit = e.Item.FindControl("hypDocumentUrlEdit") as HyperLink;
                hypDocumentUrlEdit.NavigateUrl = o.FileUrl;
                hypDocumentUrlEdit.Text = o.NamaDokumen;

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

                HyperLink hypDocumentUrl = e.Item.FindControl("hypDocumentUrl") as HyperLink;
                hypDocumentUrl.NavigateUrl = o.FileUrl;
                hypDocumentUrl.Text = o.NamaDokumen;

                if (o.TanggaPengembalian != null)
                {
                    Label lblTanggalPengembalian = e.Item.FindControl("lblTanggalPengembalian") as Label;
                    lblTanggalPengembalian.Text = Convert.ToDateTime(o.TanggaPengembalian).ToString("dd-MMM-yyyy");

                    DateTimeControl dtTanggalPengembalian = e.Item.FindControl("dtTanggalPengembalian") as DateTimeControl;
                    dtTanggalPengembalian.SelectedDate = Convert.ToDateTime(o.TanggaPengembalian);
                }
                if (o.TanggalEstimasiPengembalian != null)
                {
                    Label lblTanggalEstimasiPengembalian = e.Item.FindControl("lblTanggalEstimasiPengembalian") as Label;
                    lblTanggalEstimasiPengembalian.Text = Convert.ToDateTime(o.TanggalEstimasiPengembalian).ToString("dd-MMM-yyyy");

                    DateTimeControl dtTanggalEstimasiPengembalian = e.Item.FindControl("dtTanggalEstimasiPengembalian") as DateTimeControl;
                    dtTanggalEstimasiPengembalian.SelectedDate = Convert.ToDateTime(o.TanggalEstimasiPengembalian);
                }

                Label lblStatusTidakDikembalikan = e.Item.FindControl("lblStatusTidakDikembalikan") as Label;
                if (lblStatusTidakDikembalikan != null)
                    lblStatusTidakDikembalikan.Text = o.StatusTidakDikembalikan == true ? "Yes" : "No";

                CheckBox chkStatusTidakDikembalikan = e.Item.FindControl("chkStatusTidakDikembalikan") as CheckBox;
                if (chkStatusTidakDikembalikan != null)
                    chkStatusTidakDikembalikan.Checked = o.StatusTidakDikembalikan;
            }
        }

        protected void dgDokumen_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<Dokument> coll = new List<Dokument>();
            if (ViewState["Dokument"] != null)
                coll = ViewState["Dokument"] as List<Dokument>;

            if (e.CommandName == "add")
            {
                HyperLink hypDocumentUrlAdd = e.Item.FindControl("hypDocumentUrlAdd") as HyperLink;
                DropDownList ddlTipeDokumenAdd = e.Item.FindControl("ddlTipeDokumenAdd") as DropDownList;
                DropDownList ddlSoftcopyOriginalAdd = e.Item.FindControl("ddlSoftcopyOriginalAdd") as DropDownList;
                TextBox txtTujuanPeminjamanAdd = e.Item.FindControl("txtTujuanPeminjamanAdd") as TextBox;
                DateTimeControl dtTanggaldibutuhkanAdd = e.Item.FindControl("dtTanggaldibutuhkanAdd") as DateTimeControl;
                Label lblNamaFileAdd = e.Item.FindControl("lblNamaFileAdd") as Label;

                string msg = DokumentValidation(lblNamaFileAdd, ddlTipeDokumenAdd, ddlSoftcopyOriginalAdd, txtTujuanPeminjamanAdd, dtTanggaldibutuhkanAdd);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                if (isExistInGrid(lblNamaFileAdd.Text, ddlTipeDokumenAdd.SelectedItem.Text, ddlSoftcopyOriginalAdd.SelectedValue))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(lblNamaFileAdd.Text.Trim()));
                    return;
                }

                Dokument o = new Dokument();
                o.NamaDokumen = lblNamaFileAdd.Text.Trim();
                o.IDTipeDokumen = Convert.ToInt32(ddlTipeDokumenAdd.SelectedValue);
                o.TipeDokumen = ddlTipeDokumenAdd.SelectedItem.Text;
                o.SoftcopyOriginal = ddlSoftcopyOriginalAdd.SelectedValue;
                o.TujuanPeminjaman = txtTujuanPeminjamanAdd.Text.Trim();
                o.TanggalDibutuhkan = dtTanggaldibutuhkanAdd.SelectedDate;
                o.FileUrl = hypDocumentUrlAdd.NavigateUrl;

                o.ID = 0;
                coll.Add(o);

                ViewState["Dokument"] = coll;
            }
            if (e.CommandName == "save")
            {
                HyperLink hypDocumentUrlEdit = e.Item.FindControl("hypDocumentUrlEdit") as HyperLink;
                DropDownList ddlTipeDokumenEdit = e.Item.FindControl("ddlTipeDokumenEdit") as DropDownList;
                DropDownList ddlSoftcopyOriginalEdit = e.Item.FindControl("ddlSoftcopyOriginalEdit") as DropDownList;
                TextBox txtTujuanPeminjamanEdit = e.Item.FindControl("txtTujuanPeminjamanEdit") as TextBox;
                DateTimeControl dtTanggaldibutuhkanEdit = e.Item.FindControl("dtTanggaldibutuhkanEdit") as DateTimeControl;
                Label lblNamaFileEdit = e.Item.FindControl("lblNamaFileEdit") as Label;

                string msg = DokumentValidation(lblNamaFileEdit, ddlTipeDokumenEdit, ddlSoftcopyOriginalEdit, txtTujuanPeminjamanEdit, dtTanggaldibutuhkanEdit);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                if (isExistInGrid(lblNamaFileEdit.Text, ddlTipeDokumenEdit.SelectedItem.Text, ddlSoftcopyOriginalEdit.SelectedValue))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(lblNamaFileEdit.Text.Trim()));
                    return;
                }

                Dokument o = new Dokument();
                o.NamaDokumen = lblNamaFileEdit.Text.Trim();
                o.IDTipeDokumen = Convert.ToInt32(ddlTipeDokumenEdit.SelectedValue);
                o.TipeDokumen = ddlTipeDokumenEdit.SelectedItem.Text;
                o.SoftcopyOriginal = ddlSoftcopyOriginalEdit.SelectedValue;
                o.TujuanPeminjaman = txtTujuanPeminjamanEdit.Text.Trim();
                o.TanggalDibutuhkan = dtTanggaldibutuhkanEdit.SelectedDate;
                o.FileUrl = hypDocumentUrlEdit.NavigateUrl;

                coll[e.Item.ItemIndex] = o;
                ViewState["Dokument"] = coll;

                dgDokumen.EditItemIndex = -1;
                if (ViewState["Status"].ToString() == CUSTODIAN)
                    dgDokumen.ShowFooter = false;
                else
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
                if (ViewState["Status"].ToString() == CUSTODIAN)
                    dgDokumen.ShowFooter = false;
                else
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

        private void SaveAction(string mode)
        {
            string msg = Validation();
            if (msg != string.Empty)
            {
                Util.ShowMessage(Page, msg);
                return;
            }

            string result = SaveUpdate(mode);
            if (result == string.Empty)
            {
                if (Source != string.Empty)
                    SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
                else
                    Response.Redirect(string.Format("{0}/Lists/PermintaanDokumen", web.Url), true);
            }
            else
                Util.ShowMessage(Page, result);
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            SaveAction("Save");
        }

        protected void btnSaveUpdateRunWf_Click(object sender, EventArgs e)
        {
            SaveAction("SaveRunWf");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect(string.Format("{0}/Lists/PermintaanDokumen", web.Url), true);
        }

        #region Search Document

        private string DocumentUrl(int DocumentID)
        {
            SPQuery query;
            string Type = ddlTipeDokumen.SelectedItem.Text.ToLower();
            if (Type == "akta and sk pengesahan pendirian" || Type == "apv" || Type == "bnri" || Type == "npwp" || Type == "pkp" || Type == "setoran modal" || Type == "skdp" || Type == "apv")
            {
                query = new SPQuery();
                query.Query = "<Where>" +
                                 "<And>" +
                                    "<Eq>" +
                                        "<FieldRef Name='ID' />" +
                                        "<Value Type='Counter'>" + DocumentID.ToString() + "</Value>" +
                                    "</Eq>" +
                                    "<Eq>" +
                                        "<FieldRef Name='DocumentType' />" +
                                        "<Value Type='Text'>" + Type + "</Value>" +
                                    "</Eq>" +
                                "</And>" +
                              "</Where>";
                query.ViewAttributes = "Scope=\"Recursive\"";

                SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
                SPListItemCollection coll = list.GetItems(query);
                if (coll.Count > 0)
                {
                    SPListItem item = coll[0];
                    string RequestCode = item["LK_x003a_RequestCode"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    return string.Format("{0}/PerusahaanBaruDokumen/{1}/{2}", web.Url, RequestCode, item["Name"].ToString());
                }
            }
            else
            {
                if (Type == "siup")
                {
                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "SIUPDokumen"));
                    SPListItem item = list.GetItemById(DocumentID);
                    if (item != null)
                    {
                        return string.Format("{0}/SIUPDokumen/{1}", web.Url, item["Name"].ToString());
                    }
                }
                else if (Type == "tdp")
                {
                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "TDPDokumen"));
                    SPListItem item = list.GetItemById(DocumentID);
                    if (item != null)
                    {
                        return string.Format("{0}/TDPDokumen/{1}", web.Url, item["Name"].ToString());
                    }
                }
                else if (Type == "surat persetujuan pma / pmdn baru")
                {
                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PendaftaranPMAPMDNDokumen"));
                    SPListItem item = list.GetItemById(DocumentID);
                    if (item != null)
                    {
                        return string.Format("{0}/PendaftaranPMAPMDNDokumen/{1}", web.Url, item["Name"].ToString());
                    }
                }
                else if (Type == "perubahan pt biasa menjadi pma / pmdn")
                {
                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDNDokumen"));
                    SPListItem item = list.GetItemById(DocumentID);
                    if (item != null)
                    {
                        return string.Format("{0}/PerubahanPTBiasaMenjadiPMAPMDNDokumen/{1}", web.Url, item["Name"].ToString());
                    }
                }
                else if (Type == "surat izin usaha")
                {
                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "IzinUsahaDokumen"));
                    SPListItem item = list.GetItemById(DocumentID);
                    if (item != null)
                    {
                        return string.Format("{0}/IzinUsahaDokumen/{1}", web.Url, item["Name"].ToString());
                    }
                }
                else if (Type == "sertifikat" || Type == "asset" || Type == "insurance" || Type == "ijin operasional" || Type == "compliance")
                {
                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "DokumenLainnya"));
                    SPListItem item = list.GetItemById(DocumentID);
                    if (item != null)
                    {
                        return string.Format("{0}/DokumenLainnya/{1}'>", web.Url, item["Name"].ToString());
                    }
                }
            }
            return string.Empty;
        }

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
                                                 "<FieldRef Name='LinkFilename' />",
                                                 "<FieldRef Name='LK_x003a_RequestCode' />",
                                                 "<FieldRef Name='PerusahaanBaru' />");

                query.ViewFieldsOnly = true;
                query.ViewAttributes = "Scope=\"Recursive\"";

                SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
                dt = list.GetItems(query).GetDataTable();

                if (Type != "bnri" || Type != "akta and sk pengesahan pendirian")
                {
                    if (dt != null)
                        dt = SelectDistinct(dt, "PerusahaanBaru");
                }
                ViewState["ListName"] = "PerusahaanBaruDokumen";
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
                                                     "<FieldRef Name='LinkFilename' />",
                                                     "<FieldRef Name='SIUP' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "SIUPDokumen"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "SIUP");

                    ViewState["ListName"] = "SIUPDokumen";
                }
                else if (Type == "tdp")
                {
                    query.ViewFields = string.Concat("<FieldRef Name='ID' />",
                                                      "<FieldRef Name='Title' />",
                                                      "<FieldRef Name='LK_x003a_NamaPerusahaan' />",
                                                      "<FieldRef Name='LinkFilename' />",
                                                      "<FieldRef Name='TDP' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "TDPDokumen"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "TDP");

                    ViewState["ListName"] = "TDPDokumen";
                }
                else if (Type == "surat persetujuan pma / pmdn baru")
                {
                    query.ViewFields = string.Concat("<FieldRef Name='ID' />",
                                                     "<FieldRef Name='Title' />",
                                                     "<FieldRef Name='LK_x003a_NamaPerusahaan' />",
                                                     "<FieldRef Name='LinkFilename' />",
                                                     "<FieldRef Name='PendaftaranPMAPMDN' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PendaftaranPMAPMDNDokumen"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "PendaftaranPMAPMDN");

                    ViewState["ListName"] = "PendaftaranPMAPMDNDokumen";
                }
                else if (Type == "perubahan pt biasa menjadi pma / pmdn")
                {
                    query.ViewFields = string.Concat("<FieldRef Name='ID' />",
                                                      "<FieldRef Name='Title' />",
                                                      "<FieldRef Name='LK_x003a_NamaPerusahaan' />",
                                                      "<FieldRef Name='LinkFilename' />",
                                                      "<FieldRef Name='PerubahanPTBiasaMenjadiPMAPMDN' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDNDokumen"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "PerubahanPTBiasaMenjadiPMAPMDN");

                    ViewState["ListName"] = "PerubahanPTBiasaMenjadiPMAPMDNDokumen";
                }
                else if (Type == "surat izin usaha")
                {
                    query.ViewFields = string.Concat("<FieldRef Name='ID' />",
                                                      "<FieldRef Name='Title' />",
                                                      "<FieldRef Name='LK_x003a_NamaPerusahaan' />",
                                                      "<FieldRef Name='LinkFilename' />",
                                                      "<FieldRef Name='IzinUsaha' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "IzinUsahaDokumen"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "IzinUsaha");

                    ViewState["ListName"] = "IzinUsahaDokumen";
                }
                else if (Type == "sertifikat" || Type == "asset" || Type == "insurance" || Type == "ijin operasional" || Type == "compliance")
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
                                            "<FieldRef Name='TipeDokumen' />" +
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
                                                      "<FieldRef Name='LinkFilename' />",
                                                      "<FieldRef Name='PerusahaanBaru' />");

                    SPList list = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "DokumenLainnya"));
                    dt = list.GetItems(query).GetDataTable();
                    if (dt != null)
                        dt = SelectDistinct(dt, "PerusahaanBaru");

                    ViewState["ListName"] = "DokumenLainnya";
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
                            HyperLink hypDocumentUrlEdit = dgDokumen.Items[Index].FindControl("hypDocumentUrlEdit") as HyperLink;
                            hypDocumentUrlEdit.NavigateUrl = DocumentUrl(Convert.ToInt32(split[2]));
                            hypDocumentUrlEdit.Text = split[0];

                            DropDownList ddlTipeDokumenEdit = dgDokumen.Items[Index].FindControl("ddlTipeDokumenEdit") as DropDownList;
                            ddlTipeDokumenEdit.SelectedValue = split[1];

                            Label lblNamaFileEdit = dgDokumen.Items[Index].FindControl("lblNamaFileEdit") as Label;
                            lblNamaFileEdit.Text = split[0];
                        }
                    }
                    else
                    {
                        lblNamaFileAdd.Text = split[0];
                        ddlTipeDokumenAdd.SelectedValue = split[1];
                        hypDocumentUrlAdd.NavigateUrl = DocumentUrl(Convert.ToInt32(split[2]));
                        hypDocumentUrlAdd.Text = lblNamaFileAdd.Text;
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
            HyperLink hyp = e.Row.FindControl("hyp") as HyperLink;

            bool result = isAvailable(dr["Title"].ToString(), Convert.ToInt32(ddlTipeDokumen.SelectedValue));
            if (result)
            {
                Literal ltrrb = e.Row.FindControl("ltrrb") as Literal;
                ltrrb.Text = string.Format("<input type='radio' name='rb' id='Row{0}' value='{0};{1};{2}' />", dr["LinkFilename"].ToString(), ddlTipeDokumen.SelectedValue, dr["ID"].ToString());

                ltrStatus.Text = "Available";
            }
            else
                ltrStatus.Text = "Borrowed";

            if (ViewState["ListName"].ToString() == "PerusahaanBaruDokumen")
            {
                hyp.NavigateUrl = string.Format("{0}/{1}/{2}/{3}", web.Url, ViewState["ListName"].ToString(), dr["LK_x003a_RequestCode"].ToString(), dr["LinkFilename"].ToString());
                hyp.Text = dr["LinkFilename"].ToString();
            }
            else
            {
                hyp.NavigateUrl = string.Format("{0}/{1}/{2}", web.Url, ViewState["ListName"].ToString(), dr["LinkFilename"].ToString());
                hyp.Text = dr["LinkFilename"].ToString();
            }
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
