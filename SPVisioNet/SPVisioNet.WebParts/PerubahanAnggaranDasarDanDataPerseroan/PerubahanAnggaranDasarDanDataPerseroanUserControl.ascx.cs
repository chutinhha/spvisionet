using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data;
using SPVisionet.CorporateSecretary.Common;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Text;
using System.IO;
using Microsoft.SharePoint.WebControls;
using Microsoft.Office.DocumentManagement.DocumentSets;
using Microsoft.SharePoint.Workflow;

namespace SPVisioNet.WebParts.PerubahanAnggaranDasarDanDataPerseroan
{
    /// <summary>
    /// PerubahanAnggaranDasarDanDataPerseroanUserControl
    /// </summary>
    public partial class PerubahanAnggaranDasarDanDataPerseroanUserControl : UserControl
    {
        #region Properties
        private SPWeb web;

        private int IDP = 0;
        private string CodeName = "ADP"; //PERUBAHAN_ANGGARAN_DASAR_DAN_DATA_PERUSAHAAN
        private string Source = string.Empty;
        private string[] StepWF = { "Entry Perubahan Anggaran Dasar", "Approve oleh Authorized Person", "PIC Update Akta", "PIC Upload SKDP", "PIC Upload NPWP dan SKT", "PIC Upload APV", "PIC Upload Setoran Modal", "PIC Upload SK Persetujuan" };

        /// <summary>
        /// WewenangDireksi
        /// </summary>
        [Serializable]
        private class WewenangDireksi
        {
            public int ID { get; set; }
            public string Nama { get; set; }
        }

        /// <summary>
        /// KomisarisDireksi
        /// </summary>
        [Serializable]
        private class KomisarisDireksi
        {
            public int ID { get; set; }
            public string Nama { get; set; }
            public string Jabatan { get; set; }
            public int IDJabatan { get; set; }
            public string NoKTP { get; set; }
            public string NoNPWP { get; set; }
            public DateTime? MulaiMenjabat { get; set; }
            public DateTime? AkhirMenjabat { get; set; }
            public bool IsDeleted { get; set; }
        }

        /// <summary>
        /// PemegangSaham
        /// </summary>
        [Serializable]
        private class PemegangSaham
        {
            public int ID { get; set; }
            public string Nama { get; set; }
            public double JumlahSaham { get; set; }
            public double JumlahNominal { get; set; }
            public double Percentages { get; set; }
            public bool Partner { get; set; }
            public DateTime? MulaiMenjabat { get; set; }
            public DateTime? AkhirMenjabat { get; set; }
            public bool IsDeleted { get; set; }
        }

        /// <summary>
        /// NPWP
        /// </summary>
        [Serializable]
        private class NPWP
        {
            public int ID { get; set; }
            public string NoNPWP { get; set; }
            public string Keterangan { get; set; }
            public string NamaFile { get; set; }
            public byte[] Attachment { get; set; }
            public string Url { get; set; }
            public bool IsDeleted { get; set; }
        }

        /// <summary>
        /// Dokumen
        /// </summary>
        [Serializable]
        private class Dokumen
        {
            public int ID { get; set; }
            public string TipeDokumen { get; set; }
            public string Penjelasan { get; set; }
            public string NamaFile { get; set; }
            public byte[] Attachment { get; set; }
            public string Url { get; set; }
        }

        /// <summary>
        /// PKP
        /// </summary>
        [Serializable]
        private class PKP
        {
            public int ID { get; set; }
            public string NoPKP { get; set; }
            public string Keterangan { get; set; }
            public string NamaFile { get; set; }
            public byte[] Attachment { get; set; }
            public string Url { get; set; }
        }

        #endregion


        #region Methods
        private void BindMataUang()
        {
            DataTable dt = Util.GetMataUang(web);
            ddlMataUang.DataTextField = "Title";
            ddlMataUang.DataValueField = "ID";
            ddlMataUang.DataSource = dt;
            ddlMataUang.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlMataUang.Items.Insert(0, item);

        }

        private void BindTempatKedudukan()
        {
            DataTable dt = Util.GetTempatKedudukan(web);
            ddlTempatKedudukan.DataTextField = "Title";
            ddlTempatKedudukan.DataValueField = "ID";
            ddlTempatKedudukan.DataSource = dt;
            ddlTempatKedudukan.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlTempatKedudukan.Items.Insert(0, item);
        }

        private void BindMaksudDanTujuan()
        {
            DataTable dt = Util.GetMaksudTujuan(web);
            ddlMaksudDanTujuan.DataTextField = "Title";
            ddlMaksudDanTujuan.DataValueField = "ID";
            ddlMaksudDanTujuan.DataSource = dt;
            ddlMaksudDanTujuan.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlMaksudDanTujuan.Items.Insert(0, item);
        }

        private void BindKontrol()
        {
            BindMataUang();
            BindTempatKedudukan();
            BindMaksudDanTujuan();
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (ddlMataUang.SelectedValue.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Mata Uang") + " \\n");
            if (txtModalDasarNominalMenjadi.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Modal Dasar") + " \\n");
            if (txtModalSetorNominalSemula.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Modal Setor") + " \\n");
            if (txtNominalMataUang.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Nominal") + " \\n");


            if (dgKomisaris.Items.Count == 0)
                sb.Append(SR.FieldCanNotEmpty("Komisaris and Direksi") + " \\n");
            else
            {
                foreach (DataGridItem item in dgKomisaris.Items)
                {
                    Label lblNama = item.FindControl("lblNama") as Label;
                    Label lblTanggalMulaiMenjabat = item.FindControl("lblTanggalMulaiMenjabat") as Label;
                    Label lblTanggalAkhirMenjabat = item.FindControl("lblTanggalAkhirMenjabat") as Label;

                    if (lblTanggalMulaiMenjabat.Text.Trim() == string.Empty)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Menjabat for " + lblNama.Text) + " \\n");
                    if (lblTanggalAkhirMenjabat.Text.Trim() == string.Empty)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Menjabat for " + lblNama.Text) + " \\n");
                }
            }

            if (dgPemegangSaham.Items.Count == 0)
                sb.Append(SR.FieldCanNotEmpty("Pemegang Saham") + " \\n");
            else
            {
                foreach (DataGridItem item in dgPemegangSaham.Items)
                {
                    Label lblNamaPemegangSaham = item.FindControl("lblNamaPemegangSaham") as Label;
                    Label lblTanggalMulaiMenjabat = item.FindControl("lblTanggalMulaiMenjabat") as Label;
                    Label lblTanggalAkhirMenjabat = item.FindControl("lblTanggalAkhirMenjabat") as Label;

                    if (lblTanggalMulaiMenjabat.Text.Trim() == string.Empty)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Menjabat for " + lblNamaPemegangSaham.Text) + " \\n");
                    if (lblTanggalAkhirMenjabat.Text.Trim() == string.Empty)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Menjabat for " + lblNamaPemegangSaham.Text) + " \\n");
                }

            }

            return sb.ToString();
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
                item.Web.AllowUnsafeUpdates = true;
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

        private string SaveDocument(FileUpload fu, int idPerusahaan, string Folder)
        {
            if (fu.PostedFile != null)
            {
                if (fu.PostedFile.ContentLength > 0)
                {
                    SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
                    list.ParentWeb.AllowUnsafeUpdates = true;
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(@"<Where>
                          <Eq>
                             <FieldRef Name='ID' />
                             <Value Type='Counter'>{0}</Value>
                          </Eq>
                       </Where>", idPerusahaan);
                    SPListItemCollection items = list.GetItems(query);
                    string RequestCode = items[0]["Title"].ToString();

                    string fileName = fu.FileName.Replace("&", string.Empty);

                    try
                    {
                        Stream strm = fu.PostedFile.InputStream;
                        byte[] bytes = new byte[Convert.ToInt32(fu.PostedFile.ContentLength)];
                        strm.Read(bytes, 0, Convert.ToInt32(fu.PostedFile.ContentLength));
                        strm.Close();

                        SPFolder document = web.Folders["PerusahaanBaruDokumen"].SubFolders[RequestCode];
                        SPFile file = document.Files.Add(fileName, bytes);
                        SPItem itemDocument = file.Item;
                        itemDocument["Title"] = Path.GetFileNameWithoutExtension(fileName);
                        itemDocument["PerusahaanBaru"] = idPerusahaan;
                        itemDocument["DocumentType"] = Folder;
                        itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemDocument.Update();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("already exist"))
                            return SR.DataIsExist(fileName) + " in " + Folder + " Folder";
                        else
                            return SR.AttachmentFailed(fileName) + " in " + Folder + " Folder";
                    }
                }
            }
            return string.Empty;
        }

        private void DisplayDocument(Literal ltr, int idPerusahaan, string DocumentType)
        {
            SPListItem item = GetLatestDocument(idPerusahaan, DocumentType);
            if (item != null)
                ltr.Text = string.Format("<a href='{0}'>{1}</a>", web.Site.Url + "/" + item.Url, item["Name"].ToString());
        }

        private int GetNotarisID(string Notaris)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Notaris"));
            web.AllowUnsafeUpdates = true;
            SPListItem item;

            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                            "<Eq>" +
                                "<FieldRef Name='Title' />" +
                                "<Value Type='Text'>" + Notaris + "</Value>" +
                            "</Eq>" +
                          "</Where>";

            SPListItemCollection coll = list.GetItems(query);
            if (coll.Count == 0)
            {
                item = list.Items.Add();
                item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                item["Title"] = Notaris.Trim();
                item.Update();

                web.AllowUnsafeUpdates = false;

                return item.ID;
            }
            else
            {
                item = coll[0];
                return item.ID;
            }
        }

        private string SaveUpdate(string mode)
        {
            web.AllowUnsafeUpdates = true;
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanAnggaranDasarDanDataPerseroan"));
            SPList listPemegangSaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanPemegangSaham"));
            SPList listKomisarisDireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanKomisarisDireksi"));
            SPList listDokumen = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerubahanAnggaranDasarDokumen"));
            SPList listPerusahaanBaru = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
            SPListItem itemlistPerusahaanBaru = listPerusahaanBaru.GetItemById(Convert.ToInt32(hfIDCompany.Value));

            SPListItem item = null;

            try
            {
                if (IDP == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, this.CodeName, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    item["Step"] = StepWF[0];

                    if (!string.IsNullOrEmpty(rdPerubahanModal.SelectedValue))
                        item["PerubahanModal"] = (rdPerubahanModal.SelectedValue.Equals("Yes") ? true : false);

                    if (!string.IsNullOrEmpty(rdPerubahanNama.SelectedValue))
                        item["PerubahanNamaDanTempat"] = (rdPerubahanNama.SelectedValue.Equals("Yes") ? true : false);
                }
                else
                {
                    item = list.GetItemById(IDP);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                item["Tanggal"] = Convert.ToDateTime(ltrDate.Text);
                item["Requestor"] = hfIDPemohon.Value;

                SPFieldMultiChoiceValue multiValue = new SPFieldMultiChoiceValue();
                foreach (ListItem itemCheckBox in chkBoxListJenisPerubahan.Items)
                {
                    if (itemCheckBox.Selected) multiValue.Add(itemCheckBox.Text);
                }

                item["JenisPerubahan"] = multiValue;
                item["AlasanPerubahan"] = txtAlasanPerubahan.Text.Trim();
                item["BNRI"] = (rbBNRI.SelectedValue.Equals("Yes") ? true : false);
                item["MataUang"] = ddlMataUang.SelectedValue;
                item["ModalDasar"] = (!string.IsNullOrEmpty(txtModalDasarNominalSemula.Text) ? txtModalDasarNominalSemula.Text.Trim() : "0");
                item["ModalSetor"] = (!string.IsNullOrEmpty(txtModalSetorNominalSemula.Text) ? txtModalSetorNominalSemula.Text.Trim() : "0");
                item["Nominal"] = (!string.IsNullOrEmpty(txtNominalMataUang.Text) ? txtNominalMataUang.Text.Trim() : "0");
                item["NominalModalDasar"] = Convert.ToDouble(item["ModalDasar"]) * Convert.ToDouble(item["Nominal"]);
                item["NominalModalSetor"] = Convert.ToDouble(item["ModalSetor"]) * Convert.ToDouble(item["Nominal"]);
                item["Keterangan"] = txtRemarks.Text.Trim();
                item["CompanyCode"] = hfIDCompany.Value.Trim();
                item.Web.AllowUnsafeUpdates = true;
                item.Update();
                ViewState["ID"] = item.ID;



                if (item.ID > 0)
                {
                    #region UpdatePerusahaanBaru
                    itemlistPerusahaanBaru["CompanyCodeAPV"] = txtCompanyCode.Text;
                    itemlistPerusahaanBaru["NamaPerusahaan"] = txtCompanyName.Text;
                    itemlistPerusahaanBaru["TempatKedudukan"] = ddlTempatKedudukan.SelectedValue;
                    itemlistPerusahaanBaru["MaksudTujuan"] = ddlMaksudDanTujuan.SelectedValue;
                    itemlistPerusahaanBaru["MataUang"] = ddlMataUang.SelectedValue;
                    itemlistPerusahaanBaru.Web.AllowUnsafeUpdates = true;
                    itemlistPerusahaanBaru.Update();
                    #endregion
                }

                /* Pemegang Saham */
                if (ViewState["PemegangSahamMenjadi"] != null)
                {
                    List<PemegangSaham> collPemegangSaham = ViewState["PemegangSahamMenjadi"] as List<PemegangSaham>;
                    foreach (PemegangSaham i in collPemegangSaham)
                    {
                        if (!i.IsDeleted)
                        {
                            SPListItem itemPemegangSaham = null;
                            if (i.ID == 0)
                                itemPemegangSaham = listPemegangSaham.Items.Add();
                            else
                                itemPemegangSaham = listPemegangSaham.Items.GetItemById(i.ID);

                            itemPemegangSaham["PerubahanAnggaranDasar"] = ViewState["ID"].ToString();
                            itemPemegangSaham["Title"] = i.Nama;
                            itemPemegangSaham["JumlahSaham"] = i.JumlahSaham;
                            itemPemegangSaham["JumlahNominal"] = i.JumlahNominal;
                            itemPemegangSaham["Percentages"] = i.Percentages;
                            itemPemegangSaham["Partner"] = i.Partner;
                            itemPemegangSaham["TanggalMulaiMenjabat"] = i.MulaiMenjabat;
                            itemPemegangSaham["TanggalAkhirMenjabat"] = i.AkhirMenjabat;
                            itemPemegangSaham["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            itemPemegangSaham.Web.AllowUnsafeUpdates = true;
                            itemPemegangSaham.Update();
                        }
                        else
                        {
                            if (i.ID > 0)
                                listPemegangSaham.GetItemById(i.ID).Recycle();
                        }
                    }
                }

                /* Komisaris */
                if (ViewState["KomisarisDireksiMenjadi"] != null)
                {
                    List<KomisarisDireksi> collKomisarisDireksi = ViewState["KomisarisDireksiMenjadi"] as List<KomisarisDireksi>;
                    foreach (KomisarisDireksi i in collKomisarisDireksi)
                    {
                        if (!i.IsDeleted)
                        {
                            SPListItem itemKomisarisDireksi = null;
                            if (i.ID == 0)
                                itemKomisarisDireksi = listKomisarisDireksi.Items.Add();
                            else
                                itemKomisarisDireksi = listKomisarisDireksi.Items.GetItemById(i.ID);

                            itemKomisarisDireksi["PerubahanAnggaranDasar"] = ViewState["ID"].ToString();
                            itemKomisarisDireksi["Title"] = i.Nama;
                            itemKomisarisDireksi["Jabatan"] = i.IDJabatan;
                            itemKomisarisDireksi["NoKTP"] = i.NoKTP;
                            itemKomisarisDireksi["NoNPWP"] = i.NoNPWP;
                            itemKomisarisDireksi["TanggalMulaiMenjabat"] = i.MulaiMenjabat;
                            itemKomisarisDireksi["TanggalAkhirMenjabat"] = i.AkhirMenjabat;
                            itemKomisarisDireksi["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            itemKomisarisDireksi.Web.AllowUnsafeUpdates = true;
                            itemKomisarisDireksi.Update();
                        }
                        else
                        {
                            if (i.ID > 0)
                                listKomisarisDireksi.GetItemById(i.ID).Recycle();
                        }
                    }
                }

                if (IDP != 0)
                {

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == "PIC Update Akta")
                    {
                        /* Akte */
                        item["NoAkte"] = txtNoAkte.Text.Trim();
                        item["TanggalAkte"] = dtTanggalAkte.SelectedDate;

                        if (!string.IsNullOrEmpty(txtNotarisAkte.Text))
                            item["NotarisAkte"] = GetNotarisID(txtNotarisAkte.Text.Trim());
                        item["KeteranganAkte"] = txtKeteranganAkte.Text.Trim();
                        item["PembuatAkte"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    }

                    /* SKDP */
                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == "PIC Upload SKDP")
                    {
                        item["NoSKDP"] = txtSKDPNo.Text.Trim();
                        item["TanggalMulaiBerlakuSKDP"] = dtSKDPTanggalMulai.SelectedDate;
                        item["TanggalAkhirBerlakuSKDP"] = dtSKDPTanggalAkhir.SelectedDate;
                        item["KeteranganSKDP"] = txtSKDPKeterangan.Text.Trim();
                        item["AlamatSKDP"] = txtAlamatSKDP.Text.Trim();
                        item["PembuatSKDP"] = SPContext.Current.Web.CurrentUser.ID.ToString();

                        itemlistPerusahaanBaru["AlamatSKDP"] = txtAlamatSKDP.Text.Trim();
                        itemlistPerusahaanBaru.Web.AllowUnsafeUpdates = true;
                        itemlistPerusahaanBaru.Update();
                    }

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == "PIC Upload NPWP dan SKT")
                    {
                        /* NPWP */
                        if (ViewState["NPWP"] != null)
                        {
                            List<NPWP> collNPWP = ViewState["NPWP"] as List<NPWP>;
                            foreach (NPWP i in collNPWP)
                            {
                                SPFolder document = web.Folders["PerubahanNPWP"];
                                if (!i.IsDeleted)
                                {
                                    SPFile file = document.Files.Add(i.NamaFile, i.Attachment, true);
                                    SPItem itemDocument = file.Item;
                                    itemDocument["Title"] = Path.GetFileNameWithoutExtension(i.NamaFile);
                                    itemDocument["PerubahanAnggaranDasar"] = Convert.ToInt32(ViewState["ID"]);
                                    itemDocument["NoNPWP"] = i.NoNPWP;
                                    itemDocument["Keterangan"] = i.Keterangan;
                                    itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                                    itemDocument.Update();

                                }
                                else
                                {
                                    if (i.ID > 0)
                                        document.Item.ListItems.DeleteItemById(i.ID);
                                }
                            }
                        }

                        /* NPWP */
                        item["NoNPWP"] = txtNoNPWP.Text.Trim();
                        item["TanggalMulaiBerlakuNPWP"] = dtTanggalTerdaftarNPWP.SelectedDate;
                        item["KeteranganNPWP"] = txtKeteranganNPWP.Text.Trim();
                        item["NamaKPPNPWP"] = txtNamaKPP.Text.Trim();
                        item["PembuatNPWP"] = SPContext.Current.Web.CurrentUser.ID.ToString();

                        /* SKT */
                        item["NoSKT"] = txtNOSKTNPWP.Text.Trim();
                        item["PembuatSKT"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    }

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == "PIC Upload APV")
                    {
                        /* APV */
                        item["CompanyCodeAPV"] = txtKodePerusahaanAPV.Text.Trim();
                        item["NoAPV"] = txtNoAPV.Text.Trim();
                        item["TanggalAPV"] = dtTanggalAPV.SelectedDate;
                        item["KeteranganAPV"] = txtKeteranganAPV.Text.Trim();
                    }

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == "PIC Upload Setoran Modal")
                    {
                        /* Setoran */
                        item["TanggalSetoran"] = dtTanggalSetoran.SelectedDate;
                        item["KeteranganSetoran"] = txtKeteranganSetoran.Text.Trim();
                        item["StatusSetoran"] = chkStatusSetoran.Checked;
                        item["PembuatSetoran"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        item["PembuatAPV"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    }

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == "PIC Upload SK Persetujuan")
                    {
                        /* SK */
                        item["NoSK"] = txtSKNo.Text.Trim();
                        item["TanggalMulaiBerlakuSK"] = dtSKMulaiBerlaku.SelectedDate;
                        item["KeteranganSK"] = txtSKKeterangan.Text.Trim();
                        item["PembuatSK"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    }

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || divBNRI.Visible)
                    {
                        /* BNRI */
                        item["NoBNRI"] = txtBNRINo.Text.Trim();
                        item["TanggalMulaiBerlakuBNRI"] = dtBNRIMulaiBerlaku.SelectedDate;
                        item["KeteranganBNRI"] = txtBNRIKeterangan.Text.Trim();
                        item["PembuatBNRI"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    }

                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    item.Web.AllowUnsafeUpdates = true;
                    item.Update();
                    ViewState["ID"] = item.ID;

                    string message = string.Empty;
                    message = SaveDocument(fuSK, Convert.ToInt32(hfIDCompany.Value), "SK");
                    if (message != string.Empty)
                        return message;

                    message = string.Empty;
                    message = SaveDocument(fuAkte, Convert.ToInt32(hfIDCompany.Value), "AKTA");
                    if (message != string.Empty)
                        return message;

                    message = SaveDocument(fuSKDP, Convert.ToInt32(hfIDCompany.Value), "SKDP");
                    if (message != string.Empty)
                        return message;

                    message = SaveDocument(fuNPWP, Convert.ToInt32(hfIDCompany.Value), "NPWP");
                    if (message != string.Empty)
                        return message;

                    message = SaveDocument(fuSKT, Convert.ToInt32(hfIDCompany.Value), "SKT");
                    if (message != string.Empty)
                        return message;

                    message = SaveDocument(fuAPV, Convert.ToInt32(hfIDCompany.Value), "APV");
                    if (message != string.Empty)
                        return message;

                    message = SaveDocument(fuSetoranModal, Convert.ToInt32(hfIDCompany.Value), "Setoran Modal");
                    if (message != string.Empty)
                        return message;
                }
                web.AllowUnsafeUpdates = true;

                if (item["Status"] == null)
                {
                    if (mode == "SaveRunWf")
                    {
                        if (list.WorkflowAssociations.Count > 0)
                        {
                            string WfId = Util.GetSettingValue(web, "Workflow BasedId", "Perubahan Anggaran Dasar & Data Perseroan");
                            Guid wfBaseId = new Guid(WfId);
                            SPWorkflowAssociation associationTemplate = list.WorkflowAssociations.GetAssociationByBaseID(wfBaseId);
                            web.Site.WorkflowManager.StartWorkflow(item, associationTemplate, associationTemplate.AssociationData, true);
                        }
                    }
                }
                web.AllowUnsafeUpdates = false;
            }
            catch (Exception ex)
            {
                string err = ex.Message + "," + ex.StackTrace;
                if (IDP == 0)
                    return SR.SaveFail + "\n" + err;
                else
                    return SR.UpdateFail + "\n" + err;
            }

            return string.Empty;
        }

        private void BindPemohon()
        {
            string query = string.Empty;
            if (txtSearchPemohon.Text.Trim() == string.Empty)
            {
                query = @"<Where>
                          <IsNotNull>
                             <FieldRef Name='Title' />
                          </IsNotNull>
                       </Where>
                       <OrderBy>
                          <FieldRef Name='Title' Ascending='True' />
                       </OrderBy>";
            }
            else
            {
                query = string.Format(@"<Where>
                          <Contains>
                             <FieldRef Name='Title' />
                             <Value Type='Text'>{0}</Value>
                          </Contains>
                       </Where>
                       <OrderBy>
                          <FieldRef Name='Title' Ascending='True' />
                       </OrderBy>", txtSearchPemohon.Text.Trim());
            }

            grvPemohon.Visible = true;
            odsPemohon.SelectParameters["ListURL"].DefaultValue = Util.CreateSharePointListStrUrl(web.Url, "Pemohon");
            odsPemohon.SelectParameters["strQuery"].DefaultValue = query;
            odsPemohon.Page.DataBind();
        }

        private void BindCompanySearch()
        {
            string query = string.Empty;
            if (txtSearchCompany.Text.Trim() == string.Empty)
            {
                query = @"<Where>
                          <And>
                             <IsNotNull>
                                <FieldRef Name='NamaPerusahaan' />
                             </IsNotNull>
                             <Eq>
                                <FieldRef Name='ApprovalStatus' />
                                <Value Type='Text'>Approved</Value>
                             </Eq>
                          </And>
                       </Where>
                       <OrderBy>
                          <FieldRef Name='Title' Ascending='True' />
                       </OrderBy>";
            }
            else
            {
                query = string.Format(@"<Where>
                          <And>
                             <Contains>
                                <FieldRef Name='NamaPerusahaan' />
                                <Value Type='Text'>{0}</Value>
                             </Contains>
                             <Eq>
                                <FieldRef Name='ApprovalStatus' />
                                <Value Type='Text'>Approved</Value>
                             </Eq>
                          </And>
                       </Where>
                       <OrderBy>
                          <FieldRef Name='Title' Ascending='True' />
                       </OrderBy>", txtSearchCompany.Text.Trim());
            }

            grvCompanySearch.Visible = true;
            odsCompany.SelectParameters["ListURL"].DefaultValue = Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru");
            odsCompany.SelectParameters["strQuery"].DefaultValue = query;
            odsCompany.Page.DataBind();
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
                    hfIDPemohon.Value = IDPemohon.ToString();
                    txtNamaPemohon.Text = item.Title;
                    txtEmailPemohon.Text = item["EmailPemohon"].ToString();
                }
            }
        }

        private void DisplayCompany(bool isGrid, int IDCompany)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
            SPListItem item = list.GetItemById(IDCompany);
            if (item != null)
            {

                hfIDCompany.Value = IDCompany.ToString();
                txtCompanyCode.Text = (item["CompanyCodeAPV"] != null ? item["CompanyCodeAPV"].ToString() : string.Empty);
                txtCompanyName.Text = (item["NamaPerusahaan"] != null ? item["NamaPerusahaan"].ToString() : string.Empty);
                ddlTempatKedudukan.SelectedValue = (item["TempatKedudukan"] != null ? new SPFieldLookupValue(item["TempatKedudukan"].ToString()).LookupId.ToString() : string.Empty);
                ddlMaksudDanTujuan.SelectedValue = (item["MaksudTujuan"] != null ? new SPFieldLookupValue(item["MaksudTujuan"].ToString()).LookupId.ToString() : string.Empty);
                ddlMataUang.SelectedValue = (item["MataUang"] != null ? new SPFieldLookupValue(item["MataUang"].ToString()).LookupId.ToString() : string.Empty);
                txtModalDasarNominalSemula.Text = Convert.ToDouble(item["ModalDasar"]).ToString("#,##0");
                txtModalSetorNominalSemula.Text = Convert.ToDouble(item["ModalSetor"]).ToString("#,##0");
                txtNominalMataUang.Text = Convert.ToDouble(item["Nominal"]).ToString("#,##0");
                txtModalDasarNominalMenjadi.Text = (Convert.ToDouble(txtModalDasarNominalSemula.Text) * Convert.ToDouble(txtNominalMataUang.Text)).ToString("#,##0");
                txtModalSetorNominalMenjadi.Text = (Convert.ToDouble(txtModalSetorNominalSemula.Text) * Convert.ToDouble(txtNominalMataUang.Text)).ToString("#,##0");

                GetKomisarisDireksiSemula(IDCompany);
                BindKomisarisDireksiSemula();

                GetPemegangSahamSemula(IDCompany);
                BindPemegangSahamSemula();

                //dgPemegangSaham.Columns[6].Visible = true;
                //dgPemegangSaham.Columns[7].Visible = true;

                //dgKomisaris.Columns[5].Visible = true;
                //dgKomisaris.Columns[6].Visible = true;

                if (IDP == 0)
                {
                    if (ViewState["KomisarisDireksiSemula"] != null)
                    {
                        ViewState["KomisarisDireksiMenjadi"] = ViewState["KomisarisDireksiSemula"];
                        BindKomisarisDireksiMenjadi();
                    }

                    if (ViewState["PemegangSahamSemula"] != null)
                    {
                        ViewState["PemegangSahamMenjadi"] = ViewState["PemegangSahamSemula"];
                        BindPemegangSahamMenjadi();
                    }
                }
            }
        }

        private void BindKomisarisDireksiSemula()
        {
            List<KomisarisDireksi> coll = new List<KomisarisDireksi>();
            if (ViewState["KomisarisDireksiSemula"] != null)
                coll = ViewState["KomisarisDireksiSemula"] as List<KomisarisDireksi>;

            dgKomisarisSemula.DataSource = coll;
            dgKomisarisSemula.DataBind();
            upKomisarisSemula.Update();
        }

        private void BindKomisarisDireksiMenjadi()
        {
            List<KomisarisDireksi> coll = new List<KomisarisDireksi>();
            if (ViewState["KomisarisDireksiMenjadi"] != null)
                coll = ViewState["KomisarisDireksiMenjadi"] as List<KomisarisDireksi>;

            dgKomisaris.DataSource = coll.FindAll(x => x.IsDeleted == false);
            dgKomisaris.DataBind();
            upKomisarisMenjadi.Update();
        }

        private void GetKomisarisDireksiSemula(int idcompany)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + idcompany + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";

            SPList listKomisarisDireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "KomisarisDireksi"));
            SPListItemCollection collSPKomisarisDireksi = listKomisarisDireksi.GetItems(query);

            List<KomisarisDireksi> collKomisarisDireksi = new List<KomisarisDireksi>();
            foreach (SPListItem i in collSPKomisarisDireksi)
            {
                KomisarisDireksi o = new KomisarisDireksi();
                o.ID = 0;
                o.Nama = i["Title"].ToString();
                String[] split = i["Jabatan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries);
                o.IDJabatan = Convert.ToInt32(split[0]);
                o.Jabatan = split[1];
                o.NoKTP = i["NoKTP"].ToString();
                o.NoNPWP = i["NoNPWP"].ToString();
                if (i["TanggalMulaiMenjabat"] != null)
                    o.MulaiMenjabat = Convert.ToDateTime(i["TanggalMulaiMenjabat"]);
                if (i["TanggalAkhirMenjabat"] != null)
                    o.AkhirMenjabat = Convert.ToDateTime(i["TanggalAkhirMenjabat"]);
                collKomisarisDireksi.Add(o);
            }
            ViewState["KomisarisDireksiSemula"] = collKomisarisDireksi;
        }

        private void GetKomisarisDireksiMenjadi(int id)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PerubahanAnggaranDasar' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + id + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";

            SPList listKomisarisDireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanKomisarisDireksi"));
            SPListItemCollection collSPKomisarisDireksi = listKomisarisDireksi.GetItems(query);

            List<KomisarisDireksi> collKomisarisDireksi = new List<KomisarisDireksi>();
            foreach (SPListItem i in collSPKomisarisDireksi)
            {
                KomisarisDireksi o = new KomisarisDireksi();
                o.ID = i.ID;
                o.Nama = i["Title"].ToString();
                String[] split = i["Jabatan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries);
                o.IDJabatan = Convert.ToInt32(split[0]);
                o.Jabatan = split[1];
                o.NoKTP = i["NoKTP"].ToString();
                o.NoNPWP = i["NoNPWP"].ToString();
                if (i["TanggalMulaiMenjabat"] != null)
                    o.MulaiMenjabat = Convert.ToDateTime(i["TanggalMulaiMenjabat"]);
                if (i["TanggalAkhirMenjabat"] != null)
                    o.AkhirMenjabat = Convert.ToDateTime(i["TanggalAkhirMenjabat"]);
                o.IsDeleted = false;
                collKomisarisDireksi.Add(o);
            }
            ViewState["KomisarisDireksiMenjadi"] = collKomisarisDireksi;
        }

        private void GetPemegangSahamSemula(int idcompany)
        {
            SPList listPemegangSaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PemegangSaham"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + idcompany + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";
            SPListItemCollection collSPPemegangSaham = listPemegangSaham.GetItems(query);

            List<PemegangSaham> collPemegangSaham = new List<PemegangSaham>();
            foreach (SPListItem i in collSPPemegangSaham)
            {
                PemegangSaham o = new PemegangSaham();
                o.ID = 0;
                o.Nama = i["Title"].ToString();
                o.JumlahNominal = Convert.ToDouble(i["JumlahNominal"]);
                o.JumlahSaham = Convert.ToDouble(i["JumlahSaham"]);
                o.Partner = Convert.ToBoolean(i["Partner"]);
                o.Percentages = Convert.ToDouble(i["Percentages"]);
                if (i["TanggalMulaiMenjabat"] != null)
                    o.MulaiMenjabat = Convert.ToDateTime(i["TanggalMulaiMenjabat"]);
                if (i["TanggalAkhirMenjabat"] != null)
                    o.AkhirMenjabat = Convert.ToDateTime(i["TanggalAkhirMenjabat"]);
                o.IsDeleted = false;
                collPemegangSaham.Add(o);
            }
            ViewState["PemegangSahamSemula"] = collPemegangSaham;
        }

        private void GetPemegangSahamMenjadi(int id)
        {
            SPList listPemegangSaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanPemegangSaham"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PerubahanAnggaranDasar' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + id + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";
            SPListItemCollection collSPPemegangSaham = listPemegangSaham.GetItems(query);

            List<PemegangSaham> collPemegangSaham = new List<PemegangSaham>();
            foreach (SPListItem i in collSPPemegangSaham)
            {
                PemegangSaham o = new PemegangSaham();
                o.ID = i.ID;
                o.Nama = i["Title"].ToString();
                o.JumlahNominal = Convert.ToDouble(i["JumlahNominal"]);
                o.JumlahSaham = Convert.ToDouble(i["JumlahSaham"]);
                o.Partner = Convert.ToBoolean(i["Partner"]);
                o.Percentages = Convert.ToDouble(i["Percentages"]);
                if (i["TanggalMulaiMenjabat"] != null)
                    o.MulaiMenjabat = Convert.ToDateTime(i["TanggalMulaiMenjabat"]);
                if (i["TanggalAkhirMenjabat"] != null)
                    o.AkhirMenjabat = Convert.ToDateTime(i["TanggalAkhirMenjabat"]);
                o.IsDeleted = false;
                collPemegangSaham.Add(o);
            }
            ViewState["PemegangSahamMenjadi"] = collPemegangSaham;
        }

        private void BindPemegangSahamSemula()
        {
            List<PemegangSaham> coll = new List<PemegangSaham>();
            if (ViewState["PemegangSahamSemula"] != null)
                coll = ViewState["PemegangSahamSemula"] as List<PemegangSaham>;

            dgPemegangSahamSemula.DataSource = coll;
            dgPemegangSahamSemula.DataBind();
            upPemegangSahamSemula.Update();
        }

        private void BindPemegangSahamMenjadi()
        {
            List<PemegangSaham> coll = new List<PemegangSaham>();
            if (ViewState["PemegangSahamMenjadi"] != null)
                coll = ViewState["PemegangSahamMenjadi"] as List<PemegangSaham>;

            dgPemegangSaham.DataSource = coll.FindAll(x => x.IsDeleted == false);
            dgPemegangSaham.DataBind();
            upPemegangSahamMenjadi.Update();
        }


        private void GetNPWP(int id)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PerubahanAnggaranDasar' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + id + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";

            SPList listNPWP = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerubahanNPWP"));
            SPListItemCollection collSPPerubahanNPWP = listNPWP.GetItems(query);
            List<NPWP> collDokumenNPWP = new List<NPWP>();
            foreach (SPListItem i in collSPPerubahanNPWP)
            {
                NPWP o = new NPWP();
                o.ID = i.ID;
                o.NamaFile = i["Name"].ToString();
                o.NoNPWP = i["NoNPWP"].ToString();
                if (i["Keterangan"] != null)
                    o.Keterangan = i["Keterangan"].ToString();
                o.Attachment = i.File.OpenBinary();
                o.Url = string.Format("<a href='/NPWPLainnya/{0}'>{0}</a>", i["Name"].ToString());
                o.IsDeleted = false;
                collDokumenNPWP.Add(o);
            }
            ViewState["NPWP"] = collDokumenNPWP;
        }

        private void BindNPWP()
        {
            List<NPWP> coll = new List<NPWP>();
            if (ViewState["NPWP"] != null)
                coll = ViewState["NPWP"] as List<NPWP>;

            dgNPWPLainnya.DataSource = coll.FindAll(x => x.IsDeleted == false);
            dgNPWPLainnya.DataBind();

        }

        private SPListItem GetLatestDocument(int idPerusahaan, string DocumentType)
        {
            SPQuery query = new SPQuery();
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
            query.Query = string.Format(@"<Where>
                          <Eq>
                             <FieldRef Name='ID' />
                             <Value Type='Counter'>{0}</Value>
                          </Eq>
                       </Where>", idPerusahaan);
            SPListItemCollection items = list.GetItems(query);
            string RequestCode = items[0]["Title"].ToString();

            SPList documentPerubahanAnggaranDasarDokumen = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
            query = new SPQuery();
            query.Query = "<Where>" +
                             "<And>" +
                                 "<Eq>" +
                                      "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                      "<Value Type='Lookup'>" + idPerusahaan + "</Value>" +
                                  "</Eq>" +
                                  "<Eq>" +
                                      "<FieldRef Name='DocumentType' />" +
                                      "<Value Type='Text'>" + DocumentType + "</Value>" +
                                  "</Eq>" +
                             "</And>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";
            query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[RequestCode];

            SPListItemCollection coll = documentPerubahanAnggaranDasarDokumen.GetItems(query);
            if (coll.Count > 0)
                return coll[0];
            return null;
        }

        private SPListItem GetItem(int id)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanAnggaranDasarDanDataPerseroan"));
            SPListItem item = list.GetItemById(IDP);
            return item;
        }

        private void Display(string mode)
        {
            SPListItem item = GetItem(IDP);
            try
            {
                string workflowStatus = (item["Step"] != null ? item["Step"].ToString() : string.Empty);
                string approvalStatus = (item["ApprovalStatus"] != null ? item["ApprovalStatus"].ToString() : string.Empty);
                if (approvalStatus.Equals("Approved"))
                {
                    //mode = "display";
                    workflowStatus = approvalStatus;
                }

                ViewState["Status"] = workflowStatus;

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

                ltrWorkflow.Text = workflowStatus;
                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                txtAlasanPerubahan.Text = (item["AlasanPerubahan"] != null ? item["AlasanPerubahan"].ToString() : string.Empty);
                ltrAlasanPerubahan.Text = txtAlasanPerubahan.Text;
                rdPerubahanModal.SelectedValue = (Convert.ToBoolean(item["PerubahanModal"]) ? "Yes" : "No");
                rdPerubahanNama.SelectedValue = (Convert.ToBoolean(item["PerubahanNamaDanTempat"]) ? "Yes" : "No");

                rdPerubahanModal.Enabled = false;
                rdPerubahanNama.Enabled = false;
                imgbtnNamaCompany.Visible = false;

                if (item["BNRI"] != null)
                {
                    bool stsBNRI = Convert.ToBoolean(item["BNRI"]);
                    rbBNRI.SelectedValue = (stsBNRI ? "Yes" : "No");
                    ltrBNRI.Text = rbBNRI.SelectedItem.Text;
                }

                if (item["JenisPerubahan"] != null)
                {
                    string rawValue = item["JenisPerubahan"].ToString();
                    SPFieldMultiChoiceValue itemValue = new SPFieldMultiChoiceValue(rawValue);
                    for (int i = 0; i < itemValue.Count; i++)
                    {
                        chkBoxListJenisPerubahan.Items.FindByText(itemValue[i]).Selected = true;
                    }
                }

                ddlMataUang.SelectedValue = new SPFieldLookupValue(item["MataUang"].ToString()).LookupId.ToString();
                ltrMataUang.Text = ddlMataUang.SelectedItem.Text;
                txtModalDasarNominalSemula.Text = (item["ModalDasar"] != null ? Convert.ToDouble(item["ModalDasar"]).ToString("#,##0") : "0");
                ltrtxtModalDasarNominalSemula.Text = txtModalDasarNominalSemula.Text;
                txtModalSetorNominalSemula.Text = (item["ModalSetor"] != null ? Convert.ToDouble(item["ModalSetor"]).ToString("#,##0") : "0");
                ltrtxtModalSetorNominalSemula.Text = txtModalSetorNominalSemula.Text;
                txtNominalMataUang.Text = (item["Nominal"] != null ? Convert.ToDouble(item["Nominal"]).ToString("#,##0") : "1");
                ltrNominalMataUang.Text = txtNominalMataUang.Text;
                txtModalDasarNominalMenjadi.Text = (item["NominalModalDasar"] != null ? Convert.ToDouble(item["NominalModalDasar"]).ToString("#,##0") : "0");
                ltrtxtModalDasarNominalMenjadi.Text = txtModalDasarNominalMenjadi.Text;
                txtModalSetorNominalMenjadi.Text = (item["NominalModalSetor"] != null ? Convert.ToDouble(item["NominalModalSetor"]).ToString("#,##0") : "0");
                ltrtxtModalSetorNominalMenjadi.Text = txtModalSetorNominalMenjadi.Text;
                txtRemarks.Text = (item["Keterangan"] != null ? item["Keterangan"].ToString() : string.Empty);
                ltrRemarks.Text = txtRemarks.Text;
                hfIDCompany.Value = (item["CompanyCode"] != null ? new SPFieldLookupValue(item["CompanyCode"].ToString()).LookupId.ToString() : string.Empty);
                hfIDPemohon.Value = new SPFieldLookupValue(item["Requestor"].ToString()).LookupId.ToString();
                txtAlamatSKDP.Text = (item["AlamatSKDP"] != null ? item["AlamatSKDP"].ToString() : string.Empty);
                ltrAlamatSKDP.Text = txtAlamatSKDP.Text;

                if (item["JenisPerubahan"] != null)
                {
                    SPFieldLookupValueCollection lookUpJenisPerubahan = new SPFieldLookupValueCollection(item["JenisPerubahan"].ToString());
                    for (int i = 0; i < lookUpJenisPerubahan.Count; i++)
                    {
                        SPFieldLookupValue singlevalue = lookUpJenisPerubahan[i];
                        chkBoxListJenisPerubahan.SelectedValue = singlevalue.LookupId.ToString();
                    }
                }

                if (IDP != 0)
                {
                    #region UpdatePerusahaanBaru
                    SPList listPerusahaanBaru = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
                    SPListItem itemPerusahaanBaru = listPerusahaanBaru.GetItemById(Convert.ToInt32(hfIDCompany.Value));
                    txtCompanyCode.Text = (itemPerusahaanBaru["CompanyCodeAPV"] != null ? itemPerusahaanBaru["CompanyCodeAPV"].ToString() : string.Empty);
                    ltrCompanyCode.Text = txtCompanyCode.Text;
                    txtCompanyName.Text = (itemPerusahaanBaru["CompanyCodeAPV"] != null ? itemPerusahaanBaru["NamaPerusahaan"].ToString() : string.Empty);
                    lblPerusahaanName.Text = txtCompanyName.Text;

                    if (string.IsNullOrEmpty(txtAlamatSKDP.Text))
                    {
                        txtAlamatSKDP.Text = (itemPerusahaanBaru["AlamatSKDP"] != null ? itemPerusahaanBaru["AlamatSKDP"].ToString() : string.Empty);
                        ltrAlamatSKDP.Text = txtAlamatSKDP.Text;
                    }

                    if (itemPerusahaanBaru["TempatKedudukan"] != null)
                    {
                        ddlTempatKedudukan.SelectedValue = new SPFieldLookupValue(itemPerusahaanBaru["TempatKedudukan"].ToString()).LookupId.ToString();
                        ltrddlTempatKedudukan.Text = ddlTempatKedudukan.SelectedItem.Text;
                    }

                    if (itemPerusahaanBaru["MaksudTujuan"] != null)
                    {
                        ddlMaksudDanTujuan.SelectedValue = new SPFieldLookupValue(itemPerusahaanBaru["MaksudTujuan"].ToString()).LookupId.ToString();
                        ltrddlMaksudDanTujuan.Text = ddlMaksudDanTujuan.SelectedItem.Text;
                    }

                    #endregion

                    #region UpdatePemohon
                    SPList listPemohon = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
                    SPListItem itemPemohon = listPemohon.GetItemById(Convert.ToInt32(hfIDPemohon.Value));
                    txtNamaPemohon.Text = (itemPemohon["Title"] != null ? itemPemohon["Title"].ToString() : string.Empty);
                    ltrNamaPemohon.Text = txtNamaPemohon.Text;
                    txtEmailPemohon.Text = (itemPemohon["EmailPemohon"] != null ? itemPemohon["EmailPemohon"].ToString() : string.Empty);
                    ltrEmailPemohon.Text = txtEmailPemohon.Text;
                    #endregion

                    GetKomisarisDireksiSemula(itemPerusahaanBaru.ID);
                    BindKomisarisDireksiSemula();

                    GetKomisarisDireksiMenjadi(IDP);
                    BindKomisarisDireksiMenjadi();

                    GetPemegangSahamSemula(itemPerusahaanBaru.ID);
                    BindPemegangSahamSemula();

                    GetPemegangSahamMenjadi(IDP);
                    BindPemegangSahamMenjadi();

                    GetNPWP(IDP);
                    BindNPWP();

                    if (item["PembuatSK"] != null)
                    {
                        /* SK */
                        txtSKNo.Text = (item["NoSK"] != null ? item["NoSK"].ToString() : string.Empty);
                        ltrSKNo.Text = txtSKNo.Text;
                        if (item["TanggalMulaiBerlakuSK"] != null)
                        {
                            dtSKMulaiBerlaku.SelectedDate = Convert.ToDateTime(item["TanggalMulaiBerlakuSK"]);
                            ltrSKMulaiBerlaku.Text = Convert.ToDateTime(item["TanggalMulaiBerlakuSK"]).ToString("dd-MMM-yyyy");
                        }
                        txtSKKeterangan.Text = (item["KeteranganSK"] != null ? item["KeteranganSK"].ToString() : string.Empty);
                        ltrSKKeterangan.Text = txtSKKeterangan.Text;
                        lblSKUserName.Text = (item["PembuatSK"] != null ? new SPFieldUserValue(web, item["PembuatSK"].ToString()).User.Name : string.Empty);
                    }

                    if (item["PembuatBNRI"] != null)
                    {
                        /* BNRI */
                        txtBNRINo.Text = (item["NoBNRI"] != null ? item["NoBNRI"].ToString() : string.Empty);
                        ltrBNRINo.Text = txtBNRINo.Text;
                        if (item["TanggalMulaiBerlakuBNRI"] != null)
                        {
                            dtBNRIMulaiBerlaku.SelectedDate = Convert.ToDateTime(item["TanggalMulaiBerlakuBNRI"]);
                            ltrBNRIMulaiBerlaku.Text = Convert.ToDateTime(item["TanggalMulaiBerlakuBNRI"]).ToString("dd-MMM-yyyy");
                        }
                        txtBNRIKeterangan.Text = (item["KeteranganBNRI"] != null ? item["KeteranganBNRI"].ToString() : string.Empty);
                        ltrBNRIKeterangan.Text = txtBNRIKeterangan.Text;
                        lblBNRIUserName.Text = (item["PembuatBNRI"] != null ? new SPFieldUserValue(web, item["PembuatBNRI"].ToString()).User.Name : string.Empty);
                    }

                    if (item["PembuatSKDP"] != null)
                    {
                        /* SKDP */
                        txtSKDPNo.Text = (item["NoSKDP"] != null ? item["NoSKDP"].ToString() : string.Empty);
                        ltrSKDPNo.Text = txtSKDPNo.Text;
                        if (item["TanggalMulaiBerlakuSKDP"] != null)
                        {
                            dtSKDPTanggalMulai.SelectedDate = Convert.ToDateTime(item["TanggalMulaiBerlakuSKDP"]);
                            ltrSKDPTanggalMulai.Text = Convert.ToDateTime(item["TanggalMulaiBerlakuSKDP"]).ToString("dd-MMM-yyyy");
                        }
                        if (item["TanggalAkhirBerlakuSKDP"] != null)
                        {
                            dtSKDPTanggalAkhir.SelectedDate = Convert.ToDateTime(item["TanggalAkhirBerlakuSKDP"]);
                            ltrSKDPTanggalAkhir.Text = Convert.ToDateTime(item["TanggalAkhirBerlakuSKDP"]).ToString("dd-MMM-yyyy");
                        }
                        txtSKDPKeterangan.Text = (item["KeteranganSKDP"] != null ? item["KeteranganSKDP"].ToString() : string.Empty);
                        ltrSKDPKeterangan.Text = txtSKDPKeterangan.Text;
                        lblSKDPUserName.Text = (item["PembuatSKDP"] != null ? new SPFieldUserValue(web, item["PembuatSKDP"].ToString()).User.Name : string.Empty);
                    }

                    if (item["PembuatNPWP"] != null)
                    {
                        /* NPWP */
                        txtNoNPWP.Text = (item["NoNPWP"] != null ? item["NoNPWP"].ToString() : string.Empty);
                        ltrNoNPWP.Text = txtNoNPWP.Text;
                        txtNamaKPP.Text = (item["NamaKPPNPWP"] != null ? item["NamaKPPNPWP"].ToString() : string.Empty);
                        ltrNamaKPP.Text = txtNamaKPP.Text;
                        if (item["TanggalMulaiBerlakuNPWP"] != null)
                        {
                            dtTanggalTerdaftarNPWP.SelectedDate = Convert.ToDateTime(item["TanggalMulaiBerlakuNPWP"]);
                            ltrTanggalTerdaftarNPWP.Text = Convert.ToDateTime(item["TanggalMulaiBerlakuNPWP"]).ToString("dd-MMM-yyyy");
                        }
                        txtKeteranganNPWP.Text = (item["KeteranganNPWP"] != null ? item["KeteranganNPWP"].ToString() : string.Empty);
                        ltrKeteranganNPWP.Text = txtKeteranganNPWP.Text;
                        ltrUsernameNPWP.Text = (item["PembuatNPWP"] != null ? new SPFieldUserValue(web, item["PembuatNPWP"].ToString()).User.Name : string.Empty);

                        /* SKT */
                        txtNOSKTNPWP.Text = (item["NoSKT"] != null ? item["NoSKT"].ToString() : string.Empty);
                        ltrNOSKTNPWP.Text = txtNOSKTNPWP.Text;
                    }

                    /* Akte */
                    if (item["PembuatAkte"] != null)
                    {
                        txtNoAkte.Text = (item["NoAkte"] != null ? item["NoAkte"].ToString() : string.Empty);
                        ltrNoAkte.Text = txtNoAkte.Text;
                        dtTanggalAkte.SelectedDate = Convert.ToDateTime(item["TanggalAkte"]);
                        ltrTanggalAkte.Text = dtTanggalAkte.SelectedDate.ToString("dd/MM/yyyy");
                        txtNotarisAkte.Text = item["NotarisAkte"] != null ? item["NotarisAkte"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1] : string.Empty;
                        ltrNotarisAkte.Text = txtNotarisAkte.Text;
                        txtKeteranganAkte.Text = item["KeteranganAkte"] == null ? string.Empty : item["KeteranganAkte"].ToString();
                        ltrKeteranganAkte.Text = txtKeteranganAkte.Text;
                        if (item["PembuatAkte"] != null)
                            ltrUsernameAkte.Text = item["PembuatAkte"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    }

                    /* APV */
                    if (item["PembuatAPV"] != null)
                    {
                        txtKodePerusahaanAPV.Text = item["CompanyCodeAPV"] == null ? string.Empty : item["CompanyCodeAPV"].ToString();
                        ltrKodePerusahaanAPV.Text = txtKodePerusahaanAPV.Text;
                        txtNoAPV.Text = item["NoAPV"] == null ? string.Empty : item["NoAPV"].ToString();
                        ltrNoAPV.Text = txtNoAPV.Text;

                        if (item["TanggalAPV"] != null)
                        {
                            dtTanggalAPV.SelectedDate = Convert.ToDateTime(item["TanggalAPV"]);
                            ltrTanggalAPV.Text = Convert.ToDateTime(item["TanggalAPV"]).ToString("dd-MMM-yyyy");
                        }

                        txtKeteranganAPV.Text = item["KeteranganAPV"] == null ? string.Empty : item["KeteranganAPV"].ToString();
                        ltrKeteranganAPV.Text = txtKeteranganAPV.Text;
                        if (item["PembuatAPV"] != null)
                            ltrUsernameAPV.Text = item["PembuatAPV"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    }

                    /* Setoran Modal */
                    if (item["PembuatSetoran"] != null)
                    {
                        if (item["TanggalSetoran"] != null)
                        {
                            dtTanggalSetoran.SelectedDate = Convert.ToDateTime(item["TanggalSetoran"]);
                            ltrTanggalSetoran.Text = Convert.ToDateTime(item["TanggalSetoran"]).ToString("dd-MMM-yyyy");
                        }

                        txtKeteranganSetoran.Text = item["KeteranganSetoran"] == null ? string.Empty : item["KeteranganSetoran"].ToString();
                        ltrKeteranganSetoran.Text = txtKeteranganSetoran.Text;

                        if (item["StatusSetoran"] != null)
                        {
                            chkStatusSetoran.Checked = Convert.ToBoolean(item["StatusSetoran"]);
                            ltrStatusSetoran.Text = Convert.ToBoolean(item["StatusSetoran"]) == true ? "Yes" : "No";
                        }

                        if (item["PembuatSetoran"] != null)
                            ltrUsernameSetoran.Text = item["PembuatSetoran"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    }

                    DisplayDocument(ltrfuSK, Convert.ToInt32(hfIDCompany.Value), "SK");
                    DisplayDocument(ltrfuAkte, Convert.ToInt32(hfIDCompany.Value), "AKTA");
                    DisplayDocument(ltrfuSKDP, Convert.ToInt32(hfIDCompany.Value), "SKDP");
                    DisplayDocument(ltrfuNPWP, Convert.ToInt32(hfIDCompany.Value), "NPWP");
                    DisplayDocument(ltrfuSKT, Convert.ToInt32(hfIDCompany.Value), "SKT");
                    DisplayDocument(ltrfuAPV, Convert.ToInt32(hfIDCompany.Value), "APV");
                    DisplayDocument(ltrfuSetoranModal, Convert.ToInt32(hfIDCompany.Value), "Setoran Modal");
                }

                HiddenControls(mode, workflowStatus, approvalStatus);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "," + ex.StackTrace);
            }
        }

        private void HiddenControls(string mode, string workflowStatus, string approvalStatus)
        {
            if (mode == "display")
            {
                rbBNRI.Enabled = false;
                chkBoxListJenisPerubahan.Enabled = false;
                imgbtnNamaPemohon.Visible = false;
                imgbtnNamaCompany.Visible = false;
                txtNamaPemohon.Visible = false;
                txtCompanyCode.Visible = false;
                txtAlasanPerubahan.Visible = false;
                txtEmailPemohon.Visible = false;
                txtRemarks.Visible = false;
                ddlMataUang.Visible = false;
                btnSaveUpdate.Visible = false;
                txtNominalMataUang.Visible = false;
                ltrCompanyCode.Visible = true;
                txtCompanyName.Visible = false;
                ddlTempatKedudukan.Visible = false;
                ddlMaksudDanTujuan.Visible = false;
                txtModalDasarNominalSemula.Visible = false;
                txtModalDasarNominalMenjadi.Visible = false;
                txtModalSetorNominalSemula.Visible = false;
                txtModalSetorNominalMenjadi.Visible = false;
                txtSKNo.Visible = false;
                dtSKMulaiBerlaku.Visible = false;
                txtSKKeterangan.Visible = false;
                txtAlamatSKDP.Visible = false;
                txtKodePerusahaanAPV.Visible = false;
                txtNoAPV.Visible = false;
                dtTanggalAPV.Visible = false;
                txtKeteranganAPV.Visible = false;
                dtTanggalSetoran.Visible = false;
                txtKeteranganSetoran.Visible = false;
                chkStatusSetoran.Visible = false; 

                txtSKNo.Visible = false;
                dtSKMulaiBerlaku.Visible = false;
                txtSKKeterangan.Visible = false;

                txtBNRINo.Visible = false;
                dtBNRIMulaiBerlaku.Visible = false;
                txtBNRIKeterangan.Visible = false;

                fuSKDP.Visible = false;
                txtSKDPNo.Visible = false;
                dtSKDPTanggalMulai.Visible = false;
                dtSKDPTanggalAkhir.Visible = false;
                txtSKDPKeterangan.Visible = false;

                fuNPWP.Visible = false;
                txtNoNPWP.Visible = false;

                dtTanggalTerdaftarNPWP.Visible = false;
                txtNamaKPP.Visible = false;
                txtKeteranganNPWP.Visible = false;

                txtSKNo.Visible = false;
                txtNOSKTNPWP.Visible = false;
                dgPemegangSaham.ShowFooter = false;
                dgPemegangSaham.Columns[6].Visible = true;
                dgPemegangSaham.Columns[7].Visible = true;
                dgPemegangSaham.Columns[8].Visible = false;

                dgKomisaris.ShowFooter = false;
                dgKomisaris.Columns[5].Visible = true;
                dgKomisaris.Columns[6].Visible = true;
                dgKomisaris.Columns[7].Visible = false;

                dgNPWPLainnya.ShowFooter = false;
                dgNPWPLainnya.Columns[4].Visible = false;

                fuSK.Visible = false;
                fuAkte.Visible = false;
                fuSKDP.Visible = false;
                fuNPWP.Visible = false;
                fuSKT.Visible = false;
                fuAPV.Visible = false;
                fuSetoranModal.Visible = false;

                txtNoAkte.Visible = false;
                dtTanggalAkte.Visible = false;
                txtNotarisAkte.Visible = false;
                txtKeteranganAkte.Visible = false;

            }
            else if (mode == "edit")
            {
                btnSaveUpdate.Text = "Update";
                ltrtxtModalDasarNominalSemula.Visible = false;
                ltrtxtModalDasarNominalMenjadi.Visible = false;
                ltrtxtModalSetorNominalSemula.Visible = false;
                ltrtxtModalSetorNominalMenjadi.Visible = false;

                ltrddlTempatKedudukan.Visible = false;
                ltrCompanyCode.Visible = false;
                ltrAlasanPerubahan.Visible = false;
                ltrEmailPemohon.Visible = false;
                ltrNamaPemohon.Visible = false;
                ltrMataUang.Visible = false;
                ltrRemarks.Visible = false;
                ltrSKMulaiBerlaku.Visible = false;
                ltrSKNo.Visible = false;
                ltrBNRINo.Visible = false;
                ltrBNRIKeterangan.Visible = false;
                ltrSKDPKeterangan.Visible = false;
                ltrSKDPNo.Visible = false;
                ltrNoNPWP.Visible = false;
                ltrNominalMataUang.Visible = false;
                ltrBNRIMulaiBerlaku.Visible = false;
                ltrSKDPTanggalMulai.Visible = false;
                ltrSKDPTanggalAkhir.Visible = false;
                ltrSKNo.Visible = false;
                ltrTanggalTerdaftarNPWP.Visible = false;
                ltrNamaKPP.Visible = false;
                ltrKeteranganNPWP.Visible = false;
                ltrKodePerusahaanAPV.Visible = false;
                ltrNoAPV.Visible = false;
                ltrTanggalAPV.Visible = false;
                ltrKeteranganAPV.Visible = false;
                ltrTanggalSetoran.Visible = false;
                ltrKeteranganSetoran.Visible = false;
                ltrStatusSetoran.Visible = false;
                ltrSKNo.Visible = false;
                ltrSKMulaiBerlaku.Visible = false;
                ltrSKKeterangan.Visible = false;
                ltrNoAkte.Visible = false;
                ltrNotarisAkte.Visible = false;
                ltrKeteranganAkte.Visible = false;
                ltrTanggalAkte.Visible = false;
                ltrAlamatSKDP.Visible = false; 

                dgPemegangSaham.Columns[6].Visible = true;
                dgPemegangSaham.Columns[7].Visible = true;

                dgKomisaris.Columns[5].Visible = true;
                dgKomisaris.Columns[6].Visible = true;

                if (ltrfuAkte.Text.Trim() == string.Empty)
                    reqfuAkte.Visible = true;
                else
                    reqfuAkte.Visible = false;

                if (ltrfuSKDP.Text.Trim() == string.Empty)
                    reqfuSKDP.Visible = true;
                else
                    reqfuSKDP.Visible = false;

                if (ltrfuSK.Text.Trim() == string.Empty)
                    reqfuSK.Visible = true;
                else
                    reqfuSK.Visible = false;

                if (ltrfuSKT.Text.Trim() == string.Empty)
                    reqfuSKT.Visible = true;
                else
                    reqfuSKT.Visible = false;

                if (ltrfuNPWP.Text.Trim() == string.Empty)
                    reqfuNPWP.Visible = true;
                else
                    reqfuNPWP.Visible = false;

                if (ltrfuAPV.Text.Trim() == string.Empty)
                    reqfuAPV.Visible = true;
                else
                    reqfuAPV.Visible = false;

                if (ltrfuSetoranModal.Text.Trim() == string.Empty)
                    reqfuSetoranModal.Visible = true;
                else
                    reqfuSetoranModal.Visible = false;
            }

            switch (workflowStatus)
            {
                case "Entry Perubahan Anggaran Dasar" :
                case "Entry request perubahan anggaran dasar":
                    break; 
                case "Approve oleh Authorized Person":
                    divPerubahanDataPerseroan.Visible = true;
                    divPerubahanAnggaran.Visible = false;
                    break;
                case "PIC Update Akta":
                    divPerubahanDataPerseroan.Visible = true;
                    divPerubahanAnggaran.Visible = true;
                    divAkta.Visible = true; break;
                case "PIC Upload SKDP":
                    divPerubahanDataPerseroan.Visible = true;
                    divPerubahanAnggaran.Visible = true;
                    divAkta.Visible = true;
                    divSKDP.Visible = true; break;
                case "PIC Upload NPWP dan SKT":
                    divPerubahanDataPerseroan.Visible = true;
                    divPerubahanAnggaran.Visible = true;
                    divAkta.Visible = true;
                    divSKDP.Visible = true;
                    divNPWPSKT.Visible = true; break;
                case "PIC Upload APV":
                    divPerubahanDataPerseroan.Visible = true;
                    divPerubahanAnggaran.Visible = true;
                    divAkta.Visible = true;
                    if (rdPerubahanNama.SelectedValue.Equals("Yes"))
                    {
                        divSKDP.Visible = true;
                        divNPWPSKT.Visible = true;
                    }
                    divAccounting.Visible = true; break;
                case "PIC Upload Setoran Modal":
                    divPerubahanDataPerseroan.Visible = true;
                    divPerubahanAnggaran.Visible = true;
                    divAkta.Visible = true;
                    if (rdPerubahanNama.SelectedValue.Equals("Yes"))
                    {
                        divSKDP.Visible = true;
                        divNPWPSKT.Visible = true;
                    }
                    divAccounting.Visible = true;
                    divFinance.Visible = true; break;
                case "PIC Upload SK Persetujuan":
                    divPerubahanDataPerseroan.Visible = true;
                    divPerubahanAnggaran.Visible = true;
                    divAkta.Visible = true;
                    if (rdPerubahanNama.SelectedValue.Equals("Yes"))
                    {
                        divSKDP.Visible = true;
                        divNPWPSKT.Visible = true;
                    }

                    if (rdPerubahanModal.SelectedValue.Equals("Yes"))
                    {
                        divAccounting.Visible = true;
                        divFinance.Visible = true;
                    }

                    divSK.Visible = true; break;
                default:

                    if (!string.IsNullOrEmpty(ViewState["Status"].ToString()))
                    {
                        divPerubahanDataPerseroan.Visible = true;
                        divPerubahanAnggaran.Visible = true;
                        divAkta.Visible = true;
                        if (rdPerubahanNama.SelectedValue.Equals("Yes"))
                        {
                            divSKDP.Visible = true;
                            divNPWPSKT.Visible = true;
                        }

                        if (rdPerubahanModal.SelectedValue.Equals("Yes"))
                        {
                            divAccounting.Visible = true;
                            divFinance.Visible = true;
                        }

                        divSK.Visible = true;
                        divBNRI.Visible = true;
                    }
                    break;
            }
        }

        private void BindKomisarisDireksiJabatan(DropDownList ddl)
        {
            DataTable dt = Util.GetKomisarisDireksiJabatan(web);
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataSource = dt;
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
        }

        private bool isExistInKomisarisDireksiGrid(string Nama)
        {
            foreach (DataGridItem item in dgKomisaris.Items)
            {
                Label lblNama = item.FindControl("lblNama") as Label;
                if (lblNama != null)
                {
                    if (lblNama.Text.Trim().ToLower() == Nama.Trim().ToLower())
                        return true;
                }
            }
            return false;
        }

        private bool isExistInPemegangSahamGrid(string Nama)
        {
            foreach (DataGridItem item in dgPemegangSaham.Items)
            {
                Label lblNama = item.FindControl("lblNamaPemegangSaham") as Label;
                if (lblNama != null)
                {
                    if (lblNama.Text.Trim().ToLower() == Nama.Trim().ToLower())
                        return true;
                }
            }
            return false;
        }

        private bool isExistInNPWPGrid(string Nama, string Label)
        {
            foreach (DataGridItem item in dgNPWPLainnya.Items)
            {
                Label lblNama = item.FindControl(Label) as Label;
                if (lblNama != null)
                {
                    if (lblNama.Text.Trim().ToLower() == Nama.Trim().ToLower())
                        return true;
                }
            }
            return false;
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
                SPUtility.Redirect(SPContext.Current.Web.Url, SPRedirectFlags.UseSource, this.Context);
            else
                Util.ShowMessage(Page, result);
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Util.RegisterStartupScript(Page, "Pemohon", "RegisterDialog('divPemohonSearch','divPemohonDlgContainer', '550');");
            Util.RegisterStartupScript(Page, "Company", "RegisterDialog('divCompanySearch','divCompanyDlgContainer', '700');");

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

                    string mode = Request.QueryString["mode"] == null ? string.Empty : Request.QueryString["mode"].ToString();
                    Source = Request.QueryString["Source"] == null ? string.Empty : Request.QueryString["Source"].ToString();

                    if (!IsPostBack)
                    {
                        ViewState["Status"] = string.Empty;
                        try
                        {
                            string AdministratorGroup = Util.GetSettingValue(web, "SharePoint Group", "Administrator");
                            ViewState["Admin"] = Util.IsUserExistInSharePointGroup(web, SPContext.Current.Web.CurrentUser.LoginName, AdministratorGroup);
                        }
                        catch
                        {
                            ViewState["Admin"] = false;
                        }


                        ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");
                        BindKontrol();

                        txtModalDasarNominalSemula.Attributes.Add("onkeyup", "FormatNumber('" + txtModalDasarNominalSemula.ClientID + "'); Total('" + txtModalDasarNominalSemula.ClientID + "','" + txtNominalMataUang.ClientID + "','" + txtModalDasarNominalMenjadi.ClientID + "');");
                        txtModalDasarNominalSemula.Attributes.Add("onblur", " FormatNumber('" + txtModalDasarNominalSemula.ClientID + "')");

                        txtModalSetorNominalSemula.Attributes.Add("onkeyup", "FormatNumber('" + txtModalSetorNominalSemula.ClientID + "'); Total('" + txtModalSetorNominalSemula.ClientID + "','" + txtNominalMataUang.ClientID + "','" + txtModalSetorNominalMenjadi.ClientID + "');");
                        txtModalSetorNominalSemula.Attributes.Add("onblur", " FormatNumber('" + txtModalSetorNominalSemula.ClientID + "')");


                        txtNominalMataUang.Attributes.Add("onkeyup", "FormatNumber('" + txtNominalMataUang.ClientID + "'); Total('" + txtModalDasarNominalSemula.ClientID + "','" + txtNominalMataUang.ClientID + "','" + txtModalDasarNominalMenjadi.ClientID + "'); Total('" + txtModalSetorNominalSemula.ClientID + "','" + txtNominalMataUang.ClientID + "','" + txtModalSetorNominalMenjadi.ClientID + "');");
                        txtNominalMataUang.Attributes.Add("onblur", " FormatNumber('" + txtNominalMataUang.ClientID + "')");

                        if (isID)
                            Display(mode);

                    }
                }
            }
        }
        protected void txtModalDasarNominalSemula_TextChanged(object sender, EventArgs e)
        {
            double nominal = 0;
            double dasarNominal = 0;

            double.TryParse(txtNominalMataUang.Text, out nominal);
            txtNominalMataUang.Text = nominal.ToString();

            double.TryParse(txtModalDasarNominalSemula.Text, out dasarNominal);
            txtModalDasarNominalSemula.Text = dasarNominal.ToString();

            txtModalDasarNominalMenjadi.Text = (dasarNominal * nominal).ToString();
        }

        protected void txtModalSetorNominalSemula_TextChanged(object sender, EventArgs e)
        {
            double nominal = 0;
            double dasarNominal = 0;

            double.TryParse(txtNominalMataUang.Text, out nominal);
            txtNominalMataUang.Text = nominal.ToString();

            double.TryParse(txtModalSetorNominalSemula.Text, out dasarNominal);
            txtModalSetorNominalSemula.Text = dasarNominal.ToString();

            txtModalSetorNominalMenjadi.Text = (dasarNominal * nominal).ToString();
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

        protected void imgbtnNamaPemohon_Click(object sender, ImageClickEventArgs e)
        {
            grvPemohon.Visible = false;
        }

        protected void imgbtnNamaCompany_Click(object sender, ImageClickEventArgs e)
        {
            grvCompanySearch.Visible = false;
        }

        protected void btnCancelPemohon_Click(object sender, EventArgs e)
        {
            VisiblePanel(false);
        }

        protected void btnSaveUpdateRunWf_Click(object sender, EventArgs e)
        {
            SaveAction("SaveRunWf");
        }

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

        protected void grvPemohon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItemIndex < 0)
                return;

            DataRowView dr = e.Row.DataItem as DataRowView;

            Literal ltrrb = e.Row.FindControl("ltrrb") as Literal;
            ltrrb.Text = string.Format("<input type='radio' name='rbPemohon' id='Row{0}' value='{0}' />", dr["ID"].ToString());
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

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            SaveAction("Save");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SPUtility.Redirect(SPContext.Current.Web.Url, SPRedirectFlags.UseSource, this.Context);
        }

        protected void grvCompanySearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItemIndex < 0)
                return;

            DataRowView dr = e.Row.DataItem as DataRowView;
            Literal ltrrb = e.Row.FindControl("ltrrb") as Literal;
            ltrrb.Text = string.Format("<input type='radio' name='rbCompanySearch' id='Row{0}' value='{0}' />", dr["ID"].ToString());
        }

        protected void btnSelectCompany_Click(object sender, EventArgs e)
        {
            if (Request.Form["rbCompanySearch"] != null)
            {
                string IDPemohon = Request.Form["rbCompanySearch"].ToString();
                DisplayCompany(false, Convert.ToInt32(IDPemohon));
                Util.RegisterStartupScript(Page, "closeCompanySearch", "closeDialog('divCompanySearch');");
            }
            else
                Util.ShowMessage(Page, "Please choose Company");
        }

        protected void btnSearchCompany_Click(object sender, EventArgs e)
        {
            BindCompanySearch();
        }

        protected void dgKomisarisSemula_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            KomisarisDireksi o = e.Item.DataItem as KomisarisDireksi;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (o.MulaiMenjabat != null)
                {
                    Label lblTanggalMulaiMenjabat = e.Item.FindControl("lblTanggalMulaiMenjabat") as Label;
                    lblTanggalMulaiMenjabat.Text = Convert.ToDateTime(o.MulaiMenjabat).ToString("dd-MMM-yyyy");
                }

                if (o.AkhirMenjabat != null)
                {
                    Label lblTanggalAkhirMenjabat = e.Item.FindControl("lblTanggalAkhirMenjabat") as Label;
                    lblTanggalAkhirMenjabat.Text = Convert.ToDateTime(o.AkhirMenjabat).ToString("dd-MMM-yyyy");
                }
            }
        }

        protected void dgKomisaris_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            KomisarisDireksi o = e.Item.DataItem as KomisarisDireksi;
            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddlJabatanAdd = e.Item.FindControl("ddlJabatanAdd") as DropDownList;
                BindKomisarisDireksiJabatan(ddlJabatanAdd);

                TextBox txtNamaAdd = e.Item.FindControl("txtNamaAdd") as TextBox;
                txtNamaAdd.Attributes.Add("onkeyup", "KomisarisDireksi('" + txtNamaAdd.ClientID + "');");
            }
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DropDownList ddlJabatanEdit = e.Item.FindControl("ddlJabatanEdit") as DropDownList;
                BindKomisarisDireksiJabatan(ddlJabatanEdit);
                ddlJabatanEdit.SelectedValue = o.IDJabatan.ToString();

                TextBox txtNamaEdit = e.Item.FindControl("txtNamaEdit") as TextBox;
                txtNamaEdit.Attributes.Add("onkeyup", "KomisarisDireksi('" + txtNamaEdit.ClientID + "');");

                if (o.MulaiMenjabat != null)
                {
                    DateTimeControl dtTanggalMulaiMenjabatEdit = e.Item.FindControl("dtTanggalMulaiMenjabatEdit") as DateTimeControl;
                    dtTanggalMulaiMenjabatEdit.SelectedDate = Convert.ToDateTime(o.MulaiMenjabat);
                }
                if (o.AkhirMenjabat != null)
                {
                    DateTimeControl dtTanggalAkhirMenjabatEdit = e.Item.FindControl("dtTanggalAkhirMenjabatEdit") as DateTimeControl;
                    dtTanggalAkhirMenjabatEdit.SelectedDate = Convert.ToDateTime(o.AkhirMenjabat);
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (o.MulaiMenjabat != null)
                {
                    Label lblTanggalMulaiMenjabat = e.Item.FindControl("lblTanggalMulaiMenjabat") as Label;
                    lblTanggalMulaiMenjabat.Text = Convert.ToDateTime(o.MulaiMenjabat).ToString("dd-MMM-yyyy");
                }

                if (o.AkhirMenjabat != null)
                {
                    Label lblTanggalAkhirMenjabat = e.Item.FindControl("lblTanggalAkhirMenjabat") as Label;
                    lblTanggalAkhirMenjabat.Text = Convert.ToDateTime(o.AkhirMenjabat).ToString("dd-MMM-yyyy");
                }
            }
        }

        protected void dgKomisaris_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<KomisarisDireksi> coll = new List<KomisarisDireksi>();
            if (ViewState["KomisarisDireksiMenjadi"] != null)
                coll = ViewState["KomisarisDireksiMenjadi"] as List<KomisarisDireksi>;

            if (e.CommandName == "add")
            {
                TextBox txtNamaAdd = e.Item.FindControl("txtNamaAdd") as TextBox;
                DropDownList ddlJabatanAdd = e.Item.FindControl("ddlJabatanAdd") as DropDownList;
                TextBox txtNoKTPAdd = e.Item.FindControl("txtNoKTPAdd") as TextBox;
                TextBox txtNoNPWPAdd = e.Item.FindControl("txtNoNPWPAdd") as TextBox;
                DateTimeControl dtTanggalMulaiMenjabatAdd = null;
                DateTimeControl dtTanggalAkhirMenjabatAdd = null;

                if (isExistInKomisarisDireksiGrid(txtNamaAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaAdd.Text.Trim()));
                    return;
                }

                KomisarisDireksi o = new KomisarisDireksi();
                o.Nama = txtNamaAdd.Text.Trim();
                o.IDJabatan = Convert.ToInt32(ddlJabatanAdd.SelectedValue);
                o.Jabatan = ddlJabatanAdd.SelectedItem.Text;
                o.NoKTP = txtNoKTPAdd.Text;
                o.NoNPWP = txtNoNPWPAdd.Text;

                dtTanggalMulaiMenjabatAdd = e.Item.FindControl("dtTanggalMulaiMenjabatAdd") as DateTimeControl;
                dtTanggalAkhirMenjabatAdd = e.Item.FindControl("dtTanggalAkhirMenjabatAdd") as DateTimeControl;
                if (dtTanggalMulaiMenjabatAdd != null && dtTanggalAkhirMenjabatAdd != null)
                {
                    o.MulaiMenjabat = dtTanggalMulaiMenjabatAdd.SelectedDate;
                    o.AkhirMenjabat = dtTanggalAkhirMenjabatAdd.SelectedDate;

                    int i = DateTime.Compare(dtTanggalMulaiMenjabatAdd.SelectedDate, dtTanggalAkhirMenjabatAdd.SelectedDate);
                    if (i > 0)
                    {
                        Util.ShowMessage(Page, "Tanggal Akhir Menjabat must be greater or equal than Tanggal Mulai Menjabat");
                        return;
                    }
                }

                o.ID = 0;
                coll.Add(o);

                ViewState["KomisarisDireksiMenjadi"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtNamaEdit = e.Item.FindControl("txtNamaEdit") as TextBox;
                DropDownList ddlJabatanEdit = e.Item.FindControl("ddlJabatanEdit") as DropDownList;
                TextBox txtNoKTPEdit = e.Item.FindControl("txtNoKTPEdit") as TextBox;
                TextBox txtNoNPWPEdit = e.Item.FindControl("txtNoNPWPEdit") as TextBox;
                DateTimeControl dtTanggalMulaiMenjabatEdit = null;
                DateTimeControl dtTanggalAkhirMenjabatEdit = null;

                if (isExistInKomisarisDireksiGrid(txtNamaEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaEdit.Text.Trim()));
                    return;
                }

                KomisarisDireksi o = coll[e.Item.ItemIndex] as KomisarisDireksi;
                o.Nama = txtNamaEdit.Text.Trim();
                o.IDJabatan = Convert.ToInt32(ddlJabatanEdit.SelectedValue);
                o.Jabatan = ddlJabatanEdit.SelectedItem.Text;
                o.NoKTP = txtNoKTPEdit.Text;
                o.NoNPWP = txtNoNPWPEdit.Text;

                dtTanggalMulaiMenjabatEdit = e.Item.FindControl("dtTanggalMulaiMenjabatEdit") as DateTimeControl;
                dtTanggalAkhirMenjabatEdit = e.Item.FindControl("dtTanggalAkhirMenjabatEdit") as DateTimeControl;
                if (dtTanggalMulaiMenjabatEdit != null && dtTanggalAkhirMenjabatEdit != null)
                {
                    o.MulaiMenjabat = dtTanggalMulaiMenjabatEdit.SelectedDate;
                    o.AkhirMenjabat = dtTanggalAkhirMenjabatEdit.SelectedDate;

                    int i = DateTime.Compare(dtTanggalMulaiMenjabatEdit.SelectedDate, dtTanggalAkhirMenjabatEdit.SelectedDate);
                    if (i > 0)
                    {
                        Util.ShowMessage(Page, "Tanggal Akhir Menjabat must be greater or equal than Tanggal Mulai Menjabat");
                        return;
                    }
                }

                coll[e.Item.ItemIndex] = o;
                ViewState["KomisarisDireksiMenjadi"] = coll;

                dgKomisaris.EditItemIndex = -1;
                dgKomisaris.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgKomisaris.ShowFooter = false;
                dgKomisaris.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgKomisaris.EditItemIndex = -1;
                dgKomisaris.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                KomisarisDireksi o = coll[e.Item.ItemIndex] as KomisarisDireksi;
                o.IsDeleted = true;
                coll[e.Item.ItemIndex] = o;
                ViewState["KomisarisDireksiMenjadi"] = coll;
            }
            BindKomisarisDireksiMenjadi();
        }

        protected void dgPemegangSaham_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<PemegangSaham> coll = new List<PemegangSaham>();
            if (ViewState["PemegangSahamMenjadi"] != null)
                coll = ViewState["PemegangSahamMenjadi"] as List<PemegangSaham>;

            if (e.CommandName == "add")
            {
                TextBox txtNamaPemegangSahamAdd = e.Item.FindControl("txtNamaPemegangSahamAdd") as TextBox;
                TextBox txtJumlahSahamAdd = e.Item.FindControl("txtJumlahSahamAdd") as TextBox;
                TextBox txtJumlahNominalAdd = e.Item.FindControl("txtJumlahNominalAdd") as TextBox;
                TextBox txtPercentagesAdd = e.Item.FindControl("txtPercentagesAdd") as TextBox;
                CheckBox cboPartnerAdd = e.Item.FindControl("cboPartnerAdd") as CheckBox;
                DateTimeControl dtTanggalMulaiMenjabatAdd = null;
                DateTimeControl dtTanggalAkhirMenjabatAdd = null;

                if (isExistInPemegangSahamGrid(txtNamaPemegangSahamAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaPemegangSahamAdd.Text.Trim()));
                    return;
                }

                PemegangSaham o = new PemegangSaham();
                o.Nama = txtNamaPemegangSahamAdd.Text.Trim();
                o.JumlahNominal = Convert.ToDouble(txtJumlahNominalAdd.Text);
                o.JumlahSaham = Convert.ToDouble(txtJumlahSahamAdd.Text);
                o.Partner = cboPartnerAdd.Checked;
                o.Percentages = Convert.ToDouble(txtPercentagesAdd.Text);

                dtTanggalMulaiMenjabatAdd = e.Item.FindControl("dtTanggalMulaiMenjabatAdd") as DateTimeControl;
                dtTanggalAkhirMenjabatAdd = e.Item.FindControl("dtTanggalAkhirMenjabatAdd") as DateTimeControl;
                if (dtTanggalMulaiMenjabatAdd != null && dtTanggalAkhirMenjabatAdd != null)
                {
                    o.MulaiMenjabat = dtTanggalMulaiMenjabatAdd.SelectedDate;
                    o.AkhirMenjabat = dtTanggalAkhirMenjabatAdd.SelectedDate;

                    int i = DateTime.Compare(dtTanggalMulaiMenjabatAdd.SelectedDate, dtTanggalAkhirMenjabatAdd.SelectedDate);
                    if (i > 0)
                    {
                        Util.ShowMessage(Page, "Tanggal Akhir Menjabat must be greater or equal than Tanggal Mulai Menjabat");
                        return;
                    }
                }

                o.ID = 0;
                coll.Add(o);

                ViewState["PemegangSahamMenjadi"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtNamaPemegangSahamEdit = e.Item.FindControl("txtNamaPemegangSahamEdit") as TextBox;
                TextBox txtJumlahSahamEdit = e.Item.FindControl("txtJumlahSahamEdit") as TextBox;
                TextBox txtJumlahNominalEdit = e.Item.FindControl("txtJumlahNominalEdit") as TextBox;
                TextBox txtPercentagesEdit = e.Item.FindControl("txtPercentagesEdit") as TextBox;
                CheckBox cboPartnerEdit = e.Item.FindControl("cboPartnerEdit") as CheckBox;
                DateTimeControl dtTanggalMulaiMenjabatEdit = null;
                DateTimeControl dtTanggalAkhirMenjabatEdit = null;

                if (isExistInPemegangSahamGrid(txtNamaPemegangSahamEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaPemegangSahamEdit.Text.Trim()));
                    return;
                }

                PemegangSaham o = coll[e.Item.ItemIndex] as PemegangSaham;
                o.Nama = txtNamaPemegangSahamEdit.Text.Trim();
                o.JumlahNominal = Convert.ToDouble(txtJumlahNominalEdit.Text);
                o.JumlahSaham = Convert.ToDouble(txtJumlahSahamEdit.Text);
                o.Partner = cboPartnerEdit.Checked;
                o.Percentages = Convert.ToDouble(txtPercentagesEdit.Text);

                dtTanggalMulaiMenjabatEdit = e.Item.FindControl("dtTanggalMulaiMenjabatEdit") as DateTimeControl;
                dtTanggalAkhirMenjabatEdit = e.Item.FindControl("dtTanggalAkhirMenjabatEdit") as DateTimeControl;
                if (dtTanggalMulaiMenjabatEdit != null && dtTanggalAkhirMenjabatEdit != null)
                {
                    o.MulaiMenjabat = dtTanggalMulaiMenjabatEdit.SelectedDate;
                    o.AkhirMenjabat = dtTanggalAkhirMenjabatEdit.SelectedDate;

                    int i = DateTime.Compare(dtTanggalMulaiMenjabatEdit.SelectedDate, dtTanggalAkhirMenjabatEdit.SelectedDate);
                    if (i > 0)
                    {
                        Util.ShowMessage(Page, "Tanggal Akhir Menjabat must be greater or equal than Tanggal Mulai Menjabat");
                        return;
                    }
                }

                coll[e.Item.ItemIndex] = o;
                ViewState["PemegangSahamMenjadi"] = coll;

                dgPemegangSaham.EditItemIndex = -1;
                dgPemegangSaham.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgPemegangSaham.ShowFooter = false;
                dgPemegangSaham.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgPemegangSaham.EditItemIndex = -1;
                dgPemegangSaham.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                PemegangSaham o = coll[e.Item.ItemIndex] as PemegangSaham;
                o.IsDeleted = true;
                coll[e.Item.ItemIndex] = o;
                ViewState["PemegangSahamMenjadi"] = coll;
            }
            BindPemegangSahamMenjadi();
        }

        protected void dgPemegangSahamSemula_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            PemegangSaham o = e.Item.DataItem as PemegangSaham;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblPartner = e.Item.FindControl("lblPartner") as Label;
                lblPartner.Text = o.Partner == true ? "Yes" : "No";

                if (o.MulaiMenjabat != null)
                {
                    Label lblTanggalMulaiMenjabat = e.Item.FindControl("lblTanggalMulaiMenjabat") as Label;
                    lblTanggalMulaiMenjabat.Text = Convert.ToDateTime(o.MulaiMenjabat).ToString("dd-MMM-yyyy");
                }

                if (o.AkhirMenjabat != null)
                {
                    Label lblTanggalAkhirMenjabat = e.Item.FindControl("lblTanggalAkhirMenjabat") as Label;
                    lblTanggalAkhirMenjabat.Text = Convert.ToDateTime(o.AkhirMenjabat).ToString("dd-MMM-yyyy");
                }
            }
        }

        protected void dgPemegangSaham_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            PemegangSaham o = e.Item.DataItem as PemegangSaham;

            if (e.Item.ItemType == ListItemType.Footer)
            {
                TextBox txtJumlahSahamAdd = e.Item.FindControl("txtJumlahSahamAdd") as TextBox;
                TextBox txtJumlahNominalAdd = e.Item.FindControl("txtJumlahNominalAdd") as TextBox;
                TextBox txtPercentagesAdd = e.Item.FindControl("txtPercentagesAdd") as TextBox;

                txtJumlahSahamAdd.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamAdd.ClientID + "'); Total('" + txtJumlahSahamAdd.ClientID + "','" + txtModalSetorNominalSemula.ClientID + "','" + txtJumlahNominalAdd.ClientID + "'); Percentages('" + txtJumlahNominalAdd.ClientID + "','" + txtModalSetorNominalSemula.ClientID + "','" + txtPercentagesAdd.ClientID + "');");
                txtJumlahSahamAdd.Attributes.Add("onblur", " FormatNumber('" + txtJumlahSahamAdd.ClientID + "')");

                TextBox txtNamaPemegangSahamAdd = e.Item.FindControl("txtNamaPemegangSahamAdd") as TextBox;
                txtNamaPemegangSahamAdd.Attributes.Add("onkeyup", "PemegangSaham('" + txtNamaPemegangSahamAdd.ClientID + "');");
            }
            else if (e.Item.ItemType == ListItemType.EditItem)
            {
                TextBox txtJumlahSahamEdit = e.Item.FindControl("txtJumlahSahamEdit") as TextBox;
                TextBox txtJumlahNominalEdit = e.Item.FindControl("txtJumlahNominalEdit") as TextBox;
                TextBox txtPercentagesEdit = e.Item.FindControl("txtPercentagesEdit") as TextBox;

                txtJumlahSahamEdit.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamEdit.ClientID + "'); Total('" + txtJumlahSahamEdit.ClientID + "','" + txtModalSetorNominalSemula.ClientID + "','" + txtJumlahNominalEdit.ClientID + "'); Percentages('" + txtJumlahNominalEdit.ClientID + "','" + txtModalSetorNominalSemula.ClientID + "','" + txtPercentagesEdit.ClientID + "');");
                txtJumlahSahamEdit.Attributes.Add("onblur", " FormatNumber('" + txtJumlahSahamEdit.ClientID + "')");

                TextBox txtNamaPemegangSahamEdit = e.Item.FindControl("txtNamaPemegangSahamEdit") as TextBox;
                txtNamaPemegangSahamEdit.Attributes.Add("onkeyup", "PemegangSaham('" + txtNamaPemegangSahamEdit.ClientID + "');");

                if (o.MulaiMenjabat != null)
                {
                    DateTimeControl dtTanggalMulaiMenjabatEdit = e.Item.FindControl("dtTanggalMulaiMenjabatEdit") as DateTimeControl;
                    dtTanggalMulaiMenjabatEdit.SelectedDate = Convert.ToDateTime(o.MulaiMenjabat);
                }
                if (o.AkhirMenjabat != null)
                {
                    DateTimeControl dtTanggalAkhirMenjabatEdit = e.Item.FindControl("dtTanggalAkhirMenjabatEdit") as DateTimeControl;
                    dtTanggalAkhirMenjabatEdit.SelectedDate = Convert.ToDateTime(o.AkhirMenjabat);
                }
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblPartner = e.Item.FindControl("lblPartner") as Label;
                lblPartner.Text = o.Partner == true ? "Yes" : "No";

                if (o.MulaiMenjabat != null)
                {
                    Label lblTanggalMulaiMenjabat = e.Item.FindControl("lblTanggalMulaiMenjabat") as Label;
                    lblTanggalMulaiMenjabat.Text = Convert.ToDateTime(o.MulaiMenjabat).ToString("dd-MMM-yyyy");
                }

                if (o.AkhirMenjabat != null)
                {
                    Label lblTanggalAkhirMenjabat = e.Item.FindControl("lblTanggalAkhirMenjabat") as Label;
                    lblTanggalAkhirMenjabat.Text = Convert.ToDateTime(o.AkhirMenjabat).ToString("dd-MMM-yyyy");
                }
            }
        }

        protected void dgNPWPLainnya_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
                return;

            NPWP o = e.Item.DataItem as NPWP;

            if (!string.IsNullOrEmpty(o.Url))
            {
                Label lblAtttachment = e.Item.FindControl("lblAtttachment") as Label;
                lblAtttachment.Text = o.Url;
            }
        }

        protected void dgNPWPLainnya_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<NPWP> coll = new List<NPWP>();
            if (ViewState["NPWP"] != null)
                coll = ViewState["NPWP"] as List<NPWP>;

            if (e.CommandName == "add")
            {
                TextBox txtNPWPAdd = e.Item.FindControl("txtNPWPAdd") as TextBox;
                TextBox txtKeteranganAdd = e.Item.FindControl("txtKeteranganAdd") as TextBox;
                FileUpload fuAdd = e.Item.FindControl("fuAdd") as FileUpload;

                if (isExistInNPWPGrid(txtNPWPAdd.Text, "lblNPWP"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNPWPAdd.Text.Trim()));
                    return;
                }

                if (isExistInNPWPGrid(fuAdd.FileName, "lblAtttachmentHidden"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(fuAdd.FileName));
                    return;
                }

                NPWP o = new NPWP();
                o.NoNPWP = txtNPWPAdd.Text.Trim();

                Stream strm = fuAdd.PostedFile.InputStream;
                byte[] bytes = new byte[Convert.ToInt32(fuAdd.PostedFile.ContentLength)];
                strm.Read(bytes, 0, Convert.ToInt32(fuAdd.PostedFile.ContentLength));
                strm.Close();

                o.Attachment = bytes;
                o.NamaFile = fuAdd.FileName;
                o.Keterangan = txtKeteranganAdd.Text.Trim();
                o.ID = 0;
                coll.Add(o);

                ViewState["NPWP"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtNPWPEdit = e.Item.FindControl("txtNPWPEdit") as TextBox;
                TextBox txtKeteranganEdit = e.Item.FindControl("txtKeteranganEdit") as TextBox;
                FileUpload fuEdit = e.Item.FindControl("fuEdit") as FileUpload;

                if (isExistInNPWPGrid(txtNPWPEdit.Text, "lblNPWP"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNPWPEdit.Text.Trim()));
                    return;
                }

                if (isExistInNPWPGrid(fuEdit.FileName, "lblAtttachmentHidden"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(fuEdit.FileName));
                    return;
                }

                NPWP o = coll[e.Item.ItemIndex] as NPWP;
                o.NoNPWP = txtNPWPEdit.Text.Trim();

                if (fuEdit.PostedFile != null)
                {
                    if (fuEdit.PostedFile.ContentLength > 0)
                    {
                        Stream strm = fuEdit.PostedFile.InputStream;
                        byte[] bytes = new byte[Convert.ToInt32(fuEdit.PostedFile.ContentLength)];
                        strm.Read(bytes, 0, Convert.ToInt32(fuEdit.PostedFile.ContentLength));
                        strm.Close();

                        o.Attachment = bytes;
                        o.NamaFile = fuEdit.FileName;
                    }
                }

                o.Keterangan = txtKeteranganEdit.Text.Trim();

                coll[e.Item.ItemIndex] = o;
                ViewState["NPWP"] = coll;

                dgNPWPLainnya.EditItemIndex = -1;
                dgNPWPLainnya.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgNPWPLainnya.ShowFooter = false;
                dgNPWPLainnya.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgNPWPLainnya.EditItemIndex = -1;
                dgNPWPLainnya.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["NPWP"] = coll;
            }
            BindNPWP();
        }

        #endregion
    }

}
